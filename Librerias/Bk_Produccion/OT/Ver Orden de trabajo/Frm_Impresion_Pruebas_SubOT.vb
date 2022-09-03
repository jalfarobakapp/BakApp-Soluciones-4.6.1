Imports BkSpecialPrograms


Public Class Frm_Impresion_Pruebas_SubOT

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click

        Txt_OT.Text = Fx_Rellena_ceros(Txt_OT.Text, 10)
        Txt_SubOt.Text = Fx_Rellena_ceros(Txt_SubOt.Text, 5)

        Dim _Clas_Imp As New Clas_Impirmir_Operaciones_OT_Barras()
        _Clas_Imp.Pro_Nro_OT = Txt_OT.Text
        _Clas_Imp.Pro_Sub_OT = Txt_SubOt.Text
        _Clas_Imp.Fx_Imprimir_Archivo(Me, "HOJA DE RUTA", "", Clas_Impirmir_Operaciones_OT_Barras._Enum_Tipo_Impresion.Hoja_de_ruta)

        Txt_OT.Text = String.Empty
        Txt_SubOt.Text = String.Empty

        Txt_OT.Focus()

    End Sub

    Private Sub Btn_Operarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Operarios.Click

        Dim _Clas_Imp As New Clas_Impirmir_Operaciones_OT_Barras
        _Clas_Imp.Fx_Imprimir_Archivo(Me, "OPERARIOS", "", Clas_Impirmir_Operaciones_OT_Barras._Enum_Tipo_Impresion.Operarios)

    End Sub

    Private Sub Frm_Impresion_Pruebas_SubOT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class