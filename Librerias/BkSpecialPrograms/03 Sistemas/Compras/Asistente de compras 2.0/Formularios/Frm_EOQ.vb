Public Class Frm_EOQ

    Private Sub Frm_EOQ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Function Fx_EOQ(ByVal _Demanda_anual As Double, _
                    ByVal _Costo_emitir_orden As Double, _
                    ByVal _Costo_Mantencion As Double)
        Dim Pedido = Math.Round((((2 * _Demanda_anual * _Costo_emitir_orden) / _Costo_Mantencion) ^ (1 / 2)), 0)
        Return Pedido
    End Function

    Private Sub Btn_Cal_EOQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cal_EOQ.Click
        Txt_EOQ.Text = Fx_EOQ(Txt_Demanda_Anual.Text, Txt_Costo_emitir_orden.Text, Txt_Costo_Mantencion.Text)
    End Sub
End Class