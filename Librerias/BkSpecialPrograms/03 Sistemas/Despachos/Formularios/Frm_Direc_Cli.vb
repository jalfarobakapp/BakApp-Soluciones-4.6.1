Imports DevComponents.DotNetBar

Public Class Frm_Direc_Cli

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id As Integer
    Dim _Row_Despacho_Cli As DataRow
    Dim _Row_Entidad As DataRow
    Dim _Grabar As Boolean

    Dim _Row_Conf_Despacho As DataRow
    Dim _Row_Transportista As DataRow

    Dim _CodPais As String
    Dim _CodCiudad As String
    Dim _CodComuna As String
    Dim _Pais As String
    Dim _Ciudad As String
    Dim _Comuna As String

    Public Property CodPais As String
        Get
            Return _CodPais
        End Get
        Set(value As String)
            _CodPais = value
        End Set
    End Property

    Public Property CodCiudad As String
        Get
            Return _CodCiudad
        End Get
        Set(value As String)
            _CodCiudad = value
        End Set
    End Property

    Public Property CodComuna As String
        Get
            Return _CodComuna
        End Get
        Set(value As String)
            _CodComuna = value
        End Set
    End Property

    Public Property Pais As String
        Get
            Return _Pais
        End Get
        Set(value As String)
            _Pais = value
        End Set
    End Property

    Public Property Ciudad As String
        Get
            Return _Ciudad
        End Get
        Set(value As String)
            _Ciudad = value
        End Set
    End Property

    Public Property Comuna As String
        Get
            Return _Comuna
        End Get
        Set(value As String)
            _Comuna = value
        End Set
    End Property

    Public Property Id As Integer
        Get
            Return _Id
        End Get
        Set(value As Integer)
            _Id = value
        End Set
    End Property

    Public Property Row_Despacho_Cli As DataRow
        Get
            Return _Row_Despacho_Cli
        End Get
        Set(value As DataRow)
            _Row_Despacho_Cli = value
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

    Public Sub New(_CodEntidad As String, _SucEntidad As String, _Id As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Row_Entidad = Fx_Traer_Datos_Entidad(_CodEntidad, _SucEntidad)

        'caract_combo(CmbxPais)
        'Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
        '               "SELECT KOPA AS Padre,NOKOPA AS Hijo FROM TABPA ORDER BY Padre" ' WHERE SEMILLA = " & Actividad
        'CmbxPais.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        'CmbxPais.Tag = ""
        'CmbxPais.SelectedValue = ""
        'CmbxCiudad.Tag = ""
        'CmbxComuna.Tag = ""

        Dim _Tbl As DataTable

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Despachos_Direcc_Cli 
                        Where Id = " & _Id
        _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

        'Btn_Modificar_Horario.Visible = CBool(_Id)

        If CBool(_Id) Then
            _Row_Despacho_Cli = _Tbl.Rows(0)
        Else
            _Row_Despacho_Cli = Fx_Nueva_Fila(_Tbl)
        End If

        Consulta_sql = "Select Empresa,Pedir_Sucursal_Retiro,Tipo_Venta_X_Defecto,Transportista_X_Defecto,
                            Isnull(Tvta.NombreTabla,'') As Nom_Tipo_Venta,Isnull(NORETI,'') As Nom_Transportista
                            From " & _Global_BaseBk & "Zw_Despachos_Configuracion 
                            Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Tvta On Tvta.Tabla = 'SIS_DESPACHO_TIPO_VENTA' And Tvta.CodigoTabla = Tipo_Venta_X_Defecto
                            Left Join TABRETI On KORETI = Transportista_X_Defecto
                            Where Empresa = '" & ModEmpresa & "'"
        _Row_Conf_Despacho = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_Conf_Despacho) Then

            Txt_Tipo_Venta.Tag = _Row_Conf_Despacho.Item("Tipo_Venta_X_Defecto")
            Txt_Tipo_Venta.Text = _Row_Conf_Despacho.Item("Nom_Tipo_Venta")

            Txt_Transportista.Tag = _Row_Conf_Despacho.Item("Transportista_X_Defecto")
            Txt_Transportista.Text = _Row_Conf_Despacho.Item("Nom_Transportista")

        End If

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Direc_Cli_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.Text = _Row_Entidad.Item("Rut").ToString.Trim & " - " & _Row_Entidad.Item("NOKOEN")

        _CodPais = _Row_Despacho_Cli.Item("Pais")
        _CodCiudad = _Row_Despacho_Cli.Item("Ciudad")
        _CodComuna = _Row_Despacho_Cli.Item("Comuna")

        Consulta_sql = "Select Pa.KOPA,Pa.NOKOPA,Ci.KOCI,Ci.NOKOCI,Cm.KOCM,Cm.NOKOCM,
                        Rtrim(Ltrim(Pa.NOKOPA))+' - '+Rtrim(Ltrim(Ci.NOKOCI))+' - '+Rtrim(Ltrim(Cm.NOKOCM)) As Localidad	
                        From TABCM Cm 
                        Inner Join TABCI Ci On Ci.KOPA = Cm.KOPA And Ci.KOCI = Cm.KOCI
                        Inner Join TABPA Pa On Pa.KOPA = Cm.KOPA
                        Where Pa.KOPA = '" & _CodPais & "' And Ci.KOCI = '" & _CodCiudad & "' And Cm.KOCM = '" & _CodComuna & "'"

        Dim _Row_Localidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_Localidad) Then
            _Pais = _Row_Localidad.Item("NOKOPA")
            _Ciudad = _Row_Localidad.Item("NOKOCI")
            _Comuna = _Row_Localidad.Item("NOKOCM")
            Txt_Comuna.Text = _Comuna.Trim & ", " & _Ciudad.Trim
            Btn_Buscar_Comuna.Text = "Cambiar comuna"
        End If

        Txt_Direccion.Text = _Row_Despacho_Cli.Item("Direccion")
        Txt_Telefono.Text = _Row_Despacho_Cli.Item("Telefono")
        Txt_Email.Text = _Row_Despacho_Cli.Item("Email")

        Txt_Tipo_Venta.Tag = _Row_Despacho_Cli.Item("Tipo_Venta")
        Txt_Tipo_Venta.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones",
                                                "NombreTabla",
                                                "Tabla = 'SIS_DESPACHO_TIPO_VENTA' And CodigoTabla = '" & Txt_Tipo_Venta.Tag & "'")

        Txt_Transportista.Tag = _Row_Despacho_Cli.Item("Transportista")
        Txt_Transportista.Text = _Sql.Fx_Trae_Dato("TABRETI", "NORETI", "KORETI = '" & Txt_Transportista.Tag & "'")

        Chk_Por_Defecto.Checked = _Row_Despacho_Cli.Item("Por_Defecto")

        Txt_Nombre_Contacto.Text = _Row_Despacho_Cli.Item("Nombre_Contacto")

        If Chk_Por_Defecto.Checked Then
            Chk_Por_Defecto.Enabled = False
        End If

        If String.IsNullOrEmpty(_Comuna) Then
            Me.ActiveControl = Txt_Comuna
        End If

        Chk_Usar_HA.Checked = NuloPorNro(_Row_Despacho_Cli.Item("Usar_HA"), False)

        Dtp_HA_Manana_Desde.Value = NuloPorNro(_Row_Despacho_Cli.Item("HA_Manana_Desde"), Now.Date)
        Dtp_HA_Manana_Hasta.Value = NuloPorNro(_Row_Despacho_Cli.Item("HA_Manana_Hasta"), Now.Date)
        Dtp_HA_Tarde_Desde.Value = NuloPorNro(_Row_Despacho_Cli.Item("HA_Tarde_Desde"), Now.Date)
        Dtp_HA_Tarde_Hasta.Value = NuloPorNro(_Row_Despacho_Cli.Item("HA_Tarde_Hasta"), Now.Date)

        AddHandler Chk_Usar_HA.CheckedChanged, AddressOf Chk_Usar_HA_CheckedChanged
        AddHandler Chk_Usar_HA.CheckedChanging, AddressOf Chk_Usar_HA_CheckedChanging

        Sb_Color_Botones_Barra(Bar2)

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

    Private Sub Btn_Buscar_Transportista_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Transportista.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "TABRETI"
        _Filtrar.Campo = "KORETI"
        _Filtrar.Descripcion = "NORETI"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "TRANSPORTISTA"

        Dim _Sql_Filtro_Condicion_Extra = "And KORETI In (Select CodTransportista From " & _Global_BaseBk & "Zw_Despachos_Transportistas Where Mostrar = 1 And Tipo_Envio In ('DD',''))"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _Sql_Filtro_Condicion_Extra,
                               Nothing, False, True) Then

            Dim _Tbl_Transportista As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Transportista.Rows(0)

            Dim _Koreti = _Row.Item("Codigo").ToString.Trim
            Dim _Noreti = _Row.Item("Descripcion").ToString.Trim

            Txt_Transportista.Tag = _Koreti
            Txt_Transportista.Text = _Noreti

        End If

    End Sub

    Function Fx_Nueva_Fila(_Tbl As DataTable) As DataRow

        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow
        With NewFila

            .Item("Id") = 0
            .Item("CodEntidad") = _Row_Entidad.Item("KOEN")
            .Item("CodSucEntidad") = _Row_Entidad.Item("SUEN")
            .Item("Rut") = _Row_Entidad.Item("Rut")
            .Item("Nombre_Entidad") = _Row_Entidad.Item("NOKOEN")
            .Item("Pais") = String.Empty
            .Item("Ciudad") = String.Empty
            .Item("Comuna") = String.Empty
            .Item("Direccion") = String.Empty
            .Item("Telefono") = String.Empty
            .Item("Email") = String.Empty
            .Item("Tipo_Venta") = String.Empty
            .Item("Transportista") = String.Empty
            .Item("Por_Defecto") = False
            .Item("Nombre_Contacto") = String.Empty

            _Tbl.Rows.Add(NewFila)

        End With

        Return NewFila

    End Function

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(_CodComuna) Then
            MessageBoxEx.Show(Me, "Falta la comuna", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Txt_Direccion.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta la dirección de despacho", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Direccion.Text = String.Empty
            Txt_Direccion.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Nombre_Contacto.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el nombre del contacto", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Nombre_Contacto.Text = String.Empty
            Txt_Nombre_Contacto.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Telefono.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el teléfono de contacto del cliente", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Telefono.Text = String.Empty
            Txt_Telefono.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Email.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el correo para dar aviso al cliente", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Email.Text = String.Empty
            Txt_Email.Focus()
            Return
        End If

        If Not Fx_Validar_Email(Txt_Email.Text.Trim) Then
            MessageBoxEx.Show(Me, "El correo para dar aviso al cliente no es una cuenta de correo electrónico valida", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Email.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Tipo_Venta.Tag) Then

            MessageBoxEx.Show(Me, "Falta tipo de venta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Call Btn_Buscar_Tipo_Venta_Click(Nothing, Nothing)

            If String.IsNullOrEmpty(Txt_Tipo_Venta.Tag) Then
                Return
            End If

        End If

        If String.IsNullOrEmpty(Txt_Transportista.Tag) Then

            MessageBoxEx.Show(Me, "Falta el transportista", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Call Btn_Buscar_Transportista_Click(Nothing, Nothing)

            If String.IsNullOrEmpty(Txt_Transportista.Tag) Then
                Return
            End If

        End If

        If Chk_Usar_HA.Checked Then

            If Dtp_HA_Manana_Desde.Value > Dtp_HA_Manana_Hasta.Value Then
                MessageBoxEx.Show(Me, "La hora de la mañana de inicio no puede ser mayor que la hora de la mañana termino", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            If Dtp_HA_Tarde_Desde.Value > Dtp_HA_Tarde_Hasta.Value Then
                MessageBoxEx.Show(Me, "La hora de la tarde de inicio no puede ser mayor que la hora de la tarde termino", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            If Dtp_HA_Tarde_Desde.Value < Dtp_HA_Manana_Hasta.Value Then
                MessageBoxEx.Show(Me, "La hora de inicio de la tarde no puede ser menor que la hora de termino de la mañana", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        End If

        Dim _HA_MaDesde As String = FormatDateTime(Dtp_HA_Manana_Desde.Value, DateFormat.ShortTime)
        Dim _HA_MaHasta As String = FormatDateTime(Dtp_HA_Manana_Hasta.Value, DateFormat.ShortTime)
        Dim _HA_TaDesde As String = FormatDateTime(Dtp_HA_Tarde_Desde.Value, DateFormat.ShortTime)
        Dim _HA_TaHasta As String = FormatDateTime(Dtp_HA_Tarde_Hasta.Value, DateFormat.ShortTime)

        If Not Chk_Usar_HA.Checked Then
            _HA_MaDesde = "00:00"
            _HA_MaHasta = "00:00"
            _HA_TaDesde = "00:00"
            _HA_TaHasta = "00:00"
        End If

        Dim _Direccion As String = Txt_Direccion.Text.Trim
        _Direccion = Replace(_Direccion, "'", "''")

        Dim _Id = _Row_Despacho_Cli.Item("Id")

        If CBool(_Id) Then

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Despachos_Direcc_Cli Set" & vbCrLf &
                           "CodEntidad = '" & _Row_Entidad.Item("KOEN") & "'," &
                           "CodSucEntidad = '" & _Row_Entidad.Item("SUEN") & "'," &
                           "Rut = '" & _Row_Entidad.Item("Rut") & "'," &
                           "Nombre_Entidad = '" & _Row_Entidad.Item("NOKOEN") & "'," &
                           "Pais = '" & _CodPais & "'," &
                           "Ciudad = '" & _CodCiudad & "'," &
                           "Comuna = '" & _CodComuna & "'," &
                           "Direccion = '" & _Direccion & "'," &
                           "Nombre_Contacto = '" & Txt_Nombre_Contacto.Text & "'," &
                           "Telefono = '" & Txt_Telefono.Text & "'," &
                           "Email = '" & Txt_Email.Text & "'," &
                           "Tipo_Venta = '" & Txt_Tipo_Venta.Tag & "'," &
                           "Transportista = '" & Txt_Transportista.Tag & "'," &
                           "Por_Defecto = " & Convert.ToInt32(Chk_Por_Defecto.Checked) & "," &
                           "Usar_HA = " & Convert.ToInt32(Chk_Usar_HA.Checked) & "," &
                           "HA_Manana_Desde = '" & _HA_MaDesde & "'," &
                           "HA_Manana_Hasta = '" & _HA_MaHasta & "'," &
                           "HA_Tarde_Desde = '" & _HA_TaDesde & "'," &
                           "HA_Tarde_Hasta = '" & _HA_TaHasta & "'" & vbCrLf &
                           "Where Id = " & _Id

            If Chk_Por_Defecto.Checked Then

                Consulta_sql += vbCrLf & vbCrLf & "Update " & _Global_BaseBk & "Zw_Despachos_Direcc_Cli Set " & vbCrLf &
                                "Por_Defecto = 0 Where CodEntidad = '" & _Row_Entidad.Item("KOEN") & "' And Id <> " & _Id

            End If

            _Grabar = _Sql.Ej_consulta_IDU(Consulta_sql)

        Else

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Despachos_Direcc_Cli " &
                            "(CodEntidad,CodSucEntidad,Rut,Nombre_Entidad,Pais,Ciudad,Comuna,Direccion,Nombre_Contacto," &
                            "Telefono,Email,Tipo_Venta,Transportista,Por_Defecto,Usar_HA,HA_Manana_Desde,HA_Manana_Hasta,HA_Tarde_Desde,HA_Tarde_Hasta) Values " &
                            "('" & _Row_Entidad.Item("KOEN") & "'" & ",'" & _Row_Entidad.Item("SUEN") & "','" & _Row_Entidad.Item("Rut") &
                            "','" & _Row_Entidad.Item("NOKOEN") & "','" & _CodPais & "','" & _CodCiudad & "','" & _CodComuna & "','" & _Direccion & "'," &
                            "'" & Txt_Nombre_Contacto.Text & "','" & Txt_Telefono.Text & "','" & Txt_Email.Text & "','" & Txt_Tipo_Venta.Tag &
                            "','" & Txt_Transportista.Tag & "'," & Convert.ToInt32(Chk_Por_Defecto.Checked) &
                            "," & Convert.ToInt32(Chk_Usar_HA.Checked) &
                            ",'" & _HA_MaDesde & "','" & _HA_MaHasta & "','" & _HA_TaDesde & "','" & _HA_TaHasta & "')"

            If Chk_Por_Defecto.Checked Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Despachos_Direcc_Cli Set " & vbCrLf &
                               "Por_Defecto = 0 Where CodEntidad = '" & _Row_Entidad.Item("KOEN") & "'" & vbCrLf & vbCrLf &
                               Consulta_sql

            End If

            _Grabar = _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, Id)

        End If

        If _Grabar Then

            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        End If

    End Sub

    Private Sub Frm_Direc_Cli_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Buscar_Comuna_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Comuna.Click

        Dim Fm As New Frm_PaCiCm_Lista
        Fm.ShowDialog(Me)

        If Not IsNothing(Fm.Row_Localidad) Then

            _CodPais = Fm.Row_Localidad.Item("KOPA")
            _CodCiudad = Fm.Row_Localidad.Item("KOCI")
            _CodComuna = Fm.Row_Localidad.Item("KOCM")

            _Pais = Fm.Row_Localidad.Item("NOKOPA")
            _Ciudad = Fm.Row_Localidad.Item("NOKOCI")
            _Comuna = Fm.Row_Localidad.Item("NOKOCM")

            Txt_Comuna.Text = _Comuna.Trim & ", " & _Ciudad.Trim
            Btn_Buscar_Comuna.Text = "Cambiar comuna"

        End If

        Txt_Direccion.Focus()

        Fm.Dispose()

    End Sub

    Private Sub Btn_Direccion_Servicio_Click(sender As Object, e As EventArgs) Handles Btn_Direccion_Servicio.Click

        If String.IsNullOrEmpty(_CodPais.Trim) Or
           String.IsNullOrEmpty(_CodCiudad.Trim) Or
           String.IsNullOrEmpty(_CodComuna.Trim) Or
           String.IsNullOrEmpty(Txt_Direccion.Text.Trim) Then

            MessageBoxEx.Show(Me, "Falta la dirección", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Return

        End If

        Sb_Ver_Direccion_En_Mapa(_Pais.Trim, _Ciudad.Trim, _Comuna.Trim, Txt_Direccion.Text.Trim)

    End Sub

    Private Sub Txt_Comuna_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Comuna.KeyDown
        If e.KeyValue = Keys.Enter Then
            If String.IsNullOrEmpty(Txt_Comuna.Text.Trim) Then
                Call Btn_Buscar_Comuna_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub Btn_Modificar_Horario_Click(sender As Object, e As EventArgs) Handles Btn_Modificar_Horario.Click

        Btn_Modificar_Horario.Enabled = False

        If Fx_Tiene_Permiso(Me, "ODp00018") Then
            Layauot_HA.Enabled = True
            Btn_Modificar_Horario.Enabled = False
            Dtp_HA_Manana_Desde.Enabled = True
            Dtp_HA_Manana_Hasta.Enabled = True
            Dtp_HA_Tarde_Desde.Enabled = True
            Dtp_HA_Tarde_Hasta.Enabled = True
        End If

        Btn_Modificar_Horario.Enabled = True

    End Sub

    Private Sub Chk_Usar_HA_CheckedChanging(sender As Object, e As Controls.CheckBoxXChangeEventArgs)
        Chk_Usar_HA.Enabled = False
        If Not Fx_Tiene_Permiso(Me, "ODp00018") Then
            e.Cancel = True
        End If
        Chk_Usar_HA.Enabled = True
    End Sub

    Private Sub Chk_Usar_HA_CheckedChanged(sender As Object, e As EventArgs)

        Layauot_HA.Enabled = Chk_Usar_HA.Checked
        Btn_Modificar_Horario.Enabled = Chk_Usar_HA.Checked

        Dtp_HA_Manana_Desde.Enabled = False
        Dtp_HA_Manana_Hasta.Enabled = False
        Dtp_HA_Tarde_Desde.Enabled = False
        Dtp_HA_Tarde_Hasta.Enabled = False

    End Sub

    Private Sub Btn_Traer_Datos_Transportista_Click(sender As Object, e As EventArgs) Handles Btn_Traer_Datos_Transportista.Click

        If String.IsNullOrEmpty(Txt_Transportista.Tag) Then
            MessageBoxEx.Show(Me, "Falta el transportista", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Consulta_sql = "Select *,NOKOPA,NOKOCI,NOKOCM From TABRETI 
                            Left Join " & _Global_BaseBk & "Zw_Despachos_Transportistas On CodTransportista = KORETI
                            Left Join TABPA Pa On Pa.KOPA = PARETI 
                            Left Join TABCI Ci On Ci.KOPA = PARETI And Ci.KOCI = CIRETI
                            Left Join TABCM Cm On Cm.KOPA = PARETI And Cm.KOCI = CIRETI And Cm.KOCM = CMRETI
                            Where KORETI = '" & Txt_Transportista.Tag & "'"
        _Row_Transportista = _Sql.Fx_Get_DataRow(Consulta_sql)

        _CodPais = _Row_Transportista.Item("KOPA")
        _CodCiudad = _Row_Transportista.Item("KOCI")
        _CodComuna = _Row_Transportista.Item("KOCM")

        _Pais = _Row_Transportista.Item("NOKOPA")
        _Ciudad = _Row_Transportista.Item("NOKOCI")
        _Comuna = _Row_Transportista.Item("NOKOCM")

        Txt_Comuna.Text = _Comuna.Trim & ", " & _Ciudad.Trim
        Btn_Buscar_Comuna.Text = "Cambiar comuna"

        Txt_Direccion.Text = _Row_Transportista.Item("DIRETI")

    End Sub
End Class
