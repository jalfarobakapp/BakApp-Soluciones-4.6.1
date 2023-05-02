
Public Class Cl_Enviar_Doc_SinRecepcion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

#Region "PROPIEDADES"

    Public Property Id_Correo As Integer
    Public Property Para As String
    Public Property Chk_EnvDocSinRecep_EjecLunes As Boolean
    Public Property Chk_EnvDocSinRecep_EjecMartes As Boolean
    Public Property Chk_EnvDocSinRecep_EjecMiercoles As Boolean
    Public Property Chk_EnvDocSinRecep_EjecJueves As Boolean
    Public Property Chk_EnvDocSinRecep_EjecViernes As Boolean
    Public Property Chk_EnvDocSinRecep_EjecSabado As Boolean
    Public Property Chk_EnvDocSinRecep_EjecDomingo As Boolean

    Public Property Chk_EnvDocSinRecep As Boolean
    Public Property Dtp_EnvDocSinRecep_Hora_Ejecucion As DateTime

    Public Property OCC As Boolean
    Public Property OCI As Boolean
    Public Property COV As Boolean
    Public Property NVV As Boolean
    Public Property NVI As Boolean
    Public Property GTI As Boolean
    Public Property GDI As Boolean

    Public Property DiasOCC As Integer
    Public Property DiasOCI As Integer
    Public Property DiasCOV As Integer
    Public Property DiasNVV As Integer
    Public Property DiasNVI As Integer
    Public Property DiasGTI As Integer
    Public Property DiasGDI As Integer

    Public Property Crear_Html As Crear_Html

#End Region

    Public Sub New()

    End Sub

    Sub Sb_Procesar_Informe(_FechaActual As DateTime)

        Dim _TblDetalle As DataTable = Fx_Tbl_Informe(_FechaActual)
        Crear_Html = New Crear_Html

        If IsNothing(_TblDetalle) Then
            Crear_Html.EsCorrecto = False
            Crear_Html.RutaArchivo = String.Empty
            Crear_Html.Cuerpo_Html = String.Empty
            Return
        End If

        Crear_Html = Fx_CrearInformeHtmlDocumentosPendientes(_TblDetalle)

        'Crear_Html = _Crear_Html

    End Sub

    Function Fx_Tbl_Informe(_FechaActual As DateTime) As DataTable

        Dim _Tbl As DataTable
        Dim _Documentos As String

        _Documentos += Fx_Genara_FiltroDoc(_FechaActual, "OCC")
        _Documentos += Fx_Genara_FiltroDoc(_FechaActual, "OCI")
        _Documentos += Fx_Genara_FiltroDoc(_FechaActual, "COV")
        _Documentos += Fx_Genara_FiltroDoc(_FechaActual, "NVV")
        _Documentos += Fx_Genara_FiltroDoc(_FechaActual, "NVI")
        _Documentos += Fx_Genara_FiltroDoc(_FechaActual, "GTI")
        _Documentos += Fx_Genara_FiltroDoc(_FechaActual, "GDI")

        If String.IsNullOrEmpty(_Documentos) Then
            Return Nothing
        End If

        Consulta_Sql = "Select Edo.FEEMDO,Edo.SUDO,Edo.KOFUDO,Edo.BODESTI,Ddo.*,Tdo.NOTIDO,Isnull(Obs.OBDO,'') As OBDO,TABFU.NOKOFU  
Into #INFDet
From MAEDDO AS Ddo WITH ( NOLOCK )  
Inner Join MAEEDO AS Edo ON Edo.IDMAEEDO=Ddo.IDMAEEDO  
Left Join TABFU ON Edo.KOFUDO=TABFU.KOFU  
Left Join MAEEDOOB Obs On Edo.IDMAEEDO = Obs.IDMAEEDO
Left Join TABTIDO Tdo On Edo.TIDO = Tdo.TIDO
Where 
Edo.EMPRESA='" & ModEmpresa & "'  And 
(1<0 " & _Documentos & ") And
Ddo.LILG IN ('SI','CR') And Ddo.CAPRCO1 > Ddo.CAPREX1 + Ddo.CAPRAD1  
Order By Edo.IDMAEEDO 

Select Distinct TIDO,NUDO,FEEMDO,SUDO,BOSULIDO,BODESTI,DATEDIFF(DAY,FEEMDO,GETDATE()) As DiasDif,Case When OBDO = '' Then 'Sin Observaciones' Else OBDO End As OBDO,
(Select Count(*) From #INFDet Ps1 Where Ps1.IDMAEEDO = Ps2.IDMAEEDO And Ps1.BOSULIDO = Ps2.BOSULIDO) As Productos From #INFDet Ps2
Select * From #INFDet

Drop table #INFDet"

        _Tbl = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Return _Tbl

    End Function

    Function Fx_Genara_FiltroDoc(_FechaActual As DateTime, _Tido As String) As String

        Dim _Dias As Integer

        Select Case _Tido
            Case "OCC"
                If Not OCC Then Return ""
                _Dias = DiasOCC
            Case "OCI"
                If Not OCI Then Return ""
                _Dias = DiasOCI
            Case "COV"
                If Not COV Then Return ""
                _Dias = DiasCOV
            Case "NVV"
                If Not NVV Then Return ""
                _Dias = DiasNVV
            Case "NVI"
                If Not NVI Then Return ""
                _Dias = DiasNVI
            Case "GTI"
                If Not GTI Then Return ""
                _Dias = DiasGTI
            Case "GDI"
                If Not GDI Then Return ""
                _Dias = DiasGDI
        End Select

        _Dias = _Dias * -1

        Dim _FechaDif As DateTime

        _FechaDif = DateAdd(DateInterval.Day, _Dias, _FechaActual)
        Return "Or Edo.TIDO IN ('" & _Tido & "') And Edo.FEEMDO <= '" & Format(_FechaDif, "yyyyMMdd") & "'" & vbCrLf

    End Function

    Function Fx_CrearInformeHtmlDocumentosPendientes(_TblDetalle As DataTable) As Crear_Html

        Dim _NewHtml As New Crear_Html

        _NewHtml.EsCorrecto = False
        _NewHtml.RutaArchivo = String.Empty
        _NewHtml.Cuerpo_Html = String.Empty

        Try

            Dim _Ruta_Archivo As String = AppPath() & "\Data\" & RutEmpresa & "\Tmp"

            Dim _Documento_Html As String = My.Resources.Recursos_Demonio.Crear_Html_Documentos_Pendientes
            Dim _Detalle_Doc As String
            Dim _Suma_saldo As Double

            Dim _Alter As Boolean

            For Each _Detalle As DataRow In _TblDetalle.Rows

                'TIDO,NUDO,FEEMDO,SUDO,BOSULIDO,BODESTI,DiasDif,OBDO

                Dim _Tido As String = UCase(_Detalle.Item("TIDO"))
                Dim _Notido As String = UCase(_Detalle.Item("TIDO"))
                Dim _Nudo As String = _Detalle.Item("NUDO")
                Dim _Feemdo As String = FormatDateTime(_Detalle.Item("FEEMDO"), DateFormat.ShortDate)
                Dim _DiasDif As Integer = _Detalle.Item("DiasDif")

                Dim _Sudo As String = _Detalle.Item("SUDO")
                Dim _Bosulido As String = _Detalle.Item("BOSULIDO")
                Dim _Bodesti As String = _Detalle.Item("BODESTI")
                Dim _Obdo As String = _Detalle.Item("OBDO")

                Dim _BColor As String

                If _Alter Then
                    _BColor = " bgcolor=" & Chr(34) & "DCDCDC" & Chr(34) : _Alter = False
                Else
                    _BColor = " bgcolor=" & Chr(34) & "FFFFFF" & Chr(34) : _Alter = True
                End If

                _Detalle_Doc +=
                    "<tr" & _BColor & ">" & vbCrLf &
                    "<td align=left class=" & Chr(34) & "style20" & Chr(34) &
                    " align=" & Chr(34) & "center" & Chr(34) & ">" & _Tido & "</td>" & vbCrLf &
                    "<td align=left class=" & Chr(34) & "style17" & Chr(34) & ">" & _Nudo & "</td>" & vbCrLf &
                    "<td align=left class=" & Chr(34) & "style18" & Chr(34) & ">" & _Feemdo & "</td>" & vbCrLf &
                    "<td align=right class=" & Chr(34) & "style19" & Chr(34) & ">" & FormatNumber(_DiasDif, 0) & "</td>" & vbCrLf &
                    "<td align=left class=" & Chr(34) & "style19" & Chr(34) & ">" & _Sudo & "</td>" & vbCrLf &
                    "<td align=left class=" & Chr(34) & "style14" & Chr(34) & ">" & _Bosulido & "</td>" & vbCrLf &
                    "<td align=left class=" & Chr(34) & "style14" & Chr(34) & ">" & _Bodesti & "</td>" & vbCrLf &
                    "<td align=left class=" & Chr(34) & "style23" & Chr(34) & ">" & _Obdo & "</td>" &
                    "</tr>" & vbCrLf

            Next

            Dim _Total_Deuda As String = FormatCurrency(_Suma_saldo, 0)

            _Documento_Html = Replace(_Documento_Html, "#Detalle#", _Detalle_Doc)
            _Documento_Html = Replace(_Documento_Html, "#Total_deuda#", _Total_Deuda)

            _Documento_Html = Replace(_Documento_Html, "á", "&aacute;")
            _Documento_Html = Replace(_Documento_Html, "é", "&eacute;")
            _Documento_Html = Replace(_Documento_Html, "í", "&iacute;")
            _Documento_Html = Replace(_Documento_Html, "ó", "&oacute;")
            _Documento_Html = Replace(_Documento_Html, "ú", "&uacute;")
            _Documento_Html = Replace(_Documento_Html, "ñ", "&ntilde;")
            _Documento_Html = Replace(_Documento_Html, "Ñ", "&Ntilde;")

            ' Acento en Html
            'a = &aacute;
            'é = &eacute;
            'í = &iacute;
            'ó = &oacute;
            'ú = &uacute;
            'ñ = &ntilde;
            'Ñ = &Ntilde;

            CrearArchivoTxt(_Ruta_Archivo & "\", "DocPdtes.Html", _Documento_Html, False)

            _Ruta_Archivo = _Ruta_Archivo & "\DocPdtes.Html"

            _NewHtml.EsCorrecto = True
            _NewHtml.RutaArchivo = _Ruta_Archivo
            _NewHtml.Cuerpo_Html = _Documento_Html
            _NewHtml.Errores = String.Empty

        Catch ex As Exception
            _NewHtml.Errores = ex.Message
        End Try

        Return _NewHtml

    End Function

    Function Fx_EnviarNotificacionCorreoAlDiablito(_Para As String,
                                               _Cc As String,
                                               _Id_Correo As Integer,
                                               _Ruta_Archivo As String) As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_sql As String
        Dim _Error = String.Empty

        Try

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Correos Corr Where Id = " & _Id_Correo
            Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row_Correo) Then
                Throw New System.Exception("No existe configuración para el envio de correos")
            End If

            Dim _Nombre_Correo As String = _Row_Correo.Item("Nombre_Correo")
            Dim _Asunto As String = _Row_Correo.Item("Asunto")
            Dim _Mensaje As String = _Row_Correo.Item("CuerpoMensaje")

            If String.IsNullOrEmpty(_Asunto) Then
                _Asunto = "Correo de notificación de pedido " & RazonEmpresa
            End If

            _Mensaje = Replace(_Mensaje, "&lt;", "<")
            _Mensaje = Replace(_Mensaje, "&gt;", ">")
            _Mensaje = Replace(_Mensaje, "&quot;", """")
            _Mensaje = Replace(_Mensaje, "'", "''")

            Dim _Adjunto As String = _Ruta_Archivo '& "\Informe_cobranza.Html"
            Dim _Cuerpo_Html = LeeArchivo(_Adjunto)

            _Cuerpo_Html = _Cuerpo_Html.Replace("'", "''")

            _Mensaje = Replace(_Mensaje, "<HTML_DOCPENDIENTES>", _Cuerpo_Html)

            If Not String.IsNullOrEmpty(_Nombre_Correo) Then

                Dim _Fecha = "Getdate()"
                Dim _Adjuntar_Documento As Boolean = False
                Dim _NombreEquipo As String = String.Empty

                _Para = _Para.Trim

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo (NombreEquipo,Id_Correo,Nombre_Correo,CodFuncionario,Asunto," &
                               "Para,Cc,Idmaeedo,Tido,Nudo,NombreFormato,Enviar,Mensaje,Fecha,Adjuntar_Documento,Doc_Adjuntos,Id_Acp)" &
                               vbCrLf &
                               "Values ('" & _NombreEquipo & "'," & _Id_Correo & ",'" & _Nombre_Correo & "','','" & _Asunto & "','" & _Para & "','" & _Cc &
                               "',0,'','','',1,'" & _Mensaje & "'," & _Fecha & "," & Convert.ToInt32(_Adjuntar_Documento) & ",'',0)"

                _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

                _Error = _Sql.Pro_Error

                If Not String.IsNullOrEmpty(_Error) Then
                    Throw New System.Exception(_Error)
                End If

            End If

        Catch ex As Exception
            _Error = ex.Message
        End Try

        Return _Error

    End Function


End Class


Public Class Crear_Html

    Public Property EsCorrecto As Boolean
    Public Property RutaArchivo As String
    Public Property Cuerpo_Html As String
    Public Property Errores As String


End Class
