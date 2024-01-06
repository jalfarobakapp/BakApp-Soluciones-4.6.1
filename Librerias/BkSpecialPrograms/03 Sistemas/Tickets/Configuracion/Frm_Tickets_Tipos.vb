Imports DevComponents.DotNetBar

Public Class Frm_Tickets_Tipos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Area As Integer
    Dim _Row_Area As DataRow
    Dim _Tbl_Tipos As DataTable

    Public Sub New(_Id_Area As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Area = _Id_Area
        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Areas Where Id = " & _Id_Area
        _Row_Area = _Sql.Fx_Get_DataRow(Consulta_sql)

        Sb_Formato_Generico_Grilla(Grilla_Tipos, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Tickets_Tipos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Lbl_Area.Text = "AREA: " & _Row_Area.Item("AREA")

        Sb_Actualizar_Grilla()

        AddHandler Grilla_Tipos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Tipos.MouseDown, AddressOf Sb_Grilla_Tipos_MouseDown

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Tipos" & vbCrLf &
                       "Where Id_Area = " & _Id_Area
        _Tbl_Tipos = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Tipos

            .DataSource = _Tbl_Tipos

            OcultarEncabezadoGrilla(Grilla_Tipos)

            Dim _DisplayIndex = 0

            .Columns("Tipo").Visible = True
            .Columns("Tipo").HeaderText = "Tipo de requerimiento"
            .Columns("Tipo").Width = 340
            .Columns("Tipo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ExigeProducto").Visible = True
            .Columns("ExigeProducto").HeaderText = "Exige producto"
            .Columns("ExigeProducto").ToolTipText = "Si esta tickeado, el Ticket exgira la incorporación de un producto para la gestión"
            .Columns("ExigeProducto").Width = 110
            .Columns("ExigeProducto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            ''.Columns("Dias").Visible = True
            ''.Columns("Dias").HeaderText = "Días expira."
            ''.Columns("Dias").ToolTipText = "Días que faltan para que termine la oferta"
            ''.Columns("Dias").Width = 70
            ''.Columns("Dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ''.Columns("Dias").DefaultCellStyle.Format = "###,##0.##"
            ''.Columns("Dias").DisplayIndex = _DisplayIndex
            ''_DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_CrearTipo_Click(sender As Object, e As EventArgs) Handles Btn_CrearTipo.Click

        Dim _Grabar As Boolean
        Dim _Row_Tipo As DataRow

        Dim Fm As New Frm_Tickets_TiposCrear(_Id_Area, 0)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _Row_Tipo = Fm._Row_Tipo
        Fm.Dispose()

        If _Grabar Then

            Me.Sb_Actualizar_Grilla()
            BuscarDatoEnGrilla(_Row_Tipo.Item("Tipo"), "Tipo", Grilla_Tipos)

        End If

    End Sub

    Private Sub Btn_Mnu_EditarTipo_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_EditarTipo.Click

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Tickets", "Estado = 'ABIE'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "Existen Tickets que están abierto y usan este tipo de requerimiento." & vbCrLf &
                              "Se mostrara el siguiente formulario, sin embargo el sistema volverá a validar que no hayan Tickets abiertos para que pueda editar",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Dim _Fila As DataGridViewRow = Grilla_Tipos.CurrentRow

        Dim _Id_Tipo As Integer = _Fila.Cells("Id").Value
        Dim _Tipo As String = _Fila.Cells("Tipo").Value
        'Dim _Tipo_Old As String = _Fila.Cells("ExigeProducto").Value

        Dim _Grabar As Boolean
        Dim _Row_Tipo As DataRow

        Dim Fm As New Frm_Tickets_TiposCrear(_Id_Area, _Id_Tipo)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _Row_Tipo = Fm._Row_Tipo
        Fm.Dispose()

        If _Grabar Then

            _Fila.Cells("ExigeProducto").Value = _Row_Tipo.Item("ExigeProducto")
            _Fila.Cells("RevInventario").Value = _Row_Tipo.Item("RevInventario")
            _Fila.Cells("AjusInventario").Value = _Row_Tipo.Item("AjusInventario")
            _Fila.Cells("SobreStock").Value = _Row_Tipo.Item("SobreStock")
            _Fila.Cells("Asignado").Value = _Row_Tipo.Item("Asignado")
            _Fila.Cells("AsignadoGrupo").Value = _Row_Tipo.Item("AsignadoGrupo")
            _Fila.Cells("AsignadoAgente").Value = _Row_Tipo.Item("AsignadoAgente")
            _Fila.Cells("Id_Grupo").Value = _Row_Tipo.Item("Id_Grupo")
            _Fila.Cells("CodAgente").Value = _Row_Tipo.Item("CodAgente")

        End If

    End Sub

    Private Sub Btn_Mnu_EliminarTipo_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_EliminarTipo.Click

        Dim _Fila As DataGridViewRow = Grilla_Tipos.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value

        If MessageBoxEx.Show(Me, "¿Confirma eliminar este Tipo de requerimiento?", "Eliminar tipo de requerimiento",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Tipos Where Id = " & _Id
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Grilla_Tipos.Rows.Remove(_Fila)
        End If

    End Sub

    Private Sub Sb_Grilla_Tipos_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
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

    Private Sub Grilla_Tipos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Tipos.CellDoubleClick
        Call Btn_Mnu_EditarTipo_Click(Nothing, Nothing)
    End Sub
End Class
