Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Function ObtenerEncabezado(json As String) As Encabezado
        Try
            Dim Arr As Encabezado = JsonConvert.DeserializeObject(Of Encabezado)(json)
            Return Arr
        Catch Ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Des2 As Encabezado
        Des2 = ObtenerEncabezado(TextBox1.Text)
        Dim Valor1 As String = Des2.rut_emisor
        Dim Valor2 As String = Des2.estadistica(0).tipo
        Dim valor3 As String = Des2.detalle_rep_rech(0).folio
        Dim valor4 As String = Des2.detalle_rep_rech(0).error(0).descripcion
        Dim St As String = ""





    End Sub
End Class