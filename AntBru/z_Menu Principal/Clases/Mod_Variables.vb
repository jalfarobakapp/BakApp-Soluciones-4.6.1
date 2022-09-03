Imports DevComponents.DotNetBar
Imports BkSpecialPrograms
Imports System.IO
Imports Bk_Produccion

Public Module Mod_Variables

    Dim Consulta_sql As String

    Function Fx_Activar_Deactivar_Teclado(ByVal _Owner As Object,
                                           ByVal _Teclado As Boolean,
                                           ByVal _TouchKeyboard As Keyboard.TouchKeyboard,
                                           ByVal _Txt_Foco As Object)
        Dim _x = _Owner.Location.X
        Dim _Y = _Owner.Location.Y

        Dim _H = _Owner.Height

        Dim _Ancho_Teclado = _TouchKeyboard.Size.Width

        Dim _Top = (Screen.PrimaryScreen.WorkingArea.Height - _Owner.Height) / 2
        Dim _Left = (Screen.PrimaryScreen.WorkingArea.Width - _Ancho_Teclado) / 2

        _TouchKeyboard.FloatingLocation = New System.Drawing.Point(_Left, _Y + _H)
        If _Teclado Then
            _TouchKeyboard.SetShowTouchKeyboard(_Txt_Foco, Keyboard.TouchKeyboardStyle.Floating)
        Else
            _TouchKeyboard.SetShowTouchKeyboard(_Txt_Foco, Keyboard.TouchKeyboardStyle.No)
            _TouchKeyboard.HideKeyboard()
        End If

    End Function

    Function Fx_Equipo_Registrado(ByVal _NombreEquipo As String) As Boolean

        Dim _Registro As New Frm_Licencia_Empresa
        KeyReg = UCase(Trim(RutEmpresa) & "@" & _NombreEquipo)
        KeyReg = Encripta_md5(KeyReg)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _RegKeyReg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_EstacionesBkp",
                                                           "NombreEquipo = '" & _NombreEquipo & "'"))

        If _RegKeyReg Then
            Return True
        Else

            MessageBoxEx.Show(Frm_Menu, "Esta estación de trabajo no esta registrada, debe registrar", "Registro de estación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Dim FmReg As New Frm_RegistrarEquipo(Frm_RegistrarEquipo.Enum_Accion.Nuevo, 0, False)
            FmReg.ShowDialog(Frm_Menu)
            FmReg.Dispose()

        End If

    End Function

    Function Fx_Buscar_Actualizacion(_Formulario As Form) As Boolean ', _Mostra_Notificacion As Boolean) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Clas_Actualizar_Bakapp As New Clas_Actualiza_BakApp_Sql 'Clas_Actualizar_Bakapp

        With _Clas_Actualizar_Bakapp

            Dim _Rut = RutEmpresa ' _Sql.Fx_Trae_Dato("CONFIGP", "RUT", "EMPRESA = '01'").ToString.Trim
            Dim _Ruta_Y_Archivo_Actualizacion As String
            Dim _Descarga_Completa As Boolean
            Dim _Descarga_Por_Link As Boolean

            With _Clas_Actualizar_Bakapp

                If .Fx_Existe_Nueva_Actualizacion Then '(.Host & "/BakApp/Empresas/" & _Rut) Then

                    Dim Fm As New Frm_Actualizar_BakApp(.URL_Descarga, .Nombre_Archivo, .Nro_Version_Nueva, Frm_Actualizar_BakApp.Enum_Accion.Descargar_Instalar)
                    Fm.ShowDialog(_Formulario)
                    Fm.Dispose()
                    _Ruta_Y_Archivo_Actualizacion = Fm.Ruta_Y_Archivo_Actualizacion
                    _Descarga_Completa = Fm.Descarga_Completa
                    _Descarga_Por_Link = Fm.Descarga_Por_Link
                    Fm.Dispose()

                    If _Descarga_Por_Link Then
                        Return False
                    End If

                    If _Descarga_Completa Then

                        Shell("explorer.exe " & _Ruta_Y_Archivo_Actualizacion, AppWinStyle.NormalFocus)
                        Return True

                    Else

                        Frm_Menu.Notify_Actualizacion.Visible = True

                        Frm_Menu.Notify_Actualizacion.Text = "BakApp (Instalar Actualización Version: " & .Nro_Version_Nueva & ")"
                        Frm_Menu.Notify_Actualizacion.ShowBalloonTip(5, "ACTUALIZACION BAKAPP",
                                                                     "Existe una nueva versión " & .Nro_Version_Nueva,
                                                                     ToolTipIcon.Info)
                    End If

                Else

                    If Not String.IsNullOrEmpty(.Mensaje) Then
                        MessageBoxEx.Show(_Formulario, .Mensaje, "Problemas al descargar la versión", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                End If

            End With

        End With

    End Function

    Function Fx_Datos_Directorio_GenDTE(_Directorio_GenDTE As String,
                                        _NombreEquipo As String) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Existe_Archivo_GenDTE = False

        Dim _FolderBrowserDialog As New FolderBrowserDialog

        Dim _Nuevo_RunMonitor As Boolean = _Sql.Fx_Exite_Campo("CONFIGP", "VERSIONACT")


        If _Nuevo_RunMonitor Then

            If File.Exists(_Directorio_GenDTE & "\dte\bat\GenDTE.BAT") Then
                _Existe_Archivo_GenDTE = True
            End If

        Else

            If File.Exists(_Directorio_GenDTE & "\GenDTE.BAT") Then
                _Existe_Archivo_GenDTE = True
            End If

        End If

        If _Existe_Archivo_GenDTE Then

            Return True

        Else

            MessageBoxEx.Show(Frm_Menu, "El directorio GenDTE no existe o no esta registrado", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

            With _FolderBrowserDialog

                .Reset()

                ' leyenda  
                .Description = " Seleccionar una carpeta "
                ' Path " Mis documentos "  
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

                ' deshabilita el botón " crear nueva carpeta "  
                .ShowNewFolderButton = False
                '.RootFolder = Environment.SpecialFolder.Desktop  
                '.RootFolder = Environment.SpecialFolder.StartMenu  

                Dim ret As DialogResult = .ShowDialog ' abre el diálogo  

                ' si se presionó el botón aceptar ...  
                If ret = Windows.Forms.DialogResult.OK Then

                    Dim nFiles As ObjectModel.ReadOnlyCollection(Of String)

                    nFiles = My.Computer.FileSystem.GetFiles(.SelectedPath)
                    _Directorio_GenDTE = .SelectedPath

                    If _Nuevo_RunMonitor Then

                        If File.Exists(_Directorio_GenDTE & "\dte\bat\GenDTE.BAT") Then
                            _Existe_Archivo_GenDTE = True
                        End If

                    Else

                        If File.Exists(_Directorio_GenDTE & "\GenDTE.BAT") Then
                            _Existe_Archivo_GenDTE = True
                        End If

                    End If

                    'If Fx_Datos_Directorio_GenDTE(_Directorio_GenDTE, _NombreEquipo) Then
                    '    _Existe_Archivo_GenDTE = True
                    'Else
                    '    Return False
                    'End If

                End If

                .Dispose()

            End With

        End If

        If _Existe_Archivo_GenDTE Then

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set Directorio_GenDTE = '" & _Directorio_GenDTE & "'" & vbCrLf &
                           "Where NombreEquipo = '" & _NombreEquipo & "'"

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                _Global_Row_EstacionBk.Item("Directorio_GenDTE") = _Directorio_GenDTE
                Return True
            End If

        Else

            If Not String.IsNullOrEmpty(_Directorio_GenDTE) Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set Directorio_GenDTE = ''" & vbCrLf &
                               "Where NombreEquipo = '" & _NombreEquipo & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                _Global_Row_EstacionBk.Item("Directorio_GenDTE") = String.Empty

            End If

            MessageBoxEx.Show(Frm_Menu,
                                  "No se encontro el archivo GenDTE.BAT en el directorio (" & _Directorio_GenDTE & ")" & vbCrLf &
                                  "Este archivo es necesario para la generación de documentos electrónicos en DTE RunMonitor",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Function

    Function Fx_Ejecutar_Demonio_Old(_Directorio_Demonio As String) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _FolderBrowserDialog As New FolderBrowserDialog

        If Not Directory.Exists(_Directorio_Demonio) Then
            MessageBoxEx.Show(Frm_Menu, "El directorio del Demonio no existe o no esta registrado", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

            'System.IO.Directory.CreateDirectory(_Path)

            With _FolderBrowserDialog

                .Reset() ' resetea  

                ' leyenda  
                .Description = " Seleccionar una carpeta "
                ' Path " Mis documentos "  
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

                ' deshabilita el botón " crear nueva carpeta "  
                .ShowNewFolderButton = False
                '.RootFolder = Environment.SpecialFolder.Desktop  
                '.RootFolder = Environment.SpecialFolder.StartMenu  

                Dim ret As DialogResult = .ShowDialog ' abre el diálogo  

                ' si se presionó el botón aceptar ...  
                If ret = Windows.Forms.DialogResult.OK Then

                    Dim nFiles As ObjectModel.ReadOnlyCollection(Of String)

                    nFiles = My.Computer.FileSystem.GetFiles(.SelectedPath)

                    Dim _Directorio_Seleccionado As String = .SelectedPath

                    If File.Exists(_Directorio_Seleccionado & "\BakApp_Demonio.exe") Then
                        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Estaciones_CashDro Set Directorio_Demonio = '" & _Directorio_Seleccionado & "'" & vbCrLf &
                                       "Where NombreEquipo = '" & _NombreEquipo & "'"

                        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                            _Directorio_Demonio = _Directorio_Seleccionado
                        Else
                            Return False
                        End If
                    Else
                        MessageBoxEx.Show(Frm_Menu,
                        "No se encontro el archivo BakApp_Demonio.exe en el directorio (" & _Directorio_Seleccionado & ")",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                        'GenDTE.BAT
                    End If
                End If

                .Dispose()

            End With

        End If

        If File.Exists(_Directorio_Demonio & "\BakApp_Demonio.exe") Then
            Dim _Ejecutar As String = _Directorio_Demonio & "\BakApp_Demonio.exe"

            Try
                Shell(_Ejecutar, AppWinStyle.NormalFocus, False)
            Catch ex As Exception
                MessageBoxEx.Show(ex.Message)
            End Try
        Else
            MessageBoxEx.Show(Frm_Menu,
                        "No se encontro el archivo BakApp_Demonio.exe en el directorio (" & Application.StartupPath & ")",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Function

    Function Fx_Ejecutar_Demonio() As Boolean

        If File.Exists(Application.StartupPath & "\BakApp_Demonio.exe") Then
            Dim _Ejecutar As String = Application.StartupPath & "\BakApp_Demonio.exe"

            Try
                Shell(_Ejecutar, AppWinStyle.NormalFocus, False)
            Catch ex As Exception
                MessageBoxEx.Show(ex.Message)
            End Try
        Else
            MessageBoxEx.Show(Frm_Menu,
                        "No se encontro el archivo BakApp_Demonio.exe en el directorio (" & Application.StartupPath & ")",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Function

    Function Fx_Abrir_Demonio()

        Dim _Path = AppPath() & "\Data\" & RutEmpresa & "\Demonio"
        Dim _Datos_Conf As New Ds_Config_Picking

        If Not Directory.Exists(_Path) Then
            System.IO.Directory.CreateDirectory(_Path)
        End If

        _Datos_Conf.Clear()
        Dim exists = System.IO.File.Exists(_Path & "\Config_Local.xml")
        With _Datos_Conf
            If Not exists Then

                Dim NewFila As DataRow
                NewFila = _Datos_Conf.Tables("Tbl_Configuracion").NewRow

                With NewFila

                    .Item("Impresora") = String.Empty
                    .Item("RutaImagen") = String.Empty

                End With

                .Tables("Tbl_Configuracion").Rows.Add(NewFila)
                .WriteXml(_Path & "\Config_Local.xml")

            End If
        End With

        _Datos_Conf.Clear()
        _Datos_Conf.ReadXml(_Path & "\Config_Local.xml")

        Dim _Fila As DataRow = _Datos_Conf.Tables("Tbl_Configuracion").Rows(0)
        Dim _Ejecutar_Automaticamente As Boolean = NuloPorNro(_Fila.Item("Ejecutar_Automaticamente"), False)

        Return _Ejecutar_Automaticamente

    End Function

    Sub Sb_Cerrar_Sistema(_Preguntar_Cierra_Demonio As Boolean)

        If Not IsNothing(_Global_Row_EstacionBk) Then

            Dim Directorio As String = Application.StartupPath & "\Data\"
            Dim Ip = getIp()
            Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo") 'UCase(System.Net.Dns.GetHostName)

            Dim DatosConex As New ConexionBK
            DatosConex.ReadXml(Directorio & "Conexiones.xml")

            Dim _Tbl As DataTable = New DataTable
            _Tbl = DatosConex.Tables("CnBakApp")

            If _Tbl.Rows.Count Then

                For Each _Fila As DataRow In _Tbl.Rows

                    Dim _Servidor = Trim(_Fila.Item("Servidor"))
                    Dim _Puerto = Trim(_Fila.Item("Puerto"))
                    Dim _BaseDeDatos = Trim(_Fila.Item("BaseDeDatos"))
                    Dim _Usuario = Trim(_Fila.Item("Usuario"))
                    Dim _Clave = Trim(_Fila.Item("Clave"))
                    Dim _Conectado = _Fila.Item("Conectado")

                    If Not String.IsNullOrEmpty(_Puerto) Then
                        _Servidor += "," & _Puerto
                    End If

                    If _Conectado Then

                        'data source = SQL7.VITGLOBAL.NET,1777; initial catalog = AGRORAMA; user id = AGRORAMA; password = AGRORAMA

                        Cadena_ConexionSQL_Server = "data source = " & _Servidor & "; initial catalog = " & _BaseDeDatos &
                                        "; user id = " & _Usuario & "; password = " & _Clave

                        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

                        Consulta_sql = "Select Top 1 * From CONFIGP"
                        Dim _Row = _Sql.Fx_Get_DataRow(Consulta_sql)

                        Try
                            If Not (_Row Is Nothing) Then
                                RutEmpresa = Trim(_Sql.Fx_Trae_Dato("CONFIGP", "RUT", "EMPRESA = '" & ModEmpresa & "'"))

                                Dim _Class_BaseBk As New Class_Conectar_Base_BakApp(Frm_Menu)

                                If _Class_BaseBk.Pro_Existe_Base Then
                                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set Conectado = 0," & vbCrLf &
                                                   "Fecha_Hora_Conec = Null" & vbCrLf &
                                                   "Where NombreEquipo = '" & _NombreEquipo & "'"
                                    _Sql.Ej_consulta_IDU(Consulta_sql, False)
                                End If
                            Else
                                Exit For
                            End If
                        Catch ex As Exception

                        End Try
                    End If

                Next

            End If

            For Each _Fila As DataRow In _Tbl.Rows
                _Fila.Item("Conectado") = False
            Next

            DatosConex.WriteXml(Directorio & "Conexiones.xml")

        End If

        Frm_Menu.Notify_Creditos_Negocios.Visible = False
        Frm_Menu.Notify_SolCompra.Visible = False
        Frm_Menu.Notify_Remota.Visible = False

        Dim _Ejecutando_Notificaciones As Process() = Process.GetProcessesByName(_Global_Nombre_BakApp_Notificaciones)
        Dim _Ejecutando_Demonio As Process() = Process.GetProcessesByName(_Global_Nombre_BakApp_Demonio)
        Dim _Ejecutando_DTEMonitor As Process() = Process.GetProcessesByName(_Global_Nombre_BakApp_DTEMonitor)

        For Each prog As Process In Process.GetProcesses

            If UCase(prog.ProcessName) = UCase(_Global_Nombre_BakApp_Demonio) Then
                If _Preguntar_Cierra_Demonio Then
                    If MessageBoxEx.Show(Frm_Menu, "El diablito de monitoreo de acciones automáticas se encuentra en ejecución." & vbCrLf &
                                                     "¿Desea cerrarlo tambien?", "Diablito", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        prog.Kill()
                    End If
                Else
                    prog.Kill()
                End If
            End If

            If UCase(prog.ProcessName) = UCase(_Global_Nombre_BakApp_DTEMonitor) Then
                If _Preguntar_Cierra_Demonio Then
                    If MessageBoxEx.Show(Frm_Menu, "El diablito de monitoreo de documentos DTE SII se encuentra en ejecución." & vbCrLf &
                                                     "¿Desea cerrarlo tambien?", "DTEMonitor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        prog.Kill()
                    End If
                Else
                    prog.Kill()
                End If
            End If

            If UCase(prog.ProcessName) = UCase(_Global_Nombre_BakApp_Notificaciones) Then
                prog.Kill()
            End If

        Next

        Application.ExitThread()

    End Sub

    Function Fx_Row_Sesion_Star(ByVal _Formulario As Form) As DataRow


        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_Sql As String

        Dim _Row_Nom_Equipo As DataRow
        Dim _Dir_Local As String = Application.StartupPath & "\Data\"

        Dim _Nombre_Equipo As String = My.Computer.Name
        If Fx_Revisar_Nombre_Equipo_BakApp(_Formulario,
                                           _Dir_Local & RutEmpresa & "\Configuracion_Local",
                                           RutEmpresa, _Nombre_Equipo) Then

            Dim _Ds As New DatosBakApp
            _Ds.Clear()
            _Ds.ReadXml(_Dir_Local & RutEmpresa & "\Configuracion_Local\Nombre_Equipo.xml")

            _Row_Nom_Equipo = _Ds.Tables("Tbl_Nombre_Equipo").Rows(0)
        Else
            Return Nothing
        End If

        Dim _Mi_IP = getIp()
        _Nombre_Equipo = _Row_Nom_Equipo.Item("Nombre_Equipo") 'UCase(System.Net.Dns.GetHostName)

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_EstacionesBkp Where NombreEquipo = '" & _Nombre_Equipo & "'"
        _Global_Row_EstacionBk = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If Not (_Global_Row_EstacionBk Is Nothing) Then

            Dim _Cadena_Base As String =
            UCase(Trim(RutEmpresa) & "@" & Trim(_Global_Row_EstacionBk.Item("NombreEquipo")))

            Dim _Key_Base = Encripta_md5(_Cadena_Base)

            Dim _Cadena As String = UCase(Trim(RutEmpresa) & "@" & _Nombre_Equipo)
            Dim _KeyReg = _Global_Row_EstacionBk.Item("KeyReg") 'Encripta_md5(_Cadena)

            If _KeyReg = _Key_Base Then

                Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Licencia Where Rut = '" & RutEmpresa & "'"
                Dim _TblLicencia As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

                If CBool(_TblLicencia.Rows.Count) Then
                    With _TblLicencia.Rows(0)

                        Dim _Rut = .Item("Rut")
                        Dim _Fecha_caduca As Date = .Item("Fecha_caduca")
                        Dim _Cant_licencias As Integer = .Item("Cant_licencias")
                        Dim _Libre = .Item("Libre")


                        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set Conectado = 0," & vbCrLf &
                                       "IpEstacion = ''," & vbCrLf &
                                       "Fecha_Hora_Conec = Null" & vbCrLf &
                                       "Where NombreEquipo = '" & _Nombre_Equipo & "'"
                        _Sql.Ej_consulta_IDU(Consulta_Sql)

                        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_EstacionesBkp", "Conectado = 1")

                        If _Libre Then _Cant_licencias = 2

                        If _Reg >= _Cant_licencias Then

                            Dim _Nombre_Empresa As String = _Sql.Fx_Trae_Dato("CONFIGP", "RAZON", "EMPRESA = '" & ModEmpresa & "'")

                            MessageBoxEx.Show(_Formulario, "Superada la cantidad de usuarios conectados al sistema, empresa: " & _Nombre_Empresa & vbCrLf &
                                              "Para poder seguir debe cerrar una sesión o bien contactarse con" & vbCrLf &
                                              "BakApp Soluciones para adquirir más licencias",
                                              "Limite de usuarios (" & _Cant_licencias & ")",
                                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

                            Return Nothing

                        Else
                            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set Conectado = 1," & vbCrLf &
                                           "IpEstacion = '" & _Mi_IP & "'," & vbCrLf &
                                           "Fecha_Hora_Conec = Getdate()," & vbCrLf &
                                           "CodUsuario = ''," & vbCrLf &
                                           "NomUsuario = ''," & vbCrLf &
                                           "Version = '" & _Global_Version_BakApp & "'" & vbCrLf &
                                           "Where NombreEquipo = '" & _Nombre_Equipo & "'"

                            If Not _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                                Return Nothing
                            End If
                        End If
                    End With
                End If

            Else
                MessageBoxEx.Show(_Formulario, "Problemas con el registro de esta estación", "Validación",
                             MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_EstacionesBkp" & vbCrLf &
                               "Where NombreEquipo = '" & _Nombre_Equipo & "'"
                _Sql.Ej_consulta_IDU(Consulta_Sql)

                Return Nothing
            End If
        Else

            Dim Fm As New Frm_RegistrarEquipo(Frm_RegistrarEquipo.Enum_Accion.Nuevo, 0, False)
            Fm.Pro_Nombre_Equipo = _Nombre_Equipo
            Fm.ShowDialog(_Formulario)

            If Not Fm.Pro_Registrado Then
                MessageBoxEx.Show(_Formulario, "Problemas con el registro de esta estación", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

            Fm.Dispose()

            Sb_Cerrar_Sistema(False)

        End If

        Fx_Row_Sesion_Star = _Global_Row_EstacionBk

    End Function

    Sub Sb_CashDro(ByVal _Formulario As Form)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")
        Dim _Directorio_GenDTE As String = _Global_Row_EstacionBk.Item("Directorio_GenDTE")

        Dim _Row_CashDro As DataRow

        Consulta_sql = "SELECT NombreEquipo,Funcionario,Modalidad,Ip_CashDro,Usuario_CashDro,Contrasena_CashDro," &
                       "EFV,TJV,NCV,Tiempo_Espera,Directorio_Demonio,Abrir_Demonio" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_Estaciones_CashDro" & vbCrLf &
                       "Where NombreEquipo = '" & _NombreEquipo & "'"
        _Row_CashDro = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not (_Row_CashDro Is Nothing) Then

            If Fx_Datos_Directorio_GenDTE(_Directorio_GenDTE, _NombreEquipo) Then

                FUNCIONARIO = _Row_CashDro.Item("Funcionario")
                Modalidad = _Row_CashDro.Item("Modalidad")

                Consulta_sql = "Select * From TABFU Where KOFU = '" & FUNCIONARIO & "'"
                Dim _RowUsuario As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                FUNCIONARIO = _RowUsuario.Item("KOFU")
                Nombre_funcionario_activo = Trim(_RowUsuario.Item("NOKOFU"))

                Dim _Mod As New Clas_Modalidades
                _Mod.Sb_Actualiza_Formatos_X_Modalidad()
                _Global_Row_Configuracion_General = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.General, "")
                _Global_Row_Configuracion_Estacion = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.Estacion, Modalidad)
                _Mod.Sb_Actualizar_Variables_Modalidad(Modalidad)

                Dim _RowFormato_BLV As DataRow = Fx_Formato_Modalidad(Frm_Menu, Modalidad, "BLV", True)
                Dim _RowFormato_FCV As DataRow = Fx_Formato_Modalidad(Frm_Menu, Modalidad, "FCV", True)

                If (_RowFormato_BLV Is Nothing) Or
                   (_RowFormato_BLV Is Nothing) Then

                    MessageBoxEx.Show(Frm_Menu, "Debe configurar el formato de salida en la configuración por modalidad de trabajo",
                                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)


                Else

                    Frm_Menu.Text = "Sistema BakApp. Empresa :" & RazonEmpresa &
                                    ", Funcionario Activo: " & Trim(Nombre_funcionario_activo) &
                                    ", Modalidad: " & Modalidad & ", BakApp Versión: " & _Global_Version_BakApp & ","

                    Dim Fm_Cd As New Frm_Cashdro_Presentacion
                    Fm_Cd.ShowDialog(_Formulario)
                    Fm_Cd.Dispose()

                End If

            End If
        Else
            MessageBoxEx.Show(_Formulario, "Esta estación no esta registrada como equipo para CASHDRO",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Sub Sb_Produccion_Mesones_DFA(_Revisar_Demonio As Boolean)

        Frm_Menu.Hide()

        ''Frm_Menu.Tiempo_Espera_Notificacion.Stop()

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        FUNCIONARIO = _Global_Row_EstacionBk.Item("Usuario_X_Defecto")
        Modalidad = _Global_Row_EstacionBk.Item("Modalidad_X_Defecto")

        Consulta_sql = "Select * From TABFU Where KOFU = '" & FUNCIONARIO & "'"
        Dim _RowUsuario As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_RowUsuario) Then
            MessageBoxEx.Show(Frm_Menu, "FALTA EL USUARIO POR DEFECTO EN LA CONFIGURACION DE LA ESTACION",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Modalidad) Then
            MessageBoxEx.Show(Frm_Menu, "FALTA LA MODALIDAD POR DEFECTO EN LA CONFIGURACION DE LA ESTACION",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        FUNCIONARIO = _RowUsuario.Item("KOFU")
        Nombre_funcionario_activo = Trim(_RowUsuario.Item("NOKOFU"))

        Dim _Mod As New Clas_Modalidades
        _Mod.Sb_Actualiza_Formatos_X_Modalidad()
        _Global_Row_Configuracion_General = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.General, "")
        _Global_Row_Configuracion_Estacion = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.Estacion, Modalidad)
        _Mod.Sb_Actualizar_Variables_Modalidad(Modalidad)

        Dim Fm As New Frm_Meson_Operario_Ingreso(True)
        Fm.ShowDialog(Frm_Menu)
        Fm.Dispose()

    End Sub

End Module
