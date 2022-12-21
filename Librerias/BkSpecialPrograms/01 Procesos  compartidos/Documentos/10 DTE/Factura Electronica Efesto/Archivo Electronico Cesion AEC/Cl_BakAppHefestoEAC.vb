Imports System.IO
Imports HefestoCesionV12

Public Class Cl_BakAppHefestoEAC

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Path As String
    Dim _PathSchemas As String
    Dim _Fullpath As String

    Public Property Errores As List(Of String)

    Public Property AmbienteCertificacion As Integer

    Public Sub New()

        _Path = AppPath() & "\Data\Dte\"
        _PathSchemas = _Path & "Schemas"
        _Fullpath = _Path & "\Data\" & RutEmpresaActiva & "\DTE\Documentos\AEC"

        If Not Directory.Exists(_Fullpath) Then
            System.IO.Directory.CreateDirectory(_Fullpath)
        End If

        '_Path = "D:\Nube OneDrive\OneDrive\Documentos\Empresas\Alimentos Cisterna\Facturas a Ceder"

    End Sub



End Class
