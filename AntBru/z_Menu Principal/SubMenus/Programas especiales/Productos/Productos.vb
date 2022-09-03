Imports Funciones_BakApp
Imports BkSpecialPrograms
Public Class Productos

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Frm_Menu.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_CambiarCodProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_CambiarCodProducto.Click
        Dim Nro As Integer = 31
        If TienePermiso(Nro) Then
            Dim Frm_Esp_CambiarCodProducto As New Frm_Esp_CambiarCodProducto
            Frm_Esp_CambiarCodProducto.ShowDialog(Me)
        Else
            MensajeSinPermiso(Nro)
        End If
    End Sub

    Private Sub Btn_CrearProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_CrearProducto.Click
        MnuEspecialProductos.Enabled = False
        Dim Nro As Integer = 28
        If TienePermiso(Nro) Then
            NewCodigoProducto = ""
            NewDescripcionProducto = ""
            CodAlternativoProveedorProducto = ""
            Codigo_abuscar = ""

            NewRtuProducto = 1

            Dim Fm As New Frm_MtCreacionDeProducto
            Fm.ShowInTaskbar = False
            Fm.Txtcodigoprincipal.Focus()
            Fm.ShowDialog(Me)
     
        End If
        MnuEspecialProductos.Enabled = True
    End Sub

    Private Sub Btn_CodAlternativo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_CodAlternativo.Click
        Dim Nro As Integer = 32
        If TienePermiso(Nro) Then
            NewCodigoProducto = ""
            TipoBusquedaproductos = "AMBOS"
            Dim Frm_CreacionDeProductoAlternativo As New Frm_CreacionDeProductoAlternativo
            Frm_CreacionDeProductoAlternativo.ShowDialog(Me)
        Else
            MensajeSinPermiso(Nro)
        End If
    End Sub

    Private Sub Btn_OcultarPr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_OcultarPr.Click
        Dim Nro As String = "Esp0006"
        If TienePermiso(Nro) Then
            Dim Frm_OcultarPr As New Frm_OcultarPr
            Frm_OcultarPr.ShowDialog(Me)
        Else
            MensajeSinPermiso(Nro)
        End If
    End Sub

    Private Sub BtnEstProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEstProducto.Click
        Dim Nro As String = "Ifp0001"
        If TienePermiso(Nro) Then
            Dim Frm_01_InfProducto As New Frm_01_InfProducto
            Frm_01_InfProducto.ShowDialog(Me)
        Else
            MensajeSinPermiso(Nro)
        End If
    End Sub

    Private Sub Btn_CrearProductoMatriz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_CrearProductoMatriz.Click
        MnuEspecialProductos.Enabled = False
        Dim Nro As String = "Prod007"
        If TienePermiso(Nro) Then
            Dim Fm As New Frm_CreaProductos_01
            Fm.VieneDesdeSolicitud = False
            Fm.ShowInTaskbar = False
            Fm.FormBorderStyle = FormBorderStyle.FixedDialog

            Fm.ShowDialog(Me)

        Else
            MensajeSinPermiso(Nro)
        End If
        MnuEspecialProductos.Enabled = True
    End Sub

    Private Sub BtnUbicProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUbicProductos.Click
        Dim Fr As New Frm_01_UbicXpro
        Fr.ShowDialog(Me)
    End Sub

    Private Sub BtnUnificarProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnificarProductos.Click
        Dim Nro As String = "Prod006"
        If TienePermiso(Nro) Then
            Dim Frm_UnificacionProducto As New Frm_UnificacionProducto
            Frm_UnificacionProducto.ShowInTaskbar = False
            Frm_UnificacionProducto.ShowDialog(Me)
        Else
            MensajeSinPermiso(Nro)
        End If
    End Sub

    Private Sub BtnCodBusquedAvanzada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCodBusquedAvanzada.Click
        Dim Nro As String = "Prod009"
        If TienePermiso(Nro) Then
            Dim FrmBa As New Frm_MtCreaProd_01_IngBusqEspecial
            FrmBa.ShowInTaskbar = False
            FrmBa.ShowDialog(Me)
        End If
    End Sub

    Private Sub BtnCondultaIntegradaStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCondultaIntegradaStock.Click
        Dim Fm As New Frm_DocumentoLista
        Fm.ShowDialog(Me)
    End Sub

    Private Sub BtnEtiquetasDeBarra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEtiquetasDeBarra.Click
        Dim Nro As String = "Espr0003"
        If TienePermiso(Nro) Then
            Dim Fm As New Frm_ImpBarras_MenuPrincipal
            Fm.ShowDialog(Me)
        End If
    End Sub
End Class
