Public Class Frm_Demonio_ConfFacAuto

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Demonio_ConfFacAuto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Txt_Modalidad_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Modalidad.ButtonCustomClick

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "CONFIEST"
        _Filtrar.Campo = "MODALIDAD"
        _Filtrar.Descripcion = "MODALIDAD"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "MODALIDAD"

        Dim _Tbl As DataTable

        If Not String.IsNullOrEmpty(Txt_Modalidad.Text) Then

            Consulta_sql = "Select Distinct Cast(1 As Bit) As Chk,MODALIDAD As Codigo, MODALIDAD As Descripcion" & vbCrLf &
                           "From CONFIEST" & vbCrLf &
                           "Where EMPRESA = '" & ModEmpresa & "' And MODALIDAD In " & Txt_Modalidad.Text
            _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)

        End If

        If _Filtrar.Fx_Filtrar(_Tbl,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "And EMPRESA = '" & ModEmpresa & "'",
                               Nothing, False, True) Then

            Txt_Modalidad.Text = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")

        End If

    End Sub

End Class
