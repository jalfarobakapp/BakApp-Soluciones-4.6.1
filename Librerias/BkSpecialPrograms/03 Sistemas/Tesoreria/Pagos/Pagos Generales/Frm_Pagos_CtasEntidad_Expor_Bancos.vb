Imports DevComponents.DotNetBar
Imports Org.BouncyCastle.Math.EC

Public Class Frm_Pagos_CtasEntidad_Expor_Bancos

    Dim Consulta_Sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Dim _Tbl_Maedpce As DataTable
    Dim _Rojo, _Azul, _Verde As Color
    Dim _Cancelar As Boolean
    Dim _Row_Caja As DataRow

    Dim _Modp = "$"
    Dim _Timodp = "N"
    Dim _Tamodp = 1
    Public Property Tbl_Maedpce As DataTable
        Get
            Return _Tbl_Maedpce
        End Get
        Set(value As DataTable)
            _Tbl_Maedpce = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Maedpce, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Consulta_Sql = "SELECT TOP 1 * FROM MAEMO WHERE KOMO = 'US$' AND FEMO = '" & Format(FechaDelServidor, "yyyyMMdd") & "' ORDER BY IDMAEMO DESC"
        Dim _RowMoneda_USdolar = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If Not IsNothing(_RowMoneda_USdolar) Then
            _Tamodp = _RowMoneda_USdolar.Item("VAMO")
        Else
            _Tamodp = 1
        End If

        Consulta_Sql = "Select * From TABCJ Where EMPRESA = '" & ModEmpresa & "' And KOSU = '" & ModSucursal & "' and KOCJ = '" & ModCaja & "'"
        _Row_Caja = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Pagos_CtasEntidad_Expor_Bancos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "LEVANTAMIENTO DE PAGOS MASIVAMENTE, CAJA: " & ModCaja & " - " & _Row_Caja.Item("NOKOCJ").ToString.Trim

        ' Desarrollos 19-10-2020

        ' Se pueden incorporar lineas de pago
        ' Se valida y marca con rojo aquellos pagos que pudieren estar repetidos.
        ' Se puede buscar a un cliente e incorporar en el pago
        ' Se puede editar un pago
        ' Se puede eliminar una fila de pago (solo de la grilla no de Random)

        AddHandler Grilla_Maedpce.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        If Global_Thema = Enum_Themas.Oscuro Then

            _Rojo = Color.FromArgb(220, 78, 66)
            _Azul = Color.FromArgb(37, 136, 213)
            _Verde = Color.FromArgb(30, 215, 96)

        Else

            _Rojo = Color.Red
            _Azul = Color.Blue
            _Verde = Color.Green

        End If

        Sb_InsertarBotonenGrilla(Grilla_Maedpce, "Btn_Ico", "Ico", "Inf.", 0, _Tipo_Boton.Imagen)

        Sb_Tabla_Maedpce()
        Sb_Nueva_Linea_De_Pago()

        AddHandler Chk_Seleccionar_Todo.CheckedChanged, AddressOf Chk_Seleccionar_Todo_CheckedChanged
        AddHandler Grilla_Maedpce.EditingControlShowing, AddressOf Grilla_EditingControlShowing

    End Sub

    Sub Sb_Tabla_Maedpce()

        Consulta_Sql = "Select Top 1 Cast(0 As Int) As Id,Cast(0 As Bit) As Chk,IDMAEDPCE,EMPRESA,SUREDP,CJREDP,TIDP,NUDP,ENDP,EMDP,Cast('' As Varchar(50)) As RAZON,SUEMDP,CUDP,NUCUDP,FEEMDP,FEVEDP,MODP," & vbCrLf &
                       "TIMODP,TAMODP,VADP,VAABDP,VAASDP,VAVUDP,ESPGDP,REFANTI,KOTU,NUTRANSMI,DOCUENANTI,KOFUDP,KOTNDP,SUTNDP,ESASDP,CUOTAS," &
                       "ARCHIRSD,IDRSD,CAST(0 AS INT) AS IDMAEEDO,CAST(0 AS FLOAT) AS SALDO,Cast(0 As Float) As LEY20956," &
                       "Cast('' As Varchar(14)) As Doc_Anticipo,Cast('' As Varchar(30)) As NOTIDP,Cast('' As Varchar(30)) As NOKOENDP,Cast(0 As Bit) As Error," &
                       "Cast(0 As Bit) As Exclamacion,Cast('' As Varchar(100)) As Observacion,CAST(0 As Bit) As 'CruzarPagoAuto'" & vbCrLf &
                       "FROM MAEDPCE WITH ( NOLOCK ) " & vbCrLf &
                       "WHERE 1 = 0"

        _Tbl_Maedpce = _Sql.Fx_Get_DataTable(Consulta_Sql)

        Dim _DisplayIndex = 0

        With Grilla_Maedpce

            .DataSource = _Tbl_Maedpce

            OcultarEncabezadoGrilla(Grilla_Maedpce, True)

            .Columns("Btn_Ico").HeaderText = ""
            .Columns("Btn_Ico").Width = 35
            .Columns("Btn_Ico").Visible = True
            .Columns("Btn_Ico").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Chk").HeaderText = "Sel"
            .Columns("Chk").Width = 30
            .Columns("Chk").ReadOnly = False
            .Columns("Chk").Visible = True
            .Columns("Chk").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TIDP").HeaderText = "TD"
            .Columns("TIDP").Width = 30
            .Columns("TIDP").Visible = True
            .Columns("TIDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ENDP").HeaderText = "Entidad"
            .Columns("ENDP").Width = 80
            .Columns("ENDP").Visible = True
            .Columns("ENDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("RAZON").HeaderText = "Nombre Entidad"
            .Columns("RAZON").Width = 190
            .Columns("RAZON").Visible = True
            .Columns("RAZON").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMDP").HeaderText = "F.Emisión"
            .Columns("FEEMDP").Width = 65
            .Columns("FEEMDP").Visible = True
            .Columns("FEEMDP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FEEMDP").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEEMDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEVEDP").HeaderText = "F.venci."
            .Columns("FEVEDP").Width = 65
            .Columns("FEVEDP").Visible = True
            .Columns("FEVEDP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FEVEDP").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEVEDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CUDP").HeaderText = "Mon"
            .Columns("CUDP").Width = 20
            .Columns("CUDP").Visible = True
            .Columns("CUDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CUDP").HeaderText = "Cuenta"
            .Columns("CUDP").Width = 100
            .Columns("CUDP").Visible = True
            .Columns("CUDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUCUDP").HeaderText = "Número doc."
            .Columns("NUCUDP").Width = 80
            .Columns("NUCUDP").Visible = True
            .Columns("NUCUDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("VADP").HeaderText = "Monto"
            .Columns("VADP").Width = 80
            .Columns("VADP").Visible = True
            .Columns("VADP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VADP").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("VADP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("REFANTI").HeaderText = "Referencia (REFANTI)"
            .Columns("REFANTI").Width = 180
            .Columns("REFANTI").Visible = True
            .Columns("REFANTI").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CruzarPagoAuto").HeaderText = "CPA"
            .Columns("CruzarPagoAuto").ToolTipText = "Cruzar pago automáticamente"
            .Columns("CruzarPagoAuto").Width = 30
            '.Columns("CruzarPagoAuto").ReadOnly = False
            .Columns("CruzarPagoAuto").Visible = True
            .Columns("CruzarPagoAuto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Doc_Anticipo").HeaderText = "Doc.Asoc.Anticipo"
            .Columns("Doc_Anticipo").Width = 110
            .Columns("Doc_Anticipo").Visible = True
            .Columns("Doc_Anticipo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Sub Sb_Nueva_Linea_De_Pago()

        Dim NewFila As DataRow

        NewFila = Fx_Nueva_Linea_De_Pago(_Tbl_Maedpce)

        _Tbl_Maedpce.Rows.Add(NewFila)

        Dim _Filas = Grilla_Maedpce.RowCount

        If _Filas > 0 Then
            _Filas -= 1
        End If

        Grilla_Maedpce.Rows(_Filas).Cells("Btn_Ico").Value = Imagenes_20x20.Images.Item(6)

    End Sub

    Private Function Fx_Nueva_Linea_De_Pago(_Tbl As DataTable) As DataRow

        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow

        Dim _FechaDelServidor As DateTime = FechaDelServidor()
        Dim _Id = _Tbl_Maedpce.Rows.Count + 1

        If _Id > 1 Then
            _Id = _Tbl_Maedpce.Rows(_Tbl_Maedpce.Rows.Count - 1).Item("Id") + 1
        End If

        With NewFila

            .Item("Id") = _Id
            .Item("Chk") = False
            .Item("IDMAEDPCE") = 0
            .Item("EMPRESA") = ModEmpresa
            .Item("SUREDP") = ModSucursal
            .Item("CJREDP") = ModCaja

            .Item("TIDP") = String.Empty
            .Item("NUDP") = String.Empty

            .Item("ENDP") = String.Empty
            .Item("EMDP") = String.Empty   ' CODIGO EMISOR DE DOCUMENTO, BANCO, TIPO TARJETA, ETC.
            .Item("SUEMDP") = String.Empty ' ??
            .Item("CUDP") = String.Empty   ' NRO CTA. CTE.
            .Item("NUCUDP") = String.Empty ' NRO DEL CHEQUE
            .Item("FEEMDP") = _FechaDelServidor
            .Item("FEVEDP") = _FechaDelServidor

            .Item("MODP") = _Modp
            .Item("TIMODP") = _Timodp
            .Item("TAMODP") = _Tamodp

            .Item("VADP") = 0
            .Item("VAABDP") = 0
            .Item("VAASDP") = 0
            .Item("VAVUDP") = 0
            .Item("SALDO") = 0

            .Item("REFANTI") = String.Empty
            .Item("KOTU") = 1
            .Item("KOFUDP") = FUNCIONARIO
            .Item("KOTNDP") = RutEmpresa
            .Item("SUTNDP") = ModCaja

            .Item("NUTRANSMI") = String.Empty
            .Item("DOCUENANTI") = String.Empty

            .Item("ESASDP") = "P" ' ESTADO ASIGNACION DEL PAGO A = ASIGNADO A UN DOCUMENTO, P = NO ASIGNADO O PARCIALMENTE ASIGNADO, ES DECIR, 
            .Item("ESPGDP") = "P"
            .Item("CUOTAS") = 1
            .Item("NOKOENDP") = String.Empty

            .Item("ARCHIRSD") = String.Empty
            .Item("IDRSD") = 0

            .Item("Error") = False
            .Item("Exclamacion") = False
            .Item("Observacion") = String.Empty
            .Item("CruzarPagoAuto") = False

        End With

        Return NewFila

    End Function

    Private Sub Grilla_Maedpce_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Maedpce.CellDoubleClick

        Dim _Cabeza = Grilla_Maedpce.Columns(Grilla_Maedpce.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)

        Dim _Idmaedpce As Integer = _Fila.Cells("IDMAEDPCE").Value
        Dim _Tidp As String = _Fila.Cells("TIDP").Value
        Dim _Vadp As Double = NuloPorNro(_Fila.Cells("VADP").Value, 0)

        If CBool(_Idmaedpce) Then

            Dim Fm As New Frm_Pagos_Documentos_Pagados(_Idmaedpce)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        Else

            Call Grilla_Maedpce_KeyDown(Nothing, Nothing)

        End If

    End Sub

    Private Sub Grilla_Maedpce_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Maedpce.CellEndEdit

        Dim _Cabeza = Grilla_Maedpce.Columns(e.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)
        Dim _Tidp As String = _Fila.Cells("TIDP").Value
        Dim _Chk As Boolean = _Fila.Cells("Chk").Value
        Dim _Error = _Fila.Cells("Error").Value
        Dim _Exclamacion = _Fila.Cells("Exclamacion").Value

        If _Cabeza = "Chk" Then

            If _Chk And _Exclamacion Then

                If MessageBoxEx.Show(Me, "Este registro presenta reparos" & vbCrLf &
                                     "¿Desea marcarlo de todas maneras?", "Registro con reparos",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) <> DialogResult.Yes Then

                    _Fila.Cells("Chk").Value = False
                    Return

                End If

            End If

        End If

        If _Cabeza = "VADP" Then

            Dim _Saldo As Double = _Fila.Cells("SALDO").Value
            Dim _Vadp As Double = _Fila.Cells("VADP").Value

            If _Tidp = "ncv" Then

                If _Vadp > _Saldo Then

                    MessageBoxEx.Show(Me, "Valor máximo de la nota de crédito es de " & FormatCurrency(_Saldo, 0),
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    _Fila.Cells("VADP").Value = _Saldo

                End If

            End If

        End If

        Sb_Revisar_Fila(_Fila)
        Sb_Revisar_Fila2(_Fila)

        Grilla_Maedpce.Columns("VADP").ReadOnly = True
        Grilla_Maedpce.Columns("FEEMDP").ReadOnly = True
        Grilla_Maedpce.Columns("FEVEDP").ReadOnly = True

        Bar1.Enabled = True

    End Sub

    Private Sub Grilla_Maedpce_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles Grilla_Maedpce.KeyDown

        Dim _Cabeza = Grilla_Maedpce.Columns(Grilla_Maedpce.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)

        Dim _Idmaedpce As Integer = _Fila.Cells("IDMAEDPCE").Value
        Dim _Tidp As String = _Fila.Cells("TIDP").Value
        Dim _Vadp As Double = NuloPorNro(_Fila.Cells("VADP").Value, 0)

        Dim _Tecla As Keys

        If IsNothing(sender) Then
            _Tecla = Keys.Enter
        Else
            _Tecla = e.KeyValue
        End If

        Select Case _Tecla

            Case Keys.Down

                If Not String.IsNullOrEmpty(_Tidp) Then

                    Dim _Filas As Integer = Grilla_Maedpce.Rows.Count - 1

                    Dim _X_Columna As Integer = Grilla_Maedpce.CurrentCellAddress.X
                    Dim _Y_Fila As Integer = Grilla_Maedpce.CurrentCellAddress.Y

                    If _Filas = _Y_Fila Then

                        Sb_Nueva_Linea_De_Pago()
                        Grilla_Maedpce.CurrentCell = Grilla_Maedpce.Rows(_Filas + 1).Cells("TIDP")

                    End If

                End If

            Case Keys.Delete

                If _Cabeza = "Doc_Anticipo" Then

                    If CBool(_Fila.Cells("IDRSD").Value) Then

                        Call Btn_Doc_Asociado_Quitar_Click(Nothing, Nothing)

                        Return

                    End If

                End If

                Call Btn_Eliminar_Pago_Click(Nothing, Nothing)

            Case Keys.Enter

                If String.IsNullOrEmpty(_Tidp) And _Cabeza <> "TIDP" Then

                    MessageBoxEx.Show(Me, "Debe ingresar primero el tipo de pago", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return

                End If

                Select Case _Cabeza

                    Case "VADP"

                        If _Tidp = "ncv" Then

                            Beep()
                            ToastNotification.Show(Me, "NO SE PUEDE CAMBIAR EL VALOR DE LA NOTA DE CREDITO",
                                                       My.Resources.cross,
                                                      1 * 1000, eToastGlowColor.Red,
                                                       eToastPosition.MiddleCenter)

                            Return

                        End If

                        If CBool(_Idmaedpce) Then

                            Beep()
                            ToastNotification.Show(Me, "PAGO CON SALDO A FAVOR DESDE LA CTA. CTE. NO PUEDE SER MODIFICADO",
                                                       My.Resources.cross,
                                                      2 * 1000, eToastGlowColor.Red,
                                                       eToastPosition.MiddleCenter)

                            Return

                        End If

                        Grilla_Maedpce.Columns("VADP").ReadOnly = False

                        SendKeys.Send("{F2}")
                        If Not IsNothing(e) Then e.Handled = True
                        Grilla_Maedpce.BeginEdit(True)

                    Case "ENDP", "RAZON"

                        If Not String.IsNullOrEmpty(_Fila.Cells("ENDP").Value) Then

                            If MessageBoxEx.Show(Me, "¿Desea cambiar la entidad?", "Cambiar entidad",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                                Return
                            End If

                        End If

                        Call Btn_Cambiar_Entidad_Click(Nothing, Nothing)

                    Case "TIDP"

                        If String.IsNullOrEmpty(_Tidp) Then

                            Sb_Ingresar_Linea_de_pago()

                        End If

                    Case "CUDP", "NUCUDP"

                        Sb_Pago_Cheque_o_Tarjeta(_Tidp)
                        If Not IsNothing(e) Then e.Handled = True

                    Case "FEEMDP", "FEVEDP"

                        If _Tidp <> "EFV" And Not CBool(_Idmaedpce) Then

                            Dim _Aceptada As Boolean
                            Dim _Fecha As Date

                            Dim Fm As New Frm_Editor_Fecha
                            Fm.Fecha = _Fila.Cells(_Cabeza).Value
                            Fm.ShowDialog(Me)
                            _Aceptada = Fm.Aceptada
                            _Fecha = Fm.Fecha
                            Fm.Dispose()

                            If _Aceptada Then

                                _Fila.Cells(_Cabeza).Value = _Fecha
                                Sb_Revisar_Fila(_Fila)
                                Sb_Revisar_Fila2(_Fila)

                            End If

                        End If

                    Case "Doc_Anticipo"

                        Dim _Endp = _Fila.Cells("ENDP").Value
                        Dim _Archirsd = _Fila.Cells("ARCHIRSD").Value
                        Dim _Idrsd = _Fila.Cells("IDRSD").Value

                        If CBool(_Idrsd) Then

                            Dim _Idmaeedo = _Idrsd

                            Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
                            Fm.Btn_Ver_Orden_de_despacho.Visible = False
                            Fm.ShowDialog(Me)
                            Fm.Dispose()

                            Return

                        End If

                        Btn_Doc_Asociado_Ver.Visible = CBool(_Idrsd)
                        Btn_Doc_Asociado_Ver.Text = "Ver documento asociado (" & _Fila.Cells("Doc_Anticipo").Value & ")"
                        Btn_Doc_Asociado_Quitar.Visible = CBool(_Idrsd)
                        Btn_AnticipoNVV.Visible = Not CBool(_Idrsd)
                        Btn_CruceDocParaPago.Visible = Not CBool(_Idrsd)

                        ShowContextMenu(Menu_Contextual_02)

                        'Me.Enabled = False
                        'Sb_Buscar_NVV(_Fila)
                        'Me.Enabled = True

                    Case "REFANTI"

                        Dim _Referencia As String = _Fila.Cells("REFANTI").Value
                        Dim _Aceptar As Boolean = InputBox_Bk(Me, "Datos de la refencia del pago", "Referencia", _Referencia, False,, 80, True,, True)

                        If _Aceptar Then
                            _Fila.Cells("REFANTI").Value = _Referencia
                        End If

                        If Not IsNothing(e) Then e.Handled = True

                End Select

        End Select

    End Sub

    Sub Sb_Buscar_NVV(_Fila As DataGridViewRow)

        Dim _Cabeza = Grilla_Maedpce.Columns(Grilla_Maedpce.CurrentCell.ColumnIndex).Name

        Dim _Endp As String = _Fila.Cells("ENDP").Value
        Dim _Archirsd As String = _Fila.Cells("ARCHIRSD").Value
        Dim _Idrsd As Integer = _Fila.Cells("IDRSD").Value
        Dim _Vadp As Double = _Fila.Cells("VADP").Value

        If CBool(_Idrsd) Then

            Dim _Idmaeedo = _Idrsd

            Dim Fmv As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
            Fmv.Btn_Ver_Orden_de_despacho.Visible = False
            Fmv.ShowDialog(Me)
            Fmv.Dispose()

            Return

        End If

        If String.IsNullOrEmpty(_Endp.ToString.Trim) Then
            MessageBoxEx.Show(Me, "Debe seleccionar una entidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Chk_VerMontoExacto As New Command
        Chk_VerMontoExacto.Checked = False
        Chk_VerMontoExacto.Name = "Chk_VerMontoExacto"
        Chk_VerMontoExacto.Text = "Ver documentos solo con monto por " & FormatNumber(_Vadp, 0)

        Dim Chk_VerTodos As New Command
        Chk_VerTodos.Checked = False
        Chk_VerTodos.Name = "Chk_VerTodos"
        Chk_VerTodos.Text = "Ver todos los documentos"

        Dim _Opciones() As Command = {Chk_VerMontoExacto, Chk_VerTodos}

        Dim _Info As New TaskDialogInfo("Asociación de documentos",
                    eTaskDialogIcon.BlueFlag,
                    "Asociar notas de venta",
                    "Indique su opción",
                    eTaskDialogButton.Ok, eTaskDialogBackgroundColor.Red, _Opciones, Nothing, Nothing, Nothing, Nothing)

        Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

        If _Resultado <> eTaskDialogResult.Ok Then
            Return
        End If

        Dim _MontoExacto As String

        If Chk_VerTodos.Checked Then
            _MontoExacto = String.Empty
        ElseIf Chk_VerMontoExacto.Checked Then
            _MontoExacto = vbCrLf & "And Edo.VABRDO = " & De_Num_a_Tx_01(_Vadp, False, 5)
        Else
            MessageBoxEx.Show(Me, "Debe seleccionar una opción", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Sb_Buscar_NVV(_Fila)
            Return
        End If

        Dim _Filtro_Documentos = "('NVV','RES','PRO')"
        Dim _Mensaje As LsValiciones.Mensajes = Fx_SelecionarDocumento(_Endp, _MontoExacto, _Filtro_Documentos)

        If Not _Mensaje.EsCorrecto Then
            If Not _Mensaje.Cancelado Then
                MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            Return
        End If

        _Fila.Cells("ENDP").Value = CType(_Mensaje.Tag, DataRow).Item("ENDO")
        _Fila.Cells("RAZON").Value = CType(_Mensaje.Tag, DataRow).Item("NOKOEN")
        _Fila.Cells("ARCHIRSD").Value = "MAEEDO"
        _Fila.Cells("IDRSD").Value = CType(_Mensaje.Tag, DataRow).Item("IDMAEEDO")
        _Fila.Cells("Doc_Anticipo").Value = CType(_Mensaje.Tag, DataRow).Item("TIDO") & "-" & CType(_Mensaje.Tag, DataRow).Item("NUDO")
        _Fila.Cells("REFANTI").Value = String.Empty

        Return

        'Dim _Left_Join_MAEEN_ENDOFI_SUENDOFI As String
        'Dim _Campo_SUENDOFI As String

        'If _Sql.Fx_Exite_Campo("MAEEDO", "SUENDOFI") Then
        '    _Left_Join_MAEEN_ENDOFI_SUENDOFI = "Left Join MAEEN Mae2 On Edo.ENDOFI = Mae2.KOEN And Edo.SUENDOFI = Mae2.SUEN"
        '    _Campo_SUENDOFI = "Isnull(SUENDOFI,'') As SUENDOFI,"
        'Else
        '    _Left_Join_MAEEN_ENDOFI_SUENDOFI = "Left Join MAEEN Mae2 On Edo.ENDOFI = Mae2.KOEN "
        '    _Campo_SUENDOFI = String.Empty
        'End If

        'Dim _Otro_Filtro = "And Edo.EMPRESA='" & ModEmpresa & "' And Edo.TIDO IN ('NVV','RES','PRO') And Edo.ESDO Not In ('C','N') And" & vbCrLf &
        '                   "Not Exists (Select * From MAEDPCE Where MAEDPCE.ARCHIRSD = 'MAEEDO' And MAEDPCE.IDRSD = Edo.IDMAEEDO)" & _MontoExacto

        'Dim _CodPagador As String
        'Dim _FiltroEntidad As String

        '_CodPagador = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Entidades", "CodPagador", "CodEntidad = '" & _Endp & "'")

        'If Not String.IsNullOrWhiteSpace(_CodPagador) Then
        '    _FiltroEntidad = "And Edo.ENDO In (Select CodEntidad From " & _Global_BaseBk & "Zw_Entidades Where CodPagador = '" & _CodPagador & "')"
        'Else
        '    _FiltroEntidad = "And Edo.ENDO = '" & _Endp & "'"
        'End If

        'Consulta_Sql = My.Resources._24_Recursos.SQLQuery_Buscar_Docmuento
        'Consulta_Sql = Replace(Consulta_Sql, "#Empresa#", ModEmpresa)
        'Consulta_Sql = Replace(Consulta_Sql, "#CantidadDoc#", 1000)
        'Consulta_Sql = Replace(Consulta_Sql, "#TipoDocumento#", _Filtro_Documentos)
        'Consulta_Sql = Replace(Consulta_Sql, "#NroDocumento#", "")
        'Consulta_Sql = Replace(Consulta_Sql, "#Entidad#", _FiltroEntidad)
        'Consulta_Sql = Replace(Consulta_Sql, "#Fecha#", _Filtro_Fechas)
        'Consulta_Sql = Replace(Consulta_Sql, "#Estado#", "")
        'Consulta_Sql = Replace(Consulta_Sql, "#Funcionario#", "")
        'Consulta_Sql = Replace(Consulta_Sql, "#SucursalDocumento#", "--And Edo.SUDO = '" & ModSucursal & "'")
        'Consulta_Sql = Replace(Consulta_Sql, "#Producto#", "")
        'Consulta_Sql = Replace(Consulta_Sql, "#Orden#", "Order by IDMAEEDO Desc")

        'Consulta_Sql = Replace(Consulta_Sql, "#Left_Join_MAEEN_ENDOFI_SUENDOFI#", _Left_Join_MAEEN_ENDOFI_SUENDOFI)
        'Consulta_Sql = Replace(Consulta_Sql, "#Campo_SUENDOFI#", _Campo_SUENDOFI)

        'Consulta_Sql = Replace(Consulta_Sql, "#Otro_Filtro#", _Otro_Filtro)
        'Consulta_Sql = Replace(Consulta_Sql, "#ValesTransitorios#", "")
        'Consulta_Sql = Replace(Consulta_Sql, "#Observaciones#", "")

        'Dim _Tbl_Paso As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        'If Not CBool(_Tbl_Paso.Rows.Count) Then
        '    MessageBoxEx.Show(Me, "No hay documentos que mostrar", "Buscar documentos", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Return
        'End If

        'Consulta_Sql = Replace(Consulta_Sql, "", "Top #CantidadDoc#")

        'Dim Fm As New Frm_BuscarDocumento_Mt
        'Fm.BtnAceptar.Visible = False
        'Fm.Pro_Sql_Query = Consulta_Sql
        'Fm.CmbCantFilas.Text = 1000
        'Fm.Pro_Pago_a_Documento = True
        'Fm.Pro_Abrir_Seleccionado = False
        'Fm.CmbCantFilas.Enabled = False
        'Fm.Btn_Enviar_Correos_Masivos.Visible = False
        'Fm.SoloModoSeleccion = True
        'Fm.ShowDialog(Me)

        'Dim _IdMaeedo_Doc = Fm.Pro_IdMaeedo_Doc

        'Fm.Dispose()

        'If Convert.ToBoolean(_IdMaeedo_Doc) Then

        '    Consulta_Sql = "Select IDMAEEDO,TIDO,NUDO From MAEEDO Where IDMAEEDO = " & _IdMaeedo_Doc
        '    Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        '    _Fila.Cells("ARCHIRSD").Value = "MAEEDO"
        '    _Fila.Cells("IDRSD").Value = _Row.Item("IDMAEEDO")
        '    _Fila.Cells("Doc_Anticipo").Value = _Row.Item("TIDO") & "-" & _Row.Item("NUDO")
        '    _Fila.Cells("REFANTI").Value = String.Empty

        'End If

        'Fm.Dispose()

    End Sub

    Function Fx_SelecionarDocumento(_Endp As String,
                                    _FiltroMontoExacto As String,
                                    _FiltroDocuemntos As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes


        Dim _Filtro_Documentos = "And Edo.TIDO In " & _FiltroDocuemntos '('NVV','RES','PRO')"
        Dim _Filtro_Fechas = String.Empty

        Dim _Left_Join_MAEEN_ENDOFI_SUENDOFI As String
        Dim _Campo_SUENDOFI As String

        If _Sql.Fx_Exite_Campo("MAEEDO", "SUENDOFI") Then
            _Left_Join_MAEEN_ENDOFI_SUENDOFI = "Left Join MAEEN Mae2 On Edo.ENDOFI = Mae2.KOEN And Edo.SUENDOFI = Mae2.SUEN"
            _Campo_SUENDOFI = "Isnull(SUENDOFI,'') As SUENDOFI,"
        Else
            _Left_Join_MAEEN_ENDOFI_SUENDOFI = "Left Join MAEEN Mae2 On Edo.ENDOFI = Mae2.KOEN "
            _Campo_SUENDOFI = String.Empty
        End If

        Dim _Otro_Filtro As String

        If _FiltroDocuemntos.Contains("NVV") Then
            _Otro_Filtro = "And Edo.ESDO Not In ('C','N')" & vbCrLf &
                           "And Not Exists (Select * From MAEDPCE Where MAEDPCE.ARCHIRSD = 'MAEEDO' And MAEDPCE.IDRSD = Edo.IDMAEEDO)" & _FiltroMontoExacto
        End If

        If _FiltroDocuemntos.Contains("FCV") Then
            _Otro_Filtro = "And VAABDO = 0 And ESPGDO = 'P' " & vbCrLf & _FiltroMontoExacto
        End If

        Dim _CodPagador As String
        Dim _FiltroEntidad As String

        _CodPagador = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Entidades", "CodPagador", "CodEntidad = '" & _Endp & "'")

        If Not String.IsNullOrWhiteSpace(_CodPagador) Then
            _FiltroEntidad = "And Edo.ENDO In (Select CodEntidad From " & _Global_BaseBk & "Zw_Entidades Where CodPagador = '" & _CodPagador & "')"
        Else
            _FiltroEntidad = "And Edo.ENDO = '" & _Endp & "'"
        End If

        Consulta_Sql = My.Resources._24_Recursos.SQLQuery_Buscar_Docmuento
        Consulta_Sql = Replace(Consulta_Sql, "#Empresa#", ModEmpresa)
        Consulta_Sql = Replace(Consulta_Sql, "#CantidadDoc#", 1000)
        Consulta_Sql = Replace(Consulta_Sql, "#TipoDocumento#", _Filtro_Documentos)
        Consulta_Sql = Replace(Consulta_Sql, "#NroDocumento#", "")
        Consulta_Sql = Replace(Consulta_Sql, "#Entidad#", _FiltroEntidad)
        Consulta_Sql = Replace(Consulta_Sql, "#Fecha#", _Filtro_Fechas)
        Consulta_Sql = Replace(Consulta_Sql, "#Estado#", "")
        Consulta_Sql = Replace(Consulta_Sql, "#Funcionario#", "")
        Consulta_Sql = Replace(Consulta_Sql, "#SucursalDocumento#", "--And Edo.SUDO = '" & ModSucursal & "'")
        Consulta_Sql = Replace(Consulta_Sql, "#Producto#", "")
        Consulta_Sql = Replace(Consulta_Sql, "#Orden#", "Order by IDMAEEDO Desc")

        Consulta_Sql = Replace(Consulta_Sql, "#Left_Join_MAEEN_ENDOFI_SUENDOFI#", _Left_Join_MAEEN_ENDOFI_SUENDOFI)
        Consulta_Sql = Replace(Consulta_Sql, "#Campo_SUENDOFI#", _Campo_SUENDOFI)

        Consulta_Sql = Replace(Consulta_Sql, "#Otro_Filtro#", _Otro_Filtro)
        Consulta_Sql = Replace(Consulta_Sql, "#ValesTransitorios#", "")
        Consulta_Sql = Replace(Consulta_Sql, "#Observaciones#", "")

        Dim _Tbl_Paso As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        If Not CBool(_Tbl_Paso.Rows.Count) Then
            'MessageBoxEx.Show(Me, "No hay documentos que mostrar", "Buscar documentos", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            _Mensaje.Detalle = "Buscar documentos"
            _Mensaje.Mensaje = "No hay documentos que mostrar"
            _Mensaje.EsCorrecto = False
            _Mensaje.Icono = MessageBoxIcon.Stop
            Return _Mensaje
        End If

        Consulta_Sql = Replace(Consulta_Sql, "", "Top #CantidadDoc#")

        Dim Fm As New Frm_BuscarDocumento_Mt
        Fm.BtnAceptar.Visible = False
        Fm.Pro_Sql_Query = Consulta_Sql
        Fm.CmbCantFilas.Text = 1000
        Fm.Pro_Pago_a_Documento = True
        Fm.Pro_Abrir_Seleccionado = False
        Fm.CmbCantFilas.Enabled = False
        Fm.Btn_Enviar_Correos_Masivos.Visible = False
        Fm.SoloModoSeleccion = True
        Fm.ShowDialog(Me)

        Dim _IdMaeedo_Doc = Fm.Pro_IdMaeedo_Doc

        Fm.Dispose()

        If Convert.ToBoolean(_IdMaeedo_Doc) Then

            Consulta_Sql = "Select IDMAEEDO,TIDO,NUDO,ENDO,NOKOEN" & vbCrLf &
                           "From MAEEDO" & vbCrLf &
                           "Inner Join MAEEN On KOEN = ENDO And SUEN = SUENDO " & vbCrLf &
                           "Where IDMAEEDO = " & _IdMaeedo_Doc
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

            _Mensaje.EsCorrecto = True
            _Mensaje.Tag = _Row

            '_Fila.Cells("ARCHIRSD").Value = "MAEEDO"
            '_Fila.Cells("IDRSD").Value = _Row.Item("IDMAEEDO")
            '_Fila.Cells("Doc_Anticipo").Value = _Row.Item("TIDO") & "-" & _Row.Item("NUDO")
            '_Fila.Cells("REFANTI").Value = String.Empty
        Else

            _Mensaje.Cancelado = True

        End If

        Fm.Dispose()

        Return _Mensaje

    End Function

    Sub Sb_Buscar_FCVBLV(_Fila As DataGridViewRow)

        Dim _Cabeza = Grilla_Maedpce.Columns(Grilla_Maedpce.CurrentCell.ColumnIndex).Name

        Dim _Endp = _Fila.Cells("ENDP").Value
        Dim _Archirsd = _Fila.Cells("ARCHIRSD").Value
        Dim _Idrsd = _Fila.Cells("IDRSD").Value
        Dim _Vadp As Double = _Fila.Cells("VADP").Value

        If CBool(_Idrsd) Then

            Dim _Idmaeedo = _Idrsd

            Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
            Fm.Btn_Ver_Orden_de_despacho.Visible = False
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Return

        End If

        If String.IsNullOrEmpty(_Endp.ToString.Trim) Then
            MessageBoxEx.Show(Me, "Debe seleccionar una entidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _CodPagador As String
        Dim _FiltroEntidad As String

        _CodPagador = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Entidades", "CodPagador", "CodEntidad = '" & _Endp & "'")

        If Not String.IsNullOrWhiteSpace(_CodPagador) Then
            _FiltroEntidad = "And ENDO In (Select CodEntidad From " & _Global_BaseBk & "Zw_Entidades Where CodPagador = '" & _CodPagador & "')"
        Else
            _FiltroEntidad = "And ENDO = '" & _Endp & "'"
        End If

        Consulta_Sql = "Select IDMAEEDO,TIDO,NUDO,ENDO,NOKOEN,VABRDO,ESPGDO" & vbCrLf &
                       "From MAEEDO Edo" & vbCrLf &
                       "Inner Join MAEEN Ent On Edo.ENDO = Ent.KOEN And Edo.SUENDO = Ent.SUEN" & vbCrLf &
                       "Where TIDO In ('FCV','BLV') " & _FiltroEntidad &
                       "And VAABDO = 0 " &
                       "And ESPGDO = 'P' " &
                       "And NUDONODEFI = 0 " &
                       "And VABRDO = " & De_Num_a_Tx_01(_Vadp, False, 5)
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        If Not CBool(_Tbl.Rows.Count) Then
            MessageBoxEx.Show(Me, "No hay documentos que mostrar", "Buscar documentos", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If _Tbl.Rows.Count = 1 Then

            Dim _Idmaeedo As Integer = _Tbl.Rows(0).Item("IDMAEEDO")
            Dim _Endo As String = _Tbl.Rows(0).Item("ENDO").ToString.Trim
            Dim _Nokoen As String = _Tbl.Rows(0).Item("NOKOEN").ToString.Trim

            If MessageBoxEx.Show(Me, "Se encontro el documento " & _Tbl.Rows(0).Item("TIDO") & "-" & _Tbl.Rows(0).Item("NUDO") & vbCrLf &
                                "Entidad: " & _Endo & " - " & _Nokoen & vbCrLf &
                                 "¿Confirma el cruce del pago para este documento?",
                                 "Cruzar pago", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
                Return
            End If

            _Fila.Cells("ARCHIRSD").Value = "MAEEDO"
            _Fila.Cells("IDRSD").Value = _Idmaeedo
            _Fila.Cells("ENDP").Value = _Endo
            _Fila.Cells("RAZON").Value = _Nokoen
            _Fila.Cells("Doc_Anticipo").Value = _Tbl.Rows(0).Item("TIDO") & "-" & _Tbl.Rows(0).Item("NUDO")
            _Fila.Cells("REFANTI").Value = "*** Cruce automático ***"
            _Fila.Cells("CruzarPagoAuto").Value = True

            Return

        End If

        MessageBoxEx.Show(Me, "Hay varios documentos disponibles." & vbCrLf &
                          "Puede seleccionar el documento deseado en la ventana posterior.",
                          "Buscar documentos", MessageBoxButtons.OK, MessageBoxIcon.Warning)


        Dim _MontoExacto As String = vbCrLf & "And Edo.VABRDO = " & De_Num_a_Tx_01(_Vadp, False, 5)

        Dim _Filtro_Documentos = "('FCV','BLV')"
        Dim _Mensaje As LsValiciones.Mensajes = Fx_SelecionarDocumento(_Endp, _MontoExacto, _Filtro_Documentos)

        If Not _Mensaje.EsCorrecto Then
            If _Mensaje.Cancelado Then
                Return
            End If
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        _Fila.Cells("ARCHIRSD").Value = "MAEEDO"
        _Fila.Cells("IDRSD").Value = CType(_Mensaje.Tag, DataRow).Item("IDMAEEDO")
        _Fila.Cells("Doc_Anticipo").Value = CType(_Mensaje.Tag, DataRow).Item("TIDO") & "-" & CType(_Mensaje.Tag, DataRow).Item("NUDO")
        _Fila.Cells("REFANTI").Value = "*** Cruce automático ***"
        _Fila.Cells("CruzarPagoAuto").Value = True
        _Fila.Cells("Exclamacion").Value = False

        Sb_Revisar_Fila(_Fila)
        Sb_Revisar_Fila2(_Fila)

    End Sub

    Private Sub Grilla_Maedpce_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grilla_Maedpce.DataError

        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)
        Dim _Cabeza = Grilla_Maedpce.Columns(Grilla_Maedpce.CurrentCell.ColumnIndex).Name

        Select Case _Cabeza

            Case "FEEMDP", "FEVEDP"

                _Fila.Cells(_Cabeza).Value = Date.Now

        End Select

        MessageBoxEx.Show(Me, e.Exception.Message, "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Stop)

    End Sub

    Sub Sb_Ingresar_Linea_de_pago()

        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)
        Dim _Tidp As String
        Dim _Tipo_Pago As Integer
        Dim _Tidp_Seleccionado As Boolean
        Dim _Row_Tidp As DataRow

        Dim _Filtro_Extra_Sql As String = "And CodigoTabla In ('DEP','ATB')"

        Dim Fm As New Frm_Pagos_Seleccion_Tipo_Pago(_Tipo_Pago)
        Fm.Pro_Filtro_Extra_Sql = _Filtro_Extra_Sql
        Fm.ShowDialog(Me)
        _Tidp_Seleccionado = Fm.Pro_Precio_Tidp_Seleccionado
        _Row_Tidp = Fm.Pro_Row_Tidp
        Fm.Dispose()

        If _Tidp_Seleccionado Then

            _Tidp = _Row_Tidp.Item("TIDP")

            Sb_Pago_Cheque_o_Tarjeta(_Tidp)

        End If

    End Sub

    Private Sub Btn_Importar_Pagos_Click(sender As Object, e As EventArgs) Handles Btn_Importar_Pagos.Click

        Dim _Tbl_Resultado As DataTable

        Dim Fm As New Frm_Pagos_CtasEntidades_Expor_Banco_ImpExcel
        Fm.ShowDialog(Me)
        If Fm.Aceptar Then _Tbl_Resultado = Fm.Tbl_Resultado
        Fm.Dispose()

        Dim _Contador = 0
        Dim _Filas = 0

        If Not IsNothing(_Tbl_Resultado) Then

            Sb_Tabla_Maedpce()

            _Filas = _Tbl_Resultado.Rows.Count

            Barra_Progreso.Maximum = 100
            Barra_Progreso.Visible = True

            Me.Refresh()

            For Each _Fl As DataRow In _Tbl_Resultado.Rows

                System.Windows.Forms.Application.DoEvents()

                Dim _NewFila As DataRow

                _NewFila = Fx_Nueva_Linea_De_Pago(_Tbl_Maedpce)

                Dim _Tidp As String = _Fl.Item("TIDP")
                Dim _Notidp As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones", "NombreTabla", "Tabla Like 'TIDP_%' And CodigoTabla = '" & _Tidp & "'")

                Dim _Endp As String = _Fl.Item("ENDP")
                Dim _Razon = String.Empty

                Consulta_Sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Endp & "'"
                Dim _Row_Entidas As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                If IsNothing(_Row_Entidas) Then
                    _Endp = String.Empty
                Else
                    _Razon = _Row_Entidas.Item("NOKOEN").ToString.Trim
                End If

                Dim _Emdp As String = _Fl.Item("EMDP")
                Dim _Cudp As String = _Fl.Item("CUDP")
                Dim _Nokoendp As String = String.Empty

                Consulta_Sql = "Select * From TABENDP Where TIDPEN = 'CH' And KOENDP = '" & _Emdp & "' And CTACTE = '" & _Cudp & "'"
                Dim _Row_Cuenta As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                If IsNothing(_Row_Cuenta) Then
                    _Emdp = String.Empty
                    _Cudp = String.Empty
                Else
                    _Nokoendp = _Row_Cuenta.Item("NOKOENDP").ToString.Trim
                End If

                With _NewFila

                    .Item("TIDP") = _Tidp
                    .Item("NOTIDP") = _Notidp
                    .Item("NUDP") = _Fl.Item("NUDP")
                    .Item("ENDP") = _Endp
                    .Item("RAZON") = _Razon
                    .Item("EMDP") = _Emdp
                    .Item("SUEMDP") = _Fl.Item("SUEMDP")
                    .Item("CUDP") = _Cudp
                    .Item("NUCUDP") = _Fl.Item("NUCUDP")
                    .Item("VADP") = _Fl.Item("VADP")
                    .Item("FEEMDP") = _Fl.Item("FEEMDP")
                    .Item("FEVEDP") = _Fl.Item("FEVEDP")
                    .Item("REFANTI") = _Fl.Item("REFANTI")
                    .Item("NOKOENDP") = _Nokoendp

                End With

                _Tbl_Maedpce.Rows.Add(_NewFila)

                Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(_Contador)

                Sb_Revisar_Fila(_Fila)

                Barra_Progreso.Value = ((_Contador * 100) / _Filas) 'Mas
                _Contador += 1

            Next

        End If

        _Filas = Grilla_Maedpce.RowCount
        _Contador = 0

        Barra_Progreso.Maximum = 100
        Barra_Progreso.Visible = True

        Dim _Error As Boolean

        For Each _Fila As DataGridViewRow In Grilla_Maedpce.Rows

            Sb_Revisar_Fila2(_Fila)

            Barra_Progreso.Value = ((_Contador * 100) / _Filas)
            _Contador += 1

        Next

        Barra_Progreso.Value = 0
        Barra_Progreso.Visible = False

        Me.Refresh()

    End Sub

    Private Sub Btn_Grabar_Autorizacion_Click(sender As Object, e As EventArgs) Handles Btn_Grabar_Autorizacion.Click

        Dim _Checados = 0

        For Each _Fl As DataRow In _Tbl_Maedpce.Rows
            If NuloPorNro(_Fl.Item("Chk"), False) Then
                _Checados += 1
            End If
        Next

        If Not CBool(_Checados) Then
            MessageBoxEx.Show(Me, "No hay registros seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Levantados = 0
        Dim _Cl_Pagar As New Clas_Pagar

        If MessageBoxEx.Show(Me, "¿Esta seguro de levantar los registros a la caja: " & ModCaja & " - " & _Row_Caja.Item("NOKOCJ").ToString.Trim & " ?", "Levantar registros",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            For Each _Fila As DataGridViewRow In Grilla_Maedpce.Rows

                Dim _Idmaedpce_new = CBool(_Fila.Cells("IDMAEDPCE").Value)
                Dim _Id = _Fila.Cells("Id").Value
                Dim _Chk = _Fila.Cells("Chk").Value

                If _Chk And Not _Idmaedpce_new Then

                    For Each _Fl As DataRow In _Tbl_Maedpce.Rows

                        If _Fl.Item("Id") = _Id Then

                            Dim _Idmaedpce = _Cl_Pagar.Fx_Crear_Pago_Anticipo(_Fl)

                            If CBool(_Idmaedpce) Then

                                If _Fl.Item("CruzarPagoAuto") Then

                                    Dim _Idmaeedo As Integer = _Fila.Cells("IDRSD").Value
                                    Dim _Vadp As Double = _Fila.Cells("VADP").Value

                                    _Cl_Pagar.Fx_Crear_Pago_MAEDPCD(_Idmaeedo, _Idmaedpce, _Vadp)

                                End If

                                _Fila.Cells("IDMAEDPCE").Value = _Idmaedpce

                                Sb_Revisar_Fila(_Fila)
                                Sb_Revisar_Fila2(_Fila)

                                _Levantados += 1

                            End If

                            Exit For

                        End If

                    Next

                End If

            Next

            If CBool(_Levantados) Then

                Chk_Seleccionar_Todo.Checked = False
                Chk_Seleccionar_Todo_CheckedChanged(Nothing, Nothing)

                MessageBoxEx.Show(Me, FormatNumber(_Levantados, 0) & " Registro(s) levantado(s) correctamente", "Grabar",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If

    End Sub

    Private Sub Grilla_Maedpce_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Maedpce.CellEnter

        Try

            Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)

            Dim _Tidp = _Fila.Cells("TIDP").Value.ToString.Trim
            Dim _Notidp = _Fila.Cells("NOTIDP").Value.ToString.Trim
            Dim _Nokoendp = _Fila.Cells("NOKOENDP").Value.ToString.Trim
            Dim _Razon = _Fila.Cells("RAZON").Value.ToString.Trim
            Dim _Cudp = _Fila.Cells("CUDP").Value.ToString.Trim
            Dim _Nucudp = _Fila.Cells("NUCUDP").Value.ToString.Trim
            Dim _Vadp = _Fila.Cells("VADP").Value
            Dim _Refanti = _Fila.Cells("Refanti").Value

            Dim _Error As Boolean = _Fila.Cells("Error").Value
            Dim _Exclamacion As Boolean = _Fila.Cells("Exclamacion").Value

            Dim _Observacion = _Fila.Cells("Observacion").Value.ToString.Trim

            Lbl_Razon_Social.Text = _Razon
            Lbl_Tipo_Documento.Text = _Tidp & " - " & _Notidp
            Lbl_Banco_Cta_Cte.Text = _Nokoendp & ", Cta. Cte: " & _Cudp & ", Nro: " & _Nucudp & ", Monto: " & FormatCurrency(_Vadp, 0)
            Lbl_Referencia.Text = _Refanti

            If Not String.IsNullOrEmpty(_Observacion) Then

                If _Error Then Lbl_Informacion.Text = "Problemas: " & _Observacion
                If _Exclamacion Then Lbl_Informacion.Text = "Reparos: " & _Observacion

                Lbl_Informacion.ForeColor = _Rojo
            Else
                Lbl_Informacion.Text = String.Empty
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Grilla_Maedpce_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles Grilla_Maedpce.CellBeginEdit

        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)
        Dim _Cabeza = Grilla_Maedpce.Columns(Grilla_Maedpce.CurrentCell.ColumnIndex).Name

        Dim _Idmaedpce = _Fila.Cells("IDMAEDPCE").Value
        Dim _Tidp = _Fila.Cells("TIDP").Value
        Dim _Error = _Fila.Cells("Error").Value
        Dim _Exclamacion = _Fila.Cells("Exclamacion").Value

        If CBool(_Idmaedpce) Then
            MessageBoxEx.Show(Me, "Este registro ya esta ingresado al sistema", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Cancel = True
            Return
        End If

        If _Error Or String.IsNullOrEmpty(_Tidp) Then

            If _Error Then MessageBoxEx.Show(Me, "Este registro presenta problemas no se puede levantar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            _Fila.Cells("Chk").Value = False
            e.Cancel = True

        End If

    End Sub

    Private Sub Grilla_Maedpce_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla_Maedpce.CellMouseUp
        Grilla_Maedpce.EndEdit()
    End Sub

    Private Sub Chk_Seleccionar_Todo_CheckedChanged(sender As Object, e As EventArgs)

        Dim _Errores = 0

        If Chk_Seleccionar_Todo.Checked Then
            If _Tbl_Maedpce.Rows.Count = 1 Then
                If String.IsNullOrEmpty(_Tbl_Maedpce.Rows(0).Item("Tidp")) Then
                    Beep()
                    Chk_Seleccionar_Todo.Checked = False
                    Return
                End If
            End If
        End If

        For Each _Fila As DataGridViewRow In Grilla_Maedpce.Rows

            Dim _Error = _Fila.Cells("Error").Value
            Dim _Exclamacion = _Fila.Cells("Exclamacion").Value

            If _Error Or _Exclamacion Then
                _Errores += 1
                _Fila.Cells("Chk").Value = False
            Else
                _Fila.Cells("Chk").Value = Chk_Seleccionar_Todo.Checked
            End If

        Next

        If Chk_Seleccionar_Todo.Checked Then

            If Not CBool(_Errores) Then
                MessageBoxEx.Show(Me, "No existen reparos, datos seleccionados correctemente", "Selección masiva",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBoxEx.Show(Me, "Existen filas con reparos, no se seleccionaron todos los registros", "Selección masiva",
                                  MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        End If

    End Sub

    Private Sub Btn_Editar_Pago_Click(sender As Object, e As EventArgs) Handles Btn_Editar_Pago.Click
        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)
        Dim _Tidp As String = _Fila.Cells("TIDP").Value
        Sb_Pago_Cheque_o_Tarjeta(_Tidp)
    End Sub

    Private Sub Btn_Eliminar_Pago_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar_Pago.Click

        If MessageBoxEx.Show(Me, "¿Esta seguro de quitar este registro del tratamiento?", "Quitar registro",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Grilla_Maedpce.Rows.RemoveAt(Grilla_Maedpce.CurrentRow.Index)
            Grilla_Maedpce.Refresh()

            If Grilla_Maedpce.Rows.Count = 0 Then

                Sb_Tabla_Maedpce()
                Sb_Nueva_Linea_De_Pago()

            End If

        End If

    End Sub

    Private Sub Btn_Cambiar_Entidad_Click(sender As Object, e As EventArgs) Handles Btn_Cambiar_Entidad.Click

        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)

        Dim _RowEntidad As DataRow
        Dim Fm_Ent As New Frm_BuscarEntidad_Mt(False)
        Fm_Ent.Text = "SELECCIONE EL CLIENTE"
        Fm_Ent.ShowDialog(Me)
        If Fm_Ent.Pro_Entidad_Seleccionada Then _RowEntidad = Fm_Ent.Pro_RowEntidad
        Fm_Ent.Dispose()

        If Not IsNothing(_RowEntidad) Then

            _Fila.Cells("ENDP").Value = _RowEntidad.Item("KOEN")
            _Fila.Cells("RAZON").Value = _RowEntidad.Item("NOKOEN")
            _Fila.Cells("Observacion").Value = String.Empty

            _Fila.Cells("ARCHIRSD").Value = String.Empty
            _Fila.Cells("IDRSD").Value = 0
            _Fila.Cells("Doc_Anticipo").Value = String.Empty
            _Fila.Cells("REFANTI").Value = String.Empty
            _Fila.Cells("CruzarPagoAuto").Value = False

            Sb_Revisar_Fila(_Fila)
            Sb_Revisar_Fila2(_Fila)

        End If

    End Sub

    Private Sub Btn_Ver_Cta_Cte_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Cta_Cte.Click

        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)
        Dim _Koen = _Fila.Cells("ENDP").Value
        Dim _Razon = _Fila.Cells("RAZON").Value

        Dim _Grabar As Boolean

        Dim Fm As New Frm_Pagos_Generales(Frm_Pagos_Generales.Enum_Tipo_Pago.Clientes)
        Fm.Koen = _Koen
        Fm.BtnActualizarLista.Visible = False
        Fm.Cerrar_al_grabar = True
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then
            Sb_Revisar_Fila(_Fila)
        End If

    End Sub

    Private Sub Btn_Doc_Asociado_Ver_Click(sender As Object, e As EventArgs) Handles Btn_Doc_Asociado_Ver.Click

        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)

        Dim _Idrsd = _Fila.Cells("IDRSD").Value

        If CBool(_Idrsd) Then

            Dim _Idmaeedo = _Idrsd

            Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
            Fm.Btn_Ver_Orden_de_despacho.Visible = False
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Return

        End If

    End Sub

    Private Sub Btn_Doc_Asociado_Quitar_Click(sender As Object, e As EventArgs) Handles Btn_Doc_Asociado_Quitar.Click

        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)

        If MessageBoxEx.Show(Me, "¿Esta seguro de quitar el documento " & _Fila.Cells("Doc_Anticipo").Value & " del registro?", "Quitar registro",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            _Fila.Cells("IDRSD").Value = 0
            _Fila.Cells("Doc_Anticipo").Value = String.Empty
            _Fila.Cells("ARCHIRSD").Value = String.Empty
            _Fila.Cells("REFANTI").Value = String.Empty
            _Fila.Cells("CruzarPagoAuto").Value = False

        End If

    End Sub


    Private Sub Grilla_Maedpce_MouseDown(sender As Object, e As MouseEventArgs) Handles Grilla_Maedpce.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then

            With sender

                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)

                If Hitest.Type = DataGridViewHitTestType.Cell Then

                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)

                    Dim _Idmaedpce As Boolean = _Fila.Cells("IDMAEDPCE").Value
                    Dim _Idrsd As Boolean = _Fila.Cells("IDRSD").Value
                    Dim _Endp As Boolean = Not String.IsNullOrEmpty(_Fila.Cells("ENDP").Value)
                    'Dim _Tidp As Boolean = Not String.IsNullOrEmpty(_Fila.Cells("TIDP").Value)

                    Dim _Cabeza = Grilla_Maedpce.Columns(Grilla_Maedpce.CurrentCell.ColumnIndex).Name

                    If String.IsNullOrEmpty(_Fila.Cells("TIDP").Value) Then
                        Return
                    End If

                    If _Idmaedpce Then

                        Btn_Cambiar_Entidad.Enabled = False
                        Btn_Ver_Cta_Cte.Enabled = True
                        Btn_Cambiar_Entidad.Visible = False
                        Btn_Eliminar_Pago.Visible = False
                        Btn_Editar_Pago.Visible = False

                        ShowContextMenu(Menu_Contextual_01)
                        Return

                    End If

                    If _Cabeza = "Doc_Anticipo" And Not _Idmaedpce Then

                        Btn_Doc_Asociado_Ver.Visible = _Idrsd
                        Btn_Doc_Asociado_Ver.Text = "Ver documento asociado (" & _Fila.Cells("Doc_Anticipo").Value & ")"
                        Btn_Doc_Asociado_Quitar.Visible = _Idrsd

                        Btn_AnticipoNVV.Visible = Not _Idrsd
                        Btn_CruceDocParaPago.Visible = Not _Idrsd

                        ShowContextMenu(Menu_Contextual_02)

                    Else

                        'If _Tidp Then

                        Btn_Cambiar_Entidad.Enabled = _Endp
                        Btn_Ver_Cta_Cte.Enabled = _Endp

                        Btn_Cambiar_Entidad.Visible = Not CBool(_Idmaedpce)
                        Btn_Eliminar_Pago.Visible = Not CBool(_Idmaedpce)
                        Btn_Editar_Pago.Visible = Not CBool(_Idmaedpce)

                        ShowContextMenu(Menu_Contextual_01)

                        'End If

                    End If

                End If

            End With

        End If

    End Sub

    Private Sub Btn_Limpiar_Click(sender As Object, e As EventArgs) Handles Btn_Limpiar.Click

        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)

        If Not String.IsNullOrEmpty(_Fila.Cells("TIDP").Value) Then

            Dim dlg As System.Windows.Forms.DialogResult =
                      MessageBoxEx.Show(Me, "¿Esta seguro de querer limipar todo el documento?",
                             "Limpiar documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, Me.TopMost)

            If dlg = System.Windows.Forms.DialogResult.Yes Then
                Sb_Tabla_Maedpce()
                Sb_Nueva_Linea_De_Pago()
            End If

        End If

    End Sub

    Sub Sb_Pago_Cheque_o_Tarjeta(_Tidp As String)

        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)
        Dim _Tipo_Pago As Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago
        Dim _Row_Tabendp As DataRow

        Dim _Mostrar_Cuentas_Del_Cliente_Proveedor As Boolean
        Dim _Mostrar_Cuentas_De_La_Empresa As Boolean

        If _Tidp = "DEP" Then

            _Tipo_Pago = Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.DP
            _Mostrar_Cuentas_De_La_Empresa = True

        ElseIf _Tidp = "ATB" Then

            _Tipo_Pago = Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.PT
            _Mostrar_Cuentas_De_La_Empresa = True

        End If

        Dim Fm As New Frm_Pagos_Seleccionar_CH_TJ(_Tipo_Pago, _Row_Tabendp, Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_De_Pago.Cliente, 0)
        Fm.Mostrar_Cuentas_De_La_Empresa = _Mostrar_Cuentas_De_La_Empresa
        Fm.Mostrar_Cuentas_Del_Cliente_Proveedor = _Mostrar_Cuentas_Del_Cliente_Proveedor
        Fm.Koen = _Fila.Cells("ENDP").Value
        Fm.Btn_Limpiar.Visible = String.IsNullOrEmpty(_Fila.Cells("ENDP").Value)
        Fm.Pro_Emdp = _Fila.Cells("EMDP").Value
        Fm.Pro_Suemdp = _Fila.Cells("SUEMDP").Value
        Fm.Pro_Cudp = _Fila.Cells("CUDP").Value
        Fm.Pro_Nucudp = _Fila.Cells("NUCUDP").Value
        Fm.Pro_Cuotas = _Fila.Cells("CUOTAS").Value
        Fm.Pro_Monto = _Fila.Cells("VADP").Value
        Fm.Txt_EMDP_Documento.Text = _Fila.Cells("NOKOENDP").Value

        Fm.Btn_Traer_Saldo.Visible = False
        Fm.ShowDialog(Me)

        If Fm.Pro_Aceptar Then

            If String.IsNullOrEmpty(_Fila.Cells("ENDP").Value) Then

                MessageBoxEx.Show(Me, "A continuación debera seleccionar una entidad para el documento de pago", "Ingresar Entidad",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                Dim _RowEntidad As DataRow
                Dim Fm_Ent As New Frm_BuscarEntidad_Mt(False)
                Fm_Ent.Text = "SELECCIONE EL CLIENTE"
                Fm_Ent.ShowDialog(Me)
                If Fm_Ent.Pro_Entidad_Seleccionada Then _RowEntidad = Fm_Ent.Pro_RowEntidad
                Fm_Ent.Dispose()

                If Not IsNothing(_RowEntidad) Then

                    _Fila.Cells("ENDP").Value = _RowEntidad.Item("KOEN")
                    _Fila.Cells("RAZON").Value = _RowEntidad.Item("NOKOEN")

                End If

            End If

            _Fila.Cells("ARCHIRSD").Value = String.Empty
            _Fila.Cells("IDRSD").Value = 0
            _Fila.Cells("Doc_Anticipo").Value = String.Empty
            _Fila.Cells("REFANTI").Value = String.Empty
            _Fila.Cells("CruzarPagoAuto").Value = False

            _Fila.Cells("EMDP").Value = Fm.Pro_Emdp
            _Fila.Cells("SUEMDP").Value = Fm.Pro_Suemdp
            _Fila.Cells("CUDP").Value = Fm.Pro_Cudp
            _Fila.Cells("NUCUDP").Value = Fm.Pro_Nucudp
            _Fila.Cells("CUOTAS").Value = Fm.Pro_Cuotas
            _Fila.Cells("VADP").Value = Fm.Pro_Monto

            _Fila.Cells("TIDP").Value = Fm.Pro_Tipd
            _Fila.Cells("NOTIDP").Value = Fm.Pro_NoTipd
            '_Fila.Cells("ESPGDP").Value = "P"
            _Fila.Cells("NOKOENDP").Value = Fm.Txt_EMDP_Documento.Text.Trim

            Sb_Revisar_Fila(_Fila)
            Sb_Revisar_Fila2(_Fila)

            If _Fila.Cells("Error").Value Then
                _Fila.Cells("Chk").Value = False
            End If

            If _Tidp = "CHV" Then
                Grilla_Maedpce.CurrentCell = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index).Cells("FEVEDP")
            Else
                Grilla_Maedpce.CurrentCell = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index).Cells("VADP")
            End If

        End If

    End Sub

    Sub Sb_Revisar_Fila(_Fila As DataGridViewRow)

        Dim _Idmaedpce = _Fila.Cells("IDMAEDPCE").Value
        Dim _Endp = _Fila.Cells("ENDP").Value
        Dim _Tipd = _Fila.Cells("TIDP").Value
        Dim _Cudp = _Fila.Cells("CUDP").Value
        Dim _Nucudp = _Fila.Cells("NUCUDP").Value
        Dim _Emdp = _Fila.Cells("EMDP").Value
        Dim _Vadp = De_Num_a_Tx_01(_Fila.Cells("VADP").Value, False, 5)


        Dim _Feemdp As Date
        Dim _Fevedp As Date

        Dim _Nokoendp = _Fila.Cells("NOKOENDP").Value
        Dim _Error As Boolean
        Dim _Exclamacion As Boolean

        _Fila.Cells("Error").Value = False
        _Fila.Cells("Exclamacion").Value = False
        _Fila.Cells("Observacion").Value = String.Empty

        Consulta_Sql = "Select * From MAEDPCE 
                        Where TIDP = '" & _Tipd & "' And ENDP = '" & _Endp & "' And EMDP = '" & _Emdp & "' And CUDP = '" & _Cudp & "' And NUCUDP = '" & _Nucudp & "' And VADP = " & _Vadp
        Dim _Row_Maedpce As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Dim _Color As Color

        If IsNothing(_Row_Maedpce) Then

            If Global_Thema = Enum_Themas.Oscuro Then
                _Color = Color.White
            Else
                _Color = Color.Black
            End If

        Else

            If Not CBool(_Idmaedpce) Then
                _Exclamacion = True
                _Fila.Cells("Exclamacion").Value = True
                _Fila.Cells("Observacion").Value = "YA EXISTE UN PAGO PARA ESTE CLIENTE CON LOS MISMOS DATOS DE LA FILA"
            End If

        End If

        Dim _Cabeza = Grilla_Maedpce.Columns(Grilla_Maedpce.CurrentCell.ColumnIndex).Name

        _Fila.DefaultCellStyle.ForeColor = _Color
        _Fila.Cells(_Cabeza).Style.ForeColor = _Color

        If String.IsNullOrEmpty(_Endp.ToString.Trim) Then
            _Error = True
            _Fila.Cells("Error").Value = True
            _Fila.Cells("Observacion").Value = " - FALTA CLIENTE ASOCIADO AL DOCUMENTO"
        End If

        If String.IsNullOrEmpty(_Nokoendp.ToString.Trim) Then
            _Error = True
            _Fila.Cells("Error").Value = True
            _Fila.Cells("Observacion").Value += " - NO EXISTE CUENTA O BANCO RELACIONADO"
        End If

        If String.IsNullOrEmpty(_Nucudp.ToString.Trim) Then
            _Error = True
            _Fila.Cells("Error").Value = True
            _Fila.Cells("Observacion").Value += " - FALTA NUMERO DE DOCUMENTO"
        End If

        If _Cudp.ToString.Trim.Length > 16 Then
            _Error = True
            _Fila.Cells("Error").Value = True
            _Fila.Cells("Observacion").Value += " - NUMERO DE CUENTA MAXIMO 16 DIGITOS"
            _Fila.Cells("CUDP").Style.ForeColor = _Rojo
        End If

        If _Nucudp.ToString.Trim.Length > 8 Then
            _Error = True
            _Fila.Cells("Error").Value = True
            _Fila.Cells("NUCUDP").Style.ForeColor = _Rojo
        End If

        Try
            _Feemdp = FormatDateTime(_Fila.Cells("FEEMDP").Value, DateFormat.ShortDate)
        Catch ex As Exception
            _Error = True
            _Fila.Cells("Observacion").Value += " - REVISE LA FECHA DE EMISION"
            _Fila.Cells("FEEMDP").Value = vbNull
            _Fila.Cells("FEEMDP").Style.ForeColor = _Rojo
        End Try

        Try
            _Fevedp = FormatDateTime(_Fila.Cells("FEVEDP").Value, DateFormat.ShortDate)
        Catch ex As Exception
            _Error = True
            _Fila.Cells("Observacion").Value += " - REVISE LA FECHA DE EMISION"
            _Fila.Cells("FEVEDP").Value = vbNull
            _Fila.Cells("FEVEDP").Style.ForeColor = _Rojo
        End Try

        If _Feemdp > _Fevedp Then

            _Error = True
            _Fila.Cells("Observacion").Value += " - FECHA EMISION MAYOR QUE FECHA VENCIMIENTO"
            _Fila.Cells("FEVEDP").Style.ForeColor = _Rojo
            _Fila.Cells("Error").Value = True

        End If

        If _Error Then
            _Color = _Rojo
        End If

        _Fila.DefaultCellStyle.ForeColor = _Color

        Dim _Imagen As Image

        Select Case _Tipd
            Case "DEP"
                _Imagen = Imagenes_20x20.Images.Item(1)
            Case "ATB"
                _Imagen = Imagenes_20x20.Images.Item(1)
        End Select

        If _Error Then _Imagen = Imagenes_20x20.Images.Item(11)
        If _Exclamacion Then _Imagen = Imagenes_20x20.Images.Item(7)

        If CBool(_Idmaedpce) Then
            _Imagen = Imagenes_20x20.Images.Item(0)
        End If

        _Fila.Cells("Btn_Ico").Value = _Imagen

    End Sub

    Sub Sb_Revisar_Fila2(_Fila As DataGridViewRow)

        Dim _Id = _Fila.Cells("ID").Value
        Dim _Idmaedpce = _Fila.Cells("IDMAEDPCE").Value
        Dim _Endp = _Fila.Cells("ENDP").Value.ToString.Trim
        Dim _Tipd = _Fila.Cells("TIDP").Value.ToString.Trim
        Dim _Cudp = _Fila.Cells("CUDP").Value.ToString.Trim
        Dim _Nucudp = _Fila.Cells("NUCUDP").Value.ToString.Trim
        Dim _Emdp = _Fila.Cells("EMDP").Value.ToString.Trim
        Dim _Vadp = De_Num_a_Tx_01(_Fila.Cells("VADP").Value, False, 5)

        For Each _Fila2 As DataRow In _Tbl_Maedpce.Rows

            Dim _Id2 = _Fila2.Item("ID")
            Dim _Idmaedpce2 = _Fila2.Item("IDMAEDPCE")
            Dim _Endp2 = _Fila2.Item("ENDP").ToString.Trim
            Dim _Tipd2 = _Fila2.Item("TIDP").ToString.Trim
            Dim _Cudp2 = _Fila2.Item("CUDP").ToString.Trim
            Dim _Nucudp2 = _Fila2.Item("NUCUDP").ToString.Trim
            Dim _Emdp2 = _Fila2.Item("EMDP").ToString.Trim
            Dim _Vadp2 = De_Num_a_Tx_01(_Fila2.Item("VADP"), False, 5)

            If _Id <> _Id2 Then

                If _Endp = _Endp2 And _Tipd = _Tipd2 And _Nucudp = _Nucudp2 Then

                    If _Vadp = _Vadp2 Then
                        _Fila.Cells("Observacion").Value = " - FILA DUPLICADA (NO PUEDE SUBIR 2 REGISTROS CON LOS MISMOS DATOS)"
                    Else
                        _Fila.Cells("Observacion").Value = " - NO PUEDE SUBIR MAS DE UN REGISTRO CON EL MISMO NUMERO DE DOCUMENTO"
                    End If

                    _Fila.Cells("NUCUDP").Style.ForeColor = _Rojo
                    _Fila.Cells("Error").Value = True

                    _Fila.DefaultCellStyle.ForeColor = Rojo

                    Dim _Imagen As Image = Imagenes_20x20.Images.Item(11)

                    _Fila.Cells("Btn_Ico").Value = _Imagen

                End If

            End If

        Next

    End Sub

    Private Sub Btn_SugerirNVVRefAuto_Click(sender As Object, e As EventArgs) Handles Btn_SugerirNVVRefAuto.Click

        Dim _Checados = 0

        For Each _Fl As DataRow In _Tbl_Maedpce.Rows
            If NuloPorNro(_Fl.Item("Chk"), False) Then
                _Checados += 1
            End If
        Next

        If Not CBool(_Checados) Then
            MessageBoxEx.Show(Me, "No hay registros seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Confirma que desea marcar los registros sugeridos para Ref. NVV en forma masiva?",
                             "Sugerencia automática", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim _RegRevisados As Integer = 0
        Dim _RegConCoincidencias As Integer = 0
        Dim _RegSinCoincidencias As Integer = 0
        Dim _RegMas1Coincidencias As Integer = 0

        For Each _Fila As DataGridViewRow In Grilla_Maedpce.Rows

            If _Fila.Cells("Chk").Value Then

                _RegRevisados += 1

                If Not _Fila.Cells("CruzarPagoAuto").Value AndAlso Not _Fila.Cells("Error").Value = True Then

                    Dim _Tipd As String = _Fila.Cells("TIDP").Value
                    Dim _Endp As String = _Fila.Cells("ENDP").Value
                    Dim _Vadp As Double = _Fila.Cells("VADP").Value
                    Dim _CodPagador As String
                    Dim _FiltroEndo As String

                    _CodPagador = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Entidades", "CodPagador", "CodEntidad = '" & _Endp & "'")

                    If Not String.IsNullOrWhiteSpace(_CodPagador) Then
                        _FiltroEndo = "(Select CodEntidad From " & _Global_BaseBk & "Zw_Entidades Where CodPagador = '" & _CodPagador & "')"
                    Else
                        _FiltroEndo = "('" & _Endp & "')"
                    End If

                    Consulta_Sql = "Select IDMAEEDO,TIDO,NUDO,ENDO,NOKOEN" & vbCrLf &
                                   "From MAEEDO WITH (NOLOCK)" & vbCrLf &
                                   "Left Join MAEEN On KOEN = ENDO And SUEN = SUENDO" & vbCrLf &
                                   "Where EMPRESA = '" & ModEmpresa & "' And ENDO In " & _FiltroEndo & " And TIDO In ('NVV','RES','PRO') And ESDO Not In ('C','N')" & vbCrLf &
                                   "And NOT EXISTS (SELECT * FROM MAEDPCE WHERE MAEDPCE.ARCHIRSD = 'MAEEDO' AND MAEDPCE.IDRSD = MAEEDO.IDMAEEDO) And VABRDO = " & De_Num_a_Tx_01(_Vadp, False, 5)
                    Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

                    If Not CBool(_Tbl.Rows.Count) Then
                        _RegSinCoincidencias += 1
                    Else

                        Dim _Idmaeedo As Integer = _Tbl.Rows(0).Item("IDMAEEDO")
                        Dim _Tido As String = _Tbl.Rows(0).Item("TIDO")
                        Dim _Nudo As String = _Tbl.Rows(0).Item("NUDO")
                        Dim _Endo As String = _Tbl.Rows(0).Item("ENDO")
                        Dim _Nokoen As String = _Tbl.Rows(0).Item("NOKOEN")
                        Dim _Referencia As String = "*** Cruce automático ***"

                        If _Tbl.Rows.Count = 1 Then

                            _Fila.Cells("ENDP").Value = _Endo
                            _Fila.Cells("RAZON").Value = _Nokoen
                            _Fila.Cells("ARCHIRSD").Value = "MAEEDO"
                            _Fila.Cells("IDRSD").Value = _Idmaeedo
                            _Fila.Cells("Doc_Anticipo").Value = _Tido & "-" & _Nudo
                            _Fila.Cells("REFANTI").Value = _Referencia
                            _RegConCoincidencias += 1

                        Else

                            _Fila.Cells("Observacion").Value += "LA ENTIDAD TIENE " & _Tbl.Rows.Count & " DOCUMENTOS (NVV) QUE COINCIDEN CON EL VALOR ESTABLECIDO, DEBE SELECCIONAR UNO MANUALMENTE"
                            _Fila.Cells("Chk").Value = False
                            _Fila.Cells("Exclamacion").Value = True
                            _Fila.DefaultCellStyle.ForeColor = Rojo
                            _Fila.Cells("Btn_Ico").Value = Imagenes_20x20.Images.Item(7)

                            _RegMas1Coincidencias += 1

                        End If

                    End If

                End If

            End If

        Next

        If _RegSinCoincidencias = Grilla_Maedpce.RowCount Then

            MessageBoxEx.Show(Me, "No se encontraron registros con coincidencias exactas", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        MessageBoxEx.Show(Me, "Registros revisados: " & _RegRevisados & vbCrLf &
                              "Registros con coincidencias: " & _RegConCoincidencias & vbCrLf &
                              "Registros con mas de una coincidencia: " & _RegMas1Coincidencias & vbCrLf &
                              "Registros sin coincidencia: " & _RegSinCoincidencias,
                              "Marcar masivamente", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Btn_AnticipoNVV_Click(sender As Object, e As EventArgs) Handles Btn_AnticipoNVV.Click

        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)
        Sb_Buscar_NVV(_Fila)

    End Sub

    Private Sub Btn_CruceDocParaPago_Click(sender As Object, e As EventArgs) Handles Btn_CruceDocParaPago.Click

        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)
        Sb_Buscar_FCVBLV(_Fila)

    End Sub

    Private Sub Btn_SugerirFCVBLVRefAuto_Click(sender As Object, e As EventArgs) Handles Btn_SugerirFCVBLVRefAuto.Click

        Dim _Checados = 0

        For Each _Fl As DataRow In _Tbl_Maedpce.Rows
            If NuloPorNro(_Fl.Item("Chk"), False) Then
                _Checados += 1
            End If
        Next

        If Not CBool(_Checados) Then
            MessageBoxEx.Show(Me, "No hay registros seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Confirma que desea marcar los registros sugeridos para FCV/BLV con pago automático en forma masiva?",
                             "Sugerencia automática", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim _RegRevisados As Integer = 0
        Dim _RegConCoincidencias As Integer = 0
        Dim _RegSinCoincidencias As Integer = 0
        Dim _RegMas1Coincidencias As Integer = 0

        For Each _Fila As DataGridViewRow In Grilla_Maedpce.Rows

            If _Fila.Cells("Chk").Value Then

                _RegRevisados += 1

                If Not _Fila.Cells("Error").Value = True Then

                    Dim _Endp As String = _Fila.Cells("ENDP").Value
                    Dim _Vadp As Double = _Fila.Cells("VADP").Value

                    Dim _CodPagador As String
                    Dim _FiltroEndo As String

                    _CodPagador = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Entidades", "CodPagador", "CodEntidad = '" & _Endp & "'")

                    If Not String.IsNullOrWhiteSpace(_CodPagador) Then
                        _FiltroEndo = "(Select CodEntidad From " & _Global_BaseBk & "Zw_Entidades Where CodPagador = '" & _CodPagador & "')"
                    Else
                        _FiltroEndo = "('" & _Endp & "')"
                    End If

                    Consulta_Sql = "Select IDMAEEDO,TIDO,NUDO,ENDO,NOKOEN,VABRDO,ESPGDO" & vbCrLf &
                                   "From MAEEDO Edo" & vbCrLf &
                                   "Inner Join MAEEN Ent On Ent.KOEN = Edo.ENDO And Ent.SUEN = Edo.SUENDO" & vbCrLf &
                                   "Where TIDO In ('FCV','BLV') And ENDO In " & _FiltroEndo &
                                   "And VAABDO = 0 " &
                                   "And ESPGDO = 'P' " &
                                   "And NUDONODEFI = 0 " &
                                   "And VABRDO = " & De_Num_a_Tx_01(_Vadp, False, 5)

                    Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

                    If Not CBool(_Tbl.Rows.Count) Then
                        _RegSinCoincidencias += 1
                    Else

                        Dim _Idmaeedo As Integer = _Tbl.Rows(0).Item("IDMAEEDO")
                        Dim _Tido As String = _Tbl.Rows(0).Item("TIDO")
                        Dim _Nudo As String = _Tbl.Rows(0).Item("NUDO")
                        Dim _Endo As String = _Tbl.Rows(0).Item("ENDO")
                        Dim _Nokoen As String = _Tbl.Rows(0).Item("NOKOEN")
                        Dim _Referencia As String = "*** Cruce automático ***"

                        If _Tbl.Rows.Count = 1 Then

                            _Fila.Cells("ENDP").Value = _Endo
                            _Fila.Cells("RAZON").Value = _Nokoen
                            _Fila.Cells("ARCHIRSD").Value = "MAEEDO"
                            _Fila.Cells("IDRSD").Value = _Idmaeedo
                            _Fila.Cells("Doc_Anticipo").Value = _Tido & "-" & _Nudo
                            _Fila.Cells("REFANTI").Value = _Referencia
                            _Fila.Cells("CruzarPagoAuto").Value = True
                            _RegConCoincidencias += 1

                        Else

                            _Fila.Cells("Observacion").Value += "LA ENTIDAD TIENE " & _Tbl.Rows.Count & " DOCUMENTOS (FCV/BLV) QUE COINCIDEN CON EL VALOR ESTABLECIDO, DEBE SELECCIONAR UNO MANUALMENTE"
                            _Fila.Cells("Chk").Value = False
                            _Fila.Cells("Exclamacion").Value = True
                            _Fila.DefaultCellStyle.ForeColor = Rojo
                            _Fila.Cells("Btn_Ico").Value = Imagenes_20x20.Images.Item(7)

                            _RegMas1Coincidencias += 1

                        End If

                    End If

                End If

            End If

        Next

        If _RegSinCoincidencias = Grilla_Maedpce.RowCount Then

            MessageBoxEx.Show(Me, "No se encontraron registros con coincidencias exactas", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        MessageBoxEx.Show(Me, "Registros revisados: " & _RegRevisados & vbCrLf &
                              "Registros con coincidencias: " & _RegConCoincidencias & vbCrLf &
                              "Registros con mas de una coincidencia: " & _RegMas1Coincidencias & vbCrLf &
                              "Registros sin coincidencia: " & _RegSinCoincidencias,
                              "Marcar masivamente", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Grilla_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
        Dim validar As TextBox = CType(e.Control, TextBox)
        AddHandler validar.KeyPress, AddressOf Sb_Validar_Keypress
    End Sub

    Private Sub Sb_Validar_Keypress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)

        ' obtener indice de la columna

        Dim _Columna As Integer = Grilla_Maedpce.CurrentCellAddress.X 'Current.ColumnIndex
        Dim _Fila As Integer = Grilla_Maedpce.CurrentCellAddress.Y 'Current.ColumnIndex

        Dim _Cabeza = Grilla_Maedpce.Columns(_Columna).Name

        ' comprobar si la celda en edición corresponde a la columna 1 o 2
        If _Cabeza = "VADP" Then

            ' Obtener caracter  
            Dim _Caracter As Char = e.KeyChar

            ' referencia a la celda  
            Dim _Txt As TextBox = CType(sender, TextBox)

            If e.KeyChar = "."c Then
                ' si se pulsa la coma se convertirá en punto
                'e.Handled = True
                SendKeys.Send(",")
                e.KeyChar = ","c
                _Caracter = ","
            End If

            Dim _Caracter_Raro = ChrW(Keys.Back)
            Dim _EsNumero As Boolean = Char.IsNumber(_Caracter)

            ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
            ' es el separador decimal, y que no contiene ya el separador  
            If (Char.IsNumber(_Caracter)) Or
               (_Caracter = ChrW(Keys.Back)) Or
               (_Caracter = ",") And
               (_Txt.Text.Contains(",") = False) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

        End If

    End Sub

End Class
