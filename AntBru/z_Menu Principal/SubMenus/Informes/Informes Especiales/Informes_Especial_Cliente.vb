'Imports Lib_Bakapp_VarClassFunc
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Informes_Especial_Cliente

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Public Sub New(ByVal Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre
    End Sub


    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_Creditos_Vigentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Creditos_Vigentes.Click

        Dim Fm As New Frm_Infor_Ent_Estado_Creditos_Vigentes
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Comportamiento_De_Pago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Comportamiento_De_Pago.Click

        Dim _RowEntidad As DataRow

        Dim Fm_E As New Frm_BuscarEntidad_Mt(False)
        Fm_E.ShowDialog(Me)
        _RowEntidad = Fm_E.Pro_RowEntidad
        Fm_E.Dispose()

        If Not (_RowEntidad Is Nothing) Then

            Dim Fm As New Frm_Infor_Ent_Comportamiento_De_Pago
            Fm.Pro_RowEntidad = _RowEntidad
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Informe_Cheques_En_Cartera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_Cheques_En_Cartera.Click
        Dim Fm As New Frm_Infor_Cheques_En_Cartera_X_Clientes
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub
End Class
