Imports DevComponents

Public Class Ctr_Sql2Excel

    Public FmPrincipal As DevComponents.DotNetBar.Metro.MetroAppForm

    Private Sub BtnSQL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSQL.Click

        Try
            Expor_JetExcel(TxtQuerySQL.Text, FmPrincipal)
        Catch ex As Exception
            MsgBox("Error en la Consulta", MsgBoxStyle.Critical, "Consulta SQL")
            TxtQuerySQL.SelectAll()
            TxtQuerySQL.Focus()
        End Try

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        FmPrincipal.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Ctr_Sql2Excel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TxtQuerySQL.Focus()
    End Sub
End Class
