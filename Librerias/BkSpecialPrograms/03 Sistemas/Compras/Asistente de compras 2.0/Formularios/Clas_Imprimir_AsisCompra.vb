Imports DevComponents.DotNetBar
Imports System.Drawing.Printing

Public Class Clas_Imprimir_AsisCompra

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Proveedor As DataRow

    Dim _PrtSettings As New PrinterSettings

    Dim _Item = 1
    Dim _Pagina = 1

    Dim _Chk_Mostrar_Item As Boolean
    Dim _Tbl_Productos As DataTable

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

    Public Sub New()

    End Sub

    Function Fx_Ejecutar_Impresion(_CodEntidad As String, _SucEntidad As String, _Ud As Integer) As Boolean

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

            _Row_Proveedor = Fx_Traer_Datos_Entidad(_CodEntidad, _SucEntidad)

            If _Ud <> 1 And _Ud <> 2 Then
                _Ud = 1
            End If

            Consulta_sql = "Select Mp.KOPR,Td.KOPRAL,Mp.NOKOPR,Mp.UD0" & _Ud & "PR As UD,RLUD,1 As Contador,Cast(0 As Bit) As Impreso 
                            From TABCODAL Td 
                            Inner Join MAEPR Mp On Td.KOPR = Mp.KOPR
                            Where KOEN = '" & _Row_Proveedor.Item("KOEN") & "' And BLOQUEAPR In ('','V')
                            Order by " & _Orden
            _Tbl_Productos = _Sql.Fx_Get_DataTable(Consulta_sql)

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

            Dim _Rut = _Row_Proveedor.Item("Rut")
            e.Graphics.DrawString("RUT            : " & _Rut, Fx_Fuente(_Enum_Fuentes.Courier_New, 10, FontStyle.Bold), Brushes.Black, _xPos, _yPos)
            e.Graphics.DrawString("Fecha: " & Now.Date.ToShortDateString, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular),
                                  Brushes.Black, _xPos + 700, _yPos)
            _yPos += 20

            Dim _Nokoen = _Row_Proveedor.Item("NOKOEN")
            e.Graphics.DrawString("NOMBRE         : " & _Nokoen, Fx_Fuente(_Enum_Fuentes.Courier_New, 10, FontStyle.Bold), Brushes.Black, _xPos, _yPos)

            e.Graphics.DrawString("Hora : " & DateTime.Now.ToString("HH:mm"), Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular),
                                  Brushes.Black, _xPos + 700, _yPos)
            _yPos += 10
            e.Graphics.DrawString(StrDup(79, "_"), _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 40

            Dim _Contador = 0
            Dim _Ord_Codigo, _Ord_Alternativo, _Ord_Descripcion As String

            Select Case _Ordenar_por
                Case Enum_Orden_Productos.Codigo
                    _Ord_Codigo = " *"
                Case Enum_Orden_Productos.Codigo_Alternativo
                    _Ord_Alternativo = " *"
                Case Enum_Orden_Productos.Descripcion
                    _Ord_Descripcion = " *"
            End Select

            _xPos += 10
            e.Graphics.DrawString("Código" & _Ord_Codigo, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _xPos, _yPos)
            _xPos += 100
            e.Graphics.DrawString("Código", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _xPos, _yPos - 15)
            e.Graphics.DrawString("Alternativo" & _Ord_Alternativo, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _xPos, _yPos)
            _xPos += 100
            e.Graphics.DrawString("Descripción" & _Ord_Descripcion, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _xPos, _yPos)
            _xPos += 310
            e.Graphics.DrawString("Ud", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _xPos, _yPos)
            _xPos += 30
            e.Graphics.DrawString("Rtu", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold), Brushes.Black, _xPos, _yPos)

            _xPos += 40
            e.Graphics.DrawString("Fecha           Fecha            Fecha       ", Fx_Fuente(_Enum_Fuentes.Courier_New, 6, FontStyle.Bold), Brushes.Black, _xPos, _yPos - 10)
            e.Graphics.DrawString("     _______         _______          _______", Fx_Fuente(_Enum_Fuentes.Courier_New, 6, FontStyle.Bold), Brushes.Black, _xPos, _yPos - 10)
            e.Graphics.DrawString("Stock|Pedido    Stock|Pedido     Stock|Pedido", Fx_Fuente(_Enum_Fuentes.Courier_New, 6, FontStyle.Bold), Brushes.Black, _xPos, _yPos + 5)

            _xPos = 20
            e.Graphics.DrawString(StrDup(79, "_"), _Font_C12, Brushes.Black, _xPos, _yPos)

            _yPos += 30

            Dim _Alto = e.PageSettings.PaperSize.Height

            Dim _Filas_X_Documento = Math.Round(_Alto / 30, 0) ' 60

            Dim _Items As Integer = _Tbl_Productos.Rows.Count
            Dim _Paginas = Math.Ceiling(_Items / _Filas_X_Documento)

            Dim _Font As FontStyle

            If _Imprimir_Negrita Then
                _Font = FontStyle.Bold
            Else
                _Font = FontStyle.Regular
            End If

            For Each _Fila As DataRow In _Tbl_Productos.Rows

                _xPos = 5

                Dim _Impreso As Boolean = _Fila.Item("Impreso")

                If Not _Impreso Then

                    Dim _Codido = _Fila.Item("KOPR").ToString.Trim
                    Dim _CodAlternativo = _Fila.Item("KOPRAL").ToString.Trim
                    Dim _Descripcion = _Fila.Item("NOKOPR").ToString.Trim
                    Dim _Ud = _Fila.Item("UD").ToString.Trim
                    Dim _Rtu = _Fila.Item("RLUD").ToString.Trim

                    If _Chk_Mostrar_Item Then

                        e.Graphics.DrawString(numero_(_Item, _Items.ToString.Length), Fx_Fuente(_Enum_Fuentes.Courier_New, 6, FontStyle.Regular),
                                          Brushes.Black, _xPos, _yPos + 2)

                    End If

                    _xPos += 25

                    e.Graphics.DrawString(_Codido, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, _Font), Brushes.Black, _xPos, _yPos)
                    _xPos += 100 '+ 20
                    e.Graphics.DrawString(_CodAlternativo, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, _Font), Brushes.Black, _xPos, _yPos)
                    _xPos += 100
                    e.Graphics.DrawString(_Descripcion, Fx_Fuente(_Enum_Fuentes.Courier_New, 7, _Font), Brushes.Black, _xPos, _yPos)
                    _xPos += 310
                    e.Graphics.DrawString(_Ud, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, _Font), Brushes.Black, _xPos, _yPos)
                    _xPos += 30
                    e.Graphics.DrawString(_Rtu, Fx_Fuente(_Enum_Fuentes.Courier_New, 8, _Font), Brushes.Black, _xPos, _yPos)


                    _xPos += 35
                    e.Graphics.DrawString("_____|_____ _____|_____ _____|_____", Fx_Fuente(_Enum_Fuentes.Courier_New, 8, _Font), Brushes.Black, _xPos, _yPos)

                    _yPos += 25

                    _Fila.Item("Impreso") = True
                    _Contador += 1
                    _Item += 1

                    If _Contador = _Filas_X_Documento Then
                        Exit For
                    End If

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
