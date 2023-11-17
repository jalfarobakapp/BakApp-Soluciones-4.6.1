Imports System
Imports System.Data
Imports MySql.Data.MySqlClient


Public Class Class_MySQL

    Dim _Cn_MySql As MySqlConnection
    Dim _Cadena_Conexion_MySql As String

    Dim _Error As String

    Public ReadOnly Property Pro_Error() As String
        Get
            Return _Error
        End Get
    End Property

    Public Sub New(ByVal Cadena_Conexion_MySql As String)
        _Cadena_Conexion_MySql = Cadena_Conexion_MySql
    End Sub

    Function Sb_Abrir_Conexion()
        _Error = String.Empty
        Try
            Try
                If _Cn_MySql.State = ConnectionState.Open Then
                    ' Cerrar conexion
                    _Cn_MySql.Close()
                End If
            Catch ex As Exception

            End Try
            _Cn_MySql = New MySqlConnection(_Cadena_Conexion_MySql)
            _Cn_MySql.Open()
        Catch ex As Exception
            _Error = ex.Message
        End Try
    End Function

    Sub Sb_Cerrar_Conexion()
        Try
            If _Cn_MySql.State = ConnectionState.Open Then
                '' Cerrar conexion
                _Cn_MySql.Close()
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        '_Error = String.Empty
    End Sub

    Function Fx_Get_Datatable(ByVal Consulta_sql) As DataTable

        Dim _Tbl As New DataTable

        Sb_Abrir_Conexion()

        Try
            Dim _DaMySql As MySqlDataAdapter
            Dim _DsMySql As New DataSet

            _DaMySql = New MySqlDataAdapter(Consulta_sql, _Cn_MySql)
            _DaMySql.Fill(_Tbl) '(DsMySql, 0)

        Catch ex As Exception
            _Error = ex.ToString
            _Tbl = Nothing
        End Try

        Sb_Cerrar_Conexion()

        Return _Tbl

    End Function

    Function Fx_Get_DataRow(ByVal _Consulta_sql As String) As DataRow

        Try

            Dim _Tbl As DataTable = Fx_Get_Datatable(_Consulta_sql)

            If CBool(_Tbl.Rows.Count) Then
                Return _Tbl.Rows(0)
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Function Fx_Get_DataSet(ByVal _Consulta_sql As String, _
                          ByVal _Ds As DataSet, _
                          ByVal _Nombre_Tabla As String) As DataSet

        Dim _DaMySql As MySqlDataAdapter
        Dim _DsMySql As New DataSet

        Try
            Sb_Abrir_Conexion()

            _DaMySql = New MySqlDataAdapter(_Consulta_sql, _Cn_MySql)
            _DaMySql.SelectCommand.CommandTimeout = 8000
            _DaMySql.Fill(_Ds, _Nombre_Tabla) '(DsMySql, 0)

            Sb_Cerrar_Conexion()

        Catch ex As Exception
            _Error = String.Empty
            _Ds = Nothing
        End Try

        Return _Ds

    End Function

    Function Fx_Get_DataSet(ByVal _Consulta_sql As String) As DataSet

        Dim _DaMySql As MySqlDataAdapter
        Dim _DsMySql As New DataSet

        Try
            Sb_Abrir_Conexion()

            _DaMySql = New MySqlDataAdapter(_Consulta_sql, _Cn_MySql)
            _DaMySql.SelectCommand.CommandTimeout = 8000
            _DaMySql.Fill(_DsMySql) '(DsMySql, 0)

            Sb_Cerrar_Conexion()

            Return _DsMySql
            ' errores
        Catch ex As Exception
            _Error = ex.Message
            _DsMySql = Nothing
        End Try

        Return _DsMySql

    End Function

    Function Fx_Ej_consulta_IDU(ByVal _Consulta_sql As String, _
                                Optional ByVal _Mostrar_Error As Boolean = True) As Boolean
        Try
            'Abrimos la conexión con la base de datos
            Sb_Abrir_Conexion()

            Dim _Query As MySqlCommand '(_Consulta_sql, _Cn_MySql)

            _Query = New MySqlCommand
            _Query.Connection = _Cn_MySql
            _Query.CommandType = CommandType.Text
            _Query.CommandText = _Consulta_sql
            _Query.CommandTimeout = 0
            _Query.ExecuteNonQuery()

            'Cerramos la conexión con la base de datos
            Sb_Cerrar_Conexion()

            System.Windows.Forms.Application.DoEvents()
            Return True
        Catch ex As Exception
            _Error = ex.Message
            If _Mostrar_Error = True Then
                MsgBox("No se realizo la operación: Insert, Update o Delete..." & vbCrLf & vbCrLf & _
                       ex.Message, MsgBoxStyle.Critical, "Modificar tabla")
            End If
        End Try

    End Function


End Class
