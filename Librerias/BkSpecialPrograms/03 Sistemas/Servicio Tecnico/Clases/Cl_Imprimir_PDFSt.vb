Imports System.Drawing.Printing
Imports System.Drawing.Text

Public Class Cl_Imprimir_PDFSt

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private prtSettings As PrinterSettings

    Public Property Ds_Ot As DataSet

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
    Private _Filas_X_Documento As Integer
    Private _Item As Integer
    Private _Pagina As Integer

#End Region

    Public Sub New(_Id_Ot As Integer)

        Dim _Fuentes As New Fuentes_Impresion.ListaFuentes
        'Sb_Cargar_OrdenDeServicio(_Id_Ot)

    End Sub

    Public Function Fx_Imprimir_Archivo(_Formulario As Form,
                                        _Nombre_documento As String,
                                        ByRef _Impresora As String)

        Try

            ' ejemplo simple para imprimir en .NET
            ' Usamos una clase del tipo PrintDocument

            Dim printDoc As New PrintDocument

            'Dim pd As Printing.PrintDocument
            'pd = New Printing.PrintDocument

            'Dim pkCustomSize1 As New Printing.PaperSize("Custom Paper Size", 100, 5000)
            'printDoc.PrinterSettings.DefaultPageSettings.PaperSize = pkCustomSize1

            'Dim pkCustomSize1 As New Printing.PaperSize(PaperKind.Legal, 850, 1400)

            ' CON ESTA CONFIGURACION PODEMOS PROPORCIONAR LAS DIMENCIONES Y ESTADO DE LA PAGINA, MARGENES, LARGO Y HORIENTACION

            Dim pkCustomSize1 As New Printing.PaperSize(PaperKind.Legal, 850, 1400)

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

            AddHandler printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Portada_OT

            ' indicamos que queremos imprimir

            printDoc.DocumentName = _Nombre_documento

            If String.IsNullOrEmpty(_Impresora) Then
                Dim prtDialog As New PrintDialog
                If prtSettings Is Nothing Then
                    prtSettings = New PrinterSettings
                End If

                With prtDialog
                    .AllowPrintToFile = False
                    .AllowSelection = False
                    .AllowSomePages = False
                    .PrintToFile = False
                    .ShowHelp = False
                    .ShowNetwork = True

                    .PrinterSettings = prtSettings

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
            Return False
            MsgBox(ex.Message)
        End Try
    End Function

    'Sub Sb_Cargar_OrdenDeServicio(_Id_Ot As Integer)

    '    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_St_OT_Encabezado" & vbCrLf &
    '                   "Inner Join MAEEN On KOEN = CodEntidad And SUEN = SucEntidad" & vbCrLf &
    '                   "WHERE Id_Ot = " & _Id_Ot & vbCrLf &
    '                   "Select OtEnc.Sub_Ot,OtDet.*,Edo.VABRDO,Edo.VANEDO,VAIVDO,Ddo.*,1 As Contador,Cast(0 As Bit) As Impreso" & vbCrLf &
    '                   "From " & _Global_BaseBk & "Zw_St_OT_Doc_Asociados OtDet" & vbCrLf &
    '                   "Inner Join MAEEDO Edo On Edo.IDMAEEDO = Idmaeedo" & vbCrLf &
    '                   "Inner Join MAEDDO Ddo on Edo.IDMAEEDO = Ddo.IDMAEEDO" & vbCrLf &
    '                   "Left Join " & _Global_BaseBk & "Zw_St_OT_Encabezado OtEnc On OtEnc.Id_Ot = OtDet.Id_Ot" & vbCrLf &
    '                   "Where OtDet.Id_Ot In (Select Id_Ot From " & _Global_BaseBk & "Zw_St_OT_Encabezado Where Id_Ot_Padre = " & _Id_Ot & ") And Edo.TIDO = 'COV'"

    '    Ds_Ot = _Sql.Fx_Get_DataSet(Consulta_sql)

    'End Sub

    Private Sub Sb_Print_PrintPage_Portada_OT(sender As Object, e As PrintPageEventArgs)

        Try

            ' imprimimos la cadena en el margen izquierdo
            Dim _xPos As Single = 3 'e.MarginBounds.Left
            ' La fuente a usar


            ' la posición superior
            Dim _yPos As Single = prFont.GetHeight(e.Graphics) - 10

            _xPos = 20
            _yPos += 20

            Dim _Row_Encabezado As DataRow = Ds_Ot.Tables(0).Rows(0)
            Dim _Tbl_Detalle As DataTable = Ds_Ot.Tables(1)

            Dim _Nro_Ot = _Row_Encabezado.Item("Nro_Ot")
            Dim _Referencia '= _Row_Pote.Item("REFERENCIA")
            Dim _Fiot '= _Row_Pote.Item("FIOT")
            Dim _Ftespprod '= _Row_Pote.Item("FTESPPROD")   'Fecha estimada entrega
            Dim _Fechaoc ' = _Row_Pote.Item("FECHAOC")        'Fecha de confirmación

            Dim _Nokoen As String

            Consulta_sql = "SELECT DISTINCT IDPOTE,EDO.IDMAEEDO,EDO.SUDO,POTLCOM.DESDE AS TIDOD, POTLCOM.NUMECOTI AS NUDOD,KOFUDO," &
                           "NOKOFU AS VENDEDOR,EDO.ENDO,EDO.SUENDO,NOKOEN,Isnull(OBS.OBDO,'') As OBDO,Isnull(OBS.OCDO,'') As OCDO" & vbCrLf &
                           "From POTL WITH ( NOLOCK )" & vbCrLf &
                           "Inner Join POTLCOM On POTLCOM.IDPOTL = POTL.IDPOTL" & vbCrLf &
                           "Left Outer Join MAEEDO EDO On EDO.TIDO = POTLCOM.DESDE AND POTLCOM.NUMECOTI = EDO.NUDO" & vbCrLf &
                           "Left Outer Join MAEEN On EDO.ENDO = KOEN AND EDO.SUENDO = SUEN" & vbCrLf &
                           "Left Outer Join TABFU On KOFU = KOFUDO" & vbCrLf &
                           "Left Join MAEEDOOB OBS On OBS.IDMAEEDO = EDO.IDMAEEDO" & vbCrLf &
                           "WHERE POTL.NUMOT='" & _Nro_Ot & "' AND POTL.EMPRESA = '" & Mod_Empresa & "'"
            Dim _TblDocRela As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
            Dim _Row_DocRela As DataRow

            If CBool(_TblDocRela.Rows.Count) Then
                _Row_DocRela = _TblDocRela.Rows(0)
            End If

            Dim _Font_Enc_1 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 14, FontStyle.Bold)
            Dim _Font_Enc_2 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 12, FontStyle.Regular)
            Dim _Font_Enc_3 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 10, FontStyle.Regular)
            Dim _Font_Enc_4 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 8, FontStyle.Regular)

            Dim _Font_Detalle_1 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 6, FontStyle.Regular)
            Dim _Font_Detalle_2 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 8, FontStyle.Regular)
            Dim _Font_Detalle_3 As Font = Fx_Fuente(_Enum_Fuentes.Arial, 8, FontStyle.Regular)

            Dim _Font_Detalle_Curr_1_R As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 6, FontStyle.Regular)
            Dim _Font_Detalle_Curr_2_R As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular)

            Dim _Font_Detalle_Curr_1_B As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 6, FontStyle.Bold)
            Dim _Font_Detalle_Curr_2_B As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold)
            Dim _Font_Detalle_Curr_3_B As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 10, FontStyle.Bold)

            e.Graphics.DrawString("ORDEN DE SERVICIO", Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 18, FontStyle.Bold),
                                  Brushes.Black, _xPos + 300, _yPos)
            _yPos += 40

            e.Graphics.DrawString(RutEmpresa, _Font_Detalle_Curr_2_B, Brushes.Black, _xPos, _yPos)
            _yPos += 12
            e.Graphics.DrawString(RazonEmpresa, _Font_Detalle_Curr_2_B, Brushes.Black, _xPos, _yPos)

            e.Graphics.DrawString("NRO: " & _Nro_Ot, _Font_Enc_1, Brushes.Black, _xPos + 600, _yPos)
            _yPos += 12

            e.Graphics.DrawString(StrDup(200, "_"), _Font_Enc_2, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            _Nokoen = _Row_Encabezado.Item("NOKOEN").ToString.Trim
            e.Graphics.DrawString("CLIENTE: " & _Nokoen, _Font_Enc_3, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            'e.Graphics.DrawString("Fecha OT", _Font_Enc_3, Brushes.Black, _xPos, _yPos)
            'e.Graphics.DrawString(": " & _Fiot, _Font_Enc_3, Brushes.Black, _xPos + 180, _yPos)
            '_yPos += 20
            'e.Graphics.DrawString("Fecha confirmación OT", _Font_Enc_3, Brushes.Black, _xPos, _yPos)
            'e.Graphics.DrawString(": " & _Fechaoc, _Font_Enc_3, Brushes.Black, _xPos + 180, _yPos)
            '_yPos += 20
            'e.Graphics.DrawString("Fecha compromiso de entrega", _Font_Enc_3, Brushes.Black, _xPos, _yPos)
            'e.Graphics.DrawString(": " & _Ftespprod, _Font_Enc_3, Brushes.Black, _xPos + 180, _yPos)
            '_yPos += 40

            If Not IsNothing(_Row_DocRela) Then

                Dim _Vendedor = _Row_DocRela.Item("VENDEDOR")
                Dim _Sudo = _Row_DocRela.Item("SUDO")
                Dim _Sucursal = _Sql.Fx_Trae_Dato("TABSU", "NOKOSU", "EMPRESA = '" & Mod_Empresa & "' AND KOSU = '" & _Sudo & "'")
                Dim _Tidod = _Row_DocRela.Item("TIDOD")
                Dim _Nudod = _Row_DocRela.Item("NUDOD")
                Dim _Ocdo = _Row_DocRela.Item("OCDO")

                e.Graphics.DrawString("Solicitado por", _Font_Enc_3, Brushes.Black, _xPos, _yPos)
                e.Graphics.DrawString(": " & _Vendedor, _Font_Enc_3, Brushes.Black, _xPos + 180, _yPos)
                _yPos += 20
                e.Graphics.DrawString("Sucursal", _Font_Enc_3, Brushes.Black, _xPos, _yPos)
                e.Graphics.DrawString(": " & _Sudo & " - " & _Sucursal, _Font_Enc_3, Brushes.Black, _xPos + 180, _yPos)
                _yPos += 20
                e.Graphics.DrawString("Documento", _Font_Enc_3, Brushes.Black, _xPos, _yPos)
                e.Graphics.DrawString(": " & _Tidod & " - " & _Nudod, _Font_Enc_3, Brushes.Black, _xPos + 180, _yPos)
                _yPos += 20
                e.Graphics.DrawString("Orden de compra", _Font_Enc_3, Brushes.Black, _xPos, _yPos)
                e.Graphics.DrawString(": " & _Ocdo, _Font_Enc_3, Brushes.Black, _xPos + 180, _yPos)
                _yPos += 20

            End If

            e.Graphics.DrawString(StrDup(200, "_"), _Font_Enc_2, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            e.Graphics.DrawString("Sub OT", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos, _yPos)
            e.Graphics.DrawString("Documento", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos + 70, _yPos)
            e.Graphics.DrawString("Descripción del servicio", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos + 200, _yPos)
            e.Graphics.DrawString("Total neto", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos + 580, _yPos)

            _yPos += 10

            e.Graphics.DrawString(StrDup(200, "_"), _Font_Enc_2, Brushes.Black, _xPos, _yPos)

            _yPos += 30
            _xPos += 20

            Dim _Contador = 0

            Dim _TotalNeto As Double = 0
            Dim _TotalIva As Double = 0
            Dim _TotalBruto As Double = 0

            ' imprimimos la cadena

            Dim _Index As Integer = 0
            _Filas_X_Documento = 20

            Dim _Items As Integer = NuloPorNro(_Tbl_Detalle.Compute("Sum(Contador)", "Tido = 'COV'"), 0)
            Dim _Paginas = Math.Ceiling(_Items / _Filas_X_Documento)

            For Each _Fila As DataRow In _Tbl_Detalle.Rows

                'Dim _Nreglot As String = _Fila.Item("NREGOTL")
                Dim _Impreso As Boolean = _Fila.Item("Impreso")

                'If _Nreglot = _Sub_OT Then

                If Not _Impreso Then

                    Dim _Tido = Trim(_Fila.Item("Tido"))
                    Dim _Nudo = Trim(_Fila.Item("Nudo"))
                    Dim _Sub_Ot = Trim(_Fila.Item("Sub_Ot"))
                    Dim _Nokopr = Trim(_Fila.Item("NOKOPR"))
                    Dim _Vaneli = _Fila.Item("VANELI")
                    Dim _Vaivli = _Fila.Item("VAIVLI")
                    Dim _Vabrli = _Fila.Item("VABRLI")

                    _TotalNeto += _Vaneli
                    _TotalIva += _Vaivli
                    _TotalBruto += _Vabrli

                    e.Graphics.DrawString(_Sub_Ot, _Font_Detalle_Curr_2_R, Brushes.Black, _xPos, _yPos)
                    e.Graphics.DrawString(_Tido & "-" & _Nudo, _Font_Detalle_Curr_2_R, Brushes.Black, _xPos + 50, _yPos)
                    e.Graphics.DrawString(_Nokopr, _Font_Detalle_Curr_2_R, Brushes.Black, _xPos + 180, _yPos)

                    Dim _Vaneli_Str = Fx_Formato_Numerico(_Vaneli, "9.999.999", False)
                    e.Graphics.DrawString(_Vaneli_Str, _Font_Detalle_Curr_2_R, Brushes.Black, _xPos + 550, _yPos)

                    _yPos += 20

                    _Fila.Item("Impreso") = True
                    _Contador += 1
                    _Item += 1

                    If _Contador = _Filas_X_Documento Then
                        Exit For
                    End If

                End If

                'End If

            Next

            _xPos -= 20

            'Consulta_sql = "Select * From MEVENTO Where IDRVE = " & _Idpote & " And ARCHIRVE = 'POTE' Order By IDEVENTO"
            'Dim _TblMevento_Pote As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            '_yPos += (20 - _Item) * 30

            e.Graphics.DrawString(StrDup(200, "_"), _Font_Enc_2, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            Dim _Neto_Str = Fx_Formato_Numerico(_TotalNeto, "9.999.999", False)
            Dim _Iva_Str = Fx_Formato_Numerico(_TotalIva, "9.999.999", False)
            Dim _Bruto_Str = Fx_Formato_Numerico(_TotalBruto, "9.999.999", False)

            e.Graphics.DrawString("Total Neto  :" & _Neto_Str, _Font_Detalle_Curr_2_B, Brushes.Black, _xPos + 480, _yPos)
            _yPos += 15
            e.Graphics.DrawString("Iva         :" & _Iva_Str, _Font_Detalle_Curr_2_B, Brushes.Black, _xPos + 480, _yPos)
            _yPos += 15
            e.Graphics.DrawString("Total Bruto :" & _Bruto_Str, _Font_Detalle_Curr_2_B, Brushes.Black, _xPos + 480, _yPos)
            _yPos += 15

            'e.Graphics.DrawString("OBSERVACIONES:", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos, _yPos)
            '_yPos += 15

            'If CBool(_TblMevento_Pote.Rows.Count) Then

            '    For Each _Row_Mevento As DataRow In _TblMevento_Pote.Rows
            '        Dim _Nokocarac = _Row_Mevento.Item("NOKOCARAC")
            '        e.Graphics.DrawString(_Nokocarac, _Font_Detalle_Curr_2_R, Brushes.Black, _xPos, _yPos)
            '        _yPos += 15
            '    Next

            'End If

            _yPos += 90

            'e.Graphics.DrawString(StrDup(20, "_"), _Font_Enc_2, Brushes.Black, _xPos, _yPos)
            'e.Graphics.DrawString(StrDup(20, "_"), _Font_Enc_2, Brushes.Black, _xPos + 500, _yPos)
            '_yPos += 20
            'e.Graphics.DrawString("AUTORIZADO", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos + 50, _yPos)
            'e.Graphics.DrawString("FECHA ENTREGA", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos + 50 + 500, _yPos)

            Dim _Saldo_Registros As Integer = NuloPorNro(_Tbl_Detalle.Compute("Sum(Contador)", "Impreso = 0 And Tido = 'COV'"), 0)

            If CBool(_Saldo_Registros) Then
                e.HasMorePages = True
            Else
                'e.Graphics.DrawString("FIN IMPRESION", FontNro, Brushes.Black, _xPos, _yPos)
                e.HasMorePages = False
            End If
            _Pagina += 1

        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub

End Class

Namespace Fuentes_Impresion


    Public Class Fuente
        Public Property Nombre As String
    End Class

    Public Class ListaFuentes

        Public Property Fuentes As New List(Of Fuente)

        Public Sub New()
            CargarFuentes()
        End Sub

        Sub CargarFuentes()
            ' Obtener el arreglo de objetos FontFamily que representan las fuentes instaladas en el sistema
            ' Usar la instrucción Using para liberar los recursos
            Using coleccion As New InstalledFontCollection()
                Dim familias As FontFamily() = coleccion.Families

                For Each familia As FontFamily In familias
                    ' Obtener el nombre de la fuente usando la propiedad Name
                    Dim nombre As String = familia.Name
                    ' Agregar el nombre de la fuente a la colección
                    ' Usar la instrucción Dim para declarar e inicializar la variable
                    Dim nuevaFuente As New Fuente With {.Nombre = nombre}
                    Fuentes.Add(nuevaFuente)
                Next
            End Using
        End Sub

    End Class

End Namespace


