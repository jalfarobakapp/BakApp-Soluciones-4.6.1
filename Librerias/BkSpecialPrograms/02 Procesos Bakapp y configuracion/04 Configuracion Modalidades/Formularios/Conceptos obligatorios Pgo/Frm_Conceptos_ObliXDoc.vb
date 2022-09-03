Imports DevComponents.DotNetBar
Public Class Frm_Conceptos_ObliXDoc

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Modalidad As String

    Dim _Tbl_Conceptos As DataTable

    Public Sub New(_Modalidad As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Me._Modalidad = _Modalidad

    End Sub

    Private Sub Frm_Conceptos_ObliXDoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Cargar_Tabla()

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub

    Sub Sb_Cargar_Tabla()

        Consulta_sql = "Select Id, Modalidad, Tido, Tidp, Concepto, NOKOCT,NombreTabla,DescripcionTabla
                        From " & _Global_BaseBk & "Zw_Docu_ObligPg
                        Left Join TABCT On KOCT = Concepto
                        Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones On Tabla = 'TIDP_Cli' And CodigoTabla = Tidp 
                        Where Modalidad = '" & _Modalidad & "'"
        _Tbl_Conceptos = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _DisplayIndex = 0

        With Grilla

            .DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Tido").Visible = True
            .Columns("Tido").HeaderText = "TD"
            .Columns("Tido").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Tido").Width = 30
            .Columns("Tido").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Tidp").Visible = True
            .Columns("Tidp").HeaderText = "PG"
            .Columns("Tidp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Tidp").Width = 30
            .Columns("Tidp").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreTabla").Visible = True
            .Columns("NombreTabla").HeaderText = "Tipo pago"
            .Columns("NombreTabla").Width = 150
            .Columns("NombreTabla").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Concepto").Visible = True
            .Columns("Concepto").HeaderText = "Concepto"
            .Columns("Concepto").Width = 150
            .Columns("Concepto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOCT").Visible = True
            .Columns("NOKOCT").HeaderText = "Descripción"
            .Columns("NOKOCT").Width = 200
            .Columns("NOKOCT").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1


        End With

    End Sub

    Private Sub Btn_Agregar_Click(sender As Object, e As EventArgs) Handles Btn_Agregar.Click

        Dim Fm As New Frm_Conceptos_ObliXDoc_Ing(Me._Modalidad, 0, False)
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Cargar_Tabla()

    End Sub

    Private Sub Btn_Notif_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Notif_Eliminar.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id = _Fila.Cells("Id").Value

        If MessageBoxEx.Show(Me, "¿Confirma la eliminación de la cuenta?", "Eliminar cuenta",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Docu_ObligPg Where Id = " & _Id
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
            End If

        End If

    End Sub

    Private Sub Btn_Notif_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Notif_Editar.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id = _Fila.Cells("Id").Value

        Dim Fm As New Frm_Conceptos_ObliXDoc_Ing(Me._Modalidad, _Id, True)
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Cargar_Tabla()

    End Sub
    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    ShowContextMenu(Menu_Contextual_03)

                End If
            End With
        End If
    End Sub

    Private Sub Frm_Conceptos_ObliXDoc_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
