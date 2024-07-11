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
        AddHandler Chk_MostrarSoloInventariados.CheckedChanged, AddressOf Sb_Filtrar


        Sb_ActualizarGrilla()

    End Sub

    Private Sub Sb_ActualizarGrilla()

        Consulta_sql = "Select Codigo,Recontado, SUM(Cantidad) As Cantidad" & vbCrLf &
                       "Into #Paso" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_Hoja_Detalle" & vbCrLf &
                       "Group By Codigo,Recontado" & vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Inv_FotoInventario Set Recontado = 1" & vbCrLf &
                       "Where Codigo In (Select Codigo From " & _Global_BaseBk & "Zw_Inv_Hoja_Detalle Where Recontado = 1)" & vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Inv_FotoInventario Set Cant_Inventariada = Cantidad" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_FotoInventario Foto" & vbCrLf &
                       "Inner Join #Paso On #Paso.Codigo = Foto.Codigo And Foto.Recontado = #Paso.Recontado" & vbCrLf &
                       "Where Foto.Recontado = 0" & vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Inv_FotoInventario Set Cant_Inventariada = Cantidad" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_FotoInventario Foto" & vbCrLf &
                       "Inner Join #Paso On #Paso.Codigo = Foto.Codigo And Foto.Recontado = #Paso.Recontado" & vbCrLf &
                       "Where Foto.Recontado = 1" & vbCrLf &
                       "Drop table #Paso" & vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Inv_FotoInventario Set " &
                       "Dif_Inv_Cantidad = Cant_Inventariada-StFisicoUd1" &
                       ",Total_Costo_Foto = StFisicoUd1*Costo" &
                       ",Total_Costo_Inv = Cant_Inventariada*Costo" & vbCrLf &
                       "Where IdInventario = " & _IdInventario

        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Inv_FotoInventario" & vbCrLf &
                       "Where IdInventario = " & _IdInventario

        Dim _New_Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)
        _Dv = New DataView
        _Dv.Table = _New_Ds.Tables("Table")
        _Tbl_FotoInventario = _Dv.Table

        With Grilla

            .DataSource = _Dv

            OcultarEncabezadoGrilla(Grilla)

            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = True

            .Columns("Descripcion").Width = 290
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True

            .Columns("StFisicoUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StFisicoUd1").DefaultCellStyle.Format = "###,##.##"
            .Columns("StFisicoUd1").HeaderText = "Stock"
            .Columns("StFisicoUd1").Width = 50
            .Columns("StFisicoUd1").Visible = True

            .Columns("Cant_Inventariada").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cant_Inventariada").DefaultCellStyle.Format = "###,##.##"
            .Columns("Cant_Inventariada").HeaderText = "Inventario"
            .Columns("Cant_Inventariada").Width = 70
            .Columns("Cant_Inventariada").Visible = True

            .Columns("Recontado").HeaderText = "[R]"
            .Columns("Recontado").Width = 30
            .Columns("Recontado").Visible = True

            .Columns("Cerrado").HeaderText = "[C]"
            .Columns("Cerrado").Width = 30
            .Columns("Cerrado").Visible = True

            .Columns("Levantado").HeaderText = "[L]"
            .Columns("Levantado").Width = 30
            .Columns("Levantado").Visible = True

            .Columns("Costo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Costo").DefaultCellStyle.Format = "$ ###,#0"
            .Columns("Costo").HeaderText = "Costo PM"
            .Columns("Costo").Width = 70
            .Columns("Costo").Visible = True

            .Columns("Dif_Inv_Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Dif_Inv_Cantidad").DefaultCellStyle.Format = "###,##.##"
            .Columns("Dif_Inv_Cantidad").HeaderText = "Dif. Inv."
            .Columns("Dif_Inv_Cantidad").Width = 70
            .Columns("Dif_Inv_Cantidad").Visible = True

            .Columns("Total_Costo_Foto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Costo_Foto").DefaultCellStyle.Format = "$ ###,#0"
            .Columns("Total_Costo_Foto").HeaderText = "Total Foto $"
            .Columns("Total_Costo_Foto").Width = 70
            .Columns("Total_Costo_Foto").Visible = True

            .Columns("Total_Costo_Inv").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Costo_Inv").DefaultCellStyle.Format = "$ ###,#0"
            .Columns("Total_Costo_Inv").HeaderText = "Total Inv. $"
            .Columns("Total_Costo_Inv").Width = 70
            .Columns("Total_Costo_Inv").Visible = True

            .Columns("Dif_Inv_Costo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Dif_Inv_Costo").DefaultCellStyle.Format = "$ ###,#0"
            .Columns("Dif_Inv_Costo").HeaderText = "Dif. $"
            .Columns("Dif_Inv_Costo").Width = 70
            .Columns("Dif_Inv_Costo").Visible = True

        End With

        Sb_SumarTotales()

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
            LblTotal_Diferencia.ForeColor = Color.Red
        Else
            LblTotal_Diferencia.ForeColor = Color.Green
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
        Dim _Cerrado As Boolean = _Fila.Cells("Cerrado").Value
        Dim _Recontado As Boolean = _Fila.Cells("Recontado").Value
        Dim _Levantado As Boolean = _Fila.Cells("Levantado").Value

        Dim Fm As New Frm_02_Detalle_Producto_Actual(_IdInventario, _CodigoPR)

        Fm.Text = "Producto: " & _CodigoPR & " - " & _DescripcionPR
        Fm.ShowDialog(Me)

        _Fila.Cells("Cant_Inventariada").Value = Fm.Zw_Inv_FotoInventario.Cant_Inventariada
        _Fila.Cells("Dif_Inv_Cantidad").Value = Fm.Zw_Inv_FotoInventario.Dif_Inv_Cantidad
        _Fila.Cells("Total_Costo_Foto").Value = Fm.Zw_Inv_FotoInventario.Total_Costo_Foto
        _Fila.Cells("Total_Costo_Inv").Value = Fm.Zw_Inv_FotoInventario.Total_Costo_Inv
        _Fila.Cells("Dif_Inv_Costo").Value = Fm.Zw_Inv_FotoInventario.Dif_Inv_Costo
        _Fila.Cells("Cerrado").Value = Fm.Zw_Inv_FotoInventario.Cerrado
        _Fila.Cells("Recontado").Value = Fm.Zw_Inv_FotoInventario.Recontado
        _Fila.Cells("Levantado").Value = Fm.Zw_Inv_FotoInventario.Levantado

        Fm.Dispose()

    End Sub



    Private Sub BtnCerrarSinDiferencias_Click(sender As System.Object, e As System.EventArgs) Handles BtnCerrarSinDiferencias.Click

        Dim _Condicion As String = "IdInventario = " & _IdInventario & vbCrLf &
                                   "And Diferencia = ''" & vbCrLf &
                                   "And Recontado = 0" & vbCrLf &
                                   "And Levantado = 0"

        Dim Reg As Integer = _Sql.Fx_Cuenta_Registros("Zw_Inv_Inventario", _Condicion)

        If Reg > 0 Then

            Consulta_sql = "Update Zw_Inv_Inventario Set Cerrado = 1 " & vbCrLf &
                           "Where " & vbCrLf & _Condicion

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                MessageBoxEx.Show("Productos cerrados " & Reg, "Cerrar",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else
            MessageBoxEx.Show("No existen productos que marcar", "Cerrar",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub


    Private Sub BtnLevantados_Click(sender As System.Object, e As System.EventArgs) Handles BtnLevantados.Click


        Dim _Condicion As String = "IdInventario = " & _IdInventario & vbCrLf &
                                   "And Cerrado = 1" & vbCrLf &
                                   "And Levantado = 0"

        Dim Reg As Integer = _Sql.Fx_Cuenta_Registros("Zw_Inv_Inventario", _Condicion)

        If Reg > 0 Then
            Consulta_sql = "Update Zw_Inv_Inventario Set Levantado = 1 " & vbCrLf &
                           "Where " & vbCrLf & _Condicion

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                MessageBoxEx.Show("Productos Levantados " & Reg, "Marcar Levantados",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else
            MessageBoxEx.Show("No existen productos que marcar", "Marcar Levantados",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnMarcarLevantadosInventariados_Click(sender As System.Object, e As System.EventArgs) Handles BtnCerrarInventariados.Click

        Dim _Condicion As String = "IdInventario = " & _IdInventario & vbCrLf &
                                   "And Cant_Inventariada > 0" & vbCrLf &
                                   "And Cerrado = 0"

        Dim Reg As Integer = _Sql.Fx_Cuenta_Registros("Zw_Inv_Inventario", _Condicion)

        If Reg > 0 Then
            Consulta_sql = "Update Zw_Inv_Inventario Set Cerrado = 1 " & vbCrLf &
                           "Where " & vbCrLf & _Condicion

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                MessageBoxEx.Show("Productos Levantados " & Reg, "Marcar Levantados",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else
            MessageBoxEx.Show("No existen productos que marcar", "Marcar Levantados",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

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

    Private Sub BtnCerrarTodosInvCero_Click(sender As System.Object, e As System.EventArgs) Handles BtnCerrarTodosInvCero.Click
        MessageBoxEx.Show(Me, "En Construcción")
    End Sub

    Sub Sb_Filtrar()
        Try
            Me.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            If IsNothing(_Dv) Then Return

            If Chk_MostrarSoloInventariados.Checked Then
                _Dv.RowFilter = String.Format("Codigo+CodigoRap+CodigoTec+Descripcion Like '%{0}%' And Cant_Inventariada > 0", Txt_Filtrar.Text.Trim)
            Else
                _Dv.RowFilter = String.Format("Codigo+CodigoRap+CodigoTec+Descripcion Like '%{0}%'", Txt_Filtrar.Text.Trim)
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

        Consulta_sql = "select Codigo As 'Codigo',Cantidad As 'Cantidad',Costo as 'Costo'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_Inventario" & vbCrLf &
                       "Where IdInventario = " & _IdInventario

        Dim NombreFile As String = "Inventario TODOS " & FormatDateTime(_Fecha_Inventario, DateFormat.LongDate)

        ExportarTabla_JetExcel(Consulta_sql, Me, NombreFile)

    End Sub

    Private Sub Btn_ExportarAjuste_Cerrados_Click(sender As Object, e As EventArgs) Handles Btn_ExportarAjuste_Cerrados.Click

        Consulta_sql = "select Codigo As 'Codigo',Cantidad As 'Cantidad',Costo as 'Costo'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_Inventario" & vbCrLf &
                       "Where IdInventario = " & _IdInventario & vbCrLf &
                       "And Cerrado = 1 And Cantidad > 0"

        Dim NombreFile As String = "Inventario SOLO CERRADOS " & FormatDateTime(_Fecha_Inventario, DateFormat.LongDate)

        ExportarTabla_JetExcel(Consulta_sql, Me, NombreFile)

    End Sub

    Private Sub Btn_ExportarAjuste_Click(sender As Object, e As EventArgs) Handles Btn_ExportarAjuste.Click
        ShowContextMenu(Menu_Contextual_ExportarAjuste)
    End Sub


End Class
