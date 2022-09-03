Imports DevComponents.DotNetBar
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms
Imports System.Drawing
'Imports Lib_Bakapp_VarClassFunc
Imports System.Data.SqlClient

Public Class Frm_Inf_Ventas_X_Vendedor_03

    Public _Titulo_Del_Grafico As String
    Public _TblGrafico As DataTable

    Sub Sb_Llenar_Grafico(ByVal _Grafico As Chart, _
                          ByVal _TblGrafico As DataTable, _
                          ByVal _Serie As Integer, _
                          Optional ByVal _Tiene_Varianza As Boolean = False)

        'SQL_ServerClass.Sb_Abrir_Conexion(cn1)
        'Dim Comando = New SqlCommand(SqlQuery, cn1)
        'Dim myReader As SqlDataReader = Comando.ExecuteReader()



        '        ' Initializes a new instance of the DataView class
        '       Dim firstView As New DataView(custDS.Tables(0))

        ''     ' Since the DataView implements IEnumerable, pass the reader directly into
        ''   '   the DataBind method with the name of the Columns selected in the query    
        '      Chart1.Series("Default").Points.DataBindXY(firstView, "Name", firstView, "Sales")


        With _Grafico

            ' Set Grid lines and tick marks interval
            .Series(_Serie).XValueType = ChartValueType.Double

            ' Set X axis automatic fitting style
            .ChartAreas(_Serie).AxisX.LabelAutoFitStyle = _
             LabelAutoFitStyles.DecreaseFont 'ON LabelAutoFitStyle.DecreaseFont Or LabelAutoFitStyle.IncreaseFont Or LabelAutoFitStyle.WordWrap

            '
            .ChartAreas(_Serie).AxisX.Interval = 1
            .ChartAreas(_Serie).AxisY.Interval = 0
            .ChartAreas(_Serie).AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount

            .ChartAreas(_Serie).AxisX.MajorGrid.Interval = 0
            .ChartAreas(_Serie).AxisX.MajorTickMark.Interval = 1
            .ChartAreas(_Serie).AxisX.MinorGrid.Interval = 0.5
            .ChartAreas(_Serie).AxisX.MinorTickMark.Interval = 0.5
            .ChartAreas(_Serie).AxisX.IsMarginVisible = True
            ' Calculate Mean
            'Dim mean As Double = .DataManipulator.Statistics.Mean(Serie)

            Dim _FirstView As New DataView(_TblGrafico)

            .Series(_Serie).Points.DataBindXY(_FirstView, "KOFULIDO", _FirstView, "VALORNETO")

            ' Set X axis labels format
            '.ChartAreas("Default").AxisX.LabelStyle.Format = "D"

            .ChartAreas(_Serie).AxisY.IsLabelAutoFit = True
            '.ChartAreas(_Serie).AxisY.LabelAutoFitStyle = LabelAutoFitStyles.None
            .ChartAreas(_Serie).AxisY.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30

            ' Disable end labels for the X axis
            '.ChartAreas(_Serie).AxisX.LabelStyle.IsEndLabelVisible = True

            ' Use variable count algorithm to generate labels.
            .ChartAreas(_Serie).AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount


            ' Set interval of X axis to zero, which represents an "Auto" value.
            '.ChartAreas(_Serie).AxisY.Interval = 0

            ' Set series point labels format
            .Series(_Serie).LabelFormat = "C0"
            ' Set Y axis labels format
            .ChartAreas(_Serie).AxisY.LabelStyle.Format = "C0"

            ' Enable 3D charts
            .ChartAreas(_Serie).Area3DStyle.Enable3D = True

            .Titles(0).Text = _Titulo_Del_Grafico
            .Titles(1).Text = String.Empty
            'Return
            ' Loop through all series
            Dim series As Series
            For Each series In _Grafico.Series
                ' Set empty points visual appearance attributes

                


                series.EmptyPointStyle.Color = Color.Red
                series.EmptyPointStyle.BorderWidth = 1
                series.EmptyPointStyle.BorderDashStyle = ChartDashStyle.Dash
                series.EmptyPointStyle.MarkerSize = 14
                series.EmptyPointStyle.MarkerStyle = MarkerStyle.Cross
                series.EmptyPointStyle.MarkerBorderColor = Color.Black
                series.EmptyPointStyle.MarkerColor = Color.Red

                ' Adjust visual appearance attributes depending on the user selection
                'If series.emptyPointAppearanceList.SelectedItem.Text = "Transparent" Then
                'series.EmptyPointStyle.BorderWidth = 0
                'series.EmptyPointStyle.MarkerStyle = MarkerStyle.None
                'Else
                'If EmptyPointAppearanceList.SelectedItem.Text = "Line" Then
                'series.EmptyPointStyle.BorderDashStyle = ChartDashStyle.Dot
                'series.EmptyPointStyle.BorderWidth = 1
                'series.EmptyPointStyle.Color = series.Color
                'Else
                'If EmptyPointAppearanceList.SelectedItem.Text = "Marker" Then
                'series.EmptyPointStyle.BorderWidth = 0
                'series.EmptyPointStyle.MarkerSize = 8
                'series.EmptyPointStyle.MarkerStyle = MarkerStyle.Diamond
                'series.EmptyPointStyle.MarkerColor = series.Color
                'End If
                'End If
                'End If
            Next series

            ' Set empty points values of Series1 to average.
            '.Series(Serie)("EmptyPointValue") = "Average"
            .Series(_Serie)("EmptyPointValue") = "Zero"





            ' myReader.Close()
            ' SQL_ServerClass.Sb_Cerrar_Conexion(cn1)

        End With

        Return


        With _Grafico

            '.Series.Add("Serie2")
            '.DataSource = Tabla

            'Asociar las series con los nombres de las columnas

            .Series.Add("Serie2")
            .Series("Serie2").ChartType = SeriesChartType.Line
            .Series("Serie2").BorderWidth = 2

            .Series(0).Points.AddXY(.Series(0).XValueMember, .Series(0).YValueMembers)

            .Series(0).LegendText = "Cantidad"
            .DataBind()
        End With

    End Sub

    Private Sub Frm_Inf_Ventas_X_Vendedor_03_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Llenar_Grafico(Grafico1, _TblGrafico, 0)

    End Sub

    Private Sub Frm_Inf_Ventas_X_Vendedor_03_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class