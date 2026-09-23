Imports DevComponents.DotNetBar

Public Class Frm_PreciosLC_InfUltCompras_Mt

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim Tbl1 As String = "Zw_TblPasoUltGRC" & FUNCIONARIO
    Dim Actualizo_Precio As String
    Dim UnidadSeleccionada
    Dim UnidadDeTransaccionActual

    Dim _Tbl_Lista_LC As DataTable
    Dim _Tbl_Lista_LC_Actualizados As DataTable

    Dim _Tbl_Grilla_Old As DataTable

    Dim _Fecha_Hoy As Date = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)

    Dim FormatDecimal As String

    Private _Filtro_Productos_Todos As Boolean
    Private _Filtro_Clalibpr_Todas As Boolean
    Private _Filtro_Marcas_Todas As Boolean
    Private _Filtro_Rubro_Todas As Boolean
    Private _Filtro_Super_Familias_Todas As Boolean
    Private _Filtro_Zonas_Todas As Boolean
    Private _Filtro_Jefes_Todos As Boolean
    Private _Filtro_Bakapp_Todas As Boolean
    Private _Tbl_Filtro_Productos As DataTable
    Private _Tbl_Filtro_Clalibpr As DataTable
    Private _Tbl_Filtro_Marcas As DataTable
    Private _Tbl_Filtro_Rubro As DataTable
    Private _Tbl_Filtro_Super_Familias As DataTable
    Private _Tbl_Filtro_Jefes As DataTable
    Private _Tbl_Filtro_Zonas As DataTable
    Private _Ls_SelSuperFamilias As New List(Of SelSuperFamilias)
    Private _Ls_SelFamilias As New List(Of SelFamilias)
    Private _Ls_SelSubFamilias As New List(Of SelSubFamilias)
    Private _Ls_SelArbol_Asociaciones As New List(Of Zw_TblArbol_Asociaciones)

    Private _Sql_FiltroProductos As String

    Private _Imagen_Btn_Filtro_Productos As System.Drawing.Image
    Private _ImagenAlt_Btn_Filtro_Productos As System.Drawing.Image
    Private _Texto_Btn_Filtro_Productos As String

    Private _Usar_Filtro_Productos_En_Grilla As Boolean = True
    Private _Forzar_Filtro_Productos_Sql As Boolean
    Private Const NombreColFiltroProducto As String = "CumpleFiltroProducto"

    Private Const NombreColSeleccion As String = "Chk"
    Private _AplicandoSeleccionMasiva As Boolean
    Private _FilasSeleccionadasCheck As List(Of Integer)

    Public Property ModoGRC As Boolean
    Public Property ModoProductos As Boolean

    Private _LayoutGrillasInicializado As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        _Imagen_Btn_Filtro_Productos = Btn_Filtro_Productos.Image
        _ImagenAlt_Btn_Filtro_Productos = Btn_Filtro_Productos.ImageAlt
        _Texto_Btn_Filtro_Productos = Btn_Filtro_Productos.Text

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, True, False)
        Sb_Formato_Generico_Grilla(GrillaProdActualizados, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, True, False)
        Sb_Formato_Generico_Grilla(Grilla_GRC_Ant, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        _Sql_FiltroProductos = String.Empty

        _Filtro_Productos_Todos = True
        _Filtro_Clalibpr_Todas = True
        _Filtro_Marcas_Todas = True
        _Filtro_Rubro_Todas = True
        _Filtro_Super_Familias_Todas = True
        _Filtro_Zonas_Todas = True
        _Filtro_Jefes_Todos = True
        _Filtro_Bakapp_Todas = True

        ModoGRC = True

        Sb_Color_Botones_Barra(Bar2)

        Lbl_Empresa.Text = RazonEmpresa

    End Sub

    Private Sub Frm_PreciosLC_InfUltCompras_Mt_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'If ModoProductos Then
        '    Me.WindowState = FormWindowState.Normal
        '    Me.StartPosition = FormStartPosition.CenterScreen
        '    Me.Size = New Size(1040, 627)
        'Else
        '    Me.WindowState = FormWindowState.Maximized
        'End If

        DFechaInicio.Value = Date.Now
        DFechaTermino.Value = Date.Now

        Btn_VerInformeXProductos.Visible = Not ModoProductos
        Btn_Procesar.Visible = Not ModoProductos

        'Dim _Arr_GRCvsUltGR(,) As String = {{"", "Mostrar todo"},
        '                           {"1", "Sin Diferencia"},
        '                           {"2", "Entre -3% y 3% (sin 0)"},
        '                           {"3", ">= 3% Diferencia"},
        '                           {"-3", "<= 3% Diferencia"}}
        'Sb_Llenar_Combos(_Arr_GRCvsUltGR, Cmb_GRCvsUltGRC)
        'Cmb_GRCvsUltGRC.SelectedValue = ""

        Dim _Arr_GRCvsUltGR(,) As String = {{"", "Mostrar todo"},
                                   {"1", "Sin Diferencia"},
                                   {"2", "Entre -5% y 1% (sin 0)"},
                                   {"3", "> 1% Diferencia"},
                                   {"-3", "< 5% Diferencia"}}
        Sb_Llenar_Combos(_Arr_GRCvsUltGR, Cmb_GRCvsUltGRC)
        Cmb_GRCvsUltGRC.SelectedValue = ""

        Dim _Arr_Margen(,) As String = {{"", "Mostrar todo"},
                                        {"1", "Igual a"},
                                        {"2", "Menor que"},
                                        {"3", "Mayor que"}}
        Sb_Llenar_Combos(_Arr_Margen, Cmb_Margen)
        Cmb_Margen.SelectedValue = ""
        Input_Margen.Enabled = False

        caract_combo(Cmb_ListaPrecio)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KOLT AS Padre,'TABPP'+KOLT+' '+NOKOLT AS Hijo FROM TABPP WHERE TILT = 'P' ORDER BY Hijo "
        Cmb_ListaPrecio.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)

        If RutEmpresa = "77634879-1" Then
            Cmb_ListaPrecio.SelectedValue = "PB1"
        Else
            Cmb_ListaPrecio.SelectedValue = "PB7"
        End If

        'Call TabControl1_SelectedIndexChanged(Nothing, Nothing)

        Call Sb_Actualizar_Grillas()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler GrillaProdActualizados.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_Principal_MouseDown
        AddHandler Grilla.MouseDoubleClick, AddressOf Sb_Grilla_Principal_MouseDoubleClick

        AddHandler Grilla.CellMouseDown, AddressOf Sb_Grilla_Seleccion_CellMouseDown
        AddHandler GrillaProdActualizados.CellMouseDown, AddressOf Sb_Grilla_Seleccion_CellMouseDown

        AddHandler Grilla.CurrentCellDirtyStateChanged, AddressOf Sb_Grilla_Seleccion_CurrentCellDirtyStateChanged
        AddHandler GrillaProdActualizados.CurrentCellDirtyStateChanged, AddressOf Sb_Grilla_Seleccion_CurrentCellDirtyStateChanged

        AddHandler Grilla.CellValueChanged, AddressOf Sb_Grilla_Seleccion_CellValueChanged
        AddHandler GrillaProdActualizados.CellValueChanged, AddressOf Sb_Grilla_Seleccion_CellValueChanged

    End Sub

#Region "FUNCIONES"

    Function ActualizarInforme(Redondeo As String)

        Dim Unidad, UD, UdPEdido As String

        If UnidadSeleccionada = True Then
            Unidad = "StockUd1" : UD = "UD1" : UdPEdido = "StockUd1Pedido"
            UnidadDeTransaccionActual = 1
        Else
            Unidad = "StockUd2" : UD = "UD2"
            UnidadDeTransaccionActual = 2 : UdPEdido = "StockUd2Pedido"
        End If

        Consulta_sql = "select * from " & Tbl1

        Consulta_sql = "SELECT dbo." & Tbl1 & ".Id, dbo." & Tbl1 & ".KOPRCT, dbo." & Tbl1 & ".NOKOPR, dbo." & Tbl1 & ".RLUDPR," & vbCrLf &
                       "dbo." & Tbl1 & ".CAPRCO2, dbo." & Tbl1 & ".UD02PR, dbo." & Tbl1 & ".PPPRNE, dbo.MAEPREM.PM," & vbCrLf &
                       "ROUND(ISNULL(dbo." & Tbl1 & ".PPPRNERE2, 0) / ISNULL(dbo." & Tbl1 & ".RLUDPR, 0), 3) AS Ult_Compra, ISNULL(dbo.Zw_ListaLC_ValPro.Mcosto, " & vbCrLf &
                       "0) AS Mcosto, dbo." & Tbl1 & ".TIDO, dbo." & Tbl1 & ".NUDO, dbo." & Tbl1 & ".FEEMLI, dbo." & Tbl1 & ".ENDO, " & vbCrLf &
                       "dbo." & Tbl1 & ".SUENDO, dbo." & Tbl1 & ".NOKOEN, dbo." & Tbl1 & ".SULIDO, dbo." & Tbl1 & ".BOSULIDO" & vbCrLf &
                       "From dbo." & Tbl1 & " LEFT OUTER JOIN" & vbCrLf &
                       "dbo.Zw_ListaLC_ValPro ON dbo." & Tbl1 & ".KOPRCT = dbo.Zw_ListaLC_ValPro.Codigo LEFT OUTER JOIN" & vbCrLf &
                       "dbo.MAEPREM ON dbo." & Tbl1 & ".KOPRCT = dbo.MAEPREM.KOPR" & vbCrLf &
                       "where " & vbCrLf &
                       "dbo.Zw_ListaLC_ValPro.FechaModif <> (SELECT replace(convert(varchar, getdate(), 111), '/',''))" & vbCrLf &
                       "OR dbo.Zw_ListaLC_ValPro.FechaModif IS NULL"

        'Grilla.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        _Tbl_Grilla_Old = _Sql.Fx_Get_DataTable(Consulta_sql)
        GrillaProdActualizados.DataSource = _Tbl_Grilla_Old

        ''cast((1375.0*100/1462) as decimal(10,2)) as porcentaj


        'ActualizaLaGrilla(Grilla, tb, Consulta_sql, cn1)
        FormatoGrilla(GrillaProdActualizados, Redondeo)
        'FormatoGrilla(Grilla, Redondeo)

        ' ActualizarGrilla2()

    End Function

    Sub ActualizarGrilla2()

        Consulta_sql = "SELECT dbo." & Tbl1 & ".Id, dbo." & Tbl1 & ".KOPRCT, dbo." & Tbl1 & ".NOKOPR, dbo." & Tbl1 & ".RLUDPR," & vbCrLf &
                       "dbo." & Tbl1 & ".CAPRCO2, dbo." & Tbl1 & ".UD02PR, dbo." & Tbl1 & ".PPPRNE, dbo.MAEPREM.PM," & vbCrLf &
                       "ROUND(ISNULL(dbo." & Tbl1 & ".PPPRNE, 0) / ISNULL(dbo." & Tbl1 & ".RLUDPR, 0), 3) AS Ult_Compra, ISNULL(dbo.Zw_ListaLC_ValPro.Mcosto, " & vbCrLf &
                       "0) AS Mcosto, dbo." & Tbl1 & ".TIDO, dbo." & Tbl1 & ".NUDO, dbo." & Tbl1 & ".FEEMLI, dbo." & Tbl1 & ".ENDO, " & vbCrLf &
                       "dbo." & Tbl1 & ".SUENDO, dbo." & Tbl1 & ".NOKOEN, dbo." & Tbl1 & ".SULIDO, dbo." & Tbl1 & ".BOSULIDO," & vbCrLf &
                       "dbo.Zw_ListaLC_ValPro.FechaModif,isnull(convert(varchar, dbo.Zw_ListaLC_ValPro.HoraModif, 108) ,'00:00:00') as Hora" & vbCrLf &
                       "FROM  dbo." & Tbl1 & " LEFT OUTER JOIN" & vbCrLf &
                       "dbo.Zw_ListaLC_ValPro ON dbo." & Tbl1 & ".KOPRCT = dbo.Zw_ListaLC_ValPro.Codigo LEFT OUTER JOIN" & vbCrLf &
                       "dbo.MAEPREM ON dbo." & Tbl1 & ".KOPRCT = dbo.MAEPREM.KOPR" & vbCrLf &
                       "where " & vbCrLf &
                       "dbo.Zw_ListaLC_ValPro.FechaModif = (SELECT replace(convert(varchar, getdate(), 111), '/',''))"


        Dim FechaDesde As String = Format(DFechaInicio.Value, "yyyyMMdd")
        Dim FechaHasta As String = Format(DFechaTermino.Value, "yyyyMMdd")


        Consulta_sql = "SELECT Codigo,(Select top 1 NOKOPR from MAEPR where KOPR = TB.Codigo ) AS Descripcion," & vbCrLf &
                       "Mcosto,VproNeto,VproBruto,MgDigitado,ValDigitado,FechaModif,isnull(convert(varchar, HoraModif, 108) ,'00:00:00') as Hora " & vbCrLf &
                       "FROM Zw_ListaLC_ValPro as TB" & vbCrLf &
                       "WHERE FechaModif BETWEEN '" & FechaDesde & "' AND '" & FechaHasta & "'"

        Consulta_sql = My.Resources.Listado_de_productos_con_precios_actualizados_entre_fechas
        Consulta_sql = Replace(Consulta_sql, "#FechaInicio#", FechaDesde)
        Consulta_sql = Replace(Consulta_sql, "#FechaFin#", FechaHasta)


        With GrillaProdActualizados

            .DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)


            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"

            .Columns("Descripcion").Width = 300
            .Columns("Descripcion").HeaderText = "Descripción"

            .Columns("Mcosto").Width = 70
            .Columns("Mcosto").HeaderText = "Mejor costo (Anterior)"
            .Columns("Mcosto").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Mcosto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("VproNeto").Width = 70
            .Columns("VproNeto").HeaderText = "Valor propuesto Neto"
            .Columns("VproNeto").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VproNeto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("VproBruto").Width = 70
            .Columns("VproBruto").HeaderText = "Valor propuesto Bruto"
            .Columns("VproBruto").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VproBruto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("MgDigitado").Width = 70
            .Columns("MgDigitado").HeaderText = "Margen propuesto"
            .Columns("MgDigitado").DefaultCellStyle.Format = "$ ###,##"
            .Columns("MgDigitado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("ValDigitado").Width = 70
            .Columns("ValDigitado").HeaderText = "Valor digitado"
            .Columns("ValDigitado").DefaultCellStyle.Format = "$ ###,##"
            .Columns("ValDigitado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("FechaModif").Width = 80
            .Columns("FechaModif").HeaderText = "Fecha Mod."

            .Columns("Hora").Width = 100
            .Columns("Hora").HeaderText = "Hora Mod."


            .Columns("Tido_UlRc").Width = 50
            .Columns("Tido_UlRc").HeaderText = "Tipo Doc. (Ult. recepción)"

            .Columns("Nudo_UlRc").Width = 80
            .Columns("Nudo_UlRc").HeaderText = "Número Doc. (Ult. recepción)"

            .Columns("Fecha_UlRc").Width = 80
            .Columns("Fecha_UlRc").HeaderText = "Fecha Doc. (Ult. recepción)"

            .Columns("dias").Width = 40
            .Columns("dias").HeaderText = "Días dif."

            'FormatoGrilla(GrillaProdActualizados, 3)

        End With

    End Sub

    Function EjecutarInformeEvaluacionCompras(FechaDesde As String,
                                               FechaHasta As String,
                                               ConsideraFechas As String,
                                               TablaPaso As String)

        Consulta_sql = "IF EXISTS (SELECT * FROM sysobjects WHERE name='Trae_UltGRCxProducto') BEGIN" & vbCrLf &
                       "DROP PROCEDURE Trae_UltGRCxProducto End"
        _Sql.Ej_consulta_IDU(Consulta_sql)


        Consulta_sql = My.Resources.Trae_UltimoDocumentoXproducto.ToString

        Consulta_sql = Replace(Consulta_sql, "@1Tbl", TablaPaso)
        Consulta_sql = Replace(Consulta_sql, "@2Tbl", TablaPaso)

        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "exec Trae_UltGRCxProducto '" & FechaDesde & "','" & FechaHasta &
                       "','" & ConsideraFechas & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql)


        ActualizarInforme(3)


    End Function

    Function FormatoGrilla(Grilla As DataGridView,
                            VarDecimal As String)
        Try

            If VarDecimal = 0 Then FormatDecimal = "##,###0"
            If VarDecimal = 1 Then FormatDecimal = "##,#0.0"
            If VarDecimal = 2 Then FormatDecimal = "##,##0.00"
            If VarDecimal = 3 Then FormatDecimal = "##0.000"
            If VarDecimal = 4 Then FormatDecimal = "##,###0.0000"
            If VarDecimal = 5 Then FormatDecimal = "##,###0.00000"

            With Grilla

                OcultarEncabezadoGrilla(Grilla, True)

                '.DefaultCellStyle.Font = New Font("Tahoma", 8)
                '.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod

                .Columns("Id").Visible = False
                .Columns("ENDO").Visible = False
                .Columns("NOKOEN").Visible = False
                .Columns("BOSULIDO").Visible = False
                .Columns("SUENDO").Visible = False
                .Columns("SULIDO").Visible = False

                .Columns("TIDO").Width = 60
                .Columns("TIDO").HeaderText = "Tipo Doc."
                .Columns("TIDO").Visible = True

                .Columns("NUDO").Width = 100
                .Columns("NUDO").HeaderText = "Nro Doc."
                .Columns("NUDO").Visible = True

                .Columns("FEEMLI").Width = 100
                .Columns("FEEMLI").HeaderText = "Fecha Doc."
                .Columns("FEEMLI").Visible = True

                .Columns("KOPRCT").Width = 100
                .Columns("KOPRCT").HeaderText = "Código producto"
                .Columns("KOPRCT").Visible = True

                .Columns("NOKOPR").Width = 300
                .Columns("NOKOPR").HeaderText = "Descripción producto"
                .Columns("NOKOPR").Visible = True

                .Columns("UD02PR").Width = 60
                .Columns("UD02PR").HeaderText = "Ud"
                .Columns("UD02PR").Visible = True

                .Columns("PPPRNE").Width = 60
                .Columns("PPPRNE").HeaderText = "Precio en Doc."
                .Columns("PPPRNE").DefaultCellStyle.Format = "$ ###,##"
                .Columns("PPPRNE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("PPPRNE").Visible = True

                .Columns("Ult_Compra").Width = 100
                .Columns("Ult_Compra").HeaderText = "$ Ult. Compra (Valor futuro en prox. FCC)"
                .Columns("Ult_Compra").DefaultCellStyle.Format = "$ ###,##"
                .Columns("Ult_Compra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Ult_Compra").Visible = True

                .Columns("PM").Width = 60
                .Columns("PM").HeaderText = "$ P.M."
                .Columns("PM").DefaultCellStyle.Format = "$ ###,##"
                .Columns("PM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("PM").Visible = True

                .Columns("Mcosto").Width = 60
                .Columns("Mcosto").HeaderText = "Mejor Costo (Anterior)"
                .Columns("Mcosto").DefaultCellStyle.Format = "$ ###,##"
                .Columns("Mcosto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Mcosto").Visible = True

                .Columns("CAPRCO2").Width = 60
                .Columns("CAPRCO2").HeaderText = "Cantidad"
                .Columns("CAPRCO2").DefaultCellStyle.Format = FormatDecimal
                .Columns("CAPRCO2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("CAPRCO2").Visible = True

                .Columns("RLUDPR").Width = 30
                .Columns("RLUDPR").HeaderText = "Rtu"
                .Columns("RLUDPR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("RLUDPR").Visible = True


            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Sub Sb_Actualizar_Grilla(Grilla As DataGridView, ByRef _Tbl As DataTable, _Condicion As String)

        Dim VarDecimal = 3

        If VarDecimal = 0 Then FormatDecimal = "##,###0"
        If VarDecimal = 1 Then FormatDecimal = "##,#0.0"
        If VarDecimal = 2 Then FormatDecimal = "##,##0.00"
        If VarDecimal = 3 Then FormatDecimal = "##0.000"
        If VarDecimal = 4 Then FormatDecimal = "##,###0.0000"
        If VarDecimal = 5 Then FormatDecimal = "##,###0.00000"

        Dim _Fecha_Desde As String = Format(DFechaInicio.Value, "yyyyMMdd")
        Dim _Fecha_Hasta As String = Format(DFechaTermino.Value, "yyyyMMdd")

        If ModoGRC Then
            Consulta_sql = My.Resources.Recursos_Lista_LC.Ult_Compras_GRC__New
        ElseIf ModoProductos Then
            Consulta_sql = My.Resources.Recursos_Lista_LC.Ult_Compras_X_Productos
        End If

        Consulta_sql = Replace(Consulta_sql, "#Fecha_Desde#", _Fecha_Desde)
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Hasta#", _Fecha_Hasta)
        Consulta_sql = Replace(Consulta_sql, "--#Condicion#", _Condicion)
        Consulta_sql = Replace(Consulta_sql, "#Global_BaseBk#", _Global_BaseBk)
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", Mod_Empresa)
        Consulta_sql = Replace(Consulta_sql, "#ListaPrecio#", Cmb_ListaPrecio.SelectedValue)

        If Fx_Debe_Filtrar_Productos_En_Sql() Then
            Consulta_sql = Replace(Consulta_sql, "#Condicion_Productos#", _Sql_FiltroProductos)
        Else
            Consulta_sql = Replace(Consulta_sql, "#Condicion_Productos#", String.Empty)
        End If

        _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

        If Not Fx_Debe_Filtrar_Productos_En_Sql() Then
            Sb_Preparar_Columna_Filtro_Productos(_Tbl)
        End If

        With Grilla

            .DataSource = _Tbl

            Sb_Agregar_Columna_Seleccion(_Tbl)

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            .Columns("TIDO").Width = 30
            .Columns("TIDO").HeaderText = "Tipo Doc."
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDO").Width = 80
            .Columns("NUDO").HeaderText = "Nro Doc."
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FECHA").Width = 80
            .Columns("FECHA").HeaderText = "Fecha Doc."
            .Columns("FECHA").Visible = True
            .Columns("FECHA").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TieneFCC").Width = 30
            .Columns("TieneFCC").HeaderText = "Fcc?"
            .Columns("TieneFCC").ToolTipText = "¿Tiene FCC?"
            .Columns("TieneFCC").Visible = True
            .Columns("TieneFCC").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("TIDO_FCC").Width = 30
            '.Columns("TIDO_FCC").HeaderText = "TD"
            '.Columns("TIDO_FCC").Visible = True
            '.Columns("TIDO_FCC").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("NUDO_FCC").Width = 80
            '.Columns("NUDO_FCC").HeaderText = "Nro FCC"
            '.Columns("NUDO_FCC").Visible = True
            '.Columns("NUDO_FCC").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("KOPRCT").Width = 100
            .Columns("KOPRCT").HeaderText = "Código producto"
            .Columns("KOPRCT").Visible = True
            .Columns("KOPRCT").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOPR").Width = 300
            .Columns("NOKOPR").HeaderText = "Descripción producto"
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("RLUDPR").Width = 30
            .Columns("RLUDPR").HeaderText = "Rtu"
            .Columns("RLUDPR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RLUDPR").Visible = True
            .Columns("RLUDPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("UD02PR").Width = 30
            .Columns("UD02PR").HeaderText = "Ud"
            .Columns("UD02PR").Visible = True
            .Columns("UD02PR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CAPRCO2").Width = 60
            .Columns("CAPRCO2").HeaderText = "Cantidad"
            .Columns("CAPRCO2").DefaultCellStyle.Format = FormatDecimal
            .Columns("CAPRCO2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CAPRCO2").Visible = True
            .Columns("CAPRCO2").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Precio_Neto_UN").Width = 70
            '.Columns("Precio_Neto_UN").HeaderText = "Precio GRC (Actual)"
            '.Columns("Precio_Neto_UN").DefaultCellStyle.Format = "$ ###,##.###"
            '.Columns("Precio_Neto_UN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Precio_Neto_UN").Visible = True
            '.Columns("Precio_Neto_UN").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Precio_Neto_UN_Ant").Width = 70
            '.Columns("Precio_Neto_UN_Ant").HeaderText = "Precio GRC (Anterior)"
            '.Columns("Precio_Neto_UN_Ant").DefaultCellStyle.Format = "$ ###,##.###"
            '.Columns("Precio_Neto_UN_Ant").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Precio_Neto_UN_Ant").Visible = True
            '.Columns("Precio_Neto_UN_Ant").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Precio_Bruto_UN").Width = 70
            .Columns("Precio_Bruto_UN").HeaderText = "Precio GRC (Actual)"
            .Columns("Precio_Bruto_UN").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Precio_Bruto_UN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Precio_Bruto_UN").Visible = True
            .Columns("Precio_Bruto_UN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Precio_Bruto_UN_Ant").Width = 70
            .Columns("Precio_Bruto_UN_Ant").HeaderText = "Precio GRC (Anterior)"
            .Columns("Precio_Bruto_UN_Ant").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Precio_Bruto_UN_Ant").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Precio_Bruto_UN_Ant").Visible = True
            .Columns("Precio_Bruto_UN_Ant").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Dif_UCCValor").Width = 60
            '.Columns("Dif_UCCValor").HeaderText = "Dif.UCC Valor"
            '.Columns("Dif_UCCValor").DefaultCellStyle.Format = "$ ###,##"
            '.Columns("Dif_UCCValor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Dif_UCCValor").Visible = True
            '.Columns("Dif_UCCValor").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Dif_UCCPorc").Width = 60
            .Columns("Dif_UCCPorc").HeaderText = "% Diferencia"
            .Columns("Dif_UCCPorc").DefaultCellStyle.Format = "% ###,##.##"
            .Columns("Dif_UCCPorc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Dif_UCCPorc").Visible = True
            .Columns("Dif_UCCPorc").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PM").Width = 60
            .Columns("PM").HeaderText = "$ P.M."
            .Columns("PM").DefaultCellStyle.Format = "$ ###,##"
            .Columns("PM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PM").Visible = True
            .Columns("PM").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Precio_ListaBruto").Width = 70
            .Columns("Precio_ListaBruto").HeaderText = "Precio Lista"
            .Columns("Precio_ListaBruto").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Precio_ListaBruto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Precio_ListaBruto").Visible = True
            .Columns("Precio_ListaBruto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Margen_Lista_Porc").Width = 60
            .Columns("Margen_Lista_Porc").HeaderText = "% Margen P.Lista"
            .Columns("Margen_Lista_Porc").DefaultCellStyle.Format = "% ###,##.##"
            .Columns("Margen_Lista_Porc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Margen_Lista_Porc").Visible = True
            .Columns("Margen_Lista_Porc").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("MontoOferta_Neto").Width = 70
            '.Columns("MontoOferta_Neto").HeaderText = $"$ Precio Oferta"
            '.Columns("MontoOferta_Neto").ToolTipText = "Precio Menor Oferta"
            '.Columns("MontoOferta_Neto").DefaultCellStyle.Format = "##,###0.##"
            '.Columns("MontoOferta_Neto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("MontoOferta_Neto").Visible = True
            '.Columns("MontoOferta_Neto").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("MontoOferta").Width = 70
            .Columns("MontoOferta").HeaderText = $"$ Precio Oferta"
            .Columns("MontoOferta").ToolTipText = "Precio Menor Oferta"
            .Columns("MontoOferta").DefaultCellStyle.Format = "##,###0.##"
            .Columns("MontoOferta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("MontoOferta").Visible = True
            .Columns("MontoOferta").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("MargenOferta_Porc").Width = 60
            .Columns("MargenOferta_Porc").HeaderText = "% Margen Oferta"
            .Columns("MargenOferta_Porc").DefaultCellStyle.Format = "% ###,##.##"
            .Columns("MargenOferta_Porc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("MargenOferta_Porc").Visible = True
            .Columns("MargenOferta_Porc").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaFinOferta").HeaderText = "F.T.Oferta"
            .Columns("FechaFinOferta").ToolTipText = "Fecha de termino de la Oferta"
            .Columns("FechaFinOferta").Width = 70
            .Columns("FechaFinOferta").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaFinOferta").Visible = True
            .Columns("FechaFinOferta").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("IMPUESTOS").Width = 60
            .Columns("IMPUESTOS").HeaderText = "% Imp"
            .Columns("IMPUESTOS").DefaultCellStyle.Format = "% ###,##.##"
            .Columns("IMPUESTOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("IMPUESTOS").Visible = True
            .Columns("IMPUESTOS").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Flete_Bruto").Width = 70
            .Columns("Flete_Bruto").HeaderText = "Flete Bruto"
            .Columns("Flete_Bruto").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Flete_Bruto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Flete_Bruto").Visible = True
            .Columns("Flete_Bruto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ULT_Vta").Width = 100
            .Columns("ULT_Vta").HeaderText = "Ult.Venta"
            .Columns("ULT_Vta").Visible = True
            .Columns("ULT_Vta").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMLI_Vta").Width = 80
            .Columns("FEEMLI_Vta").HeaderText = "Fecha Doc."
            .Columns("FEEMLI_Vta").Visible = True
            .Columns("FEEMLI_Vta").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Precio_Bruto_UN_Vta").Width = 70
            .Columns("Precio_Bruto_UN_Vta").HeaderText = "Precio Vta."
            .Columns("Precio_Bruto_UN_Vta").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Precio_Bruto_UN_Vta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Precio_Bruto_UN_Vta").Visible = True
            .Columns("Precio_Bruto_UN_Vta").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Margen_Porc").Width = 60
            .Columns("Margen_Porc").HeaderText = "% Margen Ult.Vta."
            .Columns("Margen_Porc").DefaultCellStyle.Format = "% ###,##.##"
            .Columns("Margen_Porc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Margen_Porc").Visible = True
            .Columns("Margen_Porc").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("IVA").Width = 60
            '.Columns("IVA").HeaderText = "% Iva"
            '.Columns("IVA").DefaultCellStyle.Format = "% ###,##.##"
            '.Columns("IVA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("IVA").Visible = True
            '.Columns("IVA").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("IMP").Width = 60
            '.Columns("IMP").HeaderText = "% Imp"
            '.Columns("IMP").DefaultCellStyle.Format = "% ###,##.##"
            '.Columns("IMP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("IMP").Visible = True
            '.Columns("IMP").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1


            .Columns("NOKOFM").Width = 150
            .Columns("NOKOFM").HeaderText = "Super Familia"
            .Columns("NOKOFM").Visible = True
            .Columns("NOKOFM").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOPF").Width = 150
            .Columns("NOKOPF").HeaderText = "Familia"
            .Columns("NOKOPF").Visible = True
            .Columns("NOKOPF").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOHF").Width = 150
            .Columns("NOKOHF").HeaderText = "Sub Familia"
            .Columns("NOKOHF").Visible = True
            .Columns("NOKOHF").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOMR").Width = 150
            .Columns("NOKOMR").HeaderText = "Marca"
            .Columns("NOKOMR").Visible = True
            .Columns("NOKOMR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOFU").Width = 150
            .Columns("NOKOFU").HeaderText = "Jefe.prod."
            .Columns("NOKOFU").Visible = True
            .Columns("NOKOFU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOZOPR").Width = 150
            .Columns("NOKOZOPR").HeaderText = "Zona"
            .Columns("NOKOZOPR").Visible = True
            .Columns("NOKOZOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOCLALIBPR").Width = 150
            .Columns("NOCLALIBPR").HeaderText = "Clas.Libre"
            .Columns("NOCLALIBPR").Visible = True
            .Columns("NOKOZOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .ScrollBars = ScrollBars.Both
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

        End With

        Sb_Configurar_Grilla_Seleccion(Grilla)
        Sb_Aplicar_Colores_Filas(Grilla)

    End Sub

    Private Sub Sb_Actualizar_Grilla_GRC_Ant(_Grilla As DataGridView)

        Grilla_GRC_Ant.DataSource = Nothing

        If IsNothing(_Grilla.DataSource) Then
            Return
        End If

        If IsNothing(_Grilla.CurrentRow) Then
            Return
        End If

        Dim _DtOrigen As DataTable = TryCast(_Grilla.DataSource, DataTable)

        If IsNothing(_DtOrigen) Then
            Return
        End If

        Dim _TblAnt As New DataTable
        Dim _FilaOrigen As DataGridViewRow = _Grilla.CurrentRow

        If _DtOrigen.Columns.Contains("KOPRCT") Then
            _TblAnt.Columns.Add("KOPRCT", _DtOrigen.Columns("KOPRCT").DataType)
        End If

        If _DtOrigen.Columns.Contains("NOKOPR") Then
            _TblAnt.Columns.Add("NOKOPR", _DtOrigen.Columns("NOKOPR").DataType)
        End If

        For Each _Columna As DataGridViewColumn In _Grilla.Columns

            If _Columna.Name.EndsWith("_Ant") Then
                Continue For
            End If

            Dim _NombreColumnaAnt As String = _Columna.Name & "_Ant"

            If Not _DtOrigen.Columns.Contains(_NombreColumnaAnt) Then
                Continue For
            End If

            _TblAnt.Columns.Add(_NombreColumnaAnt, _DtOrigen.Columns(_NombreColumnaAnt).DataType)

        Next

        If _TblAnt.Columns.Count = 0 Then
            Return
        End If

        Dim _NuevaFila As DataRow = _TblAnt.NewRow()

        For Each _Columna As DataGridViewColumn In _Grilla.Columns

            If _TblAnt.Columns.Contains(_Columna.Name) Then
                _NuevaFila(_Columna.Name) = _FilaOrigen.Cells(_Columna.Name).Value
            End If

            If _Columna.Name.EndsWith("_Ant") Then
                Continue For
            End If

            Dim _NombreColumnaAnt As String = _Columna.Name & "_Ant"

            If Not _TblAnt.Columns.Contains(_NombreColumnaAnt) Then
                Continue For
            End If

            _NuevaFila(_NombreColumnaAnt) = _FilaOrigen.Cells(_NombreColumnaAnt).Value

        Next

        _TblAnt.Rows.Add(_NuevaFila)
        Grilla_GRC_Ant.DataSource = _TblAnt

        OcultarEncabezadoGrilla(Grilla_GRC_Ant, True)

        Dim VarDecimal = 3

        If VarDecimal = 0 Then FormatDecimal = "##,###0"
        If VarDecimal = 1 Then FormatDecimal = "##,#0.0"
        If VarDecimal = 2 Then FormatDecimal = "##,##0.00"
        If VarDecimal = 3 Then FormatDecimal = "##0.000"
        If VarDecimal = 4 Then FormatDecimal = "##,###0.0000"
        If VarDecimal = 5 Then FormatDecimal = "##,###0.00000"

        Dim _DisplayIndex = 0

        With Grilla_GRC_Ant

            .Columns("TIDO_Ant").Width = 30
            .Columns("TIDO_Ant").HeaderText = "TD"
            .Columns("TIDO_Ant").Visible = True
            .Columns("TIDO_Ant").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDO_Ant").Width = 80
            .Columns("NUDO_Ant").HeaderText = "Nro Doc."
            .Columns("NUDO_Ant").Visible = True
            .Columns("NUDO_Ant").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FECHA_Ant").Width = 100
            .Columns("FECHA_Ant").HeaderText = "Fecha Doc."
            .Columns("FECHA_Ant").Visible = True
            .Columns("FECHA_Ant").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TieneFCC_Ant").Width = 30
            .Columns("TieneFCC_Ant").HeaderText = "Fcc?"
            .Columns("TieneFCC_Ant").ToolTipText = "¿Tiene FCC?"
            .Columns("TieneFCC_Ant").Visible = True
            .Columns("TieneFCC_Ant").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("TIDO_FCC_Ant").Width = 60
            '.Columns("TIDO_FCC_Ant").HeaderText = "TD"
            '.Columns("TIDO_FCC_Ant").Visible = True
            '.Columns("TIDO_FCC_Ant").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("NUDO_FCC_Ant").Width = 80
            .Columns("NUDO_FCC_Ant").HeaderText = "Nro FCC"
            .Columns("NUDO_FCC_Ant").Visible = True
            .Columns("NUDO_FCC_Ant").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("KOPRCT").Width = 100
            .Columns("KOPRCT").HeaderText = "Código producto"
            .Columns("KOPRCT").Visible = True
            .Columns("KOPRCT").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOPR").Width = 300
            .Columns("NOKOPR").HeaderText = "Descripción producto"
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("UD02PR").Width = 60
            '.Columns("UD02PR").HeaderText = "Ud"
            '.Columns("UD02PR").Visible = True
            '.Columns("UD02PR").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("PM").Width = 60
            '.Columns("PM").HeaderText = "$ P.M."
            '.Columns("PM").DefaultCellStyle.Format = "$ ###,##"
            '.Columns("PM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("PM").Visible = True
            '.Columns("PM").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Precio_Bruto_UN_Ant").Width = 100
            .Columns("Precio_Bruto_UN_Ant").HeaderText = "$ Valor GRC"
            .Columns("Precio_Bruto_UN_Ant").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Precio_Bruto_UN_Ant").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Precio_Bruto_UN_Ant").Visible = True
            .Columns("Precio_Bruto_UN_Ant").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CAPRCO2_Ant").Width = 60
            .Columns("CAPRCO2_Ant").HeaderText = "Cantidad"
            .Columns("CAPRCO2_Ant").DefaultCellStyle.Format = FormatDecimal
            .Columns("CAPRCO2_Ant").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CAPRCO2_Ant").Visible = True
            .Columns("CAPRCO2_Ant").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        'For Each _Columna As DataGridViewColumn In Grilla.Columns

        '    If _Columna.Name.EndsWith("_Ant") Then
        '        Continue For
        '    End If

        '    Dim _NombreColumnaAnt As String = _Columna.Name & "_Ant"

        '    If Not Grilla_GRC_Ant.Columns.Contains(_NombreColumnaAnt) Then
        '        Continue For
        '    End If

        '    Dim _DisplayIndex = 0

        '    With Grilla_GRC_Ant.Columns(_NombreColumnaAnt)
        '        .HeaderText = If(String.IsNullOrWhiteSpace(_Columna.HeaderText), _Columna.Name, _Columna.HeaderText)
        '        .Width = _Columna.Width
        '        .DefaultCellStyle.Format = _Columna.DefaultCellStyle.Format
        '        .DefaultCellStyle.Alignment = _Columna.DefaultCellStyle.Alignment
        '        .Visible = True
        '        .DisplayIndex = _DisplayIndex
        '        _DisplayIndex += 1
        '    End With

        'Next

    End Sub

    Private Function Ejecutar()

        Dim FechaDesde As String = Format(DFechaInicio.Value, "yyyyMMdd")
        Dim FechaHasta As String = Format(DFechaTermino.Value, "yyyyMMdd")

        EjecutarInformeEvaluacionCompras(FechaDesde, FechaHasta, "S", Tbl1)

    End Function

#End Region

    Private Sub Grilla_CellFormatting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)

        With sender

            Dim CostoPM As Double
            Dim CostoUC As Double
            Dim Mcosto, McostoNew As Double

            CostoPM = NuloPorNro(.Rows(e.RowIndex).Cells(7).Value, 0)
            CostoUC = NuloPorNro(.Rows(e.RowIndex).Cells(8).Value, 0)
            Mcosto = NuloPorNro(.Rows(e.RowIndex).Cells(9).Value, 0)

            Dim _Codigo As String = .Rows(e.RowIndex).Cells("KOPRCT").Value.ToString.Trim

            If CostoPM > CostoUC Then
                McostoNew = CostoPM
            ElseIf CostoPM < CostoUC Then
                McostoNew = CostoUC
            ElseIf CostoPM = CostoUC Then
                McostoNew = CostoUC
            End If

            If Math.Round(McostoNew, 0) > Math.Round(Mcosto, 0) Then
                .Rows.Item(e.RowIndex).Cells("Dif_UCCPorc").Style.BackColor = Color.Red
                .Rows.Item(e.RowIndex).Cells("Dif_UCCPorc").Style.ForeColor = Color.White
            Else
                .Rows.Item(e.RowIndex).Cells("Dif_UCCPorc").Style.BackColor = Color.White
                .Rows.Item(e.RowIndex).Cells("Dif_UCCPorc").Style.ForeColor = Color.Black
            End If

        End With

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Me.Enabled = False

        Try

            Select Case _Cabeza

                Case "TIDO", "NUDO"

                    Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value
                    Dim _Idmaeddo = _Fila.Cells("IDMAEDDO").Value

                    Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
                    Fm.Idrst = _Idmaeddo
                    Fm.ShowDialog(Me)
                    Fm.Dispose()

                Case Else

                    If Not Fx_Tiene_Permiso(Me, "Pre0002") Then
                        Return
                    End If

                    Dim _Codigo As String = _Fila.Cells("KOPRCT").Value.ToString.Trim

                    Dim Fm As New Frm_PreciosLC_Mt01
                    Fm.Sb_Cargar_Producto(_Codigo)
                    Fm.Txtcodigo.Text = _Codigo
                    Fm.Cerrar_Al_Grabar = True
                    Fm.ShowDialog(Me)

                    If Fm.Grabar Then
                        Sb_Mover_Fila_A_Productos_Procesados(_Fila)
                    End If

                    Fm.Dispose()

            End Select

        Catch ex As Exception
        Finally
            Me.Enabled = True
        End Try

    End Sub

    Private Sub GrillaProdActualizados_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Cabeza = Grilla.Columns(GrillaProdActualizados.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = GrillaProdActualizados.Rows(GrillaProdActualizados.CurrentRow.Index)

        Me.Enabled = False

        Try

            Select Case _Cabeza

                Case "TIDO", "NUDO"

                    Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value
                    Dim _Idmaeddo = _Fila.Cells("IDMAEDDO").Value

                    Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
                    Fm.Idrst = _Idmaeddo
                    Fm.ShowDialog(Me)
                    Fm.Dispose()

                Case Else

                    If Fx_Tiene_Permiso(Me, "Pre0002") Then

                        Dim _Codigo As String = _Fila.Cells("KOPRCT").Value.ToString.Trim

                        Dim Fm As New Frm_PreciosLC_Mt01
                        Fm.Sb_Cargar_Producto(_Codigo)
                        Fm.Txtcodigo.Text = _Codigo
                        Fm.Cerrar_Al_Grabar = True
                        Fm.ShowDialog(Me)
                        Fm.Dispose()

                    End If

            End Select

        Catch ex As Exception
        Finally
            Me.Enabled = True
        End Try

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim _Condicion As String = String.Empty
        Dim Fm_Espera As New Frm_Form_Esperar

        Try

            Me.Enabled = False
            Fm_Espera.BarraCircular.IsRunning = True
            Fm_Espera.Show()
            Me.Cursor = Cursors.WaitCursor

            'If TabControl1.SelectedTabIndex = 0 Then

            _Condicion = $"Where (Lc.FechaModif <> '{Format(_Fecha_Hoy, "yyyyMMdd")}' OR Lc.FechaModif IS NULL)"

            Sb_Actualizar_Grilla(Grilla,
                                 _Tbl_Lista_LC,
                                 _Condicion)
            'Else

            _Condicion = $"Where Lc.FechaModif = '{Format(_Fecha_Hoy, "yyyyMMdd")}'"

            Sb_Actualizar_Grilla(GrillaProdActualizados,
                                 _Tbl_Lista_LC_Actualizados,
                                 _Condicion)
            'End If

            Sb_Aplicar_Filtros()

        Catch ex As Exception
        Finally
            Me.Enabled = True
            Fm_Espera.Dispose()
            Me.Cursor = Cursors.Default
        End Try

        Me.Refresh()

    End Sub

    Sub Sb_Actualizar_Grillas()

        Dim _Condicion As String = String.Empty
        Dim Fm_Espera As New Frm_Form_Esperar

        Try

            Me.Enabled = False
            Fm_Espera.BarraCircular.IsRunning = True
            Fm_Espera.Show()
            Me.Cursor = Cursors.WaitCursor

            'If TabControl1.SelectedTabIndex = 0 Then

            '_Condicion = $"Where (Lc.FechaModif <> '{Format(_Fecha_Hoy, "yyyyMMdd")}' OR Lc.FechaModif IS NULL)"
            '_Condicion = $"Where ((Lc.FechaModif NOT BETWEEN '{Format(DFechaInicio.Value, "yyyyMMdd")}' AND '{Format(DFechaTermino.Value, "yyyyMMdd")}') Or (Lc.FechaModif IS NULL))"
            _Condicion = $"Where ((Lc.FechaModif NOT BETWEEN @Fecha_Desde AND @Fecha_Hasta) Or (Lc.FechaModif IS NULL))"

            Sb_Actualizar_Grilla(Grilla,
                                 _Tbl_Lista_LC,
                                 _Condicion)
            'Else

            '_Condicion = $"Where Lc.FechaModif = '{Format(_Fecha_Hoy, "yyyyMMdd")}'"
            '_Condicion = $"Where Lc.FechaModif BETWEEN '{Format(DFechaInicio.Value, "yyyyMMdd")}' AND '{Format(DFechaTermino.Value, "yyyyMMdd")}'"
            _Condicion = $"Where Lc.FechaModif BETWEEN @Fecha_Desde AND @Fecha_Hasta"

            Sb_Actualizar_Grilla(GrillaProdActualizados,
                                 _Tbl_Lista_LC_Actualizados,
                                 _Condicion)
            'End If

            Sb_Aplicar_Filtros()

        Catch ex As Exception
        Finally
            Me.Enabled = True
            Fm_Espera.Dispose()
            Me.Cursor = Cursors.Default
        End Try

        Me.Refresh()

    End Sub

    Private Sub Grilla_SelectionChanged(sender As Object, e As EventArgs) Handles Grilla.SelectionChanged
        If Object.ReferenceEquals(sender, Me.Grilla) Then
            Sb_Actualizar_Grilla_GRC_Ant(Me.Grilla)
        End If
    End Sub

    Private Sub GrillaProdActualizados_SelectionChanged(sender As Object, e As EventArgs) Handles GrillaProdActualizados.SelectionChanged
        If Object.ReferenceEquals(sender, Me.GrillaProdActualizados) Then
            Sb_Actualizar_Grilla_GRC_Ant(Me.GrillaProdActualizados)
        End If
    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        _Forzar_Filtro_Productos_Sql = False
        'TabControl1.SelectedTabIndex = 0
        Call Sb_Actualizar_Grillas()
    End Sub

    Private Function Fx_Grilla_Activa() As DataGridView

        If TabControl1.SelectedTabIndex = 0 Then
            Return Grilla
        End If

        Return GrillaProdActualizados

    End Function

    Private Function Fx_Obtener_Valor_Combo(_Combo As DevComponents.DotNetBar.Controls.ComboBoxEx) As String

        If IsNothing(_Combo.SelectedValue) Then
            Return String.Empty
        End If

        If TypeOf _Combo.SelectedValue Is DataRowView Then
            Return String.Empty
        End If

        Return _Combo.SelectedValue.ToString.Trim

    End Function

    Private Function Fx_Construir_Filtro_Porcentaje(_Campo As String,
                                                _ValorCombo As String) As String

        'Select Case _ValorCombo

        '    Case "1"
        '        Return "IsNull(" & _Campo & ", 0) = 0"
        '    Case "2"
        '        Return "IsNull(" & _Campo & ", 0) > -0.03 And IsNull(" & _Campo & ", 0) < 0.03 And IsNull(" & _Campo & ", 0) <> 0"
        '    Case "3"
        '        Return "IsNull(" & _Campo & ", 0) >= 0.03"
        '    Case "-3"
        '        Return "IsNull(" & _Campo & ", 0) <= -0.03"

        'End Select

        Select Case _ValorCombo

            Case "1"
                Return "IsNull(" & _Campo & ", 0) = 0"
            Case "2"
                Return "IsNull(" & _Campo & ", 0) > -0.05 And IsNull(" & _Campo & ", 0) < 0.01 And IsNull(" & _Campo & ", 0) <> 0"
            Case "3"
                Return "IsNull(" & _Campo & ", 0) >= 0.01"
            Case "-3"
                Return "IsNull(" & _Campo & ", 0) <= -0.05"

        End Select

        Return String.Empty

    End Function

    Private Sub Sb_Agregar_Filtro(ByRef _Filtro As String,
                              _Condicion As String)

        If String.IsNullOrWhiteSpace(_Condicion) Then
            Return
        End If

        If Not String.IsNullOrWhiteSpace(_Filtro) Then
            _Filtro &= " And "
        End If

        _Filtro &= _Condicion

    End Sub

    Private Sub Sb_Aplicar_Filtros()

        Me.Cursor = Cursors.WaitCursor

        Dim _Grilla As DataGridView = Fx_Grilla_Activa()
        Dim _Tbl As DataTable = TryCast(_Grilla.DataSource, DataTable)

        If IsNothing(_Tbl) Then
            Return
        End If

        Dim _IdFilaActual As Integer? = Fx_Obtener_Id_Fila_Actual(_Grilla)
        Dim _IndicePrimeraFila As Integer = -1

        If _Grilla.Rows.Count Then
            _IndicePrimeraFila = _Grilla.FirstDisplayedScrollingRowIndex
        End If

        Dim _Filtro As String = String.Empty

        If Not Fx_Debe_Filtrar_Productos_En_Sql() Then

            If Fx_Puede_Filtrar_Productos_En_Grilla(_Tbl) Then
                Sb_Actualizar_Filtro_Productos_En_Grilla(_Tbl)
                Sb_Agregar_Filtro(_Filtro, NombreColFiltroProducto & " = True")
            End If

        End If

        Sb_Agregar_Filtro(_Filtro,
                          Fx_Construir_Filtro_Seleccion(_Tbl))

        Sb_Agregar_Filtro(_Filtro,
                          Fx_Construir_Filtro_GrcConFcc(_Tbl))

        Sb_Agregar_Filtro(_Filtro,
                          Fx_Construir_Filtro_Porcentaje("Dif_UCCPorc",
                                                         Fx_Obtener_Valor_Combo(Cmb_GRCvsUltGRC)))

        Sb_Agregar_Filtro(_Filtro,
                          Fx_Construir_Filtro_Margen())

        If Not String.IsNullOrWhiteSpace(Txt_BuscaXProducto.Text) Then
            Dim _CodigoProducto As String = Txt_BuscaXProducto.Text.Trim.Replace("'", "''")
            Sb_Agregar_Filtro(_Filtro, "KOPRCT = '" & _CodigoProducto & "'")
        End If

        _Tbl.DefaultView.RowFilter = _Filtro
        Sb_Aplicar_Colores_Filas(_Grilla)

        If _Grilla.Rows.Count Then
            Sb_Restaurar_Fila_Actual(_Grilla, _IdFilaActual, _IndicePrimeraFila)
            Sb_Actualizar_Grilla_GRC_Ant(_Grilla)
        Else
            Grilla_GRC_Ant.DataSource = Nothing
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Cmb_GRCvsUltGRC_SelectedValueChanged(sender As Object, e As EventArgs) Handles Cmb_GRCvsUltGRC.SelectedValueChanged
        Sb_Aplicar_Filtros()
    End Sub

    Private Sub Cmb_Margen_SelectedValueChanged(sender As Object, e As EventArgs) Handles Cmb_Margen.SelectedValueChanged
        Sb_Actualizar_Estado_Filtro_Margen()
    End Sub

    Private Sub Input_Margen_ButtonCustomClick(sender As Object, e As EventArgs) Handles Input_Margen.ButtonCustomClick

        If Not Input_Margen.Enabled Then
            Return
        End If

        Sb_Aplicar_Filtros()

    End Sub

    Private Sub Sb_Aplicar_Colores_Filas(_Grilla As DataGridView)

        If IsNothing(_Grilla) Then
            Return
        End If

        If IsNothing(_Grilla.DataSource) Then
            Return
        End If

        Dim _TieneDifUccPorc As Boolean = _Grilla.Columns.Contains("Dif_UCCPorc")
        Dim _TieneMontoOferta As Boolean = _Grilla.Columns.Contains("MontoOferta")
        Dim _TieneCodigoOferta As Boolean = _Grilla.Columns.Contains("CodigoOferta")

        For Each _Fila As DataGridViewRow In _Grilla.Rows

            _Fila.DefaultCellStyle.BackColor = Color.White
            _Fila.DefaultCellStyle.ForeColor = Color.Black

            If _TieneDifUccPorc Then

                Dim _Dif_UCCPorc As Double = NuloPorNro(_Fila.Cells("Dif_UCCPorc").Value, 0) * 100

                If _Dif_UCCPorc > 1 Then
                    _Fila.Cells("Dif_UCCPorc").Style.ForeColor = Rojo
                ElseIf _Dif_UCCPorc < -5 Then
                    _Fila.Cells("Dif_UCCPorc").Style.ForeColor = Verde
                Else
                    _Fila.Cells("Dif_UCCPorc").Style.ForeColor = Color.Black
                End If

            End If

            If _TieneMontoOferta AndAlso _TieneCodigoOferta Then

                Dim _CodigoOferta As String = String.Empty

                If Not IsDBNull(_Fila.Cells("CodigoOferta").Value) Then
                    _CodigoOferta = _Fila.Cells("CodigoOferta").Value.ToString.Trim
                End If

                If Not String.IsNullOrWhiteSpace(_CodigoOferta) Then
                    _Fila.Cells("MontoOferta").Style.ForeColor = Verde
                    _Fila.Cells("FechaFinOferta").Style.ForeColor = Verde
                Else
                    _Fila.Cells("MontoOferta").Style.ForeColor = Color.Black
                    _Fila.Cells("FechaFinOferta").Style.ForeColor = Color.Black
                End If

            End If

        Next

    End Sub


    Private Sub Btn_Filtro_Productos_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Productos.Click

        Dim Fm As New Frm_Filtro_Especial_Productos

        Dim _Sql_Filtro_Condicion_Extra As String

        Fm.Pro_Filtro_Extra_Productos = _Sql_Filtro_Condicion_Extra
        Fm.Pro_Filtro_Extra_Marcas = $"And KOMR In (Select MRPR From MAEPR Where KOPR In (Select KOPR From MAEPR Where 1>0 {_Sql_Filtro_Condicion_Extra}))"
        Fm.Pro_Filtro_Extra_Super_Familias = $"And KOFM In (Select FMPR From MAEPR Where KOPR In (Select KOPR From MAEPR Where 1>0 {_Sql_Filtro_Condicion_Extra}))"
        Fm.Pro_Filtro_Extra_Rubro_Productos = $"And KORU In (Select RUPR From MAEPR Where KOPR In (Select KOPR From MAEPR Where 1>0 {_Sql_Filtro_Condicion_Extra}))"
        Fm.Pro_Filtro_Extra_Clalibpr = $"And KOCARAC In (Select CLALIBPR From MAEPR Where KOPR In (Select KOPR From MAEPR Where 1>0 {_Sql_Filtro_Condicion_Extra}))"
        Fm.Pro_Filtro_Extra_Zonas = $"And KOZO In (Select ZONAPR From MAEPR Where KOPR In (Select KOPR From MAEPR Where 1>0 {_Sql_Filtro_Condicion_Extra}))"
        Fm.Pro_Filtro_Extra_JefesProducto = $"And INACTIVO = 0 And KOFU In (Select KOFU From TABFUEM Where EMPRESA = '{Mod_Empresa}')"

        Fm.Pro_Filtro_Productos_Todos = _Filtro_Productos_Todos
        Fm.Pro_Filtro_Clalibpr_Todas = _Filtro_Clalibpr_Todas
        Fm.Pro_Filtro_Marcas_Todas = _Filtro_Marcas_Todas
        Fm.Pro_Filtro_Rubro_Todas = _Filtro_Rubro_Todas
        Fm.Pro_Filtro_Super_Familias_Todas = _Filtro_Super_Familias_Todas
        Fm.Pro_Filtro_Zonas_Todas = _Filtro_Zonas_Todas
        Fm.Pro_Filtro_Jefes_Todos = _Filtro_Jefes_Todos
        Fm.Pro_Filtro_Bakapp_Todas = _Filtro_Bakapp_Todas

        Fm.Pro_Tbl_Filtro_Productos = _Tbl_Filtro_Productos
        Fm.Pro_Tbl_Filtro_Clalibpr = _Tbl_Filtro_Clalibpr
        Fm.Pro_Tbl_Filtro_Marcas = _Tbl_Filtro_Marcas
        Fm.Pro_Tbl_Filtro_Rubro = _Tbl_Filtro_Rubro
        Fm.Pro_Tbl_Filtro_Super_Familias = _Tbl_Filtro_Super_Familias
        Fm.Pro_Tbl_Filtro_Jefes = _Tbl_Filtro_Jefes
        Fm.Pro_Tbl_Filtro_Zonas = _Tbl_Filtro_Zonas

        Fm.BuscarSpfmfmsubfm = True
        Fm.Ls_SelSuperFamilias = _Ls_SelSuperFamilias
        Fm.Ls_SelFamilias = _Ls_SelFamilias
        Fm.Ls_SelSubFamilias = _Ls_SelSubFamilias

        Fm.Ls_SelArbol_Asociaciones = _Ls_SelArbol_Asociaciones

        Fm.Btn_Bakapp_Algunas.Enabled = False
        Fm.Rdb_Bakapp_Algunas.Enabled = False
        Fm.Rdb_Bakapp_Todas.Enabled = False
        Fm.LabelX6.Enabled = False
        Fm.LabelX7.Enabled = False

        Fm.ShowDialog(Me)

        If Fm.DialogResult <> DialogResult.OK Then
            Fm.Dispose()
            Return
        End If

        _Tbl_Filtro_Productos = Fm.Pro_Tbl_Filtro_Productos
        _Tbl_Filtro_Clalibpr = Fm.Pro_Tbl_Filtro_Clalibpr
        _Tbl_Filtro_Marcas = Fm.Pro_Tbl_Filtro_Marcas
        _Tbl_Filtro_Rubro = Fm.Pro_Tbl_Filtro_Rubro
        _Tbl_Filtro_Super_Familias = Fm.Pro_Tbl_Filtro_Super_Familias
        _Tbl_Filtro_Jefes = Fm.Pro_Tbl_Filtro_Jefes
        _Tbl_Filtro_Zonas = Fm.Pro_Tbl_Filtro_Zonas

        _Filtro_Productos_Todos = Fm.Pro_Filtro_Productos_Todos
        _Filtro_Clalibpr_Todas = Fm.Pro_Filtro_Clalibpr_Todas
        _Filtro_Marcas_Todas = Fm.Pro_Filtro_Marcas_Todas
        _Filtro_Rubro_Todas = Fm.Pro_Filtro_Rubro_Todas
        _Filtro_Super_Familias_Todas = Fm.Pro_Filtro_Super_Familias_Todas
        _Filtro_Zonas_Todas = Fm.Pro_Filtro_Zonas_Todas
        _Filtro_Jefes_Todos = Fm.Pro_Filtro_Jefes_Todos
        _Filtro_Bakapp_Todas = Fm.Pro_Filtro_Bakapp_Todas

        _Ls_SelSuperFamilias = Fm.Ls_SelSuperFamilias
        _Ls_SelFamilias = Fm.Ls_SelFamilias
        _Ls_SelSubFamilias = Fm.Ls_SelSubFamilias

        _Ls_SelArbol_Asociaciones = Fm.Ls_SelArbol_Asociaciones

        Fm.Dispose()

        '---- FILTROS -------------------------------

        Dim _Filtro_Productos = String.Empty
        Dim _Filtro_Rubros = String.Empty
        Dim _Filtro_Marcas = String.Empty
        Dim _Filtro_Zonas = String.Empty
        Dim _Filtro_SuperFamilias = String.Empty
        Dim _Filtro_ClasLibre = String.Empty
        Dim _Filtro_Bodega = String.Empty
        Dim _Filtro_Jefes = String.Empty
        Dim _Filtro_Bakapp = String.Empty


        If _Filtro_Productos_Todos Then

            If Not _Filtro_Rubro_Todas Then
                _Filtro_Rubros = Generar_Filtro_IN(_Tbl_Filtro_Rubro, "Chk", "Codigo", False, True, "'")
                _Filtro_Rubros = "And Ddo.KOPRCT IN (Select KOPR From MAEPR Where RUPR In " & _Filtro_Rubros & ")"
            End If

            If Not _Filtro_Marcas_Todas Then
                _Filtro_Marcas = Generar_Filtro_IN(_Tbl_Filtro_Marcas, "Chk", "Codigo", False, True, "'")
                _Filtro_Marcas = "And Ddo.KOPRCT IN (Select KOPR From MAEPR Where MRPR In " & _Filtro_Marcas & ")"
            End If

            If Not _Filtro_Super_Familias_Todas Then

                Dim _Fl_SuperFamilias As String = String.Empty
                Dim _Fl_Familias As String = String.Empty
                Dim _Fl_SubFamilias As String = String.Empty

                For Each _Sfm As SelSubFamilias In _Ls_SelSubFamilias
                    _Fl_SubFamilias += "(FMPR = '" & _Sfm.Kofm & "' And PFPR = '" & _Sfm.Kopf & "' And HFPR = '" & _Sfm.Kohf & "');"
                Next
                _Fl_SubFamilias = _Fl_SubFamilias.TrimEnd(";").ToString.Replace(";", " Or ")

                For Each _Fm As SelFamilias In _Ls_SelFamilias
                    If _Fl_SubFamilias.Contains("FMPR = '" & _Fm.Kofm & "'") And _Fl_SubFamilias.Contains("PFPR = '" & _Fm.Kopf & "'") Then
                        Continue For
                    End If
                    _Fl_Familias += "(FMPR = '" & _Fm.Kofm & "' And PFPR = '" & _Fm.Kopf & "');"
                Next
                _Fl_Familias = _Fl_Familias.TrimEnd(";").ToString.Replace(";", " Or ")

                For Each _Spfm As SelSuperFamilias In _Ls_SelSuperFamilias
                    If _Fl_SubFamilias.Contains("FMPR = '" & _Spfm.Kofm & "'") Or _Fl_Familias.Contains("FMPR = '" & _Spfm.Kofm & "'") Then
                        Continue For
                    End If
                    _Fl_SuperFamilias += "(FMPR = '" & _Spfm.Kofm & "');"
                Next
                _Fl_SuperFamilias = _Fl_SuperFamilias.TrimEnd(";").ToString.Replace(";", " Or ")

                If Not String.IsNullOrWhiteSpace(_Fl_SuperFamilias) Then
                    _Filtro_SuperFamilias = "And Ddo.KOPRCT IN (Select KOPR From MAEPR Where " & _Fl_SuperFamilias & ")"
                End If

                If Not String.IsNullOrWhiteSpace(_Fl_Familias) Then
                    If String.IsNullOrWhiteSpace(_Fl_SuperFamilias) Then
                        _Filtro_SuperFamilias = "And Ddo.KOPRCT IN (Select KOPR From MAEPR Where " & _Fl_Familias & ")"
                    Else
                        _Filtro_SuperFamilias = "And Ddo.KOPRCT IN (Select KOPR From MAEPR Where " & _Fl_SuperFamilias & " Or " & _Fl_Familias & ")"
                    End If
                End If

                If Not String.IsNullOrWhiteSpace(_Fl_SubFamilias) Then
                    If String.IsNullOrWhiteSpace(_Fl_Familias) Then
                        _Filtro_SuperFamilias = "And Ddo.KOPRCT IN (Select KOPR From MAEPR Where " & _Fl_SubFamilias & ")"
                    Else

                        If String.IsNullOrWhiteSpace(_Fl_SuperFamilias) Then
                            _Filtro_SuperFamilias = "And Ddo.KOPRCT IN (Select KOPR From MAEPR Where " & _Fl_Familias & " Or " & _Fl_SubFamilias & ")"
                        Else
                            _Filtro_SuperFamilias = "And Ddo.KOPRCT IN (Select KOPR From MAEPR Where " & _Fl_SuperFamilias & " Or " & _Fl_Familias & " Or " & _Fl_SubFamilias & ")"
                        End If

                    End If
                End If

                '_Filtro_SuperFamilias = Generar_Filtro_IN(_Tbl_Filtro_Super_Familias, "Chk", "Codigo", False, True, "'")
                '_Filtro_SuperFamilias = "And KOPR IN (Select KOPR From MAEPR Where FMPR In " & _Filtro_SuperFamilias & ")"

            End If

            If _Filtro_Bakapp_Todas Then
                _Filtro_Bakapp = String.Empty
            Else

                For Each _Asoc In _Ls_SelArbol_Asociaciones
                    If String.IsNullOrWhiteSpace(_Filtro_Bakapp) Then
                        _Filtro_Bakapp = _Asoc.Codigo_Nodo
                    Else
                        _Filtro_Bakapp &= "," & _Asoc.Codigo_Nodo
                    End If
                Next

                If Not String.IsNullOrWhiteSpace(_Filtro_Bakapp) Then
                    _Filtro_Bakapp = "And Ddo.KOPRCT IN (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo_Nodo In (" & _Filtro_Bakapp & "))"
                End If

            End If

            If Not _Filtro_Clalibpr_Todas Then
                _Filtro_ClasLibre = Generar_Filtro_IN(_Tbl_Filtro_Clalibpr, "Chk", "Codigo", False, True, "'")
                _Filtro_ClasLibre = "And Ddo.KOPRCT IN (Select KOPR From MAEPR Where CLALIBPR In " & _Filtro_ClasLibre & ")"
            End If

            If Not _Filtro_Zonas_Todas Then
                _Filtro_Zonas = Generar_Filtro_IN(_Tbl_Filtro_Zonas, "Chk", "Codigo", False, True, "'")
                _Filtro_Zonas = "And Ddo.KOPRCT IN (Select KOPR From MAEPR Where ZONAPR In " & _Filtro_Zonas & ")"
            End If

            If Not _Filtro_Jefes_Todos Then
                _Filtro_Jefes = Generar_Filtro_IN(_Tbl_Filtro_Jefes, "Chk", "Codigo", False, True, "'")
                _Filtro_Jefes = "And Ddo.KOPRCT IN (Select KOPR From MAEPR Where KOFUPR In " & _Filtro_Jefes & ")"
            End If

        Else

            If IsNothing(_Tbl_Filtro_Productos) Then
                Return
            End If

            _Filtro_Productos = Generar_Filtro_IN(_Tbl_Filtro_Productos, "Chk", "Codigo", False, True, "'")
            _Filtro_Productos = "And Ddo.KOPRCT IN " & _Filtro_Productos

        End If

        '---------------------------

        _Sql_FiltroProductos = _Filtro_Productos & vbCrLf &
                        _Filtro_Bodega & vbCrLf &
                        _Filtro_ClasLibre & vbCrLf &
                        _Filtro_Marcas & vbCrLf &
                        _Filtro_Rubros & vbCrLf &
                        _Filtro_SuperFamilias & vbCrLf &
                        _Filtro_Zonas & vbCrLf &
                        _Filtro_Jefes & vbCrLf &
                        _Filtro_Bakapp

        '_Tbl_Productos_Filtrados = _Sql.Fx_Get_DataTable(Consulta_sql)

        Sb_Actualizar_Imagen_Btn_Filtro_Productos()

        Sb_Reaplicar_Filtros_Productos()

        'Call TabControl1_SelectedIndexChanged(Nothing, Nothing)

    End Sub

    Private Sub Chk_QuitarSeleccionados_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_QuitarSeleccionados.CheckedChanged

        If Chk_QuitarSeleccionados.Checked AndAlso Chk_MostrarSoloSeleccionados.Checked Then
            Chk_MostrarSoloSeleccionados.Checked = False
            Return
        End If

        Sb_Aplicar_Filtros()

    End Sub

    Private Sub Chk_MostrarSoloSeleccionados_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_MostrarSoloSeleccionados.CheckedChanged

        If Chk_MostrarSoloSeleccionados.Checked AndAlso Chk_QuitarSeleccionados.Checked Then
            Chk_QuitarSeleccionados.Checked = False
            Return
        End If

        Sb_Aplicar_Filtros()

    End Sub

    Private Sub Chk_GRCconFCC_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_GRCconFCC.CheckedChanged
        Sb_Aplicar_Filtros()
    End Sub

    Private Sub Txt_BuscaXProducto_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_BuscaXProducto.ButtonCustomClick

        Txt_BuscaXProducto.Enabled = False

        Dim _RowProducto As DataRow = Fx_Buscar_Producto("")

        If Not IsNothing(_RowProducto) Then

            Txt_BuscaXProducto.ButtonCustom.Visible = False
            Txt_BuscaXProducto.ButtonCustom2.Visible = True

            Txt_BuscaXProducto.Text = _RowProducto.Item("KOPR").ToString.Trim
            Sb_Aplicar_Filtros()

            If Not CBool(Fx_Grilla_Activa().RowCount) Then
                MessageBoxEx.Show(Me, "No se encontraron registros", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If

        Txt_BuscaXProducto.Enabled = True

    End Sub

    Private Sub Txt_BuscaXProducto_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_BuscaXProducto.ButtonCustom2Click

        If String.IsNullOrWhiteSpace(Txt_BuscaXProducto.Text) Then
            Return
        End If

        Txt_BuscaXProducto.Text = String.Empty
        Txt_BuscaXProducto.ButtonCustom2.Visible = False
        Txt_BuscaXProducto.ButtonCustom.Visible = True

        Sb_Aplicar_Filtros()

    End Sub

    Function Fx_Buscar_Producto(_Codigo As String) As DataRow

        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
        Fm.Pro_CodEntidad = String.Empty
        Fm.Pro_CodSucEntidad = String.Empty
        Fm.Pro_Tipo_Lista = "P"

        Fm.Pro_Sucursal_Busqueda = Mod_Sucursal
        Fm.Pro_Bodega_Busqueda = Mod_Bodega
        Fm.Txtdescripcion.Text = _Codigo
        Fm.Pro_Mostrar_Info = True
        Fm.Pro_Actualizar_Precios = True

        Codigo_abuscar = String.Empty
        Fm.Pro_Mostrar_Clasificaciones = True
        Fm.Pro_Mostrar_Imagenes = True

        Fm.Pro_Filtro_Sql_Extra = "And TIPR <> 'SSN'"

        Fm.ShowDialog(Me)

        If Fm.Pro_Seleccionado Then
            Return Fm.Pro_RowProducto
        Else
            Return Nothing
        End If

    End Function

    Private Sub Grilla_Sorted(sender As Object, e As EventArgs) Handles Grilla.Sorted

        Dim _Grilla As DataGridView = DirectCast(sender, DataGridView)

        Sb_Aplicar_Colores_Filas(_Grilla)

        If _Grilla.Rows.Count Then
            Sb_Actualizar_Grilla_GRC_Ant(_Grilla)
        Else
            Grilla_GRC_Ant.DataSource = Nothing
        End If

    End Sub

    Private Function Fx_Hay_Filtro_Productos() As Boolean

        Return Not (_Filtro_Productos_Todos And
                    _Filtro_Clalibpr_Todas And
                    _Filtro_Marcas_Todas And
                    _Filtro_Rubro_Todas And
                    _Filtro_Super_Familias_Todas And
                    _Filtro_Zonas_Todas And
                    _Filtro_Jefes_Todos And
                    _Filtro_Bakapp_Todas)

    End Function

    Private Sub Sb_Actualizar_Imagen_Btn_Filtro_Productos()

        If Fx_Hay_Filtro_Productos() Then
            Btn_Filtro_Productos.Image = _Imagen_Btn_Filtro_Productos
            Btn_Filtro_Productos.ImageAlt = _ImagenAlt_Btn_Filtro_Productos
            Btn_Filtro_Productos.Text = _Texto_Btn_Filtro_Productos & " (*)"
        Else
            Btn_Filtro_Productos.Image = Nothing
            Btn_Filtro_Productos.ImageAlt = Nothing
            Btn_Filtro_Productos.Text = _Texto_Btn_Filtro_Productos
        End If

    End Sub

    Private Function Fx_Debe_Filtrar_Productos_En_Sql() As Boolean

        If _Forzar_Filtro_Productos_Sql Then
            Return True
        End If

        If Not _Usar_Filtro_Productos_En_Grilla Then
            Return True
        End If

        If Not _Filtro_Bakapp_Todas Then
            Return True
        End If

        Return False

    End Function

    Private Function Fx_Tabla_Base_Activa() As DataTable

        Dim _Grilla As DataGridView = Fx_Grilla_Activa()
        Dim _Tbl As DataTable = Nothing

        If Not IsNothing(_Grilla) Then
            _Tbl = TryCast(_Grilla.DataSource, DataTable)
        End If

        If Not IsNothing(_Tbl) Then
            Return _Tbl
        End If

        If TabControl1.SelectedTabIndex = 0 Then
            Return _Tbl_Lista_LC
        End If

        Return _Tbl_Lista_LC_Actualizados

    End Function

    Private Function Fx_Puede_Filtrar_Productos_En_Grilla(_Tbl As DataTable) As Boolean

        If IsNothing(_Tbl) Then
            Return False
        End If

        If Not _Filtro_Productos_Todos AndAlso Not _Tbl.Columns.Contains("KOPRCT") Then
            Return False
        End If

        If Not _Filtro_Rubro_Todas AndAlso Not _Tbl.Columns.Contains("RUPR") Then
            Return False
        End If

        If Not _Filtro_Marcas_Todas AndAlso Not _Tbl.Columns.Contains("MRPR") Then
            Return False
        End If

        If Not _Filtro_Clalibpr_Todas AndAlso Not _Tbl.Columns.Contains("CLALIBPR") Then
            Return False
        End If

        If Not _Filtro_Zonas_Todas AndAlso Not _Tbl.Columns.Contains("ZONAPR") Then
            Return False
        End If

        If Not _Filtro_Jefes_Todos AndAlso Not _Tbl.Columns.Contains("KOFUPR") Then
            Return False
        End If

        If Not _Filtro_Super_Familias_Todas Then

            If Not _Tbl.Columns.Contains("FMPR") OrElse
               Not _Tbl.Columns.Contains("PFPR") OrElse
               Not _Tbl.Columns.Contains("HFPR") Then
                Return False
            End If

        End If

        Return True

    End Function

    Private Sub Sb_Preparar_Columna_Filtro_Productos(_Tbl As DataTable)

        If IsNothing(_Tbl) Then
            Return
        End If

        If Not _Tbl.Columns.Contains(NombreColFiltroProducto) Then
            Dim _Columna As New DataColumn(NombreColFiltroProducto, GetType(Boolean))
            _Columna.DefaultValue = True
            _Tbl.Columns.Add(_Columna)
        End If

        For Each _Fila As DataRow In _Tbl.Rows
            If _Fila.RowState = DataRowState.Deleted OrElse
               _Fila.RowState = DataRowState.Detached Then
                Continue For
            End If

            _Fila.Item(NombreColFiltroProducto) = True
        Next

    End Sub

    Private Function Fx_Valor_Fila(_Fila As DataRow,
                                   _Campo As String) As String

        If IsNothing(_Fila) Then
            Return String.Empty
        End If

        If IsNothing(_Fila.Table) Then
            Return String.Empty
        End If

        If Not _Fila.Table.Columns.Contains(_Campo) Then
            Return String.Empty
        End If

        If IsDBNull(_Fila.Item(_Campo)) Then
            Return String.Empty
        End If

        Return _Fila.Item(_Campo).ToString.Trim

    End Function

    Private Function Fx_Esta_Seleccionado(_TblFiltro As DataTable,
                                          _Codigo As String) As Boolean

        If IsNothing(_TblFiltro) Then
            Return False
        End If

        If String.IsNullOrWhiteSpace(_Codigo) Then
            Return False
        End If

        If Not _TblFiltro.Columns.Contains("Chk") OrElse
           Not _TblFiltro.Columns.Contains("Codigo") Then
            Return False
        End If

        For Each _Fila As DataRow In _TblFiltro.Rows

            Dim _Marcado As Boolean = False

            If Not IsDBNull(_Fila.Item("Chk")) Then
                _Marcado = CBool(_Fila.Item("Chk"))
            End If

            If Not _Marcado Then
                Continue For
            End If

            If _Fila.Item("Codigo").ToString.Trim = _Codigo Then
                Return True
            End If

        Next

        Return False

    End Function

    Private Function Fx_Cumple_Filtro_SuperFamilias(_Fila As DataRow) As Boolean

        If _Filtro_Super_Familias_Todas Then
            Return True
        End If

        Dim _Kofm As String = Fx_Valor_Fila(_Fila, "FMPR")
        Dim _Kopf As String = Fx_Valor_Fila(_Fila, "PFPR")
        Dim _Kohf As String = Fx_Valor_Fila(_Fila, "HFPR")

        ' 1) Subfamilia exacta
        For Each _Sfm As SelSubFamilias In _Ls_SelSubFamilias
            If _Sfm.Kofm = _Kofm AndAlso
           _Sfm.Kopf = _Kopf AndAlso
           _Sfm.Kohf = _Kohf Then
                Return True
            End If
        Next

        ' 2) Familia exacta, pero solo si no hay subfamilias más específicas para esa familia
        Dim _HaySubFamiliasEspecificas As Boolean = False

        For Each _Sfm As SelSubFamilias In _Ls_SelSubFamilias
            If _Sfm.Kofm = _Kofm AndAlso _Sfm.Kopf = _Kopf Then
                _HaySubFamiliasEspecificas = True
                Exit For
            End If
        Next

        If Not _HaySubFamiliasEspecificas Then
            For Each _Fm As SelFamilias In _Ls_SelFamilias
                If _Fm.Kofm = _Kofm AndAlso
               _Fm.Kopf = _Kopf Then
                    Return True
                End If
            Next
        End If

        ' 3) Superfamilia, pero solo si no hay familias/subfamilias más específicas para esa superfamilia
        Dim _HayDetalleMasEspecifico As Boolean = False

        For Each _Fm As SelFamilias In _Ls_SelFamilias
            If _Fm.Kofm = _Kofm Then
                _HayDetalleMasEspecifico = True
                Exit For
            End If
        Next

        If Not _HayDetalleMasEspecifico Then
            For Each _Sfm As SelSubFamilias In _Ls_SelSubFamilias
                If _Sfm.Kofm = _Kofm Then
                    _HayDetalleMasEspecifico = True
                    Exit For
                End If
            Next
        End If

        If Not _HayDetalleMasEspecifico Then
            For Each _Spfm As SelSuperFamilias In _Ls_SelSuperFamilias
                If _Spfm.Kofm = _Kofm Then
                    Return True
                End If
            Next
        End If

        Return False

    End Function

    Private Function Fx_Cumple_Filtro_Producto(_Fila As DataRow) As Boolean

        If IsNothing(_Fila) Then
            Return False
        End If

        If Not _Filtro_Productos_Todos Then
            Return Fx_Esta_Seleccionado(_Tbl_Filtro_Productos,
                                        Fx_Valor_Fila(_Fila, "KOPRCT"))
        End If

        If Not _Filtro_Rubro_Todas Then

            If Not Fx_Esta_Seleccionado(_Tbl_Filtro_Rubro,
                                        Fx_Valor_Fila(_Fila, "RUPR")) Then
                Return False
            End If

        End If

        If Not _Filtro_Marcas_Todas Then

            If Not Fx_Esta_Seleccionado(_Tbl_Filtro_Marcas,
                                        Fx_Valor_Fila(_Fila, "MRPR")) Then
                Return False
            End If

        End If

        If Not _Filtro_Super_Familias_Todas Then

            If Not Fx_Cumple_Filtro_SuperFamilias(_Fila) Then
                Return False
            End If

        End If

        If Not _Filtro_Clalibpr_Todas Then

            If Not Fx_Esta_Seleccionado(_Tbl_Filtro_Clalibpr,
                                        Fx_Valor_Fila(_Fila, "CLALIBPR")) Then
                Return False
            End If

        End If

        If Not _Filtro_Zonas_Todas Then

            If Not Fx_Esta_Seleccionado(_Tbl_Filtro_Zonas,
                                        Fx_Valor_Fila(_Fila, "ZONAPR")) Then
                Return False
            End If

        End If

        If Not _Filtro_Jefes_Todos Then

            If Not Fx_Esta_Seleccionado(_Tbl_Filtro_Jefes,
                                        Fx_Valor_Fila(_Fila, "KOFUPR")) Then
                Return False
            End If

        End If

        Return True

    End Function

    Private Sub Sb_Actualizar_Filtro_Productos_En_Grilla(_Tbl As DataTable)

        If IsNothing(_Tbl) Then
            Return
        End If

        Sb_Preparar_Columna_Filtro_Productos(_Tbl)

        For Each _Fila As DataRow In _Tbl.Rows
            If _Fila.RowState = DataRowState.Deleted OrElse
               _Fila.RowState = DataRowState.Detached Then
                Continue For
            End If

            _Fila.Item(NombreColFiltroProducto) = Fx_Cumple_Filtro_Producto(_Fila)
        Next

    End Sub

    Private Sub Sb_Reaplicar_Filtros_Productos()

        _Forzar_Filtro_Productos_Sql = False

        If Fx_Debe_Filtrar_Productos_En_Sql() Then
            Call Sb_Actualizar_Grillas()
            Return
        End If

        Dim _TblBase As DataTable = Fx_Tabla_Base_Activa()

        If Not Fx_Puede_Filtrar_Productos_En_Grilla(_TblBase) Then
            _Forzar_Filtro_Productos_Sql = True
            Call Sb_Actualizar_Grillas()
            Return
        End If

        Sb_Aplicar_Filtros()

    End Sub

    Private Sub Btn_Ver_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Documento.Click

        Dim _Fila As DataGridViewRow

        If TabControl1.SelectedTabIndex = 0 Then
            _Fila = Grilla.CurrentRow
        Else
            _Fila = GrillaProdActualizados.CurrentRow
        End If

        Dim _Grilla As DataGridView = Fx_Grilla_Activa()

        If IsNothing(_Grilla.CurrentCell) Then
            Return
        End If

        Dim _Cabeza As String = _Grilla.CurrentCell.OwningColumn.Name
        Dim _Idmaeedo As Integer
        Dim _Idmaeddo As Integer

        If _Cabeza = "TIDO" Or _Cabeza = "NUDO" Or _Cabeza = "ULT_Vta" Then

            If _Cabeza = "TIDO" Or _Cabeza = "NUDO" Then
                _Idmaeedo = _Fila.Cells("IDMAEEDO").Value
                _Idmaeddo = _Fila.Cells("IDMAEDDO").Value
            End If

            If _Cabeza = "ULT_Vta" Then
                _Idmaeedo = _Fila.Cells("IDMAEEDO_Vta").Value
                _Idmaeddo = _Fila.Cells("IDMAEDDO_Vta").Value
            End If

            Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
            Fm.Idrst = _Idmaeddo
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_ListaLC_Click(sender As Object, e As EventArgs) Handles Btn_ListaLC.Click

        If Not Fx_Tiene_Permiso(Me, "Pre0002") Then
            Return
        End If

        Dim _Fila As DataGridViewRow

        If TabControl1.SelectedTabIndex = 0 Then
            _Fila = Grilla.CurrentRow
        Else
            _Fila = GrillaProdActualizados.CurrentRow
        End If

        Dim _Codigo As String = _Fila.Cells("KOPRCT").Value
        Dim _Grabar As Boolean

        Dim Fm As New Frm_PreciosLC_Mt01
        Fm.Sb_Cargar_Producto(_Codigo)
        Fm.Txtcodigo.Text = _Codigo
        Fm.Cerrar_Al_Grabar = True
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then

            If TabControl1.SelectedTabIndex = 0 Then
                Sb_Mover_Fila_A_Productos_Procesados(_Fila)
            Else
                Call Sb_Actualizar_Grillas()
            End If

        End If

    End Sub

    Private Sub Btn_OfertasDinamicas_Click(sender As Object, e As EventArgs) Handles Btn_OfertasDinamicas.Click

        If Not Fx_Tiene_Permiso(Me, "Ofer0001") Then
            Return
        End If

        Dim _Fila As DataGridViewRow

        If TabControl1.SelectedTabIndex = 0 Then
            _Fila = Grilla.CurrentRow
        Else
            _Fila = GrillaProdActualizados.CurrentRow
        End If

        Dim _CodigoOferta As String = _Fila.Cells("CodigoOferta").Value

        Dim Fm As New Frm_OfDinamLista
        Fm.Txt_Buscador.Text = _CodigoOferta
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Sb_Grilla_Principal_MouseDown(sender As Object, e As MouseEventArgs)

        If e.Button <> Windows.Forms.MouseButtons.Right Then
            Return
        End If

        Dim _Grilla As DataGridView = DirectCast(sender, DataGridView)
        Dim _Hit As DataGridView.HitTestInfo = _Grilla.HitTest(e.X, e.Y)

        If _Hit.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If

        If _Hit.RowIndex < 0 OrElse _Hit.ColumnIndex < 0 Then
            Return
        End If

        _Grilla.ClearSelection()
        _Grilla.CurrentCell = _Grilla.Rows(_Hit.RowIndex).Cells(_Hit.ColumnIndex)
        _Grilla.Rows(_Hit.RowIndex).Selected = True

        Dim _Cabeza As String = _Grilla.CurrentCell.OwningColumn.Name

        Btn_ListaLC.Visible = True
        Btn_OfertasDinamicas.Visible = True
        Btn_Ver_Documento.Enabled = (_Cabeza = "TIDO" Or _Cabeza = "NUDO" Or _Cabeza = "ULT_Vta")

        Btn_Ver_Documento.Text = "Ver Documento"

        If _Cabeza = "TIDO" Or _Cabeza = "NUDO" Then
            Btn_Ver_Documento.Text = $"Ver Documento {_Grilla.CurrentRow.Cells("TIDO").Value}-{_Grilla.CurrentRow.Cells("NUDO").Value}"
        End If

        If _Cabeza = "ULT_Vta" Then
            Btn_Ver_Documento.Text = $"Ver Documento {_Grilla.CurrentRow.Cells("ULT_Vta").Value}"
        End If

        ShowContextMenu(Menu_Contextual)

    End Sub

    Private Sub Sb_Grilla_Principal_MouseDoubleClick(sender As Object, e As MouseEventArgs)

        Dim _Grilla As DataGridView = DirectCast(sender, DataGridView)
        Dim _Hit As DataGridView.HitTestInfo = _Grilla.HitTest(e.X, e.Y)

        If _Hit.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If

        If _Hit.RowIndex < 0 OrElse _Hit.ColumnIndex < 0 Then
            Return
        End If

        _Grilla.ClearSelection()
        _Grilla.CurrentCell = _Grilla.Rows(_Hit.RowIndex).Cells(_Hit.ColumnIndex)
        _Grilla.Rows(_Hit.RowIndex).Selected = True

        Dim _Cabeza As String = _Grilla.CurrentCell.OwningColumn.Name

        Btn_ListaLC.Visible = True
        Btn_OfertasDinamicas.Visible = True
        Btn_Ver_Documento.Enabled = (_Cabeza = "TIDO" Or _Cabeza = "NUDO" Or _Cabeza = "ULT_Vta")
        Btn_Ver_Documento.Text = "Ver Documento"

        If _Cabeza = "TIDO" Or _Cabeza = "NUDO" Then
            Btn_Ver_Documento.Text = $"Ver Documento {_Grilla.CurrentRow.Cells("TIDO").Value}-{_Grilla.CurrentRow.Cells("NUDO").Value}"
        End If

        If _Cabeza = "ULT_Vta" Then
            Btn_Ver_Documento.Text = $"Ver Documento {_Grilla.CurrentRow.Cells("ULT_Vta").Value}"
        End If

        ShowContextMenu(Menu_Contextual)

    End Sub


    Private Sub Sb_Agregar_Columna_Seleccion(_Tbl As DataTable)

        If IsNothing(_Tbl) Then
            Return
        End If

        If _Tbl.Columns.Contains(NombreColSeleccion) Then
            Return
        End If

        Dim _Columna As New DataColumn(NombreColSeleccion, GetType(Boolean))
        _Columna.DefaultValue = False
        _Tbl.Columns.Add(_Columna)

    End Sub

    Private Sub Sb_Configurar_Grilla_Seleccion(_Grilla As DataGridView)

        If IsNothing(_Grilla) Then
            Return
        End If

        If Not _Grilla.Columns.Contains(NombreColSeleccion) Then
            Return
        End If

        _Grilla.MultiSelect = True
        _Grilla.ReadOnly = False
        _Grilla.EditMode = DataGridViewEditMode.EditOnEnter
        _Grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        For Each _Columna As DataGridViewColumn In _Grilla.Columns
            _Columna.ReadOnly = _Columna.Name <> NombreColSeleccion
        Next

        With _Grilla.Columns(NombreColSeleccion)
            .HeaderText = "Sel."
            .Width = 35
            .Visible = True
            .DisplayIndex = 0
            .ReadOnly = False
            .Frozen = True
        End With

    End Sub

    Private Function Fx_Valor_Check(_Valor As Object) As Boolean

        If IsNothing(_Valor) OrElse IsDBNull(_Valor) Then
            Return False
        End If

        Return CBool(_Valor)

    End Function

    Private Sub Sb_Grilla_Seleccion_CellMouseDown(sender As Object,
                                                  e As DataGridViewCellMouseEventArgs)

        Dim _Grilla As DataGridView = TryCast(sender, DataGridView)

        _FilasSeleccionadasCheck = Nothing

        If IsNothing(_Grilla) Then
            Return
        End If

        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
            Return
        End If

        If _Grilla.Columns(e.ColumnIndex).Name <> NombreColSeleccion Then
            Return
        End If

        If Not _Grilla.Rows(e.RowIndex).Selected Then
            Return
        End If

        _FilasSeleccionadasCheck = New List(Of Integer)

        For Each _Fila As DataGridViewRow In _Grilla.SelectedRows
            _FilasSeleccionadasCheck.Add(_Fila.Index)
        Next

    End Sub

    Private Sub Sb_Grilla_Seleccion_CurrentCellDirtyStateChanged(sender As Object,
                                                                 e As EventArgs)

        Dim _Grilla As DataGridView = TryCast(sender, DataGridView)

        If IsNothing(_Grilla) Then
            Return
        End If

        If IsNothing(_Grilla.CurrentCell) Then
            Return
        End If

        If _Grilla.Columns(_Grilla.CurrentCell.ColumnIndex).Name <> NombreColSeleccion Then
            Return
        End If

        If _Grilla.IsCurrentCellDirty Then
            _Grilla.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If

    End Sub

    Private Sub Sb_Grilla_Seleccion_CellValueChanged(sender As Object,
                                                     e As DataGridViewCellEventArgs)

        If _AplicandoSeleccionMasiva Then
            Return
        End If

        Dim _Grilla As DataGridView = TryCast(sender, DataGridView)

        If IsNothing(_Grilla) Then
            Return
        End If

        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
            Return
        End If

        If _Grilla.Columns(e.ColumnIndex).Name <> NombreColSeleccion Then
            Return
        End If

        Dim _Valor As Boolean = Fx_Valor_Check(_Grilla.Rows(e.RowIndex).Cells(NombreColSeleccion).Value)
        Dim _FilasAplicar As New List(Of Integer)

        If Not IsNothing(_FilasSeleccionadasCheck) Then
            For Each _Indice As Integer In _FilasSeleccionadasCheck
                If Not _FilasAplicar.Contains(_Indice) Then
                    _FilasAplicar.Add(_Indice)
                End If
            Next
        End If

        If _FilasAplicar.Count <= 1 Then
            For Each _Fila As DataGridViewRow In _Grilla.SelectedRows
                If Not _FilasAplicar.Contains(_Fila.Index) Then
                    _FilasAplicar.Add(_Fila.Index)
                End If
            Next
        End If

        If _FilasAplicar.Count > 1 Then

            _AplicandoSeleccionMasiva = True

            Try
                For Each _Indice As Integer In _FilasAplicar
                    If _Indice <> e.RowIndex AndAlso _Indice >= 0 AndAlso _Indice < _Grilla.Rows.Count Then
                        _Grilla.Rows(_Indice).Cells(NombreColSeleccion).Value = _Valor
                    End If
                Next
            Finally
                _AplicandoSeleccionMasiva = False
                _FilasSeleccionadasCheck = Nothing
            End Try

        Else
            _FilasSeleccionadasCheck = Nothing
        End If

        Sb_Aplicar_Filtros()

    End Sub

    Private Function Fx_Construir_Filtro_Margen() As String

        Dim _ValorCombo As String = Fx_Obtener_Valor_Combo(Cmb_Margen)

        If String.IsNullOrWhiteSpace(_ValorCombo) Then
            Return String.Empty
        End If

        Dim _Margen As Integer = Input_Margen.Value

        Select Case _ValorCombo

            Case "1"
                Return "(IsNull(Margen_Porc, 0) * 100) = " & _Margen

            Case "2"
                Return "(IsNull(Margen_Porc, 0) * 100) < " & _Margen

            Case "3"
                Return "(IsNull(Margen_Porc, 0) * 100) > " & _Margen

        End Select

        Return String.Empty

    End Function

    Private Sub Sb_Actualizar_Estado_Filtro_Margen()

        Dim _MostrarTodo As Boolean = String.IsNullOrWhiteSpace(Fx_Obtener_Valor_Combo(Cmb_Margen))

        Input_Margen.Enabled = Not _MostrarTodo

        If _MostrarTodo Then
            Sb_Aplicar_Filtros()
        End If

    End Sub

    Private Sub Btn_Copiar_Click(sender As Object, e As EventArgs) Handles Btn_Copiar.Click

        Dim _Grilla As DataGridView

        If TabControl1.SelectedTabIndex = 0 Then
            _Grilla = Grilla
        Else
            _Grilla = GrillaProdActualizados
        End If

        Dim _Cabeza = _Grilla.Columns(_Grilla.CurrentCell.ColumnIndex).Name
        Dim _Texto_Cabeza = _Grilla.Columns(_Grilla.CurrentCell.ColumnIndex).HeaderText

        Dim Copiar = _Grilla.Rows(_Grilla.CurrentRow.Index).Cells(_Cabeza).Value
        Clipboard.SetText(Copiar)

        ToastNotification.Show(Me, _Texto_Cabeza & " esta en el portapapeles", Btn_Copiar.Image,
                               2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

    End Sub

    Private Function Fx_Construir_Filtro_Seleccion(_Tbl As DataTable) As String

        If IsNothing(_Tbl) Then
            Return String.Empty
        End If

        If Not _Tbl.Columns.Contains(NombreColSeleccion) Then
            Return String.Empty
        End If

        If Chk_MostrarSoloSeleccionados.Checked Then
            Return NombreColSeleccion & " = True"
        End If

        If Chk_QuitarSeleccionados.Checked Then
            Return NombreColSeleccion & " = False"
        End If

        Return String.Empty

    End Function

    Private Function Fx_Construir_Filtro_GrcConFcc(_Tbl As DataTable) As String

        If Not Chk_GRCconFCC.Checked Then
            Return String.Empty
        End If

        If IsNothing(_Tbl) Then
            Return String.Empty
        End If

        If Not _Tbl.Columns.Contains("TieneFCC") Then
            Return String.Empty
        End If

        Return "Convert(TieneFCC, 'System.String') = 'True' Or " &
               "Convert(TieneFCC, 'System.String') = '1' Or " &
               "Convert(TieneFCC, 'System.String') = 'S' Or " &
               "Convert(TieneFCC, 'System.String') = 'SI'"

    End Function

    Private Sub Btn_Procesar_Click(sender As Object, e As EventArgs) Handles Btn_Procesar.Click

        Dim _TblOrigen As DataTable = TryCast(Grilla.DataSource, DataTable)
        Dim _TblDestino As DataTable = TryCast(GrillaProdActualizados.DataSource, DataTable)
        Dim _FilasSeleccionadas As New List(Of DataRow)
        Dim _ListaFilasSeleccionadas As New List(Of String)

        If IsNothing(_TblOrigen) Then
            MessageBoxEx.Show(Me,
                          "No hay registros seleccionados para procesar.",
                          "Validación",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Stop)
            Return
        End If

        If IsNothing(_TblDestino) Then
            _TblDestino = _TblOrigen.Clone()
            _Tbl_Lista_LC_Actualizados = _TblDestino
            GrillaProdActualizados.DataSource = _TblDestino
            Sb_Configurar_Grilla_Seleccion(GrillaProdActualizados)
        End If

        For Each _FilaGrilla As DataGridViewRow In Grilla.Rows

            If _FilaGrilla.IsNewRow Then
                Continue For
            End If

            If Fx_Valor_Check(_FilaGrilla.Cells(NombreColSeleccion).Value) Then

                Dim _Drv As DataRowView = TryCast(_FilaGrilla.DataBoundItem, DataRowView)

                If Not IsNothing(_Drv) Then
                    _FilasSeleccionadas.Add(_Drv.Row)
                    _ListaFilasSeleccionadas.Add(_Drv.Row.ItemArray(12))
                End If

            End If

        Next

        If _FilasSeleccionadas.Count = 0 Then
            MessageBoxEx.Show(Me,
                          "No hay registros seleccionados para procesar.",
                          "Validación",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Stop)
            Return
        End If

        Dim _Filtro As String = Generar_Filtro_IN_Lista2(_ListaFilasSeleccionadas, False, "'")

        For Each _Codigo As String In _ListaFilasSeleccionadas

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_ListaLC_ValPro")

            If CBool(_Reg) Then
                Consulta_sql = $"
Update {_Global_BaseBk}Zw_ListaLC_ValPro 
Set 
Procesada = 1,
FechaModif = (SELECT replace(convert(varchar, GetDate(), 111), '/','')),
HoraModif = (SELECT convert(varchar, GetDate(), 108)),
FechaHoraModif = GetDate() 
Where Codigo = '{_Codigo}'"
            Else
                Consulta_sql = $"
Delete {_Global_BaseBk}Zw_ListaLC_ValPro Where Codigo = '{_Codigo}'
Insert Into {_Global_BaseBk}Zw_ListaLC_ValPro (Codigo,Mcosto,VproNeto,VproBruto,MgDigitado,ValDigitado,FechaModif,HoraModif,FechaHoraModif) 
values
('{_Codigo}',0,0,0,0,0,(SELECT replace(convert(varchar, GetDate(), 111), '/','')),(SELECT convert(varchar, GetDate(), 108)),GetDate())"
            End If

            _Sql.Ej_consulta_IDU(Consulta_sql)

        Next


        For Each _FilaOrigen As DataRow In _FilasSeleccionadas

            Dim _NuevaFila As DataRow = _TblDestino.NewRow()

            For Each _Columna As DataColumn In _TblOrigen.Columns

                If _TblDestino.Columns.Contains(_Columna.ColumnName) Then
                    _NuevaFila.Item(_Columna.ColumnName) = _FilaOrigen.Item(_Columna.ColumnName)
                End If

            Next

            If _TblDestino.Columns.Contains(NombreColSeleccion) Then
                _NuevaFila.Item(NombreColSeleccion) = False
            End If

            _TblDestino.Rows.Add(_NuevaFila)

        Next

        For Each _FilaOrigen As DataRow In _FilasSeleccionadas
            _TblOrigen.Rows.Remove(_FilaOrigen)
        Next

        Sb_Aplicar_Colores_Filas(Grilla)
        Sb_Aplicar_Colores_Filas(GrillaProdActualizados)

        If Grilla.Rows.Count Then
            Grilla.ClearSelection()
            Grilla.Rows(0).Selected = True
        Else
            Grilla_GRC_Ant.DataSource = Nothing
        End If

    End Sub

    Private Function Fx_Obtener_Id_Fila_Actual(_Grilla As DataGridView) As Integer?

        If IsNothing(_Grilla) Then
            Return Nothing
        End If

        If IsNothing(_Grilla.CurrentRow) Then
            Return Nothing
        End If

        If Not _Grilla.Columns.Contains("Id") Then
            Return Nothing
        End If

        Dim _Valor As Object = _Grilla.CurrentRow.Cells("Id").Value

        If IsNothing(_Valor) OrElse IsDBNull(_Valor) Then
            Return Nothing
        End If

        Return CInt(_Valor)

    End Function

    Private Sub Sb_Restaurar_Fila_Actual(_Grilla As DataGridView,
                                         _IdFila As Integer?,
                                         _IndicePrimeraFila As Integer)

        If IsNothing(_Grilla) Then
            Return
        End If

        If Not _Grilla.Rows.Count Then
            Return
        End If

        Dim _FilaDestino As DataGridViewRow = Nothing

        If _IdFila.HasValue AndAlso _Grilla.Columns.Contains("Id") Then

            For Each _Fila As DataGridViewRow In _Grilla.Rows

                Dim _Valor As Object = _Fila.Cells("Id").Value

                If Not IsNothing(_Valor) AndAlso
                   Not IsDBNull(_Valor) AndAlso
                   CInt(_Valor) = _IdFila.Value Then
                    _FilaDestino = _Fila
                    Exit For
                End If

            Next

        End If

        If IsNothing(_FilaDestino) Then
            _FilaDestino = _Grilla.Rows(0)
        End If

        _Grilla.ClearSelection()
        _FilaDestino.Selected = True

        If _Grilla.Columns.Contains("KOPRCT") Then
            _Grilla.CurrentCell = _FilaDestino.Cells("KOPRCT")
        Else
            _Grilla.CurrentCell = _FilaDestino.Cells(0)
        End If

        If _IndicePrimeraFila >= 0 AndAlso _IndicePrimeraFila < _Grilla.Rows.Count Then
            _Grilla.FirstDisplayedScrollingRowIndex = _IndicePrimeraFila
        ElseIf _FilaDestino.Index >= 0 AndAlso _FilaDestino.Index < _Grilla.Rows.Count Then
            _Grilla.FirstDisplayedScrollingRowIndex = _FilaDestino.Index
        End If

    End Sub

    Private Sub Sb_Mover_Fila_A_Productos_Procesados(_Fila As DataGridViewRow)

        If IsNothing(_Fila) Then
            Return
        End If

        If IsNothing(_Tbl_Lista_LC) OrElse IsNothing(_Tbl_Lista_LC_Actualizados) Then
            Call Sb_Actualizar_Grillas()
            Return
        End If

        Dim _FilaOrigen As DataRowView = TryCast(_Fila.DataBoundItem, DataRowView)

        If IsNothing(_FilaOrigen) Then
            Call Sb_Actualizar_Grillas()
            Return
        End If

        Dim _Row As DataRow = _FilaOrigen.Row

        If _Tbl_Lista_LC_Actualizados.Columns.Contains("Id") AndAlso
           _Row.Table.Columns.Contains("Id") Then

            Dim _Id As Integer = NuloPorNro(_Row.Item("Id"), 0)

            If _Tbl_Lista_LC_Actualizados.Select("Id = " & _Id).Length = 0 Then
                _Tbl_Lista_LC_Actualizados.ImportRow(_Row)
            End If

        Else
            _Tbl_Lista_LC_Actualizados.ImportRow(_Row)
        End If

        _Row.Table.Rows.Remove(_Row)

        Grilla.Refresh()
        GrillaProdActualizados.Refresh()

        Sb_Aplicar_Filtros()

        If GrillaProdActualizados.Rows.Count Then
            Sb_Aplicar_Colores_Filas(GrillaProdActualizados)
        End If

        Sb_Actualizar_Grilla_GRC_Ant(Fx_Grilla_Activa())

    End Sub

    Private Sub Btn_VerInformeXProductos_Click(sender As Object, e As EventArgs) Handles Btn_VerInformeXProductos.Click

        If Not Fx_Tiene_Permiso(Me, "Pre0002") Then
            Return
        End If

        Dim Fm As New Frm_PreciosLC_InfUltCompras_Mt
        Fm.ModoGRC = False
        Fm.ModoProductos = True
        Fm.WindowState = FormWindowState.Normal
        Fm.StartPosition = FormStartPosition.CenterScreen
        Fm.Size = New Size(1056, 666)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Frm_PreciosLC_InfUltCompras_Mt_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        If _LayoutGrillasInicializado Then
            Return
        End If

        _LayoutGrillasInicializado = True

        BeginInvoke(New MethodInvoker(AddressOf Sb_Inicializar_Layout_Grillas))

    End Sub

    Private Sub Sb_Inicializar_Layout_Grillas()

        Dim _TabActual As Integer = TabControl1.SelectedTabIndex

        Try
            TabControl1.SelectedTabIndex = 0
            Sb_Refrescar_Layout_Grilla(Grilla)

            TabControl1.SelectedTabIndex = 1
            Sb_Refrescar_Layout_Grilla(GrillaProdActualizados)

        Finally
            TabControl1.SelectedTabIndex = _TabActual
        End Try

    End Sub

    Private Sub Sb_Refrescar_Layout_Grilla(_Grilla As DataGridView)

        If IsNothing(_Grilla) Then
            Return
        End If

        _Grilla.SuspendLayout()

        Try
            _Grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            _Grilla.ScrollBars = ScrollBars.Both
            _Grilla.Refresh()
            _Grilla.PerformLayout()
        Finally
            _Grilla.ResumeLayout()
        End Try

    End Sub

    Private Sub BtnExportarExcel_Click(sender As Object, e As EventArgs) Handles BtnExportarExcel.Click

        ShowContextMenu(Menu_Contextual_Exportar_Excel)


    End Sub


    Private Function Fx_Obtener_Tabla_Excel_Desde_Grilla_Activa() As DataTable

        Dim _Grilla As DataGridView = Fx_Grilla_Activa()

        If IsNothing(_Grilla) Then
            Return Nothing
        End If

        If _Grilla.Rows.Count = 0 Then
            Return Nothing
        End If

        Dim _Tbl_Excel As New DataTable
        Dim _ColumnasExportar As New List(Of DataGridViewColumn)

        For _DisplayIndex As Integer = 0 To _Grilla.Columns.Count - 1

            For Each _Columna As DataGridViewColumn In _Grilla.Columns

                If _Columna.DisplayIndex <> _DisplayIndex Then
                    Continue For
                End If

                If Not _Columna.Visible Then
                    Continue For
                End If

                If _Columna.Name = NombreColSeleccion Then
                    Continue For
                End If

                Dim _NombreColumna As String = _Columna.HeaderText.Trim

                If String.IsNullOrWhiteSpace(_NombreColumna) Then
                    _NombreColumna = _Columna.Name
                End If

                Dim _NombreBase As String = _NombreColumna
                Dim _Contador As Integer = 1

                While _Tbl_Excel.Columns.Contains(_NombreColumna)
                    _Contador += 1
                    _NombreColumna = _NombreBase & " (" & _Contador & ")"
                End While

                Dim _TipoDato As Type = GetType(String)

                If Not IsNothing(_Columna.ValueType) Then
                    _TipoDato = _Columna.ValueType
                End If

                _Tbl_Excel.Columns.Add(_NombreColumna, _TipoDato)
                _ColumnasExportar.Add(_Columna)

            Next

        Next

        For Each _FilaGrilla As DataGridViewRow In _Grilla.Rows

            If _FilaGrilla.IsNewRow OrElse Not _FilaGrilla.Visible Then
                Continue For
            End If

            Dim _NuevaFila As DataRow = _Tbl_Excel.NewRow()

            For _Indice As Integer = 0 To _ColumnasExportar.Count - 1

                Dim _Valor As Object = _FilaGrilla.Cells(_ColumnasExportar(_Indice).Name).Value

                If IsNothing(_Valor) OrElse IsDBNull(_Valor) Then
                    _NuevaFila(_Indice) = DBNull.Value
                Else
                    _NuevaFila(_Indice) = _Valor
                End If

            Next

            _Tbl_Excel.Rows.Add(_NuevaFila)

        Next

        Return _Tbl_Excel

    End Function

    Private Function Fx_Obtener_Tabla_Excel_Todo() As DataTable

        Dim _TblOrigen As DataTable = Fx_Tabla_Base_Activa()

        If IsNothing(_TblOrigen) Then
            Return Nothing
        End If

        If _TblOrigen.Rows.Count = 0 Then
            Return Nothing
        End If

        Dim _TblExcel As DataTable = _TblOrigen.Copy()

        If _TblExcel.Columns.Contains(NombreColSeleccion) Then
            _TblExcel.Columns.Remove(NombreColSeleccion)
        End If

        If _TblExcel.Columns.Contains(NombreColFiltroProducto) Then
            _TblExcel.Columns.Remove(NombreColFiltroProducto)
        End If

        Return _TblExcel

    End Function

    Private Sub Btn_Mnu_ExportarExcelVistaActual_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_ExportarExcelVistaActual.Click

        Dim Tbl_Excel As DataTable = Fx_Obtener_Tabla_Excel_Desde_Grilla_Activa()
        Dim _NombreArchivo As String = "InformeExcel"

        If TabControl1.SelectedTabIndex = 1 Then
            _NombreArchivo &= "_Actualizados"
        End If

        ExportarTabla_JetExcel_Tabla(Tbl_Excel, Me, _NombreArchivo)

    End Sub

    Private Sub Btn_Mnu_ExportarExcelTodo_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_ExportarExcelTodo.Click

        Dim Tbl_Excel As DataTable = Fx_Obtener_Tabla_Excel_Todo()
        Dim _NombreArchivo As String = "InformeExcel_Todo"

        If TabControl1.SelectedTabIndex = 1 Then
            _NombreArchivo &= "_Actualizados"
        End If

        ExportarTabla_JetExcel_Tabla(Tbl_Excel, Me, _NombreArchivo)

    End Sub
End Class
