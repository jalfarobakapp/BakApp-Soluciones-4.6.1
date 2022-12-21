Imports System.IO
Imports System.Reflection.Assembly
Imports System.Security.Cryptography.X509Certificates
Imports System.Xml
Imports System.Xml.XPath

Module EnviaDTESIIBk

    Dim _Sql As Class_SQL
    Dim Consulta_sql As String

    Dim _Global_BaseBk As String
    Dim _Empresa As String
    Dim _RutEmpresaActiva As String
    Dim _AmbienteCertificacion As Boolean
    Dim _Id_Dte As Integer
    Dim _Trackid As String

    Enum Enum_Acciones
        EnviarDTE
        ConsultarTrackID
    End Enum

    Dim _Accion As Enum_Acciones

    Sub Main()

        Dim Cadena_ConexionSQL_Server As String

        Cadena_ConexionSQL_Server = System.Configuration.ConfigurationSettings.AppSettings.Item("Cadenadeconexion")

        Dim _Version_BakApp = FileVersionInfo.GetVersionInfo(AppPath() & "\EnviaDTESIIBk.exe").FileVersion

        Console.WriteLine("EnviaDTESIIBk.exe Versión: " & _Version_BakApp)
        'Console.WriteLine(_xsd_path)

        If Environment.GetCommandLineArgs.Length > 1 Then

            'Cadena_ConexionSQL_Server = Environment.GetCommandLineArgs(1)
            'Cadena_ConexionSQL_Server = Replace(Cadena_ConexionSQL_Server, "@", " ")
            Try

                _Empresa = Environment.GetCommandLineArgs(1)
                _AmbienteCertificacion = Environment.GetCommandLineArgs(2)
                _Id_Dte = Environment.GetCommandLineArgs(3)
                _Trackid = Environment.GetCommandLineArgs(4)
                _Accion = Environment.GetCommandLineArgs(5)

                If _AmbienteCertificacion Then

                    Console.WriteLine("******************************")
                    Console.WriteLine("Cadena_ConexionSQL_Server : {0}", Cadena_ConexionSQL_Server)
                    Console.WriteLine("Empresa                   : {0}", _Empresa)
                    Console.WriteLine("AmbienteCertificacion     : {0}", _AmbienteCertificacion)
                    Console.WriteLine("Id_Dte                    : {0}", _Id_Dte)
                    Console.WriteLine("Trackid                   : {0}", _Trackid)
                    Console.WriteLine("Accion                    : {0}", _Accion.ToString)
                    Console.WriteLine("******************************")
                    Console.WriteLine(vbCrLf)

                End If

            Catch ex As Exception
                Console.WriteLine("Error!")
                Console.WriteLine(ex.Message)
                Console.ReadKey()
                Return
            End Try

        Else

            '_Empresa = "01"
            'Cadena_ConexionSQL_Server = "data source = SIERRALTA; initial catalog = SIERRALTA_PRB; user id = SIERRALTA_PRB; password = SIERRALTA_PRB"
            'Cadena_ConexionSQL_Server = "data source=186.67.37.218,1518;initial catalog=SIERRALTA_PRB;user id=SIERRALTA_PRB;password = SIERRALTA_PRB"
            '"data@source=186.67.37.218,1518;initial@catalog=SIERRALTA_PRB;user@id=SIERRALTA_PRB;password=SIERRALTA_PRB"


            _Empresa = "01"
            _AmbienteCertificacion = True
            _Id_Dte = 5801
            _Trackid = ""
            _Accion = Enum_Acciones.EnviarDTE

        End If


        _Sql = New Class_SQL(Cadena_ConexionSQL_Server)

        _Global_BaseBk = _Sql.Fx_Trae_Dato("TABCARAC", "NOKOCARAC", "KOTABLA = 'BAKAPP'")

        If String.IsNullOrEmpty(_Global_BaseBk) Then
            _Sql.Pro_Error = "No se encontro el nombre de la base de datos de Bakapp, TABCARAC-NOKOCARAC-KOTABLA = 'BAKAPP'"
        End If

        _Global_BaseBk = _Global_BaseBk & ".dbo."

        _Sql.Global_BaseBk = _Global_BaseBk

        If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
            Console.WriteLine("Error Sql : {0}", _Sql.Pro_Error)
            Console.ReadKey()
            Return
        End If

        If _Accion = Enum_Acciones.EnviarDTE Then
            Sb_EnviarDTE()
        End If

        If _Accion = Enum_Acciones.ConsultarTrackID Then
            Sb_Consultar_Trackid()
        End If

    End Sub

    Sub Sb_EnviarDTE()

        Dim _Respuesta As HEFESTO.DTE.AUTENTICACION.ENT.Respuesta

        _Respuesta = Fx_Enviar_DTE_Al_SII(_Id_Dte, _AmbienteCertificacion)

        Console.WriteLine("******************************")
        Console.WriteLine("Es correcto : {0}", _Respuesta.correcto)
        Console.WriteLine("Detalle     : {0}", _Respuesta.detalle)
        Console.WriteLine("Mensaje     : {0}", _Respuesta.mensaje)
        Console.WriteLine("Resultado   : {0}", _Respuesta.Resultado)
        Console.WriteLine("******************************")
        Console.WriteLine(vbCrLf)

        If Environment.GetCommandLineArgs.Length = 1 Then
            Console.ReadKey()
        End If

    End Sub

    Function Fx_Enviar_DTE_Al_SII(_Id_Dte As Integer, _AmbienteCertificacion As Boolean) As HEFESTO.DTE.AUTENTICACION.ENT.Respuesta

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DTE_Documentos Where Id_Dte = " & _Id_Dte
        Dim _Zw_DTE_Documentos As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Idmaeedo = _Zw_DTE_Documentos.Item("Idmaeedo")

        Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
        Dim _Maeedo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Tido As String = _Zw_DTE_Documentos.Item("Tido")
        Dim _Nudo As String = _Zw_DTE_Documentos.Item("Nudo")

        If IsNothing(_Maeedo) Then
            Consulta_sql = "Select * From MAEEDO Where TIDO = '" & _Tido & "' And NUDO = '" & _Nudo & "'"
            _Maeedo = _Sql.Fx_Get_DataRow(Consulta_sql)
        End If

        Dim MensajeError As String = "No pudimos encontrar la siguiente información:" & vbCrLf

        Dim _Respuesta As New HEFESTO.DTE.AUTENTICACION.ENT.Respuesta

        Try

            Dim _RutEmisor As String
            Dim _RutEnvia As String
            Dim _RutReceptor As String
            Dim _FchResol As String
            Dim _NroResol As String
            Dim _Cn As String

            Dim _ErrorEnvioDTE = False
            Dim _RespuestaError = String.Empty

            If IsNothing(_Maeedo) Then
                _ErrorEnvioDTE = True
                _RespuestaError = "No se encontro el documento " & _Tido & "-" & _Nudo
            Else
                If _Maeedo.Item("ESDO") = "N" Then
                    _ErrorEnvioDTE = True
                    _RespuestaError = "Documento NULO"
                End If
            End If

            If _ErrorEnvioDTE Then
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set " &
                               "Procesado = 1,Procesar = 0,ErrorEnvioDTE = 1,Respuesta = '" & _RespuestaError & "' Where Id_Dte = " & _Id_Dte
                _Sql.Ej_consulta_IDU(Consulta_sql)
                Throw New System.Exception(_RespuestaError)
            End If

            Consulta_sql = "Select Id,Empresa,Campo,Valor,FechaMod,TipoCampo,TipoConfiguracion" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_DTE_Configuracion" & vbCrLf &
                           "Where Empresa = '" & _Empresa & "' And TipoConfiguracion = 'ConfEmpresa'"
            Dim _Tbl_ConfEmpresa As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

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

            Dim _Archivo_Xml As String
            Dim _Dset_DTE As New DataSet

            Dim _Dir As String = AppPath() & "\Temp"
            _Archivo_Xml = _Zw_DTE_Documentos.Item("CaratulaXml") '_Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Documentos", "CaratulaXml", "Id_Dte = " & _Id_Dte)

            If String.IsNullOrEmpty(_Archivo_Xml) Then
                MensajeError += "No fue posible encontrar la Caratula desde la tabla " & _Global_BaseBk & "Zw_DTE_Documentos" & vbCrLf
                Throw New System.Exception(MensajeError)
            Else

                If Not Directory.Exists(_Dir) Then
                    System.IO.Directory.CreateDirectory(_Dir)
                End If

                Dim _Nombre_Archivo As String

                If String.IsNullOrEmpty(_Archivo_Xml) Then
                    MensajeError += "No fue posible encontrar el archivo de paso .xml" & vbCrLf
                    Throw New System.Exception(MensajeError)
                End If

                _Nombre_Archivo = _Tido & "-" & _Nudo
                _Dir = _Dir & "\" & _Nombre_Archivo

                Dim oSW As New System.IO.StreamWriter(_Dir)

                oSW.WriteLine(_Archivo_Xml)
                oSW.Close()

                Dim xmlDocumento As XmlDocument = New XmlDocument()
                xmlDocumento.PreserveWhitespace = True
                xmlDocumento.Load(_Dir)

                Dim _lRutEmisor As List(Of String) = New List(Of String)()
                Dim _XmlRutEmisor As XmlNodeList = xmlDocumento.GetElementsByTagName("RutEmisor", xmlDocumento.DocumentElement.NamespaceURI)
                Dim _XmlRutEmisorLibro As XmlNodeList = xmlDocumento.GetElementsByTagName("RutEmisorLibro", xmlDocumento.DocumentElement.NamespaceURI)

                If _XmlRutEmisor IsNot Nothing AndAlso _XmlRutEmisor.Count > 0 Then _lRutEmisor.Add(_XmlRutEmisor(0).InnerText)
                If _XmlRutEmisorLibro IsNot Nothing AndAlso _XmlRutEmisorLibro.Count > 0 Then _lRutEmisor.Add(_XmlRutEmisorLibro(0).InnerText)

                Dim _XmlRutEnvia As XmlNodeList = xmlDocumento.GetElementsByTagName("RutEnvia", xmlDocumento.DocumentElement.NamespaceURI)

                Dim _Error As Boolean

                If _lRutEmisor Is Nothing OrElse _lRutEmisor.Count = 0 Then
                    MensajeError += "- Rut de la empresa emisora del documento." & vbCrLf
                    _Error = True
                End If

                If _XmlRutEnvia Is Nothing OrElse _XmlRutEnvia.Count = 0 Then
                    MensajeError += "- Rut del certificado digital." & vbCrLf
                    _Error = True
                End If

                If _Error Then
                    Throw New System.Exception(MensajeError)
                End If

                Dim _cmpRutEmisor, _cmpRutEnvia As String

                If CBool(_lRutEmisor.Count) Then
                    _cmpRutEmisor = _lRutEmisor(0).ToString
                End If

                If CBool(_XmlRutEnvia.Count) Then
                    _cmpRutEnvia = _XmlRutEnvia(0).InnerText
                End If

                Dim _Ambiente As HEFESTO.DTE.AUTENTICACION.SIIAmbiente

                If _AmbienteCertificacion Then
                    _Ambiente = HEFESTO.DTE.AUTENTICACION.SIIAmbiente.Certificacion
                Else
                    _Ambiente = HEFESTO.DTE.AUTENTICACION.SIIAmbiente.Produccion
                End If

                _Respuesta = HEFESTO.DTE.AUTENTICACION.LOGIN.Conectar(_Cn, _Ambiente)

                If _Respuesta.correcto Then

                    Dim _paramToken As String = _Respuesta.Resultado
                    Dim _paramArchivo As String = _Dir
                    Dim _paramRutEmisorB As String = _cmpRutEmisor.Split("-"c)(0)
                    Dim _paramRutEmisorD As String = _cmpRutEmisor.Split("-"c)(1)
                    Dim _paramRutEnviaB As String = _cmpRutEnvia.Split("-"c)(0)
                    Dim _paramRutEnviaD As String = _cmpRutEnvia.Split("-"c)(1)

                    Dim _respuestaEnvio As HEFESTO.DTE.AUTENTICACION.ENT.Respuesta =
                                    HEFESTO.DTE.AUTENTICACION.ENVIO.EnviarArchivoSII(_paramArchivo,
                                                                                     _paramToken,
                                                                                     _paramRutEnviaB,
                                                                                     _paramRutEnviaD,
                                                                                     _paramRutEmisorB,
                                                                                     _paramRutEmisorD,
                                                                                     _Ambiente)
                    File.Delete(_Dir)

                    _Respuesta = _respuestaEnvio

                End If


                If _Respuesta.correcto Then

                    _Trackid = _Respuesta.Resultado

                    If IsNumeric(_Trackid) Then

                        'Sb_AddToLog("Enviar SII", _Tido & "-" & _Nudo & ", Enviado Trackid: " & _Trackid, Txt_Log)

                        Dim _Id_Trackid As Integer

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_DTE_Trackid (Id_Dte,Idmaeedo,Trackid,FechaEnvSII,Procesar,AmbienteCertificacion) Values " & vbCrLf &
                               "(" & _Id_Dte & "," & _Idmaeedo & ",'" & _Trackid & "',Getdate(),1," & Convert.ToInt32(_AmbienteCertificacion) & ")"
                        _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Trackid, False)

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Procesado = 1 Where Id_Dte =  " & _Id_Dte
                        _Sql.Ej_consulta_IDU(Consulta_sql, False)

                    Else

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Respuesta = '" & _Trackid & "' Where Id_Dte = " & _Id_Dte
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                    End If

                Else

                    'Sb_AddToLog("Enviar SII", _Tido & "-" & _Nudo & ", Error: " & _Respuesta.mensaje.Trim & " - " & _Respuesta.detalle.Trim, Txt_Log)

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Respuesta = '" & _Respuesta.mensaje & " - " & _Respuesta.detalle.Trim & "' Where Id_Dte = " & _Id_Dte
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

            End If

        Catch ex As Exception
            _Respuesta.correcto = False
            _Respuesta.mensaje = ex.Message
            _Respuesta.detalle = String.Empty
        End Try

        Return _Respuesta

    End Function

    Sub Sb_Consultar_Trackid()

        Dim _Resultado As Object 'HEFESTO.CONSULTA.TRACKID.Respuesta

        Dim _Id_Trackid As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Trackid", "Id", "Trackid = '" & _Trackid & "'", True, False)

        If Not CBool(_Id_Trackid) Then
            Console.WriteLine("No se encontro registros con el Trackid: {0}", _Trackid)
            Return
        End If

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_DTE_Trackid Where Id = " & _Id_Trackid
        Dim _RowTrackid As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Intentos As Integer = _RowTrackid.Item("Intentos")
        Dim _Procesado = 1
        Dim _Procesar = 0

        Dim _Estado = String.Empty
        Dim _Glosa = String.Empty

        Dim _Aceptado As Integer
        Dim _Informado As Integer
        Dim _Rechazado As Integer
        Dim _Reparo As Integer
        Dim _EnviarMail = 0
        Dim _VolverProcesar As Boolean
        Dim _Respuesta As String

        _Intentos += 1

        If Fx_Consultar_Trackid(_Trackid, _Resultado) Then

            Console.WriteLine("******************************")
            Console.WriteLine("Estado    : {0}", CType(_Resultado, HEFESTO.CONSULTA.TRACKID.entRespuestaDTE).Estado)
            Console.WriteLine("EstadoDTE : {0}", CType(_Resultado, HEFESTO.CONSULTA.TRACKID.entRespuestaDTE).EstadoDTE)
            Console.WriteLine("Glosa     : {0}", CType(_Resultado, HEFESTO.CONSULTA.TRACKID.entRespuestaDTE).Glosa)
            Console.WriteLine("******************************")
            Console.WriteLine(vbCrLf)

            _Respuesta = CType(_Resultado, HEFESTO.CONSULTA.TRACKID.entRespuestaDTE).Glosa

            Sb_Revisar_Respuesta_Trackid(_Respuesta, _Estado, _Glosa,
                                                    _Aceptado, _Informado, _Rechazado, _Reparo,
                                                    _VolverProcesar)

            If _VolverProcesar And _Intentos <= 3 Then
                _Procesado = 0
                _Procesar = 1
            End If

            If _Estado = "EPR" Then
                _EnviarMail = 1
            End If

        Else

            Console.WriteLine("******************************")
            Console.WriteLine("Es correcto : {0}", CType(_Resultado, HEFESTO.CONSULTA.TRACKID.Respuesta).EsCorrecto)
            Console.WriteLine("Detalle     : {0}", CType(_Resultado, HEFESTO.CONSULTA.TRACKID.Respuesta).Detalle)
            Console.WriteLine("Mensaje     : {0}", CType(_Resultado, HEFESTO.CONSULTA.TRACKID.Respuesta).Mensaje)
            Console.WriteLine("Resultado   : {0}", CType(_Resultado, HEFESTO.CONSULTA.TRACKID.Respuesta).Resultado)
            Console.WriteLine("******************************")
            Console.WriteLine(vbCrLf)

            If _Intentos <= 3 Then
                _Procesado = 0
                _Procesar = 1
            End If

            _Respuesta = CType(_Resultado, HEFESTO.CONSULTA.TRACKID.Respuesta).Mensaje

        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set " & vbCrLf &
                           "Procesado = " & _Procesado & "," &
                           "Procesar = " & _Procesar & "," &
                           "Informado = " & _Informado & "," &
                           "Aceptado = " & _Aceptado & "," &
                           "Rechazado = " & _Rechazado & "," &
                           "Reparo = " & _Reparo & "," &
                           "EnviarMail = " & _EnviarMail & "," &
                           "Estado = '" & _Estado & "'," &
                           "Glosa = '" & _Glosa & "'," &
                           "Respuesta = '" & _Respuesta & "'," & vbCrLf &
                           "Intentos = " & _Intentos & vbCrLf &
                           "Where Id = " & _Id_Trackid
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Console.WriteLine("*** Fin consulta Tranckid")

        If Environment.GetCommandLineArgs.Length = 1 Then
            Console.ReadKey()
        End If

    End Sub

    Function Fx_Consultar_Trackid(_Trackid As String, ByRef _Resultado As Object) As Boolean ' HEFESTO.CONSULTA.TRACKID.Respuesta

        Dim _Resp As New HEFESTO.CONSULTA.TRACKID.Respuesta

        Dim _Id_Trackid As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Trackid", "Id", "Trackid = '" & _Trackid & "'", True, False)

        If Not CBool(_Id_Trackid) Then
            _Resp.EsCorrecto = False
            _Resp.Mensaje = "No se encontro registros con el Trackid: " & _Trackid
            _Resultado = _Resp
            Return False
        End If

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_DTE_Trackid Where Id = " & _Id_Trackid
        Dim _RowTrackid As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Idmaeedo = _RowTrackid.Item("Idmaeedo")

        Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
        Dim _Maeedo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Tido As String = _Maeedo.Item("TIDO")
        Dim _Nudo As String = _Maeedo.Item("NUDO")
        Dim _RutEmisor As String

        Dim _Cn As String

        Consulta_sql = "Select Id,Empresa,Campo,Valor,FechaMod,TipoCampo,TipoConfiguracion" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_DTE_Configuracion" & vbCrLf &
                       "Where Empresa = '" & _Empresa & "' And TipoConfiguracion = 'ConfEmpresa'"
        Dim _Tbl_ConfEmpresa As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If Not CBool(_Tbl_ConfEmpresa.Rows.Count) Then
            _Resp.EsCorrecto = False
            _Resp.Mensaje = "Faltan los datos de configuración DTE para la empresa"
            _Resultado = _Resp
            Return False
        End If

        For Each _Fila As DataRow In _Tbl_ConfEmpresa.Rows

            Dim _Campo As String = _Fila.Item("Campo").ToString.Trim

            If _Campo = "RutEmisor" Then _RutEmisor = _Fila.Item("Valor")
            If _Campo = "Cn" Then _Cn = _Fila.Item("Valor")

        Next

        Dim _Certificado As X509Certificate2 = HEFESTO.CONSULTA.TRACKID.Negocio.Certificados.RecuperarCertificado(_Cn)

        If IsDBNull(_Certificado) Then
            _Resp.EsCorrecto = False
            _Resp.Mensaje = "No se encuentra el certificado: " & _Cn
            _Resultado = _Resp
            Return False
        End If

        Dim _SiiAmbiente As HEFESTO.CONSULTA.TRACKID.SIIAmbiente

        If _AmbienteCertificacion Then
            _SiiAmbiente = HEFESTO.CONSULTA.TRACKID.SIIAmbiente.Certificacion
        Else
            _SiiAmbiente = HEFESTO.CONSULTA.TRACKID.SIIAmbiente.Produccion
        End If

        _Resp = HEFESTO.CONSULTA.TRACKID.Negocio.EnvioSII.ConsultarTrackId(_RutEmisor, _Certificado, _Trackid, _SiiAmbiente)

        If _Resp.EsCorrecto Then

            Dim _NewResp As New HEFESTO.CONSULTA.TRACKID.entRespuestaDTE

            _NewResp = _Resp.Resultado

            Dim _Estado = CType(_Resp.Resultado, HEFESTO.CONSULTA.TRACKID.entRespuestaDTE).Estado
            Dim _EstadoDTE = CType(_Resp.Resultado, HEFESTO.CONSULTA.TRACKID.entRespuestaDTE).EstadoDTE
            Dim _Glosa = CType(_Resp.Resultado, HEFESTO.CONSULTA.TRACKID.entRespuestaDTE).Glosa

            Dim _Respuesta As HEFESTO.CONSULTA.TRACKID.Respuesta = HEFESTO.CONSULTA.TRACKID.Negocio.EnvioSII.RecuperarEstadoByRespuesta(_Glosa)

            _Resultado = _NewResp

        End If

        Return True

    End Function

    Public Function AppPath(Optional backSlash As Boolean = False) As String

        Dim s As String = IO.Path.GetDirectoryName(GetExecutingAssembly.GetCallingAssembly.Location)

        If backSlash Then
            s &= "\"
        End If

        ' si hay que añadirle el backslash
        Return s

    End Function

    Sub Sb_Revisar_Respuesta_Trackid(_Respuesta As String,
                                     ByRef _Estado As String,
                                     ByRef _Glosa As String,
                                     ByRef _Aceptados As Integer,
                                     ByRef _Informados As Integer,
                                     ByRef _Rechazados As Integer,
                                     ByRef _Reparos As Integer,
                                     ByRef _VolverProcesar As Boolean)

        If _Respuesta.Contains("SII:RESP_BODY") Then

            Dim _Caf As New XDocument
            _Caf = XDocument.Parse(_Respuesta)

            'Dim _ACEPTADOS As Integer
            'Dim _INFORMADOS As Integer
            'Dim _RECHAZADOS As Integer
            'Dim _REPAROS As Integer

            Dim ns = _Caf.Root.GetDefaultNamespace
            Dim _nsManager = New XmlNamespaceManager(New NameTable())

            _nsManager.AddNamespace("d", "http://www.sii.cl/XMLSchema")

            Try
                _Aceptados = _Caf.XPathSelectElement("/d:RESPUESTA/d:RESP_BODY/ACEPTADOS", _nsManager)
                'If CBool(_Aceptados) Then _Estado = "-ACEPTADO"
                _Informados = _Caf.XPathSelectElement("/d:RESPUESTA/d:RESP_BODY/INFORMADOS", _nsManager)
                'If CBool(_Informados) Then _Estado += "-INFORMADO"
                _Rechazados = _Caf.XPathSelectElement("/d:RESPUESTA/d:RESP_BODY/RECHAZADOS", _nsManager)
                'If CBool(_Rechazados) Then _Estado += "-RECHAZADO"
                _Reparos = _Caf.XPathSelectElement("/d:RESPUESTA/d:RESP_BODY/REPAROS", _nsManager)
                'If CBool(_Reparos) Then _Estado += "-REPARO"
            Catch ex As Exception
                _Aceptados = 0 : _Informados = 0 : _Rechazados = 0 : _Reparos = 0
                'Throw New Exception("El documento que intenta cargar no es un archivo CAF.")
            End Try

        End If

        If _Respuesta.Contains("SII:RESP_HDR") Then

            Dim _Caf As New XDocument
            _Caf = XDocument.Parse(_Respuesta)

            Dim ns = _Caf.Root.GetDefaultNamespace
            Dim _nsManager = New XmlNamespaceManager(New NameTable())

            _nsManager.AddNamespace("d", "http://www.sii.cl/XMLSchema")

            Try
                _Estado = _Caf.XPathSelectElement("/d:RESPUESTA/d:RESP_HDR/ESTADO", _nsManager)
            Catch ex As Exception
                _Estado = String.Empty
            End Try

            If _Estado = "EPR" And _Rechazados Then
                _Estado = "RCH"
            End If

            _Glosa = Fx_GlosaEstados(_Estado, _Aceptados, _Rechazados, _VolverProcesar)

            If _Estado = "EPR" And _Rechazados Then
                _Glosa += " (Revise el SII, puede que el documento este aceptado con otro Trackid)"
            End If

        End If

    End Sub

    Function Fx_GlosaEstados(_Estado As String,
                             ByRef _Aceptado As Integer,
                             ByRef _Rechazado As Integer,
                             ByRef _VolverProcesar As Boolean) As String

        _Aceptado = 0
        _Rechazado = 0
        _VolverProcesar = False

        Select Case _Estado
            Case "RSC"
                _Rechazado = 1
                Return "Rechazado por Error en Schema"
            Case "SOK"
                _VolverProcesar = True
                Return "Schema Validado"
            Case "CRT"
                _VolverProcesar = True
                Return "Carátula OK"
            Case "RFR"
                _Rechazado = 1
                Return "Rechazado por Error en Firma"
            Case "FOK"
                _VolverProcesar = True
                Return "Firma de Envió Validada"
            Case "PDR"
                _VolverProcesar = True
                Return "Envió en Proceso"
            Case "RCT"
                _Rechazado = 1
                Return "Rechazado por Error en Carátula"
            Case "RCH"
                _Rechazado = 1
                Return "DTE Rechazado"
            Case "EPR"
                _Aceptado = 1
                Return "Envió Procesado"
            Case "-1"
                _VolverProcesar = True
                Return "ERROR: RETORNO CAMPO ESTADO, NO EXISTE"
            Case "-2"
                _VolverProcesar = True
                Return "ERROR RETORNO"
            Case "-3"
                _VolverProcesar = True
                Return "ERROR: RUT USUARIO NO EXISTE"
            Case "-4"
                _VolverProcesar = True
                Return "ERROR OBTENCION DE DATOS"
            Case "-5"
                _VolverProcesar = True
                Return "ERROR RETORNO DATOS"
            Case "-6"
                _VolverProcesar = True
                Return "ERROR: USUARIO NO AUTORIZADO"
            Case "-7"
                _VolverProcesar = True
                Return "ERROR RETORNO DATOS"
            Case "-8"
                _VolverProcesar = True
                Return "ERROR: RETORNO DATOS"
            Case "-9"
                Return "ERROR: RETORNO DATOS"
            Case "-10"
                _VolverProcesar = True
                Return "ERROR: VALIDA RUT USUARIO"
            Case "-11"
                _VolverProcesar = True
                Return "ERR_CODE, SQL_CODE, SRV_CODE"
            Case "-12"
                _VolverProcesar = True
                Return "ERROR: RETORNO CONSULTA"
            Case "-13"
                _VolverProcesar = True
                Return "ERROR RUT USUARIO NULO"
            Case "-14"
                _VolverProcesar = True
                Return "ERROR XML RETORNO DATOS"
            Case "001"
                _Rechazado = 1
                Return "COOKIE INACTIV"
            Case "002"
                _Rechazado = 1
                Return "TOKEN+INACTIVO"
            Case "003"
                _Rechazado = 1
                Return "NO+EXISTE"
            Case Else
                Return ""
        End Select

    End Function

End Module
