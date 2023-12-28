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
        Me._Tipo_Tickets = _Tipo
        Me._Id_Grupo = _Id_Grupo

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Tickets_Lista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InsertarBotonenGrilla(Grilla, "BtnImagen_Estado", "Est.", "Img_Estado", 0, _Tipo_Boton.Imagen)

        'AddHandler Grilla.RowPrePaint, AddressOf Grilla_RowPrePaint

        Sb_Actualizar_Grilla()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Btn_Crear_Ticket.Visible = (_Tipo_Tickets = Enum_Tickets.MisTicket)
        Btn_RevisarTicket.Visible = Not (_Tipo_Tickets = Enum_Tickets.MisTicket)

        If _Tipo_Tickets = Enum_Tickets.MisTicket Then
            Me.Text = "MIS TICKETS"
            Chk_TickesAsigMi.Visible = False
            Chk_TickesMiGrupo.Visible = False
        Else
            Me.Text = "TICKET ASIGNADOS A MI COMO AGENTE"
        End If

        AddHandler Chk_TickesMiGrupo.CheckedChanged, AddressOf Chk_TickesTiposMi_CheckedChanged

    End Sub

    Sub Sb_Actualizar_Grilla()

        'Dim _Texto_Busqueda As String = Txt_Buscador.Text.Trim
        Dim _Condicion As String = String.Empty
        Dim _Condicion2 As String = String.Empty

        'Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(_Texto_Busqueda), "CODIGO+DESCRIPTOR Like '%")

        'If Not String.IsNullOrWhiteSpace(Txt_BuscaXProducto.Text) Then
        '_Condicion = "And CODIGO In (Select CODIGO From MAEDRES Where ELEMENTO = '" & Txt_BuscaXProducto.Text & "')"
        'End If

        If Chk_TickesMiGrupo.Visible And Chk_TickesMiGrupo.Checked Then
            _Condicion2 = "Or (Tks.Id In (Select Id From " & _Global_BaseBk & "Zw_Stk_Tickets " &
                          "Where Id_Grupo In (Select Id_Grupo From " & _Global_BaseBk & "Zw_Stk_GrupoVsAgente " &
                          "Where CodAgente = '" & FUNCIONARIO & "')))"
        End If

        Select Case _Tipo_Tickets
            Case Enum_Tickets.MisTicket
                _Condicion = "And CodFuncionario_Crea = '" & _Funcionario & "'"
            Case Enum_Tickets.TicketAsignadoGrupo
                _Condicion = "And Id_Grupo = " & _Id_Grupo
                _Condicion += vbCrLf & "And Estado <> 'NULO'"
            Case Enum_Tickets.TicketAsignadosAgente
                _Condicion = "And (Tks.Id In (Select Id_Ticket From " & _Global_BaseBk & "Zw_Stk_Tickets_Asignado " &
                             "Where CodAgente = '" & FUNCIONARIO & "') " & _Condicion2 & ")"
                _Condicion += vbCrLf & "And Estado <> 'NULO'"
        End Select

        Consulta_sql = "Select Tks.*,TkPrd.Empresa,TkPrd.Sucursal,TkPrd.Bodega,TkPrd.Codigo,TkPrd.Descripcion As DescripcionPr," & vbCrLf &
                       "Case UdMedida When 1 Then Ud1 Else Ud2 End As 'Udm',Case UdMedida When 1 Then Stfi1 Else Stfi2 End As 'STF',Cantidad" & vbCrLf &
                       ",Case Prioridad When 'AL' Then 'Alta' When 'NR' Then 'Normal' When 'BJ' Then 'Baja' When 'UR' Then 'Urgente' Else '??' End As NomPrioridad" & vbCrLf &
                       ",Case UltAccion When 'INGR' then 'Ingresada' When 'MENS' then 'Mensaje' When 'RESP' then 'Respondido' When 'CERR' then 'Cerrada' End As UltimaAccion" & vbCrLf &
                       ",Case Estado When 'ABIE' then 'Abierto' When 'CERR' then 'Cerrado' When 'NULO' then 'Nulo' When 'SOLC' then 'Sol. Cierre' End As NomEstado," & vbCrLf &
                       "(Select COUNT(*) From " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones AcMs Where AcMs.Id_Ticket = Tks.Id And AcMs.Accion = 'MENS' And AcMs.Visto = 0) As Mesn_Pdte_Ver," & vbCrLf &
                       "(Select COUNT(*) From " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones AcRs Where AcRs.Id_Ticket = Tks.Id And AcRs.Accion = 'RESP' And AcRs.Visto = 0) As Resp_Pdte_Ver" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stk_Tickets Tks" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Stk_Tickets_Producto TkPrd On Tks.Id = TkPrd.Id_Ticket" & vbCrLf &
                       "Where 1 > 0" & vbCrLf & _Condicion

        _Tbl_Tickets = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Tickets

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("BtnImagen_Estado").Width = 50
            .Columns("BtnImagen_Estado").HeaderText = "Est."
            .Columns("BtnImagen_Estado").Visible = True
            .Columns("BtnImagen_Estado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("BtnImagen_Tag").Width = 50
            '.Columns("BtnImagen_Tag").HeaderText = "Tag"
            '.Columns("BtnImagen_Tag").Visible = True
            '.Columns("BtnImagen_Tag").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Numero").Visible = True
            .Columns("Numero").HeaderText = "Número"
            .Columns("Numero").Width = 80
            .Columns("Numero").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Asunto").Visible = True
            .Columns("Asunto").HeaderText = "Asunto"
            .Columns("Asunto").Width = 250
            .Columns("Asunto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NomEstado").Visible = True
            .Columns("NomEstado").HeaderText = "Estado"
            .Columns("NomEstado").ToolTipText = "Estado del Ticket"
            '.Columns("NomEstado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("NomEstado").Width = 80
            .Columns("NomEstado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NomPrioridad").Visible = True
            .Columns("NomPrioridad").HeaderText = "Prioridad"
            '.Columns("NomPrioridad").ToolTipText = "Estado del Ticket"
            .Columns("NomPrioridad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("NomPrioridad").Width = 80
            .Columns("NomPrioridad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("UltimaAccion").Visible = True
            .Columns("UltimaAccion").HeaderText = "Ult. Estado"
            .Columns("UltimaAccion").ToolTipText = "Ultimo Estado"
            '.Columns("UltimaAccion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("UltimaAccion").Width = 80
            .Columns("UltimaAccion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaCreacion").Visible = True
            .Columns("FechaCreacion").HeaderText = "Fecha creación"
            '.Columns("FechaCreacion").ToolTipText = "de tope de la oferta"
            .Columns("FechaCreacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FechaCreacion").Width = 100
            .Columns("FechaCreacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codigo").Visible = True
            .Columns("Codigo").HeaderText = "Código"
            '.Columns("UltimaAccion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Codigo").Width = 100
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("DescripcionPr").Visible = True
            .Columns("DescripcionPr").HeaderText = "Descripción"
            '.Columns("UltimaAccion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("DescripcionPr").Width = 150
            .Columns("DescripcionPr").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Udm").Visible = True
            .Columns("Udm").HeaderText = "Udm"
            .Columns("Udm").ToolTipText = "Unidad de medida de la operación"
            '.Columns("UltimaAccion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Udm").Width = 30
            .Columns("Udm").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("STF").Visible = True
            .Columns("STF").HeaderText = "Stock"
            .Columns("STF").ToolTipText = "Stock del producto al momento de la operación"
            .Columns("STF").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STF").Width = 50
            .Columns("STF").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").HeaderText = "Cantidad"
            .Columns("Cantidad").ToolTipText = "Cantidad inventariada al momento de la operación"
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").Width = 50
            .Columns("Cantidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With


        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Mesn_Pdte_Ver = _Fila.Cells("Mesn_Pdte_Ver").Value
            Dim _Resp_Pdte_Ver = _Fila.Cells("Resp_Pdte_Ver").Value
            Dim _Estado = _Fila.Cells("Estado").Value

            Dim _Icono As Image
            Dim _Nombre_Image As String
            Dim _Num

            If _Tipo_Tickets = Enum_Tickets.MisTicket Then
                _Num = _Resp_Pdte_Ver
            Else
                _Num = _Mesn_Pdte_Ver
            End If

            If _Estado = "NULO" Then
                _Icono = Imagenes_16x16.Images.Item("cancel.png")
            Else

                If CBool(_Num) Then
                    _Nombre_Image = "comment-number-" & _Num & ".png"
                    If _Mesn_Pdte_Ver > 9 Then
                        _Nombre_Image = "comment-number-9-plus.png"
                    End If
                    _Icono = Imagenes_16x16.Images.Item(_Nombre_Image)
                    _Fila.DefaultCellStyle.BackColor = Color.LightYellow
                Else
                    _Icono = Imagenes_16x16.Images.Item("menu-more.png")
                End If

            End If

            _Fila.Cells("BtnImagen_Estado").Value = _Icono

        Next

    End Sub

    Private Sub Btn_Crear_Ticket_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Ticket.Click

        'RemoveHandler Grilla.RowPrePaint, AddressOf Grilla_RowPrePaint

        Dim Fm As New Frm_Tickets_Mant(0)
        Fm.ShowDialog(Me)
        Fm.Dispose()

        'AddHandler Grilla.RowPrePaint, AddressOf Grilla_RowPrePaint

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Try

            Dim _Fila As DataGridViewRow = Grilla.CurrentRow
            Dim _Id_Ticket As Integer = _Fila.Cells("Id").Value
            Dim _Numero As String = _Fila.Cells("Numero").Value

            'RemoveHandler Grilla.RowPrePaint, AddressOf Grilla_RowPrePaint

            Dim Fm As New Frm_Tickets_Seguimiento(_Id_Ticket)
            Fm.Mis_Ticket = (_Tipo_Tickets = Enum_Tickets.MisTicket)
            Fm.ShowDialog(Me)
            Fm.Dispose()

            'AddHandler Grilla.RowPrePaint, AddressOf Grilla_RowPrePaint

            Sb_Actualizar_Grilla()

            BuscarDatoEnGrilla(_Numero, "_Numero", Grilla)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Btn_RevisarTicket_Click(sender As Object, e As EventArgs) Handles Btn_RevisarTicket.Click
        Call Grilla_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Chk_TickesTiposMi_CheckedChanged(sender As Object, e As EventArgs)
        Sb_Actualizar_Grilla()
    End Sub

    'Private Sub Grilla_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs)

    '    'Dim _Columname As String = Grilla.Columns(e.ColumnIndex).Name
    '    Dim _Fila As DataGridViewRow = Grilla.Rows(e.RowIndex)

    '    'If _Columname = "BtnImagen_Estado" Then

    '    Try

    '        Dim _Mesn_Pdte_Ver = _Fila.Cells("Mesn_Pdte_Ver").Value
    '        Dim _Resp_Pdte_Ver = _Fila.Cells("Resp_Pdte_Ver").Value
    '        Dim _Estado = _Fila.Cells("Estado").Value

    '        Dim _Icono As Image
    '        Dim _Nombre_Image As String
    '        Dim _Num

    '        If _Tipo_Tickets = Enum_Tickets.MisTicket Then
    '            _Num = _Resp_Pdte_Ver
    '        Else
    '            _Num = _Mesn_Pdte_Ver
    '        End If

    '        If _Estado = "NULO" Then
    '            _Icono = Imagenes_16x16.Images.Item("cancel.png")
    '        Else

    '            If CBool(_Num) Then
    '                _Nombre_Image = "comment-number-" & _Num & ".png"
    '                If _Mesn_Pdte_Ver > 9 Then
    '                    _Nombre_Image = "comment-number-9-plus.png"
    '                End If
    '                _Icono = Imagenes_16x16.Images.Item(_Nombre_Image)
    '                _Fila.DefaultCellStyle.BackColor = Color.LightYellow
    '            Else
    '                _Icono = Imagenes_16x16.Images.Item("menu-more.png")
    '            End If

    '        End If

    '        _Fila.Cells("BtnImagen_Estado").Value = _Icono

    '    Catch ex As Exception

    '    End Try

    '    'End If

    'End Sub
End Class
