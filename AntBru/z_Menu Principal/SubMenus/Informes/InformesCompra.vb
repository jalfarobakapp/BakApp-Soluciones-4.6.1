'Imports Lib_Bakapp_VarClassFunc
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class InformesCompra

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

    Private Sub Btn_Informe_Vencimiento_Compras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_Vencimiento_Compras.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Inc00001") Then
            Dim Fm As New Frm_Inf_Vencimientos_Procesar_Informe("DS_Filtro_Informe_vencimientos_compra.xml", "Inc00001")
            Fm._Informe = Frm_Inf_Vencimientos_Procesar_Informe.Tipo_Informe.Compras
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Informe_Analisis_Recepcion_vs_Despacho_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim _Analisis As New Class_Informe_Analisis_Recepcion_Vs_Despacho
        _Analisis.Sb_Generar_Reporte(_Fm_Menu_Padre, 1)
    End Sub

    Private Sub Btn_Proximas_Recepciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Proximas_Recepciones.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Inc00003") Then
            Dim Fm As New Frm_Informe_Proximas_Recepiones
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub BtnCambiarDeUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCambiarDeUsuario.Click
        Dim NewPanel As Login = Nothing
        NewPanel = New Login(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Right)
    End Sub

End Class
