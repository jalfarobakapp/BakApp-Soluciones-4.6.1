Imports BkSpecialPrograms
Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc
Imports System.IO

Public Class Sis_ValesDespacho

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

    Private Sub BtnModCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModCaja.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Vale0003") Then
            Dim NewPanel As ModCaja_01 = Nothing
            NewPanel = New ModCaja_01(_Fm_Menu_Padre)
            _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
        End If

    End Sub

    Private Sub Btn_Retiro_Despacho_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Retiro_Despacho.Click

        If Not Directory.Exists(AppPath() & "\Data\" & RutEmpresa & "\Vales_despacho") Then

            Beep()
            ToastNotification.Show(Me, "DEBE CONFIGURAR LA ESTACION DE TRABAJO", My.Resources.cross,
                                   3 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            Return

        End If

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Vale0002") Then

            Dim _Retira_Cliente As Boolean = Fx_Tiene_Permiso(_Fm_Menu_Padre, "Vale0006", , True)
            Dim _Despacho_domic As Boolean = Fx_Tiene_Permiso(_Fm_Menu_Padre, "Vale0007", , True)
            Dim _Ambos As Boolean

            If Not _Retira_Cliente And Not _Despacho_domic Then
                MessageBoxEx.Show(Me, "No tiene permiso para ver los listados", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Fx_Tiene_Permiso(_Fm_Menu_Padre, "Vale0006")
                Fx_Tiene_Permiso(_Fm_Menu_Padre, "Vale0007")

                Return
            End If

            If _Retira_Cliente And _Despacho_domic Then _Ambos = True

            Dim Fm As New Frm_Vales_Listado_Espera

            If _Ambos Then
                Fm.Rdb_Ambos.Checked = True
            Else
                Fm.Rdb_Retira_Cliente.Enabled = _Retira_Cliente
                Fm.Rdb_Despacho_Domicilio.Enabled = _Despacho_domic
                Fm.Rdb_Ambos.Enabled = False
            End If


            Fm.ShowDialog(Me)

        End If
    End Sub

    Private Sub BtnConfiguracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConfiguracion.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Vale0018") Then
            Dim Fm As New Frm_Configuracion_vales
            Fm.ShowDialog(Me)
        End If

    End Sub

End Class
