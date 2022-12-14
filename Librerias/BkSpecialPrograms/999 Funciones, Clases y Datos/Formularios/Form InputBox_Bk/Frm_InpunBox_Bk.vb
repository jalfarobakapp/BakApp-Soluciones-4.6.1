Imports DevComponents.DotNetBar

Public Class Frm_InpunBox_Bk

    Dim _Nueva_Descripcion As String
    Dim _Imagen As String
    Dim _Aceptado As Boolean
    Dim _Permitir_En_Blanco As Boolean
    Dim _Permitir_Valor_Cero As Boolean
    Dim _Tipo_de_Caracter As _Tipo_Caracter

    Public Property Pro_Nueva_Descripcion As String
        Get
            Return _Nueva_Descripcion
        End Get
        Set(value As String)
            _Nueva_Descripcion = value
        End Set
    End Property

    Public Property Pro_Imagen As String
        Get
            Return _Imagen
        End Get
        Set(value As String)
            _Imagen = value
        End Set
    End Property

    Public Property Pro_Aceptado As Boolean
        Get
            Return _Aceptado
        End Get
        Set(value As Boolean)
            _Aceptado = value
        End Set
    End Property

    Public Property Pro_Permitir_En_Blanco As Boolean
        Get
            Return _Permitir_En_Blanco
        End Get
        Set(value As Boolean)
            _Permitir_En_Blanco = value
        End Set
    End Property

    Public Property Pro_Permitir_Valor_Cero As Boolean
        Get
            Return _Permitir_Valor_Cero
        End Get
        Set(value As Boolean)
            _Permitir_Valor_Cero = value
        End Set
    End Property

    Public Property Pro_Tipo_de_Caracter As _Tipo_Caracter
        Get
            Return _Tipo_de_Caracter
        End Get
        Set(value As _Tipo_Caracter)
            _Tipo_de_Caracter = value
        End Set
    End Property

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        Sb_Aceptar()
    End Sub

    Private Sub TxtDescripcion_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtDescripcion.KeyDown

        If TxtDescripcion.Multiline = False Then
            If e.KeyValue = Keys.Enter Then
                Sb_Aceptar()
            ElseIf e.KeyValue = Keys.Escape Then
                Me.Close()
            End If
        End If

    End Sub

    Sub Sb_Aceptar()

        _Nueva_Descripcion = TxtDescripcion.Text

        If _Nueva_Descripcion.Contains("'") Then
            MessageBoxEx.Show(Me, "Carácter no autorizado -> '" & vbCrLf &
                              "No puede usar comillas simples", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Not String.IsNullOrEmpty(_Nueva_Descripcion) Then

            If _Imagen = "Correo" Then

                _Nueva_Descripcion = Replace(_Nueva_Descripcion, ",", ";")

                For Each _Para As String In _Nueva_Descripcion.Split(New Char() {";"c})
                    If Not Fx_Validar_Email(_Para) Then
                        MessageBoxEx.Show(Me, _Para & vbCrLf & "No es una cuenta de correos valida", "Validación",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        TxtDescripcion.Focus()
                        Return
                    End If
                Next

            End If

        End If


        If String.IsNullOrEmpty(Trim(_Nueva_Descripcion)) Then

            If _Permitir_En_Blanco Then
                _Aceptado = True
            Else
                MessageBoxEx.Show(Me, "La descripción no puede estar vacía", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TxtDescripcion.Focus()
            End If

        ElseIf Val(TxtDescripcion.Text) = 0 Then

            If _Permitir_Valor_Cero Then
                _Aceptado = True
            Else
                MessageBoxEx.Show(Me, "No se permite valor cero", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TxtDescripcion.Focus()
            End If

        Else
            _Aceptado = True
        End If

        If _Aceptado Then
            Me.Close()
        End If

    End Sub

    Private Sub Frm_InpunBox_Bk_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        If Global_Thema = Enum_Themas.Oscuro Then
            Rf_Imagen.Image = Imagenes_48x48_Dark.Images.Item(_Imagen)
        Else
            Rf_Imagen.Image = Imagenes_48x48_Ligth.Images.Item(_Imagen)
        End If

        Dim _x = Me.Location.X
        Dim _Y = Me.Location.Y
        Dim _H = Me.Height
        Dim _Ancho_Teclado = TouchKeyboard1.Size.Width
        Dim _Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
        Dim _Left = (Screen.PrimaryScreen.WorkingArea.Width - _Ancho_Teclado) / 2

        Me.TouchKeyboard1.FloatingLocation = New System.Drawing.Point(_Left, _Y + _H)
        If _Global_Es_Touch Then
            TouchKeyboard1.SetShowTouchKeyboard(TxtDescripcion, DevComponents.DotNetBar.Keyboard.TouchKeyboardStyle.Floating)
        End If

        If _Tipo_de_Caracter = _Tipo_Caracter.Moneda Then
            AddHandler TxtDescripcion.KeyPress, AddressOf Sb_Monedas
        ElseIf _Tipo_de_Caracter = _Tipo_Caracter.Solo_Numeros_Enteros Then
            AddHandler TxtDescripcion.KeyPress, AddressOf Sb_Solo_Numeros_Enteros
        End If

    End Sub

    Private Sub Frm_InpunBox_Bk_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub Sb_Monedas(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            'If e.KeyChar = ChrW(Keys.Return) Then
            e.Handled = True
        ElseIf e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(".")
        ElseIf e.KeyChar = "-"c Then
            e.Handled = True
            SendKeys.Send("")
        End If
    End Sub

    Private Sub Sb_Solo_Numeros_Enteros(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumerosSinPuntosNiComas(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

End Class
