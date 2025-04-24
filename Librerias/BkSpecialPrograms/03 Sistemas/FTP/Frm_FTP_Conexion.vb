Imports System.Net
Imports System.Security.Policy
Imports BkSpecialPrograms.Cl_Ftp
Imports DevComponents.DotNetBar

Public Class Frm_FTP_Conexion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Ftp As New Cl_Ftp
    Public Property Grabar As Boolean

    Private _eTipo_Ftp As Cl_Ftp.eTipo_Ftp


    Public Sub New(_eTipo_Ftp As Cl_Ftp.eTipo_Ftp)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._eTipo_Ftp = _eTipo_Ftp

        Dim _Id = 0

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Ftp_Conexiones Where Tipo = '" & _eTipo_Ftp.ToString & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row) Then
            _Id = _Row.Item("Id")
        End If

        Ftp.Fx_Llenar_Host(_Id)

    End Sub

    Private Sub Frm_FTP_Conexion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "CONEXION FTP PARA " & _eTipo_Ftp.ToString.ToUpper

        Txt_Carpeta_Imagenes.Text = "/" & _eTipo_Ftp.ToString & "/Imagenes"
        Txt_Carpeta_Archivos.Text = "/" & _eTipo_Ftp.ToString & "/Archivos"

        With Ftp.Zw_Ftp_Conexiones

            Txt_Usuario.Text = .Usuario
            Txt_Clave.Text = .Clave
            Txt_Host.Text = .Host
            Txt_Puerto.Text = .Puerto
            'Txt_Carpeta_Archivos.Text = .Carpeta_Archivos
            'txt_Carpeta_Imagenes.Text = .Carpeta_Imagenes
            Txt_Fichero.Text = .Fichero
            Txt_Url_public.Text = .Url_public
            Input_Timeout.Value = .Timeout
            Chk_UsePassive.Checked = .UsePassive

        End With

        Me.ActiveControl = Txt_Usuario

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Txt_Usuario.Text) Then
            MessageBoxEx.Show(Me, "Debe indicar el usuario", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Usuario.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Clave.Text) Then
            MessageBoxEx.Show(Me, "Debe indicar la clave", "Clave", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Clave.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Host.Text) Then
            MessageBoxEx.Show(Me, "Debe indicar el host", "Host", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Host.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Puerto.Text) Then
            MessageBoxEx.Show(Me, "Debe indicar el puerto", "Puerto", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Puerto.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Fichero.Text) Then
            MessageBoxEx.Show(Me, "Debe indicar el nombre del fichero", "Fichero", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Fichero.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Url_public.Text) Then
            MessageBoxEx.Show(Me, "Debe indicar la url publica", "Url publica", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Url_public.Focus()
            Return
        End If

        With Ftp.Zw_Ftp_Conexiones

            .Usuario = Txt_Usuario.Text.Trim
            .Clave = Txt_Clave.Text.Trim
            .Host = Txt_Host.Text.Trim
            .Puerto = Txt_Puerto.Text.Trim
            .Fichero = Txt_Fichero.Text.Trim
            .Carpeta_Archivos = Txt_Carpeta_Archivos.Text
            .Carpeta_Imagenes = Txt_Carpeta_Imagenes.Text
            .Url_public = Txt_Url_public.Text.Trim
            .Timeout = Input_Timeout.Value
            .UsePassive = Chk_UsePassive.Checked

        End With

        'Try
        '    Dim request As HttpWebRequest = CType(WebRequest.Create(Txt_Url_public.Text.Trim), HttpWebRequest)
        '    request.Method = "HEAD"
        '    Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
        '        'MessageBoxEx.Show(Me, "La url publica es correcta", "Url publica", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End Using
        'Catch ex As WebException
        '    MessageBoxEx.Show(Me, "La url publica no es correcta", "Url publica", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Txt_Url_public.Focus()
        '    Return
        'End Try

        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False

        Dim _Mensaje As LsValiciones.Mensajes = Ftp.Fx_Probar_Conexion_FTP

        Me.Cursor = Cursors.Default
        Me.Enabled = True

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Col1_Mensaje, _Mensaje.Col2_Detalle, MessageBoxButtons.OK, _Mensaje.Icono)
            Return
        End If

        _Mensaje = Ftp.Fx_Existe_Directorio3(Ftp.Zw_Ftp_Conexiones.Fichero & "/" & _eTipo_Ftp.ToString)

        If Not _Mensaje.EsCorrecto Then

            If _Mensaje.HuboOtroError Then
                MessageBoxEx.Show(Me, _Mensaje.Col1_Mensaje, _Mensaje.Col2_Detalle, MessageBoxButtons.OK, _Mensaje.Icono)
                Return
            End If

            _Mensaje = Ftp.Fx_Crear_Directorio(Ftp.Zw_Ftp_Conexiones.Fichero & "/" & _eTipo_Ftp.ToString)

            If Not _Mensaje.EsCorrecto Then
                MessageBoxEx.Show(Me, _Mensaje.Col1_Mensaje, _Mensaje.Col2_Detalle, MessageBoxButtons.OK, _Mensaje.Icono)
                Return
            End If

        End If

        _Mensaje = Ftp.Fx_Existe_Directorio3(Ftp.Zw_Ftp_Conexiones.Fichero & "/" & _eTipo_Ftp.ToString & "/Imagenes")

        If Not _Mensaje.EsCorrecto Then

            If _Mensaje.HuboOtroError Then
                MessageBoxEx.Show(Me, _Mensaje.Col1_Mensaje, _Mensaje.Col2_Detalle, MessageBoxButtons.OK, _Mensaje.Icono)
                Return
            End If

            _Mensaje = Ftp.Fx_Crear_Directorio(Ftp.Zw_Ftp_Conexiones.Fichero & "/" & _eTipo_Ftp.ToString & "/Imagenes")

            If Not _Mensaje.EsCorrecto Then
                MessageBoxEx.Show(Me, _Mensaje.Col1_Mensaje, _Mensaje.Col2_Detalle, MessageBoxButtons.OK, _Mensaje.Icono)
                Return
            End If

        End If

        _Mensaje = Ftp.Fx_Existe_Directorio3(Ftp.Zw_Ftp_Conexiones.Fichero & "/" & _eTipo_Ftp.ToString & "/Archivos")

        If Not _Mensaje.EsCorrecto Then

            If _Mensaje.HuboOtroError Then
                MessageBoxEx.Show(Me, _Mensaje.Col1_Mensaje, _Mensaje.Col2_Detalle, MessageBoxButtons.OK, _Mensaje.Icono)
                Return
            End If

            _Mensaje = Ftp.Fx_Crear_Directorio(Ftp.Zw_Ftp_Conexiones.Fichero & "/" & _eTipo_Ftp.ToString & "/Archivos")

            If Not _Mensaje.EsCorrecto Then
                MessageBoxEx.Show(Me, _Mensaje.Col1_Mensaje, _Mensaje.Col2_Detalle, MessageBoxButtons.OK, _Mensaje.Icono)
                Return
            End If

        End If

        Ftp.Zw_Ftp_Conexiones.Tipo = _eTipo_Ftp.ToString

        If CBool(Ftp.Zw_Ftp_Conexiones.Id) Then
            _Mensaje = Ftp.Fx_Editar_Host()
        Else
            _Mensaje = Ftp.Fx_Grabar_Host()
        End If

        MessageBoxEx.Show(Me, _Mensaje.Col1_Mensaje, _Mensaje.Col2_Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If _Mensaje.EsCorrecto Then
            Grabar = True
            Me.Close()
        End If

    End Sub

End Class
