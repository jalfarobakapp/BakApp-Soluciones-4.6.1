Imports DevComponents.DotNetBar

Public Class Frm_Tickets_Grupos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Grupos As DataTable
    Dim _Tbl_Agentes As DataTable

    Public Property ModoSeleccion As Boolean
    Public Property Row_Grupo As DataRow
    Public Property GrupoSeleccionado As String
    Public Property Sql_Filtro_Condicion_Extra As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Grupos, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Agentes, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Tipos, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Tickets_Grupos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        If Not ModoSeleccion Then
            AddHandler Grilla_Grupos.MouseDown, AddressOf Sb_Grilla_Grupos_MouseDown
            AddHandler Grilla_Agentes.MouseDown, AddressOf Sb_Grilla_Agentes_MouseDown
        End If

        AddHandler Grilla_Grupos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Agentes.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Btn_Crear_Grupo.Visible = Not ModoSeleccion
        Btn_SeleccionarGrupo.Visible = ModoSeleccion

        Me.ActiveControl = Txt_Buscador

        If ModoSeleccion Then
            BuscarDatoEnGrilla(GrupoSeleccionado, "Grupo", Grilla_Grupos)
        End If

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Texto_Busqueda As String = Txt_Buscador.Text.Trim

        Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(_Texto_Busqueda), "Gr.Grupo+Isnull(NOKOFU,'') Like '%")

        Consulta_sql = "Select Distinct Gr.* From " & _Global_BaseBk & "Zw_Stk_Grupos Gr" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Stk_GrupoVsAgente GvsA On GvsA.Id_Grupo = Gr.Id" & vbCrLf &
                       "Left Join TABFU Tf On Tf.KOFU = GvsA.CodAgente" & vbCrLf &
                       "Where Gr.Grupo+Isnull(NOKOFU,'') Like '%" & _Cadena & "%'" & vbCrLf &
                       Sql_Filtro_Condicion_Extra & vbCrLf &
                       "Order by Gr.Grupo"
        _Tbl_Grupos = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla_Grupos

            .DataSource = _Tbl_Grupos

            OcultarEncabezadoGrilla(Grilla_Grupos)

            Dim _DisplayIndex = 0

            .Columns("Grupo").Visible = True
            .Columns("Grupo").HeaderText = "Descripción"
            .Columns("Grupo").Width = 440
            .Columns("Grupo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Crear_Grupo_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Grupo.Click

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Agentes", "Activo = 1")

        If Not CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No existen agentes que asociar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Aceptar As Boolean
        Dim _Grupo As String

        _Aceptar = InputBox_Bk(Me, "Ingrese el nombre del Grupo de trabajo", "Crear Grupo de trabajo", _Grupo, False, _Tipo_Mayus_Minus.Mayusculas, 50, True)

        If Not _Aceptar Then
            Return
        End If

        _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Grupos", "Grupo = '" & _Grupo & "'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "El nombre del Grupo ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Call Btn_Crear_Grupo_Click(Nothing, Nothing)
            Return
        End If

        MessageBoxEx.Show(Me, "A continuación debera asociar agentes al grupo", "Asociar agentes",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)

        Dim _Sql_Filtro_Condicion_Extra = "And KOFU In " &
                                           "(Select CodAgente From " & _Global_BaseBk & "Zw_Stk_Agentes " &
                                           "Where Activo = 1)-- And CodAgente Not In (Select CodAgente From " & _Global_BaseBk & "Zw_Stk_GrupoVsAgente))"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra, False, False) Then
            _Tbl_Agentes = _Filtrar.Pro_Tbl_Filtro
        End If

        If IsNothing(_Tbl_Agentes) Then
            MessageBoxEx.Show(Me, "No puede crear un grupo sin agentes asociados", "Validación", MessageBoxButtons.OK,
                              MessageBoxIcon.Stop)
            Return
        End If

        Dim _Id_Grupo As Integer

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stk_Grupos (Grupo) Values ('" & _Grupo & "')"
        If _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Grupo) Then

            Consulta_sql = String.Empty

            For Each _Fila As DataRow In _Tbl_Agentes.Rows

                Dim _CodAgente As String = _Fila.Item("Codigo")
                Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_Stk_GrupoVsAgente (Id_Grupo,CodAgente) Values (" & _Id_Grupo & ",'" & _CodAgente & "')" & vbCrLf

            Next

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                Me.Sb_Actualizar_Grilla()
                BuscarDatoEnGrilla(_Grupo, "Grupo", Grilla_Grupos)

            End If

        End If

    End Sub

    Private Sub Btn_Mnu_EditarOferta_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_EditarOferta.Click

        Dim _Fila As DataGridViewRow = Grilla_Grupos.CurrentRow

        Dim _Id_Grupo As Integer = _Fila.Cells("Id").Value
        Dim _Grupo As String = _Fila.Cells("Grupo").Value
        Dim _Grupo_Old As String = _Fila.Cells("Grupo").Value

        Dim _Aceptar As Boolean

        _Aceptar = InputBox_Bk(Me, "Ingrese el nombre del Grupo de trabajo", "Editar nombre del Grupo", _Grupo, False,
                               _Tipo_Mayus_Minus.Mayusculas, 50, True)

        If Not _Aceptar Then
            Return
        End If

        If _Grupo.Trim = _Grupo_Old.Trim Then
            Return
        End If

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Grupos", "Grupo = '" & _Grupo & "' And Id <> " & _Id_Grupo)

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "Al nombre del Grupo ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Call Btn_Mnu_EditarOferta_Click(Nothing, Nothing)
            Return
        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Grupos Set Grupo = '" & _Grupo.Trim & "' Where Id = " & _Id_Grupo
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            _Fila.Cells("Grupo").Value = _Grupo
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub Btn_Mnu_AsociarProductos_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_AsociarProductos.Click

        Dim _FilaArea As DataGridViewRow = Grilla_Grupos.CurrentRow

        Dim _Id_Grupo As Integer = _FilaArea.Cells("Id").Value
        Dim _Tbl_Agentes As DataTable

        Dim _Sql_Filtro_Condicion_Extra = "And KOFU In " &
                                           "(Select CodAgente From " & _Global_BaseBk & "Zw_Stk_Agentes " &
                                           "Where Activo = 1 And CodAgente Not In (Select CodAgente From " & _Global_BaseBk & "Zw_Stk_GrupoVsAgente Where Id_Grupo = " & _Id_Grupo & "))"

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
            Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_Stk_GrupoVsAgente (Id_Grupo,CodAgente) Values (" & _Id_Grupo & ",'" & _CodFuncionario & "')" & vbCrLf

        Next

        If String.IsNullOrEmpty(Consulta_sql) Then
            Return
        End If

        _Sql.Ej_consulta_IDU(Consulta_sql)

        Call Grilla_Grupos_CellEnter(Nothing, Nothing)

    End Sub

    Private Sub Btn_Mnu_QuitarProducto_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_QuitarProducto.Click

        Dim _Fila As DataGridViewRow = Grilla_Agentes.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value

        If MessageBoxEx.Show(Me, "¿Confirma quitar este Agente del Grupo de trabajo?", "Quitar Agente",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_GrupoVsAgente Where Id = " & _Id
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Grilla_Agentes.Rows.Remove(_Fila)
        End If

    End Sub

    Private Sub Grilla_Grupos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Grupos.CellEnter

        Dim _FilaArea As DataGridViewRow = Grilla_Grupos.CurrentRow
        Dim _Id_Grupo As Integer = _FilaArea.Cells("Id").Value

        Consulta_sql = "Select Gr.*,Tf.NOKOFU From " & _Global_BaseBk & "Zw_Stk_GrupoVsAgente Gr" & vbCrLf &
                       "Left Join TABFU Tf On Tf.KOFU = Gr.CodAgente" & vbCrLf &
                       "Where Id_Grupo = " & _Id_Grupo & vbCrLf &
                       "Order by Tf.NOKOFU"

        _Tbl_Agentes = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla_Agentes

            .DataSource = _Tbl_Agentes

            OcultarEncabezadoGrilla(Grilla_Agentes)

            Dim _DisplayIndex = 0

            .Columns("NOKOFU").Visible = True
            .Columns("NOKOFU").HeaderText = "Nombre del agente"
            .Columns("NOKOFU").Width = 440
            .Columns("NOKOFU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Consulta_sql = "Select Tipo,Area" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stk_Tipos Tp" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Stk_Areas Ar On Ar.Id = Tp.Id_Area" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Stk_Grupos Gr On Gr.Id = Tp.Id_Grupo" & vbCrLf &
                       "Where Id_Grupo = " & _Id_Grupo

        Dim _Tbl_Tipos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla_Tipos

            .DataSource = _Tbl_Tipos

            OcultarEncabezadoGrilla(Grilla_Tipos)

            Dim _DisplayIndex = 0

            .Columns("Area").Visible = True
            .Columns("Area").HeaderText = "Area"
            .Columns("Area").Width = 200
            .Columns("Area").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Tipo").Visible = True
            .Columns("Tipo").HeaderText = "Tipo"
            .Columns("Tipo").Width = 240
            .Columns("Tipo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Sb_Grilla_Grupos_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
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

    Private Sub Sb_Grilla_Agentes_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
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

    Private Sub Txt_Buscador_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Buscador.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Txt_Buscador_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Buscador.ButtonCustom2Click
        Txt_Buscador.Text = String.Empty
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Grilla_Grupos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Grupos.CellDoubleClick

        If Not ModoSeleccion Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla_Grupos.CurrentRow
        Dim _Id_Grupo As Integer = _Fila.Cells("Id").Value

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Grupos Where Id = " & _Id_Grupo
        Row_Grupo = _Sql.Fx_Get_DataRow(Consulta_sql)
        Me.Close()

    End Sub

    Private Sub Btn_SeleccionarGrupo_Click(sender As Object, e As EventArgs) Handles Btn_SeleccionarGrupo.Click
        Call Grilla_Grupos_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Grilla_Grupos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Grupos.CellClick
        Btn_SeleccionarGrupo.Enabled = ModoSeleccion
    End Sub

    Private Sub Grilla_Grupos_Leave(sender As Object, e As EventArgs) Handles Grilla_Grupos.Leave
        Btn_SeleccionarGrupo.Enabled = False
    End Sub

    Private Sub Btn_Mnu_EliminarGrupo_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_EliminarGrupo.Click

        Dim _Fila As DataGridViewRow = Grilla_Grupos.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Tickets", "Id_Grupo = " & _Id & " And Estado = 'ABIE'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No se puede eliminar este grupo ya que tiene ticket asociados que aun estan abiertos.",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Confirma eliminar el grupo?", "Quitar tipo de requerimiento",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim _Cl_Tickets As New Cl_Tickets
        _Mensaje = _Cl_Tickets.Fx_Eliminar_Grupo(_Id)

        If _Mensaje.EsCorrecto Then
            Grilla_Grupos.Rows.Remove(_Fila)
        Else
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Txt_Buscador_TextChanged(sender As Object, e As EventArgs) Handles Txt_Buscador.TextChanged
        If String.IsNullOrWhiteSpace(Txt_Buscador.Text) Then
            Sb_Actualizar_Grilla()
        End If
    End Sub


End Class
