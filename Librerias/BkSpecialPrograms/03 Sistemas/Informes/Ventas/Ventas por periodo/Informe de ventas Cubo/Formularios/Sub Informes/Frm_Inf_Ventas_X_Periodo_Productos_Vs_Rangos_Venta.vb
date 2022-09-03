Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Inf_Ventas_X_Periodo_Productos_Vs_Rangos_Venta

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Informe As DataTable
    Dim _Row_Entidad As DataRow

    Public Property Pro_RowEntidad() As DataRow
        Get
            Return _Row_Entidad
        End Get
        Set(value As DataRow)
            _Row_Entidad = value

            If Not (_Row_Entidad Is Nothing) Then
                Me.Text = "DETALLE DE PRODUCTOS VENDIDOS, CLIENTE: " & _Row_Entidad.Item("NOKOEN")
            End If

        End Set
    End Property

    Public Sub New(Tbl_Informe As DataTable)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Tbl_Informe = Tbl_Informe
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 7), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Inf_Ventas_X_Periodo_Clientes_Vs_Rangos_Venta_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_Detalle_MouseDown
        AddHandler Grilla.ColumnHeaderMouseClick, AddressOf Sb_Grilla_ColumnHeaderMouseClick

    End Sub

    Sub Sb_Actualizar_Grilla()

        With Grilla

            .DataSource = _Tbl_Informe

            OcultarEncabezadoGrilla(Grilla, False)

            .Columns("CODIGO").HeaderText = "Código"
            .Columns("CODIGO").Width = 100
            .Columns("CODIGO").Visible = True

            '.Columns("_SUENDO").HeaderText = "Suc."
            '.Columns("_SUENDO").Width = 50
            '.Columns("_SUENDO").Visible = True

            .Columns("DESCRIPCION").HeaderText = "  Descripción"
            .Columns("DESCRIPCION").Width = 270
            .Columns("DESCRIPCION").Visible = True

            .Columns("Rango_1").HeaderText = "Ventas R1"
            .Columns("Rango_1").Width = 80
            .Columns("Rango_1").Visible = True
            .Columns("Rango_1").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Rango_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("Rango_2").HeaderText = "Ventas R2"
            .Columns("Rango_2").Width = 80
            .Columns("Rango_2").Visible = True
            .Columns("Rango_2").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Rango_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("Cant_Expectativa").HeaderText = "Qty. Expectativa"
            .Columns("Cant_Expectativa").Width = 80
            .Columns("Cant_Expectativa").Visible = True
            .Columns("Cant_Expectativa").DefaultCellStyle.Format = "###,##"
            .Columns("Cant_Expectativa").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("Cant_Realidad").HeaderText = "Qty. Realidad"
            .Columns("Cant_Realidad").Width = 80
            .Columns("Cant_Realidad").Visible = True
            .Columns("Cant_Realidad").DefaultCellStyle.Format = "###,##"
            .Columns("Cant_Realidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("Expectativa").HeaderText = "Expectativa"
            .Columns("Expectativa").Width = 70
            .Columns("Expectativa").Visible = True
            .Columns("Expectativa").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Expectativa").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("Realidad").HeaderText = "Realidad"
            .Columns("Realidad").Width = 70
            .Columns("Realidad").Visible = True
            .Columns("Realidad").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Realidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("Diferencia").HeaderText = "Dif. $"
            .Columns("Diferencia").Width = 60
            .Columns("Diferencia").Visible = True
            .Columns("Diferencia").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Diferencia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            '.Columns("Porc_diferencia").HeaderText = "Dif. %"
            '.Columns("Porc_diferencia").Width = 80
            '.Columns("Porc_diferencia").Visible = True
            '.Columns("Porc_diferencia").DefaultCellStyle.Format = "% #,##.###"
            '.Columns("Porc_diferencia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("StockUd1").HeaderText = "Stock Físico"
            .Columns("StockUd1").Width = 60
            .Columns("StockUd1").Visible = True
            .Columns("StockUd1").DefaultCellStyle.Format = "###,##"
            .Columns("StockUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("StockComprUd1").HeaderText = "Stock Comprom."
            .Columns("StockComprUd1").Width = 65
            .Columns("StockComprUd1").Visible = True
            .Columns("StockComprUd1").DefaultCellStyle.Format = "###,##"
            .Columns("StockComprUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("StockTeoriUd1").HeaderText = "Stock Teórico"
            .Columns("StockTeoriUd1").Width = 60
            .Columns("StockTeoriUd1").Visible = True
            .Columns("StockTeoriUd1").DefaultCellStyle.Format = "###,##"
            .Columns("StockTeoriUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        End With

        Sb_Marcar_Grilla()

    End Sub

    Sub Sb_Marcar_Grilla()

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Expectativa = _Fila.Cells("Expectativa").Value
            Dim _Realidad = _Fila.Cells("Realidad").Value
            Dim _StockTeoriUd1 = NuloPorNro(_Fila.Cells("StockTeoriUd1").Value, 0)

            If _Expectativa > _Realidad Then
                '_Fila.Cells("CODIGO").Style.ForeColor = Color.Red
                _Fila.Cells("DESCRIPCION").Style.ForeColor = Color.Red
                _Fila.Cells("Realidad").Style.ForeColor = Color.Red
                _Fila.DefaultCellStyle.BackColor = Color.PaleGoldenrod 'Khaki
            Else
                '_Fila.Cells("CODIGO").Style.ForeColor = Color.Red
                _Fila.Cells("DESCRIPCION").Style.ForeColor = Color.Black
                _Fila.Cells("Realidad").Style.ForeColor = Color.Green
            End If

            If _StockTeoriUd1 <= 0 Then
                _Fila.Cells("StockTeoriUd1").Style.ForeColor = Color.Red
            Else
                _Fila.Cells("StockTeoriUd1").Style.ForeColor = Color.Green
            End If

        Next

    End Sub

    Private Sub Sb_Grilla_ColumnHeaderMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        Sb_Marcar_Grilla()
    End Sub

    Private Sub Frm_Inf_Ventas_X_Periodo_Productos_Vs_Rangos_Venta_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Excel_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Excel.Click
        If Fx_Tiene_Permiso(Me, "Inf00040") Then
            ExportarTabla_JetExcel_Tabla(_Tbl_Informe, Me, "Productos")
        End If
    End Sub

    Private Sub Btn_Mnu_Estadisticas_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Estadisticas_Producto.Click
        Dim Fm_Producto As New Frm_BkpPostBusquedaEspecial_Mt

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Codigo As String = _Fila.Cells("CODIGO").Value

        Dim _Endo As String

        If Not (_Row_Entidad Is Nothing) Then
            _Endo = _Row_Entidad.Item("KOEN")
            Fm_Producto.Sb_Ver_Informacion_Adicional_producto(Me, _Codigo,
                                                             _Endo, Frm_BkpPostBusquedaEspecial_Mt.Tipo_Doc.Venta)
        Else
            Fm_Producto.Sb_Ver_Informacion_Adicional_producto(Me, _Codigo)
        End If

    End Sub

    Private Sub Sb_Grilla_Detalle_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    'ShowContextMenu(Menu_Contextual_Informe)
                    ShowContextMenu(Menu_Contextual)
                End If
            End With
        End If
    End Sub

    Private Sub Chk_Mostrar_Solo_Vendidos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Chk_Mostrar_Solo_Vendidos.CheckedChanged
        Sb_Actualizar_Grilla()
    End Sub

End Class
