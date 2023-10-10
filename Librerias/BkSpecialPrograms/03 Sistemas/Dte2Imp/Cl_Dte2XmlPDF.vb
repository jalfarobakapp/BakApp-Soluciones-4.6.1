Imports System.Web.Services
Imports DevComponents.DotNetBar
Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Drawing.Layout
Imports PdfSharp.Pdf
Imports PdfSharp.Pdf.IO

Public Class Cl_Dte2XmlPDF

    Public Property Crear_PDF_En_Directorio As Boolean
    Public Property Directorio As String

    Sub Sb_Imprimir_Regleta(_Formulario As Form,
                            _Dset_DTE As DataSet,
                            _Nombre_Archivo_PDF As String,
                            _Marca_Agua As String)

        Try

            Dim Tbl_Encabezado = _Dset_DTE.Tables("Encabezado")

            For Each _DTE_Fila As DataRow In Tbl_Encabezado.Rows

                Dim _Documento_Id As Integer = _DTE_Fila.Item("Documento_Id")
                Dim _Encabezado_Id As Integer = _DTE_Fila.Item("Encabezado_Id")

                Dim Documento As PdfDocument = New PdfDocument                      ' Crea el documento Pdf
                Dim pagina As PdfPage = Documento.AddPage                           ' Crea una pagina vacia

                Dim Fte_Detalle_Negrita As XFont = New XFont("Arial", 10, XFontStyle.Bold) ' Crea la fuente
                Dim Fte_Detalle_Normal As XFont = New XFont("Arial", 10, XFontStyle.Regular) ' Crea la fuente

                Dim FteNegrita_3 As XFont = New XFont("Arial", 3, XFontStyle.Bold) ' Crea la fuente
                Dim FteNegrita_6 As XFont = New XFont("Arial", 6, XFontStyle.Bold) ' Crea la fuente
                Dim FteNegrita_7 As XFont = New XFont("Arial", 7, XFontStyle.Bold) ' Crea la fuente
                Dim FteNegrita_8 As XFont = New XFont("Arial", 8, XFontStyle.Bold) ' Crea la fuente
                Dim FteNegrita_9 As XFont = New XFont("Arial", 9, XFontStyle.Bold) ' Crea la fuente
                Dim FteNegrita_10 As XFont = New XFont("Arial", 10, XFontStyle.Bold) ' Crea la fuente

                Dim FteNormal_3 As XFont = New XFont("Arial", 3, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_4 As XFont = New XFont("Arial", 4, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_5 As XFont = New XFont("Arial", 5, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_6 As XFont = New XFont("Arial", 6, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_7 As XFont = New XFont("Arial", 7, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_8 As XFont = New XFont("Arial", 8, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_9 As XFont = New XFont("Arial", 9, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_10 As XFont = New XFont("Arial", 10, XFontStyle.Regular) ' Crea la fuente

                Dim FteNormal_C_6 As XFont = New XFont("Courier New", 6, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_C_7 As XFont = New XFont("Courier New", 7, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_C_8 As XFont = New XFont("Courier New", 8, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_C_9 As XFont = New XFont("Courier New", 9, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_C_10 As XFont = New XFont("Courier New", 10, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_C_11 As XFont = New XFont("Courier New", 11, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_C_12 As XFont = New XFont("Courier New", 12, XFontStyle.Regular) ' Crea la fuente


                Dim FteNegrilla As XFont = New XFont("Arial", 15, XFontStyle.Bold)  ' Crea la fuente

                pagina.Size = PageSize.Letter
                pagina.Orientation = PageOrientation.Portrait

                Dim pgfx As XGraphics = XGraphics.FromPdfPage(pagina)               ' Crea un Objeto XGraphics para la creacion de los datos
                Dim tf As XTextFormatter                                            ' Objeto para formatear texto

                Dim Archivo As String = AppPath() & "\Data\" & RutEmpresa & "\DTE2PDF\" & _Nombre_Archivo_PDF & _Documento_Id & ".pdf"

                Dim Fte_Encabezado_Negrita_16 As XFont = New XFont("Arial", 16, XFontStyle.Bold)   ' Crea la fuente
                Dim Fte_Encabezado_Negrita_14 As XFont = New XFont("Arial", 14, XFontStyle.Bold)   ' Crea la fuente
                Dim Fte_Encabezado_Negrita_12 As XFont = New XFont("Arial", 12, XFontStyle.Bold)   ' Crea la fuente
                Dim Fte_Encabezado_Negrita_10 As XFont = New XFont("Arial", 10, XFontStyle.Bold)   ' Crea la fuente
                Dim Fte_Encabezado_Normal_10 As XFont = New XFont("Arial", 10, XFontStyle.Regular)   ' Crea la fuente

                Dim _Tipo_Documento As String = "FACTURA ELECTRÓNICA"

                ' EMISOR

                Dim Xpos = 10 ' Columna
                Dim Ypos = 30 ' Fila
                Dim Contador As Integer = 1
                Dim Con As Integer = 1
                Dim Dig As Integer = 50
                Dim Cm As Integer = 1

                'Dim filter As String = String.Format("Id = " & Id)
                'Dim rows() As DataRow = dt.Select(filter)

                Dim Tbl_IdDoc = _Dset_DTE.Tables("IdDoc") '.Select("Encabezado_Id = 0")

                Dim _Id_Doc As Integer = Tbl_IdDoc.Rows(_Encabezado_Id).Item("TipoDTE")
                Dim _Nro_Documento As String = Tbl_IdDoc.Rows(_Encabezado_Id).Item("Folio")

                Dim Tbl_Emisor = _Dset_DTE.Tables("Emisor")

                With Tbl_Emisor

                    Dim _Razon_Emisor As String = Trim(.Rows(_Encabezado_Id).Item("RznSoc")) '"Razon Social Emisor de documento"
                    Dim _Rt() As String = Split(Trim(.Rows(_Encabezado_Id).Item("RUTEmisor")), "-")
                    Dim _Rut_Emisor As String = FormatNumber(De_Txt_a_Num_01(_Rt(0), 0), 0) & "-" & _Rt(1)

                    Dim _Giro_Emisor As String = Valor_Columna(.Rows(_Encabezado_Id), 0, "GiroEmis") 'Trim(.Rows(0).Item("GiroEmis"))
                    Dim _direccion_Emisor As String = Valor_Columna(.Rows(_Encabezado_Id), 0, "DirOrigen") 'Trim(.Rows(0).Item("DirOrigen"))
                    Dim _Ciudad_Emisor As String = Valor_Columna(.Rows(_Encabezado_Id), 0, "CiudadOrigen") 'Trim(.Rows(0).Item("CiudadOrigen"))
                    Dim _Comuna_Emisor As String = Valor_Columna(.Rows(_Encabezado_Id), 0, "CmnaOrigen") 'Trim(.Rows(0).Item("CmnaOrigen"))

                    Dim _Telefono_Emisor As String = "" '.Rows(0).Item("RUTEmisor")

                    _Tipo_Documento = Tipo_Documento(_Id_Doc)

                    Ypos = 40
                    pgfx.DrawString("R.U.T.:" & _Rut_Emisor, Fte_Encabezado_Negrita_16, XBrushes.Red, 410, Ypos)
                    Ypos += 10

                    '' UTIL PARA ALINEAR IMPRESION
                    tf = New XTextFormatter(pgfx)
                    tf.Alignment = XParagraphAlignment.Center
                    ''

                    tf.DrawString(_Tipo_Documento, Fte_Encabezado_Negrita_12, XBrushes.Red, New XRect(375, Ypos, 220, 0))
                    Ypos += 15
                    tf.DrawString("ELECTRÓNICA", Fte_Encabezado_Negrita_12, XBrushes.Red, New XRect(375, Ypos, 220, 0))
                    Ypos += 20
                    tf.DrawString("N° " & _Nro_Documento, Fte_Encabezado_Negrita_16, XBrushes.Red, New XRect(375, Ypos, 220, 0))
                    'pgfx.DrawString("N° " & _Nro_Documento, Fte_Encabezado_Negrita_16, XBrushes.Red, 430, Ypos)

                    Ypos = 30
                    pgfx.DrawString(UCase(_Razon_Emisor), Fte_Encabezado_Negrita_14, XBrushes.Black, 20, Ypos)
                    Ypos += 15
                    pgfx.DrawString(UCase(_direccion_Emisor), Fte_Encabezado_Negrita_10, XBrushes.Black, 20, Ypos)
                    Ypos += 15
                    pgfx.DrawString(UCase(_Giro_Emisor), FteNegrita_7, XBrushes.Black, 20, Ypos)
                    Ypos += 15
                    pgfx.DrawString(UCase(_Ciudad_Emisor), Fte_Encabezado_Negrita_10, XBrushes.Black, 20, Ypos)
                    Ypos += 15
                    pgfx.DrawString(UCase(_Comuna_Emisor), Fte_Encabezado_Negrita_10, XBrushes.Black, 20, Ypos)
                    Ypos += 15
                    pgfx.DrawString(_Telefono_Emisor, Fte_Encabezado_Negrita_10, XBrushes.Black, 20, Ypos)
                    Ypos += 15

                End With

                Dim DD = Tbl_IdDoc

                Dim _Fecha_Emision As Date = Tbl_IdDoc.Rows(_Encabezado_Id).Item("FchEmis")
                Dim _Fecha_Vencimiento As Date

                Try
                    _Fecha_Vencimiento = Tbl_IdDoc.Rows(_Encabezado_Id).Item("FchVenc")
                Catch ex As Exception
                    If MessageBoxEx.Show(_Formulario, "Documento sin fecha de vencimiento" & vbCrLf &
                                    "¿Desea ingresar la fecha de vencimiento?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Try
                            _Fecha_Vencimiento = InputBox("Ingrese fecha de vencimiento del documento en formato dd/mm/aaaa o dd-mm-aaaa",
                                                      "Fecha de vencimiento", _Fecha_Emision)
                        Catch exx As Exception
                            MessageBoxEx.Show(_Formulario, exx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            _Fecha_Vencimiento = Nothing
                        End Try
                    Else
                        _Fecha_Vencimiento = Nothing
                    End If

                End Try


                Dim Tbl_Receptor = _Dset_DTE.Tables("Receptor")

                'Dim _FILE_XSD = "D:\Empresas\Agrorama\Documentos DTE\Documentos Ayuda SII\schema_dte\schema_dte\DTE_v10.xsd"
                'Tbl_Receptor.WriteXmlSchema(_FILE_XSD)

                'Dim newTable As New DataTable
                'newTable.ReadXmlSchema(_FILE_XSD)
                'RECEPTOR

                With Tbl_Receptor

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''''   ENCABEZADO DOCUMENTO
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim _Razon_Receptor As String = Trim(.Rows(_Encabezado_Id).Item("RznSocRecep")) '"Razon Social Receptor de documento"

                    Dim _Rt() As String = Split(Trim(.Rows(_Encabezado_Id).Item("RUTRecep")), "-")
                    Dim _Rut_Receptor As String = FormatNumber(De_Txt_a_Num_01(_Rt(0), 0), 0) & "-" & _Rt(1)

                    Dim _Giro_Receptor As String

                    Try
                        _Giro_Receptor = Trim(.Rows(_Encabezado_Id).Item("GiroRecep"))
                    Catch ex As Exception
                        _Giro_Receptor = String.Empty
                    End Try

                    Dim _direccion_Receptor As String = Trim(.Rows(_Encabezado_Id).Item("DirRecep"))
                    Dim _Ciudad_Receptor As String = Valor_Columna(.Rows(_Encabezado_Id), 0, "CiudadRecep") 'Trim(.Rows(0).Item("CiudadRecep"))
                    Dim _Comuna_Receptor As String = Valor_Columna(.Rows(_Encabezado_Id), 0, "CmnaRecep") 'Trim(.Rows(0).Item("CmnaRecep"))
                    Dim _Telefono_Receptor As String = Valor_Columna(.Rows(_Encabezado_Id), 0, "Contacto") 'Trim(.Rows(0).Item("RznSocRecep"))
                    '
                    Ypos = 140
                    pgfx.DrawString("RUT", FteNegrita_8, XBrushes.Black, 35, Ypos)
                    pgfx.DrawString(": " & _Rut_Receptor, FteNormal_8, XBrushes.Black, 100, Ypos)
                    pgfx.DrawString("FECHA EMISION", FteNegrita_8, XBrushes.Black, 380, Ypos)
                    pgfx.DrawString(": " & FormatDateTime(_Fecha_Emision, DateFormat.LongDate), FteNormal_8, XBrushes.Black, 450, Ypos)
                    Ypos += 20

                    pgfx.DrawString("RAZON SOCIAL", FteNegrita_8, XBrushes.Black, 35, Ypos)
                    pgfx.DrawString(": " & UCase(_Razon_Receptor), FteNormal_8, XBrushes.Black, 100, Ypos)
                    pgfx.DrawString("COMUNA", FteNegrita_8, XBrushes.Black, 380, Ypos)
                    pgfx.DrawString(": " & UCase(_Comuna_Receptor), FteNormal_8, XBrushes.Black, 450, Ypos)
                    Ypos += 20

                    pgfx.DrawString("DIRECCION", FteNegrita_8, XBrushes.Black, 35, Ypos)
                    pgfx.DrawString(": " & UCase(_direccion_Receptor), FteNormal_8, XBrushes.Black, 100, Ypos)
                    pgfx.DrawString("FECHA VENC.", FteNegrita_8, XBrushes.Black, 380, Ypos)
                    pgfx.DrawString(": " & UCase(_Fecha_Vencimiento), FteNormal_8, XBrushes.Black, 450, Ypos)
                    Ypos += 20

                    pgfx.DrawString("CIUDAD", FteNegrita_8, XBrushes.Black, 35, Ypos)
                    pgfx.DrawString(": " & UCase(_Ciudad_Receptor), FteNormal_8, XBrushes.Black, 100, Ypos)
                    pgfx.DrawString("TELEFONO", FteNegrita_8, XBrushes.Black, 380, Ypos)
                    pgfx.DrawString(": " & UCase(_Telefono_Receptor), FteNormal_8, XBrushes.Black, 450, Ypos)
                    Ypos += 20

                End With

                pgfx.DrawString("|", FteNormal_3, XBrushes.Green, 1, 20)
                pgfx.DrawString(Cm, FteNormal_3, XBrushes.Green, 1, 25)

                'Escribimos el titulo
                Dim rect As New XRect(15, 15, 585, 20)

                ' XStringFormat.Center)

                'escribimos el texto
                tf = New XTextFormatter(pgfx)
                tf.Alignment = XParagraphAlignment.Justify
                rect = New XRect(15, 45, 585, 60)
                ' tf.DrawString(txTexto.Text, FteNormal_10, XBrushes.Black, rect)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''   ENCABEZADO DE DETALLE
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Ypos = 245

                pgfx.DrawString("CANTIDAD", FteNegrita_7, XBrushes.Black, 20, Ypos)
                pgfx.DrawString("CODIGO", FteNegrita_7, XBrushes.Black, 80, Ypos)
                pgfx.DrawString("DESCRIPCION", FteNegrita_7, XBrushes.Black, 220, Ypos)
                pgfx.DrawString("PRECIO", FteNegrita_7, XBrushes.Black, 395, Ypos)
                pgfx.DrawString("%D.", FteNegrita_7, XBrushes.Black, 450, Ypos)
                pgfx.DrawString("DSCTO. $", FteNegrita_7, XBrushes.Black, 480, Ypos)
                pgfx.DrawString("TOTAL", FteNegrita_7, XBrushes.Black, 550, Ypos)

                Ypos = 265

                Dim _Valor As String
                Dim _Caracter As String
                Dim _Largo As Integer = 18
                Dim numero As Integer = 10 'Random.Next(1, 4)

                'Inicializar la clase Random  
                Dim Random As New Random()

                Dim Tbl_Detalle = _Dset_DTE.Tables("Detalle")
                Dim Tbl_CdgItem = _Dset_DTE.Tables("CdgItem")

                Contador = 0

                For Each Fila As DataRow In Tbl_Detalle.Rows

                    Dim Id = Fila.Item("Documento_Id")

                    If Id = _Documento_Id Then

                        Dim _Codigo As String = String.Empty
                        Dim _Detalle_Id As String

                        Try
                            _Detalle_Id = Fila.Item("Detalle_Id")
                        Catch ex As Exception
                            _Detalle_Id = 0
                        End Try


                        If Not (Tbl_CdgItem Is Nothing) Then

                            Try
                                _Codigo = Tbl_CdgItem.Rows(_Detalle_Id).Item("VlrCodigo").ToString.Trim
                            Catch ex As Exception
                                _Codigo = String.Empty
                            End Try

                        End If

                        Dim _Cantidad As Double

                        Try
                            _Cantidad = De_Txt_a_Num_01(Fila.Item("QtyItem"))
                        Catch ex As Exception
                            _Cantidad = 1
                        End Try

                        Dim _DscItem As String
                        Dim _NmbItem As String

                        Try
                            _DscItem = Trim(Fila.Item("DscItem"))
                        Catch ex As Exception
                            _DscItem = String.Empty
                        End Try

                        Try
                            _NmbItem = Trim(Fila.Item("NmbItem"))
                        Catch ex As Exception
                            _NmbItem = String.Empty
                        End Try

                        Dim _Descripcion As String = _NmbItem

                        Dim _Descripcion_01 = String.Empty
                        Dim _Descripcion_02 = String.Empty

                        If _Descripcion.Length > 63 Then

                            _Descripcion_01 = Mid(_Descripcion, 1, 63)
                            _Descripcion_02 = Mid(_Descripcion, 64, _Descripcion.Length)

                        End If

                        Dim _Precio As Double = Valor_Columna(Fila, 0, "PrcItem", True)
                        Dim _DecuentoPct As Double = Valor_Columna(Fila, 0, "DescuentoPct", True)
                        Dim _DescuentoMonto As Double = Valor_Columna(Fila, 0, "DescuentoMonto", True)
                        Dim _Monto As Double = Valor_Columna(Fila, 0, "MontoItem", True)

                        Dim _Decimal As Integer


                        If Int(_DecuentoPct) Then : _Decimal = 2 : Else : _Decimal = 0 : End If
                        Dim _DecuentoPct_ = Rellenar(FormatNumber(_DecuentoPct, _Decimal), 4, " ", False)

                        If Int(_DescuentoMonto) Then : _Decimal = 2 : Else : _Decimal = 0 : End If
                        Dim _DescuentoMonto_ = Rellenar(FormatNumber(_DescuentoMonto, _Decimal), 13, " ", False)

                        If Int(_Cantidad) Then : _Decimal = 2 : Else : _Decimal = 0 : End If
                        Dim _Cantidad_ = Rellenar(FormatNumber(_Cantidad, _Decimal), 9, " ", False)

                        If Int(_Precio) Then : _Decimal = 2 : Else : _Decimal = 0 : End If
                        Dim _Precio_ = Rellenar(FormatNumber(_Precio, _Decimal), 13, " ", False)


                        Dim _Monto_ = Rellenar(FormatNumber(_Monto, 0), 13, " ", False)

                        pgfx.DrawString(_Cantidad_, FteNormal_C_7, XBrushes.Black, 15, Ypos)
                        pgfx.DrawString(_Codigo, FteNormal_C_7, XBrushes.Black, 70, Ypos)

                        If Len(_Descripcion) > 63 Then
                            pgfx.DrawString(_Descripcion_01, FteNormal_C_6, XBrushes.Black, 140, Ypos)
                        Else
                            pgfx.DrawString(_Descripcion, FteNormal_C_7, XBrushes.Black, 140, Ypos)
                        End If

                        pgfx.DrawString(_Precio_, FteNormal_C_7, XBrushes.Black, 380, Ypos)
                        pgfx.DrawString(_DecuentoPct_, FteNormal_C_7, XBrushes.Black, 446, Ypos) ' porcentaje descuento
                        pgfx.DrawString(_DescuentoMonto_, FteNormal_C_7, XBrushes.Black, 460, Ypos) ' valor descuento
                        pgfx.DrawString(_Monto_, FteNormal_C_7, XBrushes.Black, 530, Ypos)

                        If Not String.IsNullOrEmpty(_Descripcion_02) Then
                            Ypos += 10
                            pgfx.DrawString(_Descripcion_02, FteNormal_C_6, XBrushes.Black, 140, Ypos)
                        End If

                        If Not String.IsNullOrEmpty(_DscItem) Then
                            Ypos += 10
                            pgfx.DrawString(_DscItem, FteNormal_C_6, XBrushes.Black, 145, Ypos)
                        End If

                        Ypos += 10
                        Contador += 1

                    End If

                Next



                Dim elipse As XSize
                elipse.Height = 10
                elipse.Width = 10

                rect = New XRect(15, 230, 580, 380)
                pgfx.DrawRoundedRectangle(XPens.Black, rect, elipse)

                rect = New XRect(15, 250, 580, 320)
                pgfx.DrawRectangle(XPens.Black, rect)


                rect = New XRect(15, 250, 580, 320)
                pgfx.DrawRectangle(XPens.Black, rect)

                rect = New XRect(65, 230, 70, 340)
                pgfx.DrawRectangle(XPens.Black, rect)

                rect = New XRect(135, 230, 240, 340)
                pgfx.DrawRectangle(XPens.Black, rect)

                rect = New XRect(375, 230, 70, 340)
                pgfx.DrawRectangle(XPens.Black, rect)

                rect = New XRect(445, 230, 80, 340)
                pgfx.DrawRectangle(XPens.Black, rect)

                rect = New XRect(465, 230, 60, 340)
                pgfx.DrawRectangle(XPens.Black, rect)

                rect = New XRect(465, 230, 60, 340)
                pgfx.DrawRectangle(XPens.Black, rect)

                Dim pen As XPen = New XPen(XColor.FromArgb(255, 0, 0), 1)
                pgfx.DrawLine(XPens.Red, New XPoint(15, Ypos), New XPoint(595, Ypos)) ' New XPoint(pagina.Width.Point, pagina.Height.Point))
                pgfx.DrawLine(XPens.Red, New XPoint(15, Ypos + 2), New XPoint(595, Ypos + 2)) ' New XPoint(pagina.Width.Point, pagina.Height.Point))

                Ypos += 10

                'TIPO DE DOCUMENTO FOLIO FECHA MOTIVO
                'Orden de Compra 58 03-10-2014

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''' REFERENCIA 
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim Tbl_Referencia = _Dset_DTE.Tables("Referencia")


                If Not (Tbl_Referencia Is Nothing) Then

                    pgfx.DrawString("Tipo Documento", FteNegrita_6, XBrushes.Black, 140, Ypos)
                    pgfx.DrawString("Folio", FteNegrita_6, XBrushes.Black, 210, Ypos)
                    pgfx.DrawString("Fecha", FteNegrita_6, XBrushes.Black, 255, Ypos)
                    pgfx.DrawString("Motivo", FteNegrita_6, XBrushes.Black, 290, Ypos)
                    Ypos += 10

                    For Each Fila As DataRow In Tbl_Referencia.Rows

                        Dim ID = Fila.Item("Documento_Id")

                        If ID = _Documento_Id Then

                            Dim _Id_Doc_Ref As String = Fila.Item("TpoDocRef")
                            Dim _Doc_Ref As String = Tipo_Documento(_Id_Doc_Ref)

                            Dim _Nro_Doc_Ref As String = Fila.Item("FolioRef")
                            Dim _FchRef As Date = Fila.Item("FchRef")

                            Dim _CodRef As String
                            Dim _Motivo As String

                            Try
                                _CodRef = Fila.Item("CodRef")
                                _Motivo = Tipo_Referencia(_CodRef)
                            Catch ex As Exception
                                _CodRef = String.Empty
                                _Motivo = String.Empty
                            End Try

                            pgfx.DrawString(_Doc_Ref, FteNormal_5, XBrushes.Black, 140, Ypos)
                            pgfx.DrawString(_Nro_Doc_Ref, FteNormal_5, XBrushes.Black, 210, Ypos)
                            pgfx.DrawString(_FchRef, FteNormal_5, XBrushes.Black, 255, Ypos)
                            pgfx.DrawString(_Motivo, FteNormal_5, XBrushes.Black, 290, Ypos)
                            Ypos += 8

                        End If

                    Next

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''   PIE 
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim Tbl_ImptoReten = _Dset_DTE.Tables("ImptoReten")

                Ypos = 585


                Dim _Impuestos_Ila As Double

                If Not (Tbl_ImptoReten Is Nothing) Then
                    '_Impuestos_Ila = Tbl_ImptoReten.Compute("Sum(MontoImp)", "MontoImp > 0") ')Dif_GDI_Ud1 > 0")

                    For Each _Fila_Ila As DataRow In Tbl_ImptoReten.Rows
                        _Impuestos_Ila += Valor_Columna(_Fila_Ila, 0, "MontoImp", True)
                    Next
                End If


                Dim Tbl_Totales = _Dset_DTE.Tables("Totales")

                If Not (Tbl_Totales Is Nothing) Then

                    Dim _TasaIVA As Double
                    Dim _IVA As Double

                    Dim _Descuento As Double
                    Dim _Exento As Double
                    Dim _MntNeto As Double
                    Dim _MntTotal As Double

                    Try
                        _MntNeto = De_Txt_a_Num_01(Tbl_Totales.Rows(_Encabezado_Id).Item("MntNeto"))
                    Catch ex As Exception
                        _MntNeto = 0
                    End Try

                    _MntTotal = De_Txt_a_Num_01(Tbl_Totales.Rows(_Encabezado_Id).Item("MntTotal"))

                    Try
                        _TasaIVA = De_Txt_a_Num_01(Tbl_Totales.Rows(_Encabezado_Id).Item("TasaIVA"))
                    Catch ex As Exception
                        _TasaIVA = 0
                    End Try

                    Try
                        _IVA = De_Txt_a_Num_01(Tbl_Totales.Rows(_Encabezado_Id).Item("IVA"))
                    Catch ex As Exception
                        _IVA = 0
                    End Try

                    Try
                        _Exento = De_Txt_a_Num_01(Tbl_Totales.Rows(_Encabezado_Id).Item("MntExe"))
                    Catch ex As Exception
                        _Exento = 0
                    End Try

                    _MntTotal = De_Txt_a_Num_01(Tbl_Totales.Rows(_Encabezado_Id).Item("MntTotal"))

                    Dim _Total_Palabras As String = Trim(UCase(Letras(_MntTotal))) & " ---------"
                    pgfx.DrawString("SON :" & _Total_Palabras, FteNegrita_8, XBrushes.Black, 25, Ypos)
                    Ypos += 20

                    Dim _Tota_Descuento As String
                    _Tota_Descuento = FormatNumber(_Descuento, 0)
                    _Tota_Descuento = ": $ " & Rellenar(_Tota_Descuento, 11, " ", False)

                    Dim _Tota_Exento As String
                    _Tota_Exento = FormatNumber(_Exento, 0)
                    _Tota_Exento = ": $ " & Rellenar(_Tota_Exento, 11, " ", False)

                    Dim _Total_Neto As String
                    _Total_Neto = FormatNumber(_MntNeto, 0)
                    _Total_Neto = ": $ " & Rellenar(_Total_Neto, 11, " ", False)

                    Dim _Total_Ila As String
                    _Total_Ila = FormatNumber(_IVA, 0)
                    _Total_Ila = ": $ " & Rellenar(_Impuestos_Ila, 11, " ", False)

                    Dim _Total_Iva As String
                    _Total_Iva = FormatNumber(_IVA, 0)
                    _Total_Iva = ": $ " & Rellenar(_Total_Iva, 11, " ", False)

                    Dim _Total_Bruto As String
                    _Total_Bruto = FormatNumber(_MntTotal, 0)
                    _Total_Bruto = ": $ " & Rellenar(_Total_Bruto, 11, " ", False)

                    Ypos = 635
                    'pgfx.DrawString("DESCUENTO", FteNegrita_8, XBrushes.Black, 425, Ypos)
                    'pgfx.DrawString(_Tota_Descuento, FteNormal_C_12, XBrushes.Black, 475, Ypos)
                    'Ypos += 20
                    pgfx.DrawString("EXENTO", FteNegrita_8, XBrushes.Black, 425, Ypos)
                    pgfx.DrawString(_Tota_Exento, FteNormal_C_12, XBrushes.Black, 475, Ypos)
                    Ypos += 20
                    pgfx.DrawString("NETO", FteNegrita_8, XBrushes.Black, 425, Ypos)
                    pgfx.DrawString(_Total_Neto, FteNormal_C_12, XBrushes.Black, 475, Ypos)
                    Ypos += 20
                    pgfx.DrawString("IMPUESTOS", FteNegrita_8, XBrushes.Black, 425, Ypos)
                    pgfx.DrawString(_Total_Ila, FteNormal_C_12, XBrushes.Black, 475, Ypos)
                    Ypos += 20
                    pgfx.DrawString("IVA (" & _TasaIVA & ")", FteNegrita_8, XBrushes.Black, 425, Ypos)
                    pgfx.DrawString(_Total_Iva, FteNormal_C_12, XBrushes.Black, 475, Ypos)
                    Ypos += 20
                    pgfx.DrawString("TOTAL", FteNegrita_8, XBrushes.Black, 425, Ypos)
                    pgfx.DrawString(_Total_Bruto, FteNormal_C_12, XBrushes.Black, 475, Ypos)
                    Ypos += 20

                End If


                'Insertamos un cuadro
                rect = New XRect(50, 200, 100, 50)
                pen = New XPen(XColor.FromArgb(255, 0, 0))
                ' pgfx.DrawRoundedRectangle(XPens.Blue, rect, elipse)

                rect = New XRect(375, 20, 218, 90)
                pen = New XPen(XColor.FromArgb(255, 0, 0), 3)
                pgfx.DrawRectangle(pen, rect)


                rect = New XRect(15, 120, 580, 100)
                pgfx.DrawRoundedRectangle(XPens.Black, rect, elipse)

                'pgfx.DrawRectangle(XPens.Black, rect)

                rect = New XRect(415, 620, 178, 125)
                pgfx.DrawRoundedRectangle(XPens.Black, rect, elipse)





                '********************************************** TIMBRE ELECTRONICO **************************************************
                Dim bm As Bitmap = Nothing
                Dim CodBarras As XImage ' PictureBox

                Dim _TED = _Dset_DTE.Tables("TED")
                Dim _DD = _Dset_DTE.Tables("DD")
                Dim _CAF = _Dset_DTE.Tables("CAF")
                Dim _DA = _Dset_DTE.Tables("DA")
                Dim _RNG = _Dset_DTE.Tables("RNG")
                Dim _RSAPK = _Dset_DTE.Tables("RSAPK")
                Dim _FRMA = _Dset_DTE.Tables("FRMA")



                Dim _Timbre As String = "<DD><RE>" & _DD.Rows(_Documento_Id).Item("RE") & "</RE><TD>" & _DD.Rows(_Documento_Id).Item("TD") & "</TD><F>" & _DD.Rows(_Documento_Id).Item("F") &
                                        "</F><FE>" & _DD.Rows(_Documento_Id).Item("FE") & "</FE><RR>" & _DD.Rows(_Documento_Id).Item("RR") & "</RR><RSR>" & _DD.Rows(_Documento_Id).Item("RSR") & "</RSR>" &
                                        "<MNT>" & _DD.Rows(_Documento_Id).Item("MNT") & "</MNT><IT1>" & _DD.Rows(_Documento_Id).Item("IT1") & "</IT1>" &
                                        "<CAF version=" & Chr(34) & _CAF.Rows(_Documento_Id).Item("version") & Chr(34) & "><DA>" &
                                        "<RE>" & _DA.Rows(_Documento_Id).Item("RE") & "</RE><RS>" & _DA.Rows(_Documento_Id).Item("RS") & "</RS>" &
                                        "<TD>" & _DA.Rows(_Documento_Id).Item("TD") & "</TD><RNG><D>" & _RNG.Rows(_Documento_Id).Item("D") & "</D><H>" & _RNG.Rows(_Documento_Id).Item("H") & "</H>" &
                                        "</RNG><FA>" & _DA.Rows(_Documento_Id).Item("FA") & "</FA>" &
                                        "<RSAPK><M>" & _RSAPK.Rows(_Documento_Id).Item("M") & "</M><E>" & _RSAPK.Rows(_Documento_Id).Item("E") & "</E></RSAPK>" &
                                        "<IDK>" & _DA.Rows(_Documento_Id).Item("IDK") & "</IDK></DA>" &
                                        "<FRMA algoritmo=" & Chr(34) & _FRMA.Rows(_Documento_Id).Item("algoritmo") & Chr(34) &
                                        ">" & _FRMA.Rows(_Documento_Id).Item("FRMA_Text") & "</FRMA></CAF><TSTED>" & _DD.Rows(_Documento_Id).Item("TSTED") & "</TSTED></DD>"

                'Dim iType As BarCode.Code128SubTypes = _
                ' DirectCast([Enum].Parse(GetType(BarCode.Code128SubTypes), "CODE128"), BarCode.Code128SubTypes)
                bm = BarCode.PDF417(_Timbre, 1, 8)

                'Image as XImage = XImage.FromFile(jpegSamplePath)
                'Dim x As Double = ((250 - Image.PixelWidth * 72 / Image.HorizontalResolution) / 2)
                'GFX.DrawImage(Image, x, 0)

                If Not IsNothing(bm) Then
                    CodBarras = bm
                End If

                'rect = New XRect(15, 620, 250, 125)
                'pgfx.DrawRoundedRectangle(XPens.Black, rect, elipse)

                pgfx.DrawImage(CodBarras, 45, 630)
                pgfx.DrawString("Timbre Electrónico S.I.I.", FteNegrita_9, XBrushes.Black, 90, 750)
                'e.Graphics.DrawImage(CodBarras.Image, Xpos + 10, Ypos - 35, 220, 140)

                '*********************************************************************************************************************

                'Insertamos un cuadro con color interno
                'rect = New XRect(200,200,100,50)
                'pgfx.DrawRoundedRectangle(pen, Xbrushes.Aqua ,rect,elipse)

                'Insertamos la imagen en una hoja nueva
                'If File.Exists(txImagen.Text) Then
                'pagina = Documento.AddPage
                'pagina.Size = PageSize.Letter
                'pgfx = XGraphics.FromPdfPage(pagina)
                'Dim imagen As XImage = XImage.FromFile(txImagen.Text)
                'pgfx.DrawImage(imagen, 50, 150, 500, 375)
                'End If


                'IMPRIMIR REGLETA
                For x As Integer = 1 To 1000
                    If Con < 50 Then

                        If Contador = 5 Or Contador = 10 Then

                            Dim y_ As Integer = 40

                            If Contador = 5 Then y_ = 35

                            pgfx.DrawString("|", FteNormal_3, XBrushes.Green, x, 30)
                            pgfx.DrawString(Contador, FteNormal_3, XBrushes.Green, x, y_)
                            pgfx.DrawString("|", FteNormal_3, XBrushes.Green, x, 200)
                            pgfx.DrawString(Contador, FteNormal_3, XBrushes.Green, x, 200 - y_ + 20)
                            pgfx.DrawString("|", FteNormal_3, XBrushes.Green, x, 400)
                            pgfx.DrawString(Contador, FteNormal_3, XBrushes.Green, x, 400 - y_ + 20)
                            pgfx.DrawString("|", FteNormal_3, XBrushes.Green, x, 600)
                            pgfx.DrawString(Contador, FteNormal_3, XBrushes.Green, x, 600 - y_ + 20)
                            pgfx.DrawString("|", FteNormal_3, XBrushes.Green, x, 800)
                            pgfx.DrawString(Contador, FteNormal_3, XBrushes.Green, x, 800 - y_ + 20)
                            Cm += 5
                            If Contador = 10 Then
                                Contador = 0
                            End If
                        Else
                            pgfx.DrawString(" ", FteNormal_10, XBrushes.Green, x, 20)
                            pgfx.DrawString(" ", FteNormal_10, XBrushes.Green, x, 210)
                            pgfx.DrawString(" ", FteNormal_10, XBrushes.Green, x, 410)
                            pgfx.DrawString(" ", FteNormal_10, XBrushes.Green, x, 610)
                            pgfx.DrawString(" ", FteNormal_10, XBrushes.Green, x, 810)
                            'Cm = 5
                        End If
                    Else
                        pgfx.DrawString(Dig, FteNormal_8, XBrushes.Green, x, 20)
                        pgfx.DrawString(Dig, FteNormal_8, XBrushes.Green, x, 210)
                        pgfx.DrawString(Dig, FteNormal_8, XBrushes.Green, x, 410)
                        pgfx.DrawString(Dig, FteNormal_8, XBrushes.Green, x, 610)
                        pgfx.DrawString(Dig, FteNormal_8, XBrushes.Green, x, 810)

                        pgfx.DrawString("|", FteNormal_10, XBrushes.Green, x, 30)
                        pgfx.DrawString("|", FteNormal_10, XBrushes.Green, x, 200)
                        pgfx.DrawString("|", FteNormal_10, XBrushes.Green, x, 400)
                        pgfx.DrawString("|", FteNormal_10, XBrushes.Green, x, 600)
                        pgfx.DrawString("|", FteNormal_10, XBrushes.Green, x, 800)

                        Dig += 50
                        Con = 1
                        Contador = 0
                    End If

                    Con += 1
                    Contador += 1
                Next

                Contador = 1
                Con = 1
                Dig = 50

                pgfx.DrawString("__", FteNormal_3, XBrushes.Green, 25, 1)

                For y As Integer = 1 To 1000
                    If Con < 50 Then
                        If Contador = 5 Then
                            pgfx.DrawString("______ " & y, FteNormal_4, XBrushes.Green, 25, y)
                            pgfx.DrawString("__", FteNormal_3, XBrushes.Green, 25, y)
                            pgfx.DrawString(y & " ______", FteNormal_4, XBrushes.Green, 580, y)
                            pgfx.DrawString("__", FteNormal_3, XBrushes.Green, 590, y)
                            Contador = 0
                        Else
                            pgfx.DrawString(" ", FteNormal_10, XBrushes.Green, 25, y)
                            pgfx.DrawString(" ", FteNormal_10, XBrushes.Green, 590, y)
                        End If
                    Else
                        pgfx.DrawString(Dig, FteNormal_8, XBrushes.Green, 8, y)
                        pgfx.DrawString(Dig, FteNormal_8, XBrushes.Green, 573, y)

                        pgfx.DrawString("____________", FteNormal_3, XBrushes.Green, 8, y)
                        pgfx.DrawString("____________", FteNormal_3, XBrushes.Green, 590, y)
                        Dig += 50
                        Con = 1
                        Contador = 0
                    End If
                    Con += 1
                    Contador += 1
                Next



                Try
                    'si el archivo esta abierto da error
                    'para que averiguen como saber si ela rchivo esta abierto y cerrarlo
                    ' antes de grabar uno nuevo
                    Documento.Save(Archivo)
                Catch ex As Exception
                End Try

                'If _Poner_Marca_de_agua Then

                '    Dim rot(3) As Double
                '    rot(0) = 1.5
                '    rot(1) = 2
                '    rot(2) = 100
                '    rot(3) = 8
                '    PoneMarcaAgua(Archivo, _Marca_Agua, rot)

                'End If

                Process.Start(Archivo)

            Next

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message & vbCrLf &
                              "Problemas al leer el archivo XML de origen, puede que el archivos no tenga la estructura adecuada", "Problema en DTE", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ''' <summary>
    ''' Crear PDF desde archivo xml enviado por el proveedor, para creación por formulario
    ''' </summary>
    ''' <param name="_Formulario"></param>
    ''' <param name="_Dset_DTE"></param>
    ''' <param name="_Nombre_Archivo_PDF"></param>
    ''' <param name="_Marca_Agua"></param>
    ''' <param name="_Poner_Marca_de_agua"></param>
    Sub Sb_Crear_PDF2XML(_Formulario As Form,
                         _Dset_DTE As DataSet,
                         _Nombre_Archivo_PDF As String,
                         _Marca_Agua As String,
                         _Poner_Marca_de_agua As Boolean,
                         _Abrir_PDF As Boolean)

        Try

            Dim Tbl_Encabezado = _Dset_DTE.Tables("Encabezado")

            For Each _DTE_Fila As DataRow In Tbl_Encabezado.Rows

                Dim _Documento_Id As Integer = _DTE_Fila.Item("Documento_Id")
                Dim _Encabezado_Id As Integer = _DTE_Fila.Item("Encabezado_Id")

                Dim Documento As PdfDocument = New PdfDocument                      ' Crea el documento Pdf
                Dim pagina As PdfPage = Documento.AddPage                           ' Crea una pagina vacia

                Dim Fte_Detalle_Negrita As XFont = New XFont("Arial", 10, XFontStyle.Bold) ' Crea la fuente
                Dim Fte_Detalle_Normal As XFont = New XFont("Arial", 10, XFontStyle.Regular) ' Crea la fuente

                Dim FteNegrita_3 As XFont = New XFont("Arial", 3, XFontStyle.Bold) ' Crea la fuente
                Dim FteNegrita_6 As XFont = New XFont("Arial", 6, XFontStyle.Bold) ' Crea la fuente
                Dim FteNegrita_7 As XFont = New XFont("Arial", 7, XFontStyle.Bold) ' Crea la fuente
                Dim FteNegrita_8 As XFont = New XFont("Arial", 8, XFontStyle.Bold) ' Crea la fuente
                Dim FteNegrita_9 As XFont = New XFont("Arial", 9, XFontStyle.Bold) ' Crea la fuente
                Dim FteNegrita_10 As XFont = New XFont("Arial", 10, XFontStyle.Bold) ' Crea la fuente

                Dim FteNormal_3 As XFont = New XFont("Arial", 3, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_4 As XFont = New XFont("Arial", 4, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_5 As XFont = New XFont("Arial", 5, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_6 As XFont = New XFont("Arial", 6, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_7 As XFont = New XFont("Arial", 7, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_8 As XFont = New XFont("Arial", 8, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_9 As XFont = New XFont("Arial", 9, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_10 As XFont = New XFont("Arial", 10, XFontStyle.Regular) ' Crea la fuente

                Dim FteNormal_C_6 As XFont = New XFont("Courier New", 6, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_C_7 As XFont = New XFont("Courier New", 7, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_C_8 As XFont = New XFont("Courier New", 8, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_C_9 As XFont = New XFont("Courier New", 9, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_C_10 As XFont = New XFont("Courier New", 10, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_C_11 As XFont = New XFont("Courier New", 11, XFontStyle.Regular) ' Crea la fuente
                Dim FteNormal_C_12 As XFont = New XFont("Courier New", 12, XFontStyle.Regular) ' Crea la fuente


                Dim FteNegrilla As XFont = New XFont("Arial", 15, XFontStyle.Bold)  ' Crea la fuente

                pagina.Size = PageSize.Letter
                pagina.Orientation = PageOrientation.Portrait

                Dim pgfx As XGraphics = XGraphics.FromPdfPage(pagina)               ' Crea un Objeto XGraphics para la creacion de los datos
                Dim tf As XTextFormatter                                            ' Objeto para formatear texto

                Dim Archivo As String = AppPath() & "\Data\" & RutEmpresa & "\DTE2PDF\" & _Nombre_Archivo_PDF & _Documento_Id & ".pdf"

                If Crear_PDF_En_Directorio Then
                    Archivo = Directorio & "\" & _Nombre_Archivo_PDF & _Documento_Id & ".pdf"
                End If

                Dim Fte_Encabezado_Negrita_16 As XFont = New XFont("Arial", 16, XFontStyle.Bold)   ' Crea la fuente
                Dim Fte_Encabezado_Negrita_14 As XFont = New XFont("Arial", 14, XFontStyle.Bold)   ' Crea la fuente
                Dim Fte_Encabezado_Negrita_12 As XFont = New XFont("Arial", 12, XFontStyle.Bold)   ' Crea la fuente
                Dim Fte_Encabezado_Negrita_10 As XFont = New XFont("Arial", 10, XFontStyle.Bold)   ' Crea la fuente
                Dim Fte_Encabezado_Normal_10 As XFont = New XFont("Arial", 10, XFontStyle.Regular)   ' Crea la fuente

                Dim _Tipo_Documento As String = "FACTURA ELECTRÓNICA"

                ' EMISOR

                Dim Xpos = 10 ' Columna
                Dim Ypos = 30 ' Fila
                Dim Contador As Integer = 1
                Dim Con As Integer = 1
                Dim Dig As Integer = 50
                Dim Cm As Integer = 1

                'Dim filter As String = String.Format("Id = " & Id)
                'Dim rows() As DataRow = dt.Select(filter)

                Dim Tbl_IdDoc = _Dset_DTE.Tables("IdDoc") '.Select("Encabezado_Id = 0")

                Dim _Id_Doc As Integer = Tbl_IdDoc.Rows(_Encabezado_Id).Item("TipoDTE")
                Dim _Nro_Documento As String = Tbl_IdDoc.Rows(_Encabezado_Id).Item("Folio")

                Dim Tbl_Emisor = _Dset_DTE.Tables("Emisor")

                With Tbl_Emisor

                    Dim _Razon_Emisor As String = Trim(.Rows(_Encabezado_Id).Item("RznSoc")) '"Razon Social Emisor de documento"
                    Dim _Rt() As String = Split(Trim(.Rows(_Encabezado_Id).Item("RUTEmisor")), "-")
                    Dim _Rut_Emisor As String = FormatNumber(De_Txt_a_Num_01(_Rt(0), 0), 0) & "-" & _Rt(1)

                    Dim _Giro_Emisor As String = Valor_Columna(.Rows(_Encabezado_Id), 0, "GiroEmis") 'Trim(.Rows(0).Item("GiroEmis"))
                    Dim _direccion_Emisor As String = Valor_Columna(.Rows(_Encabezado_Id), 0, "DirOrigen") 'Trim(.Rows(0).Item("DirOrigen"))
                    Dim _Ciudad_Emisor As String = Valor_Columna(.Rows(_Encabezado_Id), 0, "CiudadOrigen") 'Trim(.Rows(0).Item("CiudadOrigen"))
                    Dim _Comuna_Emisor As String = Valor_Columna(.Rows(_Encabezado_Id), 0, "CmnaOrigen") 'Trim(.Rows(0).Item("CmnaOrigen"))

                    If _Ciudad_Emisor.Trim = _Comuna_Emisor.Trim Then
                        _Comuna_Emisor = String.Empty
                    End If

                    Dim _Telefono_Emisor As String = "" '.Rows(0).Item("RUTEmisor")

                    _Tipo_Documento = Tipo_Documento(_Id_Doc)

                    Ypos = 40
                    pgfx.DrawString("R.U.T.:" & _Rut_Emisor, Fte_Encabezado_Negrita_16, XBrushes.Red, 410, Ypos)
                    Ypos += 10

                    '' UTIL PARA ALINEAR IMPRESION
                    tf = New XTextFormatter(pgfx)
                    tf.Alignment = XParagraphAlignment.Center
                    ''

                    tf.DrawString(_Tipo_Documento, Fte_Encabezado_Negrita_12, XBrushes.Red, New XRect(375, Ypos, 220, 0))
                    Ypos += 15
                    tf.DrawString("ELECTRÓNICA", Fte_Encabezado_Negrita_12, XBrushes.Red, New XRect(375, Ypos, 220, 0))
                    Ypos += 20
                    tf.DrawString("N° " & _Nro_Documento, Fte_Encabezado_Negrita_16, XBrushes.Red, New XRect(375, Ypos, 220, 0))
                    'pgfx.DrawString("N° " & _Nro_Documento, Fte_Encabezado_Negrita_16, XBrushes.Red, 430, Ypos)

                    Ypos = 30

                    If _Razon_Emisor.Length <= 40 Then
                        pgfx.DrawString(UCase(_Razon_Emisor), Fte_Encabezado_Negrita_14, XBrushes.Black, 20, Ypos)
                    ElseIf _Razon_Emisor.Length > 40 And _Razon_Emisor.Length <= 45 Then
                        pgfx.DrawString(UCase(_Razon_Emisor), Fte_Encabezado_Negrita_12, XBrushes.Black, 20, Ypos)
                    Else
                        pgfx.DrawString(UCase(_Razon_Emisor), Fte_Encabezado_Negrita_10, XBrushes.Black, 20, Ypos)
                    End If

                    Ypos += 15
                    pgfx.DrawString(UCase(_direccion_Emisor), Fte_Encabezado_Negrita_10, XBrushes.Black, 20, Ypos)
                    Ypos += 15
                    pgfx.DrawString(UCase(_Giro_Emisor), FteNegrita_7, XBrushes.Black, 20, Ypos)
                    Ypos += 15
                    pgfx.DrawString(UCase(_Ciudad_Emisor), Fte_Encabezado_Negrita_10, XBrushes.Black, 20, Ypos)
                    Ypos += 15
                    pgfx.DrawString(UCase(_Comuna_Emisor), Fte_Encabezado_Negrita_10, XBrushes.Black, 20, Ypos)
                    Ypos += 15
                    pgfx.DrawString(_Telefono_Emisor, Fte_Encabezado_Negrita_10, XBrushes.Black, 20, Ypos)
                    Ypos += 15

                End With

                Dim DD = Tbl_IdDoc

                Dim _Fecha_Emision As Date = Tbl_IdDoc.Rows(_Encabezado_Id).Item("FchEmis")
                Dim _Fecha_Vencimiento As Date
                Dim _TieneFechaVencimiento As Boolean

                Try
                    _Fecha_Vencimiento = Tbl_IdDoc.Rows(_Encabezado_Id).Item("FchVenc")
                    _TieneFechaVencimiento = True
                Catch ex As Exception
                    If _Abrir_PDF AndAlso MessageBoxEx.Show(_Formulario, "Documento sin fecha de vencimiento" & vbCrLf &
                                    "¿Desea ingresar la fecha de vencimiento?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Try
                            _Fecha_Vencimiento = _Fecha_Emision
                            If InputBox_Bk(_Formulario, "Ingrese fecha de vencimiento del documento en formato dd/mm/aaaa o dd-mm-aaaa",
                                           "Fecha de vencimiento",
                                           _Fecha_Vencimiento, False,,,, _Tipo_Imagen.Texto,, _Tipo_Caracter.Cualquier_caracter) Then
                                _TieneFechaVencimiento = True
                            End If
                        Catch exx As Exception
                            MessageBoxEx.Show(_Formulario, exx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            _Fecha_Vencimiento = Nothing
                        End Try
                    Else
                        _Fecha_Vencimiento = Nothing
                    End If

                End Try

                Dim Tbl_Receptor = _Dset_DTE.Tables("Receptor")

                With Tbl_Receptor

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''''   ENCABEZADO DOCUMENTO
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim _Razon_Receptor As String = Trim(.Rows(_Encabezado_Id).Item("RznSocRecep")) '"Razon Social Receptor de documento"

                    Dim _Rt() As String = Split(Trim(.Rows(_Encabezado_Id).Item("RUTRecep")), "-")
                    Dim _Rut_Receptor As String = FormatNumber(De_Txt_a_Num_01(_Rt(0), 0), 0) & "-" & _Rt(1)

                    Dim _Giro_Receptor As String

                    Try
                        _Giro_Receptor = Trim(.Rows(_Encabezado_Id).Item("GiroRecep"))
                    Catch ex As Exception
                        _Giro_Receptor = String.Empty
                    End Try

                    Dim _direccion_Receptor As String = Trim(.Rows(_Encabezado_Id).Item("DirRecep"))
                    Dim _Ciudad_Receptor As String = Valor_Columna(.Rows(_Encabezado_Id), 0, "CiudadRecep") 'Trim(.Rows(0).Item("CiudadRecep"))
                    Dim _Comuna_Receptor As String = Valor_Columna(.Rows(_Encabezado_Id), 0, "CmnaRecep") 'Trim(.Rows(0).Item("CmnaRecep"))
                    Dim _Telefono_Receptor As String = Valor_Columna(.Rows(_Encabezado_Id), 0, "Contacto") 'Trim(.Rows(0).Item("RznSocRecep"))
                    '
                    Ypos = 140
                    pgfx.DrawString("RUT", FteNegrita_8, XBrushes.Black, 35, Ypos)
                    pgfx.DrawString(": " & _Rut_Receptor, FteNormal_8, XBrushes.Black, 100, Ypos)
                    pgfx.DrawString("FECHA EMISION", FteNegrita_8, XBrushes.Black, 380, Ypos)
                    pgfx.DrawString(": " & FormatDateTime(_Fecha_Emision, DateFormat.LongDate), FteNormal_8, XBrushes.Black, 450, Ypos)
                    Ypos += 20

                    pgfx.DrawString("RAZON SOCIAL", FteNegrita_8, XBrushes.Black, 35, Ypos)
                    pgfx.DrawString(": " & UCase(_Razon_Receptor), FteNormal_8, XBrushes.Black, 100, Ypos)
                    pgfx.DrawString("COMUNA", FteNegrita_8, XBrushes.Black, 380, Ypos)
                    pgfx.DrawString(": " & UCase(_Comuna_Receptor), FteNormal_8, XBrushes.Black, 450, Ypos)
                    Ypos += 20

                    pgfx.DrawString("DIRECCION", FteNegrita_8, XBrushes.Black, 35, Ypos)
                    pgfx.DrawString(": " & UCase(_direccion_Receptor), FteNormal_8, XBrushes.Black, 100, Ypos)

                    If _TieneFechaVencimiento Then
                        pgfx.DrawString("FECHA VENC.", FteNegrita_8, XBrushes.Black, 380, Ypos)
                        pgfx.DrawString(": " & UCase(_Fecha_Vencimiento), FteNormal_8, XBrushes.Black, 450, Ypos)
                    End If

                    Ypos += 20

                    pgfx.DrawString("CIUDAD", FteNegrita_8, XBrushes.Black, 35, Ypos)
                    pgfx.DrawString(": " & UCase(_Ciudad_Receptor), FteNormal_8, XBrushes.Black, 100, Ypos)
                    pgfx.DrawString("TELEFONO", FteNegrita_8, XBrushes.Black, 380, Ypos)
                    pgfx.DrawString(": " & UCase(_Telefono_Receptor), FteNormal_8, XBrushes.Black, 450, Ypos)
                    Ypos += 20

                End With

                pgfx.DrawString("|", FteNormal_3, XBrushes.Green, 1, 20)
                pgfx.DrawString(Cm, FteNormal_3, XBrushes.Green, 1, 25)

                'Escribimos el titulo
                Dim rect As New XRect(15, 15, 585, 20)

                ' XStringFormat.Center)

                'escribimos el texto
                tf = New XTextFormatter(pgfx)
                tf.Alignment = XParagraphAlignment.Justify
                rect = New XRect(15, 45, 585, 60)
                ' tf.DrawString(txTexto.Text, FteNormal_10, XBrushes.Black, rect)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''   ENCABEZADO DE DETALLE
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Ypos = 245

                pgfx.DrawString("CANTIDAD", FteNegrita_7, XBrushes.Black, 20, Ypos)
                pgfx.DrawString("CODIGO", FteNegrita_7, XBrushes.Black, 80, Ypos)
                pgfx.DrawString("DESCRIPCION", FteNegrita_7, XBrushes.Black, 220, Ypos)
                pgfx.DrawString("PRECIO", FteNegrita_7, XBrushes.Black, 395, Ypos)
                pgfx.DrawString("%D.", FteNegrita_7, XBrushes.Black, 450, Ypos)
                pgfx.DrawString("DSCTO. $", FteNegrita_7, XBrushes.Black, 490, Ypos)
                pgfx.DrawString("TOTAL", FteNegrita_7, XBrushes.Black, 550, Ypos)

                Ypos = 265

                Dim _Valor As String
                Dim _Caracter As String
                Dim _Largo As Integer = 18
                Dim numero As Integer = 10 'Random.Next(1, 4)

                'Inicializar la clase Random  
                Dim Random As New Random()

                Dim Tbl_Detalle = _Dset_DTE.Tables("Detalle")
                Dim Tbl_CdgItem = _Dset_DTE.Tables("CdgItem")

                Contador = 0

                Dim _Registros = 0

                For Each Fila As DataRow In Tbl_Detalle.Rows

                    Dim Id = Fila.Item("Documento_Id")

                    If Id = _Documento_Id Then
                        _Registros += 1
                    End If

                Next


                For Each Fila As DataRow In Tbl_Detalle.Rows

                    Dim Id = Fila.Item("Documento_Id")

                    If Id = _Documento_Id Then

                        Dim _Codigo As String = String.Empty
                        Dim _Detalle_Id As String

                        Try
                            _Detalle_Id = Fila.Item("Detalle_Id")
                        Catch ex As Exception
                            _Detalle_Id = 0
                        End Try

                        If Not (Tbl_CdgItem Is Nothing) Then

                            Try
                                _Codigo = Tbl_CdgItem.Rows(_Detalle_Id).Item("VlrCodigo").ToString.Trim
                            Catch ex As Exception
                                _Codigo = String.Empty
                            End Try

                        End If

                        Dim _Cantidad As Double

                        Try
                            _Cantidad = De_Txt_a_Num_01(Fila.Item("QtyItem"))
                        Catch ex As Exception
                            _Cantidad = 1
                        End Try

                        Dim _DscItem As String
                        Dim _NmbItem As String

                        Try
                            _DscItem = Trim(Fila.Item("DscItem"))
                        Catch ex As Exception
                            _DscItem = String.Empty
                        End Try

                        Try
                            _NmbItem = Trim(Fila.Item("NmbItem"))
                        Catch ex As Exception
                            _NmbItem = String.Empty
                        End Try

                        Dim _Descripcion As String = _NmbItem

                        Dim _Descripcion_01 = String.Empty
                        Dim _Descripcion_02 = String.Empty

                        If _Descripcion.Length > 63 Then

                            _Descripcion_01 = Mid(_Descripcion, 1, 63)
                            _Descripcion_02 = Mid(_Descripcion, 64, _Descripcion.Length)

                        End If

                        Dim _Precio As Double = Valor_Columna(Fila, 0, "PrcItem", True)
                        Dim _DecuentoPct As Double = Valor_Columna(Fila, 0, "DescuentoPct", True)
                        Dim _DescuentoMonto As Double = Valor_Columna(Fila, 0, "DescuentoMonto", True)
                        Dim _Monto As Double = Valor_Columna(Fila, 0, "MontoItem", True)

                        Dim _Decimal As Integer


                        If Int(_DecuentoPct) Then : _Decimal = 2 : Else : _Decimal = 0 : End If
                        Dim _DecuentoPct_ = Rellenar(FormatNumber(_DecuentoPct, _Decimal), 4, " ", False)

                        If Int(_DescuentoMonto) Then : _Decimal = 2 : Else : _Decimal = 0 : End If
                        Dim _DescuentoMonto_ = Rellenar(FormatNumber(_DescuentoMonto, _Decimal), 13, " ", False)

                        If Int(_Cantidad) Then : _Decimal = 2 : Else : _Decimal = 0 : End If
                        Dim _Cantidad_ = Rellenar(FormatNumber(_Cantidad, _Decimal), 9, " ", False)

                        If Int(_Precio) Then : _Decimal = 2 : Else : _Decimal = 0 : End If
                        Dim _Precio_ = Rellenar(FormatNumber(_Precio, _Decimal), 13, " ", False)


                        Dim _Monto_ = Rellenar(FormatNumber(_Monto, 0), 13, " ", False)

                        pgfx.DrawString(_Cantidad_, FteNormal_C_7, XBrushes.Black, 15, Ypos)
                        pgfx.DrawString(_Codigo, FteNormal_C_7, XBrushes.Black, 70, Ypos)

                        If Len(_Descripcion) > 63 Then
                            pgfx.DrawString(_Descripcion_01, FteNormal_C_6, XBrushes.Black, 140, Ypos)
                        Else
                            pgfx.DrawString(_Descripcion, FteNormal_C_7, XBrushes.Black, 140, Ypos)
                        End If

                        pgfx.DrawString(_Precio_, FteNormal_C_7, XBrushes.Black, 380, Ypos)
                        pgfx.DrawString(_DecuentoPct_, FteNormal_C_7, XBrushes.Black, 445, Ypos) ' porcentaje descuento
                        pgfx.DrawString(_DescuentoMonto_, FteNormal_C_7, XBrushes.Black, 470, Ypos) ' valor descuento
                        pgfx.DrawString(_Monto_, FteNormal_C_7, XBrushes.Black, 530, Ypos)

                        If _Registros <= 15 Then

                            If Not String.IsNullOrEmpty(_Descripcion_02) Then
                                Ypos += 10
                                pgfx.DrawString(_Descripcion_02, FteNormal_C_6, XBrushes.Black, 140, Ypos)
                            End If

                            If Not String.IsNullOrEmpty(_DscItem) Then
                                Ypos += 10
                                pgfx.DrawString(_DscItem, FteNormal_C_6, XBrushes.Black, 145, Ypos)
                            End If

                        End If

                        Ypos += 10
                        Contador += 1

                    End If

                Next

                Dim Tbl_DscRcgGlobal = _Dset_DTE.Tables("DscRcgGlobal")

                If Not IsNothing(Tbl_DscRcgGlobal) Then

                    For Each _Fila As DataRow In Tbl_DscRcgGlobal.Rows

                        Dim ID = _Fila.Item("Documento_Id")

                        If ID = _Documento_Id Then

                            Dim _TpoMov As String = _Fila.Item("TpoMov")
                            Dim _GlosaDR As String
                            Dim _TpoValor As String = _Fila.Item("TpoValor")
                            Dim _ValorDR As Double = Valor_Columna(_Fila, 0, "ValorDR", True)

                            Try
                                _GlosaDR = _Fila.Item("GlosaDR")
                            Catch ex As Exception
                                _GlosaDR = "DESCUENTO"
                            End Try

                            If _TpoMov = "D" And _TpoValor = "$" Then _ValorDR = _ValorDR * -1

                            Dim _DecuentoPct = Rellenar(FormatNumber(_ValorDR, 2), 4, " ", False)
                            Dim _DescuentoMonto = Rellenar(FormatNumber(_ValorDR, 0), 13, " ", False)

                            pgfx.DrawString(_GlosaDR, FteNormal_C_7, XBrushes.Black, 140, Ypos)

                            If _TpoValor = "%" Then
                                pgfx.DrawString(_DecuentoPct, FteNormal_C_7, XBrushes.Black, 446, Ypos) ' porcentaje descuento
                            Else
                                pgfx.DrawString(_DescuentoMonto, FteNormal_C_7, XBrushes.Black, 530, Ypos) ' valor descuento
                            End If
                            Ypos += 8

                        End If

                    Next

                End If

                Dim elipse As XSize
                elipse.Height = 10
                elipse.Width = 10

                rect = New XRect(15, 230, 580, 380)
                pgfx.DrawRoundedRectangle(XPens.Black, rect, elipse)

                rect = New XRect(15, 250, 580, 320)
                pgfx.DrawRectangle(XPens.Black, rect)


                rect = New XRect(15, 250, 580, 320)
                pgfx.DrawRectangle(XPens.Black, rect)

                rect = New XRect(65, 230, 70, 340)
                pgfx.DrawRectangle(XPens.Black, rect)

                rect = New XRect(135, 230, 240, 340)
                pgfx.DrawRectangle(XPens.Black, rect)

                rect = New XRect(375, 230, 63, 340)
                pgfx.DrawRectangle(XPens.Black, rect)

                rect = New XRect(438, 230, 30, 340)
                pgfx.DrawRectangle(XPens.Black, rect)

                rect = New XRect(468, 230, 65, 340)
                pgfx.DrawRectangle(XPens.Black, rect)

                Dim pen As XPen = New XPen(XColor.FromArgb(255, 0, 0), 1)
                pgfx.DrawLine(XPens.Red, New XPoint(15, Ypos), New XPoint(595, Ypos)) ' New XPoint(pagina.Width.Point, pagina.Height.Point))
                pgfx.DrawLine(XPens.Red, New XPoint(15, Ypos + 2), New XPoint(595, Ypos + 2)) ' New XPoint(pagina.Width.Point, pagina.Height.Point))

                Ypos += 10

                'TIPO DE DOCUMENTO FOLIO FECHA MOTIVO
                'Orden de Compra 58 03-10-2014

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''' REFERENCIA 
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim Tbl_Referencia = _Dset_DTE.Tables("Referencia")


                If Not (Tbl_Referencia Is Nothing) Then

                    pgfx.DrawString("Tipo Documento", FteNegrita_6, XBrushes.Black, 140, Ypos)
                    pgfx.DrawString("Folio", FteNegrita_6, XBrushes.Black, 210, Ypos)
                    pgfx.DrawString("Fecha", FteNegrita_6, XBrushes.Black, 255, Ypos)
                    pgfx.DrawString("Motivo", FteNegrita_6, XBrushes.Black, 290, Ypos)
                    Ypos += 10

                    For Each Fila As DataRow In Tbl_Referencia.Rows

                        Dim ID = Fila.Item("Documento_Id")

                        If ID = _Documento_Id Then

                            Dim _Id_Doc_Ref As String = Fila.Item("TpoDocRef")
                            Dim _Doc_Ref As String = Tipo_Documento(_Id_Doc_Ref)

                            Dim _Nro_Doc_Ref As String = Fila.Item("FolioRef")
                            Dim _FchRef As Date = Fila.Item("FchRef")

                            Dim _CodRef As String
                            Dim _Motivo As String

                            Try
                                _CodRef = Fila.Item("CodRef")
                                _Motivo = Tipo_Referencia(_CodRef)
                            Catch ex As Exception
                                _CodRef = String.Empty
                                _Motivo = String.Empty
                            End Try

                            pgfx.DrawString(_Doc_Ref, FteNormal_5, XBrushes.Black, 140, Ypos)
                            pgfx.DrawString(_Nro_Doc_Ref, FteNormal_5, XBrushes.Black, 210, Ypos)
                            pgfx.DrawString(_FchRef, FteNormal_5, XBrushes.Black, 255, Ypos)
                            pgfx.DrawString(_Motivo, FteNormal_5, XBrushes.Black, 290, Ypos)
                            Ypos += 8

                        End If

                    Next

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''   PIE 
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim Tbl_ImptoReten = _Dset_DTE.Tables("ImptoReten")

                Ypos = 585


                Dim _Impuestos_Ila As Double

                If Not (Tbl_ImptoReten Is Nothing) Then
                    '_Impuestos_Ila = Tbl_ImptoReten.Compute("Sum(MontoImp)", "MontoImp > 0") ')Dif_GDI_Ud1 > 0")

                    For Each _Fila_Ila As DataRow In Tbl_ImptoReten.Rows
                        _Impuestos_Ila += Valor_Columna(_Fila_Ila, 0, "MontoImp", True)
                    Next
                End If


                Dim Tbl_Totales = _Dset_DTE.Tables("Totales")

                If Not (Tbl_Totales Is Nothing) Then

                    Dim _TasaIVA As Double
                    Dim _IVA As Double

                    Dim _Descuento As Double
                    Dim _Exento As Double
                    Dim _MntNeto As Double
                    Dim _MntTotal As Double

                    Try
                        _MntNeto = De_Txt_a_Num_01(Tbl_Totales.Rows(_Encabezado_Id).Item("MntNeto"))
                    Catch ex As Exception
                        _MntNeto = 0
                    End Try

                    _MntTotal = De_Txt_a_Num_01(Tbl_Totales.Rows(_Encabezado_Id).Item("MntTotal"))

                    Try
                        _TasaIVA = De_Txt_a_Num_01(Tbl_Totales.Rows(_Encabezado_Id).Item("TasaIVA"))
                    Catch ex As Exception
                        _TasaIVA = 0
                    End Try

                    Try
                        _IVA = De_Txt_a_Num_01(Tbl_Totales.Rows(_Encabezado_Id).Item("IVA"))
                    Catch ex As Exception
                        _IVA = 0
                    End Try

                    Try
                        _Exento = De_Txt_a_Num_01(Tbl_Totales.Rows(_Encabezado_Id).Item("MntExe"))
                    Catch ex As Exception
                        _Exento = 0
                    End Try

                    _MntTotal = De_Txt_a_Num_01(Tbl_Totales.Rows(_Encabezado_Id).Item("MntTotal"))

                    Dim _Total_Palabras As String = Trim(UCase(Letras(_MntTotal))) & " ---------"
                    pgfx.DrawString("SON :" & _Total_Palabras, FteNegrita_8, XBrushes.Black, 25, Ypos)
                    Ypos += 20

                    Dim _Tota_Descuento As String
                    _Tota_Descuento = FormatNumber(_Descuento, 0)
                    _Tota_Descuento = ": $ " & Rellenar(_Tota_Descuento, 11, " ", False)

                    Dim _Tota_Exento As String
                    _Tota_Exento = FormatNumber(_Exento, 0)
                    _Tota_Exento = ": $ " & Rellenar(_Tota_Exento, 11, " ", False)

                    Dim _Total_Neto As String
                    _Total_Neto = FormatNumber(_MntNeto, 0)
                    _Total_Neto = ": $ " & Rellenar(_Total_Neto, 11, " ", False)

                    Dim _Total_Ila As String
                    _Total_Ila = FormatNumber(_IVA, 0)
                    _Total_Ila = ": $ " & Rellenar(_Impuestos_Ila, 11, " ", False)

                    Dim _Total_Iva As String
                    _Total_Iva = FormatNumber(_IVA, 0)
                    _Total_Iva = ": $ " & Rellenar(_Total_Iva, 11, " ", False)

                    Dim _Total_Bruto As String
                    _Total_Bruto = FormatNumber(_MntTotal, 0)
                    _Total_Bruto = ": $ " & Rellenar(_Total_Bruto, 11, " ", False)

                    Ypos = 635
                    'pgfx.DrawString("DESCUENTO", FteNegrita_8, XBrushes.Black, 425, Ypos)
                    'pgfx.DrawString(_Tota_Descuento, FteNormal_C_12, XBrushes.Black, 475, Ypos)
                    'Ypos += 20
                    pgfx.DrawString("EXENTO", FteNegrita_8, XBrushes.Black, 425, Ypos)
                    pgfx.DrawString(_Tota_Exento, FteNormal_C_12, XBrushes.Black, 475, Ypos)
                    Ypos += 20
                    pgfx.DrawString("NETO", FteNegrita_8, XBrushes.Black, 425, Ypos)
                    pgfx.DrawString(_Total_Neto, FteNormal_C_12, XBrushes.Black, 475, Ypos)
                    Ypos += 20
                    pgfx.DrawString("IMPUESTOS", FteNegrita_8, XBrushes.Black, 425, Ypos)
                    pgfx.DrawString(_Total_Ila, FteNormal_C_12, XBrushes.Black, 475, Ypos)
                    Ypos += 20
                    pgfx.DrawString("IVA (" & _TasaIVA & ")", FteNegrita_8, XBrushes.Black, 425, Ypos)
                    pgfx.DrawString(_Total_Iva, FteNormal_C_12, XBrushes.Black, 475, Ypos)
                    Ypos += 20
                    pgfx.DrawString("TOTAL", FteNegrita_8, XBrushes.Black, 425, Ypos)
                    pgfx.DrawString(_Total_Bruto, FteNormal_C_12, XBrushes.Black, 475, Ypos)
                    Ypos += 20

                End If


                'Insertamos un cuadro
                rect = New XRect(50, 200, 100, 50)
                pen = New XPen(XColor.FromArgb(255, 0, 0))
                ' pgfx.DrawRoundedRectangle(XPens.Blue, rect, elipse)

                rect = New XRect(375, 20, 218, 90)
                pen = New XPen(XColor.FromArgb(255, 0, 0), 3)
                pgfx.DrawRectangle(pen, rect)


                rect = New XRect(15, 120, 580, 100)
                pgfx.DrawRoundedRectangle(XPens.Black, rect, elipse)


                ' Rectangulo de los totales
                rect = New XRect(415, 620, 178, 105)
                pgfx.DrawRoundedRectangle(XPens.Black, rect, elipse)





                '********************************************** TIMBRE ELECTRONICO **************************************************
                Dim bm As Bitmap = Nothing
                Dim CodBarras As XImage ' PictureBox

                Dim _TED = _Dset_DTE.Tables("TED")
                Dim _DD = _Dset_DTE.Tables("DD")
                Dim _CAF = _Dset_DTE.Tables("CAF")
                Dim _DA = _Dset_DTE.Tables("DA")
                Dim _RNG = _Dset_DTE.Tables("RNG")
                Dim _RSAPK = _Dset_DTE.Tables("RSAPK")
                Dim _FRMA = _Dset_DTE.Tables("FRMA")



                Dim _Timbre As String = "<DD><RE>" & _DD.Rows(_Documento_Id).Item("RE") & "</RE><TD>" & _DD.Rows(_Documento_Id).Item("TD") & "</TD><F>" & _DD.Rows(_Documento_Id).Item("F") &
                                        "</F><FE>" & _DD.Rows(_Documento_Id).Item("FE") & "</FE><RR>" & _DD.Rows(_Documento_Id).Item("RR") & "</RR><RSR>" & _DD.Rows(_Documento_Id).Item("RSR") & "</RSR>" &
                                        "<MNT>" & _DD.Rows(_Documento_Id).Item("MNT") & "</MNT><IT1>" & _DD.Rows(_Documento_Id).Item("IT1") & "</IT1>" &
                                        "<CAF version=" & Chr(34) & _CAF.Rows(_Documento_Id).Item("version") & Chr(34) & "><DA>" &
                                        "<RE>" & _DA.Rows(_Documento_Id).Item("RE") & "</RE><RS>" & _DA.Rows(_Documento_Id).Item("RS") & "</RS>" &
                                        "<TD>" & _DA.Rows(_Documento_Id).Item("TD") & "</TD><RNG><D>" & _RNG.Rows(_Documento_Id).Item("D") & "</D><H>" & _RNG.Rows(_Documento_Id).Item("H") & "</H>" &
                                        "</RNG><FA>" & _DA.Rows(_Documento_Id).Item("FA") & "</FA>" &
                                        "<RSAPK><M>" & _RSAPK.Rows(_Documento_Id).Item("M") & "</M><E>" & _RSAPK.Rows(_Documento_Id).Item("E") & "</E></RSAPK>" &
                                        "<IDK>" & _DA.Rows(_Documento_Id).Item("IDK") & "</IDK></DA>" &
                                        "<FRMA algoritmo=" & Chr(34) & _FRMA.Rows(_Documento_Id).Item("algoritmo") & Chr(34) &
                                        ">" & _FRMA.Rows(_Documento_Id).Item("FRMA_Text") & "</FRMA></CAF><TSTED>" & _DD.Rows(_Documento_Id).Item("TSTED") & "</TSTED></DD>"

                'Dim iType As BarCode.Code128SubTypes = _
                ' DirectCast([Enum].Parse(GetType(BarCode.Code128SubTypes), "CODE128"), BarCode.Code128SubTypes)
                bm = BarCode.PDF417(_Timbre, 1, 8)

                'Image as XImage = XImage.FromFile(jpegSamplePath)
                'Dim x As Double = ((250 - Image.PixelWidth * 72 / Image.HorizontalResolution) / 2)
                'GFX.DrawImage(Image, x, 0)

                If Not IsNothing(bm) Then
                    CodBarras = bm
                End If

                'rect = New XRect(15, 620, 250, 125)
                'pgfx.DrawRoundedRectangle(XPens.Black, rect, elipse)

                pgfx.DrawImage(CodBarras, 45, 630)
                pgfx.DrawString("Timbre Electrónico S.I.I.", FteNegrita_9, XBrushes.Black, 90, 750)
                'e.Graphics.DrawImage(CodBarras.Image, Xpos + 10, Ypos - 35, 220, 140)

                '*********************************************************************************************************************

                'Insertamos un cuadro con color interno
                'rect = New XRect(200,200,100,50)
                'pgfx.DrawRoundedRectangle(pen, Xbrushes.Aqua ,rect,elipse)

                'Insertamos la imagen en una hoja nueva
                'If File.Exists(txImagen.Text) Then
                'pagina = Documento.AddPage
                'pagina.Size = PageSize.Letter
                'pgfx = XGraphics.FromPdfPage(pagina)
                'Dim imagen As XImage = XImage.FromFile(txImagen.Text)
                'pgfx.DrawImage(imagen, 50, 150, 500, 375)
                'End If

                Try
                    'si el archivo esta abierto da error
                    'para que averiguen como saber si ela rchivo esta abierto y cerrarlo
                    ' antes de grabar uno nuevo
                    Documento.Save(Archivo)
                Catch ex As Exception
                End Try

                If _Poner_Marca_de_agua Then

                    Dim rot(3) As Double
                    rot(0) = 1.5
                    rot(1) = 2
                    rot(2) = 100
                    rot(3) = 8
                    PoneMarcaAgua(Archivo, _Marca_Agua, rot)

                End If

                If _Abrir_PDF Then
                    Process.Start(Archivo)
                End If

            Next

        Catch ex As Exception
            MessageBoxEx.Show(_Formulario, ex.Message & vbCrLf &
                              "Problemas al leer el archivo XML de origen, puede que el archivos no tenga la estructura adecuada", "Problema en DTE", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function Valor_Columna(_Tabla As DataRow,
                                   Fila As Integer,
                                   _Campo As String,
                                   Optional _EsNro As Boolean = False)

        Dim _Cadena As String
        Dim _Numero As Double

        Try

            If _EsNro Then
                _Numero = De_Txt_a_Num_01(_Tabla.Item(_Campo), 5)
                Return _Numero
            Else
                _Cadena = Trim(_Tabla.Item(_Campo))
                Return _Cadena
            End If

        Catch ex As Exception

            If _EsNro Then
                Return 0
            Else
                Return String.Empty
            End If

        End Try


    End Function

    Private Function Tipo_Documento(_Id_Doc As String)
        Select Case _Id_Doc
            Case 33
                Return "FACTURA"
            Case 34
                Return "FACTURA EXENTA"
            Case 52
                Return "GUIA DE DESPACHO"
            Case 46
                Return "FACTURA DE COMPRA"
            Case 56
                Return "NOTA DE DEBITO"
            Case 61
                Return "NOTA DE CREDITO"
            Case 801
                Return "ORDEN DE COMPRA"
            Case Else
                Return _Id_Doc

        End Select

    End Function

    Private Function Tipo_Referencia(_Cod_Ref As Integer)
        Select Case _Cod_Ref
            Case 1
                Return "Anula Documento de Referencia"
            Case 2
                Return "Corrige Texto Documento de Referencia"
            Case 3
                Return "Corrige montos"
            Case Else
                Return String.Empty
        End Select
    End Function

    Public Sub PoneMarcaAgua(FileName As String, Texto As String, rotacion() As Double)

        Dim watermark As String = Texto
        Const emSize As Integer = 75

        ' Crea la fuente
        Dim font As New XFont("Times", emSize, XFontStyle.Italic)

        ' Abre el pdf existente
        Dim document As PdfDocument = PdfReader.Open(FileName)

        ' fija la  version a PDF 1.4 (Acrobat 5) ya que usamos transparencia
        If document.Version < 14 Then
            document.Version = 14
        End If
        For idx As Integer = 0 To document.Pages.Count - 1
            Dim page As PdfPage = document.Pages(idx)

            ' Crea el XGrafics para el dibujo
            Dim gfx As XGraphics = XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Prepend)

            Dim size As XSize = gfx.MeasureString(watermark, font)

            gfx.TranslateTransform(gfx.PageSize.Width / rotacion(0), gfx.PageSize.Height / rotacion(1))
            gfx.RotateTransform(-Math.Atan(gfx.PageSize.Height / gfx.PageSize.Width) * 180 / Math.PI)
            gfx.TranslateTransform(-gfx.PageSize.Width / rotacion(2), -gfx.PageSize.Height / rotacion(3))


            Dim path As New XGraphicsPath()
            path.AddString(watermark, font.FontFamily, XFontStyle.Italic, 75, New XPoint((page.Width.Centimeter - size.Width) / 2, (page.Height.Centimeter - size.Height) / 2), XStringFormat.Default)

            Dim pen As New XPen(XColor.FromArgb(128, 255, 150, 150), 2)

            gfx.DrawPath(pen, path)
        Next
        document.Save(FileName)



    End Sub

End Class
