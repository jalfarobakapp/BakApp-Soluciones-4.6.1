Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Tesoreria_Proveedores

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Public Sub New(Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre

    End Sub

    Private Sub Btn_Pagos_Previamente_Autorizados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Pagos_Previamente_Autorizados.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Ppro0004") Then
            Dim Fm As New Frm_Pagos_Masivo_Prov_Autoriza_01_Enc 'Frm_Pagos_Generales
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_Buscar_Documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Buscar_Documento.Click
        Dim Fm As New Frm_Tenerduria_Buscar_Documento_Pago(Frm_Tenerduria_Buscar_Documento_Pago.Enum_Tipo_Pago.Proveedores, False)
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub
End Class
