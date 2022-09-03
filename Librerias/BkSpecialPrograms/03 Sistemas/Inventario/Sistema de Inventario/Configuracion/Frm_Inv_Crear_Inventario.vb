Imports DevComponents.DotNetBar
Public Class Frm_Inv_Crear_Inventario

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Grabar As Boolean
    Dim _Id_Inventario As Integer
    Dim _Empresa As String
    Dim _Sucursal As String

    Dim _Row_Inventario As DataRow

    Public Property Empresa As String
        Get
            Return _Empresa
        End Get
        Set(value As String)
            _Empresa = value
        End Set
    End Property

    Public Property Sucursal As String
        Get
            Return _Sucursal
        End Get
        Set(value As String)
            _Sucursal = value
        End Set
    End Property

    Public Property Id_Inventario As Integer
        Get
            Return _Id_Inventario
        End Get
        Set(value As Integer)
            _Id_Inventario = value
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

    Public Sub New(_Empresa As String, _Sucursal As String, _Id_Inventario As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.Id_Inventario = _Id_Inventario
        Me.Empresa = _Empresa
        Me.Sucursal = _Sucursal

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Inv_Inventario Inv" & vbCrLf &
                       "Where Id_Inventario = " & _Id_Inventario
        _Row_Inventario = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Private Sub Frm_Crear_Inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LblEmpresa.Text = RazonEmpresa
        LblSucursal.Text = _Sql.Fx_Trae_Dato("TABSU", "NOKOSU", "EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sucursal & "'")

        If Not IsNothing(_Row_Inventario) Then
            Txt_Nombre.Text = _Row_Inventario.Item("Nombre")
            Dtp_FechaInicio.Value = _Row_Inventario.Item("FechaInicio")
            Sw_Activo.Value = _Row_Inventario.Item("Activo")
            Dtp_FechaCierre.Value = _Row_Inventario.Item("FechaCierre")
        Else
            Lbl_Estado.Enabled = False
            Sw_Activo.Enabled = False
            Lbl_FechaCierre.Enabled = False
            Dtp_FechaCierre.Enabled = False
            Txt_Nombre.ReadOnly = False
            Txt_Nombre.Enabled = True
            Dtp_FechaInicio.Enabled = True
            Me.ActiveControl = Txt_Nombre
        End If

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _FechaInicio As String = Format(Dtp_FechaInicio.Value, "yyyyMMdd")
        Dim _FechaCierre As String = Format(Dtp_FechaCierre.Value, "yyyyMMdd")

        If Sw_Activo.Value Then
            _FechaCierre = "Null"
        Else
            _FechaCierre = "'" & _FechaCierre & "'"
        End If

        If Not CBool(_Id_Inventario) Then
            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Inv_Inventario (Empresa,Sucursal,Nombre_Inventario,FechaInicio) Values ('" & _Empresa & "','" & _Sucursal & "','" & Txt_Nombre.Text.Trim & "','" & _FechaInicio & "')"
            _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Inventario)
        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Inv_Inventario Set" & vbCrLf &
                        "FechaInicio = '" & _FechaInicio &
                        "',Nombre_Inventario = '" & Txt_Nombre.Text &
                        "',Activo = " & Convert.ToInt32(Sw_Activo.Value) &
                        ",FechaCierre = " & _FechaCierre & vbCrLf &
                        "Where Id_Inventario = " & _Id_Inventario
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        _Grabar = True
        Me.Close()

    End Sub

End Class
