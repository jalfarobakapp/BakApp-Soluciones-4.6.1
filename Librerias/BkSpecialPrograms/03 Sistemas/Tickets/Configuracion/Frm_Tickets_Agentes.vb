Imports DevComponents.DotNetBar

Public Class Frm_Tickets_Agentes

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Agentes As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Agentes, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Tipos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

    End Sub

    Private Sub Frm_Tickets_Agentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla_Agentes.MouseDown, AddressOf Sb_Grilla_Agentes_MouseDown
        AddHandler Grilla_Tipos.MouseDown, AddressOf Sb_Grilla_Tipos_MouseDown

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Btn_Crear_Agente_Click(sender As Object, e As EventArgs)

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Texto_Busqueda As String = Txt_Buscador.Text.Trim
        Dim _Condicion As String = String.Empty

        Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(_Texto_Busqueda), "CodAgente+NOKOFU Like '%")

        Consulta_sql = "Select Ag.*,NOKOFU From " & _Global_BaseBk & "Zw_Stk_Agentes Ag" & vbCrLf &
                       "Left Join TABFU On KOFU = Ag.CodAgente" & vbCrLf &
                       "Where CodAgente+NOKOFU Like '%" & _Cadena & "%'"
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

        Dim _Fila As DataGridViewRow = Grilla_Agentes.CurrentRow

        If IsNothing(_Fila) Then
            Return
        End If

        Dim _CodAgente As String = _Fila.Cells("CodAgente").Value

        'Consulta_sql = "Select Ag.Id,Ag.Id_Area,Ag.Id_Tipo,Ar.Area,Tp.Tipo From " & _Global_BaseBk & "Zw_Stk_AgentesVsTipos Ag" & vbCrLf &
        '               "Left Join " & _Global_BaseBk & "Zw_Stk_Areas Ar On Ar.Id = Ag.Id_Area" & vbCrLf &
        '               "Left Join " & _Global_BaseBk & "Zw_Stk_Tipos Tp On Tp.Id = Ag.Id_Tipo" & vbCrLf &
        '               "Where Ag.CodAgente = '" & _CodAgente & "'" & vbCrLf &
        '               "Order By Ar.Area,Tp.Tipo"

        'Consulta_sql = "SELECT Tipo,Area" & vbCrLf &
        '               "From " & _Global_BaseBk & "Zw_Stk_Tipos Tp" & vbCrLf &
        '               "Left Join " & _Global_BaseBk & "Zw_Stk_Areas Ar On Ar.Id = Tp.Id_Area" & vbCrLf &
        '               "Where Id_Grupo In (Select Id_Grupo From " & _Global_BaseBk & "Zw_Stk_GrupoVsAgente " &
        '               "Where CodAgente = '" & _CodAgente & "') Or CodAgente = '" & _CodAgente & "'"

        Consulta_sql = "Select Tipo,Area,'Como Agente' As Asociado" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stk_Tipos Tp" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Stk_Areas Ar On Ar.Id = Tp.Id_Area" & vbCrLf &
                       "Where CodAgente = '" & _CodAgente & "'" & vbCrLf &
                       "Union" & vbCrLf &
                       "Select Tipo,Area,'En Grupo: '+Grupo As Asociado" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stk_Tipos Tp" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Stk_Areas Ar On Ar.Id = Tp.Id_Area" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Stk_Grupos Gr On Gr.Id = Tp.Id_Grupo" & vbCrLf &
                       "Where Id_Grupo In (Select Id_Grupo From " & _Global_BaseBk & "Zw_Stk_GrupoVsAgente Where CodAgente = '" & _CodAgente & "')"

        Dim _Tbl_Tipos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Tipos

            .DataSource = _Tbl_Tipos

            OcultarEncabezadoGrilla(Grilla_Tipos)

            Dim _DisplayIndex = 0

            .Columns("Area").Visible = True
            .Columns("Area").HeaderText = "Area"
            .Columns("Area").Width = 140
            .Columns("Area").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Tipo").Visible = True
            .Columns("Tipo").HeaderText = "Tipo"
            .Columns("Tipo").Width = 200
            .Columns("Tipo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Asociado").Visible = True
            .Columns("Asociado").HeaderText = "Asociado"
            .Columns("Asociado").Width = 150
            .Columns("Asociado").DisplayIndex = _DisplayIndex
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

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Tipos", "")

        If Not CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No existen tipos de requerimiento que asociar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

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
                    ShowContextMenu(Menu_Contextual_02)
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

        Dim _Fila_Ag As DataGridViewRow = Grilla_Agentes.CurrentRow
        Dim _CodAgente As String = _Fila_Ag.Cells("CodAgente").Value

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Tipos", "CodAgente = '" & _CodAgente & "'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No se puede quitar este tipo de requerimiento." & vbCrLf &
                              "El Agente esta asociado por defecto al tipo de requerimiento.",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

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

    Private Sub Txt_Buscador_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Buscador.KeyDown

        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Txt_Buscador_TextChanged(sender As Object, e As EventArgs) Handles Txt_Buscador.TextChanged
        If String.IsNullOrWhiteSpace(Txt_Buscador.Text) Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Txt_Buscador_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Buscador.ButtonCustom2Click
        Txt_Buscador.Text = String.Empty
        Sb_Actualizar_Grilla()
    End Sub
End Class
