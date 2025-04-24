Imports System.Drawing.Printing

Public Class Cl_Imprimir_Sectores

    Private _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Private ConsultaSql As String

    Private _Zw_Inv_Sector As New Zw_Inv_Sector
    Private _Error As String

    Public Sub New(_IdSector As Integer)

        Dim Cl_InvSectores As New Cl_InvSectores

        Cl_InvSectores.Fx_Llenar_Zw_Inv_Sector(_IdSector)
        _Zw_Inv_Sector = Cl_InvSectores.Zw_Inv_Sector

    End Sub

    Public Function Fx_Imprimir_Sector(_PrinterSettings As PrinterSettings) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje.Col2_Detalle = "Imprimir Sector"
        _Mensaje.Icono = MessageBoxIcon.Information

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

            printDoc.PrinterSettings = _PrinterSettings
            'printDoc.PrinterSettings.PrinterName = _Impresora
            printDoc.Print()

            _Mensaje.Col1_Mensaje = "Impresión realizada con éxito"
            _Mensaje.EsCorrecto = True

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Col1_Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function

    Private Sub print_PrintPage(sender As Object,
                                e As PrintPageEventArgs)

        ' Este evento se producirá cada vez que se imprima una nueva página
        ' imprimir HOLA MUNDO en Arial tamaño 24 y negrita
        _Error = String.Empty

        Dim _IdSector As Integer = _Zw_Inv_Sector.Id
        Dim _Sector As String = _Zw_Inv_Sector.Sector
        Dim _NombreSector As String = _Zw_Inv_Sector.NombreSector

        Try
            'Vale-BkPost
            Dim bm As Bitmap = Nothing
            Dim _CodBarras_Sector As New PictureBox
            Dim _CodBarras_IdSector As New PictureBox
            Dim Imagen As New PictureBox

            Dim iType As BarCode.Code128SubTypes =
             DirectCast([Enum].Parse(GetType(BarCode.Code128SubTypes), "CODE128"), BarCode.Code128SubTypes)
            bm = BarCode.Code128(UCase(_IdSector), iType, False)
            If Not IsNothing(bm) Then
                _CodBarras_IdSector.Image = bm
            End If

            bm = BarCode.Code128(UCase(_Sector), iType, False)
            If Not IsNothing(bm) Then
                _CodBarras_Sector.Image = bm
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
            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(xPos, 5, 800, 150))
            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(xPos, 180, 800, 200))
            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(xPos, 180, 800, 300))
            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(xPos, 500, 800, 100))

            'Try
            '    Imagen.Image = New System.Drawing.Bitmap(_Ruta_Imagen)
            '    e.Graphics.DrawImage(Imagen.Image, xPos + 10, yPos - 35, 220, 140)
            'Catch ex As Exception
            'End Try

            Try
                e.Graphics.DrawImage(_CodBarras_Sector.Image, xPos + 10, yPos - 35, 220, 140)
            Catch ex As Exception
            End Try

            Dim Rt() As String = Split(RutEmpresa, "-")
            Dim Rut_Emp As String = RutEmpresa 'FormatNumber(Rt(0), 0) & "-" & Rt(1)

            e.Graphics.DrawString("Rut: " & Rut_Emp, Ft_Arial12_N, Brushes.Black, xPos + 300, yPos - 30)
            yPos = yPos + 20
            e.Graphics.DrawString("Nombre : " & RazonEmpresa, Ft_Arial12_N, Brushes.Black, xPos + 300, yPos - 30)

            Dim _Nombre_Encargado As String = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & _Zw_Inv_Sector.CodFuncionario & "'")

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
            e.Graphics.DrawString(_NombreSector, prFont, Brushes.Black, xPos + 5, yPos)
            yPos += 80
            e.Graphics.DrawString(_Sector, Dt2Font, Brushes.Black, xPos + 5, yPos)

            yPos += 110
            e.Graphics.DrawString("SECTOR : " & numero_(_IdSector, 5), Dt2Font, Brushes.Black, xPos + 5, yPos)
            e.Graphics.DrawImage(_CodBarras_IdSector.Image, xPos + 550, yPos, 220, 60)
            yPos += 170

            e.Graphics.DrawString("ENCARGADO", FontCon, Brushes.Black, xPos + 30, yPos)
            e.Graphics.DrawString("SUPERVISOR", FontCon, Brushes.Black, xPos + 330, yPos)
            e.Graphics.DrawString("DIGITADOR", FontCon, Brushes.Black, xPos + 660, yPos)

            ' e.Graphics.DrawString("ESTADO :_______________________________", DtFont, Brushes.Black, xPos + 5, yPos)
            e.HasMorePages = False

        Catch ex As Exception
            _Error = ex.Message
        End Try

    End Sub

End Class
