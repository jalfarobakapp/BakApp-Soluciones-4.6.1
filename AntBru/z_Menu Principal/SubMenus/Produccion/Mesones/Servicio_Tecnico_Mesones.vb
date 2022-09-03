Imports DevComponents.DotNetBar
Imports Bk_Produccion
Imports BkSpecialPrograms


Public Class Servicio_Tecnico_Mesones
    Private Sub Btn_Asignacion_OT_Al_Meson_ST_Click(sender As Object, e As EventArgs) Handles Btn_Asignacion_OT_Al_Meson_ST.Click

        Dim Fm As New Frm_Meson_Asignar_Productos(Frm_Meson_Asignar_Productos.Enum_Tipo_OT.Servicio_Tecnico)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Frm_Menu.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

End Class
