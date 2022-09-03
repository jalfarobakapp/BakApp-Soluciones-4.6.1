Imports DevComponents.DotNetBar

Public Class Frm_Retirador_Mercaderia

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Row_Tabreti As DataRow
    Dim _Accion As Enum_Reti
    Dim _Grabar As Boolean
    Dim _Eliminado As Boolean

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


    Public Property Row_Tabreti As DataRow
        Get
            Return _Row_Tabreti
        End Get
        Set(value As DataRow)
            _Row_Tabreti = value
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

    Public Property Eliminado As Boolean
        Get
            Return _Eliminado
        End Get
        Set(value As Boolean)
            _Eliminado = value
        End Set
    End Property

    Enum Enum_Reti
        Nuevo
        Editar
    End Enum

    Public Sub New(_Koreti As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dim _Arr_Tipo_Envio(,) As String = {{"", "AGENCIA y DESPACHO A DOMICILIO"},
                                            {"AG", "SOLO PARA AGENCIA"},
                                            {"DD", "SOLO PARA DESPACHO A DOMICILIO"}}
        Sb_Llenar_Combos(_Arr_Tipo_Envio, Cmb_Tipo_Envio)
        Cmb_Tipo_Envio.SelectedValue = ""

        Sb_Cargar_Retirador(_Koreti)

    End Sub
    Private Sub Frm_Retirador_Mercaderia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Btn_Eliminar.Visible = (_Accion = Enum_Reti.Editar)
        Me.ActiveControl = Txt_Koreti

    End Sub

    Sub Sb_Cargar_Retirador(_Koreti As String)

        Consulta_Sql = "Select TABRETI.*,Isnull(Tr.Cant_Minima,0) As Cant_Minima,Isnull(Tr.Mostrar,0) As Mostrar,Tipo_Envio
                        From TABRETI 
                        Left Join " & _Global_BaseBk & "Zw_Despachos_Transportistas Tr On KORETI = Tr.CodTransportista
                        Where KORETI = '" & _Koreti & "'"
        _Row_Tabreti = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If Not IsNothing(_Row_Tabreti) Then

            _Accion = Enum_Reti.Editar

            Txt_Koreti.Text = _Row_Tabreti.Item("KORETI")
            Txt_Rureti.Text = _Row_Tabreti.Item("RURETI")
            Txt_Noreti.Text = _Row_Tabreti.Item("NORETI")
            Txt_Direti.Text = _Row_Tabreti.Item("DIRETI")
            _CodPais = _Row_Tabreti.Item("PARETI")
            _CodCiudad = _Row_Tabreti.Item("CIRETI")
            _CodComuna = _Row_Tabreti.Item("CMRETI")
            Chk_Retcli.Checked = _Row_Tabreti.Item("RETCLI")
            Txt_Koenresp.Text = _Row_Tabreti.Item("KOENRESP")
            Txt_Koenresp.Tag = _Row_Tabreti.Item("SUENRESP")
            Txt_Licencondu.Text = NuloPorNro(_Row_Tabreti.Item("LICENCONDU"), "")
            Input_Cant_Minima.Value = _Row_Tabreti.Item("Cant_Minima")
            Chk_Mostrar.Checked = _Row_Tabreti.Item("Mostrar")
            Cmb_Tipo_Envio.SelectedValue = _Row_Tabreti.Item("Tipo_Envio")

            Lbl_Nom_EntResponsable.Text = _Sql.Fx_Trae_Dato("MAEEN", "NOKOEN", "KOEN = '" & Txt_Koenresp.Text & "' And SUEN = '" & Txt_Koenresp.Tag & "'")

            Txt_Koreti.Enabled = False

            Consulta_Sql = "Select Pa.KOPA,Pa.NOKOPA,Ci.KOCI,Ci.NOKOCI,Cm.KOCM,Cm.NOKOCM,
                            Rtrim(Ltrim(Pa.NOKOPA))+' - '+Rtrim(Ltrim(Ci.NOKOCI))+' - '+Rtrim(Ltrim(Cm.NOKOCM)) As Localidad	
                            From TABCM Cm 
                            Inner Join TABCI Ci On Ci.KOPA = Cm.KOPA And Ci.KOCI = Cm.KOCI
                            Inner Join TABPA Pa On Pa.KOPA = Cm.KOPA
                            Where Pa.KOPA = '" & _CodPais & "' And Ci.KOCI = '" & _CodCiudad & "' And Cm.KOCM = '" & _CodComuna & "'"

            Dim _Row_Localidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

            If Not IsNothing(_Row_Localidad) Then
                _Pais = _Row_Localidad.Item("NOKOPA")
                _Ciudad = _Row_Localidad.Item("NOKOCI")
                _Comuna = _Row_Localidad.Item("NOKOCM")
                Txt_Comuna.Text = _Comuna.Trim & ", " & _Ciudad.Trim
                Btn_Buscar_Comuna.Text = "Cambiar comuna"
            End If

        Else
            _Accion = Enum_Reti.Nuevo
        End If

    End Sub

    Private Sub Btn_Grabar_e_Imprimir_Click(sender As Object, e As EventArgs) Handles Btn_Grabar_e_Imprimir.Click

        If String.IsNullOrEmpty(Txt_Koreti.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el código del retirador", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Koreti.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Noreti.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el nombre del retirador", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Noreti.Focus()
            Return
        End If


        If String.IsNullOrEmpty(Txt_Rureti.Text.Trim) Then
            MessageBoxEx.Show(Me, "El Rut no puede estar vacio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Rureti.Focus()
            Return
        End If

        Txt_Rureti.Text = Replace(Txt_Rureti.Text, ".", "")
        Dim Rut(1) As String
        Rut = Split(Txt_Rureti.Text, "-")
        Dim Rt = numero_(Rut(0), 8)

        If Not VerificaDigito(Txt_Rureti.Text) Then
            MessageBoxEx.Show(Me, "Rut invalido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Rureti.SelectAll()
            Txt_Rureti.Focus()
            Return
        End If

        If _Accion = Enum_Reti.Nuevo Then

            Dim _Reg = _Sql.Fx_Cuenta_Registros("TABRETI", "KORETI = '" & Txt_Koreti.Text & "'")

            If CBool(_Reg) Then
                MessageBoxEx.Show(Me, "Ya existe un registro con este código de retirador", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        End If

        Consulta_Sql = "Insert Into TABRETI (KORETI,RURETI,NORETI,PARETI,CIRETI,CMRETI,DIRETI,RETCLI,KOENRESP,SUENRESP,TIPORUC,LICENCONDU) Values " &
                       "('" & Txt_Koreti.Text & "','" & Txt_Rureti.Text & "','" & Txt_Noreti.Text.Trim &
                       "','" & _CodPais & "','" & _CodCiudad & "','" & _CodComuna &
                       "','" & Txt_Direti.Text.Trim & "'," & Convert.ToInt32(Chk_Retcli.Checked) & ",'" & Txt_Koenresp.Text & "','" & Txt_Koenresp.Tag &
                       "','','" & Txt_Licencondu.Text & "')

                       Insert Into " & _Global_BaseBk & "Zw_Despachos_Transportistas (CodTransportista,Mostrar,Cant_Minima,Tipo_Envio) Values " &
                       "('" & Txt_Koreti.Text & "'," & Convert.ToInt32(Chk_Mostrar.Checked) & "," & Input_Cant_Minima.Value & ",'" & Cmb_Tipo_Envio.SelectedValue & "')"

        If _Accion = Enum_Reti.Editar Then

            Consulta_Sql = "Delete TABRETI Where KORETI = '" & _Row_Tabreti.Item("KORETI") & "'" & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Despachos_Transportistas Where CodTransportista = '" & _Row_Tabreti.Item("KORETI") & "'" & vbCrLf &
                           Consulta_Sql

        End If

        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

            Consulta_Sql = "Select * From TABRETI Where KORETI = '" & Txt_Koreti.Text & "'"
            _Row_Tabreti = _Sql.Fx_Get_DataRow(Consulta_Sql)

            _Grabar = True

            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        End If

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        If Fx_Tiene_Permiso(Me, "Tbl00045") Then

            If MessageBoxEx.Show(Me, "¿Confirma eliminar retirador?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Consulta_Sql = "Delete TABRETI Where KORETI='" & Txt_Koreti.Text & "'"

                If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

                    Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Despachos_Transportistas Where CodTransportista = '" & Txt_Koreti.Text & "'"
                    _Sql.Ej_consulta_IDU(Consulta_Sql)

                    _Eliminado = True
                    Me.Close()

                End If

            End If

        End If

    End Sub

    Private Sub Btn_Buscar_Koenresp_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Koenresp.Click

        If Btn_Buscar_Koenresp.Text = "Quitar" Then
            Txt_Koenresp.Text = String.Empty
            Txt_Koenresp.Tag = String.Empty
            Lbl_Nom_EntResponsable.Text = String.Empty
            Btn_Buscar_Koenresp.Text = "Buscar"
            Return
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)
        Dim _Tbl_Filtro_Entidad As DataTable

        _Filtrar.Tabla = "MAEEN"
        _Filtrar.Campo = "KOEN+SUEN"
        _Filtrar.Descripcion = "NOKOEN"

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Entidad,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "",
                               False, False, True) Then

            _Tbl_Filtro_Entidad = _Filtrar.Pro_Tbl_Filtro

            Dim _Koen = Mid(_Tbl_Filtro_Entidad.Rows(0).Item("Codigo"), 1, 13)
            Dim _Suen = Mid(_Tbl_Filtro_Entidad.Rows(0).Item("Codigo"), 14, 10)
            Dim _Nokoen = _Tbl_Filtro_Entidad.Rows(0).Item("Descripcion")

            Txt_Koenresp.Text = _Koen
            Txt_Koenresp.Tag = _Suen
            Lbl_Nom_EntResponsable.Text = _Nokoen.ToString.Trim

            Btn_Buscar_Koenresp.Text = "Quitar"

        End If

    End Sub

    Private Sub Txt_Koenresp_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Koenresp.KeyDown
        If e.KeyValue = Keys.Delete Then
            Txt_Koenresp.Text = String.Empty
            Txt_Koenresp.Tag = String.Empty
            Lbl_Nom_EntResponsable.Text = String.Empty
            Beep()
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

        Txt_Direti.Focus()

        Fm.Dispose()

    End Sub

End Class
