Imports DevComponents.DotNetBar
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Frm_Inv_Inventarios

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Inventarios, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, True, False)

    End Sub

    Private Sub Frm_Inventarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla_Inventarios.MouseDown, AddressOf Sb_Grilla_MouseDown

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select *," &
                       "Case When Estado = 1 Then 'Abierto' Else 'Cerrado' End as Estado_" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_TmpInv_History"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _DisplayIndex = 0

        With Grilla_Inventarios

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla_Inventarios, True)

            .Columns("IdInventario").Width = 40
            .Columns("IdInventario").HeaderText = "ID"
            .Columns("IdInventario").Visible = True
            .Columns("IdInventario").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha_Inventario").Width = 70
            .Columns("Fecha_Inventario").HeaderText = "Fecha"
            .Columns("Fecha_Inventario").Visible = True
            .Columns("Fecha_Inventario").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Empresa").Width = 30
            .Columns("Empresa").HeaderText = "Emp"
            .Columns("Empresa").Visible = True
            .Columns("Empresa").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sucursal").Width = 30
            .Columns("Sucursal").HeaderText = "Suc"
            .Columns("Sucursal").Visible = True
            .Columns("Sucursal").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Bodega").Width = 30
            .Columns("Bodega").HeaderText = "Bod"
            .Columns("Bodega").Visible = True
            .Columns("Bodega").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreInventario").Width = 250
            .Columns("NombreInventario").HeaderText = "Nombre inventario"
            .Columns("NombreInventario").Visible = True
            .Columns("NombreInventario").DisplayIndex = _DisplayIndex

            _DisplayIndex += 1
            .Columns("Estado").Width = 40
            .Columns("Estado").HeaderText = "Activo"
            .Columns("Estado").Visible = True
            .Columns("Estado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Crear_Inventario_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Inventario.Click

        Dim Fecha As String = Format(Date.Now, "yyyyMMdd")
        Dim _Row_Bodega As DataRow
        Dim _BodSeleccionada As Boolean

        Dim Fm As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
        Fm.ShowDialog(Me)
        _Row_Bodega = Fm.Pro_RowBodega()
        _BodSeleccionada = Fm.Pro_Seleccionado
        Fm.Dispose()

        If Not _BodSeleccionada Then
            Return
        End If

        Dim Cl_Inventario As New Cl_Inventario
        Cl_Inventario.Fx_Llenar_Zw_Inv_Inventario(0)

        With Cl_Inventario.Zw_Inv_Inventario

            .Id = 0
            .Empresa = _Row_Bodega.Item("EMPRESA")
            .Nombre_Empresa = _Row_Bodega.Item("RAZON").ToString.Trim
            .Sucursal = _Row_Bodega.Item("KOSU")
            .Nombre_Sucursal = _Row_Bodega.Item("NOKOSU").ToString.Trim
            .Bodega = _Row_Bodega.Item("KOBO")
            .Nombre_Bodega = _Row_Bodega.Item("NOKOBO").ToString.Trim
            .Fecha_Inventario = Now.Date

        End With

        Dim Fm2 As New Frm_01_CrearInventario(0)
        Fm2.Cl_Inventario = Cl_Inventario
        Fm2.Text = "Crear inventario"
        Fm2.ShowDialog(Me)

        If Fm2.Grabar Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Grilla_Inventarios_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Inventarios.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Inventarios.Rows(Grilla_Inventarios.CurrentRow.Index)

        Dim _IdInventario = _Fila.Cells("IdInventario").Value

        Dim Fm As New Frm_01_CrearInventario(_IdInventario)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

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

    Private Sub Btn_ActivarInventario_Click(sender As Object, e As EventArgs) Handles Btn_ActivarInventario.Click

        Dim _Fila As DataGridViewRow = Grilla_Inventarios.CurrentRow
        Dim _IdInventario As Integer = _Fila.Cells("IdInventario").Value

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_TmpInv_History Set Estado = 0" & vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_TmpInv_History Set Estado = 1" & vbCrLf &
                       "Where IdInventario = " & _IdInventario

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            MessageBoxEx.Show(Me, "Inventario activo", "Activar inventario", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Sb_Actualizar_Grilla()
            BuscarDatoEnGrilla(_IdInventario, "IdInventario", Grilla_Inventarios)
        End If

    End Sub

    Private Sub Btn_EditarInventario_Click(sender As Object, e As EventArgs) Handles Btn_EditarInventario.Click
        Call Grilla_Inventarios_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Btn_EliminarInventario_Click(sender As Object, e As EventArgs) Handles Btn_EliminarInventario.Click

        Dim _Fila As DataGridViewRow = Grilla_Inventarios.Rows(Grilla_Inventarios.CurrentRow.Index)

        Dim _IdInventario = _Fila.Cells("IdInventario").Value

        Dim Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "ZW_TmpInvFotoInventario", "IdInventario = " & _IdInventario)

        If CBool(Reg) Then
            MessageBoxEx.Show(Me, "Actualmente hay operaciones registradas para este inventario. " & vbCrLf &
                              "No es posible eliminar la fila", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar la fila seleccionada?",
                             "Eliminar fila", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_TmpInv_History Where IdInventario = " & _IdInventario
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Grilla_Inventarios.Rows.RemoveAt(Grilla_Inventarios.CurrentRow.Index)
        End If

    End Sub
End Class
