'Imports Lib_Bakapp_VarClassFunc
'Imports BkSpecialPrograms

Public Class Frm_03_Asis_Compra_ProdSinCosto

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public ListaCosto As String
    Public SQL_ As String


    Sub ActualizarGrilla()

        With GrillaXProductosSinCosto

            .RowHeadersVisible = False

            .DataSource = Nothing
            .DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

            .RowTemplate.Height = 18
            .DefaultCellStyle.Font = New Font("Tahoma", 8)
            .AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod

            .Columns("PP01UD").Width = 70
            .Columns("PP01UD").HeaderText = "Costo Ud1"
            .Columns("PP01UD").DefaultCellStyle.Format = "$ ###,##"
            .Columns("PP01UD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            .Columns("PP02UD").Width = 70
            .Columns("PP02UD").HeaderText = "Costo Ud2"
            .Columns("PP02UD").DefaultCellStyle.Format = "$ ###,##"
            .Columns("PP02UD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            .Columns("KOPR").Width = 100
            .Columns("KOPR").HeaderText = "Código"

            .Columns("NOKOPR").Width = 363
            .Columns("NOKOPR").HeaderText = "Descripción"

        End With

    End Sub


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        SQL_ = Consulta_sql
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ActualizarGrilla()

    End Sub

    Private Sub BtnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportarExcel.Click
        ExportarTabla_JetExcel(SQL_, Me)
    End Sub

    Private Sub Frm_03_Asis_Compra_ProdSinCosto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class