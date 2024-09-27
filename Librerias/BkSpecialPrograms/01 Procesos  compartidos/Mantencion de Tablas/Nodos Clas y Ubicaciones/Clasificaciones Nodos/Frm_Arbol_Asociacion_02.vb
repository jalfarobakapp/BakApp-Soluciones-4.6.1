Imports DevComponents.DotNetBar

Public Class Frm_Arbol_Asociacion_02

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Identificador_NodoPadre
    Dim _Row_Padre As DataRow

    Dim _Grabar As Boolean
    Dim _FullPath As String
    Dim _Descripcion_Busqueda As String
    Dim _Nodo_Raiz As Integer

    Dim _Tbl_Carpetas As DataTable
    Dim _Codigo_Heredado As String

    Dim _Clas_Unica_X_Producto As Boolean

    Dim _Correr_a_la_derecha As Boolean
    Dim _Top, _Left As Integer

    Dim _Fila_Seleccionada_DrapDorg As Integer

    Dim _Tbl_Tabla_De_Paso As String
    Dim _NroTblPaso As Integer

    Dim _Lista_Nodos As New List(Of Integer)

    Enum Enum_Clasificacion
        Unica
        Dinamica
    End Enum

    Dim _Clasificacion As Enum_Clasificacion

    Public Property Pro_Top() As Integer
        Get
            Return Me.Top
        End Get
        Set(value As Integer)
            _Top = value
        End Set
    End Property
    Public Property Pro_Left() As Integer
        Get
            Return Me.Left
        End Get
        Set(value As Integer)
            _Left = value
        End Set
    End Property
    Public Property Pro_Identificador_NodoPadre() As Integer
        Get
            Return _Identificador_NodoPadre
        End Get
        Set(value As Integer)
            _Identificador_NodoPadre = value
            _Lista_Nodos.Add(value)
        End Set
    End Property
    Public Property Pro_Grabar() As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property
    Public Property Pro_FullPath() As String
        Get
            Return _FullPath
        End Get
        Set(value As String)
            _FullPath = value
        End Set
    End Property
    Public Property Pro_Descripcion_Busqueda() As String
        Get
            Return _Descripcion_Busqueda
        End Get
        Set(value As String)
            _Descripcion_Busqueda = value
        End Set
    End Property
    Public Property Pro_Clas_Unica_X_Producto() As Boolean
        Get
            Return _Clas_Unica_X_Producto
        End Get
        Set(value As Boolean)
            _Clas_Unica_X_Producto = value
        End Set
    End Property
    Public Property Pro_Codigo_Heredado() As String
        Get
            Return _Codigo_Heredado
        End Get
        Set(value As String)
            _Codigo_Heredado = value
        End Set
    End Property
    Public Property Pro_Row_Padre() As DataRow
        Get
            Return _Row_Padre
        End Get
        Set(value As DataRow)
            _Row_Padre = value
        End Set
    End Property
    Public Property Pro_Lista_Nodos() As List(Of Integer)
        Get
            Return _Lista_Nodos
        End Get
        Set(value As List(Of Integer))
            _Lista_Nodos = value
        End Set
    End Property

    Public Sub New(Correr_a_la_derecha As Boolean,
                   Nodo_Raiz As Integer,
                   Modo_Editar As Boolean, Clasificacion As Enum_Clasificacion,
                   NroTblPaso As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()


        _NroTblPaso = NroTblPaso
        Sb_Crear_Tabla_De_Paso()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        _Correr_a_la_derecha = Correr_a_la_derecha
        _Nodo_Raiz = Nodo_Raiz

        _Clasificacion = Clasificacion

        Switch_Modo_Edicion.Value = Modo_Editar
        'Grilla.AllowUserToAddRows = Modo_Editar

        Btn_BuscarClasificacion.Visible = False
        Btn_Ver_Arbol.Visible = False
        Btn_Exportar_Excel.Visible = False

        If Not Modo_Editar Then

            '        Else
            If _Clasificacion = Enum_Clasificacion.Dinamica Then
                Btn_BuscarClasificacion.Visible = True
                Btn_Ver_Arbol.Visible = True
            End If
            Btn_Exportar_Excel.Visible = True
        End If


        Btn_Grabar.Visible = Modo_Editar
        Btn_Importar_Asociaciones_Desde_Excel.Visible = Modo_Editar
        Btn_Agregar_Nueva_Carpeta.Enabled = Modo_Editar

        If Global_Thema = Enum_Themas.Oscuro Then

            Txt_DescripcionBusqueda.FocusHighlightEnabled = False
            TxtFullPath.ForeColor = Color.Black

            Btn_Ver_Arbol.ForeColor = Color.White
            Btn_BuscarClasificacion.ForeColor = Color.White

        End If

    End Sub

    Sub Sb_Crear_Tabla_De_Paso()

        _Tbl_Tabla_De_Paso = _Global_BaseBk & "ZZPaso_" & FUNCIONARIO & _NroTblPaso
        _Sql.Sb_Eliminar_Tabla_De_Paso(_Tbl_Tabla_De_Paso)

        Consulta_sql = "CREATE TABLE " & _Tbl_Tabla_De_Paso & " (" & vbCrLf &
                       "[Id] [int] IDENTITY(1,1) NOT NULL," & vbCrLf &
                       "[Nuevo_Item] [bit] Default(1)," & vbCrLf &
                       "[Editado] [bit] Default(0)," & vbCrLf &
                       "[Eliminado] [bit] Default(0)," & vbCrLf &
                       "[Ult_Item] [bit] Default(0)," & vbCrLf &
                       "[Codigo_Nodo] [varchar](13) Default('')," & vbCrLf &
                       "[Identificador_Nodo] [int] Default(0)," & vbCrLf &
                       "[Identificacdor_NodoPadre] [int] Default(0)," & vbCrLf &
                       "[Codigo_Madre] [varchar](20) Default('')," & vbCrLf &
                       "[Descripcion] [varchar](500) Default('')," & vbCrLf &
                       "[Prod_Ass] [int] Default(0)," & vbCrLf &
                       "[Es_Seleccionable] [bit] Default(0)," & vbCrLf &
                       "[Clas_Unica_X_Producto] [bit] Default(0)," & vbCrLf &
                       "[Nodo_Raiz] [int] Default(0)" & vbCrLf &
                       ") ON [PRIMARY]"
        _Sql.Ej_consulta_IDU(Consulta_sql)

    End Sub

    Private Sub Frm_Arbol_Asociacion_02_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        _Sql.Sb_Eliminar_Tabla_De_Paso(_Tbl_Tabla_De_Paso)
    End Sub

    Private Sub Frm_Arbol_Asociacion_02_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                       "Where Codigo_Nodo = " & _Identificador_NodoPadre
        _Row_Padre = _Sql.Fx_Get_DataRow(Consulta_sql)

        'If (_Row_Padre Is Nothing) Then
        '_Lista_Nodos.Add(0)
        'End If

        If _Correr_a_la_derecha Then
            Me.Top = _Top + 10
            Me.Left = _Left + 10
        End If

        TxtFullPath.Text = _FullPath & " [" & _Identificador_NodoPadre & "]"

        'InsertarBotonenGrilla(Grilla, "BtnImagen", "Tipo", "Tipo", 0, _Tipo_Boton.Imagen)
        Sb_Actualizar_Grilla(Switch_Modo_Edicion.Value)

        'Actualizar Nodo_Raiz

        Consulta_sql = String.Empty
        If _Tbl_Carpetas.Rows.Count < 100 Then
            For Each _Fila As DataRow In _Tbl_Carpetas.Rows

                Dim _Nodo_Raiz_Carpeta As Integer = _Fila.Item("Nodo_Raiz")
                Dim _Codigo_Nodo As Integer = _Fila.Item("Codigo_Nodo")

                'If _Nodo_Raiz <> _Nodo_Raiz_Carpeta Then
                Consulta_sql += "Update " & _Global_BaseBk & "Zw_TblArbol_Asociaciones set Nodo_Raiz = " & _Nodo_Raiz & Space(1) &
                               "Where Codigo_Nodo = " & _Codigo_Nodo & vbCrLf
                'End If
            Next
            If Not String.IsNullOrEmpty(Consulta_sql) Then
                _Sql.Ej_consulta_IDU(Consulta_sql)
            End If
        End If

        With Grilla
            If CBool(.RowCount) Then
                .FirstDisplayedScrollingRowIndex = .RowCount - 1
                .CurrentCell = .Rows(.RowCount - 1).Cells("Descripcion")
            End If
        End With

        If Not String.IsNullOrEmpty(_Descripcion_Busqueda) Then
            If Not String.IsNullOrEmpty(Trim(_Descripcion_Busqueda)) Then
                If BuscarDatoEnGrilla(Trim(_Descripcion_Busqueda), "Descripcion", Grilla) = True Then
                    'CodigoSeleccionado = Codigo_abuscar
                    Grilla.Focus()
                End If
            End If
        End If

        TxtFullPath.BackColor = Color.Gold
        TxtFullPath.ForeColor = Color.Black

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Switch_Modo_Edicion.ValueChanged, AddressOf Sb_Switch_Modo_Edicion_ValueChanged
        ' AddHandler Grilla.CellMouseUp, AddressOf Sb_Grilla_CellMouseUp

        If _Clas_Unica_X_Producto Then
            Btn_BuscarClasificacion.Visible = False
            Btn_Ver_Arbol.Visible = False
        End If

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        If _Clasificacion = Enum_Clasificacion.Unica Then
            If CBool(_Nodo_Raiz) Then
                Btn_Carpeta_Padrel_Ver_Productos_Asociados.Visible = True
                Btn_Carpeta_Padre_Ver_Productos_Sin_Asociacion.Visible = True
            End If
        End If

    End Sub

    Sub Sb_Actualizar_Grilla(_Modo_Edicion As Boolean)

        Try

            Me.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            Dim _Class As Integer
            'las_Unica_X_Producto
            Select Case _Clasificacion
                Case Enum_Clasificacion.Dinamica
                    _Class = 0
                Case Enum_Clasificacion.Unica
                    _Class = 1
            End Select

            If Not _Modo_Edicion Then 'Not Switch_Modo_Edicion.Value Then

                Consulta_sql = "Truncate Table " & _Tbl_Tabla_De_Paso & vbCrLf &
                               "Insert Into " & _Tbl_Tabla_De_Paso & vbCrLf &
                               "Select Cast(0 As Bit) as Nuevo_Item,Cast(0 As Bit) as Editado,Cast(0 As Bit) as Eliminado," &
                               "Cast(0 As Bit) as Ult_Item,Codigo_Nodo," &
                               "Identificador_Nodo,Identificacdor_NodoPadre,Codigo_Madre,Descripcion," & vbCrLf &
                               "(Select COUNT(*) From " & _Global_BaseBk & "Zw_Prod_Asociacion Z1" & vbCrLf &
                               "Where Z1.Codigo_Nodo = Z2.Codigo_Nodo And Para_filtro = 1) as Prod_Ass," & vbCrLf &
                               "Es_Seleccionable,Clas_Unica_X_Producto,Nodo_Raiz" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Z2" & vbCrLf &
                               "Where 1> 0" & vbCrLf &
                               "And Identificacdor_NodoPadre = " & _Identificador_NodoPadre & vbCrLf &
                               "And Clas_Unica_X_Producto = " & _Class & vbCrLf &
                               "And Es_Ubicacion = 0" & vbCrLf &
                               "Order by Codigo_Nodo"
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

            Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(Txt_DescripcionBusqueda.Text), "Codigo_Nodo+Descripcion+Codigo_Madre Like '%")

            Consulta_sql = "Select * From " & _Tbl_Tabla_De_Paso & vbCrLf &
                           "Where Codigo_Nodo+Descripcion+Codigo_Madre Like '%" & _Cadena & "%'"
            _Tbl_Carpetas = _Sql.Fx_Get_DataTable(Consulta_sql)


            Dim _ReadOnly As Boolean

            If Switch_Modo_Edicion.Value Then
                _ReadOnly = False
            Else
                _ReadOnly = True
            End If

            With Grilla

                '.DataSource = Nothing
                .DataSource = _Tbl_Carpetas ' Datos_Arbol
                '.DataMember = Datos_Arbol.Tables("Arbol_Asociacion").TableName

                OcultarEncabezadoGrilla(Grilla)

                '.Columns("BtnImagen").Visible = True
                '.Columns("BtnImagen").HeaderText = "Tipo"
                '.Columns("BtnImagen").Width = 50

                Dim _Width_Desc = 620

                Dim _Clas_Unica_X_Producto = False
                Dim _Es_Seleccionable As Boolean = True

                If (_Row_Padre Is Nothing) Then
                    _Es_Seleccionable = False
                Else
                    _Clas_Unica_X_Producto = _Row_Padre.Item("Clas_Unica_X_Producto")
                    If _Clas_Unica_X_Producto Then _Width_Desc = 500
                End If

                .Columns("Codigo_Madre").Width = 110
                .Columns("Codigo_Madre").HeaderText = "Código"
                .Columns("Codigo_Madre").Visible = _Clas_Unica_X_Producto
                .Columns("Codigo_Madre").DisplayIndex = 1

                .Columns("Descripcion").Width = _Width_Desc
                .Columns("Descripcion").HeaderText = "Nombre de asociación"
                .Columns("Descripcion").Visible = True
                .Columns("Descripcion").DisplayIndex = 2
                '.Columns("Descripcion").ReadOnly = _ReadOnly

                '.Columns("Es_Padre").Width = 100
                '.Columns("Es_Padre").HeaderText = "¿Es Padre?"
                '.Columns("Es_Padre").ReadOnly = True
                '.Columns("Es_Padre").Visible = True
                '.Columns("Es_Padre").DisplayIndex = 1


                .Columns("Es_Seleccionable").HeaderText = "¿Sel.?"
                .Columns("Es_Seleccionable").Width = 40
                .Columns("Es_Seleccionable").ReadOnly = True ' _ReadOnly
                .Columns("Es_Seleccionable").Visible = _Es_Seleccionable
                .Columns("Es_Seleccionable").DisplayIndex = 3

                .Columns("Prod_Ass").Width = 40
                .Columns("Prod_Ass").HeaderText = "Prod."
                .Columns("Prod_Ass").Visible = True
                .Columns("Prod_Ass").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Prod_Ass").ReadOnly = True
                .Columns("Prod_Ass").DisplayIndex = 4

            End With


            Mnu_Btn_Eliminar_Clasificacion.Visible = Switch_Modo_Edicion.Value

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message)
        Finally
            Me.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
        Me.Refresh()


    End Sub

    Sub Sb_Marcar_Fila(_Fila As DataGridViewRow)

        Dim _Es_Seleccionable As Boolean = _Fila.Cells("Es_Seleccionable").Value
        Dim _Prod_Ass As Boolean = CBool(_Fila.Cells("Prod_Ass").Value)
        Dim _Nodo_Raiz = _Fila.Cells("Nodo_Raiz").Value
        Dim _Clas_Unica_X_Producto = _Fila.Cells("Clas_Unica_X_Producto").Value
        Dim _Nuevo_Item = _Fila.Cells("Nuevo_Item").Value


        If _Nuevo_Item Is Nothing Then
            _Fila.Cells("BtnImagen").Value = Imagenes.Images.Item("folder-new.png")
        Else
            If _Nodo_Raiz Is DBNull.Value Then
                _Fila.Cells("BtnImagen").Value = Imagenes.Images.Item("folder_open-error.png")
            Else
                If _Nodo_Raiz <> 0 Then
                    If _Es_Seleccionable Then
                        _Fila.Cells("BtnImagen").Value = Imagenes.Images.Item("folder_open-add.png")
                    Else
                        _Fila.Cells("BtnImagen").Value = Imagenes.Images.Item("folder.png")
                    End If
                Else
                    If _Es_Seleccionable Then
                        _Fila.Cells("BtnImagen").Value = Imagenes.Images.Item("folder_open-add.png")
                    Else
                        If _Clas_Unica_X_Producto Then
                            _Fila.Cells("BtnImagen").Value = Imagenes.Images.Item("folder_open-error.png")
                        Else
                            _Fila.Cells("BtnImagen").Value = Imagenes.Images.Item("folder.png") '("folder_open-bookmark.png")
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        If Switch_Modo_Edicion.Value Then
            Sb_Salir()
        Else
            Me.Close()
        End If
    End Sub


    Sub Sb_Salir()

        Dim _Modificado As Boolean '= _Global_Fx_Cambio_en_la_Grilla(_Tbl_Carpetas)

        Dim _Registros_Nuevos As Integer = _Sql.Fx_Cuenta_Registros(_Tbl_Tabla_De_Paso, "Nuevo_Item = 1")
        Dim _Registros_Editados As Integer = _Sql.Fx_Cuenta_Registros(_Tbl_Tabla_De_Paso, "Editado = 1")
        Dim _Registros_Eliminados As Integer = _Sql.Fx_Cuenta_Registros(_Tbl_Tabla_De_Paso, "Eliminado = 1")

        _Modificado = CBool(_Registros_Editados + _Registros_Eliminados + _Registros_Nuevos)

        If _Modificado Then

            Dim _Accion = MessageBoxEx.Show(Me, "¿Desea guardar los cambios?", "Salir",
                                 MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            If _Accion = Windows.Forms.DialogResult.Yes Then
                _Grabar = Fx_Grabar()
            ElseIf _Accion = Windows.Forms.DialogResult.Cancel Then
                Return
            ElseIf _Accion = Windows.Forms.DialogResult.No Then
                _Grabar = False
            End If
        Else
            _Grabar = False
        End If

        Me.Close()
    End Sub


    Public Sub Sb_Insertar_nueva_linea(_Clas_Unica_X_Producto As Boolean,
                                       Optional _Descripcion As String = "")


        Dim _Es_Seleccionable As Boolean

        If Not (_Row_Padre Is Nothing) Then
            If _Clas_Unica_X_Producto Then
                _Es_Seleccionable = True
            End If
        End If

        Consulta_sql = "Insert Into " & _Tbl_Tabla_De_Paso & " (Nuevo_Item,Codigo_Nodo,Identificacdor_NodoPadre,Descripcion,Es_Seleccionable," &
                       "Prod_Ass,Clas_Unica_X_Producto,Nodo_Raiz) Values " &
                       "(1,0," & _Identificador_NodoPadre & ",'" & _Descripcion & "'," & CBool(_Es_Seleccionable) * -1 &
                       ",0," & CInt(_Clas_Unica_X_Producto) * -1 &
                       "," & _Nodo_Raiz & ")"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Dim _Id As Integer = _Sql.Fx_Trae_Dato(_Tbl_Tabla_De_Paso, "Max(Id)")

        Grilla.Refresh()

        Dim NewFila As DataRow
        NewFila = _Tbl_Carpetas.NewRow

        With NewFila
            .Item("Id") = _Id
            .Item("Nuevo_Item") = True
            .Item("Descripcion") = _Descripcion
            .Item("Es_Seleccionable") = CBool(_Es_Seleccionable) * -1
            .Item("Prod_Ass") = 0
            .Item("Clas_Unica_X_Producto") = _Clas_Unica_X_Producto
            .Item("Nodo_Raiz") = _Nodo_Raiz
        End With

        _Tbl_Carpetas.Rows.Add(NewFila)

    End Sub

    Private Sub Frm_Arbol_Asociacion_02_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Try
            Dim tecla = e.KeyCode

            If e.KeyValue = Keys.Down Then 'Or e.KeyValue = Keys.Up Then
                Dim _Fila As Integer = Grilla.CurrentCellAddress.Y
                Sub_Agregar_Nueva_Carpeta(_Fila)
            ElseIf e.KeyValue = Keys.Escape Then
                If Switch_Modo_Edicion.Value Then
                    Sb_Salir()
                Else
                    Me.Close()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub Sub_Agregar_Nueva_Carpeta(_Fila As Integer)

        If Switch_Modo_Edicion.Value Then

            With Grilla

                If CBool(.Rows.Count) Then

                    Dim _Nuevo_Item As Boolean = .Rows(_Fila).Cells("Nuevo_Item").Value
                    Dim _Descripcion As String = .Rows(_Fila).Cells("Descripcion").Value

                    Dim _Filas As Integer = .Rows.Count - 1
                    _Descripcion = Replace(_Descripcion, ".", "")

                    If Not String.IsNullOrEmpty(_Descripcion) Then

                        If _Filas = _Fila Then

                            If _Identificador_NodoPadre = 0 Then
                                If Not Fx_Insertar_Clas_Unica() Then Return
                            Else
                                Sb_Insertar_nueva_linea(_Clas_Unica_X_Producto)
                            End If

                            .CurrentCell = .Rows(_Fila + 1).Cells("Descripcion") '.Rows(.CurrentRow.Index).Cells("Codigo")

                        ElseIf _Fila + 1 = .Rows.Count - 1 And _Nuevo_Item Then

                            .CurrentCell = .Rows(_Filas).Cells("Descripcion")

                        End If

                    End If

                Else

                    If _Identificador_NodoPadre = 0 Then

                        If Fx_Insertar_Clas_Unica() Then
                            .CurrentCell = .Rows(_Fila + 1).Cells("Descripcion") '.Rows(.CurrentRow.Index).Cells("Codigo")
                        End If

                    Else

                        Sb_Insertar_nueva_linea(_Clas_Unica_X_Producto)
                        .CurrentCell = .Rows(_Fila + 1).Cells("Descripcion") '.Rows(.CurrentRow.Index).Cells("Codigo")

                    End If

                End If

            End With

        End If

    End Sub

    Function Fx_Insertar_Clas_Unica() As Boolean

        Dim Fm As New Frm_Arbol_Asociacion_05_Crear_Nueva_Raiz

        If _Clasificacion = Enum_Clasificacion.Unica Then
            Fm.Pro_Clas_Unica_X_Producto = True
        ElseIf _Clasificacion = Enum_Clasificacion.Dinamica Then
            Fm.Pro_Clas_Unica_X_Producto = False
        End If

        Fm.Pro_Es_Posible_Cambiar_Clas_Unicas = False

        Fm.ShowDialog(Me)
        Dim _Aceptar = Fm.Pro_Aceptar
        If _Aceptar Then
            Sb_Insertar_nueva_linea(Fm.Pro_Clas_Unica_X_Producto,
                                    Fm.Txt_Descripcion.Text)
        End If
        Fm.Dispose()

        Return _Aceptar


    End Function


    Sub Sb_Agregar_SubClasificaciones()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id = _Fila.Cells("Id").Value
        Dim _Nuevo_Item As Boolean = _Fila.Cells("Nuevo_Item").Value
        Dim _Identificacdor_NodoPadre = _Fila.Cells("Identificacdor_NodoPadre").Value
        Dim _Es_Seleccionable As Boolean = _Fila.Cells("Es_Seleccionable").Value
        Dim _Codigo_Nodo As String = _Fila.Cells("Codigo_Nodo").Value
        Dim _Descripcion As String = _Fila.Cells("Descripcion").Value
        Dim _Clas_Unica_X_Producto_ As Boolean = _Fila.Cells("Clas_Unica_X_Producto").Value

        Dim _Raiz As Integer

        If CBool(_Identificacdor_NodoPadre) Then
            _Raiz = _Nodo_Raiz
        Else
            _Lista_Nodos.Clear()
            _Raiz = _Codigo_Nodo
        End If

        If Not _Es_Seleccionable Then

            Dim _IdPadre As Integer = _Fila.Cells("Codigo_Nodo").Value

            Dim Fm As New Frm_Arbol_Asociacion_02(True, _Raiz, Switch_Modo_Edicion.Value, _Clasificacion, _NroTblPaso + 1)
            'Fm.Pro_Row_Padre = _Row_Padre
            Fm.Pro_Codigo_Heredado = _Codigo_Heredado
            Fm.Pro_Top = Me.Top
            Fm.Pro_Left = Me.Left
            Fm.Pro_Clas_Unica_X_Producto = _Clas_Unica_X_Producto_
            Fm.Pro_Lista_Nodos = _Lista_Nodos
            Fm.Pro_Identificador_NodoPadre = _IdPadre
            Fm.BtnSalir.Image = My.Resources.RecursosBkSpecialPrograms.folder_open_arrow_left
            Fm.Text = "MANTENCION DE ASOCIACIONES DE PRODUCTOS: " & _Descripcion
            Fm._FullPath = _FullPath & "\" & _Descripcion
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Dim _Prod_Ass As Double = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Asociacion",
                                                                 "Codigo_Nodo = " & _Codigo_Nodo)

            _Fila.Cells("Prod_Ass").Value = _Prod_Ass

            Consulta_sql = "Update " & _Tbl_Tabla_De_Paso & " Set Prod_Ass = " & De_Num_a_Tx_01(_Fila.Cells("Prod_Ass").Value, False, 5) & vbCrLf &
                           "Where Id = " & _Id
            _Sql.Ej_consulta_IDU(Consulta_sql)

        Else

            MessageBoxEx.Show(Me, "¡ESTA CLASIFICACION NO PERMITE INCORPORAR SUB-CLASIFICACIONES!" & vbCrLf &
                                 "DEBE MARCAR LA CLASIFICACION COMO PADRE PARA PODER REALIZAR ESTA GESTION",
                                 "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub BtnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Grabar.Click

        Dim _Registros_Nuevos As Integer
        Dim _Registros_Editados As Integer
        Dim _Registros_Eliminados As Integer

        _Grabar = Fx_Grabar(_Registros_Nuevos, _Registros_Editados, _Registros_Eliminados)

        If _Grabar Then

            MessageBoxEx.Show(Me, "DATOS GUARDADOS CORRECTAMENTE", "Grabar",
                                MessageBoxButtons.OK, MessageBoxIcon.Question)

            Switch_Modo_Edicion.Value = False
            _Grabar = False

            If CBool(_Registros_Nuevos) Then

                Sb_Actualizar_Grilla(Switch_Modo_Edicion.Value)

                If CBool(Grilla.RowCount) Then

                    Grilla.FirstDisplayedScrollingRowIndex = Grilla.RowCount - 1
                    Grilla.CurrentCell = Grilla.Rows(Grilla.RowCount - 1).Cells("Descripcion")

                End If

            End If

        End If

    End Sub

    Function Fx_Grabar_Old() As Boolean

        Dim _Grabacion As Boolean

        Dim _Sql_Query_Grabar As String = String.Empty

        If False Then
            For Each _Fila As DataRow In _Tbl_Carpetas.Rows ' _Tbl.Rows

                'Codigo_Nodo,Identificador_Nodo,Identificacdor_NodoPadre,Descripcion"
                Dim Estado As DataRowState = _Fila.RowState

                If Estado <> DataRowState.Deleted Then

                    Dim _Codigo_Nodo As String = NuloPorNro(_Fila.Item("Codigo_Nodo"), "")
                    Dim _Codigo_Madre As String = NuloPorNro(_Fila.Item("Codigo_Madre"), "")
                    Dim _Descripcion As String = _Fila.Item("Descripcion")
                    Dim _Nuevo_Item As Boolean = _Fila.Item("Nuevo_Item")
                    Dim _Es_Padre As Boolean = NuloPorNro(_Fila.Item("Es_Padre"), False)
                    Dim _Es_Seleccionable As Boolean = NuloPorNro(_Fila.Item("Es_Seleccionable"), False)
                    Dim _Clas_Unica_X_Producto As Boolean = _Fila.Item("Clas_Unica_X_Producto")
                    'Dim _Codigo_Madre_Obligatorio As Boolean = _Fila.Item("Clas_Unica_X_Producto")

                    'Dim _Cod_Ubicacion = String.Empty
                    'If _Es_Seleccionable Then _Cod_Ubicacion = _Fila.Item("Cod_Ubicacion")

                    If _Es_Seleccionable Then _Es_Padre = False

                    If Not _Nuevo_Item And String.IsNullOrEmpty(Trim(_Descripcion)) Then
                        MessageBoxEx.Show(Me, "No puede guardar asociaciones sin descripción",
                                          "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    End If

                    If Not _Es_Seleccionable Then _Es_Padre = True

                    _Sql_Query_Grabar += "Insert Into " & _Global_BaseBk & "Zw_TblArbol_Asociaciones " &
                                         "(Codigo_Nodo,Identificacdor_NodoPadre,Descripcion,Es_Padre,Es_Seleccionable," &
                                         "Es_Ubicacion,Clas_Unica_X_Producto,Nodo_Raiz,Codigo_Madre) Values " & vbCrLf &
                                         "('" & _Codigo_Nodo & "'," & _Identificador_NodoPadre & ",'" &
                                         UCase(Trim(_Descripcion)) & "'," & CInt(_Es_Padre) * -1 &
                                         "," & CInt(_Es_Seleccionable) * -1 & ",0," &
                                         CInt(_Clas_Unica_X_Producto) * -1 & "," & _Nodo_Raiz & ",'" & _Codigo_Madre & "')" & vbCrLf
                    ' ",'" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "')" & vbCrLf
                End If
            Next

        End If


        Dim _Registros_En_Blanco As Integer = _Sql.Fx_Cuenta_Registros(_Tbl_Tabla_De_Paso, "Descripcion = '' And Eliminado = 0")

        If CBool(_Registros_En_Blanco) Then
            MessageBoxEx.Show(Me, "No se pueden grabar registros con descripción en blanco", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        Else

            Dim _Registros_Nuevos As Integer = _Sql.Fx_Cuenta_Registros(_Tbl_Tabla_De_Paso, "Nuevo_Item = 1")
            Dim _Registros_Editados As Integer = _Sql.Fx_Cuenta_Registros(_Tbl_Tabla_De_Paso, "Editado = 1")
            Dim _Registros_Eliminados As Integer = _Sql.Fx_Cuenta_Registros(_Tbl_Tabla_De_Paso, "Eliminado = 1")

            If CBool(_Registros_Eliminados) Then
                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                               "Where Codigo_Nodo In (Select Codigo_Nodo From " & _Tbl_Tabla_De_Paso & " Where Eliminado = 1)"
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    Consulta_sql = "Delete " & _Tbl_Tabla_De_Paso & " Where Eliminado = 1"
                    _Sql.Ej_consulta_IDU(Consulta_sql)
                End If
            End If

            If CBool(_Registros_Nuevos) Then
                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TblArbol_Asociaciones " &
                               "(Codigo_Nodo,Identificacdor_NodoPadre,Descripcion,Es_Seleccionable," &
                               "Es_Ubicacion,Clas_Unica_X_Producto,Nodo_Raiz,Codigo_Madre)" & vbCrLf &
                               "Select Codigo_Nodo,Identificacdor_NodoPadre,Descripcion,Es_Seleccionable," &
                               "0,Clas_Unica_X_Producto,Nodo_Raiz,Codigo_Madre" & vbCrLf &
                               "From " & _Tbl_Tabla_De_Paso & vbCrLf &
                               "Where Nuevo_Item = 1"
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Set Codigo_Nodo = Identificador_Nodo" & vbCrLf &
                                   "Where Codigo_Nodo = 0" & vbCrLf &
                                   "Update " & _Tbl_Tabla_De_Paso & " Set Nuevo_Item = 0"
                    _Sql.Ej_consulta_IDU(Consulta_sql)
                End If

            End If

            If CBool(_Registros_Editados) Then
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Set" & Space(1) & "--Select Z2.*" & vbCrLf &
                               "Codigo_Madre = Z2.Codigo_Madre," & vbCrLf &
                               "Descripcion = Z2.Descripcion," & vbCrLf &
                               "Identificacdor_NodoPadre = Z2.Identificacdor_NodoPadre," & vbCrLf &
                               "Es_Seleccionable = Z2.Es_Seleccionable" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Z1 INNER JOIN" & vbCrLf &
                               _Tbl_Tabla_De_Paso & " Z2 ON Z1.Codigo_Nodo = Z2.Codigo_Nodo" & vbCrLf &
                               "Where Z2.Editado = 1"
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Asociacion Set " & _Global_BaseBk & "Zw_Prod_Asociacion.DescripcionBusqueda = " & vbCrLf &
                                   _Global_BaseBk & "Zw_TblArbol_Asociaciones.Descripcion" & vbCrLf &
                                   "FROM " & _Global_BaseBk & "Zw_Prod_Asociacion  LEFT OUTER JOIN" & vbCrLf &
                                   _Global_BaseBk & "Zw_TblArbol_Asociaciones ON " & _Global_BaseBk & "Zw_Prod_Asociacion.Codigo_Nodo = " & _Global_BaseBk & "Zw_TblArbol_Asociaciones.Codigo_Nodo" & vbCrLf &
                                   "WHERE (" & _Global_BaseBk & "Zw_TblArbol_Asociaciones.Identificacdor_NodoPadre = " & _Identificador_NodoPadre & ")"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    Consulta_sql = "Update " & _Tbl_Tabla_De_Paso & " Set Editado = 0"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

            End If

        End If

        Return True

    End Function

    Function Fx_Grabar(Optional ByRef _Registros_Nuevos As Integer = 0,
                       Optional ByRef _Registros_Editados As Integer = 0,
                       Optional ByRef _Registros_Eliminados As Integer = 0) As Boolean

        Dim _Registros_En_Blanco As Integer = _Sql.Fx_Cuenta_Registros(_Tbl_Tabla_De_Paso, "Descripcion = '' And Eliminado = 0")

        If CBool(_Registros_En_Blanco) Then
            MessageBoxEx.Show(Me, "No se pueden grabar registros con descripción en blanco", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        Else

            _Registros_Nuevos = _Sql.Fx_Cuenta_Registros(_Tbl_Tabla_De_Paso, "Nuevo_Item = 1")
            _Registros_Editados = _Sql.Fx_Cuenta_Registros(_Tbl_Tabla_De_Paso, "Editado = 1")
            _Registros_Eliminados = _Sql.Fx_Cuenta_Registros(_Tbl_Tabla_De_Paso, "Eliminado = 1")

            If CBool(_Registros_Eliminados) Then
                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                               "Where Codigo_Nodo In (Select Codigo_Nodo From " & _Tbl_Tabla_De_Paso & " Where Eliminado = 1)"
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    Consulta_sql = "Delete " & _Tbl_Tabla_De_Paso & " Where Eliminado = 1"
                    _Sql.Ej_consulta_IDU(Consulta_sql)
                End If
            End If

            If CBool(_Registros_Nuevos) Then
                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TblArbol_Asociaciones " &
                               "(Codigo_Nodo,Identificacdor_NodoPadre,Descripcion,Es_Seleccionable," &
                               "Es_Ubicacion,Clas_Unica_X_Producto,Nodo_Raiz,Codigo_Madre)" & vbCrLf &
                               "Select Codigo_Nodo,Identificacdor_NodoPadre,Descripcion,Es_Seleccionable," &
                               "0,Clas_Unica_X_Producto,Nodo_Raiz,Codigo_Madre" & vbCrLf &
                               "From " & _Tbl_Tabla_De_Paso & vbCrLf &
                               "Where Nuevo_Item = 1"
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Set Codigo_Nodo = Identificador_Nodo" & vbCrLf &
                                   "Where Codigo_Nodo = 0" & vbCrLf &
                                   "Update " & _Tbl_Tabla_De_Paso & " Set Nuevo_Item = 0"
                    _Sql.Ej_consulta_IDU(Consulta_sql)
                End If

            End If

            If CBool(_Registros_Editados) Then
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Set" & Space(1) & "--Select Z2.*" & vbCrLf &
                               "Codigo_Madre = Z2.Codigo_Madre," & vbCrLf &
                               "Descripcion = Z2.Descripcion," & vbCrLf &
                               "Identificacdor_NodoPadre = Z2.Identificacdor_NodoPadre," & vbCrLf &
                               "Es_Seleccionable = Z2.Es_Seleccionable" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Z1 INNER JOIN" & vbCrLf &
                               _Tbl_Tabla_De_Paso & " Z2 ON Z1.Codigo_Nodo = Z2.Codigo_Nodo" & vbCrLf &
                               "Where Z2.Editado = 1"
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Asociacion Set " & _Global_BaseBk & "Zw_Prod_Asociacion.DescripcionBusqueda = " & vbCrLf &
                                   _Global_BaseBk & "Zw_TblArbol_Asociaciones.Descripcion" & vbCrLf &
                                   "FROM " & _Global_BaseBk & "Zw_Prod_Asociacion  LEFT OUTER JOIN" & vbCrLf &
                                   _Global_BaseBk & "Zw_TblArbol_Asociaciones ON " & _Global_BaseBk & "Zw_Prod_Asociacion.Codigo_Nodo = " & _Global_BaseBk & "Zw_TblArbol_Asociaciones.Codigo_Nodo" & vbCrLf &
                                   "WHERE (" & _Global_BaseBk & "Zw_TblArbol_Asociaciones.Identificacdor_NodoPadre = " & _Identificador_NodoPadre & ")"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    Consulta_sql = "Update " & _Tbl_Tabla_De_Paso & " Set Editado = 0"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

            End If

        End If

        Return True

    End Function

    Sub Sb_Eliminar_Clasificacion()

        Dim _Pregunta_Elimina As Boolean = True

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id As Integer = _Fila.Cells("Id").Value
        'Dim _Es_Padre = _Fila.Cells("Es_Padre").Value
        Dim _Es_Seleccionable = _Fila.Cells("Es_Seleccionable").Value
        Dim _Codigo_Nodo = _Fila.Cells("Codigo_Nodo").Value
        Dim _Identificacdor_NodoPadre = _Fila.Cells("Descripcion").Value
        Dim _Reg As Integer
        Dim _Nuevo_Item = _Fila.Cells("Nuevo_Item").Value
        Dim _Prod_Ass = _Fila.Cells("Prod_Ass").Value

        If _Nuevo_Item Then

            Consulta_sql = "Update " & _Tbl_Tabla_De_Paso & Space(1) & "Set" & Space(1) & "Eliminado = 1" & Space(1) & "Where Id = " & _Id
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
            If Not CBool(Grilla.Rows.Count) Then
                Sb_Insertar_nueva_linea(_Clas_Unica_X_Producto)
                'Grilla.Rows(Grilla.Rows.Count - 1).Cells("BtnImagen").Value = Imagenes.Images.Item("folder-new.png")
            End If
            Grilla.Focus()
            Return
        End If

        If Not CBool(_Prod_Ass) Then

            'If Fx_Tiene_Permiso(Me, "Tbl00006") Then
            If Not _Nuevo_Item Then

                If Not _Es_Seleccionable Then
                    _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_TblArbol_Asociaciones",
                                                "Identificacdor_NodoPadre = '" & _Codigo_Nodo & "'")

                    If CBool(_Reg) Then
                        MessageBoxEx.Show(Me, "Esta clasificación posee sub-clasificaciones" & vbCrLf &
                                          "Debe Eliminar las sub-carpetas primero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If
                End If
            End If


            Dim _Cta_ProdClasificados As Integer


            'If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar esta clasificación?", "Eliminar clasificación", _
            '                    MessageBoxButtons.YesNo, _
            '                    MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            'Return
            'End If

            Consulta_sql = "Update " & _Tbl_Tabla_De_Paso & Space(1) & "Set" & Space(1) & "Eliminado = 1" & Space(1) & "Where Id = " & _Id
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
            Grilla.Focus()

        Else
            MessageBoxEx.Show(Me, "Existen productos asociados a esta carpeta o alguna de sus dependencias" & vbCrLf &
                              "Quite los productos para poder hacer su gestión",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Function Fx_Tiene_Productos(_NodoPadre As String) As Boolean

        Consulta_sql = "Select Codigo_Nodo from " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Identificacdor_NodoPadre = " & _NodoPadre
        Dim _Tbl_Tree As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql) ' _SQL.Fx_Get_Tablas(Consulta_sql)
        Dim _Cta_ProdClasificados As Boolean
        Dim _Codigo_Nodo As Integer

        If CBool(_Tbl_Tree.Rows.Count) Then
            For Each _Fila As DataRow In _Tbl_Tree.Rows
                _Codigo_Nodo = _Fila.Item("Codigo_Nodo")
                If Fx_Tiene_Productos(_Codigo_Nodo) Then
                    Return True
                End If
            Next
        Else
            _Cta_ProdClasificados = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Asociacion", "Codigo_Nodo = '" & _NodoPadre & "'"))
            If _Cta_ProdClasificados Then
                Return True
            End If
        End If

        Return False

    End Function


    Private Sub Grilla_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEndEdit

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Id = _Fila.Cells("Id").Value
        Dim _Codigo_Nodo = _Fila.Cells("Codigo_Nodo").Value

        Dim _Codigo_Madre As String = NuloPorNro(_Fila.Cells("Codigo_Madre").Value, "")
        Dim _Descripcion As String = NuloPorNro(_Fila.Cells("Descripcion").Value, "")

        Dim _Prod_Ass = _Fila.Cells("Prod_Ass").Value
        Dim _Clas_Unica_X_Producto = _Fila.Cells("Clas_Unica_X_Producto").Value
        Dim _Nuevo_Item As Boolean = _Fila.Cells("Nuevo_Item").Value
        Dim _Editado As Boolean

        Dim _Es_Seleccionable As Boolean = _Fila.Cells("Es_Seleccionable").Value

        If Not _Nuevo_Item Then _Editado = True

        Consulta_sql = "Update " & _Tbl_Tabla_De_Paso & Space(1) &
                       "Set" & Space(1) &
                       "Editado = " & CInt(_Editado) * -1 & "," &
                       "Codigo_Madre = '" & _Codigo_Madre & "'," &
                       "Descripcion = '" & _Descripcion & "'," &
                       "Es_Seleccionable = " & CInt(_Es_Seleccionable) * -1 & Space(1) &
                       "Where Id = " & _Id
        _Sql.Ej_consulta_IDU(Consulta_sql)
        'Sb_Marcar_Fila(_Fila)

        Grilla.Columns("Descripcion").ReadOnly = True

        Dim _Indice As Integer = Grilla.CurrentRow.Index + 1
        Dim Filas As Integer = Grilla.Rows.Count


    End Sub

    Private Sub Grilla_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        'Dim _Es_Padre = _Fila.Cells("Es_Padre").Value
        Dim _Nuevo_Item As Boolean = _Fila.Cells("Nuevo_Item").Value

        If Not Fx_Rev_Class_Grabada(_Nuevo_Item) Then Return

        Dim _Identificacdor_NodoPadre = _Fila.Cells("Identificacdor_NodoPadre").Value
        Dim _Codigo_Nodo As Integer = _Fila.Cells("Codigo_Nodo").Value
        Dim _Descripcion As String = _Fila.Cells("Descripcion").Value
        Dim _Es_Seleccionable As Boolean = _Fila.Cells("Es_Seleccionable").Value
        Dim _Prod_Ass = _Fila.Cells("Prod_Ass").Value

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Select Case _Cabeza

            Case "Descripcion", "Codigo_Madre" ', "Es_Padre", "Es_Seleccionable"
                If Switch_Modo_Edicion.Value Then
                    If _Identificacdor_NodoPadre = 0 Then

                        Dim Fm As New Frm_Arbol_Asociacion_05_Crear_Nueva_Raiz
                        Fm.Pro_Clas_Unica_X_Producto = _Fila.Cells("Clas_Unica_X_Producto").Value
                        Fm.Pro_Descripcion = _Descripcion
                        If CBool(_Prod_Ass) Then Fm.Pro_Es_Posible_Cambiar_Clas_Unicas = False

                        Fm.ShowDialog(Me)
                        If Fm.Pro_Aceptar Then
                            'Sb_Insertar_nueva_linea(Fm.Pro_Clas_Unica_X_Producto, Fm.Txt_Descripcion.Text)
                            _Fila.Cells("Descripcion").Value = Fm.Txt_Descripcion.Text
                            _Fila.Cells("Clas_Unica_X_Producto").Value = Fm.Pro_Clas_Unica_X_Producto
                        End If

                        Fm.Dispose()
                    Else
                        Grilla.Columns("Descripcion").ReadOnly = False
                        Grilla.BeginEdit(True)
                    End If
                Else
                    If _Es_Seleccionable Then
                        Sb_VerProductos_X_Class_X_Fila(_Codigo_Nodo, _Descripcion, False)
                    Else
                        Sb_Agregar_SubClasificaciones()
                    End If
                End If
            Case "Prod_Ass"
                If Switch_Modo_Edicion.Value Then
                    MessageBoxEx.Show(Me, "Estas en modo edición de carpetas, no es posible ver los productos." & vbCrLf &
                                          "Debes desactivar EDITAR CARPETAS para poder hacer gestión", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Sb_VerProductos_X_Class_X_Fila(_Codigo_Nodo, _Descripcion, False)
                End If
            Case Else

        End Select

    End Sub

    Function Fx_Rev_Class_Grabada(_Nuevo_Item As Boolean)
        Dim _Class = True

        If _Nuevo_Item Then
            Beep()

            ToastNotification.Show(Me, "ESTA CLASIFICACION NO ESTA GRABADA EN LA BASE DE DATOS." & vbCrLf &
                                  "DEBE GRABAR PARA PODER INGRESAR SUB-CLASIFICACIONES AS ESTA CLASIFICACION",
                                  My.Resources.button_rounded_red_delete,
                                 6 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

            _Class = False

        End If

        Return _Class

    End Function

    Sub Sb_VerProductos_X_Class_X_Fila(_Codigo_Nodo As String,
                                       _Descripcion As String,
                                       Optional _Mostrar_Productos_Sin_Asociacion_En_Nodo As Boolean = False)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Identificador_NodoPadre As Integer = _Fila.Cells("Identificacdor_NodoPadre").Value
        Dim _Id = _Fila.Cells("Prod_Ass").Value
        Dim _Es_Seleccionable = _Fila.Cells("Es_Seleccionable").Value

        Dim Fm As New Frm_Arbol_Asociacion_04_Productos_x_class(_Identificador_NodoPadre,
                                                                _Codigo_Nodo,
                                                                _Descripcion,
                                                                _FullPath,
                                                                _Es_Seleccionable,
                                                                _Clas_Unica_X_Producto,
                                                                _Mostrar_Productos_Sin_Asociacion_En_Nodo)
        Fm.Pro_Codigo_Heredado = _Codigo_Heredado
        Fm.Text = "Clasificación: (Cod. " & _Codigo_Nodo & ") " & _Descripcion
        Fm.Pro_Lista_Nodos = _Lista_Nodos
        Fm.ShowDialog(Me)


        _Fila.Cells("Prod_Ass").Value = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Asociacion",
                                                                 "Codigo_Nodo = " & _Codigo_Nodo)

        If Fm.Pro_Grabar Then

            Consulta_sql = "Update " & _Tbl_Tabla_De_Paso & " Set Prod_Ass = " & De_Num_a_Tx_01(_Fila.Cells("Prod_Ass").Value, False, 5) & vbCrLf &
                           "Where Id = " & _Id
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

    End Sub

    Sub Sb_VerProductos_X_Class_X_Cartepa_Padre(_Mostrar_Productos_Sin_Asociacion_En_Nodo As Boolean)

        Dim _Codigo_Nodo As String = _Row_Padre.Item("Codigo_Nodo")
        Dim _Descripcion As String = _Row_Padre.Item("Descripcion")
        Dim _Identificador_NodoPadre As Integer = _Row_Padre.Item("Identificacdor_NodoPadre")
        Dim _Es_Seleccionable = _Row_Padre.Item("Es_Seleccionable")
        Dim _Nodo_Raiz As Integer = _Row_Padre.Item("Nodo_Raiz")

        Dim _Nodo As Integer

        If CBool(_Nodo_Raiz) Then
            _Nodo = _Nodo_Raiz
        Else
            _Nodo = _Identificador_NodoPadre
        End If

        Dim Fm As New Frm_Arbol_Asociacion_04_Productos_x_class(_Nodo,
                                                                _Codigo_Nodo,
                                                                _Descripcion,
                                                                _FullPath,
                                                                _Es_Seleccionable,
                                                                _Clas_Unica_X_Producto,
                                                                _Mostrar_Productos_Sin_Asociacion_En_Nodo)
        Fm.Pro_Codigo_Heredado = _Codigo_Heredado
        Fm.Text = "Clasificación: (Cod. " & _Codigo_Nodo & ") " & _Descripcion

        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub EsPadreToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Codigo_Nodo = _Fila.Cells("Codigo_Nodo").Value
        Dim _Prod_Ass = _Fila.Cells("Prod_Ass").Value
        Dim _Clas_Unica_X_Producto = _Fila.Cells("Clas_Unica_X_Producto").Value
        Dim _Es_Padre = _Fila.Cells("Es_Padre").Value

        If Not CBool(_Prod_Ass) Then

            If Fx_Tiene_Permiso(Me, "Tbl00003") Then

                'Dim _Identificacdor_NodoPadre = .Rows(.CurrentRow.Index).Cells("Descripcion").Value
                Dim _Reg As Integer

                If _Es_Padre Then

                    If (_Codigo_Nodo Is Nothing) Then
                        _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_TblArbol_Asociaciones",
                                                "Identificacdor_NodoPadre = '" & _Codigo_Nodo & "'")
                    Else
                        _Reg = 0
                    End If

                    If CBool(_Reg) Then
                        MessageBoxEx.Show(Me, "Esta clasificación posee sub-clasificaciones" & vbCrLf &
                                            "No se puede quitar el ticket, debe eliminar los hijos para poder realizar esta acción",
                                            "Eliminar clasificaciones",
                                            MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        _Fila.Cells("Es_Padre").Value = False
                        _Fila.Cells("Es_Seleccionable").Value = True
                    End If
                Else
                    _Fila.Cells("Es_Padre").Value = True
                    _Fila.Cells("Es_Seleccionable").Value = False
                End If

            End If

        Else
            MessageBoxEx.Show(Me, "No se puede cambiar el tipo de carpeta, ya que existen productos asociados a esta",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Sub

    Private Sub BtnImportarAsociaciones_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Importar_Asociaciones_Desde_Excel.Click

        Try

            MessageBoxEx.Show(Me, "El archivo Excel debe tener 3 columnas:" & vbCrLf &
                                  "Columna A = Codigo asociación (Máx. 20 Caracteres)" & vbCrLf &
                                  "Columna B = Nombre de asociación (Máx. 300 Caracteres)" & vbCrLf &
                                  "Columna C = Es Seleccionable, 0 = NO, 1 = SI" & vbCrLf & vbCrLf &
                                  "(*) LA PRIMERA FILA DE LA HOJA EXCEL SE CONSIDERA COMO ENCABEZADO" & vbCrLf & vbCrLf &
                                  "Los códigos nuevos se intertaran y los códigos que ya existan, se modificara la descripción",
                                  "Formato archivo Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Bar2.Enabled = False
            Me.Enabled = False

            Switch_Modo_Edicion.Enabled = False

            Dim _Nombre_Archivo As String
            Dim _UbicArchivo As String

            With OpenFileDialog1
                '.Filter = "Ficheros DBF (PFMDSP10.dbf)|PFMDSP10.dbf|Todos (*.*)|*.*"
                .Filter = "Ficheros (*.xls)|*.xlsx|Todos los archivos (*.*)|*.*"
                'Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
                .FileName = String.Empty
                '.ShowDialog(Me)

                If .ShowDialog(Me) = DialogResult.OK Then
                    _Nombre_Archivo = .SafeFileName
                    _UbicArchivo = .FileName
                Else
                    _UbicArchivo = String.Empty
                    Bar2.Enabled = True
                    Return
                End If
            End With

            Progreso_Porc.Visible = True
            Barra_Progreso.Visible = True

            Dim ImpEx As New Class_Importar_Excel
            Dim Extencion As String = Replace(System.IO.Path.GetExtension(_Nombre_Archivo), ".", "")
            Dim Arreglo = ImpEx.Importar_Excel_Array(_UbicArchivo, Extencion, 0)
            Dim Filas = Arreglo.GetUpperBound(0)
            Dim RegInsert As Long = 0

            Dim _Codigo_Madre As String
            Dim _Descripcion As String

            Dim _Editados As Integer
            Dim _Insertados As Integer

            Progreso_Porc.Maximum = 100
            Barra_Progreso.Maximum = Filas
            Dim Contador As Integer = 0

            Dim _Es_Seleccionable As Boolean


            For i = 1 To Filas

                System.Windows.Forms.Application.DoEvents()

                Dim _Punto As String = String.Empty

                _Codigo_Madre = Trim(NuloPorNro(Arreglo(i, 0), ""))
                _Descripcion = Trim(NuloPorNro(Arreglo(i, 1), ""))
                _Es_Seleccionable = CBool(Arreglo(i, 2))

                Dim _Reg As Boolean

                Consulta_sql = "Select * From " & _Tbl_Tabla_De_Paso & " Where Codigo_Madre = '" & _Codigo_Madre & "'"
                Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                If CBool(_Tbl.Rows.Count) Then
                    Consulta_sql = "Update " & _Tbl_Tabla_De_Paso & Space(1) &
                                   "Set Editado = 1,Descripcion = '" & _Descripcion & "' Where Codigo_Madre = '" & _Codigo_Madre & "'"
                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                        _Editados += 1
                    End If
                Else
                    Consulta_sql = "Insert Into " & _Tbl_Tabla_De_Paso & " (Nuevo_Item,Codigo_Nodo,Identificacdor_NodoPadre,Descripcion,Es_Seleccionable," &
                                   "Prod_Ass,Clas_Unica_X_Producto,Nodo_Raiz,Codigo_Madre) Values " &
                                   "(1,0," & _Identificador_NodoPadre & ",'" & _Descripcion & "'," & CInt(_Es_Seleccionable) * -1 &
                                   ",0," & CInt(_Clas_Unica_X_Producto) * -1 &
                                   "," & _Nodo_Raiz & ",'" & _Codigo_Madre & "')"
                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                        _Insertados += 1
                    End If
                End If

                'System.Windows.Forms.Application.DoEvents()
                Contador += 1
                Progreso_Porc.Value = ((Contador * 100) / Filas - 1) 'Mas
                Barra_Progreso.Text = FormatPercent(Progreso_Porc.Value, 0)
                Barra_Progreso.Value += 1
            Next

            MessageBoxEx.Show(Me, "Total registros leidos: " & FormatNumber(Filas, 0) & vbCrLf &
                              "Registros insertados: " & FormatNumber(_Insertados, 0) & vbCrLf &
                              "Registros editados:" & FormatNumber(_Editados, 0),
                              "Inserción y actualización masiva", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message)
        Finally
            Bar2.Enabled = True
            Me.Enabled = True
            Progreso_Porc.Text = String.Empty
            Progreso_Porc.Value = 0
            Switch_Modo_Edicion.Enabled = True
            Barra_Progreso.Visible = False
        End Try


        Sb_Actualizar_Grilla(True)
        Me.Refresh()

    End Sub

    Private Sub EsSeleccionableToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Codigo_Nodo = _Fila.Cells("Codigo_Nodo").Value
        Dim _Prod_Ass = _Fila.Cells("Prod_Ass").Value
        Dim _Clas_Unica_X_Producto = _Fila.Cells("Clas_Unica_X_Producto").Value

        If Not CBool(_Prod_Ass) Then

            If Fx_Tiene_Permiso(Me, "Tbl00003") Then

                Dim _Es_Seleccionable = _Fila.Cells("Es_Seleccionable").Value

                If _Es_Seleccionable Then
                    'If _Ubicaciones Then _Fila.Cells("Es_Padre").Value = True
                    _Fila.Cells("Es_Seleccionable").Value = False
                Else

                    Dim _Cod_Ubicacion = String.Empty
                    Dim _Descripcion = _Fila.Cells("Descripcion").Value

                    _Fila.Cells("Es_Seleccionable").Value = True

                End If

            End If
        Else
            MessageBoxEx.Show(Me, "No se puede cambiar el tipo de carpeta, ya que existen productos asociados a esta",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


    Private Sub BtnEliminarTodo_Click(sender As System.Object, e As System.EventArgs) Handles BtnEliminarTodo.Click
        With Grilla
            If Fx_Tiene_Permiso(Me, "Tbl00006") Then
                If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar todas las clasificaciones de selección?",
                                     "Eliminar clasificación",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Consulta_sql = "Delete " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Identificacdor_NodoPadre = " & _Identificador_NodoPadre &
                                   "And Es_Padre = 0"

                    _Sql.Ej_consulta_IDU(Consulta_sql) '  _Sql.Ej_consulta_IDU(Consulta_Sql)

                    Sb_Actualizar_Grilla(Switch_Modo_Edicion.Value)

                End If
            End If
        End With
    End Sub



    Private Sub Btn_ClasificarMasivamente_Click(sender As System.Object, e As System.EventArgs) Handles Btn_ClasificarMasivamente.Click
        If Fx_Tiene_Permiso(Me, "Tbl00022") Then
            Dim Fm As New Frm_Arbol_Asociaciones_05_Marcar_filtros_masivamente
            Fm.BtnGenerar.Visible = False
            Fm.ShowDialog(Me)
        End If
    End Sub

    Private Sub Btn_BuscarClasificacion_Click(sender As System.Object, e As System.EventArgs) Handles Btn_BuscarClasificacion.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        'Dim _Codigo_Nodo = _Fila.Cells("Codigo_Nodo").Value
        'Dim _Prod_Ass = _Fila.Cells("Prod_Ass").Value
        Dim _Clas_Unica_X_Producto = _Fila.Cells("Clas_Unica_X_Producto").Value

        Dim Fm As Frm_Arbol_Asociacion_05_Busqueda '(Frm_Arbol_Asociacion_05_Busqueda.Enum_Tipo_De_Carpeta.Toda, False) 'Frm_Arbol_Asociacion_03_buscar("")

        If _Clas_Unica_X_Producto Then
            Fm = New Frm_Arbol_Asociacion_05_Busqueda(Frm_Arbol_Asociacion_05_Busqueda.Enum_Tipo_De_Carpeta.Clas_Unica_Hijos)
        Else
            Fm = New Frm_Arbol_Asociacion_05_Busqueda(Frm_Arbol_Asociacion_05_Busqueda.Enum_Tipo_De_Carpeta.Clas_Filtro_Ambas)
        End If

        'Dim Fm As New Frm_Arbol_Asociacion_05_Busqueda(Frm_Arbol_Asociacion_05_Busqueda.Enum_Tipo_De_Carpeta.Toda, False) 'Frm_Arbol_Asociacion_03_buscar("")
        Fm.Text = "Busqueda de carpetas"

        Fm.ShowDialog(Me)
        Dim _Row_Nodo_Seleccionado As DataRow = Fm.Pro_Row_Nodo_Seleccionado ' = Fm._Tbl_Nodo_Seleccionado
        Fm.Dispose()

        If Not (_Row_Nodo_Seleccionado Is Nothing) Then

            Dim _Codigo_Nodo = _Row_Nodo_Seleccionado.Item("Codigo_Nodo")
            Dim _Cod_NodoPadre = _Row_Nodo_Seleccionado.Item("Identificacdor_NodoPadre")
            Dim _Descripcion As String = _Row_Nodo_Seleccionado.Item("Descripcion")

            If _Cod_NodoPadre <> _Identificador_NodoPadre Then

                Dim _Clas As New Clas_Arbol_Asociaciones(Me)
                Dim _Full As String = _Clas.Fx_Raiz_Clasificacion(_Codigo_Nodo)

                Dim _Fm As New Frm_Arbol_Asociacion_02(True, 0, Switch_Modo_Edicion.Value, _Clasificacion, _NroTblPaso + 1)
                With _Fm
                    .Pro_Top = Me.Top
                    .Pro_Left = Me.Left
                    ._Descripcion_Busqueda = _Descripcion
                    ._Identificador_NodoPadre = _Cod_NodoPadre
                    ._FullPath = _Full 'Fx_Raiz_Clasificacion(_Codigo_Nodo)
                    .Btn_Importar_Asociaciones_Desde_Excel.Visible = False
                    .Btn_Ver_Arbol.Visible = False
                    .Btn_BuscarClasificacion.Visible = False
                    .ShowDialog(Me)
                End With

            Else
                If BuscarDatoEnGrilla(Trim(_Descripcion), "Descripcion", Grilla) = True Then
                    Grilla.Focus()
                End If
            End If

        End If

    End Sub

    Private Sub Txt_DescripcionBusqueda_TextChanged(sender As System.Object, e As System.EventArgs) Handles Txt_DescripcionBusqueda.TextChanged
        'BuscarDatoEnGrilla(Txt_DescripcionBusqueda.Text, "Descripcion", Grilla)
    End Sub

    Private Sub Txt_DescripcionBusqueda_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles Txt_DescripcionBusqueda.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla(Switch_Modo_Edicion.Value)
        End If
    End Sub


    Private Sub Sb_Grilla_CellMouseUp(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs)

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        If _Cabeza = "Seleccion" Then
            If Switch_Modo_Edicion.Value Then
                Grilla.EndEdit()
            End If
        End If

    End Sub


    Private Sub Mnu_Btn_Ver_Sub_Carpetas_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Btn_Ver_Sub_Carpetas.Click
        Sb_Agregar_SubClasificaciones()
    End Sub

    Private Sub Mnu_Btn_Eliminar_Clasificacion_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Btn_Eliminar_Clasificacion.Click
        Sb_Eliminar_Clasificacion()
    End Sub

    Private Sub Mnu_Btn_Ver_Productos_Asociados_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Btn_Ver_Productos_Asociados.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Nuevo_Item As Boolean = _Fila.Cells("Nuevo_Item").Value

        If Not Fx_Rev_Class_Grabada(_Nuevo_Item) Then Return

        Dim _Codigo_Nodo As Integer = _Fila.Cells("Codigo_Nodo").Value
        Dim _Descripcion As String = _Fila.Cells("Descripcion").Value

        Sb_VerProductos_X_Class_X_Fila(_Codigo_Nodo, _Descripcion)

    End Sub

    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

                    Dim _Nuevo_Item As Boolean = NuloPorNro(_Fila.Cells("Nuevo_Item").Value, False)
                    Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
                    Dim _Es_Seleccionable As Boolean = _Fila.Cells("Es_Seleccionable").Value
                    Dim _Descripcion = _Fila.Cells("Descripcion").Value

                    If _Cabeza = "Es_Seleccionable" Then
                        If _Nodo_Raiz = 0 Then
                            MessageBoxEx.Show(Me, "Debe crear carpetas dentro de esta asociación." & vbCrLf &
                                               "Las carpetas de asociación principales no reciben productos directamente",
                                               "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            If Switch_Modo_Edicion.Value Then

                                RemoveHandler Mnu_Rdb_Es_Padre.CheckedChanged, AddressOf Sb_Rdb_CheckedChanged
                                RemoveHandler Mnu_Rdb_Es_Seleccionable.CheckedChanged, AddressOf Sb_Rdb_CheckedChanged

                                If _Es_Seleccionable Then
                                    Mnu_Rdb_Es_Seleccionable.Checked = True
                                Else
                                    Mnu_Rdb_Es_Padre.Checked = True
                                End If

                                AddHandler Mnu_Rdb_Es_Padre.CheckedChanged, AddressOf Sb_Rdb_CheckedChanged
                                AddHandler Mnu_Rdb_Es_Seleccionable.CheckedChanged, AddressOf Sb_Rdb_CheckedChanged

                                ShowContextMenu(Menu_Contextual_02)
                            End If
                        End If

                    Else
                        If Not _Fila.IsNewRow() Then

                            If _Nuevo_Item Then
                                Mnu_Btn_Ver_Productos_Asociados.Visible = False
                                Mnu_Btn_Ver_Sub_Carpetas.Visible = False
                                Mnu_Btn_Ver_Productos_Sin_Asociacion.Visible = False
                            Else
                                If _Identificador_NodoPadre = 0 Then
                                    Mnu_Btn_Ver_Productos_Sin_Asociacion.Visible = True
                                Else
                                    Mnu_Btn_Ver_Productos_Sin_Asociacion.Visible = False
                                End If
                            End If

                            If Switch_Modo_Edicion.Value Then
                                Mnu_Btn_Ver_Sub_Carpetas.Visible = False
                                Mnu_Btn_Ver_Productos_Asociados.Visible = False
                                Mnu_Btn_Ver_Productos_Sin_Asociacion.Visible = False
                            Else
                                Mnu_Btn_Ver_Sub_Carpetas.Visible = True
                                Mnu_Btn_Ver_Productos_Asociados.Visible = True
                            End If

                            Mnu_Btn_Eliminar_Clasificacion.Visible = Switch_Modo_Edicion.Value

                            ShowContextMenu(Menu_Contextual_01)
                        End If
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub Mnu_Btn_Ver_Productos_Sin_Asociacion_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Btn_Ver_Productos_Sin_Asociacion.Click
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Codigo_Nodo As Integer = _Fila.Cells("Codigo_Nodo").Value
        Dim _Descripcion As String = _Fila.Cells("Descripcion").Value

        Sb_VerProductos_X_Class_X_Fila(_Codigo_Nodo, _Descripcion, True)
    End Sub


    Private Sub Sb_Switch_Modo_Edicion_ValueChanged(sender As System.Object, e As System.EventArgs)

        If Switch_Modo_Edicion.Value Then
            If Fx_Tiene_Permiso(Me, "Tbl00030") Then

                'Sb_Actualizar_Grilla()

                ToastNotification.Show(Me, "AHORA ES POSIBLE EDITAR LAS CLASIFICACIONES",
                                       My.Resources.ok_button,
                                       1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                'Sb_Insertar_nueva_linea(_Clas_Unica_X_Producto)
                'Grilla.Rows(Grilla.Rows.Count - 1).Cells("BtnImagen").Value = Imagenes.Images.Item("folder-new.png")
            Else
                Switch_Modo_Edicion.Value = False
            End If

        Else

            Dim _Modificado As Boolean

            Dim _Registros_Nuevos As Integer = _Sql.Fx_Cuenta_Registros(_Tbl_Tabla_De_Paso, "Nuevo_Item = 1")
            Dim _Registros_Editados As Integer = _Sql.Fx_Cuenta_Registros(_Tbl_Tabla_De_Paso, "Editado = 1")
            Dim _Registros_Eliminados As Integer = _Sql.Fx_Cuenta_Registros(_Tbl_Tabla_De_Paso, "Eliminado = 1")

            _Modificado = CBool(_Registros_Editados + _Registros_Eliminados + _Registros_Nuevos)

            If _Modificado Then
                If MessageBoxEx.Show(Me, "¿Desea guardar los cambios hechos?",
                                         "Carpetas modficadas sin grabar", MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Call BtnGrabar_Click(Nothing, Nothing)
                End If
                Txt_DescripcionBusqueda.Text = String.Empty
            End If

        End If

        Btn_Grabar.Visible = Switch_Modo_Edicion.Value
        Btn_Importar_Asociaciones_Desde_Excel.Visible = Switch_Modo_Edicion.Value
        Btn_Agregar_Nueva_Carpeta.Enabled = Switch_Modo_Edicion.Value


        If Switch_Modo_Edicion.Value Then
            Btn_BuscarClasificacion.Visible = False
            Btn_Ver_Arbol.Visible = False
            Btn_Exportar_Excel.Visible = False
            Btn_Carpeta_Padrel_Ver_Productos_Asociados.Visible = False
            Btn_Carpeta_Padre_Ver_Productos_Sin_Asociacion.Visible = False
            AddHandler Mnu_Rdb_Es_Padre.CheckedChanged, AddressOf Sb_Rdb_CheckedChanged
            AddHandler Mnu_Rdb_Es_Seleccionable.CheckedChanged, AddressOf Sb_Rdb_CheckedChanged
        Else

            If _Clasificacion = Enum_Clasificacion.Dinamica Then
                Btn_BuscarClasificacion.Visible = True
                Btn_Ver_Arbol.Visible = True
            ElseIf _Clasificacion = Enum_Clasificacion.Unica Then
                If CBool(_Nodo_Raiz) Then
                    Btn_Carpeta_Padrel_Ver_Productos_Asociados.Visible = True
                    Btn_Carpeta_Padre_Ver_Productos_Sin_Asociacion.Visible = True
                End If
            End If

            Btn_Exportar_Excel.Visible = True
            RemoveHandler Mnu_Rdb_Es_Padre.CheckedChanged, AddressOf Sb_Rdb_CheckedChanged
            RemoveHandler Mnu_Rdb_Es_Seleccionable.CheckedChanged, AddressOf Sb_Rdb_CheckedChanged

        End If

        Me.Refresh()
        'BuscarDatoEnGrilla(Txt_DescripcionBusqueda.Text, "Descripcion", Grilla)

    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Grilla.KeyDown
        If e.KeyValue = Keys.Enter Then
            If Switch_Modo_Edicion.Value Then
                Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
                If _Cabeza = "Codigo_Madre" Or _Cabeza = "Descripcion" Then
                    Grilla.Columns(_Cabeza).ReadOnly = False
                    Grilla.BeginEdit(True)
                    e.SuppressKeyPress = False
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Sub Btn_Agregar_Nueva_Carpeta_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Agregar_Nueva_Carpeta.Click
        Dim _Fila = Grilla.Rows.Count - 1
        Sub_Agregar_Nueva_Carpeta(_Fila)
    End Sub

    Private Sub Sb_Rdb_CheckedChanged(sender As System.Object, e As DevComponents.DotNetBar.CheckBoxChangeEventArgs)
        If CType(sender, Object).Checked Then
            Sb_Cambiar_Tipo_De_Carpeta()
        End If
    End Sub

    Sub Sb_Cambiar_Tipo_De_Carpeta()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Codigo_Nodo = _Fila.Cells("Codigo_Nodo").Value
        Dim _Prod_Ass = _Fila.Cells("Prod_Ass").Value
        Dim _Clas_Unica_X_Producto = _Fila.Cells("Clas_Unica_X_Producto").Value

        Dim _Es_Seleccionable As Boolean = _Fila.Cells("Es_Seleccionable").Value
        Dim _Id = _Fila.Cells("Id").Value

        '_Fila.Cells("BtnImagen").Value = Imagenes.Images.Item("folder-new.png")

        Select Case _Cabeza
            Case "Es_Seleccionable", "Codigo_Madre_Obligatorio"

                'If Not _Nuevo_Item Then

                If Not CBool(_Prod_Ass) Then

                    If Mnu_Rdb_Es_Padre.Checked Then

                        Dim _Reg As Boolean

                        If Not CBool(_Prod_Ass) Then
                            _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_TblArbol_Asociaciones",
                                                    "Identificacdor_NodoPadre = '" & _Codigo_Nodo & "'")
                        End If

                        If Not _Reg Then
                            _Fila.Cells(_Cabeza).Value = False
                        Else
                            MessageBoxEx.Show(Me, "Esta clasificación posee sub-clasificaciones" & vbCrLf &
                                              "No se puede quitar el ticket, debe eliminar los hijos para poder realizar esta acción",
                                              "Editar atributo de carpeta",
                                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                    Else
                        _Fila.Cells(_Cabeza).Value = True
                    End If

                    Consulta_sql = "Update " & _Tbl_Tabla_De_Paso & Space(1) &
                                   "Set" & Space(1) &
                                   "Editado = 1," &
                                   "Es_Seleccionable = " & CInt(_Fila.Cells(_Cabeza).Value) * -1 & Space(1) &
                                   "Where Id = " & _Id
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                Else
                    MessageBoxEx.Show(Me, "No se puede cambiar el tipo de carpeta, ya que existen productos asociados a esta",
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '_Denegar = True
                End If

            Case ""

        End Select

        'Sb_Marcar_Fila(_Fila)


    End Sub

    Private Sub Grilla_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Grilla.DragDrop

        ' The mouse locations are relative to the screen, so they must be 
        ' converted to client coordinates.
        Dim clientPoint As Point = Grilla.PointToClient(New Point(e.X, e.Y))
        ' Get the row index of the item the mouse is below. 
        Dim filaLugarnuevo = Grilla.HitTest(clientPoint.X, clientPoint.Y).RowIndex


        'Comprobamos que los indices de las filas no son el mismo y que no es el anterior a la fila seleccionada
        If filaLugarnuevo <> _Fila_Seleccionada_DrapDorg Then
            If (filaLugarnuevo + 1) <> _Fila_Seleccionada_DrapDorg Then
                'Comprobamos que el efecto sea el de mover una fila
                If (e.Effect = DragDropEffects.Move) Then
                    'Aqui pondremos si queremos guardar los datos en una BD
                End If
            End If
        End If


    End Sub

    Private Sub Grilla_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Grilla.MouseMove
        Return
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If _Fila_Seleccionada_DrapDorg <> -1 Then
                'If dragBoxFromMouseDown <> Rectangle.Empty And Not System.Windows.Forms.dragBoxFromMouseDown.Contains(e.X, e.Y) Then

                ' Iniciamos el porcedimiento de arratrar.                    
                Dim dropEffect As DragDropEffects
                dropEffect = Grilla.DoDragDrop(Grilla.Rows(_Fila_Seleccionada_DrapDorg), DragDropEffects.Move)
                'End If
            End If
        End If
    End Sub

    Private Sub Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Grilla.MouseDown
        'Get the Index of Row which is being Dragged
        'We would use this Index on Drop to identify which Row was dragged and get the values from that row
        If Switch_Modo_Edicion.Value Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                _Fila_Seleccionada_DrapDorg = Grilla.HitTest(e.X, e.Y).RowIndex 'Grilla.CurrentRow.Index
                Dim Index As Integer
                Index = Grilla.HitTest(e.X, e.Y).RowIndex
                If Index > -1 Then
                    'Pass the Index as "Data" argument of the DoDragDrop Function
                    'Grilla.DoDragDrop(Index, DragDropEffects.Move)
                    Dim dropEffect As DragDropEffects

                    Dim _Fila As DataGridViewRow = Grilla.Rows(Index)

                    dropEffect = Grilla.DoDragDrop(Grilla.Rows(_Fila_Seleccionada_DrapDorg), DragDropEffects.Move)

                End If
            End If
        End If
    End Sub

    Private Sub Grilla_DragOver(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Grilla.DragOver
        'Just to Show a mouse icon to denote drop is allowed here

        Dim clientPoint As Point = Grilla.PointToClient(New Point(e.X, e.Y))
        Dim filaLugarnuevo = Grilla.HitTest(clientPoint.X, clientPoint.Y).RowIndex

        Dim _Fila As DataGridViewRow = Grilla.Rows(filaLugarnuevo)

        Dim _Es_Seleccionable = _Fila.Cells("Es_Seleccionable").Value

        If _Es_Seleccionable Then
            e.Effect = DragDropEffects.None
        Else
            e.Effect = DragDropEffects.Move
        End If
        '_Fila.DefaultCellStyle.BackColor = Color.Aqua
    End Sub

    Private Sub Grilla_DragLeave(sender As System.Object, e As System.EventArgs) Handles Grilla.DragLeave
        Dim dropEffect As DragDropEffects
        dropEffect = DragDropEffects.None

        Me.Cursor = New Cursor(Cursor.Current.Handle)

        Dim clientPoint As Point = Grilla.PointToClient(New Point(Cursor.Position.X, Cursor.Position.Y))
        Dim filaLugarnuevo = Grilla.HitTest(clientPoint.X, clientPoint.Y).RowIndex

        Dim _Fila As DataGridViewRow = Grilla.Rows(filaLugarnuevo)
        _Fila.DefaultCellStyle.BackColor = Color.White
        'e.Effect = DragDropEffects.None
    End Sub

    Private Sub Grilla_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Grilla.DragEnter

        Dim clientPoint As Point = Grilla.PointToClient(New Point(e.X, e.Y))
        Dim filaLugarnuevo = Grilla.HitTest(clientPoint.X, clientPoint.Y).RowIndex

        Dim _Fila As DataGridViewRow = Grilla.Rows(filaLugarnuevo)

        Dim _Es_Seleccionable = _Fila.Cells("Es_Seleccionable").Value

        If _Es_Seleccionable Then
            Dim dropEffect As DragDropEffects
            dropEffect = DragDropEffects.None
        Else

            'Comprobamos que los indices de las filas no son el mismo y que no es el anterior a la fila seleccionada
            If filaLugarnuevo <> _Fila_Seleccionada_DrapDorg Then
                If (filaLugarnuevo + 1) <> _Fila_Seleccionada_DrapDorg Then
                    'Comprobamos que el efecto sea el de mover una fila
                    If (e.Effect = DragDropEffects.Move) Then
                        'Aqui pondremos si queremos guardar los datos en una BD
                    End If
                End If
            End If

        End If

        _Fila.DefaultCellStyle.BackColor = Color.Aqua

    End Sub

    Private Sub Grilla_CellMouseEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellMouseEnter
        Return
        If Switch_Modo_Edicion.Value Then
            If e.RowIndex >= 0 Then
                Grilla.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.AliceBlue
                'Grilla.Rows(e.RowIndex).Selected = True
                'Grilla.FirstDisplayedScrollingRowIndex = e.RowIndex
            End If
        End If
    End Sub

    Private Sub Grilla_CellMouseLeave(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellMouseLeave
        Return
        If Switch_Modo_Edicion.Value Then
            If e.RowIndex >= 0 Then
                ' Grilla.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub Btn_Ver_Arbol_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ver_Arbol.Click

        Dim Fm As New Frm_Arbol_Asociacion_01
        Fm.Pro_CheckBoxes_Nodos = False
        Fm.BtnGrabar.Visible = False
        Fm.BtnContraerTodo.Visible = True
        Fm.BtnImprimirArbol.Visible = True
        Fm.Chk_Ver_Clas_Unicas.Enabled = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Exportar_Excel.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_Carpetas, Me, "Nodos")
    End Sub


    'Pinta el contenido que abarca varias columnas y el rectángulo de enfoque.

    Sub Sb_Grilla_RowPostPaint(sender As Object,
        e As DataGridViewRowPostPaintEventArgs) ' _


        'Calcula los límites de la fila.
        Dim rowBounds As New Rectangle(Grilla.RowHeadersWidth,
            e.RowBounds.Top, Grilla.Columns.GetColumnsWidth(
            DataGridViewElementStates.Visible) -
            Grilla.HorizontalScrollingOffset + 1, e.RowBounds.Height)

        Dim forebrush As SolidBrush = Nothing
        Try
            'Determine el color de primer plano.
            If (e.State And DataGridViewElementStates.Selected) =
                DataGridViewElementStates.Selected Then

                forebrush = New SolidBrush(e.InheritedRowStyle.SelectionForeColor)
            Else
                forebrush = New SolidBrush(e.InheritedRowStyle.ForeColor)
            End If

            'Obtenga el contenido que abarca múltiples columnas.
            Dim recipe As Object =
                Grilla.Rows.SharedRow(e.RowIndex).Cells(1).Value

            If (recipe IsNot Nothing) Then
                Dim text As String = recipe.ToString()

                'Calcule los límites para el contenido que abarca múltiples
                'columnas, ajustando para la posición de desplazamiento horizontal
                'y la altura de la fila actual, y mostrando solo todo
                'líneas de texto.
                Dim textArea As Rectangle = rowBounds
                textArea.X -= Grilla.HorizontalScrollingOffset
                textArea.Width += Grilla.HorizontalScrollingOffset
                textArea.Y += rowBounds.Height - e.InheritedRowStyle.Padding.Bottom
                textArea.Height -= rowBounds.Height - e.InheritedRowStyle.Padding.Bottom
                textArea.Height = (textArea.Height \ e.InheritedRowStyle.Font.Height) *
                    e.InheritedRowStyle.Font.Height

                'Calcule la parte del área de texto que necesita pintura.
                Dim clip As RectangleF = textArea
                clip.Width -= Grilla.RowHeadersWidth + 1 - clip.X
                clip.X = Grilla.RowHeadersWidth + 1
                Dim oldClip As RectangleF = e.Graphics.ClipBounds
                e.Graphics.SetClip(clip)

                'Dibuja el contenido que abarca varias columnas.
                e.Graphics.DrawString(text, e.InheritedRowStyle.Font, forebrush,
                    textArea)

                e.Graphics.SetClip(oldClip)
            End If
        Finally
            forebrush.Dispose()
        End Try

        If Grilla.CurrentCellAddress.Y = e.RowIndex Then
            ' Paint the focus rectangle.
            e.DrawFocus(rowBounds, True)
        End If

    End Sub 'dataGridView1_RowPostPaint

    Private Sub Grilla_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEnter

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        'Sb_Marcar_Fila(_Fila)

    End Sub

    Private Sub Mnu_Btn_Carpeta_Actual_Ver_Productos_Asociados_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Btn_Carpeta_Actual_Ver_Productos_Asociados.Click
        Dim _Codigo_Nodo As Integer = _Row_Padre.Item("Codigo_Nodo") ' _Fila.Cells("Codigo_Nodo").Value
        Dim _Descripcion As String = _Row_Padre.Item("Descripcion") ' _Fila.Cells("Descripcion").Value
        Sb_VerProductos_X_Class_X_Fila(_Codigo_Nodo, _Descripcion, False)
    End Sub

    Private Sub Mnu_Btn_Carpeta_Actual_Ver_Productos_Sin_Asociacion_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Btn_Carpeta_Actual_Ver_Productos_Sin_Asociacion.Click
        Dim _Codigo_Nodo As Integer = _Row_Padre.Item("Codigo_Nodo") '_Fila.Cells("Codigo_Nodo").Value
        Dim _Descripcion As String = _Row_Padre.Item("Descripcion") '_Fila.Cells("Descripcion").Value
        Sb_VerProductos_X_Class_X_Fila(_Codigo_Nodo, _Descripcion, True)
    End Sub

    Private Sub Btn_Carpeta_Padrel_Ver_Productos_Asociados_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Carpeta_Padrel_Ver_Productos_Asociados.Click
        Sb_VerProductos_X_Class_X_Cartepa_Padre(False)
    End Sub

    Private Sub Btn_Carpeta_Padre_Ver_Productos_Sin_Asociacion_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Carpeta_Padre_Ver_Productos_Sin_Asociacion.Click
        Sb_VerProductos_X_Class_X_Cartepa_Padre(True)
    End Sub

    Public Sub Sb_Insertar_Registro_O_Actualizar(_Clas_Unica_X_Producto As Boolean,
                                       Optional _Descripcion As String = "")


        Dim _Es_Seleccionable As Boolean

        If Not (_Row_Padre Is Nothing) Then
            If _Clas_Unica_X_Producto Then
                _Es_Seleccionable = True
            End If
        End If

        Consulta_sql = "Insert Into " & _Tbl_Tabla_De_Paso & " (Nuevo_Item,Codigo_Nodo,Identificacdor_NodoPadre,Descripcion,Es_Seleccionable," &
                       "Prod_Ass,Clas_Unica_X_Producto,Nodo_Raiz) Values " &
                       "(1,0," & _Identificador_NodoPadre & ",'" & _Descripcion & "'," & CBool(_Es_Seleccionable) * -1 &
                       ",0," & CInt(_Clas_Unica_X_Producto) * -1 &
                       "," & _Nodo_Raiz & ")"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Dim _Id As Integer = _Sql.Fx_Trae_Dato(_Tbl_Tabla_De_Paso, "Max(Id)")

        Grilla.Refresh()

        Dim NewFila As DataRow
        NewFila = _Tbl_Carpetas.NewRow

        With NewFila
            .Item("Id") = _Id
            .Item("Nuevo_Item") = True
            .Item("Descripcion") = _Descripcion
            .Item("Es_Seleccionable") = CBool(_Es_Seleccionable) * -1
            .Item("Prod_Ass") = 0
            .Item("Clas_Unica_X_Producto") = _Clas_Unica_X_Producto
            .Item("Nodo_Raiz") = _Nodo_Raiz
        End With

        _Tbl_Carpetas.Rows.Add(NewFila)

    End Sub

End Class
