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

        If _Clas_Unica_X_Producto Then
            Me.Text = "CLASIFICACIONES UNICAS"
        Else
            Me.Text = "CLASIFICACIONES DINAMICAS"
        End If

        Tree_Bandeja.CheckBoxes = False

        If Global_Thema = Enum_Themas.Oscuro Then
            Tree_Bandeja.ImageList = Imagenes_16x16_Dark
        End If

        Sb_Cargar_Arbol()

    End Sub

    Sub Sb_Cargar_Arbol()

        Tree_Bandeja.Nodes.Clear()

        Dim fuenteNegrita As New Font(Tree_Bandeja.Font.Name, Tree_Bandeja.Font.Size, FontStyle.Bold)
        Dim _NodoRaiz As TreeNode

        _NodoRaiz = Fx_CrearNodo(0, "CLASIFICACIONES UNICAS", False, False, 4, 4)
        '_NodoRaiz.NodeFont = fuenteNegrita

        Sb_Cargar_Nodos(_NodoRaiz, _Clas_Unica_X_Producto)

        Tree_Bandeja.Nodes.Add(_NodoRaiz)

        For Each nodo As TreeNode In Tree_Bandeja.Nodes
            nodo.Expand()
        Next

    End Sub

    Sub Sb_Cargar_Nodos(_Nodo_Padre As TreeNode, _Clas_Unica_X_Producto As Boolean)

        Dim _Identificacdor_NodoPadre = _Nodo_Padre.Name

        If _Identificacdor_NodoPadre = "Raiz" Then _Identificacdor_NodoPadre = 0

        Dim _Filtro As String

        If _Clas_Unica_X_Producto Then
            _Filtro = "And Clas_Unica_X_Producto = 1" & vbCrLf & "Order By Codigo_Madre"
        Else
            _Filtro = "And Clas_Unica_X_Producto = 0" & vbCrLf & "Order By Descripcion"
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
                _Nodo = Fx_CrearNodo(_Codigo_Nodo, _Descripcion, _Es_Seleccionable, _Es_Seleccionable, 7, 8)
            Else
                _Nodo = Fx_CrearNodo(_Codigo_Nodo, _Descripcion, _Es_Seleccionable, _Es_Seleccionable, 0, 0)
            End If

            _Nodo_Padre.Nodes.Add(_Nodo)

            If _Es_Padre Then
                Sb_Cargar_Nodos(_Nodo, _Clas_Unica_X_Producto)
            End If

        Next

    End Sub

    Function Fx_CrearNodo(_Name As String,
                          _Text As String,
                          _Checked As Boolean,
                          _Tag As Object,
                          _ImageIndex As Integer,
                          _SelectedImageIndex As Integer) As TreeNode

        Dim _Nodo As New TreeNode

        With _Nodo

            .Name = _Name
            .Text = _Text
            .ImageIndex = _ImageIndex
            .SelectedImageIndex = _SelectedImageIndex
            .Checked = _Checked
            .Tag = _Tag

        End With

        Return _Nodo

    End Function

    Private Sub Tree_Bandeja_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles Tree_Bandeja.AfterSelect

        Dim _Nodo As TreeNode = e.Node

    End Sub

    Sub Sb_VerProductos_X_Class_X_Fila(_Nodo As TreeNode)

        Dim _Codigo_Nodo As String = _Nodo.Name
        Dim _Descripcion As String = _Nodo.Text
        Dim _Identificador_NodoPadre As Integer = _Nodo.Parent.Name
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
        Dim nodoRaiz As TreeNode = Tree_Bandeja.SelectedNode

        'Dim todosLosNodos As List(Of TreeNode) = ObtenerDescendientes(nodoRaiz)

        '' Uso:
        'Dim nodosAnteriores As New List(Of TreeNode)
        'RecorrerNodosAnteriores(nodoRaiz, nodosAnteriores)
        '' La lista 'nodosAnteriores' ahora contiene los nodos anteriores al último nodo seleccionado.
        If _Nodo.Checked Then
            Sb_VerProductos_X_Class_X_Fila(_Nodo)
        End If

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

            If _Nodo.Name = 0 Then
                Return
            End If

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Asociacion", "Codigo_Nodo = " & _Nodo.Name)

            Lbl_TotalProductos.Text = "Id: " & _Nodo.Name & ",Total productos asociados: " & FormatNumber(_Reg, 0)

            'LabelItem1.Visible = _Nodo.Checked
            Btn_VerProductos.Enabled = _Nodo.Checked
            Btn_TicketProducto.Enabled = _Nodo.Checked
            Btn_CrearClasificacion.Enabled = Not _Nodo.Checked

            ShowContextMenu(Menu_Contextual_01)

        End If

    End Sub

    Private Sub Btn_VerProductos_Click(sender As Object, e As EventArgs) Handles Btn_VerProductos.Click

        Dim _Nodo As TreeNode = Tree_Bandeja.SelectedNode
        Sb_VerProductos_X_Class_X_Fila(_Nodo)

    End Sub

    Private Sub Btn_CambiarNombreCarpeta_Click(sender As Object, e As EventArgs) Handles Btn_CambiarNombreCarpeta.Click

        If Not Fx_Tiene_Permiso(Me, "Tbl00005") Then
            Return
        End If

        Dim _Nodo As TreeNode = Tree_Bandeja.SelectedNode
        Dim _Codigo_Nodo As Integer = _Nodo.Name
        Dim _Descripcion As String = _Nodo.Text

        Dim _Grabar As Boolean

        Dim Fm As New Frm_Arbol_Asociacion_06_CrearEditar(_Codigo_Nodo, _Nodo.Parent.Name, 0, _Clas_Unica_X_Producto)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            _Descripcion = _Row.Item("Descripcion")

            If Not String.IsNullOrEmpty(_Row.Item("Codigo_Madre")) Then
                _Descripcion = _Row.Item("Codigo_Madre") & " - " & _Row.Item("Descripcion")
            End If

            _Nodo.Text = _Descripcion

            Dim _Es_Padre As Boolean = _Row.Item("Es_Padre")
            Dim _Es_Seleccionable As Boolean = _Row.Item("Es_Seleccionable")

            _Nodo.Checked = _Es_Seleccionable

            If _Es_Seleccionable Then
                _Nodo.ImageIndex = 7
                _Nodo.SelectedImageIndex = 8
            Else
                _Nodo.ImageIndex = 0
                _Nodo.SelectedImageIndex = 0
            End If

        End If

    End Sub

    Private Sub Btn_Copiar_Click(sender As Object, e As EventArgs) Handles Btn_Copiar.Click

        Dim _Nodo As TreeNode = Tree_Bandeja.SelectedNode
        Dim _Codigo_Nodo As Integer = _Nodo.Name
        Dim _Descripcion As String = _Nodo.Text

        Dim Copiar = _Descripcion
        Clipboard.SetText(Copiar)

        ToastNotification.Show(Me, _Descripcion & " esta en el portapapeles", Btn_Copiar.Image,
                               2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

    End Sub

    Private Sub Btn_CrearClasificacion_Click(sender As Object, e As EventArgs) Handles Btn_CrearClasificacion.Click

        If Not Fx_Tiene_Permiso(Me, "Tbl00004") Then
            Return
        End If

        Dim _Nodo As TreeNode = Tree_Bandeja.SelectedNode
        Dim _Codigo_Nodo As Integer = _Nodo.Name
        Dim _Descripcion As String = _Nodo.Text
        Dim _Grabar As Boolean

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Nodo_Raiz As Integer = _Row.Item("Nodo_Raiz")

        If _Nodo_Raiz = 0 Then
            _Nodo_Raiz = _Codigo_Nodo
        End If

        Dim _Cl_Arbol_Asociaciones As Cl_Arbol_Asociaciones

        Dim Fm As New Frm_Arbol_Asociacion_06_CrearEditar(0, _Codigo_Nodo, _Nodo_Raiz, _Clas_Unica_X_Producto)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _Cl_Arbol_Asociaciones = Fm.Cl_Arbol_Asociaciones
        Fm.Dispose()

        If _Grabar Then

            _Codigo_Nodo = _Cl_Arbol_Asociaciones.Zw_TblArbol_Asociaciones.Codigo_Nodo

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
            _Row = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _NewNodo As TreeNode

            If Not String.IsNullOrWhiteSpace(_Row.Item("Codigo_Madre")) And _Row.Item("Codigo_Madre") <> _Row.Item("Descripcion") Then
                _Descripcion = _Row.Item("Codigo_Madre") & " - " & _Row.Item("Descripcion")
            Else
                _Descripcion = _Row.Item("Descripcion")
            End If

            If _Row.Item("Es_Seleccionable") Then
                _NewNodo = Fx_CrearNodo(_Codigo_Nodo, _Descripcion, True, True, 7, 8)
            Else
                _NewNodo = Fx_CrearNodo(_Codigo_Nodo, _Descripcion, False, False, 0, 0)
            End If

            _Nodo.Nodes.Add(_NewNodo)
            _Nodo.Expand()

        End If

    End Sub

    Private Sub Btn_CambiarNombreCarpeta2_Click(sender As Object, e As EventArgs)

        Call Btn_CambiarNombreCarpeta_Click(Nothing, Nothing)

    End Sub

    Private Sub Btn_EliminarClasificacion_Click(sender As Object, e As EventArgs) Handles Btn_EliminarClasificacion.Click

        If Not Fx_Tiene_Permiso(Me, "Tbl00006") Then
            Return
        End If

        Dim _Nodo As TreeNode = Tree_Bandeja.SelectedNode
        Dim _Codigo_Nodo As Integer = _Nodo.Name
        Dim _Descripcion As String = _Nodo.Text

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Asociacion", "Codigo_Nodo = " & _Nodo.Name)

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "Antes de eliminar esta clasificación, asegúrate de quitar los productos asociados." & vbCrLf &
                              "Existen productos asociados.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_TblArbol_Asociaciones", "Identificacdor_NodoPadre = " & _Nodo.Name)

        If MessageBoxEx.Show(Me, "¿Seguro que deseas eliminar esta clasificación?" & vbCrLf &
                                   "Se eliminarán todas las carpetas asociadas.", "Eliminar clasificación",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
            Return
        End If

        Dim _Cl_Arbol As New Cl_Arbol_Asociaciones
        _Cl_Arbol.Fx_Llenar_Asociacion(_Codigo_Nodo)

        Dim _Mensaje As LsValiciones.Mensajes

        _Mensaje = _Cl_Arbol.Fx_Eliminar_Clasificacion()

        If _Mensaje.EsCorrecto Then
            Tree_Bandeja.Nodes.Remove(_Nodo)
        End If

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

    End Sub

    Private Sub Btn_Copiar2_Click(sender As Object, e As EventArgs)
        Call Btn_Copiar_Click(Nothing, Nothing)
    End Sub

    Private Sub Tree_Bandeja_BeforeCheck(sender As Object, e As TreeViewCancelEventArgs) Handles Tree_Bandeja.BeforeCheck

        Dim _Nodo As TreeNode = Tree_Bandeja.SelectedNode
        Dim _Codigo_Nodo As Integer = _Nodo.Name
        Dim _Descripcion As String = _Nodo.Text
        Dim _Es_Seleccionable As Boolean = _Nodo.Tag

        If Not _Es_Seleccionable Then
            e.Cancel = True
        End If

    End Sub

    Private Sub TreeView1_AfterCheck(sender As Object, e As TreeViewEventArgs)
        Dim nodoSeleccionado As TreeNode = e.Node

        ' Desmarcar todos los nodos
        For Each nodo As TreeNode In Tree_Bandeja.Nodes
            If nodo IsNot nodoSeleccionado Then
                nodo.Checked = False
            End If
        Next

        ' Marcar el nodo seleccionado
        nodoSeleccionado.Checked = True
    End Sub

    Private Function Fx_ObtenerNodosConCheck(nodo As TreeNode) As List(Of TreeNode)
        Dim nodosConCheck As New List(Of TreeNode)()

        ' Verificar si el nodo actual está marcado (con check)
        If nodo.Checked Then
            nodosConCheck.Add(nodo)
        End If

        ' Recorrer los subnodos recursivamente
        For Each subnodo As TreeNode In nodo.Nodes
            nodosConCheck.AddRange(Fx_ObtenerNodosConCheck(subnodo))
        Next

        Return nodosConCheck
    End Function

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        ' Uso:
        Dim nodosMarcados As List(Of TreeNode) = Fx_ObtenerNodosConCheck(Tree_Bandeja.Nodes(0)) ' Pasa el nodo raíz adecuado

        ' Ahora 'nodosMarcados' contiene todos los nodos con check en el TreeView
        For Each nodoMarcado As TreeNode In nodosMarcados
            Console.WriteLine(nodoMarcado.Text)
        Next

    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        Sb_Cargar_Arbol()
    End Sub
End Class
