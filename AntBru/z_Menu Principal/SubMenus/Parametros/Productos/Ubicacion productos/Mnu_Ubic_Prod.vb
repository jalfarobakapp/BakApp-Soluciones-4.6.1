'Imports Lib_Bakapp_VarClassFunc
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Mnu_Ubic_Prod

    Public _ImpDesdeInventario As Boolean
    Public _IdInventario As Integer
    'Public _Empresa, _Sucursal, _Bodega As String
    Public _RowBodega As DataRow

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Public Sub New(ByVal Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub BtnUbicxProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUbicxProductos.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Ubic0002") Then

            Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt

            With Fm
                .Pro_Empresa = _RowBodega.Item("EMPRESA")
                .Pro_Sucursal = _RowBodega.Item("KOSU")
                .Pro_Bodega = _RowBodega.Item("KOBO")
                .Pro_Row_Bodega = _RowBodega
                .Pro_Actualizar_Precios = False
                .Pro_Mostrar_Info = False
                .BtnBuscarAlternativos.Visible = True
                .Pro_Mostrar_Imagenes = True
                .BtnExportaExcel.Visible = True
                .Pro_Tipo_Lista = "P"
                .Pro_Sucursal_Busqueda = _RowBodega.Item("KOSU")
                .Pro_Bodega_Busqueda = _RowBodega.Item("KOBO")
                .Pro_Lista_Busqueda = ModListaPrecioVenta
                .Mnu_Btn_Cambiar_Codigo_Producto.Visible = True
                .Pro_Trabajar_Ubicaciones = True
                .ShowDialog(Me)
                .Dispose()

            End With

        End If

    End Sub

    Private Sub BtnVerUbicaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVerUbicaciones.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Ubic0003") Then 'Mantención de ubicaciones

            Dim Fm As New Frm_Diseno_Doc_y_Ubic
            Fm.Pro_RowBodega = _RowBodega
            Fm.Pro_Configuracion_Diseno = Frm_Diseno_Doc_y_Ubic._TipoDiseno.Mapa_Bodega_Crear_Ubicaciones
            Fm.Text = Trim(_RowBodega.Item("NOKOBO"))
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub BtnMantUbicaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMantUbicaciones.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Ubic0003") Then 'Mantención de ubicaciones

            Dim Fm_b As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
            Fm_b.Pro_Empresa = ModEmpresa
            Fm_b.Pro_Sucursal = ModSucursal
            Fm_b.Pro_Bodega = ModBodega
            Fm_b.ShowDialog(Me)

            If Fm_b.Pro_Seleccionado Then
                Dim Fm As New Frm_Diseno_Doc_y_Ubic
                Fm.Pro_RowBodega = Fm_b.Pro_RowBodega
                Fm.Pro_Configuracion_Diseno = Frm_Diseno_Doc_y_Ubic._TipoDiseno.Mapa_Bodega_Diseño
                Fm.ShowDialog(Me)
                Fm.Dispose()
            End If
            Fm_b.Dispose()

        End If

    End Sub

  
End Class
