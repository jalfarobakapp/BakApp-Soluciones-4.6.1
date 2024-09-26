Imports DevComponents.DotNetBar

Public Class Frm_01_Inventario_Actual

    Private _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Private Consulta_sql As String

    Public IdBodega As String

    Private _Fecha_Inventario As Date
    Private _Empresa As String
    Private _Sucursal As String
    Private _Bodega As String

    Private _IdInventario As Integer
    Private _Cl_Inventario As New Cl_Inventario

    Private _Tbl_FotoInventario As DataTable
    Private _Dv As DataView

    Private _Tbl_Filtro_Sectores As DataTable
    Private _Tbl_Filtro_Encargados As DataTable
    Private _Filtrar_Todos_Sectores As Boolean = True
    Private _Filtrar_Todos_Encargados As Boolean = True

    Public Sub New(_IdInventario As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Me._IdInventario = _IdInventario
        _Cl_Inventario.Fx_Llenar_Zw_Inv_Inventario(_IdInventario)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Inventario_Actual_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        With _Cl_Inventario.Zw_Inv_Inventario

            _Fecha_Inventario = _Cl_Inventario.Zw_Inv_Inventario.Fecha_Inventario
            _Empresa = .Empresa
            _Sucursal = .Sucursal
            _Bodega = _Bodega

        End With

        AddHandler Grilla.MouseDown, AddressOf Grilla_MouseDown
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Rdb_MostrarSoloInventariados.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_MostrarSoloConStockSinInventariar.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_MostrarTodosLosProductos.CheckedChanged, AddressOf Rdb_CheckedChanged

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Sb_Actualizar_Grilla()

        Me.Cursor = Cursors.WaitCursor

        Btn_Filtro_Encargados.Image = Fx_Imagen_Filtro(_Filtrar_Todos_Encargados)
        Btn_Filtro_Sectores.Image = Fx_Imagen_Filtro(_Filtrar_Todos_Sectores)

        Btn_Filtrar.Image = Fx_Imagen_Filtro(_Filtrar_Todos_Sectores And _Filtrar_Todos_Encargados)

        Dim _Filtros As String = String.Empty

        If Not _Filtrar_Todos_Sectores Then
            Dim _Fl As String = Generar_Filtro_IN(_Tbl_Filtro_Sectores, "Chk", "Codigo", False, True, "'")
            _Filtros += "And Codigo In (Select Codigo From " & _Global_BaseBk & "Zw_Inv_Hoja_Detalle " &
                        "Where Sector In " & _Fl & ")" & vbCrLf
        End If

        If Not _Filtrar_Todos_Encargados Then
            Dim _Fl As String = Generar_Filtro_IN(_Tbl_Filtro_Encargados, "Chk", "Codigo", False, True, "'")
            _Filtros += "And Codigo In (Select Codigo From " & _Global_BaseBk & "Zw_Inv_Hoja_Detalle " &
                        "Where IdSector In (Select Id From " & _Global_BaseBk & "Zw_Inv_Sector Where CodFuncionario In " & _Fl & ") " &
                        "And IdInventario = " & _IdInventario & ")" & vbCrLf
        End If

        Consulta_sql = "Select Codigo,Recontado, SUM(Cantidad) As Cantidad" & vbCrLf &
                       "Into #PasoR" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_Hoja_Detalle" & vbCrLf &
                       "Where IdInventario = " & _IdInventario & " And Recontado = 1" & vbCrLf &
                       "Group By Codigo,Recontado" & vbCrLf &
                       vbCrLf &
                       "Select Codigo,Recontado, SUM(Cantidad) As Cantidad" & vbCrLf &
                       "Into #PasoC" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_Hoja_Detalle" & vbCrLf &
                       "Where IdInventario = " & _IdInventario & " And Codigo Not In (Select Codigo From #PasoR)" & vbCrLf &
                       "Group By Codigo,Recontado" & vbCrLf &
                       vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Inv_FotoInventario Set Recontado = 0 Where IdInventario = " & _IdInventario & vbCrLf &
                       vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Inv_FotoInventario Set Recontado = 1,Cant_Inventariada = Cantidad" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_FotoInventario Foto" & vbCrLf &
                       "Inner Join #PasoR On #PasoR.Codigo = Foto.Codigo" & vbCrLf &
                       "Where IdInventario = " & _IdInventario & vbCrLf &
                       vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Inv_FotoInventario Set Cant_Inventariada = Cantidad" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_FotoInventario Foto" & vbCrLf &
                       "Inner Join #PasoC On #PasoC.Codigo = Foto.Codigo" & vbCrLf &
                       "Where IdInventario = " & _IdInventario & "" & vbCrLf &
                       vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Inv_FotoInventario Set " &
                       "Dif_Inv_Cantidad = ROUND(Cant_Inventariada-StFisicoUd1,5)," &
                       "Total_Costo_Foto = StFisicoUd1*Costo,Total_Costo_Inv = Cant_Inventariada*Costo," &
                       "Dif_Inv_Costo = Total_Costo_Inv-Total_Costo_Foto" & vbCrLf &
                       "Where IdInventario = " & _IdInventario & vbCrLf &
                       vbCrLf &
                       "Drop Table #PasoR" & vbCrLf &
                       "Drop Table #PasoC"

        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Select Codigo,CodigoRap,CodigoTec,Descripcion,StFisicoUd1,Cant_Inventariada,Costo,Dif_Inv_Cantidad," &
                       "Total_Costo_Foto,Total_Costo_Inv,Dif_Inv_Costo,Recontado,NoInventariar," & vbCrLf &
                       "SuperFamilia,Nom_SuperFamilia,Familia,Nom_Familia,SubFamilia,Nom_SubFamilia,Rubro,Nom_Rubro,ClasLibre,Nom_ClasLibre,Zona,Nom_Zona" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_FotoInventario" & vbCrLf &
                       "Where IdInventario = " & _IdInventario & vbCrLf & _Filtros

        Dim _New_Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)
        _Dv = New DataView
        _Dv.Table = _New_Ds.Tables("Table")
        _Tbl_FotoInventario = _Dv.Table

        With Grilla

            .DataSource = _Dv

            OcultarEncabezadoGrilla(Grilla)

            Dim DisplayIndex As Integer = 0

            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = DisplayIndex
            DisplayIndex += 1

            .Columns("Descripcion").Width = 290
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = DisplayIndex
            DisplayIndex += 1

            .Columns("StFisicoUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StFisicoUd1").DefaultCellStyle.Format = "###,##.#####"
            .Columns("StFisicoUd1").HeaderText = "Stock"
            .Columns("StFisicoUd1").Width = 50
            .Columns("StFisicoUd1").Visible = True
            .Columns("StFisicoUd1").DisplayIndex = DisplayIndex
            DisplayIndex += 1

            .Columns("Cant_Inventariada").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cant_Inventariada").DefaultCellStyle.Format = "###,##.#####"
            .Columns("Cant_Inventariada").HeaderText = "Inventario"
            .Columns("Cant_Inventariada").ToolTipText = "Cantidad Inventariada"
            .Columns("Cant_Inventariada").Width = 70
            .Columns("Cant_Inventariada").Visible = True
            .Columns("Cant_Inventariada").DisplayIndex = DisplayIndex
            DisplayIndex += 1

            .Columns("Costo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Costo").DefaultCellStyle.Format = "$ ###,#0"
            .Columns("Costo").HeaderText = "Costo PM"
            .Columns("Costo").Width = 60
            .Columns("Costo").Visible = True
            .Columns("Costo").DisplayIndex = DisplayIndex
            DisplayIndex += 1

            .Columns("Dif_Inv_Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Dif_Inv_Cantidad").DefaultCellStyle.Format = "###,##.#####"
            .Columns("Dif_Inv_Cantidad").HeaderText = "Dif. Inv."
            .Columns("Dif_Inv_Cantidad").Width = 70
            .Columns("Dif_Inv_Cantidad").Visible = True
            .Columns("Dif_Inv_Cantidad").DisplayIndex = DisplayIndex
            DisplayIndex += 1

            .Columns("Total_Costo_Foto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Costo_Foto").DefaultCellStyle.Format = "$ ###,#0"
            .Columns("Total_Costo_Foto").HeaderText = "Total Foto $"
            .Columns("Total_Costo_Foto").Width = 70
            .Columns("Total_Costo_Foto").Visible = True
            .Columns("Total_Costo_Foto").DisplayIndex = DisplayIndex
            DisplayIndex += 1

            .Columns("Total_Costo_Inv").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Costo_Inv").DefaultCellStyle.Format = "$ ###,#0"
            .Columns("Total_Costo_Inv").HeaderText = "Total Inv. $"
            .Columns("Total_Costo_Inv").Width = 70
            .Columns("Total_Costo_Inv").Visible = True
            .Columns("Total_Costo_Inv").DisplayIndex = DisplayIndex
            DisplayIndex += 1

            .Columns("Dif_Inv_Costo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Dif_Inv_Costo").DefaultCellStyle.Format = "$ ###,#0"
            .Columns("Dif_Inv_Costo").HeaderText = "Dif. $"
            .Columns("Dif_Inv_Costo").Width = 70
            .Columns("Dif_Inv_Costo").Visible = True
            .Columns("Dif_Inv_Costo").DisplayIndex = DisplayIndex
            DisplayIndex += 1

            .Columns("Recontado").HeaderText = "[R]"
            .Columns("Recontado").ToolTipText = "Recontado"
            .Columns("Recontado").Width = 30
            .Columns("Recontado").Visible = True
            .Columns("Recontado").DisplayIndex = DisplayIndex
            DisplayIndex += 1

            '.Columns("Cerrado").HeaderText = "[C]"
            '.Columns("Cerrado").Width = 30
            '.Columns("Cerrado").Visible = True
            '.Columns("Cerrado").DisplayIndex = DisplayIndex
            'DisplayIndex += 1

            '.Columns("Levantado").HeaderText = "[L]"
            '.Columns("Levantado").Width = 30
            '.Columns("Levantado").Visible = True
            '.Columns("Levantado").DisplayIndex = DisplayIndex
            'DisplayIndex += 1

            .Columns("NoInventariar").HeaderText = "NO Inv."
            .Columns("NoInventariar").ToolTipText = "No Inventariar"
            .Columns("NoInventariar").Width = 30
            .Columns("NoInventariar").Visible = True
            .Columns("NoInventariar").DisplayIndex = DisplayIndex

        End With

        Sb_SumarTotales()
        Me.Cursor = Cursors.Default

        Sb_Filtrar()

    End Sub

    Sub Sb_SumarTotales()

        Dim _Total_Inventario As Double
        Dim _Total_Foto As Double

        For Each row As DataGridViewRow In Grilla.Rows
            _Total_Inventario += CDbl(row.Cells("Total_Costo_Inv").Value)
            _Total_Foto += CDbl(row.Cells("Total_Costo_Foto").Value)
        Next

        Dim _Total_Diferencia As Double = _Total_Inventario - _Total_Foto

        LblTotal_FotoStock.Text = FormatCurrency(_Total_Foto, 0)
        LblTotal_Inventario.Text = FormatCurrency(_Total_Inventario, 0)
        LblTotal_Diferencia.Text = FormatCurrency(_Total_Diferencia, 0)

        If _Total_Diferencia < 0 Then
            LblTotal_Diferencia.ForeColor = Rojo
        Else
            LblTotal_Diferencia.ForeColor = Verde
        End If

    End Sub

    Private Sub Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

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

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub BtnExcel_Click(sender As System.Object, e As System.EventArgs)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Inv_Inventario" & vbCrLf &
                        "Where IdInventario = " & _IdInventario

        ExportarTabla_JetExcel(Consulta_sql, Me, "Inventario")

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        Ver_Detalle_Del_Producto()
    End Sub

    Sub Ver_Detalle_Del_Producto()

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _CodigoPR As String = _Fila.Cells("Codigo").Value
        Dim _DescripcionPR As String = _Fila.Cells("Descripcion").Value.ToString.Trim
        Dim _StFisicoUd1 As Double = _Fila.Cells("StFisicoUd1").Value
        Dim _Cant_Inventariada As Double = _Fila.Cells("Cant_Inventariada").Value
        Dim _Dif_Inv_Cantidad As Double = _Fila.Cells("Dif_Inv_Cantidad").Value
        'Dim _Cerrado As Boolean = _Fila.Cells("Cerrado").Value
        Dim _Recontado As Boolean = _Fila.Cells("Recontado").Value
        'Dim _Levantado As Boolean = _Fila.Cells("Levantado").Value

        Dim Fm As New Frm_02_Detalle_Producto_Actual(_IdInventario, _CodigoPR)

        Fm.Text = "Producto: " & _CodigoPR & " - " & _DescripcionPR
        Fm.ShowDialog(Me)

        _Fila.Cells("Cant_Inventariada").Value = Fm.Zw_Inv_FotoInventario.Cant_Inventariada
        _Fila.Cells("Dif_Inv_Cantidad").Value = Fm.Zw_Inv_FotoInventario.Dif_Inv_Cantidad
        _Fila.Cells("Total_Costo_Foto").Value = Fm.Zw_Inv_FotoInventario.Total_Costo_Foto
        _Fila.Cells("Total_Costo_Inv").Value = Fm.Zw_Inv_FotoInventario.Total_Costo_Inv
        _Fila.Cells("Dif_Inv_Costo").Value = Fm.Zw_Inv_FotoInventario.Dif_Inv_Costo
        '_Fila.Cells("Cerrado").Value = Fm.Zw_Inv_FotoInventario.Cerrado
        _Fila.Cells("Recontado").Value = Fm.Zw_Inv_FotoInventario.Recontado
        '_Fila.Cells("Levantado").Value = Fm.Zw_Inv_FotoInventario.Levantado
        _Fila.Cells("NoInventariar").Value = Fm.Zw_Inv_FotoInventario.NoInventariar

        Fm.Dispose()

    End Sub


    Private Sub BtnFiltroSectores_Click(sender As System.Object, e As System.EventArgs)

        Dim Fm As New Frm_03_Sectores_Inv

        Fm._IngresarHoja = True
        Fm._Empresa = _Empresa
        Fm._Sucursal = _Sucursal
        Fm._Bodega = _Bodega
        Fm._IdInventario = _IdInventario
        Fm.Grilla_Inv.ContextMenuStrip = Nothing
        Fm._ValidaEstado = False

        Fm.ShowDialog(Me)

        'If String.IsNullOrEmpty(Trim(_CodSectorSel)) Then
        '    MessageBoxEx.Show("No se selecciono ningun sector", "Filtrar por sector", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End If

    End Sub

    Private Sub ButtonItem2_Click_1(sender As System.Object, e As System.EventArgs)
        Dim Fm As New Frm_05_Filtrar_FMRCZ
        Fm._IdInventario = _IdInventario
        Fm.ShowDialog(Me)
    End Sub

    Sub Sb_Filtrar()
        Try
            Me.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            If IsNothing(_Dv) Then Return

            If Rdb_MostrarTodosLosProductos.Checked Then
                _Dv.RowFilter = String.Format("Codigo+CodigoRap+CodigoTec+Descripcion Like '%{0}%'", Txt_Filtrar.Text.Trim)
            End If
            If Rdb_MostrarSoloInventariados.Checked Then
                _Dv.RowFilter = String.Format("Codigo+CodigoRap+CodigoTec+Descripcion Like '%{0}%' And Cant_Inventariada <> 0", Txt_Filtrar.Text.Trim)
            End If
            If Rdb_MostrarSoloConStockSinInventariar.Checked Then
                _Dv.RowFilter = String.Format("Codigo+CodigoRap+CodigoTec+Descripcion Like '%{0}%' And Cant_Inventariada = 0 And StFisicoUd1 <> 0", Txt_Filtrar.Text.Trim)
            End If
            Sb_SumarTotales()
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Cuek!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Me.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Txt_Filtrar_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Filtrar.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Filtrar()
        End If
    End Sub

    Private Sub Txt_Filtrar_TextChanged(sender As Object, e As EventArgs) Handles Txt_Filtrar.TextChanged
        If String.IsNullOrEmpty(Txt_Filtrar.Text) Then
            Sb_Filtrar()
        End If
    End Sub

    Private Sub Txt_Filtrar_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Filtrar.ButtonCustom2Click
        Txt_Filtrar.Text = String.Empty
        Sb_Filtrar()
    End Sub

    Private Sub Btn_RevisarProducto_Click(sender As Object, e As EventArgs) Handles Btn_RevisarProducto.Click
        Call Grilla_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Btn_Copiar_Click(sender As Object, e As EventArgs) Handles Btn_Copiar.Click
        With Grilla
            Try
                Dim _Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
                Dim _Texto_Cabeza = .Columns(.CurrentCell.ColumnIndex).HeaderText
                Dim Copiar = .Rows(.CurrentRow.Index).Cells(_Cabeza).Value
                Clipboard.SetText(Copiar)

                ToastNotification.Show(Me, _Texto_Cabeza & " esta en el portapapeles", Btn_Copiar.Image,
                                       2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
            Catch ex As Exception
                MessageBoxEx.Show(Me, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End With
    End Sub

    Private Sub Btn_ExportarAjuste_Todo_Click(sender As Object, e As EventArgs) Handles Btn_ExportarAjuste_Todo.Click

        Consulta_sql = "Select Hd.Codigo,Sum(Cantidad) As Cantidad,Ft.Costo
Into #PasoR
From " & _Global_BaseBk & "Zw_Inv_Hoja_Detalle Hd
Left Join " & _Global_BaseBk & "Zw_Inv_FotoInventario Ft On Ft.IdInventario = Hd.IdInventario And Ft.Codigo = Hd.Codigo
Where Hd.IdInventario = " & _IdInventario & " And Hd.Recontado = 1 And Cantidad > 0
Group by Hd.Codigo,Ft.Costo

Select Hd.Codigo,Sum(Cantidad) As Cantidad,Ft.Costo
Into #PasoC
From " & _Global_BaseBk & "Zw_Inv_Hoja_Detalle Hd
Left Join " & _Global_BaseBk & "Zw_Inv_FotoInventario Ft On Ft.IdInventario = Hd.IdInventario And Ft.Codigo = Hd.Codigo
Where Hd.IdInventario = " & _IdInventario & " And Hd.Recontado = 0 And Hd.Codigo Not In (Select Codigo From #PasoR) And Cantidad > 0
Group by Hd.Codigo,Ft.Costo

Select * From #PasoC
Union
Select * From #PasoR

Drop table #PasoC
Drop table #PasoR"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim NombreFile As String = "Levantar Inventario " & FormatDateTime(_Fecha_Inventario, DateFormat.LongDate)

        ExportarTabla_JetExcel_Tabla(_Tbl, Me, NombreFile)

    End Sub

    Private Sub Btn_ExportarAjuste_Cerrados_Click(sender As Object, e As EventArgs) Handles Btn_ExportarAjuste_Cerrados.Click

        MessageBoxEx.Show(Me, "En construcción", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return

        Consulta_sql = "select Codigo As 'Codigo',Cantidad As 'Cantidad',Costo as 'Costo'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_Inventario" & vbCrLf &
                       "Where IdInventario = " & _IdInventario & vbCrLf &
                       "And Cerrado = 1 And Cantidad > 0"

        Dim NombreFile As String = "Inventario SOLO CERRADOS " & FormatDateTime(_Fecha_Inventario, DateFormat.LongDate)

        ExportarTabla_JetExcel(Consulta_sql, Me, NombreFile)

    End Sub

    Private Sub Btn_ExportarAjuste_Click(sender As Object, e As EventArgs) Handles Btn_ExportarAjuste.Click

        'If _Cl_Inventario.Zw_Inv_Inventario.Activo Then
        '    MessageBoxEx.Show(Me, "Actualmente, el inventario está abierto, lo que significa que no es posible" & vbCrLf &
        '                      "exportar los ajustes. Para poder realizar esta acción, es necesario cerrar el inventario primero.", "Validación",
        '                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Return
        'End If

        ShowContextMenu(Menu_Contextual_ExportarAjuste)

    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Rdb_CheckedChanged(sender As Object, e As EventArgs)
        If sender.Checked Then
            Txt_Filtrar.Text = String.Empty
            Sb_Filtrar()
        End If
    End Sub

    Private Sub Btn_Btn_ExportarResumenActual_Click(sender As Object, e As EventArgs) Handles Btn_Btn_ExportarResumenActual.Click
        ExportarTabla_JetExcel_Tabla(_Dv.ToTable(), Me, "Resumen1")
    End Sub

    Private Sub Btn_Btn_ExportarResumenTodo_Click(sender As Object, e As EventArgs) Handles Btn_Btn_ExportarResumenTodo.Click
        ExportarTabla_JetExcel_Tabla(_Dv.Table(), Me, "Resumen")
    End Sub

    Private Sub Btn_Ver_Informacion_Producto_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Informacion_Producto.Click
        If Fx_Tiene_Permiso(Me, "Prod009") Then
            Dim _Fila As DataGridViewRow = Grilla.CurrentRow
            Dim _Codigo As String = _Fila.Cells("Codigo").Value
            Dim _Producto_Op As New Frm_BkpPostBusquedaEspecial_Mt
            _Producto_Op.Sb_Ver_Informacion_Adicional_producto(Me, _Codigo)
        End If
    End Sub

    Private Sub Btn_Filtro_Sectores_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Sectores.Click

        Dim _Sql_Filtro_Condicion_Extra = "And IdInventario = " & _IdInventario
        Dim _Filtro_Extra_Encargados = String.Empty

        If Not _Filtrar_Todos_Encargados Then
            If Not (_Tbl_Filtro_Encargados Is Nothing) Then
                If _Tbl_Filtro_Encargados.Rows.Count Then

                    Dim _Fl_Encargados = Generar_Filtro_IN(_Tbl_Filtro_Encargados, "Chk", "Codigo", False, True, "'")
                    _Filtro_Extra_Encargados += vbCrLf & "And CodFuncionario In " & _Fl_Encargados

                End If
            End If
        End If

        _Sql_Filtro_Condicion_Extra += _Filtro_Extra_Encargados

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_Inv_Sector"
        _Filtrar.Campo = "Sector"
        _Filtrar.Descripcion = "NombreSector"

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Sectores,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _Sql_Filtro_Condicion_Extra,
                               _Filtrar_Todos_Sectores, False) Then

            _Tbl_Filtro_Sectores = _Filtrar.Pro_Tbl_Filtro
            _Filtrar_Todos_Sectores = _Filtrar.Pro_Filtro_Todas

            Sb_Actualizar_Grilla()

        End If

    End Sub

    Private Sub Btn_Filtro_Encargados_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Encargados.Click

        Dim _Sql_Filtro_Condicion_Extra = "And KOFU In (Select CodFuncionario From " & _Global_BaseBk &
                                          "Zw_Inv_Sector Where IdInventario = " & _IdInventario & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Encargados,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra,
                               _Filtrar_Todos_Encargados, False) Then

            _Tbl_Filtro_Encargados = _Filtrar.Pro_Tbl_Filtro
            _Filtrar_Todos_Encargados = _Filtrar.Pro_Filtro_Todas

            Sb_Actualizar_Grilla()

        End If

    End Sub

    Function Fx_Imagen_Filtro(_Todas As Boolean) As Image

        If _Todas Then
            Return Nothing
        Else
            Return Imagenes_16x16.Images.Item("filter.png")
        End If

    End Function

    Private Sub Btn_Filtrar_Click(sender As Object, e As EventArgs) Handles Btn_Filtrar.Click
        ShowContextMenu(Menu_Contextual_Filtrar)
    End Sub
End Class
