Imports System.Data.SqlClient
Imports DevComponents.DotNetBar

Public Class Frm_Crear_Entidad_Mt

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _CreaNuevaEntidad As Boolean
    Dim _Crear_Entidad As Boolean
    Dim _Editar_Entidad As Boolean
    Dim _Grabar As Boolean
    Dim _Elimnar As Boolean
    Dim _Crear_Sucursal As Boolean
    'Dim Pais, Ciudad, Comuna, Zona As String
    Dim TipoSuc As String = "P"
    Dim _Sql_BlocDesb_VtayCmp As String
    Dim _Sql_BlocDesb_Compra As String
    Dim _BlocDesb_VtayCmp, _BlocDesb_Compra As Boolean
    Dim _RowEntidad As DataRow
    Dim _Tbl_Maeencta As DataTable
    Dim _Tbl_Maeenmail As DataTable
    Dim _Cmb_TipoPago As New DataGridViewComboBoxColumn
    Dim _Cmb_Banco As New DataGridViewComboBoxColumn

    Dim _Pais, _Ciudad, _Comuna As String
    Dim _Existe_Tbl_Entidades_Bakapp As Boolean

    Public Property Pro_CreaNuevaEntidad() As Boolean
        Get
            Return _CreaNuevaEntidad
        End Get
        Set(ByVal value As Boolean)
            _CreaNuevaEntidad = value
        End Set
    End Property
    Public Property Pro_Crear_Entidad() As Boolean
        Get
            Return _Crear_Entidad
        End Get
        Set(ByVal value As Boolean)
            _Crear_Entidad = value
        End Set
    End Property
    Public Property Pro_Editar_Entidad() As Boolean
        Get
            Return _Editar_Entidad
        End Get
        Set(ByVal value As Boolean)
            _Editar_Entidad = value
        End Set
    End Property
    Public Property Pro_Grabar() As Boolean
        Get
            Return _Grabar
        End Get
        Set(ByVal value As Boolean)
            _Grabar = value
        End Set
    End Property
    Public Property Pro_Elimnar() As Boolean
        Get
            Return _Elimnar
        End Get
        Set(ByVal value As Boolean)
            _Elimnar = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Cuentas, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Maeenmail, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        Sb_Llena_Combos_Con_Arreglos()

        _Existe_Tbl_Entidades_Bakapp = _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Entidades")

        caract_combo(CmbxZona)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KOZO AS Padre,NOKOZO AS Hijo FROM TABZO ORDER BY Padre" ' WHERE SEMILLA = " & Actividad
        CmbxZona.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        caract_combo(CmbxListaCosto)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KOLT AS Padre,'TABPP'+KOLT+' '+NOKOLT AS Hijo FROM TABPP WHERE TILT = 'C' ORDER BY Hijo "
        CmbxListaCosto.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        CmbxListaCosto.SelectedValue = ModListaPrecioCosto


        caract_combo(CmbxListaVenta)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KOLT AS Padre,'TABPP'+KOLT+' '+NOKOLT AS Hijo FROM TABPP WHERE TILT = 'P' ORDER BY Hijo "
        CmbxListaVenta.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        CmbxListaVenta.SelectedValue = ModListaPrecioVenta


        caract_combo(CmbxVendedor)
        Consulta_sql = "Select '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "Select TABFU.KOFU AS Padre,TABFU.KOFU+'-'+NOKOFU AS Hijo" & vbCrLf &
                       "From TABFU" & vbCrLf &
                       "Inner Join TABFUEM On TABFUEM.KOFU=TABFU.KOFU And TABFUEM.EMPRESA='" & ModEmpresa & "'" & vbCrLf &
                       "Order BY Hijo"
        CmbxVendedor.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        If Fx_Tiene_Permiso(Me, "CfEnt014", , False) Then
            CmbxVendedor.SelectedValue = FUNCIONARIO
        Else
            CmbxVendedor.SelectedValue = ""
        End If

        caract_combo(CmbxCobrador)
        Consulta_sql = "Select '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "Select TABFU.KOFU AS Padre,TABFU.KOFU+'-'+NOKOFU AS Hijo" & vbCrLf &
                       "From TABFU" & vbCrLf &
                       "Inner Join TABFUEM On TABFUEM.KOFU=TABFU.KOFU And TABFUEM.EMPRESA='" & ModEmpresa & "'" & vbCrLf &
                       "Order BY Hijo"
        CmbxCobrador.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        If Fx_Tiene_Permiso(Me, "CfEnt015", , False) Then
            CmbxCobrador.SelectedValue = FUNCIONARIO
        Else
            CmbxCobrador.SelectedValue = ""
        End If



        caract_combo(CmbxMoneda)
        Consulta_sql = "SELECT KOMO AS Padre,LTRIM(LTRIM(KOMO))+' '+NOKOMO AS Hijo FROM TABMO" ' WHERE SEMILLA = " & Actividad
        CmbxMoneda.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        DtpxFechaCreacion.Value = FechaDelServidor()

        caract_combo(Cmbx_Cat_ActEconomica)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KOCARAC AS Padre,NOKOCARAC AS Hijo FROM TABCARAC WHERE KOTABLA = 'ACTIVIDADE' ORDER BY Padre"
        Cmbx_Cat_ActEconomica.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmbx_Cat_Rubro)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KORU AS Padre,NOKORU AS Hijo FROM TABRU ORDER BY Padre"
        Cmbx_Cat_Rubro.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmbx_Cat_TamanoEmpresa)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KOCARAC AS Padre,NOKOCARAC AS Hijo FROM TABCARAC WHERE KOTABLA = 'TAMA¥OEMPR' ORDER BY Padre"
        Cmbx_Cat_TamanoEmpresa.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmbx_Cat_TipoEntidad)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KOCARAC AS Padre,NOKOCARAC AS Hijo FROM TABCARAC WHERE KOTABLA = 'TIPOENTIDA' ORDER BY Padre"
        Cmbx_Cat_TipoEntidad.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmbx_Cat_Transportista)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KOCARAC AS Padre,NOKOCARAC AS Hijo FROM TABCARAC WHERE KOTABLA = 'TRANSPORTE' ORDER BY Padre"
        Cmbx_Cat_Transportista.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        _CreaNuevaEntidad = False


        Dim _Creditos_Mod As DataTable

        Consulta_sql = "SELECT CRTO,CRSD,CRCH,CRLT,CRPA FROM CONFIEST WHERE MODALIDAD = '" & Modalidad & "'"
        _Creditos_Mod = _Sql.Fx_Get_Tablas(Consulta_sql)

        TxtxCtoTotal.Text = _Creditos_Mod.Rows(0).Item("CRTO")
        TxtxCtoSinDocumentar.Text = _Creditos_Mod.Rows(0).Item("CRSD")
        TxtxCtoEnCheques.Text = _Creditos_Mod.Rows(0).Item("CRCH")
        TxtxCtoEnLetra.Text = _Creditos_Mod.Rows(0).Item("CRLT")
        TxtxCtoEnPagare.Text = _Creditos_Mod.Rows(0).Item("CRPA")


        AddHandler TxtxCodEntidad.KeyPress, AddressOf PresionaEnter
        AddHandler TxtxSucursal.KeyPress, AddressOf PresionaEnter
        AddHandler TxtxRut.KeyPress, AddressOf PresionaEnter
        AddHandler TxtxRazonSocial.KeyPress, AddressOf PresionaEnter
        AddHandler TxtxSigla.KeyPress, AddressOf PresionaEnter
        AddHandler TxtxDireccion.KeyPress, AddressOf PresionaEnter
        AddHandler TxtxGiro.KeyPress, AddressOf PresionaEnter
        AddHandler TxtxTelefono.KeyPress, AddressOf PresionaEnter
        AddHandler TxtxFax.KeyPress, AddressOf PresionaEnter
        AddHandler TxtxEmail1.KeyPress, AddressOf PresionaEnter
        AddHandler TxtxEmail2.KeyPress, AddressOf PresionaEnter
        AddHandler TxtxCodPostal.KeyPress, AddressOf PresionaEnter

        AddHandler CmbxTipoEntidad.KeyPress, AddressOf PresionaEnter
        'AddHandler CmbxPais.KeyPress, AddressOf PresionaEnter
        'AddHandler CmbxCiudad.KeyPress, AddressOf PresionaEnter
        'AddHandler CmbxComuna.KeyPress, AddressOf PresionaEnter
        AddHandler CmbxZona.KeyPress, AddressOf PresionaEnter

        AddHandler TxtxCtoSinDocumentar.KeyPress, AddressOf PresionaEnter
        AddHandler TxtxCtoEnCheques.KeyPress, AddressOf PresionaEnter
        AddHandler TxtxCtoEnLetra.KeyPress, AddressOf PresionaEnter
        AddHandler TxtxCtoEnPagare.KeyPress, AddressOf PresionaEnter
        AddHandler TxtxCtoTotal.KeyPress, AddressOf PresionaEnter

        AddHandler TxtxNroMaxVenci.KeyPress, AddressOf PresionaEnter
        AddHandler TxtxDias1erVenci.KeyPress, AddressOf PresionaEnter
        AddHandler TxtxDiasEntreVenci.KeyPress, AddressOf PresionaEnter
        AddHandler TxtxMorosidadP.KeyPress, AddressOf PresionaEnter

        AddHandler TxtxCtoSinDocumentar.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros
        AddHandler TxtxCtoEnCheques.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros
        AddHandler TxtxCtoEnLetra.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros
        AddHandler TxtxCtoEnPagare.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros
        AddHandler TxtxCtoTotal.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros
        AddHandler TxtxNroMaxVenci.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros_Enteros
        AddHandler TxtxDias1erVenci.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros_Enteros
        AddHandler TxtxDiasEntreVenci.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros_Enteros
        AddHandler TxtxMorosidadP.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros_Enteros
        AddHandler TxtxPorcAnticipo.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros

        AddHandler TxtxCtoSinDocumentar.Validated, AddressOf Sb_Txt_Nros_Validated
        AddHandler TxtxCtoEnCheques.Validated, AddressOf Sb_Txt_Nros_Validated
        AddHandler TxtxCtoEnLetra.Validated, AddressOf Sb_Txt_Nros_Validated
        AddHandler TxtxCtoEnPagare.Validated, AddressOf Sb_Txt_Nros_Validated
        AddHandler TxtxCtoTotal.Validated, AddressOf Sb_Txt_Nros_Validated

        AddHandler TxtxNroMaxVenci.Validated, AddressOf Sb_Txt_Nros_Validated
        AddHandler TxtxDias1erVenci.Validated, AddressOf Sb_Txt_Nros_Validated
        AddHandler TxtxDiasEntreVenci.Validated, AddressOf Sb_Txt_Nros_Validated
        AddHandler TxtxMorosidadP.Validated, AddressOf Sb_Txt_Nros_Validated
        AddHandler TxtxPorcAnticipo.Validated, AddressOf Sb_Txt_Nros_Validated

        AddHandler TxtxCtoSinDocumentar.Enter, AddressOf Sb_Txt_Nros_Enter
        AddHandler TxtxCtoEnCheques.Enter, AddressOf Sb_Txt_Nros_Enter
        AddHandler TxtxCtoEnLetra.Enter, AddressOf Sb_Txt_Nros_Enter
        AddHandler TxtxCtoEnPagare.Enter, AddressOf Sb_Txt_Nros_Enter
        AddHandler TxtxCtoTotal.Enter, AddressOf Sb_Txt_Nros_Enter

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Crear_Entidad_Mt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Lbl_Libera_NVV.Visible = _Existe_Tbl_Entidades_Bakapp
        Sw_Libera_NVV.Visible = _Existe_Tbl_Entidades_Bakapp

        If _Crear_Entidad Then

            BtnContactosEntidad.Enabled = False
            BtnEliminarUser.Enabled = False
            Btn_ComentariosCtaCte.Enabled = False
            Btn_Anotaciones_a_la_entidad.Enabled = False
            Btn_Agregar_CtaCte.Enabled = False
            CmbxVendedor.Enabled = True
            BtnModVendedor.Enabled = False
            CmbxCobrador.Enabled = True
            BtnModCobrador.Enabled = False
            Btn_Direcciones_Despachos.Enabled = False

            If String.IsNullOrEmpty(Trim(TxtxCodEntidad.Text)) Then
                Me.ActiveControl = TxtxCodEntidad
            Else
                Me.Text += " CREAR SUCURSAL"
                Me.ActiveControl = TxtxDireccion
            End If

            Btn_Asociar_Marcas.Enabled = False

            Grilla_Cuentas.DataSource = Nothing

        ElseIf _Editar_Entidad Then

            DtpxFechaCreacion.Enabled = False
            TxtxCodEntidad.Enabled = False
            TxtxSucursal.Enabled = False
            BtnContactosEntidad.Enabled = True
            BtnEliminarUser.Enabled = True

            Me.ActiveControl = TxtxDireccion
            TxtxDireccion.Focus()

            _BlocDesb_VtayCmp = ChkxBloqueadaVyC.Checked
            _BlocDesb_Compra = ChkxBlocCompras.Checked

        End If

        AddHandler ChkxBloqueadaVyC.CheckValueChanged, AddressOf Sb_ChkxBloqueadaVyC
        AddHandler ChkxBlocCompras.CheckValueChanged, AddressOf Sb_ChkxBlocCompras

        Sb_Llenar_Grilla_Ctas_Ctes()

        If _Sql.Fx_Existe_Tabla("MAEENMAIL") Then
            Sb_Llenar_Grilla_Emial_Notificaciones()
            TabItem8.Visible = True
        Else
            TabItem8.Visible = False
        End If

        AddHandler Grilla_Cuentas.CellEndEdit, AddressOf Grilla_Cuentas_CellValueChanged
        AddHandler Grilla_Cuentas.MouseDown, AddressOf Sb_Grilla_Cuentas_MouseDown
        AddHandler Grilla_Maeenmail.MouseDown, AddressOf Sb_Grilla_Maennmail_MouseDown

        AddHandler Sw_Libera_NVV.ValueChanged, AddressOf Sw_Libera_NVV_ValueChanged

        Btn_Direcciones_Despachos.Visible = True

    End Sub

    Private Sub Sb_Llenar_Grilla_Ctas_Ctes()

        Consulta_sql = "Select KOEN,TIPOPAGO,EMISOR,CUENTA,RUT,NORUT,BLOQUEADA,Cast(Case When BLOQUEADA = 0 Then 1 Else 0 End As Bit) As Activo,SUCURSAL," &
               "TIPOPAGO +' - '+Isnull((Select top 1 NOKOENDP From TABENDP " &
               "Where KOENDP = EMISOR And EMPRESA = '" & ModEmpresa & "' And TIDPEN = SUBSTRING(TIPOPAGO,1,2)),'') As BANCO" & vbCrLf &
               "From MAEENCTA" & vbCrLf &
               "Where KOEN = '" & TxtxCodEntidad.Text & "'"

        _Tbl_Maeencta = _Sql.Fx_Get_Tablas(Consulta_sql)

        Grilla_Cuentas.DataSource = _Tbl_Maeencta

        Grilla_Cuentas.Columns.Add(_Cmb_Banco)

        With Grilla_Cuentas

            OcultarEncabezadoGrilla(Grilla_Cuentas)

            .Columns("BANCO").HeaderText = "Emisor (Descripción)"
            .Columns("BANCO").Width = 250
            .Columns("BANCO").Visible = True
            .Columns("BANCO").ReadOnly = True
            .Columns("BANCO").DisplayIndex = 1

            .Columns("SUCURSAL").HeaderText = "Suc."
            .Columns("SUCURSAL").Width = 30
            .Columns("SUCURSAL").Visible = True
            .Columns("SUCURSAL").ReadOnly = True
            .Columns("SUCURSAL").DisplayIndex = 2

            .Columns("CUENTA").HeaderText = "Cuenta"
            .Columns("CUENTA").Width = 100
            .Columns("CUENTA").Visible = True
            .Columns("CUENTA").DisplayIndex = 3

            .Columns("Activo").HeaderText = "?"
            .Columns("Activo").Width = 20
            .Columns("Activo").Visible = True
            .Columns("Activo").DisplayIndex = 4

            .Columns("RUT").HeaderText = "Rut"
            .Columns("RUT").Width = 80
            .Columns("RUT").Visible = True
            .Columns("RUT").DisplayIndex = 5

            .Columns("NORUT").HeaderText = "Nombre"
            .Columns("NORUT").Width = 150
            .Columns("NORUT").Visible = True
            .Columns("NORUT").DisplayIndex = 6

        End With

    End Sub

    Private Sub Sb_Llenar_Grilla_Emial_Notificaciones()

        Consulta_sql = "Select Cast(0 As Int) As ID,KOEN,KOMAIL,Cast(Case KOMAIL 
                                                        When '001' Then 'Envío de correo con PDF/XML de documentos tributarios electrónicos' 
                                                        When '004' Then 'Informe de facturas impagas con mas de N días a fecha de emisión'
                                                        When 'CAM' Then 'Campañas promocionales'
                                                        When 'ODS' Then 'Envío de notificaciones por ordenes de servicio'
                                                        Else ''
                                                End As Varchar(100)) As NAME_KOMAIL,MAILTO,NAMETO,MAILCC,NAMECC,MAILCC2,NAMECC2,MAILBCC,NAMEBCC,MAILINI,SUEN
                        From MAEENMAIL
                        Where KOEN = '" & TxtxCodEntidad.Text & "'"

        _Tbl_Maeenmail = _Sql.Fx_Get_Tablas(Consulta_sql)

        Grilla_Maeenmail.DataSource = _Tbl_Maeenmail

        With Grilla_Maeenmail

            OcultarEncabezadoGrilla(Grilla_Maeenmail)

            Dim _DisplayIndex = 0

            .Columns("SUEN").HeaderText = "Suc."
            .Columns("SUEN").Width = 60
            .Columns("SUEN").Visible = True
            .Columns("SUEN").ReadOnly = True
            .Columns("SUEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("KOMAIL").HeaderText = "Tipo"
            .Columns("KOMAIL").Width = 60
            .Columns("KOMAIL").Visible = True
            .Columns("KOMAIL").ReadOnly = True
            .Columns("KOMAIL").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("MAILTO").HeaderText = "Email"
            .Columns("MAILTO").Width = 200
            .Columns("MAILTO").Visible = True
            .Columns("MAILTO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NAMETO").HeaderText = "Nombre Dest."
            .Columns("NAMETO").Width = 100
            .Columns("NAMETO").Visible = True
            .Columns("NAMETO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("MAILCC").HeaderText = "Copia Email"
            .Columns("MAILCC").Width = 200
            .Columns("MAILCC").Visible = True
            .Columns("MAILCC").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1


        End With

        Dim _Id = 0

        For Each _Fila As DataGridViewRow In Grilla_Maeenmail.Rows

            _Fila.Cells("ID").Value = _Id
            _Id += 1

        Next

    End Sub


    Function Fx_Nueva_Linea_Cta(_Tbl As DataTable,
                                _Koen As String,
                                _Tipopago As String,
                                _Emisor As String,
                                _Cuenta As String,
                                _Rut As String,
                                _Norut As String,
                                _Bloqueada As Boolean,
                                _Sucursal As String,
                                _Banco As String) As DataRow
        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow
        With NewFila

            .Item("KOEN") = _Koen
            .Item("TIPOPAGO") = _Tipopago
            .Item("EMISOR") = _Emisor
            .Item("CUENTA") = _Cuenta
            .Item("RUT") = _Rut
            .Item("NORUT") = _Norut
            .Item("BLOQUEADA") = _Bloqueada
            .Item("Activo") = Not _Bloqueada
            .Item("SUCURSAL") = _Sucursal
            .Item("BANCO") = _Banco

            _Tbl.Rows.Add(NewFila)

        End With

        Return NewFila

    End Function

    Function Fx_Nueva_Linea_Notificacion(_Tbl As DataTable,
                                         _Koen As String,
                                         _Suen As String,
                                         _Komail As String,
                                         _Name_komail As String,
                                         _Mailto As String,
                                         _Nameto As String,
                                         _Mailcc As String,
                                         _Namecc As String,
                                         _Mailcc2 As String,
                                         _Namecc2 As String,
                                         _Mailbcc As String,
                                         _Namebcc As String,
                                         _Mailini As Date) As DataRow

        Dim _Id = 0

        If Grilla_Maeenmail.Rows.Count > 0 Then
            _Id = Grilla_Maeenmail.Rows(Grilla_Maeenmail.Rows.Count - 1).Cells("ID").Value + 1
        End If

        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow
        With NewFila

            .Item("ID") = _Id
            .Item("KOEN") = _Koen
            .Item("SUEN") = _Suen
            .Item("KOMAIL") = _Komail
            .Item("NAME_KOMAIL") = _Name_komail
            .Item("MAILTO") = _Mailto
            .Item("NAMETO") = _Nameto
            .Item("MAILCC") = _Mailcc
            .Item("NAMECC") = _Namecc
            .Item("MAILCC2") = _Mailcc2
            .Item("NAMECC2") = _Namecc2
            .Item("MAILBCC") = _Mailbcc
            .Item("NAMEBCC") = _Namebcc
            .Item("MAILINI") = _Mailini

            _Tbl.Rows.Add(NewFila)

        End With

        Return NewFila

    End Function

    Private Sub BtnxGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxGrabar.Click

        Dim _Koen As String = TxtxCodEntidad.Text
        Dim _Suen As String = TxtxSucursal.Text

        Me.Refresh()

        If _Crear_Entidad Then

            If String.IsNullOrEmpty(Trim(TxtxCodEntidad.Text)) Then

                MessageBoxEx.Show(Me, "Código de entidad vacio, debe completar datos", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TxtxCodEntidad.Focus()
                Return

            End If

            Dim _EncuetraEnt As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEEN", "KOEN = '" & TxtxCodEntidad.Text &
                                "' And SUEN = '" & TxtxSucursal.Text & "'"))
            If _EncuetraEnt Then

                MessageBoxEx.Show(Me, "¡Entidad ya existe!" & vbCrLf &
                              "No es posible grabar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TxtxCodEntidad.SelectAll()
                TxtxSucursal.SelectAll()
                TxtxCodEntidad.Focus()

                Exit Sub

            End If

            If String.IsNullOrEmpty(CmbxTipoEntidad.Text.Trim) Then
                MessageBoxEx.Show("Falta el tipo de entidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                CmbxTipoEntidad.Focus()
                Return
            End If

            If String.IsNullOrEmpty(TxtxRazonSocial.Text.Trim) Then
                MessageBoxEx.Show("Faltan la razón social", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TxtxRazonSocial.Focus()
                Return
            End If

            If String.IsNullOrEmpty(TxtxDireccion.Text.Trim) Then
                MessageBoxEx.Show("Faltan la dirección", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TxtxDireccion.Focus()
                Return
            End If

            If String.IsNullOrEmpty(TxtxGiro.Text.Trim) Then
                MessageBoxEx.Show("Faltan el giro", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TxtxGiro.Focus()
                Return
            End If

            If String.IsNullOrEmpty(TxtxTelefono.Text.Trim) Then
                MessageBoxEx.Show("Falta el teléfono de la entidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TxtxTelefono.Focus()
                Return
            End If

            If IsNothing(_Pais) Then _Pais = String.Empty
            If IsNothing(_Ciudad) Then _Ciudad = String.Empty
            If IsNothing(_Comuna) Then _Comuna = String.Empty

            If String.IsNullOrEmpty(_Pais.Trim) Or String.IsNullOrEmpty(_Ciudad) Or String.IsNullOrEmpty(_Comuna.Trim) Then
                MessageBoxEx.Show("Faltan pais, ciudad o comuna", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Call Btn_Buscar_Comuna_Click(Nothing, Nothing)
            End If

            If String.IsNullOrEmpty(_Pais.Trim) Or String.IsNullOrEmpty(_Ciudad) Or String.IsNullOrEmpty(_Comuna.Trim) Then Return

            If _Existe_Tbl_Entidades_Bakapp Then

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Entidades (CodEntidad,CodSucEntidad,Libera_NVV) Values ('" & _Koen & "','" & _Suen & "',0)" & vbCrLf &
              _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

        End If

        If _Existe_Tbl_Entidades_Bakapp Then

            Dim _CRTO As Double = TxtxCtoTotal.Text
            Dim _CRSD As Double = TxtxCtoSinDocumentar.Text
            Dim _CRCH As Double = TxtxCtoEnCheques.Text
            Dim _CRLT As Double = TxtxCtoEnLetra.Text
            Dim _CRPA As Double = TxtxCtoEnPagare.Text

            Dim _Suma As Double = _CRTO + _CRSD + _CRCH + _CRLT + _CRPA

            If Sw_Libera_NVV.Value And _Suma > 0 Then

                TabControl1.SelectedTabIndex = 3

                MessageBoxEx.Show(Me, "No puede dejar Libera NVV en [SI] cuando la entidad tiene créditos asociados" & vbCrLf &
                                      "Para poder dejar en [SI] debe dejar todos los créditos en cero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return

            End If

        End If

        TabControl1.Tabs(2).Visible = False

        TxtxRut.Text = Replace(TxtxRut.Text, ".", "")
        Dim Rut(1) As String

        Rut = Split(TxtxRut.Text, "-")

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        If _Crear_Sucursal Then

            'Dim _Sucursales As Integer
            Dim _Existe_Suc As Boolean

            _Existe_Suc = CBool(_Sql.Fx_Cuenta_Registros("MAEEN", "KOEN = '" & TxtxCodEntidad.Text & "'" & vbCrLf &
                                           "And SUEN = '" & TxtxSucursal.Text & "'"))

            If _Existe_Suc Then
                MessageBoxEx.Show(Me, "La sucursal con el código " & TxtxSucursal.Text & " ya existe para esta entidad", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            'Do
            '    _Sucursales += 1
            '    TxtxSucursal.Text = numero_(_Sucursales, 2)
            '    _Existe_Suc = CBool(_Sql.Fx_Cuenta_Registros("MAEEN", "KOEN = '" & TxtxCodEntidad.Text & "'" & vbCrLf &
            '                               "And SUEN = '" & TxtxSucursal.Text & "'"))
            'Loop While (_Existe_Suc)

        End If

        Dim cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(cn2)

        Try
            myTrans = cn2.BeginTransaction()

            If _Crear_Entidad Then

                Consulta_sql = BkSpecialPrograms.RecursosEnt.Insertar_Entidad_MAEEN.ToString
                Consulta_sql = Replace(Consulta_sql, "#KOEN#", TxtxCodEntidad.Text)
                Consulta_sql = Replace(Consulta_sql, "#TIEN#", CmbxTipoEntidad.SelectedValue)
                Consulta_sql = Replace(Consulta_sql, "#RTEN#", Trim(numero_(Rut(0), 8)))
                Consulta_sql = Replace(Consulta_sql, "#SUEN#", TxtxSucursal.Text)

                If _Sql.Fx_Cuenta_Registros("MAEEN", "KOEN = '" & TxtxCodEntidad.Text & "'") > 1 Then TipoSuc = "S"
                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            Dim Zona = CmbxZona.SelectedValue

            Consulta_sql = BkSpecialPrograms.RecursosEnt.Actualiza_Entidad_MAEEN

            Consulta_sql = Replace(Consulta_sql, "#KOEN#", TxtxCodEntidad.Text)
            Consulta_sql = Replace(Consulta_sql, "#TIEN#", UCase(Trim(CmbxTipoEntidad.SelectedValue)))
            Consulta_sql = Replace(Consulta_sql, "#RTEN#", UCase(Trim(numero_(Rut(0), 8))))
            Consulta_sql = Replace(Consulta_sql, "#SUEN#", TxtxSucursal.Text)
            Consulta_sql = Replace(Consulta_sql, "#TIPOSUC#", TipoSuc)
            Consulta_sql = Replace(Consulta_sql, "#NOKOEN#", UCase(Trim(TxtxRazonSocial.Text)))
            Consulta_sql = Replace(Consulta_sql, "#SIEN#", UCase(Trim(TxtxSigla.Text)))
            Consulta_sql = Replace(Consulta_sql, "#GIEN#", UCase(Trim(TxtxGiro.Text)))
            Consulta_sql = Replace(Consulta_sql, "#EMAIL#", TxtxEmail1.Text)
            Consulta_sql = Replace(Consulta_sql, "#EMAILCOMER#", TxtxEmail2.Text)
            Consulta_sql = Replace(Consulta_sql, "#PAEN#", _Pais)
            Consulta_sql = Replace(Consulta_sql, "#CIEN#", _Ciudad)
            Consulta_sql = Replace(Consulta_sql, "#CMEN#", _Comuna)
            Consulta_sql = Replace(Consulta_sql, "#DIEN#", UCase(Trim(TxtxDireccion.Text)))
            Consulta_sql = Replace(Consulta_sql, "#ZOEN#", Zona)
            Consulta_sql = Replace(Consulta_sql, "#FOEN#", UCase(Trim(TxtxTelefono.Text)))
            Consulta_sql = Replace(Consulta_sql, "#FAEN#", UCase(Trim(TxtxFax.Text)))
            Consulta_sql = Replace(Consulta_sql, "#FOEN#", UCase(Trim(TxtxTelefono.Text)))
            Consulta_sql = Replace(Consulta_sql, "#CPOSTAL#", TxtxCodPostal.Text)
            Consulta_sql = Replace(Consulta_sql, "#NOKOENAMP#", TxtxRazonSocialAmpliada.Text)
            Consulta_sql = Replace(Consulta_sql, "#KOFUEN#", CmbxVendedor.SelectedValue)
            Consulta_sql = Replace(Consulta_sql, "#COBRADOR#", CmbxCobrador.SelectedValue)
            Consulta_sql = Replace(Consulta_sql, "#LCEN#", "TABPP" & CmbxListaCosto.SelectedValue)
            Consulta_sql = Replace(Consulta_sql, "#LVEN#", "TABPP" & CmbxListaVenta.SelectedValue)
            Consulta_sql = Replace(Consulta_sql, "#RUEN#", Cmbx_Cat_Rubro.SelectedValue)
            Consulta_sql = Replace(Consulta_sql, "#TIPOEN#", Cmbx_Cat_TipoEntidad.SelectedValue)
            Consulta_sql = Replace(Consulta_sql, "#ACTIEN#", Cmbx_Cat_ActEconomica.SelectedValue)
            Consulta_sql = Replace(Consulta_sql, "#TAMAEN#", Cmbx_Cat_TamanoEmpresa.SelectedValue)
            Consulta_sql = Replace(Consulta_sql, "#TRANSPOEN#", Cmbx_Cat_Transportista.SelectedValue)
            Consulta_sql = Replace(Consulta_sql, "#OBEN#", UCase(Trim(TxtxObservacionesDoc.Text)))

            Consulta_sql = Replace(Consulta_sql, "#CRTO#", De_Num_a_Tx_01(TxtxCtoTotal.Tag, False, 5))
            Consulta_sql = Replace(Consulta_sql, "#CRSD#", De_Num_a_Tx_01(TxtxCtoSinDocumentar.Tag, False, 5))
            Consulta_sql = Replace(Consulta_sql, "#CRCH#", De_Num_a_Tx_01(TxtxCtoEnCheques.Tag, False, 5))
            Consulta_sql = Replace(Consulta_sql, "#CRLT#", De_Num_a_Tx_01(TxtxCtoEnLetra.Tag, False, 5))
            Consulta_sql = Replace(Consulta_sql, "#CRPA#", De_Num_a_Tx_01(TxtxCtoEnPagare.Tag, False, 5))

            Consulta_sql = Replace(Consulta_sql, "#NUVECR#", De_Num_a_Tx_01(TxtxNroMaxVenci.Tag, False, 5))
            Consulta_sql = Replace(Consulta_sql, "#DIPRVE#", De_Num_a_Tx_01(TxtxDias1erVenci.Tag, False, 5))
            Consulta_sql = Replace(Consulta_sql, "#DIASVENCI#", De_Num_a_Tx_01(TxtxDiasEntreVenci.Tag, False, 5))
            Consulta_sql = Replace(Consulta_sql, "#DIMOPER#", De_Num_a_Tx_01(TxtxMorosidadP.Tag, False, 5))

            Consulta_sql = Replace(Consulta_sql, "#FEULTR#", Format(Now.Date, "yyyyMMdd"))
            Consulta_sql = Replace(Consulta_sql, "#FECREEN#", Format(DtpxFechaCreacion.Value, "yyyyMMdd"))

            Dim _Fevecren As String

            If FormatDateTime(DtpxFechaVigencia.Value, DateFormat.ShortDate) = #01-01-0001# Or IsNothing(DtpxFechaVigencia.Value) Or IsDBNull(DtpxFechaVigencia.Value) Then
                _Fevecren = "Null"
            Else
                _Fevecren = "'" & Format(DtpxFechaVigencia.Value, "yyyyMMdd") & "'"
            End If

            Consulta_sql = Replace(Consulta_sql, "'#FEVECREN#'", _Fevecren)

            Consulta_sql = Replace(Consulta_sql, "#CPEN#", UCase(Trim(TxtxoObservacionesCondPago.Text)))

            Consulta_sql = Replace(Consulta_sql, "#NVVPIDEPIE#", Val(ChkxExigeNVV.Checked))
            Consulta_sql = Replace(Consulta_sql, "#POPICR#", De_Num_a_Tx_01(TxtxPorcAnticipo.Tag, False, 5))

            Consulta_sql = Replace(Consulta_sql, "#BLOQUEADO#", Val(ChkxBloqueadaVyC.Checked))
            Consulta_sql = Replace(Consulta_sql, "#BLOQENCOM#", Val(ChkxBlocCompras.Checked))

            Consulta_sql = Replace(Consulta_sql, "#PREFEN#", Val(ChkxEntPreferencial.Checked))
            Consulta_sql = Replace(Consulta_sql, "#NOTRAEDEUD#", Val(ChkxEntNoAfecCtaCte.Checked))

            Consulta_sql = Replace(Consulta_sql, "#OCCOBLI#", Val(Chk_Occobli.Checked))
            Consulta_sql = Replace(Consulta_sql, "#FEREFAUTO#", Val(Chk_Ferefauto.Checked))

            Consulta_sql = Replace(Consulta_sql, "#MOCTAEN#", CmbxMoneda.SelectedValue)

            Dim _Dia_Cobra As String = Fx_DiaCobra()
            Consulta_sql = Replace(Consulta_sql, "#DIACOBRA#", _Dia_Cobra)

            '--CUENTABCO =  Nro Cta Cte  (20)
            '--KOENDPEN  =  Código del banco (13)
            '--SUENDPEN  =  Plaza o sucursal bancaria (3)
            '--ACTECOBCO =  Código de actividad economica   (10)

            Consulta_sql = Replace(Consulta_sql, "#CUENTABCO#", Txt_Cta_NroCtaCte.Text)
            Consulta_sql = Replace(Consulta_sql, "#KOENDPEN#", Txt_Cta_Codigo_Banco.Text)
            Consulta_sql = Replace(Consulta_sql, "#SUENDPEN#", Txt_Cta_Plaza_Sucursal.Text)
            Consulta_sql = Replace(Consulta_sql, "#ACTECOBCO#", Txt_Cta_Codigo_Act_Economica.Text)

            Consulta_sql = Replace(Consulta_sql, "#RUTALUN#", Input_Rutalun.Value)
            Consulta_sql = Replace(Consulta_sql, "#RUTAMAR#", Input_Rutamar.Value)
            Consulta_sql = Replace(Consulta_sql, "#RUTAMIE#", Input_Rutamie.Value)
            Consulta_sql = Replace(Consulta_sql, "#RUTAJUE#", Input_Rutajue.Value)
            Consulta_sql = Replace(Consulta_sql, "#RUTAVIE#", Input_Rutavie.Value)
            Consulta_sql = Replace(Consulta_sql, "#RUTASAB#", Input_Rutasab.Value)
            Consulta_sql = Replace(Consulta_sql, "#RUTADOM#", Input_Rutadom.Value)

            Consulta_sql = Replace(Consulta_sql, "#RECEPELECT#", Val(ChkxEnsEsEmisorDocumento.Checked))

            Dim _Fecnacen As String

            If FormatDateTime(Dtp_Fecnacen.Value, DateFormat.ShortDate) = #01-01-0001# Or IsNothing(Dtp_Fecnacen.Value) Or IsDBNull(Dtp_Fecnacen.Value) Then
                _Fecnacen = "Null"
            Else
                _Fecnacen = "'" & Format(Dtp_Fecnacen.Value, "yyyyMMdd") & "'"
            End If

            Consulta_sql = Replace(Consulta_sql, "#NACIONEN#", Txt_Nacionen.Text)
            Consulta_sql = Replace(Consulta_sql, "#PROFECEN#", Txt_Profecen.Text)
            Consulta_sql = Replace(Consulta_sql, "#DIRPAREN#", Txt_Dirparen.Text)
            Consulta_sql = Replace(Consulta_sql, "'#FECNACEN#'", _Fecnacen)
            Consulta_sql = Replace(Consulta_sql, "#ESTCIVEN#", Cmb_Estciven.SelectedValue)
            Consulta_sql = Replace(Consulta_sql, "#SEXOEN#", Cmb_Sexoen.SelectedValue)
            Consulta_sql = Replace(Consulta_sql, "#RELACIEN#", Cmb_Relacien.SelectedValue)
            Consulta_sql = Replace(Consulta_sql, "#CONYUGEN#", Txt_Conyugen.Text)
            Consulta_sql = Replace(Consulta_sql, "#RUTCONEN#", Txt_Rutconen.Text)
            Consulta_sql = Replace(Consulta_sql, "#RUTSOCEN#", Rutsocen.Text)
            Consulta_sql = Replace(Consulta_sql, "#ANEXEN1#", Txt_Anexen1.Text)
            Consulta_sql = Replace(Consulta_sql, "#ANEXEN2#", Txt_Anexen2.Text)
            Consulta_sql = Replace(Consulta_sql, "#ANEXEN3#", Txt_Anexen3.Text)

            Dim _Reg As Boolean
            '
            _Reg = CBool(_Sql.Fx_Cuenta_Registros("INFORMATION_SCHEMA.COLUMNS",
                                          "COLUMN_NAME = 'CATLEGRET' AND TABLE_NAME = 'MAEEN'"))
            If _Reg Then Consulta_sql += "Update MAEEN Set CATLEGRET=@catlegret WHERE KOEN=@koen AND SUEN=@suen" & vbCrLf


            '
            _Reg = CBool(_Sql.Fx_Cuenta_Registros("INFORMATION_SCHEMA.COLUMNS",
                                          "COLUMN_NAME = 'IMPTORET' AND TABLE_NAME = 'MAEEN'"))
            If _Reg Then Consulta_sql += "Update MAEEN Set IMPTORET=@imptoret WHERE KOEN=@koen AND SUEN=@suen" & vbCrLf


            '
            _Reg = CBool(_Sql.Fx_Cuenta_Registros("INFORMATION_SCHEMA.COLUMNS",
                                          "COLUMN_NAME = 'ENTILIGA' AND TABLE_NAME = 'MAEEN'"))
            If _Reg Then Consulta_sql += "Update MAEEN Set ENTILIGA=@entiliga WHERE KOEN=@koen AND SUEN=@suen" & vbCrLf


            '
            _Reg = CBool(_Sql.Fx_Cuenta_Registros("INFORMATION_SCHEMA.COLUMNS",
                                          "COLUMN_NAME = 'PORCELIGA' AND TABLE_NAME = 'MAEEN'"))
            If _Reg Then Consulta_sql += "Update MAEEN Set PORCELIGA=@porceliga WHERE KOEN=@koen AND SUEN=@suen" & vbCrLf


            '
            _Reg = CBool(_Sql.Fx_Cuenta_Registros("INFORMATION_SCHEMA.COLUMNS",
                                          "COLUMN_NAME = 'ACTECOBCO' AND TABLE_NAME = 'MAEEN'"))
            If _Reg Then Consulta_sql += "Update MAEEN Set ACTECOBCO=@actecobco WHERE KOEN=@koen AND SUEN=@suen" & vbCrLf


            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            If _Crear_Entidad Then

                _CreaNuevaEntidad = True

            ElseIf _Editar_Entidad Then


                If ChkxBloqueadaVyC.Checked <> _BlocDesb_VtayCmp Then
                    Consulta_sql += vbCrLf & vbCrLf & _Sql_BlocDesb_VtayCmp
                End If

                If ChkxBlocCompras.Checked <> _BlocDesb_Compra Then
                    Consulta_sql += vbCrLf & vbCrLf & _Sql_BlocDesb_Compra
                End If

                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            Consulta_sql = "Delete MAEENCTA Where KOEN = '" & TxtxCodEntidad.Text & "'" & vbCrLf & vbCrLf

            For Each _Fila As DataRow In _Tbl_Maeencta.Rows

                If _Fila.RowState <> DataRowState.Deleted Then

                    'Dim _Koen = _Fila.Item("KOEN")
                    Dim _Tipopago = _Fila.Item("TIPOPAGO")
                    Dim _Emisor = _Fila.Item("EMISOR")
                    Dim _Cuenta = _Fila.Item("CUENTA")
                    Dim _Rut = _Fila.Item("RUT")
                    Dim _Norut = _Fila.Item("NORUT")
                    Dim _Bloqueada = CInt(_Fila.Item("BLOQUEADA")) * -1
                    Dim _Sucursal = _Fila.Item("SUCURSAL")

                    If Not String.IsNullOrEmpty(_Koen) Then

                        Consulta_sql += "Insert Into MAEENCTA (KOEN,TIPOPAGO,EMISOR,CUENTA,RUT,NORUT,BLOQUEADA,SUCURSAL) Values " & vbCrLf &
                                        "('" & _Koen & "','" & _Tipopago & "','" & _Emisor & "','" & _Cuenta &
                                        "','" & _Rut & "','" & _Norut & "'," & _Bloqueada & ",'" & _Sucursal & "')" & vbCrLf
                    End If

                End If

            Next

            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            If _Sql.Fx_Existe_Tabla("MAEENMAIL") Then

                Consulta_sql = "Delete MAEENMAIL Where KOEN = '" & TxtxCodEntidad.Text & "'" & vbCrLf & vbCrLf

                For Each _Fila As DataRow In _Tbl_Maeenmail.Rows

                    'Dim _Koen As String = _Fila.Item("KOEN")
                    'Dim _Suen As String = _Fila.Item("SUEN")

                    Dim _Komail As String = _Fila.Item("KOMAIL")
                    Dim _Name_komail As String = _Fila.Item("NAME_KOMAIL")

                    Dim _Mailto As String = _Fila.Item("MAILTO")
                    Dim _Nameto As String = _Fila.Item("NAMETO")
                    Dim _Mailcc As String = _Fila.Item("MAILCC")
                    Dim _Namecc As String = _Fila.Item("NAMECC")
                    Dim _Mailcc2 As String = _Fila.Item("MAILCC2")
                    Dim _Namecc2 As String = _Fila.Item("NAMECC2")
                    Dim _Mailbcc As String = _Fila.Item("MAILBCC")
                    Dim _Namebcc As String = _Fila.Item("NAMEBCC")
                    Dim _Mailini As Date = _Fila.Item("MAILINI")

                    Consulta_sql += "Insert Into MAEENMAIL (KOEN,KOMAIL,MAILTO,NAMETO,MAILCC,NAMECC,MAILCC2,NAMECC2,MAILBCC,NAMEBCC,MAILINI,SUEN) Values " &
                                    "('" & _Koen & "','" & _Komail & "','" & _Mailto & "','" & _Nameto & "','" & _Mailcc & "','" & _Namecc & "'" &
                                    ",'" & _Mailcc2 & "','" & _Namecc2 & "','" & _Mailbcc & "','" & _Namebcc & "'" &
                                    ",'" & Format(_Mailini, "yyyyMMdd") & "','" & _Suen & "')" & vbCrLf

                Next

                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            If _Existe_Tbl_Entidades_Bakapp Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Entidades Set Libera_NVV = " & Convert.ToInt32(Sw_Libera_NVV.Value) & vbCrLf &
                               "Where CodEntidad = '" & _Koen & "' And CodSucEntidad = '" & _Suen & "'"

                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)


            _Grabar = True
            Me.Close()

        Catch ex As Exception
            myTrans.Rollback()
            MessageBoxEx.Show(ex.Message, "Transaccion desecha", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)
            _Grabar = False
        End Try

    End Sub

    Function Fx_DiaCobra() As String

        Dim _DiasCobranza As String

        If Chk_Lunes.Checked Then
            _DiasCobranza += "X"
        Else
            _DiasCobranza += " "
        End If

        If Chk_Martes.Checked Then
            _DiasCobranza += "X"
        Else
            _DiasCobranza += " "
        End If

        If Chk_Miercoles.Checked Then
            _DiasCobranza += "X"
        Else
            _DiasCobranza += " "
        End If

        If Chk_Jueves.Checked Then
            _DiasCobranza += "X"
        Else
            _DiasCobranza += " "
        End If

        If Chk_Viernes.Checked Then
            _DiasCobranza += "X"
        Else
            _DiasCobranza += " "
        End If

        If Chk_Sabado.Checked Then
            _DiasCobranza += "X"
        Else
            _DiasCobranza += " "
        End If

        If Chk_Domingo.Checked Then
            _DiasCobranza += "X"
        Else
            _DiasCobranza += " "
        End If

        Return _DiasCobranza

    End Function

    Sub Sb_Llena_Combos_Con_Arreglos()

        Dim _Arr_Tipo_Entidad(,) As String = {{"", ""},
                                             {"C", "Cliente"},
                                             {"P", "Proveedor"},
                                             {"A", "ambos"}}
        Sb_Llenar_Combos(_Arr_Tipo_Entidad, CmbxTipoEntidad)
        CmbxTipoEntidad.SelectedValue = "A"


        Dim _Arr_Estado_Civil(,) As String = {{"", ""},
                                     {"S", "Soltero"},
                                     {"C", "Casado"},
                                     {"V", "Viudo"},
                                     {"D", "Divorsiado"},
                                     {"O", "Otro"}}
        Sb_Llenar_Combos(_Arr_Estado_Civil, Cmb_Estciven)
        Cmb_Estciven.SelectedValue = ""

        Dim _Arr_Sexo(,) As String = {{"", ""},
                                     {"M", "Masculino"},
                                     {"F", "Femenino"}}
        Sb_Llenar_Combos(_Arr_Sexo, Cmb_Sexoen)
        Cmb_Sexoen.SelectedValue = ""

        Dim _Arr_Relacionado(,) As String = {{"", ""},
                                     {"S", "Si"},
                                     {"N", "No"}}
        Sb_Llenar_Combos(_Arr_Relacionado, Cmb_Relacien)
        Cmb_Relacien.SelectedValue = ""

    End Sub

    Sub Sb_Llena_Combo_Tipo_Pago(ByVal _Cmb As DataGridViewComboBoxColumn)

        _Cmb.ValueMember = "Padre"
        _Cmb.DisplayMember = "Hijo"

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Padre", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Hijo", System.Type.[GetType]("System.String"))
        ',,,,,,

        dr = dt.NewRow() : dr("Padre") = "" : dr("Hijo") = "" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "CH" : dr("Hijo") = "CHV" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "TJ" : dr("Hijo") = "TJV" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "LT" : dr("Hijo") = "LTV" : dt.Rows.Add(dr)
        'cerramos el datareader y la conexión
        'añadimos la tabla al dataset
        rs.Tables.Add(dt)

        With _Cmb
            .DataSource = Nothing
            .DataSource = dt
        End With

    End Sub

    'Private Sub CmbxPais_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try

    '        Pais = CmbxPais.SelectedValue

    '        Ciudad = ""
    '        Comuna = ""

    '        CmbxCiudad.DataSource = Nothing
    '        CmbxComuna.DataSource = Nothing

    '        caract_combo(CmbxCiudad)
    '        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
    '                       "SELECT KOCI AS Padre,' '+RTRIM(LTRIM(KOCI))+' -'+NOKOCI AS Hijo FROM TABCI WHERE KOPA = '" & Pais & "'"
    '        CmbxCiudad.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

    '        CmbxCiudad.SelectedValue = Ciudad
    '        'CmbxComuna.Text = Comuna
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub CmbxCiudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Ciudad = CmbxCiudad.SelectedValue.ToString
    '    Catch ex As Exception

    '    Finally

    '        Comuna = ""
    '        CmbxComuna.DataSource = Nothing

    '        caract_combo(CmbxComuna)
    '        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
    '                       "SELECT KOCM AS Padre, NOKOCM AS Hijo FROM TABCM WHERE KOPA = '" & Pais & "' AND KOCI = '" & Ciudad & "'"
    '        CmbxComuna.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
    '        CmbxComuna.SelectedValue = Comuna

    '    End Try
    'End Sub

    Private Sub TxtxRazonSocial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtxRazonSocial.TextChanged
        TxtxRazonSocialAmpliada.Text = TxtxRazonSocial.Text
    End Sub

    Private Sub TxtxRut_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtxRut.Validating

        Dim _Rut As String

        If _Editar_Entidad Then

            _Rut = _RowEntidad.Item("RTEN").ToString.Trim & "-" & RutDigito(_RowEntidad.Item("RTEN").ToString.Trim)

            If _Rut = TxtxRut.Text Then
                Return
            End If

        End If

        If String.IsNullOrEmpty(Trim(TxtxRut.Text)) Then
            MessageBoxEx.Show(Me, "El Rut no puede estar vacio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            BtnxGrabar.Enabled = False
            Return
        End If

        TxtxRut.Text = Replace(TxtxRut.Text, ".", "")
        Dim Rut(1) As String
        Rut = Split(TxtxRut.Text, "-")
        Dim Rt = numero_(Rut(0), 8)

        If Not VerificaDigito(TxtxRut.Text) Then
            MessageBoxEx.Show(Me, "Rut invalido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TxtxRut.SelectAll()
            TxtxRut.Focus()
            e.Cancel = True
            BtnxGrabar.Enabled = False
            Return
        Else
            TxtxRut.Text = Rt & "-" & Rut(1)
            BtnxGrabar.Enabled = True
        End If

        If Rt = Trim(TxtxCodEntidad.Text) Then
            BtnxGrabar.Enabled = True
        Else
            Dim Nro As String = "CfEnt005"
            If Not Fx_Tiene_Permiso(Me, Nro) Then
                MessageBoxEx.Show(Me, "El código de la entidad es distinto al Rut" & vbCrLf &
                                  "Recuerde que los Rut de menos de 10.000.000 debe anteponer un 0 para rellenar",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                If _Editar_Entidad Then
                    TxtxRut.Text = _Rut
                Else
                    TxtxRut.Text = String.Empty
                    BtnxGrabar.Enabled = False
                    TxtxRut.Focus()
                End If

            End If

        End If

    End Sub

    Private Sub TxtxSucursal_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtxSucursal.Validating


        Dim EncuetraEnt As Integer = _Sql.Fx_Cuenta_Registros("MAEEN", "KOEN = '" & TxtxCodEntidad.Text & "' And SUEN = '" & TxtxSucursal.Text & "'")

        If EncuetraEnt > 0 Then

            MessageBoxEx.Show(Me, "Entidad/Sucursal ya existe." & vbCrLf &
                              "Digite otro código de sucursal", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            TxtxSucursal.SelectAll()

            Return

        End If

        'Dim Tbl As DataTable

        'Consulta_sql = "Select RTEN,NOKOEN,TIEN,GIEN From MAEEN Where KOEN = '" & TxtxCodEntidad.Text & "'"
        'Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)

        'Dim Filas As Integer = Tbl.Rows.Count

        'If Filas > 0 Then

        '    Dim dlg As System.Windows.Forms.DialogResult =
        '                                 MessageBoxEx.Show(Me,
        '                                 "Entidad ya existe" & vbCrLf &
        '                                 "¿Desea crear una nueva sucursal para la entidad?",
        '                                 "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        '    If dlg = System.Windows.Forms.DialogResult.Yes Then

        '        Dim Rut As String = Tbl.Rows(0).Item("RTEN").ToString
        '        TxtxRut.Text = Trim(Rut) & "-" & RutDigito(Rut)
        '        TxtxRazonSocial.Text = Trim(Tbl.Rows(0).Item("NOKOEN").ToString)
        '        TxtxRazonSocialAmpliada.Text = Trim(Tbl.Rows(0).Item("NOKOEN").ToString)
        '        CmbxTipoEntidad.SelectedValue = Trim(Tbl.Rows(0).Item("TIEN").ToString)
        '        TxtxGiro.Text = Trim(Tbl.Rows(0).Item("GIEN").ToString)
        '        TxtxRazonSocial.Focus()
        '        TipoSuc = "S"

        '    Else

        '        e.Cancel = True
        '        TxtxSucursal.SelectAll()

        '    End If

        'Else

        '    TipoSuc = "P"

        'End If

    End Sub

    Private Sub TxtxRazonSocial_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtxRazonSocial.Validating
        If String.IsNullOrEmpty(Trim(TxtxRazonSocial.Text)) Then
            MessageBoxEx.Show("La razón social no puede estar vacía", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If
    End Sub

    Private Sub TxtxDireccion_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtxDireccion.Validating
        If String.IsNullOrEmpty(Trim(TxtxDireccion.Text)) Then
            MessageBoxEx.Show("La dirección no puede estar vacía", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If
    End Sub

    Private Sub TxtxGiro_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtxGiro.Validating
        If String.IsNullOrEmpty(Trim(TxtxGiro.Text)) Then
            MessageBoxEx.Show("El Giro no puede estar vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        If Len(Trim(TxtxGiro.Text)) < 10 Then
            MessageBoxEx.Show("El Giro es sospechoso", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If

    End Sub

    Private Sub BtnModVendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModVendedor.Click
        CmbxVendedor.Enabled = Fx_Tiene_Permiso(Me, "CfEnt006")
        BtnModVendedor.Enabled = Not CmbxVendedor.Enabled
    End Sub

    Private Sub BtnModListas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModListas.Click
        CmbxListaCosto.Enabled = Fx_Tiene_Permiso(Me, "CfEnt008")
        CmbxListaVenta.Enabled = CmbxListaCosto.Enabled
        BtnModListas.Enabled = Not CmbxListaCosto.Enabled
    End Sub

    Private Sub BtnModCobrador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModCobrador.Click
        CmbxCobrador.Enabled = Fx_Tiene_Permiso(Me, "CfEnt007")
        BtnModCobrador.Enabled = Not CmbxCobrador.Enabled
    End Sub

    Private Sub BtnModCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModCredito.Click

        Dim _Enable As Boolean = Fx_Tiene_Permiso(Me, "CfEnt009")

        TxtxCtoEnCheques.Enabled = _Enable
        TxtxCtoEnLetra.Enabled = _Enable
        TxtxCtoEnPagare.Enabled = _Enable
        TxtxCtoSinDocumentar.Enabled = _Enable
        TxtxCtoTotal.Enabled = _Enable

        TxtxNroMaxVenci.Enabled = _Enable
        TxtxDias1erVenci.Enabled = _Enable
        TxtxDiasEntreVenci.Enabled = _Enable
        TxtxMorosidadP.Enabled = _Enable

        Sw_Libera_NVV.Enabled = _Enable

        If _Enable Then TxtxCtoTotal.Focus()

    End Sub

    Public Function Fx_Llenar_Entidad(_Koen As String, _Suen As String) As Boolean

        Try

            Consulta_sql = "Select * From MAEEN Where KOEN = '" & _Koen & "' And SUEN = '" & _Suen & "'"
            Dim Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            If Tbl.Rows.Count > 0 Then
                _RowEntidad = Tbl.Rows(0)
            Else
                MessageBoxEx.Show(Me, "Entidad no existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If

            TxtxCodEntidad.Text = _Koen
            TxtxSucursal.Text = _Suen
            TipoSuc = _RowEntidad.Item("TIPOSUC")
            TxtxRut.Text = Trim(_RowEntidad.Item("RTEN")) & "-" & Trim(RutDigito(_RowEntidad.Item("RTEN")))
            CmbxTipoEntidad.SelectedValue = _RowEntidad.Item("TIEN")
            TxtxRazonSocial.Text = Trim(_RowEntidad.Item("NOKOEN"))
            TxtxDireccion.Text = Trim(_RowEntidad.Item("DIEN"))
            TxtxSigla.Text = Trim(_RowEntidad.Item("SIEN"))
            TxtxGiro.Text = Trim(_RowEntidad.Item("GIEN"))
            TxtxCodPostal.Text = Trim(_RowEntidad.Item("CPOSTAL"))
            TxtxTelefono.Text = Trim(_RowEntidad.Item("FOEN"))
            TxtxFax.Text = Trim(_RowEntidad.Item("FAEN"))
            TxtxEmail1.Text = Trim(_RowEntidad.Item("EMAIL"))

            Try
                TxtxEmail2.Text = Trim(_RowEntidad.Item("EMAILCOMER"))
            Catch ex As Exception
                TxtxEmail2.Text = String.Empty
                TxtxEmail2.Enabled = False
            End Try

            _Pais = _RowEntidad.Item("PAEN").ToString.Trim
            _Ciudad = _RowEntidad.Item("CIEN").ToString.Trim
            _Comuna = _RowEntidad.Item("CMEN").ToString.Trim

            Consulta_sql = "Select Pa.KOPA,Pa.NOKOPA,Ci.KOCI,Ci.NOKOCI,Cm.KOCM,Cm.NOKOCM,
                        Rtrim(Ltrim(Pa.NOKOPA))+' - '+Rtrim(Ltrim(Ci.NOKOCI))+' - '+Rtrim(Ltrim(Cm.NOKOCM)) As Localidad	
                        From TABCM Cm 
                        Inner Join TABCI Ci On Ci.KOPA = Cm.KOPA And Ci.KOCI = Cm.KOCI
                        Inner Join TABPA Pa On Pa.KOPA = Cm.KOPA
                        Where Pa.KOPA = '" & _Pais & "' And Ci.KOCI = '" & _Ciudad & "' And Cm.KOCM = '" & _Comuna & "'"

            Dim _Row_Localidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _NPais = _Row_Localidad.Item("NOKOPA")
            Dim _NCiudad = _Row_Localidad.Item("NOKOCI")
            Dim _NComuna = _Row_Localidad.Item("NOKOCM")

            Txt_Comuna.Text = _NComuna.Trim & ", " & _NCiudad.Trim & " - " & _NPais

            Btn_Buscar_Comuna.Text = "Cambiar comuna..."

            CmbxZona.SelectedValue = Trim(_RowEntidad.Item("ZOEN"))
            TxtxRazonSocialAmpliada.Text = Trim(_RowEntidad.Item("NOKOENAMP"))
            CmbxVendedor.SelectedValue = Trim(_RowEntidad.Item("KOFUEN"))
            CmbxCobrador.SelectedValue = Trim(_RowEntidad.Item("COBRADOR"))

            Dim ListaC As String = Replace(Trim(_RowEntidad.Item("LCEN")), "TABPP", "")
            Dim ListaV As String = Replace(Trim(_RowEntidad.Item("LVEN")), "TABPP", "")

            CmbxListaCosto.SelectedValue = Trim(ListaC)
            CmbxListaVenta.SelectedValue = Trim(ListaV)


            Cmbx_Cat_Rubro.SelectedValue = Trim(_RowEntidad.Item("RUEN"))
            Cmbx_Cat_TipoEntidad.SelectedValue = Trim(_RowEntidad.Item("TIPOEN"))
            Cmbx_Cat_ActEconomica.SelectedValue = Trim(_RowEntidad.Item("ACTIEN"))
            Cmbx_Cat_TamanoEmpresa.SelectedValue = Trim(_RowEntidad.Item("TAMAEN"))
            Cmbx_Cat_Transportista.SelectedValue = Trim(_RowEntidad.Item("TRANSPOEN"))
            TxtxObservacionesDoc.Text = Trim(_RowEntidad.Item("OBEN"))

            TxtxCtoTotal.Tag = _RowEntidad.Item("CRTO")
            TxtxCtoSinDocumentar.Tag = _RowEntidad.Item("CRSD")
            TxtxCtoEnCheques.Tag = _RowEntidad.Item("CRCH")
            TxtxCtoEnLetra.Tag = _RowEntidad.Item("CRLT")
            TxtxCtoEnPagare.Tag = _RowEntidad.Item("CRPA")

            TxtxCtoTotal.Text = FormatNumber(TxtxCtoTotal.Tag, 0)
            TxtxCtoSinDocumentar.Text = FormatNumber(TxtxCtoSinDocumentar.Tag, 0)
            TxtxCtoEnCheques.Text = FormatNumber(TxtxCtoEnCheques.Tag, 0)
            TxtxCtoEnLetra.Text = FormatNumber(TxtxCtoEnLetra.Tag, 0)
            TxtxCtoEnPagare.Text = FormatNumber(TxtxCtoEnPagare.Tag, 0)


            TxtxNroMaxVenci.Tag = _RowEntidad.Item("NUVECR")
            TxtxDias1erVenci.Tag = _RowEntidad.Item("DIPRVE")
            TxtxDiasEntreVenci.Tag = NuloPorNro(_RowEntidad.Item("DIASVENCI"), 0)
            TxtxMorosidadP.Tag = _RowEntidad.Item("DIMOPER")

            TxtxNroMaxVenci.Text = FormatNumber(TxtxNroMaxVenci.Tag, 0)
            TxtxDias1erVenci.Text = FormatNumber(TxtxDias1erVenci.Tag, 0)
            TxtxDiasEntreVenci.Text = FormatNumber(TxtxDiasEntreVenci.Tag, 0)
            TxtxMorosidadP.Text = FormatNumber(TxtxMorosidadP.Tag, 0)

            DtpxFechaCreacion.Value = NuloPorNro(_RowEntidad.Item("FECREEN"), Now.Date)

            DtpxFechaVigencia.Value = NuloPorNro(_RowEntidad.Item("FEVECREN"), Nothing)
            TxtxoObservacionesCondPago.Text = Trim(_RowEntidad.Item("CPEN"))

            ChkxBloqueadaVyC.Checked = _RowEntidad.Item("BLOQUEADO")
            ChkxBlocCompras.Checked = _RowEntidad.Item("BLOQENCOM")
            CmbxMoneda.SelectedValue = _RowEntidad.Item("MOCTAEN")

            ChkxEnsEsEmisorDocumento.Checked = _RowEntidad.Item("RECEPELECT")
            ChkxEntNoAfecCtaCte.Checked = _RowEntidad.Item("NOTRAEDEUD")
            ChkxEntPreferencial.Checked = _RowEntidad.Item("PREFEN")

            ChkxExigeNVV.Checked = _RowEntidad.Item("NVVPIDEPIE")

            TxtxPorcAnticipo.Tag = _RowEntidad.Item("POPICR")
            TxtxPorcAnticipo.Text = FormatNumber(TxtxPorcAnticipo.Tag, 0)

            '-- DIACOBRA CON EXISTE EN LA TABLA MAEEN

            Dim _DiaCobra As String = NuloPorNro(_RowEntidad.Item("DIACOBRA"), "")

            If Mid(_DiaCobra, 1, 1) = "X" Then Chk_Lunes.Checked = True
            If Mid(_DiaCobra, 2, 1) = "X" Then Chk_Martes.Checked = True
            If Mid(_DiaCobra, 3, 1) = "X" Then Chk_Miercoles.Checked = True
            If Mid(_DiaCobra, 4, 1) = "X" Then Chk_Jueves.Checked = True
            If Mid(_DiaCobra, 5, 1) = "X" Then Chk_Viernes.Checked = True
            If Mid(_DiaCobra, 6, 1) = "X" Then Chk_Sabado.Checked = True
            If Mid(_DiaCobra, 7, 1) = "X" Then Chk_Domingo.Checked = True

            Txt_Cta_NroCtaCte.Text = _RowEntidad.Item("CUENTABCO").ToString.Trim             '--CUENTABCO =  Nro Cta Cte  (20)
            Txt_Cta_Codigo_Banco.Text = _RowEntidad.Item("KOENDPEN").ToString.Trim           '--KOENDPEN  =  Código del banco (13)
            Txt_Cta_Plaza_Sucursal.Text = _RowEntidad.Item("SUENDPEN").ToString.Trim         '--SUENDPEN  =  Plaza o sucursal bancaria (3)
            Txt_Cta_Codigo_Act_Economica.Text = _RowEntidad.Item("ACTECOBCO").ToString.Trim  '--ACTECOBCO =  Código de actividad economica   (10)

            Txt_Nacionen.Text = _RowEntidad.Item("NACIONEN").ToString.Trim
            Txt_Profecen.Text = _RowEntidad.Item("PROFECEN").ToString.Trim
            Txt_Dirparen.Text = _RowEntidad.Item("DIRPAREN").ToString.Trim
            Dtp_Fecnacen.Value = NuloPorNro(_RowEntidad.Item("FECNACEN"), Nothing)
            Cmb_Estciven.SelectedValue = _RowEntidad.Item("ESTCIVEN")
            Cmb_Sexoen.SelectedValue = _RowEntidad.Item("SEXOEN")
            Cmb_Relacien.SelectedValue = _RowEntidad.Item("RELACIEN")
            Txt_Conyugen.Text = _RowEntidad.Item("CONYUGEN").ToString.Trim
            Txt_Rutconen.Text = _RowEntidad.Item("RUTCONEN").ToString.Trim
            Rutsocen.Text = _RowEntidad.Item("RUTSOCEN").ToString.Trim
            Txt_Anexen1.Text = _RowEntidad.Item("ANEXEN1").ToString.Trim
            Txt_Anexen2.Text = _RowEntidad.Item("ANEXEN2").ToString.Trim
            Txt_Anexen3.Text = _RowEntidad.Item("ANEXEN3").ToString.Trim

            Input_Rutalun.Value = NuloPorNro(_RowEntidad.Item("RUTALUN"), 0)
            Input_Rutamar.Value = NuloPorNro(_RowEntidad.Item("RUTAMAR"), 0)
            Input_Rutamie.Value = NuloPorNro(_RowEntidad.Item("RUTAMIE"), 0)
            Input_Rutajue.Value = NuloPorNro(_RowEntidad.Item("RUTAJUE"), 0)
            Input_Rutavie.Value = NuloPorNro(_RowEntidad.Item("RUTAVIE"), 0)
            Input_Rutasab.Value = NuloPorNro(_RowEntidad.Item("RUTASAB"), 0)
            Input_Rutadom.Value = NuloPorNro(_RowEntidad.Item("RUTADOM"), 0)

            If _Existe_Tbl_Entidades_Bakapp Then

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Entidades where CodEntidad = '" & _Koen & "' And CodSucEntidad = '" & _Suen & "'"
                Dim _Row_Entidades As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If IsNothing(_Row_Entidades) Then

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Entidades (CodEntidad,CodSucEntidad,Libera_NVV) Values ('" & _Koen & "','" & _Suen & "',0)" & vbCrLf &
                                   "Select * From " & _Global_BaseBk & "Zw_Entidades where CodEntidad = '" & _Koen & "' And CodSucEntidad = '" & _Suen & "'"
                    _Row_Entidades = _Sql.Fx_Get_DataRow(Consulta_sql)

                End If

                Sw_Libera_NVV.Value = _Row_Entidades.Item("Libera_NVV")

            End If

            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub BtnCrearContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Fm As New Frm_Crear_Entidad_Mt_Crear_Contactos
        Fm._CodEntidad = TxtxCodEntidad.Text
        Fm.ShowDialog(Me)
    End Sub

    Sub PresionaEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub TxtxCodEntidad_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtxCodEntidad.Validating

        If String.IsNullOrEmpty(Trim(TxtxCodEntidad.Text)) Then

            If TabControl1.SelectedTabIndex = 0 Then

                MessageBoxEx.Show(Me, "Código de entidad vacio, debe completar datos", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

            e.Cancel = True

        End If


        Dim _EncuetraEnt As Integer = _Sql.Fx_Cuenta_Registros("MAEEN", "KOEN = '" & TxtxCodEntidad.Text & "'")

        If CBool(_EncuetraEnt) Then
            If MessageBoxEx.Show(Me, "Esta entidad ya existe en el sistema" & vbCrLf &
                                "¿Desea crear una sucursal para la entidad?",
                                "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) = Windows.Forms.DialogResult.Yes Then

                Sb_Crear_Sucursal()

            Else
                TxtxCodEntidad.Text = String.Empty
                e.Cancel = True
            End If
        Else
            _Crear_Sucursal = False
        End If

    End Sub

    Public Sub Sb_Crear_Sucursal()

        Dim _TblEnt As DataTable

        Consulta_sql = "Select KOEN,SUEN,TIPOSUC,RTEN,NOKOEN,TIEN,GIEN FROM MAEEN" & vbCrLf &
                       "Where KOEN = '" & TxtxCodEntidad.Text & "'" & vbCrLf &
                       "Order by TIPOSUC"

        _TblEnt = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_TblEnt.Rows.Count) Then

            Dim Rut As String = _TblEnt.Rows(0).Item("RTEN").ToString
            TxtxRut.Text = Trim(Rut) & "-" & RutDigito(Rut)
            TxtxRut.Enabled = False

            Dim _Carac As String = _Sql.Fx_Trae_Dato("MAEEN", "SUEN", "KOEN = '" & TxtxCodEntidad.Text & "' Order By IDMAEEN Desc").ToString.Trim
            Dim _Digito = 2

            If Not String.IsNullOrEmpty(_Carac) Then
                _Digito = _Carac.Length
            End If

            Dim _Sucursales As Integer = _Sql.Fx_Cuenta_Registros("MAEEN", "KOEN = '" & TxtxCodEntidad.Text & "'")
            Dim _Existe_Suc As Boolean

            Do
                _Sucursales += 1
                TxtxSucursal.Text = numero_(_Sucursales, _Digito)
                _Existe_Suc = CBool(_Sql.Fx_Cuenta_Registros("MAEEN", "KOEN = '" & TxtxCodEntidad.Text & "'" & vbCrLf &
                                           "And SUEN = '" & TxtxSucursal.Text & "'"))
            Loop While (_Existe_Suc)

            'If MessageBoxEx.Show(Me, "¿Desea dejar el código de la sucursal como " & TxtxSucursal.Text & "?", "Sucursal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            '    TxtxSucursal.Text = String.Empty
            'End If

            TxtxRazonSocial.Text = Trim(_TblEnt.Rows(0).Item("NOKOEN").ToString)
            TxtxRazonSocialAmpliada.Text = Trim(_TblEnt.Rows(0).Item("NOKOEN").ToString)
            CmbxTipoEntidad.SelectedValue = Trim(_TblEnt.Rows(0).Item("TIEN").ToString)
            TxtxGiro.Text = Trim(_TblEnt.Rows(0).Item("GIEN").ToString)
            TxtxCodEntidad.Enabled = False

            If MessageBoxEx.Show(Me, "¿Confirma el código sugerido para la sucursal?" & vbCrLf & vbCrLf &
                                 "Código sugerido: " & TxtxSucursal.Text, "Sucursal", MessageBoxButtons.YesNo) = DialogResult.No Then
                TxtxSucursal.Focus()
            Else
                TxtxDireccion.Focus()
            End If

            TipoSuc = "S"
            _Crear_Sucursal = True

        Else
            MessageBoxEx.Show(Me, "Alguien elimino la entidad", "Validación",
                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If
    End Sub

    Private Sub BtnContactosEntidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnContactosEntidad.Click

        Dim Fm As New Frm_Crear_Entidad_Mt_Lista_contactos(False)
        Fm.Pro_CodEntidad = TxtxCodEntidad.Text
        Fm.Pro_SucEntidad = TxtxSucursal.Text
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub ChkxExigeNVV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkxExigeNVV.CheckedChanged
        TxtxPorcAnticipo.Enabled = ChkxExigeNVV.Checked
    End Sub

    Private Sub BtnEliminarUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminarUser.Click
        If Fx_Eliminar_Entidad(TxtxCodEntidad.Text, TxtxSucursal.Text, Me) Then
            _Elimnar = True
            Me.Close()
        End If
    End Sub

    Private Sub Btn_ComentariosCtaCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ComentariosCtaCte.Click
        Dim Fm As New Frm_Crear_Entidad_Mt_Obs_CtaCte
        Fm.Pro_CodEntidad = TxtxCodEntidad.Text
        Fm.Pro_SucEntidad = TxtxSucursal.Text
        Fm.ShowDialog(Me)
    End Sub

    Private Sub Sb_ChkxBloqueadaVyC(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Palabra As String
        Dim _BloDes As String

        If Not ChkxBloqueadaVyC.Checked Then
            _Palabra = "Desbloqueo"
            _BloDes = "Bloq.Comp/Vta decía : SI ahora dice : NO, "
        Else
            _Palabra = "Bloqueo"
            _BloDes = "Bloq.Comp/Vta decía : NO ahora dice : SI, "
        End If

        Dim _HoraGrab = Hora_Grab_fx(False)
        Dim _Observacion = String.Empty

        If MessageBoxEx.Show(Me, "¿Desea agregar un comentario con respecto al " & _Palabra & "?", "Comentario",
                             MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            _Observacion = InputBox_Bk(Me, "Ingrese una observación",
                                                 "Observación", "", True, _Tipo_Mayus_Minus.Mayusculas)


            If Not String.IsNullOrEmpty(Trim(_Observacion)) Then
                _Observacion = Replace(_Observacion, vbCrLf, " ")
            Else
                _Observacion = String.Empty
            End If
        End If

        _Observacion = _BloDes & _Observacion

        _Sql_BlocDesb_VtayCmp = "Insert Into MAEENOBS (KOEN,SUEN,KOFU,FECHA,HORAGRAB,POSIT) Values " & vbCrLf &
                                "('" & TxtxCodEntidad.Text & "','" & TxtxSucursal.Text & "','" & FUNCIONARIO & "','" & Format(FechaDelServidor, "yyyyMMdd") &
                                "'," & _HoraGrab & ",'" & _Observacion & "')"

    End Sub

    Private Sub Sb_ChkxBlocCompras(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Palabra As String
        Dim _BloDes As String

        If Not ChkxBlocCompras.Checked Then
            _Palabra = "Desbloqueo"
            _BloDes = "Bloq.Compras decía : SI ahora dice : NO, "
        Else
            _Palabra = "Bloqueo"
            _BloDes = "Bloq.Compras decía : NO ahora dice : SI, "
        End If

        Dim _HoraGrab = Hora_Grab_fx(False)
        Dim _Observacion = String.Empty

        If MessageBoxEx.Show(Me, "¿Desea agregar un comentario con respecto al " & _Palabra & "?", "Comentario",
                             MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            _Observacion = InputBox_Bk(Me, "Ingrese una observación",
                                                 "Observación", "", True, _Tipo_Mayus_Minus.Mayusculas)


            If Not String.IsNullOrEmpty(Trim(_Observacion)) Then
                _Observacion = Replace(_Observacion, vbCrLf, " ")
            Else
                _Observacion = String.Empty
            End If

        End If

        _Observacion = _BloDes & _Observacion

        _Sql_BlocDesb_Compra = "Insert Into MAEENOBS (KOEN,SUEN,KOFU,FECHA,HORAGRAB,POSIT) Values " & vbCrLf &
                               "('" & TxtxCodEntidad.Text & "','" & TxtxSucursal.Text & "','" & FUNCIONARIO & "','" & Format(FechaDelServidor, "yyyyMMdd") &
                               "'," & _HoraGrab & ",'" & _Observacion & "')"


    End Sub

    Private Sub Btn_TipoEntidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_TipoEntidad.Click
        If Fx_Tiene_Permiso(Me, "Tbl00015") Then
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Tipoentidad,
                                                                 Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "TIPO DE ENTIDAD"
            Fm.ShowDialog(Me)
            Fm.Dispose()

            caract_combo(Cmbx_Cat_TipoEntidad)
            Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                           "SELECT KOCARAC AS Padre,NOKOCARAC AS Hijo FROM TABCARAC WHERE KOTABLA = 'TIPOENTIDA' ORDER BY Padre"
            Cmbx_Cat_TipoEntidad.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        End If
    End Sub

    Private Sub Btn_TamnoEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_TamnoEmpresa.Click
        If Fx_Tiene_Permiso(Me, "Tbl00013") Then
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Tamanoempr,
                                                                  Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "TAMAÑO EMPRESA"
            Fm.ShowDialog(Me)
            Fm.Dispose()

            caract_combo(Cmbx_Cat_TamanoEmpresa)
            Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                           "SELECT KOCARAC AS Padre,NOKOCARAC AS Hijo FROM TABCARAC WHERE KOTABLA = 'TAMA¥OEMPR' ORDER BY Padre"
            Cmbx_Cat_TamanoEmpresa.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        End If
    End Sub

    Private Sub Btn_Rubro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Rubro.Click
        If Fx_Tiene_Permiso(Me, "Tbl00017") Then
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Rubros,
                                                                 Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "RUBROS"
            Fm.ShowDialog(Me)
            Fm.Dispose()

            caract_combo(Cmbx_Cat_Rubro)
            Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                           "SELECT KORU AS Padre,NOKORU AS Hijo FROM TABRU ORDER BY Padre"
            Cmbx_Cat_Rubro.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        End If
    End Sub

    Private Sub Btn_ActividadEconomica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ActividadEconomica.Click
        If Fx_Tiene_Permiso(Me, "Tbl00012") Then
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Actividade,
                                                                 Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "ACTIVIDAD ECONOMICA"
            Fm.ShowDialog(Me)
            Fm.Dispose()

            caract_combo(Cmbx_Cat_ActEconomica)
            Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                           "SELECT KOCARAC AS Padre,NOKOCARAC AS Hijo FROM TABCARAC WHERE KOTABLA = 'ACTIVIDADE' ORDER BY Padre"
            Cmbx_Cat_ActEconomica.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)


        End If
    End Sub

    Private Sub Btn_Transportista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Transportista.Click

        If Fx_Tiene_Permiso(Me, "") Then
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Transporte,
                                                                 Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "TRANSPORTE"
            Fm.ShowDialog(Me)
            Fm.Dispose()

            caract_combo(Cmbx_Cat_Transportista)
            Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                           "SELECT KOCARAC AS Padre,NOKOCARAC AS Hijo FROM TABCARAC WHERE KOTABLA = 'TRANSPORTE' ORDER BY Padre"
            Cmbx_Cat_Transportista.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        End If
    End Sub

    Private Sub Btn_Asociar_Marcas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Asociar_Marcas.Click

        Dim Fm As New Frm_ProveedoresVSMarcas
        Fm.TxtCodigo.Text = TxtxCodEntidad.Text
        Fm.Txtdescripcion.Text = TxtxRazonSocial.Text

        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Anotaciones_a_la_entidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Anotaciones_a_la_entidad.Click

        Dim _Idmaeen As Integer = _RowEntidad.Item("IDMAEEN")

        Dim Fm As New Frm_Anotaciones_Ver_Anotaciones(_Idmaeen, Frm_Anotaciones_Ver_Anotaciones.Tipo_Tabla.MAEEN)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Agregar_CtaCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Agregar_CtaCte.Click

        Dim _Koen = TxtxCodEntidad.Text

        Dim _Emisor = String.Empty
        Dim _Nombre_Emisor = String.Empty
        Dim _Tipopago = String.Empty
        Dim _Sucursal = String.Empty
        Dim _Cuenta = String.Empty
        Dim _Banco = String.Empty

        If Not String.IsNullOrEmpty(_Koen) Then

            Dim _Filtro_Extra_Sql = "And CodigoTabla In ('CHV','TJV','LTV')"

            Dim Fm_Tp As New Frm_Pagos_Seleccion_Tipo_Pago(Frm_Pagos_Seleccion_Tipo_Pago.Enum_Cliente_Proveedor.TIDP_Cli)
            Fm_Tp.Pro_Filtro_Extra_Sql = _Filtro_Extra_Sql
            Fm_Tp.ShowDialog(Me)
            Dim _Tidp_Seleccionado As Boolean = Fm_Tp.Pro_Precio_Tidp_Seleccionado
            Dim _Row_Tidp As DataRow = Fm_Tp.Pro_Row_Tidp
            Fm_Tp.Dispose()

            If _Tidp_Seleccionado Then

                Dim _Tipo_Pago As Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago

                _Tipopago = _Row_Tidp.Item("TIDP")

                If _Tipopago = "CHV" Then _Tipo_Pago = Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.CH
                If _Tipopago = "TJV" Then _Tipo_Pago = Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.TJ
                If _Tipopago = "LTV" Then _Tipo_Pago = Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.LT


                Dim _Aceptar As Boolean
                Dim _Rut, _Norut As String

                Dim Fm_Cta As New Frm_Pagos_Agregar_Cte_Maeencta
                Fm_Cta.Emisor = _Emisor
                Fm_Cta.Nombre_Emisor = _Nombre_Emisor
                Fm_Cta.Sucursal = _Sucursal

                Fm_Cta.Tidpen = _Tipo_Pago
                Fm_Cta.ShowDialog(Me)

                _Aceptar = Fm_Cta.Aceptar
                _Rut = Fm_Cta.Rut
                _Norut = Fm_Cta.Norut
                _Emisor = Fm_Cta.Emisor
                _Sucursal = Fm_Cta.Sucursal
                _Cuenta = Fm_Cta.Cuenta
                _Banco = _Tipopago & " - " & Fm_Cta.Nombre_Emisor

                Fm_Cta.Dispose()

                If _Aceptar Then

                    Dim _NewFila As DataRow = Fx_Nueva_Linea_Cta(_Tbl_Maeencta, _Koen, _Tipopago, _Emisor, _Cuenta, _Rut, _Norut, False, _Sucursal, _Banco)

                    MessageBoxEx.Show(Me, "Registro incorporado correctamente a la lista", "Insertar nueva Cuenta",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Grilla_Cuentas.Rows(Grilla_Cuentas.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Black
                    Grilla_Cuentas.Rows(Grilla_Cuentas.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightYellow

                    Lbl_Warning_Ctas.Visible = _Editar_Entidad
                    Img_Warning_Ctas.Visible = _Editar_Entidad

                End If

            End If

        End If

    End Sub

#Region "COMBOBOX EN DATAGRIDVIEW"

    Sub Sb_Act_Cta_Banco()

        For Each _Fila As DataGridViewRow In Grilla_Cuentas.Rows
            Dim _TIPOPAGO = Mid(_Fila.Cells("TIPOPAGO").Value, 1, 2)
            _Fila.Cells("_TIPOPAGO").Value = _TIPOPAGO

            Dim _Cmb As New DataGridViewComboBoxCell

            Sb_Llena_Combo_Tipo_Pago_Cell(_Cmb)

            _Cmb.Value = _TIPOPAGO
            Grilla_Cuentas.Item("BANCO", _Fila.Index) = _Cmb


            Dim _Koendp = _Fila.Cells("EMISOR").Value
            Sb_TipoPago(_Fila)
            Grilla_Cuentas.EndEdit()
            Sb_Cell_Banco(_Fila, _Koendp)
        Next

    End Sub

    Sub Sb_Llena_Combo_Tipo_Pago_Cell(ByVal _Cmb As DataGridViewComboBoxCell)

        'caract_combo(_Cmb)
        _Cmb.ValueMember = "Padre"
        _Cmb.DisplayMember = "Hijo"

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Padre", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Hijo", System.Type.[GetType]("System.String"))
        ',,,,,,

        dr = dt.NewRow() : dr("Padre") = "" : dr("Hijo") = "" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "CH" : dr("Hijo") = "CHV" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "TJ" : dr("Hijo") = "TJV" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "LT" : dr("Hijo") = "LTV" : dt.Rows.Add(dr)
        'cerramos el datareader y la conexión
        'añadimos la tabla al dataset
        rs.Tables.Add(dt)

        With _Cmb
            .DataSource = Nothing
            .DataSource = dt
        End With

    End Sub

    Sub Sb_Cell_Banco(ByVal _Fila As DataGridViewRow, ByVal _Koendp As String)

        'Dim _Koendp = Trim(_Fila.Cells("BANCO").Value)
        Dim _Tidepen = _Fila.Cells("_TIPOPAGO").Value
        Dim _TipoPago = _Fila.Cells("_TIPOPAGO").FormattedValue

        Consulta_sql = "Select top 1 * From TABENDP" & vbCrLf &
                       "Where EMPRESA = '" & ModEmpresa & "' And KOENDP = '" & Trim(_Koendp) & "' And TIDPEN = '" & _Tidepen & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        _Fila.Cells("KOEN").Value = TxtxCodEntidad.Text
        _Fila.Cells("EMISOR").Value = _Tbl.Rows(0).Item("KOENDP")
        _Fila.Cells("SUCURSAL").Value = _Tbl.Rows(0).Item("SUENDP")
        _Fila.Cells("TIPOPAGO").Value = _TipoPago

    End Sub

    Private Sub Grilla_Cuentas_CellMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Grilla_Cuentas.CellMouseUp

        Try
            Dim _Cabeza = Grilla_Cuentas.Columns(Grilla_Cuentas.CurrentCell.ColumnIndex).Name

            If _Cabeza = "BLOQUEADO" Then
                Grilla_Cuentas.EndEdit()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Grilla_Cuentas_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        'Handles Grilla_Cuentas.CellValueChanged
        Dim _Cabeza = Grilla_Cuentas.Columns(Grilla_Cuentas.CurrentCell.ColumnIndex).Name

        If _Cabeza = "_TIPOPAGO" Then

            Dim _Fila As DataGridViewRow = Grilla_Cuentas.Rows(Grilla_Cuentas.CurrentRow.Index)

            Sb_TipoPago(_Fila)

            'End If

        End If
    End Sub

    Private Sub Btn_Cta_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Cta_Editar.Click

        Call Grilla_Cuentas_CellDoubleClick(Nothing, Nothing)

    End Sub

    Private Sub Btn_Agregar_Notif_Click(sender As Object, e As EventArgs) Handles Btn_Agregar_Notif.Click

        Dim _NewFila As DataRow = Fx_Nueva_Linea_Notificacion(_Tbl_Maeenmail, TxtxCodEntidad.Text, "", "", "", "", "", "", "", "", "", "", "", Date.Now)
        Dim _Aceptar As Boolean

        Dim Fm As New Frm_Crear_Entidad_Mt_Noficicaiones(_NewFila)
        Fm.ShowDialog(Me)
        _Aceptar = Fm.Aceptar
        Fm.Dispose()

        If Not _Aceptar Then

            Grilla_Maeenmail.Rows.RemoveAt(Grilla_Maeenmail.RowCount - 1)
            Lbl_Warning_Notif.Visible = _Editar_Entidad
            Img_Warning_Notif.Visible = _Editar_Entidad

            If CBool(Grilla_Maeenmail.Rows.Count) Then
                Grilla_Maeenmail.Rows(Grilla_Cuentas.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Black
                Grilla_Maeenmail.Rows(Grilla_Cuentas.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightYellow
            End If

        End If

    End Sub

    Private Sub Grilla_Maeenmail_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Maeenmail.CellEnter

        Try

            Dim _Fila As DataGridViewRow = Grilla_Maeenmail.Rows(Grilla_Maeenmail.CurrentRow.Index)

            Dim _Name_komail As String = _Fila.Cells("NAME_KOMAIL").Value

            Lbl_Notificacion.Text = _Name_komail

        Catch ex As Exception
            Lbl_Notificacion.Text = String.Empty
        End Try

    End Sub

    Sub Sb_TipoPago(ByVal _Fila As DataGridViewRow)

        Dim _TP = _Fila.Cells("_TIPOPAGO")
        Dim _TipoPago = _Fila.Cells("_TIPOPAGO").Value

        Dim _Cmb_Banco As New DataGridViewComboBoxCell
        '_Cmb_Banco.Name = "BANCO"

        'caract_combo(_Cmb)
        _Cmb_Banco.ValueMember = "Padre"
        _Cmb_Banco.DisplayMember = "Hijo"

        Consulta_sql = "Select KOENDP AS Padre,NOKOENDP as Hijo From TABENDP" & vbCrLf &
                       "Where TIDPEN = '" & _TipoPago & "'"

        _Cmb_Banco.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        Grilla_Cuentas.Item("BANCO", _Fila.Index) = _Cmb_Banco

    End Sub

    Private Sub Grilla_Maeenmail_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Maeenmail.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Maeenmail.Rows(Grilla_Maeenmail.CurrentRow.Index)
        Dim _Id = _Fila.Cells("ID").Value

        Dim _NewFila As DataRow '= Fx_Nueva_Linea_Notificacion(_Tbl_Maeenmail, TxtxCodEntidad.Text, "", "", "", "", "", "", "", "", "", "", "", Date.Now)
        Dim _Aceptar As Boolean

        For Each _Row As DataRow In _Tbl_Maeenmail.Rows

            Dim _IdR = _Row.Item("ID")

            If _Id = _IdR Then
                _NewFila = _Row
                Exit For
            End If

        Next

        Dim Fm As New Frm_Crear_Entidad_Mt_Noficicaiones(_NewFila)
        Fm.ShowDialog(Me)
        _Aceptar = Fm.Aceptar
        Fm.Dispose()

        If _Aceptar Then

            Lbl_Warning_Notif.Visible = _Editar_Entidad
            Img_Warning_Notif.Visible = _Editar_Entidad

            If CBool(Grilla_Maeenmail.Rows.Count) Then

                Grilla_Maeenmail.Rows(Grilla_Maeenmail.CurrentRow.Index).DefaultCellStyle.ForeColor = Color.Black
                Grilla_Maeenmail.Rows(Grilla_Maeenmail.CurrentRow.Index).DefaultCellStyle.BackColor = Color.LightYellow

            End If

        End If

    End Sub

    Private Sub Btn_Notif_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Notif_Editar.Click

        Call Grilla_Maeenmail_CellDoubleClick(Nothing, Nothing)

    End Sub

    Private Sub Btn_Notif_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Notif_Eliminar.Click

        If MessageBoxEx.Show(Me, "¿Confirma la eliminación de la cuenta?", "Eliminar cuenta",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Grilla_Maeenmail.Rows.RemoveAt(Grilla_Maeenmail.RowCount - 1)

            Lbl_Warning_Notif.Visible = _Editar_Entidad
            Img_Warning_Notif.Visible = _Editar_Entidad

        End If

    End Sub

    Private Sub Btn_Direcciones_Despachos_Click(sender As Object, e As EventArgs) Handles Btn_Direcciones_Despachos.Click

        Dim Fm As New Frm_Direc_Cli_Lista(TxtxCodEntidad.Text, TxtxSucursal.Text)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Buscar_Comuna_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Comuna.Click

        Dim Fm As New Frm_PaCiCm_Lista
        Fm.ShowDialog(Me)

        If Not IsNothing(Fm.Row_Localidad) Then

            _Pais = Fm.Row_Localidad.Item("KOPA")
            _Ciudad = Fm.Row_Localidad.Item("KOCI")
            _Comuna = Fm.Row_Localidad.Item("KOCM")

            Dim _NPais = Fm.Row_Localidad.Item("NOKOPA")
            Dim _NCiudad = Fm.Row_Localidad.Item("NOKOCI")
            Dim _NComuna = Fm.Row_Localidad.Item("NOKOCM")

            Txt_Comuna.Text = _NComuna.Trim & ", " & _NCiudad.Trim & " - " & _NPais

        End If

        Fm.Dispose()

    End Sub


#End Region

    Private Sub Grilla_Cuentas_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Cuentas.CellDoubleClick

        Dim _Cabeza = Grilla_Cuentas.Columns(Grilla_Cuentas.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla_Cuentas.Rows(Grilla_Cuentas.CurrentRow.Index)

        Dim _Koen = TxtxCodEntidad.Text

        Dim _Tipopago = _Fila.Cells("TIPOPAGO").Value
        Dim _Emisor = _Fila.Cells("EMISOR").Value
        Dim _Sucursal = _Fila.Cells("SUCURSAL").Value
        Dim _Cuenta = _Fila.Cells("CUENTA").Value
        Dim _Banco = _Fila.Cells("BANCO").Value.ToString.Trim
        Dim _Nombre_Emisor = Replace(_Banco, _Tipopago & " - ", "")
        Dim _Rut = _Fila.Cells("RUT").Value
        Dim _Norut = _Fila.Cells("NORUT").Value

        If Not String.IsNullOrEmpty(_Koen) Then

            Dim _Tipo_Pago As Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago

            If _Tipopago = "CHV" Then _Tipo_Pago = Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.CH
            If _Tipopago = "TJV" Then _Tipo_Pago = Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.TJ

            Dim _Aceptar As Boolean

            Dim Fm_Cta As New Frm_Pagos_Agregar_Cte_Maeencta
            Fm_Cta.Btn_Buscar_Emisor.Enabled = False
            Fm_Cta.Txt_EMDP_Documento.Enabled = False
            Fm_Cta.Txt_SUEMDP_Sucursal.Enabled = False
            Fm_Cta.Emisor = _Emisor
            Fm_Cta.Nombre_Emisor = _Nombre_Emisor
            Fm_Cta.Sucursal = _Sucursal
            Fm_Cta.Cuenta = _Cuenta
            Fm_Cta.Rut = _Rut
            Fm_Cta.Norut = _Norut

            Fm_Cta.Tidpen = _Tipo_Pago
            Fm_Cta.ShowDialog(Me)

            _Aceptar = Fm_Cta.Aceptar
            _Rut = Fm_Cta.Rut
            _Norut = Fm_Cta.Norut
            _Emisor = Fm_Cta.Emisor
            _Sucursal = Fm_Cta.Sucursal
            _Cuenta = Fm_Cta.Cuenta
            _Banco = _Tipopago & " - " & Fm_Cta.Nombre_Emisor

            Fm_Cta.Dispose()

            If _Aceptar Then

                _Fila.Cells("TIPOPAGO").Value = _Tipopago
                _Fila.Cells("EMISOR").Value = _Emisor
                _Fila.Cells("SUCURSAL").Value = _Sucursal
                _Fila.Cells("CUENTA").Value = _Cuenta
                _Fila.Cells("BANCO").Value = _Banco
                _Fila.Cells("RUT").Value = _Rut
                _Fila.Cells("NORUT").Value = _Norut

                _Fila.DefaultCellStyle.ForeColor = Color.Black
                _Fila.DefaultCellStyle.BackColor = Color.LightGreen

                Lbl_Warning_Ctas.Visible = _Editar_Entidad
                Img_Warning_Ctas.Visible = _Editar_Entidad

            End If

        End If

    End Sub

    Private Sub Sw_Libera_NVV_ValueChanged(sender As Object, e As EventArgs)

        If Sw_Libera_NVV.Value Then

            Dim _CRTO As Double = TxtxCtoTotal.Tag
            Dim _CRSD As Double = TxtxCtoSinDocumentar.Tag
            Dim _CRCH As Double = TxtxCtoEnCheques.Tag
            Dim _CRLT As Double = TxtxCtoEnLetra.Tag
            Dim _CRPA As Double = TxtxCtoEnPagare.Tag

            Dim _Suma = _CRTO + _CRSD + _CRCH + _CRLT + _CRPA

            If Sw_Libera_NVV.Value And _Suma > 0 Then
                MessageBoxEx.Show(Me, "No puede dejar Libera NVV en [SI] cuando la entidad tiene créditos asociados" & vbCrLf &
                                  "Para poder dejar en [SI] debe dejar todos los créditos en cero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Sw_Libera_NVV.Value = False
            End If

        End If

    End Sub

    Private Sub Sb_Txt_Nros_Validated(sender As Object, e As EventArgs)
        CType(sender, Controls.TextBoxX).Tag = Val(CType(sender, Controls.TextBoxX).Text)
        CType(sender, Controls.TextBoxX).Text = FormatNumber(CType(sender, Controls.TextBoxX).Tag, 0)
    End Sub

    Private Sub Sb_Txt_Nros_Enter(sender As Object, e As EventArgs)
        CType(sender, Controls.TextBoxX).Text = CType(sender, Controls.TextBoxX).Tag
    End Sub

    Private Sub Btn_Cta_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cta_Eliminar.Click

        If MessageBoxEx.Show(Me, "¿Confirma la eliminación de la cuenta?", "Eliminar cuenta",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Grilla_Cuentas.Rows.RemoveAt(Grilla_Cuentas.CurrentRow.Index)

            Lbl_Warning_Ctas.Visible = _Editar_Entidad
            Img_Warning_Ctas.Visible = _Editar_Entidad

        End If

    End Sub

    Private Sub Sb_Grilla_Cuentas_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    ShowContextMenu(Menu_Contextual_02)

                End If
            End With
        End If
    End Sub

    Private Sub Sb_Grilla_Maennmail_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    ShowContextMenu(Menu_Contextual_03)

                End If
            End With
        End If
    End Sub


End Class
