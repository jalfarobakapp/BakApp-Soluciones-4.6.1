Imports DevComponents.DotNetBar

Public Class Frm_Tickets_TiposCrear

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Grabar As Boolean

    Dim Cl_Tickets As New Cl_Tickets

    Public Property Row_Tipo As DataRow
    Public Property _Zw_Stk_Tipos As New Zw_Stk_Tipos

    Public Sub New(_Id_Area As Integer, _Id_Tipo As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Zw_Stk_Tipos = Cl_Tickets.Fx_Llenar_Tipo(_Id_Tipo)
        _Zw_Stk_Tipos.Id_Area = _Id_Area

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Tickets_TiposCrear_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Areas Where Id = " & _Zw_Stk_Tipos.Id_Area
        Dim _Row_Area As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Lbl_Area.Text = "AREA: " & _Row_Area.Item("AREA")

        With _Zw_Stk_Tipos

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

            Txt_Tipo_Cie.Tag = .CieTk_Id_Tipo
            Txt_Tipo_Cie.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Stk_Tipos", "Tipo", "Id = " & .CieTk_Id_Tipo)

            Chk_BodModalXDefecto.Checked = .BodModalXDefecto
            Chk_PreguntaCreaNewTicket.Checked = .PreguntaCreaNewTicket
            Chk_CerrarAgenteSinPerm.Checked = .CerrarAgenteSinPerm
            Txt_RespuestaXDefecto.Text = .RespuestaXDefecto
            Txt_RespuestaXDefectoCerrar.Text = .RespuestaXDefectoCerrar

            Rdb_EsTicketUnico.Checked = .EsTicketUnico
            Rdb_NoEsTicketUnico.Checked = Not .EsTicketUnico

            Chk_CierraRaiz.Checked = .CierraRaiz
            Chk_ExigeDocCerrar.Checked = .ExigeDocCerrar
            Txt_TidoDocCierra.Text = .TidoDocCerrar

        End With

        Txt_Agente.Enabled = Rdb_AsignadoAgente.Checked
        Txt_Grupo.Enabled = Rdb_AsignadoGrupo.Checked

        Me.ActiveControl = Txt_Tipo

        AddHandler Chk_Asignado.CheckedChanged, AddressOf Chk_Asignado_CheckedChanged

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Tickets", "Estado = 'ABIE' And Id_Tipo = " & _Zw_Stk_Tipos.Id)

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

        'Lbl_Area_Cie.Enabled = Rdb_NoEsTicketUnico.Checked
        'Lbl_Tipo_Cie.Enabled = Rdb_NoEsTicketUnico.Checked
        'Txt_Area_Cie.Enabled = Rdb_NoEsTicketUnico.Checked
        'Txt_Tipo_Cie.Enabled = Rdb_NoEsTicketUnico.Checked

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

        Dim _Editar As Boolean = CBool(_Zw_Stk_Tipos.Id)

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

        If Not Rdb_EsTicketUnico.Checked AndAlso Not Rdb_NoEsTicketUnico.Checked Then
            MessageBoxEx.Show(Me, "Debe marcar si el Ticket es único o no",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Rdb_NoEsTicketUnico.Checked AndAlso (String.IsNullOrEmpty(Txt_Area_Cie.Text) Or String.IsNullOrEmpty(Txt_Tipo_Cie.Text)) Then
            MessageBoxEx.Show(Me, "Debe seleccionar un Area (Cierre Tickets) y Tipo (Cierre Tickets)",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Chk_ExigeDocCerrar.Checked And String.IsNullOrEmpty(Txt_TidoDocCierra.Text) Then
            MessageBoxEx.Show(Me, "Debe seleccionar el o los documentos asociados para poder cerrar el Ticket",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Rdb_EsTicketUnico.Checked Then
            Txt_Area_Cie.Tag = 0
            Txt_Area_Cie.Text = String.Empty
            Txt_Tipo_Cie.Tag = 0
            Txt_Tipo_Cie.Text = String.Empty
        End If

        With _Zw_Stk_Tipos

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
            .RespuestaXDefectoCerrar = Txt_RespuestaXDefectoCerrar.Text

            .EsTicketUnico = Rdb_EsTicketUnico.Checked
            .CierraRaiz = Chk_CierraRaiz.Checked
            .ExigeDocCerrar = Chk_ExigeDocCerrar.Checked
            .TidoDocCerrar = Txt_TidoDocCierra.Text

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Tipos", "Tipo = '" & .Tipo & "' And Id <> " & .Id)

            If CBool(_Reg) Then
                MessageBoxEx.Show(Me, "Ya existe un tipo de requerimiento con este nombre." & vbCrLf &
                                  "Los nombre de los tipos de requerimientos son únicos por sistema",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        End With

        Dim _Mensaje As LsValiciones.Mensajes = Cl_Tickets.Fx_Grabar_Tipo(_Zw_Stk_Tipos)

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Grabar = True

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Tipos Where Id = " & _Mensaje.Id
        Row_Tipo = _Sql.Fx_Get_DataRow(Consulta_sql)

        MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
                               "And Id In (Select Id From " & _Global_BaseBk & "Zw_Stk_Tipos Where Id_Area = " & Txt_Area_Cie.Tag & " And Id <> " & _Zw_Stk_Tipos.Id & ")",
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

    Private Sub Rdb_NoEsTicketUnico_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_NoEsTicketUnico.CheckedChanged
        Lbl_Area_Cie.Enabled = Rdb_NoEsTicketUnico.Checked
        Lbl_Tipo_Cie.Enabled = Rdb_NoEsTicketUnico.Checked
        Txt_Area_Cie.Enabled = Rdb_NoEsTicketUnico.Checked
        Txt_Tipo_Cie.Enabled = Rdb_NoEsTicketUnico.Checked
    End Sub

    Private Sub Rdb_EsTicketUnico_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_EsTicketUnico.CheckedChanged
        Lbl_Area_Cie.Enabled = Rdb_NoEsTicketUnico.Checked
        Lbl_Tipo_Cie.Enabled = Rdb_NoEsTicketUnico.Checked
        Txt_Area_Cie.Enabled = Rdb_NoEsTicketUnico.Checked
        Txt_Tipo_Cie.Enabled = Rdb_NoEsTicketUnico.Checked
    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        With _Zw_Stk_Tipos

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Tickets", "Id_Tipo = " & .Id)

            If CBool(_Reg) Then
                MessageBoxEx.Show(Me, "No se puede eliminar este tipo de ticket, ya que tiene ticket asociados",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            If MessageBoxEx.Show(Me, "¿Confirma eliminar este Tipo de requerimiento?", "Quitar tipo de requerimiento",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                Return
            End If

            Dim _CodPermiso As String = "Tkt" & numero_(_Zw_Stk_Tipos.Id_Area & _Zw_Stk_Tipos.Id, 6)

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Tipos Where Id = " & .Id & vbCrLf &
                           "Delete " & _Global_BaseBk & "ZW_Permisos Where CodPermiso = '" & _CodPermiso & "'" & vbCrLf &
                           "Delete " & _Global_BaseBk & "ZW_PermisosVsUsuarios Where CodPermiso = '" & _CodPermiso & "'"

            If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Grabar = True
            Me.Close()

        End With

    End Sub

    Private Sub Txt_TidoDocCierra_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_TidoDocCierra.ButtonCustomClick

        Dim _Nombre_Control = CType(sender, Control).Name
        Dim _Tbl_Filtro As DataTable
        Dim _Sql_Filtro_Condicion_Extra = String.Empty

        Dim _Tidos As String = Txt_TidoDocCierra.Text
        Dim _TidosArray() As String = _Tidos.Split(","c)
        Dim _TidosFormatted As String = String.Join(",", _TidosArray.Select(Function(t) $"'{t}'"))

        If Not String.IsNullOrEmpty(Txt_TidoDocCierra.Text) Then
            Consulta_sql = "Select TIDO As Codigo,NOTIDO As Descripcion From TABTIDO Where TIDO In (" & _TidosFormatted & ")"
            _Tbl_Filtro = _Sql.Fx_Get_DataTable(Consulta_sql)
        End If

        '_Sql_Filtro_Condicion_Extra = "And TIDO In ('BLV','FCL','FCT','FCV','FDE','FDV','FDX','FEV','FVX','FXV','FYV','GDD','GDP','GDV','GTI','NCV','NCX','NEV','GRI','GTI','GDI')"

        Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Documentos, False)
        Fm.Pro_Tbl_Filtro = _Tbl_Filtro
        ' Fm.Pro_Sql_Filtro_Condicion_Extra = _Sql_Filtro_Condicion_Extra
        Fm.ShowDialog(Me)

        If Fm.Pro_Filtrar Then
            _Tbl_Filtro = Fm.Pro_Tbl_Filtro
            Txt_TidoDocCierra.Text = Generar_Filtro_IN(_Tbl_Filtro, "", "Codigo", False, False, "", False)
        End If
        Fm.Dispose()

    End Sub

End Class
