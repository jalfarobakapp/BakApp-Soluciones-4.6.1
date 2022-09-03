Imports DevComponents.DotNetBar
Imports System.Drawing.Printing
Imports System.IO
Imports System.Xml.XPath

Public Class Clas_Imprimir_Reserva_OCC

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Proveedor As DataRow

    Dim _PrtSettings As New PrinterSettings

    Dim _Item = 1
    Dim _Pagina = 1

    Dim _Chk_Mostrar_Item As Boolean
    Dim _Row_Documento As DataRow

    Dim _Error As String

    Dim _Imprimir_Negrita As Boolean

    Enum Enum_Orden_Productos
        Codigo
        Codigo_Alternativo
        Descripcion
    End Enum

    Dim _Ordenar_por As Enum_Orden_Productos

#Region "FUENTES"

    Dim DtFont As New Font("Arial", 9, FontStyle.Regular) ' Fuente del detalle
    Dim prFont As New Font("Arial", 9, FontStyle.Bold)
    Dim FontNro As New Font("Times New Roman", 14, FontStyle.Bold)
    Dim FontCon As New Font("Times New Roman", 11, FontStyle.Bold)

    Dim FteCourier_New_C_4 As New Font("Courier New", 4, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_6 As New Font("Courier New", 6, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_7 As New Font("Courier New", 7, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_8 As New Font("Courier New", 8, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_9 As New Font("Courier New", 9, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_10 As New Font("Courier New", 10, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_11 As New Font("Courier New", 11, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_12 As New Font("Courier New", 12, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_13 As New Font("Courier New", 13, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_14 As New Font("Courier New", 13, FontStyle.Bold) ' Crea la fuente

    Public Property Imprimir_Negrita As Boolean
        Get
            Return _Imprimir_Negrita
        End Get
        Set(value As Boolean)
            _Imprimir_Negrita = value
        End Set
    End Property

    Public Property [Error] As String
        Get
            Return _Error
        End Get
        Set(value As String)
            _Error = value
        End Set
    End Property

#End Region

    Public Sub New()

    End Sub

    Public Function Fx_Imprimir_Archivo(_Formulario As Form,
                                        _Id_DocEnc As Integer,
                                        _DocumentName As String,
                                        _Impresora As String)

        Try

            _Error = String.Empty

            Consulta_sql = "Select Enc.*,Obs.Observaciones,NOKOFU As NombreResponsable 
                            From " & _Global_BaseBk & "Zw_Casi_DocEnc Enc 
                                Left Join " & _Global_BaseBk & "Zw_Casi_DocObs Obs On Enc.Id_DocEnc = Obs.Id_DocEnc  
                                    Left Join TABFU On KOFU = CodFuncionario
                            Where Enc.Id_DocEnc = " & _Id_DocEnc

            _Row_Documento = _Sql.Fx_Get_DataRow(Consulta_sql)

            ' ejemplo simple para imprimir en .NET
            ' Usamos una clase del tipo PrintDocument

            Dim printDoc As New PrintDocument

            ' CON ESTA CONFIGURACION PODEMOS PROPORCIONAR LAS DIMENCIONES Y ESTADO DE LA PAGINA, MARGENES, LARGO Y HORIENTACION

            ' Tamaño de carta = Ancho (8.5 X 100), Largo = (11 X 100)
            ' Tamaño de oficio = Ancho (8.5 X 100), Largo = (14.5 X 100)

            Dim pkCustomSize1 As New Printing.PaperSize(PaperKind.Letter, 850, 1100)

            Dim PageSetupDialog1 As New PageSetupDialog

            PageSetupDialog1.Document = printDoc
            PageSetupDialog1.PageSettings.Landscape = False

            PageSetupDialog1.PageSettings.PaperSize = pkCustomSize1
            PageSetupDialog1.PageSettings.Margins.Left = 2
            PageSetupDialog1.PageSettings.Margins.Right = 2

            'PageSetupDialog1.ShowDialog()

            'Dim PageSetupDialog1 As New PageSetupDialog

            'PageSetupDialog1.Document = printDoc
            'PageSetupDialog1.PageSettings.Landscape = False
            'PageSetupDialog1.PageSettings.PaperSize = pkCustomSize1

            ' asignamos el método de evento para cada página a imprimir

            AddHandler printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Reserva_OCC

            ' indicamos que queremos imprimir

            If String.IsNullOrEmpty(_DocumentName.Trim) Then

                Dim _Nudo As String = _Row_Documento.Item("NroDocumento")

                _DocumentName = "Reserva_OCC_" & _Nudo

            End If

            printDoc.DocumentName = _DocumentName '"Productos X Proveedor"

            If String.IsNullOrEmpty(_Impresora) Then

                Dim prtDialog As New PrintDialog

                If _PrtSettings Is Nothing Then
                    _PrtSettings = New PrinterSettings
                End If

                With prtDialog

                    .AllowPrintToFile = False
                    .AllowSelection = False
                    .AllowSomePages = False
                    .PrintToFile = False
                    .ShowHelp = False
                    .ShowNetwork = True

                    .PrinterSettings = _PrtSettings

                    If .ShowDialog(_Formulario) = DialogResult.OK Then
                        _Impresora = .PrinterSettings.PrinterName
                    Else
                        Return False
                    End If

                End With

            End If

            printDoc.PrinterSettings.PrinterName = _Impresora
            printDoc.Print()

            Return True

        Catch ex As Exception
            _Error = ex.Message
            Return False
        End Try

    End Function

    Private Sub Sb_Print_PrintPage_Reserva_OCC(ByVal sender As Object, ByVal e As PrintPageEventArgs)

        Try

            ' imprimimos la cadena en el margen izquierdo
            Dim _xPos As Single = 3 'e.MarginBounds.Left
            ' La fuente a usar


            ' la posición superior
            Dim _yPos As Single = prFont.GetHeight(e.Graphics) - 10

            _xPos = 20
            _yPos += 20

            Dim _Font_Enc_1 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 14, FontStyle.Bold)
            Dim _Font_Enc_2 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 12, FontStyle.Regular)
            Dim _Font_Enc_3 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 10, FontStyle.Regular)
            Dim _Font_Enc_4 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 8, FontStyle.Regular)

            Dim _Font_C6 As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 6, FontStyle.Regular)
            Dim _Font_C8 As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular)
            Dim _Font_C9 As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 9, FontStyle.Regular)
            Dim _Font_C10 As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 10, FontStyle.Regular)
            Dim _Font_C12 As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 12, FontStyle.Regular)

            Dim _Font_Detalle_1 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 6, FontStyle.Regular)
            Dim _Font_Detalle_2 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 8, FontStyle.Regular)
            Dim _Font_Detalle_3 As Font = Fx_Fuente(_Enum_Fuentes.Arial, 8, FontStyle.Regular)

            Dim _Font_Detalle_Curr_1_R As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 6, FontStyle.Regular)
            Dim _Font_Detalle_Curr_2_R As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular)

            Dim _Font_Detalle_Curr_1_B As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 6, FontStyle.Bold)
            Dim _Font_Detalle_Curr_2_B As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold)

            e.Graphics.DrawString(RazonEmpresa, Fx_Fuente(_Enum_Fuentes.Arial, 10, FontStyle.Regular), Brushes.Black, _xPos, _yPos)
            e.Graphics.DrawString("Fecha: " & Now.Date.ToShortDateString, Fx_Fuente(_Enum_Fuentes.Arial, 10, FontStyle.Regular),
                                  Brushes.Black, _xPos + 700, _yPos)
            _yPos += 20

            e.Graphics.DrawString("RUT: " & RutEmpresaActiva, Fx_Fuente(_Enum_Fuentes.Arial, 10, FontStyle.Regular), Brushes.Black, _xPos, _yPos)

            _yPos += 50

            e.Graphics.DrawString("*** Documento en construcción (no constituye orden de compra definitiva) ***",
                                  Fx_Fuente(_Enum_Fuentes.Arial, 10, FontStyle.Bold), Brushes.Black, _xPos + 150, _yPos)

            _yPos += 40

            Dim _Tido As String = _Row_Documento.Item("TipoDoc")
            Dim _Nudo As String = _Row_Documento.Item("NroDocumento")

            e.Graphics.DrawString("Número reservado para Orden: ",
                                  Fx_Fuente(_Enum_Fuentes.Arial, 10, FontStyle.Regular), Brushes.Black, _xPos, _yPos)

            e.Graphics.DrawString(_Tido & " " & _Nudo,
                                  Fx_Fuente(_Enum_Fuentes.Arial, 10, FontStyle.Bold), Brushes.Black, _xPos + 200, _yPos)

            _yPos += 20

            Dim _CodEntidad As String = _Row_Documento.Item("CodEntidad")
            Dim _CodSucEntidad As String = _Row_Documento.Item("CodSucEntidad")

            Dim _Row_Entidad As DataRow = Fx_Traer_Datos_Entidad(_CodEntidad, _CodSucEntidad)

            Dim _Nokoen As String = _Row_Entidad.Item("NOKOEN").ToString.Trim
            Dim _Rut As String = _Row_Entidad.Item("Rut")

            e.Graphics.DrawString("Proveedor: " & _Rut & " - " & _Nokoen,
                                  Fx_Fuente(_Enum_Fuentes.Arial, 10, FontStyle.Regular), Brushes.Black, _xPos, _yPos)
            _yPos += 20
            e.Graphics.DrawString(StrDup(79, "_"), _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            Dim _CodFuncionario As String = _Row_Documento.Item("CodFuncionario")
            Dim _NombreResponsable As String = _Row_Documento.Item("NombreResponsable")

            e.Graphics.DrawString("Responsable: " & _CodFuncionario & " - " & _NombreResponsable,
                                  Fx_Fuente(_Enum_Fuentes.Arial, 10, FontStyle.Regular), Brushes.Black, _xPos, _yPos)

            Dim _Observaciones As String = _Row_Documento.Item("Observaciones")

            _yPos += 30
            e.Graphics.DrawString("Observaciones:",
                                  Fx_Fuente(_Enum_Fuentes.Arial, 10, FontStyle.Regular), Brushes.Black, _xPos, _yPos)

            _yPos += 10
            'e.Graphics.DrawString("Esta orden de compra será generada con el detalle una vez que se hayan solicitado todos los productos y revisar la",
            '                      Fx_Fuente(_Enum_Fuentes.Arial, 10, FontStyle.Regular), Brushes.Black, _xPos, _yPos)
            '_yPos += 20
            'e.Graphics.DrawString("disponibilidad de nuestro proveedor…",
            '                      Fx_Fuente(_Enum_Fuentes.Arial, 10, FontStyle.Regular), Brushes.Black, _xPos, _yPos)

            _Observaciones = Replace(_Observaciones.Trim, vbCrLf, " ")

            Dim _Letras = _Observaciones.Length
            Dim _Filas = _Letras / 115

            If _Filas > 1 Then
                _Filas = Math.Ceiling(_Filas)
            Else
                _Filas = 1
            End If

            Dim _Cont = 1

            For i = 1 To _Filas

                _yPos += 20

                Dim _Obs1 = Mid(_Observaciones.Trim, _Cont, 114)
                'Dim _Obs2 = Mid(_Observaciones.Trim, _Cont + 114, 1)

                'If Not String.IsNullOrEmpty(_Obs2.Trim) Then
                '    _Obs1 += "-"
                'End If

                e.Graphics.DrawString(_Obs1.Trim,
                                      Fx_Fuente(_Enum_Fuentes.Arial, 10, FontStyle.Regular), Brushes.Black, _xPos, _yPos)
                _Cont += 114

            Next

            _yPos += 50
            e.Graphics.DrawString("Valores por definir",
                                  Fx_Fuente(_Enum_Fuentes.Arial, 10, FontStyle.Regular), Brushes.Black, _xPos, _yPos)

            'Dim _Font As FontStyle

            'If _Imprimir_Negrita Then
            '    _Font = FontStyle.Bold
            'Else
            '    _Font = FontStyle.Regular
            'End If

            e.HasMorePages = False

        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub

    Private Function Fx_Codigo_Barras(ByVal _Codigo As String) As PictureBox

        'Código de barras 
        Dim _Bmp As Bitmap = Nothing
        Dim _CodBarras As New PictureBox
        Dim _Imagen As New PictureBox

        Dim _iType As BarCode.Code128SubTypes =
        DirectCast([Enum].Parse(GetType(BarCode.Code128SubTypes), "CODE128"), BarCode.Code128SubTypes)

        _Bmp = BarCode.Code128(_Codigo, _iType, False)

        If Not IsNothing(_Bmp) Then
            _CodBarras.Image = _Bmp
        End If

        Return _CodBarras

    End Function

End Class
