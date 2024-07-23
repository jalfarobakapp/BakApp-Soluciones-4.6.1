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

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Control_Inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Cl_Inventario.Zw_Inv_Inventario

            Lbl_Nombre_Inventario.Text = .NombreInventario
            Lbl_Estatus.Text = "Fecha de inventario: " & .Fecha_Inventario

            Btn_Cerrar_Inventario.Visible = .Activo
            Btn_Abrir_Inventario.Visible = Not .Activo

        End With

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

        If Not Cl_Inventario.Zw_Inv_Inventario.Activo Then
            MessageBoxEx.Show(Me, "El inventario se encuentra cerrado, no se puede ingresar hojas de conteo", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim Fm As New Frm_IngresarHoja(_IdInventario, 0, FUNCIONARIO)
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

        If Not Fx_Validar_Inventario() Then
            Return
        End If

        Me.Enabled = False

        Dim Fm As New Frm_01_Inventario_Actual(_IdInventario)
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Me.Enabled = True

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

    Private Sub Stab_Configuracion_Click(sender As Object, e As EventArgs) Handles Stab_Configuracion.Click

        If Not Fx_Tiene_Permiso(Me, "Invg0002") Then
            SuperTabControl1.SelectedTabIndex = 0
        End If

    End Sub

    Private Sub Btn_Abrir_Inventario_Click(sender As Object, e As EventArgs) Handles Btn_Abrir_Inventario.Click

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")
        Dim _PermisoAceptado As Boolean

        If Not Fx_Tiene_Permiso(Me, "Invg0005",, , False,,,, False) Then
            Return
        End If

        Dim Fm As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Invg0005", True, False)
        Fm.Text = "INGRESE CLAVE DE AUTORIZACION"
        Fm.Pro_Cerrar_Automaticamente = True
        Fm.ShowDialog(Me)

        _PermisoAceptado = Fm.Pro_Permiso_Aceptado
        Dim _RowUsuario As DataRow = Fm.Pro_RowUsuario
        Fm.Dispose()

        If Not _PermisoAceptado Then
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Está seguro de abrir el inventario?" & vbCrLf &
                             "Recuerde que si abre el inventario, podrá realizar gestión de ingreso de hojas" & vbCrLf &
                             "de conteo y/o reconteo.", "Abrir inventario",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> Windows.Forms.DialogResult.Yes Then
            Return
        End If

        Dim _Mensaje As LsValiciones.Mensajes

        _Mensaje = Cl_Inventario.Fx_Abrir_Inventario(_NombreEquipo, _RowUsuario.Item("KOFU"))

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If _Mensaje.EsCorrecto Then
            Me.Close()
        End If

    End Sub

    Private Sub Btn_Cerrar_Inventario_Click(sender As Object, e As EventArgs) Handles Btn_Cerrar_Inventario.Click

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")
        Dim _PermisoAceptado As Boolean

        If Not Fx_Tiene_Permiso(Me, "Invg0006",, , False,,,, False) Then
            Return
        End If

        Dim Fm As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Invg0006", True, False)
        Fm.Text = "INGRESE CLAVE DE AUTORIZACION"
        Fm.Pro_Cerrar_Automaticamente = True
        Fm.ShowDialog(Me)

        _PermisoAceptado = Fm.Pro_Permiso_Aceptado
        Dim _RowUsuario As DataRow = Fm.Pro_RowUsuario
        Fm.Dispose()

        If Not _PermisoAceptado Then
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Está seguro de cerrar el inventario?" & vbCrLf &
                             "Recuerde que si cierra el inventario, no podrá realizar más gestión de ingreso de hojas" & vbCrLf &
                             "de conteo y/o reconteo.", "Cerrar inventario",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> Windows.Forms.DialogResult.Yes Then
            Return
        End If

        Dim _Mensaje As LsValiciones.Mensajes

        _Mensaje = Cl_Inventario.Fx_Cerrar_Inventario(_NombreEquipo, _RowUsuario.Item("KOFU"))

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If _Mensaje.EsCorrecto Then
            Me.Close()
        End If

    End Sub
End Class
