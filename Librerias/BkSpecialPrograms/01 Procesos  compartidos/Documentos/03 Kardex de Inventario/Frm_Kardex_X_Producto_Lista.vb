'Imports Lib_Bakapp_VarClassFunc
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DevComponents.DotNetBar

Public Class Frm_Kardex_X_Producto_Lista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Codigo As String
    Dim _Row_Producto As DataRow

    Dim _Tbl_Productos_Hermanos As DataTable
    Dim _Tbl_Productos As DataTable

    Dim _Ds As DataSet
    Private _dv As New DataView

    Dim _Mostrar_Kardex_Asociados As Boolean

    Public Property Pro_Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
            Consulta_sql = "Select Top 1 * From MAEPR Where KOPR = '" & _Codigo & "'"
            _Row_Producto = _Sql.Fx_Get_DataRow(Consulta_sql)

            Txt_Descripcion.Text = _Codigo

        End Set
    End Property

    Public Property Pro_Mostrar_Kardex_Asociados As Boolean
        Get
            Return _Mostrar_Kardex_Asociados
        End Get
        Set(value As Boolean)
            _Mostrar_Kardex_Asociados = value
        End Set
    End Property

    Public Property Pro_Tbl_Productos_Hermanos As DataTable
        Get
            Return _Tbl_Productos_Hermanos
        End Get
        Set(value As DataTable)
            _Tbl_Productos_Hermanos = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(GrillaListaProductos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, True, False)
        Sb_Formato_Generico_Grilla(Grilla_Detalle_Stock, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Total_Stock, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_DocmentoLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "ZW_PermisosVsUsuarios", "CodUsuario = '" & FUNCIONARIO & "' And CodPermiso Like 'Bo" & ModEmpresa & "%'")

        If _Reg = 0 Then
            MessageBoxEx.Show(Me, "Usted no tiene permisos para ninguna bodega en Bakapp", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
            Return
        End If

        Sb_Actualizar_Listado(False)

        AddHandler Grilla_Detalle_Stock.CellDoubleClick, AddressOf Sb_DrobleClic_en_Grilla
        AddHandler GrillaListaProductos.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla_Detalle_Stock.MouseDown, AddressOf Sb_Grilla_MouseDown

        AddHandler Rdb_Ud1.CheckedChanged, AddressOf Rdb_Ud_CheckedChanged
        AddHandler Rdb_Ud2.CheckedChanged, AddressOf Rdb_Ud_CheckedChanged

        If Not String.IsNullOrEmpty(_Codigo) Then
            If BuscarDatoEnGrilla(Trim(_Codigo), "KOPR", GrillaListaProductos) = True Then
                GrillaListaProductos.Focus()
            End If
        End If

        If _Mostrar_Kardex_Asociados Then Sb_Ver_Kardex_Productos_Hermanos(_Codigo)

        Me.ActiveControl = Txt_Descripcion

    End Sub

    Sub Sb_Actualizar_Listado(_Ver_Kardex_Asociados As Boolean)

        Dim _Texto_Busqueda As String
        Dim _Cadena As String
        Dim _Condicion = String.Empty

        Dim _Tx = Split(Txt_Descripcion.Text, ";")

        If _Tx.Length > 1 Then

            For i = 0 To _Tx.Length - 1

                If _Ver_Kardex_Asociados Then
                    _Condicion += "(MP.KOPR = '" & _Tx(i).Trim & "')" & vbCrLf
                Else
                    _Cadena = CADENA_A_BUSCAR(_Tx(i).Trim, "MP.KOPR+NOKOPR LIKE '%")
                    _Condicion += "(MP.KOPR+NOKOPR LIKE '%" & _Cadena & "%')" & vbCrLf
                End If

                If i <> _Tx.Length - 1 Then
                    _Condicion += "Or "
                End If

            Next

            _Condicion = "And (" & _Condicion & ")"

        Else
            _Texto_Busqueda = Txt_Descripcion.Text.Trim
            _Cadena = CADENA_A_BUSCAR(RTrim$(_Texto_Busqueda), "MP.KOPR+NOKOPR LIKE '%")
            _Condicion = "And MP.KOPR+NOKOPR LIKE '%" & _Cadena & "%'" & vbCrLf
        End If

        Consulta_sql = My.Resources.Recursos_Kardex.Kardex_por_producto
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#ListaPrecio#", ModListaPrecioVenta)

        If ChkMostrarOcultos.Checked Then
            _Condicion += "MP.ATPR<>'OCU' AND"
        End If

        Consulta_sql = Replace(Consulta_sql, "#Reemplazos#", String.Empty)

        Consulta_sql = "SELECT Top 200 
                               MP.TIPR,
                               MP.KOPR,
                               MP.NOKOPR,
                               MP.UD01PR,
                               MP.UD02PR,
                               MP.RLUD,
                               Isnull( TP.PP01UD,0) As PP01UD,
                               Isnull( TP.PP01UD,0) As PP02UD
                          FROM MAEPR MP INNER JOIN MAEPREM 
                            ON MAEPREM.KOPR=MP.KOPR 
                            AND MAEPREM.EMPRESA='" & ModEmpresa & "'  
                                LEFT JOIN TABPRE TP 
                            ON MP.KOPR=TP.KOPR 
                            AND TP.KOLT= '" & ModListaPrecioVenta & "'   
                        WHERE  
                            MP.ATPR<>'OCU' AND 
                            MP.TIPR<>'SSN'  
                            " & _Condicion & "
                        ORDER BY MP.KOPR OPTION ( FAST 20 )"

        '_Ds = _Sql.Fx_Get_DataSet(Consulta_sql)
        '_dv.Table = _Ds.Tables(0)

        _Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_sql)

        With GrillaListaProductos

            .DataSource = _Tbl_Productos

            .Columns("TIPR").Visible = False

            .Columns("KOPR").HeaderText = "Código"
            .Columns("KOPR").Width = 110

            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Width = 330

            .Columns("PP01UD").HeaderText = "Precio Ud1"
            .Columns("PP01UD").Width = 90
            .Columns("PP01UD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PP01UD").DefaultCellStyle.Format = "$ ###,##"

            .Columns("PP02UD").HeaderText = "Precio Ud2"
            .Columns("PP02UD").Width = 90
            .Columns("PP02UD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PP02UD").DefaultCellStyle.Format = "$ ###,##"

            .Columns("RLUD").HeaderText = "Rtu"
            .Columns("RLUD").Width = 60
            .Columns("RLUD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("UD01PR").HeaderText = "Ud1"
            .Columns("UD01PR").Width = 30

            .Columns("UD02PR").HeaderText = "Ud2"
            .Columns("UD02PR").Width = 30

        End With

        If CBool(GrillaListaProductos.Rows.Count) Then
            GrillaListaProductos.CurrentCell = GrillaListaProductos.Rows(0).Cells("KOPR")
        End If

    End Sub

    Sub Sb_Llenar_Stock_Por_Producto(ByVal _Codigo As String) ',

        Dim _Tbl_Detalle_Stock As DataTable
        Dim _Tbl_Total_Stock As DataTable

        Dim _Unidad As Integer

        If Rdb_Ud1.Checked Then
            _Unidad = Rdb_Ud1.Tag
        Else
            _Unidad = Rdb_Ud2.Tag
        End If

        Consulta_sql = My.Resources.Recursos_Kardex.Kardex_Stock_Productos_por_Suc_Bod
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Codigo)
        Consulta_sql = Replace(Consulta_sql, "#Ud#", _Unidad)
        Consulta_sql = Replace(Consulta_sql, "#ListaPrecio#", ModListaPrecioVenta)
        Consulta_sql = Replace(Consulta_sql, "#Kofu#", FUNCIONARIO)
        Consulta_sql = Replace(Consulta_sql, "#Global_BaseBk#", _Global_BaseBk)

        _Tbl_Detalle_Stock = _Sql.Fx_Get_Tablas(Consulta_sql)


        Consulta_sql = "SELECT " & vbCrLf &
                       "'ZZ' as EMPRESA," & vbCrLf &
                       "'..' as KOSU," & vbCrLf &
                       "'..' as KOBO," & vbCrLf &
                       "'Total' as SUC_BOD," & vbCrLf &
                       "MST.KOPR AS KOPR," & vbCrLf &
                       "SUM(MST.STFI" & _Unidad & ") AS STFI" & _Unidad & ",             -- STOCK FISICO" & vbCrLf &
                       "SUM(MST.STDV" & _Unidad & ") AS STDV" & _Unidad & " ,            -- STOCK DEVENGADO" & vbCrLf &
                       "SUM(MST.DESPNOFAC" & _Unidad & ") AS DESPNOFAC" & _Unidad & ",   -- DESPACHADO SIN FACTURAR " & vbCrLf &
                       "SUM(MST.STOCNV" & _Unidad & ") AS STOCNV" & _Unidad & ",         -- STOCK COMPROMETIDO" & vbCrLf &
                       "SUM(MST.STDV" & _Unidad & "C) AS STDV" & _Unidad & "C,           -- COMPRAS NO RECEPCIONADAS" & vbCrLf &
                       "SUM(MST.RECENOFAC" & _Unidad & ") AS RECENOFAC" & _Unidad & ",   -- RECEPCIONADO SIN FACTURAR" & vbCrLf &
                       "SUM(MST.STOCNV" & _Unidad & "C) AS STOCNV" & _Unidad & "C,       -- STOCK PEDIDO" & vbCrLf &
                       "'' AS DATOSUBIC                                                  -- UBICACION EN BODEGA" & vbCrLf &
                       "From MAEST MST WITH ( NOLOCK )  " & vbCrLf &
                       "WHERE MST.KOPR = '" & _Codigo & "' AND MST.EMPRESA = '" & ModEmpresa & "'" & vbCrLf &
                       "GROUP BY KOPR"

        _Tbl_Total_Stock = _Sql.Fx_Get_Tablas(Consulta_sql)

        Sb_Formato_Y_Llenar_Grilla_Stock(Grilla_Detalle_Stock, _Tbl_Detalle_Stock, True)
        Sb_Formato_Y_Llenar_Grilla_Stock(Grilla_Total_Stock, _Tbl_Total_Stock, False)

        If CBool(_Tbl_Total_Stock.Rows.Count) Then
            Grilla_Detalle_Stock.CurrentCell = Grilla_Detalle_Stock.Rows(0).Cells("SUC_BOD")
        End If

    End Sub

    Sub Sb_Formato_Y_Llenar_Grilla_Stock(ByRef _Grilla As DevComponents.DotNetBar.Controls.DataGridViewX,
                                        ByVal _Tbl As DataTable,
                                        ByVal _Mostrar_Datos_Ubic As Boolean)

        Dim _Unidad As Integer

        If Rdb_Ud1.Checked Then
            _Unidad = Rdb_Ud1.Tag
        Else
            _Unidad = Rdb_Ud2.Tag
        End If

        With _Grilla

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(_Grilla, True)

            .Columns("SUC_BOD").HeaderText = "Suc-Bod"
            .Columns("SUC_BOD").Width = 70
            .Columns("SUC_BOD").Visible = True

            .Columns("STFI" & _Unidad).HeaderText = "Stock Físico"
            .Columns("STFI" & _Unidad).Width = 80
            .Columns("STFI" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STFI" & _Unidad).DefaultCellStyle.Format = "##,#0"
            .Columns("STFI" & _Unidad).ToolTipText = "Stock Físico"
            .Columns("STFI" & _Unidad).Visible = True

            .Columns("STDV" & _Unidad).HeaderText = "Devengado"
            .Columns("STDV" & _Unidad).Width = 75
            .Columns("STDV" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STDV" & _Unidad).DefaultCellStyle.Format = "###,#0"
            .Columns("STDV" & _Unidad).ToolTipText = "Facturado al cliente sin entregar físicamente, pendiente de generar guía de despacho"
            .Columns("STDV" & _Unidad).Visible = True

            .Columns("DESPNOFAC" & _Unidad).HeaderText = "Desp.S/Fac"
            .Columns("DESPNOFAC" & _Unidad).Width = 75
            .Columns("DESPNOFAC" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DESPNOFAC" & _Unidad).DefaultCellStyle.Format = "###,#0"
            .Columns("DESPNOFAC" & _Unidad).ToolTipText = "Despachado con guía que aún no han sido facturadas"
            .Columns("DESPNOFAC" & _Unidad).Visible = True

            .Columns("STOCNV" & _Unidad).HeaderText = "Comprom."
            .Columns("STOCNV" & _Unidad).Width = 75
            .Columns("STOCNV" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STOCNV" & _Unidad).DefaultCellStyle.Format = "###,#0"
            .Columns("STOCNV" & _Unidad).ToolTipText = "Notas de venta pendiente [NVV][NVI]"
            .Columns("STOCNV" & _Unidad).Visible = True

            .Columns("STDV" & _Unidad & "C").HeaderText = "Comp.N/Rec"
            .Columns("STDV" & _Unidad & "C").Width = 75
            .Columns("STDV" & _Unidad & "C").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STDV" & _Unidad & "C").DefaultCellStyle.Format = "###,#0"
            .Columns("STDV" & _Unidad & "C").ToolTipText = "Facturas de compra que no han movido Stock físico, aún falta la guía de recepción de mercadería"
            .Columns("STDV" & _Unidad & "C").Visible = True

            .Columns("RECENOFAC" & _Unidad).HeaderText = "Rece.S/Fac"
            .Columns("RECENOFAC" & _Unidad).Width = 75
            .Columns("RECENOFAC" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RECENOFAC" & _Unidad).DefaultCellStyle.Format = "###,#0"
            .Columns("RECENOFAC" & _Unidad).ToolTipText = "Guías de proveedores que aún no han sido facturadas"
            .Columns("RECENOFAC" & _Unidad).Visible = True

            .Columns("STOCNV" & _Unidad & "C").HeaderText = "Pedido"
            .Columns("STOCNV" & _Unidad & "C").Width = 75
            .Columns("STOCNV" & _Unidad & "C").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STOCNV" & _Unidad & "C").DefaultCellStyle.Format = "###,#0"
            .Columns("STOCNV" & _Unidad & "C").ToolTipText = "Ordenes de compra pendientes [OCI][OCC]"
            .Columns("STOCNV" & _Unidad & "C").Visible = True

            .Columns("DATOSUBIC").HeaderText = "Ubicación"
            .Columns("DATOSUBIC").Width = 160
            .Columns("DATOSUBIC").Visible = _Mostrar_Datos_Ubic

            For Each _Fila As DataGridViewRow In .Rows

                Dim _SUC_BOD = _Fila.Cells("SUC_BOD").Value

                If _SUC_BOD = "Total" Then
                    If Global_Thema = Enum_Themas.Oscuro Then
                        _Fila.DefaultCellStyle.ForeColor = Color.Gold
                    Else
                        _Fila.DefaultCellStyle.BackColor = Color.Yellow
                    End If
                End If

            Next

            For Each _Fila As DataGridViewRow In _Grilla.Rows

                Dim _Suc_Bod = Trim(_Fila.Cells("SUC_BOD").Value)

                'Dim _Sucursal As String = _Fila.Cells("Sucursal").Value
                'Dim _Bodega As String = _Fila.Cells("Bodega").Value

                If String.IsNullOrEmpty(_Suc_Bod) Then
                    If Global_Thema = Enum_Themas.Oscuro Then
                        _Fila.DefaultCellStyle.BackColor = Color.Black
                        _Fila.DefaultCellStyle.ForeColor = Color.Gold
                    Else
                        _Fila.DefaultCellStyle.BackColor = Color.Gold
                    End If
                Else
                    If Global_Thema = Enum_Themas.Oscuro Then
                        _Fila.DefaultCellStyle.BackColor = Color.Black
                    Else
                        _Fila.DefaultCellStyle.BackColor = Color.White
                    End If
                End If

                If _Suc_Bod = "Total" Then
                    If Global_Thema = Enum_Themas.Oscuro Then
                        _Fila.DefaultCellStyle.ForeColor = Color.Gold
                        Exit For
                    Else
                        _Fila.DefaultCellStyle.BackColor = Color.Yellow
                    End If
                End If

                For Each Columna As DataGridViewColumn In _Grilla.Columns
                    Dim _Columna As String = Columna.Name
                    If _Columna.Contains("1") Or _Columna.Contains("2") Then

                        Dim _Valor As Double = _Fila.Cells(_Columna).Value

                        Dim _Color_Cero As Color = Color.LightGray
                        Dim _Color_Positivo As Color = Color.Black
                        Dim _Color_Negativo As Color = Rojo

                        If Global_Thema = Enum_Themas.Oscuro Then
                            _Color_Cero = Color.FromArgb(60, 60, 60)
                            _Color_Positivo = Verde
                        End If

                        If _Valor = 0 Then
                            _Fila.Cells(_Columna).Style.ForeColor = _Color_Cero
                        ElseIf _Valor < 0 Then
                            _Fila.Cells(_Columna).Style.ForeColor = Rojo
                        ElseIf _Valor > 0 Then
                            _Fila.Cells(_Columna).Style.ForeColor = _Color_Positivo
                        End If

                    End If
                Next

            Next





        End With

    End Sub

    Private Sub GrillaListaProductos_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrillaListaProductos.CellEnter
        Try

            Dim Codigo As String
            Codigo = GrillaListaProductos.Rows(GrillaListaProductos.CurrentRow.Index).Cells("KOPR").Value

            Sb_Llenar_Stock_Por_Producto(Codigo) ', GrillaUd1, 1)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Codigo_abuscar = String.Empty

        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt

        Fm.Pro_Tipo_Lista = "C" '.Tipo_Busqueda_Productos = Fm.Buscar_En.Maestro_de_Productos
        Fm.Pro_Lista_Busqueda = ModListaPrecioVenta
        Fm.Pro_CodEntidad = String.Empty
        Fm.Pro_Mostrar_Info = False 'MostrarOcultos = True
        Fm.Pro_Actualizar_Precios = False
        Fm.BtnBuscarAlternativos.Visible = True
        Fm.BtnCrearProductos.Visible = False
        Fm.BtnExportaExcel.Visible = False
        Fm.ShowDialog(Me)

        If Fm.Pro_Seleccionado Then
            If Not (Fm.Pro_RowProducto Is Nothing) Then
                Codigo_abuscar = Fm.Pro_RowProducto.Item("KOPR")
            End If

            If Not String.IsNullOrEmpty(Trim(Codigo_abuscar)) Then
                If BuscarDatoEnGrilla(Trim(Codigo_abuscar), "KOPR", GrillaListaProductos) = True Then
                    GrillaListaProductos.Focus()
                End If
            End If
        End If
        Fm.Dispose()

    End Sub

    Sub Sb_DrobleClic_en_Grilla(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Fila As DataGridViewRow = sender.Rows(sender.CurrentRow.Index)

        Dim _Cabeza = sender.Columns(sender.CurrentCell.ColumnIndex).Name
        _Codigo = _Fila.Cells("KOPR").Value
        Dim _Empresa = _Fila.Cells("EMPRESA").Value
        Dim _Sucursal = _Fila.Cells("KOSU").Value
        Dim _Bodega = _Fila.Cells("KOBO").Value

        If _Cabeza = "DATOSUBIC" Then
            Call Mnu_Btn_Cambiar_Ubicacion_Click(Nothing, Nothing)
        Else
            Sb_Revisar_Kardex()
        End If

    End Sub

    Sub Sb_Revisar_Kardex() '(ByVal Grilla As DataGridView)

        Try
            Dim _Fila As DataGridViewRow = Grilla_Detalle_Stock.Rows(Grilla_Detalle_Stock.CurrentRow.Index) ' Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Codigo = _Fila.Cells("KOPR").Value
            Dim _Empresa = _Fila.Cells("EMPRESA").Value
            Dim _Sucursal = _Fila.Cells("KOSU").Value
            Dim _Bodega = _Fila.Cells("KOBO").Value

            Dim _Unidad As Integer

            If Rdb_Ud1.Checked Then
                _Unidad = Rdb_Ud1.Tag
            Else
                _Unidad = Rdb_Ud2.Tag
            End If

            Dim Fm As New Frm_Kardex_Procesar_Estudio_X_Producto(_Empresa, _Sucursal, _Bodega, _Codigo, _Unidad)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub BtnKardex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKardex.Click
        Sb_Revisar_Kardex()
    End Sub

    Private Sub Frm_DocumentoLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Txt_Descripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Descripcion.KeyDown

        If e.KeyValue = Keys.Enter Or e.KeyValue = Keys.Space Then

            Sb_Actualizar_Listado(False)

            If Not CBool(GrillaListaProductos.Rows.Count) Then
                Sb_Llenar_Stock_Por_Producto(Txt_Descripcion.Text)
            End If
        End If

    End Sub

    Function Fx_Tbl_Productos_Hermanos(_Codigo As String)

        Dim _Nodo_Raiz_Asociados = _Global_Row_Configuracion_General.Item("Nodo_Raiz_Asociados")

        Consulta_sql = "SELECT Top 1 * From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                       "Where (Codigo = '" & _Codigo & "') AND (Para_filtro = 1)" & vbCrLf &
                       "And Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Nodo_Raiz = " & _Nodo_Raiz_Asociados & ")"

        Dim _Row_Nodo_Clasificaciones As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Codigo_Nodo As Integer

        If _Row_Nodo_Clasificaciones Is Nothing Then
            _Codigo_Nodo = 0
        Else
            _Codigo_Nodo = _Row_Nodo_Clasificaciones.Item("Codigo_Nodo")
        End If

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
        _Row_Nodo_Clasificaciones = _Sql.Fx_Get_DataRow(Consulta_sql)

        Consulta_sql = "SELECT KOPR FROM MAEPR WHERE KOPR IN (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & Space(1) &
                       "Where Codigo_Nodo = " & _Codigo_Nodo & " And Codigo_Nodo <> 0)"
        Fx_Tbl_Productos_Hermanos = _Sql.Fx_Get_Tablas(Consulta_sql)

    End Function

    Private Sub Btn_Ver_Informacion_Producto_Click(sender As Object, e As EventArgs) Handles Mnu_Btn_Ver_Informacion_Producto.Click

        If Fx_Tiene_Permiso(Me, "Prod009") Then

            Dim _Fila As DataGridViewRow = GrillaListaProductos.Rows(GrillaListaProductos.CurrentRow.Index)
            Dim _Codigo As String = _Fila.Cells("KOPR").Value

            Dim Fm As New Frm_EstadisticaProducto(_Codigo)
            Fm.Chk_Rotacion_Con_Ent_Excluidas.Checked = False
            Fm.ShowInTaskbar = True
            Fm.BtnKardex.Enabled = False
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

    End Sub

    Private Sub Mnu_Btn_Ver_Kardex_Productos_Hermanos_Click(sender As Object, e As EventArgs) Handles Mnu_Btn_Ver_Kardex_Productos_Hermanos.Click

        Dim _Fila As DataGridViewRow = GrillaListaProductos.Rows(GrillaListaProductos.CurrentRow.Index)
        Dim _Codigo = _Fila.Cells("KOPR").Value

        Sb_Ver_Kardex_Productos_Hermanos(_Codigo)

    End Sub

    Sub Sb_Ver_Kardex_Productos_Hermanos(_Codigo As String)

        Dim _Tbl_Productos_Hermanos As DataTable = Fx_Tbl_Productos_Hermanos(_Codigo)
        Dim _Filtro_Prod_Hermanos = Generar_Filtro_IN(_Tbl_Productos_Hermanos, "", "KOPR", False, False, "", False)

        Txt_Descripcion.Text = Replace(_Filtro_Prod_Hermanos, ",", ";")

        Sb_Actualizar_Listado(True)

        If BuscarDatoEnGrilla(Trim(_Codigo), "KOPR", GrillaListaProductos) = True Then
            GrillaListaProductos.Focus()
        End If

    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Dim _Nombre_Grilla As String = sender.Name

        If CBool(GrillaListaProductos.Rows.Count) Then

            If e.Button = Windows.Forms.MouseButtons.Right Then
                With sender
                    Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                    If Hitest.Type = DataGridViewHitTestType.Cell Then
                        .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                        Dim _Fila As DataGridViewRow = GrillaListaProductos.Rows(GrillaListaProductos.CurrentRow.Index)

                        Dim _Codigo_Actual = _Fila.Cells("KOPR").Value

                        If _Codigo_Actual = _Codigo Then
                            Mnu_Btn_Ver_Informacion_Producto.Enabled = False
                        Else
                            Mnu_Btn_Ver_Informacion_Producto.Enabled = True
                        End If

                        If _Nombre_Grilla = "GrillaListaProductos" Then
                            ShowContextMenu(Menu_Contextual_01_Opciones_Producto)
                        ElseIf _Nombre_Grilla = "Grilla_Detalle_Stock" Then
                            ShowContextMenu(Menu_Contextual_02_Opciones_Detalle_Stock)
                        End If
                    End If
                End With
            End If
        End If

    End Sub

    Private Sub Btn_Copiar_Click(sender As Object, e As EventArgs) Handles Btn_Copiar.Click
        With GrillaListaProductos

            Dim _Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
            Dim _Texto_Cabeza = .Columns(.CurrentCell.ColumnIndex).HeaderText

            Dim Copiar = .Rows(.CurrentRow.Index).Cells(_Cabeza).Value
            Clipboard.SetText(Copiar)

            ToastNotification.Show(Me, _Texto_Cabeza & " esta en el portapapeles", Btn_Copiar.Image,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        End With
    End Sub

    Private Sub Sb_Buscar_En_Grilla_Dataview(_Descripcion_a_buscar As String)

        _Descripcion_a_buscar = Replace(_Descripcion_a_buscar, vbTab, "")

        Dim _Descripcion As String = Replace(_Descripcion_a_buscar, "'", "")

        If IsNothing(_Descripcion) Then _Descripcion = String.Empty

        Dim _Contiene_Punto_Coma As Boolean = _Descripcion.Contains(";")
        Dim _Lista_Descripciones() As String

        Dim _Lista_productos_A_Buscar As String = String.Empty

        If _Contiene_Punto_Coma Then

            'Cmb_Filtro_Codigo.SelectedValue = "I"

            _Lista_Descripciones = Split(_Descripcion, ";")

            For i = 0 To _Lista_Descripciones.Length - 1
                If i = 0 Then
                    _Lista_productos_A_Buscar += Fx_Descripcion(_Lista_Descripciones(i))
                Else
                    _Lista_productos_A_Buscar += Fx_Descripcion(_Lista_Descripciones(i), " Or ")
                End If
            Next

        Else

            'Cmb_Filtro_Codigo.SelectedValue = "C"

            _Lista_Descripciones = Split(_Descripcion, " ")

            For i = 0 To _Lista_Descripciones.Length - 1
                If i = 0 Then
                    _Lista_productos_A_Buscar += Fx_Descripcion(_Lista_Descripciones(i))
                Else
                    _Lista_productos_A_Buscar += Fx_Descripcion(_Lista_Descripciones(i), " And ")
                End If
            Next

        End If

        _dv.RowFilter = _Lista_productos_A_Buscar

    End Sub

    Private Function Fx_Descripcion(_Buscar As String, Optional _And_Or As String = "") As String

        'Dim _Descripcion_Busqueda = String.Empty

        'If Not String.IsNullOrEmpty(_Buscar) Then
        '    Select Case Cmb_Filtro_Codigo.SelectedValue
        '        Case "C" ' Contiene
        '            _Descripcion_Busqueda = _And_Or & "KOPR+NOKOPR Like '%" & _Buscar & "%'"
        '        Case "I" ' Igual a 
        '            _Descripcion_Busqueda = _And_Or & "KOPR Like '" & _Buscar & "'"
        '            'Case "T" ' Termina
        '            '_Descripcion_Busqueda = _And_Or & "Descripcion Like '%" & _Buscar & "'"
        '            'Case "E" ' Empieza
        '            '_Descripcion_Busqueda = _And_Or & "Descripcion Like '" & _Buscar & "'%"
        '    End Select
        'End If

        'Return _Descripcion_Busqueda

    End Function

    Private Sub Btn_Ayuda_Asistente_Busqueda_Click(sender As Object, e As EventArgs) Handles Btn_Ayuda_Asistente_Busqueda.Click

        Dim _Msg = "Para buscar una lista de productos puede digitar los códigos exactos a buscar separados por "";"" (punto y coma)" & vbCrLf &
                   "Ejemplo: CODIGO01;CODIGO02;CODIGO03" & vbCrLf & vbCrLf &
                   "Puede buscar registros por algo de la descripción utilizando algo de la descripción o bien las palabras completas, " &
                   "pero deben ir separadas por espacios entre las palabras" & vbCrLf &
                   "Ejemplo: RUEDA DELANTERA SUZUKI"

        MessageBoxEx.Show(Me, _Msg, "Ayuda, asistente de busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Mnu_Ver_Kardex_Stock_Click(sender As Object, e As EventArgs) Handles Mnu_Ver_Kardex_Stock.Click
        Sb_Revisar_Kardex()
    End Sub

    Private Sub Mnu_Btn_Cambiar_Ubicacion_Click(sender As Object, e As EventArgs) Handles Mnu_Btn_Cambiar_Ubicacion.Click

        If _Global_Row_Configuracion_General.Item("Utilizar_Ubicaciones_WCM") Then

            MessageBoxEx.Show(Me, "No se puede cambiar la ubicación desde este control, se debe cambiar desde el sistema de WMS", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Return

        End If

        If Fx_Tiene_Permiso(Me, "Prod058") Then

            Dim _Fila As DataGridViewRow = Grilla_Detalle_Stock.Rows(Grilla_Detalle_Stock.CurrentRow.Index)

            Dim _Codigo = _Fila.Cells("KOPR").Value
            Dim _Empresa = Trim(_Fila.Cells("EMPRESA").Value)
            Dim _Sucursal = Trim(_Fila.Cells("KOSU").Value)
            Dim _Bodega = Trim(_Fila.Cells("KOBO").Value)
            Dim _Ubicacion As String = Trim(_Fila.Cells("DATOSUBIC").Value)
            Dim _OldUbicacion As String = "([" & _Empresa & "-" & _Sucursal & "-" & _Bodega & "] --> " & _Ubicacion & ")"

            Dim _Ingresar As Boolean

            If Not String.IsNullOrEmpty(_Ubicacion) Then
                If MessageBoxEx.Show(Me, "¿Está seguro de querer cambiar la ubicación del producto?",
                                     "Cambiar ubicación", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = DialogResult.Yes Then
                    _Ingresar = True
                End If
            Else
                _Ingresar = True
            End If

            If _Ingresar Then

                Dim _Aceptado As Boolean = InputBox_Bk(Me, "Ingrese nueva unbicación Máx. 20 Caracteres",
                                                       "Cambiar Ubicación", _Ubicacion, False,, 20, True)

                If _Aceptado Then

                    Consulta_sql = "Update TABBOPR Set DATOSUBIC = '" & _Ubicacion & "'" & vbCrLf &
                                   "Where EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sucursal & "' And KOBO = '" & _Bodega & "' And KOPR = '" & _Codigo & "'"

                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                        Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "", 0, "",
                                           "CAMBIO DE UBICACION DEL PRODUCTO," & Space(1) &
                                           "NUEVA UBICACION (" & _Empresa & "-" & _Sucursal & "-" & _Bodega & " -> " & _Ubicacion & ")" & Space(1) &
                                           "UBICACION ANTERIOR " & _OldUbicacion,
                                           "Prod058", _Codigo, "", "", False, "")

                        _Fila.Cells("DATOSUBIC").Value = _Ubicacion
                        MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Cambiar Ubicación",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                End If

            End If

        End If

    End Sub

    Private Sub Rdb_Ud_CheckedChanged(sender As Object, e As EventArgs)
        If CBool(GrillaListaProductos.Rows.Count) Then
            Dim Codigo As String
            Codigo = GrillaListaProductos.Rows(GrillaListaProductos.CurrentRow.Index).Cells("KOPR").Value

            Sb_Llenar_Stock_Por_Producto(Codigo)
        End If
    End Sub

End Class
