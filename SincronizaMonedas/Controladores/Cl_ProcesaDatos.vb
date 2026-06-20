Imports System.Data.SqlClient
Imports System.IO
Imports BkSpecialPrograms
Imports BkSpecialPrograms.LsValiciones
Imports Newtonsoft.Json

Public Class Cl_ProcesaDatos
    Dim _SqlRandom As Class_SQL
    Dim _Consulta_sql As String
    Public Property DirectorioActual As String
    Public Property NombreArchivo_Configuracion As String
    Public Property Configuracion As Configuracion

    Dim Monedas As Monedas_BakApp.Monedas
    Private Diccionario As MonedasDiccionario

    Public Sub New()
        ' Ahora solo necesitamos conectarnos a la base de datos de Random/Bakapp
        _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)
    End Sub

    ''' <summary>
    ''' Lee y valida el archivo JSON de configuración de monedas.
    ''' </summary>
    Function Fx_LeerArchivoMonedasJson() As LsValiciones.Mensajes
        Dim _Mensaje As New LsValiciones.Mensajes

        Try
            Dim rutaArchivo As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Monedas.json")

            ' 1. Validar si el archivo existe
            If Not File.Exists(rutaArchivo) Then
                _Mensaje.Detalle = "Falta archivo de configuración"
                Throw New System.Exception("Debe configurar la asignación de monedas (UF, Dólar, Euro).")
            End If

            ' 2. Leer el archivo y deserializar
            Dim jsonString As String = File.ReadAllText(rutaArchivo)
            Dim miConfig As MonedasDiccionario = JsonConvert.DeserializeObject(Of MonedasDiccionario)(jsonString)

            ' 3. Validar que los DataTables internos no estén vacíos ni nulos
            If miConfig.uf Is Nothing OrElse miConfig.uf.Rows.Count = 0 OrElse
               miConfig.eur Is Nothing OrElse miConfig.eur.Rows.Count = 0 OrElse
               miConfig.usd Is Nothing OrElse miConfig.usd.Rows.Count = 0 Then

                _Mensaje.Detalle = "Datos incompletos"
                Throw New System.Exception("Faltan monedas por configurar. Por favor, asigne las monedas correspondientes.")
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Monedas leídas correctamente"
            _Mensaje.Tag = miConfig

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Id = 0
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje
    End Function

    ''' <summary>
    ''' Descarga valores de monedas y las actualiza en la BD para todos los KOMO asociados.
    ''' </summary>
    Public Async Function PreCargaAsync(Txt_Log As Object) As Task

        Monedas = Await Monedas_BakApp.Monedas.CrearYCargarAsync()
        Sb_AddToLog("Demonio Monedas", "Moneda cargada: Eur= " & Monedas.EUR & " USD= " & Monedas.USD & " Uf= " & Monedas.UF, Txt_Log)

        Dim mensaje As LsValiciones.Mensajes = Fx_LeerArchivoMonedasJson()
        Dim config As MonedasDiccionario

        If Not mensaje.EsCorrecto Then
            Sb_AddToLog("Demonio Monedas", "Error al cargar monedas: " & mensaje.Mensaje, Txt_Log)
            Return
        Else
            config = CType(mensaje.Tag, MonedasDiccionario)
            Sb_AddToLog("Demonio Monedas", "Configuración de monedas validada correctamente.", Txt_Log)
        End If

        Dim Cn2 As New System.Data.SqlClient.SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        Try
            ' Abrimos la conexión una sola vez para procesar todo
            SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

            ' 1. Procesar UF
            If Monedas Is Nothing OrElse Monedas.UF = 0 Then
                Sb_AddToLog("Demonio Monedas", "Valor de la UF no disponible. No se actualizará.", Txt_Log)
            Else
                Sb_ActualizarMonedasEnBD("UF", Monedas.UF, config.uf, Cn2, Txt_Log)
            End If

            ' 2. Procesar USD
            If Monedas Is Nothing OrElse Monedas.USD = 0 Then
                Sb_AddToLog("Demonio Monedas", "Valor del Dólar no disponible. No se actualizará.", Txt_Log)
            Else
                Sb_ActualizarMonedasEnBD("USD", Monedas.USD, config.usd, Cn2, Txt_Log)
            End If

            ' 3. Procesar EUR
            If Monedas Is Nothing OrElse Monedas.EUR = 0 Then
                Sb_AddToLog("Demonio Monedas", "Valor del Euro no disponible. No se actualizará.", Txt_Log)
            Else
                Sb_ActualizarMonedasEnBD("EUR", Monedas.EUR, config.eur, Cn2, Txt_Log)
            End If

        Catch ex As Exception
            Sb_AddToLog("Demonio Monedas", "Error de base de datos durante la actualización: " & ex.Message, Txt_Log)
        Finally
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)
        End Try

    End Function

    ''' <summary>
    ''' Método auxiliar que itera sobre los KOMO de una moneda y ejecuta las consultas.
    ''' </summary>
    Private Sub Sb_ActualizarMonedasEnBD(NombreMoneda As String, ValorMoneda As Double, TablaKomo As DataTable, Cn2 As SqlConnection, Txt_Log As Object)
        Dim valFormateado As String = ValorMoneda.ToString().Replace(",", ".")

        ' Recorremos cada fila de la configuración (cada KOMO asignado a esta moneda)
        For Each fila As DataRow In TablaKomo.Rows
            Dim codigoKomo As String = fila("Codigo").ToString().Trim()

            _Consulta_sql = $"
                -- Actualizar TABMO siempre
                UPDATE TABMO 
                SET VAMO = {valFormateado}, FEMO = CAST(GETDATE() AS DATE) 
                WHERE KOMO = '{codigoKomo}';

                -- Insertar en MAEMO validando solo contra el ÚLTIMO registro ingresado
                IF NOT EXISTS (
                    SELECT 1 
                    FROM (
                        SELECT TOP 1 VAMO, FEMO 
                        FROM MAEMO 
                        WHERE KOMO = '{codigoKomo}' 
                        ORDER BY IDMAEMO DESC
                    ) UltimoRegistro
                    WHERE UltimoRegistro.VAMO = {valFormateado} 
                      AND CAST(UltimoRegistro.FEMO AS DATE) = CAST(GETDATE() AS DATE)
                )
                BEGIN
                    INSERT INTO MAEMO (KOMO, TIMO, NOKOMO, VAMO, FEMO, VAMOCOM)
                    SELECT KOMO, TIMO, NOKOMO, {valFormateado}, CAST(GETDATE() AS DATE), VAMOCOM 
                    FROM TABMO WHERE KOMO = '{codigoKomo}';
                END
            "

            Try
                Dim Comando As New SqlCommand(_Consulta_sql, Cn2)
                Dim filasAfectadas As Integer = Comando.ExecuteNonQuery()

                If filasAfectadas > 1 Then
                    Sb_AddToLog("Demonio Monedas", $"{NombreMoneda} ({codigoKomo}) actualizada en TABMO e histórico nuevo guardado en MAEMO.", Txt_Log)
                ElseIf filasAfectadas = 1 Then
                    Sb_AddToLog("Demonio Monedas", $"{NombreMoneda} ({codigoKomo}) actualizada en TABMO. Se omitió MAEMO (el último registro de hoy tiene el mismo valor).", Txt_Log)
                Else
                    Sb_AddToLog("Demonio Monedas", $"Advertencia: No se encontró la moneda {NombreMoneda} ({codigoKomo}) en TABMO para actualizar.", Txt_Log)
                End If
            Catch ex As Exception
                Sb_AddToLog("Demonio Monedas", $"Error al actualizar {NombreMoneda} ({codigoKomo}) en BD: " & ex.Message, Txt_Log)
            End Try
        Next
    End Sub

    Public Function Fx_Testear_Conexion(Txt_Log As Object) As Mensajes
        Dim _Mensaje As New Mensajes
        Dim Cn2 As New SqlConnection
        _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)

        Try
            Dim Consulta_sql_test As String = "SELECT 1"
            Dim _Tbl_Prueba As DataTable = _SqlRandom.Fx_Get_DataTable(Consulta_sql_test)

            If Not IsNothing(_Tbl_Prueba) AndAlso _Tbl_Prueba.Rows.Count > 0 Then
                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "tick recibido"
                _Mensaje.Mensaje = "OK."
                Sb_AddToLog("Demonio Monedas", "Tick Correcto: " & _Mensaje.Mensaje, Txt_Log)
                Return _Mensaje
            Else
                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "tick recibido"
                _Mensaje.Mensaje = "ERROR."
                Sb_AddToLog("Demonio Monedas", "Tick Incorrecto: " & _Mensaje.Mensaje, Txt_Log)
                Return _Mensaje
            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "conexion fallida"
            _Mensaje.Mensaje = "ERROR."
            Sb_AddToLog("Demonio Monedas", "Sin Conexion: " & _Mensaje.Mensaje, Txt_Log)
            Return _Mensaje
        End Try
    End Function

End Class
