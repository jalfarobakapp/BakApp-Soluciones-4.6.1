Public Class Frm_Form_Esperar

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        System.Windows.Forms.Application.DoEvents()
    End Sub
End Class