Imports DevComponents
Imports DevComponents.DotNetBar


Public Class Frm_Arbol_Lista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _ListaBusquedaNodos As List(Of TreeNode)
    Private _ListaBusquedaNodos_Advt As List(Of AdvTree.Node)
    Private _Clas_Unica_X_Producto As Boolean
    Private _Zw_Prod_Asociacion As New List(Of Zw_Prod_Asociacion)

    Public Property Codigo_Heredado As String
    Public Property ModoRadioButton As Boolean
    Public Property ModoCheckButton As Boolean
    Public Property MostrarClasProducto As Boolean
    Public Property ModoSeleccion As Boolean

    Public seleccionados As Boolean
    Public Ls_SelArbol_Asociaciones As New List(Of Zw_TblArbol_Asociaciones)

    Public Sub New(_Clas_Unica_X_Producto As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Clas_Unica_X_Producto = _Clas_Unica_X_Producto
        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Arbol_Lista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Consulta_sql = "Select KOPR,NOKOPR From MAEPR Where KOPR = '" & Codigo_Heredado & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If _Clas_Unica_X_Producto Then
            Me.Text = "CLASIFICACIONES UNICAS"
        Else
            Me.Text = "CLASIFICACIONES DINAMICAS"
        End If

        If Not IsNothing(_Row) Then
            If MostrarClasProducto Then
                Me.Text = "Producto: " & _Row.Item("KOPR").ToString.Trim & " - " & _Row.Item("NOKOPR").ToString.Trim
            Else
                Me.Text += ", Producto: " & _Row.Item("KOPR").ToString.Trim & " - " & _Row.Item("NOKOPR").ToString.Trim
            End If
        End If

        Tree_Bandeja.CheckBoxes = False

        If Global_Thema = Enum_Themas.Oscuro Then
            Tree_Bandeja.ImageList = Imagenes_16x16_Dark
        End If

        Sb_Llenar_Zw_Prod_Asociacion()

        If MostrarClasProducto Then

            Dim _NodoRaiz_ClasDinamicas As AdvTree.Node = Fx_CrearNodo_Advt(0, "CLASIFICACIONES DINAMICAS", False, False, 9, 9, eCheckBoxStyle.CheckBox)
            Dim _NodoRaiz_ClasUnicas As AdvTree.Node = Fx_CrearNodo_Advt(0, "CLASIFICACIONES UNICAS", False, False, 10, 10, eCheckBoxStyle.CheckBox)

            Sb_Cargar_Arbol_Advt_ClProd(_NodoRaiz_ClasDinamicas, False)
            Sb_Cargar_Arbol_Advt_ClProd(_NodoRaiz_ClasUnicas, True)

        Else
            Sb_Cargar_Arbol_Advt()
        End If

        _ListaBusquedaNodos = New List(Of TreeNode)
        _ListaBusquedaNodos_Advt = New List(Of AdvTree.Node)

        Btn_Grabar.Visible = (ModoCheckButton Or ModoRadioButton) And Not ModoSeleccion
        Btn_Aceptar.Visible = ModoSeleccion

        If MostrarClasProducto Then
            Btn_Grabar.Visible = False
        End If

        Me.Cursor = Cursors.Default

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

        Lbl_Estatus.Text = Replace(_NodoRaiz.FullPath, ";", "\")

        Me.Refresh()

    End Sub

    Sub Sb_Cargar_Arbol_Advt()

        Me.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        Tree_Bandeja_Adv.Nodes.Clear()

        Dim fuenteNegrita As New Font(Tree_Bandeja_Adv.Font.Name, Tree_Bandeja_Adv.Font.Size, FontStyle.Bold)

        Dim _NodoRaiz_Advt As AdvTree.Node
        Dim _Descripcion As String
        Dim _Icono As Integer

        If _Clas_Unica_X_Producto Then
            _Descripcion = "CLASIFICACIONES UNICAS"
            _Icono = 10
        Else
            _Descripcion = "CLASIFICACIONES DINAMICAS"
            _Icono = 9
        End If

        _NodoRaiz_Advt = Fx_CrearNodo_Advt(0, _Descripcion, False, False, _Icono, _Icono, eCheckBoxStyle.CheckBox)

        Sb_Cargar_Nodos_Advt(_NodoRaiz_Advt, _Clas_Unica_X_Producto)

        Tree_Bandeja_Adv.Nodes.Add(_NodoRaiz_Advt)

        For Each nodo As AdvTree.Node In Tree_Bandeja_Adv.Nodes
            nodo.Expand()
        Next

        If ModoCheckButton Or ModoRadioButton Then

            ' Llamada a la función desde donde desees expandir los nodos marcados
            ExpandirNodosMarcados(Tree_Bandeja_Adv) ' Reemplaza con el nombre de tu TreeView

        End If

        Lbl_Estatus.Text = Replace(_NodoRaiz_Advt.FullPath, ";", "\")

        Me.Cursor = Cursors.Default
        Me.Enabled = True
        Me.Refresh()

    End Sub

    Sub Sb_Cargar_Arbol_Advt_ClProd(_NodoRaiz_Advt As AdvTree.Node, _Clas_Unica_X_Producto As Integer)

        Me.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        'Tree_Bandeja_Adv.Nodes.Clear()

        Dim fuenteNegrita As New Font(Tree_Bandeja_Adv.Font.Name, Tree_Bandeja_Adv.Font.Size, FontStyle.Bold)

        'Dim _NodoRaiz_Advt As AdvTree.Node

        '_NodoRaiz_Advt = Fx_CrearNodo_Advt(0, "CLASIFICACIONES UNICAS", False, False, 4, 4)

        Sb_Cargar_Nodos_Advt(_NodoRaiz_Advt, _Clas_Unica_X_Producto)

        Tree_Bandeja_Adv.Nodes.Add(_NodoRaiz_Advt)

        For Each nodo As AdvTree.Node In Tree_Bandeja_Adv.Nodes
            nodo.Expand()
        Next

        'If ModoCheckButton Or ModoRadioButton Then

        ' Llamada a la función desde donde desees expandir los nodos marcados
        ExpandirNodosMarcados(Tree_Bandeja_Adv) ' Reemplaza con el nombre de tu TreeView

        'End If

        Lbl_Estatus.Text = Replace(_NodoRaiz_Advt.FullPath, ";", "\")

        Me.Cursor = Cursors.Default
        Me.Enabled = True
        Me.Refresh()

    End Sub

    Private Sub ExpandirNodosMarcados(treeView As AdvTree.AdvTree)
        For Each nodo As AdvTree.Node In treeView.Nodes
            If nodo.CheckState = CheckState.Indeterminate Then
                nodo.Expand()
            End If
            ExpandirNodosMarcadosRecursivo(nodo)
        Next
    End Sub

    Private Sub ExpandirNodosMarcadosRecursivo(nodoPadre As AdvTree.Node)
        For Each nodoHijo As AdvTree.Node In nodoPadre.Nodes
            If nodoHijo.CheckState = CheckState.Indeterminate Then
                nodoHijo.Expand()
            End If
            ExpandirNodosMarcadosRecursivo(nodoHijo)
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
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

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

    Sub Sb_Cargar_Nodos_Advt(_Nodo_Padre As AdvTree.Node, _Clas_Unica_X_Producto As Boolean)

        Dim _Identificacdor_NodoPadre = _Nodo_Padre.Name

        If _Identificacdor_NodoPadre = "Raiz" Then _Identificacdor_NodoPadre = 0

        Dim _Filtro = String.Empty

        If MostrarClasProducto Then
            _Filtro = "And Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_Prod_Asociacion " &
                      "Where (Codigo = '" & Codigo_Heredado & "') AND (Para_filtro = 1))" & vbCrLf
        End If

        If _Clas_Unica_X_Producto Then
            _Filtro += "And Clas_Unica_X_Producto = 1" & vbCrLf & "Order By Codigo_Madre"
        Else
            _Filtro += "And Clas_Unica_X_Producto = 0" & vbCrLf & "Order By Descripcion"
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                       "Where Identificacdor_NodoPadre = " & _Identificacdor_NodoPadre & vbCrLf &
                       _Filtro
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If _Tbl.Rows.Count = 0 Then
            Return
        End If

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Codigo_Nodo As Integer = _Fila.Item("Codigo_Nodo")
            Dim _Descripcion As String = _Fila.Item("Descripcion").ToString.Trim
            Dim _Codigo_Madre As String = _Fila.Item("Codigo_Madre").ToString.Trim
            Dim _Es_Padre As Boolean = _Fila.Item("Es_Padre")
            Dim _Es_Seleccionable As Boolean = _Fila.Item("Es_Seleccionable")
            Dim _Checked As Boolean = _Es_Seleccionable

            Dim _Nodo As AdvTree.Node

            If Not String.IsNullOrWhiteSpace(_Codigo_Madre) And _Codigo_Madre <> _Descripcion Then
                _Descripcion = _Codigo_Madre & " - " & _Descripcion
            End If

            Dim _eCheckBoxStyle As eCheckBoxStyle

            If ModoCheckButton Then _eCheckBoxStyle = eCheckBoxStyle.CheckBox
            If ModoRadioButton Then _eCheckBoxStyle = eCheckBoxStyle.RadioButton

            If MostrarClasProducto Then
                If _Clas_Unica_X_Producto Then
                    _eCheckBoxStyle = eCheckBoxStyle.RadioButton
                Else
                    _eCheckBoxStyle = eCheckBoxStyle.CheckBox
                End If
            End If

            If _Es_Seleccionable Then

                If _Es_Seleccionable AndAlso (ModoRadioButton Or ModoCheckButton Or MostrarClasProducto) Then

                    _Checked = False

                    For Each _Fl As Zw_Prod_Asociacion In _Zw_Prod_Asociacion

                        If _Fl.Codigo_Nodo = _Codigo_Nodo Then
                            _Checked = True
                            Sb_MarcarPadre(_Nodo_Padre, CheckState.Indeterminate)
                            Exit For
                        End If

                    Next

                    If ModoSeleccion Then

                        Dim valorBuscado As String = _Codigo_Nodo
                        Dim existeValor As Boolean = Ls_SelArbol_Asociaciones.Any(Function(item) item.Codigo_Nodo = valorBuscado)

                        If existeValor Then
                            _Checked = True
                            Sb_MarcarPadre(_Nodo_Padre, CheckState.Indeterminate)
                        End If

                    End If

                End If

                _Nodo = Fx_CrearNodo_Advt(_Codigo_Nodo, _Descripcion, _Checked, _Es_Seleccionable, 7, 8, _eCheckBoxStyle)

            Else
                _Nodo = Fx_CrearNodo_Advt(_Codigo_Nodo, _Descripcion, _Checked, _Es_Seleccionable, 0, 0, eCheckBoxStyle.CheckBox)
            End If

            _Nodo_Padre.Nodes.Add(_Nodo)

            If _Es_Padre Then
                Sb_Cargar_Nodos_Advt(_Nodo, _Clas_Unica_X_Producto)
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

    Function Fx_CrearNodo_Advt(_Name As String,
                               _Text As String,
                               _Checked As Boolean,
                               _Tag As Object,
                               _ImageIndex As Integer,
                               _SelectedImageIndex As Integer,
                               _eCheckBoxStyle As eCheckBoxStyle) As AdvTree.Node

        Dim _Nodo As New AdvTree.Node

        Dim _Imagen1 As Image
        Dim _Imagen2 As Image

        Dim _Imagenes_List As ImageList
        If Global_Thema = Enum_Themas.Oscuro Then
            _Imagenes_List = Imagenes_16x16_Dark
        Else
            _Imagenes_List = Imagenes_16x16
        End If

        _Imagen1 = _Imagenes_List.Images.Item(_ImageIndex)
        _Imagen2 = _Imagenes_List.Images.Item(_SelectedImageIndex)

        Dim _CheckBoxVisible As Boolean = (ModoCheckButton Or ModoRadioButton)

        If MostrarClasProducto Then
            _CheckBoxVisible = False
        End If

        With _Nodo

            .Name = _Name
            .Text = _Text
            .Editable = False

            If Not _Tag Then
                .Image = _Imagen1
                .ImageExpanded = _Imagen2
            Else
                If Not _CheckBoxVisible And Not MostrarClasProducto Then
                    .Image = _Imagen1
                    .ImageExpanded = _Imagen2
                End If
            End If

            .Checked = _Checked
            .Tag = _Tag

            If Not _Tag And _CheckBoxVisible Then
                _CheckBoxVisible = True
                _eCheckBoxStyle = eCheckBoxStyle.CheckBox
            End If

            .CheckBoxVisible = _CheckBoxVisible
            .CheckBoxStyle = _eCheckBoxStyle

        End With

        Return _Nodo

    End Function

    Function Fx_CrearNodo_Advt_Old(_Name As String,
                               _Text As String,
                               _Checked As Boolean,
                               _Tag As Object,
                               _ImageIndex As Integer,
                               _SelectedImageIndex As Integer) As AdvTree.Node

        Dim _Nodo As New AdvTree.Node

        Dim _Imagen1 As Image
        Dim _Imagen2 As Image

        Dim _Imagenes_List As ImageList
        If Global_Thema = Enum_Themas.Oscuro Then
            _Imagenes_List = Imagenes_16x16_Dark
        Else
            _Imagenes_List = Imagenes_16x16
        End If

        _Imagen1 = _Imagenes_List.Images.Item(_ImageIndex)
        _Imagen2 = _Imagenes_List.Images.Item(_SelectedImageIndex)

        Dim _eCheckBoxStyle As eCheckBoxStyle

        If ModoCheckButton Then _eCheckBoxStyle = eCheckBoxStyle.CheckBox
        If ModoRadioButton Then _eCheckBoxStyle = eCheckBoxStyle.RadioButton

        Dim _CheckBoxVisible As Boolean = (ModoCheckButton Or ModoRadioButton)

        If MostrarClasProducto Then
            _CheckBoxVisible = False
        End If

        With _Nodo

            .Name = _Name
            .Text = _Text
            .Editable = False

            If Not _Tag Then
                .Image = _Imagen1
                .ImageExpanded = _Imagen2
            Else
                If Not _CheckBoxVisible Then
                    .Image = _Imagen1
                    .ImageExpanded = _Imagen2
                End If
            End If

            .Checked = _Checked
            .Tag = _Tag

            If Not _Tag And _CheckBoxVisible Then
                _CheckBoxVisible = True
                _eCheckBoxStyle = eCheckBoxStyle.CheckBox
            End If

            .CheckBoxVisible = _CheckBoxVisible
            .CheckBoxStyle = _eCheckBoxStyle

        End With

        Return _Nodo

    End Function

    Private Sub Tree_Bandeja_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles Tree_Bandeja.AfterSelect

        Dim _Nodo As TreeNode = e.Node
        Lbl_Estatus.Text = Replace(_Nodo.FullPath, ";", "\")
        Lbl_Estatus.Text = _Nodo.FullPath
        Me.Refresh()

    End Sub

    Sub Sb_VerProductos_X_Class_X_Fila(_Nodo As Object)

        Dim _Codigo_Nodo As String = _Nodo.Name
        Dim _Descripcion As String = _Nodo.Text
        Dim _Identificador_NodoPadre As Integer = _Nodo.Parent.Name
        Dim _Es_Seleccionable = _Nodo.Tag
        Dim _FullPath As String = _Nodo.FullPath

        Dim Fm As New Frm_Arbol_Asociacion_04_Productos_x_class(_Identificador_NodoPadre,
                                                                _Codigo_Nodo,
                                                                _Descripcion,
                                                                _FullPath,
                                                                _Es_Seleccionable,
                                                                _Clas_Unica_X_Producto,
                                                                False)
        If ModoCheckButton Or ModoRadioButton Then
            Fm.ModoSoloLectura = True
        Else
            Fm.ModoSoloLectura = Not _Es_Seleccionable
        End If

        Fm.Pro_Codigo_Heredado = Codigo_Heredado
        Fm.Text = "Clasificación: (Cod. " & _Codigo_Nodo & ") " & _Descripcion
        Fm.ShowDialog(Me)
        Fm.Dispose()

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
            Dim _NodoYaBuscado As Boolean
            For Each _nd As TreeNode In _ListaBusquedaNodos
                If _nd.Index = nodoPadre.Index Then
                    _NodoYaBuscado = True
                    Exit For
                End If
            Next
            If Not _NodoYaBuscado Then
                Return nodoPadre
            End If
        End If

        For Each nodoHijo As TreeNode In nodoPadre.Nodes
            Dim nodoEncontrado As TreeNode = BuscarNodoPorEtiqueta(nodoHijo, etiquetaBuscada)
            If nodoEncontrado IsNot Nothing Then
                Return nodoEncontrado
            End If
        Next

        Return Nothing

    End Function

    Function BuscarNodoPorEtiqueta_Advt(nodoPadre As AdvTree.Node, etiquetaBuscada As String) As AdvTree.Node

        If nodoPadre.Tag IsNot Nothing AndAlso nodoPadre.Text.ToUpper.Contains(etiquetaBuscada.ToUpper) Then
            Dim _NodoYaBuscado As Boolean
            For Each _nd As AdvTree.Node In _ListaBusquedaNodos_Advt
                If _nd.Index = nodoPadre.Index Then
                    _NodoYaBuscado = True
                    Exit For
                End If
            Next
            If Not _NodoYaBuscado Then
                Return nodoPadre
            End If
        End If

        For Each nodoHijo As AdvTree.Node In nodoPadre.Nodes
            Dim nodoEncontrado As AdvTree.Node = BuscarNodoPorEtiqueta_Advt(nodoHijo, etiquetaBuscada)
            If nodoEncontrado IsNot Nothing Then
                Return nodoEncontrado
            End If
        Next

        Return Nothing

    End Function
    Private Sub Txt_Filtrar_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Filtrar.KeyDown

        If e.KeyValue = Keys.Enter Then
            Sb_BuscarNodo_Advt()
            'Sb_BuscarNodo()
        End If

    End Sub



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

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Asociacion", "Codigo_Nodo = " & _Nodo.Name)

            Lbl_TotalProductos.Text = "Id: " & _Nodo.Name & ",Total productos asociados: " & FormatNumber(_Reg, 0)

            Lbl_TotalProductos.Visible = CBool(_Nodo.Name)
            Btn_VerProductos.Visible = CBool(_Nodo.Name)
            LabelItem1.Visible = CBool(_Nodo.Name)
            LabelItem2.Visible = CBool(_Nodo.Name)
            Btn_CambiarNombreCarpeta.Visible = CBool(_Nodo.Name)
            Btn_CambiarNombreCarpeta.Visible = CBool(_Nodo.Name)
            Btn_EliminarClasificacion.Visible = CBool(_Nodo.Name)
            Btn_Copiar.Visible = CBool(_Nodo.Name)

            Btn_VerProductos.Enabled = _Nodo.Checked
            Btn_TicketProducto.Enabled = _Nodo.Checked
            Btn_CrearClasificacion.Enabled = Not _Nodo.Checked

            ShowContextMenu(Menu_Contextual_01)

        End If

    End Sub

    Private Sub Btn_VerProductos_Click(sender As Object, e As EventArgs) Handles Btn_VerProductos.Click

        Dim _Nodo As AdvTree.Node = Tree_Bandeja_Adv.SelectedNode
        Sb_VerProductos_X_Class_X_Fila(_Nodo)

    End Sub

    Private Sub Btn_CambiarNombreCarpeta_Click(sender As Object, e As EventArgs) Handles Btn_CambiarNombreCarpeta.Click

        If Not Fx_Tiene_Permiso(Me, "Tbl00005") Then
            Return
        End If

        Dim _Nodo As AdvTree.Node = Tree_Bandeja_Adv.SelectedNode
        Dim _Codigo_Nodo As Integer = _Nodo.Name
        Dim _Descripcion As String = _Nodo.Text
        Dim _Fullpath As String = _Nodo.FullPath

        Dim _Grabar As Boolean

        Dim Fm As New Frm_Arbol_Asociacion_06_CrearEditar(_Codigo_Nodo, _Nodo.Parent.Name, 0, _Clas_Unica_X_Producto, _Fullpath)
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

            _Nodo.Tag = _Es_Seleccionable

            Dim _Imagen1 As Image
            Dim _Imagen2 As Image

            Dim _Imagenes_List As ImageList
            If Global_Thema = Enum_Themas.Oscuro Then
                _Imagenes_List = Imagenes_16x16_Dark
            Else
                _Imagenes_List = Imagenes_16x16
            End If

            Dim _ImageIndex As Integer
            Dim _SelectedImageIndex As Integer

            If _Es_Seleccionable Then
                _ImageIndex = 7
                _SelectedImageIndex = 8
            Else
                _ImageIndex = 0
                _SelectedImageIndex = 0
            End If

            _Imagen1 = _Imagenes_List.Images.Item(_ImageIndex)
            _Imagen2 = _Imagenes_List.Images.Item(_SelectedImageIndex)

            _Nodo.Image = _Imagen1
            _Nodo.ImageExpanded = _Imagen2

        End If

    End Sub

    Private Sub Btn_Copiar_Click(sender As Object, e As EventArgs) Handles Btn_Copiar.Click

        Dim _Nodo As AdvTree.Node = Tree_Bandeja_Adv.SelectedNode
        Dim _Codigo_Nodo As Integer = _Nodo.Name
        Dim _Descripcion As String = _Codigo_Nodo & ";" & _Nodo.Text

        Dim Copiar = _Descripcion
        Clipboard.SetText(Copiar)

        ToastNotification.Show(Me, _Descripcion & " esta en el portapapeles", Btn_Copiar.Image,
                               2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

    End Sub

    Private Sub Btn_CrearClasificacion_Click(sender As Object, e As EventArgs) Handles Btn_CrearClasificacion.Click

        If Not Fx_Tiene_Permiso(Me, "Tbl00004") Then
            Return
        End If

        Dim _Nodo As AdvTree.Node = Tree_Bandeja_Adv.SelectedNode
        Dim _Codigo_Nodo As Integer = _Nodo.Name
        Dim _Descripcion As String = _Nodo.Text
        Dim _Fullpath As String = Replace(_Nodo.FullPath, ";", "\")
        Dim _Grabar As Boolean

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Nodo_Raiz As Integer

        If Not IsNothing(_Row) Then
            _Nodo_Raiz = _Row.Item("Nodo_Raiz")
        End If

        If _Nodo_Raiz = 0 Then
            _Nodo_Raiz = _Codigo_Nodo
        End If

        Dim _Cl_Arbol_Asociaciones As Cl_Arbol_Asociaciones

        Dim Fm As New Frm_Arbol_Asociacion_06_CrearEditar(0, _Codigo_Nodo, _Nodo_Raiz, _Clas_Unica_X_Producto, _Fullpath)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _Cl_Arbol_Asociaciones = Fm.Cl_Arbol_Asociaciones
        Fm.Dispose()

        If _Grabar Then

            _Codigo_Nodo = _Cl_Arbol_Asociaciones.Zw_TblArbol_Asociaciones.Codigo_Nodo

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
            _Row = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _NewNodo As AdvTree.Node

            If Not String.IsNullOrWhiteSpace(_Row.Item("Codigo_Madre")) And _Row.Item("Codigo_Madre") <> _Row.Item("Descripcion") Then
                _Descripcion = _Row.Item("Codigo_Madre") & " - " & _Row.Item("Descripcion")
            Else
                _Descripcion = _Row.Item("Descripcion")
            End If

            Dim _eCheckBoxStyle As eCheckBoxStyle

            If ModoCheckButton Then _eCheckBoxStyle = eCheckBoxStyle.CheckBox
            If ModoRadioButton Then _eCheckBoxStyle = eCheckBoxStyle.RadioButton

            If _Row.Item("Es_Seleccionable") Then
                _NewNodo = Fx_CrearNodo_Advt(_Codigo_Nodo, _Descripcion, False, True, 7, 8, _eCheckBoxStyle)
            Else
                _NewNodo = Fx_CrearNodo_Advt(_Codigo_Nodo, _Descripcion, False, False, 0, 0, _eCheckBoxStyle)
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

        Dim _Nodo As AdvTree.Node = Tree_Bandeja_Adv.SelectedNode
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
            _Nodo.Parent.Nodes.Remove(_Nodo)
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

    Private Function Fx_ObtenerNodosConCheck(nodo As AdvTree.Node) As List(Of AdvTree.Node)
        Dim nodosConCheck As New List(Of AdvTree.Node)()

        ' Verificar si el nodo actual está marcado (con check)
        If nodo.Checked Then
            nodosConCheck.Add(nodo)
        End If

        ' Recorrer los subnodos recursivamente
        For Each subnodo As AdvTree.Node In nodo.Nodes
            nodosConCheck.AddRange(Fx_ObtenerNodosConCheck(subnodo))
        Next

        Return nodosConCheck
    End Function


    ' Función recursiva para obtener todos los nodos descendientes
    Function Fx_ObtenerDescendientes(nodoPadre As AdvTree.Node) As List(Of AdvTree.Node)

        Dim nodos As New List(Of AdvTree.Node)()

        ' Agregar el nodo actual
        nodos.Add(nodoPadre)

        If Not IsNothing(nodoPadre.Parent) AndAlso nodoPadre.Parent.Name <> 0 Then
            nodos.AddRange(Fx_ObtenerDescendientes(nodoPadre.Parent))
        End If

        Return nodos
    End Function

    Sub Sb_MarcarPadre(_Nodo As AdvTree.Node, _CheckState As CheckState)

        Try
            _Nodo.CheckState = _CheckState
            If Not IsNothing(_Nodo.Parent) Then
                Sb_MarcarPadre(_Nodo.Parent, _CheckState)
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click

        If MostrarClasProducto Then

            Tree_Bandeja_Adv.Nodes.Clear()

            Dim _NodoRaiz_ClasUnicas As AdvTree.Node = Fx_CrearNodo_Advt(0, "CLASIFICACIONES UNICAS", False, False, 4, 4, eCheckBoxStyle.CheckBox)
            Dim _NodoRaiz_ClasDinamicas As AdvTree.Node = Fx_CrearNodo_Advt(0, "CLASIFICACIONES DINAMICAS", False, False, 4, 4, eCheckBoxStyle.CheckBox)

            Sb_Cargar_Arbol_Advt_ClProd(_NodoRaiz_ClasDinamicas, False)
            Sb_Cargar_Arbol_Advt_ClProd(_NodoRaiz_ClasUnicas, True)

        Else

            Sb_Cargar_Arbol_Advt()

        End If

    End Sub

    Private Sub Txt_Filtrar_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Filtrar.ButtonCustomClick
        Sb_BuscarNodo_Advt()
    End Sub

    Private Sub Txt_Filtrar_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Filtrar.ButtonCustom2Click
        Txt_Filtrar.Text = String.Empty
        _ListaBusquedaNodos.Clear()
    End Sub

    Sub Sb_BuscarNodo()

        ' Uso de la función
        Dim etiquetaBuscada As String = Txt_Filtrar.Text

        If String.IsNullOrWhiteSpace(etiquetaBuscada.Trim) Then
            Beep()
            Return
        End If

        Dim nodoEncontrado As TreeNode = BuscarNodoPorEtiqueta(Tree_Bandeja.Nodes(0), etiquetaBuscada)

        If nodoEncontrado IsNot Nothing Then

            _ListaBusquedaNodos.Add(nodoEncontrado)

            ' Haz algo con el nodo encontrado
            Tree_Bandeja.Focus()
            nodoEncontrado.EnsureVisible()
            Tree_Bandeja.SelectedNode = nodoEncontrado
            nodoEncontrado.Expand()
            Txt_Filtrar.ButtonCustom.Visible = True
            Me.Refresh()

        Else

            If CBool(_ListaBusquedaNodos.Count) Then
                MessageBoxEx.Show(Me, "No se han encontrado más resultados en los documentos especificados.", "Buscar",
                                  MessageBoxButtons.OK, Nothing)
            Else
                MessageBoxEx.Show(Me, "No se encuentra el siguiente texto especificado: " & Txt_Filtrar.Text, "Buscar",
                                  MessageBoxButtons.OK, Nothing)
            End If

            _ListaBusquedaNodos.Clear()

        End If

    End Sub

    Sub Sb_BuscarNodo_Advt()

        ' Uso de la función
        Dim etiquetaBuscada As String = Txt_Filtrar.Text

        If String.IsNullOrWhiteSpace(etiquetaBuscada.Trim) Then
            Beep()
            Return
        End If

        Dim nodoEncontrado As AdvTree.Node = BuscarNodoPorEtiqueta_Advt(Tree_Bandeja_Adv.Nodes(0), etiquetaBuscada)

        If nodoEncontrado IsNot Nothing Then

            _ListaBusquedaNodos_Advt.Add(nodoEncontrado)

            ' Haz algo con el nodo encontrado
            Tree_Bandeja.Focus()
            nodoEncontrado.EnsureVisible()
            Tree_Bandeja_Adv.SelectedNode = nodoEncontrado
            nodoEncontrado.Expand()
            Txt_Filtrar.ButtonCustom.Visible = True
            Me.Refresh()

        Else

            If CBool(_ListaBusquedaNodos_Advt.Count) Then
                MessageBoxEx.Show(Me, "No se han encontrado más resultados en los documentos especificados.", "Buscar",
                                  MessageBoxButtons.OK, Nothing)
            Else
                MessageBoxEx.Show(Me, "No se encuentra el siguiente texto especificado: " & Txt_Filtrar.Text, "Buscar",
                                  MessageBoxButtons.OK, Nothing)
            End If

            _ListaBusquedaNodos_Advt.Clear()

        End If

    End Sub

    Private Sub Txt_Filtrar_TextChanged(sender As Object, e As EventArgs) Handles Txt_Filtrar.TextChanged
        If String.IsNullOrEmpty(Txt_Filtrar.Text) Then
            'Txt_Filtrar.ButtonCustom.Visible = False
            _ListaBusquedaNodos.Clear()
            Me.Refresh()
        End If
    End Sub

    Sub Sb_Llenar_Zw_Prod_Asociacion()

        If String.IsNullOrEmpty(Codigo_Heredado) Then
            Return
        End If

        Consulta_sql = "Select Id,Codigo,Codigo_Nodo,DescripcionBusqueda,Para_filtro,Nodo_origen," &
                       "Clas_unica,Producto,Lect_Barras_IngrxCantidad,Stock_desde_WMS" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                       "Where (Codigo = '" & Codigo_Heredado & "') AND (Para_filtro = 1)"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        For Each _Row As DataRow In _Tbl.Rows

            Dim _Prod As New Zw_Prod_Asociacion

            With _Prod

                .Id = _Row.Item("Id")
                .Codigo = _Row.Item("Codigo")
                .Codigo_Nodo = _Row.Item("Codigo_Nodo")
                .DescripcionBusqueda = _Row.Item("DescripcionBusqueda")
                .Para_filtro = _Row.Item("Para_filtro")
                .Nodo_origen = _Row.Item("Nodo_origen")
                .Clas_unica = _Row.Item("Clas_unica")
                .Producto = _Row.Item("Producto")
                .Lect_Barras_IngrxCantidad = _Row.Item("Lect_Barras_IngrxCantidad")
                .Stock_desde_WMS = _Row.Item("Stock_desde_WMS")

            End With

            _Zw_Prod_Asociacion.Add(_Prod)

        Next

    End Sub

    Private Sub Adv_Tree_Bandeja_AfterNodeSelect(sender As Object, e As AdvTree.AdvTreeNodeEventArgs) Handles Tree_Bandeja_Adv.AfterNodeSelect
        Try
            Dim _Nodo As AdvTree.Node = e.Node
            Lbl_Estatus.Text = Replace(_Nodo.FullPath, ";", "\")
        Catch ex As Exception
            Lbl_Estatus.Text = "...\\"
        End Try
        Me.Refresh()
    End Sub

    Private Sub Adv_Tree_Bandeja_BeforeCheck(sender As Object, e As AdvTree.AdvTreeCellBeforeCheckEventArgs) Handles Tree_Bandeja_Adv.BeforeCheck

        Dim _Nodo As AdvTree.Node = Tree_Bandeja_Adv.SelectedNode
        Dim _Codigo_Nodo As Integer = _Nodo.Name
        Dim _Descripcion As String = _Nodo.Text
        Dim _Es_Seleccionable As Boolean = _Nodo.Tag
        Dim _Checked As Boolean = _Nodo.Checked

        If Not _Es_Seleccionable Then
            e.Cancel = True
        End If

    End Sub

    Private Sub Adv_Tree_Bandeja_NodeMouseDown(sender As Object, e As AdvTree.TreeNodeMouseEventArgs) Handles Tree_Bandeja_Adv.NodeMouseDown

        Dim _Nodo As AdvTree.Node = e.Node
        Tree_Bandeja_Adv.SelectedNode = _Nodo

        If e.Button = MouseButtons.Right Then

            If MostrarClasProducto Then
                Return
            End If

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Asociacion", "Codigo_Nodo = " & _Nodo.Name)

            Lbl_TotalProductos.Text = "Id: " & _Nodo.Name & ",Total productos asociados: " & FormatNumber(_Reg, 0)

            Lbl_TotalProductos.Visible = CBool(_Nodo.Name)
            Btn_VerProductos.Visible = CBool(_Nodo.Name)
            LabelItem1.Visible = CBool(_Nodo.Name)
            LabelItem2.Visible = CBool(_Nodo.Name)
            Btn_CambiarNombreCarpeta.Visible = CBool(_Nodo.Name)
            Btn_CambiarNombreCarpeta.Visible = CBool(_Nodo.Name)
            Btn_EliminarClasificacion.Visible = CBool(_Nodo.Name)
            Btn_Copiar.Visible = CBool(_Nodo.Name)

            Btn_VerProductos.Enabled = _Nodo.Tag
            Btn_TicketProducto.Enabled = _Nodo.Tag
            Btn_CrearClasificacion.Enabled = Not _Nodo.Tag

            ShowContextMenu(Menu_Contextual_01)

        End If

    End Sub

    Private Sub Tree_Bandeja_Adv_NodeDoubleClick(sender As Object, e As AdvTree.TreeNodeMouseEventArgs) Handles Tree_Bandeja_Adv.NodeDoubleClick

        If ModoCheckButton Or ModoRadioButton Then
            Return
        End If

        Dim _Nodo As AdvTree.Node = e.Node
        Dim nodoRaiz As AdvTree.Node = Tree_Bandeja_Adv.SelectedNode

        'Dim todosLosNodos As List(Of TreeNode) = ObtenerDescendientes(nodoRaiz)

        '' Uso:
        'Dim nodosAnteriores As New List(Of TreeNode)
        'RecorrerNodosAnteriores(nodoRaiz, nodosAnteriores)
        '' La lista 'nodosAnteriores' ahora contiene los nodos anteriores al último nodo seleccionado.
        If _Nodo.Tag Then
            Sb_VerProductos_X_Class_X_Fila(_Nodo)
        End If
    End Sub

    Private Sub Btn_Grabar_Click_1(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _NodosSeleccionados As List(Of AdvTree.Node) = Fx_ObtenerNodosConCheck(Tree_Bandeja_Adv.Nodes(0))

        Dim _Msg = String.Empty

        'Dim _Todoslosnodos As New List(Of AdvTree.Node)()
        Dim _nodos As New List(Of AdvTree.Node)()


        For Each _Nodo As AdvTree.Node In _NodosSeleccionados

            _Msg += " - " & _Nodo.Parent.Text & "\" & _Nodo.Text & vbCrLf

            If Not _nodos.Contains(_Nodo.Parent) Then
                _nodos.AddRange(Fx_ObtenerDescendientes(_Nodo))
            End If

        Next

        _nodos.AddRange(_NodosSeleccionados)

        Dim nodosSinDuplicados As New List(Of AdvTree.Node)()

        For Each nodo As AdvTree.Node In _nodos
            If Not nodosSinDuplicados.Contains(nodo) Then
                nodosSinDuplicados.Add(nodo)
            End If
        Next

        Dim nodosRaiz As New List(Of AdvTree.Node)()

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                       "Where Codigo = '" & Codigo_Heredado & "' And Para_filtro = 1" & vbCrLf &
                       "And Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Clas_Unica_X_Producto = " & Convert.ToUInt32(_Clas_Unica_X_Producto) & ")" & vbCrLf

        For Each _Nd As AdvTree.Node In nodosSinDuplicados

            Dim _Codigo_Nodo As Integer = _Nd.Name
            Dim _DescripcionBusqueda As String = _Nd.Text

            If ModoRadioButton Then

                If _Nd.Parent.Name = 0 Then

                    nodosRaiz.Add(_Nd)
                    Dim _Checkeados As Integer = ContarNodosConCheck(_Nd)

                    If _Checkeados > 1 Then
                        MessageBoxEx.Show(Me, "No es posible marcar más de una casilla en una clasificación de raíz llamada ‘" & _Nd.Text & "’" & vbCrLf &
                                          "Actualmente, hay " & _Checkeados & " casillas marcadas.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If

                End If

            End If

            Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_Prod_Asociacion (Codigo,Codigo_Nodo,DescripcionBusqueda,Para_filtro) Values " &
                            "('" & Codigo_Heredado & "'," & _Codigo_Nodo & ",'" & _DescripcionBusqueda & "',1)" & vbCrLf

        Next

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            MessageBoxEx.Show(Me, "Datos guardados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If

    End Sub

    Private Sub Tree_Bandeja_Adv_AfterCheck(sender As Object, e As AdvTree.AdvTreeCellEventArgs) Handles Tree_Bandeja_Adv.AfterCheck

        Dim _NodoSeleccionado As AdvTree.Node = e.Cell.Parent 'Tree_Bandeja_Adv.SelectedNode
        Dim _Codigo_Nodo As Integer = _NodoSeleccionado.Name
        Dim _Descripcion As String = _NodoSeleccionado.Text
        Dim _Es_Seleccionable As Boolean = _NodoSeleccionado.Tag
        Dim _Checked As Boolean = _NodoSeleccionado.Checked

        If ModoCheckButton Or ModoRadioButton Then

            If _NodoSeleccionado.Tag Then

                If _NodoSeleccionado.Checked Then
                    _NodoSeleccionado.Parent.CheckState = CheckState.Indeterminate
                Else
                    If Not RecorrerNodosYDetectarCheck(_NodoSeleccionado.Parent) Then
                        _NodoSeleccionado.Parent.CheckState = CheckState.Unchecked
                    End If
                End If

            Else

                If Not IsNothing(_NodoSeleccionado.Parent) Then
                    If _NodoSeleccionado.CheckState = CheckState.Indeterminate Then
                        _NodoSeleccionado.Parent.CheckState = _NodoSeleccionado.CheckState
                    Else
                        If Not RecorrerNodosYDetectarCheck(_NodoSeleccionado.Parent) Then
                            _NodoSeleccionado.Parent.CheckState = CheckState.Unchecked
                        End If
                    End If
                End If

            End If

        End If

        Me.Refresh()

    End Sub

    Private Function Fx_TieneNodosMarcados(nodoPadre As AdvTree.Node) As Boolean
        For Each nodoHijo As AdvTree.Node In nodoPadre.Nodes
            If nodoHijo.Tag Then
                Return nodoHijo.Checked
            Else
                Return Fx_TieneNodosMarcados(nodoHijo)
            End If
        Next
    End Function

    Private Function Fx_DemarcarMarcarNodos(nodoPadre As AdvTree.Node, nodoNoDesmarcar As AdvTree.Node, _Marcar As Boolean) As Boolean
        For Each nodoHijo As AdvTree.Node In nodoPadre.Nodes
            If nodoHijo.Tag Then
                If nodoNoDesmarcar.Name <> nodoHijo.Name Then
                    nodoHijo.Checked = _Marcar
                End If
            Else
                Fx_DemarcarMarcarNodos(nodoHijo, nodoNoDesmarcar, _Marcar)
            End If
        Next
    End Function

    Private Function RecorrerNodosYDetectarCheck(nodo As AdvTree.Node) As Boolean
        If nodo.Checked Then
            Return True
        End If

        For Each nodoHijo As AdvTree.Node In nodo.Nodes
            If RecorrerNodosYDetectarCheck(nodoHijo) Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Function ContarNodosConCheck(nodoPadre As AdvTree.Node) As Integer
        Dim contador As Integer = 0

        For Each nodoHijo As AdvTree.Node In nodoPadre.Nodes
            If nodoHijo.Checked Then
                contador += 1
            End If
            contador += ContarNodosConCheck(nodoHijo) ' Llamada recursiva para los nodos hijos
        Next

        Return contador
    End Function

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click

        Dim _NodosSeleccionados As List(Of AdvTree.Node) = Fx_ObtenerNodosConCheck(Tree_Bandeja_Adv.Nodes(0))

        If _NodosSeleccionados.Count = 0 Then
            MessageBoxEx.Show(Me, "No se ha seleccionado ninguna clasificación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Ls_SelArbol_Asociaciones.Clear()

        Dim _Cl_Arbol_Asociaciones As New Cl_Arbol_Asociaciones

        For Each _Nodo As AdvTree.Node In _NodosSeleccionados

            _Cl_Arbol_Asociaciones.Fx_Llenar_Asociacion(_Nodo.Name)
            Ls_SelArbol_Asociaciones.Add(_Cl_Arbol_Asociaciones.Zw_TblArbol_Asociaciones)

        Next

        seleccionados = True
        Me.Close()

    End Sub
End Class
