Imports BkSpecialPrograms.Cl_Fincred_Bakapp.Cl_Fincred_SQL
Imports DevComponents.DotNetBar

Public Class Frm_Tickets_Mant

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Cl_Tickets As New Cl_Tickets
    Dim _Cl_Tickets_Padre As New Cl_Tickets

    Public Property Grabar As Boolean
    Public Property Id_Padre As Integer
    Public Property New_Ticket As Cl_Tickets

    Public Sub New(_Id_Ticket As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        'Consulta_sql = "Select *,NOKOFU From " & _Global_BaseBk & "Zw_Stk_Tickets" & vbCrLf &
        '               "Left Join TABFU On KOFU = CodFuncionario_Crea" & vbCrLf &
        '               "Where Id = " & _Id_Ticket
        '_Row_Ticket = _Sql.Fx_Get_DataRow(Consulta_sql)

        _Cl_Tickets.Tickets.CodFuncionario_Crea = FUNCIONARIO
        _Cl_Tickets.Sb_Llenar_Ticket(0)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Tickets_Mant_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_OcultarDesocultarControles(-95)

        Dim _Arr_Tipo_Entidad(,) As String = {{"", ""},
                                             {"AL", "Alta"},
                                             {"NR", "Normal"},
                                             {"BJ", "Baja"},
                                             {"UR", "Urgente"}}
        Sb_Llenar_Combos(_Arr_Tipo_Entidad, Cmb_Prioridad)

        If CBool(Id_Padre) Then

            _Cl_Tickets.Tickets.Id_Padre = Id_Padre
            _Cl_Tickets_Padre.Sb_Llenar_Ticket(Id_Padre)

            _Cl_Tickets.Tickets.Prioridad = _Cl_Tickets_Padre.Tickets.Prioridad

            Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Cl_Tickets_Padre.Tickets.Tickets_Producto.Codigo & "'"
            Dim _RowProducto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_RowProducto) Then

                With _Cl_Tickets.Tickets.Tickets_Producto

                    .Codigo = _RowProducto.Item("KOPR")
                    .Descripcion = _RowProducto.Item("NOKOPR").ToString.Trim
                    .Empresa = ModEmpresa
                    .Rtu = _RowProducto.Item("RLUD")
                    .Ud1 = _RowProducto.Item("UD01PR")
                    .Ud2 = _RowProducto.Item("UD02PR")

                    Txt_Producto.Tag = .Codigo
                    Txt_Producto.Text = .Codigo.ToString.Trim & "-" & .Descripcion.ToString.Trim
                    Txt_Descripcion.Focus()

                    Dim _Arr_UdMedida(,) As String = {{"1", .Ud1}, {"2", .Ud2}}
                    Sb_Llenar_Combos(_Arr_UdMedida, Cmb_UdMedida)
                    .UdMedida = _Cl_Tickets_Padre.Tickets.Tickets_Producto.UdMedida
                    Cmb_UdMedida.SelectedValue = .UdMedida

                    .Empresa = _Cl_Tickets_Padre.Tickets.Tickets_Producto.Empresa
                    .Sucursal = _Cl_Tickets_Padre.Tickets.Tickets_Producto.Sucursal
                    .Bodega = _Cl_Tickets_Padre.Tickets.Tickets_Producto.Bodega
                    .FechaRev = _Cl_Tickets_Padre.Tickets.Tickets_Producto.FechaRev
                    .Stfi1 = _Cl_Tickets_Padre.Tickets.Tickets_Producto.Stfi1
                    .Stfi2 = _Cl_Tickets_Padre.Tickets.Tickets_Producto.Stfi2
                    .Cantidad = _Cl_Tickets_Padre.Tickets.Tickets_Producto.Cantidad

                    Txt_Stf.Text = .Stfi1
                    Txt_Cantidad.Text = .Cantidad

                    Dtp_FechaRev.Value = .FechaRev

                    Dim _Sucursal = _Sql.Fx_Trae_Dato("TABSU", "NOKOSU", "EMPRESA = '" & .Empresa & "' And KOSU = '" & .Sucursal & "'")
                    Dim _Bodega = _Sql.Fx_Trae_Dato("TABBO", "NOKOBO", "EMPRESA = '" & .Empresa & "' And KOSU = '" & .Sucursal & "' And KOBO = '" & .Bodega & "'")

                    Txt_Bodega.Text = _Sucursal.ToString.Trim & " - " & _Bodega.ToString.Trim

                End With

                Txt_Producto.ButtonCustom.Visible = False
                Txt_Producto.ButtonCustom2.Visible = False

                Chk_ExigeProducto.Checked = True

            End If

        End If

        Chk_ExigeProducto.Enabled = False

        Txt_Grupo.Enabled = Chk_Asignado.Checked
        Txt_Agente.Enabled = Chk_Asignado.Checked
        Rdb_AsignadoAgente.Enabled = Chk_Asignado.Checked
        Rdb_AsignadoGrupo.Enabled = Chk_Asignado.Checked

        With _Cl_Tickets.Tickets
            Txt_CodFuncionario_Crea.Tag = .CodFuncionario_Crea
            Txt_CodFuncionario_Crea.Text = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & .CodFuncionario_Crea & "'")
            Txt_Asunto.Text = .Asunto
            Cmb_Prioridad.SelectedValue = .Prioridad
            Txt_Area.Tag = .Id_Area
            Txt_Area.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Stk_Areas", "Area", "Id = " & .Id_Area)
            Txt_Tipo.Tag = .Id_Tipo
            Txt_Tipo.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Stk_Tipos", "Tipo", "Id = " & .Id_Tipo)
            Txt_Descripcion.Text = .Descripcion
            Chk_Asignado.Checked = .Asignado
            Txt_Agente.Tag = .CodAgente
            Txt_Agente.Text = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & .CodAgente & "'")
            Txt_Grupo.Tag = .Id_Grupo
            Txt_Grupo.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Stk_Grupos", "Grupo", "Id = " & .Id_Grupo)
            .New_Id_TicketAc = _Cl_Tickets.Fx_Grabar_Nueva_Accion(_Cl_Tickets.Tickets.CodFuncionario_Crea, True)
        End With

        Me.ActiveControl = Txt_Asunto

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrWhiteSpace(Txt_Asunto.Text) Then
            MessageBoxEx.Show(Me, "Falta el asunto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Asunto.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(Txt_Descripcion.Text) AndAlso Not Chk_ExigeProducto.Checked Then
            MessageBoxEx.Show(Me, "Falta la descripción del requerimiento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Descripcion.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(Cmb_Prioridad.Text) Then
            MessageBoxEx.Show(Me, "Falta la Prioridad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Cmb_Prioridad.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(Txt_Area.Text) Then
            MessageBoxEx.Show(Me, "Falta el Area/Departamento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Area.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(Txt_Tipo.Text) Then
            MessageBoxEx.Show(Me, "Falta el Tipo de requerimiento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Tipo.Focus()
            Return
        End If

        If Chk_ExigeProducto.Checked AndAlso Txt_Producto.Text = String.Empty Then
            MessageBoxEx.Show(Me, "Falta el producto asociado al tipo de requerimiento." & vbCrLf &
                              "El tipo de requerimiento exige un producto asociado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
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

        End If

        With _Cl_Tickets.Tickets

            If Chk_ExigeProducto.Checked Then

                If Not CBool(Val(Txt_Cantidad.Text)) Then
                    If MessageBoxEx.Show(Me, "¿Confirma el valor cero para la cantidad inventariada?",
                                         "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) <> DialogResult.Yes Then
                        Return
                    End If
                End If

                .Tickets_Producto.FechaRev = Dtp_FechaRev.Value
                .Tickets_Producto.Cantidad = Val(Txt_Cantidad.Text)

                Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Tickets_PorDefecto",
                                   "CodFuncionario = '" & .CodFuncionario_Crea & "' And Asunto = '" & .Asunto & "'")

                If _Reg = 0 Then

                    If MessageBoxEx.Show(Me, "¿Desea dejar este tipo de Ticket grabado como plantilla para el futuro?",
                                      "Grabar plantilla de Tickets", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stk_Tickets_PorDefecto " &
                                       "(CodFuncionario,Asunto,Id_Area,Id_Tipo,Prioridad) Values " &
                                       "('" & .CodFuncionario_Crea & "','" & .Asunto & "'," & .Id_Area & "," & .Id_Tipo & ",'" & .Prioridad & "')"
                        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                            MessageBoxEx.Show(Me, "El tipo de Ticket quedo guardado para que pueda usar la plantilla en ticket futuros",
                                              "Grabar plantilla de Tickets", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    End If

                End If

                Dim _Descripcion As String = Txt_Descripcion.Text
                Dim _Ticket_Pr As Tickets_Db.Tickets_Producto = .Tickets_Producto
                Dim _Descripcion_Pr As String

                _Descripcion_Pr = "PRODUCTO : " & _Ticket_Pr.Codigo.Trim & " - " & _Ticket_Pr.Descripcion.Trim & vbCrLf &
                                  "BODEGA " & Txt_Bodega.Text & vbCrLf &
                                  "CANTIDAD EN BODEGA SEGUN SISTEMA: " & Txt_Stf.Text & vbCrLf &
                                  "CANTIDAD INVENTARIADA: " & Txt_Cantidad.Text & vbCrLf &
                                  "FECHA REV.: " & Dtp_FechaRev.Value & vbCrLf

                If .Tickets_Producto.AjusInventario Then
                    Txt_Descripcion.Text = "*** GENERAR AJUSTE DE INVENTARIO." & vbCrLf & _Descripcion_Pr
                End If

                If .Tickets_Producto.RevInventario Then
                    Txt_Descripcion.Text = "*** GENERAR REVISION DE INVENTARIO." & vbCrLf & _Descripcion_Pr
                End If

                If .Tickets_Producto.SobreStock Then
                    Txt_Descripcion.Text = "*** PRODUCTO CON SOBRE STOCK." & vbCrLf & _Descripcion_Pr
                End If

                If Not String.IsNullOrEmpty(_Descripcion) Then
                    Txt_Descripcion.Text += vbCrLf & _Descripcion
                End If

            End If

            .Asunto = Txt_Asunto.Text.Trim
            .Descripcion = Txt_Descripcion.Text.Trim
            .Prioridad = Cmb_Prioridad.SelectedValue
            .Id_Area = Txt_Area.Tag
            .Id_Tipo = Txt_Tipo.Tag
            .Id_Grupo = Txt_Grupo.Tag
            .CodAgente = Txt_Agente.Tag
            .Asignado = Chk_Asignado.Checked
            .AsignadoGrupo = Rdb_AsignadoGrupo.Checked
            .AsignadoAgente = Rdb_AsignadoAgente.Checked

        End With

        Dim _Msg_Grabar = String.Empty

        If _Cl_Tickets.Tickets.Id = 0 Then
            _Msg_Grabar = _Cl_Tickets.Fx_Grabar_Nuevo_Tickets()
        End If

        If String.IsNullOrEmpty(_Msg_Grabar) Then
            MessageBoxEx.Show(Me, "El ticket se ha creado correctamente, el número de ticket es " & _Cl_Tickets.Tickets.Numero & "." & vbCrLf &
                              "Guárdelo para fururas referencias", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            New_Ticket = _Cl_Tickets
            Grabar = True
            Me.Close()
        Else
            MessageBoxEx.Show(Me, _Msg_Grabar, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Txt_Area_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Area.ButtonCustomClick

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_Stk_Areas"
        _Filtrar.Campo = "Id"
        _Filtrar.Descripcion = "Area"
        _Filtrar.Pro_Nombre_Encabezado_Informe = "AREA/DEPARTAMENTO"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra,
                               "And Id In (Select Id_Area From " & _Global_BaseBk & "Zw_Stk_AgentesVsTipos)", False, False, True, False,, False) Then

            Txt_Area.Tag = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Txt_Area.Text = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Descripcion")

            Txt_Tipo.Tag = 0
            Txt_Tipo.Text = String.Empty

            If Not CBool(Id_Padre) Then

                Txt_Producto.Enabled = False
                Txt_Producto.Tag = String.Empty
                Txt_Producto.Text = String.Empty

                Chk_ExigeProducto.Checked = False

            End If

            Txt_Area.ButtonCustom.Visible = False
            Txt_Area.ButtonCustom2.Visible = True

            Txt_Tipo.ButtonCustom.Visible = True

            Call Txt_Tipo_ButtonCustomClick(Nothing, Nothing)

        End If

    End Sub

    Private Sub Txt_Tipo_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Tipo.ButtonCustomClick

        If String.IsNullOrEmpty(Txt_Area.Text) Then
            MessageBoxEx.Show(Me, "Falta el Area/Departamento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_Stk_Tipos"
        _Filtrar.Campo = "Id"
        _Filtrar.Descripcion = "Tipo"
        _Filtrar.Pro_Nombre_Encabezado_Informe = "TIPO DE REQUERIMIENTO DEL AREA: " & Txt_Area.Text

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra,
                               "And Id In (Select Id From " & _Global_BaseBk & "Zw_Stk_Tipos Where Id_Area = " & Txt_Area.Tag & ")",
                               False, False, True, False,, False) Then

            Txt_Tipo.Tag = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Txt_Tipo.Text = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Descripcion")

            'If CBool(Id_Padre) Then
            '    Txt_Tipo.ButtonCustom.Visible = False
            '    Txt_Tipo.ButtonCustom2.Visible = False
            '    Txt_Descripcion.Focus()
            '    Return
            'End If

            Dim _Id_Tipo = Txt_Tipo.Tag

            Consulta_sql = "Select  Tp.*,Isnull(Tf.NOKOFU,'') As 'Agente',Isnull(Gr.Grupo,'') As Grupo" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_Stk_Tipos Tp" & vbCrLf &
                           "Left Join TABFU Tf On Tf.KOFU = Tp.CodAgente" & vbCrLf &
                           "Left Join " & _Global_BaseBk & "Zw_Stk_Grupos Gr On Tp.Id_Grupo = Gr.Id" & vbCrLf &
                           "Where Tp.Id = " & _Id_Tipo
            Dim _Row_Tipo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
            Chk_ExigeProducto.Checked = _Row_Tipo.Item("ExigeProducto")
            Chk_Asignado.Checked = _Row_Tipo.Item("Asignado")
            Txt_Grupo.Tag = _Row_Tipo.Item("Id_Grupo")
            Txt_Grupo.Text = _Row_Tipo.Item("Grupo")
            Txt_Agente.Tag = _Row_Tipo.Item("CodAgente")
            Txt_Agente.Text = _Row_Tipo.Item("Agente").ToString.Trim
            Rdb_AsignadoAgente.Checked = _Row_Tipo.Item("AsignadoAgente")
            Rdb_AsignadoGrupo.Checked = _Row_Tipo.Item("AsignadoGrupo")

            _Cl_Tickets.Tickets.Tickets_Producto.AjusInventario = _Row_Tipo.Item("AjusInventario")
            _Cl_Tickets.Tickets.Tickets_Producto.RevInventario = _Row_Tipo.Item("RevInventario")
            _Cl_Tickets.Tickets.Tickets_Producto.SobreStock = _Row_Tipo.Item("SobreStock")
            Dim _ExigeProducto As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Stk_Tipos", "ExigeProducto", "Id = " & Txt_Tipo.Tag)
            Chk_ExigeProducto.Checked = _ExigeProducto
            Lbl_Producto.Enabled = _ExigeProducto
            Txt_Producto.Enabled = _ExigeProducto
            Txt_Tipo.ButtonCustom.Visible = False
            Txt_Tipo.ButtonCustom2.Visible = True

            If _ExigeProducto And Not CBool(Id_Padre) Then
                Call Txt_Producto_ButtonCustomClick(Nothing, Nothing)
            Else
                Txt_Descripcion.Focus()
            End If
        End If

    End Sub

    Private Sub Txt_Area_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Area.ButtonCustom2Click
        Txt_Area.Tag = String.Empty
        Txt_Area.Text = String.Empty
        Txt_Area.ButtonCustom.Visible = True
        Txt_Area.ButtonCustom2.Visible = False
        Txt_Tipo.Tag = String.Empty
        Txt_Tipo.Text = String.Empty
        Txt_Tipo.ButtonCustom.Visible = False
        Txt_Tipo.ButtonCustom2.Visible = False
        Txt_Producto.Tag = String.Empty
        Txt_Producto.Text = String.Empty
        Txt_Producto.Enabled = False
        Chk_ExigeProducto.Checked = False
        Txt_Producto.ButtonCustom.Visible = False
        Txt_Producto.ButtonCustom2.Visible = False
    End Sub

    Private Sub Txt_Tipo_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Tipo.ButtonCustom2Click
        Txt_Tipo.Tag = String.Empty
        Txt_Tipo.Text = String.Empty
        Txt_Tipo.ButtonCustom.Visible = True
        Txt_Tipo.ButtonCustom2.Visible = False
        Txt_Producto.Tag = String.Empty
        Txt_Producto.Text = String.Empty
        Txt_Producto.Enabled = False
        Txt_Producto.ButtonCustom.Visible = False
        Txt_Producto.ButtonCustom2.Visible = False
        Chk_ExigeProducto.Checked = False
    End Sub

    Private Sub Chk_Asignado_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Asignado.CheckedChanged

        If Chk_Asignado.Checked Then

            If String.IsNullOrWhiteSpace(Txt_Area.Text) Then
                MessageBoxEx.Show(Me, "Falta el Area/Departamento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Chk_Asignado.Checked = False
                Return
            End If

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

        Dim _Sql_Filtro_Condicion_Extra = "And KOFU In (Select CodAgente From " & _Global_BaseBk & "Zw_Stk_AgentesVsTipos Where Id_Area = " & Txt_Area.Tag & " And Id_Tipo = " & Txt_Tipo.Tag & ")"

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

    Private Sub Btn_Archivos_Adjuntos_Click(sender As Object, e As EventArgs) Handles Btn_Archivos_Adjuntos.Click

        Dim Fm As New Frm_Adjuntar_Archivos("Zw_Stk_Tickets_Archivos", "Id_TicketAc", _Cl_Tickets.Tickets.New_Id_TicketAc)
        Fm.Pedir_Permiso = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Frm_Tickets_Mant_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        If Not _Grabar Then
            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Where Id = " & _Cl_Tickets.Tickets.New_Id_TicketAc & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Archivos Where Id_TicketAc = " & _Cl_Tickets.Tickets.New_Id_TicketAc
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

    End Sub

    Private Sub Txt_Producto_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Producto.ButtonCustomClick

        Dim _ProductoSeleccionado As Boolean

        Try

            Txt_Producto.Enabled = False

            Dim _Codigo As String = Txt_Producto.Text

            Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
            Dim _RowProducto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_RowProducto) Then
                If Not String.IsNullOrEmpty(_RowProducto.Item("ATPR").ToString.Trim) Then
                    MessageBoxEx.Show(Me, "Producto oculto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                Else
                    Codigo_abuscar = _Codigo
                    Txt_Producto.Tag = _RowProducto.Item("KOPR")
                    Txt_Producto.Text = _RowProducto.Item("KOPR").ToString.Trim & "-" & _RowProducto.Item("NOKOPR").ToString.Trim
                End If
                Return
            End If

            Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
            Fm.Pro_Tipo_Lista = "P"
            Fm.Pro_Lista_Busqueda = ModListaPrecioVenta
            Fm.Pro_CodEntidad = String.Empty
            Fm.Pro_Mostrar_Info = True
            Fm.BtnCrearProductos.Visible = False
            Fm.Txtdescripcion.Text = String.Empty
            Fm.BtnExportaExcel.Visible = False
            Fm.Pro_Actualizar_Precios = False

            Fm.ShowDialog(Me)
            _ProductoSeleccionado = Fm.Pro_Seleccionado

            If _ProductoSeleccionado Then

                _RowProducto = Fm.Pro_RowProducto

                Codigo_abuscar = Fm.Pro_RowProducto.Item("KOPR")

                If Not String.IsNullOrEmpty(Trim(Codigo_abuscar)) Then

                    With _Cl_Tickets.Tickets.Tickets_Producto

                        .Codigo = _RowProducto.Item("KOPR")
                        .Descripcion = _RowProducto.Item("NOKOPR").ToString.Trim
                        .Empresa = ModEmpresa
                        .Rtu = _RowProducto.Item("RLUD")
                        .Ud1 = _RowProducto.Item("UD01PR")
                        .Ud2 = _RowProducto.Item("UD02PR")

                        Txt_Producto.Tag = .Codigo
                        Txt_Producto.Text = .Codigo.ToString.Trim & "-" & .Descripcion.ToString.Trim
                        Txt_Descripcion.Focus()

                        Dim _Arr_Tipo_Entidad(,) As String = {{"1", .Ud1}, {"2", .Ud2}}
                        Sb_Llenar_Combos(_Arr_Tipo_Entidad, Cmb_UdMedida)
                        Cmb_UdMedida.SelectedValue = 2
                        .UdMedida = 2

                    End With

                End If

            End If

            Fm.Dispose()

            Txt_Producto.ButtonCustom.Visible = Not _ProductoSeleccionado
            Txt_Producto.ButtonCustom2.Visible = _ProductoSeleccionado

            If _ProductoSeleccionado Then
                Call Txt_Bodega_ButtonCustomClick(Nothing, Nothing)
            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Producto.Tag = String.Empty
            Txt_Producto.Text = String.Empty
        Finally
            Txt_Producto.Enabled = True
        End Try

    End Sub

    Private Sub Txt_Producto_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Producto.ButtonCustom2Click

        Txt_Producto.Tag = String.Empty
        Txt_Producto.Text = String.Empty
        Txt_Producto.ButtonCustom.Visible = True
        Txt_Producto.ButtonCustom2.Visible = False

        Txt_Bodega.Text = String.Empty
        Txt_Stf.Text = String.Empty

        With _Cl_Tickets.Tickets.Tickets_Producto

            .Codigo = String.Empty
            .Descripcion = String.Empty
            .Empresa = String.Empty
            .Sucursal = String.Empty
            .Bodega = String.Empty
            .Stfi1 = 0
            .Stfi2 = 0
            .Rtu = 0
            .Ud1 = String.Empty
            .Ud2 = String.Empty

        End With

    End Sub

    Private Sub Btn_Estadisticas_Producto_Click(sender As Object, e As EventArgs) Handles Btn_Estadisticas_Producto.Click

        Dim _Codigo As String = Txt_Producto.Tag

        Dim Fm_Producto As New Frm_BkpPostBusquedaEspecial_Mt()
        Fm_Producto.Sb_Ver_Informacion_Adicional_producto(Me, _Codigo)

    End Sub

    Private Sub Btn_Copiar_Click(sender As Object, e As EventArgs) Handles Btn_Copiar.Click

        Dim Copiar = Txt_Producto.Text
        Clipboard.SetText(Copiar)

        ToastNotification.Show(Me, Copiar & vbCrLf & "Esta en el portapapeles", Btn_Copiar.Image,
                               2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

    End Sub

    Private Sub Btn_OpcProducto_Click(sender As Object, e As EventArgs) Handles Btn_OpcProducto.Click
        ShowContextMenu(Menu_Contextual_Productos)
    End Sub

    Private Sub Chk_ExigeProducto_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_ExigeProducto.CheckedChanged
        If Chk_ExigeProducto.Checked Then
            Sb_OcultarDesocultarControles(95)
        Else
            Sb_OcultarDesocultarControles(-95)
        End If
    End Sub

    Sub Sb_OcultarDesocultarControles(_Lc As Integer)

        Lbl_Descripcion.Location = New Point(Lbl_Descripcion.Location.X, Lbl_Descripcion.Location.Y + _Lc)
        Txt_Descripcion.Location = New Point(Txt_Descripcion.Location.X, Txt_Descripcion.Location.Y + _Lc)
        Line1.Location = New Point(Line1.Location.X, Line1.Location.Y + _Lc)
        Chk_Asignado.Location = New Point(Chk_Asignado.Location.X, Chk_Asignado.Location.Y + _Lc)
        Rdb_AsignadoGrupo.Location = New Point(Rdb_AsignadoGrupo.Location.X, Rdb_AsignadoGrupo.Location.Y + _Lc)
        Rdb_AsignadoAgente.Location = New Point(Rdb_AsignadoAgente.Location.X, Rdb_AsignadoAgente.Location.Y + _Lc)
        Txt_Grupo.Location = New Point(Txt_Grupo.Location.X, Txt_Grupo.Location.Y + _Lc)
        Txt_Agente.Location = New Point(Txt_Agente.Location.X, Txt_Agente.Location.Y + _Lc)

        GroupPanel2.Height += _Lc
        Me.Height += _Lc

        Txt_Producto.Visible = Not (0 > _Lc)
        Btn_OpcProducto.Visible = Not (0 > _Lc)

    End Sub

    Private Sub Txt_Bodega_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Bodega.ButtonCustomClick

        If String.IsNullOrEmpty(_Cl_Tickets.Tickets.Tickets_Producto.Codigo) Then
            MessageBoxEx.Show(Me, "Falta el producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm_b As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
        Fm_b.Pro_Empresa = ModEmpresa
        Fm_b.Pro_Sucursal = NuloPorNro(_Cl_Tickets.Tickets.Tickets_Producto.Sucursal, ModSucursal)
        Fm_b.Pro_Bodega = NuloPorNro(_Cl_Tickets.Tickets.Tickets_Producto.Bodega, ModBodega)
        Fm_b.RevisarPermisosBodega = False
        Fm_b.Pedir_Permiso = False
        Fm_b.ShowDialog(Me)

        If Fm_b.Pro_Seleccionado Then

            With _Cl_Tickets.Tickets.Tickets_Producto

                .Empresa = Fm_b.Pro_RowBodega.Item("EMPRESA")
                .Sucursal = Fm_b.Pro_RowBodega.Item("KOSU")
                .Bodega = Fm_b.Pro_RowBodega.Item("KOBO")
                Txt_Bodega.Text = Fm_b.Pro_RowBodega.Item("NOKOSU").ToString.Trim & " - " & Fm_b.Pro_RowBodega.Item("NOKOBO").ToString.Trim

                .Stfi1 = _Sql.Fx_Trae_Dato("MAEST",
                                           "STFI1", "EMPRESA = '" & .Empresa & "' " &
                                           "And KOSU = '" & .Sucursal & "' " &
                                           "And KOBO = '" & .Bodega & "' " &
                                           "And KOPR = '" & .Codigo & "'", True)

                .Stfi2 = _Sql.Fx_Trae_Dato("MAEST",
                                           "STFI2", "EMPRESA = '" & .Empresa & "' " &
                                           "And KOSU = '" & .Sucursal & "' " &
                                           "And KOBO = '" & .Bodega & "' " &
                                           "And KOPR = '" & .Codigo & "'", True)

                If Cmb_UdMedida.SelectedValue = 1 Then
                    Txt_Stf.Text = .Stfi1
                Else
                    Txt_Stf.Text = .Stfi2
                End If

                Txt_Stf.Focus()

            End With

        End If

        Fm_b.Dispose()

    End Sub

    Private Sub Cmb_UdMedida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_UdMedida.SelectedIndexChanged
        _Cl_Tickets.Tickets.Tickets_Producto.UdMedida = Cmb_UdMedida.SelectedValue
    End Sub
End Class
