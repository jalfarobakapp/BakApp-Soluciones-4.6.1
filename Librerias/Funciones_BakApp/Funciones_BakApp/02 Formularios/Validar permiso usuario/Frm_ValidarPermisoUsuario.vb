Imports DevComponents.DotNetBar
Imports System.Windows.Forms


Public Class Frm_ValidarPermisoUsuario

    Public PermisoAceptado As Boolean
    Public _Funcionario As String

    Private Sub BtnIngresarClave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIngresarClave.Click
        Dim Fm As New Frm_ValidarPermiso
        Fm.PermisoAsociado = LblCodPermiso.Text
        Fm.ShowDialog(Me)
        PermisoAceptado = Fm.AccionValidada
        Me.Close()
    End Sub

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxSalir.Click
        PermisoAceptado = False
        Me.Close()
    End Sub


    Private Sub BtnOtorgarPermisoPermanente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOtorgarPermisoPermanente.Click

        If MessageBoxEx.Show(Me, "Si le da el permiso desde acá, dejara al usuario con acceso permanente" & vbCrLf & vbCrLf & _
                              "¿Está seguro de seguir con la gestión?", "Dejar al usuario con acceso permanente", _
                              MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

            Dim Frm_ingresopass As New Frm_ingresopass
            Frm_ingresopass.ShowDialog(Me)



            If AccesoAdministrador Then


                Dim Codpermiso As String = Trim(LblCodPermiso.Text)
                Dim _Clave_Admin As String = trae_dato(tb, cn1, "ClaveAdministrador", _Global_BaseBk & "ZW_PermisosADM")

                Dim _Llave As String = UCase(Codpermiso & "@" & FUNCIONARIO)
                _Llave = Encripta_md5(_Llave)

                Consulta_sql = "INSERT INTO " & _Global_BaseBk & "ZW_PermisosVsUsuarios (CodUsuario, CodPermiso, Llave) VALUES " & _
                                     "('" & _Funcionario & "','" & Trim(LblCodPermiso.Text) & "','" & _Llave & "')"

                If Ej_consulta_IDU(Consulta_sql, cn1) Then
                    MessageBoxEx.Show(Frm_ingresopass, "Permisos otorgado permanentemente al usuario", _
                                      "Otorgar permiso", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
                    PermisoAceptado = True
                    Me.Close()
                End If
            End If
            Frm_ingresopass.Dispose()
        End If
    End Sub

    Private Sub Frm_ValidarPermisoUsuario_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyValue = Keys.Escape Then
            PermisoAceptado = False
            Me.Close()
        End If
    End Sub

   
End Class