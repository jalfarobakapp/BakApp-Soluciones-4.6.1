Imports BkSpecialPrograms
Imports DevComponents.DotNetBar
Public Class Frm_Conexiones

    Private _Cl_Conexion As New Cl_Conexion

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Conexiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Mensaje As New LsValiciones.Mensajes
        _Mensaje = _Cl_Conexion.Fx_LeerArchivoConexionJson(False)

        If Not _Mensaje.EsCorrecto OrElse _Mensaje.Id = 0 Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        With _Cl_Conexion.Ls_Conexiones

            With .Item(0)
                .NombreConexion = String.Empty
                Txt_Rd_Host.Text = .Host
                Txt_Rd_Puerto.Text = .Puerto
                Txt_Rd_Usuario.Text = .Usuario
                Txt_Rd_Password.Text = .Password
                Txt_Rd_Basededatos.Text = .Basededatos
            End With

            With .Item(1)
                .NombreConexion = String.Empty
                Txt_Wms_Host.Text = .Host
                Txt_Wms_Puerto.Text = .Puerto
                Txt_Wms_Usuario.Text = .Usuario
                Txt_Wms_Password.Text = .Password
                Txt_Wms_Basededatos.Text = .Basededatos
            End With

        End With

    End Sub

    Private Sub Btn_ProbarConexionRd_Click(sender As Object, e As EventArgs) Handles Btn_ProbarConexionRd.Click
        Fx_ProbarConexionRd()
    End Sub

    Function Fx_ProbarConexionRd() As Boolean

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False

            Dim _Cadena As String = _Cl_Conexion.Fx_CadenaConexion(Txt_Rd_Host.Text, Txt_Rd_Puerto.Text, Txt_Rd_Basededatos.Text, Txt_Rd_Usuario.Text, Txt_Rd_Password.Text)

            Dim _Mensaje As New LsValiciones.Mensajes

            _Mensaje = _Cl_Conexion.Fx_Conectar(_Cadena)

            If Not _Mensaje.EsCorrecto Then
                MessageBoxEx.Show(Me, Fx_AjustarTexto(_Mensaje.Mensaje, 100), _Mensaje.Detalle & " (Base de datos RANDOM/BAKAPP)", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Rd_Host.Focus()
                Return False
            End If

            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle & "Base de datos " & Txt_Rd_Basededatos.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            With _Cl_Conexion.Ls_Conexiones

                With _Cl_Conexion.Ls_Conexiones

                    With .Item(0)

                        .NombreConexion = "RandomBakapp"
                        .Host = Txt_Rd_Host.Text
                        .Puerto = Txt_Rd_Puerto.Text
                        .Usuario = Txt_Rd_Usuario.Text
                        .Password = Txt_Rd_Password.Text
                        .Basededatos = Txt_Rd_Basededatos.Text

                    End With

                End With

            End With

        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try

        Return True

    End Function
    Private Sub Btn_ProbarConexionWms_Click(sender As Object, e As EventArgs) Handles Btn_ProbarConexionWms.Click
        Fx_ProbarConexionWms()
    End Sub

    Function Fx_ProbarConexionWms() As Boolean

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False

            Dim _Cadena As String = _Cl_Conexion.Fx_CadenaConexion(Txt_Wms_Host.Text, Txt_Wms_Puerto.Text, Txt_Wms_Basededatos.Text, Txt_Wms_Usuario.Text, Txt_Wms_Password.Text)

            Dim _Mensaje As New LsValiciones.Mensajes

            _Mensaje = _Cl_Conexion.Fx_Conectar(_Cadena)

            If Not _Mensaje.EsCorrecto Then
                MessageBoxEx.Show(Me, Fx_AjustarTexto(_Mensaje.Mensaje, 100), _Mensaje.Detalle & " (Base de datos de WMS)", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Wms_Host.Focus()
                Return False
            End If

            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle & "Base de datos " & Txt_Wms_Basededatos.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            With _Cl_Conexion.Ls_Conexiones

                With _Cl_Conexion.Ls_Conexiones

                    With .Item(1)

                        .NombreConexion = "WMS"
                        .Host = Txt_Wms_Host.Text
                        .Puerto = Txt_Wms_Puerto.Text
                        .Usuario = Txt_Wms_Usuario.Text
                        .Password = Txt_Wms_Password.Text
                        .Basededatos = Txt_Wms_Basededatos.Text

                    End With

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

        'If _Cl_Conexion.Ls_Conexiones.Item(0).NombreConexion <> "RandomBakapp" Or
        '   _Cl_Conexion.Ls_Conexiones.Item(1).NombreConexion <> "WMS" Then
        '    MessageBoxEx.Show(Me, "Debe probar las conexiones antes de grabar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Return
        'End If

        If Not Fx_ProbarConexionRd() Then Return
        If Not Fx_ProbarConexionWms() Then Return

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje = _Cl_Conexion.Fx_GrabarConexiones()

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

    End Sub

End Class
