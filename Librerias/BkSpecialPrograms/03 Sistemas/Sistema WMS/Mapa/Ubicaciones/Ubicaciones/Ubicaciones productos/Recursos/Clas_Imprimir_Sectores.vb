﻿'Imports Lib_Bakapp_VarClassFunc
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing

Public Class Clas_Imprimir_Sectores


    Public _Ruta_Imagen As String
    Public _CodigoBarras As String
    Public _Nombre_Encargado As String
    Public _Nombre_Piso As String
    Public _Codigo_Sector As String
    Public _Nombre_Sector As String
    Public _Codigo_ArchivoTxt_Ubicacion As String

    Enum _Hojas
        Carta
        Oficio
    End Enum


    'Public Ds_DatosImpresion As DataSet


    Public Function Imprimir_Sectores(ByVal _Impresora As String)

        Try

            Dim printDoc As New PrintDocument

            'Dim pkCustomSize1 As New Printing.PaperSize("Custom Paper Size", 612, 792) ' CARTA
            'printDoc.PrinterSettings.DefaultPageSettings.PaperSize = pkCustomSize1
            ' printDoc.DefaultPageSettings.Landscape = True
            ' asignamos el método de evento para cada página a imprimir
            AddHandler printDoc.PrintPage, AddressOf print_PrintPage

            'Indicamos la impresora
            'Dim Imp As String
            'Imp = trae_datoAccess(tb, "Impresora", "Tmp_Conf_Local", "Modulo = 'Imp_Picking'")

            printDoc.PrinterSettings.PrinterName = _Impresora
            printDoc.Print()
            Return True
        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub print_PrintPage(ByVal sender As Object, _
                                ByVal e As PrintPageEventArgs)


        ' Este evento se producirá cada vez que se imprima una nueva página
        ' imprimir HOLA MUNDO en Arial tamaño 24 y negrita


        Try
            'Vale-BkPost
            Dim bm As Bitmap = Nothing
            Dim CodBarras As New PictureBox
            Dim Imagen As New PictureBox


            Dim iType As BarCode.Code128SubTypes = _
             DirectCast([Enum].Parse(GetType(BarCode.Code128SubTypes), "CODE128"), BarCode.Code128SubTypes)
            bm = BarCode.Code128(UCase(_CodigoBarras), iType, False)
            If Not IsNothing(bm) Then
                CodBarras.Image = bm
            End If

            ' imprimimos la cadena en el margen izquierdo
            Dim xPos As Single = 10 'e.MarginBounds.Left
            ' La fuente a usar

            Dim Ft_Arial12_N As New Font("Arial", 12, FontStyle.Bold) ' Fuente del detalle
            Dim DtFont As New Font("Arial", 16, FontStyle.Regular) ' Fuente del detalle
            Dim Dt2Font As New Font("Arial", 40, FontStyle.Bold) ' Fuente del detalle
            Dim prFont As New Font("Arial", 35, FontStyle.Bold)    ' Fuente Encabezado
            Dim FontNro As New Font("Times New Roman", 50, FontStyle.Bold)
            Dim FontCon As New Font("Times New Roman", 11, FontStyle.Bold)
            ' la posición superior
            Dim yPos As Single = prFont.GetHeight(e.Graphics) - 10


            'Encabezado
            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(xPos, 5, 830, 150))
            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(xPos, 180, 830, 200))
            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(xPos, 180, 830, 300))
            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(xPos, 500, 830, 100))

            Try
                Imagen.Image = New System.Drawing.Bitmap(_Ruta_Imagen)
                e.Graphics.DrawImage(Imagen.Image, xPos + 10, yPos - 35, 220, 140)
            Catch ex As Exception
            End Try

            Dim Rt() As String = Split(RutEmpresa, "-")
            Dim Rut_Emp As String = RutEmpresa 'FormatNumber(Rt(0), 0) & "-" & Rt(1)

            e.Graphics.DrawString("Rut: " & Rut_Emp, Ft_Arial12_N, Brushes.Black, xPos + 300, yPos - 30)
            yPos = yPos + 20
            e.Graphics.DrawString("Nombre : " & RazonEmpresa, Ft_Arial12_N, Brushes.Black, xPos + 300, yPos - 30)

            If Not String.IsNullOrEmpty(Trim(_Nombre_Encargado)) Then
                yPos = yPos + 40
                e.Graphics.DrawString("Encargado : " & _Nombre_Encargado, Ft_Arial12_N, Brushes.Black, xPos + 300, yPos - 30)
                yPos += 40
            Else
                yPos += 80
            End If
            ''' UTIL PARA ALINEAR IMPRESION
            'Dim tf = New TextFormatFlags(
            'tf.Alignment = XParagraphAlignment.Center



            Dim Hora = FormatDateTime(Date.Now, DateFormat.ShortTime).ToString
            Dim Fecha = FormatDateTime(Date.Now, DateFormat.ShortDate).ToString

            Dim NroLineasPagina As Integer = e.PageBounds.Height / Dt2Font.GetHeight(e.Graphics)

            yPos += 70
            e.Graphics.DrawString(_Nombre_Piso, prFont, Brushes.Black, xPos + 5, yPos)
            yPos += 80
            e.Graphics.DrawString(_Codigo_Sector, Dt2Font, Brushes.Black, xPos + 5, yPos)



            yPos += 110
            e.Graphics.DrawString("SECTOR : " & _Codigo_Sector, Dt2Font, Brushes.Black, xPos + 5, yPos)
            e.Graphics.DrawImage(CodBarras.Image, xPos + 550, yPos, 220, 60)
            yPos += 170

            e.Graphics.DrawString("ENCARGADO", FontCon, Brushes.Black, xPos + 30, yPos)
            e.Graphics.DrawString("SUPERVISOR", FontCon, Brushes.Black, xPos + 330, yPos)
            e.Graphics.DrawString("DIGITADOR", FontCon, Brushes.Black, xPos + 660, yPos)

            ' e.Graphics.DrawString("ESTADO :_______________________________", DtFont, Brushes.Black, xPos + 5, yPos)
            e.HasMorePages = False


        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub


End Class
