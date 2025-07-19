Imports System.Drawing.Printing
Imports DevComponents.DotNetBar

Public Class Clas_Imprimir_Despacho

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _PrtSettings As New PrinterSettings

    Dim _Cl_Despacho As Clas_Despacho

    Enum Enum_Tamano
        Carta
        Vale
    End Enum

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

    Public Property Cl_Despacho As Clas_Despacho
        Get
            Return _Cl_Despacho
        End Get
        Set(value As Clas_Despacho)
            _Cl_Despacho = value
        End Set
    End Property

#End Region

    Public Sub New(Cl_Despacho As Clas_Despacho)
        _Cl_Despacho = Cl_Despacho
    End Sub

    Public Function Fx_Imprimir_Archivo_Tam_Carta(_Formulario As Form,
                                                  _Nombre_documento As String,
                                                  _Impresora As String,
                                                  _Tamano As Enum_Tamano,
                                                  _Copias As Integer)

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

            Dim _TamañoPersonal As Printing.PaperSize '(PaperKind.Legal, 850, 1400)

            If _Tamano = Enum_Tamano.Carta Then
                _TamañoPersonal = New Printing.PaperSize(PaperKind.Legal, 850, 1400)
                AddHandler printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Letrero_Carta
            End If

            If _Tamano = Enum_Tamano.Vale Then

                Dim _Observaciones As String = _Cl_Despacho.Row_Despacho.Item("Observaciones")
                Dim _Largo = 0
                If Not String.IsNullOrEmpty(_Observaciones.ToString.Trim) Then _Largo = 150

                _TamañoPersonal = New Printing.PaperSize(PaperKind.Legal, 295, 550 + _Largo)
                AddHandler printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Letrero_Vale

            End If


            'Dim PageSetupDialog1 As New PageSetupDialog

            'PageSetupDialog1.Document = printDoc
            'PageSetupDialog1.PageSettings.Landscape = False

            'PageSetupDialog1.PageSettings.PaperSize = pkCustomSize1
            'PageSetupDialog1.PageSettings.Margins.Left = 2
            'PageSetupDialog1.PageSettings.Margins.Right = 2

            'PageSetupDialog1.ShowDialog()

            'Dim PageSetupDialog1 As New PageSetupDialog

            'PageSetupDialog1.Document = printDoc
            'PageSetupDialog1.PageSettings.Landscape = False
            'PageSetupDialog1.PageSettings.PaperSize = pkCustomSize1

            ' asignamos el método de evento para cada página a imprimir

            'AddHandler printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Letrero_Carta

            ' indicamos que queremos imprimir

            printDoc.DefaultPageSettings.PaperSize = _TamañoPersonal

            printDoc.DocumentName = _Nombre_documento

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

            For i = 1 To _Copias
                printDoc.Print()
            Next

            Return True
        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub Sb_Print_PrintPage_Letrero_Carta(ByVal sender As Object, ByVal e As PrintPageEventArgs)

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

            Dim _Font_C8 As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold)
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

            e.Graphics.DrawString(StrDup(200, "_"), _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            e.Graphics.DrawString("DESTINATARIO", Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 16, FontStyle.Bold),
                                  Brushes.Black, _xPos, _yPos)
            _yPos += 30

            e.Graphics.DrawString(StrDup(100, "_"), _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            Dim _Nokoen = _Cl_Despacho.Row_Entidad.Item("NOKOEN")
            e.Graphics.DrawString("NOMBRE         : " & _Nokoen, _Font_C12, Brushes.Black, _xPos, _yPos)

            _yPos += 30

            Dim _Rut = _Cl_Despacho.Row_Despacho.Item("Rut")
            e.Graphics.DrawString("RUT            : " & _Rut, _Font_C12, Brushes.Black, _xPos, _yPos)

            Dim _CodBarras_Nro_Orden, _CodBarras_Nro_Sub, _CodBarras_Orden_Sub As New PictureBox

            _CodBarras_Nro_Orden = Fx_Codigo_Barras(_Cl_Despacho.Nro_Despacho)
            _CodBarras_Nro_Sub = Fx_Codigo_Barras(_Cl_Despacho.Nro_Sub)
            _CodBarras_Orden_Sub = Fx_Codigo_Barras(_Cl_Despacho.Nro_Despacho & "-" & _Cl_Despacho.Nro_Sub)

            e.Graphics.DrawImage(_CodBarras_Orden_Sub.Image, _xPos + 500, _yPos, 300, 60)

            _yPos += 30

            Dim _Nro_Sub = _Cl_Despacho.Row_Despacho.Item("Nro_Sub")
            e.Graphics.DrawString("ORDEN DESPACHO : " & _Cl_Despacho.Nro_Despacho & ", Sub-OD: " & _Nro_Sub, _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            Dim _Contador = 0
            Dim _Documentos As String

            For Each _Fila As DataRow In _Cl_Despacho.Tbl_Despacho_Doc.Rows

                Dim _Idmaeedo = _Fila.Item("Idrst")
                Dim _Vabrdo As Double = _Sql.Fx_Trae_Dato("MAEEDO", "VABRDO", "IDMAEEDO = " & _Idmaeedo)

                _Documentos += _Fila.Item("Tido") & "-" & _Fila.Item("Nudo") & " (" & FormatCurrency(_Vabrdo, 0) & ")"
                _Contador += 1

                If _Contador <> _Cl_Despacho.Tbl_Despacho_Doc.Rows.Count Then
                    _Documentos += ", "
                End If

            Next

            e.Graphics.DrawString("DOCUMENTOS     : " & _Documentos, _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            e.Graphics.DrawString(StrDup(200, "_"), _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            Dim _Nom_Tipo_Envio = _Cl_Despacho.Row_Despacho.Item("Nom_Tipo_Envio")

            e.Graphics.DrawString("TIPO           : " & _Nom_Tipo_Envio, _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            Dim _Direccion = _Cl_Despacho.Row_Despacho.Item("Direccion")

            e.Graphics.DrawString("DIRECCION      : " & _Direccion, _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            Dim _Comuna = _Cl_Despacho.Row_Despacho.Item("Comuna")

            e.Graphics.DrawString("COMUNA         : " & _Comuna, _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            Dim _Telefono = _Cl_Despacho.Row_Despacho.Item("Telefono")

            e.Graphics.DrawString("TELEFONO       : " & _Telefono, _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            Dim _Transportista = _Cl_Despacho.Row_Despacho.Item("Nombre_Transportista").ToString.Trim
            Dim _Transpor_Por_Pagar = _Cl_Despacho.Row_Despacho.Item("Transpor_Por_Pagar")

            If _Transpor_Por_Pagar Then
                _Transportista = _Transportista.ToString.Trim & " (POR PAGAR)"
            End If

            e.Graphics.DrawString("ENCOMIENDA     : " & _Transportista, _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            Dim _Email = _Cl_Despacho.Row_Despacho.Item("Email")

            e.Graphics.DrawString("EMAIL          : " & _Email, _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 30


            Dim _Observaciones As String = _Cl_Despacho.Row_Despacho.Item("Observaciones")
            Dim _Obs1, _Obs2, _Obs3, _Obs4, _Obs5, _Obs6 As String
            Dim _Desde As Integer

            _Obs1 = Mid(_Observaciones, 1, 50)
            _Obs2 = Mid(_Observaciones, 51, 50)
            _Obs3 = Mid(_Observaciones, 101, 50)
            _Obs4 = Mid(_Observaciones, 151, 50)
            _Obs5 = Mid(_Observaciones, 201, 50)
            _Obs6 = Mid(_Observaciones, 251, 50)

            _Desde = 1 : If _Obs1.Length > _Desde Then _Desde = _Obs1.Length
            If Not String.IsNullOrEmpty(Mid(_Obs1, _Desde, 1)) And Not String.IsNullOrEmpty(Mid(_Obs2, 1, 1)) Then _Obs1 += "_"

            _Desde = 1 : If _Obs2.Length > _Desde Then _Desde = _Obs2.Length
            If Not String.IsNullOrEmpty(Mid(_Obs2, _Desde, 1)) And Not String.IsNullOrEmpty(Mid(_Obs3, 1, 1)) Then _Obs2 += "_"

            _Desde = 1 : If _Obs3.Length > _Desde Then _Desde = _Obs3.Length
            If Not String.IsNullOrEmpty(Mid(_Obs3, _Desde, 1)) And Not String.IsNullOrEmpty(Mid(_Obs4, 1, 1)) Then _Obs3 += "_"

            _Desde = 1 : If _Obs4.Length > _Desde Then _Desde = _Obs4.Length
            If Not String.IsNullOrEmpty(Mid(_Obs4, _Desde, 1)) And Not String.IsNullOrEmpty(Mid(_Obs2, 1, 1)) Then _Obs4 += "_"

            _Desde = 1 : If _Obs5.Length > _Desde Then _Desde = _Obs5.Length
            If Not String.IsNullOrEmpty(Mid(_Obs5, _Desde, 1)) And Not String.IsNullOrEmpty(Mid(_Obs3, 1, 1)) Then _Obs5 += "_"

            _Desde = 1 : If _Obs6.Length > _Desde Then _Desde = _Obs6.Length
            If Not String.IsNullOrEmpty(Mid(_Obs6, _Desde, 1)) And Not String.IsNullOrEmpty(Mid(_Obs4, 1, 1)) Then _Obs6 += "_"

            e.Graphics.DrawString("OBSERVACIONES  : " & _Obs1.Trim, _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 20

            e.Graphics.DrawString("                 " & _Obs2.Trim, _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 20

            e.Graphics.DrawString("                 " & _Obs3.Trim, _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 20

            e.Graphics.DrawString("                 " & _Obs4.Trim, _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 20

            e.Graphics.DrawString("                 " & _Obs5.Trim, _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 20

            e.Graphics.DrawString("                 " & _Obs6.Trim, _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 20


            e.Graphics.DrawString(StrDup(200, "_"), _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            e.Graphics.DrawString("REMITENTE", Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 12, FontStyle.Bold),
                                  Brushes.Black, _xPos, _yPos)

            e.Graphics.DrawString(StrDup(200, "_"), _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            Consulta_sql = "Select * From MAEEN Where KOEN = '" & RutEmpresa & "' And SUEN = '" & Mod_Sucursal & "'"
            Dim _Row_Empresa As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

            Dim _Nokoen_Emp As String = RazonEmpresa
            Dim _Rut_Emp As String = RutEmpresa
            Dim _Direccion_Emp As String = DireccionEmpresa
            Dim _Telefono_Emp As String = _Global_Row_Configp.Item("TELEFONOS").ToString.Trim
            Dim _Emailcomer_Emp As String

            If Not IsNothing(_Row_Empresa) Then
                _Direccion_Emp = _Row_Empresa.Item("DIEN").ToString.Trim
                _Telefono_Emp = _Row_Empresa.Item("FOEN").ToString.Trim
                _Emailcomer_Emp = _Row_Empresa.Item("EMAILCOMER").ToString.Trim
            End If

            e.Graphics.DrawString("NOMBRE      : " & _Nokoen_Emp, _Font_C10,
                                  Brushes.Black, _xPos, _yPos)
            _yPos += 15
            e.Graphics.DrawString("RUT         : " & _Rut_Emp, _Font_C10,
                                  Brushes.Black, _xPos, _yPos)
            _yPos += 15
            e.Graphics.DrawString("DIRECCION   : " & _Direccion_Emp, _Font_C10,
                                  Brushes.Black, _xPos, _yPos)
            _yPos += 15
            e.Graphics.DrawString("TELEFONO    : " & _Telefono_Emp, _Font_C10,
                                  Brushes.Black, _xPos, _yPos)
            _yPos += 15
            e.Graphics.DrawString("EMAIL       : " & _Emailcomer_Emp, _Font_C10,
                                  Brushes.Black, _xPos, _yPos)
            _yPos += 15

            e.Graphics.DrawString(StrDup(200, "_"), _Font_C12, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            e.HasMorePages = False

        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub

    Private Sub Sb_Print_PrintPage_Letrero_Vale(ByVal sender As Object, ByVal e As PrintPageEventArgs)

        Try

            ' imprimimos la cadena en el margen izquierdo
            Dim _xPos As Single = 3 'e.MarginBounds.Left
            ' La fuente a usar


            ' la posición superior
            Dim _yPos As Single = prFont.GetHeight(e.Graphics) - 10

            _xPos = 5
            _yPos += 5

            Dim _Font_Enc_1 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 14, FontStyle.Bold)
            Dim _Font_Enc_2 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 12, FontStyle.Regular)
            Dim _Font_Enc_3 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 10, FontStyle.Regular)
            Dim _Font_Enc_4 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 8, FontStyle.Regular)

            Dim _Font_C8_R As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular)
            Dim _Font_C9_R As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 9, FontStyle.Regular)
            Dim _Font_C10_R As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 10, FontStyle.Regular)
            Dim _Font_C12_R As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 12, FontStyle.Regular)

            Dim _Font_C8_N As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold)
            Dim _Font_C9_N As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 9, FontStyle.Bold)
            Dim _Font_C10_N As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 10, FontStyle.Bold)
            Dim _Font_C12_N As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 12, FontStyle.Bold)

            Dim _Font_Detalle_1 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 6, FontStyle.Regular)
            Dim _Font_Detalle_2 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 8, FontStyle.Regular)
            Dim _Font_Detalle_3 As Font = Fx_Fuente(_Enum_Fuentes.Arial, 8, FontStyle.Regular)

            Dim _Font_Detalle_Curr_1_R As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 6, FontStyle.Regular)
            Dim _Font_Detalle_Curr_2_R As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular)

            Dim _Font_Detalle_Curr_1_B As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 6, FontStyle.Bold)
            Dim _Font_Detalle_Curr_2_B As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold)

            e.Graphics.DrawString(StrDup(30, "_"), _Font_C12_R, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            e.Graphics.DrawString("DESTINATARIO", _Font_C12_N, Brushes.Black, _xPos, _yPos)
            _yPos += 15

            e.Graphics.DrawString(StrDup(30, "_"), _Font_C12_R, Brushes.Black, _xPos, _yPos)
            _yPos += 25

            Dim _Nokoen = _Cl_Despacho.Row_Entidad.Item("NOKOEN")
            e.Graphics.DrawString("NOMBRE      : " & _Nokoen, _Font_C8_R, Brushes.Black, _xPos, _yPos)
            _yPos += 15

            Dim _Rut = _Cl_Despacho.Row_Despacho.Item("Rut")
            e.Graphics.DrawString("RUT         : " & _Rut, _Font_C8_R, Brushes.Black, _xPos, _yPos)
            _yPos += 15

            Dim _Nro_Sub = _Cl_Despacho.Row_Despacho.Item("Nro_Sub")
            e.Graphics.DrawString("NRO ORDEN   : " & _Cl_Despacho.Nro_Despacho & ", Sub-OD: " & _Nro_Sub, _Font_C8_R, Brushes.Black, _xPos, _yPos)
            _yPos += 15

            Dim _Contador = 0
            Dim _Documentos As String

            For Each _Fila As DataRow In _Cl_Despacho.Tbl_Despacho_Doc.Rows

                Dim _Idmaeedo = _Fila.Item("Idrst")
                Dim _Vabrdo As Double = _Sql.Fx_Trae_Dato("MAEEDO", "VABRDO", "IDMAEEDO = " & _Idmaeedo)

                _Documentos = _Fila.Item("Tido") & "-" & _Fila.Item("Nudo") & " (" & FormatCurrency(_Vabrdo, 0) & ")"

                e.Graphics.DrawString("DOCUMENTOS  : " & _Documentos, _Font_C8_R, Brushes.Black, _xPos, _yPos)
                _yPos += 15

            Next

            _yPos += 5
            e.Graphics.DrawString(StrDup(30, "_"), _Font_C12_R, Brushes.Black, _xPos, _yPos)
            _yPos += 25

            Dim _Nom_Tipo_Envio = _Cl_Despacho.Row_Despacho.Item("Nom_Tipo_Envio")

            e.Graphics.DrawString("TIPO        : " & _Nom_Tipo_Envio, _Font_C8_R, Brushes.Black, _xPos, _yPos)
            _yPos += 15

            Dim _Direccion As String = _Cl_Despacho.Row_Despacho.Item("Direccion")
            Dim _Dir1 As String = Mid(_Direccion, 1, 25)
            Dim _Dir2 As String = Mid(_Direccion, 26, 50).Trim

            e.Graphics.DrawString("DIRECCION   : " & _Dir1, _Font_C8_R, Brushes.Black, _xPos, _yPos)
            _yPos += 15
            e.Graphics.DrawString("              " & _Dir2, _Font_C8_R, Brushes.Black, _xPos, _yPos)
            _yPos += 15

            Dim _Comuna = _Cl_Despacho.Row_Despacho.Item("Comuna")

            e.Graphics.DrawString("COMUNA      : " & _Comuna, _Font_C8_R, Brushes.Black, _xPos, _yPos)
            _yPos += 15

            Dim _Telefono = _Cl_Despacho.Row_Despacho.Item("Telefono")

            e.Graphics.DrawString("TELEFONO    : " & _Telefono, _Font_C8_R, Brushes.Black, _xPos, _yPos)
            _yPos += 15

            Dim _Transportista = _Cl_Despacho.Row_Despacho.Item("Nombre_Transportista").ToString.Trim
            Dim _Transpor_Por_Pagar = _Cl_Despacho.Row_Despacho.Item("Transpor_Por_Pagar")

            If _Transpor_Por_Pagar Then
                _Transportista = _Transportista.ToString.Trim & " (POR PAGAR)"
            End If

            e.Graphics.DrawString("ENCOMIENDA  : " & _Transportista, _Font_C8_R, Brushes.Black, _xPos, _yPos)
            _yPos += 15

            Dim _Email = _Cl_Despacho.Row_Despacho.Item("Email")

            e.Graphics.DrawString("EMAIL       : " & _Email, _Font_C8_R, Brushes.Black, _xPos, _yPos)
            _yPos += 15

            Dim _Observaciones As String = _Cl_Despacho.Row_Despacho.Item("Observaciones")
            Dim _Obs1, _Obs2, _Obs3, _Obs4, _Obs5, _Obs6 As String
            Dim _Desde As Integer

            If Not String.IsNullOrEmpty(_Observaciones.ToString.Trim) Then

                _Obs1 = Mid(_Observaciones, 1, 40)
                _Obs2 = Mid(_Observaciones, 41, 40)
                _Obs3 = Mid(_Observaciones, 81, 40)
                _Obs4 = Mid(_Observaciones, 121, 40)
                _Obs5 = Mid(_Observaciones, 161, 40)
                _Obs6 = Mid(_Observaciones, 201, 40)

                _Desde = 1 : If _Obs1.Length > _Desde Then _Desde = _Obs1.Length
                If Not String.IsNullOrEmpty(Mid(_Obs1, _Desde, 1)) And Not String.IsNullOrEmpty(Mid(_Obs2, 1, 1)) Then _Obs1 += "_"

                _Desde = 1 : If _Obs2.Length > _Desde Then _Desde = _Obs2.Length
                If Not String.IsNullOrEmpty(Mid(_Obs2, _Desde, 1)) And Not String.IsNullOrEmpty(Mid(_Obs3, 1, 1)) Then _Obs2 += "_"

                _Desde = 1 : If _Obs3.Length > _Desde Then _Desde = _Obs3.Length
                If Not String.IsNullOrEmpty(Mid(_Obs3, _Desde, 1)) And Not String.IsNullOrEmpty(Mid(_Obs4, 1, 1)) Then _Obs3 += "_"

                _Desde = 1 : If _Obs4.Length > _Desde Then _Desde = _Obs4.Length
                If Not String.IsNullOrEmpty(Mid(_Obs4, _Desde, 1)) And Not String.IsNullOrEmpty(Mid(_Obs2, 1, 1)) Then _Obs4 += "_"

                _Desde = 1 : If _Obs5.Length > _Desde Then _Desde = _Obs5.Length
                If Not String.IsNullOrEmpty(Mid(_Obs5, _Desde, 1)) And Not String.IsNullOrEmpty(Mid(_Obs3, 1, 1)) Then _Obs5 += "_"

                _Desde = 1 : If _Obs6.Length > _Desde Then _Desde = _Obs6.Length

                e.Graphics.DrawString("OBSERVACIONES  : ", _Font_C8_R, Brushes.Black, _xPos, _yPos)
                _yPos += 15

                e.Graphics.DrawString(_Obs1.Trim, _Font_C8_R, Brushes.Black, _xPos, _yPos)
                _yPos += 15

                e.Graphics.DrawString(_Obs2.Trim, _Font_C8_R, Brushes.Black, _xPos, _yPos)
                _yPos += 15

                e.Graphics.DrawString(_Obs3.Trim, _Font_C8_R, Brushes.Black, _xPos, _yPos)
                _yPos += 15

                e.Graphics.DrawString(_Obs4.Trim, _Font_C8_R, Brushes.Black, _xPos, _yPos)
                _yPos += 15

                e.Graphics.DrawString(_Obs5.Trim, _Font_C8_R, Brushes.Black, _xPos, _yPos)
                _yPos += 15

                e.Graphics.DrawString(_Obs6.Trim, _Font_C8_R, Brushes.Black, _xPos, _yPos)
                _yPos += 30

            End If

            e.Graphics.DrawString(StrDup(30, "_"), _Font_C12_R, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            e.Graphics.DrawString("REMITENTE", _Font_C12_N, Brushes.Black, _xPos, _yPos)
            _yPos += 15

            e.Graphics.DrawString(StrDup(30, "_"), _Font_C12_R, Brushes.Black, _xPos, _yPos)
            _yPos += 20

            Consulta_sql = "Select * From MAEEN Where KOEN = '" & RutEmpresa & "' And TIPOSUC = 'P'"
            Dim _Row_Empresa As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

            Dim _Nokoen_Emp As String = RazonEmpresa
            Dim _Rut_Emp As String = RutEmpresa
            Dim _Direccion_Emp As String = DireccionEmpresa
            Dim _Telefono_Emp As String = _Global_Row_Configp.Item("TELEFONOS").ToString.Trim
            Dim _Emailcomer_Emp As String

            If Not IsNothing(_Row_Empresa) Then
                _Direccion_Emp = _Row_Empresa.Item("DIEN").ToString.Trim
                _Telefono_Emp = _Row_Empresa.Item("FOEN").ToString.Trim
                _Emailcomer_Emp = _Row_Empresa.Item("EMAILCOMER").ToString.Trim
            End If

            e.Graphics.DrawString("NOMBRE      : " & _Nokoen_Emp, _Font_C8_R,
                                  Brushes.Black, _xPos, _yPos)
            _yPos += 15
            e.Graphics.DrawString("RUT         : " & _Rut_Emp, _Font_C8_R,
                                  Brushes.Black, _xPos, _yPos)
            _yPos += 15
            e.Graphics.DrawString("DIRECCION   : " & _Direccion_Emp, _Font_C8_R,
                                  Brushes.Black, _xPos, _yPos)
            _yPos += 15
            e.Graphics.DrawString("TELEFONO    : " & _Telefono_Emp, _Font_C8_R,
                                  Brushes.Black, _xPos, _yPos)
            _yPos += 15
            e.Graphics.DrawString("EMAIL       : " & _Emailcomer_Emp, _Font_C8_R,
                                  Brushes.Black, _xPos, _yPos)
            _yPos += 15

            e.Graphics.DrawString(StrDup(30, "_"), _Font_C12_R, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            Dim _CodBarras_Nro_Orden, _CodBarras_Nro_Sub, _CodBarras_Orden_Sub As New PictureBox

            _CodBarras_Nro_Orden = Fx_Codigo_Barras(_Cl_Despacho.Nro_Despacho)
            _CodBarras_Nro_Sub = Fx_Codigo_Barras(_Cl_Despacho.Nro_Sub)
            _CodBarras_Orden_Sub = Fx_Codigo_Barras(_Cl_Despacho.Nro_Despacho & "-" & _Cl_Despacho.Nro_Sub)

            'e.Graphics.DrawImage(_CodBarras_Nro_Orden.Image, _xPos, _yPos, 100, 40)
            'e.Graphics.DrawImage(_CodBarras_Nro_Sub.Image, _xPos + 200, _yPos, 50, 40)

            '_yPos += 50

            e.Graphics.DrawImage(_CodBarras_Orden_Sub.Image, _xPos + 20, _yPos, 240, 40)
            _yPos += 40

            e.Graphics.DrawString(StrDup(30, "_"), _Font_C12_R, Brushes.Black, _xPos, _yPos)

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

    Sub Sb_Seleccionar_Tipo_Impresion(_Formulario As Form)

        Dim Chk_Imprimir_Carta As New Command
        Chk_Imprimir_Carta.Checked = False
        Chk_Imprimir_Carta.Name = "Chk_Imprimir_Carta"
        Chk_Imprimir_Carta.Text = "Imprimir en tamaño carta (impresora laser)"

        Dim Chk_Imprimir_Tipo_Vale As New Command
        Chk_Imprimir_Tipo_Vale.Checked = False
        Chk_Imprimir_Tipo_Vale.Name = "Chk_Imprimir_Tipo_Vale"
        Chk_Imprimir_Tipo_Vale.Text = "Imprimir en termica (impresora de vales)"

        Dim Chk_Imprimir_Zebra As New Command
        Chk_Imprimir_Zebra.Checked = False
        Chk_Imprimir_Zebra.Name = "Chk_Imprimir_Zebra"
        Chk_Imprimir_Zebra.Text = "Imprimir en etiqueta (impresora de etiquetas)"

        Dim _Clas_CliexpressAPI As New Clas_CliexpressAPI()
        Dim _Row_Envio As DataRow = _Clas_CliexpressAPI.Fx_Trae_Row_Envio(0, _Cl_Despacho.Id_Despacho)

        Dim Chk_Imprimir_Carta_Chilexpress As New Command
        Chk_Imprimir_Carta_Chilexpress.Checked = String.IsNullOrEmpty(_Clas_CliexpressAPI.NombreEtiqueta)
        Chk_Imprimir_Carta_Chilexpress.Name = "Chk_Imprimir_Carta_Chilexpress"
        Chk_Imprimir_Carta_Chilexpress.Text = "CHILEXPRESS Imprimir en tamaño carta (impresora laser)"

        Dim Chk_Imprimir_Zebra_Chilexpress As New Command
        Chk_Imprimir_Zebra_Chilexpress.Checked = Not String.IsNullOrEmpty(_Clas_CliexpressAPI.NombreEtiqueta)
        Chk_Imprimir_Zebra_Chilexpress.Name = "Chk_Imprimir_Zebra_Chilexpress"
        Chk_Imprimir_Zebra_Chilexpress.Text = "CHILEXPRESS Imprimir en etiqueta (impresora de etiquetas)"

        Dim _Opciones() As Command

        If IsNothing(_Row_Envio) Then
            Chk_Imprimir_Carta_Chilexpress.Checked = False
            Chk_Imprimir_Zebra_Chilexpress.Checked = False
            _Opciones = {Chk_Imprimir_Carta, Chk_Imprimir_Tipo_Vale, Chk_Imprimir_Zebra}
        Else
            _Opciones = {Chk_Imprimir_Carta_Chilexpress, Chk_Imprimir_Zebra_Chilexpress}
        End If

        Dim _Icono As New eTaskDialogIcon

        Dim _Info As New TaskDialogInfo("Imprimir letero",
                                        eTaskDialogIcon.BlueFlag,
                                        "Selección de tipo de letrero",
                                        "Marque su opción",
                                        eTaskDialogButton.Ok + eTaskDialogButton.Cancel _
                                        , eTaskDialogBackgroundColor.Red, _Opciones, Nothing, Nothing, Nothing, Nothing)

        Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

        If _Resultado = eTaskDialogResult.Ok Then

            Dim Fm As New Frm_Barras_ConfPuerto_OD

            Dim _Puerto = Fm.Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Puerto")
            Dim _Etiqueta = Fm.Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Etiqueta")

            Dim _Imp_Barras As Boolean = Fm.Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Imp_Barras")
            Dim _Imp_Laser As Boolean = Fm.Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Imp_Laser")
            Dim _Imp_Termica As Boolean = Fm.Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Imp_Termica")

            Dim _Copias = 1

            Dim _Aceptar As Boolean = InputBox_Bk(_Formulario, "Número de etiquetas", "Imprimir letreros",
                                                      _Copias, False, _Tipo_Mayus_Minus.Normal,, True,
                                                      _Tipo_Imagen.Barra,, _Tipo_Caracter.Solo_Numeros_Enteros, False)

            If _Aceptar Then

                If Chk_Imprimir_Carta.Checked Then

                    Fx_Imprimir_Archivo_Tam_Carta(_Formulario, "Letrero", "", Enum_Tamano.Carta, _Copias)

                End If

                If Chk_Imprimir_Tipo_Vale.Checked Then

                    Fx_Imprimir_Archivo_Tam_Carta(_Formulario, "Letrero", "", Enum_Tamano.Vale, _Copias)

                End If

                If Chk_Imprimir_Zebra.Checked Then

                    If String.IsNullOrEmpty(_Puerto) Or String.IsNullOrEmpty(_Etiqueta) Then
                        MessageBoxEx.Show(_Formulario, "Falta configuración de impresora termica", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If

                    Dim Cl_ImpBarra As New Class_Imprimir_Barras
                    For i = 1 To _Copias
                        Cl_ImpBarra.Sb_Imprimir_Orden_Despacho_Letrero(_Etiqueta, _Puerto, _Cl_Despacho.Id_Despacho)
                    Next

                End If


                'CHILEXPRESS

                If Chk_Imprimir_Carta_Chilexpress.Checked Then

                    Dim Cl_ImpBarra As New Class_Imprimir_Barras
                    For i = 1 To _Copias

                        Dim _Impresora As String
                        Dim _Clas_CliexpressAPI2 As New Clas_CliexpressAPI()
                        _Clas_CliexpressAPI2.Fx_Imprimir_Archivo(_Formulario, _Impresora, _Cl_Despacho.Id_Despacho)

                    Next

                End If

                If Chk_Imprimir_Zebra_Chilexpress.Checked Then

                    If String.IsNullOrEmpty(_Puerto) Or String.IsNullOrEmpty(_Etiqueta) Then
                        MessageBoxEx.Show(_Formulario, "Falta configuración de impresora termica", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If

                    Dim Cl_ImpBarra As New Class_Imprimir_Barras
                    For i = 1 To _Copias
                        Cl_ImpBarra.Sb_Imprimir_Etiqueta_Chilexpress(_Puerto, _Cl_Despacho.Id_Despacho)

                        If Not String.IsNullOrEmpty(Cl_ImpBarra.Error) Then
                            MessageBoxEx.Show(_Formulario, Cl_ImpBarra.Error, "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return
                        End If

                    Next

                End If

            End If

        End If

    End Sub

    Sub Sb_Imprimir_Letrero(_Formulario As Form)

        Dim Fm As New Frm_Barras_ConfPuerto_OD

        Dim _Puerto = Fm.Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Puerto")
        Dim _Etiqueta = Fm.Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Etiqueta")

        Dim _Imp_Barras As Boolean = Fm.Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Imp_Barras")
        Dim _Imp_Laser As Boolean = Fm.Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Imp_Laser")
        Dim _Imp_Termica As Boolean = Fm.Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Imp_Termica")

        Dim _Impresora As String = Fm.Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Impresora")
        Dim _Imprimir_Automaticamente As Boolean = Fm.Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Imprimir_Automaticamente")

        Dim _Clas_CliexpressAPI As New Clas_CliexpressAPI()
        Dim _Row_Envio As DataRow = _Clas_CliexpressAPI.Fx_Trae_Row_Envio(0, _Cl_Despacho.Id_Despacho_Padre)

        If Not IsNothing(_Row_Envio) Then
            _Imprimir_Automaticamente = False
        End If

        If _Imprimir_Automaticamente Then

            Dim _Copias = 1

            Dim _Aceptar As Boolean = InputBox_Bk(_Formulario, "Número de etiquetas", "Imprimir letreros",
                                                      _Copias, False, _Tipo_Mayus_Minus.Normal,, True,
                                                      _Tipo_Imagen.Barra,, _Tipo_Caracter.Solo_Numeros_Enteros, False)

            If _Aceptar Then

                If _Imp_Laser Then

                    Fx_Imprimir_Archivo_Tam_Carta(_Formulario, "Letrero", _Impresora, Enum_Tamano.Carta, _Copias)

                End If

                If _Imp_Termica Then

                    Fx_Imprimir_Archivo_Tam_Carta(_Formulario, "Letrero", _Impresora, Enum_Tamano.Vale, _Copias)

                End If

                If _Imp_Barras Then

                    If String.IsNullOrEmpty(_Puerto) Or String.IsNullOrEmpty(_Etiqueta) Then
                        MessageBoxEx.Show(_Formulario, "Falta configuración de impresora termica" & vbCrLf &
                                      "Debe ir a configuración en el menu de DESPACHO y configurar la salida de impresión",
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If

                    Dim Cl_ImpBarra As New Class_Imprimir_Barras
                    For I = 1 To _Copias
                        Cl_ImpBarra.Sb_Imprimir_Orden_Despacho_Letrero(_Etiqueta, _Puerto, _Cl_Despacho.Id_Despacho)
                    Next
                End If

            End If

        Else
            Sb_Seleccionar_Tipo_Impresion(_Formulario)
        End If

    End Sub

End Class
