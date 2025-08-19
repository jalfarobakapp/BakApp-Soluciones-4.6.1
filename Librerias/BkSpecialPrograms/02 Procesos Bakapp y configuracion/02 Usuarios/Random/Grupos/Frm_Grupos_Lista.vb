Imports DevComponents.DotNetBar

Public Class Frm_Grupos_Lista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Grupos As DataTable
    Dim _Tbl_Usuarios As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Grupos, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Formato_Generico_Grilla(Grilla_Agentes, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Grupos_User_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla_Grupos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Agentes.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

        AddHandler Grilla_Grupos.CellEnter, AddressOf Sb_Grilla_Grupos_CellEnter
        AddHandler Grilla_Grupos.MouseDown, AddressOf Sb_Grilla_Grupos_MouseDown

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select Tg.*,Tf.NOKOFU From TABFUGE Tg" & vbCrLf &
                       "Left Join TABFU Tf On Tf.KOFU = Tg.KOFUJEFE"
        _Tbl_Grupos = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla_Grupos

            .DataSource = _Tbl_Grupos

            OcultarEncabezadoGrilla(Grilla_Grupos)

            Dim _DisplayIndex = 0

            .Columns("KOGRU").Visible = True
            .Columns("KOGRU").HeaderText = "Grupo"
            .Columns("KOGRU").Width = 80
            .Columns("KOGRU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOGRU").Visible = True
            .Columns("NOKOGRU").HeaderText = "Nombre del Grupo"
            .Columns("NOKOGRU").Width = 165
            .Columns("NOKOGRU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("KOFUJEFE").Visible = True
            .Columns("KOFUJEFE").HeaderText = "CJA"
            .Columns("KOFUJEFE").Width = 30
            .Columns("KOFUJEFE").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOFU").Visible = True
            .Columns("NOKOFU").HeaderText = "Jefe/Asistente"
            .Columns("NOKOFU").Width = 165
            .Columns("NOKOFU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Sb_Grilla_Grupos_CellEnter(sender As Object, e As DataGridViewCellEventArgs)

        Dim _Fila As DataGridViewRow = Grilla_Grupos.CurrentRow
        Dim _Kogru As String = _Fila.Cells("KOGRU").Value

        Consulta_sql = "Select Td.*,Tf.NOKOFU From TABFUGD Td" & vbCrLf &
                       "Left Join TABFU Tf On Tf.KOFU = Td.KOFU" & vbCrLf &
                       "Where Td.KOGRU = '" & _Kogru & "'" & vbCrLf &
                       "Order By ORDEN"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla_Agentes

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla_Agentes)

            Dim _DisplayIndex = 0

            .Columns("KOFU").Visible = True
            .Columns("KOFU").HeaderText = "Código"
            .Columns("KOFU").Width = 80
            .Columns("KOFU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOFU").Visible = True
            .Columns("NOKOFU").HeaderText = "Nombre del Usuario"
            .Columns("NOKOFU").Width = 360
            .Columns("NOKOFU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("ORDEN").Visible = True
            '.Columns("ORDEN").HeaderText = "Código"
            '.Columns("ORDEN").Width = 80
            '.Columns("ORDEN").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

        End With

    End Sub

    Private Sub Grilla_Grupos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Grupos.CellDoubleClick

        If e Is Nothing OrElse e.RowIndex < 0 Then Return
        Dim _Fila As DataGridViewRow = Grilla_Grupos.Rows(e.RowIndex)
        Sb_Editar_Grupo(_Fila)

        'Dim _Fila As DataGridViewRow = Grilla_Grupos.CurrentRow

        'If e.RowIndex < 0 OrElse _Fila Is Nothing Then
        '    Return
        'End If
        'Dim _Kogru As String = _Fila.Cells("KOGRU").Value

        'Dim Fm As New Frm_Grupos_Usuarios(_Kogru)
        'Fm.ShowDialog(Me)

        'If Fm.Grabar Then
        '    _Fila.Cells("NOKOGRU").Value = Fm._Cl_GruposRD.Tabfuge.NOKOGRU
        '    _Fila.Cells("KOFUJEFE").Value = Fm._Cl_GruposRD.Tabfuge.KOFUJEFE
        '    Call Sb_Grilla_Grupos_CellEnter(Nothing, Nothing)
        'End If
        'Fm.Dispose()

    End Sub

    Private Sub Sb_Grilla_Grupos_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
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

    Private Sub Btn_Mnu_EditarGrupo_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_EditarGrupo.Click
        Dim _Fila As DataGridViewRow = Grilla_Grupos.CurrentRow
        Sb_Editar_Grupo(_Fila)
    End Sub

    Private Sub Btn_Mnu_EliminarGrupo_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_EliminarGrupo.Click

        If Not Fx_Tiene_Permiso(Me, "Mode0004") Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla_Grupos.CurrentRow

        If _Fila Is Nothing Then
            Return
        End If

        Dim _Kogru As String = _Fila.Cells("KOGRU").Value.ToString.Trim
        Dim _Nokogru As String = _Fila.Cells("NOKOGRU").Value.ToString.Trim

        If MessageBoxEx.Show(Me, "¿Está seguro de eliminar el grupo " & _Kogru & " - " & _Nokogru & "?", "Eliminar grupo",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Consulta_sql = "Delete TABFUGE Where KOGRU = '" & _Kogru & "'" & vbCrLf &
                           "Delete TABFUGD Where KOGRU = '" & _Kogru & "'"
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                MessageBoxEx.Show(Me, "Grupo eliminado correctamente", "Eliminar Grupo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Sb_Actualizar_Grilla()
                If Grilla_Grupos.RowCount = 0 Then
                    Grilla_Agentes.DataSource = Nothing
                End If
            End If

        End If

    End Sub

    Private Sub Btn_Crear_Grupo_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Grupo.Click

        If Not Fx_Tiene_Permiso(Me, "Mode0002") Then
            Return
        End If

        Dim _Grabar As Boolean
        Dim _Kogru As String = String.Empty

        Dim Fm As New Frm_Grupos_Usuarios(_Kogru)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _Kogru = Fm._Kogru
        Fm.Dispose()

        If _Grabar Then
            Sb_Actualizar_Grilla()
            BuscarDatoEnGrilla(_Kogru, "KOGRU", Grilla_Grupos)
        End If

    End Sub

    Private Sub Sb_Editar_Grupo(_Fila As DataGridViewRow)

        If Not Fx_Tiene_Permiso(Me, "Mode0003") Then
            Return
        End If

        If _Fila Is Nothing Then Return

        Dim _Kogru As String = _Fila.Cells("KOGRU").Value.ToString()
        Dim Fm As New Frm_Grupos_Usuarios(_Kogru)
        Fm.ShowDialog(Me)

        If Fm.Grabar Then
            _Fila.Cells("NOKOGRU").Value = Fm._Cl_GruposRD.Tabfuge.NOKOGRU
            _Fila.Cells("KOFUJEFE").Value = Fm._Cl_GruposRD.Tabfuge.KOFUJEFE
            Call Sb_Grilla_Grupos_CellEnter(Nothing, Nothing)
        End If
        Fm.Dispose()

    End Sub

End Class
