Imports DevComponents.DotNetBar
Public Class Frm_Tickets_Lista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Tickets As DataTable
    Dim _Funcionario As String
    Dim _Id_Grupo As Integer

    Dim _Tipo_Tickets As Enum_Tickets
    Enum Enum_Tickets
        MisTicket
        TicketAsignadosAgente
        TicketAsignadoGrupo
    End Enum

    Public Sub New(_Funcionario As String, _Tipo As Enum_Tickets, _Id_Grupo As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Funcionario = _Funcionario
        Me._Tipo_Tickets = _Tipo_Tickets
        Me._Id_Grupo = _Id_Grupo

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Tickets_Lista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub

    Sub Sb_Actualizar_Grilla()

        'Dim _Texto_Busqueda As String = Txt_Buscador.Text.Trim
        Dim _Condicion As String = String.Empty

        'Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(_Texto_Busqueda), "CODIGO+DESCRIPTOR Like '%")

        'If Not String.IsNullOrWhiteSpace(Txt_BuscaXProducto.Text) Then
        '_Condicion = "And CODIGO In (Select CODIGO From MAEDRES Where ELEMENTO = '" & Txt_BuscaXProducto.Text & "')"
        'End If

        Select Case _Tipo_Tickets
            Case Enum_Tickets.MisTicket
                _Condicion = "And CodFuncionario_Crea = '" & _Funcionario & "'"
            Case Enum_Tickets.TicketAsignadoGrupo
                _Condicion = "And Id_Grupo = " & _Id_Grupo
            Case Enum_Tickets.TicketAsignadosAgente
                _Condicion = "And CodAgente = '" & _Funcionario & "'"
        End Select

        Consulta_sql = "Select *" & vbCrLf &
                       ",Case Prioridad When 'AL' Then 'Alta' When 'NR' Then 'Normal' When 'BJ' Then 'Baja' When 'AL' Then 'Alta' Else '??' End As NomPrioridad" & vbCrLf &
                       ",Case UltAccion When 'INGR' then 'Ingresada' When 'MENS' then 'Mensaje' When 'RESP' then 'Respondido' When 'CERR' then 'Cerrada' End As UltimaAccion" & vbCrLf &
                       ",Case Estado When 'ABIE' then 'Abierto' When 'CERR' then 'Cerrado' When 'NULO' then 'Nulo' End As NomEstado" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stk_Tickets" & vbCrLf &
                       "Where 1 > 0" & vbCrLf & _Condicion

        _Tbl_Tickets = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Tickets

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            .Columns("Numero").Visible = True
            .Columns("Numero").HeaderText = "Número"
            .Columns("Numero").Width = 100
            .Columns("Numero").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Asunto").Visible = True
            .Columns("Asunto").HeaderText = "Asunto"
            .Columns("Asunto").Width = 300
            .Columns("Asunto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NomEstado").Visible = True
            .Columns("NomEstado").HeaderText = "Estado"
            .Columns("NomEstado").ToolTipText = "Estado del Ticket"
            '.Columns("NomEstado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("NomEstado").Width = 100
            .Columns("NomEstado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NomPrioridad").Visible = True
            .Columns("NomPrioridad").HeaderText = "Prioridad"
            '.Columns("NomPrioridad").ToolTipText = "Estado del Ticket"
            .Columns("NomPrioridad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("NomPrioridad").Width = 100
            .Columns("NomPrioridad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("UltimaAccion").Visible = True
            .Columns("UltimaAccion").HeaderText = "Ult. Estado"
            .Columns("UltimaAccion").ToolTipText = "Ultimo Estado"
            '.Columns("UltimaAccion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("UltimaAccion").Width = 100
            .Columns("UltimaAccion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaCreacion").Visible = True
            .Columns("FechaCreacion").HeaderText = "Fecha creación"
            '.Columns("FechaCreacion").ToolTipText = "de tope de la oferta"
            .Columns("FechaCreacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FechaCreacion").Width = 100
            .Columns("FechaCreacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Dias").Visible = True
            '.Columns("Dias").HeaderText = "Días expira."
            '.Columns("Dias").ToolTipText = "Días que faltan para que termine la oferta"
            '.Columns("Dias").Width = 70
            '.Columns("Dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Dias").DefaultCellStyle.Format = "###,##0.##"
            '.Columns("Dias").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Crear_Ticket_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Ticket.Click

        Dim Fm As New Frm_Tickets_Mant(0)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id_Ticket As Integer = _Fila.Cells("Id").Value

        Dim Fm As New Frm_Tickets_Seguimiento(_Id_Ticket)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub
End Class
