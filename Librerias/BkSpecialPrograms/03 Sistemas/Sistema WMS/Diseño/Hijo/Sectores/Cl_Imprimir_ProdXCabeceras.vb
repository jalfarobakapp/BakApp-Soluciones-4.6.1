Imports System.Drawing.Printing

Public Class Cl_Imprimir_ProdXCabeceras

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _PrtSettings As New PrinterSettings
    Dim _Tbl_Maedpce As DataTable
    Dim _Tbl_Estado_Cuenta As DataTable

    Dim _Item = 1
    Dim _Pagina = 1

    Dim _Row_Entidad As DataRow
    Dim _Row_Sucursal As DataRow

    Dim _Total_Documentos_Pago As Double
    Dim _Totales_Documentos_Abonados As Double
    Dim _Totales_Valor_Documentos As Double

    Private _ListaImprimir As List(Of ImpCabecera.DocumentoPrint)
    Private _FechaIngreso As Date

    Public Property Imprimir_Negrita As Boolean

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

    Public Sub New(_Ls_Cabeceras As List(Of Zw_WMS_Ubicaciones_Sectores), _FechaIngreso As Date)

        Me._FechaIngreso = _FechaIngreso

        _Total_Documentos_Pago = 0
        _Totales_Documentos_Abonados = 0
        _Totales_Valor_Documentos = 0

        _ListaImprimir = New List(Of ImpCabecera.DocumentoPrint)

        For Each _Cabecera In _Ls_Cabeceras

            Dim _Mensaje As LsValiciones.Mensajes = Fx_Llenar_Cabecera(_Cabecera)

            If _Mensaje.EsCorrecto Then
                Dim _Doc As ImpCabecera.DocumentoPrint = _Mensaje.Tag
                _ListaImprimir.Add(_Doc)
            End If

        Next

    End Sub

#End Region

    Public Function Fx_Imprimir_Archivo(_Formulario As Form, _Impresora As String)

        Try

            ' ejemplo simple para imprimir en .NET
            ' Usamos una clase del tipo PrintDocument

            Dim printDoc As New PrintDocument

            ' CON ESTA CONFIGURACION PODEMOS PROPORCIONAR LAS DIMENCIONES Y ESTADO DE LA PAGINA, MARGENES, LARGO Y HORIENTACION

            Dim pkCustomSize1 As New Printing.PaperSize(PaperKind.Letter, 850, 1100)

            Dim PageSetupDialog1 As New PageSetupDialog

            PageSetupDialog1.Document = printDoc
            PageSetupDialog1.PageSettings.Landscape = False

            PageSetupDialog1.PageSettings.PaperSize = pkCustomSize1
            PageSetupDialog1.PageSettings.Margins.Left = 2
            PageSetupDialog1.PageSettings.Margins.Right = 2

            PageSetupDialog1.ShowDialog()

            'Dim PageSetupDialog1 As New PageSetupDialog

            'PageSetupDialog1.Document = printDoc
            'PageSetupDialog1.PageSettings.Landscape = False
            'PageSetupDialog1.PageSettings.PaperSize = pkCustomSize1

            ' asignamos el método de evento para cada página a imprimir

            AddHandler printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Listado

            ' indicamos que queremos imprimir

            printDoc.DocumentName = "Productos X Proveedor"

            Dim _Copias As Integer

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

                    _Copias = .PrinterSettings.Copies

                End With

            End If

            printDoc.PrinterSettings.PrinterName = _Impresora

            For i = 1 To _Copias

                _Pagina = 1

                'For Each _Fila As DataRow In _Tbl_Maedpce.Rows
                '    _Fila.Item("Impreso") = Not _Fila.Item("Usar")
                '    _Fila.Item("Contador") = 1
                'Next

                _Total_Documentos_Pago = 0
                _Totales_Documentos_Abonados = 0
                _Totales_Valor_Documentos = 0

                printDoc.Print()

            Next

            Return True

        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub Sb_Print_PrintPage_Listado(sender As Object, e As PrintPageEventArgs)

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

            Dim _ZFE = 9
            Dim _ZFD = 9

            'If Not IO.Directory.Exists(AppPath() & "\Data\" & RutEmpresa & "\Imagenes") Then
            '    System.IO.Directory.CreateDirectory(AppPath() & "\Data\" & RutEmpresa & "\Imagenes")
            'End If

            'Dim _Imagen As New PictureBox
            'Dim _RutaImagen = AppPath() & "\Data\" & RutEmpresa & "\Imagenes\LogoInfListaPrecio.jpg"

            'Try

            '    _Imagen.Image = New System.Drawing.Bitmap(_RutaImagen)
            '    Using _Imagen
            '        e.Graphics.DrawImage(_Imagen.Image, _xPos, _yPos, 100, 100)
            '    End Using
            'Catch ex As Exception
            'End Try

            Dim _Font As FontStyle

            If _Imprimir_Negrita Then
                _Font = FontStyle.Bold
            Else
                _Font = FontStyle.Regular
            End If

            Dim _Alto = e.PageSettings.PaperSize.Height

            Dim _Filas_X_Documento = Math.Round(_Alto / 17, 0) - 5

            Dim _Items As Integer = 0

            For Each documento As ImpCabecera.DocumentoPrint In _ListaImprimir
                _Items += documento.Detalle.Count
            Next

            '_Filas_X_Documento += 26

            Dim _Fecha = DateTime.Now
            Dim _Titulo As String
            Dim _Paginas = Math.Ceiling(_Items / _Filas_X_Documento)

            e.Graphics.DrawString("Fecha : " & DateTime.Now.ToString("dd/MM/yyyy"), Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular),
                                  Brushes.Black, _xPos + 650, _yPos)

            'e.Graphics.DrawString("Página: " & _Pagina & " de " & _Paginas, Fx_Fuente(_Enum_Fuentes.Courier_New, 7, _Font), Brushes.Black, _xPos + 650, _yPos + 15)
            e.Graphics.DrawString("Página: " & numero_(_Pagina, 6), Fx_Fuente(_Enum_Fuentes.Courier_New, 8, _Font), Brushes.Black, _xPos + 650, _yPos + 15)

            'e.Graphics.DrawString("Hora  : " & DateTime.Now.ToString("HH:mm"), Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular),
            '                      Brushes.Black, _xPos + 650, _yPos + 15)

            e.Graphics.DrawString(RazonEmpresa, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _xPos, _yPos)
            e.Graphics.DrawString("R.U.T.: " & RutEmpresaActiva, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _xPos, _yPos + 15)
            _yPos += 40

            _Titulo = "CABACERAS"

            Sb_Centrar_Titulo(e, _Titulo, _Enum_Fuentes.Courier_New, 10, FontStyle.Bold, 0, _yPos, 95, True)
            _yPos += 20

            _Titulo = "PRODUCTOS EN CABECERA EL " & _FechaIngreso.Date.ToShortDateString

            Sb_Centrar_Titulo(e, _Titulo, _Enum_Fuentes.Courier_New, 10, FontStyle.Regular, 0, _yPos, 95, False)
            _yPos += 20

            e.Graphics.DrawString(StrDup(100, "_"), _Font_C12, Brushes.Black, 0, _yPos)
            _yPos += 30

            Dim _Enc_Cabecera = 20
            Dim _Enc_NombreCabecera = 60
            'Dim _Enc_FEntrega = 140
            'Dim _Enc_Vendedor = 220
            'Dim _Enc_Sucursal = 260
            'Dim _Enc_Bodega = 290
            'Dim _Enc_Plaz = 320
            'Dim _Enc_Occ = 350


            Dim _Contador = 0

            'e.Graphics.DrawString("Cabecera", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Enc_Cabecera, _yPos)
            'e.Graphics.DrawString("Nombre Cabecera", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Enc_NombreCabecera, _yPos)
            'e.Graphics.DrawString("F.Entrega", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Enc_FEntrega, _yPos)
            'e.Graphics.DrawString("Ven", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Enc_Vendedor, _yPos)
            'e.Graphics.DrawString("Suc", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Enc_Sucursal, _yPos)
            'e.Graphics.DrawString("Bod", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Enc_Bodega, _yPos)
            'e.Graphics.DrawString("Plaz", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Enc_Plaz, _yPos)
            'e.Graphics.DrawString("Orden de compra", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Enc_Occ, _yPos)


            '_yPos += 15

            Dim _EncDet_Item = 30
            Dim _EncDet_Codigo = 80
            Dim _EncDet_Descripcion = 180
            'Dim _EncDet_CantSoli = 500
            'Dim _EncDet_CantDesp = 570
            'Dim _EncDet_CantPend = 640
            'Dim _EncDet_Um = 710
            ''Dim _EncDet_Occ = 730
            Dim _EncDet_MontoPdte = 730

            'e.Graphics.DrawString("Código", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _EncDet_Codigo, _yPos)
            'e.Graphics.DrawString("Descripción", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _EncDet_Descripcion, _yPos)
            'e.Graphics.DrawString("SOLICI.", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _EncDet_CantSoli, _yPos)
            'e.Graphics.DrawString("DESPACH.", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _EncDet_CantDesp, _yPos)
            'e.Graphics.DrawString("PENDIEN.", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _EncDet_CantPend, _yPos)
            'e.Graphics.DrawString("UM", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _EncDet_Um, _yPos)

            '_xPos += 10
            'e.Graphics.DrawString(StrDup(100, "_"), _Font_C12, Brushes.Black, 0, _yPos)

            '_yPos += 30

            Dim _Det_Item = _EncDet_Item
            Dim _Det_Codigo = _EncDet_Codigo
            Dim _Det_Detalle = _EncDet_Descripcion
            'Dim _Det_CantSoli = _EncDet_CantSoli
            'Dim _Det_CantDesp = _EncDet_CantDesp
            'Dim _Det_CantPend = _EncDet_CantPend
            'Dim _Det_Um = _EncDet_Um
            'Dim _Det_MontoPdte = _EncDet_MontoPdte

            '_Filas_X_Documento = 58

            For Each _Documento As ImpCabecera.DocumentoPrint In _ListaImprimir

                If Not _Documento.Impreso Then

                    'Dim _Vadp_Str As String = Rellenar2(FormatNumber(_Vadp, 0), 10, " ", Enum_Relleno.Izquierda)

                    If _Contador >= _Filas_X_Documento - 2 Then
                        _Pagina += 1
                        e.HasMorePages = True
                        Return
                    End If

                    With _Documento.Encabezado

                        'e.Graphics.DrawString("Empresa: " & .Empresa & " Sucursal:" & .Sucursal & " " & .Bodega, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _Enc_Cabecera, _yPos)
                        '_yPos += 15
                        e.Graphics.DrawString("Cabecera: " & .Codigo_Sector & " - " & .Nombre_Sector, Fx_Fuente(_Enum_Fuentes.Courier_New, 10, FontStyle.Bold), Brushes.Black, _Enc_Cabecera, _yPos)
                        _yPos += 15

                        'If String.IsNullOrEmpty(.Observaciones) Then
                        e.Graphics.DrawString(StrDup(10, "-"), Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, 20, _yPos)
                        'Else
                        '    e.Graphics.DrawString(StrDup(10, "-") & " Obs: " & .Observaciones, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, 20, _yPos)
                        'End If
                        _yPos += 15

                        'e.Graphics.DrawString(.Tido, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _Enc_Cabecera, _yPos)
                        'e.Graphics.DrawString(.Nudo, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _Enc_NombreCabecera, _yPos)
                        'e.Graphics.DrawString(.FechaEntrega.Date.ToShortDateString, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _Enc_FEntrega, _yPos)
                        'e.Graphics.DrawString(.Vendedor, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _Enc_Vendedor, _yPos)
                        'e.Graphics.DrawString(.Sucursal, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _Enc_Sucursal, _yPos)
                        'e.Graphics.DrawString("OCC: ", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _Enc_Occ, _yPos)
                        'e.Graphics.DrawString(.OrdenDeCompra, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _Enc_Occ + 30, _yPos)

                    End With

                    _Contador += 4

                    '_yPos += 15

                    'e.Graphics.DrawString("Detalle de productos...", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col1TD, _yPos)
                    '_yPos += 15

                    e.Graphics.DrawString("Item", Fx_Fuente(_Enum_Fuentes.Courier_New, 10, FontStyle.Bold), Brushes.Black, _EncDet_Item, _yPos)
                    e.Graphics.DrawString("Código", Fx_Fuente(_Enum_Fuentes.Courier_New, 10, FontStyle.Bold), Brushes.Black, _EncDet_Codigo, _yPos)
                    e.Graphics.DrawString("Descripción", Fx_Fuente(_Enum_Fuentes.Courier_New, 10, FontStyle.Bold), Brushes.Black, _EncDet_Descripcion, _yPos)

                    _yPos += 30

                    Dim _CtaItems = 0

                    For Each _Detalle As ImpCabecera.Cabecera_Detalle In _Documento.Detalle

                        With _Detalle

                            If Not .Impreso Then

                                e.Graphics.DrawString(numero_(.Item, 2), Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Det_Item, _yPos)
                                e.Graphics.DrawString(.Codigo, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Det_Codigo, _yPos)
                                e.Graphics.DrawString(.Descripcion, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Det_Detalle, _yPos)
                                'e.Graphics.DrawString(_CantSolicitado, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Det_CantSoli, _yPos)

                                _yPos += 15

                                .Impreso = True

                            End If

                            _CtaItems += 1
                            _Contador += 1

                            'If (_Contador + _Documento.Detalle.Count) > _Filas_X_Documento Then
                            '    _Pagina += 1
                            '    e.HasMorePages = True
                            '    Return
                            'End If

                            ' Verificar si se necesita una nueva página
                            If _Contador >= _Filas_X_Documento Then

                                If _CtaItems = _Documento.Detalle.Count Then
                                    _Documento.Impreso = True
                                    e.Graphics.DrawString(StrDup(120, "-"), Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, 20, _yPos)

                                    Dim quedanFilasPorImprimir As Boolean = False

                                    For Each documento As ImpCabecera.DocumentoPrint In _ListaImprimir
                                        For Each detalle As ImpCabecera.Cabecera_Detalle In documento.Detalle
                                            If Not detalle.Impreso Then
                                                quedanFilasPorImprimir = True
                                                Exit For
                                            End If
                                        Next
                                        If quedanFilasPorImprimir Then
                                            Exit For
                                        End If
                                    Next

                                    If Not quedanFilasPorImprimir Then
                                        ' No quedan filas por imprimir
                                        ' Puedes realizar alguna acción aquí si es necesario
                                        Exit For
                                    End If
                                Else
                                    e.Graphics.DrawString("*** El detalle continúa en la siguiente página...", Fx_Fuente(_Enum_Fuentes.Courier_New, 7, FontStyle.Italic), Brushes.Black, 20, _yPos)
                                End If

                                _Pagina += 1
                                e.HasMorePages = True
                                Return
                            End If

                        End With

                    Next

                    e.Graphics.DrawString(StrDup(110, "-"), Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, 20, _yPos)
                    _yPos += 15

                    _Contador += 1
                    _Documento.Impreso = True

                End If

            Next


            _xPos += 10
            e.Graphics.DrawString(StrDup(88, "_"), _Font_C12, Brushes.Black, 0, _yPos)

            _yPos += 30

            e.HasMorePages = False

        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub

    Sub Sb_Centrar_Titulo(_e As PrintPageEventArgs,
                          _Titulo As String,
                          _Fuente As _Enum_Fuentes,
                          _Tamano As Integer,
                          _FontStyle As System.Drawing.FontStyle,
                          _x As Integer,
                          _y As Integer,
                          _Largo As Integer,
                          _Subrayado As Boolean)

        Dim _Espacio, _EspDerecha, _EspIzquierda As Integer

        Dim _Ancho_Pg = _e.PageBounds.Width

        _Titulo = _Titulo.Trim
        _Espacio = _Titulo.ToString.Length * _Tamano
        _Espacio = _Ancho_Pg - _Espacio
        _Espacio = Math.Round(_Espacio / 2, 0)

        _e.Graphics.DrawString(_Titulo, Fx_Fuente(_Fuente, _Tamano, _FontStyle, _Subrayado), Brushes.Black, _x + _Espacio, _y)

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

    Function Fx_Llenar_Cabecera(_Cabecera As Zw_WMS_Ubicaciones_Sectores) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim _Doc As New ImpCabecera.DocumentoPrint

            'Dim _Id_Sector = _Cabecera.Item(0)
            'Dim _Id_Mapa = _Cabecera.Item(1)
            'Dim _Empresa = _Cabecera.Item(2)
            'Dim _Sucursal = _Cabecera.Item(3)
            'Dim _Bodega = _Cabecera.Item(4)
            'Dim _Codigo_Sector = _Cabecera.Item(5)

            'Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Sectores" & vbCrLf &
            '               "Where Id_Sector  = " & _Id_Sector & " --And Id_Mapa = 0 And Empresa = '' And Sucursal = '' And Bodega = ''"

            'Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

            'If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
            '    Throw New System.Exception(_Sql.Pro_Error)
            'End If

            'If IsNothing(_Row) Then
            '    Throw New System.Exception("No se encontro el documento en Zw_WMS_Ubicaciones_Sectores Id_Sector = " & _Id_Sector)
            'End If

            'Dim _Encabezado As New Zw_WMS_Ubicaciones_Sectores

            'With _Encabezado

            '    .Id_Sector = _Row.Item("Id_Sector")
            '    .Id_Mapa = _Row.Item("Id_Mapa")
            '    .Empresa = _Row.Item("Empresa")
            '    .Sucursal = _Row.Item("Sucursal")
            '    .Bodega = _Row.Item("Bodega")
            '    .Codigo_Sector = _Row.Item("Codigo_Sector")
            '    .Nombre_Sector = _Row.Item("Nombre_Sector")
            '    .Es_SubSector = _Row.Item("Es_SubSector")
            '    .EsCabecera = _Row.Item("EsCabecera")
            '    .SoloUnaUbicacion = _Row.Item("SoloUnaUbicacion")
            '    .OblConfimarUbic = _Row.Item("OblConfimarUbic")

            'End With

            _Doc.Encabezado = _Cabecera

            With _Doc.Encabezado

                Consulta_sql = "Select KOPR As Codigo,NOKOPR As Descripcion From MAEPR Where KOPR In " &
                               "(Select Codigo From " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal " &
                               "Where Id_Mapa = " & .Id_Mapa & " And Empresa = '" & .Empresa & "' And Sucursal = '" & .Sucursal & "' And Bodega = '" & .Bodega & "' And Codigo_Sector = '" & .Codigo_Sector & "' And FechaIngreso = '" & Format(_FechaIngreso, "yyyyMMdd") & "')"

            End With


            Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            If _Tbl.Rows.Count = 0 Then
                Throw New System.Exception("No se encontraron detalles para la cabecera")
            End If

            _Item = 1

            For Each _Fila As DataRow In _Tbl.Rows

                Dim _Detalle As New ImpCabecera.Cabecera_Detalle

                _Detalle.Item = _Item
                _Detalle.Codigo = _Fila.Item("Codigo").ToString.Trim
                _Detalle.Descripcion = _Fila.Item("Descripcion").ToString.Trim

                _Doc.Detalle.Add(_Detalle)

                _Item += 1

            Next

            _Mensaje.EsCorrecto = True
            _Mensaje.Col2_Detalle = "Traer documento a imprimir"
            _Mensaje.Col1_Mensaje = "Datos rescatados correctamente"
            _Mensaje.Tag = _Doc

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Col2_Detalle = "Traer documento a imprimir"
            _Mensaje.Col1_Mensaje = ex.Message
            _Mensaje.Tag = Nothing
        End Try

        Return _Mensaje

    End Function

End Class

Namespace ImpCabecera

    Class DocumentoPrint
        Property Encabezado As Zw_WMS_Ubicaciones_Sectores
        Property Detalle As List(Of Cabecera_Detalle)
        Property Impreso As Boolean

        Sub New()
            Encabezado = New Zw_WMS_Ubicaciones_Sectores
            Detalle = New List(Of Cabecera_Detalle)
            Impreso = False
        End Sub

    End Class

    Public Class Cabecera_Detalle

        Property Impreso As Boolean
        Property Id_Sector As Integer
        Property Id_Mapa As Integer
        Property Empresa As String
        Property Sucursal As String
        Property Bodega As String
        Property Codigo_Sector As String
        Property Item As Integer
        Property Codigo As String
        Property Descripcion As String

    End Class

End Namespace

