Imports DevComponents.DotNetBar
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms
'Imports Lib_Bakapp_VarClassFunc

Public Class Cl_Imprimir_documento

    Public _IdMaeedo As Integer
    Public _TipoDoc As String
    Public _NombreFormato As String

    Dim _Ds_Documento_imprimir As DataSet
    Dim _Ds_Vale_imprimir As DataSet

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public _RutaImagen As String

    Enum _Tipo_impresion
        Documento
        Vale
        Vale_direccion
        Solicitud
        Solicitud_direccion
    End Enum

    Public Function _Imprimir_Documento(ByVal _Tipo As _Tipo_impresion, _
                                        ByVal _Ds_Datos As DataSet, _
                                        ByVal _Impresora As String, _
                                        ByVal _EsPreview As Boolean, _
                                        Optional ByVal _Ruta_Imagen As String = "")


        Try


            Dim printPreviewDialog1 As New PrintPreviewDialog()
            Dim printDoc As New PrintDocument


            Select Case _Tipo
                Case _Tipo_impresion.Documento
                    AddHandler printDoc.PrintPage, AddressOf Sb_imprimir_documento
                Case _Tipo_impresion.Vale_direccion
                    _Ds_Vale_imprimir = _Ds_Datos
                    _RutaImagen = _Ruta_Imagen
                    AddHandler printDoc.PrintPage, AddressOf Sb_PP_Direccion_Vale
                Case _Tipo_impresion.Vale
                    _Ds_Vale_imprimir = _Ds_Datos
                    _RutaImagen = _Ruta_Imagen
                    AddHandler printDoc.PrintPage, AddressOf Sb_PP_Vale_Mercaderia_pendiente
                Case _Tipo_impresion.Solicitud_direccion
                    _Ds_Vale_imprimir = _Ds_Datos
                    _RutaImagen = _Ruta_Imagen
                    AddHandler printDoc.PrintPage, AddressOf Sb_PP_Direccion_SOC
                Case Else
                    Return False
            End Select



            If _Tipo = _Tipo_impresion.Documento Then

                Consulta_sql = "SELECT TipoDoc, NombreFormato, LargoDoc, AnchoDoc, NroLineasXpag, Fila_InicioDetalle," & vbCrLf & _
                          "Fila_FinDetalle, Col_InicioDetalle, Col_FinDetalle" & vbCrLf & _
                          "FROM Zw_Formato00Pag" & vbCrLf & _
                          "Where TipoDoc = '" & _Tipo & "' and NombreFormato = '" & _NombreFormato & "'"

                Dim TblEncForm = _Sql.Fx_Get_DataTable(Consulta_sql)

                If CBool(TblEncForm.Rows.Count) Then

                    Dim FilaEnc = TblEncForm.Rows(0)

                    Dim _Ancho = Math.Round(FilaEnc.Item("AnchoDoc"), 2)
                    Dim _Largo = Math.Round(FilaEnc.Item("LargoDoc"), 2)

                    _Ancho = _Ancho / 2.54
                    _Largo = _Largo / 2.54

                    _Ancho = _Ancho * 1000
                    _Largo = _Largo * 1000

                    Dim _Doc_AnchoDoc As Integer = _Ancho
                    Dim _Doc_LargoDoc As Integer = _Largo

                    Dim _Doc_NrolineasXpag = FilaEnc.Item("NrolineasXpag")
                    Dim _Doc_Fila_InicioDetalle = FilaEnc.Item("Fila_InicioDetalle")
                    Dim _Doc_Fila_FinDetalle = FilaEnc.Item("Fila_FinDetalle")
                    Dim _Doc_Col_InicioDetalle = FilaEnc.Item("Col_InicioDetalle")
                    Dim _Doc_Col_FinDetalle = FilaEnc.Item("Col_FinDetalle")

                    Dim pkCustomSize1 As New Printing.PaperSize("Custom Paper Size", _Doc_AnchoDoc, _Doc_LargoDoc)

                Else

                    Return False
                    'printDoc.PrinterSettings.DefaultPageSettings.PaperSize
                End If
            End If

            ' asignamos el método de evento para cada página a imprimir

            'PageSize.Letter()
            ' indicamos que queremos imprimir
            'Dim Imp As String
            'Imp = trae_datoAccess(tb, "Impresora", "Tmp_Conf_Local", "Modulo = 'Imp_Picking'")

            If _EsPreview Then
                Dim prtPrev As New PrintPreviewDialog
                With prtPrev
                    .Document = printDoc
                    .Width = 500
                    .Height = 700
                    .Text = "Previsualizar documento"
                    .ShowDialog()
                End With
            Else

                printDoc.PrinterSettings.PrinterName = _Impresora
                printDoc.Print()
            End If
            Return True

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message)
        End Try

    End Function

    Private Sub Sb_imprimir_documento(ByVal sender As Object, _
                                      ByVal e As PrintPageEventArgs)


        Dim _Hora_Pc = FormatDateTime(Date.Now, DateFormat.ShortTime).ToString
        Dim _Fecha_Pc = FormatDateTime(Date.Now, DateFormat.ShortDate).ToString

        Dim _FteCourier_New As New Font("Courier New", 6, FontStyle.Bold) ' Crea la fuente

        'IMPRIME CODIGO DE BARRAS

        ' Dim _Tbl_Encabezado As DataTable = _Ds_Documento.Tables(0)
        'Dim iType As BarCode.Code128SubTypes = _
        'DirectCast([Enum].Parse(GetType(BarCode.Code128SubTypes), "CODE128"), BarCode.Code128SubTypes)
        'bm = BarCode.Code128(UCase(Tipo & Numero), iType, False)
        'If Not IsNothing(bm) Then
        'CodBarras.Image = bm
        'End If

        Try


            'Encabezado

            Consulta_sql = "SELECT TipoDoc,NombreFormato,NombreObjeto,Seccion,TipoDato,Funcion,Formato,CantDecimales," & vbCrLf & _
                           "Fuente,Tamano,Alto,Ancho,Estilo,Color,Fila_Y,Columna_X,Texto,RutaImagen" & vbCrLf & _
                           "FROM Zw_Format01Enc" & vbCrLf & _
                           "Where TipoDoc = 'OCC' And NombreFormato = '" & _NombreFormato & "'"
            '& vbCrLf & _
            '                          "And Seccion = 'E'"

            Dim _Tbl_Fx As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            'Dim _Columna_X As Single
            'Dim _Fila_Y As Single

            For Each _Fila As DataRow In _Tbl_Fx.Rows

                Dim _Imagen As New PictureBox

                Dim _NombreObjeto As String = _Fila.Item("NombreObjeto")
                Dim _TipoDato As String = _Fila.Item("TipoDato")
                Dim _Funcion As String = _Fila.Item("Funcion")
                Dim _Formato As String = _Fila.Item("Formato")
                Dim _CantDecimales = _Fila.Item("CantDecimales")
                Dim _Fuente As String = _Fila.Item("Fuente")
                Dim _Tamano As Single = _Fila.Item("Tamano")
                Dim _Alto As Single = _Fila.Item("Alto")
                Dim _Ancho As Single = _Fila.Item("Ancho")
                Dim _Estilo = _Fila.Item("Estilo")
                Dim _Color = _Fila.Item("Color")
                Dim _Fila_Y = _Fila.Item("Fila_Y")
                Dim _Columna_X = _Fila.Item("Columna_X")
                Dim _Texto = _Fila.Item("Texto")
                Dim _RutaImagen As String = _Fila.Item("RutaImagen")

                ' Dim DtFont As New Font("Arial", 7, FontStyle.Regular) ' Fuente del detalle
                Dim Imagen As New PictureBox


                Dim _Fte_Usar

                If _NombreObjeto = "Texto_libre" Then

                    _Fte_Usar = New Font(_Fuente, _Tamano, FontStyle.Bold)
                    e.Graphics.DrawString(_Texto, _Fte_Usar, Brushes.Black, _Columna_X, _Fila_Y)

                ElseIf _NombreObjeto = "Funcion" Then

                    _Fte_Usar = New Font(_Fuente, _Tamano, FontStyle.Bold)
                    e.Graphics.DrawString(_Texto, _Fte_Usar, Brushes.Black, _Columna_X, _Fila_Y)

                ElseIf _NombreObjeto = "Imagen" Then

                    Try
                        _Imagen.Image = New System.Drawing.Bitmap(_RutaImagen)
                        e.Graphics.DrawImage(_Imagen.Image, _Columna_X, _Fila_Y, _Ancho, _Alto)
                    Catch ex As Exception
                    End Try

                ElseIf _NombreObjeto = "Caja" Then

                    e.Graphics.DrawRectangle(Pens.Black, New Rectangle(_Columna_X, _Fila_Y, _Ancho, _Alto))

                End If
            Next

            ' Dim NroLineasPagina As Integer = e.PageBounds.Height / Dt2Font.GetHeight(e.Graphics)

            ' imprimimos la cadena
            'For Each Fila As DataRow In TablaOigenr.Rows
            'Dim Ttipo As String = Trim(Fila.Item("TipoProd").ToString)

            'e.Graphics.DrawString(Contador, Dt2Font, Brushes.Black, _Columna_X, _Fila_Y)
            '_Fila_Y = _Fila_Y + 10
            'e.Graphics.DrawString("Cód: " & Codigo & ", Item:" & numero_(Contador, 2), Dt2Font, Brushes.Black, _Columna_X, _Fila_Y)
            '_Fila_Y = _Fila_Y + 10
            'Descripcion = Trim(Descripcion)
            'Dim D1, D2 As String
            'D1 = Mid(Descripcion, 1, 45)
            'D2 = Mid(Descripcion, 46, 50)

            'Dim Lg As Integer = Len(Descripcion)

            'If Lg > 45 Then
            'e.Graphics.DrawString(D1, DtFont, Brushes.Black, _Columna_X, _Fila_Y)
            '_Fila_Y = _Fila_Y + 10
            'e.Graphics.DrawString(D2, DtFont, Brushes.Black, _Columna_X, _Fila_Y)
            'Else
            'e.Graphics.DrawString(D1, DtFont, Brushes.Black, _Columna_X, _Fila_Y)
            'End If


            'Next


            'If ObservacionPie <> "" Then

            'e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, _Columna_X, _Fila_Y)
            '_Fila_Y = _Fila_Y + 15

            'Dim Palabra As String = ""
            'Contador = 0

            'For Each Letra As String In ObservacionPie.ToCharArray

            'Palabra = Palabra & UCase(Letra)
            'Contador += 1

            'If Contador = 36 Then
            'Palabra = Palabra
            'e.Graphics.DrawString(Palabra, prFont, Brushes.Black, _Columna_X, _Fila_Y)
            'Palabra = ""
            '_Fila_Y = _Fila_Y + 12
            'Contador = 0
            'End If

            'Next


            'e.Graphics.DrawString(Palabra, prFont, Brushes.Black, _Columna_X, _Fila_Y)
            '_Fila_Y = _Fila_Y + 5
            'e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, _Columna_X, _Fila_Y)

            'ObservacionPie

            'End If

            '_Fila_Y = _Fila_Y + 30
            'e.Graphics.DrawImage(CodBarras.Image, _Columna_X + 10, _Fila_Y, 220, 70)
            'e.HasMorePages = False

        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub



#Region "Imprimir Vales"

    Private Sub Sb_PP_Direccion_Vale(ByVal sender As Object, _
                                    ByVal e As PrintPageEventArgs)


        ' Este evento se producirá cada vez que se imprima una nueva página
        ' imprimir HOLA MUNDO en Arial tamaño 24 y negrita

        Dim _Fila_Enc As DataRow = _Ds_Vale_imprimir.Tables(0).Rows(0) 'Encabezado del vale
        Dim _Fila_Dir As DataRow = _Ds_Vale_imprimir.Tables(1).Rows(0) 'Observaciones del vale, direccion de despacho

        Dim _NroVale As String = _Fila_Enc.Item("NroVale")


        Try
            'Vale-BkPost
            Dim bm As Bitmap = Nothing
            Dim CodBarras As New PictureBox
            Dim Imagen As New PictureBox


            Dim iType As BarCode.Code128SubTypes = _
             DirectCast([Enum].Parse(GetType(BarCode.Code128SubTypes), "CODE128"), BarCode.Code128SubTypes)
            bm = BarCode.Code128(UCase(_NroVale), iType, False)
            If Not IsNothing(bm) Then
                CodBarras.Image = bm
            End If

            ' imprimimos la cadena en el margen izquierdo
            Dim xPos As Single = 3 'e.MarginBounds.Left
            ' La fuente a usar

            Dim DtFont As New Font("Arial", 7, FontStyle.Regular) ' Fuente del detalle
            Dim Dt2Font As New Font("Arial", 8, FontStyle.Bold)   ' Fuente del detalle
            Dim prFont As New Font("Arial", 9, FontStyle.Bold)    ' Fuente Encabezado
            Dim Fte_Arial_12 As New Font("Arial", 12, FontStyle.Bold)    ' Fuente Encabezado


            Dim FontNro As New Font("Times New Roman", 14, FontStyle.Bold)
            Dim FontCon As New Font("Times New Roman", 11, FontStyle.Bold)
            ' la posición superior
            Dim yPos As Single = prFont.GetHeight(e.Graphics) - 10

            'tb = TablaOigenr 'DirectCast(Grilla.DataSource, DataTable)
            'Encabezado

            Try
                Imagen.Image = New System.Drawing.Bitmap(_RutaImagen)
                e.Graphics.DrawImage(Imagen.Image, xPos + 10, yPos, 250, 200)
            Catch ex As Exception
            End Try

            Dim _Hora_actual = FormatDateTime(Date.Now, DateFormat.ShortTime).ToString
            Dim _Fecha_actual = FormatDateTime(Date.Now, DateFormat.ShortDate).ToString

            Dim _Fecha_servidor = FormatDateTime(FechaDelServidor(), DateFormat.ShortTime).ToString

            Dim NroLineasPagina As Integer = e.PageBounds.Height / Dt2Font.GetHeight(e.Graphics)

            yPos += 180
            'e.Graphics.DrawString("VALE DE MERCADERIA PENDIENTE", prFont, Brushes.Black, xPos, yPos)
            e.Graphics.DrawString("DATOS DEL DESPACHO", Fte_Arial_12, Brushes.Black, xPos, yPos)
            yPos += 10
            e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            yPos += 15

            Dim _CodEntidad = _Fila_Enc.Item("CodEntidad")
            e.Graphics.DrawString("CLIENTE: " & _CodEntidad, prFont, Brushes.Black, xPos, yPos)
            yPos += 12

            Dim _Razon = _Fila_Enc.Item("Razon")
            e.Graphics.DrawString(_Razon, prFont, Brushes.Black, xPos, yPos)
            yPos += 10
            e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            yPos += 15

            e.Graphics.DrawString("VALE: " & _NroVale, Fte_Arial_12, Brushes.Black, xPos, yPos)
            yPos += 15
            'e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            'yPos = yPos + 15

            Dim _Tipo_Doc_As = _Fila_Enc.Item("Tipo_Doc_As")
            e.Graphics.DrawString("DOC.   : " & _Tipo_Doc_As & "-" & _Fila_Enc.Item("NroDoc_Doc_As"), Fte_Arial_12, Brushes.Black, xPos, yPos)
            yPos += 18

            Dim _Nom_Funcionario_Activa = _Fila_Enc.Item("Nom_Funcionario_Activa")
            e.Graphics.DrawString("RESP. : " & _Nom_Funcionario_Activa, prFont, Brushes.Black, xPos, yPos)
            yPos += 12
            e.Graphics.DrawString("FECHA: " & _Fecha_actual, prFont, Brushes.Black, xPos, yPos)
            yPos += 12
            e.Graphics.DrawString("HORA: " & _Hora_actual, prFont, Brushes.Black, xPos, yPos)
            yPos += 5
            e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            yPos += 25


            'e.Graphics.DrawString("DATOS DEL DESPACHO", Fte_Arial_12, Brushes.Black, xPos, yPos)
            'yPos = yPos + 10
            'e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            'yPos = yPos + 18


            'yPos = yPos + 5
            'e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            'yPos = yPos + 15
            Dim _Palabra As String
            Dim _Contador As Integer
            Dim _i = 0
            Dim _Direccion_Desp = _Fila_Dir.Item("Direccion_Desp")
            e.Graphics.DrawString("Dirección: ", prFont, Brushes.Black, xPos, yPos)
            yPos += 12

            For Each Letra As String In _Direccion_Desp.ToCharArray

                _Palabra = _Palabra & UCase(Letra)
                _Contador += 1

                If _Contador = 36 Or _Contador = Len(_Direccion_Desp) Then
                    e.Graphics.DrawString(_Palabra, prFont, Brushes.Black, xPos, yPos)
                    _Palabra = String.Empty
                    yPos = yPos + 12
                    _Contador = 0
                End If

            Next

            If Not String.IsNullOrEmpty(_Palabra) Then
                e.Graphics.DrawString(_Palabra, prFont, Brushes.Black, xPos, yPos)
            End If

            yPos += 18

            Dim _Comuna_Desp = _Fila_Dir.Item("Comuna_Desp")
            e.Graphics.DrawString("Comuna: ", prFont, Brushes.Black, xPos, yPos)
            yPos += 12
            e.Graphics.DrawString(_Comuna_Desp, prFont, Brushes.Black, xPos, yPos)
            yPos += 18

            Dim _Ciudad_Desp = _Fila_Dir.Item("Ciudad_Desp")
            e.Graphics.DrawString("Ciudad: ", prFont, Brushes.Black, xPos, yPos)
            yPos += 12
            e.Graphics.DrawString(_Ciudad_Desp, prFont, Brushes.Black, xPos, yPos)
            yPos += 18

            Dim _Contacto_Desp = _Fila_Dir.Item("Contacto_Desp")
            e.Graphics.DrawString("Contacto: ", prFont, Brushes.Black, xPos, yPos)
            yPos += 12
            e.Graphics.DrawString(_Contacto_Desp, prFont, Brushes.Black, xPos, yPos)
            yPos += 18


            Dim _Telefono_Desp = _Fila_Dir.Item("Telefono_Desp") & " - " & _Fila_Dir.Item("Contacto_Desp_Fono")
            e.Graphics.DrawString("Teléfono: ", prFont, Brushes.Black, xPos, yPos)
            yPos += 12
            e.Graphics.DrawString(_Telefono_Desp, prFont, Brushes.Black, xPos, yPos)
            yPos += 18

            Dim _Horario_Desp = _Fila_Dir.Item("Horario_Desp")
            e.Graphics.DrawString("Horario atención: ", prFont, Brushes.Black, xPos, yPos)
            yPos += 12
            e.Graphics.DrawString(_Horario_Desp, prFont, Brushes.Black, xPos, yPos)
            yPos += 18

            Dim _Observaciones As String = Replace(_Fila_Dir.Item("Observaciones"), vbCrLf, " ")

            e.Graphics.DrawString("Observaciones: ", prFont, Brushes.Black, xPos, yPos)
            yPos += 12



            _Palabra = String.Empty
            _Contador = 0

            Dim _Observaciones_Arr() = _Observaciones.ToCharArray


            For Each Letra As String In _Observaciones.ToCharArray

                _Palabra += UCase(Letra)
                _Contador += 1

                If _Contador = 36 Then
                    '_Palabra = _Palabra
                    e.Graphics.DrawString(_Palabra, prFont, Brushes.Black, xPos, yPos)
                    _Palabra = ""
                    yPos = yPos + 12
                    _Contador = 0
                End If

            Next

            If Not String.IsNullOrEmpty(_Palabra) Then
                e.Graphics.DrawString(_Palabra, prFont, Brushes.Black, xPos, yPos)
            End If



            'e.Graphics.DrawString(_Observaciones, prFont, Brushes.Black, xPos, yPos)
            yPos += 20

            e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            yPos = yPos + 15
            '------------------------





            yPos = yPos + 30
            e.Graphics.DrawImage(CodBarras.Image, xPos + 10, yPos, 220, 70)
            e.HasMorePages = False

        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub

    Private Sub Sb_PP_Vale_Mercaderia_pendiente(ByVal sender As Object, _
                                    ByVal e As PrintPageEventArgs)


        ' Este evento se producirá cada vez que se imprima una nueva página
        ' imprimir HOLA MUNDO en Arial tamaño 24 y negrita

        Dim _Fila_Enc_Vale As DataRow = _Ds_Vale_imprimir.Tables(0).Rows(0) 'Encabezado del vale
        'Dim _Fila_Dir_Vale As DataRow = _Ds_Vale_imprimir.Tables(1).Rows(0) 'Observaciones del vale, direccion de despacho

        Dim _Fila_Encabezado_Documento As DataRow = _Ds_Vale_imprimir.Tables(2).Rows(0) 'Observaciones del vale, direccion de despacho
        Dim _Tbl_Detalle_Documento As DataTable = _Ds_Vale_imprimir.Tables(3) 'Detalle del documento
        'Dim _Tbl_Observacion_Documento As DataTable = _Ds_Vale_imprimir.Tables(4) 'Detalle del documento

        Dim _NroVale As String = _Fila_Enc_Vale.Item("NroVale")


        Try
            'Vale-BkPost
            Dim bm As Bitmap = Nothing
            Dim CodBarras As New PictureBox
            Dim Imagen As New PictureBox


            Dim iType As BarCode.Code128SubTypes = _
             DirectCast([Enum].Parse(GetType(BarCode.Code128SubTypes), "CODE128"), BarCode.Code128SubTypes)
            bm = BarCode.Code128(UCase(_NroVale), iType, False)
            If Not IsNothing(bm) Then
                CodBarras.Image = bm
            End If

            ' imprimimos la cadena en el margen izquierdo
            Dim xPos As Single = 3 'e.MarginBounds.Left
            ' La fuente a usar

            Dim DtFont As New Font("Arial", 7, FontStyle.Regular) ' Fuente del detalle
            Dim Dt2Font As New Font("Arial", 8, FontStyle.Bold)   ' Fuente del detalle
            Dim prFont As New Font("Arial", 9, FontStyle.Bold)    ' Fuente Encabezado
            Dim Fte_Arial_12 As New Font("Arial", 12, FontStyle.Bold)    ' Fuente Encabezado


            Dim FontNro As New Font("Times New Roman", 14, FontStyle.Bold)
            Dim FontCon As New Font("Times New Roman", 11, FontStyle.Bold)
            ' la posición superior
            Dim yPos As Single = prFont.GetHeight(e.Graphics) - 10

            'tb = TablaOigenr 'DirectCast(Grilla.DataSource, DataTable)
            'Encabezado

            Try
                Imagen.Image = New System.Drawing.Bitmap(_RutaImagen)
                e.Graphics.DrawImage(Imagen.Image, xPos + 10, yPos, 250, 200)
            Catch ex As Exception
            End Try

            Dim _Hora_actual = FormatDateTime(Date.Now, DateFormat.ShortTime).ToString
            Dim _Fecha_actual = FormatDateTime(Date.Now, DateFormat.ShortDate).ToString

            Dim _Fecha_servidor = FormatDateTime(FechaDelServidor(), DateFormat.ShortTime).ToString

            Dim NroLineasPagina As Integer = e.PageBounds.Height / Dt2Font.GetHeight(e.Graphics)

            yPos += 180
            e.Graphics.DrawString("VALE DE MERCADERIA PENDIENTE", prFont, Brushes.Black, xPos, yPos)
            yPos += 10
            e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            yPos += 15

            Dim _CodEntidad = _Fila_Enc_Vale.Item("CodEntidad")
            e.Graphics.DrawString("CLIENTE: " & _CodEntidad, prFont, Brushes.Black, xPos, yPos)
            yPos += 12

            Dim _Razon = _Fila_Enc_Vale.Item("Razon")
            e.Graphics.DrawString(_Razon, prFont, Brushes.Black, xPos, yPos)
            yPos += 10
            e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            yPos += 15

            e.Graphics.DrawString("VALE: " & _NroVale, Fte_Arial_12, Brushes.Black, xPos, yPos)
            yPos += 15
            'e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            'yPos = yPos + 15

            Dim _Tipo_Doc_As = _Fila_Enc_Vale.Item("Tipo_Doc_As")
            e.Graphics.DrawString("DOC.   : " & _Tipo_Doc_As & "-" & _Fila_Enc_Vale.Item("NroDoc_Doc_As"), Fte_Arial_12, Brushes.Black, xPos, yPos)
            yPos += 18

            Dim _Nom_Funcionario_Activa = _Fila_Enc_Vale.Item("Nom_Funcionario_Activa")
            e.Graphics.DrawString("RESP. : " & _Nom_Funcionario_Activa, prFont, Brushes.Black, xPos, yPos)
            yPos += 12
            e.Graphics.DrawString("FECHA: " & _Fecha_actual, prFont, Brushes.Black, xPos, yPos)
            yPos += 12
            e.Graphics.DrawString("HORA: " & _Hora_actual, prFont, Brushes.Black, xPos, yPos)
            yPos += 5
            e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            yPos += 25


            e.Graphics.DrawString("DETALLE", Fte_Arial_12, Brushes.Black, xPos, yPos)
            yPos = yPos + 10
            e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            yPos = yPos + 18


            ' IMPRIMIR DELALLE DEL DOCUMENTO


            For Each _Fila As DataRow In _Tbl_Detalle_Documento.Rows
                'Dim Ttipo As String = Trim(Fila.Item("TipoProd").ToString)
                'Codigo = Trim(Mid(Fila.Item("KOPR").ToString, 1, 40))
                Dim _Codigo = _Fila.Item("KOPRCT").ToString
                Dim _Descripcion = Trim(Mid(_Fila.Item("NOKOPR").ToString, 1, 50))
                Dim _Saldo = Mid(_Fila.Item("SALDO").ToString, 1, 40)
                Dim _Ud = Mid(_Fila.Item("UD").ToString, 1, 40)

                'Ubicacion = Trim(Mid(_Fila.Item("UBICACION").ToString, 1, 40))
                'Stock = Mid(_Fila.Item("STOCK").ToString, 1, 40)

                If _Saldo > 0 Then
                    'e.Graphics.DrawString(Contador, Dt2Font, Brushes.Black, xPos, yPos)
                    'yPos = yPos + 10
                    e.Graphics.DrawString(_Codigo, Dt2Font, Brushes.Black, xPos, yPos)
                    yPos = yPos + 13

                    _Descripcion = Trim(_Descripcion)
                    Dim D1, D2 As String

                    D1 = Mid(_Descripcion, 1, 45)
                    D2 = Mid(_Descripcion, 46, 50)

                    Dim Lg As Integer = Len(_Descripcion)

                    If Lg > 45 Then
                        e.Graphics.DrawString(D1, DtFont, Brushes.Black, xPos, yPos)
                        yPos = yPos + 10
                        e.Graphics.DrawString(D2, DtFont, Brushes.Black, xPos, yPos)
                    Else
                        e.Graphics.DrawString(D1, DtFont, Brushes.Black, xPos, yPos)
                    End If


                    yPos = yPos + 13

                    e.Graphics.DrawString(_Ud, Dt2Font, Brushes.Black, xPos, yPos)
                    e.Graphics.DrawString(_Saldo, Dt2Font, Brushes.Black, xPos + 40, yPos)

                    'e.Graphics.DrawString(Stock, Dt2Font, Brushes.Black, xPos + 100, yPos)
                    'e.Graphics.DrawString(Ubicacion, Dt2Font, Brushes.Black, xPos + 160, yPos)

                    Dim CantiVal As Double = De_Txt_a_Num_01(_Saldo)
                    'Dim StockVal As Double = De_Txt_a_Num_01(Stock)
                    'Dim Diferencia = StockVal - CantiVal

                    'If Diferencia < 0 Then
                    'e.Graphics.DrawString("X", Dt2Font, Brushes.Black, xPos + 269, yPos)
                    'e.Graphics.DrawRectangle(Pens.Black, New Rectangle(xPos + 270, yPos, 15, 15))
                    'End If
                    e.Graphics.DrawRectangle(Pens.Black, New Rectangle(xPos + 270, yPos, 10, 15))


                    yPos = yPos + 5
                    e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
                    yPos += 15
                End If
                'Contador += 1
            Next

            yPos += 20
            e.Graphics.DrawString("CLIENTE:____________________________________ ", prFont, Brushes.Black, xPos, yPos)
            yPos += 30

            e.Graphics.DrawString("FIRMA:____________________________________ ", prFont, Brushes.Black, xPos, yPos)
            yPos += 12

            '**************************************************************************************************************


            'yPos = yPos + 5

            e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            yPos = yPos + 15
            '------------------------





            yPos = yPos + 30
            e.Graphics.DrawImage(CodBarras.Image, xPos + 10, yPos, 220, 70)
            e.HasMorePages = False

        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub
    
#End Region

#Region "Imprimir Solicitud Compra"

    Private Sub Sb_PP_Direccion_SOC(ByVal sender As Object, _
                                    ByVal e As PrintPageEventArgs)


        ' Este evento se producirá cada vez que se imprima una nueva página
        ' imprimir HOLA MUNDO en Arial tamaño 24 y negrita

        Dim _Fila_Enc As DataRow = _Ds_Vale_imprimir.Tables(0).Rows(0) 'Encabezado SOC
        Dim _Fila_Det As DataRow = _Ds_Vale_imprimir.Tables(1).Rows(0) 'Detalle SOC
        Dim _Fila_Dir As DataRow = _Ds_Vale_imprimir.Tables(2).Rows(0) 'Observaciones SOC, direccion de retiro

        Dim _NroSOC As String = _Fila_Enc.Item("Nro_SOC")


        Try
            'Vale-BkPost
            Dim bm As Bitmap = Nothing
            Dim CodBarras As New PictureBox
            Dim Imagen As New PictureBox


            Dim iType As BarCode.Code128SubTypes = _
             DirectCast([Enum].Parse(GetType(BarCode.Code128SubTypes), "CODE128"), BarCode.Code128SubTypes)
            bm = BarCode.Code128(UCase(_NroSOC), iType, False)
            If Not IsNothing(bm) Then
                CodBarras.Image = bm
            End If

            ' imprimimos la cadena en el margen izquierdo
            Dim xPos As Single = 3 'e.MarginBounds.Left
            ' La fuente a usar

            Dim DtFont As New Font("Arial", 7, FontStyle.Regular) ' Fuente del detalle
            Dim Dt2Font As New Font("Arial", 8, FontStyle.Bold)   ' Fuente del detalle
            Dim prFont As New Font("Arial", 9, FontStyle.Bold)    ' Fuente Encabezado
            Dim Fte_Arial_12 As New Font("Arial", 12, FontStyle.Bold)    ' Fuente Encabezado


            Dim FontNro As New Font("Times New Roman", 14, FontStyle.Bold)
            Dim FontCon As New Font("Times New Roman", 11, FontStyle.Bold)
            ' la posición superior
            Dim yPos As Single = prFont.GetHeight(e.Graphics) - 10

            'tb = TablaOigenr 'DirectCast(Grilla.DataSource, DataTable)
            'Encabezado

            Try
                Imagen.Image = New System.Drawing.Bitmap(_RutaImagen)
                e.Graphics.DrawImage(Imagen.Image, xPos + 50, yPos, 150, 100)
            Catch ex As Exception
            End Try

            Dim _Hora_actual = FormatDateTime(Date.Now, DateFormat.ShortTime).ToString
            Dim _Fecha_actual = FormatDateTime(Date.Now, DateFormat.ShortDate).ToString

            Dim _Fecha_servidor = FormatDateTime(FechaDelServidor(), DateFormat.ShortTime).ToString

            Dim NroLineasPagina As Integer = e.PageBounds.Height / Dt2Font.GetHeight(e.Graphics)

            yPos += 100
            'e.Graphics.DrawString("VALE DE MERCADERIA PENDIENTE", prFont, Brushes.Black, xPos, yPos)
            e.Graphics.DrawString("RETIRO DE MERCADERIA", Fte_Arial_12, Brushes.Black, xPos, yPos)
            yPos += 10
            e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            yPos += 15



            Dim _Tipo_Compra As String = _Fila_Enc.Item("Tipo_Compra")

            Dim _CodEntidad As String
            Dim _Razon As String

            If _Tipo_Compra = "D" Then
                _CodEntidad = _Fila_Enc.Item("CodProveedor")
                _Razon = _Fila_Enc.Item("Pro1")
            Else
                _CodEntidad = _Fila_Enc.Item("CodEntDespacho")
                _Razon = _Fila_Enc.Item("Pro2")
            End If

            e.Graphics.DrawString("PROVEEDOR: " & _CodEntidad, prFont, Brushes.Black, xPos, yPos)
            yPos += 12


            e.Graphics.DrawString(_Razon, prFont, Brushes.Black, xPos, yPos)
            yPos += 10
            e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            yPos += 15

            'e.Graphics.DrawString("SOC: " & _NroSOC, Fte_Arial_12, Brushes.Black, xPos, yPos)
            'yPos += 15
            'e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            'yPos = yPos + 15
            Dim _Nro_OCC = _Fila_Enc.Item("Nro_OCC")
            e.Graphics.DrawString("Orden de compra: " & _Nro_OCC, Fte_Arial_12, Brushes.Black, xPos, yPos)
            yPos += 18

            Dim _Vendedor = _Fila_Enc.Item("Ven")
            e.Graphics.DrawString("VENDEDOR: " & _Vendedor, prFont, Brushes.Black, xPos, yPos)
            yPos += 12
            e.Graphics.DrawString("FECHA: " & _Fecha_actual, prFont, Brushes.Black, xPos, yPos)
            yPos += 12
            e.Graphics.DrawString("HORA: " & _Hora_actual, prFont, Brushes.Black, xPos, yPos)
            yPos += 5
            e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            yPos += 25


            'e.Graphics.DrawString("DATOS DEL DESPACHO", Fte_Arial_12, Brushes.Black, xPos, yPos)
            'yPos = yPos + 10
            'e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            'yPos = yPos + 18


            'yPos = yPos + 5
            'e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            'yPos = yPos + 15
            Dim _Palabra As String
            Dim _Contador As Integer
            Dim _i = 0
            Dim _Direccion_Desp = _Fila_Dir.Item("Direccion_Retiro")
            e.Graphics.DrawString("Dirección: ", prFont, Brushes.Black, xPos, yPos)
            yPos += 12



            For Each Letra As String In _Direccion_Desp.ToCharArray

                _Palabra = _Palabra & UCase(Letra)
                _Contador += 1

                If _Contador = 36 Or _Contador = Len(_Direccion_Desp) Then
                    e.Graphics.DrawString(_Palabra, prFont, Brushes.Black, xPos, yPos)
                    _Palabra = String.Empty
                    yPos = yPos + 12
                    _Contador = 0
                End If

            Next

            If Not String.IsNullOrEmpty(_Palabra) Then
                e.Graphics.DrawString(_Palabra, prFont, Brushes.Black, xPos, yPos)
            End If

            yPos += 18

            Dim _Comuna_Desp = _Fila_Dir.Item("Comuna_Retiro")
            e.Graphics.DrawString("Comuna: ", prFont, Brushes.Black, xPos, yPos)
            yPos += 12
            e.Graphics.DrawString(_Comuna_Desp, prFont, Brushes.Black, xPos, yPos)
            yPos += 18

            Dim _Ciudad_Desp = _Fila_Dir.Item("Ciudad_Retiro")
            e.Graphics.DrawString("Ciudad: ", prFont, Brushes.Black, xPos, yPos)
            yPos += 12
            e.Graphics.DrawString(_Ciudad_Desp, prFont, Brushes.Black, xPos, yPos)
            yPos += 18

            Dim _Contacto_Desp = _Fila_Dir.Item("Contacto_Retiro")
            e.Graphics.DrawString("Contacto: ", prFont, Brushes.Black, xPos, yPos)
            yPos += 12
            e.Graphics.DrawString(_Contacto_Desp, prFont, Brushes.Black, xPos, yPos)
            yPos += 18
            Dim SS = _Ds_Vale_imprimir

            Dim _Telefono_Desp = Trim(_Fila_Dir.Item("Telefono_R")) & " - " & Trim(_Fila_Dir.Item("Telefono_C"))
            e.Graphics.DrawString("Teléfonos: ", prFont, Brushes.Black, xPos, yPos)
            yPos += 12
            e.Graphics.DrawString(_Telefono_Desp, prFont, Brushes.Black, xPos, yPos)
            yPos += 18

            Dim _Horario_Desp = _Fila_Dir.Item("Hora_Retiro")
            e.Graphics.DrawString("Horario atención: ", prFont, Brushes.Black, xPos, yPos)
            yPos += 12
            e.Graphics.DrawString(_Horario_Desp, prFont, Brushes.Black, xPos, yPos)
            yPos += 18

            Dim _Observaciones As String = Replace(_Fila_Dir.Item("Observaciones"), vbCrLf, " ")

            e.Graphics.DrawString("Observaciones: ", prFont, Brushes.Black, xPos, yPos)
            yPos += 12



            _Palabra = String.Empty
            _Contador = 0

            Dim _Observaciones_Arr() = _Observaciones.ToCharArray


            For Each Letra As String In _Observaciones.ToCharArray

                _Palabra += UCase(Letra)
                _Contador += 1

                If _Contador = 36 Then
                    '_Palabra = _Palabra
                    e.Graphics.DrawString(_Palabra, prFont, Brushes.Black, xPos, yPos)
                    _Palabra = ""
                    yPos = yPos + 12
                    _Contador = 0
                End If

            Next

            If Not String.IsNullOrEmpty(_Palabra) Then
                e.Graphics.DrawString(_Palabra, prFont, Brushes.Black, xPos, yPos)
            End If



            'e.Graphics.DrawString(_Observaciones, prFont, Brushes.Black, xPos, yPos)
            yPos += 20

            e.Graphics.DrawString("_____________________________________________", Dt2Font, Brushes.Black, xPos, yPos)
            yPos = yPos + 15
            '------------------------





            yPos = yPos + 30
            e.Graphics.DrawImage(CodBarras.Image, xPos + 10, yPos, 220, 70)
            e.HasMorePages = False

        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub

#End Region

End Class
