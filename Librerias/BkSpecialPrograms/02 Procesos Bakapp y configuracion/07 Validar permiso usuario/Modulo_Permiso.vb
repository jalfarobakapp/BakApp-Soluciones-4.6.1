Imports DevComponents.DotNetBar

Public Module Modulo_Permiso

    Public _Rows_Info_Remota As DataRow
    Public _Id_Log_Gestion As Integer

    Public Function Fx_Tiene_Permiso(_Formulario As Form,
                                     _Codpermiso As String,
                                     Optional _Func As String = "",
                                     Optional _Mostrar_Permiso As Boolean = True,
                                     Optional _Mostrar_Boton_BtnIngresarClave As Boolean = True,
                                     Optional _Descripcion_Permiso As String = "",
                                     Optional _CodEntidad As String = "",
                                     Optional _CodSucEntidad As String = "",
                                     Optional _Mostrar_Boton_BtnPermisoRemoto As Boolean = True,
                                     Optional _Mostrar_Boton_BtnOtorgarPermisoPermanente As Boolean = True,
                                     Optional ByRef _Rows_Usuario_Autoriza As DataRow = Nothing,
                                     Optional ByRef _Solicitar_permiso_y_esperar As Boolean = False,
                                     Optional ByRef _Solicitar_permiso_y_no_esperar As Boolean = False,
                                     Optional ByRef _Permiso_Presencial As Boolean = False,
                                     Optional _Ds_Matriz_Documentos As Ds_Matriz_Documentos = Nothing,
                                     Optional _Grabar_Log As Boolean = True,
                                     Optional ByRef _Solicitar_Permiso_Al_Final As Boolean = False,
                                     Optional _Descripcion_Adicionasl As String = "",
                                     Optional _Idmaeedo As Integer = 0,
                                     Optional _PermitirPermisoBkp00039 As Boolean = False) As Boolean

        Dim _Permiso As Boolean = False

        _Rows_Info_Remota = Nothing
        _Id_Log_Gestion = 0

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_Sql As String

        If String.IsNullOrEmpty(_Func) Then _Func = FUNCIONARIO

        Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "ZW_PermisosVsUsuarios Where CodUsuario = '" & _Func & "' AND CodPermiso = '" & _Codpermiso & "'"
        Dim _Row_PermisosVsUsuarios As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If Not IsNothing(_Row_PermisosVsUsuarios) Then

            Dim _Llave = _Row_PermisosVsUsuarios.Item("Llave")

            Dim _Llave_Scrip1 As String = UCase(_Codpermiso.Trim & "@" & _Func.Trim)
            Dim _Llave_Scrip2 As String = UCase(_Codpermiso & "@" & _Func)
            Dim _Llave_Scrip3 As String = UCase(_Codpermiso.Trim & "@" & _Func)
            Dim _Llave_Scrip4 As String = UCase(_Codpermiso & "@" & _Func.Trim)

            _Llave_Scrip1 = Encripta_md5(_Llave_Scrip1)
            _Llave_Scrip2 = Encripta_md5(_Llave_Scrip2)
            _Llave_Scrip3 = Encripta_md5(_Llave_Scrip3)
            _Llave_Scrip4 = Encripta_md5(_Llave_Scrip4)

            _Permiso = (_Llave = _Llave_Scrip1 Or _Llave = _Llave_Scrip2 Or _Llave = _Llave_Scrip3 Or _Llave = _Llave_Scrip4)

            If _Permiso Then
                If _Codpermiso = "Bkp00039" AndAlso _Func = FUNCIONARIO AndAlso Not _PermitirPermisoBkp00039 Then
                    _Permiso = False
                End If
            Else

                MessageBoxEx.Show(_Formulario, "El permiso ha sido manipulado externamente por base de datos." & vbCrLf &
                                  "Informe al administrador del sistema.", "PERMISO DENEGADO",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Return False

            End If

        End If

        Dim Cl_Permiso As New Class_Permiso_BakApp
        Dim _Row_Permiso As DataRow = Cl_Permiso.Fx_Row_Traer_Permiso_Sistema(_Codpermiso)
        Dim _NombrePermiso As String

        If Not IsNothing(_Row_Permiso) Then

            _NombrePermiso = _Row_Permiso.Item("DescripcionPermiso")

            If String.IsNullOrEmpty(_Descripcion_Permiso) Then

                Dim _SqlQ As String = Cl_Permiso.Fx_Insertar_Permiso(_Codpermiso, Nothing, Nothing)
                _Descripcion_Permiso = _NombrePermiso

                If Not String.IsNullOrEmpty(_SqlQ) Then

                    Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "ZW_Permisos", "CodPermiso = '" & _Codpermiso & "'"))

                    If IsNothing(_Row_Permiso) Or Not _Reg Then
                        _Sql.Ej_consulta_IDU(_SqlQ)
                    End If
                End If

            End If

        Else

            MessageBoxEx.Show(_Formulario, "No existe este permiso Código: " & _Codpermiso, "Falta este permiso en Bakapp",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, _Formulario.TopMost)
            _Permiso = False
            Return _Permiso

        End If

        If _Mostrar_Permiso Then

            Dim _Crear_Doc As New Clase_Crear_Documento
            Dim _Id_DocEnc As Integer

            If _Permiso Then

                Consulta_Sql = "Select top 1 *  From TABFU Where KOFU = '" & _Func & "'"
                _Rows_Usuario_Autoriza = _Sql.Fx_Get_DataRow(Consulta_Sql)

                Dim _Archirst = String.Empty
                _Grabar_Log = False

                If CBool(_Idmaeedo) Then
                    _Archirst = "MAEEDO"
                End If

                If CBool(_Idmaeedo) Or Not String.IsNullOrWhiteSpace(_CodEntidad) Then
                    _Grabar_Log = True
                End If

                If _Grabar_Log Then
                    _Id_Log_Gestion = Fx_Add_Log_Gestion(_Func, Mod_Modalidad, _Archirst, _Idmaeedo, "", _NombrePermiso,
                                                         _Codpermiso, "", _CodEntidad, _CodSucEntidad,
                                                         True, _Rows_Usuario_Autoriza.Item("KOFU"))
                End If

            Else

                If Not IsNothing(_Ds_Matriz_Documentos) Then
                    _Id_DocEnc = _Crear_Doc.Fx_Crear_Documento_En_BakApp_Casi(_Ds_Matriz_Documentos, False, True)
                End If

                If Not _Solicitar_permiso_y_no_esperar Then Beep()

                Cl_Permiso.Sb_Existe_Permiso_En_BakApp(_Codpermiso)


                If String.IsNullOrEmpty(_Descripcion_Permiso) Then
                    _Descripcion_Permiso = _NombrePermiso
                End If

                _Descripcion_Permiso += _Descripcion_Adicionasl

                Dim _NombreUsuario As String = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & _Func & "'")

                Dim Fm As New Frm_ValidarPermisoUsuario(_CodEntidad, _CodSucEntidad)

                Fm.ShowInTaskbar = False
                Fm.Pro_Cod_Permiso = _Codpermiso
                Fm.Pro_Nombre_Permiso = _Descripcion_Permiso
                Fm.Text = "Permiso de usuario: " & _NombreUsuario
                Fm.Pro_Funcionario = _Func
                Fm.Btn_Autorizar_Permiso.Visible = _Mostrar_Boton_BtnIngresarClave
                Fm.Btn_Permiso_Remoto.Visible = _Mostrar_Boton_BtnPermisoRemoto
                Fm.BtnOtorgarPermisoPermanente.Visible = _Mostrar_Boton_BtnOtorgarPermisoPermanente
                Fm.Pro_Solicitar_permiso_y_esperar = _Solicitar_permiso_y_esperar
                Fm.Pro_Solicitar_permiso_y_no_esperar = _Solicitar_permiso_y_no_esperar
                Fm.TopMost = _Formulario.TopMost
                Fm.Id_DocEnc = _Id_DocEnc
                Fm.Solicitar_Permiso_Al_Final = _Solicitar_Permiso_Al_Final
                Fm.Idmaeedo = _Idmaeedo
                Fm.ShowDialog(_Formulario)

                _Permiso_Presencial = Fm.Pro_Permiso_Presencial

                _Permiso = Fm.Pro_Permiso_Aceptado

                _Solicitar_permiso_y_esperar = Fm.Pro_Solicitar_permiso_y_esperar
                _Solicitar_permiso_y_no_esperar = Fm.Pro_Solicitar_permiso_y_no_esperar
                _Solicitar_Permiso_Al_Final = Fm.Solicitar_Permiso_Al_Final

                _Rows_Info_Remota = Fm.Pro_Rows_Info_Remota

                If _Permiso Then

                    If _Permiso_Presencial And _Codpermiso = "Bkp00039" Then

                        Consulta_Sql = "Select * From " & _Global_BaseBk & "ZW_PermisosVsUsuarios 
                                        Where CodUsuario = '" & Fm.Pro_Rows_Usuario_Autoriza.Item("KOFU") & "' And CodPermiso = 'Bkp00039'"

                        Dim _Row_Permisos As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)
                        Dim _Dscto_Global As Double = _Ds_Matriz_Documentos.Tables("Encabezado_Doc").Rows(0).Item("TotalDsctoReal_Porc")

                        _Dscto_Global = Math.Round(_Dscto_Global / 100, 4)
                        Dim _Valor_Dscto As Double = Math.Round(_Row_Permisos.Item("Valor_Dscto") / 100, 4)

                        If _Valor_Dscto >= _Dscto_Global Then

                            If MessageBoxEx.Show(_Formulario, "¿Confirma dar un " & FormatPercent(_Dscto_Global, 2) & " de descuento global para el documento?",
                                             "Confirmar descuento global",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                                             MessageBoxDefaultButton.Button1, _Formulario.TopMost) <> DialogResult.Yes Then
                                _Permiso = False
                                _Grabar_Log = False
                            End If

                        Else

                            MessageBoxEx.Show(_Formulario, "Descuento global según documento " & FormatPercent(_Dscto_Global, 2) & " %" & Environment.NewLine &
                                              "Descuento máximo permitido para el usuario " & FUNCIONARIO.Trim & ": " & FormatPercent(_Valor_Dscto, 2),
                                              "PERMISO DENEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop,
                                              MessageBoxDefaultButton.Button1, _Formulario.TopMost)
                            _Permiso = False
                            _Grabar_Log = False

                        End If

                    End If

                    If (Fm.Pro_Rows_Usuario_Autoriza Is Nothing) Then

                        Consulta_Sql = "Select top 1 *  From TABFU Where KOFU = '" & _Func & "'"
                        _Rows_Usuario_Autoriza = _Sql.Fx_Get_DataRow(Consulta_Sql)

                    Else

                        _Rows_Usuario_Autoriza = Fm.Pro_Rows_Usuario_Autoriza

                    End If

                    If Not IsNothing(_Rows_Usuario_Autoriza) Then

                        Dim _Archirst = String.Empty

                        If CBool(_Idmaeedo) Then
                            _Archirst = "MAEEDO"
                        End If

                        Dim _Id_Rem = 0
                        Dim _NroRemota = String.Empty
                        Dim _PermisoRemoto = False

                        If Not IsNothing(_Rows_Info_Remota) Then
                            _PermisoRemoto = True
                            _Id_Rem = _Rows_Info_Remota.Item("Id_Rem")
                            _NroRemota = _Rows_Info_Remota.Item("NroRemota")
                        End If

                        If _Grabar_Log Then
                            _Id_Log_Gestion = Fx_Add_Log_Gestion(_Func, Mod_Modalidad, _Archirst, _Idmaeedo, "", _NombrePermiso,
                                                                 _Codpermiso, "", _CodEntidad, _CodSucEntidad,
                                                                 True, _Rows_Usuario_Autoriza.Item("KOFU"),
                                                                 _PermisoRemoto, _Id_Rem, _NroRemota)
                        End If

                    End If


                End If

                Fm.Dispose()

                If CBool(_Id_DocEnc) Then
                    Fx_Eliminar_Kasidoc_BakApp(_Id_DocEnc, "", False)
                End If

            End If

        End If

        Return _Permiso

    End Function

    Public Function Fx_TienePermiso_EnDoc(_Formulario As Form,
                                          _Codpermiso As String,
                                          _Idmaeedo As Integer,
                                          Optional _MostraPermiso As Boolean = True,
                                          Optional _Grabar_Log As Boolean = True) As Boolean
        Return Fx_Tiene_Permiso(_Formulario, _Codpermiso,, _MostraPermiso,,,,,,,,,,,, _Grabar_Log,,, _Idmaeedo)
    End Function
    Enum Enum_Archirst
        Maeedo
        Maeddo
    End Enum

    Public Function Fx_Tiene_Permiso(_CodPermiso As String, _Kofu As String) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_Sql As String

        Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "ZW_PermisosVsUsuarios 
                        Where CodUsuario = '" & _Kofu & "' AND CodPermiso = '" & _CodPermiso & "'"

        Dim _Row_PermisosVsUsuarios As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql, False)

        Return Not (IsNothing(_Row_PermisosVsUsuarios))

    End Function


End Module
