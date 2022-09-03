Imports System.Drawing.Printing

Public Class Clas_Imprimir_DocEnconstruccion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _PrtSettings As New PrinterSettings

    Dim _Item = 1
    Dim _Pagina = 1

    Dim _Chk_Mostrar_Item As Boolean

    Dim _Ds_Matriz_Documentos As DataSet
    Dim _Row_Entidad As DataRow
    Dim _Row_Encabezado As DataRow
    Dim _Tbl_Detalle As DataTable

    Dim _Imprimir_Negrita As Boolean

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

    Enum Enum_Tipo_Impresion
        Carta
        Vale
    End Enum

    Public Sub New(_Ds_Matriz_Documentos As DataSet)

        Me._Ds_Matriz_Documentos = _Ds_Matriz_Documentos

    End Sub

    Public Function Fx_Imprimir_Archivo(_Formulario As Form, _Impresora As String, _Tipo_Impresion As Enum_Tipo_Impresion)

        Try

            _Row_Encabezado = _Ds_Matriz_Documentos.Tables("Encabezado_Doc").Rows(0)
            _Tbl_Detalle = _Ds_Matriz_Documentos.Tables("Detalle_Doc")

            ' ejemplo simple para imprimir en .NET
            ' Usamos una clase del tipo PrintDocument

            Dim printDoc As New PrintDocument

            ' CON ESTA CONFIGURACION PODEMOS PROPORCIONAR LAS DIMENCIONES Y ESTADO DE LA PAGINA, MARGENES, LARGO Y HORIENTACION

            Dim _Doc_AnchoDoc As Double
            Dim _Doc_LargoDoc As Double

            'Dim pkCustomSize1 As New Printing.PaperSize(PaperKind.Letter, 850, 1100)
            'Dim PageSetupDialog1 As New PageSetupDialog

            Select Case _Tipo_Impresion

                Case Enum_Tipo_Impresion.Carta

                    'PageSetupDialog1.Document = printDoc
                    'PageSetupDialog1.PageSettings.Landscape = False

                    'PageSetupDialog1.PageSettings.PaperSize = pkCustomSize1
                    'PageSetupDialog1.PageSettings.Margins.Left = 2
                    'PageSetupDialog1.PageSettings.Margins.Right = 2

                    'PageSetupDialog1.ShowDialog()

                    ' asignamos el método de evento para cada página a imprimir
                    _Doc_AnchoDoc = 850
                    _Doc_LargoDoc = 1100

                    AddHandler printDoc.PrintPage, AddressOf Sb_Print_Imprimir_TamCarta

                Case Enum_Tipo_Impresion.Vale

                    _Doc_AnchoDoc = 295
                    _Doc_LargoDoc = 500 + 110

                    For Each _Fila As DataRow In _Tbl_Detalle.Rows
                        _Doc_LargoDoc += 45
                    Next

                    AddHandler printDoc.PrintPage, AddressOf Sb_Print_Imprimir_TamVale

                    'pkCustomSize1 = New Printing.PaperSize(PaperKind.Letter, _Doc_AnchoDoc, _Doc_LargoDoc)

            End Select

            Dim _TamañoPersonal = New Printing.PaperSize("Personalizado", _Doc_AnchoDoc, _Doc_LargoDoc + 2)

            ' indicamos que queremos imprimir

            printDoc.DocumentName = "Productos X Proveedor"

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

            printDoc.PrinterSettings = _PrtSettings
            printDoc.DefaultPageSettings.PaperSize = _TamañoPersonal

            printDoc.PrinterSettings.PrinterName = _Impresora
            printDoc.Print()

            Return True

        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub Sb_Print_Imprimir_TamCarta(sender As Object, ByVal e As PrintPageEventArgs)

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
            Dim _ZFD = 8

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

            e.Graphics.DrawString(RazonEmpresa, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold),
                                  Brushes.Black, _xPos, _yPos)
            e.Graphics.DrawString(RutEmpresa, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold),
                                  Brushes.Black, _xPos, _yPos + 15)

            e.Graphics.DrawString("*** Documento en construcción (no constituye venta) ***", Fx_Fuente(_Enum_Fuentes.Courier_New, 9, FontStyle.Bold),
                                  Brushes.Black, _xPos + 180, _yPos + 20)

            Dim _Fecha = DateTime.Now

            e.Graphics.DrawString("Fecha : " & DateTime.Now.ToString("dd/MM/yyyy"), Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular),
                                  Brushes.Black, _xPos + 660, _yPos)
            e.Graphics.DrawString("Hora  : " & DateTime.Now.ToString("HH:mm"), Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular),
                                  Brushes.Black, _xPos + 660, _yPos + 15)

            _yPos += 60

            Dim _Documento = _Row_Encabezado.Item("TipoDoc") & "-" & _Row_Encabezado.Item("NroDocumento")
            Dim _CodEntidad = _Row_Encabezado.Item("CodEntidad")
            Dim _Nombre_Entidad = _Row_Encabezado.Item("Nombre_Entidad")

            e.Graphics.DrawString("Documento: " & _Documento, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _xPos, _yPos)
            _yPos += 15
            e.Graphics.DrawString("Entidad  : " & _CodEntidad.ToString.Trim & " - " & _Nombre_Entidad, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _xPos, _yPos)

            _yPos += 20
            e.Graphics.DrawString(StrDup(79, "_"), _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            Dim _Contador = 0

            Dim _XVen = 20
            Dim _XBod = 60
            Dim _XCod = 100
            Dim _XDes = 200
            Dim _XUbi = 450 + 30
            Dim _XUdt = 500 + 30
            Dim _XCan = 580 - 20
            Dim _XPre = 630 - 20
            Dim _XDto = 700 - 20
            Dim _XTot = 750 - 20

            e.Graphics.DrawString("Ven", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XVen, _yPos)
            e.Graphics.DrawString("Bod", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XBod, _yPos)
            e.Graphics.DrawString("Código", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XCod, _yPos)
            e.Graphics.DrawString("Descripción", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XDes, _yPos)
            e.Graphics.DrawString("Ubic.", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XUbi, _yPos)
            e.Graphics.DrawString("Ud", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XUdt, _yPos)
            e.Graphics.DrawString("Cant.", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XCan + 20, _yPos)
            e.Graphics.DrawString("Precio", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XPre + 20, _yPos)
            e.Graphics.DrawString("Desc.", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XDto + 20, _yPos)
            e.Graphics.DrawString("Subtotal", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XTot + 20, _yPos)

            _yPos += 5
            e.Graphics.DrawString(StrDup(79, "_"), _Font_C12, Brushes.Black, _xPos, _yPos)

            _yPos += 30

            Dim _Alto = e.PageSettings.PaperSize.Height

            Dim _Filas_X_Documento = Math.Round(_Alto / 30, 0) - 5

            Dim _Items As Integer = _Tbl_Detalle.Rows.Count
            Dim _Paginas = Math.Ceiling(_Items / _Filas_X_Documento)

            Dim _Font As FontStyle

            If _Imprimir_Negrita Then
                _Font = FontStyle.Bold
            Else
                _Font = FontStyle.Regular
            End If

            Dim _NetoBruto As String = _Row_Encabezado.Item("DocEn_Neto_Bruto")

            For Each _Fila As DataRow In _Tbl_Detalle.Rows

                'Dim _Impreso As Boolean = _Fila.Item("Impreso")

                Dim _Codigo = _Fila.Item("Codigo")
                Dim _Descripcion = _Fila.Item("Descripcion")
                Dim _CodVendedor = _Fila.Item("CodVendedor")
                Dim _Bodega = _Fila.Item("Bodega")
                Dim _UbicacionBod = _Fila.Item("UbicacionBod")
                Dim _UdTrans = _Fila.Item("UdTrans")
                Dim _Cantidad = Fx_Formato_Numerico(_Fila.Item("Cantidad"), "999.999", False)
                Dim _Precio = Fx_Formato_Numerico(_Fila.Item("Precio"), "99.999.999", False)
                Dim _DescuentoPorc = Fx_Formato_Numerico(_Fila.Item("DescuentoPorc"), "99.99%", False)
                Dim _ValNetoLinea = Fx_Formato_Numerico(_Fila.Item("ValNetoLinea"), "999.999.999", False)
                Dim _ValBrutoLinea = Fx_Formato_Numerico(_Fila.Item("ValBrutoLinea"), "999.999.999", False)

                Dim _Subtotal = _ValNetoLinea

                If _NetoBruto = "B" Then _Subtotal = _ValBrutoLinea

                'Dim _Neto = Rellenar2(FormatNumber(_Fila.Item("Neto"), 0), 8, " ", Enum_Relleno.Izquierda)
                'Dim _Iva = Rellenar2(FormatNumber(_Fila.Item("IvaCalc"), 0), 8, " ", Enum_Relleno.Izquierda)
                'Dim _Bruto = Rellenar2(FormatNumber(_Fila.Item("Bruto"), 0), 8, " ", Enum_Relleno.Izquierda)
                'Dim _Vsaco = Rellenar2(FormatNumber(_Fila.Item("Vsaco"), 0), 8, " ", Enum_Relleno.Izquierda)

                If _Chk_Mostrar_Item Then

                    e.Graphics.DrawString(numero_(_Item, _Items.ToString.Length), Fx_Fuente(_Enum_Fuentes.Courier_New, 6, FontStyle.Regular),
                                      Brushes.Black, _xPos, _yPos + 2)

                End If

                e.Graphics.DrawString(_CodVendedor, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XVen, _yPos)
                e.Graphics.DrawString(_Bodega, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XBod, _yPos)
                e.Graphics.DrawString(_Codigo, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XCod, _yPos)
                e.Graphics.DrawString(_Descripcion, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XDes, _yPos)
                e.Graphics.DrawString(_UbicacionBod, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XUbi, _yPos)
                e.Graphics.DrawString(_UdTrans, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XUdt, _yPos)
                e.Graphics.DrawString(_Cantidad, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XCan, _yPos)
                e.Graphics.DrawString(_Precio, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XPre, _yPos)
                e.Graphics.DrawString(_DescuentoPorc, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XDto, _yPos)
                e.Graphics.DrawString(_Subtotal, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XTot, _yPos)

                _yPos += 15

                ' _Fila.Item("Impreso") = True
                _Contador += 1
                _Item += 1

                If _Contador = _Filas_X_Documento Then
                    Exit For
                End If

                '_FilaFm.Item("Impreso") = True
                If _Contador = _Filas_X_Documento Then
                    Exit For
                End If

            Next

            _yPos -= 10
                        e.Graphics.DrawString(StrDup(79, "_"), _Font_C12, Brushes.Black, _xPos, _yPos)

            _xPos = 20
            _yPos += 30

            Dim _CantTotal = Fx_Formato_Numerico(_Row_Encabezado.Item("CantTotal"), "999.999", False)

            Dim _TotalNetoDoc = Fx_Formato_Numerico(_Row_Encabezado.Item("TotalNetoDoc"), "999.999.999", False)
            Dim _TotalIvaDoc = Fx_Formato_Numerico(_Row_Encabezado.Item("TotalIvaDoc"), "999.999.999", False)
            Dim _TotalIlaDoc = Fx_Formato_Numerico(_Row_Encabezado.Item("TotalIlaDoc"), "999.999.999", False)
            Dim _TotalBrutoDoc = Fx_Formato_Numerico(_Row_Encabezado.Item("TotalBrutoDoc"), "999.999.999", False)

            e.Graphics.DrawString("Totales:", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XUbi, _yPos)
            e.Graphics.DrawString(_CantTotal, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XCan, _yPos)

            e.Graphics.DrawString("Neto   :", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XDto - 20, _yPos)
            e.Graphics.DrawString(_TotalNetoDoc, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XTot, _yPos)
            _yPos += 15
            e.Graphics.DrawString("I.V.A. :", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XDto - 20, _yPos)
            e.Graphics.DrawString(_TotalIvaDoc, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XTot, _yPos)

            Dim _Observaciones = _Ds_Matriz_Documentos.Tables("Observaciones_Doc").Rows(0).Item("Observaciones")

            e.Graphics.DrawString("Observaciones: ", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _xPos, _yPos)
            e.Graphics.DrawString(_Observaciones, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _xPos, _yPos + 20)

            _yPos += 15
            e.Graphics.DrawString("Impues.:", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XDto - 20, _yPos)
            e.Graphics.DrawString(_TotalIlaDoc, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XTot, _yPos)
            _yPos += 15
            e.Graphics.DrawString("Total  :", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XDto - 20, _yPos)
            e.Graphics.DrawString(_TotalBrutoDoc, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XTot, _yPos)

            'Dim _Saldo_Registros As Integer = NuloPorNro(_Tbl_Detalle.Compute("Sum(Contador)", "Impreso = 0"), 0)

            'e.Graphics.DrawString("Página " & _Pagina & " de " & _Paginas, Fx_Fuente(_Enum_Fuentes.Courier_New, 7, _Font), Brushes.Black, _xPos, _yPos)

            'If CBool(_Saldo_Registros) Then
            '    e.HasMorePages = True
            'Else
            'e.HasMorePages = False
            'End If

            _Pagina += 1

            e.HasMorePages = False

        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub

    Private Sub Sb_Print_Imprimir_TamVale(sender As Object, ByVal e As PrintPageEventArgs)

        Try

            ' imprimimos la cadena en el margen izquierdo
            Dim _xPos As Single = 5 'e.MarginBounds.Left
            ' La fuente a usar

            ' la posición superior
            Dim _yPos As Single = prFont.GetHeight(e.Graphics) - 10

            _xPos = 10

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
            Dim _ZFD = 8

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

            If RazonEmpresa.Trim.Length <= 30 Then
                e.Graphics.DrawString(RazonEmpresa, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold),
                                  Brushes.Black, _xPos, _yPos)
            Else
                e.Graphics.DrawString(Mid(RazonEmpresa, 1, 30), Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold),
                              Brushes.Black, _xPos, _yPos)
                _yPos += 15
                e.Graphics.DrawString(Mid(RazonEmpresa, 31, 30), Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold),
                              Brushes.Black, _xPos, _yPos)
            End If

            _yPos += 15
            e.Graphics.DrawString(RutEmpresa, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold),
                                  Brushes.Black, _xPos, _yPos)
            _yPos += 30
            e.Graphics.DrawString("DOCUMENTO EN CONSTRUCCION", Fx_Fuente(_Enum_Fuentes.Courier_New, 12, FontStyle.Bold),
                                  Brushes.Black, _xPos, _yPos)
            _yPos += 15
            e.Graphics.DrawString("* NO CONSTITUYE VENTA *", Fx_Fuente(_Enum_Fuentes.Courier_New, 12, FontStyle.Bold),
                                  Brushes.Black, _xPos + 10, _yPos)
            _yPos += 30
            Dim _Fecha = DateTime.Now

            e.Graphics.DrawString("Fecha : " & DateTime.Now.ToString("dd/MM/yyyy"), Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular),
                                  Brushes.Black, _xPos, _yPos)
            _yPos += 15
            e.Graphics.DrawString("Hora  : " & DateTime.Now.ToString("HH:mm"), Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular),
                                  Brushes.Black, _xPos, _yPos)

            _yPos += 30

            Dim _Documento = _Row_Encabezado.Item("TipoDoc") & "-" & _Row_Encabezado.Item("NroDocumento")
            Dim _CodEntidad = _Row_Encabezado.Item("CodEntidad")
            Dim _Nombre_Entidad = _Row_Encabezado.Item("Nombre_Entidad")

            e.Graphics.DrawString("Documento: " & _Documento, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _xPos, _yPos)
            _yPos += 15
            e.Graphics.DrawString("Entidad  : " & _CodEntidad.ToString.Trim & " - " & _Nombre_Entidad, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _xPos, _yPos)
            _yPos += 30
            e.Graphics.DrawString("DETALLE", Fx_Fuente(_Enum_Fuentes.Courier_New, 9, FontStyle.Bold), Brushes.Black, _xPos + 110, _yPos)

            _yPos += 5
            e.Graphics.DrawString(StrDup(26, "_"), _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            Dim _Contador = 0

            Dim _XCod = _xPos
            Dim _XVen = 110
            Dim _XBod = 150
            Dim _XUdt = 180
            Dim _XUbi = 210

            Dim _XDes = _xPos

            Dim _XCan = _xPos
            Dim _XPre = 60
            Dim _XDto = 120
            Dim _XTot = 160

            Dim _XTotXlin = 5

            e.Graphics.DrawString("Código", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XCod, _yPos)
            e.Graphics.DrawString("Ven", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XVen, _yPos)
            e.Graphics.DrawString("Bod", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XBod, _yPos)
            e.Graphics.DrawString("Ud", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XUdt, _yPos)
            e.Graphics.DrawString("Ubic.", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XUbi, _yPos)
            _yPos += 12

            e.Graphics.DrawString("Descripción", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XDes, _yPos)
            _yPos += 12

            e.Graphics.DrawString("Cantidad", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XCan, _yPos)
            e.Graphics.DrawString("Precio", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XPre + 20, _yPos)
            e.Graphics.DrawString("Desc.", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XDto + 20, _yPos)
            e.Graphics.DrawString("Subtotal", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _XTot + 20, _yPos)

            _yPos += 5
            e.Graphics.DrawString(StrDup(26, "_"), _Font_C12, Brushes.Black, _xPos, _yPos)

            _yPos += 30

            Dim _Alto = e.PageSettings.PaperSize.Height

            Dim _Filas_X_Documento = Math.Round(_Alto / 30, 0) - 5

            Dim _Items As Integer = _Tbl_Detalle.Rows.Count
            Dim _Paginas = Math.Ceiling(_Items / _Filas_X_Documento)

            Dim _Font As FontStyle

            If _Imprimir_Negrita Then
                _Font = FontStyle.Bold
            Else
                _Font = FontStyle.Regular
            End If

            Dim _NetoBruto As String = _Row_Encabezado.Item("DocEn_Neto_Bruto")

            For Each _Fila As DataRow In _Tbl_Detalle.Rows

                'Dim _Impreso As Boolean = _Fila.Item("Impreso")

                Dim _Codigo = _Fila.Item("Codigo")
                Dim _Descripcion = _Fila.Item("Descripcion")
                Dim _CodVendedor = _Fila.Item("CodVendedor")
                Dim _Bodega = _Fila.Item("Bodega")
                Dim _UbicacionBod = _Fila.Item("UbicacionBod")
                Dim _UdTrans = _Fila.Item("UdTrans")
                Dim _Cantidad = Fx_Formato_Numerico(_Fila.Item("Cantidad"), "999.999", False)
                Dim _Precio = Fx_Formato_Numerico(_Fila.Item("Precio"), "99.999.999", False)
                Dim _DescuentoPorc = Fx_Formato_Numerico(_Fila.Item("DescuentoPorc"), "99.99%", False)
                Dim _ValNetoLinea = Fx_Formato_Numerico(_Fila.Item("ValNetoLinea"), "999.999.999", False)
                Dim _ValBrutoLinea = Fx_Formato_Numerico(_Fila.Item("ValBrutoLinea"), "999.999.999", False)

                Dim _Subtotal = _ValNetoLinea

                If _NetoBruto = "B" Then _Subtotal = _ValBrutoLinea

                'Dim _Neto = Rellenar2(FormatNumber(_Fila.Item("Neto"), 0), 8, " ", Enum_Relleno.Izquierda)
                'Dim _Iva = Rellenar2(FormatNumber(_Fila.Item("IvaCalc"), 0), 8, " ", Enum_Relleno.Izquierda)
                'Dim _Bruto = Rellenar2(FormatNumber(_Fila.Item("Bruto"), 0), 8, " ", Enum_Relleno.Izquierda)
                'Dim _Vsaco = Rellenar2(FormatNumber(_Fila.Item("Vsaco"), 0), 8, " ", Enum_Relleno.Izquierda)

                If _Chk_Mostrar_Item Then

                    e.Graphics.DrawString(numero_(_Item, _Items.ToString.Length), Fx_Fuente(_Enum_Fuentes.Courier_New, 6, FontStyle.Regular),
                                      Brushes.Black, _xPos, _yPos + 2)

                End If

                e.Graphics.DrawString(_CodVendedor, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XVen, _yPos)
                e.Graphics.DrawString(_Bodega, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XBod, _yPos)
                e.Graphics.DrawString(_Codigo, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XCod, _yPos)
                e.Graphics.DrawString(_UbicacionBod, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XUbi, _yPos)
                e.Graphics.DrawString(_UdTrans, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XUdt, _yPos)
                _yPos += 12
                e.Graphics.DrawString(_Descripcion, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XDes, _yPos)
                _yPos += 12
                e.Graphics.DrawString(_Cantidad, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XCan, _yPos)
                e.Graphics.DrawString(_Precio, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XPre, _yPos)
                e.Graphics.DrawString(_DescuentoPorc, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XDto, _yPos)
                e.Graphics.DrawString(_Subtotal, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _XTot, _yPos)

                _yPos += 20

                ' _Fila.Item("Impreso") = True
                _Contador += 1
                _Item += 1

                If _Contador = _Filas_X_Documento Then
                    Exit For
                End If

                '_FilaFm.Item("Impreso") = True
                If _Contador = _Filas_X_Documento Then
                    Exit For
                End If

            Next

            _yPos -= 10
            e.Graphics.DrawString(StrDup(26, "_"), _Font_C12, Brushes.Black, _xPos, _yPos)

            _yPos += 30

            Dim _CantTotal = Fx_Formato_Numerico(_Row_Encabezado.Item("CantTotal"), "999.999", False)

            Dim _TotalNetoDoc = Fx_Formato_Numerico(_Row_Encabezado.Item("TotalNetoDoc"), "999.999.999", False)
            Dim _TotalIvaDoc = Fx_Formato_Numerico(_Row_Encabezado.Item("TotalIvaDoc"), "999.999.999", False)
            Dim _TotalIlaDoc = Fx_Formato_Numerico(_Row_Encabezado.Item("TotalIlaDoc"), "999.999.999", False)
            Dim _TotalBrutoDoc = Fx_Formato_Numerico(_Row_Encabezado.Item("TotalBrutoDoc"), "999.999.999", False)

            'e.Graphics.DrawString("Total Cant. :", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _xPos, _yPos)
            'e.Graphics.DrawString(_CantTotal, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _xPos + 60, _yPos)
            '_yPos += 20
            e.Graphics.DrawString("Neto   :", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _xPos, _yPos)
            e.Graphics.DrawString(_TotalNetoDoc, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _xPos + 60, _yPos)
            _yPos += 15
            e.Graphics.DrawString("I.V.A. :", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _xPos, _yPos)
            e.Graphics.DrawString(_TotalIvaDoc, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _xPos + 60, _yPos)

            _yPos += 15
            e.Graphics.DrawString("Impues.:", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _xPos, _yPos)
            e.Graphics.DrawString(_TotalIlaDoc, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _xPos + 60, _yPos)
            _yPos += 15
            e.Graphics.DrawString("Total  :", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _xPos, _yPos)
            e.Graphics.DrawString(_TotalBrutoDoc, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _xPos + 60, _yPos)

            _yPos += 5
            e.Graphics.DrawString(StrDup(26, "_"), _Font_C12, Brushes.Black, _xPos, _yPos)

            _yPos += 30

            Dim _Observaciones = _Ds_Matriz_Documentos.Tables("Observaciones_Doc").Rows(0).Item("Observaciones")

            _Observaciones = Replace(_Observaciones, Chr(13), " ")

            e.Graphics.DrawString("Observaciones: ", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _xPos, _yPos)
            _yPos += 15
            e.Graphics.DrawString(Mid(_Observaciones, 1, 30), Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _xPos, _yPos)
            _yPos += 15
            e.Graphics.DrawString(Mid(_Observaciones, 31, 30), Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _xPos, _yPos)
            _yPos += 15
            e.Graphics.DrawString(Mid(_Observaciones, 61, 30), Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _xPos, _yPos)
            _yPos += 15
            e.Graphics.DrawString(Mid(_Observaciones, 91, 30), Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _xPos, _yPos)

            '_yPos += 5
            'e.Graphics.DrawString(StrDup(26, "_"), _Font_C12, Brushes.Black, _xPos, _yPos)

            _yPos += 20
            e.Graphics.DrawString("Nota escrita:", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _xPos, _yPos)

            _yPos += 30
            e.Graphics.DrawString(StrDup(26, "_"), _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 30
            e.Graphics.DrawString(StrDup(26, "_"), _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 30
            e.Graphics.DrawString(StrDup(26, "_"), _Font_C12, Brushes.Black, _xPos, _yPos)
            '_yPos += 30
            'e.Graphics.DrawString(StrDup(26, "_"), _Font_C12, Brushes.Black, _xPos, _yPos)

            'Dim _Saldo_Registros As Integer = NuloPorNro(_Tbl_Detalle.Compute("Sum(Contador)", "Impreso = 0"), 0)

            'e.Graphics.DrawString("Página " & _Pagina & " de " & _Paginas, Fx_Fuente(_Enum_Fuentes.Courier_New, 7, _Font), Brushes.Black, _xPos, _yPos)

            'If CBool(_Saldo_Registros) Then
            '    e.HasMorePages = True
            'Else
            'e.HasMorePages = False
            'End If

            _Pagina += 1

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
