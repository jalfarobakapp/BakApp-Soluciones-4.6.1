'Imports Lib_Bakapp_VarClassFunc
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar



Public Class Cambiar_Codigos_Mnu

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

    Private Sub Btn_Cambio_Masivo_Click(sender As Object, e As EventArgs) Handles Btn_Cambio_Masivo.Click

        If Not Fx_Tiene_Permiso(_Fm_Menu_Padre, "Prod042") Then
            Return
        End If

        Dim Fm As New Frm_Cambio_Codigos
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Cambio_UnoxUno_Click(sender As Object, e As EventArgs) Handles Btn_Cambio_UnoxUno.Click

        If Not Fx_Tiene_Permiso(_Fm_Menu_Padre, "Prod003") Then
            Return
        End If

        Dim Fm As New Frm_Cambio_Codigos_UnoxUno
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

End Class
