Imports BkSpecialPrograms.Tickets_Db
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.SuperGrid

Public Class Frm_Tickets_TiposCrear

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Grabar As Boolean
    Dim Cl_Tickets As New Cl_Tickets

    Public Property _Row_Tipo As DataRow
    Public Property Cl_Tipo As New Tickets_Db.Tickets_Tipo

    Public Sub New(_Id_Area As Integer, _Id_Tipo As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Cl_Tipo = Cl_Tickets.Fx_Llenar_Tipo(_Id_Area, _Id_Tipo)

    End Sub

    Private Sub Frm_Tickets_TiposCrear_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Areas Where Id = " & Cl_Tipo.Id_Area
        Dim _Row_Area As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Lbl_Area.Text = "AREA: " & _Row_Area.Item("AREA")

        With Cl_Tipo

            Txt_Tipo.Tag = .Id
            Txt_Tipo.Text = .Tipo

            Chk_Asignado.Checked = .Asignado
            Rdb_AsignadoAgente.Checked = .AsignadoAgente
            Rdb_AsignadoGrupo.Checked = .AsignadoGrupo

            Txt_Grupo.Tag = .Id_Grupo
            Txt_Grupo.Text = .Grupo
            Txt_Agente.Tag = .CodAgente
            Txt_Agente.Text = .Agente

            Chk_ExigeProducto.Checked = .ExigeProducto
            Chk_Inc_Cantidades.Checked = .Inc_Cantidades
            Chk_Inc_Fecha.Checked = .Inc_Fecha
            Chk_Inc_Hora.Checked = .Inc_Hora

            Txt_Area_Cie.Tag = .CieTk_Id_Area
            Txt_Area_Cie.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Stk_Areas", "Area", "Id = " & .CieTk_Id_Area)

            Txt_Tipo_Cie.Tag = .CieTk_Id_Area
            Txt_Tipo_Cie.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Stk_Tipos", "Tipo", "Id = " & .CieTk_Id_Tipo)

            Chk_BodModalXDefecto.Checked = .BodModalXDefecto
            Chk_PreguntaCreaNewTicket.Checked = .PreguntaCreaNewTicket
            Chk_CerrarAgenteSinPerm.Checked = .CerrarAgenteSinPerm
            Txt_RespuestaXDefecto.Text = .RespuestaXDefecto

        End With

        Txt_Agente.Enabled = Rdb_AsignadoAgente.Checked
        Txt_Grupo.Enabled = Rdb_AsignadoGrupo.Checked

        Me.ActiveControl = Txt_Tipo

        AddHandler Chk_Asignado.CheckedChanged, AddressOf Chk_Asignado_CheckedChanged

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Tickets", "Estado = 'ABIE' And Id_Tipo = " & Cl_Tipo.Id)

        If CBool(_Reg) Then
            Txt_Tipo.Enabled = False
            Chk_ExigeProducto.Enabled = False
            Panel_Productos.Enabled = False
            Chk_Asignado.Enabled = False
        End If

        Panel_Productos.Enabled = Chk_ExigeProducto.Checked
        Chk_Inc_Cantidades.Enabled = Chk_ExigeProducto.Checked
        Chk_Inc_Fecha.Enabled = Chk_ExigeProducto.Checked
        Chk_Inc_Hora.Enabled = Chk_ExigeProducto.Checked
        Chk_BodModalXDefecto.Enabled = Chk_ExigeProducto.Checked

    End Sub

    Private Sub Chk_ExigeProducto_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_ExigeProducto.CheckedChanged
        Panel_Productos.Enabled = Chk_ExigeProducto.Checked
        Chk_Inc_Cantidades.Checked = Chk_ExigeProducto.Checked
        Chk_Inc_Fecha.Checked = Chk_ExigeProducto.Checked
        Chk_Inc_Hora.Checked = Chk_ExigeProducto.Checked
        Chk_BodModalXDefecto.Enabled = Chk_ExigeProducto.Checked
        Chk_BodModalXDefecto.Checked = Chk_ExigeProducto.Checked
    End Sub

    Private Sub Btn_Crear_Tipo_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Tipo.Click

        Dim _Editar As Boolean = CBool(Cl_Tipo.Id)

        'If _Editar Then

        '    Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Tickets", "Estado = 'ABIE' And Id_Tipo = " & _Id_Tipo)

        '    If CBool(_Reg) Then
        '        MessageBoxEx.Show(Me, "Existen Tickets que están abierto y usan este tipo de requerimiento." & vbCrLf &
        '                      "No es posible editar el tipo de requerimiento hasta que todos los Tickets que lo usan estén cerrados" & vbCrLf & vbCrLf &
        '                      "Los dato no han sido modificados",
        '                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '        Me.Close()
        '        Return
        '    End If

        'End If

        If String.IsNullOrEmpty(Txt_Tipo.Text) Then
            MessageBoxEx.Show(Me, "Debe ingresar el tipo de requerimiento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Tipo.Focus()
            Return
        End If

        If Not String.IsNullOrEmpty(Txt_Area_Cie.Text) AndAlso String.IsNullOrEmpty(Txt_Tipo_Cie.Text) Then
            MessageBoxEx.Show(Me, "Debe ingresar el Tipo (Cierre Ticket)", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Tipo.Focus()
            Return
        End If

        'If Chk_ExigeProducto.Checked Then
        '    If Not Rdb_AjusInventario.Checked AndAlso Not Rdb_RevInventario.Checked AndAlso Not Rdb_SobreStock.Checked Then
        '        MessageBoxEx.Show(Me, "Debe marcar alguna de las opciones para la gestión con productos",
        '                          "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '        Return
        '    End If
        'End If

        If Chk_Asignado.Checked Then

            If (Not Rdb_AsignadoGrupo.Checked AndAlso Not Rdb_AsignadoAgente.Checked) Or
                (Rdb_AsignadoGrupo.Checked AndAlso String.IsNullOrWhiteSpace(Txt_Grupo.Text)) Or
                  (Rdb_AsignadoAgente.Checked AndAlso String.IsNullOrWhiteSpace(Txt_Agente.Text)) Then

                MessageBoxEx.Show(Me, "Debe asignar un grupo de trabajo o agente para este requerimiento." & vbCrLf & vbCrLf &
                                  "Si no sabe a quien asignar esta labor debe dejar la casilla [ASIGNAR EL REQUERIMINETO A:] destickeada" & vbCrLf &
                                  "y el administrador del sistema redirigirá el requerimiento a quien corresponda",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        End If

        With Cl_Tipo

            .Tipo = Txt_Tipo.Text.Trim
            .Asignado = Chk_Asignado.Checked
            .AsignadoAgente = Rdb_AsignadoAgente.Checked
            .AsignadoGrupo = Rdb_AsignadoGrupo.Checked
            .CodAgente = Txt_Agente.Tag
            .Id_Grupo = Txt_Grupo.Tag
            .ExigeProducto = Chk_ExigeProducto.Checked
            .Inc_Cantidades = Chk_Inc_Cantidades.Checked
            .Inc_Fecha = Chk_Inc_Fecha.Checked
            .Inc_Hora = Chk_Inc_Hora.Checked
            .CieTk_Id_Area = Val(Txt_Area_Cie.Tag)
            .CieTk_Id_Tipo = Val(Txt_Tipo_Cie.Tag)

            .BodModalXDefecto = Chk_BodModalXDefecto.Checked
            .PreguntaCreaNewTicket = Chk_PreguntaCreaNewTicket.Checked
            .CerrarAgenteSinPerm = Chk_CerrarAgenteSinPerm.Checked
            .RespuestaXDefecto = Txt_RespuestaXDefecto.Text

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Tipos", "Tipo = '" & .Tipo & "' And Id <> " & .Id)

            If CBool(_Reg) Then
                MessageBoxEx.Show(Me, "Ya existe un tipo de requerimiento con este nombre." & vbCrLf &
                                  "Los nombre de los tipos de requerimientos son únicos por sistema",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        End With

        Dim _Mensaje_Ticket As Mensaje_Ticket = Cl_Tickets.Fx_Grabar_Tipo(Cl_Tipo)

        If _Mensaje_Ticket.EsCorrecto Then

            Grabar = True

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Tipos Where Id = " & _Mensaje_Ticket.New_Id
            _Row_Tipo = _Sql.Fx_Get_DataRow(Consulta_sql)

            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else

            MessageBoxEx.Show(Me, _Mensaje_Ticket.Mensaje, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        Grabar = True
        Me.Close()

    End Sub

    Function Fx_Asignar_Agente(_Id_Area As Integer, _Id_Tipo As Integer, _CodAgente As String) As String

        Dim _Sqr As String

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_AgentesVsTipos",
                                                       "Id_Area = " & _Id_Area & " And Id_Tipo = " & _Id_Tipo & " And CodAgente = '" & _CodAgente & "'")

        If Not CBool(_Reg) Then
            _Sqr = "Insert Into " & _Global_BaseBk & "Zw_Stk_AgentesVsTipos (Id_Area,Id_Tipo,CodAgente) Values " &
           "(" & _Id_Area & "," & _Id_Tipo & ",'" & _CodAgente & "')" & vbCrLf
        End If

        Return _Sqr

    End Function

    Private Sub Txt_Grupo_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Grupo.ButtonCustomClick

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Grupos",
                                                       "Id In (Select Id_Grupo From " & _Global_BaseBk & "Zw_Stk_GrupoVsAgente)")

        If Not CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No existen grupos para asociar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_Tickets_Grupos
        Fm.ModoSeleccion = True
        Fm.GrupoSeleccionado = Txt_Grupo.Text
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

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Agentes", "")

        If Not CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No existen agentes que asociar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Sql_Filtro_Condicion_Extra = "And KOFU In (Select CodAgente From " & _Global_BaseBk & "Zw_Stk_Agentes)"

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

    Private Sub Chk_Asignado_CheckedChanged(sender As Object, e As EventArgs)

        'If Not Chk_Asignado.Checked Then

        '    If String.IsNullOrWhiteSpace(Txt_Tipo.Text) Then
        '        MessageBoxEx.Show(Me, "Falta el tipo de requerimiento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '        Chk_Asignado.Checked = False
        '        Return
        '    End If

        'End If

        Txt_Grupo.Tag = 0
        Txt_Agente.Tag = String.Empty
        Txt_Grupo.Text = String.Empty
        Txt_Agente.Text = String.Empty
        Rdb_AsignadoAgente.Checked = False
        Rdb_AsignadoGrupo.Checked = False
        Txt_Grupo.Enabled = False
        Txt_Agente.Enabled = False

        Rdb_AsignadoAgente.Enabled = Chk_Asignado.Checked
        Rdb_AsignadoGrupo.Enabled = Chk_Asignado.Checked

    End Sub

    Private Sub Txt_Area_Cie_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Area_Cie.ButtonCustomClick

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_Stk_Areas"
        _Filtrar.Campo = "Id"
        _Filtrar.Descripcion = "Area"
        _Filtrar.Pro_Nombre_Encabezado_Informe = "AREA/DEPARTAMENTO"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra,
                               "And Id In (Select Id_Area From " & _Global_BaseBk & "Zw_Stk_AgentesVsTipos)", False, False, True, False,, False) Then

            Txt_Area_Cie.Tag = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Txt_Area_Cie.Text = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Descripcion")

            Txt_Tipo_Cie.Tag = 0
            Txt_Tipo_Cie.Text = String.Empty

            Txt_Area_Cie.ButtonCustom.Visible = False
            Txt_Area_Cie.ButtonCustom2.Visible = True

            Txt_Tipo.ButtonCustom.Visible = True

            Call Txt_Tipo_Cie_ButtonCustomClick(Nothing, Nothing)

        End If


    End Sub

    Private Sub Txt_Tipo_Cie_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Tipo_Cie.ButtonCustomClick

        If String.IsNullOrEmpty(Txt_Area_Cie.Text) Then
            MessageBoxEx.Show(Me, "Falta el Area/Departamento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_Stk_Tipos"
        _Filtrar.Campo = "Id"
        _Filtrar.Descripcion = "Tipo"
        _Filtrar.Pro_Nombre_Encabezado_Informe = "TIPO DE REQUERIMIENTO DEL AREA: " & Txt_Area_Cie.Text

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra,
                               "And Id In (Select Id From " & _Global_BaseBk & "Zw_Stk_Tipos Where Id_Area = " & Txt_Area_Cie.Tag & " And Id <> " & Cl_Tipo.Id & ")",
                               False, False, True, False,, False) Then

            Txt_Tipo_Cie.Tag = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Txt_Tipo_Cie.Text = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Descripcion")

        End If

    End Sub

    Private Sub Txt_Area_Cie_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Area_Cie.ButtonCustom2Click

        Txt_Area_Cie.Tag = String.Empty
        Txt_Area_Cie.Text = String.Empty
        Txt_Area_Cie.ButtonCustom.Visible = True
        Txt_Area_Cie.ButtonCustom2.Visible = False
        Txt_Tipo_Cie.Tag = String.Empty
        Txt_Tipo_Cie.Text = String.Empty
        Txt_Tipo_Cie.ButtonCustom.Visible = False
        Txt_Tipo_Cie.ButtonCustom2.Visible = False

    End Sub

    Private Sub Txt_Tipo_Cie_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Tipo_Cie.ButtonCustom2Click

        Txt_Tipo_Cie.Tag = String.Empty
        Txt_Tipo_Cie.Text = String.Empty
        Txt_Tipo_Cie.ButtonCustom.Visible = False
        Txt_Tipo_Cie.ButtonCustom2.Visible = False

    End Sub

End Class
