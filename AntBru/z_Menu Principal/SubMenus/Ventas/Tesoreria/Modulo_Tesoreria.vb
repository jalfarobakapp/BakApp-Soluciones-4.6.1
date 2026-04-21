Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Modulo_Tesoreria

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

        Lbl_NombreEmpresaActiva.Text = BkSpecialPrograms.RazonEmpresa

    End Sub

    Private Sub Btn_Cambiar_De_Usuario_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cambiar_De_Usuario.Click
        Dim NewPanel As Login = Nothing
        NewPanel = New Login(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Right)
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_Pago_Proveedores_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Pago_Proveedores.Click
        Dim NewPanel As Tesoreria_Proveedores = Nothing
        NewPanel = New Tesoreria_Proveedores(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_Pago_Clientes_Click(sender As Object, e As EventArgs) Handles Btn_Pago_Clientes.Click
        Dim NewPanel As Tesoreria_Clientes = Nothing
        NewPanel = New Tesoreria_Clientes(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

End Class
