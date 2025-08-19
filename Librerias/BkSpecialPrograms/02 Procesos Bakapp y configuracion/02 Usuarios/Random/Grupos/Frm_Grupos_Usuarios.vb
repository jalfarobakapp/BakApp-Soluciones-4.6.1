
Imports DevComponents.DotNetBar

Public Class Frm_Grupos_Usuarios

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Tbl_Usuarios As DataTable
    Public _Kogru As String
    Private _RowIndex As Integer

    Public _Cl_GruposRD As New Cl_GruposRD
    Public Property Grabar As Boolean


    Public Sub New(_Kogru As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me._Kogru = _Kogru

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.LightYellow, ScrollBars.Vertical, True, True, False)
        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Grupos_Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

        If Not String.IsNullOrEmpty(_Kogru) Then

            Consulta_sql = "Select Tg.*,Tf.NOKOFU From TABFUGE Tg" & vbCrLf &
                           "Left Join TABFU Tf On Tf.KOFU = Tg.KOFUJEFE" & vbCrLf &
                           "Where KOGRU = '" & _Kogru & "'"
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Txt_Kogru.Text = _Row.Item("KOGRU")
            Txt_Nokogru.Text = _Row.Item("NOKOGRU")
            Txt_Kofujefe.Tag = _Row.Item("KOFUJEFE")
            Txt_Kofujefe.Text = _Row.Item("KOFUJEFE") & " - " & _Row.Item("NOKOFU").ToString.Trim

            Txt_Kogru.Enabled = False

        End If

        Sb_ActualizarGrilla()

        If String.IsNullOrEmpty(_Kogru) Then
            ActiveControl = Txt_Kogru
        Else
            ActiveControl = Txt_Nokogru
        End If

    End Sub

    Sub Sb_ActualizarGrilla()

        Consulta_sql = "Select Td.*,Tf.NOKOFU,Cast(0 As Bit) As Nueva_Linea From TABFUGD Td" & vbCrLf &
                       "Left Join TABFU Tf On Tf.KOFU = Td.KOFU" & vbCrLf &
                       "Where KOGRU = '" & _Kogru & "'" & vbCrLf &
                       "Order By ORDEN"

        _Tbl_Usuarios = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Usuarios

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("KOFU").Visible = True
            .Columns("KOFU").HeaderText = "Usuario"
            .Columns("KOFU").Width = 60
            .Columns("KOFU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOFU").Visible = True
            .Columns("NOKOFU").HeaderText = "Nombre"
            .Columns("NOKOFU").Width = 350
            .Columns("NOKOFU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Agregar_Click(sender As Object, e As EventArgs) Handles Btn_Agregar.Click

        Dim _Filtro_Kofu As String = Generar_Filtro_IN(_Tbl_Usuarios, "", "KOFU", False, False, "'")
        Dim _Sql_Filtro_Condicion_Extra = "And KOFU Not In " & _Filtro_Kofu

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Sql_Filtro_Condicion_Extra.Contains("()") Then
            _Sql_Filtro_Condicion_Extra = String.Empty
        End If

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra, False, False) Then

            For Each _Fl As DataRow In _Filtrar.Pro_Tbl_Filtro.Rows
                Sb_AgregarFila(_Fl.Item("Codigo"), _Fl.Item("Descripcion"))
            Next

        End If

    End Sub

    ' Método para agregar una nueva fila a la grilla
    Private Sub Sb_AgregarFila(_Kofu As String, _Nokofu As String)

        Dim nuevoOrden As Integer = 1

        If _Tbl_Usuarios.Rows.Count > 0 Then
            ' Obtener el valor máximo de ORDEN y sumarle 1
            nuevoOrden = CInt(_Tbl_Usuarios.Compute("MAX(ORDEN)", String.Empty)) + 1
        End If

        ' Agregar la nueva fila
        _Tbl_Usuarios.Rows.Add(_Kogru, _Kofu, nuevoOrden, _Nokofu, True)

    End Sub

    Private Sub Btn_Subir_Click(sender As Object, e As EventArgs) Handles Btn_Subir.Click

        If Not CBool(Grilla.RowCount) Then
            Return
        End If

        Try

            'obtener el índice de la fila seleccionada
            _RowIndex = Grilla.SelectedCells(0).OwningRow.Index

            'crear una nueva fila
            Dim _Fila_Actual As DataRow = Fx_Clonar_Fila(_RowIndex)
            Dim _Fila_Arriba As DataRow

            Dim _Subir As Boolean
            Dim _Contador As Integer = 1

            If _RowIndex > 0 Then

                Dim _Fila_de_Arriba As DataGridViewRow

                For _i = _RowIndex - 1 To 0 Step -1

                    _Fila_de_Arriba = Grilla.Rows(_i)

                    _Fila_Arriba = Fx_Clonar_Fila(_i)
                    _Subir = True
                    Exit For
                    _Contador += 1

                Next

                If _Subir Then

                    'eliminar la fila seleccionada
                    Grilla.ClearSelection()
                    Grilla.Rows(0).Selected = True
                    Grilla.CurrentCell = Grilla.Rows(0).Cells("KOFU")

                    _Tbl_Usuarios.Rows.RemoveAt(_RowIndex)
                    _Tbl_Usuarios.Rows.InsertAt(_Fila_Actual, _RowIndex - _Contador)

                    'inserte la nueva fila en una nueva posición
                    _Tbl_Usuarios.Rows.RemoveAt(_Fila_de_Arriba.Index)
                    _Tbl_Usuarios.Rows.InsertAt(_Fila_Arriba, _RowIndex)

                    Dim _Orden_Index = _RowIndex '_Fila_Actual.Item("Orden")
                    'Sb_Marcar_Fila_Seleccionada(_Orden_Index)
                    BuscarDatoEnGrilla(_Fila_Actual.Item("KOFU"), "KOFU", Grilla)

                Else
                    Beep()
                End If

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub Btn_Bajar_Click(sender As Object, e As EventArgs) Handles Btn_Bajar.Click

        If Not CBool(Grilla.RowCount) Then
            Return
        End If

        Try

            'obtener el índice de la fila seleccionada
            _RowIndex = Grilla.SelectedCells(0).OwningRow.Index

            'crear una nueva fila
            Dim _Fila_Actual As DataRow = Fx_Clonar_Fila(_RowIndex)
            Dim _Fila_Abajo As DataRow

            Dim _Bajar As Boolean
            Dim _Contador As Integer = 1

            Dim _RowIndex_Abajo As Integer


            If _RowIndex >= 0 Then

                Dim _Fila_de_Abajo As DataGridViewRow

                For _i = _RowIndex + 1 To Grilla.RowCount - 1

                    _Fila_de_Abajo = Grilla.Rows(_i)

                    'Dim _Movible = _Fila_de_Abajo.Cells("Movible").Value

                    'If _Movible Then
                    _Fila_Abajo = Fx_Clonar_Fila(_i)
                    _RowIndex_Abajo = _i
                    _Bajar = True
                    Exit For
                    'End If

                    _Contador -= 1

                Next

                If _Bajar Then

                    'eliminar la fila seleccionada

                    _Tbl_Usuarios.Rows.RemoveAt(_RowIndex)
                    _Tbl_Usuarios.Rows.InsertAt(_Fila_Actual, _RowIndex_Abajo) ' _RowIndex + _Contador)

                    'inserte la nueva fila en una nueva posición
                    _Tbl_Usuarios.Rows.RemoveAt(_Fila_de_Abajo.Index)
                    _Tbl_Usuarios.Rows.InsertAt(_Fila_Abajo, _RowIndex)

                    Dim _Orden = _Fila_Actual.Item("ORDEN")
                    BuscarDatoEnGrilla(_Fila_Actual.Item("KOFU"), "KOFU", Grilla)
                    'Sb_Marcar_Fila_Seleccionada(_Orden)

                Else
                    Beep()
                End If

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    Sub Sb_Marcar_Fila_Seleccionada(_Orden_Index As Integer)

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Orden_1 = _Fila.Cells("ORDEN").Value

            If _Orden_1 = _Orden_Index Then

                _Fila.Selected = True
                Grilla.CurrentCell = Grilla.Rows(_Fila.Index).Cells("KOFU")
                Grilla.Focus()
                'Btn_Dehacer_los_cambios.Enabled = True
                Exit For

            End If

        Next

    End Sub

    Private Function Fx_Clonar_Fila(_RowIndex As Integer) As DataRow
        Dim row As DataRow
        row = _Tbl_Usuarios.NewRow()

        'agregar datos a la fila

        For i = 0 To Grilla.ColumnCount - 1
            row(i) = Grilla.Rows(_RowIndex).Cells(i).Value
        Next
        Return row
    End Function

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Txt_Kogru.Text.Trim()) Then
            MessageBoxEx.Show(Me, "Debe ingresar el código del grupo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Kogru.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Nokogru.Text.Trim()) Then
            MessageBoxEx.Show(Me, "Debe ingresar el nombre del grupo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Nokogru.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Kofujefe.Text.Trim()) Then
            MessageBoxEx.Show(Me, "Debe ingresar el jefe del grupo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Kofujefe.Focus()
            Return
        End If

        _Cl_GruposRD.Tabfuge = New TABFUGE With {
                .KOGRU = Txt_Kogru.Text.Trim(),
                .NOKOGRU = Txt_Nokogru.Text.Trim(),
                .KOFUJEFE = Txt_Kofujefe.Tag.Trim()
            }

        _Cl_GruposRD.Ls_Tabfugd = New List(Of TABFUGD)

        For Each _Fila As DataRow In _Tbl_Usuarios.Rows
            If _Fila.RowState <> DataRowState.Deleted Then
                If Not String.IsNullOrEmpty(_Fila.Item("KOFU").ToString()) Then
                    Dim _Tabfugd As New TABFUGD With {
                            .KOGRU = Txt_Kogru.Text.Trim(),
                            .KOFU = _Fila.Item("KOFU").ToString(),
                            .ORDEN = _Cl_GruposRD.Ls_Tabfugd.Count + 1
                        }
                    _Cl_GruposRD.Ls_Tabfugd.Add(_Tabfugd)
                End If
            End If
        Next

        Dim _Mensaje As LsValiciones.Mensajes

        If String.IsNullOrEmpty(_Kogru) Then
            _Mensaje = _Cl_GruposRD.Fx_Grabar_Nuevo_Grupo(_Cl_GruposRD.Tabfuge, _Cl_GruposRD.Ls_Tabfugd)
        Else
            _Mensaje = _Cl_GruposRD.Fx_Editar_Grupo(_Cl_GruposRD.Tabfuge, _Cl_GruposRD.Ls_Tabfugd)
        End If

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Información", MessageBoxButtons.OK, _Mensaje.Icono)

        If Not _Mensaje.EsCorrecto Then
            Return
        End If

        _Kogru = Txt_Kogru.Text

        Grabar = True
        Me.Close()

    End Sub

    Private Sub Txt_Kofujefe_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Kofujefe.ButtonCustomClick

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, "", False, False, True) Then

            Dim _Fl As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)
            Txt_Kofujefe.Tag = _Fl.Item("Codigo")
            Txt_Kofujefe.Text = _Fl.Item("Codigo") & " - " & _Fl.Item("Descripcion")

        End If

    End Sub

    Private Sub Btn_Mnu_QuitarFuncionario_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_QuitarFuncionario.Click
        Sb_EliminarFila()
    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown
        If e.KeyValue = Keys.Delete Then
            Sb_EliminarFila()
        End If
    End Sub
    Sub Sb_EliminarFila()
        If Grilla.CurrentRow IsNot Nothing AndAlso Not Grilla.CurrentRow.IsNewRow Then

            If MessageBoxEx.Show(Me, "¿Está seguro que desea quitar al funcionario seleccionado?", "Confirmar acción",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                Return
            End If

            Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
        End If
    End Sub

    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_01)
                End If
            End With
        End If
    End Sub

End Class
