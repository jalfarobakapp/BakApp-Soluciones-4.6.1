Imports DevComponents.DotNetBar

Public Class Frm_Inv_Inventarios

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property ModoSeleccion As Boolean
    Public Property Empresa As String
    Public Property Sucursal As String
    Public Property Bodega As String
    Public Property IdInventario_Selecionado As Integer

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Inventarios, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, True, False)

        Sb_Color_Botones_Barra(Bar1)

        Empresa = ModEmpresa
        Sucursal = ModSucursal
        Bodega = ModBodega

        IdInventario_Selecionado = 0

    End Sub

    Private Sub Frm_Inventarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not ModoSeleccion Then
            AddHandler Grilla_Inventarios.MouseDown, AddressOf Sb_Grilla_MouseDown
        End If

        Sb_Actualizar_Grilla()

        Btn_Crear_Inventario.Enabled = Not ModoSeleccion

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String = String.Empty

        If Chk_Activos.Checked Then
            _Condicion = " And Activo = 1"
        End If

        Consulta_sql = "Select *," &
                       "Case When Activo = 1 Then 'Abierto' Else 'Cerrado' End as Estado_Str" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_Inventario" & vbCrLf &
                       "Where Empresa = '" & Empresa & "' And Sucursal = '" & Sucursal & "'" & _Condicion

        If ModoSeleccion Then

            Consulta_sql = "Select *," &
                       "Case When Activo = 1 Then 'Abierto' Else 'Cerrado' End as Estado_Str" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_Inventario" & vbCrLf &
                       "Where Empresa = '" & Empresa & "' And Sucursal = '" & Sucursal & "' And Bodega = '" & Bodega & "'" & _Condicion

        End If

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _DisplayIndex = 0

        With Grilla_Inventarios

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla_Inventarios, True)

            .Columns("Id").Width = 40
            .Columns("Id").HeaderText = "ID"
            .Columns("Id").Visible = True
            .Columns("Id").DisplayIndex = _DisplayIndex
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

            .Columns("NombreInventario").Width = 350
            .Columns("NombreInventario").HeaderText = "Nombre inventario"
            .Columns("NombreInventario").Visible = True
            .Columns("NombreInventario").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Activo").Width = 40
            .Columns("Activo").HeaderText = "Activo"
            .Columns("Activo").Visible = True
            .Columns("Activo").DisplayIndex = _DisplayIndex
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

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Inventario",
                                                       "Empresa = '" & _Row_Bodega.Item("Empresa") &
                                                       "' And Sucursal = '" & _Row_Bodega.Item("KOSU") &
                                                       "' And Bodega = '" & _Row_Bodega.Item("KOBO") & "' And Activo = 1")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "Ya existe un inventario activo para la bodega seleccionada", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Call Btn_Crear_Inventario_Click(Nothing, Nothing)
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

        If ModoSeleccion Then

            Dim _Fila As DataGridViewRow = Grilla_Inventarios.CurrentRow
            IdInventario_Selecionado = _Fila.Cells("Id").Value
            Me.Close()
            Return

        End If

        Call Btn_VerInventario_Click(Nothing, Nothing)

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

    Private Sub Btn_EditarInventario_Click(sender As Object, e As EventArgs) Handles Btn_EditarInventario.Click
        Dim _Fila As DataGridViewRow = Grilla_Inventarios.Rows(Grilla_Inventarios.CurrentRow.Index)

        Dim _Id = _Fila.Cells("Id").Value

        Dim Fm As New Frm_01_CrearInventario(_Id)
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_EliminarInventario_Click(sender As Object, e As EventArgs) Handles Btn_EliminarInventario.Click

        Dim _Fila As DataGridViewRow = Grilla_Inventarios.CurrentRow

        Dim _Id = _Fila.Cells("Id").Value

        Dim Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_FotoInventario", "IdInventario = " & _Id)

        If CBool(Reg) Then
            MessageBoxEx.Show(Me, "Actualmente hay una Foto Stock registrada para este inventario. " & vbCrLf &
                              "No es posible eliminar la fila", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar la fila seleccionada?",
                             "Eliminar fila", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Inv_Inventario Where Id = " & _Id
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Grilla_Inventarios.Rows.RemoveAt(Grilla_Inventarios.CurrentRow.Index)
        End If

    End Sub

    Private Sub Btn_VerInventario_Click(sender As Object, e As EventArgs) Handles Btn_VerInventario.Click

        Dim _Fila As DataGridViewRow = Grilla_Inventarios.CurrentRow

        Dim _Id = _Fila.Cells("Id").Value

        Dim Fm As New Frm_Inv_Ctrl_Inventario(_Id)
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Actualizar_Grilla()

    End Sub
End Class
