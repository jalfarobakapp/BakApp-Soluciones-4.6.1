﻿Imports Docs.Excel

Public Class Class_Importar_Excel

    Public Property Errores As String

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
                    Arreglo(i - 1, cl) = Workbook.Worksheets(Hoja).Cells(i - 1, cl).Value
                Next
            Next i

            Return Arreglo

        Catch ex As Exception
            Errores = ex.Message
        End Try

    End Function

    Public Function Importar_Excel_Lista(_Direccion_Archivo_XLS As String,
                                         _Extencion_ As String,
                                         Optional _Hoja As Integer = 0) As List(Of List(Of String))

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
                Dim Fila As New List(Of String)
                For cl As Integer = 0 To Columnas - 1
                    Fila.Add(Workbook.Worksheets(_Hoja).Cells(i - 1, cl).Value)
                Next
                Lista.Add(Fila)
            Next i

            Return Lista

        Catch ex As Exception
            Errores = ex.Message
            Return Nothing
        End Try

    End Function

End Class
