Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Stk_Ticktes
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
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_MisTicket_Click(sender As Object, e As EventArgs) Handles Btn_MisTicket.Click

        Dim Fm As New Frm_Tickets_Lista(FUNCIONARIO, Frm_Tickets_Lista.Enum_Tickets.MisTicket, 0)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_TicketAsignados_Click(sender As Object, e As EventArgs) Handles Btn_TicketAsignados.Click

        Dim Fm As New Frm_Tickets_Lista(FUNCIONARIO, Frm_Tickets_Lista.Enum_Tickets.TicketAsignadosAgente, 0)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Configuracion_Click(sender As Object, e As EventArgs) Handles Btn_Configuracion.Click
        Dim NewPanel As Stk_Configuracion = Nothing
        NewPanel = New Stk_Configuracion(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub BtnCambiarDeUsuario_Click(sender As Object, e As EventArgs) Handles BtnCambiarDeUsuario.Click
        Dim NewPanel As Login = Nothing
        NewPanel = New Login(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Right)
    End Sub
End Class
