Imports System.IO
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar
Public Class Frm_Conexiones

    Private _Cl_ConfiguracionLocal As New Cl_ConfiguracionLocal

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Conexiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Mensaje As New LsValiciones.Mensajes
        _Mensaje = _Cl_ConfiguracionLocal.Fx_LeerArchivoConexionJson(False)

        If Not _Mensaje.EsCorrecto OrElse _Mensaje.Id = 0 Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Dim _Arr_Relacionado(,) As String = {{"", ""},
                                     {"BLV", "BOLETA"},
                                     {"FCV", "FACTURA"}}
        Sb_Llenar_Combos(_Arr_Relacionado, Cmb_DocEmitir)
        Cmb_DocEmitir.SelectedValue = ""


        Txt_Global_BaseBk.Text = _Cl_ConfiguracionLocal.Configuracion.Global_BaseBk

        With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones

            With .Item(0)
                .NombreConexion = String.Empty
                Txt_Rd_Host.Text = .Host
                Txt_Rd_Puerto.Text = .Puerto
                Txt_Rd_Usuario.Text = .Usuario
                Txt_Rd_Password.Text = .Password
                Txt_Rd_Basededatos.Text = .Basededatos
            End With

            With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones.Item(0)
                Cadena_ConexionSQL_Server = _Cl_ConfiguracionLocal.Fx_CadenaConexion(.Host, .Puerto, .Basededatos, .Usuario, .Password)
            End With

            With .Item(1)
                .NombreConexion = String.Empty
                Txt_Meli_Host.Text = .Host
                Txt_Meli_Puerto.Text = .Puerto
                Txt_Meli_Usuario.Text = .Usuario
                Txt_Meli_Password.Text = .Password
                Txt_Meli_Basededatos.Text = .Basededatos
            End With

        End With

        Txt_Empresa.Tag = String.Empty
        Txt_Empresa.Text = String.Empty

        Txt_Bodega.Tag = New BodegaFacturacion

        If Not IsNothing(_Cl_ConfiguracionLocal.Configuracion.BodegaFacturacion) Then

            Txt_Bodega.Tag = _Cl_ConfiguracionLocal.Configuracion.BodegaFacturacion

            With _Cl_ConfiguracionLocal.Configuracion.BodegaFacturacion

                Txt_Empresa.Tag = .Empresa
                Txt_Empresa.Text = .Razon

                Dim _Bod As BodegaFacturacion = Txt_Bodega.Tag

                Txt_Bodega.Text = String.Format("{0}{1}{2}:{3}, {4}", _Bod.Empresa, _Bod.Kosu, _Bod.Kobo, _Bod.Nokosu, _Bod.Nokobo)

            End With

        End If

        Txt_Vendedor.Tag = _Cl_ConfiguracionLocal.Configuracion.Vendedor
        Txt_Vendedor.Text = _Cl_ConfiguracionLocal.Configuracion.NoVendedor

        Txt_Responsable.Tag = _Cl_ConfiguracionLocal.Configuracion.Responsable
        Txt_Responsable.Text = _Cl_ConfiguracionLocal.Configuracion.NoResponsable

        Txt_RutaEtiquetas.Text = _Cl_ConfiguracionLocal.Configuracion.RutaEtiquetas
        Cmb_DocEmitir.SelectedValue = _Cl_ConfiguracionLocal.Configuracion.DocEmitir
        Chk_Facturar.Checked = _Cl_ConfiguracionLocal.Configuracion.Facturar

        Txt_Concepto_R.Tag = _Cl_ConfiguracionLocal.Configuracion.Concepto_R
        Txt_Concepto_R.Text = _Cl_ConfiguracionLocal.Configuracion.Concepto_R

        Txt_Concepto_D.Tag = _Cl_ConfiguracionLocal.Configuracion.Concepto_D
        Txt_Concepto_D.Text = _Cl_ConfiguracionLocal.Configuracion.Concepto_D

    End Sub

    Private Sub Btn_ProbarConexionRd_Click(sender As Object, e As EventArgs) Handles Btn_ProbarConexionRd.Click
        If Fx_ProbarConexionRd() Then

            With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones.Item(0)
                Cadena_ConexionSQL_Server = _Cl_ConfiguracionLocal.Fx_CadenaConexion(.Host, .Puerto, .Basededatos, .Usuario, .Password)
            End With

        Else
            Cadena_ConexionSQL_Server = String.Empty
        End If
    End Sub

    Private Sub Btn_ProbarConexionMeli_Click(sender As Object, e As EventArgs) Handles Btn_ProbarConexionMeli.Click
        Fx_ProbarConexionMeli()
    End Sub

    Function Fx_ProbarConexionRd() As Boolean

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False

            Dim _Cadena As String = _Cl_ConfiguracionLocal.Fx_CadenaConexion(Txt_Rd_Host.Text, Txt_Rd_Puerto.Text, Txt_Rd_Basededatos.Text, Txt_Rd_Usuario.Text, Txt_Rd_Password.Text)

            Dim _Mensaje As New LsValiciones.Mensajes

            _Mensaje = _Cl_ConfiguracionLocal.Fx_Conectar(_Cadena)

            If Not _Mensaje.EsCorrecto Then
                MessageBoxEx.Show(Me, Fx_AjustarTexto(_Mensaje.Mensaje, 100), _Mensaje.Detalle & " (Base de datos RANDOM/BAKAPP)", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Rd_Host.Focus()
                Return False
            End If

            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle & "Base de datos " & Txt_Rd_Basededatos.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones

                With .Item(0)

                    .NombreConexion = "RandomBakapp"
                    .Host = Txt_Rd_Host.Text
                    .Puerto = Txt_Rd_Puerto.Text
                    .Usuario = Txt_Rd_Usuario.Text
                    .Password = Txt_Rd_Password.Text
                    .Basededatos = Txt_Rd_Basededatos.Text

                End With

            End With

        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try

        Return True

    End Function

    Function Fx_ProbarConexionMeli() As Boolean

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False

            Dim _Cadena As String = _Cl_ConfiguracionLocal.Fx_CadenaConexion(Txt_Meli_Host.Text, Txt_Meli_Puerto.Text, Txt_Meli_Basededatos.Text, Txt_Meli_Usuario.Text, Txt_Meli_Password.Text)

            Dim _Mensaje As New LsValiciones.Mensajes

            _Mensaje = _Cl_ConfiguracionLocal.Fx_Conectar(_Cadena)

            If Not _Mensaje.EsCorrecto Then
                MessageBoxEx.Show(Me, Fx_AjustarTexto(_Mensaje.Mensaje, 100), _Mensaje.Detalle & " (Base de datos de MELI)", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Meli_Host.Focus()
                Return False
            End If

            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle & "Base de datos " & Txt_Meli_Basededatos.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones

                With .Item(1)

                    .NombreConexion = "Meli"
                    .Host = Txt_Meli_Host.Text
                    .Puerto = Txt_Meli_Puerto.Text
                    .Usuario = Txt_Meli_Usuario.Text
                    .Password = Txt_Meli_Password.Text
                    .Basededatos = Txt_Meli_Basededatos.Text

                End With

            End With

        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try

        Return True

    End Function

    Function Fx_ProbarConexionBaseBakapp() As Boolean

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False

            Dim _Cadena As String = _Cl_ConfiguracionLocal.Fx_CadenaConexion(Txt_Rd_Host.Text, Txt_Rd_Puerto.Text, Txt_Rd_Basededatos.Text, Txt_Rd_Usuario.Text, Txt_Rd_Password.Text)

            Dim _Mensaje As New LsValiciones.Mensajes

            _Mensaje = _Cl_ConfiguracionLocal.Fx_ConfirmardbBakapp(Txt_Global_BaseBk.Text, Txt_Rd_Usuario.Text, _Cadena)

            If Not _Mensaje.EsCorrecto Then
                MessageBoxEx.Show(Me, Fx_AjustarTexto(_Mensaje.Mensaje, 100), _Mensaje.Detalle & " (Nombre de base de datos de BAKAPP)", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Global_BaseBk.Focus()
                Return False
            End If

            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle & "Base de datos " & Txt_Rd_Basededatos.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try

        Return True
    End Function
    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Txt_Global_BaseBk.Text) Then
            MessageBoxEx.Show(Me, "Debe ingresar el nombre de la base de datos de BAKAPP", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Global_BaseBk.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Bodega.Text) Then
            MessageBoxEx.Show(Me, "Debe ingresar los datos de la bodega de facturación", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Bodega.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Vendedor.Text) Then
            MessageBoxEx.Show(Me, "Falta el vendedor", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Vendedor.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_RutaEtiquetas.Text) Then
            MessageBoxEx.Show(Me, "Falta la ruta de las etiquetas", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_RutaEtiquetas.Focus()
            Return
        End If

        If Not Directory.Exists(Txt_RutaEtiquetas.Text) Then
            MessageBoxEx.Show(Me, "La ruta de las etiquetas no existe", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_RutaEtiquetas.Focus()
            Return
        End If

        If Chk_Facturar.Checked And String.IsNullOrEmpty(Cmb_DocEmitir.SelectedValue) Then
            MessageBoxEx.Show(Me, "Debe seleccionar el tipo de documento a emitir", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Cmb_DocEmitir.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(Txt_Concepto_R.Text) Then
            MessageBoxEx.Show(Me, "Debe seleccionar el concepto de Recargo", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Concepto_R.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(Txt_Concepto_D.Text) Then
            MessageBoxEx.Show(Me, "Debe seleccionar el concepto de Descuento", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Concepto_D.Focus()
            Return
        End If

        If Not Fx_ProbarConexionRd() Then Return
        If Not Fx_ProbarConexionBaseBakapp() Then Return

        If Not Fx_ProbarConexionMeli() Then Return


        With _Cl_ConfiguracionLocal.Configuracion
            .Global_BaseBk = Txt_Global_BaseBk.Text
            .BodegaFacturacion = Txt_Bodega.Tag
            .Vendedor = Txt_Vendedor.Tag
            .NoVendedor = Txt_Vendedor.Text
            .Responsable = Txt_Responsable.Tag
            .NoResponsable = Txt_Responsable.Text
            .RutaEtiquetas = Txt_RutaEtiquetas.Text
            .Facturar = Chk_Facturar.Checked
            .DocEmitir = Cmb_DocEmitir.SelectedValue
            .Concepto_R = Txt_Concepto_R.Tag
            .Concepto_D = Txt_Concepto_D.Tag
        End With

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje = _Cl_ConfiguracionLocal.Fx_GrabarConexiones()

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

    End Sub

    Private Sub Txt_Bodega_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Bodega.ButtonCustomClick

        If String.IsNullOrEmpty(Txt_Empresa.Text) Then
            MessageBoxEx.Show(Me, "Debe seleccionar una empresa", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Empresa.Focus()
            Return
        End If

        Dim Fm As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
        Fm.Pro_Empresa = Txt_Empresa.Tag
        Fm.Pro_Sucursal = ""
        Fm.Pro_Bodega = ""
        Fm.Pedir_Permiso = False
        Fm.ShowDialog(Me)

        If Fm.Pro_Seleccionado Then

            Dim _Bod As BodegaFacturacion = Txt_Bodega.Tag

            With Txt_Bodega.Tag
                .Empresa = Fm.Pro_RowBodega.Item("EMPRESA")
                .Razon = Fm.Pro_RowBodega.Item("RAZON").ToString.Trim
                .Kosu = Fm.Pro_RowBodega.Item("KOSU")
                .Nokosu = Fm.Pro_RowBodega.Item("NOKOSU").ToString.Trim
                .Kobo = Fm.Pro_RowBodega.Item("KOBO")
                .Nokobo = Fm.Pro_RowBodega.Item("NOKOBO").ToString.Trim
            End With

            Txt_Bodega.Text = String.Format("{0}{1}{2}:{3}, {4}", _Bod.Empresa, _Bod.Kosu, _Bod.Kobo, _Bod.Nokosu, _Bod.Nokobo)

        End If

    End Sub

    Private Sub Txt_Empresa_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Empresa.ButtonCustomClick

        Dim _Sql_Filtro_Condicion_Extra = String.Empty
        Dim _Tbl As DataTable

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "CONFIGP"
        _Filtrar.Campo = "EMPRESA"
        _Filtrar.Descripcion = "RAZON"

        If _Filtrar.Fx_Filtrar(_Tbl, Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _Sql_Filtro_Condicion_Extra, False, False, True) Then

            Txt_Empresa.Tag = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Txt_Empresa.Text = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Descripcion").ToString.Trim

            Txt_Bodega.Text = String.Empty
            Txt_Bodega.Tag = New BodegaFacturacion

        End If

    End Sub

    Private Sub Txt_Vendedor_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Vendedor.ButtonCustomClick

        Dim _Sql_Filtro_Condicion_Extra = String.Empty
        Dim _Tbl As DataTable

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl, Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra, False, False, True) Then

            Txt_Vendedor.Tag = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Txt_Vendedor.Text = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Descripcion").ToString.Trim

        End If

    End Sub

    Private Sub Txt_RutaEtiquetas_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_RutaEtiquetas.ButtonCustomClick
        Using folderBrowser As New FolderBrowserDialog()
            If folderBrowser.ShowDialog() = DialogResult.OK Then
                Txt_RutaEtiquetas.Tag = folderBrowser.SelectedPath
                Txt_RutaEtiquetas.Text = folderBrowser.SelectedPath
            End If
        End Using
    End Sub

    Private Sub Txt_Responsable_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Responsable.ButtonCustomClick

        Dim _Sql_Filtro_Condicion_Extra = String.Empty
        Dim _Tbl As DataTable

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl, Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra, False, False, True) Then

            Txt_Responsable.Tag = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Txt_Responsable.Text = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Descripcion").ToString.Trim

        End If


    End Sub

    Private Sub Txt_Concepto_R_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Concepto_R.ButtonCustomClick

        Dim _Sql_Filtro_Condicion_Extra = "And TICT = 'R'"
        Dim _Tbl As DataTable

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl, Clas_Filtros_Random.Enum_Tabla_Fl._Conceptos, _Sql_Filtro_Condicion_Extra, False, False, True) Then

            Txt_Concepto_R.Tag = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Txt_Concepto_R.Text = Txt_Concepto_R.Tag.ToString.Trim & " - " & _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Descripcion").ToString.Trim

        End If

    End Sub

    Private Sub Txt_Concepto_D_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Concepto_D.ButtonCustomClick

        Dim _Sql_Filtro_Condicion_Extra = "And TICT = 'D'"
        Dim _Tbl As DataTable

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl, Clas_Filtros_Random.Enum_Tabla_Fl._Conceptos, _Sql_Filtro_Condicion_Extra, False, False, True) Then

            Txt_Concepto_D.Tag = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Txt_Concepto_D.Text = Txt_Concepto_D.Tag.ToString.Trim & " - " & _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Descripcion").ToString.Trim

        End If

    End Sub
End Class
