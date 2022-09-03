Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Tablas_BakApp_Vehiculos

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

    Private Sub Btn_Tipo_Vehiculos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Tipo_Vehiculos.Click

        Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Vehiculo_Tipo, _
                                                   Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
        Fm.Text = "Tabla Vehículos"
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Marca_Vehiculo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Marca_Vehiculo.Click
        Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Vehiculo_Marca, _
                                                  Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
        Fm.Text = "Tabla Marcas de Vehículos"
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Modelo_Vehiculos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Modelo_Vehiculos.Click
        Sb_Seleccionar_Marca_Para_Modelos()
    End Sub

    Sub Sb_Seleccionar_Marca_Para_Modelos()

        Dim _RowMarca As DataRow

        Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Vehiculo_Marca, _
                                                  Frm_Tabla_Caracterizaciones_01_Listado.Accion.Seleccionar)
        Fm.Text = "SELECCIONE UNA MARCA"
        Fm.ShowDialog(Me)

        _RowMarca = Fm.Pro_RowFilaSeleccionada
        Fm.Dispose()

        If Not (_RowMarca Is Nothing) Then
            Sb_Modelos_Vehiculos(_RowMarca)
        End If

    End Sub

    Sub Sb_Modelos_Vehiculos(ByVal _RowMarca As DataRow)

        Dim _CodMarca = _RowMarca.Item("CodigoTabla")
        Dim _Marca = Trim(_RowMarca.Item("NombreTabla"))

        Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Vehiculo_Modelo, _
                                                  Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
        Fm.Pro_Padre_Tabla = "VEHIC_MARCA"
        Fm.Pro_Padre_CodigoTabla = _CodMarca
        Fm.Text = "Tabla Modelos de Vehículos Marca (" & _Marca & ")"
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Seleccionar_Marca_Para_Modelos()

    End Sub

End Class
