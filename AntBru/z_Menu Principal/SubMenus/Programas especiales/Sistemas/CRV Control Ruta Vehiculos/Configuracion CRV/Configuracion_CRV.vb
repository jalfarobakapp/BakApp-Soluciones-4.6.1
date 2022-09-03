'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Configuracion_CRV

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

    Private Sub Btn_Marca_Vehiculo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Marca_Vehiculo.Click
        Dim NewPanel As Tablas_BakApp_Vehiculos = Nothing
        NewPanel = New Tablas_BakApp_Vehiculos(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_Vehiculos_Empresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Vehiculos_Empresa.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Crv0001") Then
            Dim Fm As New Frm_Vehiculos_Empresa_Lista
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Modelo_Vehiculos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Modelo_Vehiculos.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Crv0006") Then
            Dim Fm As New Frm_Choferes_Empresa_Lista
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub
End Class
