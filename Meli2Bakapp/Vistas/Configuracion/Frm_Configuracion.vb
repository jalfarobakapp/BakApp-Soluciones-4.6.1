Imports System.IO
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar
Public Class Frm_Configuracion

    Private _Cl_ConfiguracionLocal As New Cl_ConfiguracionLocal

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Lbl_RutEmpresa.Tag = String.Empty

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

        Txt_ModalidadFac.Text = _Cl_ConfiguracionLocal.Configuracion.ModalidadFac

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
        Txt_Responsable.Text = _Cl_ConfiguracionLocal.Configuracion.NomResponsable

        Txt_RutaEtiquetas.Text = _Cl_ConfiguracionLocal.Configuracion.RutaEtiquetas
        Cmb_DocEmitir.SelectedValue = _Cl_ConfiguracionLocal.Configuracion.DocEmitir
        Chk_Facturar.Checked = _Cl_ConfiguracionLocal.Configuracion.Facturar

        Txt_Concepto_R.Tag = _Cl_ConfiguracionLocal.Configuracion.Concepto_R
        Txt_Concepto_R.Text = _Cl_ConfiguracionLocal.Configuracion.Concepto_R

        Txt_Concepto_D.Tag = _Cl_ConfiguracionLocal.Configuracion.Concepto_D
        Txt_Concepto_D.Text = _Cl_ConfiguracionLocal.Configuracion.Concepto_D

        With _Cl_ConfiguracionLocal.Configuracion.Pago
            Txt_ModalidadPago.Tag = .Modalidad
            Txt_ModalidadPago.Text = .Modalidad
            Txt_EmpresaPago.Tag = .Empresa
            Txt_EmpresaPago.Text = .Razon
            Lbl_RutEmpresa.Tag = .RutEmpresa
            Lbl_RutEmpresa.Text = "Rut empresa: " & .RutEmpresa
            Txt_SucursalPago.Tag = .Sucursal
            Txt_SucursalPago.Text = .NomSucursal
            Txt_CajaPago.Tag = .Caja
            Txt_CajaPago.Text = .NomCaja
            Txt_TipoPago.Text = .TipoPago
            Txt_FuncionarioPaga.Tag = .Funcionario
            Txt_FuncionarioPaga.Text = .NomFuncionario
            Txt_BancoPago.Tag = .Banco
            Txt_BancoPago.Text = .NomBanco
            Chk_PagarAuto.Checked = .PagarAuto
        End With

        Txt_ModalidadFac.Text = _Cl_ConfiguracionLocal.Configuracion.ModalidadFac

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

        If String.IsNullOrWhiteSpace(Txt_ModalidadFac.Text) Then
            MessageBoxEx.Show(Me, "Falta la modalidad de facturación", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_ModalidadFac.Focus()
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

        If Chk_PagarAuto.Checked Then

            If String.IsNullOrWhiteSpace(Txt_ModalidadPago.Text) Then
                MessageBoxEx.Show(Me, "Falta la modalidad de pago", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_ModalidadPago.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(Lbl_RutEmpresa.Tag) Then
                MessageBoxEx.Show(Me, "Falta el Rut de la empresa de pago", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_ModalidadPago.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(Txt_EmpresaPago.Text) Then
                MessageBoxEx.Show(Me, "Falta la empresa de pago", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_ModalidadPago.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(Txt_SucursalPago.Text) Then
                MessageBoxEx.Show(Me, "Falta la sucursal de pago", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_SucursalPago.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(Txt_CajaPago.Text) Then
                MessageBoxEx.Show(Me, "Falta la caja de pago", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_SucursalPago.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(Txt_BancoPago.Text) Then
                MessageBoxEx.Show(Me, "Falta el banco de pago", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_BancoPago.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(Txt_FuncionarioPaga.Text) Then
                MessageBoxEx.Show(Me, "Falta el funcionario que paga", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_FuncionarioPaga.Focus()
                Return
            End If

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
            .NomResponsable = Txt_Responsable.Text
            .RutaEtiquetas = Txt_RutaEtiquetas.Text
            .Facturar = Chk_Facturar.Checked
            .DocEmitir = Cmb_DocEmitir.SelectedValue
            .Concepto_R = Txt_Concepto_R.Tag
            .Concepto_D = Txt_Concepto_D.Tag
            .ModalidadFac = Txt_ModalidadFac.Text
        End With

        With _Cl_ConfiguracionLocal.Configuracion.Pago
            .Modalidad = Txt_ModalidadPago.Tag
            .Empresa = Txt_Empresa.Tag
            .Razon = Txt_Empresa.Text
            .RutEmpresa = Lbl_RutEmpresa.Tag
            .Sucursal = Txt_SucursalPago.Tag
            .NomSucursal = Txt_SucursalPago.Text
            .Caja = Txt_CajaPago.Tag
            .NomCaja = Txt_CajaPago.Text
            .Banco = Txt_BancoPago.Tag
            .NomBanco = Txt_BancoPago.Text
            .Funcionario = Txt_FuncionarioPaga.Tag
            .NomFuncionario = Txt_FuncionarioPaga.Text
            .PagarAuto = Chk_PagarAuto.Checked
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

    Private Sub Txt_ModalidadPago_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_ModalidadPago.ButtonCustomClick

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Sql_Filtro_Condicion_Extra = String.Empty
        Dim _Tbl As DataTable

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "CONFIEST"
        _Filtrar.Campo = "MODALIDAD"
        _Filtrar.Descripcion = "MODALIDAD+', Empresa: '+EMPRESA+', Sucursal:'+ESUCURSAL+', Bodega: '+EBODEGA+', Caja: :'+ECAJA"

        If _Filtrar.Fx_Filtrar(_Tbl, Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _Sql_Filtro_Condicion_Extra, False, False, True) Then

            Txt_ModalidadPago.Tag = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Txt_ModalidadPago.Text = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo").ToString.Trim

            Dim _ConsultaSql As String = "Select Ct.MODALIDAD,Ct.EMPRESA,Cp.RUT,Cp.RAZON,Ct.ESUCURSAL,Ts.NOKOSU,Ct.EBODEGA,Ct.ECAJA,Cj.NOKOCJ" & vbCrLf &
                                         "From CONFIEST Ct" & vbCrLf &
                                         "Left Join CONFIGP Cp On Cp.EMPRESA = Ct.EMPRESA" & vbCrLf &
                                         "Left Join TABSU Ts On Ct.EMPRESA = Ts.EMPRESA And Ct.ESUCURSAL = Ts.KOSU" & vbCrLf &
                                         "Left Join TABCJ Cj On Ct.EMPRESA = Cj.EMPRESA And Ct.ESUCURSAL = Cj.KOSU And Ct.ECAJA = Cj.KOCJ" & vbCrLf &
                                         "Where MODALIDAD = '" & Txt_ModalidadPago.Tag & "'"
            Dim _Row_Modalidad As DataRow = _Sql.Fx_Get_DataRow(_ConsultaSql)

            Txt_EmpresaPago.Tag = _Row_Modalidad.Item("EMPRESA")
            Txt_EmpresaPago.Text = _Row_Modalidad.Item("RAZON").ToString.Trim
            Lbl_RutEmpresa.Tag = _Row_Modalidad.Item("RUT").ToString.Trim
            Lbl_RutEmpresa.Text = "Rut empresa: " & _Row_Modalidad.Item("RUT").ToString.Trim
            Txt_SucursalPago.Tag = _Row_Modalidad.Item("ESUCURSAL")
            Txt_SucursalPago.Text = _Row_Modalidad.Item("NOKOSU").ToString.Trim
            Txt_CajaPago.Tag = _Row_Modalidad.Item("ECAJA")
            Txt_CajaPago.Text = _Row_Modalidad.Item("NOKOCJ").ToString.Trim

        End If

    End Sub

    Private Sub Txt_BancoPago_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_BancoPago.ButtonCustomClick

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Sql_Filtro_Condicion_Extra = "And TIDPEN = 'TJ'"
        Dim _Tbl As DataTable

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "TABENDP"
        _Filtrar.Campo = "KOENDP"
        _Filtrar.Descripcion = "NOKOENDP"

        If _Filtrar.Fx_Filtrar(_Tbl, Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _Sql_Filtro_Condicion_Extra, False, False, True) Then

            Txt_BancoPago.Tag = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Txt_BancoPago.Text = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Descripcion").ToString.Trim

        End If

    End Sub

    Private Sub Txt_FuncionarioPaga_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_FuncionarioPaga.ButtonCustomClick

        Dim _Sql_Filtro_Condicion_Extra = String.Empty
        Dim _Tbl As DataTable

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl, Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra, False, False, True) Then

            Txt_FuncionarioPaga.Tag = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Txt_FuncionarioPaga.Text = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Descripcion").ToString.Trim

        End If

    End Sub

    Private Sub Txt_SucursalPago_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_SucursalPago.ButtonCustomClick

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Sql_Filtro_Condicion_Extra = "And EMPRESA = '" & Txt_EmpresaPago.Tag & "'"
        Dim _Tbl As DataTable

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl, Clas_Filtros_Random.Enum_Tabla_Fl._Sucursales, _Sql_Filtro_Condicion_Extra, False, False, True) Then

            Txt_SucursalPago.Tag = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Txt_SucursalPago.Text = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Descripcion").ToString.Trim

            Txt_CajaPago.Tag = String.Empty
            Txt_CajaPago.Text = String.Empty

        End If

    End Sub

    Private Sub Txt_CajaPago_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_CajaPago.ButtonCustomClick

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Sql_Filtro_Condicion_Extra = "And EMPRESA = '" & Txt_EmpresaPago.Tag & "' And KOSU = '" & Txt_SucursalPago.Tag & "'"
        Dim _Tbl As DataTable

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "TABCJ"
        _Filtrar.Campo = "KOCJ"
        _Filtrar.Descripcion = "NOKOCJ"

        If _Filtrar.Fx_Filtrar(_Tbl, Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _Sql_Filtro_Condicion_Extra, False, False, True) Then

            Txt_CajaPago.Tag = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Txt_CajaPago.Text = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Descripcion").ToString.Trim

        End If

    End Sub

    Private Sub Txt_ModalidadFac_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_ModalidadFac.ButtonCustomClick

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "MODALIDADES DE LA EMPRESA"

        _Filtrar.Tabla = "CONFIEST"
        _Filtrar.Campo = "MODALIDAD"
        _Filtrar.Descripcion = "MODALIDAD"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra,
                               "And MODALIDAD <> '  ' And EMPRESA = '" & Txt_Empresa.Tag & "'",
                               Nothing, False, True) Then

            Dim _Tbl_Transportista As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Transportista.Rows(0)

            Dim _Modalidad = _Row.Item("Codigo").ToString.Trim

            'Dim _RowFormato As DataRow = Fx_Formato_Modalidad(Me, _Modalidad, "FCV", True)

            'If IsNothing(_RowFormato) Then
            '    _Modalidad = String.Empty
            '    'Throw New System.Exception("No existe formato de documento para la modalidad")
            'End If

            Txt_ModalidadFac.Tag = _Modalidad
            Txt_ModalidadFac.Text = _Modalidad

        End If

    End Sub

End Class
