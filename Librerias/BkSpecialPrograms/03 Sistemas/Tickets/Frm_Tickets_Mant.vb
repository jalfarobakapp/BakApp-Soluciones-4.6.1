Imports DevComponents.DotNetBar

Public Class Frm_Tickets_Mant

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Cl_Tickets As New Cl_Tickets

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

        If CBool(Id_Padre) Then

            _Cl_Tickets.Tickets.Id_Padre = Id_Padre

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Tickets Where Id = " & Id_Padre
            Dim _Row_Ticket_Padre As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Row_Ticket_Padre.Item("CodProducto") & "'"
            Dim _RowProducto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_RowProducto) Then

                Txt_Producto.Tag = _RowProducto.Item("KOPR")
                Txt_Producto.Text = _RowProducto.Item("KOPR").ToString.Trim & "-" & _RowProducto.Item("NOKOPR").ToString.Trim

                Txt_Producto.ButtonCustom.Visible = False
                Txt_Producto.ButtonCustom2.Visible = False

                Chk_ExigeProducto.Checked = True

            End If

        End If

        Chk_ExigeProducto.Enabled = False

        Dim _Arr_Tipo_Entidad(,) As String = {{"", ""},
                                             {"AL", "Alta"},
                                             {"NR", "Normal"},
                                             {"BJ", "Baja"},
                                             {"UR", "Urgente"}}
        Sb_Llenar_Combos(_Arr_Tipo_Entidad, Cmb_Prioridad)

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

        If String.IsNullOrWhiteSpace(Txt_Descripcion.Text) Then
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
            If String.IsNullOrEmpty(Txt_Agente.Text) AndAlso String.IsNullOrEmpty(Txt_Grupo.Text) Then
                MessageBoxEx.Show(Me, "Debe asignar un grupo de trabajo o agente para este requerimiento." & vbCrLf & vbCrLf &
                                  "Si no sabe a quien asignar esta labor debe dejar la casilla [ASIGNAR EL REQUERIMINETO A:] destickeada" & vbCrLf &
                                  "y el administrador del sistema redirigira el requerimiento a quien corresponda",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

        With _Cl_Tickets.Tickets

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
            If Chk_ExigeProducto.Checked Then .CodProducto = Txt_Producto.Tag

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

            If CBool(Id_Padre) Then
                Txt_Tipo.ButtonCustom.Visible = False
                Txt_Tipo.ButtonCustom2.Visible = False
                Txt_Descripcion.Focus()
                Return
            End If

            Chk_ExigeProducto.Checked = False

            Dim _ExigeProducto As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Stk_Tipos", "ExigeProducto", "Id = " & Txt_Tipo.Tag)

            Chk_ExigeProducto.Checked = _ExigeProducto
            Lbl_Producto.Enabled = _ExigeProducto
            Txt_Producto.Enabled = _ExigeProducto

            Txt_Tipo.ButtonCustom.Visible = False
            Txt_Tipo.ButtonCustom2.Visible = True

            If _ExigeProducto Then
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

            If Fm.Pro_Seleccionado Then

                _RowProducto = Fm.Pro_RowProducto

                Codigo_abuscar = Fm.Pro_RowProducto.Item("KOPR")

                If Not String.IsNullOrEmpty(Trim(Codigo_abuscar)) Then
                    Txt_Producto.Tag = _RowProducto.Item("KOPR")
                    Txt_Producto.Text = _RowProducto.Item("KOPR").ToString.Trim & "-" & _RowProducto.Item("NOKOPR").ToString.Trim
                    Txt_Descripcion.Focus()
                End If

            End If

            Txt_Producto.ButtonCustom.Visible = Not Fm.Pro_Seleccionado
            Txt_Producto.ButtonCustom2.Visible = Fm.Pro_Seleccionado

            Fm.Dispose()

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
End Class
