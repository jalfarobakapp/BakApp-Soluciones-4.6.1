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

    Function Fx_Llenar_SobreStock_Tomado() As Zw_Prod_SobreStock_Tom

        Dim _Zw_Prod_SobreStock_Tom As New Zw_Prod_SobreStock_Tom

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Prod_SobreStock_Tom"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then
            Return _Zw_Prod_SobreStock_Tom
        End If

        With _Zw_Prod_SobreStock_Tom

            .Id = _Row.Item("Id")
            .CodFuncionario = _Row.Item("CodFuncionario")
            .Fecha_Hora = _Row.Item("Fecha_Hora")
            .NombreEquipo = _Row.Item("NombreEquipo")

        End With

        Return _Zw_Prod_SobreStock_Tom

    End Function

    Function Fx_Tomar_SobreStock() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje.Detalle = "Tomar contenedor"

        Try

            Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")
            Dim _Zw_Prod_SobreStock_Tom As Zw_Prod_SobreStock_Tom = Fx_Llenar_SobreStock_Tomado()

            If _Zw_Prod_SobreStock_Tom.Id <> 0 Then

                If _NombreEquipo = _Zw_Prod_SobreStock_Tom.NombreEquipo Then

                    _Mensaje = Fx_Soltar_SobreStock_Tomado()

                    If Not _Mensaje.EsCorrecto Then
                        Return _Mensaje
                    End If

                Else
                    Dim _Funcionario As String = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & _Zw_Prod_SobreStock_Tom.CodFuncionario & "'").ToString.Trim

                    Throw New System.Exception("El Sobre stock ya fue tomado por otro funcionario" & vbCrLf & vbCrLf &
                                               "Funcionario: " & _Zw_Prod_SobreStock_Tom.CodFuncionario & " - " & _Funcionario &
                                               ", Equipo: " & _Zw_Prod_SobreStock_Tom.NombreEquipo & vbCrLf &
                                               "Fecha y hora: " & _Zw_Prod_SobreStock_Tom.Fecha_Hora)
                End If

            End If

            With _Zw_Prod_SobreStock_Tom

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_SobreStock_Tom (CodFuncionario,Fecha_Hora,NombreEquipo) Values " &
                           "('" & FUNCIONARIO & "',Getdate(),'" & _NombreEquipo & "')"

                If Not _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Mensaje.Id) Then
                    Throw New System.Exception("Error al tomar Sobre Stock" & vbCrLf & _Sql.Pro_Error)
                End If

                _Zw_Prod_SobreStock_Tom = Fx_Llenar_SobreStock_Tomado()

            End With

            _Mensaje.Mensaje = "Sobre Stock Tomado Correctamente"
            _Mensaje.EsCorrecto = True
            _Mensaje.Tag = _Zw_Prod_SobreStock_Tom
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
            _Mensaje.EsCorrecto = False
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function

    Function Fx_Soltar_SobreStock_Tomado() As LsValiciones.Mensajes

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje.Detalle = "Soltar contenedor tomado"

        Try

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_SobreStock_Tom Where NombreEquipo = '" & _NombreEquipo & "'"

            If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                Throw New System.Exception("Error al soltar el contenedor tomado" & vbCrLf & _Sql.Pro_Error)
            End If

            _Mensaje.Mensaje = "Sobre Stock Soltado Correctamente"
            _Mensaje.EsCorrecto = True
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
            _Mensaje.EsCorrecto = False
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function

End Class
