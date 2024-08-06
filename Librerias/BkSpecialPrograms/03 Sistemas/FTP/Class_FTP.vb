Imports System.Net
Imports System.IO
Imports System.Text
Imports DevComponents.DotNetBar
Imports System.Data.SqlClient
Imports System.Net.WebRequestMethods

'El método subirFichero recibe tres argumentos:

'fichero: Ruta local del fichero
'destino: Dirección FTP del destino del fichero. Ej: "ftp://ftp.BAKAPP.cl/Negocios/fichero.txt"
'dir: Dirección FTP del directorio donde se almacenará el fichero. Ej: "ftp://ftp.BAKAPP.cl/Negocios"

Public Class Class_FTP

    Public Property Zw_Ftp_Conexiones As New Zw_Ftp_Conexiones

    Dim host, user, pass As String
    Dim _Proxy_Usa As Boolean
    Dim _Proxy_Host, _Proxy_Dominio, _Proxy_User, _Proxy_Pass As String

    Public Sub New(host As String,
                   user As String,
                   pass As String)

        'Usa_Proxy As Boolean, _
        'Proxy_Host As String, _
        'Proxy_Dominio As String, _
        'Proxy_User As String, _
        'Proxy_Pass As String)

        Me.host = host
        Me.user = user
        Me.pass = pass

        '_Usa_Proxy = Usa_Proxy
        '_Proxy_Host = _Proxy_Host
        '_Proxy_Dominio = Proxy_Dominio
        '_Proxy_User = Proxy_User
        '_Proxy_Pass = Proxy_Pass

    End Sub

    Enum Info
        Size
        Fecha_creacion
    End Enum


    Public Function Fx_Eliminar_Fichero_Ftp(_Fichero As String) As String

        Dim peticionFTP As FtpWebRequest
        Dim Fm As New Frm_Form_Esperar
        Fm.BarraCircular.IsRunning = True
        Fm.Show()

        Try

            ' Creamos una petición FTP con la dirección del fichero a eliminar
            peticionFTP = CType(WebRequest.Create(New Uri(_Fichero)), FtpWebRequest)

            ' Fijamos el usuario y la contraseña de la petición
            peticionFTP.Credentials = New NetworkCredential(user, pass)

            ' Seleccionamos el comando que vamos a utilizar: Eliminar un fichero
            peticionFTP.Method = WebRequestMethods.Ftp.DeleteFile
            peticionFTP.UsePassive = False
        Catch ex As Exception
            Return ex.Message
        Finally
            Fm.Close()
        End Try

        Try
            Dim respuestaFTP As FtpWebResponse
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuestaFTP.Close()
            ' Si todo ha ido bien, devolvemos String.Empty
            Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            Return ex.Message
        End Try
    End Function

    Public Function Fx_Renombrar_Fichero_Ftp(_Fichero As String, _NewName As String) As String
        Dim peticionFTP As FtpWebRequest

        ' Creamos una petición FTP con la dirección del fichero a eliminar
        peticionFTP = CType(WebRequest.Create(New Uri(_Fichero)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Seleccionamos el comando que vamos a utilizar: Renombrar fichero
        peticionFTP.Method = WebRequestMethods.Ftp.Rename
        peticionFTP.RenameTo() = _NewName

        Try
            Dim respuestaFTP As FtpWebResponse
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuestaFTP.Close()
            ' Si todo ha ido bien, devolvemos String.Empty
            Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            Return ex.Message
        End Try
    End Function
    Private Sub RenameFileOnServer(TheServerURL As String, OldFile As String, NewName As String)

        Dim MyFtpWebRequest As System.Net.FtpWebRequest = CType(System.Net.FtpWebRequest.Create(TheServerURL & OldFile), FtpWebRequest)
        MyFtpWebRequest.Credentials = New System.Net.NetworkCredential(user, pass)
        MyFtpWebRequest.Method = System.Net.WebRequestMethods.Ftp.Rename
        MyFtpWebRequest.RenameTo() = NewName
        Dim MyResponse As System.Net.FtpWebResponse

        Try
            MyResponse = CType(MyFtpWebRequest.GetResponse, FtpWebResponse)

            Dim MyStatusStr As String = MyResponse.StatusDescription
            Dim MyStatusCode As System.Net.FtpStatusCode = MyResponse.StatusCode

            If MyStatusCode <> Net.FtpStatusCode.FileActionOK Then
                MessageBox.Show("*** Rename " & OldFile & " to " & NewName & " failed.  Returned status = " & MyStatusStr)
            Else
                MessageBox.Show("Rename " & OldFile & " to " & NewName & " ok at " & Now.ToString)
            End If
        Catch ex As Exception
            MessageBox.Show("*** Rename " & OldFile & " to " & NewName & " failed due to the following error: " & ex.Message)

        End Try

    End Sub

    Public Function Fx_Existe_Archivo(_Dir As String) As Boolean

        Dim peticionFTP As FtpWebRequest

        Try
            ' Creamos una peticion FTP con la dirección del objeto que queremos saber si existe
            peticionFTP = CType(WebRequest.Create(New Uri(_Dir)), FtpWebRequest)
            Dim f = New Uri(_Dir)
            ' Fijamos el usuario y la contraseña de la petición
            peticionFTP.Credentials = New NetworkCredential(user, pass)

            ' Para saber si el objeto existe, solicitamos la fecha de creación del mismo
            peticionFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp

            peticionFTP.UsePassive = False

            ' Si el objeto existe, se devolverá True
            Dim respuestaFTP As FtpWebResponse
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
            Return True
        Catch ex As Exception
            ' Si el objeto no existe, se producirá un error y al entrar por el Catch
            ' se devolverá falso
            'MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Public Function Fx_Existe_Directorio(_Dir As String) As Boolean

        Dim peticionFTP As FtpWebRequest
        '"http://proxyserver:port"
        Dim myProxy As New WebProxy(_Proxy_Host, True)
        myProxy.Credentials = New NetworkCredential(_Proxy_User, _Proxy_Pass, _Proxy_Dominio)

        'Dim myProxy As New WebProxy()
        'myProxy.Address = New Uri("proxyAddress")
        'myProxy.Credentials = New NetworkCredential("username", "password")
        ' myWebRequest.Proxy = myProxy

        ' Creamos una peticion FTP con la dirección del objeto que queremos saber si existe
        peticionFTP = CType(WebRequest.Create(New Uri(_Dir)), FtpWebRequest)
        If _Proxy_Usa Then
            peticionFTP.Proxy = myProxy
        Else
            peticionFTP.Proxy = Nothing
        End If


        Dim f = New Uri(_Dir)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Para saber si el objeto existe, solicitamos la fecha de creación del mismo
        peticionFTP.Method = WebRequestMethods.Ftp.PrintWorkingDirectory

        peticionFTP.UsePassive = False

        Try
            ' Si el objeto existe, se devolverá True
            Dim respuestaFTP As FtpWebResponse
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
            Return True
        Catch ex As Exception
            ' Si el objeto no existe, se producirá un error y al entrar por el Catch
            ' se devolverá falso
            'MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Public Function Fx_Crear_Directorio(_Dir As String) As String

        Dim peticionFTP As FtpWebRequest
        Try

            ' Creamos una peticion FTP con la dirección del directorio que queremos crear
            peticionFTP = CType(WebRequest.Create(New Uri(_Dir)), FtpWebRequest)

            ' Fijamos el usuario y la contraseña de la petición
            peticionFTP.Credentials = New NetworkCredential(user, pass)

            ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
            peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory
        Catch ex As Exception
            Return ex.Message
        End Try
        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            Return ex.Message
        End Try

    End Function

    Public Function Fx_Subir_Fichero_oLD(_Fichero As String,
                                     _Destino As String,
                                     _Dir As String) As String

        Dim _InfoFichero As New FileInfo(_Fichero)

        Dim uri As String
        uri = _Destino
        Dim peticionFTP As FtpWebRequest
        Dim num As Integer

        ' Abrimos el fichero para subirlo
        Dim fs As FileStream

        ' Fijamos un buffer de 2KB
        Dim longitudBuffer As Integer
        longitudBuffer = 2048
        Dim lector As Byte() = System.IO.File.ReadAllBytes(_Fichero) 'New Byte(2048) {}
        'Dim lector As Byte() = System.IO.File.ReadAllBytes(_Fichero) 'New Byte(2048) {}
        'Dim bFile() As Byte = System.IO.File.ReadAllBytes(_Fichero)

        Try

            ' Si no existe el directorio, lo creamos
            If Not Fx_Existe_Directorio(_Dir) Then
                Fx_Crear_Directorio(Dir)
            End If

            ' Creamos una peticion FTP con la dirección del fichero que vamos a subir
            peticionFTP = CType(FtpWebRequest.Create(New Uri(_Destino)), FtpWebRequest)

            ' Fijamos el usuario y la contraseña de la petición
            peticionFTP.Credentials = New NetworkCredential(user, pass)

            ''peticionFTP.KeepAlive = False
            ''peticionFTP.UsePassive = False

            ' Seleccionamos el comando que vamos a utilizar: Subir un fichero
            peticionFTP.Method = WebRequestMethods.Ftp.UploadFile

            ' Especificamos el tipo de transferencia de datos
            ''peticionFTP.UseBinary = True

            ' Informamos al servidor sobre el tamaño del fichero que vamos a subir
            ''peticionFTP.ContentLength = _InfoFichero.Length
            ''fs = _InfoFichero.OpenRead()

        Catch ex As Exception
            Return ex.Message
        End Try

        Try
            Dim bFile() As Byte = System.IO.File.ReadAllBytes(_Fichero)
            Dim clsStream As System.IO.Stream =
            peticionFTP.GetRequestStream()
            clsStream.Write(bFile, 0, bFile.Length)
            clsStream.Close()
            clsStream.Dispose()
        Catch ex As Exception
            Return ex.Message + ". El Archivo no pudo ser enviado, intente en otro momento"
        End Try


        Exit Function

        Try
            Dim escritor As Stream
            escritor = peticionFTP.GetRequestStream()

            ' Leemos 2 KB del fichero en cada iteración
            num = fs.Read(lector, 0, longitudBuffer)

            While (num <> 0)
                ' Escribimos el contenido del flujo de lectura en el 
                ' flujo de escritura del comando FTP
                'escritor.Write(bFile, 0, bFile.Length) 
                escritor.Write(lector, 0, num)

                num = fs.Read(lector, 0, longitudBuffer)
            End While

            '          miStream.Write(bFile, 0, bFile.Length)
            '          miStream.Close()
            '          miStream.Dispose()

            escritor.Close()
            fs.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            Return ex.Message
        End Try
    End Function

    Public Function Fx_Subir_Fichero(_Fichero As String,
                                     _Destino As String)

        Dim Fm As New Frm_Form_Esperar
        Fm.BarraCircular.IsRunning = True
        Fm.Show()

        Dim clsRequest As System.Net.FtpWebRequest
        Dim conexion As Net.Sockets.TcpClient
        clsRequest = DirectCast(System.Net.WebRequest.Create(_Destino), System.Net.FtpWebRequest)
        clsRequest.Proxy = Nothing ' Esta asignación es importantisimo con los que trabajen en windows XP ya que por defecto esta propiedad esta para ser asignado a un servidor http lo cual ocacionaria un error si deseamos conectarnos con un FTP, en windows Vista y el Seven no tube este problema.
        clsRequest.Credentials = New System.Net.NetworkCredential(user, pass) ' Usuario y password de acceso al server FTP, si no tubiese, dejar entre comillas, osea ""
        clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile
        Try
            Dim bFile() As Byte = System.IO.File.ReadAllBytes(_Fichero)
            Dim clsStream As System.IO.Stream =
            clsRequest.GetRequestStream()
            clsStream.Write(bFile, 0, bFile.Length)
            clsStream.Close()
            clsStream.Dispose()
            Return ""
        Catch ex As Exception
            Return ex.Message + ". El Archivo no pudo ser enviado, intente en otro momento"
        Finally
            Fm.Close()
        End Try

    End Function
    Public Function Fx_Descargar_Fichero(_Destino As String,
                                         _Fichero As String)

        Dim peticionFTP As FtpWebRequest

        Dim Fm As New Frm_Form_Esperar
        Fm.BarraCircular.IsRunning = True
        Fm.Show()

        Try

            ' Creamos una peticion FTP con la dirección del fichero que vamos a subir
            peticionFTP = CType(FtpWebRequest.Create(New Uri(_Destino)), FtpWebRequest)

            ' Fijamos el usuario y la contraseña de la petición
            peticionFTP.Credentials = New NetworkCredential(user, pass)


            ' El comando a ejecutar usando la enumeración de WebRequestMethods.Ftp
            peticionFTP.Method = WebRequestMethods.Ftp.DownloadFile

            ' Obtener el resultado del comando
            Dim reader As New StreamReader(peticionFTP.GetResponse().GetResponseStream())

            ' Leer el stream (el contenido del archivo)
            Dim res As String = reader.ReadToEnd()

            ' Mostrarlo.
            'Console.WriteLine(res)

            ' Guardarlo localmente con la extensión .txt
            Dim ficLocal As String = Path.Combine(_Fichero, Path.GetFileName(_Destino))
            Dim sw As New StreamWriter(ficLocal, False, Encoding.Default)
            sw.Write(res)
            sw.Close()

            ' Cerrar el stream abierto.
            reader.Close()
        Catch ex As Exception
            Return ex.Message
        Finally
            Fm.Close()
        End Try
        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            Return ex.Message
        End Try

    End Function

    Public Function Fx_Obtener_Archivos_Directorio(ByRef _Dir As String) As List(Of String)

        Dim peticionFTP As FtpWebRequest
        Dim listaRutas As List(Of String) = New List(Of String)
        Try

            ' Creamos una peticion FTP con la dirección del directorio que queremos crear
            peticionFTP = CType(WebRequest.Create(New Uri(_Dir)), FtpWebRequest)
            'peticionFTP = CType(WebRequest.Create(_Dir), FtpWebRequest)
            ' Fijamos el usuario y la contraseña de la petición
            peticionFTP.Credentials = New NetworkCredential(user, pass)

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

            For Each _F As String In _Archivos

                If _F <> "." And _F <> ".." And Not String.IsNullOrEmpty(_F) Then

                    Dim _Size = Fx_Obtener_Size_Archivo(_Dir & "/" & _F)
                    Dim _Fecha = Fx_Obtener_Fecha_Archivo(_Dir & "/" & _F)

                    If Not String.IsNullOrEmpty(Trim(_F)) Then
                        listaRutas.Add(_F & ";" & _Size & ";" & _Fecha)
                    End If
                End If

            Next

            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()

            ' Si todo ha ido bien, se devolverá String.Empty
            Return listaRutas
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            listaRutas.Add(ex.Message)
            Return listaRutas
        End Try

    End Function
    Public Function Fx_Obtener_Size_Archivo(_Destino As String) As String
        Dim peticionFTP As FtpWebRequest

        ' Creamos una peticion FTP con la dirección del objeto que queremos saber si existe
        peticionFTP = CType(WebRequest.Create(New Uri(_Destino)), FtpWebRequest)
        Dim f = New Uri(_Destino)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

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
        peticionFTP.Credentials = New NetworkCredential(user, pass)

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
    Public Function Fx_Verificar_Conexion_FTP(_Fm As Form,
                                               _Host As String,
                                               Optional _Puerto As Integer = 21) As Boolean

        Dim ClienteFtp As New Sockets.TcpClient
        Try
            ClienteFtp.Connect(_Host, _Puerto) ' ojo, solo IP del server FTP
            Return True ' si devuelve True significa que hay conexion
        Catch Ex As Exception
            ' escriba el mensaje que mas te salve del apuro
            MessageBoxEx.Show(_Fm, Ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False ' si devuelve False significa que tienes que ir corriendo a ver que pasa en el server
        End Try
    End Function



    Public Sub Sb_Descargar_Archivo_FTP(_RutaArchivo_Destino As String, _RutaArchivo_FTP As String)

        '  Dim localFile As String = RutaArchivo
        '  Dim remoteFile As String = NombreArchivo

        'Const host As String = "ftp://xxx.xx.xx.xxx/archivos/" 'nombre de la carpeta en nuestro server FTP donde estan los archivos que deseamos descargar
        ' colocamos el nombre de usuario y password respectivo para acceder al server, si este no poseyera, dejar solo las comillas, osea ""
        ' Const username As String = "usuario"
        ' Const password As String = "password"

        Dim URI As String = _RutaArchivo_FTP ' nombre completo de la ruta del archivo
        Dim ftp As System.Net.FtpWebRequest = CType(Net.FtpWebRequest.Create(URI), Net.FtpWebRequest)
        ftp.Credentials = New _
        System.Net.NetworkCredential(user, pass)
        ftp.KeepAlive = False
        ftp.UseBinary = True
        ftp.Method = System.Net.WebRequestMethods.Ftp.DownloadFile
        Try
            Using response As System.Net.FtpWebResponse =
            CType(ftp.GetResponse, System.Net.FtpWebResponse)
                Using responseStream As IO.Stream = response.GetResponseStream
                    Using fs As New IO.FileStream(_RutaArchivo_Destino, IO.FileMode.Create)
                        Dim buffer(2047) As Byte
                        Dim read As Integer = 0
                        Do
                            read = responseStream.Read(buffer, 0, buffer.Length)
                            fs.Write(buffer, 0, read)
                        Loop Until read = 0
                        responseStream.Close()
                        fs.Flush()
                        fs.Close()
                    End Using
                    responseStream.Close()
                End Using
                response.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
