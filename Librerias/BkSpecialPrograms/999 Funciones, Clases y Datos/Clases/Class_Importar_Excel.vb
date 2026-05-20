Imports Docs.Excel
Imports System.Reflection

Public Class Class_Importar_Excel

    Public Property Errores As String

    ' Plan (pseudocódigo detallado):
    ' 1. Mantener la función privada `CellIsFormula(cell As Object) As Boolean` tal como está:
    '    - Si `cell` es `Nothing` devolver `False`.
    '    - Usar reflection para comprobar propiedades comunes que indiquen fórmula:
    '      a) Propiedad `IsFormula` (Boolean).
    '      b) Propiedad `HasFormula` (Boolean).
    '      c) Propiedad `Formula` (si no es nula y no vacía -> es fórmula).
    '      d) Propiedad `Value`: si es `String` y comienza con "=" -> es fórmula.
    '    - Manejar excepciones silenciosamente y devolver `False` por defecto.
    '
    ' 2. En `Importar_Excel_Array` y `Importar_Excel_Lista`:
    '    - Obtener el objeto celda con `Workbook.Worksheets(Hoja).Cells(rowIndex, colIndex)`.
    '    - Llamar a `CellIsFormula(cellObj)` para detectar fórmula. Si devuelve `True`, lanzar excepción con fila/col.
    '    - Obtener el valor de la celda por reflection (propiedad `Value`) dentro de un bloque `Try`.
    '    - Si `val` resulta `Nothing`:
    '       - Tratarlo como sospechoso de contener fórmula o dato no accesible y lanzar una excepción con fila/col
    '         indicando que el valor es `Nothing` (posible fórmula o celda vacía no legible).
    '       - Esto mantiene consistencia con la política de abortar cuando hay fórmulas detectadas para que el
    '         `Catch` superior capture y asigne `Errores` con contexto de fila/col.
    '    - Si `val` no es `Nothing`, asignarlo al arreglo o lista como antes.
    '
    ' 3. Mantener la captura de excepciones existente para asignar `Errores` y devolver `Nothing` (o no devolver en el caso de arrays).
    ' 4. Aplicar la detección en ambos métodos para consistencia y mensajes útiles al usuario.

    Private Function CellIsFormula(cell As Object) As Boolean
        If cell Is Nothing Then
            Return False
        End If

        Try
            Dim t As Type = cell.GetType()

            ' Propiedad IsFormula (Boolean)
            Dim prop As PropertyInfo = t.GetProperty("IsFormula")
            If prop IsNot Nothing Then
                Dim val = prop.GetValue(cell, Nothing)
                If TypeOf val Is Boolean Then
                    Return CBool(val)
                End If
            End If

            ' Propiedad HasFormula (Boolean)
            prop = t.GetProperty("HasFormula")
            If prop IsNot Nothing Then
                Dim val = prop.GetValue(cell, Nothing)
                If TypeOf val Is Boolean Then
                    Return CBool(val)
                End If
            End If

            ' Propiedad Formula (string u otro)
            prop = t.GetProperty("Formula")
            If prop IsNot Nothing Then
                Dim f = prop.GetValue(cell, Nothing)
                If f IsNot Nothing AndAlso Not String.IsNullOrEmpty(f.ToString()) Then
                    Return True
                End If
            End If

            ' Si Value es string y comienza con "=" entonces es fórmula
            prop = t.GetProperty("Value")
            If prop IsNot Nothing Then
                Dim v = prop.GetValue(cell, Nothing)
                If TypeOf v Is String Then
                    Dim s = v.ToString()
                    If s.StartsWith("=") Then
                        Return True
                    End If
                End If
            End If
        Catch
            ' Ignorar errores de reflection y considerar que no es fórmula
        End Try

        Return False
    End Function

    Public Function Importar_Excel_Array(Direccion_Archivo_XLS As String,
                                          Extencion_ As String,
                                         Optional Hoja As Integer = 0)

        Dim _UltFila As Integer
        Dim _UltColumna As Integer

        Try
            Errores = String.Empty

            ExcelWorkbook.SetLicenseCode("SA014N-E4113A-E1ALDA-101800")
            Dim Workbook As Object

            Dim Ext_ As String = LCase(Extencion_)

            If Ext_ = "xls" Then
                Workbook = ExcelWorkbook.ReadXLSX(Direccion_Archivo_XLS)
            ElseIf Ext_ = "xlsx" Then
                Workbook = ExcelWorkbook.ReadXLSX(Direccion_Archivo_XLS)
            End If

            Dim Filas As Double = Workbook.Worksheets(Hoja).Rows.Count
            Dim Columnas As Double = Workbook.Worksheets(Hoja).Columns.Count

            Dim Arreglo(Filas - 1, Columnas - 1) As String


            Dim dt As New DataTable
            dt.Columns.Add("Codigo")
            dt.Columns.Add("Precio")

            For i As Integer = 1 To Filas  ' Workbook.Worksheets(0).Rows.Count
                _UltFila = i
                For cl As Integer = 0 To Columnas - 1
                    _UltColumna = cl
                    Dim cellObj As Object = Workbook.Worksheets(Hoja).Cells(i - 1, cl)

                    ' Detectar si la celda contiene una fórmula
                    If CellIsFormula(cellObj) Then
                        Throw New Exception("contiene una fórmula.")
                    End If

                    ' Obtener valor de la celda por reflection (si existe la propiedad Value)
                    Dim val As Object = Nothing
                    Try
                        Dim propVal = cellObj.GetType().GetProperty("Value")
                        If propVal IsNot Nothing Then
                            val = propVal.GetValue(cellObj, Nothing)
                        Else
                            ' Intentar usar ToString() si no hay Value
                            val = If(cellObj IsNot Nothing, cellObj.ToString(), Nothing)
                        End If
                    Catch
                        val = Nothing
                    End Try

                    ' Si el valor resultante es Nothing, considerarlo sospechoso de fórmula o dato no legible
                    If val Is Nothing Then
                        val = String.Empty
                        'Throw New Exception("tiene valor Nothing (posible fórmula o celda vacía no legible).")
                    End If

                    Arreglo(i - 1, cl) = val
                Next
            Next i

            Return Arreglo

        Catch ex As Exception
            Errores = ex.Message & vbCrLf & "Utl. Fila: " & _UltFila & ", Ult. Columna: " & _UltColumna
        End Try

    End Function

    Public Function Importar_Excel_Lista(_Direccion_Archivo_XLS As String,
                                         _Extencion_ As String,
                                         Optional _Hoja As Integer = 0) As List(Of List(Of String))

        Dim _UltFila As Integer = 0
        Dim _UltColumna As Integer = 0

        Try
            Errores = String.Empty

            ExcelWorkbook.SetLicenseCode("SA014N-E4113A-E1ALDA-101800")
            Dim Workbook As Object

            Dim Ext_ As String = LCase(_Extencion_)

            If Ext_ = "xls" Then
                Workbook = ExcelWorkbook.ReadXLSX(_Direccion_Archivo_XLS)
            ElseIf Ext_ = "xlsx" Then
                Workbook = ExcelWorkbook.ReadXLSX(_Direccion_Archivo_XLS)
            End If

            Dim Filas As Double = Workbook.Worksheets(_Hoja).Rows.Count
            Dim Columnas As Double = Workbook.Worksheets(_Hoja).Columns.Count

            Dim Lista As New List(Of List(Of String))

            For i As Integer = 1 To Filas
                _UltFila = i
                Dim Fila As New List(Of String)
                For cl As Integer = 0 To Columnas - 1
                    _UltColumna = cl
                    Dim cellObj As Object = Workbook.Worksheets(_Hoja).Cells(i - 1, cl)

                    ' Detectar si la celda contiene una fórmula
                    If CellIsFormula(cellObj) Then
                        Throw New Exception("La celda Fila: " & i.ToString() & ", Columna: " & (cl + 1).ToString() & " contiene una fórmula.")
                    End If

                    ' Obtener valor de la celda por reflection (si existe la propiedad Value)
                    Dim val As Object = Nothing
                    Try
                        Dim propVal = cellObj.GetType().GetProperty("Value")
                        If propVal IsNot Nothing Then
                            val = propVal.GetValue(cellObj, Nothing)
                        Else
                            val = If(cellObj IsNot Nothing, cellObj.ToString(), Nothing)
                        End If
                    Catch
                        val = Nothing
                    End Try

                    ' Si el valor resultante es Nothing, considerarlo sospechoso de fórmula o dato no legible
                    If val Is Nothing Then
                        Throw New Exception("La celda Fila: " & i.ToString() & ", Columna: " & (cl + 1).ToString() & " tiene valor Nothing (posible fórmula o celda vacía no legible).")
                    End If

                    Fila.Add(val)
                Next
                Lista.Add(Fila)
            Next i

            Return Lista

        Catch ex As Exception
            Errores = ex.Message & vbCrLf & "Utl. Fila: " & _UltFila & ", Ult. Columna: " & _UltColumna
            Return Nothing
        End Try

    End Function

End Class
