Imports DevComponents.DotNetBar

Public Module Modulo_Permiso

    Public Function TienePermiso(ByVal Codpermiso As String, _
                          Optional ByVal Func As String = "", _
                          Optional ByVal MostrarPermiso As Boolean = False, _
                          Optional ByVal _Mostrar_Boton As Boolean = True, _
                          Optional ByVal _Descripcion_Permiso As String = "") As Boolean
        Dim Permiso As Boolean = False
        If Func = "" Then Func = FUNCIONARIO

        Dim Condicion As String
        Condicion = "CodUsuario = '" & Func & _
                     "' AND CodPermiso = '" & Codpermiso & "'"

        Dim Tiene As Integer = Cuenta_registros(_Global_BaseBk & "ZW_PermisosVsUsuarios", Condicion)
        If Tiene > 0 Then Permiso = True

        If MostrarPermiso = False Then
            If Permiso = False Then
                Beep()


                Dim NombrePermiso As String = trae_dato(tb, cn1, "DescripcionPermiso", _
                                               _Global_BaseBk & "ZW_Permisos", "CodPermiso = '" & Codpermiso & "'")

                If String.IsNullOrEmpty(_Descripcion_Permiso) Then
                    _Descripcion_Permiso = NombrePermiso
                End If



                Dim _NombreUsuario As String = trae_dato(tb, cn1, "NOKOFU", _
                                                "TABFU", "KOFU = '" & Func & "'")

                Dim Fm As New Frm_ValidarPermisoUsuario

                Fm.ShowInTaskbar = False
                Fm.LblCodPermiso.Text = Codpermiso
                Fm.LblDescripcionPermiso.Text = _Descripcion_Permiso
                Fm.PermisoAceptado = False
                Fm.Text = "Permiso de usuario: " & _NombreUsuario
                Fm._Funcionario = Func
                Fm.BtnIngresarClave.Visible = _Mostrar_Boton
                Fm.BtnPermisoRemoto.Visible = _Mostrar_Boton
                Fm.ShowDialog()

                Permiso = Fm.PermisoAceptado

                Fm.Dispose()

                'ToastNotification.Show(Me, message.Text, IIf(checkBoxX1.Checked, My.Resources.win, Nothing), slider1.Value * 1000, glow, pos)

            End If
        End If

        Return Permiso


    End Function

End Module
