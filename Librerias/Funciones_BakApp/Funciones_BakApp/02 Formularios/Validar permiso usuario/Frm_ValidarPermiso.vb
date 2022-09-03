Imports DevComponents.DotNetBar
Imports System.Windows.Forms

Public Class Frm_ValidarPermiso

    Public AccionValidada As Boolean
    Public PermisoAsociado As String
    Public _Mostrar_Aceptar As Boolean = True
    Public _Usuario
    Public _Nombre_Usuario

    Dim _Teclado As Boolean

    Function Accion(ByVal ClaveUsuario As String, ByVal Permiso As String) As Boolean
        Dim Tiene As Boolean
        If String.IsNullOrEmpty(Trim(ClaveUsuario)) Then Return False

        Consulta_sql = "Select top 1 * From TABFU Where PWFU = '" & TraeClaveRD(ClaveUsuario) & "'"
        Dim _Tbl As DataTable = get_Tablas(Consulta_sql, cn1)

        If CBool(_Tbl.Rows.Count) Then

            _Usuario = _Tbl.Rows(0).Item("KOFU")
            _Nombre_Usuario = _Tbl.Rows(0).Item("NOKOFU")

            Dim Condicion = "CodUsuario = '" & _Usuario & "' and CodPermiso = '" & Permiso & "'"
            Tiene = CBool(Cuenta_registros(_Global_BaseBk & "ZW_PermisosVsUsuarios", Condicion))
        Else
            _Usuario = String.Empty : _Nombre_Usuario = String.Empty : Tiene = False
        End If

        Return Tiene

    End Function


  
    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        Validar()
    End Sub

    Sub Validar()



        If String.IsNullOrEmpty(Trim(Txtclave.Text)) Then
            MessageBoxEx.Show("Clave vacía", "Acción cancelada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            AccionValidada = Accion(Txtclave.Text, PermisoAsociado)

            If AccionValidada Then
                If _Mostrar_Aceptar Then
                    MessageBoxEx.Show("¡Autorizado!", "Permiso de usuario", Windows.Forms.MessageBoxButtons.OK, _
                                      Windows.Forms.MessageBoxIcon.Information)
                End If
            Else
                If String.IsNullOrEmpty(_Usuario) Then
                    MessageBoxEx.Show("Usuario no existe", "Verificar permiso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Txtclave.Text = String.Empty
                    Txtclave.Focus()
                    Return
                End If
                MensajeSinPermiso(PermisoAsociado, _Usuario, _Nombre_Usuario)
            End If
        End If

        Me.Close()

    End Sub



    Private Sub Txtclave_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtclave.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            Validar()
        End If
    End Sub

    Private Sub Frm_ValidarPermiso_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            AccionValidada = False
            Me.Close()
        End If
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
            BtnAceptar.Focus()
            TouchKeyboard1.SetShowTouchKeyboard(Txtclave, DevComponents.DotNetBar.Keyboard.TouchKeyboardStyle.Floating)
        Else
            TouchKeyboard1.SetShowTouchKeyboard(Txtclave, DevComponents.DotNetBar.Keyboard.TouchKeyboardStyle.No)
            TouchKeyboard1.HideKeyboard()
        End If

        Txtclave.Focus()

    End Function

    Private Sub Btn_Teclado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Teclado.Click
        If _Teclado Then
            Fx_Activar_Deactivar_Teclado(False)
            _Teclado = False
        Else
            Fx_Activar_Deactivar_Teclado(True)
            _Teclado = True
        End If
        'BtnAceptar.Focus()
    End Sub
End Class