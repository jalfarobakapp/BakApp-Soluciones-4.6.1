Imports DevComponents.DotNetBar
Public Class Frm_Crear_PaCiCm

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Localidad As String
    Dim _Tp As Enum_Tp

    Enum Enum_Tp
        Pais
        Ciudad
        Comuna
    End Enum

    Dim _Kopa As String
    Dim _Koci As String

    Dim _Grabar As Boolean

    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property Codigo As String
        Get
            Return Txt_Codigo.Text
        End Get
        Set(value As String)
            Txt_Codigo.Text = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return Txt_Descripcion.Text
        End Get
        Set(value As String)
            Txt_Descripcion.Text = value
        End Set
    End Property

    Public Property Kopa As String
        Get
            Return _Kopa
        End Get
        Set(value As String)
            _Kopa = value
        End Set
    End Property

    Public Property Koci As String
        Get
            Return _Koci
        End Get
        Set(value As String)
            _Koci = value
        End Set
    End Property

    Public Property Localidad As String
        Get
            Return _Localidad
        End Get
        Set(value As String)
            _Localidad = value
        End Set
    End Property

    Public Sub New(_Tp As Enum_Tp, _Localidad As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Localidad = _Localidad
        Me._Tp = _Tp

        Select Case _Tp
            Case Enum_Tp.Pais
                Txt_Codigo.MaxLength = 3
            Case Enum_Tp.Ciudad
                Txt_Codigo.MaxLength = 3
            Case Enum_Tp.Comuna
                Txt_Codigo.MaxLength = 6
        End Select

        Txt_Descripcion.MaxLength = 30

        If Global_Thema = Enum_Themas.Oscuro Then
            Txt_Codigo.FocusHighlightEnabled = False
            Txt_Descripcion.FocusHighlightEnabled = False
        End If

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Txt_Codigo.Text.Trim) Then
            MessageBoxEx.Show(Me, "El falta el código", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Txt_Descripcion.Text.Trim) Then
            MessageBoxEx.Show(Me, "El falta la descripción", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Reg As Boolean

        Select Case _Tp
            Case Enum_Tp.Pais

                _Reg = _Sql.Fx_Cuenta_Registros("TABPA", "KOPA = '" & Txt_Codigo.Text & "'")

                If _Reg Then
                    MessageBoxEx.Show(Me, "El código del pais ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                Consulta_sql = "Insert Into TABPA (KOPA,NOKOPA) Values ('" & Txt_Codigo.Text & "','" & Txt_Descripcion.Text & "')"
                If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    Return
                End If

            Case Enum_Tp.Ciudad

                _Reg = _Sql.Fx_Cuenta_Registros("TABCI", "KOPA = '" & _Kopa & "' And KOCI = '" & Txt_Codigo.Text & "'")

                If _Reg Then
                    MessageBoxEx.Show(Me, "El código de la ciudad ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                Consulta_sql = "Insert Into TABCI (KOPA,KOCI,NOKOCI) Values ('" & _Kopa & "','" & Txt_Codigo.Text & "','" & Txt_Descripcion.Text & "')"
                If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    Return
                End If

            Case Enum_Tp.Comuna

                _Reg = _Sql.Fx_Cuenta_Registros("TABCM", "KOPA = '" & _Kopa & "' And KOCI = '" & Koci & "' And KOCM = '" & Txt_Codigo.Text & "'")

                If _Reg Then
                    MessageBoxEx.Show(Me, "El código de la comuna ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                Consulta_sql = "Insert Into TABCM (KOPA,KOCI,KOCM,NOKOCM) Values ('" & _Kopa & "','" & _Koci & "','" & Txt_Codigo.Text & "','" & Txt_Descripcion.Text & "')"
                If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    Return
                End If

        End Select

        _Localidad += Txt_Descripcion.Text.Trim

        _Grabar = True
        Me.Close()

    End Sub

    Private Sub Frm_Crear_Pais_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Frm_Crear_PaCiCm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ActiveControl = Txt_Codigo
    End Sub
End Class
