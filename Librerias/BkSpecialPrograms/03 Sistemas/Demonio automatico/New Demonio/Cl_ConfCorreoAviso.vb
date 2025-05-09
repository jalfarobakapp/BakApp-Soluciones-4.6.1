Public Class Cl_ConfCorreoAviso

    Public Property Zw_Demonio_Conf_Correo As New Zw_Demonio_Conf_Correo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

        With Zw_Demonio_Conf_Correo

            .Id = 0
            .NombreEquipo = String.Empty
            .Id_Padre = 0
            .EnviarCorreo = False
            .Nombre_ConfCorreo = String.Empty
            .Id_Correo = 0
            .Nombre_Correo = String.Empty
            .Enviar_Remitente = True
            .MailRemitente = String.Empty
            .Enviar_VendedorCliente = False
            .Enviar_VendedorLinea = False
            .Enviar_ResponsableDoc = False
            .Enviar_EntidadDoc = False
            .CC_Remitente = False
            .MailCC = String.Empty
            .CC_VendedorCliente = False
            .CC_VendedorLinea = False
            .CC_ResponsableDoc = False
            .CC_EntidadDoc = False
            .EnvioAnticipacion = False
            .DiasEnvioAnticipacion = 0

        End With

    End Sub

    Function Fx_Llenar_ConfCorreo(_Id_ConfCorreo As Integer) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_Conf_Correo Where Id = " & _Id_ConfCorreo
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then

            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "No se encontraron registros en la tabla Zw_Demonio_Conf_Correo con el Id " & _Id_ConfCorreo

            Return _Mensaje

        End If

        With Zw_Demonio_Conf_Correo

            .Id = _Row.Item("Id")
            .NombreEquipo = _Row.Item("NombreEquipo")
            .Id_Padre = _Row.Item("Id_Padre")
            .EnviarCorreo = _Row.Item("EnviarCorreo")
            .Nombre_ConfCorreo = _Row.Item("Nombre_ConfCorreo")
            .Id_Correo = _Row.Item("Id_Correo")
            .Nombre_Correo = _Row.Item("Nombre_Correo")
            .Enviar_Remitente = _Row.Item("Enviar_Remitente")
            .MailRemitente = _Row.Item("MailRemitente")
            .Enviar_VendedorCliente = _Row.Item("Enviar_VendedorCliente")
            .Enviar_VendedorLinea = _Row.Item("Enviar_VendedorLinea")
            .Enviar_ResponsableDoc = _Row.Item("Enviar_ResponsableDoc")
            .Enviar_EntidadDoc = _Row.Item("Enviar_EntidadDoc")
            .CC_Remitente = _Row.Item("CC_Remitente")
            .MailCC = _Row.Item("MailCC")
            .CC_VendedorCliente = _Row.Item("CC_VendedorCliente")
            .CC_VendedorLinea = _Row.Item("CC_VendedorLinea")
            .CC_ResponsableDoc = _Row.Item("CC_ResponsableDoc")
            .CC_EntidadDoc = _Row.Item("CC_EntidadDoc")
            .EnvioAnticipacion = _Row.Item("EnvioAnticipacion")
            .DiasEnvioAnticipacion = _Row.Item("DiasEnvioAnticipacion")

        End With

        _Mensaje.EsCorrecto = True
        _Mensaje.Mensaje = "Registros cargados correctamente"
        _Mensaje.Tag = Zw_Demonio_Conf_Correo

        Return _Mensaje

    End Function

    Function Fx_Grabar_Nuevo_ConfCorreo(_Zw_Demonio_Conf_Correo As Zw_Demonio_Conf_Correo) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            With _Zw_Demonio_Conf_Correo

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_Conf_Correo (NombreEquipo,Id_Padre,EnviarCorreo,Nombre_ConfCorreo,Id_Correo,Nombre_Correo," &
                "Enviar_Remitente,MailRemitente,Enviar_VendedorCliente,Enviar_VendedorLinea,Enviar_ResponsableDoc," &
                "Enviar_EntidadDoc,CC_Remitente,MailCC,CC_VendedorCliente,CC_VendedorLinea,CC_ResponsableDoc," &
                "CC_EntidadDoc,EnvioAnticipacion,DiasEnvioAnticipacion) Values ('" & .NombreEquipo & "'," & .Id_Padre & "," & Convert.ToInt32(.EnviarCorreo) & ",'" & .Nombre_ConfCorreo & "'," & .Id_Correo & ",'" & .Nombre_Correo & "'," &
                Convert.ToInt32(.Enviar_Remitente) & ",'" & .MailRemitente & "'," &
                Convert.ToInt32(.Enviar_VendedorCliente) & "," & Convert.ToInt32(.Enviar_VendedorLinea) & "," &
                Convert.ToInt32(.Enviar_ResponsableDoc) & "," & Convert.ToInt32(.Enviar_EntidadDoc) & "," &
                Convert.ToInt32(.CC_Remitente) & ",'" & .MailCC & "'," &
                Convert.ToInt32(.CC_VendedorCliente) & "," & Convert.ToInt32(.CC_VendedorLinea) & "," &
                Convert.ToInt32(.CC_ResponsableDoc) & "," & Convert.ToInt32(.CC_EntidadDoc) & "," &
                Convert.ToInt32(.EnvioAnticipacion) & "," & .DiasEnvioAnticipacion & ")"

                If Not _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, .Id, False) Then

                    _Mensaje.Detalle = "Error al grabar la configuración de correo aviso"
                    Throw New System.Exception("Error al grabar la configuración de correo aviso" & vbCrLf & _Sql.Pro_Error)

                End If

                _Mensaje.EsCorrecto = True
                _Mensaje.Mensaje = "Configuración de correo aviso grabada correctamente"
                _Mensaje.Tag = Zw_Demonio_Conf_Correo
                _Mensaje.Id = .Id
                _Mensaje.Icono = MessageBoxIcon.Information

            End With

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function


    Function Fx_Editar_ConfCorreo(_Id_ConfCorreo As Integer, _NuevaConfiguracion As Zw_Demonio_Conf_Correo) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try
            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Conf_Correo Set " &
                           "NombreEquipo = '" & _NuevaConfiguracion.NombreEquipo & "', " &
                           "Id_Padre = " & _NuevaConfiguracion.Id_Padre & ", " &
                           "EnviarCorreo = " & Convert.ToInt32(_NuevaConfiguracion.EnviarCorreo) & ", " &
                           "Nombre_ConfCorreo = '" & _NuevaConfiguracion.Nombre_ConfCorreo & "', " &
                           "Id_Correo = " & _NuevaConfiguracion.Id_Correo & ", " &
                           "Nombre_Correo = '" & _NuevaConfiguracion.Nombre_Correo & "', " &
                           "Enviar_Remitente = " & Convert.ToInt32(_NuevaConfiguracion.Enviar_Remitente) & ", " &
                           "MailRemitente = '" & _NuevaConfiguracion.MailRemitente & "', " &
                           "Enviar_VendedorCliente = " & Convert.ToInt32(_NuevaConfiguracion.Enviar_VendedorCliente) & ", " &
                           "Enviar_VendedorLinea = " & Convert.ToInt32(_NuevaConfiguracion.Enviar_VendedorLinea) & ", " &
                           "Enviar_ResponsableDoc = " & Convert.ToInt32(_NuevaConfiguracion.Enviar_ResponsableDoc) & ", " &
                           "Enviar_EntidadDoc = " & Convert.ToInt32(_NuevaConfiguracion.Enviar_EntidadDoc) & ", " &
                           "CC_Remitente = " & Convert.ToInt32(_NuevaConfiguracion.CC_Remitente) & ", " &
                           "MailCC = '" & _NuevaConfiguracion.MailCC & "', " &
                           "CC_VendedorCliente = " & Convert.ToInt32(_NuevaConfiguracion.CC_VendedorCliente) & ", " &
                           "CC_VendedorLinea = " & Convert.ToInt32(_NuevaConfiguracion.CC_VendedorLinea) & ", " &
                           "CC_ResponsableDoc = " & Convert.ToInt32(_NuevaConfiguracion.CC_ResponsableDoc) & ", " &
                           "CC_EntidadDoc = " & Convert.ToInt32(_NuevaConfiguracion.CC_EntidadDoc) & "," &
                           "EnvioAnticipacion = " & Convert.ToInt32(_NuevaConfiguracion.EnvioAnticipacion) & ", " &
                           "DiasEnvioAnticipacion = " & _NuevaConfiguracion.DiasEnvioAnticipacion & vbCrLf &
                           "Where Id = " & _Id_ConfCorreo

            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                _Mensaje.Detalle = "Error al editar la configuración de correo aviso"
                Throw New System.Exception("Error al editar la configuración de correo aviso" & vbCrLf & _Sql.Pro_Error)
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Configuración de correo aviso editada correctamente"
            _Mensaje.Tag = _NuevaConfiguracion
            _Mensaje.Id = _Id_ConfCorreo
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function


    Function Fx_Eliminar_ConfCorreo(_Id_ConfCorreo As Integer) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try
            Consulta_sql = "Delete From " & _Global_BaseBk & "Zw_Demonio_Conf_Correo Where Id = " & _Id_ConfCorreo

            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                _Mensaje.Detalle = "Error al eliminar la configuración de correo aviso"
                Throw New System.Exception("Error al eliminar la configuración de correo aviso" & vbCrLf & _Sql.Pro_Error)
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Configuración de correo aviso eliminada correctamente"
            _Mensaje.Id = _Id_ConfCorreo
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function
End Class
