Imports DevComponents.DotNetBar

Public Class Frm_Agencia_Entidad

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Entidad As DataRow
    Dim _Grabar As Boolean
    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Sub New(_CodEntidad As String, _SucEntidad As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Row_Entidad = Fx_Traer_Datos_Entidad(_CodEntidad, _SucEntidad)

        Sb_Color_Botones_Barra(Bar2)

    End Sub


    Private Sub Frm_Agencia_Entidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _CodEntidad As String = _Row_Entidad.Item("KOEN")
        Dim _SucEntidad As String = _Row_Entidad.Item("SUEN")

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Entidades Where CodEntidad = '" & _CodEntidad & "' And CodSucEntidad = '" & _SucEntidad & "'"
        Dim _Row_AgenciaXEntidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _AG_AgenciaxDefDespachos As Boolean
        Dim _AG_Transportista As String
        Dim _AG_Nombre_Contacto As String

        If Not IsNothing(_Row_AgenciaXEntidad) Then

            _AG_AgenciaxDefDespachos = _Row_AgenciaXEntidad.Item("AG_AgenciaxDefDespachos")
            _AG_Transportista = _Row_AgenciaXEntidad.Item("AG_Transportista")
            _AG_Nombre_Contacto = _Row_AgenciaXEntidad.Item("AG_Nombre_Contacto")

            Consulta_sql = "Select * From TABRETI 
                                            Left Join " & _Global_BaseBk & "Zw_Despachos_Transportistas On CodTransportista = KORETI
                                            Where KORETI = '" & _AG_Transportista & "'"
            Dim _Row_Transportista = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Transportista) Then

                Txt_AG_Transportista.Tag = _AG_Transportista
                Txt_AG_Transportista.Text = _Row_Transportista.Item("NORETI")

            End If

        End If

        Chk_AG_AgenciaxDefDespachos.Checked = _AG_AgenciaxDefDespachos
        Txt_AG_Nombre_Contacto.Text = _AG_Nombre_Contacto

    End Sub

    Private Sub Btn_Buscar_Transportista_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Transportista.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "TABRETI"
        _Filtrar.Campo = "KORETI"
        _Filtrar.Descripcion = "NORETI"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "TRANSPORTISTA"

        Dim _Sql_Filtro_Condicion_Extra = "And KORETI In (Select CodTransportista From " & _Global_BaseBk & "Zw_Despachos_Transportistas Where Mostrar = 1 And Tipo_Envio In ('AG',''))"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _Sql_Filtro_Condicion_Extra,
                               Nothing, False, True) Then

            Dim _Tbl_Transportista As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Transportista.Rows(0)

            Dim _Koreti = _Row.Item("Codigo").ToString.Trim
            Dim _Noreti = _Row.Item("Descripcion").ToString.Trim

            Txt_AG_Transportista.Tag = _Koreti
            Txt_AG_Transportista.Text = _Noreti

        End If

    End Sub

    Private Sub Btn_Quitar_Transportista_Click(sender As Object, e As EventArgs) Handles Btn_Quitar_Transportista.Click

        Txt_AG_Transportista.Tag = String.Empty
        Txt_AG_Transportista.Text = String.Empty

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _CodEntidad As String = _Row_Entidad.Item("KOEN")
        Dim _CodSucEntidad As String = _Row_Entidad.Item("SUEN")

        Dim _AG_AgenciaxDefDespachos = Convert.ToInt32(Chk_AG_AgenciaxDefDespachos.Checked)
        Dim _AG_Transportista = Txt_AG_Transportista.Tag
        Dim _AG_Nombre_Contacto = Txt_AG_Nombre_Contacto.Text

        If String.IsNullOrEmpty(_AG_Transportista) And Chk_AG_AgenciaxDefDespachos.Checked Then
            MessageBoxEx.Show(Me, "Falta el transportista", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Entidades Set " & vbCrLf &
                       "AG_AgenciaxDefDespachos = " & _AG_AgenciaxDefDespachos & ", AG_Transportista = '" & _AG_Transportista & "', AG_Nombre_Contacto = '" & _AG_Nombre_Contacto & "'" & vbCrLf &
                       "Where CodEntidad = '" & _CodEntidad & "' And CodSucEntidad = '" & _CodSucEntidad & "'"
        _Sql.Fx_Ejecutar_Consulta(Consulta_sql)

        Grabar = True
        Me.Close()

    End Sub

    Private Sub Frm_Agencia_Entidad_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
