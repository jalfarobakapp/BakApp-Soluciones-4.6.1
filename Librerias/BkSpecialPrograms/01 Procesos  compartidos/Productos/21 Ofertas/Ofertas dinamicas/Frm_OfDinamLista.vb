Imports DevComponents.DotNetBar
Public Class Frm_OfDinamLista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Maeeres As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Recetas, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Productos, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_OfDinamLista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla_Ofertas()

        AddHandler Grilla_Recetas.MouseDown, AddressOf Sb_Grilla_Recetas_MouseDown
        AddHandler Grilla_Productos.MouseDown, AddressOf Sb_Grilla_Productos_MouseDown

        Txt_BuscaXProducto.ButtonCustom2.Visible = False
        Txt_BuscaXProducto.ButtonCustom.Visible = True

    End Sub

    Sub Sb_Actualizar_Grilla_Ofertas()

        Dim _Texto_Busqueda As String = Txt_Buscador.Text.Trim
        Dim _Condicion As String = String.Empty

        Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(_Texto_Busqueda), "CODIGO+DESCRIPTOR Like '%")

        If Not String.IsNullOrWhiteSpace(Txt_BuscaXProducto.Text) Then
            _Condicion = "And CODIGO In (Select CODIGO From MAEDRES Where ELEMENTO = '" & Txt_BuscaXProducto.Text & "')"
        End If

        Consulta_sql = "Select * From MAEERES Where TIPORESE = 'din' And CODIGO+DESCRIPTOR Like '%" & _Cadena & "%'" & vbCrLf & _Condicion

        _Tbl_Maeeres = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Codigo As String

        If CBool(_Tbl_Maeeres.Rows.Count) Then
            _Codigo = _Tbl_Maeeres.Rows(0).Item("CODIGO")
        End If

        Sb_Actualizar_Grilla_Productos(_Codigo)

        With Grilla_Recetas

            .DataSource = _Tbl_Maeeres

            OcultarEncabezadoGrilla(Grilla_Recetas, True)

            .Columns("CODIGO").Visible = True
            .Columns("CODIGO").HeaderText = "Código"
            .Columns("CODIGO").Width = 100
            .Columns("CODIGO").DisplayIndex = 0

            .Columns("DESCRIPTOR").Visible = True
            .Columns("DESCRIPTOR").HeaderText = "Nombre del tipo de descuento oferta"
            .Columns("DESCRIPTOR").Width = 300
            .Columns("DESCRIPTOR").DisplayIndex = 1

            .Columns("LISTAS").Visible = True
            .Columns("LISTAS").HeaderText = "Listas de precios válidas"
            .Columns("LISTAS").Width = 140
            .Columns("LISTAS").DisplayIndex = 2
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End With

    End Sub

    Sub Sb_Actualizar_Grilla_Productos(_Codigo As String)

        Consulta_sql = "Select Mprod.*,Mp.NOKOPR From MAEDRES Mprod" & vbCrLf &
                       "Left Join MAEPR Mp On Mp.KOPR = Mprod.ELEMENTO" & vbCrLf &
                       "Where CODIGO = '" & _Codigo & "'"
        Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Productos

            .DataSource = _Tbl_Productos

            OcultarEncabezadoGrilla(Grilla_Productos, True)

            .Columns("ELEMENTO").Visible = True
            .Columns("ELEMENTO").HeaderText = "Código"
            .Columns("ELEMENTO").Width = 100
            .Columns("ELEMENTO").DisplayIndex = 0

            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Width = 390 + 50
            .Columns("NOKOPR").DisplayIndex = 1

        End With

    End Sub

    Private Sub Grilla_Recetas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Recetas.CellDoubleClick

        If Not Fx_Tiene_Permiso(Me, "Ofer0003") Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla_Recetas.CurrentRow

        Dim _Codigo As String = _Fila.Cells("CODIGO").Value
        Dim _Grabar As Boolean
        Dim _Eliminado As Boolean
        Dim _Row_Maeeres As DataRow

        Dim Fm As New Frm_OfDinamFicha(_Codigo)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _Eliminado = Fm.Eliminado
        _Row_Maeeres = Fm.Row_Maeeres
        Fm.Dispose()

        If _Grabar Then
            If _Eliminado Then
                Sb_Actualizar_Grilla_Ofertas()
            Else
                _Fila.Cells("DESCRIPTOR").Value = _Row_Maeeres.Item("DESCRIPTOR")
                _Fila.Cells("LISTAS").Value = _Row_Maeeres.Item("LISTAS")
            End If
        End If

    End Sub

    Private Sub Grilla_Recetas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Recetas.CellEnter

        Dim _Fila As DataGridViewRow = Grilla_Recetas.CurrentRow
        Dim _Codigo As String = _Fila.Cells("CODIGO").Value

        Sb_Actualizar_Grilla_Productos(_Codigo)

    End Sub

    Private Sub Btn_Crear_Receta_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Receta.Click

        If Not Fx_Tiene_Permiso(Me, "Ofer0002") Then
            Return
        End If

        Txt_Buscador.Text = String.Empty
        Txt_BuscaXProducto.Text = String.Empty

        Dim _Grabar As Boolean
        Dim _Row_Maeeres As DataRow

        Dim Fm As New Frm_OfDinamFicha("")
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _Row_Maeeres = Fm.Row_Maeeres
        Fm.Dispose()

        If _Grabar Then
            Sb_Actualizar_Grilla_Ofertas()
            BuscarDatoEnGrilla(_Row_Maeeres.Item("CODIGO"), "CODIGO", Grilla_Recetas)
        End If

    End Sub

    Private Sub Btn_Mnu_EditarOferta_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_EditarOferta.Click
        Call Grilla_Recetas_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Btn_Mnu_AsociarProductos_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_AsociarProductos.Click

        If Not Fx_Tiene_Permiso(Me, "Ofer0005") Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla_Recetas.CurrentRow

        Dim _Codigo As String = _Fila.Cells("CODIGO").Value

        Consulta_sql = "Select Cast(1 As Bit) As Chk,ELEMENTO As Codigo,NOKOPR As Descripcion,NREG" & vbCrLf &
                       "From MAEDRES" & vbCrLf &
                       "Left Join MAEPR On KOPR = ELEMENTO" & vbCrLf &
                       "Where CODIGO In (Select CODIGO From MAEERES Res Where TIPORESE = 'din' And Res.CODIGO = '" & _Codigo & "')" & vbCrLf &
                       "Order By NREG Desc"
        Dim _TblProductos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _FiltroProdExc As String = Generar_Filtro_IN(_TblProductos, "Chk", "Codigo", False, True, "'")

        Dim _FechaServidor As Date = FechaDelServidor()

        Dim _Sql_Filtro_Condicion_Extra = "And TIPR <> 'SSN' And KOPR Not In " &
                                          "(Select ELEMENTO From MAEDRES Where CODIGO In " &
                                          "(Select CODIGO From MAEERES Res Where TIPORESE = 'din' And FTOFERTA >= '" & Format(_FechaServidor, "yyyyMMdd") & "'))"
        Dim _Nreg = 0

        If CBool(_TblProductos.Rows.Count) Then
            _Sql_Filtro_Condicion_Extra += " And KOPR Not In " & _FiltroProdExc
            _Nreg = _TblProductos.Rows(0).Item("NREG")
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Filtro_Todas = False
        _Filtrar.Pro_Nombre_Encabezado_Informe = "SELECCIONAR PRODUCTOS (NO MUESTRA PRODUCTOS EN OFERTAS ACTIVAS)"

        If _Filtrar.Fx_Filtrar(_TblProductos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               False, False,, False,, False) Then

            Dim _Nodo_Raiz_Asociados As Integer = _Global_Row_Configuracion_General.Item("Nodo_Raiz_Asociados")

            _TblProductos = _Filtrar.Pro_Tbl_Filtro

            If Not _Filtrar.Pro_Filtro_Todas Then

                Dim _FiltroProductos As String = Generar_Filtro_IN(_TblProductos, "Chk", "Codigo", False, True, "'")

                Consulta_sql = String.Empty

                If Not IsNothing(_TblProductos) Then

                    For Each _Flprod As DataRow In _TblProductos.Rows

                        _Nreg += 1
                        Dim _Elemento As String = _Flprod.Item("Codigo")

                        Consulta_sql += "Insert Into MAEDRES (CODIGO,NREG,ELEMENTO) Values " &
                                        "('" & _Codigo & "'," & _Nreg & ",'" & _Elemento & "')" & vbCrLf

                    Next

                End If

                If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                    MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                Sb_Actualizar_Grilla_Productos(_Codigo)

            End If

        End If

    End Sub

    Private Sub Btn_Mnu_QuitarProducto_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_QuitarProducto.Click

        If Not Fx_Tiene_Permiso(Me, "Ofer0006") Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla_Productos.CurrentRow
        Dim _Codigo As String = _Fila.Cells("CODIGO").Value
        Dim _Elemento As String = _Fila.Cells("ELEMENTO").Value

        If MessageBoxEx.Show(Me, "¿Confirma quitar este producto de la oferta?", "Quitar productos",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_sql = "Delete From MAEDRES Where ELEMENTO = '" & _Elemento & "' AND CODIGO = '" & _Codigo & "'"
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Grilla_Productos.Rows.Remove(_Fila)
        End If

    End Sub

    Private Sub Sb_Grilla_Recetas_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_01)
                End If
            End With
        End If
    End Sub

    Private Sub Sb_Grilla_Productos_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_02)
                End If
            End With
        End If
    End Sub

    Private Sub Txt_Buscador_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Buscador.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla_Ofertas()
            If Not String.IsNullOrWhiteSpace(Txt_Buscador.Text) AndAlso Not CBool(Grilla_Recetas.RowCount) Then
                MessageBoxEx.Show(Me, "No se encontraron registros", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Private Sub Txt_BuscaXProducto_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_BuscaXProducto.ButtonCustomClick

        Txt_BuscaXProducto.Enabled = False

        Dim _RowProducto As DataRow = Fx_Buscar_Producto("")

        If Not IsNothing(_RowProducto) Then

            Txt_BuscaXProducto.ButtonCustom.Visible = False
            Txt_BuscaXProducto.ButtonCustom2.Visible = True

            Txt_BuscaXProducto.Text = _RowProducto.Item("KOPR")
            Sb_Actualizar_Grilla_Ofertas()
            If Not CBool(Grilla_Recetas.RowCount) Then
                MessageBoxEx.Show(Me, "No se encontraron registros", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If

        Txt_BuscaXProducto.Enabled = True

    End Sub

    Private Sub Txt_BuscaXProducto_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_BuscaXProducto.ButtonCustom2Click

        If String.IsNullOrEmpty(Txt_BuscaXProducto.Text.Trim) Then Return
        Txt_BuscaXProducto.Text = String.Empty
        Sb_Actualizar_Grilla_Ofertas()

        Txt_BuscaXProducto.ButtonCustom2.Visible = False
        Txt_BuscaXProducto.ButtonCustom.Visible = True

    End Sub

    Function Fx_Buscar_Producto(_Codigo As String) As DataRow

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

        Fm.Pro_Filtro_Sql_Extra = "And TIPR <> 'SSN'"

        Fm.ShowDialog(Me)

        If Fm.Pro_Seleccionado Then
            Return Fm.Pro_RowProducto
        Else
            Return Nothing
        End If

        'End If

    End Function

    Private Sub Txt_Buscador_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Buscador.ButtonCustom2Click
        Txt_Buscador.Text = String.Empty
        Sb_Actualizar_Grilla_Ofertas()
    End Sub
End Class
