Imports System.IO
Imports System.Net.Sockets
Imports System.Text
Imports DevComponents.DotNetBar
Imports Limilabs.Client
Imports Limilabs.Client.IMAP
Imports Limilabs.Client.POP3
Imports Limilabs.Mail
Imports Limilabs.Mail.Headers
Imports Limilabs.Mail.MIME

Public Class Frm_Recibir_Correos_DTE

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim Server As TcpClient
    Dim NetStrm As NetworkStream
    Dim RdStrm As StreamReader
    Dim _Directorio As String = AppPath() & "\Data\" & RutEmpresa & "\DTE"
    Dim _Ds_Receptor_DTE As New Ds_Receptor_DTE
    Dim _Cancelar As Boolean

    Dim _Row_Cuenta As DataRow

    Public Property ActivacionAutomatica As Boolean
    Public Property ErrorEjecucion As String

    Public Property Row_Cuenta As DataRow
        Get
            Return _Row_Cuenta
        End Get
        Set(value As DataRow)
            _Row_Cuenta = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Not Directory.Exists(_Directorio) Then
            Directory.CreateDirectory(_Directorio)
        End If

        _Directorio = _Directorio & "\Recepcion"

        If Not Directory.Exists(_Directorio) Then
            System.IO.Directory.CreateDirectory(_Directorio)
        End If

        Dim _RecepXMLComp_CorreoPOP3 As String = _Global_Row_Configuracion_General.Item("RecepXMLComp_CorreoPOP3")
        Dim _RecepXMLCmp_ElimiCorreosPOP3 As Boolean = _Global_Row_Configuracion_General.Item("RecepXMLCmp_ElimiCorreosPOP3")

        '_RecepXMLComp_CorreoPOP3 = "notificacionsii@sirrep.cl"

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Correos_Cuentas Where Nombre_Usuario = '" & _RecepXMLComp_CorreoPOP3 & "'"
        _Row_Cuenta = _Sql.Fx_Get_DataRow(Consulta_sql)

        Chk_Borrar_Todos_Los_Correos.Checked = _RecepXMLCmp_ElimiCorreosPOP3

        Txt_Directorio.ReadOnly = True
        'Txt_Clave.PasswordChar = "*"
        Btn_Cancelar.Visible = False

        Sb_Color_Botones_Barra(Bar1)

        Sb_Imap()

    End Sub

    Private Sub Frm_Recibir_Correos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        If ActivacionAutomatica Then

            If IsNothing(_Row_Cuenta) Then
                Me.Close()
                Return
            End If

            Timer_Segundos.Start()
            Btn_Descargar_Archivos.Enabled = False

        End If

        Btn_BuscarSMTPRecepXMLComp.Visible = Not ActivacionAutomatica

        If Not IsNothing(_Row_Cuenta) Then
            Txt_Usuario.Text = _Row_Cuenta.Item("Nombre_Usuario")
        End If

        Txt_Directorio.Text = _Directorio

        Txt_CarpetaDestino.ReadOnly = False
        Txt_CarpetaLectura.ReadOnly = False

        Dtp_Fecha_Desde.Value = Primerdiadelmes(FechaDelServidor)
        Dtp_Fecha_Hasta.Value = FechaDelServidor()

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

    Function Fx_Validar_Archivo_XML_DTE(_Archivo As String) As Boolean

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


    Function Fx_New_Validar_DTE(_Archivo_Xml As String)


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

    'Sub Sb_Parametros_Actualizar()

    '    _Ds_Receptor_DTE.Clear()

    '    Dim NewFila As DataRow
    '    NewFila = _Ds_Receptor_DTE.Tables("Tbl_Configuracion").NewRow
    '    With NewFila

    '        .Item("Host") = Txt_Host.Text
    '        .Item("Usuario") = Txt_Usuario.Text
    '        .Item("Clave") = Txt_Clave.Text
    '        .Item("Directorio") = Txt_Directorio.Text
    '        .Item("Borrar_Todos_Los_Correos") = Chk_Borrar_Todos_Los_Correos.Checked

    '        _Ds_Receptor_DTE.Tables("Tbl_Configuracion").Rows.Add(NewFila)

    '    End With
    '    ' Dim exists = File.Exists(_Directorio_Informe & "\Parametros_Inf.xml")
    '    _Ds_Receptor_DTE.WriteXml(_Directorio & "\Conf_Recepcion_DTE.xml")

    'End Sub

    Private Sub Btn_Buscar_Directorio_Destino_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Buscar_Directorio_Destino.Click

        Dim _Fb_Directorio As New FolderBrowserDialog

        If _Fb_Directorio.ShowDialog() = DialogResult.OK Then
            Txt_Directorio.Text = _Fb_Directorio.SelectedPath
        End If

    End Sub

    Private Sub Btn_Descargar_Archivos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Descargar_Archivos.Click
        If Rdb_POP3.Checked Then Sb_Descargar_Archivos_POP3(True)
        If Rdb_IMAP.Checked Then Sb_Descargar_Archivos_IMAP(True)
    End Sub

    Sub Sb_Descargar_Archivos_POP3(_Mostrar_Mensaje As Boolean)

        ErrorEjecucion = String.Empty

        If IsNothing(_Row_Cuenta) Then
            MessageBoxEx.Show(Me, "Falta la cuenta del correo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Host As String = _Row_Cuenta.Item("Host") 'Txt_Host.Text
        Dim _User As String = _Row_Cuenta.Item("Nombre_Usuario") 'Txt_Usuario.Text
        Dim _Pass As String = _Row_Cuenta.Item("Contrasena") 'Txt_Clave.Text

        Lbl_Total_Correos.Text = 0
        Lbl_Xml_InsertBD.Text = 0
        Lbl_Xml_Descargados.Text = 0

        Try

            Me.Cursor = Cursors.WaitCursor
            _Cancelar = False
            Grupo.Enabled = False
            Btn_Descargar_Archivos.Enabled = False
            Me.ControlBox = False
            Btn_Cancelar.Visible = _Mostrar_Mensaje
            Me.Refresh()
            Dim _Pop3 As New Pop3
            Lbl_Xml_InsertBD.Tag = 0

            'Using _Pop3 As New Pop3
            _Pop3.Connect(_Host)                          'Utilice sobrecargas o ConnectSSL si necesita especificar otro puerto o SSL.
            '_Pop3.Login(_User, _Pass)                    ' You can also use: LoginAPOP, LoginPLAIN, LoginCRAM, LoginDIGEST methods,

            _Pop3.UseBestLogin(_User, _Pass)              ' You can also use: LoginAPOP, LoginPLAIN, LoginCRAM, LoginDIGEST methods,
            ' or use UseBestLogin method if you want Mail.dll to choose for you.
            Dim _Contador = 0
            Dim _Archivos_Descargados = 0

            Dim _MaxCorreos As Integer

            If _Pop3.Connected Then

                Dim uids As List(Of String) = _Pop3.GetAll ' Get unique-ids of all messages.

                Progreso_Porc.Maximum = 100

                If uids.Count > 2000 Then
                    _MaxCorreos = 2000
                Else
                    _MaxCorreos = uids.Count - 1
                End If

                'Progreso_Cont.Maximum = uids.Count - 1
                'Lbl_Total_Correos.Text = FormatNumber(Progreso_Cont.Value, 0)

                Progreso_Cont.Maximum = _MaxCorreos - 1
                Lbl_Total_Correos.Text = FormatNumber(_MaxCorreos, 0)

                For Each uid As String In uids
                    System.Windows.Forms.Application.DoEvents()
                    Dim email As IMail

                    Try
                        email = New MailBuilder().CreateFromEml(_Pop3.GetMessageByUID(uid)) ' Download and parse each message.
                    Catch ex As Exception
                        email = Nothing
                    End Try

                    If Not IsNothing(email) Then

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

                        Dim _FechaActual As DateTime = FechaDelServidor()



                        For Each attachment As MimeData In email.Attachments

                            With attachment

                                Dim _Filename As String

                                If Not IsNothing(.FileName) Then

                                    _Filename = .FileName

                                    If (InStr(_Filename.ToLower, ".xml")) Then

                                        Dim _Nombre_Archivo As String = numero_(_Contador + 1, 5) & "_" & .FileName

                                        _Nombre_Archivo = Replace(_Nombre_Archivo, "/", "_")
                                        .Save(Txt_Directorio.Text & "\" & _Nombre_Archivo)

                                        If Fx_Validar_Archivo_XML_DTE(Txt_Directorio.Text & "\" & _Nombre_Archivo) Then

                                            _Archivos_Descargados += 1
                                            Lbl_Xml_Descargados.Text = FormatNumber(_Archivos_Descargados, 0)

                                            Dim _DocInsertador As Integer

                                            If Fx_Grabar_En_DTE_ReccEnc_DTE_ReccDet(_Nombre_Archivo, _DocInsertador) Then

                                                Lbl_Xml_InsertBD.Tag += _DocInsertador
                                                Lbl_Xml_InsertBD.Text = FormatNumber(Lbl_Xml_InsertBD.Tag, 0)
                                                File.Delete(Txt_Directorio.Text & "\" & _Nombre_Archivo)

                                            End If

                                        Else
                                            File.Delete(Txt_Directorio.Text & "\" & _Nombre_Archivo)
                                        End If

                                    End If

                                End If

                            End With

                        Next

                        'ELIMINA EL CORREO EN EL SERVIDOR DE CORREOS
                        If Chk_Borrar_Todos_Los_Correos.Checked Then
                            _Pop3.DeleteMessageByUID(uid)
                        End If

                    End If

                    _Contador += 1
                    Progreso_Porc.Value = ((_Contador * 100) / _MaxCorreos - 1) 'Mas
                    Progreso_Cont.Value += 1

                    If _Cancelar Then
                        If MessageBoxEx.Show(Me, "¿Desea cancelar la acción?", "Cancelar",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            Exit For
                        End If
                    End If

                    If _Contador = 2000 Then
                        Exit For
                    End If

                Next

            End If

            _Pop3.Close()

            If _Mostrar_Mensaje Then
                MessageBoxEx.Show(Me, "Total archivos descargados: " & Lbl_Xml_Descargados.Text,
                              "Descarga completa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            ErrorEjecucion = ex.Message
            If _Mostrar_Mensaje Then
                MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Finally

            Grupo.Enabled = True
            Btn_Descargar_Archivos.Enabled = True
            Me.ControlBox = True
            Btn_Cancelar.Visible = False
            Progreso_Porc.Value = 0
            Progreso_Cont.Value = 0

            'Lbl_Total_Correos.Text = 0
            'Lbl_Xml_InsertBD.Text = 0
            'Lbl_Xml_Descargados.Text = 0

            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Sub Sb_Descargar_Archivos_IMAP(_Mostrar_Mensaje As Boolean)

        ErrorEjecucion = String.Empty

        If IsNothing(_Row_Cuenta) Then
            MessageBoxEx.Show(Me, "Falta la cuenta del correo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Host As String = _Row_Cuenta.Item("Host") 'Txt_Host.Text
        Dim _User As String = _Row_Cuenta.Item("Nombre_Usuario") 'Txt_Usuario.Text
        Dim _Pass As String = _Row_Cuenta.Item("Contrasena") 'Txt_Clave.Text

        Lbl_Total_Correos.Text = 0
        Lbl_Xml_InsertBD.Text = 0
        Lbl_Xml_Descargados.Text = 0

        Try

            Me.Cursor = Cursors.WaitCursor
            _Cancelar = False
            Grupo.Enabled = False
            Btn_Descargar_Archivos.Enabled = False
            Me.ControlBox = False
            Btn_Cancelar.Visible = _Mostrar_Mensaje
            Me.Refresh()

            Dim _Imap As New Imap

            '_Imap.SSLConfiguration.EnabledSslProtocols = SslProtocols.Tls12

            _Imap.ConnectSSL(_Host)  ' or Connect for non SSL/TLS<font></font>
            _Imap.UseBestLogin(_User, _Pass)

            _Imap.SelectInbox()

            Lbl_Xml_InsertBD.Tag = 0

            Dim _Contador = 0
            Dim _Archivos_Descargados = 0

            Dim _MaxCorreos As Integer

            Dim _Leidos = 0

            If _Imap.Connected Then

                If Not String.IsNullOrEmpty(Txt_CarpetaLectura.Text) Then
                    _Imap.Select(Txt_CarpetaLectura.Text) '("INBOX.DTE_PROCESADOS")
                End If

                Dim uids As List(Of Long)

                Dim _FechaDesde As Date = Dtp_Fecha_Desde.Value
                Dim _FechaHasta As Date = DateAdd(DateInterval.Day, 1, Dtp_Fecha_Hasta.Value)

                _FechaHasta = New DateTime(_FechaHasta.Year, _FechaHasta.Month, _FechaHasta.Day, 23, 59, 0)
                _FechaDesde = New DateTime(_FechaDesde.Year, _FechaDesde.Month, _FechaDesde.Day, 0, 0, 0)

                If Rdb_DecargarNoLeidos.Checked Then
                    uids = _Imap.Search(Flag.Unseen)
                End If

                If Rdb_DescargarRangoFechas.Checked Then
                    ' Esto de aca busca por fecha al parecer...
                    uids = _Imap.Search((Expression.[And](Expression.Before(_FechaHasta), Expression.Since(_FechaDesde))))
                End If


                Progreso_Porc.Maximum = 100

                Lbl_Total_Correos.Text = FormatNumber(_MaxCorreos, 0)
                _MaxCorreos = uids.Count - 1

                Progreso_Cont.Maximum = _MaxCorreos - 1

                For Each uid As String In uids

                    System.Windows.Forms.Application.DoEvents()
                    Dim email As IMail

                    Try
                        email = New MailBuilder().CreateFromEml(_Imap.GetMessageByUID(uid))
                    Catch ex As Exception
                        email = Nothing
                    End Try

                    _Leidos += 1

                    If Not IsNothing(email) Then

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

                        Dim _FechaActual As DateTime = FechaDelServidor()

                        If email.Date > #01-01-2023# Then

                            For Each attachment As MimeData In email.Attachments

                                With attachment

                                    Dim _Filename As String

                                    If Not IsNothing(.FileName) Then

                                        _Filename = .FileName

                                        If (InStr(_Filename.ToLower, ".xml")) Then

                                            Dim _Nombre_Archivo As String = numero_(_Contador + 1, 5) & "_" & .FileName

                                            _Nombre_Archivo = Replace(_Nombre_Archivo, "/", "_")
                                            .Save(Txt_Directorio.Text & "\" & _Nombre_Archivo)

                                            If Fx_Validar_Archivo_XML_DTE(Txt_Directorio.Text & "\" & _Nombre_Archivo) Then

                                                _Archivos_Descargados += 1
                                                Lbl_Xml_Descargados.Text = FormatNumber(_Archivos_Descargados, 0)

                                                Dim _DocInsertador As Integer

                                                If Fx_Grabar_En_DTE_ReccEnc_DTE_ReccDet(_Nombre_Archivo, _DocInsertador) Then

                                                    Lbl_Xml_InsertBD.Tag += _DocInsertador
                                                    Lbl_Xml_InsertBD.Text = FormatNumber(Lbl_Xml_InsertBD.Tag, 0)
                                                    File.Delete(Txt_Directorio.Text & "\" & _Nombre_Archivo)

                                                End If

                                                If Not String.IsNullOrEmpty(Txt_CarpetaDestino.Text) Then
                                                    _Imap.MoveByUID(uid, Txt_CarpetaDestino.Text)
                                                End If

                                            Else
                                                'File.Delete(Txt_Directorio.Text & "\" & _Nombre_Archivo)
                                            End If

                                        End If

                                    End If

                                End With

                            Next

                        End If

                        'ELIMINA EL CORREO EN EL SERVIDOR DE CORREOS
                        If Chk_Borrar_Todos_Los_Correos.Checked Then
                            _Imap.DeleteMessageByUID(uid)
                        End If

                    End If

                    _Contador += 1
                    Progreso_Porc.Value = ((_Contador * 100) / _MaxCorreos - 1) 'Mas
                    Progreso_Cont.Value += 1

                    If _Cancelar Then
                        If MessageBoxEx.Show(Me, "¿Desea cancelar la acción?", "Cancelar",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            Exit For
                        End If
                    End If

                    'If _Contador >= 2000 Then
                    '    Exit For
                    'End If

                Next

            End If

            _Imap.Close()

            If _Mostrar_Mensaje Then
                MessageBoxEx.Show(Me, "Total archivos descargados: " & Lbl_Xml_Descargados.Text & vbCrLf &
                                  "Mensajes leídos; " & _Leidos,
                              "Descarga completa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            ErrorEjecucion = ex.Message
            If _Mostrar_Mensaje Then
                MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Finally

            Grupo.Enabled = True
            Btn_Descargar_Archivos.Enabled = True
            Me.ControlBox = True
            Btn_Cancelar.Visible = False
            Progreso_Porc.Value = 0
            Progreso_Cont.Value = 0

            'Lbl_Total_Correos.Text = 0
            'Lbl_Xml_InsertBD.Text = 0
            'Lbl_Xml_Descargados.Text = 0

            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Function Fx_Grabar_En_FMAESRE_FMAESRD(_Nombre_Archivo As String)

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

    Function Fx_Grabar_En_DTE_ReccEnc_DTE_ReccDet(_Nombre_Archivo As String, ByRef _DocInsertador As Integer) As Boolean

        If CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_DTE_ReccEnc", "NombreArchivo = '" & _Nombre_Archivo & "'")) Then
            Return True
        End If

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

            If m_nodelist.Count = 0 Then
                m_nodelist = m_xmld.SelectNodes("DTE")
            End If

            ' m_nodelist = m_xmld.SelectNodes("sii:EnvioDTE/sii:SetDTE", ns)
            Dim xDTEs As XmlNodeList = m_xmld.GetElementsByTagName("DTE", m_xmld.DocumentElement.NamespaceURI)

            'Dim XmlRut = m_xmld.SelectSingleNode("sii:DTE//sii:Encabezado/sii:Emisor/sii:RUTEmisor", ns).InnerText
            Dim _Id = 1
            'Iniciamos el ciclo de lectura

            Dim _Detalle_DTE As String = String.Empty
            Dim _Cnt = 0

            'Dim oSW As New System.IO.StreamWriter(_DirNomArchivo)
            'oSW.WriteLine(_Dte)
            'oSW.Close()

            Dim Ds_Xml As New DataSet
            Ds_Xml.ReadXml(Txt_Directorio.Text & "\" & _Nombre_Archivo)

            Dim _TblEmisor As DataTable = Ds_Xml.Tables("Emisor")
            Dim _TblIdDoc As DataTable = Ds_Xml.Tables("IdDoc")
            Dim _TblCaratula As DataTable = Ds_Xml.Tables("Caratula")

            For Each m_node In m_nodelist

                Dim _Dte = m_node.InnerXml
                Dim _RUTEmisor1 As String = _TblEmisor.Rows(_Cnt).Item("RUTEmisor")

                If Not _Dte.Contains("<DTE") Then
                    _Dte = "<DTE>" & _Dte & "</DTE>"
                End If

                Dim _TipoDTE As Integer = _TblIdDoc.Rows(_Cnt).Item("TipoDTE")
                Dim _Folio As Integer = _TblIdDoc.Rows(_Cnt).Item("Folio")
                Dim _FchEmis As DateTime = _TblIdDoc.Rows(_Cnt).Item("FchEmis")

                _Detalle_DTE += "Insert Into " & _Global_BaseBk & "Zw_DTE_ReccDet (Id_Enc,Aceptado,Glosa,RutEmisor,TipoDTE,Folio,FchEmis,Xml) Values " &
                                "(@Idsre,0,'DTE Recibido OK','" & _RUTEmisor1 & "'," & _TipoDTE &
                                "," & _Folio & ",'" & Format(_FchEmis, "yyyyMMdd") & "','" & _Dte & "')" & vbCrLf

                _DocInsertador += 1

                Dim _Reg As Boolean = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_DTE_ReccDet",
                                                               "RutEmisor = '" & _RUTEmisor1 & "' And " &
                                                               "TipoDTE = " & _TipoDTE & " And " &
                                                               "Folio = " & _Folio)

                If _Reg Then
                    Return True
                End If

                _Cnt += 1

            Next

            Dim _Xml = m_xmld.InnerXml

            'Dim _HoraGrab = Hora_Grab_fx(False)

            Dim _RutEmisor As String = _TblCaratula.Rows(0).Item("RutEmisor")

            Consulta_sql = "Declare @Idsre Int" & vbCrLf & vbCrLf &
                           "Insert Into " & _Global_BaseBk & "Zw_DTE_ReccEnc (RutEmisor,Glosa,NombreArchivo,FechaRecep,Xml) Values " & vbCrLf &
                           "('" & _RutEmisor & "','Envio Recibido Conforme','" & _Nombre_Archivo & "',Getdate(),'" & _Xml & "')" &
                           vbCrLf &
                           vbCrLf &
                           "Set @Idsre = @@IDENTITY" &
                           vbCrLf &
                           _Detalle_DTE

            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Return False
            End If

        Catch ex As Exception
            _DocInsertador = 0
            'Error trapping
        End Try
        Return True

    End Function

    Sub ProcessMessage(email As IMail)

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

    Private Function JoinMailboxes(mailboxes As IList(Of MailBox)) As String
        Return String.Join(",", New List(Of MailBox)(mailboxes).ConvertAll(Function(x As MailBox) String.Format("{0} <{1}>", x.Name, x.Address)).ToArray())
    End Function

    Private Function JoinAddresses(addresses As IList(Of MailAddress)) As String
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

    Private Sub Btn_Cancelar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cancelar.Click
        _Cancelar = True
    End Sub

    'Private Sub Frm_Recibir_Correos_DTE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    '    Sb_Parametros_Actualizar()
    'End Sub

    Private Sub Timer_Segundos_Tick(sender As Object, e As EventArgs) Handles Timer_Segundos.Tick
        Timer_Segundos.Stop()

        If Rdb_POP3.Checked Then Sb_Descargar_Archivos_POP3(True)
        If Rdb_IMAP.Checked Then Sb_Descargar_Archivos_IMAP(True)

        Me.Close()
    End Sub

    Private Sub Btn_BuscarSMTPRecepXMLComp_Click(sender As Object, e As EventArgs) Handles Btn_BuscarSMTPRecepXMLComp.Click

        Dim Fm As New Frm_Correos_Conf_SMTP_Lista(Frm_Correos_Conf_SMTP_Lista.Enum_Accion.Seleccionar)
        Fm.ShowDialog(Me)
        _Row_Cuenta = Fm.Pro_Row_Cuenta
        Fm.Dispose()

        If Not IsNothing(_Row_Cuenta) Then
            Txt_Usuario.Text = _Row_Cuenta.Item("Nombre_Usuario")
        End If

    End Sub

    Private Sub Rdb_IMAP_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_IMAP.CheckedChanged
        Sb_Imap()
    End Sub

    Sub Sb_Imap()

        If Rdb_IMAP.Checked Then
            Me.Height = 458
            Chk_Borrar_Todos_Los_Correos.Checked = False
            Chk_Borrar_Todos_Los_Correos.Enabled = False
        Else
            Me.Height = 310
            Chk_Borrar_Todos_Los_Correos.Enabled = True
        End If

    End Sub

End Class
