'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Vales_Marcar

    Public _Marcar As Boolean
    Public _Retira_Cliente As Boolean
    Public _Despacho_Domicilio As Boolean

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _Marcar = False
        Me.Close()
    End Sub

    Private Sub BtnRetiraCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRetiraCliente.Click
        _Retira_Cliente = True
        _Despacho_Domicilio = False
        _Marcar = True
        Me.Close()
    End Sub

    Private Sub BtnDespacho_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDespacho.Click
        _Retira_Cliente = False
        _Despacho_Domicilio = True
        _Marcar = True
        Me.Close()
    End Sub

    Private Sub Frm_Vales_Marcar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            _Marcar = False
            Me.Close()
        End If
    End Sub
End Class