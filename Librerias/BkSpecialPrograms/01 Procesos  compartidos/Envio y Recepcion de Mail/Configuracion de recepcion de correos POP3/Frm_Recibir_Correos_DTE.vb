Imports DevComponents.DotNetBar

'Imports Rebex.Net
'Imports Rebex.Mail
'Imports Rebex.Mime.Headers
Imports System.IO

Imports System
Imports System.Net.Sockets
Imports System.Text

Imports Limilabs.Client.POP3
Imports Limilabs.Mail
Imports Limilabs.Mail.MIME
Imports Limilabs.Mail.Headers
'Imports Lib_Bakapp_VarClassFunc
'Imports cl.sii.maullin
'Imports cl.sii.palena
'Imports cl.sii.palena1

Public Class Frm_Recibir_Correos_DTE

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim Server As TcpClient
    Dim NetStrm As NetworkStream
    Dim RdStrm As StreamReader
    Dim _Directorio As String = AppPath() & "\Data\" & RutEmpresa & "\DTE"
    Dim _Ds_Receptor_DTE As New Ds_Receptor_DTE
    Dim _Cancelar As Boolean

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Not Directory.Exists(_Directorio) Then
            Directory.CreateDirectory(_Directorio)
            Directory.CreateDirectory(_Directorio & "\Recepcion")
        End If

        _Directorio = _Directorio & "\Recepcion"

        Dim _Exists = File.Exists(_Directorio & "\Conf_Recepcion_DTE.xml")

        If Not _Exists Then

            _Ds_Receptor_DTE.WriteXml(_Directorio & "\Conf_Recepcion_DTE.xml")

            Sb_Parametros_Actualizar()

        Else

            _Ds_Receptor_DTE.Clear()
            _Ds_Receptor_DTE.ReadXml(_Directorio & "\Conf_Recepcion_DTE.xml")

            Dim TblParametros As DataTable

            TblParametros = _Ds_Receptor_DTE.Tables("Tbl_Configuracion")
            Dim Fila As DataRow
            Fila = TblParametros.Rows(0)
            With Fila

                Txt_Host.Text = .Item("Host")
                Txt_Usuario.Text = .Item("Usuario")
                Txt_Clave.Text = .Item("Clave")
                Txt_Directorio.Text = .Item("Directorio")
                Chk_Borrar_Todos_Los_Correos.Checked = NuloPorNro(.Item("Borrar_Todos_Los_Correos"), False)

            End With

        End If

        Txt_Directorio.ReadOnly = True
        Txt_Clave.PasswordChar = "*"
        Btn_Cancelar.Visible = False

    End Sub

    Private Sub Frm_Recibir_Correos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'CheckForIllegalCrossThreadCalls = False

        'Dim jws As New cl.sii.maullin.QueryEstDteAvService 'referenciaws.proceso_wcService
        'Dim jws_2 As New cl.sii.palena1.QueryEstDteAvService 'referenciaws.proceso_wcService

        'Dim _Prueba_2 = jws.getEstDteAv("", "", "", "", "", "", "", "", "", "")
        ' Dim _Prueba = jws.reenvioCorreo("", "", "", "")

    End Sub

    Sub Sb_Descargar_Archivos()

        Try


            Me.Enabled = False

            'create client, connect and log in
            'Rebex ---Dim client As New Pop3

            'Rebex Dim Att As New Attachment

            'Rebex client.Connect(Txt_Host.Text)
            'Rebex client.Login(Txt_Usuario.Text, Txt_Clave.Text)

            'get message list
            'Rebex Dim list As Pop3MessageCollection = client.GetMessageList()
            Dim list

            If list.Count = 0 Then
                MessageBoxEx.Show(Me, "No existen mensaje en la bandeja de entrada", "Informacíón",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                'download the first message
                Dim _Fecha_Hoy As Date = FormatDateTime(FechaDelServidor, DateFormat.ShortDate)

                Progreso_Porc.Maximum = 100
                Progreso_Cont.Maximum = list.Count - 1

                Dim _Contador = 0

                For _i = 0 To list.Count - 1

                    System.Windows.Forms.Application.DoEvents()

                    Dim _Mensaje 'As MailMessage = client.GetMailMessage(list(_i).SequenceNumber)
                    Dim _Fecha As Date = FormatDateTime(_Mensaje.Date.OriginalTime, DateFormat.ShortDate)
                    Dim _De = _Mensaje.From.ToString

                    Dim _Borrar = False
                    Dim _No_Borrar = False

                    If CBool(_Mensaje.Attachments.Count) Then

                        Dim _Autorizado As Integer = 1

                        If CBool(_Autorizado) Then
                            For Each objAtt In _Mensaje.Attachments
                                If (InStr(objAtt.DisplayName, ".xml")) Then

                                    Dim _Nombre_Archivo As String = numero_(_i + 1, 5) & "_" & objAtt.DisplayName

                                    objAtt.Save(Txt_Directorio.Text & "\" & _Nombre_Archivo)

                                    If Fx_Validar_Archivo_XML_DTE(Txt_Directorio.Text & "\" & _Nombre_Archivo) Then
                                        _No_Borrar = True
                                    Else
                                        File.Delete(Txt_Directorio.Text & "\" & _Nombre_Archivo)
                                        _Borrar = True
                                    End If
                                Else
                                    If _Mensaje.Attachments.Count = 1 Then
                                        _Borrar = True
                                    End If
                                End If
                            Next
                            'client.Delete(_i + 1)
                        End If

                        If Not _No_Borrar Then
                            _Borrar = True
                        End If

                    Else
                        _Borrar = True
                    End If

                    If Chk_Borrar_Todos_Los_Correos.Checked Then
                        _Borrar = True
                    End If

                    If _Borrar Then
                        ' client.Delete(_i + 1)
                    End If

                    System.Windows.Forms.Application.DoEvents()
                    _Contador += 1
                    Progreso_Porc.Value = ((_Contador * 100) / list.Count - 1) 'Mas
                    Progreso_Cont.Value += 1

                Next

                MessageBoxEx.Show(Me, "Listo", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            '  client.Disconnect()

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Progreso_Cont.Value = 0
            Progreso_Porc.Value = 0
            Me.Enabled = True
        End Try


    End Sub

    Function Fx_Validar_Archivo_XML_DTE(ByVal _Archivo As String) As Boolean

        Try

            Dim Ds_Xml As New DataSet
            Ds_Xml.ReadXml(_Archivo)

            Dim Tbl_Encabezado = Ds_Xml.Tables("Encabezado")

            For Each _DTE_Fila As DataRow In Tbl_Encabezado.Rows

                Dim _Documento_Id As Integer = _DTE_Fila.Item("Documento_Id")
                Dim _Encabezado_Id As Integer = _DTE_Fila.Item("Encabezado_Id")

                Dim _Tbl_IdDoc = Ds_Xml.Tables("IdDoc")
                Dim _Id_Doc As Integer = _Tbl_IdDoc.Rows(_Encabezado_Id).Item("TipoDTE")
                Dim _Nro_Documento As String = _Tbl_IdDoc.Rows(_Encabezado_Id).Item("Folio")

                Dim _Tbl_Emisor = Ds_Xml.Tables("Emisor")

                With _Tbl_Emisor

                    Dim _Razon_Emisor As String = Trim(.Rows(_Encabezado_Id).Item("RznSoc")) '"Razon Social Emisor de documento"
                    Dim _Rt() As String = Split(Trim(.Rows(_Encabezado_Id).Item("RUTEmisor")), "-")

                End With

                Dim _Tbl_Receptor = Ds_Xml.Tables("Receptor")

                With _Tbl_Receptor

                    Dim _Razon_Receptor As String = Trim(.Rows(_Encabezado_Id).Item("RznSocRecep")) '"Razon Social Emisor de documento"
                    'Dim _Rt() As String = Split(Trim(.Rows(_Encabezado_Id).Item("RUTEmisor")), "-")
                    Dim _Rut_Receptor As String = Trim(.Rows(_Encabezado_Id).Item("RUTRecep"))

                    If _Rut_Receptor = RutEmpresa Then
                        Return True
                    End If

                End With

            Next

            'Return True

        Catch ex As Exception
            Return False
        End Try

    End Function


    Function Fx_New_Validar_DTE(ByVal _Archivo_Xml As String)


        Try
            Dim m_xmld As XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode

            'Creamos el "Document"
            m_xmld = New XmlDocument()

            'Cargamos el archivo
            m_xmld.Load(_Archivo_Xml)

            'Obtenemos la lista de los nodos "name"
            m_nodelist = m_xmld.SelectNodes("/usuarios/name")

            'Iniciamos el ciclo de lectura
            For Each m_node In m_nodelist
                'Obtenemos el atributo del codigo
                Dim mCodigo = m_node.Attributes.GetNamedItem("codigo").Value

                'Obtenemos el Elemento nombre
                Dim mNombre = m_node.ChildNodes.Item(0).InnerText

                'Obtenemos el Elemento apellido
                Dim mApellido = m_node.ChildNodes.Item(1).InnerText

                'Escribimos el resultado en la consola, 
                'pero tambien podriamos utilizarlos en
                'donde deseemos
                Console.Write("Codigo usuario: " & mCodigo _
                  & " Nombre: " & mNombre _
                  & " Apellido: " & mApellido)
                Console.Write(vbCrLf)

            Next
        Catch ex As Exception
            'Error trapping
            Console.Write(ex.ToString())
        End Try

    End Function

    Sub Sb_Parametros_Actualizar()

        _Ds_Receptor_DTE.Clear()

        Dim NewFila As DataRow
        NewFila = _Ds_Receptor_DTE.Tables("Tbl_Configuracion").NewRow
        With NewFila

            .Item("Host") = Txt_Host.Text
            .Item("Usuario") = Txt_Usuario.Text
            .Item("Clave") = Txt_Clave.Text
            .Item("Directorio") = Txt_Directorio.Text
            .Item("Borrar_Todos_Los_Correos") = Chk_Borrar_Todos_Los_Correos.Checked

            _Ds_Receptor_DTE.Tables("Tbl_Configuracion").Rows.Add(NewFila)

        End With
        ' Dim exists = File.Exists(_Directorio_Informe & "\Parametros_Inf.xml")
        _Ds_Receptor_DTE.WriteXml(_Directorio & "\Conf_Recepcion_DTE.xml")

    End Sub

    Private Sub Btn_Buscar_Directorio_Destino_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Buscar_Directorio_Destino.Click

        Dim _Fb_Directorio As New FolderBrowserDialog

        If _Fb_Directorio.ShowDialog() = DialogResult.OK Then
            Txt_Directorio.Text = _Fb_Directorio.SelectedPath
        End If


    End Sub

    Private Sub Btn_Descargar_Archivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Descargar_Archivos.Click

        Dim _Host As String = Txt_Host.Text
        Dim _User As String = Txt_Usuario.Text
        Dim _Pass As String = Txt_Clave.Text

        'Me.Cursor = Cursors.WaitCursor

        Try

            _Cancelar = False
            Grupo.Enabled = False
            Btn_Descargar_Archivos.Enabled = False
            Me.ControlBox = False
            Btn_Cancelar.Visible = True
            Me.Refresh()
            Dim _Pop3 As New Pop3

            'Using _Pop3 As New Pop3
            _Pop3.Connect(_Host)                           ' Use overloads or ConnectSSL if you need to specify different port or SSL.
            _Pop3.Login(_User, _Pass)                    ' You can also use: LoginAPOP, LoginPLAIN, LoginCRAM, LoginDIGEST methods,
            ' or use UseBestLogin method if you want Mail.dll to choose for you.
            Dim _Contador = 0
            Dim _Archivos_Descargados = 0

            If _Pop3.Connected Then

                Dim uids As List(Of String) = _Pop3.GetAll           ' Get unique-ids of all messages.

                Progreso_Porc.Maximum = 100
                Progreso_Cont.Maximum = uids.Count - 1
                Lbl_Total_Correos.Text = FormatNumber(Progreso_Cont.Value, 0)

                For Each uid As String In uids
                    System.Windows.Forms.Application.DoEvents()
                    Dim email As IMail

                    Try
                        email = New MailBuilder() _
                                             .CreateFromEml(_Pop3.GetMessageByUID(uid))      ' Download and parse each message.
                        'System.Windows.Forms.Application.DoEvents()
                        'ProcessMessage(email)
                    Catch ex As Exception
                        email = Nothing
                    End Try

                    If Not email Is Nothing Then



                        Dim _STRSS As String = "Subject: " & email.Subject & vbCrLf &
                                               "From: " + JoinMailboxes(email.From) & vbCrLf &
                                               "To: " + JoinAddresses(email.To) & vbCrLf &
                                               "Cc: " + JoinAddresses(email.Cc) & vbCrLf &
                                               "Bcc: " + JoinAddresses(email.Bcc) & vbCrLf &
                                               "Text: " + email.Text & vbCrLf &
                                               "HTML: " + email.Html

                        Dim _Fecha_Email As Date

                        If email.Date.Equals(Nothing) Then
                            _Fecha_Email = FechaDelServidor()
                        Else
                            _Fecha_Email = FormatDateTime(email.Date)
                        End If


                        'If FormatDateTime(_Fecha_Email, DateFormat.ShortDate) = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate) Then
                        For Each attachment As MimeData In email.Attachments
                            ' Console.WriteLine(attachment.FileName)
                            Dim _Borrar As Boolean

                            With attachment
                                Dim _Filename = .FileName
                                If (InStr(_Filename, ".xml")) Then

                                    Dim _Nombre_Archivo As String = numero_(_Contador + 1, 5) & "_" & .FileName '.DisplayName

                                    _Nombre_Archivo = Replace(_Nombre_Archivo, "/", "_")
                                    .Save(Txt_Directorio.Text & "\" & _Nombre_Archivo)

                                    If Fx_Validar_Archivo_XML_DTE(Txt_Directorio.Text & "\" & _Nombre_Archivo) Then
                                        _Archivos_Descargados += 1
                                        Lbl_Xml_Descargados.Text = FormatNumber(_Archivos_Descargados, 0)
                                    Else

                                        'If Fx_Grabar_En_FMAESRE_FMAESRD(_Nombre_Archivo) Then
                                        'End If

                                        'Else

                                        '_No_Borrar = True
                                        'Else
                                        File.Delete(Txt_Directorio.Text & "\" & _Nombre_Archivo)
                                        '_Borrar = True
                                    End If
                                Else
                                    'If _Mensaje.Attachments.Count = 1 Then
                                    '_Borrar = True
                                    'End If
                                End If

                                'If 

                                'attachment.Save(_Directorio & "\" & attachment.SafeFileName)
                            End With
                        Next
                        'End If

                        'ELIMINA EL MENSAJE
                        If Chk_Borrar_Todos_Los_Correos.Checked Then
                            _Pop3.DeleteMessageByUID(uid)
                        End If

                    End If


                    _Contador += 1
                    Progreso_Porc.Value = ((_Contador * 100) / uids.Count - 1) 'Mas
                    Progreso_Cont.Value += 1

                    If _Cancelar Then
                        If MessageBoxEx.Show(Me, "¿Desea cancelar la acción?", "Cancelar",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            Exit For
                        End If
                    End If

                    ' Display email data, save attachments.
                Next

            End If

            _Pop3.Close()

            MessageBoxEx.Show(Me, "Total archivos descargados: " & Lbl_Xml_Descargados.Text,
                              "Descarga completa", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally

            Grupo.Enabled = True
            Btn_Descargar_Archivos.Enabled = True
            Me.ControlBox = True
            Btn_Cancelar.Visible = False
            Progreso_Porc.Value = 0
            Progreso_Cont.Value = 0

            Lbl_Total_Correos.Text = 0
            Lbl_Xml_Descargados.Text = 0

            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Function Fx_Grabar_En_FMAESRE_FMAESRD(ByVal _Nombre_Archivo As String)

        Try
            Dim m_xmld As XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode

            'Creamos el "Document"
            m_xmld = New XmlDocument()

            'Cargamos el archivo
            m_xmld.Load(Txt_Directorio.Text & "\" & _Nombre_Archivo)

            ' Cree el name space manager del documento
            Dim ns As New XmlNamespaceManager(m_xmld.NameTable)
            ns.AddNamespace("sii", m_xmld.DocumentElement.NamespaceURI)

            'Obtenemos la lista de los nodos "name"
            m_nodelist = m_xmld.SelectNodes("sii:EnvioDTE/sii:SetDTE/sii:DTE", ns)
            ' m_nodelist = m_xmld.SelectNodes("sii:EnvioDTE/sii:SetDTE", ns)
            Dim xDTEs As XmlNodeList = m_xmld.GetElementsByTagName("DTE", m_xmld.DocumentElement.NamespaceURI)

            'Dim XmlRut = m_xmld.SelectSingleNode("sii:DTE//sii:Encabezado/sii:Emisor/sii:RUTEmisor", ns).InnerText
            Dim _Id = 1
            'Iniciamos el ciclo de lectura

            Dim _Detalle_DTE As String

            For Each m_node In m_nodelist 'm_nodelist

                Dim _Dte = m_node.InnerXml

                _Detalle_DTE += "Insert Into FMAESRD (IDSRE,ESACEP,DESACEP,XML) Values " &
                                "(@Idsre,0,'DTE Recibido OK','" & _Dte & "')" & vbCrLf

            Next

            Dim _Xml = m_xmld.InnerXml

            Dim _HoraGrab = Hora_Grab_fx(False)

            Consulta_sql = "Declare @Idsre Int" & vbCrLf & vbCrLf &
                           "Insert Into FMAESRE (ESACEP,DESACEP,ARCHIVO,FECHARE,HORAGRAB,XML) Values " & vbCrLf &
                           "(0,'Envio Recibido Conforme','" & _Nombre_Archivo & "',Getdate()," & _HoraGrab & ",'" & _Xml & "')" &
                           vbCrLf &
                           vbCrLf &
                           "Set @Idsre = @@IDENTITY" &
                           vbCrLf &
                           _Detalle_DTE

            Return _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

            'SELECT @@IDENTITY
            'IDSRE, ESACEP, DESACEP, ARCHIVO, FECHARE, HORAGRAB, Xml
            'FROM(FMAESRE)

            'SELECT IDSRE,ESACEP,DESACEP,XML
            'FROM(FMAESRD)

        Catch ex As Exception
            'Error trapping
        End Try
    End Function

    Sub ProcessMessage(ByVal email As IMail)

        Console.WriteLine("Subject: " + email.Subject)
        Console.WriteLine("From: " + JoinMailboxes(email.From))
        Console.WriteLine("To: " + JoinAddresses(email.To))
        Console.WriteLine("Cc: " + JoinAddresses(email.Cc))
        Console.WriteLine("Bcc: " + JoinAddresses(email.Bcc))

        Console.WriteLine("Text: " + email.Text)
        Console.WriteLine("HTML: " + email.Html)

        Console.WriteLine("Attachments: ")

        Dim _STRSS As String = "Subject: " & email.Subject & vbCrLf &
        "From: " + JoinMailboxes(email.From) & vbCrLf &
        "To: " + JoinAddresses(email.To) & vbCrLf &
        "Cc: " + JoinAddresses(email.Cc) & vbCrLf &
        "Bcc: " + JoinAddresses(email.Bcc) & vbCrLf &
        "Text: " + email.Text & vbCrLf &
        "HTML: " + email.Html


        For Each attachment As MimeData In email.Attachments
            Console.WriteLine(attachment.FileName)
            attachment.Save(_Directorio & "\" & attachment.SafeFileName)
        Next
    End Sub

    Private Function JoinMailboxes(ByVal mailboxes As IList(Of MailBox)) As String
        Return String.Join(",", New List(Of MailBox)(mailboxes).ConvertAll(Function(x As MailBox) String.Format("{0} <{1}>", x.Name, x.Address)).ToArray())
    End Function

    Private Function JoinAddresses(ByVal addresses As IList(Of MailAddress)) As String
        Dim builder As New StringBuilder

        For Each address As MailAddress In addresses
            If (TypeOf address Is MailGroup) Then
                Dim group As MailGroup = CType(address, MailGroup)
                builder.AppendFormat("{0}: {1};, ", group.Name, JoinAddresses(group.Addresses))
            End If
            If (TypeOf address Is MailBox) Then
                Dim mailbox As MailBox = CType(address, MailBox)
                builder.AppendFormat("{0} <{1}>, ", mailbox.Name, mailbox.Address)
            End If
        Next
        Return builder.ToString()
    End Function

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        _Cancelar = True
    End Sub

    Private Sub Frm_Recibir_Correos_DTE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Sb_Parametros_Actualizar()
    End Sub
End Class
