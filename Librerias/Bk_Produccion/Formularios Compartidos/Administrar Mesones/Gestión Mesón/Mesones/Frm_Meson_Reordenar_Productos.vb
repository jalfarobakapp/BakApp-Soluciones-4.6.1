Imports DevComponents.DotNetBar
Imports BkSpecialPrograms


Public Class Frm_Meson_Reordenar_Productos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String
    Dim _FilaProductos As DataGridViewRow
    Dim _OrdenProducto As Integer
    Dim _Codemeson As String
    Dim _IdOrden As Integer

    Dim _Codmeson As String

    Dim _Tbl_Mesones As DataTable
    Dim _Tbl_Prod_Meson As DataTable
    Dim _Tbl_Prod_Maquinas As DataTable

    Dim _RowIndex As Integer
    Dim _Row_Meson As DataRow

    Dim _Actualizado As Boolean

    Public Property Pro_Actualizado As Boolean
        Get
            Return _Actualizado
        End Get
        Set(value As Boolean)
            _Actualizado = value
        End Set
    End Property

    Public Sub New(Codmeson As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Productos_En_Meson, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        _Codemeson = Codmeson
        Consulta_sql = "Select Top 1 Codmeson,Nommeson,Activo,Virtual,Case Virtual When 1 Then 'VIRTUAL' When 0 Then 'TANGIBLE' End As Tipo" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Pdc_Mesones" & vbCrLf &
                       "Where Codmeson = '" & _Codemeson & "'"
        _Row_Meson = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Private Sub Frm_Meson_Reordenar_Productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "REORDENAMIENTO DEl MESON DE TRABAJO, MESON: " & Trim(_Row_Meson.Item("Codmeson")) & " - " & Trim(_Row_Meson.Item("Nommeson")) & " TIPO:" & _Row_Meson.Item("Tipo")
        Sb_Actualizar_Grilla_Productos_En_Meson()

        Btn_Subir_Producto.Enabled = False
        Btn_Bajar_Producto.Enabled = False

    End Sub

    Sub Sb_Actualizar_Grilla_Productos_En_Meson()

        Consulta_sql = "Select Mp.*,Case Estado When 'PD' Then 'En mesón' When 'MQ' Then 'En Maquina' Else '??' End As Estado_Pr," &
                       "Fecha_Asignacion As Fecha,Fecha_Asignacion As Hora,Cast(1 As Bit) As Movible,Isnull(Pd.Grado,0) AS Grado" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Mp" & vbCrLf &
                       "Left JOIN " & _Global_BaseBk & "Zw_Pdp_OT_Prioridad Pd ON Pd.Idpote=Mp.Idpote" & vbCrLf &
                       "WHERE Codmeson='" & Trim(_Row_Meson.Item("Codmeson")) & "' And Estado In ('PD','MQ') ORDER BY Orden_Meson"
        _Tbl_Prod_Meson = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla_Productos_En_Meson

            .DataSource = _Tbl_Prod_Meson

            OcultarEncabezadoGrilla(Grilla_Productos_En_Meson)

            .Columns("Numot").Visible = True
            .Columns("Numot").HeaderText = "OT"
            .Columns("Numot").Width = 75
            .Columns("Numot").DisplayIndex = 0

            .Columns("Orden_Meson").Visible = True
            .Columns("Orden_Meson").HeaderText = "Orden original"
            .Columns("Orden_Meson").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns("Orden_Meson").Width = 50
            .Columns("Orden_Meson").DisplayIndex = 1

            .Columns("Estado_Pr").Visible = True
            .Columns("Estado_Pr").HeaderText = "Estado"
            .Columns("Estado_Pr").Width = 70
            .Columns("Estado_Pr").DisplayIndex = 2

            .Columns("Codigo").Visible = True
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Width = 100
            .Columns("Codigo").DisplayIndex = 3

            .Columns("Glosa").Visible = True
            .Columns("Glosa").HeaderText = "Descripción"
            .Columns("Glosa").Width = 280
            .Columns("Glosa").DisplayIndex = 4

            .Columns("Fecha").Visible = True
            .Columns("Fecha").HeaderText = "Fecha"
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha").Width = 65
            .Columns("Fecha").DisplayIndex = 5

            .Columns("Hora").Visible = True
            .Columns("Hora").HeaderText = "Hora"
            .Columns("Hora").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Hora").DefaultCellStyle.Format = "HH:mm"
            .Columns("Hora").Width = 50
            .Columns("Hora").DisplayIndex = 6

            '.Columns("Fabricar").Visible = True
            '.Columns("Fabricar").HeaderText = "Fabricar"
            '.Columns("Fabricar").Width = 60
            '.Columns("Fabricar").DisplayIndex = 5

            '.Columns("Fabricado").Visible = True
            '.Columns("Fabricado").HeaderText = "Fabricado"
            '.Columns("Fabricado").Width = 60
            '.Columns("Fabricado").DisplayIndex = 6

            .Columns("Saldo_Fabricar").Visible = True
            .Columns("Saldo_Fabricar").HeaderText = "Saldo Fabricar"
            .Columns("Saldo_Fabricar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Saldo_Fabricar").Width = 60
            .Columns("Saldo_Fabricar").DisplayIndex = 7

        End With

        For Each _Fila As DataGridViewRow In Grilla_Productos_En_Meson.Rows

            Dim _Estado = _Fila.Cells("Estado").Value
            Dim _Saldo_Fabricar = _Fila.Cells("Saldo_Fabricar").Value

            Dim _Grado = _Fila.Cells("Grado").Value

            If _Grado = 1 Then
                _Fila.DefaultCellStyle.BackColor = Color.Red 'LightCoral
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.ForeColor = Color.Black
                Else
                    _Fila.DefaultCellStyle.ForeColor = Color.White
                End If
            ElseIf _Grado = 2 Then
                _Fila.DefaultCellStyle.BackColor = Color.Yellow 'LightYellow
            Else
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.BackColor = Color.Black
                Else
                    _Fila.DefaultCellStyle.BackColor = Color.White
                End If
            End If

            If _Estado = "MQ" Or _Saldo_Fabricar = 0 Then
                _Fila.Cells("Movible").Value = False
                _Fila.DefaultCellStyle.BackColor = Color.LightGray
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.ForeColor = Color.Black
                End If
            End If

        Next

    End Sub

    Private Sub Grilla_Productos_En_Meson_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Productos_En_Meson.CellEnter

        Try
            Dim _Index = Grilla_Productos_En_Meson.CurrentRow.Index
            Dim _Count_Filas = Grilla_Productos_En_Meson.RowCount - 1
            Dim _Fila As DataGridViewRow = Grilla_Productos_En_Meson.Rows(_Index)

            Dim _Movible = _Fila.Cells("Movible").Value
            Dim _Habilitar_Subir = False
            Dim _Habilitar_Bajar = False

            If _Movible Then '= "PD" Then
                If _Index > 0 Then _Habilitar_Subir = True
                If _Index < _Count_Filas Then _Habilitar_Bajar = True
            End If

            Btn_Subir_Producto.Enabled = _Habilitar_Subir
            Btn_Bajar_Producto.Enabled = _Habilitar_Bajar
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If MessageBoxEx.Show(Me, "¿Desea guardar los cambios?", "Guardar cambios",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim _Orden_Meson = 1
            Dim Consulta_sql = String.Empty

            For Each _Fila As DataGridViewRow In Grilla_Productos_En_Meson.Rows
                Dim _IdMeson As Integer = _Fila.Cells("IdMeson").Value
                Consulta_sql += "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Set Orden_Meson = " & _Orden_Meson & " Where IdMeson = " & _IdMeson & vbCrLf
                _Orden_Meson += 1
            Next

            If Not String.IsNullOrEmpty(Consulta_sql) Then
                _Actualizado = _Sql.Ej_consulta_IDU(Consulta_sql)
                Btn_Dehacer_los_cambios.Enabled = False
                Me.Close()
            End If

        End If

    End Sub

    Private Sub Btn_Subir_Producto_Click(sender As Object, e As EventArgs) Handles Btn_Subir_Producto.Click

        Try

            'obtener el índice de la fila seleccionada
            _RowIndex = Grilla_Productos_En_Meson.SelectedCells(0).OwningRow.Index

            'crear una nueva fila
            Dim _Fila_Actual As DataRow = Fx_Clonar_Fila(_RowIndex)
            Dim _Fila_Arriba As DataRow

            Dim _Subir As Boolean
            Dim _Contador As Integer = 1

            If _RowIndex > 0 Then

                Dim _Fila_de_Arriba As DataGridViewRow
                For _i = _RowIndex - 1 To 0 Step -1
                    _Fila_de_Arriba = Grilla_Productos_En_Meson.Rows(_i)
                    Dim _Movible = _Fila_de_Arriba.Cells("Movible").Value
                    If _Movible Then
                        _Fila_Arriba = Fx_Clonar_Fila(_i)
                        _Subir = True
                        Exit For
                    End If
                    _Contador += 1
                Next

                If _Subir Then

                    'eliminar la fila seleccionada
                    Grilla_Productos_En_Meson.ClearSelection()
                    Grilla_Productos_En_Meson.Rows(0).Selected = True
                    Grilla_Productos_En_Meson.CurrentCell = Grilla_Productos_En_Meson.Rows(0).Cells("Numot")

                    _Tbl_Prod_Meson.Rows.RemoveAt(_RowIndex)
                    _Tbl_Prod_Meson.Rows.InsertAt(_Fila_Actual, _RowIndex - _Contador)

                    'inserte la nueva fila en una nueva posición
                    _Tbl_Prod_Meson.Rows.RemoveAt(_Fila_de_Arriba.Index)
                    _Tbl_Prod_Meson.Rows.InsertAt(_Fila_Arriba, _RowIndex)

                    Dim _Orden_Index = _Fila_Actual.Item("Orden_Meson")
                    Sb_Marcar_Fila_Seleccionada(_Orden_Index)

                Else
                    Beep()
                End If

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Function Fx_Clonar_Fila(_RowIndex As Integer) As DataRow
        Dim row As DataRow
        row = _Tbl_Prod_Meson.NewRow()

        'agregar datos a la fila

        For i = 0 To Grilla_Productos_En_Meson.ColumnCount - 1
            row(i) = Grilla_Productos_En_Meson.Rows(_RowIndex).Cells(i).Value
        Next
        Return row
    End Function

    Private Sub Btn_Bajar_Producto_Click(sender As Object, e As EventArgs) Handles Btn_Bajar_Producto.Click

        Try

            'obtener el índice de la fila seleccionada
            _RowIndex = Grilla_Productos_En_Meson.SelectedCells(0).OwningRow.Index

            'crear una nueva fila
            Dim _Fila_Actual As DataRow = Fx_Clonar_Fila(_RowIndex)
            Dim _Fila_Abajo As DataRow

            Dim _Bajar As Boolean
            Dim _Contador As Integer = 1

            Dim _RowIndex_Abajo As Integer


            If _RowIndex >= 0 Then

                Dim _Fila_de_Abajo As DataGridViewRow
                For _i = _RowIndex + 1 To Grilla_Productos_En_Meson.RowCount - 1
                    _Fila_de_Abajo = Grilla_Productos_En_Meson.Rows(_i)
                    Dim _Movible = _Fila_de_Abajo.Cells("Movible").Value
                    If _Movible Then
                        _Fila_Abajo = Fx_Clonar_Fila(_i)
                        _RowIndex_Abajo = _i
                        _Bajar = True
                        Exit For
                    End If
                    _Contador -= 1
                Next

                If _Bajar Then

                    'eliminar la fila seleccionada

                    _Tbl_Prod_Meson.Rows.RemoveAt(_RowIndex)
                    _Tbl_Prod_Meson.Rows.InsertAt(_Fila_Actual, _RowIndex_Abajo) ' _RowIndex + _Contador)

                    'inserte la nueva fila en una nueva posición
                    _Tbl_Prod_Meson.Rows.RemoveAt(_Fila_de_Abajo.Index)
                    _Tbl_Prod_Meson.Rows.InsertAt(_Fila_Abajo, _RowIndex)

                    Dim _Orden_Index = _Fila_Actual.Item("Orden_Meson")
                    Sb_Marcar_Fila_Seleccionada(_Orden_Index)

                Else
                    Beep()
                End If

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Sub Sb_Marcar_Fila_Seleccionada(_Orden_Index As Integer)

        For Each _Fila As DataGridViewRow In Grilla_Productos_En_Meson.Rows
            Dim _Orden_1 = _Fila.Cells("Orden_Meson").Value
            If _Orden_1 = _Orden_Index Then
                _Fila.Selected = True
                Grilla_Productos_En_Meson.CurrentCell = Grilla_Productos_En_Meson.Rows(_Fila.Index).Cells("Numot")
                Grilla_Productos_En_Meson.Focus()
                Btn_Dehacer_los_cambios.Enabled = True
                Exit For
            End If
        Next

    End Sub

    Private Sub Frm_Meson_Reordenar_Productos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Btn_Dehacer_los_cambios.Enabled Then
            Btn_Grabar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Btn_Dehacer_los_cambios_Click(sender As Object, e As EventArgs) Handles Btn_Dehacer_los_cambios.Click
        Sb_Actualizar_Grilla_Productos_En_Meson()
        Btn_Dehacer_los_cambios.Enabled = False
    End Sub

    Private Sub Frm_Meson_Reordenar_Productos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
