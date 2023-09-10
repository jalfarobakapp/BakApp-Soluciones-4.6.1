'Imports Lib_Bakapp_VarClassFunc
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Productos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Productos_Seleccionados As DataTable

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Public Sub New(ByVal Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre
    End Sub

    Private Sub Productos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        AddHandler Btn_AjustePM.Click, AddressOf Sb_Ajuste_PM
        AddHandler Btn_Arbol_Clasificaciones.Click, AddressOf Sb_Arbol_Clasificaciones
        AddHandler Btn_Tablas.Click, AddressOf Sb_Tablas
        AddHandler BtnConsolidarStock.Click, AddressOf Sb_Consolidar_Stock
        AddHandler BtnUnificarProductos.Click, AddressOf Sb_Unificar_Productos
        AddHandler BtnUbicProductos.Click, AddressOf Sb_Ubicacion_Productos
        AddHandler Btn_CodAlternativo.Click, AddressOf Sb_Codigos_Alternativos
        AddHandler Btn_Maestra_Productos.Click, AddressOf Sb_Maestra_Productos
        AddHandler Btn_CambiarCodProducto.Click, AddressOf Sb_Cambiar_Codigo_Producto
        AddHandler BtnCP_Matriz.Click, AddressOf Sb_Crear_Producto_Matriz

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub ButtonItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem1.Click
        CallByName(Me, "Crear_Producto", vbMethod)
    End Sub

    ' Private Function GetRadioButtons() As Command()
    '    Return New Command() {Radio1, Radio2}
    'End Function

    Private Sub Productos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
        End If
    End Sub

#Region "MENU"

#Region "UNIFICAR PRODUCTOS"
    Sub Sb_Unificar_Productos()

        Dim Nro As String = "Prod006"

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, Nro) Then

            Dim Frm_UnificacionProducto As New Frm_UnificacionProducto
            Frm_UnificacionProducto.ShowInTaskbar = False
            Frm_UnificacionProducto.ShowDialog(Me)

        End If

    End Sub
#End Region

#Region "AJUSTE PM"
    Sub Sb_Ajuste_PM()

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Espr0005") Then

            Dim Fm As New Frm_Mt_InvParc_02_Seleccion(ModEmpresa, ModSucursal, ModBodega, FechaDelServidor, True)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

#End Region

#Region "ARBOL DE CLASIFICACIONES"
    Sub Sb_Arbol_Clasificaciones()

        Dim NewPanel As Arbol_Clasificaciones = Nothing
        NewPanel = New Arbol_Clasificaciones(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub
#End Region

#Region "TABLAS"
    Sub Sb_Tablas()

        Dim NewPanel As Tablas_Clasificaciones_Pro = Nothing
        NewPanel = New Tablas_Clasificaciones_Pro(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub
#End Region

    Private Function GetRadioButtons() As Command()
        Return New Command() {Radio1, Radio2}
    End Function


#Region "CONSOLIDAR STOCK"

    Sub Sb_Consolidar_Stock()

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Prod055") Then

            Dim Fm As New Frm_Consolidacion_Stock_PP_Selec_Prod
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

#End Region

#Region "UBICACION PRODUCTOS"
    Sub Sb_Ubicacion_Productos()

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Ubic0001") Then

            Dim Fm As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
            Fm.Pro_Empresa = ModEmpresa
            Fm.Pro_Sucursal = ModSucursal
            Fm.Pro_Bodega = ModBodega
            Fm.ShowDialog(Me)

            If Fm.Pro_Seleccionado Then

                Dim NewPanel As Mnu_Ubic_Prod = Nothing
                NewPanel = New Mnu_Ubic_Prod(_Fm_Menu_Padre)
                NewPanel._ImpDesdeInventario = False
                NewPanel._RowBodega = Fm.Pro_RowBodega
                _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

            End If

        End If

    End Sub
#End Region

#Region "CODIGOS ALTERNATIVOS"
    Sub Sb_Codigos_Alternativos()

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Prod020") Then

            Dim Fm As New Frm_Codigos_Alternativos
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

#End Region

#Region "MAESTRO PRODUCTOS"
    Sub Sb_Maestra_Productos()

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Prod012") Then

            Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
            With Fm
                .Pro_Actualizar_Precios = False
                .Pro_Mostrar_Info = False
                .BtnBuscarAlternativos.Visible = True
                .Pro_Mostrar_Imagenes = True
                .BtnCrearProductos.Visible = True
                .Pro_Mostrar_Editar = True
                .Pro_Mostrar_Eliminar = True
                .BtnExportaExcel.Visible = True
                .Pro_Tipo_Lista = "P"
                .Pro_Maestro_Productos = True
                .Pro_Sucursal_Busqueda = ModSucursal
                .Pro_Bodega_Busqueda = ModBodega
                .Pro_Lista_Busqueda = ModListaPrecioVenta
                .Mnu_Btn_Cambiar_Codigo_Producto.Visible = True
                .TraerTodosLosProductos = True
                .ShowDialog(Me)
                .Dispose()
            End With

        End If

    End Sub
#End Region

#Region "CAMBIAR CODIGO PRODUCTO"
    Sub Sb_Cambiar_Codigo_Producto()

        Dim NewPanel As Cambiar_Codigos_Mnu = Nothing
        NewPanel = New Cambiar_Codigos_Mnu(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

#End Region

#Region "CREAR PRODUCTO POR MATRIZ"
    Sub Sb_Crear_Producto_Matriz()

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Prod007") Then
            MessageBoxEx.Show(Me, "En Construcción")
        End If

    End Sub
#End Region

#End Region

    Private Sub BtnRankingProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRankingProductos.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Inf00004") Then
            Dim Fm As New Frm_Ranking_Menu
            Fm.ShowDialog(_Fm_Menu_Padre)
        End If

    End Sub

    Private Sub Btn_Kardex_Inventario_Click(sender As Object, e As EventArgs) Handles Btn_Kardex_Inventario.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Prod002") Then

            Dim Fm As New Frm_Kardex_X_Producto_Lista
            Fm.ShowDialog(_Fm_Menu_Padre)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_ImagenesXProductos_Click(sender As Object, e As EventArgs) Handles Btn_ImagenesXProductos.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Prod067") Then

            Dim Fm As New Frm_Imagenes_X_Producto_Lista
            Fm.ShowDialog(_Fm_Menu_Padre)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_ImpAdicionalXProd_Click(sender As Object, e As EventArgs) Handles Btn_ImpAdicionalXProd.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Prod072") Then

            Dim Fm As New Frm_ImpAdicXProd_Lista
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Maestra_Productos_Click(sender As Object, e As EventArgs) Handles Btn_Maestra_Productos.Click

    End Sub

    Private Sub Btn_Ofertas_Click(sender As Object, e As EventArgs) Handles Btn_Ofertas.Click

        Dim Fm As New Frm_OfDinamLista
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub
End Class
