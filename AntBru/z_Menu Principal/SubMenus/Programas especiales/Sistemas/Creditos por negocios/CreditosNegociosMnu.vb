Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class CreditosNegociosMnu

    Dim _DsNegocioCr As New DsNegocioCr
    Dim _Dir_Temp = AppPath() & "\Data\" & RutEmpresa & "\Tmp\Negocios_Cli"
    ' Dim _Path = AppPath() & "\Data\Negocios_Cli\Config_Estacion_Negocios_Cli.xml"
    Dim _Existe = System.IO.File.Exists(_Dir_Temp & "\Config_Estacion_Negocios_Cli.xml")

    'Dim Fm_Ng As New Frm_SolCredito_Listado
    Dim NotifyIcon1 As NotifyIcon = Frm_Menu.Notify_Creditos_Negocios

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Public Sub New(ByVal Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click

        Frm_Menu.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub BtnConfiguracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConfiguracion.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Scn00002") Then

            Dim Fm As New Frm_SolCredito_Configuracion
            Fm.ShowDialog(Me)
            Fm.Dispose()
            If String.IsNullOrEmpty(Fx_Directorio()) Then
                _Existe = False
            End If

        End If

    End Sub

    Private Sub Btn_Resolucion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Resolucion.Click
        Sb_Gestion_Comite()
    End Sub

    Private Function Fx_Directorio() As String

        Dim _Dir = String.Empty
        _DsNegocioCr.ReadXml(_Dir_Temp & "\Config_Estacion_Negocios_Cli.xml")

        Dim _Fila As DataRow = _DsNegocioCr.Tables("Tbl_Configuracion_local").Rows(0)
        _Dir = _Fila.Item("Direcctorio_Archivos_Adjuntos")

        Return _Dir

    End Function

    Private Sub CreditosNegociosMnu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If _Existe Then
            If String.IsNullOrEmpty(Fx_Directorio()) Then
                _Existe = False
            End If
            AddHandler NotifyIcon1.Click, AddressOf Sb_Notifi_SolCompra_Click
        End If

    End Sub

    Private Sub Btn_Mis_SCN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mis_SCN.Click
        Sb_Gestion_Dpto_Cto()
    End Sub

    Private Function Fx_CheckForm(ByVal _form As Form) As Form

        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return f
            End If
        Next

        Return Nothing

    End Function

    Sub Sb_Gestion_Dpto_Cto()

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Scn00011") Then

            If _Existe Then
                NotifyIcon1.Visible = False
                Dim Fm_Ng As New Frm_SolCredito_Listado
                Fm_Ng.Pro_Directorio_Seleccionado = Fx_Directorio()
                Fm_Ng.Pro_Tipo_Informe = Frm_SolCredito_Listado._Filtro_Negocios.Mis_Negocios
                Fm_Ng.ShowDialog(Me)
                Fm_Ng.Dispose()
                Fm_Ng = Nothing
                NotifyIcon1.Visible = True
                NotifyIcon1.ShowBalloonTip(5, "Info. BakApp", "Menú crédito por negocios quedara en la barra de tareas", ToolTipIcon.Info)
            Else
                MessageBoxEx.Show(Me, "Falta la configuración local", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

    End Sub

    Sub Sb_Gestion_Comite()

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Scn00010") Then

            If _Existe Then

                NotifyIcon1.Visible = False
                Dim Fm_Ng As New Frm_SolCredito_Listado
                Fm_Ng.Pro_Directorio_Seleccionado = Fx_Directorio()
                Fm_Ng.Pro_Tipo_Informe = Frm_SolCredito_Listado._Filtro_Negocios.Resolucion
                'Fm_Ng.NotifyIcon1.Visible = False
                Fm_Ng.ShowDialog(Me)
                Fm_Ng.Dispose()
                Fm_Ng = Nothing
                NotifyIcon1.Visible = True
                NotifyIcon1.ShowBalloonTip(5, "Info. BakApp", "Solicitud de compra quedara en barra de tareas", ToolTipIcon.Info)

            Else

                MessageBoxEx.Show(Me, "Falta la configuración local", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return

            End If

        End If

    End Sub

    Private Sub Sb_Notifi_SolCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ShowContextMenu(Menu_Contextual_01)

    End Sub

    Private Sub Btn_Mnu_Departamento_Credito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Departamento_Credito.Click

        Sb_Gestion_Dpto_Cto()

    End Sub

    Private Sub Btn_Mnu_Autorizar_Solicitudes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Autorizar_Solicitudes.Click

        Sb_Gestion_Comite()

    End Sub
End Class
