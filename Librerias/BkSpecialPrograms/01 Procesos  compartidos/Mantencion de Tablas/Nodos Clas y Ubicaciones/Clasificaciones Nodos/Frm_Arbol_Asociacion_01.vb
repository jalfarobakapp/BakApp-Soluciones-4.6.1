Imports DevComponents.DotNetBar
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml.Serialization
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Collections.Generic
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Arbol_Asociacion_01

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim Datos_Arbol As New DS_Nodos
    Dim _Tbl_Nodos_Asociacios_Producto As DataTable

    Dim _Codigo As String
    Dim _RowProducto As DataRow
    Dim _Mostrar_Arbol_Del_Producto As Boolean
    Dim _Mostrar_Clas_Unica As Boolean

    Dim _Nro_Chequeados As Integer
    Dim _Nodos_Chequeados() As String

    Dim _Sql_Query_Grabar As String
    Dim _NroProAsociados As Integer

    ' variable (Flag) usada para indicar que si hay o no un Drag and Drop dentro del TreeView
    Private DragDropTreeView As Boolean
    ' variable que guarda el nodo arrastrado por el usuario.
    Private NodoOrigen As TreeNode

    Public Property Pro_Codigo_Producto() As String
        Get
            Return _Codigo
        End Get
        Set(value As String)
            _Codigo = value
            Consulta_sql = "Select Top 1 * From MAEPR Where KOPR = '" & _Codigo & "'"
            _RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)
        End Set
    End Property
    Public ReadOnly Property Pro_RowProducto() As DataRow
        Get
            Return _RowProducto
        End Get
    End Property
    Public Property Pro_CheckBoxes_Nodos() As Boolean
        Get
            Return TreeView1.CheckBoxes
        End Get
        Set(value As Boolean)
            TreeView1.CheckBoxes = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        If Not Directory.Exists(AppPath() & "\Data\" & RutEmpresa & "\Clasificaciones_prod") Then
            System.IO.Directory.CreateDirectory(AppPath() & "\Data\" & RutEmpresa & "\Clasificaciones_prod")
        End If

        TreeView1.AllowDrop = False

        Sb_Color_Botones_Barra(Bar2)

    End Sub


    Private Sub Frm_Arbol_Asociacion_01_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        If Not (_RowProducto Is Nothing) Then
            _Mostrar_Arbol_Del_Producto = True
        End If

        Sb_Load()

        AddHandler TreeView1.DragDrop, AddressOf Sb_TreeView_DragDrop
        AddHandler TreeView1.DragOver, AddressOf Sb_TreeView_DragOver
        AddHandler TreeView1.MouseDown, AddressOf Sb_TreeView_MouseDown
        AddHandler TreeView1.MouseUp, AddressOf Sb_TreeView1_MouseUp

        AddHandler Chk_Ver_Clas_Unicas.CheckedChanged, AddressOf Sb_Load

    End Sub

    Sub Sb_Load()

        TreeView1.Nodes.Clear()

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo = '" & _Codigo & "'" & vbCrLf &
                       "And Para_filtro = 0"

        _Tbl_Nodos_Asociacios_Producto = _Sql.Fx_Get_Tablas(Consulta_sql) '_SQL.Fx_Get_Tablas(Consulta_sql)

        If _Mostrar_Arbol_Del_Producto Then

            Dim _Descripcion = _RowProducto.Item("NOKOPR")

            Me.Text = "ARBOL DE ASOCIACIONES, PRODUCTO: " & _Codigo & " - " & _Descripcion
            BtnGrabar.Visible = False
            TreeView1.CheckBoxes = False

            If Chk_Ver_Clas_Unicas.Checked Then
                Consulta_sql = "Select Codigo_Nodo,Identificacdor_NodoPadre,Descripcion" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                               "Where Codigo_Nodo in (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                               "Where Codigo = '" & _Codigo & "' And Producto = 0 And Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones))" & vbCrLf &
                               "Order By Identificacdor_NodoPadre, Descripcion"
            Else
                Consulta_sql = "Select Codigo_Nodo,Identificacdor_NodoPadre,Descripcion" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                               "Where Codigo_Nodo in (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                               "Where Codigo = '" & _Codigo & "' And Producto = 0 And Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones))" & vbCrLf &
                               "And Clas_Unica_X_Producto = 0" & vbCrLf &
                               "Order By Identificacdor_NodoPadre, Descripcion"
            End If

            Me.MaximizeBox = False
        Else
            Me.Text = "ARBOL DE ASOCIACIONES DE PRODUCTOS"
            Consulta_sql = "Select Codigo_Nodo,Identificacdor_NodoPadre,Descripcion" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                           "Where (Clas_Unica_X_Producto = 0) or (Clas_Unica_X_Producto = 1 And Es_Seleccionable = 0)"

        End If

        Dim _Chk As Integer = _Tbl_Nodos_Asociacios_Producto.Rows.Count - 1
        ReDim _Nodos_Chequeados(_Chk)

        Datos_Arbol.Clear()
        Datos_Arbol = _Sql.Fx_Get_DataSet(Consulta_sql, Datos_Arbol, "Arbol_Asociacion")

        CrearNodosDelPadre(0, Nothing)

        For Each _Full In _Nodos_Chequeados

            Dim _sKey As String = _Full

            Dim _tvn() As TreeNode = TreeView1.Nodes.Find(_sKey, True)
            If _tvn IsNot Nothing AndAlso _tvn.Length > 0 Then
                _tvn(0).BackColor = Drawing.Color.Yellow
                _tvn(0).Checked = True
                TreeView1.SelectedNode = _tvn(0)
            End If
        Next


        If _Mostrar_Arbol_Del_Producto Then
            TreeView1.ExpandAll()
        Else
            TreeView1.ContextMenuStrip = ContextMenuStrip1
        End If

    End Sub

    Private Sub CrearNodosDelPadre(indicePadre As Integer,
                                   nodePadre As TreeNode)

        Dim dataViewHijos As DataView

        ' Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
        dataViewHijos = New DataView(Datos_Arbol.Tables("Arbol_Asociacion"))
        dataViewHijos.RowFilter =
        Datos_Arbol.Tables("Arbol_Asociacion").Columns("Identificacdor_NodoPadre").ColumnName + " = " + indicePadre.ToString()

        ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        For Each dataRowCurrent As DataRowView In dataViewHijos

            Dim _NroNodo As Integer = Int32.Parse(dataRowCurrent("Codigo_Nodo").ToString())
            'Dim nuevoNodo As New TreeNode
            Dim nuevoNodo As String
            'nuevoNodo.Text = dataRowCurrent("Descripcion").ToString().Trim()
            nuevoNodo = dataRowCurrent("Descripcion").ToString().Trim()

            Dim _Text_Nodo = dataRowCurrent("Descripcion").ToString().Trim()
            'nuevoNodo = numero_(_NroNodo, 4) & " - " & nuevoNodo

            Dim _Full As String

            ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            ' del primer nivel que no dependen de otro nodo.
            If nodePadre Is Nothing Then

                _Full = nuevoNodo

                TreeView1.Nodes.Add(_Full, nuevoNodo, 3)

            Else
                _Full = nodePadre.FullPath & "\" & nuevoNodo

                Dim _Es_Ubicacion As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_TblArbol_Asociaciones",
                                                 "Descripcion = '" & nuevoNodo &
                                                 "' And Es_Ubicacion = 1 And" & vbCrLf &
                                                 "Codigo_Nodo Not in (Select Identificacdor_NodoPadre From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones)"))
                Dim _Imagen = 3

                If _Es_Ubicacion Then
                    _Imagen = 2
                End If

                nodePadre.Nodes.Add(_Full, nuevoNodo, _Imagen)
            End If

            If TreeView1.CheckBoxes Then
                If CBool(_Tbl_Nodos_Asociacios_Producto.Rows.Count) Then
                    For Each _Fila As DataRow In _Tbl_Nodos_Asociacios_Producto.Rows
                        Dim Nro_IdNodo As Integer = _Fila.Item("Codigo_Nodo")
                        If Nro_IdNodo = _NroNodo Then
                            'nuevoNodo.Checked = True
                            _Nodos_Chequeados(_Nro_Chequeados) = _Full
                            _Nro_Chequeados += 1
                        End If
                        ' If Nro_IdNodo Then
                    Next
                End If
            End If

            ' Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.

            Dim tvn() As TreeNode = TreeView1.Nodes.Find(_Full, True)

            CrearNodosDelPadre(_NroNodo, tvn(0))

        Next dataRowCurrent

    End Sub


    Private Sub Recorrer_Nodos(indicePadre As Integer,
                               nodePadre As TreeNode)

        Dim dataViewHijos As DataView

        ' Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
        dataViewHijos = New DataView(Datos_Arbol.Tables("Arbol_Asociacion"))
        dataViewHijos.RowFilter =
        Datos_Arbol.Tables("Arbol_Asociacion").Columns("Identificacdor_NodoPadre").ColumnName + " = " + indicePadre.ToString()

        ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        For Each dataRowCurrent As DataRowView In dataViewHijos

            Dim nuevoNodo As New TreeNode
            nuevoNodo.Text = dataRowCurrent("Descripcion").ToString().Trim()

            ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            ' del primer nivel que no dependen de otro nodo.
            If nodePadre Is Nothing Then
                nuevoNodo.SelectedImageIndex = 0
                TreeView1.Nodes.Add(nuevoNodo)
            Else
                ' se añade el nuevo nodo al nodo padre.
                nuevoNodo.SelectedImageIndex = 3
                nodePadre.Nodes.Add(nuevoNodo)
            End If

            ' Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
            CrearNodosDelPadre(Int32.Parse(dataRowCurrent("Identificador_Nodo").ToString()), nuevoNodo)
        Next dataRowCurrent

    End Sub

    Private Sub TreeView1_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        TxtFullPath.Text = e.Node.FullPath
    End Sub

    Private Sub RecorrerNodos(treeNode As TreeNode)
        Try
            'Si el nodo que recibimos tiene hijos se recorrerá
            'para luego verificar si esta o no checado
            For Each tn As TreeNode In treeNode.Nodes
                'Se Verifica si esta marcado...
                If tn.Checked = True Then
                    'Si esta marcado mostramos el texto del nodo

                    Dim _Selec_() = Split(tn.FullPath, "\")
                    Dim _NroPadre = _Selec_.Length - 2
                    Dim _Padre = _Selec_(_NroPadre)

                    Dim _Cod_Padre = _Sql.Fx_Trae_Dato("Zw_TblArbol_Asociaciones", "Identificador_Nodo", "Descripcion = '" & _Padre & "'")

                    MessageBox.Show(tn.FullPath)
                    ' MessageBox.Show(tn.Text)
                End If
                'Ahora hago verificacion a los hijos del nodo actual            
                'Esta iteración no acabara hasta llegar al ultimo nodo principal
                RecorrerNodos(tn)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub AgregarAsociaciónToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AgregarAsociaciónToolStripMenuItem.Click
        ' pregunto si hay un nodo seleccionado
        If Fx_Tiene_Permiso(Me, "Tbl00007") Then
            If IsNothing(TreeView1.SelectedNode) = False Then

                Dim Tn = TreeView1.SelectedNode
                Dim _Selec_() = Split(Tn.FullPath, "\")
                Dim _NroPadre = _Selec_.Length - 1
                Dim _Padre = _Selec_(_NroPadre)

                Dim _Cod_Padre = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblArbol_Asociaciones", "Codigo_Nodo", "Descripcion = '" & _Padre & "'")
                Dim _Es_Padre As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblArbol_Asociaciones", "Es_Padre", "Codigo_Nodo = '" & _Cod_Padre & "'")

                If _Es_Padre Then

                    Dim Fm As New Frm_Arbol_Asociacion_02(False, 0, False, Frm_Arbol_Asociacion_02.Enum_Clasificacion.Dinamica, 0)
                    Fm.Pro_Identificador_NodoPadre = _Cod_Padre

                    Dim _Descripcion As String

                    Dim _Aceptar As Boolean = InputBox_Bk(Me,
                                                         "Escriba la descripción para la clasificación",
                                                         "Crear asociación", _Descripcion, False, _Tipo_Mayus_Minus.Mayusculas)

                    If _Aceptar Then

                        Dim _Como_Padre As Boolean = Fx_Tiene_Permiso(Me, "Tbl00003", , False)

                        If _Como_Padre Then

                            If MessageBoxEx.Show(Me, "¿Desea crear claificación como padre?" & vbCrLf & vbCrLf &
                                                 Tn.FullPath & "\" & _Descripcion,
                                                 "Crear clasificación",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                                _Como_Padre = False
                            Else
                                _Como_Padre = True
                            End If

                        End If

                        Consulta_sql = "Insert Into Zw_TblArbol_Asociaciones (Identificacdor_NodoPadre,Descripcion,Es_Padre) Values " &
                                       "('" & _Cod_Padre & "','" & Trim(_Descripcion) & "'," & CInt(_Como_Padre) * -1 & ")"
                        If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                            Consulta_sql = "Update Zw_TblArbol_Asociaciones Set Codigo_Nodo = Identificador_Nodo Where Codigo_Nodo = ''"
                            _Sql.Ej_consulta_IDU(Consulta_sql)
                            ' agrego un nuevo nodo secundario dentro del nodo seleccionado
                            TreeView1.SelectedNode.Nodes.Add(_Descripcion)
                        End If
                    End If

                Else
                    MessageBoxEx.Show(Me, "Esta clasificación no permite asignar sub-clasificaciones",
                                      "Agregar sub-clasificación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Else
                MessageBoxEx.Show(Me, "No hay un nodo seleccionado para agregar uno nuevo.",
                                  "Agregar sub-clasificación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub


    Sub Sb_Grabar_Asociaciones(treeNode As TreeNode)

        For Each tn As TreeNode In treeNode.Nodes

            If tn.Checked Then

                Dim _Descripcion_Busqueda = Trim(tn.FullPath)
                Dim _Selec_() = Split(tn.FullPath, "\")

                Dim _NroHijo = _Selec_.Length - 1
                Dim _Hijo = _Selec_(_NroHijo)

                Dim _NroPadre = _Selec_.Length - 2
                Dim _Padre = _Selec_(_NroPadre)

                Dim _Cod_Hijo = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblArbol_Asociaciones", "Identificador_Nodo", "Descripcion = '" & _Hijo & "'")
                Dim _Cod_Nodo As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblArbol_Asociaciones", "Codigo_Nodo", "Descripcion = '" & _Hijo & "'")

                Dim _SqlQuery = "Select * From Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Cod_Nodo

                Dim _TblNodo As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
                Dim _Es_Padre As Boolean

                If CBool(_TblNodo.Rows.Count) Then
                    _Cod_Nodo = _TblNodo.Rows(0).Item("Codigo_Nodo")
                    _Es_Padre = _TblNodo.Rows(0).Item("Es_Padre")

                    If Not _Es_Padre Then
                        _Sql_Query_Grabar += "Insert Into " & _Global_BaseBk & "Zw_Prod_Asociacion " &
                                           "(Codigo,Codigo_Nodo,DescripcionBusqueda) Values " & vbCrLf &
                                           "('" & _Codigo & "'," & _Cod_Nodo & ",'" & _Descripcion_Busqueda & "')" & vbCrLf
                    End If
                End If




                '_Sql_Query_Grabar += "Insert Into Zw_Prod_Asociacion " & _
                '                  "(Codigo,Descripcion,Codigo_Nodo,Identificacdor_NodoPadre,DescripcionBusqueda) Values " & vbCrLf & _
                '                  "('" & _Codigo & "','" & _Descripcion & "'," & _Cod_Nodo & "," & _Cod_Padre & ",'" & _Descripcion_Busqueda & "')" & vbCrLf


            End If
            Sb_Grabar_Asociaciones(tn)
        Next


    End Sub


    Private Sub TreeView1_NodeMouseClick(sender As Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick

        Dim Tn = e.Node

        If Not _Mostrar_Arbol_Del_Producto Then
            If CBool(Tn.Nodes.Count) Then

                ' Beep()

                Tn.Checked = False

                'ToastNotification.Show(Me, "DEBE SELECCIONAR UN HIJO DE ESTE ARBOL", My.Resources.button_rounded_red_delete, _
                '                       2 * 1000, eToastGlowColor.Red, eToastPosition.BottomCenter)

            End If
        End If

        If e.Button = Windows.Forms.MouseButtons.Right Then
            ' Referenciamos el control
            Dim tv As Windows.Forms.TreeView = DirectCast(sender, Windows.Forms.TreeView)

            ' Seleccionamos el nodo
            tv.SelectedNode = e.Node
            'MessageBoxEx.Show(tv.Checked)
        End If

    End Sub

    Private Sub EliminarAsociaciónsoloSiHaSidoCreadaDesdeEsteAsistenteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EliminarAsociaciónsoloSiHaSidoCreadaDesdeEsteAsistenteToolStripMenuItem.Click
        ' pregunto si hay un nodo seleccionado
        If IsNothing(TreeView1.SelectedNode) = False Then

            Dim Tn = TreeView1.SelectedNode
            Dim _Selec_() = Split(Tn.FullPath, "\")
            Dim _NroPadre = _Selec_.Length - 1
            Dim _Padre = _Selec_(_NroPadre)

            Dim _Cod_Padre = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblArbol_Asociaciones", "Codigo_Nodo", "Descripcion = '" & _Padre & "'")
            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_TblArbol_Asociaciones", "Codigo_Nodo = '" & _Cod_Padre & "'")

            If Not CBool(_Reg) Then
                ' elimino el nodo seleccionado
                TreeView1.SelectedNode.Remove()
            Else
                MessageBoxEx.Show(Me, "Esta clasificación se debe eliminar desde el administrador de clasificaciones",
                                     "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Else
            MessageBox.Show("No hay un nodo seleccionado para eliminar.",
                            "Eliminar nodo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BtnExpandirTodo_Click(sender As System.Object, e As System.EventArgs) Handles BtnExpandirTodo.Click
        ' expando todos los nodos del control TreeView
        TreeView1.ExpandAll()
    End Sub

    Private Sub BtnMantencion_Click(sender As System.Object, e As System.EventArgs) Handles BtnMantencion.Click
        Dim Fm As New Frm_Arbol_Asociacion_02(False, 0, False, Frm_Arbol_Asociacion_02.Enum_Clasificacion.Dinamica, 0)
        Fm.Pro_Identificador_NodoPadre = 0
        Fm.ShowDialog(Me)

        TreeView1.Nodes.Clear()

        Sb_Load()

    End Sub

    Private Sub BuildCSV(nodes As TreeNodeCollection,
                         ByRef csvData As String,
                         depth As Integer,
                         Optional _Cadena As String = "")
        For Each node As TreeNode In nodes

            Dim _FullP As String = node.FullPath
            csvData = csvData & New [String](_FullP + vbLf) '(csvData & New [String](","c, depth)) + node.Text + vbLf

            If node.Nodes.Count > 0 Then
                BuildCSV(node.Nodes, csvData, depth + 1)
            End If
        Next
    End Sub


    Private Function BuildMyNodes(treeNodes As TreeNodeCollection) As List(Of MyNode)

        Dim myNodes As New List(Of MyNode)

        For Each node As TreeNode In treeNodes
            Dim newNode As New MyNode(node.Text, node.Tag)
            If (node.Nodes.Count > 0) Then
                newNode.Nodes = BuildMyNodes(node.Nodes)
            End If

            myNodes.Add(newNode)
        Next

        Return myNodes

    End Function

    Private Sub BtnExportarCsv_Click(sender As System.Object, e As System.EventArgs) Handles BtnExportarCsv.Click

        If Fx_Tiene_Permiso(Me, "Tbl00011") Then

            Dim csvData As String = ""
            Dim _Dir = AppPath() & "\Data\" & RutEmpresa & "\ExportedTree.csv"
            BuildCSV(TreeView1.Nodes, csvData, 0)

            If Not String.IsNullOrEmpty(csvData) Then
                SaveFileDialog1.Filter = "TXT Files (*.csv)|*.csv"
                If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                    'My.Computer.FileSystem.WriteAllText _
                    '(SaveFileDialog1.FileName, RichTextBox1.Text, True)
                    _Dir = SaveFileDialog1.FileName

                    Using writer As New StreamWriter(_Dir)
                        csvData = Replace(csvData, "\", ",")
                        writer.Write(csvData)
                    End Using
                    MessageBoxEx.Show(Me, "Archivo guardado correctamente" & vbCrLf &
                                         "Ruta: " & _Dir, "Exportar a csv", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBoxEx.Show(Me, "No exiten datos que exportar",
                                  "Exportar a .csv", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If
    End Sub

    Private Sub Frm_Arbol_Asociacion_01_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub


    Private Function WriteTreeView(parent As String, tnc As TreeNodeCollection) As String

        'TextChangeNode = True

        Dim strOutput As String = ""

        If tnc.Count = 0 Then

            strOutput = parent & vbCrLf 'leaf

        Else

            For i As Integer = 0 To tnc.Count - 1

                Dim strCurrent As String = ""
                Dim Data As String = Replace(Replace(Replace(tnc(i).Tag, vbCr, "{ENTER}"), vbLf, "{ENTER}"), vbTab, "{TAB}")
                Dim Title As String = Replace(Replace(Replace(tnc(i).Text, vbCr, "{ENTER}"), vbLf, "{ENTER}"), vbTab, "{TAB}")
                If parent > "" Then strCurrent = parent & "."
                strCurrent &= "Key(""" & tnc(i).Name & """)" & " - " & "Text(""" & Title & """)" & " - " & "Data(""" & Data & """)"
                strOutput &= WriteTreeView(strCurrent, tnc(i).Nodes)
            Next i

        End If

        Return strOutput

        'TextChangeNode = False

    End Function




    Private Sub BtnContraerTodo_Click(sender As System.Object, e As System.EventArgs) Handles BtnContraerTodo.Click
        ' contraer todos los nodos del control TreeView
        TreeView1.CollapseAll()
    End Sub

    Private Sub BtnImprimirArbol_Click(sender As System.Object, e As System.EventArgs) Handles BtnImprimirArbol.Click
        If Fx_Tiene_Permiso(Me, "Tbl00021") Then
            'Dim _WW = WriteTreeView("", TreeView1.Nodes)
            Dim _Path = AppPath() & "\Data\" & RutEmpresa & "\Clasificaciones_prod"

            'create buffer for storing string data
            Dim buffer As New System.Text.StringBuilder
            'loop through each of the treeview's root nodes
            For Each rootNode As TreeNode In TreeView1.Nodes
                'call recursive function
                BuildTreeString(rootNode, buffer)
            Next
            'write data to file
            IO.File.WriteAllText(_Path & "\Arbol_Class.txt", buffer.ToString)
            Process.Start("notepad.exe", _Path & "\Arbol_Class.txt")
        End If
    End Sub

    Private Sub BuildTreeString(rootNode As TreeNode, ByRef buffer As System.Text.StringBuilder)

        Dim _Linea As String = rootNode.Text
        Dim _Nivel As Integer = rootNode.Level
        Dim _Tab As String

        For i = 0 To _Nivel
            If CBool(i) Then _Tab += vbTab
        Next

        _Linea = _Tab & _Linea
        'If CBool(rootNode.Nodes.Count) Then
        '_Linea = _Tab & "+.." & _Linea
        'Else
        '_Linea = _Tab & "..." & _Linea
        'End If



        Dim Rt = rootNode
        buffer.Append(_Linea)
        buffer.Append(Environment.NewLine)

        For Each childNode As TreeNode In rootNode.Nodes
            BuildTreeString(childNode, buffer)
        Next
    End Sub



    Private Sub Btn_MoverCarpetas_Click(sender As System.Object, e As System.EventArgs) Handles Btn_MoverCarpetas.Click
        If TreeView1.AllowDrop Then
            TreeView1.AllowDrop = False
        Else
            TreeView1.AllowDrop = True
        End If
    End Sub



#Region "Mover Nodos"



    Private Sub Sb_TreeView_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        ' pregunto si el botón que estoy pulsando es el izquierdo para poder arrastrar el nodo
        If e.Button.Left = MouseButtons.Left Then
            ' señalo que se está haciendo un Drag and Drop dentro del TreeView
            DragDropTreeView = True

            ' obtengo el arbol del control TreeView1
            Dim tree As TreeView = CType(sender, TreeView)

            ' recupero el nodo debajo del mouse.
            Dim node As TreeNode
            node = tree.GetNodeAt(e.X, e.Y)

            ' establezco el nodo del árbol seleccionado actualmente en el control TreeView
            tree.SelectedNode = node

            ' guardo los datos del origen del nodo
            NodoOrigen = CType(node, TreeNode)

            If Not (node Is Nothing) Then node.SelectedImageIndex = node.ImageIndex

            ' inicio la operación Drag and Drop con una copia clonada del nodo.
            If Not node Is Nothing Then
                tree.DoDragDrop(node.Clone(), DragDropEffects.Copy)
            End If
        End If
    End Sub

    Private Sub Sb_TreeView_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs)
        If DragDropTreeView = True Then
            ' determino si los datos almacenados en la instancia están asociados al formato especificado del TreeView
            If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", False) Then
                ' variable que sirve para guardar el valor de un punto en coordenadas X e Y
                Dim pt As Point
                ' variable que sirve para guardar el valor del nodo de destino
                Dim DestinationNode As TreeNode

                ' uso PointToClient para calcular la ubicación del mouse sobre el control TreeView
                pt = CType(sender, TreeView).PointToClient(New Point(e.X, e.Y))
                ' uso este punto para recuperar el nodo de destino dentro del árbol del control TreeView.
                DestinationNode = CType(sender, TreeView).GetNodeAt(pt)
                ' verifico que el nodo de destino sea distinto al nodo de origen
                If DestinationNode.FullPath <> NodoOrigen.FullPath Then
                    DestinationNode.Nodes.Add(CType(NodoOrigen.Clone, TreeNode))
                    ' expando el nodo padre donde agregue el nuevo nodo. Sin esto, solo aparecería el signo +.
                    DestinationNode.Expand()
                    ' elimino el nodo de origen dentro del árbol
                    NodoOrigen.Remove()
                End If
            End If
        End If
    End Sub

    Private Sub Sb_TreeView_DragOver(sender As System.Object, e As System.Windows.Forms.DragEventArgs)
        ' Verifica si dentro del TreeView se está arrastrando
        If DragDropTreeView Then
            ' deshabilita la actualización en pantalla del control TreeView 
            TreeView1.BeginUpdate()

            ' obtengo el árbol
            Dim tree As TreeView = CType(sender, TreeView)

            ' establezco el efecto de la operación Drag and Drop
            e.Effect = DragDropEffects.None

            ' pregunto por si el formato es válido?
            If Not e.Data.GetData(GetType(TreeNode)) Is Nothing Then

                ' Obtengo el punto en la pantalla.
                Dim pt As New Point(e.X, e.Y)

                ' Convierto a un punto en el sistema de coordenadas del control TreeView
                pt = tree.PointToClient(pt)

                ' pregunto si el mouse está sobre un nodo válido
                Dim node As TreeNode = tree.GetNodeAt(pt)
                If Not node Is Nothing Then
                    ' establezco el efecto de la operación Drag and Drop
                    e.Effect = DragDropEffects.Copy
                    ' establezco el nodo del árbol seleccionado actualmente en el control TreeView
                    tree.SelectedNode = node
                End If

            End If
            ' habilita la actualización en pantalla del control TreeView
            TreeView1.EndUpdate()
        End If
    End Sub

    Private Sub Sb_TreeView1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        ' señalo que no está haciendo un Drag and Drop dentro del TreeView
        DragDropTreeView = False
    End Sub


#End Region

    Private Sub Btn_RearmarArbol_Click(sender As System.Object, e As System.EventArgs) Handles Btn_RearmarArbol.Click

        Dim Fm As New Frm_Arbol_Asociaciones_05_Marcar_filtros_masivamente
        Fm.Btn_ImportarListado.Visible = False
        Fm.ShowDialog(Me)

    End Sub



    Private Sub TreeView1_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles TreeView1.MouseDoubleClick
        ' obtengo el arbol del control TreeView1
        Dim _Tree As TreeView = CType(sender, TreeView)
        Dim _Nodo As TreeNode = _Tree.SelectedNode

        ' If _Ubicacion And _Tree.SelectedNode.SelectedImageIndex = 2 Then
        'Dim _Descripcion As String = Trim(_Nodo.Text)
        'Sb_Ver_Ubicaciones(_Descripcion)
        'End If

    End Sub

    Private Sub TreeView1_AfterExpand(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterExpand


        ' obtengo el arbol del control TreeView1
        Dim _Tree As TreeView = CType(sender, TreeView)
        Dim _Nodo As TreeNode = _Tree.SelectedNode

        'If _Ubicacion And _Tree.SelectedNode.SelectedImageIndex = 2 Then

        If Not (_Nodo Is Nothing) Then

            If CBool(_Nodo.Nodes.Count) Then
                '_Nodo.SelectedImageIndex = 5
                _Nodo.ImageIndex = 4
                _Nodo.SelectedImageIndex = 4
            End If
        End If
        'Dim _Descripcion As String = Trim(_Nodo.Text)
        'Sb_Ver_Ubicaciones(_Descripcion)
        'If Not (_Nodo Is Nothing) Then _Nodo.SelectedImageIndex = _Nodo.ImageIndex
        'End If



    End Sub

    Private Sub TreeView1_AfterCollapse(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterCollapse

        ' obtengo el arbol del control TreeView1
        Dim _Tree As TreeView = CType(sender, TreeView)
        Dim _Nodo As TreeNode = _Tree.SelectedNode

        Try

            'If _Ubicacion And _Tree.SelectedNode.SelectedImageIndex = 2 Then

            If CBool(_Nodo.Nodes.Count) Then
                '_Nodo.SelectedImageIndex = 5
                _Nodo.ImageIndex = 3
                _Nodo.SelectedImageIndex = 3
            End If
            'Dim _Descripcion As String = Trim(_Nodo.Text)
            'Sb_Ver_Ubicaciones(_Descripcion)
            'If Not (_Nodo Is Nothing) Then _Nodo.SelectedImageIndex = _Nodo.ImageIndex
            'End If

        Catch ex As Exception
            'MessageBoxEx.Show(ex.Message)
        End Try


    End Sub


End Class
