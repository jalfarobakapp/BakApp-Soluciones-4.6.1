Imports System.IO
Imports BkSpecialPrograms
Imports BkSpecialPrograms.LsValiciones
Imports DevComponents.DotNetBar
Imports Newtonsoft.Json

Public Class Frm_Sincronizador

    Dim _FechaRevision As DateTime
    Dim _Cl_ConfiguracionLocal As New Cl_ConfiguracionLocal
    Dim _CL_ProcesaDatos As New Cl_ProcesaDatos
    Dim _Version As String
    Private _Ls_Programaciones As New List(Of Cl_NewProgramacion)

    ' Memoria para registrar la última ejecución de cada tarea
    Private _DictUltimaEjecucion As New Dictionary(Of String, DateTime)
    Public Property _Global_BaseBk As String

    ' --- Propiedades Públicas para las Entidades ---
    ' Se eliminan las tablas sueltas y se mantiene solo el objeto estructurado
    Public Property Empresa01 As New Empresa() With {.Numero = "01"}
    Public Property Empresa02 As New Empresa() With {.Numero = "02"}
    ' -----------------------------------------------

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
    End Sub

    Public Property Ls_ProgramacionesGlobal As List(Of Cl_NewProgramacion)
        Get
            Return _Ls_Programaciones
        End Get
        Set(value As List(Of Cl_NewProgramacion))
            _Ls_Programaciones = value
        End Set
    End Property

    Private Sub Frm_Sincronizador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Inicializamos la propiedad de correos para evitar errores de referencia nula en caso de que el archivo no exista o esté corrupto
        ' el nombre del ejecutable y la extensión:
        _Version = System.IO.Path.GetFileName(Application.ExecutablePath)

        _Version = FileVersionInfo.GetVersionInfo _
                                   (Application.StartupPath & "\" & _Version).FileVersion

        Lbl_Estatus.Text = "Versión: " & _Version

        Txt_Log.ReadOnly = True
        CircularPgrs.IsRunning = False

        Timer_Limpiar.Interval = (1000 * 60) * 1   ' Limpieza del log cada 1 min
        Timer_AjustarFecha.Interval = (1000 * 60) * 30 ' Ajuste de fecha cada 30 min

        Sb_Ejecutar_diablito()
    End Sub

    Sub Sb_Ejecutar_diablito()
        Try
            Dim _Mensaje As New LsValiciones.Mensajes

            Txt_Log.Text = String.Empty

            Sb_AddToLog("Conexión", "Revisando el archivo de conexión a la base de datos...", Txt_Log)

            _Mensaje = _Cl_ConfiguracionLocal.Fx_LeerArchivoConexionJson(True)

            If Not _Mensaje.EsCorrecto Or _Mensaje.Id = 0 Then
                MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Sb_AddToLog("Conexión", "¡Error en la conexión!", Txt_Log)
                Sb_AddToLog("Conexión", _Mensaje.Detalle, Txt_Log)
                Sb_AddToLog("Conexión", _Mensaje.Mensaje, Txt_Log)
                Switch_Sincronizacion.Value = False
                Switch_Sincronizacion.Enabled = False
                CircularPgrs.IsRunning = False
                Return
            End If

            _Global_BaseBk = _Cl_ConfiguracionLocal.Configuracion.Global_BaseBk & ".dbo."

            ' SOLO SE CARGA LA CONEXIÓN 0 (Principal) YA QUE TODO ESTÁ EN EL MISMO SERVIDOR AHORA
            With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones.Item(0)
                Cadena_ConexionSQL_Server = _Cl_ConfiguracionLocal.Fx_CadenaConexion(.Host, .Puerto, .Basededatos, .Usuario, .Password)
                Sb_AddToLog("Conexión", "Conexión exitosa a la base de datos " & .Basededatos.ToString.Trim, Txt_Log)
            End With
            Dtp_FechaRevision.Value = FechaDelServidor()

            ' --- CARGA DE ENTIDADES PÚBLICAS DESDE JSON (ESTRUCTURA NUEVA) ---
            Try
                Dim rutaEntidades As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Entidades.json")
                If File.Exists(rutaEntidades) Then
                    Dim jsonString As String = File.ReadAllText(rutaEntidades)
                    Dim miConfig As EntidadesDiccionario = JsonConvert.DeserializeObject(Of EntidadesDiccionario)(jsonString)

                    If miConfig IsNot Nothing AndAlso miConfig.Empresa01 IsNot Nothing AndAlso miConfig.Empresa02 IsNot Nothing Then
                        ' Asignamos los objetos completos deserializados a las propiedades locales
                        Empresa01 = miConfig.Empresa01
                        Empresa02 = miConfig.Empresa02

                        ' Aseguramos que los identificadores de número se mantengan correctos
                        Empresa01.Numero = "01"
                        Empresa02.Numero = "02"

                        Sb_AddToLog("Entidades", "Filtros de empresas y modalidades cargados exitosamente.", Txt_Log)
                    Else
                        Switch_Sincronizacion.Value = False
                        Switch_Sincronizacion.Enabled = False
                        CircularPgrs.IsRunning = False
                        Sb_AddToLog("Entidades", "Advertencia: El archivo Entidades.json está incompleto. Faltan configuraciones de empresas.", Txt_Log)
                        MessageBoxEx.Show(Me, "Advertencia: El archivo Entidades.json está incompleto. Faltan configuraciones de empresas.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If
                Else
                    Switch_Sincronizacion.Value = False
                    Switch_Sincronizacion.Enabled = False
                    CircularPgrs.IsRunning = False
                    Sb_AddToLog("Entidades", "Advertencia: Archivo Entidades.json no encontrado.", Txt_Log)
                    MessageBoxEx.Show(Me, "Advertencia: Archivo Entidades.json no encontrado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If
            Catch ex As Exception
                Switch_Sincronizacion.Value = False
                Switch_Sincronizacion.Enabled = False
                CircularPgrs.IsRunning = False
                Sb_AddToLog("Error Entidades", "Fallo al cargar Entidades.json: " & ex.Message, Txt_Log)
                MessageBoxEx.Show(Me, "Fallo al cargar Entidades.json: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End Try
            ' -----------------------------------------------------------------

            ' --- NUEVA LÓGICA DE VALIDACIÓN DE PROGRAMACIONES ---
            Dim prog = Frm_Configuracion.CargarProgramaciones("ConfHoras.json")

            ' Validamos si el archivo no existe, está corrupto o la lista está vacía
            If prog Is Nothing OrElse prog.Count = 0 Then
                MessageBoxEx.Show(Me, "No hay tareas programadas configuradas. El demonio de sincronización se detendrá.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Sb_AddToLog("Sincronizador", "Sin tareas programadas. Demonio detenido.", Txt_Log)

                Switch_Sincronizacion.Value = False
                Switch_Sincronizacion.Enabled = False
                CircularPgrs.IsRunning = False

                Return ' Salimos antes de encender los timers
            End If

            ' Si superó la validación, asignamos a la memoria local
            _Ls_Programaciones = prog
            Sb_AddToLog("Fechas", "Programaciones cargadas exitosamente (" & prog.Count & " tareas encontradas).", Txt_Log)
            ' ----------------------------------------------------

            Switch_Sincronizacion.Value = True
            Switch_Sincronizacion.Enabled = True

            CircularPgrs.IsRunning = True
            Dim _NombreEquipo = "DIEGO"
            Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
            Dim Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_EstacionesBkp Where NombreEquipo = '" & _NombreEquipo & "'"
            _Global_Row_EstacionBk = _Sql.Fx_Get_DataRow(Consulta_sql)
            FUNCIONARIO = "RDF"
            Timer_Ejecutar.Interval = 1000 ' Configurado a 1 segundo (Ajustable)
            Timer_Ejecutar.Start()
            Timer_Limpiar.Start()
            Timer_AjustarFecha.Start()
            Sb_AddToLog("Sincronizador", "Demonio en ejecución.", Txt_Log)

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub Btn_Configuraciones_Click(sender As Object, e As EventArgs) Handles Btn_Configuraciones.Click
        Timer_Ejecutar.Stop()

        Dim Fm As New Frm_Configuracion
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Ejecutar_diablito()
    End Sub

    Private Async Sub Timer_Ejecutar_Tick(sender As Object, e As EventArgs) Handles Timer_Ejecutar.Tick
        ' Detenemos el timer para evitar superposiciones
        Timer_Ejecutar.Stop()

        Try
            Dim horaActual As DateTime = Now

            For Each tarea In _Ls_Programaciones
                Dim tocaEjecutar As Boolean = False

                ' Leemos la memoria para saber cuándo fue la última ejecución de esta tarea
                Dim ultimaVez As DateTime = DateTime.MinValue
                If _DictUltimaEjecucion.ContainsKey(tarea.Nombre) Then
                    ultimaVez = _DictUltimaEjecucion(tarea.Nombre)
                End If

                ' 1. Verificamos la frecuencia de días
                Dim diaCorrecto As Boolean = False
                If tarea.FrecuDiaria Then
                    diaCorrecto = True
                ElseIf tarea.FrecuSemanal Then
                    diaCorrecto = Fx_DiaDeLaSemanaValido(tarea, horaActual.DayOfWeek)
                End If

                If diaCorrecto Then
                    ' 2A. SUCEDE UNA VEZ
                    If tarea.SucedeUnaVez Then
                        If horaActual.Hour = tarea.HoraUnaVez.Hour AndAlso horaActual.Minute = tarea.HoraUnaVez.Minute Then
                            ' Ejecutamos solo si han pasado más de 50 segundos desde la última vez 
                            ' (Evita 60 ejecuciones múltiples en el mismo minuto)
                            If (horaActual - ultimaVez).TotalSeconds > 50 Then
                                tocaEjecutar = True
                            End If
                        End If
                    End If

                    ' 2B. LÓGICA DE INTERVALOS
                    If tarea.SucedeCada Then
                        ' Matemática absoluta y precisa para los segundos del día (Sin usar CInt)
                        Dim segActuales As Integer = (horaActual.Hour * 3600) + (horaActual.Minute * 60) + horaActual.Second
                        Dim segInicio As Integer = (tarea.ApartirDeCada.Hour * 3600) + (tarea.ApartirDeCada.Minute * 60) + tarea.ApartirDeCada.Second
                        Dim segFin As Integer = (tarea.FinalizaCada.Hour * 3600) + (tarea.FinalizaCada.Minute * 60) + tarea.FinalizaCada.Second

                        If segFin = 0 Then segFin = 86399 ' Asumimos las 23:59:59 si no hay hora de fin definida

                        ' Validamos que estemos dentro de la ventana de tiempo
                        If segActuales >= segInicio AndAlso segActuales <= segFin Then

                            Dim tipo As String = If(String.IsNullOrEmpty(tarea.TipoIntervaloCada), "", tarea.TipoIntervaloCada.ToUpper())
                            Dim intervaloSegundos As Integer = 0

                            If tipo.Contains("HORA") OrElse tipo = "HH" Then
                                intervaloSegundos = tarea.IntervaloCada * 3600
                            ElseIf tipo.Contains("SEGUNDO") OrElse tipo = "SS" Then
                                intervaloSegundos = tarea.IntervaloCada
                            Else
                                intervaloSegundos = tarea.IntervaloCada * 60 ' Asumimos Minutos ("MM")
                            End If

                            If intervaloSegundos > 0 Then
                                If ultimaVez = DateTime.MinValue Then
                                    ' PRIMERA VEZ: Esperamos a que el reloj se alinee matemáticamente con el inicio
                                    ' Se aplica una tolerancia de 3 segundos para atrapar el tick
                                    Dim residuo As Integer = (segActuales - segInicio) Mod intervaloSegundos
                                    If residuo <= 3 Then
                                        tocaEjecutar = True
                                    End If
                                Else
                                    ' EJECUCIONES SIGUIENTES: A prueba de fallos. 
                                    ' Si ya pasó la cantidad de segundos configurada, dispara.
                                    If (horaActual - ultimaVez).TotalSeconds >= intervaloSegundos Then
                                        tocaEjecutar = True
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

                ' EJECUCIÓN FINAL:
                If tocaEjecutar Then
                    ' Guardamos la hora exacta en la que se disparó para calcular el siguiente ciclo
                    _DictUltimaEjecucion(tarea.Nombre) = horaActual

                    Sb_AddToLog("Demonio", "Ejecutando tarea programada: [" & tarea.Nombre & "]", Txt_Log)

                    Dim msg = _CL_ProcesaDatos.Fx_RellenarInterStock(Txt_Log)

                    If msg.EsCorrecto Then
                        Sb_AddToLog("Éxito", "Tarea [" & tarea.Nombre & "] finalizada: " & msg.Mensaje, Txt_Log)
                    Else

                        Sb_AddToLog("Error", "Fallo en tarea [" & tarea.Nombre & "]: " & msg.Mensaje, Txt_Log)
                        Exit For

                    End If
                    Sb_AddToLog("Actualizando", "Iniciando la actualizacion de precios: ", Txt_Log)

                    Dim MensajePrecio As Mensajes
                    MensajePrecio = _CL_ProcesaDatos.actualiza_precio()
                    If MensajePrecio.EsCorrecto Then
                        Sb_AddToLog("SincroStock", "Precios actualizados correctamente: " & MensajePrecio.Mensaje, Txt_Log)
                    Else

                        Sb_AddToLog("SincroStock", "Error al actualizar precios: " & MensajePrecio.Mensaje, Txt_Log)
                        Exit For

                    End If

                    Dim r = _CL_ProcesaDatos.GenerarDocumentos(Txt_Log)
                    If r.EsCorrecto Then
                        Sb_AddToLog("SincroStock", "Documentos generados correctamente: " & r.Mensaje, Txt_Log)
                    Else

                        Sb_AddToLog("SincroStock", "Error al generar documentos: " & r.Mensaje, Txt_Log)
                        Exit For

                    End If

                    Exit For
                End If
            Next

        Catch ex As Exception
            Sb_AddToLog("Error Demonio", "Fallo general en ejecución: " & ex.Message, Txt_Log)
        End Try

        ' Reanudamos el reloj
        Timer_Ejecutar.Start()
    End Sub

    Private Sub Ejecucion()
    End Sub

    Private Function Fx_DiaDeLaSemanaValido(tarea As Cl_NewProgramacion, diaActual As DayOfWeek) As Boolean
        Select Case diaActual
            Case DayOfWeek.Monday : Return tarea.Lunes
            Case DayOfWeek.Tuesday : Return tarea.Martes
            Case DayOfWeek.Wednesday : Return tarea.Miercoles
            Case DayOfWeek.Thursday : Return tarea.Jueves
            Case DayOfWeek.Friday : Return tarea.Viernes
            Case DayOfWeek.Saturday : Return tarea.Sabado
            Case DayOfWeek.Sunday : Return tarea.Domingo
            Case Else : Return False
        End Select
    End Function

    Private Sub Timer_Limpiar_Tick(sender As Object, e As EventArgs) Handles Timer_Limpiar.Tick
        Timer_Limpiar.Stop()

        ' Limpiamos el texto del log cada cierto tiempo para que el programa no consuma toda la RAM
        Txt_Log.Text = String.Empty
        Sb_AddToLog("SincroStock", "Limpieza de Log automática.", Txt_Log)

        Timer_Limpiar.Start()
    End Sub

    Private Sub Timer_AjustarFecha_Tick(sender As Object, e As EventArgs) Handles Timer_AjustarFecha.Tick
        Dtp_FechaRevision.Value = Now.Date
        Sb_AddToLog("SincroStock", "Se actualiza la fecha de revisión: " & Dtp_FechaRevision.Value, Txt_Log)
    End Sub

    Private Sub Bar1_ItemClick(sender As Object, e As EventArgs) Handles Bar1.ItemClick
    End Sub

    Private Sub Switch_Sincronizacion_ValueChanged(sender As Object, e As EventArgs) Handles Switch_Sincronizacion.ValueChanged
        If Timer_Ejecutar.Enabled Then
            Timer_Ejecutar.Stop()
            If Timer_Limpiar.Enabled Then
                Timer_Limpiar.Stop()
            End If
            CircularPgrs.IsRunning = False
            Sb_AddToLog("SincroStock", "Demonio de Sincronización detenido por el usuario.", Txt_Log)
        Else
            Timer_Ejecutar.Start()
            If Timer_Limpiar.Enabled = False Then
                Timer_Limpiar.Start()
            End If

            CircularPgrs.IsRunning = True
            Sb_AddToLog("SincroStock", "Demonio de Sincronización reanudado por el usuario.", Txt_Log)
        End If
    End Sub

    Private Sub Btn_Limpiar_Click(sender As Object, e As EventArgs) Handles Btn_Limpiar.Click
        Timer_Limpiar.Stop()

        ' Limpiamos el texto del log cada cierto tiempo para que el programa no consuma toda la RAM
        Txt_Log.Text = String.Empty
        Sb_AddToLog("SincroStock", "Limpieza de Log manual.", Txt_Log)

        Timer_Limpiar.Start()
    End Sub

    Private Sub Txt_Log_TextChanged(sender As Object, e As EventArgs) Handles Txt_Log.TextChanged
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


    End Sub
End Class
