Imports DevComponents.DotNetBar
Imports BkSpecialPrograms


Public Class Modulo_Documentos_Stock

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Dim _Menu_Extra As Boolean

    Public Property Pro_Menu_Extra() As Boolean
        Get
            Return _Menu_Extra
        End Get
        Set(ByVal value As Boolean)
            _Menu_Extra = value
        End Set
    End Property

    Public Sub New(ByVal Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_NVI_Click(sender As Object, e As EventArgs) Handles Btn_NVI.Click
        Dim _Tido = "NVI"
        Sb_Generar_Documento(_Fm_Menu_Padre, _Tido, True, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Nota_Venta_Interna, "")
    End Sub

    Private Sub Btn_Guias_Click(sender As Object, e As EventArgs) Handles Btn_GDD.Click
        Dim _Tido = "GDD"
        Sb_Generar_Documento(_Fm_Menu_Padre, _Tido, True, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Guia_Despacho_Devolucion, "")
    End Sub

    Private Sub Btn_GTI_Click(sender As Object, e As EventArgs) Handles Btn_GTI.Click
        Dim _Tido = "GTI"
        Sb_Generar_Documento(_Fm_Menu_Padre, _Tido, True, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Guia_Traslado_Interno, "")
    End Sub

    Private Sub Btn_GRI_Click(sender As Object, e As EventArgs) Handles Btn_GRI.Click
        Dim _Tido = "GRI"
        Sb_Generar_Documento(_Fm_Menu_Padre, _Tido, True, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Guia_Recepcion_Interna, "")
    End Sub

    Private Sub Btn_GDP_GDD_Click(sender As Object, e As EventArgs) Handles Btn_GDP_GDD.Click
        If Fx_Revisar_Taza_Cambio(_Fm_Menu_Padre) Then
            Dim NewPanel As Documentos_GDD_GDP = Nothing
            NewPanel = New Documentos_GDD_GDP(_Fm_Menu_Padre)
            _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
        End If
    End Sub

    Private Sub Btn_Guia_Recepcion_Devoluciones_Click(sender As Object, e As EventArgs) Handles Btn_Guia_Recepcion_Devoluciones.Click
        Dim _Tido = "GRD"
        Modulo_Documentos.Sb_Generar_Documento(_Fm_Menu_Padre, _Tido, True, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Compra, "")
    End Sub
End Class
