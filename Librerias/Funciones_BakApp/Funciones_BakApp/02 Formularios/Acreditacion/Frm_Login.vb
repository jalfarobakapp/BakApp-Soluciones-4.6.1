Imports System.Windows.Forms
Imports System.Drawing
'Imports Funciones_BakApp
Imports DevComponents.DotNetBar

Public Class Frm_Login

    Public CancelarLogin As Boolean
    Public UsuarioActivado As Boolean
    Public _RowUsuario As DataRow

    Dim _Teclado As Boolean

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

       
    End Sub

    Private Sub TxtxPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtxPassword.TextChanged
        If Trim(TxtxPassword.Text) = "" Then Return
        Txtxusuario.Text = trae_dato(tb, cn1, "NOKOFU", "TABFU", "PWFU = '" & _
                  TraeClaveRD(TxtxPassword.Text) & "'")
        If Txtxusuario.Text <> "" Then
            BtnxAceptar.Enabled = True
        Else
            BtnxAceptar.Enabled = False
        End If
    End Sub

    Private Sub BtnxAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxAceptar.Click
        Aceptar()
    End Sub

    Sub Aceptar()
        If Fx_Autentificar_Usuario(TxtxPassword.Text, Txtxusuario.Text) Then
            Nombre_funcionario_activo = Txtxusuario.Text
            sesion = True

            UsuarioActivado = True
            CancelarLogin = False

            'Frm_MenuPrincipal.TimpoEsperaNotificacion.Enabled = True
            AccesoAdministrador = False

            Me.Close()
        Else
            MessageBoxEx.Show(Me, "Clave desconocida", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            sesion = False
        End If
    End Sub


    Public Function Fx_Autentificar_Usuario(ByVal _Pass As String, _
                                          ByVal _Usuario As String) As Boolean
        'Dim ussuario As String = trae_dato(tb, cn1, "NOMBRE", "W_USUARIOS", "CLAVE = '" & _
        '          Encripta_md5(password_us) & "'")

        If Not String.IsNullOrEmpty(_Usuario) Then
            'Txtusuario.Text = ussuario

            FUNCIONARIO = trae_dato(tb, cn1, "KOFU", "TABFU", "PWFU = '" & _
                              TraeClaveRD(_Pass) & "'")

            Consulta_sql = "Select top 1 * From TABFU Where KOFU = '" & FUNCIONARIO & "'"
            Dim _Tbl As DataTable = get_Tablas(Consulta_sql, cn1)

            Nombre_funcionario_activo = trae_dato(tb, cn1, "NOKOFU", "TABFU", "PWFU = '" & _
                  TraeClaveRD(_Usuario) & "'")

            Dim inactivo As Boolean = trae_dato(tb, cn1, "INACTIVO", "TABFU", "PWFU = '" & _
                  TraeClaveRD(_Pass) & "'")

            If inactivo = True Then
                MessageBoxEx.Show(Me, "Usuario Inactivo en Sistema", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            Else
                _RowUsuario = _Tbl.Rows(0)
            End If


            Return True
        Else
            Return False
        End If

    End Function


    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        If AccesoAdministrador = False Then
            If sesion = False Then
                CancelarLogin = False
            Else
                CancelarLogin = True
            End If
            _RowUsuario = Nothing
            Me.Close()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub TxtxPassword_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtxPassword.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            BtnxAceptar.Focus()
            'Aceptar()
            'SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_Login_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Normal
        Me.StartPosition = FormStartPosition.CenterScreen
        TxtxPassword.Focus()
    End Sub

    Function Fx_Activar_Deactivar_Teclado(ByVal _Teclado As Boolean)
        Dim _x = Me.Location.X
        Dim _Y = Me.Location.Y

        Dim _H = Me.Height

        Dim _Ancho_Teclado = TouchKeyboard1.Size.Width

        Dim _Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
        Dim _Left = (Screen.PrimaryScreen.WorkingArea.Width - _Ancho_Teclado) / 2

        Me.TouchKeyboard1.FloatingLocation = New System.Drawing.Point(_Left, _Y + _H)
        If _Teclado Then
            BtnCancelar.Focus()
            TouchKeyboard1.SetShowTouchKeyboard(TxtxPassword, DevComponents.DotNetBar.Keyboard.TouchKeyboardStyle.Floating)
        Else
            TouchKeyboard1.SetShowTouchKeyboard(TxtxPassword, DevComponents.DotNetBar.Keyboard.TouchKeyboardStyle.No)
            TouchKeyboard1.HideKeyboard()
        End If

        TxtxPassword.Focus()

    End Function

    Private Sub Btn_Teclado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Teclado.Click
        If _Teclado Then
            Fx_Activar_Deactivar_Teclado(False)
            _Teclado = False
        Else
            Fx_Activar_Deactivar_Teclado(True)
            _Teclado = True
        End If
    End Sub
End Class