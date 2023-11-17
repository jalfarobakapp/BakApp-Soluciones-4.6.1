Imports DevComponents.DotNetBar

Public Class Frm_Tickets_Agentes

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Agentes As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Tickets_Agentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla_Agentes.MouseDown, AddressOf Sb_Grilla_Agentes_MouseDown
        AddHandler Grilla_Tipos.MouseDown, AddressOf Sb_Grilla_Tipos_MouseDown

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Btn_Crear_Agente_Click(sender As Object, e As EventArgs)

    End Sub

    Sub Sb_Actualizar_Grilla()

        'Dim _Texto_Busqueda As String = Txt_Buscador.Text.Trim
        'Dim _Condicion As String = String.Empty

        'Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(_Texto_Busqueda), "CODIGO+DESCRIPTOR Like '%")

        'If Not String.IsNullOrWhiteSpace(Txt_BuscaXProducto.Text) Then
        '_Condicion = "And CODIGO In (Select CODIGO From MAEDRES Where ELEMENTO = '" & Txt_BuscaXProducto.Text & "')"
        'End If

        Consulta_sql = "Select Ag.*,NOKOFU From " & _Global_BaseBk & "Zw_Stk_Agentes Ag" & vbCrLf &
                       "Left Join TABFU On KOFU = Ag.CodAgente"
        _Tbl_Agentes = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Agentes

            .DataSource = _Tbl_Agentes

            OcultarEncabezadoGrilla(Grilla_Agentes)

            Dim _DisplayIndex = 0

            .Columns("CodAgente").Visible = True
            .Columns("CodAgente").HeaderText = "Código"
            .Columns("CodAgente").Width = 50
            .Columns("CodAgente").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOFU").Visible = True
            .Columns("NOKOFU").HeaderText = "Nombre de agente"
            .Columns("NOKOFU").Width = 390
            .Columns("NOKOFU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Grilla_Agentes_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Agentes.CellEnter

        Try

        Catch ex As Exception

        End Try

        Dim _Fila As DataGridViewRow = Grilla_Agentes.CurrentRow

        If IsNothing(_Fila) Then
            Return
        End If

        Dim _CodAgente As String = _Fila.Cells("CodAgente").Value

        Consulta_sql = "Select Ar.Area,Tp.Tipo From " & _Global_BaseBk & "Zw_Stk_AgentesVsTipos Ag" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Stk_Areas Ar On Ar.Id = Ag.Id_Area" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Stk_Tipos Tp On Tp.Id = Ag.Id_Tipo" & vbCrLf &
                       "Where CodAgente = '" & _CodAgente & "'"

        Dim _Tbl_Tipos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Tipos

            .DataSource = _Tbl_Tipos

            OcultarEncabezadoGrilla(Grilla_Tipos)

            Dim _DisplayIndex = 0

            .Columns("Area").Visible = True
            .Columns("Area").HeaderText = "Area"
            .Columns("Area").Width = 150
            .Columns("Area").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Tipo").Visible = True
            .Columns("Tipo").HeaderText = "Tipo"
            .Columns("Tipo").Width = 290
            .Columns("Tipo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Crear_Agente_Click_1(sender As Object, e As EventArgs) Handles Btn_Crear_Agente.Click

        Dim _Tbl_Agentes As DataTable

        Dim _Sql_Filtro_Condicion_Extra = "And KOFU Not In (Select CodAgente From " & _Global_BaseBk & "Zw_Stk_Agentes)"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra, False, False) Then
            _Tbl_Agentes = _Filtrar.Pro_Tbl_Filtro
        Else
            Return
        End If

        Consulta_sql = String.Empty

        For Each _Fila As DataRow In _Tbl_Agentes.Rows

            Dim _CodFuncionario As String = _Fila.Item("Codigo")
            Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_Stk_Agentes (CodAgente,Activo) Values ('" & _CodFuncionario & "',1)" & vbCrLf

        Next

        If String.IsNullOrEmpty(Consulta_sql) Then
            Return
        End If

        _Sql.Ej_consulta_IDU(Consulta_sql)
        Sb_Actualizar_Grilla()

        Call Grilla_Agentes_CellEnter(Nothing, Nothing)

    End Sub

    Private Sub Btn_Mnu_AsociarTipos_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_AsociarTipos.Click

        Dim _Fila As DataGridViewRow = Grilla_Agentes.CurrentRow
        Dim _CodAgente As String = _Fila.Cells("CodAgente").Value
        Dim _Id_Area As Integer = Fx_Buscar_Area()

        If CBool(_Id_Area) Then

            Dim _Tbl_Tipos As DataTable = Fx_Traer_Tipos(_Id_Area, _CodAgente)

            If IsNothing(_Tbl_Tipos) Then
                Return
            End If

            Consulta_sql = String.Empty

            For Each _Fl As DataRow In _Tbl_Tipos.Rows

                Dim _Id_Tipo As Integer = _Fl.Item("Codigo")

                Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_Stk_AgentesVsTipos (Id_Area,Id_Tipo,CodAgente) Values (" & _Id_Area & "," & _Id_Tipo & ",'" & _CodAgente & "')" & vbCrLf

            Next

            If Not String.IsNullOrEmpty(Consulta_sql) Then
                _Sql.Ej_consulta_IDU(Consulta_sql)
                Call Grilla_Agentes_CellEnter(Nothing, Nothing)
            End If

        End If

    End Sub

    Function Fx_Traer_Tipos(_Id_Area As Integer, _CodAgente As String) As DataTable

        Dim _Tbl_Tipos As DataTable
        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_Stk_Tipos"
        _Filtrar.Campo = "Id"
        _Filtrar.Descripcion = "Tipo"
        _Filtrar.Pro_Nombre_Encabezado_Informe = "TIPOS DE REQUERIMIENTO"

        If _Filtrar.Fx_Filtrar(_Tbl_Tipos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra,
                               "And Id In (Select Id From " & _Global_BaseBk & "Zw_Stk_Tipos Where Id_Area = " & _Id_Area & ")" & vbCrLf &
                               "And Id Not In (Select Id_Tipo From " & _Global_BaseBk & "Zw_Stk_AgentesVsTipos Where CodAgente = '" & _CodAgente & "')",
                               False, False, False, False,, False) Then

            _Tbl_Tipos = _Filtrar.Pro_Tbl_Filtro

        End If

        Return _Tbl_Tipos

    End Function

    Function Fx_Buscar_Area() As Integer

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_Stk_Areas"
        _Filtrar.Campo = "Id"
        _Filtrar.Descripcion = "Area"
        _Filtrar.Pro_Nombre_Encabezado_Informe = "AREA/DEPARTAMENTO"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "", False, False, True, False,, False) Then

            Return _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")

        End If

    End Function

    Private Sub Sb_Grilla_Agentes_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
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

    Private Sub Sb_Grilla_Tipos_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Btn_Mnu_QuitarTipo)
                End If
            End With
        End If
    End Sub

    Private Sub Btn_Mnu_EliminarAgente_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_EliminarAgente.Click

        Dim _Fila As DataGridViewRow = Grilla_Agentes.CurrentRow
        Dim _CodAgente As String = _Fila.Cells("CodAgente").Value

        If MessageBoxEx.Show(Me, "¿Confirma eliminar este Agente?" & vbCrLf &
                             "Se perdera toda su configuración", "Quitar Agente",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Agentes Where CodAgente = '" & _CodAgente & "'" & vbCrLf &
                       "Delete " & _Global_BaseBk & "Zw_Stk_AgentesVsTipos Where CodAgente = '" & _CodAgente & "'"
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            MessageBoxEx.Show(Me, "El Agente se elimino correctamente", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Btn_Mnu_QuitarTipo_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_QuitarTipo.Click
        Dim _Fila As DataGridViewRow = Grilla_Tipos.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value

        If MessageBoxEx.Show(Me, "¿Confirma quitar este Tipo de Ticket?", "Quitar Tipo",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_AgentesVsTipos Where Id = " & _Id
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Grilla_Tipos.Rows.Remove(_Fila)
        End If
    End Sub
End Class
