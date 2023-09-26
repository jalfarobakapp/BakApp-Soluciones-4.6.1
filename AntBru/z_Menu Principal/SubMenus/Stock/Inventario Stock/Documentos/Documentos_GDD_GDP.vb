Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Documentos_GDD_GDP

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

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre

    End Sub

    Private Sub Btn_GDD_PRE_Click(sender As Object, e As EventArgs) Handles Btn_GDD_PRE.Click
        Dim _Tido = "GDD"
        Sb_Generar_Documento(_Fm_Menu_Padre, _Tido, True, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Guia_Devolucion_Prestamo_GDD_PRE, "PRE")
    End Sub

    Private Sub Btn_GDP_PRE_Click(sender As Object, e As EventArgs) Handles Btn_GDP_PRE.Click
        Dim _Tido = "GDP"
        Sb_Generar_Documento(_Fm_Menu_Padre, _Tido, True, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Guia_Despacho_Prestamo_GDP_PRE, "PRE")
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_GDD_CON_Click(sender As Object, e As EventArgs) Handles Btn_GDD_CON.Click
        Dim _Tido = "GDD"
        Sb_Generar_Documento(_Fm_Menu_Padre, _Tido, True, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Guia_Devolucion_Consignaciones_GDD_CON, "CON")
    End Sub

    Private Sub Btn_GDP_CON_Click(sender As Object, e As EventArgs) Handles Btn_GDP_CON.Click
        Dim _Tido = "GDP"
        Sb_Generar_Documento(_Fm_Menu_Padre, _Tido, True, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Guia_Despacho_Consignaciones_GPD_CON, "CON")
    End Sub

    Private Sub Documentos_GDD_GDP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
