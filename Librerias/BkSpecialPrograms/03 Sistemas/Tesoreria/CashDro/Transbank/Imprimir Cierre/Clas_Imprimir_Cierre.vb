'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing

Public Class Clas_Imprimir_Cierre

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Empresa, _Sucursal, _Bodega As String
    Dim _TblProductos As DataTable
    Dim _Tbl_Detalle_Terminal As DataTable

    Dim _Filas_X_Documento As Integer

    Dim _Item = 1

    Dim _Row_Cierre As DataRow
    Dim _Row_Configp As DataRow

    Dim _Fecha_Cierre As Date
    Dim _NombreEquipo As String

    Dim _printDoc As New PrintDocument
    Dim _PrtSettings As New PrinterSettings
    Dim _Impresora As String

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
    Public Property Pro_Tbl_Detalle_Terminal() As DataTable
        Get
            Return _Tbl_Detalle_Terminal
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Detalle_Terminal = value
        End Set
    End Property
    Public Property Pro_Row_Cierre() As DataRow
        Get
            Return _Row_Cierre
        End Get
        Set(ByVal value As DataRow)
            _Row_Cierre = value
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

    Public Sub New(ByVal NombreEquipo As String, _
                   ByVal Fecha_Cierre As Date)

        _NombreEquipo = NombreEquipo
        _Fecha_Cierre = Fecha_Cierre

        Dim _FechaCierre As String = Format(_Fecha_Cierre, "yyyyMMdd")

        Consulta_sql = "Select Top 1 * From CONFIGP Where EMPRESA = '" & ModEmpresa & "'"
        _Row_Configp = _Sql.Fx_Get_DataRow(Consulta_sql)

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Estaciones_CashDro" & vbCrLf & _
                       "Where NombreEquipo = '" & _NombreEquipo & "'"
        _Row_Terminal_Transbank = _Sql.Fx_Get_DataRow(Consulta_sql)


        'Consulta_sql = "Declare @Fecha as date = '" & _FechaCierre & "'" & vbCrLf &
        '               "SELECT Z1.*,Isnull(Log_Datos_Ultima_Venta_Transbank ,'') As Log_Datos_Ultima_Venta_Transbank" & vbCrLf &
        '               "Into #Paso1" & vbCrLf &
        '               "FROM " & _Global_BaseBk & "Zw_CashDro_Operaciones Z1" & vbCrLf &
        '               "Inner Join " & _Global_BaseBk & "Zw_CashDro_Transbank_Log Z2 On Z2.Idmaeedo_Referencia = Z1.Idmaeedo" & vbCrLf &
        '               "WHERE posid = '" & _NombreEquipo & "' And Pagado_Transbank = 1 And" & Space(1) &
        '               "FechaHora_Inicio >= @Fecha And FechaHora_Inicio < DATEADD(dd,1,@Fecha)" & vbCrLf &
        '               "ORDER BY Z1.Id DESC" & vbCrLf &
        '                vbCrLf &
        '               "Select * From #Paso1" & vbCrLf &
        '               "Drop table #Paso1"

        Consulta_sql = "Declare @Fecha as date = '" & _FechaCierre & "'
                        SELECT Z1.*,Cast('' As Varchar(2000)) As Log_Datos_Ultima_Venta_Transbank
                        Into #Paso1
                        FROM " & _Global_BaseBk & "Zw_CashDro_Operaciones Z1
                        WHERE posid = '" & _NombreEquipo & "' And Pagado_Transbank = 1 And FechaHora_Inicio >= @Fecha And FechaHora_Inicio < DATEADD(dd,1,@Fecha) 
                        ORDER BY Z1.Id DESC

                        Update #Paso1 Set Log_Datos_Ultima_Venta_Transbank = Isnull((Select Top 1 Log_Datos_Ultima_Venta_Transbank From " & _Global_BaseBk & "Zw_CashDro_Transbank_Log 
                                          Where Idmaeedo_Referencia = Idmaeedo ),'???')

                        Update #Paso1 Set Tido = (Select TIDO From MAEEDO Where IDMAEEDO = Idmaeedo_H) 
						Where Idmaeedo = 0 and Idmaedpce = 0 And Idmaeedo_H <> 0 and posid In (Select NombreEquipo From " & _Global_BaseBk & "Zw_Estaciones_CashDro Where Post_Integrado = 1 and Usar_Post_Integrado = 1)

						Update #Paso1 Set Nudo = (Select NUDO From MAEEDO Where IDMAEEDO = Idmaeedo_H) 
						Where Idmaeedo = 0 and Idmaedpce = 0 And Idmaeedo_H <> 0 and posid In (Select NombreEquipo From " & _Global_BaseBk & "Zw_Estaciones_CashDro Where Post_Integrado = 1 and Usar_Post_Integrado = 1)

   						Update #Paso1 Set Idmaedpce = (Select Top 1 IDMAEDPCE From MAEDPCD Where IDRST = Idmaeedo_H) 
						Where Idmaeedo = 0 and Idmaedpce = 0 And Idmaeedo_H <> 0 and posid In (Select NombreEquipo From " & _Global_BaseBk & "Zw_Estaciones_CashDro Where Post_Integrado = 1 and Usar_Post_Integrado = 1)

                        Select * From #Paso1 Order by FechaHora_Inicio
                        Drop table #Paso1"

        _Tbl_Detalle_Terminal = _Sql.Fx_Get_DataTable(Consulta_sql)


        Consulta_sql = "Declare @Fecha as date = '" & _FechaCierre & "'" & vbCrLf & _
                       "Select Top 1 *" & vbCrLf & _
                       "From " & _Global_BaseBk & "Zw_CashDro_Transbank_Cierre" & vbCrLf & _
                       "Where NombreEquipo = '" & _NombreEquipo & "' And Fecha_Hora_Cierre >= @Fecha And Fecha_Hora_Cierre < DATEADD(dd,1,@Fecha)" & vbCrLf & _
                       "Order By Fecha_Hora_Cierre Desc"

        _Row_Cierre = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Enum _Enum_Tipo_Impresion
        Cierre_Caja
        Detalle_Terminal
    End Enum

    Public Function Fx_Imprimir_Archivo(ByVal _Formulario As Form, _
                                        ByVal _Nombre_documento As String, _
                                        ByVal _Impresora_Sel As String, _
                                        ByVal _Tipo_Impresion As _Enum_Tipo_Impresion)

        Try

            ' ejemplo simple para imprimir en .NET
            ' Usamos una clase del tipo _printDocument

            _Impresora = _Impresora_Sel

            _printDoc = New PrintDocument

            Dim _Doc_AnchoDoc As Integer = 7.5 * 38.5 '39 '38.5
            Dim _Doc_LargoDoc As Integer = 8 * 38.5 '42 '41.5
            Dim _Item As Integer = 1
            ' asignamos el método de evento para cada página a imprimir

            Select Case _Tipo_Impresion
                Case _Enum_Tipo_Impresion.Cierre_Caja
                    AddHandler _printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Cierre_Caja
                Case _Enum_Tipo_Impresion.Detalle_Terminal

                    For Each _Fila As DataRow In _Tbl_Detalle_Terminal.Rows
                        _Item += 2
                    Next

                    AddHandler _printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Detalle_Ventas_Terminal
            End Select

            _Doc_LargoDoc += _Item * 12

            ' indicamos que queremos imprimir

            _printDoc.DocumentName = _Nombre_documento

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


    Private Function Fx_Codigo_Barras(ByVal _Codigo As String) As PictureBox
        'Código de barras 
        Dim _Bmp As Bitmap = Nothing
        Dim _CodBarras As New PictureBox
        Dim _Imagen As New PictureBox

        Dim _iType As BarCode.Code128SubTypes = _
        DirectCast([Enum].Parse(GetType(BarCode.Code128SubTypes), "CODE128"), BarCode.Code128SubTypes)

        _Bmp = BarCode.Code128(_Codigo, _iType, False)

        If Not IsNothing(_Bmp) Then
            _CodBarras.Image = _Bmp
        End If

        Return _CodBarras

    End Function

    Private Sub Sb_Print_PrintPage_Cierre_Caja(ByVal sender As Object, _
                                               ByVal e As PrintPageEventArgs)
        ' Este evento se producirá cada vez que se imprima una nueva página
        ' imprimir HOLA MUNDO en Arial tamaño 24 y negrita

        Try

            ' imprimimos la cadena en el margen izquierdo
            Dim _xPos As Single = 3 'e.MarginBounds.Left
            ' La fuente a usar

            Dim _Direccion As String = _Row_Configp.Item("DIRECCION")
            Dim _Ciudad As String = _Row_Configp.Item("CIUDAD")

            Dim _Codigo_comercio As String = _Row_Terminal_Transbank.Item("Tbk_Post_Codigo_Comercio")
            Dim _Version_Post As String = _Row_Terminal_Transbank.Item("Tbk_Post_Version")
            Dim _Terminal As String = _Row_Terminal_Transbank.Item("Tbk_Post_Terminal")

            Dim _Fuente As Font
            _Fuente = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular)

            ' la posición superior
            Dim _yPos As Single = _Fuente.GetHeight(e.Graphics) - 10

            _yPos += 20

            Dim _Fecha = FormatDateTime(_Row_Cierre.Item("Fecha_Hora_Cierre"), DateFormat.ShortDate)

            Dim _Hora = FormatDateTime(_Row_Cierre.Item("Fecha_Hora_Cierre"), DateFormat.LongTime)

            e.Graphics.DrawString(Space(5) & "REPORTE DE CIERRE DEL TERMINAL", _Fuente, Brushes.Black, _xPos, _yPos)
            _yPos += 12
            e.Graphics.DrawString(Space(13) & _Direccion, _Fuente, Brushes.Black, _xPos, _yPos)
            _yPos += 12
            e.Graphics.DrawString(Space(15) & _Ciudad, _Fuente, Brushes.Black, _xPos, _yPos)
            _yPos += 12
            e.Graphics.DrawString(Space(8) & _Codigo_comercio & Space(3) & _Version_Post, _Fuente, Brushes.Black, _xPos, _yPos)
            _yPos += 12 * 2
            e.Graphics.DrawString("FECHA" & Space(12) & "HORA" & Space(11) & "TERMINAL", _Fuente, Brushes.Black, _xPos, _yPos)
            _yPos += 12
            e.Graphics.DrawString(_Fecha & Space(6) & _Hora & Space(8) & _Terminal, _Fuente, Brushes.Black, _xPos, _yPos)
            _yPos += 12 * 2

            e.Graphics.DrawString(Space(17) & "NUMERO" & Space(12) & "TOTAL", _Fuente, Brushes.Black, _xPos, _yPos)
            _yPos += 12

            e.Graphics.DrawString(StrDup(40, "-"), _Fuente, Brushes.Black, _xPos, _yPos)
            _yPos += 12

            Dim _Detalle = _Row_Cierre.Item("Detalle")

            Dim _Array_Detalle = Split(_Detalle, ";")


            For Each _Descripcion As String In _Array_Detalle

                e.Graphics.DrawString(_Descripcion, _Fuente, Brushes.Black, _xPos, _yPos)

                _yPos += 12

                _Item += 1

            Next


            ' indicamos que ya no hay nada más que imprimir
            ' (el valor predeterminado de esta propiedad es False)
            e.HasMorePages = False
            

        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub

    Private Sub Sb_Print_PrintPage_Detalle_Ventas_Terminal(ByVal sender As Object, _
                                                           ByVal e As PrintPageEventArgs)
       

        Try

            ' imprimimos la cadena en el margen izquierdo
            Dim _xPos As Single = 3 'e.MarginBounds.Left


            Dim _Direccion As String = _Row_Configp.Item("DIRECCION")
            Dim _Ciudad As String = _Row_Configp.Item("CIUDAD")

            Dim _Codigo_comercio As String = _Row_Terminal_Transbank.Item("Tbk_Post_Codigo_Comercio")
            Dim _Version_Post As String = _Row_Terminal_Transbank.Item("Tbk_Post_Version")
            Dim _Terminal As String = _Row_Terminal_Transbank.Item("Tbk_Post_Terminal")

            ' La fuente a usar
            Dim _Fuente As Font
            _Fuente = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular)

            Dim _Total_Venta As String

            ' la posición superior
            Dim _yPos As Single = _Fuente.GetHeight(e.Graphics) - 10

            _yPos += 20

            Dim _Fecha = FormatDateTime(_Fecha_Cierre, DateFormat.ShortDate)
            Dim _Hora = String.Empty

            e.Graphics.DrawString(Space(5) & "DETALLE DE VENTAS DEL TERMINAL", _Fuente, Brushes.Black, _xPos, _yPos)
            _yPos += 12
            e.Graphics.DrawString(Space(13) & _Direccion, _Fuente, Brushes.Black, _xPos, _yPos)
            _yPos += 12
            e.Graphics.DrawString(Space(15) & _Ciudad, _Fuente, Brushes.Black, _xPos, _yPos)
            _yPos += 12
            e.Graphics.DrawString(Space(8) & _Codigo_comercio & Space(3) & _Version_Post, _Fuente, Brushes.Black, _xPos, _yPos)
            _yPos += 12 * 2
            e.Graphics.DrawString("FECHA" & Space(12) & Space(15) & "TERMINAL", _Fuente, Brushes.Black, _xPos, _yPos)
            _yPos += 12
            e.Graphics.DrawString(_Fecha & Space(6) & Space(16) & _Terminal, _Fuente, Brushes.Black, _xPos, _yPos)
            _yPos += 12 * 2

            e.Graphics.DrawString("Nro" & Space(5) & "TJ" & Space(3) & "TT" & Space(3) & "HORA" & Space(11) & "TOTAL", _Fuente, Brushes.Black, _xPos, _yPos)
            _yPos += 12

            e.Graphics.DrawString(StrDup(40, "-"), _Fuente, Brushes.Black, _xPos, _yPos)
            _yPos += 12

           
            Dim _Suma_Total As Double

            _xPos += 1

            For Each _Fila As DataRow In _Tbl_Detalle_Terminal.Rows

                Dim _Descripcion As String

                Dim _Hora_Trans As String = FormatDateTime(_Fila.Item("FechaHora_Inicio"), DateFormat.ShortTime)

                Dim _Respuesta_Tarjeta As String

                _Respuesta_Tarjeta = _Fila.Item("Log_Datos_Ultima_Venta_Transbank")

                Dim _Comando = String.Empty
                Dim _Codigo_Respuesta = String.Empty
                Dim _Codigo_de_comercio = String.Empty
                Dim _Terminal_ID = String.Empty
                Dim _Numero_Ticket_Boleta = String.Empty
                Dim _Codigo_Autorizacion = String.Empty
                Dim _Monto As Double = _Fila.Item("Monto")
                Dim _Ultimos_4_Digitos_Tarjeta = String.Empty
                Dim _Numero_Operacion = String.Empty
                Dim _Tipo_de_Tarjeta = String.Empty
                Dim _Fecha_Contable = String.Empty
                Dim _Numero_de_Cuenta = String.Empty
                Dim _Emdp As String
                Dim _Idmaedpce As Integer = _Fila.Item("Idmaedpce")

                Dim _Cod_Tarjeta = String.Empty

                _Total_Venta = Fx_Formato_Numerico(_Monto, "$ 9.999.999", False)

                _Suma_Total += _Monto


                If Not String.IsNullOrEmpty(Trim(_Respuesta_Tarjeta)) Then

                    Consulta_sql = "Select Top 1 * From MAEDPCE Where IDMAEDPCE = " & _Idmaedpce
                    Dim _Row_Maedpce As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    Dim _Datos_Tarjeta = Split(_Respuesta_Tarjeta, "|")

                    Dim _Largo As Integer = CType(_Datos_Tarjeta, System.Array).Length

                    Try

                        _Ultimos_4_Digitos_Tarjeta = _Row_Maedpce.Item("REFANTI")
                        _Ultimos_4_Digitos_Tarjeta = Replace(_Ultimos_4_Digitos_Tarjeta, "**********", "")

                        _Descripcion = _Ultimos_4_Digitos_Tarjeta & Space(2) & _Emdp & Space(2) &
                                       _Tipo_de_Tarjeta & Space(3) & _Hora_Trans & Space(5) & _Total_Venta

                    Catch ex As Exception

                        _Descripcion = "Revisar sitio transbank!" & Space(3) & _Total_Venta

                    End Try

                End If

                Dim _Tido = _Fila.Item("Tido")
                Dim _Nudo = _Fila.Item("Nudo")


                e.Graphics.DrawString(_Descripcion, _Fuente, Brushes.Black, _xPos, _yPos)
                _yPos += 12
                e.Graphics.DrawString(Space(4) & _Tido & "-" & _Nudo, _Fuente, Brushes.Black, _xPos, _yPos)
                _yPos += 12

                _Item += 1

            Next

            e.Graphics.DrawString(StrDup(40, "-"), _Fuente, Brushes.Black, _xPos, _yPos)
            _yPos += 12 * 2

            Dim _Descripcion_Total = Space(20) & "TOTAL: " & Fx_Formato_Numerico(_Suma_Total, "$ 9.999.999", False)

            e.Graphics.DrawString(_Descripcion_Total, _Fuente, Brushes.Black, _xPos, _yPos)

            _yPos += 12 * 2
            e.Graphics.DrawString(".", _Fuente, Brushes.Black, 1, _yPos)

            ' indicamos que ya no hay nada más que imprimir
            ' (el valor predeterminado de esta propiedad es False)

            e.HasMorePages = False

        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
        End Try

    End Sub


End Class
