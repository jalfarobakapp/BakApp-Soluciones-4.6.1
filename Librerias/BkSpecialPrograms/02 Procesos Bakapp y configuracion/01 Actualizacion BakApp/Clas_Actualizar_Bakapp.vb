Imports System.IO
Imports System.Net

Public Class Clas_Actualizar_Bakapp

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Host As String
    Dim _User As String
    Dim _Pass As String

    Dim _Dir_Temp = AppPath() & "\Data\Tmp\Actualizacion"
    Dim _Nombre_Archivo As String
    Dim _Ruta_Y_Archivo_Actualizacion As String
    Dim _Directorio As String
    Dim _URL_Descarga As String
    Dim _Nro_Version_Nueva As Integer
    Dim _Error As String

    Public Property Host As String
        Get
            Return _Host
        End Get
        Set(value As String)
            _Host = value
        End Set
    End Property

    Public Property User As String
        Get
            Return _User
        End Get
        Set(value As String)
            _User = value
        End Set
    End Property

    Public Property Pass As String
        Get
            Return _Pass
        End Get
        Set(value As String)
            _Pass = value
        End Set
    End Property

    Public Property Ruta_Y_Archivo_Actualizacion As String
        Get
            Return _Ruta_Y_Archivo_Actualizacion
        End Get
        Set(value As String)
            _Ruta_Y_Archivo_Actualizacion = value
        End Set
    End Property

    Public Property URL_Descarga As String
        Get
            Return _URL_Descarga
        End Get
        Set(value As String)
            _URL_Descarga = value
        End Set
    End Property

    Public Property Nro_Version_Nueva As Integer
        Get
            Return _Nro_Version_Nueva
        End Get
        Set(value As Integer)
            _Nro_Version_Nueva = value
        End Set
    End Property

    Public Property Nombre_Archivo As String
        Get
            Return _Nombre_Archivo
        End Get
        Set(value As String)
            _Nombre_Archivo = value
        End Set
    End Property

    Public Property [Error] As String
        Get
            Return _Error
        End Get
        Set(value As String)
            _Error = value
        End Set
    End Property

    Public Property Directorio As String
        Get
            Return _Directorio
        End Get
        Set(value As String)
            _Directorio = value
        End Set
    End Property

    Public Sub New() '(Host_Ftp As String, User As String, Pass As String, URL_Descarga As String)

        ' Si este FTP no funciona, prueba con otro ;-)))

        '_Host = Host '"ftp://201.148.105.132" 
        '_User = User ' "Descargas@bakapp.cl"
        '_Pass = Pass ' "EVF55-DEAsEE"

        ' _Directorio = ftp://201.148.105.132/BakApp/Empresas/"RutEmpresa"/
        ' _URL_Descarga = http://www.bakapp.cl/bakapp.cl/Descargas/BakApp/Versiones

        'listarFTP(_Host & "/BakApp/Versiones/", _User, _Pass)

        If Not Directory.Exists(_Dir_Temp) Then
            System.IO.Directory.CreateDirectory(_Dir_Temp)
        End If

        If Not Directory.Exists(_Dir_Temp & "\Versiones") Then
            System.IO.Directory.CreateDirectory(_Dir_Temp & "\Versiones")
        End If

        _Dir_Temp = _Dir_Temp & "\Versiones"

        Sb_Actualizar_Tabla_FTP_ACTUALIZCION()

    End Sub

    Sub Sb_Actualizar_Tabla_FTP_ACTUALIZCION()

        Dim _Tabla = "FTP_ACTUALIZACION"
        Dim _DescripcionTabla = "Datos FTP para Actualizacion"

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','Host','ftp://201.148.105.132')" 'Sitio FTP
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','User','Descargas@bakapp.cl')" ' Usuario
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','Pass','EVF55-DEAsEE')" ' Contraseña
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','Directorio','BakApp/Empresas')"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','URL_Descarga','http://www.bakapp.cl/bakapp.cl/Descargas/BakApp/Versiones')"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

    End Sub

    Function Fx_Existe_Nueva_Actualizacion() As Boolean

        Dim _Buscar_Actualizacion_En_FTP = True

        Try
            _Buscar_Actualizacion_En_FTP = _Global_Row_EstacionBk.Item("Buscar_Actualizacion_En_FTP")
        Catch ex As Exception
            _Buscar_Actualizacion_En_FTP = False
        End Try

        Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        If _Buscar_Actualizacion_En_FTP Then

            _Host = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones", "NombreTabla", "Tabla = 'FTP_ACTUALIZACION' And CodigoTabla = 'Host'")
            _User = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones", "NombreTabla", "Tabla = 'FTP_ACTUALIZACION' And CodigoTabla = 'User'")
            _Pass = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones", "NombreTabla", "Tabla = 'FTP_ACTUALIZACION' And CodigoTabla = 'Pass'")
            _Directorio = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones", "NombreTabla", "Tabla = 'FTP_ACTUALIZACION' And CodigoTabla = 'Directorio'")
            _URL_Descarga = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones", "NombreTabla", "Tabla = 'FTP_ACTUALIZACION' And CodigoTabla = 'URL_Descarga'")

            _Directorio = Host & "/" & _Directorio & "/" & RutEmpresa

            _Error = String.Empty

            Dim _Existe_Actualizacion As Boolean = Fx_Buscar_Actualizacion_FTP()

            If Not String.IsNullOrEmpty(_Error) Then

                Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "", 0, "Act_Ftp", _Error & " - " & _Host & " - " & _URL_Descarga, "", "", "", "", False, "")
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set Buscar_Actualizacion_En_FTP = 0 Where NombreEquipo = '" & _NombreEquipo & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql, False)

            End If

            Return _Existe_Actualizacion

        End If

    End Function

    Function Fx_Buscar_Actualizacion_FTP() As Boolean

        Try

            Dim dirFtp As FtpWebRequest = CType(FtpWebRequest.Create(_Directorio), FtpWebRequest)

            ' Los datos del usuario (credenciales)
            Dim cr As New NetworkCredential(User, Pass)
            dirFtp.Credentials = cr

            ' El comando a ejecutar
            dirFtp.Method = "LIST"

            ' También usando la enumeración de WebRequestMethods.Ftp
            dirFtp.Method = WebRequestMethods.Ftp.ListDirectoryDetails

            Dim ftpresp As FtpWebResponse = DirectCast(dirFtp.GetResponse, FtpWebResponse)

            Dim sreader As New IO.StreamReader(ftpresp.GetResponseStream)

            Dim _Lista_Archivos As New List(Of String)

            While Not sreader.Peek = -1

                Dim ftpList As String() = sreader.ReadLine.Split(" ")
                Dim ftpfile As String = ftpList(ftpList.GetUpperBound(0))

                _Lista_Archivos.Add(ftpfile)

            End While

            ftpresp.Close()

            For Each _Archivo As String In _Lista_Archivos

                Dim _Version_Nueva As String = _Archivo

                If Not _Version_Nueva.Contains(".") Then

                    _Version_Nueva = Replace(_Version_Nueva, "Setup_BakApp_Version_", "")
                    _Version_Nueva = Replace(_Version_Nueva, ".exe", "")

                    Dim _Nro_New_Version As Integer = Replace(_Version_Nueva, ".", "")
                    Dim _Nro_Old_Version As Integer = Replace(_Version_BakApp, ".", "")

                    If _Nro_New_Version > _Nro_Old_Version Then

                        _Nombre_Archivo = "Setup_BakApp_Version_" & _Nro_New_Version & ".exe"

                        _URL_Descarga = _URL_Descarga & "/" & _Nombre_Archivo

                        Dim _Valida_Sitio = UCase(Fx_Validar_Sitio_Web(_URL_Descarga))

                        If _Valida_Sitio = "OK" Then

                            _Nro_Version_Nueva = _Nro_New_Version
                            _Ruta_Y_Archivo_Actualizacion = _Dir_Temp & "\" & _Nombre_Archivo

                            Return True

                        Else

                            Throw New System.Exception("No es posible descargar el archivo de actualización desde el sitio: " & _URL_Descarga & vbCrLf & _Valida_Sitio)

                        End If

                    End If

                End If

            Next

        Catch ex As Exception
            _Error = ex.Message
        End Try

    End Function

    Function Fx_Buscar_Actualizacion_Directorio_Local() As Boolean

        Try

            Dim _Directorio As String

            ':::Capturador de errores Try
            Try
                ':::Contamos cuanto archivos de texto hay en la carpeta
                Dim Total = My.Computer.FileSystem.GetFiles(_Directorio, FileIO.SearchOption.SearchAllSubDirectories, "*.txt")
                'LblTotal.Text = "Total Archivos de Texto: " + CStr(Total.Count)

                ':::Realizamos la búsqueda de la ruta de cada archivo de texto y los agregamos al ListBox
                For Each _Archivo As String In My.Computer.FileSystem.GetFiles("C:\Tutoriales", FileIO.SearchOption.SearchAllSubDirectories, "*.exe")

                    Dim _Version_Nueva As String = _Archivo

                    If Not _Version_Nueva.Contains(".") Then

                        _Version_Nueva = Replace(_Version_Nueva, "Setup_BakApp_Version_", "")
                        _Version_Nueva = Replace(_Version_Nueva, ".exe", "")

                        Dim _Nro_New_Version As Integer = Replace(_Version_Nueva, ".", "")
                        Dim _Nro_Old_Version As Integer = Replace(_Version_BakApp, ".", "")

                        If _Nro_New_Version > _Nro_Old_Version Then

                            _Nombre_Archivo = "Setup_BakApp_Version_" & _Nro_New_Version & ".exe"

                            _URL_Descarga = _URL_Descarga & "/" & _Nombre_Archivo

                            Dim _Valida_Sitio = UCase(Fx_Validar_Sitio_Web(_URL_Descarga))

                            If _Valida_Sitio = "OK" Then

                                _Nro_Version_Nueva = _Nro_New_Version
                                _Ruta_Y_Archivo_Actualizacion = _Dir_Temp & "\" & _Nombre_Archivo

                                Return True

                            Else

                                Throw New System.Exception("No es posible descargar el archivo de actualización desde el sitio: " & _URL_Descarga & vbCrLf & _Valida_Sitio)

                            End If

                        End If

                    End If

                Next

            Catch ex As Exception
                MsgBox("No se realizó la operación por: " & ex.Message)
            End Try


        Catch ex As Exception
            _Error = ex.Message
        End Try

    End Function

    Function Fx_Crear_Directorio_FTP(ByVal dir As String) As String

        Dim peticionFTP As FtpWebRequest

        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(User, Pass)

        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory

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

End Class
