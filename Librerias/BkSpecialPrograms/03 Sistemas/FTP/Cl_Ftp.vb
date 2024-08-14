Imports System.Data.SqlClient
Imports System.IO
Imports System.Net

Public Class Cl_Ftp

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Zw_Ftp_Conexiones As New Zw_Ftp_Conexiones

    Enum eTipo_Ftp
        Producto
        Entidad
        Documento
    End Enum

    Public Sub New()

    End Sub

    Function Fx_Llenar_Host(_Id As Integer) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Ftp_Conexiones Where Id = " & _Id
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then

            With Zw_Ftp_Conexiones

                .Id = 0
                .Tipo = String.Empty
                .Usuario = String.Empty
                .Clave = String.Empty
                .Host = String.Empty
                .Puerto = 21
                .Fichero = String.Empty
                .Carpeta_Imagenes = String.Empty
                .Carpeta_Archivos = String.Empty
                .Url_public = String.Empty

            End With

            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "No se encontro el registro en la tabla Zw_Ftp_Conexiones con el Idc " & _Id
            _Mensaje.Tag = Zw_Ftp_Conexiones

            Return _Mensaje

        End If

        'Dim Zw_Ftp_Conexiones As New Zw_Ftp_Conexiones

        With Zw_Ftp_Conexiones

            .Id = _Row.Item("Id")
            .Tipo = _Row.Item("Tipo")
            .Usuario = _Row.Item("Usuario")
            .Clave = _Row.Item("Clave")
            .Host = _Row.Item("Host")
            .Puerto = _Row.Item("Puerto")
            .Fichero = _Row.Item("Fichero")
            .Carpeta_Imagenes = _Row.Item("Carpeta_Imagenes")
            .Carpeta_Archivos = _Row.Item("Carpeta_Archivos")
            .Url_public = _Row.Item("Url_public")

        End With

        _Mensaje.EsCorrecto = True
        _Mensaje.Mensaje = "Registro encontrado."
        _Mensaje.Tag = Zw_Ftp_Conexiones

        Return _Mensaje

    End Function
    Function Fx_Grabar_Host() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Consulta_sql = String.Empty

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With Zw_Ftp_Conexiones

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Ftp_Conexiones (Tipo,Usuario,Clave,Host,Puerto,Fichero,Carpeta_Imagenes,Carpeta_Archivos,Url_public) Values " &
                               "('" & .Tipo & "','" & .Usuario & "','" & .Clave & "','" & .Host & "'," & .Puerto & ",'" & .Fichero & "','" & .Carpeta_Imagenes & "','" & .Carpeta_Archivos & "','" & .Url_public & "')"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Comando = New System.Data.SqlClient.SqlCommand("SELECT @@IDENTITY AS 'Identity'", Cn2)
                Comando.Transaction = myTrans
                Dim dfd1 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
                While dfd1.Read()
                    .Id = dfd1("Identity")
                End While
                dfd1.Close()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Grabar conexión FTP"
            _Mensaje.Mensaje = "Conexión FTP grabada con exito"
            _Mensaje.Id = Zw_Ftp_Conexiones.Id
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Error al grabar"
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Id = 0
            _Mensaje.Icono = MessageBoxIcon.Error

            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje

    End Function

    Function Fx_Editar_Host() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Consulta_sql = String.Empty

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With Zw_Ftp_Conexiones

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Ftp_Conexiones Set " & vbCrLf &
                               "Tipo = '" & .Tipo & "'" &
                               ",Usuario = '" & .Usuario & "'," &
                               "Clave = '" & .Clave & "'," &
                               "Host = '" & .Host & "'," &
                               "Puerto = " & .Puerto & "," &
                               "Fichero = '" & .Fichero & "'," &
                               "Carpeta_Imagenes = '" & .Carpeta_Imagenes & "'," &
                               "Carpeta_Archivos = '" & .Carpeta_Archivos & "'," &
                               "Url_public = '" & .Url_public & "'" & vbCrLf &
                               "Where Id = " & .Id

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Editar conexión FTP"
            _Mensaje.Mensaje = "Conexión FTP editada correctamente"
            _Mensaje.Id = Zw_Ftp_Conexiones.Id
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Error al grabar"
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Id = 0
            _Mensaje.Icono = MessageBoxIcon.Error

            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje

    End Function

    Public Function Fx_Probar_Conexion_FTP() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim ClienteFtp As New Sockets.TcpClient

        Try
            ClienteFtp.Connect(Zw_Ftp_Conexiones.Host, Zw_Ftp_Conexiones.Puerto) ' ojo, solo IP del server FTP

            Dim _Msj As LsValiciones.Mensajes = Fx_Existe_Directorio(Zw_Ftp_Conexiones.Fichero)

            If Not _Msj.EsCorrecto Then
                Throw New Exception(_Msj.Mensaje)
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Conexión exitosa."
            _Mensaje.Detalle = "Probar conexión FTP"
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch Ex As Exception

            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = Ex.Message
            _Mensaje.Detalle = "Probar conexión FTP"
            _Mensaje.Icono = MessageBoxIcon.Error

        End Try

        Return _Mensaje

    End Function

    Public Function Fx_Existe_Directorio(_Dir As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim _Proxy_Host, _Proxy_Dominio, _Proxy_User, _Proxy_Pass As String
            Dim _Proxy_Usa As Boolean

            Dim peticionFTP As FtpWebRequest
            '"http://proxyserver:port"
            Dim myProxy As New WebProxy(_Proxy_Host, True)
            myProxy.Credentials = New NetworkCredential(_Proxy_User, _Proxy_Pass, _Proxy_Dominio)

            ' Creamos una peticion FTP con la dirección del objeto que queremos saber si existe
            peticionFTP = CType(WebRequest.Create(New Uri(_Dir)), FtpWebRequest)
            If _Proxy_Usa Then
                peticionFTP.Proxy = myProxy
            Else
                peticionFTP.Proxy = Nothing
            End If

            Dim f = New Uri(_Dir)
            ' Fijamos el usuario y la contraseña de la petición
            peticionFTP.Credentials = New NetworkCredential(Zw_Ftp_Conexiones.Usuario, Zw_Ftp_Conexiones.Clave)

            ' Para saber si el objeto existe, solicitamos la fecha de creación del mismo
            peticionFTP.Method = WebRequestMethods.Ftp.PrintWorkingDirectory

            peticionFTP.UsePassive = False

            ' Si el objeto existe, se devolverá True
            Dim respuestaFTP As FtpWebResponse
            'Try
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
            'Catch ex As Exception
            'End Try

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Directorio encontrado."
            _Mensaje.Detalle = "Existe directorio FTP"
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Detalle = "Existe directorio FTP"
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function

    Public Function Fx_Existe_Directorio2(_Dir As String) As Boolean
        Dim existeDirectorio As Boolean = False

        Try
            ' Crear la solicitud FTP
            Dim request As FtpWebRequest = CType(WebRequest.Create(_Dir), FtpWebRequest)
            request.Method = WebRequestMethods.Ftp.ListDirectory
            request.Credentials = New NetworkCredential(Zw_Ftp_Conexiones.Usuario, Zw_Ftp_Conexiones.Clave)

            ' Obtener la respuesta del servidor
            Using response As FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)
                ' Si llegamos aquí, la carpeta existe
                Return True
            End Using
        Catch ex As WebException
            ' Si se lanza una excepción, verificamos si es porque la carpeta no existe
            Dim response As FtpWebResponse = CType(ex.Response, FtpWebResponse)
            If response.StatusCode = FtpStatusCode.ActionNotTakenFileUnavailable Then
                ' La carpeta no existe
                Return False
            Else
                ' Otro tipo de error
                Throw
            End If
        End Try

        Return existeDirectorio
    End Function


    Public Function Fx_Crear_Directorio(_Dir As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim peticionFTP As FtpWebRequest

        Try

            ' Creamos una peticion FTP con la dirección del directorio que queremos crear
            peticionFTP = CType(WebRequest.Create(New Uri(_Dir)), FtpWebRequest)

            ' Fijamos el usuario y la contraseña de la petición
            peticionFTP.Credentials = New NetworkCredential(Zw_Ftp_Conexiones.Usuario, Zw_Ftp_Conexiones.Clave)

            ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
            peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory

            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Directorio creado."
            _Mensaje.Detalle = "Directorio FTP creado"
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error

        End Try

        Return _Mensaje

    End Function

    Public Function Fx_Obtener_Archivos_Directorio(ByRef _Dir As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim peticionFTP As FtpWebRequest
        Dim listaRutas As List(Of String) = New List(Of String)

        Try

            ' Creamos una peticion FTP con la dirección del directorio que queremos crear
            peticionFTP = CType(WebRequest.Create(New Uri(_Dir)), FtpWebRequest)
            'peticionFTP = CType(WebRequest.Create(_Dir), FtpWebRequest)
            ' Fijamos el usuario y la contraseña de la petición
            peticionFTP.Credentials = New NetworkCredential(Zw_Ftp_Conexiones.Usuario, Zw_Ftp_Conexiones.Clave)

            ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
            peticionFTP.Method = WebRequestMethods.Ftp.ListDirectory

        Catch ex As Exception
            Return Nothing
        End Try


        Try

            ' Obtener el resultado del comando
            Dim reader As New StreamReader(peticionFTP.GetResponse().GetResponseStream())

            ' Leer el stream
            Dim res As String = reader.ReadToEnd()
            Dim _Archivos = Split(res, vbCrLf) 'res.Split

            listaRutas.Add("..;;")

            For Each _F As String In _Archivos

                If Not _F.Contains("/.") And Not String.IsNullOrEmpty(_F) Then

                    Dim _Raiz = _F.Split("/")

                    _F = _Raiz(1)

                    ' Verificar si el archivo es una carpeta
                    Dim esCarpeta As Boolean = Fx_Existe_Directorio(_Dir & "/" & _F).EsCorrecto


                    Dim _Size = Fx_Obtener_Size_Archivo(_Dir & "/" & _F)
                    Dim _Fecha = Fx_Obtener_Fecha_Archivo(_Dir & "/" & _F)

                    If Not String.IsNullOrEmpty(Trim(_F)) Then
                        listaRutas.Add(_F & ";" & _Size & ";" & _Fecha)
                    End If

                End If

                'If _F <> "." And _F <> ".." And Not String.IsNullOrEmpty(_F) Then

                '    Dim _Size = Fx_Obtener_Size_Archivo(_Dir & "/" & _F)
                '    Dim _Fecha = Fx_Obtener_Fecha_Archivo(_Dir & "/" & _F)

                '    If Not String.IsNullOrEmpty(Trim(_F)) Then
                '        listaRutas.Add(_F & ";" & _Size & ";" & _Fecha)
                '    End If

                'End If

            Next

            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Directorio encontrado."
            _Mensaje.Detalle = "Existe directorio FTP"
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Tag = listaRutas

        Catch ex As Exception

            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Detalle = "Obtener directorio FTP"
            _Mensaje.Icono = MessageBoxIcon.Error

        End Try

        Return _Mensaje

    End Function

    Public Function Fx_Obtener_Size_Archivo(_Destino As String) As String
        Dim peticionFTP As FtpWebRequest

        ' Creamos una peticion FTP con la dirección del objeto que queremos saber si existe
        peticionFTP = CType(WebRequest.Create(New Uri(_Destino)), FtpWebRequest)
        Dim f = New Uri(_Destino)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(Zw_Ftp_Conexiones.Usuario, Zw_Ftp_Conexiones.Clave)

        peticionFTP.Method = WebRequestMethods.Ftp.GetFileSize

        peticionFTP.UsePassive = False

        Try
            ' Si el objeto existe, se devolverá True
            Dim respuestaFTP As FtpWebResponse
            Dim _Informacion As Long
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)


            _Informacion = respuestaFTP.ContentLength
            Return _Informacion
        Catch ex As Exception
            ' Si el objeto no existe, se producirá un error y al entrar por el Catch
            ' se devolverá falso
            'MsgBox(ex.Message)
            Return ""
        End Try
    End Function
    Public Function Fx_Obtener_Fecha_Archivo(_Destino As String) As String

        Dim peticionFTP As FtpWebRequest

        ' Creamos una peticion FTP con la dirección del objeto que queremos saber si existe
        peticionFTP = CType(WebRequest.Create(New Uri(_Destino)), FtpWebRequest)
        Dim f = New Uri(_Destino)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(Zw_Ftp_Conexiones.Usuario, Zw_Ftp_Conexiones.Clave)

        peticionFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp

        peticionFTP.UsePassive = False

        Try
            ' Si el objeto existe, se devolverá True
            Dim respuestaFTP As FtpWebResponse
            Dim _Informacion As String
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)

            _Informacion = respuestaFTP.LastModified.ToString

            Return _Informacion

        Catch ex As Exception
            ' Si el objeto no existe, se producirá un error y al entrar por el Catch
            ' se devolverá falso
            'MsgBox(ex.Message)
            Return ""
        End Try

    End Function

    Public Function AccederCarpetaFTP(_Url_Directorio As String) As List(Of String)
        Dim listaArchivos As New List(Of String)

        Try
            ' Crear la solicitud FTP
            Dim solicitud As FtpWebRequest = CType(WebRequest.Create(_Url_Directorio), FtpWebRequest)
            solicitud.Method = WebRequestMethods.Ftp.ListDirectory
            solicitud.Credentials = New NetworkCredential(Zw_Ftp_Conexiones.Usuario, Zw_Ftp_Conexiones.Clave)

            ' Obtener la respuesta del servidor
            Using respuesta As FtpWebResponse = CType(solicitud.GetResponse(), FtpWebResponse)
                ' Leer el contenido de la carpeta
                Using stream As Stream = respuesta.GetResponseStream()
                    Using reader As New StreamReader(stream)
                        While Not reader.EndOfStream
                            Dim archivo As String = reader.ReadLine()
                            listaArchivos.Add(archivo)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As WebException
            ' Manejar cualquier error de conexión o autenticación
            Console.WriteLine("Error al acceder a la carpeta FTP: " & ex.Message)
        End Try

        Return listaArchivos
    End Function

End Class
