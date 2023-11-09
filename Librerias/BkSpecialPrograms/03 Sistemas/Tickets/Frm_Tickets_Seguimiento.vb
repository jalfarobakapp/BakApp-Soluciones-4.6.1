Imports DevComponents.DotNetBar
Public Class Frm_Tickets_Seguimiento

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Ticket As Integer
    Dim _Row_Ticket As DataRow
    Dim _Tbl_Acciones As DataTable
    Dim _Funcionario As String

    'Dim _Cl_Tickets As New Cl_Tickets
    Dim _Row_UltMensaje As DataRow
    Public Property Mis_Ticket As Boolean

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

        '_Cl_Tickets.Sb_Llenar_Ticket(_Id_Ticket)

    End Sub

    Private Sub Frm_Tickets_Seguimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Mis_Ticket Then
            Btn_MensajeRespuesta.Text = "Nuevo mensaje"
            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Set Visto = 1 Where Id_Ticket = " & _Id_Ticket & " And Accion = 'RESP'"
        Else
            Btn_MensajeRespuesta.Text = "Responder"
            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Set Visto = 1 Where Id_Ticket = " & _Id_Ticket & " And Accion = 'MENS'"
        End If

        _Sql.Ej_consulta_IDU(Consulta_sql)

        Lbl_Estado.Text = _Row_Ticket.Item("NomEstado")
        Lbl_Area.Text = _Row_Ticket.Item("Area")
        Lbl_Tipo.Text = _Row_Ticket.Item("Tipo")
        Lbl_FechaCreacion.Text = _Row_Ticket.Item("FechaCreacion")
        Txt_Producto.Text = _Row_Ticket.Item("CodProducto").ToString.Trim & " - " & _Row_Ticket.Item("DesProducto").ToString.Trim

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

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select Acc.*,Case Accion When 'MENS' Then 'Mensaje' When 'RESP' Then 'Respuesta' Else '???' End As 'StrAccion'," &
                       "Case Accion When 'MENS' Then Isnull(Cf.NOKOFU,'') When 'RESP' Then Isnull(Ca.NOKOFU,'') Else '???' End As 'NombreFunAge'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Acc" & vbCrLf &
                       "Left Join TABFU Cf On Cf.KOFU = CodFuncionario" & vbCrLf &
                       "Left Join TABFU Ca On Ca.KOFU = CodAgente" & vbCrLf &
                       "Where Id_Ticket = " & _Id_Ticket
        _Tbl_Acciones = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Acciones

            .DataSource = _Tbl_Acciones

            OcultarEncabezadoGrilla(Grilla_Acciones)

            Dim _DisplayIndex = 0

            .Columns("StrAccion").Visible = True
            .Columns("StrAccion").HeaderText = "Acción"
            .Columns("StrAccion").Width = 100
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

            .Columns("Fecha").Visible = True
            .Columns("Fecha").HeaderText = "Fecha creación"
            '.Columns("Fecha").ToolTipText = "de tope de la oferta"
            '.Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").Width = 110
            .Columns("Fecha").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Try
            Grilla_Acciones.CurrentCell = Grilla_Acciones.Rows(Grilla_Acciones.RowCount - 1).Cells("StrAccion")
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Grilla_Acciones_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Acciones.CellEnter

        Try
            Dim _Fila As DataGridViewRow = Grilla_Acciones.CurrentRow
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
End Class
