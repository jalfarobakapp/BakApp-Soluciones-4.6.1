Public Class Frm_01_AutoconsultaSaldo

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Frm_02_AutoconsultaSaldo As New Frm_02_AutoconsultaSaldo
        Frm_02_AutoconsultaSaldo.ShowDialog(Me)
    End Sub
End Class