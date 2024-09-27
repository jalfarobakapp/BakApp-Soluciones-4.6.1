Imports DevComponents.DotNetBar

Public Class Frm_Permisos_Usuario_Mis_Jefes

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _CodFuncionario As String

    Public Sub New(CodFuncionario As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _CodFuncionario = CodFuncionario

    End Sub

    Private Sub Frm_Permisos_Usuario_Mis_Jefes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Tbl_Empresas As DataTable

        caract_combo(Cmb_Empresa)
        Consulta_Sql = "Select EMPRESA As Padre,EMPRESA+'-'+RAZON AS Hijo From CONFIGP Order By EMPRESA"
        _Tbl_Empresas = _Sql.Fx_Get_DataTable(Consulta_Sql)
        Cmb_Empresa.DataSource = _Tbl_Empresas
        Cmb_Empresa.SelectedValue = "01"

        If _Tbl_Empresas.Rows.Count = 1 Then
            Cmb_Empresa.Enabled = False
        End If

        Sb_Actualizar_Jefes_Por_Empresa()

        AddHandler Cmb_Empresa.SelectedIndexChanged, AddressOf Sb_Actualizar_Jefes_Por_Empresa

    End Sub

    'Private Sub Btn_Buscar_CodJefe_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_CodJefe.Click
    '    Sb_Buscar_Jefe("BUSCAR JEFE DIRECTO", Txt_CodJefe, "And KOFU <> '" & Txt_CodJefeReemplazo.Tag & "'")
    'End Sub

    'Private Sub Btn_Buscar_CodJefeReemplazo_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_CodJefeReemplazo.Click
    '    Sb_Buscar_Jefe("BUSCAR JEFE DE REEMPLAZO", Txt_CodJefeReemplazo, "And KOFU <> '" & Txt_CodJefe.Tag & "'")
    'End Sub

    'Sub Sb_Buscar_Jefe(_Nombre_Encabezado_Informe As String,
    '                   _Txt As DevComponents.DotNetBar.Controls.TextBoxX,
    '                   _Condicion As String)

    '    Dim _Filtrar As New Clas_Filtros_Random(Me)

    '    _Filtrar.Pro_Nombre_Encabezado_Informe = _Nombre_Encabezado_Informe

    '    If _Filtrar.Fx_Filtrar(Nothing,
    '                           Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Condicion,
    '                           Nothing, True, True) Then

    '        Dim _Tbl_Transportista As DataTable = _Filtrar.Pro_Tbl_Filtro

    '        Dim _Row As DataRow = _Tbl_Transportista.Rows(_Tbl_Transportista.Rows.Count - 1)

    '        Dim _Codigo = _Row.Item("Codigo").ToString.Trim
    '        Dim _Descripcion = _Codigo & "-" & _Row.Item("Descripcion").ToString.Trim

    '        If String.IsNullOrEmpty(_Codigo) Then
    '            _Descripcion = String.Empty
    '        End If

    '        _Txt.Tag = _Codigo
    '        _Txt.Text = _Descripcion

    '    End If

    'End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Txt_CodJefe.Tag) And Not String.IsNullOrEmpty(Txt_CodJefeReemplazo.Tag) Then
            MessageBoxEx.Show(Me, "No puede incorporar un Jefe de Reemplazo si no tiene asignado un Jefe",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Usuarios_VS_Jefes 
                        Where Empresa = '" & Cmb_Empresa.SelectedValue & "' And CodFuncionario = '" & _CodFuncionario & "'" & vbCrLf

        If Not String.IsNullOrEmpty(Txt_CodJefe.Tag) Then
            Consulta_Sql += "Insert Into " & _Global_BaseBk & "Zw_Usuarios_VS_Jefes (Empresa,CodFuncionario,CodJefe,CodJefeReemplazo) " &
                            "Values ('" & Cmb_Empresa.SelectedValue & "','" & _CodFuncionario & "','" & Txt_CodJefe.Tag.ToString.Trim & "','" & Txt_CodJefeReemplazo.Tag.ToString.Trim & "')"
        End If

        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Sub Sb_Actualizar_Jefes_Por_Empresa()

        Consulta_Sql = "Select Jefes.*,Isnull(CodJefe+'-'+Tf1.NOKOFU ,'') As Nombre_Jefe,Isnull(CodJefeReemplazo+'-'+Tf2.NOKOFU ,'') As Nombre_JefeReemplazo
                        From " & _Global_BaseBk & "Zw_Usuarios_VS_Jefes Jefes
                            Left Join TABFU Tf1 On Jefes.CodJefe = Tf1.KOFU
                                Left Join TABFU Tf2 On Jefes.CodJefeReemplazo = Tf2.KOFU
                        Where Empresa = '" & Cmb_Empresa.SelectedValue & "' And CodFuncionario = '" & _CodFuncionario & "'"
        Dim _Row_Jefes As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If IsNothing(_Row_Jefes) Then
            Txt_CodJefe.Tag = String.Empty
            Txt_CodJefe.Text = String.Empty
            Txt_CodJefeReemplazo.Tag = String.Empty
            Txt_CodJefeReemplazo.Text = String.Empty
        Else
            Txt_CodJefe.Tag = _Row_Jefes.Item("CodJefe")
            Txt_CodJefe.Text = _Row_Jefes.Item("Nombre_Jefe").ToString.Trim
            Txt_CodJefeReemplazo.Tag = _Row_Jefes.Item("CodJefeReemplazo")
            Txt_CodJefeReemplazo.Text = _Row_Jefes.Item("Nombre_JefeReemplazo").ToString.Trim
        End If

    End Sub

End Class
