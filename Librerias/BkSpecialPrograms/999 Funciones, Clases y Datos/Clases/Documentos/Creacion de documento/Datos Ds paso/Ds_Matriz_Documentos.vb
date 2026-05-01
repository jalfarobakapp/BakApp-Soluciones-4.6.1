

Partial Class Ds_Matriz_Documentos
    Partial Public Class Encabezado_DocDataTable
        Private Sub Encabezado_DocDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.Cn_TipoCompraColumn.ColumnName) Then
                'Agregar código de usuario aquí
            End If

        End Sub

    End Class

    Partial Public Class Detalle_DocDataTable


    End Class
End Class
