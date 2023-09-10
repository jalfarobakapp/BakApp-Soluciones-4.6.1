Public Class Frm_OfDinamFicha

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Codigo As String
    Dim _Row_Maeeres As DataRow
    Dim _Tbl_Listas As DataTable

    Public Property Grabar As Boolean

    Public Sub New(_Codigo As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Codigo = _Codigo

        If Not String.IsNullOrEmpty(_Codigo) Then

            Consulta_sql = "Select * From MAEERES Where CODIGO = '" & _Codigo & "' And TIPORESE = 'din'"
            _Row_Maeeres = _Sql.Fx_Get_DataRow(Consulta_sql)

        End If

    End Sub

    Private Sub Frm_OfDinamFicha_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Chk_Tipotrat1.CheckedChanged, AddressOf Chk_Tipotrat_CheckedChanged
        AddHandler Chk_Tipotrat2.CheckedChanged, AddressOf Chk_Tipotrat_CheckedChanged
        AddHandler Chk_Tipotrat3.CheckedChanged, AddressOf Chk_Tipotrat_CheckedChanged
        AddHandler Chk_Tipotrat4.CheckedChanged, AddressOf Chk_Tipotrat_CheckedChanged

        caract_combo(Cmb_Concepto)
        Consulta_sql = "SELECT KOCT AS Padre,LTRIM(RTRIM(KOCT))+'-'+LTRIM(RTRIM(NOKOCT)) AS Hijo FROM TABCT WHERE TICT = 'D' ORDER BY Hijo"
        Cmb_Concepto.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Concepto.SelectedValue = ""

        If Not IsNothing(_Row_Maeeres) Then

            Txt_Codigo.Enabled = False
            Txt_Codigo.Text = _Row_Maeeres.Item("CODIGO")
            Txt_Descriptor.Text = _Row_Maeeres.Item("DESCRIPTOR")
            Dtp_Fioferta.Value = _Row_Maeeres.Item("FIOFERTA")
            Dtp_Ftoferta.Value = _Row_Maeeres.Item("FTOFERTA")
            Txt_Udad.Text = _Row_Maeeres.Item("UDAD")
            Input_Cantmin.Value = _Row_Maeeres.Item("CANTMIN")
            Chk_Rangos.Checked = _Row_Maeeres.Item("RANGOS")

            Select Case _Row_Maeeres.Item("TIPOTRAT")
                Case "1"
                    Chk_Tipotrat1.Checked = True
                Case "2"
                    Chk_Tipotrat2.Checked = True
                Case "3"
                    Chk_Tipotrat3.Checked = True
                Case "4"
                    Chk_Tipotrat4.Checked = True
                Case Else
                    Chk_Tipotrat1.Checked = True
            End Select

            Txt_Valdesc.Text = _Row_Maeeres.Item("VALDESC")
            Txt_Ecupordesc.Text = _Row_Maeeres.Item("ECUPORDESC")
            Cmb_Concepto.SelectedValue = _Row_Maeeres.Item("CONCEPTO")

            Txt_Listas.Text = _Row_Maeeres.Item("LISTAS")

            Dim _Listas As String = Txt_Listas.Text.Replace("TABPP", "")
            Dim _ListasPr() = _Listas.Split("_")

            Dim _Filtro_Listas As String = Generar_Filtro_IN_Arreglo(_ListasPr, False)

            If _Filtro_Listas <> "()" Then

                Consulta_sql = "Select Cast(1 As Bit) As Chk,KOLT As Codigo,NOKOLT As Descripcion From TABPP Where KOLT In " & _Filtro_Listas
                _Tbl_Listas = _Sql.Fx_Get_Tablas(Consulta_sql)

            End If

            Chk_Desc_Lun.Checked = (_Row_Maeeres.Item("DESC_LUN") = "S")
            Chk_Desc_Mar.Checked = (_Row_Maeeres.Item("DESC_MAR") = "S")
            Chk_Desc_Mie.Checked = (_Row_Maeeres.Item("DESC_MIE") = "S")
            Chk_Desc_Jue.Checked = (_Row_Maeeres.Item("DESC_JUE") = "S")
            Chk_Desc_Vie.Checked = (_Row_Maeeres.Item("DESC_VIE") = "S")
            Chk_Desc_Sab.Checked = (_Row_Maeeres.Item("DESC_SAB") = "S")
            Chk_Desc_Dom.Checked = (_Row_Maeeres.Item("DESC_DOM") = "S")

        End If


    End Sub

    Private Sub Chk_Tipotrat_CheckedChanged(sender As Object, e As EventArgs)

        If Chk_Tipotrat1.Checked Or Chk_Tipotrat2.Checked Then
            Lbl_Valdesc.Text = "Porcentaje"
        End If

        If Chk_Tipotrat1.Checked Or Chk_Tipotrat2.Checked Then
            Lbl_Valdesc.Text = "Monto"
        End If

    End Sub

    Private Sub Txt_Listas_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Listas.ButtonCustomClick

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "TABPP"
        _Filtrar.Campo = "KOLT"
        _Filtrar.Descripcion = "NOKOLT"

        If _Filtrar.Fx_Filtrar(_Tbl_Listas,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "",
                               False, True) Then

            _Tbl_Listas = _Filtrar.Pro_Tbl_Filtro
            Txt_Listas.Text = String.Empty

            For Each _Lista As DataRow In _Tbl_Listas.Rows
                Txt_Listas.Text += "TABPP" & _Lista.Item("Codigo") & "_"
            Next

        End If

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click
        Grabar = True
        Me.Close()
    End Sub

End Class
