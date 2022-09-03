'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_01_Inventarios


    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private Sub Frm_01_Inventarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DtpFechaFl.Value = Now.Date
        ActualizarGrillaInventario()
    End Sub


    Private Function ActualizarGrillaInventario()

        Dim Filtro As String

        If ChkFiltroFecha.Checked Then
            Filtro = "Where Fecha_Inventario = '" & Format(DtpFechaFl.Value, "yyyyMMdd") & "'"
        End If

        Consulta_sql = "SELECT *," & _
                       "Case When Estado = 1 Then 'Abierto' Else 'Cerrado' End as Estado_" & vbCrLf & _
                       "FROM Zw_TmpInv_History" & vbCrLf & Filtro

        Grilla.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Fecha_Inventario").Width = 70
            .Columns("Fecha_Inventario").HeaderText = "Fecha"
            .Columns("Fecha_Inventario").Visible = True

            .Columns("Empresa").Width = 30
            .Columns("Empresa").HeaderText = "Emp"
            .Columns("Empresa").Visible = True

            .Columns("Sucursal").Width = 30
            .Columns("Sucursal").HeaderText = "Suc"
            .Columns("Sucursal").Visible = True

            .Columns("Bodega").Width = 30
            .Columns("Bodega").HeaderText = "Bod"
            .Columns("Bodega").Visible = True



            .Columns("NombreInventario").Width = 345
            .Columns("NombreInventario").HeaderText = "Nombre inventario"
            .Columns("NombreInventario").Visible = True

            .Columns("Estado").Width = 50
            .Columns("Estado").HeaderText = "Activo"
            .Columns("Estado").Visible = True


        End With
    End Function

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
       Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        Editar_Inventario()
    End Sub

    Private Sub BtnCrearNuevoInventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCrearNuevoInventario.Click
        Crear_Inventario()
    End Sub

    Sub Crear_Inventario()
        Dim Fecha As String = Format(Date.Now, "yyyyMMdd")

        Dim Fm As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
        'Fm.Cmbbodega.Enabled = False
        Fm.ShowDialog(Me)


        If Fm.Pro_Seleccionado Then

            Dim Fm2 As New Frm_01_CrearInventario
            Fm2._Empresa_Inv = Fm.Pro_Empresa
            Fm2._Sucursal_Inv = Fm.Pro_Sucursal
            Fm2._Bodega_Inv = Fm.Pro_Bodega

            Fm2.DtFechaInv.Value = Date.Now
            Fm2.DtFechaInv.Enabled = True
            Fm2.BtnEstado.Text = String.Empty
            Fm2.BtnEstado.Enabled = False
            Fm2.LblEmpresa.Text = Trim(Fm.Pro_Nombre_Empresa)
            Fm2.LblSucursal.Text = Trim(Fm.Pro_Nombre_Sucursal)
            Fm2.LblBodega.Text = Trim(Fm.Pro_Nombre_Bodega)
            Fm2.ChkInvGenerado.Checked = False
            Fm2.ChkInvGenerado.Enabled = False
            Fm2.TxtNombreInventario.Text = String.Empty
            Fm2.CmbFuncionarios.SelectedValue = FUNCIONARIO
            Fm2.Text = "Crear inventario"
            Fm2.ShowDialog(Me)

            If Fm2._Actualizar_Lista Then
                ActualizarGrillaInventario()
            End If

        End If

    End Sub
  
    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxSalir.Click
        Me.Close()
    End Sub

    Private Sub DtpFechaFl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFechaFl.ValueChanged
        ActualizarGrillaInventario()
    End Sub

    Private Sub ChkFiltroFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFiltroFecha.CheckedChanged
        ActualizarGrillaInventario()
        DtpFechaFl.Enabled = ChkFiltroFecha.Checked
    End Sub


    Sub Eliminar_Fila()

        Dim _IdInventario = Grilla.Rows(Grilla.CurrentRow.Index).Cells("IdInventario").Value

        Dim Reg As Integer =_Sql.Fx_Cuenta_Registros("ZW_TmpInvFotoInventario", _
                                              "IdInventario = " & _IdInventario)
        If CBool(Reg) Then
            MessageBoxEx.Show("Existe gestión sobre este inventario." & vbCrLf & _
                              "La fila no se puede eliminar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim dlg As System.Windows.Forms.DialogResult = _
                      MessageBoxEx.Show(Me, "¿Esta seguro de eliminar la fila seleccionada?", _
                                       "Eliminar fila", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        With Grilla
            If dlg = System.Windows.Forms.DialogResult.Yes Then

                Consulta_sql = "Delete Zw_TmpInv_History Where IdInventario = " & _IdInventario
                If  _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                    .Rows.RemoveAt(.CurrentRow.Index)
                End If
            End If
        End With

    End Sub

  
    Private Sub Grilla_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grilla.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim Id = NuloPorNro(.Rows(.CurrentRow.Index).Cells("IdInventario").VALUE, "")
                    If String.IsNullOrEmpty(Id) Then
                        ContextMenuStrip1.Enabled = False
                    Else

                        ContextMenuStrip1.Enabled = True
                    End If
                Else
                    ContextMenuStrip1.Enabled = False
                End If
            End With
        End If
    End Sub

    Private Sub EliminarFilaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarFilaToolStripMenuItem.Click
        Eliminar_Fila()
    End Sub

    Private Sub CrearNuevoInventarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrearNuevoInventarioToolStripMenuItem.Click
        Crear_Inventario()
    End Sub

    Private Sub EditarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarToolStripMenuItem.Click
        Editar_Inventario()
    End Sub


    Sub Editar_Inventario()
        With Grilla
            Dim _Fecha_Inv As Date = .Rows(.CurrentRow.Index).Cells("Fecha_Inventario").Value
            Dim _Estado As Boolean = .Rows(.CurrentRow.Index).Cells("Estado").Value

            Dim Bt_es As String

            If _Estado Then
                Bt_es = "Desactivar"
            Else
                Bt_es = "Activar"
            End If

            Dim _IdInventario As String = .Rows(.CurrentRow.Index).Cells("IdInventario").Value
            Dim _Fun As String = .Rows(.CurrentRow.Index).Cells("FuncionarioCargo").Value
            Dim _Emp As String = .Rows(.CurrentRow.Index).Cells("Empresa").Value
            Dim _Suc As String = .Rows(.CurrentRow.Index).Cells("Sucursal").Value
            Dim _Bod As String = .Rows(.CurrentRow.Index).Cells("Bodega").Value
            Dim _NomEmp As String = .Rows(.CurrentRow.Index).Cells("Nombre_Empresa").Value
            Dim _NomSuc As String = .Rows(.CurrentRow.Index).Cells("Nombre_Sucursal").Value
            Dim _NomBod As String = .Rows(.CurrentRow.Index).Cells("Nombre_Bodega").Value
            Dim _NombreInventario As String = .Rows(.CurrentRow.Index).Cells("NombreInventario").Value


            Dim Fm As New Frm_01_CrearInventario
            Fm._IdInventario = _IdInventario
            Fm._Empresa_Inv = _Emp
            Fm._Sucursal_Inv = _Suc
            Fm._Bodega_Inv = _Bod
            Fm.DtFechaInv.Value = _Fecha_Inv
            Fm.DtFechaInv.Enabled = False
            Fm.BtnEstado.Text = Bt_es
            Fm._Estado = _Estado
            Fm.LblEmpresa.Text = _NomEmp
            Fm.LblSucursal.Text = _NomSuc
            Fm.LblBodega.Text = _NomBod
            Fm.ChkInvGenerado.Checked = True
            Fm.ChkInvGenerado.Enabled = False
            Fm.TxtNombreInventario.Text = _NombreInventario
            Fm.CmbFuncionarios.SelectedValue = _Fun
            Fm.Text = "Editar inventario"
            Fm.ShowDialog(Me)

            If Fm._Actualizar_Lista Then
                ActualizarGrillaInventario()
            End If

        End With
    End Sub

   

End Class