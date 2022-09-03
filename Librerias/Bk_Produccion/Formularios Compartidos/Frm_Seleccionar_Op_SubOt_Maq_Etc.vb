
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Seleccionar_Op_SubOt_Maq_Etc

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim _Tbl_Tabla As DataTable
    Dim _Row As DataRow

    Dim _Campo_Codigo As String
    Dim _Campo_Descripcion As String

    Public Property Pro_Tbl_Tabla() As DataTable
        Get
            Return _Tbl_Tabla
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Tabla = value
        End Set
    End Property
    Public Property Pro_Row() As DataRow
        Get
            Return _Row
        End Get
        Set(ByVal value As DataRow)
            _Row = value
        End Set
    End Property

    Public Sub New(ByVal Campo_Codigo As String, ByVal Campo_Descripcion As String, ByVal Tbl_Tabla As DataTable)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 10), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        _Campo_Codigo = Campo_Codigo
        _Campo_Descripcion = Campo_Descripcion
        _Tbl_Tabla = Tbl_Tabla

    End Sub

    Private Sub Frm_Seleccionar_Operacion_Lod(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_RowsPostPaint

        If Not (_Tbl_Tabla Is Nothing) Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Sub Sb_Actualizar_Grilla()

        With Grilla

            .DataSource = _Tbl_Tabla

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns(_Campo_Codigo).Visible = True
            .Columns(_Campo_Codigo).HeaderText = "Código"
            .Columns(_Campo_Codigo).Width = 120
            .Columns(_Campo_Codigo).DisplayIndex = 0

            .Columns(_Campo_Descripcion).Visible = True
            .Columns(_Campo_Descripcion).HeaderText = "Descripción"
            .Columns(_Campo_Descripcion).Width = 450
            .Columns(_Campo_Descripcion).DisplayIndex = 1

        End With

    End Sub


    Private Sub Btn_Seleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Seleccionar.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Codigo As String = _Fila.Cells(_Campo_Codigo).Value

        Dim foundRows() As Data.DataRow
        foundRows = _Tbl_Tabla.Select(_Campo_Codigo & " = '" & _Codigo & "'")

        _Row = foundRows(0)

        If Not (_Row Is Nothing) Then
            Me.Close()
        End If

    End Sub

    Sub Sb_RowsPostPaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < Grilla.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If Grilla.RowHeadersWidth < CInt(size.Width + 20) Then
                Grilla.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "vb.net",
         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        Call Btn_Seleccionar_Click(Nothing, Nothing)
    End Sub

    Private Sub Grilla_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grilla.KeyDown
        If e.KeyValue = Keys.Enter Then
            SendKeys.Send("{LEFT}")
            e.Handled = True
            Call Btn_Seleccionar_Click(Nothing, Nothing)
        End If
    End Sub
End Class
