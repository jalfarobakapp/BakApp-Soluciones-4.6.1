Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Sistema_Despachos

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

    Private Sub Btn_Ordenes_De_Despacho_Click(sender As Object, e As EventArgs) Handles Btn_Ordenes_De_Despacho.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "ODp00003") Then

            Dim Fm As New Frm_Despacho_Ordenes(Frm_Despacho_Ordenes.Enum_Ver.Todas)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_En_Proceso_Click(sender As Object, e As EventArgs) Handles Btn_En_Proceso.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "ODp00001") Then

            Dim Fm As New Frm_Despacho_Lista(Frm_Despacho_Lista.Enum_Ver.Proceso)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Configuración_Click(sender As Object, e As EventArgs) Handles Btn_Configuración.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "ODp00004") Then

            Dim Fm As New Frm_Despacho_Configuracion
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Sistema_Despachos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
