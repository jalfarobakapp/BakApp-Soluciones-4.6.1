Imports DevComponents.DotNetBar
Imports Funciones_BakApp
Imports BkSpecialPrograms

Public Class Inv_Parcializado

    Private Sub BtnNuevoInventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevoInventario.Click

        Dim Fecha As String = Format(Date.Now, "yyyyMMdd")

        Dim Fm As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
        Fm.ShowDialog(Me)

        Dim _RowBodega As DataRow = Fm.Pro_RowBodega

        If Not (_RowBodega Is Nothing) Then

            Dim Fm_ As New Frm_Mt_InvParc_NuevoAjuste(_RowBodega)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If
      
    End Sub

   
    Private Sub BtnAbrirInventarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAbrirInventarios.Click

        Dim Fm As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
        Fm.Pro_Empresa = Mod_Empresa
        Fm.Pro_Sucursal = Mod_Sucursal
        Fm.Pro_Bodega = Mod_Bodega
        Fm.ShowDialog(Me)

        Dim _Seleccionado As Boolean = Fm.Pro_Seleccionado
        Dim _RowBodega As DataRow = Fm.Pro_RowBodega

        Fm.Dispose()

        If _Seleccionado Then

            Dim Fm_ As New Frm_Mt_InvParc_SelecionFechas(_RowBodega)
            Fm_.ShowInTaskbar = False
            Fm_.ShowDialog(Me)
            Fm_.Dispose()

        End If

    End Sub

    Private Sub BtnCalculadoraPeso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCalculadoraPeso.Click
        'Dim Fm As New Frm_Inv_CalcPeso
        'Fm.MinimizeBox = False
        'Fm.MaximizeBox = False
        'Fm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        'Fm.Show()
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Frm_Menu.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub
End Class
