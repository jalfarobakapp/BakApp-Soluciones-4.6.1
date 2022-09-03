'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Frm_Inf_Ventas_Grafico_Linea_Tiempo

    Public Sub New(ByVal Grafico As Chart)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Grafico_Linea_De_Tiempo = Grafico
    End Sub

    Private Sub Frm_Inf_Ventas_Grafico_Linea_Tiempo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


End Class