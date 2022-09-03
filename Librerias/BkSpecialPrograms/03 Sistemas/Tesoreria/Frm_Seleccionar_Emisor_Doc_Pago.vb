Imports DevComponents.DotNetBar

Public Class Frm_Seleccionar_Emisor_Doc_Pago

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Tabendp As DataRow

    'Enum Enum_Tidpen
    '    CH
    '    TJ
    '    DP
    'End Enum

    Dim _Tidpen As Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago 'Enum_Tidpen

    Public ReadOnly Property Pro_Row_Tabendp() As DataRow
        Get
            Return _Row_Tabendp
        End Get
    End Property

    Public Sub New(ByVal Tidpen As Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        _Tidpen = Tidpen

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Aceptar.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Seleccionar_TipoPago_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        InsertarBotonenGrilla(Grilla, "BtnImagen", "Est.", "Estado", 0, _Tipo_Boton.Imagen)

        Sb_Actualizar_Grilla()

        AddHandler Grilla.CellDoubleClick, AddressOf Sb_Seleccionar_Emisor
        AddHandler Btn_Aceptar.Click, AddressOf Sb_Seleccionar_Emisor
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Me.ActiveControl = Txtdescripcion

        'AddHandler Grilla.CellFormatting, AddressOf Sb_Grilla_CellFormatting

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Cadena As String _
                             = CADENA_A_BUSCAR(RTrim$(Txtdescripcion.Text), "KOENDP+NOKOENDP+SUENDP" & " LIKE '%")

        Dim _Filtro_Inactivos = String.Empty
        Dim _Filtro_Deposito = String.Empty

        Dim _Tidpen_var As String = _Tidpen.ToString

        If _Tidpen = Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.DP Then
            _Tidpen_var = "CH"
            _Filtro_Deposito = "And CTACTE <> ''"
        End If

        Consulta_sql = "Select * From TABENDP
                        Where KOENDP+NOKOENDP+SUENDP Like '%" & _Cadena & "%' And TIDPEN = '" & _Tidpen_var & "'
                        " & _Filtro_Deposito & "   
                        Order by TIDPEN,KOENDP"

        With Grilla

            .DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

            OcultarEncabezadoGrilla(Grilla, False)

            .Columns("BtnImagen").Width = 30
            .Columns("BtnImagen").HeaderText = "Img"
            .Columns("BtnImagen").Visible = True

            .Columns("KOENDP").Visible = True
            .Columns("KOENDP").HeaderText = "Cód."
            .Columns("KOENDP").Width = 40
            .Columns("KOENDP").DisplayIndex = 1

            .Columns("SUENDP").Visible = True
            .Columns("SUENDP").HeaderText = "Suc."
            .Columns("SUENDP").Width = 30
            .Columns("SUENDP").DisplayIndex = 2

            .Columns("NOKOENDP").Visible = True

            If _Tidpen = Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.CH Or _Tidpen = Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.DP Then
                .Columns("NOKOENDP").HeaderText = "Banco"
            ElseIf _Tidpen = Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.TJ Then
                .Columns("NOKOENDP").HeaderText = "Tarjeta"
            End If

            .Columns("NOKOENDP").Width = 220
            .Columns("NOKOENDP").DisplayIndex = 3

        End With

        If Grilla.Rows.Count <= 30 Then

            For Each _Row As DataGridViewRow In Grilla.Rows

                Select Case _Tidpen
                    Case Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.CH
                        _Row.Cells("BtnImagen").Value = Lista_Imagnes_Pago_16.Images.Item(0)
                    Case Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.TJ
                        _Row.Cells("BtnImagen").Value = Lista_Imagnes_Pago_16.Images.Item(1)
                    Case Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.DP
                        _Row.Cells("BtnImagen").Value = Lista_Imagnes_Pago_16.Images.Item(2)
                    Case Else
                        _Row.Cells("BtnImagen").Value = Lista_Imagnes_Pago_16.Images.Item(3)
                End Select

            Next

        End If

    End Sub

    Private Sub Txtdescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtdescripcion.TextChanged
        Sb_Actualizar_Grilla()
    End Sub

    Sub Sb_Seleccionar_Emisor()

        Try
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Tidpen = _Fila.Cells("TIDPEN").Value
            Dim _Koendp = _Fila.Cells("KOENDP").Value
            Dim _Suendp = _Fila.Cells("SUENDP").Value

            Consulta_sql = "Select Top 1 * From TABENDP " & vbCrLf &
                           "Where KOENDP = '" & _Koendp & "' And TIDPEN = '" & _Tidpen & "' And SUENDP = '" & _Suendp & "'"

            _Row_Tabendp = _Sql.Fx_Get_DataRow(Consulta_sql)

            Me.Close()
        Catch ex As Exception
            MessageBoxEx.Show(Me, "Debe seleccionar un registro", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub Frm_Seleccionar_TipoPago_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
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
            MessageBox.Show(ex.Message, "vb.net",
         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Grilla_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grilla.KeyDown
        If e.KeyValue = Keys.Enter Then
            SendKeys.Send("{F2}")
            'SendKeys.Send("{LEFT}")
            e.Handled = True
            Sb_Seleccionar_Emisor()
        End If
    End Sub

    'Private Sub Sb_Grilla_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)

    '    Try
    '        Select Case _Tidpen
    '            Case Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.CH
    '                Grilla.Rows(e.RowIndex).Cells("BtnImagen").Value = Lista_Imagnes_Pago_16.Images.Item(0)
    '            Case Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.TJ
    '                Grilla.Rows(e.RowIndex).Cells("BtnImagen").Value = Lista_Imagnes_Pago_16.Images.Item(1)
    '            Case Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.DP
    '                Grilla.Rows(e.RowIndex).Cells("BtnImagen").Value = Lista_Imagnes_Pago_16.Images.Item(2)
    '            Case Else
    '                Grilla.Rows(e.RowIndex).Cells("BtnImagen").Value = Lista_Imagnes_Pago_16.Images.Item(3)
    '        End Select
    '    Catch ex As Exception

    '    End Try

    'End Sub

End Class
