Imports DevComponents.DotNetBar
Imports System.Windows.Forms

Public Class Frm_ValidarPermiso

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tiempo_Espera = 0
    Dim _Permiso_Aceptado As Boolean
    Dim _CodPermiso As String
    Dim _Mostrar_Mensaje_Autorizado As Boolean
    Dim _Teclado As Boolean
    Dim _RowUsuario As DataRow
    Dim _Cerrar_Automaticamente As Boolean
    Dim _Validar_Con_Huella As Boolean
    Dim _No_Necesita_Permiso_Supervisor As Boolean

    Enum Tipo_Accion
        Validar_Permiso
        Validar_Que_Exite_El_Usuario
    End Enum

    Dim _Tipo_Accion As Tipo_Accion

    Public Property Pro_Cerrar_Automaticamente As Boolean
        Get
            Return _Cerrar_Automaticamente
        End Get
        Set(value As Boolean)
            _Cerrar_Automaticamente = value
            If _Cerrar_Automaticamente Then
                Tiempo_Label.Enabled = True
            End If
        End Set
    End Property

    Public ReadOnly Property Pro_RowUsuario() As DataRow
        Get
            If _Permiso_Aceptado Then
                Return _RowUsuario
            Else
                Return Nothing
            End If
        End Get
        'Set(value As DataRow)
        '    'Pro_RowUsuario = value
        'End Set
    End Property

    Public Property Pro_Permiso_Aceptado() As Boolean
        Get
            Return _Permiso_Aceptado
        End Get
        Set(ByVal _Accion As Boolean)
            'labelName.Text = Value
        End Set
    End Property

    Public Property Tiempo_Espera As Object
        Get
            Return _Tiempo_Espera
        End Get
        Set(value As Object)
            _Tiempo_Espera = value
            Tiempo_Label.Interval = 1000 * 20
        End Set
    End Property

    Public Property Pro_Validar_Con_Huella As Boolean
        Get
            Return _Validar_Con_Huella
        End Get
        Set(value As Boolean)
            _Validar_Con_Huella = value
        End Set
    End Property

    Public Property No_Necesita_Permiso_Supervisor As Boolean
        Get
            Return _No_Necesita_Permiso_Supervisor
        End Get
        Set(value As Boolean)
            _No_Necesita_Permiso_Supervisor = value
        End Set
    End Property

    Public Sub New(ByVal Tipo_de_Accion As Tipo_Accion,
                   ByVal CodPermiso As String,
                   ByVal Mostrar_Mensaje_Autorizado As Boolean,
                   ByVal Validar_Con_Huella As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Tipo_Accion = Tipo_de_Accion
        _CodPermiso = CodPermiso
        _Mostrar_Mensaje_Autorizado = Mostrar_Mensaje_Autorizado

        _Validar_Con_Huella = Validar_Con_Huella
        Tiempo_Huella.Interval = 500
        Tiempo_Huella.Enabled = _Validar_Con_Huella

    End Sub

    Private Sub Frm_ValidarPermiso_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Enabled = Not _Validar_Con_Huella
        Btn_Validar_Con_Huella.Enabled = _Validar_Con_Huella
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        Sb_Validar_Usuario(Txtclave.Text, False)
    End Sub

    Sub Sb_Validar_Usuario(_Clave As String, _Codificada As Boolean)

        _Clave = Trim(_Clave)

        If Not _Codificada Then
            _Clave = TraeClaveRD(_Clave)
        End If

        If String.IsNullOrEmpty(_Clave) Then _Clave = "@@##"

        Consulta_sql = "Select top 1 * From TABFU Where PWFU = '" & _Clave & "'"
        _RowUsuario = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Kofu As String
        Dim _Nokofu As String

        If Not IsNothing(_RowUsuario) Then

            _Kofu = _RowUsuario.Item("KOFU")
            _Nokofu = _RowUsuario.Item("NOKOFU")

            If _Tipo_Accion = Tipo_Accion.Validar_Permiso Then

                If _Tipo_Accion = Tipo_Accion.Validar_Permiso Then

                    If Fx_Tiene_Permiso(Me, _CodPermiso, _Kofu, False) Then

                        If _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Configuracion", "Solo_Supervisores_Dan_Permisos") Then

                            If _Global_Row_Configuracion_General.Item("Solo_Supervisores_Dan_Permisos") And Not No_Necesita_Permiso_Supervisor Then

                                If Fx_Tiene_Permiso(Me, "Admin001", _Kofu, False) Then

                                    _Permiso_Aceptado = True

                                Else

                                    MessageBoxEx.Show(Me, "El usuario " & _Kofu.Trim & " - " & _Nokofu.Trim & " No esta autorizado a dar permisos remotos ni presenciales" & vbCrLf & vbCrLf &
                                                      "El sistema esta configurado para que solo usuarios Supervisores puedan otorgar permisos presenciales o remotos",
                                                      "No es un usuario Supervisor", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                                End If

                            Else

                                _Permiso_Aceptado = True

                            End If

                        Else

                            _Permiso_Aceptado = True

                        End If

                    Else

                        If _Mostrar_Mensaje_Autorizado Then

                            Dim _Nombre_Permiso As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "ZW_Permisos", "DescripcionPermiso", "CodPermiso = '" & _CodPermiso & "'")

                            _Nombre_Permiso = _Kofu & "-" & _Nokofu.Trim & vbCrLf & "No tienes el permiso: [" & _CodPermiso & "] - " & _Nombre_Permiso.Trim

                            MessageBoxEx.Show(Me, _Nombre_Permiso, "PERMISO DENEGADO", Windows.Forms.MessageBoxButtons.OK,
                                              Windows.Forms.MessageBoxIcon.Stop)

                        End If

                    End If

                ElseIf _Tipo_Accion = Tipo_Accion.Validar_Que_Exite_El_Usuario Then

                    _Permiso_Aceptado = True

                End If

            ElseIf _Tipo_Accion = Tipo_Accion.Validar_Que_Exite_El_Usuario Then

                _Permiso_Aceptado = True

            End If

        Else

            If Not String.IsNullOrEmpty(Trim(Txtclave.Text)) Then
                MessageBoxEx.Show(Me, "Usuario no existe", "Verificar permiso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            Txtclave.Text = String.Empty
            Txtclave.Focus()
            Return

        End If

        Me.Close()

    End Sub

    Private Sub Txtclave_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtclave.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            Sb_Validar_Usuario(Txtclave.Text, False)
        End If
    End Sub

    Private Sub Frm_ValidarPermiso_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
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
    End Sub

    Private Sub Tiempo_Label_Tick(sender As Object, e As EventArgs) Handles Tiempo_Label.Tick
        Me.Close()
    End Sub

    'Private Sub Btn_Validar_Con_Huella_Click(sender As Object, e As EventArgs) Handles Btn_Validar_Con_Huella.Click

    '    'Dim _Huella As String
    '    'Dim _Registrado As Boolean

    '    'Dim Fm As New Frm_Huella_Identificar(Me, _Huella, False, False, Frm_Huella_Identificar.Enum_Accion.Buscar_Huella)
    '    'If Fm.Pro_Conectado Then Fm.ShowDialog(Me)
    '    '_Registrado = Fm.Pro_Verificado
    '    'Dim _Row_Usuario As DataRow = Fm.Pro_Row_Usuario
    '    '_Huella = Fm.Pro_Huella
    '    'Fm.Dispose()

    '    Dim _Verificado As Boolean
    '    Dim _Graba_Sin_Huella As Boolean

    '    Dim Fm As New VerificationForm(Nothing)
    '    Fm.Cerrar_Al_Confirmar = True
    '    Fm.ShowDialog(Me)
    '    _Verificado = Fm.Verificado
    '    _Graba_Sin_Huella = Fm.Graba_Sin_Huella
    '    Dim _Row_Usuario As DataRow = Fm.Row_Usuario
    '    Fm.Dispose()

    '    If _Verificado Then
    '        Sb_Validar_Usuario(_Row_Usuario.Item("PWFU"), True)
    '        If _Validar_Con_Huella Then Me.Close()
    '    Else
    '        If _Graba_Sin_Huella Then
    '            If Fx_Tiene_Permiso(Me, _CodPermiso,,,,,,,,, _Row_Usuario) Then
    '                _Permiso_Aceptado = True
    '                _RowUsuario = _Row_Usuario
    '            Else
    '                _Permiso_Aceptado = False
    '            End If
    '        End If
    '    End If

    '    Me.Close()

    'End Sub

    Private Sub Tiempo_Huella_Tick(sender As Object, e As EventArgs) Handles Tiempo_Huella.Tick
        'Tiempo_Huella.Enabled = False
        'Call Btn_Validar_Con_Huella_Click(Nothing, Nothing)
    End Sub


End Class
