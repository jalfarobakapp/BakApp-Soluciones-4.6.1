﻿Imports DevComponents.DotNetBar

Public Class Frm_Tickets_Seguimiento

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Ticket As Integer
    Dim _Tbl_Acciones As DataTable
    Dim _Funcionario As String

    Dim _Cl_Tickets As New Cl_Tickets
    Dim _Zw_Stk_Tipos As New Zw_Stk_Tipos

    Dim _Row_UltMensaje As DataRow
    Public Property Mis_Ticket As Boolean
    Public Property SoloLectura As Boolean
    Public Property CorrerALaDerecha As Boolean
    Public Property TicketSucesor As Boolean
    Public Property TicketAntecesor As Boolean
    Public Property GestionRealizada As Boolean
    Public Property Aprobado As Boolean
    Public Property Rechazado As Boolean
    Public Property Anulado As Boolean
    Public Property vTop As Integer
    Public Property vLeft As Integer


    Public Sub New(_Id_Ticket As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Ticket = _Id_Ticket
        Me._Funcionario = _Funcionario

        Dim _Mensaje As LsValiciones.Mensajes

        _Mensaje = _Cl_Tickets.Fx_Llenar_Ticket(_Id_Ticket)
        _Mensaje = _Cl_Tickets.FX_Llenar_Producto(_Cl_Tickets.Zw_Stk_Tickets.Id_Raiz)

        _Cl_Tickets.Zw_Stk_Tickets_Producto = _Mensaje.Tag

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones" & vbCrLf &
                       "Where Id_Ticket = " & _Id_Ticket & " And Accion = 'MENS'" & vbCrLf &
                       "Order By Id Desc"
        _Row_UltMensaje = _Sql.Fx_Get_DataRow(Consulta_sql)

        Sb_Formato_Generico_Grilla(Grilla, 22, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Color_Botones_Barra(Bar2)

        If _Cl_Tickets.Zw_Stk_Tickets.CodFuncionario_Crea = FUNCIONARIO Then
            Mis_Ticket = True
        End If

    End Sub

    Private Sub Frm_Tickets_Seguimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "TICKET NRO: " & _Cl_Tickets.Zw_Stk_Tickets.Numero & " (" & _Cl_Tickets.Zw_Stk_Tickets.Id & ")"

        If CorrerALaDerecha Then
            Me.Top = vTop
            Me.Left = vLeft
        End If

        If SoloLectura Then
            Me.Text += " (SOLO LECTURA)"
        End If

        Btn_MensajeRespuesta.Visible = Not SoloLectura
        Btn_GestionarAcciones.Visible = Not SoloLectura

        If Not SoloLectura Then

            If Mis_Ticket Then
                Btn_MensajeRespuesta.Text = "Nuevo mensaje"
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Set Visto = 1 Where Id_Ticket = " & _Id_Ticket & " And Accion In ('RESP')"
                Btn_Mnu_SolicitarCierre.Enabled = False
            Else
                Btn_MensajeRespuesta.Text = "Responder"
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Set Visto = 1 Where Id_Ticket = " & _Id_Ticket & " And Accion In ('MENS','CREA')"
                Btn_Anular.Enabled = False
            End If

            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

        Select Case _Cl_Tickets.Zw_Stk_Tickets.Estado
            Case "ABIE"
                Lbl_Estado.Text = "Abierto"
            Case "CERR"
                Lbl_Estado.Text = "Cerrado"
            Case "NULO"
                Lbl_Estado.Text = "Nulo"
            Case "PROC"
                Lbl_Estado.Text = "En proceso"
            Case Else
                Lbl_Estado.Text = "???"
        End Select

        Lbl_Area.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Stk_Areas", "Area", "Id = " & _Cl_Tickets.Zw_Stk_Tickets.Id_Area)
        Lbl_Tipo.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Stk_Tipos", "Tipo", "Id = " & _Cl_Tickets.Zw_Stk_Tickets.Id_Tipo)
        Lbl_FechaCreacion.Text = _Cl_Tickets.Zw_Stk_Tickets.FechaCreacion
        Txt_Producto.Text = _Cl_Tickets.Zw_Stk_Tickets_Producto.Codigo & " - " & _Cl_Tickets.Zw_Stk_Tickets_Producto.Descripcion

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
        Sb_InsertarBotonenGrilla(Grilla, "Btn_ProductoInfo", "P.I.", "ProductoInfo", 0, _Tipo_Boton.Imagen)
        Sb_InsertarBotonenGrilla(Grilla, "Btn_DocCierra", "Doc.", "DocCierra", 0, _Tipo_Boton.Imagen)
        Sb_InsertarBotonenGrilla(Grilla, "Btn_ImagenUser", "Est.", "ImagenUser", 0, _Tipo_Boton.Imagen)

        Sb_Actualizar_Grilla()

        If Not SoloLectura Then

            Btn_MensajeRespuesta.Visible = Not (_Cl_Tickets.Zw_Stk_Tickets.Estado = "CERR" Or _Cl_Tickets.Zw_Stk_Tickets.Estado = "NULO")
            Btn_GestionarAcciones.Visible = Not (_Cl_Tickets.Zw_Stk_Tickets.Estado = "CERR" Or _Cl_Tickets.Zw_Stk_Tickets.Estado = "NULO")

            Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Toma Where NombreEquipo = '" & _NombreEquipo & "'" & vbCrLf &
                           "Insert Into " & _Global_BaseBk & "Zw_Stk_Tickets_Toma (Id_Ticket,CodFuncionario,FechaToma,NombreEquipo) " &
                           "Values (" & _Id_Ticket & ",'" & FUNCIONARIO & "',Getdate(),'" & _NombreEquipo & "')"
            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        End If

        _Zw_Stk_Tipos = _Cl_Tickets.Fx_Llenar_Tipo(_Cl_Tickets.Zw_Stk_Tickets.Id_Tipo)

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select Tk.Id As 'Id_Ticket',Tk.Id_Padre,Tk.Id_Raiz,Acc.Id As 'Id_Accion'," & vbCrLf &
                       "(Select Numero From " & _Global_BaseBk & "Zw_Stk_Tickets Where Id = Tk.Id_Raiz) As 'Ticket_Origen'," & vbCrLf &
                       "Tk.Numero,Tk.SubNro,Acc.Asunto,Acc.CodFunGestiona,Cf.NOKOFU As 'NombreFunGestiona',Acc.Accion,Acc.Fecha,Acc.CodFuncionario," & vbCrLf &
                       "Case Acc.CodFunGestiona When Acc.CodFuncionario Then 'FunCrea' When Acc.CodAgente Then 'FunAge' End As 'FunAccion',Acc.Aceptado,Acc.Rechazado," & vbCrLf &
                       "Case Acc.Accion " & vbCrLf &
                       "When 'CREA' Then 'Crea Ticket' " & vbCrLf &
                       "When 'MENS' Then 'Mensaje' " & vbCrLf &
                       "When 'RESP' Then 'Mensaje' " & vbCrLf &
                       "When 'OBS'  Then 'Observación' " & vbCrLf &
                       "When 'NULO' Then 'Anula' " & vbCrLf &
                       "When 'SOLC' Then 'Sol. Cierre' " & vbCrLf &
                       "When 'ACCI' Then 'Acepta y cierra ticket' " & vbCrLf &
                       "When 'RECI' Then 'Rechaza y cierra ticket' " & vbCrLf &
                       "When 'CERR' Then 'Cierra ticket' " & vbCrLf &
                       "When 'CECR' Then 'Acepta y crea nuevo ticket' " & vbCrLf &
                       "When 'RECH' Then 'Rechazado' Else '???' End As 'StrAccion'," & vbCrLf &
                       "Cf.NOKOFU As 'NombreFunAge'," & vbCrLf &
                       "(Select COUNT(*) From " & _Global_BaseBk & "Zw_Stk_Tickets_Archivos Where Id_TicketAc = Acc.Id) As 'Num_Attach'," & vbCrLf &
                       "(Select COUNT(*) From " & _Global_BaseBk & "Zw_Stk_Tickets_Producto Where Id_TicketAc = Acc.Id) As 'Producto_Attach'," & vbCrLf &
                       "Acc.Descripcion," & vbCrLf &
                       "Case CreaNewTicket When 1 Then Tk.SubNro Else '' End As 'Ticket Crea'," & vbCrLf &
                       "ISNULL(Tkc.SubNro,'') As 'Ticket Cierra'," & vbCrLf &
                       "Acc.Tido_Cierra,Acc.Nudo_Cierra,Acc.Idmaeedo_Cierra,Acc.ConfSinDoc_Cierra" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Acc" & vbCrLf &
                       "Left Join TABFU Cf On Cf.KOFU = CodFunGestiona" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Stk_Tickets Tk On Tk.Id = Acc.Id_Ticket" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Stk_Tickets Tkc On Tkc.Id = Acc.Id_Ticket_Cierra " & vbCrLf &
                       "Where" & vbCrLf &
                       "Id_Ticket In (Select Id From " & _Global_BaseBk & "Zw_Stk_Tickets Where Id_Raiz = " & _Cl_Tickets.Zw_Stk_Tickets.Id_Raiz & ")" & vbCrLf &
                       "Order By Fecha --,Id_Ticket"

        _Tbl_Acciones = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Acciones

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Btn_ImagenUser").Width = 40
            .Columns("Btn_ImagenUser").HeaderText = "User"
            .Columns("Btn_ImagenUser").Visible = True
            .Columns("Btn_ImagenUser").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SubNro").Visible = True
            .Columns("SubNro").HeaderText = "Sub"
            .Columns("SubNro").Width = 30
            .Columns("SubNro").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StrAccion").Visible = True
            .Columns("StrAccion").HeaderText = "Acción"
            .Columns("StrAccion").Width = 150
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

            .Columns("Asunto").Visible = True
            .Columns("Asunto").HeaderText = "Asunto"
            .Columns("Asunto").Width = 220
            .Columns("Asunto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Btn_ProductoInfo").Width = 40
            .Columns("Btn_ProductoInfo").HeaderText = "P.I."
            .Columns("Btn_ProductoInfo").ToolTipText = "Información del producto"
            .Columns("Btn_ProductoInfo").Visible = True
            .Columns("Btn_ProductoInfo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Btn_ImagenAttach").Width = 40
            .Columns("Btn_ImagenAttach").HeaderText = "Att."
            .Columns("Btn_ImagenAttach").ToolTipText = "Archivos adjuntos"
            .Columns("Btn_ImagenAttach").Visible = True
            .Columns("Btn_ImagenAttach").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Btn_DocCierra").Width = 40
            .Columns("Btn_DocCierra").HeaderText = "Doc."
            .Columns("Btn_DocCierra").ToolTipText = "Documento de ajuste"
            .Columns("Btn_DocCierra").Visible = True
            .Columns("Btn_DocCierra").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ConfSinDoc_Cierra").Width = 40
            .Columns("ConfSinDoc_Cierra").HeaderText = "C.S.D."
            .Columns("ConfSinDoc_Cierra").ToolTipText = "Confirma cierre sin documento adjunto"
            .Columns("ConfSinDoc_Cierra").Visible = True
            .Columns("ConfSinDoc_Cierra").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha").Visible = True
            .Columns("Fecha").HeaderText = "Fecha creación"
            '.Columns("Fecha").ToolTipText = "de tope de la oferta"
            '.Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").Width = 110
            .Columns("Fecha").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Dim _CodFunInicia As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Stk_Tickets", "CodFuncionario_Crea", "Id = " & _Cl_Tickets.Zw_Stk_Tickets.Id_Raiz)

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Icono As Image
            Dim _Nombre_Image As String
            Dim _Accion As String = _Fila.Cells("Accion").Value
            Dim _Aceptado As Boolean = _Fila.Cells("Aceptado").Value
            Dim _Rechazado As Boolean = _Fila.Cells("Rechazado").Value
            Dim _Num_Attach As Integer = _Fila.Cells("Num_Attach").Value
            Dim _Producto_Attach As Integer = _Fila.Cells("Producto_Attach").Value
            Dim _Idmaeedo_Cierra As Integer = _Fila.Cells("Idmaeedo_Cierra").Value

            Dim _CodFuncionario As String = _Fila.Cells("CodFuncionario").Value.ToString.Trim
            Dim _CodFunGestiona As String = _Fila.Cells("CodFunGestiona").Value.ToString.Trim

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

            If _CodFunGestiona = _CodFunInicia Then
                _Icono = _Imagenes_List.Images.Item("people-customer-man.png")
                If _Accion = "OBS" Then _Icono = _Imagenes_List.Images.Item("people-customer-man-note.png")
            Else
                _Icono = _Imagenes_List.Images.Item("people-vendor.png")
                If _Aceptado Then _Icono = _Imagenes_List.Images.Item("people-vendor-ok.png")
                If _Rechazado Then _Icono = _Imagenes_List.Images.Item("people-vendor-error.png")
                If _Accion = "OBS" Then _Icono = _Imagenes_List.Images.Item("people-vendor-note.png")
            End If

            If _Accion = "NULO" Then
                _Icono = _Imagenes_List.Images.Item("delete_button_error.png")
            End If

            _Fila.Cells("Btn_ImagenUser").Value = _Icono

            If CBool(_Producto_Attach) Then
                _Icono = _Imagenes_List.Images.Item("product-info.png")
            Else
                _Icono = _Imagenes_List.Images.Item("menu-more.png")
            End If
            _Fila.Cells("Btn_ProductoInfo").Value = _Icono

            If CBool(_Idmaeedo_Cierra) Then
                _Icono = _Imagenes_List.Images.Item("document-browse.png")
            Else
                _Icono = _Imagenes_List.Images.Item("menu-more.png")
            End If
            _Fila.Cells("Btn_DocCierra").Value = _Icono

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
            Dim _NombreFunGestiona As String = _Fila.Cells("NombreFunGestiona").Value
            Dim _StrAccion As String = _Fila.Cells("StrAccion").Value
            Dim _Asunto As String = _Fila.Cells("Asunto").Value
            Txt_Descripcion.Text = _NombreFunGestiona & " " & _StrAccion.ToUpper & vbCrLf & "Asunto: " & _Asunto & vbCrLf & "Detalle: " & _Fila.Cells("Descripcion").Value
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

        If _Cl_Tickets.Zw_Stk_Tickets.Rechazado Then
            Sb_Agregar_Mensaje_Respuesta(False)
        End If

    End Sub

    Sub Sb_Agregar_Mensaje_Respuesta(_RechazarTicket As Boolean)

        Dim _Grabar As Boolean
        Dim _Descripcion As String
        Dim _Cl_Tickets2 As New Cl_Tickets
        Dim _Zw_Stk_Tickets_Acciones As New Zw_Stk_Tickets_Acciones

        With _Zw_Stk_Tickets_Acciones

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

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje = _Cl_Tickets2.Fx_Grabar_Nueva_Accion2(_Zw_Stk_Tickets_Acciones, True)

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        _Zw_Stk_Tickets_Acciones.Id = _Mensaje.Id

        Dim Fm As New Frm_Tickets_Respuesta(_Zw_Stk_Tickets_Acciones.Id)

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

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Where Id = " & _Zw_Stk_Tickets_Acciones.Id & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Archivos Where Id_TicketAc = " & _Zw_Stk_Tickets_Acciones.Id
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Return

        End If

        Consulta_sql = String.Empty

        If _RechazarTicket Then
            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tickets Set Rechazado = " & Convert.ToInt32(_RechazarTicket) & vbCrLf &
                           "Where Id_Raiz = " & _Cl_Tickets.Zw_Stk_Tickets.Id_Raiz & vbCrLf
        End If

        Consulta_sql += "Update " & _Global_BaseBk & "Zw_Stk_Tickets Set UltAccion = '" & _Zw_Stk_Tickets_Acciones.Accion & "' Where Id = " & _Id_Ticket & vbCrLf &
                        "Update " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Set Visto = 1 Where Id_Ticket = " & _Id_Ticket & vbCrLf &
                        "Update " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Set " &
                        "Fecha = Getdate(),Descripcion = '" & _Descripcion & "',En_Construccion = 0,Visto = 0,Rechazado = " & Convert.ToInt32(_RechazarTicket) & vbCrLf &
                        "Where Id = " & _Zw_Stk_Tickets_Acciones.Id
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

    Function Fx_Agregar_Mensaje_Respuesta(_RechazarTicket As Boolean,
                                          _Observacion As Boolean) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim _Grabar As Boolean
            Dim _Descripcion As String

            Dim _Cl_Tickets2 As New Cl_Tickets
            Dim _Zw_Stk_Tickets_Acciones As New Zw_Stk_Tickets_Acciones

            With _Zw_Stk_Tickets_Acciones

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

                If _Observacion Then
                    .CodFuncionario = FUNCIONARIO
                    .CodAgente = FUNCIONARIO
                    .Accion = "OBS"
                End If

                .CodFunGestiona = FUNCIONARIO
                .Descripcion = ""

            End With

            Dim _Mensaje_Tk As New LsValiciones.Mensajes

            _Mensaje_Tk = _Cl_Tickets2.Fx_Grabar_Nueva_Accion2(_Zw_Stk_Tickets_Acciones, True)

            If Not _Mensaje_Tk.EsCorrecto Then
                _Mensaje.Detalle = "Error al grabar"
                Throw New System.Exception(_Mensaje.Mensaje)
            End If

            _Zw_Stk_Tickets_Acciones.Id = _Mensaje_Tk.Id

            Dim Fm As New Frm_Tickets_Respuesta(_Zw_Stk_Tickets_Acciones.Id)

            If Mis_Ticket Then
                Fm.Text = "NUEVO MENSAJE"
            Else
                Fm.Text = "RESPONDER"
            End If

            If _Observacion Then
                Fm.Text = "OBSERCACIONES"
            End If

            Fm.Btn_Archivos_Adjuntos.Enabled = Not _RechazarTicket
            Fm.ShowDialog(Me)
            _Grabar = Fm.Grabar
            _Descripcion = Fm.Txt_Descripcion.Text.Trim
            Fm.Dispose()

            If Not _Grabar Then

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Where Id = " & _Zw_Stk_Tickets_Acciones.Id & vbCrLf &
                               "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Archivos Where Id_TicketAc = " & _Zw_Stk_Tickets_Acciones.Id
                _Sql.Ej_consulta_IDU(Consulta_sql)

                _Mensaje.Detalle = "Acción"
                Throw New System.Exception("No se realiza ninguna acción")

            End If

            Consulta_sql = String.Empty

            If _RechazarTicket Then
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tickets Set Estado = 'CERR' Rechazado = " & Convert.ToInt32(_RechazarTicket) & vbCrLf &
                               "Where Id_Raiz = " & _Cl_Tickets.Zw_Stk_Tickets.Id_Raiz & vbCrLf
            End If

            Consulta_sql += "Update " & _Global_BaseBk & "Zw_Stk_Tickets Set UltAccion = '" & _Zw_Stk_Tickets_Acciones.Accion & "' Where Id = " & _Id_Ticket & vbCrLf &
                            "Update " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Set Visto = 1 Where Id_Ticket = " & _Id_Ticket & vbCrLf &
                            "Update " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Set " &
                            "Fecha = Getdate(),Descripcion = '" & _Descripcion & "',En_Construccion = 0,Visto = 0,Rechazado = " & Convert.ToInt32(_RechazarTicket) & vbCrLf &
                            "Where Id = " & _Zw_Stk_Tickets_Acciones.Id
            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

            If _RechazarTicket Then

                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "Rechazar Ticket"
                _Mensaje.Mensaje = "Ticket Rechazado, se ha enviado la confirmación al remitente"
                _Mensaje.Icono = MessageBoxIcon.Information

            Else

                _Mensaje.Detalle = "Información"
                _Mensaje.Mensaje = "Mensaje enviado correctamente"
                _Mensaje.MostrarMensaje = False

                If MessageBoxEx.Show(Me, "Mensaje enviado correctamente" & vbCrLf & vbCrLf & "¿Desea cerrar el formulario?",
                                     "Información",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    _Mensaje.EsCorrecto = True
                Else
                    Sb_Actualizar_Grilla()
                End If

            End If

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop
        End Try

        Return _Mensaje

    End Function

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id_Ticket As Integer = _Fila.Cells("Id_Ticket").Value
        Dim _Id_TicketAc As Integer = _Fila.Cells("Id_Accion").Value
        Dim _Num_Attach As Integer = _Fila.Cells("Num_Attach").Value

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name


    End Sub

    Private Sub Btn_Estadisticas_Producto_Click(sender As Object, e As EventArgs) Handles Btn_Estadisticas_Producto.Click

        Dim _Codigo As String = _Cl_Tickets.Zw_Stk_Tickets_Producto.Codigo

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

            'If Not _Zw_Stk_Tipos.CerrarAgenteSinPerm Then
            If Not Fx_Tiene_Permiso(Me, "Tkts0001") Then
                Return
            End If
            'End If

        End If

        Fx_Cerrar_Ticket(True, False, False, False, 0, False, False, True, True)

    End Sub

    Private Sub Btn_Mnu_SolicitarCierre_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_SolicitarCierre.Click
        Fx_Cerrar_Ticket(False, True, False, False, 0, False, False, False, False)
    End Sub

    Private Sub Btn_Mnu_CerrarTicketCrearNuevo_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_CerrarTicketCrearNuevo.Click

        If Not Mis_Ticket Then

            If _Cl_Tickets.Zw_Stk_Tickets.Rechazado Then
                If MessageBoxEx.Show(Me, "Este ticket fue rechazado." & vbCrLf &
                                  "¿Confirma crear un nuevo Ticket a partir de este, esto revertira el rechazo?",
                                     "Ticket Rechazado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                    Return
                End If
            End If

        End If

        Dim _Grabar As Boolean
        Dim _Cerrar As Boolean
        Dim _Id_Hijo As Integer

        Dim Fm As New Frm_Tickets_Mant(0)
        Fm.Id_Padre = _Id_Ticket
        Fm.Aceptado = True
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        If _Grabar Then
            _Cerrar = Fm.CerrarTicketAlFinalizar
            If _Cerrar Then
                _Id_Hijo = Fm.New_Ticket.Zw_Stk_Tickets.Id
            End If
        End If
        Fm.Dispose()

        If _Grabar Then
            If _Cerrar Then
                Fx_Cerrar_Ticket(True, False, True, False, _Id_Hijo, False, False, False, False)
            End If
            GestionRealizada = True
            Me.Close()
        End If

    End Sub

    Private Sub Btn_Anular_Click(sender As Object, e As EventArgs) Handles Btn_Anular.Click

        If MessageBoxEx.Show(Me, "¿Confirma la anulación del Ticket?", "Anular Ticket",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje = Fx_Cerrar_Ticket(False, False, False, True, 0, False, False, True, True)

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Alerta", MessageBoxButtons.OK, _Mensaje.Icono)
        End If

        Anulado = True

        Me.Close()

    End Sub

    Function Fx_Cerrar_Ticket(_Cierra_Ticket As Boolean,
                              _Solicita_Cierre As Boolean,
                              _CreaNewTicket As Boolean,
                              _AnulaTicket As Boolean,
                              _Id_Hijo As Integer,
                              _Aceptado As Boolean,
                              _Rechazado As Boolean,
                              _CierraTicketPadre As Boolean,
                              _CierraTicektRaiz As Boolean) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim _Aceptar As Boolean
            Dim _Descripcion As String

            Dim _Caption As String

            If _Cierra_Ticket Then
                _Caption = "Cerrar Ticket"
                If Not Mis_Ticket Then
                    _Descripcion = _Zw_Stk_Tipos.RespuestaXDefecto.Trim
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
                    _Mensaje.Cancelado = True
                    Throw New System.Exception("Acción cancelada por el usuario")
                End If

            End If

            _Mensaje.Detalle = _Descripcion

            If _CreaNewTicket Then

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Tickets Where Id = " & _Id_Hijo
                Dim _Row_Ticket_Hijo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _Numero_H As String = _Row_Ticket_Hijo.Item("Numero")
                Dim _Asunto_H As String = _Row_Ticket_Hijo.Item("Asunto")
                Dim _Descripcion_H As String = _Row_Ticket_Hijo.Item("Descripcion")

                _Descripcion = "SE GENERA EL TICKET Nro " & _Numero_H & " Asunto: " & _Asunto_H.ToString.Trim

            End If

            Dim _Zw_Stk_Tickets_Acciones As Zw_Stk_Tickets_Acciones

            If _AnulaTicket Then

                Dim _MsjAnula As New LsValiciones.Mensajes

                _Zw_Stk_Tickets_Acciones = New Zw_Stk_Tickets_Acciones

                With _Zw_Stk_Tickets_Acciones

                    .Id_Ticket = _Id_Ticket
                    .Id_Raiz = _Cl_Tickets.Zw_Stk_Tickets.Id_Raiz
                    .Id_Ticket_Cierra = _Cl_Tickets.Zw_Stk_Tickets.Id_Padre
                    .CodFuncionario = FUNCIONARIO
                    .CodAgente = String.Empty
                    .Accion = "NULO"
                    .CodFunGestiona = FUNCIONARIO
                    .Descripcion = _Descripcion
                    .Asunto = "TICKET ANULADO"
                    .Aceptado = False
                    .Rechazado = False

                End With

            End If

            Dim _Mensaje_Ticket As New LsValiciones.Mensajes

            _Mensaje_Ticket = _Cl_Tickets.Fx_Cerrar_Ticket(FUNCIONARIO,
                                                           _Descripcion,
                                                           _Cierra_Ticket,
                                                           _Solicita_Cierre,
                                                           _CreaNewTicket,
                                                           _AnulaTicket,
                                                           _Aceptado,
                                                           _Rechazado,
                                                           _CierraTicketPadre,
                                                           _CierraTicektRaiz,
                                                           _Zw_Stk_Tickets_Acciones)

            If Not _Mensaje_Ticket.EsCorrecto Then
                Throw New System.Exception(_Mensaje_Ticket.Mensaje)
            End If

            MessageBoxEx.Show(Me, _Mensaje_Ticket.Mensaje, _Caption, MessageBoxButtons.OK, MessageBoxIcon.Information)
            GestionRealizada = True

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = _Mensaje_Ticket.Mensaje
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop
        End Try

        Return _Mensaje

    End Function

    Function Fx_Rechazar_Ticket() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim _Aceptar As Boolean
            Dim _Descripcion As String

            _Aceptar = InputBox_Bk(Me, "Ingrese un comentario (obligatorio)", "Rechazar Ticket",
                   _Descripcion, True, _Tipo_Mayus_Minus.Mayusculas, 200, True,
                   _Tipo_Imagen.Texto, False,,,, Nothing)

            If Not _Aceptar Then
                _Mensaje.Cancelado = True
                Throw New System.Exception("Acción cancelada por el usuario")
            End If

            _Mensaje.Detalle = _Descripcion

            Dim _Zw_Stk_Tickets_Acciones As Zw_Stk_Tickets_Acciones

            Dim _MsjAnula As New LsValiciones.Mensajes

            _Zw_Stk_Tickets_Acciones = New Zw_Stk_Tickets_Acciones

            With _Zw_Stk_Tickets_Acciones

                .Id_Ticket = _Id_Ticket
                .Id_Raiz = _Cl_Tickets.Zw_Stk_Tickets.Id_Raiz
                .Id_Ticket_Cierra = _Cl_Tickets.Zw_Stk_Tickets.Id_Padre
                .CodFuncionario = FUNCIONARIO
                .CodAgente = String.Empty
                .Accion = "RECH"
                .CodFunGestiona = FUNCIONARIO
                .Descripcion = _Descripcion
                .Asunto = "RECHAZA TICKET"
                .Aceptado = False
                .Rechazado = True

            End With

            Dim _Mensaje_Ticket As New LsValiciones.Mensajes

            _Mensaje_Ticket = _Cl_Tickets.Fx_Cerrar_Ticket(FUNCIONARIO,
                                                           _Descripcion,
                                                           True,
                                                           False,
                                                           False,
                                                           False,
                                                           False,
                                                           True,
                                                           True,
                                                           True,
                                                           _Zw_Stk_Tickets_Acciones)

            If Not _Mensaje_Ticket.EsCorrecto Then
                Throw New System.Exception(_Mensaje_Ticket.Mensaje)
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = _Mensaje_Ticket.Mensaje
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Detalle = "Rechazar Ticket"

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop
        End Try

        Return _Mensaje

    End Function

    Private Sub Btn_Cerrar_Click(sender As Object, e As EventArgs) Handles Btn_Cerrar.Click
        Me.Close()
    End Sub

    Private Sub Btn_AgentesAsignados_Click(sender As Object, e As EventArgs) Handles Btn_AgentesAsignados.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Id_Ticket As Integer = _Fila.Cells("Id_Ticket").Value

        Consulta_sql = "Select Asg.*,NOKOFU" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stk_Tickets_Asignado Asg" & vbCrLf &
                       "Left Join TABFU On KOFU = Asg.CodAgente " & vbCrLf &
                       "Where Id_Ticket = " & _Id_Ticket
        Dim _Tbl_Agentes As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

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

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje = Fx_Rechazar_Ticket() 'Fx_Agregar_Mensaje_Respuesta(True)

        If _Mensaje.Cancelado Then
            Return
        End If

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If Not _Mensaje.EsCorrecto Then
            Sb_Actualizar_Grilla()
            Return
        End If

        GestionRealizada = True
        Me.Close()

    End Sub

    Private Sub Btn_Mnu_EnviarMensajeRespuesta_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_EnviarMensajeRespuesta.Click

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje = Fx_Agregar_Mensaje_Respuesta(False, False)

        GestionRealizada = _Mensaje.EsCorrecto

        If _Mensaje.MostrarMensaje Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)
        End If

        If GestionRealizada And Not _Mensaje.MostrarMensaje Then
            Me.Close()
        Else
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Frm_Tickets_Seguimiento_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Toma" & vbCrLf &
                       "Where CodFuncionario = '" & FUNCIONARIO & "' And NombreEquipo = '" & _NombreEquipo & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql)

    End Sub

    Private Sub Btn_GestionarAcciones_Click(sender As Object, e As EventArgs) Handles Btn_GestionarAcciones.Click

        Btn_Mnu_RechazarTicket.Visible = Not Mis_Ticket
        Btn_Mnu_RechazarTicket.Enabled = Not _Cl_Tickets.Zw_Stk_Tickets.Rechazado
        Btn_Mnu_CerrarTicketCrearNuevo.Visible = Not Mis_Ticket

        If Btn_Mnu_CerrarTicketCrearNuevo.Visible Then
            Btn_Mnu_CerrarTicketCrearNuevo.Visible = Not _Zw_Stk_Tipos.CerrarAgenteSinPerm
        End If

        Btn_Mnu_CerrarTicket.Visible = (_Zw_Stk_Tipos.EsTicketUnico And Not Mis_Ticket)
        Btn_Mnu_AceptarCerrarTicket.Visible = _Zw_Stk_Tipos.CierraRaiz

        Btn_Anular.Visible = (Grilla.RowCount = 1)

        ShowContextMenu(Menu_Contextual_Cambio_Estado)

    End Sub

    Private Sub Btn_Mnu_TkAntecesor_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_TkAntecesor.Click

        If Not CBool(_Cl_Tickets.Zw_Stk_Tickets.Id_Padre) Then
            MessageBoxEx.Show(Me, "Este Ticket no tiene Ticket de Origen", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_Tickets_Seguimiento(_Cl_Tickets.Zw_Stk_Tickets.Id_Padre)
        Fm.SoloLectura = True
        Fm.CorrerALaDerecha = True
        Fm.vTop = Me.Top + 15
        Fm.vLeft = Me.Left + 15
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Mnu_TkSucesor_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_TkSucesor.Click

        Dim _Id_Sucesor As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Stk_Tickets",
                                                       "Id", "Id_Padre = " & _Cl_Tickets.Zw_Stk_Tickets.Id, True)

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

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Tickets Where Id = " & _Cl_Tickets.Zw_Stk_Tickets.Id_Raiz
        Dim _RowTicketRaiz As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_RowTicketRaiz) Then
            MessageBoxEx.Show(Me, "No se encontró Ticket Raíz", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Lista As List(Of LsValiciones.Mensajes) = Fx_Cargar_Traza(_Cl_Tickets.Zw_Stk_Tickets.Id_Raiz)

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
        Fmv.Col1_Mensaje = _Columan1
        Fmv.Col2_Descripcion = _Columan2
        Fmv.Col3_Resultado = _Columan3
        Fmv.Col4_Fecha = _Columan4
        Fmv.ListaMensajes = _Lista
        Fmv.UsarImagenesExternas = True

        If Global_Thema = Enum_Themas.Oscuro Then
            _Imagenes_List = Imagenes_16x16_Dark
        Else
            _Imagenes_List = Imagenes_16x16
        End If

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
                       "When 'ACCI' Then 'Acepta y cierra ticket' " & vbCrLf &
                       "When 'RECI' Then 'Rechaza y cierra ticket' " & vbCrLf &
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

        Dim _Tbl_Documentos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

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

    Private Sub Grilla_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id_Ticket As Integer = _Fila.Cells("Id_Ticket").Value
        Dim _Id_TicketAc As Integer = _Fila.Cells("Id_Accion").Value
        Dim _Num_Attach As Integer = _Fila.Cells("Num_Attach").Value
        Dim _Producto_Attach As Integer = _Fila.Cells("Producto_Attach").Value
        Dim _Idmaeedo_Cierra As Integer = _Fila.Cells("Idmaeedo_Cierra").Value

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If _Cabeza = "Btn_ImagenAttach" Then

            If Not CBool(_Num_Attach) Then
                MessageBoxEx.Show(Me, "No hay archivos adjuntos que mostrar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Dim Fm As New Frm_Adjuntar_Archivos("Zw_Stk_Tickets_Archivos", "Id_TicketAc", _Id_TicketAc)
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

        If _Cabeza = "Btn_ProductoInfo" Then

            If Not CBool(_Producto_Attach) Then
                MessageBoxEx.Show(Me, "No hay archivos adjuntos que mostrar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Dim _Cl_Tickets2 As New Cl_Tickets

            Dim _Mensaje As LsValiciones.Mensajes = _Cl_Tickets2.FX_Llenar_Producto(_Id_Ticket)

            If Not _Mensaje.EsCorrecto Then
                MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Tickets_Producto" & vbCrLf &
                           "Where Id_Ticket = " & _Id_Ticket & " Or (Id_Padre = 0 And Id_Ticket = " & _Id_Ticket & ") Order By Id"
            Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            For Each _Fl As DataRow In _Tbl.Rows

                _Mensaje = _Cl_Tickets.FX_Llenar_Producto_Id(_Fl.Item("Id"))
                _Cl_Tickets2.Ls_Zw_Stk_Tickets_Producto.Add(_Mensaje.Tag)

            Next

            _Cl_Tickets2.Zw_Stk_Tickets_Producto = _Mensaje.Tag

            Dim Fm2 As New Frm_Tickets_IngProducto_GesXBod
            Fm2.ModoSoloLectura = True
            Fm2.Cl_Tickets = _Cl_Tickets2
            Fm2.ShowDialog(Me)
            Fm2.Dispose()

        End If

        If _Cabeza = "Btn_DocCierra" Then

            If Not CBool(_Idmaeedo_Cierra) Then
                MessageBoxEx.Show(Me, "No hay documentos adjuntos que mostrar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Dim Fm As New Frm_Ver_Documento(_Idmaeedo_Cierra, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
            Fm.Codigo_Marcar = _Cl_Tickets.Zw_Stk_Tickets_Producto.Codigo
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Mnu_AceptarCerrarTicket_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_AceptarCerrarTicket.Click

        Dim _Grabar As Boolean
        Dim _Id_Hijo As Integer

        Dim Fm As New Frm_Tickets_Mant(0)
        Fm.Id_Padre = _Id_Ticket
        Fm.Aceptado = True
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        If _Grabar Then
            _Id_Hijo = Fm.New_Ticket.Zw_Stk_Tickets.Id
        End If
        Fm.Dispose()

        GestionRealizada = True
        Me.Close()

    End Sub

    Private Sub Btn_Mnu_IngresarObservaciones_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_IngresarObservaciones.Click

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje = Fx_Agregar_Mensaje_Respuesta(False, True)

        GestionRealizada = _Mensaje.EsCorrecto

        If _Mensaje.MostrarMensaje Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)
        End If

        If GestionRealizada And Not _Mensaje.MostrarMensaje Then
            Me.Close()
        Else
            Sb_Actualizar_Grilla()
        End If

    End Sub

End Class

