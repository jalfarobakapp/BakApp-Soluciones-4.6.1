Public Class Frm_Cms_Fun

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Tbl_Usuarios As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Comisiones_Funcionarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String

        If Chk_MostrarSoloHabilitados.Checked Then
            _Condicion = "And Uss.Habilitado = 1"
        End If

        Consulta_Sql = "Select TABFU.*,Uss.*" & vbCrLf &
                       "From TABFU" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_Comisiones_Fun Uss On KOFU = Uss.CodFuncionario"
        _Tbl_Usuarios = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Dim _DisplayIndex = 0

        With Grilla

            .DataSource = _Tbl_Usuarios

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("KOFU").Width = 50
            .Columns("KOFU").HeaderText = "Cod."
            .Columns("KOFU").Visible = True
            .Columns("KOFU").ReadOnly = False
            .Columns("KOFU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOFU").Width = 300
            .Columns("NOKOFU").HeaderText = "Nombre funcionario"
            .Columns("NOKOFU").Visible = True
            .Columns("NOKOFU").ReadOnly = False
            .Columns("NOKOFU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("AFP").Width = 40
            .Columns("AFP").HeaderText = "AFP"
            .Columns("AFP").Visible = True
            .Columns("AFP").ReadOnly = False
            .Columns("AFP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Salud").Width = 40
            .Columns("Salud").HeaderText = "Salud"
            .Columns("Salud").Visible = True
            .Columns("Salud").ReadOnly = False
            .Columns("Salud").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Agregar_Funcionario_Click(sender As Object, e As EventArgs) Handles Btn_Agregar_Funcionario.Click

        Dim _Sql_Filtro_Condicion_Extra = "And KOFU Not In (Select CodFuncionario From " & _Global_BaseBk & "Zw_Comisiones_Fun)"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra,
                               False, False, True) Then

            Dim _CodFuncionario = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Dim _Id As Integer

            Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Comisiones_Fun (CodFuncionario,Habilitado) Values ('" & _CodFuncionario & "',1)"
            If _Sql.Ej_Insertar_Trae_Identity(Consulta_Sql, _Id) Then

                Consulta_Sql = "Select TABFU.*,Uss.*" & vbCrLf &
                       "From TABFU" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_Comisiones_Fun Uss On KOFU = Uss.CodFuncionario" & vbCrLf &
                       "Where Uss.Id = " & _Id
                Dim _Row_Funcionario As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                Dim Fm As New Frm_Cms_FuncMant(_Id)
                Fm.Row_Funcionario = _Row_Funcionario
                Fm.ShowDialog(Me)
                Fm.Dispose()

            End If

            Sb_Actualizar_Grilla()

        End If


    End Sub
End Class
