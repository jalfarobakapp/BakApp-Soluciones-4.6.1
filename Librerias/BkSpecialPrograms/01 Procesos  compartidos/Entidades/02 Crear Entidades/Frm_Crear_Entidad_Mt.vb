Imports System.Data.SqlClient
Imports DevComponents.DotNetBar

Public Class Frm_Crear_Entidad_Mt

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    'Dim _CreaNuevaEntidad As Boolean
    'Dim CrearEntidad As Boolean
    'Dim EditarEntidad As Boolean
    'Dim _Grabar As Boolean
    'Dim _Elimnar As Boolean
    Dim _Crear_Sucursal As Boolean
    'Dim Pais, Ciudad, Comuna, Zona As String
    Dim TipoSuc As String = "P"
    Dim _Sql_BlocDesb_VtayCmp As String
    Dim _Sql_BlocDesb_Compra As String
    Dim _BlocDesb_VtayCmp, _BlocDesb_Compra As Boolean
    'Dim _RowEntidad As DataRow
    Dim _Tbl_Maeencta As DataTable
    Dim _Tbl_Maeenmail As DataTable
    Dim _Cmb_TipoPago As New DataGridViewComboBoxColumn
    Dim _Cmb_Banco As New DataGridViewComboBoxColumn

    Dim _Existe_Tbl_Entidades_Bakapp As Boolean

    Public Property Cl_Maeen As New Tablas_Entidades.Maeen
    Public Property Cl_Entidades As New Tablas_Entidades.Zw_Entidades


    Public Property CreaNuevaEntidad() As Boolean
    Public Property CrearEntidad() As Boolean
    Public Property EditarEntidad() As Boolean
    Public Property Grabar() As Boolean
    Public Property Elimnar() As Boolean

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Cuentas, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Maeenmail, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        Sb_Llena_Combos_Con_Arreglos()

        _Existe_Tbl_Entidades_Bakapp = _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Entidades")

        caract_combo(Cmb_Zoen)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KOZO AS Padre,NOKOZO AS Hijo FROM TABZO ORDER BY Padre" ' WHERE SEMILLA = " & Actividad
        Cmb_Zoen.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmb_Lcen)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KOLT AS Padre,'TABPP'+KOLT+' '+NOKOLT AS Hijo FROM TABPP WHERE TILT = 'C' ORDER BY Hijo "
        Cmb_Lcen.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Lcen.SelectedValue = ModListaPrecioCosto


        caract_combo(Cmb_Lven)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KOLT AS Padre,'TABPP'+KOLT+' '+NOKOLT AS Hijo FROM TABPP WHERE TILT = 'P' ORDER BY Hijo "
        Cmb_Lven.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Lven.SelectedValue = ModListaPrecioVenta


        caract_combo(Cmb_Kofuen)
        Consulta_sql = "Select '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "Select TABFU.KOFU AS Padre,TABFU.KOFU+'-'+NOKOFU AS Hijo" & vbCrLf &
                       "From TABFU" & vbCrLf &
                       "Inner Join TABFUEM On TABFUEM.KOFU=TABFU.KOFU And TABFUEM.EMPRESA='" & ModEmpresa & "'" & vbCrLf &
                       "Order BY Hijo"
        Cmb_Kofuen.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        If Fx_Tiene_Permiso(Me, "CfEnt014", , False) Then
            Cmb_Kofuen.SelectedValue = FUNCIONARIO
        Else
            Cmb_Kofuen.SelectedValue = ""
        End If

        caract_combo(Cmb_Cobrador)
        Consulta_sql = "Select '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "Select TABFU.KOFU AS Padre,TABFU.KOFU+'-'+NOKOFU AS Hijo" & vbCrLf &
                       "From TABFU" & vbCrLf &
                       "Inner Join TABFUEM On TABFUEM.KOFU=TABFU.KOFU And TABFUEM.EMPRESA='" & ModEmpresa & "'" & vbCrLf &
                       "Order BY Hijo"
        Cmb_Cobrador.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        If Fx_Tiene_Permiso(Me, "CfEnt015", , False) Then
            Cmb_Cobrador.SelectedValue = FUNCIONARIO
        Else
            Cmb_Cobrador.SelectedValue = ""
        End If



        caract_combo(CmbxMoneda)
        Consulta_sql = "SELECT KOMO AS Padre,LTRIM(LTRIM(KOMO))+' '+NOKOMO AS Hijo FROM TABMO" ' WHERE SEMILLA = " & Actividad
        CmbxMoneda.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dtp_Fecreen.Value = FechaDelServidor()

        caract_combo(Cmb_Actien)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KOCARAC AS Padre,NOKOCARAC AS Hijo FROM TABCARAC WHERE KOTABLA = 'ACTIVIDADE' ORDER BY Padre"
        Cmb_Actien.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmb_Ruen)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KORU AS Padre,NOKORU AS Hijo FROM TABRU ORDER BY Padre"
        Cmb_Ruen.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmb_Tamaen)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KOCARAC AS Padre,NOKOCARAC AS Hijo FROM TABCARAC WHERE KOTABLA = 'TAMA¥OEMPR' ORDER BY Padre"
        Cmb_Tamaen.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmb_Tien)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KOCARAC AS Padre,NOKOCARAC AS Hijo FROM TABCARAC WHERE KOTABLA = 'TIPOENTIDA' ORDER BY Padre"
        Cmb_Tien.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmb_Transpoen)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KOCARAC AS Padre,NOKOCARAC AS Hijo FROM TABCARAC WHERE KOTABLA = 'TRANSPORTE' ORDER BY Padre"
        Cmb_Transpoen.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        _CreaNuevaEntidad = False


        Dim _Creditos_Mod As DataTable

        Consulta_sql = "SELECT CRTO,CRSD,CRCH,CRLT,CRPA FROM CONFIEST WHERE MODALIDAD = '" & Modalidad & "'"
        _Creditos_Mod = _Sql.Fx_Get_Tablas(Consulta_sql)

        Txt_Crto.Text = _Creditos_Mod.Rows(0).Item("CRTO")
        Txt_Crsd.Text = _Creditos_Mod.Rows(0).Item("CRSD")
        Txt_Crch.Text = _Creditos_Mod.Rows(0).Item("CRCH")
        Txt_Crlt.Text = _Creditos_Mod.Rows(0).Item("CRLT")
        Txt_Crpa.Text = _Creditos_Mod.Rows(0).Item("CRPA")


        AddHandler Txt_Koen.KeyPress, AddressOf PresionaEnter
        AddHandler Txt_Suen.KeyPress, AddressOf PresionaEnter
        AddHandler Txt_Rten.KeyPress, AddressOf PresionaEnter
        AddHandler Txt_Nokoen.KeyPress, AddressOf PresionaEnter
        AddHandler Txt_Sien.KeyPress, AddressOf PresionaEnter
        AddHandler Txt_Dien.KeyPress, AddressOf PresionaEnter
        AddHandler Txt_Gien.KeyPress, AddressOf PresionaEnter
        AddHandler Txt_Foen.KeyPress, AddressOf PresionaEnter
        AddHandler Txt_Faen.KeyPress, AddressOf PresionaEnter
        AddHandler Txt_Email.KeyPress, AddressOf PresionaEnter
        AddHandler Txt_Emailcomer.KeyPress, AddressOf PresionaEnter
        AddHandler Txt_Cpostal.KeyPress, AddressOf PresionaEnter

        AddHandler Cmb_Tiposuc.KeyPress, AddressOf PresionaEnter
        AddHandler Cmb_Zoen.KeyPress, AddressOf PresionaEnter

        AddHandler Txt_Crsd.KeyPress, AddressOf PresionaEnter
        AddHandler Txt_Crch.KeyPress, AddressOf PresionaEnter
        AddHandler Txt_Crlt.KeyPress, AddressOf PresionaEnter
        AddHandler Txt_Crpa.KeyPress, AddressOf PresionaEnter
        AddHandler Txt_Crto.KeyPress, AddressOf PresionaEnter

        AddHandler Txt_Nuvecre.KeyPress, AddressOf PresionaEnter
        AddHandler Txt_Dipreve.KeyPress, AddressOf PresionaEnter
        AddHandler Txt_Diasvenci.KeyPress, AddressOf PresionaEnter
        AddHandler Txt_Dimoper.KeyPress, AddressOf PresionaEnter

        AddHandler Txt_MontoMinCompra.KeyPress, AddressOf PresionaEnter

        AddHandler Txt_Crsd.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros
        AddHandler Txt_Crch.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros
        AddHandler Txt_Crlt.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros
        AddHandler Txt_Crpa.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros
        AddHandler Txt_Crto.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros
        AddHandler Txt_Nuvecre.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros_Enteros
        AddHandler Txt_Dipreve.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros_Enteros
        AddHandler Txt_Diasvenci.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros_Enteros
        AddHandler Txt_Dimoper.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros_Enteros
        AddHandler Txt_Popicr.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros

        AddHandler Txt_MontoMinCompra.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros

        AddHandler Txt_Crsd.Validated, AddressOf Sb_Txt_Nros_Validated
        AddHandler Txt_Crch.Validated, AddressOf Sb_Txt_Nros_Validated
        AddHandler Txt_Crlt.Validated, AddressOf Sb_Txt_Nros_Validated
        AddHandler Txt_Crpa.Validated, AddressOf Sb_Txt_Nros_Validated
        AddHandler Txt_Crto.Validated, AddressOf Sb_Txt_Nros_Validated

        AddHandler Txt_MontoMinCompra.Validated, AddressOf Sb_Txt_Nros_Validated

        AddHandler Txt_Nuvecre.Validated, AddressOf Sb_Txt_Nros_Validated
        AddHandler Txt_Dipreve.Validated, AddressOf Sb_Txt_Nros_Validated
        AddHandler Txt_Diasvenci.Validated, AddressOf Sb_Txt_Nros_Validated
        AddHandler Txt_Dimoper.Validated, AddressOf Sb_Txt_Nros_Validated
        AddHandler Txt_Popicr.Validated, AddressOf Sb_Txt_Nros_Validated

        AddHandler Txt_Crsd.Enter, AddressOf Sb_Txt_Nros_Enter
        AddHandler Txt_Crch.Enter, AddressOf Sb_Txt_Nros_Enter
        AddHandler Txt_Crlt.Enter, AddressOf Sb_Txt_Nros_Enter
        AddHandler Txt_Crpa.Enter, AddressOf Sb_Txt_Nros_Enter
        AddHandler Txt_Crto.Enter, AddressOf Sb_Txt_Nros_Enter

        AddHandler Txt_MontoMinCompra.Enter, AddressOf Sb_Txt_Nros_Enter

        Sb_Color_Botones_Barra(Bar1)

        Chk_RevFincred.Visible = _Global_Row_Configuracion_General.Item("Fincred_Usar")
        Btn_Modificar_RevCredFincred.Visible = _Global_Row_Configuracion_General.Item("Fincred_Usar")

        'CheckBox1.Visible = _Global_Row_Configuracion_General.Item("Fincred_Usar")

    End Sub

    Private Sub Frm_Crear_Entidad_Mt_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Chk_Libera_NVV.Visible = _Existe_Tbl_Entidades_Bakapp
        Btn_ProductosExcluidos.Visible = False
        Btn_ProdCanMinCompra.Visible = False

        If CrearEntidad Then

            BtnContactosEntidad.Enabled = False
            BtnEliminarUser.Enabled = False
            Btn_ComentariosCtaCte.Enabled = False
            Btn_Anotaciones_a_la_entidad.Enabled = False
            Btn_Agregar_CtaCte.Enabled = False
            Cmb_Kofuen.Enabled = True
            BtnModVendedor.Enabled = False
            Cmb_Cobrador.Enabled = True
            BtnModCobrador.Enabled = False
            Btn_Direcciones_Despachos.Enabled = False

            If String.IsNullOrEmpty(Trim(Txt_Koen.Text)) Then
                Me.ActiveControl = Txt_Koen
            Else
                Me.Text += " CREAR SUCURSAL"
                Me.ActiveControl = Txt_Dien
            End If

            Btn_Asociar_Marcas.Enabled = False

            Grilla_Cuentas.DataSource = Nothing

        ElseIf EditarEntidad Then

            Dtp_Fecreen.Enabled = False
            Txt_Koen.Enabled = False
            Txt_Suen.Enabled = False
            BtnContactosEntidad.Enabled = True
            BtnEliminarUser.Enabled = True

            Me.ActiveControl = Txt_Dien
            Txt_Dien.Focus()

            _BlocDesb_VtayCmp = Chk_Bloqueado.Checked
            _BlocDesb_Compra = Chk_Bloqencom.Checked

            If _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Entidades_ProdExcluidos") Then
                Btn_ProductosExcluidos.Visible = True
            End If

            If _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Entidades_ProdMinCompra") Then
                Btn_ProdCanMinCompra.Visible = True
            End If

        End If

        AddHandler Chk_Bloqueado.CheckValueChanged, AddressOf Sb_ChkxBloqueadaVyC
        AddHandler Chk_Bloqencom.CheckValueChanged, AddressOf Sb_ChkxBlocCompras

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
        AddHandler Chk_Libera_NVV.CheckedChanged, AddressOf Chk_Libera_NVV_CheckedChanged

        Btn_Direcciones_Despachos.Visible = True

    End Sub

    Private Sub Sb_Llenar_Grilla_Ctas_Ctes()

        Consulta_sql = "Select KOEN,TIPOPAGO,EMISOR,CUENTA,RUT,NORUT,BLOQUEADA,Cast(Case When BLOQUEADA = 0 Then 1 Else 0 End As Bit) As Activo,SUCURSAL," &
               "TIPOPAGO +' - '+Isnull((Select top 1 NOKOENDP From TABENDP " &
               "Where KOENDP = EMISOR And EMPRESA = '" & ModEmpresa & "' And TIDPEN = SUBSTRING(TIPOPAGO,1,2)),'') As BANCO" & vbCrLf &
               "From MAEENCTA" & vbCrLf &
               "Where KOEN = '" & Txt_Koen.Text & "'"

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
                        Where KOEN = '" & Txt_Koen.Text & "'"

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

            .Columns("NAMETO").HeaderText = "Nombre Destinatario"
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

    Private Sub BtnxGrabar_Click(sender As System.Object, e As System.EventArgs) Handles BtnxGrabar.Click

        Dim _Koen As String = Txt_Koen.Text
        Dim _Suen As String = Txt_Suen.Text

        Me.Refresh()

        If CrearEntidad Then

            If String.IsNullOrEmpty(Txt_Koen.Text.Trim) Then

                MessageBoxEx.Show(Me, "Código de entidad vacio, debe completar datos", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TabControl1.SelectedTabIndex = 0
                Txt_Koen.Focus()
                Return

            End If

            Dim _EncuetraEnt As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEEN", "KOEN = '" & Txt_Koen.Text & "' And SUEN = '" & Txt_Suen.Text & "'"))

            If _EncuetraEnt Then

                MessageBoxEx.Show(Me, "¡Entidad ya existe!" & vbCrLf &
                              "No es posible grabar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Koen.SelectAll()
                Txt_Suen.SelectAll()
                Txt_Koen.Focus()

                Exit Sub

            End If

            If String.IsNullOrEmpty(Cmb_Tiposuc.Text.Trim) Then
                MessageBoxEx.Show("Falta el tipo de entidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TabControl1.SelectedTabIndex = 0
                Cmb_Tiposuc.Focus()
                Return
            End If

            If String.IsNullOrEmpty(Txt_Nokoen.Text.Trim) Then
                MessageBoxEx.Show("Faltan la razón social", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TabControl1.SelectedTabIndex = 0
                Txt_Nokoen.Focus()
                Return
            End If

            If String.IsNullOrEmpty(Txt_Dien.Text.Trim) Then
                MessageBoxEx.Show("Faltan la dirección", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TabControl1.SelectedTabIndex = 0
                Txt_Dien.Focus()
                Return
            End If

            If String.IsNullOrEmpty(Txt_Gien.Text.Trim) Then
                MessageBoxEx.Show("Faltan el giro", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TabControl1.SelectedTabIndex = 0
                Txt_Gien.Focus()
                Return
            End If

            If String.IsNullOrEmpty(Txt_Foen.Text.Trim) Then
                MessageBoxEx.Show("Falta el teléfono de la entidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TabControl1.SelectedTabIndex = 0
                Txt_Foen.Focus()
                Return
            End If

            If IsNothing(Cl_Maeen.Paen) Then Cl_Maeen.Paen = String.Empty
            If IsNothing(Cl_Maeen.Cien) Then Cl_Maeen.Cien = String.Empty
            If IsNothing(Cl_Maeen.Cmen) Then Cl_Maeen.Cmen = String.Empty

            If String.IsNullOrEmpty(Cl_Maeen.Paen.Trim) Or String.IsNullOrEmpty(Cl_Maeen.Cien) Or String.IsNullOrEmpty(Cl_Maeen.Cmen.Trim) Then
                MessageBoxEx.Show("Faltan pais, ciudad o comuna", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TabControl1.SelectedTabIndex = 0
                Call Btn_Buscar_Comuna_Click(Nothing, Nothing)
            End If

            If String.IsNullOrEmpty(Cl_Maeen.Paen.Trim) Or String.IsNullOrEmpty(Cl_Maeen.Cien.Trim) Or String.IsNullOrEmpty(Cl_Maeen.Cmen.Trim) Then Return

        End If

        If Not String.IsNullOrEmpty(Txt_Email.Text) Then
            If Not Fx_Validar_Email(Txt_Email.Text) Then
                MessageBoxEx.Show(Me, "el correo de Email [" & Txt_Email.Text & "] no es una cuenta de correos valida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TabControl1.SelectedTabIndex = 0
                Txt_Email.Focus()
                Return
            End If
        End If

        If Not String.IsNullOrEmpty(Txt_Emailcomer.Text) Then
            If Not Fx_Validar_Email(Txt_Emailcomer.Text) Then
                MessageBoxEx.Show(Me, "el correo de Email2 [" & Txt_Emailcomer.Text & "] no es una cuenta de correos valida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TabControl1.SelectedTabIndex = 0
                Txt_Emailcomer.Focus()
                Return
            End If
        End If

        If _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Entidades", "EmailCompras") Then
            If Not String.IsNullOrEmpty(Txt_EmailCompras.Text) Then
                Txt_EmailCompras.Text = Txt_EmailCompras.Text.Trim
                If Not Fx_Validar_Email(Txt_EmailCompras.Text) Then
                    MessageBoxEx.Show(Me, "el correo de Email Compras [" & Txt_EmailCompras.Text & "] no es una cuenta de correos valida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    TabControl1.SelectedTabIndex = 5
                    Txt_EmailCompras.Focus()
                    Return
                End If
            End If
        End If

        If _Existe_Tbl_Entidades_Bakapp Then

            Dim _CRTO As Double = Txt_Crto.Text
            Dim _CRSD As Double = Txt_Crsd.Text
            Dim _CRCH As Double = Txt_Crch.Text
            Dim _CRLT As Double = Txt_Crlt.Text
            Dim _CRPA As Double = Txt_Crpa.Text

            Dim _Suma As Double = _CRTO + _CRSD + _CRCH + _CRLT + _CRPA

            If Chk_Libera_NVV.Checked And _Suma > 0 Then

                TabControl1.SelectedTabIndex = 3

                MessageBoxEx.Show(Me, "No puede dejar Libera NVV en [SI] cuando la entidad tiene créditos asociados" & vbCrLf &
                                      "Para poder dejar en [SI] debe dejar todos los créditos en cero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TabControl1.SelectedTabIndex = 3
                Return

            End If

        End If

        TabControl1.Tabs(2).Visible = False

        Txt_Rten.Text = Replace(Txt_Rten.Text, ".", "")
        Dim Rut(1) As String

        Rut = Split(Txt_Rten.Text, "-")

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        If _Crear_Sucursal Then

            Dim _Existe_Suc As Boolean

            _Existe_Suc = CBool(_Sql.Fx_Cuenta_Registros("MAEEN", "KOEN = '" & Txt_Koen.Text & "' And SUEN = '" & Txt_Suen.Text & "'"))

            If _Existe_Suc Then
                MessageBoxEx.Show(Me, "La sucursal con el código " & Txt_Suen.Text & " ya existe para esta entidad", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        End If

        Dim cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(cn2)

        Try
            myTrans = cn2.BeginTransaction()

            If CrearEntidad Then

                If _Sql.Fx_Cuenta_Registros("MAEEN", "KOEN = '" & Txt_Koen.Text & "'") > 1 Then TipoSuc = "S"

                Consulta_sql = BkSpecialPrograms.RecursosEnt.Insertar_Entidad_MAEEN.ToString
                Consulta_sql = Replace(Consulta_sql, "#KOEN#", Txt_Koen.Text)
                Consulta_sql = Replace(Consulta_sql, "#TIEN#", Cmb_Tiposuc.SelectedValue)
                Consulta_sql = Replace(Consulta_sql, "#RTEN#", Trim(numero_(Rut(0), 8)))
                Consulta_sql = Replace(Consulta_sql, "#SUEN#", _Suen)

                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Dim _Idmaeen

                Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
                Comando.Transaction = myTrans
                Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
                While dfd1.Read()
                    _Idmaeen = dfd1("Identity")
                End While
                dfd1.Close()

                Comando = New SqlCommand("SELECT * From MAEEN Where IDMAEEN = " & _Idmaeen, cn2)
                Comando.Transaction = myTrans
                dfd1 = Comando.ExecuteReader()
                While dfd1.Read()
                    If Txt_Suen.Text <> dfd1("SUEN") Then
                        _Suen = dfd1("SUEN")
                        Exit While
                    End If
                End While
                dfd1.Close()


                Consulta_sql = "DELETE FROM MAEENCON WHERE KOEN=''-- tabla de contactos por empresa" & vbCrLf &
                               "DELETE FROM MAEENPRO WHERE KOEN='" & _Koen & "' AND SUEN='" & _Suen & "' -- Tabla de proyectos por empresa" & vbCrLf &
                               "INSERT INTO MAEENPRO (KOEN,SUEN,PROYECTO) VALUES ('" & _Koen & "','" & _Suen & "','') " & vbCrLf &
                               "DELETE FROM MAEENCTA WHERE KOEN='" & _Koen & "' --  Tabla de cuentas corrientes asociadas a la entidad"
                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()


            End If

            Dim Zona = Cmb_Zoen.SelectedValue

            Consulta_sql = BkSpecialPrograms.RecursosEnt.Actualiza_Entidad_MAEEN

            Consulta_sql = Replace(Consulta_sql, "#KOEN#", Txt_Koen.Text)
            Consulta_sql = Replace(Consulta_sql, "#TIEN#", UCase(Trim(Cmb_Tiposuc.SelectedValue)))
            Consulta_sql = Replace(Consulta_sql, "#RTEN#", UCase(Trim(numero_(Rut(0), 8))))
            Consulta_sql = Replace(Consulta_sql, "#SUEN#", _Suen)
            Consulta_sql = Replace(Consulta_sql, "#TIPOSUC#", TipoSuc)
            Consulta_sql = Replace(Consulta_sql, "#NOKOEN#", UCase(Trim(Txt_Nokoen.Text)))
            Consulta_sql = Replace(Consulta_sql, "#SIEN#", UCase(Trim(Txt_Sien.Text)))
            Consulta_sql = Replace(Consulta_sql, "#GIEN#", UCase(Trim(Txt_Gien.Text)))
            Consulta_sql = Replace(Consulta_sql, "#EMAIL#", Txt_Email.Text)
            Consulta_sql = Replace(Consulta_sql, "#EMAILCOMER#", Txt_Emailcomer.Text)
            Consulta_sql = Replace(Consulta_sql, "#PAEN#", Cl_Maeen.Paen)
            Consulta_sql = Replace(Consulta_sql, "#CIEN#", Cl_Maeen.Cien)
            Consulta_sql = Replace(Consulta_sql, "#CMEN#", Cl_Maeen.Cmen)
            Consulta_sql = Replace(Consulta_sql, "#DIEN#", UCase(Trim(Txt_Dien.Text)))
            Consulta_sql = Replace(Consulta_sql, "#ZOEN#", Zona)
            Consulta_sql = Replace(Consulta_sql, "#FOEN#", UCase(Trim(Txt_Foen.Text)))
            Consulta_sql = Replace(Consulta_sql, "#FAEN#", UCase(Trim(Txt_Faen.Text)))
            Consulta_sql = Replace(Consulta_sql, "#FOEN#", UCase(Trim(Txt_Foen.Text)))
            Consulta_sql = Replace(Consulta_sql, "#CPOSTAL#", Txt_Cpostal.Text)
            Consulta_sql = Replace(Consulta_sql, "#NOKOENAMP#", Txt_Nokoenamp.Text)
            Consulta_sql = Replace(Consulta_sql, "#KOFUEN#", Cmb_Kofuen.SelectedValue)
            Consulta_sql = Replace(Consulta_sql, "#COBRADOR#", Cmb_Cobrador.SelectedValue)
            Consulta_sql = Replace(Consulta_sql, "#LCEN#", "TABPP" & Cmb_Lcen.SelectedValue)
            Consulta_sql = Replace(Consulta_sql, "#LVEN#", "TABPP" & Cmb_Lven.SelectedValue)
            Consulta_sql = Replace(Consulta_sql, "#RUEN#", Cmb_Ruen.SelectedValue)
            Consulta_sql = Replace(Consulta_sql, "#TIPOEN#", Cmb_Tien.SelectedValue)
            Consulta_sql = Replace(Consulta_sql, "#ACTIEN#", Cmb_Actien.SelectedValue)
            Consulta_sql = Replace(Consulta_sql, "#TAMAEN#", Cmb_Tamaen.SelectedValue)
            Consulta_sql = Replace(Consulta_sql, "#TRANSPOEN#", Cmb_Transpoen.SelectedValue)
            Consulta_sql = Replace(Consulta_sql, "#OBEN#", UCase(Trim(TxtxObservacionesDoc.Text)))

            Consulta_sql = Replace(Consulta_sql, "#CRTO#", De_Num_a_Tx_01(Txt_Crto.Tag, False, 5))
            Consulta_sql = Replace(Consulta_sql, "#CRSD#", De_Num_a_Tx_01(Txt_Crsd.Tag, False, 5))
            Consulta_sql = Replace(Consulta_sql, "#CRCH#", De_Num_a_Tx_01(Txt_Crch.Tag, False, 5))
            Consulta_sql = Replace(Consulta_sql, "#CRLT#", De_Num_a_Tx_01(Txt_Crlt.Tag, False, 5))
            Consulta_sql = Replace(Consulta_sql, "#CRPA#", De_Num_a_Tx_01(Txt_Crpa.Tag, False, 5))

            Consulta_sql = Replace(Consulta_sql, "#NUVECR#", De_Num_a_Tx_01(Txt_Nuvecre.Tag, False, 5))
            Consulta_sql = Replace(Consulta_sql, "#DIPRVE#", De_Num_a_Tx_01(Txt_Dipreve.Tag, False, 5))
            Consulta_sql = Replace(Consulta_sql, "#DIASVENCI#", De_Num_a_Tx_01(Txt_Diasvenci.Tag, False, 5))
            Consulta_sql = Replace(Consulta_sql, "#DIMOPER#", De_Num_a_Tx_01(Txt_Dimoper.Tag, False, 5))

            Consulta_sql = Replace(Consulta_sql, "#FEULTR#", Format(Now.Date, "yyyyMMdd"))
            Consulta_sql = Replace(Consulta_sql, "#FECREEN#", Format(Dtp_Fecreen.Value, "yyyyMMdd"))

            Dim _Fevecren As String

            If FormatDateTime(Dtp_Fevecren.Value, DateFormat.ShortDate) = #01-01-0001# Or IsNothing(Dtp_Fevecren.Value) Or IsDBNull(Dtp_Fevecren.Value) Then
                _Fevecren = "Null"
            Else
                _Fevecren = "'" & Format(Dtp_Fevecren.Value, "yyyyMMdd") & "'"
            End If

            Consulta_sql = Replace(Consulta_sql, "'#FEVECREN#'", _Fevecren)

            Consulta_sql = Replace(Consulta_sql, "#CPEN#", UCase(Trim(Txt_Cpen.Text)))

            Consulta_sql = Replace(Consulta_sql, "#NVVPIDEPIE#", Val(Chk_Nvvpidepie.Checked))
            Consulta_sql = Replace(Consulta_sql, "#POPICR#", De_Num_a_Tx_01(Txt_Popicr.Tag, False, 5))

            Consulta_sql = Replace(Consulta_sql, "#BLOQUEADO#", Val(Chk_Bloqueado.Checked))
            Consulta_sql = Replace(Consulta_sql, "#BLOQENCOM#", Val(Chk_Bloqencom.Checked))

            Consulta_sql = Replace(Consulta_sql, "#PREFEN#", Val(Chk_Prefen.Checked))
            Consulta_sql = Replace(Consulta_sql, "#NOTRAEDEUD#", Val(Chk_Notraedeud.Checked))

            Consulta_sql = Replace(Consulta_sql, "#OCCOBLI#", Val(Chk_Occobli.Checked))
            Consulta_sql = Replace(Consulta_sql, "#FEREFAUTO#", Val(Chk_Ferefauto.Checked))

            Consulta_sql = Replace(Consulta_sql, "#MOCTAEN#", CmbxMoneda.SelectedValue)

            Dim _Dia_Cobra As String = Fx_DiaCobra()
            'Cl_Maeen.Diacobra = Fx_DiaCobra()
            Consulta_sql = Replace(Consulta_sql, "#DIACOBRA#", _Dia_Cobra)

            '--CUENTABCO =  Nro Cta Cte  (20)
            '--KOENDPEN  =  Código del banco (13)
            '--SUENDPEN  =  Plaza o sucursal bancaria (3)
            '--ACTECOBCO =  Código de actividad economica   (10)

            Consulta_sql = Replace(Consulta_sql, "#CUENTABCO#", Txt_Cuentabco.Text)
            Consulta_sql = Replace(Consulta_sql, "#KOENDPEN#", Txt_Koendpen.Text)
            Consulta_sql = Replace(Consulta_sql, "#SUENDPEN#", Txt_Suendpen.Text)
            Consulta_sql = Replace(Consulta_sql, "#ACTECOBCO#", Txt_Actecobco.Text)

            Consulta_sql = Replace(Consulta_sql, "#RUTALUN#", Input_Rutalun.Value)
            Consulta_sql = Replace(Consulta_sql, "#RUTAMAR#", Input_Rutamar.Value)
            Consulta_sql = Replace(Consulta_sql, "#RUTAMIE#", Input_Rutamie.Value)
            Consulta_sql = Replace(Consulta_sql, "#RUTAJUE#", Input_Rutajue.Value)
            Consulta_sql = Replace(Consulta_sql, "#RUTAVIE#", Input_Rutavie.Value)
            Consulta_sql = Replace(Consulta_sql, "#RUTASAB#", Input_Rutasab.Value)
            Consulta_sql = Replace(Consulta_sql, "#RUTADOM#", Input_Rutadom.Value)

            Consulta_sql = Replace(Consulta_sql, "#RECEPELECT#", Val(Chk_Recepelect.Checked))

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


            If CrearEntidad Then

                _CreaNuevaEntidad = True

            ElseIf EditarEntidad Then

                If Chk_Bloqueado.Checked <> _BlocDesb_VtayCmp Then
                    Consulta_sql += vbCrLf & vbCrLf & _Sql_BlocDesb_VtayCmp
                End If

                If Chk_Bloqencom.Checked <> _BlocDesb_Compra Then
                    Consulta_sql += vbCrLf & vbCrLf & _Sql_BlocDesb_Compra
                End If

                _Reg = CBool(_Sql.Fx_Cuenta_Registros("INFORMATION_SCHEMA.COLUMNS",
                                          "COLUMN_NAME = 'FEMOEN' AND TABLE_NAME = 'MAEEN'"))
                If _Reg Then Consulta_sql += "Update MAEEN Set FEMOEN = Getdate() WHERE KOEN=@koen AND SUEN=@suen" & vbCrLf

                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            Consulta_sql = "Delete MAEENCTA Where KOEN = '" & Txt_Koen.Text & "'" & vbCrLf & vbCrLf

            For Each _Fila As DataRow In _Tbl_Maeencta.Rows

                If _Fila.RowState <> DataRowState.Deleted Then

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

                Consulta_sql = "Delete MAEENMAIL Where KOEN = '" & Txt_Koen.Text & "'" & vbCrLf & vbCrLf

                For Each _Fila As DataRow In _Tbl_Maeenmail.Rows

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

                With Cl_Entidades

                    .EmailCompras = Txt_EmailCompras.Text
                    .Libera_NVV = Chk_Libera_NVV.Checked
                    .FacAuto = Chk_FacAuto.Checked
                    .RevFincred = Chk_RevFincred.Checked
                    .MontoMinCompra = Txt_MontoMinCompra.Tag
                    .NoResMtoMinComAsCompraAuto = Chk_NoResMtoMinComAsCompraAuto.Checked

                    If _CreaNuevaEntidad Then

                        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Entidades Where CodEntidad = '" & _Koen & "' And CodSucEntidad = '" & _Suen & "'"
                        Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Entidades (CodEntidad,CodSucEntidad,Libera_NVV) Values ('" & _Koen & "','" & _Suen & "',0)"
                        Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                    End If

                    '.FechaInscripPuntos = NuloPorNro(.FechaInscripPuntos, #01-01-0001#)

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Entidades Set " & vbCrLf &
                                   "Libera_NVV = " & Convert.ToInt32(.Libera_NVV) & vbCrLf &
                                   ",FacAuto = " & Convert.ToInt32(.FacAuto) & vbCrLf &
                                   ",RevFincred = " & Convert.ToInt32(.RevFincred) & vbCrLf &
                                   ",EmailCompras = '" & .EmailCompras & "'" & vbCrLf &
                                   ",MontoMinCompra = " & .MontoMinCompra & vbCrLf &
                                   ",NoResMtoMinComAsCompraAuto = " & Convert.ToInt32(.NoResMtoMinComAsCompraAuto) & vbCrLf &
                                   "Where CodEntidad = '" & .CodEntidad & "' And CodSucEntidad = '" & .CodSucEntidad & "'"

                    Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                    If .JuntaPuntos Then

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Entidades Set " & vbCrLf &
                                       "JuntaPuntos = " & Convert.ToInt32(.JuntaPuntos) & vbCrLf &
                                       ",EmailPuntos = '" & .EmailPuntos.Trim & "'" & vbCrLf &
                                       ",FechaInscripPuntos = '" & Format(.FechaInscripPuntos, "yyyyMMdd") & "'" & vbCrLf &
                                       "Where CodEntidad = '" & .CodEntidad & "' And CodSucEntidad = '" & .CodSucEntidad & "'"

                    End If

                End With

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

        Dim _Diacobra As String

        If Chk_Lunes.Checked Then
            _Diacobra += "X"
        Else
            _Diacobra += " "
        End If

        If Chk_Martes.Checked Then
            _Diacobra += "X"
        Else
            _Diacobra += " "
        End If

        If Chk_Miercoles.Checked Then
            _Diacobra += "X"
        Else
            _Diacobra += " "
        End If

        If Chk_Jueves.Checked Then
            _Diacobra += "X"
        Else
            _Diacobra += " "
        End If

        If Chk_Viernes.Checked Then
            _Diacobra += "X"
        Else
            _Diacobra += " "
        End If

        If Chk_Sabado.Checked Then
            _Diacobra += "X"
        Else
            _Diacobra += " "
        End If

        If Chk_Domingo.Checked Then
            _Diacobra += "X"
        Else
            _Diacobra += " "
        End If

        Return _Diacobra

    End Function

    Sub Sb_Llena_Combos_Con_Arreglos()

        Dim _Arr_Tipo_Entidad(,) As String = {{"", ""},
                                             {"C", "Cliente"},
                                             {"P", "Proveedor"},
                                             {"A", "ambos"}}
        Sb_Llenar_Combos(_Arr_Tipo_Entidad, Cmb_Tiposuc)
        Cmb_Tiposuc.SelectedValue = "A"


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

    Sub Sb_Llena_Combo_Tipo_Pago(_Cmb As DataGridViewComboBoxColumn)

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

    Private Sub TxtxRazonSocial_TextChanged(sender As System.Object, e As System.EventArgs) Handles Txt_Nokoen.TextChanged
        Txt_Nokoenamp.Text = Txt_Nokoen.Text
    End Sub

    Private Sub TxtxRut_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles Txt_Rten.Validating

        Dim _Rut As String

        If EditarEntidad Then

            _Rut = Cl_Maeen.RTEN.Trim & "-" & RutDigito(Cl_Maeen.RTEN.Trim) '_RowEntidad.Item("RTEN").ToString.Trim & "-" & RutDigito(_RowEntidad.Item("RTEN").ToString.Trim)

            If _Rut = Txt_Rten.Text Then
                Return
            End If

        End If

        If String.IsNullOrEmpty(Trim(Txt_Rten.Text)) Then
            MessageBoxEx.Show(Me, "El Rut no puede estar vacio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            BtnxGrabar.Enabled = False
            Return
        End If

        Txt_Rten.Text = Replace(Txt_Rten.Text, ".", "")
        Dim Rut(1) As String
        Rut = Split(Txt_Rten.Text, "-")
        Dim Rt = numero_(Rut(0), 8)

        If Not VerificaDigito(Txt_Rten.Text) Then
            MessageBoxEx.Show(Me, "Rut invalido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Rten.SelectAll()
            Txt_Rten.Focus()
            e.Cancel = True
            BtnxGrabar.Enabled = False
            Return
        Else
            Txt_Rten.Text = Rt & "-" & Rut(1)
            BtnxGrabar.Enabled = True
        End If

        If Rt = Trim(Txt_Koen.Text) Then
            BtnxGrabar.Enabled = True
        Else
            Dim Nro As String = "CfEnt005"
            If Not Fx_Tiene_Permiso(Me, Nro) Then
                MessageBoxEx.Show(Me, "El código de la entidad es distinto al Rut" & vbCrLf &
                                  "Recuerde que los Rut de menos de 10.000.000 debe anteponer un 0 para rellenar",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                If EditarEntidad Then
                    Txt_Rten.Text = _Rut
                Else
                    Txt_Rten.Text = String.Empty
                    BtnxGrabar.Enabled = False
                    Txt_Rten.Focus()
                End If

            End If

        End If

    End Sub

    Private Sub TxtxSucursal_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles Txt_Suen.Validating


        Dim EncuetraEnt As Integer = _Sql.Fx_Cuenta_Registros("MAEEN", "KOEN = '" & Txt_Koen.Text & "' And SUEN = '" & Txt_Suen.Text & "'")

        If EncuetraEnt > 0 Then

            MessageBoxEx.Show(Me, "Entidad/Sucursal ya existe." & vbCrLf &
                              "Digite otro código de sucursal", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Txt_Suen.SelectAll()

            Return

        End If

    End Sub

    Private Sub TxtxRazonSocial_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles Txt_Nokoen.Validating
        If String.IsNullOrEmpty(Trim(Txt_Nokoen.Text)) Then
            MessageBoxEx.Show("La razón social no puede estar vacía", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If
    End Sub

    Private Sub TxtxDireccion_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles Txt_Dien.Validating
        If String.IsNullOrEmpty(Trim(Txt_Dien.Text)) Then
            MessageBoxEx.Show("La dirección no puede estar vacía", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If
    End Sub

    Private Sub TxtxGiro_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles Txt_Gien.Validating
        If String.IsNullOrEmpty(Trim(Txt_Gien.Text)) Then
            MessageBoxEx.Show("El Giro no puede estar vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        If Len(Trim(Txt_Gien.Text)) < 10 Then
            MessageBoxEx.Show("El Giro es sospechoso", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If

    End Sub

    Private Sub BtnModVendedor_Click(sender As System.Object, e As System.EventArgs) Handles BtnModVendedor.Click
        Cmb_Kofuen.Enabled = Fx_Tiene_Permiso(Me, "CfEnt006")
        BtnModVendedor.Enabled = Not Cmb_Kofuen.Enabled
    End Sub

    Private Sub BtnModListas_Click(sender As System.Object, e As System.EventArgs) Handles BtnModListas.Click
        Cmb_Lcen.Enabled = Fx_Tiene_Permiso(Me, "CfEnt008")
        Cmb_Lven.Enabled = Cmb_Lcen.Enabled
        BtnModListas.Enabled = Not Cmb_Lcen.Enabled
    End Sub

    Private Sub BtnModCobrador_Click(sender As System.Object, e As System.EventArgs) Handles BtnModCobrador.Click
        Cmb_Cobrador.Enabled = Fx_Tiene_Permiso(Me, "CfEnt007")
        BtnModCobrador.Enabled = Not Cmb_Cobrador.Enabled
    End Sub

    Private Sub BtnModCredito_Click(sender As System.Object, e As System.EventArgs) Handles BtnModCredito.Click

        Dim _Enable As Boolean = Fx_Tiene_Permiso(Me, "CfEnt009")

        Txt_Crch.Enabled = _Enable
        Txt_Crlt.Enabled = _Enable
        Txt_Crpa.Enabled = _Enable
        Txt_Crsd.Enabled = _Enable
        Txt_Crto.Enabled = _Enable

        Txt_Nuvecre.Enabled = _Enable
        Txt_Dipreve.Enabled = _Enable
        Txt_Diasvenci.Enabled = _Enable
        Txt_Dimoper.Enabled = _Enable

        Chk_Libera_NVV.Enabled = _Enable

        If _Enable Then Txt_Crto.Focus()

    End Sub

    Public Function Fx_Llenar_Entidad(_Koen As String, _Suen As String) As Boolean

        Try

            Dim _Cl_Entidad As New Cl_Entidades

            Cl_Maeen = _Cl_Entidad.Fx_Llenar_Maeen(_Koen, _Suen)

            If IsNothing(Cl_Maeen) Then
                MessageBoxEx.Show(Me, "Entidad no existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If

            With Cl_Maeen

                Txt_Koen.Text = _Koen
                Txt_Suen.Text = _Suen
                TipoSuc = .TIPOSUC ' _RowEntidad.Item("TIPOSUC")

                Try
                    Txt_Rten.Text = .RTEN.ToString.Trim & "-" & RutDigito(.RTEN).ToString.Trim ' Trim(_RowEntidad.Item("RTEN")) & "-" & Trim(RutDigito(_RowEntidad.Item("RTEN")))
                Catch ex As Exception
                    Txt_Rten.Text = .RTEN.ToString.Trim 'Trim(_RowEntidad.Item("RTEN")) '& "-" & Trim(RutDigito(_RowEntidad.Item("RTEN")))
                End Try

                Cmb_Tiposuc.SelectedValue = .TIEN
                Txt_Nokoen.Text = .NOKOEN.Trim
                Txt_Dien.Text = .DIEN.Trim
                Txt_Sien.Text = .SIEN.Trim
                Txt_Gien.Text = .GIEN.Trim
                Txt_Cpostal.Text = .CPOSTAL.Trim
                Txt_Foen.Text = .FOEN.Trim
                Txt_Faen.Text = .FAEN.Trim
                Txt_Email.Text = .EMAIL.Trim

                Try
                    Txt_Emailcomer.Text = .EMAILCOMER.Trim
                Catch ex As Exception
                    Txt_Emailcomer.Text = String.Empty
                    Txt_Emailcomer.Enabled = False
                End Try

                Consulta_sql = "Select Pa.KOPA,Pa.NOKOPA,Ci.KOCI,Ci.NOKOCI,Cm.KOCM,Cm.NOKOCM,
                        Rtrim(Ltrim(Pa.NOKOPA))+' - '+Rtrim(Ltrim(Ci.NOKOCI))+' - '+Rtrim(Ltrim(Cm.NOKOCM)) As Localidad	
                        From TABCM Cm 
                        Inner Join TABCI Ci On Ci.KOPA = Cm.KOPA And Ci.KOCI = Cm.KOCI
                        Inner Join TABPA Pa On Pa.KOPA = Cm.KOPA
                        Where Pa.KOPA = '" & .PAEN & "' And Ci.KOCI = '" & .CIEN & "' And Cm.KOCM = '" & .CMEN & "'"

                Dim _Row_Localidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _NPais As String
                Dim _NCiudad As String
                Dim _NComuna As String

                If Not IsNothing(_Row_Localidad) Then
                    _NPais = _Row_Localidad.Item("NOKOPA").ToString.Trim
                    _NCiudad = _Row_Localidad.Item("NOKOCI").ToString.Trim
                    _NComuna = _Row_Localidad.Item("NOKOCM").ToString.Trim
                End If

                Txt_Comuna.Text = _NComuna & ", " & _NCiudad & " - " & _NPais

                Btn_Buscar_Comuna.Text = "Cambiar comuna..."

                Cmb_Zoen.SelectedValue = .ZOEN.Trim ' Trim(_RowEntidad.Item("ZOEN"))
                Txt_Nokoenamp.Text = .NOKOENAMP.Trim ' Trim(_RowEntidad.Item("NOKOENAMP"))
                Cmb_Kofuen.SelectedValue = .KOFUEN.Trim ' Trim(_RowEntidad.Item("KOFUEN"))
                Cmb_Cobrador.SelectedValue = .COBRADOR.Trim ' Trim(_RowEntidad.Item("COBRADOR"))

                Dim _Lcen As String = .LCEN.Replace("TABPP", "") 'Replace(Trim(_RowEntidad.Item("LCEN")), "TABPP", "")
                Dim _Lven As String = .LVEN.Replace("TABPP", "") 'Replace(Trim(_RowEntidad.Item("LVEN")), "TABPP", "")

                Cmb_Lcen.SelectedValue = Trim(_Lcen)
                Cmb_Lven.SelectedValue = Trim(_Lven)


                Cmb_Ruen.SelectedValue = .RUEN.Trim ' Trim(_RowEntidad.Item("RUEN"))
                Cmb_Tien.SelectedValue = .TIPOEN.Trim ' Trim(_RowEntidad.Item("TIPOEN"))
                Cmb_Actien.SelectedValue = .ACTIEN.Trim ' Trim(_RowEntidad.Item("ACTIEN"))
                Cmb_Tamaen.SelectedValue = .TAMAEN.Trim ' Trim(_RowEntidad.Item("TAMAEN"))
                Cmb_Transpoen.SelectedValue = .TRANSPOEN.Trim ' Trim(_RowEntidad.Item("TRANSPOEN"))
                TxtxObservacionesDoc.Text = .OBEN.Trim ' Trim(_RowEntidad.Item("OBEN"))

                Txt_Crto.Tag = .CRTO ' _RowEntidad.Item("CRTO")
                Txt_Crsd.Tag = .CRSD ' _RowEntidad.Item("CRSD")
                Txt_Crch.Tag = .CRCH ' _RowEntidad.Item("CRCH")
                Txt_Crlt.Tag = .CRLT ' _RowEntidad.Item("CRLT")
                Txt_Crpa.Tag = .CRPA ' _RowEntidad.Item("CRPA")

                Txt_Crto.Text = FormatNumber(Txt_Crto.Tag, 0)
                Txt_Crsd.Text = FormatNumber(Txt_Crsd.Tag, 0)
                Txt_Crch.Text = FormatNumber(Txt_Crch.Tag, 0)
                Txt_Crlt.Text = FormatNumber(Txt_Crlt.Tag, 0)
                Txt_Crpa.Text = FormatNumber(Txt_Crpa.Tag, 0)

                Txt_Nuvecre.Tag = .NUVECR '_RowEntidad.Item("NUVECR")
                Txt_Dipreve.Tag = .DIPRVE ' _RowEntidad.Item("DIPRVE")
                Txt_Diasvenci.Tag = .DIASVENCI ' NuloPorNro(_RowEntidad.Item("DIASVENCI"), 0) 'NuloPorNro(_RowEntidad.Item("DIASVENCI"), 0)
                Txt_Dimoper.Tag = .DIMOPER ' _RowEntidad.Item("DIMOPER")

                Txt_Nuvecre.Text = FormatNumber(Txt_Nuvecre.Tag, 0)
                Txt_Dipreve.Text = FormatNumber(Txt_Dipreve.Tag, 0)
                Txt_Diasvenci.Text = FormatNumber(Txt_Diasvenci.Tag, 0)
                Txt_Dimoper.Text = FormatNumber(Txt_Dimoper.Tag, 0)

                Dtp_Fecreen.Value = NuloPorNro(.FECREEN, Now.Date) 'NuloPorNro(_RowEntidad.Item("FECREEN"), Now.Date)
                Dtp_Fevecren.Value = NuloPorNro(.FEVECREN, #01-01-0001#) 'NuloPorNro(_RowEntidad.Item("FEVECREN"), Nothing)

                Txt_Cpen.Text = .CPEN.Trim 'Trim(_RowEntidad.Item("CPEN"))

                Chk_Bloqueado.Checked = .BLOQUEADO ' _RowEntidad.Item("BLOQUEADO")
                Chk_Bloqencom.Checked = .BLOQENCOM ' _RowEntidad.Item("BLOQENCOM")
                CmbxMoneda.SelectedValue = .MOCTAEN ' _RowEntidad.Item("MOCTAEN")

                Chk_Recepelect.Checked = .RECEPELECT ' _RowEntidad.Item("RECEPELECT")
                Chk_Ferefauto.Checked = .FEREFAUTO ' _RowEntidad.Item("FEREFAUTO")
                Chk_Notraedeud.Checked = .NOTRAEDEUD ' _RowEntidad.Item("NOTRAEDEUD")
                Chk_Prefen.Checked = .PREFEN ' _RowEntidad.Item("PREFEN")
                Chk_Occobli.Checked = .OCCOBLI ' _RowEntidad.Item("OCCOBLI")

                Chk_Nvvpidepie.Checked = .NVVPIDEPIE ' _RowEntidad.Item("NVVPIDEPIE")

                Txt_Popicr.Tag = .POPICR ' _RowEntidad.Item("POPICR")
                Txt_Popicr.Text = FormatNumber(Txt_Popicr.Tag, 0)

                '-- DIACOBRA CON EXISTE EN LA TABLA MAEEN

                Dim _DiaCobra As String = .DIACOBRA ' 'NuloPorNro(_RowEntidad.Item("DIACOBRA"), "")

                If Mid(_DiaCobra, 1, 1) = "X" Then Chk_Lunes.Checked = True
                If Mid(_DiaCobra, 2, 1) = "X" Then Chk_Martes.Checked = True
                If Mid(_DiaCobra, 3, 1) = "X" Then Chk_Miercoles.Checked = True
                If Mid(_DiaCobra, 4, 1) = "X" Then Chk_Jueves.Checked = True
                If Mid(_DiaCobra, 5, 1) = "X" Then Chk_Viernes.Checked = True
                If Mid(_DiaCobra, 6, 1) = "X" Then Chk_Sabado.Checked = True
                If Mid(_DiaCobra, 7, 1) = "X" Then Chk_Domingo.Checked = True

                Txt_Cuentabco.Text = .CUENTABCO.Trim ' _RowEntidad.Item("CUENTABCO").ToString.Trim             '--CUENTABCO =  Nro Cta Cte  (20)
                Txt_Koendpen.Text = .KOENDPEN.Trim ' _RowEntidad.Item("KOENDPEN").ToString.Trim           '--KOENDPEN  =  Código del banco (13)
                Txt_Suendpen.Text = .SUENDPEN.Trim ' _RowEntidad.Item("SUENDPEN").ToString.Trim         '--SUENDPEN  =  Plaza o sucursal bancaria (3)
                Txt_Actecobco.Text = .ACTECOBCO.Trim ' _RowEntidad.Item("ACTECOBCO").ToString.Trim  '--ACTECOBCO =  Código de actividad economica   (10)

                Txt_Nacionen.Text = .NACIONEN.Trim ' _RowEntidad.Item("NACIONEN").ToString.Trim
                Txt_Profecen.Text = .PROFECEN.Trim ' _RowEntidad.Item("PROFECEN").ToString.Trim
                Txt_Dirparen.Text = .DIRPAREN.Trim ' _RowEntidad.Item("DIRPAREN").ToString.Trim
                Dtp_Fecnacen.Value = NuloPorNro(Cl_Maeen.FECNACEN, #01-01-0001#) ' NuloPorNro(_RowEntidad.Item("FECNACEN"), Nothing)
                Cmb_Estciven.SelectedValue = .ESTCIVEN ' _RowEntidad.Item("ESTCIVEN")
                Cmb_Sexoen.SelectedValue = .SEXOEN ' _RowEntidad.Item("SEXOEN")
                Cmb_Relacien.SelectedValue = .RELACIEN ' _RowEntidad.Item("RELACIEN")
                Txt_Conyugen.Text = .CONYUGEN ' _RowEntidad.Item("CONYUGEN").ToString.Trim
                Txt_Rutconen.Text = .RUTCONEN.Trim ' _RowEntidad.Item("RUTCONEN").ToString.Trim
                Rutsocen.Text = .RUTSOCEN.Trim ' _RowEntidad.Item("RUTSOCEN").ToString.Trim
                Txt_Anexen1.Text = .ANEXEN1.Trim ' _RowEntidad.Item("ANEXEN1").ToString.Trim
                Txt_Anexen2.Text = .ANEXEN2.Trim ' _RowEntidad.Item("ANEXEN2").ToString.Trim
                Txt_Anexen3.Text = .ANEXEN3.Trim ' _RowEntidad.Item("ANEXEN3").ToString.Trim

                Input_Rutalun.Value = .RUTALUN ' NuloPorNro(_RowEntidad.Item("RUTALUN"), 0)
                Input_Rutamar.Value = .RUTAMAR ' NuloPorNro(_RowEntidad.Item("RUTAMAR"), 0)
                Input_Rutamie.Value = .RUTAMIE ' NuloPorNro(_RowEntidad.Item("RUTAMIE"), 0)
                Input_Rutajue.Value = .RUTAJUE ' NuloPorNro(_RowEntidad.Item("RUTAJUE"), 0)
                Input_Rutavie.Value = .RUTAVIE ' NuloPorNro(_RowEntidad.Item("RUTAVIE"), 0)
                Input_Rutasab.Value = .RUTASAB ' NuloPorNro(_RowEntidad.Item("RUTASAB"), 0)
                Input_Rutadom.Value = .RUTADOM ' NuloPorNro(_RowEntidad.Item("RUTADOM"), 0)

            End With

            If _Existe_Tbl_Entidades_Bakapp Then

                'Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Entidades where CodEntidad = '" & _Koen & "' And CodSucEntidad = '" & _Suen & "'"
                'Dim _Row_Entidades As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Cl_Entidades = _Cl_Entidad.Fx_Llenar_Zw_Entidades(_Koen, _Suen)

                If IsNothing(Cl_Entidades) Then

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Entidades (CodEntidad,CodSucEntidad,Libera_NVV) Values ('" & _Koen & "','" & _Suen & "',0)"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    Cl_Entidades = _Cl_Entidad.Fx_Llenar_Zw_Entidades(_Koen, _Suen)

                End If

                With Cl_Entidades

                    Chk_Libera_NVV.Checked = .Libera_NVV ' _Row_Entidades.Item("Libera_NVV")
                    Chk_FacAuto.Checked = .FacAuto ' _Row_Entidades.Item("FacAuto")
                    Chk_RevFincred.Checked = .RevFincred ' _Row_Entidades.Item("RevFincred")

                    If _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Entidades", "EmailCompras") Then
                        Txt_EmailCompras.Text = .EmailCompras ' _Row_Entidades.Item("EmailCompras")
                    Else
                        Label31.Visible = False
                        Txt_EmailCompras.Visible = False
                    End If

                    Txt_MontoMinCompra.Tag = .MontoMinCompra ' _Row_Entidades.Item("MontoMinCompra")
                    Txt_MontoMinCompra.Text = FormatNumber(Txt_MontoMinCompra.Tag, 0)

                    Chk_NoResMtoMinComAsCompraAuto.Checked = .NoResMtoMinComAsCompraAuto ' _Row_Entidades.Item("NoResMtoMinComAsCompraAuto")

                End With

            End If

            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub BtnCrearContacto_Click(sender As System.Object, e As System.EventArgs)
        Dim Fm As New Frm_Crear_Entidad_Mt_Crear_Contactos
        Fm._CodEntidad = Txt_Koen.Text
        Fm.ShowDialog(Me)
    End Sub

    Sub PresionaEnter(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub TxtxCodEntidad_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles Txt_Koen.Validating

        If String.IsNullOrEmpty(Trim(Txt_Koen.Text)) Then

            If TabControl1.SelectedTabIndex = 0 Then

                MessageBoxEx.Show(Me, "Código de entidad vacio, debe completar datos", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

            e.Cancel = True

        End If


        Dim _EncuetraEnt As Integer = _Sql.Fx_Cuenta_Registros("MAEEN", "KOEN = '" & Txt_Koen.Text & "'")

        If CBool(_EncuetraEnt) Then
            If MessageBoxEx.Show(Me, "Esta entidad ya existe en el sistema" & vbCrLf &
                                "¿Desea crear una sucursal para la entidad?",
                                "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) = Windows.Forms.DialogResult.Yes Then

                Sb_Crear_Sucursal()

            Else
                Txt_Koen.Text = String.Empty
                e.Cancel = True
            End If
        Else
            _Crear_Sucursal = False
        End If

    End Sub

    Public Sub Sb_Crear_Sucursal()

        Dim _TblEnt As DataTable

        Consulta_sql = "Select KOEN,SUEN,TIPOSUC,RTEN,NOKOEN,TIEN,GIEN FROM MAEEN" & vbCrLf &
                       "Where KOEN = '" & Txt_Koen.Text & "'" & vbCrLf &
                       "Order by TIPOSUC"

        _TblEnt = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_TblEnt.Rows.Count) Then

            Dim Rut As String = _TblEnt.Rows(0).Item("RTEN").ToString
            Txt_Rten.Text = Trim(Rut) & "-" & RutDigito(Rut)
            Txt_Rten.Enabled = False

            Dim _Carac As String = _Sql.Fx_Trae_Dato("MAEEN", "SUEN", "KOEN = '" & Txt_Koen.Text & "' Order By IDMAEEN Desc").ToString.Trim
            Dim _Digito = 2

            If Not String.IsNullOrEmpty(_Carac) Then
                _Digito = _Carac.Length
            End If

            Dim _Sucursales As Integer = _Sql.Fx_Cuenta_Registros("MAEEN", "KOEN = '" & Txt_Koen.Text & "'")
            Dim _Existe_Suc As Boolean

            Do
                _Sucursales += 1
                Txt_Suen.Text = numero_(_Sucursales, _Digito)
                _Existe_Suc = CBool(_Sql.Fx_Cuenta_Registros("MAEEN", "KOEN = '" & Txt_Koen.Text & "'" & vbCrLf &
                                           "And SUEN = '" & Txt_Suen.Text & "'"))
            Loop While (_Existe_Suc)

            'If MessageBoxEx.Show(Me, "¿Desea dejar el código de la sucursal como " & TxtxSucursal.Text & "?", "Sucursal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            '    TxtxSucursal.Text = String.Empty
            'End If

            Txt_Nokoen.Text = Trim(_TblEnt.Rows(0).Item("NOKOEN").ToString)
            Txt_Nokoenamp.Text = Trim(_TblEnt.Rows(0).Item("NOKOEN").ToString)
            Cmb_Tiposuc.SelectedValue = Trim(_TblEnt.Rows(0).Item("TIEN").ToString)
            Txt_Gien.Text = Trim(_TblEnt.Rows(0).Item("GIEN").ToString)
            Txt_Koen.Enabled = False

            If MessageBoxEx.Show(Me, "¿Confirma el código sugerido para la sucursal?" & vbCrLf & vbCrLf &
                                 "Código sugerido: " & Txt_Suen.Text, "Sucursal", MessageBoxButtons.YesNo) = DialogResult.No Then
                Txt_Suen.Focus()
            Else
                Txt_Dien.Focus()
            End If

            TipoSuc = "S"
            _Crear_Sucursal = True

        Else
            MessageBoxEx.Show(Me, "Alguien elimino la entidad", "Validación",
                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If
    End Sub

    Private Sub BtnContactosEntidad_Click(sender As System.Object, e As System.EventArgs) Handles BtnContactosEntidad.Click

        Dim Fm As New Frm_Crear_Entidad_Mt_Lista_contactos(False)
        Fm.Pro_CodEntidad = Txt_Koen.Text
        Fm.Pro_SucEntidad = Txt_Suen.Text
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub ChkxExigeNVV_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Chk_Nvvpidepie.CheckedChanged
        Txt_Popicr.Enabled = Chk_Nvvpidepie.Checked
    End Sub

    Private Sub BtnEliminarUser_Click(sender As System.Object, e As System.EventArgs) Handles BtnEliminarUser.Click
        If Fx_Eliminar_Entidad(Txt_Koen.Text, Txt_Suen.Text, Me) Then
            Elimnar = True
            Me.Close()
        End If
    End Sub

    Private Sub Btn_ComentariosCtaCte_Click(sender As System.Object, e As System.EventArgs) Handles Btn_ComentariosCtaCte.Click
        Dim Fm As New Frm_Crear_Entidad_Mt_Obs_CtaCte
        Fm.Pro_CodEntidad = Txt_Koen.Text
        Fm.Pro_SucEntidad = Txt_Suen.Text
        Fm.ShowDialog(Me)
    End Sub

    Private Sub Sb_ChkxBloqueadaVyC(sender As System.Object, e As System.EventArgs)

        Dim _Palabra As String
        Dim _BloDes As String

        If Not Chk_Bloqueado.Checked Then
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
                                "('" & Txt_Koen.Text & "','" & Txt_Suen.Text & "','" & FUNCIONARIO & "','" & Format(FechaDelServidor, "yyyyMMdd") &
                                "'," & _HoraGrab & ",'" & _Observacion & "')"

    End Sub

    Private Sub Sb_ChkxBlocCompras(sender As System.Object, e As System.EventArgs)

        Dim _Palabra As String
        Dim _BloDes As String

        If Not Chk_Bloqencom.Checked Then
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
                               "('" & Txt_Koen.Text & "','" & Txt_Suen.Text & "','" & FUNCIONARIO & "','" & Format(FechaDelServidor, "yyyyMMdd") &
                               "'," & _HoraGrab & ",'" & _Observacion & "')"


    End Sub

    Private Sub Btn_TipoEntidad_Click(sender As System.Object, e As System.EventArgs) Handles Btn_TipoEntidad.Click
        If Fx_Tiene_Permiso(Me, "Tbl00015") Then
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Tipoentidad,
                                                                 Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "TIPO DE ENTIDAD"
            Fm.ShowDialog(Me)
            Fm.Dispose()

            caract_combo(Cmb_Tien)
            Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                           "SELECT KOCARAC AS Padre,NOKOCARAC AS Hijo FROM TABCARAC WHERE KOTABLA = 'TIPOENTIDA' ORDER BY Padre"
            Cmb_Tien.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        End If
    End Sub

    Private Sub Btn_TamnoEmpresa_Click(sender As System.Object, e As System.EventArgs) Handles Btn_TamnoEmpresa.Click
        If Fx_Tiene_Permiso(Me, "Tbl00013") Then
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Tamanoempr,
                                                                  Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "TAMAÑO EMPRESA"
            Fm.ShowDialog(Me)
            Fm.Dispose()

            caract_combo(Cmb_Tamaen)
            Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                           "SELECT KOCARAC AS Padre,NOKOCARAC AS Hijo FROM TABCARAC WHERE KOTABLA = 'TAMA¥OEMPR' ORDER BY Padre"
            Cmb_Tamaen.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        End If
    End Sub

    Private Sub Btn_Rubro_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Rubro.Click
        If Fx_Tiene_Permiso(Me, "Tbl00017") Then
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Rubros,
                                                                 Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "RUBROS"
            Fm.ShowDialog(Me)
            Fm.Dispose()

            caract_combo(Cmb_Ruen)
            Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                           "SELECT KORU AS Padre,NOKORU AS Hijo FROM TABRU ORDER BY Padre"
            Cmb_Ruen.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        End If
    End Sub

    Private Sub Btn_ActividadEconomica_Click(sender As System.Object, e As System.EventArgs) Handles Btn_ActividadEconomica.Click
        If Fx_Tiene_Permiso(Me, "Tbl00012") Then
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Actividade,
                                                                 Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "ACTIVIDAD ECONOMICA"
            Fm.ShowDialog(Me)
            Fm.Dispose()

            caract_combo(Cmb_Actien)
            Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                           "SELECT KOCARAC AS Padre,NOKOCARAC AS Hijo FROM TABCARAC WHERE KOTABLA = 'ACTIVIDADE' ORDER BY Padre"
            Cmb_Actien.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)


        End If
    End Sub

    Private Sub Btn_Transportista_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Transportista.Click

        If Fx_Tiene_Permiso(Me, "") Then
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Transporte,
                                                                 Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "TRANSPORTE"
            Fm.ShowDialog(Me)
            Fm.Dispose()

            caract_combo(Cmb_Transpoen)
            Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                           "SELECT KOCARAC AS Padre,NOKOCARAC AS Hijo FROM TABCARAC WHERE KOTABLA = 'TRANSPORTE' ORDER BY Padre"
            Cmb_Transpoen.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        End If
    End Sub

    Private Sub Btn_Asociar_Marcas_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Asociar_Marcas.Click

        Dim Fm As New Frm_ProveedoresVSMarcas
        Fm.TxtCodigo.Text = Txt_Koen.Text
        Fm.Txtdescripcion.Text = Txt_Nokoen.Text

        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Anotaciones_a_la_entidad_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Anotaciones_a_la_entidad.Click

        Dim _Idmaeen As Integer = Cl_Maeen.IDMAEEN ' _RowEntidad.Item("IDMAEEN")

        Dim Fm As New Frm_Anotaciones_Ver_Anotaciones(_Idmaeen, Frm_Anotaciones_Ver_Anotaciones.Tipo_Tabla.MAEEN)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Agregar_CtaCte_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Agregar_CtaCte.Click

        Dim _Koen = Txt_Koen.Text

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

                    Lbl_Warning_Ctas.Visible = EditarEntidad
                    Img_Warning_Ctas.Visible = EditarEntidad

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

    Sub Sb_Llena_Combo_Tipo_Pago_Cell(_Cmb As DataGridViewComboBoxCell)

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

    Sub Sb_Cell_Banco(_Fila As DataGridViewRow, _Koendp As String)

        'Dim _Koendp = Trim(_Fila.Cells("BANCO").Value)
        Dim _Tidepen = _Fila.Cells("_TIPOPAGO").Value
        Dim _TipoPago = _Fila.Cells("_TIPOPAGO").FormattedValue

        Consulta_sql = "Select top 1 * From TABENDP" & vbCrLf &
                       "Where EMPRESA = '" & ModEmpresa & "' And KOENDP = '" & Trim(_Koendp) & "' And TIDPEN = '" & _Tidepen & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        _Fila.Cells("KOEN").Value = Txt_Koen.Text
        _Fila.Cells("EMISOR").Value = _Tbl.Rows(0).Item("KOENDP")
        _Fila.Cells("SUCURSAL").Value = _Tbl.Rows(0).Item("SUENDP")
        _Fila.Cells("TIPOPAGO").Value = _TipoPago

    End Sub

    Private Sub Grilla_Cuentas_CellMouseUp(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Grilla_Cuentas.CellMouseUp

        Try
            Dim _Cabeza = Grilla_Cuentas.Columns(Grilla_Cuentas.CurrentCell.ColumnIndex).Name

            If _Cabeza = "BLOQUEADO" Then
                Grilla_Cuentas.EndEdit()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Grilla_Cuentas_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
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

        Dim _NewFila As DataRow = Fx_Nueva_Linea_Notificacion(_Tbl_Maeenmail, Txt_Koen.Text, "", "", "", "", "", "", "", "", "", "", "", Date.Now)
        Dim _Aceptar As Boolean

        Dim Fm As New Frm_Crear_Entidad_Mt_Noficicaiones(_NewFila)
        Fm.ShowDialog(Me)
        _Aceptar = Fm.Aceptar
        Fm.Dispose()

        If Not _Aceptar Then

            Grilla_Maeenmail.Rows.RemoveAt(Grilla_Maeenmail.RowCount - 1)
            Lbl_Warning_Notif.Visible = EditarEntidad
            Img_Warning_Notif.Visible = EditarEntidad

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

    Sub Sb_TipoPago(_Fila As DataGridViewRow)

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

            Lbl_Warning_Notif.Visible = EditarEntidad
            Img_Warning_Notif.Visible = EditarEntidad

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

            Lbl_Warning_Notif.Visible = EditarEntidad
            Img_Warning_Notif.Visible = EditarEntidad

        End If

    End Sub

    Private Sub Btn_Direcciones_Despachos_Click(sender As Object, e As EventArgs) Handles Btn_Direcciones_Despachos.Click

        Dim Fm As New Frm_Direc_Cli_Lista(Txt_Koen.Text, Txt_Suen.Text)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Buscar_Comuna_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Comuna.Click

        Dim Fm As New Frm_PaCiCm_Lista
        Fm.ShowDialog(Me)

        If Not IsNothing(Fm.Row_Localidad) Then

            Cl_Maeen.Paen = Fm.Row_Localidad.Item("KOPA")
            Cl_Maeen.Cien = Fm.Row_Localidad.Item("KOCI")
            Cl_Maeen.Cmen = Fm.Row_Localidad.Item("KOCM")

            Dim _NPais = Fm.Row_Localidad.Item("NOKOPA")
            Dim _NCiudad = Fm.Row_Localidad.Item("NOKOCI")
            Dim _NComuna = Fm.Row_Localidad.Item("NOKOCM")

            Txt_Comuna.Text = _NComuna.Trim & ", " & _NCiudad.Trim & " - " & _NPais

        End If

        Fm.Dispose()

    End Sub


#End Region

    Private Sub Grilla_Cuentas_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Cuentas.CellDoubleClick

        Dim _Cabeza = Grilla_Cuentas.Columns(Grilla_Cuentas.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla_Cuentas.Rows(Grilla_Cuentas.CurrentRow.Index)

        Dim _Koen = Txt_Koen.Text

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

                Lbl_Warning_Ctas.Visible = EditarEntidad
                Img_Warning_Ctas.Visible = EditarEntidad

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

    Private Sub Chk_Libera_NVV_CheckedChanged(sender As Object, e As EventArgs)

        If Chk_Libera_NVV.Checked Then

            Dim _CRTO As Double = Txt_Crto.Tag
            Dim _CRSD As Double = Txt_Crsd.Tag
            Dim _CRCH As Double = Txt_Crch.Tag
            Dim _CRLT As Double = Txt_Crlt.Tag
            Dim _CRPA As Double = Txt_Crpa.Tag

            Dim _Suma = _CRTO + _CRSD + _CRCH + _CRLT + _CRPA

            If _Suma > 0 Then
                MessageBoxEx.Show(Me, "No puede dejar Libera NVV en [SI] cuando la entidad tiene créditos asociados" & vbCrLf &
                                  "Para poder dejar en [SI] debe dejar todos los créditos en cero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Chk_Libera_NVV.Checked = False
            End If

        End If

    End Sub

    Private Sub Btn_Modificar_FacAuto_Click(sender As Object, e As EventArgs) Handles Btn_Modificar_FacAuto.Click
        Chk_FacAuto.Enabled = Fx_Tiene_Permiso(Me, "CfEnt028")
        Btn_Modificar_FacAuto.Enabled = Not Chk_FacAuto.Enabled
    End Sub

    Private Sub Btn_Modificar_RevCredFincred_Click(sender As Object, e As EventArgs) Handles Btn_Modificar_RevCredFincred.Click
        Chk_RevFincred.Enabled = Fx_Tiene_Permiso(Me, "CfEnt029")
        Btn_Modificar_RevCredFincred.Enabled = Not Chk_RevFincred.Enabled
    End Sub

    Private Sub Btn_ProductosExcluidos_Click(sender As Object, e As EventArgs) Handles Btn_ProductosExcluidos.Click

        Dim Fm As New Frm_Crear_Entidad_Mt_ProdExcluidosCompra(Txt_Koen.Text, Txt_Suen.Text)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_ProdCanMinCompra_Click(sender As Object, e As EventArgs) Handles Btn_ProdCanMinCompra.Click

        Dim Fm As New Frm_Crear_Entidad_Mt_ProdCanMinXProv(Txt_Koen.Text, Txt_Suen.Text)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub


    Private Sub Btn_Cta_Eliminar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cta_Eliminar.Click

        If MessageBoxEx.Show(Me, "¿Confirma la eliminación de la cuenta?", "Eliminar cuenta",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Grilla_Cuentas.Rows.RemoveAt(Grilla_Cuentas.CurrentRow.Index)

            Lbl_Warning_Ctas.Visible = EditarEntidad
            Img_Warning_Ctas.Visible = EditarEntidad

        End If

    End Sub

    Private Sub Sb_Grilla_Cuentas_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
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

    Private Sub Btn_Puntos_Click(sender As Object, e As EventArgs) Handles Btn_Puntos.Click

        Dim _Cl_Puntos As New Cl_Puntos()
        _Cl_Puntos.Zw_PtsVta_Configuracion = _Cl_Puntos.Fx_Llenar_Zw_PtsVta_Configuracion(ModEmpresa)

        If Not _Cl_Puntos.Zw_PtsVta_Configuracion.Activo Then
            MessageBoxEx.Show(Me, "Sistema de fidelización de clientes inactivo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        With Cl_Entidades

            If .JuntaPuntos Then

                Dim Fmptos As New Frm_InformePtosClientes(Txt_Koen.Text, Txt_Suen.Text)
                Fmptos.ShowDialog(Me)
                Fmptos.Dispose()
                Return

            End If

            Dim Fm As New Frm_Crear_Entidad_Mt_Puntos
            Fm.Txt_EmailPuntos.Text = .EmailPuntos.Trim
            Fm.Chk_JuntaPuntos.Checked = .JuntaPuntos
            Fm.Dtp_FechaInscripPuntos.Value = NuloPorNro(.FechaInscripPuntos, Now.Date)
            Fm.ShowDialog(Me)

            If Fm.Aceptar Then
                .JuntaPuntos = Fm.Chk_JuntaPuntos.Checked
                .EmailPuntos = Fm.Txt_EmailPuntos.Text.Trim
                .FechaInscripPuntos = Fm.Dtp_FechaInscripPuntos.Value
            End If

            Fm.Dispose()

        End With

    End Sub

    Private Sub Sb_Grilla_Maennmail_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
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
