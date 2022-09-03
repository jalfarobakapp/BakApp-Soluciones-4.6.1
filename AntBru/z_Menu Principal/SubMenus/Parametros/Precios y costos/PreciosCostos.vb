'Imports Lib_Bakapp_VarClassFunc
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class PreciosCostos

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

    Private Sub BtnActuCostosVILLAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActuCostosVILLAR.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Espr0002") Then
            'Dim FO As New Frm_CargarLista_VillarHnos
            'FO.StartPosition = FormStartPosition.CenterScreen
            'FO.ShowInTaskbar = False
            'FO.ShowDialog(Me)
        Else

            MensajeSinPermiso("Espr0002")

        End If
    End Sub

    Private Sub MetroTileItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTileItem1.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Pre0008") Then

            Dim NewPanel As Modulo_Lista_Precios_Costos = Nothing
            NewPanel = New Modulo_Lista_Precios_Costos(_Fm_Menu_Padre)
            _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

        End If

    End Sub
End Class
