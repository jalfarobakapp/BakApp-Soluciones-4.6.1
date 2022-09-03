Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Nomenclaturas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Cl_Nomenclatura As New Cl_Nomenclatura

    Dim _Ds As DataSet
    Dim _Dv As New DataView
    Dim _Dv2 As New DataView

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Nomenclaturas, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Productos, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            Txt_Buscar_Nomenclatura.FocusHighlightEnabled = False
        End If

    End Sub

    Private Sub Frm_Nomenclaturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler Grilla_Nomenclaturas.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Productos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        AddHandler Grilla_Nomenclaturas.MouseDown, AddressOf Grilla_Detalle_MouseDown

    End Sub

    Sub Sb_Actualizar_Grilla()

        _Cl_Nomenclatura.Sb_Llenar_Ds_Nomenclatura(Txt_Buscar_Nomenclatura.Text)

        _Ds = _Cl_Nomenclatura.Ds_Nomenclaturas

        Grilla_Nomenclaturas.DataSource = _Ds
        Grilla_Nomenclaturas.DataMember = "Nomenclaturas"

        Grilla_Productos.DataSource = _Ds
        Grilla_Productos.DataMember = "Nomenclaturas.Rel_Nom_vs_Prod"

        OcultarEncabezadoGrilla(Grilla_Nomenclaturas, True)
        OcultarEncabezadoGrilla(Grilla_Productos, True)

        Dim _DisplayIndex = 0

        With Grilla_Nomenclaturas

            .Columns("CODIGO").Visible = True
            .Columns("CODIGO").HeaderText = "Código"
            .Columns("CODIGO").Width = 100
            .Columns("CODIGO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("DESCRIPTOR").Visible = True
            .Columns("DESCRIPTOR").HeaderText = "Nombre Nomenclatura"
            .Columns("DESCRIPTOR").Width = 340
            .Columns("DESCRIPTOR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CANTIDAD").Visible = True
            .Columns("CANTIDAD").HeaderText = "Cantidad"
            .Columns("CANTIDAD").Width = 65
            .Columns("CANTIDAD").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("UDAD").Visible = True
            .Columns("UDAD").HeaderText = "Ud"
            .Columns("UDAD").Width = 35
            .Columns("UDAD").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Estado").Visible = True
            .Columns("Estado").HeaderText = "Esatdo"
            .Columns("Estado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Estado").Width = 60
            .Columns("Estado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        'For Each _Fila As DataGridViewRow In Grilla_Nomenclaturas.Rows

        '    Dim _Grado = _Fila.Cells("Grado_Prioridad").Value

        '    If _Grado = 1 Then

        '        _Fila.Cells("Grado_Prioridad").Style.ForeColor = Color.White
        '        _Fila.Cells("Grado_Prioridad").Style.BackColor = Color.Red

        '    ElseIf _Grado = 2 Then

        '        _Fila.Cells("Grado_Prioridad").Style.BackColor = Color.Yellow

        '    Else

        '        _Fila.Cells("Grado_Prioridad").Style.ForeColor = Color.White
        '        _Fila.Cells("Grado_Prioridad").Style.BackColor = Color.White

        '    End If

        'Next

        With Grilla_Productos

            _DisplayIndex = 0

            .Columns("KOPR").Visible = True
            .Columns("KOPR").HeaderText = "Código"
            .Columns("KOPR").Width = 100
            .Columns("KOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Width = 500
            .Columns("NOKOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Grilla_Nomenclaturas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Nomenclaturas.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Nomenclaturas.Rows(Grilla_Nomenclaturas.CurrentRow.Index)

        Dim _Codigo = _Fila.Cells("CODIGO").Value

        Dim _Cl_Nomenclatura As New Cl_Nomenclatura
        _Cl_Nomenclatura.Sb_Cargar_Nomenclatura(_Codigo)

        _Cl_Nomenclatura.Accion = Cl_Nomenclatura.Enum_Accion.Editar

        Dim Fm As New Frm_Mant_Nomenclatura
        Fm.Cl_Nomenclatura = _Cl_Nomenclatura
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Txt_Buscar_Nomenclatura_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Buscar_Nomenclatura.KeyDown

        If e.KeyValue = Keys.Enter Or
           e.KeyValue = Keys.Space Then
            Sb_Actualizar_Grilla()
        End If

        If e.KeyValue = Keys.Back And String.IsNullOrEmpty(Txt_Buscar_Nomenclatura.Text) Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Btn_Mnu_Enviar_Al_Meson_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Enviar_Al_Meson.Click

        Dim _Fila As DataGridViewRow = Grilla_Nomenclaturas.Rows(Grilla_Nomenclaturas.CurrentRow.Index)

        Dim _Codigo = _Fila.Cells("CODIGO").Value
        Dim _Codigo_New As String
        Dim _Descripcion_New As String

        Dim _Aceptar As Boolean

        _Aceptar = InputBox_Bk(Me, "Código de nomenclatura", "Copiar nomenclatura", _Codigo_New, False,, 20, True)

        If _Aceptar Then

            Dim _Reg = CBool(_Sql.Fx_Cuenta_Registros("PNPE", "CODIGO = '" & _Codigo_New & "'"))

            If _Reg Then
                MessageBoxEx.Show(Me, "Ese código nomenclatura ya existe", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Consulta_sql = "Select KOPR,NOKOPR From MAEPR Where KOPR = '" & _Codigo_New & "'"
            Dim _Row_Producto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Producto) Then
                _Descripcion_New = _Row_Producto.Item("NOKOPR").ToString.Trim
            End If

            _Aceptar = InputBox_Bk(Me, "Descripcion de nomenclatura", "Copiar nomenclatura", _Descripcion_New, False,, 20, True)

            If _Aceptar Then

                If _Cl_Nomenclatura.Fx_Copiar_Nomenclatura(_Codigo, _Codigo_New, _Descripcion_New) Then
                    Txt_Buscar_Nomenclatura.Text = _Codigo_New
                    Sb_Actualizar_Grilla()
                End If

            End If


        End If

    End Sub

    Private Sub Grilla_Detalle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            With sender

                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)

                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                Else
                    Return
                End If

                ShowContextMenu(Menu_Contextual_Potpr)

            End With

        End If

    End Sub

    Private Sub Grilla_Detalle_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
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


End Class
