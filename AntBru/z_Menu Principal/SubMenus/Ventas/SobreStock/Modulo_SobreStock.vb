Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Modulo_SobreStock

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Dim _Menu_Extra As Boolean

    Public Property Pro_Menu_Extra() As Boolean
        Get
            Return _Menu_Extra
        End Get
        Set(value As Boolean)
            _Menu_Extra = value
        End Set
    End Property

    Public Sub New(Fm_Menu_Padre As Metro.MetroAppForm)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Fm_Menu_Padre = Fm_Menu_Padre

        If Global_Thema = Enum_Themas.Oscuro Then
            Sb_Color_Botones_Barra(Bar2)
        End If

    End Sub

    Private Sub Btn_COV_SobreStock_Click(sender As Object, e As EventArgs) Handles Btn_COV_SobreStock.Click

        If Not Fx_Tiene_Permiso(_Fm_Menu_Padre, "Sobs0006") Then
            Return
        End If

        Modulo_Documentos.Sb_Generar_Documento(_Fm_Menu_Padre,
                                        "COV",
                                        True,
                                        csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Venta, "STK")

    End Sub

    Private Sub Btn_ProductoSobreStock_Click(sender As Object, e As EventArgs) Handles Btn_ProductoSobreStock.Click

        If Not Fx_Tiene_Permiso(_Fm_Menu_Padre, "Sobs0001") Then
            Return
        End If

        Dim Fm As New Frm_SobreStock_Productos
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_CreaNVVdesdeCOVSobreStock_Click(sender As Object, e As EventArgs) Handles Btn_CreaNVVdesdeCOVSobreStock.Click

        If Not Fx_Tiene_Permiso(_Fm_Menu_Padre, "Sobs0007") Then
            Return
        End If

        Dim _Msj_Tsc As LsValiciones.Mensajes = Fx_Revisar_Tasa_Cambio(_Fm_Menu_Padre)

        If Not _Msj_Tsc.EsCorrecto Then
            Return
        End If

        Dim Fm As New Frm_BusquedaDocumento_Filtro(False)
        Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado, "COV", "Where TIDO = 'COV'")
        Fm.Rdb_Estado_Todas.Enabled = False
        Fm.Rdb_Estado_Vigente.Checked = True
        Fm.Rdb_Estado_Cerrado.Enabled = False
        Fm.Rdb_FEmision_EmitidosEntre.Checked = True
        Fm.Chk_Mostrar_Vales_Transitorios.Checked = False
        Fm.Chk_Mostrar_Vales_Transitorios.Enabled = False
        Fm.SobreStock = True
        Fm.ShowDialog(_Fm_Menu_Padre)
        Fm.Dispose()

    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub
End Class
