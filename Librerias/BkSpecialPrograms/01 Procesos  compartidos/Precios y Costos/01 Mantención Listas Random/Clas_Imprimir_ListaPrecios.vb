Imports DevComponents.DotNetBar
Imports System.Drawing.Printing

Public Class Clas_Imprimir_ListaPrecios

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _PrtSettings As New PrinterSettings

    Dim _Item = 1
    Dim _Pagina = 1

    Dim _Chk_Mostrar_Item As Boolean
    Dim _Tbl_Productos As DataTable
    Dim _Tbl_SuperFamilia As DataTable
    Dim _Tbl_Familias As DataTable
    Dim _Tbl_SubFamilias As DataTable

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

    Public Property Tbl_Productos As DataTable
        Get
            Return _Tbl_Productos
        End Get
        Set(value As DataTable)
            _Tbl_Productos = value
        End Set
    End Property

#End Region

    Public Sub New(_Tabla_Paso As String)

        Consulta_sql = "Select Cast(0 As Bit) As Impreso,1 As Contador, Tbl.*,Lp.NOKOLT,Mp.RLUD As Rtu,
	                           Isnull(Fm.NOKOFM,'') As NOKOFM,Isnull(Pf.NOKOPF,'') As NOKOPF,Isnull(Hf.NOKOHF,'') As NOKOHF,
	                           Mp.UD01PR,Mp.UD02PR,Round(Tbl.PP01UD,0) As Neto,Round(Tbl.PP01UD*1.19,0)-Round(Tbl.PP01UD,0) As IvaCalc,Round(Tbl.PP01UD*1.19,0) As Bruto,Round((Tbl.PP01UD*1.19) * Mp.RLUD,0) As Vsaco
	                           From " & _Tabla_Paso & " Tbl
                        Left Join TABFM Fm On Fm.KOFM = Tbl.FMPR 
                        Left Join TABPF Pf On Pf.KOFM = Tbl.FMPR And Pf.KOPF = Tbl.PFPR
                        Left Join TABHF Hf On Hf.KOFM = Tbl.FMPR And Hf.KOPF = Tbl.PFPR And Hf.KOPF = Tbl.HFPR
                        Left Join MAEPR Mp On Mp.KOPR = Tbl.KOPR
                        Left Join TABPP Lp On Lp.KOLT = Tbl.KOLT
                        Where [Select] = 1
                        Order By Tbl.FMPR,Tbl.PFPR,Tbl.HFPR,Tbl.KOPR"
        _Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_sql)

        Consulta_sql = "Select Distinct Cast(0 As Bit) As Impreso,FMPR From " & _Tabla_Paso & " Tbl Where [Select] = 1"
        _Tbl_SuperFamilia = _Sql.Fx_Get_Tablas(Consulta_sql)

        Consulta_sql = "Select Distinct Cast(0 As Bit) As Impreso,FMPR,PFPR,Pf.NOKOPF" & vbCrLf &
                       "From " & _Tabla_Paso & " Tbl" & vbCrLf &
                       "Left Join TABPF Pf On Pf.KOFM = FMPR And Pf.KOPF = PFPR " & vbCrLf &
                       "Where [Select] = 1"
        _Tbl_Familias = _Sql.Fx_Get_Tablas(Consulta_sql)

        Consulta_sql = "Select Distinct Cast(0 As Bit) As Impreso,FMPR,PFPR,HFPR From " & _Tabla_Paso & " Tbl Where [Select] = 1"
        _Tbl_SubFamilias = _Sql.Fx_Get_Tablas(Consulta_sql)

    End Sub

    Function Fx_Ejecutar_ImpresionOld() As Boolean

        Dim Chk_KOPR As New Command
        Chk_KOPR.Checked = True
        Chk_KOPR.Name = "Chk_KOPR"
        Chk_KOPR.Text = "Código del producto"

        Dim Chk_KOPRAL As New Command
        Chk_KOPRAL.Checked = False
        Chk_KOPRAL.Name = "Chk_KOPRAL"
        Chk_KOPRAL.Text = "Código alternativo"

        Dim Chk_NOKOPR As New Command
        Chk_NOKOPR.Checked = False
        Chk_NOKOPR.Name = "Chk_NOKOPR"
        Chk_NOKOPR.Text = "Descripción del producto"

        Dim Chk_ITEM As New Command
        Chk_ITEM.Checked = False
        Chk_ITEM.Name = "Chk_ITEM"
        Chk_ITEM.Text = "Mostrar Nro Item"

        Dim _Opciones() As Command = {Chk_KOPR, Chk_KOPRAL, Chk_NOKOPR}

        Dim _Info As New TaskDialogInfo("Informe maestra",
                                          eTaskDialogIcon.CheckMark2,
                                          "Orden de los productos",
                                          "Confirme su opción",
                                          eTaskDialogButton.Ok, eTaskDialogBackgroundColor.Red, _Opciones, Nothing, Chk_ITEM, Nothing, Nothing)

        Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)
        Dim _Orden As String

        If _Resultado = eTaskDialogResult.Ok Then

            _Chk_Mostrar_Item = Chk_ITEM.Checked

            If Chk_KOPR.Checked Then
                _Orden = "KOPR"
            End If

            If Chk_KOPRAL.Checked Then
                _Orden = "KOPRAL"
            End If

            If Chk_NOKOPR.Checked Then
                _Orden = "NOKOPR"
            End If

            Return CBool(_Tbl_Productos.Rows.Count)

        End If

    End Function

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
            Return False
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub Sb_Print_PrintPage_Listado(ByVal sender As Object, ByVal e As PrintPageEventArgs)

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

            If Not IO.Directory.Exists(AppPath() & "\Data\" & RutEmpresa & "\Imagenes") Then
                System.IO.Directory.CreateDirectory(AppPath() & "\Data\" & RutEmpresa & "\Imagenes")
            End If

            Dim _Imagen As New PictureBox
            Dim _RutaImagen = AppPath() & "\Data\" & RutEmpresa & "\Imagenes\LogoInfListaPrecio.jpg"

            Try

                _Imagen.Image = New System.Drawing.Bitmap(_RutaImagen)
                Using _Imagen
                    e.Graphics.DrawImage(_Imagen.Image, _xPos, _yPos, 100, 100)
                End Using
            Catch ex As Exception
            End Try

            Dim _Fecha = DateTime.Now

            e.Graphics.DrawString("Fecha : " & DateTime.Now.ToString("dd/MM/yyyy"), Fx_Fuente(_Enum_Fuentes.Courier_New, 10, FontStyle.Regular),
                                  Brushes.Black, _xPos + 650, _yPos)
            e.Graphics.DrawString("Hora  : " & DateTime.Now.ToString("HH:mm"), Fx_Fuente(_Enum_Fuentes.Courier_New, 10, FontStyle.Regular),
                                  Brushes.Black, _xPos + 650, _yPos + 20)
            _yPos += 30

            Dim _Kolt = _Tbl_Productos.Rows(0).Item("KOLT")
            Dim _NombreLista = "(" & _Kolt & ") " & _Tbl_Productos.Rows(0).Item("NOKOLT").ToString.Trim

            Dim _WebLista = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones", "NombreTabla", "Tabla = 'LISTAPRECIO_WEB' And CodigoTabla = '" & _Kolt & "'")
            Dim _FonoLista = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones", "NombreTabla", "Tabla = 'LISTAPRECIO_FONO' And CodigoTabla = '" & _Kolt & "'")
            Dim _Vigencia = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones", "NombreTabla", "Tabla = 'LISTAPRECIO_VIGENCIA' And CodigoTabla = '" & _Kolt & "'")

            ' Se agrega esta funcion para poner observaciones
            Dim _Observaciones2 = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones", "NombreTabla", "Tabla = 'LISTAPRECIO_OBSERV1' And CodigoTabla = '" & _Kolt & "'")

            '_Observaciones2 = "OBSERVACIONES 2 FDS DSF DSFSD FSDJF SDJF SDLFKJ LSDKFJ DSJF LSDFJLJSD NBN FIN"

            e.Graphics.DrawString(_NombreLista, Fx_Fuente(_Enum_Fuentes.Arial, 16, FontStyle.Bold), Brushes.Black, _xPos + 200, _yPos)
            _yPos += 30
            e.Graphics.DrawString("Vigencia:" & _Vigencia, Fx_Fuente(_Enum_Fuentes.Courier_New, _ZFE, FontStyle.Bold), Brushes.Black, _xPos + 250, _yPos)

            If Not String.IsNullOrWhiteSpace(_Observaciones2) Then
                _yPos += 30
                e.Graphics.DrawString("Obs:" & _Observaciones2, Fx_Fuente(_Enum_Fuentes.Courier_New, _ZFE, FontStyle.Bold), Brushes.Black, _xPos + 150, _yPos)
                _yPos += 30
            Else
                _yPos += 60
            End If

            Dim _Observaciones = _WebLista & Space(5) & "Fono: " & _FonoLista ' "www.cisternaspetfood.cl     Fono: 28213320 - 28213373"
            e.Graphics.DrawString(_Observaciones, Fx_Fuente(_Enum_Fuentes.Courier_New, _ZFE, FontStyle.Bold), Brushes.Black, _xPos, _yPos)
            _yPos += 10
            e.Graphics.DrawString(StrDup(79, "_"), _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 20

            Dim _Contador = 0

            e.Graphics.DrawString("PRECIO POR KILO", Fx_Fuente(_Enum_Fuentes.Courier_New, _ZFE, FontStyle.Bold), Brushes.Black, _xPos + 130 + 330 + 120, _yPos)
            '_yPos += 3
            e.Graphics.DrawString(StrDup(17, "_"), _Font_C12, Brushes.Black, _xPos + 120 + 330 + 100, _yPos)
            _yPos += 25

            _xPos += 10

            e.Graphics.DrawString("Código", Fx_Fuente(_Enum_Fuentes.Courier_New, _ZFE, FontStyle.Bold), Brushes.Black, _xPos, _yPos)
            _xPos += 120
            e.Graphics.DrawString("Descripción", Fx_Fuente(_Enum_Fuentes.Courier_New, _ZFE, FontStyle.Bold), Brushes.Black, _xPos, _yPos)
            _xPos += 330
            e.Graphics.DrawString("Envase", Fx_Fuente(_Enum_Fuentes.Courier_New, _ZFE, FontStyle.Bold), Brushes.Black, _xPos, _yPos)
            _xPos += 100
            e.Graphics.DrawString("Neto", Fx_Fuente(_Enum_Fuentes.Courier_New, _ZFE, FontStyle.Bold), Brushes.Black, _xPos, _yPos)
            _xPos += 70
            e.Graphics.DrawString("Iva", Fx_Fuente(_Enum_Fuentes.Courier_New, _ZFE, FontStyle.Bold), Brushes.Black, _xPos, _yPos)
            _xPos += 60
            e.Graphics.DrawString("Total", Fx_Fuente(_Enum_Fuentes.Courier_New, _ZFE, FontStyle.Bold), Brushes.Black, _xPos, _yPos)
            _xPos += 60
            e.Graphics.DrawString("V.SACO", Fx_Fuente(_Enum_Fuentes.Courier_New, _ZFE, FontStyle.Bold), Brushes.Black, _xPos, _yPos)

            _yPos += 30

            Dim _Alto = e.PageSettings.PaperSize.Height '- _yPos

            Dim _Filas_X_Documento = Math.Round(_Alto / 30, 0) - 5 ' 60

            Dim _Items As Integer = _Tbl_Productos.Rows.Count
            Dim _Paginas = Math.Ceiling(_Items / _Filas_X_Documento)

            Dim _Font As FontStyle

            If _Imprimir_Negrita Then
                _Font = FontStyle.Bold
            Else
                _Font = FontStyle.Regular
            End If

            For Each _FilaFm As DataRow In _Tbl_Familias.Rows

                Dim _EImpreso As Boolean = _FilaFm.Item("Impreso")
                Dim _EFmpr As String = _FilaFm.Item("FMPR").ToString.Trim
                Dim _EPfpr As String = _FilaFm.Item("PFPR").ToString.Trim
                Dim _ENokopf As String = _FilaFm.Item("NOKOPF").ToString.Trim

                Dim _Encimpreso As Boolean
                Dim _Familia = _EFmpr & "-" & _EPfpr & " (" & _ENokopf & ")"

                _xPos = 30
                If Not _EImpreso Then
                    e.Graphics.DrawString(_Familia, Fx_Fuente(_Enum_Fuentes.Courier_New, 10, FontStyle.Bold), Brushes.Black, _xPos, _yPos)
                    _yPos += 25
                    _Encimpreso = True
                    _Contador += 1
                End If

                For Each _Fila As DataRow In _Tbl_Productos.Rows

                    Dim _Impreso As Boolean = _Fila.Item("Impreso")

                    Dim _Kopr = _Fila.Item("KOPR").ToString.Trim
                    Dim _Nokopr = _Fila.Item("NOKOPR").ToString.Trim
                    Dim _Fmpr = _Fila.Item("FMPR").ToString.Trim
                    Dim _Nokofm = _Fila.Item("NOKOFM").ToString.Trim
                    Dim _Pfpr = _Fila.Item("PFPR").ToString.Trim
                    Dim _Nokopf = _Fila.Item("NOKOPF").ToString.Trim
                    Dim _Rlud = _Fila.Item("Rtu").ToString.Trim
                    Dim _Ud01pr = _Fila.Item("UD01PR").ToString.Trim
                    Dim _Ud02pr = _Fila.Item("UD02PR").ToString.Trim

                    _xPos = 5

                    If Not _Impreso And _EFmpr = _Fmpr And _EPfpr = _Pfpr Then

                        If _Contador = 0 And Not _Encimpreso Then
                            _xPos = 30
                            _Familia = _Fmpr & "-" & _Pfpr & " (" & _Nokopf & ")"
                            e.Graphics.DrawString(_Familia, Fx_Fuente(_Enum_Fuentes.Courier_New, 10, FontStyle.Bold), Brushes.Black, _xPos, _yPos)
                            _yPos += 25
                            _Encimpreso = True
                            _xPos = 5
                            _Contador += 1
                        End If

                        Dim _Neto = Rellenar2(FormatNumber(_Fila.Item("Neto"), 0), 8, " ", Enum_Relleno.Izquierda)
                        Dim _Iva = Rellenar2(FormatNumber(_Fila.Item("IvaCalc"), 0), 8, " ", Enum_Relleno.Izquierda)
                        Dim _Bruto = Rellenar2(FormatNumber(_Fila.Item("Bruto"), 0), 8, " ", Enum_Relleno.Izquierda)
                        Dim _Vsaco = Rellenar2(FormatNumber(_Fila.Item("Vsaco"), 0), 8, " ", Enum_Relleno.Izquierda)

                        _Rlud = Rellenar2(FormatNumber(_Rlud, 0), 2, " ", Enum_Relleno.Izquierda)

                        If _Chk_Mostrar_Item Then

                            e.Graphics.DrawString(numero_(_Item, _Items.ToString.Length), Fx_Fuente(_Enum_Fuentes.Courier_New, 6, FontStyle.Regular),
                                              Brushes.Black, _xPos, _yPos + 2)

                        End If

                        _xPos += 25

                        e.Graphics.DrawString(_Kopr, Fx_Fuente(_Enum_Fuentes.Courier_New, _ZFD, _Font), Brushes.Black, _xPos, _yPos)
                        _xPos += 120
                        e.Graphics.DrawString(_Nokopr, Fx_Fuente(_Enum_Fuentes.Courier_New, _ZFD, _Font), Brushes.Black, _xPos, _yPos)
                        _xPos += 330
                        e.Graphics.DrawString(_Rlud, Fx_Fuente(_Enum_Fuentes.Courier_New, _ZFD, _Font), Brushes.Black, _xPos, _yPos)
                        _xPos += 30
                        e.Graphics.DrawString(_Ud01pr, Fx_Fuente(_Enum_Fuentes.Courier_New, _ZFD, _Font), Brushes.Black, _xPos, _yPos)
                        _xPos += 30
                        e.Graphics.DrawString(_Neto, Fx_Fuente(_Enum_Fuentes.Courier_New, _ZFD, _Font), Brushes.Black, _xPos, _yPos)
                        _xPos += 70
                        e.Graphics.DrawString(_Iva, Fx_Fuente(_Enum_Fuentes.Courier_New, _ZFD, _Font), Brushes.Black, _xPos, _yPos)
                        _xPos += 70
                        e.Graphics.DrawString(_Bruto, Fx_Fuente(_Enum_Fuentes.Courier_New, _ZFD, _Font), Brushes.Black, _xPos, _yPos)
                        _xPos += 70
                        e.Graphics.DrawString(_Vsaco, Fx_Fuente(_Enum_Fuentes.Courier_New, _ZFD, _Font), Brushes.Black, _xPos, _yPos)

                        _yPos += 25

                        _Fila.Item("Impreso") = True
                        _Contador += 1
                        _Item += 1

                        If _Contador = _Filas_X_Documento Then
                            Exit For
                        End If

                    End If

                Next

                _FilaFm.Item("Impreso") = True
                If _Contador = _Filas_X_Documento Then
                    Exit For
                End If

            Next

            _xPos = 20
            _yPos += 15

            ' indicamos que ya no hay nada más que imprimir
            ' (el valor predeterminado de esta propiedad es False)

            Dim _Saldo_Registros As Integer = NuloPorNro(_Tbl_Productos.Compute("Sum(Contador)", "Impreso = 0"), 0)

            e.Graphics.DrawString("Página " & _Pagina & " de " & _Paginas, Fx_Fuente(_Enum_Fuentes.Courier_New, 7, _Font), Brushes.Black, _xPos, _yPos)

            If CBool(_Saldo_Registros) Then
                e.HasMorePages = True
            Else
                e.HasMorePages = False
            End If

            _Pagina += 1

            'e.HasMorePages = False

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
