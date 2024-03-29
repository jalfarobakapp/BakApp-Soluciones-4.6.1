Imports BkSpecialPrograms.Frm_Tickets_Lista
Imports BkSpecialPrograms.Frm_Ver_Documento
Imports DevComponents.DotNetBar

Public Class Frm_Tickets_Seguimiento

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Ticket As Integer
    'Dim _Row_Ticket As DataRow
    Dim _Tbl_Acciones As DataTable
    Dim _Funcionario As String

    Dim _Ticket As New Cl_Tickets
    Dim _Tipo As New Tickets_Db.Tickets_Tipo

    Dim _Row_UltMensaje As DataRow
    Public Property Mis_Ticket As Boolean
    Public Property SoloLectura As Boolean
    Public Property CorrerALaDerecha As Boolean
    Public Property TicketSucesor As Boolean
    Public Property TicketAntecesor As Boolean

    Public Property vTop As Integer
    Public Property vLeft As Integer

    Public Sub New(_Id_Ticket As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Ticket = _Id_Ticket
        Me._Funcionario = _Funcionario

        _Ticket.Sb_Llenar_Ticket(_Id_Ticket)

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones" & vbCrLf &
                       "Where Id_Ticket = " & _Id_Ticket & " And Accion = 'MENS'" & vbCrLf &
                       "Order By Id Desc"
        _Row_UltMensaje = _Sql.Fx_Get_DataRow(Consulta_sql)

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Tickets_Seguimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "TICKET NRO: " & _Ticket.Tickets.Numero & " (" & _Ticket.Tickets.Id & ")"

        If CorrerALaDerecha Then
            Me.Top = vTop
            Me.Left = vLeft
        End If

        Btn_MensajeRespuesta.Visible = Not SoloLectura
        Btn_GestionarAcciones.Visible = Not SoloLectura
        'Btn_VerTicketOrigen.Visible = Not SoloLectura

        If Not SoloLectura Then

            If Mis_Ticket Then
                Btn_MensajeRespuesta.Text = "Nuevo mensaje"
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Set Visto = 1 Where Id_Ticket = " & _Id_Ticket & " And Accion = 'RESP'"
                Btn_Mnu_SolicitarCierre.Enabled = False
            Else
                Btn_MensajeRespuesta.Text = "Responder"
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Set Visto = 1 Where Id_Ticket = " & _Id_Ticket & " And Accion = 'MENS'"
                Btn_Anular.Enabled = False
            End If

            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

        Select Case _Ticket.Tickets.Estado
            Case "ABIE"
                Lbl_Estado.Text = "Abierto"
            Case "CERR"
                Lbl_Estado.Text = "Cerrado"
            Case "NULO"
                Lbl_Estado.Text = "Nulo"
            Case Else
                Lbl_Estado.Text = "???"
        End Select

        Lbl_Area.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Stk_Areas", "Area", "Id = " & _Ticket.Tickets.Id_Area)
        Lbl_Tipo.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Stk_Tipos", "Tipo", "Id = " & _Ticket.Tickets.Id_Tipo)
        Lbl_FechaCreacion.Text = _Ticket.Tickets.FechaCreacion
        Txt_Producto.Text = _Ticket.Tickets.Tickets_Producto.Codigo & " - " & _Ticket.Tickets.Tickets_Producto.Descripcion

        Txt_Producto.Enabled = Not String.IsNullOrEmpty(Txt_Producto.Text)

        Dim _Row_UltMensaje As DataRow
        Dim _Row_UltRespuesta As DataRow

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones" & vbCrLf &
                       "Where Id_Ticket = " & _Id_Ticket & " And Accion = 'MENS'" & vbCrLf &
                       "Order By Fecha Desc"
        _Row_UltMensaje = _Sql.Fx_Get_DataRow(Consulta_sql)

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones" & vbCrLf &
                       "Where Id_Ticket = " & _Id_Ticket & " And Accion = 'RESP'" & vbCrLf &
                       "Order By Fecha Desc"
        _Row_UltRespuesta = _Sql.Fx_Get_DataRow(Consulta_sql)

        Lbl_FUlt_Mensaje.Text = String.Empty
        Lbl_FUlt_Respuesta.Text = String.Empty

        If Not IsNothing(_Row_UltMensaje) Then
            Lbl_FUlt_Mensaje.Text = _Row_UltMensaje.Item("Fecha")
        End If

        If Not IsNothing(_Row_UltRespuesta) Then
            Lbl_FUlt_Respuesta.Text = _Row_UltRespuesta.Item("Fecha")
        End If

        Sb_InsertarBotonenGrilla(Grilla, "Btn_ImagenAttach", "Est.", "ImagenAttach", 0, _Tipo_Boton.Imagen)
        Sb_InsertarBotonenGrilla(Grilla, "Btn_ImagenUser", "Est.", "ImagenUser", 0, _Tipo_Boton.Imagen)

        Sb_Actualizar_Grilla()

        'Btn_VerTicketOrigen.Visible = CBool(_Ticket.Tickets.Id_Padre)

        If Not SoloLectura Then

            Btn_MensajeRespuesta.Visible = Not (_Ticket.Tickets.Estado = "CERR" Or _Ticket.Tickets.Estado = "NULO")
            Btn_GestionarAcciones.Visible = Not (_Ticket.Tickets.Estado = "CERR" Or _Ticket.Tickets.Estado = "NULO")

            Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stk_Tickets_Toma (Id_Ticket,CodFuncionario,FechaToma,NombreEquipo) " &
                           "Values (" & _Id_Ticket & ",'" & FUNCIONARIO & "',Getdate(),'" & _NombreEquipo & "')"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

        _Tipo = _Ticket.Fx_Llenar_Tipo(_Ticket.Tickets.Id_Area, _Ticket.Tickets.Id_Tipo)

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select Acc.*," & vbCrLf &
                       "Case Accion " &
                       "When 'CREA' Then 'Crea Ticket' " &
                       "When 'MENS' Then 'Mensaje' " &
                       "When 'RESP' Then 'Respuesta' " &
                       "When 'NULO' Then 'Anula' " &
                       "When 'SOLC' Then 'Sol. Cierre' " &
                       "When 'CERR' Then 'Cierra ticket' " &
                       "When 'CECR' Then 'Cierra y crea nuevo ticket' " &
                       "When 'RECH' Then 'Rechazado' " &
                       "Else '???' End As 'StrAccion'," & vbCrLf &
                       "Cf.NOKOFU As 'NombreFunAge'," & vbCrLf &
                       "(Select COUNT(*) From " & _Global_BaseBk & "Zw_Stk_Tickets_Archivos Where Id_TicketAc = Acc.Id) As 'Num_Attach'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Acc" & vbCrLf &
                       "Left Join TABFU Cf On Cf.KOFU = CodFunGestiona" & vbCrLf &
                       "Where Id_Ticket = " & _Id_Ticket & vbCrLf &
                       "Order By Fecha"

        _Tbl_Acciones = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Acciones

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Btn_ImagenUser").Width = 40
            .Columns("Btn_ImagenUser").HeaderText = "User"
            .Columns("Btn_ImagenUser").Visible = True
            .Columns("Btn_ImagenUser").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StrAccion").Visible = True
            .Columns("StrAccion").HeaderText = "Acción"
            .Columns("StrAccion").Width = 70
            .Columns("StrAccion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CodFunGestiona").Visible = True
            .Columns("CodFunGestiona").HeaderText = "CF"
            .Columns("CodFunGestiona").Width = 30
            .Columns("CodFunGestiona").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreFunAge").Visible = True
            .Columns("NombreFunAge").HeaderText = "De"
            .Columns("NombreFunAge").Width = 150
            .Columns("NombreFunAge").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Width = 240
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Btn_ImagenAttach").Width = 40
            .Columns("Btn_ImagenAttach").HeaderText = "Att."
            .Columns("Btn_ImagenAttach").Visible = True
            .Columns("Btn_ImagenAttach").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha").Visible = True
            .Columns("Fecha").HeaderText = "Fecha creación"
            '.Columns("Fecha").ToolTipText = "de tope de la oferta"
            '.Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").Width = 110
            .Columns("Fecha").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Icono As Image
            Dim _Nombre_Image As String
            Dim _Accion As String = _Fila.Cells("Accion").Value
            Dim _Num_Attach As Integer = _Fila.Cells("Num_Attach").Value
            Dim _CodFuncionario As String = _Fila.Cells("CodFuncionario").Value.ToString.Trim

            Dim _Imagenes_List As ImageList

            If Global_Thema = Enum_Themas.Oscuro Then
                _Imagenes_List = Imagenes_16x16_Dark
            Else
                _Imagenes_List = Imagenes_16x16
            End If

            If CBool(_Num_Attach) Then
                _Nombre_Image = "attach-number-" & _Num_Attach & ".png"
                If _Num_Attach > 9 Then
                    _Nombre_Image = "attach-number-9-plus.png"
                End If
                _Icono = _Imagenes_List.Images.Item(_Nombre_Image)
                _Fila.DefaultCellStyle.BackColor = Color.LightYellow
            Else
                _Icono = _Imagenes_List.Images.Item("menu-more.png")
            End If

            _Fila.Cells("Btn_ImagenAttach").Value = _Icono

            If Not String.IsNullOrEmpty(_CodFuncionario) Then
                _Icono = _Imagenes_List.Images.Item("people-customer-man.png")
            Else
                _Icono = _Imagenes_List.Images.Item("people-vendor.png")
                If _Accion = "RECH" Then
                    _Icono = _Imagenes_List.Images.Item("people-vendor-error.png")
                    _Fila.Cells("Accion").Style.ForeColor = Rojo
                End If
            End If

            _Fila.Cells("Btn_ImagenUser").Value = _Icono

        Next

        Try
            Grilla.CurrentCell = Grilla.Rows(Grilla.RowCount - 1).Cells("StrAccion")
        Catch ex As Exception

        End Try

        Grilla.Refresh()

    End Sub

    Private Sub Grilla_Acciones_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter

        Try
            Dim _Fila As DataGridViewRow = Grilla.CurrentRow
            Txt_Descripcion.Text = _Fila.Cells("Descripcion").Value
        Catch ex As Exception
            Txt_Descripcion.Text = String.Empty
        End Try

    End Sub

    Private Sub Btn_MensajeRespuesta_Click(sender As Object, e As EventArgs) Handles Btn_MensajeRespuesta.Click

        If Mis_Ticket Then
            Sb_Agregar_Mensaje_Respuesta(False)
            Return
        End If

        If _Ticket.Tickets.Rechazado Then
            Sb_Agregar_Mensaje_Respuesta(False)
        End If

    End Sub

    Sub Sb_Agregar_Mensaje_Respuesta(_RechazarTicket As Boolean)

        Dim _Grabar As Boolean
        Dim _Descripcion As String

        Dim _Cl_Tickets As New Cl_Tickets
        '_Cl_Tickets.Sb_Llenar_Ticket(_Id_Ticket)

        Dim _Tk_Accion As New Tickets_Db.Tickets_Acciones

        With _Tk_Accion

            .Id_Ticket = _Id_Ticket

            If Mis_Ticket Then
                .CodFuncionario = FUNCIONARIO
                .Accion = "MENS"
            Else
                .CodAgente = FUNCIONARIO
                .Accion = "RESP"
            End If

            If _RechazarTicket Then
                .Accion = "RECH"
            End If

            .CodFunGestiona = FUNCIONARIO
            .Descripcion = ""

        End With

        Dim _Mensaje_Ticket As New Tickets_Db.Mensaje_Ticket

        _Mensaje_Ticket = _Cl_Tickets.Fx_Grabar_Nueva_Accion2(_Tk_Accion)

        If Not _Mensaje_Ticket.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje_Ticket.Mensaje, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        _Tk_Accion.Id = _Mensaje_Ticket.New_Id

        Dim Fm As New Frm_Tickets_Respuesta(_Tk_Accion.Id)

        If Mis_Ticket Then
            Fm.Text = "NUEVO MENSAJE"
        Else
            Fm.Text = "RESPONDER"
        End If

        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _Descripcion = Fm.Txt_Descripcion.Text.Trim
        Fm.Dispose()

        If Not _Grabar Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Where Id = " & _Tk_Accion.Id & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Archivos Where Id_TicketAc = " & _Tk_Accion.Id
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Return

        End If

        Consulta_sql = String.Empty

        If _RechazarTicket Then
            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tickets Set Rechazado = 1 Where Id = " & _Id_Ticket & vbCrLf
        Else
            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tickets Set Rechazado = 0 Where Id = " & _Id_Ticket & vbCrLf
        End If

        Consulta_sql += "Update " & _Global_BaseBk & "Zw_Stk_Tickets Set UltAccion = '" & _Tk_Accion.Accion & "' Where Id = " & _Id_Ticket & vbCrLf &
                        "Update " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Set Visto = 1 Where Id_Ticket = " & _Id_Ticket & vbCrLf &
                        "Update " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Set " &
                        "Fecha = Getdate(),Descripcion = '" & _Descripcion & "',En_Construccion = 0,Visto = 0" & vbCrLf &
                        "Where Id = " & _Tk_Accion.Id
        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        If _RechazarTicket Then

            MessageBoxEx.Show(Me, "Ticket Rechazado, se ha enviado la confirmación al remitente",
                              "Rechazar Ticket", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()

        Else

            If MessageBoxEx.Show(Me, "Mensaje enviado correctamente" & vbCrLf & vbCrLf & "¿Desea cerrar el formulario?",
                                 "Información",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Me.Close()
            Else
                Sb_Actualizar_Grilla()
            End If

        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id_TicketAc As Integer = _Fila.Cells("Id").Value
        Dim _Num_Attach As Integer = _Fila.Cells("Num_Attach").Value

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If _Cabeza = "Btn_ImagenAttach" Then

            If Not CBool(_Num_Attach) Then
                DevComponents.DotNetBar.MessageBoxEx.Show(Me, "No hay archivos adjuntos que mostrar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Dim Fm As New Frm_Adjuntar_Archivos("Zw_Stk_Tickets_Archivos", "Id_TicketAc", _Id_TicketAc)
            'Fm.Text = "Archivos adjuntos documento en construcción: " & _Tido.Trim & " Nro: " & _Nudo
            Fm.Pedir_Permiso = False
            Fm.SoloLectura = True
            Fm.ShowDialog(Me)
            Fm.Dispose()

            _Fila.Cells("Num_Attach").Value = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Tickets_Archivos", "Id_TicketAc = " & _Id_TicketAc)

            Dim _Icono As Image
            Dim _Nombre_Image As String
            _Num_Attach = _Fila.Cells("Num_Attach").Value

            If CBool(_Num_Attach) Then
                _Nombre_Image = "attach-number-" & _Num_Attach & ".png"
                If _Num_Attach > 9 Then
                    _Nombre_Image = "attach-number-9-plus.png"
                End If
                _Icono = Imagenes_16x16.Images.Item(_Nombre_Image)
                _Fila.DefaultCellStyle.BackColor = Color.LightYellow
            Else
                _Icono = Imagenes_16x16.Images.Item("menu-more.png")
            End If

            _Fila.Cells("Btn_ImagenAttach").Value = _Icono

            Grilla.CurrentCell = Grilla.Rows(_Fila.Index).Cells("StrAccion")

        End If

    End Sub

    Private Sub Btn_Estadisticas_Producto_Click(sender As Object, e As EventArgs) Handles Btn_Estadisticas_Producto.Click

        Dim _Codigo As String = _Ticket.Tickets.Tickets_Producto.Codigo

        Dim Fm_Producto As New Frm_BkpPostBusquedaEspecial_Mt()
        Fm_Producto.Sb_Ver_Informacion_Adicional_producto(Me, _Codigo)

    End Sub

    Private Sub Btn_Copiar_Click(sender As Object, e As EventArgs) Handles Btn_Copiar.Click

        Dim Copiar = Txt_Producto.Text
        Clipboard.SetText(Copiar)

        ToastNotification.Show(Me, Copiar & vbCrLf & "Esta en el portapapeles", Btn_Copiar.Image,
                               2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

    End Sub

    Private Sub Txt_Producto_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Producto.ButtonCustomClick
        ShowContextMenu(Menu_Contextual_Productos)
    End Sub

    Private Sub Btn_Mnu_CerrarTicket_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_CerrarTicket.Click

        If Not Mis_Ticket Then

            If Not _Tipo.CerrarAgenteSinPerm Then
                If Not Fx_Tiene_Permiso(Me, "") Then
                    Return
                End If
            End If

        End If

        Sb_Cerrar_Ticket(True, False, False, False, 0)

    End Sub

    Private Sub Btn_Mnu_SolicitarCierre_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_SolicitarCierre.Click
        Sb_Cerrar_Ticket(False, True, False, False, 0)
    End Sub

    Private Sub Btn_Mnu_CerrarTicketCrearNuevo_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_CerrarTicketCrearNuevo.Click

        If Not Mis_Ticket Then

            If _Ticket.Tickets.Rechazado Then
                If MessageBoxEx.Show(Me, "Este ticket fue rechazado." & vbCrLf &
                                  "¿Confirma crear un nuevo Ticket a partir de este, esto revertira el rechazo?",
                                     "Ticket Rechazado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                    Return
                End If
            End If

        End If

        Dim _Grabar As Boolean
        Dim _Id_Hijo As Integer

        Dim Fm As New Frm_Tickets_Mant(0)
        Fm.Id_Padre = _Id_Ticket
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        If _Grabar Then
            _Id_Hijo = Fm.New_Ticket.Tickets.Id
        End If
        Fm.Dispose()

        If _Grabar Then
            Sb_Cerrar_Ticket(True, False, True, False, _Id_Hijo)
        End If

    End Sub

    Private Sub Btn_Anular_Click(sender As Object, e As EventArgs) Handles Btn_Anular.Click

        If MessageBoxEx.Show(Me, "¿Confirma la anulación del Ticket?", "Anular Ticket",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Sb_Cerrar_Ticket(False, False, False, True, 0)

    End Sub

    Sub Sb_Cerrar_Ticket(_Cierra_Ticket As Boolean,
                         _Solicita_Cierre As Boolean,
                         _CreaNewTicket As Boolean,
                         _AnulaTicket As Boolean,
                         _Id_Hijo As Integer)

        Dim _Aceptar As Boolean
        Dim _Descripcion As String

        Dim _Caption As String

        If _Cierra_Ticket Then
            _Caption = "Cerrar Ticket"
            If Not Mis_Ticket Then
                _Descripcion = _Tipo.RespuestaXDefecto.Trim
            End If
        End If
        If _Solicita_Cierre Then _Caption = "Solicitar cierre"
        If _CreaNewTicket Then _Caption = "Cerrar y crear Ticket"
        If _AnulaTicket Then _Caption = "Anular Ticket"

        If Not _CreaNewTicket Then

            _Aceptar = InputBox_Bk(Me, "Ingrese un comentario (obligatorio)", _Caption,
                               _Descripcion, True, _Tipo_Mayus_Minus.Mayusculas, 200, True,
                               _Tipo_Imagen.Texto, False,,,, Nothing)

            If Not _Aceptar Then
                Return
            End If

        End If

        If _CreaNewTicket Then

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Tickets Where Id = " & _Id_Hijo
            Dim _Row_Ticket_Hijo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Numero_H As String = _Row_Ticket_Hijo.Item("Numero")
            Dim _Asunto_H As String = _Row_Ticket_Hijo.Item("Asunto")
            Dim _Descripcion_H As String = _Row_Ticket_Hijo.Item("Descripcion")

            _Descripcion = "SE GENERA EL TICKET Nro " & _Numero_H & " Asunto: " & _Asunto_H.ToString.Trim

        End If

        Dim _Cl_Tickets As New Cl_Tickets
        _Cl_Tickets.Sb_Llenar_Ticket(_Id_Ticket)

        Dim _Mensaje_Ticket As New Tickets_Db.Mensaje_Ticket

        _Mensaje_Ticket = _Cl_Tickets.Fx_Cerrar_Ticket(FUNCIONARIO,
                                                       _Descripcion,
                                                       _Cierra_Ticket,
                                                       _Solicita_Cierre,
                                                       _CreaNewTicket,
                                                       _AnulaTicket)

        If Not _Mensaje_Ticket.EsCorrecto Then
            Return
        End If

        MessageBoxEx.Show(Me, _Mensaje_Ticket.Mensaje, _Caption, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

    End Sub

    Private Sub Btn_Cerrar_Click(sender As Object, e As EventArgs) Handles Btn_Cerrar.Click
        Me.Close()
    End Sub



    Private Sub Btn_AgentesAsignados_Click(sender As Object, e As EventArgs) Handles Btn_AgentesAsignados.Click

        Consulta_sql = "Select Asg.*,NOKOFU" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stk_Tickets_Asignado Asg" & vbCrLf &
                       "Left Join TABFU On KOFU = Asg.CodAgente " & vbCrLf &
                       "Where Id_Ticket = " & _Id_Ticket
        Dim _Tbl_Agentes As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If Not CBool(_Tbl_Agentes.Rows.Count) Then
            MessageBoxEx.Show(Me, "No hay agentes asociados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Agentes = String.Empty

        For Each _FlAgente As DataRow In _Tbl_Agentes.Rows
            If Not String.IsNullOrEmpty(_Agentes) Then
                _Agentes += vbCrLf
            End If
            _Agentes += "- " & _FlAgente.Item("NOKOFU").ToString.Trim
        Next

        _Agentes = "AGENTE:" & vbCrLf & vbCrLf & _Agentes

        If _Tbl_Agentes.Rows.Count > 1 Then
            _Agentes = _Agentes.Replace("AGENTE:", "AGENTES:")
        End If

        MessageBoxEx.Show(Me, _Agentes, "Agentes asociados", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Btn_Mnu_RechazarTicket_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_RechazarTicket.Click
        Sb_Agregar_Mensaje_Respuesta(True)
    End Sub

    Private Sub Btn_Mnu_EnviarMensajeRespuesta_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_EnviarMensajeRespuesta.Click
        Sb_Agregar_Mensaje_Respuesta(False)
    End Sub

    Private Sub Frm_Tickets_Seguimiento_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Toma" & vbCrLf &
                       "Where CodFuncionario = '" & FUNCIONARIO & "' And NombreEquipo = '" & _NombreEquipo & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql)

    End Sub

    Private Sub Btn_GestionarAcciones_Click(sender As Object, e As EventArgs) Handles Btn_GestionarAcciones.Click

        Btn_Mnu_RechazarTicket.Visible = Not Mis_Ticket
        Btn_Mnu_RechazarTicket.Enabled = Not _Ticket.Tickets.Rechazado
        Btn_Mnu_CerrarTicketCrearNuevo.Visible = Not Mis_Ticket

        If Btn_Mnu_CerrarTicketCrearNuevo.Visible Then Btn_Mnu_CerrarTicketCrearNuevo.Visible = Not _Tipo.CerrarAgenteSinPerm

        Btn_Anular.Visible = (Grilla.RowCount = 1)

        ShowContextMenu(Menu_Contextual_Cambio_Estado)

    End Sub

    Private Sub Btn_Mnu_TkAntecesor_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_TkAntecesor.Click

        If Not CBool(_Ticket.Tickets.Id_Padre) Then
            MessageBoxEx.Show(Me, "Este Ticket no tiene Ticket de Origen", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_Tickets_Seguimiento(_Ticket.Tickets.Id_Padre)
        Fm.SoloLectura = True
        Fm.CorrerALaDerecha = True
        Fm.vTop = Me.Top + 15
        Fm.vLeft = Me.Left + 15
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Mnu_TkSucesor_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_TkSucesor.Click

        Dim _Id_Sucesor As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Stk_Tickets",
                                                       "Id", "Id_Padre = " & _Ticket.Tickets.Id, True)

        If Not CBool(_Id_Sucesor) Then
            MessageBoxEx.Show(Me, "Este Ticket no tiene Ticket Sucesor", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_Tickets_Seguimiento(_Id_Sucesor)
        Fm.SoloLectura = True
        Fm.CorrerALaDerecha = True
        Fm.vTop = Me.Top + 15
        Fm.vLeft = Me.Left + 15
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_VerTicketOrigen_Click(sender As Object, e As EventArgs) Handles Btn_VerTicketOrigen.Click

        Btn_Mnu_TkAntecesor.Visible = True
        Btn_Mnu_TkSucesor.Visible = True

        ShowContextMenu(Menu_Contextual_Ticker_Traza)

    End Sub

    Private Sub Btn_Mnu_TkHistoria_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_TkHistoria.Click

        Dim _Lista As List(Of LsValiciones.Mensajes) = Fx_Cargar_Traza(_Ticket.Tickets.Id_Raiz)

        'Dim ListaQr As LsValiciones.Mensajes = _Lista.FirstOrDefault(Function(p) p.EsCorrecto = False)

        'If Not IsNothing(ListaQr) Then

        '    MessageBoxEx.Show(Me, "Hay documentos con problemas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        'End If

        Dim _Columan1 As New LsValiciones.Columnas
        Dim _Columan2 As New LsValiciones.Columnas
        Dim _Columan3 As New LsValiciones.Columnas
        Dim _Columan4 As New LsValiciones.Columnas

        _Columan1.Nombre = "Ticket"
        _Columan1.Descripcion = "Detalle"
        _Columan1.Ancho = 200

        _Columan2.Nombre = "Accion"
        _Columan2.Descripcion = "Acción"
        _Columan2.Ancho = 140

        _Columan3.Nombre = "Descripcion"
        _Columan3.Descripcion = "Descripción"
        _Columan3.Ancho = 400

        _Columan4.Nombre = "Fecha"
        _Columan4.Descripcion = "Fecha/Hora"
        _Columan4.Ancho = 150

        Dim _Imagenes_List As ImageList

        Dim Fmv As New Frm_Validaciones
        Fmv.Columan1 = _Columan1
        Fmv.Columan2 = _Columan2
        Fmv.Columan3 = _Columan3
        Fmv.Columan4 = _Columan4
        Fmv.ListaMensajes = _Lista
        Fmv.UsarImagenesExternas = True

        If Global_Thema = Enum_Themas.Oscuro Then
            _Imagenes_List = Imagenes_16x16_Dark
        Else
            _Imagenes_List = Imagenes_16x16
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Tickets Where Id = " & _Ticket.Tickets.Id_Raiz
        Dim _RowTicketRaiz As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Fmv.ListaDeImagenesExternas = _Imagenes_List
        Fmv.Text = "TRAZA DE TICKET ORIGEN " & _RowTicketRaiz.Item("Numero").ToString.Trim & ", Asunto: " & _RowTicketRaiz.Item("Asunto").ToString.Trim
        Fmv.ShowDialog(Me)
        Fmv.Dispose()

    End Sub

    Function Fx_Cargar_Traza(_Id_Raiz As Integer) As List(Of LsValiciones.Mensajes)

        Dim _Lista As New List(Of LsValiciones.Mensajes)
        Dim _FechaHoy As DateTime = FechaDelServidor()

        Consulta_sql = "Select Tk.Id As 'Id_Ticket',Tk.Id_Padre,Tk.Id_Raiz,Acc.Id As 'Id_Accion'," & vbCrLf &
                       "(Select Numero From " & _Global_BaseBk & "Zw_Stk_Tickets Where Id = Tk.Id_Raiz) As 'Ticket_Origen'," & vbCrLf &
                       "Tk.Numero,Tk.Asunto,Acc.CodFunGestiona,Cf.NOKOFU As 'NombreFunGestiona',Acc.Accion,Acc.Fecha," & vbCrLf &
                       "Case Acc.CodFunGestiona When Acc.CodFuncionario Then 'FunCrea' When Acc.CodAgente Then 'FunAge' End As 'FunAccion'," & vbCrLf &
                       "Case Accion " & vbCrLf &
                       "When 'CREA' Then 'Crea Ticket' " & vbCrLf &
                       "When 'MENS' Then 'Mensaje' " & vbCrLf &
                       "When 'RESP' Then 'Respuesta' " & vbCrLf &
                       "When 'NULO' Then 'Anula' " & vbCrLf &
                       "When 'SOLC' Then 'Sol. Cierre' " & vbCrLf &
                       "When 'CERR' Then 'Cierra ticket' " & vbCrLf &
                       "When 'CECR' Then 'Cierra y crea nuevo ticket' " & vbCrLf &
                       "When 'RECH' Then 'Rechazado' Else '???' End As 'StrAccion'," & vbCrLf &
                       "Acc.Descripcion," & vbCrLf &
                       "Case Accion When 'CECR' Then Tk.Numero Else '' End As 'Ticket Cierra'," & vbCrLf &
                       "Case Accion " & vbCrLf &
                       "When 'CREA' Then Tk.Numero " & vbCrLf &
                       "When 'CECR' Then (Select Top 1 Numero From " & _Global_BaseBk & "Zw_Stk_Tickets Where Id_Padre = Tk.Id) " & vbCrLf &
                       "Else '' End As 'Ticket Crea'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Acc" & vbCrLf &
                       "Left Join TABFU Cf On Cf.KOFU = CodFunGestiona" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Stk_Tickets Tk On Tk.Id = Acc.Id_Ticket" & vbCrLf &
                       "Where" & vbCrLf &
                       "Id_Ticket In (Select Id From " & _Global_BaseBk & "Zw_Stk_Tickets Where Id_Raiz = " & _Id_Raiz & ")" & vbCrLf &
                       "Order By Id_Ticket,Fecha"

        Dim _Tbl_Documentos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _UltNumero = String.Empty

        For Each _Fila As DataRow In _Tbl_Documentos.Rows

            Dim _Mensaje_Stem As New LsValiciones.Mensajes

            Dim _NombreImagen As String

            _Mensaje_Stem.EsCorrecto = True

            If _Fila.Item("FunAccion") = "FunCrea" Then _NombreImagen = "people-customer-man.png"
            If _Fila.Item("FunAccion") = "FunAge" Then _NombreImagen = "people-vendor.png"

            If String.IsNullOrEmpty(_UltNumero) Or _UltNumero <> _Fila.Item("Numero") Then
                _Mensaje_Stem.Mensaje = "Ticket Nro: " & _Fila.Item("Numero")
                _NombreImagen = "ticket-new.png"
            Else
                _Mensaje_Stem.Mensaje = _Fila.Item("NombreFunGestiona").ToString.Trim
            End If

            'If _Fila.Item("Accion") = "CREA" Then _NombreImagen = "people-customer-man.png"
            'If _Fila.Item("Accion") = "MENS" Then _NombreImagen = "people-customer-man.png"
            'If _Fila.Item("Accion") = "RESP" Then _NombreImagen = "people-vendor.png"
            'If _Fila.Item("Accion") = "CECR" Then _NombreImagen = "people-vendor.png"
            'If _Fila.Item("Accion") = "RECH" Then _NombreImagen = "people-vendor-error.png"

            _Mensaje_Stem.UsarImagen = True
            _Mensaje_Stem.NombreImagen = _NombreImagen

            _UltNumero = _Fila.Item("Numero")

            _Mensaje_Stem.Detalle = _Fila.Item("StrAccion")
            _Mensaje_Stem.Resultado = _Fila.Item("Descripcion")
            _Mensaje_Stem.Fecha = _Fila.Item("Fecha")
            _Mensaje_Stem.Tag = "Ticket Nro: " & _Fila.Item("Numero").ToString.Trim & vbCrLf &
                                    "Func: " & _Fila.Item("NombreFunGestiona").ToString.Trim & ", Accion:" & _Fila.Item("StrAccion").ToString.Trim & vbCrLf &
                                    "Descripción:" & _Fila.Item("Descripcion").ToString.Trim

            _Lista.Add(_Mensaje_Stem)

        Next

        Return _Lista

    End Function

End Class

