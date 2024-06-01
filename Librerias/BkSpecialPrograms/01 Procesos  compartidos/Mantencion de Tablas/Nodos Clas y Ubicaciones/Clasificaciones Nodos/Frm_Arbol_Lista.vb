Imports DevComponents.DotNetBar

Public Class Frm_Arbol_Lista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Clas_Unica_X_Producto As Boolean

    Public Sub New(_Clas_Unica_X_Producto As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Clas_Unica_X_Producto = _Clas_Unica_X_Producto

    End Sub

    Private Sub Frm_Arbol_Lista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Tree_Bandeja.CheckBoxes = False

        If Global_Thema = Enum_Themas.Oscuro Then
            Tree_Bandeja.ImageList = Imagenes_16x16_Dark
        End If

        Dim fuenteNegrita As New Font(Tree_Bandeja.Font.Name, Tree_Bandeja.Font.Size, FontStyle.Bold)
        Dim _NodoRaiz As TreeNode

        _NodoRaiz = Fx_CrearNodo(0, "CLASIFICACIONES UNICAS", False, "CLASUNICAS", 4, 4)
        '_NodoRaiz.NodeFont = fuenteNegrita

        Sb_Cargar_Nodos(_NodoRaiz, _Clas_Unica_X_Producto)

        Tree_Bandeja.Nodes.Add(_NodoRaiz)

        For Each nodo As TreeNode In Tree_Bandeja.Nodes
            nodo.Expand()
        Next

    End Sub

    Sub Sb_Cargar_Nodos(_Nodo_Padre As TreeNode, _Clas_Unica_X_Producto As Boolean)

        Dim _Identificacdor_NodoPadre = _Nodo_Padre.Tag

        Dim _Filtro As String

        If _Clas_Unica_X_Producto Then
            _Filtro = "And Clas_Unica_X_Producto = 1"
        Else
            _Filtro = "And Clas_Unica_X_Producto = 0"
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                       "Where Identificacdor_NodoPadre = " & _Identificacdor_NodoPadre & vbCrLf &
                       _Filtro
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If _Tbl.Rows.Count = 0 Then
            Return
        End If

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Codigo_Nodo As Integer = _Fila.Item("Codigo_Nodo")
            Dim _Descripcion As String = _Fila.Item("Descripcion").ToString.Trim
            Dim _Codigo_Madre As String = _Fila.Item("Codigo_Madre").ToString.Trim
            Dim _Es_Padre As Boolean = _Fila.Item("Es_Padre")
            Dim _Es_Seleccionable As Boolean = _Fila.Item("Es_Seleccionable")

            Dim _Nodo As TreeNode

            If Not String.IsNullOrWhiteSpace(_Codigo_Madre) And _Codigo_Madre <> _Descripcion Then
                _Descripcion = _Codigo_Madre & " - " & _Descripcion
            End If

            If _Es_Seleccionable Then
                _Nodo = Fx_CrearNodo(_Codigo_Nodo, _Descripcion, _Es_Seleccionable, _Codigo_Nodo, 2, 3)
            Else
                _Nodo = Fx_CrearNodo(_Codigo_Nodo, _Descripcion, _Es_Seleccionable, _Codigo_Nodo, 0, 0)
            End If

            _Nodo_Padre.Nodes.Add(_Nodo)

            If _Es_Padre Then
                Sb_Cargar_Nodos(_Nodo, _Clas_Unica_X_Producto)
            End If

        Next

    End Sub

    Function Fx_CrearNodo(_Tag As String, _Text As String, _Checked As Boolean, _Name As String, _ImageIndex As Integer, _SelectedImageIndex As Integer) As TreeNode

        Dim _Nodo As New TreeNode

        With _Nodo

            .Name = _Name
            .Text = _Text
            .ImageIndex = _ImageIndex
            .SelectedImageIndex = _SelectedImageIndex
            .Tag = _Tag
            .Checked = _Checked

        End With

        Return _Nodo

    End Function

    Private Sub Tree_Bandeja_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles Tree_Bandeja.AfterSelect

        Dim _Nodo As TreeNode = e.Node

    End Sub

    Sub Sb_VerProductos_X_Class_X_Fila(_Nodo As TreeNode)

        Dim _Codigo_Nodo As String = _Nodo.Tag
        Dim _Descripcion As String = _Nodo.Text
        Dim _Identificador_NodoPadre As Integer = _Nodo.Parent.Tag
        Dim _Es_Seleccionable = _Nodo.Checked
        Dim _FullPath As String = _Nodo.FullPath

        Dim Fm As New Frm_Arbol_Asociacion_04_Productos_x_class(_Identificador_NodoPadre,
                                                                _Codigo_Nodo,
                                                                _Descripcion,
                                                                _FullPath,
                                                                _Es_Seleccionable,
                                                                _Clas_Unica_X_Producto,
                                                                False)
        Fm.Pro_Codigo_Heredado = "" '_Codigo_Heredado
        Fm.Text = "Clasificación: (Cod. " & _Codigo_Nodo & ") " & _Descripcion
        'Fm.Pro_Lista_Nodos = _Lista_Nodos
        Fm.ShowDialog(Me)

        If Fm.Pro_Grabar Then

            'Consulta_sql = "Update " & _Tbl_Tabla_De_Paso & " Set Prod_Ass = " & De_Num_a_Tx_01(_Fila.Cells("Prod_Ass").Value, False, 5) & vbCrLf &
            '               "Where Id = " & _Id
            '_Sql.Ej_consulta_IDU(Consulta_sql)

        End If

    End Sub

    Private Sub Tree_Bandeja_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles Tree_Bandeja.NodeMouseDoubleClick

        Dim _Nodo As TreeNode = e.Node

        ' Uso de la función
        Dim nodoRaiz As TreeNode = Tree_Bandeja.SelectedNode
        'Dim todosLosNodos As List(Of TreeNode) = ObtenerDescendientes(nodoRaiz)

        ' Uso:
        Dim nodosAnteriores As New List(Of TreeNode)
        RecorrerNodosAnteriores(nodoRaiz, nodosAnteriores)
        ' La lista 'nodosAnteriores' ahora contiene los nodos anteriores al último nodo seleccionado.

        Sb_VerProductos_X_Class_X_Fila(_Nodo)

    End Sub

    ' Función recursiva para buscar un nodo por etiqueta
    Function BuscarNodoPorEtiqueta(nodoPadre As TreeNode, etiquetaBuscada As String) As TreeNode

        If nodoPadre.Tag IsNot Nothing AndAlso nodoPadre.Text.ToUpper.Contains(etiquetaBuscada.ToUpper) Then
            Return nodoPadre
        End If

        For Each nodoHijo As TreeNode In nodoPadre.Nodes
            Dim nodoEncontrado As TreeNode = BuscarNodoPorEtiqueta(nodoHijo, etiquetaBuscada)
            If nodoEncontrado IsNot Nothing Then
                Return nodoEncontrado
            End If
        Next

        Return Nothing

    End Function

    Private Sub Txt_Filtrar_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Filtrar.KeyDown

        If e.KeyValue = Keys.Enter Then
            ' Uso de la función
            Dim etiquetaBuscada As String = Txt_Filtrar.Text
            Dim nodoEncontrado As TreeNode = BuscarNodoPorEtiqueta(Tree_Bandeja.Nodes(0), etiquetaBuscada)
            If nodoEncontrado IsNot Nothing Then
                ' Haz algo con el nodo encontrado
                Tree_Bandeja.Focus()
                nodoEncontrado.EnsureVisible()
                Tree_Bandeja.SelectedNode = nodoEncontrado
                nodoEncontrado.Expand()
            End If
        End If

    End Sub


    ' Función recursiva para obtener todos los nodos descendientes
    Function ObtenerDescendientes(nodoPadre As TreeNode) As List(Of TreeNode)
        Dim nodos As New List(Of TreeNode)()

        ' Agregar el nodo actual
        nodos.Add(nodoPadre)

        ' Recorrer los nodos hijos
        For Each nodoHijo As TreeNode In nodoPadre.Nodes
            nodos.AddRange(ObtenerDescendientes(nodoHijo))
        Next

        Return nodos
    End Function

    Private Sub RecorrerNodosAnteriores(nodo As TreeNode, listaNodos As List(Of TreeNode))
        If nodo IsNot Nothing Then
            listaNodos.Add(nodo)
            RecorrerNodosAnteriores(nodo.Parent, listaNodos)
        End If
    End Sub

    Private Sub Tree_Bandeja_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles Tree_Bandeja.NodeMouseClick

        Dim _Nodo As TreeNode = e.Node
        Tree_Bandeja.SelectedNode = _Nodo

        If e.Button = MouseButtons.Right Then

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Asociacion", "Codigo_Nodo = " & _Nodo.Tag)

            Lbl_TotalProductos.Text = "Total productos asociados: " & FormatNumber(_Reg, 0)

            If _Nodo.Checked Then
                ShowContextMenu(Menu_Contextual_01)
            Else
                ShowContextMenu(Menu_Contextual_02)
            End If

        End If

    End Sub

    Private Sub Btn_VerProductos_Click(sender As Object, e As EventArgs) Handles Btn_VerProductos.Click

        Dim _Nodo As TreeNode = Tree_Bandeja.SelectedNode
        Sb_VerProductos_X_Class_X_Fila(_Nodo)

    End Sub

    Private Sub Btn_CambiarNombreCarpeta_Click(sender As Object, e As EventArgs) Handles Btn_CambiarNombreCarpeta.Click

        Dim _Nodo As TreeNode = Tree_Bandeja.SelectedNode
        Dim _Codigo_Nodo As Integer = _Nodo.Tag
        Dim _Descripcion As String = _Nodo.Text
        Dim _Codigo_Madre As String = _Nodo.Name

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        _Codigo_Madre = _Row.Item("Codigo_Madre")
        _Descripcion = _Row.Item("Descripcion")

        Dim _Aceptar As Boolean

        _Aceptar = InputBox_Bk(Me, "Nombre de la descripción de la clasificación", "Editar",
                               _Descripcion, True, _Tipo_Mayus_Minus.Normal, 200, True, _Tipo_Imagen.Folder)

        If Not _Aceptar Then
            Return
        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Set Descripcion = '" & _Descripcion & "'" & vbCrLf &
                       "Where Codigo_Nodo = " & _Codigo_Nodo & vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Prod_Asociacion Set DescripcionBusqueda = '" & _Descripcion & "'" & vbCrLf &
                       "Where Codigo_Nodo = " & _Codigo_Nodo
        If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Not String.IsNullOrEmpty(_Codigo_Madre) Then
            _Descripcion = _Codigo_Madre & " - " & _Descripcion
        End If
        _Nodo.Text = _Descripcion

    End Sub

    Private Sub Btn_Copiar_Click(sender As Object, e As EventArgs) Handles Btn_Copiar.Click

        Dim _Nodo As TreeNode = Tree_Bandeja.SelectedNode
        Dim _Codigo_Nodo As Integer = _Nodo.Tag
        Dim _Descripcion As String = _Nodo.Text
        Dim _Codigo_Madre As String = _Nodo.Name

        Dim Copiar = _Descripcion
        Clipboard.SetText(Copiar)

        ToastNotification.Show(Me, _Descripcion & " esta en el portapapeles", Btn_Copiar.Image,
                               2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

    End Sub

    Private Sub Btn_CrearClasificacion_Click(sender As Object, e As EventArgs) Handles Btn_CrearClasificacion.Click

        Dim _Nodo As TreeNode = Tree_Bandeja.SelectedNode
        Dim _Codigo_Nodo As Integer = _Nodo.Tag
        Dim _Descripcion As String = _Nodo.Text
        Dim _Codigo_Madre As String = _Nodo.Name

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Private Sub Btn_CambiarNombreCarpeta2_Click(sender As Object, e As EventArgs) Handles Btn_CambiarNombreCarpeta2.Click

        Call Btn_CambiarNombreCarpeta_Click(Nothing, Nothing)

    End Sub

    Private Sub Btn_EliminarClasificacion_Click(sender As Object, e As EventArgs) Handles Btn_EliminarClasificacion.Click

        Dim _Nodo As TreeNode = Tree_Bandeja.SelectedNode
        Dim _Codigo_Nodo As Integer = _Nodo.Tag
        Dim _Descripcion As String = _Nodo.Text
        Dim _Codigo_Madre As String = _Nodo.Name

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Private Sub Btn_Copiar2_Click(sender As Object, e As EventArgs) Handles Btn_Copiar2.Click
        Call Btn_Copiar_Click(Nothing, Nothing)
    End Sub
End Class
