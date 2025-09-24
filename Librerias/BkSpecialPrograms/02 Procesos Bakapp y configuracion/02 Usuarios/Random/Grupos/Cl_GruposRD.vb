Imports System.Data.SqlClient

Public Class Cl_GruposRD

    Public Property Tabfuge As TABFUGE
    Public Property Tabfugd As TABFUGD
    Public Property Ls_Tabfugd As New List(Of TABFUGD)

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

        Tabfugd = New TABFUGD
        Tabfuge = New TABFUGE
        Ls_Tabfugd = New List(Of TABFUGD)

    End Sub

    Function Fx_Grabar_Nuevo_Grupo(_Tabfuge As TABFUGE, _Ls_Tabfugd As List(Of TABFUGD)) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("TABFUGE", "KOGRU = '" & _Tabfuge.KOGRU & "'")

        If _Reg > 0 Then
            'Throw New System.Exception("El código del grupo ya existe")
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "El código de grupo ya existe"
            _Mensaje.Mensaje = "El código de grupo (" & _Tabfuge.KOGRU.ToString.Trim & ") ya existe" & vbCrLf &
                               "Debe ingresar un código de grupo diferente"
            _Mensaje.Icono = MessageBoxIcon.Error
            Return _Mensaje
        End If

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        'Throw New System.Exception("An exception has occurred.")

        Try

            With _Tabfuge

                myTrans = Cn2.BeginTransaction()

                With _Tabfuge

                    Consulta_sql = "Insert Into TABFUGE (KOGRU,NOKOGRU,KOFUJEFE) Values " &
                       "('" & .KOGRU & "','" & .NOKOGRU & "','" & .KOFUJEFE & "')"

                End With

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With


            For Each _Tabfugd As TABFUGD In _Ls_Tabfugd

                With _Tabfugd

                    Consulta_sql = "Insert Into TABFUGD (KOGRU,KOFU,ORDEN) Values " &
                             "('" & .KOGRU & "','" & .KOFU & "'," & .ORDEN & ")"

                    Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                End With

            Next

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Grabación correcta"
            _Mensaje.Mensaje = "Se graba correctamente el Grupo"
            _Mensaje.Icono = MessageBoxIcon.Information

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        Catch ex As Exception

            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.ConsultaSQLEjecutada = Consulta_sql
            _Mensaje.Icono = MessageBoxIcon.Error

            If Not IsNothing(myTrans) Then
                myTrans.Rollback()
            End If

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje

    End Function

    Function Fx_Editar_Grupo(_Tabfuge As TABFUGE, _Ls_Tabfugd As List(Of TABFUGD)) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand
        Dim Cn2 As New SqlConnection

        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With _Tabfuge

                Consulta_sql = "Update TABFUGE Set NOKOGRU = '" & .NOKOGRU.ToString.Trim & "', KOFUJEFE = '" & .KOFUJEFE & "'" & vbCrLf &
                               "Where KOGRU = '" & .KOGRU & "'" & vbCrLf &
                               "Delete TABFUGD Where KOGRU = '" & .KOGRU & "'"
                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With


            For Each _Tabfugd As TABFUGD In _Ls_Tabfugd

                With _Tabfugd

                    Consulta_sql = "Insert Into TABFUGD (KOGRU,KOFU,ORDEN) Values " &
                             "('" & .KOGRU & "','" & .KOFU & "'," & .ORDEN & ")"

                    Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                End With

            Next

            myTrans.Commit()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Grabación correcta"
            _Mensaje.Mensaje = "Grupo actualizado correctamente"
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.ConsultaSQLEjecutada = Consulta_sql
            _Mensaje.Icono = MessageBoxIcon.Error

            If Not IsNothing(myTrans) Then
                myTrans.Rollback()
            End If

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje

    End Function

    Function Fx_Eliminar_Grupo(_Kogru As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand
        Dim Cn2 As New SqlConnection

        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            Consulta_sql = "Delete TABFUGD Where KOGRU = '" & _Kogru & "'" & vbCrLf &
                           "Delete TABFUGE Where KOGRU = '" & _Kogru & "'"
            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Eliminación correcta"
            _Mensaje.Mensaje = "Se elimina correctamente el Grupo"
            _Mensaje.Icono = MessageBoxIcon.Information

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        Catch ex As Exception

            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.ConsultaSQLEjecutada = Consulta_sql
            _Mensaje.Icono = MessageBoxIcon.Error

            If Not IsNothing(myTrans) Then
                myTrans.Rollback()
            End If

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje

    End Function


End Class
