Imports DevComponents.DotNetBar

Public Class Frm_Stmp_IncNVVPicking

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    'Dim _Ds As DataSet
    'Dim _Dv As New DataView

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

        Dtp_BuscaXFechaEmision.Value = #1/1/0001 12:00:00 AM#
        Dtp_BuscaXFechaDespacho.Value = #1/1/0001 12:00:00 AM#

        'Dtp_BuscaXFechaEmision.Value = FechaDelServidor()

        Sb_Actualizar_Grilla()

        'Circular_Progres_Run.IsRunning = True

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

        ' DEBO ENLAZAR LA TABLA Zw_Docu_Det a esta consulta para poner la RtuVariale por productos para las CARNES...

        Dim _Pickear_FacturarAutoCompletas As Integer = Convert.ToInt32(_Global_Row_Configuracion_General.Item("Pickear_FacturarAutoCompletas"))

        Consulta_sql = "Select Cast(0 As Bit) As Pickear,Cast(" & _Pickear_FacturarAutoCompletas & " As Bit) As Facturar,Edo.IDMAEEDO,Edo.EMPRESA,Edo.SUDO,TIDO,Edo.NUDO," & vbCrLf &
                       "Cast(ENDO As Varchar(10)) As ENDO,Cast(SUENDO As Varchar(10)) As SUENDO," & vbCrLf &
                       "Cast('' As Varchar(15)) As Rut,NOKOEN,FEEMDO,FEER,FE01VEDO,FEULVEDO," & vbCrLf &
                       "Case When FEEMDO < FE01VEDO Then 'Credito' Else 'Contado' End As TipoVenta," & vbCrLf &
                       "CONVERT(NVARCHAR, CONVERT(datetime, (Edo.HORAGRAB*1.0/3600)/24), 108) AS HORA,VANEDO," & vbCrLf &
                       "VAIVDO,VAIMDO,VABRDO,VAABDO,KOFUDO,NOKOFU," & vbCrLf &
                       "Cast(0 As Bit) As Facturado,Cast(0 As Int) As IDMAEEDO_FCV,Cast('' As Varchar(10)) As NUDO_FCV," & vbCrLf &
                       "FEEMDO AS Fecha_Emision,Edo.FEER AS Fecha_Despacho,Cast(0 As Float) As VABRDO_FCV,Cast(0 As Float) As VAABDO_FCV," & vbCrLf &
                       "Cast(0 As Bit) As FCV_PAGADA,Cast(0 As Bit) As FCV_IMPRESA," & vbCrLf &
                       "Cast(0 As Int) As IDMAEDPCE,Cast(0 As Float) As VADP,Cast(0 As Float) As VAASDP," & vbCrLf &
                       "Cast(0 As Float) As SALDO,Cast(0 As Bit) As CRV, Cast(0 as Float) SALDO_CRV,Isnull(OBDO,'') As OBDO," & vbCrLf &
                       "Isnull(DocE.HabilitadaFac,1) As HabilitadaFac" & vbCrLf &
                       "Into #Paso" & vbCrLf &
                        "From MAEEDO Edo" & vbCrLf &
                        "Left Join MAEEDOOB Obs On Obs.IDMAEEDO = Edo.IDMAEEDO" & vbCrLf &
                        "Left Join MAEEN On KOEN = ENDO And SUENDO = SUEN" & vbCrLf &
                        "Left Join TABFU On KOFU = KOFUEN" & vbCrLf &
                        "Left Join " & _Global_BaseBk & "Zw_Docu_Ent DocE On DocE.Idmaeedo = Edo.IDMAEEDO" & vbCrLf &
                        "Where 1 > 0" & vbCrLf &
                        "And Edo.IDMAEEDO Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Stmp_Enc Where Estado <> 'NULO' And Empresa = '" & ModEmpresa & "' And Sucursal = '" & ModSucursal & "')" & vbCrLf &
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
                        "Update #Paso Set HORA = SUBSTRING(HORA,1,5),ENDO = Ltrim(Rtrim(ENDO)),SUENDO = Ltrim(Rtrim(SUENDO))" & vbCrLf &
                        "Update #Paso Set SALDO_CRV = VABRDO-VADP Where VADP > 0" & vbCrLf &
                        "Select * From #Paso" & _FiltroTipoVenta & vbCrLf &
                        "Order By IDMAEEDO" & vbCrLf &
                        "Drop Table #Paso"

        _Tbl_Documentos = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Documentos

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            .Columns("Pickear").HeaderText = "Pickear"
            .Columns("Pickear").Width = 50
            .Columns("Pickear").Visible = True
            .Columns("Pickear").ReadOnly = False
            .Columns("Pickear").DisplayIndex = _DisplayIndex
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
            .Columns("NUDO").Width = 70
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Facturar").HeaderText = "Facturar al completar"
            .Columns("Facturar").ToolTipText = "Facturar automáticamente una vez completado el picking"
            .Columns("Facturar").Width = 70
            .Columns("Facturar").Visible = _Global_Row_Configuracion_General.Item("Pickear_FacturarAutoCompletas")
            .Columns("Facturar").ReadOnly = False
            .Columns("Facturar").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("HabilitadaFac").HeaderText = "Habilitada Facturar"
            .Columns("HabilitadaFac").ToolTipText = "Habilitada ser facturada"
            .Columns("HabilitadaFac").Width = 70
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
            .Columns("NOKOEN").Width = 190
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
            .Columns("OBDO").Width = 200
            .Columns("OBDO").Visible = True
            .Columns("OBDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TipoVenta").HeaderText = "T.Venta"
            .Columns("TipoVenta").Width = 60
            .Columns("TipoVenta").Visible = True
            .Columns("TipoVenta").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMDO").HeaderText = "F.Emisión"
            .Columns("FEEMDO").Width = 70
            .Columns("FEEMDO").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEEMDO").Visible = True
            .Columns("FEEMDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEER").HeaderText = "F.Despacho"
            .Columns("FEER").Width = 70
            .Columns("FEER").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEER").Visible = True
            .Columns("FEER").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("FEULVEDO").HeaderText = "F.Vencimiento"
            '.Columns("FEULVEDO").Width = 70
            '.Columns("FEULVEDO").DefaultCellStyle.Format = "dd/MM/yyyy"
            '.Columns("FEULVEDO").Visible = True
            '.Columns("FEULVEDO").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("HORA").HeaderText = "Hora"
            '.Columns("HORA").Width = 50
            '.Columns("HORA").Visible = True
            '.Columns("HORA").DisplayIndex = _DisplayIndex
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

        If _Global_Row_Configuracion_General.Item("LasNVVDebenSerHabilitadasParaFacturar") AndAlso
            (_Cabeza = "Facturar" Or _Cabeza = "Pickear") AndAlso
            _Fila.Cells(_Cabeza).Value AndAlso
            Not _Fila.Cells("HabilitadaFac").Value Then

            _Fila.Cells(_Cabeza).Value = False
            MessageBoxEx.Show(Me, "Esta nota de venta no ha sido habilitada para ser facturada", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

    End Sub

    Private Sub Chk_PickearTodo_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_PickearTodo.CheckedChanged

        Try

            If Not Chk_PickearTodo.Checked Then

                For Each _Fila As DataRow In _Tbl_Documentos.Rows
                    _Fila.Item("Pickear") = Chk_PickearTodo.Checked
                Next

                Return

            End If

            Dim _Marcar As Boolean
            Dim _SinHabilitar = 0

            For Each _Fila As DataGridViewRow In Grilla.Rows

                If Not _Fila.Cells("Pickear").Value Then

                    _Marcar = True

                    If _Global_Row_Configuracion_General.Item("LasNVVDebenSerHabilitadasParaFacturar") Then

                        If Not _Fila.Cells("HabilitadaFac").Value Then

                            _Marcar = False
                            _SinHabilitar += 1

                        End If

                    End If

                    _Fila.Cells("Pickear").Value = _Marcar

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

                If _Fila.Item("Pickear") Then
                    _Contador += 1
                End If

            End If

        Next

        If _Contador = 0 Then
            MessageBoxEx.Show(Me, "No hay registros seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Msj_Tsc As LsValiciones.Mensajes

        _Msj_Tsc = Fx_Revisar_Tasa_Cambio(Me, Dtp_FechaParaFacturacion.Value)

        If Not _Msj_Tsc.EsCorrecto Then
            Return
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
            Dim _Pickear As Boolean = _Fila.Item("Pickear")
            Dim _Facturar As Boolean = _Fila.Item("Facturar")

            If _Pickear Then

                _Mensaje_Stem = _Cl_Stmp.Fx_Crear_Ticket(_Idmaeedo,
                                                         _Tido,
                                                         _Nudo,
                                                         _Facturar,
                                                         Dtp_FechaParaFacturacion.Value,
                                                         "R",
                                                         False,
                                                         ModEmpresa,
                                                         ModSucursal,
                                                         FUNCIONARIO)
                _Lista.Add(_Mensaje_Stem)

            End If

        Next

        Return _Lista

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
        Sb_Ver_Documento()
    End Sub

End Class
