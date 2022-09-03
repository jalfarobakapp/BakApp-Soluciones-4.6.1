Imports System.Windows.Forms

Public Module ExportarJetExcel


    Public Sub ExportarTabla_JetExcel(ByVal SQl As String, _
                               ByVal Formulario As Form)

        Dim Frm_ExportarJetExcel As New Frm_ExportarJetExcel
        Frm_ExportarJetExcel.TablaExcel = get_Tablas(SQl, cn1)

        If Frm_ExportarJetExcel.TablaExcel.Rows.Count > 0 Then
            Frm_ExportarJetExcel.ShowDialog(Formulario)
        Else
            MsgBox("No existena datos que mostrar", MsgBoxStyle.Exclamation, "Exportar a Ecxel")
        End If

    End Sub



    


End Module
