Public Class Frm_Cms_AgregarTipos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _CodFuncionario As String
    Dim _TblSucursales As DataTable
    Dim _TblVendedores As DataTable

    Dim _Id As Integer
    Dim _Row_Comisiones_Mis As DataRow

    Public Property Grabar As Boolean

    Public Sub New(_Id As Integer, _CodFuncionario As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


        Me._CodFuncionario = _CodFuncionario
        Me._Id = _Id

        If CBool(_Id) Then

            Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Comisiones_Mis Where Id = " & _Id
            _Row_Comisiones_Mis = _Sql.Fx_Get_DataRow(Consulta_Sql)

        End If

    End Sub

    Private Sub Frm_Cms_AgregarTipos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Rdb_MisVentas.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_VentasXEmpresa.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_VentasXSucursal.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_VentasXVendedores.CheckedChanged, AddressOf Rdb_CheckedChanged


    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If Not CBool(_Id) Then
            Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Comisiones_Mis (CodFuncionario,Descripcion) Values " &
                           "('" & _CodFuncionario & "','" & Txt_Descripcion.Text & "')"
            _Sql.Ej_Insertar_Trae_Identity(Consulta_Sql, _Id)
        End If

        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Comisiones_Mis Set" &
                       " PorcComision = " & De_Num_a_Tx_01(Txt_PorcComision.Text) &
                       ",MisVentas = " & Convert.ToInt32(Rdb_MisVentas.Checked) &
                       ",VentasXEmpresa = " & Convert.ToInt32(Rdb_VentasXEmpresa.Checked) &
                       ",Empresa = " & ModEmpresa &
                       ",VentasXSucursal = " & Convert.ToInt32(Rdb_VentasXSucursal.Checked) &
                       ",XSucursales = '" & Txt_Sucursales.Text & "'" &
                       ",VentasXVendedores = " & Convert.ToInt32(Rdb_VentasXVendedores.Checked) &
                       ",XVendedores = '" & Txt_Vendedores.Text & "'" &
                       ",TieneSC = " & Convert.ToInt32(Chk_TieneSC.Checked) &
                       ",QuitarEntExcluidas = " & Convert.ToInt32(Chk_QuitarEntExcluidas.Checked) & vbCrLf &
                       "Where Id = " & _Id
        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
            Grabar = True
            Me.Close()
        End If

    End Sub

    Private Sub Txt_Sucursales_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Sucursales.ButtonCustomClick

        Dim _Sql_Filtro_Condicion_Extra '= "And KOFU Not In (Select CodFuncionario From " & _Global_BaseBk & "Zw_Comisiones_Fun)"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_TblSucursales,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Sucursales, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            _TblSucursales = _Filtrar.Pro_Tbl_Filtro

        End If

        If _TblSucursales.Rows.Count Then
            Txt_Sucursales.Text = Generar_Filtro_IN(_TblSucursales, "Chk", "Codigo", False, True)
        Else
            Txt_Sucursales.Text = String.Empty
        End If

    End Sub

    Private Sub Txt_Sucursales_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Sucursales.ButtonCustom2Click

    End Sub

    Private Sub Txt_Vendedores_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Vendedores.ButtonCustomClick

        Dim _Sql_Filtro_Condicion_Extra '= "And KOFU Not In (Select CodFuncionario From " & _Global_BaseBk & "Zw_Comisiones_Fun)"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_TblVendedores,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            _TblVendedores = _Filtrar.Pro_Tbl_Filtro

        End If

        If _TblSucursales.Rows.Count Then
            Txt_Vendedores.Text = Generar_Filtro_IN(_TblVendedores, "Chk", "Codigo", False, True)
        Else
            Txt_Vendedores.Text = String.Empty
        End If

    End Sub

    Private Sub Txt_Vendedores_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Vendedores.ButtonCustom2Click

    End Sub

    Private Sub Txt_PorcComision_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_PorcComision.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii, False))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True

        ElseIf e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(".")
        End If
    End Sub

    Private Sub Rdb_CheckedChanged(sender As Object, e As EventArgs)

        Txt_Sucursales.Enabled = Rdb_VentasXSucursal.Checked
        Txt_Vendedores.Enabled = Rdb_VentasXVendedores.Checked

    End Sub

End Class
