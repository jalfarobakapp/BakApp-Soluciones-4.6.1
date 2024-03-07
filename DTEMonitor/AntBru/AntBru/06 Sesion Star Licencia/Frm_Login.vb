Imports DevComponents.DotNetBar


Public Class Frm_Login

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    'Dim _CancelarLogin As Boolean
    'Dim _UsuarioActivado As Boolean
    'Dim _RowUsuario As DataRow
    'Dim _AccesoAdministrador As String
    Dim _Teclado As Boolean

    Public Property RowUsuario As DataRow
    Public Property Aceptar As Boolean
    Public Property UsuarioActivado As Boolean
    Public Property CancelarLogin As Boolean
    Public Property AccesoAdministrador As String
    Public Property ValidarPermiso As Boolean
    Public Property Permiso As String

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

    End Sub

    Private Sub TxtxPassword_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtxPassword.TextChanged
        If Trim(TxtxPassword.Text) = "" Then Return
        Txtxusuario.Text = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "PWFU = '" &
                  TraeClaveRD(TxtxPassword.Text) & "'")
        If Txtxusuario.Text <> "" Then
            BtnxAceptar.Enabled = True
        Else
            BtnxAceptar.Enabled = False
        End If
    End Sub

    Private Sub BtnxAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnxAceptar.Click

        Dim _ClaveCorrecta As Boolean

        If Fx_Autentificar_Usuario_Pass_Codificada(TxtxPassword.Text, Txtxusuario.Text, _ClaveCorrecta) Then

            If Fx_Sesion_Star(Me, FUNCIONARIO, Nombre_funcionario_activo) Then

                Nombre_funcionario_activo = Txtxusuario.Text
                _Global_Sesion = True
                UsuarioActivado = True
                CancelarLogin = False
                AccesoAdministrador = False
                Aceptar = True
                Me.Close()

            Else

                TxtxPassword.Focus()

            End If

        End If

        If Not _ClaveCorrecta Then
            MessageBoxEx.Show(Me, "Clave desconocida", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            _Global_Sesion = False
        End If

    End Sub

    Public Function Fx_Autentificar_Usuario_Decodificada(_Pwfu As String,
                                                         _Usuario As String) As Boolean

        If Not String.IsNullOrEmpty(_Usuario) Then

            Consulta_sql = "Select * From TABFU Where PWFU = '" & _Pwfu & "'"
            _RowUsuario = _Sql.Fx_Get_DataRow(Consulta_sql)

            FUNCIONARIO = _RowUsuario.Item("KOFU") '_Sql.Fx_Trae_Dato("TABFU", "KOFU", "PWFU = '" & TraeClaveRD(_Pass) & "'")
            Nombre_funcionario_activo = _RowUsuario.Item("NOKOFU") '_Sql.Fx_Trae_Dato(, "NOKOFU", "TABFU", "PWFU = '" & TraeClaveRD(_Usuario) & "'")

            Dim inactivo As Boolean = _RowUsuario.Item("INACTIVO") '_Sql.Fx_Trae_Dato(, "INACTIVO", "TABFU", "PWFU = '" & TraeClaveRD(_Pass) & "'")

            If inactivo = True Then
                MessageBoxEx.Show(Me, "Usuario Inactivo en Sistema", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _RowUsuario = Nothing
            Else
                Return True
            End If

        Else
            _RowUsuario = Nothing
            Return False
        End If

    End Function

    Public Function Fx_Autentificar_Usuario_Pass_Codificada(_Pass_Codificada As String,
                                                            _Usuario As String,
                                                            ByRef _ClaveCorrecta As Boolean) As Boolean

        If Not String.IsNullOrEmpty(_Usuario) Then

            Dim _Pwfu = TraeClaveRD(_Pass_Codificada)

            Consulta_sql = "Select * From TABFU Where PWFU = '" & _Pwfu & "'"
            _RowUsuario = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_RowUsuario) Then
                _ClaveCorrecta = True
            End If

            Dim inactivo As Boolean = _RowUsuario.Item("INACTIVO")

            If inactivo = True Then
                MessageBoxEx.Show(Me, "Usuario Inactivo en Sistema", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _RowUsuario = Nothing
                Return False
            End If

            If ValidarPermiso Then
                If Not Fx_Tiene_Permiso(Me, Permiso, _RowUsuario.Item("KOFU"),, False,,,, False, True) Then
                    _RowUsuario = Nothing
                    Return False
                End If
            End If

            If Not Fx_ValidarSiTieneModalidades(_RowUsuario.Item("KOFU")) Then
                Return False
            End If

            FUNCIONARIO = _RowUsuario.Item("KOFU")
            Nombre_funcionario_activo = _RowUsuario.Item("NOKOFU")

        Else
            _RowUsuario = Nothing
            Return False
        End If

        Return True

    End Function


    Private Sub BtnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancelar.Click

        If Not AccesoAdministrador Then

            If Not _Global_Sesion Then

                CancelarLogin = False

            Else

                CancelarLogin = True

            End If

            RowUsuario = Nothing

        End If

        Me.Close()

    End Sub

    Private Sub TxtxPassword_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtxPassword.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            BtnxAceptar.Focus()
            'Aceptar()
            'SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_Login_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Normal
        Me.StartPosition = FormStartPosition.CenterScreen
        TxtxPassword.Focus()
    End Sub

    Function Fx_Activar_Deactivar_Teclado(_Teclado As Boolean)
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

    Private Sub Btn_Teclado_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Teclado.Click
        If _Teclado Then
            Fx_Activar_Deactivar_Teclado(False)
            _Teclado = False
        Else
            Fx_Activar_Deactivar_Teclado(True)
            _Teclado = True
        End If
    End Sub

    Public Function Fx_Sesion_Star(_Formulario As Form,
                                   _CodUsuario As String,
                                   _NomUsuario As String) As Boolean

        Dim _Row_Nom_Equipo As DataRow
        Dim _Dir_Local As String = Application.StartupPath & "\Data\" '"Configuracion_Local"

        Dim _RutEmpresa01 As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Empresas", "Rut", "Empresa = '01'").ToString.Trim

        Dim _Nombre_Equipo As String = My.Computer.Name
        If Fx_Revisar_Nombre_Equipo_BakApp(_Formulario,
                                               _Dir_Local & _RutEmpresa01 & "\Configuracion_Local", _RutEmpresa01, _Nombre_Equipo) Then

            Dim _Ds As New DatosBakApp
            _Ds.Clear()
            _Ds.ReadXml(_Dir_Local & _RutEmpresa01 & "\Configuracion_Local\Nombre_Equipo.xml")

            _Row_Nom_Equipo = _Ds.Tables("Tbl_Nombre_Equipo").Rows(0)
        Else
            Return False
        End If

        Dim _Mi_IP '= getIp()
        _Nombre_Equipo = _Row_Nom_Equipo.Item("Nombre_Equipo")

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_EstacionesBkp Where NombreEquipo = '" & _Nombre_Equipo & "'"
        _Global_Row_EstacionBk = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not (_Global_Row_EstacionBk Is Nothing) Then

            'Dim _RutEmpresa01 As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Empresas", "Rut", "Empresa = '01'")

            Dim _Cadena_Base As String =
            UCase(Trim(_RutEmpresa01) & "@" & Trim(_Global_Row_EstacionBk.Item("NombreEquipo")))

            Dim _Key_Base = Encripta_md5(_Cadena_Base)

            Dim _Cadena As String = UCase(Trim(_RutEmpresa01) & "@" & _Nombre_Equipo)
            Dim _KeyReg = _Global_Row_EstacionBk.Item("KeyReg")

            If _KeyReg = _Key_Base Then

                Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Licencia Where Rut = '" & _RutEmpresa01 & "'"
                Dim _TblLicencia As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                If CBool(_TblLicencia.Rows.Count) Then
                    With _TblLicencia.Rows(0)

                        Dim _Rut = .Item("Rut")
                        Dim _Fecha_caduca As Date = .Item("Fecha_caduca")
                        Dim _Cant_licencias As Integer = .Item("Cant_licencias")
                        Dim _Libre = .Item("Libre")


                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set Conectado = 0," & vbCrLf &
                                       "IpEstacion = ''," & vbCrLf &
                                       "Fecha_Hora_Conec = Null" & vbCrLf &
                                       "Where NombreEquipo = '" & _Nombre_Equipo & "'"
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_EstacionesBkp", "Conectado = 1")

                        If _Libre Then _Cant_licencias = 2

                        If _Reg >= _Cant_licencias Then

                            Dim _Nombre_Empresa As String = _Sql.Fx_Trae_Dato("CONFIGP", "RAZON", "EMPRESA = '" & ModEmpresa & "'")

                            MessageBoxEx.Show(_Formulario, "Superada la cantidad de usuarios conectados al sistema, empresa: " & _Nombre_Empresa & vbCrLf &
                                              "Para poder seguir debe cerrar una sesión o bien contactarse con" & vbCrLf &
                                              "BakApp Soluciones para adquirir más licencias",
                                              "Limite de usuarios (" & _Cant_licencias & ")",
                                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

                            Return False

                        Else
                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set Conectado = 1," & vbCrLf &
                                           "IpEstacion = '" & _Mi_IP & "'," & vbCrLf &
                                           "Fecha_Hora_Conec = Getdate()," & vbCrLf &
                                           "CodUsuario = '" & _CodUsuario & "'," & vbCrLf &
                                           "NomUsuario = '" & Trim(_NomUsuario) & "'," & vbCrLf &
                                           "Version = '" & _Global_Version_BakApp & "'" & vbCrLf &
                                           "Where NombreEquipo = '" & _Nombre_Equipo & "'"

                            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                                Return False
                                ' End
                            End If
                        End If
                    End With
                End If

            Else
                MessageBoxEx.Show(Me, "Problemas con el registro de esta estación", "Validación",
                             MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_EstacionesBkp" & vbCrLf &
                               "Where NombreEquipo = '" & _Nombre_Equipo & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Return False

            End If
        Else

            'Dim Fm As New Frm_RegistrarEquipo(Frm_RegistrarEquipo.Enum_Accion.Nuevo, 0, False)
            'Fm.Pro_Nombre_Equipo = _Nombre_Equipo
            'Fm.ShowDialog(_Formulario)
            'Fm.Dispose()

            MessageBoxEx.Show(_Formulario, "Problemas con el registro de esta estación", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            'End
            Return False
        End If

        Return True

    End Function

    Function Fx_ValidarSiTieneModalidades(_Kofu As String) As Boolean

        Consulta_sql = "Select Distinct Ce.EMPRESA As Padre,Ce.EMPRESA+' - '+Cp.RAZON As Hijo
                        Into #Paso
                        From CONFIEST Ce
                        Inner Join CONFIGP Cp On Cp.EMPRESA = Ce.EMPRESA 
                        Where MODALIDAD <> '  '
                        Order by Ce.EMPRESA

                        Select Ce.EMPRESA,Cp.RAZON,'MO-' + MODALIDAD As PERMISO,MODALIDAD,Ts.NOKOSU,Tb.NOKOBO,ESUCURSAL,EBODEGA,ECAJA,ELISTAVEN,
                               NLISTAVEN,ELISTACOM,NLISTACOM,ELISTAINT,NLISTAINT
                        Into #Paso1
                        From CONFIEST Ce
                        Inner Join CONFIGP Cp On Cp.EMPRESA = Ce.EMPRESA 
                        Left Join TABSU Ts On Ts.EMPRESA = Ce.EMPRESA And Ts.KOSU = Ce.ESUCURSAL
                        Left Join TABBO Tb On Tb.EMPRESA = Ce.EMPRESA And Tb.KOSU = Ce.ESUCURSAL And Tb.KOBO = Ce.EBODEGA
                        Where MODALIDAD <> '  '
                        Order by Ce.EMPRESA,MODALIDAD

                        Select * From #Paso
                        Where Padre In (Select EMPRESA From #Paso1
                        Where PERMISO In (Select KOOP From MAEUS Where KOUS = '" & _Kofu & "' And KOOP Like 'MO-%'))

                        --Select * From #Paso1
                        --Where PERMISO In (Select KOOP From MAEUS Where KOUS = '" & _Kofu & "' And KOOP Like 'MO-%')

                        Drop Table #Paso
                        Drop Table #Paso1"

        Dim _Tbl_Modalidades As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If Not CBool(_Tbl_Modalidades.Rows.Count) Then

            MessageBoxEx.Show(Me, "El usuario no tiene modalidades asociadas." & vbCrLf &
                              "Informe de esta situación al administrador del sistema." & vbCrLf &
                              "El usuario debe tener por lo menos permiso para poder usar una modalidad en el sistema Random",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Return False

        End If

        Return True

    End Function

End Class
