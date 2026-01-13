Option Strict On
Option Explicit On

Imports System
Imports System.Data
Imports System.Collections.Generic

' Plan (pseudocódigo detallado):
' - Problema: se usa la forma binaria de `If(primero, segundo)` para tipos de valor no anulables.
'   La forma binaria de If en VB es un operador "coalesce" que requiere que el primer operando sea
'   un tipo de referencia, un tipo Nullable(Of T) o un genérico sin restricciones.
' - Solución:
'   1) No envolver el resultado de `ValorEn(...)` en otro `If(...)` cuando `ValorEn` devuelve
'      ya el valor por defecto para tipos de valor. Asignar directamente:
'         .Id = ValorEn(row, "ID", 0)
'   2) Mantener `If(...)` para cadenas u otros tipos de referencia si se desea, aunque también
'      es redundante si `ValorEn` ya retorna el valor por defecto.
'   3) Revisar todas las propiedades de tipo valor (Integer, Double, etc.) y quitar la forma binaria `If`.
' - Resultado esperado: compilar sin BC33107 y mantener comportamiento de sustitución por defecto.

Public Class Cl_MaeedoItem

    Public Property Id As Integer
    Public Property IdPadre As Integer
    Public Property IdPago As Integer
    Public Property IdMaedpce As Integer
    Public Property IdRst As Integer
    Public Property ArchIrst As String
    Public Property TcaSig As String
    Public Property Empresa As String
    Public Property Tido As String
    Public Property Nudo As String
    Public Property Endp As String
    Public Property Emdp As String
    Public Property SuEmdp As String
    Public Property Cudp As String
    Public Property Nucudp As String
    Public Property Feemdp As Nullable(Of Date)
    Public Property Fevedp As Nullable(Of Date)
    Public Property Modp As String
    Public Property Timodp As String
    Public Property Tamodp As String
    Public Property Vadp As Double
    Public Property Vaabdp As Double
    Public Property Saldo As Double
    Public Property Abono As Double
    Public Property Abono2 As Double
    Public Property SaldoAct As Double
    Public Property Orden As Integer
    Public Property FevedpStr As String
    Public Property ModpStr As String
    Public Property VadpStr As String
    Public Property SaldoStr As String
    Public Property SaldoActStr As String
    Public Property Ley20956 As Double

    Public Sub New()
        ' Inicializar valores por defecto si se desea
        ArchIrst = String.Empty
        TcaSig = String.Empty
        Empresa = String.Empty
        Tido = String.Empty
        Nudo = String.Empty
        Endp = String.Empty
        Emdp = String.Empty
        SuEmdp = String.Empty
        Cudp = String.Empty
        Nucudp = String.Empty
        Modp = String.Empty
        Timodp = String.Empty
        Tamodp = String.Empty
        FevedpStr = String.Empty
        ModpStr = String.Empty
        VadpStr = String.Empty
        SaldoStr = String.Empty
        SaldoActStr = String.Empty
    End Sub

    ' Crea una instancia a partir de un DataRow (maneja DBNull)
    Public Shared Function FromDataRow(ByVal row As DataRow) As Cl_MaeedoItem
        If row Is Nothing Then
            Return Nothing
        End If

        Dim i As New Cl_MaeedoItem With {
            .Id = ValorEn(row, "ID", 0),
            .IdPadre = ValorEn(row, "ID_PADRE", 0),
            .IdPago = ValorEn(row, "ID_PAGO", 0),
            .IdMaedpce = ValorEn(row, "IDMAEDPCE", 0),
            .IdRst = ValorEn(row, "IDRST", 0),
            .ArchIrst = If(ValorEn(row, "ARCHIRST", String.Empty), String.Empty),
            .TcaSig = If(ValorEn(row, "TCASIG", String.Empty), String.Empty),
            .Empresa = If(ValorEn(row, "EMPRESA", String.Empty), String.Empty),
            .Tido = If(ValorEn(row, "DP", String.Empty), String.Empty),
            .Nudo = If(ValorEn(row, "NUDP", String.Empty), String.Empty),
            .Endp = If(ValorEn(row, "ENDP", String.Empty), String.Empty),
            .Emdp = If(ValorEn(row, "EMDP", String.Empty), String.Empty),
            .SuEmdp = If(ValorEn(row, "SUEMDP", String.Empty), String.Empty),
            .Cudp = If(ValorEn(row, "CUDP", String.Empty), String.Empty),
            .Nucudp = If(ValorEn(row, "NUCUDP", String.Empty), String.Empty),
            .Feemdp = TryGetDate(row, "FEEMDP"),
            .Fevedp = TryGetDate(row, "FEVEDP"),
            .Modp = If(ValorEn(row, "MODP", String.Empty), String.Empty),
            .Timodp = If(ValorEn(row, "TIMODP", String.Empty), String.Empty),
            .Tamodp = If(ValorEn(row, "TAMODP", String.Empty), String.Empty),
            .Vadp = ValorEn(row, "VADP", 0.0#),
            .Vaabdp = ValorEn(row, "VAABDP", 0.0#),
            .Saldo = ValorEn(row, "SALDO", 0.0#),
            .Abono = ValorEn(row, "ABONO", 0.0#),
            .Abono2 = ValorEn(row, "ABONO2", 0.0#),
            .SaldoAct = ValorEn(row, "SALDO_ACT", 0.0#),
            .Orden = ValorEn(row, "Orden", 0),
            .FevedpStr = If(ValorEn(row, "Fevedp_Str", String.Empty), String.Empty),
            .ModpStr = If(ValorEn(row, "Modp_Str", String.Empty), String.Empty),
            .VadpStr = If(ValorEn(row, "Vadp_Str", String.Empty), String.Empty),
            .SaldoStr = If(ValorEn(row, "Saldo_Str", String.Empty), String.Empty),
            .SaldoActStr = If(ValorEn(row, "Saldo_Act_Str", String.Empty), String.Empty),
            .Ley20956 = ValorEn(row, "LEY20956", 0.0#)
        }

        Return i
    End Function

    ' Convierte un DataTable en una lista fuertemente tipada
    Public Function ListFromDataTable(ByVal table As DataTable) As List(Of Cl_MaeedoItem)
        Dim lista As New List(Of Cl_MaeedoItem)

        If table Is Nothing Then
            Return lista
        End If

        For Each r As DataRow In table.Rows
            Dim item = FromDataRow(r)
            If item IsNot Nothing Then
                lista.Add(item)
            End If
        Next

        Return lista
    End Function

    ' Helpers privados para manejar DBNull y conversiones seguras
    Private Shared Function ValorEn(Of T)(ByVal row As DataRow, ByVal columnName As String, ByVal defaultValue As T) As T
        If row.Table.Columns.Contains(columnName) Then
            Dim val = row(columnName)
            If val IsNot Nothing AndAlso val IsNot DBNull.Value Then
                Try
                    Return CType(val, T)
                Catch ex As InvalidCastException
                    Try
                        Return DirectCast(Convert.ChangeType(val, GetType(T)), T)
                    Catch
                        Return defaultValue
                    End Try
                End Try
            End If
        End If

        Return defaultValue
    End Function

    Private Shared Function TryGetDate(ByVal row As DataRow, ByVal columnName As String) As Nullable(Of Date)
        If row.Table.Columns.Contains(columnName) Then
            Dim val = row(columnName)
            If val IsNot Nothing AndAlso val IsNot DBNull.Value Then
                Dim d As Date
                If Date.TryParse(Convert.ToString(val), d) Then
                    Return d
                End If
            End If
        End If

        Return Nothing
    End Function

End Class
