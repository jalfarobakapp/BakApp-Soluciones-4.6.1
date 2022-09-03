Imports System.IO

Public Class Clas_Actualiza_BakApp_Sql

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Dir_Temp = AppPath() & "\Data\Tmp\Actualizacion"
    Dim _Mensaje As String
    Dim _Nro_Version_Nueva As String
    Dim _URL_Descarga As String
    Dim _Ruta_Y_Archivo_Actualizacion As String
    Dim _Nombre_Archivo As String
    Public Property Mensaje As String
        Get
            Return _Mensaje
        End Get
        Set(value As String)
            _Mensaje = value
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

    Public Property Nro_Version_Nueva As String
        Get
            Return _Nro_Version_Nueva
        End Get
        Set(value As String)
            _Nro_Version_Nueva = value
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

    Public Property Nombre_Archivo As String
        Get
            Return _Nombre_Archivo
        End Get
        Set(value As String)
            _Nombre_Archivo = value
        End Set
    End Property

    Public Sub New()

        If Not Directory.Exists(_Dir_Temp) Then
            System.IO.Directory.CreateDirectory(_Dir_Temp)
        End If

        If Not Directory.Exists(_Dir_Temp & "\Versiones") Then
            System.IO.Directory.CreateDirectory(_Dir_Temp & "\Versiones")
        End If

        _Dir_Temp = _Dir_Temp & "\Versiones"

    End Sub

    Function Fx_Existe_Nueva_Actualizacion() As Boolean

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Version Where Activa = 1"
        Dim _Row_Version As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Version) Then
            'Throw New System.Exception("No se encontro registro en la tabla Zw_Version")
            Mensaje = String.Empty ' "No se encontro registro en la tabla Zw_Version"
            Return False
        End If

        Dim _Version_Nueva As String = _Row_Version.Item("Version")
        _URL_Descarga = _Row_Version.Item("URL_Descarga")
        _Nombre_Archivo = _Row_Version.Item("Nombre_Archivo")

        Dim _Nro_New_Version As Integer = Replace(_Version_Nueva, ".", "")
        Dim _Nro_Old_Version As Integer = Replace(_Version_BakApp, ".", "")

        If _Nro_New_Version > _Nro_Old_Version Then

            _Nombre_Archivo = _Nombre_Archivo '& _Nro_New_Version & ".exe"

            _URL_Descarga = _URL_Descarga & "/" & _Nombre_Archivo

            Dim _Valida_Sitio = UCase(Fx_Validar_Sitio_Web(_URL_Descarga))

            If _Valida_Sitio = "OK" Then

                _Nro_Version_Nueva = _Nro_New_Version
                _Ruta_Y_Archivo_Actualizacion = _Dir_Temp & "\" & _Nombre_Archivo

                Return True

            Else

                'Throw New System.Exception("No es posible descargar el archivo de actualización desde el sitio: " & _URL_Descarga & vbCrLf & _Valida_Sitio)
                Mensaje = "No es posible descargar el archivo de actualización desde el sitio: " & _URL_Descarga & vbCrLf & _Valida_Sitio
                Return False

            End If

        End If

    End Function

    Function Fx_Existe_Version_Para_Descargar() As Boolean

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Version Where Activa = 1"
        Dim _Row_Version As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Version) Then
            'Throw New System.Exception("No se encontro registro en la tabla Zw_Version")
            Mensaje = "No se encontro registro en la tabla Zw_Version"
            Return False
        End If

        Dim _Version_Nueva As String = _Row_Version.Item("Version")

        _URL_Descarga = _Row_Version.Item("URL_Descarga")
        _Nombre_Archivo = _Row_Version.Item("Nombre_Archivo")

        Dim _Nro_New_Version As Integer = Replace(_Version_Nueva, ".", "")
        Dim _Nro_Old_Version As Integer = Replace(_Version_BakApp, ".", "")

        _Nombre_Archivo = _Nombre_Archivo '& _Nro_New_Version & ".exe"

        _URL_Descarga = _URL_Descarga & "/" & _Nombre_Archivo

        Dim _Valida_Sitio = UCase(Fx_Validar_Sitio_Web(_URL_Descarga))

        If _Valida_Sitio = "OK" Then

            _Nro_Version_Nueva = _Nro_New_Version
            _Ruta_Y_Archivo_Actualizacion = _Dir_Temp & "\" & _Nombre_Archivo

            Return True

        Else

            'Throw New System.Exception("No es posible descargar el archivo de actualización desde el sitio: " & _URL_Descarga & vbCrLf & _Valida_Sitio)
            Mensaje = "No es posible descargar el archivo de actualización desde el sitio: " & _URL_Descarga & vbCrLf & _Valida_Sitio
            Return False

        End If

    End Function

End Class
