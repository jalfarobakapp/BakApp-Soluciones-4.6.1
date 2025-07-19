Imports BkSpecialPrograms.Bk_Comporamiento_UdMedidas
Imports DevComponents.DotNetBar
Public Class Frm_LiquidTJVcredito

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _RowEntidadLiq As DataRow
    Dim _RowCtaOrigen As DataRow
    Dim _Tbl_Maedpce As DataTable
    Dim _Dv As New DataView

    Dim _Emdp As String
    Dim _Suemdp As String
    Dim _Cudp As String
    Dim _Nucudp As String

    Dim _Modp = "$"
    Dim _Timodp = "N"
    Dim _Tamodp = 1
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_LiquidTJVcredito_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Chk_MostrarSoloIncluidos.CheckedChanged, AddressOf Sb_Chk_MostrarSoloIncluidos_CheckedChanged
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_Areas_MouseDown

        Call Btn_Limpiar_Click(Nothing, Nothing)

    End Sub

    Function Fx_Buscar_Entidad(ByVal _Koen As String)

        Dim Fm As New Frm_BuscarEntidad_Mt(False)

        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEEN", "KOEN = '" & _Koen & "'"))

        If Not _Reg Then

            Fm.Pro_Descripcion = _Koen
            Fm.ShowDialog(Me)

            If Fm.Pro_Entidad_Seleccionada Then
                _RowEntidadLiq = Fm.Pro_RowEntidad
                _Koen = _RowEntidadLiq.Item("KOEN")
            Else
                _Koen = String.Empty
                Txt_Entidad.Text = String.Empty
                Txt_NombreEntidad.Text = String.Empty
                _RowEntidadLiq = Nothing
            End If

            Fm.Dispose()

        End If

        If String.IsNullOrEmpty(_Koen) Then
            Return False
        End If

        Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Koen & "'"
        _RowEntidadLiq = _Sql.Fx_Get_DataRow(Consulta_sql)

        Txt_Entidad.Text = _RowEntidadLiq.Item("KOEN")
        Txt_NombreEntidad.Text = _RowEntidadLiq.Item("NOKOEN")

        Return True

    End Function

    Private Sub Txt_Entidad_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Entidad.KeyDown
        If e.KeyValue = Keys.Enter Then
            Dim _Koen = Txt_Entidad.Text
            If Fx_Buscar_Entidad(_Koen) Then
                Txt_CtaOrigen.Focus()
            End If
        End If
        If e.KeyValue = Keys.Delete Then
            Txt_Entidad.Text = String.Empty
            Txt_NombreEntidad.Text = String.Empty
            _RowEntidadLiq = Nothing
        End If
    End Sub

    Private Sub Txt_CtaOrigen_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_CtaOrigen.KeyDown

        If e.KeyValue = Keys.Enter Then

            Dim _Percontact As String = _Sql.Fx_Trae_Dato("TABFU", "PERCONTACT", "KOFU = '" & FUNCIONARIO & "'")
            Txt_CtaOrigen.Text = Txt_CtaOrigen.Text.Trim

            Consulta_sql = "Select GRANCUE+MAYOR+CUENTA As CtaOrigen,* From CCUENTAS" & vbCrLf &
                           "Where PERIODO = '" & _Percontact & "' And GRANCUE+MAYOR+CUENTA = '" & Txt_CtaOrigen.Text & "'"
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row) Then
                _RowCtaOrigen = _Row
                Txt_CtaOrigen.Text = _RowCtaOrigen.Item("CtaOrigen")
                Txt_NombreCtaOrigen.Text = _RowCtaOrigen.Item("NOCUENTA")
                Return
            End If

            Dim _CtaOrigen As String = Txt_CtaOrigen.Text

            _RowCtaOrigen = Nothing
            Txt_CtaOrigen.Text = String.Empty
            Txt_NombreCtaOrigen.Text = String.Empty

            Dim Fm As New Frm_BuscarCtasContables
            Fm.CtaBuscar = _CtaOrigen
            Fm.ShowDialog(Me)

            If Not IsNothing(Fm.RowCtaSeleccionada) Then
                _RowCtaOrigen = Fm.RowCtaSeleccionada
                Txt_CtaOrigen.Text = _RowCtaOrigen.Item("CtaOrigen")
                Txt_NombreCtaOrigen.Text = _RowCtaOrigen.Item("NOCUENTA")
                Txt_CtaCteOperacion.Focus()
            End If

            Fm.Dispose()

        End If

        If e.KeyValue = Keys.Delete Then
            _RowCtaOrigen = Nothing
            Txt_CtaOrigen.Text = String.Empty
            Txt_NombreCtaOrigen.Text = String.Empty
            _Dv = Nothing
            Grilla.DataSource = Nothing
            Txt_TotalValSelec.Tag = 0
            Txt_TotalValSelec.Text = 0
        End If

    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Sb_Actualizar_Grilla()
    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Percontact As String = _Sql.Fx_Trae_Dato("TABFU", "PERCONTACT", "KOFU = '" & FUNCIONARIO & "'")

        Dim _Grancue As String
        Dim _Mayor As String
        Dim _Cuenta As String
        Dim _Subauxi As String

        If IsNothing(_RowCtaOrigen) Then
            MessageBoxEx.Show(Me, "Falta la cuenta de origen", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_CtaOrigen.Focus()
            Return
        End If

        _Grancue = Mid(Txt_CtaOrigen.Text, 1, 2)
        _Mayor = Mid(Txt_CtaOrigen.Text, 3, 3)
        _Cuenta = Mid(Txt_CtaOrigen.Text, 6, 3)
        _Subauxi = Txt_Subauxiliar.Text.Trim

        Dim _FechaDesde As Date = FormatDateTime(Dtp_FechaDesde.Value, DateFormat.ShortDate)
        Dim _FechaHasta As Date = FormatDateTime(Dtp_FechaHasta.Value, DateFormat.ShortDate)

        If _FechaDesde > _FechaHasta Then
            MessageBoxEx.Show(Me, "La fecha desde no puede ser mayor a la fecha hasta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Consulta_sql = My.Resources.Recursos_Contabilidad.Nomina_de_tarjetas_de_credito_a_liquidacion
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", Mod_Empresa)
        Consulta_sql = Replace(Consulta_sql, "#Periodo#", _Percontact)
        Consulta_sql = Replace(Consulta_sql, "#Grancue#", _Grancue)
        Consulta_sql = Replace(Consulta_sql, "#Mayor#", _Mayor)
        Consulta_sql = Replace(Consulta_sql, "#Cuenta#", _Cuenta)
        Consulta_sql = Replace(Consulta_sql, "#Subauxi#", _Subauxi)
        Consulta_sql = Replace(Consulta_sql, "#FechaDesde#", Format(_FechaDesde, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#FechaHasta#", Format(_FechaHasta, "yyyyMMdd"))

        Dim _New_Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)
        _Dv = New DataView
        _Dv.Table = _New_Ds.Tables("Table")

        With Grilla

            .DataSource = _Dv

            OcultarEncabezadoGrilla(Grilla, False)

            Dim _DisplayIndex = 0

            .Columns("Incluir").Width = 30
            .Columns("Incluir").HeaderText = "Inc"
            .Columns("Incluir").Visible = True
            .Columns("Incluir").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TIDP").Width = 30
            .Columns("TIDP").HeaderText = "TD."
            .Columns("TIDP").Visible = True
            .Columns("TIDP").ToolTipText = "Tipo de documento"
            .Columns("TIDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CUDP").Width = 110
            .Columns("CUDP").HeaderText = "Nro.Cuenta"
            .Columns("CUDP").Visible = True
            .Columns("CUDP").ToolTipText = "Número de la cuenta"
            .Columns("CUDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDP").Width = 80
            .Columns("NUDP").HeaderText = "Nro.Interno"
            .Columns("NUDP").Visible = True
            .Columns("NUDP").ToolTipText = "Número interno"
            .Columns("NUDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUCUDP").Width = 60
            .Columns("NUCUDP").HeaderText = "Nro.Doc."
            .Columns("NUCUDP").Visible = True
            .Columns("NUCUDP").ToolTipText = "Número de documento"
            .Columns("NUCUDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ENDP").Width = 80
            .Columns("ENDP").HeaderText = "Entidad"
            .Columns("ENDP").Visible = True
            .Columns("ENDP").ToolTipText = "Código de la entidad"
            .Columns("ENDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NomCliente").Width = 160
            .Columns("NomCliente").HeaderText = "Nombre cliente tarjeta"
            .Columns("NomCliente").Visible = True
            .Columns("NomCliente").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("MODP").Width = 30
            .Columns("MODP").HeaderText = "M"
            .Columns("MODP").Visible = True
            .Columns("MODP").ToolTipText = "Moneda"
            .Columns("MODP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("VADP").Width = 70
            .Columns("VADP").HeaderText = "Valor"
            .Columns("VADP").Visible = True
            .Columns("VADP").DefaultCellStyle.Format = "###,##0.##"
            .Columns("VADP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VADP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMDP").Width = 70
            .Columns("FEEMDP").HeaderText = "F.Emisión"
            .Columns("FEEMDP").Visible = True
            .Columns("FEEMDP").ToolTipText = "Fecha de emisión"
            .Columns("FEEMDP").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEEMDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEVEDP").Width = 70
            .Columns("FEVEDP").HeaderText = "F.Venc."
            .Columns("FEVEDP").Visible = True
            .Columns("FEVEDP").ToolTipText = "Fecha de vencimiento"
            .Columns("FEVEDP").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEVEDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("HORA").Width = 60
            .Columns("HORA").HeaderText = "Hora"
            .Columns("HORA").Visible = True
            .Columns("HORA").ToolTipText = "Fecha de vencimiento"
            .Columns("HORA").DefaultCellStyle.Format = "hh:mm"
            .Columns("HORA").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Txt_TotalValSelec.Tag = 0
        Txt_TotalValSelec.Text = FormatNumber(Txt_TotalValSelec.Tag, 0)

    End Sub

    Private Sub Grilla_MouseUp(sender As Object, e As MouseEventArgs) Handles Grilla.MouseUp

        'Grilla.EndEdit()

        'Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        'If _Fila.Cells("Incluir").Value Then
        '    Txt_TotalValSelec.Tag += _Fila.Cells("VADP").Value
        'Else
        '    Txt_TotalValSelec.Tag -= _Fila.Cells("VADP").Value
        'End If

        'Txt_TotalValSelec.Text = FormatNumber(Txt_TotalValSelec.Tag, 0)

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        _Fila.Cells("Incluir").Value = Not _Fila.Cells("Incluir").Value

        'Grilla.EndEdit()

        If _Fila.Cells("Incluir").Value Then
            Txt_TotalValSelec.Tag += _Fila.Cells("VADP").Value
        Else
            Txt_TotalValSelec.Tag -= _Fila.Cells("VADP").Value
        End If

        Txt_TotalValSelec.Text = FormatNumber(Txt_TotalValSelec.Tag, 0)

    End Sub

    Private Sub Txt_Filtrar_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Filtrar.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Filtrar()
        End If
    End Sub

    Private Sub Txt_Filtrar_TextChanged(sender As Object, e As EventArgs) Handles Txt_Filtrar.TextChanged
        If String.IsNullOrEmpty(Txt_Filtrar.Text) Then
            Sb_Filtrar()
        End If
    End Sub

    Private Sub Sb_Chk_MostrarSoloIncluidos_CheckedChanged(sender As Object, e As EventArgs) 'Handles 
        Sb_Filtrar()
    End Sub

    Private Sub Txt_CtaCteOperacion_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_CtaCteOperacion.KeyDown
        If e.KeyValue = Keys.Enter And String.IsNullOrEmpty(Txt_CtaCteOperacion.Text) Then
            Call Txt_CtaCteOperacion_ButtonCustom2Click(Nothing, Nothing)
        End If
        If e.KeyValue = Keys.Delete Then
            Txt_CtaCteOperacion.Text = String.Empty
        End If
    End Sub

    Private Sub Btn_Limpiar_Click(sender As Object, e As EventArgs) Handles Btn_Limpiar.Click

        Txt_Entidad.Text = String.Empty
        Txt_NombreEntidad.Text = String.Empty
        _RowEntidadLiq = Nothing
        Txt_CtaCteOperacion.Text = String.Empty
        Txt_CtaOrigen.Text = String.Empty
        Txt_NombreCtaOrigen.Text = String.Empty
        _RowCtaOrigen = Nothing
        Txt_Subauxiliar.Text = String.Empty
        Num_ValorLiquidacion.Value = 0
        Num_ValorComision.Value = 0
        Txt_Filtrar.Text = String.Empty
        Chk_MostrarSoloIncluidos.Checked = False
        Txt_TotalValSelec.Tag = 0
        Txt_TotalValSelec.Text = 0
        Dtp_FechaOperacion.Value = FechaDelServidor()
        Dtp_FechaDesde.Value = Primerdiadelmes(FechaDelServidor)
        Dtp_FechaHasta.Value = FechaDelServidor()
        _Dv = Nothing
        Grilla.DataSource = Nothing
        Sb_Tabla_Maedpce()

        Me.ActiveControl = Txt_Entidad

    End Sub

    Sub Sb_Filtrar()
        Try
            If IsNothing(_Dv) Then Return

            Dim _Refanti As String = String.Empty

            If Chk_Refanti.Checked Then
                _Refanti = "+REFANTI"
            End If

            If Chk_MostrarSoloIncluidos.Checked Then
                _Dv.RowFilter = String.Format("CUDP+NUCUDP+NUDP+ENDP+VADP+FEEMDP+FEVEDP" & _Refanti & " Like '%{0}%' And Incluir = 1", Txt_Filtrar.Text.Trim)
            Else
                _Dv.RowFilter = String.Format("CUDP+NUCUDP+NUDP+ENDP+VADP+FEEMDP+FEVEDP" & _Refanti & " Like '%{0}%'", Txt_Filtrar.Text.Trim)
            End If
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Cuek!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Grilla_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEndEdit

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        If _Fila.Cells("Incluir").Value Then
            Txt_TotalValSelec.Tag += _Fila.Cells("VADP").Value
        Else
            Txt_TotalValSelec.Tag -= _Fila.Cells("VADP").Value
        End If

        Txt_TotalValSelec.Text = FormatNumber(Txt_TotalValSelec.Tag, 0)

    End Sub

    Private Sub Txt_CtaCteOperacion_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_CtaCteOperacion.ButtonCustom2Click

        Dim Fm As New Frm_Pagos_Seleccionar_CH_TJ(Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.PT, Nothing, Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_De_Pago.Cliente, 0)
        Fm.Mostrar_Cuentas_De_La_Empresa = True
        Fm.Mostrar_Cuentas_Del_Cliente_Proveedor = False
        Fm.LabelX6.Visible = False
        Fm.Txt_VADP_Monto.Visible = False
        Fm.Btn_Traer_Saldo.Visible = False
        Fm.ShowDialog(Me)

        If Fm.Pro_Aceptar Then

            Txt_CtaCteOperacion.Text = Fm.Pro_Cudp.Trim

            _Emdp = Fm.Pro_Emdp
            _Suemdp = Fm.Pro_Suemdp
            _Cudp = Fm.Pro_Cudp
            _Nucudp = Fm.Pro_Nucudp

            '_Fila.Cells("EMDP").Value = Fm.Pro_Emdp
            '_Fila.Cells("SUEMDP").Value = Fm.Pro_Suemdp
            '_Fila.Cells("CUDP").Value = Fm.Pro_Cudp
            '_Fila.Cells("NUCUDP").Value = Fm.Pro_Nucudp
            '_Fila.Cells("CUOTAS").Value = Fm.Pro_Cuotas
            '_Fila.Cells("VADP").Value = Fm.Pro_Monto

            '_Fila.Cells("TIDP").Value = Fm.Pro_Tipd
            '_Fila.Cells("ESPGDP").Value = "P"

        End If

        Fm.Dispose()

    End Sub

    Private Sub Txt_Entidad_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Entidad.ButtonCustomClick
        If Fx_Buscar_Entidad("") Then
            Txt_CtaOrigen.Focus()
        End If
    End Sub

    Private Sub Txt_CtaOrigen_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_CtaOrigen.ButtonCustomClick

        Dim Fm As New Frm_BuscarCtasContables
        Fm.ShowDialog(Me)

        If Not IsNothing(Fm.RowCtaSeleccionada) Then
            _RowCtaOrigen = Fm.RowCtaSeleccionada
            Txt_CtaOrigen.Text = _RowCtaOrigen.Item("CtaOrigen")
            Txt_NombreCtaOrigen.Text = _RowCtaOrigen.Item("NOCUENTA")
            Txt_CtaCteOperacion.Focus()
        End If

        Fm.Dispose()

    End Sub

    Sub Sb_Tabla_Maedpce()

        Consulta_sql = "Select Top 1 IDMAEDPCE,EMPRESA,SUREDP,CJREDP,TIDP,NUDP,ENDP,EMDP,SUEMDP,CUDP,NUCUDP,FEEMDP,FEVEDP,MODP," & vbCrLf &
                       "TIMODP,TAMODP,VADP,VAABDP,VAASDP,VAVUDP,ESPGDP,REFANTI,KOTU,NUTRANSMI,DOCUENANTI,KOFUDP,KOTNDP,SUTNDP,ESASDP,ESPGDP,CUOTAS," &
                       "Cast(0 AS Int) AS IDMAEEDO,Cast(0 AS Float) As SALDO,Cast(0 As Float) As LEY20956" & vbCrLf &
                       "From MAEDPCE" & vbCrLf &
                       "Where 1 = 0"

        _Tbl_Maedpce = _Sql.Fx_Get_DataTable(Consulta_sql)

    End Sub

    Private Sub Sb_Nueva_Linea_De_Pago(_Tidp As String,
                                       _Nudp As String,
                                       _Endp As String,
                                       _Emdp As String,
                                       _Cudp As String,
                                       _Nucudp As String,
                                       _Vadp As Double,
                                       _Vaabdp As Double,
                                       _Vaasdp As Double,
                                       _Vavudp As Double,
                                       _Refanti As String)

        Dim NewFila As DataRow
        NewFila = _Tbl_Maedpce.NewRow

        With NewFila

            .Item("IDMAEDPCE") = 0
            .Item("EMPRESA") = Mod_Empresa
            .Item("SUREDP") = Mod_Sucursal
            .Item("CJREDP") = Mod_Caja

            .Item("TIDP") = _Tidp
            .Item("NUDP") = _Nudp

            .Item("ENDP") = _Endp
            .Item("EMDP") = _Emdp   ' CODIGO EMISOR DE DOCUMENTO, BANCO, TIPO TARJETA, ETC.
            .Item("SUEMDP") = String.Empty ' ??
            .Item("CUDP") = _Cudp   ' NRO CTA. CTE.
            .Item("NUCUDP") = _Nucudp ' NRO DEL CHEQUE
            .Item("FEEMDP") = Dtp_FechaOperacion.Value 'FechaDelServidor()
            .Item("FEVEDP") = Dtp_FechaOperacion.Value 'FechaDelServidor()

            .Item("MODP") = _Modp
            .Item("TIMODP") = _Timodp
            .Item("TAMODP") = _Tamodp

            .Item("VADP") = _Vadp
            .Item("VAABDP") = _Vaabdp
            .Item("VAASDP") = _Vaasdp
            .Item("VAVUDP") = _Vavudp
            .Item("ESPGDP") = String.Empty
            .Item("REFANTI") = _Refanti
            .Item("KOTU") = 1
            .Item("KOFUDP") = FUNCIONARIO
            .Item("KOTNDP") = RutEmpresa
            .Item("SUTNDP") = Mod_Caja

            .Item("ESASDP") = "A" ' ESTADO ASIGNACION DEL PAGO A = ASIGNADO A UN DOCUMENTO, P = NO ASIGNADO O PARCIALMENTE ASIGNADO, ES DECIR, SALDO A FAVOR DEL CLIENTE
            .Item("ESPGDP") = "P"
            .Item("CUOTAS") = 0

            .Item("IDMAEEDO") = 0
            .Item("SALDO") = 0
            .Item("LEY20956") = 0

            _Tbl_Maedpce.Rows.Add(NewFila)

        End With

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If IsNothing(_Dv) Or Txt_TotalValSelec.Tag = 0 Then
            MessageBoxEx.Show(Me, "Debe completar información para grabar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Txt_Entidad.Text) Then
            MessageBoxEx.Show(Me, "Falta entidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Txt_CtaOrigen.Text) Then
            MessageBoxEx.Show(Me, "Falta cuenta de origen", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Txt_CtaCteOperacion.Text) Then
            MessageBoxEx.Show(Me, "Falta cuenta de operación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Num_ValorLiquidacion.Value <> Txt_TotalValSelec.Tag Then
            MessageBoxEx.Show(Me, "EL valor a liquidar no cuadra con sumatoria de documentos" & vbCrLf &
                          "de pago a dar por cancelados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Num_ValorComision.Value >= Num_ValorLiquidacion.Value Then
            MessageBoxEx.Show(Me, "Inconsistencia en valores de comisión y/o valor a liquidar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Confirma los siguientes valores para efectuar la liquidación?" & vbCrLf & vbCrLf &
                             "Valor informado liquidar con ATB (abono transferencia bancaria): " & FormatNumber(Num_ValorLiquidacion.Value, 0) & vbCrLf &
                             "Valor de comisión a ser representada con PTB (pago con transferencia bancaria): " & FormatNumber(Num_ValorComision.Value, 0),
                             "Grabar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim _Filtro As String = Generar_Filtro_IN(_Dv.Table, "Incluir", "IDMAEDPCE", True, True, "")

        Consulta_sql = "Select * From MAEDPCE Where IDMAEDPCE In " & _Filtro
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Sb_Tabla_Maedpce()

        Dim _Endp = _RowEntidadLiq.Item("KOEN")

        Sb_Nueva_Linea_De_Pago("ATB", "", _Endp, _Emdp, _Cudp, _Nucudp, Num_ValorLiquidacion.Value, 0, Num_ValorLiquidacion.Value, 0, "")
        Sb_Nueva_Linea_De_Pago("PTB", "", _Endp, _Emdp, _Cudp, _Nucudp, Num_ValorComision.Value, 0, Num_ValorComision.Value, 0, "Anticipo para cruce comisión liquidación")

        Dim _Cl_Pagar As New Clas_Pagar
        If _Cl_Pagar.Fx_Crear_Pago_Liquidacion_Tarjetas_Credito(_Tbl_Maedpce.Rows(0), _Tbl_Maedpce.Rows(1), _Tbl) Then
            Call Btn_Limpiar_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub Btn_ImportarExcel_Click(sender As Object, e As EventArgs) Handles Btn_ImportarExcel.Click

        If IsNothing(_Dv) Then
            MessageBoxEx.Show(Me, "No hay registros que analizar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Not CBool(_Dv.Table.Rows.Count) Then
            MessageBoxEx.Show(Me, "No hay registros que analizar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Txt_Filtrar.Text = String.Empty
        Chk_MostrarSoloIncluidos.Checked = False

        Dim Fm As New Frm_LiquidImporDtExcel(_Dv.Table)
        Fm.Chk_Refanti.Checked = Chk_Refanti.Checked
        Fm.ShowDialog(Me)

        If Fm.Ls_Liquid_Transbank.Count Then
            Chk_MostrarSoloIncluidos.Checked = True
            Txt_TotalValSelec.Tag = Fm.TotalValSelec
            Txt_TotalValSelec.Text = FormatNumber(Txt_TotalValSelec.Tag, 0)
        End If

        Fm.Dispose()

    End Sub

    Private Sub Chk_MarcarTodos_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_MarcarTodos.CheckedChanged

        If IsNothing(_Dv) Then
            If Chk_MarcarTodos.Checked Then
                MessageBoxEx.Show(Me, "No hay registros que analizar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            Chk_MarcarTodos.Checked = False
            Return
        End If

        If Not CBool(_Dv.Table.Rows.Count) Then
            If Chk_MarcarTodos.Checked Then
                MessageBoxEx.Show(Me, "No hay registros que analizar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            Chk_MarcarTodos.Checked = False
            Return
        End If

        Txt_Filtrar.Text = String.Empty
        Chk_MostrarSoloIncluidos.Checked = False

        For Each _Fila As DataRow In _Dv.Table.Rows

            _Fila.Item("Incluir") = Chk_MarcarTodos.Checked

            If Chk_MarcarTodos.Checked Then
                Txt_TotalValSelec.Tag += _Fila.Item("VADP")
            Else
                Txt_TotalValSelec.Tag -= _Fila.Item("VADP")
            End If

        Next

        Txt_TotalValSelec.Text = FormatNumber(Txt_TotalValSelec.Tag, 0)

    End Sub

    Private Sub Sb_Grilla_Areas_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_01)
                End If
            End With
        End If
    End Sub

    Private Sub Btn_Mnu_EditarCuenta_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_EditarCuenta.Click

        If Not Fx_Tiene_Permiso(Me, "Espr0034") Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Idmaedpce As Integer = _Fila.Cells("IDMAEDPCE").Value
        Dim _Cudp As String = _Fila.Cells("CUDP").Value.ToString.Trim
        Dim _Cudp_Old As String = _Cudp
        Dim _Aceptar As Boolean

        _Aceptar = InputBox_Bk(Me, "Ingrese el nuevo número de cuenta" & vbCrLf & "Máximo 16 caracteres",
                               "Cambiar número de cuenta",
                               _Cudp,
                               False,
                               _Tipo_Mayus_Minus.Normal,
                               16,
                               True,
                               _Tipo_Imagen.Cheque_Numero,, _Tipo_Caracter.Solo_Numeros_Enteros)

        If Not _Aceptar Then
            Return
        End If

        If _Cudp = _Cudp_Old Then
            Return
        End If

        Consulta_sql = "Update MAEDPCE Set CUDP = '" & _Cudp & "' Where IDMAEDPCE = " & _Idmaedpce

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then

            _Fila.Cells("CUDP").Value = _Cudp
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Cambiar número de cuenta",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub Btn_Mnu_EditarNumero_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_EditarNumero.Click

        If Not Fx_Tiene_Permiso(Me, "Espr0034") Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Idmaedpce As Integer = _Fila.Cells("IDMAEDPCE").Value
        Dim _Nucudp As String = _Fila.Cells("NUCUDP").Value.ToString.Trim
        Dim _Nucudp_Old As String = _Nucudp
        Dim _Aceptar As Boolean

        _Aceptar = InputBox_Bk(Me, "Ingrese el nuevo número del documento de pago" & vbCrLf & "Máximo 8 caracteres",
                               "Cambiar número de documento",
                               _Nucudp,
                               False,
                               _Tipo_Mayus_Minus.Normal,
                               8,
                               True,
                               _Tipo_Imagen.Cheque_Numero,, _Tipo_Caracter.Solo_Numeros_Enteros)

        If Not _Aceptar Then
            Return
        End If

        If _Nucudp = _Nucudp_Old Then
            Return
        End If

        Consulta_sql = "Update MAEDPCE Set NUCUDP = '" & _Nucudp & "' Where IDMAEDPCE = " & _Idmaedpce

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then

            _Fila.Cells("NUCUDP").Value = _Nucudp
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Cambiar número de documento",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub Btn_Copiar_Click(sender As Object, e As EventArgs) Handles Btn_Copiar.Click

        With Grilla

            Dim _Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
            Dim _Texto_Cabeza = .Columns(.CurrentCell.ColumnIndex).HeaderText

            If _Cabeza = "Incluir" Then
                _Cabeza = "IDMAEDPCE"
                _Texto_Cabeza = _Cabeza
            End If

            Dim Copiar = .Rows(.CurrentRow.Index).Cells(_Cabeza).Value
            Clipboard.SetText(Copiar)

            ToastNotification.Show(Me, _Texto_Cabeza & " esta en el portapapeles", Btn_Copiar.Image,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        End With

    End Sub

    Private Sub Btn_ExportarExcel_Click(sender As Object, e As EventArgs) Handles Btn_ExportarExcel.Click
        ExportarTabla_JetExcel_Tabla(_Dv.Table, Me, "Liquidacion")
    End Sub

    Private Sub Btn_Ver_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Documento.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Idmaedpce As Integer = _Fila.Cells("IDMAEDPCE").Value

        Dim Fm As New Frm_Pagos_Documentos_Pagados(_Idmaedpce)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Refanti As String = _Fila.Cells("REFANTI").Value

        Lbl_Refanti.Text = "Ref. Anticipo: " & _Refanti

    End Sub
End Class
