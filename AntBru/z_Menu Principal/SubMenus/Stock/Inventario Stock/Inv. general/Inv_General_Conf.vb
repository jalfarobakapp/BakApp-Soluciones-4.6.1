Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Inv_General_Conf

    Private Sub BtnSisinvenParcializado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If Fx_Tiene_Permiso(Me, "In0002") Then
        'Frm_Inv_MantencionBodegas.ShowDialog(Me)
        'End If
    End Sub

    Private Sub BtnPreciosCostos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPreciosCostos.Click

        'Consulta_sql = "SELECT TOP 1 IdInventario, Ano, Mes, Dia, Fecha_Inventario, Empresa, Sucursal, Bodega, Nombre_Empresa, Nombre_Sucursal, Nombre_Bodega, NombreInventario, " & vbCrLf &
        '                   "FuncionarioCargo, NombreFuncionario, Estado, FechaCierre" & vbCrLf &
        '                   "FROM Zw_TmpInv_History" & vbCrLf &
        '                   "Where Estado = 1"

        'Dim _IdInventario As Integer = trae_dato(tb, cn1, "IdInventario", "Zw_TmpInv_History", "Estado = 1")

        'If CBool(_IdInventario) Then

        'Nro = "In0003"
        'If Fx_Tiene_Permiso(Me, Nro) Then
        'Dim NewPanel As Mnu_Ubic_Prod = Nothing
        'NewPanel = New Mnu_Ubic_Prod()
        'NewPanel._ImpDesdeInventario = True
        'NewPanel._IdInventario = _IdInventario
        '
        'Frm_Menu.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
        'End If
        'Else
        'MessageBoxEx.Show("No existe ningún inventario activo", "Ubicaciones", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End If
    End Sub

    Private Sub BtnInformes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInformes.Click
        ' Dim Fm As New Frm_Inv_MantencionUsuariosLideres
        ' Fm.ShowDialog(Me)
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Frm_Menu.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub
End Class
