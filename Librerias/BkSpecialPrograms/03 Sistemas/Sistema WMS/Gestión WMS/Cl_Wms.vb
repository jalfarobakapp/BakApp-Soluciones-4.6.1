Imports System.Data
Imports System.Data.SqlClient
Imports System.Reflection


Public Class Cl_Wms

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Zw_WMS_Picking_Enc As New Zw_WMS_Picking_Enc
    Public Property Lst_Zw_WMS_Picking_Det As New List(Of Zw_WMS_Picking_Det)


    Public Property Zw_Stmp_Enc As New Zw_Stmp_Enc
    Public Property Lst_Zw_Stmp_Det As New List(Of Zw_Stmp_Det)

    Dim _Cl_Stmp As New Cl_Stmp

    Public Sub New()

    End Sub

    Sub Sb_Cargar_Stmp(_Id_Enc As String)
        Cargar_Zw_Stmp_Enc(_Id_Enc)
        Cargar_Lst_Zw_Stmp_Det(_Id_Enc)
    End Sub

    Public Function Cargar_Zw_Stmp_Enc(_Id_Enc As String) As Boolean

        Consulta_sql = $"Select * From {_Global_BaseBk}Zw_Stmp_Enc Where Id_Enc = {_Id_Enc}"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
        Zw_Stmp_Enc = MapDataRowToObject(Of Zw_Stmp_Enc)(_Row)

        'Try
        '    Using conn As New SqlConnection(Cadena_ConexionSQL_Server)
        '        Using cmd As New SqlCommand(Consulta_sql, conn)
        '            cmd.Parameters.AddWithValue("@IdEnc", If(_Id_Enc, DBNull.Value))
        '            Using da As New SqlDataAdapter(cmd)
        '                Dim dt As New DataTable()
        '                da.Fill(dt)
        '                If dt.Rows.Count = 0 Then
        '                    Return False
        '                End If

        '                Zw_Stmp_Enc = MapDataRowToObject(Of Zw_Stmp_Enc)(dt.Rows(0))
        '                Return True
        '            End Using
        '        End Using
        '    End Using
        'Catch
        '    Return False
        'End Try
    End Function

    Public Function Cargar_Lst_Zw_Stmp_Det(_Id_Enc As String) As Boolean

        Consulta_sql = $"Select * From {_Global_BaseBk}Lst_Zw_Stmp_Det Where Id_Enc = {_Id_Enc}"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
        Lst_Zw_Stmp_Det.Clear()
        For Each _Row As DataRow In _Tbl.Rows
            Dim item = MapDataRowToObject(Of Zw_Stmp_Det)(_Row)
            Lst_Zw_Stmp_Det.Add(item)
        Next

        'Try
        '    Using conn As New SqlConnection(Cadena_ConexionSQL_Server)
        '        Using cmd As New SqlCommand(Consulta_sql, conn)
        '            cmd.Parameters.AddWithValue("@IdEnc", If(_Id_Enc, DBNull.Value))
        '            Using da As New SqlDataAdapter(cmd)
        '                Dim dt As New DataTable()
        '                da.Fill(dt)
        '                Lst_Zw_Stmp_Det.Clear()
        '                For Each row As DataRow In dt.Rows
        '                    Dim item = MapDataRowToObject(Of Zw_Stmp_Det)(row)
        '                    Lst_Zw_Stmp_Det.Add(item)
        '                Next
        '                Return True
        '            End Using
        '        End Using
        '    End Using
        'Catch
        '    Return False
        'End Try
    End Function

    Private Function MapDataRowToObject(Of T As {New})(row As DataRow) As T
        Dim obj As New T()
        Dim tType As Type = GetType(T)
        For Each prop As PropertyInfo In tType.GetProperties(BindingFlags.Public Or BindingFlags.Instance)
            If Not prop.CanWrite Then
                Continue For
            End If

            If row.Table.Columns.Contains(prop.Name) Then
                Dim val = row(prop.Name)
                If val Is DBNull.Value Then
                    prop.SetValue(obj, Nothing, Nothing)
                    Continue For
                End If

                Dim targetType As Type = prop.PropertyType
                Dim nullableUnderlying = Nullable.GetUnderlyingType(targetType)
                If nullableUnderlying IsNot Nothing Then
                    targetType = nullableUnderlying
                End If

                Try
                    If targetType.IsEnum Then
                        Dim enumValue = [Enum].Parse(targetType, val.ToString())
                        prop.SetValue(obj, enumValue, Nothing)
                    Else
                        Dim safeValue = Convert.ChangeType(val, targetType)
                        prop.SetValue(obj, safeValue, Nothing)
                    End If
                Catch
                    ' Si la conversión falla, intentar asignar directamente si es compatible
                    Try
                        prop.SetValue(obj, val, Nothing)
                    Catch
                        ' Ignorar si no se puede asignar
                    End Try
                End Try
            End If
        Next

        Return obj
    End Function

End Class
