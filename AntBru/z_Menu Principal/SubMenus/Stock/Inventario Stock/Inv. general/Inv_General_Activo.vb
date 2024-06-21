Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Inv_General_Activo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Dim _Row_InventarioActivo As DataRow

    Public Sub New(Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Inv_Inventario Where Estado = 1"
        _Row_InventarioActivo = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub
    Private Sub Inv_General_Activo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Lbl_InventarioActivo.Text = _Row_InventarioActivo.Item("Nombreinventario")
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Frm_Menu.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_VerInventarioActivo_Click(sender As Object, e As EventArgs) Handles Btn_VerInventarioActivo.Click

        If Not Fx_Tiene_Permiso(_Fm_Menu_Padre, "In0011") Then
            Return
        End If

        Dim _Id As Integer = _Row_InventarioActivo.Item("Id")

        Dim Fm As New Frm_01_Inventario_Actual(_Id)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub BtnConfiguracion_Click(sender As Object, e As EventArgs) Handles BtnConfiguracion.Click

        Dim _Id As Integer = _Row_InventarioActivo.Item("Id")

        Dim Fm As New Frm_Inv_Ctrl_Inventario(_Id)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub


End Class
