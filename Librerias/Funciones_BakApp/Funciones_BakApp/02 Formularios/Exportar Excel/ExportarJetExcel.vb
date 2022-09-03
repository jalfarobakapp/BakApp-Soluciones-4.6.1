Imports System.Windows.Forms
Imports DevComponents.DotNetBar

Public Module ExportarJetExcel


    Public Sub ExportarTabla_JetExcel(ByVal SQl As String, _
                               ByVal Formulario As Form, _
                               Optional ByVal Nombre_Archivo As String = "Datos")

        Dim Fm_xls As New Frm_ExportarJetExcel
        Fm_xls.TablaExcel = get_Tablas(SQl, cn1)
        Fm_xls.TxtNombreArchivo.Text = Nombre_Archivo

        If Fm_xls.TablaExcel.Rows.Count > 0 Then
            Fm_xls.ShowDialog(Formulario)
        Else
            MessageBoxEx.Show(Formulario, "No existen datos que mostrar", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub


    Public Sub ExportarTabla_JetExcel_Tabla(ByVal Tabla As Object, _
                                            ByVal Formulario As Form, _
                                            Optional ByVal Nombre_Archivo As String = "Datos")

        Dim Fm_xls As New Frm_ExportarJetExcel
        Fm_xls.TxtNombreArchivo.Text = Nombre_Archivo
        Fm_xls.TablaExcel = Tabla

        If (Tabla Is Nothing) Or Not CBool(Tabla.ROWS.COUNT) Then
            MessageBoxEx.Show(Formulario, _
                              "No existen datos que mostrar", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            Fm_xls.ShowDialog(Formulario)
        End If

    End Sub

    Public Sub Expor_JetExcel(ByVal SQl As String, _
                              ByVal FmPrincipal As DevComponents.DotNetBar.Metro.MetroAppForm)

        Dim Frm_ExportarJetExcel As New Frm_ExportarJetExcel
        Dim TablaExcel = get_Tablas(SQl, cn1)

        If TablaExcel.Rows.Count > 0 Then

            MessageBoxEx.Show("Se encontrarón " & TablaExcel.Rows.Count & " registros en la base de datos", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim NewPanel As CtrExportar_Excel = Nothing
            NewPanel = New CtrExportar_Excel()
            NewPanel.FmPrincipal = FmPrincipal
            NewPanel.TablaExcel = TablaExcel
            FmPrincipal.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
        Else
            MessageBoxEx.Show("No existen datos que mostrar", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    


End Module
