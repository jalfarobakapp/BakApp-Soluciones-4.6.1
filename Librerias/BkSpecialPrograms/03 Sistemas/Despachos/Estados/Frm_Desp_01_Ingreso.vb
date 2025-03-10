Imports DevComponents.DotNetBar

Public Class Frm_Desp_01_Ingreso

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Cl_Despacho As Clas_Despacho
    Dim _Grabar As Boolean
    Private _Desde_Documento As Boolean
    Private _Row_Entidad_Transportista As DataRow
    Dim _Ds_Matriz_Documentos As DataSet

    Dim _Row_Direccion_Despacho As DataRow
    Dim _Row_Transportista As DataRow

    Dim _Total_Venta_Neto As Double
    Dim _Total_Venta_Bruto As Double
    Dim _Total_Venta_Kilos As Double

    Dim _Kilos_Minimo As Double
    Dim _Netos_Minimo As Double

    Dim _Idenvio_Chilexpress As Integer

    Public Property Cl_Despacho As Clas_Despacho
        Get
            Return _Cl_Despacho
        End Get
        Set(value As Clas_Despacho)
            _Cl_Despacho = value
        End Set
    End Property

    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property Desde_Documento As Boolean
        Get
            Return _Desde_Documento
        End Get
        Set
            _Desde_Documento = Value
        End Set
    End Property

    Public Property Total_Venta_Neto As Double
        Get
            Return _Total_Venta_Neto
        End Get
        Set(value As Double)
            _Total_Venta_Neto = value
        End Set
    End Property

    Public Property Total_Venta_Kilos As Double
        Get
            Return _Total_Venta_Kilos
        End Get
        Set(value As Double)
            _Total_Venta_Kilos = value
        End Set
    End Property

    Public Property Kilos_Minimo As Double
        Get
            Return _Kilos_Minimo
        End Get
        Set(value As Double)
            _Kilos_Minimo = value
        End Set
    End Property

    Public Property Netos_Minimo As Double
        Get
            Return _Netos_Minimo
        End Get
        Set(value As Double)
            _Netos_Minimo = value
        End Set
    End Property

    Public Property Ds_Matriz_Documentos As DataSet
        Get
            Return _Ds_Matriz_Documentos
        End Get
        Set(value As DataSet)
            _Ds_Matriz_Documentos = value
        End Set
    End Property

    Public Property ConfirmarLecturaDespacho As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Txt_Datos_Entidad_Direccion.Text = String.Empty

        Sb_Formato_Generico_Grilla(Grilla_Documentos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Productos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Consulta_Sql = "Select '' As Padre,'' As 'Hijo' Union Select EMPRESA+KOSU As Padre,NOKOSU As Hijo From TABSU"
        caract_combo(Cmb_Sucursal_Retiro)
        Cmb_Sucursal_Retiro.DataSource = _Sql.Fx_Get_DataTable(Consulta_Sql)
        Cmb_Sucursal_Retiro.SelectedValue = ""

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Desp_01_Ingreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        caract_combo(Cmb_Tipo_Envio)
        Cmb_Tipo_Envio.DataSource = _Cl_Despacho.Fx_Tbl_Tipo_Envio(True)
        Cmb_Tipo_Envio.SelectedValue = ""

        If _Cl_Despacho.Accion = Clas_Despacho.Enum_Accion.Nuevo Then

            Dim _Row_Despacho As DataRow = _Cl_Despacho.Tbl_Despacho(0)

            Txt_Nombre_Cliente.Text = _Cl_Despacho.Row_Entidad.Item("Rut") & " - " & _Cl_Despacho.Row_Entidad.Item("NOKOEN")
            Txt_Referencia.Text = _Row_Despacho.Item("Referencia")

            Dtp_Fecha_Despacho.Value = Ds_Matriz_Documentos.Tables("Encabezado_Doc").Rows(0).Item("FechaRecepcion") 'FechaDelServidor()
            Sb_Habilitar_Controles(True)

            Me.ActiveControl = Txt_Referencia

            If Not IsNothing(_Cl_Despacho.Row_Conf_Despacho) Then

                Txt_Tipo_Venta.Tag = _Cl_Despacho.Row_Conf_Despacho.Item("Tipo_Venta_X_Defecto")
                Txt_Tipo_Venta.Text = _Cl_Despacho.Row_Conf_Despacho.Item("Nom_Tipo_Venta")

                Txt_Transportista.Tag = _Cl_Despacho.Row_Conf_Despacho.Item("Transportista_X_Defecto")
                Txt_Transportista.Text = _Cl_Despacho.Row_Conf_Despacho.Item("Nom_Transportista")

                Cmb_Sucursal_Retiro.Visible = _Cl_Despacho.Row_Conf_Despacho.Item("Pedir_Sucursal_Retiro")
                Lbl_Suc_Retiro.Visible = _Cl_Despacho.Row_Conf_Despacho.Item("Pedir_Sucursal_Retiro")

                Chk_Transpor_Por_Pagar.Checked = _Cl_Despacho.Row_Conf_Despacho.Item("Transpor_Por_Pagar")

            End If

        ElseIf _Cl_Despacho.Accion = Clas_Despacho.Enum_Accion.Editar Then

            Sb_Cargar_Despacho()

        End If

        Dim _CodEntidad As String = _Cl_Despacho.Row_Entidad.Item("KOEN")
        Dim _CodSucEntidad As String = _Cl_Despacho.Row_Entidad.Item("SUEN")

        Chk_EntregaPaletizada.Checked = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Entidades",
                                                          "EntregaPaletizada", "CodEntidad = '" & _CodEntidad & "' And CodSucEntidad = '" & _CodSucEntidad & "'",,,, True)


        Dim _Empresa = _Cl_Despacho.Tbl_Despacho.Rows(0).Item("Empresa")
        Dim _Sucursal = _Cl_Despacho.Tbl_Despacho.Rows(0).Item("Sucursal")

        AddHandler Grilla_Documentos.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla_Documentos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Cmb_Tipo_Envio.SelectedIndexChanged, AddressOf Sb_Cmb_Tipo_Envio_SelectedIndexChanged
        AddHandler Cmb_Sucursal_Retiro.SelectedIndexChanged, AddressOf Cmb_Sucursal_Retiro_SelectedIndexChanged

        AddHandler Dtp_Fecha_Despacho.ValueChanged, AddressOf Sb_Dtp_Fecha_Despacho_ValueChanged

        SuperTabItem2.Visible = _Cl_Despacho.Row_Despacho.Item("Confirmado")
        SuperTabItem3.Visible = _Cl_Despacho.Row_Despacho.Item("Confirmado")

        If _Cl_Despacho.Desde_Documento Then

            Sb_Habilitar_Controles(True)
            _Cl_Despacho.Fx_Tomar_Orden_Despacho(_Cl_Despacho.Id_Despacho, FUNCIONARIO)
            Btn_Editar.Visible = False
            Btn_Cancelar.Visible = False

            SuperTabItem2.Visible = False
            SuperTabItem3.Visible = False

        End If

        Lbl_Suc_Retiro.Visible = (Cmb_Tipo_Envio.SelectedValue = "RT")
        Cmb_Sucursal_Retiro.Visible = (Cmb_Tipo_Envio.SelectedValue = "RT")

        Sb_Color_Botones_Barra(Bar2)

        Warning_Cantidad.Visible = (_Kilos_Minimo > _Total_Venta_Kilos And Cmb_Tipo_Envio.SelectedValue = "DD")
        Warning_Valor.Visible = (_Netos_Minimo > _Total_Venta_Neto And Cmb_Tipo_Envio.SelectedValue = "DD")

    End Sub

    Sub Sb_Cargar_Despacho()

        Dim _Row_Despacho As DataRow = _Cl_Despacho.Tbl_Despacho(0)

        Sb_Cargar_Datos_Envio()

        Cmb_Tipo_Envio.SelectedValue = _Row_Despacho.Item("Tipo_Envio")

        Dim _Transportista As String = _Row_Despacho.Item("Transportista")

        Consulta_Sql = "Select * 
                        From TABRETI 
                        Left Join " & _Global_BaseBk & "Zw_Despachos_Transportistas On CodTransportista = KORETI
                        Where KORETI = '" & _Transportista & "'"
        _Row_Transportista = _Sql.Fx_Get_DataRow(Consulta_Sql)

        'Sb_Validar_Cantidad_X_Transportista(_Transportista)

        Warning_Cantidad.Visible = (_Kilos_Minimo > _Total_Venta_Kilos And Cmb_Tipo_Envio.SelectedValue = "DD")
        Warning_Valor.Visible = (_Netos_Minimo > _Total_Venta_Neto And Cmb_Tipo_Envio.SelectedValue = "DD")

        If Not IsNothing(_Row_Transportista) Then
            Txt_Transportista.Tag = _Row_Transportista.Item("KORETI") ' _Koreti
            Txt_Transportista.Text = _Row_Transportista.Item("NORETI") ' _Noreti
        End If

        Txt_Tipo_Venta.Tag = _Row_Despacho.Item("Tipo_Venta")
        Txt_Tipo_Venta.Text = _Row_Despacho.Item("Nom_Tipo_Venta")

        Txt_Nombre_Cliente.Text = _Cl_Despacho.Row_Entidad.Item("Rut") & " - " & _Cl_Despacho.Row_Entidad.Item("NOKOEN")
        Txt_Referencia.Text = _Row_Despacho.Item("Referencia")

        Chk_Entregar_Con_Doc_Pagados.Checked = _Row_Despacho.Item("Entregar_Con_Doc_Pagados")
        Chk_Transpor_Por_Pagar.Checked = _Row_Despacho.Item("Transpor_Por_Pagar")

        Cmb_Sucursal_Retiro.SelectedValue = _Row_Despacho.Item("Empresa") & _Row_Despacho.Item("Sucursal_Retiro")

        Dtp_Fecha_Despacho.Value = _Row_Despacho.Item("Fecha_Compromiso")

        Txt_Observaciones.Text = _Row_Despacho.Item("Observaciones")

        Chk_EntregaPaletizada.Checked = _Row_Despacho.Item("EntregaPaletizada")

        Me.Text = "ORDEN DE DESPACHO NRO: " & _Cl_Despacho.Nro_Despacho.Trim & ", Responsable: " & _Row_Despacho.Item("Responsable")

        Sb_Actualizar_Grillas()
        Sb_Habilitar_Controles(False)

        Btn_Modificar_Direccion.Enabled = (Cmb_Tipo_Envio.SelectedValue = "DD" Or Cmb_Tipo_Envio.SelectedValue = "AG")

    End Sub

    Sub Sb_Modificar_Direccion_2(_CodEntidad As String, _CodSucEntidad As String)

        Dim Fm As New Frm_Direc_Cli_Lista(_CodEntidad, _CodSucEntidad)
        Fm.Btn_Eliminar.Visible = False
        Fm.Seleccionar = True
        Fm.Row_Direccion = _Row_Direccion_Despacho
        Fm.ShowDialog(Me)

        If IsNothing(Fm.Row_Direccion) Then

            If IsNothing(_Row_Direccion_Despacho) Then Return

            Sb_Cargar_Direccion_Despcaho(False, _Row_Direccion_Despacho.Item("Id"), _CodEntidad, _CodSucEntidad)

        Else

            If Not IsNothing(_Row_Direccion_Despacho) Then
                If _Row_Direccion_Despacho.Item("Id") <> Fm.Row_Direccion.Item("Id") Then
                    MessageBoxEx.Show(Me, "Dirección cambiada", "BakApp", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

            _Row_Direccion_Despacho = Fm.Row_Direccion

            _Cl_Despacho.Row_Despacho.Item("Pais") = _Row_Direccion_Despacho.Item("NOKOPA")
            _Cl_Despacho.Row_Despacho.Item("Ciudad") = _Row_Direccion_Despacho.Item("NOKOCI")
            _Cl_Despacho.Row_Despacho.Item("Comuna") = _Row_Direccion_Despacho.Item("NOKOCM")

            _Cl_Despacho.Row_Despacho.Item("Telefono") = _Row_Direccion_Despacho.Item("Telefono")
            _Cl_Despacho.Row_Despacho.Item("Email") = _Row_Direccion_Despacho.Item("Email")
            _Cl_Despacho.Row_Despacho.Item("Direccion") = _Row_Direccion_Despacho.Item("Direccion")
            _Cl_Despacho.Row_Despacho.Item("Nombre_Contacto") = _Row_Direccion_Despacho.Item("Nombre_Contacto")

            Txt_Tipo_Venta.Tag = _Row_Direccion_Despacho.Item("Tipo_Venta")
            Txt_Tipo_Venta.Text = _Row_Direccion_Despacho.Item("Nom_Tipo_Venta")

            Txt_Transportista.Tag = _Row_Direccion_Despacho.Item("Transportista")
            Txt_Transportista.Text = _Row_Direccion_Despacho.Item("Nom_Transportista")

        End If

        Fm.Dispose()

        Chk_EntregaPaletizada.Checked = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Entidades",
                                                          "EntregaPaletizada", "CodEntidad = '" & _CodEntidad & "' And CodSucEntidad = '" & _CodSucEntidad & "'",,,, True)


        Sb_Cargar_Datos_Envio()

    End Sub

    Private Sub Btn_Buscar_Transportista_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Transportista.Click
        Sb_Buscar_Transportista(True)
    End Sub

    Sub Sb_Buscar_Transportista(_Limpiar_Despacho As Boolean)

        Dim _Filtrar As New Clas_Filtros_Random(Me)
        Dim _Row_Despacho As DataRow = _Cl_Despacho.Tbl_Despacho.Rows(0)

        _Filtrar.Tabla = "TABRETI"
        _Filtrar.Campo = "KORETI"
        _Filtrar.Descripcion = "NORETI"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "TRANSPORTISTA"

        Dim _Tipo_Envio As String = Cmb_Tipo_Envio.SelectedValue

        If _Tipo_Envio = "RR" Then _Tipo_Envio = "AG"

        Dim _Sql_Filtro_Condicion_Extra = "And KORETI In (Select CodTransportista From " & _Global_BaseBk & "Zw_Despachos_Transportistas Where Mostrar = 1 And Tipo_Envio In ('" & _Tipo_Envio & "',''))"
        _Tipo_Envio = Cmb_Tipo_Envio.SelectedValue

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _Sql_Filtro_Condicion_Extra,
                               Nothing, False, True) Then

            Dim _Tbl_Transportista As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Transportista.Rows(0)

            Dim _Koreti = _Row.Item("Codigo").ToString
            Dim _Noreti = _Row.Item("Descripcion").ToString.Trim

            Txt_Transportista.Tag = _Koreti
            Txt_Transportista.Text = _Noreti

            Consulta_Sql = "Select * 
                            From TABRETI 
                            Left Join " & _Global_BaseBk & "Zw_Despachos_Transportistas On CodTransportista = KORETI
                            Where KORETI = '" & _Koreti & "'"
            _Row_Transportista = _Sql.Fx_Get_DataRow(Consulta_Sql)

            If _Limpiar_Despacho And _Tipo_Envio <> "RR" Then

                _Row_Despacho.Item("CodPais") = String.Empty
                _Row_Despacho.Item("CodCiudad") = String.Empty
                _Row_Despacho.Item("CodComuna") = String.Empty
                _Row_Despacho.Item("Pais") = String.Empty
                _Row_Despacho.Item("Ciudad") = String.Empty
                _Row_Despacho.Item("Comuna") = String.Empty
                _Row_Despacho.Item("Direccion") = String.Empty
                _Row_Despacho.Item("Nombre_Contacto") = String.Empty
                _Row_Despacho.Item("Telefono") = String.Empty
                _Row_Despacho.Item("Email") = String.Empty

            End If

            _Idenvio_Chilexpress = 0

        End If

        Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Chilexpress_Conf Where Activo = 1"
        Dim _Row_Conf As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If Not IsNothing(_Row_Conf) Then

            Btn_Chilexpress.Visible = (Txt_Transportista.Tag.ToString.Trim = _Row_Conf.Item("CodTransportista").ToString.Trim)
            If Btn_Chilexpress.Visible Then
                Call Btn_Chilexpress_Click(Nothing, Nothing)
            End If

        End If

        If _Tipo_Envio = "RR" Then
            _Row_Despacho.Item("Direccion") = "RETIRA TRANSPORTISTA: " & Txt_Transportista.Text
            Sb_Cargar_Datos_Envio()
        End If

    End Sub

    Private Sub Sb_Cmb_Tipo_Envio_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim _Tipo_Envio = Cmb_Tipo_Envio.SelectedValue
        Dim _Row_Despacho As DataRow = _Cl_Despacho.Tbl_Despacho.Rows(0)

        SuperTabControl1.Enabled = True

        Lbl_Suc_Retiro.Visible = (_Tipo_Envio = "RT")
        Cmb_Sucursal_Retiro.Visible = (_Tipo_Envio = "RT")
        Btn_Modificar_Direccion.Enabled = (_Tipo_Envio = "DD" Or _Tipo_Envio = "AG")

        Dim _RegAG As Boolean = CBool(_Sql.Fx_Cuenta_Registros("TABRETI", "RETCLI = 1"))
        Btn_Direccion_Agencia.Visible = (_Tipo_Envio = "AG" And _RegAG)

        Warning_Valor.Visible = False
        Warning_Cantidad.Visible = False

        Dim _CodEntidad_Dir As String = _Cl_Despacho.Row_Entidad.Item("KOEN")
        Dim _CodSucEntidad_Dir As String = _Cl_Despacho.Row_Entidad.Item("SUEN")

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Entidades Where CodEntidad = '" & _CodEntidad_Dir & "' And CodSucEntidad = '" & _CodSucEntidad_Dir & "'"
        Dim _Row_AgenciaXEntidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)


        Dim _Pais_Dir As String
        Dim _Ciudad_Dir As String
        Dim _Comuna_Dir As String
        Dim _Direccion_Dir As String
        Dim _Telefono_Dir As String
        Dim _Email_Dir As String

        Select Case _Tipo_Envio

            Case "RT", "RR" ' Retiro en tienda

                If _Tipo_Envio = "RR" Then

                    Dim _BuscarTransportista As Boolean = True

                    If Not IsNothing(_Row_AgenciaXEntidad) Then

                        Dim _RT_Transportista = _Row_AgenciaXEntidad.Item("RT_Transportista")

                        Consulta_Sql = "Select * From TABRETI 
                                            Left Join " & _Global_BaseBk & "Zw_Despachos_Transportistas On CodTransportista = KORETI
                                            Where KORETI = '" & _RT_Transportista & "'"
                        _Row_Transportista = _Sql.Fx_Get_DataRow(Consulta_Sql)

                        If Not IsNothing(_Row_Transportista) Then

                            If MessageBoxEx.Show(Me, "¿Desea utilizar a este transportista: " & _Row_Transportista.Item("NORETI").ToString.Trim & "?",
                                                 "Agencia por defecto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                                Txt_Transportista.Tag = _RT_Transportista
                                Txt_Transportista.Text = _Row_Transportista.Item("NORETI")
                                _BuscarTransportista = False

                            End If

                        End If

                        If _BuscarTransportista Then
                            Call Btn_Buscar_Transportista_Click(Nothing, Nothing)
                        End If

                        Btn_Buscar_Transportista.Enabled = True

                    End If

                End If

                Chk_Transpor_Por_Pagar.Checked = False
                Chk_Transpor_Por_Pagar.Enabled = False

                Dim _Empresa = _Cl_Despacho.Tbl_Despacho.Rows(0).Item("Empresa")
                Dim _Sucursal = _Cl_Despacho.Tbl_Despacho.Rows(0).Item("Sucursal")

                Consulta_Sql = "Select Top 1 Suc.*,Ci.NOKOCI As CIUDAD,Cm.NOKOCM As COMUNA FROM TABSU Suc
                                    Left Join TABCI Ci On Suc.CISU = Ci.KOCI
                                    Left Join TABCM Cm On Suc.CISU = Cm.KOCI And Suc.CMSU = Cm.KOCM
                                    Where EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sucursal & "'"

                Dim _Row_Sucursal As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                _Row_Despacho.Item("CodPais") = _Sql.Fx_Trae_Dato("TABPA", "KOPA", "NOKOPA = '" & _Global_Row_Configp.Item("PAIS").ToString.Trim & "'",,, "CHI")
                _Row_Despacho.Item("CodCiudad") = _Row_Sucursal.Item("CISU").ToString.Trim
                _Row_Despacho.Item("CodComuna") = _Row_Sucursal.Item("CMSU").ToString.Trim
                _Row_Despacho.Item("Pais") = _Global_Row_Configp.Item("PAIS").ToString.Trim
                _Row_Despacho.Item("Ciudad") = _Row_Sucursal.Item("CIUDAD").ToString.Trim
                _Row_Despacho.Item("Comuna") = _Row_Sucursal.Item("COMUNA").ToString.Trim
                _Row_Despacho.Item("Direccion") = "Cliente retira en sucursal"
                _Row_Despacho.Item("Telefono") = _Cl_Despacho.Row_Entidad.Item("FOEN").ToString.Trim
                _Row_Despacho.Item("Email") = _Cl_Despacho.Row_Entidad.Item("EMAILCOMER").ToString.Trim

                If _Cl_Despacho.Row_Conf_Despacho.Item("Pedir_Sucursal_Retiro") Then

                    Cmb_Sucursal_Retiro.SelectedValue = Fx_Sucursal_Retiro()

                    'Consulta_Sql = "Select Top 1 Suc.*,Ci.NOKOCI As CIUDAD,Cm.NOKOCM As COMUNA FROM TABSU Suc
                    '                Left Join TABCI Ci On Suc.CISU = Ci.KOCI
                    '                Left Join TABCM Cm On Suc.CISU = Cm.KOCI And Suc.CMSU = Cm.KOCM
                    '                Where EMPRESA+KOSU = '" & Cmb_Sucursal_Retiro.SelectedValue & "'"

                    '_Row_Sucursal = _Sql.Fx_Get_DataRow(Consulta_Sql)

                    '_Row_Despacho.Item("CodPais") = _Sql.Fx_Trae_Dato("TABPA", "KOPA", "NOKOPA = '" & _Global_Row_Configp.Item("PAIS").ToString.Trim & "'",,, "CHI")
                    '_Row_Despacho.Item("CodCiudad") = _Row_Sucursal.Item("CISU").ToString.Trim
                    '_Row_Despacho.Item("CodComuna") = _Row_Sucursal.Item("CMSU").ToString.Trim
                    '_Row_Despacho.Item("Pais") = _Global_Row_Configp.Item("PAIS").ToString.Trim
                    '_Row_Despacho.Item("Ciudad") = _Row_Sucursal.Item("CIUDAD").ToString.Trim
                    '_Row_Despacho.Item("Comuna") = _Row_Sucursal.Item("COMUNA").ToString.Trim

                Else
                    Cmb_Sucursal_Retiro.SelectedValue = _Empresa & _Sucursal
                End If

                If _Tipo_Envio = "RT" Then
                    Btn_Buscar_Transportista.Enabled = False
                    Txt_Transportista.Text = String.Empty
                    Txt_Transportista.Tag = String.Empty
                    Txt_Transportista.Enabled = False
                    _Row_Despacho.Item("Transportista") = String.Empty
                    _Row_Despacho.Item("Direccion") = "RETIRA EN SUCURSAL: " & Cmb_Sucursal_Retiro.Text.Trim
                End If

                If _Tipo_Envio = "RR" Then _Row_Despacho.Item("Direccion") = "RETIRA TRANSPORTISTA: " & Txt_Transportista.Text

                If Not String.IsNullOrEmpty(Cmb_Sucursal_Retiro.SelectedValue) Then

                    If String.IsNullOrEmpty(Txt_Tipo_Venta.Tag) Then

                        Call Btn_Buscar_Tipo_Venta_Click(Nothing, Nothing)
                        Txt_Referencia.Focus()

                    End If

                End If

            Case "DD", "AG"

                Btn_Buscar_Transportista.Enabled = True
                Txt_Transportista.Enabled = True
                Txt_Datos_Entidad_Direccion.Enabled = True
                Chk_Transpor_Por_Pagar.Enabled = True

                If Not _Cl_Despacho.Desde_Documento Then
                    Call Btn_Buscar_Documentos_Click(Nothing, Nothing)
                End If

                Dim _Revisar_Direcciones_Despacho As Boolean

                If _Tipo_Envio = "AG" Then

                    Txt_Tipo_Venta.Tag = _Cl_Despacho.Row_Conf_Despacho.Item("Tipo_Venta_X_Defecto")
                    Txt_Tipo_Venta.Text = _Cl_Despacho.Row_Conf_Despacho.Item("Nom_Tipo_Venta")

                    Txt_Transportista.Tag = _Cl_Despacho.Row_Conf_Despacho.Item("Transportista_X_Defecto")
                    Txt_Transportista.Text = _Cl_Despacho.Row_Conf_Despacho.Item("Nom_Transportista")

                    If String.IsNullOrEmpty(Txt_Tipo_Venta.Tag) Then
                        Call Btn_Buscar_Tipo_Venta_Click(Nothing, Nothing)
                    End If

                    Dim _AG_AgenciaxDefDespachos As Boolean
                    Dim _AG_Transportista As String
                    Dim _AG_Nombre_Contacto As String

                    If Not IsNothing(_Row_AgenciaXEntidad) Then

                        _AG_AgenciaxDefDespachos = _Row_AgenciaXEntidad.Item("AG_AgenciaxDefDespachos")
                        _AG_Transportista = _Row_AgenciaXEntidad.Item("AG_Transportista")
                        _AG_Nombre_Contacto = _Row_AgenciaXEntidad.Item("AG_Nombre_Contacto")

                        If _AG_AgenciaxDefDespachos Then

                            Consulta_Sql = "Select * From TABRETI 
                                            Left Join " & _Global_BaseBk & "Zw_Despachos_Transportistas On CodTransportista = KORETI
                                            Where KORETI = '" & _AG_Transportista & "'"
                            _Row_Transportista = _Sql.Fx_Get_DataRow(Consulta_Sql)

                            If Not IsNothing(_Row_Transportista) Then

                                If MessageBoxEx.Show(Me, "¿Desea utilizar a este transportista: " & _Row_Transportista.Item("NORETI").ToString.Trim & "?",
                                                     "Agencia por defecto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                                    Txt_Transportista.Tag = _AG_Transportista
                                    Txt_Transportista.Text = _Row_Transportista.Item("NORETI")
                                    _Revisar_Direcciones_Despacho = False

                                Else
                                    _AG_Nombre_Contacto = String.Empty
                                End If

                                _Row_Despacho.Item("Nombre_Contacto") = _AG_Nombre_Contacto

                            End If

                        End If

                    End If

                    If String.IsNullOrEmpty(Txt_Transportista.Tag) Then

                        Call Btn_Buscar_Transportista_Click(Nothing, Nothing)

                        If Not IsNothing(_Row_Transportista) Then

                            Dim _Koenresp = NuloPorNro(_Row_Transportista.Item("KOENRESP"), "")
                            Dim _Suenresp = NuloPorNro(_Row_Transportista.Item("SUENRESP"), "")

                            _CodEntidad_Dir = _Koenresp
                            _CodSucEntidad_Dir = _Suenresp

                            _Revisar_Direcciones_Despacho = Not String.IsNullOrEmpty(_CodEntidad_Dir.ToString.Trim)

                            If _Row_Transportista.Item("RETCLI") Then
                                _Revisar_Direcciones_Despacho = False
                            End If

                        End If

                    End If

                    If String.IsNullOrEmpty(Txt_Transportista.Tag) Then
                        Sb_Limpiar()
                        Return
                    End If

                    If Not _Revisar_Direcciones_Despacho Then

                        _Row_Despacho.Item("Direccion") = "RETIRO EN AGENCIA/OFICINA DE " & Txt_Transportista.Text

                        If _Row_Transportista.Item("RETCLI") Then

                            _Row_Despacho.Item("CodPais") = _Row_Transportista.Item("PARETI")
                            _Row_Despacho.Item("CodCiudad") = _Row_Transportista.Item("CIRETI")
                            _Row_Despacho.Item("CodComuna") = _Row_Transportista.Item("CMRETI")
                            _Row_Despacho.Item("Direccion") = _Row_Transportista.Item("DIRETI")

                            '_Row_Despacho.Item("Telefono")
                            '_Row_Despacho.Item("Email")
                            _Row_Despacho.Item("Nombre_Contacto") = _AG_Nombre_Contacto

                        End If

                        Sb_Modificar_Direccion_1()

                        If _Row_Transportista.Item("RETCLI") Then

                            If Not _AG_AgenciaxDefDespachos Then

                                _AG_Transportista = Txt_Transportista.Tag
                                _AG_Nombre_Contacto = _Row_Despacho.Item("Nombre_Contacto")

                                If MessageBoxEx.Show(Me, "¿Desea dejar a este transporte por defecto para los despachos por agencia de este cliente?" & vbCrLf & vbCrLf &
                                                     "Trasporte: " & Txt_Transportista.Tag.ToString.Trim & " - " & Txt_Transportista.Text, "Transporte de agencia por defecto",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                                    Dim _CodEntidad As String = _Cl_Despacho.Row_Entidad.Item("KOEN")
                                    Dim _CodSucEntidad As String = _Cl_Despacho.Row_Entidad.Item("SUEN")

                                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Entidades Set " & vbCrLf &
                                                   "AG_AgenciaxDefDespachos = 1, AG_Transportista = '" & _AG_Transportista & "', AG_Nombre_Contacto = '" & _AG_Nombre_Contacto & "'" & vbCrLf &
                                                   "Where CodEntidad = '" & _CodEntidad & "' And CodSucEntidad = '" & _CodSucEntidad & "'"
                                    _Sql.Fx_Ejecutar_Consulta(Consulta_Sql)

                                End If

                            End If

                        End If

                    End If

                ElseIf _Tipo_Envio = "DD" Then

                    _Revisar_Direcciones_Despacho = True

                End If


                If _Revisar_Direcciones_Despacho Then

                    Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Despachos_Direcc_Cli",
                                                        "CodEntidad = '" & _CodEntidad_Dir & "' And " &
                                                        "CodSucEntidad = '" & _CodSucEntidad_Dir & "'")

                    Sb_Cargar_Direccion_Despcaho(True, 0, _CodEntidad_Dir, _CodSucEntidad_Dir)

                    If _Reg > 0 Then

                        If IsNothing(_Row_Direccion_Despacho) Then

                            Sb_Modificar_Direccion_2(_CodEntidad_Dir, _CodSucEntidad_Dir)

                            If IsNothing(_Row_Direccion_Despacho) Then

                                Sb_Limpiar()
                                Return

                            End If

                        Else

                            Dim _Msg = MessageBoxEx.Show(Me, "¿Confirma la dirección de despacho?" & vbCrLf & vbCrLf &
                                                 "Dirección: " & _Cl_Despacho.Row_Despacho.Item("Direccion").ToString.Trim & vbCrLf & vbCrLf &
                                                 "Comuna: " & _Cl_Despacho.Row_Despacho.Item("Comuna").ToString.Trim & ", " &
                                                 _Cl_Despacho.Row_Despacho.Item("Ciudad").ToString.Trim, "Dirección de despacho",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                            If _Msg = DialogResult.No Then

                                _Row_Direccion_Despacho = Nothing

                                Sb_Modificar_Direccion_2(_CodEntidad_Dir, _CodSucEntidad_Dir)

                                If IsNothing(_Row_Direccion_Despacho) Then

                                    Sb_Limpiar()
                                    Return

                                End If

                            End If

                        End If

                    End If

                    If IsNothing(_Row_Direccion_Despacho) Then

                        Dim _Row_Entidad_Dir As DataRow = Fx_Traer_Datos_Entidad(_CodEntidad_Dir, _CodSucEntidad_Dir)

                        _Pais_Dir = _Row_Entidad_Dir.Item("PAEN")
                        _Ciudad_Dir = _Row_Entidad_Dir.Item("CIEN")
                        _Comuna_Dir = _Row_Entidad_Dir.Item("CMEN")
                        _Direccion_Dir = _Row_Entidad_Dir.Item("DIEN").ToString.Trim
                        _Telefono_Dir = _Row_Entidad_Dir.Item("FOEN").ToString.Trim
                        _Email_Dir = _Row_Entidad_Dir.Item("EMAILCOMER").ToString.Trim

                        Dim Fm As New Frm_Direc_Cli(_CodEntidad_Dir, _CodSucEntidad_Dir, 0)

                        Fm.Row_Despacho_Cli.Item("Pais") = _Pais_Dir
                        Fm.Row_Despacho_Cli.Item("Ciudad") = _Ciudad_Dir
                        Fm.Row_Despacho_Cli.Item("Comuna") = _Comuna_Dir
                        Fm.Row_Despacho_Cli.Item("Direccion") = _Direccion_Dir
                        Fm.Row_Despacho_Cli.Item("Telefono") = _Telefono_Dir
                        Fm.Row_Despacho_Cli.Item("Email") = _Email_Dir
                        Fm.Row_Despacho_Cli.Item("Por_Defecto") = True
                        Fm.Chk_Por_Defecto.Enabled = False

                        Fm.ShowDialog(Me)

                        If CBool(Fm.Id) Then
                            Sb_Cargar_Direccion_Despcaho(False, Fm.Id, _CodEntidad_Dir, _CodSucEntidad_Dir)
                        End If

                        Fm.Dispose()

                    End If

                    If IsNothing(_Row_Direccion_Despacho) Then

                        If _Tipo_Envio = "AG" Then
                            MessageBoxEx.Show(Me, "Debe ingresar una dirección de despacho para el transportista", "Validación",
                                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If

                        If _Tipo_Envio = "DD" Then
                            MessageBoxEx.Show(Me, "Debe ingresar una dirección de despacho para el cliente", "Validación",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If

                        Cmb_Tipo_Envio.SelectedValue = ""
                        Return

                    End If

                End If

                If _Tipo_Envio = "DD" Or _Tipo_Envio = "AG" Then

                    Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Chilexpress_Conf Where Activo = 1"
                    Dim _Row_Conf As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                    If Not IsNothing(_Row_Conf) Then

                        Dim _Activa_Chilexpress As Boolean = (Txt_Transportista.Tag.ToString.Trim = _Row_Conf.Item("CodTransportista").ToString.Trim) '"CHILEXPRESS")

                        If _Activa_Chilexpress Then

                            Btn_Chilexpress.Visible = True
                            Call Btn_Chilexpress_Click(Nothing, Nothing)

                        End If

                    End If

                End If

                Txt_Referencia.Focus()

            Case Else

                Sb_Limpiar()

                Return

        End Select

        Warning_Cantidad.Visible = (_Kilos_Minimo > _Total_Venta_Kilos And Cmb_Tipo_Envio.SelectedValue = "DD")
        Warning_Valor.Visible = (_Netos_Minimo > _Total_Venta_Neto And Cmb_Tipo_Envio.SelectedValue = "DD")

        Sb_Cargar_Datos_Envio()

    End Sub

    Sub Sb_Modificar_Direccion_1()

        Dim _Tipo_Envio = Cmb_Tipo_Envio.SelectedValue

        Dim _Row_Despacho As DataRow = _Cl_Despacho.Tbl_Despacho.Rows(0)

        Select Case _Tipo_Envio

            Case "RT", "AG", "DD"

                Dim _Grabar As Boolean

                Dim Fm As New Frm_Direccion_Desp
                Fm.CodPais = _Row_Despacho.Item("CodPais")
                Fm.CodCiudad = _Row_Despacho.Item("CodCiudad")
                Fm.CodComuna = _Row_Despacho.Item("CodComuna")
                Fm.Direccion = _Row_Despacho.Item("Direccion")
                Fm.Telefono = _Row_Despacho.Item("Telefono")
                Fm.Email = _Row_Despacho.Item("Email")
                Fm.Txt_Nombre_Contacto.Text = _Row_Despacho.Item("Nombre_Contacto")
                Fm.Observaciones = Txt_Observaciones.Text

                If Not IsNothing(_Row_Transportista) Then
                    Fm.Btn_Buscar_Comuna.Enabled = Not _Row_Transportista.Item("RETCLI")
                    Fm.Txt_Comuna.Enabled = Not _Row_Transportista.Item("RETCLI")
                    Fm.Txt_Direccion.Enabled = Not _Row_Transportista.Item("RETCLI")
                End If

                If _Tipo_Envio = "RT" Then
                    Fm.Txt_Comuna.Enabled = False
                    Fm.Btn_Buscar_Comuna.Enabled = False
                    Fm.Txt_Direccion.Enabled = False
                    Fm.Btn_Buscar_Comuna.Enabled = False
                    Fm.Btn_Direccion_Servicio.Visible = False
                End If

                If _Tipo_Envio = "AG" Then
                    If String.IsNullOrEmpty(Fm.Telefono) Then Fm.Telefono = _Cl_Despacho.Row_Entidad.Item("FOEN").ToString.Trim
                    If String.IsNullOrEmpty(Fm.Email) Then Fm.Email = _Cl_Despacho.Row_Entidad.Item("EMAILCOMER").ToString.Trim
                End If

                'If _Tipo_Envio <> "RT" Then
                '    If String.IsNullOrEmpty(Fm.CodComuna.Trim) Then Fm.Buscar_Comuna_Inmediatamente = True
                'End If

                Fm.ShowDialog(Me)

                _Grabar = Fm.Grabar

                If _Grabar Then

                    _Row_Despacho.Item("CodPais") = Fm.CodPais
                    _Row_Despacho.Item("CodCiudad") = Fm.CodCiudad
                    _Row_Despacho.Item("CodComuna") = Fm.CodComuna.ToString.Trim
                    _Row_Despacho.Item("Pais") = Fm.Pais.Trim
                    _Row_Despacho.Item("Ciudad") = Fm.Ciudad.Trim
                    _Row_Despacho.Item("Comuna") = Fm.Comuna.Trim
                    _Row_Despacho.Item("Direccion") = Fm.Direccion.Trim
                    _Row_Despacho.Item("Nombre_Contacto") = Fm.Txt_Nombre_Contacto.Text.Trim
                    _Row_Despacho.Item("Telefono") = Fm.Telefono.Trim
                    _Row_Despacho.Item("Email") = Fm.Email.Trim

                    Txt_Observaciones.Text = Fm.Observaciones.Trim

                    If _Tipo_Envio = "DD" Then

                        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Despachos_Direcc_Cli Set" & vbCrLf &
                                       "Pais = '" & Fm.CodPais & "'," &
                                       "Ciudad = '" & Fm.CodCiudad & "'," &
                                       "Comuna = '" & Fm.CodComuna & "'," &
                                       "Direccion = '" & Fm.Direccion.Trim & "'," &
                                       "Nombre_Contacto = '" & Fm.Txt_Nombre_Contacto.Text.Trim & "'," &
                                       "Telefono = '" & Fm.Telefono.Trim & "'," &
                                       "Email = '" & Fm.Email.Trim & "'," &
                                       "Tipo_Venta = '" & Txt_Tipo_Venta.Tag & "'," &
                                       "Transportista = '" & Txt_Transportista.Tag & "'" & vbCrLf &
                                       "Where Id = " & _Row_Direccion_Despacho.Item("Id")

                        _Sql.Ej_consulta_IDU(Consulta_Sql)

                    End If

                    Sb_Cargar_Datos_Envio()

                End If

                Fm.Dispose()

            Case Else

                SuperTabControl1.Enabled = False
                Txt_Datos_Entidad_Direccion.Text = String.Empty

                Chk_Transpor_Por_Pagar.Checked = False
                Chk_Transpor_Por_Pagar.Enabled = False

        End Select

    End Sub

    Sub Sb_Cargar_Datos_Envio()

        Dim _Row_Despacho As DataRow = _Cl_Despacho.Row_Despacho

        Dim _Contacto = String.Empty

        If Not String.IsNullOrEmpty(_Row_Despacho.Item("Nombre_Contacto").ToString.Trim) Then
            _Contacto = "Contacto: " & _Row_Despacho.Item("Nombre_Contacto")
        End If

        Dim _Direccion As String = _Row_Despacho.Item("Direccion").ToString.Trim
        _Direccion = Replace(_Direccion, "'", "''")

        Dim _CodEntidad As String = _Cl_Despacho.Row_Entidad.Item("KOEN")
        Dim _CodSucEntidad As String = _Cl_Despacho.Row_Entidad.Item("SUEN")

        Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Despachos_Direcc_Cli" & vbCrLf &
                       "Where CodEntidad = '" & _CodEntidad & "' And CodSucEntidad = '" & _CodSucEntidad & "' And Direccion = '" & _Direccion & "'"
        Dim _Row_Direccion As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Dim _Ha = String.Empty

        If Not IsNothing(_Row_Direccion) Then
            If _Row_Direccion.Item("Usar_HA") Then
                _Ha = vbCrLf & "*** Horario de atención. Mañana de " & FormatDateTime(_Row_Direccion.Item("HA_Manana_Desde"), DateFormat.ShortTime) &
                               " a " & FormatDateTime(_Row_Direccion.Item("HA_Manana_Hasta"), DateFormat.ShortTime) &
                               " tarde de " & FormatDateTime(_Row_Direccion.Item("HA_Tarde_Desde"), DateFormat.ShortTime) &
                               " a " & FormatDateTime(_Row_Direccion.Item("HA_Tarde_Hasta"), DateFormat.ShortTime)
            End If
        End If

        'Dim _EntregaPaletizada As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Entidades",
        '                                                  "EntregaPaletizada", "CodEntidad = '" & _CodEntidad & "' And CodSucEntidad = '" & _CodSucEntidad & "'",,,, True)

        If Chk_EntregaPaletizada.Checked Then
            _Ha += vbCrLf & "*** ENTREGA PALETIZADA ***"
        End If

        Txt_Datos_Entidad_Direccion.Text = _Cl_Despacho.Row_Entidad.Item("NOKOEN") & vbCrLf &
                                           _Cl_Despacho.Row_Entidad.Item("Rut") & vbCrLf & vbCrLf &
                                           _Row_Despacho.Item("Direccion") & vbCrLf &
                                           _Row_Despacho.Item("Ciudad") & vbCrLf &
                                           _Row_Despacho.Item("Comuna") & vbCrLf &
                                           _Contacto & vbCrLf &
                                           _Row_Despacho.Item("Telefono") & vbCrLf &
                                           _Row_Despacho.Item("Email") & vbCrLf & _Ha

    End Sub

    Private Sub Btn_Buscar_Documentos_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Documentos.Click

        If _Cl_Despacho.Accion = Clas_Despacho.Enum_Accion.Nuevo Or
           _Cl_Despacho.Estado = "ING" Or
           _Cl_Despacho.Estado = "CON" Or
           _Cl_Despacho.Estado = "PRE" Then

            Dim _Endo = _Cl_Despacho.Row_Entidad.Item("KOEN")
            Dim _Suendo = _Cl_Despacho.Row_Entidad.Item("SUEN")
            Dim _Seleccionar As Boolean
            Dim _Tbl_Documentos As DataTable

            Dim _Filtro_Idmaeedo = Generar_Filtro_IN(_Cl_Despacho.Tbl_Despacho_Doc, "", "Idrst", False, False, "")

            If CBool(_Cl_Despacho.Tbl_Despacho_Doc.Rows.Count) Then

                Consulta_Sql = "Select * From MAEEDO Where IDMAEEDO In " & _Filtro_Idmaeedo
                _Tbl_Documentos = _Sql.Fx_Get_DataTable(Consulta_Sql)

            End If

            Dim Fm As New Frm_Sel_Documentos(_Endo, _Suendo)
            Fm.Cl_Despacho = _Cl_Despacho
            Fm.Tbl_Documentos_Seleccionados = _Tbl_Documentos
            Fm.Text = "SELECCIONE DOCUMENTOS PARA EL DESPACHO"
            If CBool(Fm.Tbl_Informe.Rows.Count) Then
                Fm.ShowDialog(Me)
                _Seleccionar = Fm.Seleccionar
                _Tbl_Documentos = Fm.Tbl_Informe
            Else
                MessageBoxEx.Show(Me, "No existen documentos pendientes de despacho para la entidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

            Fm.Dispose()

            If _Seleccionar Then

                _Cl_Despacho.Tbl_Despacho_Doc.Clear()

                For Each _Fila As DataRow In _Tbl_Documentos.Rows

                    Dim _Idmaeedo = _Fila.Item("Idrst")
                    Dim _Tido = _Fila.Item("Tido")
                    Dim _Nudo = _Fila.Item("Nudo")
                    Dim _CantC = _Fila.Item("CantC")
                    Dim _CantD = _Fila.Item("CantD")
                    Dim _CantE = _Fila.Item("CantE")
                    Dim _CantR = 0
                    Dim _Nudonodefi = _Fila.Item("Nudonodefi")

                    _Cl_Despacho.Fx_Nuevo_Documento("MAEEDO", _Idmaeedo, _Tido, _Nudo, _CantC, _CantD, _CantE, _CantR, _Nudonodefi)

                Next

                Sb_Actualizar_Grillas()

            End If

        End If

    End Sub

    Sub Sb_Actualizar_Grillas()

        Sb_Actualizar_Grilla_Documentos()
        Sb_Actualizar_Grilla_Productos()

    End Sub

    Sub Sb_Actualizar_Grilla_Documentos()

        Dim _Filtro_Idmaeedo = Generar_Filtro_IN(_Cl_Despacho.Tbl_Despacho_Doc, "", "Idrst", False, False, "")

        If CBool(_Cl_Despacho.Tbl_Despacho_Doc.Rows.Count) Then
            _Filtro_Idmaeedo = "Where IDMAEEDO In " & _Filtro_Idmaeedo
        Else
            _Filtro_Idmaeedo = "Where 1 < 0"
        End If

        Consulta_Sql = "Select IDMAEEDO,TIDO,NUDO,ENDO,SUENDO,NOKOEN,FEEMDO,FEER 
                        From MAEEDO 
                        Left Join MAEEN On KOEN = ENDO And SUEN = SUENDO" & vbCrLf & _Filtro_Idmaeedo

        Dim _Tbl_Documentos As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        Dim _DisplayIndex = 0

        With Grilla_Documentos

            .DataSource = _Tbl_Documentos

            OcultarEncabezadoGrilla(Grilla_Documentos, False)

            .Columns("TIDO").Width = 35
            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Visible = True
            .Columns("TIDO").ReadOnly = False
            .Columns("TIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDO").Width = 75
            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").ReadOnly = True
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ENDO").Width = 80
            .Columns("ENDO").HeaderText = "Entidad"
            .Columns("ENDO").ReadOnly = True
            .Columns("ENDO").Visible = True
            .Columns("ENDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SUENDO").Width = 50
            .Columns("SUENDO").HeaderText = "Suc"
            .Columns("SUENDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SUENDO").ReadOnly = True
            .Columns("SUENDO").Visible = True
            .Columns("SUENDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOEN").Width = 250
            .Columns("NOKOEN").HeaderText = "Razón Social"
            .Columns("NOKOEN").ReadOnly = True
            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMDO").Width = 80
            .Columns("FEEMDO").HeaderText = "Fecha E."
            .Columns("FEEMDO").ReadOnly = True
            .Columns("FEEMDO").Visible = True
            .Columns("FEEMDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Sub Sb_Actualizar_Grilla_Productos()

        Dim _Filtro_Idmaeedo = Generar_Filtro_IN(_Cl_Despacho.Tbl_Despacho_Doc, "", "Idrst", False, False, "")

        If CBool(_Cl_Despacho.Tbl_Despacho_Doc.Rows.Count) Then
            _Filtro_Idmaeedo = "Where IDMAEEDO In " & _Filtro_Idmaeedo
        Else
            _Filtro_Idmaeedo = "Where 1 < 0"
        End If

        Dim _Empresa = _Cl_Despacho.Tbl_Despacho.Rows(0).Item("Empresa")
        Dim _Sucursal = _Cl_Despacho.Tbl_Despacho.Rows(0).Item("Sucursal")

        Consulta_Sql = "Select KOPRCT,NOKOPR,Case UDTRPR When 1 Then UD01PR Else UD02PR End As UD," &
                       "Case UDTRPR When 1 Then Sum(CAPRCO1) Else Sum(CAPRCO1) End As CANTIDAD" & vbCrLf &
                       "From MAEDDO" & vbCrLf & _Filtro_Idmaeedo & vbCrLf &
                       "--And EMPRESA = '" & _Empresa & "' And SULIDO = '" & _Sucursal & "' " & vbCrLf &
                       "Group By KOPRCT,NOKOPR,UDTRPR,UD01PR,UD02PR"

        Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        Dim _DisplayIndex = 0

        With Grilla_Productos

            .DataSource = _Tbl_Productos

            OcultarEncabezadoGrilla(Grilla_Productos, False)

            .Columns("KOPRCT").Width = 100
            .Columns("KOPRCT").HeaderText = "Código"
            .Columns("KOPRCT").Visible = True
            .Columns("KOPRCT").ReadOnly = False
            .Columns("KOPRCT").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOPR").Width = 360
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").ReadOnly = True
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("UD").Width = 30
            .Columns("UD").HeaderText = "Ud"
            .Columns("UD").ReadOnly = True
            .Columns("UD").Visible = True
            .Columns("UD").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CANTIDAD").Width = 80
            .Columns("CANTIDAD").HeaderText = "Cantidad"
            .Columns("CANTIDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CANTIDAD").ReadOnly = True
            .Columns("CANTIDAD").Visible = True
            .Columns("CANTIDAD").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Grilla_Documentos_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla_Documentos.KeyDown

        If CBool(Grilla_Documentos.RowCount) Then

            Dim _Cabeza = Grilla_Documentos.Columns(Grilla_Documentos.CurrentCell.ColumnIndex).Name
            Dim _Fila As DataGridViewRow = Grilla_Documentos.Rows(Grilla_Documentos.CurrentRow.Index)

            Dim _Tecla As Keys

            _Tecla = e.KeyValue

            Select Case _Tecla

                Case Keys.Delete

                    Sb_Eliminar_Fila(_Fila)

            End Select

        End If

    End Sub

    Sub Sb_Eliminar_Fila(ByVal _Fila As DataGridViewRow)

        Dim _Index As Integer = _Fila.Index
        Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value

        If MessageBoxEx.Show(Me, "¿Esta seguro de querer quitar el documento " & _Fila.Cells("TIDO").Value & "-" & _Fila.Cells("NUDO").Value & "?",
                               "Quitar documento de la orden",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button1, Me.TopMost) = DialogResult.Yes Then

            Grilla_Documentos.Rows.RemoveAt(_Index)

            Try

                Dim filter As String = String.Format("Idmaeedo = " & _Idmaeedo)
                Dim rows() As DataRow = _Cl_Despacho.Tbl_Despacho_Doc.Select(filter)

                Dim totalValoresIguales As Integer = rows.Count

                For Each row In rows
                    _Cl_Despacho.Tbl_Despacho_Doc.Rows.Remove(row)
                Next

                _Cl_Despacho.Tbl_Despacho_Doc.AcceptChanges()
                Sb_Actualizar_Grilla_Productos()

            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub Btn_Ver_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Documento.Click

        Me.Enabled = False

        Dim _Fila As DataGridViewRow = Grilla_Documentos.Rows(Grilla_Documentos.CurrentRow.Index)
        Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Me.Enabled = True

    End Sub

    Private Sub Btn_Quitar_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Quitar_Documento.Click

        If _Cl_Despacho.Accion = Clas_Despacho.Enum_Accion.Nuevo Or
           _Cl_Despacho.Estado = "ING" Or
           _Cl_Despacho.Estado = "CON" Or
           _Cl_Despacho.Estado = "PRE" Then
            Dim _Fila As DataGridViewRow = Grilla_Documentos.Rows(Grilla_Documentos.CurrentRow.Index)
            Sb_Eliminar_Fila(_Fila)
        End If

    End Sub

    Private Sub Grilla_Documentos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Documentos.CellDoubleClick

        Call Btn_Ver_Documento_Click(Nothing, Nothing)

    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            Dim Hitest As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)

            If Hitest.Type = DataGridViewHitTestType.Cell Then
                sender.CurrentCell = sender.Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                ShowContextMenu(Menu_Contextual_01)
            End If

        End If

    End Sub

    Private Sub Sb_Grilla_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < sender.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If sender.RowHeadersWidth < CInt(size.Width + 20) Then
                sender.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "vb.net",
         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _Row_Despacho As DataRow = _Cl_Despacho.Tbl_Despacho.Rows(0)
        Dim _Se_Puede_Grabar As Boolean

        _Se_Puede_Grabar = _Cl_Despacho.Desde_Documento

        If Not _Se_Puede_Grabar Then
            _Se_Puede_Grabar = CBool(_Cl_Despacho.Tbl_Despacho_Doc.Rows.Count)
        End If

        Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Chilexpress_Conf Where Activo = 1"
        Dim _Row_Conf As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If Not IsNothing(_Row_Conf) Then

            Dim _Existe_COV_Chilexpress As Boolean

            Try
                If Txt_Transportista.Tag.ToString.Trim = _Row_Conf.Item("CodTransportista").ToString.Trim Then

                    If CBool(_Idenvio_Chilexpress) Then

                        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Chilexpress_Env Where Idenvio = " & _Idenvio_Chilexpress
                        Dim _Row_Chilexpress As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                        If Not IsNothing(_Row_Chilexpress) Then _Existe_COV_Chilexpress = True

                    End If

                    If Not _Existe_COV_Chilexpress Then
                        MessageBoxEx.Show(Me, "Debe completar todos los datos para el registro de Chilexpress", "Validación",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If

                End If
            Catch ex As Exception

            End Try

        End If

        If _Se_Puede_Grabar Then

            If String.IsNullOrEmpty(Cmb_Tipo_Envio.SelectedValue) Then
                MessageBoxEx.Show(Me, "Falta tipo de envio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Dim _Pais As String = _Row_Despacho.Item("CodPais").ToString.Trim
            Dim _Ciudad As String = _Row_Despacho.Item("CodCiudad").ToString.Trim
            Dim _Comuna As String = _Row_Despacho.Item("CodComuna").ToString.Trim
            Dim _Direccion As String = _Row_Despacho.Item("Direccion").ToString.Trim
            Dim _Nombre_Contacto As String = _Row_Despacho.Item("Nombre_Contacto").ToString.Trim
            Dim _Telefono As String = _Row_Despacho.Item("Telefono").ToString.Trim
            Dim _Email As String = _Row_Despacho.Item("Email").ToString.Trim

            If Not Fx_Validar_Email(_Email) Then
                _Row_Despacho.Item("Email") = String.Empty
                _Email = String.Empty
            End If

            If Cmb_Tipo_Envio.SelectedValue = "RT" Then

                If _Cl_Despacho.Row_Conf_Despacho.Item("Pedir_Sucursal_Retiro") And String.IsNullOrEmpty(Cmb_Sucursal_Retiro.SelectedValue.ToString.Trim) Then
                    MessageBoxEx.Show(Me, "Falta la sucursal de retiro", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Cmb_Sucursal_Retiro.Focus()
                    Return
                End If

            End If

            If (String.IsNullOrEmpty(_Email) And _Cl_Despacho.Row_Conf_Despacho.Item("Pedir_Sucursal_Retiro") And Cmb_Tipo_Envio.SelectedValue = "RT") Or
                (
                (Cmb_Tipo_Envio.SelectedValue <> "RT" And Cmb_Tipo_Envio.SelectedValue <> "RR") And
                (
                String.IsNullOrEmpty(_Pais) Or
                String.IsNullOrEmpty(_Ciudad) Or
                String.IsNullOrEmpty(_Comuna) Or
                String.IsNullOrEmpty(_Direccion) Or
                String.IsNullOrEmpty(_Nombre_Contacto) Or
                String.IsNullOrEmpty(_Telefono) Or
                String.IsNullOrEmpty(_Email)
                )
                ) Then

                MessageBoxEx.Show(Me, "Faltan datos en la dirección de despacho", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Sb_Modificar_Direccion_1()

                Return

            End If

            If IsNothing(Txt_Tipo_Venta.Tag) Or String.IsNullOrEmpty(Txt_Tipo_Venta.Text.Trim) Then
                MessageBoxEx.Show(Me, "Falta tipo de venta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            If Cmb_Tipo_Envio.SelectedValue <> "RT" Then
                If IsNothing(Txt_Transportista.Tag) Or String.IsNullOrEmpty(Txt_Transportista.Text.Trim) Then
                    MessageBoxEx.Show(Me, "Falta el trasportista", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If
            End If

            If Cmb_Tipo_Envio.SelectedValue = "RR" And Not String.IsNullOrEmpty(Txt_Transportista.Tag) Then

                Dim _CodEntidad_Dir = _Cl_Despacho.Row_Entidad.Item("KOEN")
                Dim _CodSucEntidad_Dir = _Cl_Despacho.Row_Entidad.Item("SUEN")

                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Entidades Set " & vbCrLf &
                                                "RT_Transportista = '" & Txt_Transportista.Tag & "'" & vbCrLf &
                                                "Where CodEntidad = '" & _CodEntidad_Dir & "' And CodSucEntidad = '" & _CodSucEntidad_Dir & "'"
                _Sql.Fx_Ejecutar_Consulta(Consulta_Sql)

            End If


            If ConfirmarLecturaDespacho Then

                'Sb_Confirmar_Lectura("El código ya fue leído en otro(s) documento(s) GRI",
                '         "No puede leer mas de una vez el mismo código en otro documento" & vbCrLf & vbCrLf &
                '         "Documento(s): " & _Msg, eTaskDialogIcon.Stop, Nothing)

                Dim _Msg1 = "CONFIRMA: " & Cmb_Tipo_Envio.Text
                Dim _Msg2 = vbCrLf &
                            "Dirección: " & _Direccion & vbCrLf &
                            "Transportista: " & Txt_Transportista.Text.Trim & vbCrLf &
                            "Referencia: " & Txt_Referencia.Text & vbCrLf

                If Not Fx_Confirmar_Lectura(_Msg1, _Msg2, eTaskDialogIcon.Exclamation) Then
                    Return
                End If

            End If


            Dim _Confirmado As Boolean = Not _Cl_Despacho.Desde_Documento
            Dim _Nro_Despacho As String = _Cl_Despacho.Fx_Nuevo_Nro_Despacho(_Confirmado)

            Dim _Empresa As String = _Row_Despacho.Item("Empresa")
            Dim _Sucursal As String = _Row_Despacho.Item("Sucursal")

            If _Cl_Despacho.Accion = Clas_Despacho.Enum_Accion.Nuevo Then

                _Row_Despacho.Item("Nro_Sub") = "000"
                _Row_Despacho.Item("Fecha_Emision") = FechaDelServidor()
                _Row_Despacho.Item("Tipo_Despacho") = "CLI"
                _Row_Despacho.Item("Estado") = "ING"

            End If

            _Row_Despacho.Item("CodFuncionario") = FUNCIONARIO

            _Row_Despacho.Item("Fecha_Compromiso") = Dtp_Fecha_Despacho.Value
            _Row_Despacho.Item("Confirmado") = _Confirmado

            _Row_Despacho.Item("Referencia") = Txt_Referencia.Text.Trim
            _Row_Despacho.Item("CodEntidad") = _Cl_Despacho.Row_Entidad.Item("KOEN")
            _Row_Despacho.Item("CodSucEntidad") = _Cl_Despacho.Row_Entidad.Item("SUEN")
            _Row_Despacho.Item("Rut") = _Cl_Despacho.Row_Entidad.Item("Rut")
            _Row_Despacho.Item("Nombre_Entidad") = _Cl_Despacho.Row_Entidad.Item("NOKOEN")
            _Row_Despacho.Item("Tipo_Envio") = Cmb_Tipo_Envio.SelectedValue
            _Row_Despacho.Item("Tipo_Venta") = Txt_Tipo_Venta.Tag
            _Row_Despacho.Item("Sucursal_Retiro") = Mid(Cmb_Sucursal_Retiro.SelectedValue, 3, 3)

            If Cmb_Tipo_Envio.SelectedValue = "RT" Then
                _Row_Despacho.Item("Direccion") = "RETIRA EN SUCURSAL: " & Cmb_Sucursal_Retiro.Text.Trim
            End If

            _Row_Despacho.Item("Transportista") = NuloPorNro(Txt_Transportista.Tag, "")

            _Row_Despacho.Item("Transpor_Por_Pagar") = Chk_Transpor_Por_Pagar.Checked
            _Row_Despacho.Item("Entregar_Con_Doc_Pagados") = Chk_Entregar_Con_Doc_Pagados.Checked

            _Row_Despacho.Item("Observaciones") = Txt_Observaciones.Text.Trim
            _Row_Despacho.Item("EntregaPaletizada") = Chk_EntregaPaletizada.Checked

            If _Cl_Despacho.Accion = Clas_Despacho.Enum_Accion.Nuevo Then

                _Grabar = _Cl_Despacho.Fx_Grabar_Documento()

                If _Grabar Then

                    If Not _Cl_Despacho.Desde_Documento Then

                        _Row_Despacho.Item("Confirmado") = True

                        Consulta_Sql = "Select Distinct EMPRESA,SULIDO,BOSULIDO From MAEDDO Where IDMAEEDO In (Select Idrst From " & _Global_BaseBk & "Zw_Despachos_Doc 
                                        Where Id_Despacho = " & _Cl_Despacho.Id_Despacho & ")"
                        Dim _Tbl_Bodegas As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

                        Dim _Id_Despacho_Padre As Integer

                        _Cl_Despacho.Sb_Crear_Desdespachos_Para_Todas_Las_Bodegas(_Cl_Despacho.Id_Despacho, _Id_Despacho_Padre)

                        If _Tbl_Bodegas.Rows.Count > 1 Then

                            MessageBoxEx.Show(Me, "Se crearón distintas Ordenes de Despacho para las distintas bodegas de cada una de las lineas de los documentos",
                                      "Ordenes de despacho", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        End If

                    End If

                End If

            ElseIf _Cl_Despacho.Accion = Clas_Despacho.Enum_Accion.Editar Then

                _Grabar = _Cl_Despacho.Fx_Editar_Documento

            End If

            If _Grabar Then
                Me.Close()
            End If

        Else

            MessageBoxEx.Show(Me, "Debe ingresar los documentos de despacho", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click

        If _Cl_Despacho.Estado = "ING" Or _Cl_Despacho.Estado = "CON" Or _Cl_Despacho.Estado = "PRE" Or _Cl_Despacho.Estado = "DPR" Or _Cl_Despacho.Desde_Documento Then

            If _Cl_Despacho.Fx_Se_Puede_Editar_La_Orden(Me) Then

                Sb_Habilitar_Controles(True)
                _Cl_Despacho.Fx_Tomar_Orden_Despacho(_Cl_Despacho.Id_Despacho, FUNCIONARIO)

                Beep()
                ToastNotification.Show(Me, "EDICION ACTIVA",
                                       Btn_Editar.Image,
                                       1 * 1000, eToastGlowColor.Green,
                                       eToastPosition.MiddleCenter)
                Me.Refresh()

            End If

        End If

    End Sub

    Sub Sb_Habilitar_Controles(_Habilitar As Boolean)

        Btn_Modificar_Direccion.Enabled = _Habilitar
        Cmb_Tipo_Envio.Enabled = _Habilitar
        Btn_Buscar_Tipo_Venta.Enabled = _Habilitar
        Btn_Buscar_Transportista.Enabled = _Habilitar
        Btn_Modificar_Direccion.Enabled = _Habilitar
        Btn_Buscar_Documentos.Enabled = _Habilitar
        Dtp_Fecha_Despacho.Enabled = _Habilitar

        Chk_Transpor_Por_Pagar.Enabled = _Habilitar
        Chk_Entregar_Con_Doc_Pagados.Enabled = _Habilitar

        Txt_Referencia.ReadOnly = Not _Habilitar

        Dim _Color As Color

        If Global_Thema = Enum_Themas.Oscuro Then
            If _Habilitar Then
                _Color = Color.Black
            Else
                _Color = Color.Gray
            End If
        Else
            If _Habilitar Then
                _Color = Color.White
            Else
                _Color = Color.AliceBlue
            End If
        End If

        Txt_Nombre_Cliente.BackColor = _Color
        Txt_Referencia.BackColor = _Color
        Txt_Transportista.BackColor = _Color
        Txt_Datos_Entidad_Direccion.BackColor = _Color

        If Btn_Editar.Visible Then

            Btn_Editar.Enabled = Not _Habilitar
            Btn_Grabar.Enabled = _Habilitar
            Btn_Cancelar.Visible = _Habilitar

        End If

        Me.Refresh()

    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click

        _Cl_Despacho.Sb_Cargar_Despacho(_Cl_Despacho.Id_Despacho)

        Beep()
        ToastNotification.Show(Me, "EDICION CANCELADA, LOS CAMBIOS SERAN REVERTIDOS",
                               Btn_Editar.Image,
                               1 * 1000, eToastGlowColor.Green,
                               eToastPosition.MiddleCenter)

        Sb_Cargar_Despacho()

        _Cl_Despacho.Fx_Soltar_Orden_Despacho(_Cl_Despacho.Id_Despacho, FUNCIONARIO)

    End Sub

    Private Sub Sb_Dtp_Fecha_Despacho_ValueChanged(sender As Object, e As EventArgs)

        Dim _Fecha_Servidor As Date = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)
        Dim _Fecha_Despacho As Date = FormatDateTime(Dtp_Fecha_Despacho.Value, DateFormat.ShortDate)

        'If (DateTime.Compare(_Fecha_Servidor, _Fecha_Despacho) > 0) Then
        '    Return
        'End If '// La Then fecha actual es mayor que la fecha insertada.

        'If (DateTime.Compare(_Fecha_Servidor, _Fecha_Despacho) = 0) Then
        '    Return
        'End If

        ''// La Then fecha actual y la fecha insertada son iguales.

        'If (DateTime.Compare(_Fecha_Servidor, _Fecha_Despacho) < 0) Then
        '    Return
        'End If '// La Then fecha actual es menor que la fecha insertada.

        If (DateTime.Compare(_Fecha_Servidor, _Fecha_Despacho) > 0) Then

            MessageBoxEx.Show(Me, "La fecha de despacho no puede ser menor a la fecha de hoy", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Dtp_Fecha_Despacho.Value = FechaDelServidor()

        End If

    End Sub

    Private Sub Frm_Desp_01_Ingreso_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Buscar_Tipo_Venta_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Tipo_Venta.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
        _Filtrar.Campo = "CodigoTabla"
        _Filtrar.Descripcion = "NombreTabla"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "TIPO DE VENTA"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "And Tabla = 'SIS_DESPACHO_TIPO_VENTA'",
                               Nothing, False, True) Then

            Dim _Tbl_Transportista As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Transportista.Rows(0)

            Dim _Codigo = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Txt_Tipo_Venta.Tag = _Codigo
            Txt_Tipo_Venta.Text = _Descripcion

        End If

    End Sub

    Function Fx_Sucursal_Retiro() As String

        Dim _Filtrar As New Clas_Filtros_Random(Me)
        Dim _Codigo = String.Empty

        _Filtrar.Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
        _Filtrar.Campo = "CodigoTabla"
        _Filtrar.Descripcion = "NombreTabla"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "SUCURSAL DE RETIRO"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Sucursales, "",
                               Nothing, False, True) Then

            Dim _Tbl_Transportista As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Transportista.Rows(0)

            _Codigo = ModEmpresa & _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

        End If

        Return _Codigo

    End Function


    Sub Sb_Cargar_Direccion_Despcaho(_Por_Defecto As Boolean, _Id As Integer, _CodEntidad As String, _CodSucEntidad As String)

        Dim _Condicion As String

        If _Por_Defecto Then
            '_Condicion = "CodEntidad = '" & _Cl_Despacho.Row_Entidad.Item("KOEN") & "' And CodSucEntidad = '" & _Cl_Despacho.Row_Entidad.Item("SUEN") & "' And Por_Defecto = 1"
            _Condicion = "CodEntidad = '" & _CodEntidad & "' And CodSucEntidad = '" & _CodSucEntidad & "' And Por_Defecto = 1"
        Else
            _Condicion = "Id = " & _Id
        End If

        Consulta_Sql = "Select Top 1 Desp.*,Pa.NOKOPA,Ci.NOKOCI,Cm.NOKOCM,Isnull(Tvta.NombreTabla,'') As Nom_Tipo_Venta,Isnull(NORETI,'') As Nom_Transportista,TABRETI.*,
                        PaReti.NOKOPA As Pais_Reti,CiReti.NOKOCI As Ciudad_Reti,CmReti.NOKOCM As Comuna_Reti
                            From " & _Global_BaseBk & "Zw_Despachos_Direcc_Cli Desp
                            Left Join TABPA Pa On Pa.KOPA = Pais
                            Left Join TABCI Ci On Ci.KOPA = Pais And Ci.KOCI = Ciudad
                            Left Join TABCM Cm On Cm.KOPA = Pais And Cm.KOCI = Ciudad And Cm.KOCM = Comuna
                            Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Tvta On Tvta.Tabla = 'SIS_DESPACHO_TIPO_VENTA' And Tvta.CodigoTabla = Tipo_Venta
                            Left Join TABRETI On KORETI = Transportista
                            Left Join TABPA PaReti On PaReti.KOPA = TABRETI.PARETI
                            Left Join TABCI CiReti On CiReti.KOPA = TABRETI.PARETI And CiReti.KOCI = TABRETI.CIRETI
                            Left Join TABCM CmReti On CmReti.KOPA = TABRETI.PARETI And CmReti.KOCI = TABRETI.CIRETI And CmReti.KOCM = TABRETI.CMRETI 
                            Where " & _Condicion

        _Row_Direccion_Despacho = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If Not IsNothing(_Row_Direccion_Despacho) Then

            _Cl_Despacho.Row_Despacho.Item("CodPais") = _Row_Direccion_Despacho.Item("Pais")
            _Cl_Despacho.Row_Despacho.Item("CodCiudad") = _Row_Direccion_Despacho.Item("Ciudad")
            _Cl_Despacho.Row_Despacho.Item("CodComuna") = _Row_Direccion_Despacho.Item("Comuna")
            _Cl_Despacho.Row_Despacho.Item("Pais") = _Row_Direccion_Despacho.Item("NOKOPA").ToString.Trim
            _Cl_Despacho.Row_Despacho.Item("Ciudad") = _Row_Direccion_Despacho.Item("NOKOCI").ToString.Trim
            _Cl_Despacho.Row_Despacho.Item("Comuna") = _Row_Direccion_Despacho.Item("NOKOCM").ToString.Trim

            _Cl_Despacho.Row_Despacho.Item("Telefono") = _Row_Direccion_Despacho.Item("Telefono")
            _Cl_Despacho.Row_Despacho.Item("Email") = _Row_Direccion_Despacho.Item("Email")
            _Cl_Despacho.Row_Despacho.Item("Direccion") = _Row_Direccion_Despacho.Item("Direccion")
            _Cl_Despacho.Row_Despacho.Item("Nombre_Contacto") = _Row_Direccion_Despacho.Item("Nombre_Contacto")

            'If _Row_Direccion_Despacho.Item("RETCLI") Then
            '    _Cl_Despacho.Row_Despacho.Item("Direccion") = _Row_Direccion_Despacho.Item("DIRETI")
            '    _Cl_Despacho.Row_Despacho.Item("CodPais") = _Row_Direccion_Despacho.Item("PARETI")
            '    _Cl_Despacho.Row_Despacho.Item("CodCiudad") = _Row_Direccion_Despacho.Item("CIRETI")
            '    _Cl_Despacho.Row_Despacho.Item("CodComuna") = _Row_Direccion_Despacho.Item("CMRETI")
            '    _Cl_Despacho.Row_Despacho.Item("Pais") = _Row_Direccion_Despacho.Item("Pais_Reti").ToString.Trim
            '    _Cl_Despacho.Row_Despacho.Item("Ciudad") = _Row_Direccion_Despacho.Item("Ciudad_Reti").ToString.Trim
            '    _Cl_Despacho.Row_Despacho.Item("Comuna") = _Row_Direccion_Despacho.Item("Comuna_Reti").ToString.Trim
            'End If

            Txt_Tipo_Venta.Tag = _Row_Direccion_Despacho.Item("Tipo_Venta")
            Txt_Tipo_Venta.Text = _Row_Direccion_Despacho.Item("Nom_Tipo_Venta")

            Txt_Transportista.Tag = _Row_Direccion_Despacho.Item("Transportista")
            Txt_Transportista.Text = _Row_Direccion_Despacho.Item("Nom_Transportista")

            If String.IsNullOrEmpty(Txt_Tipo_Venta.Tag) Then
                Txt_Tipo_Venta.Tag = _Cl_Despacho.Row_Conf_Despacho.Item("Tipo_Venta_X_Defecto")
                Txt_Tipo_Venta.Text = _Cl_Despacho.Row_Conf_Despacho.Item("Nom_Tipo_Venta")
            End If

            If String.IsNullOrEmpty(Txt_Transportista.Tag) And Not String.IsNullOrEmpty(_Cl_Despacho.Row_Conf_Despacho.Item("Transportista_X_Defecto")) Then
                Txt_Transportista.Tag = _Cl_Despacho.Row_Conf_Despacho.Item("Transportista_X_Defecto")
                Txt_Transportista.Text = _Cl_Despacho.Row_Conf_Despacho.Item("Nom_Transportista")
            Else
                Consulta_Sql = "Select * From TABRETI 
                                Left Join " & _Global_BaseBk & "Zw_Despachos_Transportistas On CodTransportista = KORETI
                                Where KORETI = '" & Txt_Transportista.Tag & "'"
                _Row_Transportista = _Sql.Fx_Get_DataRow(Consulta_Sql)

                Dim _Buscar_Transportista As Boolean

                If IsNothing(_Row_Transportista) Then
                    _Buscar_Transportista = True
                Else
                    _Buscar_Transportista = Not _Row_Transportista.Item("Mostrar")
                End If

                If _Buscar_Transportista Then

                    _Id = _Row_Direccion_Despacho.Item("Id")

                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Despachos_Direcc_Cli Set Transportista = '' Where Id = " & _Id
                    _Sql.Ej_consulta_IDU(Consulta_Sql)

                    If Not IsNothing(_Row_Transportista) Then

                        MessageBoxEx.Show(Me, "El transporte esta bloqueado para utilizar en el sistema de despachos" & vbCrLf &
                                      "Debe seleccionar otro transporte" & vbCrLf & vbCrLf &
                                      "Transporte bloqueado: " & _Row_Transportista.Item("KORETI").ToString.Trim & "-" & _Row_Transportista.Item("NORETI").ToString.Trim, "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    End If

                    Txt_Transportista.Tag = String.Empty
                    Txt_Transportista.Text = String.Empty

                    Sb_Buscar_Transportista(False)

                    If Not String.IsNullOrEmpty(Txt_Transportista.Tag) Then

                        If MessageBoxEx.Show(Me, "¿Desea dejar este transporte por defecto para esta dirección de este cliente?" & vbCrLf & vbCrLf &
                                             "Transporte: " & Txt_Transportista.Tag.ToString.Trim & " - " & Txt_Transportista.Text.ToString.Trim, "Nuevo transportista",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Despachos_Direcc_Cli Set Transportista = '" & Txt_Transportista.Tag & "' Where Id = " & _Id
                            _Sql.Ej_consulta_IDU(Consulta_Sql)
                        End If

                    End If

                End If

            End If

        End If

    End Sub

    Private Sub Btn_Modificar_Direccion_Click(sender As Object, e As EventArgs) Handles Btn_Modificar_Direccion.Click

        Dim _Revisar_Direcciones_Despacho As Boolean
        Dim _CodEntidad_Dir = _Cl_Despacho.Row_Entidad.Item("KOEN")
        Dim _CodSucEntidad_Dir = _Cl_Despacho.Row_Entidad.Item("SUEN")

        If Cmb_Tipo_Envio.SelectedValue = "AG" Then

            If Not IsNothing(_Row_Transportista) Then

                _CodEntidad_Dir = NuloPorNro(_Row_Transportista.Item("KOENRESP"), "")
                _CodSucEntidad_Dir = NuloPorNro(_Row_Transportista.Item("SUENRESP"), "")

                _Revisar_Direcciones_Despacho = Not String.IsNullOrEmpty(_CodEntidad_Dir.ToString.Trim)

            End If

            If Not _Revisar_Direcciones_Despacho Then
                Sb_Modificar_Direccion_1()
                Return
            End If

        End If

        If Cmb_Tipo_Envio.SelectedValue = "DD" Then
            _Revisar_Direcciones_Despacho = True
            'Sb_Modificar_Direccion_2(_Cl_Despacho.Row_Entidad.Item("KOEN"), _Cl_Despacho.Row_Entidad.Item("SUEN"))
        End If

        If _Revisar_Direcciones_Despacho Then
            Sb_Modificar_Direccion_2(_CodEntidad_Dir, _CodSucEntidad_Dir)
        End If

    End Sub

    Private Sub Chk_Transpor_Por_Pagar_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Transpor_Por_Pagar.CheckedChanged

        If Cmb_Tipo_Envio.SelectedValue = "AG" Or Cmb_Tipo_Envio.SelectedValue = "DD" Then
            If _Cl_Despacho.Row_Conf_Despacho.Item("Transpor_Por_Pagar") Then
                If Not Chk_Transpor_Por_Pagar.Checked Then
                    If Not Fx_Tiene_Permiso(Me, "ODp00016") Then
                        Chk_Transpor_Por_Pagar.Checked = True
                    End If
                End If
            End If
        End If

    End Sub

    Sub Sb_Limpiar()

        SuperTabControl1.Enabled = False

        _Row_Direccion_Despacho = Nothing
        Txt_Datos_Entidad_Direccion.Text = String.Empty
        Txt_Tipo_Venta.Tag = String.Empty
        Txt_Tipo_Venta.Text = String.Empty

        Txt_Transportista.Tag = String.Empty
        Txt_Transportista.Text = String.Empty

        Chk_Transpor_Por_Pagar.Checked = _Cl_Despacho.Row_Conf_Despacho.Item("Transpor_Por_Pagar")
        Chk_Transpor_Por_Pagar.Enabled = False

        Txt_Referencia.Text = String.Empty
        Txt_Observaciones.Text = String.Empty

        _Cl_Despacho.Row_Despacho.Item("CodPais") = String.Empty
        _Cl_Despacho.Row_Despacho.Item("CodCiudad") = String.Empty
        _Cl_Despacho.Row_Despacho.Item("CodComuna") = String.Empty
        _Cl_Despacho.Row_Despacho.Item("Pais") = String.Empty
        _Cl_Despacho.Row_Despacho.Item("Ciudad") = String.Empty
        _Cl_Despacho.Row_Despacho.Item("Comuna") = String.Empty

        _Cl_Despacho.Row_Despacho.Item("Telefono") = String.Empty
        _Cl_Despacho.Row_Despacho.Item("Email") = String.Empty
        _Cl_Despacho.Row_Despacho.Item("Direccion") = String.Empty

    End Sub

    Private Sub Warning_Cantidad_OptionsClick(sender As Object, e As EventArgs) Handles Warning_Cantidad.OptionsClick

        MessageBoxEx.Show(Me, "Los kilos en el documento son menores a la cantidad mínima de kilos para poder hacer despacho a domicilio" & vbCrLf & vbCrLf &
                          "Kilos documento: " & FormatNumber(Total_Venta_Kilos, 1) & vbCrLf &
                          "Kilos mínimo para despachar: " & FormatNumber(_Kilos_Minimo, 1) & vbCrLf & vbCrLf &
                          "Para poder grabar el despacho a domicilio se necesitara un permiso", "Validación",
                          MessageBoxButtons.OK, MessageBoxIcon.Stop)

    End Sub

    Private Sub Warning_Valor_OptionsClick(sender As Object, e As EventArgs) Handles Warning_Valor.OptionsClick

        MessageBoxEx.Show(Me, "El monto total neto del documento es menor al valor total neto mínimo de compra para despachar" & vbCrLf & vbCrLf &
                          "Valor neto documento: " & FormatCurrency(_Total_Venta_Neto, 0) & vbCrLf &
                          "Valor mínimo para despachar: " & FormatCurrency(_Netos_Minimo, 0) & vbCrLf & vbCrLf &
                          "Para poder grabar el despacho a domicilio se necesitara un permiso", "Validación",
                          MessageBoxButtons.OK, MessageBoxIcon.Stop)

    End Sub

    Private Sub Btn_Chilexpress_Click(sender As Object, e As EventArgs) Handles Btn_Chilexpress.Click

        Dim _Kopr = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Chilexpress_Conf", "CodigoRd", "Activo = 1")
        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEPR", "KOPR = '" & _Kopr & "'"))

        If Not _Reg Then
            MessageBoxEx.Show(Me, "Esta configurado el sistema de Chilexpress, sin embargo no existe el producto: " & _Kopr & vbCrLf &
                              "Avise de esta situación al administrador para que configure bien el producto de salida", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
            Return
        End If

        Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Chilexpress_Conf Where Activo = 1"
        Dim _Row_Conf As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        'Aca se debe validar que los datos de configuración de chilexpress esten bien ingresados....

        Dim _Key_Cotizador As String = _Row_Conf.Item("Key_Cotizador")
        Dim _Key_Cobertura As String = _Row_Conf.Item("Key_Cobertura")
        Dim _Key_Envios As String = _Row_Conf.Item("Key_Envios")
        Dim _TCC As Integer = _Row_Conf.Item("TCC")
        Dim _Rut_Seller As String = _Row_Conf.Item("Rut_Seller")
        Dim _Rut_Mark As String = _Row_Conf.Item("Rut_Mark")

        Dim _Cond_Peso As String = _Row_Conf.Item("Cond_Peso")
        Dim _Cond_Alto As String = _Row_Conf.Item("Cond_Alto")
        Dim _Cond_Largo As String = _Row_Conf.Item("Cond_Largo")
        Dim _Cond_Ancho As String = _Row_Conf.Item("Cond_Ancho")

        Dim _RowEncabezadoDoc As DataRow = _Ds_Matriz_Documentos.Tables("Encabezado_Doc").Rows(0)
        Dim _TotalBrutoDoc As Double = _RowEncabezadoDoc.Item("TotalBrutoDoc")

        Dim _Peso As Double = 0
        Dim _Alto As Double = 0
        Dim _Largo As Double = 0
        Dim _Ancho As Double = 0
        Dim _PesoPr As Double
        Dim _AltoPr As Double
        Dim _LargoPr As Double
        Dim _AnchoPr As Double
        Dim _Falta_Dimension As Integer
        Dim _Txt_Log As New TextBox
        Dim _Txt_LogDetalle As New TextBox

        Dim _TblDetalle As DataTable = Ds_Matriz_Documentos.Tables("Detalle_Doc")

        Dim _FiltroProd As String = Generar_Filtro_IN(_TblDetalle, "", "Codigo", False, False, "'")

        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Dimensiones (Codigo,Peso,Alto,Largo,Ancho)" & vbCrLf &
                       "Select KOPR,0,0,0,0 From MAEPR Where KOPR In " & _FiltroProd & vbCrLf &
                       "And KOPR Not In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Dimensiones) And TIPR = 'FPN'"
        _Sql.Ej_consulta_IDU(Consulta_Sql)

        For Each _Fl As DataRow In _TblDetalle.Rows

            Dim _Codigo As String = _Fl.Item("Codigo")
            Dim _Cantidad As Double = _Fl.Item("Cantidad")
            Dim _Descripcion As String = _Fl.Item("Descripcion")
            Dim _Prct As Boolean = _Fl.Item("Prct")
            Dim _Problema = "Ok."

            If Not _Prct Then

                Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Prod_Dimensiones Where Codigo = '" & _Codigo & "'"
                Dim _Row_Dimensiones As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                If IsNothing(_Row_Dimensiones) Then

                    Consulta_Sql = "Insert Into "

                    _PesoPr = 0 : _AltoPr = 0 : _LargoPr = 0 : _AnchoPr = 0
                Else

                    Sb_Valor_Dimensiones(_Cond_Peso, _Row_Dimensiones.Item("Peso"), _PesoPr, _Peso, _Cantidad)
                    Sb_Valor_Dimensiones(_Cond_Alto, _Row_Dimensiones.Item("Alto"), _AltoPr, _Alto, _Cantidad)
                    Sb_Valor_Dimensiones(_Cond_Largo, _Row_Dimensiones.Item("Largo"), _LargoPr, _Largo, _Cantidad)
                    Sb_Valor_Dimensiones(_Cond_Ancho, _Row_Dimensiones.Item("Ancho"), _AnchoPr, _Ancho, _Cantidad)

                End If

                If _PesoPr = 0 Or _AltoPr = 0 Or _LargoPr = 0 Or _AnchoPr = 0 Then
                    _Falta_Dimension += 1
                    _Problema = vbCrLf & ":( Faltan dimensiones ***" & vbCrLf
                End If

                Sb_AddToLog(_Codigo,
                                  ", Peso: " & De_Num_a_Tx_01(_Row_Dimensiones.Item("Peso"), False, 2) &
                                  ", Alto: " & De_Num_a_Tx_01(_Row_Dimensiones.Item("Alto"), False, 2) &
                                  ", Largo: " & De_Num_a_Tx_01(_Row_Dimensiones.Item("Largo"), False, 2) &
                                  ", Ancho: " & De_Num_a_Tx_01(_Row_Dimensiones.Item("Ancho"), False, 2) & "." & _Problema, _Txt_Log, False)

                _PesoPr = _Row_Dimensiones.Item("Peso") * _Cantidad
                _AltoPr = _Row_Dimensiones.Item("Alto") * _Cantidad
                _LargoPr = _Row_Dimensiones.Item("Largo") * _Cantidad
                _AnchoPr = _Row_Dimensiones.Item("Ancho") * _Cantidad

                Sb_AddToLog(_Codigo, _Descripcion & vbCrLf &
                                  "Cantidad: " & De_Num_a_Tx_01(_Cantidad, False, 2) &
                                  ", Peso: " & De_Num_a_Tx_01(_Row_Dimensiones.Item("Peso"), False, 2) &
                                  ", Alto: " & De_Num_a_Tx_01(_Row_Dimensiones.Item("Alto"), False, 2) &
                                  ", Largo: " & De_Num_a_Tx_01(_Row_Dimensiones.Item("Largo"), False, 2) &
                                  ", Ancho: " & De_Num_a_Tx_01(_Row_Dimensiones.Item("Ancho"), False, 2) & vbCrLf &
                                 "Totales T.Peso: " & De_Num_a_Tx_01(_PesoPr, False, 2) &
                                  ", T.Alto: " & De_Num_a_Tx_01(_AltoPr, False, 2) &
                                  ", T.Largo: " & De_Num_a_Tx_01(_LargoPr, False, 2) &
                                  ", T.Ancho: " & De_Num_a_Tx_01(_AnchoPr, False, 2) & vbCrLf &
                                  StrDup(50, "-") & vbCrLf, _Txt_LogDetalle, False, False)

                _PesoPr = 0 : _AltoPr = 0 : _LargoPr = 0 : _AnchoPr = 0

            End If

        Next

        If CBool(_Falta_Dimension) Then

            MessageBoxEx.Show(Me, "Hay productos que no tienen los valores en la dimensiones: Peso, Largo, Alto o Ancho" & vbCrLf &
                              "No se puede enviar productos por CHILEXPRESS sin estas condiciones", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Dim Fmx As New Frm_Archivo_TXT
            Fmx.Pro_Nombre_Archivo = "ProdSinDimensiones.txt"
            Fmx.Pro_Texto_Log = _Txt_Log.Text
            Fmx.ShowDialog(Me)
            Fmx.Dispose()

            Me.Close()
            Return

        End If

        If _Alto < 20 Then _Alto = 20
        If _Largo < 10 Then _Largo = 10
        If _Ancho < 10 Then _Ancho = 10

        Dim Fm As New Frm_Chilexpress_Envio(_Key_Cotizador,
                                            _Key_Cobertura,
                                            _Key_Envios,
                                            _TCC,
                                            _Rut_Seller,
                                            _Rut_Mark)
        Fm.Referencia = "En construcción..."
        Fm.Peso = _Peso
        Fm.Alto = _Alto
        Fm.Largo = _Largo
        Fm.Ancho = _Ancho
        Fm.Nombre_Destino = _Cl_Despacho.Row_Despacho.Item("Nombre_Contacto")
        Fm.Telefono_Destino = _Cl_Despacho.Row_Despacho.Item("Telefono")
        Fm.Correo_Destino = _Cl_Despacho.Row_Despacho.Item("Email")
        Fm.Valor_Declarado = _TotalBrutoDoc
        Fm.Detalle_Productos = _Txt_LogDetalle.Text
        Fm.ShowDialog(Me)
        _Idenvio_Chilexpress = Fm.Idenvio
        Fm.Dispose()

        If CBool(_Idenvio_Chilexpress) Then

            Call Btn_Grabar_Click(Nothing, Nothing)

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Chilexpress_Env Set IdDespacho = " & Cl_Despacho.Id_Despacho & " Where Idenvio = " & _Idenvio_Chilexpress
            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                Me.Close()
            End If
        Else
            MessageBoxEx.Show(Me, "Debe completar todos los datos para el registro de Chilexpress", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            'Me.Close()
        End If

    End Sub

    Sub Sb_Valor_Dimensiones(_Condicion As String, _Valor_Dimension As Double, ByRef _ValorPr As Double, ByRef _Valor As Double, _Cantidad As Double)

        If String.IsNullOrEmpty(_Condicion.Trim) Then _Condicion = "SUMA"

        Select Case _Condicion
            Case "SUMA"
                _ValorPr = Math.Round(_Valor_Dimension * _Cantidad, 2)
                _Valor += _ValorPr
            Case "MAXIMOVALOR"
                _ValorPr = _Valor_Dimension
                If _ValorPr > _Valor Then _Valor = _ValorPr
        End Select

    End Sub

    Private Sub Btn_Direccion_Agencia_Click(sender As Object, e As EventArgs) Handles Btn_Direccion_Agencia.Click

        Dim _CodEntidad = _Cl_Despacho.Row_Entidad.Item("KOEN")
        Dim _CodSucEntidad = _Cl_Despacho.Row_Entidad.Item("SUEN")

        Dim Fm As New Frm_Agencia_Entidad(_CodEntidad, _CodSucEntidad)
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Agencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If Fm.Chk_AG_AgenciaxDefDespachos.Checked Then
                Cmb_Tipo_Envio.SelectedValue = "AG"
                Call Sb_Cmb_Tipo_Envio_SelectedIndexChanged(Nothing, Nothing)
            End If
        End If
        Fm.Dispose()

    End Sub

    Private Sub Btn_EditarEntregaPaletizada_Click(sender As Object, e As EventArgs) Handles Btn_EditarEntregaPaletizada.Click
        Chk_EntregaPaletizada.Enabled = Fx_Tiene_Permiso(Me, "ODp00019")
        Btn_EditarEntregaPaletizada.Enabled = Not Chk_EntregaPaletizada.Enabled
        Sb_Cargar_Datos_Envio()
    End Sub

    Private Sub Cmb_Sucursal_Retiro_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim _Row_Despacho As DataRow = _Cl_Despacho.Tbl_Despacho.Rows(0)

        Consulta_Sql = "Select Top 1 Suc.*,Ci.NOKOCI As CIUDAD,Cm.NOKOCM As COMUNA FROM TABSU Suc
                                    Left Join TABCI Ci On Suc.CISU = Ci.KOCI
                                    Left Join TABCM Cm On Suc.CISU = Cm.KOCI And Suc.CMSU = Cm.KOCM
                                    Where EMPRESA+KOSU = '" & Cmb_Sucursal_Retiro.SelectedValue & "'"

        Dim _Row_Sucursal As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Dim _CodPais = String.Empty
        Dim _CodCiudad = String.Empty
        Dim _CodComuna = String.Empty
        Dim _Pais = String.Empty
        Dim _Ciudad = String.Empty
        Dim _Comuna = String.Empty

        If Not IsNothing(_Row_Sucursal) Then

            _CodPais = _Sql.Fx_Trae_Dato("TABPA", "KOPA", "NOKOPA = '" & _Global_Row_Configp.Item("PAIS").ToString.Trim & "'",,, "CHI")
            _CodCiudad = _Row_Sucursal.Item("CISU").ToString.Trim
            _CodComuna = _Row_Sucursal.Item("CMSU").ToString.Trim
            _Pais = _Global_Row_Configp.Item("PAIS").ToString.Trim
            _Ciudad = _Row_Sucursal.Item("CIUDAD").ToString.Trim
            _Comuna = _Row_Sucursal.Item("COMUNA").ToString.Trim

        End If

        _Row_Despacho.Item("CodPais") = _CodPais
        _Row_Despacho.Item("CodCiudad") = _CodCiudad
        _Row_Despacho.Item("CodComuna") = _CodComuna
        _Row_Despacho.Item("Ciudad") = _Pais
        _Row_Despacho.Item("Comuna") = _Comuna
        _Row_Despacho.Item("Nombre_Contacto") = String.Empty
        _Row_Despacho.Item("Transportista") = String.Empty
        _Row_Despacho.Item("Direccion") = "RETIRA EN SUCURSAL: " & Cmb_Sucursal_Retiro.Text.Trim

        Sb_Cargar_Datos_Envio()

    End Sub

End Class
