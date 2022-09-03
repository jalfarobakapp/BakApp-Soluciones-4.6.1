Imports DevComponents.DotNetBar

Public Class Frm_Direccion_Desp

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Grabar As Boolean
    Dim _Buscar_Comuna_Inmediatamente As Boolean

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

    Public Property Direccion As String
        Get
            Return Txt_Direccion.Text
        End Get
        Set(value As String)
            Txt_Direccion.Text = value
        End Set
    End Property

    Public Property Telefono As String
        Get
            Return Txt_Telefono.Text
        End Get
        Set(value As String)
            Txt_Telefono.Text = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return Txt_Email.Text.Trim
        End Get
        Set(value As String)
            Txt_Email.Text = value.Trim
        End Set
    End Property

    Public Property Observaciones As String
        Get
            Txt_Observaciones.Text = Replace(Txt_Observaciones.Text, vbLf, Space(1))
            Txt_Observaciones.Text = Replace(Txt_Observaciones.Text, vbCrLf, Space(1))
            Txt_Observaciones.Text = Replace(Txt_Observaciones.Text, Chr(13), Space(1))
            Txt_Observaciones.Text = Replace(Txt_Observaciones.Text, "  ", Space(1))
            Return Txt_Observaciones.Text.Trim
        End Get
        Set(value As String)
            Txt_Observaciones.Text = value.Trim
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

    Public Property Buscar_Comuna_Inmediatamente As Boolean
        Get
            Return _Buscar_Comuna_Inmediatamente
        End Get
        Set(value As Boolean)
            _Buscar_Comuna_Inmediatamente = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Txt_Nombre_Contacto.CharacterCasing = CharacterCasing.Upper
        Txt_Email.CharacterCasing = CharacterCasing.Lower

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Direccion_Desp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        End If

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

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

        If String.IsNullOrEmpty(_Comuna) Then
            MessageBoxEx.Show(Me, "Falta la comuna", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Call Btn_Buscar_Comuna_Click(Nothing, Nothing)
            If String.IsNullOrEmpty(_Comuna) Then Return
        End If

        If String.IsNullOrEmpty(Telefono) Then
            MessageBoxEx.Show(Me, "Falta el teléfono de contacto del cliente", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Telefono.Text = String.Empty
            Txt_Telefono.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Email) Then
            MessageBoxEx.Show(Me, "Falta el correo para dar aviso al cliente", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Email.Text = String.Empty
            Txt_Email.Focus()
            Return
        End If

        If Not Fx_Validar_Email(Email) Then
            MessageBoxEx.Show(Me, "El correo para dar aviso al cliente no es una cuenta de correo electrónico valida", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Email.Focus()
            Return
        End If

        _Grabar = True
        Me.Close()

    End Sub

    Private Sub Frm_Direccion_Desp_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
End Class
