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

        ButtonItem2.Visible = (RutEmpresa = "79514800-0")
        ButtonItem3.Visible = (RutEmpresa = "79514800-0")

    End Sub

    Private Sub Btn_Modo_OCC_Click(sender As Object, e As EventArgs) Handles Btn_Modo_OCC.Click
        Dim Fm As New Frm_00_Asis_Compra_Menu(Modalidad)
        Fm.Tipo_Informe = "Asistente de compras"
        Fm.Modo_OCC = True
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Modo_NVI_Click(sender As Object, e As EventArgs) Handles Btn_Modo_NVI.Click
        Dim Fm As New Frm_00_Asis_Compra_Menu(Modalidad)
        Fm.Tipo_Informe = "Asistente de compras"
        Fm.Modo_NVI = True
        Fm.Modo_OCC = False
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click
        Dim Fm As New Frm_00_Asis_Compra_Menu(Modalidad)
        Fm.Tipo_Informe = "Asistente de compras Configuración de OCC automatizadas"
        Fm.Modo_OCC = True
        Fm.Modo_ConfAuto = True
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub ButtonItem3_Click(sender As Object, e As EventArgs) Handles ButtonItem3.Click
        Dim Fm As New Frm_00_Asis_Compra_Menu(Modalidad)
        Fm.Tipo_Informe = "Asistente de compras Configuración de NVI automatizadas"
        Fm.Modo_NVI = True
        Fm.Modo_OCC = False
        Fm.Modo_ConfAuto = True
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

End Class
