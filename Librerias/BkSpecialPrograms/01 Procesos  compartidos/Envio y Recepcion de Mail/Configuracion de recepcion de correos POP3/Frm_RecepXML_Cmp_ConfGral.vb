Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Net.Sockets
Imports System.Text
Imports Limilabs.Client
Imports Limilabs.Client.IMAP
Imports Limilabs.Client.POP3
Imports Limilabs.Mail
Imports Limilabs.Mail.Headers
Imports Limilabs.Mail.MIME
Imports Microsoft.VisualBasic.ApplicationServices

Public Class Frm_RecepXML_Cmp_ConfGral

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Grabar As Boolean
    Dim _Row_CuentaSMTP As DataRow

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Recibir_Correos_DTE_ConfGral_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Txt_CuentaSMTP.Text = _Global_Row_Configuracion_General.Item("RecepXML_Cmp_CorreoSMTP")

        If String.IsNullOrEmpty(Txt_CuentaSMTP.Text) Then
            Txt_CuentaSMTP.Text = _Global_Row_Configuracion_General.Item("RecepXMLComp_CorreoPOP3")
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Correos_Cuentas Where Nombre_Usuario = '" & Txt_CuentaSMTP.Text & "'"
        _Row_CuentaSMTP = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_CuentaSMTP) Then
            Txt_CuentaSMTP.Text = String.Empty
        End If

        With _Global_Row_Configuracion_General

            Txt_CuentaSMTP.Text = .Item("RecepXML_Cmp_CorreoSMTP")
            Txt_CuentaSMTP.Text = .Item("RecepXMLComp_CorreoPOP3")
            Chk_RecepXMLCmp_ElimiCorreosPOP3.Checked = .Item("RecepXMLCmp_ElimiCorreosPOP3")

            Rdb_POP3.Checked = .Item("RecepXML_Cmp_POP3")
            Rdb_IMAP.Checked = .Item("RecepXML_Cmp_IMAP")

            Txt_IMAP_CarpetaLectura.Text = .Item("RecepXML_Cmp_IMAP_CarpetaLectura")
            Txt_IMAP_CarpetaDestino.Text = .Item("RecepXML_Cmp_IMAP_CarpetaDestino")
            Rdb_IMAP_DescHoy.Checked = .Item("RecepXML_Cmp_IMAP_DescHoy")
            Rdb_IMAP_DescNoLeidos.Checked = .Item("RecepXML_Cmp_IMAP_DescNoLeidos")

        End With

        Lbl_CarpetaLectura.Enabled = Rdb_IMAP.Checked
        Lbl_CarpetaDestino.Enabled = Rdb_IMAP.Checked
        Txt_IMAP_CarpetaLectura.Enabled = Rdb_IMAP.Checked
        Txt_IMAP_CarpetaDestino.Enabled = Rdb_IMAP.Checked
        Rdb_IMAP_DescNoLeidos.Enabled = Rdb_IMAP.Checked
        Rdb_IMAP_DescHoy.Enabled = Rdb_IMAP.Checked
        Chk_RecepXMLCmp_ElimiCorreosPOP3.Enabled = Rdb_POP3.Checked

        Txt_IMAP_CarpetaLectura.ReadOnly = False
        Txt_IMAP_CarpetaDestino.ReadOnly = False

    End Sub

    Private Sub Btn_BuscarSMTPRecepXMLComp_Click(sender As Object, e As EventArgs) Handles Btn_BuscarSMTPRecepXMLComp.Click

        Dim Fm As New Frm_Correos_Conf_SMTP_Lista(Frm_Correos_Conf_SMTP_Lista.Enum_Accion.Seleccionar)
        Fm.ShowDialog(Me)
        _Row_CuentaSMTP = Fm.Pro_Row_Cuenta
        Fm.Dispose()

        If Not IsNothing(_Row_CuentaSMTP) Then
            Txt_CuentaSMTP.Text = _Row_CuentaSMTP.Item("Nombre_Usuario")
        End If

    End Sub

    Private Sub Rdb_IMAP_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_IMAP.CheckedChanged
        Lbl_CarpetaLectura.Enabled = Rdb_IMAP.Checked
        Lbl_CarpetaDestino.Enabled = Rdb_IMAP.Checked
        Txt_IMAP_CarpetaLectura.Enabled = Rdb_IMAP.Checked
        Txt_IMAP_CarpetaDestino.Enabled = Rdb_IMAP.Checked
        Rdb_IMAP_DescNoLeidos.Enabled = Rdb_IMAP.Checked
        Rdb_IMAP_DescHoy.Enabled = Rdb_IMAP.Checked
        Chk_RecepXMLCmp_ElimiCorreosPOP3.Enabled = Rdb_POP3.Checked
    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Txt_CuentaSMTP.Text) Then
            MessageBoxEx.Show(Me, "Falta la cuenta del correo SMTP", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Rdb_POP3.Checked Then
            If Not Fx_ConectarPOP3() Then
                Return
            End If
        End If

        If Rdb_IMAP.Checked Then
            If Not Fx_Conectar_IMAP() Then
                Return
            End If
        End If

        With _Global_Row_Configuracion_General

            .Item("RecepXMLComp_CorreoPOP3") = Txt_CuentaSMTP.Text
            .Item("RecepXML_Cmp_CorreoSMTP") = Txt_CuentaSMTP.Text
            .Item("RecepXMLCmp_ElimiCorreosPOP3") = Chk_RecepXMLCmp_ElimiCorreosPOP3.Checked
            .Item("RecepXMLCmp_MarcaAgua") = Txt_RecepXMLCmp_MarcaAgua.Text
            .Item("RecepXML_Cmp_POP3") = Rdb_POP3.Checked
            .Item("RecepXML_Cmp_IMAP") = Rdb_IMAP.Checked
            .Item("RecepXML_Cmp_IMAP_CarpetaLectura") = Txt_IMAP_CarpetaLectura.Text
            .Item("RecepXML_Cmp_IMAP_CarpetaDestino") = Txt_IMAP_CarpetaDestino.Text
            .Item("RecepXML_Cmp_IMAP_DescHoy") = Rdb_IMAP_DescHoy.Checked
            .Item("RecepXML_Cmp_IMAP_DescNoLeidos") = Rdb_IMAP_DescNoLeidos.Checked

        End With

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Configuracion Set " &
                       "RecepXMLComp_CorreoPOP3 = '" & Txt_CuentaSMTP.Text & "'" &
                       ",RecepXMLCmp_ElimiCorreosPOP3 = " & Convert.ToInt32(Chk_RecepXMLCmp_ElimiCorreosPOP3.Checked) &
                       ",RecepXMLCmp_MarcaAgua = '" & Txt_RecepXMLCmp_MarcaAgua.Text & "'" &
                       ",RecepXML_Cmp_CorreoSMTP = '" & Txt_CuentaSMTP.Text & "'" &
                       ",RecepXML_Cmp_POP3 = " & Convert.ToInt32(Rdb_POP3.Checked) &
                       ",RecepXML_Cmp_IMAP = " & Convert.ToInt32(Rdb_IMAP.Checked) &
                       ",RecepXML_Cmp_IMAP_CarpetaLectura = '" & Txt_IMAP_CarpetaLectura.Text & "'" &
                       ",RecepXML_Cmp_IMAP_CarpetaDestino = '" & Txt_IMAP_CarpetaDestino.Text & "'" &
                       ",RecepXML_Cmp_IMAP_DescHoy = " & Convert.ToInt32(Rdb_IMAP_DescHoy.Checked) &
                       ",RecepXML_Cmp_IMAP_DescNoLeidos = " & Convert.ToInt32(Rdb_IMAP_DescNoLeidos.Checked) &
                       "Where Modalidad = '  '"

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Grabar = True
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If

    End Sub

    Function Fx_ConectarPOP3() As Boolean

        Dim _Host As String = _Row_CuentaSMTP.Item("Host")
        Dim _User As String = _Row_CuentaSMTP.Item("Nombre_Usuario")
        Dim _Pass As String = _Row_CuentaSMTP.Item("Contrasena")

        Dim _Pop3 As New Pop3
        'Using _Pop3 As New Pop3
        _Pop3.Connect(_Host)                          'Utilice sobrecargas o ConnectSSL si necesita especificar otro puerto o SSL.
        '_Pop3.Login(_User, _Pass)                    ' You can also use: LoginAPOP, LoginPLAIN, LoginCRAM, LoginDIGEST methods,
        _Pop3.UseBestLogin(_User, _Pass)              ' You can also use: LoginAPOP, LoginPLAIN, LoginCRAM, LoginDIGEST methods,
        ' or use UseBestLogin method if you want Mail.dll to choose for you.

        If Not _Pop3.Connected Then
            MessageBoxEx.Show(Me, "No es posible establecer conexión", "Conexión POP3", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        _Pop3.Close()

        MessageBoxEx.Show(Me, "Conexión establecida correctamente", "Conexión POP3", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Return True

    End Function

    Function Fx_Conectar_IMAP() As Boolean

        Dim _Host As String = _Row_CuentaSMTP.Item("Host")
        Dim _User As String = _Row_CuentaSMTP.Item("Nombre_Usuario")
        Dim _Pass As String = _Row_CuentaSMTP.Item("Contrasena")

        Dim _Imap As New Imap

        Try

            '_Imap.SSLConfiguration.EnabledSslProtocols = SslProtocols.Tls12

            _Imap.ConnectSSL(_Host)  ' or Connect for non SSL/TLS<font></font>
            _Imap.UseBestLogin(_User, _Pass)

            _Imap.SelectInbox()

            If Not _Imap.Connected Then
                Throw New System.Exception("No es posible establecer conexión")
            End If

            Dim _Folder = _Imap.GetFolders
            Dim _ExisteCarpDestino As Boolean = True
            Dim _ExisteCarpLectura As Boolean = True

            If Not String.IsNullOrWhiteSpace(Txt_IMAP_CarpetaDestino.Text) Then
                _ExisteCarpDestino = False
                For Each _Carp In _Folder
                    If _Carp.Name = Txt_IMAP_CarpetaDestino.Text Then
                        _ExisteCarpDestino = True
                        Exit For
                    End If
                Next
            End If

            If Not String.IsNullOrWhiteSpace(Txt_IMAP_CarpetaLectura.Text) Then
                _ExisteCarpLectura = False
                For Each _Carp In _Folder
                    If _Carp.Name = Txt_IMAP_CarpetaLectura.Text Then
                        _ExisteCarpLectura = True
                        Exit For
                    End If
                Next
            End If

            If Not _ExisteCarpDestino Then
                Throw New System.Exception("No existe carpeta de destino: " & Txt_IMAP_CarpetaDestino.Text)
            End If

            If Not _ExisteCarpLectura Then
                Throw New System.Exception("No existe carpeta de lectura: " & Txt_IMAP_CarpetaDestino.Text)
            End If

            _Imap.Close()

            MessageBoxEx.Show(Me, "Conexión establecida correctamente", "Conexión IMAP", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return True

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error de conexión IMAP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End Try

        '_Imap.CurrentFolder

    End Function


End Class
