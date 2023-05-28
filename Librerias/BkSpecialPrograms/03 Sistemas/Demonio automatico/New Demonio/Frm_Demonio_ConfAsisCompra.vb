Public Class Frm_Demonio_ConfAsisCompra

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id As Integer
    Dim _Row_Configuracion As DataRow
    Dim _Row_Programacion As DataRow

    Public Property Id As Integer
        Get
            Return _Id
        End Get
        Set(value As Integer)
            _Id = value
        End Set
    End Property

    Public Sub New(_Id As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id = _Id

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_ConfAsisCompra Where Id = " & _Id
        _Row_Configuracion = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Arr_Tido(,) As String = {{"", ""}, {"NVI", "NVI - Nota de venta interna"},
                                     {"OC1", "OCC - Orden de compra proveedor estrella"},
                                     {"OC2", "OCC - Orden de compra proveedor regular"}}
        Sb_Llenar_Combos(_Arr_Tido, Cmb_Tido)
        Cmb_Tido.SelectedValue = ""

    End Sub

    Private Sub Frm_Demonio_ConfAsisCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not IsNothing(_Row_Configuracion) Then
            Txt_Modalidad.Text = _Row_Configuracion.Item("Modalidad")
            Cmb_Tido.SelectedValue = _Row_Configuracion.Item("Tido")
        End If

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

    End Sub

    Private Sub Btn_ConfProgramacion_Click(sender As Object, e As EventArgs) Handles Btn_ConfProgramacion.Click

        ' Dim Fm As New Frm_Demonio_ConfProgramacion

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
