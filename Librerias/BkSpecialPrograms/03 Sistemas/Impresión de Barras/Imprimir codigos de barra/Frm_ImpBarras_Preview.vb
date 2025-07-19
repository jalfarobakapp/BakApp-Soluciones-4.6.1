Imports System.IO
Imports System.Net
Imports System.Text

Public Class Frm_ImpBarras_Preview

    Private _zpl_Preview As String
    Private _Name As String
    Private _Producto As String

    ' API para obtener DPI físico
    Private Declare Function GetDC Lib "user32" (hWnd As IntPtr) As IntPtr
    Private Declare Function ReleaseDC Lib "user32" (hWnd As IntPtr, hDC As IntPtr) As Integer
    Private Declare Function GetDeviceCaps Lib "gdi32" (hdc As IntPtr, nIndex As Integer) As Integer
    Private Const LOGPIXELSX As Integer = 88 ' DPI horizontal
    Private Const LOGPIXELSY As Integer = 90 ' DPI vertical

    ' Variables para almacenar píxeles por cm
    Private pxPorCM_Horizontal As Double
    Private pxPorCM_Vertical As Double

    Public Sub New(_zpl_Preview As String, _Name As String, _Producto As String)

        Me._zpl_Preview = _zpl_Preview
        Me._Name = _Name
        Me._Producto = _Producto
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_ImpBarras_Preview_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Lbl_Nombre_Etiqueta.Text = _Name
        Lbl_Producto.Text = _Producto

        Sb_CalcularPixelesPorCM()
        Sb_Cargar_Imagen(_zpl_Preview, 0)

        AddHandler Pnl_Ancho.Paint, AddressOf Sb_DibujarReglaHorizontal
        AddHandler Pnl_Alto.Paint, AddressOf Sb_DibujarReglaVertical

        Pnl_Ancho.Invalidate()
        Pnl_Alto.Invalidate()

    End Sub
    Private Sub Sb_CalcularPixelesPorCM()
        ' Obtener DPI físico (real, no ajustado por escalado)
        Dim hdcScreen As IntPtr = GetDC(IntPtr.Zero)
        Dim dpiX As Integer = GetDeviceCaps(hdcScreen, LOGPIXELSX)
        Dim dpiY As Integer = GetDeviceCaps(hdcScreen, LOGPIXELSY)
        ReleaseDC(IntPtr.Zero, hdcScreen)

        ' Calcular píxeles por centímetro (1 pulgada = 2.54 cm)
        pxPorCM_Horizontal = dpiX / 2.54
        pxPorCM_Vertical = dpiY / 2.54
    End Sub

    ' ... (resto del código igual)

    Private etiquetaAnchoCM As Double = 0
    Private etiquetaAltoCM As Double = 0

    Private Sub Cargar_Imagen_Old(ZPL As String)
        Dim url As String
        Dim ancho As String
        Dim alto As String
        Dim dpi As Double = 203
        Dim size As Dictionary(Of String, Double) = GetLabelSizeInInches(ZPL)

        ' Convertir pulgadas a centímetros
        etiquetaAnchoCM = size("Ancho") * 2.54
        etiquetaAltoCM = size("Alto") * 2.54

        ancho = size("Ancho").ToString.Replace(",", ".")
        alto = size("Alto").ToString.Replace(",", ".")

        Dim anchoPixels As Integer = CInt(size("Ancho") * dpi)
        Dim altoPixels As Integer = CInt(size("Alto") * dpi)
        Img_Etiqueta.Height = size("Alto") * 96
        Img_Etiqueta.Width = size("Ancho") * 96

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

    Private Sub Sb_DibujarReglaHorizontal(sender As Object, e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.Clear(Pnl_Ancho.BackColor)

        Dim offset As Integer = Pnl_Alto.Width
        Dim anchoDisponible As Integer = Pnl_Ancho.Width - offset

        If etiquetaAnchoCM <= 0 Then Return

        ' Calcular el ancho disponible en centímetros
        Dim anchoDisponibleCM As Double = etiquetaAnchoCM
        If anchoDisponible > 0 AndAlso pxPorCM_Horizontal > 0 Then
            anchoDisponibleCM = anchoDisponible / pxPorCM_Horizontal
        End If

        ' Escala: cuántos píxeles por cm en la regla, según el ancho de la etiqueta
        Dim pxPorCM_Regla As Double = anchoDisponible / anchoDisponibleCM

        ' Dibujar regla en cm y mm
        For i As Integer = 0 To CInt(anchoDisponibleCM * 10) ' 10 divisiones por cm (mm)
            Dim x As Single = offset + CSng(i * (pxPorCM_Regla / 10))

            If i Mod 10 = 0 Then ' Cada 1 cm
                g.DrawLine(Pens.Black, x, Pnl_Ancho.Height, x, Pnl_Ancho.Height - 20)
                Dim texto As String = (i \ 10).ToString()
                Dim tamTexto = g.MeasureString(texto, Me.Font)
                g.DrawString(texto, Me.Font, Brushes.Black, x - tamTexto.Width / 2, 2)
            ElseIf i Mod 5 = 0 Then ' Cada 0.5 cm
                g.DrawLine(Pens.Gray, x, Pnl_Ancho.Height, x, Pnl_Ancho.Height - 15)
            Else ' Cada 1 mm
                g.DrawLine(Pens.LightGray, x, Pnl_Ancho.Height, x, Pnl_Ancho.Height - 10)
            End If
        Next
    End Sub

    Private Sub Sb_DibujarReglaVertical(sender As Object, e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.Clear(Pnl_Alto.BackColor)

        Dim altoDisponible As Integer = Pnl_Alto.Height

        If etiquetaAltoCM <= 0 Then Return

        ' Calcular el alto disponible en centímetros
        Dim altoDisponibleCM As Double = etiquetaAltoCM
        If altoDisponible > 0 AndAlso pxPorCM_Vertical > 0 Then
            altoDisponibleCM = altoDisponible / pxPorCM_Vertical
        End If

        ' Escala: cuántos píxeles por cm en la regla, según el alto de la etiqueta
        Dim pxPorCM_Regla As Double = altoDisponible / altoDisponibleCM

        ' Dibujar regla en cm y mm
        For i As Integer = 0 To CInt(altoDisponibleCM * 10) ' 10 divisiones por cm (mm)
            Dim y As Single = CSng(i * (pxPorCM_Regla / 10))

            If i Mod 10 = 0 Then ' Cada 1 cm
                g.DrawLine(Pens.Black, Pnl_Alto.Width, y, Pnl_Alto.Width - 20, y)
                Dim texto As String = (i \ 10).ToString()
                Dim tamTexto = g.MeasureString(texto, Me.Font)
                g.DrawString(texto, Me.Font, Brushes.Black, 2, y - tamTexto.Height / 2)
            ElseIf i Mod 5 = 0 Then ' Cada 0.5 cm
                g.DrawLine(Pens.Gray, Pnl_Alto.Width, y, Pnl_Alto.Width - 15, y)
            Else ' Cada 1 mm
                g.DrawLine(Pens.LightGray, Pnl_Alto.Width, y, Pnl_Alto.Width - 10, y)
            End If
        Next
    End Sub

    'Private Sub Sb_DibujarReglaVertical(sender As Object, e As PaintEventArgs)
    '    Dim g As Graphics = e.Graphics
    '    g.Clear(Pnl_Alto.BackColor)

    '    Dim altoDisponible As Integer = Pnl_Alto.Height
    '    Dim totalCM As Double = altoDisponible / pxPorCM_Vertical

    '    ' Dibujar regla en cm
    '    For i As Integer = 0 To CInt(totalCM * 10) ' 10 divisiones por cm (mm)
    '        Dim y As Single = CSng(i * (pxPorCM_Vertical / 10))

    '        If i Mod 10 = 0 Then ' Cada 1 cm
    '            g.DrawLine(Pens.Black, Pnl_Alto.Width, y, Pnl_Alto.Width - 20, y)
    '            Dim texto As String = (i \ 10).ToString()
    '            Dim tamTexto = g.MeasureString(texto, Me.Font)
    '            g.DrawString(texto, Me.Font, Brushes.Black, 2, y - tamTexto.Height / 2)
    '        ElseIf i Mod 5 = 0 Then ' Cada 0.5 cm
    '            g.DrawLine(Pens.Gray, Pnl_Alto.Width, y, Pnl_Alto.Width - 15, y)
    '        Else ' Cada 1 mm
    '            g.DrawLine(Pens.LightGray, Pnl_Alto.Width, y, Pnl_Alto.Width - 10, y)
    '        End If
    '    Next
    'End Sub

    Private Sub Pnl_Ancho_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Ancho.Paint
        Sb_DibujarReglaHorizontal(sender, e)
    End Sub

    Private Sub Pnl_Alto_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Alto.Paint
        Sb_DibujarReglaVertical(sender, e)
    End Sub
    ' Filtrar el ZPL y quedarnos solo con la primera etiqueta (si hay varias)

    Private Sub Sb_Cargar_Imagen(ZPL As String, Optional porcentajeAumento As Double = 0)

        Dim url As String
        Dim ancho As String
        Dim alto As String
        Dim dpi As Double = 203
        ' Obtener tamaño original de la etiqueta en pulgadas
        Dim size As Dictionary(Of String, Double) = GetLabelSizeInInches(ZPL)

        ' Calcular el factor de aumento
        Dim factorAumento As Double = 1 + (porcentajeAumento / 100.0)

        ' Ancho y alto originales en pulgadas
        Dim anchoOriginalInches As Double = size("Ancho")
        Dim altoOriginalInches As Double = size("Alto")

        ' Convertir a centímetros
        etiquetaAnchoCM = anchoOriginalInches * 2.54
        etiquetaAltoCM = altoOriginalInches * 2.54

        ' Aplicar el aumento al tamaño en centímetros
        Dim anchoAumentadoCM As Double = etiquetaAnchoCM * factorAumento
        Dim altoAumentadoCM As Double = etiquetaAltoCM * factorAumento

        ' Convertir a pulgadas para la API
        Dim anchoAumentadoInches As Double = anchoAumentadoCM / 2.54
        Dim altoAumentadoInches As Double = altoAumentadoCM / 2.54

        ancho = anchoAumentadoInches.ToString.Replace(",", ".")
        alto = altoAumentadoInches.ToString.Replace(",", ".")

        ' Descargar la imagen de la API
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
                    Dim originalImage As Image = Image.FromStream(responseStream)

                    ' Calcular el tamaño en píxeles para el tamaño físico de la etiqueta (sin aumento)
                    Dim anchoEtiquetaPx As Integer = CInt(etiquetaAnchoCM * pxPorCM_Horizontal)
                    Dim altoEtiquetaPx As Integer = CInt(etiquetaAltoCM * pxPorCM_Vertical)

                    ' Calcular el tamaño final en píxeles con el aumento
                    Dim finalWidth As Integer = CInt(anchoEtiquetaPx * factorAumento)
                    Dim finalHeight As Integer = CInt(altoEtiquetaPx * factorAumento)
                    Dim finalImage As New Bitmap(finalWidth, finalHeight)

                    Using g As Graphics = Graphics.FromImage(finalImage)
                        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                        g.Clear(Color.Gray)
                        g.DrawImage(originalImage, 0, 0, finalWidth, finalHeight)
                    End Using

                    Img_Etiqueta.Image = finalImage
                    Img_Etiqueta.Width = finalWidth
                    Img_Etiqueta.Height = finalHeight
                End Using
            End Using
        Catch ex As WebException
            MessageBox.Show("Error al generar la etiqueta: " & ex.Message)
        End Try
        size.Clear()

    End Sub

    Private Sub Img_Etiqueta1_Paint(sender As Object, e As PaintEventArgs) Handles Img_Etiqueta.Paint
        ' Asegurarse de que el PictureBox tenga una imagen
        Dim pb As PictureBox = CType(sender, PictureBox)
        If pb.Image Is Nothing Then Return

        Dim img As Image = pb.Image

        ' Escalado proporcional (Zoom)
        Dim scale As Double = Math.Min(pb.Width / img.Width, pb.Height / img.Height)

        Dim newWidth As Integer = CInt(img.Width * scale)
        Dim newHeight As Integer = CInt(img.Height * scale)

        Dim x As Integer = (pb.Width - newWidth) \ 2 ' Centrado horizontal
        Dim y As Integer = 0 ' Pegado arriba

        ' Limpiar con color de fondo (por ejemplo, transparente o del control padre)
        Dim bgColor As Color = Color.Gray

        ' Para simular transparencia
        e.Graphics.Clear(bgColor)

        ' Dibujar la imagen escalada y alineada
        e.Graphics.DrawImage(img, New Rectangle(x, y, newWidth, newHeight))
    End Sub

    ' Agrega un margen de 5 cm alrededor de la imagen y dibuja un contorno de etiqueta (bordes redondeados)
    'Private Sub Img_Etiqueta1_Paint(sender As Object, e As PaintEventArgs) Handles Img_Etiqueta.Paint
    '    Dim pb As PictureBox = CType(sender, PictureBox)
    '    If pb.Image Is Nothing Then Return

    '    Dim img As Image = pb.Image

    '    ' Calcular el margen en píxeles (5 cm)
    '    Dim margenCM As Double = 5.0
    '    Dim margenPx As Integer = CInt(margenCM * pxPorCM_Horizontal)

    '    ' Área disponible para la imagen (restando márgenes)
    '    Dim areaAncho As Integer = pb.Width - 2 * margenPx
    '    Dim areaAlto As Integer = pb.Height - 2 * margenPx

    '    If areaAncho <= 0 Or areaAlto <= 0 Then Return

    '    ' Escalado proporcional (Zoom)
    '    Dim scale As Double = Math.Min(areaAncho / img.Width, areaAlto / img.Height)
    '    Dim newWidth As Integer = CInt(img.Width * scale)
    '    Dim newHeight As Integer = CInt(img.Height * scale)

    '    ' Posición de la imagen (centrada dentro del área con margen)
    '    Dim x As Integer = margenPx + (areaAncho - newWidth) \ 2
    '    Dim y As Integer = margenPx + (areaAlto - newHeight) \ 2

    '    ' Limpiar con color de fondo
    '    Dim bgColor As Color = Color.Gray
    '    e.Graphics.Clear(bgColor)

    '    ' Dibujar la imagen escalada y alineada
    '    e.Graphics.DrawImage(img, New Rectangle(x, y, newWidth, newHeight))

    '    ' Dibujar el contorno de la etiqueta (puedes elegir entre bordes redondeados o cuadrados)
    '    Dim contornoRect As New Rectangle(margenPx, margenPx, areaAncho, areaAlto)
    '    Dim radioBorde As Integer = 30 ' píxeles para esquinas redondeadas

    '    Using pen As New Pen(Color.Black, 3)
    '        ' Bordes redondeados
    '        Dim path As New Drawing2D.GraphicsPath()
    '        path.AddArc(contornoRect.Left, contornoRect.Top, radioBorde, radioBorde, 180, 90)
    '        path.AddArc(contornoRect.Right - radioBorde, contornoRect.Top, radioBorde, radioBorde, 270, 90)
    '        path.AddArc(contornoRect.Right - radioBorde, contornoRect.Bottom - radioBorde, radioBorde, radioBorde, 0, 90)
    '        path.AddArc(contornoRect.Left, contornoRect.Bottom - radioBorde, radioBorde, radioBorde, 90, 90)
    '        path.CloseFigure()
    '        e.Graphics.DrawPath(pen, path)
    '        ' Si prefieres bordes cuadrados, comenta lo anterior y descomenta la siguiente línea:
    '        'e.Graphics.DrawRectangle(pen, contornoRect)
    '    End Using
    'End Sub

    Function GetLabelSizeInInches(zplCode As String) As Dictionary(Of String, Double)
        Dim dpi As Integer = 203 ' Densidad común de impresión térmica
        Dim result As New Dictionary(Of String, Double) From {
        {"Ancho", 0},
        {"Alto", 0}
    }

        ' Buscar ancho (^PWnnn)
        Dim pwIndex As Integer = zplCode.IndexOf("^PW")
        If pwIndex <> -1 Then
            Dim widthStr As String = Fx_ExtractDigits(zplCode.Substring(pwIndex + 3))
            If widthStr.Length > 0 Then
                Dim widthDots As Integer = Integer.Parse(widthStr)
                Dim widthInches As Double = widthDots / dpi
                result("Ancho") = Math.Round(widthInches, 2)
            End If
        End If

        ' Buscar alto (^LLnnn)
        Dim llIndex As Integer = zplCode.IndexOf("^LL")
        If llIndex <> -1 Then
            Dim heightStr As String = Fx_ExtractDigits(zplCode.Substring(llIndex + 3))
            If heightStr.Length > 0 Then
                Dim heightDots As Integer = Integer.Parse(heightStr)
                Dim heightInches As Double = heightDots / dpi
                result("Alto") = Math.Round(heightInches, 2)
            End If
        End If

        Return result
    End Function

    Private Function Fx_ExtractDigits(s As String) As String
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
        Sb_Cargar_Imagen(_zpl_Preview, 20)
    End Sub

End Class
