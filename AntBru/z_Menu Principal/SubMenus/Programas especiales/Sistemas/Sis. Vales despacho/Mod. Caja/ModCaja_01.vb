'Imports Lib_Bakapp_VarClassFunc
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class ModCaja_01

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Public Sub New(ByVal Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

   
    Private Sub BtnMarcar_Documentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMarcar_Documentos.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Vale0004") Then
            Dim Fm As New Frm_Vales_Caja_01_MarcarDoc()
            Fm.ShowDialog(Me)
        End If
    End Sub
End Class
