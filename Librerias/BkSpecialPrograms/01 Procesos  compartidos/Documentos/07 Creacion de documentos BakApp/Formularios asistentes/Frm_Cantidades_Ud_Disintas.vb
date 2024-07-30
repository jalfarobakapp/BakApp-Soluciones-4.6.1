Imports System.Windows.Forms
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls


Public Class Frm_Cantidades_Ud_Disintas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim Fr_Alerta_Stock As DevComponents.DotNetBar.Balloon

    Dim _Codigo As String
    Dim _Rtu As Double
    Dim _UnTrans As Integer
    Dim _Cantidad_Original As Double

    Dim _Fila As DataGridViewRow
    Dim _RowProducto As DataRow

    Public Property RevisarRtuVariable As Boolean
    Public Property RtuVariable As Boolean
    Public Property Cantidad_Ud1 As Double
    Public Property Cantidad_Ud2 As Double
    Public Property Aceptado As Boolean


    Public Sub New(Fila As DataGridViewRow)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Fila = Fila

        _Codigo = _Fila.Cells("Codigo").Value 'Codigo
        _Rtu = _Fila.Cells("Rtu").Value 'Rtu
        _UnTrans = _Fila.Cells("UnTrans").Value 'UdTrans

        Consulta_sql = "Select Top 1 KOPR,NOKOPR,RLUD,DIVISIBLE,DIVISIBLE2,NMARCA From MAEPR Where KOPR = '" & _Codigo & "'"
        _RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

        Fr_Alerta_Stock = New AlertCustom(_Codigo, _UnTrans)

        If Global_Thema = Enum_Themas.Oscuro Then
            TxtCantUD1.FocusHighlightEnabled = False
            TxtCantUD2.FocusHighlightEnabled = False
        End If

    End Sub

    Private Sub Frm_SolicitudDeCompraCantProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TxtRTU.Text = _Rtu

        If RevisarRtuVariable Then

            If _Fila.Cells("Nmarca").Value = "¡" Then

                Dim _Cl_Producto As Cl_Producto = New Cl_Producto()
                _Cl_Producto.Fx_Llenar_Zw_Producto(_Codigo)

                If Not _Cl_Producto.Zw_Producto.RtuXWms Then

                    Chk_RtuVariable.Checked = RtuVariable

                    If Not RtuVariable AndAlso Not CBool(Cantidad_Ud1) AndAlso Not CBool(Cantidad_Ud2) Then
                        Chk_RtuVariable.Checked = True
                    End If

                End If

            End If

        End If

        Chk_RtuVariable.Enabled = (_Fila.Cells("Nmarca").Value = "¡")

        If Chk_RtuVariable.Checked Then
            Label3.Text = "R.T.U.  (" & _Rtu & ")"
        End If

        If _Rtu = 1 Then TxtCantUD2.Enabled = False

        If _UnTrans = 1 Then
            TxtCantUD1.Text = Cantidad_Ud1
            TxtCantUD2.Text = Math.Round(Cantidad_Ud1 / _Rtu, 3)
            Me.ActiveControl = TxtCantUD1
        Else
            TxtCantUD2.Text = Cantidad_Ud2
            TxtCantUD1.Text = Math.Round(Cantidad_Ud2 * _Rtu, 3)
            Me.ActiveControl = TxtCantUD2
        End If

        If RtuVariable Then
            TxtCantUD1.Text = Math.Round(Cantidad_Ud1, 3)
            TxtCantUD2.Text = Math.Round(Cantidad_Ud2, 3)
        End If

        _Cantidad_Original = _Fila.Cells("CantUd" & _UnTrans & "_Dori").Value

        TxtCantUD1.Tag = _Cantidad_Ud1
        TxtCantUD2.Tag = _Cantidad_Ud2

        Sb_Ver_Alerta_Stock()

    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click

        Fr_Alerta_Stock.Close()

        Dim _Oferta = _Fila.Cells("Oferta").Value
        Dim _Padre_Oferta = _Fila.Cells("Padre_Oferta").Value
        Dim _Cantidad_Oferta = _Fila.Cells("Cantidad_Oferta").Value
        Dim _Aplica_Oferta = _Fila.Cells("Aplica_Oferta").Value
        Dim _Rtu = _Fila.Cells("Rtu").Value

        If _Cantidad_Ud1 <> 0 Then

            If Fx_Solo_Enteros(_Cantidad_Ud1, _RowProducto.Item("DIVISIBLE")) Then
                MessageBoxEx.Show(Me, "Primera Unidad solo permite cantidades enteras", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TxtCantUD1.Focus()
                Return
            End If

            If Fx_Solo_Enteros(_Cantidad_Ud2, _RowProducto.Item("DIVISIBLE2")) Then
                MessageBoxEx.Show(Me, "Segunda Unidad solo permite cantidades enteras", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TxtCantUD2.Focus()
                Return
            End If

        End If

        If _Aplica_Oferta Then

            Dim _Cantidad As Double
            Dim _Txt As TextBoxX

            If _UnTrans = 1 Then
                _Cantidad = _Cantidad_Ud1 / _Cantidad_Oferta
                _Txt = TxtCantUD1
            Else
                _Cantidad = (_Cantidad_Ud2 * _Rtu) / _Cantidad_Oferta
                _Txt = TxtCantUD2
            End If

            Dim _Volver As Boolean

            If _Cantidad = 0 Then

                MessageBoxEx.Show(Me, "La cantidad no puede ser 0 cuando el producto es una oferta", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _Volver = True

            End If

            If IsNumeric(_Cantidad) Then

                If CInt(_Cantidad) <> _Cantidad Then

                    MessageBoxEx.Show(Me, "La cantidad debe ser multiplo de " & _Cantidad_Oferta, "Validación, producto oferta",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    _Volver = True

                End If

            End If

            Dim _Idmaeddo_Dori As Integer = _Fila.Cells("Idmaeddo_Dori").Value

            If _Txt.Text > _Cantidad_Original And CBool(_Idmaeddo_Dori) Then
                MessageBoxEx.Show(Me, "La cantidad no puede ser mayor a " & FormatNumber(_Cantidad_Original, 0),
                                  "Validación, producto oferta", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _Volver = True
            End If

            If _Volver Then

                _Cantidad_Ud1 = TxtCantUD1.Tag
                _Cantidad_Ud2 = TxtCantUD2.Tag

                TxtCantUD1.Text = TxtCantUD1.Tag
                TxtCantUD2.Text = TxtCantUD2.Tag

                _Txt.Focus()

                Return

            End If

        End If

        _Aceptado = True
        RtuVariable = Chk_RtuVariable.Checked

        Me.Close()

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

            Dim _C1 As Double = Math.Round(De_Txt_a_Num_01(TxtCantUD1.Text, 5), 5)

            If Chk_RtuVariable.Checked Then

                _Cantidad_Ud1 = _C1

                Try
                    TxtRTU.Text = _Cantidad_Ud1 / _Cantidad_Ud2
                Catch ex As Exception
                    TxtRTU.Text = 0
                End Try

                TxtCantUD2.Focus()

            Else

                e.Handled = True

                If _C1 <> _Cantidad_Ud1 Then
                    _Cantidad_Ud1 = _C1
                    _Cantidad_Ud2 = Math.Round(_Cantidad_Ud1 / _Rtu, 5)

                    TxtCantUD2.Text = Math.Round(_Cantidad_Ud2, 3)
                End If

                BtnAceptar.Focus()

            End If

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

            Dim _C2 As Double = De_Txt_a_Num_01(TxtCantUD2.Text, 5)

            If Chk_RtuVariable.Checked Then

                _Cantidad_Ud2 = _C2

                Try
                    TxtRTU.Text = _Cantidad_Ud1 / _Cantidad_Ud2
                Catch ex As Exception
                    TxtRTU.Text = 0
                End Try

            Else

                e.Handled = True

                If _C2 <> _Cantidad_Ud2 Then
                    _Cantidad_Ud2 = _C2
                    _Cantidad_Ud1 = Math.Round(_Cantidad_Ud2 * _Rtu, 5)
                    TxtCantUD1.Text = Math.Round(_Cantidad_Ud1, 3)
                End If

            End If

            BtnAceptar.Focus()

        ElseIf e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(".")
        End If

    End Sub

    Private Sub TxtCantUD1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCantUD1.Enter
        _UnTrans = 1
        TxtCantUD1.Text = Math.Round(_Cantidad_Ud1, 5)
    End Sub

    Private Sub TxtCantUD2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCantUD2.Enter
        _UnTrans = 2
        TxtCantUD2.Text = Math.Round(_Cantidad_Ud2, 5)
    End Sub

    Private Sub Btn_Ver_Stock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Stock.Click
        Sb_Ver_Alerta_Stock()
    End Sub

    Sub Sb_Ver_Alerta_Stock()

        If Fr_Alerta_Stock.Visible Then
            Fr_Alerta_Stock.Close()
        End If

        Fr_Alerta_Stock = New AlertCustom(_Codigo, _UnTrans)
        ShowLoadAlert(Fr_Alerta_Stock, Me)

    End Sub

End Class
