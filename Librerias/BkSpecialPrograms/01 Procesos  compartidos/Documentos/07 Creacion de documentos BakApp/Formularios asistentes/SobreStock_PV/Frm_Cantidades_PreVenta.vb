Imports DevComponents.DotNetBar

Public Class Frm_Cantidades_PreVenta

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    'Public Property Zw_PreVenta_StockProd As Zw_PreVenta_StockProd
    Public Property Codigo As String
    Public Property Rtu As Double
    Public Property Rtu_Ori As Double
    Public Property UnTrans As Integer
    Public Property Cantidad As Double
    Public Property Cantidad_Original As Double
    Public Property Tido As String
    Public Property RevisarRtuVariable As Boolean
    Public Property FormatoPqte As String
    Public Property Cantidad_Pqte As Double
    Public Property Cantidad_Ud1 As Double
    Public Property Cantidad_Ud2 As Double
    Public Property CantMinFormato As Double
    Public Property PqteDisponible As Double
    Public Property Ud1XPqte As Double
    Public Property Aceptado As Boolean
    Public Property CantidadDisponible As Double
    Public Property PrecioXUd1 As Double
    Public Property Precio_DigSobreStock As Double

    Private _RowProducto As DataRow
    Private _Fr_Alerta_Stock As New DevComponents.DotNetBar.Balloon

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Cantidades_PreVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Consulta_sql = "Select Top 1 KOPR,NOKOPR,RLUD,DIVISIBLE,DIVISIBLE2,NMARCA,UD01PR,UD02PR From MAEPR Where KOPR = '" & Codigo & "'"
        _RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

        Txt_RTU.Text = _Rtu

        Dim _ValidarApiWMSBosOne As Boolean = False
        Dim _RtuVariable As Boolean = False

        Txt_CantidadPreVenta.Text = Cantidad ' Zw_PreVenta_StockProd.Cantidad
        Txt_CantidadPreVenta.Tag = Cantidad ' Zw_PreVenta_StockProd.Cantidad

        DInput_PrecioXUd1.Value = Precio_DigSobreStock

        If RevisarRtuVariable Then

            If _RowProducto.Item("NMARCA").Value = "¡" Then

                Dim _Cl_Producto As Cl_Producto = New Cl_Producto()
                _Cl_Producto.Fx_Llenar_Zw_Producto(_Codigo)

                _RtuVariable = True

                'If Not _Cl_Producto.Zw_Producto.RtuXWms Then

                '    Chk_RtuVariable.Checked = RtuVariable

                '    If Not RtuVariable AndAlso Not CBool(Cantidad_Ud1) AndAlso Not CBool(Cantidad_Ud2) Then
                '        Chk_RtuVariable.Checked = True
                '    End If

                'End If

                _ValidarApiWMSBosOne = True

                Dim _Habpesovariable As Boolean = CBool(_Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones", "Valor",
                                                        "Tabla = 'BODONE_CONF' And CodigoTabla = 'Habpesovariable'", True, False, 0))

                If Not _Habpesovariable Then
                    _ValidarApiWMSBosOne = False
                End If

                'If RtuVariable And Chk_DesacRazTransf.Checked Then
                '    Chk_DesacRazTransf.Enabled = False
                'End If

            End If

        End If

        Txt_CantidadDisponible.Text = FormatNumber(PqteDisponible, 0)
        Txt_Ud1XPqte.Text = FormatNumber(Ud1XPqte, 0)
        Txt_CantMinFormato.Text = CantMinFormato

        Img_RtuAPI.Visible = _ValidarApiWMSBosOne
        'TxtCantUD1.Enabled = Chk_DesacRazTransf.Checked

        'Chk_RtuVariable.Enabled = (_Fila.Cells("Nmarca").Value = "¡")

        _Cantidad_Ud1 = Cantidad * Ud1XPqte
        _Cantidad_Ud2 = Math.Round(_Cantidad_Ud1 / _Rtu, 5)

        If Chk_DesacRazTransf.Checked Then
            Lbl_Rtu.Text = "R.T.U.  (" & _Rtu & ")"
        End If

        If _Rtu = 1 Then Txt_CantUD2.Enabled = False

        If _UnTrans = 1 Then
            Txt_CantUD1.Text = Cantidad_Ud1
            Txt_CantUD2.Text = Math.Round(Cantidad_Ud1 / _Rtu, 3)
            Me.ActiveControl = Txt_CantUD1
        Else
            Txt_CantUD2.Text = Cantidad_Ud2
            Txt_CantUD1.Text = Math.Round(Cantidad_Ud2 * _Rtu, 3)
            Me.ActiveControl = Txt_CantUD2
        End If

        If Not Txt_CantUD1.Enabled Then
            Txt_CantUD2.Text = Cantidad_Ud2
            Txt_CantUD1.Text = Math.Round(Cantidad_Ud2 * _Rtu, 3)
            Me.ActiveControl = Txt_CantUD2
        End If

        If _RtuVariable Then
            Txt_CantUD1.Text = Math.Round(Cantidad_Ud1, 3)
            Txt_CantUD2.Text = Math.Round(Cantidad_Ud2, 3)
        End If

        _Cantidad_Original = Cantidad '_Fila.Cells("CantUd" & _UnTrans & "_Dori").Value

        Txt_CantUD1.Tag = _Cantidad_Ud1
        Txt_CantUD2.Tag = _Cantidad_Ud2

        'Sb_Ver_Alerta_Stock()

        'If _ValidarApiWMSBosOne And Not Chk_DesacRazTransf.Checked Then
        '    Sb_Rtu_WMSBodOne()
        'End If

        ActiveControl = Txt_CantidadPreVenta

        Me.Refresh()

    End Sub

    'Sub Sb_Ver_Alerta_Stock()

    '    If _Fr_Alerta_Stock.Visible Then
    '        _Fr_Alerta_Stock.Close()
    '    End If

    '    _Fr_Alerta_Stock = New AlertCustom(_Codigo, _UnTrans)
    '    CType(_Fr_Alerta_Stock, AlertCustom).Tido = _Tido
    '    ShowLoadAlert(_Fr_Alerta_Stock, Me,,,, True, Zw_PreVenta_StockProd.IdCont)

    'End Sub

    'Private Sub Btn_VerStock_Click(sender As Object, e As EventArgs) Handles Btn_VerStock.Click
    '    Sb_Ver_Alerta_Stock()
    'End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click

        If Cantidad_Ud1 <= 0 Then
            MessageBoxEx.Show(Me, "La cantidad no puede ser cero o negativa", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_CantidadPreVenta.SelectAll()
            Txt_CantidadPreVenta.Focus()
            Return
        End If


        If Txt_CantidadPreVenta.Tag < CantMinFormato Then
            MessageBoxEx.Show(Me, "La cantidad mínima para la venta es de " & CantMinFormato & " " & FormatoPqte,
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_CantidadPreVenta.SelectAll()
            Txt_CantidadPreVenta.Focus()
            Return
        End If

        'If Fx_Solo_Enteros(_Cantidad_Ud1, _RowProducto.Item("DIVISIBLE")) Then
        '    MessageBoxEx.Show(Me, "Primera Unidad solo permite cantidades enteras", "Validación",
        '                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Txt_CantUD1.Focus()
        '    Return
        'End If

        'If Fx_Solo_Enteros(_Cantidad_Ud2, _RowProducto.Item("DIVISIBLE2")) Then
        '    MessageBoxEx.Show(Me, "Segunda Unidad solo permite cantidades enteras", "Validación",
        '                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Txt_CantUD2.Focus()
        '    Return
        'End If

        If PqteDisponible <= 0 Then

            MessageBoxEx.Show(Me, "Producto sin stock disponble", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_CantidadPreVenta.Focus()
            Return

        End If

        If Cantidad > PqteDisponible Then

            Dim _Msj = "No puede vender mas de " & PqteDisponible & " " & FormatoPqte & vbCrLf &
                              "En su defecto " & Ud1XPqte * Cantidad & " " & _RowProducto.Item("UD01PR")
            _Msj = "Límite disponible: " & PqteDisponible & " " & FormatoPqte &
                   " o " & FormatNumber(Ud1XPqte * PqteDisponible, 0) & " " & _RowProducto.Item("UD01PR") & ". Verifique antes de continuar."
            MessageBoxEx.Show(Me, _Msj, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_CantidadPreVenta.Focus()
            Return

        End If

        Precio_DigSobreStock = DInput_PrecioXUd1.Value

        Aceptado = True

        Me.Close()

    End Sub

    Private Sub Txt_CantidadPreVenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_CantidadPreVenta.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii, False))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            Dim _CantidadPallet As Double = De_Txt_a_Num_01(Txt_CantidadPreVenta.Text, 5)

            'If _CantidadPallet < _Cl_PreVta.CantMinFormato Then
            '    MessageBoxEx.Show(Me, "La cantidad no puede ser menor a " & _Cl_PreVta.CantMinFormato & " " & _Cl_PreVta.FormatoPqte,
            '                                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    Return
            'End If

            Cantidad = _CantidadPallet
            Cantidad_Ud1 = _CantidadPallet * Ud1XPqte
            Cantidad_Ud2 = Math.Round(_Cantidad_Ud1 / _Rtu, 5)

            Txt_CantidadPreVenta.Tag = _CantidadPallet
            Txt_CantUD1.Text = Cantidad_Ud1
            Txt_CantUD2.Text = Math.Round(Cantidad_Ud2, 3)

            Btn_Aceptar.Focus()

            'Dim _C1 As Double = Math.Round(De_Txt_a_Num_01(Txt_CantUD1.Text, 5), 5)

            'If Chk_DesacRazTransf.Checked Then

            '    _Cantidad_Ud1 = _C1

            '    Try
            '        Txt_RTU.Text = Math.Round(_Cantidad_Ud1 / _Cantidad_Ud2, 5)
            '    Catch ex As Exception
            '        Txt_RTU.Text = 0
            '    End Try

            '    Txt_CantUD2.Focus()

            'Else

            '    e.Handled = True

            '    If _C1 <> _Cantidad_Ud1 Then
            '        _Cantidad_Ud1 = _C1
            '        _Cantidad_Ud2 = Math.Round(_Cantidad_Ud1 / _Rtu, 5)

            '        Txt_CantUD2.Text = Math.Round(_Cantidad_Ud2, 3)
            '    End If

            '    Btn_Aceptar.Focus()

            'End If

        ElseIf e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(".")
        End If

    End Sub

    Private Sub Txt_CantidadPreVenta_Leave(sender As Object, e As EventArgs) Handles Txt_CantidadPreVenta.Leave
        Txt_CantUD1.Text = Math.Round(_Cantidad_Ud1, 3)
    End Sub

    Private Sub Frm_Cantidades_PreVenta_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If _Fr_Alerta_Stock.Visible Then
            _Fr_Alerta_Stock.Close()
        End If
        If Not Aceptado Then
            Cantidad = Cantidad_Original
        End If
    End Sub


End Class
