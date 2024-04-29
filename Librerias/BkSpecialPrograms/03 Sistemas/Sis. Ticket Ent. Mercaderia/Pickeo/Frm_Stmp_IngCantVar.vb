Imports DevComponents.DotNetBar

Public Class Frm_Stmp_IngCantVar

    Public Property Cantidad_Ud1 As Double
    Public Property Cantidad_Ud2 As Double
    Public Property Aceptar As Boolean

    Dim _CantUd1_Ori As Double
    Dim _CantUd2_Ori As Double

    Public Sub New(_CantUd1_Ori As Double, _CantUd2_Ori As Double)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._CantUd1_Ori = _CantUd1_Ori
        Me._CantUd2_Ori = _CantUd2_Ori

    End Sub

    Private Sub Frm_Stmp_IngCantVar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TxtCantUD1.Text = Cantidad_Ud1
        TxtCantUD2.Text = Cantidad_Ud2

        Me.ActiveControl = TxtCantUD1

    End Sub

    Private Sub TxtCantUD2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCantUD2.KeyDown
        If e.KeyValue = Keys.Up Then
            e.Handled = True
            TxtCantUD1.Focus()
        End If
    End Sub

    Private Sub TxtCantUD2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCantUD2.Leave
        TxtCantUD2.Text = Math.Round(_Cantidad_Ud2, 3)
    End Sub

    Private Sub TxtCantUD1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCantUD1.Leave
        TxtCantUD1.Text = Math.Round(_Cantidad_Ud1, 3)
    End Sub

    Private Sub TxtCantUD1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCantUD1.KeyDown
        If e.KeyValue = Keys.Down Then
            e.Handled = True
            TxtCantUD2.Focus()
        End If
    End Sub

    Private Sub TxtCantUD1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantUD1.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii, False))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            _Cantidad_Ud1 = Math.Round(De_Txt_a_Num_01(TxtCantUD1.Text, 5), 5)
            TxtCantUD2.Focus()

        ElseIf e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(".")
        End If

    End Sub

    Private Sub TxtCantUD2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantUD2.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii, False))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            _Cantidad_Ud2 = De_Txt_a_Num_01(TxtCantUD2.Text, 5)
            BtnAceptar.Focus()

        ElseIf e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(".")
        End If

    End Sub

    Private Sub TxtCantUD1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCantUD1.Enter
        TxtCantUD1.Text = Math.Round(_Cantidad_Ud1, 5)
    End Sub

    Private Sub TxtCantUD2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCantUD2.Enter
        TxtCantUD2.Text = Math.Round(_Cantidad_Ud2, 5)
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click

        If Cantidad_Ud1 > _CantUd1_Ori Or Cantidad_Ud2 > _CantUd2_Ori Then
            MessageBoxEx.Show(Me, "Las cantidades no pueden ser mayores a las cantidades originales" & vbCrLf & vbCrLf &
                              "Cantidad " & LblUnidad1.Text & ": " & _CantUd1_Ori & vbCrLf &
                              "Cantidad " & LblUnidad2.Text & ": " & _CantUd2_Ori,
                              "Validación, producto oferta", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TxtCantUD1.Focus()
            Return
        End If

        Aceptar = True
        Me.Close()

    End Sub

    Private Sub Frm_Stmp_IngCantVar_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
