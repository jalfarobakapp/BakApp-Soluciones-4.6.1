Imports DevComponents.DotNetBar

Public Class Frm_St_Recetas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Recetas As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Recetas, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Productos, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_St_Recetas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()
        AddHandler Grilla_Recetas.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Productos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Texto_Busqueda As String = Txt_Buscador.Text.Trim
        Dim _CondicionProd As String = String.Empty

        If Not String.IsNullOrEmpty(Txt_BuscaXProducto.Text) Then
            _CondicionProd = vbCrLf & "And Id In (Select Id_Rec From " & _Global_BaseBk & "Zw_St_OT_Recetas_Prod Where Codigo = '" & Txt_BuscaXProducto.Text & "')"
        End If

        Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(_Texto_Busqueda), "CodReceta+Descripcion Like '%")

        Consulta_sql = "Select Id,Empresa,CodReceta,Descripcion,Activo" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_St_OT_Recetas_Enc" & vbCrLf &
                       "Where Empresa = '" & ModEmpresa & "'" & vbCrLf &
                       "And CodReceta+Descripcion Like '%" & _Cadena & "%'" & _CondicionProd
        _Tbl_Recetas = _Sql.Fx_Get_Tablas(Consulta_sql)

        Sb_Actualizar_Grilla_Productos(0)

        With Grilla_Recetas

            .DataSource = _Tbl_Recetas

            OcultarEncabezadoGrilla(Grilla_Recetas, True)

            .Columns("CodReceta").Visible = True
            .Columns("CodReceta").HeaderText = "Código"
            .Columns("CodReceta").Width = 100
            .Columns("CodReceta").DisplayIndex = 0

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Width = 390
            .Columns("Descripcion").DisplayIndex = 1

            .Columns("Activo").Visible = True
            .Columns("Activo").HeaderText = "Activa"
            .Columns("Activo").Width = 50
            .Columns("Activo").DisplayIndex = 2
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End With

    End Sub

    Sub Sb_Actualizar_Grilla_Productos(_Id_Rec As Integer)

        Consulta_sql = "Select Id,Codigo,CodReceta,NOKOPR" & vbCrLf &
               "From " & _Global_BaseBk & "Zw_St_OT_Recetas_Prod" & vbCrLf &
               "Left Join MAEPR On KOPR = Codigo" & vbCrLf &
               "Where Id_Rec = " & _Id_Rec
        Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Productos

            .DataSource = _Tbl_Productos

            OcultarEncabezadoGrilla(Grilla_Productos, True)

            .Columns("Codigo").Visible = True
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Width = 100
            .Columns("Codigo").DisplayIndex = 0

            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Width = 390 + 50
            .Columns("NOKOPR").DisplayIndex = 1

        End With

    End Sub

    Private Sub Btn_Crear_Receta_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Receta.Click

        Dim _Grabar As Boolean

        Dim _Fm As New Frm_St_RecetaCrear("")
        _Fm.ShowDialog(Me)
        _Grabar = _Fm.Grabar
        _Fm.Dispose()

        If _Grabar Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Grilla_Recetas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Recetas.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Recetas.CurrentRow
        Dim _Row_Receta As DataRow
        Dim _Id_Rec As Integer = _Fila.Cells("Id").Value
        Dim _CodReceta As String = _Fila.Cells("CodReceta").Value

        Dim _Grabar As Boolean

        Dim Fm As New Frm_St_RecetaCrear(_CodReceta)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _Row_Receta = Fm.Row_Receta
        Fm.Dispose()

        If _Grabar Then
            _Fila.Cells("Descripcion").Value = _Row_Receta.Item("Descripcion")
            BuscarDatoEnGrilla(_CodReceta, "CodReceta", Grilla_Recetas)
        End If

    End Sub

    Private Sub Grilla_Recetas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Recetas.CellEnter

        Dim _Fila As DataGridViewRow = Grilla_Recetas.CurrentRow
        Dim _Id_Rec As Integer = _Fila.Cells("Id").Value

        Sb_Actualizar_Grilla_Productos(_Id_Rec)

    End Sub

    Private Sub Txt_Buscador_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Buscador.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Txt_Buscador_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Buscador.ButtonCustomClick
        If String.IsNullOrEmpty(Txt_Buscador.Text.Trim) Then Return
        Txt_Buscador.Text = String.Empty
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Txt_BuscaXProducto_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_BuscaXProducto.ButtonCustom2Click
        If String.IsNullOrEmpty(Txt_BuscaXProducto.Text.Trim) Then Return
        Txt_BuscaXProducto.Text = String.Empty
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Txt_BuscaXProducto_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_BuscaXProducto.ButtonCustomClick

        Dim _RowProducto As DataRow = Fx_Buscar_Producto("")

        If Not IsNothing(_RowProducto) Then
            Txt_BuscaXProducto.Text = _RowProducto.Item("KOPR")
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Btn_Asociar_Producto_Click(sender As Object, e As EventArgs) Handles Btn_Asociar_Producto.Click

        Dim _Fila As DataGridViewRow = Grilla_Recetas.CurrentRow

        If IsNothing(_Fila) Then
            Return
        End If

        Dim _Id_Rec As Integer = _Fila.Cells("Id").Value
        Dim _CodReceta As String = _Fila.Cells("CodReceta").Value

        Consulta_sql = "Select Cast(1 As Bit) As Chk,Codigo,NOKOPR As Descripcion" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_St_OT_Recetas_Prod" & vbCrLf &
                       "Left Join MAEPR On KOPR = Codigo" & vbCrLf &
                       "Where Id_Rec = " & _Id_Rec
        Dim _TblProductos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Sql_Filtro_Condicion_Extra = "And TIPR = 'SSN'"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Filtro_Todas = False

        If _Filtrar.Fx_Filtrar(_TblProductos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               False, False,, False,, False) Then

            Dim _Nodo_Raiz_Asociados As Integer = _Global_Row_Configuracion_General.Item("Nodo_Raiz_Asociados")

            _TblProductos = _Filtrar.Pro_Tbl_Filtro

            If Not _Filtrar.Pro_Filtro_Todas Then

                Dim _FiltroProductos As String = Generar_Filtro_IN(_TblProductos, "Chk", "Codigo", False, True, "'")

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_St_OT_Recetas_Prod Where Id_Rec = " & _Id_Rec & vbCrLf

                If Not IsNothing(_TblProductos) Then

                    For Each _Flprod As DataRow In _TblProductos.Rows

                        Dim _Codigo As String = _Flprod.Item("Codigo")

                        Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_St_OT_Recetas_Prod (Id_Rec,CodReceta,Codigo) Values " &
                                        "(" & _Id_Rec & ",'" & _CodReceta & "','" & _Codigo & "')" & vbCrLf

                    Next

                End If

                If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                    MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                Sb_Actualizar_Grilla_Productos(_Id_Rec)

            End If

        End If




















        'Dim _RowProducto As DataRow = Fx_Buscar_Producto("")

        'If Not IsNothing(_RowProducto) Then

        '    Dim _Codigo As String = _RowProducto.Item("KOPR")

        '    Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_St_OT_Recetas_Prod", "Codigo = '" & _Codigo & "' And Id_Rec = " & _Id_Rec)

        '    If CBool(_Reg) Then
        '        MessageBoxEx.Show(Me, "Este producto ya esta asociado a esta receta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '        Return
        '    End If



        'End If

    End Sub

    Function Fx_Buscar_Producto(_Codigo As String) As DataRow

        Dim _TblProducto As DataTable

        Dim _CodigoAlt = _Codigo
        _CodigoAlt = _Sql.Fx_Trae_Dato("TABCODAL", "KOPR", "KOEN = '' And KOPRAL = '" & _CodigoAlt & "'")

        If Not String.IsNullOrEmpty(_CodigoAlt) Then
            _Codigo = _CodigoAlt
        End If

        Consulta_sql = "Select top 1 * From MAEPR Where KOPR = '" & _Codigo & "'"
        _TblProducto = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_TblProducto.Rows.Count) Then
            Return _TblProducto.Rows(0)
        Else

            Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
            Fm.Pro_CodEntidad = String.Empty
            Fm.Pro_CodSucEntidad = String.Empty
            Fm.Pro_Tipo_Lista = "P"
            'Fm.Pro_Lista_Busqueda = ModListaPrecioVenta
            Fm.Pro_Sucursal_Busqueda = ModSucursal
            Fm.Pro_Bodega_Busqueda = ModBodega
            Fm.Txtdescripcion.Text = _Codigo
            Fm.Pro_Mostrar_Info = True
            Fm.Pro_Actualizar_Precios = True

            Codigo_abuscar = String.Empty
            Fm.Pro_Mostrar_Clasificaciones = True
            Fm.Pro_Mostrar_Imagenes = True

            Fm.Pro_Filtro_Sql_Extra = "And TIPR = 'SSN'"

            Fm.ShowDialog(Me)

            If Fm.Pro_Seleccionado Then
                '_TblProducto = Fm.Pro_RowProducto
                Return Fm.Pro_RowProducto '_TblProducto.Rows(0)
            Else
                Return Nothing
            End If

        End If

    End Function


End Class
