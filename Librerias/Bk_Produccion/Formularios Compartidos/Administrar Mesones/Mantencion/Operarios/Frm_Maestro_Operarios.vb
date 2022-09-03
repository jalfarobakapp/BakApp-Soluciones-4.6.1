Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Frm_Maestro_Operarios

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    ' Dim _Dv As New DataView

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Maestro_Operarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Tbl_Operarios As DataTable

        Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(Txt_Descripcion.Text), "CODIGOOB+NOMBREOB Like '%")

        Consulta_sql = "Select *," &
                       "Case INACTIVO When 0 Then NOMBREOB Else Rtrim(Ltrim(NOMBREOB))+' - (Operario Inactivo)' End As Nombreob2,Cast((Case INACTIVO When 0 Then 1 Else 0 End) As Bit) As Activo From PMAEOB Where CODIGOOB+NOMBREOB Like '%" & _Cadena & "%'"
        _Tbl_Operarios = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Operarios

            .Columns("CODIGOOB").Width = 120
            .Columns("CODIGOOB").HeaderText = "Código"
            .Columns("CODIGOOB").ReadOnly = True

            .Columns("Nombreob2").Width = 400
            .Columns("Nombreob2").HeaderText = "Nombre operario"
            .Columns("Nombreob2").ReadOnly = True

        End With

        For Each _Fila As DataGridViewRow In Grilla.Rows

            If Not _Fila.Cells("Activo").Value Then
                _Fila.DefaultCellStyle.BackColor = Color.LightYellow
                _Fila.DefaultCellStyle.ForeColor = Color.Black
            End If

        Next

    End Sub

    Private Sub Txt_Descripcion_TextChanged(sender As Object, e As EventArgs) Handles Txt_Descripcion.TextChanged
        If String.IsNullOrEmpty(Txt_Descripcion.Text.Trim) Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Txt_Descripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Descripcion.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Btn_Ver_Jornada_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Jornada.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Codigoob = _Fila.Cells("CODIGOOB").Value

        Dim Fm As New Frm_Jornadas_X_Operario(_Codigoob)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
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

End Class
