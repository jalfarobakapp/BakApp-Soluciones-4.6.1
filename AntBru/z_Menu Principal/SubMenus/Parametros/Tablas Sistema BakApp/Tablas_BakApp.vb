'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Tablas_BakApp

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

    Private Sub Btn_Arbol_Clasificaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Arbol_Clasificaciones.Click
        Dim NewPanel As Arbol_Clasificaciones = Nothing
        NewPanel = New Arbol_Clasificaciones(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_Marca_Vehiculo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Marca_Vehiculo.Click
        Dim NewPanel As Tablas_BakApp_Vehiculos = Nothing
        NewPanel = New Tablas_BakApp_Vehiculos(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

End Class
