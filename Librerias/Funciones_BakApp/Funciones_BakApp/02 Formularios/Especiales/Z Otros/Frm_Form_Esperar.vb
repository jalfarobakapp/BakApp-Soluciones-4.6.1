Public Class Frm_Form_Esperar

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        System.Windows.Forms.Application.DoEvents()
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Dise�ador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicializaci�n despu�s de la llamada a InitializeComponent().
        Timer1.Enabled = True

    End Sub
End Class