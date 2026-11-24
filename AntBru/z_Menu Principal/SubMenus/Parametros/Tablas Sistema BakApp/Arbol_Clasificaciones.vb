'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Arbol_Clasificaciones

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Public Sub New(Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre

    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click

        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub Btn_Clasificaciones_Dinamicas_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Clasificaciones_Dinamicas.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Tbl00002") Then

            Dim Fm As New Frm_Arbol_Lista(False)
            Fm.ModoConfiguracion = True
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Marca_Vehiculo_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Marca_Vehiculo.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Tbl00002") Then

            Dim Fm As New Frm_Arbol_Lista(True)
            Fm.ModoProductos = True
            Fm.ModoConfiguracion = True
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

End Class
