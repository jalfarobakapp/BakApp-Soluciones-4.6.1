'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
'Imports BkSpecialPrograms

Public Class Frm_St_Ordenes_de_trabajo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Ds As DataSet
    Dim _Tbl_OT As DataTable
    Dim _Correr_a_la_derecha As Boolean

    Dim _Id_Fila_Activa = Nothing

    Public Property Pro_Tbl_Informe() As DataTable
        Get
            Return _Tbl_OT
        End Get
        Set(value As DataTable)

            If value Is Nothing Then
                Sb_Actualizar_Grilla2()
            Else

                Super_TabS.Enabled = False

                _Tbl_OT = value
                Btn_Buscar_OT.Visible = False
                Btn_Crear_OT.Visible = False
                Btn_Mantencion_Tecnicos.Visible = False

                Me.Text = "Filtro de Ordendes de Trabajo"

            End If

        End Set
    End Property

    Public Property Pro_Correr_a_la_derecha() As Boolean
        Get

        End Get
        Set(value As Boolean)
            _Correr_a_la_derecha = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_SubOt, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Super_TabS.SelectedTabIndex = 0

        Me.Text += Space(1) & "SUCURSAL: " & ModSucursal & " " '& _Global_Row_Configuracion_Estacion

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_St_Ordenes_de_trabajo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'InsertarBotonenGrilla(Grilla, "BtnImagen", "Situación", "Solicitud", 0, _Tipo_Boton.Imagen)
        AddHandler Btn_Crear_OT1Producto.Click, AddressOf Sb_Crear_Nueva_OT

        Sb_Marcar_Grilla2()

        If _Correr_a_la_derecha Then
            Me.Top += 30
            Me.Left += 30
        End If

        AddHandler Tab_01_Todas.Click, AddressOf Sb_Actualizar_Grilla2
        AddHandler Tab_02_Ingresadas.Click, AddressOf Sb_Actualizar_Grilla2
        AddHandler Tab_03_Asignadas.Click, AddressOf Sb_Actualizar_Grilla2
        AddHandler Tab_04_Presupuesto.Click, AddressOf Sb_Actualizar_Grilla2
        AddHandler Tab_05_Preparacion.Click, AddressOf Sb_Actualizar_Grilla2
        AddHandler Tab_06_Aviso.Click, AddressOf Sb_Actualizar_Grilla2
        AddHandler Tab_07_Entregadas.Click, AddressOf Sb_Actualizar_Grilla2
        AddHandler Tab_08_Cerradas_Hoy.Click, AddressOf Sb_Actualizar_Grilla2

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_SubOt.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        'Txt_Informacion.DataBindings.Add(New System.Windows.Forms.Binding("Text", _TblTecnicos, "Informacion", True))

    End Sub

#Region "PROCEMIENTOS"

    Sub Sb_Crear_Nueva_OT()

        If Fx_Tiene_Permiso(Me, "Stec0002") Then

            Dim _RowEntidad As DataRow
            Dim Fm_Ent As New Frm_BuscarEntidad_Mt(False)
            Fm_Ent.Text = "SELECCIONE EL CLIENTE"
            Fm_Ent.ShowDialog(Me)

            If Fm_Ent.Pro_Entidad_Seleccionada Then
                _RowEntidad = Fm_Ent.Pro_RowEntidad
            Else
                Return
            End If
            Fm_Ent.Dispose()

            Dim Fm As New Frm_St_Documento(Frm_St_Documento.Accion.Nuevo)
            Fm.Pro_RowEntidad = _RowEntidad
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Sb_Actualizar_Grilla2()
            'Sb_Marcar_Grilla()

        End If

    End Sub

    Sub Sb_Crear_Nueva_OT_Varios_Productos()

        If Fx_Tiene_Permiso(Me, "Stec0002") Then

            Dim _RowEntidad As DataRow
            Dim Fm_Ent As New Frm_BuscarEntidad_Mt(False)
            Fm_Ent.Text = "SELECCIONE EL CLIENTE"
            Fm_Ent.ShowDialog(Me)

            If Fm_Ent.Pro_Entidad_Seleccionada Then
                _RowEntidad = Fm_Ent.Pro_RowEntidad
            Else
                Return
            End If
            Fm_Ent.Dispose()

            Dim _Bloqueada = _RowEntidad.Item("BLOQUEADO")

            If Not Fx_Entidad_Tiene_Deudas_CtaCte(Me, _RowEntidad, False, False, _Bloqueada) Then

                'If _Bloqueada Then Return Nothing

                MessageBoxEx.Show(Me, "La entidad presenta morosidad" & Environment.NewLine &
                                      "Está situación será evaluada nuevamente al grabar el documento",
                                      "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, Me.TopMost)

            End If

            Dim _Cl_OrdenServicio As Cl_OrdenServicio

            Dim Fm As New Frm_St_EncIngreso(_RowEntidad)
            Fm.ShowDialog(Me)
            _Cl_OrdenServicio = Fm.Cl_OrdenServicio
            Fm.Dispose()

            Sb_Actualizar_Grilla2()
            'Sb_Marcar_Grilla()

        End If

    End Sub

#End Region

#Region "LISTAR DOCUMENTOS"

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String

        'A  - ASIGNADO
        'C  - COTIZACION
        'CE - CERRADO 
        'E  - ENTREGADO
        'F  - FACTURADO / GDI
        'I  - INGRESADO
        'N  - NULA
        'P  - PRESUPUESTO 
        'R	- REPARACION Y CIERRE
        'V(AVISO)

        'Dim Fm_Espera As New Frm_Form_Esperar
        'Fm_Espera.BarraCircular.IsRunning = True
        'Fm_Espera.Show()

        Dim _Fecha As Date = FechaDelServidor()

        Dim Dia_1 As String = numero_(_Fecha.Day, 2)
        Dim Mes_1 As String = numero_(_Fecha.Month, 2)
        Dim Ano_1 As String = _Fecha.Year

        Dim _Filtro_Fecha = "Fecha_Cierre BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf &
                            "And CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 23:59:59', 102)" & vbCrLf

        Select Case Super_TabS.SelectedTabIndex

            Case 0 ' Todas
                GroupPanel1.Text = "Todas las ordenes de trabajo activas"
                _Condicion = "And (CodEstado In ('A','C','E','F','I','P','R','V') Or (CodEstado In ('CE','N') And " & _Filtro_Fecha & "))" & vbCrLf
            Case 1 ' Ingresadas
                GroupPanel1.Text = "Ordenes de trabajo Ingresadas, en espera de asignación a algún técnico."
                _Condicion = "And CodEstado In ('I')" & vbCrLf
            Case 2 ' Asignadas tecnico
                GroupPanel1.Text = "Ordenes de trabajo asignadas a algún técnico, a la espera de una evaluación."
                _Condicion = "And CodEstado In ('A')" & vbCrLf
            Case 3 ' Presupuesto
                GroupPanel1.Text = "Ordenes de trabajo con evaluación realizada por el técnico, presupuesto o cotización creadas"
                _Condicion = "And CodEstado In ('P')" & vbCrLf
            Case 4 ' En Reparacion
                GroupPanel1.Text = "Ordenes de trabajo en reparación"
                _Condicion = "And CodEstado In ('R')" & vbCrLf
            Case 5 ' Aviso cliente
                GroupPanel1.Text = "Todas las ordenes de trabajo reparadas en espera de aviso al cliente"
                _Condicion = "And CodEstado In ('V')" & vbCrLf
            Case 6 ' Entregadas
                GroupPanel1.Text = "Ordenes de trabajo entregadas con factura o guía"
                _Condicion = "And CodEstado In ('E','F')" & vbCrLf
            Case 7 ' Cerradas hoy
                GroupPanel1.Text = "Ordenes de trabajo cerradas hoy"
                _Condicion = "And CodEstado In ('CE') And " & _Filtro_Fecha & vbCrLf

        End Select

        _Condicion += "And Empresa = '" & ModEmpresa & "' And Sucursal = '" & ModSucursal & "'" & vbCrLf

        Consulta_Sql = My.Resources.Recursos_Locales.SqlQuery_Lista_OT
        Consulta_Sql = Replace(Consulta_Sql, "#Db_BakApp#", _Global_BaseBk)
        Consulta_Sql = Replace(Consulta_Sql, "#Condicion#", _Condicion)

        _Tbl_OT = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Sb_Marcar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla2()

        Me.Cursor = Cursors.WaitCursor

        Dim _Condicion As String

        'A  - ASIGNADO
        'C  - COTIZACION
        'CE - CERRADO 
        'E  - ENTREGADO
        'F  - FACTURADO / GDI
        'I  - INGRESADO
        'N  - NULA
        'P  - PRESUPUESTO 
        'R	- REPARACION Y CIERRE
        'V(AVISO)

        'Dim Fm_Espera As New Frm_Form_Esperar
        'Fm_Espera.BarraCircular.IsRunning = True
        'Fm_Espera.Show()

        Dim _Fecha As Date = FechaDelServidor()

        Dim Dia_1 As String = numero_(_Fecha.Day, 2)
        Dim Mes_1 As String = numero_(_Fecha.Month, 2)
        Dim Ano_1 As String = _Fecha.Year

        Dim _Filtro_Fecha = "Fecha_Cierre BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf &
                            "And CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 23:59:59', 102)" & vbCrLf

        Select Case Super_TabS.SelectedTabIndex

            Case 0 ' Todas
                GroupPanel1.Text = "Todas las ordenes de trabajo activas"
                _Condicion = "And (CodEstado In ('A','C','E','F','I','P','R','V') Or (CodEstado In ('CE','N') And " & _Filtro_Fecha & "))" & vbCrLf
            Case 1 ' Ingresadas
                GroupPanel1.Text = "Ordenes de trabajo Ingresadas, en espera de asignación a algún técnico."
                _Condicion = "And CodEstado In ('I')" & vbCrLf
            Case 2 ' Asignadas tecnico
                GroupPanel1.Text = "Ordenes de trabajo asignadas a algún técnico, a la espera de una evaluación."
                _Condicion = "And CodEstado In ('A')" & vbCrLf
            Case 3 ' Presupuesto
                GroupPanel1.Text = "Ordenes de trabajo con evaluación realizada por el técnico, presupuesto o cotización creadas"
                _Condicion = "And CodEstado In ('P')" & vbCrLf
            Case 4 ' En Reparacion
                GroupPanel1.Text = "Ordenes de trabajo en reparación"
                _Condicion = "And CodEstado In ('R')" & vbCrLf
            Case 5 ' Aviso cliente
                GroupPanel1.Text = "Todas las ordenes de trabajo reparadas en espera de aviso al cliente"
                _Condicion = "And CodEstado In ('V')" & vbCrLf
            Case 6 ' Entregadas
                GroupPanel1.Text = "Ordenes de trabajo entregadas con factura o guía"
                _Condicion = "And CodEstado In ('E','F')" & vbCrLf
            Case 7 ' Cerradas hoy
                GroupPanel1.Text = "Ordenes de trabajo cerradas hoy"
                _Condicion = "And CodEstado In ('CE') And " & _Filtro_Fecha & vbCrLf

        End Select

        _Condicion += "And Empresa = '" & ModEmpresa & "' And Sucursal = '" & ModSucursal & "'" & vbCrLf

        Consulta_Sql = My.Resources.Recursos_Locales.SqlQuery_Lista_OT2
        Consulta_Sql = Replace(Consulta_Sql, "#Db_BakApp#", _Global_BaseBk)
        Consulta_Sql = Replace(Consulta_Sql, "#Condicion#", _Condicion)


        _Ds = _Sql.Fx_Get_DataSet(Consulta_Sql)

        ' Agregar la relación ( campo en común : campo_Relacionado = idCliente )  
        ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  
        ' Table.Rel_Entidad_Documentos.Rel_Documentos_Detalle

        _Ds.Relations.Add("Ot_SubOt",
                             _Ds.Tables("Table").Columns("Id_Ot_Padre"),
                             _Ds.Tables("Table1").Columns("Id_Ot_Padre"), False)

        Grilla.DataSource = _Ds
        Grilla.DataMember = "Table"

        Grilla_SubOt.DataSource = _Ds
        Grilla_SubOt.DataMember = "Table.Ot_SubOt"

        OcultarEncabezadoGrilla(Grilla, True)
        OcultarEncabezadoGrilla(Grilla_SubOt, True)

        Sb_Marcar_Grilla2()

        Me.Cursor = Cursors.Default

    End Sub

    Sub Sb_Marcar_Grilla()
        Return
        With Grilla

            .DataSource = _Tbl_OT

            Dim _Mas = 0

            If Super_TabS.SelectedTabIndex <> 0 Then
                _Mas = 120
            End If

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Nro_Ot").Visible = True
            .Columns("Nro_Ot").HeaderText = "Número OT"
            .Columns("Nro_Ot").Width = 80
            .Columns("Nro_Ot").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sub_Ot").Visible = True
            .Columns("Sub_Ot").HeaderText = "Sub OT"
            .Columns("Sub_Ot").Width = 30
            .Columns("Sub_Ot").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Rut").Visible = True
            .Columns("Rut").HeaderText = "Rut"
            .Columns("Rut").Width = 80
            .Columns("Rut").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SucEntidad").Visible = True
            .Columns("SucEntidad").HeaderText = "Suc."
            .Columns("SucEntidad").Width = 60
            .Columns("SucEntidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Cliente").Visible = True
            .Columns("Cliente").HeaderText = "Cliente"
            .Columns("Cliente").Width = 240
            .Columns("Cliente").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Lugar").Visible = True
            .Columns("Lugar").HeaderText = "lugar"
            .Columns("Lugar").Width = 50
            .Columns("Lugar").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha").Visible = True
            .Columns("Fecha").HeaderText = "Fecha"
            .Columns("Fecha").Width = 70
            .Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Hora").Visible = True
            .Columns("Hora").HeaderText = "Hora"
            .Columns("Hora").Width = 50
            .Columns("Hora").DefaultCellStyle.Format = "hh:mm"
            .Columns("Hora").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Hora").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Dias").Visible = True
            .Columns("Dias").HeaderText = "Dias"
            .Columns("Dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Dias").DefaultCellStyle.Format = "###,##"
            .Columns("Dias").Width = 40
            .Columns("Dias").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Estado").Visible = (Super_TabS.SelectedTabIndex = 0)
            .Columns("Estado").HeaderText = "Estado"
            .Columns("Estado").Width = 120
            .Columns("Estado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Producto").Visible = True
            .Columns("Producto").HeaderText = "Producto"
            .Columns("Producto").Width = 250 + _Mas - 30
            .Columns("Producto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        If CBool(Grilla.RowCount) Then
            Grilla.FirstDisplayedScrollingRowIndex = Grilla.RowCount - 1
            Grilla.CurrentCell = Grilla.Rows(Grilla.RowCount - 1).Cells("Nro_Ot")
        End If

        Me.Refresh()

    End Sub

    Sub Sb_Marcar_Grilla2()

        With Grilla

            Dim _Mas = 0

            If Super_TabS.SelectedTabIndex <> 0 Then
                _Mas = 120
            End If

            Dim _DisplayIndex = 0

            .Columns("Nro_Ot").Visible = True
            .Columns("Nro_Ot").HeaderText = "Número OT"
            .Columns("Nro_Ot").Width = 80
            .Columns("Nro_Ot").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Sub_Ot").Visible = True
            '.Columns("Sub_Ot").HeaderText = "Sub OT"
            '.Columns("Sub_Ot").Width = 30
            '.Columns("Sub_Ot").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Rut").Visible = True
            .Columns("Rut").HeaderText = "Rut"
            .Columns("Rut").Width = 80
            .Columns("Rut").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SucEntidad").Visible = True
            .Columns("SucEntidad").HeaderText = "Suc."
            .Columns("SucEntidad").Width = 60
            .Columns("SucEntidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Cliente").Visible = True
            .Columns("Cliente").HeaderText = "Cliente"
            .Columns("Cliente").Width = 490
            .Columns("Cliente").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Lugar").Visible = True
            .Columns("Lugar").HeaderText = "lugar"
            .Columns("Lugar").Width = 50
            .Columns("Lugar").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha").Visible = True
            .Columns("Fecha").HeaderText = "Fecha"
            .Columns("Fecha").Width = 70
            .Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Hora").Visible = True
            '.Columns("Hora").HeaderText = "Hora"
            '.Columns("Hora").Width = 50
            '.Columns("Hora").DefaultCellStyle.Format = "hh:mm"
            '.Columns("Hora").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("Hora").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Dias").Visible = True
            .Columns("Dias").HeaderText = "Dias"
            .Columns("Dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Dias").DefaultCellStyle.Format = "###,##"
            .Columns("Dias").Width = 40
            .Columns("Dias").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Estado").Visible = (Super_TabS.SelectedTabIndex = 0)
            '.Columns("Estado").HeaderText = "Estado"
            '.Columns("Estado").Width = 120
            '.Columns("Estado").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Producto").Visible = True
            '.Columns("Producto").HeaderText = "Producto"
            '.Columns("Producto").Width = 250 + _Mas - 30
            '.Columns("Producto").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

        End With

        With Grilla_SubOt

            Dim _Mas = 0

            If Super_TabS.SelectedTabIndex <> 0 Then
                _Mas = 120
            End If

            Dim _DisplayIndex = 0

            .Columns("Nro_Ot").Visible = True
            .Columns("Nro_Ot").HeaderText = "Número OT"
            .Columns("Nro_Ot").Width = 80
            .Columns("Nro_Ot").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sub_Ot").Visible = True
            .Columns("Sub_Ot").HeaderText = "Sub OT"
            .Columns("Sub_Ot").Width = 30
            .Columns("Sub_Ot").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Producto").Visible = True
            .Columns("Producto").HeaderText = "Producto"
            .Columns("Producto").Width = 480 + _Mas
            .Columns("Producto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha").Visible = True
            .Columns("Fecha").HeaderText = "Fecha"
            .Columns("Fecha").Width = 70
            .Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Hora").Visible = True
            .Columns("Hora").HeaderText = "Hora"
            .Columns("Hora").Width = 50
            .Columns("Hora").DefaultCellStyle.Format = "hh:mm"
            .Columns("Hora").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Hora").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Dias").Visible = True
            .Columns("Dias").HeaderText = "Dias"
            .Columns("Dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Dias").DefaultCellStyle.Format = "###,##"
            .Columns("Dias").Width = 40
            .Columns("Dias").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Estado").Visible = (Super_TabS.SelectedTabIndex = 0)
            .Columns("Estado").HeaderText = "Estado"
            .Columns("Estado").Width = 120
            .Columns("Estado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1



        End With

        If CBool(Grilla_SubOt.RowCount) Then
            Grilla_SubOt.FirstDisplayedScrollingRowIndex = Grilla_SubOt.RowCount - 1
            Grilla_SubOt.CurrentCell = Grilla_SubOt.Rows(Grilla_SubOt.RowCount - 1).Cells("Nro_Ot")
        End If

        Me.Refresh()

    End Sub

#End Region

#Region "EDITAR DOCUMENTO, HACER GESTION"

    Sub Sb_Abrir_Documento(_Fila As DataGridViewRow)

        Dim _Abrir_Documento As Boolean

        Dim _Id_Ot = _Fila.Cells("Id_Ot").Value
        Dim _Id_Ot_Padre = _Fila.Cells("Id_Ot_Padre").Value

        Consulta_Sql = My.Resources.Recursos_Locales.SqlQuery_Traer_OT
        Consulta_Sql = Replace(Consulta_Sql, "#Id_Ot#", _Id_Ot)
        Consulta_Sql = Replace(Consulta_Sql, "#Db_BakApp#", _Global_BaseBk)
        '#Id_Ot# #Db_BakApp#

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _DsDocumento As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql)

        Dim Fm As New Frm_St_Documento(Frm_St_Documento.Accion.Editar)
        Fm.Id_Ot = _Id_Ot
        Fm.Id_Ot_Padre = _Id_Ot_Padre
        Fm.Pro_DsDocumento = _DsDocumento
        Fm.ShowDialog(Me)
        _Abrir_Documento = Fm.Pro_Abrir_Documeneto
        Fm.Dispose()

        Dim _CodEstado = _DsDocumento.Tables(0).Rows(0).Item("CodEstado")
        Dim _Estado = _DsDocumento.Tables(0).Rows(0).Item("Estado")
        Dim _CodTecnico_Asignado = _DsDocumento.Tables(0).Rows(0).Item("CodTecnico_Asignado")
        Dim _Tecnico_Asignado = _DsDocumento.Tables(0).Rows(0).Item("Tecnico_Asignado")
        Dim _CodTecnico_Repara = _DsDocumento.Tables(0).Rows(0).Item("CodTecnico_Repara")
        Dim _Tecnico_Repara = _DsDocumento.Tables(0).Rows(0).Item("Tecnico_Repara")

        Dim _Estado_Entrega = _DsDocumento.Tables(0).Rows(0).Item("Estado_Entrega")

        _Fila.Cells("CodEstado").Value = _CodEstado
        _Fila.Cells("Estado").Value = _Estado
        _Fila.Cells("CodTecnico_Asignado").Value = _CodTecnico_Asignado
        _Fila.Cells("Tecnico_Asignado").Value = _Tecnico_Asignado

        _Fila.Cells("CodTecnico_Repara").Value = _CodTecnico_Repara
        _Fila.Cells("Tecnico_Repara").Value = _Tecnico_Repara

        _Fila.Cells("Estado_Entrega").Value = _Estado_Entrega

        _Fila.Cells("Chk_Flujo_Trabajo").Value = False
        Sb_Actualizar_Estados_De_La_Fila(_Fila)

        If _Abrir_Documento Then
            Sb_Abrir_Documento(_Fila)
        End If


    End Sub

#End Region

    Sub Sb_Actualizar_Estados_De_La_Fila(_Fila_Dg As DataGridViewRow)

        Dim _Id_Ot = _Fila_Dg.Cells("Id_Ot").Value
        Dim _Tbl_Estado As DataTable

        Dim _CodEstado As String

        If Not _Fila_Dg.Cells("Chk_Flujo_Trabajo").Value Then

            Consulta_Sql = "SELECT * FROM " & _Global_BaseBk & "Zw_St_OT_Estados" & Space(1) &
                       "Where Id_Ot = " & _Id_Ot & Space(1) &
                       "Order by Semilla"

            _Tbl_Estado = _Sql.Fx_Get_Tablas(Consulta_Sql)


            Fx_Estados(Estado_01_Ingreso, "Ingresado", "...", "1ra Etapa",
                                   Color.GreenYellow, Color.GreenYellow, 0)

            Fx_Estados(Estado_02_Asignar_Tecnico, "Asignar", "...", "2da Etapa",
                                   Color.GreenYellow, Color.GreenYellow, 0)

            Fx_Estados(Estado_03_Presupuesto, "Presupuesto", "...", "3ra Etapa",
                                   Color.GreenYellow, Color.GreenYellow, 0)

            Fx_Estados(Estado_04_Cotizacion, "Cotización", "...", "4ta Etapa",
                                   Color.GreenYellow, Color.GreenYellow, 0)

            Fx_Estados(Estado_05_Reparacion_Cierre, "Reparación", "...", "5ta Etapa",
                                   Color.GreenYellow, Color.GreenYellow, 0)

            Fx_Estados(Estado_06_Aviso, "Aviso", "...", "6ta Etapa",
                                   Color.GreenYellow, Color.GreenYellow, 0)

            Fx_Estados(Estado_07_Entrega, "Entrega/Facturación", "...", "7ma Etapa",
                                   Color.GreenYellow, Color.GreenYellow, 0)

            Fx_Estados(Estado_08_Cierre, "Cierre", "...", "8va Etapa",
                                  Color.GreenYellow, Color.GreenYellow, 0)

            For Each _Fila As DataRow In _Tbl_Estado.Rows

                _CodEstado = _Fila.Item("CodEstado")

                Select Case _CodEstado
                    Case "I"
                        '_Row_Estado_1 = _Fila
                        Dim _Fecha As Date = _Fila.Item("Fecha_Fijacion")
                        Fx_Estados(Estado_01_Ingreso, "Ingresado", "Check_In",
                                   "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                                   Color.GreenYellow, Color.GreenYellow, 100)

                    Case "A"
                        '_Row_Estado_2 = _Fila
                        Dim _Fecha As Date = _Fila.Item("Fecha_Fijacion")
                        Dim _Tecnico_Asignado As String

                        Try
                            _Tecnico_Asignado = _Fila_Dg.Cells("Tecnico_Asignado").Value
                        Catch ex As Exception
                            _Tecnico_Asignado = String.Empty
                        End Try

                        Fx_Estados(Estado_02_Asignar_Tecnico, "Asignado", _Tecnico_Asignado.Trim,
                                   "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                                   Color.GreenYellow, Color.GreenYellow, 100)

                    Case "P"
                        '_Row_Estado_3 = _Fila
                        Dim _Fecha As Date = _Fila.Item("Fecha_Fijacion")
                        Fx_Estados(Estado_03_Presupuesto, "Presupuesto", "",
                                   "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                                   Color.GreenYellow, Color.GreenYellow, 100)

                    Case "C"
                        '_Row_Estado_4 = _Fila
                        Dim _Fecha As Date = _Fila.Item("Fecha_Fijacion")
                        Fx_Estados(Estado_04_Cotizacion, "Cotizacion", "",
                                   "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                                   Color.GreenYellow, Color.GreenYellow, 100)

                    Case "R"
                        '_Row_Estado_5 = _Fila
                        Dim _Fecha As Date = _Fila.Item("Fecha_Fijacion")
                        Dim _Tecnico_Repara = NuloPorNro(_Fila_Dg.Cells("Tecnico_Repara").Value, "")

                        Fx_Estados(Estado_05_Reparacion_Cierre, "Reparación", _Tecnico_Repara,
                                   "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                                   Color.GreenYellow, Color.GreenYellow, 100)

                    Case "V"
                        '_Row_Estado_6 = _Fila
                        Dim _Fecha As Date = _Fila.Item("Fecha_Fijacion")
                        Fx_Estados(Estado_06_Aviso, "Aviso", "",
                                   "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                                   Color.GreenYellow, Color.GreenYellow, 100)

                    Case "F"
                        ' _Row_Estado_7 = _Fila
                        Dim _Fecha As Date = _Fila.Item("Fecha_Fijacion")
                        Dim _Estado_Entrega = _Fila_Dg.Cells("Estado_Entrega").Value
                        Fx_Estados(Estado_07_Entrega, "Entrega y/o Facturación", _Estado_Entrega,
                                   "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                                   Color.GreenYellow, Color.GreenYellow, 100)

                    Case "CE"
                        ' _Row_Estado_7 = _Fila
                        Dim _Fecha As Date = _Fila.Item("Fecha_Fijacion")
                        Fx_Estados(Estado_08_Cierre, "CERRADO", "",
                                   "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                                   Color.GreenYellow, Color.GreenYellow, 100)



                End Select

            Next

            _Fila_Dg.Cells("Chk_Flujo_Trabajo").Value = True
            _Id_Fila_Activa = _Fila_Dg.Index


            _CodEstado = Trim(_Fila_Dg.Cells("CodEstado").Value)
            Dim _Proximo_Estado As StepItem
            Dim _Info_Estado_A_Realizar As String

            Select Case _CodEstado
                Case "I"

                    _Info_Estado_A_Realizar = "Asignar un técnico / taller para la realización del presupuesto"
                    _Proximo_Estado = Estado_02_Asignar_Tecnico

                Case "A"

                    _Info_Estado_A_Realizar = "Generar el presupuesto"
                    _Proximo_Estado = Estado_03_Presupuesto

                Case "P"

                    _Info_Estado_A_Realizar = "Generar Cotización. (Importar desde el sistema)"
                    _Proximo_Estado = Estado_04_Cotizacion

                Case "C"

                    _Info_Estado_A_Realizar = "Reparación y  Cierre..."
                    _Proximo_Estado = Estado_05_Reparacion_Cierre

                Case "R"

                    _Info_Estado_A_Realizar = "Reparación y  Cierre..."
                    _Proximo_Estado = Estado_05_Reparacion_Cierre

                Case "V"

                    _Info_Estado_A_Realizar = "Aviso al cliente..."
                    _Proximo_Estado = Estado_06_Aviso

                Case "F"

                    _Info_Estado_A_Realizar = "Entrega y/o Facturación"
                    _Proximo_Estado = Estado_07_Entrega

                Case "E"

                    _Info_Estado_A_Realizar = String.Empty '"Entrega y/o Facturación"
                    _Proximo_Estado = Estado_08_Cierre

                Case "CE"

                    _Info_Estado_A_Realizar = String.Empty '"Entrega y/o Facturación"
                    _Proximo_Estado = Nothing

                Case Else

                    _Proximo_Estado = Nothing 'Estado_01_Ingreso

            End Select

            If Not (_Proximo_Estado Is Nothing) Then

                _Proximo_Estado.Text = Replace(_Proximo_Estado.Text, "...", "Espera...")
                _Proximo_Estado.TextColor = Color.Black
                _Proximo_Estado.ProgressColors = New System.Drawing.Color() {Color.Yellow, Color.Yellow} '{Color.GreenYellow, Color.GreenYellow}
                _Proximo_Estado.Value = 100
                _Proximo_Estado.HotTracking = True

            End If

        End If

        Me.Refresh()

    End Sub

    Function Fx_Estados(_St_Etapa As StepItem,
                        _Encabezado As String,
                        _Espera As String,
                        _Etapa As String,
                        _Color_Arriba As Color,
                        _Color_Abajo As Color,
                        _Valor As Integer)

        Dim _Leyenda As String = "<font size=" & Chr(34) & "+2" & Chr(34) & "><b>" & _Encabezado &
                              "</b></font><br/><font size=" & Chr(34) & "-1" & Chr(34) & ">" & _Espera & "<br/>" & _Etapa & "</font>"

        With _St_Etapa
            .Text = _Leyenda
            .Value = _Valor
            .TextColor = Color.Black
            If _Valor = 0 Then
                If Global_Thema = Enum_Themas.Oscuro Then .TextColor = Color.White
            End If
            .ProgressColors = New System.Drawing.Color() {_Color_Arriba, _Color_Abajo} '{Color.GreenYellow, Color.GreenYellow}
            .HotTracking = True
        End With

    End Function

    Private Sub Frm_St_Ordenes_de_trabajo_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Return
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Sb_Abrir_Documento(_Fila)

    End Sub

    Private Sub BtnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles BtnActualizar.Click
        _Id_Fila_Activa = Nothing
        Sb_Actualizar_Grilla2()
        'Sb_Marcar_Grilla()
    End Sub

    Private Sub Grilla_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEnter

        Dim _Fila As DataGridViewRow = Grilla_SubOt.Rows(0)

        'If _Id_Fila_Activa <> _Fila.Index Or (_Id_Fila_Activa Is Nothing) Then
        '_Fila.Cells("Chk_Flujo_Trabajo").Value = False
        Sb_Actualizar_Estados_De_La_Fila(_Fila)
        'End If

    End Sub

    Private Sub Btn_Mantencion_Tecnicos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mantencion_Tecnicos.Click
        Dim Fm As New Frm_St_Lista_Tecnicos_Talleres
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Buscar_OT_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Buscar_OT.Click

        Dim _TblInforme As DataTable

        Dim Fm As New Frm_St_Filtrar_Ordenes_de_trabajo
        Fm.ShowDialog(Me)
        '_TblInforme = Fm.Pro_Tbl_Informe
        Fm.Dispose()

        Sb_Actualizar_Grilla2()
        'Sb_Marcar_Grilla()


    End Sub

    Private Sub Btn_Conf_Info_Reportes_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Conf_Info_Reportes.Click
        If Fx_Tiene_Permiso(Me, "Stec0015") Then
            Dim Fm As New Frm_St_Notas_Reportes
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Exportar_Excel.Click

        If Fx_Tiene_Permiso(Me, "Stec0018") Then
            ExportarTabla_JetExcel_Tabla(_Tbl_OT, Me, "Ordenes de Trabajo")
        End If

    End Sub

    Private Sub Btn_Crear_OT_Click(sender As Object, e As EventArgs) Handles Btn_Crear_OT.Click

        Dim _ServTecnico_Empresa As String = _Global_Row_Configuracion_Estacion.Item("ServTecnico_Empresa").ToString.Trim
        Dim _ServTecnico_Sucursal As String = _Global_Row_Configuracion_Estacion.Item("ServTecnico_Sucursal").ToString.Trim
        Dim _ServTecnico_Bodega As String = _Global_Row_Configuracion_Estacion.Item("ServTecnico_Bodega").ToString.Trim

        If String.IsNullOrEmpty(_ServTecnico_Empresa) Or
               String.IsNullOrEmpty(_ServTecnico_Sucursal) Or
               String.IsNullOrEmpty(_ServTecnico_Bodega) Then
            MessageBoxEx.Show(Me, "Faltan los datos de la configuración del ingreso de mercadería" & vbCrLf &
                                  "para servicio tecnico en la modalidad: " & Modalidad, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        ShowContextMenu(Menu_Contextual_Garantia)

    End Sub

    Private Sub Btn_Crear_OTVariosProductos_Click(sender As Object, e As EventArgs) Handles Btn_Crear_OTVariosProductos.Click
        Sb_Crear_Nueva_OT_Varios_Productos()
    End Sub

    Private Sub Btn_Recetas_Click(sender As Object, e As EventArgs) Handles Btn_Recetas.Click

        Dim Fm As New Frm_St_Recetas
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Operaciones_Click(sender As Object, e As EventArgs) Handles Btn_Operaciones.Click

        Dim Fm As New Frm_St_Operaciones
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Grilla_SubOt_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_SubOt.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_SubOt.Rows(Grilla_SubOt.CurrentRow.Index)
        Sb_Abrir_Documento(_Fila)

    End Sub

    Private Sub Grilla_SubOt_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_SubOt.CellEnter

        Try
            Dim _Fila As DataGridViewRow = Grilla_SubOt.Rows(Grilla_SubOt.CurrentRow.Index)

            'If _Id_Fila_Activa <> _Fila.Index Or (_Id_Fila_Activa Is Nothing) Then
            _Fila.Cells("Chk_Flujo_Trabajo").Value = False
            Sb_Actualizar_Estados_De_La_Fila(_Fila)
            'End If
        Catch ex As Exception

        End Try

    End Sub

End Class
