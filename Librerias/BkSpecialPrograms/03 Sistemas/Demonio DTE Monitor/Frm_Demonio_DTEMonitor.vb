Imports System.ComponentModel
Imports System.IO
Imports DevComponents.DotNetBar
Imports HEFESTO.FIRMA.DOCUMENTO
Imports Ionic.Zip

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

        Timer_Hora_Actual.Enabled = True
        Timer_Enviar_SII.Start()

        _AmbienteCertificacion = Convert.ToInt32(Chk_AmbienteCertificacion.Checked)

        Chk_MostrarBoletaBkHfDOS.Checked = False
        Chk_MostrarBoletaBkHfDOS.Visible = Chk_AmbienteCertificacion.Checked

        Dim _Dir_Local As String = AppPath() & "\Data\"

        Dim _Ds As New DatosBakApp
        _Ds.Clear()
        _Ds.ReadXml(_Dir_Local & RutEmpresa & "\Configuracion_Local\Nombre_Equipo.xml")

        Dim _Row_Nom_Equipo = _Ds.Tables("Tbl_Nombre_Equipo").Rows(0)
        Dim _Nombre_Equipo = _Global_Row_EstacionBk.Item("NombreEquipo") & " (" & _Global_Row_EstacionBk.Item("Alias") & ")"

        Lbl_Nombre_Equipo.Text = "Nombre equipo: " & _Nombre_Equipo.trim & ", Modalidad: " & Modalidad
        _Contador_Esperando = 1

        Timer_Segundos.Start()

        bgWorker = New BackgroundWorker
        AddHandler bgWorker.DoWork, AddressOf MyWorker_DoWork
        AddHandler bgWorker.RunWorkerCompleted, AddressOf MyWorker_RunWorkerCompleted

    End Sub

    Private Sub Timer_Hora_Actual_Tick(sender As Object, e As EventArgs) Handles Timer_Hora_Actual.Tick
        Me.Text = "Acciones automáticas, Hora actual: " & Date.Now.ToLongTimeString & ". Versión BakApp DTEMonitor: " & _VersionDTEMonitor
    End Sub

    Sub Sb_Enviar_Documentos_Al_SIIEnviaDTESIIBk()

        Dim _FechaHoy As String = Format(FechaDelServidor, "yyyyMMdd")

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Procesar = 1 " & vbCrLf &
                       "Where Procesar = 0 And Idmaeedo Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_DTE_Trackid) And " &
                       "Convert(varchar,FechaSolicitud,112) = '" & _FechaHoy & "' And Tido <> 'BLV' And ErrorEnvioDTE = 0"
        _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Select Top 20 Id_Dte,Idmaeedo,Tido,Nudo,Trackid,FechaSolicitud,Xml,Firma,CaratulaXml,Respuesta,AmbienteCertificacion,Procesar,Procesado" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_DTE_Documentos" & vbCrLf &
                           "Where Procesar = 1 And Procesado = 0 And AmbienteCertificacion = " & _AmbienteCertificacion & " And Tido <> 'BLV'" & vbCrLf &
                           "Order By Tido,Nudo"

            Dim _Tbl_DTE_Documentos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            If Not CBool(_Tbl_DTE_Documentos.Rows.Count) Then
                Return
            End If

            If CBool(_Tbl_DTE_Documentos.Rows.Count) Then

                Sb_AddToLog("Enviar SII", "Revisando documentos pendientes de enviar al SII", Txt_Log)

                Dim _Filtro_Id_Dte As String = Generar_Filtro_IN(_Tbl_DTE_Documentos, "", "Id_Dte", False, False, "")

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Procesar = 0 Where Id_Dte In " & _Filtro_Id_Dte
                _Sql.Ej_consulta_IDU(Consulta_sql, False)

                For Each _Fila As DataRow In _Tbl_DTE_Documentos.Rows

                    Dim _Idmaeedo = _Fila.Item("Idmaeedo")
                    Dim _Id_Dte = _Fila.Item("Id_Dte")
                    Dim _Tido = _Fila.Item("Tido")
                    Dim _Nudo = _Fila.Item("Nudo")

                    If Fx_Esta_Firmando(_Filtro_Id_Dte, _Id_Dte) Then
                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set Procesar = 1" & vbCrLf &
                                       "Where Id In " & _Filtro_Id_Dte
                        _Sql.Ej_consulta_IDU(Consulta_sql, False)
                        Exit For
                    End If

                    Sb_AddToLog("Enviar SII", "Revisando " & _Tido & "-" & _Nudo, Txt_Log)

                    Dim _AmbienteCertificacion As Boolean = Chk_AmbienteCertificacion.Checked
                    Dim _Accion As Enum_Accion = Enum_Accion.EnviarBoletaSII

                    Dim _Cadena_ConexionSQL_Server_Actual As String = Replace(Cadena_ConexionSQL_Server, " ", "@")
                    Dim _Ejecutar As String = Application.StartupPath & "\EnvioDTE\EnviaDTESIIBk.exe" &
                                                                                            Space(1) & ModEmpresa &
                                                                                            Space(1) & _AmbienteCertificacion &
                                                                                            Space(1) & _Id_Dte &
                                                                                            Space(1) & "0" &
                                                                                            Space(1) & _Accion

                    Dim _MostrarShell As AppWinStyle

                    If Chk_MostrarBoletaBkHfDOS.Checked Then
                        _MostrarShell = AppWinStyle.NormalFocus
                    Else
                        _MostrarShell = AppWinStyle.Hide
                    End If

                    Try
                        Shell(_Ejecutar, _MostrarShell, True)

                        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_DTE_Trackid Where Id_Dte = " & _Id_Dte & "Order By Id Desc"
                        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

                        If Not IsNothing(_Row) Then
                            Dim _Trackid As String = _Row.Item("Trackid")
                            Sb_AddToLog("Enviar SII", _Tido & "-" & _Nudo & ", Enviado Trackid: " & _Trackid, Txt_Log)
                        Else
                            Dim _Error = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Documentos", "Respuesta", "Id_Dte = " & _Id_Dte)
                            Sb_AddToLog("Enviar SII", _Tido & "-" & _Nudo & ", Error: " & _Error, Txt_Log)
                        End If

                    Catch ex As Exception
                        Sb_AddToLog("Enviar SII", ex.Message, Txt_Log)
                    End Try

                Next

                Sb_AddToLog("Enviar SII", "Fin proceso", Txt_Log)

            End If

    End Sub

    Sub Sb_Enviar_Documentos_Al_SIIBoletas()

        Dim _FechaHoy As String = Format(FechaDelServidor, "yyyyMMdd")

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Procesar = 1 " & vbCrLf &
                           "Where Procesar = 0 And Idmaeedo Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_DTE_Trackid) And " &
                           "CONVERT(varchar,FechaSolicitud,112) = '" & _FechaHoy & "' And Tido = 'BLV' And ErrorEnvioDTE = 0"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Select Top 20 Id_Dte,Idmaeedo,Tido,Nudo,Trackid,FechaSolicitud,Xml,Firma,CaratulaXml,Respuesta,AmbienteCertificacion,Procesar,Procesado" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_DTE_Documentos" & vbCrLf &
                           "Where Procesar = 1 And Procesado = 0 And AmbienteCertificacion = " & _AmbienteCertificacion & " And Tido = 'BLV'" & vbCrLf &
                           "Order By Tido,Nudo"

        Dim _Tbl_DTE_Documentos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If Not CBool(_Tbl_DTE_Documentos.Rows.Count) Then
            Return
        End If

        If CBool(_Tbl_DTE_Documentos.Rows.Count) Then

            Sb_AddToLog("Enviar SII", "Revisando documentos pendientes de enviar al SII", Txt_Log)

            Dim _Filtro_Id_Dte As String = Generar_Filtro_IN(_Tbl_DTE_Documentos, "", "Id_Dte", False, False, "")

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Procesar = 0 Where Id_Dte In " & _Filtro_Id_Dte
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

            For Each _Fila As DataRow In _Tbl_DTE_Documentos.Rows

                Dim _Idmaeedo = _Fila.Item("Idmaeedo")
                Dim _Id_Dte = _Fila.Item("Id_Dte")
                Dim _Tido = _Fila.Item("Tido")
                Dim _Nudo = _Fila.Item("Nudo")

                If Fx_Esta_Firmando(_Filtro_Id_Dte, _Id_Dte) Then
                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set Procesar = 1" & vbCrLf &
                                       "Where Id In " & _Filtro_Id_Dte
                    _Sql.Ej_consulta_IDU(Consulta_sql, False)
                    Exit For
                End If

                Sb_AddToLog("Enviar SII", "Revisando " & _Tido & "-" & _Nudo, Txt_Log)

                Dim _AmbienteCertificacion As Boolean = Chk_AmbienteCertificacion.Checked
                Dim _Accion As Enum_Accion = Enum_Accion.EnviarBoletaSII

                Dim _Cadena_ConexionSQL_Server_Actual As String = Replace(Cadena_ConexionSQL_Server, " ", "@")
                Dim _Ejecutar As String = Application.StartupPath & "\BoletaSII\BoletaBkHf.exe" &
                                                                                            Space(1) & ModEmpresa &
                                                                                            Space(1) & _AmbienteCertificacion &
                                                                                            Space(1) & _Id_Dte &
                                                                                            Space(1) & "0" &
                                                                                            Space(1) & _Accion
                Dim _MostrarShell As AppWinStyle

                If Chk_MostrarBoletaBkHfDOS.Checked Then
                    _MostrarShell = AppWinStyle.NormalFocus
                Else
                    _MostrarShell = AppWinStyle.Hide
                End If

                Try
                    Shell(_Ejecutar, _MostrarShell, True)

                    Consulta_sql = "Select Top 1 Isnull(Tid.Trackid,'') As Trackid,Doc.Respuesta" & vbCrLf &
                                   "From " & _Global_BaseBk & "Zw_DTE_Trackid Tid " & vbCrLf &
                                   "Inner Join " & _Global_BaseBk & "Zw_DTE_Documentos Doc On Tid.Id_Dte = Doc.Id_Dte" & vbCrLf &
                                   "Where Doc.Id_Dte = " & _Id_Dte & "Order By Id Desc"
                    Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

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

    End Sub

    Sub Sb_Revisar_Trackid_EnviaDTESIIBk()

        Consulta_sql = "Select Top 20 Tid.*,Doc.Tido From " & _Global_BaseBk & "Zw_DTE_Trackid Tid" & vbCrLf &
                   "Inner Join " & _Global_BaseBk & "Zw_DTE_Documentos Doc On Tid.Id_Dte = Doc.Id_Dte" & vbCrLf &
                   "Where Doc.Tido <> 'BLV' And Tid.AmbienteCertificacion = " & _AmbienteCertificacion &
                   " And ((Tid.Procesar = 0 And (Tid.Estado = '-11' Or Tid.Estado = 'SOK')) Or (Tid.Procesar = 1 And Tid.Procesado = 0))" & vbCrLf &
                   "Order By Tido,Nudo"

        Dim _Tbl_DTE_Trackid As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If Not CBool(_Tbl_DTE_Trackid.Rows.Count) Then
            Return
        End If

        If CBool(_Tbl_DTE_Trackid.Rows.Count) Then

            Dim _Filtro_Id_Trackid As String = Generar_Filtro_IN(_Tbl_DTE_Trackid, "", "Id_Dte", False, False, "")

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set Procesar = 0 Where Id In " & _Filtro_Id_Trackid
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

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
                    _Sql.Ej_consulta_IDU(Consulta_sql, False)
                    Exit For
                End If

                Sb_AddToLog("Revisar Trackid", "Revisando Trackid" & _Trackid, Txt_Log)

                ' PARAMETROS 

                '1 _Empresa = Environment.GetCommandLineArgs(2)
                '2 _AmbienteCertificacion = Environment.GetCommandLineArgs(3)
                '3 _Id_Dte = Environment.GetCommandLineArgs(4)
                '4 _Trackid = Environment.GetCommandLineArgs(5)
                '5 _Accion = Environment.GetCommandLineArgs(6)

                Dim _AmbienteCertificacion As Boolean = Chk_AmbienteCertificacion.Checked
                Dim _Accion As Enum_Accion = Enum_Accion.ConsultarTrackid

                Dim _Cadena_ConexionSQL_Server_Actual As String = Replace(Cadena_ConexionSQL_Server, " ", "@")
                Dim _Ejecutar As String = Application.StartupPath & "\EnvioDTE\EnviaDTESIIBk.exe" &
                                                                                    Space(1) & ModEmpresa &
                                                                                    Space(1) & _AmbienteCertificacion &
                                                                                    Space(1) & _Id_Dte &
                                                                                    Space(1) & _Trackid &
                                                                                    Space(1) & _Accion
                Dim _MostrarShell As AppWinStyle

                If Chk_MostrarBoletaBkHfDOS.Checked Then
                    _MostrarShell = AppWinStyle.NormalFocus
                Else
                    _MostrarShell = AppWinStyle.Hide
                End If

                Try
                    Shell(_Ejecutar, _MostrarShell, True)
                Catch ex As Exception
                    'MessageBoxEx.Show(Me, ex.Message, "DTEMonitor Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End Try

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DTE_Trackid Where Id = " & _Id_Trackid
                Dim _RowTrackid As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                _Estado = _RowTrackid.Item("Estado")
                _Glosa = _RowTrackid.Item("Glosa")
                _Respuesta = _RowTrackid.Item("Respuesta")

                Sb_AddToLog("Revisar Trackid", "Respuesta SII: " & _Respuesta, Txt_Log)
                Sb_AddToLog("Revisar Trackid", "Respuesta Estado: " & _Estado & ", Glosa: " & _Glosa, Txt_Log)

            Next

            Sb_AddToLog("Revisar Trackid", "Fin revisión", Txt_Log)

        End If

    End Sub

    Sub Sb_Revisar_Trackid_SIIBoletas()

        Consulta_sql = "Select Top 20 Tid.*,Doc.Tido From " & _Global_BaseBk & "Zw_DTE_Trackid Tid" & vbCrLf &
                   "Inner Join " & _Global_BaseBk & "Zw_DTE_Documentos Doc On Tid.Id_Dte = Doc.Id_Dte" & vbCrLf &
                   "Where Doc.Tido = 'BLV' And Tid.AmbienteCertificacion = " & _AmbienteCertificacion &
                   " And ((Tid.Procesar = 0 And (Tid.Estado = '-11' Or Tid.Estado = 'SOK')) Or (Tid.Procesar = 1 And Tid.Procesado = 0))" & vbCrLf &
                   "Order By Tido,Nudo"

        Dim _Tbl_DTE_Trackid As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If Not CBool(_Tbl_DTE_Trackid.Rows.Count) Then
            Return
        End If

        If CBool(_Tbl_DTE_Trackid.Rows.Count) Then

            Dim _Filtro_Id_Trackid As String = Generar_Filtro_IN(_Tbl_DTE_Trackid, "", "Id_Dte", False, False, "")

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set Procesar = 0 Where Id In " & _Filtro_Id_Trackid
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

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
                    _Sql.Ej_consulta_IDU(Consulta_sql, False)
                    Exit For
                End If

                Sb_AddToLog("Revisar Trackid", "Revisando Trackid" & _Trackid, Txt_Log)

                ' PARAMETROS 

                '1 _Empresa = Environment.GetCommandLineArgs(2)
                '2 _AmbienteCertificacion = Environment.GetCommandLineArgs(3)
                '3 _Id_Dte = Environment.GetCommandLineArgs(4)
                '4 _Trackid = Environment.GetCommandLineArgs(5)
                '5 _Accion = Environment.GetCommandLineArgs(6)

                Dim _AmbienteCertificacion As Boolean = Chk_AmbienteCertificacion.Checked
                Dim _Accion As Enum_Accion = Enum_Accion.ConsultarTrackid

                Dim _Cadena_ConexionSQL_Server_Actual As String = Replace(Cadena_ConexionSQL_Server, " ", "@")
                Dim _Ejecutar As String = Application.StartupPath & "\BoletaSII\BoletaBkHf.exe" &
                                                                                Space(1) & ModEmpresa &
                                                                                Space(1) & _AmbienteCertificacion &
                                                                                Space(1) & _Id_Dte &
                                                                                Space(1) & _Trackid &
                                                                                Space(1) & _Accion
                Dim _MostrarShell As AppWinStyle

                If Chk_MostrarBoletaBkHfDOS.Checked Then
                    _MostrarShell = AppWinStyle.NormalFocus
                Else
                    _MostrarShell = AppWinStyle.Hide
                End If

                Try
                    Shell(_Ejecutar, _MostrarShell, True)
                Catch ex As Exception
                    'MessageBoxEx.Show(Me, ex.Message, "DTEMonitor Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End Try

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DTE_Trackid Where Id = " & _Id_Trackid
                Dim _RowTrackid As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                _Estado = _RowTrackid.Item("Estado")
                _Glosa = _RowTrackid.Item("Glosa")
                _Respuesta = _RowTrackid.Item("Respuesta")

                Sb_AddToLog("Revisar Trackid", "Respuesta SII: " & _Respuesta, Txt_Log)
                Sb_AddToLog("Revisar Trackid", "Respuesta Estado: " & _Estado & ", Glosa: " & _Glosa, Txt_Log)

            Next

            Sb_AddToLog("Revisar Trackid", "Fin revisión", Txt_Log)

        End If

    End Sub

    Sub Sb_Enviar_Correos()

        Consulta_sql = "Select Id,Id_Dte,Idmaeedo,Trackid,Informado,Aceptado,Rechazado,Reparo,Estado,Glosa,Respuesta,FechaEnvSII," &
                   "AmbienteCertificacion,MailToDiablito, ErrorMailToDiablito" & vbCrLf &
                   "From " & _Global_BaseBk & "Zw_DTE_Trackid" & vbCrLf &
                   "Where Procesar = 0 " &
                   "And Procesado = 1 " &
                   "And EnviarMail = 1 " &
                   "And AmbienteCertificacion = " & _AmbienteCertificacion

        Dim _Tbl_DTE_Trackid As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            If Not CBool(_Tbl_DTE_Trackid.Rows.Count) Then
                Return
            End If

            'Dim _ListaDteTrackId As New List(Of String)

            If CBool(_Tbl_DTE_Trackid.Rows.Count) Then

                Dim _Filtro_Id_Trackid As String = Generar_Filtro_IN(_Tbl_DTE_Trackid, "", "Id", False, False, "")

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set MailToDiablito = 1,ErrorMailToDiablito = 0,EnviarMail = 0,MailEnviado = 0" & vbCrLf &
                               "Where Id In " & _Filtro_Id_Trackid
                _Sql.Ej_consulta_IDU(Consulta_sql, False)

                Sb_AddToLog("Enviar Correo", "Preparando envio de correos", Txt_Log)

                For Each _Fila As DataRow In _Tbl_DTE_Trackid.Rows

                    Dim _Id_Dte = _Fila.Item("Id_Dte")
                    Dim _Id_Trackid = _Fila.Item("Id")
                    Dim _Trackid = _Fila.Item("Trackid")
                    Dim _Idmaeedo = _Fila.Item("Idmaeedo")

                    If Fx_Esta_Firmando(_Filtro_Id_Trackid, _Id_Trackid) Then
                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set MailToDiablito = 0,EnviarMail = 1" & vbCrLf &
                               "Where Id In " & _Filtro_Id_Trackid
                        _Sql.Ej_consulta_IDU(Consulta_sql, False)
                        Exit For
                    End If

                    Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo)
                    _Class_DTE.AmbienteCertificacion = Convert.ToInt32(Chk_AmbienteCertificacion.Checked)

                    If IsNothing(_Class_DTE.Maeedo) Then
                        Sb_AddToLog("Enviar Correo", "Problemas al enviar correo, no se reconoce el IDMAEEDO: " & _Idmaeedo, Txt_Log)
                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set ErrorMailToDiablito = 1" & vbCrLf &
                                       "Where Id = " & _Id_Trackid
                        _Sql.Ej_consulta_IDU(Consulta_sql, False)
                    End If

                    If Not IsNothing(_Class_DTE.Maeedo) Then

                        Dim _Koen = _Class_DTE.Maeedo.Rows(0).Item("ENDO").ToString.Trim
                        Dim _Suen = _Class_DTE.Maeedo.Rows(0).Item("SUENDO").ToString.Trim
                        Dim _Para = _Class_DTE.Maeen.Rows(0).Item("EMAIL").ToString.Trim

                        Dim _EnvioCorreo As String = _Class_DTE.Fx_Enviar_Notificacion_Correo_Al_Diablito(_Idmaeedo, _Para, "", _Id_Trackid)

                        If String.IsNullOrEmpty(_EnvioCorreo) Then
                            Sb_AddToLog("Enviar Correo", "Se deja en la bandeja de salida correo para: " & _Para, Txt_Log)
                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set MailToDiablito = 1" & vbCrLf &
                                           "Where Id = " & _Id_Trackid
                            _Sql.Ej_consulta_IDU(Consulta_sql, False)
                        Else
                            Sb_AddToLog("Enviar Correo", "Problemas al enviar correo, problema: " & _EnvioCorreo, Txt_Log)
                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set ErrorMailToDiablito = 1" & vbCrLf &
                                            "Where Id = " & _Id_Trackid
                            _Sql.Ej_consulta_IDU(Consulta_sql, False)
                            Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "Zw_DTE_Trackid", _Id_Trackid, "Email_DTE_Error", _EnvioCorreo, "", "", _Koen, _Suen, False, "")
                        End If

                    End If

                Next

                Sb_AddToLog("Enviar Correo", "Fin envio de correos", Txt_Log)

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
        'Sb_Enviar_Documentos_Al_SII()
        Sb_Enviar_Documentos_Al_SIIEnviaDTESIIBk()
        Sb_Enviar_Documentos_Al_SIIBoletas()

        _Segundos = 30

        Timer_Consultar_TrackId.Start()
        If Me.WindowState <> FormWindowState.Minimized Then Timer_Segundos.Start()

    End Sub

    Private Sub Timer_Consultar_TrackId_Tick(sender As Object, e As EventArgs) Handles Timer_Consultar_TrackId.Tick

        Timer_Segundos.Stop()
        Timer_Enviar_SII.Stop()
        Timer_Consultar_TrackId.Stop()
        Lbl_Estatus.Text = "Consultar Trackid..."

        Sb_Revisar_Trackid_EnviaDTESIIBk()
        Sb_Revisar_Trackid_SIIBoletas()

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

        Sb_Enviar_Correos()

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

                Using Zip As ZipFile = ZipFile.Read(_AppPath & "\Dte.zip")
                    Zip.ExtractAll(AppPath(), ExtractExistingFileAction.OverwriteSilently)
                End Using

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

    Private Sub MyWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        'Add your codes here for the worker to execute

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_DTE_Firmar" & vbCrLf &
                       "Where Firmar = 1 And AmbienteCertificacion = " & _AmbienteCertificacion
        Dim _RowFirmar As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_RowFirmar) Then

            Dim _Id As Integer = _RowFirmar.Item("Id")
            Dim _Idmaeedo As Integer = _RowFirmar.Item("Idmaeedo")
            Dim _Tido As String = _RowFirmar.Item("Tido")
            Dim _Nudo As String = _RowFirmar.Item("Nudo")

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Firmar Set Firmar = 0 Where Id = " & _Id
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo)
            _Class_DTE.AmbienteCertificacion = Convert.ToInt32(Chk_AmbienteCertificacion.Checked)

            Dim _Id_Dte As Integer = _Class_DTE.Fx_Timbrar_Documento_Hefesto(Me)

            If CBool(_Id_Dte) Then
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Firmar Set Id_Dte = " & _Id_Dte & " Where Id = " & _Id
                _Sql.Ej_consulta_IDU(Consulta_sql)
            Else
                If CBool(_Class_DTE.Pro_Errores.Count) Then
                    Dim Log_Error As String
                    For Each _Error As String In _Class_DTE.Pro_Errores
                        Log_Error += _Error & vbCrLf
                    Next
                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Firmar Set Log_Error = '" & Log_Error & "' Where Id = " & _Id
                    _Sql.Ej_consulta_IDU(Consulta_sql)
                End If
            End If

        End If

    End Sub

    Private Sub MyWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        'Add your codes for the worker to execute after finishing the work.
        bgWorker.RunWorkerAsync()
    End Sub

End Class


