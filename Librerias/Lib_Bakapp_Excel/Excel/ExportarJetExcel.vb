Imports System.Windows.Forms
Imports DevComponents.DotNetBar
Imports Funciones_BakApp

Public Module ExportarJetExcel

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub ExportarTabla_JetExcel(ByVal _Consulta_sql As String, _
                                      ByVal _Formulario As Form, _
                                      Optional ByVal _Nombre_Archivo As String = "Datos")

        Consulta_sql = _Consulta_sql

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If _Tbl.Rows.Count > 0 Then
            Dim Fm As New Frm_Exportar_Excel(_Tbl) 'Frm_ExportarJetExcel
            Fm.Pro_Nombre_Archivo = _Nombre_Archivo
            Fm.ShowDialog(_Formulario)
            Fm.Dispose()
        Else
            MessageBoxEx.Show(_Formulario, "No existen datos que mostrar", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Public Sub ExportarTabla_JetExcel_Tabla(ByVal _Tabla As Object, _
                                            ByVal _Formulario As Form, _
                                            Optional ByVal _Nombre_Archivo As String = "Datos")

        If (_Tabla Is Nothing) Or Not CBool(_Tabla.ROWS.COUNT) Then
            MessageBoxEx.Show(_Formulario, _
                              "No existen datos que mostrar", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            Dim Fm As New Frm_Exportar_Excel(_Tabla) 'Frm_ExportarJetExcel
            Fm.Pro_Nombre_Archivo = _Nombre_Archivo
            Fm.ShowDialog(_Formulario)
            Fm.Dispose()
        End If

    End Sub

    Public Sub ExportarTabla_JetExcel_Old(ByVal SQl As String, _
                                          ByVal Formulario As Form, _
                                          Optional ByVal Nombre_Archivo As String = "Datos")

        Dim Fm_xls As New Frm_ExportarJetExcel
        Fm_xls.TablaExcel = _Sql.Fx_Get_Tablas(SQl)
        Fm_xls.TxtNombreArchivo.Text = Nombre_Archivo

        If Fm_xls.TablaExcel.Rows.Count > 0 Then
            Fm_xls.ShowDialog(Formulario)
        Else
            MessageBoxEx.Show(Formulario, "No existen datos que mostrar", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Public Sub ExportarTabla_JetExcel_Tabla_Old(ByVal Tabla As Object, _
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

    Public Sub Fx_ExportarTabla_JetExcel_Tabla_Grabar_En_Directorio_Tmp(ByVal _Tabla As Object, _
                                                                        ByVal _Nombre_Archivo As String, _
                                                                        ByRef _Ruta_Archivo As String)

        Dim Fm As New Frm_Exportar_Excel(_Tabla) 'Frm_ExportarJetExcel
        Fm.Pro_Nombre_Archivo = _Nombre_Archivo
        _Ruta_Archivo = Fm.Fx_Exportar_ExcelJet(_Nombre_Archivo, "", Frm_Exportar_Excel.Enum_Extencion.xlsx)
        Fm.Dispose()

    End Sub

    'Public Sub Expor_JetExcel(ByVal SQl As String, _
    '                          ByVal FmPrincipal As DevComponents.DotNetBar.Metro.MetroAppForm)

    'Dim Frm_ExportarJetExcel As New Frm_ExportarJetExcel
    'Dim TablaExcel = get_Tablas(Sql, cn1)

    'If TablaExcel.Rows.Count > 0 Then

    'MessageBoxEx.Show("Se encontrarón " & TablaExcel.Rows.Count & " registros en la base de datos", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)

    'Dim NewPanel As CtrExportar_Excel = Nothing
    'NewPanel = New CtrExportar_Excel()
    'NewPanel.FmPrincipal = FmPrincipal
    'NewPanel.TablaExcel = TablaExcel
    'FmPrincipal.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    'Else
    'MessageBoxEx.Show("No existen datos que mostrar", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    'End If

    'End Sub

End Module
