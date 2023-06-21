'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Entidades_menu

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

    Private Sub Btn_MantEntidades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_MantEntidades.Click

        Dim Fm1 As New Fm_BuscarEntidades
        Fm1.ShowDialog(Me)
        Fm1.Dispose()
        Return
        Dim Nro = "CfEnt001"
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, Nro) Then
            Dim Fm As New Frm_BuscarEntidad_Mt(False)
            Fm.Pro_Crear_Entidad = True
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_EntExcuidas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EntExcuidas.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "CfEnt016") Then
            Dim Fm As New Frm_EntExcluidas
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Tablas_Conf_Entidad_Click(sender As Object, e As EventArgs) Handles Btn_Tablas_Conf_Entidad.Click
        Dim NewPanel As Tablas_Clasificaciones_Ent = Nothing
        NewPanel = New Tablas_Clasificaciones_Ent(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

End Class
