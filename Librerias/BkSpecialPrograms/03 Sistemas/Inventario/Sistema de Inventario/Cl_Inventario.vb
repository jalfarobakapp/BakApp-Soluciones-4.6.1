Imports System.Data.SqlClient

Public Class Cl_Inventario

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Zw_Inv_Inventario As New Zw_Inv_Inventario
    Public Sub New()

    End Sub

    Function Fx_Crear_Inventario() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Consulta_sql = String.Empty

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With Zw_Inv_Inventario

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Inv_Inventario (Empresa,Sucursal,Bodega,Nombre_Inventario,FechaInicio,Activo) Values " &
                       "('" & .Empresa & "','" & .Sucursal & "','" & .Bodega & "','" & .Nombre_Inventario & "','" & Format(.FechaInicio, "yyyyMMdd HH:mm") & "'," & Convert.ToInt32(.Activo) & ")"

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
            _Mensaje.Id = Zw_Inv_Inventario.Id
            _Mensaje.Detalle = "Documento grabado correctamente"
            _Mensaje.Mensaje = "Se crea Inventario " & Zw_Inv_Inventario.Nombre_Inventario
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Error al grabar"
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop
            Zw_Inv_Inventario.Id = 0

            If Not IsNothing(myTrans) Then
                myTrans.Rollback()
            End If

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje


    End Function

    Function Fx_Llenar_Zw_Inv_Inventario(_Id As Integer) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Inv_Inventario Where Id = " & _Id
        Dim _Row_Enc As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        With Zw_Inv_Inventario

            If IsNothing(_Row_Enc) Then

                _Mensaje_Stem.EsCorrecto = False
                _Mensaje_Stem.Mensaje = "No se encontro el registro en la tabla Zw_Inv_Inventario con el Id " & _Id

                Return _Mensaje_Stem

            End If



            .Id = _Row_Enc.Item("Id")
            .Empresa = _Row_Enc.Item("Empresa")
            .Sucursal = _Row_Enc.Item("Sucursal")
            .Bodega = _Row_Enc.Item("Sucursal")
            .Nombre_Inventario = _Row_Enc.Item("Nombre_Inventario")
            .Activo = _Row_Enc.Item("Activo")
            .FechaInicio = _Row_Enc.Item("FechaInicio")
            .FechaCierre = _Row_Enc.Item("FechaCierre")

        End With

        _Mensaje_Stem.EsCorrecto = True
        _Mensaje_Stem.Mensaje = "Registro encontrado."

        Return _Mensaje_Stem

    End Function

End Class
