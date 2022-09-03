'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Frm_Inf_Ventas_Linea_Tiempo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim _Sql_Grafico As String


    Public Sub New(ByVal Sql_Grafico As String, ByVal Grafico As Chart)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Sql_Grafico = Sql_Grafico

        ' This call is required by the Windows.Forms Form Designer.
        InitializeComponent()

        Grafico_Linea_De_Tiempo = Grafico

    End Sub

    Private Sub Frm_Inf_Ventas_Linea_Tiempo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Sb_Generar_Grafica_Linea_De_Tiempo(Grafico_Linea_De_Tiempo)
        'Sb_Generar_Grafica_Linea_De_Tiempo(Grafico_Linea_De_Tiempo)

        ' Add Border styles to control.
        'For Each styleName As String In [Enum].GetNames(GetType(LegendStyle))
        'Me.TheStyle.Items.Add(styleName)
        'Next
        'Me.TheStyle.SelectedIndex = 2

        'For Each dockName As String In [Enum].GetNames(GetType(Docking))
        'Me.TheDocking.Items.Add(dockName)
        'Next
        'Me.TheDocking.SelectedIndex = 1

        'For Each alignName As String In [Enum].GetNames(GetType(StringAlignment))
        'Me.TheAlignment.Items.Add(alignName)
        'Next
        'Me.TheAlignment.SelectedIndex = 0

        'Me.TheTableStyle.SelectedIndex = 0

    End Sub

    Sub Sb_Generar_Grafica_Linea_De_Tiempo(ByVal _Grafico As Chart)

        _Grafico.Series.Clear()


        Dim _Sql_DReader As System.Data.SqlClient.SqlDataReader
        _Sql_DReader = _Sql.Fx_SqlDataReader(_Sql_Grafico)

        ' Data bind chart to a table where all rows are grouped in series by the "Name" column

        _Grafico.DataBindCrossTable(_Sql_DReader, "DESCRIPCION", "Mes_Ano", "Total", "Label=Total{C0}")
        _Grafico.ChartAreas(0).AxisX.IsMarginVisible = True
        _Grafico.ChartAreas(0).AxisY.LabelStyle.Format = "C0"
        _Grafico.ChartAreas(0).AlignmentStyle = AreaAlignmentStyles.All

        _Grafico.Legends("Default").BackColor = Color.White
        'Chart1.Legends("Default").BackSecondaryColor = Color.Green
        'Chart1.Legends("Default").BackGradientStyle = GradientStyle.DiagonalLeft



        _Grafico.Legends("Default").BorderColor = Color.Black
        '_Grafico.Legends("Default").BorderWidth = 2
        _Grafico.Legends("Default").BorderDashStyle = ChartDashStyle.NotSet

        'Sombra leyenda
        '_Grafico.Legends("Default").ShadowOffset = 5

        '_Grafico.Legends("Default").InsideChartArea = "Default"
        '_Grafico.Legends("Default").Alignment = StringAlignment.Near

        '_Grafico.Legends("Default").Docking = Docking.Right
        '_Grafico.Legends("Default").LegendStyle = LegendStyle.Column
        '_Grafico.Legends("Default").TableStyle = LegendTableStyle.Auto
        '
        '_Grafico.Series("Series 3").Legend = "Second"

        ' Set series appearance
        Dim marker As MarkerStyle = MarkerStyle.Circle
        For Each ser As Series In _Grafico.Series

            ser.ShadowOffset = 1
            ser.BorderWidth = 3
            ser.ChartType = SeriesChartType.Line
            'ser.Color = Color.FromArgb(255, 128, 128)

            ser.MarkerSize = 5
            ser.MarkerStyle = marker
            'ser.MarkerBorderColor = Color.FromArgb(64, 64, 64)
            ser.Font = New Font("Trebuchet MS", 8, FontStyle.Bold)
            ser.IsValueShownAsLabel = False

            For Each Punto In ser.Points
                Punto.Label = String.Empty
                Dim _Cod As String = Punto.XValue
            Next

            'ser.Legend = "Default"
            ser.EmptyPointStyle.Color = Color.Red
            ser.EmptyPointStyle.BorderWidth = 2
            ser.EmptyPointStyle.BorderDashStyle = ChartDashStyle.Dash
            ser.EmptyPointStyle.MarkerSize = 10
            ser.EmptyPointStyle.MarkerStyle = MarkerStyle.Cross
            ser.EmptyPointStyle.MarkerBorderColor = Color.Black
            ser.EmptyPointStyle.MarkerColor = Color.Red

            'Dim _Name As String = Trim(ser.Name.ToString)
            '
            'For Each _Row As DataGridViewRow In Grilla.Rows
            'Dim _Codigo = _Row.Cells("CODIGO").Value
            'If Trim(_Codigo) = Trim(ser.Name) Then
            '_Row.Cells("CODIGO").Style.BackColor = ser.Color
            'End If
            'Next

            'marker += 1
            'If marker > 9 Then
            'marker = MarkerStyle.Square
            'End If

        Next

        ' Find point with maximum Y value and change color
        'Dim maxValuePoint As DataPoint = Grafico_Lineal.Series("Series1").Points.FindMaxValue()
        'maxValuePoint.Color = Color.FromArgb(255, 128, 128)

        ' Find point with minimum Y value and change color
        'Dim minValuePoint As DataPoint = Grafico_Lineal.Series("Series1").Points.FindMinValue()
        'minValuePoint.Color = Color.FromArgb(128, 128, 255)


        For i = 0 To _Grafico.Series.Count - 1
            Try
                _Grafico.Series(i)("EmptyPointValue") = "Zero" '"Average"
            Catch ex As Exception

            End Try
        Next

    End Sub


    Private Sub ControlChange(ByVal sender As Object, ByVal e As System.EventArgs)

        'If InsideCheck.Checked Then
        'Grafico_Linea_De_Tiempo.Legends("Default").InsideChartArea = "Default"
        'Else
        'Grafico_Linea_De_Tiempo.Legends("Default").InsideChartArea = ""
        'End If

        'Grafico_Linea_De_Tiempo.Legends("Default").Enabled = Not DisableCheck.Checked

        'If Me.TheStyle.SelectedItem.ToString() = "Table" AndAlso Not Me.DisableCheck.Checked Then
        'Me.TheTableStyle.Enabled = True
        'Else

        'Me.TheTableStyle.Enabled = False
        'End If

        'If Me.TheTableStyle.SelectedIndex >= 0 Then
        'Grafico_Linea_De_Tiempo.Legends("Default").TableStyle = DirectCast(LegendTableStyle.Parse(GetType(LegendTableStyle), Me.TheTableStyle.SelectedItem.ToString()), LegendTableStyle)
        'End If

        'If Me.TheStyle.SelectedIndex >= 0 Then
        'Grafico_Linea_De_Tiempo.Legends("Default").LegendStyle = DirectCast(LegendStyle.Parse(GetType(LegendStyle), Me.TheStyle.SelectedItem.ToString()), LegendStyle)
        'End If

        'If Me.TheDocking.SelectedIndex >= 0 Then
        'Grafico_Linea_De_Tiempo.Legends("Default").Docking = DirectCast(Docking.Parse(GetType(Docking), Me.TheDocking.SelectedItem.ToString()), Docking)
        'End If

        'If Me.TheAlignment.SelectedIndex >= 0 Then
        'Grafico_Linea_De_Tiempo.Legends("Default").Alignment = DirectCast(StringAlignment.Parse(GetType(StringAlignment), Me.TheAlignment.SelectedItem.ToString()), StringAlignment)
        'End If

        'If Me.cb_Reversed.Checked Then
        'Grafico_Linea_De_Tiempo.Legends("Default").LegendItemOrder = LegendItemOrder.ReversedSeriesOrder
        'Else
        'Grafico_Linea_De_Tiempo.Legends("Default").LegendItemOrder = LegendItemOrder.SameAsSeriesOrder
        'End If
    End Sub

    Private Sub cb_Reversed_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ControlChange(sender, e)
    End Sub

    Private Sub DisableCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'If Not Me.DisableCheck.Checked Then
        'Me.TheAlignment.Enabled = True
        'Me.TheDocking.Enabled = True
        'Me.TheTableStyle.Enabled = True
        'Me.TheStyle.Enabled = True
        'Me.InsideCheck.Enabled = True
        'Me.cb_Reversed.Enabled = True
        'Else

        'Me.TheAlignment.Enabled = False
        'Me.TheDocking.Enabled = False
        'Me.TheTableStyle.Enabled = False
        'Me.TheStyle.Enabled = False
        'Me.InsideCheck.Enabled = False
        'Me.cb_Reversed.Enabled = False
        'End If

        'ControlChange(sender, e)
    End Sub

End Class