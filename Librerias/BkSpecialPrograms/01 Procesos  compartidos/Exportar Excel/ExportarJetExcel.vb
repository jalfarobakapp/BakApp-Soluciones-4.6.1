Imports DevComponents.DotNetBar
Imports NUnrar

Public Module ExportarJetExcel

    Dim Consulta_sql As String

    Public Sub ExportarTabla_JetExcel(_Consulta_sql As String,
                                      _Formulario As Form,
                                      Optional _Nombre_Archivo As String = "Datos")

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = _Consulta_sql

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If _Tbl.Rows.Count > 0 Then
            Dim Fm As New Frm_Exportar_Excel(_Tbl)
            Fm.ShowInTaskbar = False
            Fm.Pro_Nombre_Archivo = _Nombre_Archivo
            Fm.ShowDialog(_Formulario)
            Fm.Dispose()
        Else
            MessageBoxEx.Show(_Formulario, "No existen datos que mostrar", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Public Sub ExportarTabla_JetExcel_Tabla(_Tabla As Object,
                                            _Formulario As Form,
                                            Optional _Nombre_Archivo As String = "Datos",
                                            Optional _CodPermiso As String = "")

        If (_Tabla Is Nothing) OrElse Not CBool(_Tabla.ROWS.COUNT) Then
            MessageBoxEx.Show(_Formulario,
                              "No existen datos que mostrar", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            Dim Fm As New Frm_Exportar_Excel(_Tabla)
            Fm.CodPermiso = _CodPermiso
            Fm.Pro_Nombre_Archivo = _Nombre_Archivo
            Fm.ShowDialog(_Formulario)
            Fm.Dispose()
        End If

    End Sub

    Public Sub ExportarTabla_JetExcel_DataSet(_Ds As DataSet,
                                              _Formulario As Form,
                                              Optional _Nombre_Archivo As String = "Datos",
                                              Optional _CodPermiso As String = "")

        If (_Ds Is Nothing) OrElse Not CBool(_Ds.Tables.Count) Then
            MessageBoxEx.Show(_Formulario,
                              "No existen datos que mostrar", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            Dim Fm As New Frm_Exportar_Excel(Nothing)
            Fm.Ds_Excel = _Ds
            Fm.CodPermiso = _CodPermiso
            Fm.Pro_Nombre_Archivo = _Nombre_Archivo
            Fm.ShowDialog(_Formulario)
            Fm.Dispose()
        End If

    End Sub

    Public Sub ExportarTabla_JetExcel_Old(SQl As String,
                                          Formulario As Form,
                                          Optional Nombre_Archivo As String = "Datos")

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim Fm_xls As New Frm_ExportarJetExcel
        Fm_xls.Pro_TablaExcel = _Sql.Fx_Get_DataTable(SQl)
        Fm_xls.TxtNombreArchivo.Text = Nombre_Archivo

        If Fm_xls.Pro_TablaExcel.Rows.Count > 0 Then
            Fm_xls.ShowDialog(Formulario)
        Else
            MessageBoxEx.Show(Formulario, "No existen datos que mostrar", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Public Sub ExportarTabla_JetExcel_Tabla_Old(Tabla As Object,
                                                Formulario As Form,
                                                Optional Nombre_Archivo As String = "Datos")

        Dim Fm_xls As New Frm_ExportarJetExcel
        Fm_xls.TxtNombreArchivo.Text = Nombre_Archivo
        Fm_xls.Pro_TablaExcel = Tabla

        If (Tabla Is Nothing) Or Not CBool(Tabla.ROWS.COUNT) Then
            MessageBoxEx.Show(Formulario,
                              "No existen datos que mostrar", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            Fm_xls.ShowDialog(Formulario)
        End If

    End Sub

    Public Sub Fx_ExportarTabla_JetExcel_Tabla_Grabar_En_Directorio_Tmp(_Tabla As Object,
                                                                        _Nombre_Archivo As String,
                                                                        ByRef _Ruta_Archivo As String)

        Dim _Mensaje As LsValiciones.Mensajes '= Fx_Exportar_ExcelJet(Txt_Nombre_Archivo.Text, _Directorio_Destino, _Extension)

        'MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, Windows.Forms.MessageBoxButtons.OK, _Mensaje.Icono)

        'If _Mensaje.EsCorrecto Then
        '_Archivo = _Mensaje.Tag
        'End If

        Dim Fm As New Frm_Exportar_Excel(_Tabla)
        Fm.Pro_Nombre_Archivo = _Nombre_Archivo
        '_Ruta_Archivo = Fm.Fx_Exportar_ExcelJet(_Nombre_Archivo, "", Frm_Exportar_Excel.Enum_Extension.xlsx)
        _Mensaje = Fm.Fx_Exportar_ExcelJet(_Nombre_Archivo, "", Frm_Exportar_Excel.Enum_Extension.xlsx)
        Fm.Dispose()

        _Ruta_Archivo = _Mensaje.Tag

    End Sub

End Module
