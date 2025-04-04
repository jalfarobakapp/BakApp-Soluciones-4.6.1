Imports System.Windows.Forms.DataVisualization.Charting
Imports BkSpecialPrograms
Public Class Frm_Informe_Meson_Familias

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String
    Dim _Tbl_Informe As DataTable
    Dim _Cl_Informe As Cl_Informe_Meson_Familia
    Dim _Tx_Descripcion As String
    Dim _Correr_a_la_derecha As Boolean
    Dim _Rotacion = 0

    Dim _Tbl_Vista_Informe As DataTable
    Dim _Row_Vista As DataRow

    Dim _Tbl_Filtro_Mesones As DataTable
    Dim _Tbl_Filtro_Operaciones As DataTable
    Dim _Tbl_Filtro_Productos As DataTable
    Dim _Tbl_Filtro_Super_Familias As DataTable
    Dim _Tbl_Filtro_Familias As DataTable
    Dim _Tbl_Filtro_Sub_Familias As DataTable

    Dim _Filtro_Mesoness_Todos As Boolean
    Dim _Filtro_Operaciones_Todas As Boolean
    Dim _Filtro_Productos_Todos As Boolean
    Dim _Filtro_Super_Familias_Todas As Boolean
    Dim _Filtro_Familias_Todas As Boolean
    Dim _Filtro_Sub_Familias_Todas As Boolean

    Dim _Top, _Left As Integer

    Public Property Pro_Top() As Integer
        Get
            Return Me.Top
        End Get
        Set(ByVal value As Integer)
            _Top = value
        End Set
    End Property

    Public Property Pro_Left() As Integer
        Get
            Return Me.Left
        End Get
        Set(ByVal value As Integer)
            _Left = value
        End Set
    End Property

    Public Sub New(ByRef _Cl_Informe As Cl_Informe_Meson_Familia, _Correr_a_la_derecha As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dtp_Fecha_Desde.Value = Primerdiadelmes(Now.Date)
        Dtp_Fecha_Hasta.Value = ultimodiadelmes(Now.Date)

        If IsNothing(_Cl_Informe) Then
            _Cl_Informe = New Cl_Informe_Meson_Familia()
            _Cl_Informe.Tipo_Informe = Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Mesones
            _Cl_Informe.Tipo_Vista_Informe = Cl_Informe_Meson_Familia.Enum_Tipo_Vista_Informe.MESONES
            Dim _Fecha_Desde As Date = DateAdd(DateInterval.Year, -1, Now.Date)
            _Cl_Informe.Sb_Generar_Informe(_Fecha_Desde)
        End If

        Me._Cl_Informe = _Cl_Informe
        Me._Correr_a_la_derecha = _Correr_a_la_derecha

        Sb_Cargar_Combo_Vista_Informe()

    End Sub

    Private Sub Frm_Informe_Meson_Familias_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _Filtro_Mesoness_Todos = True
        _Filtro_Operaciones_Todas = True
        _Filtro_Productos_Todos = True
        _Filtro_Super_Familias_Todas = True
        _Filtro_Familias_Todas = True
        _Filtro_Sub_Familias_Todas = True


        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 9), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        If _Correr_a_la_derecha Then
            Me.Top = _Top + 10
            Me.Left = _Left + 10
        End If

        Sb_Actualizar_Grilla()

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_Detalle_MouseDown
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Num_Agrupador_Pie.ValueChanged, AddressOf Sb_Grafico_Pie_Acumulativo

        AddHandler Chk_Ver_Pie_3D.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Chk_Ver_Leyenda.CheckedChanged, AddressOf Rdb_CheckedChanged

        AddHandler Rdb_Pie_Codigo.CheckedChanged, AddressOf Rdb_Pie_CheckedChanged
        AddHandler Rdb_Pie_Descripcion.CheckedChanged, AddressOf Rdb_Pie_CheckedChanged

    End Sub

    Sub Sb_Actualizar_Grilla()

        _Row_Vista = Fx_Crea_Tabla_Con_Filtro(_Tbl_Vista_Informe,
                                         "CODIGO = '" & Cmb_Vista_Informe.SelectedValue & "'", "Id").Rows(0)

        Dim _Campo_Codigo As String = _Row_Vista.Item("CODIGO")
        Dim _Campo_Descripcion As String = _Row_Vista.Item("DESCRIPCION")

        _Tx_Descripcion = _Row_Vista.Item("DESCRIPCION")

        Dim _Condicion As String
        Dim _Agrupar As String

        _Condicion = Fx_Filtro_Detalle(True)

        If Cmb_Vista_Informe.SelectedValue = "Codmeson" Then
            _Agrupar = "Group By " & _Campo_Codigo & "," & _Campo_Descripcion & ",[Prom.Carga SubOt],[Prom.Carga xPiezas]"
            _Tbl_Informe = _Cl_Informe.Fx_Trae_Informe_X_Mesones(_Campo_Codigo, _Campo_Descripcion, _Condicion, _Agrupar)
        Else
            _Agrupar = "Group By " & _Campo_Codigo & "," & _Campo_Descripcion
            _Tbl_Informe = _Cl_Informe.Fx_Trae_Informe_X_SuperFamilias(_Campo_Codigo, _Campo_Descripcion, _Condicion, _Agrupar)
        End If

        With Grilla

            .DataSource = _Tbl_Informe

            OcultarEncabezadoGrilla(Grilla, False)

            .Columns("CODIGO").Width = 90 + 20
            .Columns("CODIGO").HeaderText = "Código"
            .Columns("CODIGO").Visible = True

            .Columns("DESCRIPCION").Width = 300 + 80
            .Columns("DESCRIPCION").HeaderText = _Tx_Descripcion
            .Columns("DESCRIPCION").Visible = True

            '.Columns("Dias").Width = 40
            '.Columns("Dias").HeaderText = "Días"
            '.Columns("Dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Dias").DefaultCellStyle.Format = "###,##"
            '.Columns("Dias").Visible = True

            .Columns("Fabricado").Width = 60
            .Columns("Fabricado").HeaderText = "C.P.Fabr."
            .Columns("Fabricado").ToolTipText = "Cantidad de productos fabricados en un año"
            .Columns("Fabricado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Fabricado").DefaultCellStyle.Format = "###,##"
            .Columns("Fabricado").Visible = True

            '.Columns("Productos").Width = 40
            '.Columns("Productos").HeaderText = "Prod"
            '.Columns("Productos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Productos").DefaultCellStyle.Format = "###,##"
            '.Columns("Productos").Visible = True

            .Columns("Prom.").Width = 60
            .Columns("Prom.").HeaderText = "Prom."
            .Columns("Prom.").ToolTipText = "Promedio de días en que se demora en fabricar este producto"
            .Columns("Prom.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Prom.").DefaultCellStyle.Format = "###,##.##"
            .Columns("Prom.").Visible = True

            If Cmb_Vista_Informe.SelectedValue = "Codmeson" Then

                .Columns("CODIGO").Width = 90
                .Columns("DESCRIPCION").Width = 280

                .Columns("Prom.Carga SubOt").Width = 60
                .Columns("Prom.Carga SubOt").HeaderText = "P. SOT"
                .Columns("Prom.Carga SubOt").ToolTipText = "Promedio de Sub OT esperando en mesón"
                .Columns("Prom.Carga SubOt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Prom.Carga SubOt").DefaultCellStyle.Format = "###,##"
                .Columns("Prom.Carga SubOt").Visible = (_Cl_Informe.Tipo_Informe = Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Mesones)

                .Columns("Prom.Carga xPiezas").Width = 60
                .Columns("Prom.Carga xPiezas").HeaderText = "P.XPz"
                .Columns("Prom.Carga xPiezas").ToolTipText = "Promedio de piezas esperando en mesón"
                .Columns("Prom.Carga xPiezas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Prom.Carga xPiezas").DefaultCellStyle.Format = "###,##"
                .Columns("Prom.Carga xPiezas").Visible = (_Cl_Informe.Tipo_Informe = Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Mesones)

            End If

            .Columns("Porc").Width = 60
            .Columns("Porc").HeaderText = "%"
            .Columns("Porc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc").DefaultCellStyle.Format = "% ###,##.#0"
            .Columns("Porc").Visible = True

        End With

        Sb_Grafico_Pie_Acumulativo()

    End Sub

    Sub Sb_Actualizar_Grilla2()

        Dim _Campo_Codigo As String
        Dim _Campo_Descripcion As String
        Dim _Condicion As String
        Dim _Agrupar As String

        If Cmb_Vista_Informe.SelectedValue = "Codmeson" Then
            _Cl_Informe.Tipo_Vista_Informe = Cl_Informe_Meson_Familia.Enum_Tipo_Vista_Informe.MESONES
        End If

        If Cmb_Vista_Informe.SelectedValue = 1 Then
            _Cl_Informe.Tipo_Vista_Informe = Cl_Informe_Meson_Familia.Enum_Tipo_Vista_Informe.SUPER_FAMILIA
            If Not _Correr_a_la_derecha Then
                _Cl_Informe.Codmeson = String.Empty
            End If
        End If

        Select Case _Cl_Informe.Tipo_Vista_Informe

            Case Cl_Informe_Meson_Familia.Enum_Tipo_Vista_Informe.MESONES
                Select Case _Cl_Informe.Tipo_Informe
                    Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Mesones
                        '_Condicion = "--Where Codmeson = '" & _Cl_Informe.Codmeson & "'"
                        _Campo_Codigo = "Codmeson" : _Campo_Descripcion = "Nommeson" : _Tx_Descripcion = "Nombre mesón"
                    Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_Super_Familia
                        _Condicion = "Where Codmeson = '" & _Cl_Informe.Codmeson & "'-- And FMPR = '" & _Cl_Informe.SuperFamilia & "'"
                        _Campo_Codigo = "FMPR" : _Campo_Descripcion = "NOKOFM" : _Tx_Descripcion = "Nombre Super Familia"
                    Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_SP_Familias
                        _Condicion = "Where Codmeson = '" & _Cl_Informe.Codmeson & "' And FMPR = '" & _Cl_Informe.SuperFamilia & "'"
                        _Campo_Codigo = "PFPR" : _Campo_Descripcion = "NOKOPF" : _Tx_Descripcion = "Nombre Familia"
                    Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_Sp_FM_SubFamilia
                        _Condicion = "Where Codmeson = '" & _Cl_Informe.Codmeson & "' And FMPR = '" & _Cl_Informe.SuperFamilia & "' And PFPR = '" & _Cl_Informe.Familia & "'"
                        _Campo_Codigo = "HFPR" : _Campo_Descripcion = "NOKOHF" : _Tx_Descripcion = "Nombre Sub-Familia"
                End Select

                _Agrupar = "Group By " & _Campo_Codigo & "," & _Campo_Descripcion & ",[Prom.Carga SubOt],[Prom.Carga xPiezas]"
                _Tbl_Informe = _Cl_Informe.Fx_Trae_Informe_X_Mesones(_Campo_Codigo, _Campo_Descripcion, _Condicion, _Agrupar)

            Case Cl_Informe_Meson_Familia.Enum_Tipo_Vista_Informe.SUPER_FAMILIA

                _Campo_Codigo = "FMPR" : _Campo_Descripcion = "NOKOFM" : _Tx_Descripcion = "Nombre Super Familia"

                Select Case _Cl_Informe.Tipo_Informe

                    Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Mesones
                        If Not String.IsNullOrEmpty(_Cl_Informe.Codmeson) Then
                            _Condicion = "Where FMPR = '" & _Cl_Informe.SuperFamilia & "' And Codmeson = '" & _Cl_Informe.Codmeson & "'"
                            _Campo_Codigo = "Codmeson" : _Campo_Descripcion = "Nommeson" : _Tx_Descripcion = "Nombre mesón"
                        End If
                    Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_SP_Familias
                        _Condicion = "Where Codmeson = '" & _Cl_Informe.Codmeson & "' And FMPR = '" & _Cl_Informe.SuperFamilia & "'"
                        _Campo_Codigo = "PFPR" : _Campo_Descripcion = "NOKOPF" : _Tx_Descripcion = "Nombre Familia"
                    Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_Sp_FM_SubFamilia
                        _Condicion = "Where Codmeson = '" & _Cl_Informe.Codmeson & "' And FMPR = '" & _Cl_Informe.SuperFamilia & "' And PFPR = '" & _Cl_Informe.Familia & "'"
                        _Campo_Codigo = "HFPR" : _Campo_Descripcion = "NOKOHF" : _Tx_Descripcion = "Nombre Sub-Familia"

                End Select

                _Agrupar = "Group By " & _Campo_Codigo & "," & _Campo_Descripcion
                _Tbl_Informe = _Cl_Informe.Fx_Trae_Informe_X_SuperFamilias(_Campo_Codigo, _Campo_Descripcion, _Condicion, _Agrupar)

        End Select



        With Grilla

            .DataSource = _Tbl_Informe

            OcultarEncabezadoGrilla(Grilla, False)

            .Columns("CODIGO").Width = 90
            .Columns("CODIGO").HeaderText = "Código"
            .Columns("CODIGO").Visible = True

            .Columns("DESCRIPCION").Width = 300
            .Columns("DESCRIPCION").HeaderText = _Tx_Descripcion
            .Columns("DESCRIPCION").Visible = True

            '.Columns("Dias").Width = 40
            '.Columns("Dias").HeaderText = "Días"
            '.Columns("Dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Dias").DefaultCellStyle.Format = "###,##"
            '.Columns("Dias").Visible = True

            .Columns("Fabricado").Width = 60
            .Columns("Fabricado").HeaderText = "C.P.Fabr."
            .Columns("Fabricado").ToolTipText = "Cantidad de productos fabricados en un año"
            .Columns("Fabricado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Fabricado").DefaultCellStyle.Format = "###,##"
            .Columns("Fabricado").Visible = True

            '.Columns("Productos").Width = 40
            '.Columns("Productos").HeaderText = "Prod"
            '.Columns("Productos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Productos").DefaultCellStyle.Format = "###,##"
            '.Columns("Productos").Visible = True

            .Columns("Prom.").Width = 60
            .Columns("Prom.").HeaderText = "Prom."
            .Columns("Prom.").ToolTipText = "Promedio de días en que se demora en fabricar este producto"
            .Columns("Prom.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Prom.").DefaultCellStyle.Format = "###,##.##"
            .Columns("Prom.").Visible = True

            If _Cl_Informe.Tipo_Vista_Informe = Cl_Informe_Meson_Familia.Enum_Tipo_Vista_Informe.MESONES Then

                .Columns("Prom.Carga SubOt").Width = 60
                .Columns("Prom.Carga SubOt").HeaderText = "P. SOT"
                .Columns("Prom.Carga SubOt").ToolTipText = "Promedio de Sub OT esperando en mesón"
                .Columns("Prom.Carga SubOt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Prom.Carga SubOt").DefaultCellStyle.Format = "###,##"
                .Columns("Prom.Carga SubOt").Visible = (_Cl_Informe.Tipo_Informe = Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Mesones)

                .Columns("Prom.Carga xPiezas").Width = 60
                .Columns("Prom.Carga xPiezas").HeaderText = "P.XPz"
                .Columns("Prom.Carga xPiezas").ToolTipText = "Promedio de piezas esperando en mesón"
                .Columns("Prom.Carga xPiezas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Prom.Carga xPiezas").DefaultCellStyle.Format = "###,##"
                .Columns("Prom.Carga xPiezas").Visible = (_Cl_Informe.Tipo_Informe = Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Mesones)

            End If

            .Columns("Porc").Width = 60
            .Columns("Porc").HeaderText = "%"
            .Columns("Porc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc").DefaultCellStyle.Format = "% ###,##.#0"
            .Columns("Porc").Visible = True

        End With

        Sb_Grafico_Pie_Acumulativo()

    End Sub

    Private Sub Rdb_Pie_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CType(sender, DevComponents.DotNetBar.Controls.CheckBoxX).Checked Then
            Sb_Grafico_Pie_Acumulativo()
        End If
    End Sub
    Private Sub Rdb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Sb_Grafico_Pie_Acumulativo()
    End Sub

    Sub Sb_Grafico_Pie_Acumulativo()

        Dim _TblPie As DataTable = Fx_Crea_Tabla_Con_Filtro(_Tbl_Informe, "1 > 0", "Porc")
        Dim _Coun As Integer = _TblPie.Rows.Count
        ' Populate series data
        Dim _yValues(_Coun - 1) As Double '= {65.62, 75.54, 60.45, 55.73, 70.42}
        Dim _xValues(_Coun - 1) As String '= {"France", "Canada", "UK", "USA", "Italy"}

        Dim series1 As Series = Grafico_Pie.Series(0)

        Dim _i = 0

        For Each _Fila As DataRow In _TblPie.Rows

            _yValues(_i) = _Fila.Item("Porc")

            Dim _Porc = FormatNumber(_Fila.Item("Porc"), 0) 'FormatNumber(_Fila.Item("Porc") * 100, 1) ' FormatPercent(_Fila.Item("Porc"), 1)
            Dim _Codigo = _Fila.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Fila.Item("Descripcion").ToString.Trim

            _Descripcion = Replace(_Descripcion, "MESON ", "")
            _Descripcion = Mid(_Descripcion, 1, 17)

            If Rdb_Pie_Codigo.Checked Then
                _xValues(_i) = _Porc & " - " & _Codigo
            ElseIf Rdb_Pie_Descripcion.Checked Then
                _xValues(_i) = _Descripcion
            End If

            _i += 1

        Next

        series1.Points.DataBindXY(_xValues, _yValues)

        _i = 0

        For Each _Fila As DataRow In _TblPie.Rows

            _yValues(_i) = _Fila.Item("Porc")

            Dim _Porc = FormatNumber(_Fila.Item("Porc"), 0) 'FormatPercent(_Fila.Item("Porc"), 1) ' FormatPercent(_Fila.Item("Porc"), 1)
            Dim _Codigo = _Fila.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Fila.Item("Descripcion").ToString.Trim

            _Descripcion = Replace(_Descripcion, "MESON ", "")
            _Descripcion = Mid(_Descripcion, 1, 17)

            series1.Points.Item(_i).ToolTip = _Codigo & " - " & _Descripcion & " (" & _Porc & ")"
            _i += 1

        Next


        Grafico_Pie.ChartAreas(0).BackColor = Color.FromArgb(Global_camvasColor)

        Dim _Num_Agrupador As Double = Num_Agrupador_Pie.Value / 100


        'If Not Chk_Agrupar_Pie.Checked Then _Num_Agrupador = 0

        '' Establezca el umbral bajo el cual se recogerán todos los puntos
        series1("CollectedThreshold") = Num_Agrupador_Pie.Value '- 0.01 ' _Num_Agrupador * 10 '0.1
        '' Establecer el tipo de umbral para ser un porcentaje del PIE Grafico
        '' Cuando se establece en falso, esta propiedad usa el valor real para determinar el umbral recolectado
        series1("CollectedThresholdUsePercent") = True 'Chk_Agrupar_Pie.Checked ' "true"

        '' Establecer la etiqueta de la porción de PIE Grafico recogido
        series1("CollectedLabel") = "Grupo de ventas <= " & FormatPercent(_Num_Agrupador, 0)

        '' Establecer el texto de la leyenda del sector de PIE Grafico recogido
        series1("CollectedLegendText") = "Grupo de ventas <= " & FormatPercent(_Num_Agrupador, 0) '"Otros 02"

        '' Establecer el sector de PIE Grafico recogido a explotar
        series1("CollectedSliceExploded") = "true"

        '' Establecer el color de la porción de PIE Grafico recogido
        series1("CollectedColor") = "Green"

        '' Establezca la información sobre herramientas de la porción de gráfico recopilada
        series1("CollectedToolTip") = "Grupo de ventas <= " & FormatPercent(_Num_Agrupador, 0) '"Otros 03"


        Select Case Global_Thema
            Case Enum_Themas.Claro
                series1.Palette = ChartColorPalette.BrightPastel
                series1.LabelForeColor = Color.FromArgb(32, 32, 32)
            Case Enum_Themas.Gris
                series1.Palette = ChartColorPalette.BrightPastel
                series1.LabelForeColor = Color.FromArgb(32, 32, 32)
            Case Enum_Themas.Oscuro
                series1.Palette = ChartColorPalette.Chocolate
                series1.LabelForeColor = Color.FromArgb(226, 226, 226)
                Grafico_Pie.Legends(0).ForeColor = Color.FromArgb(226, 226, 226)
            Case Enum_Themas.Azul
                series1.Palette = ChartColorPalette.SeaGreen
                series1.LabelForeColor = Color.FromArgb(60, 64, 67)
                Grafico_Pie.Legends(0).ForeColor = Color.FromArgb(60, 64, 67)
        End Select


        Grafico_Pie.ChartAreas(0).Area3DStyle.Enable3D = Chk_Ver_Pie_3D.Checked


        Grafico_Pie.Legends(0).Enabled = Chk_Ver_Leyenda.Checked
        Grafico_Pie.Legends(0).BackColor = Color.FromArgb(Global_camvasColor)


        'SEIRES1.LabelStyle.Font = New Font("Arial", 10)


        ' MUESTRA EL PORCENTAJE EN LAS ETIQUETAS DEL GRAFICO

        If Rdb_Pie_Codigo.Checked Then
            series1.Label = "#PERCENT{P2}"
        Else
            series1.Label = String.Empty
        End If

        'Chart1.ChartAreas("Default")
        series1.Font = New Font("Arial", 7)


        ' Set chart type and title
        series1.ChartType = SeriesChartType.Pie ' DirectCast([Enum].Parse(GetType(SeriesChartType), comboBoxChartType.Text, True), SeriesChartType)
        'Grafico_Pie.Titles(0).Text = "Porcentaje de ventas según selección" 'comboBoxChartType.Text + " Chart"

        ' Set labels style

        If Chk_Ver_Pie_3D.Checked Then
            series1("PieLabelStyle") = "Outside" ' comboBoxLabelStyle.Text
        Else
            series1("PieLabelStyle") = Nothing
        End If


        ' Set Doughnut hole size
        'series1("Default")("DoughnutRadius") = "Radio Tex" 'comboBoxRadius.Text

        ' Disable Doughnut hole size control for Pie chart
        'comboBoxRadius.Enabled = (comboBoxChartType.Text <> "Pie")

        ' Explode selected country
        For Each point As DataPoint In Grafico_Pie.Series(0).Points
            'point("")
            point("Exploded") = "false"
            If point.AxisLabel = "SALMON" Then
                point("Exploded") = "true"
            End If
        Next

    End Sub





    Private Sub Sb_Grilla_Detalle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    Sb_Ver_Sub_Menu_Contextual()
                End If
            End With
        End If
    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_Informe, Me, "Informe")
    End Sub

    Sub Sb_Revisar_Sub_Informe(_Sub_Informe As Cl_Informe_Meson_Familia.Enum_Tipo_Informe)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Codigo = _Fila.Cells("CODIGO").Value.ToString.Trim
        Dim _Des = UCase(Trim(_Fila.Cells(1).Value))

        Dim _Texto_Fm As String

        'If _Cod = "ZZZ" Then
        '    _Texto_Fm = "DESDE " & UCase(_Informe.ToString) & ": TODAS"
        'Else
        '    _Texto_Fm = "DESDE " & UCase(_Informe.ToString) & ": " & Trim(_Des)
        'End If

        Dim _Old_Tipo_Informe As Cl_Informe_Meson_Familia.Enum_Tipo_Informe = _Cl_Informe.Tipo_Informe
        _Cl_Informe.Tipo_Informe = _Sub_Informe

        Select Case _Sub_Informe
            Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Mesones
            Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_Super_Familia
                _Cl_Informe.Codmeson = _Codigo
            Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_SP_Familias
                _Cl_Informe.SuperFamilia = _Codigo
            Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_Sp_FM_SubFamilia
                _Cl_Informe.Familia = _Codigo
        End Select

        Dim Fm As New Frm_Informe_Meson_Familias(_Cl_Informe, True)
        Fm.Pro_Top = Me.Top
        Fm.Pro_Left = Me.Left

        Fm.ShowDialog(Me)
        Fm.Dispose()

        Select Case _Sub_Informe
            Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Mesones
            Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_Super_Familia
                _Cl_Informe.SuperFamilia = String.Empty
            Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_SP_Familias
                _Cl_Informe.Familia = String.Empty
            Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_Sp_FM_SubFamilia
                _Cl_Informe.SubFamilia = String.Empty
        End Select

        _Cl_Informe.Tipo_Informe = _Old_Tipo_Informe

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        Sb_Ver_Sub_Menu_Contextual()
    End Sub

    Sub Sb_Ver_Sub_Menu_Contextual()

        Btn_Informe_X_Mesones.Visible = False
        Btn_Informe_X_Super_Familias.Visible = False
        Btn_Informe_X_Familias.Visible = False
        Btn_Informe_X_Sub_Familias.Visible = False

        Select Case _Cl_Informe.Tipo_Vista_Informe
            Case Cl_Informe_Meson_Familia.Enum_Tipo_Vista_Informe.MESONES
                Select Case _Cl_Informe.Tipo_Informe
                    Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Mesones
                        Btn_Informe_X_Super_Familias.Visible = True
                    Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_Super_Familia
                        Btn_Informe_X_Familias.Visible = True
                    Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_SP_Familias
                        Btn_Informe_X_Sub_Familias.Visible = True
                    Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_Sp_FM_SubFamilia
                End Select
            Case Cl_Informe_Meson_Familia.Enum_Tipo_Vista_Informe.SUPER_FAMILIA
                Select Case _Cl_Informe.Tipo_Informe
                    Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Mesones
                        Btn_Informe_X_Super_Familias.Visible = True
                    Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_Super_Familia
                        Btn_Informe_X_Mesones.Visible = True
                        Btn_Informe_X_Familias.Visible = True
                    Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_SP_Familias
                        Btn_Informe_X_Mesones.Visible = True
                        Btn_Informe_X_Sub_Familias.Visible = True
                        Btn_Informe_X_Mesones.Visible = True
                    Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_Sp_FM_SubFamilia
                End Select
        End Select

        ShowContextMenu(Menu_Contextual_Informe)

    End Sub

    Private Sub Btn_Informe_X_Super_Familias_Click(sender As Object, e As EventArgs) Handles Btn_Informe_X_Super_Familias.Click
        Sb_Revisar_Sub_Informe(Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_Super_Familia)
    End Sub

    Private Sub Btn_Informe_X_Familias_Click(sender As Object, e As EventArgs) Handles Btn_Informe_X_Familias.Click
        Sb_Revisar_Sub_Informe(Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_SP_Familias)
    End Sub

    Private Sub Btn_Informe_X_Sub_Familias_Click(sender As Object, e As EventArgs) Handles Btn_Informe_X_Sub_Familias.Click
        Sb_Revisar_Sub_Informe(Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_Sp_FM_SubFamilia)
    End Sub

    Private Sub Btn_Actualizar_Informe_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar_Informe.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Btn_Informe_X_Mesones_Click(sender As Object, e As EventArgs) Handles Btn_Informe_X_Mesones.Click
        Sb_Revisar_Sub_Informe(Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Mesones)
    End Sub

    Private Sub Cmb_Vista_Informe_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Vista_Informe.SelectedIndexChanged
        'Select Case Cmb_Vista_Informe.SelectedValue
        '    Case 0
        '        _Cl_Informe.Tipo_Vista_Informe = Cl_Informe_Meson_Familia.Enum_Tipo_Vista_Informe.MESONES
        '        _Cl_Informe.Codmeson = String.Empty
        '    Case 1
        '        _Cl_Informe.Tipo_Vista_Informe = Cl_Informe_Meson_Familia.Enum_Tipo_Vista_Informe.SUPER_FAMILIA
        '        _Cl_Informe.Codmeson = String.Empty
        '        _Cl_Informe.SuperFamilia = String.Empty
        'End Select
        'Sb_Actualizar_Grilla()
    End Sub

    Private Sub Btn_Ver_Meson_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Meson.Click

        Dim _Fila_Potpr As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        'Dim _Numot As String = _Fila_Potpr.Cells("NUMOT").Value
        Dim _Codmeson As String = _Fila_Potpr.Cells("CODIGO").Value

        Dim Fm As New Frm_Busqueda_OT
        Fm.Codemeson = _Codmeson
        'Fm.Numot = _Numot
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Grafico_Anual_Click(sender As Object, e As EventArgs) Handles Btn_Grafico_Anual.Click

        Dim _Fila_Potpr As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Codigo As String = _Fila_Potpr.Cells("CODIGO").Value
        Dim _Descripcion As String = _Fila_Potpr.Cells("DESCRIPCION").Value

        Dim _Fecha_Desde As DateTime = _Sql.Fx_Trae_Dato(_Cl_Informe.Tabla_Paso, "Min(FIOT)")
        Dim _Fecha_Hasta As DateTime = _Sql.Fx_Trae_Dato(_Cl_Informe.Tabla_Paso, "Max(FIOT)")

        Dim _Campo_Codigo As String
        Dim _Campo_Descripcion As String
        Dim _Condicion As String

        '_Cl_Informe.Tipo_Informe = Cmb_Vista_Informe.SelectedValue

        Select Case _Cl_Informe.Tipo_Vista_Informe

            Case Cl_Informe_Meson_Familia.Enum_Tipo_Vista_Informe.MESONES
                Select Case _Cl_Informe.Tipo_Informe
                    Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Mesones
                        '_Condicion = "--Where Codmeson = '" & _Cl_Informe.Codmeson & "'"
                        _Campo_Codigo = "Codmeson" : _Campo_Descripcion = "Nommeson" : _Tx_Descripcion = "Nombre mesón"
                    Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_Super_Familia
                        _Condicion = "And Codmeson = '" & _Cl_Informe.Codmeson & "'-- And FMPR = '" & _Cl_Informe.SuperFamilia & "'"
                        _Campo_Codigo = "FMPR" : _Campo_Descripcion = "NOKOFM" : _Tx_Descripcion = "Nombre Super Familia"
                    Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_SP_Familias
                        _Condicion = "And Codmeson = '" & _Cl_Informe.Codmeson & "' And FMPR = '" & _Cl_Informe.SuperFamilia & "'"
                        _Campo_Codigo = "PFPR" : _Campo_Descripcion = "NOKOPF" : _Tx_Descripcion = "Nombre Familia"
                    Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_Sp_FM_SubFamilia
                        _Condicion = "And Codmeson = '" & _Cl_Informe.Codmeson & "' And FMPR = '" & _Cl_Informe.SuperFamilia & "' And PFPR = '" & _Cl_Informe.Familia & "'"
                        _Campo_Codigo = "HFPR" : _Campo_Descripcion = "NOKOHF" : _Tx_Descripcion = "Nombre Sub-Familia"
                End Select

            Case Cl_Informe_Meson_Familia.Enum_Tipo_Vista_Informe.SUPER_FAMILIA

                _Campo_Codigo = "FMPR" : _Campo_Descripcion = "NOKOFM" : _Tx_Descripcion = "Nombre Super Familia"

                Select Case _Cl_Informe.Tipo_Informe

                    Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Mesones
                        If Not String.IsNullOrEmpty(_Cl_Informe.Codmeson) Then
                            _Condicion = "And FMPR = '" & _Cl_Informe.SuperFamilia & "' And Codmeson = '" & _Cl_Informe.Codmeson & "'"
                            _Campo_Codigo = "Codmeson" : _Campo_Descripcion = "Nommeson" : _Tx_Descripcion = "Nombre mesón"
                        End If
                    Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_SP_Familias
                        _Condicion = "And Codmeson = '" & _Cl_Informe.Codmeson & "' And FMPR = '" & _Cl_Informe.SuperFamilia & "'"
                        _Campo_Codigo = "PFPR" : _Campo_Descripcion = "NOKOPF" : _Tx_Descripcion = "Nombre Familia"
                    Case Cl_Informe_Meson_Familia.Enum_Tipo_Informe.Ms_Sp_FM_SubFamilia
                        _Condicion = "And Codmeson = '" & _Cl_Informe.Codmeson & "' And FMPR = '" & _Cl_Informe.SuperFamilia & "' And PFPR = '" & _Cl_Informe.Familia & "'"
                        _Campo_Codigo = "HFPR" : _Campo_Descripcion = "NOKOHF" : _Tx_Descripcion = "Nombre Sub-Familia"

                End Select

        End Select

        'Fecha_Asignacion
        Dim _Ds1 As DataSet = _Cl_Informe.Fx_Ds_Graficos(_Campo_Codigo, _Campo_Descripcion, _Codigo, _Descripcion, "Fabricar", "Fecha_Fabr_MQ", _Fecha_Desde, _Fecha_Hasta, _Condicion)
        Dim _Ds2 As DataSet = _Cl_Informe.Fx_Ds_Graficos(_Campo_Codigo, _Campo_Descripcion, _Codigo, _Descripcion, "Fabricar", "Fecha_Asignacion", _Fecha_Desde, _Fecha_Hasta, _Condicion)

        Dim Fm As New Frm_Grafico1
        Fm.TblGrafico1 = _Ds1.Tables(0)
        Fm.TblGrafico2 = _Ds2.Tables(0)
        Fm.Titulo = _Descripcion
        Fm.Descripcion1 = "Fabricados"
        Fm.Descripcion2 = "Asignados"
        Fm.Fecha_Desde = _Fecha_Desde
        Fm.Fecha_Hasta = _Fecha_Hasta
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Frm_Informe_Meson_Familias_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
        If e.KeyValue = Keys.F5 Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Btn_Totar_Pie_Derecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Totar_Pie_Derecha.Click
        _Rotacion -= 5
        If _Rotacion <= 0 Then
            _Rotacion = 360
        End If
        Grafico_Pie.Series(0)("PieStartAngle") = _Rotacion.ToString()
    End Sub

    Private Sub Btn_Totar_Pie_Izquierda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Totar_Pie_Izquierda.Click
        _Rotacion += 5
        If _Rotacion >= 360 Then
            _Rotacion = 0
        End If
        Grafico_Pie.Series(0)("PieStartAngle") = _Rotacion.ToString()
    End Sub

    Sub Sb_Cargar_Combo_Vista_Informe()

        Consulta_sql = My.Resources.Recursos_Informe_Meson_Familias.Cargar_Tabla_Vista_del_Cubo
        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Tbl_Vista_Informe = _Ds.Tables(0)

        Dim _Tbl = _Ds.Tables(1)

        caract_combo(Cmb_Vista_Informe)
        Cmb_Vista_Informe.DataSource = _Tbl
        Cmb_Vista_Informe.SelectedValue = "Empresa"

        _Row_Vista = Fx_Crea_Tabla_Con_Filtro(_Tbl_Vista_Informe,
                                         "CODIGO = '" & Cmb_Vista_Informe.SelectedValue & "'", "Id").Rows(0)

    End Sub

    Private Sub Btn_Filtro_Pro_Productos_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_Productos.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FIOT BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        _SqlFiltro_Fechas = String.Empty

        Dim _Sql_Filtro_Condicion_Extra = "And Codigo In (Select Distinct Codigo From " &
                                          _Cl_Informe.Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Productos_Todos, False) Then

            _Tbl_Filtro_Productos = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Productos_Todos = _Filtrar.Pro_Filtro_Todas

            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Btn_Filtro_Pro_Super_Familias_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_Super_Familias.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FIOT BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        _SqlFiltro_Fechas = String.Empty

        Dim _Sql_Filtro_Condicion_Extra = "And KOFM In (Select Distinct FMPR From " &
                                          _Cl_Informe.Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Super_Familias,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Super_Familia, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Super_Familias_Todas) Then

            _Tbl_Filtro_Super_Familias = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Super_Familias_Todas = _Filtrar.Pro_Filtro_Todas

            'If Cmb_Vista_Informe.SelectedValue = "FMPR" Then
            '    Sb_Actualizar_Grilla()
            'Else
            '    Cmb_Vista_Informe.SelectedValue = "FMPR"
            'End If

            Sb_Actualizar_Grilla()

        End If

    End Sub

    Private Sub Btn_Filtro_Pro_Familias_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_Familias.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FIOT BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        _SqlFiltro_Fechas = String.Empty

        Dim _Sql_Filtro_Condicion_Extra = String.Empty
        Dim _Filtro_Extra_Familias = String.Empty

        If Not _Filtro_Super_Familias_Todas Then
            If Not (_Tbl_Filtro_Super_Familias Is Nothing) Then
                If _Tbl_Filtro_Super_Familias.Rows.Count Then

                    Dim _Fl_Super_Familias = Generar_Filtro_IN(_Tbl_Filtro_Super_Familias, "Chk", "Codigo", False, True, "'")
                    _Filtro_Extra_Familias = vbCrLf & "And FMPR In " & _Fl_Super_Familias

                End If
            End If
        End If

        _Sql_Filtro_Condicion_Extra = "And KOPF In (Select Distinct PFPR From " &
                                       _Cl_Informe.Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")" & _Filtro_Extra_Familias

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Familias,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Familia, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Familias_Todas) Then

            _Tbl_Filtro_Familias = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Familias_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "PFPR" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "PFPR"
            End If
        End If

    End Sub

    Private Sub Btn_Filtro_Pro_Sub_Familias_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_Sub_Familias.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FIOT BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        _SqlFiltro_Fechas = String.Empty

        Dim _Sql_Filtro_Condicion_Extra = String.Empty
        Dim _Filtro_Extra_Familias = String.Empty

        If Not _Filtro_Super_Familias_Todas Then
            If Not (_Tbl_Filtro_Super_Familias Is Nothing) Then
                If _Tbl_Filtro_Super_Familias.Rows.Count Then

                    Dim _Fl_Super_Familias = Generar_Filtro_IN(_Tbl_Filtro_Super_Familias, "Chk", "Codigo", False, True, "'")
                    _Filtro_Extra_Familias = vbCrLf & "And FMPR In " & _Fl_Super_Familias

                End If
            End If
        End If

        If Not _Filtro_Familias_Todas Then
            If Not (_Tbl_Filtro_Familias Is Nothing) Then
                If _Tbl_Filtro_Familias.Rows.Count Then

                    Dim _Fl_Familias = Generar_Filtro_IN(_Tbl_Filtro_Familias, "Chk", "Codigo", False, True, "'")
                    _Filtro_Extra_Familias += vbCrLf & "And FMPR+PFPR In " & _Fl_Familias

                End If
            End If
        End If

        _Sql_Filtro_Condicion_Extra = "And KOPF In (Select Distinct PFPR From " &
                                       _Cl_Informe.Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")" & vbCrLf &
                                       _Filtro_Extra_Familias

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Sub_Familias,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Sub_Familia, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Sub_Familias_Todas) Then

            _Tbl_Filtro_Sub_Familias = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Sub_Familias_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "HFPR" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "HFPR"
            End If

        End If

    End Sub

    Private Sub Btn_Filtrar_Productos_Click(sender As Object, e As EventArgs) Handles Btn_Filtrar_Productos.Click
        ShowContextMenu(Menu_Contextual_Filtros_Productos)
    End Sub

    Private Sub Btn_Filtrar_Mesones_Click(sender As Object, e As EventArgs) Handles Btn_Filtrar_Mesones.Click
        ShowContextMenu(Menu_Contextual_Filtros_Mesones_Operaciones)
    End Sub

    Private Sub Btn_Filtro_Mesones_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Mesones.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FIOT BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        _SqlFiltro_Fechas = String.Empty

        Dim _Sql_Filtro_Condicion_Extra = "And Codmeson In (Select Distinct Codmeson From " &
                                          _Cl_Informe.Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_Pdc_Mesones"
        _Filtrar.Campo = "Codmeson"
        _Filtrar.Descripcion = "Nommeson"

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Mesoness_Todos, False) Then

            _Tbl_Filtro_Mesones = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Mesoness_Todos = _Filtrar.Pro_Filtro_Todas

            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Btn_Filtro_Opreciones_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Opreciones.Click

        Dim _SqlFiltro_Fechas As String

        _SqlFiltro_Fechas = "Where FIOT BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                             Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        _SqlFiltro_Fechas = String.Empty

        Dim _Sql_Filtro_Condicion_Extra = "And Operacion In (Select Distinct Operacion From " &
                                          _Cl_Informe.Tabla_Paso & vbCrLf & _SqlFiltro_Fechas & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "POPER"
        _Filtrar.Campo = "OPERACION"
        _Filtrar.Campo = "NOMBREOP"

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Mesoness_Todos, False) Then

            _Tbl_Filtro_Operaciones = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Operaciones_Todas = _Filtrar.Pro_Filtro_Todas

            Sb_Actualizar_Grilla()
        End If

    End Sub

    Function Fx_Filtro_Detalle(_Incluye_Fechas As Boolean)

        Dim _Filtro_Mesones,
            _Filtro_Operaciones,
            _Filtro_Productos,
            _Filtro_SuperFamilias,
            _Filtro_Familias,
            _Filtro_Sub_Familias As String

        If _Filtro_Mesoness_Todos Then
            _Filtro_Mesones = String.Empty
        Else
            _Filtro_Mesones = Generar_Filtro_IN(_Tbl_Filtro_Mesones, "Chk", "Codigo", False, True, "'")
            _Filtro_Mesones = "And Codmeson IN " & _Filtro_Mesones & vbCrLf
        End If

        If _Filtro_Operaciones_Todas Then
            _Filtro_Operaciones = String.Empty
        Else
            _Filtro_Operaciones = Generar_Filtro_IN(_Tbl_Filtro_Operaciones, "Chk", "Codigo", False, True, "'")
            _Filtro_Operaciones = "And Operacion IN " & _Filtro_Operaciones & vbCrLf
        End If

        If _Filtro_Productos_Todos Then
            _Filtro_Productos = String.Empty
        Else
            _Filtro_Productos = Generar_Filtro_IN(_Tbl_Filtro_Productos, "Chk", "Codigo", False, True, "'")
            _Filtro_Productos = "And Codigo IN " & _Filtro_Productos & vbCrLf
        End If

        If _Filtro_Super_Familias_Todas Then
            _Filtro_SuperFamilias = String.Empty
        Else
            _Filtro_SuperFamilias = Generar_Filtro_IN(_Tbl_Filtro_Super_Familias, "Chk", "Codigo", False, True, "'")
            _Filtro_SuperFamilias = "And FMPR In " & _Filtro_SuperFamilias & vbCrLf
        End If

        If _Filtro_Familias_Todas Then
            _Filtro_Familias = String.Empty
        Else
            _Filtro_Familias = Generar_Filtro_IN(_Tbl_Filtro_Familias, "Chk", "Codigo", False, True, "'")
            _Filtro_Familias = "And FMPR+PFPR In " & _Filtro_Familias & vbCrLf
        End If

        If _Filtro_Sub_Familias_Todas Then
            _Filtro_Sub_Familias = String.Empty
        Else
            _Filtro_Sub_Familias = Generar_Filtro_IN(_Tbl_Filtro_Sub_Familias, "Chk", "Codigo", False, True, "'")
            _Filtro_Sub_Familias = "And FMPR+PFPR+HFPR In " & _Filtro_Sub_Familias & vbCrLf
        End If

        '---------------------------

        Dim _SqlFiltro_Fechas As String = String.Empty

        If _Incluye_Fechas Then

            _SqlFiltro_Fechas = "And FIOT BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                                 Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

        End If

        'Dim _Filtro_Tipr As String

        'If Not Chk_Incluir_Conceptos.Checked Then
        '    _Filtro_Tipr = "And PRCT = 0" & vbCrLf
        'End If

        Dim _Filtro_Externo = _Filtro_Mesones &
                              _Filtro_Operaciones &
                              _Filtro_Productos &
                              _Filtro_SuperFamilias &
                              _Filtro_Familias &
                              _Filtro_Sub_Familias &
                              _SqlFiltro_Fechas

        Return _Filtro_Externo

    End Function

End Class
