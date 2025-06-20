Imports System.ComponentModel
Imports System.IO
Imports System.IO.Compression
Imports System.Linq
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.Xml
Imports System.Xml.XPath
Imports BakApp_DTEMonitor.Eventos_Dte
Imports DevComponents.DotNetBar
Imports Hefesto.FIRMA.DOCUMENTO
Imports HEFSIILIBDTES
'Imports Ionic.Zip
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports HefConsultas = HEFSIILIBDTES.CONSULTAS.HefConsultas
Imports HefRespuesta = HEFSIIREGCOMPRAVENTAS.LIB.HefRespuesta


Public Class Frm_Demonio_DTEMonitor

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Minimizar As Boolean
    Dim _Formulario_Padre As Form

    Dim _AmbienteCertificacion As Integer

    Dim _Segundos As Integer
    Dim _Segundos_Esperando As Integer
    Dim _Contador_Esperando As Long
    Dim _ProxProceso As String

    Dim _VersionBakappExe As String
    Dim _VersionDTEMonitor As String
    Dim _RevisarCertificado As Boolean

    Dim _Firmando As Boolean

    Private bgWorker As New BackgroundWorker

    Dim _RutEmisor As String
    Dim _RutEnvia As String
    Dim _RutReceptor As String
    Dim _FchResol As String
    Dim _NroResol As String
    Dim _Cn As String

    Dim _RevisarReclamoDTE As Boolean

    Enum Enum_Accion
        EnviarBoletaSII
        ConsultarTrackid
    End Enum

    Public Property Minimizar As Boolean
        Get
            Return _Minimizar
        End Get
        Set(value As Boolean)
            _Minimizar = value
        End Set
    End Property

    Public Sub New(_Formulario_Padre As Form)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Formulario_Padre = _Formulario_Padre
        'Me.WindowState = FormWindowState.Minimized

        Timer_Hora_Actual.Enabled = True

        Chk_AmbienteCertificacion.Checked = _Global_Row_EstacionBk.Item("DTEMonitorAmbienteCertificacion")

        _Segundos_Esperando = 10
        _Segundos = 15

        Dim _elPath = AppPath() & "\BakApp_Soluciones.exe"

        Try
            Dim fvi As System.Diagnostics.FileVersionInfo =
        System.Diagnostics.FileVersionInfo.GetVersionInfo(_elPath)

            _VersionBakappExe = "Versión BakApp: " & fvi.FileVersion & ", "
        Catch ex As Exception
            _VersionBakappExe = String.Empty
        End Try

        _elPath = AppPath() & "\BakApp_DTEMonitor.exe"

        Try
            Dim fvi As System.Diagnostics.FileVersionInfo =
        System.Diagnostics.FileVersionInfo.GetVersionInfo(_elPath)

            _VersionDTEMonitor = fvi.FileVersion
        Catch ex As Exception
            _VersionDTEMonitor = String.Empty
        End Try

        Timer_Minimizar.Interval = (1000 * 60) * 10
        _RevisarCertificado = True

        'Timer_RevisarReclamoDTE.Interval = (1000 * 60) * 30

        Timer_RevisarReclamoDTE.Start()

        'Dim sb As New System.Text.StringBuilder
        'sb.AppendLine("ProductName:     " & fvi.ProductName)
        'sb.AppendLine("FileDescription: " & fvi.FileDescription)
        'sb.AppendLine("FileVersion:     " & fvi.FileVersion)
        'sb.AppendLine("ProductVersion:  " & fvi.ProductVersion)
        'sb.AppendLine("LegalCopyright:  " & fvi.LegalCopyright)

    End Sub
    Private Sub Frm_Demonio_DTEMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CircularPgrs.IsRunning = True

        Timer_Enviar_SII.Interval = 1000 * 15
        Timer_Consultar_TrackId.Interval = 1000 * 30
        Timer_Enviar_Correos.Interval = 1000 * 30

        _RevisarReclamoDTE = True

        Timer_Hora_Actual.Enabled = True
        Timer_Enviar_SII.Start()

        _AmbienteCertificacion = Convert.ToInt32(Chk_AmbienteCertificacion.Checked)

        Chk_MostrarBoletaBkHfDOS.Checked = False
        Chk_MostrarBoletaBkHfDOS.Visible = Chk_AmbienteCertificacion.Checked

        Dim _Dir_Local As String = Application.StartupPath

        Dim infoDirectorio As New DirectoryInfo(_Dir_Local)
        ' Obtener el directorio padre
        Dim directorioPadre As DirectoryInfo = infoDirectorio.Parent

        ' Si necesitas la ruta como string
        Dim rutaDirectorioPadre As String = directorioPadre.FullName
        _Dir_Local = rutaDirectorioPadre & "\Data\"



        Dim _Ds As New DatosBakApp
        _Ds.Clear()
        _Ds.ReadXml(_Dir_Local & RutEmpresa & "\Configuracion_Local\Nombre_Equipo.xml")

        Dim _Row_Nom_Equipo = _Ds.Tables("Tbl_Nombre_Equipo").Rows(0)
        Dim _Nombre_Equipo = _Global_Row_EstacionBk.Item("NombreEquipo") & " (" & _Global_Row_EstacionBk.Item("Alias") & ")"

        Lbl_Nombre_Equipo.Text = "Nombre equipo: " & _Nombre_Equipo.trim & ", Modalidad: " & Modalidad
        _Contador_Esperando = 1


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

        bgWorker = New BackgroundWorker
        AddHandler bgWorker.DoWork, AddressOf MyWorker_DoWork
        AddHandler bgWorker.RunWorkerCompleted, AddressOf MyWorker_RunWorkerCompleted

    End Sub

    Private Sub Timer_Hora_Actual_Tick(sender As Object, e As EventArgs) Handles Timer_Hora_Actual.Tick
        Me.Text = "Acciones automáticas, Hora actual: " & Date.Now.ToLongTimeString & ". Versión BakApp DTEMonitor: " & _VersionDTEMonitor
    End Sub

    Sub Sb_Enviar_Documentos_Al_SIIDTE_Bk()

        Try

            Dim _FechaDelServidor As Date = FechaDelServidor(False)

            Dim _FechaHoy As String = Format(_FechaDelServidor, "yyyyMMdd")
            Dim _FechaMesAnterios As DateTime = DateAdd(DateInterval.Month, -1, _FechaDelServidor)
            Dim _FechaPrimerDiaMes As String = Format(Primerdiadelmes(_FechaMesAnterios), "yyyyMMdd")

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Procesar = 1 " & vbCrLf &
                           "Where Procesar = 0 And Idmaeedo Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_DTE_Trackid) And " &
                           "Convert(varchar,FechaSolicitud,112) = '" & _FechaHoy & "' And Tido <> 'BLV' And ErrorEnvioDTE = 0"
            If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Procesar = 1 " & vbCrLf &
                           "Where Procesar = 0 And Idmaeedo Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_DTE_Trackid Where FechaEnvSII > '" & _FechaPrimerDiaMes & "') And " &
                           "FechaSolicitud >= '" & _FechaPrimerDiaMes & "' And Tido <> 'BLV' And ErrorEnvioDTE = 0"
            If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            Consulta_sql = "Select Top 20 Id_Dte,Idmaeedo,Tido,Nudo,Trackid,FechaSolicitud,Xml,Firma,CaratulaXml,Respuesta,AmbienteCertificacion,Procesar,Procesado" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_DTE_Documentos" & vbCrLf &
                           "Where Procesar = 1 And Procesado = 0 And AmbienteCertificacion = " & _AmbienteCertificacion & " And Tido <> 'BLV'" & vbCrLf &
                           "Order By Tido,Nudo"

            Dim _Tbl_DTE_Documentos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            If Not CBool(_Tbl_DTE_Documentos.Rows.Count) Then
                Return
            End If

            If CBool(_Tbl_DTE_Documentos.Rows.Count) Then

                Sb_AddToLog("Enviar SII", "Revisando documentos pendientes de enviar al SII", Txt_Log)

                Dim _Filtro_Id_Dte As String = Generar_Filtro_IN(_Tbl_DTE_Documentos, "", "Id_Dte", False, False, "")

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Procesar = 0 Where Id_Dte In " & _Filtro_Id_Dte
                If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                    Throw New System.Exception(_Sql.Pro_Error)
                End If

                For Each _Fila As DataRow In _Tbl_DTE_Documentos.Rows

                    Dim _Idmaeedo = _Fila.Item("Idmaeedo")
                    Dim _Id_Dte = _Fila.Item("Id_Dte")
                    Dim _Tido = _Fila.Item("Tido")
                    Dim _Nudo = _Fila.Item("Nudo")
                    Dim _FechaSolicitud As DateTime = _Fila.Item("FechaSolicitud")

                    If Fx_Esta_Firmando(_Filtro_Id_Dte, _Id_Dte) Then
                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set Procesar = 1" & vbCrLf &
                                       "Where Id In " & _Filtro_Id_Dte
                        If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                            Throw New System.Exception(_Sql.Pro_Error)
                        End If
                        Exit For
                    End If

                    Dim _FechaSolicitud_Str As String = _FechaSolicitud.ToShortDateString & " - " & _FechaSolicitud.ToShortTimeString
                    Sb_AddToLog("Enviar SII", "Revisando " & _Tido & "-" & _Nudo & ", Fecha solicitud: " & _FechaSolicitud_Str, Txt_Log)

                    Dim _AmbienteCertificacion As Boolean = Chk_AmbienteCertificacion.Checked
                    Dim _Accion As Enum_Accion = Enum_Accion.EnviarBoletaSII

                    Dim _Enviar_DTE As Hefesto.DTE.AUTENTICACION.ENT.Respuesta = Fx_Enviar_DTE_Al_SII(_Id_Dte, _AmbienteCertificacion)

                    If _Enviar_DTE.correcto Then

                        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_DTE_Trackid Where Id_Dte = " & _Id_Dte & "Order By Id Desc"
                        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

                        If Not IsNothing(_Row) Then
                            Dim _Trackid As String = _Row.Item("Trackid")
                            Sb_AddToLog("Enviar SII", _Tido & "-" & _Nudo & ", Enviado Trackid: " & _Trackid, Txt_Log)
                        Else
                            Dim _Error = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Documentos", "Respuesta", "Id_Dte = " & _Id_Dte)
                            Sb_AddToLog("Enviar SII", _Tido & "-" & _Nudo & ", Error: " & _Error, Txt_Log)
                        End If

                    Else

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Respuesta = Respuesta + '" & _Enviar_DTE.mensaje & "'" & vbCrLf &
                                       "Where Id_Dte In " & _Filtro_Id_Dte
                        If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                            Throw New System.Exception(_Sql.Pro_Error)
                        End If

                        If _Enviar_DTE.mensaje.ToString.Contains("No fue posible encontrar la Caratula") Then
                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Procesar = 0, Procesado = 1" & vbCrLf &
                                           "Where Id_Dte In " & _Filtro_Id_Dte
                            If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                                Throw New System.Exception(_Sql.Pro_Error)
                            End If
                        End If

                        Sb_AddToLog("Enviar SII", _Enviar_DTE.mensaje, Txt_Log)

                    End If

                Next

                Sb_AddToLog("Enviar SII", "Fin proceso", Txt_Log)

            End If

        Catch ex As Exception
            Sb_AddToLog("Enviar SII", ex.Message, Txt_Log)
        End Try

    End Sub

    Function Fx_Consultar_Trackid_DTE(_Trackid As String, ByRef _Resultado As Object) As Boolean

        Dim _Resp As New Hefesto.CONSULTA.TRACKID.Respuesta

        Dim _Id_Trackid As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Trackid", "Id", "Trackid = '" & _Trackid & "'", True, False)

        If Not CBool(_Id_Trackid) Then
            _Resp.EsCorrecto = False
            _Resp.Mensaje = "No se encontro registros con el Trackid: " & _Trackid
            _Resultado = _Resp
            Return False
        End If

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_DTE_Trackid Where Id = " & _Id_Trackid
        Dim _RowTrackid As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Id_Dte = _RowTrackid.Item("Id_Dte")
        Dim _Idmaeedo = _RowTrackid.Item("Idmaeedo")

        Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
        Dim _Maeedo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Tido As String
        Dim _Nudo As String

        If IsNothing(_Maeedo) Then

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_DTE_Documentos Where Id_Dte = " & _Id_Dte
            Dim _Row_Dte As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row_Dte) Then
                _Resp.EsCorrecto = False
                _Resp.Mensaje = "No se encontro registros con el Id_Dte: " & _Id_Dte & ", Idmaeedo: " & _Idmaeedo
                _Resultado = _Resp
                Return False
            End If

            _Tido = _Row_Dte.Item("Tido")
            _Nudo = _Row_Dte.Item("Nudo")

            Consulta_sql = "Select * From MAEEDO Where TIDO = '" & _Tido & "' And NUDO = '" & _Nudo & "'"
            _Maeedo = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Maeedo) Then
                _Resp.EsCorrecto = False
                _Resp.Mensaje = "No se encontro el documento: " & _Tido & "-" & _Nudo
                _Resultado = _Resp
                Return False
            End If

            _Idmaeedo = _Maeedo.Item("IDMAEEDO")

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Idmaeedo = " & _Idmaeedo & " Where Id_Dte = " & _Id_Dte & vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set Idmaeedo = " & _Idmaeedo & " Where Id_Dte = " & _Id_Dte
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

        End If

        _Tido = _Maeedo.Item("TIDO")
        _Nudo = _Maeedo.Item("NUDO")

        Dim _RutEmisor As String

        Dim _Cn As String

        Consulta_sql = "Select Id,Empresa,Campo,Valor,FechaMod,TipoCampo,TipoConfiguracion" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_DTE_Configuracion" & vbCrLf &
                       "Where Empresa = '" & ModEmpresa & "' And TipoConfiguracion = 'ConfEmpresa'"
        Dim _Tbl_ConfEmpresa As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

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

        Dim _Certificado As X509Certificate2 = Hefesto.CONSULTA.TRACKID.Negocio.Certificados.RecuperarCertificado(_Cn)

        If IsDBNull(_Certificado) Then
            _Resp.EsCorrecto = False
            _Resp.Mensaje = "No se encuentra el certificado: " & _Cn
            _Resultado = _Resp
            Return False
        End If

        Dim _SiiAmbiente As Hefesto.CONSULTA.TRACKID.SIIAmbiente

        If _AmbienteCertificacion Then
            _SiiAmbiente = Hefesto.CONSULTA.TRACKID.SIIAmbiente.Certificacion
        Else
            _SiiAmbiente = Hefesto.CONSULTA.TRACKID.SIIAmbiente.Produccion
        End If

        _Resp = Hefesto.CONSULTA.TRACKID.Negocio.EnvioSII.ConsultarTrackId(_RutEmisor, _Certificado, _Trackid, _SiiAmbiente)

        If _Resp.EsCorrecto Then

            Dim _NewResp As New Hefesto.CONSULTA.TRACKID.entRespuestaDTE

            _NewResp = _Resp.Resultado

            Dim _Estado = CType(_Resp.Resultado, Hefesto.CONSULTA.TRACKID.entRespuestaDTE).Estado
            Dim _EstadoDTE = CType(_Resp.Resultado, Hefesto.CONSULTA.TRACKID.entRespuestaDTE).EstadoDTE
            Dim _Glosa = CType(_Resp.Resultado, Hefesto.CONSULTA.TRACKID.entRespuestaDTE).Glosa

            Dim _Respuesta As Hefesto.CONSULTA.TRACKID.Respuesta = Hefesto.CONSULTA.TRACKID.Negocio.EnvioSII.RecuperarEstadoByRespuesta(_Glosa)

            _Resultado = _NewResp

        End If

        Return True

    End Function

    Sub Sb_Enviar_Documentos_Al_SIIBoletas_Bk()

        Try

            Dim _FechaDelServidor As Date = FechaDelServidor(False)

            Dim _FechaMesAnterios As DateTime = DateAdd(DateInterval.Month, -1, _FechaDelServidor)
            Dim _FechaPrimerDiaMes As String = Format(Primerdiadelmes(_FechaMesAnterios), "yyyyMMdd")

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Procesar = 1 " & vbCrLf &
                           "Where Procesar = 0 And Idmaeedo Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_DTE_Trackid) And " &
                           "CONVERT(varchar,FechaSolicitud,112) = '" & _FechaDelServidor & "' And Tido = 'BLV' And ErrorEnvioDTE = 0"
            If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Procesar = 1 " & vbCrLf &
                           "Where Procesar = 0 And Idmaeedo Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_DTE_Trackid Where FechaEnvSII > '" & _FechaPrimerDiaMes & "') And " &
                           "FechaSolicitud >= '" & _FechaPrimerDiaMes & "' And Tido = 'BLV' And ErrorEnvioDTE = 0"
            If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            Consulta_sql = "Select Top 20 Id_Dte,Idmaeedo,Tido,Nudo,Trackid,FechaSolicitud,Xml,Firma,CaratulaXml,Respuesta,AmbienteCertificacion,Procesar,Procesado" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_DTE_Documentos" & vbCrLf &
                           "Where Procesar = 1 And Procesado = 0 And AmbienteCertificacion = " & _AmbienteCertificacion & " And Tido = 'BLV'" & vbCrLf &
                           "Order By Tido,Nudo"

            Dim _Tbl_DTE_Documentos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            If Not CBool(_Tbl_DTE_Documentos.Rows.Count) Then
                Return
            End If

            If CBool(_Tbl_DTE_Documentos.Rows.Count) Then

                Sb_AddToLog("Enviar SII", "Revisando documentos pendientes de enviar al SII", Txt_Log)

                Dim _Filtro_Id_Dte As String = Generar_Filtro_IN(_Tbl_DTE_Documentos, "", "Id_Dte", False, False, "")

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Procesar = 0 Where Id_Dte In " & _Filtro_Id_Dte
                If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                    Throw New System.Exception(_Sql.Pro_Error)
                End If

                For Each _Fila As DataRow In _Tbl_DTE_Documentos.Rows

                    Dim _Idmaeedo = _Fila.Item("Idmaeedo")
                    Dim _Id_Dte = _Fila.Item("Id_Dte")
                    Dim _Tido = _Fila.Item("Tido")
                    Dim _Nudo = _Fila.Item("Nudo")
                    Dim _FechaSolicitud As DateTime = _Fila.Item("FechaSolicitud")

                    If Fx_Esta_Firmando(_Filtro_Id_Dte, _Id_Dte) Then
                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set Procesar = 1" & vbCrLf &
                                           "Where Id In " & _Filtro_Id_Dte
                        If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                            Throw New System.Exception(_Sql.Pro_Error)
                        End If
                        Exit For
                    End If

                    Dim _FechaSolicitud_Str As String = _FechaSolicitud.ToShortDateString & " - " & _FechaSolicitud.ToShortTimeString

                    Sb_AddToLog("Enviar SII", "Revisando " & _Tido & "-" & _Nudo & ", Fecha solicitud: " & _FechaSolicitud_Str, Txt_Log)

                    Dim _AmbienteCertificacion As Boolean = Chk_AmbienteCertificacion.Checked

                    Dim _HefRespuesta As New HEFSIILIBDTES.HefRespuesta

                    _HefRespuesta = Fx_Enviar_Boleta_SII(_Id_Dte, _AmbienteCertificacion, RutEmpresaActiva)

                    Try

                        If Not _HefRespuesta.EsCorrecto Then
                            Throw New System.Exception(_HefRespuesta.Detalle)
                        End If

                        Consulta_sql = "Select Top 1 Isnull(Tid.Trackid,'') As Trackid,Doc.Respuesta" & vbCrLf &
                                       "From " & _Global_BaseBk & "Zw_DTE_Trackid Tid " & vbCrLf &
                                       "Inner Join " & _Global_BaseBk & "Zw_DTE_Documentos Doc On Tid.Id_Dte = Doc.Id_Dte" & vbCrLf &
                                       "Where Doc.Id_Dte = " & _Id_Dte & "Order By Id Desc"
                        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

                        If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                            Throw New System.Exception(_Sql.Pro_Error)
                        End If

                        Dim _Trackid As String = _Row.Item("Trackid")
                        Dim _Respuesta As String = _Row.Item("Respuesta")

                        If String.IsNullOrEmpty(_Trackid) Then
                            Sb_AddToLog("Enviar SII", _Tido & "-" & _Nudo & ", Error documento no enviado al SII: " & _Trackid, Txt_Log)
                        Else
                            Sb_AddToLog("Enviar SII", _Tido & "-" & _Nudo & ", Enviado Trackid: " & _Trackid, Txt_Log)
                        End If

                    Catch ex As Exception
                        Sb_AddToLog("Enviar SII", ex.Message, Txt_Log)
                    End Try

                Next

                Sb_AddToLog("Enviar SII", "Fin proceso", Txt_Log)

            End If

        Catch ex As Exception
            Sb_AddToLog("Enviar SII", ex.Message, Txt_Log)
        End Try

    End Sub

    Sub Sb_Revisar_Trackid_DTEBk()

        Try

            Consulta_sql = "Select Top 20 Tid.*,Doc.Tido From " & _Global_BaseBk & "Zw_DTE_Trackid Tid" & vbCrLf &
                   "Inner Join " & _Global_BaseBk & "Zw_DTE_Documentos Doc On Tid.Id_Dte = Doc.Id_Dte" & vbCrLf &
                   "Where Doc.Tido <> 'BLV' And Tid.AmbienteCertificacion = " & _AmbienteCertificacion & vbCrLf &
                   "And ((Tid.Procesar = 0 And (Tid.Estado = '-11' Or Tid.Estado = 'SOK' Or Tid.Estado = '107' Or Tid.Estado = '') And Tid.Intentos <=10) Or (Tid.Procesar = 1 And Tid.Procesado = 0))" & vbCrLf &
                   "And Tid.Idmaeedo Not In  (Select Idmaeedo From " & _Global_BaseBk & "Zw_DTE_Trackid Tid2 Where Tid.Idmaeedo = Tid2.Idmaeedo And ((Informado = 1 And Reparo = 1 And Estado <> '107') or (Aceptado = 1)))" & vbCrLf &
                   "Order By Tido,Nudo"

            Dim _Tbl_DTE_Trackid As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            If Not CBool(_Tbl_DTE_Trackid.Rows.Count) Then
                Return
            End If

            If CBool(_Tbl_DTE_Trackid.Rows.Count) Then

                Dim _Filtro_Id_Trackid As String = Generar_Filtro_IN(_Tbl_DTE_Trackid, "", "Id_Dte", False, False, "")

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set Procesar = 0 Where Id In " & _Filtro_Id_Trackid
                If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                    Throw New System.Exception(_Sql.Pro_Error)
                End If

                For Each _Fila As DataRow In _Tbl_DTE_Trackid.Rows

                    Dim _Id_Trackid = _Fila.Item("Id")
                    Dim _Id_Dte = _Fila.Item("Id_Dte")
                    Dim _Trackid = _Fila.Item("Trackid")
                    Dim _Idmaeedo = _Fila.Item("Idmaeedo")
                    Dim _Respuesta = _Fila.Item("Respuesta")
                    Dim _Estado = String.Empty
                    Dim _Glosa = String.Empty
                    Dim _Tido = _Fila.Item("Tido")

                    If Fx_Esta_Firmando(_Filtro_Id_Trackid, _Id_Trackid) Then
                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set Procesar = 1" & vbCrLf &
                                       "Where Id In " & _Filtro_Id_Trackid
                        If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                            Throw New System.Exception(_Sql.Pro_Error)
                        End If
                        Exit For
                    End If

                    Sb_AddToLog("Revisar Trackid", "Revisando Trackid" & _Trackid, Txt_Log)

                    ' PARAMETROS 

                    '1 _Empresa = Environment.GetCommandLineArgs(2)
                    '2 _AmbienteCertificacion = Environment.GetCommandLineArgs(3)
                    '3 _Id_Dte = Environment.GetCommandLineArgs(4)
                    '4 _Trackid = Environment.GetCommandLineArgs(5)
                    '5 _Accion = Environment.GetCommandLineArgs(6)

                    Dim _Intentos As Integer = _Fila.Item("Intentos")
                    Dim _Procesado = 1
                    Dim _Procesar = 0

                    Dim _Aceptado As Integer
                    Dim _Informado As Integer
                    Dim _Rechazado As Integer
                    Dim _Reparo As Integer
                    Dim _EnviarMail = 0
                    Dim _VolverProcesar As Boolean

                    _Intentos += 1

                    Dim _Resultado As Object

                    If Fx_Consultar_Trackid_DTE(_Trackid, _Resultado) Then

                        Try

                            _Respuesta = CType(_Resultado, Hefesto.CONSULTA.TRACKID.entRespuestaDTE).Glosa

                            Sb_Revisar_Respuesta_Trackid(_Respuesta, _Estado, _Glosa,
                                                         _Aceptado, _Informado, _Rechazado, _Reparo,
                                                         _VolverProcesar)

                            If _VolverProcesar And _Intentos <= 3 Then
                                _Procesado = 0
                                _Procesar = 1
                            End If

                            If _Estado = "EPR" And _Tido <> "GTI" Then
                                _EnviarMail = 1
                            End If

                        Catch ex As Exception
                            _Intentos -= 1
                        End Try

                    Else

                        If _Intentos <= 3 Then
                            _Procesado = 0
                            _Procesar = 1
                        End If

                        _Respuesta = CType(_Resultado, Hefesto.CONSULTA.TRACKID.Respuesta).Mensaje

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
                    If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                        Throw New System.Exception(_Sql.Pro_Error)
                    End If

                    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DTE_Trackid Where Id = " & _Id_Trackid
                    Dim _RowTrackid As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                        Throw New System.Exception(_Sql.Pro_Error)
                    End If

                    _Estado = _RowTrackid.Item("Estado")
                    _Glosa = _RowTrackid.Item("Glosa")
                    _Respuesta = _RowTrackid.Item("Respuesta")

                    Sb_AddToLog("Revisar Trackid", "Respuesta SII: " & _Respuesta, Txt_Log)
                    Sb_AddToLog("Revisar Trackid", "Respuesta Estado: " & _Estado & ", Glosa: " & _Glosa, Txt_Log)

                Next

                Sb_AddToLog("Revisar Trackid", "Fin revisión", Txt_Log)

            End If

        Catch ex As Exception
            Sb_AddToLog("Enviar SII", ex.Message, Txt_Log)
        End Try

    End Sub

    Sub Sb_Revisar_Trackid_SIIBoletas_Bk()

        Try

            Consulta_sql = "Select Top 20 Tid.*,Doc.Tido From " & _Global_BaseBk & "Zw_DTE_Trackid Tid" & vbCrLf &
                           "Inner Join " & _Global_BaseBk & "Zw_DTE_Documentos Doc On Tid.Id_Dte = Doc.Id_Dte" & vbCrLf &
                           "Where Doc.Tido = 'BLV' And Tid.AmbienteCertificacion = " & _AmbienteCertificacion &
                           " And ((Tid.Procesar = 0 And (Tid.Estado = '-11' Or Tid.Estado = 'SOK' Or Tid.Estado = 'REC' Or Tid.Estado = '')) Or (Tid.Procesar = 1 And Tid.Procesado = 0))" & vbCrLf &
                           "Order By Tido,Nudo"

            'Consulta_sql = "Select Top 20 Tid.*,Doc.Tido From " & _Global_BaseBk & "Zw_DTE_Trackid Tid" & vbCrLf &
            '               "Inner Join " & _Global_BaseBk & "Zw_DTE_Documentos Doc On Tid.Id_Dte = Doc.Id_Dte" & vbCrLf &
            '               "Where Doc.Tido = 'BLV' And Tid.AmbienteCertificacion = " & _AmbienteCertificacion &
            '               " And Tid.Id = 16146"

            Dim _Tbl_DTE_Trackid As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            If Not CBool(_Tbl_DTE_Trackid.Rows.Count) Then
                Return
            End If

            If CBool(_Tbl_DTE_Trackid.Rows.Count) Then

                Dim _Filtro_Id_Trackid As String = Generar_Filtro_IN(_Tbl_DTE_Trackid, "", "Id_Dte", False, False, "")

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set Procesar = 0 Where Id In " & _Filtro_Id_Trackid
                If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                    Throw New System.Exception(_Sql.Pro_Error)
                End If

                For Each _Fila As DataRow In _Tbl_DTE_Trackid.Rows

                    Dim _Id_Trackid = _Fila.Item("Id")
                    Dim _Id_Dte = _Fila.Item("Id_Dte")
                    Dim _Trackid = _Fila.Item("Trackid")
                    Dim _Idmaeedo = _Fila.Item("Idmaeedo")
                    Dim _Respuesta = _Fila.Item("Respuesta")
                    Dim _Estado = String.Empty
                    Dim _Glosa = String.Empty

                    If Fx_Esta_Firmando(_Filtro_Id_Trackid, _Id_Trackid) Then
                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set Procesar = 1" & vbCrLf &
                                       "Where Id In " & _Filtro_Id_Trackid
                        If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                            Throw New System.Exception(_Sql.Pro_Error)
                        End If
                        Exit For
                    End If

                    Sb_AddToLog("Revisar Trackid", "Revisando Trackid: " & _Trackid, Txt_Log)

                    ' PARAMETROS 

                    '1 _Empresa = Environment.GetCommandLineArgs(2)
                    '2 _AmbienteCertificacion = Environment.GetCommandLineArgs(3)
                    '3 _Id_Dte = Environment.GetCommandLineArgs(4)
                    '4 _Trackid = Environment.GetCommandLineArgs(5)
                    '5 _Accion = Environment.GetCommandLineArgs(6)

                    Dim _HefRespuesta As New HEFSIILIBDTES.HefRespuesta

                    _HefRespuesta = Fx_Consultar_Trackid_BLV(_Trackid, _AmbienteCertificacion)

                    If Not IsNothing(_HefRespuesta) Then

                        If _HefRespuesta.EsCorrecto Then

                            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DTE_Trackid Where Trackid = '" & _Trackid & "'"
                            Dim _TblTrackid As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                            'Dim _RowTrackid As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                            For Each _Row As DataRow In _TblTrackid.Rows

                                Dim _Intentos As Integer = _Row.Item("Intentos")

                                _Id_Trackid = _Row.Item("Id")

                                If _TblTrackid.Rows.Count = 0 Then ' _Id_Trackid = 0 Then
                                    _HefRespuesta.EsCorrecto = False
                                    _HefRespuesta.Mensaje = "NO se encontro Id Trackid con Trackid: " & _Trackid
                                    _Id_Trackid = 0
                                End If

                                If CBool(_Id_Trackid) Then

                                    _Estado = String.Empty
                                    _Glosa = String.Empty

                                    Dim _Aceptado As Integer
                                    Dim _Informado As Integer
                                    Dim _Rechazado As Integer
                                    Dim _Reparo As Integer
                                    Dim _Procesado As Integer = 1
                                    Dim _Procesar As Integer = 0
                                    _Respuesta = _HefRespuesta.XmlDocumento
                                    Dim _VolverProcesar As Boolean

                                    _Intentos += 1

                                    If Not _HefRespuesta.EsCorrecto Then
                                        _Respuesta = _HefRespuesta.Detalle
                                        _VolverProcesar = True
                                    End If

                                    Dim _RespuestSII As RespBolSII = Fx_ObtenerDatosRespuestaSII(_Respuesta)

                                    If IsNothing(_RespuestSII) Then
                                        _VolverProcesar = True
                                    End If

                                    If Not IsNothing(_RespuestSII) Then

                                        _Estado = _RespuestSII.estado

                                        Try
                                            _Aceptado = _RespuestSII.estadistica(0).aceptados
                                            _Informado = _RespuestSII.estadistica(0).informados
                                            _Rechazado = _RespuestSII.estadistica(0).rechazados
                                            _Reparo = _RespuestSII.estadistica(0).reparos
                                        Catch ex As Exception
                                            _Aceptado = False
                                            _Informado = False
                                            _Rechazado = False
                                            _Reparo = False
                                        End Try

                                        If CBool(_Rechazado) Or CBool(_Reparo) Then
                                            _Estado = _RespuestSII.detalle_rep_rech(0).estado
                                            _Glosa = _RespuestSII.detalle_rep_rech(0).descripcion
                                        Else
                                            _Glosa = Fx_GlosaEstados(_Estado, _Aceptado, _Rechazado, _VolverProcesar)
                                        End If

                                        If _Estado = "EPR" And CBool(_Rechazado) Then
                                            _Glosa += " (Revise el SII, puede que el documento este aceptado con otro Trackid)"
                                        End If

                                    End If

                                    If _VolverProcesar And _Intentos <= 3 Then
                                        _Procesado = 0
                                        _Procesar = 1
                                    End If

                                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set " & vbCrLf &
                                                   "Procesado = " & _Procesado & "," &
                                                   "Procesar = " & _Procesar & "," &
                                                   "Informado = " & _Informado & "," &
                                                   "Aceptado = " & _Aceptado & "," &
                                                   "Rechazado = " & _Rechazado & "," &
                                                   "Reparo = " & _Reparo & "," &
                                                   "EnviarMail = 0," &
                                                   "Estado = '" & _Estado & "'," &
                                                   "Glosa = '" & _Glosa & "'," &
                                                   "Respuesta = '" & _Respuesta & "'," & vbCrLf &
                                                   "Intentos = " & _Intentos & vbCrLf &
                                                   "Where Id = " & _Id_Trackid
                                    If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                                        Throw New System.Exception(_Sql.Pro_Error)
                                    End If

                                End If

                                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DTE_Trackid Where Id = " & _Id_Trackid
                                Dim _RowTrackid As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

                                If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                                    Throw New System.Exception(_Sql.Pro_Error)
                                End If

                                _Estado = _RowTrackid.Item("Estado")
                                _Glosa = _RowTrackid.Item("Glosa")
                                _Respuesta = _RowTrackid.Item("Respuesta")

                                Sb_AddToLog("Revisar Trackid", "Respuesta SII: " & _Respuesta, Txt_Log)
                                Sb_AddToLog("Revisar Trackid", "Respuesta Estado: " & _Estado & ", Glosa: " & _Glosa, Txt_Log)

                            Next

                        Else

                            If _HefRespuesta.XmlDocumento = "No existe recurso" Then

                                Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Procesar = 1 Where Id_Dte = " & _Id_Dte
                                If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                                    Throw New System.Exception(_Sql.Pro_Error)
                                End If

                            End If

                        End If

                    End If

                Next

                Sb_AddToLog("Revisar Trackid", "Fin revisión", Txt_Log)

            End If

        Catch ex As Exception
            Sb_AddToLog("Enviar SII", ex.Message, Txt_Log)
        End Try

    End Sub

    Sub Sb_Enviar_Correos()

        Try

            Consulta_sql = "Select Id,Id_Dte,Idmaeedo,Trackid,Informado,Aceptado,Rechazado,Reparo,Estado,Glosa,Respuesta,FechaEnvSII," &
                   "AmbienteCertificacion,MailToDiablito, ErrorMailToDiablito" & vbCrLf &
                   "From " & _Global_BaseBk & "Zw_DTE_Trackid" & vbCrLf &
                   "Where Procesar = 0 " &
                   "And Procesado = 1 " &
                   "And EnviarMail = 1 " &
                   "And AmbienteCertificacion = " & _AmbienteCertificacion

            Dim _Tbl_DTE_Trackid As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            If Not CBool(_Tbl_DTE_Trackid.Rows.Count) Then
                Return
            End If

            'Dim _ListaDteTrackId As New List(Of String)

            If CBool(_Tbl_DTE_Trackid.Rows.Count) Then

                Dim _Filtro_Id_Trackid As String = Generar_Filtro_IN(_Tbl_DTE_Trackid, "", "Id", False, False, "")

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set MailToDiablito = 1,ErrorMailToDiablito = 0,EnviarMail = 0,MailEnviado = 0" & vbCrLf &
                               "Where Id In " & _Filtro_Id_Trackid
                If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                    Throw New System.Exception(_Sql.Pro_Error)
                End If

                Sb_AddToLog("Enviar Correo", "Preparando envio de correos", Txt_Log)

                For Each _Fila As DataRow In _Tbl_DTE_Trackid.Rows

                    Dim _Id_Dte = _Fila.Item("Id_Dte")
                    Dim _Id_Trackid = _Fila.Item("Id")
                    Dim _Trackid = _Fila.Item("Trackid")
                    Dim _Idmaeedo = _Fila.Item("Idmaeedo")

                    If Fx_Esta_Firmando(_Filtro_Id_Trackid, _Id_Trackid) Then
                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set MailToDiablito = 0,EnviarMail = 1" & vbCrLf &
                               "Where Id In " & _Filtro_Id_Trackid
                        If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                            Throw New System.Exception(_Sql.Pro_Error)
                        End If
                        Exit For
                    End If

                    Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo)
                    _Class_DTE.AmbienteCertificacion = Convert.ToInt32(Chk_AmbienteCertificacion.Checked)

                    If IsNothing(_Class_DTE.Maeedo) Then
                        Sb_AddToLog("Enviar Correo", "Problemas al enviar correo, no se reconoce el IDMAEEDO: " & _Idmaeedo, Txt_Log)
                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set ErrorMailToDiablito = 1" & vbCrLf &
                                       "Where Id = " & _Id_Trackid
                        If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                            Throw New System.Exception(_Sql.Pro_Error)
                        End If
                    End If

                    If Not IsNothing(_Class_DTE.Maeedo) Then

                        Dim _Koen = _Class_DTE.Maeedo.Rows(0).Item("ENDO").ToString.Trim
                        Dim _Suen = _Class_DTE.Maeedo.Rows(0).Item("SUENDO").ToString.Trim
                        Dim _Para = _Class_DTE.Maeen.Rows(0).Item("EMAIL").ToString.Trim

                        If CBool(_AmbienteCertificacion) Then
                            _Para = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor",
                                                      "Empresa = '" & ModEmpresa & "' And Campo = 'MailContactoSIIPruebas' And AmbienteCertificacion = " & _AmbienteCertificacion)
                        End If

                        Dim _EnvioCorreo As String = _Class_DTE.Fx_Enviar_Notificacion_Correo_Al_Diablito(_Idmaeedo, _Para, "", _Id_Trackid)

                        If String.IsNullOrEmpty(_EnvioCorreo) Then
                            Sb_AddToLog("Enviar Correo", "Se deja en la bandeja de salida correo para: " & _Para, Txt_Log)
                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set MailToDiablito = 1" & vbCrLf &
                                           "Where Id = " & _Id_Trackid
                            If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                                Throw New System.Exception(_Sql.Pro_Error)
                            End If
                        Else
                            Sb_AddToLog("Enviar Correo", "Problemas al enviar correo, problema: " & _EnvioCorreo, Txt_Log)
                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set ErrorMailToDiablito = 1" & vbCrLf &
                                            "Where Id = " & _Id_Trackid
                            If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                                Throw New System.Exception(_Sql.Pro_Error)
                            End If
                            Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "Zw_DTE_Trackid", _Id_Trackid, "Email_DTE_Error", _EnvioCorreo, "", "", _Koen, _Suen, False, "")
                        End If

                    End If

                Next

                Sb_AddToLog("Enviar Correo", "Fin envio de correos", Txt_Log)

            End If

        Catch ex As Exception
            Sb_AddToLog("Enviar SII", ex.Message, Txt_Log)
        End Try

    End Sub

    Sub Sb_Enviar_Cesion()

        Try

            Consulta_sql = "Select Top 5 Id_Aec,Id_Dte,Idmaeedo,Tido,Nudo" & vbCrLf &
                   "From " & _Global_BaseBk & "Zw_DTE_Aec" & vbCrLf &
                   "Where Procesar = 1 And AmbienteCertificacion = " & _AmbienteCertificacion
            Dim _Tbl_DTE_Aec As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            If Not CBool(_Tbl_DTE_Aec.Rows.Count) Then
                Return
            End If

            For Each _Fila As DataRow In _Tbl_DTE_Aec.Rows

                Dim _Id_Aec = _Fila.Item("Id_Aec")
                Dim _Idmaeedo = _Fila.Item("Idmaeedo")
                Dim _Tido = _Fila.Item("Tido")
                Dim _Nudo = _Fila.Item("Nudo")

                Sb_AddToLog("Revisar Trackid", "Enviando a Cesion " & _Tido & "-" & _Nudo, Txt_Log)

                Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo)

                Dim _Fx_AEC_EnviarCesion As HefestoCesionV12.HefRespuesta
                _Fx_AEC_EnviarCesion = _Class_DTE.Fx_AEC_EnviarCesion(_Id_Aec)

                If _Fx_AEC_EnviarCesion.EsCorrecto Then
                    Sb_AddToLog("Enviar SII", _Tido & "-" & _Nudo & ", Enviado Trackid: " & _Fx_AEC_EnviarCesion.Trackid, Txt_Log)
                    Sb_AddToLog("Enviar SII", _Tido & "-" & _Nudo & ", Respuesta: " & _Fx_AEC_EnviarCesion.Resultado, Txt_Log)
                    Sb_AddToLog("Enviar SII", _Tido & "-" & _Nudo & ", Declaración jurada: ", Txt_Log)
                    Sb_AddToLog("Enviar SII", _Fx_AEC_EnviarCesion.Detalle, Txt_Log)
                Else
                    Sb_AddToLog("Enviar SII", _Tido & "-" & _Nudo & ", Error al enviar cesion: " & _Fx_AEC_EnviarCesion.Detalle, Txt_Log)
                End If

            Next

        Catch ex As Exception
            Sb_AddToLog("Enviar SII", ex.Message, Txt_Log)
        End Try

    End Sub


    Sub Sb_Revisar_Acuse_Recibo_Al_SIIDTE_Bk()

        Dim _FechaHoy As String = Format(FechaDelServidor, "yyyyMMdd")
        Dim _FechaPrimerDiaMes As String = Format(Primerdiadelmes(FechaDelServidor), "yyyyMMdd")
        Dim _8Dias As DateTime = DateAdd(DateInterval.Day, -9, FechaDelServidor)
        Dim _Fecha8Dias As String = Format(_8Dias, "yyyyMMdd")

        Consulta_sql = "Select DteDoc.Id_Dte,DteTk.Id As Id_Trackid,DteDoc.Idmaeedo,Tido,Nudo," &
                       "DteTk.Trackid,FechaSolicitud,DteDoc.AmbienteCertificacion,DteDoc.Procesar,DteDoc.Procesado,DteTk.Estado,DteTk.Glosa" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_DTE_Documentos DteDoc" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_DTE_Trackid DteTk On DteDoc.Id_Dte = DteTk.Id_Dte" & vbCrLf &
                       "Where DteDoc.Procesado = 1 And DteDoc.AmbienteCertificacion = 0 And Tido In ('FCV','NCV') And (DteTk.Aceptado = 1 or DteTk.Reparo = 1)" & vbCrLf &
                       "And DteTk.FechaEnvSII > '" & _Fecha8Dias & "' And DteTk.FechaEnvSII < '" & _FechaHoy & "'" & vbCrLf &
                       "Order By DteDoc.Id_Dte Desc"

        Dim _Tbl_DTE_Documentos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If Not CBool(_Tbl_DTE_Documentos.Rows.Count) Then
            Return
        End If

        If CBool(_Tbl_DTE_Documentos.Rows.Count) Then

            Sb_AddToLog("Revisión DTE en SII", "Revisando historial de documentos en el SII", Txt_Log)

            Dim _Filtro_Id_Dte As String = Generar_Filtro_IN(_Tbl_DTE_Documentos, "", "Id_Dte", False, False, "")

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Procesar = 0 Where Id_Dte In " & _Filtro_Id_Dte
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

            For Each _Fila As DataRow In _Tbl_DTE_Documentos.Rows

                Dim _Idmaeedo = _Fila.Item("Idmaeedo")
                Dim _Id_Dte = _Fila.Item("Id_Dte")
                Dim _Id_Trackid = _Fila.Item("Id_Trackid")
                Dim _Tido = _Fila.Item("Tido")
                Dim _Nudo = _Fila.Item("Nudo")

                If Fx_Esta_Firmando(_Filtro_Id_Dte, _Id_Dte) Then
                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set Procesar = 1" & vbCrLf &
                                   "Where Id In " & _Filtro_Id_Dte
                    _Sql.Ej_consulta_IDU(Consulta_sql, False)
                    Exit For
                End If

                Sb_AddToLog("Revisión DTE en SII", "Revisando " & _Tido & "-" & _Nudo, Txt_Log)

                Dim _AmbienteCertificacion As Boolean = Chk_AmbienteCertificacion.Checked
                'Dim _Acuse As Respuesta = HefAcuseReciboFactura.ConsultarVersion(_Cn)

                Dim _TipoDte As String = Fx_Tipo_DTE_VS_TIDO(_Tido)
                Dim _FolioDte As String = CInt(_Nudo)

                Dim _Cl_AcuseReciboFactura As New Cl_AcuseReciboFactura

                Dim _Historial As New Eventos_Dte.Ls_HistorialDocumentoDte

                _Historial = _Cl_AcuseReciboFactura.Fx_RevisarHistorialDocumento(_Cn, _RutEmisor, _TipoDte, _FolioDte, 1)

                If _Historial.EsCorrecto Then

                    Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_DTE_Trackid Where Id_Dte = " & _Id_Dte & "Order By Id Desc"
                    Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

                    If Not IsNothing(_Row) Then
                        Dim _Trackid As String = _Row.Item("Trackid")
                        Sb_AddToLog("Enviar SII", _Tido & "-" & _Nudo & ", Enviado Trackid: " & _Trackid, Txt_Log)
                    Else
                        Dim _Error = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Documentos", "Respuesta", "Id_Dte = " & _Id_Dte)
                        Sb_AddToLog("Enviar SII", _Tido & "-" & _Nudo & ", Error: " & _Error, Txt_Log)
                    End If

                Else

                    'Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Respuesta = Respuesta + '" & _Enviar_DTE.mensaje & "'" & vbCrLf &
                    '               "Where Id_Dte In " & _Filtro_Id_Dte
                    '_Sql.Ej_consulta_IDU(Consulta_sql, False)

                    'If _Enviar_DTE.mensaje.ToString.Contains("No fue posible encontrar la Caratula") Then
                    '    Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Procesar = 0, Procesado = 1" & vbCrLf &
                    '                   "Where Id_Dte In " & _Filtro_Id_Dte
                    '    _Sql.Ej_consulta_IDU(Consulta_sql, False)
                    'End If

                    'Sb_AddToLog("Enviar SII", _Enviar_DTE.mensaje, Txt_Log)

                End If


            Next

            Sb_AddToLog("Enviar SII", "Fin proceso", Txt_Log)

        End If

    End Sub

    Private Function Fx_Esta_Firmando(ByRef _Filtro_Id_Trackid As String, _Id_Trackid As Integer) As Boolean

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_DTE_Firmar",
                                            "Firmar = 1 And AmbienteCertificacion = " & Convert.ToInt32(Chk_AmbienteCertificacion.Checked))

        If Not CBool(_Reg) Then

            If _Filtro_Id_Trackid.Contains("," & _Id_Trackid) Then
                _Filtro_Id_Trackid = Replace(_Filtro_Id_Trackid, "," & _Id_Trackid, "")
            Else
                _Filtro_Id_Trackid = Replace(_Filtro_Id_Trackid, _Id_Trackid & ",", "")
            End If

        End If

        Return CBool(_Reg)

    End Function

    Private Sub Timer_Enviar_SII_Tick(sender As Object, e As EventArgs) Handles Timer_Enviar_SII.Tick

        Timer_Segundos.Stop()
        Timer_Enviar_SII.Stop()
        Timer_Consultar_TrackId.Stop()
        Lbl_Estatus.Text = "Enviar documentos al SII..."

        'Buscar documentos pendientes de ser enviados al SII

        If Chk_EnviarDTE.Checked Then

            Sb_Enviar_Documentos_Al_SIIDTE_Bk()
            Sb_Enviar_Documentos_Al_SIIBoletas_Bk()
            Sb_Enviar_Cesion()

            'Sb_Enviar_Documentos_Al_SIIEnviaDTESIIBk()
            'Sb_Enviar_Documentos_Al_SIIBoletas()

        Else
            Sb_AddToLog("Enviar SII", "Proceso pausado...", Txt_Log)
        End If

        _Segundos = 30

        Timer_Consultar_TrackId.Start()
        If Me.WindowState <> FormWindowState.Minimized Then Timer_Segundos.Start()

    End Sub

    Private Sub Timer_Consultar_TrackId_Tick(sender As Object, e As EventArgs) Handles Timer_Consultar_TrackId.Tick

        Timer_Segundos.Stop()
        Timer_Enviar_SII.Stop()
        Timer_Consultar_TrackId.Stop()
        Lbl_Estatus.Text = "Consultar Trackid..."

        If Chk_ConsultarTrackid.Checked Then

            Sb_Revisar_Trackid_DTEBk()
            Sb_Revisar_Trackid_SIIBoletas_Bk()

            If _RevisarReclamoDTE Then

                Sb_Revisar_Reclamos()
                Timer_RevisarReclamoDTE.Interval = (1000 * 60) * 30
                _RevisarReclamoDTE = False
                Timer_RevisarReclamoDTE.Start()

            End If

        Else
            Sb_AddToLog("Revisar Trackid", "Proceso pausado...", Txt_Log)
        End If

        _Segundos = 30

        Timer_Enviar_Correos.Start()
        If Me.WindowState <> FormWindowState.Minimized Then Timer_Segundos.Start()

    End Sub

    Private Sub Timer_Enviar_Correos_Tick(sender As Object, e As EventArgs) Handles Timer_Enviar_Correos.Tick

        Timer_Segundos.Stop()
        Timer_Enviar_Correos.Stop()
        Timer_Enviar_SII.Stop()
        Timer_Consultar_TrackId.Stop()
        Lbl_Estatus.Text = "Enviar Correos..."

        If Chk_EnviarCorreos.Checked Then
            Sb_Enviar_Correos()
        Else
            Sb_AddToLog("Enviar Correo", "Proceso pausado...", Txt_Log)
        End If

        _Segundos = 15

        Timer_Enviar_SII.Start()
        If Me.WindowState <> FormWindowState.Minimized Then Timer_Segundos.Start()

    End Sub

    Private Sub Frm_Demonio_DTEMonitor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If Not _RevisarCertificado Then

            Dim _Validar As Boolean

            Dim Fm As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Pick0011", True, False)
            Fm.Pro_Cerrar_Automaticamente = True
            Fm.ShowDialog(Me)
            _Validar = Fm.Pro_Permiso_Aceptado
            Fm.Dispose()

            If Not _Validar Then
                e.Cancel = True
            End If

        End If

    End Sub

    Private Sub Timer_Segundos_Tick(sender As Object, e As EventArgs) Handles Timer_Segundos.Tick

        If _RevisarCertificado Then

            Timer_Segundos.Stop()
            If Not Fx_Revisar_Certificado_y_Archivos_Hefesto() Then
                Me.Close()
            End If

            bgWorker.RunWorkerAsync()
            _RevisarCertificado = False
            Timer_Segundos.Start()

        End If

        _Segundos -= 1
        _Segundos_Esperando += 1

        'Sb_Firmar()

        If Timer_Enviar_Correos.Enabled Then _ProxProceso = "Enviar Correos"
        If Timer_Enviar_SII.Enabled Then _ProxProceso = "Enviar Documentos al SII"
        If Timer_Consultar_TrackId.Enabled Then _ProxProceso = "Consulta Trackid"

        Lbl_Estatus.Text = _VersionBakappExe & " tiempo que resta para el siguiente proceso (" & _Segundos & "): " & _ProxProceso
        Me.Refresh()

        If _Segundos_Esperando >= 10 Then
            _Contador_Esperando += 1
            Sb_AddToLog("BakApp DTEMonitor", "Esperando..." & "(" & _Contador_Esperando & ")", Txt_Log)
            _Segundos_Esperando = 0
        End If

    End Sub

    Function Fx_Revisar_Certificado_y_Archivos_Hefesto() As Boolean

        Dim _AppPath = AppPath()

        Try

            Dim _Cn As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor", "Empresa = '" & ModEmpresa & "' And Campo = 'Cn'")
            Dim _Certificado As Security.Cryptography.X509Certificates.X509Certificate2 = FuncionesComunes.RecuperarCertificado(_Cn)

            If IsNothing(_Certificado) Then
                Throw New System.Exception("Falta instalar el certificado digital en este equipo" & vbCrLf & "Cetificado: " & _Cn)
            End If

            If Not File.Exists(AppPath() & "\Dte.zip") Then
                Throw New System.Exception("Falta el archivo " & AppPath() & "\Dte.zip")
            Else

                If Not Directory.Exists(_AppPath & "\Data\Dte") Then
                    System.IO.Directory.CreateDirectory(_AppPath & "\Data\Dte")
                End If

                If Not Directory.Exists(_AppPath & "\DocumentosSII") Then
                    System.IO.Directory.CreateDirectory(_AppPath & "\DocumentosSII")
                End If

                If Not Directory.Exists(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE") Then
                    System.IO.Directory.CreateDirectory(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE")
                End If

                If Not Directory.Exists(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Documentos") Then
                    System.IO.Directory.CreateDirectory(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Documentos")
                End If

                Dim _Fullpath = _AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Documentos"

                If Not Directory.Exists(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto") Then
                    System.IO.Directory.CreateDirectory(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto")
                End If

                If Not Directory.Exists(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\CAF") Then
                    System.IO.Directory.CreateDirectory(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\CAF")
                End If

                'Try

                'Using Zip As ZipFile = ZipFile.Read(_AppPath & "\Dte.zip")
                '    Zip.ExtractAll(AppPath(), ExtractExistingFileAction.OverwriteSilently)
                'End Using

                ' Por este bloque usando System.IO.Compression.ZipFile:
                Dim zipPath As String = _AppPath & "\Dte.zip"
                Dim extractPath As String = AppPath()
                If File.Exists(zipPath) Then
                    ZipFile.ExtractToDirectory(zipPath, extractPath)
                End If



                'RarArchive.WriteToDirectory(_AppPath & "\Dte.Rar", AppPath() & "\Dte", ExtractOptions.Overwrite)

                'Copiamos la carpeta DocumentosSII en la raiz del sistema
                My.Computer.FileSystem.CopyDirectory(AppPath() & "\Dtes\DocumentosSII", _AppPath & "\DocumentosSII", True)
                'Copiamos la carpeta Dte dentro de la carpeta Data
                My.Computer.FileSystem.CopyDirectory(AppPath() & "\Dtes\Dte", _AppPath & "\Data\Dte", True)
                'Copiamos la carpeta Documentos dentro de la carpete DTE de la empresa
                My.Computer.FileSystem.CopyDirectory(AppPath() & "\Dtes\Documentos", _AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Documentos", True)

                My.Computer.FileSystem.DeleteDirectory(AppPath() & "\Dtes", FileIO.DeleteDirectoryOption.DeleteAllContents)
                'Catch ex As Exception
                '    CircularPgrs.Visible = False
                '    MessageBoxEx.Show(Me, ex.Message, "Error al extraer archivos desde: " & _AppPath & "\Dte.zip", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '    Return False
                'End Try

            End If

        Catch ex As Exception
            CircularPgrs.Visible = False
            MessageBoxEx.Show(Me, ex.Message & vbCrLf & vbCrLf &
                              "INFORME ESTA SITUACION AL ADMINISTRADOR DEL SISTEMA POR FAVOR", "Validación DTEMonitor",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End Try

        Return True

    End Function

    Private Sub Frm_Demonio_DTEMonitor_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If WindowState <> FormWindowState.Minimized Then
            '_Contador_Esperando = 0
            _Segundos_Esperando = 0
            Timer_Segundos.Start()
        End If
    End Sub

    Private Sub Timer_Minimizar_Tick(sender As Object, e As EventArgs) Handles Timer_Minimizar.Tick
        Me.WindowState = FormWindowState.Minimized
        'Txt_Log.Text = String.Empty
    End Sub

    Private Sub Btn_Limpiar_Click(sender As Object, e As EventArgs) Handles Btn_Limpiar.Click
        _Contador_Esperando = 0
        _Segundos_Esperando = 0
        Txt_Log.Text = String.Empty
    End Sub

    Private Sub MyWorker_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs)
        'Add your codes here for the worker to execute

        If Not Chk_FirmarDocumentos.Checked Then
            Return
        End If

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_DTE_Firmar" & vbCrLf &
                       "Where Firmar = 1 And AmbienteCertificacion = " & _AmbienteCertificacion
        Dim _RowFirmar As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

        If Not IsNothing(_RowFirmar) Then

            Dim _Id As Integer = _RowFirmar.Item("Id")
            Dim _Idmaeedo As Integer = _RowFirmar.Item("Idmaeedo")
            Dim _Tido As String = _RowFirmar.Item("Tido")
            Dim _Nudo As String = _RowFirmar.Item("Nudo")

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Firmar Set Firmar = 0 Where Id = " & _Id
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

            Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo)
            _Class_DTE.AmbienteCertificacion = Convert.ToInt32(Chk_AmbienteCertificacion.Checked)

            'FIRMAR DOCUMENTO
            Dim _Id_Dte As Integer = _Class_DTE.Fx_Timbrar_Documento_Hefesto(Me)

            If CBool(_Id_Dte) Then
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Firmar Set Id_Dte = " & _Id_Dte & " Where Id = " & _Id
                _Sql.Ej_consulta_IDU(Consulta_sql, False)
            Else
                If CBool(_Class_DTE.Pro_Errores.Count) Then
                    Dim Log_Error As String
                    For Each _Error As String In _Class_DTE.Pro_Errores
                        Log_Error += _Error & vbCrLf
                    Next
                    Log_Error = Replace(Log_Error, "'", "''")
                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Firmar Set Log_Error = '" & Log_Error & "' Where Id = " & _Id
                    _Sql.Ej_consulta_IDU(Consulta_sql, False)
                End If
            End If

        End If

    End Sub

    Private Sub MyWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
        'Add your codes for the worker to execute after finishing the work.
        bgWorker.RunWorkerAsync()
    End Sub

    Function Fx_Enviar_DTE_Al_SII(_Id_Dte As Integer, _AmbienteCertificacion As Boolean) As Hefesto.DTE.AUTENTICACION.ENT.Respuesta

        Dim _Respuesta As New Hefesto.DTE.AUTENTICACION.ENT.Respuesta

        Try

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

                Dim _Ambiente As Hefesto.DTE.AUTENTICACION.SIIAmbiente

                If _AmbienteCertificacion Then
                    _Ambiente = Hefesto.DTE.AUTENTICACION.SIIAmbiente.Certificacion
                Else
                    _Ambiente = Hefesto.DTE.AUTENTICACION.SIIAmbiente.Produccion
                End If

                _Respuesta = Hefesto.DTE.AUTENTICACION.LOGIN.Conectar(_Cn, _Ambiente)

                If _Respuesta.correcto Then

                    Dim _paramToken As String = _Respuesta.Resultado
                    Dim _paramArchivo As String = _Dir
                    Dim _paramRutEmisorB As String = _cmpRutEmisor.Split("-"c)(0)
                    Dim _paramRutEmisorD As String = _cmpRutEmisor.Split("-"c)(1)
                    Dim _paramRutEnviaB As String = _cmpRutEnvia.Split("-"c)(0)
                    Dim _paramRutEnviaD As String = _cmpRutEnvia.Split("-"c)(1)

                    Dim _respuestaEnvio As Hefesto.DTE.AUTENTICACION.ENT.Respuesta =
                                    Hefesto.DTE.AUTENTICACION.ENVIO.EnviarArchivoSII(_paramArchivo,
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

                    Dim _Trackid = _Respuesta.Resultado

                    If IsNumeric(_Trackid) Then

                        Dim _Id_Trackid As Integer

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_DTE_Trackid (Id_Dte,Idmaeedo,Trackid,FechaEnvSII,Procesar,AmbienteCertificacion) Values " & vbCrLf &
                               "(" & _Id_Dte & "," & _Idmaeedo & ",'" & _Trackid & "',Getdate(),1," & Convert.ToInt32(_AmbienteCertificacion) & ")"
                        _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Trackid, False)

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Procesado = 1 Where Id_Dte =  " & _Id_Dte
                        _Sql.Ej_consulta_IDU(Consulta_sql, False)

                    Else

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Respuesta = '" & _Trackid & "' Where Id_Dte = " & _Id_Dte
                        _Sql.Ej_consulta_IDU(Consulta_sql, False)

                    End If

                Else

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Respuesta = '" & _Respuesta.mensaje & " - " & _Respuesta.detalle.Trim & "' Where Id_Dte = " & _Id_Dte
                    _Sql.Ej_consulta_IDU(Consulta_sql, False)

                End If

                If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                    MensajeError += _Sql.Pro_Error & vbCrLf
                    Throw New System.Exception(MensajeError)
                End If

            End If

        Catch ex As Exception
            _Respuesta.correcto = False
            _Respuesta.mensaje = ex.Message
            _Respuesta.detalle = String.Empty
        End Try

        Return _Respuesta

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


    Function Fx_Enviar_Boleta_SII(_Id_Dte As Integer,
                                  _AmbienteCertificacion As Boolean,
                                  _RutEmpresaActiva As String) As HEFSIILIBDTES.HefRespuesta

        Consulta_sql = "Select Id,Empresa,Campo,Valor,FechaMod,TipoCampo,TipoConfiguracion" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_DTE_Configuracion" & vbCrLf &
                       "Where Empresa = '" & ModEmpresa & "' And TipoConfiguracion = 'ConfEmpresa'"
        Dim _Tbl_ConfEmpresa As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If Not CBool(_Tbl_ConfEmpresa.Rows.Count) Then
            'MessageBoxEx.Show(Me, "Faltan los datos de configuración DTE para la empresa", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return Nothing
        End If

        'Dim _Path As String = AppPath() & "\Data\Dte"


        Dim _HefRespuesta As New HEFSIILIBDTES.HefRespuesta
        Dim _HefPublicador As New HefPublicador

        'Dim _xsd_path As String = _AppPath & "\Dtes\Dte\Schemas\BOLETAS\EnvioBOLETA_v11.xsd"
        Dim _RutEmisor As String
        Dim _Rutenvia As String
        Dim _FchResol As String
        Dim _NroResol As Integer
        Dim _Cn As String

        For Each _Fila As DataRow In _Tbl_ConfEmpresa.Rows

            Dim _Campo As String = _Fila.Item("Campo").ToString.Trim

            If _Campo = "RutEmisor" Then _RutEmisor = _Fila.Item("Valor")
            If _Campo = "RutEnvia" Then _Rutenvia = _Fila.Item("Valor")
            If _Campo = "FchResol" Then _FchResol = _Fila.Item("Valor")
            If _Campo = "NroResol" Then _NroResol = _Fila.Item("Valor")
            If _Campo = "Cn" Then _Cn = _Fila.Item("Valor")

        Next

        If _AmbienteCertificacion Then
            _NroResol = 0
        End If

        Dim _Certificado As Security.Cryptography.X509Certificates.X509Certificate2 = HEFSIILIBDTES.FUNCIONES.HefCertificados.RecuperarCertificado(_Cn)

        If IsNothing(_Certificado) Then
            _HefRespuesta.EsCorrecto = False
            _HefRespuesta.Mensaje = "No se encontró el certificado electrónico"
            _HefRespuesta.Detalle = "Nombre del certificado: " & _Cn
            _HefRespuesta.Proceso = "Línea 296"
            Return _HefRespuesta
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DTE_Documentos Where Id_Dte = " & _Id_Dte
        Dim _Zw_DTE_Documentos As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
            _HefRespuesta.EsCorrecto = False
            _HefRespuesta.Mensaje = _Sql.Pro_Error
            _HefRespuesta.Detalle = Consulta_sql
            _HefRespuesta.Proceso = "Línea 306"
            Return _HefRespuesta
        End If

        If IsNothing(_Zw_DTE_Documentos) Then
            _HefRespuesta.EsCorrecto = False
            _HefRespuesta.Mensaje = "No se encontro el registro con el Id_Dte: " & _Id_Dte
            _HefRespuesta.Detalle = Consulta_sql
            _HefRespuesta.Proceso = "Línea 306"
            Return _HefRespuesta
        End If

        Dim _Idmaeedo As Integer = _Zw_DTE_Documentos.Item("Idmaeedo")
        Dim _Xml As String = _Zw_DTE_Documentos.Item("CaratulaXml")

        Dim _AppPath As String = AppPath()
        Dim _xsd_path As String = _AppPath & "\Data\Dte\Schemas\BOLETAS\EnvioBOLETA_v11.xsd"

        Dim _Ruta = _AppPath & "\Data\DTE\Documentos\Boleta\"
        _Ruta = _AppPath & "\Data\Dtes\Documentos\Boleta\"

        If Not Directory.Exists(_Ruta) Then
            System.IO.Directory.CreateDirectory(_Ruta)
        End If

        Dim _CrearArchivo As String = Fx_CrearArchivo(_Ruta, "SET_ENVIO_BOLETA.xml", _Xml)

        If Not String.IsNullOrEmpty(_CrearArchivo) Then
            _HefRespuesta.EsCorrecto = False
            _HefRespuesta.Mensaje = "Problema al crear el archivo, " & _Ruta & "SET_ENVIO_BOLETA.xml"
            _HefRespuesta.Detalle = _CrearArchivo
            _HefRespuesta.Proceso = "Línea 338"
            Return _HefRespuesta
        End If

        Dim _mis_boletas As List(Of String) = New List(Of String)()
        Dim path_boleta As String = _Ruta & "\SET_ENVIO_BOLETA.xml"

        Dim content As String = File.ReadAllText(path_boleta, Encoding.GetEncoding("ISO-8859-1"))
        _mis_boletas.Add(content)

        _HefRespuesta = _HefPublicador.PublicadoBoletasPorLotes3(_RutEmisor,
                                                                 _Rutenvia,
                                                                 _FchResol,
                                                                 _NroResol,
                                                                 _Certificado,
                                                                 _mis_boletas,
                                                                 _xsd_path)

        Dim _EsCorrecto = _HefRespuesta.EsCorrecto
        Dim _FchProceso = _HefRespuesta.FchProceso
        Dim _Mensaje = _HefRespuesta.Mensaje
        Dim _Proceso = _HefRespuesta.Proceso
        Dim _Resultado = _HefRespuesta.Resultado
        Dim _Trackid As String
        Dim _XmlDocumento As String

        If _HefRespuesta.EsCorrecto Then

            _Trackid = _HefRespuesta.Trackid.ToString.Trim
            _XmlDocumento = _HefRespuesta.XmlDocumento

            Dim _Id_Trackid As Integer

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_DTE_Trackid (Id_Dte,Idmaeedo,Trackid,FechaEnvSII,Procesar,AmbienteCertificacion) Values " & vbCrLf &
                           "(" & _Id_Dte & "," & _Idmaeedo & ",'" & _Trackid & "',Getdate(),1," & Convert.ToInt32(_AmbienteCertificacion) & ")"
            _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Trackid, False)

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Procesado = 1,Procesar = 0 Where Id_Dte =  " & _Id_Dte
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Else

            Dim _Detalle As String

            Try
                _Detalle = _HefRespuesta.Detalle
            Catch ex As Exception
                _Detalle = String.Empty
            End Try

            _Detalle = Replace(_Detalle, "'", "''")

            If _Detalle.Contains("Error") And _Detalle <> "No fue posible enviar el documento: Error en el servidor remoto: (401) No autorizado." Then
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Procesado = 1,Procesar = 0,Respuesta = '" & _Detalle & "',ErrorEnvioDTE = 1" & vbCrLf &
                               "Where Id_Dte =  " & _Id_Dte
            Else
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Procesado = 0,Procesar = 1,Respuesta = '" & _Detalle & "'" & vbCrLf &
               "Where Id_Dte =  " & _Id_Dte
            End If

            _Sql.Ej_consulta_IDU(Consulta_sql, False)

        End If

        Return _HefRespuesta

    End Function

    Function Fx_CrearArchivo(Ruta As String,
                             NombreArchivo As String,
                             Cuerpo As String) As String
        Try

            Dim _Palo = Microsoft.VisualBasic.Right(Ruta, 1)

            If _Palo <> "\" Then
                Ruta += "\"
            End If

            Dim RutaArchivo As String = Ruta & NombreArchivo

            Dim oSW As New System.IO.StreamWriter(RutaArchivo)

            oSW.WriteLine(Cuerpo)
            oSW.Close()

            'aqui creo el archivo oculto,,, si no se pone este instrucion no pasa nada .. solo es para 
            'asignarles caracteristicas a los archivos 
            'quitalo como comentario y calalo
            'SetAttr(RutaArchivo, vbHidden)
        Catch ex As Exception
            Return ex.Message
        End Try

        Return ""

    End Function

    Function Fx_Consultar_Trackid_BLV(_Trackid As String, _AmbienteCertificacion As Boolean) As HEFSIILIBDTES.HefRespuesta

        Dim HefRespuesta As New HEFSIILIBDTES.HefRespuesta
        Dim HefConsultas As New HefConsultas
        Dim _Ambiente As AmbienteSII

        Consulta_sql = "Select Id,Empresa,Campo,Valor,FechaMod,TipoCampo,TipoConfiguracion" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_DTE_Configuracion" & vbCrLf &
                       "Where Empresa = '" & ModEmpresa & "' And TipoConfiguracion = 'ConfEmpresa'"
        Dim _Tbl_ConfEmpresa As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _RutEmisor As String
        Dim _Cn As String

        For Each _Fila As DataRow In _Tbl_ConfEmpresa.Rows

            Dim _Campo As String = _Fila.Item("Campo").ToString.Trim

            If _Campo = "RutEmisor" Then _RutEmisor = _Fila.Item("Valor")
            If _Campo = "Cn" Then _Cn = _Fila.Item("Valor")

        Next

        If _AmbienteCertificacion Then
            _Ambiente = AmbienteSII.Certificacion
        Else
            _Ambiente = AmbienteSII.Produccion
        End If

        HefRespuesta = HefConsultas.EstadoBolTrackid(_RutEmisor, _Trackid, _Cn, _Ambiente)

        If HefRespuesta.EsCorrecto Then
            If HefRespuesta.XmlDocumento = "No existe recurso" Then
                HefRespuesta.EsCorrecto = False
            End If
        End If

        Return HefRespuesta

    End Function

    Function Fx_ObtenerDatosRespuestaSII(json As String) As RespBolSII
        Try
            Dim Arr As RespBolSII = JsonConvert.DeserializeObject(Of RespBolSII)(json)
            Return Arr
        Catch Ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub Btn_Pruebas_Click(sender As Object, e As EventArgs) Handles Btn_Pruebas.Click


        ''Dim _Cl_SIIRegCV As New Cl_SIIRegCV
        '''_Cl_SIIRegCV.f

        ''Await _Cl_SIIRegCV.RecuperarRegistrosCompras_Certificado(RutEmpresa, pathCert, passCert, periodo)

        ''    MessageBox.Show("¡Fin del proceso!")

        'Return

        Chk_ConsultarTrackid.Checked = False
        Chk_EnviarCorreos.Checked = False
        Chk_EnviarCorreos.Checked = False
        Chk_EnviarDTE.Checked = False
        Chk_FirmarDocumentos.Checked = False

        Dim _FechaHoy As String = Format(FechaDelServidor, "yyyyMMdd")
        Dim _8Dias As DateTime = DateAdd(DateInterval.Day, -10, FechaDelServidor)

        Dim _Periodo1 = _8Dias.Year
        Dim _Mes1 = _8Dias.Month
        Dim _Periodo2 = FechaDelServidor.Year
        Dim _Mes2 = FechaDelServidor.Month

        'Dim _DTE_AnoMes As New List(Of DTE_AnoMes.DTE_AnoMes)

        _Periodo1 = "2025"
        _Mes1 = "4"

        Sb_Revisar_Reclamo_DTE(_Periodo1, _Mes1)

        _Mes2 = "5"

        If _Mes1 <> _Mes2 Then
            Sb_Revisar_Reclamo_DTE(_Periodo2, _Mes2)
        End If

        'Dim _Tbl_Registro_Compras_Pendientes As DataTable = Fx_TblFromJson(_Fichero2, "RegistroComprasPendientes")

        'If _Clas_Hefesto_Dte_Libro.Fx_Importar_Archivo_SII_Compras_Desde_Json(_Tbl_Registro_Compras,
        '                                                                      _Tbl_Registro_Compras_Pendientes,
        '                                                                      _Periodo, _Mes) Then
        '    Me.Close()
        'End If

        'Return

        'Dim Fm As New Frm_Pruebas_DTE
        'Fm.ShowDialog(Me)
        'Fm.Dispose()

    End Sub

    Sub Sb_Revisar_Reclamos()

        If Not Chk_RevisarReclamoDTE.Checked Then
            Sb_AddToLog("Rev. Reclamos DTE", "Proceso pausado...", Txt_Log)
            Return
        End If

        Dim _FechaDelServidor As Date = FechaDelServidor(False)

        If _FechaDelServidor = #1/1/0001 12:00:00 AM# Then
            Return
        End If

        Dim _8Dias As DateTime = DateAdd(DateInterval.Day, -10, _FechaDelServidor)

        Dim _Periodo1 = _8Dias.Year
        Dim _Mes1 = _8Dias.Month
        Dim _Periodo2 = _FechaDelServidor.Year
        Dim _Mes2 = FechaDelServidor.Month

        'Sb_Revisar_Reclamo_DTE(_Periodo1, 4)
        'Sb_Revisar_Reclamo_DTE(_Periodo1, 5)
        'Sb_Revisar_Reclamo_DTE(_Periodo1, 6)

        Sb_Revisar_Reclamo_DTE(_Periodo1, _Mes1)

        If _Mes1 <> _Mes2 Then
            Sb_Revisar_Reclamo_DTE(_Periodo2, _Mes2)
        End If

    End Sub

    Sub Sb_Revisar_Reclamo_DTE(_Periodo As String, _Mes As String)

        'Dim _Periodo As String = Now.Year
        'Dim _Mes As String = 1

        Dim _Clas_Hefesto_Dte_Libro As New Clas_Hefesto_Dte_Libro

        Sb_AddToLog("Rev. Reclamos DTE", "Recuperando el registros de ventas desde el SII", Txt_Log)

        Dim _RecuperarVentasRegistro As HefRespuesta
        _RecuperarVentasRegistro = _Clas_Hefesto_Dte_Libro.Fx_RecuperarVentasRegistro(_Periodo, _Mes)

        If _RecuperarVentasRegistro.EsCorrecto Then
            'Sb_AddToLog("Rev. Reclamos DTE", "Es correcto: " & _RecuperarVentasRegistro.EsCorrecto, Txt_Log)
            Sb_AddToLog("Rev. Reclamos DTE", "Mensaje    : " & _RecuperarVentasRegistro.Mensaje, Txt_Log)
            'Sb_AddToLog("Rev. Reclamos DTE", "Detalle    :" & _RecuperarVentasRegistro.Directorio, Txt_Log)
        End If

        Sb_AddToLog("Rev. Reclamos DTE", "Rescatando datos desde archivos Json...", Txt_Log)

        Try

            Dim _Fichero1 As String = File.ReadAllText(_RecuperarVentasRegistro.Directorio)


            '' Suponiendo que tienes un objeto JSON en una cadena llamada jsonString
            'Dim jsonString As String = "{""RegistrosVentas"": []}"

            '' Convertir la cadena JSON en un objeto utilizable en VB.NET
            'Dim jsonObject As JObject = JObject.Parse(_Fichero1)

            '' Verificar si la matriz RegistrosVentas está vacía
            'If jsonObject("RegistrosVentas").Count = 0 Then
            '    Throw New System.Exception("El arreglo RegistrosVentas está vacío para el periodo: " & _Periodo & " Mes: " & MonthName(_Mes))
            'End If


            Dim _Tbl_Registro_Ventas As DataTable '= Fx_TblFromJson(_Fichero1, "RegistrosVentas")

            If File.Exists(_RecuperarVentasRegistro.Directorio) Then
                'Dim _Fichero1 As String = File.ReadAllText(_Dir_ComprasRegistro)
                ' Convierte el contenido JSON de _Fichero1 a un DataSet usando Newtonsoft.Json
                Dim _DataSet As New DataSet()
                _DataSet = JsonConvert.DeserializeObject(Of DataSet)(_Fichero1)
                _Tbl_Registro_Ventas = _DataSet.Tables("RegistroVentas")
            Else
                _Tbl_Registro_Ventas = Nothing
            End If


            Dim filtro As String = "FechaReclamo <> ''"
            Dim filasEncontradas As DataRow() = _Tbl_Registro_Ventas.Select(filtro)

            ' Extraer solo las filas que cumplen con el filtro y dejarlas en una pequeña DataTable
            'Dim filtro As String = "FechaReclamo <> ''"
            'Dim filasEncontradas As DataRow() = _Tbl_Registro_Ventas.Select(filtro)

            ' Crear una nueva DataTable con la misma estructura
            Dim dtFiltrada As DataTable = _Tbl_Registro_Ventas.Clone()

            ' Importar las filas encontradas a la nueva DataTable
            For Each fila As DataRow In filasEncontradas
                dtFiltrada.ImportRow(fila)
            Next

            ' Ahora puedes recorrer dtFiltrada para acceder a los valores filtrados
            For Each fila As DataRow In dtFiltrada.Rows
                Dim _TipoDTE = fila.Item("TipoDoc")
                Dim _Folio = fila.Item("Folio")
                Dim _FechaReclamo = fila.Item("FechaReclamo")

                Fx_Revisar_ListaEventosDoc(_TipoDTE, _Folio)
            Next

            '' Ahora puedes iterar sobre el arreglo de filas encontradas
            'For Each fila As DataRow In filasEncontradas

            '    Dim _TipoDTE = fila.Item("TipoDTE")
            '    Dim _Folio = fila.Item("Folio")
            '    Dim _FechaReclamo = fila.Item("FechaReclamo")

            '    Fx_Revisar_ListaEventosDoc(_TipoDTE, _Folio)

            'Next

        Catch ex As Exception
            Sb_AddToLog("Rev. Reclamos DTE", ex.Message, Txt_Log)
        End Try

    End Sub

    Function Fx_Revisar_ListaEventosDoc(_TipoDoc As Integer, _Folio As Integer)

        Dim _Tido = Fx_Tipo_TIDO_VS_DTE(_TipoDoc)
        Dim _Nudo = numero_(_Folio, 10)

        Consulta_sql = "Select DteDoc.Id_Dte,DteTk.Id As Id_Trackid,DteDoc.Idmaeedo,Tido,Nudo," &
                       "DteTk.Trackid,FechaSolicitud,DteDoc.AmbienteCertificacion,DteDoc.Procesar,DteDoc.Procesado,DteTk.Estado,DteTk.Glosa,DteTk.TieneReclamo" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_DTE_Documentos DteDoc" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_DTE_Trackid DteTk On DteDoc.Id_Dte = DteTk.Id_Dte" & vbCrLf &
                       "Where DteDoc.Tido = '" & _Tido & "' And DteDoc.Nudo = '" & _Nudo & "' -- And DteTk.TieneReclamo = 0" & vbCrLf &
                       "--And DteTk.Id Not In (Select Id_Trackid From " & _Global_BaseBk & "Zw_DTE_ListaEventosDoc Where CodEvento In ('PAG','ACD','ERM'))" & vbCrLf &
                       "Order By DteDoc.Id_Dte Desc"

        Dim _Tbl_DTE_Documentos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If Not CBool(_Tbl_DTE_Documentos.Rows.Count) Then
            Return False
        End If

        If CBool(_Tbl_DTE_Documentos.Rows.Count) Then

            'Sb_AddToLog("Revisión DTE en SII", "Revisando historial de documentos en el SII", Txt_Log)

            For Each _Fila As DataRow In _Tbl_DTE_Documentos.Rows

                Dim _Idmaeedo = _Fila.Item("Idmaeedo")
                Dim _Id_Dte = _Fila.Item("Id_Dte")
                Dim _Id_Trackid = _Fila.Item("Id_Trackid")
                Dim _TieneReclamo As Boolean = _Fila.Item("TieneReclamo")

                Dim _TipoDte As String = Fx_Tipo_DTE_VS_TIDO(_Tido)
                Dim _FolioDte As String = CInt(_Nudo)

                Dim _Cl_AcuseReciboFactura As New Cl_AcuseReciboFactura

                Dim _Historial As New Eventos_Dte.Ls_HistorialDocumentoDte

                _Historial = _Cl_AcuseReciboFactura.Fx_RevisarHistorialDocumento(_Cn, _RutEmisor, _TipoDte, _FolioDte, 1)

                Sb_AddToLog("Revisión DTE en SII", "Revisando " & _Tido & "-" & _Nudo, Txt_Log)

                If _Historial.EsCorrecto Then

                    For Each _Hst As HistorialDocumentoDte In _Historial.Historial

                        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_DTE_ListaEventosDoc",
                                                            "Idmaeedo = " & _Idmaeedo & " And CodEvento = '" & _Hst.CodEvento & "'")

                        If _Reg = 0 Then

                            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_DTE_ListaEventosDoc " &
                                       "(Id_Dte,Id_Trackid,Idmaeedo,Tido,Nudo,CodEvento,DescEvento,RutResponsable,DvResponsable,FechaEvento) Values " & vbCrLf &
                                       "(" & _Id_Dte & "," & _Id_Trackid & "," & _Idmaeedo & ",'" & _Tido & "','" & _Nudo & "'" &
                                       ",'" & _Hst.CodEvento & "'" &
                                       ",'" & _Hst.DescEvento & "'" &
                                       ",'" & _Hst.RutResponsable & "'" &
                                       ",'" & _Hst.DvResponsable & "'" &
                                       ",'" & Format(_Hst.FechaEvento, "yyyyMMdd HH:MM") & "')"
                            _Sql.Ej_consulta_IDU(Consulta_sql, False)

                            If Not _TieneReclamo Then

                                If _Hst.CodEvento = "RCD" Then

                                    _Historial.Mensaje = _Hst.DescEvento

                                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set " &
                                                   "TieneReclamo = 1" &
                                                   ",FechaReclamo = '" & Format(_Hst.FechaEvento, "yyyyMMdd HH:MM") & "'" &
                                                   ",MensajeRegEventosDoc = '" & _Hst.DescEvento & "'" & vbCrLf &
                                                   "Where Id = " & _Id_Trackid
                                    _Sql.Ej_consulta_IDU(Consulta_sql, False)

                                End If

                                Sb_AddToLog("Revisión DTE en SII", "CodEvento: " & _Hst.CodEvento & " - " & _Hst.DescEvento, Txt_Log)

                            End If

                        End If

                    Next

                    If Not _TieneReclamo Then

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set MensajeRegEventosDoc = '" & _Historial.Mensaje & "' Where Id = " & _Id_Trackid
                        _Sql.Ej_consulta_IDU(Consulta_sql, False)

                    End If

                Else

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set MensajeRegEventosDoc = '" & _Historial.Mensaje & "' Where Id = " & _Id_Trackid
                    _Sql.Ej_consulta_IDU(Consulta_sql, False)

                    'Sb_AddToLog("Enviar SII", _Enviar_DTE.mensaje, Txt_Log)

                End If

                Sb_AddToLog("Revisión DTE en SII", "MensajeRegEventosDoc " & _Historial.Mensaje, Txt_Log)
                Sb_AddToLog("Revisión DTE en SII", "..........", Txt_Log)

            Next

            'Sb_AddToLog("Enviar SII", "Fin proceso", Txt_Log)

        End If

        Return True

    End Function

    Private Sub Chk_ConsultarTrackid_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_ConsultarTrackid.CheckedChanged
        Chk_RevisarReclamoDTE.Checked = Chk_ConsultarTrackid.Checked
    End Sub

    Private Sub Timer_RevisarReclamoDTE_Tick(sender As Object, e As EventArgs) Handles Timer_RevisarReclamoDTE.Tick
        Timer_RevisarReclamoDTE.Stop()
        _RevisarReclamoDTE = True
    End Sub
End Class


