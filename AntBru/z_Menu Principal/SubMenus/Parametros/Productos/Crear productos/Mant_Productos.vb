'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Mant_Productos

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Public Sub New(ByVal Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click

        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub BtnCP_Clasico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCP_Clasico.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Prod013") Then

            Dim Fm As New Frm_BuscarXProducto_Mt

            With Fm
                .CodProveedor_productos = String.Empty
                .Tipo_Busqueda_Productos = Fm.Buscar_En.Maestro_de_Productos
                .ListaDePrecio = ModListaPrecioVenta
                ' .BtnCrearProductos.Visible = True
                .BtnEditarProducto.Visible = True
                '.BtnEliminarProducto.Visible = True
                .ShowDialog(Me)
            End With

        End If

    End Sub

    Private Sub Mant_Productos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyValue = Keys.Escape Then
            _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
        End If

    End Sub

End Class
