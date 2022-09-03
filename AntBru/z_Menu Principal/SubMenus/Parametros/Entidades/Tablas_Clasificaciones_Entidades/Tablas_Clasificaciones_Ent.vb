'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Tablas_Clasificaciones_Ent

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


    Private Sub Btn_TiposEntidades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_TiposEntidades.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Tbl00015") Then
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Tipoentidad, Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "TIPO DE ENTIDAD"
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

    End Sub

    Private Sub Btn_ActEconomica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ActEconomica.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Tbl00012") Then
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Actividade, Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "ACTIVIDAD ECONOMICA"
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

    End Sub

    Private Sub Btn_TamanoEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_TamanoEmpresa.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Tbl00013") Then
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Tamanoempr, Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "TAMAÑO EMPRESA"
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

    End Sub

    Private Sub Btn_Cargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cargo.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Tbl00019") Then
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Cargos, Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "CARGOS EMPRESARIALES"
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

    End Sub

    Private Sub Btn_AreaAct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AreaAct.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Tbl00014") Then
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Areasactiv, Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "AREAS DE ACTIVIDAD"
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

    End Sub

    Private Sub Btn_Rubro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Rubro.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Tbl00017") Then
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Rubros, Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "RUBROS"
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

    End Sub

    Private Sub Btn_PaCiCm_Click(sender As Object, e As EventArgs) Handles Btn_PaCiCm.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Tbl00047") Then
            Dim Fm As New Frm_PaCiCm_Lista
            Fm.No_Cerrar = True
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

    End Sub
End Class
