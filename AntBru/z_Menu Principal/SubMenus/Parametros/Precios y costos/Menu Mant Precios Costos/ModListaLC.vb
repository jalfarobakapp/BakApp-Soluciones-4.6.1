Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class ModListaLC

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

    Public Sub New(Fm_Menu_Padre As Metro.MetroAppForm)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre
    End Sub

    Private Sub ModListaLC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn_LictaLC_Click(sender As Object, e As EventArgs) Handles Btn_LictaLC.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Pre0002") Then
            Dim Fm As New Frm_PreciosLC_Mt01
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_UltRecepciones_Click(sender As Object, e As EventArgs) Handles Btn_UltRecepciones.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Pre0002") Then
            Dim Fm As New Frm_PreciosLC_InfUltCompras_Mt
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_PreciosFuturo_Click(sender As Object, e As EventArgs) Handles Btn_PreciosFuturo.Click
        Dim Fm As New Frm_PrecioLCFuturo2
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub
End Class
