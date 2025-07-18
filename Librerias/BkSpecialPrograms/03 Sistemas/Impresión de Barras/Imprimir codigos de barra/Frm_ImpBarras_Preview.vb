Imports System.IO
Imports System.Net
Imports System.Text
Imports BkSpecialPrograms.csNotificaciones.Notificacion

Public Class Frm_ImpBarras_Preview
    Private _zpl_Preview As String
    Private _Name As String
    Private _Producto As String

    Public Sub New(_zpl_Preview As String, _Name As String, _Producto As String)


        Me._zpl_Preview = _zpl_Preview
        Me._Name = _Name
        Me._Producto = _Producto
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub GroupPanel2_Click(sender As Object, e As EventArgs) Handles GroupPanel2.Click

    End Sub

    Private Sub Frm_ImpBarras_Preview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Lbl_Nombre_Etiqueta.Text = _Name
        Lbl_Producto.Text = _Producto

        Cargar_Imagen(_zpl_Preview)
    End Sub
    ' Filtrar el ZPL y quedarnos solo con la primera etiqueta (si hay varias)


    Private Sub Cargar_Imagen(ZPL As String)

        Dim url As String
        Dim ancho As String
        Dim alto As String
        Dim dpi As Double = 203
        ' URL con DPI y tamaño de etiqueta pequeña
        Dim size As Dictionary(Of String, Double) = GetLabelSizeInInches(ZPL)
        Console.WriteLine("Ancho (pulgadas): " & size("Ancho"))
        Console.WriteLine("Alto (pulgadas): " & size("Alto"))
        ancho = size("Ancho").ToString.Replace(",", ".")
        alto = size("Alto").ToString.Replace(",", ".")

        Dim anchoPixels As Integer = CInt(size("Ancho") * dpi)
        Dim altoPixels As Integer = CInt(size("Alto") * dpi)
        Img_Etiqueta.Size = New Size(anchoPixels, altoPixels)

        url = $"https://api.labelary.com/v1/printers/8dpmm/labels/{ancho}x{alto}/0/"





        Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"
        request.Accept = "image/png"

        Dim zplBytes As Byte() = Encoding.UTF8.GetBytes(ZPL)
        request.ContentLength = zplBytes.Length

        Try
            Using stream As Stream = request.GetRequestStream()
                stream.Write(zplBytes, 0, zplBytes.Length)
            End Using

            Using response As WebResponse = request.GetResponse()
                Using responseStream As Stream = response.GetResponseStream()
                    Dim images As Image = Image.FromStream(responseStream)
                    Img_Etiqueta.Image = images

                End Using
            End Using
        Catch ex As WebException
            MessageBox.Show("Error al generar la etiqueta: " & ex.Message)
        End Try
        size.Clear()

    End Sub
    Function GetLabelSizeInInches(zplCode As String) As Dictionary(Of String, Double)
        Dim dpi As Integer = 203 ' Densidad común de impresión térmica
        Dim result As New Dictionary(Of String, Double) From {
        {"Ancho", 0},
        {"Alto", 0}
    }

        ' Buscar ancho (^PWnnn)
        Dim pwIndex As Integer = zplCode.IndexOf("^PW")
        If pwIndex <> -1 Then
            Dim widthStr As String = ExtractDigits(zplCode.Substring(pwIndex + 3))
            If widthStr.Length > 0 Then
                Dim widthDots As Integer = Integer.Parse(widthStr)
                Dim widthInches As Double = widthDots / dpi
                result("Ancho") = Math.Round(widthInches, 2)
            End If
        End If

        ' Buscar alto (^LLnnn)
        Dim llIndex As Integer = zplCode.IndexOf("^LL")
        If llIndex <> -1 Then
            Dim heightStr As String = ExtractDigits(zplCode.Substring(llIndex + 3))
            If heightStr.Length > 0 Then
                Dim heightDots As Integer = Integer.Parse(heightStr)
                Dim heightInches As Double = heightDots / dpi
                result("Alto") = Math.Round(heightInches, 2)
            End If
        End If

        Return result
    End Function

    Private Function ExtractDigits(s As String) As String
        Dim digits As New System.Text.StringBuilder()
        For Each c As Char In s
            If Char.IsDigit(c) Then
                digits.Append(c)
            Else
                Exit For
            End If
        Next
        Return digits.ToString()
    End Function


    Private Sub Btn_Recargar_Click(sender As Object, e As EventArgs) Handles Btn_Recargar.Click
        Cargar_Imagen(_zpl_Preview)

    End Sub

    Private Sub Img_Etiqueta_Click(sender As Object, e As EventArgs) Handles Img_Etiqueta.Click

    End Sub
End Class
