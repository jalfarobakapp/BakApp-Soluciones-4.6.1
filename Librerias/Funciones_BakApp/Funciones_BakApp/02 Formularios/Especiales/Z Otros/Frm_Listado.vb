Public Class Frm_Listado


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Grilla.DataSource = get_Tablas(Consulta_sql, cn1)
        FormatoGrilla()

    End Sub


    Sub FormatoGrilla()

        With Grilla
            .RowTemplate.Height = 18
            .AlternatingRowsDefaultCellStyle.BackColor = Drawing.Color.PaleGoldenrod

            .Columns("Codigo").Width = 80
            .Columns("Codigo").HeaderText = "Código"

            .Columns("Descripcion").Width = 300
            .Columns("Descripcion").HeaderText = "Descrición"

            .Columns("Observacion").Width = 80
            .Columns("Observacion").HeaderText = "Observación"


        End With
    End Sub

    Private Sub BtnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportarExcel.Click
        ExportarTabla_JetExcel(Consulta_sql, Me)
    End Sub
End Class