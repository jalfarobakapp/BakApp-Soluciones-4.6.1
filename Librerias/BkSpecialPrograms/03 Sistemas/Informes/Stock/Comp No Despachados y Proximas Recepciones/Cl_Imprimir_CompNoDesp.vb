Imports System.Drawing.Printing

Public Class Cl_Imprimir_CompNoDesp

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _PrtSettings As New PrinterSettings
    Dim _Imprimir_Negrita As Boolean

    Dim _Tbl_Maedpce As DataTable
    Dim _Tbl_Estado_Cuenta As DataTable

    Dim _Item = 1
    Dim _Pagina = 1

    Dim _Row_Entidad As DataRow
    Dim _Row_Sucursal As DataRow

    Dim _Total_Documentos_Pago As Double
    Dim _Totales_Documentos_Abonados As Double
    Dim _Totales_Valor_Documentos As Double

    Private _ListaImprimir As List(Of Imprimir_CND.DocumentoPrint)

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

    Public Sub New(_Ls_Idmaeedo As List(Of String))

        _Total_Documentos_Pago = 0
        _Totales_Documentos_Abonados = 0
        _Totales_Valor_Documentos = 0

        _ListaImprimir = New List(Of Imprimir_CND.DocumentoPrint)

        Dim _Filtro As String = Generar_Filtro_IN_Lista2(_Ls_Idmaeedo, True, "")

        For Each _Idmaeedo In _Ls_Idmaeedo

            Dim _Mensaje As LsValiciones.Mensajes = Fx_Llenar_Documento(_Idmaeedo)

            If _Mensaje.EsCorrecto Then
                Dim _Doc As Imprimir_CND.DocumentoPrint = _Mensaje.Tag
                _ListaImprimir.Add(_Doc)
            End If

        Next

    End Sub

    Public Property Imprimir_Negrita As Boolean
        Get
            Return _Imprimir_Negrita
        End Get
        Set(value As Boolean)
            _Imprimir_Negrita = value
        End Set
    End Property

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

            Dim _Filas_X_Documento = Math.Round(_Alto / 30, 0) - 5

            Dim _Items As Integer

            For Each documento As Imprimir_CND.DocumentoPrint In _ListaImprimir
                _Items += documento.Detalle.Count
            Next

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

            _Titulo = "NOTAS DE VENTA Y FACTURAS CON DESPACHOS PENDIENTES (DETALLADO)"

            Sb_Centrar_Titulo(e, _Titulo, _Enum_Fuentes.Courier_New, 10, FontStyle.Bold, 0, _yPos, 95, True)
            _yPos += 20

            _Titulo = "DOCUMENTOS COMPLETOS-EMITIDOS ENTRE EL 18/12/2024 Y 18/12/2024"

            Sb_Centrar_Titulo(e, _Titulo, _Enum_Fuentes.Courier_New, 10, FontStyle.Regular, 0, _yPos, 95, False)
            _yPos += 20

            e.Graphics.DrawString(StrDup(88, "_"), _Font_C12, Brushes.Black, 0, _yPos)
            _yPos += 30

            Dim _Enc_TD = 20
            Dim _Enc_Nudo = 60
            Dim _Enc_FEntrega = 150
            Dim _Enc_Vendedor = 220
            Dim _Enc_Sucursal = 260
            Dim _Enc_Bodega = 290
            Dim _Enc_Plaz = 320
            Dim _Enc_Observaciones = 350
            'Dim _Col1FVenci = 600
            'Dim _Col1ValDoc = 700

            Dim _Contador = 0

            e.Graphics.DrawString("TD", Fx_Fuente(_Enum_Fuentes.Courier_New, 7, FontStyle.Regular), Brushes.Black, _Enc_TD, _yPos)
            e.Graphics.DrawString("Número", Fx_Fuente(_Enum_Fuentes.Courier_New, 7, FontStyle.Regular), Brushes.Black, _Enc_Nudo, _yPos)
            e.Graphics.DrawString("F.Emisión", Fx_Fuente(_Enum_Fuentes.Courier_New, 7, FontStyle.Regular), Brushes.Black, _Enc_FEntrega, _yPos)
            e.Graphics.DrawString("OCC", Fx_Fuente(_Enum_Fuentes.Courier_New, 7, FontStyle.Regular), Brushes.Black, _Enc_Vendedor, _yPos)
            e.Graphics.DrawString("F.Entrega", Fx_Fuente(_Enum_Fuentes.Courier_New, 7, FontStyle.Regular), Brushes.Black, _Enc_Observaciones, _yPos)


            _yPos += 15

            Dim _Col2TD = 150
            Dim _Col2Documento = 180
            Dim _Col2FEmision = 220 + 60
            Dim _Col2ValTotDoc = 300 + 60
            Dim _Col2Abono = 480 + 30
            Dim _Col2Numero = 580 + 30

            e.Graphics.DrawString("TD", Fx_Fuente(_Enum_Fuentes.Courier_New, 7, FontStyle.Regular), Brushes.Black, _Col2TD, _yPos)
            e.Graphics.DrawString("Documento", Fx_Fuente(_Enum_Fuentes.Courier_New, 7, FontStyle.Regular), Brushes.Black, _Col2Documento, _yPos)
            e.Graphics.DrawString("Emisión", Fx_Fuente(_Enum_Fuentes.Courier_New, 7, FontStyle.Regular), Brushes.Black, _Col2FEmision, _yPos)
            e.Graphics.DrawString("Valor Total Doc", Fx_Fuente(_Enum_Fuentes.Courier_New, 7, FontStyle.Regular), Brushes.Black, _Col2ValTotDoc, _yPos)
            e.Graphics.DrawString("Abono", Fx_Fuente(_Enum_Fuentes.Courier_New, 7, FontStyle.Regular), Brushes.Black, _Col2Abono, _yPos)
            e.Graphics.DrawString("Número", Fx_Fuente(_Enum_Fuentes.Courier_New, 7, FontStyle.Regular), Brushes.Black, _Col2Numero, _yPos)

            _xPos += 10
            e.Graphics.DrawString(StrDup(120, "_"), _Font_C12, Brushes.Black, 20, _yPos)

            _yPos += 30

            Dim _Det_Codigo = 60
            Dim _Det_Detalle = 140
            Dim _Det_CantSoli = 490
            Dim _Det_CantDesp = 540
            Dim _Det_CantPend = 590
            Dim _Det_Um = 640
            Dim _Det_Occ = 660

            For Each _Documento As Imprimir_CND.DocumentoPrint In _ListaImprimir

                If Not _Documento.Impreso Then

                    'Dim _Vadp_Str As String = Rellenar2(FormatNumber(_Vadp, 0), 10, " ", Enum_Relleno.Izquierda)

                    With _Documento.Encabezado

                        e.Graphics.DrawString("Entidad: " & .Entidad & " Sucursal:" & .Suc & " " & .RazonSocial, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _Enc_TD, _yPos)
                        _yPos += 15
                        e.Graphics.DrawString("Emisión: " & .FechaEmision & " Zona:" & .Zona & " Dir:" & .Direccion.Trim & "/" & .Comuna, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _Enc_TD, _yPos)
                        _yPos += 15
                        e.Graphics.DrawString(StrDup(10, "-"), Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, 20, _yPos)
                        _yPos += 15

                        e.Graphics.DrawString(.Tido, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Enc_TD, _yPos)
                        e.Graphics.DrawString(.Nudo, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Enc_Nudo, _yPos)
                        e.Graphics.DrawString(.FechaEntrega.Date.ToShortDateString, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Enc_FEntrega, _yPos)
                        e.Graphics.DrawString(.Vendedor, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Enc_Vendedor, _yPos)
                        e.Graphics.DrawString(.Sucursal, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Enc_Sucursal, _yPos)
                        e.Graphics.DrawString(.Observaciones, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Enc_Observaciones, _yPos)

                    End With

                    _yPos += 15

                    'e.Graphics.DrawString("Detalle de productos...", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col1TD, _yPos)
                    '_yPos += 15

                    For Each _Detalle As Imprimir_CND.DetalleDoc In _Documento.Detalle

                        With _Detalle

                            If Not .Impreso Then

                                e.Graphics.DrawString(.Codigo, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Det_Codigo, _yPos)
                                e.Graphics.DrawString(.Descripcion, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Det_Detalle, _yPos)
                                e.Graphics.DrawString(.CantSolicitado, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Det_CantSoli, _yPos)
                                e.Graphics.DrawString(.CantDespachado, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Det_CantDesp, _yPos)
                                e.Graphics.DrawString(.CantPendiente, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Det_CantPend, _yPos)
                                e.Graphics.DrawString(.UN, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Det_Um, _yPos)
                                e.Graphics.DrawString(_Documento.Encabezado.OrdenDeCompra, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Det_Occ, _yPos)

                                _yPos += 15

                                .Impreso = True

                            End If

                            _Contador += 1

                            ' Verificar si se necesita una nueva página
                            If _Contador = _Filas_X_Documento Then
                                _Pagina += 1
                                e.HasMorePages = True
                                Return
                            End If

                        End With

                    Next

                    e.Graphics.DrawString(StrDup(120, "-"), Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, 20, _yPos)
                    _yPos += 15

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

    Function Fx_Llenar_Documento(_Idmaeedo As Integer) As LsValiciones.Mensajes ' Imprimir_CND.DocumentoPrint 'As Imprimir_CND.DocumentoPrint

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim _Doc As New Imprimir_CND.DocumentoPrint

            Consulta_sql = "Select Edo.IDMAEEDO,Edo.TIDO,Edo.NUDO,Edo.ENDO,Edo.SUENDO,En.NOKOEN,En.DIEN,Cm.NOKOCM,En.KOFUEN," &
                       "Cm.NOKOCM,Edo.FEEMDO,Edo.FEER,En.ZOEN,ISNULL(Obs.OBDO,'') As OBDO ,ISNULL(Obs.OCDO,'') As OCDO" & vbCrLf &
                       "From MAEEDO Edo" & vbCrLf &
                       "Inner Join MAEEN En On Edo.ENDO = En.KOEN And Edo.SUENDO = En.SUEN" & vbCrLf &
                       "Left Join MAEEDOOB Obs On Edo.IDMAEEDO = Obs.IDMAEEDO" & vbCrLf &
                       "Left Join TABCM Cm On Cm.KOPA = En.PAEN And Cm.KOCI = En.CIEN And Cm.KOCM = En.CMEN" & vbCrLf &
                       "Where Edo.IDMAEEDO = " & _Idmaeedo

            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            If IsNothing(_Row) Then
                Throw New System.Exception("No se encontro el documento en MAEEDO IDMAEEDO = " & _Idmaeedo)
            End If

            Dim _Encabezado As New Imprimir_CND.EncabezadoDoc

            _Encabezado.Entidad = _Row.Item("ENDO").ToString.Trim
            _Encabezado.Suc = _Row.Item("SUENDO").ToString.Trim
            _Encabezado.RazonSocial = _Row.Item("NOKOEN").ToString.Trim
            _Encabezado.Direccion = _Row.Item("DIEN").ToString.Trim
            _Encabezado.Comuna = _Row.Item("NOKOCM").ToString.Trim
            _Encabezado.FechaEmision = _Row.Item("FEEMDO")
            _Encabezado.FechaEntrega = _Row.Item("FEER")
            _Encabezado.Zona = _Row.Item("ZOEN").ToString.Trim
            _Encabezado.Tido = _Row.Item("TIDO").ToString.Trim
            _Encabezado.Nudo = _Row.Item("NUDO").ToString.Trim
            _Encabezado.Vendedor = _Row.Item("KOFUEN").ToString.Trim
            _Encabezado.Sucursal = _Row.Item("SUENDO").ToString.Trim
            _Encabezado.Bodega = String.Empty '_Row.Item("KOBODE").ToString.Trim
            _Encabezado.Observaciones = _Row.Item("OBDO").ToString.Trim
            _Encabezado.OrdenDeCompra = _Row.Item("OCDO").ToString.Trim

            _Doc.Encabezado = _Encabezado

            Consulta_sql = "Select Ddo.KOPRCT,Ddo.NOKOPR,CASE When UDTRPR = 1 Then UD01PR Else UD02PR End As UM," &
                           "CAPRCO1,CAPREX1,CAPRCO1-CAPREX1 As PENDIENTE" & vbCrLf &
                           "From MAEDDO Ddo " & vbCrLf &
                           "Where Ddo.IDMAEEDO = " & _Idmaeedo
            Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            If _Tbl.Rows.Count = 0 Then
                Throw New System.Exception("No se encontraron detalles para el documento IDMAEEDO = " & _Idmaeedo)
            End If

            For Each _Fila As DataRow In _Tbl.Rows

                Dim _Detalle As New Imprimir_CND.DetalleDoc

                _Detalle.Impreso = False
                _Detalle.Codigo = _Fila.Item("KOPRCT").ToString.Trim
                _Detalle.Descripcion = _Fila.Item("NOKOPR").ToString.Trim
                _Detalle.CantSolicitado = _Fila.Item("CAPRCO1")
                _Detalle.CantDespachado = _Fila.Item("CAPREX1")
                _Detalle.CantPendiente = _Fila.Item("PENDIENTE")
                _Detalle.UN = _Fila.Item("UM").ToString.Trim
                _Detalle.MontoPend = 0 '_Fila.Item("MONTO_PENDIENTE")

                _Doc.Detalle.Add(_Detalle)

            Next

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Traer documento a imprimir"
            _Mensaje.Mensaje = "Datos rescatados correctamente"
            _Mensaje.Tag = _Doc

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Traer documento a imprimir"
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Tag = Nothing
        End Try

        Return _Mensaje

    End Function

End Class

Namespace Imprimir_CND

    Class DocumentoPrint
        Property Encabezado As EncabezadoDoc
        Property Detalle As List(Of DetalleDoc)
        Property Impreso As Boolean
        Sub New()
            Encabezado = New EncabezadoDoc
            Detalle = New List(Of DetalleDoc)
            Impreso = False
        End Sub

    End Class

    Class EncabezadoDoc
        Property Entidad As String
        Property Suc As String
        Property RazonSocial As String
        Property Direccion As String
        Property Comuna As String
        Property FechaEmision As Date
        Property FechaEntrega As Date
        Property Zona As String
        Property Tido As String
        Property Nudo As String
        Property Vendedor As String
        Property Sucursal As String
        Property Bodega As String
        Property Observaciones As String
        Property OrdenDeCompra As String

    End Class

    Class DetalleDoc
        Property Impreso As Boolean
        Property Codigo As String
        Property Descripcion As String
        Property CantSolicitado As Double
        Property CantDespachado As Double
        Property CantPendiente As Double
        Property UN As String
        Property MontoPend As Double
    End Class

End Namespace
