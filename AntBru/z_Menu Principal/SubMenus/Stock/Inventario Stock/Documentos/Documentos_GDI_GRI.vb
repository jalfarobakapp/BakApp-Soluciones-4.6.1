Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Documentos_GDI_GRI

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
    Private Sub Documentos_GDI_GRI_Load(sender As Object, e As EventArgs) Handles Me.Load
        If RutEmpresa = "85904700-9" Then
            'Me.Width = 634
            Btn_GDI_GRI.Visible = True
            'Documentos_GDI_GRI 634
        End If
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_GRI_Click(sender As Object, e As EventArgs) Handles Btn_GRI.Click
        Dim _Tido = "GRI"
        Sb_Generar_Documento(_Fm_Menu_Padre, _Tido, True, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Guia_Recepcion_Interna, "")
    End Sub

    Private Sub Btn_GRI_Ajuste_Click(sender As Object, e As EventArgs) Handles Btn_GRI_Ajuste.Click
        Dim _Tido = "GRI"
        Sb_Generar_Documento(_Fm_Menu_Padre, _Tido, True, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Guia_Recepcion_Interna, "AJU")
    End Sub

    Private Sub Btn_GDI_Click(sender As Object, e As EventArgs) Handles Btn_GDI.Click
        Dim _Tido = "GDI"
        Sb_Generar_Documento(_Fm_Menu_Padre, _Tido, True, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Guia_Despacho_Interna, "")
    End Sub

    Private Sub Btn_GDI_Ajuste_Click(sender As Object, e As EventArgs) Handles Btn_GDI_Ajuste.Click
        Dim _Tido = "GDI"
        Sb_Generar_Documento(_Fm_Menu_Padre, _Tido, True, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Guia_Despacho_Interna, "AJU")
    End Sub

    Private Sub Btn_GDI_GRI_Click(sender As Object, e As EventArgs) Handles Btn_GDI_GRI.Click

        Dim Fm As New Frm_GDI2GRI
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub


End Class
