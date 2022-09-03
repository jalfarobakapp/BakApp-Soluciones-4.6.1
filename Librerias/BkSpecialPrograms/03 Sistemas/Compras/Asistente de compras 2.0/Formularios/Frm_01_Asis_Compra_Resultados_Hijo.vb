Imports DevComponents.DotNetBar
Public Class Frm_01_Asis_Compra_Resultados_Hijo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    'Dim _Frm_Padre = CType(Me.Parent, Frm_01_Asis_Compra_Resultados)

    Dim _Ds As DataSet
    Dim _Dv, _Dv2 As New DataView

    Dim _Frm_Padre = CType(Me.Parent, Frm_01_Asis_Compra_Resultados)
    Dim _Modo_OCC As Boolean
    Dim _Modo_NVI As Boolean

    Public Property Modo_OCC As Boolean
        Get
            Return _Modo_OCC
        End Get
        Set(value As Boolean)
            _Modo_OCC = value

            LabelX4.Visible = _Modo_OCC
            Txt_Proveedor.Visible = _Modo_OCC
            Btn_Filtrar_Proveedor.Visible = _Modo_OCC
            Btn_Quitar_Filtro_Proveedor.Visible = _Modo_OCC
            Lbl_Costos_Desde.Visible = _Modo_OCC
            Cmb_Documento_Compra.Visible = _Modo_OCC
            LabelX6.Visible = _Modo_OCC
            Cmb_Tipo_de_compra.Visible = _Modo_OCC
            Me.Refresh()
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, False, False)

        Sb_Formato_Generico_Grilla(Grilla_GRC, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(Grilla_FCC, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(Grilla_GDD, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(Grilla_OCC, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        Sb_Formato_Generico_Grilla(Grill_Mensual, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Semanal, 13, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then

            MchMensuales.LineChartStyle.LineColor = Color.White
            McsSemanales.LineChartStyle.LineColor = Color.White

        End If

        AddHandler Grilla_GRC.CellDoubleClick, AddressOf Sb_Grilla_Detalle_Producto_CellDoubleClick
        AddHandler Grilla_FCC.CellDoubleClick, AddressOf Sb_Grilla_Detalle_Producto_CellDoubleClick
        AddHandler Grilla_GDD.CellDoubleClick, AddressOf Sb_Grilla_Detalle_Producto_CellDoubleClick
        AddHandler Grilla_OCC.CellDoubleClick, AddressOf Sb_Grilla_Detalle_Producto_CellDoubleClick

    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Dim Fm As New Frm_EOQ
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Sb_Grilla_Detalle_Producto_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)

        Dim Grilla = CType(sender, DataGridView)

        Grilla.Enabled = False

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value
        Dim _Idmaeddo = _Fila.Cells("IDMAEDDO").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.Idrst = _Idmaeddo
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Grilla.Enabled = True

    End Sub

End Class
