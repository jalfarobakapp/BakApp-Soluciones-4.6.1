Imports System.Data.SqlClient

Public Class Cl_Despachos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Zw_Despachos_Configuracion As New Zw_Despachos_Configuracion

    Public Sub New()

    End Sub

    Function Fx_Llenar_Configuracion(_Empresa As String, _Sucursal As String) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Despachos_Configuracion" & vbCrLf &
                       "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then

            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Mensaje = "No se encontro el registro en la tabla Zw_Despachos_Configuracion con Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "'"

            Return _Mensaje_Stem

        End If

        With Zw_Despachos_Configuracion

            .Empresa = _Row.Item("Empresa")
            .Pedir_Sucursal_Retiro = _Row.Item("Pedir_Sucursal_Retiro")
            .Tipo_Venta_X_Defecto = _Row.Item("Tipo_Venta_X_Defecto")
            .Transportista_X_Defecto = _Row.Item("Transportista_X_Defecto")
            .Obs_Retira_Cliente = _Row.Item("Obs_Retira_Cliente")
            .Obs_DirCom = _Row.Item("Obs_DirCom")
            .Transpor_Por_Pagar = _Row.Item("Transpor_Por_Pagar")
            .Valor_Min_Despacho = _Row.Item("Valor_Min_Despacho")
            .Peso_Min_Despacho = _Row.Item("Peso_Min_Despacho")
            .Mostrar_RetiraTransportista = _Row.Item("Mostrar_RetiraTransportista")
            .Mostrar_Agencia = _Row.Item("Mostrar_Agencia")
            .ConfirmarLecturaDespacho = _Row.Item("ConfirmarLecturaDespacho")
            .Sucursal = _Row.Item("Sucursal")
            .NoObligadatosRetiraCliente = _Row.Item("NoObligadatosRetiraCliente")

        End With

        _Mensaje_Stem.EsCorrecto = True
        _Mensaje_Stem.Mensaje = "Registro encontrado."

        Return _Mensaje_Stem

    End Function

    Function Fx_Grabar_Configuracion() As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes
        Dim _NuevoRegistro As Boolean

        Consulta_sql = String.Empty

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Despachos_Configuracion",
                                                       "Empresa = '" & Zw_Despachos_Configuracion.Empresa & "' And Sucursal = '" & Zw_Despachos_Configuracion.Sucursal & "'")

        _NuevoRegistro = Not CBool(_Reg)

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With Zw_Despachos_Configuracion

                If _NuevoRegistro Then

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Despachos_Configuracion (Empresa,Sucursal) Values ('" & .Empresa & "','" & .Sucursal & "')"
                    Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                End If

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Despachos_Configuracion Set " & vbCrLf &
                               "Pedir_Sucursal_Retiro = " & Convert.ToInt32(.Pedir_Sucursal_Retiro) & vbCrLf &
                               ",Tipo_Venta_X_Defecto = '" & .Tipo_Venta_X_Defecto & "'" & vbCrLf &
                               ",Transportista_X_Defecto = '" & .Transportista_X_Defecto & "'" & vbCrLf &
                               ",Obs_Retira_Cliente = '" & .Obs_Retira_Cliente & "'" & vbCrLf &
                               ",Obs_DirCom = " & Convert.ToInt32(.Obs_DirCom) & vbCrLf &
                               ",Transpor_Por_Pagar = " & Convert.ToInt32(.Transpor_Por_Pagar) & vbCrLf &
                               ",Valor_Min_Despacho = " & .Valor_Min_Despacho & vbCrLf &
                               ",Peso_Min_Despacho = " & .Peso_Min_Despacho & vbCrLf &
                               ",Mostrar_RetiraTransportista = " & Convert.ToInt32(.Mostrar_RetiraTransportista) & vbCrLf &
                               ",Mostrar_Agencia = " & Convert.ToInt32(.Mostrar_Agencia) & vbCrLf &
                               ",ConfirmarLecturaDespacho = " & Convert.ToInt32(.ConfirmarLecturaDespacho) & vbCrLf &
                               "Where Empresa = '" & .Empresa & "' And Sucursal = '" & .Sucursal & "'"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Stem.EsCorrecto = True
            _Mensaje_Stem.Detalle = "Grabar configuración"
            _Mensaje_Stem.Mensaje = "Configuración grabada correctamente."
            _Mensaje_Stem.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Mensaje = ex.Message
            _Mensaje_Stem.Icono = MessageBoxIcon.Stop

            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function

End Class
