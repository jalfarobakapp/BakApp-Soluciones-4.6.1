Imports DevComponents.DotNetBar
Imports System.Windows.Forms

Public Class Frm_ValidarPermiso

    Public AccionValidada As Boolean
    Public PermisoAsociado As String

    Function Accion(ByVal ClaveUsuario As String, ByVal Permiso As String) As Boolean

        If Trim(ClaveUsuario) = "" Then Return False

        Dim Usuario = trae_dato(tb, cn1, "KOFU", "TABFU", "PWFU = '" & _
                      TraeClaveRD(ClaveUsuario) & "'")

        If Usuario <> "" Then

            Dim Nro As String = Permiso
            If TienePermiso(Nro, Usuario) = True Then
                Return True
            Else
                Return False
            End If

        End If

    End Function


  
    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click

        Validar()

    End Sub

    Sub Validar()
        AccionValidada = Accion(Txtclave.Text, PermisoAsociado)

        If AccionValidada Then
            MessageBoxEx.Show("¡Autorizado!", "Permiso de usuario", Windows.Forms.MessageBoxButtons.OK, _
                              Windows.Forms.MessageBoxIcon.Information)
        Else
            MensajeSinPermiso(PermisoAsociado)
        End If
        Me.Close()

    End Sub



    Private Sub Txtclave_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtclave.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            Validar()
        End If
    End Sub
End Class