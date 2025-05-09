Imports DevComponents.DotNetBar

Public Class Frm_Demonio_ConfCorreoAviso

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Cl_ConfCorreoAviso As New Cl_ConfCorreoAviso

    Private _Id_ConfCorreo As Integer

    Public Sub New(_Id_ConfCorreo As Integer, _Nombre_ConfCorreo As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Cl_ConfCorreoAviso.Fx_Llenar_ConfCorreo(_Id_ConfCorreo)
        Cl_ConfCorreoAviso.Zw_Demonio_Conf_Correo.Nombre_ConfCorreo = _Nombre_ConfCorreo

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Demonio_ConfCorreoAviso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Cl_ConfCorreoAviso.Zw_Demonio_Conf_Correo

            .NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")
            .Id_Padre = _Global_Row_EstacionBk.Item("Id")
            Chk_NVV_EnviaCorreo.Checked = .EnviarCorreo
            Txt_Nombre_Correo.Tag = .Id_Correo
            Txt_Nombre_Correo.Text = .Nombre_Correo
            Txt_MailRemitente.Text = .MailRemitente
            Txt_MailCC.Text = .MailCC
            Rdb_Enviar_Remitente.Checked = .Enviar_Remitente
            Rdb_Enviar_VendedorCliente.Checked = .Enviar_VendedorCliente
            Rdb_Enviar_VendedorLinea.Checked = .Enviar_VendedorLinea
            Rdb_Enviar_ResponsableDoc.Checked = .Enviar_ResponsableDoc
            Rdb_Enviar_EntidadDoc.Checked = .Enviar_EntidadDoc
            Rdb_CC_Remitente.Checked = .CC_Remitente
            Rdb_CC_VendedorCliente.Checked = .CC_VendedorCliente
            Rdb_CC_VendedorLinea.Checked = .CC_VendedorLinea
            Rdb_CC_ResponsableDoc.Checked = .CC_ResponsableDoc
            Rdb_CC_EntidadDoc.Checked = .CC_EntidadDoc
            Chk_EnvioAnticipacion.Checked = .EnvioAnticipacion
            Input_DiasEnvioAnticipacion.Value = .DiasEnvioAnticipacion
            Input_DiasEnvioAnticipacion.Enabled = Chk_EnvioAnticipacion.Checked

        End With

    End Sub

    Private Sub Txt_Nombre_Correo_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Nombre_Correo.ButtonCustomClick

        Dim _Row_Email As DataRow

        Dim Fm As New Frm_Correos_SMTP
        Fm.Pro_Seleccionar = True
        Fm.ShowDialog(Me)
        _Row_Email = Fm.Pro_Row_Fila_Seleccionada
        Fm.Dispose()

        If Not IsNothing(_Row_Email) Then
            Txt_Nombre_Correo.Tag = _Row_Email.Item("Id")
            Txt_Nombre_Correo.Text = _Row_Email.Item("Nombre_Correo").ToString.Trim
        End If

    End Sub

    Private Sub Txt_Nombre_Correo_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Nombre_Correo.ButtonCustom2Click
        Txt_Nombre_Correo.Tag = 0
        Txt_Nombre_Correo.Text = String.Empty
    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrWhiteSpace(Txt_Nombre_Correo.Text) Then
            MessageBoxEx.Show("Seleccione un correo SMTP.", "Validación de Correo SMTP",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Nombre_Correo.Focus()
            Return
        End If

        If Rdb_Enviar_Remitente.Checked AndAlso String.IsNullOrWhiteSpace(Txt_MailRemitente.Text) Then
            MessageBoxEx.Show("Debe ingresar un correo para el remitente de envío.", "Validación de Envío",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_MailRemitente.Focus()
            Return
        End If

        'If String.IsNullOrWhiteSpace(Txt_MailRemitente.Text) Then
        '    MessageBox.Show("Ingrese al menos un correo remitente.", "Validación de Correo Remitente",
        '                    MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Txt_MailRemitente.Focus()
        '    Return
        'End If

        ' Validar los correos en Txt_MailRemitente.Text separados por ";"
        If Rdb_Enviar_Remitente.Checked Then
            Dim correos As String() = Txt_MailRemitente.Text.Split(";"c)
            For Each correo In correos
                If Not Fx_Validar_Email(correo.Trim()) Then
                    MessageBoxEx.Show($"El correo '{correo.Trim()}' no es válido.", "Validación de Correo Remitente",
                                    MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If
            Next
        Else
            Txt_MailRemitente.Text = String.Empty
        End If


        ' Validar el correo en Txt_MailCC.Text separados por ";"
        If Rdb_CC_Remitente.Checked Then
            If Not String.IsNullOrWhiteSpace(Txt_MailCC.Text) Then
                Dim correosCC As String() = Txt_MailCC.Text.Split(";"c)
                For Each correo In correosCC
                    If Not Fx_Validar_Email(correo.Trim()) Then
                        MessageBoxEx.Show($"El correo '{correo.Trim()}' no es válido.", "Validación de Correo CC",
                                    MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If
                Next
            End If
        Else
            Txt_MailCC.Text = String.Empty
        End If

        If Chk_EnvioAnticipacion.Checked Then
            If Input_DiasEnvioAnticipacion.Value = 0 Then
                MessageBoxEx.Show("Debe ingresar la cantidad de días de anticipación para el envío del correo.", "Validación de Envío",
                MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Input_DiasEnvioAnticipacion.Focus()
                Return
            End If
        Else
            Input_DiasEnvioAnticipacion.Value = 0
        End If

        Dim _Zw_Demonio_Conf_Correo As New Zw_Demonio_Conf_Correo

        With _Zw_Demonio_Conf_Correo

            .Id = Cl_ConfCorreoAviso.Zw_Demonio_Conf_Correo.Id
            .EnviarCorreo = Chk_NVV_EnviaCorreo.Checked
            .NombreEquipo = Cl_ConfCorreoAviso.Zw_Demonio_Conf_Correo.NombreEquipo
            .Id_Padre = Cl_ConfCorreoAviso.Zw_Demonio_Conf_Correo.Id_Padre
            .Nombre_ConfCorreo = Cl_ConfCorreoAviso.Zw_Demonio_Conf_Correo.Nombre_ConfCorreo
            .Id_Correo = Txt_Nombre_Correo.Tag
            .Nombre_Correo = Txt_Nombre_Correo.Text.Trim
            .Enviar_Remitente = Rdb_Enviar_Remitente.Checked
            .MailRemitente = Txt_MailRemitente.Text.Trim
            .Enviar_VendedorCliente = Rdb_Enviar_VendedorCliente.Checked
            .Enviar_VendedorLinea = Rdb_Enviar_VendedorLinea.Checked
            .Enviar_ResponsableDoc = Rdb_Enviar_ResponsableDoc.Checked
            .Enviar_EntidadDoc = Rdb_Enviar_EntidadDoc.Checked
            .CC_Remitente = Rdb_CC_Remitente.Checked
            .MailCC = Txt_MailCC.Text.Trim
            .CC_VendedorCliente = Rdb_CC_VendedorCliente.Checked
            .CC_VendedorLinea = Rdb_CC_VendedorLinea.Checked
            .CC_ResponsableDoc = Rdb_CC_ResponsableDoc.Checked
            .CC_EntidadDoc = Rdb_CC_EntidadDoc.Checked
            .EnvioAnticipacion = Chk_NVV_EnviaCorreo.Checked
            .DiasEnvioAnticipacion = Input_DiasEnvioAnticipacion.Value

        End With

        Dim _Mensaje As New LsValiciones.Mensajes

        If CBool(Cl_ConfCorreoAviso.Zw_Demonio_Conf_Correo.Id) Then
            _Mensaje = Cl_ConfCorreoAviso.Fx_Editar_ConfCorreo(Cl_ConfCorreoAviso.Zw_Demonio_Conf_Correo.Id, _Zw_Demonio_Conf_Correo)
        Else
            _Mensaje = Cl_ConfCorreoAviso.Fx_Grabar_Nuevo_ConfCorreo(_Zw_Demonio_Conf_Correo)
        End If

        MessageBoxEx.Show(_Mensaje.Mensaje, "Validación de Correo Aviso", MessageBoxButtons.OK, _Mensaje.Icono)

        If _Mensaje.EsCorrecto Then
            Me.Close()
        End If

    End Sub

    Private Sub Rdb_Enviar_Remitente_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Enviar_Remitente.CheckedChanged
        Txt_MailRemitente.Enabled = Rdb_Enviar_Remitente.Checked
    End Sub
    Private Sub Rdb_CC_Remitente_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_CC_Remitente.CheckedChanged
        Txt_MailCC.Enabled = Rdb_CC_Remitente.Checked
    End Sub

    Private Sub Txt_MailCC_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_MailCC.ButtonCustom2Click
        Txt_MailCC.Text = String.Empty
    End Sub

    Private Sub Txt_MailRemitente_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_MailRemitente.ButtonCustom2Click
        Txt_MailRemitente.Text = String.Empty
    End Sub

    Private Sub Chk_EnvioAnticipacion_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_EnvioAnticipacion.CheckedChanged
        Input_DiasEnvioAnticipacion.Enabled = Chk_EnvioAnticipacion.Checked
    End Sub
End Class
