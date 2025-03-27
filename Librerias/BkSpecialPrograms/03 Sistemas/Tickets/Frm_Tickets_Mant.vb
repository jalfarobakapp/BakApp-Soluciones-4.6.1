Imports BkSpecialPrograms.LsValiciones
Imports BkSpecialPrograms.Tickets_Db
Imports DevComponents.DotNetBar
Imports Google.Protobuf.Reflection

Public Class Frm_Tickets_Mant

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    'Dim _Cl_Tickets As New Cl_Tickets
    'Dim _Cl_Tickets_Padre As New Cl_Tickets

    Public Property Cl_Tickets As New Cl_Tickets
    Public Property Cl_Tickets_Padre As New Cl_Tickets

    Public Property Grabar As Boolean
    Public Property Id_Padre As Integer
    Public Property New_Ticket As Cl_Tickets
    Public Property Aceptado As Boolean
    Public Property Rechazado As Boolean
    Public Property CerrarTicketAlFinalizar As Boolean

    Private _ConfirmaCantidades As Boolean

    Public Sub New(_Id_Ticket As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Cl_Tickets.Zw_Stk_Tickets.CodFuncionario_Crea = FUNCIONARIO
        ' _Cl_Tickets.Sb_Llenar_Ticket(0)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Tickets_Mant_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Arr_Tipo_Entidad(,) As String = {{"", ""},
                                             {"AL", "Alta"}, {"NR", "Normal"},
                                             {"BJ", "Baja"},
                                             {"UR", "Urgente"}}
        Sb_Llenar_Combos(_Arr_Tipo_Entidad, Cmb_Prioridad)

        Btn_VerProducto.Visible = False

        Txt_AreaTipo.ButtonCustom.Visible = True
        Txt_AreaTipo.ButtonCustom2.Visible = False

        If CBool(Id_Padre) Then

            _Cl_Tickets.Zw_Stk_Tickets.Id_Padre = Id_Padre

            Dim _Mensaje As LsValiciones.Mensajes

            _Mensaje = _Cl_Tickets_Padre.Fx_Llenar_Ticket(Id_Padre)
            _Mensaje = _Cl_Tickets.FX_Llenar_Producto(_Cl_Tickets_Padre.Zw_Stk_Tickets.Id)

            _Cl_Tickets.Zw_Stk_Tickets_Producto = _Mensaje.Tag

            _Cl_Tickets_Padre.Zw_Stk_Tipos = _Cl_Tickets_Padre.Fx_Llenar_Tipo(_Cl_Tickets_Padre.Zw_Stk_Tickets.Id_Tipo)

            _Cl_Tickets.Zw_Stk_Tipos = _Cl_Tickets.Fx_Llenar_Tipo(_Cl_Tickets_Padre.Zw_Stk_Tipos.CieTk_Id_Tipo)

            _Cl_Tickets.Zw_Stk_Tickets.Prioridad = _Cl_Tickets_Padre.Zw_Stk_Tickets.Prioridad
            _Cl_Tickets.Zw_Stk_Tickets.Id_Raiz = _Cl_Tickets_Padre.Zw_Stk_Tickets.Id_Raiz
            _Cl_Tickets.Zw_Stk_Tickets.Numero = _Cl_Tickets_Padre.Zw_Stk_Tickets.Numero

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Tickets_Producto Where Id_Raiz = " & _Cl_Tickets_Padre.Zw_Stk_Tickets.Id_Raiz
            Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            For Each _Fila As DataRow In _Tbl.Rows

                _Mensaje = _Cl_Tickets.FX_Llenar_Producto_Id(_Fila.Item("Id"))
                _Cl_Tickets.Ls_Zw_Stk_Tickets_Producto.Add(_Mensaje.Tag)
                _Cl_Tickets_Padre.Ls_Zw_Stk_Tickets_Producto.Add(_Mensaje.Tag)

            Next


            If Aceptado Then
                Txt_Descripcion.Text = _Cl_Tickets_Padre.Zw_Stk_Tipos.RespuestaXDefecto
            End If

            Txt_AreaTipo.ButtonCustom.Enabled = False
            Txt_AreaTipo.ButtonCustom2.Enabled = False

        End If

        Chk_ExigeProducto.Enabled = False

        Txt_Grupo.Enabled = Chk_Asignado.Checked
        Txt_Agente.Enabled = Chk_Asignado.Checked
        Rdb_AsignadoAgente.Enabled = Chk_Asignado.Checked
        Rdb_AsignadoGrupo.Enabled = Chk_Asignado.Checked

        With _Cl_Tickets.Zw_Stk_Tickets
            'Txt_CodFuncionario_Crea.Tag = .CodFuncionario_Crea
            'Txt_CodFuncionario_Crea.Text = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & .CodFuncionario_Crea & "'")
            Txt_Asunto.Text = .Asunto
            Cmb_Prioridad.SelectedValue = .Prioridad
            'Txt_Descripcion.Text = .Descripcion
            Chk_Asignado.Checked = .Asignado
            Txt_Agente.Tag = .CodAgente
            Txt_Agente.Text = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & .CodAgente & "'")
            Txt_Grupo.Tag = .Id_Grupo
            Txt_Grupo.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Stk_Grupos", "Grupo", "Id = " & .Id_Grupo)
            '.New_Id_TicketAc = _Cl_Tickets.Fx_Grabar_Nueva_Accion(_Cl_Tickets.Zw_Stk_Tickets.CodFuncionario_Crea, True, False)
        End With

        _Cl_Tickets.Zw_Stk_Tickets_Acciones.Id = _Cl_Tickets.Fx_Grabar_Nueva_Accion(_Cl_Tickets.Zw_Stk_Tickets.CodFuncionario_Crea, True, False)

        Me.ActiveControl = Txt_Asunto

        If CBool(Id_Padre) Then
            Timer_CreaDesdeTicket.Start()
        End If

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

        'If String.IsNullOrWhiteSpace(Txt_Area.Text) Then
        '    MessageBoxEx.Show(Me, "Falta el Area/Departamento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Txt_Area.Focus()
        '    Return
        'End If

        'If String.IsNullOrWhiteSpace(Txt_Tipo.Text) Then
        '    MessageBoxEx.Show(Me, "Falta el Tipo de requerimiento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Txt_Tipo.Focus()
        '    Return
        'End If

        If Not CBool(_Cl_Tickets.Zw_Stk_Tickets.Id_Tipo) Then
            MessageBoxEx.Show(Me, "Falta el tipo de Area/Requerimiento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Chk_Asignado.Checked = False
            Return
        End If

        Dim _TkProducto As Zw_Stk_Tickets_Producto = _Cl_Tickets.Zw_Stk_Tickets_Producto

        'If _Cl_Tickets.Zw_Stk_Tipos.ExigeProducto AndAlso
        '    _Cl_Tickets.Zw_Stk_Tipos.Inc_Cantidades AndAlso
        '    _Cl_Tickets_Padre.Ls_Zw_Stk_Tickets_Producto.Count <> _Cl_Tickets.Ls_Zw_Stk_Tickets_Producto.Count Then

        '    MessageBoxEx.Show(Me, "Falta ingresar cantidades en el detalle del producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Return

        'End If

        If Chk_ExigeProducto.Checked AndAlso _TkProducto.Codigo = String.Empty Then
            MessageBoxEx.Show(Me, "Falta el producto asociado al tipo de requerimiento." & vbCrLf &
                              "El tipo de requerimiento exige un producto asociado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If CBool(Id_Padre) AndAlso
            _Cl_Tickets.Zw_Stk_Tipos.ExigeProducto AndAlso
            _Cl_Tickets.Zw_Stk_Tipos.Inc_Cantidades AndAlso
            _Cl_Tickets_Padre.Ls_Zw_Stk_Tickets_Producto.Count = _Cl_Tickets.Ls_Zw_Stk_Tickets_Producto.Count Then
            MessageBoxEx.Show(Me, "Debe ingresar las cantidades para confirmar la grabación del Ticket",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Call Btn_VerProducto_Click(Nothing, Nothing)
            Return

        Else

            If _Cl_Tickets.Zw_Stk_Tipos.ExigeProducto AndAlso
            _Cl_Tickets.Zw_Stk_Tipos.Inc_Cantidades AndAlso
            (_Cl_Tickets.Ls_Zw_Stk_Tickets_Producto.Item(0).Cantidad + _Cl_Tickets.Ls_Zw_Stk_Tickets_Producto.Item(0).StfiEnBodega) = 0 Then
                MessageBoxEx.Show(Me, "Debe ingresar las cantidades para confirmar la grabación del Ticket",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Call Btn_VerProducto_Click(Nothing, Nothing)
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

        End If


        If Chk_ExigeDocCerrar.Checked And String.IsNullOrEmpty(Txt_TidoNudoCierra.Text) Then

            Dim _Msg1 = "TICKET EXIJE DOCUMENTO"
            Dim _Msg2 = "¿ESTA SEGURO DE CONFIRMAR EL TICKET SIN ADJUNTAR DOCUMENTO?" & vbCrLf & vbCrLf &
                        "[Yes] Confirmar cierre - [No] Cancelar"

            Dim _Mensaje As LsValiciones.Mensajes = Fx_Confirmar_LecturaSINO(_Msg1, _Msg2, eTaskDialogIcon.Exclamation, "CONFIRMACION DE RECETA", False, , False)

            If CType(_Mensaje.Tag, eTaskDialogResult) = eTaskDialogResult.No Or CType(_Mensaje.Tag, eTaskDialogResult) = eTaskDialogResult.Cancel Then
                Return
            End If

            'MessageBoxEx.Show(Me, "Falta el documento relacionado con el producto para poder grabar esta acción",
            '                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            _Cl_Tickets.Zw_Stk_Tickets_Acciones.ConfSinDoc_Cierra = True

        End If

        With _Cl_Tickets.Zw_Stk_Tickets

            .Asunto = Txt_Asunto.Text.Trim
            .Prioridad = Cmb_Prioridad.SelectedValue
            .Id_Grupo = Txt_Grupo.Tag
            .CodAgente = Txt_Agente.Tag
            .Asignado = Chk_Asignado.Checked
            .AsignadoGrupo = Rdb_AsignadoGrupo.Checked
            .AsignadoAgente = Rdb_AsignadoAgente.Checked

            Consulta_sql = "Select Top 1 Prod.Codigo,Prod.Descripcion,Prod.Numero,Prod.Ubicacion,Tks.CodFuncionario_Crea,NOKOFU" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_Stk_Tickets_Producto Prod" & vbCrLf &
                           "Inner Join " & _Global_BaseBk & "Zw_Stk_Tickets Tks On Tks.Id_Raiz = Prod.Id_Raiz" & vbCrLf &
                           "Inner Join TABFU On KOFU = Tks.CodFuncionario_Crea" & vbCrLf &
                           "Where Tks.Id <> " & _Cl_Tickets_Padre.Zw_Stk_Tickets.Id &
                           " And Id_Tipo = " & .Id_Tipo &
                           " And Prod.Empresa = '" & _TkProducto.Empresa & "' And Prod.Sucursal = '" & _TkProducto.Sucursal & "' And Prod.Bodega = '" & _TkProducto.Bodega & "' And Prod.Ubicacion = '" & _TkProducto.Ubicacion & "' And Codigo = '" & _TkProducto.Codigo & "' And Estado = 'ABIE'"
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row) Then

                MessageBoxEx.Show(Me, "Ticket " & _Row.Item("Numero") & vbCrLf &
                                      "De: " & _Row.Item("CodFuncionario_Crea") & "-" & _Row.Item("NOKOFU").ToString.Trim() & vbCrLf &
                                      "Producto: " & _TkProducto.Codigo.Trim & " - " & _Row.Item("Descripcion") & vbCrLf &
                                      "Asunto: " & Txt_AreaTipo.Text.Trim & vbCrLf &
                                      "Ubicación: " & _Row.Item("Ubicacion").ToString.Trim,
                                      "Ya hay un ticket abierto por esta misma solución", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Return

            End If

            .Descripcion = Txt_Descripcion.Text.Trim

        End With

        If CBool(_Cl_Tickets.Zw_Stk_Tickets.Id_Raiz) And _Cl_Tickets.Zw_Stk_Tipos.CierraRaiz Then
            Sb_CerrarTickets(True, False)
        Else
            Sb_CrearNuevoTicket()
        End If

    End Sub

    Sub Sb_CrearNuevoTicket()

        Dim _Mensaje As New LsValiciones.Mensajes

        If _Cl_Tickets.Zw_Stk_Tickets.Id = 0 Then

            With _Cl_Tickets.Zw_Stk_Tickets_Acciones

                .Accion = "CREA"

                If _Cl_Tickets.Zw_Stk_Tickets.Id <> _Cl_Tickets.Zw_Stk_Tickets.Id_Raiz Then
                    .Accion = "MENS"
                End If

                .Descripcion = Txt_Descripcion.Text
                .Fecha = FechaDelServidor()
                .CodFunGestiona = FUNCIONARIO

                If Aceptado Then
                    .Accion = "CECR"
                    .CreaNewTicket = True
                    .Cierra_Ticket = True
                    .Id_Ticket_Cierra = _Cl_Tickets_Padre.Zw_Stk_Tickets.Id
                End If

                .Aceptado = Aceptado
                .Rechazado = Rechazado
                .Id_Raiz = _Cl_Tickets.Zw_Stk_Tickets.Id_Raiz
                .Asunto = Txt_Asunto.Text

            End With

            _Mensaje = _Cl_Tickets.Fx_Grabar_Nuevo_Tickets()

        End If

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Zw_Stk_Tipos As New Zw_Stk_Tipos

        _Zw_Stk_Tipos = _Cl_Tickets.Fx_Llenar_Tipo(_Cl_Tickets.Zw_Stk_Tickets.Id_Tipo)

        If Chk_ExigeProducto.Checked And _Zw_Stk_Tipos.PreguntaCreaNewTicket Then

            If MessageBoxEx.Show(Me, "El ticket se ha creado correctamente, el número de ticket es " & _Cl_Tickets.Zw_Stk_Tickets.Numero & "." & vbCrLf & vbCrLf &
                                 "¿Desea agregar otro Ticket con las mismas definiciones, pero con otro producto?" & vbCrLf &
                                 "Crear nuevo Ticket", "Grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then

                _Cl_Tickets.Zw_Stk_Tickets.Id = 0
                _Cl_Tickets.Zw_Stk_Tickets.Id_Raiz = 0
                _Cl_Tickets.Zw_Stk_Tickets_Acciones.Id = _Cl_Tickets.Fx_Grabar_Nueva_Accion(_Cl_Tickets.Zw_Stk_Tickets.CodFuncionario_Crea, True, False)

                _Cl_Tickets.Zw_Stk_Tickets_Producto = New Zw_Stk_Tickets_Producto
                _Cl_Tickets.Ls_Zw_Stk_Tickets_Producto = New List(Of Zw_Stk_Tickets_Producto)

                Sb_Llenar_Tipo(_Cl_Tickets.Zw_Stk_Tickets.Id_Tipo)
                Return

            End If

        End If

        MessageBoxEx.Show(Me, "El ticket se ha creado correctamente, el número de ticket es " & _Cl_Tickets.Zw_Stk_Tickets.Numero & "-" & _Cl_Tickets.Zw_Stk_Tickets.SubNro & "." & vbCrLf &
                          "Guárdelo para fururas referencias", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        New_Ticket = _Cl_Tickets
        Grabar = True
        CerrarTicketAlFinalizar = True
        Me.Close()

    End Sub
    Sub Sb_CerrarTickets(_Aceptado As Boolean, _Rechazado As Boolean)

        With _Cl_Tickets.Zw_Stk_Tickets_Acciones

            .Id_Ticket = _Cl_Tickets_Padre.Zw_Stk_Tickets.Id
            .Id_Raiz = _Cl_Tickets_Padre.Zw_Stk_Tickets.Id_Raiz
            .Id_Ticket_Cierra = _Cl_Tickets_Padre.Zw_Stk_Tickets.Id
            .CodFuncionario = FUNCIONARIO
            .CodAgente = String.Empty
            .Accion = "ACCI"
            .CodFunGestiona = FUNCIONARIO
            .Descripcion = Txt_Descripcion.Text.Trim
            .Asunto = _Cl_Tickets.Zw_Stk_Tickets.Asunto
            .Aceptado = True

        End With

        Dim _Mensaje_Ticket As New LsValiciones.Mensajes

        _Mensaje_Ticket = _Cl_Tickets.Fx_Cerrar_Ticket(FUNCIONARIO, Txt_Descripcion.Text,
                                                       True, False, False, False, _Aceptado, _Rechazado, True, True, _Cl_Tickets.Zw_Stk_Tickets_Acciones)

        If Not _Mensaje_Ticket.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje_Ticket.Mensaje, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        MessageBoxEx.Show(Me, "El ticket se ha cerrado correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Grabar = True
        Me.Close()

    End Sub

    Sub Sb_Llenar_Tipo(_Id_Tipo As Integer)

        _Cl_Tickets.Zw_Stk_Tipos = _Cl_Tickets.Fx_Llenar_Tipo(_Id_Tipo)

        With _Cl_Tickets.Zw_Stk_Tipos

            Chk_ExigeProducto.Checked = .ExigeProducto
            Chk_Asignado.Checked = .Asignado
            Txt_Grupo.Tag = .Id_Grupo
            Txt_Grupo.Text = .Grupo
            Txt_Agente.Tag = .CodAgente
            Txt_Agente.Text = .Agente
            Rdb_AsignadoAgente.Checked = .AsignadoAgente
            Rdb_AsignadoGrupo.Checked = .AsignadoGrupo

            Chk_ExigeDocCerrar.Checked = .ExigeDocCerrar
            Txt_TidoNudoCierra.Visible = .ExigeDocCerrar
            Chk_ExigeDocCerrar.Visible = .ExigeDocCerrar

            If String.IsNullOrWhiteSpace(Txt_Asunto.Text) Then
                Txt_Asunto.Text = .Tipo.ToString.Trim
            End If

            Txt_Descripcion.Text = .RespuestaXDefecto

        End With

        Dim _ExigeProducto As Boolean = _Cl_Tickets.Zw_Stk_Tipos.ExigeProducto

        Chk_ExigeProducto.Checked = _ExigeProducto
        Btn_VerProducto.Visible = _ExigeProducto

        Dim _MostrarProducto = True

        If _ExigeProducto And Not CBool(Id_Padre) Then

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
            Dim _ProductoSeleccionado As Boolean = Fm.Pro_Seleccionado

            If _ProductoSeleccionado Then

                Dim _RowProducto = Fm.Pro_RowProducto

                Codigo_abuscar = Fm.Pro_RowProducto.Item("KOPR")

                If Not String.IsNullOrEmpty(Trim(Codigo_abuscar)) Then

                    With _Cl_Tickets.Zw_Stk_Tickets_Producto

                        .Codigo = _RowProducto.Item("KOPR")
                        .Descripcion = _RowProducto.Item("NOKOPR").ToString.Trim
                        .Empresa = ModEmpresa
                        .Rtu = _RowProducto.Item("RLUD")
                        .Ud1 = _RowProducto.Item("UD01PR")
                        .Ud2 = _RowProducto.Item("UD02PR")

                        Txt_Descripcion.Focus()

                    End With

                End If

            End If

            Fm.Dispose()

            If Not _ProductoSeleccionado Then

                Sb_Limpiar_Tipo()
                Return

            End If

            If _Cl_Tickets.Zw_Stk_Tipos.BodModalXDefecto Then

                With _Cl_Tickets.Zw_Stk_Tickets_Producto

                    .Empresa = ModEmpresa
                    .Sucursal = ModSucursal
                    .Bodega = ModBodega

                End With

            Else

                Dim Fm_b As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
                Fm_b.Pro_Empresa = ModEmpresa
                Fm_b.Pro_Sucursal = NuloPorNro(_Cl_Tickets.Zw_Stk_Tickets_Producto.Sucursal, ModSucursal)
                Fm_b.Pro_Bodega = NuloPorNro(_Cl_Tickets.Zw_Stk_Tickets_Producto.Bodega, ModBodega)
                Fm_b.RevisarPermisosBodega = False
                Fm_b.Pedir_Permiso = False
                Fm_b.ShowDialog(Me)

                If Fm_b.Pro_Seleccionado Then

                    With _Cl_Tickets.Zw_Stk_Tickets_Producto

                        .Empresa = Fm_b.Pro_RowBodega.Item("EMPRESA")
                        .Sucursal = Fm_b.Pro_RowBodega.Item("KOSU")
                        .Bodega = Fm_b.Pro_RowBodega.Item("KOBO")
                        .Descripcion_Bodega = Fm_b.Pro_RowBodega.Item("NOKOBO").ToString.Trim

                    End With

                End If

                Fm_b.Dispose()

            End If


            With _Cl_Tickets.Zw_Stk_Tickets_Producto

                Consulta_sql = "Select Top 1 Prod.Codigo,Prod.Descripcion,Prod.Numero,Prod.Ubicacion,Tks.CodFuncionario_Crea,NOKOFU" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_Stk_Tickets_Producto Prod" & vbCrLf &
                               "Inner Join " & _Global_BaseBk & "Zw_Stk_Tickets Tks On Tks.Id_Raiz = Prod.Id_Raiz" & vbCrLf &
                               "Inner Join TABFU On KOFU = Tks.CodFuncionario_Crea" & vbCrLf &
                               "Where Tks.Id <> " & _Cl_Tickets_Padre.Zw_Stk_Tickets.Id & " And Id_Tipo = " & _Id_Tipo &
                               " And Prod.Empresa = '" & .Empresa & "' And Prod.Sucursal = '" & .Sucursal & "' And Prod.Bodega = '" & .Bodega & "' And Codigo = '" & .Codigo & "' And Estado = 'ABIE'"
                Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not IsNothing(_Row) Then

                    Dim _Msj = "Ya hay un ticket abierto por esta misma solución. " & "Ticket " & _Row.Item("Numero") & vbCrLf & vbCrLf &
                               "De: " & _Row.Item("CodFuncionario_Crea") & "-" & _Row.Item("NOKOFU").ToString.Trim() & vbCrLf &
                               "Producto: " & .Codigo.Trim & " - " & _Row.Item("Descripcion") & vbCrLf &
                               "Ubicación: " & _Row.Item("Ubicacion") & vbCrLf &
                               "Asunto: " & Txt_AreaTipo.Text.Trim & vbCrLf & vbCrLf &
                               "¿Desea igualmente seleccionar este producto?"

                    If MessageBoxEx.Show(Me, _Msj, "Alerta",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then

                        With _Cl_Tickets.Zw_Stk_Tickets_Producto

                            .Codigo = String.Empty
                            .Descripcion = String.Empty
                            .Rtu = 0
                            .Um = String.Empty
                            '.Ud2 = String.Empty
                            .Empresa = ModEmpresa
                            .Sucursal = String.Empty
                            .Bodega = String.Empty

                        End With

                        Sb_Llenar_Tipo(_Cl_Tickets.Zw_Stk_Tickets.Id_Tipo)

                        Return

                    End If

                End If

                _Cl_Tickets.Ls_Zw_Stk_Tickets_Producto.Add(_Cl_Tickets.Zw_Stk_Tickets_Producto)

            End With

            'Dim Fm2 As New Frm_Tickets_IngProducto_GesXBod
            'Fm2.SoloUnProducto = True
            'Fm2.Cl_Tickets = _Cl_Tickets
            'Fm2.ShowDialog(Me)
            'Fm2.Dispose()

            Call Btn_VerProducto_Click(Nothing, Nothing)
            _MostrarProducto = False

        End If

        Txt_AreaTipo.ButtonCustom.Visible = False
        Txt_AreaTipo.ButtonCustom2.Visible = True
        Btn_VerProducto.Enabled = True

        Txt_Descripcion.Focus()

    End Sub

    Private Sub Chk_Asignado_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Asignado.CheckedChanged

        If Chk_Asignado.Checked Then

            If Not CBool(_Cl_Tickets.Zw_Stk_Tickets.Id_Tipo) Then
                MessageBoxEx.Show(Me, "Falta el tipo de Area/Requerimiento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Chk_Asignado.Checked = False
                Return
            End If

            Consulta_sql = "Select  Tp.*,Isnull(Tf.NOKOFU,'') As 'Agente',Isnull(Gr.Grupo,'') As Grupo" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_Stk_Tipos Tp" & vbCrLf &
                           "Left Join TABFU Tf On Tf.KOFU = Tp.CodAgente" & vbCrLf &
                           "Left Join " & _Global_BaseBk & "Zw_Stk_Grupos Gr On Tp.Id_Grupo = Gr.Id" & vbCrLf &
                           "Where Tp.Id = " & _Cl_Tickets.Zw_Stk_Tickets.Id_Tipo

            Dim _Row_Tipo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Chk_ExigeProducto.Checked = _Row_Tipo.Item("ExigeProducto")
            Chk_Asignado.Checked = _Row_Tipo.Item("Asignado")
            Txt_Grupo.Tag = _Row_Tipo.Item("Id_Grupo")
            Txt_Grupo.Text = _Row_Tipo.Item("Grupo")
            Txt_Agente.Tag = _Row_Tipo.Item("CodAgente")
            Txt_Agente.Text = _Row_Tipo.Item("Agente").ToString.Trim
            Rdb_AsignadoAgente.Checked = _Row_Tipo.Item("AsignadoAgente")
            Rdb_AsignadoGrupo.Checked = _Row_Tipo.Item("AsignadoGrupo")

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

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Tipos Where Id = " & _Cl_Tickets.Zw_Stk_Tickets.Id_Tipo
        Dim _Row_Tipo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not CBool(_Row_Tipo.Item("Id_Grupo")) Then
            MessageBoxEx.Show(Me, "Este tipo de requerimiento no tiene asociado a ningún grupo de trabajo",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Rdb_AsignadoAgente.Checked = True
            Return
        End If

        Dim _Sql_Filtro_Condicion_Extra As String = "And Gr.Id = " & _Row_Tipo.Item("Id_Grupo")

        Dim Fm As New Frm_Tickets_Grupos
        Fm.ModoSeleccion = True
        Fm.Sql_Filtro_Condicion_Extra = _Sql_Filtro_Condicion_Extra
        Fm.ShowDialog(Me)
        'If Not IsNothing(Fm.Row_Grupo) Then
        '    Txt_Grupo.Tag = Fm.Row_Grupo.Item("Id")
        '    Txt_Grupo.Text = Fm.Row_Grupo.Item("Grupo")
        'End If
        Fm.Dispose()

    End Sub

    Private Sub Txt_Grupo_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Grupo.ButtonCustom2Click
        Txt_Grupo.Tag = String.Empty
        Txt_Grupo.Text = String.Empty
    End Sub

    Private Sub Txt_Agente_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Agente.ButtonCustomClick

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Tipos Where Id = " & _Cl_Tickets.Zw_Stk_Tickets.Id_Tipo
        Dim _Row_Tipo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not CBool(_Row_Tipo.Item("Id_Grupo")) Then
            MessageBoxEx.Show(Me, "Este tipo de requerimiento solo esta asociado a un agente", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Sql_Filtro_Condicion_Extra = "And KOFU In (Select CodAgente From " & _Global_BaseBk & "Zw_Stk_GrupoVsAgente Where Id_Grupo = " & _Row_Tipo.Item("Id_Grupo") & ")"

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

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Tipos Where Id = " & _Cl_Tickets.Zw_Stk_Tickets.Id_Tipo
            Dim _Row_Tipo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not CBool(_Row_Tipo.Item("Id_Grupo")) Then
                MessageBoxEx.Show(Me, "Este tipo de requerimiento no tiene asociado a ningún grupo de trabajo",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Rdb_AsignadoAgente.Checked = True
                Return
            End If

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Grupos Where Id = " & _Row_Tipo.Item("Id_Grupo")
            Dim _Row_Grupo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Txt_Grupo.Tag = _Row_Grupo.Item("Id")
            Txt_Grupo.Text = _Row_Grupo.Item("Grupo")

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

        Dim Fm As New Frm_Adjuntar_Archivos("Zw_Stk_Tickets_Archivos", "Id_TicketAc", _Cl_Tickets.Zw_Stk_Tickets_Acciones.Id)
        Fm.Pedir_Permiso = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Frm_Tickets_Mant_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        If Not _Grabar Then
            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Where Id = " & _Cl_Tickets.Zw_Stk_Tickets_Acciones.Id & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Archivos Where Id_TicketAc = " & _Cl_Tickets.Zw_Stk_Tickets_Acciones.Id
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

    End Sub

    Private Sub Btn_OpcProducto_Click(sender As Object, e As EventArgs)
        ShowContextMenu(Menu_Contextual_Productos)
    End Sub

    Private Sub Txt_Bodega_ButtonCustomClick(sender As Object, e As EventArgs)

        If String.IsNullOrEmpty(_Cl_Tickets.Zw_Stk_Tickets_Producto.Codigo) Then
            MessageBoxEx.Show(Me, "Falta el producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm_b As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
        Fm_b.Pro_Empresa = ModEmpresa
        Fm_b.Pro_Sucursal = NuloPorNro(_Cl_Tickets.Zw_Stk_Tickets_Producto.Sucursal, ModSucursal)
        Fm_b.Pro_Bodega = NuloPorNro(_Cl_Tickets.Zw_Stk_Tickets_Producto.Bodega, ModBodega)
        Fm_b.RevisarPermisosBodega = False
        Fm_b.Pedir_Permiso = False
        Fm_b.ShowDialog(Me)

        If Fm_b.Pro_Seleccionado Then

            With _Cl_Tickets.Zw_Stk_Tickets_Producto

                .Empresa = Fm_b.Pro_RowBodega.Item("EMPRESA")
                .Sucursal = Fm_b.Pro_RowBodega.Item("KOSU")
                .Bodega = Fm_b.Pro_RowBodega.Item("KOBO")

            End With

        End If

        Fm_b.Dispose()

    End Sub

    Private Sub Txt_Asunto_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Asunto.ButtonCustomClick

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Tickets_PorDefecto",
                                                       "CodFuncionario = '" & FUNCIONARIO & "'")

        If Not CBool(_Reg) Then

            MessageBoxEx.Show(Me, "No existen asuntos por defecto para su usuario", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        Dim _AreaXDefecto As AreaXDefecto.AreaXDefecto

        Dim Fm As New Frm_Tickets_BuscarAsunto(FUNCIONARIO)
        Fm.ShowDialog(Me)
        _AreaXDefecto = Fm.AreaXDefecto
        Fm.Dispose()

        If Not IsNothing(_AreaXDefecto) AndAlso CBool(_AreaXDefecto.Id) Then

            With _AreaXDefecto

                Txt_Asunto.Text = .Asunto
                'Txt_Area.Tag = .Id_Area
                'Txt_Area.Text = .Area
                'Txt_Tipo.Tag = .Id_Tipo
                'Txt_Tipo.Text = .Tipo
                Cmb_Prioridad.SelectedValue = .Prioridad

                Sb_Llenar_Tipo(.Id_Tipo)

            End With

        End If

    End Sub

    Private Sub Btn_VerProducto_Click(sender As Object, e As EventArgs) Handles Btn_VerProducto.Click

        Dim _Grabar As Boolean

        Dim Fm2 As New Frm_Tickets_IngProducto_GesXBod
        Fm2.SoloUnProducto = Not CBool(Id_Padre)
        Fm2.Cl_Tickets = _Cl_Tickets
        Fm2.ModoSoloLectura = Not _Cl_Tickets.Zw_Stk_Tipos.Inc_Cantidades
        Fm2.ShowDialog(Me)
        _Grabar = Fm2.Grabar
        Fm2.Dispose()

        If _Grabar Then

            'If IsNothing(_Cl_Tickets_Padre.Zw_Stk_Tipos.RespuestaXDefecto) Then
            '    _Cl_Tickets_Padre.Zw_Stk_Tipos.RespuestaXDefecto = String.Empty
            'End If

            'If Not String.IsNullOrEmpty(_Cl_Tickets_Padre.Zw_Stk_Tipos.RespuestaXDefecto) Then
            '    Txt_Descripcion.Text = _Cl_Tickets_Padre.Zw_Stk_Tipos.RespuestaXDefecto & vbCrLf & vbCrLf &
            '                           _Cl_Tickets.Fx_Crear_Descripcion(_Cl_Tickets.Zw_Stk_Tickets.Id_Tipo)
            'Else
            '    Txt_Descripcion.Text = _Cl_Tickets.Fx_Crear_Descripcion(_Cl_Tickets.Zw_Stk_Tickets.Id_Tipo)
            'End If

        End If

    End Sub

    Private Sub Txt_AreaTipo_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_AreaTipo.ButtonCustomClick

        Dim _Id_Tipo As Integer

        'Dim Fm As New Frm_Tickets_Areas
        'Fm.ModoSeleccion = True
        'Fm.ShowDialog(Me)
        '_Id_Tipo = Fm.Id_Tipo_Seleccionado
        'Fm.Dispose()

        Dim Fm As New Frm_Tickets_BuscarTipo
        Fm.ModoSeleccion = True
        Fm.ShowDialog(Me)
        _Id_Tipo = Fm.Id_Tipo
        Fm.Dispose()

        If CBool(_Id_Tipo) Then

            Consulta_sql = "Select Tp.*,Ar.Area From " & _Global_BaseBk & "Zw_Stk_Tipos Tp" & vbCrLf &
                           "Inner Join " & _Global_BaseBk & "Zw_Stk_Areas Ar On Ar.Id = Tp.Id_Area" & vbCrLf &
                           "Where Tp.Id = " & _Id_Tipo
            Dim _Row_AreaTipo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            _Cl_Tickets.Zw_Stk_Tickets.Id_Area = _Row_AreaTipo.Item("Id_Area")
            _Cl_Tickets.Zw_Stk_Tickets.Id_Tipo = _Row_AreaTipo.Item("Id")

            Txt_AreaTipo.Text = _Row_AreaTipo.Item("Area").ToString.Trim & " - " & _Row_AreaTipo.Item("Tipo").ToString.Trim

            Sb_Llenar_Tipo(_Id_Tipo)

        End If

    End Sub

    Private Sub Txt_AreaTipo_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_AreaTipo.ButtonCustom2Click

        If MessageBoxEx.Show(Me, "¿Confirma quitar esta Area/Tipo de requerimniento?",
                             "Quitar Area/Requerimiento",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Sb_Limpiar_Tipo()

    End Sub

    Sub Sb_Limpiar_Tipo()

        Txt_AreaTipo.Text = String.Empty
        _Cl_Tickets.Zw_Stk_Tickets.Id_Area = 0
        _Cl_Tickets.Zw_Stk_Tickets.Id_Tipo = 0
        _Cl_Tickets.Zw_Stk_Tickets_Producto = New Zw_Stk_Tickets_Producto
        _Cl_Tickets.Zw_Stk_Tickets_Producto.Codigo = String.Empty
        _Cl_Tickets.Zw_Stk_Tickets_Producto.Descripcion = String.Empty
        _Cl_Tickets.Zw_Stk_Tipos = New Zw_Stk_Tipos
        _Cl_Tickets.Ls_Zw_Stk_Tickets_Producto = New List(Of Zw_Stk_Tickets_Producto)

        Txt_Descripcion.Text = String.Empty

        Txt_AreaTipo.ButtonCustom.Visible = True
        Txt_AreaTipo.ButtonCustom2.Visible = False

        If Chk_ExigeProducto.Checked Then Txt_Asunto.Text = String.Empty
        Chk_ExigeProducto.Checked = False
        Btn_VerProducto.Enabled = False

        Chk_Asignado.Checked = False

        With _Cl_Tickets.Zw_Stk_Tickets_Producto

            .Codigo = String.Empty
            .Descripcion = String.Empty
            .Rtu = 0
            .Um = String.Empty
            '.Ud2 = String.Empty
            .Empresa = ModEmpresa
            .Sucursal = String.Empty
            .Bodega = String.Empty

        End With

    End Sub

    Private Sub Timer_CreaDesdeTicket_Tick(sender As Object, e As EventArgs) Handles Timer_CreaDesdeTicket.Tick

        Timer_CreaDesdeTicket.Stop()

        Dim _New_Id_Tipo As Integer
        Dim _New_Id_Area As Integer

        Dim _LlenarElTipo As Boolean

        If _Cl_Tickets_Padre.Zw_Stk_Tickets.Rechazado Then
            _New_Id_Area = _Cl_Tickets_Padre.Zw_Stk_Tickets.Id_Area
            _New_Id_Tipo = _Cl_Tickets_Padre.Zw_Stk_Tickets.Id_Tipo
            Txt_AreaTipo.Enabled = False
            _LlenarElTipo = True
        Else
            If CBool(_Cl_Tickets_Padre.Zw_Stk_Tickets.Id_Area) AndAlso CBool(_Cl_Tickets_Padre.Zw_Stk_Tickets.Id_Tipo) Then
                _New_Id_Area = _Cl_Tickets_Padre.Zw_Stk_Tipos.CieTk_Id_Area
                _New_Id_Tipo = _Cl_Tickets_Padre.Zw_Stk_Tipos.CieTk_Id_Tipo
                _LlenarElTipo = True
            End If
        End If

        If _LlenarElTipo Then

            'Dim _Zw_Stk_Tipos As New Zw_Stk_Tipos

            '_Zw_Stk_Tipos = _Cl_Tickets_Padre.Fx_Llenar_Tipo(_New_Id_Tipo)

            Consulta_sql = "Select Tp.*,Ar.Area From " & _Global_BaseBk & "Zw_Stk_Tipos Tp" & vbCrLf &
                           "Inner Join " & _Global_BaseBk & "Zw_Stk_Areas Ar On Ar.Id = Tp.Id_Area" & vbCrLf &
                           "Where Tp.Id = " & _New_Id_Tipo
            Dim _Row_AreaTipo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            _Cl_Tickets.Zw_Stk_Tickets.Id_Area = _Row_AreaTipo.Item("Id_Area")
            _Cl_Tickets.Zw_Stk_Tickets.Id_Tipo = _Row_AreaTipo.Item("Id")

            'Txt_Asunto.Text = _Cl_Tickets.Zw_Stk_Tipos.Tipo
            Txt_AreaTipo.Text = _Row_AreaTipo.Item("Area").ToString.Trim & " - " & _Row_AreaTipo.Item("Tipo").ToString.Trim

            Sb_Llenar_Tipo(_Cl_Tickets.Zw_Stk_Tickets.Id_Tipo)

            If _Cl_Tickets.Zw_Stk_Tipos.Inc_Cantidades Then
                Call Btn_VerProducto_Click(Nothing, Nothing)
            End If

        End If

    End Sub

    Private Sub Txt_TidoNudoCierra_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_TidoNudoCierra.ButtonCustomClick

        Txt_TidoNudoCierra.ButtonCustom.Enabled = False

        Dim _Tidos As String = _Cl_Tickets.Zw_Stk_Tipos.TidoDocCerrar ' "GTI,GDI,GRI"
        Dim _TidosArray() As String = _Tidos.Split(","c)
        Dim _TidosFormatted As String = String.Join(",", _TidosArray.Select(Function(t) $"'{t}'"))

        Consulta_sql = "Select KOPR,NOKOPR From MAEPR Where KOPR = '" & Cl_Tickets.Zw_Stk_Tickets_Producto.Codigo & "'"
        Dim _Row_Producto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Fm As New Frm_BusquedaDocumento_Filtro(False)
        _Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado, "",
                                 $"Where TIDO In({_TidosFormatted})")
        _Fm.Pro_Row_Producto = _Row_Producto
        _Fm.Rdb_Estado_Todos.Checked = True
        _Fm.ShowDialog(Me)
        Dim _Row_Documento As DataRow = _Fm.Pro_Row_Documento_Seleccionado
        _Fm.Dispose()

        Txt_TidoNudoCierra.ButtonCustom.Enabled = True

        If Not IsNothing(_Row_Documento) Then

            Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEDDO",
                                       $"IDMAEEDO =  {_Row_Documento.Item("IDMAEEDO")} And KOPRCT = '{_Cl_Tickets.Zw_Stk_Tickets_Producto.Codigo}'"))

            If Not _Reg Then
                MessageBoxEx.Show(Me, "El documento no contiene al producto en sus filas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Txt_TidoNudoCierra.Text = _Row_Documento.Item("TIDO") & "-" & _Row_Documento.Item("NUDO")
            Txt_TidoNudoCierra.Tag = _Row_Documento.Item("IDMAEEDO")

            Consulta_sql = "Select * From MAEEDOOB Where IDMAEEDO = " & _Row_Documento.Item("IDMAEEDO")
            Dim _Row_Observaciones As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Motivo_Cierra As String = String.Empty
            Dim _Obdo As String = String.Empty
            Dim _Observaciones As String = String.Empty

            If Not IsNothing(_Row_Observaciones) Then

                _Obdo = _Row_Observaciones.Item("OBDO").ToString.Trim
                _Motivo_Cierra = _Row_Observaciones.Item("MOTIVO").ToString.Trim
                _Observaciones = _Obdo

                If Not String.IsNullOrEmpty(_Motivo_Cierra) Then
                    _Observaciones += vbCrLf & "MOTIVO: " & _Motivo_Cierra & " - " & _Sql.Fx_Trae_Dato("TABCARAC",
                                     "NOKOCARAC", "KOTABLA = 'MOTIVOS" & _Row_Documento.Item("TIDO") & "' And KOCARAC = '" & _Motivo_Cierra & "'").ToString.Trim
                End If

            End If

            _Observaciones = _Cl_Tickets.Zw_Stk_Tipos.Tipo & vbCrLf & vbCrLf & _Observaciones

            With _Cl_Tickets.Zw_Stk_Tickets_Acciones
                .Idmaeedo_Cierra = _Row_Documento.Item("IDMAEEDO")
                .Tido_Cierra = _Row_Documento.Item("TIDO")
                .Nudo_Cierra = _Row_Documento.Item("NUDO")
                .Motivo_Cierra = _Motivo_Cierra
            End With

            If Not String.IsNullOrWhiteSpace(_Observaciones) Then
                Txt_Descripcion.Text = _Observaciones
            End If

        End If

    End Sub

    Private Sub Txt_TidoNudoCierra_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_TidoNudoCierra.ButtonCustom2Click

        Txt_TidoNudoCierra.ButtonCustom2.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        If Not CBool(_Cl_Tickets.Zw_Stk_Tickets_Acciones.Idmaeedo_Cierra) Then
            MessageBoxEx.Show(Me, "No hay documento para ver", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_Ver_Documento(_Cl_Tickets.Zw_Stk_Tickets_Acciones.Idmaeedo_Cierra, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.Codigo_Marcar = Cl_Tickets.Zw_Stk_Tickets_Producto.Codigo
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Txt_TidoNudoCierra.ButtonCustom2.Enabled = True
        Me.Cursor = Cursors.Default

    End Sub
End Class
