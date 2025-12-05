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

        Sb_Formato_Generico_Grilla(Grilla_Clasificaciones, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Formato_Generico_Grilla(Grilla_Productos, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

    End Sub

    Private Sub Frm_SobreStockXClas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler Grilla_Clasificaciones.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Productos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

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

            Dim _AnchoClValores = 60

            .Columns("Codigo_Nodo_Madre").Visible = True
            .Columns("Codigo_Nodo_Madre").HeaderText = "Codigo_Nodo_Madre"
            '.Columns("Codigo_Nodo_Madre").ToolTipText = "Vendedor"
            .Columns("Codigo_Nodo_Madre").Width = 80
            .Columns("Codigo_Nodo_Madre").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Producto").Visible = True
            .Columns("Producto").HeaderText = "Producto"
            '.Columns("Codigo_Nodo_Madre").ToolTipText = "Vendedor"
            .Columns("Producto").Width = 200
            .Columns("Producto").DisplayIndex = _DisplayIndex
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
            '.Columns("Codigo_Nodo_Madre").ToolTipText = "Vendedor"
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
            .Columns("Syncro").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Syncro").Visible = True
            .Columns("Syncro").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("KilosXPallet").Width = _AnchoClValores
            .Columns("KilosXPallet").HeaderText = "Kg X Pallet"
            .Columns("KilosXPallet").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("KilosXPallet").DefaultCellStyle.Format = "###,##0.##"
            .Columns("KilosXPallet").Visible = True
            .Columns("KilosXPallet").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PalletSY").Width = 50
            .Columns("PalletSY").HeaderText = "Pallet SY"
            .Columns("PalletSY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PalletSY").DefaultCellStyle.Format = "###,##0.##"
            .Columns("PalletSY").Visible = True
            .Columns("PalletSY").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SobreStock").Width = 40
            .Columns("SobreStock").Visible = True
            .Columns("SobreStock").HeaderText = "Sobre" & vbCrLf & "Stock"
            '.Columns("Codigo_Nodo_Madre").ToolTipText = "Vendedor"
            .Columns("SobreStock").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

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

        Dim _Codigo_Nodo As Integer = _Fila.Cells("Codigo_Nodo").Value
        Dim _Codigo_Nodo_Madre2 = _Fila.Cells("Codigo_Nodo_Madre").Value

        Consulta_sql = "Select * From " & _Cl_SobreStockXClas.TablaPasoRotacion_Productos & vbCrLf &
                       "Where Codigo_Nodo_Madre = '" & _Codigo_Nodo_Madre2 & "' And Codigo_Nodo = " & _Codigo_Nodo
        Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla_Productos

            .DataSource = _Tbl_Productos

            OcultarEncabezadoGrilla(Grilla_Productos, True)

            Dim _DisplayIndex = 0

            Dim _AnchoClValores = 60

            .Columns("Codigo").Width = 100
            .Columns("Codigo").Visible = True
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Width = 200
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripción"
            '.Columns("Codigo_Nodo_Madre").ToolTipText = "Vendedor"
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
            '.Columns("Codigo_Nodo_Madre").ToolTipText = "Vendedor"
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

            .Columns("KilosXPallet").Width = _AnchoClValores - 10
            .Columns("KilosXPallet").HeaderText = "Kg X Pallet"
            .Columns("KilosXPallet").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("KilosXPallet").DefaultCellStyle.Format = "###,##0.##"
            .Columns("KilosXPallet").Visible = True
            .Columns("KilosXPallet").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PalletSY").Width = 50
            .Columns("PalletSY").HeaderText = "Pallet SY"
            .Columns("PalletSY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PalletSY").DefaultCellStyle.Format = "###,##0.##"
            .Columns("PalletSY").Visible = True
            .Columns("PalletSY").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SobreStock").Width = 40
            .Columns("SobreStock").Visible = True
            .Columns("SobreStock").HeaderText = "Sobre Stock"
            '.Columns("Codigo_Nodo_Madre").ToolTipText = "Vendedor"
            .Columns("SobreStock").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

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
            _Codigo_Nodo_Madre = _Fila.Cells("Codigo_Nodo_Madre").Value

            Dim _Mensaje As LsValiciones.Mensajes

            _Mensaje = _Cl_SobreStockXClas.Fx_CrearTablaPaso_TablaCalendarioMesesSemanasProductos
            _Mensaje = _Cl_SobreStockXClas.Fx_CrearTablaPaso_TablaCalendarioMesesSemanasClasificacion

            _Mensaje = _Cl_SobreStockXClas.Fx_InsertarDetalleEn_TablaCalendarioMesesSemanasProductos(_Codigo_Nodo_Madre)
            _Mensaje = _Cl_SobreStockXClas.Fx_InsertarDetalleEn_TablaCalendarioMesesSemanasClasificacion(_Codigo_Nodo_Madre)

            Fm_Espera.Close()
            Fm_Espera = Nothing

            ' MessageBoxEx.Show(_Mensaje.Mensaje, "Sobre stock", MessageBoxButtons.OK, _Mensaje.Icono)

            Dim Fm As New Frm_SobreStock_Grafico("", _Codigo_Nodo_Madre)
            Fm.Text = "CLASIFICACION: " & _Codigo_Nodo_Madre.ToString.Trim & " - " & _Producto
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

        Dim _Fila As DataGridViewRow = Grilla_Productos.CurrentRow
        Dim _Codigo As String = _Fila.Cells("Codigo").Value
        Dim _Codigo_Nodo_Madre2 As String = _Fila.Cells("Codigo_Nodo_Madre").Value
        Dim _Descripcion As String = _Fila.Cells("Descripcion").Value

        If String.IsNullOrEmpty(_Codigo_Nodo_Madre) Then
            MessageBoxEx.Show(Me, "Debe seleccionar primero una clasificación", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If _Codigo_Nodo_Madre2 <> _Codigo_Nodo_Madre Then
            MessageBoxEx.Show("El código seleccionado no pertenece a la clasificación seleccionada." & vbCrLf &
                              "Por favor seleccione un código de la clasificación: " & _Codigo_Nodo_Madre,
                              "Sobre stock", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_SobreStock_Grafico(_Codigo, "")
        Fm.Text = "PRODUCTO: " & _Codigo & " - " & _Descripcion.ToString.Trim
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub
End Class
