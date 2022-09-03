Imports DevComponents.DotNetBar
Public Class Frm_Correos_Conf_SMTP

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Nombre_Usuario As String
    Dim _Accion As Enum_Accion
    Dim _Grabar As Boolean

    Public Property Pro_Nombre_Usuario As String
        Get
            Return _Nombre_Usuario
        End Get
        Set(value As String)
            _Nombre_Usuario = value
        End Set
    End Property
    Public ReadOnly Property Pro_Grabar As Boolean
        Get
            Return _Grabar
        End Get
    End Property

    Enum Enum_Accion
        Nuevo
        Editar
    End Enum
    Public Sub New(Accion As Enum_Accion)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Accion = Accion

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Correos_Conf_SMTP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If _Accion = Enum_Accion.Nuevo Then

            Btn_Eliminar.Visible = False

        ElseIf _Accion = Enum_Accion.Editar Then

            Consulta_Sql = "Select Nombre_Usuario,Contrasena,Host,Puerto,SSL 
                            From " & _Global_BaseBk & "Zw_Correos_Cuentas Where Nombre_Usuario = '" & _Nombre_Usuario & "'"
            Dim _Row_Cuenta As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

            Txt_Remitente.Text = _Row_Cuenta.Item("Nombre_Usuario")
            Txt_Contrasena.Text = _Row_Cuenta.Item("Contrasena")
            Txt_Host_SMTP.Text = _Row_Cuenta.Item("Host")
            Txt_Puerto.Text = _Row_Cuenta.Item("Puerto")
            Chk_SSL.Checked = _Row_Cuenta.Item("SSL")
            Txt_Remitente.Enabled = False

        End If

    End Sub

    Private Sub Btn_Probar_Envio_Click(sender As Object, e As EventArgs) Handles Btn_Probar_Envio.Click

        Dim _Asunto = "Mesaje de prueba BakApp"
        Dim _Cuerpo = "Mensaje de correo electrónico enviado para comprobar la configuración de su cuenta. "
        Dim _Para = String.Empty

        'Dim _Aceptar As Boolean

        '_Aceptar = InputBox_Bk(Me, "Ingrese correo de respuesta", "Prueba de envio de correo (SMTP)", _Para,
        '           False, _Tipo_Mayus_Minus.Normal, 0, True, _Tipo_Imagen.Texto, False)

        'If _Aceptar Then

        If Fx_Test_envio_correo(Me, Txt_Host_SMTP.Text,
                                 Txt_Remitente.Text, Txt_Contrasena.Text, "", "", _Asunto, _Cuerpo,
                                 Nothing, Txt_Puerto.Text, Chk_SSL.Checked) Then

            csNotificaciones.Notificacion.mostrarVentana("Prueba correo",
                                                             "Correo enviado sin problemas, revise su bandeja de entrada" & vbCrLf & vbCrLf &
                                                             "Remitente : " & Txt_Remitente.Text & vbCrLf &
                                                             "Para: " & _Para,
                                                             csNotificaciones.Notificacion.Imagen.Internet, 5, True, Me)
        End If

        'End If

    End Sub

    Private Function Fx_Test_envio_correo(ByVal Fm As Form,
                                          ByVal _Host_SMT As String,
                                          ByVal _Usuario As String,
                                          ByVal _Contrasena As String,
                                          ByVal _Para As String,
                                          ByVal _CC As String,
                                          ByVal _Asunto As String,
                                          ByVal _Cuerpo As String,
                                          ByVal _StrAttach() As String,
                                          Optional ByVal _Puerto As String = "25",
                                          Optional ByVal _EnableSsl As Boolean = True)

        _Asunto = "Mesaje de prueba BakApp"
        If String.IsNullOrEmpty(Trim(_Cuerpo)) Then _Cuerpo = "Mensaje de correo electrónico enviado para comprobar la configuración de su cuenta. "
        Dim _Aceptar As Boolean

        If String.IsNullOrEmpty(_Para) Then
            _Aceptar = InputBox_Bk(Fm, "Ingrese correo de respuesta", "Prueba de envio de correo (SMTP)", _Para,
                            False, _Tipo_Mayus_Minus.Normal, 0, True, _Tipo_Imagen.Texto, False)

            If Not _Aceptar Then
                Return False
            End If
        End If

        If Fx_Enviar_Mail(_Host_SMT, _Usuario, _Contrasena, _Para, _CC, _Asunto, _Cuerpo, _StrAttach, _Puerto, _EnableSsl) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function Fx_Enviar_Mail(ByVal _Host_SMT As String,
                                   ByVal _Usuario As String,
                                   ByVal _Contrasena As String,
                                   ByVal _Para As String,
                                   ByVal _CC As String,
                                   ByVal _Asunto As String,
                                   ByVal _Cuerpo As String,
                                   ByVal _StrAttach() As String,
                                   Optional ByVal _Puerto As String = "25",
                                   Optional ByVal _EnableSsl As Boolean = True,
                                   Optional ByVal _Mostrar_Error As Boolean = True) As Boolean
        Try

            'Dim correo As New MailMessage
            'Dim smtp As New SmtpClient()

            _CC = Replace(_CC, ";", ",")

            'Declaro la variable para enviar el correo
            Dim correo As New System.Net.Mail.MailMessage()
            correo.From = New System.Net.Mail.MailAddress(_Usuario)
            correo.Subject = _Asunto
            correo.To.Add(_Para)
            If Not String.IsNullOrEmpty(_CC) Then correo.CC.Add(_CC)
            correo.Body = _Cuerpo
            correo.Priority = System.Net.Mail.MailPriority.Normal
            correo.IsBodyHtml = True


            ' Esta comprobación es conveniente, ya que si el Array aún no está dimensionado, dará error.
            Dim xi

            Try
                ' simplemente para saber si se produce error
                xi = _StrAttach.Length
            Catch
                ' Si se produce un error, asignamos el valor cero, que más abajo indicará si el array contien datos o no
                xi = 0
            End Try

            If xi > 0 Then
                For Each strFile In _StrAttach
                    correo.Attachments.Add(New System.Net.Mail.Attachment(Trim(strFile)))
                Next
            End If

            'Configuracion del servidor
            Dim Servidor As New System.Net.Mail.SmtpClient
            Servidor.EnableSsl = _EnableSsl
            Servidor.Host = _Host_SMT
            Servidor.Port = _Puerto
            'Servidor.UseDefaultCredentials = True

            Servidor.Credentials = New System.Net.NetworkCredential(_Usuario, _Contrasena)

            Servidor.Send(correo)

            Return True

        Catch ex As Exception
            If _Mostrar_Error Then
                MsgBox(ex.Message)
            End If
            Return False

        End Try

    End Function

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Correos_Cuentas Where Nombre_Usuario = '" & Txt_Remitente.Text & "'
                        Insert Into " & _Global_BaseBk & "Zw_Correos_Cuentas Values ('" & Txt_Remitente.Text & "','" & Txt_Contrasena.Text &
                        "','" & Txt_Host_SMTP.Text & "','" & Txt_Puerto.Text & "'," & CInt(Chk_SSL.Checked) * -1 & ")"

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then

            _Grabar = True
            Me.Close()

        End If

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Correos", "Remitente = '" & Txt_Remitente.Text & "'"))

        If CBool(_Reg) Then

            If MessageBoxEx.Show(Me, "Existen Correos de envio relacionados a este remitente" & vbCrLf & vbCrLf &
                                 "¿Desea eliminar el correo de todas formas?", "Correo con datos relacionados",
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Correos_Cuentas Where Nombre_Usuario = '" & Txt_Remitente.Text & "'"

                If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then
                    _Grabar = True
                    Me.Close()
                End If

            End If

        End If

    End Sub


End Class
