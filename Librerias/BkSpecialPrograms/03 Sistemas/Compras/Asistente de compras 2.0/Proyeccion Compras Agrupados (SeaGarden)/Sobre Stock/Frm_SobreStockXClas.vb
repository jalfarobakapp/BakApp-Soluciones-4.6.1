Imports System.Drawing
Imports System.Windows.Forms
Imports BkSpecialPrograms.Cl_Fincred_Bakapp.Cl_Fincred_SQL
Imports BkSpecialPrograms.LsValiciones
Imports DevComponents.DotNetBar

Public Class Frm_SobreStockXClas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Cl_SobreStockXClas As New Cl_SobreStockXClas

    Dim _Tbl_Asc_01_Productos As String = "Tbl_Asc_01_Productos_" & FUNCIONARIO
    Dim _Tbl_Asc_02_Asociaciones As String = "Tbl_Asc_02_Asociaciones_" & FUNCIONARIO

    Dim _Codigo_Nodo_Madre As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Clasificaciones, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Productos, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_SobreStockXClas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "SOBRE STOCK"
        Chk_SumarStockDisponible.Checked = True
        Chk_MostrarSoloProdConStockEnDetalle.Checked = True

        Sb_Actualizar_Grilla()

        AddHandler Grilla_Clasificaciones.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Productos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        AddHandler Grilla_Clasificaciones.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla_Productos.MouseDown, AddressOf Sb_Grilla_MouseDown

    End Sub

    Sub Sb_Actualizar_Grilla()

        With _Cl_SobreStockXClas

            .Fx_CrearTablaPaso_TablaPasoRotacionXClasificaciones()
            .Fx_CrearTablaPaso_TablaPasoRotacionXProductos()
            .Fx_InsertarDetalleEn_TablaPasoRotacionXClasificaciones(_Tbl_Asc_02_Asociaciones, Chk_SumarStockDisponible.Checked)
            .Fx_InsertarDetalleEn_TablaPasoRotacionXProductos(_Tbl_Asc_01_Productos, Chk_SumarStockDisponible.Checked)

        End With

        Consulta_sql = "Select * From " & _Cl_SobreStockXClas.TablaPasoRotacion_Clasificacion
        Dim _Tbl_Clasificaciones As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla_Clasificaciones

            .DataSource = _Tbl_Clasificaciones

            OcultarEncabezadoGrilla(Grilla_Clasificaciones, True)

            Dim _DisplayIndex = 0

            Dim _AnchoClValores = 60

            .Columns("Codigo_Nodo_Madre").Visible = True
            .Columns("Codigo_Nodo_Madre").HeaderText = "Codigo_Nodo_Madre"
            .Columns("Codigo_Nodo_Madre").Width = 80
            .Columns("Codigo_Nodo_Madre").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Producto").Visible = True
            .Columns("Producto").HeaderText = "Producto"
            .Columns("Producto").Width = 190
            .Columns("Producto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StockUd1").Width = _AnchoClValores
            .Columns("StockUd1").HeaderText = "Stock Físico"
            .Columns("StockUd1").ToolTipText = "Stock Físico en Bodegas"
            .Columns("StockUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StockUd1").DefaultCellStyle.Format = "###,##0.##"
            .Columns("StockUd1").Visible = True
            .Columns("StockUd1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StockEnTransitoUd1").Width = _AnchoClValores
            .Columns("StockEnTransitoUd1").HeaderText = "Stock Transito"
            .Columns("StockEnTransitoUd1").ToolTipText = "Stock Transito hacia bodegas"
            .Columns("StockEnTransitoUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StockEnTransitoUd1").DefaultCellStyle.Format = "###,##0.##"
            .Columns("StockEnTransitoUd1").Visible = True
            .Columns("StockEnTransitoUd1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StockPedidoUd1").Width = _AnchoClValores
            .Columns("StockPedidoUd1").HeaderText = "Stock Pedido"
            .Columns("StockFacSinRecepUd1").ToolTipText = "Stock Pedido Ordenes De Compra por llegar"
            .Columns("StockPedidoUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StockPedidoUd1").DefaultCellStyle.Format = "###,##0.##"
            .Columns("StockPedidoUd1").Visible = True
            .Columns("StockPedidoUd1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StockFacSinRecepUd1").Width = _AnchoClValores
            .Columns("StockFacSinRecepUd1").HeaderText = "Stock FacS/R"
            .Columns("StockFacSinRecepUd1").ToolTipText = "Stock Facturado Sin Recepcionar"
            .Columns("StockFacSinRecepUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StockFacSinRecepUd1").DefaultCellStyle.Format = "###,##0.##"
            .Columns("StockFacSinRecepUd1").Visible = True
            .Columns("StockFacSinRecepUd1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("RotM1").Width = _AnchoClValores
            .Columns("RotM1").HeaderText = "Rot1"
            .Columns("RotM1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RotM1").DefaultCellStyle.Format = "###,##0.##"
            .Columns("RotM1").Visible = True
            .Columns("RotM1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("RotM2").Width = _AnchoClValores
            .Columns("RotM2").HeaderText = "Rot2"
            .Columns("RotM2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RotM2").DefaultCellStyle.Format = "###,##0.##"
            .Columns("RotM2").Visible = True
            .Columns("RotM2").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("RotM3").Width = _AnchoClValores
            .Columns("RotM3").HeaderText = "Rot3"
            .Columns("RotM3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RotM3").DefaultCellStyle.Format = "###,##0.##"
            .Columns("RotM3").Visible = True
            .Columns("RotM3").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("RotM4").Width = _AnchoClValores
            .Columns("RotM4").HeaderText = "Rot4"
            .Columns("RotM4").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RotM4").DefaultCellStyle.Format = "###,##0.##"
            .Columns("RotM4").Visible = True
            .Columns("RotM4").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("RotCalculo").Width = _AnchoClValores
            .Columns("RotCalculo").Visible = True
            .Columns("RotCalculo").HeaderText = "Rotación Calculo"
            .Columns("RotCalculo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Rotacion").Width = _AnchoClValores
            .Columns("Rotacion").HeaderText = "Rotación"
            .Columns("Rotacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Rotacion").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Rotacion").Visible = True
            .Columns("Rotacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StockDisponible").Width = _AnchoClValores
            .Columns("StockDisponible").HeaderText = "Stock Disponible"
            .Columns("StockDisponible").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StockDisponible").DefaultCellStyle.Format = "###,##0.##"
            .Columns("StockDisponible").Visible = True
            .Columns("StockDisponible").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Duracion_Stock_Meses").Width = 40
            .Columns("Duracion_Stock_Meses").HeaderText = "Duración Meses"
            .Columns("Duracion_Stock_Meses").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Duracion_Stock_Meses").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Duracion_Stock_Meses").Visible = True
            .Columns("Duracion_Stock_Meses").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("MesesSobreStock").Width = _AnchoClValores - 30
            .Columns("MesesSobreStock").HeaderText = "M/S"
            .Columns("MesesSobreStock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("MesesSobreStock").DefaultCellStyle.Format = "###,##0.##"
            .Columns("MesesSobreStock").Visible = True
            .Columns("MesesSobreStock").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Syncro").Width = _AnchoClValores
            .Columns("Syncro").HeaderText = "Syncro"
            .Columns("Syncro").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Syncro").DefaultCellStyle.Format = "###,##0"
            .Columns("Syncro").Visible = True
            .Columns("Syncro").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("KilosXPallet").Width = _AnchoClValores - 20
            .Columns("KilosXPallet").HeaderText = "Kg X Pallet"
            .Columns("KilosXPallet").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("KilosXPallet").DefaultCellStyle.Format = "###,##0.##"
            .Columns("KilosXPallet").Visible = True
            .Columns("KilosXPallet").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PalletSY").Width = 40
            .Columns("PalletSY").HeaderText = "Pallet SY"
            .Columns("PalletSY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PalletSY").DefaultCellStyle.Format = "###,##0.##"
            .Columns("PalletSY").Visible = True
            .Columns("PalletSY").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SobreStock").Width = 40
            .Columns("SobreStock").Visible = True
            .Columns("SobreStock").HeaderText = "S/S"
            .Columns("SobreStock").ToolTipText = "Sobre Stock"
            .Columns("SobreStock").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        ' Aplicar coloreo según la columna SobreStock
        Sb_ColorearFilasSobreStock(Grilla_Clasificaciones)

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Frm_SobreStockXClas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        _Cl_SobreStockXClas.Sb_Eliminar_TablasDePasoRotacion()
    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Grilla_Clasificaciones_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Clasificaciones.CellEnter

        Dim _Fila As DataGridViewRow = Grilla_Clasificaciones.CurrentRow

        If IsNothing(_Fila) Then
            Return
        End If

        Dim _Codigo_Nodo As Integer = _Fila.Cells("Codigo_Nodo").Value
        Dim _Codigo_Nodo_Madre2 = _Fila.Cells("Codigo_Nodo_Madre").Value

        Dim _Condicion As String = String.Empty

        If Chk_MostrarSoloProdConStockEnDetalle.Checked Then
            _Condicion = vbCrLf & "And (StockUd1+StockEnTransitoUd1+StockPedidoUd1+StockFacSinRecepUd1) <> 0"
        End If

        Consulta_sql = "Select * From " & _Cl_SobreStockXClas.TablaPasoRotacion_Productos & vbCrLf &
                       "Where Codigo_Nodo_Madre = '" & _Codigo_Nodo_Madre2 & "' And Codigo_Nodo = " & _Codigo_Nodo & _Condicion
        Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla_Productos

            .DataSource = _Tbl_Productos

            OcultarEncabezadoGrilla(Grilla_Productos, True)

            Dim _DisplayIndex = 0

            Dim _AnchoClValores = 60

            .Columns("Codigo").Width = 90
            .Columns("Codigo").Visible = True
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Width = 180
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StockUd1").Width = _AnchoClValores
            .Columns("StockUd1").HeaderText = "Stock Físico"
            .Columns("StockUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StockUd1").DefaultCellStyle.Format = "###,##0.##"
            .Columns("StockUd1").Visible = True
            .Columns("StockUd1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StockEnTransitoUd1").Width = _AnchoClValores
            .Columns("StockEnTransitoUd1").HeaderText = "Stock Transito"
            .Columns("StockEnTransitoUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StockEnTransitoUd1").DefaultCellStyle.Format = "###,##0.##"
            .Columns("StockEnTransitoUd1").Visible = True
            .Columns("StockEnTransitoUd1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StockPedidoUd1").Width = _AnchoClValores
            .Columns("StockPedidoUd1").HeaderText = "Stock Pedido"
            .Columns("StockPedidoUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StockPedidoUd1").DefaultCellStyle.Format = "###,##0.##"
            .Columns("StockPedidoUd1").Visible = True
            .Columns("StockPedidoUd1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StockFacSinRecepUd1").Width = _AnchoClValores
            .Columns("StockFacSinRecepUd1").HeaderText = "Stock FacS/R"
            '.Columns("StockFacSinRecepUd1").ToolTipText = "Stock Facturado Sin Recepcionar"
            .Columns("StockFacSinRecepUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StockFacSinRecepUd1").DefaultCellStyle.Format = "###,##0.##"
            .Columns("StockFacSinRecepUd1").Visible = True
            .Columns("StockFacSinRecepUd1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("RotM1").Width = _AnchoClValores
            .Columns("RotM1").HeaderText = "Rot1"
            .Columns("RotM1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RotM1").DefaultCellStyle.Format = "###,##0.##"
            .Columns("RotM1").Visible = True
            .Columns("RotM1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("RotM2").Width = _AnchoClValores
            .Columns("RotM2").HeaderText = "Rot2"
            .Columns("RotM2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RotM2").DefaultCellStyle.Format = "###,##0.##"
            .Columns("RotM2").Visible = True
            .Columns("RotM2").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("RotM3").Width = _AnchoClValores
            .Columns("RotM3").HeaderText = "Rot3"
            .Columns("RotM3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RotM3").DefaultCellStyle.Format = "###,##0.##"
            .Columns("RotM3").Visible = True
            .Columns("RotM3").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("RotM4").Width = _AnchoClValores
            .Columns("RotM4").HeaderText = "Rot4"
            .Columns("RotM4").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RotM4").DefaultCellStyle.Format = "###,##0.##"
            .Columns("RotM4").Visible = True
            .Columns("RotM4").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("RotCalculo").Width = _AnchoClValores - 10
            .Columns("RotCalculo").Visible = True
            .Columns("RotCalculo").HeaderText = "Rot. Calculo"
            .Columns("RotCalculo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Rotacion").Width = _AnchoClValores
            .Columns("Rotacion").HeaderText = "Rotación"
            .Columns("Rotacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Rotacion").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Rotacion").Visible = True
            .Columns("Rotacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StockDisponible").Width = _AnchoClValores + 10
            .Columns("StockDisponible").HeaderText = "Stock Disponible"
            .Columns("StockDisponible").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StockDisponible").DefaultCellStyle.Format = "###,##0.##"
            .Columns("StockDisponible").Visible = True
            .Columns("StockDisponible").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Duracion_Stock_Meses").Width = 40
            .Columns("Duracion_Stock_Meses").HeaderText = "Duración Meses"
            .Columns("Duracion_Stock_Meses").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Duracion_Stock_Meses").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Duracion_Stock_Meses").Visible = True
            .Columns("Duracion_Stock_Meses").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("MesesSobreStock").Width = _AnchoClValores - 30
            .Columns("MesesSobreStock").HeaderText = "M/S"
            .Columns("MesesSobreStock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("MesesSobreStock").DefaultCellStyle.Format = "###,##0.##"
            .Columns("MesesSobreStock").Visible = True
            .Columns("MesesSobreStock").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Syncro").Width = _AnchoClValores
            .Columns("Syncro").HeaderText = "Syncro"
            .Columns("Syncro").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Syncro").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Syncro").Visible = True
            .Columns("Syncro").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("KilosXPallet").Width = _AnchoClValores - 20
            .Columns("KilosXPallet").HeaderText = "Kg X Pallet"
            .Columns("KilosXPallet").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("KilosXPallet").DefaultCellStyle.Format = "###,##0.##"
            .Columns("KilosXPallet").Visible = True
            .Columns("KilosXPallet").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PalletSY").Width = 40
            .Columns("PalletSY").HeaderText = "Pallet SY"
            .Columns("PalletSY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PalletSY").DefaultCellStyle.Format = "###,##0.##"
            .Columns("PalletSY").Visible = True
            .Columns("PalletSY").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SobreStock").Width = 40
            .Columns("SobreStock").Visible = True
            .Columns("SobreStock").HeaderText = "Sobre Stock"
            .Columns("SobreStock").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        ' Aplicar coloreo según la columna SobreStock en la grilla de productos
        Sb_ColorearFilasSobreStock(Grilla_Productos)

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Grilla_Clasificaciones_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Clasificaciones.CellDoubleClick

        Dim Fm_Espera As New Frm_Form_Esperar
        Fm_Espera.BarraCircular.IsRunning = True
        Fm_Espera.Show()

        Try

            Me.Enabled = False

            Dim _Fila As DataGridViewRow = Grilla_Clasificaciones.CurrentRow
            Dim _Codigo_Nodo As Integer = _Fila.Cells("Codigo_Nodo").Value
            Dim _Producto As String = _Fila.Cells("Producto").Value
            Dim _StockUd1 As Double = _Fila.Cells("StockUd1").Value
            _Codigo_Nodo_Madre = _Fila.Cells("Codigo_Nodo_Madre").Value

            Dim _Mensaje As LsValiciones.Mensajes

            _Mensaje = _Cl_SobreStockXClas.Fx_InsertarDetalleEn_TablaCalendarioMesesSemanasClasificaciones_VB(_Codigo_Nodo_Madre)

            Fm_Espera.Close()
            Fm_Espera = Nothing

            If Not _Mensaje.EsCorrecto Then
                MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Dim Fm As New Frm_SobreStock_Grafico("", _Codigo_Nodo_Madre)
            Fm.Text = "CLASIFICACION: " & _Codigo_Nodo_Madre.ToString.Trim & " - " & _Producto
            Fm.StockInicial = _StockUd1
            Fm.ShowDialog(Me)
            Fm.Dispose()

        Catch ex As Exception
        Finally
            If Not IsNothing(Fm_Espera) Then
                Fm_Espera.Close()
                Fm_Espera = Nothing
            End If
            Me.Enabled = True
        End Try

    End Sub

    Private Sub Grilla_Productos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Productos.CellDoubleClick

        Dim Fm_Espera As New Frm_Form_Esperar
        Fm_Espera.BarraCircular.IsRunning = True
        Fm_Espera.Show()

        Try

            Dim _Fila As DataGridViewRow = Grilla_Productos.CurrentRow
            Dim _Codigo As String = _Fila.Cells("Codigo").Value
            Dim _Codigo_Nodo_Madre2 As String = _Fila.Cells("Codigo_Nodo_Madre").Value
            Dim _Descripcion As String = _Fila.Cells("Descripcion").Value
            Dim _StockUd1 As Double = _Fila.Cells("StockUd1").Value

            Dim _Mensaje As LsValiciones.Mensajes
            _Mensaje = _Cl_SobreStockXClas.Fx_InsertarDetalleEn_TablaCalendarioMesesSemanasProductos_VB(_Codigo_Nodo_Madre2, _Codigo)

            Fm_Espera.Close()
            Fm_Espera = Nothing

            If Not _Mensaje.EsCorrecto Then
                MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Dim Fm As New Frm_SobreStock_Grafico(_Codigo, "")
            Fm.Text = "PRODUCTO: " & _Codigo & " - " & _Descripcion.ToString.Trim
            Fm.StockInicial = _StockUd1
            Fm.ShowDialog(Me)
            Fm.Dispose()

        Catch ex As Exception
        Finally
            If Not IsNothing(Fm_Espera) Then
                Fm_Espera.Close()
                Fm_Espera = Nothing
            End If
            Me.Enabled = True
        End Try

    End Sub

    ' Método para colorear filas cuando SobreStock = "Si"
    Private Sub Sb_ColorearFilasSobreStock(ByVal Grilla As DataGridView)

        Try
            If IsNothing(Grilla) Then
                Return
            End If

            ' Evitar excepciones si la columna no existe
            If Not Grilla.Columns.Contains("SobreStock") Then
                Return
            End If

            For Each row As DataGridViewRow In Grilla.Rows
                If row.IsNewRow Then
                    Continue For
                End If

                Dim cellValue As String = String.Empty

                Try
                    cellValue = If(row.Cells("SobreStock").Value, String.Empty).ToString()
                Catch ex As Exception
                    cellValue = String.Empty
                End Try

                If cellValue.Trim().ToUpper() = "SI" Then
                    ' Colores para filas con sobre stock
                    row.DefaultCellStyle.BackColor = Color.LightGreen
                    row.DefaultCellStyle.ForeColor = Color.Black
                Else
                    ' Restaurar colores por defecto
                    row.DefaultCellStyle.BackColor = Color.White
                    row.DefaultCellStyle.ForeColor = Color.Black
                End If
            Next
        Catch ex As Exception
            ' No propagamos la excepción para no interrumpir la UI
        End Try

    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Excel.Click

        Consulta_sql = "Select * From " & _Cl_SobreStockXClas.TablaPasoRotacion_Clasificacion & vbCrLf &
                       "Select * From " & _Cl_SobreStockXClas.TablaPasoRotacion_Productos
        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        ExportarTabla_JetExcel_DataSet(_Ds, Me, "Sobre Stock")

    End Sub

    Private Sub Btn_MostrarGraficoXClasificacion_Click(sender As Object, e As EventArgs) Handles Btn_MostrarGraficoXClasificacion.Click
        Call Grilla_Clasificaciones_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Btn_VerDocPdtesXClasificacion_Click(sender As Object, e As EventArgs) Handles Btn_VerDocPdtesXClasificacion.Click

        Dim _Fila As DataGridViewRow = Grilla_Clasificaciones.CurrentRow
        Dim _Codigo_Nodo_Madre = _Fila.Cells("Codigo_Nodo_Madre").Value
        Dim _Producto = _Fila.Cells("Producto").Value

        Dim _Condicion As String = String.Empty

        If Not String.IsNullOrEmpty(_Codigo_Nodo_Madre) Then
            _Condicion = "Codigo_Nodo_Madre = '" & _Codigo_Nodo_Madre & "'"
        End If

        Dim _Reg = _Sql.Fx_Cuenta_Registros($"Tbl_Asc_04_DocUltComp_{FUNCIONARIO}", _Condicion)

        If Not CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No hay documentos pendientes de compra para mostrar",
                              "Ver documentos pendientes de compra", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_SobreStock_Llegadas(_Codigo_Nodo_Madre, "")
        Fm.Text = "CLASIFICACION: " & _Codigo_Nodo_Madre.ToString.Trim & " - " & _Producto
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_CopiarXClasificacion_Click(sender As Object, e As EventArgs) Handles Btn_CopiarXClasificacion.Click

        ' Reutiliza el método genérico que copia la celda activa al portapapeles.
        ' Si se quiere forzar copiar desde la grilla de clasificaciones pasarla como parámetro.
        Fx_CopiarCeldaActivaAlPortapapeles(Grilla_Clasificaciones)

    End Sub

    ' Ejemplo de handler para un posible botón "Copiar" de productos.
    ' Si ya existe en el diseñador, reemplace o añada el Handles correspondiente.
    Private Sub Btn_CopiarXProducto_Click(sender As Object, e As EventArgs) Handles Btn_CopiarXProducto.Click

        ' Reutiliza el mismo método y fuerza la grilla de productos.
        Fx_CopiarCeldaActivaAlPortapapeles(Grilla_Productos)

    End Sub

    ' Método reutilizable que copia el valor de la celda actual de la grilla indicada (o de la grilla con foco)
    ' al portapapeles. Devuelve True si la operación fue exitosa.
    Private Function Fx_CopiarCeldaActivaAlPortapapeles(Optional ByVal dgv As DataGridView = Nothing) As Boolean

        Try
            ' Determinar la grilla si no se especificó
            If dgv Is Nothing Then
                If Grilla_Productos.ContainsFocus Then
                    dgv = Grilla_Productos
                ElseIf Grilla_Clasificaciones.ContainsFocus Then
                    dgv = Grilla_Clasificaciones
                ElseIf Grilla_Clasificaciones.CurrentCell IsNot Nothing Then
                    dgv = Grilla_Clasificaciones
                ElseIf Grilla_Productos.CurrentCell IsNot Nothing Then
                    dgv = Grilla_Productos
                End If
            End If

            If dgv Is Nothing Then
                MessageBoxEx.Show(Me, "No hay ninguna celda activa en las grillas para copiar.", "Copiar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

            Dim celda As DataGridViewCell = dgv.CurrentCell

            If celda Is Nothing Then
                MessageBoxEx.Show(Me, "No hay ninguna celda seleccionada.", "Copiar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

            Dim texto As String = String.Empty

            Try
                texto = If(celda.Value, String.Empty).ToString().Trim()
            Catch ex As Exception
                texto = String.Empty
            End Try

            If String.IsNullOrEmpty(texto) Then
                Clipboard.Clear()
            Else
                Clipboard.SetText(texto)
            End If

            MessageBoxEx.Show(Me, "Valor copiado al portapapeles." & If(String.IsNullOrEmpty(texto), String.Empty, vbCrLf & texto), "Copiar", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return True

        Catch ex As Exception
            MessageBoxEx.Show(Me, "Ocurrió un error al copiar al portapapeles:" & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function

    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            With sender

                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)

                If Hitest.Type = DataGridViewHitTestType.Cell Then

                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim Dg As DataGridView = sender

                    If Not IsNothing(sender) Then
                        If Dg.Name = "Grilla_Productos" Then
                            ShowContextMenu(Menu_Contextual_Productos)
                        ElseIf Dg.Name = "Grilla_Clasificaciones" Then
                            ShowContextMenu(Menu_Contextual_Clasificaciones)
                        End If
                    End If

                End If

            End With

        End If

    End Sub

    Private Sub Btn_Estadisticas_Producto_Click(sender As Object, e As EventArgs) Handles Btn_Estadisticas_Producto.Click

        Dim _Fila As DataGridViewRow = Grilla_Productos.CurrentRow
        Dim _Codigo = _Fila.Cells("Codigo").Value

        Dim Fm As New Frm_EstadisticaProducto(_Codigo)

        Fm.Pro_Agrupar_Reemplazos = True
        Fm.Input_Stock_Minimo.Enabled = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_MostrarGraficoXProducto_Click(sender As Object, e As EventArgs) Handles Btn_MostrarGraficoXProducto.Click
        Call Grilla_Productos_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Btn_VerDocPdtesXProductos_Click(sender As Object, e As EventArgs) Handles Btn_VerDocPdtesXProductos.Click

        Dim _Fila As DataGridViewRow = Grilla_Productos.CurrentRow
        Dim _Codigo = _Fila.Cells("Codigo").Value
        Dim _Descripcion = _Fila.Cells("Descripcion").Value

        Dim _Condicion As String = String.Empty

        If Not String.IsNullOrEmpty(_Codigo) Then
            _Condicion += "Codigo = '" & _Codigo & "'"
        End If

        Dim _Reg = _Sql.Fx_Cuenta_Registros($"Tbl_Asc_04_DocUltComp_{FUNCIONARIO}", _Condicion)

        If Not CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No hay documentos pendientes de compra para mostrar",
                              "Ver documentos pendientes de compra", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_SobreStock_Llegadas("", _Codigo)
        Fm.Text = "PRODUCTO: " & _Codigo & " - " & _Descripcion
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Grilla_Productos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Productos.CellEnter

        Try

            Dim _Fila As DataGridViewRow = Grilla_Productos.CurrentRow
            Dim _Codigo As String = _Fila.Cells("Codigo").Value
            Dim _Descripcion As String = _Fila.Cells("Descripcion").Value

            Lbl_Producto.Text = "Producto: " & _Codigo & " - " & _Descripcion

        Catch ex As Exception
            Lbl_Producto.Text = String.Empty
        End Try

    End Sub

    Private Sub Btn_EnviarProdSobreStock_Click(sender As Object, e As EventArgs) Handles Btn_EnviarProdSobreStock.Click

        Dim _Fila As DataGridViewRow = Grilla_Productos.CurrentRow
        Dim _Codigo As String = _Fila.Cells("Codigo").Value
        Dim _Descripcion As String = _Fila.Cells("Descripcion").Value
        Dim _KilosXPallet As Double = _Fila.Cells("KilosXPallet").Value
        Dim _PalletSY As Double = IIf(NuloPorNro(_Fila.Cells("PalletSY").Value, 0) > 0, _Fila.Cells("PalletSY").Value, 0)


        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_SobreStock",
                                                     "Empresa = '" & Mod_Empresa & "' And " &
                                                     "Codigo = '" & _Codigo & "' And " &
                                                     "Activo = 1 And Eliminado = 0")

        If _Reg > 0 Then
            MessageBoxEx.Show(Me, "El producto ya se encuentra ingresado para la venta de Sobre/Stock" & vbCrLf &
                              $"Producto: {_Codigo.ToString.Trim} - {_Descripcion.ToString.Trim}", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Zw_Prod_SobreStock As New Zw_Prod_SobreStock

        Consulta_sql = "Select Ms.EMPRESA,Sum(Ms.STFI1) As 'STFI1',Sum(Ms.STFI2) As 'STFI2',Sum(Ms.STTR1) As 'STTR1'" & vbCrLf &
                       ",Sum(Ms.STTR2) As 'STTR2',Sum(Ms.STOCNV1) As 'STOCNV1',Sum(Ms.STOCNV2) As 'STOCNV2'" & vbCrLf &
                       ",Sum(Isnull(St.StComp1,0)) As 'StComp1',Sum(Isnull(St.StComp2,0)) As 'StComp2'" & vbCrLf &
                       ",Cast(0 As Float) As StDispUd1,Cast(0 As Float) As StockDisponibleUd2" & vbCrLf &
                       "Into #Paso" & vbCrLf &
                       "From MAEST Ms" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Prod_Stock St On St.Empresa = Ms.EMPRESA And St.Sucursal = Ms.KOSU And St.Bodega = Ms.KOBO And St.Codigo = Ms.KOPR" & vbCrLf &
                       "Where Ms.EMPRESA = '" & Mod_Empresa & "' And Ms.KOPR = '" & _Codigo & "'" & vbCrLf &
                       "Group By Ms.EMPRESA" & vbCrLf &
                       "Update #Paso Set StDispUd1 = STFI1-(STOCNV1+StComp1+STTR1),StockDisponibleUd2 = STFI2-(STOCNV2+StComp2+STTR2)" & vbCrLf &
                       "Select * From #Paso" & vbCrLf &
                       "Drop Table #Paso"

        Dim _Row_Stock As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Stock) Then
            MessageBoxEx.Show(Me, "No tiene stock suficiente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        With _Zw_Prod_SobreStock

            .Id = 0
            .Empresa = Mod_Empresa
            .Codigo = _Codigo
            .Descripcion = _Descripcion
            .FormatoPqte = "Pallet"
            .StDispUd1 = _Row_Stock.Item("StDispUd1")
            .PqteHabilitado = _PalletSY
            .Ud1XPqte = _KilosXPallet
            .CantMinFormato = 0
            .Moneda = String.Empty
            .PrecioXUd1 = 0

        End With

        Dim _Grabar As Boolean

        Dim Fm As New Frm_SobreStock_IngDet(_Zw_Prod_SobreStock)
        Fm.Text = "SUBIR PRODUCTOS CON SOBRE STOCK"
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _Zw_Prod_SobreStock = Fm.Zw_Prod_SobreStock
        Fm.Dispose()

        If Not _Grabar Then
            Return
        End If

        Dim _Cl_SobreStock As New Cl_SobreStock
        Dim _Mensaje As LsValiciones.Mensajes

        _Mensaje = _Cl_SobreStock.Fx_Grabar_Producto_Para_SobreStock(_Zw_Prod_SobreStock)

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Validación", MessageBoxButtons.OK, _Mensaje.Icono)
        If Not _Mensaje.EsCorrecto Then
            Return
        End If

    End Sub

    Private Sub Btn_VerProdSobreStock_Click(sender As Object, e As EventArgs) Handles Btn_VerProdSobreStock.Click

        Dim Fm As New Frm_SobreStock_Productos
        Fm.Btn_AgregarProducto.Visible = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Chk_SumarStockDisponible_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_SumarStockDisponible.CheckedChanged
        Call Btn_Actualizar_Click(Nothing, Nothing)
    End Sub

    Private Sub Chk_MostrarSoloProdConStockEnDetalle_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_MostrarSoloProdConStockEnDetalle.CheckedChanged
        Call Grilla_Clasificaciones_CellEnter(Nothing, Nothing)
    End Sub
End Class
