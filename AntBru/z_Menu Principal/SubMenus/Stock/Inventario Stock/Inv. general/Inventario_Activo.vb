Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Inventario_Activo

    Public _Fecha_Inv_Activo As Date
    Public _Empresa_Inv_Activo, _
           _Sucursal_Inv_Activo, _
           _Bodega_Inv_Activo As String

    Public IdInventario_Activo As Integer


    Dim _Fm_Menu_Padre As Metro.MetroAppForm
    Public Sub New(ByVal Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Frm_Menu.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub BtnVerInventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVerInventario.Click

        Dim Nro As String = "In0011"

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, Nro) Then

            Dim Fm As New Frm_01_Inventario_Actual

            Fm._Fecha_Inv_Activo = _Fecha_Inv_Activo
            Fm._Empresa_Inv_Activo = _Empresa_Inv_Activo
            Fm._Sucursal_Inv_Activo = _Sucursal_Inv_Activo
            Fm._Bodega_Inv_Activo = _Bodega_Inv_Activo
            Fm._IdInventario_Activo = IdInventario_Activo

            Fm.ShowDialog(Me)

        End If

    End Sub

    Private Sub BtnIngresoHojaConteo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIngresoHojaConteo.Click
        Dim Nro As String = "In0014"
        'If Fx_Tiene_Permiso(Me, Nro) Then

        Dim Fm As New Frm_Login
        Fm.Text = "INGRESE CLAVE DE DIGITADOR DEL DOCUMENTO"
        Fm.ShowDialog(Me)

        If Not Fm.CancelarLogin Then

            Dim Fm_Inv As New Frm_01_HojaConteo
            With Fm_Inv
                ._IdInventario_Activo = IdInventario_Activo
                ._Fecha_Inventario_Gral = _Fecha_Inv_Activo
                .Digitador = FUNCIONARIO
                .Nombre_Digitador = Nombre_funcionario_activo
                ._Empresa_Inv_Activo = _Empresa_Inv_Activo
                ._Sucursal_Inv_Activo = _Sucursal_Inv_Activo
                ._Bodega_Inv_Activo = _Bodega_Inv_Activo
                '._Ano = Inventario_AnoActivo
                ' ._Mes = Inventario_MesActivo
                ' ._Dia = inventario_DiaActivo

                .ShowDialog(Me)
            End With
        Else
            MessageBox.Show("Sin acceso!!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnVerSectores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVerSectores.Click

        Dim Frm_ As New Frm_03_Sectores_Inv
        Frm_._Empresa = _Empresa_Inv_Activo
        Frm_._Sucursal = _Sucursal_Inv_Activo
        Frm_._Bodega = _Bodega_Inv_Activo
        Frm_._IngresarHoja = False
        Frm_._IdInventario = IdInventario_Activo 'SemillaUbicacion_Inv
        Frm_.ShowDialog(Me)

    End Sub
End Class
