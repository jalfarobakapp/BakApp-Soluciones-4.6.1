Imports DevComponents.DotNetBar

Public Class Frm_ConfPuntosVta

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Cl_Puntos As Cl_Puntos
    Private _Row_Concepto As DataRow

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_ConfPuntosVta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _Cl_Puntos = New Cl_Puntos()
        _Cl_Puntos.Zw_PtsVta_Configuracion = _Cl_Puntos.Fx_Llenar_Zw_PtsVta_Configuracion(ModEmpresa)

        With _Cl_Puntos.Zw_PtsVta_Configuracion

            Input_GCadaPesos.Value = .GCadaPesos
            Input_GEquivPuntos.Value = .GEquivPuntos
            Input_RCadaPuntos.Value = .RCadaPuntos
            Input_REquivPesos.Value = .REquivPesos
            Input_MinPtosCanjear.Value = .MinPtosCanjear
            Input_ValMinPedCajear.Value = .ValMinPedCajear
            Txt_Concepto.Tag = .Concepto
            Chk_Activo.Checked = .Activo

            Consulta_sql = "Select * From TABCT Where KOCT = '" & .Concepto & "'"
            _Row_Concepto = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Concepto) Then
                Txt_Concepto.Text = .Concepto.ToString.Trim & " - " & _Row_Concepto.Item("NOKOCT").ToString.Trim
            End If

        End With

        Me.ActiveControl = Input_GCadaPesos

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If Chk_Activo.Checked Then
            If String.IsNullOrWhiteSpace(Txt_Concepto.Text) Then
                MessageBoxEx.Show(Me, "Falta el concepto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Concepto.Focus()
                Return
            End If
        End If

        With _Cl_Puntos.Zw_PtsVta_Configuracion

            .GCadaPesos = Input_GCadaPesos.Value
            .GEquivPuntos = Input_GEquivPuntos.Value
            .RCadaPuntos = Input_RCadaPuntos.Value
            .REquivPesos = Input_REquivPesos.Value
            .MinPtosCanjear = Input_MinPtosCanjear.Value
            .ValMinPedCajear = Input_ValMinPedCajear.Value
            .Concepto = Txt_Concepto.Tag
            .Activo = Chk_Activo.Checked

        End With

        Dim _Mensaje As LsValiciones.Mensajes = _Cl_Puntos.Fx_Grabar_Configuracion

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        MessageBoxEx.Show(Me, _Mensaje.Mensaje & vbCrLf &
                          "No sera necesario grabar en el siguiente formulario.", _Mensaje.Detalle,
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

    End Sub

    Private Sub Txt_Concepto_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Concepto.ButtonCustomClick

        Dim _Sql_Filtro_Condicion_Extra = "And TICT = 'D'"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Conceptos, _Sql_Filtro_Condicion_Extra, False, False, True) Then

            Dim _Concepto As String = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")

            Consulta_sql = "Select * From TABCT Where KOCT = '" & _Concepto & "'"
            _Row_Concepto = _Sql.Fx_Get_DataRow(Consulta_sql)

            Txt_Concepto.Tag = _Concepto
            Txt_Concepto.Text = _Concepto.ToString.Trim & " - " & _Row_Concepto.Item("NOKOCT").ToString.Trim

        End If

    End Sub

End Class
