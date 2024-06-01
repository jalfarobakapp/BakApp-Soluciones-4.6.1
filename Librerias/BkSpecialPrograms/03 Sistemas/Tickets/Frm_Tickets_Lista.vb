Imports DevComponents.DotNetBar

Public Class Frm_Tickets_Lista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Tickets As DataTable
    Dim _Funcionario As String
    Dim _Id_Grupo As Integer

    Dim _Tipo_Tickets As Enum_Tickets
    Private _EsAgente As Boolean
    Dim _Dv As New DataView

    Enum Enum_Tickets
        MisTicket
        TicketAsignadosAgente
        TicketAsignadoGrupo
        TodosLosTickets
    End Enum

    Private _NodoSeleccionado As TreeNode

    Public Sub New(_Funcionario As String, _Tipo As Enum_Tickets, _Id_Grupo As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Funcionario = _Funcionario
        Me._Tipo_Tickets = _Tipo
        Me._Id_Grupo = _Id_Grupo

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, False, False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Tickets_Lista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Agentes", "CodAgente = '" & FUNCIONARIO & "'")

        _EsAgente = CBool(_Reg)

        Sb_InsertarBotonenGrilla(Grilla, "BtnImagen_Estado", "Est.", "Img_Estado", 0, _Tipo_Boton.Imagen)
        Sb_InsertarBotonenGrilla(Grilla, "BtnImagen_Estado2", "Est.", "Img_Estado2", 0, _Tipo_Boton.Imagen)
        Sb_InsertarBotonenGrilla(Grilla, "BtnImagen_Estado3", "Est.", "Img_Estado3", 0, _Tipo_Boton.Imagen)

        'AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Btn_Crear_Ticket.Visible = (_Tipo_Tickets = Enum_Tickets.MisTicket)
        Btn_RevisarTicket.Visible = Not (_Tipo_Tickets = Enum_Tickets.MisTicket)

        AddHandler Chk_TickesMiGrupo.CheckedChanged, AddressOf Chk_TickesTiposMi_CheckedChanged
        AddHandler Grilla.CellFormatting, AddressOf Grilla_CellFormatting
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

        Me.Text += ", Usuario : " & FUNCIONARIO & " - " & Nombre_funcionario_activo

        Sb_CargarTreeView()

        Sb_Actualizar_Grilla_Treeview(Nothing)
        Sb_ActualizarTotalesTreeNodos(Tree_Bandeja.Nodes(0))
        If _EsAgente Then
            Sb_ActualizarTotalesTreeNodos(Tree_Bandeja.Nodes(1))
        End If

    End Sub

    Function ImagenLista(_Num As Integer) As Image

        Dim _Imagen As Image
        Dim _Imagenes_List As ImageList

        If Global_Thema = Enum_Themas.Oscuro Then
            _Imagenes_List = Imagenes_16x16_Dark
        Else
            _Imagenes_List = Imagenes_16x16
        End If

        Dim _Nombre_Image = "ticket-number-" & _Num & ".png"
        If _Num > 9 Then
            _Nombre_Image = "ticket-number-9-plus.png"
        End If
        _Imagen = _Imagenes_List.Images.Item(_Nombre_Image)

        Return _Imagen

    End Function

    Sub Sb_ActualizarImagenesTabListados()

        Dim _Condicion2 As String
        Dim _CondicionFun As String

        Select Case _Tipo_Tickets
            Case Enum_Tickets.MisTicket
                _CondicionFun = "CodFuncionario_Crea = '" & _Funcionario & "'"
            Case Enum_Tickets.TicketAsignadoGrupo
                _CondicionFun = "And Id_Grupo = " & _Id_Grupo
                _CondicionFun += vbCrLf & "And Estado <> 'NULO'"
            Case Enum_Tickets.TicketAsignadosAgente
                _CondicionFun = "(Id In (Select Id_Ticket From " & _Global_BaseBk & "Zw_Stk_Tickets_Asignado " &
                             "Where CodAgente = '" & FUNCIONARIO & "') " & _Condicion2 & ")"
                _CondicionFun += vbCrLf & "And Estado <> 'NULO'"
            Case Enum_Tickets.TodosLosTickets
                _CondicionFun += "1>0"
        End Select

        Consulta_sql = "Select (Select COUNT(*) From " & _Global_BaseBk & "Zw_Stk_Tickets Where " & _CondicionFun & " And Estado = 'ABIE' And Rechazado = 0) As TodasActivas,
	   (Select COUNT(*) From " & _Global_BaseBk & "Zw_Stk_Tickets Where " & _CondicionFun & " And Estado = 'ABIE' And Rechazado = 1) As ActivasRechazadas,	
	   (Select COUNT(*) From " & _Global_BaseBk & "Zw_Stk_Tickets Where " & _CondicionFun & " And Estado = 'CERR' And Rechazado = 0 And Aceptado = 0) As Cerradas,
	   (Select COUNT(*) From " & _Global_BaseBk & "Zw_Stk_Tickets Where " & _CondicionFun & " And Estado = 'CERR' And Rechazado = 0 And Aceptado = 1) As CerradasAceptadas,
	   (Select COUNT(*) From " & _Global_BaseBk & "Zw_Stk_Tickets Where " & _CondicionFun & " And Estado = 'CERR' And Rechazado = 1 And Aceptado = 0) As CerradasRechazadas,
	   (Select COUNT(*) From " & _Global_BaseBk & "Zw_Stk_Tickets Where " & _CondicionFun & " And Estado = 'NULO') As Nulas"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _TodasActivas As Integer = _Row.Item("TodasActivas")
        Dim _ActivasRechazadas As Integer = _Row.Item("ActivasRechazadas")
        Dim _Cerradas As Integer = _Row.Item("Cerradas")
        Dim _CerradasAceptadas As Integer = _Row.Item("CerradasAceptadas")
        Dim _CerradasRechazadas As Integer = _Row.Item("CerradasRechazadas")
        Dim _Nulas As Integer = _Row.Item("Nulas")

        'Tab_TodasActivas.Image = ImagenLista(_TodasActivas)
        'Tab_ActivasRechazadas.Image = ImagenLista(_ActivasRechazadas)
        'Tab_Cerradas.Image = ImagenLista(_Cerradas)
        'Tab_CerradasAceptadas.Image = ImagenLista(_CerradasAceptadas)
        'Tab_CerradasRechazadas.Image = ImagenLista(_CerradasRechazadas)
        'Tab_Nulas.Image = ImagenLista(_Nulas)

    End Sub

    Sub Sb_Actualizar_Totales_Nodos(_NodoPadre As TreeNode, _NodoHijo As TreeNode)

        Dim _Condicion2 As String
        Dim _CondicionFun As String
        Dim _Accion As String

        ' Crear una fuente en negrita
        Dim fuenteNegrita As New Font(Tree_Bandeja.Font, FontStyle.Bold)
        Dim fuenteNormal As New Font(Tree_Bandeja.Font, FontStyle.Regular)

        If IsNothing(_NodoPadre) Then

            If _NodoHijo.Text = "ENVIADOS" Then
                _CondicionFun = "CodFuncionario_Crea = '" & _Funcionario & "'"
            End If

            If _NodoHijo.Text = "ASIGNADOS" Then
                _CondicionFun = "(Id In (Select Id_Ticket From " & _Global_BaseBk & "Zw_Stk_Tickets_Asignado " &
                               "Where CodAgente = '" & FUNCIONARIO & "') " & _Condicion2 & ")"
            End If

        Else

            If _NodoPadre.Text = "ENVIADOS" Then
                _CondicionFun = "CodFuncionario_Crea = '" & _Funcionario & "'"
            End If

            If _NodoPadre.Text = "ASIGNADOS" Then
                _CondicionFun = "(Id In (Select Id_Ticket From " & _Global_BaseBk & "Zw_Stk_Tickets_Asignado " &
                               "Where CodAgente = '" & FUNCIONARIO & "') " & _Condicion2 & ")"
            End If

            If _NodoHijo.Tag = "Aceptados" Then _Accion = "And Aceptado = 1 And Rechazado = 0 And Estado <> 'CERR'"
            If _NodoHijo.Tag = "Rechazados" Then _Accion = "And Aceptado = 0 And Rechazado = 1 And Estado <> 'CERR'"
            If _NodoHijo.Tag = "Pendientes" Then _Accion = "And Estado = 'ABIE' And Aceptado = 0 And Rechazado = 0"
            If _NodoHijo.Tag = "Cerradas" Then _Accion = "And Estado = 'CERR'"

        End If

        Consulta_sql = "Select COUNT(*) As Cantidad From " & _Global_BaseBk & "Zw_Stk_Tickets Where " & _CondicionFun & " " & _Accion

        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Cantidad As Integer = _Row.Item("Cantidad")

        If _Cantidad > 0 Then
            _NodoHijo.Text = _NodoHijo.Tag & " " & _Cantidad
            ' Asignar la fuente al nodo
            _NodoHijo.NodeFont = fuenteNegrita
        Else
            _NodoHijo.Text = _NodoHijo.Tag
            _NodoHijo.NodeFont = fuenteNormal
        End If

        Tree_Bandeja.Update()
        Tree_Bandeja.Refresh()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Sb_ActualizarImagenesTabListados()

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
            Case Enum_Tickets.TodosLosTickets
                _Condicion = String.Empty
        End Select


        'Dim _Tbas = Super_TabS.SelectedTab

        'Select Case _Tbas.Name
        '    Case "Tab_TodasActivas"
        '        _Condicion += vbCrLf & "And Estado = 'ABIE' And Rechazado = 0"
        '    Case "Tab_ActivasRechazadas"
        '        _Condicion += vbCrLf & "And Estado = 'ABIE' And Rechazado = 1"
        '    Case "Tab_Cerradas"
        '        _Condicion += vbCrLf & "And Estado = 'CERR' And Rechazado = 0 And Aceptado = 0"
        '    Case "Tab_CerradasAceptadas"
        '        _Condicion += vbCrLf & "And Estado = 'CERR' And Aceptado = 1"
        '    Case "Tab_CerradasRechazadas"
        '        _Condicion += vbCrLf & "And Estado = 'CERR' And Rechazado = 1"
        '    Case "Tab_Nulas"
        '        _Condicion += vbCrLf & "And Estado = 'NULO'"
        'End Select

        Consulta_sql = "Select Tks.*,TkPrd.Empresa,TkPrd.Sucursal,TkPrd.Bodega,TkPrd.Codigo,TkPrd.Descripcion As DescripcionPr," & vbCrLf &
                       "Case UdMedida When 1 Then Ud1 Else Ud2 End As 'Udm',StfiEnBodega,Cantidad,Diferencia" & vbCrLf &
                       ",Case Prioridad When 'AL' Then 'Alta' When 'NR' Then 'Normal' When 'BJ' Then 'Baja' When 'UR' Then 'Urgente' Else '??' End As NomPrioridad" & vbCrLf &
                       ",Case UltAccion When 'INGR' then 'Ingresada' When 'MENS' then 'Mensaje' When 'RESP' then 'Respondido' When 'CERR' then 'Cerrada' End As UltimaAccion" & vbCrLf &
                       ",Case Estado 
                       When 'ABIE' Then 
                            Case When Rechazado = 1 Then 'Abierto (Rechazado)' Else 'Abierto' End 
                       When 'CERR' Then 
                            Case When Rechazado = 1 Then 'Cerrado (Rechazado)' When Aceptado = 1 Then 'Cerrado (Aceptado)' Else 'Cerrado' End 
                       When 'NULO' then 'Nulo' When 'SOLC' then 'Sol. Cierre' End As NomEstado," & vbCrLf &
                       "(Select COUNT(*) From " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones AcMs Where AcMs.Id_Ticket = Tks.Id And AcMs.Accion = 'MENS' And AcMs.Visto = 0) As Mesn_Pdte_Ver," & vbCrLf &
                       "(Select COUNT(*) From " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones AcRs Where AcRs.Id_Ticket = Tks.Id And AcRs.Accion = 'RESP' And AcRs.Visto = 0) As Resp_Pdte_Ver" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stk_Tickets Tks" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Stk_Tickets_Producto TkPrd On Tks.Id_Raiz = TkPrd.Id_Raiz" & vbCrLf &
                       "Where 1 > 0" & vbCrLf & _Condicion

        _Tbl_Tickets = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Tickets

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            '.Columns("BtnImagen_Estado").Width = 30
            '.Columns("BtnImagen_Estado").HeaderText = "E."
            '.Columns("BtnImagen_Estado").Visible = True
            '.Columns("BtnImagen_Estado").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            ''.Columns("BtnImagen_Estado2").Width = 30
            ''.Columns("BtnImagen_Estado2").HeaderText = "2"
            ''.Columns("BtnImagen_Estado2").Visible = True
            ''.Columns("BtnImagen_Estado2").DisplayIndex = _DisplayIndex
            ''_DisplayIndex += 1

            '.Columns("BtnImagen_Estado3").Width = 30
            '.Columns("BtnImagen_Estado3").HeaderText = "3"
            '.Columns("BtnImagen_Estado3").Visible = True
            '.Columns("BtnImagen_Estado3").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            ''.Columns("BtnImagen_Tag").Width = 50
            ''.Columns("BtnImagen_Tag").HeaderText = "Tag"
            ''.Columns("BtnImagen_Tag").Visible = True
            ''.Columns("BtnImagen_Tag").DisplayIndex = _DisplayIndex
            ''_DisplayIndex += 1

            '.Columns("Numero").Visible = True
            '.Columns("Numero").HeaderText = "Número"
            '.Columns("Numero").Width = 80
            '.Columns("Numero").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("SubNro").Visible = True
            .Columns("SubNro").HeaderText = "Sub"
            .Columns("SubNro").Width = 30
            .Columns("SubNro").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Asunto").Visible = True
            .Columns("Asunto").HeaderText = "Asunto"
            .Columns("Asunto").Width = 230
            .Columns("Asunto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NomEstado").Visible = True
            .Columns("NomEstado").HeaderText = "Estado"
            .Columns("NomEstado").ToolTipText = "Estado del Ticket"
            '.Columns("NomEstado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("NomEstado").Width = 110
            .Columns("NomEstado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NomPrioridad").Visible = True
            .Columns("NomPrioridad").HeaderText = "Prioridad"
            '.Columns("NomPrioridad").ToolTipText = "Estado del Ticket"
            .Columns("NomPrioridad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("NomPrioridad").Width = 70
            .Columns("NomPrioridad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("UltimaAccion").Visible = True
            '.Columns("UltimaAccion").HeaderText = "Ult. Estado"
            '.Columns("UltimaAccion").ToolTipText = "Ultimo Estado"
            ''.Columns("UltimaAccion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("UltimaAccion").Width = 80
            '.Columns("UltimaAccion").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("FechaCreacion").Visible = True
            .Columns("FechaCreacion").HeaderText = "Fecha creación"
            '.Columns("FechaCreacion").ToolTipText = "de tope de la oferta"
            .Columns("FechaCreacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FechaCreacion").Width = 100
            .Columns("FechaCreacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            'If _Tbas.Name.Contains("Cerradas") Then

            '    .Columns("FechaCierre").Visible = True
            '    .Columns("FechaCierre").HeaderText = "Fecha cierre"
            '    '.Columns("FechaCreacion").ToolTipText = "de tope de la oferta"
            '    .Columns("FechaCierre").DefaultCellStyle.Format = "dd/MM/yyyy"
            '    .Columns("FechaCierre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '    .Columns("FechaCierre").Width = 70
            '    .Columns("FechaCierre").DisplayIndex = _DisplayIndex
            '    _DisplayIndex += 1

            'End If

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
            .Columns("Udm").HeaderText = "UM"
            .Columns("Udm").ToolTipText = "Unidad de medida de la operación"
            '.Columns("UltimaAccion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Udm").Width = 30
            .Columns("Udm").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StfiEnBodega").Visible = True
            .Columns("StfiEnBodega").HeaderText = "Stock Bod."
            .Columns("StfiEnBodega").ToolTipText = "Stock físico en bodega del producto al momento de la gestión"
            .Columns("StfiEnBodega").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StfiEnBodega").Width = 60
            .Columns("StfiEnBodega").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").HeaderText = "Cantidad"
            .Columns("Cantidad").ToolTipText = "Cantidad inventariada al momento de la operación"
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").Width = 60
            .Columns("Cantidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Diferencia").Visible = True
            .Columns("Diferencia").HeaderText = "Diferencia"
            .Columns("Diferencia").ToolTipText = "Diferencia entre el stock en bodega y la cantidad inventariada"
            .Columns("Diferencia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Diferencia").Width = 60
            .Columns("Diferencia").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With


        'For Each _Fila As DataGridViewRow In Grilla.Rows

        '    Dim _Mesn_Pdte_Ver = _Fila.Cells("Mesn_Pdte_Ver").Value
        '    Dim _Resp_Pdte_Ver = _Fila.Cells("Resp_Pdte_Ver").Value
        '    Dim _Estado As String = _Fila.Cells("Estado").Value
        '    Dim _Aceptado As Boolean = _Fila.Cells("Aceptado").Value
        '    Dim _Rechazado As Boolean = _Fila.Cells("Rechazado").Value
        '    Dim _Prioridad As String = _Fila.Cells("Prioridad").Value

        '    Dim _Icono As Image
        '    Dim _Nombre_Image As String
        '    Dim _Num

        '    If _Tipo_Tickets = Enum_Tickets.MisTicket Then
        '        _Num = _Resp_Pdte_Ver
        '    Else
        '        _Num = _Mesn_Pdte_Ver
        '    End If

        '    Dim _Imagenes_List As ImageList

        '    If Global_Thema = Enum_Themas.Oscuro Then
        '        _Imagenes_List = Imagenes_16x16_Dark
        '    Else
        '        _Imagenes_List = Imagenes_16x16
        '    End If

        '    If _Estado = "NULO" Then
        '        _Icono = _Imagenes_List.Images.Item("cancel.png")
        '    Else

        '        If CBool(_Num) Then
        '            _Nombre_Image = "comment-number-" & _Num & ".png"
        '            If _Mesn_Pdte_Ver > 9 Then
        '                _Nombre_Image = "comment-number-9-plus.png"
        '            End If
        '            _Icono = _Imagenes_List.Images.Item(_Nombre_Image)

        '            If Global_Thema = Enum_Themas.Oscuro Then
        '                _Fila.DefaultCellStyle.ForeColor = Amarillo
        '            Else
        '                _Fila.DefaultCellStyle.BackColor = Color.LightYellow
        '            End If

        '        Else
        '            _Icono = _Imagenes_List.Images.Item("menu-more.png")
        '        End If

        '    End If

        '    _Fila.Cells("BtnImagen_Estado").Value = _Icono

        '    If _Aceptado Then _Fila.Cells("NomEstado").Style.ForeColor = Verde
        '    If _Rechazado Then _Fila.Cells("NomEstado").Style.ForeColor = Rojo

        '    _Fila.Cells("NomPrioridad").Style.ForeColor = Color.White

        '    If _Prioridad = "AL" Then
        '        _Fila.Cells("NomPrioridad").Style.BackColor = Color.Orange
        '    End If

        '    If _Prioridad = "BJ" Then
        '        _Fila.Cells("NomPrioridad").Style.ForeColor = Color.Black
        '        _Fila.Cells("NomPrioridad").Style.BackColor = Amarillo
        '    End If

        '    If _Prioridad = "NR" Then
        '        _Fila.Cells("NomPrioridad").Style.BackColor = Verde
        '    End If

        '    If _Prioridad = "UR" Then
        '        _Fila.Cells("NomPrioridad").Style.BackColor = Rojo
        '    End If

        'Next

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Toma" & vbCrLf &
                       "Where CodFuncionario = '" & FUNCIONARIO & "' And NombreEquipo = '" & _NombreEquipo & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql)

    End Sub

    Sub Sb_Actualizar_Grilla_Treeview(_Carpeta As TreeNode)

        If False Then
            Sb_ActualizarTotalesTreeNodos(Tree_Bandeja.Nodes(0))
            If _EsAgente Then
                Sb_ActualizarTotalesTreeNodos(Tree_Bandeja.Nodes(1))
            End If
        End If

        Dim _Condicion As String = String.Empty
        Dim _Condicion2 As String = String.Empty

        If Chk_TickesMiGrupo.Visible And Chk_TickesMiGrupo.Checked Then
            _Condicion2 = "Or (Tks.Id In (Select Id From " & _Global_BaseBk & "Zw_Stk_Tickets " &
                          "Where Id_Grupo In (Select Id_Grupo From " & _Global_BaseBk & "Zw_Stk_GrupoVsAgente " &
                          "Where CodAgente = '" & FUNCIONARIO & "')))"
        End If

        If Not IsNothing(_Carpeta) AndAlso Not IsNothing(_Carpeta.Parent) Then

            Dim nodoPadre As TreeNode = _Carpeta.Parent

            If nodoPadre.Tag = "ASIGNADOS" Then
                _Condicion = "And (Tks.Id In (Select Id_Ticket From " & _Global_BaseBk & "Zw_Stk_Tickets_Asignado " &
                                 "Where CodAgente = '" & FUNCIONARIO & "') " & _Condicion2 & ")"
            End If

            If nodoPadre.Tag = "ENVIADOS" Then
                _Condicion = "And CodFuncionario_Crea = '" & _Funcionario & "'"
            End If

            If _Carpeta.Tag = "Pendientes" Then
                _Condicion += vbCrLf & "And Estado = 'ABIE' And Rechazado = 0 And Aceptado = 0"
            End If

            If _Carpeta.Tag = "Aceptados" Then
                _Condicion += vbCrLf & "And Aceptado = 1 And Rechazado = 0 And Estado <> 'CERR'"
            End If

            If _Carpeta.Tag = "Rechazados" Then
                _Condicion += vbCrLf & "And Rechazado = 1 And Aceptado = 0 And Estado <> 'CERR'"
            End If

            If _Carpeta.Tag = "Cerradas" Then
                _Condicion += vbCrLf & "And Estado = 'CERR'"
            End If

            _NodoSeleccionado = _Carpeta

        Else

            Try
                If _Carpeta.Tag = "ASIGNADOS" Then
                    _Condicion = "And (Tks.Id In (Select Id_Ticket From " & _Global_BaseBk & "Zw_Stk_Tickets_Asignado " &
                                     "Where CodAgente = '" & FUNCIONARIO & "') " & _Condicion2 & ")"
                End If

                If _Carpeta.Tag = "ENVIADOS" Then
                    _Condicion = "And CodFuncionario_Crea = '" & _Funcionario & "'"
                End If
            Catch ex As Exception
                _Condicion = "And 1 = 0"
                _NodoSeleccionado = Nothing
            End Try

        End If

        Consulta_sql = "Select Tks.*,NOKOFU As 'NomFuncCrea',TkPrd.Empresa,TkPrd.Sucursal,TkPrd.Bodega,TkPrd.Codigo,TkPrd.Descripcion As DescripcionPr," & vbCrLf &
                       "Case UdMedida When 1 Then Ud1 Else Ud2 End As 'Udm',StfiEnBodega,Cantidad,Diferencia" & vbCrLf &
                       ",Case Prioridad When 'AL' Then 'Alta' When 'NR' Then 'Normal' When 'BJ' Then 'Baja' When 'UR' Then 'Urgente' Else '??' End As NomPrioridad" & vbCrLf &
                       ",Case UltAccion When 'INGR' then 'Ingresada' When 'MENS' then 'Mensaje' When 'RESP' then 'Respondido' When 'CERR' then 'Cerrada' End As UltimaAccion" & vbCrLf &
                       ",Case Estado 
                       When 'ABIE' Then 
                            Case When Rechazado = 1 Then 'Abierto (Rechazado)' Else 'Abierto' End 
                       When 'CERR' Then 
                            Case When Rechazado = 1 Then 'Cerrado (Rechazado)' When Aceptado = 1 Then 'Cerrado (Aceptado)' Else 'Cerrado' End 
                       When 'NULO' then 'Nulo' When 'SOLC' then 'Sol. Cierre' End As NomEstado," & vbCrLf &
                       "(Select COUNT(*) From " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones AcMs Where AcMs.Id_Raiz = Tks.Id_Raiz And AcMs.Accion In ('MENS','CREA') And AcMs.Visto = 0) As Mesn_Pdte_Ver," & vbCrLf &
                       "(Select COUNT(*) From " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones AcRs Where AcRs.Id_Raiz = Tks.Id_Raiz And AcRs.Accion In ('RESP','CREA') And AcRs.Visto = 0) As Resp_Pdte_Ver" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stk_Tickets Tks" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Stk_Tickets_Producto TkPrd On Tks.Id_Raiz = TkPrd.Id_Raiz" & vbCrLf &
                       "Left Join TABFU Fu On Fu.KOFU = CodFuncionario_Crea" & vbCrLf &
                       "Where 1 > 0" & vbCrLf & _Condicion & vbCrLf &
                       "Order By Numero Desc"

        _Tbl_Tickets = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _New_Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)
        _Dv = New DataView
        _Dv.Table = _New_Ds.Tables("Table")
        _Tbl_Tickets = _Dv.Table


        With Grilla

            .DataSource = _Dv

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            '.Columns("BtnImagen_Estado").Width = 30
            '.Columns("BtnImagen_Estado").HeaderText = "E."
            '.Columns("BtnImagen_Estado").Visible = True
            '.Columns("BtnImagen_Estado").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("BtnImagen_Estado2").Width = 30
            '.Columns("BtnImagen_Estado2").HeaderText = "2"
            '.Columns("BtnImagen_Estado2").Visible = True
            '.Columns("BtnImagen_Estado2").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("BtnImagen_Estado3").Width = 30
            '.Columns("BtnImagen_Estado3").HeaderText = "3"
            '.Columns("BtnImagen_Estado3").Visible = True
            '.Columns("BtnImagen_Estado3").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Numero").Visible = True
            .Columns("Numero").HeaderText = "Número"
            .Columns("Numero").Width = 80
            .Columns("Numero").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SubNro").Visible = True
            .Columns("SubNro").HeaderText = "Sub"
            .Columns("SubNro").Width = 30
            .Columns("SubNro").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("CodFuncionario_Crea").Visible = True
            '.Columns("CodFuncionario_Crea").HeaderText = "CF"
            '.Columns("CodFuncionario_Crea").Width = 30
            '.Columns("CodFuncionario_Crea").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("NomFuncCrea").Visible = True
            .Columns("NomFuncCrea").HeaderText = "De"
            .Columns("NomFuncCrea").Width = 100
            .Columns("NomFuncCrea").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Asunto").Visible = True
            .Columns("Asunto").HeaderText = "Asunto"
            .Columns("Asunto").Width = 230
            .Columns("Asunto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NomEstado").Visible = True
            .Columns("NomEstado").HeaderText = "Estado"
            .Columns("NomEstado").ToolTipText = "Estado del Ticket"
            '.Columns("NomEstado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("NomEstado").Width = 110
            .Columns("NomEstado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NomPrioridad").Visible = True
            .Columns("NomPrioridad").HeaderText = "Prioridad"
            '.Columns("NomPrioridad").ToolTipText = "Estado del Ticket"
            .Columns("NomPrioridad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("NomPrioridad").Width = 70
            .Columns("NomPrioridad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("UltimaAccion").Visible = True
            '.Columns("UltimaAccion").HeaderText = "Ult. Estado"
            '.Columns("UltimaAccion").ToolTipText = "Ultimo Estado"
            ''.Columns("UltimaAccion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("UltimaAccion").Width = 80
            '.Columns("UltimaAccion").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("FechaCreacion").Visible = True
            .Columns("FechaCreacion").HeaderText = "Fecha creación"
            '.Columns("FechaCreacion").ToolTipText = "de tope de la oferta"
            .Columns("FechaCreacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FechaCreacion").Width = 100
            .Columns("FechaCreacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            If Not IsNothing(_Carpeta) AndAlso _Carpeta.Text = "" Then

                .Columns("FechaCierre").Visible = True
                .Columns("FechaCierre").HeaderText = "Fecha cierre"
                '.Columns("FechaCreacion").ToolTipText = "de tope de la oferta"
                .Columns("FechaCierre").DefaultCellStyle.Format = "dd/MM/yyyy"
                .Columns("FechaCierre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("FechaCierre").Width = 70
                .Columns("FechaCierre").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

            End If

            .Columns("Codigo").Visible = True
            .Columns("Codigo").HeaderText = "Código"
            '.Columns("UltimaAccion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Codigo").Width = 100
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("DescripcionPr").Visible = True
            '.Columns("DescripcionPr").HeaderText = "Descripción"
            ''.Columns("UltimaAccion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("DescripcionPr").Width = 150
            '.Columns("DescripcionPr").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Udm").Visible = True
            .Columns("Udm").HeaderText = "UM"
            .Columns("Udm").ToolTipText = "Unidad de medida de la operación"
            '.Columns("UltimaAccion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Udm").Width = 30
            .Columns("Udm").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StfiEnBodega").Visible = True
            .Columns("StfiEnBodega").HeaderText = "Stk Bod."
            .Columns("StfiEnBodega").ToolTipText = "Stock físico en bodega del producto al momento de la gestión"
            .Columns("StfiEnBodega").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StfiEnBodega").Width = 40
            .Columns("StfiEnBodega").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").HeaderText = "Cant."
            .Columns("Cantidad").ToolTipText = "Cantidad inventariada al momento de la operación"
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").Width = 40
            .Columns("Cantidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Diferencia").Visible = True
            .Columns("Diferencia").HeaderText = "Dif"
            .Columns("Diferencia").ToolTipText = "Diferencia entre el stock en bodega y la cantidad inventariada"
            .Columns("Diferencia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Diferencia").Width = 40
            .Columns("Diferencia").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Toma" & vbCrLf &
                       "Where CodFuncionario = '" & FUNCIONARIO & "' And NombreEquipo = '" & _NombreEquipo & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Lbl_Estatus.Text = "Registros: " & _Tbl_Tickets.Rows.Count

        'For Each _Fila As DataGridViewRow In Grilla.Rows

        '    Dim _Mesn_Pdte_Ver = _Fila.Cells("Mesn_Pdte_Ver").Value
        '    Dim _Resp_Pdte_Ver = _Fila.Cells("Resp_Pdte_Ver").Value
        '    Dim _Estado As String = _Fila.Cells("Estado").Value
        '    Dim _Aceptado As Boolean = _Fila.Cells("Aceptado").Value
        '    Dim _Rechazado As Boolean = _Fila.Cells("Rechazado").Value
        '    Dim _Prioridad As String = _Fila.Cells("Prioridad").Value

        '    Dim _Icono As Image
        '    Dim _Nombre_Image As String
        '    Dim _Num

        '    Dim nodoPadre As TreeNode = _Carpeta.Parent

        '    If nodoPadre.Tag = "ASIGNADOS" Then
        '        _Num = _Mesn_Pdte_Ver
        '    End If

        '    If nodoPadre.Tag = "ENVIADOS" Then
        '        _Num = _Resp_Pdte_Ver
        '    End If

        '    Dim _Imagenes_List As ImageList

        '    If Global_Thema = Enum_Themas.Oscuro Then
        '        _Imagenes_List = Imagenes_16x16_Dark
        '    Else
        '        _Imagenes_List = Imagenes_16x16
        '    End If

        '    ' Dim estiloFuente As New DataGridViewCellStyle(_Fila.Cells("Asunto").Style)
        '    ' Establece la fuente en negrita

        '    Dim fuentePersonalizada As Font = Grilla.DefaultCellStyle.Font

        '    If _Estado = "NULO" Then
        '        _Icono = _Imagenes_List.Images.Item("cancel.png")
        '    Else

        '        If CBool(_Num) Then

        '            _Nombre_Image = "comment.png" '"comment-number-" & _Num & ".png"

        '            'If _Mesn_Pdte_Ver > 9 Then
        '            '    _Nombre_Image = "comment-number-9-plus.png"
        '            'End If

        '            _Icono = _Imagenes_List.Images.Item(_Nombre_Image)

        '            'If Global_Thema = Enum_Themas.Oscuro Then
        '            '    _Fila.DefaultCellStyle.ForeColor = Amarillo
        '            'Else
        '            '    _Fila.DefaultCellStyle.BackColor = Color.LightYellow
        '            'End If

        '            'fuentePersonalizada = New Font(fuentePersonalizada, FontStyle.Bold)

        '        Else
        '            _Icono = _Imagenes_List.Images.Item("menu-more.png")
        '            'estiloFuente.Font = New Font(_Fila.Cells(0).Style.Font, FontStyle.Regular)
        '        End If

        '    End If

        '    _Fila.Cells("BtnImagen_Estado").Value = _Icono
        '    '_Fila.Cells("BtnImagen_Estado2").Value = _Icono

        '    '' Aplica la fuente personalizada a la fila específica:
        '    'For Each celda As DataGridViewCell In _Fila.Cells
        '    '    celda.Style.Font = fuentePersonalizada
        '    'Next

        '    'If False Then


        '    ' Aplica el nuevo estilo de fuente a la celda
        '    '_Fila.Cells(0).Style.Font = estiloFuente.Font



        '    'If _Aceptado Then _Fila.Cells("NomEstado").Style.ForeColor = Verde
        '    'If _Rechazado Then _Fila.Cells("NomEstado").Style.ForeColor = Rojo

        '    '_Fila.Cells("NomPrioridad").Style.ForeColor = Color.White

        '    If _Prioridad = "AL" Then
        '        _Icono = _Imagenes_List.Images.Item("tag-green.png")
        '        '_Fila.Cells("NomPrioridad").Style.BackColor = Verde 'Color.Orange
        '    End If

        '    If _Prioridad = "BJ" Then
        '        _Icono = _Imagenes_List.Images.Item("tag-gray.png")
        '        '_Fila.Cells("NomPrioridad").Style.ForeColor = Color.Black
        '        '_Fila.Cells("NomPrioridad").Style.BackColor = Color.LightGray
        '    End If

        '    If _Prioridad = "NR" Then
        '        _Icono = _Imagenes_List.Images.Item("tag-blue.png")
        '        '_Fila.Cells("NomPrioridad").Style.BackColor = Azul
        '    End If

        '    If _Prioridad = "UR" Then
        '        _Icono = _Imagenes_List.Images.Item("tag-red.png")
        '        '_Fila.Cells("NomPrioridad").Style.BackColor = Rojo
        '    End If

        '    _Fila.Cells("BtnImagen_Estado2").Value = _Icono

        '    'End If

        'Next

        Grilla.Refresh()

    End Sub

    Private Sub Btn_Crear_Ticket_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Ticket.Click

        RemoveHandler Grilla.CellFormatting, AddressOf Grilla_CellFormatting

        Dim Fm As New Frm_Tickets_Mant(0)
        Fm.ShowDialog(Me)
        Fm.Dispose()

        AddHandler Grilla.CellFormatting, AddressOf Grilla_CellFormatting

        Sb_ActualizarTotalesTreeNodos(Tree_Bandeja.Nodes(0))

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Try
            RemoveHandler Grilla.CellFormatting, AddressOf Grilla_CellFormatting

            Dim _Fila As DataGridViewRow = Grilla.CurrentRow
            Dim _Id_Ticket As Integer = _Fila.Cells("Id").Value
            Dim _Numero As String = _Fila.Cells("Numero").Value

            Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Toma" & vbCrLf &
                           "Where CodFuncionario = '" & FUNCIONARIO & "' And NombreEquipo = '" & _NombreEquipo & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Select Top 1 KOFU,NOKOFU,Tm.NombreEquipo,Isnull(Alias,'') As Alias From " & vbCrLf &
                           _Global_BaseBk & "Zw_Stk_Tickets_Toma Tm " & vbCrLf &
                           "Inner Join TABFU On KOFU = CodFuncionario" & vbCrLf &
                           "Left Join " & _Global_BaseBk & "Zw_EstacionesBkp EstB On EstB.NombreEquipo = Tm.NombreEquipo" & vbCrLf &
                           "Where Id_Ticket = " & _Id_Ticket & " And CodFuncionario = '" & FUNCIONARIO & "'"
            Dim _Row_Tomado As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _SoloLectura = False

            If Not IsNothing(_Row_Tomado) Then

                Dim _UsuarioToma As String = _Row_Tomado.Item("KOFU") & " - " & _Row_Tomado.Item("NOKOFU").ToString.Trim

                If Not String.IsNullOrEmpty(_Row_Tomado.Item("Alias").ToString.Trim) Then
                    _NombreEquipo = _NombreEquipo.ToString.Trim & " (" & _Row_Tomado.Item("Alias") & ")"
                End If

                If MessageBoxEx.Show(Me, "El Ticket se encuentra tomado por el usuario: " & _UsuarioToma & vbCrLf &
                                  "En el equipo: " & _NombreEquipo & vbCrLf & vbCrLf &
                                  "Solo podrá ver el Ticket en modo de lectura" & vbCrLf & vbCrLf &
                                  "¿Desea abrirlo de todas maneras?", "Ticket tomado",
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) <> DialogResult.Yes Then
                    Return
                End If
                _SoloLectura = True

            End If

            Dim _GestinRealizada As Boolean

            Dim Fm As New Frm_Tickets_Seguimiento(_Id_Ticket)
            Fm.SoloLectura = _SoloLectura
            'Fm.Mis_Ticket = (_Tipo_Tickets = Enum_Tickets.MisTicket)
            Fm.ShowDialog(Me)
            _GestinRealizada = Fm.GestionRealizada
            Fm.Dispose()

            If _GestinRealizada Then

                Dim nodoSeleccionado As TreeNode = Tree_Bandeja.SelectedNode

                If nodoSeleccionado IsNot Nothing Then
                    ' El nodo seleccionado tiene el foco
                    ' Puedes acceder a sus propiedades o realizar otras acciones aquí
                    'Console.WriteLine("El nodo seleccionado es: " & nodoSeleccionado.Text)
                    Sb_Actualizar_Grilla_Treeview(nodoSeleccionado)
                    'Else
                    'Console.WriteLine("Ningún nodo tiene el foco actualmente.")
                End If

                BuscarDatoEnGrilla(_Numero, "Numero", Grilla)

            End If

        Catch ex As Exception
        Finally
            AddHandler Grilla.CellFormatting, AddressOf Grilla_CellFormatting
        End Try

    End Sub

    Private Sub Btn_RevisarTicket_Click(sender As Object, e As EventArgs) Handles Btn_RevisarTicket.Click
        Call Grilla_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click

        ' Obtén el nodo seleccionado (con foco):
        Dim nodoSeleccionado As TreeNode = Tree_Bandeja.SelectedNode

        If nodoSeleccionado IsNot Nothing Then

            Sb_ActualizarTotalesTreeNodos(Tree_Bandeja.Nodes(0))
            If _EsAgente Then
                Sb_ActualizarTotalesTreeNodos(Tree_Bandeja.Nodes(1))
            End If

            Sb_Actualizar_Grilla_Treeview(nodoSeleccionado)

        End If

    End Sub

    Private Sub Chk_TickesTiposMi_CheckedChanged(sender As Object, e As EventArgs)
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Frm_Tickets_Lista_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Toma" & vbCrLf &
                       "Where CodFuncionario = '" & FUNCIONARIO & "' And NombreEquipo = '" & _NombreEquipo & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql)

    End Sub

    Sub Sb_CargarTreeView()

        ' Crear el TreeView
        'Dim treeView As New TreeView()
        'Tree_Bandeja.Dock = DockStyle.Fill
        Tree_Bandeja.CheckBoxes = False

        Dim _BandejaEntrada As TreeNode
        Dim _Rec_Pendientes As TreeNode
        Dim _Rec_Aceptados As TreeNode
        Dim _Rec_Rechazados As TreeNode
        Dim _Rec_Cerradas As TreeNode

        Dim _Enviados As TreeNode
        Dim _Env_Pendientes As TreeNode
        Dim _Env_Aceptados As TreeNode
        Dim _Env_Rechazados As TreeNode
        Dim _Env_Cerradas As TreeNode

        Dim fuenteNegrita As New Font(Tree_Bandeja.Font.Name, 10, FontStyle.Bold)

        ' Crear los nodos de la Asignados
        _BandejaEntrada = Fx_CrearNodo("ASIGNADOS", "ASIGNADOS", 12, 12)
        _Rec_Pendientes = Fx_CrearNodo("Pendientes", "Pendientes", 0, 1)
        _Rec_Aceptados = Fx_CrearNodo("Aceptados", "Aceptados", 0, 1)
        _Rec_Rechazados = Fx_CrearNodo("Rechazados", "Rechazados", 0, 1)
        _Rec_Cerradas = Fx_CrearNodo("Cerradas", "Cerradas", 0, 1)

        With _BandejaEntrada
            .NodeFont = fuenteNegrita
            .Nodes.Add(_Rec_Pendientes)
            .Nodes.Add(_Rec_Aceptados)
            .Nodes.Add(_Rec_Rechazados)
            .Nodes.Add(_Rec_Cerradas)
        End With

        ' Crear los nodos de la bandeja de enviados
        _Enviados = Fx_CrearNodo("ENVIADOS", "ENVIADOS", 13, 13)

        _Env_Pendientes = Fx_CrearNodo("Pendientes", "Pendientes", 0, 1)
        _Env_Aceptados = Fx_CrearNodo("Aceptados", "Aceptados", 0, 1)
        _Env_Rechazados = Fx_CrearNodo("Rechazados", "Rechazados", 0, 1)
        _Env_Cerradas = Fx_CrearNodo("Cerradas", "Cerradas", 0, 1)

        With _Enviados
            .NodeFont = fuenteNegrita
            .Nodes.Add(Fx_CrearNodo("Pendientes", "Pendientes", 0, 1))
            .Nodes.Add(Fx_CrearNodo("Aceptados", "Aceptados", 0, 1))
            .Nodes.Add(Fx_CrearNodo("Rechazados", "Rechazados", 0, 1))
            .Nodes.Add(Fx_CrearNodo("Cerradas", "Cerradas", 0, 1))
        End With

        ' Agregar los nodos principales al TreeView
        Tree_Bandeja.Nodes.Add(_BandejaEntrada)
        Tree_Bandeja.Nodes.Add(_Enviados)

        Tree_Bandeja.ExpandAll()

        If Not (_EsAgente) Then

            ' Obtén el nodo que deseas eliminar (por ejemplo, el primer nodo hijo del nodo raíz):
            Dim nodoAEliminar As TreeNode = Tree_Bandeja.Nodes(0)

            ' Elimina el nodo:
            Tree_Bandeja.Nodes(0).Nodes.Remove(nodoAEliminar)

        End If

        Tree_Bandeja.Update()

    End Sub

    Function Fx_CrearNodo(_Tag As String, _Text As String, _ImageIndex As Integer, _SelectedImageIndex As Integer) As TreeNode
        Dim _Nodo As New TreeNode
        _Nodo.Text = _Text
        _Nodo.ImageIndex = _ImageIndex
        _Nodo.SelectedImageIndex = _SelectedImageIndex
        _Nodo.Tag = _Tag
        Return _Nodo
    End Function

    Private Sub Tree_Bandeja_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles Tree_Bandeja.AfterSelect

        Dim nodoSeleccionado As TreeNode = e.Node
        'Dim textoNodo As String = nodoSeleccionado.Text
        'Dim configuracionNodo As String = nodoSeleccionado.Tag ' Puedes asignar una configuración personalizada al nodo usando la propiedad Tag
        '' Realiza acciones según el nodo seleccionado
        'MessageBox.Show($"Nodo seleccionado: {textoNodo}, Configuración: {configuracionNodo}")

        Sb_Actualizar_Grilla_Treeview(nodoSeleccionado)

        'For Each nodoRaiz As TreeNode In _BandejaEntrada.Nodes
        '    Sb_Actualizar_Totales_Nodos(_BandejaEntrada, nodoRaiz)
        'Next

        'For Each nodoRaiz As TreeNode In _Enviados.Nodes
        '    Sb_Actualizar_Totales_Nodos(_Enviados, nodoRaiz)
        'Next

        'Sb_ActualizarTotalesTreeNodos(Tree_Bandeja.Nodes(0))

        Me.Refresh()

    End Sub

    Sub Sb_ActualizarTotalesTreeNodos(_NodoPadre As TreeNode)

        For Each Nodos As TreeNode In _NodoPadre.Nodes
            Sb_Actualizar_Totales_Nodos(_NodoPadre, Nodos)
            If Nodos.Nodes.Count > 0 Then
                Sb_ActualizarTotalesTreeNodos(Nodos)
            End If
        Next

    End Sub

    Private Sub Grilla_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) 'Handles Grilla.CellFormatting

        If IsNothing(_NodoSeleccionado) Then
            Return
        End If

        Dim _Columname As String = sender.Columns(e.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = sender.Rows(e.RowIndex)

        'If _Fila.Index = Grilla.RowCount - 1 Then
        '    RemoveHandler Grilla.CellFormatting, AddressOf Grilla_CellFormatting
        'End If

        Dim _Mesn_Pdte_Ver = _Fila.Cells("Mesn_Pdte_Ver").Value
        Dim _Resp_Pdte_Ver = _Fila.Cells("Resp_Pdte_Ver").Value
        Dim _Estado As String = _Fila.Cells("Estado").Value
        Dim _Aceptado As Boolean = _Fila.Cells("Aceptado").Value
        Dim _Rechazado As Boolean = _Fila.Cells("Rechazado").Value
        Dim _Prioridad As String = _Fila.Cells("Prioridad").Value

        Dim _Icono As Image
        Dim _Nombre_Image As String
        Dim _Num

        Dim _Carpeta As TreeNode = _NodoSeleccionado ' Tree_Bandeja.SelectedNode

        Dim nodoPadre As TreeNode = _Carpeta.Parent

        If nodoPadre.Tag = "ASIGNADOS" Then
            _Num = _Mesn_Pdte_Ver
        End If

        If nodoPadre.Tag = "ENVIADOS" Then
            _Num = _Resp_Pdte_Ver
        End If

        'If _Tipo_Tickets = Enum_Tickets.MisTicket Then
        '    _Num = _Resp_Pdte_Ver
        'Else
        '    _Num = _Mesn_Pdte_Ver
        'End If

        Dim _Imagenes_List As ImageList

        If Global_Thema = Enum_Themas.Oscuro Then
            _Imagenes_List = Imagenes_16x16_Dark
        Else
            _Imagenes_List = Imagenes_16x16
        End If

        ' Dim estiloFuente As New DataGridViewCellStyle(_Fila.Cells("Asunto").Style)
        ' Establece la fuente en negrita

        Dim fuentePersonalizada As Font '= Grilla.DefaultCellStyle.Font

        Dim _EstiloFuenteNegrita As New DataGridViewCellStyle(e.CellStyle)
        Dim _EstiloFuenteRegular As New DataGridViewCellStyle(e.CellStyle)
        ' Establece la fuente en negrita
        _EstiloFuenteNegrita.Font = New Font(e.CellStyle.Font, FontStyle.Bold)
        _EstiloFuenteRegular.Font = New Font(e.CellStyle.Font, FontStyle.Regular)

        If _Estado = "NULO" Then
            '_Fila.Cells("BtnImagen_Estado").Value = _Imagenes_List.Images.Item("cancel.png")
            '_Icono = _Imagenes_List.Images.Item("cancel.png")
        Else

            If CBool(_Num) Then

                _Nombre_Image = "comment.png" '"comment-number-" & _Num & ".png"

                'If _Mesn_Pdte_Ver > 9 Then
                '    _Nombre_Image = "comment-number-9-plus.png"
                'End If
                '_Fila.Cells("BtnImagen_Estado").Value = _Imagenes_List.Images.Item(_Nombre_Image)
                '_Icono = _Imagenes_List.Images.Item(_Nombre_Image)

                'If Global_Thema = Enum_Themas.Oscuro Then
                '    _Fila.DefaultCellStyle.ForeColor = Amarillo
                'Else
                '    _Fila.DefaultCellStyle.BackColor = Color.LightYellow
                'End If

                fuentePersonalizada = New Font(e.CellStyle.Font, FontStyle.Bold)

                'estiloFuente.Font = New Font(_Fila.Cells(0).Style.Font, FontStyle.Bold)
                'e.CellStyle = _EstiloFuenteNegrita
                _Fila.Cells("Asunto").Style = _EstiloFuenteNegrita
            Else
                fuentePersonalizada = New Font(e.CellStyle.Font, FontStyle.Regular)
                '_Fila.Cells("BtnImagen_Estado").Value = _Imagenes_List.Images.Item("menu-more.png")
                '_Icono = _Imagenes_List.Images.Item("menu-more.png")
                e.CellStyle = _EstiloFuenteRegular
            End If

        End If

        ' Aplica el nuevo estilo de fuente a la celda



        '' Aplica la fuente personalizada a la fila específica:
        'For Each celda As DataGridViewCell In _Fila.Cells
        '    celda.Style.Font = fuentePersonalizada
        'Next


        ' Aplica el nuevo estilo de fuente a la celda
        '_Fila.Cells(0).Style.Font = estiloFuente.Font

        '_Fila.Cells("BtnImagen_Estado").Value = _Icono

        If _Aceptado Then _Fila.Cells("NomEstado").Style.ForeColor = Verde
        If _Rechazado Then _Fila.Cells("NomEstado").Style.ForeColor = Rojo

        _Fila.Cells("NomPrioridad").Style.ForeColor = Color.White

        If _Prioridad = "AL" Then
            '_Icono = _Imagenes_List.Images.Item("tag-green.png")
            _Fila.Cells("NomPrioridad").Style.BackColor = Verde 'Color.Orange
        End If

        If _Prioridad = "BJ" Then
            '_Icono = _Imagenes_List.Images.Item("tag-gray.png")
            _Fila.Cells("NomPrioridad").Style.ForeColor = Color.Black
            _Fila.Cells("NomPrioridad").Style.BackColor = Color.LightGray
        End If

        If _Prioridad = "NR" Then
            '_Icono = _Imagenes_List.Images.Item("tag-blue.png")
            _Fila.Cells("NomPrioridad").Style.BackColor = Azul
        End If

        If _Prioridad = "UR" Then
            '_Icono = _Imagenes_List.Images.Item("tag-red.png")
            _Fila.Cells("NomPrioridad").Style.BackColor = Rojo
        End If

        '_Fila.Cells("BtnImagen_Estado2").Value = _Icono


    End Sub

    Sub Sb_Filtrar()
        Try
            If IsNothing(_Dv) Then Return

            Dim _Buscar As String

            If Txt_Filtrar.Text.Contains("#") Then
                Txt_Filtrar.Text = Replace(Txt_Filtrar.Text, "#", "")
                Txt_Filtrar.Text = "#Tk" & numero_(Txt_Filtrar.Text, 7)
            End If

            'If Chk_MostrarSoloIncluidos.Checked Then
            _Dv.RowFilter = String.Format("Numero+Asunto+FechaCreacion+NomFuncCrea+Codigo+DescripcionPr Like '%{0}%'", Txt_Filtrar.Text.Trim)
            'Else
            '_Dv.RowFilter = String.Format("CUDP+NUCUDP+NUDP+ENDP+VADP+FEEMDP+FEVEDP Like '%{0}%'", Txt_Filtrar.Text.Trim)
            'End If
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Cuek!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Txt_Filtrar_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Filtrar.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Filtrar()
        End If
    End Sub

    Private Sub Txt_Filtrar_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Filtrar.ButtonCustom2Click
        If String.IsNullOrWhiteSpace(Txt_Filtrar.Text) Then
            Return
        End If
        Txt_Filtrar.Text = String.Empty
        Sb_Filtrar()
    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Excel.Click

        RemoveHandler Grilla.CellFormatting, AddressOf Grilla_CellFormatting
        ExportarTabla_JetExcel_Tabla(_Tbl_Tickets, Me, "Tickets")
        AddHandler Grilla.CellFormatting, AddressOf Grilla_CellFormatting

    End Sub

    Private Sub Btn_VerTicket_Click(sender As Object, e As EventArgs) Handles Btn_VerTicket.Click
        Call Grilla_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Btn_TicketProducto_Click(sender As Object, e As EventArgs) Handles Btn_TicketProducto.Click

        Try

            RemoveHandler Grilla.CellFormatting, AddressOf Grilla_CellFormatting

            Dim _Fila As DataGridViewRow = Grilla.CurrentRow
            Dim _Id_Ticket As Integer = _Fila.Cells("Id").Value

            Dim _Cl_Tickets As New Cl_Tickets

            Dim _Mensaje As LsValiciones.Mensajes

            _Mensaje = _Cl_Tickets.Fx_Llenar_Ticket(_Id_Ticket)
            _Mensaje = _Cl_Tickets.FX_Llenar_Producto(_Cl_Tickets.Zw_Stk_Tickets.Id_Raiz)

            Dim Fm As New Frm_Tickets_IngProducto(_Cl_Tickets.Zw_Stk_Tickets.Id_Tipo)
            Fm._Cl_Tickets = _Cl_Tickets
            Fm.SoloLectura = True
            Fm.ShowDialog(Me)

        Catch ex As Exception
        Finally
            AddHandler Grilla.CellFormatting, AddressOf Grilla_CellFormatting
        End Try

    End Sub

    Private Sub Btn_Mnu_Copiar_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Copiar.Click

        With Grilla

            Dim _Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
            Dim _Texto_Cabeza = .Columns(.CurrentCell.ColumnIndex).HeaderText

            Dim Copiar = .Rows(.CurrentRow.Index).Cells(_Cabeza).Value
            Clipboard.SetText(Copiar)

            'MessageBoxEx.Show(Me, _Texto_Cabeza & " esta en el portapapeles", "Copiar", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End With

    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            With sender

                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)

                If Hitest.Type = DataGridViewHitTestType.Cell Then

                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

                    ShowContextMenu(Menu_Contextual_01)

                End If

            End With

        End If

    End Sub

    Private Sub Txt_Filtrar_TextChanged(sender As Object, e As EventArgs) Handles Txt_Filtrar.TextChanged
        If String.IsNullOrWhiteSpace(Txt_Filtrar.Text) Then
            Sb_Filtrar()
            Return
        End If
    End Sub
End Class
