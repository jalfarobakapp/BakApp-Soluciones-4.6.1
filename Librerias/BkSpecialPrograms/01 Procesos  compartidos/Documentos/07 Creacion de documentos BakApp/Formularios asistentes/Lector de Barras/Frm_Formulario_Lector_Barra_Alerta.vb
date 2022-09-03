Imports DevComponents.DotNetBar

Public Class Frm_Formulario_Lector_Barra_Alerta

    Public Sub New(Tbl As DataTable)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Grilla.DataSource = Tbl

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Aceptar.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Formulario_Lector_Barra_Alerta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint


        With Grilla

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Codigo").ReadOnly = True
            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Cód. Principal"
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = 0

            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").Width = 280
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = 1

            .Columns("Cantidad").Width = 60
            .Columns("Cantidad").HeaderText = "Cantidad"
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").DisplayIndex = 2

            .Columns("Problema").ReadOnly = True
            .Columns("Problema").Width = 250
            .Columns("Problema").HeaderText = "Problema"
            .Columns("Problema").Visible = True
            .Columns("Problema").DisplayIndex = 3

        End With

        For Each _Fila As DataGridViewRow In Grilla.Rows
            Dim _Es_Correcto As Boolean = _Fila.Cells("Es_Correcto").Value
            _Fila.Visible = Not _Es_Correcto
        Next

    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        Me.Close()
    End Sub

    Private Sub Grilla_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < sender.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If sender.RowHeadersWidth < CInt(size.Width + 20) Then
                sender.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "vb.net",
         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Frm_Formulario_Lector_Barra_Alerta_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

End Class
