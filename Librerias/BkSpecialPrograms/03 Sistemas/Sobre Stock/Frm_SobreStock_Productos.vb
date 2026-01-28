Imports DevComponents.DotNetBar

Public Class Frm_SobreStock_Productos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Empresa As String = Mod_Empresa

    Public Property Seleccionado As Boolean
    Public Property ModoSeleccion As Boolean
    Public Property ModoSoloLectrura As Boolean
    Public Property Zw_Prod_SobreStock As New Zw_Prod_SobreStock
    Public Property Ls_ListaProductos As New List(Of String)
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Color_Botones_Barra(Bar1)


    End Sub

    Private Sub Frm_SobreStock_Productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        Btn_AgregarProducto.Visible = Not ModoSeleccion

        'If ModoSoloLectrura Then
        '    Btn_AgregarProducto.Visible = False
        'End If

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String = String.Empty

        Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(Txt_Filtrar.Text.Trim), "Sbs.Codigo+Sbs.Descripcion Like '%")

        Consulta_sql = $"
Select Sbs.*,Sbs.PqteComprometido - Sbs.PqteDevuelto As PqteComprometido2,
Sbs.PqteHabilitado+Sbs.PqteDevuelto-(Sbs.PqteComprometido+Sbs.PqteComprometidoSol) As 'PqteDisponible'
From {_Global_BaseBk}Zw_Prod_SobreStock Sbs
Where Sbs.Empresa = '{_Empresa}' And Sbs.Eliminado = 0
And Sbs.Codigo+Sbs.Descripcion Like '%{_Cadena}%'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _DisplayIndex = 0

        With Grilla

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Empresa").Width = 30
            .Columns("Empresa").HeaderText = "Emp"
            .Columns("Empresa").Visible = True
            .Columns("Empresa").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Width = 310
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Moneda").Width = 30
            .Columns("Moneda").HeaderText = "M."
            .Columns("Moneda").Visible = True
            .Columns("Moneda").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PrecioXUd1").Width = 70
            .Columns("PrecioXUd1").HeaderText = "Precio"
            .Columns("PrecioXUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PrecioXUd1").DefaultCellStyle.Format = "##,###0.##"
            .Columns("PrecioXUd1").Visible = True
            .Columns("PrecioXUd1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            'If Not ModoSeleccion Then

            '    .Columns("StSobStockUd1").Width = 70
            '    .Columns("StSobStockUd1").HeaderText = "Disponible Ud1"
            '    .Columns("StSobStockUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '    .Columns("StSobStockUd1").DefaultCellStyle.Format = "##,###0.##"
            '    .Columns("StSobStockUd1").Visible = True
            '    .Columns("StSobStockUd1").DisplayIndex = _DisplayIndex
            '    _DisplayIndex += 1

            'End If

            .Columns("FormatoPqte").Width = 70
            .Columns("FormatoPqte").HeaderText = "Form.Vnta"
            .Columns("FormatoPqte").Visible = True
            .Columns("FormatoPqte").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Ud1XPqte").Width = 60
            .Columns("Ud1XPqte").HeaderText = "Ud1XPallet"
            .Columns("Ud1XPqte").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Ud1XPqte").DefaultCellStyle.Format = "##,###0.##"
            .Columns("Ud1XPqte").Visible = True
            .Columns("Ud1XPqte").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantMinFormato").Width = 70
            .Columns("CantMinFormato").HeaderText = "Cant.Min.Vta"
            .Columns("CantMinFormato").ToolTipText = "Cantidad Mínima de venta por Pallet."
            .Columns("CantMinFormato").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantMinFormato").DefaultCellStyle.Format = "##,###0.##"
            .Columns("CantMinFormato").Visible = True
            .Columns("CantMinFormato").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PqteHabilitado").Width = 70
            .Columns("PqteHabilitado").HeaderText = "Habilitado"
            .Columns("PqteHabilitado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PqteHabilitado").DefaultCellStyle.Format = "##,###0.##"
            .Columns("PqteHabilitado").Visible = True
            .Columns("PqteHabilitado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PqteComprometido2").Width = 70
            .Columns("PqteComprometido2").HeaderText = "Comprom. Venta"
            .Columns("PqteComprometido2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PqteComprometido2").DefaultCellStyle.Format = "##,###0.##"
            .Columns("PqteComprometido2").Visible = True
            .Columns("PqteComprometido2").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PqteComprometidoSol").Width = 70
            .Columns("PqteComprometidoSol").HeaderText = "Comprom. SOL"
            .Columns("PqteComprometidoSol").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PqteComprometidoSol").DefaultCellStyle.Format = "##,###0.##"
            .Columns("PqteComprometidoSol").Visible = True
            .Columns("PqteComprometidoSol").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PqteDisponible").Width = 70
            .Columns("PqteDisponible").HeaderText = "Disponible"
            .Columns("PqteDisponible").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PqteDisponible").DefaultCellStyle.Format = "##,###0.##"
            .Columns("PqteDisponible").Visible = True
            .Columns("PqteDisponible").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_AgregarProducto_Click(sender As Object, e As EventArgs) Handles Btn_AgregarProducto.Click

        Dim _RowProducto As DataRow

        Dim Fm_Prod As New Frm_BkpPostBusquedaEspecial_Mt
        Fm_Prod.Pro_Tipo_Lista = "P"
        Fm_Prod.Pro_Lista_Busqueda = Mod_ListaPrecioVenta
        Fm_Prod.Pro_CodEntidad = String.Empty
        Fm_Prod.Pro_Mostrar_Info = True
        Fm_Prod.BtnCrearProductos.Visible = False
        Fm_Prod.Txtdescripcion.Text = String.Empty
        Fm_Prod.BtnExportaExcel.Visible = False
        Fm_Prod.Pro_Actualizar_Precios = False
        Fm_Prod.ShowDialog(Me)
        _RowProducto = Fm_Prod.Pro_RowProducto
        Fm_Prod.Dispose()

        If IsNothing(_RowProducto) Then
            Return
        End If

        'Dim _Row_Bodega As DataRow = Fx_Seleccionar_Bodega()

        'If IsNothing(_Row_Bodega) Then
        '    Return
        'End If

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_SobreStock",
                                                        "Empresa = '" & Mod_Empresa & "' And " &
                                                        "Codigo = '" & _RowProducto.Item("KOPR") & "' And " &
                                                        "Activo = 1 And Eliminado = 0")

        If _Reg > 0 Then
            MessageBoxEx.Show(Me, "El producto ya se encuentra ingresado en la bodega seleccionada", "Validación",
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
                       "Left Join " & _Global_BaseBk & " Zw_Prod_Stock St On St.Empresa = Ms.EMPRESA And St.Sucursal = Ms.KOSU And St.Bodega = Ms.KOBO And St.Codigo = Ms.KOPR" & vbCrLf &
                       "Where Ms.EMPRESA = '" & Mod_Empresa & "' And Ms.KOPR = '" & _RowProducto.Item("KOPR") & "'" & vbCrLf &
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
            .Codigo = _RowProducto.Item("KOPR")
            .Descripcion = _RowProducto.Item("NOKOPR")
            .CantMinFormato = 0
            .FormatoPqte = "Pallet"
            .StDispUd1 = _Row_Stock.Item("StDispUd1")
            .PqteHabilitado = 0
            .Ud1XPqte = 1
            .CantMinFormato = 0
            .Moneda = String.Empty
            .PrecioXUd1 = 0

        End With

        Dim _Grabar As Boolean

        Dim Fm As New Frm_SobreStock_IngDet(_Zw_Prod_SobreStock)
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

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        If ModoSeleccion Then

            Dim _Fila As DataGridViewRow = Grilla.CurrentRow

            If IsNothing(_Fila) Then
                Return
            End If

            Dim _Codigo As String = String.Empty

            Try
                If Not IsNothing(_Fila.Cells("Codigo").Value) Then
                    _Codigo = _Fila.Cells("Codigo").Value.ToString().Trim()
                End If
            Catch ex As Exception
                _Codigo = String.Empty
            End Try

            ' Comprobar si el código ya está en la lista de productos seleccionados (insensible a mayúsculas)
            If Not String.IsNullOrEmpty(_Codigo) AndAlso Ls_ListaProductos.Exists(Function(x) String.Equals(x, _Codigo, StringComparison.OrdinalIgnoreCase)) Then
                MessageBoxEx.Show(Me,
                                  "No se puede seleccionar el producto '" & _Codigo & "' - " & _Fila.Cells("Descripcion").Value & vbCrLf &
                                  "porque ya está en la lista de selección para la creación del documento.",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            With Zw_Prod_SobreStock

                .Id = _Fila.Cells("Id").Value
                .Empresa = _Fila.Cells("Empresa").Value
                .Codigo = _Fila.Cells("Codigo").Value
                .Descripcion = _Fila.Cells("Descripcion").Value
                .Activo = _Fila.Cells("Activo").Value
                .CodFuncionarioCrea = _Fila.Cells("CodFuncionarioCrea").Value
                .FechaVigencia = _Fila.Cells("FechaVigencia").Value
                .FormatoPqte = _Fila.Cells("FormatoPqte").Value
                .PqteHabilitado = _Fila.Cells("PqteHabilitado").Value
                .PqteComprometido = _Fila.Cells("PqteComprometido").Value
                .PqteComprometidoSol = _Fila.Cells("PqteComprometidoSol").Value
                .PqteDevuelto = _Fila.Cells("PqteDevuelto").Value
                .Ud1XPqte = _Fila.Cells("Ud1XPqte").Value
                .CantMinFormato = _Fila.Cells("CantMinFormato").Value
                .Moneda = _Fila.Cells("Moneda").Value
                .PrecioXUd1 = _Fila.Cells("PrecioXUd1").Value
                .Precio_DigSobreStock = _Fila.Cells("PrecioXUd1").Value
                '.StSobStockUd1 = _Fila.Cells("StSobStockUd1").Value
                '.StSobStockUd2 = _Fila.Cells("StSobStockUd2").Value
                '.StSbCompStock1 = _Fila.Cells("StSbCompStock1").Value
                '.StSbCompStock2 = _Fila.Cells("StSbCompStock2").Value
                '.StDispUd1 = _Fila.Cells("StSobStockUd1").Value - _Fila.Cells("StSbCompStock1").Value

            End With

            Seleccionado = True

            Me.Close()

        End If

    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call Grilla_CellDoubleClick(Nothing, Nothing)
            ' Evitar el sonido por defecto y que la tecla se propague
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    Btn_Eliminar.Visible = Not ModoSeleccion
                    ShowContextMenu(Menu_Contextual_01)
                End If
            End With
        End If
    End Sub

    Private Sub Txt_Filtrar_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Filtrar.KeyDown
        If e.KeyValue = Keys.Space Or e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Txt_Filtrar_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Filtrar.ButtonCustom2Click
        Txt_Filtrar.Text = String.Empty
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        Dim _Rows_Usuario_Autoriza As DataRow = Nothing
        Dim _CodFuncionario_Elimina As String = FUNCIONARIO

        If Not Fx_Tiene_Permiso(Me, "Sobs0004",,,,,,,,, _Rows_Usuario_Autoriza) Then
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Está seguro de eliminar el producto seleccionado para sobre stock?", "Eliminar producto",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim _Cl_SobreStock As New Cl_SobreStock
        Dim _Mensaje As LsValiciones.Mensajes

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        With Zw_Prod_SobreStock

            .Id = _Fila.Cells("Id").Value
            .Empresa = _Fila.Cells("Empresa").Value
            .Codigo = _Fila.Cells("Codigo").Value
            .Descripcion = _Fila.Cells("Descripcion").Value
            .Activo = _Fila.Cells("Activo").Value
            .CodFuncionarioCrea = _Fila.Cells("CodFuncionarioCrea").Value
            .FechaVigencia = _Fila.Cells("FechaVigencia").Value
            .FormatoPqte = _Fila.Cells("FormatoPqte").Value
            .PqteHabilitado = _Fila.Cells("PqteHabilitado").Value
            .PqteComprometido = _Fila.Cells("PqteComprometido").Value
            .PqteComprometidoSol = _Fila.Cells("PqteComprometidoSol").Value
            .PqteDevuelto = _Fila.Cells("PqteDevuelto").Value
            .Ud1XPqte = _Fila.Cells("Ud1XPqte").Value
            .CantMinFormato = _Fila.Cells("CantMinFormato").Value
            .Moneda = _Fila.Cells("Moneda").Value
            .PrecioXUd1 = _Fila.Cells("PrecioXUd1").Value
            .Precio_DigSobreStock = _Fila.Cells("PrecioXUd1").Value

        End With

        If Not IsNothing(_Rows_Usuario_Autoriza) Then
            _CodFuncionario_Elimina = _Rows_Usuario_Autoriza.Item("KOFU").ToString.Trim
        End If

        _Mensaje = _Cl_SobreStock.Fx_Eliminar_SobreStock(_Zw_Prod_SobreStock, _CodFuncionario_Elimina)

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Validación", MessageBoxButtons.OK, _Mensaje.Icono)
        If Not _Mensaje.EsCorrecto Then
            Return
        End If

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Btn_Copiar_Click(sender As Object, e As EventArgs) Handles Btn_Copiar.Click
        With Grilla

            Dim _Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
            Dim _Texto_Cabeza = .Columns(.CurrentCell.ColumnIndex).HeaderText

            Dim Copiar = .Rows(.CurrentRow.Index).Cells(_Cabeza).Value
            Clipboard.SetText(Copiar)

        End With
    End Sub

    Private Sub Txt_Filtrar_TextChanged(sender As Object, e As EventArgs) Handles Txt_Filtrar.TextChanged
        If String.IsNullOrWhiteSpace(Txt_Filtrar.Text) Then
            Sb_Actualizar_Grilla()
        End If
    End Sub
End Class
