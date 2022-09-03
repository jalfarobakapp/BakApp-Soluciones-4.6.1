Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Modulo_Documentos_Venta

    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Dim _Menu_Extra As Boolean

    Public Property Pro_Menu_Extra() As Boolean
        Get
            Return _Menu_Extra
        End Get
        Set(ByVal value As Boolean)
            _Menu_Extra = value
        End Set
    End Property

    Public Sub New(ByVal Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre

    End Sub

    Private Sub Btn_Pago_Proveedores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Fm_Post As New Frm_Formulario_Documento("NCV", csGlobales.Enum_Tipo_Documento.Nota_De_Credito, False)
        Fm_Post.ShowDialog(Me)
        Fm_Post.Dispose()
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_Cotizacion_Click(sender As Object, e As EventArgs) Handles Btn_Cotizacion.Click
        Dim _Tido = "COV"
        Modulo_Documentos.Sb_Generar_Documento(_Fm_Menu_Padre, _Tido, True, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Venta, "")
    End Sub

    Private Sub Btn_Boleta_Click(sender As Object, e As EventArgs) Handles Btn_Boleta.Click
        Dim _Tido = "BLV"
        Modulo_Documentos.Sb_Generar_Documento(_Fm_Menu_Padre, _Tido, True, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Venta, "")
    End Sub

    Private Sub Btn_Nota_De_Venta_Click(sender As Object, e As EventArgs) Handles Btn_Nota_De_Venta.Click
        Dim _Tido = "NVV"
        Modulo_Documentos.Sb_Generar_Documento(_Fm_Menu_Padre, _Tido, True, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Venta, "")
    End Sub

    Private Sub Btn_Factura_Click(sender As Object, e As EventArgs) Handles Btn_Factura.Click
        Dim _Tido = "FCV"
        Modulo_Documentos.Sb_Generar_Documento(_Fm_Menu_Padre, _Tido, True, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Venta, "")
    End Sub

    Private Sub Btn_Nota_De_Credito_Click(sender As Object, e As EventArgs) Handles Btn_Nota_De_Credito.Click
        Dim _Tido = "NCV"
        Modulo_Documentos.Sb_Generar_Documento(_Fm_Menu_Padre, _Tido, True, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Venta, "")
    End Sub

    Private Sub Btn_Guias_Click(sender As Object, e As EventArgs) Handles Btn_Guias.Click
        Dim _Tido = "GDV"
        Modulo_Documentos.Sb_Generar_Documento(_Fm_Menu_Padre, _Tido, True, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Venta, "")
    End Sub

    Sub Sb_Generar_Documento(_Tido As String, _Minimizar As Boolean)

        If Fx_Revisar_Taza_Cambio(_Fm_Menu_Padre) Then

            Dim _RowFormato As DataRow = Fx_Formato_Modalidad(_Fm_Menu_Padre, Modalidad, _Tido, True)

            If Not IsNothing(_RowFormato) Then

                Dim _Empresa As String = ModEmpresa
                Dim _Sucursal As String = ModSucursal
                Dim _Bodega As String = ModBodega

                Dim _Permiso = "Bo" & _Empresa & _Sucursal & _Bodega

                If Not Fx_Tiene_Permiso(_Fm_Menu_Padre, _Permiso, , True) Then
                    Dim _Bod = _Global_Row_Configuracion_Estacion.Item("NOKOBO")
                    MessageBoxEx.Show(Me, "NO ESTA AUTORIZADO PARA EFECTUAR VENTAS DESDE LA BODEGA DE ESTA MODALIDAD" & vbCrLf & vbCrLf &
                                      "BODEGA: " & _Bodega & " - " & _Bod,
                                      "VALIDACION",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                If Fx_Tiene_Permiso(_Fm_Menu_Padre, _Permiso) Then

                    If Fx_Es_Electronico(_Tido) Then

                        Dim _Directorio_GenDTE As String = _Global_Row_EstacionBk.Item("Directorio_GenDTE")
                        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

                        Fx_Datos_Directorio_GenDTE(_Directorio_GenDTE, _NombreEquipo)

                    End If

                    Dim Fm_Post As New Frm_Formulario_Documento(_Tido, csGlobales.Enum_Tipo_Documento.Venta, False)
                    If _Fm_Menu_Padre.Name <> "Frm_Menu_Extra" Then Fm_Post.MinimizeBox = True
                    Fm_Post.MinimizeBox = _Minimizar
                    Fm_Post.ShowDialog(Me)
                    Fm_Post.Dispose()

                End If

            End If

        Else

            MessageBoxEx.Show(Me, "Debe configurar el formato de salida en la configuración por modalidad de trabajo",
                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub Btn_Guia_Recepcion_Devoluciones_Click(sender As Object, e As EventArgs) Handles Btn_Guia_Recepcion_Devoluciones.Click
        Dim _Tido = "GRD"
        Modulo_Documentos.Sb_Generar_Documento(_Fm_Menu_Padre, _Tido, True, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Compra, "")
    End Sub

    Private Sub Btn_Nota_De_Debito_Click(sender As Object, e As EventArgs) Handles Btn_Nota_De_Debito.Click
        MessageBoxEx.Show(_Fm_Menu_Padre, "En construcción",
                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return
        Dim _Tido = "FDV"
        Modulo_Documentos.Sb_Generar_Documento(_Fm_Menu_Padre, _Tido, True, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Venta, "")
    End Sub
End Class
