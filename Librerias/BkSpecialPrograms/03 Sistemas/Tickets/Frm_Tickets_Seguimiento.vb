Imports DevComponents.DotNetBar
Public Class Frm_Tickets_Seguimiento

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Ticket As Integer
    Dim _Row_Ticket As DataRow
    Dim _Tbl_Acciones As DataTable

    Public Sub New(_Id_Ticket As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Ticket = _Id_Ticket

        Consulta_sql = "Select *" & vbCrLf &
                       ",Case Prioridad When 'AL' Then 'Alta' When 'NR' Then 'Normal' When 'BJ' Then 'Baja' When 'AL' Then 'Alta' Else '??' End As NomPrioridad" & vbCrLf &
                       ",Case UltAccion When 'INGR' then 'Ingresada' When 'MENS' then 'Mensaje' When 'RESP' then 'Respondido' When 'CERR' then 'Cerrada' End As UltimaAccion" & vbCrLf &
                       ",Case Estado When 'ABIE' then 'Abierto' When 'CERR' then 'Cerrado' When 'NULO' then 'Nulo' End As NomEstado" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stk_Tickets" & vbCrLf &
                       "Where Id = " & _Id_Ticket
        _Row_Ticket = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Private Sub Frm_Tickets_Seguimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Lbl_Estado.Text = _Row_Ticket.Item("NomEstado")
        Lbl_Area.Text = _Row_Ticket.Item("Area")
        Lbl_Tipo.Text = _Row_Ticket.Item("Tipo")
        Lbl_FechaCreacion.Text = _Row_Ticket.Item("FechaCreacion")

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

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Where Id_Ticket = " & _Id_Ticket
        _Tbl_Acciones = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Acciones

            .DataSource = _Tbl_Acciones

            OcultarEncabezadoGrilla(Grilla_Acciones)

            Dim _DisplayIndex = 0

            .Columns("Accion").Visible = True
            .Columns("Accion").HeaderText = "Acción"
            .Columns("Accion").Width = 100
            .Columns("Accion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Width = 300
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha").Visible = True
            .Columns("Fecha").HeaderText = "Fecha creación"
            '.Columns("Fecha").ToolTipText = "de tope de la oferta"
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").Width = 100
            .Columns("Fecha").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Grilla_Acciones_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Acciones.CellEnter

        Try
            Dim _Fila As DataGridViewRow = Grilla_Acciones.CurrentRow
            Txt_Descripcion.Text = _Fila.Cells("Descripcion").Value
        Catch ex As Exception
            Txt_Descripcion.Text = String.Empty
        End Try

    End Sub
End Class
