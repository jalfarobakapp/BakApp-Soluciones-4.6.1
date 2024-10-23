Imports System.Data.SqlClient
Imports System.IO
Imports BkSpecialPrograms
Imports Newtonsoft.Json
Public Class Cl_ConfiguracionLocal

    Public Property DirectorioActual As String
    Public Property NombreArchivo_Configuracion As String
    Public Property Ls_ImpFormatos As List(Of ImpFormatos)
    Public Property Configuracion As New Configuracion


    Public Sub New()

        DirectorioActual = Application.StartupPath & "\Data"
        'NombreArchivo_Conexion = "ConexionBkWms.json"
        NombreArchivo_Configuracion = "ConfLocal.json"

    End Sub

    Function Fx_LeerArchivoConexionJson(_ProbarConexion As Boolean) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            If Not Directory.Exists(DirectorioActual) Then

                Directory.CreateDirectory(DirectorioActual)

                DirectorioActual = Application.StartupPath & "\Data\Tmp"

                If Not Directory.Exists(DirectorioActual) Then
                    Directory.CreateDirectory(DirectorioActual)
                End If

            Else
                DirectorioActual = Application.StartupPath & "\Data\Tmp"
            End If

            _Mensaje.Id = 1

            Dim json As String

            If Not File.Exists(DirectorioActual & "\" & NombreArchivo_Configuracion) Then

                Dim _Conexion1 As New Conexion With {.NombreConexion = "RandomBakapp", .Host = "", .Puerto = "", .Usuario = "", .Password = "", .Basededatos = ""}
                Dim _Conexion2 As New Conexion With {.NombreConexion = "WMS", .Host = "", .Puerto = "", .Usuario = "", .Password = "", .Basededatos = ""}

                Configuracion.Ls_Conexiones = New List(Of Conexion)

                Configuracion.Ls_Conexiones.Add(_Conexion1)
                Configuracion.Ls_Conexiones.Add(_Conexion2)

                Dim _ImpFormatos_Reti As New ImpFormatos With {.Tipo = "Retiro", .Impresora = "", .Imprimir = False, .NombreFormato = "", .NombreEquipoImprime = ""}
                Dim _ImpFormatos_Desp As New ImpFormatos With {.Tipo = "Despacho", .Impresora = "", .Imprimir = False, .NombreFormato = "", .NombreEquipoImprime = ""}
                Dim _ImpFormatos_Tick As New ImpFormatos With {.Tipo = "Ticket", .Impresora = "", .Imprimir = False, .NombreFormato = "", .NombreEquipoImprime = ""}

                Configuracion.Ls_ImpFormatos = New List(Of ImpFormatos)

                Configuracion.Ls_ImpFormatos.Add(_ImpFormatos_Reti)
                Configuracion.Ls_ImpFormatos.Add(_ImpFormatos_Desp)
                Configuracion.Ls_ImpFormatos.Add(_ImpFormatos_Tick)

                Configuracion.DiasRevNVV = 7
                'Configuracion.NombreEquipoImprime = ""

                json = Newtonsoft.Json.JsonConvert.SerializeObject(Configuracion)

                Dim _Mensaje2 As New LsValiciones.Mensajes

                _Mensaje2 = Fx_GrabarConexiones()

                _Mensaje.Detalle = "Falta datos en la configuración"
                Throw New System.Exception("Debe ingresar la configuración de conexión a las bases de datos.")

            End If

            json = File.ReadAllText(DirectorioActual & "\" & NombreArchivo_Configuracion)
            Configuracion = JsonConvert.DeserializeObject(Of Configuracion)(json)

            Dim Ls_FunFcvGdvAuto As List(Of FunFcvGdvAuto) = Configuracion.Ls_FunFcvGdvAuto

            If IsNothing(Ls_FunFcvGdvAuto) OrElse Not CBool(Ls_FunFcvGdvAuto.Count) Then
                Ls_FunFcvGdvAuto = New List(Of FunFcvGdvAuto)
                Throw New System.Exception("Debe ingresar la configuración de conexión a las bases de datos.")
            End If

            Dim Ls_Conexiones As List(Of Conexion) = Configuracion.Ls_Conexiones

            If _Mensaje.Id = 1 Then

                If _ProbarConexion Then

                    Dim _Cadena As String

                    _Cadena = Fx_CadenaConexion(Ls_Conexiones(0).Host,
                                                Ls_Conexiones(0).Puerto,
                                                Ls_Conexiones(0).Basededatos,
                                                Ls_Conexiones(0).Usuario,
                                                Ls_Conexiones(0).Password)

                    Dim _Ms = Fx_Conectar(_Cadena)

                    If Not _Ms.EsCorrecto Then
                        _Mensaje.Detalle = _Ms.Detalle
                        Throw New System.Exception(_Ms.Mensaje)
                    End If

                    _Cadena = Fx_CadenaConexion(Ls_Conexiones(1).Host,
                                                Ls_Conexiones(1).Puerto,
                                                Ls_Conexiones(1).Basededatos,
                                                Ls_Conexiones(1).Usuario,
                                                Ls_Conexiones(1).Password)


                    _Ms = Fx_Conectar(_Cadena)

                    If Not _Ms.EsCorrecto Then
                        _Mensaje.Detalle = _Ms.Detalle
                        Throw New System.Exception(_Ms.Mensaje)
                    End If

                End If

                _Mensaje.Detalle = "Archivo leido correctamente"
                _Mensaje.Mensaje = "El archivo contiene las conexiones a las bases de datos"

            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Resultado = json

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Id = 0
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function

    Function Fx_GrabarConexiones() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            DirectorioActual = Application.StartupPath & "\Data\Tmp"

            Dim json As String

            json = JsonConvert.SerializeObject(Configuracion, Formatting.Indented)
            File.WriteAllText(DirectorioActual & "\" & NombreArchivo_Configuracion, json)

            'json = JsonConvert.SerializeObject(Ls_Conexiones, Formatting.Indented)
            'File.WriteAllText(DirectorioActual & "\" & NombreArchivo_Conexion, json)

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Archivo grabado correctamente"
            _Mensaje.Mensaje = "Ruta de archivo: " & DirectorioActual & "\" & NombreArchivo_Configuracion
            _Mensaje.Resultado = json

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Problema"
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function

    Function Fx_CadenaConexion(_Host As String,
                               _Puerto As String,
                               _Basededatos As String,
                               _Usuario As String,
                               _Password As String) As String

        Dim Cadena = "data source = #SV#; initial catalog = #BD#; user id = #US#; password = #PW#"

        If Trim(_Puerto) <> "" Then
            _Host = Trim(_Host & "," & _Puerto)
        End If

        Cadena = Replace(Cadena, "#SV#", _Host)
        Cadena = Replace(Cadena, "#BD#", _Basededatos)
        Cadena = Replace(Cadena, "#US#", _Usuario)
        Cadena = Replace(Cadena, "#PW#", _Password)

        Return Cadena

    End Function

    Function Fx_Conectar(_CadenaDeConexion As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim _Sql As New Class_SQL(_CadenaDeConexion)

        Try

            Dim _Cn As New SqlConnection
            _Sql.Sb_Abrir_Conexion(_Cn, False)

            If Not String.IsNullOrWhiteSpace(_Sql.Pro_Error) Then
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Conexión"
            _Mensaje.Mensaje = "La conexión a la base de datos ha resultado exitosa"

        Catch ex As Exception
            _Mensaje.Detalle = "Problema al conectar"
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function


End Class
