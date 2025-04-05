Imports DevComponents.DotNetBar

Public Class Frm_Stmp_ListadoXRutas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Tickets_Stem As DataTable
    Dim _FechaServidor As DateTime

    Dim _Dv As New DataView

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 22, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, True, False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Stmp_ListadoXRutas_Load(sender As Object, e As EventArgs) Handles Me.Load

        _FechaServidor = FechaDelServidor()

        Dtp_FechaDesde.Value = Now.Date
        Dtp_FechaHasta.Value = Now.Date

        Dim _Arr_Tipo_Entidad(,) As String = {{"Fecha_Facturar", "F.Despacho/Facturar"},
                                             {"FechaCreacion", "F.Creación"}}
        Sb_Llenar_Combos(_Arr_Tipo_Entidad, Cmb_FiltroFecha)
        Cmb_FiltroFecha.SelectedValue = "Fecha_Facturar"

        Sb_InsertarBotonenGrilla(Grilla, "BtnImagen_Estado", "Est.", "Img_Estado", 0, _Tipo_Boton.Imagen)

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

        AddHandler Tab_Preparacion.Click, AddressOf Sb_Actualizar_Grilla
        AddHandler Tab_Ingresadas.Click, AddressOf Sb_Actualizar_Grilla
        AddHandler Tab_Completadas.Click, AddressOf Sb_Actualizar_Grilla
        AddHandler Tab_Facturadas.Click, AddressOf Sb_Actualizar_Grilla
        AddHandler Tab_Todas.Click, AddressOf Sb_Actualizar_Grilla

        'AddHandler Grilla.ColumnHeaderMouseClick, AddressOf Grilla_ColumnHeaderMouseClick

        Super_TabS.SelectedTabIndex = 0

        Sb_Actualizar_Grilla()

        'Timer_Monitoreo.Interval = 1000 * 5

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stmp_Enc Where Estado = 'COMPL' And Facturar = 1 --And ProblemaFac = 0"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        For Each _Fl As DataRow In _Tbl.Rows

            Dim _Id As Integer = _Fl.Item("Id")
            Dim _Idmaeedo As Integer = _Fl.Item("Idmaeedo")

            Consulta_sql = "Select Top 1 e.IDMAEEDO,e.TIDO,e.NUDO,e.FEEMDO,e.LAHORA" & vbCrLf &
                           "From MAEEDO e" & vbCrLf &
                           "Inner Join MAEDDO d on e.IDMAEEDO = d.IDMAEEDO" & vbCrLf &
                           "Where d.IDRST In (Select IDMAEDDO From MAEDDO Where IDMAEEDO = " & _Idmaeedo & ")"
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row) Then
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set " &
                               "Estado = 'FACTU'" &
                               ",IdmaeedoGen = " & _Row.Item("IDMAEEDO") &
                               ",TidoGen = '" & _Row.Item("TIDO") & "'" &
                               ",NudoGen = '" & _Row.Item("NUDO") & "'" & vbCrLf &
                               "Where Id = " & _Id & vbCrLf &
                               "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set " &
                               "Facturado = 1" &
                               ",Idmaeedo_FCV = '" & _Row.Item("IDMAEEDO") & "'" &
                               ",Nudo_Fcv = '" & _Row.Item("NUDO") & "'" &
                               ",Fecha_Facturado = '" & Format(_Row.Item("FEEMDO"), "yyyyMMdd") & "'" &
                               ",FechaHoraFacturado= '" & Format(_Row.Item("LAHORA"), "yyyyMMdd HH:mm:ss") & "'" &
                               ",Informacion = 'Documento creado correctamente'" &
                               ",ErrorGrabar = 0" & vbCrLf &
                               "Where Id_Pickeo = " & _Id
                _Sql.Ej_consulta_IDU(Consulta_sql)
            End If

        Next

        'Me.Cursor = Cursors.WaitCursor

        Dim _Condicion As String = String.Empty
        Dim _DocEmitir As Boolean
        Dim _TidoGen As Boolean
        Dim _NudoGen As Boolean
        Dim _FechaPickeado As Boolean
        Dim _HoraPickeado As Boolean
        Dim _MostrarImagenes As Boolean
        Dim _FechaPlanificacion As Boolean

        Dim _VerPlanificadas As String = "--And Planificada = 1"

        'If Chk_VerIngresadas.Checked Then
        '    _VerPlanificadas = String.Empty
        'End If

        Dim _Tbas = Super_TabS.SelectedTab

        Select Case _Tbas.Name
            Case "Tab_Pendientes"
                'If Chk_VerIngresadas.Checked Then
                '    _Condicion += vbCrLf & "And (Estado In ('PREPA','COMPL') And Planificada = 1) Or (Estado = 'INGRE')"
                'Else
                '    _Condicion += vbCrLf & "And (Estado In ('PREPA','COMPL') And Planificada = 1)"
                'End If
                _DocEmitir = True
                _FechaPickeado = True
                _HoraPickeado = True
                _MostrarImagenes = True
            Case "Tab_Ingresadas"
                _Condicion += vbCrLf & "And Estado = 'INGRE'"
                _DocEmitir = True
                _MostrarImagenes = True
                _FechaPlanificacion = True
            Case "Tab_Preparacion"
                _Condicion += vbCrLf & "And Estado = 'PREPA' " & _VerPlanificadas
                _DocEmitir = True
                _MostrarImagenes = True
                _FechaPlanificacion = True
            Case "Tab_Completadas"
                _Condicion += vbCrLf & "And Estado = 'COMPL' --" & _VerPlanificadas
                _DocEmitir = True
                _FechaPickeado = True
                _HoraPickeado = True
                _MostrarImagenes = True
                '_FechaPlanificacion = True
            Case "Tab_Facturadas"
                _Condicion += vbCrLf & "And Estado = 'FACTU'"
                _TidoGen = True
                _NudoGen = True
            Case "Tab_Entregadas"
                _Condicion += vbCrLf & "And Estado = 'ENTRE' --And CONVERT(varchar, FechaEntrega, 112) = '" & Format(Now.Date, "yyyyMMdd") & "'"
                _TidoGen = True
                _NudoGen = True
            Case "Tab_Cerradas"
                _Condicion += vbCrLf & "And Estado = 'CERRA' And CONVERT(varchar, FechaCierre, 112) = '" & Format(Now.Date, "yyyyMMdd") & "'"
                _TidoGen = True
                _NudoGen = True
            Case "Tab_Nulas"
                _Condicion += vbCrLf & "And Estado = 'NULO'"
        End Select

        '_Condicion += vbCrLf & "And CONVERT(varchar, Enc." & Cmb_FiltroFecha.SelectedValue & ", 112) = '" & Format(Dtp_FechaDesde.Value, "yyyyMMdd") & "'"
        _Condicion += vbCrLf & "And CONVERT(varchar, Enc." & Cmb_FiltroFecha.SelectedValue & ", 112) Between '" & Format(Dtp_FechaDesde.Value, "yyyyMMdd") & "' And '" & Format(Dtp_FechaHasta.Value, "yyyyMMdd") & "'"

        Consulta_sql = My.Resources.Recursos_WmsSgem.SQLQuery_Listado_Stmp_Rutas
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Sucursal#", ModSucursal)
        Consulta_sql = Replace(Consulta_sql, "--#Condicion#", _Condicion)
        'Consulta_sql = Replace(Consulta_sql, "Zw_Stmp_Enc", _Global_BaseBk & "Zw_Stmp_Enc")
        'Consulta_sql = Replace(Consulta_sql, "Zw_Demonio_FacAuto", _Global_BaseBk & "Zw_Demonio_FacAuto")
        'Consulta_sql = Replace(Consulta_sql, "Zw_Despachos_Doc", _Global_BaseBk & "Zw_Despachos_Doc")
        'Consulta_sql = Replace(Consulta_sql, "Zw_Despachos", _Global_BaseBk & "Zw_Despachos")
        Consulta_sql = Replace(Consulta_sql, "Global_BaseBk.", _Global_BaseBk)


        Dim _New_Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)
        _Dv = New DataView
        _Dv.Table = _New_Ds.Tables("Table")
        _Tbl_Tickets_Stem = _Dv.Table

        With Grilla

            .DataSource = _Dv

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            .Columns("BtnImagen_Estado").Width = 30
            .Columns("BtnImagen_Estado").HeaderText = "Est."
            .Columns("BtnImagen_Estado").Visible = _MostrarImagenes
            .Columns("BtnImagen_Estado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Facturar").Visible = True '(_Tbas.Name = "Tab_Completadas")
            .Columns("Facturar").HeaderText = "Fac."
            .Columns("Facturar").ToolTipText = "Facturar al completar"
            .Columns("Facturar").Width = 30
            .Columns("Facturar").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Ruta").Visible = True
            .Columns("Ruta").HeaderText = "Ruta"
            .Columns("Ruta").Width = 50
            .Columns("Ruta").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("OrdenRuta").Visible = True
            '.Columns("OrdenRuta").HeaderText = "OR"
            '.Columns("OrdenRuta").Width = 30
            '.Columns("OrdenRuta").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Numero").Visible = True
            '.Columns("Numero").HeaderText = "#Ticket"
            '.Columns("Numero").Width = 70
            '.Columns("Numero").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Tido").Visible = True
            .Columns("Tido").HeaderText = "TD"
            .Columns("Tido").Width = 30
            .Columns("Tido").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nudo").Visible = True
            .Columns("Nudo").HeaderText = "Número"
            .Columns("Nudo").Width = 70
            .Columns("Nudo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Estado").Visible = True
            .Columns("Estado").HeaderText = "Estado"
            .Columns("Estado").Width = 50
            .Columns("Estado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Accion").Visible = True
            .Columns("Accion").HeaderText = "Acción"
            .Columns("Accion").Width = 50
            .Columns("Accion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SUDO").Visible = True
            .Columns("SUDO").HeaderText = "Suc."
            .Columns("SUDO").ToolTipText = "Sucursal del documento"
            .Columns("SUDO").Width = 30
            .Columns("SUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Endo").Visible = True
            .Columns("Endo").HeaderText = "Entidad"
            '.Columns("Endo").ToolTipText = "Estado del Ticket"
            .Columns("Endo").Width = 70
            .Columns("Endo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Suendo").Visible = True
            '.Columns("Suendo").HeaderText = "Entidad"
            ''.Columns("Endo").ToolTipText = "Estado del Ticket"
            '.Columns("Suendo").Width = 120
            '.Columns("Suendo").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").HeaderText = "Razón Social"
            '.Columns("NOKOEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("NOKOEN").Width = 200
            .Columns("NOKOEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1


            .Columns(Cmb_FiltroFecha.SelectedValue).Visible = True
            .Columns(Cmb_FiltroFecha.SelectedValue).HeaderText = Cmb_FiltroFecha.Text '"F.Creación"
            .Columns(Cmb_FiltroFecha.SelectedValue).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(Cmb_FiltroFecha.SelectedValue).DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns(Cmb_FiltroFecha.SelectedValue).Width = 70
            .Columns(Cmb_FiltroFecha.SelectedValue).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("HoraCreacion").Visible = (_Tbas.Name = "Tab_Completadas")
            .Columns("HoraCreacion").HeaderText = "H.Crea"
            .Columns("HoraCreacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("HoraCreacion").DefaultCellStyle.Format = "HH:mm"
            .Columns("HoraCreacion").Width = 50
            .Columns("HoraCreacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Duracion").Visible = _DocEmitir
            '.Columns("Duracion").HeaderText = "Duración"
            '.Columns("Duracion").ToolTipText = "Tiempo que ha transcurrido desde que se creo la entrega hasta ahora."
            '.Columns("Duracion").Width = 80
            '.Columns("Duracion").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("DocEmitir").Visible = _DocEmitir
            .Columns("DocEmitir").HeaderText = "D.E."
            .Columns("DocEmitir").ToolTipText = "Documento a emitir posteriormente (sugerido)"
            '.Columns("NOKOEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("DocEmitir").Width = 30
            .Columns("DocEmitir").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Informacion").Visible = True
            .Columns("Informacion").HeaderText = "Estado"
            .Columns("Informacion").Width = 210
            .Columns("Informacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ItemxDoc").Visible = True
            .Columns("ItemxDoc").HeaderText = "Items"
            .Columns("ItemxDoc").ToolTipText = "Total de Items en el documento"
            .Columns("ItemxDoc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ItemxDoc").Width = 40
            .Columns("ItemxDoc").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantUd1xDoc").Visible = True
            .Columns("CantUd1xDoc").HeaderText = "Cant."
            .Columns("CantUd1xDoc").ToolTipText = "Total de las cantidades de la Unidad 1"
            .Columns("CantUd1xDoc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantUd1xDoc").Width = 40
            .Columns("CantUd1xDoc").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Planificada").Visible = _FechaPlanificacion
            .Columns("Planificada").HeaderText = "Plf."
            .Columns("Planificada").ToolTipText = "Planificada"
            .Columns("Planificada").Width = 30
            .Columns("Planificada").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaPlanificacion").Visible = _FechaPlanificacion
            .Columns("FechaPlanificacion").HeaderText = "F.Planif."
            .Columns("FechaPlanificacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FechaPlanificacion").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaPlanificacion").Width = 70
            .Columns("FechaPlanificacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("HoraPlanificacion").Visible = _FechaPlanificacion
            .Columns("HoraPlanificacion").HeaderText = "H.Planif."
            .Columns("HoraPlanificacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("HoraPlanificacion").DefaultCellStyle.Format = "HH:mm"
            .Columns("HoraPlanificacion").Width = 50
            .Columns("HoraPlanificacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaPickeado").Visible = _FechaPickeado
            .Columns("FechaPickeado").HeaderText = "F.Pickeo"
            .Columns("FechaPickeado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FechaPickeado").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaPickeado").Width = 70
            .Columns("FechaPickeado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("HoraPickeado").Visible = _HoraPickeado
            .Columns("HoraPickeado").HeaderText = "H.Pickeo"
            .Columns("HoraPickeado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("HoraPickeado").DefaultCellStyle.Format = "HH:mm"
            .Columns("HoraPickeado").Width = 60
            .Columns("HoraPickeado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            'If _Tbas.Name.Contains("Tab_Entregadas") Then

            '    .Columns("FechaCierre").Visible = True
            '    .Columns("FechaCierre").HeaderText = "Fecha cierre"
            '    '.Columns("FechaCreacion").ToolTipText = "de tope de la oferta"
            '    .Columns("FechaCierre").DefaultCellStyle.Format = "dd/MM/yyyy"
            '    .Columns("FechaCierre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '    .Columns("FechaCierre").Width = 70
            '    .Columns("FechaCierre").DisplayIndex = _DisplayIndex
            '    _DisplayIndex += 1

            'End If

            .Columns("TidoGen").Visible = True
            .Columns("TidoGen").HeaderText = "TD"
            .Columns("TidoGen").ToolTipText = "Tipo de documento generado"
            .Columns("TidoGen").Width = 30
            .Columns("TidoGen").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NudoGen").Visible = True
            .Columns("NudoGen").HeaderText = "Número"
            .Columns("NudoGen").ToolTipText = "Número de documento generado"
            .Columns("NudoGen").Width = 70
            .Columns("NudoGen").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaFactu").Visible = True
            .Columns("FechaFactu").HeaderText = "F.Factu."
            .Columns("FechaFactu").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FechaFactu").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaFactu").Width = 70
            .Columns("FechaFactu").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("HoraFactu").Visible = True
            .Columns("HoraFactu").HeaderText = "H.Factu."
            .Columns("HoraFactu").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("HoraFactu").DefaultCellStyle.Format = "HH:mm"
            .Columns("HoraFactu").Width = 50
            .Columns("HoraFactu").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Lbl_Estatus.Text = "Registros: " & _Tbl_Tickets_Stem.Rows.Count
        Me.Refresh()

        'Sb_Filtrar()

        If Not _MostrarImagenes Then
            Return
        End If

        'Sb_MarcarPendientes()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Txt_Filtrar_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Filtrar.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Filtrar()
        End If
    End Sub

    Sub Sb_Filtrar()
        Try
            If IsNothing(_Dv) Then Return

            If Txt_Filtrar.Text.ToUpper.Contains("RUTA:") Then

                Dim _Filtro As String() = Txt_Filtrar.Text.Split(":"c)

                _Dv.RowFilter = String.Format("Ruta = '{0}'", _Filtro(1))
            Else
                _Dv.RowFilter = String.Format("Numero+Nudo+NudoGen+Endo+NOKOEN+Ruta Like '%{0}%'", Txt_Filtrar.Text.Trim)
            End If

            Sb_MarcarPendientes()

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Cuek!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Btn_ImpFacMasiva_Click(sender As Object, e As EventArgs) Handles Btn_ImpFacMasiva.Click

        If Not Fx_Tiene_Permiso(Me, "Doc00012") Then
            Return
        End If

        Dim _Ls_Idmaeedo As New List(Of String)

        For Each _Row As DataRowView In _Dv

            Dim _Estado As String = _Row.Item("Estado")

            If _Estado = "FACTU" Then

                If CBool(_Row.Item("IdmaeedoGen")) Then
                    _Ls_Idmaeedo.Add(_Row.Item("IdmaeedoGen"))
                End If

            End If

        Next

        ' Ordenar la lista por OrdenRuta
        _Ls_Idmaeedo = _Ls_Idmaeedo.OrderBy(Function(id) _Tbl_Tickets_Stem.Select("IdmaeedoGen = " & id)(0).Item("OrdenRuta")).ToList()

        If Not CBool(_Ls_Idmaeedo.Count) Then
            MessageBoxEx.Show(Me, "No hay documentos facturados para imprimir", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_ImpMasiva("FCV", _Ls_Idmaeedo)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Excel.Click

    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub BtnIrAptincipio_Click(sender As Object, e As EventArgs) Handles BtnIrAptincipio.Click

    End Sub

    Private Sub BtnIrAlFin_Click(sender As Object, e As EventArgs) Handles BtnIrAlFin.Click

    End Sub

    Private Sub Txt_Filtrar_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Filtrar.ButtonCustom2Click
        If String.IsNullOrWhiteSpace(Txt_Filtrar.Text) Then
            Return
        End If
        Txt_Filtrar.Text = String.Empty
        Sb_Filtrar()
    End Sub

    Sub Sb_MarcarPendientes()

        Dim _MostrarImagenes As Boolean

        Dim _Tbas = Super_TabS.SelectedTab

        Select Case _Tbas.Name
            Case "Tab_Pendientes", "Tab_Preparacion", "Tab_Completadas", "Tab_Ingresadas"
                _MostrarImagenes = True
            Case Else
                _MostrarImagenes = False
        End Select

        If Not _MostrarImagenes Then
            Return
        End If

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Estado As String = _Fila.Cells("Estado").Value
            Dim _Planificada As Boolean = _Fila.Cells("Planificada").Value
            Dim _Error_FacAuto As Boolean = _Fila.Cells("Error_FacAuto").Value
            Dim _Info_FacAuto As String = _Fila.Cells("Info_FacAuto").Value
            Dim _Reasignada As Boolean = _Fila.Cells("Reasignada").Value

            'warning.png
            Dim _Icono As Image

            Dim _Imagenes_List As ImageList
            If Global_Thema = Enum_Themas.Oscuro Then
                _Imagenes_List = Imagenes_16x16_Dark
            Else
                _Imagenes_List = Imagenes_16x16
            End If

            _Icono = Nothing

            If _Estado = "INGRE" Then
                _Icono = _Imagenes_List.Images.Item("menu-more.png")
            End If

            If _Estado = "COMPL" Then
                _Icono = _Imagenes_List.Images.Item("ok.png")
            End If

            If _Estado = "NULO" Or _Estado = "CANCE" Then
                _Icono = _Imagenes_List.Images.Item("cancel.png")
            End If

            If _Estado = "PREPA" Then

                If _Reasignada Then
                    _Icono = _Imagenes_List.Images.Item("symbol-remove.png")
                Else
                    _Icono = _Imagenes_List.Images.Item("symbol-delete.png")
                End If

            End If

            If _Error_FacAuto Then
                _Icono = _Imagenes_List.Images.Item("warning.png")
            End If

            _Fila.Cells("BtnImagen_Estado").Value = _Icono

        Next

    End Sub

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter

        Try
            Dim _Fila As DataGridViewRow = Grilla.CurrentRow
            Dim _Info_FacAuto As String = _Fila.Cells("Info_FacAuto").Value.ToString.Trim
            Lbl_Informacion.Text = _Info_FacAuto
        Catch ex As Exception
            Lbl_Informacion.Text = String.Empty
        End Try

    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            With sender

                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)

                If Hitest.Type = DataGridViewHitTestType.Cell Then

                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
                    Dim _Idmaeedo As Integer = _Fila.Cells("IDMAEEDO").Value
                    Dim _Estado As String = _Fila.Cells("Estado").Value
                    Dim _Error_FacAuto As Boolean = _Fila.Cells("Error_FacAuto").Value

                    LabelItem1.Text = "Opciones (Id: " & _Idmaeedo & ")"

                    Btn_Mnu_EntregarMercaderia.Visible = (Super_TabS.SelectedTab.Name = "Tab_Facturadas")
                    Btn_CerrarTicket.Visible = (Super_TabS.SelectedTab.Name = "Tab_Entregadas")
                    Btn_Mnu_Preparacion.Visible = (Super_TabS.SelectedTab.Name = "Tab_Ingresadas")
                    Btn_ReenviaFacturar.Visible = (Super_TabS.SelectedTab.Name = "Tab_Completadas")
                    Btn_ReenviaFacturar.Enabled = _Error_FacAuto

                    ShowContextMenu(Menu_Contextual_01_Opciones_Documento)

                End If

            End With

        End If

    End Sub

    Private Sub Btn_ReenviaFacturar_Click(sender As Object, e As EventArgs) Handles Btn_ReenviaFacturar.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Id As Integer = _Fila.Cells("Id").Value
        Dim _Idmaeedo As Integer = _Fila.Cells("Idmaeedo").Value

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_FacAuto Where Idmaeedo_NVV = " & _Idmaeedo
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set Facturar = 1,EnvFacAutoBk = 0 Where Id = " & _Id

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                MessageBoxEx.Show(Me, "La nota de venta se envio nuevamente a facturar al diablito", "Información",
                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                Dim _Imagenes_List As ImageList
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Imagenes_List = Imagenes_16x16_Dark
                Else
                    _Imagenes_List = Imagenes_16x16
                End If

                _Fila.Cells("BtnImagen_Estado").Value = _Imagenes_List.Images.Item("ok.png")
            End If

            Return

        End If

        If _Row.Item("Facturado") Then

            MessageBoxEx.Show(Me, "Este documento ya se encuentra facturado" & vbCrLf &
                              _Row.Item("DocEmitir") & "-" & _Row.Item("Nudo_Fcv"), "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto " & vbCrLf &
                       "Set NombreEquipo = '',Facturar = 1,ErrorGrabar = 0,Informacion = ''" & vbCrLf &
                       "Where Id = " & _Row.Item("Id")

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then

            MessageBoxEx.Show(Me, "La nota de venta se envio nuevamente a facturar al diablito", "Información",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim _Imagenes_List As ImageList
            If Global_Thema = Enum_Themas.Oscuro Then
                _Imagenes_List = Imagenes_16x16_Dark
            Else
                _Imagenes_List = Imagenes_16x16
            End If

            _Fila.Cells("BtnImagen_Estado").Value = _Imagenes_List.Images.Item("ok.png")

        End If

    End Sub

    Private Sub Btn_VerDocumento_Click(sender As Object, e As EventArgs) Handles Btn_VerDocumento.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()


    End Sub

    Private Sub Btn_Imprimir_Click(sender As Object, e As EventArgs) Handles Btn_Imprimir.Click

        If Not Fx_Tiene_Permiso(Me, "Doc00012") Then Return

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _IdMaeedo As Integer = _Fila.Cells("IDMAEEDO").Value
        Dim _Tido = _Fila.Cells("TIDO").Value
        Dim _Subtido = String.Empty

        If _Tido = "GDD" Or _Tido = "GDP" Then
            _Subtido = _Fila.Cells("SUBTIDO").Value
        End If

        Consulta_sql = "Select top 1 * From MAEEDO Where IDMAEEDO = " & _IdMaeedo
        Dim _RowEncabezado As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _NombreFormato As String

        Dim Fm As New Frm_Seleccionar_Formato(_Tido)
        If CBool(Fm.Tbl_Formatos.Rows.Count) Then
            Fm.ShowDialog(Me)

            If Fm.Formato_Seleccionado Then
                _Subtido = Fm.Row_Formato_Seleccionado.Item("Subtido")
                _NombreFormato = Fm.Row_Formato_Seleccionado.Item("NombreFormato")
                If _NombreFormato = "" Then
                    _NombreFormato = String.Empty
                End If

                Dim _Imprime As String = Fx_Enviar_A_Imprimir_Documento(Me, _NombreFormato, _IdMaeedo,
                                                         False, True, "", False, 0, False, _Subtido)

                If Not String.IsNullOrEmpty(Trim(_Imprime)) Then
                    MessageBox.Show(Me, _Imprime, "Problemas al Imprimir",
                               MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            End If

        Else
            MessageBoxEx.Show(Me, "No existen formatos adicionales para este documento", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Fm.Dispose()

    End Sub

End Class
