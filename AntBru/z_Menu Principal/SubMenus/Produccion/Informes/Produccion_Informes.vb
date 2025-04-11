Imports Bk_Produccion
Imports BkSpecialPrograms

Public Class Produccion_Informes

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Frm_Menu.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_Informe_Avance_OT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_Avance_OT.Click
        Dim Fm As New Frm_Inf_Prod_Avance_OT
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Informe_Ocupacion_Maquinas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_Ocupacion_Maquinas.Click
        Dim Fm As New Frm_Maquinas_vs_Carga_De_Trabajo
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Informe_Operarios_Estado_Click(sender As Object, e As EventArgs) Handles Btn_Informe_Operarios_Estado.Click

        Dim Fm As New Frm_Operarios_Estado
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Informe_Meson_Click(sender As Object, e As EventArgs) Handles Btn_Informe_Meson.Click

        Dim Fm As New Frm_Informe_Meson_Familias(Nothing, False)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub
End Class
