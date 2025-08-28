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
    Private _NodoAnterior As TreeNode

    Public Sub New(_Funcionario As String, _Tipo As Enum_Tickets, _Id_Grupo As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Funcionario = _Funcionario
        Me._Tipo_Tickets = _Tipo
        Me._Id_Grupo = _Id_Grupo

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, True, False)
        Sb_Formato_Generico_Grilla(Grilla_Acciones, 22, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, False, False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Tickets_Lista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Agentes", "CodAgente = '" & FUNCIONARIO & "'")

        _EsAgente = CBool(_Reg)

        Sb_InsertarBotonenGrilla(Grilla, "BtnImagen_Estado", "Est.", "Img_Estado", 0, _Tipo_Boton.Imagen)
        Sb_InsertarBotonenGrilla(Grilla, "BtnImagen_Estado2", "Est.", "Img_Estado2", 0, _Tipo_Boton.Imagen)
        Sb_InsertarBotonenGrilla(Grilla, "BtnImagen_Estado3", "Est.", "Img_Estado3", 0, _Tipo_Boton.Imagen)

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Btn_Crear_Ticket.Visible = (_Tipo_Tickets = Enum_Tickets.MisTicket)
        Btn_RevisarTicket.Visible = Not (_Tipo_Tickets = Enum_Tickets.MisTicket)

        AddHandler Chk_TickesMiGrupo.CheckedChanged, AddressOf Chk_TickesTiposMi_CheckedChanged
        'AddHandler Grilla.CellFormatting, AddressOf Grilla_CellFormatting
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

        Me.Text = "MANTENCION DE TICKET, Usuario : " & FUNCIONARIO & " - " & Nombre_funcionario_activo

        Sb_CargarTreeView()

        Sb_InsertarBotonenGrilla(Grilla_Acciones, "Btn_ImagenAttach", "Est.", "ImagenAttach", 0, _Tipo_Boton.Imagen)
        Sb_InsertarBotonenGrilla(Grilla_Acciones, "Btn_ProductoInfo", "P.I.", "ProductoInfo", 0, _Tipo_Boton.Imagen)
        Sb_InsertarBotonenGrilla(Grilla_Acciones, "Btn_DocCierra", "Doc.", "DocCierra", 0, _Tipo_Boton.Imagen)
        Sb_InsertarBotonenGrilla(Grilla_Acciones, "Btn_ImagenUser", "Est.", "ImagenUser", 0, _Tipo_Boton.Imagen)

        Sb_Actualizar_Grilla_Treeview(Nothing)
        Sb_ActualizarTotalesTreeNodos(Tree_Bandeja.Nodes(0))
        Sb_ActualizarTotalesTreeNodos(Tree_Bandeja.Nodes(1))
        Sb_ActualizarTotalesTreeNodos(Tree_Bandeja.Nodes(2))

        Txt_Descripcion.ReadOnly = True

        Dtp_Filtro_Fcreacion_Desde.Enabled = Chk_Filtro_FcreacionRango.Checked
        Dtp_Filtro_Fcreacion_Hasta.Enabled = Chk_Filtro_FcreacionRango.Checked
        Btn_Filtrar.Enabled = Chk_Filtro_FcreacionRango.Checked

        Dtp_Filtro_Fcreacion_Desde.Value = Primerdiadelmes(Date.Now)
        Dtp_Filtro_Fcreacion_Hasta.Value = ultimodiadelmes(Date.Now)

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
                                "Where CodAgente = '" & FUNCIONARIO & "') " & _Condicion2 & ")" & vbCrLf &
                                "And CodFuncionario_Crea <> '" & FUNCIONARIO & "'"
            End If

            If _NodoPadre.Text = "TODOS" Then
                _CondicionFun = "1>0"
            End If


            Dim _FechaLimite As DateTime = DateAdd(DateInterval.Weekday, -1, Now.Date)
            Dim _FechaLimiteStr As String = Format(_FechaLimite, "yyyyMMdd")

            If _NodoHijo.Tag = "EnProceso" Then _Accion = "And Estado = 'PROC' And Aceptado = 0 And Rechazado = 0"
            If _NodoHijo.Tag = "Aceptados" Then _Accion = "And Aceptado = 1 And Rechazado = 0 And Estado <> 'PROC' And CONVERT(varchar, FechaCierre, 112) > '" & _FechaLimiteStr & "'"
            If _NodoHijo.Tag = "Rechazados" Then _Accion = "And Aceptado = 0 And Rechazado = 1 And Estado <> 'PROC' And CONVERT(varchar, FechaCierre, 112) > '" & _FechaLimiteStr & "'"
            If _NodoHijo.Tag = "Pendientes" Then _Accion = "And Estado = 'ABIE' And Aceptado = 0 And Rechazado = 0"
            If _NodoHijo.Tag = "Cerradas" Then _Accion = "And Estado = 'CERR' And CONVERT(varchar, FechaCierre, 112) > '" & _FechaLimiteStr & "'"
            If _NodoHijo.Tag = "Nulos" Then _Accion = "And Estado = 'NULO' And CONVERT(varchar, FechaCierre, 112) > '" & _FechaLimiteStr & "'"

            'If _Carpeta.Tag = "Cerradas" Then
            '    _Condicion += vbCrLf & "And Estado = 'CERR' And CONVERT(varchar, FechaCierre, 112) > '" & _FechaLimiteStr & "'"
            'End If

            'If _Carpeta.Tag = "Nulos" Then
            '    _Condicion += vbCrLf & "And Estado = 'NULO' And CONVERT(varchar, FechaCierre, 112) > '" & _FechaLimiteStr & "'"
            'End If

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


    Sub Sb_Actualizar_Grilla_Treeview(_Carpeta As TreeNode)

        If False Then
            Sb_ActualizarTotalesTreeNodos(Tree_Bandeja.Nodes(0))
            Sb_ActualizarTotalesTreeNodos(Tree_Bandeja.Nodes(1))
            'If _EsAgente Then
            '    Sb_ActualizarTotalesTreeNodos(Tree_Bandeja.Nodes(1))
            'End If
        End If

        Me.Cursor = Cursors.WaitCursor

        If IsNothing(_Carpeta) Then
            GroupPanel1.Text = "Tickets"
        Else
            GroupPanel1.Text = "Tickets: " & _Carpeta.FullPath
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
                                 "Where CodAgente = '" & FUNCIONARIO & "') " & _Condicion2 & ")" & vbCrLf &
                                 "And Tks.CodFuncionario_Crea <> '" & FUNCIONARIO & "'"
            End If

            If nodoPadre.Tag = "ENVIADOS" Then
                _Condicion = "And Tks.CodFuncionario_Crea = '" & _Funcionario & "'"
            End If

            If _Carpeta.Tag = "Pendientes" Then
                _Condicion += vbCrLf & "And Tks.Estado = 'ABIE' And Tks.Rechazado = 0 And Tks.Aceptado = 0"
            End If

            If _Carpeta.Tag = "EnProceso" Then
                _Condicion += vbCrLf & "And Tks.Estado = 'PROC' And Tks.Aceptado = 0 And Tks.Rechazado = 0"
            End If

            Dim _FechaLimite As DateTime = DateAdd(DateInterval.Weekday, -1, Now.Date)
            Dim _FechaLimiteStr As String = Format(_FechaLimite, "yyyyMMdd")

            If _Carpeta.Tag = "Aceptados" Then
                _Condicion += vbCrLf & "And Tks.Aceptado = 1 And Tks.Rechazado = 0 And Tks.Estado <> 'PROC' And CONVERT(varchar, Tks.FechaCierre, 112) > '" & _FechaLimiteStr & "'"
            End If

            If _Carpeta.Tag = "Rechazados" Then
                _Condicion += vbCrLf & "And Tks.Rechazado = 1 And Tks.Aceptado = 0 And Tks.Estado <> 'PROC' And CONVERT(varchar, Tks.FechaCierre, 112) > '" & _FechaLimiteStr & "'"
            End If

            If _Carpeta.Tag = "Cerradas" Then
                _Condicion += vbCrLf & "And Tks.Estado = 'CERR' And CONVERT(varchar, Tks.FechaCierre, 112) > '" & _FechaLimiteStr & "'"
            End If

            If _Carpeta.Tag = "Nulos" Then
                _Condicion += vbCrLf & "And Tks.Estado = 'NULO' And CONVERT(varchar, Tks.FechaCierre, 112) > '" & _FechaLimiteStr & "'"
            End If

            _NodoSeleccionado = _Carpeta

        Else

            Try
                If _Carpeta.Tag = "ASIGNADOS" Then
                    _Condicion = "And (Tks.Id In (Select Id_Ticket From " & _Global_BaseBk & "Zw_Stk_Tickets_Asignado " &
                                     "Where CodAgente = '" & FUNCIONARIO & "') " & _Condicion2 & ")"
                End If

                If _Carpeta.Tag = "ENVIADOS" Then
                    _Condicion = "And Tks.CodFuncionario_Crea = '" & _Funcionario & "'"
                End If
                _NodoSeleccionado = _Carpeta
            Catch ex As Exception
                _Condicion = "And 1 = 0"
                _NodoSeleccionado = Nothing
            End Try

        End If

        '        Consulta_sql = $"Select Distinct Tks.*,
        'Isnull(TksDeri.Numero,'') As 'NroDerivado',Isnull(TksDeri.SubNro,'') As 'SubDerivado',
        'Isnull(TksAhilo.Numero,'') As 'NroHilo',Isnull(TksAhilo.SubNro,'') As 'SubHilo',
        'NOKOFU As 'NomFuncCrea',TkPrd.Empresa As 'Empresa_Pr',TkPrd.Sucursal As 'Sucursal_Pr',TkPrd.Bodega As 'Bodega_Pr',
        'TkPrd.Codigo,TkPrd.Descripcion As DescripcionPr,
        'TkPrd.Um As 'Udm',StfiEnBodega,Cantidad,Diferencia
        ',Case Tks.Prioridad When 'AL' Then 'Alta' When 'NR' Then 'Normal' When 'BJ' Then 'Baja' When 'UR' Then 'Urgente' Else '??' End As NomPrioridad
        ',Case Tks.UltAccion When 'INGR' then 'Ingresada' When 'MENS' then 'Mensaje' When 'RESP' then 'Respondido' When 'CERR' then 'Cerrada' End As UltimaAccion
        ',Case Tks.Estado 
        '                       When 'ABIE' Then 
        '                            Case When Tks.Rechazado = 1 Then 'ABIERTO (Rechazado)' Else 'ABIERTO' End 
        '					   When 'PROC' Then 'EN PROCESO'
        '                       When 'CERR' Then 
        '                            Case When Tks.Rechazado = 1 Then 'CERRADO (Rechazado)' When Tks.Aceptado = 1 Then 'CERRADO (Aceptado)' Else 'CERRADO' End 
        '                       When 'NULO' then 'NULO' When 'SOLC' then 'Sol. Cierre' End As NomEstado,Cast('' As Varchar(100)) As 'NomEstadoExt',
        '(Select COUNT(*) From {_Global_BaseBk}Zw_Stk_Tickets_Acciones AcMs Where AcMs.Id_Raiz = Tks.Id_Raiz And AcMs.Accion In ('MENS','CREA') And AcMs.Visto = 0) As Mesn_Pdte_Ver,
        '(Select COUNT(*) From {_Global_BaseBk}Zw_Stk_Tickets_Acciones AcRs Where AcRs.Id_Raiz = Tks.Id_Raiz And AcRs.Accion In ('RESP','CREA') And AcRs.Visto = 0) As Resp_Pdte_Ver,
        'Cast(0 As int) AS Idmaeedo_Cierra,Cast('' As Varchar(100)) As 'Motivo_Cierra',Cast('' As Varchar(30)) As 'NomFuncionario_Cierra'
        'Into #Paso
        'From {_Global_BaseBk}Zw_Stk_Tickets Tks
        '--Left Join {_Global_BaseBk}Zw_Stk_Tickets_Producto TkPrd On Tks.Id_Raiz = TkPrd.Id_Raiz And TkPrd.Id_Raiz = TkPrd.Id_Ticket
        'Left Join {_Global_BaseBk}Zw_Stk_Tickets_Producto TkPrd On TkPrd.Id_Ticket = Tks.Id And Tks.Id_Raiz = TkPrd.Id_Raiz 
        'Left Join TABFU Fu On Fu.KOFU = Tks.CodFuncionario_Crea
        'Left Join {_Global_BaseBk}Zw_Stk_Tickets TksDeri On TksDeri.Id = Tks.Id_Padre
        'Left Join {_Global_BaseBk}Zw_Stk_Tickets_Acciones TksADeri On Tks.Id = TksADeri.Id_Ticket_Cierra And TksADeri.Accion = 'CECR'
        'Left Join {_Global_BaseBk}Zw_Stk_Tickets TksAhilo On TksAhilo.Id = TksADeri.Id_Ticket
        'Where 1 > 0" & vbCrLf & _Condicion & vbCrLf &
        '                       $"Order By Tks.FechaCreacion

        'Update #Paso Set Idmaeedo_Cierra = Isnull((Select Top 1 Idmaeedo_Cierra From {_Global_BaseBk}Zw_Stk_Tickets_Acciones Aci Where Aci.Id_Ticket = #Paso.Id And Idmaeedo_Cierra <> 0),0)
        'Update #Paso Set CodFuncionario_Cierra = Isnull((Select Top 1 Aci.CodFuncionario From {_Global_BaseBk}Zw_Stk_Tickets_Acciones Aci Where Aci.Id_Ticket = #Paso.Id And Accion = 'ACCI'),0)
        'Update #Paso Set NomFuncionario_Cierra = Isnull((Select Top 1 NOKOFU From TABFU Where KOFU = #Paso.CodFuncionario_Cierra),'')

        'Update #Paso Set NomEstadoExt = NomEstado+'... (derivado de '+NroDerivado+'-'+SubDerivado+')' 
        'Where Id_Padre <> 0 and NroDerivado <> '' And Estado in ('ABIE')

        'Update #Paso Set NomEstadoExt = NomEstado+'... (hilo continuado en '+NroHilo+'-'+SubHilo+')' 
        'Where Id_Padre = 0 And NroHilo <> '' And Estado = 'PROC'

        'Update #Paso Set NomEstadoExt = NomEstado
        'Where NomEstadoExt = ''

        'Update #Paso Set [Motivo_Cierra] = (Select Top 1 Motivo_Cierra From {_Global_BaseBk}Zw_Stk_Tickets_Acciones Acc Where Acc.Idmaeedo_Cierra = #Paso.Idmaeedo_Cierra) Where Idmaeedo_Cierra <> 0
        'Update #Paso Set [Motivo_Cierra] = (Select Top 1 'MOTIVO: '+[Motivo_Cierra]+' - '+NOKOCARAC From TABCARAC Where KOCARAC = [Motivo_Cierra]) Where Idmaeedo_Cierra <> 0

        'Select * From #Paso
        'Drop Table #Paso"



        Consulta_sql = $"-- CTE para seleccionar solo un producto por ticket
;With ProductosUnicos As (
    Select *,
           ROW_NUMBER() Over (Partition By Id_Ticket, Id_Raiz Order By Id) As rn
    From {_Global_BaseBk}Zw_Stk_Tickets_Producto
)

-- Selección principal con JOIN al producto único
Select Distinct Tks.*,
    Isnull(TksDeri.Numero,'') As 'NroDerivado',
    Isnull(TksDeri.SubNro,'') As 'SubDerivado',
    Isnull(TksAhilo.Numero,'') As 'NroHilo',
    Isnull(TksAhilo.SubNro,'') As 'SubHilo',
    NOKOFU As 'NomFuncCrea',
    TkPrd.Empresa As 'Empresa_Pr',
    TkPrd.Sucursal As 'Sucursal_Pr',
    TkPrd.Bodega As 'Bodega_Pr',
    TkPrd.Codigo,
    TkPrd.Descripcion As DescripcionPr,
    TkPrd.Um As 'Udm',
    StfiEnBodega,
    Cantidad,
    Diferencia,
    Case Tks.Prioridad 
        When 'AL' Then 'Alta' 
        When 'NR' Then 'Normal' 
        When 'BJ' Then 'Baja' 
        When 'UR' Then 'Urgente' 
        Else '??' 
    End As NomPrioridad,
    Case Tks.UltAccion 
        When 'INGR' then 'Ingresada' 
        When 'MENS' then 'Mensaje' 
        When 'RESP' then 'Respondido' 
        When 'CERR' then 'Cerrada' 
    End As UltimaAccion,
    Case Tks.Estado  
        When 'ABIE' Then  
            Case When Tks.Rechazado = 1 Then 'ABIERTO (Rechazado)' Else 'ABIERTO' End  
        When 'PROC' Then 'EN PROCESO'
        When 'CERR' Then  
            Case When Tks.Rechazado = 1 Then 'CERRADO (Rechazado)' 
                 When Tks.Aceptado = 1 Then 'CERRADO (Aceptado)' 
                 Else 'CERRADO' End  
        When 'NULO' then 'NULO' 
        When 'SOLC' then 'Sol. Cierre' 
    End As NomEstado,
    Cast('' As Varchar(100)) As 'NomEstadoExt',
    (Select COUNT(*) 
     From {_Global_BaseBk}Zw_Stk_Tickets_Acciones AcMs 
     Where AcMs.Id_Raiz = Tks.Id_Raiz And AcMs.Accion In ('MENS','CREA') And AcMs.Visto = 0) As Mesn_Pdte_Ver,
    (Select COUNT(*) 
     From {_Global_BaseBk}Zw_Stk_Tickets_Acciones AcRs 
     Where AcRs.Id_Raiz = Tks.Id_Raiz And AcRs.Accion In ('RESP','CREA') And AcRs.Visto = 0) As Resp_Pdte_Ver,
    Cast(0 As int) AS Idmaeedo_Cierra,
    Cast('' As Varchar(100)) As 'Motivo_Cierra'
Into #Paso
From {_Global_BaseBk}Zw_Stk_Tickets Tks
Left Join ProductosUnicos TkPrd On TkPrd.Id_Ticket = Tks.Id And TkPrd.Id_Raiz = Tks.Id_Raiz And TkPrd.rn = 1
Left Join TABFU Fu On Fu.KOFU = Tks.CodFuncionario_Crea
Left Join {_Global_BaseBk}Zw_Stk_Tickets TksDeri On TksDeri.Id = Tks.Id_Padre
Left Join {_Global_BaseBk}Zw_Stk_Tickets_Acciones TksADeri On Tks.Id = TksADeri.Id_Ticket_Cierra And TksADeri.Accion = 'CECR'
Left Join {_Global_BaseBk}Zw_Stk_Tickets TksAhilo On TksAhilo.Id = TksADeri.Id_Ticket
--Where Tks.Id_Raiz = 1246
Where 1 > 0 {_Condicion}
Order By Tks.FechaCreacion

-- Actualizaciones posteriores
Update #Paso 
Set Idmaeedo_Cierra = Isnull((Select Top 1 Idmaeedo_Cierra 
                              From {_Global_BaseBk}Zw_Stk_Tickets_Acciones Aci 
                              Where Aci.Id_Ticket = #Paso.Id And Idmaeedo_Cierra <> 0),0)

Update #Paso 
Set NomEstadoExt = NomEstado+'... (derivado de '+NroDerivado+'-'+SubDerivado+')' 
Where Id_Padre <> 0 and NroDerivado <> '' And Estado in ('ABIE')

Update #Paso 
Set NomEstadoExt = NomEstado+'... (hilo continuado en '+NroHilo+'-'+SubHilo+')' 
Where Id_Padre = 0 And NroHilo <> '' And Estado = 'PROC'

Update #Paso 
Set NomEstadoExt = NomEstado 
Where NomEstadoExt = ''

Update #Paso 
Set [Motivo_Cierra] = (Select Top 1 Motivo_Cierra 
                       From {_Global_BaseBk}Zw_Stk_Tickets_Acciones Acc 
                       Where Acc.Idmaeedo_Cierra = #Paso.Idmaeedo_Cierra) 
Where Idmaeedo_Cierra <> 0

Update #Paso 
Set [Motivo_Cierra] = (Select Top 1 'MOTIVO: '+[Motivo_Cierra]+' - '+NOKOCARAC 
                       From TABCARAC 
                       Where KOCARAC = [Motivo_Cierra]) 
Where Idmaeedo_Cierra <> 0

-- Resultado final
Select * From #Paso
Drop Table #Paso"


        _Tbl_Tickets = _Sql.Fx_Get_DataTable(Consulta_sql)

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
            .Columns("NomFuncCrea").Width = 140
            .Columns("NomFuncCrea").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Asunto").Visible = True
            .Columns("Asunto").HeaderText = "Asunto"
            .Columns("Asunto").Width = 200
            .Columns("Asunto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("NomEstado").Visible = True
            '.Columns("NomEstado").HeaderText = "Estado"
            '.Columns("NomEstado").ToolTipText = "Estado del Ticket"
            '.Columns("NomEstado").Width = 110
            '.Columns("NomEstado").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("NomEstadoExt").Visible = True
            .Columns("NomEstadoExt").HeaderText = "Estado"
            .Columns("NomEstadoExt").ToolTipText = "Estado del Ticket"
            .Columns("NomEstadoExt").Width = 110
            .Columns("NomEstadoExt").DisplayIndex = _DisplayIndex
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

            .Columns("Sucursal_Pr").Visible = True
            .Columns("Sucursal_Pr").HeaderText = "Suc"
            .Columns("Sucursal_Pr").Width = 30
            .Columns("Sucursal_Pr").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Bodega_Pr").Visible = True
            .Columns("Bodega_Pr").HeaderText = "Bod"
            .Columns("Bodega_Pr").Width = 30
            .Columns("Bodega_Pr").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

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

            '.Columns("StfiEnBodega").Visible = True
            '.Columns("StfiEnBodega").HeaderText = "Stk Bod."
            '.Columns("StfiEnBodega").ToolTipText = "Stock físico en bodega del producto al momento de la gestión"
            '.Columns("StfiEnBodega").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("StfiEnBodega").Width = 40
            '.Columns("StfiEnBodega").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Cantidad").Visible = True
            '.Columns("Cantidad").HeaderText = "Cant."
            '.Columns("Cantidad").ToolTipText = "Cantidad inventariada al momento de la operación"
            '.Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Cantidad").Width = 40
            '.Columns("Cantidad").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Diferencia").Visible = True
            .Columns("Diferencia").HeaderText = "Dif"
            .Columns("Diferencia").ToolTipText = "Diferencia entre el stock en bodega y la cantidad inventariada"
            .Columns("Diferencia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Diferencia").Width = 45
            .Columns("Diferencia").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1


            .Columns("Id").Visible = True
            .Columns("Id").HeaderText = "Id_Ticket"
            .Columns("Id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Id").Width = 50
            .Columns("Id").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Id_Raiz").Visible = True
            .Columns("Id_Raiz").HeaderText = "Id_Raiz"
            .Columns("Id_Raiz").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Id_Raiz").Width = 50
            .Columns("Id_Raiz").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Id_Padre").Visible = True
            .Columns("Id_Padre").HeaderText = "Id_Padre"
            .Columns("Id_Padre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Id_Padre").Width = 50
            .Columns("Id_Padre").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Toma" & vbCrLf &
                       "Where CodFuncionario = '" & FUNCIONARIO & "' And NombreEquipo = '" & _NombreEquipo & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Lbl_Estatus.Text = "Registros: " & _Tbl_Tickets.Rows.Count

        ' Posicionarse en la primera fila de la grilla si tiene datos
        If Grilla.Rows.Count > 0 Then
            Grilla.CurrentCell = Grilla.Rows(0).Cells("Numero")
            Dim _Id_Raiz As Integer = Grilla.Rows(0).Cells("Id_Raiz").Value
            Sb_Actualizar_Grilla_Acciones(_Id_Raiz)
        Else
            Grilla_Acciones.DataSource = Nothing
        End If

        Txt_Descripcion.Text = String.Empty

        Grilla.Refresh()

        If Not String.IsNullOrWhiteSpace(Txt_Filtrar.Text.Trim) Or Chk_Filtro_FcreacionRango.Checked Then
            Sb_Filtrar()
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Btn_Crear_Ticket_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Ticket.Click

        Dim Fm As New Frm_Tickets_Mant(0)
        Fm.ShowDialog(Me)
        Fm.Dispose()

        ' Obtén el nodo seleccionado (con foco):
        Dim nodoSeleccionado As TreeNode = Tree_Bandeja.SelectedNode

        If nodoSeleccionado Is Nothing AndAlso Tree_Bandeja.Nodes.Count > 0 Then
            nodoSeleccionado = Tree_Bandeja.Nodes(0)
            Tree_Bandeja.SelectedNode = nodoSeleccionado
        End If

        Call Btn_Actualizar_Click(Nothing, Nothing)

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Try
            'RemoveHandler Grilla.CellFormatting, AddressOf Grilla_CellFormatting

            Dim _Fila As DataGridViewRow = Grilla.CurrentRow
            Dim _Id_Ticket As Integer = _Fila.Cells("Id").Value
            Dim _Numero As String = _Fila.Cells("Numero").Value
            Dim _SubNro As String = _Fila.Cells("SubNro").Value

            Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Toma" & vbCrLf &
                           "Where CodFuncionario = '" & FUNCIONARIO & "' And NombreEquipo = '" & _NombreEquipo & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Select Top 1 KOFU,NOKOFU,Tm.NombreEquipo,Isnull(Alias,'') As Alias From " & vbCrLf &
                           _Global_BaseBk & "Zw_Stk_Tickets_Toma Tm " & vbCrLf &
                           "Inner Join TABFU On KOFU = CodFuncionario" & vbCrLf &
                           "Left Join " & _Global_BaseBk & "Zw_EstacionesBkp EstB On EstB.NombreEquipo = Tm.NombreEquipo" & vbCrLf &
                           "Where Id_Ticket = " & _Id_Ticket & " --And CodFuncionario = '" & FUNCIONARIO & "'"
            Dim _Row_Tomado As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _SoloLectura = False

            If Not IsNothing(_Row_Tomado) Then

                Dim _UsuarioToma As String = _Row_Tomado.Item("KOFU") & " - " & _Row_Tomado.Item("NOKOFU").ToString.Trim

                If Not String.IsNullOrEmpty(_Row_Tomado.Item("Alias").ToString.Trim) Then
                    _NombreEquipo = _Row_Tomado.Item("Alias")
                End If

                If MessageBoxEx.Show(Me, "El Ticket se encuentra tomado por el usuario: " & _UsuarioToma & vbCrLf &
                                  "En el equipo: " & _NombreEquipo & vbCrLf & vbCrLf &
                                  "Solo podrá ver el Ticket en modo de lectura" & vbCrLf & vbCrLf &
                                  "¿Desea abrirlo de todas maneras?", "Ticket " & _Numero & " - " & _SubNro & " tomado",
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) <> DialogResult.Yes Then
                    Return
                End If

                _SoloLectura = True

            End If


            If IsNothing(_NodoSeleccionado) OrElse
                _NodoSeleccionado.Text = "TODOS" OrElse
                IsNothing(_NodoSeleccionado.Parent) OrElse
                _NodoSeleccionado.Parent.Text = "TODOS" Then
                _SoloLectura = True
            End If

            Dim _GestionRealizada As Boolean
            Dim _Anulado As Boolean

            Dim Fm As New Frm_Tickets_Seguimiento(_Id_Ticket)
            Fm.SoloLectura = _SoloLectura
            Fm.ShowDialog(Me)
            _Anulado = Fm.Anulado
            _GestionRealizada = Fm.GestionRealizada
            Fm.Dispose()

            ' Obtén el nodo seleccionado (con foco):
            Dim nodoSeleccionado As TreeNode = Tree_Bandeja.SelectedNode

            If _GestionRealizada Then

                Txt_Filtrar.Text = String.Empty
                Call Btn_Actualizar_Click(Nothing, Nothing)

                'If nodoSeleccionado IsNot Nothing Then
                '    ' El nodo seleccionado tiene el foco
                '    ' Puedes acceder a sus propiedades o realizar otras acciones aquí
                '    'Console.WriteLine("El nodo seleccionado es: " & nodoSeleccionado.Text)

                '    Sb_ActualizarTotalesTreeNodos(Tree_Bandeja.Nodes(0))
                '    Sb_ActualizarTotalesTreeNodos(Tree_Bandeja.Nodes(1))
                '    Sb_ActualizarTotalesTreeNodos(Tree_Bandeja.Nodes(2))

                '    Sb_Actualizar_Grilla_Treeview(nodoSeleccionado)
                '    'Else
                '    'Console.WriteLine("Ningún nodo tiene el foco actualmente.")
                'End If

                BuscarDatoEnGrilla(_Numero, "Numero", Grilla)

            End If

            If _Anulado Then

                If nodoSeleccionado Is Nothing AndAlso Tree_Bandeja.Nodes.Count > 0 Then
                    nodoSeleccionado = Tree_Bandeja.Nodes(0)
                    Tree_Bandeja.SelectedNode = nodoSeleccionado
                End If

                Call Btn_Actualizar_Click(Nothing, Nothing)
            End If

        Catch ex As Exception
        Finally
            'AddHandler Grilla.CellFormatting, AddressOf Grilla_CellFormatting
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
            Sb_ActualizarTotalesTreeNodos(Tree_Bandeja.Nodes(1))
            Sb_ActualizarTotalesTreeNodos(Tree_Bandeja.Nodes(2))

            Sb_Actualizar_Grilla_Treeview(nodoSeleccionado)

        End If

    End Sub

    Private Sub Chk_TickesTiposMi_CheckedChanged(sender As Object, e As EventArgs)
        Dim nodoSeleccionado As TreeNode = Tree_Bandeja.SelectedNode
        Sb_Actualizar_Grilla_Treeview(nodoSeleccionado)
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
        Dim _Asig_Pendientes As TreeNode
        Dim _Asig_Aceptados As TreeNode
        Dim _Asig_Rechazados As TreeNode
        Dim _Asig_Nulos As TreeNode

        Dim _Enviados As TreeNode
        Dim _Env_Pendientes As TreeNode
        Dim _Env_EnProceso As TreeNode
        Dim _Env_Aceptados As TreeNode
        Dim _Env_Rechazados As TreeNode
        Dim _Env_Nulos As TreeNode

        Dim fuenteNegrita As New Font(Tree_Bandeja.Font.Name, 10, FontStyle.Bold)

        ' Crear los nodos de la Asignados
        _BandejaEntrada = Fx_CrearNodo("ASIGNADOS", "ASIGNADOS", 12, 12)
        _Asig_Pendientes = Fx_CrearNodo("Pendientes", "Pendientes", 0, 1)
        _Asig_Aceptados = Fx_CrearNodo("Aceptados", "Aceptados", 0, 1)
        _Asig_Rechazados = Fx_CrearNodo("Rechazados", "Rechazados", 0, 1)
        _Asig_Nulos = Fx_CrearNodo("Nulos", "Nulos", 0, 1)

        With _BandejaEntrada
            .NodeFont = fuenteNegrita
            .Nodes.Add(_Asig_Pendientes)
            .Nodes.Add(_Asig_Aceptados)
            .Nodes.Add(_Asig_Rechazados)
            .Nodes.Add(_Asig_Nulos)
        End With

        ' Crear los nodos de la bandeja de enviados
        _Enviados = Fx_CrearNodo("ENVIADOS", "ENVIADOS", 13, 13)
        _Env_Pendientes = Fx_CrearNodo("Pendientes", "Pendientes", 0, 1)
        _Env_EnProceso = Fx_CrearNodo("EnProceso", "En proceso", 0, 1)
        _Env_Aceptados = Fx_CrearNodo("Aceptados", "Aceptados", 0, 1)
        _Env_Rechazados = Fx_CrearNodo("Rechazados", "Rechazados", 0, 1)
        _Env_Nulos = Fx_CrearNodo("Nulos", "Nulos", 0, 1)

        With _Enviados
            .NodeFont = fuenteNegrita
            .Nodes.Add(_Env_Pendientes)
            .Nodes.Add(_Env_EnProceso)
            .Nodes.Add(_Env_Aceptados)
            .Nodes.Add(_Env_Rechazados)
            .Nodes.Add(_Env_Nulos)
        End With

        ' Agregar los nodos principales al TreeView
        Tree_Bandeja.Nodes.Add(_BandejaEntrada)
        Tree_Bandeja.Nodes.Add(_Enviados)

        Tree_Bandeja.ExpandAll()
        Tree_Bandeja.Update()

        ' Crear los nodos de la Asignados
        _BandejaEntrada = Fx_CrearNodo("TODOS", "TODOS", 12, 12)
        _Asig_Pendientes = Fx_CrearNodo("Pendientes", "Pendientes", 0, 1)
        _Asig_Aceptados = Fx_CrearNodo("Aceptados", "Aceptados", 0, 1)
        _Asig_Rechazados = Fx_CrearNodo("Rechazados", "Rechazados", 0, 1)
        _Asig_Nulos = Fx_CrearNodo("Nulos", "Nulos", 0, 1)

        With _BandejaEntrada
            .NodeFont = fuenteNegrita
            .Nodes.Add(_Asig_Pendientes)
            .Nodes.Add(_Asig_Aceptados)
            .Nodes.Add(_Asig_Rechazados)
            .Nodes.Add(_Asig_Nulos)
        End With

        Tree_Bandeja.Nodes.Add(_BandejaEntrada)
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

        If nodoSeleccionado.Text = "TODOS" AndAlso Not nodoSeleccionado.IsExpanded Then
            If Not Fx_Tiene_Permiso(Me, "Tkts0007") Then
                ' Si no tiene permiso, volver a seleccionar el nodo anterior si no es Nothing
                If _NodoAnterior IsNot Nothing Then
                    Tree_Bandeja.SelectedNode = _NodoAnterior
                End If
                Return
            End If
        End If

        Sb_Actualizar_Grilla_Treeview(nodoSeleccionado)

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

    'Sub Sb_Filtrar()

    '    Sb_Filtrar2()
    '    Return

    '    Try
    '        If IsNothing(_Dv) Then Return

    '        Sb_Actualizar_Grilla_Acciones(0)
    '        Txt_Descripcion.Text = String.Empty

    '        If Txt_Filtrar.Text.Contains(" ") Then
    '            Sb_Filtrar2()
    '            Return
    '        End If

    '        If Txt_Filtrar.Text.Contains("#") Then
    '            Txt_Filtrar.Text = Replace(Txt_Filtrar.Text, "#", "")
    '            Txt_Filtrar.Text = "#Tk" & numero_(Txt_Filtrar.Text, 7)
    '        End If

    '        If Chk_Filtro_Fcreacion.Checked Then

    '            If Txt_Filtrar.Text.ToLower = "dif-" Or Txt_Filtrar.Text = "-" Then
    '                _Dv.RowFilter = String.Format("Diferencia < 0 And (CONVERT(FechaCreacion, 'System.String') Like '{1}%' Or CONVERT(FechaCreacion, " &
    '                                              "'System.String') Like '{2}%')",
    '                                              Txt_Filtrar.Text.Trim,
    '                                              Dtp_Filtro_Fcreacion.Value.ToString("dd/MM/yyyy"),
    '                                              Dtp_Filtro_Fcreacion.Value.ToString("dd-MM-yyyy"))
    '            ElseIf Txt_Filtrar.Text.ToLower = "dif+" Or Txt_Filtrar.Text = "+" Then
    '                _Dv.RowFilter = String.Format("Diferencia > 0 And (CONVERT(FechaCreacion, 'System.String') Like '{1}%' Or CONVERT(FechaCreacion, " &
    '                                              "'System.String') Like '{2}%')",
    '                                              Txt_Filtrar.Text.Trim,
    '                                              Dtp_Filtro_Fcreacion.Value.ToString("dd/MM/yyyy"),
    '                                              Dtp_Filtro_Fcreacion.Value.ToString("dd-MM-yyyy"))
    '            Else
    '                _Dv.RowFilter = String.Format("Numero+Asunto+CONVERT(FechaCreacion, 'System.String')+NomFuncCrea+Codigo+DescripcionPr+Sucursal+Bodega+NomPrioridad " &
    '                                              "Like '%{0}%' And (CONVERT(FechaCreacion, 'System.String') Like '{1}%' Or CONVERT(FechaCreacion, 'System.String') Like '{2}%')",
    '                                              Txt_Filtrar.Text.Trim, Dtp_Filtro_Fcreacion.Value.ToString("dd/MM/yyyy"), Dtp_Filtro_Fcreacion.Value.ToString("dd-MM-yyyy"))
    '            End If

    '        Else

    '            If Txt_Filtrar.Text.ToLower = "dif-" Or Txt_Filtrar.Text = "-" Then
    '                _Dv.RowFilter = String.Format("Diferencia < 0", Txt_Filtrar.Text.Trim)
    '            ElseIf Txt_Filtrar.Text.ToLower = "dif+" Or Txt_Filtrar.Text = "+" Then
    '                _Dv.RowFilter = String.Format("Diferencia > 0", Txt_Filtrar.Text.Trim)
    '            Else
    '                _Dv.RowFilter = String.Format("Numero+Asunto+FechaCreacion+NomFuncCrea+Codigo+DescripcionPr+Sucursal+Bodega+NomPrioridad " &
    '                                              "Like '%{0}%'", Txt_Filtrar.Text.Trim)
    '            End If

    '        End If

    '        If Grilla.RowCount = 0 Then

    '            ToastNotification.Show(Me, "NO SE ENCONTRARON REGISTROS", My.Resources.delete,
    '                      2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

    '        End If

    '    Catch ex As Exception
    '        MessageBoxEx.Show(Me, ex.Message, "Cuek!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '    End Try
    'End Sub

    Sub Sb_Filtrar()
        Try
            If IsNothing(_Dv) Then Return

            Sb_Actualizar_Grilla_Acciones(0)
            Txt_Descripcion.Text = String.Empty

            Dim filtros As String() = Txt_Filtrar.Text.Trim().Split(" "c)
            Dim filtroFinal As String = String.Empty

            For Each filtro As String In filtros
                If Not String.IsNullOrWhiteSpace(filtro) Then
                    If Not String.IsNullOrEmpty(filtroFinal) Then
                        filtroFinal &= " AND "
                    End If

                    If filtro.ToLower = "dif-" Then
                        filtroFinal &= String.Format("Diferencia <0")
                    ElseIf filtro.ToLower = "dif+" Then
                        filtroFinal &= String.Format("Diferencia >0")
                    Else
                        filtroFinal &= String.Format("(Numero+Asunto+NomEstado+CONVERT(FechaCreacion, 
                        'System.String')+NomFuncCrea+Codigo+DescripcionPr+Sucursal_Pr+Bodega_Pr+NomPrioridad Like '%{0}%')", filtro)
                    End If

                End If
            Next

            If Chk_Filtro_FcreacionRango.Checked Then
                If Not String.IsNullOrEmpty(filtroFinal) Then
                    filtroFinal &= " AND "
                End If

                ' Ajuste: comparar solo la fecha, ignorando la hora
                filtroFinal &= String.Format("(
                    CONVERT(FechaCreacion, 'System.DateTime') >= #{0}# 
                    AND CONVERT(FechaCreacion, 'System.DateTime') < #{1}#
                )",
                    Dtp_Filtro_Fcreacion_Desde.Value.Date.ToString("MM/dd/yyyy"),
                    Dtp_Filtro_Fcreacion_Hasta.Value.Date.AddDays(1).ToString("MM/dd/yyyy"))
            End If

            _Dv.RowFilter = filtroFinal

            If Grilla.RowCount = 0 Then
                ToastNotification.Show(Me, "NO SE ENCONTRARON REGISTROS", My.Resources.delete,
                                          2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            End If

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
        Chk_Filtro_FcreacionRango.Checked = False
        If String.IsNullOrWhiteSpace(Txt_Filtrar.Text) Then
            Return
        End If
        Txt_Filtrar.Text = String.Empty
        Sb_Filtrar()
    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Excel.Click

        'RemoveHandler Grilla.CellFormatting, AddressOf Grilla_CellFormatting
        ExportarTabla_JetExcel_Tabla(_Tbl_Tickets, Me, "Tickets")
        'AddHandler Grilla.CellFormatting, AddressOf Grilla_CellFormatting

    End Sub

    Private Sub Btn_VerTicket_Click(sender As Object, e As EventArgs) Handles Btn_VerTicket.Click
        Call Grilla_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Btn_Mnu_Copiar_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Copiar.Click

        With Grilla

            Dim _Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
            Dim _Texto_Cabeza = .Columns(.CurrentCell.ColumnIndex).HeaderText

            Dim Copiar = .Rows(.CurrentRow.Index).Cells(_Cabeza).Value
            Clipboard.SetText(Copiar)

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

    Sub Sb_Actualizar_Grilla_Acciones(_Id_Raiz As Integer)

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
                       "Id_Ticket In (Select Id From " & _Global_BaseBk & "Zw_Stk_Tickets Where Id_Raiz = " & _Id_Raiz & ")" & vbCrLf &
                       "Order By Fecha -- Id_Ticket,Fecha"

        Dim _Tbl_Acciones As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla_Acciones

            .DataSource = _Tbl_Acciones

            OcultarEncabezadoGrilla(Grilla_Acciones, True)

            Dim _DisplayIndex = 0

            .Columns("Btn_ImagenUser").Width = 40
            .Columns("Btn_ImagenUser").HeaderText = "User"
            .Columns("Btn_ImagenUser").Visible = True
            '.Columns("Btn_ImagenUser").Frozen = True
            .Columns("Btn_ImagenUser").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SubNro").Visible = True
            .Columns("SubNro").HeaderText = "Sub"
            .Columns("SubNro").Width = 30
            .Columns("SubNro").Frozen = True
            .Columns("SubNro").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StrAccion").Visible = True
            .Columns("StrAccion").HeaderText = "Acción"
            .Columns("StrAccion").Width = 150
            .Columns("StrAccion").Frozen = True
            .Columns("StrAccion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CodFunGestiona").Visible = True
            .Columns("CodFunGestiona").HeaderText = "CF"
            .Columns("CodFunGestiona").Width = 30
            '.Columns("CodFunGestiona").Frozen = True
            .Columns("CodFunGestiona").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreFunAge").Visible = True
            .Columns("NombreFunAge").HeaderText = "De"
            .Columns("NombreFunAge").Width = 150
            '.Columns("NombreFunAge").Frozen = True
            .Columns("NombreFunAge").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Asunto").Visible = True
            .Columns("Asunto").HeaderText = "Asunto"
            .Columns("Asunto").Width = 240
            '.Columns("Asunto").Frozen = True
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

            .Columns("Descripcion").Width = 1500
            .Columns("Descripcion").HeaderText = "Descripción"
            '.Columns("Descripcion").ToolTipText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Dim _CodFunInicia As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Stk_Tickets", "CodFuncionario_Crea", "Id = " & _Id_Raiz)

        For Each _Fila As DataGridViewRow In Grilla_Acciones.Rows

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
            Grilla_Acciones.CurrentCell = Grilla_Acciones.Rows(Grilla_Acciones.RowCount - 1).Cells("StrAccion")
        Catch ex As Exception

        End Try

        Grilla_Acciones.Refresh()

    End Sub

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id_Raiz As Integer = _Fila.Cells("Id_Raiz").Value

        Sb_Actualizar_Grilla_Acciones(_Id_Raiz)

    End Sub

    Private Sub Grilla_Acciones_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Acciones.CellClick

        Dim _Fila As DataGridViewRow = Grilla_Acciones.CurrentRow

        Try

            Dim _Id_Ticket As Integer = _Fila.Cells("Id_Ticket").Value
            Dim _Id_TicketAc As Integer = _Fila.Cells("Id_Accion").Value
            Dim _Num_Attach As Integer = _Fila.Cells("Num_Attach").Value
            Dim _Producto_Attach As Integer = _Fila.Cells("Producto_Attach").Value
            Dim _Idmaeedo_Cierra As Integer = _Fila.Cells("Idmaeedo_Cierra").Value

            Dim _Cabeza = Grilla_Acciones.Columns(Grilla_Acciones.CurrentCell.ColumnIndex).Name

            If _Cabeza = "Btn_ImagenAttach" Or _Cabeza = "Btn_ProductoInfo" Or _Cabeza = "Btn_DocCierra" Then
                MessageBoxEx.Show(Me, "Para ver esta información debe ingregar al Ticket", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Btn_Filtrar_Click(sender As Object, e As EventArgs) Handles Btn_Filtrar.Click
        Sb_Filtrar()
    End Sub

    Private Sub Grilla_Acciones_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Acciones.CellEnter

        Try

            Dim _Fila As DataGridViewRow = Grilla_Acciones.CurrentRow
            Dim _NombreFunGestiona As String = _Fila.Cells("NombreFunGestiona").Value
            Dim _StrAccion As String = _Fila.Cells("StrAccion").Value
            Dim _Asunto As String = _Fila.Cells("Asunto").Value
            Txt_Descripcion.Text = _NombreFunGestiona & " " & _StrAccion.ToUpper & vbCrLf & "Asunto: " & _Asunto & vbCrLf & "Detalle: " & _Fila.Cells("Descripcion").Value
            Txt_Descripcion.Text = _Fila.Cells("Descripcion").Value
        Catch ex As Exception
            Txt_Descripcion.Text = String.Empty
        End Try

    End Sub

    Private Sub Tree_Bandeja_BeforeExpand(sender As Object, e As TreeViewCancelEventArgs) Handles Tree_Bandeja.BeforeExpand

        Dim nodoSeleccionado As TreeNode = e.Node

        If e.Node.Tag = "TODOS" Then

            If Fx_Tiene_Permiso(Me, "Tkts0007") Then Return
            e.Cancel = True

        End If

    End Sub

    Private Sub Tree_Bandeja_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles Tree_Bandeja.BeforeSelect
        _NodoAnterior = Tree_Bandeja.SelectedNode
        If _NodoAnterior IsNot Nothing Then
            ' Aquí el nodoAnterior está a punto de dejar de estar seleccionado
            'MessageBox.Show("Nodo que deja de estar seleccionado: " & _NodoAnterior.Text)
        End If
    End Sub

    Private Sub Chk_Filtro_FcreacionRango_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Filtro_FcreacionRango.CheckedChanged
        Dtp_Filtro_Fcreacion_Desde.Enabled = Chk_Filtro_FcreacionRango.Checked
        Dtp_Filtro_Fcreacion_Hasta.Enabled = Chk_Filtro_FcreacionRango.Checked
        Btn_Filtrar.Enabled = Chk_Filtro_FcreacionRango.Checked
        If Not Chk_Filtro_FcreacionRango.Checked Then
            Sb_Filtrar()
        End If
    End Sub
End Class
