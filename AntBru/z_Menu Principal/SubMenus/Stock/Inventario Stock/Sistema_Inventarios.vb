Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Sistema_Inventarios

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

    Private Sub SistemaInventarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Frm_Menu.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub BtnSisinvenParcializado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSisinvenParcializado.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Invp0001") Then

            Dim Fm As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
            Fm.Pro_Empresa = ModEmpresa
            Fm.Pro_Sucursal = ModSucursal
            Fm.Pro_Bodega = ModBodega
            Fm.ShowDialog(Me)

            Dim _Seleccionado As Boolean = Fm.Pro_Seleccionado
            Dim _RowBodega As DataRow = Fm.Pro_RowBodega

            Fm.Dispose()

            If _Seleccionado Then

                Dim Fm_ As New Frm_Mt_InvParc_SelecionFechas(_RowBodega)
                Fm_.ShowInTaskbar = False
                Fm_.ShowDialog(Me)
                Fm_.Dispose()

            End If

        End If

    End Sub

    Private Sub BtnPreciosCostos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Inventario_General.Click
        'MessageBoxEx.Show(_Fm_Menu_Padre, "En construcción", "Bakapp", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Dim NewPanel As Inv_General = Nothing
        NewPanel = New Inv_General(_Fm_Menu_Padre)
        Frm_Menu.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub BtnUbicProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUbicProductos.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Ubic0001") Then

            Dim Fm As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
            Fm.Pro_Empresa = ModEmpresa
            Fm.Pro_Sucursal = ModSucursal
            Fm.Pro_Bodega = ModBodega
            Fm.ShowDialog(Me)

            If Fm.Pro_Seleccionado Then

                Dim NewPanel As Mnu_Ubic_Prod = Nothing
                NewPanel = New Mnu_Ubic_Prod(Frm_Menu)
                NewPanel._ImpDesdeInventario = False
                NewPanel._RowBodega = Fm.Pro_RowBodega
                _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

            End If

        End If

    End Sub

    Private Sub Btn_Documentos_Stock_Click(sender As Object, e As EventArgs) Handles Btn_Documentos_Stock.Click
        If Fx_Revisar_Taza_Cambio(_Fm_Menu_Padre) Then
            Dim NewPanel As Modulo_Documentos_Stock = Nothing
            NewPanel = New Modulo_Documentos_Stock(_Fm_Menu_Padre)
            _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
        End If
    End Sub

    Private Sub BtnCambiarDeUsuario_Click(sender As Object, e As EventArgs) Handles BtnCambiarDeUsuario.Click
        Dim NewPanel As Login = Nothing
        NewPanel = New Login(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Right)
    End Sub
End Class
