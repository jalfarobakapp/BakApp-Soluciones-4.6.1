'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Clave_Administrador

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Autorizado As Boolean
    Dim _Teclado As Boolean
    Dim _Tiempo_Espera = 0
    Dim _Cerrar_Si_No_Existe As Boolean

    Public ReadOnly Property Pro_Autorizado() As Boolean
        Get
            Return _Autorizado
        End Get
    End Property

    Public Sub New(Optional ByVal Cerrar_Si_No_Existe As Boolean = False)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Cerrar_Si_No_Existe = Cerrar_Si_No_Existe

    End Sub

    Private Sub Frm_Clave_Administrador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ActiveControl = Txtclave
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

    Private Sub Txtclave_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtclave.KeyDown

        If e.KeyValue = Keys.Enter Then
            Call BtnAceptar_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        _Autorizado = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "ZW_PermisosADM", _
                                        "ClaveAdministrador = '" & Encripta_md5(Txtclave.Text) & "'"))

        Dim Encriptado As String = Trim(Encripta_md5(Txtclave.Text))

        If Not _Autorizado Then
            If _Cerrar_Si_No_Existe Then
                Me.Close()
            Else
                MessageBoxEx.Show(Me, "Clave de acceso no autorizado", "Validación", _
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txtclave.SelectAll()
                Txtclave.Focus()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub Frm_Clave_Administrador_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Teclado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Teclado.Click
        If _Teclado Then
            Fx_Activar_Deactivar_Teclado(False)
            _Teclado = False
        Else
            Fx_Activar_Deactivar_Teclado(True)
            _Teclado = True
        End If
    End Sub

    Private Sub Tiempo_Label_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tiempo_Label.Tick
        If _Tiempo_Espera = 10 Then
            Me.Close()
        End If

        _Tiempo_Espera += 1
    End Sub
End Class