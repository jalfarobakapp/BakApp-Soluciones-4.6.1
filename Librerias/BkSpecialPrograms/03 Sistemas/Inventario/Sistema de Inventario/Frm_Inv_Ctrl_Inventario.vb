Imports DevComponents.DotNetBar

Public Class Frm_Inv_Ctrl_Inventario

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _IdInventario As Integer
    Public Property Cl_Inventario As New Cl_Inventario

    Public Sub New(_IdInventario As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._IdInventario = _IdInventario
        Cl_Inventario.Fx_Llenar_Zw_Inv_Inventario(_IdInventario)

    End Sub

    Private Sub Frm_Control_Inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Lbl_Nombre_Inventario.Text = Cl_Inventario.Zw_Inv_Inventario.NombreInventario
        Lbl_Estatus.Text = "Fecha de inventario: " & Cl_Inventario.Zw_Inv_Inventario.Fecha_Inventario

        SuperTabControl1.SelectedTabIndex = 0

    End Sub


    Private Sub Btn_Sectores_Click(sender As Object, e As EventArgs) Handles Btn_Sectores.Click

        Dim Fm As New Frm_Inv_Sector_Lista(_IdInventario)
        Fm.Text = "UBICACIONES DEL INVENTARIO: " & Cl_Inventario.Zw_Inv_Inventario.NombreInventario
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_CrearHoja_Click(sender As Object, e As EventArgs) Handles Btn_CrearHoja.Click

        If Not Fx_Validar_Inventario() Then
            Return
        End If

        Dim Fm As New Frm_IngresarHoja(_IdInventario, 0)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Btn_TomarFotoStock_Click(sender As Object, e As EventArgs) Handles Btn_TomarFotoStock.Click

        If Not Fx_Tiene_Permiso(Me, "In0006") Then
            Return
        End If

        Dim _Mensaje As LsValiciones.Mensajes
        _Mensaje = Cl_Inventario.Fx_CrearFoto(_IdInventario)

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If _Mensaje.EsCorrecto Then
            Me.Close()
        End If

    End Sub

    Private Sub Btn_EliminarFotoStock_Click(sender As Object, e As EventArgs) Handles Btn_EliminarFotoStock.Click
        If Not Fx_Tiene_Permiso(Me, "In0010") Then
            Return
        End If

        Dim _Mensaje As LsValiciones.Mensajes
        _Mensaje = Cl_Inventario.Fx_EliminarFoto(Me, _IdInventario)

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)
    End Sub

    Private Sub Btn_VerInventario_Click(sender As Object, e As EventArgs) Handles Btn_VerInventario.Click

        If Not Fx_Tiene_Permiso(Me, "In0011") Then
            Return
        End If

        If Not Fx_Validar_Inventario() Then
            Return
        End If

        Dim Fm As New Frm_01_Inventario_Actual(_IdInventario)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Contadores_Click(sender As Object, e As EventArgs) Handles Btn_Contadores.Click

        Dim Fm As New Frm_Contadores
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_InventarioXSector_Click(sender As Object, e As EventArgs) Handles Btn_InventarioXSector.Click

        If Not Fx_Validar_Inventario() Then
            Return
        End If

        Dim Fm As New Frm_Inv_Sector_Lista(_IdInventario)
        Fm.ModoRevisionInventario = True
        Fm.Text = "UBICACIONES DEL INVENTARIO: " & Cl_Inventario.Zw_Inv_Inventario.NombreInventario
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Function Fx_Validar_Inventario() As Boolean

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_FotoInventario", "IdInventario = " & _IdInventario)

        If Not CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No se ha tomado foto de inventario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Sector", "IdInventario = " & _IdInventario)

        If Not CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No se han creado sectores para este inventario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Return True

    End Function

End Class
