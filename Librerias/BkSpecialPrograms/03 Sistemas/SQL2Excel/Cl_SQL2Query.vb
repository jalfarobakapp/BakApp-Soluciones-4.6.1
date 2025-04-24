Imports System.Data.SqlClient
Imports BkSpecialPrograms.My.Resources

Public Class Cl_SQL2Query

    Private _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Private Consulta_sql As String

    Public Property Zw_SQL_Querys As New Zw_SQL_Querys

    Public Sub New()

    End Sub

    Function Fx_Llenar_Zw_SQL_Querys(_Nombre_Query As String) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_SQL_Querys Where Nombre_Query = '" & _Nombre_Query & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        With Zw_SQL_Querys

            If IsNothing(_Row) Then

                _Mensaje_Stem.EsCorrecto = False
                _Mensaje_Stem.Col1_Mensaje = "No se encontro el registro en la tabla Zw_SQL_Querys con el Nombre_Query = " & _Nombre_Query

                Return _Mensaje_Stem

            End If

            .Id = _Row.Item("Id")
            .Nombre_Query = _Row.Item("Nombre_Query")
            .SQL_Query = _Row.Item("SQL_Query")
            .Funcionario = _Row.Item("Funcionario")
            .Consulta_Global = _Row.Item("Consulta_Global")
            .Consulta_Personal = _Row.Item("Consulta_Personal")
            .FechaCreacion = _Row.Item("FechaCreacion")
            .Nota = _Row.Item("Nota")

        End With

        _Mensaje_Stem.EsCorrecto = True
        _Mensaje_Stem.Col1_Mensaje = "Registro encontrado."
        _Mensaje_Stem.Tag = Zw_SQL_Querys

        Return _Mensaje_Stem

    End Function

    Function Fx_Llenar_Zw_SQL_Querys(_Id As Integer) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_SQL_Querys Where Id = " & _Id
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        With Zw_SQL_Querys

            If IsNothing(_Row) Then

                _Mensaje_Stem.EsCorrecto = False
                _Mensaje_Stem.Col1_Mensaje = "No se encontro el registro en la tabla Zw_SQL_Querys con el Id = " & _Id

                Return _Mensaje_Stem

            End If

            .Id = _Row.Item("Id")
            .Nombre_Query = _Row.Item("Nombre_Query")
            .SQL_Query = _Row.Item("SQL_Query")
            .Funcionario = _Row.Item("Funcionario")
            .Consulta_Global = _Row.Item("Consulta_Global")
            .Consulta_Personal = _Row.Item("Consulta_Personal")
            .FechaCreacion = NuloPorNro(_Row.Item("FechaCreacion"), #01-01-0001#)
            .Nota = _Row.Item("Nota")

        End With

        _Mensaje_Stem.EsCorrecto = True
        _Mensaje_Stem.Col1_Mensaje = "Registro encontrado."
        _Mensaje_Stem.Tag = Zw_SQL_Querys

        Return _Mensaje_Stem

    End Function

    Function Fx_Crear_SQlQuery() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes


        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_SQL_Querys",
                                                             "Nombre_Query = '" & Zw_SQL_Querys.Nombre_Query & "' And Id <> " & Zw_SQL_Querys.Id))

        If CBool(_Reg) Then

            _Mensaje.EsCorrecto = False
            _Mensaje.Col1_Mensaje = "Ya existe un registro con el nombre de la consulta SQL."
            _Mensaje.Icono = MessageBoxIcon.Stop

            Return _Mensaje

        End If


        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()
            With Zw_SQL_Querys

                .SQL_Query = Replace(.SQL_Query, "'", "''")

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_SQL_Querys (Nombre_Query, SQL_Query, Funcionario, Consulta_Global, Consulta_Personal, FechaCreacion, Nota) " &
                               "Values ('" & .Nombre_Query & "','" & .SQL_Query & "','" & .Funcionario & "'" &
                               "," & Convert.ToInt32(.Consulta_Global) & ", " & Convert.ToInt32(.Consulta_Personal) & ",GetDate(),'" & .Nota & "')"

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
            _Mensaje.Id = Zw_SQL_Querys.Id
            _Mensaje.Col2_Detalle = "Grabar consulta SQL"
            _Mensaje.Col1_Mensaje = "Consulta SQL grabada correctamente."
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje.EsCorrecto = False
            _Mensaje.Col2_Detalle = "Error al grabar"
            _Mensaje.Col1_Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop
            Zw_SQL_Querys.Id = 0

            If Not IsNothing(myTrans) Then
                myTrans.Rollback()
            End If

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje

    End Function

    Function Fx_Editar_SqlQuery() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Consulta_sql = String.Empty

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With Zw_SQL_Querys

                .SQL_Query = Replace(.SQL_Query, "'", "''")

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_SQL_Querys Set " & vbCrLf &
                               "Nombre_Query = '" & .Nombre_Query & "'" &
                               ",SQL_Query = '" & .SQL_Query & "'" &
                               ",Funcionario = '" & .Funcionario & "'" &
                               ",Consulta_Global = " & Convert.ToInt32(.Consulta_Global) &
                               ",Consulta_Personal = " & Convert.ToInt32(.Consulta_Personal) &
                               ",Nota = '" & .Nota & "' " &
                               "Where Id = " & .Id

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje.EsCorrecto = True
            _Mensaje.Id = Zw_SQL_Querys.Id
            _Mensaje.Col2_Detalle = "Editar consulta SQL"
            _Mensaje.Col1_Mensaje = "Consulta SQL editada correctamente."
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje.EsCorrecto = False
            _Mensaje.Col2_Detalle = "Error al editar"
            _Mensaje.Col1_Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop

            If Not IsNothing(myTrans) Then
                myTrans.Rollback()
            End If

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje

    End Function

    Function Fx_Eliminar_SqlQuery() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Consulta_sql = String.Empty

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With Zw_SQL_Querys

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_SQL_Querys Where Id = " & .Id

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje.EsCorrecto = True
            _Mensaje.Id = Zw_SQL_Querys.Id
            _Mensaje.Col2_Detalle = "Eliminar consulta SQL"
            _Mensaje.Col1_Mensaje = "Consulta SQL eliminada correctamente."
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje.EsCorrecto = False
            _Mensaje.Col2_Detalle = "Error al eliminar"
            _Mensaje.Col1_Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop

            If Not IsNothing(myTrans) Then
                myTrans.Rollback()
            End If

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje

    End Function

End Class
