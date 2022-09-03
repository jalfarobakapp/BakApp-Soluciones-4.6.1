Imports System.Drawing.Printing

Public Class Cl_Imprimir_CompPagoClientes

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

    Public Sub New(_CodEntidad As String, _Sucursal As String, _Tbl_Maedpce As DataTable, _Tbl_Estado_Cuenta As DataTable)

        _Total_Documentos_Pago = 0
        _Totales_Documentos_Abonados = 0
        _Totales_Valor_Documentos = 0

        Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _CodEntidad & "'"
        _Row_Entidad = _Sql.Fx_Get_DataRow(Consulta_sql)

        Consulta_sql = "Select * From TABSU Where EMPRESA = '" & ModEmpresa & "' And KOSU = '" & _Sucursal & "'"
        _Row_Sucursal = _Sql.Fx_Get_DataRow(Consulta_sql)

        Me._Tbl_Maedpce = _Tbl_Maedpce
        Me._Tbl_Estado_Cuenta = _Tbl_Estado_Cuenta

        Dim dc As DataColumn

        Try
            dc = New DataColumn("Impreso", Type.GetType("System.Boolean"))
            _Tbl_Maedpce.Columns.Add(dc)
        Catch ex As Exception

        End Try

        Try
            dc = New DataColumn("Contador", Type.GetType("System.Int32"))
            _Tbl_Maedpce.Columns.Add(dc)
        Catch ex As Exception

        End Try

        'For Each _Fila As DataRow In _Tbl_Maedpce.Rows
        '    Dim _Id = _Fila.Item("ID")
        '    For Each _Fila2 As DataRow In _Tbl_Estado_Cuenta.Rows
        '        Dim _Id_Pago As Integer = _Fila2.Item("ID_PAGO")
        '        If _Id = _Id_Pago Then
        '            _Fila.Item("Nueva_Linea") = True
        '        End If
        '    Next
        'Next

        'For Each _Fila As DataRow In _Tbl_Maedpce.Rows
        '    _Fila.Item("Impreso") = Not _Fila.Item("Usar")
        '    _Fila.Item("Contador") = 1
        'Next

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
                For Each _Fila As DataRow In _Tbl_Maedpce.Rows
                    _Fila.Item("Impreso") = Not _Fila.Item("Usar")
                    _Fila.Item("Contador") = 1
                Next

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

            Dim _Items As Integer = _Tbl_Maedpce.Rows.Count

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

            _Titulo = "COMPROBANTE DE PAGO DE CLIENTES"

            Sb_Centrar_Titulo(e, _Titulo, _Enum_Fuentes.Courier_New, 10, FontStyle.Bold, 0, _yPos, 95, True)
            _yPos += 20

            Dim _Koen = _Row_Entidad.Item("KOEN").ToString.Trim
            Dim _Nokoen = _Row_Entidad.Item("NOKOEN").ToString.Trim
            Dim _Rut As String = _Row_Entidad.Item("RTEN").ToString.Trim
            Dim _Dien = _Row_Entidad.Item("DIEN").ToString.Trim

            If _Rut.Contains("-") Then
                Dim _Rt = Split(_Rut, "-")
                _Rut = _Rt(0)
            End If
            _Rut = FormatNumber(_Rut, 0) & "-" & RutDigito(_Rut)

            _Titulo = "Entidad: " & _Koen & " -.- " & _Rut & " -.- " & _Nokoen

            Sb_Centrar_Titulo(e, _Titulo, _Enum_Fuentes.Courier_New, 10, FontStyle.Regular, 0, _yPos, 95, False)
            _yPos += 20

            _Titulo = "Domicilio: " & _Dien

            Sb_Centrar_Titulo(e, _Titulo, _Enum_Fuentes.Courier_New, 10, FontStyle.Regular, 0, _yPos, 95, False)
            _yPos += 20

            Dim _Kosu = _Row_Sucursal.Item("KOSU").ToString.Trim
            Dim _Nokosu = _Row_Sucursal.Item("NOKOSU").ToString.Trim

            _Titulo = "Sucursal Receptora: " & _Kosu & " " & _Nokosu

            Sb_Centrar_Titulo(e, _Titulo, _Enum_Fuentes.Courier_New, 10, FontStyle.Regular, 0, _yPos, 95, False)
            _yPos += 20

            e.Graphics.DrawString(StrDup(88, "_"), _Font_C12, Brushes.Black, 0, _yPos)
            _yPos += 30

            Dim _Col1TDP = 20
            Dim _Col1NumInt = 60
            Dim _Col1Emisor = 150
            Dim _Col1Numero = 400
            Dim _Col1FEmision = 500
            Dim _Col1FVenci = 600
            Dim _Col1ValDoc = 700

            Dim _Contador = 0

            e.Graphics.DrawString("TDP", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col1TDP, _yPos)
            e.Graphics.DrawString("Num-Int", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col1NumInt, _yPos)
            e.Graphics.DrawString("Emisor", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col1Emisor, _yPos)
            e.Graphics.DrawString("Número", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col1Numero, _yPos)
            e.Graphics.DrawString("Emision", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col1FEmision, _yPos)
            e.Graphics.DrawString("Vencim", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col1FVenci, _yPos)
            e.Graphics.DrawString("Valor Documento", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col1ValDoc, _yPos)

            _yPos += 15

            Dim _Col2TD = 150
            Dim _Col2Documento = 180
            Dim _Col2FEmision = 220 + 60
            Dim _Col2ValTotDoc = 300 + 60
            Dim _Col2Abono = 480 + 30
            Dim _Col2Numero = 580 + 30

            e.Graphics.DrawString("TD", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col2TD, _yPos)
            e.Graphics.DrawString("Documento", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col2Documento, _yPos)
            e.Graphics.DrawString("Emisión", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col2FEmision, _yPos)
            e.Graphics.DrawString("Valor Total Doc", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col2ValTotDoc, _yPos)
            e.Graphics.DrawString("Abono", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col2Abono, _yPos)
            e.Graphics.DrawString("Número", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col2Numero, _yPos)

            _xPos += 10
            e.Graphics.DrawString(StrDup(88, "_"), _Font_C12, Brushes.Black, 0, _yPos)

            _yPos += 30

            For Each _FilaFm As DataRow In _Tbl_Maedpce.Rows

                Dim _Impreso As Boolean = _FilaFm.Item("Impreso")

                _xPos = 30

                If Not _Impreso Then

                    Dim _Idmaedpce As Integer = _FilaFm.Item("IDMAEDPCE")

                    Consulta_sql = "SELECT TOP 1 NUDP,FEEMDP,VADP,VAASDP,VAVUDP,NUCUDP FROM MAEDPCE WITH ( NOLOCK ) WHERE IDMAEDPCE=" & _Idmaedpce
                    Dim _Row_Pago As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    Consulta_sql = "SELECT MAEDPCD.TIDOPA,MAEDPCD.FEASDP,MAEDPCD.VAASDP,MAEEDO.TIDO,MAEEDO.NUDO,MAEEDO.ENDO,MAEEDO.FEEMDO," &
                               "MAEEDO.FEULVEDO,MAEEDO.VABRDO,MAEEDO.LIBRO,CDOCCOE.TIDO AS TIDOC,CDOCCOE.NUDO AS NUDOC,CDOCCOE.ENDO AS ENDOC," &
                               "CDOCCOE.FEEMDO AS FEEMDOC,CDOCCOE.FEVEDO AS FEULVEDOC,CDOCCOE.VABRDO AS VABRDOC,MAEDPCE.TIDP,MAEDPCE.NUDP,MAEDPCE.ENDP," &
                               "MAEDPCE.FEEMDP,MAEDPCE.FEVEDP,MAEDPCE.VADP,MAEDPCE.NUCUDP" & vbCrLf &
                               "FROM MAEDPCD  WITH ( NOLOCK ) " &
                               "LEFT JOIN MAEDPCE ON MAEDPCD.IDRST=MAEDPCE.IDMAEDPCE AND MAEDPCD.ARCHIRST='MAEDPCE' " &
                               "LEFT JOIN MAEEDO  ON MAEDPCD.IDRST=MAEEDO.IDMAEEDO AND MAEDPCD.ARCHIRST='MAEEDO'  " &
                               "LEFT JOIN CDOCCOE ON MAEDPCD.IDRST=CDOCCOE.IDDOCCOE AND MAEDPCD.ARCHIRST='CDOCCOE '" & vbCrLf &
                               "WHERE MAEDPCD.IDMAEDPCE = " & _Idmaedpce
                    Dim _Tbl_Documentos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)


                    Dim _Id As Integer = _FilaFm.Item("ID").ToString.Trim
                    Dim _Tidp As String = _FilaFm.Item("TIDP").ToString.Trim
                    Dim _Nudp As String = _FilaFm.Item("NUDP").ToString.Trim
                    Dim _Emdp As String = _FilaFm.Item("EMDP").ToString.Trim
                    Dim _Nokoendp As String = _Sql.Fx_Trae_Dato("TABENDP", "NOKOENDP", "TIDPEN = SUBSTRING('" & _Tidp & "',1,2) And KOENDP = '" & _Emdp & "'").ToString.Trim

                    If _Tidp = "EFV" Then _Nokoendp = "EFECTIVO"

                    Dim _Cudp As String = _FilaFm.Item("CUDP").ToString.Trim
                    Dim _Nucudp As String = _FilaFm.Item("NUCUDP").ToString.Trim
                    Dim _FEmision As String = FormatDateTime(_FilaFm.Item("FEEMDP"), DateFormat.ShortDate)
                    Dim _FVencim As String = FormatDateTime(_FilaFm.Item("FEVEDP"), DateFormat.ShortDate)
                    Dim _Vadp As Double = _FilaFm.Item("VADP").ToString.Trim
                    Dim _Vaasdp As Double = _FilaFm.Item("VAASDP").ToString.Trim
                    Dim _Refanti As String = _FilaFm.Item("REFANTI").ToString.Trim
                    Dim _Usar As Boolean = _FilaFm.Item("Usar")
                    Dim _Nueva_Linea As Boolean = _FilaFm.Item("Nueva_Linea")

                    Dim _Vadp_Str As String = Rellenar2(FormatNumber(_Vadp, 0), 10, " ", Enum_Relleno.Izquierda)


                    If String.IsNullOrEmpty(_Nudp) Then
                        Dim _Rd As New Random
                        _Nudp = numero_(_Rd.Next(1000, 9999), 10)
                    End If

                    e.Graphics.DrawString(_Tidp, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col1TDP, _yPos)
                    e.Graphics.DrawString(_Nudp, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col1NumInt, _yPos)
                    e.Graphics.DrawString(_Nokoendp, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col1Emisor, _yPos)
                    e.Graphics.DrawString(_Nucudp, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col1Numero, _yPos)
                    e.Graphics.DrawString(_FEmision, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col1FEmision, _yPos)
                    e.Graphics.DrawString(_FVencim, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col1FVenci, _yPos)
                    e.Graphics.DrawString(_Vadp_Str, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col1ValDoc, _yPos)
                    _yPos += 15

                    If Not String.IsNullOrEmpty(_Refanti) Then

                        e.Graphics.DrawString("Ref.: ANTICIPO", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col1TDP, _yPos)
                        e.Graphics.DrawString(_Tidp, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col1Emisor, _yPos)
                        _yPos += 15

                    End If

                    Dim _Anticipo As Double = _Vadp - _Vaasdp

                    If CBool(_Anticipo) Then

                        e.Graphics.DrawString("ANT", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col2TD, _yPos)
                        e.Graphics.DrawString(_Nudp, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col2Documento, _yPos)

                        Dim _Favor_Str As String = Rellenar2(FormatNumber(_Anticipo, 0), 10, " ", Enum_Relleno.Izquierda)

                        e.Graphics.DrawString(_Favor_Str, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col2Abono, _yPos)

                        _Totales_Documentos_Abonados += _Anticipo
                        _yPos += 15

                    End If

                    _Totales_Valor_Documentos += _Vadp
                    _Contador += 1

                    For Each _Fila As DataRow In _Tbl_Documentos.Rows

                        'Dim _Id_Hijo As Integer = _Fila.Item("ID")
                        'Dim _Id_Padre As Integer = _Fila.Item("ID_PADRE")
                        'Dim _Id_Pago As Integer = _Fila.Item("ID_PAGO")
                        Dim _Dp2 As String = _Fila.Item("TIDOPA")
                        Dim _Nudp2 As String = _Fila.Item("NUDO").ToString.Trim
                        Dim _FEmision2 As String = FormatDateTime(_Fila.Item("FEEMDO"), DateFormat.ShortDate)
                        Dim _Vadp2 As Double = _Fila.Item("VABRDO").ToString.Trim
                        Dim _Abono As Double = _Fila.Item("VAASDP").ToString.Trim
                        'Dim _Nucudp2 As String = _Fila.Item("NUCUDP").ToString.Trim

                        Dim _Abono_Str As String = Rellenar2(FormatNumber(_Abono, 0), 10, " ", Enum_Relleno.Izquierda)
                        Dim _Vadp2_Str As String = Rellenar2(FormatNumber(_Vadp2, 0), 10, " ", Enum_Relleno.Izquierda)

                        'If CBool(_Id_Pago) Then

                        '    If _Id_Pago = _Id Then

                        e.Graphics.DrawString(_Dp2, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col2TD, _yPos)
                        e.Graphics.DrawString(_Nudp2, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col2Documento, _yPos)
                        e.Graphics.DrawString(_FEmision2, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col2FEmision, _yPos)
                        e.Graphics.DrawString(_Vadp2_Str, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col2ValTotDoc, _yPos)
                        e.Graphics.DrawString(_Abono_Str, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col2Abono, _yPos)

                        'If Not String.IsNullOrEmpty(_Nucudp2.Trim) Then
                        '    e.Graphics.DrawString("#:" & _Nucudp2, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col2Numero, _yPos)
                        'End If

                        _Totales_Documentos_Abonados += _Abono

                        'If _Id_Hijo = _Id_Padre Then
                        _Total_Documentos_Pago += _Vadp2
                        'End If

                        _yPos += 15

                        '    End If

                        'End If

                    Next


                End If

                _FilaFm.Item("Impreso") = True
                If _Contador = _Filas_X_Documento Then
                    Exit For
                End If

            Next

            _xPos += 10
            e.Graphics.DrawString(StrDup(88, "_"), _Font_C12, Brushes.Black, 0, _yPos)

            _yPos += 30

            ' indicamos que ya no hay nada más que imprimir
            ' (el valor predeterminado de esta propiedad es False)

            Dim _Saldo_Registros As Integer = NuloPorNro(_Tbl_Maedpce.Compute("Sum(Contador)", "Impreso = 0"), 0)

            Dim _Total_Documentos_Pago_Str As String = Rellenar2(FormatNumber(_Total_Documentos_Pago, 0), 10, " ", Enum_Relleno.Izquierda)
            Dim _Totales_Documentos_Abonados_Str As String = Rellenar2(FormatNumber(_Totales_Documentos_Abonados, 0), 10, " ", Enum_Relleno.Izquierda)
            Dim _Totales_Valor_Documentos_Str As String = Rellenar2(FormatNumber(_Totales_Valor_Documentos, 0), 10, " ", Enum_Relleno.Izquierda)

            e.Graphics.DrawString("Total documentos de pago", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, 20, _yPos)
            e.Graphics.DrawString(_Totales_Documentos_Abonados_Str, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col2Abono, _yPos)
            e.Graphics.DrawString(_Totales_Valor_Documentos_Str, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col1ValDoc, _yPos)
            _yPos += 15
            e.Graphics.DrawString("Totales documentos abonados", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, 20, _yPos)
            e.Graphics.DrawString(_Total_Documentos_Pago_Str, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular), Brushes.Black, _Col2ValTotDoc, _yPos)

            _Pagina += 1

            If CBool(_Saldo_Registros) Then
                e.HasMorePages = True
            Else
                e.HasMorePages = False
            End If

            'e.HasMorePages = False

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
        _Espacio = _Ancho_Pg - _Espacio '_Largo - _Espacio
        _Espacio = Math.Round(_Espacio / 2, 0)


        '_e.Graphics.DrawString(StrDup(_Espacio, " ") & _Titulo, Fx_Fuente(_Fuente, _Tamano, _FontStyle, _Subrayado), Brushes.Black, _x + _Espacio, _y)
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


End Class
