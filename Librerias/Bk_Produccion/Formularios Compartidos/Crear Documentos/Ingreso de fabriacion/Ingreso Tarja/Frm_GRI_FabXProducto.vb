Imports System.Runtime.InteropServices
Imports BkSpecialPrograms
Imports BkSpecialPrograms.LsValiciones
Imports DevComponents.DotNetBar

Public Class Frm_GRI_FabXProducto

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Pote As DataRow
    Dim _Row_Potl As DataRow
    Dim _Row_Maepr As DataRow
    Dim _Row_Tabcodal As DataRow

    Dim _FechaDelServidor As Date

    Dim _Cl_Tarja As New Cl_Tarja

    Dim _LotePlantaTurno As Boolean
    Dim _RowBodegaGRI As DataRow
    Private _Ult_Tipo As String
    Private _Ult_Turno As String
    Private _Ult_Turno_Str As String
    Private _Ult_Planta As String
    Private _Ult_Planta_Str As String
    Private _Ult_Tolva As String
    Private _Ult_Tolva_Str As String
    Private _Ult_Lote As String

    Enum Enum_TipoFab
        Ninguno
        Saco
        Pallet
        Maxi
    End Enum

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _FechaDelServidor = FechaDelServidor()

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_GRI_FabXProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'AddHandler Txt_Cantidad.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros_Enteros
        'AddHandler Txt_Cantidad.Validated, AddressOf Sb_Txt_Nros_Validated
        'AddHandler Txt_Cantidad.Enter, AddressOf Sb_Txt_Nros_Enter

        ActiveControl = Txt_Numot
        Sb_Limpiar()
        Sb_LimpiarMaxi()

        _LotePlantaTurno = True

        Chk_FechaEmiFiot.Checked = Not Fx_Tiene_Permiso(Me, "Pdc00009",, False)
        Dtp_Fiot.Enabled = Not Chk_FechaEmiFiot.Checked

        AddHandler Chk_FechaEmiFiot.CheckedChanged, AddressOf Chk_FechaEmiFiot_CheckedChanged

    End Sub

    Private Sub Txt_Numot_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Numot.KeyDown
        If e.KeyValue = Keys.Enter Then
            If String.IsNullOrEmpty(Txt_Numot.Text.Trim) Then
                Call Btn_BuscarOT_Click(Nothing, Nothing)
            Else
                Sb_BuscarOt(Txt_Numot.Text)
            End If
        End If
    End Sub

    Sub Sb_BuscarOt(_Numot As String)

        If Not String.IsNullOrEmpty(_Numot) Then

            Dim _Nudo As String = Fx_Rellena_ceros(_Numot, 10)
            Dim _Nro As String

            _Nro = Replace(_Nudo, "-", ",")

            Dim _Cadena = Split(_Nro, ",")

            If _Cadena.Length = 2 Then
                _Nudo = Fx_Rellena_ceros(_Cadena(1), 10)
            Else
                _Numot = _Nudo
            End If

            Txt_Numot.Text = _Numot

            Consulta_sql = "Select * From POTE Where NUMOT = '" & _Numot & "'"
            _Row_Pote = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row_Pote) Then
                MessageBoxEx.Show(Me, "No existe la OT Nro: " & _Numot, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _Numot = String.Empty
                Txt_Numot.Text = _Numot
                Return
            End If

            If _Row_Pote.Item("ESTADO") = "C" Then
                MessageBoxEx.Show(Me, "la OT Nro: " & _Numot & " Se encuentra cerrada" & vbCrLf &
                                  "No se permite el movimiento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _Numot = String.Empty
                Txt_Numot.Text = _Numot
                Return
            End If

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdp_CPT_MzEnc", "Idpote = " & _Row_Pote.Item("IDPOTE"))

            If CBool(_Reg) Then
                MessageBoxEx.Show(Me, "Esta OT no puede ser procesada por este modulo ya que es una OT de producción de Mezcla",
                              "Validación OT " & _Numot, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _Numot = String.Empty
                Txt_Numot.Text = _Numot
                Return
            End If

            Txt_Numot.ButtonCustom.Visible = True
            Lbl_ReferenciaOT.Text = "REFERENCIA: " & _Row_Pote.Item("REFERENCIA")

            Dtp_Fiot.Value = _Row_Pote.Item("FIOT")

            If Chk_FechaEmiFiot.Checked Then
                Dtp_Fecha_Ingreso.Value = _Row_Pote.Item("FIOT")
            Else
                Dtp_Fecha_Ingreso.Value = _FechaDelServidor
            End If

            Sb_BuscarProductos(_Numot)

            Txt_Numot.Text = _Numot

        End If

    End Sub

    Sub Sb_BuscarProductos(_Numot As String)

        Dim _CreaNuevaOTExtra As Boolean
        Dim _Numot_Extra As String

        Consulta_sql = "Select POTL.*,POTE.CARGO,(FABRICAR-REALIZADO) As SALDO,Case RLUD When 1 Then 0 Else (FABRICAR-REALIZADO)/RLUD End As SALDO2,RLUD" & vbCrLf &
                       "From POTL" & vbCrLf &
                       "Inner Join MAEPR On KOPR = CODIGO" & vbCrLf &
                       "Inner Join POTE On POTE.IDPOTE = POTL.IDPOTE" & vbCrLf &
                       "Where POTL.NUMOT='" & _Numot & "' And POTL.EMPRESA = '" & ModEmpresa & "' And LILG <> 'IM' " &
                       "And Exists (Select TABBOPR.* From TABBOPR " &
                       "Where TABBOPR.KOPR = POTL.CODIGO And TABBOPR.KOSU = '" & ModSucursal & "' AND TABBOPR.KOBO = '" & ModBodega & "')"

        Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim Fm As New Frm_GRI_ProductosOT
        Fm.Text = "COMPONETES DE LA ORDEN DE TRABAJO: " & Txt_Numot.Text
        Fm.MarcarFilasSinSaldo = True
        Fm.Tbl_Productos = _Tbl_Productos
        Fm.ShowDialog(Me)
        _Row_Potl = Fm.FilaSeleccionada
        _CreaNuevaOTExtra = Fm.CreaNuevaOTExtra
        _Numot_Extra = Fm.Numot_Extra
        Fm.Dispose()

        Txt_Numot.ReadOnly = True

        If _CreaNuevaOTExtra Then
            Sb_Limpiar()
            Sb_LimpiarMaxi()
            Txt_Numot.Text = _Numot_Extra
            Dtp_Fiot.Value = _Sql.Fx_Trae_Dato("POTE", "FIOT", "NUMOT = '" & _Numot_Extra & "'")
            Sb_BuscarProductos(_Numot_Extra)
            Return
        End If

        If IsNothing(_Row_Potl) Then
            If String.IsNullOrEmpty(Txt_Codigo.Text) Then
                Grupo_Producto.Text = "DETALLE DE DATOS DE FABRICACION"
                MessageBoxEx.Show(Me, "Debe seleccionar algún producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'Txt_Numot.Text = String.Empty
                Txt_Numot.ButtonCustom.Visible = False
                Txt_Numot.Focus()
            Else
                Txt_Cantidad.Focus()
            End If
            Return
        End If

        Sb_TraerBodegaGRI()

        Grupo_Producto.Text = "DETALLE DE DATOS DE FABRICACION SUBOT: " & _Row_Potl.Item("NREG").ToString.Trim
        Txt_Cantidad.Text = String.Empty
        Txt_Cantidad.Tag = 0

        Grupo_Producto.Enabled = True
        GroupPanel2.Enabled = True
        Txt_Codigo.ButtonCustom.Enabled = True
        Txt_Codigo.Text = _Row_Potl.Item("CODIGO")
        Txt_Descripcion.Text = _Row_Potl.Item("GLOSA")
        Btn_EditFechaGRI.Enabled = True

        Lbl_Fabricar.Text = FormatNumber(_Row_Potl.Item("FABRICAR"), 0)
        Lbl_Realizado.Text = FormatNumber(_Row_Potl.Item("REALIZADO"), 0)
        Lbl_Saldo.Text = FormatNumber(_Row_Potl.Item("SALDO"), 0)

        If _Row_Potl.Item("RLUD") <> 1 Then
            LabelX16.Text = FormatNumber(_Row_Potl.Item("SALDO2"), 0)
            Panel_SC.Visible = True
        End If

        Consulta_sql = "Select * From MAEPR Where KOPR = '" & Txt_Codigo.Text & "'"
        _Row_Maepr = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Arr(,) As String = {{"", ""},
                                             {1, _Row_Maepr.Item("UD01PR")},
                                             {2, _Row_Maepr.Item("UD02PR")}}
        Sb_Llenar_Combos(_Arr, Cmb_Formato)
        Cmb_Formato.SelectedValue = ""

        Dim _TipoFab As Enum_TipoFab = Enum_TipoFab.Ninguno

        If _Ult_Tipo = "MAXI-SACO" Or _Row_Maepr.Item("RLUD") = 1 Then
            _TipoFab = Enum_TipoFab.Maxi
        End If

        Sb_TipoIngreso(_Row_Maepr.Item("KOPR"), _Row_Maepr.Item("RLUD"), _TipoFab)

        Txt_Cantidad.Enabled = True
        Txt_Cantidad.Focus()

    End Sub

    Sub Sb_TipoIngreso(_Codigo As String, _Rtu As Double, _TipoFab As Enum_TipoFab)

        Dim _Row_Tabcodal As DataRow

        Dim Rdb_Sacos As New Command
        Rdb_Sacos.Checked = False
        Rdb_Sacos.Name = "Rdb_Sacos"
        Rdb_Sacos.Text = "SACOS"

        Dim Rdb_Pallets As New Command
        Rdb_Pallets.Checked = False
        Rdb_Pallets.Name = "Rdb_Pallets"
        Rdb_Pallets.Text = "PALLETS"

        Dim Rdb_Maxi As New Command
        Rdb_Maxi.Checked = False
        Rdb_Maxi.Name = "Rdb_Maxi"
        Rdb_Maxi.Text = "SACO (MAXI)"

        If Not IsNothing(_TipoFab) Then
            Select Case _TipoFab
                Case Enum_TipoFab.Saco
                    Rdb_Sacos.Checked = True
                Case Enum_TipoFab.Pallet
                    Rdb_Pallets.Checked = True
                Case Enum_TipoFab.Maxi
                    Rdb_Maxi.Checked = True
            End Select
        End If

        If _Row_Maepr.Item("RLUD") = 1 Then
            Rdb_Sacos.Enabled = False
            Rdb_Pallets.Enabled = False
            Rdb_Maxi.Checked = True
        End If

        Dim _Opciones() As Command = {Rdb_Sacos, Rdb_Pallets, Rdb_Maxi}

        Dim _Info As New TaskDialogInfo("Ingreso de fabricación",
                  eTaskDialogIcon.CheckMark2,
                  "Tipo de ingreso",
                  "Seleccione su opción",
                  eTaskDialogButton.Ok + eTaskDialogButton.Cancel,
                  eTaskDialogBackgroundColor.OliveGreen, _Opciones, Nothing, Nothing, Nothing, Nothing)

        Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

        If _Resultado <> eTaskDialogResult.Ok Then
            Sb_Limpiar()
            Sb_LimpiarMaxi()
            Return
        End If

        If Not Rdb_Sacos.Checked AndAlso Not Rdb_Pallets.Checked AndAlso Not Rdb_Maxi.Checked Then
            MessageBoxEx.Show(Me, "Debe seleccionar un tipo de ingreso SACOS, PALLETS o  MAXI-SACO",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Sb_TipoIngreso(_Codigo, _Rtu, Nothing)
            Return
        End If

        Dim _Tipo As String
        Dim _Tipo_Str As String
        Dim _Unimulti As Integer
        Dim _Multiplo As Integer
        Dim _Cantidad_Fab As Double

        If Rdb_Maxi.Checked Then

            _Tipo = "MAXI-SACO"
            _Tipo_Str = _Row_Maepr.Item("UD01PR")
            _Unimulti = 1
            _Multiplo = 1

        Else

            Sb_LimpiarMaxi()

            If Rdb_Sacos.Checked Then _Tipo = "SACO"
            If Rdb_Pallets.Checked Then _Tipo = "PALLET"

            _Tipo_Str = _Tipo & "S"

            Consulta_sql = "Select Top 1 * From TABCODAL Where KOPR = '" & _Codigo & "' And TXTMULTI = '" & _Tipo & "'"
            _Row_Tabcodal = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row_Tabcodal) Then
                MessageBoxEx.Show(Me, "No existe código alternativo para " & _Tipo & " para este producto",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Sb_TipoIngreso(_Codigo, _Rtu, Nothing)
                Return
            End If

            _Unimulti = _Row_Tabcodal.Item("UNIMULTI")
            _Multiplo = _Row_Tabcodal.Item("MULTIPLO")

        End If


        Dim _Cantidad As Double
        Dim _Aceptar As Boolean = InputBox_Bk(Me, "Ingrese la cantidad de " & _Tipo_Str & " fabricados", "Ingresar cantidad",
                                              _Cantidad, False,, 5, True,
                                              _Tipo_Imagen.Product,, _Tipo_Caracter.Solo_Numeros_Enteros, False)

        If Not _Aceptar Then
            Sb_TipoIngreso(_Codigo, _Rtu, Nothing)
            Return
        End If

        If _Unimulti = 1 Then
            _Cantidad_Fab = _Multiplo * _Cantidad
        Else
            _Cantidad_Fab = _Multiplo * (_Rtu * _Cantidad)
        End If

        If (_Cantidad_Fab + _Row_Potl.Item("REALIZADO")) > _Row_Potl.Item("FABRICAR") Then
            MessageBoxEx.Show(Me, "Usted no puede recepcionar más que el SALDO indicado en la orden", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Sb_TipoIngreso(_Codigo, _Rtu, Nothing)
            Return
        End If

        Txt_Cantidad.Text = FormatNumber(_Cantidad_Fab, 0)
        Txt_Cantidad.Tag = _Cantidad_Fab

        Dim _Kopral As String
        Dim _Nokopral As String
        Dim _Sacos As Integer
        Dim _SacosXPallet As Integer
        Dim _Ud01Pr As String
        Dim _Ud02Pr As String
        Dim _Txtmulti As String
        Dim _Udad As String

        If Rdb_Maxi.Checked Then

            If _Cantidad < 400 Or _Cantidad > 1500 Then

                Dim _Seguir = False

                If MessageBoxEx.Show(Me, "La cantidad del MAXI-SACO debe estan entre un rango de 400 y 1500 kilos" & vbCrLf &
                                     "¿Confirma igualmente ingresar la cantidad de " & _Cantidad & " kilos?", "Validación",
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Stop) = DialogResult.Yes Then
                    _Seguir = Fx_Tiene_Permiso(Me, "Pdc00013")
                End If

                If Not _Seguir Then
                    Sb_TipoIngreso(_Codigo, _Rtu, Enum_TipoFab.Maxi)
                    Return
                End If

            End If


            _Kopral = _Row_Maepr.Item("KOPR")
            _Nokopral = _Row_Maepr.Item("KOPR").ToString.Trim & " - " & _Row_Maepr.Item("NOKOPR").ToString.Trim

            _Sacos = Txt_Cantidad.Tag / _Rtu
            _SacosXPallet = 1
            _Ud01Pr = _Row_Maepr.Item("UD01PR")
            _Ud02Pr = _Row_Maepr.Item("UD02PR")
            _Txtmulti = _Tipo
            _Cantidad = 1
            _Udad = _Ud01Pr

        Else

            _Kopral = _Row_Tabcodal.Item("KOPRAL")
            _Nokopral = _Row_Tabcodal.Item("KOPRAL").ToString.Trim & " - " & _Row_Tabcodal.Item("NOKOPRAL").ToString.Trim
            _Sacos = Txt_Cantidad.Tag / _Rtu
            _SacosXPallet = _Row_Tabcodal.Item("MULTIPLO")
            _Ud01Pr = _Row_Maepr.Item("UD01PR")
            _Ud02Pr = _Row_Maepr.Item("UD02PR")
            _Txtmulti = _Row_Tabcodal.Item("TXTMULTI").ToString.Trim

            If _Row_Tabcodal.Item("UNIMULTI") = 1 Then
                _Udad = _Ud01Pr
            Else
                _Udad = _Ud02Pr
            End If

        End If

        _Cl_Tarja.Zw_Pdp_CPT_Tarja.SacosXPallet = _SacosXPallet
        _Cl_Tarja.Zw_Pdp_CPT_Tarja.CodAlternativo_Pallet = _Kopral

        _Cl_Tarja.Zw_Pdp_CPT_Tarja.Tipo = _Txtmulti
        _Cl_Tarja.Zw_Pdp_CPT_Tarja.CantidadFab = _Cantidad_Fab
        _Cl_Tarja.Zw_Pdp_CPT_Tarja.CantidadTipo = _Cantidad

        Lbl_Tipo.Text = _Tipo
        Txt_Descripcion_Kopral.Text = _Kopral.ToString.Trim & ", Udad: " & _Udad & " x " & _Sacos & ", Formato: " & _Txtmulti & " X " & FormatNumber(_Cantidad, 0)
        _Cl_Tarja.Zw_Pdp_CPT_Tarja.Descripcion_Kopral = _Nokopral.ToString.Trim & ", Udad: " & _Udad & " x " & _Sacos & ", Formato: " & _Txtmulti & " X " & FormatNumber(_Cantidad, 0)

        If _Ult_Tipo = "MAXI-SACO" Then

            If MessageBoxEx.Show(Me, "¿Quiere seguir utilizando los datos de MAXI fabricado anteriormente?" & vbCrLf & vbCrLf &
                                 "Turno: " & _Ult_Turno_Str.Trim & vbCrLf &
                                 "Planta: " & _Ult_Planta_Str.Trim & vbCrLf &
                                 "Tolva: " & _Ult_Tolva_Str.Trim & vbCrLf &
                                 "Lote: " & _Ult_Lote,
                                 "Fabricar MAXI-SACO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                _Cl_Tarja.Zw_Pdp_CPT_Tarja.Tipo = _Ult_Tipo
                _Cl_Tarja.Zw_Pdp_CPT_Tarja.Turno = _Ult_Turno
                Txt_Turno.Text = _Ult_Turno_Str
                _Cl_Tarja.Zw_Pdp_CPT_Tarja.Planta = _Ult_Planta
                Txt_Planta.Text = _Ult_Planta_Str
                _Cl_Tarja.Zw_Pdp_CPT_Tarja.Tolva = _Ult_Tolva
                Txt_Tolva.Text = _Ult_Tolva_Str
                _Cl_Tarja.Zw_Pdp_CPT_Tarja.Lote = _Ult_Lote
                Txt_NroLote.Text = _Ult_Lote
                Cmb_Formato.SelectedValue = 1

                Btn_Grabar.Focus()

            End If

        Else

            Call Txt_NroLote_ButtonCustomClick(Nothing, Nothing)

        End If

    End Sub

    Private Sub Btn_Limpiar_Click(sender As Object, e As EventArgs) Handles Btn_Limpiar.Click
        Sb_Limpiar()
        Sb_LimpiarMaxi()
    End Sub

    Sub Sb_Limpiar()

        Dtp_Fecha_Ingreso.Value = _FechaDelServidor
        Dtp_Fecha_Ingreso.Enabled = False
        Btn_EditFechaGRI.Enabled = False
        Dtp_Fiot.Value = Nothing
        Txt_Numot.ReadOnly = False
        Txt_Numot.Text = String.Empty
        Txt_Numot.ButtonCustom.Visible = False
        Grupo_Producto.Enabled = False
        Txt_Codigo.Text = String.Empty
        Txt_Codigo.ButtonCustom.Enabled = False
        Txt_Descripcion.Text = String.Empty
        Lbl_ReferenciaOT.Text = "REFERENCIA:"
        Txt_Cantidad.Enabled = False
        Txt_Cantidad.Text = String.Empty
        Txt_Cantidad.Tag = 0
        'Btn_Grabar.Enabled = False
        Lbl_Fabricar.Text = "0"
        Lbl_Realizado.Text = "0"
        Lbl_Saldo.Text = "0"
        Txt_Numot.Focus()
        Grupo_Producto.Text = "DETALLE DE DATOS DE FABRICACION"

        GroupPanel2.Enabled = False
        Txt_NroLote.Text = String.Empty

        If Not _LotePlantaTurno Then
            Txt_Turno.Text = String.Empty
            _Cl_Tarja.Zw_Pdp_CPT_Tarja.Turno = String.Empty
            Txt_Planta.Text = String.Empty
            _Cl_Tarja.Zw_Pdp_CPT_Tarja.Planta = String.Empty
        End If

        _Cl_Tarja.Zw_Pdp_CPT_Tarja.Tolva = String.Empty
        Txt_Tolva.Text = String.Empty

        Txt_Analista.Text = String.Empty

        _Cl_Tarja.Zw_Pdp_CPT_Tarja.Analista = FUNCIONARIO
        _Cl_Tarja.Zw_Pdp_CPT_Tarja_Det_Ls.Clear()

        Txt_Analista.Text = Nombre_funcionario_activo.ToString.Trim

        Txt_Descripcion_Kopral.Text = String.Empty
        Txt_Observaciones.Text = String.Empty
        Txt_Observaciones.ReadOnly = False
        Cmb_Formato.DataSource = Nothing

        Panel_SC.Visible = False

        Me.Refresh()

    End Sub

    Sub Sb_LimpiarMaxi()
        _Ult_Tipo = String.Empty
        _Ult_Lote = String.Empty
        _Ult_Tipo = String.Empty
        _Ult_Turno = String.Empty
        _Ult_Turno_Str = String.Empty
        _Ult_Planta = String.Empty
        _Ult_Planta_Str = String.Empty
        _Ult_Tolva = String.Empty
        _Ult_Tolva_Str = String.Empty
    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Sb_Grabar()

    End Sub

    Private Sub Sb_Txt_Nros_Validated(sender As Object, e As EventArgs)
        'Btn_Grabar.Enabled = True
        CType(sender, Controls.TextBoxX).Tag = Val(CType(sender, Controls.TextBoxX).Text)
        CType(sender, Controls.TextBoxX).Text = FormatNumber(CType(sender, Controls.TextBoxX).Tag, 0)
    End Sub

    Private Sub Sb_Txt_Nros_Enter(sender As Object, e As EventArgs)
        CType(sender, Controls.TextBoxX).Text = CType(sender, Controls.TextBoxX).Tag
        'Btn_Grabar.Enabled = False
    End Sub

    Private Sub Txt_Cantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Cantidad.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then ' Comprueba si se presionó la tecla ENTER
            e.Handled = True ' Evita que el ENTER se refleje en el TextBox
            Me.SelectNextControl(ActiveControl, True, True, True, True) ' Salta al siguiente control
        End If
    End Sub

    Private Sub Txt_Numot_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Numot.ButtonCustomClick
        Sb_BuscarProductos(Txt_Numot.Text)
    End Sub

    Private Sub Txt_NroLote_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_NroLote.ButtonCustomClick

        If _LotePlantaTurno Then

            If String.IsNullOrEmpty(Txt_Turno.Text) Then Call Txt_Turno_ButtonCustomClick(Nothing, Nothing)
            If String.IsNullOrEmpty(Txt_Turno.Text) Then
                MessageBoxEx.Show(Me, "Falta el TURNO para generar el número de Lote", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            If String.IsNullOrEmpty(Txt_Planta.Text) Then Call Txt_Planta_ButtonCustomClick(Nothing, Nothing)
            If String.IsNullOrEmpty(Txt_Planta.Text) Then
                MessageBoxEx.Show(Me, "Falta la PLANTA para generar el número de Lote", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        End If

        If String.IsNullOrEmpty(Txt_Tolva.Text) Then Call Txt_Tolva_ButtonCustomClick(Nothing, Nothing)

        Dim _Aceptar As Boolean
        Dim _NroLote As String

        Dim _NoPermitirEntradaDeTeclado As Boolean = CBool(_Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones",
                                                          "Valor",
                                                          "Tabla = 'TARJA_INGLOTES' And CodigoTabla = 'INGLOTES'", True))

        _Aceptar = InputBox_Bk(Me, "Ingrese el número de Lote", "Número de Lote", _NroLote, False,, 20, True,,,,,,,, _NoPermitirEntradaDeTeclado)

        If Not _Aceptar Then
            Return
        End If

        If _LotePlantaTurno Then
            _NroLote = _Cl_Tarja.Zw_Pdp_CPT_Tarja.Planta & "" & _Cl_Tarja.Zw_Pdp_CPT_Tarja.Turno & _NroLote
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Lotes_Enc Where NroLote = '" & _NroLote & "'"
        Dim _Row_Lote As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Lote) Then

            If MessageBoxEx.Show(Me, "El Número de Lote no esta registrado en el sistema" & vbCrLf & vbCrLf &
                              "¿Confirma la grabación de este nuevo lote?", "Validación",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                Return
            End If

            Dim _FechaVencimiento As DateTime = DateAdd(DateInterval.Year, 1, Dtp_Fecha_Ingreso.Value)
            Dim _Kopral = String.Empty

            If _Cl_Tarja.Zw_Pdp_CPT_Tarja.Tipo <> "MAXI-SACO" Then

                Consulta_sql = "Select Top 1 * From TABCODAL Where KOPR = '" & Txt_Codigo.Text & "' And TXTMULTI = 'SACO'"
                Dim _Row_Saco As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If IsNothing(_Row_Saco) Then
                    MessageBoxEx.Show(Me, "No existe código alternativo asociado a los SACOS", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                _Kopral = _Row_Saco.Item("KOPRAL").ToString.Trim

            End If

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Lotes_Enc (NroLote,Codigo,FechaVenci,CodAlternativo) Values " &
                       "('" & _NroLote & "','" & Txt_Codigo.Text &
                       "','" & Format(_FechaVencimiento, "yyyyMMdd") & "','" & _Kopral & "')"
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Lotes_Enc Where NroLote = '" & _NroLote & "'"
                _Row_Lote = _Sql.Fx_Get_DataRow(Consulta_sql)
            End If

            '_Row_Lote = Fx_Ingresar_Lote(_NroLote)

            If IsNothing(_Row_Lote) Then
                Return
            End If

        End If

        If _Row_Lote.Item("Codigo").ToString.Trim <> Txt_Codigo.Text.Trim Then

            'MessageBoxEx.Show(Me, "El número de lote " & _NroLote & " no pertence al producto " & Txt_Codigo.Text.Trim & vbCrLf & vbCrLf &
            '                  "El lote " & _NroLote & " es del producto " & _Row_Lote.Item("Codigo").ToString.Trim, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            MessageBoxEx.Show(Me, "El número de lote " & _NroLote & " pertence al producto " & _Row_Lote.Item("Codigo").ToString.Trim & vbCrLf & vbCrLf &
                              "No puede grabar el mismo numero de lote para otro producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Return
        End If

        MessageBoxEx.Show(Me, "Lote aceptado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)

        If _LotePlantaTurno Then
            Sb_Actualizar_Parametros_SQL(True)
        End If

        Txt_NroLote.Text = _NroLote

        Txt_Observaciones.Text = String.Empty
        Txt_Observaciones.ReadOnly = False

        Consulta_sql = "Select * From TABCODAL Where KOPRAL = '" & _Row_Lote.Item("CodAlternativo") & "'"
        Dim _Row_Tabcodal As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        _Cl_Tarja.Zw_Pdp_CPT_Tarja.Lote = _NroLote
        _Cl_Tarja.Zw_Pdp_CPT_Tarja.CodAlternativo = _Row_Lote.Item("CodAlternativo")

        If IsNothing(_Row_Tabcodal) Then
            Cmb_Formato.SelectedValue = 1
        Else
            Cmb_Formato.SelectedValue = _Row_Tabcodal.Item("UNIMULTI")
        End If

        If Not _LotePlantaTurno Then
            Txt_Turno.Text = String.Empty
            _Cl_Tarja.Zw_Pdp_CPT_Tarja.Turno = String.Empty
            Txt_Planta.Text = String.Empty
            _Cl_Tarja.Zw_Pdp_CPT_Tarja.Planta = String.Empty
            Sb_Actualizar_Parametros_SQL(False)
        End If

    End Sub

    Function Fx_Ingresar_Lote(_Nro_Lote As String) As DataRow

        Dim _Row_Lote As DataRow

        Dim Fm As New Frm_Lote_Ing(_Nro_Lote, Txt_Codigo.Text)
        Fm.ShowDialog(Me)

        If Fm.Grabar Then

            _Nro_Lote = Fm.NroLote

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Lotes_Enc Where NroLote = '" & _Nro_Lote & "'"
            _Row_Lote = _Sql.Fx_Get_DataRow(Consulta_sql)

        End If

        Fm.Dispose()

        Return _Row_Lote

    End Function

    Private Sub Txt_NroLote_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_NroLote.KeyDown
        If e.KeyValue = Keys.Enter Then
            Call Txt_NroLote_ButtonCustomClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub Txt_CodAlternativo_Pallet_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Descripcion_Kopral.ButtonCustomClick

        Dim _Codigo As String = _Row_Maepr.Item("KOPR")
        Dim _Descripcion As String = _Row_Maepr.Item("NOKOPR")
        Dim _Rtu As Double = _Row_Maepr.Item("RLUD")

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("TABCODAL", "KOPR = '" & _Codigo & "'")

        If _Reg = 0 Then
            MessageBoxEx.Show(Me, "Este producto no tiene códigos alternativos asociados", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_CodAlternativo_Ver
        Fm.TxtCodigo.Text = _Codigo
        Fm.Txtdescripcion.Text = _Descripcion
        Fm.TxtRTU.Text = _Rtu
        Fm.ModoSeleccion = True
        Fm.ShowDialog(Me)
        _Row_Tabcodal = Fm.RowTabcodalSeleccionado
        Fm.Dispose()

        If Not IsNothing(_Row_Tabcodal) Then

            Dim _Kopral As String = _Row_Tabcodal.Item("KOPRAL")
            Dim _Sacos As Integer = Txt_Cantidad.Tag / _Rtu
            Dim _SacosXPallet As Integer = _Row_Tabcodal.Item("MULTIPLO")
            Dim _Ud01Pr As String = _Row_Maepr.Item("UD01PR")
            Dim _Ud02Pr As String = _Row_Maepr.Item("UD02PR")
            Dim _Txtmulti As String = _Row_Tabcodal.Item("TXTMULTI")
            Dim _Udad As String

            If _Row_Tabcodal.Item("UNIMULTI") = 1 Then
                _Udad = _Ud01Pr
            Else
                _Udad = _Ud02Pr
            End If

            _Cl_Tarja.Zw_Pdp_CPT_Tarja.SacosXPallet = _SacosXPallet
            _Cl_Tarja.Zw_Pdp_CPT_Tarja.CodAlternativo_Pallet = _Kopral

            Txt_Descripcion_Kopral.Text = _Row_Tabcodal.Item("KOPRAL").ToString.Trim & ", Udad: " & _Udad & " x " & _Sacos & ", Formato: " & _Txtmulti

        End If

    End Sub

    Private Sub Txt_Turno_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Turno.ButtonCustomClick

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
        _Filtrar.Campo = "CodigoTabla"
        _Filtrar.Descripcion = "NombreTabla"
        _Filtrar.Pro_Nombre_Encabezado_Informe = "TURNO"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra,
                               "And Tabla = 'TARJA_TURNO'",
                               False, False, True, False,, False) Then

            _Cl_Tarja.Zw_Pdp_CPT_Tarja.Turno = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Txt_Turno.Text = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Descripcion")

            If Not String.IsNullOrEmpty(Txt_NroLote.Text) Then
                MessageBoxEx.Show(Me, "Se borra el Número de lote, debe ingresarlo nuevamente", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_NroLote.Text = String.Empty
                Txt_NroLote.Focus()
            End If

        End If

    End Sub

    Private Sub Txt_Planta_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Planta.ButtonCustomClick

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
        _Filtrar.Campo = "CodigoTabla"
        _Filtrar.Descripcion = "NombreTabla"
        _Filtrar.Pro_Nombre_Encabezado_Informe = "PLANTA"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra,
                               "And Tabla = 'TARJA_PLANTA'",
                               False, False, True, False,, False) Then

            _Cl_Tarja.Zw_Pdp_CPT_Tarja.Planta = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Txt_Planta.Text = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Descripcion")

            If Not String.IsNullOrEmpty(Txt_NroLote.Text) Then
                MessageBoxEx.Show(Me, "Se borra el Número de lote, debe ingresarlo nuevamente", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_NroLote.Text = String.Empty
                Txt_NroLote.Focus()
            End If

        End If

    End Sub

    Private Sub Txt_Analista_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Analista.ButtonCustomClick

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
        _Filtrar.Campo = "CodigoTabla"
        _Filtrar.Descripcion = "NombreTabla"
        _Filtrar.Pro_Nombre_Encabezado_Informe = "ANALISTA"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra,
                               "And Tabla = 'TARJA_ANALISTA'",
                               False, False, True, False,, False) Then

            _Cl_Tarja.Zw_Pdp_CPT_Tarja.Analista = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Txt_Analista.Text = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Descripcion")
            Txt_Observaciones.Focus()

        End If

    End Sub

    Sub Sb_Actualizar_Parametros_SQL(_Actualizar As Boolean)

        Dim _Turno = _Cl_Tarja.Zw_Pdp_CPT_Tarja.Turno
        Dim _Planta = _Cl_Tarja.Zw_Pdp_CPT_Tarja.Planta
        'Dim _Analista = _Cl_Tarja._Cl_Tarja_Ent.Analista

        _Sql.Sb_Parametro_Informe_Sql(_Turno, "Produccion_Tarja",
                                      "Tarja_Turno", Class_SQL.Enum_Type._String, _Turno, _Actualizar,, True)
        _Sql.Sb_Parametro_Informe_Sql(_Planta, "Produccion_Tarja",
                                      "Tarja_Planta", Class_SQL.Enum_Type._String, _Planta, _Actualizar,, True)
        '_Sql.Sb_Parametro_Informe_Sql(_Analista, "Produccion_Tarja",
        '                              "Tarja_Analista", Class_SQL.Enum_Type._String, _Analista, _Actualizar,, True)

        If Not _Actualizar Then

            _Cl_Tarja.Zw_Pdp_CPT_Tarja.Turno = _Turno
            _Cl_Tarja.Zw_Pdp_CPT_Tarja.Planta = _Planta
            '   _Cl_Tarja._Cl_Tarja_Ent.Analista = _Analista

            Txt_Turno.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones",
                                                "NombreTabla", "Tabla = 'TARJA_TURNO' And CodigoTabla = '" & _Turno & "'")
            Txt_Planta.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones",
                                                "NombreTabla", "Tabla = 'TARJA_PLANTA' And CodigoTabla = '" & _Planta & "'")
            '   Txt_Analista.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones",
            '                                       "NombreTabla", "Tabla = 'TARJA_ANALISTA' And CodigoTabla = '" & _Analista & "'")
        End If

    End Sub

    Private Sub Frm_GRI_FabXProducto_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Sb_Actualizar_Parametros_SQL(True)
    End Sub

    Private Sub Txt_Cantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Cantidad.KeyDown

        If e.KeyValue = Keys.Enter Then

        End If

    End Sub

    Private Sub Txt_Cantidad_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Cantidad.ButtonCustomClick
        Sb_TipoIngreso(_Row_Maepr.Item("KOPR"), _Row_Maepr.Item("RLUD"), Nothing)
    End Sub

    Private Sub Btn_BuscarOT_Click(sender As Object, e As EventArgs) Handles Btn_BuscarOT.Click

        Dim _Seleccionada As Boolean
        Dim _Numot As String

        Dim Fm As New Frm_BuscarOT
        Fm.ShowDialog(Me)
        _Seleccionada = Fm.Seleccionada
        _Numot = Fm.Numot
        Fm.Dispose()

        If _Seleccionada Then
            Sb_Limpiar()
            Sb_LimpiarMaxi()
            Txt_Numot.Text = _Numot
            Sb_BuscarOt(_Numot)
        End If

    End Sub

    Sub Sb_Grabar()

        If String.IsNullOrEmpty(Txt_Numot.Text) Then
            MessageBoxEx.Show(Me, "Falta la OT", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If IsNothing(_Row_Maepr) Then
            MessageBoxEx.Show(Me, "Falta el producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Consulta_sql = "Select Top 1 * From CONFIGP Where EMPRESA = '" & ModEmpresa & "'"
        Dim _Row_Configp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Koen As String = _Row_Configp.Item("RUT").ToString.Trim
        Dim _Observaciones As String

        Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Koen & "'"
        Dim _Row_Entidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Cantidad As String = De_Num_a_Tx_01(Txt_Cantidad.Tag, False, 5)

        Dim _Ud2 As String = _Row_Maepr.Item("UD02PR")
        Dim _Cantidadv As Double = Txt_Cantidad.Tag
        Dim _Rtu As Double = _Row_Maepr.Item("RLUD")
        Dim _Resultado As Double = _Cantidadv / _Rtu

        If _Cantidadv = 0 Then
            MessageBoxEx.Show(Me, "Debe ingresar la cantidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Cantidad.Focus()
            Return
        End If

        If (_Cantidadv + _Row_Potl.Item("REALIZADO")) > _Row_Potl.Item("FABRICAR") Then
            MessageBoxEx.Show(Me, "Usted no puede recepcionar más que el SALDO indicado en la orden", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Cantidad.Focus()
            Return
        End If

        If Not (_Resultado Mod 1 = 0) And _Cl_Tarja.Zw_Pdp_CPT_Tarja.Tipo <> "MAXI-SACO" Then
            MessageBoxEx.Show(Me, "La cantidad ingresada no es divisible por la unidad 2 " & _Ud2 & "-" & _Rtu, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Cantidad.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_NroLote.Text) Then
            MessageBoxEx.Show(Me, "Falta el numero de lote", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_NroLote.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Turno.Text) Then
            MessageBoxEx.Show(Me, "Falta el turno", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Turno.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Planta.Text) Then
            MessageBoxEx.Show(Me, "Falta la planta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Planta.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Tolva.Text) Then
            MessageBoxEx.Show(Me, "Falta la tolva", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Tolva.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Descripcion_Kopral.Text) Then
            MessageBoxEx.Show(Me, "Falta el pallet", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Descripcion_Kopral.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Analista.Text) Then
            MessageBoxEx.Show(Me, "Falta el analista", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Analista.Focus()
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Confirma la grabación por " & _Cl_Tarja.Zw_Pdp_CPT_Tarja.CantidadTipo & " (" & _Cl_Tarja.Zw_Pdp_CPT_Tarja.Tipo & ") " & vbCrLf &
                                "Equivalente a " & Txt_Cantidad.Text & " " & LabelX3.Text & "?",
                             "Confirmar Grabación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Txt_Cantidad.Focus()
            Return
        End If

        _Cl_Tarja.Zw_Pdp_CPT_Tarja.Codigo = _Row_Maepr.Item("KOPR")
        _Cl_Tarja.Zw_Pdp_CPT_Tarja.Idpote = _Row_Potl.Item("IDPOTE")
        _Cl_Tarja.Zw_Pdp_CPT_Tarja.Idpotl = _Row_Potl.Item("IDPOTL")

        If _Cl_Tarja.Zw_Pdp_CPT_Tarja.Tipo = "MAXI-SACO" Then

            Consulta_sql = "Select Top 1 * From TABCODAL" & vbCrLf &
                           "Where KOPR = '" & _Cl_Tarja.Zw_Pdp_CPT_Tarja.Codigo & "' " &
                           "And TXTMULTI = '" & _Cl_Tarja.Zw_Pdp_CPT_Tarja.Tipo & "' " &
                           "And MULTIPLO = " & _Cl_Tarja.Zw_Pdp_CPT_Tarja.CantidadFab
            _Row_Tabcodal = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Kopral As String
            Dim _Nokopral As String

            If IsNothing(_Row_Tabcodal) Then

                _Kopral = _Row_Maepr.Item("KOPR").ToString.Trim & "-M" & _Cl_Tarja.Zw_Pdp_CPT_Tarja.CantidadFab
                _Nokopral = _Row_Maepr.Item("NOKOPR").ToString.Trim

                Consulta_sql = "Insert Into TABCODAL (KOPRAL,KOPR,NOKOPRAL,CONMULTI,UNIMULTI,MULTIPLO,TXTMULTI) Values " &
                               "('" & _Kopral & "','" & _Cl_Tarja.Zw_Pdp_CPT_Tarja.Codigo & "','" & _Nokopral & "',1,1," &
                               De_Txt_a_Num_01(_Cl_Tarja.Zw_Pdp_CPT_Tarja.CantidadFab, 5) & ",'" & _Cl_Tarja.Zw_Pdp_CPT_Tarja.Tipo & "')"
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                    Consulta_sql = "Select Top 1 * From TABCODAL Where KOPRAL = '" & _Kopral & "'"
                    _Row_Tabcodal = _Sql.Fx_Get_DataRow(Consulta_sql)

                End If

            End If

            _Kopral = _Row_Tabcodal.Item("KOPRAL")
            _Nokopral = _Row_Tabcodal.Item("KOPRAL").ToString.Trim & " - " & _Row_Tabcodal.Item("NOKOPRAL").ToString.Trim

            _Cl_Tarja.Zw_Pdp_CPT_Tarja.CodAlternativo = _Kopral

        End If



        ' Obtener la fecha actual
        Dim fechaActual As Date = Dtp_Fecha_Ingreso.Value.Date
        ' Obtener la hora actual
        Dim horaActual As TimeSpan = DateTime.Now.TimeOfDay

        ' Combinar la fecha y la hora en una variable DateTime
        Dim _FechaElab As DateTime = fechaActual + horaActual
        Dtp_Fecha_Ingreso.Value = _FechaElab

        _Cl_Tarja.Zw_Pdp_CPT_Tarja.FechaElab = Dtp_Fecha_Ingreso.Value
        _Cl_Tarja.Zw_Pdp_CPT_Tarja.Observaciones = Txt_Observaciones.Text
        _Cl_Tarja.Zw_Pdp_CPT_Tarja.Udm = Cmb_Formato.Text

        If Cmb_Formato.SelectedValue = 1 Then
            _Cl_Tarja.Zw_Pdp_CPT_Tarja.Formato = 1
        Else
            _Cl_Tarja.Zw_Pdp_CPT_Tarja.Formato = _Row_Maepr.Item("RLUD")
        End If

        If _Cl_Tarja.Zw_Pdp_CPT_Tarja.Tipo = "PALLET" Or _Cl_Tarja.Zw_Pdp_CPT_Tarja.Tipo = "MAXI-SACO" Then

            _Cl_Tarja.Zw_Pdp_CPT_Tarja_Det_Ls.Clear()

            For i = 1 To _Cl_Tarja.Zw_Pdp_CPT_Tarja.CantidadTipo

                Dim _Tj_Det As New Zw_Pdp_CPT_Tarja_Det

                _Tj_Det.Idmaeddo = 0
                _Tj_Det.Tipo = _Cl_Tarja.Zw_Pdp_CPT_Tarja.Tipo
                _Tj_Det.Nro = i
                _Tj_Det.Lote = String.Empty
                _Tj_Det.Nro_CPT = String.Empty
                _Tj_Det.Codigo = _Cl_Tarja.Zw_Pdp_CPT_Tarja.Codigo
                _Tj_Det.CodAlternativo = _Cl_Tarja.Zw_Pdp_CPT_Tarja.CodAlternativo
                _Tj_Det.CodAlternativo_Pallet = _Cl_Tarja.Zw_Pdp_CPT_Tarja.CodAlternativo_Pallet

                _Cl_Tarja.Zw_Pdp_CPT_Tarja_Det_Ls.Add(_Tj_Det)

            Next

        End If

        Dim _EmpresaGRI As String = _RowBodegaGRI.Item("EMPRESA")
        Dim _SucursalGRI As String = _RowBodegaGRI.Item("KOSU")
        Dim _BodegaGRI As String = _RowBodegaGRI.Item("KOBO")

        Consulta_sql = "Select *," & _Cantidad & " As Cantidad,'" & _SucursalGRI & "' As Sucursal,'" & _BodegaGRI & "' As Bodega" & vbCrLf &
                       "From POTL Where IDPOTL = " & _Row_Potl.Item("IDPOTL")
        Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        _Cl_Tarja.Zw_Pdp_CPT_Tarja.Idmaeddo = 0

        Dim _Mensaje As New LsValiciones.Mensajes
        _Mensaje = _Cl_Tarja.Fx_Grabar_Tarja2()

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)
            Return
        End If


        Me.Enabled = False
        Dim Fm_Espera As New Frm_Form_Esperar
        Fm_Espera.Pro_Texto = "GRABANDO DATOS DE FABRICACION, POR FAVOR ESPERE"
        Fm_Espera.BarraCircular.IsRunning = True
        Fm_Espera.Show()

        Dim _FechaEmision As DateTime = Dtp_Fecha_Ingreso.Value

        'If Chk_FechaEmiFiot.Checked Then
        '    _FechaEmision = Dtp_Fiot.Value
        'Else
        '    _FechaEmision = Dtp_Fecha_Ingreso.Value
        'End If

        Dim Fm As New Frm_Formulario_Documento("GRI", csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Guia_Recepcion_Interna,
                                               False, False, False, False, False, False)

        Fm.Pro_RowEntidad = _Row_Entidad
        Fm.Sb_Crear_Documento_Interno_Con_Tabla3Potl(Me, _Tbl_Productos, _FechaEmision, "CODIGO", "Cantidad", "C_FABRIC", _Observaciones, False, False, 1)
        _Mensaje = Fm.Fx_Grabar_Documento(False)
        Fm.Dispose()

        If Not CBool(_Mensaje.Id) Then
            Fm_Espera.Close()
            Fm_Espera.Dispose()
            Fm_Espera = Nothing
            Me.Enabled = True
            Me.Refresh()
            Return
        End If

        Dim Cl_ArmaGDI As New Cl_ArmaGDIConsumo
        _Mensaje = Cl_ArmaGDI.Fx_CrearGDI(Me, _Row_Potl.Item("IDPOTL"), _Cantidad, _Row_Entidad, _FechaEmision, "")

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono, MessageBoxDefaultButton.Button1, True)
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Lotes_Enc Where NroLote = '" & Txt_NroLote.Text & "'"
        Dim _Row_Lote As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Consulta_sql = "Select top 1 IDMAEDDO,NUDO From MAEDDO Where IDMAEEDO = " & _Mensaje.Id
        Dim _Row_Maeddo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Nudo As String = _Row_Maeddo.Item("NUDO")
        Dim _Id_Lote As Integer = _Row_Lote.Item("Id_Lote")
        Dim _NroLote As String = _Row_Lote.Item("NroLote")
        Dim _NomTabla As String = "MAEDDO"
        Dim _Idmaeddo As Integer = _Row_Maeddo.Item("IDMAEDDO")

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Lotes_Det (Id_Lote,NroLote,NomTabla,IdTabla) Values " &
                       "(" & _Id_Lote & ",'" & _NroLote & "','" & _NomTabla & "'," & _Idmaeddo & ")"
        _Sql.Ej_consulta_IDU(Consulta_sql)


        _Cl_Tarja.Zw_Pdp_CPT_Tarja.Idmaeddo = _Idmaeddo
        _Cl_Tarja.Zw_Pdp_CPT_Tarja.Lote = _NroLote

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_CPT_Tarja Set " & vbCrLf &
                       "Idmaeddo = " & _Idmaeddo &
                       ",Lote = '" & _Cl_Tarja.Zw_Pdp_CPT_Tarja.Lote & "'" & vbCrLf &
                       "Where Id = " & _Cl_Tarja.Zw_Pdp_CPT_Tarja.Id &
                       vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Pdp_CPT_Tarja_Det Set " & vbCrLf &
                       "Idmaeddo = " & _Idmaeddo &
                       ",Lote = '" & _Cl_Tarja.Zw_Pdp_CPT_Tarja.Lote & "'" & vbCrLf &
                       "Where Id_CPT = " & _Cl_Tarja.Zw_Pdp_CPT_Tarja.Id

        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        Fm_Espera.Close()
        Fm_Espera.Dispose()
        Fm_Espera = Nothing

        Sb_Actualizar_Parametros_SQL(True)

        'MessageBoxEx.Show(Me, "Datos de fabricación ingresados correctamente con el Nro de GRI: " & _Nudo & vbCrLf &
        '                  "Tarja ingresada Nro: " & _Cl_Tarja.Zw_Pdp_CPT_Tarja.Nro_CPT, "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Enabled = True
        Me.Refresh()

        'Sb_Imprimir_Documento(Me, _New_Idmaeedo, False, Modalidad)

        Dim Fmt As New Frm_ImpBarras_Tarja
        Fmt.Txt_Nro_CPT.Text = _Cl_Tarja.Zw_Pdp_CPT_Tarja.Nro_CPT
        Fmt.CerrarDespuesDeImprimir = True
        Fmt.ShowDialog(Me)

        Dim _Numot = String.Empty

        If _Cl_Tarja.Zw_Pdp_CPT_Tarja.Tipo = "MAXI-SACO" Then

            _Numot = Txt_Numot.Text

            _Ult_Tipo = _Cl_Tarja.Zw_Pdp_CPT_Tarja.Tipo
            _Ult_Turno = _Cl_Tarja.Zw_Pdp_CPT_Tarja.Turno
            _Ult_Turno_Str = Txt_Turno.Text
            _Ult_Planta = _Cl_Tarja.Zw_Pdp_CPT_Tarja.Planta
            _Ult_Planta_Str = Txt_Planta.Text
            _Ult_Tolva = _Cl_Tarja.Zw_Pdp_CPT_Tarja.Tolva
            _Ult_Tolva_Str = Txt_Tolva.Text
            _Ult_Lote = _Cl_Tarja.Zw_Pdp_CPT_Tarja.Lote

        Else

            Sb_LimpiarMaxi()

        End If

        Sb_Limpiar()

        Txt_Numot.Text = _Numot

        If Not String.IsNullOrEmpty(_Numot) Then
            Txt_Numot.Focus()
        End If

        ' Falta agregar los siguientes campos
        ' MAEEDO: NUVEDO = 0,ESFADO = '',DESPACHO = 0
        ' MAEDDO: ARCHIRST = 'POTL' OPERACION,PPOPPR = 0, COSTOTRIB y COSTOIFRS = VANELI,TAMOPPPR = 0,TASADORIG = 0

    End Sub

    Private Sub Chk_FechaEmiFiot_CheckedChanged(sender As Object, e As EventArgs)

        If Chk_FechaEmiFiot.Checked Then
            Dtp_Fiot.Value = _Row_Pote.Item("FIOT")
            Dtp_Fecha_Ingreso.Value = _Row_Pote.Item("FIOT")
        Else
            If Not Fx_Tiene_Permiso(Me, "Pdc00009") Then
                Chk_FechaEmiFiot.Checked = True
            End If
        End If

        Dtp_Fiot.Enabled = Not Chk_FechaEmiFiot.Checked

    End Sub

    Private Sub Txt_Tolva_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Tolva.ButtonCustomClick

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
        _Filtrar.Campo = "CodigoTabla"
        _Filtrar.Descripcion = "NombreTabla"
        _Filtrar.Pro_Nombre_Encabezado_Informe = "PLANTA"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra,
                               "And Tabla = 'TARJA_TOLVA'",
                               False, False, True, False,, False) Then

            _Cl_Tarja.Zw_Pdp_CPT_Tarja.Tolva = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Txt_Tolva.Text = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Descripcion")

        End If

    End Sub

    Private Sub Rdb_BodegaDesdeOT_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_BodegaDesdeOT.CheckedChanged
        If Rdb_BodegaDesdeOT.Checked Then
            Sb_TraerBodegaGRI()
        End If
    End Sub
    Private Sub Rdb_BodegaDesdeModalidad_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_BodegaDesdeModalidad.CheckedChanged
        If Rdb_BodegaDesdeModalidad.Checked Then
            Sb_TraerBodegaGRI()
        End If
    End Sub
    Sub Sb_TraerBodegaGRI()

        Dim _Empresa As String = ModEmpresa
        Dim _Sucursal As String = ModSucursal
        Dim _Bodega As String = ModBodega

        If Rdb_BodegaDesdeOT.Checked Then

            If IsNothing(_Row_Potl) Then
                Lbl_BodegaGRI.Text = "BODEGA DE LA GRI: ..."
                Return
            Else
                _Empresa = _Row_Potl.Item("EMPRESA")
                _Sucursal = _Row_Potl.Item("SULIOTL")
                _Bodega = _Row_Potl.Item("BOLIOTL")
                _Cl_Tarja.Zw_Pdp_CPT_Tarja.BodegaDesde = "POTL"
            End If

        End If

        If Rdb_BodegaDesdeModalidad.Checked Then
            _Cl_Tarja.Zw_Pdp_CPT_Tarja.BodegaDesde = "MODALIDAD"
        End If

        Consulta_sql = "Select EMPRESA,KOSU,KOBO,NOKOBO" & vbCrLf &
                       "From TABBO" & vbCrLf &
                       "Where EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sucursal & "' And KOBO = '" & _Bodega & "'"
        _RowBodegaGRI = _Sql.Fx_Get_DataRow(Consulta_sql)
        If IsNothing(_RowBodegaGRI) Then
            Lbl_BodegaGRI.Text = "NO SE ENCONTRO Bodega: " & _Bodega & " en Empresa: " & _Empresa & ", Sucursal: " & _Sucursal
            _RowBodegaGRI = Nothing
        End If

        Lbl_BodegaGRI.Text = "BODEGA DE LA GRI: " & _RowBodegaGRI.Item("KOBO") & " - " & _RowBodegaGRI.Item("NOKOBO").ToString.Trim

    End Sub

    Private Sub Btn_EditFechaGRI_Click(sender As Object, e As EventArgs) Handles Btn_EditFechaGRI.Click

        If Fx_Tiene_Permiso(Me, "Pdc00012") Then
            Dtp_Fecha_Ingreso.Enabled = True
        End If

    End Sub

    Private Sub Dtp_Fiot_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_Fiot.ValueChanged
        Dtp_Fecha_Ingreso.Value = Dtp_Fiot.Value
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        Consulta_sql = "Select Top 1 * From CONFIGP Where EMPRESA = '" & ModEmpresa & "'"
        Dim _Row_Configp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Koen As String = _Row_Configp.Item("RUT").ToString.Trim
        Dim _Observaciones As String

        Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Koen & "'"
        Dim _Row_Entidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
        Dim _Cantidad As Double = Txt_Cantidad.Tag

        Dim _FechaEmision As DateTime = Dtp_Fecha_Ingreso.Value

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim Cl_ArmaGDI As New Cl_ArmaGDIConsumo
        _Mensaje = Cl_ArmaGDI.Fx_CrearGDI(Me, _Row_Potl.Item("IDPOTL"), _Cantidad, _Row_Entidad, _FechaEmision, "")
        If _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono, MessageBoxDefaultButton.Button1, True)
        End If

    End Sub
End Class
