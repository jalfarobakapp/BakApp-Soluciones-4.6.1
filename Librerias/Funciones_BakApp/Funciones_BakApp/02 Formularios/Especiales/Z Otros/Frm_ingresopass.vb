Imports DevComponents.DotNetBar
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

        AccesoAdministrador = CBool(Cuenta_registros(_Global_BaseBk & "ZW_PermisosADM", _
                                                        "ClaveAdministrador = '" & Encripta_md5(Txtpass.Text) & "'"))

        Dim Encriptado As String = Trim(Encripta_md5(Txtpass.Text))
        If Not AccesoAdministrador Then
            MessageBoxEx.Show(Me, "Clave de acceso no autorizado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txtpass.SelectAll()
            Txtpass.Focus()
        Else
            Me.Close()
        End If
    End Function

    Private Sub Frm_ingresopass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AccesoAdministrador = False
        Txtpass.Text = String.Empty
        Me.ActiveControl = Txtpass
    End Sub
End Class