Imports System.ComponentModel
Imports DevComponents.DotNetBar

Public Class Frm_Tickets_IngProducto_GesXBod

    Dim listaProductos As New BindingList(Of Zw_Stk_Tickets_Producto)

    Public Property Cl_Tickets As Cl_Tickets

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Detalle, 18, New Font("Tahoma", 8), Color.LightYellow, ScrollBars.None, True, False, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Tickets_IngProducto_GesXBod_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Asignar la lista de detalles a listaProductos
        listaProductos = New BindingList(Of Zw_Stk_Tickets_Producto)(Cl_Tickets.Ls_Zw_Stk_Tickets_Producto)

        Sb_ActualizarGrilla()

    End Sub

    Sub Sb_Agregar_Nueva_Linea()

        Dim _Detalle As New Zw_Stk_Tickets_Producto

        _Detalle.Id_Padre = 1

        listaProductos.Add(_Detalle)
        Grilla_Detalle.Refresh()

        Try
            Grilla_Detalle.CurrentCell = Grilla_Detalle.Rows(Grilla_Detalle.RowCount - 1).Cells("Bodega")
        Catch ex As Exception

        End Try

    End Sub

    Sub Sb_ActualizarGrilla()

        ' Desvincular el DataGridView
        Grilla_Detalle.DataSource = Nothing

        Dim bindingSource As New BindingSource()
        bindingSource.DataSource = listaProductos
        Grilla_Detalle.DataSource = bindingSource

        With Grilla_Detalle

            '.DataSource = _Source

            OcultarEncabezadoGrilla(Grilla_Detalle, True)

            Dim _DisplayIndex = 0

            .Columns("Empresa").Visible = True
            .Columns("Empresa").HeaderText = "Emp"
            .Columns("Empresa").Width = 30
            .Columns("Empresa").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sucursal").Visible = True
            .Columns("Sucursal").HeaderText = "Suc"
            .Columns("Sucursal").Width = 30
            .Columns("Sucursal").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Bodega").Visible = True
            .Columns("Bodega").HeaderText = "Bod"
            .Columns("Bodega").Width = 30
            .Columns("Bodega").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Um").Visible = True
            .Columns("Um").HeaderText = "UM"
            .Columns("Um").Width = 30
            .Columns("Um").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StfiEnBodega").Visible = True
            .Columns("StfiEnBodega").HeaderText = "Stock Sistema"
            .Columns("StfiEnBodega").Width = 100
            .Columns("StfiEnBodega").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StfiEnBodega").DefaultCellStyle.Format = "###,##0.##"
            .Columns("StfiEnBodega").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").HeaderText = "Stock Físico"
            .Columns("Cantidad").Width = 100
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Cantidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Diferencia").Visible = True
            .Columns("Diferencia").HeaderText = "Stock Físico"
            .Columns("Diferencia").Width = 100
            .Columns("Diferencia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Diferencia").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Diferencia").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaRev").Visible = True
            .Columns("FechaRev").HeaderText = "Fecha Rev."
            .Columns("FechaRev").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaRev").Width = 80
            .Columns("FechaRev").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaRev").Visible = True
            .Columns("FechaRev").HeaderText = "Hora Rev."
            .Columns("FechaRev").DefaultCellStyle.Format = "HH:mm"
            .Columns("FechaRev").Width = 80
            .Columns("FechaRev").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Grilla_Detalle_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla_Detalle.KeyDown

        If IsNothing(Grilla_Detalle.CurrentCell) Then
            Return
        End If

        If Not Btn_Grabar.Enabled Then
            Return
        End If

        Dim _Cabeza = Grilla_Detalle.Columns(Grilla_Detalle.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla_Detalle.CurrentRow

        Dim _Id_Padre As Integer = _Fila.Cells("Id_Padre").Value
        Dim _Empresa As String = _Fila.Cells("Empresa").Value
        Dim _Sucursal As String = _Fila.Cells("Sucursal").Value
        Dim _Bodega As String = _Fila.Cells("Bodega").Value

        Dim _Cantidad As Double = _Fila.Cells("Cantidad").Value
        Dim _StfiEnBodega As Double = _Fila.Cells("StfiEnBodega").Value

        Dim _Index As Integer = _Fila.Index

        Select Case e.KeyValue

            Case Keys.Enter

                If _Cabeza = "Descripcion" Then
                    e.Handled = True
                    Return
                End If

                If _Cabeza = "StfiEnBodega" Or
                    _Cabeza = "Cantidad" Or
                    _Cabeza = "Empresa" Or
                    _Cabeza = "Sucursal" Or
                    _Cabeza = "Bodega" Or
                    _Cabeza = "Um" Then

                    If _Fila.IsNewRow Then

                        If _Cabeza = "StfiEnBodega" Or _Cabeza = "Cantidad" Then

                            If String.IsNullOrEmpty(_Empresa) Or String.IsNullOrEmpty(_Sucursal) Or String.IsNullOrEmpty(_Bodega) Then
                                MessageBoxEx.Show(Me, "Debe ingresar la bodega", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Grilla_Detalle.CurrentCell = _Fila.Cells("Bodega")
                                Return
                            End If

                        End If

                        SendKeys.Send("{F2}")
                        e.Handled = True
                        Grilla_Detalle.Columns(_Cabeza).ReadOnly = False
                        Grilla_Detalle.BeginEdit(True)

                    End If

                    If Not _Fila.IsNewRow Then

                        If _Cabeza = "StfiEnBodega" Or _Cabeza = "Cantidad" Or _Cabeza = "Um" Then

                            If String.IsNullOrEmpty(_Empresa) Or String.IsNullOrEmpty(_Sucursal) Or String.IsNullOrEmpty(_Bodega) Then
                                MessageBoxEx.Show(Me, "Debe ingresar la bodega", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Grilla_Detalle.CurrentCell = _Fila.Cells("Bodega")
                                e.Handled = True
                                Return
                            End If

                            If String.IsNullOrEmpty(_Fila.Cells("Um").Value) Then
                                MessageBoxEx.Show(Me, "Debe ingresar la unidad de medida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Grilla_Detalle.CurrentCell = _Fila.Cells("Um")
                                e.Handled = True
                                Return
                            End If

                            SendKeys.Send("{F2}")
                            e.Handled = True
                            Grilla_Detalle.Columns(_Cabeza).ReadOnly = False
                            Grilla_Detalle.BeginEdit(True)

                        End If

                        If _Cabeza = "Empresa" Or _Cabeza = "Sucursal" Or _Cabeza = "Bodega" Then

                            Dim Fm_b As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
                            Fm_b.Pro_Empresa = ModEmpresa
                            Fm_b.Pro_Sucursal = NuloPorNro(_Fila.Cells("Sucursal").Value, ModSucursal)
                            Fm_b.Pro_Bodega = NuloPorNro(_Fila.Cells("Bodega").Value, ModBodega)
                            Fm_b.RevisarPermisosBodega = False
                            Fm_b.Pedir_Permiso = False
                            Fm_b.ShowDialog(Me)

                            If Fm_b.Pro_Seleccionado Then

                                ' Verificar si ya existe la misma empresa, sucursal y bodega en la lista
                                For Each producto As Zw_Stk_Tickets_Producto In listaProductos
                                    If producto.Empresa = Fm_b.Pro_RowBodega.Item("EMPRESA") AndAlso
                                        producto.Sucursal = Fm_b.Pro_RowBodega.Item("KOSU") AndAlso
                                        producto.Bodega = Fm_b.Pro_RowBodega.Item("KOBO") Then
                                        MessageBoxEx.Show(Me, "Ya existe un registro con la misma empresa, sucursal y bodega", "Validación",
                                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                        Grilla_Detalle.CurrentCell = _Fila.Cells("Bodega")
                                        Return
                                    End If
                                Next

                                _Fila.Cells("Empresa").Value = Fm_b.Pro_RowBodega.Item("EMPRESA")
                                _Fila.Cells("Sucursal").Value = Fm_b.Pro_RowBodega.Item("KOSU")
                                _Fila.Cells("Bodega").Value = Fm_b.Pro_RowBodega.Item("KOBO")

                            End If

                            Fm_b.Dispose()

                        End If

                        If _Cabeza = "Um" Then

                            Dim Fm As New Frm_Cantidades_Selec_Ud(_Fila.Cells("Ud1").Value, _Fila.Cells("Ud2").Value)
                            Fm.ShowDialog(Me)
                            If Fm.Seleccionada Then
                                _Fila.Cells("Um").Value = Fm.UdTrans
                            End If
                            Fm.Dispose()

                        End If

                    End If

                End If

            Case Keys.Delete

                Try
                    If Not _Fila.IsNewRow Then

                        If _Id_Padre = 0 Then
                            MessageBoxEx.Show(Me, "Esta línea no puede ser eliminada, pues es la línea de origen del producto", "Validación",
                                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return
                        End If

                        ' Asegúrate de que el índice sea válido antes de intentar eliminar
                        If _Index >= 0 AndAlso _Index < Grilla_Detalle.Rows.Count AndAlso _Id_Padre = 0 Then

                            If MessageBoxEx.Show(Me, "¿Está seguro de eliminar la fila seleccionada?", "Eliminar Fila",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                                Return
                            End If

                            Grilla_Detalle.Rows.RemoveAt(_Index)

                        End If
                    End If

                    If Grilla_Detalle.Rows.Count = 0 Then
                        Sb_Agregar_Nueva_Linea()
                    End If

                Catch ex As Exception
                    MessageBoxEx.Show(Me, "Error al eliminar la fila: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            Case Keys.Down

                ' Verificar si la fila actual es la última fila visible
                If Grilla_Detalle.CurrentRow.Index = Grilla_Detalle.Rows.Count - 1 Then

                    If Not String.IsNullOrEmpty(_Bodega) Then
                        Sb_Agregar_Nueva_Linea()
                    End If

                End If

        End Select

        Grilla_Detalle.Refresh()

    End Sub

End Class
