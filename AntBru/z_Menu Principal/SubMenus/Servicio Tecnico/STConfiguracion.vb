Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class STConfiguracion
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

    Private Sub Btn_Mantencion_Tecnicos_Click(sender As Object, e As EventArgs) Handles Btn_Mantencion_Tecnicos.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Stec0006") Then
            Dim Fm As New Frm_St_Lista_Tecnicos_Talleres
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Conf_Info_Reportes_Click(sender As Object, e As EventArgs) Handles Btn_Conf_Info_Reportes.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Stec0015") Then
            Dim Fm As New Frm_St_Notas_Reportes
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Recetas_Click(sender As Object, e As EventArgs) Handles Btn_Recetas.Click
        Dim Fm As New Frm_St_Recetas
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Operaciones_Click(sender As Object, e As EventArgs) Handles Btn_Operaciones.Click
        Dim Fm As New Frm_St_Operaciones
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

End Class
