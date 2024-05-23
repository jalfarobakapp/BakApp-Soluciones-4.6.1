Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports DevComponents.DotNetBar

Imports Limilabs.Client.SMTP
Imports Limilabs.Mail
Imports Limilabs.Mail.Fluent
Imports Limilabs.Mail.Headers
Imports Limilabs.Mail.MIME

Public Class Frm_Correos_Conf_SMTP

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Nombre_Usuario As String
    Dim _Accion As Enum_Accion
    Dim _Grabar As Boolean

    Dim _Directorio = AppPath() & "\Data\" & RutEmpresa & "\Tmp"
    Dim _Dir_Correo = _Directorio & "\Correo"
    Dim _Dir_Correo_Imagenes = _Directorio & "\Correo\Imagenes"

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

        Dim _Mensaje As New LsValiciones.Mensajes

        '_Mensaje = Fx_Test_envio_correo_Mail2(Me, Txt_Host_SMTP.Text,
        '                         Txt_Remitente.Text, Txt_Contrasena.Text, "", "", _Asunto, _Cuerpo,
        '                         Nothing, Txt_Puerto.Text, Chk_SSL.Checked)

        _Mensaje = Fx_Test_envio_correo_Mail3(Me, Txt_Host_SMTP.Text,
                                 Txt_Remitente.Text, Txt_Contrasena.Text, "", "", _Asunto, _Cuerpo,
                                 Nothing, Txt_Puerto.Text, Chk_SSL.Checked)

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)
            Return
        End If

        csNotificaciones.Notificacion.mostrarVentana("Prueba correo",
                                                 "Correo enviado sin problemas, revise su bandeja de entrada" & vbCrLf & vbCrLf &
                                                 "Remitente : " & Txt_Remitente.Text & vbCrLf &
                                                 "Para: " & _Para,
                                                 csNotificaciones.Notificacion.Imagen.Internet, 3)
    End Sub

    Private Function Fx_Test_envio_correo_Mail2(Fm As Form,
                                          _Host_SMT As String,
                                          _Usuario As String,
                                          _Contrasena As String,
                                          _Para As String,
                                          _CC As String,
                                          _Asunto As String,
                                          _Cuerpo As String,
                                          _StrAttach() As String,
                                          Optional _Puerto As String = "25",
                                          Optional _EnableSsl As Boolean = True) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        _Asunto = "Mesaje de prueba BakApp"
        If String.IsNullOrEmpty(Trim(_Cuerpo)) Then _Cuerpo = "Mensaje de correo electrónico enviado para comprobar la configuración de su cuenta. "
        Dim _Aceptar As Boolean

        If String.IsNullOrEmpty(_Para) Then
            _Aceptar = InputBox_Bk(Fm, "Ingrese correo de respuesta", "Prueba de envio de correo (SMTP)", _Para,
                            False, _Tipo_Mayus_Minus.Normal, 0, True, _Tipo_Imagen.Texto, False)

            If Not _Aceptar Then
                Return _Mensaje
            End If
        End If

        _Mensaje.EsCorrecto = Fx_Enviar_Mail2(_Host_SMT, _Usuario, _Contrasena, _Para, _CC, _Asunto, _Cuerpo, _StrAttach, _Puerto, _EnableSsl, True)

        Return _Mensaje

    End Function

    Private Function Fx_Test_envio_correo_Mail3(Fm As Form,
                                          _Host_SMT As String,
                                          _Usuario As String,
                                          _Contrasena As String,
                                          _Para As String,
                                          _CC As String,
                                          _Asunto As String,
                                          _Cuerpo As String,
                                          _StrAttach() As String,
                                          Optional _Puerto As String = "25",
                                          Optional _EnableSsl As Boolean = True) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        _Asunto = "Mesaje de prueba BakApp"
        If String.IsNullOrEmpty(Trim(_Cuerpo)) Then _Cuerpo = "Mensaje de correo electrónico enviado para comprobar la configuración de su cuenta. "
        Dim _Aceptar As Boolean

        If String.IsNullOrEmpty(_Para) Then
            _Aceptar = InputBox_Bk(Fm, "Ingrese correo de respuesta", "Prueba de envio de correo (SMTP)", _Para,
                            False, _Tipo_Mayus_Minus.Normal, 0, True, _Tipo_Imagen.Texto, False)

            If Not _Aceptar Then
                Return _Mensaje
            End If
        End If

        _Mensaje = Fx_Enviar_Mail3IMail(_Host_SMT, _Usuario, _Contrasena, _Para, _CC, _Asunto, _Cuerpo, _StrAttach, _Puerto, _EnableSsl)

        Return _Mensaje

    End Function

    Public Function Fx_Enviar_Mail(_Host_SMT As String,
                                    _Usuario As String,
                                    _Contrasena As String,
                                    _Para As String,
                                    _CC As String,
                                    _Asunto As String,
                                    _Cuerpo As String,
                                    _StrAttach() As String,
                                   Optional _Puerto As String = "25",
                                   Optional _EnableSsl As Boolean = True,
                                   Optional _Mostrar_Error As Boolean = True) As Boolean

        Dim Servidor As New System.Net.Mail.SmtpClient

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

            Servidor.EnableSsl = _EnableSsl
            Servidor.Host = _Host_SMT
            Servidor.Port = _Puerto
            Servidor.Timeout = (1000 * 60) * 10
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

    Public Function Fx_Enviar_Mail2(_Host_SMT As String,
                                    _Usuario As String,
                                    _Contrasena As String,
                                    _Para As String,
                                    _CC As String,
                                    _Asunto As String,
                                    _Cuerpo As String,
                                    _StrAttach() As String,
                                    _Puerto As String,
                                    _EnableSsl As Boolean,
                                    _Mostrar_Error As Boolean) As Boolean
        '_Imagenes As List(Of String),
        '_Mostrar_Error As Boolean) As Boolean

        'Dim _Directorio = AppPath() & "\Data\" & RutEmpresa & "\Tmp"
        'Dim _Dir_Correo = _Directorio & "\Correo"
        'Dim _Dir_Correo_Imagenes = _Directorio & "\Correo\Imagenes"

        If Not Directory.Exists(_Dir_Correo) Then
            System.IO.Directory.CreateDirectory(_Dir_Correo)
        End If

        If Not Directory.Exists(_Dir_Correo_Imagenes) Then
            System.IO.Directory.CreateDirectory(_Dir_Correo_Imagenes)
        End If

        Try

            If String.IsNullOrEmpty(_Asunto.Trim) Then
                Throw New System.Exception("El Asunto no puede estar vacio")
            End If


            'DEFINE QUE ESTAMOS ENVIANDO UN MAIL EN FORMATO HTML
            Dim _VistaHTML As AlternateView = AlternateView.CreateAlternateViewFromString(_Cuerpo, Nothing, System.Net.Mime.MediaTypeNames.Text.Html)

            If IsNothing(_CC) Then _CC = String.Empty

            _Para = _Para.Trim()
            _CC = _CC.Trim()

            _CC = Replace(_CC, ",", ";")

            'Declaro la variable para enviar el correo
            Dim _Correo As New MailMessage()
            _Correo.From = New System.Net.Mail.MailAddress(_Usuario)
            _Correo.Subject = _Asunto

            For Each _To As String In _Para.Split(New Char() {";"c})
                _Correo.To.Add(New System.Net.Mail.MailAddress(_To))
            Next

            '_Correo.To.Add(_Para)

            If Not String.IsNullOrEmpty(_CC) Then
                For Each _Cc_ As String In _CC.Split(New Char() {";"c})
                    _Correo.CC.Add(New System.Net.Mail.MailAddress(_Cc_))
                Next
                '_Correo.CC.Add(_CC)
            End If

            'DEFINE DE DONDE SE OBTIENEN LAS IMAGENES

            Dim _Imagenes As New List(Of String)
            Dim _IdImagenes As New List(Of String)

            Dim _Dir_Imagenes = "Data\" & RutEmpresa & "\Tmp\Correo\Imagenes\"
            Dim _ContImg = 0
            Dim _UlImg = 0
            ' Incorporacion de imagenes Random
            For i = 0 To 32

                If _Cuerpo.Contains("cid:IMG" & i) Then
                    If System.IO.File.Exists(_Dir_Imagenes & "IMG" & i & ".jpg") Then
                        _Imagenes.Add(_Dir_Imagenes & "IMG" & i & ".jpg")
                        _IdImagenes.Add("IMG" & i)
                        _UlImg = i
                    End If
                    If System.IO.File.Exists(_Dir_Imagenes & "IMG" & i & ".jpeg") Then
                        _Imagenes.Add(_Dir_Imagenes & "IMG" & i & ".jpeg")
                        _IdImagenes.Add("IMG" & i)
                        _UlImg = i
                    End If
                End If

            Next

            ' Incorporación de imagenes de funcionarios

            Consulta_Sql = "Select KOFU From TABFU"
            Dim _Tbl_Funcionarios As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

            For Each _Fila As DataRow In _Tbl_Funcionarios.Rows

                Dim _Kofu = _Fila.Item("KOFU")

                If _Cuerpo.Contains("cid:" & _Kofu) Then
                    If System.IO.File.Exists(_Dir_Imagenes & _Kofu & ".jpg") Then
                        _Imagenes.Add(_Dir_Imagenes & _Kofu & ".jpg")
                        _IdImagenes.Add(_Kofu)
                    End If
                    If System.IO.File.Exists(_Dir_Imagenes & _Kofu & ".jpeg") Then
                        _Imagenes.Add(_Dir_Imagenes & _Kofu & ".jpeg")
                        _IdImagenes.Add(_Kofu)
                    End If
                End If

            Next

            For Each _Imagen As String In _Imagenes

                Dim _Img As String

                _Img = Replace(_Imagen, _Dir_Imagenes, "")
                _Img = Replace(_Img, ".jpg", "")
                _Img = Replace(_Img, ".jpeg", "")

                If _Cuerpo.Contains("cid:" & _Img) Then

                    Dim _Link_Imagen As LinkedResource = New LinkedResource(_Imagen, System.Net.Mime.MediaTypeNames.Image.Jpeg)

                    _Link_Imagen.ContentId = _IdImagenes.Item(_ContImg) ' "IMG" & _ContImg
                    _VistaHTML.LinkedResources.Add(_Link_Imagen)        ' LA AÑADE AL MENSAJE HTML

                    _ContImg += 1

                End If

            Next

            ' *******************

            'Dim MENSAJE As MailMessage = New MailMessage 'DECLARA EL MENSAJE....
            _Correo.AlternateViews.Add(_VistaHTML) '... Y QUE VA EN FORMATO HTML

            _Correo.Body = _Cuerpo
            _Correo.Priority = System.Net.Mail.MailPriority.Normal
            '_Correo.IsBodyHtml = True

            ' Esta comprobación es conveniente, ya que si el Array aún no está dimensionado, dará error.
            Dim xi

            Try
                ' simplemente para saber si se produce error
                xi = _StrAttach.Length
            Catch
                ' Si se produce un error, asignamos el valor cero, que más abajo indicará si el array contien datos o no
                xi = 0
            End Try

            Dim _Archivos_Adjuntos As Net.Mail.Attachment
            Dim _AttAdj As New List(Of Net.Mail.Attachment)

            If xi > 0 Then
                For Each strFile In _StrAttach
                    If Not IsNothing(strFile) Then
                        '_Correo.Attachments.Add(New System.Net.Mail.Attachment(Trim(strFile)))
                        _Archivos_Adjuntos = New Net.Mail.Attachment(strFile.Trim)
                        If IsNothing(_Archivos_Adjuntos) Then
                            xi = 0
                        Else
                            _AttAdj.Add(_Archivos_Adjuntos)
                            _Correo.Attachments.Add(_Archivos_Adjuntos)
                        End If
                    End If
                Next
            End If

            '_EnableSsl = True
            '_Puerto = 465

            'Configuracion del servidor
            Dim Servidor As New System.Net.Mail.SmtpClient(_Host_SMT)
            Servidor.Credentials = New System.Net.NetworkCredential(_Usuario, _Contrasena)
            Servidor.EnableSsl = _EnableSsl
            Servidor.Port = _Puerto
            'Servidor.Host = _Host_SMT


            'Servidor.UseDefaultCredentials = True
            'ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12


            Servidor.Send(_Correo)

            If xi > 0 Then

                For Each _Arch As Net.Mail.Attachment In _AttAdj
                    _Arch.Dispose()
                Next

                '_Archivos_Adjuntos.Dispose()
                _Correo.Attachments.Clear()
            End If

            Return True

        Catch ex As Exception

            If _Mostrar_Error Then
                MsgBox(ex.Message)
            End If

            Return False

        End Try

    End Function

    Function Fx_Enviar_Mail3IMail(_Host_SMT As String,
                                  _Usuario As String,
                                  _Contrasena As String,
                                  _Para As String,
                                  _CC As String,
                                  _Asunto As String,
                                  _Cuerpo As String,
                                  _StrAttach() As String,
                                  _Puerto As Integer,
                                  _EnableSsl As Boolean) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            If String.IsNullOrEmpty(_Asunto.Trim) Then
                Throw New System.Exception("El Asunto no puede estar vacio")
            End If

            Dim builder As New MailBuilder()
            builder.From.Add(New MailBox(_Usuario))
            builder.[To].Add(New MailBox(_Para))
            builder.Subject = _Asunto
            builder.Html = _Cuerpo '"<img src=""cid:lemon@id"" align=""left"" /> This is simple <strong>HTML email</strong> with an image and attachment"

            'Dim visual As MimeData = builder.AddVisual("Lemon.jpg")
            'visual.ContentId = "lemon@id"

            'DEFINE DE DONDE SE OBTIENEN LAS IMAGENES

            Dim _Imagenes As New List(Of String)
            Dim _IdImagenes As New List(Of String)

            Dim _Dir_Imagenes = "Data\" & RutEmpresa & "\Tmp\Correo\Imagenes\"
            Dim _ContImg = 0
            Dim _UlImg = 0
            ' Incorporacion de imagenes Random
            For i = 0 To 32

                If _Cuerpo.Contains("cid:IMG" & i) Then
                    If System.IO.File.Exists(_Dir_Imagenes & "IMG" & i & ".jpg") Then
                        Dim visual As MimeData = builder.AddVisual(_Dir_Imagenes & "IMG" & i & ".jpg")
                        visual.ContentId = "IMG" & i
                        _UlImg = i
                    End If
                    If System.IO.File.Exists(_Dir_Imagenes & "IMG" & i & ".jpeg") Then
                        Dim visual As MimeData = builder.AddVisual(_Dir_Imagenes & "IMG" & i & ".jpeg")
                        visual.ContentId = "IMG" & i
                        _UlImg = i
                    End If
                End If

            Next


            'Dim attachment As MimeData = builder.AddAttachment("Attachment.txt")
            'attachment.SetFileName("Attachment.txt", guessContentType:=True)

            Dim xi

            Try
                ' simplemente para saber si se produce error
                xi = _StrAttach.Length
            Catch
                ' Si se produce un error, asignamos el valor cero, que más abajo indicará si el array contien datos o no
                xi = 0
            End Try

            Dim _Archivos_Adjuntos As Net.Mail.Attachment
            Dim _AttAdj As New List(Of Net.Mail.Attachment)
            Dim _Adjunto As String = String.Empty

            If xi > 0 Then
                For Each strFile In _StrAttach
                    If Not IsNothing(strFile) Then
                        '_Correo.Attachments.Add(New System.Net.Mail.Attachment(Trim(strFile)))
                        _Archivos_Adjuntos = New Net.Mail.Attachment(strFile.Trim)
                        If IsNothing(_Archivos_Adjuntos) Then
                            xi = 0
                        Else
                            Dim attachment As MimeData = builder.AddAttachment(strFile.Trim)
                            attachment.SetFileName("Attachment.txt", guessContentType:=True)
                            _Adjunto = strFile.Trim
                            Exit For
                        End If
                    End If
                Next
            End If

            Dim email As IMail = builder.Create()

            'Dim email As IMail

            'If Not String.IsNullOrEmpty(_Adjunto) Then
            '    email = Mail _
            '    .Html(_Cuerpo) _
            '    .Subject("Asunto") _
            '    .AddAttachment("Attachment.txt").SetFileName("Invoice.txt") _
            '    .From(New MailBox(_User)) _
            '    .To(New MailBox(_Para, _Para)) _
            '    .Create()
            'Else
            '    email = Mail _
            '    .Html(_Cuerpo) _
            '    .Subject(_Asunto) _
            '    .From(New MailBox(_User)) _
            '    .To(New MailBox(_Para, _Para)) _
            '    .Create()
            'End If

            'email.Save("SampleEmail.eml")                   ' You can save the email for preview.


            Using smtp As New Smtp
                'Now connect to SMTP server and send it
                If _EnableSsl Then
                    smtp.Connect(_Host_SMT)                       ' Use overloads or ConnectSSL if you need to specify different port or SSL.
                Else
                    smtp.Connect(_Host_SMT, _Puerto, _EnableSsl)                       ' Use overloads or ConnectSSL if you need to specify different port or SSL.
                End If

                'smtp.IsEncrypted = True
                'Smtp.DefaultPort = _Puerto
                smtp.SSLConfiguration.EnabledSslProtocols = _EnableSsl ' True
                smtp.UseBestLogin(_Usuario, _Contrasena)         ' You can also use: Login, LoginPLAIN, LoginCRAM, LoginDIGEST, LoginOAUTH methods,
                ' or use UseBestLogin method if you want Mail.dll to choose for you.
                'Smtp.DefaultPort = 456
                Dim result As ISendMessageResult = smtp.SendMessage((email))
                Console.WriteLine(result.Status.ToString)
                Console.WriteLine(result.AllResponses.ToString)
                Console.WriteLine(result.FromRejected.ToString)
                Console.WriteLine(result.GeneralErrors.ToString)
                Console.WriteLine(result.RejectedRecipients.ToString)
                Console.WriteLine(result.RejectedRecipientsErrors.ToString)

                'Console.ReadKey()
                smtp.Close()

                If result.Status = SendMessageStatus.Success Then
                    _Mensaje.EsCorrecto = True
                End If

                Return result

            End Using

        Catch ex As Exception
            _Mensaje.Detalle = "Problema al enviar el correo"
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop
        End Try

        Return _Mensaje

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
