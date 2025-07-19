Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class SolCompras_Documentos

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


    Private Sub Btn_OCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_OCC.Click

        Dim _RowFormato As DataRow = Fx_Formato_Modalidad(_Fm_Menu_Padre, Mod_Empresa, Mod_Modalidad, "OCC", True)

        If (_RowFormato Is Nothing) Then

            MessageBoxEx.Show(_Fm_Menu_Padre, "Debe configurar el formato de salida en la configuración por modalidad de trabajo",
                              "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Exit Sub

        End If

        Dim _Msj_Tsc As LsValiciones.Mensajes = Fx_Revisar_Tasa_Cambio(_Fm_Menu_Padre)

        If Not _Msj_Tsc.EsCorrecto Then
            Return
        End If

        Dim Fm As New Frm_Formulario_Documento("OCC", csGlobales.Enum_Tipo_Documento.Compra, False, False, True)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_GRC_Click(sender As Object, e As EventArgs) Handles Btn_GRC.Click

        Dim _Msj_Tsc As LsValiciones.Mensajes = Fx_Revisar_Tasa_Cambio(_Fm_Menu_Padre)

        If Not _Msj_Tsc.EsCorrecto Then
            Return
        End If

        Dim Fm As New Frm_Formulario_Documento("GRC", csGlobales.Enum_Tipo_Documento.Compra, False, False, True)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Recomendacion_Compra_Click(sender As Object, e As EventArgs) Handles Btn_Recomendacion_Compra.Click

        Dim _Msj_Tsc As LsValiciones.Mensajes = Fx_Revisar_Tasa_Cambio(_Fm_Menu_Padre)

        If Not _Msj_Tsc.EsCorrecto Then
            Return
        End If

        Dim Fm As New Frm_Formulario_Documento("FCC", csGlobales.Enum_Tipo_Documento.Compra, False, False, True)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

End Class
