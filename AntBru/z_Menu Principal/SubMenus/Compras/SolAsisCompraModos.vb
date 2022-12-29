Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class SolAsisCompraModos

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Dim _Menu_Extra As Boolean
    Public Property Pro_Menu_Extra() As Boolean
        Get
            Return _Menu_Extra
        End Get
        Set(value As Boolean)
            _Menu_Extra = value
        End Set
    End Property

    Public Sub New(Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre

    End Sub

    Private Sub Btn_Modo_OCC_Click(sender As Object, e As EventArgs) Handles Btn_Modo_OCC.Click
        Dim Fm As New Frm_00_Asis_Compra_Menu
        Fm.Tipo_Informe = "Asistente de compras"
        Fm.Modo_OCC = True
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Modo_NVI_Click(sender As Object, e As EventArgs) Handles Btn_Modo_NVI.Click
        Dim Fm As New Frm_00_Asis_Compra_Menu
        Fm.Tipo_Informe = "Asistente de compras"
        Fm.Modo_NVI = True
        Fm.Modo_OCC = False
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub
End Class
