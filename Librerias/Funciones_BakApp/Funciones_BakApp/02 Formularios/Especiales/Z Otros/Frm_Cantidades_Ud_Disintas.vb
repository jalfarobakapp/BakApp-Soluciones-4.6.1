Imports System.Windows.Forms

Public Class Frm_Cantidades_Ud_Disintas
    Public _Rtu, _
           _Cantidad_Ud1, _
           _Cantidad_Ud2 As Double

    Public _UdTrans As Integer

    Private Sub Frm_SolicitudDeCompraCantProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'RTU = trae_dato(tb, cn1, "RLUD", "MAEPR", "KOPR = '" & CodigoRandom & "'")
        'RLUD = Math.Round((1 / RTU), 0)
        TxtRTU.Text = _Rtu
        ' _Rlud = Math.Round((1 / _Rlud), 0)

        If _Rtu = 1 Then TxtCantUD2.Enabled = False

        If _UdTrans = 1 Then
            TxtCantUD1.Text = _Cantidad_Ud1
            TxtCantUD2.Text = Math.Round(_Cantidad_Ud1 / _Rtu, 5)
            Me.ActiveControl = TxtCantUD1
        Else 'CantidadUnidad2 > 0 Then
            TxtCantUD2.Text = _Cantidad_Ud2
            TxtCantUD1.Text = Math.Round(_Cantidad_Ud2 * _Rtu, 5)
            Me.ActiveControl = TxtCantUD2
        End If

        

    End Sub



    Private Sub TxtCantUD2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantUD2.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            'If e.KeyChar = ChrW(Keys.Return) Then
            e.Handled = True

            TxtCantUD1.Text = Math.Round(Val(TxtCantUD2.Text) * _Rtu, 5)
            BtnAceptar.Focus()
            'MsgBox(Nivel1)
        ElseIf e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(".")
        End If
    End Sub
    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        CantidadPRUd1 = Math.Round(Val(TxtCantUD2.Text), 0)

        _Cantidad_Ud1 = De_Txt_a_Num_01(TxtCantUD1.Text, 5)
        _Cantidad_Ud2 = De_Txt_a_Num_01(TxtCantUD2.Text, 5)

        Me.Close()
    End Sub
    Private Sub TxtCantUD2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCantUD2.KeyDown
        If e.KeyValue = Keys.Up Then
            e.Handled = True
            TxtCantUD1.Focus()
        End If
    End Sub
    Private Sub TxtCantUD2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCantUD2.Leave
        TxtCantUD1.Text = Math.Round(De_Txt_a_Num_01(TxtCantUD2.Text, 3) * _Rtu, 5)
    End Sub


    Private Sub TxtCantUD1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCantUD1.KeyDown
        If e.KeyValue = Keys.Down Then
            e.Handled = True
            TxtCantUD2.Focus()
        End If
    End Sub

    Private Sub TxtCantUD1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantUD1.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            'If e.KeyChar = ChrW(Keys.Return) Then
            e.Handled = True

            Dim Ud2 As Double = Math.Round(Val(TxtCantUD1.Text) / _Rtu, 3)
            TxtCantUD2.Text = Ud2
            If TxtCantUD2.Enabled = True Then
                TxtCantUD2.Focus()
            Else
                BtnAceptar.Focus()
            End If
            'MsgBox(Nivel1)
        ElseIf e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(".")
        End If
    End Sub

    Private Sub TxtCantUD1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCantUD1.Leave
        TxtCantUD2.Text = Math.Round(De_Txt_a_Num_01(TxtCantUD1.Text, 3) / _Rtu, 3)
    End Sub
End Class