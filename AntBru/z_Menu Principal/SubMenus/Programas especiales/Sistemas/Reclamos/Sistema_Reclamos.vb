Imports BkSpecialPrograms
Imports DevComponents.DotNetBar
Imports BkReclamos

Public Class Sistema_Reclamos

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

    Private Sub Btn_Ingresar_Reclamos_Click(sender As Object, e As EventArgs) Handles Btn_Ingresar_Reclamos.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Rcl00001") Then

            Dim Fm As New Frm_Rc_Lista_Reclamos(Cl_Reclamo.Enum_Estados.Ingresado)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Resolucion_Click(sender As Object, e As EventArgs) Handles Btn_Resolucion.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Rcl00003") Then

            Dim Fm As New Frm_Rc_Lista_Reclamos(Cl_Reclamo.Enum_Estados.Resolucion)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Validacion_Click(sender As Object, e As EventArgs) Handles Btn_Validacion.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Rcl00004") Then

            Dim Fm As New Frm_Rc_Lista_Reclamos(Cl_Reclamo.Enum_Estados.Validacion)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Gestionar_Reclamo_Click(sender As Object, e As EventArgs) Handles Btn_Gestionar_Reclamo.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Rcl00018") Then

            Dim Fm As New Frm_Rc_Lista_Reclamos(Cl_Reclamo.Enum_Estados.Gestionar_Reclamo)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Configuración_Click(sender As Object, e As EventArgs) Handles Btn_Configuración.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Rcl00017") Then

            Dim Fm As New Frm_Rc_Configuracion
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_Buscar_Reclamos_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Reclamos.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Rcl00016") Then

            Dim Fm As New Frm_Rc_Buscador
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

End Class
