Imports BakApp_DTEMonitor.Eventos_Dte

Public Class Frm_Pruebas_DTE

    Dim _RutEmisor As String
    Dim _RutEnvia As String
    Dim _RutReceptor As String
    Dim _FchResol As String
    Dim _NroResol As String
    Dim _Cn As String

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Pruebas_DTE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Consulta_sql = "Select Id,Empresa,Campo,Valor,FechaMod,TipoCampo,TipoConfiguracion" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_DTE_Configuracion" & vbCrLf &
                       "Where Empresa = '" & ModEmpresa & "' And TipoConfiguracion = 'ConfEmpresa'"
        Dim _Tbl_ConfEmpresa As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If Not CBool(_Tbl_ConfEmpresa.Rows.Count) Then
            Throw New System.Exception("Faltan los datos de configuración DTE para la empresa")
        End If

        For Each _Fila As DataRow In _Tbl_ConfEmpresa.Rows

            Dim _Campo As String = _Fila.Item("Campo").ToString.Trim

            If _Campo = "RutEmisor" Then _RutEmisor = _Fila.Item("Valor")
            If _Campo = "RutEnvia" Then _RutEnvia = _Fila.Item("Valor")
            If _Campo = "RutReceptor" Then _RutReceptor = _Fila.Item("Valor")
            If _Campo = "FchResol" Then _FchResol = _Fila.Item("Valor")
            If _Campo = "NroResol" Then _NroResol = _Fila.Item("Valor")
            If _Campo = "Cn" Then _Cn = _Fila.Item("Valor")

        Next

    End Sub


    Sub Sb_Revisar_Acuse_Recibo_Al_SIIDTE_Bk(_FechaRevision As DateTime)

        'Dim _FechaHoy As String = Format(FechaDelServidor, "yyyyMMdd")
        'Dim _FechaPrimerDiaMes As String = Format(Primerdiadelmes(FechaDelServidor), "yyyyMMdd")
        'Dim _8Dias As DateTime = DateAdd(DateInterval.Day, -10, FechaDelServidor)
        'Dim _Fecha8Dias As String = Format(_8Dias, "yyyyMMdd")

        Dim _FechaEnvSII As String = Format(_FechaRevision, "yyyyMMdd")

        'Consulta_sql = "Select Top 100 DteDoc.Id_Dte,DteTk.Id As Id_Trackid,DteDoc.Idmaeedo,Tido,Nudo," &
        '               "DteTk.Trackid,FechaSolicitud,DteDoc.AmbienteCertificacion,DteDoc.Procesar,DteDoc.Procesado,DteTk.Estado,DteTk.Glosa" & vbCrLf &
        '               "From " & _Global_BaseBk & "Zw_DTE_Documentos DteDoc" & vbCrLf &
        '               "Inner Join " & _Global_BaseBk & "Zw_DTE_Trackid DteTk On DteDoc.Id_Dte = DteTk.Id_Dte" & vbCrLf &
        '               "Where DteDoc.Procesado = 1 And DteDoc.AmbienteCertificacion = 0 And Tido In ('FCV','NCV') And (DteTk.Aceptado = 1 or DteTk.Reparo = 1)" & vbCrLf &
        '               "And DteTk.FechaEnvSII > '" & _Fecha8Dias & "' And DteTk.FechaEnvSII < '" & _FechaHoy & "'" & vbCrLf &
        '               "And DteTk.Id Not In (Select Id_Trackid From " & _Global_BaseBk & "Zw_DTE_ListaEventosDoc Where CodEvento In ('PAG','ACD','ERM'))" & vbCrLf &
        '               "Order By DteDoc.Id_Dte Desc"

        Consulta_sql = "Select DteDoc.Id_Dte,DteTk.Id As Id_Trackid,DteDoc.Idmaeedo,Tido,Nudo," &
                       "DteTk.Trackid,FechaSolicitud,DteDoc.AmbienteCertificacion,DteDoc.Procesar,DteDoc.Procesado,DteTk.Estado,DteTk.Glosa" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_DTE_Documentos DteDoc" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_DTE_Trackid DteTk On DteDoc.Id_Dte = DteTk.Id_Dte" & vbCrLf &
                       "Where DteDoc.Procesado = 1 And DteDoc.AmbienteCertificacion = 0 And Tido In ('FCV','NCV') And (DteTk.Aceptado = 1 or DteTk.Reparo = 1)" & vbCrLf &
                       "And Convert(varchar, DteTk.FechaEnvSII, 112) = '" & _FechaEnvSII & "'" & vbCrLf &
                       "And DteTk.Id Not In (Select Id_Trackid From " & _Global_BaseBk & "Zw_DTE_ListaEventosDoc Where CodEvento In ('PAG','ACD','ERM'))" & vbCrLf &
                       "Order By DteDoc.Id_Dte Desc"

        '
        'Consulta_sql = "Select DteDoc.Id_Dte,DteTk.Id As Id_Trackid,DteDoc.Idmaeedo,Tido,Nudo," &
        '               "DteTk.Trackid,FechaSolicitud,DteDoc.AmbienteCertificacion,DteDoc.Procesar,DteDoc.Procesado,DteTk.Estado,DteTk.Glosa" & vbCrLf &
        '               "From " & _Global_BaseBk & "Zw_DTE_Documentos DteDoc" & vbCrLf &
        '               "Inner Join " & _Global_BaseBk & "Zw_DTE_Trackid DteTk On DteDoc.Id_Dte = DteTk.Id_Dte" & vbCrLf &
        '               "Where DteDoc.Id_Dte In (85715,85716,88035)"

        Dim _Tbl_DTE_Documentos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If Not CBool(_Tbl_DTE_Documentos.Rows.Count) Then
            Return
        End If

        Barra_Progreso.Maximum = _Tbl_DTE_Documentos.Rows.Count
        Barra_Progreso.Value = 0

        Lbl_Estado.Text = "Revisando documentos del " & _FechaRevision.ToShortDateString

        If CBool(_Tbl_DTE_Documentos.Rows.Count) Then

            'Sb_AddToLog("Revición DTE en SII", "Revisando historial de documentos en el SII", Txt_Log)

            For Each _Fila As DataRow In _Tbl_DTE_Documentos.Rows

                Dim _Idmaeedo = _Fila.Item("Idmaeedo")
                Dim _Id_Dte = _Fila.Item("Id_Dte")
                Dim _Id_Trackid = _Fila.Item("Id_Trackid")
                Dim _Tido = _Fila.Item("Tido")
                Dim _Nudo = _Fila.Item("Nudo")

                Dim _TipoDte As String = Fx_Tipo_DTE_VS_TIDO(_Tido)
                Dim _FolioDte As String = CInt(_Nudo)

                Dim _Cl_AcuseReciboFactura As New Cl_AcuseReciboFactura

                Dim _Historial As New Eventos_Dte.Ls_HistorialDocumentoDte

                _Historial = _Cl_AcuseReciboFactura.Fx_RevisarHistorialDocumento(_Cn, _RutEmisor, _TipoDte, _FolioDte, 1)

                Barra_Progreso.TextVisible = True
                Barra_Progreso.Value += 1
                Barra_Progreso.Text = FormatNumber(Barra_Progreso.Value, 0) & " de " & FormatNumber(_Tbl_DTE_Documentos.Rows.Count, 0)
                System.Windows.Forms.Application.DoEvents()

                Lbl_Estado.Text = "Revisando documentos del " & _FechaRevision.ToShortDateString & ". (" & Barra_Progreso.Text & ")"

                Sb_AddToLog("Revición DTE en SII", "Revisando " & _Tido & "-" & _Nudo, Txt_Log)

                If _Historial.EsCorrecto Then

                    For Each _Hst As HistorialDocumentoDte In _Historial.Historial

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_DTE_ListaEventosDoc " &
                                       "(Id_Dte,Id_Trackid,Idmaeedo,Tido,Nudo,CodEvento,DescEvento,RutResponsable,DvResponsable,FechaEvento) Values " & vbCrLf &
                                       "(" & _Id_Dte & "," & _Id_Trackid & "," & _Idmaeedo & ",'" & _Tido & "','" & _Nudo & "'" &
                                       ",'" & _Hst.CodEvento & "'" &
                                       ",'" & _Hst.DescEvento & "'" &
                                       ",'" & _Hst.RutResponsable & "'" &
                                       ",'" & _Hst.DvResponsable & "'" &
                                       ",'" & Format(_Hst.FechaEvento, "yyyyMMdd HH:MM") & "')"
                        _Sql.Ej_consulta_IDU(Consulta_sql, False)

                        If _Hst.CodEvento = "RCD" Then

                            _Historial.Mensaje = _Hst.DescEvento

                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set " &
                                           "TieneReclamo = 1" &
                                           ",FechaReclamo = '" & Format(_Hst.FechaEvento, "yyyyMMdd HH:MM") & "'" &
                                           ",MensajeRegEventosDoc = '" & _Hst.DescEvento & "'" & vbCrLf &
                                           "Where Id = " & _Id_Trackid
                            _Sql.Ej_consulta_IDU(Consulta_sql, False)

                        End If

                        Sb_AddToLog("Revición DTE en SII", "CodEvento: " & _Hst.CodEvento & " - " & _Hst.DescEvento, Txt_Log)

                    Next

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set MensajeRegEventosDoc = '" & _Historial.Mensaje & "' Where Id = " & _Id_Trackid
                    _Sql.Ej_consulta_IDU(Consulta_sql, False)

                    'Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_DTE_Trackid Where Id_Dte = " & _Id_Dte & "Order By Id Desc"
                    'Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

                    'If Not IsNothing(_Row) Then
                    '    Dim _Trackid As String = _Row.Item("Trackid")
                    '    Sb_AddToLog("Enviar SII", _Tido & "-" & _Nudo & ", Enviado Trackid: " & _Trackid, Txt_Log)
                    'Else
                    '    Dim _Error = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Documentos", "Respuesta", "Id_Dte = " & _Id_Dte)
                    '    Sb_AddToLog("Enviar SII", _Tido & "-" & _Nudo & ", Error: " & _Error, Txt_Log)
                    'End If

                Else

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set MensajeRegEventosDoc = '" & _Historial.Mensaje & "' Where Id = " & _Id_Trackid
                    _Sql.Ej_consulta_IDU(Consulta_sql, False)

                    'Sb_AddToLog("Enviar SII", _Enviar_DTE.mensaje, Txt_Log)

                End If

                Sb_AddToLog("Revición DTE en SII", "MensajeRegEventosDoc " & _Historial.Mensaje, Txt_Log)
                Sb_AddToLog("Revición DTE en SII", "..........", Txt_Log)

            Next

            'Sb_AddToLog("Enviar SII", "Fin proceso", Txt_Log)

        End If

    End Sub

    Private Sub Btn_RevisarHistorialDTE_Click(sender As Object, e As EventArgs) Handles Btn_RevisarHistorialDTE.Click

        Dim _FechaHoy As String = Format(FechaDelServidor, "yyyyMMdd")
        Dim _FechaPrimerDiaMes As String = Format(Primerdiadelmes(FechaDelServidor), "yyyyMMdd")
        Dim _8Dias As DateTime = DateAdd(DateInterval.Day, -10, FechaDelServidor)
        Dim _Fecha8Dias As String = Format(_8Dias, "yyyyMMdd")

        For i = 1 To 10

            Sb_Revisar_Acuse_Recibo_Al_SIIDTE_Bk(_8Dias)

            _8Dias = DateAdd(DateInterval.Day, 1, _8Dias)

        Next

        Me.Close()

    End Sub

End Class
