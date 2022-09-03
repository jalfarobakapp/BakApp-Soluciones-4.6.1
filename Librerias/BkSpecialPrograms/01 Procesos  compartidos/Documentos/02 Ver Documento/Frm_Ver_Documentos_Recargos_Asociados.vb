Imports DevComponents.DotNetBar

Public Class Frm_Ver_Documentos_Recargos_Asociados

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Idmaeedo As Integer
    Dim _Nulido As String

    Public Sub New(_Idmaeedo As Integer, _Nulido As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Idmaeedo = _Idmaeedo
        Me._Nulido = _Nulido

        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.LightYellow, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Ver_Documentos_Recargos_Asociados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select Ddo_Rec.IDMAEEDO,Ddo_Rec.IDMAEDDO,Ddo_Rec.TIDO,Ddo_Rec.NUDO,Ddo_Rec.ENDO,Ddo_Rec.SUENDO,NOKOEN," &
                        "Ddo_Rec.KOPRCT,Ddo_Rec.NOKOPR,Ddo_Rec.MOPPPR,Rec.* 
                        From MAEDCR Rec
                            Inner Join MAEDDO Ddo_Rec On Ddo_Rec.IDMAEDDO = Rec.IDDDODCR
                                Left Join MAEEN On Ddo_Rec.ENDO = KOEN And Ddo_Rec.SUENDO = SUEN
                        Where Rec.IDMAEEDO = " & _Idmaeedo & " And Rec.NULIDO = '" & _Nulido & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Width = 30
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Width = 80
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("KOPRCT").HeaderText = "Código"
            .Columns("KOPRCT").Width = 100
            .Columns("KOPRCT").Visible = True
            .Columns("KOPRCT").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Width = 270
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("MOPPPR").HeaderText = "TM."
            .Columns("MOPPPR").Visible = True
            .Columns("MOPPPR").Width = 30
            .Columns("MOPPPR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("MOPPPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("VALDCR").HeaderText = "Valor distribuido"
            .Columns("VALDCR").ToolTipText = "Valor distribuido"
            .Columns("VALDCR").Width = 100
            .Columns("VALDCR").Visible = True
            .Columns("VALDCR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VALDCR").DefaultCellStyle.Format = "###,##0.##"
            .Columns("VALDCR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Idmaeedo As Integer = _Fila.Cells("IDMAEEDO").Value
        Dim _Idmaeddo As Integer = _Fila.Cells("IDMAEDDO").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.Btn_Ver_Orden_de_despacho.Visible = False
        Fm.Idrst = _Idmaeddo
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Frm_Ver_Documentos_Recargos_Asociados_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
