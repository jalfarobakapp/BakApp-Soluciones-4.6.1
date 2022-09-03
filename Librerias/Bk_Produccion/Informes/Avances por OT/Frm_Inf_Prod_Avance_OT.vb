Imports DevComponents.DotNetBar

Imports BkSpecialPrograms

Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.SuperGrid.Style

Public Class Frm_Inf_Prod_Avance_OT

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Informe_01_OT As DataTable
    Dim _Tbl_Informe_02_SUBOT As DataTable
    Dim _Tbl_Informe_03_SUBOT_OPERACIONES As DataTable
    Dim _Tbl_Informe_04_OPERACIONES As DataTable

    Dim _Numot As String

    ' Formato de colores para las grillas
    Private _Background1 As New Background(Color.White, Color.FromArgb(238, 244, 251), 45)
    Private _Background2 As New Background(Color.FromArgb(249, 249, 234))
    Private _Background3 As New Background(Color.FromArgb(255, 247, 250))

    Public Property Pro_Numot As String
        Get
            Return _Numot
        End Get
        Set(value As String)
            _Numot = "And POTPR.NUMOT = '" & value & "'"
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


        Me.Width = 1300
        Me.Height = 600

        _Numot = String.Empty

    End Sub

    Private Sub Frm_Inf_Prod_Avance_OT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Initialize_Grid()
        Sb_Actualizar_Grilla()
        
    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = My.Resources.Recursos_Informes_Produccion.SQLQuery_Informe_de_OT_avance_Vs_SubOt_por_Operaciones
        Consulta_sql = Replace(Consulta_sql, "--And NUMOT = ''", _Numot)
        Consulta_sql = Replace(Consulta_sql, "#Base_Bakapp#", _Global_BaseBk)


        Dim _Ds_Informe As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)


        _Tbl_Informe_01_OT = _Ds_Informe.Tables(0)
        _Tbl_Informe_02_SUBOT = _Ds_Informe.Tables(1)
        _Tbl_Informe_03_SUBOT_OPERACIONES = _Ds_Informe.Tables(2)
        _Tbl_Informe_04_OPERACIONES = _Ds_Informe.Tables(3)

        If True Then

            _Ds_Informe.Relations.Add("1",
                                    _Ds_Informe.Tables("Table").Columns("NUMOT"),
                                    _Ds_Informe.Tables("Table1").Columns("NUMOT"), False)

            _Ds_Informe.Relations.Add("2",
                                    _Ds_Informe.Tables("Table1").Columns("NUMOT_PERTENECE"),
                                    _Ds_Informe.Tables("Table2").Columns("NUMOT_PERTENECE"), False)

            _Ds_Informe.Relations.Add("3",
                                    _Ds_Informe.Tables("Table2").Columns("IDPOTL"),
                                    _Ds_Informe.Tables("Table3").Columns("IDPOTL"), False)

            _Ds_Informe.Relations.Add("4",
                                    _Ds_Informe.Tables("Table3").Columns("IDPOTPR"),
                                    _Ds_Informe.Tables("Table4").Columns("IDRST"), False)

            _Ds_Informe.Relations.Add("5",
                                    _Ds_Informe.Tables("Table4").Columns("IDPDATFAD"),
                                    _Ds_Informe.Tables("Table5").Columns("IDPDATFAD"), False)

        End If

        If False Then
            _Ds_Informe.Relations.Add("1",
                                    _Ds_Informe.Tables("Table").Columns("NUMOT"),
                                     _Ds_Informe.Tables("Table1").Columns("NUMOT"), False)

            _Ds_Informe.Relations.Add("2",
                                      _Ds_Informe.Tables("Table1").Columns("IDPOTL"),
                                      _Ds_Informe.Tables("Table2").Columns("IDPOTL"), False)

            _Ds_Informe.Relations.Add("3",
                                     _Ds_Informe.Tables("Table2").Columns("IDPOTPR"),
                                     _Ds_Informe.Tables("Table3").Columns("IDRST"), False)


            _Ds_Informe.Relations.Add("4",
                                     _Ds_Informe.Tables("Table3").Columns("IDPDATFAD"),
                                     _Ds_Informe.Tables("Table4").Columns("IDPDATFAD"), False)

        End If

        Super_Grilla.PrimaryGrid.DataSource = _Ds_Informe
        Super_Grilla.PrimaryGrid.DataMember = "Table"

        Dim _Fecha_Hoy As Date = FormatDateTime(FechaDelServidor, DateFormat.ShortDate)

        For Each _Fila As DataRow In _Tbl_Informe_01_OT.Rows

            Dim _Fiot As Date = _Fila.Item("FIOT")
            Dim _Dias_Habiles = Fx_Cuenta_Dias(_Fiot, _Fecha_Hoy, Opcion_Dias.Habiles)
            Dim _Dias_Sabado = Fx_Cuenta_Dias(_Fiot, _Fecha_Hoy, Opcion_Dias.Sabado)
            Dim _Dias_domingo = Fx_Cuenta_Dias(_Fiot, _Fecha_Hoy, Opcion_Dias.Domingo)

            _Fila.Item("Dias_Hb") = _Dias_Habiles
            _Fila.Item("Dias_Sb") = _Dias_Sabado
            _Fila.Item("Dias_Dm") = _Dias_domingo

        Next


    End Sub

    Private Sub Sb_Initialize_Grid()

        Dim panel As GridPanel = Super_Grilla.PrimaryGrid

        panel.Name = "Informe"
        panel.ShowToolTips = True

        panel.MinRowHeight = 20
        panel.AutoGenerateColumns = True

        panel.DefaultVisualStyles.GroupByStyles.Default.Background = _Background1

        panel.SelectionGranularity = SelectionGranularity.Cell

        'AddHandler Super_Grilla.CellValueChanged, AddressOf SuperGridControl1CellValueChanged
        AddHandler Super_Grilla.GetCellStyle, AddressOf SuperGridControl1GetCellStyle
        AddHandler Super_Grilla.DataBindingComplete, AddressOf SuperGridControl1DataBindingComplete

        'AddHandler Super_Grilla.MouseClick, AddressOf Sb_Super_Grilla_MouseClick
        'AddHandler Super_Grilla.SelectionChanged, AddressOf SuperGridControl1SelectionChanged
    End Sub

    Private Sub SuperGridControl1DataBindingComplete(ByVal sender As Object, ByVal e As GridDataBindingCompleteEventArgs)

        Dim panel As GridPanel = e.GridPanel

        panel.GroupByRow.Visible = True
        panel.GroupByRow.Text = "GRUPOS"

        Sb_Ocultar_encabezados_Super_Grilla(panel)

        Select Case panel.DataMember
            Case "Table"
                Sb_Formato_Grilla_OT(panel)
            Case "Table1"
                Sb_Formato_Grilla_OT2(panel)
            Case "Table2"
                Sb_Formato_Grilla_OT3(panel)
                ' panel.SortLevel = SortLevel.None
                'Sb_Formato_Grilla_Documentos(panel)
            Case "Table3"
                Sb_Formato_Grilla_OT4(panel)
            Case "Table4"
                Sb_Formato_Grilla_OT5(panel)
        End Select
    End Sub

    Sub Sb_Formato_Grilla_OT(ByVal _Grilla As GridPanel)

        With _Grilla

            .FrozenColumnCount = 1
            .ColumnHeader.RowHeight = 70
            .ShowRowGridIndex = True
            .GroupByRow.Visible = False
            '.UseAlternateRowStyle = True

            .Caption.Text = "(INFORME DE COMPRAS COMERCIO EXTERIOR)<div align=""vcenter"">Información detallada de los productos de la empresa</div>"

            .Columns(0).GroupBoxEffects = GroupBoxEffects.None
            .Columns(0).CellStyles.Default.Background = New Background(Color.AliceBlue)

            For Each column As GridColumn In .Columns
                column.ColumnSortMode = ColumnSortMode.Multiple
                column.ResizeMode = ColumnResizeMode.MoveFollowingElements
                'column.AutoSizeMode = ColumnAutoSizeMode.AllCells
                '   column.HeaderStyles.Default.Margin = _Padding
                'column.HeaderText = "Masked TextBox"
            Next column

            .Columns("NUMOT").Width = 100
            .Columns("NUMOT").HeaderText = "Número OT"
            .Columns("NUMOT").Visible = True
            .Columns("NUMOT").DisplayIndex = 0

            .Columns("REFERENCIA").Width = 290
            .Columns("REFERENCIA").HeaderText = "Referencia"
            .Columns("REFERENCIA").Visible = True
            .Columns("REFERENCIA").DisplayIndex = 1

            .Columns("FIOT").Width = 70
            .Columns("FIOT").HeaderText = "Fecha" & vbCrLf & "inicio OT"
            .Columns("FIOT").Visible = True
            'DirectCast(.Columns("FIOT").RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"
            .Columns("FIOT").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("FIOT").DisplayIndex = 2

            .Columns("Dias_Hb").Width = 80
            .Columns("Dias_Hb").HeaderText = "Días habiles" & vbCrLf & "transcurridos"
            .Columns("Dias_Hb").Visible = True
            DirectCast(.Columns("Dias_Hb").RenderControl, GridIntegerInputEditControl).DisplayFormat = "###,##"
            .Columns("Dias_Hb").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("Dias_Hb").DisplayIndex = 3

            '.Columns("Dias_Sb").Width = 60
            '.Columns("Dias_Sb").HeaderText = "Días sábado"
            '.Columns("Dias_Sb").Visible = True
            '.Columns("Dias_Sb").DisplayIndex = 1

            '.Columns("Dias_Dm").Width = 60
            '.Columns("Dias_Dm").HeaderText = "Días domingo"
            '.Columns("Dias_Dm").Visible = True
            '.Columns("Dias_Dm").DisplayIndex = 1

            .Columns("Fabricar").Width = 80
            .Columns("Fabricar").HeaderText = "Cantidad" & vbCrLf & "Fabricar"
            DirectCast(.Columns("Fabricar").RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,#0"
            .Columns("Fabricar").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("Fabricar").Visible = True
            .Columns("Fabricar").DisplayIndex = 4

            .Columns("Realizado").Width = 80
            .Columns("Realizado").HeaderText = "Cantidad" & vbCrLf & "Realizado"
            DirectCast(.Columns("Realizado").RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,#0"
            .Columns("Realizado").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("Realizado").Visible = True
            .Columns("Realizado").DisplayIndex = 5

            .Columns("Av_Fb_Ot").Width = 60
            .Columns("Av_Fb_Ot").HeaderText = "% Avance"
            DirectCast(.Columns("Av_Fb_Ot").RenderControl, GridDoubleInputEditControl).DisplayFormat = "% #0.##"
            .Columns("Av_Fb_Ot").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("Av_Fb_Ot").Visible = True
            .Columns("Av_Fb_Ot").DisplayIndex = 6

            .Columns("Cant_Operaciones").Width = 80
            .Columns("Cant_Operaciones").HeaderText = "Operaciones" & vbCrLf & "a realizar"
            DirectCast(.Columns("Cant_Operaciones").RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,#0"
            .Columns("Cant_Operaciones").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("Cant_Operaciones").Visible = True
            .Columns("Cant_Operaciones").DisplayIndex = 7

            .Columns("Operaciones_Realizadas").HeaderText = "Operaciones" & vbCrLf & "realizadas"
            DirectCast(.Columns("Operaciones_Realizadas").RenderControl, GridIntegerInputEditControl).DisplayFormat = "###,#0"
            .Columns("Operaciones_Realizadas").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("Operaciones_Realizadas").Visible = True
            .Columns("Operaciones_Realizadas").DisplayIndex = 8

            .Columns("Av_Op").Width = 60
            .Columns("Av_Op").HeaderText = "% Avance"
            DirectCast(.Columns("Av_Op").RenderControl, GridDoubleInputEditControl).DisplayFormat = "% #0.##"
            .Columns("Av_Op").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("Av_Op").Visible = True
            .Columns("Av_Op").DisplayIndex = 9

            .Columns("Fabricar_SubOt").Width = 80
            .Columns("Fabricar_SubOt").HeaderText = "Cantidad piezas SubOT"
            DirectCast(.Columns("Fabricar_SubOt").RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,#0"
            .Columns("Fabricar_SubOt").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("Fabricar_SubOt").Visible = True
            .Columns("Fabricar_SubOt").DisplayIndex = 10

            .Columns("Realizado_SubOt").Width = 60
            .Columns("Realizado_SubOt").HeaderText = "Cant. Piezas" & vbCrLf & "fabricadas SubOt"
            DirectCast(.Columns("Realizado_SubOt").RenderControl, GridIntegerInputEditControl).DisplayFormat = "###,#0"
            .Columns("Realizado_SubOt").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("Realizado_SubOt").Visible = True
            .Columns("Realizado_SubOt").DisplayIndex = 11

            .Columns("Av_Fb_Partes_SubOt").Width = 60
            .Columns("Av_Fb_Partes_SubOt").HeaderText = "% Avance"
            DirectCast(.Columns("Av_Fb_Partes_SubOt").RenderControl, GridDoubleInputEditControl).DisplayFormat = "% #0.##"
            .Columns("Av_Fb_Partes_SubOt").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("Av_Fb_Partes_SubOt").Visible = True
            .Columns("Av_Fb_Partes_SubOt").DisplayIndex = 12

            '.Columns("TOT_SALDOxPRECIOREAL").Width = 120
            '.Columns("TOT_SALDOxPRECIOREAL").HeaderText = "Saldo $"
            '.Columns("TOT_SALDOxPRECIOREAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("TOT_SALDOxPRECIOREAL").DefaultCellStyle.Format = "$ ###,##"
            '.Columns("TOT_SALDOxPRECIOREAL").Visible = True
            '.Columns("TOT_SALDOxPRECIOREAL").DisplayIndex = 11

        End With


    End Sub

    Sub Sb_Formato_Grilla_OT2(ByVal _Grilla As GridPanel)

        With _Grilla


            .FrozenColumnCount = 1
            .ColumnHeader.RowHeight = 35
            .ShowRowGridIndex = True
            .GroupByRow.Visible = False
            '.UseAlternateRowStyle = True

            .Caption.Text = "(PRODUCTOS)<div align=""vcenter"">Productos solicitados a fabricar</div>"

            .Columns(0).GroupBoxEffects = GroupBoxEffects.None
            .Columns(0).CellStyles.Default.Background = New Background(Color.AliceBlue)

            For Each column As GridColumn In .Columns
                column.ColumnSortMode = ColumnSortMode.Multiple
                column.ResizeMode = ColumnResizeMode.MoveFollowingElements
                'column.AutoSizeMode = ColumnAutoSizeMode.AllCells
                '   column.HeaderStyles.Default.Margin = _Padding
                'column.HeaderText = "Masked TextBox"
            Next column

            Dim _Columna As String
            Dim _DisplayIndex = 0

            _Columna = "NUMOT_PERTENECE"
            .Columns(_Columna).Width = 100
            .Columns(_Columna).HeaderText = "Pertenece"
            .Columns(_Columna).Visible = True
            .Columns(_Columna).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Columna = "CODIGO"
            .Columns(_Columna).Width = 100
            .Columns(_Columna).HeaderText = "Código"
            .Columns(_Columna).Visible = True
            .Columns(_Columna).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Columna = "NREGOTL"
            .Columns(_Columna).Width = 60
            .Columns(_Columna).HeaderText = "SubOt"
            .Columns(_Columna).Visible = True
            .Columns(_Columna).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Columna = "DESCRIPCION_PR"
            .Columns(_Columna).Width = 350
            .Columns(_Columna).HeaderText = "Descripción"
            .Columns(_Columna).Visible = True
            .Columns(_Columna).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Columna = "FABRICAR"
            .Columns(_Columna).Width = 60
            .Columns(_Columna).HeaderText = "Cantidad"
            DirectCast(.Columns(_Columna).RenderControl, GridDoubleInputEditControl).DisplayFormat = "#0.##"
            .Columns(_Columna).CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns(_Columna).Visible = True
            .Columns(_Columna).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Columna = "Av_Op"
            .Columns(_Columna).Width = 60
            .Columns(_Columna).HeaderText = "% Fabric."
            DirectCast(.Columns(_Columna).RenderControl, GridDoubleInputEditControl).DisplayFormat = "% #0.##"
            .Columns(_Columna).CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns(_Columna).Visible = True
            .Columns(_Columna).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Sub Sb_Formato_Grilla_OT3(ByVal _Grilla As GridPanel)

        With _Grilla

            .FrozenColumnCount = 1
            .ColumnHeader.RowHeight = 35
            .ShowRowGridIndex = True
            .GroupByRow.Visible = False
            .SortUsingHiddenColumns = False
            '.UseAlternateRowStyle = True

            .Caption.Text = "(COMPONENTES)<div align=""vcenter"">Piezas a fabricar</div>"

            .Columns(0).GroupBoxEffects = GroupBoxEffects.None
            .Columns(0).CellStyles.Default.Background = New Background(Color.AliceBlue)

            For Each column As GridColumn In .Columns
                column.ColumnSortMode = ColumnSortMode.Multiple
                column.ResizeMode = ColumnResizeMode.MoveFollowingElements
                'column.AutoSizeMode = ColumnAutoSizeMode.AllCells
                '   column.HeaderStyles.Default.Margin = _Padding
                'column.HeaderText = "Masked TextBox"
            Next column

            '.Columns("NUMOT_PERTENECE").Width = 100
            '.Columns("NUMOT_PERTENECE").HeaderText = "Pertenece"
            '.Columns("NUMOT_PERTENECE").Visible = True
            '.Columns("NUMOT_PERTENECE").DisplayIndex = 0

            .Columns("IDPOTL").Width = 100
            .Columns("IDPOTL").HeaderText = "Pertenece"
            .Columns("IDPOTL").Visible = True
            .Columns("IDPOTL").DisplayIndex = 0

            .Columns("CODIGO").Width = 100
            .Columns("CODIGO").HeaderText = "Código"
            .Columns("CODIGO").Visible = True
            .Columns("CODIGO").DisplayIndex = 1

            .Columns("DESCRIPCION_PR").Width = 350
            .Columns("DESCRIPCION_PR").HeaderText = "Descripción"
            .Columns("DESCRIPCION_PR").Visible = True
            .Columns("DESCRIPCION_PR").DisplayIndex = 2

            '.Columns("Porc_Avance").Width = 60
            '.Columns("Porc_Avance").HeaderText = "% Fabric."
            'DirectCast(.Columns("Porc_Avance").RenderControl, GridDoubleInputEditControl).DisplayFormat = "% #0.##"
            '.Columns("Porc_Avance").CellStyles.Default.Alignment = Alignment.MiddleRight
            '.Columns("Porc_Avance").Visible = True
            '.Columns("Porc_Avance").DisplayIndex = 3

            .Columns("Av_Op").Width = 60
            .Columns("Av_Op").HeaderText = "% Fabric."
            DirectCast(.Columns("Porc_Avance").RenderControl, GridDoubleInputEditControl).DisplayFormat = "% #0.##"
            .Columns("Av_Op").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("Av_Op").Visible = True
            .Columns("Av_Op").DisplayIndex = 3

        End With

    End Sub

    Sub Sb_Formato_Grilla_OT4(ByVal _Grilla As GridPanel)

        With _Grilla

            .FrozenColumnCount = 1
            .ColumnHeader.RowHeight = 35
            .ShowRowGridIndex = True
            .GroupByRow.Visible = False
            '.UseAlternateRowStyle = True

            .Caption.Text = "HOJA DE RUTA<div align=""vcenter"">Procesos de fabricación.</div>"

            .Columns(0).GroupBoxEffects = GroupBoxEffects.None
            .Columns(0).CellStyles.Default.Background = New Background(Color.AliceBlue)

            For Each column As GridColumn In .Columns
                column.ColumnSortMode = ColumnSortMode.Multiple
                column.ResizeMode = ColumnResizeMode.MoveFollowingElements
                'column.AutoSizeMode = ColumnAutoSizeMode.AllCells
                '   column.HeaderStyles.Default.Margin = _Padding
                'column.HeaderText = "Masked TextBox"
            Next column

            Dim _DisplayIndex = 0

            .Columns("IDPOTPR").Width = 100
            .Columns("IDPOTPR").HeaderText = "Pertenece"
            .Columns("IDPOTPR").Visible = True
            .Columns("IDPOTPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("OPERACION").Width = 100
            .Columns("OPERACION").HeaderText = "Código"
            .Columns("OPERACION").Visible = True
            .Columns("OPERACION").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOMBREOP").Width = 350
            .Columns("NOMBREOP").HeaderText = "Descripción"
            .Columns("NOMBREOP").Visible = True
            .Columns("NOMBREOP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Porc_Avance").Width = 60
            .Columns("Porc_Avance").HeaderText = "% Fabric."
            DirectCast(.Columns("Porc_Avance").RenderControl, GridDoubleInputEditControl).DisplayFormat = "% #0.##"
            .Columns("Porc_Avance").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("Porc_Avance").Visible = True
            .Columns("Porc_Avance").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Porc_Avance_Saldo_Fab").Width = 60
            .Columns("Porc_Avance_Saldo_Fab").HeaderText = "% Avance"
            DirectCast(.Columns("Porc_Avance_Saldo_Fab").RenderControl, GridDoubleInputEditControl).DisplayFormat = "% #0.##"
            .Columns("Porc_Avance_Saldo_Fab").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("Porc_Avance_Saldo_Fab").Visible = True
            .Columns("Porc_Avance_Saldo_Fab").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Sub Sb_Formato_Grilla_OT5(ByVal _Grilla As GridPanel)

        With _Grilla

            .FrozenColumnCount = 1
            .ColumnHeader.RowHeight = 35
            .ShowRowGridIndex = True
            .GroupByRow.Visible = False
            '.UseAlternateRowStyle = True

            .Caption.Text = "DATOS DE FABRICACION<div align=""vcenter"">Informe del operario</div>"

            .Columns(0).GroupBoxEffects = GroupBoxEffects.None
            .Columns(0).CellStyles.Default.Background = New Background(Color.AliceBlue)

            For Each column As GridColumn In .Columns
                column.ColumnSortMode = ColumnSortMode.Multiple
                column.ResizeMode = ColumnResizeMode.MoveFollowingElements
                'column.AutoSizeMode = ColumnAutoSizeMode.AllCells
                '   column.HeaderStyles.Default.Margin = _Padding
                'column.HeaderText = "Masked TextBox"
            Next column

            Dim _DisplayIndex = 0

            .Columns("NUMDF").Width = 100
            .Columns("NUMDF").HeaderText = "Nro. DF."
            .Columns("NUMDF").Visible = True
            .Columns("NUMDF").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("OBRERO").Width = 100
            .Columns("OBRERO").HeaderText = "Cód."
            .Columns("OBRERO").Visible = True
            .Columns("OBRERO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOMBREOB").Width = 250
            .Columns("NOMBREOB").HeaderText = "Operario"
            .Columns("NOMBREOB").Visible = True
            .Columns("NOMBREOB").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOMBREMAQ").Width = 250
            .Columns("NOMBREMAQ").HeaderText = "Maquina"
            .Columns("NOMBREMAQ").Visible = True
            .Columns("NOMBREMAQ").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("UDAD").Width = 30
            .Columns("UDAD").HeaderText = "Ud"
            .Columns("UDAD").Visible = True
            .Columns("UDAD").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("REALJOR").Width = 60
            .Columns("REALJOR").HeaderText = "Fabricado"
            DirectCast(.Columns("REALJOR").RenderControl, GridDoubleInputEditControl).DisplayFormat = "#0.##"
            .Columns("REALJOR").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("REALJOR").Visible = True
            .Columns("REALJOR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FECHINI").Width = 70
            .Columns("FECHINI").HeaderText = "Fecha Ini."
            'DirectCast(.Columns("FECHINI").RenderControl, GridDateTimeInputEditControl)isplayFormat = "dd/MM/yyyy"
            .Columns("FECHINI").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("FECHINI").Visible = True
            .Columns("FECHINI").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("HORAINI").Width = 60
            .Columns("HORAINI").HeaderText = "Hora Ini."
            DirectCast(.Columns("HORAINI").RenderControl, GridDoubleInputEditControl).DisplayFormat = "#0.##,##"
            .Columns("HORAINI").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("HORAINI").Visible = True
            .Columns("HORAINI").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FECHTER").Width = 70
            .Columns("FECHTER").HeaderText = "Fecha Ter."
            'DirectCast(.Columns("FECHINI").RenderControl, GridDateTimeInputEditControl)isplayFormat = "dd/MM/yyyy"
            .Columns("FECHTER").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("FECHTER").Visible = True
            .Columns("FECHTER").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("HORATER").Width = 60
            .Columns("HORATER").HeaderText = "Hora Ter."
            DirectCast(.Columns("HORATER").RenderControl, GridDoubleInputEditControl).DisplayFormat = "#0.##,##"
            .Columns("HORATER").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("HORATER").Visible = True
            .Columns("HORATER").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TIEMPO").Width = 60
            .Columns("TIEMPO").HeaderText = "Tiempo"
            DirectCast(.Columns("TIEMPO").RenderControl, GridDoubleInputEditControl).DisplayFormat = "#0.##,##"
            .Columns("TIEMPO").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("TIEMPO").Visible = True
            .Columns("TIEMPO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Porc_Avance_Saldo_Fab").Width = 60
            .Columns("Porc_Avance_Saldo_Fab").HeaderText = "% Fabric."
            DirectCast(.Columns("Porc_Avance_Saldo_Fab").RenderControl, GridDoubleInputEditControl).DisplayFormat = "% #0.##"
            .Columns("Porc_Avance_Saldo_Fab").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("Porc_Avance_Saldo_Fab").Visible = True
            .Columns("Porc_Avance_Saldo_Fab").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOCAUDET").Width = 150
            .Columns("NOCAUDET").HeaderText = "Tag."
            .Columns("NOCAUDET").Visible = True
            .Columns("NOCAUDET").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1


        End With

    End Sub


    Private Sub Btn_Actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Actualizar.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Frm_Inf_Prod_Avance_OT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F5 Then
            Sb_Actualizar_Grilla()
        ElseIf e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Sub Sb_Grilla_RowsPostPaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < sender.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If sender.RowHeadersWidth < CInt(size.Width + 20) Then
                sender.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "vb.net", _
         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        'Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        'Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        'Dim _Nro_Ot As String = _Fila.Cells("NUMOT").Value

        'Select Case _Cabeza
        '   Case "Cant_Operaciones", "Operaciones_Realizadas", "Av_Op"
        'Dim Fm As New Frm_Proceso_Por_Operaciones(_Nro_Ot)
        'Fm.ShowDialog(Me)
        'Fm.Dispose()
        'End Select

    End Sub


    Sub Sb_Ocultar_encabezados_Super_Grilla(ByVal _Grilla As GridPanel)

        With _Grilla

            Dim NCol As Integer = .Columns.Count 'ColumnCount
            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 0 To NCol - 1

                Dim NomColumna = .Columns(i).Name.ToString()
                'Dim TipoColumna = .Columns(i).CellType.ToString 'DataGrid.Columns(i - 1).ValueType.ToString()

                .Columns(i).Visible = False
                .Columns(i).ReadOnly = True ' _ReadOnly
                .Columns(i).GroupBoxEffects = GroupBoxEffects.None
                '.Columns(i).CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
                '.Columns(i).EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIpAddressInputEditControl)
                '.Columns(i).HeaderStyles.Default.Image = My.Resources.ok_button 'CType(Resources.GetObject("resource.Image"), System.Drawing.Image)
                '.Columns(i).Name = "IpAddressInput"
                '.Columns(i).Width = 150
                'If Activar_Orden_Automatico Then

                'End If

            Next

        End With


        _Grilla.ShowToolTips = True
        _Grilla.GroupByRow.Visible = False

        _Grilla.MinRowHeight = 20
        _Grilla.AutoGenerateColumns = True

        _Grilla.DefaultVisualStyles.GroupByStyles.Default.Background = _Background1


        _Grilla.SelectionGranularity = SelectionGranularity.Cell

    End Sub

    Private Sub SuperGridControl1GetCellStyle(ByVal sender As Object, ByVal e As GridGetCellStyleEventArgs)

        Dim panel As GridPanel = e.GridPanel

        If panel.Name.Equals("Customers") Then
            If e.GridCell.GridColumn.Name.Equals("ContactTitle") = True Then
                If CStr(e.GridCell.Value).Equals("Owner") = True Then
                    e.Style.TextColor = Color.Red
                End If
            End If
        End If

        e.Style.TextColor = Color.Black

    End Sub

End Class
