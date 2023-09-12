Imports DevComponents.DotNetBar

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

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Chk_MostrarSoloHabilitados.CheckedChanged, AddressOf Chk_MostrarSoloHabilitados_CheckedChanged

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String

        If Chk_MostrarSoloHabilitados.Checked Then
            _Condicion = "Where Uss.Habilitado = 1"
        End If

        Consulta_Sql = "Select TABFU.*,Uss.*" & vbCrLf &
                       "From TABFU" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_Comisiones_Fun Uss On KOFU = Uss.CodFuncionario" & vbCrLf &
                       _Condicion
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

            .Columns("NOKOFU").Width = 360
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

        For Each row As DataGridViewRow In Grilla.Rows

            Dim _Habilitado As Boolean = row.Cells("Habilitado").Value

            If Not _Habilitado Then
                row.DefaultCellStyle.ForeColor = Color.Gray
            End If

        Next

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
                Dim _Grabar As Boolean = Fm.Grabar
                Fm.Dispose()

                If Not _Grabar Then
                    Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Comisiones_Fun Where Id = " & _Id
                    _Sql.Ej_consulta_IDU(Consulta_Sql)
                    Return
                End If

            End If

            Sb_Actualizar_Grilla()

        End If


    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value
        Dim _CodFuncionario As String = _Fila.Cells("CodFuncionario").Value

        Dim Fm As New Frm_Cms_FuncMant(_Id)
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            Sb_Actualizar_Grilla()
        End If
        Fm.Dispose()

    End Sub

    Private Sub Btn_EditarFuncionario_Click(sender As Object, e As EventArgs) Handles Btn_EditarFuncionario.Click
        Call Grilla_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Btn_QuitarVendedor_Click(sender As Object, e As EventArgs) Handles Btn_QuitarVendedor.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value
        Dim _CodFuncionario As String = _Fila.Cells("CodFuncionario").Value

        Dim _Index As Integer = _Fila.Index

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Comisiones_Lin", "CodFuncionario = '" & _CodFuncionario & "'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "Este funcionario no puede ser eliminado, ya que cuenta con comisiones asociadas." & vbCrLf &
                              "Para quitarlo de esta lista se sugiere deshabilitar la cuenta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Confirma quitar a este vendedor del tratamiento?", "Quitar vendedor",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Comisiones_Fun Where CodFuncionario = '" & _CodFuncionario & "'" & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Comisiones_Mis Where CodFuncionario = '" & _CodFuncionario & "'" & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Comisiones_DetFlTbl" & vbCrLf &
                           "Where Id_Det Not In (Select Id From " & _Global_BaseBk & "Zw_Comisiones_Det) And Id_Det <> 0"

            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then
                Grilla.Rows.RemoveAt(_Index)
            End If

        End If

    End Sub

    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_01)
                End If
            End With
        End If
    End Sub

    Private Sub Chk_MostrarSoloHabilitados_CheckedChanged(sender As Object, e As EventArgs)
        Sb_Actualizar_Grilla()
    End Sub
End Class
