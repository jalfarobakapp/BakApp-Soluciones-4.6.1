'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Inf_Ventas_X_Vendedor_02

    Public _Titulo_Del_Grafico As String
    Public _TblVentas_X_vendedor As DataTable

    Private Sub Frm_Inf_Ventas_X_Vendedor_02_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_RowsPostPaint

    End Sub


    Sub Sb_Actualizar_Grilla()

        With Grilla

            .DataSource = _TblVentas_X_vendedor

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("KOFULIDO").Width = 30
            .Columns("KOFULIDO").HeaderText = "Cantidad"
            .Columns("KOFULIDO").Visible = True

            .Columns("NOKOFU").Width = 200
            .Columns("NOKOFU").HeaderText = "Cantidad"
            .Columns("NOKOFU").Visible = True

            .Columns("VALORNETO").Width = 90
            .Columns("VALORNETO").HeaderText = "Vta. Neta Vendedor"
            .Columns("VALORNETO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VALORNETO").DefaultCellStyle.Format = "###,##.##"
            .Columns("VALORNETO").Visible = True

            .Columns("VANEDO").Width = 85
            .Columns("VANEDO").HeaderText = "Neto"
            .Columns("VANEDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VANEDO").DefaultCellStyle.Format = "###,##.##"
            .Columns("VANEDO").Visible = True

            .Columns("VAIVDO").Width = 85
            .Columns("VAIVDO").HeaderText = "Iva"
            .Columns("VAIVDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VAIVDO").DefaultCellStyle.Format = "###,##.##"
            .Columns("VAIVDO").Visible = True

            .Columns("VAABDO").Width = 85
            .Columns("VAABDO").HeaderText = "Total"
            .Columns("VAABDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VAABDO").DefaultCellStyle.Format = "###,##.##"
            .Columns("VAABDO").Visible = True

            .Columns("VASADO").Width = 85
            .Columns("VASADO").HeaderText = "Abonado"
            .Columns("VASADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VASADO").DefaultCellStyle.Format = "###,##.##"
            .Columns("VASADO").Visible = True

        End With


    End Sub

    Sub Sb_RowsPostPaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
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
            MessageBox.Show(ex.Message, "vb.net", _
         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
       Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Btn_Procesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Frm_Inf_Ventas_X_Vendedor_02_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Ver_Grafico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Grafico.Click

        Dim Fm As New Frm_Inf_Ventas_X_Vendedor_03
        Fm._TblGrafico = _TblVentas_X_vendedor
        Fm._Titulo_Del_Grafico = _Titulo_Del_Grafico
        Fm.ShowDialog(Me)

    End Sub
End Class