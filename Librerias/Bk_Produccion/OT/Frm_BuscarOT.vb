Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_BuscarOT

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Seleccionada As Boolean
    Public Property Idpote As Integer
    Public Property Numot As String
    Public Property FiltroExternoSql As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Pote, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_BuscarOT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla_Pote.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_ActualizarGrilla()

        AddHandler Rdb_Vigentes.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Cerradas.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Todas.CheckedChanged, AddressOf Rdb_CheckedChanged

        Me.ActiveControl = Txt_Descripcion

        Call BtnIrAlFin_Click(Nothing, Nothing)

    End Sub

    Sub Sb_ActualizarGrilla()

        Me.Cursor = Cursors.WaitCursor

        Dim _Filtro As String
        Dim _Condicion As String

        _Filtro = CADENA_A_BUSCAR(RTrim$(Txt_Descripcion.Text), "NUMOT+REFERENCIA LIKE '%")

        If Rdb_Vigentes.Checked Then _Condicion = "And ESTADO = 'V'" & vbCrLf
        If Rdb_Cerradas.Checked Then _Condicion = "And ESTADO = 'C'" & vbCrLf
        If Rdb_Todas.Checked Then _Condicion = String.Empty

        Consulta_sql = "Select *,Case ESTADO When 'V' Then 'Vigente' When 'C' Then 'Cerrada' End As ESTADO_OT From POTE" & vbCrLf &
                       "Where POTE.ESODD = ' ' And EMPRESA = '" & ModEmpresa & "' And NUMOT+REFERENCIA LIKE '%" & _Filtro & "%'" & vbCrLf &
                       _Condicion & FiltroExternoSql &
                       "ORDER BY NUMOT"

        Dim _DisplayIndex = 0

        With Grilla_Pote

            .DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

            OcultarEncabezadoGrilla(Grilla_Pote, True)

            '.Columns("Chk").Visible = True
            '.Columns("Chk").HeaderText = "Sel"
            '.Columns("Chk").ReadOnly = False
            '.Columns("Chk").Width = 30
            '.Columns("Chk").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("NUMOT").Visible = True
            .Columns("NUMOT").HeaderText = "Nro. OT"
            .Columns("NUMOT").Width = 75
            .Columns("NUMOT").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FIOT").Visible = True
            .Columns("FIOT").HeaderText = "F.Emisión"
            .Columns("FIOT").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FIOT").Width = 65
            .Columns("FIOT").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FTOT").Visible = True
            .Columns("FTOT").HeaderText = "F.Cierre"
            .Columns("FTOT").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FTOT").Width = 65
            .Columns("FTOT").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ESTADO_OT").Visible = True
            .Columns("ESTADO_OT").HeaderText = "Estado"
            .Columns("ESTADO_OT").Width = 70
            .Columns("ESTADO_OT").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("REFERENCIA").Visible = True
            .Columns("REFERENCIA").HeaderText = "Referencia"
            .Columns("REFERENCIA").Width = 400
            .Columns("REFERENCIA").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Grado_Prioridad").Visible = True
            '.Columns("Grado_Prioridad").HeaderText = "Prioridad"
            '.Columns("Grado_Prioridad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("Grado_Prioridad").Width = 60
            '.Columns("Grado_Prioridad").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("IDPOTE").Visible = True
            '.Columns("IDPOTE").HeaderText = "idpote"
            '.Columns("IDPOTE").Width = 40 + 10
            '.Columns("IDPOTE").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

        End With

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Txt_Descripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Descripcion.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_ActualizarGrilla()
        End If
    End Sub

    Private Sub Grilla_Pote_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Pote.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Pote.CurrentRow

        Idpote = _Fila.Cells("IDPOTE").Value
        Numot = _Fila.Cells("NUMOT").Value

        'Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdp_CPT_MzEnc", "Idpote = " & Idpote)

        'If CBool(_Reg) Then
        '    MessageBoxEx.Show(Me, "Esta OT no puede ser procesada por este modulo ya que es una OT de producción de Mezcla",
        '                      "Validación OT " & Numot, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Return
        'End If

        Seleccionada = True

        Me.Close()

    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Frm_BuscarOT_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Rdb_CheckedChanged(sender As Object, e As EventArgs)
        If sender.Checked Then
            Sb_ActualizarGrilla()
        End If
    End Sub

    Private Sub BtnIrAptincipio_Click(sender As Object, e As EventArgs) Handles BtnIrAptincipio.Click
        If CBool(Grilla_Pote.RowCount) Then
            Grilla_Pote.FirstDisplayedScrollingRowIndex = 0
            Grilla_Pote.CurrentCell = Grilla_Pote.Rows(0).Cells("NUMOT")
        End If
    End Sub

    Private Sub BtnIrAlFin_Click(sender As Object, e As EventArgs) Handles BtnIrAlFin.Click
        If CBool(Grilla_Pote.RowCount) Then
            Grilla_Pote.FirstDisplayedScrollingRowIndex = Grilla_Pote.RowCount - 1
            Grilla_Pote.CurrentCell = Grilla_Pote.Rows(Grilla_Pote.RowCount - 1).Cells("NUMOT")
        End If
    End Sub
End Class
