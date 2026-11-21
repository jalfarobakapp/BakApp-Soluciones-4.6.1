Imports System.Collections.Generic
Imports DevComponents.DotNetBar

Public Class Frm_Arbol_Asociacion_05_Busqueda

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Dv As New DataView
    Dim _Ds As DataSet

    Dim _Tbl_Vista_Informe_ComboBox As DataTable
    Dim _Tbl_Vista_Informe As DataTable
    Dim _Row_Vista_Informe As DataRow
    Dim _Row_Nodo_Seleccionado As DataRow
    'Dim _Clas_Unica_X_Producto As Boolean

    Dim _Filtro_Unico_Seleccionado As Boolean

    Dim _Tbl_Nodos_Seleccionados As DataTable
    Dim _Seleccionar_Varios As Boolean
    Dim _Seleccionar_Todo As Boolean
    'Dim _Seleccion_Solo_Seleccionables As Boolean

    Dim _Identificacdor_NodoPadre As Integer
    Dim _Sql_Arbol As String
    Dim _Aceptar As Boolean

    Public Property ModoEntidades As Boolean
    Public Property Mostrar_Hijos_Seleccionables() As Boolean

    Enum Enum_Tipo_De_Carpeta
        Clas_Unica_Hijos
        Clas_Unica_Padres
        Clas_Unica_Ambas
        Clas_Filtro_Hijos
        Clas_Filtro_Padres
        Clas_Filtro_Ambas
        Todas
        Clas_Unica_Padres_Seleccion
    End Enum

    Dim _Tipo_De_Carpeta_Mostrar As Enum_Tipo_De_Carpeta

    Public ReadOnly Property Pro_Row_Nodo_Seleccionado() As DataRow
        Get
            Return _Row_Nodo_Seleccionado
        End Get
    End Property
    Public ReadOnly Property Pro_Row_Vista_Informe() As DataRow
        Get
            Return _Row_Vista_Informe
        End Get
    End Property
    Public ReadOnly Property Pro_Tbl_Vista_Informe() As DataTable
        Get
            Return _Tbl_Vista_Informe
        End Get
    End Property
    Public ReadOnly Property Pro_Tbl_Vista_Informe_ComboBox() As DataTable
        Get
            Return _Tbl_Vista_Informe_ComboBox
        End Get
    End Property
    Public Property Pro_Tbl_Nodos_Seleccionados() As DataTable
        Get
            Return _Tbl_Nodos_Seleccionados
        End Get
        Set(value As DataTable)
            _Tbl_Nodos_Seleccionados = value
        End Set
    End Property
    Public Property Pro_Seleccionar_Todo() As Boolean
        Get
            Return _Seleccionar_Todo
        End Get
        Set(value As Boolean)
            _Seleccionar_Todo = value
        End Set
    End Property
    Public ReadOnly Property Pro_Aceptar() As Boolean
        Get
            Return _Aceptar
        End Get
    End Property
    Public Property Pro_Filtro_Unico_Seleccionado() As Boolean
        Get
            Return _Filtro_Unico_Seleccionado
        End Get
        Set(value As Boolean)
            _Filtro_Unico_Seleccionado = value
        End Set
    End Property
    Public Property Pro_Identificacdor_NodoPadre() As Integer
        Get
            Return _Identificacdor_NodoPadre
        End Get
        Set(value As Integer)
            _Identificacdor_NodoPadre = value
        End Set
    End Property

    Public Sub New(Tipo_De_Carpeta_Mostrar As Enum_Tipo_De_Carpeta,
                   Optional Seleccionar_Varios As Boolean = False)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Courier New", 9), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        _Seleccionar_Varios = Seleccionar_Varios
        _Tipo_De_Carpeta_Mostrar = Tipo_De_Carpeta_Mostrar
        _Identificacdor_NodoPadre = 0

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Inf_Ventas_X_Periodo_Tabla_Vista_Informe_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        Sb_Actualizar_Grilla()
        Me.ActiveControl = Txt_Descripcion

        If _Seleccionar_Varios Then
            AddHandler Grilla.CellEndEdit, AddressOf Sb_Grilla_CellEndEdit
            AddHandler Grilla.CellMouseUp, AddressOf Sb_Grilla_CellMouseUp
        Else
            AddHandler Grilla.CellDoubleClick, AddressOf Sb_Grilla_CellDoubleClick
        End If

    End Sub

    Private Function Fx_Hijos(_Codigo_Nodo As Integer,
                              _Sql_Ar As String,
                              _Full_Path As String,
                              Optional _Nro_Padres As Integer = 0) As String

        Dim _Clas_Arbol_Asociaciones As New Clas_Arbol_Asociaciones(Me)

        Dim _Solo_Hijos, _Solo_Padres As Boolean

        Dim _Sql_Hijo As String
        Dim _Full As String
        Dim _Semi As String

        Dim _Sql_Clas_Unica = String.Empty

        Select Case _Tipo_De_Carpeta_Mostrar

            Case Enum_Tipo_De_Carpeta.Clas_Unica_Hijos
                _Sql_Clas_Unica = "And Clas_Unica_X_Producto = 1" ' And Es_Seleccionable = 1"
                _Solo_Hijos = True : _Solo_Padres = False
            Case Enum_Tipo_De_Carpeta.Clas_Unica_Padres
                _Sql_Clas_Unica = "And Clas_Unica_X_Producto = 1" ' And Es_Seleccionable = 0"
                _Solo_Hijos = False : _Solo_Padres = True
            Case Enum_Tipo_De_Carpeta.Clas_Unica_Ambas
                _Sql_Clas_Unica = "And Clas_Unica_X_Producto = 1"
                _Solo_Hijos = True : _Solo_Padres = True
            Case Enum_Tipo_De_Carpeta.Clas_Filtro_Hijos
                _Sql_Clas_Unica = "And Clas_Unica_X_Producto = 0" 'And Es_Seleccionable = 1"
                _Solo_Hijos = True : _Solo_Padres = False
            Case Enum_Tipo_De_Carpeta.Clas_Filtro_Padres
                _Sql_Clas_Unica = "And Clas_Unica_X_Producto = 0" ' And Es_Seleccionable = 0"
                _Solo_Hijos = False : _Solo_Padres = True
            Case Enum_Tipo_De_Carpeta.Clas_Filtro_Ambas
                _Sql_Clas_Unica = "And Clas_Unica_X_Producto = 0"
                _Solo_Hijos = True : _Solo_Padres = True
            Case Enum_Tipo_De_Carpeta.Todas
                _Sql_Clas_Unica = String.Empty
                _Solo_Hijos = True : _Solo_Padres = True
            Case Enum_Tipo_De_Carpeta.Clas_Unica_Padres_Seleccion
                _Sql_Clas_Unica = "And Clas_Unica_X_Producto = 1 And Es_Seleccionable = 0" ' And Nodo_Raiz <> 0"
                _Solo_Hijos = False : _Solo_Padres = True
        End Select

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                       "Where 1 > 0 And Identificacdor_NodoPadre = " & _Codigo_Nodo & vbCrLf & _Sql_Clas_Unica & vbCrLf &
                       "Order by Descripcion"

        Dim _TblHijos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        For Each _Fila As DataRow In _TblHijos.Rows

            Dim _Codigo = _Fila.Item("Codigo_Nodo")
            _Codigo_Nodo = _Fila.Item("Codigo_Nodo")

            Dim _Descripcion = NuloPorNro(_Fila.Item("Descripcion"), "")
            Dim _Es_Seleccionable As Boolean = _Fila.Item("Es_Seleccionable")
            Dim _Identificacdor_NodoPadre = _Fila.Item("Identificacdor_NodoPadre")
            'Dim _Es_Padre = _Fila.Item("Es_Padre")
            Dim _Clas_Unica_X_Producto = _Fila.Item("Clas_Unica_X_Producto")
            Dim _Nodo_Raiz = _Fila.Item("Nodo_Raiz")

            If _Es_Seleccionable And _Solo_Hijos Then

                If String.IsNullOrEmpty(_Descripcion) Then
                    _Descripcion = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblArbol_Asociaciones", "Descripcion",
                                                     "Codigo_Nodo = " & _Codigo)
                End If

                _Full = _Full_Path & "\" & _Descripcion

                For i = 0 To _Nro_Padres
                    If i > 0 Then
                        _Semi += Space(i + 1) '& "..\" & _Descripcion
                    End If
                Next

                _Semi += _Descripcion

                _Sql_Hijo += _Sql_Ar + vbCrLf &
                             "Insert Into #Paso_Vista (Codigo_Nodo,Identificacdor_NodoPadre,Descripcion,Es_Padre," &
                             "Es_Seleccionable,Clas_Unica_X_Producto,Nodo_Raiz,Full_Path,Semi_Path,Nro_Padres) Values " &
                             "('" & _Codigo & "','" & _Identificacdor_NodoPadre & "','" & _Descripcion & "',0," &
                             CInt(_Es_Seleccionable) * -1 & "," &
                             CInt(_Clas_Unica_X_Producto) * -1 & "," & _Nodo_Raiz &
                             ",'" & _Full & "','" & Space((_Nro_Padres * 2) + 1) & _Descripcion & "'," & _Nro_Padres & ")" & vbCrLf

                _Full = String.Empty
                _Semi = String.Empty

            Else

                If String.IsNullOrEmpty(_Descripcion) Then
                    _Descripcion = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblArbol_Asociaciones",
                                                     "Descripcion", "Codigo_Nodo = '" & _Codigo_Nodo & "'")
                End If

                _Full = _Full_Path & "\" & _Descripcion

                For i = 0 To _Nro_Padres
                    If i > 0 Then
                        _Semi += Space(i + 1)
                    End If
                Next

                _Semi = _Semi + _Descripcion

                If _Solo_Padres Then

                    _Sql_Hijo += _Sql_Ar + vbCrLf &
                                "Insert Into #Paso_Vista (Codigo_Nodo,Identificacdor_NodoPadre,Descripcion,Es_Padre," &
                                 "Es_Seleccionable,Clas_Unica_X_Producto,Nodo_Raiz,Full_Path,Semi_Path,Nro_Padres) Values " &
                                 "('" & _Codigo & "','" & _Identificacdor_NodoPadre & "','" & _Descripcion & "',0," &
                                 CInt(_Es_Seleccionable) * -1 & "," &
                                 CInt(_Clas_Unica_X_Producto) * -1 &
                                 "," & _Nodo_Raiz & ",'" & _Full & "','" & Space((_Nro_Padres * 2) + 1) & _Descripcion & "'," & _Nro_Padres & ")" & vbCrLf

                End If

            End If

            _Sql_Hijo += Fx_Hijos(_Codigo_Nodo, _Sql_Ar, _Full, _Nro_Padres + 1)

        Next

        Return _Sql_Hijo

    End Function

    Sub Sb_Actualizar_Grilla_Old()

        Me.Cursor = Cursors.WaitCursor

        Dim _Sql_Marcar_Seleccionados = String.Empty
        Dim _Filtro_Solo_Seleccionados As String = String.Empty

        If _Seleccionar_Todo Then
            _Sql_Marcar_Seleccionados = "Update #Paso_Vista Set Chk = 1"
        Else
            If Not (_Tbl_Nodos_Seleccionados Is Nothing) Then
                If CBool(_Tbl_Nodos_Seleccionados.Rows.Count) Then
                    _Sql_Marcar_Seleccionados = Generar_Filtro_IN(_Tbl_Nodos_Seleccionados, "Chk", "Codigo_Nodo", False, True, "")
                    _Sql_Marcar_Seleccionados = "Update #Paso_Vista Set Chk = 1 Where Codigo_Nodo In " & _Sql_Marcar_Seleccionados
                End If
            End If
        End If

        If Not _Seleccionar_Varios Then
            If Not _Seleccionar_Todo Then
                If Not (_Tbl_Nodos_Seleccionados Is Nothing) Then
                    If CBool(_Tbl_Nodos_Seleccionados.Rows.Count) Then
                        _Filtro_Solo_Seleccionados = Generar_Filtro_IN(_Tbl_Nodos_Seleccionados, "Chk", "Codigo_Nodo", False, True, "")
                        _Filtro_Solo_Seleccionados = "Where Codigo_Nodo In " & _Filtro_Solo_Seleccionados
                    End If
                End If
            End If
        End If

        Dim _Sql_Clas_Unica As String

        _Sql_Arbol = String.Empty
        _Sql_Arbol += Fx_Hijos(_Identificacdor_NodoPadre, _Sql_Arbol, "")

        Consulta_sql = "CREATE TABLE #Paso_Vista (" & vbCrLf &
                       "[Id]                       [int] IDENTITY(1,1) NOT NULL," & vbCrLf &
                       "[Chk]                      [bit]          Default  (0)," & vbCrLf &
                       "[Codigo_Nodo]              [varchar](10)  Default(0)," & vbCrLf &
                       "[Identificacdor_NodoPadre] [int]          Default(0)," & vbCrLf &
                       "[Descripcion]              [varchar](200) Default('')," & vbCrLf &
                       "[Es_Padre]                 [bit]		   Default(0)," & vbCrLf &
                       "[Es_Seleccionable]         [bit]		   Default(0)," & vbCrLf &
                       "[Clas_Unica_X_Producto]    [bit]          Default(0)," & vbCrLf &
                       "[Nodo_Raiz]                [int]          Default(0)," & vbCrLf &
                       "[Full_Path]                [Varchar](500) Default('')," & vbCrLf &
                       "[Semi_Path]                [Varchar](500) Default('')," & vbCrLf &
                       "[Nro_Padres]               [int]          Default(0))" & vbCrLf &
                       vbCrLf &
                       _Sql_Arbol & vbCrLf &
                       _Sql_Marcar_Seleccionados & vbCrLf &
                       "Select * From #Paso_Vista" & vbCrLf &
                       _Filtro_Solo_Seleccionados & vbCrLf &
                       "Order By Clas_Unica_X_Producto,Id" & vbCrLf &
                       "Drop Table #Paso_Vista"

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Dv.Table = _Sql.Fx_Get_DataSet(Consulta_sql, _Ds, 0).Tables("Table")
        _Tbl_Vista_Informe = _Dv.Table


        With Grilla

            .DataSource = _Dv

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _Wi = 0

            If _Seleccionar_Varios Then
                .Columns("Chk").Width = 30
                .Columns("Chk").HeaderText = "Sel."
                .Columns("Chk").ReadOnly = False
                .Columns("Chk").Visible = True
                _Wi = 30
            End If

            Select Case _Tipo_De_Carpeta_Mostrar

                Case Enum_Tipo_De_Carpeta.Clas_Filtro_Hijos,
                     Enum_Tipo_De_Carpeta.Clas_Filtro_Padres,
                     Enum_Tipo_De_Carpeta.Clas_Unica_Hijos,
                     Enum_Tipo_De_Carpeta.Clas_Unica_Padres

                    .Columns("Full_Path").Width = 660 - _Wi
                    .Columns("Full_Path").HeaderText = "Descripción"
                    .Columns("Full_Path").ReadOnly = True
                    .Columns("Full_Path").Visible = True

                Case Else

                    .Columns("Semi_Path").Width = 660 - _Wi
                    .Columns("Semi_Path").HeaderText = "Descripción"
                    .Columns("Semi_Path").ReadOnly = True
                    .Columns("Semi_Path").Visible = True

            End Select

        End With

        Sb_Marcar_Grilla()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Sb_Actualizar_Grilla()

        Me.Cursor = Cursors.WaitCursor

        Try
            Dim _Solo_Hijos As Boolean = False
            Dim _Solo_Padres As Boolean = False
            Dim _Filtro_Clasificacion As String = String.Empty

            Select Case _Tipo_De_Carpeta_Mostrar

                Case Enum_Tipo_De_Carpeta.Clas_Unica_Hijos,
                 Enum_Tipo_De_Carpeta.Clas_Unica_Padres,
                 Enum_Tipo_De_Carpeta.Clas_Unica_Ambas

                    _Filtro_Clasificacion = $"And ParaEntidad = {Convert.ToInt32(ModoEntidades)} And Clas_Unica_X_Producto = 1"

                Case Enum_Tipo_De_Carpeta.Clas_Filtro_Hijos,
                 Enum_Tipo_De_Carpeta.Clas_Filtro_Padres,
                 Enum_Tipo_De_Carpeta.Clas_Filtro_Ambas

                    _Filtro_Clasificacion = $"And ParaEntidad = {Convert.ToInt32(ModoEntidades)} And Clas_Unica_X_Producto = 0"

                Case Enum_Tipo_De_Carpeta.Clas_Unica_Padres_Seleccion

                    _Filtro_Clasificacion = $"And ParaEntidad = {Convert.ToInt32(ModoEntidades)} And Clas_Unica_X_Producto = 1 And Es_Seleccionable = 0"

            End Select

            Select Case _Tipo_De_Carpeta_Mostrar

                Case Enum_Tipo_De_Carpeta.Clas_Unica_Hijos,
                     Enum_Tipo_De_Carpeta.Clas_Filtro_Hijos
                    _Solo_Hijos = True

                Case Enum_Tipo_De_Carpeta.Clas_Unica_Padres,
                     Enum_Tipo_De_Carpeta.Clas_Filtro_Padres,
                     Enum_Tipo_De_Carpeta.Clas_Unica_Padres_Seleccion
                    _Solo_Padres = True

                Case Enum_Tipo_De_Carpeta.Clas_Unica_Ambas,
                     Enum_Tipo_De_Carpeta.Clas_Filtro_Ambas,
                     Enum_Tipo_De_Carpeta.Todas
                    _Solo_Hijos = True
                    _Solo_Padres = True

            End Select

            Consulta_sql = "Select Codigo_Nodo,Identificacdor_NodoPadre,Descripcion," & vbCrLf &
                       "Es_Seleccionable,Clas_Unica_X_Producto,Nodo_Raiz" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                       "Where 1 > 0 " & _Filtro_Clasificacion & vbCrLf &
                       "Order By Descripcion"

            Dim _TblNodos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If _TblNodos Is Nothing Then Return

            Dim _HijosPorPadre As New Dictionary(Of Integer, List(Of DataRow))

            For Each _Fila As DataRow In _TblNodos.Rows

                Dim _IdPadre As Integer = Convert.ToInt32(_Fila("Identificacdor_NodoPadre"))
                Dim _Hijos As List(Of DataRow) = Nothing

                If Not _HijosPorPadre.TryGetValue(_IdPadre, _Hijos) Then
                    _Hijos = New List(Of DataRow)
                    _HijosPorPadre.Add(_IdPadre, _Hijos)
                End If

                _Hijos.Add(_Fila)

            Next

            Dim _CodigosSeleccionados As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

            If _Tbl_Nodos_Seleccionados IsNot Nothing Then
                For Each _FilaSeleccionada As DataRow In _Tbl_Nodos_Seleccionados.Rows

                    If _FilaSeleccionada.RowState = DataRowState.Deleted Then Continue For

                    If Not IsDBNull(_FilaSeleccionada("Chk")) AndAlso
                   Convert.ToBoolean(_FilaSeleccionada("Chk")) Then

                        _CodigosSeleccionados.Add(
                        _FilaSeleccionada("Codigo_Nodo").ToString().Trim())

                    End If

                Next
            End If

            Dim _FiltrarSeleccionados As Boolean =
            Not _Seleccionar_Varios AndAlso
            Not _Seleccionar_Todo AndAlso
            _Tbl_Nodos_Seleccionados IsNot Nothing AndAlso
            _Tbl_Nodos_Seleccionados.Rows.Count > 0

            Dim _TblVista As New DataTable("TablaVista")

            Dim _ColumnaId As DataColumn = _TblVista.Columns.Add("Id", GetType(Integer))
            _ColumnaId.AutoIncrement = True
            _ColumnaId.AutoIncrementSeed = 1
            _ColumnaId.AutoIncrementStep = 1

            _TblVista.Columns.Add("Chk", GetType(Boolean))

            Dim _ColumnaCodigo As DataColumn =
            _TblVista.Columns.Add("Codigo_Nodo", GetType(String))
            _ColumnaCodigo.MaxLength = 10

            _TblVista.Columns.Add("Identificacdor_NodoPadre", GetType(Integer))

            Dim _ColumnaDescripcion As DataColumn =
            _TblVista.Columns.Add("Descripcion", GetType(String))
            _ColumnaDescripcion.MaxLength = 200

            _TblVista.Columns.Add("Es_Padre", GetType(Boolean))
            _TblVista.Columns.Add("Es_Seleccionable", GetType(Boolean))
            _TblVista.Columns.Add("Clas_Unica_X_Producto", GetType(Boolean))
            _TblVista.Columns.Add("Nodo_Raiz", GetType(Integer))

            Dim _ColumnaFullPath As DataColumn =
            _TblVista.Columns.Add("Full_Path", GetType(String))
            _ColumnaFullPath.MaxLength = 500

            Dim _ColumnaSemiPath As DataColumn =
            _TblVista.Columns.Add("Semi_Path", GetType(String))
            _ColumnaSemiPath.MaxLength = 500

            _TblVista.Columns.Add("Nro_Padres", GetType(Integer))

            Sb_Agregar_Hijos(
            _Identificacdor_NodoPadre,
            String.Empty,
            0,
            _HijosPorPadre,
            _TblVista,
            _Solo_Hijos,
            _Solo_Padres,
            _CodigosSeleccionados,
            _FiltrarSeleccionados)

            _Dv.Table = _TblVista
            _Dv.Sort = "Clas_Unica_X_Producto ASC, Id ASC"
            _Tbl_Vista_Informe = _TblVista

            With Grilla

                .DataSource = _Dv

                OcultarEncabezadoGrilla(Grilla, True)

                Grilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
                Grilla.ColumnHeadersHeight = 26

                Dim _Wi As Integer = 0

                If _Seleccionar_Varios Then
                    .Columns("Chk").Width = 30
                    .Columns("Chk").HeaderText = "Sel."
                    .Columns("Chk").ReadOnly = False
                    .Columns("Chk").Visible = True
                    _Wi = 30
                End If

                Select Case _Tipo_De_Carpeta_Mostrar

                    Case Enum_Tipo_De_Carpeta.Clas_Filtro_Hijos,
                     Enum_Tipo_De_Carpeta.Clas_Filtro_Padres,
                     Enum_Tipo_De_Carpeta.Clas_Unica_Hijos,
                     Enum_Tipo_De_Carpeta.Clas_Unica_Padres

                        .Columns("Full_Path").Width = 660 - _Wi
                        .Columns("Full_Path").HeaderText = "Descripción"
                        .Columns("Full_Path").ReadOnly = True
                        .Columns("Full_Path").Visible = True

                    Case Else

                        .Columns("Semi_Path").Width = 660 - _Wi
                        .Columns("Semi_Path").HeaderText = "Descripción"
                        .Columns("Semi_Path").ReadOnly = True
                        .Columns("Semi_Path").Visible = True

                End Select

            End With

            Sb_Marcar_Grilla()

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub Sb_Agregar_Hijos(ByVal _CodigoNodoPadre As Integer,
                             ByVal _FullPathPadre As String,
                             ByVal _NroPadres As Integer,
                             ByVal _HijosPorPadre As Dictionary(Of Integer, List(Of DataRow)),
                             ByVal _TblVista As DataTable,
                             ByVal _SoloHijos As Boolean,
                             ByVal _SoloPadres As Boolean,
                             ByVal _CodigosSeleccionados As HashSet(Of String),
                             ByVal _FiltrarSeleccionados As Boolean)

        Dim _Hijos As List(Of DataRow) = Nothing

        If Not _HijosPorPadre.TryGetValue(_CodigoNodoPadre, _Hijos) Then Return

        For Each _Fila As DataRow In _Hijos

            Dim _CodigoNodo As String = _Fila("Codigo_Nodo").ToString().Trim()
            Dim _Descripcion As String =
            If(IsDBNull(_Fila("Descripcion")), String.Empty, _Fila("Descripcion").ToString())

            Dim _EsSeleccionable As Boolean =
            Convert.ToBoolean(_Fila("Es_Seleccionable"))

            Dim _ClasUnica As Boolean =
            Convert.ToBoolean(_Fila("Clas_Unica_X_Producto"))

            Dim _AgregarFila As Boolean = (_SoloPadres OrElse (_SoloHijos AndAlso _EsSeleccionable)) AndAlso (Mostrar_Hijos_Seleccionables OrElse Not _EsSeleccionable)

            If _AgregarFila AndAlso
           (Not _FiltrarSeleccionados OrElse _CodigosSeleccionados.Contains(_CodigoNodo)) Then

                Dim _NuevaFila As DataRow = _TblVista.NewRow()

                _NuevaFila("Chk") =
                _Seleccionar_Todo OrElse _CodigosSeleccionados.Contains(_CodigoNodo)
                _NuevaFila("Codigo_Nodo") = _CodigoNodo
                _NuevaFila("Identificacdor_NodoPadre") =
                Convert.ToInt32(_Fila("Identificacdor_NodoPadre"))
                _NuevaFila("Descripcion") = _Descripcion
                _NuevaFila("Es_Padre") = _HijosPorPadre.ContainsKey(Convert.ToInt32(_CodigoNodo))
                _NuevaFila("Es_Seleccionable") = _EsSeleccionable
                _NuevaFila("Clas_Unica_X_Producto") = _ClasUnica
                _NuevaFila("Nodo_Raiz") = Convert.ToInt32(_Fila("Nodo_Raiz"))
                _NuevaFila("Full_Path") = _FullPathPadre & "\" & _Descripcion
                _NuevaFila("Semi_Path") = Space((_NroPadres * 2) + 1) & _Descripcion
                _NuevaFila("Nro_Padres") = _NroPadres

                _TblVista.Rows.Add(_NuevaFila)

            End If

            Sb_Agregar_Hijos(
            Convert.ToInt32(_CodigoNodo),
            _FullPathPadre & "\" & _Descripcion,
            _NroPadres + 1,
            _HijosPorPadre,
            _TblVista,
            _SoloHijos,
            _SoloPadres,
            _CodigosSeleccionados,
            _FiltrarSeleccionados)

        Next

    End Sub

    Sub Sb_Marcar_Grilla()
        For Each _Fila As DataGridViewRow In Grilla.Rows
            Sb_Marcar_Fila(_Fila)
        Next
    End Sub

    Sub Sb_Marcar_Fila(_Fila As DataGridViewRow)

        If _Seleccionar_Varios Then

            Dim _Chk As Boolean = _Fila.Cells("Chk").Value
            Dim _Es_Seleccionable As Boolean = _Fila.Cells("Es_Seleccionable").Value

            If _Chk Then

                Select Case _Tipo_De_Carpeta_Mostrar

                    Case Enum_Tipo_De_Carpeta.Clas_Filtro_Hijos,
                         Enum_Tipo_De_Carpeta.Clas_Unica_Hijos

                        If Global_Thema = Enum_Themas.Oscuro Then
                            _Fila.DefaultCellStyle.ForeColor = Color.Black
                        End If

                        _Fila.DefaultCellStyle.BackColor = Color.Yellow

                    Case Else

                        If Global_Thema = Enum_Themas.Oscuro Then
                            _Fila.DefaultCellStyle.ForeColor = Color.Black
                        End If

                        _Fila.DefaultCellStyle.BackColor = Color.PaleGoldenrod

                End Select

            Else

                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.ForeColor = Color.White
                    _Fila.DefaultCellStyle.BackColor = Color.Black
                Else
                    _Fila.DefaultCellStyle.BackColor = Color.White
                End If

            End If

            If _Es_Seleccionable Then
                _Fila.DefaultCellStyle.Font = New Font("Courier New", 8, FontStyle.Italic)
            Else
                _Fila.DefaultCellStyle.Font = New Font("Courier New", 10, FontStyle.Bold)
            End If

        End If

        Dim _EsPadre As Boolean = Convert.ToBoolean(_Fila.Cells("Es_Padre").Value)

        Dim _Estilo As FontStyle = If(_EsPadre, FontStyle.Bold, FontStyle.Regular)

        If _Seleccionar_Varios AndAlso Convert.ToBoolean(_Fila.Cells("Es_Seleccionable").Value) Then
            _Estilo = _Estilo Or FontStyle.Italic
        End If

        Dim _Tamano As Single = Grilla.Font.Size

        If _Seleccionar_Varios Then
            _Tamano = If(Convert.ToBoolean(_Fila.Cells("Es_Seleccionable").Value), 8.0F, 10.0F)
        End If

        _Fila.DefaultCellStyle.Font = New Font(Grilla.Font.FontFamily, _Tamano, _Estilo)

    End Sub

    Private Sub Txt_Descripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles Txt_Descripcion.TextChanged
        _Dv.RowFilter = String.Format("Codigo_Nodo+Full_Path Like '%{0}%'", Txt_Descripcion.Text)
        Sb_Marcar_Grilla()
        Lbl_Full_Path.Text = "..."
    End Sub

    Private Sub Sb_Grilla_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        If _Seleccionar_Varios Then Return

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Codigo_Nodo = _Fila.Cells("Codigo_Nodo").Value
        Dim _Id As Integer = _Fila.Cells("Id").Value

        Select Case _Tipo_De_Carpeta_Mostrar
            Case Enum_Tipo_De_Carpeta.Clas_Unica_Padres

                Dim Fm As New Frm_Arbol_Asociacion_05_Busqueda(
               Frm_Arbol_Asociacion_05_Busqueda.Enum_Tipo_De_Carpeta.Clas_Unica_Hijos, False)

                Fm.Pro_Identificacdor_NodoPadre = _Codigo_Nodo
                Fm.ShowDialog(Me)
                _Aceptar = Fm.Pro_Aceptar
                If _Aceptar Then
                    _Row_Nodo_Seleccionado = Fm.Pro_Row_Nodo_Seleccionado
                End If
                Fm.Dispose()

            Case Else
                Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
                _Row_Nodo_Seleccionado = _Sql.Fx_Get_DataRow(Consulta_sql)
                _Aceptar = True
        End Select

        If _Aceptar Then Me.Close()
    End Sub

    Private Sub Sb_Grilla_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Codigo_Nodo As Integer = _Fila.Cells("Codigo_Nodo").Value
        Dim _Descripcion As String = _Fila.Cells("Descripcion").Value
        Dim _Identificacdor_NodoPadre As Integer = _Fila.Cells("Identificacdor_NodoPadre").Value
        Dim _Chk As Boolean = _Fila.Cells("Chk").Value
        Dim _Es_Seleccionable As Boolean = _Fila.Cells("Es_Seleccionable").Value

        If CBool(_Identificacdor_NodoPadre) Then
            Fx_Marcar_Hijos(_Fila, _Chk)
        Else
            For Each _Fl As DataGridViewRow In Grilla.Rows

                Dim _New_Codigo_Nodo As Integer = _Fl.Cells("Codigo_Nodo").Value
                Dim _New_Full_Path As String = _Fl.Cells("Full_Path").Value
                Dim _New_Nodo_Raiz = _Fl.Cells("Nodo_Raiz").Value

                If _Codigo_Nodo = _New_Nodo_Raiz Then
                    _Fl.Cells("Chk").Value = _Chk
                    Sb_Marcar_Fila(_Fl)
                End If
            Next
        End If

        Sb_Marcar_Fila(_Fila)

    End Sub

    Function Fx_Marcar_Hijos(_Fila As DataGridViewRow, _Chk As Boolean)

        Dim _Codigo_Nodo As Integer = _Fila.Cells("Codigo_Nodo").Value
        Dim _Descripcion As String = _Fila.Cells("Descripcion").Value
        Dim _Identificacdor_NodoPadre As Integer = _Fila.Cells("Identificacdor_NodoPadre").Value
        Dim _Nodo_Raiz = _Fila.Cells("Nodo_Raiz").Value
        Dim _Es_Seleccionable As Boolean = _Fila.Cells("Es_Seleccionable").Value

        If _Es_Seleccionable Then
            _Fila.Cells("Chk").Value = _Chk
            Sb_Marcar_Fila(_Fila)
        Else
            For Each _Fl As DataGridViewRow In Grilla.Rows

                Dim _New_Codigo_Nodo As Integer = _Fl.Cells("Codigo_Nodo").Value
                Dim _New_Full_Path As String = _Fl.Cells("Full_Path").Value
                Dim _New_Nodo_Raiz = _Fl.Cells("Nodo_Raiz").Value

                If _Nodo_Raiz = _New_Nodo_Raiz Then
                    If _New_Codigo_Nodo <> _Codigo_Nodo Then

                        If CBool(_Identificacdor_NodoPadre) Then

                            Dim _New_Identificacdor_NodoPadre = _Fl.Cells("Identificacdor_NodoPadre").Value

                            If _New_Identificacdor_NodoPadre = _Codigo_Nodo Then
                                _Fl.Cells("Chk").Value = _Chk
                                Fx_Marcar_Hijos(_Fl, _Chk)
                                '
                            End If

                        Else
                            _Fl.Cells("Chk").Value = _Chk
                        End If
                        Sb_Marcar_Fila(_Fl)
                    Else
                        Dim S = 0
                    End If
                End If

            Next
        End If


    End Function

    Private Sub Sb_Grilla_CellMouseUp(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        Grilla.EndEdit()
    End Sub

    Private Sub Btn_Aceptar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Aceptar.Click

        Dim _Fila As DataGridViewRow

        Try
            _Fila = Grilla.Rows(Grilla.CurrentRow.Index)
        Catch ex As Exception
            _Fila = Grilla.Rows(0)
        End Try

        Dim _Cuenta_Seleccionados = 0

        Select Case _Tipo_De_Carpeta_Mostrar

            Case Enum_Tipo_De_Carpeta.Clas_Filtro_Hijos,
                 Enum_Tipo_De_Carpeta.Clas_Unica_Hijos

                _Cuenta_Seleccionados = 1

            Case Else

                For Each _Fl As DataRow In _Tbl_Vista_Informe.Rows
                    If _Fl.Item("Chk") Then
                        _Cuenta_Seleccionados += 1
                    End If
                Next

        End Select


        If CBool(_Cuenta_Seleccionados) Then

            If _Cuenta_Seleccionados = _Tbl_Vista_Informe.Rows.Count Then
                _Seleccionar_Todo = True
            Else
                _Seleccionar_Todo = False
            End If

            Dim _Codigo_Nodo As Integer = _Fila.Cells("Codigo_Nodo").Value
            Dim _Nodo_Padre As Integer = _Fila.Cells("Identificacdor_NodoPadre").Value
            Dim _Chk As Boolean = _Fila.Cells("Chk").Value
            Dim _Es_Seleccionable As Boolean = _Fila.Cells("Es_Seleccionable").Value

            _Tbl_Nodos_Seleccionados = _Tbl_Vista_Informe
            _Aceptar = True
            Me.Close()

        Else
            MessageBoxEx.Show(Me, "Debe seleccionar una clasificación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Grilla_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEndEdit
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Sb_Marcar_Fila(_Fila)
    End Sub

    Private Sub Grilla_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEnter
        Try
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Lbl_Full_Path.Text = _Fila.Cells("Full_Path").Value
        Catch ex As Exception
            Lbl_Full_Path.Text = "..."
        End Try
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
    End Sub

    Private Sub Btn_Salir_Sin_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Salir_Sin_Grabar.Click
        Me.Close()
    End Sub
End Class
