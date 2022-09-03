'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class CRV_Control_Ruta_Vehiculos

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

    Private Sub Btn_Configuracion_CRV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Configuracion_CRV.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Crv0013") Then

            Dim NewPanel As Configuracion_CRV = Nothing
            NewPanel = New Configuracion_CRV(_Fm_Menu_Padre)
            _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

        End If

    End Sub

    Private Sub Btn_CRV_Control_Ruta_Vehiculos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_CRV_Control_Ruta_Vehiculos.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Crv0012") Then

            Dim Fm As New Frm_CRV_Lista
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

End Class
