'Imports Lib_Bakapp_VarClassFunc
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Modulo_Parametros

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

    Private Sub BtnCreacionEntidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreacionEntidad.Click
        'If Licencia_Modulo("ENT01") Then
        Dim NewPanel As Entidades_menu = Nothing
        NewPanel = New Entidades_menu(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
        'End If
    End Sub

    Private Sub BtnProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProductos.Click
        'If Licencia_Modulo("PRD01") Then
        Dim NewPanel As Productos = Nothing
        NewPanel = New Productos(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
        'End If
    End Sub


    Private Sub Btn_Tablas_Conf_Entidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Tablas_Conf_Entidad.Click
        Dim NewPanel As Tablas_Clasificaciones_Ent = Nothing
        NewPanel = New Tablas_Clasificaciones_Ent(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_Tablas_Conf_Productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Tablas_Conf_Productos.Click
        Dim NewPanel As Tablas_Clasificaciones_Pro = Nothing
        NewPanel = New Tablas_Clasificaciones_Pro(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_Tablas_BakApp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Tablas_BakApp.Click
        Dim NewPanel As Tablas_BakApp = Nothing
        NewPanel = New Tablas_BakApp(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_PaCiCm_Click(sender As Object, e As EventArgs)

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Tbl00047") Then
            Dim Fm As New Frm_PaCiCm_Lista
            Fm.No_Cerrar = True
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

    End Sub

    Private Sub Btn_Momendas_Click(sender As Object, e As EventArgs) Handles Btn_Momendas.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Espr0032") Then

            Dim Fm As New Frm_MonedasLista
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub
End Class
