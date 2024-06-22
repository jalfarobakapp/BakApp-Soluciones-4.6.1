Imports System.Data.SqlClient
Imports DevComponents.DotNetBar

Public Class Cl_Contador

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Zw_Inv_Contador As New Zw_Inv_Contador

    Public Sub New()

    End Sub

    Function Fx_Llenar_Zw_Inv_Contadores(_Id As Integer) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        _Mensaje_Stem.EsCorrecto = False
        _Mensaje_Stem.Detalle = "Cargar Ubicación de Inventario"
        _Mensaje_Stem.Mensaje = String.Empty

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Inv_Contador Where Id = " & _Id
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then
            _Mensaje_Stem.Mensaje = "No se encontro el registro en la tabla Zw_Inv_Contadores con el Id " & _Id
            Return _Mensaje_Stem
        End If

        With Zw_Inv_Contador

            .Id = _Row.Item("Id")
            .Rut = _Row.Item("Rut")
            .Nombre = _Row.Item("Nombre")
            .Email = _Row.Item("Email")
            .Telefono = _Row.Item("Telefono")
            .Activo = _Row.Item("Activo")

        End With

        _Mensaje_Stem.EsCorrecto = True
        _Mensaje_Stem.Mensaje = "Registros cargados correctamente"

    End Function

    Function Fx_Crear_Contador(Zw_Inv_Contador As Zw_Inv_Contador) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        _Mensaje_Stem.Detalle = "Crear Contador de Inventario"
        _Mensaje_Stem.EsCorrecto = False
        _Mensaje_Stem.Mensaje = String.Empty
        _Mensaje_Stem.Icono = MessageBoxIcon.Stop

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Contador",
                                            "Rut = '" & Zw_Inv_Contador.Rut & "'")
        If CBool(_Reg) Then
            _Mensaje_Stem.Mensaje = "El contador ya existe con el Rut " & Zw_Inv_Contador.Rut
            Return _Mensaje_Stem
        End If

        Consulta_sql = String.Empty

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With Zw_Inv_Contador

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Inv_Contador (Rut,Nombre,Email,Telefono,Activo) Values " &
                               "('" & .Rut & "','" & .Nombre & "','" & .Email & "','" & .Telefono & "'," & Convert.ToInt32(.Activo) & ")"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Stem.EsCorrecto = True
            _Mensaje_Stem.Mensaje = "Contador creado correctamente"
            _Mensaje_Stem.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje_Stem.Mensaje = ex.Message
            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function

    Function Fx_Actualizar_Contador(Zw_Inv_Contador As Zw_Inv_Contador) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        _Mensaje_Stem.Detalle = "Crear Ubicación de Inventario"
        _Mensaje_Stem.EsCorrecto = False
        _Mensaje_Stem.Mensaje = String.Empty
        _Mensaje_Stem.Icono = MessageBoxIcon.Stop

        Dim _Ref As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Contador",
                                                       "Id <> " & Zw_Inv_Contador.Id & " And Rut = '" & Zw_Inv_Contador.Rut & "'")

        If CBool(_Ref) Then
            _Mensaje_Stem.Mensaje = "Ya existe un operador con el mismo Rut"
            Return _Mensaje_Stem
        End If

        Consulta_sql = String.Empty

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With Zw_Inv_Contador

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Inv_Contador Set " &
                               "Nombre = '" & .Nombre & "',Email = '" & .Email & "',Telefono = '" & .Telefono & "',Activo = " & Convert.ToInt32(.Activo) & vbCrLf &
                               "Where Id = " & .Id

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Stem.EsCorrecto = True
            _Mensaje_Stem.Mensaje = "Contador editado correctamente"
            _Mensaje_Stem.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje_Stem.Mensaje = ex.Message
            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function

    Function Fx_Eliminar_Contador(Zw_Inv_Contador As Zw_Inv_Contador) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        _Mensaje_Stem.Detalle = "Crear Ubicación de Inventario"
        _Mensaje_Stem.EsCorrecto = False
        _Mensaje_Stem.Mensaje = String.Empty
        _Mensaje_Stem.Icono = MessageBoxIcon.Stop

        Consulta_sql = String.Empty

        Dim _reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Hoja_Detalle",
                                            "IdContador1 = " & Zw_Inv_Contador.Id & " Or IdContador2 = " & Zw_Inv_Contador.Id)

        If CBool(_reg) Then
            _Mensaje_Stem.Mensaje = "No se puede eliminar el contador, tiene registros inventariados"
            Return _Mensaje_Stem
        End If

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With Zw_Inv_Contador

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Inv_Contador Where Id = " & .Id

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Stem.EsCorrecto = True
            _Mensaje_Stem.Mensaje = "Contador eliminado correctamente"
            _Mensaje_Stem.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje_Stem.Mensaje = ex.Message
            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function


End Class
