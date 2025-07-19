Imports DevComponents.DotNetBar
Public Class Frm_ImpAdicXProd

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id As Integer
    Dim _RowProducto As DataRow
    Dim _Tido As String
    Dim _Subtido As String
    Dim _Codigo As String
    Dim _Descripcion As String
    Dim _Editar As Boolean
    Public Property Grabar As Boolean

    Public Sub New(_Id As Integer, _Codigo As String, _Tido As String, _Subtido As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id = _Id
        Me._Codigo = _Codigo
        Me._Tido = _Tido
        Me._Subtido = _Subtido

        _Editar = CBool(_Id)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_ImpAdicXProd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Btn_Eliminar.Visible = _Editar
        Txt_Producto.ButtonCustom.Visible = Not _Editar

        If _Editar Then

            _Descripcion = _Sql.Fx_Trae_Dato("MAEPR", "NOKOPR", "KOPR = '" & _Codigo & "'")
            Txt_Producto.Text = _Codigo & " - " & _Descripcion
            Dim _Notido = _Sql.Fx_Trae_Dato("TABTIDO", "NOTIDO", "TIDO = '" & _Tido & "'").ToString.Trim
            Txt_TipoDoc.Text = _Tido & " - " & _Notido

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_ImpAdicional" & vbCrLf &
                           "Where Id = " & _id
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Txt_FormatoOrigen.Text = _Row.Item("NombreFormato_Origen")
            Txt_FormatoDestino.Text = _Row.Item("NombreFormato_Destino")
            Rdb_Reemplazar_Formato_Origen.Checked = _Row.Item("Reemplazar_Formato_Origen")
            Rdb_ImpFormDestinoyOrigen.Checked = Not _Row.Item("Reemplazar_Formato_Origen")

        End If

    End Sub

    Private Sub Txt_Producto_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Producto.ButtonCustomClick

        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
        Fm.Pro_Tipo_Lista = "P"
        Fm.Pro_Lista_Busqueda = Mod_ListaPrecioVenta
        Fm.Pro_CodEntidad = String.Empty
        Fm.Pro_Mostrar_Info = False
        Fm.BtnCrearProductos.Visible = False

        Fm.BtnExportaExcel.Visible = False
        Fm.Pro_Actualizar_Precios = False

        Fm.ShowDialog(Me)

        If Fm.Pro_Seleccionado Then

            _Codigo = Fm.Pro_RowProducto.Item("KOPR").ToString.Trim
            _Descripcion = Fm.Pro_RowProducto.Item("NOKOPR").ToString.Trim

            If Not String.IsNullOrEmpty(_Codigo) Then
                Txt_Producto.Text = _Codigo & " - " & _Descripcion
            End If

        End If

    End Sub

    Private Sub Txt_TipoDoc_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_TipoDoc.ButtonCustomClick

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "TIDO"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Documentos, "",
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            _Tido = _Row.Item("Codigo").ToString.Trim
            Txt_TipoDoc.Text = _Tido & " - " & _Row.Item("Descripcion").ToString.Trim

        End If

    End Sub

    Private Sub Txt_FormatoOrigen_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_FormatoOrigen.ButtonCustomClick
        Sb_Buscar_Formato(sender)
    End Sub

    Private Sub Txt_FormatoDestino_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_FormatoDestino.ButtonCustomClick
        Sb_Buscar_Formato(sender)
    End Sub

    Sub Sb_Buscar_Formato(ByRef _Txt As DevComponents.DotNetBar.Controls.TextBoxX)

        If String.IsNullOrEmpty(Txt_TipoDoc.Text) Then
            MessageBoxEx.Show(Me, "Falta el tipo de documento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Subtido = String.Empty

        If _Tido = "GDD" Or _Tido = "GDP" Then
            '_Subtido = _TblEncabezado.Rows(0).Item("SUBTIDO")
        End If

        Dim _Formato_Seleccionado As Boolean
        Dim _NombreFormato As String

        Dim Fm As New Frm_Seleccionar_Formato(_Tido)

        If CBool(Fm.Tbl_Formatos.Rows.Count) Then

            Fm.ShowDialog(Me)
            _Formato_Seleccionado = Fm.Formato_Seleccionado
            If Not _Formato_Seleccionado Then Return
            _Subtido = Fm.Row_Formato_Seleccionado.Item("Subtido").ToString.Trim
            _NombreFormato = Fm.Row_Formato_Seleccionado.Item("NombreFormato")
            Fm.Dispose()

        End If

        If Not String.IsNullOrEmpty(_NombreFormato) Then

            If _NombreFormato = "" Then
                _NombreFormato = String.Empty
            End If

            _Txt.Text = _NombreFormato

        Else

            MessageBoxEx.Show(Me, "No existen formatos de impresión para este documento", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Txt_Producto.Text) Then
            MessageBoxEx.Show(Me, "Falta el producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Txt_TipoDoc.Text) Then
            MessageBoxEx.Show(Me, "Falta el tipo de documento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Txt_FormatoOrigen.Text) Then
            MessageBoxEx.Show(Me, "Falta el formato de activación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Txt_FormatoDestino.Text) Then
            MessageBoxEx.Show(Me, "Falta el formato de impresión", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _NombreFormato_Origen = Txt_FormatoOrigen.Text
        Dim _NombreFormato_Destino = Txt_FormatoDestino.Text

        Dim _Reemplazar_Formato_Origen = Convert.ToInt32(Rdb_Reemplazar_Formato_Origen.Checked)

        If _Editar Then

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_ImpAdicional Set " &
                           "NombreFormato_Origen = '" & _NombreFormato_Origen & "'," &
                           "NombreFormato_Destino = '" & _NombreFormato_Destino & "'," & vbCrLf &
                           "Reemplazar_Formato_Origen = " & _Reemplazar_Formato_Origen & vbCrLf &
                           "Where Id = " & _Id
        Else

            Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_ImpAdicional",
                                  "Codigo = '" & _Codigo & "' And Tido = '" & _Tido & "' And Subtido = '" & _Subtido & "'"))

            If _Reg Then
                MessageBoxEx.Show(Me, "Ya existe una configuración para este mismo producto y el tipo de documento y formato de activación" & vbCrLf &
                                  "Debe modificar el anterior o eliminarlo y crear uno nuevo",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_ImpAdicional (Codigo,Tido,Subtido,NombreFormato_Origen,NombreFormato_Destino,Reemplazar_Formato_Origen) Values " &
                            "('" & _Codigo & "','" & _Tido & "','" & _Subtido & "','" & _NombreFormato_Origen & "','" & _NombreFormato_Destino & "'," & _Reemplazar_Formato_Origen & ")"

        End If

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            Grabar = True
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_ImpAdicional Where Id = " & _Id
            _Sql.Ej_consulta_IDU(Consulta_sql)
            Grabar = True
            Me.Close()
        End If

    End Sub
End Class
