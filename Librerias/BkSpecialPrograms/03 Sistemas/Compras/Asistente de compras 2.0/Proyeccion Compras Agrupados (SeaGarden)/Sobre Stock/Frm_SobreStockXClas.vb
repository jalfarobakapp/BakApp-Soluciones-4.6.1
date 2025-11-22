Public Class Frm_SobreStockXClas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Cl_SobreStockXClas As New Cl_SobreStockXClas

    Dim _Tbl_Asc_01_Productos As String = "Tbl_Asc_01_Productos_" & FUNCIONARIO
    Dim _Tbl_Asc_02_Asociaciones As String = "Tbl_Asc_02_Asociaciones_" & FUNCIONARIO

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_SobreStockXClas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _Cl_SobreStockXClas.Fx_CrearTablaPaso_TablaPasoRotacion()
        _Cl_SobreStockXClas.Fx_InsertarDetalleEn_TablaPasoRotacion(_Tbl_Asc_02_Asociaciones)

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select * From " & _Cl_SobreStockXClas.TablaPasoRotacion
        Dim _Tbl_Clasificaciones As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla_Clasificaciones

            .DataSource = _Tbl_Clasificaciones

            OcultarEncabezadoGrilla(Grilla_Clasificaciones, True)

            Dim _DisplayIndex = 0

            '.Columns("BtnImagen_Estado").Width = 30
            '.Columns("BtnImagen_Estado").HeaderText = "Est."
            '.Columns("BtnImagen_Estado").Visible = _MostrarImagenes
            '.Columns("BtnImagen_Estado").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Chk").Visible = True
            '.Columns("Chk").HeaderText = "Sel."
            '.Columns("Chk").ToolTipText = "Selección"
            '.Columns("Chk").Width = 30
            '.Columns("Chk").ReadOnly = False
            '.Columns("Chk").Visible = True
            '.Columns("Chk").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Codigo_Nodo_Madre").Visible = True
            .Columns("Codigo_Nodo_Madre").HeaderText = "Codigo_Nodo_Madre"
            '.Columns("Codigo_Nodo_Madre").ToolTipText = "Vendedor"
            .Columns("Codigo_Nodo_Madre").Width = 30
            .Columns("Codigo_Nodo_Madre").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Producto").Visible = True
            .Columns("Producto").HeaderText = "Producto"
            '.Columns("Codigo_Nodo_Madre").ToolTipText = "Vendedor"
            .Columns("Producto").Width = 30
            .Columns("Producto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StockUd1").Width = 90
            .Columns("StockUd1").HeaderText = "Stock Físico"
            .Columns("StockUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StockUd1").DefaultCellStyle.Format = "###,##0.##"
            .Columns("StockUd1").Visible = True
            .Columns("StockUd1").DisplayIndex = _DisplayIndex

            .Columns("StockEnTransitoUd1").Width = 90
            .Columns("StockEnTransitoUd1").HeaderText = "Stock Transito"
            .Columns("StockEnTransitoUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StockEnTransitoUd1").DefaultCellStyle.Format = "###,##0.##"
            .Columns("StockEnTransitoUd1").Visible = True
            .Columns("StockEnTransitoUd1").DisplayIndex = _DisplayIndex

            .Columns("StockPedidoUd1").Width = 90
            .Columns("StockPedidoUd1").HeaderText = "Stock Pedido"
            .Columns("StockPedidoUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StockPedidoUd1").DefaultCellStyle.Format = "###,##0.##"
            .Columns("StockPedidoUd1").Visible = True
            .Columns("StockPedidoUd1").DisplayIndex = _DisplayIndex

            .Columns("RotM1").Width = 90
            .Columns("RotM1").HeaderText = "Rot1"
            .Columns("RotM1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RotM1").DefaultCellStyle.Format = "###,##0.##"
            .Columns("RotM1").Visible = True
            .Columns("RotM1").DisplayIndex = _DisplayIndex

            .Columns("RotM2").Width = 90
            .Columns("RotM2").HeaderText = "Rot2"
            .Columns("RotM2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RotM2").DefaultCellStyle.Format = "###,##0.##"
            .Columns("RotM2").Visible = True
            .Columns("RotM2").DisplayIndex = _DisplayIndex

            .Columns("RotM3").Width = 90
            .Columns("RotM3").HeaderText = "Rot3"
            .Columns("RotM3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RotM3").DefaultCellStyle.Format = "###,##0.##"
            .Columns("RotM3").Visible = True
            .Columns("RotM3").DisplayIndex = _DisplayIndex

            .Columns("RotM4").Width = 90
            .Columns("RotM4").HeaderText = "Rot4"
            .Columns("RotM4").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RotM4").DefaultCellStyle.Format = "###,##0.##"
            .Columns("RotM4").Visible = True
            .Columns("RotM4").DisplayIndex = _DisplayIndex

            .Columns("RotCalculo").Visible = True
            .Columns("RotCalculo").HeaderText = "Rot.Calculo"
            '.Columns("Codigo_Nodo_Madre").ToolTipText = "Vendedor"
            .Columns("RotCalculo").Width = 30
            .Columns("RotCalculo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Rotacion").Width = 90
            .Columns("Rotacion").HeaderText = "Rot4"
            .Columns("Rotacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Rotacion").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Rotacion").Visible = True
            .Columns("Rotacion").DisplayIndex = _DisplayIndex

            .Columns("StockDisponible").Width = 90
            .Columns("StockDisponible").HeaderText = "Stock Disponible"
            .Columns("StockDisponible").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StockDisponible").DefaultCellStyle.Format = "###,##0.##"
            .Columns("StockDisponible").Visible = True
            .Columns("StockDisponible").DisplayIndex = _DisplayIndex

            .Columns("Duracion_Stock_Meses").Width = 90
            .Columns("Duracion_Stock_Meses").HeaderText = "Duración Meses"
            .Columns("Duracion_Stock_Meses").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Duracion_Stock_Meses").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Duracion_Stock_Meses").Visible = True
            .Columns("Duracion_Stock_Meses").DisplayIndex = _DisplayIndex

            .Columns("Syncro").Width = 90
            .Columns("Syncro").HeaderText = "Syncro"
            .Columns("Syncro").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Syncro").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Syncro").Visible = True
            .Columns("Syncro").DisplayIndex = _DisplayIndex

            .Columns("KilosXPallet").Width = 90
            .Columns("KilosXPallet").HeaderText = "Kg X Pallet"
            .Columns("KilosXPallet").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("KilosXPallet").DefaultCellStyle.Format = "###,##0.##"
            .Columns("KilosXPallet").Visible = True
            .Columns("KilosXPallet").DisplayIndex = _DisplayIndex

            .Columns("PalletSY").Width = 90
            .Columns("PalletSY").HeaderText = "Pallet SY"
            .Columns("PalletSY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PalletSY").DefaultCellStyle.Format = "###,##0.##"
            .Columns("KilosXPallet").Visible = True
            .Columns("PalletSY").DisplayIndex = _DisplayIndex

            .Columns("SobreStock").Visible = True
            .Columns("SobreStock").HeaderText = "Sobre Stock"
            '.Columns("Codigo_Nodo_Madre").ToolTipText = "Vendedor"
            .Columns("SobreStock").Width = 30
            .Columns("SobreStock").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Frm_SobreStockXClas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        _Cl_SobreStockXClas.Sb_Eliminar_TablaPasoRotacion()
    End Sub

End Class
