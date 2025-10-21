Imports System.Data.SqlClient

Public Class Cl_SobreStock

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Zw_Prod_SobreStock As New Zw_Prod_SobreStock

    Public Sub New()

    End Sub

    Function Fx_Grabar_Producto_Para_SobreStock(_Zw_Prod_SobreStock As Zw_Prod_SobreStock) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        _Mensaje.Detalle = "Relacionar contenedor con documento"

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            'If IsNothing(_Row) Then
            '    Throw New System.Exception("Documento no encontrado")
            'End If

            myTrans = Cn2.BeginTransaction()

            With _Zw_Prod_SobreStock

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_SobreStock (Empresa,Sucursal,Bodega,Codigo,Descripcion,Activo," &
                               "CodFuncionarioCrea,FechaVigencia,FormatoPqte,PqteHabilitado,Ud1XPqte,CantMinFormato,Moneda," &
                               "PrecioXUd1,StSobStockUd1,StSobStockUd2)" & vbCrLf &
                               "Values ('" & .Empresa & "','" & .Sucursal & "','" & .Bodega & "','" & .Codigo & "','" & .Descripcion & "',1," &
                               "'" & .CodFuncionarioCrea & "',Getdate(),'" & .FormatoPqte & "'," & De_Num_a_Tx_01(.PqteHabilitado, False, 5) &
                               "," & De_Num_a_Tx_01(.Ud1XPqte, False, 5) & "," & De_Num_a_Tx_01(.CantMinFormato, False, 5) &
                               ",'" & .Moneda & "'," & De_Num_a_Tx_01(.PrecioXUd1, False, 5) &
                               "," & De_Num_a_Tx_01(.StSobStockUd1, False, 5) & "," & De_Num_a_Tx_01(.StSobStockUd2, False, 5) & ")"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje.Mensaje = "Sobre Stock actualizado correctamente"
            _Mensaje.EsCorrecto = True
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje.Mensaje = ex.Message
            _Mensaje.EsCorrecto = False
            _Mensaje.Icono = MessageBoxIcon.Error

            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje

    End Function

End Class
