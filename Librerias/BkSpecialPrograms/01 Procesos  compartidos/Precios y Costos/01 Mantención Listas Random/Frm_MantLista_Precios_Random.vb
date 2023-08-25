Imports DevComponents.DotNetBar

Public Class Frm_MantLista_Precios_Random

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Nombre_Tbl_Paso_Precios = "Zw_PsLp" & FUNCIONARIO

    Dim _Cancelar As Boolean

    Dim _TblTabpre As DataTable
    Dim _Tbl_Precios As DataTable
    Dim _Tbl_Listas_Seleccionadas As DataTable

    Dim _Tbl_Productos_Seleccionados As DataTable

    Dim _Filtro_Productos_Todos As Boolean
    Dim _Filtro_Marcas_Todas As Boolean
    Dim _Filtro_Super_Familias_Todas As Boolean
    Dim _Filtro_Rubro_Todas As Boolean
    Dim _Filtro_Clalibpr_Todas As Boolean
    Dim _Filtro_Zonas_Todas As Boolean
    Dim _Filtro_Bodegas_Todas As Boolean

    Dim _Tbl_Filtro_Productos As DataTable
    Dim _Tbl_Filtro_Super_Familias As DataTable
    Dim _Tbl_Filtro_Marcas As DataTable
    Dim _Tbl_Filtro_Rubro As DataTable
    Dim _Tbl_Filtro_Clalibpr As DataTable
    Dim _Tbl_Filtro_Zonas As DataTable

    Dim _RowProducto As DataRow

    Dim _Cerrar_Al_Grabar As Boolean
    Dim _Grabacion_Realizada As Boolean

    Dim _Txt_Log As New TextBox

    Dim _Lista_Campos_Adicionales As New List(Of ListaDePrecios.LsCamposAdicionalesTabpre) ' ' List(Of String)

    Public ReadOnly Property Pro_Grabacion_Realizada() As Boolean
        Get
            Return _Grabacion_Realizada
        End Get
    End Property

    Public Sub New(Tbl_Listas_Seleccionadas As DataTable,
                   RowProducto As DataRow,
                   Cerrar_Al_Grabar As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, False, False)

        _Cerrar_Al_Grabar = Cerrar_Al_Grabar
        _Tbl_Listas_Seleccionadas = Tbl_Listas_Seleccionadas
        _RowProducto = RowProducto

        Sb_Limpiar()

        Sb_Color_Botones_Barra(Barra_Arriba)
        Sb_Color_Botones_Barra(Barra_Abajo)

        Rdb_Traer_Todos.Checked = True
        Sb_Parametros_Informe_Sql(False)

    End Sub

    Private Sub Frm_MantLista_Precios_Random_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        Consulta_sql = "Drop table " & _Nombre_Tbl_Paso_Precios
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Sb_Parametros_Informe_Sql(True)

    End Sub

    Private Sub Frm_MantLista_Precios_Random_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        AddHandler Grilla.CellEnter, AddressOf Sb_Grilla_CellEnter
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla.CellEndEdit, AddressOf Sb_Grilla_CellEndEdit
        AddHandler Grilla.CellMouseUp, AddressOf Sb_Grilla_CellMouseUp
        AddHandler Grilla.EditingControlShowing, AddressOf Sb_Grilla_EditingControlShowing
        AddHandler Grilla.KeyDown, AddressOf Sb_Grilla_KeyDown
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint ' Sb_Grilla_RowsPostPaint

        AddHandler Btn_Estadisticas_Producto_01.Click, AddressOf Sb_Btn_Estadisticas_Producto_Click
        AddHandler Btn_Estadisticas_Producto_02.Click, AddressOf Sb_Btn_Estadisticas_Producto_Click
        AddHandler Btn_Estadisticas_Producto_03.Click, AddressOf Sb_Btn_Estadisticas_Producto_Click

        AddHandler Rdb_Traer_No_Bloqueados.CheckedChanged, AddressOf Sb_Rdb_Traer_Bloqueados_CheckedChanged
        AddHandler Rdb_Traer_Todos.CheckedChanged, AddressOf Sb_Rdb_Traer_Bloqueados_CheckedChanged
        AddHandler Rdb_Traer_Bloqueados_Compras.CheckedChanged, AddressOf Sb_Rdb_Traer_Bloqueados_CheckedChanged
        AddHandler Rdb_Traer_Bloqueados_Venta.CheckedChanged, AddressOf Sb_Rdb_Traer_Bloqueados_CheckedChanged
        AddHandler Rdb_Traer_Bloqueados_Compra_y_Venta.CheckedChanged, AddressOf Sb_Rdb_Traer_Bloqueados_CheckedChanged
        AddHandler Rdb_Traer_Bloqueados_Compra_Venta_y_Produccion.CheckedChanged, AddressOf Sb_Rdb_Traer_Bloqueados_CheckedChanged

        Rdb_Traer_Bloqueados_Compras.Enabled = False
        Rdb_Traer_Bloqueados_Compra_Venta_y_Produccion.Enabled = False
        Rdb_Traer_Bloqueados_Compra_y_Venta.Enabled = False
        Rdb_Traer_Bloqueados_Venta.Enabled = False
        Rdb_Traer_No_Bloqueados.Enabled = False
        Rdb_Traer_Todos.Enabled = False

        If Not (_RowProducto Is Nothing) Then

            Dim _Codigo = _RowProducto.Item("KOPR")
            Sb_Trae_un_solo_producto(_Codigo)

            Btn_Sel_Productos.Enabled = False
            Btn_Limpiar.Enabled = False
            Btn_Buscar_Producto_En_Grilla.Enabled = False

        End If

        Btn_Ejecutar_Formula.Enabled = False
        Btn_Imprimir_Maestra.Visible = (RutEmpresa = "85904700-9")

        If Rdb_Traer_Bloqueados_Compras.Checked Then Btn_ProdBloqueados.Text = Rdb_Traer_Bloqueados_Compras.Text
        If Rdb_Traer_Bloqueados_Compra_Venta_y_Produccion.Checked Then Btn_ProdBloqueados.Text = Rdb_Traer_Bloqueados_Compra_Venta_y_Produccion.Text
        If Rdb_Traer_Bloqueados_Compra_y_Venta.Checked Then Btn_ProdBloqueados.Text = Rdb_Traer_Bloqueados_Compra_y_Venta.Text
        If Rdb_Traer_Bloqueados_Venta.Checked Then Btn_ProdBloqueados.Text = Rdb_Traer_Bloqueados_Venta.Text
        If Rdb_Traer_No_Bloqueados.Checked Then Btn_ProdBloqueados.Text = Rdb_Traer_No_Bloqueados.Text
        If Rdb_Traer_Todos.Checked Then Btn_ProdBloqueados.Text = Rdb_Traer_Todos.Text

        Chk_GrabarPreciosHistoricos.Checked = _Global_Row_Configuracion_General.Item("GrabarPreciosHistoricos")
        Chk_NoguardarTABPRE.Visible = Chk_GrabarPreciosHistoricos.Checked
        Chk_NoguardarTABPRE.Enabled = Chk_GrabarPreciosHistoricos.Checked

    End Sub

    Sub Sb_Crear_Tabla_De_Paso()

        Consulta_sql = "Drop table " & _Nombre_Tbl_Paso_Precios
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Select Top 1 * From TABPRE"
        _TblTabpre = _Sql.Fx_Get_Tablas(Consulta_sql)

        _Lista_Campos_Adicionales.Clear()
        _Lista_Campos_Adicionales = New List(Of ListaDePrecios.LsCamposAdicionalesTabpre)

        ' Asi es como actua el campo OPERA, este campo define como se comportaran los campos adicionales a partir del campo nro 29 en adelante

        '       28 Ultimo Campo EDTMA02UD

        '        '' = Descuento Porcentaje
        '        1  = Descuento Valor
        '        2  = Recargo Porcentaje
        '        3  = Recargo Valor

        Dim _Campos_Adicionales = String.Empty

        Dim _Campo = String.Empty
        Dim _Campofx = String.Empty

        Dim _Cmp = False

        For _i = 28 To _TblTabpre.Columns.Count - 1

            Dim _Columna As DataColumn = _TblTabpre.Columns(_i)
            Dim _Nombre_Columna As String = _Columna.ColumnName

            Dim _CamposAdicionales As New ListaDePrecios.LsCamposAdicionalesTabpre

            If Mid(_Nombre_Columna, 1, 5) = "FORM_" Then
                _Campofx = _Nombre_Columna
                _Campos_Adicionales += "[" & _Nombre_Columna & "] [CHAR] (121) Default ''," & vbCrLf
                _Cmp = True
            Else
                _Campo = _Nombre_Columna
                _Campos_Adicionales += "[" & _Nombre_Columna & "] [Float] Default (0)," & vbCrLf
                _Cmp = False
                '_Lista_Campos_Adicionale.Add(_Nombre_Columna)
            End If

            If _Cmp Then
                _CamposAdicionales.Campo = _Campo
                _CamposAdicionales.CampoFx = _Campofx
                _Lista_Campos_Adicionales.Add(_CamposAdicionales)
            End If

        Next

        Consulta_sql = My.Resources.Recursos_LP.SQLQuery_Cargar_LP_New
        Consulta_sql = Replace(Consulta_sql, "#Tbl_Paso_LP#", _Nombre_Tbl_Paso_Precios)
        Consulta_sql = Replace(Consulta_sql, "#Campos_Adicioanles#", _Campos_Adicionales)
        Consulta_sql += vbCrLf &
                       "Select * From " & _Nombre_Tbl_Paso_Precios

        _Tbl_Precios = _Sql.Fx_Get_Tablas(Consulta_sql)

        Sb_Formato_Grilla()

    End Sub

    Sub Sb_Formato_Grilla()

        If (_Tbl_Precios Is Nothing) Then
            Consulta_sql = "Truncate table " & _Nombre_Tbl_Paso_Precios & vbCrLf &
                      "Select * From " & _Nombre_Tbl_Paso_Precios
            _Tbl_Precios = _Sql.Fx_Get_Tablas(Consulta_sql)
        End If

        Grilla.DataSource = _Tbl_Precios

        With Grilla

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Select").Width = 30
            .Columns("Select").HeaderText = "S."
            '.Columns("Select").Frozen = True
            .Columns("Select").ReadOnly = False
            .Columns("Select").Visible = True

            .Columns("KOLT").Width = 30
            .Columns("KOLT").HeaderText = "LP"
            .Columns("KOLT").ReadOnly = True
            ' .Columns("Lista").Frozen = True
            .Columns("KOLT").Visible = True

            .Columns("KOPR").Width = 100
            .Columns("KOPR").HeaderText = "Código"
            .Columns("KOPR").ReadOnly = True
            '.Columns("KOPR").Frozen = True
            .Columns("KOPR").Visible = True

            '.Columns("NOKOPR").Width = 200
            '.Columns("NOKOPR").HeaderText = "Descripción"
            '.Columns("NOKOPR").ReadOnly = True
            '.Columns("NOKOPR").Frozen = True
            '.Columns("NOKOPR").Visible = True

            .Columns("PP01UD").Width = 80
            .Columns("PP01UD").HeaderText = "Precio Ud1"
            .Columns("PP01UD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PP01UD").DefaultCellStyle.Format = "$ ###,##.######"
            '.Columns("PP01UD").Frozen = True
            .Columns("PP01UD").Visible = True

            .Columns("MG01UD").Width = 50
            .Columns("MG01UD").HeaderText = "Margen Ud1%"
            .Columns("MG01UD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("MG01UD").DefaultCellStyle.Format = "###,##.####"
            '.Columns("MG01UD").Frozen = True
            .Columns("MG01UD").Visible = True

            .Columns("DTMA01UD").Width = 50
            .Columns("DTMA01UD").HeaderText = "%Desc. Max.1"
            .Columns("DTMA01UD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DTMA01UD").DefaultCellStyle.Format = "###,##.####"
            '.Columns("DTMA01UD").Frozen = True
            .Columns("DTMA01UD").Visible = True


            .Columns("PP02UD").Width = 80
            .Columns("PP02UD").HeaderText = "Precio Ud2"
            .Columns("PP02UD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PP02UD").DefaultCellStyle.Format = "$ ###,##.######"
            '.Columns("PP02UD").Frozen = True
            .Columns("PP02UD").Visible = True

            .Columns("MG02UD").Width = 50
            .Columns("MG02UD").HeaderText = "Margen Ud2%"
            .Columns("MG02UD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("MG02UD").DefaultCellStyle.Format = "###,##.####"
            '.Columns("MG02UD").Frozen = True
            .Columns("MG02UD").Visible = True

            .Columns("DTMA02UD").Width = 50
            .Columns("DTMA02UD").HeaderText = "%Desc. Max.2"
            .Columns("DTMA02UD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DTMA02UD").DefaultCellStyle.Format = "###,##.####"
            '.Columns("DTMA02UD").Frozen = True
            .Columns("DTMA02UD").Visible = True


            For _i = 28 To _TblTabpre.Columns.Count - 1

                Dim _Columna As DataColumn = _TblTabpre.Columns(_i)
                Dim _Nombre_Columna As String = _Columna.ColumnName

                If Mid(_Nombre_Columna, 1, 5) <> "FORM_" Then

                    .Columns(_Nombre_Columna).Width = 80
                    .Columns(_Nombre_Columna).HeaderText = _Nombre_Columna
                    .Columns(_Nombre_Columna).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(_Nombre_Columna).DefaultCellStyle.Format = "###,##.##"
                    .Columns(_Nombre_Columna).Visible = True

                End If

            Next

        End With

    End Sub

    Sub Sb_Trae_un_solo_producto(_Codigo As String)

        If String.IsNullOrEmpty(_Codigo) Then

            Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
            Fm.Pro_Actualizar_Precios = True
            Fm.Pro_Mostrar_Info = True
            Fm.BtnBuscarAlternativos.Visible = True
            Fm.Pro_Mostrar_Imagenes = True
            Fm.BtnCrearProductos.Visible = False
            Fm.Pro_Mostrar_Editar = True
            Fm.Pro_Mostrar_Eliminar = False
            Fm.BtnExportaExcel.Visible = False
            Fm.Pro_Tipo_Lista = "P"
            Fm.Pro_Maestro_Productos = False
            Fm.Pro_Sucursal_Busqueda = ModSucursal
            Fm.Pro_Bodega_Busqueda = ModBodega
            Fm.Pro_Lista_Busqueda = _Tbl_Listas_Seleccionadas.Rows(0).Item("KOLT")

            'If Rdb_Traer_Bloqueados_Compras.Checked Then
            '    Fm.Bloqueados = Frm_BkpPostBusquedaEspecial_Mt.Enum_Bloquear.Compras
            'End If

            'If Rdb_Traer_Bloqueados_Venta.Checked Then
            '    Fm.Bloqueados = Frm_BkpPostBusquedaEspecial_Mt.Enum_Bloquear.Ventas
            'End If

            'If Rdb_Traer_Bloqueados_Compra_y_Venta.Checked Then
            '    Fm.Bloqueados = Frm_BkpPostBusquedaEspecial_Mt.Enum_Bloquear.Compras_y_Ventas
            'End If

            'If Rdb_Traer_Bloqueados_Compra_Venta_y_Produccion.Checked Then
            '    Fm.Bloqueados = Frm_BkpPostBusquedaEspecial_Mt.Enum_Bloquear.Compras_Ventas_y_Produccion
            'End If

            'If Rdb_Traer_No_Bloqueados.Checked Then
            '    Fm.Bloqueados = Frm_BkpPostBusquedaEspecial_Mt.Enum_Bloquear.No_Bloquear
            'End If

            'If Rdb_Traer_No_Bloqueados.Checked Then
            '    Fm.Bloqueados = Frm_BkpPostBusquedaEspecial_Mt.Enum_Bloquear.No_Bloqueados
            'End If

            Fm.ShowDialog(Me)

            If Fm.Pro_Seleccionado Then

                _Codigo = Fm.Pro_RowProducto.Item("KOPR")

                Dim _Bloqueapr As String = Fm.Pro_RowProducto.Item("BLOQUEAPR")
                Dim _RevBloqueo As Boolean = False
                Dim _Msg As String

                If Rdb_Traer_Bloqueados_Compras.Checked Then
                    If _Bloqueapr = "V" Or _Bloqueapr = "T" Or _Bloqueapr = "X" Then _RevBloqueo = True
                End If

                If Rdb_Traer_Bloqueados_Venta.Checked Then
                    If _Bloqueapr = "C" Or _Bloqueapr = "T" Or _Bloqueapr = "X" Then _RevBloqueo = True
                End If

                If Rdb_Traer_Bloqueados_Compra_y_Venta.Checked Then
                    If _Bloqueapr = "X" Then _RevBloqueo = True
                End If

                If Rdb_Traer_Bloqueados_Compra_Venta_y_Produccion.Checked Then
                    If _Bloqueapr = "C" Or _Bloqueapr = "V" Or _Bloqueapr = "T" Then _RevBloqueo = True
                End If

                If Rdb_Traer_No_Bloqueados.Checked Then
                    If Not String.IsNullOrEmpty(_Bloqueapr) Then
                        If _Bloqueapr = "C" Or _Bloqueapr = "V" Or _Bloqueapr = "T" Or _Bloqueapr = "X" Then _RevBloqueo = True
                    End If
                End If

                If _RevBloqueo Then
                    If _Bloqueapr = "C" Then _Msg = "compras"
                    If _Bloqueapr = "V" Then _Msg = "ventas"
                    If _Bloqueapr = "T" Then _Msg = "compras y ventas"
                    If _Bloqueapr = "X" Then _Msg = "compras, ventas y producción"
                    MessageBoxEx.Show(Me, "Producto bloqueado para utilizar en " & _Msg, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    _Codigo = String.Empty
                End If

            End If

            Fm.Dispose()

        End If

        If Not String.IsNullOrEmpty(_Codigo.Trim) Then

            Dim _Traer_Producto = True

            For Each _Fila As DataRow In _Tbl_Listas_Seleccionadas.Rows

                Dim _Kolt = _Fila.Item("KOLT")

                Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("TABPRE", "KOLT = '" & _Kolt & "' And KOPR = '" & _Codigo & "'"))

                If Not _Reg Then
                    _Traer_Producto = False
                    Exit For
                End If

            Next

            If _Traer_Producto Then

                Consulta_sql = "Select KOPR As Codigo From MAEPR Where KOPR = '" & _Codigo.Trim & "'"
                _Tbl_Productos_Seleccionados = _Sql.Fx_Get_Tablas(Consulta_sql)

                Sb_Traer_Productos_Al_Tratamiento(False)

            Else

                MessageBoxEx.Show(Me, "El producto no esta asociado a una de las listas seleccionadas", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

        End If

    End Sub

    Sub Sb_Busqueda_Selectiva()

        Dim _Filtro_Listas As String = Generar_Filtro_IN(_Tbl_Listas_Seleccionadas, "", "KOLT", False, False, "'")

        Dim _Sql_Filtro_Condicion_Extra = "And KOPR In (Select KOPR From TABPRE Where KOLT In " & _Filtro_Listas & ")"

        If Rdb_Traer_No_Bloqueados.Checked Then
            _Sql_Filtro_Condicion_Extra += Rdb_Traer_No_Bloqueados.Tag.ToString
        End If

        If Rdb_Traer_Bloqueados_Compras.Checked Then
            _Sql_Filtro_Condicion_Extra += Rdb_Traer_Bloqueados_Compras.Tag.ToString
        End If

        If Rdb_Traer_Bloqueados_Venta.Checked Then
            _Sql_Filtro_Condicion_Extra += Rdb_Traer_Bloqueados_Venta.Tag.ToString
        End If

        If Rdb_Traer_Bloqueados_Compra_y_Venta.Checked Then
            _Sql_Filtro_Condicion_Extra += Rdb_Traer_Bloqueados_Compra_y_Venta.Tag.ToString
        End If

        If Rdb_Traer_Bloqueados_Compra_Venta_y_Produccion.Checked Then
            _Sql_Filtro_Condicion_Extra += Rdb_Traer_Bloqueados_Compra_Venta_y_Produccion.Tag.ToString
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            _Tbl_Productos_Seleccionados = _Filtrar.Pro_Tbl_Filtro
            If _Filtrar.Pro_Filtro_Todas Then
                Consulta_sql = "SELECT KOPR AS 'Codigo', NOKOPR AS 'Descripcion' FROM MAEPR WHERE TIPR = 'FPN'"
                _Tbl_Productos_Seleccionados = _Sql.Fx_Get_Tablas(Consulta_sql)
            End If

            Sb_Traer_Productos_Al_Tratamiento(True)

        End If

    End Sub

    Sub Sb_Traer_Productos_Al_Tratamiento(_Traer_Productos_Selectivamente As Boolean)

        Try

            Sb_Habilitar_Deshabilitar_Comandos(False, False)

            Dim _Filtro_Listas As String = Generar_Filtro_IN(_Tbl_Listas_Seleccionadas, "", "KOLT", False, False, "'")
            Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_Productos_Seleccionados, "", "Codigo", False, False, "'")

            Dim _CantListas = _Tbl_Listas_Seleccionadas.Rows.Count

            _Txt_Log.Text = String.Empty

            Consulta_sql = String.Empty

            If _Traer_Productos_Selectivamente Then

                Circular_Progres_Val.Maximum = _Tbl_Productos_Seleccionados.Rows.Count

                Dim _Contador = 0

                Sb_Habilitar_Deshabilitar_Comandos(False, True)
                Lbl_Procesando.Text = "IMPORTANDO PRODUCTOS..."

                For Each _Fila As DataRow In _Tbl_Productos_Seleccionados.Rows

                    Dim _Codigo = _Fila.Item("Codigo")

                    Consulta_sql += My.Resources.Recursos_LP.SQLQuery_Traer_Productos_LP_New
                    Consulta_sql = Replace(Consulta_sql, "#Filtro_Productos#", "And Mp.KOPR = '" & _Codigo & "'")
                    Consulta_sql = Replace(Consulta_sql, "#Listas#", _Filtro_Listas)
                    Consulta_sql = Replace(Consulta_sql, "#Tbl_Paso_LP#", _Nombre_Tbl_Paso_Precios)

                    Sb_AgregarProdSinListaAsociada(_Codigo, _Filtro_Listas)

                    _Contador += 1
                    Circular_Progres_Porc.Value = ((_Contador * 100) / Circular_Progres_Val.Maximum) 'Mas
                    Circular_Progres_Val.Value = _Contador
                    Circular_Progres_Val.ProgressText = _Contador

                    If Not String.IsNullOrEmpty(_Txt_Log.Text) Then
                        Circular_Progres_Porc.ProgressColor = Rojo
                        Circular_Progres_Val.ProgressColor = Rojo
                    End If

                    Application.DoEvents()

                    If _Cancelar Then
                        Sb_Limpiar()
                        Return
                    End If

                Next

                Sb_Habilitar_Deshabilitar_Comandos(True, False)

            Else

                Dim _Count = _Tbl_Productos_Seleccionados.Rows.Count

                If _Count > 1 Then

                    If MessageBoxEx.Show(Me, FormatNumber(_Count, 0) & " Productos encontrados" & vbCrLf &
                                         "¿Desea agregarlos en el tratamiento?", "Traer Productos",
                                       MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Cancel Then
                        Sb_Habilitar_Deshabilitar_Comandos(True, False)
                        Return
                    End If

                End If

                Consulta_sql = "Truncate table " & _Nombre_Tbl_Paso_Precios & vbCrLf
                Consulta_sql += My.Resources.Recursos_LP.SQLQuery_Traer_Productos_LP_New
                Consulta_sql = Replace(Consulta_sql, "#Filtro_Productos#", "And Mp.KOPR In " & _Filtro_Productos)
                Consulta_sql = Replace(Consulta_sql, "#Listas#", _Filtro_Listas)
                Consulta_sql = Replace(Consulta_sql, "#Tbl_Paso_LP#", _Nombre_Tbl_Paso_Precios)

            End If

            Dim _Otros_Campos1 = String.Empty
            Dim _Otros_Campos2 = String.Empty

            'For Each _Campo As String In _Lista_Campos_Adicionales

            '    _Otros_Campos1 += "," & _Campo
            '    _Otros_Campos2 += ",Tp." & _Campo

            'Next

            For Each _Campos As ListaDePrecios.LsCamposAdicionalesTabpre In _Lista_Campos_Adicionales

                _Otros_Campos1 += "," & _Campos.Campo & "," & _Campos.CampoFx
                _Otros_Campos2 += ",Tp." & _Campos.Campo & ",Tp." & _Campos.CampoFx

            Next

            'Of ListaDePrecios.LsCamposAdicionalesTabpre

            If Not String.IsNullOrEmpty(_Txt_Log.Text) Then

                MessageBoxEx.Show(Me, "Existen productos que no estan asociados a una lista de precios seleccionada" & vbCrLf &
                                      "a continuación se mostrar una lista con los errores",
                                      "Importar datos", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Dim Fm As New Frm_Archivo_TXT
                Fm.Pro_Nombre_Archivo = "Error_LevLista_X_Codigo.txt"
                Fm.Pro_Texto_Log = _Txt_Log.Text
                Fm.ShowDialog(Me)
                Fm.Dispose()

                If MessageBoxEx.Show(Me, "¿Desae igualmente cargar los productos sin problema?", "Importar datos",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                    Return
                End If

            End If

            Dim Fm_Espera As New Frm_Form_Esperar
            Fm_Espera.BarraCircular.IsRunning = True
            Fm_Espera.Show()

            Consulta_sql = Replace(Consulta_sql, "#Otros_Campos1#", _Otros_Campos1)
            Consulta_sql = Replace(Consulta_sql, "#Otros_Campos2#", _Otros_Campos2)

            Consulta_sql += My.Resources.Recursos_LP.SQLQuery_Actualizar_Costos_Impuestos_New
            Consulta_sql = Replace(Consulta_sql, "#Tbl_Paso_LP#", _Nombre_Tbl_Paso_Precios)
            Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
            Consulta_sql = Replace(Consulta_sql, "#Sucursal#", ModSucursal)

            Consulta_sql += vbCrLf & "Select * From " & _Nombre_Tbl_Paso_Precios

            _Tbl_Precios = _Sql.Fx_Get_Tablas(Consulta_sql)

            Sb_Formato_Grilla()

            Fm_Espera.Close()

        Catch ex As Exception
        Finally
            Sb_Habilitar_Deshabilitar_Comandos(True, False)
        End Try

    End Sub

    Sub Sb_AgregarProdSinListaAsociada(_Codigo As String, _Filtro_Listas As String)

        Dim _SqlQuery1 = "Select KOLT From TABPP" & vbCrLf &
                 "Where KOLT Not In (Select KOLT From TABPRE Where KOLT In " & _Filtro_Listas & " And KOPR = '" & _Codigo & "')" & vbCrLf &
                 "And KOLT In " & _Filtro_Listas
        Dim _ListaSinAsig As DataTable = _Sql.Fx_Get_Tablas(_SqlQuery1)

        If _ListaSinAsig.Rows.Count Then

            Dim _Filtro_Listas_NoAsig As String = Generar_Filtro_IN(_ListaSinAsig, "", "KOLT", False, False, "'")
            Dim _Msg As String = "Código: " & _Codigo & ", lista(s) no asignada(s): " & _Filtro_Listas_NoAsig

            Sb_AddToLog("Código: " & _Codigo, "Problema!. No esta asignado a la(s) lista(s): " & _Filtro_Listas_NoAsig, _Txt_Log, False)

        End If

    End Sub

    Private Sub Btn_Busqueda_Selectiva_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Busqueda_Selectiva.Click
        Sb_Busqueda_Selectiva()
    End Sub

    Private Sub Btn_Buscar_Un_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Buscar_Un_Producto.Click
        Sb_Trae_un_solo_producto("")
    End Sub

    Private Sub BtnBusquedaClass_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Busqueda_Class.Click

        If Grilla.RowCount > 0 Then

            If MessageBoxEx.Show(Me, "Esta acción limpiara la lista actual" & vbCrLf &
                              "¿Desea continuar con la operación?", "Buscar productos",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return
            End If

        End If

        Dim Fm As New Frm_Filtro_Especial_Productos

        Fm.Pro_Filtro_Productos_Todos = _Filtro_Productos_Todos
        Fm.Pro_Filtro_Clalibpr_Todas = _Filtro_Clalibpr_Todas
        Fm.Pro_Filtro_Marcas_Todas = _Filtro_Marcas_Todas
        Fm.Pro_Filtro_Rubro_Todas = _Filtro_Rubro_Todas
        Fm.Pro_Filtro_Super_Familias_Todas = _Filtro_Super_Familias_Todas
        Fm.Pro_Filtro_Zonas_Todas = _Filtro_Zonas_Todas

        Fm.Pro_Tbl_Filtro_Productos = _Tbl_Filtro_Productos
        Fm.Pro_Tbl_Filtro_Clalibpr = _Tbl_Filtro_Clalibpr
        Fm.Pro_Tbl_Filtro_Marcas = _Tbl_Filtro_Marcas
        Fm.Pro_Tbl_Filtro_Rubro = _Tbl_Filtro_Rubro
        Fm.Pro_Tbl_Filtro_Super_Familias = _Tbl_Filtro_Super_Familias
        Fm.Pro_Tbl_Filtro_Zonas = _Tbl_Filtro_Zonas

        Fm.ShowDialog(Me)



        _Tbl_Filtro_Productos = Fm.Pro_Tbl_Filtro_Productos
        _Tbl_Filtro_Clalibpr = Fm.Pro_Tbl_Filtro_Clalibpr
        _Tbl_Filtro_Marcas = Fm.Pro_Tbl_Filtro_Marcas
        _Tbl_Filtro_Rubro = Fm.Pro_Tbl_Filtro_Rubro
        _Tbl_Filtro_Super_Familias = Fm.Pro_Tbl_Filtro_Super_Familias
        _Tbl_Filtro_Zonas = Fm.Pro_Tbl_Filtro_Zonas

        _Filtro_Productos_Todos = Fm.Pro_Filtro_Productos_Todos
        _Filtro_Clalibpr_Todas = Fm.Pro_Filtro_Clalibpr_Todas
        _Filtro_Marcas_Todas = Fm.Pro_Filtro_Marcas_Todas
        _Filtro_Rubro_Todas = Fm.Pro_Filtro_Rubro_Todas
        _Filtro_Super_Familias_Todas = Fm.Pro_Filtro_Super_Familias_Todas
        _Filtro_Zonas_Todas = Fm.Pro_Filtro_Zonas_Todas

        Fm.Dispose()

        '---- FILTROS -------------------------------

        Dim _Filtro_Productos = String.Empty
        Dim _Filtro_Rubros = String.Empty
        Dim _Filtro_Marcas = String.Empty
        Dim _Filtro_Zonas = String.Empty
        Dim _Filtro_SuperFamilias = String.Empty
        Dim _Filtro_ClasLibre = String.Empty
        Dim _Filtro_Bodega = String.Empty


        If _Filtro_Productos_Todos Then

            If Not _Filtro_Rubro_Todas Then
                _Filtro_Rubros = Generar_Filtro_IN(_Tbl_Filtro_Rubro, "Chk", "Codigo", False, True, "'")
                _Filtro_Rubros = "And KOPR IN (Select KOPR From MAEPR Where RUPR In " & _Filtro_Rubros & ")"
            End If

            If Not _Filtro_Marcas_Todas Then
                _Filtro_Marcas = Generar_Filtro_IN(_Tbl_Filtro_Marcas, "Chk", "Codigo", False, True, "'")
                _Filtro_Marcas = "And KOPR IN (Select KOPR From MAEPR Where MRPR In " & _Filtro_Marcas & ")"
            End If

            If Not _Filtro_Super_Familias_Todas Then
                _Filtro_SuperFamilias = Generar_Filtro_IN(_Tbl_Filtro_Super_Familias, "Chk", "Codigo", False, True, "'")
                _Filtro_SuperFamilias = "And KOPR IN (Select KOPR From MAEPR Where FMPR In " & _Filtro_SuperFamilias & ")"
            End If

            If Not _Filtro_Clalibpr_Todas Then
                _Filtro_ClasLibre = Generar_Filtro_IN(_Tbl_Filtro_Clalibpr, "Chk", "Codigo", False, True, "'")
                _Filtro_ClasLibre = "And KOPR IN (Select KOPR From MAEPR Where CLALIBPR In " & _Filtro_ClasLibre & ")"
            End If

            If Not _Filtro_Zonas_Todas Then
                _Filtro_Zonas = Generar_Filtro_IN(_Tbl_Filtro_Zonas, "Chk", "Codigo", False, True, "'")
                _Filtro_Zonas = "And KOPR IN (Select KOPR From MAEPR Where ZONAPR In " & _Filtro_Zonas & ")"
            End If

        Else

            If IsNothing(_Tbl_Filtro_Productos) Then
                Return
            End If

            _Filtro_Productos = Generar_Filtro_IN(_Tbl_Filtro_Productos, "Chk", "Codigo", False, True, "'")
            _Filtro_Productos = "And KOPR IN " & _Filtro_Productos

        End If

        '---------------------------

        Consulta_sql = "Select KOPR as Codigo From MAEPR Where 1 > 0" & vbCrLf &
                        _Filtro_Productos & vbCrLf &
                        _Filtro_Bodega & vbCrLf &
                        _Filtro_ClasLibre & vbCrLf &
                        _Filtro_Marcas & vbCrLf &
                        _Filtro_Rubros & vbCrLf &
                        _Filtro_SuperFamilias & vbCrLf &
                        _Filtro_Zonas

        If Rdb_Traer_No_Bloqueados.Checked Then
            Consulta_sql += Rdb_Traer_No_Bloqueados.Tag.ToString
        End If

        If Rdb_Traer_Bloqueados_Compras.Checked Then
            Consulta_sql += Rdb_Traer_Bloqueados_Compras.Tag.ToString
        End If

        If Rdb_Traer_Bloqueados_Venta.Checked Then
            Consulta_sql += Rdb_Traer_Bloqueados_Venta.Tag.ToString
        End If

        If Rdb_Traer_Bloqueados_Compra_y_Venta.Checked Then
            Consulta_sql += Rdb_Traer_Bloqueados_Compra_y_Venta.Tag.ToString
        End If

        If Rdb_Traer_Bloqueados_Compra_Venta_y_Produccion.Checked Then
            Consulta_sql += Rdb_Traer_Bloqueados_Compra_Venta_y_Produccion.Tag.ToString
        End If

        _Tbl_Productos_Seleccionados = _Sql.Fx_Get_Tablas(Consulta_sql)

        Sb_Traer_Productos_Al_Tratamiento(False)
        _Tbl_Productos_Seleccionados = Nothing

    End Sub

    Private Sub Sb_Grilla_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Try

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
            Dim _Index_Columna = Grilla.CurrentCell.ColumnIndex

            Dim Codigo = _Fila.Cells("KOPR").Value

            'Dim Neto, Iva, Ila, Bruto As Double
            'Dim Porc_Iva, Porc_Ila, Impuestos As Double

            Dim _Ud01pr = _Fila.Cells("UD01PR").Value
            Dim _Ud02pr = _Fila.Cells("UD02PR").Value

            Txt_Funcion.Text = String.Empty


            Txt_Descripcion.Text = _Fila.Cells("NOKOPR").Value &
            " Unidad 1 : [" & _Ud01pr & "] - Unidad 2 : [" & _Ud02pr & "]"

            Lbl_Rtu.Text = _Fila.Cells("RLUD").Value

            Consulta_sql = "Select Top 1 * From MAEPREM Where EMPRESA = '" & ModEmpresa & "' And KOPR = '" & Codigo & "'"
            Dim _Row_Maeprem As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Ppul01 As Double
            Dim _Ppul02 As Double
            Dim _Pm As Double

            If Not IsNothing(_Row_Maeprem) Then

                _Ppul01 = _Row_Maeprem.Item("PPUL01")
                _Ppul02 = _Row_Maeprem.Item("PPUL02")
                _Pm = _Row_Maeprem.Item("PM")

                _Fila.Cells("PPUL01").Value = _Ppul01
                _Fila.Cells("PPUL02").Value = _Ppul02
                _Fila.Cells("PM01").Value = _Pm

            End If

            Lbl_Costo_Ultima_Compra_Ud1.Text = FormatCurrency(_Ppul01, 2)
            Lbl_Costo_Ultima_Compra_Ud2.Text = FormatCurrency(_Ppul02, 2)
            Lbl_Costo_PM.Text = FormatCurrency(_Pm, 2)


            Dim _Campo_Fx As String


            If _Cabeza = "PP01UD" Then
                _Campo_Fx = "ECUACION"
            ElseIf _Cabeza = "PP02UD" Then
                _Campo_Fx = "ECUACIONU2"
            ElseIf _Index_Columna > 15 Then
                _Campo_Fx = Grilla.Columns(_Index_Columna + 1).Name
            Else
                _Campo_Fx = String.Empty
            End If

            If String.IsNullOrEmpty(_Campo_Fx) Then
                Txt_Funcion.Text = String.Empty
                Btn_Ejecutar_Formula.Enabled = False
            Else
                Txt_Funcion.Text = Trim(_Fila.Cells(_Campo_Fx).Value)
                Btn_Ejecutar_Formula.Enabled = True
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Sb_Grilla_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Try

            Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _IdLista As Integer = _Fila.Cells("IdLista").Value
            Dim _Select As Boolean = _Fila.Cells("Select").Value

            If _Cabeza = "Select" Then
                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Precios & " Set" & vbCrLf &
                       "[Select] = " & Convert.ToInt32(_Select) & vbCrLf &
                       "Where IdLista = " & _IdLista
                _Sql.Ej_consulta_IDU(Consulta_sql)
                Return
            End If

            Dim Rtu As Double = _Fila.Cells("RLUD").Value

            Dim PrecioUd1 As Double = NuloPorNro(_Fila.Cells("PP01UD").Value, 0)
            Dim PrecioUd2 As Double = NuloPorNro(_Fila.Cells("PP02UD").Value, 0)

            If _Cabeza = "PP01UD" Or _Cabeza = "PP02UD" Then

                If Chk_Ud1_X_Ud2.Checked Then

                    If _Cabeza = "PP01UD" Then
                        PrecioUd2 = Math.Round(PrecioUd1 * Rtu, 5)
                        _Fila.Cells("PP02UD").Value = PrecioUd2
                        _Fila.Cells("FxEjecUd1").Value = False
                    ElseIf _Cabeza = "PP02UD" Then
                        PrecioUd1 = Math.Round(PrecioUd2 / Rtu, 5)
                        _Fila.Cells("PP01UD").Value = PrecioUd1
                        _Fila.Cells("FxEjecUd2").Value = False
                    End If

                End If

            End If

            Sb_Actualizar_Datos_En_Tabla_De_Paso(_IdLista)

            Grilla.Columns(_Cabeza).ReadOnly = True
            Grilla.Columns("Select").ReadOnly = False

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub Sb_Actualizar_Datos_En_Tabla_De_Paso(_IdLista As Integer)

        Dim _Filas = _Tbl_Precios.Select("IdLista = " & _IdLista)
        Dim _Fila As DataRow = _Filas(0)

        Dim _Select As Boolean = _Fila.Item("Select")

        Dim _Kolt As String = _Fila.Item("KOLT")
        Dim _Kopr As String = Trim(_Fila.Item("KOPR"))

        Dim _Pp01ud As String = De_Num_a_Tx_01(NuloPorNro(_Fila.Item("PP01UD"), 0), , 5)
        Dim _Mg01ud As String = De_Num_a_Tx_01(NuloPorNro(_Fila.Item("MG01UD"), 0), , 5)
        Dim _Dtma01ud As String = De_Num_a_Tx_01(NuloPorNro(_Fila.Item("DTMA01UD"), 0), , 5)

        Dim _Pp02ud As String = De_Num_a_Tx_01(NuloPorNro(_Fila.Item("PP02UD"), 0), , 5)
        Dim _Mg02ud As String = De_Num_a_Tx_01(NuloPorNro(_Fila.Item("MG02UD"), 0), , 5)
        Dim _Dtma02ud As String = De_Num_a_Tx_01(NuloPorNro(_Fila.Item("DTMA02UD"), 0), , 5)

        Dim _Ecuacion As String = NuloPorNro(_Fila.Item("ECUACION"), "")
        Dim _Ecuacionu2 As String = NuloPorNro(_Fila.Item("ECUACIONU2"), "")

        _Ecuacion = Replace(LTrim(RTrim(_Ecuacion)), "'", "''")
        _Ecuacionu2 = Replace(LTrim(RTrim(_Ecuacionu2)), "'", "''")

        Dim _FxEjecUd1 As Integer = Convert.ToInt32(_Fila.Item("FxEjecUd1"))
        Dim _FxEjecUd2 As Integer = Convert.ToInt32(_Fila.Item("FxEjecUd2"))

        Dim _Campos_Adicionales = String.Empty

        For _i = 28 To _TblTabpre.Columns.Count - 1

            Dim _Columna As DataColumn = _TblTabpre.Columns(_i)
            Dim _CA As String = _Columna.ColumnName
            Dim _Fx_CA As String

            If Mid(_CA, 1, 5) <> "FORM_" Then
                Dim _Valor = De_Num_a_Tx_01(NuloPorNro(_Fila.Item(_CA), 0), , 5)
                _Campos_Adicionales += _CA & " = " & _Valor & "," & vbCrLf
            Else
                _Fx_CA = NuloPorNro(_Fila.Item(_CA), "")
                _Fx_CA = Replace(LTrim(RTrim(_Fx_CA)), "'", "''")
                _Campos_Adicionales += _CA & " = '" & _Fx_CA & "'," & vbCrLf
            End If

        Next

        Consulta_sql = "Update " & _Nombre_Tbl_Paso_Precios & " Set" & vbCrLf &
                       "[Select] = " & Convert.ToInt32(_Select) & "," & vbCrLf &
                       "Editado = 1," & vbCrLf &
                       "PP01UD = " & _Pp01ud & "," & vbCrLf &
                       "MG01UD = " & _Mg01ud & "," & vbCrLf &
                       "DTMA01UD = " & _Dtma01ud & "," & vbCrLf &
                       "PP02UD = " & _Pp02ud & "," & vbCrLf &
                       "MG02UD = " & _Mg02ud & "," & vbCrLf &
                       "DTMA02UD = " & _Dtma02ud & "," & vbCrLf &
                       "ECUACION = '" & _Ecuacion & "'," & vbCrLf &
                       "ECUACIONU2 = '" & _Ecuacionu2 & "'," & vbCrLf &
                       "FxEjecUd1 = '" & _FxEjecUd1 & "'," & vbCrLf &
                       "FxEjecUd2 = '" & _FxEjecUd2 & "'," & vbCrLf &
                       _Campos_Adicionales & vbCrLf &
                       "FINMAES = 1" & vbCrLf &
                       "Where IdLista = " & _IdLista

        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

    End Sub

    Private Sub Sb_Grilla_CellMouseUp(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        Grilla.EndEdit()
    End Sub

    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            With Grilla

                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)

                If Hitest.Type = DataGridViewHitTestType.Cell Then

                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
                    Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

                    If _Cabeza = "Select" Or
                                       _Cabeza = "KOLT" Or
                                       _Cabeza = "KOPR" Or
                                       _Cabeza = "NOKOPR" Then

                        ShowContextMenu(Menu_Contextual_Productos)

                    ElseIf _Cabeza = "MG01UD" Or _Cabeza = "MG02UD" Or _Cabeza = "DTMA01UD" Or _Cabeza = "DTMA02UD" Then
                        ShowContextMenu(Menu_Contextual_Copiar)
                    Else
                        ShowContextMenu(Menu_Contextual_Formula)
                    End If

                End If

            End With

        End If

    End Sub

    Private Sub Sb_Grilla_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)

        Try

            Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Tecla As Keys = e.KeyValue

            Select Case _Tecla

                Case Keys.Enter

                    If _Cabeza <> "KOPR" And _Cabeza <> "KOLT" And _Cabeza <> "Select" Then

                        Grilla.Columns(_Cabeza).ReadOnly = False
                        Grilla.BeginEdit(True)

                    End If

                    e.SuppressKeyPress = False
                    e.Handled = True

                Case Keys.Delete

            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Sb_Grilla_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
        ' referencia a la celda  
        Dim validar As TextBox = CType(e.Control, TextBox)
        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf Validar_Keypress_Nros_Grilla
    End Sub



    Function Fx_Contar_Checkados(_Mostrar_Mensaje As Boolean) As Integer

        Dim _Marcados As Integer

        For Each _Fila As DataGridViewRow In Grilla.Rows
            Dim _Select As Boolean = _Fila.Cells("Select").Value
            If _Select Then
                _Marcados += 1
            End If
        Next

        If _Marcados = 0 Then
            If _Mostrar_Mensaje Then
                Beep()
                ToastNotification.Show(Me, "NO HAY PRODUCTOS MARCADOS", My.Resources.cross,
                                             3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
            End If
        End If

        Return _Marcados

    End Function

    Private Sub Btn_Copiar_datos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Copiar_datos.Click
        Dim _Cabeza As String
        Dim _Valor As Double

        _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        _Valor = Grilla.Rows(Grilla.CurrentRow.Index).Cells(_Cabeza).Value

        Sb_Copiar_campos(_Cabeza, _Valor)
    End Sub

    Private Sub Sb_Btn_Estadisticas_Producto_Click(sender As System.Object, e As System.EventArgs)
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        If Fx_Tiene_Permiso(Me, "Prod009") Then

            Dim _Codigo As String = _Fila.Cells("Codigo").Value

            Dim Fm As New Frm_EstadisticaProducto(_Codigo)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If
    End Sub

    Private Sub Btn_Ejecutar_Formula_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ejecutar_Formula.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _IdLista = Trim(_Fila.Cells("IdLista").Value)

        Sb_Actualizar_Datos_En_Tabla_De_Paso(_IdLista)

        Sb_Ejecutar_Formula(_Fila, True, _Cabeza)

    End Sub

    Sub Sb_Ejecutar_Formula(_Fila As DataGridViewRow,
                            _Mostrar_Mensaje As Boolean,
                            _Cabeza As String)

        'Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _IdLista = _Fila.Cells("IdLista").Value
        Dim _Campo_Precio = _Cabeza
        Dim _Campo_Formula
        Dim _Valor As Double

        If _Cabeza = "PP01UD" Or _Cabeza = "PP02UD" Then

            If _Cabeza = "PP01UD" Then _Campo_Formula = "ECUACION"
            If _Cabeza = "PP02UD" Then _Campo_Formula = "ECUACIONU2"

        Else

            _Campo_Formula = Grilla.Columns(Grilla.CurrentCell.ColumnIndex + 1).Name

        End If

        Dim _Formula = Trim(NuloPorNro(_Fila.Cells(_Campo_Formula).Value, ""))

        If String.IsNullOrEmpty(Trim(_Formula)) Then
            If _Mostrar_Mensaje Then
                Beep()
                ToastNotification.Show(Me, "NO EXISTE FORMULA PARA LA LINEA", My.Resources.cross,
                                             1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Return
            End If
        Else

            Dim _Row = _Tbl_Precios.Select("IdLista = " & _IdLista)
            Dim _RowPrecio As DataRow = _Row(0)

            Dim _Tiene_Cor As Boolean = InStr(1, _Formula, "[")

            If _Tiene_Cor Then

                Dim _Ecuacion_Copy = Replace(_Formula, "]", "")
                Dim _Ecuacion_1 = Split(_Ecuacion_Copy, "#")
                Dim _Ecuacion_2 = Split(_Ecuacion_1(0), "[")

                Dim _Error_Fx As Boolean

                For i = 1 To _Ecuacion_2.Length

                    Dim _Ecuacion_3 = Split(_Ecuacion_2(i), ",")

                    Dim _Cant1_Ecu As Double = _Ecuacion_3(0)
                    Dim _Cant2_Ecu As Double = _Ecuacion_3(1)
                    Dim _Campo_Ecu As String = _Ecuacion_3(2)

                    Dim _Corchete1 = Split(_Formula, "[")
                    Dim _Corchete2 = Split(_Formula, "]")
                    Dim _Corchete3 = Split(_Formula, "][")

                    If _Formula.Contains("-[") Then
                        'Throw New System.Exception(vbCrLf & vbCrLf & "Esto no esta permitido -> '-['")
                        _Error_Fx = True
                    End If

                    If _Formula.Contains("]-") Then
                        'Throw New System.Exception(vbCrLf & vbCrLf & "Esto no esta permitido -> ']-'")
                        _Error_Fx = True
                    End If

                    If _Corchete1.Length > _Corchete2.Length Then
                        'Throw New System.Exception(vbCrLf & vbCrLf & "Falta un cierre de corchetes")
                        _Error_Fx = True
                    End If

                    If _Corchete1.Length < _Corchete2.Length Then
                        'Throw New System.Exception(vbCrLf & vbCrLf & "Falta una apertura de corchetes")
                        _Error_Fx = True
                    End If

                    If Not String.IsNullOrEmpty(_Ecuacion_2(0).Trim) Then
                        'Throw New System.Exception(vbCrLf & vbCrLf & "Error cerca de " & _Ecuacion_2(0).Trim)
                        _Error_Fx = True
                    End If

                    If Not String.IsNullOrEmpty(_Corchete2(_Corchete2.Length - 1).Trim) Then
                        If Not (_Corchete2(_Corchete2.Length - 1).Trim).Contains("#") Then
                            'Throw New System.Exception(vbCrLf & vbCrLf & "Error cerca de " & _Corchete2(_Corchete2.Length - 1).Trim)
                            _Error_Fx = True
                        End If
                    End If

                    If _Corchete3.Length <> _Ecuacion_2.Length - 1 Then
                        'Throw New System.Exception(vbCrLf & vbCrLf & "Error en un cierre y apertura de corchetes")
                        _Error_Fx = True
                    End If

                    If Not _Error_Fx Then

                        _Valor = Fx_Precio_Formula_Random(_RowPrecio, _Campo_Precio, _Campo_Formula, _RowPrecio, False, "", 1, 1)

                        '_Ecuacion_3(3) = Replace(_Ecuacion_3(3), "caprco", "")
                        'Consulta_sql = "Select " & _Ecuacion_3(3) & " As Valor"
                        'Dim _Row_Valor As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                        '_Valor = _Row_Valor.Item("Valor")

                    End If

                    Exit For

                Next

            Else
                _Valor = Fx_Precio_Formula_Random(_RowPrecio, _Campo_Precio, _Campo_Formula, _RowPrecio, False, "", 1, 1)
            End If

            _Fila.Cells(_Cabeza).Value = _Valor

            If _Campo_Formula = "ECUACION" Then _Fila.Cells("FxEjecUd1").Value = True
            If _Campo_Formula = "ECUACIONU2" Then _Fila.Cells("FxEjecUd2").Value = True

            Sb_Actualizar_Datos_En_Tabla_De_Paso(_IdLista)

            If _Mostrar_Mensaje Then

                Beep()
                Dim _dv_Chequeados = _Tbl_Precios.Select("Select = 1")

                If CBool(_dv_Chequeados.Length) Then

                    If MessageBoxEx.Show(Me, "¿Desea aplicar la formula para todos los productos marcados?",
                                         "Aplicar formula masivamente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        Sb_Ejecutar_Formula_Masivamente()

                        ToastNotification.Show(Me, "FORMULA EJECUTADA CORRECTAMENTE", My.Resources.ok_button,
                                                    1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                    End If

                End If

            End If

        End If

    End Sub

    Private Sub Btn_Configurar_Formula_Linea_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Configurar_Formula_Linea.Click
        Sb_Configurar_Formula_producto_activo()
    End Sub

    Private Sub Btn_Copiar_Formula_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Copiar_Formula.Click

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Campo_Precio = _Cabeza
        Dim _Campo_Formula As String

        If _Cabeza = "PP01UD" Or _Cabeza = "PP02UD" Then
            'ShowContextMenu(Menu_Contextual_Copiar)
            If _Cabeza = "PP01UD" Then
                _Campo_Formula = "ECUACION"
            Else
                _Campo_Formula = "ECUACIONU2"
            End If
        Else
            _Campo_Formula = Grilla.Columns(Grilla.CurrentCell.ColumnIndex + 1).Name
            'ShowContextMenu(Menu_Contextual_Formula)
        End If

        'Dim _Valor = Grilla.Rows(Grilla.CurrentRow.Index).Cells(_Cabeza).Value
        'Sb_Copiar_campos(_Cabeza, _Valor)

        Dim _Valor = Grilla.Rows(Grilla.CurrentRow.Index).Cells(_Campo_Formula).Value
        Sb_Copiar_campos(_Campo_Formula, _Valor)

    End Sub

    Private Sub Btn_Copiar_Datos_Precios_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Copiar_Datos_Precios.Click
        Dim _Cabeza As String
        Dim _Valor As Double

        _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        _Valor = Grilla.Rows(Grilla.CurrentRow.Index).Cells(_Cabeza).Value

        Sb_Copiar_campos(_Cabeza, _Valor)
    End Sub

    Sub Sb_Limpiar()

        _Filtro_Productos_Todos = False
        _Filtro_Clalibpr_Todas = True
        _Filtro_Marcas_Todas = True
        _Filtro_Rubro_Todas = True
        _Filtro_Super_Familias_Todas = True
        _Filtro_Zonas_Todas = True

        _Tbl_Filtro_Productos = Nothing
        _Tbl_Filtro_Clalibpr = Nothing
        _Tbl_Filtro_Marcas = Nothing
        _Tbl_Filtro_Rubro = Nothing
        _Tbl_Filtro_Super_Familias = Nothing
        _Tbl_Filtro_Zonas = Nothing

        Sb_Crear_Tabla_De_Paso()

        Txt_Descripcion.Text = String.Empty
        Txt_Funcion.Text = String.Empty

        Lbl_Rtu.Text = 0
        Lbl_Costo_PM.Text = 0
        Lbl_Costo_Ultima_Compra_Ud1.Text = 0
        Lbl_Costo_Ultima_Compra_Ud2.Text = 0

        Chk_Marcar_Todo.Checked = False
        _Tbl_Productos_Seleccionados = Nothing

    End Sub

    Private Sub Btn_Limpiar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Limpiar.Click

        If Grilla.RowCount > 0 Then
            If MessageBoxEx.Show(Me, "¿Está seguro de querer limpiar el tratamiento actual?",
                                "Limpiar tratamiento",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Return
            End If
        End If

        Sb_Limpiar()
    End Sub

    Private Sub ChkMarcarTodo_CheckedChanged(sender As System.Object, e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles Chk_Marcar_Todo.CheckedChanged
        If Grilla.RowCount > 0 Then
            For Each row As DataGridViewRow In Grilla.Rows
                row.Cells("Select").Value = Chk_Marcar_Todo.Checked
            Next
            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Precios & " Set [Select] = " & CInt(Chk_Marcar_Todo.Checked) * -1
            _Sql.Ej_consulta_IDU(Consulta_sql)
            Beep()
        End If
    End Sub

    Sub Sb_Configurar_Formula_producto_activo()

        If CBool(Grilla.Rows.Count) Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Codigo As String = Trim(_Fila.Cells("KOPR").Value)
            Dim _Lista As String = Trim(_Fila.Cells("KOLT").Value)
            Dim _IdLista = Trim(_Fila.Cells("IdLista").Value)
            Dim _Melt As String = Trim(_Fila.Cells("MELT").Value)
            Dim _Campo_Formula As String

            Dim _Lista_Neta As Boolean

            If _Melt = "N" Then
                _Lista_Neta = True
            Else
                _Lista_Neta = False
            End If


            Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

            If _Cabeza = "PP01UD" Or _Cabeza = "PP02UD" Then
                If _Cabeza = "PP01UD" Then
                    _Campo_Formula = "ECUACION"
                Else
                    _Campo_Formula = "ECUACIONU2"
                End If
            Else
                _Campo_Formula = Grilla.Columns(Grilla.CurrentCell.ColumnIndex + 1).Name
            End If

            Dim _Formula As String = NuloPorNro(_Fila.Cells(_Campo_Formula).Value, "")
            Dim _Fxd As Boolean

            If LCase(Trim(_Formula)) = Trim(_Formula) Then
                _Fxd = True
            Else
                _Fxd = False
            End If

            If Fx_Tiene_Permiso(Me, "Pre0009") Then

                Dim Fm As New Frm_MantListas_Conf_Funciones(_Formula, _Fxd, _Lista_Neta)
                Fm.ShowDialog(Me)

                If Fm.Pro_Grabar Then

                    _Formula = Fm.Pro_Formula
                    _Fila.Cells(_Campo_Formula).Value = _Formula

                    Txt_Funcion.Text = _Formula

                    Sb_Actualizar_Datos_En_Tabla_De_Paso(_IdLista)

                    Dim _dv_Chequeados = _Tbl_Precios.Select("Select = 1")


                    If CBool(_dv_Chequeados.Length) Then
                        Dim _Pregunta As String = "¿Desea copiar la formula para los productos tickeados?" & vbCrLf &
                                                                  "Formula: " & _Formula

                        If String.IsNullOrEmpty(_Formula) Then
                            _Pregunta = "¿Desea quitar la formula a los productos tickeados?"
                        End If

                        Fm.Dispose()

                        If MessageBoxEx.Show(Me, _Pregunta, "Copiar formula", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                            Sb_Copiar_campos(_Campo_Formula, _Formula)
                        End If
                    End If



                End If

            End If

        Else
            Beep()
        End If

    End Sub

    Sub Sb_Copiar_campos(_Campo As String, _Dato As Object)

        Dim _Marcados As Long

        Try

            Sb_Habilitar_Deshabilitar_Comandos(False, True)
            Lbl_Procesando.Text = "COPIANDO DATOS EN LOS PRODUCTOS CHECKEADOS..."

            Dim _dv_Chequeados = _Tbl_Precios.Select("Select = 1")

            Circular_Progres_Val.Maximum = _dv_Chequeados.Length

            If CBool(Circular_Progres_Val.Maximum) Then

                Dim _Sql_Query = String.Empty

                For Each _Fila As DataRow In _dv_Chequeados 'Grilla.Rows

                    Dim _Lista As String = _Fila.Item("KOLT")
                    Dim _Codigo As String = _Fila.Item("KOPR")
                    Dim _ValorOld = _Fila.Item(_Campo)
                    Dim _Select As Boolean = _Fila.Item("Select")
                    Dim _IdLista As String = _Fila.Item("IdLista")
                    'Dim _Index As Integer = _Fila.Index

                    If _Select Then

                        _Fila.Item(_Campo) = _Dato
                        _Marcados += 1

                        Circular_Progres_Porc.Value = ((_Marcados * 100) / _dv_Chequeados.Length) 'Mas
                        Circular_Progres_Val.Value = _Marcados
                        Circular_Progres_Val.ProgressText = _Marcados

                    End If

                    Application.DoEvents()

                    If _Cancelar Then
                        Exit For
                    End If

                Next

                If IsNumeric(_Dato) Then
                    Consulta_sql = "Update " & _Nombre_Tbl_Paso_Precios & " Set Editado = 1," & _Campo & " = " & De_Num_a_Tx_01(_Dato, False, 5) & vbCrLf
                Else
                    Consulta_sql = "Update " & _Nombre_Tbl_Paso_Precios & " Set Editado = 1," & _Campo & " = '" & _Dato & "'" & vbCrLf
                End If

                Consulta_sql += "Where [Select] = 1"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                If _Marcados > 0 Then
                    Beep()
                    ToastNotification.Show(Me, "SE COPIARON " & _Marcados & " fila[s]", My.Resources.ok_button,
                                                 3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                End If
            Else
                Beep()
                ToastNotification.Show(Me, "NO HAY PRODUCTOS MARCADOS", My.Resources.cross,
                                             3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
            End If

        Catch ex As Exception
        Finally
            Sb_Habilitar_Deshabilitar_Comandos(True, False)
        End Try

    End Sub

    Sub Sb_Ejecutar_Formula_Masivamente()

        Dim _Marcados As Long
        Dim _Sql_Query As String

        Try

            Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

            Sb_Habilitar_Deshabilitar_Comandos(False, True)

            Lbl_Procesando.Text = "APLICANDO FORMULA EN LOS PRODUCTOS CHECKEADOS..."
            Lbl_Procesando.Visible = True
            Dim _dv_Chequeados = _Tbl_Precios.Select("Select = 1")

            Circular_Progres_Val.Maximum = _dv_Chequeados.Length

            Dim _Cont = 0

            If CBool(Circular_Progres_Val.Maximum) Then

                For Each _Fila As DataGridViewRow In Grilla.Rows

                    System.Windows.Forms.Application.DoEvents()

                    Dim _Select As Boolean = _Fila.Cells("Select").Value

                    If _Select Then

                        Grilla.CurrentCell = Grilla.Rows(_Fila.Index).Cells(_Cabeza)
                        Sb_Ejecutar_Formula(_Fila, False, _Cabeza)
                        _Marcados += 1

                        Circular_Progres_Val.ProgressText = _Marcados
                        Circular_Progres_Porc.Value = ((_Marcados * 100) / _dv_Chequeados.Length) 'Mas
                        Circular_Progres_Val.Value = _Marcados

                        Dim _IdLista = _Fila.Cells("IdLista").Value
                        Dim _Valor As Double = _Fila.Cells(_Cabeza).Value

                        _Sql_Query += "Update " & _Nombre_Tbl_Paso_Precios & " Set Editado = 1," & Space(1) &
                                      _Cabeza & " = " & De_Num_a_Tx_01(_Valor, False, 5) & Space(1) &
                                      "Where IdLista = " & _IdLista & vbCrLf

                    End If

                    If _Cancelar Then
                        Exit For
                    End If
                    _Cont += 1

                    If _Cont = 100 Then
                        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_Sql_Query)
                        _Sql_Query = String.Empty
                        _Cont = 0
                    End If

                Next

                If Not String.IsNullOrEmpty(_Sql_Query) Then
                    _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_Sql_Query)
                    _Sql_Query = String.Empty
                End If

                If _Marcados > 0 Then
                    ToastNotification.Show(Me, "SE ACTUALIZARON " & _Marcados & " fila[s]", My.Resources.ok_button,
                                                 3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                End If

            Else
                Beep()
                ToastNotification.Show(Me, "NO HAY PRODUCTOS MARCADOS", My.Resources.cross,
                                       3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

            End If

        Catch ex As Exception
        Finally
            Lbl_Procesando.Visible = False
            Sb_Habilitar_Deshabilitar_Comandos(True, False)
        End Try


    End Sub

    Private Sub BtnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGrabar.Click

        If CBool(Grilla.Rows.Count) Then

            Dim _Fevi = String.Empty
            Dim _FechaMinima As DateTime = FechaDelServidor()

            If Chk_GrabarPreciosHistoricos.Checked Then

                Dim _Fecha As Date

                Dim _Aceptar As Boolean

                _Aceptar = InputBox_Bk_Fecha(Me, "Ingrese la fecha de vigencia de estos precios" & vbCrLf & vbCrLf &
                               "Formato fecha: dd-mm-aaaa", "Fecha de vigencia", _Fecha, Nothing, True)

                If Not _Aceptar Then
                    Return
                End If

                _Fevi = Format(_Fecha, "yyyyMMdd")

            End If

            If Not Fx_Tiene_Permiso(Me, "Pre0011") Then
                Return
            End If

            Sb_Habilitar_Deshabilitar_Comandos(False, False)

            Dim _Campos_Adicionales = String.Empty

            For _i = 28 To _TblTabpre.Columns.Count - 1

                Dim _Columna As DataColumn = _TblTabpre.Columns(_i)
                Dim _CA As String = _Columna.ColumnName

                _Campos_Adicionales += "TABPRE." & _CA & " = Tbl." & _CA & "," & vbCrLf

            Next

            Dim _FeviStr = String.Empty

            If Not String.IsNullOrEmpty(_Fevi) Then
                _FeviStr = "TABPRE.FEVI = '" & _Fevi & "',"
            End If

            Consulta_sql = "   Update TABPRE Set 
                               TABPRE.PP01UD = Tbl.PP01UD,
                               TABPRE.MG01UD = Tbl.MG01UD,
                               TABPRE.DTMA01UD = Tbl.DTMA01UD,
                               TABPRE.PP02UD = Tbl.PP02UD,
                               TABPRE.MG02UD = Tbl.MG02UD,
                               TABPRE.DTMA02UD = Tbl.DTMA02UD,
                               TABPRE.ECUACION = Tbl.ECUACION,
                               TABPRE.ECUACIONU2 = Tbl.ECUACIONU2," & _FeviStr & "
                               " & _Campos_Adicionales & "
                               TABPRE.PM01 = 0
                               From " & _Nombre_Tbl_Paso_Precios & " Tbl 
                                   Left Outer Join TABPRE ON Tbl.KOLT = TABPRE.KOLT AND Tbl.KOPR = TABPRE.KOPR
                               Where Tbl.Editado = 1"

            If Chk_GrabarPreciosHistoricos.Checked Then

                If Chk_NoguardarTABPRE.Visible AndAlso Chk_NoguardarTABPRE.Checked Then

                    Dim _Consulta = MessageBoxEx.Show(Me, "¿Confirma NO grabar los datos en TABPRE?", "Validación",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    If _Consulta = DialogResult.Yes Then
                        Consulta_sql = String.Empty
                    Else
                        Sb_Habilitar_Deshabilitar_Comandos(True, False)
                        Return
                    End If

                End If

                If _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_ListaPreHistorico") Then

                    Consulta_sql += vbCrLf & vbCrLf &
                                    "Insert Into " & _Global_BaseBk & "Zw_ListaPreHistorico (Codigo,Lista,CodFuncionario,Fechagrab,FechaVigencia,PrecioUd1,PrecioUd2,FxEjecUd1,FxEjecUd2) " & vbCrLf &
                                    "Select KOPR,KOLT,'" & FUNCIONARIO & "',Getdate(),'" & _Fevi & "',PP01UD,PP02UD,FxEjecUd1,FxEjecUd2" & vbCrLf &
                                    "From " & _Nombre_Tbl_Paso_Precios & vbCrLf &
                                    "Where Editado = 1"

                End If

            End If

            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                Dim _Editados = _Sql.Fx_Cuenta_Registros(_Nombre_Tbl_Paso_Precios, "Editado = 1")

                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Precios & " Set Editado = 0"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                MessageBoxEx.Show(Me, FormatNumber(_Editados, 0) & " registro(s) actualizado(s) correctamente", "Actualizar Precios",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                If _Cerrar_Al_Grabar Then
                    _Grabacion_Realizada = True
                    Me.Close()
                End If

            End If

            Sb_Habilitar_Deshabilitar_Comandos(True, False)

        Else
            Beep()
            ToastNotification.Show(Me, "NO EXISTEN DATOS QUE GRABAR", My.Resources.cross,
                                   1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
        End If

    End Sub

    Private Sub Btn_Conf_Funcion_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Conf_Funcion.Click
        Sb_Configurar_Formula_producto_activo()
    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Exportar_Excel.Click

        For Each _Fila As DataRow In _Tbl_Precios.Rows
            Dim _Codigo = _Fila.Item("KOPR")
            Dim _Pm As Double = _Fila.Item("PM01")
            If Not CBool(_Pm) Then
                _Pm = Trae_PM(_Codigo)
                _Fila.Item("PM01") = _Pm
            End If
        Next

        ExportarTabla_JetExcel_Tabla(_Tbl_Precios, Me, "Tratamiento")

    End Sub

    Sub Sb_Crear_Tabla_Filas_Columnas()

        For Each _Fila As DataRow In _Tbl_Listas_Seleccionadas.Rows



        Next

    End Sub

    Sub Sb_Habilitar_Deshabilitar_Comandos(_Habilitar As Boolean,
                                           _Habilitar_Cancelar As Boolean)

        _Cancelar = False


        Barra_Abajo.Enabled = _Habilitar
        Barra_Arriba.Enabled = _Habilitar

        Grupo_Costo_Ud1.Enabled = _Habilitar
        Grupo_Costo_Ud2.Enabled = _Habilitar
        Grupo_PM.Enabled = _Habilitar
        Grupo_Rut.Enabled = _Habilitar

        Chk_Ud1_X_Ud2.Enabled = _Habilitar
        Btn_Conf_Funcion.Enabled = _Habilitar

        Circular_Progres_Porc.ProgressColor = Color.SteelBlue
        Circular_Progres_Val.ProgressColor = Color.SteelBlue
        Circular_Progres_Porc.Maximum = 100

        Circular_Progres_Porc.Value = 0
        Circular_Progres_Val.Value = 0

        Btn_Cancelar.Visible = _Habilitar_Cancelar
        Circular_Progres_Porc.Visible = _Habilitar_Cancelar
        Circular_Progres_Val.Visible = _Habilitar_Cancelar
        Lbl_Procesando.Visible = _Habilitar_Cancelar

        Me.Refresh()

    End Sub

    Sub Sb_Grilla_RowsPostPaint(sender As System.Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < Grilla.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If Grilla.RowHeadersWidth < CInt(size.Width + 20) Then
                Grilla.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "vb.net",
         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Frm_MantLista_Precios_Random_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If Not (_RowProducto Is Nothing) Then Return

        Try
            Dim tecla = e.KeyCode

            If e.KeyValue = Keys.Down Then 'Or e.KeyValue = Keys.Up Then

            ElseIf e.KeyValue = Keys.Escape Then


            ElseIf e.KeyValue = Keys.F2 Then
                Sb_Trae_un_solo_producto("")
            ElseIf e.KeyValue = Keys.F3 Then
                Sb_Busqueda_Selectiva()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Btn_Traer_Todos_Los_Productos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Traer_Todos_Los_Productos.Click
        Return
        If Grilla.RowCount > 0 Then

            If MessageBoxEx.Show(Me, "Esta acción limpiara la lista actual" & vbCrLf &
                              "¿Desea continuar con la operación?", "Buscar productos",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return
            End If

        End If

        Consulta_sql = "Select KOPR as Codigo From MAEPR"
        _Tbl_Productos_Seleccionados = _Sql.Fx_Get_Tablas(Consulta_sql)

        Sb_Traer_Productos_Al_Tratamiento(False)
        _Tbl_Productos_Seleccionados = Nothing

    End Sub


    Private Sub Btn_Cancelar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cancelar.Click

        If MessageBoxEx.Show(Me, "¿Esta seguro cancelar la acción?", "Cancelar",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _Cancelar = True
        End If

    End Sub


    Private Sub Btn_Buscar_Producto_En_Grilla_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Buscar_Producto_En_Grilla.Click

        Dim _Kopr = String.Empty

        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
        Fm.Pro_CodEntidad = String.Empty
        Fm.Pro_CodSucEntidad = String.Empty
        Fm.Pro_Tipo_Lista = "P"
        Fm.Pro_Lista_Busqueda = ModListaPrecioVenta
        Fm.Pro_Sucursal_Busqueda = ModSucursal
        Fm.Pro_Bodega_Busqueda = ModBodega
        Fm.Pro_Mostrar_Info = False
        Fm.Pro_Actualizar_Precios = False

        Fm.ShowDialog(Me)
        If Fm.Pro_Seleccionado Then
            If Not (Fm.Pro_RowProducto Is Nothing) Then
                _Kopr = Trim(Fm.Pro_RowProducto.Item("KOPR"))
            End If

            If Not String.IsNullOrEmpty(Trim(_Kopr)) Then
                If BuscarDatoEnGrilla(_Kopr, "KOPR", Grilla) = True Then
                    Grilla.Focus()
                End If
            End If
        End If

    End Sub


    Private Sub Btn_Importar_Desde_Excel_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Importar_Desde_Excel.Click

        If Grilla.RowCount > 0 Then
            If MessageBoxEx.Show(Me, "Esta acción limpiara la lista actual" & vbCrLf &
                                  "¿Desea continuar con la operación?", "Buscar productos",
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then

                Return
            End If
        End If

        Sb_Limpiar()

        Dim Fm As New Frm_Importar_Desde_Excel(_Nombre_Tbl_Paso_Precios, _Tbl_Listas_Seleccionadas)
        Fm.Lista_Campos_Adicionales = _Lista_Campos_Adicionales
        Fm.ShowDialog(Me)

        If Fm.Pro_Limpiar Then
            Sb_Limpiar()
        ElseIf Fm.Pro_Traer_Productos Then

            If Fm.Rdb_Exportar_Solo_Codigo.Checked Then

                _Tbl_Productos_Seleccionados = Fm.Pro_Tbl_Productos_Seleccionados

                Dim _Procesar As Boolean = CBool(_Tbl_Productos_Seleccionados.Rows.Count)

                If _Procesar Then

                    If Fm.Pro_Problemas Then
                        If MessageBoxEx.Show(Me, "¿Desea cargar los datos extraídos?" & vbCrLf &
                                             "Productos: " & FormatNumber(_Tbl_Productos_Seleccionados.Rows.Count, 0),
                                             "Traer productos",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                            _Procesar = False
                        End If
                    End If

                    If _Procesar Then
                        Sb_Traer_Productos_Al_Tratamiento(True)
                    Else
                        Sb_Limpiar()
                    End If

                End If

            ElseIf Fm.Rdb_Exportar_Valores.Checked Then

                _Tbl_Precios = Fm.Pro_Tbl_Precios
                Sb_Formato_Grilla()

            End If

        End If

        Fm.Dispose()

    End Sub

    Private Sub Btn_Sel_Productos_Click(sender As Object, e As EventArgs) Handles Btn_Sel_Productos.Click

        ShowContextMenu(Menu_Contextual_Tratamiento)

    End Sub

    Enum Enum_Productos_Todos
        Todos
        Con_Precio_En_Ud1
        Con_Precio_En_Ud2
        Con_Precio_En_Ud1_o_Ud2
    End Enum

    Private Sub Btn_Productos_Todos_Click(sender As Object, e As EventArgs) Handles Btn_Productos_Todos.Click
        Sb_Traer_Todos_Los_Productos(Enum_Productos_Todos.Todos)
    End Sub

    Private Sub Btn_Productos_Ud1_Click(sender As Object, e As EventArgs) Handles Btn_Productos_Ud1.Click
        Sb_Traer_Todos_Los_Productos(Enum_Productos_Todos.Con_Precio_En_Ud1)
    End Sub

    Private Sub Btn_Productos_Ud2_Click(sender As Object, e As EventArgs) Handles Btn_Productos_Ud2.Click
        Sb_Traer_Todos_Los_Productos(Enum_Productos_Todos.Con_Precio_En_Ud2)
    End Sub

    Private Sub Btn_Productos_Ud1_o_Ud2_Click(sender As Object, e As EventArgs) Handles Btn_Productos_Ud1_o_Ud2.Click
        Sb_Traer_Todos_Los_Productos(Enum_Productos_Todos.Con_Precio_En_Ud1_o_Ud2)
    End Sub

    Sub Sb_Traer_Todos_Los_Productos(_Productos_Todos As Enum_Productos_Todos)

        If Grilla.RowCount > 0 Then

            If MessageBoxEx.Show(Me, "Esta acción limpiara la lista actual" & vbCrLf &
                              "¿Desea continuar con la operación?", "Buscar productos",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return
            End If

        End If

        Dim _Filtro_Listas As String = Generar_Filtro_IN(_Tbl_Listas_Seleccionadas, "", "KOLT", False, False, "'")

        Select Case _Productos_Todos
            Case Enum_Productos_Todos.Todos
                Consulta_sql = "Select KOPR As Codigo From MAEPR Where KOPR In (Select KOPR From TABPRE Where KOLT In " & _Filtro_Listas & ")" & vbCrLf
            Case Enum_Productos_Todos.Con_Precio_En_Ud1
                Consulta_sql = "Select KOPR As Codigo From MAEPR Where KOPR In (Select KOPR From TABPRE Where KOLT In " & _Filtro_Listas & " And PP01UD = 0)" & vbCrLf
            Case Enum_Productos_Todos.Con_Precio_En_Ud2
                Consulta_sql = "Select KOPR As Codigo From MAEPR Where KOPR In (Select KOPR From TABPRE Where KOLT In " & _Filtro_Listas & " And PP02UD = 0)" & vbCrLf
            Case Enum_Productos_Todos.Con_Precio_En_Ud1_o_Ud2
                Consulta_sql = "Select KOPR As Codigo From MAEPR Where KOPR In (Select KOPR From TABPRE Where KOLT In " & _Filtro_Listas & " And (PP01UD = 0 Or PP02UD = 0))" & vbCrLf
        End Select

        If Rdb_Traer_No_Bloqueados.Checked Then
            Consulta_sql += Rdb_Traer_No_Bloqueados.Tag.ToString
        End If

        If Rdb_Traer_Bloqueados_Compras.Checked Then
            Consulta_sql += Rdb_Traer_Bloqueados_Compras.Tag.ToString
        End If

        If Rdb_Traer_Bloqueados_Venta.Checked Then
            Consulta_sql += Rdb_Traer_Bloqueados_Venta.Tag.ToString
        End If

        If Rdb_Traer_Bloqueados_Compra_y_Venta.Checked Then
            Consulta_sql += Rdb_Traer_Bloqueados_Compra_y_Venta.Tag.ToString
        End If

        If Rdb_Traer_Bloqueados_Compra_Venta_y_Produccion.Checked Then
            Consulta_sql += Rdb_Traer_Bloqueados_Compra_Venta_y_Produccion.Tag.ToString
        End If

        _Tbl_Productos_Seleccionados = _Sql.Fx_Get_Tablas(Consulta_sql)

        Sb_Traer_Productos_Al_Tratamiento(False)
        _Tbl_Productos_Seleccionados = Nothing

    End Sub

    Private Sub Btn_Imprimir_Maestra_Click(sender As Object, e As EventArgs) Handles Btn_Imprimir_Maestra.Click

        If Not CBool(Grilla.Rows.Count) Then
            MessageBoxEx.Show(Me, "No hay productos que exportar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Consulta_sql = "Select Count(Distinct KOLT) As Listas From " & _Nombre_Tbl_Paso_Precios
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row) Then
            If _Row.Item("Listas") > 1 Then
                MessageBoxEx.Show(Me, "Para poder generar el reporte solo debe haber una lista de precios seleccionada", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        Else
            Return
        End If

        Dim _Clas_Imprimir_ListaPrecios As New Clas_Imprimir_ListaPrecios(_Nombre_Tbl_Paso_Precios)

        If Not CBool(_Clas_Imprimir_ListaPrecios.Tbl_Productos.Rows.Count) Then
            MessageBoxEx.Show(Me, "No hay productos seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        _Clas_Imprimir_ListaPrecios.Imprimir_Negrita = False
        _Clas_Imprimir_ListaPrecios.Fx_Imprimir_Archivo(Me, "")

    End Sub

    Private Sub Sb_Rdb_Traer_Bloqueados_CheckedChanged(sender As Object, e As CheckBoxChangeEventArgs)

        If CType(sender, CheckBoxItem).Checked Then
            'If Not Fx_Tiene_Permiso(Me, "Pre0021") Then
            '    Rdb_Traer_No_Bloqueados.Checked = True
            'End If
            Rdb_Traer_Bloqueados_Compras.Enabled = False
            Rdb_Traer_Bloqueados_Compra_Venta_y_Produccion.Enabled = False
            Rdb_Traer_Bloqueados_Compra_y_Venta.Enabled = False
            Rdb_Traer_Bloqueados_Venta.Enabled = False
            Rdb_Traer_No_Bloqueados.Enabled = False
            Rdb_Traer_Todos.Enabled = False
            Btn_Cambiar_Opciones.Enabled = True
        End If

        If CType(sender, CheckBoxItem).Checked Then
            Btn_ProdBloqueados.Text = CType(sender, CheckBoxItem).Text
        End If

    End Sub


    Sub Sb_Parametros_Informe_Sql(_Actualizar As Boolean)

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")
        Dim _Informe = "Lista_Precios"

        _Sql.Sb_Parametro_Informe_Sql(Rdb_Traer_Bloqueados_Compras, _Informe, Rdb_Traer_Bloqueados_Compras.Name,
                                                 Class_SQLite.Enum_Type._Boolean, Rdb_Traer_Bloqueados_Compras.Checked, _Actualizar, "MantLista")

        _Sql.Sb_Parametro_Informe_Sql(Rdb_Traer_Bloqueados_Compra_Venta_y_Produccion, _Informe, Rdb_Traer_Bloqueados_Compra_Venta_y_Produccion.Name,
                                                 Class_SQLite.Enum_Type._Boolean, Rdb_Traer_Bloqueados_Compra_Venta_y_Produccion.Checked, _Actualizar, "MantLista")

        _Sql.Sb_Parametro_Informe_Sql(Rdb_Traer_Bloqueados_Compra_y_Venta, _Informe, Rdb_Traer_Bloqueados_Compra_y_Venta.Name,
                                                 Class_SQLite.Enum_Type._Boolean, Rdb_Traer_Bloqueados_Compra_y_Venta.Checked, _Actualizar, "MantLista")

        _Sql.Sb_Parametro_Informe_Sql(Rdb_Traer_Bloqueados_Venta, _Informe, Rdb_Traer_Bloqueados_Venta.Name,
                                                 Class_SQLite.Enum_Type._Boolean, Rdb_Traer_Bloqueados_Venta.Checked, _Actualizar, "MantLista")

        _Sql.Sb_Parametro_Informe_Sql(Rdb_Traer_No_Bloqueados, _Informe, Rdb_Traer_No_Bloqueados.Name,
                                                 Class_SQLite.Enum_Type._Boolean, Rdb_Traer_No_Bloqueados.Checked, _Actualizar, "MantLista")

        _Sql.Sb_Parametro_Informe_Sql(Rdb_Traer_Todos, _Informe, Rdb_Traer_Todos.Name,
                                                 Class_SQLite.Enum_Type._Boolean, Rdb_Traer_Todos.Checked, _Actualizar, "MantLista")

    End Sub

    Private Sub Btn_Cambiar_Opciones_Click(sender As Object, e As EventArgs) Handles Btn_Cambiar_Opciones.Click

        If Fx_Tiene_Permiso(Me, "Pre0021") Then
            Rdb_Traer_Bloqueados_Compras.Enabled = True
            Rdb_Traer_Bloqueados_Compra_Venta_y_Produccion.Enabled = True
            Rdb_Traer_Bloqueados_Compra_y_Venta.Enabled = True
            Rdb_Traer_Bloqueados_Venta.Enabled = True
            Rdb_Traer_No_Bloqueados.Enabled = True
            Rdb_Traer_Todos.Enabled = True
            Btn_Cambiar_Opciones.Enabled = False
        End If

    End Sub

    Private Sub Chk_GrabarPreciosHistoricos_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_GrabarPreciosHistoricos.CheckedChanged
        Chk_NoguardarTABPRE.Visible = Chk_GrabarPreciosHistoricos.Checked
        If Chk_NoguardarTABPRE.Visible Then
            Chk_NoguardarTABPRE.Checked = True
        End If
    End Sub
End Class

Namespace ListaDePrecios

    Public Class LsCamposAdicionalesTabpre

        Public Property Campo As String
        Public Property CampoFx As String

    End Class

End Namespace

