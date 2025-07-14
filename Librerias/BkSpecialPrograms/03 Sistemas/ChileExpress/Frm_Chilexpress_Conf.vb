Imports DevComponents.DotNetBar

Public Class Frm_Chilexpress_Conf

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim Cl_Chilexpress As Clas_CliexpressAPI

    Dim _Key_Cotizador As String
    Dim _Key_Cobertura As String
    Dim _Key_Envio As String
    Dim _TCC As String
    Dim _Rut_Seller As String
    Dim _Rut_Mark As String
    Dim _Es_Test As Boolean

    Public Sub New(_Es_Test As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "Select '' As Padre,'' As Hijo Union Select NombreEtiqueta As Padre,NombreEtiqueta As Hijo From " & _Global_BaseBk & "Zw_Tbl_DisenoBarras"
        Dim _TblEtiquetas As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        caract_combo(Cmb_NombreEtiqueta)
        Cmb_NombreEtiqueta.DataSource = Nothing
        Cmb_NombreEtiqueta.DataSource = _TblEtiquetas

        Me._Es_Test = _Es_Test

    End Sub

    Private Sub Frm_Chilexpress_Envio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Arr_Peso(,) As String = {{"SUMA", "Suma de pesos X cantidad de productos"},
                                      {"MAXIMOVALOR", "Toma el valor máximo de los pesos"}}
        Sb_Llenar_Combos(_Arr_Peso, Cmb_Cond_Peso)
        Cmb_Cond_Peso.SelectedValue = "SUMA"

        Dim _Arr_Alto(,) As String = {{"SUMA", "Suma de altos X cantidad de productos"},
                                      {"MAXIMOVALOR", "Toma el valor máximo de los altos"}}
        Sb_Llenar_Combos(_Arr_Alto, Cmb_Cond_Alto)
        Cmb_Cond_Alto.SelectedValue = "SUMA"

        Dim _Arr_Largo(,) As String = {{"SUMA", "Suma de largos X cantidad de productos"},
                                      {"MAXIMOVALOR", "Toma el valor máximo de los largos"}}
        Sb_Llenar_Combos(_Arr_Largo, Cmb_Cond_Largo)
        Cmb_Cond_Largo.SelectedValue = "SUMA"

        Dim _Arr_Ancho(,) As String = {{"SUMA", "Suma de anchos X cantidad de productos"},
                                      {"MAXIMOVALOR", "Toma el valor máximo de los anchos"}}
        Sb_Llenar_Combos(_Arr_Ancho, Cmb_Cond_Ancho)
        Cmb_Cond_Ancho.SelectedValue = "SUMA"

        Cl_Chilexpress = New Clas_CliexpressAPI
        Sb_Llenar_Datos()

    End Sub

    Private Sub Sb_Llenar_Datos()

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Chilexpress_Conf Where Es_Test = " & Convert.ToInt32(_Es_Test)
        Dim _Row_Configuracion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Configuracion) Then
            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Chilexpress_Conf(Key_Cotizador,Key_Cobertura,Key_Envios,TCC," &
                           "Rut_Seller,Rut_Mark,CodigoRd,CodTransportista,NombreEtiqueta,Activo,Es_Test,Cond_Peso,Cond_Alto,Cond_Largo,Cond_Ancho) Values " &
                           "('','','','','','','','','',1," & Convert.ToInt32(_Es_Test) & ",'','','','')"
            _Sql.Ej_consulta_IDU(Consulta_sql)
            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Chilexpress_Conf Where Es_Test = " & Convert.ToInt32(_Es_Test)
            _Row_Configuracion = _Sql.Fx_Get_DataRow(Consulta_sql)
        End If

        If IsNothing(_Row_Configuracion) Then
            Txt_Key_Cotizador.Text = String.Empty
            Txt_Key_Cobertura.Text = String.Empty
            Txt_Key_Envios.Text = String.Empty

            Txt_TCC.Text = String.Empty
            Txt_Rut_Seller.Text = String.Empty
            Txt_Rut_Mark.Text = String.Empty

            Txt_CodigoRd.Tag = String.Empty
        Else
            Txt_Key_Cotizador.Text = _Row_Configuracion.Item("Key_Cotizador")
            Txt_Key_Cobertura.Text = _Row_Configuracion.Item("Key_Cobertura")
            Txt_Key_Envios.Text = _Row_Configuracion.Item("Key_Envios")

            Txt_TCC.Text = _Row_Configuracion.Item("TCC")
            Txt_Rut_Seller.Text = _Row_Configuracion.Item("Rut_Seller")
            Txt_Rut_Mark.Text = _Row_Configuracion.Item("Rut_Mark")

            Txt_CodigoRd.Tag = _Row_Configuracion.Item("CodigoRd")

            Cmb_Cond_Peso.SelectedValue = _Row_Configuracion.Item("Cond_Peso")
            Cmb_Cond_Alto.SelectedValue = _Row_Configuracion.Item("Cond_Alto")
            Cmb_Cond_Largo.SelectedValue = _Row_Configuracion.Item("Cond_Largo")
            Cmb_Cond_Ancho.SelectedValue = _Row_Configuracion.Item("Cond_Ancho")

        End If

        Consulta_sql = "Select KOPR,NOKOPR From MAEPR Where KOPR = '" & Txt_CodigoRd.Tag & "'"
        Dim _Row_Producto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_Producto) Then
            Txt_CodigoRd.Text = _Row_Producto.Item("KOPR").ToString.Trim & " - " & _Row_Producto.Item("NOKOPR").ToString.Trim
        End If

        Cmb_NombreEtiqueta.SelectedValue = _Row_Configuracion.Item("NombreEtiqueta")

        Txt_CodTransportista.Tag = _Row_Configuracion.Item("CodTransportista")
        Txt_CodTransportista.Text = _Sql.Fx_Trae_Dato("TABRETI", "NORETI", "KORETI = '" & Txt_CodTransportista.Tag & "'")

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Chilexpress_Conf SET " &
                       "[Key_Cotizador] = '" & Txt_Key_Cotizador.Text & "'," &
                       "[Key_Cobertura] = '" & Txt_Key_Cobertura.Text & "'," &
                       "[Key_Envios] = '" & Txt_Key_Envios.Text & "'," &
                       "[TCC] = '" & Txt_TCC.Text & "'," &
                       "[Rut_Seller] = '" & Txt_Rut_Seller.Text & "'," &
                       "[Rut_Mark] = '" & Txt_Rut_Mark.Text & "'," &
                       "[CodigoRd] = '" & Txt_CodigoRd.Tag & "'," &
                       "[CodTransportista] = '" & Txt_CodTransportista.Tag & "'," &
                       "[NombreEtiqueta] = '" & Cmb_NombreEtiqueta.SelectedValue & "'," &
                       "[Es_Test] = '" & Convert.ToInt32(_Es_Test) & "'," & vbCrLf &
                       "[Cond_Peso] = '" & Cmb_Cond_Peso.SelectedValue & "'," &
                       "[Cond_Alto] = '" & Cmb_Cond_Alto.SelectedValue & "'," &
                       "[Cond_Largo] = '" & Cmb_Cond_Largo.SelectedValue & "'," &
                       "[Cond_Ancho] = '" & Cmb_Cond_Ancho.SelectedValue & "'" &
                       "Where Activo = 1 And Es_Test = " & Convert.ToInt32(_Es_Test)
        If _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
            MessageBoxEx.Show(Me, "Los datos fueron actualizados satisfactoriamente", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBoxEx.Show(Me, "Ha ocurrido un error favor de intentar nuevamente" & vbCrLf &
                              _Sql.Pro_Error, "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub Btn_Buscar_Transportista_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Transportista.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "TABRETI"
        _Filtrar.Campo = "KORETI"
        _Filtrar.Descripcion = "NORETI"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "TRANSPORTISTA"

        Dim _Sql_Filtro_Condicion_Extra = "And KORETI In (Select CodTransportista From " & _Global_BaseBk & "Zw_Despachos_Transportistas Where Mostrar = 1)"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _Sql_Filtro_Condicion_Extra,
                               Nothing, False, True) Then

            Dim _Tbl_Transportista As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Transportista.Rows(0)

            Dim _Codigo = _Row.Item("Codigo")
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Txt_CodTransportista.Tag = _Codigo
            Txt_CodTransportista.Text = _Descripcion

        End If

    End Sub

    Private Sub Btn_Buscar_Producto_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Producto.Click

        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
        Fm.Pro_Actualizar_Precios = True
        Fm.Pro_Mostrar_Info = False
        Fm.BtnBuscarAlternativos.Visible = True
        Fm.Pro_Mostrar_Imagenes = True
        Fm.BtnCrearProductos.Visible = False
        Fm.Pro_Mostrar_Editar = True
        Fm.Pro_Mostrar_Eliminar = False
        Fm.BtnExportaExcel.Visible = False
        Fm.Pro_Tipo_Lista = "P"
        Fm.Pro_Maestro_Productos = False
        Fm.Pro_Sucursal_Busqueda = Mod_Sucursal
        Fm.Pro_Bodega_Busqueda = Mod_Bodega
        Fm.Pro_Filtro_Sql_Extra = "And TIPR = 'SSN'"
        Fm.Pro_Lista_Busqueda = Mod_ListaPrecioVenta
        Fm.ShowDialog(Me)

        If Fm.Pro_Seleccionado Then
            Txt_CodigoRd.Tag = Fm.Pro_RowProducto.Item("KOPR")
            Txt_CodigoRd.Text = Fm.Pro_RowProducto.Item("KOPR") & " - " & Fm.Pro_RowProducto.Item("NOKOPR")
        End If

        Fm.Dispose()

    End Sub
End Class
