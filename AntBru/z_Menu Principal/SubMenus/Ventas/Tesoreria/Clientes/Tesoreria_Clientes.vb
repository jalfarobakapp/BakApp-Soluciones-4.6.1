Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Tesoreria_Clientes

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Public Sub New(Fm_Menu_Padre As Metro.MetroAppForm)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_Subir_Pagos_Click(sender As Object, e As EventArgs) Handles Btn_Subir_Pagos.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Ppro0012") Then

            If Fx_Revisar_Taza_Cambio(_Fm_Menu_Padre) Then

                Dim Fm As New Frm_Pagos_CtasEntidad_Expor_Bancos
                Fm.ShowDialog(Me)
                Fm.Dispose()

            End If

        End If

    End Sub

    Private Sub Btn_Buscar_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Documento.Click
        Dim Fm As New Frm_Tenerduria_Buscar_Documento_Pago(Frm_Tenerduria_Buscar_Documento_Pago.Enum_Tipo_Pago.Clientes, False)
        Fm.ShowDialog(_Fm_Menu_Padre)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Pago_Documentos_Click(sender As Object, e As EventArgs) Handles Btn_Pago_Documentos.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Ppro0011") Then

            If Fx_Revisar_Taza_Cambio(_Fm_Menu_Padre,, True) Then

                Dim Fm As New Frm_Pagos_Generales(Frm_Pagos_Generales.Enum_Tipo_Pago.Clientes)
                Fm.ShowDialog(Me)
                Fm.Dispose()

            End If

        End If

    End Sub

    Private Sub Btn_Liquidacion_TJV_Credito_Click(sender As Object, e As EventArgs) Handles Btn_Liquidacion_TJV_Credito.Click

        If Fx_Revisar_Taza_Cambio(_Fm_Menu_Padre,, True) Then

            Dim Fm As New Frm_LiquidTJVcredito
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

End Class
