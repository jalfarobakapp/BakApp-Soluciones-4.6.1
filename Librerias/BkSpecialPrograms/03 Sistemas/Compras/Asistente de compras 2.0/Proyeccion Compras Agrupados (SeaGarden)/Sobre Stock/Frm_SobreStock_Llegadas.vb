Imports DevComponents.DotNetBar.SuperGrid

Public Class Frm_SobreStock_Llegadas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Codigo_Nodo_Madre As String
    Dim _Codigo As String

    Dim _Tbl_Llegadas As DataTable

    Public Sub New(_Codigo_Nodo_Madre As String, _Codigo As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me._Codigo = _Codigo
        Me._Codigo_Nodo_Madre = _Codigo_Nodo_Madre

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

    End Sub

    Private Sub Frm_SobreStock_Llegadas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla()
    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String = String.Empty

        If Not String.IsNullOrEmpty(_Codigo_Nodo_Madre) Then
            _Condicion = "And Codigo_Nodo_Madre = '" & _Codigo_Nodo_Madre & "'"
        End If

        If Not String.IsNullOrEmpty(_Codigo) Then
            _Condicion += "And Codigo = '" & _Codigo & "'"
        End If

        Consulta_sql = $"Select t.*,Isnull(m.NOKOPR,'???') As 'Descripcion'" & vbCrLf &
                       $"From Tbl_Asc_04_DocUltComp_{FUNCIONARIO} t" & vbCrLf &
                       "Inner Join MAEPR m On m.KOPR = t.Codigo" & vbCrLf &
                       $"Where 1>0 {_Condicion}"
        _Tbl_Llegadas = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Llegadas

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("TIDO").Width = 30
            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Visible = True

            .Columns("NUDO").Width = 90
            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Visible = True

            .Columns("ENDO").Width = 80
            .Columns("ENDO").HeaderText = "Entidad"
            .Columns("ENDO").Visible = True

            .Columns("SUENDO").Width = 50
            .Columns("SUENDO").HeaderText = "Suc."
            .Columns("SUENDO").Visible = True

            .Columns("Razon").Width = 260
            .Columns("Razon").HeaderText = "Nombre proveedor"
            .Columns("Razon").Visible = True

            .Columns("UD01PR").Width = 30
            .Columns("UD01PR").HeaderText = "UD"
            .Columns("UD01PR").Visible = True

            .Columns("CAPRCO1").Width = 60
            .Columns("CAPRCO1").HeaderText = "Cantidad"
            .Columns("CAPRCO1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CAPRCO1").DefaultCellStyle.Format = "###,##0.##"
            .Columns("CAPRCO1").Visible = True

            .Columns("CAPREX1").Width = 80
            .Columns("CAPREX1").HeaderText = "Cantidad" & vbCrLf & "recepcionada"
            .Columns("CAPREX1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CAPREX1").DefaultCellStyle.Format = "###,##0.##"
            .Columns("CAPREX1").Visible = True

            .Columns("Saldo").Width = 60
            .Columns("Saldo").HeaderText = "Saldo"
            .Columns("Saldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Saldo").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Saldo").Visible = True

            .Columns("FEERLI").Width = 100
            .Columns("FEERLI").HeaderText = "Fecha" & vbCrLf & "recepción"
            .Columns("FEERLI").Visible = True

        End With

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Grilla_Clasificaciones_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter

        Try
            Dim _Fila As DataGridViewRow = Grilla.Rows(e.RowIndex)
            Dim _Producto As String = _Fila.Cells("Codigo").Value & " - " & _Fila.Cells("Descripcion").Value

            Lbl_Producto.Text = _Producto
        Catch ex As Exception
            Lbl_Producto.Text = String.Empty
        End Try

    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Excel.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_Llegadas, Me, "Llegadas")
    End Sub

    Private Sub Grilla_Clasificaciones_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(e.RowIndex)
        Dim _Idmaeedo As Integer = _Fila.Cells("IDMAEEDO").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub
End Class
