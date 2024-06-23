'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Pagos_Seleccionar_CH_TJ

    Dim Consulta_Sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Dim _Koen As String

    Dim _Aceptar As Boolean
    Dim _Tidpen As Enum_Tipo_Pago

    Dim _EMDP As String
    Dim _SUEMDP As String
    Dim _CUDP As String
    Dim _NUCUDP As String
    Dim _CUOTAS As Integer
    Dim _VADP As Double

    Dim _Tbl_Ctas_Entidad As DataTable
    Dim _Mostrar_Cuentas_Del_Cliente_Proveedor As Boolean
    Dim _Mostrar_Cuentas_De_La_Empresa As Boolean

    Enum Enum_Tipo_De_Pago
        Cliente
        Proveedor
    End Enum

    Dim _Tipo_De_Pago As Enum_Tipo_De_Pago

    Enum Enum_Tipo_Pago
        CH
        TJ
        DP
        PT
        LT
        CR
    End Enum

    Public ReadOnly Property Pro_Tipd() As String
        Get
            Select Case _Tipo_De_Pago
                Case Enum_Tipo_De_Pago.Cliente
                    Select Case _Tidpen
                        Case Enum_Tipo_Pago.CH
                            Return "CHV"
                        Case Enum_Tipo_Pago.TJ
                            Return "TJV"
                        Case Enum_Tipo_Pago.DP
                            Return "DEP"
                        Case Enum_Tipo_Pago.PT
                            Return "ATB"
                        Case Enum_Tipo_Pago.LT
                            Return "LTV"
                        Case Enum_Tipo_Pago.CR
                            Return "CRV"
                    End Select
                Case Enum_Tipo_De_Pago.Proveedor
                    Select Case _Tidpen
                        Case Enum_Tipo_Pago.CH
                            Return "CHC"
                        Case Enum_Tipo_Pago.TJ
                            Return "TJC"
                        Case Enum_Tipo_Pago.DP
                            Return "PTB"
                        Case Enum_Tipo_Pago.LT
                            Return "LTC"
                    End Select
            End Select
        End Get
    End Property

    Public ReadOnly Property Pro_NoTipd() As String
        Get
            Dim _Notipd = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones", "NombreTabla", "Tabla Like 'TIDP_%' And CodigoTabla = '" & Pro_Tipd & "'")
            Return _Notipd
        End Get
    End Property

    Public Property Pro_Emdp() As String
        Get
            Return _EMDP
        End Get
        Set(value As String)
            _EMDP = value
            Txt_EMDP_Documento.Text = value
        End Set
    End Property

    Public Property Pro_Suemdp() As String
        Get
            Return _SUEMDP
        End Get
        Set(value As String)
            Txt_SUEMDP_Sucursal.Text = value
            _SUEMDP = value
        End Set
    End Property

    Public Property Pro_Cudp() As String
        Get
            Return _CUDP
        End Get
        Set(value As String)
            Txt_CUDP_Nro_Cuenta.Text = value
            _CUDP = value
        End Set
    End Property

    Public Property Pro_Nucudp() As String
        Get
            Return _NUCUDP
        End Get
        Set(value As String)
            Txt_NUCUDP_Nro_Documento.Text = value
            _NUCUDP = value
        End Set
    End Property

    Public Property Pro_Cuotas() As Integer
        Get
            Return _CUOTAS
        End Get
        Set(value As Integer)
            Input_CUOTAS_Nro_Cuotas.Value = value
            _CUOTAS = value
        End Set
    End Property

    Public Property Pro_Monto() As Double
        Get
            Return _VADP
        End Get
        Set(value As Double)
            Txt_VADP_Monto.Text = value
            _VADP = value
        End Set
    End Property

    Public ReadOnly Property Pro_Aceptar() As Boolean
        Get
            Return _Aceptar
        End Get
    End Property

    Public Property Koen As String
        Get
            Return _Koen
        End Get
        Set(value As String)
            _Koen = value
        End Set
    End Property

    Public Property Mostrar_Cuentas_Del_Cliente_Proveedor As Boolean
        Get
            Return _Mostrar_Cuentas_Del_Cliente_Proveedor
        End Get
        Set(value As Boolean)
            _Mostrar_Cuentas_Del_Cliente_Proveedor = value
        End Set
    End Property

    Public Property Mostrar_Cuentas_De_La_Empresa As Boolean
        Get
            Return _Mostrar_Cuentas_De_La_Empresa
        End Get
        Set(value As Boolean)
            _Mostrar_Cuentas_De_La_Empresa = value
        End Set
    End Property

    Dim _Row_Emisor As DataRow
    Dim _Saldo As Double

    Public Sub New(Tidpen As Enum_Tipo_Pago, Row_Emisor As DataRow, Tipo_De_Pago As Enum_Tipo_De_Pago, _Saldo As Double)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Tidpen = Tidpen
        _Tipo_De_Pago = Tipo_De_Pago

        Me._Saldo = _Saldo

        If Not IsNothing(Row_Emisor) Then

            _Row_Emisor = Row_Emisor

            Txt_EMDP_Documento.Text = Trim(_Row_Emisor.Item("NOKOENDP"))
            _EMDP = _Row_Emisor.Item("KOENDP")

        End If

        Sb_Formato_Generico_Grilla(Grilla_Ctas, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, True, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Pagos_Seleccionar_CH_TJ_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Input_CUOTAS_Nro_Cuotas.Text = 1

        Input_CUOTAS_Nro_Cuotas.Visible = False
        LabelX5.Visible = False

        Select Case _Tidpen

            Case Enum_Tipo_Pago.TJ

                Me.Text = "PAGO CON TARJETAS"
                LabelX5.Visible = True
                Input_CUOTAS_Nro_Cuotas.Visible = True
                Me.ActiveControl = Txt_CUDP_Nro_Cuenta

            Case Enum_Tipo_Pago.CH

                Me.Text = "PAGO CON CHEQUE"

            Case Enum_Tipo_Pago.DP

                Me.Text = "PAGO CON DEPOSITO"
                Txt_CUDP_Nro_Cuenta.Enabled = False
                Txt_SUEMDP_Sucursal.Enabled = False
                Me.ActiveControl = Txt_NUCUDP_Nro_Documento

                If _Tipo_De_Pago = Enum_Tipo_De_Pago.Cliente Then
                    Btn_Buscar_Emisor.Enabled = False
                End If

            Case Enum_Tipo_Pago.PT

                Me.Text = "PAGO CON TRASFERENCIA BANCARIA"
                Btn_Buscar_Emisor.Enabled = False
                Txt_SUEMDP_Sucursal.Enabled = False

                If _Tipo_De_Pago = Enum_Tipo_De_Pago.Cliente Then
                    Btn_Buscar_Emisor.Enabled = False
                End If

            Case Enum_Tipo_Pago.CR

                Me.Text = "PAGO CON COMPROBANTE DE RETENCION DE VENTA"

                Txt_CUDP_Nro_Cuenta.Enabled = False
                Input_CUOTAS_Nro_Cuotas.Value = 1

                Sb_Buscar_Emisor()

        End Select

        AddHandler Btn_Aceptar.Click, AddressOf Sb_Aceptar

        AddHandler Txt_SUEMDP_Sucursal.KeyDown, AddressOf Txt_Enter_X_F2_KeyDown
        AddHandler Txt_CUDP_Nro_Cuenta.KeyDown, AddressOf Txt_Enter_X_F2_KeyDown
        AddHandler Txt_NUCUDP_Nro_Documento.KeyDown, AddressOf Txt_Enter_X_F2_KeyDown
        AddHandler Input_CUOTAS_Nro_Cuotas.KeyDown, AddressOf Txt_Enter_X_F2_KeyDown

        AddHandler Txt_VADP_Monto.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros

        Sb_Llenar_Grilla_Cuentas_Entidad()

    End Sub

    Sub Sb_Aceptar()

        If String.IsNullOrEmpty(Txt_EMDP_Documento.Text.Trim) Then

            Beep()
            ToastNotification.Show(Me, "FALTA EMISOR DE DOCUMENTO",
                                   My.Resources.cross,
                                   1 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Return
        End If

        If Txt_CUDP_Nro_Cuenta.Enabled And
          (String.IsNullOrEmpty(Txt_CUDP_Nro_Cuenta.Text.Trim) Or
           String.IsNullOrEmpty(Txt_NUCUDP_Nro_Documento.Text.Trim)) Then

            Beep()
            ToastNotification.Show(Me, "FALTA NUMERO DE CUENTA O NUMERO DE DOCUMENTO",
                                   My.Resources.cross,
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Return
        End If

        If Txt_NUCUDP_Nro_Documento.Text.Length > 8 Then
            Beep()
            ToastNotification.Show(Me, "NUMERO DE DOCUMENTO MAXIMO 8 CARACATERES",
                                   My.Resources.cross,
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Txt_NUCUDP_Nro_Documento.Focus()
            Return
        End If

        _VADP = De_Txt_a_Num_01(Txt_VADP_Monto.Text, 5)

        If Not Txt_VADP_Monto.Visible Then
            _VADP = 1
        End If

        If CBool(_VADP) Then

            If Mostrar_Cuentas_Del_Cliente_Proveedor Then

                Dim _Reg = _Sql.Fx_Cuenta_Registros("MAEENCTA",
                                                    "TIPOPAGO = '" & _Tidpen.ToString & "V' " &
                                                    "And KOEN = '" & _Koen & "' And EMISOR = '" & _EMDP & "' " &
                                                    "And CUENTA = '" & Txt_CUDP_Nro_Cuenta.Text & "' And SUCURSAL = '" & Txt_SUEMDP_Sucursal.Text & "'")

                If Not CBool(_Reg) Then

                    If MessageBoxEx.Show(Me, "¿Desea agregar esta nueva cuenta como antecedente del cliente?", "Nueva cuenta",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                        Dim _Aceptar As Boolean
                        Dim _Rut, _Norut As String

                        Dim Fm As New Frm_Pagos_Agregar_Cte_Maeencta
                        Fm.Emisor = _EMDP
                        Fm.Nombre_Emisor = Txt_EMDP_Documento.Text
                        Fm.Cuenta = Txt_CUDP_Nro_Cuenta.Text
                        Fm.Sucursal = Txt_SUEMDP_Sucursal.Text
                        Fm.Grupo_Datos_CtaCte.Enabled = False
                        Fm.ShowDialog(Me)
                        _Aceptar = Fm.Aceptar
                        _Rut = Fm.Rut
                        _Norut = Fm.Norut
                        Fm.Dispose()

                        If _Aceptar Then

                            Consulta_Sql = "Insert Into MAEENCTA (KOEN,TIPOPAGO,EMISOR,CUENTA,RUT,NORUT,BLOQUEADA,SUCURSAL) Values 
                                            ('" & _Koen & "','" & _Tidpen.ToString & "V','" & _EMDP & "'," &
                                            "'" & Txt_CUDP_Nro_Cuenta.Text & "','" & _Rut.Trim & "','" & _Norut.Trim & "',0,'" & Txt_SUEMDP_Sucursal.Text & "')"

                            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

                                MessageBoxEx.Show(Me, "Datos incorporados correctamente", "Nueva Cta.Cte.",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                            End If

                        Else

                            Return

                        End If

                    End If

                End If

            End If

            '_EMDP = Cmb_EMDP_Documento.SelectedValue
            _CUDP = Txt_CUDP_Nro_Cuenta.Text
            _NUCUDP = Txt_NUCUDP_Nro_Documento.Text
            _CUOTAS = Input_CUOTAS_Nro_Cuotas.Value
            _SUEMDP = Txt_SUEMDP_Sucursal.Text

            _Aceptar = True
            Me.Close()
        Else
            MessageBoxEx.Show(Me, "Debe ingresar el $ monto del pago", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_VADP_Monto.Focus()
            Txt_VADP_Monto.SelectAll()
        End If

    End Sub

    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click

        Txt_EMDP_Documento.Text = String.Empty
        Txt_CUDP_Nro_Cuenta.Text = String.Empty
        Input_CUOTAS_Nro_Cuotas.Value = 1
        Txt_NUCUDP_Nro_Documento.Text = String.Empty
        Txt_SUEMDP_Sucursal.Text = String.Empty
        Txt_VADP_Monto.Text = String.Empty

        Txt_EMDP_Documento.Focus()

        Sb_Llenar_Grilla_Cuentas_Entidad()

    End Sub

    Private Sub Txt_Enter_X_F2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyValue = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Public Sub Sb_Llenar_Grilla_Cuentas_Entidad()

        If Mostrar_Cuentas_De_La_Empresa Then

            Consulta_Sql = "Select * From TABENDP Where CTACTE <> '' And TIDPEN = 'CH' Order by TIDPEN,KOENDP"

        ElseIf Mostrar_Cuentas_Del_Cliente_Proveedor Then

            Consulta_Sql = "Select TIPOPAGO As TIDPEN,EMISOR As KOENDP,SUCURSAL As SUENDP,CUENTA As CTACTE,NOKOENDP,RUT
                            From MAEENCTA 
                            Left Join TABENDP On KOENDP = EMISOR And SUENDP = SUCURSAL
                            Where KOEN = '" & _Koen & "' And TIDPEN Like '" & _Tidpen.ToString & "%'"

        Else

            Return

        End If

        _Tbl_Ctas_Entidad = _Sql.Fx_Get_DataTable(Consulta_Sql)

        With Grilla_Ctas

            .DataSource = _Tbl_Ctas_Entidad

            OcultarEncabezadoGrilla(Grilla_Ctas, True)

            Dim _DisplayIndex = 0

            If Mostrar_Cuentas_De_La_Empresa Then

                .Columns("KOENDP").HeaderText = "Emisor"
                .Columns("KOENDP").Width = 90
                .Columns("KOENDP").Visible = True
                .Columns("KOENDP").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

            End If

            .Columns("CTACTE").HeaderText = "Cuenta"
            .Columns("CTACTE").Width = 100
            .Columns("CTACTE").Visible = True
            .Columns("CTACTE").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOENDP").HeaderText = "Descripción"
            .Columns("NOKOENDP").Width = 200
            .Columns("NOKOENDP").Visible = True
            .Columns("NOKOENDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            If Mostrar_Cuentas_Del_Cliente_Proveedor Then

                .Columns("RUT").HeaderText = "Rut"
                .Columns("RUT").Width = 80
                .Columns("RUT").Visible = True
                .Columns("RUT").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

            End If

        End With

    End Sub

    Private Sub Cmb_EMDP_Documento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Txt_SUEMDP_Sucursal.Focus()
    End Sub

    Private Sub Txt_VADP_Monto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_VADP_Monto.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Aceptar()
        End If
    End Sub

    Private Sub Txt_EMDP_Documento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_EMDP_Documento.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Buscar_Emisor()
        End If
    End Sub

    Private Sub Btn_Buscar_Emisor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Buscar_Emisor.Click
        Sb_Buscar_Emisor()
    End Sub

    Private Sub Sb_Buscar_Emisor()

        Dim Fm_Emisor As New Frm_Seleccionar_Emisor_Doc_Pago(_Tidpen)
        Fm_Emisor.ShowDialog(Me)
        _Row_Emisor = Fm_Emisor.Pro_Row_Tabendp
        Fm_Emisor.Dispose()

        If Not (_Row_Emisor Is Nothing) Then

            _EMDP = _Row_Emisor.Item("KOENDP")
            Txt_EMDP_Documento.Text = _Row_Emisor.Item("NOKOENDP").ToString.Trim

            Txt_CUDP_Nro_Cuenta.Text = String.Empty
            Txt_NUCUDP_Nro_Documento.Text = String.Empty

            Txt_SUEMDP_Sucursal.Text = _Row_Emisor.Item("SUENDP").ToString.Trim

            If String.IsNullOrEmpty(Txt_SUEMDP_Sucursal.Text) Then

                Txt_SUEMDP_Sucursal.Focus()
                Txt_SUEMDP_Sucursal.SelectAll()

            Else

                Txt_CUDP_Nro_Cuenta.Focus()

            End If

        End If

    End Sub

    Private Sub Frm_Pagos_Seleccionar_CH_TJ_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Grilla_Ctas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Ctas.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Ctas.Rows(Grilla_Ctas.CurrentRow.Index)

        'TIPOPAGO As TIDPEN,EMISOR As KOENDP,SUCURSAL As SUENDP,CUENTA As CTACTE,NOKOENDP,RUT

        Dim _Koendp As String = _Fila.Cells("KOENDP").Value
        Dim _Nokoendp As String = _Fila.Cells("NOKOENDP").Value
        Dim _Suendp As String = _Fila.Cells("SUENDP").Value
        Dim _Ctacte As String = _Fila.Cells("CTACTE").Value

        _EMDP = _Koendp
        Txt_EMDP_Documento.Text = _Nokoendp

        If _Tidpen = Enum_Tipo_Pago.PT Then
            _Suendp = String.Empty
        End If

        Txt_CUDP_Nro_Cuenta.Text = _Ctacte
        Input_CUOTAS_Nro_Cuotas.Value = 1

        'Txt_NUCUDP_Nro_Documento.Text = String.Empty
        If Mostrar_Cuentas_Del_Cliente_Proveedor Then Txt_SUEMDP_Sucursal.Text = _Suendp
        'Txt_VADP_Monto.Text = String.Empty

        Txt_NUCUDP_Nro_Documento.Focus()

    End Sub

    Private Sub Grilla_Ctas_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla_Ctas.KeyDown

        Try
            If e.KeyValue = Keys.Enter Then
                SendKeys.Send("{LEFT}")
                e.Handled = True
                Call Grilla_Ctas_CellDoubleClick(Nothing, Nothing)
            End If
        Catch ex As Exception
            Beep()
        End Try

    End Sub

    Private Sub Btn_Traer_Saldo_Click(sender As Object, e As EventArgs) Handles Btn_Traer_Saldo.Click
        Txt_VADP_Monto.Tag = _Saldo
        Txt_VADP_Monto.Text = _Saldo
    End Sub

End Class
