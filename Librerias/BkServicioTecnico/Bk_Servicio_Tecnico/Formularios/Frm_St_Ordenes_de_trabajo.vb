'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Frm_St_Ordenes_de_trabajo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Tbl_OT As DataTable
    Dim _Correr_a_la_derecha As Boolean

    Dim _Id_Fila_Activa = Nothing

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_St_Ordenes_de_trabajo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'InsertarBotonenGrilla(Grilla, "BtnImagen", "Situación", "Solicitud", 0, _Tipo_Boton.Imagen)
        AddHandler Btn_Crear_OT.Click, AddressOf Sb_Crear_Nueva_OT

        'Sb_Actualizar_Grilla()
        Sb_Marcar_Grilla()

        If _Correr_a_la_derecha Then
            Me.Top += 30
            Me.Left += 30
        End If

        'Txt_Informacion.DataBindings.Add(New System.Windows.Forms.Binding("Text", _TblTecnicos, "Informacion", True))

    End Sub

#Region "PROCEMIENTOS"

    Sub Sb_Crear_Nueva_OT()
        If TienePermiso("Stec0002") Then
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

            Sb_Actualizar_Grilla()
            Sb_Marcar_Grilla()

        End If
    End Sub

#End Region

#Region "LISTAR DOCUMENTOS"

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String

        'A(ASIGNADO)
        'C(COTIZACION)
        'CE(CERRADO)
        'E(ENTREGADO)
        'F(FACTURADO / GDI)
        'I(INGRESADO)
        'N(NULA)
        'P(PRESUPUESTO)
        'R	REPARACION Y CIERRE
        'V(AVISO)

        Dim _Fecha As Date = FechaDelServidor()

        Dim Dia_1 As String = numero_(_Fecha.Day, 2)
        Dim Mes_1 As String = numero_(_Fecha.Month, 2)
        Dim Ano_1 As String = _Fecha.Year

        Dim _Filtro_Fecha = "Fecha_Cierre BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf & _
                            "And CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 23:59:59', 102)" & vbCrLf


        _Condicion = "Where CodEstado In ('A','C','E','F','I','P','R','V') Or (CodEstado In ('CE','N') And " & _Filtro_Fecha & ")"

        Consulta_sql = My.Resources.Recursos_Locales.SqlQuery_Lista_OT
        Consulta_sql = Replace(Consulta_sql, "#Db_BakApp#", _Global_BaseBk)

        Consulta_sql += vbCrLf & vbCrLf & _Condicion

        _Tbl_OT = _Sql.Fx_Get_Tablas(Consulta_sql)


    End Sub

    Sub Sb_Marcar_Grilla()

        With Grilla

            .DataSource = _Tbl_OT

            OcultarEncabezadoGrilla(Grilla, True)


            '.Columns("BtnImagen").Visible = True
            '.Columns("BtnImagen").HeaderText = "Situación"
            '.Columns("BtnImagen").Width = 50

            '.Columns("BtnVer").Visible = True
            '.Columns("BtnVer").HeaderText = "Situación"
            '.Columns("BtnVer").Width = 50

            .Columns("Nro_Ot").Visible = True
            .Columns("Nro_Ot").HeaderText = "Número OT"
            .Columns("Nro_Ot").Width = 80

            .Columns("Rut").Visible = True
            .Columns("Rut").HeaderText = "Rut"
            .Columns("Rut").Width = 80

            .Columns("Cliente").Visible = True
            .Columns("Cliente").HeaderText = "Cliente"
            .Columns("Cliente").Width = 300

            .Columns("Lugar").Visible = True
            .Columns("Lugar").HeaderText = "lugar"
            .Columns("Lugar").Width = 150

            .Columns("Fecha").Visible = True
            .Columns("Fecha").HeaderText = "Fecha"
            .Columns("Fecha").Width = 70

            .Columns("Hora").Visible = True
            .Columns("Hora").HeaderText = "Hora"
            .Columns("Hora").Width = 60
            .Columns("Hora").DefaultCellStyle.Format = "hh:mm:ss"

            .Columns("Estado").Visible = True
            .Columns("Estado").HeaderText = "Estado"
            .Columns("Estado").Width = 120

            .Columns("Maquina").Visible = True
            .Columns("Maquina").HeaderText = "Maquina"
            .Columns("Maquina").Width = 120

            .Columns("Marca").Visible = True
            .Columns("Marca").HeaderText = "Marca"
            .Columns("Marca").Width = 120

            .Columns("Modelo").Visible = True
            .Columns("Modelo").HeaderText = "Modelo"
            .Columns("Modelo").Width = 120

            .Columns("Categoria").Visible = True
            .Columns("Categoria").HeaderText = "Categoria"
            .Columns("Categoria").Width = 120


        End With

    End Sub

#End Region

#Region "EDITAR DOCUMENTO, HACER GESTION"

    Sub Sb_Abrir_Documento(ByVal _Fila As DataGridViewRow)

        Dim _Abrir_Documento As Boolean

        Dim _Id_Ot = _Fila.Cells("Id_Ot").Value

        Consulta_sql = My.Resources.Recursos_Locales.SqlQuery_Traer_OT
        Consulta_sql = Replace(Consulta_sql, "#Id_Ot#", _Id_Ot)
        Consulta_sql = Replace(Consulta_sql, "#Db_BakApp#", _Global_BaseBk)
        '#Id_Ot# #Db_BakApp#

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _DsDocumento As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)


        Dim Fm As New Frm_St_Documento(Frm_St_Documento.Accion.Editar)
        Fm.Pro_Id_Ot = _Id_Ot
        Fm.Pro_DsDocumento = _DsDocumento
        Fm.ShowDialog(Me)
        _Abrir_Documento = Fm.Pro_Abrir_Documeneto
        Fm.Dispose()

        Dim _CodEstado = _DsDocumento.Tables(0).Rows(0).Item("CodEstado") '_Sql.Fx_Trae_Dato(, "CodEstado", _Global_BaseBk & "Zw_St_OT_Encabezado", "Id_Ot = " & _Id_Ot)
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

    Sub Sb_Actualizar_Estados_De_La_Fila(ByVal _Fila_Dg As DataGridViewRow)

        Dim _Id_Ot = _Fila_Dg.Cells("Id_Ot").Value
        Dim _Tbl_Estado As DataTable

        Dim _CodEstado As String

        If Not _Fila_Dg.Cells("Chk_Flujo_Trabajo").Value Then

            Consulta_sql = "SELECT * FROM " & _Global_BaseBk & "Zw_St_OT_Estados" & Space(1) & _
                       "Where Id_Ot = " & _Id_Ot & Space(1) & _
                       "Order by Semilla"

            _Tbl_Estado = _Sql.Fx_Get_Tablas(Consulta_sql)


            Fx_Estados(Estado_01_Ingreso, "Ingresado", "...", "1ra Etapa", _
                                   Color.GreenYellow, Color.GreenYellow, 0)

            Fx_Estados(Estado_02_Asignar_Tecnico, "Asignar", "...", "2da Etapa", _
                                   Color.GreenYellow, Color.GreenYellow, 0)

            Fx_Estados(Estado_03_Presupuesto, "Presupuesto", "...", "3ra Etapa", _
                                   Color.GreenYellow, Color.GreenYellow, 0)

            Fx_Estados(Estado_04_Cotizacion, "Cotización", "...", "4ta Etapa", _
                                   Color.GreenYellow, Color.GreenYellow, 0)

            Fx_Estados(Estado_05_Reparacion_Cierre, "Reparación", "...", "5ta Etapa", _
                                   Color.GreenYellow, Color.GreenYellow, 0)

            Fx_Estados(Estado_06_Aviso, "Aviso", "...", "6ta Etapa", _
                                   Color.GreenYellow, Color.GreenYellow, 0)

            Fx_Estados(Estado_07_Entrega, "Entrega/Facturación", "...", "7ma Etapa", _
                                   Color.GreenYellow, Color.GreenYellow, 0)

            Fx_Estados(Estado_08_Cierre, "Cierre", "...", "8va Etapa", _
                                  Color.GreenYellow, Color.GreenYellow, 0)

            For Each _Fila As DataRow In _Tbl_Estado.Rows

                _CodEstado = _Fila.Item("CodEstado")

                Select Case _CodEstado
                    Case "I"
                        '_Row_Estado_1 = _Fila
                        Dim _Fecha As Date = _Fila.Item("Fecha_Fijacion")
                        Fx_Estados(Estado_01_Ingreso, "Ingresado", "Check_In", _
                                   "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate), _
                                   Color.GreenYellow, Color.GreenYellow, 100)

                    Case "A"
                        '_Row_Estado_2 = _Fila
                        Dim _Fecha As Date = _Fila.Item("Fecha_Fijacion")
                        Dim _Tecnico_Asignado = _Fila_Dg.Cells("Tecnico_Asignado").Value

                        Fx_Estados(Estado_02_Asignar_Tecnico, "Asignado", Trim(_Fila_Dg.Cells("Tecnico_Asignado").Value), _
                                   "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate), _
                                   Color.GreenYellow, Color.GreenYellow, 100)

                    Case "P"
                        '_Row_Estado_3 = _Fila
                        Dim _Fecha As Date = _Fila.Item("Fecha_Fijacion")
                        Fx_Estados(Estado_03_Presupuesto, "Presupuesto", "", _
                                   "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate), _
                                   Color.GreenYellow, Color.GreenYellow, 100)

                    Case "C"
                        '_Row_Estado_4 = _Fila
                        Dim _Fecha As Date = _Fila.Item("Fecha_Fijacion")
                        Fx_Estados(Estado_04_Cotizacion, "Cotizacion", "", _
                                   "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate), _
                                   Color.GreenYellow, Color.GreenYellow, 100)

                    Case "R"
                        '_Row_Estado_5 = _Fila
                        Dim _Fecha As Date = _Fila.Item("Fecha_Fijacion")
                        Dim _Tecnico_Repara = NuloPorNro(_Fila_Dg.Cells("Tecnico_Repara").Value, "")

                        Fx_Estados(Estado_05_Reparacion_Cierre, "Reparación", _Tecnico_Repara, _
                                   "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate), _
                                   Color.GreenYellow, Color.GreenYellow, 100)

                    Case "V"
                        '_Row_Estado_6 = _Fila
                        Dim _Fecha As Date = _Fila.Item("Fecha_Fijacion")
                        Fx_Estados(Estado_06_Aviso, "Aviso", "", _
                                   "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate), _
                                   Color.GreenYellow, Color.GreenYellow, 100)

                    Case "F"
                        ' _Row_Estado_7 = _Fila
                        Dim _Fecha As Date = _Fila.Item("Fecha_Fijacion")
                        Dim _Estado_Entrega = _Fila_Dg.Cells("Estado_Entrega").Value
                        Fx_Estados(Estado_07_Entrega, "Entrega y/o Facturación", _Estado_Entrega, _
                                   "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate), _
                                   Color.GreenYellow, Color.GreenYellow, 100)

                    Case "CE"
                        ' _Row_Estado_7 = _Fila
                        Dim _Fecha As Date = _Fila.Item("Fecha_Fijacion")
                        Fx_Estados(Estado_08_Cierre, "CERRADO", "", _
                                   "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate), _
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

            'Sb_Actualizar_Estados()

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

    Function Fx_Estados(ByVal _St_Etapa As StepItem, _
                       ByVal _Encabezado As String, _
                       ByVal _Espera As String, _
                       ByVal _Etapa As String, _
                       ByVal _Color_Arriba As Color, _
                       ByVal _Color_Abajo As Color, _
                       ByVal _Valor As Integer)

        Dim _Leyenda As String = "<font size=" & Chr(34) & "+2" & Chr(34) & "><b>" & _Encabezado & _
                              "</b></font><br/><font size=" & Chr(34) & "-1" & Chr(34) & ">" & _Espera & "<br/>" & _Etapa & "</font>"

        With _St_Etapa
            .Text = _Leyenda
            .Value = _Valor
            .TextColor = Color.Black
            .ProgressColors = New System.Drawing.Color() {_Color_Arriba, _Color_Abajo} '{Color.GreenYellow, Color.GreenYellow}
            .HotTracking = True
        End With

    End Function

    Private Sub Frm_St_Ordenes_de_trabajo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Sb_Abrir_Documento(_Fila)


    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        _Id_Fila_Activa = Nothing
        Sb_Actualizar_Grilla()
        Sb_Marcar_Grilla()
    End Sub

    Private Sub Grilla_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEnter

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        If _Id_Fila_Activa <> _Fila.Index Or (_Id_Fila_Activa Is Nothing) Then
            _Fila.Cells("Chk_Flujo_Trabajo").Value = False
            Sb_Actualizar_Estados_De_La_Fila(_Fila)
        End If
    End Sub

    Private Sub Btn_Mantencion_Tecnicos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mantencion_Tecnicos.Click
        Dim Fm As New Frm_St_Lista_Tecnicos_Talleres
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Buscar_OT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Buscar_OT.Click

        Dim _TblInforme As DataTable

        Dim Fm As New Frm_St_Filtrar_Ordenes_de_trabajo
        Fm.ShowDialog(Me)
        '_TblInforme = Fm.Pro_Tbl_Informe
        Fm.Dispose()

        Sb_Actualizar_Grilla()
        Sb_Marcar_Grilla()
        

    End Sub

    Public Property Pro_Tbl_Informe() As DataTable
        Get
            Return _Tbl_OT
        End Get
        Set(ByVal value As DataTable)

            If value Is Nothing Then
                Sb_Actualizar_Grilla()
            Else
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
        Set(ByVal value As Boolean)
            _Correr_a_la_derecha = value
        End Set
    End Property

   
   
    Private Sub Btn_Conf_Info_Reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Conf_Info_Reportes.Click
        If TienePermiso("Stec0015") Then
            Dim Fm As New Frm_St_Notas_Reportes
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Exportar_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar_Excel.Click

        If TienePermiso("Stec0018") Then
            ExportarTabla_JetExcel_Tabla(_Tbl_OT, Me, "Ordenes de Trabajo")
        End If

    End Sub

End Class