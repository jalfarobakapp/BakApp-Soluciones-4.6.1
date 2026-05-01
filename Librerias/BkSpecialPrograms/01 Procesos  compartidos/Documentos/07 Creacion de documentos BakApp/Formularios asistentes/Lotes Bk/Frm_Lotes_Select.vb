Public Class Frm_Lotes_Select

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl As DataTable
    Public Property Row_Lote As DataRow

    Dim _Empresa As String
    Dim _Sucursal As String
    Dim _Bodega As String
    Dim _Codigo As String

    Public Sub New(_Empresa As String, _Sucursal As String, _Bodega As String, _Codigo As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Empresa = _Empresa
        Me._Sucursal = _Sucursal
        Me._Bodega = _Bodega
        Me._Codigo = _Codigo

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.LightYellow, ScrollBars.None, True, True, False)
        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Lotes_Select_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select Empresa, Sucursal, Bodega, NroLote, SubLote, Codigo, Stfilt1, Stfilt2" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Prod_Stock_Lote" & vbCrLf &
                       "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "' And Codigo = '" & _Codigo & "'"
        _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _DisplayIndex = 0

        With Grilla

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Empresa").ReadOnly = True
            .Columns("Empresa").Width = 80
            .Columns("Empresa").HeaderText = "Empresa"
            .Columns("Empresa").Visible = True
            .Columns("Empresa").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sucursal").ReadOnly = True
            .Columns("Sucursal").Width = 80
            .Columns("Sucursal").HeaderText = "Sucursal"
            .Columns("Sucursal").Visible = True
            .Columns("Sucursal").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Bodega").ReadOnly = True
            .Columns("Bodega").Width = 80
            .Columns("Bodega").HeaderText = "Bodega"
            .Columns("Bodega").Visible = True
            .Columns("Bodega").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NroLote").ReadOnly = True
            .Columns("NroLote").Width = 200
            .Columns("NroLote").HeaderText = "Lote"
            .Columns("NroLote").Visible = True
            .Columns("NroLote").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SubLote").ReadOnly = True
            .Columns("SubLote").Width = 100
            .Columns("SubLote").HeaderText = "Sub Lote"
            .Columns("SubLote").Visible = True
            .Columns("SubLote").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Stfilt1").Width = 60
            .Columns("Stfilt1").HeaderText = "Cantidad"
            .Columns("Stfilt1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Stfilt1").DefaultCellStyle.Format = "###,##0.0#"
            .Columns("Stfilt1").Visible = True
            .Columns("Stfilt1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        If e.RowIndex < 0 Then
            Return
        End If

        Try
            Dim drv = TryCast(Grilla.Rows(e.RowIndex).DataBoundItem, DataRowView)
            If drv IsNot Nothing Then
                Row_Lote = drv.Row
            ElseIf _Tbl IsNot Nothing AndAlso e.RowIndex < _Tbl.Rows.Count Then
                Row_Lote = _Tbl.Rows(e.RowIndex)
            Else
                Row_Lote = Nothing
            End If

            If Row_Lote IsNot Nothing Then
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If

        Catch ex As Exception
            ' Opcional: manejar/loguear la excepción según políticas del proyecto
        End Try

    End Sub

    Private Sub Btn_Seleccionar_Click(sender As Object, e As EventArgs) Handles Btn_Seleccionar.Click
        Call Grilla_CellDoubleClick(sender, New DataGridViewCellEventArgs(0, Grilla.CurrentRow.Index))
    End Sub
End Class
