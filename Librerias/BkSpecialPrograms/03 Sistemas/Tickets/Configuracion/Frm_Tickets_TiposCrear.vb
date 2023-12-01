Imports DevComponents.DotNetBar

Public Class Frm_Tickets_TiposCrear

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Area As Integer
    Dim _Id_Tipo As Integer

    Public Grabar As Boolean

    Public Property Row_Tipo As DataRow

    Public Sub New(_Id_Area As Integer, _Id_Tipo As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Area = _Id_Area
        Me._Id_Tipo = _Id_Tipo

        If CBool(_Id_Tipo) Then

            Consulta_sql = "Select  Tp.*,Isnull(Tf.NOKOFU,'') As 'Agente',Isnull(Gr.Grupo,'') As Grupo" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_Stk_Tipos Tp" & vbCrLf &
                           "Left Join TABFU Tf On Tf.KOFU = Tp.CodAgente" & vbCrLf &
                           "Left Join " & _Global_BaseBk & "Zw_Stk_Grupos Gr On Tp.Id_Grupo = Gr.Id" & vbCrLf &
                           "Where Tp.Id = " & _Id_Tipo
            Row_Tipo = _Sql.Fx_Get_DataRow(Consulta_sql)

        End If

    End Sub

    Private Sub Frm_Tickets_TiposCrear_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not IsNothing(Row_Tipo) Then

            With Row_Tipo

                Chk_Asignado.Checked = .Item("Asignado")
                Rdb_AsignadoAgente.Checked = .Item("AsignadoAgente")
                Rdb_AsignadoGrupo.Checked = .Item("AsignadoGrupo")

                Txt_Grupo.Tag = .Item("Id_Grupo")
                Txt_Grupo.Text = .Item("Grupo")
                Txt_Agente.Tag = .Item("CodAgente")
                Txt_Agente.Text = .Item("Agente")

                Txt_Tipo.Text = .Item("Tipo")

                Chk_ExigeProducto.Checked = .Item("ExigeProducto")
                Rdb_AjusInventario.Checked = .Item("AjusInventario")
                Rdb_RevInventario.Checked = .Item("RevInventario")
                Rdb_SobreStock.Checked = .Item("SobreStock")

            End With

        End If

        Txt_Agente.Enabled = Rdb_AsignadoAgente.Checked
        Txt_Grupo.Enabled = Rdb_AsignadoGrupo.Checked

        Me.ActiveControl = Txt_Tipo

    End Sub

    Private Sub Chk_ExigeProducto_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_ExigeProducto.CheckedChanged
        Panel_Productos.Enabled = Chk_ExigeProducto.Checked
        If Not Chk_ExigeProducto.Checked Then
            Rdb_AjusInventario.Checked = False
            Rdb_RevInventario.Checked = False
            Rdb_SobreStock.Checked = False
        End If
    End Sub

    Private Sub Btn_Crear_Agente_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Agente.Click

        If String.IsNullOrEmpty(Txt_Tipo.Text) Then
            MessageBoxEx.Show(Me, "Debe ingresar el tipo de requerimiento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Tipo.Focus()
            Return
        End If

        If Chk_ExigeProducto.Checked Then
            If Not Rdb_AjusInventario.Checked AndAlso Not Rdb_RevInventario.Checked AndAlso Not Rdb_SobreStock.Checked Then
                MessageBoxEx.Show(Me, "Debe marcar alguna de las opciones para la gestión con productos",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

        If Chk_Asignado.Checked Then
            If (Rdb_AsignadoGrupo.Checked AndAlso String.IsNullOrWhiteSpace(Txt_Grupo.Text)) Or
                  (Rdb_AsignadoAgente.Checked AndAlso String.IsNullOrWhiteSpace(Txt_Agente.Text)) Then

                MessageBoxEx.Show(Me, "Debe asignar un grupo de trabajo o agente para este requerimiento." & vbCrLf & vbCrLf &
                                  "Si no sabe a quien asignar esta labor debe dejar la casilla [ASIGNAR EL REQUERIMINETO A:] destickeada" & vbCrLf &
                                  "y el administrador del sistema redirigira el requerimiento a quien corresponda",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            'If Rdb_AsignadoAgente.Checked Then
            '    If String.IsNullOrWhiteSpace(Txt_Agente.Text) Then
            '        MessageBoxEx.Show(Me, "Debe asignar a un Agente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '        Return
            '    End If
            'End If

            'If Rdb_AsignadoGrupo.Checked Then
            '    If String.IsNullOrWhiteSpace(Txt_Grupo.Text) Then
            '        MessageBoxEx.Show(Me, "Debe asignar a un Grupo de trabajo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '        Return
            '    End If
            'End If

        End If

        If Not CBool(_Id_Tipo) Then

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stk_Tipos (Id_Area,Tipo) Values " &
                           "(" & _Id_Area & ",'" & Txt_Tipo.Text.Trim & "')"
            If Not _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Tipo) Then
                Return
            End If

        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tipos Set " &
                       "Tipo = '" & Txt_Tipo.Text.Trim & "'" & vbCrLf &
                       ",RevInventario = " & Convert.ToInt32(Rdb_RevInventario.Checked) & vbCrLf &
                       ",AjusInventario = " & Convert.ToInt32(Rdb_AjusInventario.Checked) & vbCrLf &
                       ",SobreStock = " & Convert.ToInt32(Rdb_SobreStock.Checked) & vbCrLf &
                       ",Asignado = " & Convert.ToInt32(Chk_Asignado.Checked) & vbCrLf &
                       ",AsignadoGrupo = " & Convert.ToInt32(Rdb_AsignadoGrupo.Checked) & vbCrLf &
                       ",AsignadoAgente = " & Convert.ToInt32(Rdb_AsignadoAgente.Checked) & vbCrLf &
                       ",Id_Grupo = " & Txt_Grupo.Tag & vbCrLf &
                       ",CodAgente = '" & Txt_Agente.Tag & "'" & vbCrLf &
                       "Where Id = " & _Id_Tipo

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Grabar = True
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Tipos Where Id = " & _Id_Tipo
        Row_Tipo = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not Grabar Then
            Return
        End If

        MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Close()

    End Sub

    Private Sub Txt_Grupo_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Grupo.ButtonCustomClick
        Dim Fm As New Frm_Tickets_Grupos
        Fm.ModoSeleccion = True
        Fm.ShowDialog(Me)
        If Not IsNothing(Fm.Row_Grupo) Then
            Txt_Grupo.Tag = Fm.Row_Grupo.Item("Id")
            Txt_Grupo.Text = Fm.Row_Grupo.Item("Grupo")
        End If
        Fm.Dispose()
    End Sub

    Private Sub Txt_Grupo_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Grupo.ButtonCustom2Click
        Txt_Grupo.Tag = String.Empty
        Txt_Grupo.Text = String.Empty
    End Sub

    Private Sub Txt_Agente_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Agente.ButtonCustomClick
        Dim _Sql_Filtro_Condicion_Extra = "And KOFU In (Select CodAgente From " & _Global_BaseBk & "Zw_Stk_AgentesVsTipos Where Id_Area = " & _Id_Area & " And Id_Tipo = " & Txt_Tipo.Tag & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random,
                               _Sql_Filtro_Condicion_Extra, False, False, True) Then
            Txt_Agente.Tag = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Txt_Agente.Text = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Descripcion")
        End If
    End Sub

    Private Sub Txt_Agente_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Agente.ButtonCustom2Click
        Txt_Agente.Tag = String.Empty
        Txt_Agente.Text = String.Empty
    End Sub

    Private Sub Rdb_AsignadoGrupo_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_AsignadoGrupo.CheckedChanged
        If Rdb_AsignadoGrupo.Checked Then
            Txt_Agente.Tag = String.Empty
            Txt_Agente.Text = String.Empty
        End If
        Txt_Grupo.Enabled = Rdb_AsignadoGrupo.Checked
    End Sub

    Private Sub Rdb_AsignadoAgente_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_AsignadoAgente.CheckedChanged
        If Rdb_AsignadoAgente.Checked Then
            Txt_Grupo.Tag = 0
            Txt_Grupo.Text = String.Empty
        End If
        Txt_Agente.Enabled = Rdb_AsignadoAgente.Checked
    End Sub

    Private Sub Chk_Asignado_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Asignado.CheckedChanged

        If Chk_Asignado.Checked Then

            If String.IsNullOrWhiteSpace(Txt_Tipo.Text) Then
                MessageBoxEx.Show(Me, "Falta el tipo de requerimiento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Chk_Asignado.Checked = False
                Return
            End If

        Else
            Txt_Grupo.Tag = 0
            Txt_Agente.Tag = String.Empty
            Txt_Grupo.Text = String.Empty
            Txt_Agente.Text = String.Empty
            Rdb_AsignadoAgente.Checked = False
            Rdb_AsignadoGrupo.Checked = False
            Txt_Grupo.Enabled = False
            Txt_Agente.Enabled = False
        End If
        Rdb_AsignadoAgente.Enabled = Chk_Asignado.Checked
        Rdb_AsignadoGrupo.Enabled = Chk_Asignado.Checked

    End Sub
End Class
