﻿Imports DevComponents.DotNetBar

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

        Sb_InsertarBotonenGrilla(Grilla, "BtnImagen_Estado", "Est.", "Img_Estado", 0, _Tipo_Boton.Imagen)

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        'AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
        'AddHandler Tab_Preparacion.Click, AddressOf Sb_Actualizar_Grilla
        'AddHandler Tab_Ingresadas.Click, AddressOf Sb_Actualizar_Grilla
        'AddHandler Tab_Completadas.Click, AddressOf Sb_Actualizar_Grilla
        'AddHandler Tab_Facturadas.Click, AddressOf Sb_Actualizar_Grilla
        'AddHandler Tab_Entregadas.Click, AddressOf Sb_Actualizar_Grilla
        'AddHandler Tab_Cerradas.Click, AddressOf Sb_Actualizar_Grilla
        'AddHandler Tab_Pendientes.Click, AddressOf Sb_Actualizar_Grilla

        'AddHandler Grilla.ColumnHeaderMouseClick, AddressOf Grilla_ColumnHeaderMouseClick

        Super_TabS.SelectedTabIndex = 0

        Sb_Actualizar_Grilla()

        Timer_Monitoreo.Interval = 1000 * 5

    End Sub

    Sub Sb_Actualizar_Grilla()

        'Consulta_sql = "Select Distinct Edo.IDMAEEDO,Edo.TIDO,Edo.NUDO,Edo.ENDO,Edo.SUENDO,Edo.FEEMDO," &
        '               "DdoFcv.IDMAEEDO As 'IDMAEEDO_Fcv',DdoFcv.TIDO As 'TD',DdoFcv.NUDO As 'NUDO_Fcv'--,DdoFcv.FEEMLI as 'F.Cierre'" & vbCrLf &
        '               "Into #PasoFacturadas" & vbCrLf &
        '               "From MAEDDO Ddo" & vbCrLf &
        '               "Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO" & vbCrLf &
        '               "Inner Join MAEDDO DdoFcv on Ddo.IDMAEDDO = DdoFcv.IDRST And DdoFcv.ARCHIRST = 'MAEDDO'" & vbCrLf &
        '               "Where Edo.IDMAEEDO In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Stmp_Enc " &
        '               "Where Estado In ('PREPA','COMPL'))" & vbCrLf &
        '               "Order By Edo.TIDO,Edo.NUDO" & vbCrLf &
        '                vbCrLf &
        '               "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set Estado = 'FACTU',Facturar = 1,IdmaeedoGen = Ps.IDMAEEDO_Fcv,TidoGen = Ps.TD,NudoGen = Ps.NUDO_Fcv" & vbCrLf &
        '               "From " & _Global_BaseBk & "Zw_Stmp_Enc Enc" & vbCrLf &
        '               "Inner Join #PasoFacturadas Ps On Enc.Idmaeedo = Ps.IDMAEEDO" & vbCrLf &
        '               "Drop Table #PasoFacturadas"

        '_Sql.Ej_consulta_IDU(Consulta_sql)

        'Me.Cursor = Cursors.WaitCursor

        Dim _Condicion As String = String.Empty
        Dim _DocEmitir As Boolean
        Dim _TidoGen As Boolean
        Dim _NudoGen As Boolean
        Dim _FechaPickeado As Boolean
        Dim _HoraPickeado As Boolean
        Dim _MostrarImagenes As Boolean
        Dim _FechaPlanificacion As Boolean

        Dim _VerPlanificadas As String = "And Planificada = 1"

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

        _Condicion += vbCrLf & "And CONVERT(varchar, FechaCreacion, 112) = '" & Format(Dtp_FechaCreacion.Value, "yyyyMMdd") & "'"

        Consulta_sql = My.Resources.Recursos_WmsSgem.SQLQuery_Listado_Stmp_Rutas
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Sucursal#", ModSucursal)
        Consulta_sql = Replace(Consulta_sql, "--#Condicion#", _Condicion)
        Consulta_sql = Replace(Consulta_sql, "Zw_Stmp_Enc", _Global_BaseBk & "Zw_Stmp_Enc")
        Consulta_sql = Replace(Consulta_sql, "Zw_Demonio_FacAuto", _Global_BaseBk & "Zw_Demonio_FacAuto")

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

            '.Columns("Accion").Visible = True
            '.Columns("Accion").HeaderText = "Acción"
            '.Columns("Accion").Width = 50
            '.Columns("Accion").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

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

            .Columns("FechaCreacion").Visible = True '(_Tbas.Name = "Tab_Completadas")
            .Columns("FechaCreacion").HeaderText = "F.Creación"
            .Columns("FechaCreacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FechaCreacion").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaCreacion").Width = 70
            .Columns("FechaCreacion").DisplayIndex = _DisplayIndex
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

            'If Txt_Filtrar.Text.Contains("#") Then
            '    Txt_Filtrar.Text = Replace(Txt_Filtrar.Text, "#", "")
            '    Txt_Filtrar.Text = "#Tk" & numero_(Txt_Filtrar.Text, 7)
            'End If

            '_Dv.RowFilter = String.Format("Numero+Nudo+Endo+NOKOEN+Ruta Like '%{0}%' " &
            '                              "And FechaCreacion = '{1}'",
            '                              Txt_Filtrar.Text.Trim,
            '                              Format(Dtp_FechaCreacion.Value, "yyyyMMdd"))

            If Txt_Filtrar.Text.ToUpper.Contains("RUTA:") Then

                Dim _Filtro As String() = Txt_Filtrar.Text.Split(":"c)

                _Dv.RowFilter = String.Format("Ruta Like '%{0}%'", _Filtro(1))
            Else
                _Dv.RowFilter = String.Format("Numero+Nudo+Endo+NOKOEN+Ruta Like '%{0}%'", Txt_Filtrar.Text.Trim)
            End If

            Sb_MarcarPendientes()

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Cuek!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Btn_ImpFacMasiva_Click(sender As Object, e As EventArgs) Handles Btn_ImpFacMasiva.Click

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

End Class
