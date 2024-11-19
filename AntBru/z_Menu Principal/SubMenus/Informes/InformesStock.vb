'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class InformesStock

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Public Sub New(ByVal Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre
    End Sub

    Private Sub Btn_Informe_Stock_Valorizado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_Stock_Valorizado.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Infst005") Then
            Dim Fm As New Frm_Informe_Stock_Valorizado
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_Proyeccion_Stock_Click(sender As Object, e As EventArgs) Handles Btn_Proyeccion_Stock.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Infst006") Then
            Dim Fm As New Frm_InfProyStXVnta_Estudio
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

End Class
