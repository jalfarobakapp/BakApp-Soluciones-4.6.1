Imports DevComponents.DotNetBar

Public Class Frm_Fincred

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String
    Private _RowToken As DataRow
    Public Property Grabar As Boolean
    Public Property RowToken As DataRow
        Get
            Return _RowToken
        End Get
        Set
            _RowToken = Value
        End Set
    End Property

    Public Sub New(_Id As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Fincred_Config Where Id = " & _Id
        _RowToken = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Private Sub Frm_Fincred_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not IsNothing(_RowToken) Then
            Txt_Token2.Enabled = False
            Txt_Token2.Text = _RowToken.Item("Token")
            Txt_NombreSucursal.Text = _RowToken.Item("NombreSucursal")
            Chk_AmbientePruebas.Checked = _RowToken.Item("AmbientePruebas")
        Else
            Me.ActiveControl() = Txt_Token2
        End If

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _Id As Integer
        Dim _Token As String = Txt_Token2.Text.Trim
        Dim _NombreSucursal As String = Txt_NombreSucursal.Text.Trim
        Dim _AmbientePruebas As Integer = Convert.ToInt32(Chk_AmbientePruebas.Checked)

        If String.IsNullOrEmpty(_Token) Then
            MessageBoxEx.Show(Me, "Falta el Token", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Token2.Focus()
            Return
        End If

        If String.IsNullOrEmpty(_NombreSucursal) Then
            MessageBoxEx.Show(Me, "Falta el nombre de la sucursal", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_NombreSucursal.Focus()
            Return
        End If

        If IsNothing(_RowToken) Then

            Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Fincred_Config", "Token = '" & _Token & "'")

            If CBool(_Reg) Then
                MessageBoxEx.Show(Me, "Token ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Fincred_Config (Token,NombreSucursal,AmbientePruebas) Values " &
                           "('" & _Token & "','" & _NombreSucursal & "','" & _AmbientePruebas & "')"
            If _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id) Then
                Grabar = True
            End If

        Else

            _Id = _RowToken.Item("Id")

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Fincred_Config Set " &
                           "NombreSucursal = '" & _NombreSucursal & "',AmbientePruebas = " & _AmbientePruebas & vbCrLf &
                           "Where Id = " & _Id
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                Grabar = True
            End If

        End If

        If Grabar Then

            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Fincred_Config Where Id = " & _Id
            _RowToken = _Sql.Fx_Get_DataRow(Consulta_sql)
            Me.Close()
        End If

    End Sub
End Class
