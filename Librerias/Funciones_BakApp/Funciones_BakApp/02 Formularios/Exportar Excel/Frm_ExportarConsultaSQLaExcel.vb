Imports System.Windows.Forms
Public Class Frm_ExportarConsultaSQLaExcel

    Public FmPrincipal As Form

    Private Sub BtnEjecutarConsultaSQL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEjecutarConsultaSQL.Click


        Consulta_sql = TxtQuerySQL.Text

        Try

            ExportarTabla_JetExcel(Consulta_sql, Me)

        Catch ex As Exception
            MsgBox("Error en la Consulta", MsgBoxStyle.Critical, "Consulta SQL")
            TxtQuerySQL.SelectAll()
            TxtQuerySQL.Focus()
        End Try


    End Sub

    Private Sub Frm_ExportarConsultaSQLaExcel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtQuerySQL.Focus()
    End Sub
End Class