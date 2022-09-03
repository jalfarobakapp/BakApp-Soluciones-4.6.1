Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing

Public Class Clas_Imprimir_Voucher

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Empresa, _Sucursal, _Bodega As String
    Dim _TblProductos As DataTable

    Dim _Voucher_Impreso As Boolean

    Dim _Filas_X_Documento As Integer

    Dim _Item = 1

    Dim _Row_Configp As DataRow

    Dim _Fecha_Cierre As Date
    Dim _NombreEquipo As String

    Dim _printDoc As New PrintDocument
    Dim _PrtSettings As New PrinterSettings
    Dim _Impresora As String

    Dim _Voucher_a_imprimir(1) As String

    Dim _Row_Terminal_Transbank As DataRow

    Public Property Pro_PrtSettings() As PrinterSettings
        Get
            Return _PrtSettings
        End Get
        Set(ByVal value As PrinterSettings)
            _PrtSettings = value
        End Set
    End Property
    Public Property Pro_Filas_X_Documento() As Integer
        Get
            Return _Filas_X_Documento
        End Get
        Set(ByVal value As Integer)
            _Filas_X_Documento = value
        End Set
    End Property

    Public Property Pro_Row_Configp() As DataRow
        Get
            Return _Row_Configp
        End Get
        Set(ByVal value As DataRow)
            _Row_Configp = value
        End Set
    End Property

    Public Property Pro_Impresora() As String
        Get
            Return _Impresora
        End Get
        Set(ByVal value As String)
            _Impresora = value
        End Set
    End Property

    Public Sub New()

        Dim _FechaCierre As String = Format(_Fecha_Cierre, "yyyyMMdd")

        Consulta_sql = "Select Top 1 * From CONFIGP Where EMPRESA = '" & ModEmpresa & "'"
        _Row_Configp = _Sql.Fx_Get_DataRow(Consulta_sql)

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Estaciones_CashDro" & vbCrLf &
                       "Where NombreEquipo = '" & _NombreEquipo & "'"
        _Row_Terminal_Transbank = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Public Function Fx_Imprimir_Voucher(ByVal _Formulario As Form,
                                        ByVal _Idmaeedo As Integer,
                                        ByVal _Impresora_Sel As String) As Boolean

        Try

            ' ejemplo simple para imprimir en .NET
            ' Usamos una clase del tipo _printDocument

            _Impresora = _Impresora_Sel

            _printDoc = New PrintDocument

            Dim _Doc_AnchoDoc As Integer = 7.5 * 38.5 '39 '38.5
            Dim _Doc_LargoDoc As Integer = 8 * 38.5 '42 '41.5
            Dim _Item As Integer = 1

            ' asignamos el método de evento para cada página a imprimir

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_CashDro_Transbank_Log" & vbCrLf &
                           "Where Idmaeedo_Referencia = " & _Idmaeedo & " And Voucher <> ''"

            Dim _Row_Log_Transaccion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row_Log_Transaccion) Then
                Return False
            End If

            Dim _Voucher As String = _Row_Log_Transaccion.Item("Voucher")

            If String.IsNullOrEmpty(_Voucher) Then
                Return False
            End If

            Dim _Datos_Voucher = Split(_Voucher, "|")

            Dim _Filas As Integer = _Voucher.Length / 40

            ReDim Preserve _Voucher_a_imprimir(_Filas)
            Dim _Posicion As Integer = 1

            For i = 0 To _Filas
                _Voucher_a_imprimir(i) = Mid(_Voucher, _Posicion, 40)
                _Posicion += 40
            Next i

            AddHandler _printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Voucher

            _Doc_LargoDoc = (_Filas + 15) * 12

            ' indicamos que queremos imprimir

            _printDoc.DocumentName = "Voucher" '_Nombre_documento

            'If String.IsNullOrEmpty(_Impresora) Then
            Fx_seleccionar_Impresora(_Impresora)
            'End If

            If Not String.IsNullOrEmpty(_Impresora) Then

                _printDoc.PrinterSettings = _PrtSettings
                Dim _TamañoPersonal = New Printing.PaperSize("Personalizado", _Doc_AnchoDoc, _Doc_LargoDoc)
                _printDoc.PrinterSettings.DefaultPageSettings.PaperSize = _TamañoPersonal

                _printDoc.Print()
                _printDoc.Dispose()

                Return True

            End If

        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function Fx_Imprimir_Voucher2(ByVal _Formulario As Form,
                                         ByVal _Voucher As String,
                                         ByVal _Impresora As String) As Boolean

        Try

            ' ejemplo simple para imprimir en .NET
            ' Usamos una clase del tipo _printDocument

            '_Impresora = _Impresora_Sel

            _printDoc = New PrintDocument

            Dim _Doc_AnchoDoc As Integer = 7.5 * 38.5 '39 '38.5
            Dim _Doc_LargoDoc As Integer = 8 * 38.5 '42 '41.5
            Dim _Item As Integer = 1

            ' asignamos el método de evento para cada página a imprimir

            If String.IsNullOrEmpty(_Voucher) Then
                Return False
            End If

            Dim _Datos_Voucher = Split(_Voucher, "|")

            Dim _Filas As Integer = _Voucher.Length / 40

            ReDim Preserve _Voucher_a_imprimir(_Filas)
            Dim _Posicion As Integer = 1

            For i = 0 To _Filas
                _Voucher_a_imprimir(i) = Mid(_Voucher, _Posicion, 40)
                _Posicion += 40
            Next i

            AddHandler _printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Voucher

            _Doc_LargoDoc = (_Filas + 5) * 12

            ' indicamos que queremos imprimir

            _printDoc.DocumentName = "Voucher" '_Nombre_documento

            'If String.IsNullOrEmpty(_Impresora) Then
            Fx_seleccionar_Impresora(_Impresora)
            'End If

            If Not String.IsNullOrEmpty(_Impresora) Then

                _printDoc.PrinterSettings = _PrtSettings
                Dim _TamañoPersonal = New Printing.PaperSize("Personalizado", _Doc_AnchoDoc, _Doc_LargoDoc)
                _printDoc.PrinterSettings.DefaultPageSettings.PaperSize = _TamañoPersonal

                _printDoc.Print()
                _printDoc.Dispose()

                Return True

            End If

        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function Fx_Imprimir_Voucher_Cierre(ByVal _Formulario As Form,
                                               ByVal _IdCierre As Integer) As Boolean

        Try

            ' ejemplo simple para imprimir en .NET
            ' Usamos una clase del tipo _printDocument

            '_Impresora = _Impresora_Sel

            _printDoc = New PrintDocument

            Dim _Doc_AnchoDoc As Integer = 7.5 * 38.5 '39 '38.5
            Dim _Doc_LargoDoc As Integer = 8 * 38.5 '42 '41.5
            Dim _Item As Integer = 1

            ' asignamos el método de evento para cada página a imprimir

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_CashDro_Transbank_Cierre" & vbCrLf &
                           "Where Id = " & _IdCierre & ""

            Dim _Row_Log_Transaccion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row_Log_Transaccion) Then
                Return False
            End If

            'Dim _Voucher As String = _Row_Log_Transaccion.Item("Detalle")

            Dim _Respuesta_Transbank = Split(_Row_Log_Transaccion("Respuesta_Transbank"), "|")
            Dim _Voucher As String = _Respuesta_Transbank(4)

            If String.IsNullOrEmpty(_Voucher) Then
                Return False
            End If

            Dim _Datos_Voucher = Split(_Voucher, "|")

            Dim _Filas As Integer = _Voucher.Length / 40

            ReDim Preserve _Voucher_a_imprimir(_Filas)
            Dim _Posicion As Integer = 1

            For i = 0 To _Filas
                _Voucher_a_imprimir(i) = Mid(_Voucher, _Posicion, 40)
                _Posicion += 40
            Next i

            AddHandler _printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Voucher

            _Doc_LargoDoc = (_Filas + 5) * 12

            ' indicamos que queremos imprimir

            _printDoc.DocumentName = "Voucher" '_Nombre_documento

            'If String.IsNullOrEmpty(_Impresora) Then
            Fx_seleccionar_Impresora(_Impresora)
            'End If

            If Not String.IsNullOrEmpty(_Impresora) Then

                _printDoc.PrinterSettings = _PrtSettings
                Dim _TamañoPersonal = New Printing.PaperSize("Personalizado", _Doc_AnchoDoc, _Doc_LargoDoc)
                _printDoc.PrinterSettings.DefaultPageSettings.PaperSize = _TamañoPersonal

                _printDoc.Print()
                _printDoc.Dispose()

                Return True

            End If

        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function Fx_seleccionar_Impresora(ByRef _Impresora As String) As Boolean

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

            If Not (String.IsNullOrEmpty(_Impresora)) Then
                .PrinterSettings.PrinterName = _Impresora
                _PrtSettings = .PrinterSettings
            Else
                If .ShowDialog() = DialogResult.OK Then
                    _PrtSettings = .PrinterSettings
                    _Impresora = _PrtSettings.PrinterName
                Else
                    _Impresora = String.Empty
                    Return False
                End If
            End If


        End With

        Return True

    End Function

    Private Sub Sb_Print_PrintPage_Voucher(ByVal sender As Object,
                                           ByVal e As PrintPageEventArgs)


        ' Este evento se producirá cada vez que se imprima una nueva página
        ' imprimir HOLA MUNDO en Arial tamaño 24 y negrita

        Try

            ' imprimimos la cadena en el margen izquierdo
            Dim xPos As Single = 3 'e.MarginBounds.Left
            ' La fuente a usar

            Dim DtFont As New Font("Courier New", 8, FontStyle.Regular) ' Fuente del detalle

            ' la posición superior
            Dim yPos As Single = 12 ' * 2

            For i = 0 To _Voucher_a_imprimir.Length - 1
                Dim _Fila As String = _Voucher_a_imprimir(i)
                e.Graphics.DrawString(_Fila, DtFont, Brushes.Black, xPos, yPos)
                yPos += 12
            Next

            yPos += 12
            e.Graphics.DrawString(".", DtFont, Brushes.Black, 1, yPos)

            e.HasMorePages = False
            _Voucher_Impreso = True

        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub

End Class
