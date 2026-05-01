Public Class Cl_Lotes_Bk

    Dim Ls_Lotes As List(Of List(Of Zw_Docu_Det_Lote))
    Dim Lote_Madre As Zw_Docu_Det_Lote

    Public Sub New(Ls_Lotes As List(Of List(Of Zw_Docu_Det_Lote)), Lote_Madre As Zw_Docu_Det_Lote)
        Me.Ls_Lotes = Ls_Lotes
        Me.Lote_Madre = Lote_Madre
    End Sub

    ' Devuelve todas las entradas Zw_Docu_Det_Lote cuyo .Id coincide con el índice de la línea.
    ' Si no existen, crea una nueva lista con un lote inicial (Id = _Index), la agrega a Ls_Lotes y la retorna.
    Function Fx_ObtenerLotesPorIndex(_Id As Integer) As List(Of Zw_Docu_Det_Lote)
        Dim resultado As New List(Of Zw_Docu_Det_Lote)

        If _Id < 0 Then
            Return resultado
        End If

        If Ls_Lotes Is Nothing Then
            Ls_Lotes = New List(Of List(Of Zw_Docu_Det_Lote))()
        End If

        For Each lista As List(Of Zw_Docu_Det_Lote) In Ls_Lotes
            If lista Is Nothing Then
                Continue For
            End If

            For Each lote As Zw_Docu_Det_Lote In lista
                If lote IsNot Nothing AndAlso lote.Id = _Id Then
                    resultado.Add(lote)
                End If
            Next
        Next

        ' Si no se encontró ningún lote, crear una nueva lista con un lote inicial y devolverla
        If resultado.Count = 0 Then

            Dim nuevoLote As New Zw_Docu_Det_Lote With {
                .Id = Lote_Madre.Id,
                .Id_Det = Lote_Madre.Id_Det,
                .Idmaeddo = Lote_Madre.Idmaeddo,
                .Idmaeedo = Lote_Madre.Idmaeedo,
                .Empresa = Lote_Madre.Empresa,
                .Sucursal = Lote_Madre.Sucursal,
                .Bodega = Lote_Madre.Bodega,
                .Tido = Lote_Madre.Tido,
                .Nudo = Lote_Madre.Nudo,
                .Codigo = Lote_Madre.Codigo,
                .Descripcion = Lote_Madre.Descripcion,
                .NroLote = Lote_Madre.NroLote,
                .SubLote = Lote_Madre.SubLote,
                .FElaboracion = Lote_Madre.FElaboracion,
                .FVencimiento = Lote_Madre.FVencimiento,
                .Rtu = Lote_Madre.Rtu,
                .Udtrans = Lote_Madre.Udtrans,
                .UnTrans = Lote_Madre.UnTrans,
                .Ud1 = Lote_Madre.Ud1,
                .Ud2 = Lote_Madre.Ud2,
                .CantUd1 = Lote_Madre.CantUd1,
                .CantUd2 = Lote_Madre.CantUd2,
                .StockUd1 = Lote_Madre.StockUd1,
                .StockUd2 = Lote_Madre.StockUd2
            }
            Dim nuevaLista As New List(Of Zw_Docu_Det_Lote)

            nuevaLista.Add(nuevoLote)

            Ls_Lotes.Add(nuevaLista)
            resultado.Add(nuevoLote)

        End If

        Return resultado
    End Function

    ' Obtiene la lista de lotes a partir de una fila del DataGridView (usa el índice de la fila).
    Function Fx_ObtenerLotesPorFila(_Fila As DataGridViewRow) As List(Of Zw_Docu_Det_Lote)
        If _Fila Is Nothing Then
            Return New List(Of Zw_Docu_Det_Lote)
        End If

        Return Fx_ObtenerLotesPorIndex(_Fila.Cells("Id").Value)
    End Function

    ' Ejemplo de uso:
    ' Dim _Lotes As List(Of Zw_Docu_Det_Lote) = Fx_ObtenerLotesPorFila(Grilla_Detalle.Rows(_Index))

End Class
