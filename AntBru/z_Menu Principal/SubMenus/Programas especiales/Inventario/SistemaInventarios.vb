Imports Funciones_BakApp
Imports BkSpecialPrograms

Public Class SistemaInventarios

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Frm_Menu.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub BtnSisinvenParcializado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSisinvenParcializado.Click
        Dim Nro As String = "Invp0001"
        If TienePermiso(Nro) Then

            Consulta_sql = "DROP TABLE TblMaeprPaso" & FUNCIONARIO
            Ej_consulta_IDU(Consulta_sql, cn1, , , False)


            Consulta_sql = Procedures.Busqueda_inventario_parcializado
            Consulta_sql = Replace(Consulta_sql, "TblMaeprPaso", "TblMaeprPaso" & FUNCIONARIO)
            Ej_consulta_IDU(Consulta_sql, cn1)

            Dim Frm_InvParc_01_MenuPrincipal As New Frm_InvParc_01_MenuPrincipal
            Frm_InvParc_01_MenuPrincipal.Show()
        Else
            MensajeSinPermiso(Nro)
        End If
    End Sub
End Class
