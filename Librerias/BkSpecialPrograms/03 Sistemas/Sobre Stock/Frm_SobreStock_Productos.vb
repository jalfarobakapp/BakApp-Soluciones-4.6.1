Imports DevComponents.DotNetBar

Public Class Frm_SobreStock_Productos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Empresa As String = Mod_Empresa

    Public Property Seleccionado As Boolean
    Public Property ModoSeleccion As Boolean
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

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String = String.Empty

        Consulta_sql = "Select Sbs.*,Sbs.PqteHabilitado-Sbs.PqteComprometido As 'PqteDisponible' ,Pst.StComp1,Pst.StComp2," &
                       "STFI1,STFI2,Ms.STOCNV1,Ms.STOCNV2" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Prod_SobreStock Sbs" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Prod_Stock Pst On " &
                       "Sbs.Empresa = Pst.Empresa And Sbs.Sucursal = Pst.Sucursal And Sbs.Bodega = Pst.Bodega And Sbs.Codigo = Pst.Codigo" & vbCrLf &
                       "Left Join MAEST Ms On Ms.EMPRESA = Sbs.Empresa And Ms.KOSU = Sbs.Sucursal And Ms.KOBO = Sbs.Bodega And Ms.KOPR = Sbs.Codigo" & vbCrLf &
                       "Where Sbs.Empresa = '" & _Empresa & "'"

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

            .Columns("Sucursal").Width = 30
            .Columns("Sucursal").HeaderText = "Suc"
            .Columns("Sucursal").Visible = True
            .Columns("Sucursal").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Bodega").Width = 30
            .Columns("Bodega").HeaderText = "Bod"
            .Columns("Bodega").Visible = True
            .Columns("Bodega").DisplayIndex = _DisplayIndex
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

            If Not ModoSeleccion Then

                .Columns("StSobStockUd1").Width = 70
                .Columns("StSobStockUd1").HeaderText = "Disponible Ud1"
                .Columns("StSobStockUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("StSobStockUd1").DefaultCellStyle.Format = "##,###0.##"
                .Columns("StSobStockUd1").Visible = True
                .Columns("StSobStockUd1").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

            End If

            .Columns("FormatoPqte").Width = 80
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

            .Columns("PqteComprometido").Width = 70
            .Columns("PqteComprometido").HeaderText = "Comprometido"
            .Columns("PqteComprometido").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PqteComprometido").DefaultCellStyle.Format = "##,###0.##"
            .Columns("PqteComprometido").Visible = True
            .Columns("PqteComprometido").DisplayIndex = _DisplayIndex
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

        Dim _Row_Bodega As DataRow = Fx_Seleccionar_Bodega()

        If IsNothing(_Row_Bodega) Then
            Return
        End If

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_SobreStock",
                                                        "Empresa = '" & _Row_Bodega.Item("EMPRESA") & "' And " &
                                                        "Sucursal = '" & _Row_Bodega.Item("KOSU") & "' And " &
                                                        "Bodega = '" & _Row_Bodega.Item("KOBO") & "' And " &
                                                        "Codigo = '" & _RowProducto.Item("KOPR") & "' And " &
                                                        "Activo = 1")

        If _Reg > 0 Then
            MessageBoxEx.Show(Me, "El producto ya se encuentra ingresado en la bodega seleccionada", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Zw_Prod_SobreStock As New Zw_Prod_SobreStock

        Consulta_sql = "Select Ms.EMPRESA,Ms.KOSU,Ms.KOBO,Ms.STFI1,Ms.STFI2,Ms.STTR1,Ms.STTR2,Ms.STOCNV1,Ms.STOCNV2" & vbCrLf &
                       ",Isnull(St.StComp1,0) As 'StComp1',Isnull(St.StComp2,0) As 'StComp2'" & vbCrLf &
                       "--,Isnull(St.StSbCompStock1,0) As 'StSbCompStock1',Isnull(St.StSbCompStock2,0) As 'StSbCompStock2'" & vbCrLf &
                       "--,Isnull(St.StSobStockUd1,0) As 'StSobStockUd1',Isnull(St.StSobStockUd2,0) As 'StSobStockUd2'" & vbCrLf &
                       ",Cast(0 As Float) As StDispUd1,Cast(0 As Float) As StockDisponibleUd2" & vbCrLf &
                       "Into #Paso" & vbCrLf &
                       "From MAEST Ms" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Prod_Stock St On " &
                       "St.Empresa = Ms.EMPRESA And St.Sucursal = Ms.KOSU And St.Bodega = Ms.KOBO And St.Codigo = Ms.KOPR" & vbCrLf &
                       "Where Ms.EMPRESA = '" & _Row_Bodega.Item("EMPRESA") & "' " &
                       "And Ms.KOSU = '" & _Row_Bodega.Item("KOSU") & "' " &
                       "And Ms.KOBO = '" & _Row_Bodega.Item("KOBO") & "' " &
                       "And Ms.KOPR = '" & _RowProducto.Item("KOPR") & "'" & vbCrLf &
                       "Update #Paso Set StDispUd1 = STFI1-(STOCNV1+StComp1+STTR1)," &
                       "StockDisponibleUd2 = STFI2-(STOCNV2+StComp2+STTR2)" & vbCrLf &
                       "Select  * From #Paso" & vbCrLf &
                       "Drop Table #Paso"
        Dim _Row_Stock As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Stock) Then
            MessageBoxEx.Show(Me, "No tiene stock suficiente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        With _Zw_Prod_SobreStock

            .Id = 0
            .Empresa = Mod_Empresa
            .Sucursal = _Row_Bodega.Item("KOSU")
            .Bodega = _Row_Bodega.Item("KOBO")
            .Codigo = _RowProducto.Item("KOPR")
            .Descripcion = _RowProducto.Item("NOKOPR")
            .CantMinFormato = 0
            .FormatoPqte = "Pallet"
            .StSobStockUd1 = _Row_Stock.Item("StDispUd1")
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

    Function Fx_Seleccionar_Bodega() As DataRow

        Dim _Row As DataRow = Nothing

        Do

            Dim Fm_b As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
            Fm_b.Pro_Empresa = Mod_Empresa
            Fm_b.Pro_Sucursal = String.Empty
            Fm_b.Pro_Bodega = String.Empty
            Fm_b.RevisarPermisosBodega = False
            Fm_b.Pedir_Permiso = False
            Fm_b.ShowDialog(Me)

            _Row = Fm_b.Pro_RowBodega
            Dim _BodegaSeleccionada As Boolean = Fm_b.Pro_Seleccionado
            Fm_b.Dispose()

            If Not _BodegaSeleccionada Then

                _Row = Nothing

                If MessageBoxEx.Show(Me, "Debe seleccionar una bodega por obligación" & vbCrLf & "¿Desea continuar con la acción?", "Validación",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Stop) <> DialogResult.Yes Then
                    'Me.Close()
                    Exit Function
                End If

            End If

        Loop While IsNothing(_Row)

        Return _Row

    End Function

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
                .Sucursal = _Fila.Cells("Sucursal").Value
                .Bodega = _Fila.Cells("Bodega").Value
                .Codigo = _Fila.Cells("Codigo").Value
                .Descripcion = _Fila.Cells("Descripcion").Value
                .Activo = _Fila.Cells("Activo").Value
                .CodFuncionarioCrea = _Fila.Cells("CodFuncionarioCrea").Value
                .FechaVigencia = _Fila.Cells("FechaVigencia").Value
                .FormatoPqte = _Fila.Cells("FormatoPqte").Value
                .PqteHabilitado = _Fila.Cells("PqteHabilitado").Value
                .PqteComprometido = _Fila.Cells("PqteComprometido").Value
                .Ud1XPqte = _Fila.Cells("Ud1XPqte").Value
                .CantMinFormato = _Fila.Cells("CantMinFormato").Value
                .Moneda = _Fila.Cells("Moneda").Value
                .PrecioXUd1 = _Fila.Cells("PrecioXUd1").Value
                .StSobStockUd1 = _Fila.Cells("StSobStockUd1").Value
                .StSobStockUd2 = _Fila.Cells("StSobStockUd2").Value
                .StSbCompStock1 = _Fila.Cells("StSbCompStock1").Value
                .StSbCompStock2 = _Fila.Cells("StSbCompStock2").Value
                .StDispUd1 = _Fila.Cells("StSobStockUd1").Value - _Fila.Cells("StSbCompStock1").Value

            End With

            Seleccionado = True

            Me.Close()

        End If

    End Sub

End Class
