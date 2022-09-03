'Imports Lib_Bakapp_VarClassFunc
Imports System.Drawing
Imports System.Drawing.Printing

Public Class Frm_02_AutoconsultaSaldo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim Suma As Double
    Dim RutCliente, NombreEmpresa As String


    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        TxtCodigo.Text = TxtCodigo.Text & "1"
    End Sub

    Private Sub Btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn2.Click
        TxtCodigo.Text = TxtCodigo.Text & "2"
    End Sub

    Private Sub Btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn3.Click
        TxtCodigo.Text = TxtCodigo.Text & "3"
    End Sub

    Private Sub Btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn4.Click
        TxtCodigo.Text = TxtCodigo.Text & "4"
    End Sub

    Private Sub Btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn5.Click
        TxtCodigo.Text = TxtCodigo.Text & "5"
    End Sub

    Private Sub Btn6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn6.Click
        TxtCodigo.Text = TxtCodigo.Text & "6"
    End Sub

    Private Sub Btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn7.Click
        TxtCodigo.Text = TxtCodigo.Text & "7"
    End Sub

    Private Sub Btn8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn8.Click
        TxtCodigo.Text = TxtCodigo.Text & "8"
    End Sub

    Private Sub Btn9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn9.Click
        TxtCodigo.Text = TxtCodigo.Text & "9"
    End Sub

    Private Sub BtnAsterisco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAsterisco.Click
        TxtCodigo.Text = TxtCodigo.Text & "*"
    End Sub

    Private Sub Btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn0.Click
        TxtCodigo.Text = TxtCodigo.Text & "0"
    End Sub

    Private Sub BtnGato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGato.Click
        TxtCodigo.Text = TxtCodigo.Text & "#"
    End Sub

    Private Sub BtnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBorrar.Click
        If Trim(TxtCodigo.Text) <> "" Then
            TxtCodigo.Text = Mid(TxtCodigo.Text, 1, Len(TxtCodigo.Text) - 1)
        End If
    End Sub

    Private Sub Frm_02_AutoconsultaSaldo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        TxtCodigo.Text = ""
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click

        If TxtCodigo.Text = "##**" Then
            Me.Close()
        End If

        Consulta_sql = My.Resources.Autoconsulta_Saldo_clientes
        Consulta_sql = Replace(Consulta_sql, "#Entidad#", TxtCodigo.Text)
        _Sql.Ej_consulta_IDU(Consulta_sql)

        RutCliente = _Sql.Fx_Trae_Dato("MAEEN", "RTEN", "KOEN = '" & TxtCodigo.Text & "'")
        NombreEmpresa = _Sql.Fx_Trae_Dato("MAEEN", "NOKOEN", "KOEN = '" & TxtCodigo.Text & "'")


        Dim Problemas As Integer
        Problemas = _Sql.Fx_Cuenta_Registros("TblSaldoCli", "DiasDiferencia < 0 and " & vbCrLf &
                  "TIDO IN ('FCV', 'FDB', 'FDV', 'FDX', 'FDZ', 'FEV', 'FVL', 'FVT', 'FVX', 'FVZ', 'FEE', 'BLV')")

        If Problemas <= 0 Then


            Consulta_sql = "select * from TblSaldoCli " & vbCrLf &
                           "Where TIDO = 'NCV' and  Saldo2 > Saldo1 or TIDO IN  ('BLV','FCV') and  Saldo2 < Saldo1" & vbCrLf &
                           "Order by FEEMDO"

            Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            If _Tbl.Rows.Count > 0 Then
                Suma = Fx_Suma_cantidades("Saldo3", "TblSaldoCli")

                Dim printDoc As New PrintDocument
                ' asignamos el método de evento para cada página a imprimir
                AddHandler printDoc.PrintPage, AddressOf print_PrintPage
                ' indicamos que queremos imprimir
                Dim Imp As String
                'Imp = trae_datoAccess(tb, "Impresora", "Tmp_Conf_Local", "Modulo = 'Autoconsulta'")

                printDoc.PrinterSettings.PrinterName = Imp
                printDoc.Print()
            Else
                MsgBox("No existen datos que mostrar", MsgBoxStyle.Information, "Auto consulta")
            End If

        Else

            MsgBox("Estimado cliente, usted tiene documentos vencidos" & vbCrLf &
                   "Favor dirigirse a Servicio al cliente", MsgBoxStyle.Critical, "¡Deuda vencida!")
            TxtCodigo.Focus()
            TxtCodigo.SelectAll()
        End If

    End Sub

    Private Sub print_PrintPage(ByVal sender As Object,
                                ByVal e As PrintPageEventArgs)
        ' Este evento se producirá cada vez que se imprima una nueva página
        ' imprimir HOLA MUNDO en Arial tamaño 24 y negrita


        Dim bm As Bitmap = Nothing
        Dim CodBarras As New PictureBox
        Dim Imagen As New PictureBox

        'Imagen.Image = New System.Drawing.Bitmap(UbicImagen)

        ' imprimimos la cadena en el margen izquierdo
        Dim xPos As Single = 3 'e.MarginBounds.Left
        ' La fuente a usar



        Dim DtFont As New Font("Arial", 5, FontStyle.Regular)
        Dim prFont As New Font("Arial", 5, FontStyle.Bold)
        Dim FontNro As New Font("Times New Roman", 10, FontStyle.Bold)
        Dim FontCon As New Font("Times New Roman", 10, FontStyle.Bold)
        ' la posición superior
        Dim yPos As Single = prFont.GetHeight(e.Graphics) - 10

        'tb = TablaOrigen 'DirectCast(Grilla.DataSource, DataTable)

        'Encabezado

        'Imagen.Image = New System.Drawing.Bitmap("D:\Empresas\Ferreteria San Francisco\LogoFerreteria2.jpg")
        'e.Graphics.DrawImage(Imagen.Image, xPos + 30, yPos)
        yPos = yPos + 10

        Dim Rt(1) As String
        Rt = Split(RutEmpresa, "-")
        Dim Rut As String = Format(De_Txt_a_Num_01(Rt(0), 0), "###,###")
        Rut = Rut & "-" & Rt(1)

        e.Graphics.DrawString(RazonEmpresa, prFont, Brushes.Black, xPos, yPos)
        yPos = yPos + 10
        e.Graphics.DrawString("Rut: " & Rut, prFont, Brushes.Black, xPos, yPos)
        yPos = yPos + 10
        e.Graphics.DrawString("_____________________________________________", DtFont, Brushes.Black, xPos, yPos)
        yPos = yPos + 15
        'RutCliente

        e.Graphics.DrawString(NombreEmpresa, prFont, Brushes.Black, xPos, yPos)
        yPos = yPos + 10

        Rut = Format(De_Txt_a_Num_01(RutCliente, 0), "###,###")
        Rut = Rut & "-" & RutDigito(RutCliente)

        e.Graphics.DrawString("Rut: " & Rut, prFont, Brushes.Black, xPos, yPos)
        yPos = yPos + 10

        e.Graphics.DrawString("Saldo de cliente al: " & FormatDateTime(Date.Now, DateFormat.ShortDate), prFont, Brushes.Black, xPos, yPos)
        yPos = yPos + 14

        e.Graphics.DrawString("Tipo", prFont, Brushes.Black, xPos, yPos)
        e.Graphics.DrawString("Número", prFont, Brushes.Black, xPos + 20, yPos)
        e.Graphics.DrawString("Fecha", prFont, Brushes.Black, xPos + 60, yPos)
        e.Graphics.DrawString("Días", prFont, Brushes.Black, xPos + 100, yPos)
        e.Graphics.DrawString("Rest.", prFont, Brushes.Black, xPos + 100, yPos + 10)
        e.Graphics.DrawString("Saldo", prFont, Brushes.Black, xPos + 140, yPos)
        yPos = yPos + 10

        e.Graphics.DrawString("_____________________________________________", DtFont, Brushes.Black, xPos, yPos)
        yPos = yPos + 15
        '------------------------


        Dim Fila As DataRow
        Dim Tido, Nudo, FechaEmision, FechaVencimiento, NroVencimientos As String
        Dim DiasAtraso, ValorDocumento, Saldo, Largo As Double



        Dim Codigo, Desc1, Desc2, Cantidades As String
        Dim Cantidad, Precio, Total As String

        Dim Valor As String
        Dim Caracter As String

        Dim tb As DataTable

        If tb.Rows.Count > 0 Then
            ' imprimimos la cadena
            For i = 0 To tb.Rows.Count - 1

                Fila = tb.Rows(i)

                Tido = Fila.Item("TIDO").ToString
                Nudo = Fila.Item("NUDO").ToString
                FechaEmision = Mid(Fila.Item("FEEMDO").ToString, 1, 10)
                FechaVencimiento = Mid(Fila.Item("FEULVEDO").ToString, 1, 10)
                DiasAtraso = Fila.Item("DiasDiferencia").ToString
                NroVencimientos = Fila.Item("NUVEDO").ToString
                ValorDocumento = Fila.Item("Saldo1").ToString
                Saldo = Fila.Item("Saldo3").ToString

                e.Graphics.DrawString(Tido, DtFont, Brushes.Black, xPos, yPos)
                e.Graphics.DrawString(Nudo, DtFont, Brushes.Black, xPos + 15, yPos)
                e.Graphics.DrawString(FechaVencimiento, DtFont, Brushes.Black, xPos + 60, yPos)

                If DiasAtraso < 0 Then
                    DiasAtraso = DiasAtraso * -1 : Caracter = " -" : Largo = 5 : Valor = Format(DiasAtraso, "###,###")
                    Valor = Caracter + Valor.PadLeft(Largo - Len(Valor), " ")
                Else
                    Caracter = " " : Largo = 6 : Valor = Format(DiasAtraso, "###,###")
                    Valor = Caracter + Valor.PadLeft(Largo - Len(Valor), " ")
                End If

                e.Graphics.DrawString(Valor, DtFont, Brushes.Black, xPos + 100, yPos)

                If Saldo < 0 Then
                    Saldo = Saldo * -1 : Caracter = "$ -" : Largo = 18
                Else
                    Caracter = "$" : Largo = 20
                End If

                Valor = Format(Saldo, "###,###")
                Valor = Caracter + Valor.PadLeft(Largo - Len(Valor), " ")
                e.Graphics.DrawString(Valor, DtFont, Brushes.Black, xPos + 130, yPos)


                yPos = yPos + 10

            Next
        End If
        e.Graphics.DrawString("_____________________________________________", DtFont, Brushes.Black, xPos, yPos)
        yPos = yPos + 15
        e.Graphics.DrawString("Deuda Total", FontNro, Brushes.Black, xPos, yPos)

        Valor = Format(Suma, "###,###")
        Valor = "$" + Valor.PadLeft(20 - Len(Valor), " ")
        e.Graphics.DrawString(Valor, FontNro, Brushes.Black, xPos + 100, yPos)

        'e.Graphics.DrawString(sb.ToString, printFont, Brushes.Black, leftMargin, yPos)

        ' indicamos que ya no hay nada más que imprimir
        ' (el valor predeterminado de esta propiedad es False)
        e.HasMorePages = False

    End Sub


    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Frm_03_AutoconsultaSaldo As New Frm_03_AutoconsultaSaldo
        Frm_03_AutoconsultaSaldo.Show()
    End Sub
End Class