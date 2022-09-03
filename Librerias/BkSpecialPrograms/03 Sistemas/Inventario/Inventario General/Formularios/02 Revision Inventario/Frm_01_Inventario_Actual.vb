Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc
'Imports BkSpecialPrograms

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Frm_01_Inventario_Actual

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Public IdBodega As String
    Dim Ds_Inventario As New DsInventario_Gral

    Public _IdInventario_Activo As Integer
    Public _Fecha_Inv_Activo As Date
    Public _Empresa_Inv_Activo As String
    Public _Sucursal_Inv_Activo As String
    Public _Bodega_Inv_Activo As String

    Dim _CodSectorSel As String

    Dim _CODIGO_BUSQUEDA As String


    Private Sub ActualizarGrillaFoto(ByVal IdBodega As String, _
                                     ByVal _Codigo_busqueda As String)

        Grilla.DataSource = Nothing
        Ds_Inventario.Clear()

        Dim Filtrar As String = ""

        Try

            Dim Pie As String
            Dim Tbl_Paso As String = "_Tbl" & FUNCIONARIO
            Dim Tbl_Paso_2 As String = "ZW_TmpInvPs01" & FUNCIONARIO

            Consulta_sql = "DROP TABLE " & Tbl_Paso_2
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

            Consulta_sql = "Drop Table " & Tbl_Paso
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

            Consulta_sql = My.Resources._Procedimientos_Inv.Inv_Sumar_Cantidades

            Consulta_sql = Replace(Consulta_sql, "@Funcionario", FUNCIONARIO)
            'Consulta_sql = Replace(Consulta_sql, "@Codigo", Codigo_abuscar)
            'Consulta_sql = Replace(Consulta_sql, "@IdBodega", IdBodega)
            'Consulta_sql = Replace(Consulta_sql, "@Ano", Inventario_AnoActivo)
            'Consulta_sql = Replace(Consulta_sql, "@Mes", Inventario_MesActivo)
            'Consulta_sql = Replace(Consulta_sql, "@Dia", inventario_DiaActivo)

            Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa_Inv_Activo)
            Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _Sucursal_Inv_Activo)
            Consulta_sql = Replace(Consulta_sql, "#Bodega#", _Bodega_Inv_Activo)
            Consulta_sql = Replace(Consulta_sql, "#FechaInv#", Format(_Fecha_Inv_Activo, "yyyyMMdd"))
             _Sql.Ej_consulta_IDU(Consulta_Sql)


            Consulta_sql = My.Resources._Procedimientos_Inv.Inv_Invetario_Todos

            'Consulta_sql = Replace(Consulta_sql, "@Top", "")
            Consulta_sql = Replace(Consulta_sql, "@Funcionario", FUNCIONARIO)
            'Consulta_sql = Replace(Consulta_sql, "@Codigo", Codigo_abuscar)
            'Consulta_sql = Replace(Consulta_sql, "@IdBodega", IdBodega)
            'Consulta_sql = Replace(Consulta_sql, "@Ano", Inventario_AnoActivo)
            'Consulta_sql = Replace(Consulta_sql, "@Mes", Inventario_MesActivo)
            'Consulta_sql = Replace(Consulta_sql, "@Dia", inventario_DiaActivo)

            Consulta_sql = Replace(Consulta_sql, "#IdInventario#", _IdInventario_Activo)

            'Consulta_sql = Replace(Consulta_sql, "#FechaInv#", Format(_Fecha_Inv_Activo, "yyyyMMdd"))
            Consulta_sql = Replace(Consulta_sql, "#TablaPaso_2#", Tbl_Paso_2)
            Consulta_sql = Replace(Consulta_sql, "#TablaPaso#", Tbl_Paso)

             _Sql.Ej_consulta_IDU(Consulta_Sql)

            Dim Filtro_Sector As String = String.Empty

            If Not ChkTodosLosSectores.Checked Then

                If Not String.IsNullOrEmpty(Trim(_CodSectorSel)) Then
                    Filtro_Sector = "And CodigoPR in (Select distinct Codproducto" & vbCrLf & _
                                    "From ZW_TmpInvProductosInventariados" & vbCrLf & _
                                    "Where IdInventario = " & _IdInventario_Activo & _
                                    " And CodSectorInt = '" & _CodSectorSel & "')"
                End If
            End If

            Dim Filtro_Codigo As String

            If String.IsNullOrEmpty(Trim(_Codigo_busqueda)) Then
                Filtro_Codigo = String.Empty
            Else
                Filtro_Codigo = "And CodigoPR >= '" & _Codigo_busqueda & "'"
            End If


            If ChkMostrarSoloInv.Checked Then
                Consulta_sql = "Select * From ZW_TmpInvFotoInventario" & vbCrLf & _
                               "Where IdInventario = " & _IdInventario_Activo & vbCrLf & _
                               Filtro_Sector & vbCrLf & _
                               Filtro_Codigo & vbCrLf & _
                               "And Cant_Inventariada > 0" & vbCrLf & _
                               "Order By CodigoPR"
            Else
                Consulta_sql = "Select top 200 * From ZW_TmpInvFotoInventario" & vbCrLf & _
                          "Where IdInventario = " & _IdInventario_Activo & vbCrLf & _
                          Filtro_Sector & vbCrLf & _
                          Filtro_Codigo & vbCrLf & _
                          "Order By CodigoPR"
            End If
           

            '"Where IdBodega = " & IdBodega & _
            '" And Ano = '" & Inventario_AnoActivo & _
            '"' And Mes = '" & Inventario_MesActivo & _
            '"' And Dia = '" & inventario_DiaActivo & "'" & vbCrLf & _
            '"Order By CodigoPR"

            With Grilla
                .DataSource = _SQL.Fx_Get_Tablas(Consulta_sql) ' Nothing

                OcultarEncabezadoGrilla(Grilla)

                .Columns("CodigoPR").Width = 70
                .Columns("CodigoPR").HeaderText = "Código"
                .Columns("CodigoPR").Visible = True

                .Columns("DescripcionPR").Width = 300
                .Columns("DescripcionPR").HeaderText = "Descripción"
                .Columns("DescripcionPR").Visible = True

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

                .Columns("ReLevantado").HeaderText = "[Lr]"
                .Columns("ReLevantado").Width = 30
                .Columns("ReLevantado").Visible = True


                .Columns("PPP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("PPP").DefaultCellStyle.Format = "$ ###,##.##"
                .Columns("PPP").HeaderText = "PM"
                .Columns("PPP").Width = 60
                .Columns("PPP").Visible = True

                .Columns("Dif_Inv_Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Dif_Inv_Cantidad").DefaultCellStyle.Format = "###,##.##"
                .Columns("Dif_Inv_Cantidad").HeaderText = "Dif. Inv."
                .Columns("Dif_Inv_Cantidad").Width = 70
                .Columns("Dif_Inv_Cantidad").Visible = True

                .Columns("Total_Costo_Foto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Total_Costo_Foto").DefaultCellStyle.Format = "$ ###,##.##"
                .Columns("Total_Costo_Foto").HeaderText = "Total Foto $"
                .Columns("Total_Costo_Foto").Width = 70
                .Columns("Total_Costo_Foto").Visible = True

                .Columns("Total_Costo_Inv").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Total_Costo_Inv").DefaultCellStyle.Format = "$ ###,##.##"
                .Columns("Total_Costo_Inv").HeaderText = "Total Inv. $"
                .Columns("Total_Costo_Inv").Width = 70
                .Columns("Total_Costo_Inv").Visible = True


                .Columns("Dif_Inv_Costo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Dif_Inv_Costo").DefaultCellStyle.Format = "$ ###,##"
                .Columns("Dif_Inv_Costo").HeaderText = "Dif. $"
                .Columns("Dif_Inv_Costo").Width = 70
                .Columns("Dif_Inv_Costo").Visible = True


            End With


            Dim _Total_Inventario As Double = Fx_Suma_cantidades("Total_Costo_Inv", "ZW_TmpInvFotoInventario",
                                                        "IdInventario = " & _IdInventario_Activo, 5)

            Dim _Total_Foto As Double = Fx_Suma_cantidades("Total_Costo_Foto", "ZW_TmpInvFotoInventario",
                                                        "IdInventario = " & _IdInventario_Activo, 5)

            Dim _Total_Diferencia As Double = _Total_Inventario - _Total_Foto '_Sql.Fx_Trae_Dato(, "Sum(Dif_Inv_Costo)", Tbl_Paso)
            'LblTotal_Inventario.Text = 

            LblTotal_FotoStock.Text = FormatCurrency(_Total_Foto, 0)
            LblTotal_Inventario.Text = FormatCurrency(_Total_Inventario, 0)
            LblTotal_Diferencia.Text = FormatCurrency(_Total_Diferencia, 0)

            If _Total_Diferencia < 0 Then
                LblTotal_Diferencia.ForeColor = Color.Red
            Else
                LblTotal_Diferencia.ForeColor = Color.Green
            End If

            Consulta_sql = "DROP TABLE " & Tbl_Paso_2
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

            Consulta_sql = "Drop Table " & Tbl_Paso
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Frm_Inventario_Actual_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ActualizarGrillaFoto(IdBodega, "")
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
       Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 7), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        _CODIGO_BUSQUEDA = String.Empty
        ActualizarGrillaFoto(IdBodega, _CODIGO_BUSQUEDA)
    End Sub

    Private Sub UltimodMovimientosCompraYVentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltimodMovimientosCompraYVentasToolStripMenuItem.Click

        Dim _Codigo = Grilla.Rows(Grilla.CurrentRow.Index).Cells("CodigoPR").Value
        Dim Fm As New Frm_EstadisticaProducto(_Codigo)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grilla.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If

            End With
        End If
    End Sub

    Private Sub DetalleDelCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetalleDelCToolStripMenuItem.Click
        Ver_Detalle_Del_Producto()
    End Sub


    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        Consulta_sql = "Select * From ZW_TmpInvFotoInventario" & vbCrLf & _
                        "Where IdInventario = " & _IdInventario_Activo

        'Dim Tbl_Excel As DataTable = Ds_Inventario.Tables(5)
        ExportarTabla_JetExcel(Consulta_sql, Me, "Inventario")

    End Sub



    Sub Buscar_Producto()
        Codigo_abuscar = String.Empty
        Dim Frm_BuscarPr As New Frm_BuscarXProducto_Mt
        Frm_BuscarPr.ShowDialog(Me)
        Dim Codigo = Frm_BuscarPr.CodProducto_Sel

        If String.IsNullOrEmpty(Trim(Codigo_abuscar)) Then Return

        _CODIGO_BUSQUEDA = Trim(Codigo_abuscar)
        ActualizarGrillaFoto(IdBodega, _CODIGO_BUSQUEDA)

        If BuscarDatoEnGrilla(Trim(Codigo), "CodigoPR", Grilla) Then

            Dim dlg As System.Windows.Forms.DialogResult = _
            MessageBoxEx.Show(Me, "¿Desea ver el detalle del producto?", _
                              "Cerrar Sistema", MessageBoxButtons.YesNo)
            Grilla.Focus()

            If dlg = System.Windows.Forms.DialogResult.No Then
                Return
            End If

            Ver_Detalle_Del_Producto()
        End If
        Exit Sub

        Dim ContarPrEnFoto As Long
        ContarPrEnFoto =_Sql.Fx_Cuenta_Registros("ZW_TmpInvFotoInventario", "CodigoPR = '" & Codigo & "'")

        If ContarPrEnFoto > 0 Then

            If BuscarDatoEnGrilla(Trim(Codigo), "CodigoPR", Grilla) = True Then
                Grilla.Focus()
            End If

        Else
            MsgBox("El producto no se encuentra en la ubicación seleccionada", MsgBoxStyle.Exclamation, "Buscar producto")
            Codigo_abuscar = ""
            Return
        End If

    End Sub

    Private Sub BtnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarProducto.Click
        Buscar_Producto()
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        Ver_Detalle_Del_Producto()
    End Sub


    Sub Ver_Detalle_Del_Producto()

        With Grilla

            Dim Codigo As String = Trim(.Rows(.CurrentRow.Index).Cells("CodigoPR").Value)
            Dim Descripcion As String = Trim(.Rows(.CurrentRow.Index).Cells("DescripcionPR").Value)

            Dim FStock_Ud1 As Double = .Rows(.CurrentRow.Index).Cells("StFisicoUd1").Value
            Dim Cantidad_Inv As Double = .Rows(.CurrentRow.Index).Cells("Cant_Inventariada").Value
            Dim Dif_Inv_Cantidad As Double = .Rows(.CurrentRow.Index).Cells("Dif_Inv_Cantidad").Value

            Dim _Cerrado As Boolean = .Rows(.CurrentRow.Index).Cells("Cerrado").Value
            Dim _Recontado As Boolean = .Rows(.CurrentRow.Index).Cells("Recontado").Value
            Dim _Levantado As Boolean = .Rows(.CurrentRow.Index).Cells("Levantado").Value

            Dim Fm As New Frm_02_Detalle_Producto_Actual

            Fm._IdInventario = _IdInventario_Activo
            Fm._Codigo = Codigo
            Fm._Descripcion = Descripcion
            Fm._FStock_Ud1 = FStock_Ud1
            Fm._Cantidad_Inv = Cantidad_Inv
            Fm._Dif_Inv_Cantidad = Dif_Inv_Cantidad
            Fm.Text = "Producto: " & Codigo & " - " & Descripcion
            Fm.ChkCerrado.Checked = _Cerrado
            Fm.ChkLevantado.Checked = _Levantado
            Fm.ChkRecontado.Checked = _Recontado

            Fm._FechaInv = _Fecha_Inv_Activo
            Fm._Empresa = _Empresa_Inv_Activo
            Fm._Sucursal = _Sucursal_Inv_Activo
            Fm._Bodega = _Bodega_Inv_Activo

            Fm.ShowDialog(Me)

            If Fm._Recontado Then
                .Rows(.CurrentRow.Index).Cells("Cerrado").Value = Fm.ChkCerrado.Checked
                .Rows(.CurrentRow.Index).Cells("Recontado").Value = Fm.ChkRecontado.Checked
                .Rows(.CurrentRow.Index).Cells("Levantado").Value = Fm.ChkLevantado.Checked
            End If

        End With



    End Sub



    Private Sub BtnCerrarSinDiferencias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrarSinDiferencias.Click

        Dim _Condicion As String = "IdInventario = " & _IdInventario_Activo & vbCrLf & _
                                   "And Diferencia = ''" & vbCrLf & _
                                   "And Recontado = 0" & vbCrLf & _
                                   "And Levantado = 0"

        Dim Reg As Integer =_Sql.Fx_Cuenta_Registros("ZW_TmpInvFotoInventario", _Condicion)

        If Reg > 0 Then
            Consulta_sql = "Update ZW_TmpInvFotoInventario Set Cerrado = 1 " & vbCrLf & _
                           "Where " & vbCrLf & _Condicion

            If  _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                MessageBoxEx.Show("Productos cerrados " & Reg, "Cerrar", _
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            _CODIGO_BUSQUEDA = String.Empty
            ActualizarGrillaFoto(IdBodega, _CODIGO_BUSQUEDA)
        Else
            MessageBoxEx.Show("No existen productos que marcar", "Cerrar", _
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub


    Private Sub BtnLevantados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLevantados.Click


        Dim _Condicion As String = "IdInventario = " & _IdInventario_Activo & vbCrLf & _
                                   "And Cerrado = 1" & vbCrLf & _
                                   "And Levantado = 0"

        Dim Reg As Integer =_Sql.Fx_Cuenta_Registros("ZW_TmpInvFotoInventario", _Condicion)

        If Reg > 0 Then
            Consulta_sql = "Update ZW_TmpInvFotoInventario Set Levantado = 1 " & vbCrLf & _
                           "Where " & vbCrLf & _Condicion

            If  _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                MessageBoxEx.Show("Productos Levantados " & Reg, "Marcar Levantados", _
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            ActualizarGrillaFoto(IdBodega, _CODIGO_BUSQUEDA)
        Else
            MessageBoxEx.Show("No existen productos que marcar", "Marcar Levantados", _
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnMarcarLevantadosInventariados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrarInventariados.Click

        Dim _Condicion As String = "IdInventario = " & _IdInventario_Activo & vbCrLf & _
                                   "And Cant_Inventariada > 0" & vbCrLf & _
                                   "And Cerrado = 0"

        Dim Reg As Integer =_Sql.Fx_Cuenta_Registros("ZW_TmpInvFotoInventario", _Condicion)

        If Reg > 0 Then
            Consulta_sql = "Update ZW_TmpInvFotoInventario Set Cerrado = 1 " & vbCrLf & _
                           "Where " & vbCrLf & _Condicion

            If  _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                MessageBoxEx.Show("Productos Levantados " & Reg, "Marcar Levantados", _
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            _CODIGO_BUSQUEDA = String.Empty
            ActualizarGrillaFoto(IdBodega, _CODIGO_BUSQUEDA)
        Else
            MessageBoxEx.Show("No existen productos que marcar", "Marcar Levantados", _
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    

    Private Sub ButtonItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExporAjuTodos.Click
        Consulta_sql = "select CodigoPR as 'Codigo',Cant_Inventariada as 'Cantidad',PPP as 'Costo'" & vbCrLf & _
                      "From ZW_TmpInvFotoInventario" & vbCrLf & _
                      "Where IdInventario = " & _IdInventario_Activo

        Dim NombreFile As String = "Inventario TODOS " & FormatDateTime(_Fecha_Inv_Activo, DateFormat.LongDate)

        ExportarTabla_JetExcel(Consulta_sql, Me, NombreFile)

    End Sub

    Private Sub ButtonItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExporAjuCerrados.Click
        Consulta_sql = "select CodigoPR as 'Codigo',Cant_Inventariada as 'Cantidad',PPP as 'Costo'" & vbCrLf & _
                       "From ZW_TmpInvFotoInventario" & vbCrLf & _
                       "Where IdInventario = " & _IdInventario_Activo & vbCrLf & _
                       "And Cerrado = 1 and Cant_Inventariada > 0"

        Dim NombreFile As String = "Inventario SOLO CERRADOS " & FormatDateTime(_Fecha_Inv_Activo, DateFormat.LongDate)

        ExportarTabla_JetExcel(Consulta_sql, Me, NombreFile)
    End Sub

    Private Sub BtnFiltroSectores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltroSectores.Click
        Dim Fm As New Frm_03_Sectores_Inv

        Fm._IngresarHoja = True
        Fm._Empresa = _Empresa_Inv_Activo
        Fm._Sucursal = _Sucursal_Inv_Activo
        Fm._Bodega = _Bodega_Inv_Activo
        Fm._IdInventario = _IdInventario_Activo
        Fm.Grilla_Inv.ContextMenuStrip = Nothing
        Fm._ValidaEstado = False

        Fm.ShowDialog(Me)
        _CodSectorSel = Fm.Sector

        If Not String.IsNullOrEmpty(Trim(_CodSectorSel)) Then
            _CODIGO_BUSQUEDA = String.Empty
            ActualizarGrillaFoto(IdBodega, _CODIGO_BUSQUEDA)
        Else
            MessageBoxEx.Show("No se selecciono ningun sector", "Filtrar por sector", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub ChkTodosLosSectores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTodosLosSectores.Click

        If ChkTodosLosSectores.Checked Then
            BtnFiltroSectores.Enabled = False
        Else
            BtnFiltroSectores.Enabled = True
        End If

    End Sub

    Private Sub ButtonItem2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem2.Click
        Dim Fm As New Frm_05_Filtrar_FMRCZ
        Fm._IdInventario = _IdInventario_Activo
        Fm.ShowDialog(Me)
    End Sub

    Private Sub BtnCerrarTodosInvCero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrarTodosInvCero.Click
        MessageBoxEx.Show(Me, "En Construcción")
    End Sub
End Class