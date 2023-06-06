Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Factura_Electronica

    Dim _Fm_Menu_Padre As Metro.MetroAppForm
    Dim _Menu_Extra As Boolean

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Pro_Menu_Extra() As Boolean
        Get
            Return _Menu_Extra
        End Get
        Set(ByVal value As Boolean)
            _Menu_Extra = value
        End Set
    End Property

    Public Sub New(Fm_Menu_Padre As Metro.MetroAppForm)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre

    End Sub

    Private Sub Factura_Electronica_Load(sender As Object, e As EventArgs) Handles Me.Load
        If _Global_Row_Configuracion_Estacion.Item("FacElect_Usar_AmbienteCertificacion") Then
            Dim _BackColor_Tido As Color = Color.FromArgb(235, 81, 13)
            MStb_Barra.BackgroundStyle.BackColor = _BackColor_Tido
            Lbl_Etiqueta.Text = "Ambiente de Certificación y Prueba"
            Btn_Pruebas.Visible = True
        End If
        'Btn_Pruebas.Visible = True
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_CAF_Click(sender As Object, e As EventArgs) Handles Btn_CAF.Click

        Dim Fm As New Frm_Folios_Caf
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Envios_DTE_Click(sender As Object, e As EventArgs) Handles Btn_Envios_DTE.Click

        Dim _Aceptar As Boolean
        Dim _Cl_MFElec As New Class_MantFacturasElect

        _Cl_MFElec.Fecha_Desde = FechaDelServidor() 'Primerdiadelmes(FechaDelServidor)
        _Cl_MFElec.Fecha_Hasta = _Cl_MFElec.Fecha_Desde

        Dim Fm As New Frm_MantFacturasElecFiltrar
        Fm.Class_MantFacturasElect = _Cl_MFElec
        Fm.ShowDialog(Me)
        _Aceptar = Fm.Aceptar
        Fm.Dispose()

    End Sub

    Private Sub Btn_Revision_Compras_SII_Click(sender As Object, e As EventArgs) Handles Btn_Revision_Compras_SII.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "RSii00001") Then

            Dim Fm As New Frm_Conf_Importar_Compras_SII
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Configuración_Click(sender As Object, e As EventArgs) Handles Btn_Configuración.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Dte00003") Then
            Dim Fm As New Frm_Dte_Configuracion
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

    End Sub

    Private Sub Btn_DiablitoDTEMonitor_Click(sender As Object, e As EventArgs) Handles Btn_DiablitoDTEMonitor.Click
        Sb_Ejecutar_DTEMonitor(_Fm_Menu_Padre, True)
    End Sub

    Private Sub Btn_Pruebas_Click(sender As Object, e As EventArgs) Handles Btn_Pruebas.Click

        Dim Fm As New Frm_FacturacionElectronica
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_DTE_Respuestas_XML_Click(sender As Object, e As EventArgs) Handles Btn_DTE_Respuestas_XML.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Mail0005") Then

            Dim Fm As New Frm_Recibir_Correos_DTE
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

End Class
