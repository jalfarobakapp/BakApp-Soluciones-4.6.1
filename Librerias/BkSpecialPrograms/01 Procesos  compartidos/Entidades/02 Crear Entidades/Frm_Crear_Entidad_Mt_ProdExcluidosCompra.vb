Imports DevComponents.DotNetBar
Public Class Frm_Crear_Entidad_Mt_ProdExcluidosCompra

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _CodEntidad As String
    Dim _CodSucEntidad As String

    Dim _Tbl_Producto As DataTable

    Public Sub New(_CodEntidad As String, _CodSucEntidad As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._CodEntidad = _CodEntidad
        Me._CodSucEntidad = _CodSucEntidad

        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Crear_Entidad_Mt_ProdExcluidosCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_Sql = "Select *,NOKOPR From " & _Global_BaseBk & "Zw_Entidades_ProdExcluidos ProdEx" & vbCrLf &
                       "Left Join MAEPR On KOPR = ProdEx.Codigo" & vbCrLf &
                       "Where CodEntidad = '" & _CodEntidad & "' And CodSucEntidad = '" & _CodSucEntidad & "'"

        _Tbl_Producto = _Sql.Fx_Get_Tablas(Consulta_Sql)

        With Grilla
            .DataSource = _Tbl_Producto

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Width = 120
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Width = 280
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Motivo").HeaderText = "Motivo bloqueo"
            .Columns("Motivo").Width = 450
            .Columns("Motivo").Visible = True
            .Columns("Motivo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grilla.MouseDown
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

    Private Sub Btn_AgregarProductos_Click(sender As Object, e As EventArgs) Handles Btn_AgregarProductos.Click

        If Not Fx_Tiene_Permiso(Me, "CfEnt030") Then Return

        Dim _Sql_Filtro_Condicion_Extra = "And TIPR In ('FPN','FIN') And KOPR Not In " &
                                          "(Select Codigo From " & _Global_BaseBk & "Zw_Entidades_ProdExcluidos " &
                                          "Where CodEntidad = '" & _CodEntidad & "' And CodSucEntidad = '" & _CodSucEntidad & "')"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               False, False, True, False,, False) Then

            Dim _Codigo As String = _Filtrar.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            Dim _Motivo As String
            Dim _Aceptar As Boolean = InputBox_Bk(Me, "Motivo por el cual se bloquea el producto", "Motivo",
                                                  _Motivo,, _Tipo_Mayus_Minus.Mayusculas, 200, True)

            If Not _Aceptar Then
                Return
            End If

            Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Entidades_ProdExcluidos (CodEntidad,CodSucEntidad,Chk,Codigo,Motivo) Values " &
                           "('" & _CodEntidad & "','" & _CodSucEntidad & "',1,'" & _Codigo & "','" & _Motivo & "')"
            _Sql.Ej_consulta_IDU(Consulta_Sql)

            Sb_Actualizar_Grilla()

        End If

    End Sub

    Private Sub Btn_QuitarProducto_Click(sender As Object, e As EventArgs) Handles Btn_QuitarProducto.Click

        If Not Fx_Tiene_Permiso(Me, "CfEnt030") Then Return

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Indice As Integer = _Fila.Index
        Dim _Id As Integer = _Fila.Cells("Id").Value
        Dim _Codigo As String = _Fila.Cells("Codigo").Value

        If MessageBoxEx.Show(Me, "¿Esta seguro de quitar este producto?", "Quitar producto",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Entidades_ProdExcluidos" & vbCrLf &
                           "Where Id = " & _Id
            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                Grilla.Rows.RemoveAt(_Indice)
            End If
        End If

    End Sub

    Private Sub Btn_EditarMotivo_Click(sender As Object, e As EventArgs) Handles Btn_EditarMotivo.Click

        If Not Fx_Tiene_Permiso(Me, "CfEnt030") Then Return

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Id As Integer = _Fila.Cells("Id").Value
        Dim _Codigo As String = _Fila.Cells("Codigo").Value
        Dim _Motivo As String = _Fila.Cells("Motivo").Value

        Dim _Aceptar As Boolean = InputBox_Bk(Me, "Motivo por el cual se bloquea el producto", "Motivo",
                                              _Motivo,, _Tipo_Mayus_Minus.Mayusculas, 200, True)

        If Not _Aceptar Then
            Return
        End If

        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Entidades_ProdExcluidos Set Motivo = '" & _Motivo & "' Where Id = " & _Id
        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
            _Fila.Cells("Motivo").Value = _Motivo
        End If

    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown
        If e.KeyCode = Keys.Enter Then

            e.Handled = True ' Evita que la tecla ENTER se propague y active la siguiente fila
            Dim dgv As DataGridView = DirectCast(sender, DataGridView)

            If dgv.CurrentRow IsNot Nothing Then
                Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
                ' Selecciona toda la fila actual
                dgv.CurrentRow.Selected = True
                If _Cabeza = "Motivo" Then
                    Call Btn_EditarMotivo_Click(Nothing, Nothing)
                End If
            End If

        End If
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
            Dim dgv As DataGridView = DirectCast(sender, DataGridView)
            If dgv.CurrentRow IsNot Nothing Then
                ' Selecciona toda la fila actual
                dgv.CurrentRow.Selected = True
                Call Btn_QuitarProducto_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        ShowContextMenu(Menu_Contextual_01)
    End Sub

    Private Sub Btn_ExportarExcel_Click(sender As Object, e As EventArgs) Handles Btn_ExportarExcel.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_Producto, Me, "Productos Excluidos")
    End Sub

    Private Sub Frm_Crear_Entidad_Mt_ProdExcluidosCompra_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
