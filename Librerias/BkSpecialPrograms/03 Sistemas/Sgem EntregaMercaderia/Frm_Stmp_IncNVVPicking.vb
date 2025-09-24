Imports DevComponents.DotNetBar

Public Class Frm_Stmp_IncNVVPicking

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Documentos As DataTable
    Dim _RowEntidadBuscar As DataRow

    Public Property FiltroDoc As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, True, False)
        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Stmp_IncNVVPicking_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dtp_FechaParaFacturacion.Value = FechaDelServidor()

        Input_Monto_Max_CRV_FacMasiva.Value = _Global_Row_Configuracion_General.Item("Monto_Max_CRV_FacMasiva")
        Input_Monto_Max_CRV_FacMasiva.Visible = False
        Chk_Pagar_Saldos_CRV.Visible = False

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Dim _Arr_Tipo_Entidad(,) As String = {{"", "Todas"},
                                             {"Contado", "Contado"},
                                             {"Credito", "Crédito"}}
        Sb_Llenar_Combos(_Arr_Tipo_Entidad, Cmb_TipoVenta)
        Cmb_TipoVenta.SelectedValue = ""

        Dim _Arr_Tipo_Entrega(,) As String = {{"", "Todas"},
                                             {"RT", "Retira cliente"},
                                             {"RR", "Retira transporte"},
                                             {"DD", "Despacho a domicilio"}}
        Sb_Llenar_Combos(_Arr_Tipo_Entrega, Cmb_TipoEnvio)
        Cmb_TipoEnvio.SelectedValue = ""

        Dtp_BuscaXFechaEmision.Value = #1/1/0001 12:00:00 AM#
        Dtp_BuscaXFechaDespacho.Value = #1/1/0001 12:00:00 AM#

        Sb_Actualizar_Grilla()
        Sb_Color_Botones_Barra(Bar1)

        Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        Me.ActiveControl = Txt_BuscaXNudoNVV

        AddHandler Txt_BuscaXNudoNVV.KeyDown, AddressOf Txt_KeyDown
        AddHandler Txt_BuscaXEntidad.KeyDown, AddressOf Txt_KeyDown
        AddHandler Txt_Observaciones.KeyDown, AddressOf Txt_KeyDown
        AddHandler Txt_Ocdo.KeyDown, AddressOf Txt_KeyDown

        Chk_FacturarTodo.Enabled = _Global_Row_Configuracion_General.Item("Pickear_FacturarAutoCompletas")

    End Sub

    Public Sub Sb_Actualizar_Grilla()

        Dim _FiltroNumero = String.Empty
        Dim _FiltroFechaDespacho = String.Empty
        Dim _FiltroFechaEmision = String.Empty
        Dim _FiltroEntidad = String.Empty
        Dim _FiltroObservaciones = String.Empty
        Dim _FiltroOrdenDeCompra = String.Empty
        Dim _FiltroTipoVenta = String.Empty
        Dim _FiltroDespacho = String.Empty

        If Dtp_BuscaXFechaEmision.Value <> #1/1/0001 12:00:00 AM# Then
            _FiltroFechaEmision = "And  Edo.FEEMDO = '" & Format(Dtp_BuscaXFechaEmision.Value, "yyyyMMdd") & "'" & vbCrLf
        End If

        If Dtp_BuscaXFechaDespacho.Value <> #1/1/0001 12:00:00 AM# Then
            _FiltroFechaDespacho = "And  Edo.FEER = '" & Format(Dtp_BuscaXFechaDespacho.Value, "yyyyMMdd") & "'" & vbCrLf
        End If

        If Not IsNothing(_RowEntidadBuscar) Then
            _FiltroEntidad = "And Edo.ENDO = '" & _RowEntidadBuscar.Item("KOEN") & "' And Edo.SUENDO = '" & _RowEntidadBuscar.Item("SUEN") & "'" & vbCrLf
        End If

        If Not String.IsNullOrEmpty(Txt_BuscaXNudoNVV.Text) Then
            _FiltroNumero = "And Edo.NUDO Like '%" & Txt_BuscaXNudoNVV.Text & "%'" & vbCrLf
        End If

        If Not String.IsNullOrEmpty(Txt_BuscaXObservaciones.Text) Then
            _FiltroObservaciones = "And Obs.OBDO Like '%" & Txt_BuscaXObservaciones.Text & "%'" & vbCrLf
        End If

        If Not String.IsNullOrEmpty(Txt_Ocdo.Text) Then
            _FiltroOrdenDeCompra = "And Obs.OCDO Like '%" & Txt_Ocdo.Text & "%'" & vbCrLf
        End If

        If Not String.IsNullOrEmpty(Cmb_TipoVenta.SelectedValue) Then
            _FiltroTipoVenta = vbCrLf & "Where TipoVenta = '" & Cmb_TipoVenta.SelectedValue & "'" & vbCrLf
        End If

        If Not String.IsNullOrEmpty(Cmb_TipoEnvio.SelectedValue) Then
            _FiltroTipoVenta = vbCrLf & "Where TipoEnvio = '" & Cmb_TipoEnvio.SelectedValue & "'" & vbCrLf
        End If

        ' DEBO ENLAZAR LA TABLA Zw_Docu_Det a esta consulta para poner la RtuVariale por productos para las CARNES...

        Dim _Pickear_FacturarAutoCompletas As Integer = Convert.ToInt32(_Global_Row_Configuracion_General.Item("Pickear_FacturarAutoCompletas"))

        Consulta_sql = "Select Cast(0 As Bit) As EnvPickeo,Cast(" & _Pickear_FacturarAutoCompletas & " As Bit) As Facturar,Edo.IDMAEEDO,Edo.EMPRESA,Edo.SUDO,TIDO,Edo.NUDO," & vbCrLf &
                       "Cast(ENDO As Varchar(10)) As ENDO,Cast(SUENDO As Varchar(10)) As SUENDO," & vbCrLf &
                       "Cast('' As Varchar(15)) As Rut,NOKOEN,FEEMDO,FEER,FE01VEDO,FEULVEDO," & vbCrLf &
                       "Case When FEEMDO < FE01VEDO Then 'Credito' Else 'Contado' End As TipoVenta," & vbCrLf &
                       "CONVERT(NVARCHAR, CONVERT(datetime, (Edo.HORAGRAB*1.0/3600)/24), 108) AS Hora_Emision,VANEDO," & vbCrLf &
                       "VAIVDO,VAIMDO,VABRDO,VAABDO,KOFUDO,NOKOFU," & vbCrLf &
                       "Cast(0 As Bit) As Facturado,Cast(0 As Int) As IDMAEEDO_FCV,Cast('' As Varchar(10)) As NUDO_FCV," & vbCrLf &
                       "FEEMDO AS Fecha_Emision,Edo.FEER AS Fecha_Despacho," &
                       "Cast('" & Format(Dtp_FechaParaFacturacion.Value, "yyyyMMdd") & "' As Datetime) As 'FechaParaFacturacion',Cast(0 As Float) As VABRDO_FCV,Cast(0 As Float) As VAABDO_FCV," & vbCrLf &
                       "Cast(0 As Bit) As FCV_PAGADA,Cast(0 As Bit) As FCV_IMPRESA," & vbCrLf &
                       "Cast(0 As Int) As IDMAEDPCE,Cast(0 As Float) As VADP,Cast(0 As Float) As VAASDP," & vbCrLf &
                       "Cast(0 As Float) As SALDO,Cast(0 As Bit) As CRV, Cast(0 as Float) SALDO_CRV,Isnull(OBDO,'') As OBDO," & vbCrLf &
                       "Isnull(DocE.HabilitadaFac,1) As HabilitadaFac,DocE.FechaHoraAutoriza As 'FechaHoraAutoriza',Isnull(Den.Tipo_Envio,'') As 'TipoEnvio',CAST('' As varchar(25)) As 'TipoDeEnvio'" & vbCrLf &
                       "Into #Paso" & vbCrLf &
                        "From MAEEDO Edo" & vbCrLf &
                        "Left Join MAEEDOOB Obs On Obs.IDMAEEDO = Edo.IDMAEEDO" & vbCrLf &
                        "Left Join MAEEN On KOEN = ENDO And SUENDO = SUEN" & vbCrLf &
                        "Left Join TABFU On KOFU = KOFUEN" & vbCrLf &
                        "Left Join " & _Global_BaseBk & "Zw_Docu_Ent DocE On DocE.Idmaeedo = Edo.IDMAEEDO" & vbCrLf &
                        "Left Join " & _Global_BaseBk & "Zw_Despachos_Doc Ddd On Ddd.Idrst = Edo.IDMAEEDO And Ddd.Archidrst = 'MAEEDO'" & vbCrLf &
                        "Left Join " & _Global_BaseBk & "Zw_Despachos Den On Den.Id_Despacho = Ddd.Id_Despacho" & vbCrLf &
                        "Where 1 > 0" & vbCrLf &
                        "And Edo.IDMAEEDO Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Stmp_Enc Where Estado Not In ('NULO','NULA') And Empresa = '" & Mod_Empresa & "' And Sucursal = '" & Mod_Sucursal & "')" & vbCrLf &
                        _FiltroFechaEmision &
                        _FiltroFechaDespacho &
                        _FiltroEntidad &
                        _FiltroNumero &
                        _FiltroObservaciones &
                        _FiltroOrdenDeCompra &
                        _FiltroDoc & vbCrLf &
                        "And DocE.Pickear = 1" & vbCrLf &
                        "Order By HORAGRAB" & vbCrLf &
                        "Update #Paso Set IDMAEDPCE = Isnull((Select Top 1 IDMAEDPCE From MAEDPCE Where IDRSD = IDMAEEDO),0)" & vbCrLf &
                        "Update #Paso Set VADP = Isnull((Select VADP From MAEDPCE Mp Where Mp.IDMAEDPCE = #Paso.IDMAEDPCE),0)" & vbCrLf &
                        "Update #Paso Set Hora_Emision = SUBSTRING(Hora_Emision,1,5),ENDO = Ltrim(Rtrim(ENDO)),SUENDO = Ltrim(Rtrim(SUENDO))" & vbCrLf &
                        "Update #Paso Set SALDO_CRV = VABRDO-VADP Where VADP > 0" & vbCrLf &
                        "Update #Paso Set TipoDeEnvio = 'Retira cliente' Where TipoEnvio = 'RT'" & vbCrLf &
                        "Update #Paso Set TipoDeEnvio = 'Despacho domicilio' Where TipoEnvio = 'DD'" & vbCrLf &
                        "Update #Paso Set TipoDeEnvio = 'Retira transporte' Where TipoEnvio = 'RR'" & vbCrLf &
                        "Select * From #Paso" & _FiltroTipoVenta & _FiltroDespacho & vbCrLf &
                        "Order By IDMAEEDO" & vbCrLf &
                        "Drop Table #Paso"

        Dim Fm_Espera As New Frm_Form_Esperar
        Fm_Espera.BarraCircular.IsRunning = True
        Fm_Espera.Show()

        Me.Cursor = Cursors.WaitCursor

        _Tbl_Documentos = _Sql.Fx_Get_DataTable(Consulta_sql)

        Fm_Espera.Dispose()
        Me.Cursor = Cursors.Default

        With Grilla

            .DataSource = _Tbl_Documentos

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            .Columns("EnvPickeo").HeaderText = "Pick?"
            .Columns("EnvPickeo").ToolTipText = "Enviar a pickeo"
            .Columns("EnvPickeo").Width = 40
            .Columns("EnvPickeo").Visible = True
            .Columns("EnvPickeo").ReadOnly = False
            .Columns("EnvPickeo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SUDO").HeaderText = "SD"
            .Columns("SUDO").Width = 35
            .Columns("SUDO").Visible = True
            .Columns("SUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Width = 30
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Width = 80
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Facturar").HeaderText = "F.C."
            .Columns("Facturar").ToolTipText = "Facturar automáticamente una vez completado el picking"
            .Columns("Facturar").Width = 30
            .Columns("Facturar").Visible = _Global_Row_Configuracion_General.Item("Pickear_FacturarAutoCompletas")
            .Columns("Facturar").ReadOnly = False
            .Columns("Facturar").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("HabilitadaFac").HeaderText = "H.F."
            .Columns("HabilitadaFac").ToolTipText = "Habilitada ser facturada"
            .Columns("HabilitadaFac").Width = 30
            .Columns("HabilitadaFac").Visible = _Global_Row_Configuracion_General.Item("LasNVVDebenSerHabilitadasParaFacturar")
            .Columns("HabilitadaFac").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ENDO").HeaderText = "Entidad"
            .Columns("ENDO").Width = 60
            .Columns("ENDO").Visible = True
            .Columns("ENDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("KOFUDO").HeaderText = "Resp"
            .Columns("KOFUDO").Width = 35
            .Columns("KOFUDO").Visible = True
            .Columns("KOFUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SUENDO").HeaderText = "Suc."
            .Columns("SUENDO").Width = 40
            .Columns("SUENDO").Visible = True
            .Columns("SUENDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOEN").HeaderText = "Razón Social"
            .Columns("NOKOEN").Width = 180
            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("VABRDO").Width = 80
            .Columns("VABRDO").HeaderText = "Monto"
            .Columns("VABRDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VABRDO").DefaultCellStyle.Format = "$ ###,##0.##"
            .Columns("VABRDO").Visible = True
            .Columns("VABRDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("VADP").Width = 70
            .Columns("VADP").HeaderText = "Abonado"
            .Columns("VADP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VADP").DefaultCellStyle.Format = "$ ###,##0.##"
            .Columns("VADP").Visible = True
            .Columns("VADP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("OBDO").HeaderText = "Observaciones"
            .Columns("OBDO").Width = 160
            .Columns("OBDO").Visible = True
            .Columns("OBDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TipoVenta").HeaderText = "T.Venta"
            .Columns("TipoVenta").ToolTipText = "Tipo de venta: Contado o Crédito"
            .Columns("TipoVenta").Width = 60
            .Columns("TipoVenta").Visible = True
            .Columns("TipoVenta").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TipoEnvio").HeaderText = "T.E."
            .Columns("TipoEnvio").ToolTipText = "Tipo de envío: RT (Retira cliente), RR (Retira transporte), DD (Despacho domicilio)"
            .Columns("TipoEnvio").Width = 30
            .Columns("TipoEnvio").Visible = True
            .Columns("TipoEnvio").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMDO").HeaderText = "F.Emisión"
            .Columns("FEEMDO").Width = 70
            .Columns("FEEMDO").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEEMDO").Visible = True
            .Columns("FEEMDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaHoraAutoriza").HeaderText = "F.H.autoriza"
            .Columns("FechaHoraAutoriza").ToolTipText = "Fecha y hora de autorización para ser facturada"
            .Columns("FechaHoraAutoriza").Width = 100
            .Columns("FechaHoraAutoriza").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
            .Columns("FechaHoraAutoriza").Visible = True
            .Columns("FechaHoraAutoriza").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("HORA").HeaderText = "Hora"
            '.Columns("HORA").Width = 50
            '.Columns("HORA").Visible = True
            '.Columns("HORA").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("FEER").HeaderText = "F.Despacho"
            .Columns("FEER").Width = 70
            .Columns("FEER").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEER").Visible = True
            .Columns("FEER").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaParaFacturacion").HeaderText = "F.Facturar"
            .Columns("FechaParaFacturacion").Width = 70
            .Columns("FechaParaFacturacion").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaParaFacturacion").Visible = True
            .Columns("FechaParaFacturacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1


            '.Columns("FEULVEDO").HeaderText = "F.Vencimiento"
            '.Columns("FEULVEDO").Width = 70
            '.Columns("FEULVEDO").DefaultCellStyle.Format = "dd/MM/yyyy"
            '.Columns("FEULVEDO").Visible = True
            '.Columns("FEULVEDO").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1




        End With

        'Call Grilla_CellEnter(Nothing, Nothing)

    End Sub

    Private Sub Grilla_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla.CellMouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Grilla_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEndEdit

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Idmaeedo As Integer = _Fila.Cells("IDMAEEDO").Value

        If _Global_Row_Configuracion_General.Item("LasNVVDebenSerHabilitadasParaFacturar") AndAlso
            (_Cabeza = "Facturar" Or _Cabeza = "EnvPickeo") AndAlso
            _Fila.Cells(_Cabeza).Value AndAlso
            Not _Fila.Cells("HabilitadaFac").Value Then

            _Fila.Cells(_Cabeza).Value = False
            MessageBoxEx.Show(Me, "Esta nota de venta no ha sido habilitada para ser facturada", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        If _Cabeza = "EnvPickeo" AndAlso _Fila.Cells("EnvPickeo").Value Then

            Dim _Esdo As String = _Sql.Fx_Trae_Dato("MAEEDO", "ESDO", "IDMAEEDO = " & _Idmaeedo)

            If _Esdo = "C" Then
                _Fila.Cells(_Cabeza).Value = False
                MessageBoxEx.Show(Me, "Esta nota de venta esta completamente cerrada", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        End If

        Lbl_Total_Facturar.Tag = 0

        For Each _Fl As DataRow In _Tbl_Documentos.Rows

            If _Fl.Item("EnvPickeo") Then
                Lbl_Total_Facturar.Tag += _Fl.Item("VABRDO")
            End If

        Next

        Lbl_Total_Facturar.Text = FormatCurrency(Lbl_Total_Facturar.Tag, 0)

    End Sub

    Private Sub Chk_PickearTodo_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_PickearTodo.CheckedChanged

        Try

            Lbl_Total_Facturar.Tag = 0
            Lbl_Total_Facturar.Text = FormatCurrency(0, 0)

            If Not Chk_PickearTodo.Checked Then

                For Each _Fila As DataRow In _Tbl_Documentos.Rows
                    _Fila.Item("EnvPickeo") = Chk_PickearTodo.Checked
                Next

                Return

            End If

            Dim _Marcar As Boolean
            Dim _SinHabilitar = 0

            For Each _Fila As DataGridViewRow In Grilla.Rows

                If Not _Fila.Cells("EnvPickeo").Value Then

                    _Marcar = True

                    If _Global_Row_Configuracion_General.Item("LasNVVDebenSerHabilitadasParaFacturar") Then

                        If Not _Fila.Cells("HabilitadaFac").Value Then

                            _Marcar = False
                            _SinHabilitar += 1

                        End If

                    End If

                    _Fila.Cells("EnvPickeo").Value = _Marcar

                    Lbl_Total_Facturar.Tag += _Fila.Cells("VABRDO").Value
                    Lbl_Total_Facturar.Text = FormatCurrency(Lbl_Total_Facturar.Tag, 0)

                End If

            Next

            If _Global_Row_Configuracion_General.Item("LasNVVDebenSerHabilitadasParaFacturar") Then

                If Chk_PickearTodo.Checked AndAlso CBool(_SinHabilitar) Then

                    MessageBoxEx.Show(Me, "Existente " & _SinHabilitar & " documento(s) sin habilitar para ser facturado(s)",
                                   "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Chk_PickearTodo.Checked = False

                End If

            End If

        Catch ex As Exception
        Finally
            Me.Refresh()
        End Try

    End Sub

    Private Sub Chk_FacturarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_FacturarTodo.CheckedChanged

        If Not Chk_FacturarTodo.Checked Then

            For Each _Fila As DataRow In _Tbl_Documentos.Rows
                _Fila.Item("Facturar") = Chk_FacturarTodo.Checked
            Next

            Return

        End If

        Dim _Marcar As Boolean
        Dim _SinHabilitar = 0

        For Each _Fila As DataGridViewRow In Grilla.Rows

            If Not _Fila.Cells("Facturar").Value Then

                _Marcar = True

                If _Global_Row_Configuracion_General.Item("LasNVVDebenSerHabilitadasParaFacturar") Then

                    If Not _Fila.Cells("HabilitadaFac").Value Then

                        _Marcar = False
                        _SinHabilitar += 1

                    End If

                    _Fila.Cells("Facturar").Value = _Marcar

                End If

            End If

        Next

        If _Global_Row_Configuracion_General.Item("LasNVVDebenSerHabilitadasParaFacturar") Then

            If Not Chk_FacturarTodo.Checked Then

                If CBool(_SinHabilitar) Then
                    MessageBoxEx.Show(Me, "Existente " & _SinHabilitar & " documento(s) sin habilitar para ser facturado(s)",
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            End If

        End If

    End Sub

    Private Sub Btn_EnviarPickear_Click(sender As Object, e As EventArgs) Handles Btn_EnviarPickear.Click

        Dim _Contador = 0

        For Each _Fila As DataRow In _Tbl_Documentos.Rows

            Dim _Estado = _Fila.RowState

            If _Estado <> DataRowState.Deleted Then

                If _Fila.Item("EnvPickeo") Then
                    _Contador += 1
                End If

            End If

        Next

        If _Contador = 0 Then
            MessageBoxEx.Show(Me, "No hay registros seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        'If Rdb_FechaFacFechaManual.Checked Then

        '    Dim _Msj_Tsc As LsValiciones.Mensajes

        '    _Msj_Tsc = Fx_Revisar_Tasa_Cambio(Me, Dtp_FechaParaFacturacion.Value)

        '    If Not _Msj_Tsc.EsCorrecto Then
        '        Return
        '    End If

        'End If

        Dim _ListaFFac As New List(Of LsValiciones.Mensajes)

        For Each _Fila As DataRow In _Tbl_Documentos.Rows

            Dim _Pickear As Boolean = _Fila.Item("EnvPickeo")

            If _Pickear Then

                Dim _Tido As String = _Fila.Item("TIDO")
                Dim _Nudo As String = _Fila.Item("NUDO")
                Dim _FechaParaFacturacion As DateTime = _Fila.Item("FechaParaFacturacion")

                Dim _Msj_Feer As New LsValiciones.Mensajes

                If _FechaParaFacturacion.Date < Date.Now.Date Then
                    _Msj_Feer.EsCorrecto = False
                    _Msj_Feer.Detalle = "Documento: " & _Tido & " - " & _Nudo & ", Fecha despacho: " & _FechaParaFacturacion.ToShortDateString
                    _Msj_Feer.Mensaje = "La fecha de facturación no puede ser menos que la fecha de hoy"
                    _Msj_Feer.Icono = MessageBoxIcon.Stop
                Else
                    _Msj_Feer = Fx_Revisar_Tasa_Cambio(Me, _FechaParaFacturacion,, False)
                End If

                If Not _Msj_Feer.EsCorrecto Then
                    _ListaFFac.Add(_Msj_Feer)
                End If

            End If

        Next

        If Not IsNothing(_ListaFFac) AndAlso CBool(_ListaFFac.Count) Then

            MessageBoxEx.Show(Me, "Hay documentos con problemas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Dim Fmf As New Frm_Validaciones
            Fmf.ListaMensajes = _ListaFFac
            Fmf.ShowDialog(Me)
            Fmf.Dispose()

            Return

        End If

        If Not Chk_FactConFDespVencida.Checked Then

            Dim _ListaFeer As New List(Of LsValiciones.Mensajes)

            For Each _Fila As DataRow In _Tbl_Documentos.Rows

                Dim _Pickear As Boolean = _Fila.Item("EnvPickeo")

                If _Pickear Then

                    Dim _Tido As String = _Fila.Item("TIDO")
                    Dim _Nudo As String = _Fila.Item("NUDO")
                    Dim _Feer As DateTime = _Fila.Item("FEER")

                    Dim _Msj_Feer As New LsValiciones.Mensajes

                    If _Feer.Date < Date.Now.Date Then
                        _Msj_Feer.EsCorrecto = False
                        _Msj_Feer.Detalle = "Documento: " & _Tido & " - " & _Nudo & ", Fecha despacho: " & _Feer.ToShortDateString
                        _Msj_Feer.Mensaje = "La fecha de despacho vencida"
                        _Msj_Feer.Icono = MessageBoxIcon.Stop
                    Else
                        _Msj_Feer = Fx_Revisar_Tasa_Cambio(Me, _Feer,, False)
                    End If

                    If Not _Msj_Feer.EsCorrecto Then
                        _ListaFeer.Add(_Msj_Feer)
                    End If

                End If

            Next

            If Not IsNothing(_ListaFeer) AndAlso CBool(_ListaFeer.Count) Then

                MessageBoxEx.Show(Me, "Hay documentos con fecha de despacho vencida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Dim Fmf As New Frm_Validaciones
                Fmf.ListaMensajes = _ListaFeer
                Fmf.ShowDialog(Me)
                Fmf.Dispose()

                MessageBoxEx.Show(Me, "Para enviar a picking y facturar los documentos con fecha de despacho vencida, " & vbCrLf &
                                  "debe marcar la opción: ""'Facturar notas de venta con fecha de despacho vencida'.""" & vbCrLf &
                                  "¡Requiere autorización!", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return

                'If MessageBoxEx.Show(Me, "¿Desea enviar a picking igualmente estas notas de venta?", "Validación",
                '                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                '    If Not Fx_Tiene_Permiso(Me, "Doc00163") Then
                '        Return
                '    End If
                'End If

                'Return

            End If

        End If

        Dim _Lista As List(Of LsValiciones.Mensajes) = Fx_Cargar_NVV_FechaDespachoHoy()

        Dim ListaQr As LsValiciones.Mensajes = _Lista.FirstOrDefault(Function(p) p.EsCorrecto = False)

        If Not IsNothing(ListaQr) Then

            MessageBoxEx.Show(Me, "Hay documentos con problemas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

        Dim Fmv As New Frm_Validaciones
        Fmv.ListaMensajes = _Lista
        Fmv.ShowDialog(Me)
        Fmv.Dispose()

        Sb_Actualizar_Grilla()

    End Sub

    Function Fx_Cargar_NVV_FechaDespachoHoy() As List(Of LsValiciones.Mensajes)

        Dim _Lista As New List(Of LsValiciones.Mensajes)
        Dim _FechaHoy As DateTime = FechaDelServidor()

        Dim _Cl_Stmp As New Cl_Stmp

        For Each _Fila As DataRow In _Tbl_Documentos.Rows

            Dim _Mensaje_Stem As New LsValiciones.Mensajes

            Dim _Idmaeedo As Integer = _Fila.Item("Idmaeedo")
            Dim _Tido As String = _Fila.Item("Tido")
            Dim _Nudo As String = _Fila.Item("Nudo")
            Dim _Pickear As Boolean = _Fila.Item("EnvPickeo")
            Dim _Facturar As Boolean = _Fila.Item("Facturar")
            Dim _FechaParaFacturar As DateTime
            Dim _PagarAuto As Boolean = Chk_Pagar_Documentos.Checked
            Dim _Idmaedpce_Paga As Integer
            Dim _CodFuncionario_Paga As String

            If _PagarAuto Then

                _Idmaedpce_Paga = _Fila.Item("IDMAEDPCE")
                _CodFuncionario_Paga = FUNCIONARIO

                If Not CBool(_Idmaedpce_Paga) Then
                    _PagarAuto = False
                    _CodFuncionario_Paga = String.Empty
                End If

            End If

            _FechaParaFacturar = _Fila.Item("FechaParaFacturacion")

            If _Pickear Then

                _Mensaje_Stem = _Cl_Stmp.Fx_Crear_Ticket(_Idmaeedo,
                                                         _Tido,
                                                         _Nudo,
                                                         _Facturar,
                                                         _FechaParaFacturar,
                                                         "R",
                                                         False,
                                                         Mod_Empresa,
                                                         Mod_Sucursal,
                                                         FUNCIONARIO,
                                                         _PagarAuto,
                                                         _Idmaedpce_Paga,
                                                         _CodFuncionario_Paga)

                If _Mensaje_Stem.EsCorrecto Then
                    If RutEmpresa = "77988832-0" Then
                        Fx_CambiarBodegaSeaGarden2MeatGarden(_Idmaeedo)
                    End If
                End If

                _Lista.Add(_Mensaje_Stem)

            End If

        Next

        Return _Lista

    End Function

    Function Fx_CambiarBodegaSeaGarden2MeatGarden(_Idmaeedo As Integer) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Consulta_sql = "Select Top 1 EMPRESA As Empresa, SULIDO As Sucursal, BOSULIDO As Bodega From MAEDDO Where IDMAEEDO = " & _Idmaeedo
            Dim _Row_Maeddo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Empresa As String
            Dim _Sucursal As String
            Dim _Bodega As String

            If Not IsNothing(_Row_Maeddo) Then

                _Empresa = _Row_Maeddo.Item("Empresa")
                _Sucursal = _Row_Maeddo.Item("Sucursal")
                _Bodega = _Row_Maeddo.Item("Bodega")

                If String.IsNullOrEmpty(_Empresa) Or String.IsNullOrEmpty(_Sucursal) Or String.IsNullOrEmpty(_Bodega) Then
                    _Mensaje.EsCorrecto = False
                    _Mensaje.Mensaje = "No se pudo obtener la empresa, sucursal o bodega de la nota de venta"
                    Return _Mensaje
                End If

            Else

                _Mensaje.EsCorrecto = False
                _Mensaje.Mensaje = "No se encontró información de la nota de venta"
                Return _Mensaje

            End If

            Dim EmpSucBod As String = _Empresa & ";" & _Sucursal & ";" & _Bodega

            Consulta_sql = "Select Tabla, DescripcionTabla, CodigoTabla, NombreTabla" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                           "Where Tabla = 'SEA2MEATGARDEN' And NombreTabla = '" & EmpSucBod & "'"
                Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row) Then
                _Mensaje.EsCorrecto = False
                _Mensaje.Mensaje = "No se encontró la caracterización para la empresa, sucursal y bodega: " & EmpSucBod
                Return _Mensaje
            End If

            Dim _ESB = _Row.Item("CodigoTabla").ToString.Split(";"c)

            _Empresa = _ESB(0).Trim
            _Sucursal = _ESB(1).Trim
            _Bodega = _ESB(2).Trim

            Consulta_sql = "Declare @Idmaeedo Int = " & _Idmaeedo & vbCrLf &
                           "Update MAEEDO Set EMPRESA = '" & _Empresa & "',SUDO = '" & _Sucursal & "' Where IDMAEEDO = @Idmaeedo" & vbCrLf &
                           "Update MAEDDO Set EMPRESA = '" & _Empresa & "',SULIDO = '" & _Sucursal & "',BOSULIDO = '" & _Bodega & "' Where IDMAEEDO = @Idmaeedo" & vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_Despachos Set Empresa = '" & _Empresa & "',Sucursal = '" & _Sucursal & "',Bodega = '" & _Bodega &
                                "' Where Id_Despacho In (Select Id_Despacho From " & _Global_BaseBk & "Zw_Despachos_Doc WHERE (Idrst = @Idmaeedo) AND (Archidrst = 'MAEEDO'))" & vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set Empresa = '" & _Empresa & "',Sucursal = '" & _Sucursal & "' Where Idmaeedo = @Idmaeedo" & vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_Docu_Ent Set Empresa = '" & _Empresa & "' Where Idmaeedo = @Idmaeedo"
            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql, False)

        Catch ex As Exception

        End Try

    End Function

    Private Sub Btn_ActualizarLista_Click(sender As Object, e As EventArgs) Handles Btn_ActualizarLista.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Txt_BuscaXEntidad_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_BuscaXEntidad.ButtonCustomClick

        Dim _CodEntidad = Txt_BuscaXEntidad.Text.Trim

        If String.IsNullOrEmpty(Txt_BuscaXEntidad.Text) Then
            _RowEntidadBuscar = Nothing
        End If

        Dim Fm As New Frm_BuscarEntidad_Mt(False)
        Fm.Rdb_Clientes.Checked = True
        Fm.Txtdescripcion.Text = _CodEntidad
        Fm.ShowDialog(Me)
        _RowEntidadBuscar = Fm.Pro_RowEntidad

        Fm.Dispose()

        If Not IsNothing(_RowEntidadBuscar) Then
            Txt_BuscaXEntidad.Text = _RowEntidadBuscar.Item("KOEN").ToString.Trim & "-" & _RowEntidadBuscar.Item("NOKOEN").ToString.Trim
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Txt_BuscaXEntidad_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_BuscaXEntidad.ButtonCustom2Click
        _RowEntidadBuscar = Nothing
        Txt_BuscaXEntidad.Text = String.Empty
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Txt_BuscaXNudoNVV_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_BuscaXNudoNVV.ButtonCustom2Click
        Txt_BuscaXNudoNVV.Text = String.Empty
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Txt_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Txt_BuscaXObservaciones_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_BuscaXObservaciones.ButtonCustom2Click
        Txt_BuscaXObservaciones.Text = String.Empty
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Txt_Ocdo_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Ocdo.ButtonCustom2Click
        Txt_Ocdo.Text = String.Empty
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Dtp_BuscaXFechaEmision_ButtonClearClick(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Dtp_BuscaXFechaEmision.ButtonClearClick
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Dtp_BuscaXFechaDespacho_ButtonClearClick(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Dtp_BuscaXFechaDespacho.ButtonClearClick
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Btn_Buscar_Click(sender As Object, e As EventArgs) Handles Btn_Buscar.Click
        Sb_Actualizar_Grilla()
    End Sub

    Sub Sb_Ver_Documento()

        Me.Enabled = False

        Try

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

            Dim _Idmaeedo As Integer
            Dim _Idmaedpce As Integer = _Fila.Cells("IDMAEDPCE").Value

            If _Cabeza = "VADP" Then

                If CBool(_Idmaedpce) Then
                    Dim Fm_P As New Frm_Pagos_Documentos_Pagados(_Idmaedpce)
                    Fm_P.ShowDialog(Me)
                    Fm_P.Dispose()
                    Return
                End If

            End If

            If _Cabeza = "SALDOAFAVOR" Then
                Call Btn_Ver_Cta_Cte_Click(Nothing, Nothing)
            End If

            If _Cabeza = "NUDO" Then
                _Idmaeedo = _Fila.Cells("IDMAEEDO").Value
            End If

            If _Cabeza = "NUDO_FCV" Then
                _Idmaeedo = _Fila.Cells("IDMAEEDO_FCV").Value
            End If

            If CBool(_Idmaeedo) Then

                Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
                Fm.ShowDialog(Me)
                Fm.Dispose()

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error inesperado!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Me.Enabled = True
        End Try

    End Sub

    Private Sub Btn_Ver_Cta_Cte_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Cta_Cte.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Koen = _Fila.Cells("ENDO").Value
        Dim _SALDOAFAVOR As Double = _Fila.Cells("SALDOAFAVOR").Value

        If Not CBool(_SALDOAFAVOR) Then
            MessageBoxEx.Show(Me, "No hay saldo a favor o no hay entidad seleccionada", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_Pagos_Generales(Frm_Pagos_Generales.Enum_Tipo_Pago.Clientes)
        Fm.Koen = _Koen
        Fm.BtnActualizarLista.Visible = False
        Fm.ModoLectura = True
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Ver_documento_Click(sender As Object, e As EventArgs) Handles Btn_Ver_documento.Click
        Sb_Ver_Documento()
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Select Case _Cabeza
            Case "VADP", "SALDOAFAVOR", "NUDO", "NUDO_FCV"
                Sb_Ver_Documento()
            Case "FechaParaFacturacion"

                Dim _Grabar As Boolean
                Dim _FechaSeleccionada As DateTime

                Dim Fm As New Frm_Seleccionar_Fecha

                Fm.SolicitarConfirmacionDeFecha = True
                'Fm.ExigeFechaMaxima = True
                'Fm.FechaMaxima = Now.Date.AddDays(1)
                Fm.FechaMinima = Now.Date
                Fm.ExigeFechaMinima = True

                If IsNothing(_Fila.Cells("FechaParaFacturacion").Value) Then
                    Fm.FechaDisplay = Now.Date
                Else
                    Fm.FechaDisplay = _Fila.Cells("FechaParaFacturacion").Value
                End If
                Fm.Dtp_Fecha.Value = _Fila.Cells("FechaParaFacturacion").Value
                Fm.Dtp_Hora.Value = Now
                Fm.MostraFormularioAlCentro = True
                Fm.SeleccionarHora = False
                Fm.ShowDialog(Me)

                _Grabar = Fm.Grabar
                _FechaSeleccionada = Fm.FechaSeleccionada
                Fm.Dispose()

                If _Grabar Then
                    _Fila.Cells("FechaParaFacturacion").Value = _FechaSeleccionada
                End If

            Case Else
                Return
        End Select

    End Sub

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter
        Try

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Nokoen As String = _Fila.Cells("NOKOEN").Value.ToString.Trim
            Dim _Obdo As String = Replace(_Fila.Cells("OBDO").Value.ToString.Trim, vbCrLf, " ")
            Dim _TipoDeEnvio As String = _Fila.Cells("TipoDeEnvio").Value.ToString.Trim

            If Not String.IsNullOrWhiteSpace(_Obdo) Then
                _Obdo = "Observaciones: " & _Obdo & ", Tipo de entrega: " & _TipoDeEnvio
            ElseIf Not String.IsNullOrWhiteSpace(_TipoDeEnvio) Then
                _Obdo = "Tipo de entrega: " & _TipoDeEnvio
            End If

            Txt_Observaciones.Text = "Razón social: " & _Nokoen & _Obdo

        Catch ex As Exception
            Txt_Observaciones.Text = String.Empty
        End Try
    End Sub

    Private Sub Txt_Ocdo_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Ocdo.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Txt_BuscaXObservaciones_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_BuscaXObservaciones.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Txt_BuscaXNudoNVV_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_BuscaXNudoNVV.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Rdb_FechaFacFechaDespachoNVV_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_FechaFacFechaDespachoNVV.CheckedChanged

        For Each _Fila As DataRow In _Tbl_Documentos.Rows
            If Rdb_FechaFacFechaDespachoNVV.Checked Then
                _Fila.Item("FechaParaFacturacion") = _Fila.Item("FEER")
            Else
                _Fila.Item("FechaParaFacturacion") = Dtp_FechaParaFacturacion.Value
            End If
        Next

    End Sub

    Private Sub Chk_FactConFDespVencida_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_FactConFDespVencida.CheckedChanged

        If Chk_FactConFDespVencida.Checked Then
            If Not Fx_Tiene_Permiso(Me, "Doc00163") Then
                Chk_FactConFDespVencida.Checked = False
            End If
        End If

    End Sub
End Class
