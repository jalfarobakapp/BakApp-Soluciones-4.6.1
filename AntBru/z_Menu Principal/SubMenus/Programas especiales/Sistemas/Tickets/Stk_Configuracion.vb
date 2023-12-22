Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Stk_Configuracion

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

    Private Sub Btn_Agentes_Click(sender As Object, e As EventArgs) Handles Btn_Agentes.Click

        Dim Fm As New Frm_Tickets_Agentes
        Fm.ShowDialog(_Fm_Menu_Padre)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Grupos_Click(sender As Object, e As EventArgs) Handles Btn_Grupos.Click

        Dim Fm As New Frm_Tickets_Grupos
        Fm.ShowDialog(_Fm_Menu_Padre)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Areas_Click(sender As Object, e As EventArgs) Handles Btn_Areas.Click

        Dim Fm As New Frm_Tickets_Areas
        Fm.ShowDialog(_Fm_Menu_Padre)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Tipos_Click(sender As Object, e As EventArgs)

        'Dim Fm As New Frm_Tickets_Tipos
        'Fm.ShowDialog(_Fm_Menu_Padre)
        'Fm.Dispose()

    End Sub
End Class
