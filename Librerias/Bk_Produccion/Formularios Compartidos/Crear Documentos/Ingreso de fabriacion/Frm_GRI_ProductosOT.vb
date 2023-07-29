Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Frm_GRI_ProductosOT

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Tbl_Productos As DataTable
    Public Property FilaSeleccionada As DataRow

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

    End Sub

    Private Sub Frm_GRI_ProductosOT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        With Grilla

            .DataSource = Tbl_Productos

            OcultarEncabezadoGrilla(Grilla)

            .Columns("NREG").Width = 60
            .Columns("NREG").HeaderText = "SubOt"
            .Columns("NREG").ReadOnly = True
            .Columns("NREG").Visible = True

            .Columns("CODIGO").Width = 120
            .Columns("CODIGO").HeaderText = "Producto"
            .Columns("CODIGO").ReadOnly = True
            .Columns("CODIGO").Visible = True

            .Columns("GLOSA").Width = 450
            .Columns("GLOSA").HeaderText = "Nombre producto"
            .Columns("GLOSA").ReadOnly = True
            .Columns("GLOSA").Visible = True

        End With

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Idpotl As Integer = _Fila.Cells("IDPOTL").Value

        Consulta_sql = "Select * From POTL Where IDPOTL = " & _Idpotl
        FilaSeleccionada = _Sql.Fx_Get_DataRow(Consulta_sql)

        Me.Close()

    End Sub

    Private Sub Frm_GRI_ProductosOT_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
        If e.KeyValue = Keys.F5 Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True ' Evita que la tecla ENTER se propague y active la siguiente fila
            Dim dgv As DataGridView = DirectCast(sender, DataGridView)

            If dgv.CurrentRow IsNot Nothing Then
                ' Selecciona toda la fila actual
                dgv.CurrentRow.Selected = True
                Call Grilla_CellDoubleClick(Nothing, Nothing)
            End If
        End If
    End Sub
End Class
