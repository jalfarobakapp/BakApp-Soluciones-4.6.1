Imports DevComponents.DotNetBar

Public Class Frm_SeleccionarTipoBusquedaCodProducto


    Public _Aceptado As Boolean
    Public _TipoCodigo As String
   
    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _Aceptado = False
        Me.Close()
    End Sub

    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click

        If RdbCodPrincipal.Checked Then
            _TipoCodigo = RdbCodPrincipal.Text
        ElseIf RdbCodTecnico.Checked Then
            _TipoCodigo = RdbCodTecnico.Text
        ElseIf RdbCodRapido.Checked Then
            _TipoCodigo = RdbCodRapido.Text
        ElseIf RdbCodAlternativo.Checked Then
            _TipoCodigo = RdbCodAlternativo.Text
        End If
        _Aceptado = True
        MessageBoxEx.Show("Código seleccionado: " & UCase(_TipoCodigo), "Seleccionar")
        Me.Close()

    End Sub
End Class