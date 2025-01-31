Imports DevComponents.DotNetBar
Imports MySql.Data.Authentication

Public Class Frm_GDI2GRI

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Empresa As String
    Private _Sucursal As String
    Private _Bodega_GDI As String
    Private _Bodega_GRI As String
    Private _RowProducto As DataRow

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Empresa = ModEmpresa
        _Sucursal = ModSucursal

    End Sub
    Private Sub Frm_GDI2GRI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Btn_Limpiar_Click(Nothing, Nothing)
    End Sub
    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Txt_Producto.Text) Then
            MessageBoxEx.Show(Me, "Falta el producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(_Bodega_GDI) Then
            MessageBoxEx.Show(Me, "Falta la bodega de Salida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_BodegaGDI.Focus()
            Return
        End If

        If String.IsNullOrEmpty(_Bodega_GRI) Then
            MessageBoxEx.Show(Me, "Falta la bodega de Ingreso", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_BodegaGDI.Focus()
            Return
        End If

        If DInput_Cantidad.Value <= 0 Then
            MessageBoxEx.Show(Me, "Falta la cantidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            DInput_Cantidad.Focus()
            Return
        End If

        Dim _Codigo As String = _RowProducto.Item("KOPR")

        Dim _Stock_Disponible = Fx_Stock_Disponible("GDI", ModEmpresa,
                                                    _Sucursal,
                                                    _Bodega_GDI,
                                                    _Codigo,
                                                    Cmb_UdMedida.SelectedValue,
                                                    "STFI" & Cmb_UdMedida.SelectedValue)

        If DInput_Cantidad.Value > _Stock_Disponible Then
            MessageBoxEx.Show(Me, "Stock insuficiente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Dim _Cl_GDI2GRI As New Cl_GDI2GRI
        Dim _FechaEmision As Date = FechaDelServidor()

        Dim _Row_GDI As DataRow
        Dim _Row_GRI As DataRow

        Dim _Mensaje As New LsValiciones.Mensajes

        Me.Enabled = False
        Dim Fm_Espera As New Frm_Form_Esperar
        Fm_Espera.Pro_Texto = "GRABANDO GUIAS DE SALIDA E INGRESO, POR FAVOR ESPERE"
        Fm_Espera.BarraCircular.IsRunning = True
        Fm_Espera.Show()

        _Mensaje = _Cl_GDI2GRI.Fx_Crear_GDI2GRI(Me, Modalidad, _Sucursal, _Bodega_GDI, _FechaEmision, _RowProducto.Item("KOPR"), DInput_Cantidad.Value)

        If Not _Mensaje.EsCorrecto Then
            Fm_Espera.Close()
            Fm_Espera.Dispose()
            Fm_Espera = Nothing
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)
            Return
        End If

        _Row_GDI = _Sql.Fx_Get_DataRow("Select * From MAEEDO Where IDMAEEDO = " & _Mensaje.Id)

        _Mensaje = _Cl_GDI2GRI.Fx_Crear_GRIDesdeGDI(Me, _Mensaje.Id, _Sucursal, _Bodega_GRI)

        If Not _Mensaje.EsCorrecto Then
            Fm_Espera.Close()
            Fm_Espera.Dispose()
            Fm_Espera = Nothing
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)
        End If

        _Row_GRI = _Sql.Fx_Get_DataRow("Select * From MAEEDO Where IDMAEEDO = " & _Mensaje.Id)

        Fm_Espera.Close()
        Fm_Espera.Dispose()
        Fm_Espera = Nothing

        _Mensaje.Mensaje = "¡Perfecto! Las guías de ingreso (GDI-" & _Row_GDI.Item("NUDO") & ") y salida (GRI-" & _Row_GRI.Item("NUDO") & ") se han creado exitosamente."
        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        Me.Enabled = True
        Call Btn_Limpiar_Click(Nothing, Nothing)

    End Sub
    Private Sub Txt_Producto_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Producto.ButtonCustomClick

        Try

            Txt_Producto.Enabled = False

            Dim _Codigo As String = Txt_Producto.Text

            Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
            _RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_RowProducto) Then
                If Not String.IsNullOrEmpty(_RowProducto.Item("ATPR").ToString.Trim) Then
                    MessageBoxEx.Show(Me, "Producto oculto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                Else
                    Codigo_abuscar = _Codigo
                    Txt_Producto.Tag = _RowProducto.Item("KOPR")
                    Txt_Producto.Text = _RowProducto.Item("KOPR").ToString.Trim & "-" & _RowProducto.Item("NOKOPR").ToString.Trim
                End If
                Return
            End If

            Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
            Fm.Pro_Tipo_Lista = "P"
            Fm.Pro_Lista_Busqueda = ModListaPrecioVenta
            Fm.Pro_CodEntidad = String.Empty
            Fm.Pro_Mostrar_Info = True
            Fm.BtnCrearProductos.Visible = False
            Fm.Txtdescripcion.Text = String.Empty
            Fm.BtnExportaExcel.Visible = False
            Fm.Pro_Actualizar_Precios = False

            Fm.ShowDialog(Me)

            Dim _ProductoSeleccionado As Boolean = Fm.Pro_Seleccionado

            If _ProductoSeleccionado Then

                _RowProducto = Fm.Pro_RowProducto

                Codigo_abuscar = Fm.Pro_RowProducto.Item("KOPR")

                If Not String.IsNullOrEmpty(Trim(Codigo_abuscar)) Then

                    Txt_Producto.Tag = _RowProducto
                    Txt_Producto.Text = _RowProducto.Item("KOPR").ToString.Trim & "-" & _RowProducto.Item("NOKOPR").ToString.Trim

                    Dim _Arr_Tipo_Entidad(,) As String = {{"1", _RowProducto.Item("UD01PR")}, {"2", _RowProducto.Item("UD01PR")}}
                    Sb_Llenar_Combos(_Arr_Tipo_Entidad, Cmb_UdMedida)
                    Cmb_UdMedida.SelectedValue = 2

                End If

            End If

            Fm.Dispose()

            'Txt_Producto.ButtonCustom.Visible = Not _ProductoSeleccionado
            'Txt_Producto.ButtonCustom2.Visible = _ProductoSeleccionado

            'If _ProductoSeleccionado Then
            '    Call Txt_Bodega_ButtonCustomClick(Nothing, Nothing)
            'End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Producto.Tag = Nothing
            Txt_Producto.Text = String.Empty
        Finally
            Txt_Producto.Enabled = True
        End Try

    End Sub

    Private Sub Txt_BodegaGDI_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_BodegaGDI.ButtonCustomClick

        If String.IsNullOrEmpty(Txt_Producto.Text) Then
            MessageBoxEx.Show(Me, "Falta el producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm_b As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)

        Fm_b.Pro_Empresa = ModEmpresa
        Fm_b.Cmbsucursal.Enabled = False
        Fm_b.Pro_Sucursal = NuloPorNro(_Sucursal, ModSucursal)
        Fm_b.Pro_Bodega = NuloPorNro(_Bodega_GDI, ModBodega)
        Fm_b.RevisarPermisosBodega = False
        Fm_b.Pedir_Permiso = False
        Fm_b.ShowDialog(Me)

        If Fm_b.Pro_Seleccionado Then

            _Empresa = Fm_b.Pro_RowBodega.Item("EMPRESA")
            _Sucursal = Fm_b.Pro_RowBodega.Item("KOSU")
            _Bodega_GDI = Fm_b.Pro_RowBodega.Item("KOBO")
            Txt_BodegaGDI.Text = Fm_b.Pro_RowBodega.Item("NOKOSU").ToString.Trim & " - " & Fm_b.Pro_RowBodega.Item("NOKOBO").ToString.Trim

        End If

        Fm_b.Dispose()

    End Sub

    Private Sub Txt_BodegaGRI_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_BodegaGRI.ButtonCustomClick

        If String.IsNullOrEmpty(Txt_Producto.Text) Then
            MessageBoxEx.Show(Me, "Falta el producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(_Bodega_GDI) Then
            MessageBoxEx.Show(Me, "Falta la bodega de Salida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_BodegaGDI.Focus()
            Return
        End If

        Dim Fm_b As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)

        Fm_b.Pro_Empresa = ModEmpresa
        Fm_b.Cmbsucursal.Enabled = False
        Fm_b.Pro_Sucursal = NuloPorNro(_Sucursal, ModSucursal)
        Fm_b.Pro_Bodega = NuloPorNro(_Bodega_GRI, ModBodega)
        Fm_b.RevisarPermisosBodega = False
        Fm_b.Pedir_Permiso = False
        Fm_b.Empresa_NoSeleccionable = _Empresa
        Fm_b.Sucursal_NoSeleccionable = _Sucursal
        Fm_b.Bodega_NoSeleccionable = _Bodega_GDI
        Fm_b.ShowDialog(Me)

        If Fm_b.Pro_Seleccionado Then

            _Bodega_GRI = Fm_b.Pro_RowBodega.Item("KOBO")
            Txt_BodegaGRI.Text = Fm_b.Pro_RowBodega.Item("NOKOSU").ToString.Trim & " - " & Fm_b.Pro_RowBodega.Item("NOKOBO").ToString.Trim

        End If

        Fm_b.Dispose()

    End Sub

    Private Sub Btn_Limpiar_Click(sender As Object, e As EventArgs) Handles Btn_Limpiar.Click

        _Empresa = ModEmpresa
        _Sucursal = ModSucursal
        Txt_Producto.Text = String.Empty
        Txt_Producto.Tag = Nothing
        Txt_BodegaGDI.Text = String.Empty
        Txt_BodegaGRI.Text = String.Empty
        _Bodega_GDI = String.Empty
        _Bodega_GRI = String.Empty
        _RowProducto = Nothing
        DInput_Cantidad.Value = 0
        Cmb_UdMedida.DataSource = Nothing

    End Sub

End Class
