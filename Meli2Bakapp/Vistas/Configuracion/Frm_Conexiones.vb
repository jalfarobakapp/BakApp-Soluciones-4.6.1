Imports BkSpecialPrograms
Imports DevComponents.DotNetBar
Public Class Frm_Conexiones

    Private _Cl_ConfiguracionLocal As New Cl_ConfiguracionLocal

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Conexiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Mensaje As New LsValiciones.Mensajes
        _Mensaje = _Cl_ConfiguracionLocal.Fx_LeerArchivoConexionJson(False)

        If Not _Mensaje.EsCorrecto OrElse _Mensaje.Id = 0 Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Txt_Global_BaseBk.Text = _Cl_ConfiguracionLocal.Configuracion.Global_BaseBk

        With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones

            With .Item(0)
                .NombreConexion = String.Empty
                Txt_Rd_Host.Text = .Host
                Txt_Rd_Puerto.Text = .Puerto
                Txt_Rd_Usuario.Text = .Usuario
                Txt_Rd_Password.Text = .Password
                Txt_Rd_Basededatos.Text = .Basededatos
            End With

            With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones.Item(0)
                Cadena_ConexionSQL_Server = _Cl_ConfiguracionLocal.Fx_CadenaConexion(.Host, .Puerto, .Basededatos, .Usuario, .Password)
            End With

            With .Item(1)
                .NombreConexion = String.Empty
                Txt_Meli_Host.Text = .Host
                Txt_Meli_Puerto.Text = .Puerto
                Txt_Meli_Usuario.Text = .Usuario
                Txt_Meli_Password.Text = .Password
                Txt_Meli_Basededatos.Text = .Basededatos
            End With

        End With

    End Sub

    Private Sub Btn_ProbarConexionRd_Click(sender As Object, e As EventArgs) Handles Btn_ProbarConexionRd.Click
        If Fx_ProbarConexionRd() Then

            With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones.Item(0)
                Cadena_ConexionSQL_Server = _Cl_ConfiguracionLocal.Fx_CadenaConexion(.Host, .Puerto, .Basededatos, .Usuario, .Password)
            End With

        Else
            Cadena_ConexionSQL_Server = String.Empty
        End If
    End Sub

    Private Sub Btn_ProbarConexionMeli_Click(sender As Object, e As EventArgs) Handles Btn_ProbarConexionMeli.Click
        Fx_ProbarConexionMeli()
    End Sub

    Function Fx_ProbarConexionRd() As Boolean

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False

            Dim _Cadena As String = _Cl_ConfiguracionLocal.Fx_CadenaConexion(Txt_Rd_Host.Text, Txt_Rd_Puerto.Text, Txt_Rd_Basededatos.Text, Txt_Rd_Usuario.Text, Txt_Rd_Password.Text)

            Dim _Mensaje As New LsValiciones.Mensajes

            _Mensaje = _Cl_ConfiguracionLocal.Fx_Conectar(_Cadena)

            If Not _Mensaje.EsCorrecto Then
                MessageBoxEx.Show(Me, Fx_AjustarTexto(_Mensaje.Mensaje, 100), _Mensaje.Detalle & " (Base de datos RANDOM/BAKAPP)", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Rd_Host.Focus()
                Return False
            End If

            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle & "Base de datos " & Txt_Rd_Basededatos.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones

                With .Item(0)

                    .NombreConexion = "RandomBakapp"
                    .Host = Txt_Rd_Host.Text
                    .Puerto = Txt_Rd_Puerto.Text
                    .Usuario = Txt_Rd_Usuario.Text
                    .Password = Txt_Rd_Password.Text
                    .Basededatos = Txt_Rd_Basededatos.Text

                End With

            End With

        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try

        Return True

    End Function

    Function Fx_ProbarConexionMeli() As Boolean

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False

            Dim _Cadena As String = _Cl_ConfiguracionLocal.Fx_CadenaConexion(Txt_Meli_Host.Text, Txt_Meli_Puerto.Text, Txt_Meli_Basededatos.Text, Txt_Meli_Usuario.Text, Txt_Meli_Password.Text)

            Dim _Mensaje As New LsValiciones.Mensajes

            _Mensaje = _Cl_ConfiguracionLocal.Fx_Conectar(_Cadena)

            If Not _Mensaje.EsCorrecto Then
                MessageBoxEx.Show(Me, Fx_AjustarTexto(_Mensaje.Mensaje, 100), _Mensaje.Detalle & " (Base de datos de MELI)", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Meli_Host.Focus()
                Return False
            End If

            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle & "Base de datos " & Txt_Meli_Basededatos.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones

                With .Item(1)

                    .NombreConexion = "Meli"
                    .Host = Txt_Meli_Host.Text
                    .Puerto = Txt_Meli_Puerto.Text
                    .Usuario = Txt_Meli_Usuario.Text
                    .Password = Txt_Meli_Password.Text
                    .Basededatos = Txt_Meli_Basededatos.Text

                End With

            End With

        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try

        Return True

    End Function

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Txt_Global_BaseBk.Text) Then
            MessageBoxEx.Show(Me, "Debe ingresar el nombre de la base de datos de BAKAPP", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Global_BaseBk.Focus()
            Return
        End If

        If Not Fx_ProbarConexionRd() Then Return
        If Not Fx_ProbarConexionMeli() Then Return

        _Cl_ConfiguracionLocal.Configuracion.Global_BaseBk = Txt_Global_BaseBk.Text

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje = _Cl_ConfiguracionLocal.Fx_GrabarConexiones()

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

    End Sub
End Class
