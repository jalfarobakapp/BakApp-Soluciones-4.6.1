Imports BkSpecialPrograms
'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class InformesVenta

    Dim NotifyIcon1 As NotifyIcon = Frm_Menu.Notify_Informes_Venta

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Public Sub New(Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub BtnInfMargenes_Click(sender As System.Object, e As System.EventArgs) Handles BtnInfMargenes.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Inf00002") Then
            Dim Fm As New Frm_InvMargenes_
            Fm.ShowInTaskbar = False
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

    End Sub

    Private Sub BtnInfPagoProveedores_Click(sender As System.Object, e As System.EventArgs)
        'Dim Nro As String = "Inf00003"
        'If Fx_Tiene_Permiso(Me, Nro) Then
        'Dim Frm_PagoProveedores_01 As New Frm_PagoProveedores_01
        'Frm_PagoProveedores_01.ShowDialog(Me)
        'End If
    End Sub

    Private Sub BtnRankingProductos_Click(sender As System.Object, e As System.EventArgs) Handles BtnRankingProductos.Click
        Dim Nro As String = "Inf00004"
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, Nro) Then
            Dim Fm As New Frm_Ranking_Menu
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Informe_Vencimiento_Ventas_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Informe_Vencimiento_Ventas.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Inf00009") Then
            Dim Fm As New Frm_Inf_Vencimientos_Procesar_Informe("DS_Filtro_Informe_vencimientos_venta.xml", "Inf00009")
            Fm._Informe = Frm_Inf_Vencimientos_Procesar_Informe.Tipo_Informe.Ventas
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Informe_Ventas_On_Line_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Informe_Ventas_On_Line.Click
        Sb_Informe_On_Line()
    End Sub

    Private Sub InformesVenta_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AddHandler NotifyIcon1.Click, AddressOf Sb_Notifi_SolCompra_Click
    End Sub

    Private Sub Btn_Mnu_Informe_Ventas_On_Line_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Informe_Ventas_On_Line.Click
        Sb_Informe_On_Line()
    End Sub

    Sub Sb_Informe_On_Line()

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Inf00009") Then

            Dim _Tbl_Conexiones As DataTable = Fx_TblConexion_Inf_Online()

            If CBool(_Tbl_Conexiones.Rows.Count) Then

                NotifyIcon1.Visible = False
                Dim Fm As New Frm_Informe_Gerencia_On_Line(_Tbl_Conexiones)
                Fm.ShowDialog(Me)
                Fm.Dispose()
                Fm = Nothing
                NotifyIcon1.Visible = True
                NotifyIcon1.ShowBalloonTip(5, "Info. BakApp",
                                           "Menú Informes de venta On-Line quedara en la barra de tareas",
                                           ToolTipIcon.Info)
            End If

        End If

    End Sub

    Private Function Fx_TblConexion_Inf_Online() As DataTable

        Dim Fm As New Frm_Seleccion_Empresas(Frm_Seleccion_Empresas.Enum_Accion.Crear)
        If Not CBool(Fm.Pro_Tbl_Conexiones.Rows.Count) Then
            MessageBoxEx.Show(Me, "Debe configurar las empresas para la muestra del informe",
                              "Configuración de informe", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Fm.ShowDialog(Me)
        End If
        Fx_TblConexion_Inf_Online = Fm.Pro_Tbl_Conexiones
        Fm.Dispose()

    End Function

    Private Sub Sb_Notifi_SolCompra_Click(sender As System.Object, e As System.EventArgs)
        ShowContextMenu(Menu_Contextual_01)
    End Sub

    Private Sub Btn_Ventas_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ventas.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Inf00017") Then

            Dim _Fecha_Desde As Date = Primerdiadelmes(FechaDelServidor)
            Dim _Fecha_Hasta As Date = ultimodiadelmes(FechaDelServidor)

            Dim _Tabla_Matriz_Informe As String = "Zw_Informe_Venta" '"Zw_TblPaso" ' & Trim(FUNCIONARIO)

            Dim Fm As New Frm_Inf_Ventas_X_Periodo_Cubo(Frm_Inf_Ventas_X_Periodo_Cubo.Enum_Informe.Sucursal,
                                                        _Tabla_Matriz_Informe,
                                                        1,
                                                        _Fecha_Desde,
                                                        _Fecha_Hasta,
                                                        False)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Creditos_Vigentes_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Creditos_Vigentes.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Inf00018") Then
            Dim Fm As New Frm_Infor_Ent_Estado_Creditos_Vigentes
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Compromisos_No_Despachados_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Compromisos_No_Despachados.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Inf00019") Then
            Dim Fm As New Frm_Informe_Compr_No_Despachados
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Margenes_y_Proyeccion_Click(sender As Object, e As EventArgs) Handles Btn_Margenes_y_Proyeccion.Click
        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Inf00049") Then
            Dim Fm As New Frm_Inf_Mg_Vta_Proyec_Listado
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub
End Class
