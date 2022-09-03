'Imports Funciones_BakApp
Imports System.Windows.Forms

Public Class Frm_ingresopass


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ver()
    End Sub

    Private Sub Txtpass_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtpass.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            ver()
        End If
    End Sub
    Function ver()

        Dim Administrador As Integer = Cuenta_registros("ZW_PermisosADM", _
                                                        "ClaveAdministrador = '" & Encripta_md5(Txtpass.Text) & "'")

        Dim Encriptado As String = Trim(Encripta_md5(Txtpass.Text))
        If Administrador = 0 Then
            MsgBox("Clave de acceso no autorizado", MsgBoxStyle.Critical, "Configuración de conexión")
            Txtpass.SelectAll()
            Txtpass.Focus()
        Else
            AccesoAdministrador = True
            Me.Close()
        End If
    End Function

    Private Sub Frm_ingresopass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AccesoAdministrador = False
        Txtpass.Text = ""
    End Sub
End Class