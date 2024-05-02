Imports System.Data.SqlClient
Imports System.IO
Imports BkSpecialPrograms
Imports Newtonsoft.Json
Public Class Cl_Conexion

    Public Property Conexiones As List(Of Conexion)
    Public Property DirectorioActual As String
    Public Property NombreArchivo As String
    Public Property Ls_Conexiones As List(Of Conexion)

    Public Sub New()

        DirectorioActual = Application.StartupPath & "\Data"
        NombreArchivo = "ConexionBkWms.json"

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

            If Not File.Exists(DirectorioActual & "\" & NombreArchivo) Then

                Dim Js As String = "[{'NombreConexion': '', 'Host': '', 'Puerto': '', 'Usuario': '','Password': '','Basededatos': ''},
                                 {'NombreConexion': '', 'Host': '', 'Puerto': '', 'Usuario': '','Password': '','Basededatos': ''}]"
                File.WriteAllText(DirectorioActual & "\" & NombreArchivo, Js)

            End If

            Dim json As String = File.ReadAllText(DirectorioActual & "\" & NombreArchivo)
            Ls_Conexiones = JsonConvert.DeserializeObject(Of List(Of Conexion))(json)

            If IsNothing(Ls_Conexiones) OrElse
               String.IsNullOrWhiteSpace(Ls_Conexiones.Item(0).NombreConexion) OrElse
               String.IsNullOrWhiteSpace(Ls_Conexiones.Item(1).NombreConexion) Then
                _Mensaje.Detalle = "Falta la configuración de la conexión"
                Throw New System.Exception("Debe ingresar la configuración de conexión a las bases de datos.")
            End If

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

            Dim json As String = JsonConvert.SerializeObject(Ls_Conexiones, Formatting.Indented)
            '       Dim json As String = JsonConvert.SerializeObject(peopleList, Formatting.Indented)

            File.WriteAllText(DirectorioActual & "\" & NombreArchivo, json)

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Archivo grabado correctamente"
            _Mensaje.Mensaje = "Ruta de archivo: " & DirectorioActual & "\" & NombreArchivo
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
