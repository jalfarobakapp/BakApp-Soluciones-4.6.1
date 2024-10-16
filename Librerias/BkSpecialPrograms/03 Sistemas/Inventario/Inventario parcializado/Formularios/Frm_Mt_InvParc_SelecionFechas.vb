Imports DevComponents.DotNetBar

Public Class Frm_Mt_InvParc_SelecionFechas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Empresa, _Sucursal, _Bodega As String
    Dim _RowBodega As DataRow

    Private _dv As New DataView

    Public Sub New(RowBodega As DataRow)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 9), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        _RowBodega = RowBodega

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Mt_InvParc_SelecionFechas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        _Empresa = _RowBodega.Item("EMPRESA")
        _Sucursal = _RowBodega.Item("KOSU")
        _Bodega = _RowBodega.Item("KOBO")

        LblEmpresa.Text = _RowBodega.Item("RAZON")
        LblSucursal.Text = _RowBodega.Item("NOKOSU")
        LblBodega.Text = _RowBodega.Item("NOKOBO")

        Sb_Actualizar_Grilla_Inventario()

        AddHandler Grilla.MouseDown, AddressOf Grilla_MouseDown
        AddHandler Grilla.CellDoubleClick, AddressOf Sb_Seleccionar_Inventario

        Btn_Actualizar_Foto_Stock.Visible = False

    End Sub

    Sub Sb_Actualizar_Grilla_Inventario()

        Consulta_sql = "Select Id,Ano,Mes,Dia,Fecha,Empresa,Sucursal,Bodega,Nombre_Ajuste,Funcionario,Estado," & vbCrLf &
                       "(Select COUNT(Distinct CodigoPr) From " & _Global_BaseBk & "Zw_TmpInv_InvParcial " &
                       "Where FechaInv = Fecha And DejaStockCero = 0) as 'Productos'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_TmpInv_InvParcial_Inventarios" & vbCrLf &
                       "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal &
                       "' And Bodega = '" & _Bodega & "'" & vbCrLf &
                       "Order by Fecha Desc"

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)
        _dv.Table = _Ds.Tables(0)

        _Ds.Tables(0).Columns("Productos").ReadOnly = False

        With Grilla

            .DataSource = _dv

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Fecha").Width = 80
            .Columns("Fecha").Visible = True
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            '.Columns("Empresa").Width = 40
            '.Columns("Empresa").HeaderText = "Emp"
            '.Columns("Empresa").Visible = True
            '.Columns("Empresa").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            '.Columns("Sucursal").Width = 40
            '.Columns("Sucursal").HeaderText = "Suc"
            '.Columns("Sucursal").Visible = True
            '.Columns("Sucursal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            '.Columns("Bodega").Width = 40
            '.Columns("Bodega").HeaderText = "Bod"
            '.Columns("Bodega").Visible = True
            '.Columns("Bodega").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Nombre_Ajuste").Width = 380
            .Columns("Nombre_Ajuste").HeaderText = "Descripción"
            .Columns("Nombre_Ajuste").Visible = True

            .Columns("Productos").Width = 70
            .Columns("Productos").HeaderText = "Productos"
            .Columns("Productos").Visible = True
            .Columns("Productos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End With

    End Sub


    Sub Sb_Seleccionar_Inventario()

        If Grilla.RowCount = 0 Then
            MessageBoxEx.Show(Me, "No hay datos que revisar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Fecha = Convert.ToDateTime(Convert.ToString(_Fila.Cells("Fecha").Value))
        Dim _Empresa As String = _Fila.Cells("Empresa").Value
        Dim _Sucursal As String = _Fila.Cells("Sucursal").Value
        Dim _Bodega As String = _Fila.Cells("Bodega").Value
        Dim _Estado As Boolean = _Fila.Cells("Estado").Value
        Dim _Nombre_Ajuste As String = _Fila.Cells("Nombre_Ajuste").Value

        If _Estado Then

            Dim _Nudo_GRI = Traer_Numero_Documento("GRI", , , False)
            Dim _Nudo_GDI = Traer_Numero_Documento("GDI", , , False)

            If String.IsNullOrEmpty(_Nudo_GRI) Or String.IsNullOrEmpty(_Nudo_GDI) Then

                MessageBoxEx.Show(Me, "Debe revisar la numeración para las guías de ajuste GRI o GDI." & vbCrLf &
                                  "Revise la numeración de la configuración de estación",
                                  "Problemas con numeración en guías internas", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Return
            End If

            Dim Fm As New Frm_Mt_InvParc_02_Seleccion(_Empresa, _Sucursal, _Bodega, _Fecha, False)
            Fm.Text = "AJUSTE DE INVENTARIO (" & _Nombre_Ajuste & ". Sucursal " & _Sucursal & ", Bodega " & _Bodega & ")"
            Fm.ShowDialog(Me)

            Dim _Cantidad As Integer = Fm.Pro_Cant_Productos
            _Fila.Cells("Productos").Value = _Cantidad
            Call TxtDescripcion_TextChanged(Nothing, Nothing)
            Fm.Dispose()
        Else
            MessageBoxEx.Show(Me, "Este ajuste se encuentra cerrado", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = CType(sender, DataGridView).Rows(CType(sender, DataGridView).CurrentRow.Index)
                    Dim _Cabeza = sender.Columns(CType(sender, DataGridView).CurrentCell.ColumnIndex).Name

                    ShowContextMenu(Menu_Contextual_Ajustes)
                End If
            End With
        End If

    End Sub

    Private Sub CrearNuevoInventarioToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Dim Fm As New Frm_Mt_InvParc_NuevoAjuste(_RowBodega)
        Fm.ShowInTaskbar = False
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub


    Private Sub BtnCrearNuevoInventario_Click(sender As System.Object, e As System.EventArgs) Handles BtnCrearNuevoInventario.Click
        Dim Fm As New Frm_Mt_InvParc_NuevoAjuste(_RowBodega)
        Fm.ShowDialog(Me)

        If Fm.Pro_Inventario_Creado Then
            Sb_Actualizar_Grilla_Inventario()
        End If

        Fm.Dispose()
    End Sub

    Private Sub Frm_Mt_InvParc_SelecionFechas_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_VerInventario_Click(sender As System.Object, e As System.EventArgs) Handles Btn_VerInventario.Click
        Sb_Seleccionar_Inventario()
    End Sub


    Private Sub Btn_Mnu_Ver_Ajuste_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Ver_Ajuste.Click
        Sb_Seleccionar_Inventario()
    End Sub

    Private Sub Btn_Mnu_Editar_Nombre_De_Ajuste_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Editar_Nombre_De_Ajuste.Click

        If Not Fx_Tiene_Permiso(Me, "Invp0005") Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id = _Fila.Cells("Id").Value
        Dim _Descripcion As String = _Fila.Cells("Nombre_Ajuste").Value
        Dim _Aceptado As Boolean

        _Aceptado = InputBox_Bk(Me, "Ingrese nueva descripción", "Cambiar descripción inventario",
                             _Descripcion, False,
                             _Tipo_Mayus_Minus.Mayusculas, 100, True, _Tipo_Imagen.Texto, False)

        If _Aceptado Then

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_TmpInv_InvParcial_Inventarios Set Nombre_Ajuste = '" & _Descripcion & "'" & vbCrLf &
                           "Where Id = " & _Id

            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                MessageBoxEx.Show(Me, "Descripcion cambiada correctamente",
                                  "Cambiar descripción", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _Fila.Cells("Nombre_Ajuste").Value = _Descripcion

            End If
        End If


    End Sub

    Private Sub Btn_Mnu_Eliminar_Ajuste_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Eliminar_Ajuste.Click

        Dim Fecha = Format(Grilla.Rows(Grilla.CurrentRow.Index).Cells("Fecha").Value, "yyyyMMdd")

        Dim Emp As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Empresa").Value
        Dim Suc As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Sucursal").Value
        Dim Bod As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Bodega").Value

        Dim Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_TmpInv_InvParcial",
                                              "Empresa = '" & Emp & "' And " &
                                              "Sucursal = '" & Suc & "' And " &
                                              "Bodega = '" & Bod & "' And " &
                                              "FechaInv = '" & Fecha & "'")
        If CBool(Reg) Then
            MessageBoxEx.Show(Me, "Existen productos ajustados para esta fecha." & vbCrLf &
                              "La fila no se puede eliminar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim dlg As System.Windows.Forms.DialogResult =
                      MessageBoxEx.Show(Me, "¿Esta seguro de eliminar la(s) fila(s) seleccionada(s)?",
                                       "Eliminar fila", MessageBoxButtons.YesNo)

        With Grilla
            If dlg = System.Windows.Forms.DialogResult.Yes Then

                Dim _Id As String = .Rows(.CurrentRow.Index).Cells("Id").Value
                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_TmpInv_InvParcial_Inventarios Where Id = " & _Id

                If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                    .Rows.RemoveAt(.CurrentRow.Index)
                End If

            End If
        End With

    End Sub

    Private Sub TxtDescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtDescripcion.TextChanged
        _dv.RowFilter = String.Format("Fecha+Nombre_Ajuste Like '%{0}%'", TxtDescripcion.Text)
    End Sub

    Private Sub Btn_Actualizar_Foto_Stock_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Actualizar_Foto_Stock.Click
        If Fx_Tiene_Permiso(Me, "In0030") Then
            Dim Fm As New Frm_Mt_InvParc_Actualizar_Foto_Stock(_Empresa, _Sucursal, _Bodega)
            If CBool(Fm.Pro_Tbl_Inventarios.Rows.Count) Then
                Fm.ShowDialog(Me)
            Else
                MessageBoxEx.Show(Me, "No existen inventarios que actualizar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Exportar_Inventarios_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Exportar_Inventarios.Click
        Consulta_sql = "Select Ano,Mes,Dia,Fecha,Empresa,Sucursal,Bodega,Nombre_Ajuste,Funcionario,Estado" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_TmpInv_InvParcial_Inventarios" & vbCrLf &
                       "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal &
                       "' And Bodega = '" & _Bodega & "'" & vbCrLf &
                       "Order by Fecha Desc"

        Dim _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Inventarios")
    End Sub

    Private Sub Btn_Exportar_Todo_Los_Productos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Exportar_Todo_Los_Productos.Click
        Consulta_sql = "Select *," &
                       "Isnull((Select Top 1 DATOSUBIC From TABBOPR" & Space(1) &
                       "Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR = CodigoPr),'') As UBICACION," &
                       "CAST(0 as Bit) As GDI_Cero_Nula," &
                       "CAST(0 as Bit) As GRI_Cero_Nula," &
                       "CAST(0 as Bit) As GRI_Ajuste_Nula" & vbCrLf &
                       "Into #Paso_Inv FROM " & _Global_BaseBk & "Zw_TmpInv_InvParcial" & vbCrLf &
                       "Where 1 > 0" & vbCrLf &
                       "And Levantado = 1" & vbCrLf &
                       "And DejaStockCero = 0" & vbCrLf &
                       "Order by CodigoPr,Semilla Desc" & vbCrLf & vbCrLf &
                       "Update #Paso_Inv Set StockActual = Isnull((Select Top 1 STFI1 From MAEST" & Space(1) &
                       "Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR = CodigoPr),0)" & vbCrLf &
                       "Update #Paso_Inv Set GRI_Cero_Nula = Case When (Select COUNT(*) From MAEEDO Where IDMAEEDO = GRI_Idmaeedo_Aj) > 0 then 0 Else 1 End" & vbCrLf &
                       "Update #Paso_Inv Set GDI_Cero_Nula = Case When (Select COUNT(*) From MAEEDO Where IDMAEEDO = GDI_Idmaeedo_Aj) > 0 then 0 Else 1 End" & vbCrLf &
                       "Update #Paso_Inv Set GRI_Ajuste_Nula = Case When (Select COUNT(*) From MAEEDO Where IDMAEEDO = IDMAEEDO_Aj) > 0 then 0 Else 1 End" & vbCrLf &
                       "Select * From #Paso_Inv" & vbCrLf &
                       "Order by CodigoPr,Semilla Desc" & vbCrLf &
                       "Drop Table #Paso_Inv"

        Dim _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Inventario_Detalle")

    End Sub

    Private Sub Btn_Exportar_Productos_No_Inventariados_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Exportar_Productos_No_Inventariados.Click

        Consulta_sql = "Select KOPR As CODIGO,NOKOPR As DESCRIPCION,RLUD As RTU,UD01PR As UN1," &
                       "Cast(0 As Float) StockUd1,UD02PR As UN2,Cast(0 As Float) StockUd2,MRPR AS MARCA" & vbCrLf &
                       "Into #Paso1" & vbCrLf &
                       "From MAEPR" & vbCrLf &
                       "Where KOPR Not in (Select CodigoPr From " & _Global_BaseBk & "Zw_TmpInv_InvParcial" & Space(1) &
                       "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "')" & vbCrLf &
                       "Update #Paso1 Set StockUd1 = Isnull((Select STFI1 From MAEST Where EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sucursal & "' AND KOBO = '" & _Bodega & "' And CODIGO = KOPR),0)" & vbCrLf &
                       "Update #Paso1 Set StockUd2 = Isnull((Select STFI2 From MAEST Where EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sucursal & "' AND KOBO = '" & _Bodega & "' And CODIGO = KOPR),0)" & vbCrLf &
                       "Select * From #Paso1" & vbCrLf &
                       "Drop Table #Paso1"

        Dim _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Prod_Sin_Inventariar")

    End Sub

    Private Sub Btn_Exportar_Excel_Detalle_Inv_Seleccionado_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Exportar_Excel_Detalle_Inv_Seleccionado.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Fecha As Date = _Fila.Cells("Fecha").Value

        Consulta_sql = "Select *," &
                       "CAST(0 as Bit) As GDI_Cero_Nula," &
                       "CAST(0 as Bit) As GRI_Cero_Nula," &
                       "CAST(0 as Bit) As GRI_Ajuste_Nula" & vbCrLf &
                       "Into #Paso_Inv FROM " & _Global_BaseBk & "Zw_TmpInv_InvParcial" & vbCrLf &
                       "Where FechaInv = '" & Format(_Fecha, "yyyyMMdd") & "'" & vbCrLf &
                       "And Levantado = 1" & vbCrLf &
                       "And DejaStockCero = 0" & vbCrLf &
                       "Order by CodigoPr,Semilla Desc" & vbCrLf & vbCrLf &
                       "Update #Paso_Inv Set StockActual = Isnull((Select Top 1 STFI1 From MAEST" & Space(1) &
                       "Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR = CodigoPr),0)" & vbCrLf &
                       "Update #Paso_Inv Set GRI_Cero_Nula = Case When (Select COUNT(*) From MAEEDO Where IDMAEEDO = GRI_Idmaeedo_Aj) > 0 then 0 Else 1 End" & vbCrLf &
                       "Update #Paso_Inv Set GDI_Cero_Nula = Case When (Select COUNT(*) From MAEEDO Where IDMAEEDO = GDI_Idmaeedo_Aj) > 0 then 0 Else 1 End" & vbCrLf &
                       "Update #Paso_Inv Set GRI_Ajuste_Nula = Case When (Select COUNT(*) From MAEEDO Where IDMAEEDO = IDMAEEDO_Aj) > 0 then 0 Else 1 End" & vbCrLf &
                       "Select * From #Paso_Inv" & vbCrLf &
                       "Order by CodigoPr,Semilla Desc" & vbCrLf &
                       "Drop Table #Paso_Inv"

        Dim _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Inv_Detalle_" & Format(_Fecha, "yyyyMMdd"))
    End Sub
End Class
