Imports DevComponents.DotNetBar

Public Class Modulo_Informes

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Dim _Menu_Extra As Boolean
    Public Property Pro_Menu_Extra() As Boolean
        Get
            Return _Menu_Extra
        End Get
        Set(ByVal value As Boolean)
            _Menu_Extra = value
        End Set
    End Property

    Public Sub New(ByVal Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub BtnInformesVenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInformesVenta.Click

        Dim NewPanel As InformesVenta = Nothing
        NewPanel = New InformesVenta(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub BtnInfMargenes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInfMargenes.Click

        Dim NewPanel As InformesCompra = Nothing
        NewPanel = New InformesCompra(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub Btn_Informes_Espciales_Clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informes_Espciales_Clientes.Click

        Dim NewPanel As Informes_Especial_Cliente = Nothing
        NewPanel = New Informes_Especial_Cliente(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub Btn_Inf_Stock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Inf_Stock.Click
        Dim NewPanel As InformesStock = Nothing
        NewPanel = New InformesStock(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub
End Class
