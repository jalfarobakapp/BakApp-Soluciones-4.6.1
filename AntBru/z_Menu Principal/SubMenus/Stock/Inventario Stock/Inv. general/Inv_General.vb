Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Inv_General

    Dim _Sql As New Class_SQL(Consulta_sql)
    Dim Consulta_sql As String

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Public Sub New(Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre

    End Sub


    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Frm_Menu.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub BtnConfiguracion_Click(sender As System.Object, e As System.EventArgs) Handles BtnConfiguracion.Click
        Dim NewPanel As Inv_General_Conf = Nothing
        NewPanel = New Inv_General_Conf
        Frm_Menu.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_Mant_Inventarios_Click(sender As Object, e As EventArgs) Handles Btn_Mant_Inventarios.Click

        Dim Fm As New Frm_Inv_Inventarios
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub
End Class
