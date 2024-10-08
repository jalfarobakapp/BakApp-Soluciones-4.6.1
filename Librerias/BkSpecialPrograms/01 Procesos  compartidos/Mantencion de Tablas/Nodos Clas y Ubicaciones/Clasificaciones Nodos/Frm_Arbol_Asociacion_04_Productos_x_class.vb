﻿Imports DevComponents.DotNetBar

Public Class Frm_Arbol_Asociacion_04_Productos_x_class

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Codigo_Heredado As String

    Dim _Codigo_Nodo As Integer
    Dim _Identificador_NodoPadre As Integer
    Dim _Descripcion_Nodo, _Descripcion_Busqueda As String
    Dim _Carpeta_Seleccionable As Boolean
    Dim _Mostrar_Productos_Sin_Asociacion_En_Nodo As Boolean

    Dim _Cant_Filas As Integer

    Dim _Tbl_Productos_En_Carpeta As DataTable
    Dim _Tbl_Productos_En_Otras_Carpetas_Padre As DataTable

    Dim _Grabar As Boolean

    Dim _Row_Nodo As DataRow
    Private _Dv As New DataView
    Dim _Filtro_todos_los_productos As String

    Dim _Lista_Nodos As New List(Of Integer)

    Public Property ModoSoloLectura As Boolean

    Public Property Pro_Codigo_Heredado() As String
        Get
            Return _Codigo_Heredado
        End Get
        Set(value As String)
            _Codigo_Heredado = value
        End Set
    End Property
    Public ReadOnly Property Pro_Grabar() As Boolean
        Get
            Return _Grabar
        End Get
    End Property
    Public Property Pro_Lista_Nodos() As List(Of Integer)
        Get
            Return _Lista_Nodos
        End Get
        Set(value As List(Of Integer))
            _Lista_Nodos = value
        End Set
    End Property

    Public Sub New(Identificador_NodoPadre As Integer,
                   Codigo_Nodo As Integer,
                   Descripcion_Nodo As String,
                   Descripcion_Busqueda As String,
                   Carpeta_Seleccionable As Boolean,
                   Clas_Unica_X_Producto As Boolean,
                   Mostrar_Productos_Sin_Asociacion_En_Nodo As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Identificador_NodoPadre = Identificador_NodoPadre
        _Codigo_Nodo = Codigo_Nodo
        _Descripcion_Nodo = Descripcion_Nodo
        _Descripcion_Busqueda = Descripcion_Busqueda
        _Carpeta_Seleccionable = Carpeta_Seleccionable
        _Mostrar_Productos_Sin_Asociacion_En_Nodo = Mostrar_Productos_Sin_Asociacion_En_Nodo

        Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                       "Where Codigo_Nodo = " & _Codigo_Nodo

        _Row_Nodo = _Sql.Fx_Get_DataRow(Consulta_Sql)

        _Codigo_Heredado = String.Empty

        Sb_Color_Botones_Barra(Bar2)

        Txt_Filtrar.ReadOnly = False

    End Sub

    Private Sub Frm_Arbol_Asociacion_04_Productos_x_class_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Txt_Codigo_Madre.Text = _Row.Item("Codigo_Madre")
        Txt_Codigo_Nodo.Text = _Row.Item("Codigo_Nodo")
        Txt_Descripcion.Text = _Row.Item("Descripcion")

        Barra_Progreso_.Visible = False

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, True)
        Grilla.RowHeadersWidth = 15

        Sb_Llenar_Tablas()

        _Cant_Filas = Grilla.RowCount

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

        Btn_AgregarProductos.Visible = Not ModoSoloLectura

        If Not _Mostrar_Productos_Sin_Asociacion_En_Nodo Then
            Btn_Reparar_Arbol.Visible = True
        End If

        Btn_QuitarProducto.Visible = Not ModoSoloLectura
        Btn_Quitar_Marcados.Visible = Not ModoSoloLectura
        Btn_Quitar_Todo.Visible = Not ModoSoloLectura
        Btn_Quitar_Productos.Visible = Not ModoSoloLectura

        If _Carpeta_Seleccionable Then
            AddHandler Grilla.MouseUp, AddressOf Sb_Grilla_MouseUp
            AddHandler Chk_Seleccionar_Todos.CheckedChanged, AddressOf Sb_Chk_Seleccionar_Todos_CheckedChanged
        End If

        Me.ActiveControl = Txt_Filtrar

    End Sub

    Sub Sb_Llenar_Tablas()

        If _Mostrar_Productos_Sin_Asociacion_En_Nodo Then

            Consulta_Sql = "SELECT KOPR As Codigo,NOKOPR As Descripcion,Cast(0 as Bit) As En_Otra_Carpeta_Padre," &
                           "Cast(0 As bit) as Nuevo,Cast(0 As bit) As Codigo_Huacho" & vbCrLf &
                           "FROM MAEPR WHERE KOPR Not In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & Space(1) &
                           "Where Codigo_Nodo In" & vbCrLf &
                           "(Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Nodo_Raiz = " & _Codigo_Nodo & "))"
            Btn_Quitar_Productos.Visible = False

        Else

            If _Carpeta_Seleccionable Then

                Consulta_Sql = "SELECT Cast(0 As Bit) As Chk,Codigo,Isnull((Select Top 1 NOKOPR From MAEPR Where KOPR = Codigo),'') as Descripcion," & vbCrLf &
                               "(Select COUNT(*) From " & _Global_BaseBk & "Zw_Prod_Asociacion Z2 Where Z2.Codigo = Z1.Codigo And Z2.Codigo_Nodo In " & vbCrLf &
                               "(Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & Space(1) &
                               "Where Es_Seleccionable = 1 And Codigo_Nodo <> " & _Codigo_Nodo & ")) As En_Otra_Carpeta_Padre,Cast(0 As bit) as Nuevo,Cast(0 As bit) As Codigo_Huacho" & vbCrLf &
                               "Into #Paso" & vbCrLf &
                               "FROM " & _Global_BaseBk & "Zw_Prod_Asociacion Z1" & vbCrLf &
                               "Where Codigo_Nodo = " & _Codigo_Nodo & " and Para_filtro = 1" & vbCrLf &
                               "Order by Codigo" & vbCrLf &
                               "Select * From #Paso" & vbCrLf &
                               "Select * From #Paso Where En_Otra_Carpeta_Padre = 1" & vbCrLf &
                               "Drop Table #Paso"

            Else

                Consulta_Sql = "SELECT  Codigo,Isnull((Select Top 1 NOKOPR From MAEPR Where KOPR = Codigo),'') as Descripcion," & vbCrLf &
                               "(Select COUNT(*) From " & _Global_BaseBk & "Zw_Prod_Asociacion Z2 Where Z2.Codigo = Z1.Codigo And Z2.Codigo_Nodo In " & vbCrLf &
                               "(Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & Space(1) &
                               "Where Identificacdor_NodoPadre = " & _Identificador_NodoPadre & Space(1) &
                               "And Codigo_Nodo <> " & _Codigo_Nodo & ")) As En_Otra_Carpeta_Padre,Cast(0 As bit) as Nuevo,Cast(0 As bit) As Codigo_Huacho" & vbCrLf &
                               "Into #Paso" & vbCrLf &
                               "FROM " & _Global_BaseBk & "Zw_Prod_Asociacion Z1" & vbCrLf &
                               "Where Codigo_Nodo = " & _Codigo_Nodo & " and Para_filtro = 1" & vbCrLf &
                               "Order by Codigo" &
                               vbCrLf &
                               vbCrLf &
                               "Update #Paso Set Codigo_Huacho = 1 Where Codigo Not In" & vbCrLf &
                               "(Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Producto = 0 And Codigo_Nodo In" & vbCrLf &
                               "(Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Es_Seleccionable = 1 and Identificacdor_NodoPadre = " & _Codigo_Nodo & "))" &
                               vbCrLf &
                               vbCrLf &
                               "Select * From #Paso" & vbCrLf &
                               "Select * From #Paso Where En_Otra_Carpeta_Padre = 1" & vbCrLf &
                               "Select * From #Paso Where Codigo_Huacho = 1" & vbCrLf &
                               "Drop Table #Paso"

            End If

        End If

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql)

        _Tbl_Productos_En_Carpeta = _Ds.Tables("Table")
        _Dv.Table = _Tbl_Productos_En_Carpeta

        If Not _Mostrar_Productos_Sin_Asociacion_En_Nodo Then _Tbl_Productos_En_Otras_Carpetas_Padre = _Ds.Tables(1)

        If Not _Carpeta_Seleccionable And Not _Mostrar_Productos_Sin_Asociacion_En_Nodo Then

            Btn_Quitar_Productos.Visible = CBool(_Ds.Tables(2).Rows.Count)

        End If

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        With Grilla

            .DataSource = _Dv

            OcultarEncabezadoGrilla(Grilla)

            If _Carpeta_Seleccionable Then
                .Columns("Chk").Width = 30
                .Columns("Chk").HeaderText = "Sel."
                .Columns("Chk").Visible = _Carpeta_Seleccionable
                .Columns("Chk").ReadOnly = False
            End If

            .Columns("Codigo").Width = 110
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = True

            .Columns("Descripcion").Width = 400
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True

        End With

        'For Each _Fila As DataGridViewRow In Grilla.Rows
        '    Sb_Marcar_Fila(_Fila)
        'Next

        Lbl_Estatus.Text = "Total de productos: " & FormatNumber(Grilla.Rows.Count, 0)

    End Sub

    Sub Sb_Marcar_Fila(_Fila As DataGridViewRow)

        Dim _En_Otra_Carpeta_Padre As Boolean = CBool(_Fila.Cells("En_Otra_Carpeta_Padre").Value)
        Dim _Nuevo As Boolean = _Fila.Cells("Nuevo").Value
        Dim _Codigo_Huacho As Boolean = _Fila.Cells("Codigo_Huacho").Value

        If _Nuevo Then

            _Fila.DefaultCellStyle.BackColor = Color.LightGray

        Else

            If _En_Otra_Carpeta_Padre Then

                If Global_Thema = Enum_Themas.Oscuro Then

                    _Fila.DefaultCellStyle.ForeColor = Color.Gold

                Else

                    _Fila.DefaultCellStyle.BackColor = Color.PaleGoldenrod

                End If

            End If

            If _Codigo_Huacho Then _Fila.DefaultCellStyle.ForeColor = Rojo

        End If

    End Sub

    Sub Sb_Salir()
        Me.Close()
    End Sub

    Private Sub Frm_Arbol_Asociacion_04_Productos_x_class_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Sb_Salir()
        End If
    End Sub

    Private Sub Btn_AgregarProductos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_AgregarProductos.Click
        If Fx_Tiene_Permiso(Me, "Tbl00035") Then
            Sb_Agregar_Productos()
        End If
    End Sub

    Sub Sb_Agregar_Productos()

        Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_Productos_En_Carpeta, "", "Codigo", False, False, "'")

        Dim _Nodo_Raiz As Integer = _Row_Nodo.Item("Nodo_Raiz")
        Dim _Clas_Unica_X_Producto_Obligatorio = _Row_Nodo.Item("Clas_Unica_X_Producto")
        Dim _Descripcion = _Row_Nodo.Item("Descripcion")

        If Not _Clas_Unica_X_Producto_Obligatorio Then
            _Nodo_Raiz = _Codigo_Nodo
        End If

        Dim _Sql_Filtro_Condicion_Extra = "And KOPR Not In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo_Nodo = " & _Nodo_Raiz & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)
        _Filtrar.Pro_Descripcion_X_Defecto = _Codigo_Heredado

        Dim _Tbl_Filtro_Productos As DataTable

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            _Tbl_Filtro_Productos = _Filtrar.Pro_Tbl_Filtro

            If CBool(_Tbl_Filtro_Productos.Rows.Count) Then

                Bar2.Enabled = False
                Dim Consulta_sql As String

                Dim Clas_Nodos As New Clas_Arbol_Asociaciones(Me)
                Dim _Lista_Nodos As List(Of Integer)
                _Lista_Nodos = Clas_Nodos.Fx_Lista_Codigos_Raiz_Clasificacion(_Codigo_Nodo)

                If CBool(_Tbl_Filtro_Productos.Rows.Count) Then

                    _Filtro_Productos = Generar_Filtro_IN(_Tbl_Filtro_Productos, "Chk", "Codigo", False, True, "'")

                    Consulta_sql = String.Empty

                    Dim _Codigo_Nodo_H As Integer

                    For Each _Codigo_Nodo_H In _Lista_Nodos

                        If CBool(_Codigo_Nodo_H) Then

                            Consulta_sql += "Delete " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                                            "Where Codigo_Nodo = '" & _Codigo_Nodo_H & "' AND Para_filtro = 1" & vbCrLf &
                                            "And Codigo In " & _Filtro_Productos & vbCrLf &
                                            "Insert Into " & _Global_BaseBk & "Zw_Prod_Asociacion (Codigo,Codigo_Nodo,DescripcionBusqueda,Para_filtro,Nodo_origen,Clas_unica, Producto)" & vbCrLf &
                                            "Select KOPR,'" & _Codigo_Nodo_H & "','" & _Descripcion & "',1,0,0,0" & vbCrLf &
                                            "From MAEPR" & vbCrLf &
                                            "Where KOPR In " & _Filtro_Productos & vbCrLf

                        End If

                    Next

                    If Not String.IsNullOrEmpty(Consulta_sql) Then
                        If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return
                        End If
                    End If

                End If

                Consulta_sql = "SELECT  Codigo,Isnull((Select Top 1 NOKOPR From MAEPR Where KOPR = Codigo),'') as Descripcion" & vbCrLf &
                               "FROM " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                               "Where Codigo_Nodo = " & _Codigo_Nodo & " and Para_filtro = 1" & vbCrLf &
                               "Order by Codigo"

                Sb_Llenar_Tablas()
                _Cant_Filas = Grilla.RowCount

                _Grabar = True
                Bar2.Enabled = True

                Sb_Actualizar_Grilla()

                MessageBoxEx.Show(Me, "Productos asociados correctamente", "Agregar productos", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If

    End Sub

    Function Fx_Raiz_Clasificacion_FullPath(_Codigo_Nodo As String)

        Dim _Full As String = String.Empty
        Dim _CodPadre As String

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        _CodPadre = _Tbl.Rows(0).Item("Identificacdor_NodoPadre")

        Do While (_CodPadre <> 0)

            Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _CodPadre
            _Tbl = _Sql.Fx_Get_DataTable(Consulta_Sql)

            _CodPadre = _Tbl.Rows(0).Item("Identificacdor_NodoPadre")
            _Full = "\" & _Tbl.Rows(0).Item("Descripcion") & _Full

        Loop

        Return _Full

    End Function

    Private Sub Btn_Exportar_Excel_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Exportar_Excel.Click
        Dim _Tbl As DataTable = _Dv.ToTable
        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Prod_" & _Descripcion_Nodo)
    End Sub


    'Private Sub Txt_Descripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles Txt_Descripcion.TextChanged

    'Dim _Lista_Descripcion = Split(Trim(Txt_Descripcion.Text), " ", 3)

    'Dim _A As String = String.Empty
    'Dim _B As String = String.Empty
    'Dim _C As String = String.Empty

    'Select Case _Lista_Descripcion.Length
    '    Case 1
    '        _A = _Lista_Descripcion(0)
    '        _Dv.RowFilter = String.Format("Descripcion Like '%{0}%'", _A)
    '    Case 2
    '        _A = _Lista_Descripcion(0) : _B = _Lista_Descripcion(1)
    '        _Dv.RowFilter = String.Format("Descripcion Like '%{0}%' And Descripcion Like '%{1}%'", _A, _B)
    '    Case 3
    '        _A = _Lista_Descripcion(0) : _B = _Lista_Descripcion(1) : _C = _Lista_Descripcion(2)
    '        _Dv.RowFilter = String.Format("Descripcion Like '%{0}%' And Descripcion Like '%{1}%' And Descripcion Like '%{2}%'", _A, _B, _C)
    'End Select

    'For Each _Fila As DataGridViewRow In Grilla.Rows

    '    Dim _En_Otra_Carpeta_Padre As Boolean = CBool(_Fila.Cells("En_Otra_Carpeta_Padre").Value)
    '    Dim _Nuevo As Boolean = _Fila.Cells("Nuevo").Value
    '    Dim _Codigo_Huacho As Boolean = _Fila.Cells("Codigo_Huacho").Value

    '    If _Nuevo Then
    '        _Fila.DefaultCellStyle.BackColor = Color.LightGray
    '    Else
    '        If _En_Otra_Carpeta_Padre Then _Fila.DefaultCellStyle.BackColor = Color.PaleGoldenrod
    '        If _Codigo_Huacho Then _Fila.DefaultCellStyle.ForeColor = Rojo '_Fila.DefaultCellStyle.BackColor = Color.Tomato
    '    End If

    'Next

    'End Sub

    Private Sub Mnu_Btn_Ver_Asociaciones_Del_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Btn_Ver_Asociaciones_Del_Producto.Click

        Dim _Codigo As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value

        Dim Fm As New Frm_Arbol_Lista(False)
        Fm.Codigo_Heredado = _Codigo
        Fm.ModoCheckButton = True
        Fm.MostrarClasProducto = True
        Fm.ShowDialog(Me)
        Fm.Dispose()

        'Dim Fm As New Frm_Arbol_Asociacion_01
        'Fm.Pro_Codigo_Producto = _Codigo
        'Fm.Chk_Ver_Clas_Unicas.Checked = True
        'Fm.ShowDialog(Me)
        'Fm.Dispose()

    End Sub

    Private Sub Btn_Estadisticas_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Estadisticas_Producto.Click
        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
        Dim _Codigo As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        Fm.Sb_Ver_Informacion_Adicional_producto(Me, _Codigo)
        Fm.Dispose()
    End Sub

    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
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

    Private Sub Btn_Reparara_Arbol_Del_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Reparara_Arbol_Del_Producto.Click

        If Fx_Tiene_Permiso(Me, "Tbl00035") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Codigo = _Fila.Cells("Codigo").Value

            Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                           "Where Codigo = '" & _Codigo & "' And Producto = 0" & vbCrLf &
                           "And Codigo_Nodo In" & Space(1) &
                           "(Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Es_Seleccionable = 1)"

            Dim _TblNodos_Hijos_Asociados As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

            If _TblNodos_Hijos_Asociados.Rows.Count Then

                Dim _Clas_Nodo As New Clas_Arbol_Asociaciones(Me)

                Dim _Sql_Crear_Arbol = String.Empty

                For Each _Rows As DataRow In _TblNodos_Hijos_Asociados.Rows

                    Dim _Codigo_Nodo = _Rows.Item("Codigo_Nodo")

                    _Sql_Crear_Arbol += "Delete " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                                        "Where Codigo = '" & _Codigo & "'" & vbCrLf &
                                        "And Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & Space(1) &
                                        "Where Es_Seleccionable = 0) And Clas_unica = 0" & vbCrLf & vbCrLf

                    _Sql_Crear_Arbol += _Clas_Nodo.Fx_Crear_Arbol_de_productos(_Codigo_Nodo, _Codigo_Nodo) & vbCrLf

                Next

                If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then

                    Sb_Marcar_Fila(_Fila)

                    MessageBoxEx.Show(Me, "Arbol del producto reconstruido", "Reconstrucción de arbol",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Else

                Dim _Codigo_Huacho As Boolean = _Fila.Cells("Codigo_Huacho").Value
                Dim _TblNodos_Huachos As DataTable

                If _Codigo_Huacho Then
                    Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                                   "Where Codigo = '" & _Codigo & "'" & vbCrLf &
                                   "And Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & Space(1) &
                                   "Where Es_Seleccionable = 0) And Clas_unica = 0" & vbCrLf & vbCrLf

                    _TblNodos_Huachos = _Sql.Fx_Get_DataTable(Consulta_Sql)

                    If CBool(_TblNodos_Huachos.Rows.Count) Then

                        Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                                       "Where Codigo = '" & _Codigo & "'" & vbCrLf &
                                       "And Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & Space(1) &
                                       "Where Es_Seleccionable = 0) And Clas_unica = 0" & vbCrLf & vbCrLf

                        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

                        End If

                    End If

                End If

            End If

            Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Asociacion",
                                                "Codigo = '" & _Codigo & "' And Codigo_Nodo = " & _Codigo_Nodo & " And Producto = 0")

            If Not CBool(_Reg) Then
                _Fila.DefaultCellStyle.BackColor = Color.Tomato
                _Fila.DefaultCellStyle.ForeColor = Color.Black

                Beep()
                ToastNotification.Show(Me, "PRODUCTO ACTUALIZADO CORRECTAMENTE",
                                       My.Resources.ok_button,
                                      1 * 1000, eToastGlowColor.Blue, eToastPosition.MiddleCenter)

            End If

        End If

    End Sub

    Private Sub Btn_Quitar_Productos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Quitar_Productos.Click
        If Fx_Tiene_Permiso(Me, "Tbl00035") Then
            Sb_Quitar_Productos(Enum_Quitar.Quitar_Seleccionados)
            'ShowContextMenu(Menu_Contextual_02)
        End If
    End Sub

    Private Sub Btn_Reparar_Arbol_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Reparar_Arbol.Click

        If Fx_Tiene_Permiso(Me, "Tbl00035") Then
            Bar2.Enabled = False
            Dim Consulta_sql As String

            Dim Clas_Nodos As New Clas_Arbol_Asociaciones(Me)
            Dim _Lista_Nodos As List(Of Integer)
            _Lista_Nodos = Clas_Nodos.Fx_Lista_Codigos_Raiz_Clasificacion(_Codigo_Nodo)

            If CBool(_Tbl_Productos_En_Carpeta.Rows.Count) Then

                Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_Productos_En_Carpeta, "", "Codigo", False, False, "'")

                Consulta_sql = String.Empty
                Dim _Codigo_Nodo_H As Integer
                For Each _Codigo_Nodo_H In _Lista_Nodos

                    If CBool(_Codigo_Nodo_H) Then
                        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo_Nodo = '" & _Codigo_Nodo_H & "' AND Para_filtro = 1" & vbCrLf &
                                       "And Codigo In " & _Filtro_Productos & vbCrLf &
                                       "Insert Into " & _Global_BaseBk & "Zw_Prod_Asociacion (Codigo,Codigo_Nodo,DescripcionBusqueda,Para_filtro,Nodo_origen,Clas_unica, Producto)" & vbCrLf &
                                       "Select KOPR,'" & _Codigo_Nodo_H & "',NOKOPR,1,0,0,0" & vbCrLf &
                                       "From MAEPR" & vbCrLf &
                                       "Where KOPR In " & _Filtro_Productos & vbCrLf
                        _Sql.Ej_consulta_IDU(Consulta_sql)
                    End If

                Next
            End If


            Beep()
            ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE",
                                        My.Resources.ok_button,
                                       2 * 1000, eToastGlowColor.Blue, eToastPosition.MiddleCenter)

            Consulta_sql = "SELECT  Codigo,Isnull((Select Top 1 NOKOPR From MAEPR Where KOPR = Codigo),'') as Descripcion" & vbCrLf &
                           "FROM " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                           "Where Codigo_Nodo = " & _Codigo_Nodo & " and Para_filtro = 1" & vbCrLf &
                           "Order by Codigo"

            Sb_Llenar_Tablas()
            _Cant_Filas = Grilla.RowCount

            _Grabar = True
            Bar2.Enabled = True

        End If

    End Sub

    Enum Enum_Quitar
        Quitar_Todos
        Quitar_Seleccionados
        Quitar_Huachos
        Quitar_SoloUno
    End Enum

    Sub Sb_Quitar_Productos(_Accion As Enum_Quitar)

        Dim Consulta_sql As String

        Dim Clas_Nodos As New Clas_Arbol_Asociaciones(Me)
        Dim _Lista_Nodos As List(Of Integer)
        Dim _Index_Eliminados As New List(Of Integer)
        Dim _Contador As Integer

        _Lista_Nodos = Clas_Nodos.Fx_Lista_Codigos_Raiz_Clasificacion(_Codigo_Nodo)

        Try

            Bar2.Enabled = False

            For Each _Fila As DataGridViewRow In Grilla.Rows 'Grilla.SelectedRows

                If _Fila.Cells("Chk").Value Then

                    Dim _Codigo = _Fila.Cells("Codigo").Value
                    Dim _Index = _Fila.Index

                    _Index_Eliminados.Add(_Index)
                    _Contador += 1

                End If

            Next

            If _Accion <> Enum_Quitar.Quitar_SoloUno AndAlso Not CBool(_Contador) Then
                Beep()
                ToastNotification.Show(Me, "NO HAY REGISTROS MARCADOS",
                                        My.Resources.cross,
                                       2 * 1000, eToastGlowColor.Blue, eToastPosition.MiddleCenter)
                Return
            End If

            Consulta_sql = String.Empty

            Dim _Filtro_Productos As String

            Select Case _Accion

                Case Enum_Quitar.Quitar_SoloUno

                    Dim _Fila As DataGridViewRow = Grilla.CurrentRow

                    Dim _Codigo = _Fila.Cells("Codigo").Value
                    Dim _Index = _Fila.Index

                    _Index_Eliminados.Add(_Index)
                    _Contador = 1
                    _Filtro_Productos = "('" & _Codigo & "')"

                Case Enum_Quitar.Quitar_Seleccionados

                    'For Each _Fila As DataGridViewRow In Grilla.Rows 'Grilla.SelectedRows

                    '    If _Fila.Cells("Chk").Value Then

                    '        Dim _Codigo = _Fila.Cells("Codigo").Value
                    '        Dim _Index = _Fila.Index

                    '        _Index_Eliminados.Add(_Index)

                    '        _Contador += 1

                    '    End If

                    'Next

                    _Filtro_Productos = Generar_Filtro_IN(_Tbl_Productos_En_Carpeta, "Chk", "Codigo", False, True, "'", True)

                Case Enum_Quitar.Quitar_Todos

                    _Filtro_Productos = Generar_Filtro_IN(_Tbl_Productos_En_Carpeta, "", "Codigo", False, False, "'")
                    _Contador = _Tbl_Productos_En_Carpeta.Rows.Count

            End Select

            Dim _Msg As String

            If _Accion = Enum_Quitar.Quitar_SoloUno Then
                _Msg = "¿Está seguro de quitar este registro?"
            Else
                _Msg = "¿Está seguro de quitar los registros seleccionados?" & vbCrLf &
                       "Registros seleccionados (" & _Contador & ")"
            End If

            If MessageBoxEx.Show(Me, _Msg, "Quitar registros",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                Return
            End If

            For Each _Codigo_Nodo_H In _Lista_Nodos

                If CBool(_Codigo_Nodo_H) Then
                    Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo_Nodo = '" & _Codigo_Nodo_H & "' And Para_filtro = 1" & vbCrLf &
                                   "And Codigo In " & _Filtro_Productos
                    _Sql.Ej_consulta_IDU(Consulta_sql)
                End If

            Next

            _Index_Eliminados.Sort(Function(x, y) y.CompareTo(x))

            For Each _Ix In _Index_Eliminados
                Grilla.Rows.RemoveAt(_Ix)
            Next

            Beep()
            ToastNotification.Show(Me, "REGISTROS QUITADOS " & FormatNumber(_Contador, 0),
                                        Btn_Quitar_Productos.Image,
                                       2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

            Lbl_Estatus.Text = "Total de productos: " & FormatNumber(Grilla.Rows.Count, 0)


        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema al quitar registros", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Bar2.Enabled = True
        End Try

    End Sub

    Sub Sb_Quitar_Productos_Old(_Accion As Enum_Quitar)

        Dim Consulta_sql As String

        Try

            Bar2.Enabled = False

            Dim _Marcados = Grilla.SelectedRows.Count

            If CBool(_Marcados) Then

                Dim _Index_Eliminados As New List(Of Integer)

                Dim _Contador As Integer

                Dim Clas_Nodos As New Clas_Arbol_Asociaciones(Me)
                Dim _Lista_Nodos As List(Of Integer)
                _Lista_Nodos = Clas_Nodos.Fx_Lista_Codigos_Raiz_Clasificacion(_Codigo_Nodo)

                Consulta_sql = String.Empty

                Dim _Arreglo(_Marcados - 1) As String
                Dim _Filtro_Productos As String

                Select Case _Accion

                    Case Enum_Quitar.Quitar_SoloUno

                        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

                        Dim _Codigo = _Fila.Cells("Codigo").Value
                        Dim _Index = _Fila.Index

                        _Index_Eliminados.Add(_Index)
                        _Contador = 1
                        _Filtro_Productos = "('" & _Codigo & "')"

                    Case Enum_Quitar.Quitar_Seleccionados

                        For Each _Fila As DataGridViewRow In Grilla.Rows 'Grilla.SelectedRows

                            If _Fila.Cells("Chk").Value Then

                                Dim _Codigo = _Fila.Cells("Codigo").Value
                                Dim _Index = _Fila.Index

                                _Index_Eliminados.Add(_Index)

                                _Arreglo(_Contador) = _Codigo
                                _Contador += 1

                            End If

                        Next


                        _Filtro_Productos = Generar_Filtro_IN_Arreglo(_Arreglo, False)

                    Case Enum_Quitar.Quitar_Todos

                        _Filtro_Productos = Generar_Filtro_IN(_Tbl_Productos_En_Carpeta, "", "Codigo", False, False, "'")
                        _Contador = _Tbl_Productos_En_Carpeta.Rows.Count
                        For Each _Fila As DataGridViewRow In Grilla.Rows
                            Dim _Index = _Fila.Index
                            _Index_Eliminados.Add(_Index)
                        Next

                    Case Enum_Quitar.Quitar_Huachos

                        For Each _Fila As DataGridViewRow In Grilla.Rows

                            Dim _Codigo = _Fila.Cells("Codigo").Value
                            Dim _Codigo_Huacho = _Fila.Cells("Codigo_Huacho").Value
                            Dim _Index = _Fila.Index

                            If _Codigo_Huacho Then
                                ReDim Preserve _Arreglo(_Contador)
                                _Index_Eliminados.Add(_Index)
                                _Arreglo(_Contador) = _Codigo
                                _Contador += 1
                            End If

                        Next

                        _Filtro_Productos = Generar_Filtro_IN_Arreglo(_Arreglo, False)

                End Select


                If MessageBoxEx.Show(Me, "¿Está seguro de quitar los registros marcados?" & vbCrLf &
                                   "Registros marcados (" & _Contador & ")", "Quitar registros", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    For Each _Codigo_Nodo_H In _Lista_Nodos
                        If CBool(_Codigo_Nodo_H) Then
                            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo_Nodo = '" & _Codigo_Nodo_H & "' AND Para_filtro = 1" & vbCrLf &
                                           "And Codigo In " & _Filtro_Productos
                            _Sql.Ej_consulta_IDU(Consulta_sql)
                        End If
                    Next

                    If _Accion = Enum_Quitar.Quitar_Huachos Then
                        Sb_Llenar_Tablas()
                        Sb_Actualizar_Grilla()
                    Else
                        For Each _Ix In _Index_Eliminados
                            Grilla.Rows.RemoveAt(_Ix)
                        Next

                        Beep()
                        ToastNotification.Show(Me, "REGISTROS QUITADOS " & FormatNumber(_Contador, 0),
                                                    Btn_Quitar_Productos.Image,
                                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                        Lbl_Estatus.Text = "Total de productos: " & FormatNumber(Grilla.Rows.Count, 0)
                    End If

                End If
            Else
                Beep()
                ToastNotification.Show(Me, "NO HAY REGISTROS MARCADOS",
                                            My.Resources.cross,
                                           2 * 1000, eToastGlowColor.Blue, eToastPosition.MiddleCenter)
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Bar2.Enabled = True
        End Try

    End Sub

    Private Sub Btn_Quitar_Marcados_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Quitar_Marcados.Click
        Sb_Quitar_Productos(Enum_Quitar.Quitar_Seleccionados)
    End Sub

    Private Sub Quitar_Todo_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Quitar_Todo.Click
        Sb_Quitar_Productos(Enum_Quitar.Quitar_Todos)
    End Sub

    Private Sub Txt_Filtrar_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Filtrar.KeyDown
        If e.KeyValue = Keys.Enter Then
            _Dv.RowFilter = String.Format("Codigo+Descripcion Like '%" & Txt_Filtrar.Text & "%'")
        End If
    End Sub

    Private Sub Btn_QuitarProducto_Click(sender As Object, e As EventArgs) Handles Btn_QuitarProducto.Click
        Sb_Quitar_Productos(Enum_Quitar.Quitar_SoloUno)
    End Sub

    Private Sub Btn_Ver_documento_origen_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ver_documento_origen.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim Copiar = Trim(_Fila.Cells(_Cabeza).Value)
        Clipboard.SetText(Copiar)

    End Sub

    Private Sub Grilla_KeyUp(sender As Object, e As KeyEventArgs) Handles Grilla.KeyUp

        RemoveHandler Chk_Seleccionar_Todos.CheckedChanged, AddressOf Sb_Chk_Seleccionar_Todos_CheckedChanged
        Chk_Seleccionar_Todos.Checked = False

        Dim _Key = e.KeyData

        If _Key = Keys.ControlKey Then

            If Grilla.SelectedRows.Count > 1 Then
                For Each _Fila As DataGridViewRow In Grilla.SelectedRows
                    Dim _Chk As Boolean = _Fila.Cells("Chk").Value
                    If _Chk Then
                        _Fila.Cells("Chk").Value = False
                    Else
                        _Fila.Cells("Chk").Value = True
                    End If
                Next
            End If

        End If

        Grilla.EndEdit()
        AddHandler Chk_Seleccionar_Todos.CheckedChanged, AddressOf Sb_Chk_Seleccionar_Todos_CheckedChanged

    End Sub

    Private Sub Sb_Chk_Seleccionar_Todos_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Dim chk As Boolean = Chk_Seleccionar_Todos.Checked
        ChequearTodo(Grilla, chk, "")
    End Sub

    Private Function ChequearTodo(Grilla As DataGridView,
                         Chk As Boolean,
                         TipoFiltro As String)


        For Each _Fila As DataGridViewRow In Grilla.Rows
            _Fila.Cells("Chk").Value = Chk
        Next

        Grilla.CurrentCell = Grilla.Rows(0).Cells("Codigo")

    End Function

    Private Sub Txt_Filtrar_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Filtrar.ButtonCustom2Click
        Txt_Filtrar.Text = String.Empty
        _Dv.RowFilter = String.Format("Codigo+Descripcion Like '%" & Txt_Filtrar.Text & "%'")
    End Sub

    Private Sub Sb_Grilla_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

        If IsNothing(Grilla.CurrentCell) Then
            Return
        End If

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        RemoveHandler Chk_Seleccionar_Todos.CheckedChanged, AddressOf Sb_Chk_Seleccionar_Todos_CheckedChanged

        Chk_Seleccionar_Todos.Checked = False

        Dim keysMod As Keys = Control.ModifierKeys

        If keysMod <> Keys.Control Then

            If Grilla.SelectedRows.Count > 1 Then
                For Each _Fila As DataGridViewRow In Grilla.SelectedRows
                    _Fila.Cells("Chk").Value = Not _Fila.Cells("Chk").Value
                Next
            End If

            If Grilla.SelectedRows.Count = 1 And _Cabeza = "Chk" Then
                Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
                _Fila.Cells("Chk").Value = Not _Fila.Cells("Chk").Value
            End If

        End If

        Grilla.EndEdit()
        AddHandler Chk_Seleccionar_Todos.CheckedChanged, AddressOf Sb_Chk_Seleccionar_Todos_CheckedChanged

    End Sub

End Class
