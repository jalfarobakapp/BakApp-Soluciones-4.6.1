Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Modulo_Compras

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

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub ModuloCompras_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If _Menu_Extra Then
            Btn_Asistente_Compras.Enabled = False
        End If

        Btn_Prb_Automatizaciones.Visible = (RutEmpresa = "79514800-0")

    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub BtnAsistenteCompras_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Asistente_Compras.Click

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Comp0004") Then

            If _Global_Row_Configuracion_General.Item("Incorporar_Modo_NVI_y_OCC_Asistente_Compras") Then
                Dim NewPanel As SolAsisCompraModos = Nothing
                NewPanel = New SolAsisCompraModos(_Fm_Menu_Padre)
                _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
            Else
                Dim Fm As New Frm_00_Asis_Compra_Menu(Modalidad)
                Fm.Tipo_Informe = "Asistente de compras"
                Fm.Modo_OCC = True
                Fm.ShowDialog(Me)
                Fm.Dispose()
            End If

        End If

    End Sub

    Private Sub BtnCambiarDeUsuario_Click(sender As System.Object, e As System.EventArgs) Handles BtnCambiarDeUsuario.Click

        Dim NewPanel As Login = Nothing
        NewPanel = New Login(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Right)

    End Sub

    Private Sub BtnDocumentosCompra_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Documentos_Compra.Click

        Dim NewPanel As SolCompras_Documentos = Nothing
        NewPanel = New SolCompras_Documentos(_Fm_Menu_Padre)
        _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

    End Sub

    Private Sub Btn_Recomendacion_Compra_Click(sender As Object, e As EventArgs) Handles Btn_Recomendacion_Compra.Click

        If Fx_Revisar_Taza_Cambio(_Fm_Menu_Padre) Then

            If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Prod060") Then

                Dim Fm As New Frm_Sol_Recom_Lista(Frm_Sol_Recom_Lista.Enum_Vista_Solicitudes.Todas)
                Fm.ShowDialog(Me)
                Fm.Dispose()

            End If

        End If

    End Sub

    Private Sub Btn_Asociar_Prod_Funcionarios_Click(sender As Object, e As EventArgs) Handles Btn_Asociar_Prod_Funcionarios.Click

        If Not _Global_Row_Configuracion_General.Item("Usar_Validador_Prod_X_Compras") Then
            MessageBoxEx.Show(Me, "No esta configurada la validación de productos en las compras" & vbCrLf & vbCrLf &
                              "Debe ir a la configuración general y marcar la casilla: Avisar a funcionario validador de códigos al generar OCC",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Comp0096") Then

            Dim Fm As New Frm_Prod_Vs_Funcionarios_Fun
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_OCCProveedores_Click(sender As Object, e As EventArgs) Handles Btn_OCCProveedores.Click
        Dim Fm1 As New Frm_00_Asis_Compra_Menu(Modalidad)
        Fm1.Accion_Automatica = True
        Fm1.Auto_GenerarAutomaticamenteOCCProveedores = True
        Fm1.Modo_OCC = True
        Fm1.Tipo_Informe = "Asistente de compras"
        Fm1.ShowDialog()
        Fm1.Dispose()
    End Sub

    Private Sub Btn_OCCStar_Click(sender As Object, e As EventArgs) Handles Btn_OCCStar.Click
        Dim Fm2 As New Frm_00_Asis_Compra_Menu(Modalidad)
        Fm2.Accion_Automatica = True
        Fm2.Auto_GenerarAutomaticamenteOCCProveedorStar = True
        Fm2.Modo_OCC = True
        Fm2.Tipo_Informe = "Asistente de compras"
        Fm2.ShowDialog()
        Fm2.Dispose()
    End Sub

    Private Sub Btn_NVI_Click(sender As Object, e As EventArgs) Handles Btn_NVI.Click
        Dim Fm3 As New Frm_00_Asis_Compra_Menu(Modalidad)
        Fm3.Accion_Automatica = True
        Fm3.Auto_GenerarAutomaticamenteNVI = True
        Fm3.Modo_NVI = True
        Fm3.Tipo_Informe = "Asistente de compras"
        Fm3.ShowDialog()
        Fm3.Dispose()
    End Sub

    Private Sub Btn_EjecutarTodas_Click(sender As Object, e As EventArgs) Handles Btn_EjecutarTodas.Click

        Call Btn_NVI_Click(Nothing, Nothing)
        Call Btn_OCCStar_Click(Nothing, Nothing)
        Call Btn_OCCProveedores_Click(Nothing, Nothing)

    End Sub

End Class
