Imports BkSpecialPrograms.Frm_Tickets_Lista
Imports BkSpecialPrograms.Frm_Ver_Documento
Imports DevComponents.DotNetBar

Public Class Frm_Tickets_Seguimiento

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Ticket As Integer
    Dim _Row_Ticket As DataRow
    Dim _Tbl_Acciones As DataTable
    Dim _Funcionario As String

    Dim _Row_UltMensaje As DataRow
    Public Property Mis_Ticket As Boolean
    Public Property SoloLectura As Boolean
    Public Property CorrerALaDerecha As Boolean

    Public Sub New(_Id_Ticket As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Ticket = _Id_Ticket
        Me._Funcionario = _Funcionario

        Consulta_sql = "Select Stk.*,Ar.Area,Tp.Tipo,Isnull(NOKOPR,'') As DesProducto" & vbCrLf &
                       ",Case Prioridad When 'AL' Then 'Alta' When 'NR' Then 'Normal' When 'BJ' Then 'Baja' When 'AL' Then 'Alta' Else '??' End As NomPrioridad" & vbCrLf &
                       ",Case UltAccion When 'INGR' then 'Ingresada' When 'MENS' then 'Mensaje' When 'RESP' then 'Respondido' When 'CERR' then 'Cerrada' End As UltimaAccion" & vbCrLf &
                       ",Case Estado When 'ABIE' then 'Abierto' When 'CERR' then 'Cerrado' When 'NULO' then 'Nulo' End As NomEstado" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stk_Tickets Stk" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Stk_Areas Ar On Stk.Id_Area = Ar.Id" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Stk_Tipos Tp On Tp.Id_Area = Stk.Id_Area And Tp.Id = Stk.Id_Tipo" & vbCrLf &
                       "Left Join MAEPR On KOPR = Stk.CodProducto" & vbCrLf &
                       "Where Stk.Id = " & _Id_Ticket
        _Row_Ticket = _Sql.Fx_Get_DataRow(Consulta_sql)

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Where Id_Ticket = " & _Id_Ticket & " And Accion = 'MENS'" & vbCrLf &
                       "Order By Id Desc"
        _Row_UltMensaje = _Sql.Fx_Get_DataRow(Consulta_sql)

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Tickets_Seguimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "TICKET NRO: " & _Row_Ticket.Item("Numero").ToString.Trim & " (" & _Row_Ticket.Item("Id") & ")"

        If CorrerALaDerecha Then
            Me.Top += 15
            Me.Left += 15
        End If

        Btn_MensajeRespuesta.Visible = Not SoloLectura
        Btn_CambiarEstado.Visible = Not SoloLectura
        Btn_VerTicketOrigen.Visible = Not SoloLectura

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

        Lbl_Estado.Text = _Row_Ticket.Item("NomEstado")
        Lbl_Area.Text = _Row_Ticket.Item("Area")
        Lbl_Tipo.Text = _Row_Ticket.Item("Tipo")
        Lbl_FechaCreacion.Text = _Row_Ticket.Item("FechaCreacion")
        Txt_Producto.Text = _Row_Ticket.Item("CodProducto").ToString.Trim & " - " & _Row_Ticket.Item("DesProducto").ToString.Trim

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

        InsertarBotonenGrilla(Grilla, "Btn_ImagenAttach", "Est.", "ImagenAttach", 0, _Tipo_Boton.Imagen)
        InsertarBotonenGrilla(Grilla, "Btn_ImagenUser", "Est.", "ImagenUser", 0, _Tipo_Boton.Imagen)

        Sb_Actualizar_Grilla()

        Btn_MensajeRespuesta.Visible = Not (_Row_Ticket.Item("Estado") = "CERR" Or _Row_Ticket.Item("Estado") = "NULO")
        Btn_CambiarEstado.Visible = Not (_Row_Ticket.Item("Estado") = "CERR" Or _Row_Ticket.Item("Estado") = "NULO")
        'Btn_CrearNuevoTicket.Visible = Not (_Row_Ticket.Item("Estado") = "CERR" Or _Row_Ticket.Item("Estado") = "NULO")

        Btn_VerTicketOrigen.Visible = CBool(_Row_Ticket.Item("Id_Padre"))

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select Acc.*,Case Accion When 'MENS' Then 'Mensaje' When 'RESP' Then 'Respuesta' When 'NULO' Then 'Anula' Else '???' End As 'StrAccion',Case Accion When 'MENS' Then Isnull(Cf.NOKOFU,'') When 'NULO' Then Isnull(Cf.NOKOFU,'') When 'RESP' Then Isnull(Ca.NOKOFU,'') Else '???' End As 'NombreFunAge'," & vbCrLf &
                       "(Select COUNT(*) From " & _Global_BaseBk & "Zw_Stk_Tickets_Archivos Where Id_TicketAc = Acc.Id) As 'Num_Attach'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Acc" & vbCrLf &
                       "Left Join TABFU Cf On Cf.KOFU = CodFuncionario" & vbCrLf &
                       "Left Join TABFU Ca On Ca.KOFU = CodAgente" & vbCrLf &
                       "Where Id_Ticket = " & _Id_Ticket
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
            .Columns("StrAccion").Width = 60
            .Columns("StrAccion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreFunAge").Visible = True
            .Columns("NombreFunAge").HeaderText = "De"
            .Columns("NombreFunAge").Width = 150
            .Columns("NombreFunAge").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Width = 250
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

            If _Accion = "MENS" Then
                '_Icono = Imagenes_16x16.Images.Item("user.png")
                '_Icono = Imagenes_16x16.Images.Item("people-employee.png")
                _Icono = Imagenes_16x16.Images.Item("people-customer-man.png")
            Else
                _Icono = Imagenes_16x16.Images.Item("people-vendor.png")
            End If

            _Fila.Cells("Btn_ImagenUser").Value = _Icono

        Next

        Try
            Grilla.CurrentCell = Grilla.Rows(Grilla.RowCount - 1).Cells("StrAccion")
        Catch ex As Exception

        End Try

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

        Dim _Grabar As Boolean
        Dim _Id_TicketAc As Integer
        Dim _Descripcion As String

        Dim _Cl_Tickets As New Cl_Tickets
        _Cl_Tickets.Sb_Llenar_Ticket(_Id_Ticket)

        _Id_TicketAc = _Cl_Tickets.Fx_Grabar_Nueva_Accion(_Funcionario, Mis_Ticket)

        Dim Fm As New Frm_Tickets_Respuesta(_Id_TicketAc)

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

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Where Id = " & _Id_TicketAc & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Archivos Where Id_TicketAc = " & _Id_TicketAc
            _Sql.Ej_consulta_IDU(Consulta_sql)
            Return
        End If

        Dim _Campo As String

        If Mis_Ticket Then
            _Campo = "CodFuncionario"
        Else
            _Campo = "CodAgente"
        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Set Visto = 1 Where Id_Ticket = " & _Id_Ticket & vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Set " &
                       _Campo & " = '" & FUNCIONARIO & "',Fecha = Getdate(),Descripcion = '" & _Descripcion & "',En_Construccion = 0,Visto = 0" & vbCrLf &
                       "Where Id = " & _Id_TicketAc
        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        Sb_Actualizar_Grilla()

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

    Private Sub Btn_CambiarEstado_Click(sender As Object, e As EventArgs) Handles Btn_CambiarEstado.Click
        ShowContextMenu(Menu_Contextual_Cambio_Estado)
    End Sub

    Private Sub Btn_Estadisticas_Producto_Click(sender As Object, e As EventArgs) Handles Btn_Estadisticas_Producto.Click

        Dim _Codigo As String = _Row_Ticket.Item("CodProducto")

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
        Sb_Cerrar_Ticket(True, False, False, False, 0)
    End Sub

    Private Sub Btn_Mnu_SolicitarCierre_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_SolicitarCierre.Click
        Sb_Cerrar_Ticket(False, True, False, False, 0)
    End Sub

    Private Sub Btn_Mnu_CerrarTicketCrearNuevo_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_CerrarTicketCrearNuevo.Click

        Dim _Grabar As Boolean
        Dim _Id_Hijo As Integer

        Dim Fm As New Frm_Tickets_Mant(0)
        Fm.Id_Padre = _Id_Ticket
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _Id_Hijo = Fm.New_Ticket.Tickets.Id
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

        If _Cierra_Ticket Then _Caption = "Cerrar Ticket"
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

    Private Sub Btn_VerTicketOrigen_Click(sender As Object, e As EventArgs) Handles Btn_VerTicketOrigen.Click

        Dim Fm As New Frm_Tickets_Seguimiento(_Row_Ticket.Item("Id_Padre"))
        Fm.SoloLectura = True
        Fm.CorrerALaDerecha = True
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

End Class
