Imports System.Windows.Forms
Imports DevComponents.DotNetBar

Public Class Frm_InpunBox_Bk

    Public _Nueva_Descripcion As String
    Public _Imagen As String
    Public _Cancelado As Boolean
    Public _Permitir_En_Blanco As Boolean
    Public _Permitir_Valor_Cero As Boolean

   

    Public _Tipo_de_Caracter As _Tipo_Caracter

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        Sb_Aceptar()
    End Sub

    Private Sub TxtDescripcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDescripcion.KeyDown

        If TxtDescripcion.Multiline = False Then
            If e.KeyValue = Keys.Enter Then
                Sb_Aceptar()
            ElseIf e.KeyValue = Keys.Escape Then
                _Cancelado = True
                Me.Close()
            End If
        End If

    End Sub

    Sub Sb_Aceptar()
        _Nueva_Descripcion = TxtDescripcion.Text

        If _Imagen = "Correo" Then
            If Not Fx_Validar_Email(_Nueva_Descripcion) Then
                MessageBoxEx.Show(Me, "No es una cuenta de correos valida", "Validación", _
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TxtDescripcion.Focus()
                Return
            End If
        End If

        If String.IsNullOrEmpty(Trim(_Nueva_Descripcion)) Then
            If _Permitir_En_Blanco Then
                Me.Close()
            Else
                MessageBoxEx.Show(Me, "La descripción no puede estar vacía", "Validación", _
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TxtDescripcion.Focus()
            End If
        ElseIf Val(TxtDescripcion.Text) = 0 Then
            If _Permitir_Valor_Cero Then
                Me.Close()
            Else
                MessageBoxEx.Show(Me, "No se permite valor cero", "Validación", _
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TxtDescripcion.Focus()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub Frm_InpunBox_Bk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

         Rf_Imagen.Image = ImageList1.Images.Item(_Imagen)

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

    Private Sub Frm_InpunBox_Bk_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            _Cancelado = True
            Me.Close()
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        _Cancelado = True
        Me.Close()
    End Sub


    Private Sub Sb_Monedas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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


    Private Sub Sb_Solo_Numeros_Enteros(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumerosSinPuntosNiComas(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

End Class