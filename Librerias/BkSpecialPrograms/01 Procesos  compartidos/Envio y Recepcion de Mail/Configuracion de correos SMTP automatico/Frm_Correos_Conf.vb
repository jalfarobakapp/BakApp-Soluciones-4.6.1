Imports DevComponents.DotNetBar
Imports System.Net.Mail
Imports EASendMail

Imports System.IO
Imports Itenso.Rtf
Imports Itenso.Rtf.Converter.Html
Imports Itenso.Rtf.Interpreter
Imports Itenso.Rtf.Support

Imports Limilabs.Client.SMTP
Imports Limilabs.Mail.Headers
Imports Limilabs.Mail.Fluent
Imports Limilabs.Mail
Imports Limilabs.Mail.MIME


Public Class Frm_Correos_Conf

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Grabar As Boolean
    Dim _Id As Integer
    Dim _Error As String

    Dim _Directorio = AppPath() & "\Data\" & RutEmpresa & "\Tmp"
    Dim _Dir_Correo = _Directorio & "\Correo"
    Dim _Dir_Correo_Imagenes = _Directorio & "\Correo\Imagenes"

    Enum Accion
        Nuevo
        Editar
        Eliminar
    End Enum

    Public _Accion As Accion

    Public ReadOnly Property Pro_Grabar()
        Get
            Return _Grabar
        End Get
    End Property
    Public Property Pro_Id() As Integer
        Get
            Return _Id
        End Get
        Set(value As Integer)
            _Id = value
        End Set
    End Property
    Public ReadOnly Property Pro_Error() As String
        Get
            Return _Error
        End Get
    End Property
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Global_Thema = Enum_Themas.Oscuro Then

            Btn_Probar_Envio.ForeColor = Color.White
            Btn_Probar_GMAIL.ForeColor = Color.White

        End If

        If Not Directory.Exists(_Dir_Correo) Then
            System.IO.Directory.CreateDirectory(_Dir_Correo)
        End If

        If Not Directory.Exists(_Dir_Correo_Imagenes) Then
            System.IO.Directory.CreateDirectory(_Dir_Correo_Imagenes)
        End If

    End Sub
    Private Sub Frm_CorreoConf_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.Cmb_Fuente.Items.Clear()

        For Each _Fuente As FontFamily In FontFamily.Families
            Dim _Nombre As String = _Fuente.Name
            Cmb_Fuente.Items.Add(_Nombre)
        Next

        Cmb_Fuente.Text = "Arial"

        Pict_Color_Fuente.BackColor = Color.Black
        Pict_Color_Resaltado.BackColor = Color.Yellow

        If Global_Thema = Enum_Themas.Oscuro Then
            Rtf_Cuerpo.BackColor = Color.White
            Rtf_Cuerpo.ForeColor = Color.Black
        End If

        If _Accion = Accion.Nuevo Then
            Btn_Eliminar.Visible = False
        ElseIf _Accion = Accion.Editar Then

            Txt_Nombre_Correo.Enabled = False
            Btn_Eliminar.Visible = True
            Txt_Nombre_Correo.Enabled = False
            ConvertHtmlUrlToRtfFile()

        End If

        ' COMO INCOPRORAR FOTOS DE LOS FUNCIONARIOS
        ' @Img_Ini<CodFuncionario>@Img_Fin
        ' Se debe incorporar una funcion como esta para inlcuir la foto o firma de los funcionarios.

        Chk_Es_Html.Checked = True

    End Sub


#Region "PROCEDIMIENTOS"

    '.Host = “smtp.gmail.com” ‘Servidor SMTP de Gmail
    '.Port = 587 ‘Puerto del SMTP de Gmail

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
        Try

            'Dim correo As New MailMessage
            'Dim smtp As New SmtpClient()

            _Para = _Para.Trim()
            _CC = _CC.Trim()

            _CC = Replace(_CC, ",", ";")

            'Declaro la variable para enviar el correo
            Dim correo As New MailMessage()
            correo.From = New System.Net.Mail.MailAddress(_Usuario)
            correo.Subject = _Asunto

            For Each _To As String In _Para.Split(New Char() {";"c})
                correo.To.Add(New System.Net.Mail.MailAddress(_To))
            Next

            'correo.To.Add(_Para)

            If Not String.IsNullOrEmpty(_CC) Then
                For Each _Cc_ As String In _CC.Split(New Char() {";"c})
                    correo.CC.Add(New System.Net.Mail.MailAddress(_Cc_))
                Next
                'correo.CC.Add(_CC)
            End If

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

            Dim _Archivos_Adjuntos As Net.Mail.Attachment

            If xi > 0 Then
                For Each strFile In _StrAttach
                    If Not IsNothing(strFile) Then
                        'correo.Attachments.Add(New System.Net.Mail.Attachment(Trim(strFile)))
                        _Archivos_Adjuntos = New Net.Mail.Attachment(strFile.Trim)
                    End If
                Next
                If IsNothing(_Archivos_Adjuntos) Then
                    xi = 0
                Else
                    correo.Attachments.Add(_Archivos_Adjuntos)
                End If
            End If

            'Configuracion del servidor
            Dim Servidor As New System.Net.Mail.SmtpClient
            Servidor.EnableSsl = _EnableSsl
            Servidor.Host = _Host_SMT
            Servidor.Port = _Puerto
            'Servidor.UseDefaultCredentials = True

            Servidor.Credentials = New System.Net.NetworkCredential(_Usuario, _Contrasena)

            Servidor.Send(correo)

            If xi > 0 Then
                _Archivos_Adjuntos.Dispose()
                correo.Attachments.Clear()
            End If

            Return True

        Catch ex As Exception
            If _Mostrar_Error Then
                MsgBox(ex.Message)
            End If
            _Error = ex.Message
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

            Consulta_sql = "Select KOFU From TABFU"
            Dim _Tbl_Funcionarios As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

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
            Dim Servidor As New System.Net.Mail.SmtpClient
            Servidor.EnableSsl = _EnableSsl
            Servidor.Host = _Host_SMT
            Servidor.Port = _Puerto
            'Servidor.UseDefaultCredentials = True

            Servidor.Credentials = New System.Net.NetworkCredential(_Usuario, _Contrasena)

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
            _Error = ex.Message
            Return False

        End Try

    End Function

    Public Sub GMailSender(_Username As String,
                            _Password As String,
                            _Asunto As String,
                            _Body As String,
                            _Addresses As String)
        Try


            Using MailSetup As New System.Net.Mail.MailMessage

                MailSetup.Subject = _Asunto
                MailSetup.To.Add(_Addresses)
                MailSetup.From = New System.Net.Mail.MailAddress(_Username)
                MailSetup.Body = _Body
                MailSetup.IsBodyHtml = False
                MailSetup.Priority = System.Net.Mail.MailPriority.High

                Dim SMTP As New System.Net.Mail.SmtpClient("smtp.gmail.com")
                SMTP.Port = 587
                SMTP.UseDefaultCredentials = True
                SMTP.EnableSsl = True
                SMTP.Credentials = New Net.NetworkCredential(_Username, _Password)

                SMTP.Send(MailSetup)
            End Using ' SMTP

            'End Using ' MailSetup
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Function Fx_Grabar() As Boolean

        Dim _Cuerpo As String = Replace(Txt_Cuerpo.Text, "'", "''")

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Correos (Nombre_Correo,Remitente,Contrasena,Host,Puerto,Asunto,Auto_Asunto,Para,CC," &
                       "CuerpoMensaje,Firma,SSL,Envio_Automatico,Es_Html) Values " &
                        "('" & Txt_Nombre_Correo.Text & "','" & Txt_Remitente.Text & "','" & Txt_Contrasena.Text &
                        "','" & Txt_Host_SMTP.Text & "','" & Txt_Puerto.Text & "','" & Txt_Asunto.Text &
                        "'," & CInt(Chk_Auto_Asunto.Checked) & ",'" & Txt_Para.Text & "','" & Txt_CC.Text & "','" & _Cuerpo &
                        "'," & CInt(Chk_Firma.Checked) & "," & CInt(Chk_SSL.Checked) &
                        "," & CInt(Rdb_Envio_Automatico.Checked) & "," & CInt(Chk_Es_Html.Checked) & ")"
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            MessageBoxEx.Show(Me, "Correo creado correctamente", "Crear correo (SMTP)", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        End If

    End Function

    Private Function Fx_Editar() As Boolean

        Dim _Cuerpo As String = Replace(Txt_Cuerpo.Text, "'", "''")

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Correos Set " &
                       "Remitente = '" & Txt_Remitente.Text & "'" &
                       ",Contrasena = '" & Txt_Contrasena.Text &
                       "',Host = '" & Txt_Host_SMTP.Text &
                       "',Puerto = '" & Txt_Puerto.Text &
                       "',Asunto = '" & Txt_Asunto.Text &
                       "',Auto_Asunto = " & CInt(Chk_Auto_Asunto.Checked) & vbCrLf &
                       ",Para = '" & Txt_Para.Text &
                       "',CC = '" & Txt_CC.Text &
                       "',CuerpoMensaje = '" & _Cuerpo &
                       "',Firma = " & CInt(Chk_Firma.Checked) & vbCrLf &
                       ",SSL = " & CInt(Chk_SSL.Checked) * -1 & vbCrLf &
                       ",Envio_Automatico = " & CInt(Rdb_Envio_Automatico.Checked) & vbCrLf &
                       ",Es_Html = " & CInt(Chk_Es_Html.Checked) & vbCrLf &
                       "Where Id = " & _Id
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            MessageBoxEx.Show(Me, "Correo actualizado correctamente", "Modificar correo (SMTP)", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        End If

    End Function
    Private Function Fx_Eliminar(Fm As Form, _Remitente As String)

        If MessageBoxEx.Show(Fm, "¿Esta seguro de eliminar este correo de salida SMTP?", "Eliminar correo",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Correos Where Nombre_Correo = '" & Txt_Nombre_Correo.Text & "'"
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If

    End Function

    Private Function Fx_Test_envio_correo(Fm As Form,
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

        If String.IsNullOrEmpty(Trim(_Cuerpo)) Then _Cuerpo = "Mensaje de correo electrónico enviado para comprobar la configuración de su cuenta. "
        Dim _Aceptar As Boolean

        If String.IsNullOrEmpty(_Para) Then

            _Aceptar = InputBox_Bk(Fm, "Ingrese correo de respuesta", "Prueba de envio de correo (SMTP)", _Para,
                                   False, _Tipo_Mayus_Minus.Normal, 0, True, _Tipo_Imagen.Texto, False)

            If Not _Aceptar Then

                _Mensaje.EsCorrecto = False
                _Mensaje.Mensaje = "El correo de respuesta no puede estar vacio"
                _Mensaje.Detalle = "Test envío de correo"

                Return _Mensaje

            End If

        End If

        _Asunto = "Mesaje de prueba BakApp (" & Now & ")"

        _Cuerpo = Replace(_Cuerpo, "&lt;", "<")
        _Cuerpo = Replace(_Cuerpo, "&gt;", ">")
        _Cuerpo = Replace(_Cuerpo, "&quot;", """")

        'Dim result As ISendMessageResult = Fx_Enviar_Mail3IMail(_Host_SMT,
        '                                                        _Usuario,
        '                                                        _Contrasena,
        '                                                        _Para,
        '                                                        _CC,
        '                                                        _Asunto,
        '                                                        _Cuerpo,
        '                                                        _StrAttach,
        '                                                        _Puerto,
        '                                                        _EnableSsl)

        _Mensaje = Fx_Enviar_Mail3IMail(_Host_SMT,
                                        _Usuario,
                                        _Contrasena,
                                        _Para,
                                        _CC,
                                        _Asunto,
                                        _Cuerpo,
                                        _StrAttach,
                                        _Puerto,
                                        _EnableSsl)

        Return _Mensaje

        'If _Mensaje.EsCorrecto = 0 Then 'Fx_Enviar_Mail3IMail(_Host_SMT, _Usuario, _Contrasena, _Para, _CC, _Asunto, _Cuerpo, _StrAttach, _Puerto, _EnableSsl, True) Then
        '    Return True
        'Else
        '    Return False
        'End If

        'If Fx_Enviar_Mail2(_Host_SMT, _Usuario, _Contrasena, _Para, _CC, _Asunto, _Cuerpo, _StrAttach, _Puerto, _EnableSsl, True) Then
        '    Return True
        'Else
        '    Return False
        'End If

        'If Fx_Enviar_Mail(_Host_SMT, _Usuario, _Contrasena, _Para, _CC, _Asunto, _Cuerpo, _StrAttach, _Puerto, _EnableSsl) Then
        '    Return True
        'Else
        '    Return False
        'End If

    End Function
    Sub Sb_Enviar_Correo_EASendMail_SSL()

        Dim oMail As New EASendMail.SmtpMail("TryIt")
        Dim oSmtp As New EASendMail.SmtpClient()

        ' Your gmail email address
        oMail.From = "test.bakapp@gmail.com"

        ' Set recipient email address, please change it to yours
        oMail.To = "jalfaro@bakapp.cl"

        ' Set email subject
        oMail.Subject = "test email from gmail account"

        ' Set email body
        oMail.TextBody = "this is a test email sent from VB.NET project with gmail"

        'Gmail SMTP server address
        Dim oServer As New SmtpServer("smtp.gmail.com")

        ' set 465 port
        oServer.Port = 465

        ' detect SSL/TLS automatically
        oServer.ConnectType = SmtpConnectType.ConnectSSLAuto

        ' Gmail user authentication should use your 
        ' Gmail email address as the user name. 
        ' For example: your email is "gmailid@gmail.com", then the user should be "gmailid@gmail.com"
        oServer.User = "test.bakapp@gmail.com"
        oServer.Password = "B4k4pp12345"

        Try

            Console.WriteLine("start to send email over SSL ...")
            oSmtp.SendMail(oServer, oMail)
            Console.WriteLine("email was sent successfully!")

        Catch ep As Exception
            MsgBox(ep.Message)
            'Console.WriteLine("failed to send email with the following error:")
            'Console.WriteLine(ep.Message)
        End Try

    End Sub
    Sub Sb_Enviar_Correo_EASendMail_SSL_TLS()

        Dim oMail As New EASendMail.SmtpMail("TryIt")
        Dim oSmtp As New EASendMail.SmtpClient()

        ' Your gmail email address
        oMail.From = "jalfaro@bakapp.cl" 'Txt_Remitente.Text '"test.bakapp@gmail.com"

        ' Set recipient email address, please change it to yours
        oMail.To = "jalfaro@bakapp.cl"

        ' Set email subject
        oMail.Subject = "test email from gmail account"

        ' Set email body
        oMail.TextBody = "this is a test email sent from VB.NET project with gmail"

        'Gmail SMTP server address
        Dim oServer As New SmtpServer("smtp.gmail.com")

        ' set 25 port, if you want to use 587 port, please change 25 to 587
        oServer.Port = 25

        ' detect SSL/TLS automatically
        oServer.ConnectType = SmtpConnectType.ConnectSSLAuto

        ' Gmail user authentication should use your 
        ' Gmail email address as the user name. 
        ' For example: your email is "gmailid@gmail.com", then the user should be "gmailid@gmail.com"
        oServer.User = Txt_Remitente.Text '"test.bakapp@gmail.com"
        oServer.Password = Txt_Contrasena.Text '"B4k4pp12345"

        Try

            Console.WriteLine("start to send email over SSL ...")
            oSmtp.SendMail(oServer, oMail)
            Console.WriteLine("email was sent successfully!")

        Catch ep As Exception
            MsgBox(ep.Message)
            'Console.WriteLine("failed to send email with the following error:")
            'Console.WriteLine(ep.Message)
        End Try


    End Sub

#End Region
    Private Sub Btn_Grabar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Grabar.Click

        Sb_Convertir_Rtf2Html(False)

        If _Accion = Accion.Nuevo Then
            If Fx_Grabar() Then
                _Grabar = True
                Me.Close()
            End If
        ElseIf _Accion = Accion.Editar Then
            If Fx_Editar() Then
                _Grabar = True
            End If
        End If

    End Sub
    Private Sub Btn_Probar_Envio_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Probar_Envio.Click

        Sb_Convertir_Rtf2Html(False)

        If Rdb_Envio_Automatico.Checked Then

            Dim _Mensaje As New LsValiciones.Mensajes

            _Mensaje = Fx_Test_envio_correo(Me, Txt_Host_SMTP.Text,
                                            Txt_Remitente.Text, Txt_Contrasena.Text, "", Txt_CC.Text, "", Txt_Cuerpo.Text,
                                            Nothing, Txt_Puerto.Text, Chk_SSL.Checked)

            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

            'If _Mensaje.EsCorrecto Then

            '    MessageBoxEx.Show(Me, "Correo enviado sin problemas, revise su bandeja de entrada",
            '                      "Correo de pruebas", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Else

            '    MessageBoxEx.Show(Me, "Error al enviar el correo" & vbCrLf & vbCrLf &
            '                      "Error: " & _Mensaje.Mensaje & vbCrLf & vbCrLf &
            '                      "Detalle: " & _Mensaje.Detalle,
            '                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)


            'End If

        Else
            Dim Envio_Occ_Mail As New Class_Outlook
            Envio_Occ_Mail.Sb_Crear_Correo_Outlook("", Nothing, "Correo de pruebas", Txt_Cuerpo.Text, Chk_Es_Html.Checked)
        End If

    End Sub
    Private Sub Btn_Eliminar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Eliminar.Click
        If Fx_Tiene_Permiso(Me, "Mail0004") Then
            If Fx_Eliminar(Me, Txt_Remitente.Text) Then
                _Grabar = True
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Btn_Ver_Contrasena_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Btn_Ver_Contrasena.MouseDown
        Txt_Contrasena.PasswordChar = ""
    End Sub

    Private Sub Btn_Ver_Contrasena_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Btn_Ver_Contrasena.MouseUp
        Txt_Contrasena.PasswordChar = "*"
    End Sub

    Private Sub Frm_CorreoConf_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Rdb_Envio_Manual_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rdb_Envio_Manual.CheckedChanged
        Grupo_Info_Sesion.Enabled = Rdb_Envio_Automatico.Checked
    End Sub

    Private Sub ButtonItem1_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Probar_GMAIL.Click
        'Sb_Enviar_Correo_EASendMail()
        Sb_Enviar_Correo_EASendMail_SSL_TLS()
    End Sub

    Private Sub Btn_Cuentas_Click(sender As Object, e As EventArgs) Handles Btn_Cuentas.Click

        Dim _Row_Cuenta As DataRow

        Dim Fm As New Frm_Correos_Conf_SMTP_Lista(Frm_Correos_Conf_SMTP_Lista.Enum_Accion.Seleccionar)
        Fm.ShowDialog(Me)
        _Row_Cuenta = Fm.Pro_Row_Cuenta
        Fm.Dispose()

        If Not IsNothing(_Row_Cuenta) Then

            Txt_Remitente.Text = _Row_Cuenta.Item("Nombre_Usuario")
            Txt_Contrasena.Text = _Row_Cuenta.Item("Contrasena")
            Txt_Host_SMTP.Text = _Row_Cuenta.Item("Host")
            Txt_Puerto.Text = _Row_Cuenta.Item("Puerto")
            Chk_SSL.Checked = _Row_Cuenta.Item("SSL")

        End If

    End Sub

    Private Sub Btn_Vista_Previa_Click(sender As Object, e As EventArgs) Handles Btn_Vista_Previa.Click

        Sb_Convertir_Rtf2Html(True)

        'Dim Fm As New Frm_Correos_Browser
        'Fm.WebBrowser.DocumentText = _Cuerpo
        'Fm.ShowDialog(Me)
        'Fm.Dispose()

    End Sub

    Private Function ConvertRtfToHtml(_Ruta_Archivo_Rtf As String) As String

        Dim sampleRtfText As String = ""
        Dim stmReader As New System.IO.StreamReader(_Ruta_Archivo_Rtf) '("D:\DefaultText.rtf")

        sampleRtfText = stmReader.ReadToEnd

        Dim rtfDocument As IRtfDocument = RtfInterpreterTool.BuildDoc(sampleRtfText)
        Dim settings As RtfHtmlConvertSettings = New RtfHtmlConvertSettings()

        settings.ConvertScope = RtfHtmlConvertScope.Content

        Dim htmlConverter As RtfHtmlConverter = New RtfHtmlConverter(rtfDocument, settings)

        Return htmlConverter.Convert()

    End Function

    Sub Sb_Convertir_Rtf2Html(_Vista_Previa As Boolean)

        Dim _Ruta_Archivo_Rtf = _Dir_Correo & "DefaultText.rtf"

        Dim exists = System.IO.File.Exists(_Ruta_Archivo_Rtf)
        If exists Then
            File.Delete(_Ruta_Archivo_Rtf)
        End If

        Rtf_Cuerpo.SaveFile(_Ruta_Archivo_Rtf, RichTextBoxStreamType.RichText)

        Dim _Error As String = Fx_Convertir_Rtf2Html(_Ruta_Archivo_Rtf, False)

        If Not String.IsNullOrEmpty(_Error) Then
            MessageBoxEx.Show(Me, _Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Txt_Cuerpo.Text = LeeArchivo(AppPath() & "\Result.html")

        '&lt;img src=&quot;cid:IMG1&quot;&gt
        '<img src = "cid:IMG1" >

        Dim a = "</div><div style=""text-align:center;"">The unlicensed version of &laquo;RTF to HTML .Net&raquo;.<br><a href=""https://www.sautinsoft.com/products/rtf-to-html/order.php"">Get the full featured version!</a></div>"

        Txt_Cuerpo.Text = Replace(Txt_Cuerpo.Text, a, "")

        Txt_Cuerpo.Text = Replace(Txt_Cuerpo.Text, "</span><span class=""st2"">", "")
        Txt_Cuerpo.Text = Replace(Txt_Cuerpo.Text, "</span><span class=""st1"">", "")

        Dim _Cuerpo As String

        _Cuerpo = Txt_Cuerpo.Text

        For i = 1 To 32

            Dim _Dir_Imagenes = _Dir_Correo_Imagenes & "\" & "IMG" & i

            If _Cuerpo.Contains("cid:IMG" & i) Then
                If System.IO.File.Exists(_Dir_Imagenes & ".jpg") Then
                    _Cuerpo = Replace(_Cuerpo, "cid:IMG" & i, _Dir_Imagenes & ".jpg")
                End If
                If System.IO.File.Exists(_Dir_Imagenes & ".jpeg") Then
                    _Cuerpo = Replace(_Cuerpo, "cid:IMG" & i, _Dir_Imagenes & ".jpeg")
                End If
                If System.IO.File.Exists(_Dir_Imagenes & ".png") Then
                    _Cuerpo = Replace(_Cuerpo, "cid:IMG" & i, _Dir_Imagenes & ".png")
                End If
            End If

        Next

        _Cuerpo = Replace(_Cuerpo, a, "")

        _Cuerpo = "<html><body>" & vbCrLf & vbCrLf & _Cuerpo & vbCrLf & vbCrLf & "</body></html>"

        If _Vista_Previa Then

            _Cuerpo = Replace(_Cuerpo, "&lt;", "<")
            _Cuerpo = Replace(_Cuerpo, "&gt;", ">")
            _Cuerpo = Replace(_Cuerpo, "&quot;", """")

        End If

        My.Computer.FileSystem.WriteAllText(_Dir_Correo & "Ejemplo.Html", _Cuerpo, False)

        If _Vista_Previa Then
            Process.Start(_Dir_Correo & "Ejemplo.Html")
        End If

    End Sub

    Function Fx_Convertir_Rtf2Html(_InpFile As String, _Mostrar_Html As Boolean) As String

        Dim _Error = String.Empty

        ' Read our RTF document as string.
        'Dim inpFile As String = "..\example.rtf"
        Dim rtfString As String = File.ReadAllText(_InpFile)

        Dim outFile As String = "Result.html"

        Dim r As New SautinSoft.RtfToHtml()

        ' Specify some properties for output HTML document.
        r.OutputFormat = SautinSoft.RtfToHtml.eOutputFormat.HTML_5
        r.Encoding = SautinSoft.RtfToHtml.eEncoding.UTF_8

        ' Imagefolder must already exist.
        r.ImageStyle.ImageFolder = Environment.CurrentDirectory

        ' Subfolder for images will be created by the component.
        r.ImageStyle.ImageSubFolder = "image.files"

        ' A template name for images.
        r.ImageStyle.ImageFileName = "picture"

        ' false - store images as files on HDD,
        ' true - store images inside HTML document using base64.
        r.ImageStyle.IncludeImageInHtml = False

        Try
            r.OpenRtf(rtfString)
            r.ToHtml(outFile)

            If _Mostrar_Html Then
                ' Open the result for demonstration purposes.
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
            End If

        Catch e As Exception
            _Error = e.Message
            'Console.WriteLine($"Error: {e.Message}")
            'Console.WriteLine("Press any key ...")
            'Console.ReadKey()
        End Try

        Return _Error

    End Function
    Public Sub ConvertHtmlUrlToRtfFile()

        Dim h As New SautinSoft.HtmlToRtf()

        ' After purchasing the license, please insert your serial number here to activate the component.
        'h.Serial = "XXXXXXXXX"

        Dim exists = System.IO.File.Exists(AppPath() & "\ResultHtml2Rtf.rtf")
        If exists Then
            File.Delete(AppPath() & "\ResultHtml2Rtf.rtf")
        End If

        Dim inputFile As String = Txt_Cuerpo.Text ' "http://www.sautinsoft.net/samples/utf-8.html"
        Dim outputFile As String = "ResultHtml2Rtf.rtf"

        ' Specify the 'BaseURL' property that component can find the full path to images, like a: <img src="..\pict.png" and
        ' to external css, like a:  <link rel="stylesheet" href="/css/style.css">.
        'h.BaseURL = "http://www.sautinsoft.net/samples/utf-8.html"

        If h.OpenHtml(inputFile) Then

            Dim ok As Boolean = h.ToRtf(outputFile)

            Rtf_Cuerpo.LoadFile(AppPath() & "\ResultHtml2Rtf.rtf")

            ' Open the result for demonstration purposes.
            'If ok Then
            'System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outputFile) With {.UseShellExecute = True})
            'End If
        End If

    End Sub

    Private Sub Cmb_Fuente_DrawItem(sender As Object, e As DrawItemEventArgs) Handles Cmb_Fuente.DrawItem

        e.DrawBackground()

        Dim _Texto As String = Cmb_Fuente.Items(e.Index).ToString
        Dim _Fuente As New Font(_Texto, e.Font.Size)

        e.Graphics.DrawString(_Texto, _Fuente, New SolidBrush(e.ForeColor), e.Bounds.Left + 2, e.Bounds.Top + 2)
        e.DrawFocusRectangle()

    End Sub

    Private Sub Cmb_Fuente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Fuente.SelectedIndexChanged
        'CmbFont.Font = New Font(CmbFont.Text, CmbFont.Font.Size)
        Try
            Dim f As New Font(Cmb_Fuente.Text, Rtf_Cuerpo.SelectionFont.Size)
            Rtf_Cuerpo.SelectionFont = f
            Rtf_Cuerpo.Font = f
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Input_Size_ValueChanged(sender As Object, e As EventArgs) Handles Input_Size.ValueChanged
        Dim f As New Font(Rtf_Cuerpo.SelectionFont.FontFamily, Input_Size.Value)
        Rtf_Cuerpo.SelectionFont = f
    End Sub

    Private Sub Color_Fuente_SelectedColorChanged(sender As Object, e As EventArgs) Handles Color_Fuente.SelectedColorChanged

        Color_Fuente.CommandParameter = Color_Fuente.SelectedColor

        Dim _Color As Color = Color_Fuente.CommandParameter

        Rtf_Cuerpo.SelectionColor = _Color
        Pict_Color_Fuente.BackColor = _Color

    End Sub

    Private Sub Color_Resaltado_SelectedColorChanged(sender As Object, e As EventArgs) Handles Color_Resaltado.SelectedColorChanged

        Color_Resaltado.CommandParameter = Color_Resaltado.SelectedColor

        Dim _Color As Color = Color_Resaltado.CommandParameter

        Rtf_Cuerpo.SelectionBackColor = _Color
        Pict_Color_Resaltado.BackColor = _Color

    End Sub

    Private Sub Cmb_Fuente_TextChanged(sender As Object, e As EventArgs)
        Dim f As New Font(Cmb_Fuente.Text, Rtf_Cuerpo.SelectionFont.Size)
        Rtf_Cuerpo.SelectionFont = f
    End Sub

    Private Sub Mnu_Tex_CortarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Mnu_Tex_CortarToolStripMenuItem.Click
        Rtf_Cuerpo.Cut()
    End Sub

    Private Sub Mnu_Tex_CopiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Mnu_Tex_CopiarToolStripMenuItem.Click
        Rtf_Cuerpo.Copy()
    End Sub

    Private Sub Mnu_Tex_PegarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Mnu_Tex_PegarToolStripMenuItem.Click
        Rtf_Cuerpo.Paste()
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        'SCor.Color = Pict_Color_Fuente.BackColor
        'SCor.ShowDialog()
        Rtf_Cuerpo.SelectionColor = Pict_Color_Fuente.BackColor
        'Pict_Color_Fuente.BackColor = SCor.Color
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        'SCor.Color = Pict_Color_Resaltado.BackColor
        'SCor.ShowDialog()
        Rtf_Cuerpo.SelectionBackColor = Pict_Color_Resaltado.BackColor
        'Pict_Color_Resaltado.BackColor = SCor.Color
    End Sub

    Private Sub SuperTabItem4_Click(sender As Object, e As EventArgs) Handles SuperTabItem4.Click
        Sb_Convertir_Rtf2Html(False)
    End Sub

    Private Sub Btn_Negrita_Click(sender As Object, e As EventArgs) Handles Btn_Negrita.Click
        Dim _Bold = Rtf_Cuerpo.SelectionFont.Bold

        If _Bold Then
            Rtf_Cuerpo.SelectionFont = New Font(Rtf_Cuerpo.SelectionFont.FontFamily, Rtf_Cuerpo.SelectionFont.Size, FontStyle.Regular)
        Else
            Rtf_Cuerpo.SelectionFont = New Font(Rtf_Cuerpo.SelectionFont.FontFamily, Rtf_Cuerpo.SelectionFont.Size, FontStyle.Bold)
        End If
    End Sub

    Private Sub Btn_Cursiva_Click(sender As Object, e As EventArgs) Handles Btn_Cursiva.Click
        Dim _Cursiva = Rtf_Cuerpo.SelectionFont.Italic

        If _Cursiva Then
            Rtf_Cuerpo.SelectionFont = New Font(Rtf_Cuerpo.SelectionFont.FontFamily, Rtf_Cuerpo.SelectionFont.Size, FontStyle.Regular)
        Else
            Rtf_Cuerpo.SelectionFont = New Font(Rtf_Cuerpo.SelectionFont.FontFamily, Rtf_Cuerpo.SelectionFont.Size, FontStyle.Italic)
        End If
    End Sub

    Private Sub Btn_Subrayada_Click(sender As Object, e As EventArgs) Handles Btn_Subrayada.Click
        Dim _Subrayada = Rtf_Cuerpo.SelectionFont.Underline

        If _Subrayada Then
            Rtf_Cuerpo.SelectionFont = New Font(Rtf_Cuerpo.SelectionFont.FontFamily, Rtf_Cuerpo.SelectionFont.Size, FontStyle.Regular)
        Else
            Rtf_Cuerpo.SelectionFont = New Font(Rtf_Cuerpo.SelectionFont.FontFamily, Rtf_Cuerpo.SelectionFont.Size, FontStyle.Underline)
        End If
    End Sub

    Private Sub Btn_Carpeta_Imagenes_Click(sender As Object, e As EventArgs) Handles Btn_Carpeta_Imagenes.Click
        Process.Start("explorer.exe", _Dir_Correo_Imagenes)
    End Sub

    Function Fx_Enviar_Mail3IMail(_Host_SMT As String,
                                  _Usuario As String,
                                  _Contrasena As String,
                                  _Para As String,
                                  _CC As String,
                                  _Asunto As String,
                                  _Cuerpo As String,
                                  _StrAttach() As String,
                                  _Puerto As Integer,
                                  _EnableSsl As Boolean) As LsValiciones.Mensajes 'ISendMessageResult

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            If String.IsNullOrEmpty(_Asunto.Trim) Then
                Throw New System.Exception("El Asunto no puede estar vacio")
            End If

            Dim builder As New MailBuilder()
            builder.From.Add(New MailBox(_Usuario))

            _Para = _Para.Trim()

            If IsNothing(_CC) Then _CC = String.Empty
            _CC = _CC.Trim()

            _CC = Replace(_CC, ",", ";")

            'Declaro la variable para enviar el correo
            Dim _Correo As New MailMessage()
            _Correo.From = New System.Net.Mail.MailAddress(_Usuario)
            _Correo.Subject = _Asunto

            For Each _To As String In _Para.Split(New Char() {";"c})
                If Fx_Validar_Email(_To) Then
                    builder.[To].Add(New MailBox(_To))
                End If
            Next

            If Not String.IsNullOrEmpty(_CC) Then
                For Each _Cc_ As String In _CC.Split(New Char() {";"c})
                    If Fx_Validar_Email(_Cc_) Then
                        builder.Cc.Add(New MailBox(_Cc_))
                    End If
                Next
            End If


            'builder.[To].Add(New MailBox(_Para))
            'builder.Cc.Add(New MailBox(_CC))

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
                    If System.IO.File.Exists(_Dir_Imagenes & "IMG" & i & ".png") Then
                        Dim visual As MimeData = builder.AddVisual(_Dir_Imagenes & "IMG" & i & ".png")
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

            If xi > 0 Then
                For Each strFile In _StrAttach
                    If Not IsNothing(strFile) Then
                        '_Correo.Attachments.Add(New System.Net.Mail.Attachment(Trim(strFile)))
                        _Archivos_Adjuntos = New Net.Mail.Attachment(strFile.Trim)
                        If IsNothing(_Archivos_Adjuntos) Then
                            xi = 0
                        Else
                            Dim attachment As MimeData = builder.AddAttachment(strFile.Trim)
                            Dim nombreArchivo As String = Path.GetFileName(strFile.Trim)
                            attachment.SetFileName(nombreArchivo, guessContentType:=True)
                            _AttAdj.Add(_Archivos_Adjuntos)
                        End If
                    End If
                Next
            End If

            Dim email As IMail = builder.Create()


            Using smtp As New Smtp

                smtp.Connect(_Host_SMT)
                smtp.SSLConfiguration.EnabledSslProtocols = _EnableSsl ' True
                smtp.UseBestLogin(_Usuario, _Contrasena)

                Dim result As ISendMessageResult = smtp.SendMessage((email))

                smtp.Close()

                If xi > 0 Then

                    For Each _Arch As Net.Mail.Attachment In _AttAdj
                        _Arch.Dispose()
                    Next

                    '_Archivos_Adjuntos.Dispose()
                    email.Attachments.DefaultIfEmpty ' .Attachments.Clear()

                End If

                Dim _Resultado As String = $"Status: {result.Status}, Detalle: {result.ToString}"

                If result.Status = SendMessageStatus.Success Then
                    _Mensaje.EsCorrecto = True
                    _Mensaje.Icono = MessageBoxIcon.Information
                ElseIf result.Status = SendMessageStatus.PartialSuccess Then
                    _Mensaje.EsCorrecto = True
                    _Mensaje.Icono = MessageBoxIcon.Warning
                ElseIf result.Status = SendMessageStatus.Failure Then
                    _Mensaje.EsCorrecto = False
                    _Mensaje.Icono = MessageBoxIcon.Stop
                    _Error = _Resultado
                End If

                _Mensaje.Mensaje = _Resultado

            End Using

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
            _Mensaje.EsCorrecto = False
            _Mensaje.Icono = MessageBoxIcon.Stop
        End Try

        Return _Mensaje

    End Function

End Class
