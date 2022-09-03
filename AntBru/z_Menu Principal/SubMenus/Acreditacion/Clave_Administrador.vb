Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Clave_Administrador

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Public Sub New(ByVal Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Sub Sb_Grabar_Nueva_Clave()

        If RCL1(Txtpass1.Text, Txtpass2.Text) Then

            Consulta_sql = "UPDATE " & _Global_BaseBk & "ZW_PermisosADM SET ClaveAdministrador = '" & Encripta_md5(Txtpass1.Text) & _
                        "' WHERE Nombre = '" & Trim(Lbl_Usuario.Text) & "'"

            _Sql.Ej_consulta_IDU(Consulta_sql)

            MessageBoxEx.Show(_Fm_Menu_Padre, "Su nueva clave ha sido cambiada correctamente", "Cambio de Clave", _
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

            _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Right)
            Me.Dispose()

        Else
            Txtpass1.Focus()
        End If



    End Sub

    Private Sub Btn_Ver_Clave_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Btn_Ver_Clave_01.MouseDown
        Txtpass1.PasswordChar = ""
    End Sub

    Private Sub Btn_Ver_Clave_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Btn_Ver_Clave_01.MouseUp
        Txtpass1.PasswordChar = "*"
    End Sub

    Private Sub Btn_Ver_Clave_02_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Btn_Ver_Clave_02.MouseDown
        Txtpass2.PasswordChar = ""
    End Sub

    Private Sub Btn_Ver_Clave_02_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Btn_Ver_Clave_02.MouseUp
        Txtpass2.PasswordChar = "*"
    End Sub

    Function RCL1(ByVal Texto1 As String, ByVal Texto2 As String) As Boolean

        If Texto1 <> Texto2 Then
            Beep()
            ToastNotification.Show(Me, "CONTRASEÑAS DISTINTAS", My.Resources.cross, _
                                 2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
        ElseIf String.IsNullOrEmpty(Trim(Texto1)) Or String.IsNullOrEmpty(Trim(Texto2)) Then
            Beep()
            ToastNotification.Show(Me, "CONTRASEÑA EN BLANCO", My.Resources.cross, _
                                 2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
        ElseIf Texto1 = Texto2 Then
            Return True
        End If

    End Function

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Right)
        Me.Dispose()
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Sb_Grabar_Nueva_Clave()
    End Sub

    Private Sub Clave_Administrador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Txt_Password.Focus()
    End Sub

    Private Sub Txt_Password_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Password.TextChanged
        Dim Usuario As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "ZW_PermisosADM", "Nombre", "ClaveAdministrador = '" &
                  Encripta_md5(Txt_Password.Text) & "'")

        Lbl_Usuario.Text = Usuario
        If Usuario <> "" Then
            'Encripta_md5(PasswordTextBox.Text)
            Grupocambiapass.Enabled = True
            Txtpass1.Focus()
        Else
            Grupocambiapass.Enabled = False
        End If
    End Sub
End Class
