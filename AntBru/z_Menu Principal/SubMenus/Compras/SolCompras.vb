'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class _02_SolCompras

    Dim NotifyIcon1 As NotifyIcon = Frm_Menu.Notify_SolCompra

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Public Sub New(ByVal Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre
    End Sub


    Private Sub _02_SolCompras_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler NotifyIcon1.Click, AddressOf Sb_Notifi_SolCompra_Click
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub MtBtnVerMisSolicitudes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MtBtnVerMisSolicitudes.Click
        Sb_Mis_Solicitudes()
    End Sub

    Private Sub MtBtnAutorizarSolicitudes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MtBtnAutorizarSolicitudes.Click
        Sb_Autorizaciones()
    End Sub

    Private Sub BtnConfiguracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConfiguracion.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Comp0027") Then
            'Dim Fm As New Frm_SolicitudCompra_Configuracion
            'Fm.ShowDialog(Me)
            'Fm.Dispose()
        End If
    End Sub

    Private Sub BtnCambiarDeUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCambiarDeUsuario.Click
        Dim NewPanel As Login = Nothing
        NewPanel = New Login(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Right)
    End Sub

    Private Function Fx_CheckForm(ByVal _form As Form) As Form

        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return f
            End If
        Next

        Return Nothing

    End Function

    Sub Sb_Mis_Solicitudes()

        'NotifyIcon1.Visible = True

        'Dim Frm_Cm As New Frm_SolicitudCompra_Permisos
        'Frm_Cm._SoloMisSolicitudes = True
        'Frm_Cm.Text = _Fm_Menu_Padre.Text
        'Me.Refresh()
        'Frm_Cm.ShowDialog(Me)

        'NotifyIcon1.Visible = True
        'NotifyIcon1.ShowBalloonTip(5, "Info. BakApp", "Solicitud de compra quedara en barra de tareas", ToolTipIcon.Info)

    End Sub

    Sub Sb_Autorizaciones()

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Comp0002") Then

            NotifyIcon1.Visible = False

            'Dim Frm_Cm As New Frm_SolicitudCompra_Permisos
            'Frm_Cm._SoloMisSolicitudes = False
            'Frm_Cm.Btn_Crear_SOC.Visible = False
            'Frm_Cm.Text = _Fm_Menu_Padre.Text
            'Me.Refresh()
            'Frm_Cm.ShowDialog(Me)

            'NotifyIcon1.Visible = True
            'NotifyIcon1.ShowBalloonTip(5, "Info. BakApp", "Solicitud de compra quedara en barra de tareas", ToolTipIcon.Info)

        End If

    End Sub

    Private Sub Sb_Notifi_SolCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowContextMenu(Menu_Contextual_01)
    End Sub


    Private Sub Btn_Mnu_Mis_Solicitudes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Mis_Solicitudes.Click
        Sb_Mis_Solicitudes()
    End Sub

    Private Sub Btn_Mnu_Autorizar_Solicitudes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Autorizar_Solicitudes.Click
        Sb_Autorizaciones()
    End Sub


End Class
