Public Class Cl_Lotes_Bk

    Dim Ls_Lotes As List(Of List(Of Zw_Docu_Det_Lote))
    Dim Lote_Madre As Zw_Docu_Det_Lote

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

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
                .Id_LoteOri = Lote_Madre.Id_LoteOri,
                .Id_Det = Lote_Madre.Id_Det,
                .Idmaeddo = Lote_Madre.Idmaeddo,
                .Idmaeedo = Lote_Madre.Idmaeedo,
                .Idmaeddo_Ori = Lote_Madre.Idmaeddo_Ori,
                .Tido_Ori = Lote_Madre.Tido_Ori,
                .Nudo_Ori = Lote_Madre.Nudo_Ori,
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

    Function Fx_Lotes_XProductoBD(_Idmaeddo As Integer) As List(Of Zw_Docu_Det_Lote)

        Consulta_sql = $"
Select Id, Id_Det, Id_LoteOri, Idmaeddo, Idmaeedo, Idmaeddo_Ori, Tido_Ori, Nudo_Ori, Empresa, 
Sucursal, Bodega, Tido, Nudo, Codigo, Descripcion, NroLote, SubLote, FElaboracion, FVencimiento, 
CantUd1, CantUd2, 
CantExUd1, CantExUd2,UD01PR As 'Ud1',UD02PR As 'Ud2'
    From {_Global_BaseBk}Zw_Docu_Det_Lote Dtl
        Left Join MAEDDO Ddo On Ddo.IDMAEDDO = Dtl.Idmaeddo
Where Idmaeddo = {_Idmaeddo}"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim resultado As New List(Of Zw_Docu_Det_Lote)

        For Each row As DataRow In _Tbl.Rows
            If row("Idmaeddo") IsNot DBNull.Value AndAlso Convert.ToInt32(row("Idmaeddo")) = _Idmaeddo Then
                Dim lote As New Zw_Docu_Det_Lote With {
                    .Id = Convert.ToInt32(row("Id")),
                    .Id_Det = Convert.ToInt32(row("Id_Det")),
                    .Id_LoteOri = Convert.ToInt32(row("Id_LoteOri")),
                    .Idmaeddo = Convert.ToInt32(row("Idmaeddo")),
                    .Idmaeedo = Convert.ToInt32(row("Idmaeedo")),
                    .Idmaeddo_Ori = Convert.ToInt32(row("Idmaeddo_Ori")),
                    .Tido_Ori = row("Tido_Ori").ToString(),
                    .Nudo_Ori = row("Nudo_Ori").ToString(),
                    .Empresa = row("Empresa").ToString(),
                    .Sucursal = row("Sucursal").ToString(),
                    .Bodega = row("Bodega").ToString(),
                    .Tido = row("Tido").ToString(),
                    .Nudo = row("Nudo").ToString(),
                    .Codigo = row("Codigo").ToString(),
                    .Descripcion = row("Descripcion").ToString(),
                    .NroLote = row("NroLote").ToString(),
                    .SubLote = row("SubLote").ToString(),
                    .FElaboracion = If(row("FElaboracion") IsNot DBNull.Value, Convert.ToDateTime(row("FElaboracion")), DateTime.MinValue),
                    .FVencimiento = If(row("FVencimiento") IsNot DBNull.Value, Convert.ToDateTime(row("FVencimiento")), DateTime.MinValue),
                    .Ud1 = row("Ud1").ToString(),
                    .Ud2 = row("Ud2").ToString(),
                    .CantUd1 = If(row("CantUd1") IsNot DBNull.Value, Convert.ToDecimal(row("CantUd1")), 0),
                    .CantUd2 = If(row("CantUd2") IsNot DBNull.Value, Convert.ToDecimal(row("CantUd2")), 0),
                    .CantExUd1 = If(row("CantExUd1") IsNot DBNull.Value, Convert.ToDecimal(row("CantExUd1")), 0),
                    .CantExUd2 = If(row("CantExUd2") IsNot DBNull.Value, Convert.ToDecimal(row("CantExUd2")), 0)
                }
                resultado.Add(lote)
            End If
        Next

        Return resultado
    End Function

End Class
