Imports DevComponents.DotNetBar

Public Class Frm_Arbol_Asociacion_04_Entidades_x_class

    Private ReadOnly _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Private _Codigo_Heredado As String
    Private _Codigo_Nodo As Integer
    Private _Identificador_NodoPadre As Integer
    Private _Descripcion_Nodo As String
    Private _Descripcion_Busqueda As String
    Private _Carpeta_Seleccionable As Boolean
    Private _Mostrar_Entidades_Sin_Asociacion_En_Nodo As Boolean
    Private _Tbl_Entidades_En_Carpeta As DataTable
    Private _Grabar As Boolean
    Private _Row_Nodo As DataRow
    Private ReadOnly _Dv As New DataView
    Private _Lista_Nodos As New List(Of Integer)

    Public Property ModoSoloLectura As Boolean

    Public Property Pro_Codigo_Heredado As String
        Get
            Return _Codigo_Heredado
        End Get
        Set(value As String)
            _Codigo_Heredado = value
        End Set
    End Property

    Public ReadOnly Property Pro_Grabar As Boolean
        Get
            Return _Grabar
        End Get
    End Property

    Public Property Pro_Lista_Nodos As List(Of Integer)
        Get
            Return _Lista_Nodos
        End Get
        Set(value As List(Of Integer))
            _Lista_Nodos = value
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
        Sb_Color_Botones_Barra(Bar2)
    End Sub

    Public Sub New(Identificador_NodoPadre As Integer,
                   Codigo_Nodo As Integer,
                   Descripcion_Nodo As String,
                   Descripcion_Busqueda As String,
                   Carpeta_Seleccionable As Boolean,
                   Clas_Unica_X_Entidad As Boolean,
                   Mostrar_Entidades_Sin_Asociacion_En_Nodo As Boolean)

        Me.New()

        _Identificador_NodoPadre = Identificador_NodoPadre
        _Codigo_Nodo = Codigo_Nodo
        _Descripcion_Nodo = Descripcion_Nodo
        _Descripcion_Busqueda = Descripcion_Busqueda
        _Carpeta_Seleccionable = Carpeta_Seleccionable
        _Mostrar_Entidades_Sin_Asociacion_En_Nodo = Mostrar_Entidades_Sin_Asociacion_En_Nodo
        _Codigo_Heredado = String.Empty

        Dim sql As String =
            "Select Top 1 * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
            "Where Codigo_Nodo = '" & _Codigo_Nodo & "' And ParaEntidad = 1"

        _Row_Nodo = _Sql.Fx_Get_DataRow(sql)
        Txt_Filtrar.ReadOnly = False
    End Sub

    Private Sub Frm_Arbol_Asociacion_04_Entidades_x_class_Load(
        sender As Object,
        e As EventArgs) Handles MyBase.Load

        Dim sql As String =
            "Select Top 1 * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
            "Where Codigo_Nodo = '" & _Codigo_Nodo & "' And ParaEntidad = 1"

        Dim rowNodo As DataRow = _Sql.Fx_Get_DataRow(sql)

        If rowNodo Is Nothing Then
            MessageBoxEx.Show(Me, "No se encontró el nodo de entidades.", "Árbol de entidades",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Close()
            Return
        End If

        Txt_Codigo_Madre.Text = Convert.ToString(rowNodo("Codigo_Madre"))
        Txt_Codigo_Nodo.Text = Convert.ToString(rowNodo("Codigo_Nodo"))
        Txt_Descripcion.Text = Convert.ToString(rowNodo("Descripcion"))

        Barra_Progreso_.Visible = False
        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8),
                                   Color.AliceBlue, ScrollBars.Vertical, True, True, True)
        Grilla.RowHeadersWidth = 15

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

        If _Carpeta_Seleccionable Then
            AddHandler Grilla.MouseUp, AddressOf Sb_Grilla_MouseUp
            AddHandler Chk_Seleccionar_Todos.CheckedChanged,
                AddressOf Sb_Chk_Seleccionar_Todos_CheckedChanged
        End If

        Btn_AgregarEntidades.Visible = Not ModoSoloLectura
        Btn_QuitarProducto.Visible = Not ModoSoloLectura
        Btn_Quitar_Marcados.Visible = Not ModoSoloLectura
        Btn_Quitar_Todo.Visible = Not ModoSoloLectura
        Btn_QuitarEntidades.Visible = Not ModoSoloLectura

        Sb_Llenar_Tablas()
        ActiveControl = Txt_Filtrar
    End Sub

    Private Sub Sb_Llenar_Tablas()
        Dim sql As String

        If _Mostrar_Entidades_Sin_Asociacion_En_Nodo Then
            sql =
                "SELECT Cast(0 As bit) As Chk, E.KOEN As CodEntidad, E.SUEN As CodSucEntidad," & vbCrLf &
                "E.NOKOEN As Descripcion, Cast(0 As bit) As Nuevo," & vbCrLf &
                "Cast(0 As bit) As En_Otra_Carpeta_Padre" & vbCrLf &
                "FROM MAEEN E" & vbCrLf &
                "WHERE NOT EXISTS (SELECT 1 FROM " & _Global_BaseBk & "Zw_Entidades_Asociacion A" & vbCrLf &
                "WHERE A.CodEntidad = E.KOEN And A.CodSucEntidad = E.SUEN" & vbCrLf &
                "And A.Codigo_Nodo = '" & _Codigo_Nodo & "' And A.Para_filtro = 1)" & vbCrLf &
                "ORDER BY E.KOEN, E.SUEN"
            Btn_QuitarEntidades.Visible = False
        Else
            sql =
                "SELECT Cast(0 As bit) As Chk, A.CodEntidad, A.CodSucEntidad," & vbCrLf &
                "Isnull(E.NOKOEN, A.DescripcionBusqueda) As Descripcion," & vbCrLf &
                "Cast(0 As bit) As Nuevo, Cast(0 As bit) As En_Otra_Carpeta_Padre" & vbCrLf &
                "FROM " & _Global_BaseBk & "Zw_Entidades_Asociacion A" & vbCrLf &
                "LEFT JOIN MAEEN E ON E.KOEN = A.CodEntidad And E.SUEN = A.CodSucEntidad" & vbCrLf &
                "WHERE A.Codigo_Nodo = '" & _Codigo_Nodo & "' And A.Para_filtro = 1" & vbCrLf &
                "And EXISTS (SELECT 1 FROM " & _Global_BaseBk & "Zw_TblArbol_Asociaciones N" & vbCrLf &
                "WHERE N.Codigo_Nodo = A.Codigo_Nodo And N.ParaEntidad = 1)" & vbCrLf &
                "ORDER BY A.CodEntidad, A.CodSucEntidad"
        End If

        Dim ds As DataSet = _Sql.Fx_Get_DataSet(sql)
        _Tbl_Entidades_En_Carpeta = ds.Tables(0)
        _Dv.Table = _Tbl_Entidades_En_Carpeta
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Sb_Actualizar_Grilla()
        With Grilla
            .DataSource = _Dv
            OcultarEncabezadoGrilla(Grilla)

            If _Carpeta_Seleccionable Then
                .Columns("Chk").Width = 35
                .Columns("Chk").HeaderText = "Sel."
                .Columns("Chk").Visible = True
                .Columns("Chk").ReadOnly = False
            End If

            .Columns("CodEntidad").Width = 105
            .Columns("CodEntidad").HeaderText = "Código"
            .Columns("CodEntidad").Visible = True
            .Columns("CodEntidad").ReadOnly = True

            .Columns("CodSucEntidad").Width = 75
            .Columns("CodSucEntidad").HeaderText = "Sucursal"
            .Columns("CodSucEntidad").Visible = True
            .Columns("CodSucEntidad").ReadOnly = True

            .Columns("Descripcion").Width = 330
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").ReadOnly = True
        End With

        Lbl_Estatus.Text = "Total de entidades: " & FormatNumber(Grilla.Rows.Count, 0)
    End Sub

    Private Sub Sb_Grilla_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
        Dim row As DataGridViewRow = Grilla.Rows(e.RowIndex)

        If row.Cells("Nuevo").Value IsNot DBNull.Value AndAlso CBool(row.Cells("Nuevo").Value) Then
            row.DefaultCellStyle.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub Sb_Grilla_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button <> MouseButtons.Right Then Return

        Dim hit As DataGridView.HitTestInfo = Grilla.HitTest(e.X, e.Y)
        If hit.Type = DataGridViewHitTestType.Cell Then
            Grilla.CurrentCell = Grilla.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            ShowContextMenu(Menu_Contextual_02)
        End If
    End Sub

    Private Sub Sb_Grilla_MouseUp(sender As Object, e As MouseEventArgs)
        If Grilla.CurrentCell Is Nothing OrElse Not Grilla.Columns.Contains("Chk") Then Return

        Dim columna As String = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        If Control.ModifierKeys <> Keys.Control AndAlso columna = "Chk" Then
            Dim fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            fila.Cells("Chk").Value = Not Convert.ToBoolean(fila.Cells("Chk").Value)
        End If

        Grilla.EndEdit()
    End Sub

    Private Sub Sb_Chk_Seleccionar_Todos_CheckedChanged(sender As Object, e As EventArgs)
        For Each fila As DataGridViewRow In Grilla.Rows
            fila.Cells("Chk").Value = Chk_Seleccionar_Todos.Checked
        Next
        Grilla.EndEdit()
    End Sub

    Private Function Fx_Lista_Nodos_Entidad() As List(Of Integer)
        Dim lista As New List(Of Integer)
        Dim codigoNodo As Integer = _Codigo_Nodo

        Do While codigoNodo <> 0 AndAlso Not lista.Contains(codigoNodo)
            Dim sql As String =
                "Select Top 1 Identificacdor_NodoPadre From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                "Where Codigo_Nodo = '" & codigoNodo & "' And ParaEntidad = 1"

            Dim row As DataRow = _Sql.Fx_Get_DataRow(sql)
            If row Is Nothing Then Exit Do

            lista.Add(codigoNodo)
            codigoNodo = Convert.ToInt32(row("Identificacdor_NodoPadre"))
        Loop

        Return lista
    End Function

    Private Function Fx_Obtener_Claves_Seleccionadas(tabla As DataTable) As List(Of String())
        Dim claves As New List(Of String())()

        If tabla Is Nothing Then Return claves

        Dim campoEntidad As String = Fx_Campo_Disponible(tabla, "CodEntidad", "KOEN", "Codigo")
        Dim campoSucursal As String = Fx_Campo_Disponible(tabla, "CodSucEntidad", "SUEN", "Sucursal", "SubCodigo")

        If String.IsNullOrEmpty(campoEntidad) OrElse String.IsNullOrEmpty(campoSucursal) Then
            Throw New InvalidOperationException(
                "El filtro de entidades debe devolver el código de entidad y el código de sucursal.")
        End If

        For Each fila As DataRow In tabla.Rows
            If tabla.Columns.Contains("Chk") AndAlso
                Not Convert.ToBoolean(fila("Chk")) Then Continue For

            Dim codigo As String = Convert.ToString(fila(campoEntidad)).Trim()
            Dim sucursal As String = Convert.ToString(fila(campoSucursal)).Trim()

            If codigo <> String.Empty AndAlso
                Not claves.Any(Function(c) c(0) = codigo AndAlso c(1) = sucursal) Then
                claves.Add(New String() {codigo, sucursal})
            End If
        Next

        Return claves
    End Function

    Private Function Fx_Campo_Disponible(tabla As DataTable, ParamArray nombres As String()) As String
        For Each nombre As String In nombres
            If tabla.Columns.Contains(nombre) Then Return nombre
        Next
        Return String.Empty
    End Function

    Private Function Fx_Condicion_Claves(claves As List(Of String())) As String
        Dim condiciones As New List(Of String)

        For Each clave As String() In claves
            Dim codigo As String = clave(0).Replace("'", "''")
            Dim sucursal As String = clave(1).Replace("'", "''")
            condiciones.Add("(CodEntidad = '" & codigo & "' And CodSucEntidad = '" & sucursal & "')")
        Next

        Return String.Join(" Or ", condiciones)
    End Function

    Private Sub Btn_Btn_AgregarEntidades_Click(sender As Object, e As EventArgs) Handles Btn_AgregarEntidades.Click
        If ModoSoloLectura OrElse Not Fx_Tiene_Permiso(Me, "Tbl00035") Then Return

        Try
            Dim filtro As New Clas_Filtros_Random(Me)
            filtro.Tabla = "MAEEN"
            filtro.Campo = "KOEN"
            filtro.Descripcion = "NOKOEN"
            filtro.Pro_Descripcion_X_Defecto = _Codigo_Heredado

            Dim condicionExtra As String =
                "And Not Exists (Select 1 From " & _Global_BaseBk & "Zw_Entidades_Asociacion A" & vbCrLf &
                "Where A.CodEntidad = MAEEN.KOEN And A.CodSucEntidad = MAEEN.SUEN" & vbCrLf &
                "And A.Codigo_Nodo = '" & _Codigo_Nodo & "' And A.Para_filtro = 1)"

            Dim tablaFiltro As DataTable = Nothing

            If Not filtro.Fx_Filtrar(tablaFiltro,
                                     Clas_Filtros_Random.Enum_Tabla_Fl._Entidades2,
                                     condicionExtra, False, False) Then
                Return
            End If

            Dim claves As List(Of String()) = Fx_Obtener_Claves_Seleccionadas(filtro.Pro_Tbl_Filtro)
            If claves.Count = 0 Then Return

            Dim nodos As List(Of Integer) = Fx_Lista_Nodos_Entidad()
            Dim condicion As String = Fx_Condicion_Claves(claves)
            Dim descripcion As String = Convert.ToString(_Row_Nodo("Descripcion")).Replace("'", "''")
            Dim codigoMadre As String = Convert.ToString(_Row_Nodo("Codigo_Madre")).Replace("'", "''")
            Dim sql As New System.Text.StringBuilder()

            For Each codigoNodo As Integer In nodos
                sql.AppendLine("INSERT INTO " & _Global_BaseBk &
                               "Zw_Entidades_Asociacion " &
                               "(CodEntidad, CodSucEntidad, Codigo_Nodo, DescripcionBusqueda, " &
                               "Para_filtro, Nodo_origen, Clas_unica, Codigo_Madre)")
                sql.AppendLine("SELECT E.KOEN, E.SUEN, '" & codigoNodo & "', '" & descripcion &
                               "', 1, 0, 0, '" & codigoMadre & "'")
                sql.AppendLine("FROM MAEEN E")
                sql.AppendLine("WHERE " & condicion.Replace("CodEntidad", "E.KOEN").
                               Replace("CodSucEntidad", "E.SUEN"))
                sql.AppendLine("And Not Exists (Select 1 From " & _Global_BaseBk &
                               "Zw_Entidades_Asociacion A")
                sql.AppendLine("Where A.CodEntidad = E.KOEN And A.CodSucEntidad = E.SUEN")
                sql.AppendLine("And A.Codigo_Nodo = '" & codigoNodo & "' And A.Para_filtro = 1)")
            Next

            If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(sql.ToString()) Then
                MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema al grabar",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            _Grabar = True
            Sb_Llenar_Tablas()
            MessageBoxEx.Show(Me, "Entidades asociadas correctamente", "Agregar entidades",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema al agregar entidades",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Sb_Quitar_Entidades(quitarTodos As Boolean, quitarUna As Boolean)
        If ModoSoloLectura Then Return

        Dim claves As New List(Of String())()

        If quitarUna Then
            If Grilla.CurrentRow Is Nothing Then Return
            claves.Add(New String() {
                Convert.ToString(Grilla.CurrentRow.Cells("CodEntidad").Value),
                Convert.ToString(Grilla.CurrentRow.Cells("CodSucEntidad").Value)
            })
        ElseIf quitarTodos Then
            For Each fila As DataGridViewRow In Grilla.Rows
                claves.Add(New String() {
                    Convert.ToString(fila.Cells("CodEntidad").Value),
                    Convert.ToString(fila.Cells("CodSucEntidad").Value)
                })
            Next
        Else
            For Each fila As DataGridViewRow In Grilla.Rows
                If Grilla.Columns.Contains("Chk") AndAlso
                    Convert.ToBoolean(fila.Cells("Chk").Value) Then
                    claves.Add(New String() {
                        Convert.ToString(fila.Cells("CodEntidad").Value),
                        Convert.ToString(fila.Cells("CodSucEntidad").Value)
                    })
                End If
            Next
        End If

        If claves.Count = 0 Then
            ToastNotification.Show(Me, "NO HAY ENTIDADES MARCADAS",
                                   My.Resources.cross, 2 * 1000,
                                   eToastGlowColor.Blue, eToastPosition.MiddleCenter)
            Return
        End If

        Dim mensaje As String = If(quitarUna,
                                   "¿Está seguro de quitar esta entidad?",
                                   "¿Está seguro de quitar las entidades seleccionadas?" &
                                   vbCrLf & "Registros: " & claves.Count)

        If MessageBoxEx.Show(Me, mensaje, "Quitar entidades",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <>
            DialogResult.Yes Then Return

        Dim condicion As String = Fx_Condicion_Claves(claves)
        Dim sql As New System.Text.StringBuilder()

        For Each codigoNodo As Integer In Fx_Lista_Nodos_Entidad()
            sql.AppendLine("DELETE FROM " & _Global_BaseBk & "Zw_Entidades_Asociacion")
            sql.AppendLine("WHERE Codigo_Nodo = '" & codigoNodo & "' And Para_filtro = 1")
            sql.AppendLine("And (" & condicion & ")")
        Next

        If Not _Sql.Ej_consulta_IDU(sql.ToString()) Then
            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema al quitar entidades",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        _Grabar = True
        Sb_Llenar_Tablas()
    End Sub

    Private Sub Btn_QuitarEntidades_Click(sender As Object, e As EventArgs) Handles Btn_QuitarEntidades.Click
        Sb_Quitar_Entidades(False, False)
    End Sub

    Private Sub Btn_Quitar_Marcados_Click(sender As Object, e As EventArgs) Handles Btn_Quitar_Marcados.Click
        Sb_Quitar_Entidades(False, False)
    End Sub

    Private Sub Btn_Quitar_Todo_Click(sender As Object, e As EventArgs) Handles Btn_Quitar_Todo.Click
        Sb_Quitar_Entidades(True, False)
    End Sub

    Private Sub Btn_QuitarProducto_Click(sender As Object, e As EventArgs) Handles Btn_QuitarProducto.Click
        Sb_Quitar_Entidades(False, True)
    End Sub

    Private Sub Txt_Filtrar_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Filtrar.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim texto As String = Txt_Filtrar.Text.Replace("'", "''")
            _Dv.RowFilter =
                String.Format("CodEntidad + CodSucEntidad + Descripcion Like '%{0}%'", texto)
        End If
    End Sub

    Private Sub Txt_Filtrar_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Filtrar.ButtonCustom2Click
        Txt_Filtrar.Text = String.Empty
        _Dv.RowFilter = String.Empty
    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Excel.Click
        ExportarTabla_JetExcel_Tabla(_Dv.ToTable(), Me, "Ent_" & _Descripcion_Nodo)
    End Sub

    Private Sub Frm_Arbol_Asociacion_04_Entidades_x_class_KeyDown(
        sender As Object,
        e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Escape Then Close()
    End Sub

End Class
