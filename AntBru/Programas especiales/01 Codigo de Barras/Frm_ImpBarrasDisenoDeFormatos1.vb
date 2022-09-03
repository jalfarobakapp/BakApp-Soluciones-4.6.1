Imports Funciones_BakApp
Public Class Frm_ImpBarrasDisenoDeFormatos1

    Private Sub Frm_ImpBarrasDisenoDeFormatos1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActualizarGrilla(DataGridView1)
    End Sub

    Function ActualizarGrilla(ByVal Grilla As DataGridView)
        Consulta_sql = "SELECT Semilla,NombreEtiqueta as Etiqueta FROM Zw_Tbl_DisenoBarras"
        'ConsultaSQLGrilla = Consulta_sql

        Ejecutar_consulta_SQL(Consulta_sql, cn1)
        tb = New DataTable
        da.Fill(tb)
        Grilla.DataSource = tb

        Grilla.AutoSizeColumnsMode = _
        DataGridViewAutoSizeColumnsMode.AllCells
        Grilla.Columns("Semilla").Visible = False

    End Function

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        CodEtiqueta = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        Frm_ImpBarrasDisenoDeFormatos.ShowDialog(Me)
        ActualizarGrilla(DataGridView1)
    End Sub
End Class