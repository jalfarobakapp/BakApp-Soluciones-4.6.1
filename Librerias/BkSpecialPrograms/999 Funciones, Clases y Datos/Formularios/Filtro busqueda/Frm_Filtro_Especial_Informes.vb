Imports DevComponents.DotNetBar

Public Class Frm_Filtro_Especial_Informes

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _TblFiltro As DataTable
    Dim _Tabla_a_Filtras As _Tabla_Fl

    Dim _Filtrar_Todo As Boolean
    Dim _Filtrar As Boolean

    Dim _Ver_Codigo As Boolean = True

    Dim _Condicion_Extra = String.Empty
    Dim _Condicion_Extra2 = String.Empty
    Dim _Incorporar_Campo_Vacias As Boolean
    Dim _Seleccionar_Solo_Uno As Boolean
    Dim _Requiere_Seleccion As Boolean

    Dim _Orden_By As String = "Order by Codigo"

    Dim _Filtro_SQl As String

    Dim _Activar_Crear_Editar_Eliminar As Boolean

    Enum _Tabla_Fl
        _Funcionarios_Random
        _Documentos
        _Documentos_Venta
        _Documentos_Compra
        _Sucursales
        _Entidades
        _Productos
        _Tabla_Tabcarac
        _Tabla_Marcas
        _Tabla_Super_Familia
        _Tabla_Familia
        _Tabla_Sub_Familia
        _Tabla_Rubros
        _Tabla_Zonas
        _Bodegas
        _Ciudades
        _Comunas
        _Otra
        _Funcionarios_BakApp
        _Estaciones_Bk
        _Pdc_Maquinas
        _Pdc_Obreros
        _Pdc_Operaciones
        _Conceptos
        _Lista_Precios_Ent
    End Enum

    Dim _Ds_Filtros_Busqueda As New Ds_Filtros_Busqueda
    Dim _Dv As New DataView

    Public _Viene_Con_Filtros As Boolean

    Dim _Tabla, _Campo, _Descripcion As String

    Public Property Pro_Filtrar() As Boolean
        Get
            Return _Filtrar
        End Get
        Set(value As Boolean)

        End Set
    End Property
    Public Property Pro_Tbl_Filtro() As DataTable
        Get
            Return _TblFiltro
        End Get
        Set(value As DataTable)
            _TblFiltro = value

            If Not (_TblFiltro Is Nothing) Then
                _Filtro_SQl = Generar_Filtro_IN(_TblFiltro, "", "Codigo", False, False, "'")
            Else
                _Filtro_SQl = "('')"
            End If

        End Set
    End Property
    Public Property Pro_Filtrar_Todo() As Boolean
        Get
            Return Chk_Seleccionar_Todos.Checked
        End Get
        Set(value As Boolean)
            Chk_Seleccionar_Todos.Checked = value
        End Set
    End Property
    Public Property Pro_Sql_Filtro_Condicion_Extra() As String
        Get
            Return _Condicion_Extra
        End Get
        Set(value As String)
            _Condicion_Extra = value
        End Set
    End Property
    Public Property Pro_Campo() As String
        Get
            Return _Campo
        End Get
        Set(value As String)
            _Campo = value
        End Set
    End Property
    Public Property Pro_Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
        End Set
    End Property
    Public Property Pro_Tabla() As String
        Get
            Return _Tabla
        End Get
        Set(value As String)
            _Tabla = value
        End Set
    End Property
    Public Property Pro_Seleccionar_Todo() As Boolean
        Get
            Return Chk_Seleccionar_Todos.Checked
        End Get
        Set(value As Boolean)
            Chk_Seleccionar_Todos.Checked = value
        End Set
    End Property
    Public Property Pro_Txt_Codigo() As String
        Get
            Return Txt_Codigo.Text
        End Get
        Set(value As String)
            Txt_Codigo.Text = value
        End Set
    End Property
    Public Property Pro_Txt_Descripcion() As String
        Get
            Return Txt_Descripcion.Text
        End Get
        Set(value As String)
            Txt_Descripcion.Text = value
        End Set
    End Property
    Public Property Pro_Orden_By As String
        Get
            Return _Orden_By
        End Get
        Set(value As String)
            _Orden_By = value
        End Set
    End Property
    Public Property Pro_Seleccionar_Solo_Uno() As Boolean
        Get
            Return _Seleccionar_Solo_Uno
        End Get
        Set(value As Boolean)
            _Seleccionar_Solo_Uno = value
        End Set
    End Property
    Public Property Pro_Dv As DataView
        Get
            Return _Dv
        End Get
        Set(value As DataView)
            _Dv = value
        End Set
    End Property
    Public Property Pro_Requiere_Seleccion As Boolean
        Get
            Return _Requiere_Seleccion
        End Get
        Set(value As Boolean)
            _Requiere_Seleccion = value
        End Set
    End Property

    Public Property Ver_Codigo As Boolean
        Get
            Return _Ver_Codigo
        End Get
        Set(value As Boolean)
            _Ver_Codigo = value
        End Set
    End Property

    Public Property Activar_Crear_Editar_Eliminar As Boolean
        Get
            Return _Activar_Crear_Editar_Eliminar
        End Get
        Set(value As Boolean)
            _Activar_Crear_Editar_Eliminar = value
        End Set
    End Property

    Public Sub New(Tabla_filtro As _Tabla_Fl,
                   Optional Incorporar_Campo_Vacias As Boolean = False,
                   Optional Condicion_Extra As String = "",
                   Optional Tabla As String = "",
                   Optional Campo As String = "",
                   Optional Descripcion As String = "")

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        ' _Ver_Codigo = True

        _Tabla = Tabla
        _Campo = Campo
        _Descripcion = Descripcion

        _Tabla_a_Filtras = Tabla_filtro

        _Incorporar_Campo_Vacias = Incorporar_Campo_Vacias

        Dim _Arr_Filtro(,) As String = {{"C", "Contiene:"},
                                        {"I", "Igual a:"},
                                        {"E", "Empieza por:"},
                                        {"T", "Termina en:"}}
        Sb_Llenar_Combos(_Arr_Filtro, Cmb_Filtro_Codigo)
        Cmb_Filtro_Codigo.SelectedValue = "C"

        _Condicion_Extra = Condicion_Extra

        _Requiere_Seleccion = True

        Sb_Color_Botones_Barra(Bar1)

        If Global_Thema = Enum_Themas.Oscuro Then

            Txt_Descripcion.FocusHighlightEnabled = False
            Txt_Codigo.FocusHighlightEnabled = False
            BtnAceptar.ForeColor = Color.White
            Btn_Crear.ForeColor = Color.White
            Btn_Editar.ForeColor = Color.White
            Btn_Eliminar.ForeColor = Color.White

        End If

    End Sub

    Private Sub Frm_Filtro_Especial_Informes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, Not Pro_Seleccionar_Solo_Uno)

        Btn_Crear.Visible = Activar_Crear_Editar_Eliminar
        Btn_Editar.Visible = Activar_Crear_Editar_Eliminar
        Btn_Eliminar.Visible = Activar_Crear_Editar_Eliminar

        Sb_Cargar_Datos()

        With Grilla

            .DataSource = _Dv

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Chk").Width = 30
            .Columns("Chk").HeaderText = "Sel."
            .Columns("Chk").Visible = True

            If _Seleccionar_Solo_Uno Then
                .Columns("Chk").ReadOnly = _Seleccionar_Solo_Uno
                .Columns("Chk").Visible = False
            End If

            Dim _Ancho_Descripcion = 400 + 120

            If _Ver_Codigo Then
                .Columns("Codigo").Width = 120
                .Columns("Codigo").HeaderText = "Código"
                .Columns("Codigo").ReadOnly = True
                .Columns("Codigo").Visible = True
                _Ancho_Descripcion -= 120
            End If

            .Columns("Descripcion").Width = _Ancho_Descripcion
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").ReadOnly = True

        End With

        If Chk_Seleccionar_Todos.Checked Then
            Dim chk As Boolean = Chk_Seleccionar_Todos.Checked
            ChequearTodo(Grilla, chk, "")
        End If

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

        If _Seleccionar_Solo_Uno Then
            Chk_Seleccionar_Todos.Visible = False
            Rdb_Mostrar_Solo_Tickeados.Visible = False
            Rdb_Mostrar_Todos.Visible = False
            BtnAceptar.Visible = False
            AddHandler Grilla.KeyDown, AddressOf Sb_Grilla_KeyDown
        Else
            AddHandler Grilla.MouseUp, AddressOf Sb_Grilla_MouseUp
            AddHandler Chk_Seleccionar_Todos.CheckedChanged, AddressOf Sb_Chk_Seleccionar_Todos_CheckedChanged
        End If

        _Dv.RowFilter = String.Format("Codigo+Descripcion Like '%{0}%'", Txt_Codigo.Text & Txt_Descripcion.Text)

        Me.ActiveControl = Txt_Descripcion

    End Sub

    Sub Sb_Cargar_Datos()

        _Ds_Filtros_Busqueda.Clear()

        Select Case _Tabla_a_Filtras

            Case _Tabla_Fl._Funcionarios_Random
                _Tabla = "TABFU" : _Campo = "KOFU" : _Descripcion = "NOKOFU"
            Case _Tabla_Fl._Documentos
                _Tabla = "TABTIDO" : _Campo = "TIDO" : _Descripcion = "NOTIDO"
            Case _Tabla_Fl._Documentos_Venta
                _Tabla = "TABTIDO" : _Campo = "TIDO" : _Descripcion = "NOTIDO"
                _Condicion_Extra = "And TIDO In ('FCV','FDB','FDV','FDX','FEV','FVL','FVT','FVX','BLV')"
            Case _Tabla_Fl._Documentos_Compra

            Case _Tabla_Fl._Bodegas
                _Tabla = "TABBO" : _Campo = "EMPRESA+KOSU+KOBO" : _Descripcion = "NOKOBO"
            Case _Tabla_Fl._Sucursales
                _Tabla = "TABSU" : _Campo = "KOSU" : _Descripcion = "NOKOSU"
            Case _Tabla_Fl._Entidades
                _Tabla = "MAEEN" : _Campo = "KOEN" : _Descripcion = "NOKOEN"
            Case _Tabla_Fl._Productos
                _Tabla = "MAEPR" : _Campo = "KOPR" : _Descripcion = "NOKOPR"
            Case _Tabla_Fl._Tabla_Tabcarac
                _Tabla = "TABCARAC" : _Campo = "KOCARAC" : _Descripcion = "NOKOCARAC"
            Case _Tabla_Fl._Tabla_Marcas
                _Tabla = "TABMR" : _Campo = "KOMR" : _Descripcion = "NOKOMR"
            Case _Tabla_Fl._Tabla_Super_Familia
                _Tabla = "TABFM" : _Campo = "KOFM" : _Descripcion = "NOKOFM"
            Case _Tabla_Fl._Tabla_Familia
                _Tabla = "TABPF" : _Campo = "KOFM+KOPF" : _Descripcion = "NOKOPF"
            Case _Tabla_Fl._Tabla_Sub_Familia
                _Tabla = "TABHF" : _Campo = "KOFM+KOPF+KOHF" : _Descripcion = "NOKOHF"
            Case _Tabla_Fl._Tabla_Rubros
                _Tabla = "TABRU" : _Campo = "KORU" : _Descripcion = "NOKORU"
            Case _Tabla_Fl._Tabla_Zonas
                _Tabla = "TABZO" : _Campo = "KOZO" : _Descripcion = "NOKOZO"
            Case _Tabla_Fl._Ciudades
                _Tabla = "TABCI" : _Campo = "KOPA+KOCI" : _Descripcion = "NOKOCI"
            Case _Tabla_Fl._Comunas
                _Tabla = "TABCM" : _Campo = "KOPA+KOCI+KOCM" : _Descripcion = "NOKOCM"
            Case _Tabla_Fl._Funcionarios_BakApp
                _Tabla = _Global_BaseBk & "Zw_Usuarios" : _Campo = "CodFuncionario" : _Descripcion = "NomFuncionario"
            Case _Tabla_Fl._Estaciones_Bk
                _Tabla = _Global_BaseBk & "Zw_EstacionesBkp" : _Campo = "Id" : _Descripcion = "NombreEquipo+' - IP:'+IpEstacion"
            Case _Tabla_Fl._Pdc_Maquinas
                _Tabla = "PMAQUI" : _Campo = "CODMAQ" : _Descripcion = "NOMBREMAQ"
            Case _Tabla_Fl._Pdc_Obreros
                _Tabla = "PMAEOB" : _Campo = "CODIGOOB" : _Descripcion = "NOMBREOB"
            Case _Tabla_Fl._Pdc_Operaciones
                _Tabla = "POPER" : _Campo = "OPERACION" : _Descripcion = "NOMBREOP"
            Case _Tabla_Fl._Conceptos
                _Tabla = "TABCT" : _Campo = "KOCT" : _Descripcion = "NOKOCT"
            Case _Tabla_Fl._Lista_Precios_Ent
                _Tabla = "TABPP" : _Campo = "'TABPP'+KOLT" : _Descripcion = "NOKOLT"
        End Select

        Dim _Vacia = InStr(_Filtro_SQl, "''") : Dim _V = 0 : If CBool(_Vacia) Then _V = 1

        Dim _Union_Campo_Vacias As String = "Select " & _V & " As Chk,'' As Codigo, 'Vacias...' As Descripcion" & vbCrLf & "Union" & vbCrLf

        Dim _Sin_Filtro As Boolean

        Consulta_Sql = "Select * From " & _Tabla & vbCrLf &
                       "Where " & _Campo & " = ''"

        Dim _Tbl_p2 As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        If _Tbl_p2.Rows.Count > 0 Or Not _Incorporar_Campo_Vacias Then
            _Union_Campo_Vacias = String.Empty
        End If


        If Not (_TblFiltro Is Nothing) Then
            If CBool(_TblFiltro.Rows.Count) Then

                If _Filtrar_Todo Then
                    Consulta_Sql = "Select 1 As Chk,'' As Codigo, 'Vacias...' As Descripcion" & vbCrLf & "Union" & vbCrLf &
                                   "Select CAST( 1 AS bit) AS Chk," & _Campo & " as Codigo," & _Descripcion & " as Descripcion" & vbCrLf &
                                   "From " & _Tabla & vbCrLf &
                                   "Where 1 > 0" & vbCrLf &
                                   _Condicion_Extra & vbCrLf &
                                   _Orden_By
                Else

                    Consulta_Sql = _Union_Campo_Vacias &
                                   "Select CAST( 1 AS bit) AS Chk," & _Campo & " as Codigo," & _Descripcion & " as Descripcion From " & _Tabla & vbCrLf &
                                   "Where " & _Campo & " IN " & _Filtro_SQl & vbCrLf &
                                   _Condicion_Extra & vbCrLf &
                                   "Union" & vbCrLf &
                                   "Select CAST( 0 AS bit) AS Chk," & _Campo & " as Codigo," & _Descripcion & " as Descripcion From " & _Tabla & vbCrLf &
                                   "Where " & _Campo & " not IN " & _Filtro_SQl & vbCrLf &
                                   _Condicion_Extra & vbCrLf &
                                   _Orden_By
                End If

                _Viene_Con_Filtros = True

            Else
                _Sin_Filtro = True
            End If

        Else
            _Sin_Filtro = True
        End If


        If _Sin_Filtro Then

            Dim _Chk = CInt(_Filtrar_Todo) * -1

            Consulta_Sql = _Union_Campo_Vacias &
                           "Select CAST(" & _Chk & " AS bit) AS Chk," & _Campo & " as Codigo," & _Descripcion & " as Descripcion" & vbCrLf &
                           "From " & _Tabla & vbCrLf &
                           "Where 1 > 0" & vbCrLf &
                           _Condicion_Extra & vbCrLf &
                           _Orden_By
        End If

        _Dv.Table = _Sql.Fx_Get_DataSet(Consulta_Sql, _Ds_Filtros_Busqueda, "Tbl_Filtro").Tables("Tbl_Filtro")

    End Sub

    Private Function ChequearTodo(Grilla As DataGridView,
                             Chk As Boolean,
                             TipoFiltro As String)


        For Each _Fila As DataGridViewRow In Grilla.Rows
            _Fila.Cells("Chk").Value = Chk
        Next

        Grilla.CurrentCell = Grilla.Rows(0).Cells("Codigo")

    End Function

    Private Sub Sb_Grilla_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        RemoveHandler Chk_Seleccionar_Todos.CheckedChanged, AddressOf Sb_Chk_Seleccionar_Todos_CheckedChanged

        Chk_Seleccionar_Todos.Checked = False
        _Filtrar_Todo = False

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

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click

        Dim _Union_Campo_Vacias As String = "Select 1 As Chk,'' As Codigo, 'Vacias...' As Descripcion" & vbCrLf &
                                            "Union" & vbCrLf

        Consulta_Sql = "Select * from " & _Tabla & vbCrLf &
                       "Where " & _Campo & " = ''" & vbCrLf & _Condicion_Extra

        Dim _Tbl_p2 As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        If _Tbl_p2.Rows.Count > 0 Then
            _Union_Campo_Vacias = String.Empty
        End If


        If Chk_Seleccionar_Todos.Checked Then

            Consulta_Sql = _Union_Campo_Vacias &
                           "Select CAST( 1 AS bit) AS Chk," & _Campo & " as Codigo," & _Descripcion & " as Descripcion " & vbCrLf &
                           "From " & _Tabla & vbCrLf &
                           "Where 1 > 0" & vbCrLf & _Condicion_Extra
            _TblFiltro = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Else

            Dim _Filtrpo_SQl = Generar_Filtro_IN(_Dv.Table, "Chk", "Codigo", False, True, "'")

            Dim _Cuenta_Checkeados = 0

            For Each _Fila As DataGridViewRow In Grilla.Rows
                If _Fila.Cells("Chk").Value Then
                    _Cuenta_Checkeados += 1
                End If
            Next

            If CBool(_Cuenta_Checkeados) Then

                Dim _Vacia = InStr(_Filtrpo_SQl, "''")

                If Not CBool(_Vacia) Then
                    _Union_Campo_Vacias = String.Empty
                End If

                Consulta_Sql = _Union_Campo_Vacias &
                               "Select CAST( 1 AS bit) AS Chk," & _Campo & " as Codigo," & _Descripcion & " as Descripcion From " & _Tabla & vbCrLf &
                               "Where " & _Campo & " IN " & _Filtrpo_SQl & vbCrLf & _Condicion_Extra
                _TblFiltro = _Sql.Fx_Get_Tablas(Consulta_Sql)

                If _Cuenta_Checkeados = _Dv.Table.Rows.Count Then 'Grilla.Rows.Count Then
                    RemoveHandler Chk_Seleccionar_Todos.CheckedChanged, AddressOf Sb_Chk_Seleccionar_Todos_CheckedChanged
                    Chk_Seleccionar_Todos.Checked = True
                Else
                    Chk_Seleccionar_Todos.Checked = False
                End If

            Else

                _TblFiltro = Nothing

                If _Requiere_Seleccion Then
                    MessageBoxEx.Show(Me, "No se seleccionó ningún registro",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

            End If

        End If

        _Filtrar = True
        Me.Close()

    End Sub

    Private Sub Frm_Filtro_Especial_Informes_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Rdb_Mostrar_Todos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rdb_Mostrar_Todos.CheckedChanged
        Grilla.EndEdit()
        If Rdb_Mostrar_Todos.Checked Then
            _Dv.RowFilter = String.Format("Codigo+Descripcion Like '%{0}%'", Txt_Descripcion.Text)
        End If
        Me.Refresh()
    End Sub

    Private Sub Rdb_Mostrar_Solo_Tickeados_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rdb_Mostrar_Solo_Tickeados.CheckedChanged
        Grilla.EndEdit()
        If Rdb_Mostrar_Solo_Tickeados.Checked Then
            _Dv.RowFilter = String.Format("Chk = {0}", 1)
        End If
        Me.Refresh()
    End Sub

    Private Sub Sb_Chk_Seleccionar_Todos_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Dim chk As Boolean = Chk_Seleccionar_Todos.Checked
        ChequearTodo(Grilla, chk, "")
    End Sub

    Private Sub Txt_Codigo_TextChanged(sender As System.Object, e As System.EventArgs) Handles Txt_Codigo.TextChanged

        Dim _Fl As String
        Select Case Cmb_Filtro_Codigo.SelectedValue
            Case "C" : _Fl = "%{0}%" : Case "E" : _Fl = "{0}%" : Case "T" : _Fl = "%{0}"
        End Select
        _Dv.RowFilter = String.Format("Codigo Like '" & _Fl & "'", Trim(Txt_Codigo.Text))

    End Sub

    Private Sub Btn_Ver_documento_origen_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ver_documento_origen.Click
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim Copiar = Trim(_Fila.Cells(_Cabeza).Value)
        Clipboard.SetText(Copiar)
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

    Private Sub Txt_Descripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Descripcion.KeyDown

        Dim _Key As Keys = e.KeyValue
        Select Case _Key
            Case Keys.Enter, Keys.Space

                Sb_Buscar_En_Grilla_Dataview(Txt_Descripcion.Text)

                If _Seleccionar_Solo_Uno And _Key = Keys.Enter Then
                    If CBool(Grilla.Rows.Count) Then
                        Grilla.Focus()
                    End If
                End If

            Case Keys.Down

                If CBool(Grilla.Rows.Count) Then
                    Grilla.Focus()
                End If

        End Select

    End Sub

    Private Sub Btn_Ayuda_Asistente_Busqueda_Click(sender As Object, e As EventArgs) Handles Btn_Ayuda_Asistente_Busqueda.Click
        Dim _Msg = "Para buscar una lista de productos puede digitar en el campo ""Descripción"" los códigos exactos separados por "";"" (punto y coma)" & vbCrLf &
                  "Ejemplo: CODIGO01;CODIGO02;CODIGO03" & vbCrLf & vbCrLf &
                  "Puede buscar registros por algo de la descripción utilizando algo de la descripción o bien las palabras completas, " &
                  "pero deben ir separadas por espacios entre las palabras" & vbCrLf &
                  "Ejemplo: RUEDA DELANTERA SUZUKI" & vbCrLf & vbCrLf &
                  "Nota: Para ejecutar la busqueda debe presionar ""Enter"" despues de poner los filtros"

        MessageBoxEx.Show(Me, _Msg, "Ayuda, asistente de busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Grilla_KeyUp(sender As Object, e As KeyEventArgs) Handles Grilla.KeyUp

        RemoveHandler Chk_Seleccionar_Todos.CheckedChanged, AddressOf Sb_Chk_Seleccionar_Todos_CheckedChanged
        Chk_Seleccionar_Todos.Checked = False
        _Filtrar_Todo = False

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

    Private Sub Sb_Buscar_En_Grilla_Dataview(_Descripcion_a_buscar As String)

        _Descripcion_a_buscar = Replace(_Descripcion_a_buscar, vbTab, "")

        Dim _Descripcion As String = Replace(_Descripcion_a_buscar, "'", "")

        If IsNothing(_Descripcion) Then _Descripcion = String.Empty

        Dim _Contiene_Punto_Coma As Boolean = _Descripcion.Contains(";")
        Dim _Lista_Descripciones() As String

        Dim _Lista_productos_A_Buscar As String = String.Empty

        If _Contiene_Punto_Coma Then

            Cmb_Filtro_Codigo.SelectedValue = "I"

            _Lista_Descripciones = Split(_Descripcion, ";")

            For i = 0 To _Lista_Descripciones.Length - 1
                If i = 0 Then
                    _Lista_productos_A_Buscar += Fx_Descripcion(_Lista_Descripciones(i))
                Else
                    _Lista_productos_A_Buscar += Fx_Descripcion(_Lista_Descripciones(i), " Or ")
                End If
            Next

        Else

            Cmb_Filtro_Codigo.SelectedValue = "C"

            _Lista_Descripciones = Split(_Descripcion, " ")

            For i = 0 To _Lista_Descripciones.Length - 1
                If i = 0 Then
                    _Lista_productos_A_Buscar += Fx_Descripcion(_Lista_Descripciones(i))
                Else
                    _Lista_productos_A_Buscar += Fx_Descripcion(_Lista_Descripciones(i), " And ")
                End If
            Next

        End If

        _Dv.RowFilter = _Lista_productos_A_Buscar

    End Sub

    Private Sub Sb_Grilla_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyValue = Keys.Enter Then

            SendKeys.Send("{LEFT}")
            e.Handled = True
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            _Fila.Cells("Chk").Value = True
            Call BtnAceptar_Click(Nothing, Nothing)

        End If
    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Excel.Click

        Dim _Tbl1 As DataTable = _Dv.Table
        Dim _Tbl2 As DataTable = Grilla.DataSource.totable

        Dim _Consulta As New DialogResult

        If _Tbl1.Rows.Count <> _Tbl2.Rows.Count Then

            _Consulta = MessageBoxEx.Show(Me, "¿Desea exportar solo la vista actual (Si) o Exportar todo (No)?",
                                 "Exportar a Excel", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            If _Consulta = DialogResult.Cancel Then
                Return
            End If

            If _Consulta = DialogResult.Yes Then
                _Tbl1 = Grilla.DataSource.totable
            End If

        End If

        ExportarTabla_JetExcel_Tabla(_Tbl1, Me, "Informe")

    End Sub

    Private Sub Btn_Crear_Click(sender As Object, e As EventArgs) Handles Btn_Crear.Click

        Select Case _Tabla

            Case "TABRETI"

                If Fx_Tiene_Permiso(Me, "Tbl00045") Then

                    Dim Fm As New Frm_Retirador_Mercaderia("")
                    Fm.ShowDialog(Me)

                    If Fm.Grabar Then

                        Sb_Cargar_Datos()

                        Dim _Row As DataRow = Fm.Row_Tabreti
                        Dim _Codigo = _Row.Item("KORETI")
                        Dim _Descripcion = _Row.Item("NORETI").ToString.Trim

                        Txt_Codigo.Text = String.Empty
                        Txt_Descripcion.Text = _Codigo

                    End If

                    Fm.Dispose()

                End If

        End Select

    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Codigo As String = _Fila.Cells("Codigo").Value

        Select Case _Tabla

            Case "TABRETI"

                If Fx_Tiene_Permiso(Me, "Tbl00045") Then

                    Dim Fm As New Frm_Retirador_Mercaderia(_Codigo)
                    Fm.ShowDialog(Me)

                    If Fm.Grabar Then
                        _Fila.Cells("Descripcion").Value = Fm.Row_Tabreti.Item("NORETI").ToString.Trim
                        Sb_Cargar_Datos()
                    End If

                    If Fm.Eliminado Then
                        Sb_Cargar_Datos()
                    End If

                    Fm.Dispose()

                End If

        End Select

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

    End Sub

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter

        If Activar_Crear_Editar_Eliminar Then
            Btn_Editar.Enabled = True
        End If

    End Sub

    Private Function Fx_Descripcion(_Buscar As String, Optional _And_Or As String = "") As String

        Dim _Descripcion_Busqueda = String.Empty

        If Not String.IsNullOrEmpty(_Buscar) Then
            Select Case Cmb_Filtro_Codigo.SelectedValue
                Case "C" ' Contiene
                    _Descripcion_Busqueda = _And_Or & "Codigo+Descripcion Like '%" & _Buscar & "%'"
                Case "I" ' Igual a 
                    _Descripcion_Busqueda = _And_Or & "Codigo Like '" & _Buscar & "'"
                    'Case "T" ' Termina
                    '_Descripcion_Busqueda = _And_Or & "Descripcion Like '%" & _Buscar & "'"
                    'Case "E" ' Empieza
                    '_Descripcion_Busqueda = _And_Or & "Descripcion Like '" & _Buscar & "'%"
            End Select
        End If

        Return _Descripcion_Busqueda

    End Function

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        If Activar_Crear_Editar_Eliminar Then
            Call Btn_Editar_Click(Nothing, Nothing)
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        _Fila.Cells("Chk").Value = True
        Call BtnAceptar_Click(Nothing, Nothing)

    End Sub


End Class
