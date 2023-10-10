Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class STConfiguracion
    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Dim _Menu_Extra As Boolean
    Public Property Pro_Menu_Extra() As Boolean
        Get
            Return _Menu_Extra
        End Get
        Set(value As Boolean)
            _Menu_Extra = value
        End Set
    End Property

    Public Sub New(Fm_Menu_Padre As Metro.MetroAppForm)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_Mantencion_Tecnicos_Click(sender As Object, e As EventArgs) Handles Btn_Mantencion_Tecnicos.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Stec0006") Then
            Dim Fm As New Frm_St_Lista_Tecnicos_Talleres
            Fm.ShowDialog(_Fm_Menu_Padre)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Conf_Info_Reportes_Click(sender As Object, e As EventArgs) Handles Btn_Conf_Info_Reportes.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Stec0015") Then
            Dim Fm As New Frm_St_Notas_Reportes
            Fm.ShowDialog(_Fm_Menu_Padre)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Recetas_Click(sender As Object, e As EventArgs) Handles Btn_Recetas.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Stec0025") Then
            Dim Fm As New Frm_St_Recetas
            Fm.ShowDialog(_Fm_Menu_Padre)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Operaciones_Click(sender As Object, e As EventArgs) Handles Btn_Operaciones.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Stec0021") Then
            Dim Fm As New Frm_St_Operaciones
            Fm.ShowDialog(_Fm_Menu_Padre)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_FiltroProductos_Click(sender As Object, e As EventArgs) Handles Btn_FiltroProductos.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Stec0029") Then
            Dim Fm As New Frm_St_Mant_ProdServTecnico
            Fm.ShowDialog(_Fm_Menu_Padre)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_BodegaServicio_Click(sender As Object, e As EventArgs) Handles Btn_BodegaServicio.Click

        If Not Fx_Tiene_Permiso(_Fm_Menu_Padre, "Stec0030") Then
            Return
        End If

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_Sql As String

        Dim _ServTecnico_Empresa As String = _Global_Row_Configuracion_Estacion.Item("ServTecnico_Empresa").ToString.Trim
        Dim _ServTecnico_Sucursal As String = _Global_Row_Configuracion_Estacion.Item("ServTecnico_Sucursal").ToString.Trim
        Dim _ServTecnico_Bodega As String = _Global_Row_Configuracion_Estacion.Item("ServTecnico_Bodega").ToString.Trim

        If String.IsNullOrWhiteSpace(_ServTecnico_Empresa) Then
            _ServTecnico_Empresa = ModEmpresa
            _ServTecnico_Sucursal = ModSucursal
        End If

        Dim Fm As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
        Fm.Pro_Empresa = _ServTecnico_Empresa
        Fm.Pro_Sucursal = _ServTecnico_Sucursal
        Fm.Pro_Bodega = _ServTecnico_Bodega
        Fm.ShowDialog(Me)

        If Fm.Pro_Seleccionado Then

            Dim _RowBodega As DataRow = Fm.Pro_RowBodega

            _ServTecnico_Empresa = _RowBodega.Item("EMPRESA")
            _ServTecnico_Sucursal = _RowBodega.Item("KOSU")
            _ServTecnico_Bodega = _RowBodega.Item("KOBO")

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Configuracion Set " & vbCrLf &
                           "ServTecnico_Empresa = '" & _ServTecnico_Empresa & "'" &
                           ",ServTecnico_Sucursal = '" & _ServTecnico_Sucursal & "'" &
                           ",ServTecnico_Bodega = '" & _ServTecnico_Bodega & "'" & vbCrLf &
                           "Where Modalidad = '" & Modalidad & "'"
            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Bodega de servicio técnico para la modalidad",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub
End Class
