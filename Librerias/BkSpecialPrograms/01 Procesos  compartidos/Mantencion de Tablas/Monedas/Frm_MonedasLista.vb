Public Class Frm_MonedasLista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tabmo As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Monedas, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_MonedasLista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla_Monedas.MouseDown, AddressOf Sb_Grilla_Monedas_MouseDown
        AddHandler Grilla_Monedas.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla_Monedas()

    End Sub

    Sub Sb_Actualizar_Grilla_Monedas()

        Consulta_sql = "Select *,Case TIMO When 'N' Then 'Nacional' When 'E' Then 'Externa' Else '??' End As Tipo From TABMO"
        _Tabmo = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Monedas

            .DataSource = _Tabmo

            OcultarEncabezadoGrilla(Grilla_Monedas)

            Dim _DisplayIndex = 0

            .Columns("KOMO").Visible = True
            .Columns("KOMO").HeaderText = "Moneda"
            .Columns("KOMO").Width = 60
            .Columns("KOMO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOMO").Visible = True
            .Columns("NOKOMO").HeaderText = "Nombre de la moneda"
            .Columns("NOKOMO").Width = 210
            .Columns("NOKOMO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("VAMO").Visible = True
            .Columns("VAMO").HeaderText = "Valor"
            .Columns("VAMO").ToolTipText = "Valor de la moneda"
            .Columns("VAMO").DefaultCellStyle.Format = "###,##0.##"
            .Columns("VAMO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VAMO").Width = 100
            .Columns("VAMO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEMO").Visible = True
            .Columns("FEMO").HeaderText = "Fecha"
            .Columns("FEMO").ToolTipText = "Fecha ultima actualización"
            .Columns("FEMO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FEMO").Width = 100
            .Columns("FEMO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Tipo").Visible = True
            .Columns("Tipo").HeaderText = "Tipo"
            .Columns("Tipo").Width = 50
            .Columns("Tipo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Grilla_Monedas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Monedas.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Monedas.CurrentRow
        Dim _Komo As String = _Fila.Cells("Komo").Value
        Dim _Grabar As Boolean

        Dim Fm As New Frm_MonedasFicha(_Komo)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then
            Sb_Actualizar_Grilla_Monedas()
            BuscarDatoEnGrilla(_Komo.Trim, "Komo", Grilla_Monedas)
        End If

    End Sub

    Private Sub Btn_Crear_Moneda_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Moneda.Click

        Dim _Grabar As Boolean

        Dim Fm As New Frm_MonedasFicha("")
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then
            Sb_Actualizar_Grilla_Monedas()
        End If

    End Sub

    Private Sub Sb_Grilla_Monedas_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
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

    Private Sub Btn_Mnu_EditarMoneda_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_EditarMoneda.Click
        Call Grilla_Monedas_CellDoubleClick(Nothing, Nothing)
    End Sub

End Class
