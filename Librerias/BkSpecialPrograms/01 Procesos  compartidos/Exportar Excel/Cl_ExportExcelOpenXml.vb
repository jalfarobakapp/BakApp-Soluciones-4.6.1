Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet

Public Class Cl_ExportExcelOpenXml

    Public Property Circular_Progres_Porcentaje As DevComponents.DotNetBar.Controls.CircularProgress
    Public Property Circular_Progres_Contador As DevComponents.DotNetBar.Controls.CircularProgress
    Public Property Cancelar As Boolean
    Public Sub New()

    End Sub

    Public Function Fx_CrearDocumentoExcel_Tbl(_Archivo As String, _Tbl_Excel As DataTable) As LsValiciones.Mensajes

        Dim _Fila As Integer = 0
        Dim _Columna As Integer = 0

        Dim _Mensaje As New LsValiciones.Mensajes

        If Not IsNothing(Circular_Progres_Contador) Then
            Circular_Progres_Contador.Minimum = 0
            Circular_Progres_Contador.Maximum = _Tbl_Excel.Rows.Count
            Circular_Progres_Contador.Value = 0
        End If

        If Not IsNothing(Circular_Progres_Porcentaje) Then
            Circular_Progres_Porcentaje.Minimum = 0
            Circular_Progres_Porcentaje.Maximum = 100
            Circular_Progres_Porcentaje.Value = 0
        End If

        Try

            Using document = SpreadsheetDocument.Create(_Archivo, SpreadsheetDocumentType.Workbook)

                Dim workbookPart = document.AddWorkbookPart()
                workbookPart.Workbook = New Workbook()

                ' Crear los estilos, incluyendo el formato de fecha
                Dim stylesPart = workbookPart.AddNewPart(Of WorkbookStylesPart)()
                stylesPart.Stylesheet = CreateStylesheetWithDateStyle()
                stylesPart.Stylesheet.Save()

                Dim sheetData = New SheetData()
                Dim worksheetPart = workbookPart.AddNewPart(Of WorksheetPart)()

                worksheetPart.Worksheet = New Worksheet(sheetData)

                Dim sheets = document.WorkbookPart.Workbook.AppendChild(New Sheets())
                Dim sheet = New Sheet() With {.Id = document.WorkbookPart.GetIdOfPart(worksheetPart), .SheetId = 1, .Name = "Hoja1"}

                sheets.Append(sheet)

                Dim row = New Row()

                For Each dc In _Tbl_Excel.Columns

                    Dim _Valor As String = dc.ColumnName
                    row.Append(New Cell() With {.CellValue = New CellValue(_Valor), .DataType = CellValues.String})

                Next

                sheetData.Append(row)

                _Fila = 1

                Dim _Contador = 0

                For Each dr In _Tbl_Excel.Rows

                    System.Windows.Forms.Application.DoEvents()

                    _Columna = 0

                    row = New Row()

                    For Each dc In _Tbl_Excel.Columns

                        Dim Contenido = dr(dc.ColumnName).ToString

                        Dim ty As Type = dc.DataType
                        Dim TipoDeDato As String = ty.Name.ToString

                        If dc.ColumnName = "Consolidado" Then
                            Dim _ssa = 0
                        End If

                        Dim Cell As New Cell

                        If TipoDeDato = "Double" Or TipoDeDato = "Decimal" Or TipoDeDato = "Int32" Then

                            Dim _Valor_ As Double = De_Txt_a_Num_01(Contenido, 3)
                            Cell = New Cell() With {.CellValue = New CellValue(_Valor_), .DataType = CellValues.Number}

                        ElseIf TipoDeDato = "DateTime" Then

                            Dim dateValue As DateTime = NuloPorNro(dr(dc.ColumnName), "01/01/1900")
                            Cell = New Cell() With {.CellValue = New CellValue(dateValue.ToOADate().ToString()), .DataType = CellValues.Number, .StyleIndex = 1}

                        ElseIf TipoDeDato = "Boolean" Then

                            Dim _Boolean As Boolean = NuloPorNro(dr(dc.ColumnName), False)
                            Cell = New Cell() With {.CellValue = New CellValue(_Boolean), .DataType = CellValues.Boolean}

                        Else

                            Dim _ValorXml As String = CStr(dr(dc.ColumnName).ToString)

                            ' Limpieza de valores ASCII
                            For _i = 0 To 31
                                _ValorXml = Replace(_ValorXml, Chr(_i), " ")
                            Next
                            _ValorXml = Replace(_ValorXml, Chr(127), " ")

                            If IsNothing(_ValorXml) Then _ValorXml = String.Empty

                            Cell = New Cell() With {.CellValue = New CellValue(_ValorXml), .DataType = CellValues.String}

                        End If

                        'Dim row = New Row()

                        row.Append(Cell)

                        If Cancelar Then
                            _Mensaje.Cancelado = True
                            Throw New Exception("Proceso cancelado por el usuario")
                        End If

                        _Columna += 1

                    Next

                    sheetData.Append(row)

                    If Not IsNothing(Circular_Progres_Contador) Then
                        Circular_Progres_Contador.Value += 1
                    End If

                    If Not IsNothing(Circular_Progres_Porcentaje) Then
                        Circular_Progres_Porcentaje.Value = ((_Contador * 100) / _Tbl_Excel.Rows.Count) 'Mas
                    End If

                    _Contador += 1
                    _Fila += 1

                    ' Liberar memoria periódicamente
                    If _Fila Mod 20000 = 0 Then
                        GC.Collect()
                    End If

                Next

            End Using

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "El archivo fue guardado con exito en la carpeta:" & vbCrLf & _Archivo.Replace("\\", "\")
            _Mensaje.Detalle = "Exportar a Excel"
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Tag = _Archivo

        Catch ex As Exception

            _Mensaje.EsCorrecto = False

            If _Fila AndAlso _Columna Then
                _Mensaje.Mensaje = "Fila: " & _Fila & ", Columna: " & _Columna & vbCrLf & ex.Message
            Else
                _Mensaje.Mensaje = ex.Message
            End If

            _Mensaje.Detalle = "Exportar a Excel"
            _Mensaje.Tag = String.Empty
            _Mensaje.Icono = MessageBoxIcon.Error

        Finally
            Circular_Progres_Contador.Minimum = 0
            Circular_Progres_Porcentaje.Value = 0
        End Try

        Return _Mensaje

    End Function

    Public Function Fx_CrearDocumentoExcel_Ds(_Archivo As String, _Ds As DataSet) As LsValiciones.Mensajes

        Dim _Fila As Integer = 0
        Dim _Columna As Integer = 0
        Dim _NroHoja As Integer = 0

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Using document = SpreadsheetDocument.Create(_Archivo, SpreadsheetDocumentType.Workbook)

                Dim workbookPart = document.AddWorkbookPart()
                workbookPart.Workbook = New Workbook()

                Dim sheets = document.WorkbookPart.Workbook.AppendChild(New Sheets())

                For Each _Tbl_Excel As DataTable In _Ds.Tables

                    If Not IsNothing(Circular_Progres_Contador) Then
                        Circular_Progres_Contador.Minimum = 0
                        Circular_Progres_Contador.Maximum = _Tbl_Excel.Rows.Count
                        Circular_Progres_Contador.Value = 0
                    End If

                    If Not IsNothing(Circular_Progres_Porcentaje) Then
                        Circular_Progres_Porcentaje.Minimum = 0
                        Circular_Progres_Porcentaje.Maximum = 100
                        Circular_Progres_Porcentaje.Value = 0
                    End If

                    ' Crear los estilos, incluyendo el formato de fecha
                    Dim stylesPart = workbookPart.AddNewPart(Of WorkbookStylesPart)()
                    stylesPart.Stylesheet = CreateStylesheetWithDateStyle()
                    stylesPart.Stylesheet.Save()

                    Dim sheetData = New SheetData()
                    Dim worksheetPart = workbookPart.AddNewPart(Of WorksheetPart)()
                    worksheetPart.Worksheet = New Worksheet(sheetData)

                    _Fila = 0
                    _NroHoja += 1

                    Dim sheet = New Sheet() With {.Id = document.WorkbookPart.GetIdOfPart(worksheetPart),
                                                  .SheetId = _NroHoja,
                                                  .Name = "Hoja" & _NroHoja}

                    sheets.Append(sheet)

                    Dim row = New Row()

                    For Each dc In _Tbl_Excel.Columns

                        Dim _Valor As String = dc.ColumnName
                        row.Append(New Cell() With {.CellValue = New CellValue(_Valor), .DataType = CellValues.String})

                    Next

                    SheetData.Append(row)

                    _Fila = 1

                    Dim _Contador = 0

                    For Each dr In _Tbl_Excel.Rows

                        System.Windows.Forms.Application.DoEvents()
                        _Columna = 0

                        row = New Row()

                        For Each dc In _Tbl_Excel.Columns

                            Dim Contenido = dr(dc.ColumnName).ToString

                            Dim ty As Type = dc.DataType
                            Dim TipoDeDato As String = ty.Name.ToString

                            If dc.ColumnName = "Consolidado" Then
                                Dim _ssa = 0
                            End If

                            Dim cell As New Cell

                            If TipoDeDato = "Double" Or TipoDeDato = "Decimal" Or TipoDeDato = "Int32" Then

                                Dim _Valor_ As Double = De_Txt_a_Num_01(Contenido, 3)

                                cell = New Cell() With {.CellValue = New CellValue(_Valor_), .DataType = CellValues.Number}

                            ElseIf TipoDeDato = "DateTime" Then

                                Dim dateValue As DateTime = NuloPorNro(dr(dc.ColumnName), "01/01/1900")
                                cell = New Cell() With {.CellValue = New CellValue(dateValue.ToOADate().ToString()), .DataType = CellValues.Number, .StyleIndex = 1}

                            ElseIf TipoDeDato = "Boolean" Then

                                Dim _Boolean As Boolean

                                _Boolean = NuloPorNro(dr(dc.ColumnName), False)

                                cell = New Cell() With {.CellValue = New CellValue(_Boolean), .DataType = CellValues.Boolean}

                            Else

                                Dim _ValorXml As String = CStr(dr(dc.ColumnName).ToString)

                                ' Limpieza de valores ASCII
                                For _i = 0 To 31
                                    _ValorXml = Replace(_ValorXml, Chr(_i), " ")
                                Next
                                _ValorXml = Replace(_ValorXml, Chr(127), " ")

                                If IsNothing(_ValorXml) Then _ValorXml = String.Empty

                                cell = New Cell() With {.CellValue = New CellValue(_ValorXml), .DataType = CellValues.String}

                            End If

                            row.Append(cell)

                            If Cancelar Then
                                _Mensaje.Cancelado = True
                                Throw New Exception("Proceso cancelado por el usuario")
                            End If

                            _Columna += 1

                        Next

                        SheetData.Append(row)

                        If Not IsNothing(Circular_Progres_Contador) Then
                            Circular_Progres_Contador.Value += 1
                        End If

                        If Not IsNothing(Circular_Progres_Porcentaje) Then
                            Circular_Progres_Porcentaje.Value = ((_Contador * 100) / _Tbl_Excel.Rows.Count) 'Mas
                        End If

                        _Contador += 1
                        _Fila += 1

                        ' Liberar memoria periódicamente
                        If _Fila Mod 20000 = 0 Then
                            GC.Collect()
                        End If

                    Next

                Next

            End Using

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "El archivo fue guardado con exito en la carpeta:" & vbCrLf & _Archivo.Replace("\\", "\")
            _Mensaje.Detalle = "Exportar a Excel"
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Tag = _Archivo

        Catch ex As Exception

            _Mensaje.EsCorrecto = False

            If _Fila AndAlso _Columna Then
                _Mensaje.Mensaje = "Fila: " & _Fila & ", Columna: " & _Columna & vbCrLf & ex.Message
            Else
                _Mensaje.Mensaje = ex.Message
            End If

            _Mensaje.Detalle = "Exportar a Excel"
            _Mensaje.Tag = String.Empty
            _Mensaje.Icono = MessageBoxIcon.Error

        Finally
            Circular_Progres_Contador.Value = 0
            Circular_Progres_Porcentaje.Value = 0
        End Try

        Return _Mensaje

    End Function

    Private Function CreateStylesheetWithDateStyle() As Stylesheet
        Dim stylesheet = New Stylesheet()

        ' Crear fuentes (fonts)
        Dim fonts = New Fonts()
        fonts.Append(New Font())
        fonts.Count = 1

        ' Crear fills
        Dim fills = New Fills()
        fills.Append(New Fill(New PatternFill() With {.PatternType = PatternValues.None}))
        fills.Append(New Fill(New PatternFill() With {.PatternType = PatternValues.Gray125}))
        fills.Count = 2

        ' Crear bordes
        Dim borders = New Borders()
        borders.Append(New Border())
        borders.Count = 1

        ' Crear cell formats
        Dim cellFormats = New CellFormats()
        ' Formato por defecto
        cellFormats.Append(New CellFormat())
        ' Formato de fecha
        cellFormats.Append(New CellFormat() With {.NumberFormatId = 14, .FontId = 0, .FillId = 0, .BorderId = 0, .ApplyNumberFormat = True})
        cellFormats.Count = 2

        stylesheet.Append(fonts)
        stylesheet.Append(fills)
        stylesheet.Append(borders)
        stylesheet.Append(cellFormats)

        Return stylesheet
    End Function

End Class


