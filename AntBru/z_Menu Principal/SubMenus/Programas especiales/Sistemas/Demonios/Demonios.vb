Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Demonios

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

        If Global_Thema = Enum_Themas.Oscuro Then
            Sb_Color_Botones_Barra(Bar2)
        End If

    End Sub

    Private Sub Demonios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn_Demonio_Impresion_Click(sender As Object, e As EventArgs) Handles Btn_Demonio_Impresion.Click
        Fx_Ejecutar_Demonio_Impresion(_Fm_Menu_Padre, True)
    End Sub
    Private Sub Demonio_Prestashop_Click(sender As Object, e As EventArgs) Handles Demonio_Old.Click
        Fx_Ejecutar_Demonio2(_Fm_Menu_Padre, True)
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub
End Class
