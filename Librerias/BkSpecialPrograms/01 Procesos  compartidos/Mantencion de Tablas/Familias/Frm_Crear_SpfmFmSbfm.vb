Imports DevComponents.DotNetBar
Public Class Frm_Crear_SpfmFmSbfm

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Kofm As String
    Dim _Kopf As String
    Dim _Kohf As String
    Dim _Grabar As Boolean
    Dim _Localidad As String
    Dim _Tf As Enum_Tp

    Dim _Row_SuperFamilia As DataRow
    Dim _Row_Familia As DataRow

    Public Property Kofm As String
        Get
            Return _Kofm
        End Get
        Set(value As String)
            _Kofm = value
        End Set
    End Property

    Public Property Kopf As String
        Get
            Return _Kopf
        End Get
        Set(value As String)
            _Kopf = value
        End Set
    End Property

    Public Property Kohf As String
        Get
            Return _Kohf
        End Get
        Set(value As String)
            _Kohf = value
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

    Public Property Localidad As String
        Get
            Return _Localidad
        End Get
        Set(value As String)
            _Localidad = value
        End Set
    End Property

    Enum Enum_Tipo_Familia
        Super_Familia
        Familia
        Sub_Familia
    End Enum

    Public Sub New(_Tf As Enum_Tipo_Familia)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Localidad = _Localidad
        Me._Tf = _Tf

        Txt_Codigo.MaxLength = 4
        Txt_Descripcion.MaxLength = 30

        If Global_Thema = Enum_Themas.Oscuro Then
            Txt_Codigo.FocusHighlightEnabled = False
            Txt_Descripcion.FocusHighlightEnabled = False
        End If

    End Sub

    Enum Enum_Tp
        Super_familia
        Familia
        Sub_familia
    End Enum
    Private Sub Frm_Crear_SpfmFmSbfm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Consulta_sql = "Select * From TABFM Where KOFM = '" & _Kofm & "'"
        _Row_SuperFamilia = _Sql.Fx_Get_DataRow(Consulta_sql)

        Consulta_sql = "Select * From TABPF Where KOFM = '" & _Kofm & "' And KOPF = '" & _Kopf & "'"
        _Row_Familia = _Sql.Fx_Get_DataRow(Consulta_sql)

        Select Case _Tf
            Case Enum_Tp.Super_familia
                Me.Text = "CREAR SUPER FAMILIA"
            Case Enum_Tp.Familia
                Me.Text = "CREAR FAMILIA de Super familia: " & _Kofm.Trim & " - " & _Row_SuperFamilia.Item("NOKOFM").ToString.Trim
            Case Enum_Tp.Sub_familia
                Me.Text = "CREAR SUB-FAMILIA de Super familia: " & _Kofm.Trim & " - familia - " & _Kopf.Trim & "-" & _Row_Familia.Item("NOKOPF").ToString.Trim
        End Select

        Me.ActiveControl = Txt_Codigo

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

        Select Case _Tf
            Case Enum_Tp.Super_familia

                Consulta_sql = "Select Top 1 * From TABFM Where KOFM = '" & Txt_Codigo.Text & "'"
                Dim _RowFm As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not IsNothing(_RowFm) Then
                    MessageBoxEx.Show(Me, "El código de la Super Familia ya existe" & vbCrLf &
                                      "Código: " & _RowFm.Item("KOFM") & " - " & _RowFm.Item("NOKOFM").ToString.Trim,
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Txt_Codigo.SelectAll()
                    Txt_Codigo.Focus()
                    Return
                End If

                Consulta_sql = "Insert Into TABFM (KOFM,NOKOFM) Values ('" & Txt_Codigo.Text & "','" & Txt_Descripcion.Text & "')"
                If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    Return
                End If

            Case Enum_Tp.Familia

                _Reg = _Sql.Fx_Cuenta_Registros("TABPF", "KOFM = '" & _Kofm & "' And KOPF = '" & Txt_Codigo.Text & "'")

                If _Reg Then
                    MessageBoxEx.Show(Me, "El código de la Familia ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                Consulta_sql = "Insert Into TABPF (KOFM,KOPF,NOKOPF) Values ('" & _Kofm & "','" & Txt_Codigo.Text & "','" & Txt_Descripcion.Text & "')"
                If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    Return
                End If

            Case Enum_Tp.Sub_familia

                _Reg = _Sql.Fx_Cuenta_Registros("TABHF", "KOFM = '" & _Kofm & "' And KOPF = '" & Kopf & "' And KOHF = '" & Txt_Codigo.Text & "'")

                If _Reg Then
                    MessageBoxEx.Show(Me, "El código de la Sub-Familia ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                Consulta_sql = "Insert Into TABHF (KOFM,KOPF,KOHF,NOKOHF) Values ('" & _Kofm & "','" & _Kopf & "','" & Txt_Codigo.Text & "','" & Txt_Descripcion.Text & "')"
                If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    Return
                End If

        End Select

        _Localidad += Txt_Descripcion.Text.Trim

        _Grabar = True
        Me.Close()

    End Sub
End Class
