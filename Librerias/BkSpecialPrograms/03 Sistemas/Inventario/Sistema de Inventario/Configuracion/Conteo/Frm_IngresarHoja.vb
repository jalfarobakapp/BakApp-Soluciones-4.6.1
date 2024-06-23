Imports System.ComponentModel
Imports DevComponents.DotNetBar

Public Class Frm_IngresarHoja

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Cl_Inventario As New Cl_Inventario
    Public Property Cl_Conteo As New Cl_Conteo

    Dim _IdInventario As Integer
    Dim _IdHoja As Integer
    Public Grabar As Boolean

    ' Crear un BindingSource y enlazarlo al DataGridView
    Dim _Source As BindingSource

    Public Sub New(_IdInventario As Integer, _IdHoja As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._IdHoja = _IdHoja
        Me._IdInventario = _IdInventario

        Cl_Inventario.Fx_Llenar_Zw_Inv_Inventario(_IdInventario)

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        If CBool(_IdHoja) Then
            Cl_Conteo.Fx_Llenar_Zw_Inv_Hoja(_IdHoja)
        Else
            Cl_Conteo.Fx_Nueva_Hoja(Cl_Inventario.Zw_Inv_Inventario, _NombreEquipo, FUNCIONARIO)
        End If

        Sb_Formato_Generico_Grilla(Grilla_Detalle, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_IngresarHoja_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ActiveControl = Txt_Numero
        Sb_ActualizarGrilla()

        AddHandler Grilla_Detalle.RowValidating, AddressOf Grilla_Detalle_RowValidating

    End Sub

    Sub Sb_ActualizarGrilla()

        '' Crear un BindingList a partir de la lista
        Dim bindingList As New BindingList(Of Zw_Inv_Hoja_Detalle)(Cl_Conteo.Ls_Zw_Inv_Hoja_Detalle)

        ' Crear un BindingSource y enlazarlo al DataGridView
        _Source = New BindingSource(bindingList, Nothing)

        With Grilla_Detalle

            .DataSource = _Source

            OcultarEncabezadoGrilla(Grilla_Detalle, True)

            Dim _DisplayIndex = 0

            .Columns("Id").Visible = False
            .Columns("Id").HeaderText = "Id"
            .Columns("Id").Width = 40
            .Columns("Id").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("IdHoja").Visible = False
            .Columns("IdHoja").HeaderText = "IdHoja"
            .Columns("IdHoja").Width = 40
            .Columns("IdHoja").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("IdUbicacion").Visible = False
            .Columns("IdUbicacion").HeaderText = "IdUbicacion"
            .Columns("IdUbicacion").Width = 40
            .Columns("IdUbicacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CodUbicacion").Visible = True
            .Columns("CodUbicacion").HeaderText = "CodUbicacion"
            .Columns("CodUbicacion").Width = 80
            .Columns("CodUbicacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codproducto").Visible = True
            .Columns("Codproducto").HeaderText = "Código"
            .Columns("Codproducto").Width = 80
            '.Columns("Codproducto").ReadOnly = False
            .Columns("Codproducto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantidadUd1").Visible = True
            .Columns("CantidadUd1").HeaderText = "Cantidad"
            .Columns("CantidadUd1").Width = 80
            '.Columns("CantidadUd1").ReadOnly = False
            .Columns("CantidadUd1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Fecha").Visible = True
            '.Columns("Fecha").HeaderText = "Fecha"
            '.Columns("Fecha").Width = 80
            '.Columns("Fecha").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Hora").Visible = True
            '.Columns("Hora").HeaderText = "Hora"
            '.Columns("Hora").Width = 80
            '.Columns("Hora").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Observaciones").Visible = True
            '.Columns("Observaciones").HeaderText = "Observaciones"
            '.Columns("Observaciones").Width = 80
            '.Columns("Observaciones").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Recontado").Visible = True
            '.Columns("Recontado").HeaderText = "Recontado"
            '.Columns("Recontado").Width = 80
            '.Columns("Recontado").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

        End With

    End Sub

    Private Sub Grilla_Detalle_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla_Detalle.KeyDown

        Dim _Cabeza = Grilla_Detalle.Columns(Grilla_Detalle.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla_Detalle.CurrentRow

        Dim _Index As Integer = _Fila.Index

        Select Case e.KeyValue

            Case Keys.Enter

                If _Cabeza = "Codproducto" Or _Cabeza = "CantidadUd1" Then

                    SendKeys.Send("{F2}")
                    e.Handled = True
                    Grilla_Detalle.Columns(_Cabeza).ReadOnly = False
                    Grilla_Detalle.BeginEdit(True)

                End If

            Case Keys.Delete

                Grilla_Detalle.Rows.RemoveAt(_Index)
                MessageBoxEx.Show(Me, "Fila eliminada", "Eliminar Fila", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Case Keys.Down

                'AgregarNuevaFila()

        End Select

        'Dim _ss = _Cl_Stmp.Zw_Stmp_Det

    End Sub

    Function Fx_BuscarProducto(_Codigo As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row) Then _Mensaje.EsCorrecto = True

            If Not _Mensaje.EsCorrecto Then

                Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
                Fm.Pro_Tipo_Lista = "P"
                Fm.Pro_Lista_Busqueda = ModListaPrecioVenta
                Fm.Pro_CodEntidad = String.Empty
                Fm.Pro_Mostrar_Info = True
                Fm.BtnCrearProductos.Visible = False
                Fm.Txtdescripcion.Text = _Codigo
                Fm.BtnExportaExcel.Visible = False
                Fm.Pro_Actualizar_Precios = False

                Fm.ShowDialog(Me)

                If Fm.Pro_Seleccionado Then
                    _Row = Fm.Pro_RowProducto
                Else
                    _Mensaje.Cancelado = True
                    Throw New System.Exception("Producto no seleccionado")
                End If

            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Buscar Producto"
            _Mensaje.Mensaje = "Producto encontrado"
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Tag = _Row

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Buscar Producto"
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop
        End Try

        Return _Mensaje

    End Function

    Private Sub Grilla_Detalle_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Detalle.CellEndEdit

        Dim _Cabeza = Grilla_Detalle.Columns(e.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla_Detalle.CurrentRow

        Dim _Index As Integer = _Fila.Index

        Select Case _Cabeza

            Case "Codproducto"

                Dim _Codigo = _Fila.Cells("Codproducto").Value

                Dim _Mensaje As New LsValiciones.Mensajes
                _Mensaje = Fx_BuscarProducto(_Codigo)

                If Not _Mensaje.EsCorrecto Then

                    MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)
                    Grilla_Detalle.Rows.RemoveAt(_Index)
                    Return

                End If

                Dim nextColumnIndex As Integer = e.ColumnIndex + 1
                Dim currentRow As DataGridViewRow = Grilla_Detalle.CurrentRow

                ' Verificar si hay una columna siguiente en la misma fila
                If nextColumnIndex < Grilla_Detalle.Columns.Count Then
                    ' Establecer la celda activa en la siguiente columna de la misma fila
                    Grilla_Detalle.CurrentCell = currentRow.Cells("CantidadUd1")
                End If

                'Dim _Row As DataRow = _Mensaje.Tag

                'With _Fila

                '    .Cells("Codigo").Value = _Row.Item("KOPR")
                '    .Cells("Descripcion").Value = _Row.Item("DEPR")
                '    .Cells("Unidad").Value = _Row.Item("UNPR")
                '    .Cells("Cantidad").Value = 1
                '    .Cells("Precio").Value = _Row.Item("PRPR")
                '    .Cells("Total").Value = _Row.Item("PRPR")

                'End With

            Case "Cantidad"

                Dim _Cantidad = _Fila.Cells("Cantidad").Value
                Dim _Precio = _Fila.Cells("Precio").Value

                _Fila.Cells("Total").Value = _Cantidad * _Precio

        End Select

    End Sub

    Private Sub AgregarNuevaFila()
        ' Crear una nueva instancia de la clase Zw_Stmp_Det
        Dim nuevaFila As New Zw_Inv_Hoja_Detalle

        ' Agregar la nueva fila a la lista _Cl_Conteo.Ls_Zw_Inv_Hoja_Detalle
        Cl_Conteo.Ls_Zw_Inv_Hoja_Detalle.Add(nuevaFila)
        Grilla_Detalle.Refresh()

    End Sub

    Private Sub Grilla_Detalle_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs)

        Dim nuevaFila As DataGridViewRow = Grilla_Detalle.Rows(e.RowIndex)

        ' Realizar las validaciones necesarias en la nueva fila
        If Not ValidarFila(nuevaFila) Then
            ' Cancelar la validación y mantener el foco en la fila actual
            e.Cancel = True
        End If
    End Sub

    Private Function ValidarFila(fila As DataGridViewRow) As Boolean
        ' Realizar las validaciones en la fila
        ' Por ejemplo, verificar que los campos obligatorios estén completos

        If Not fila.IsNewRow Then
            ' No se valida la fila nueva
            Return True
        End If

        If IsNothing(fila.Cells("Codproducto").Value) Then
            Return True
        End If

        Dim codigo As String = fila.Cells("Codproducto").Value.ToString()
        Dim cantidad As Integer = Convert.ToInt32(fila.Cells("CantidadUd1").Value)

        If String.IsNullOrEmpty(codigo) Then
            MessageBox.Show("El campo Código es obligatorio.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If cantidad <= 0 Then
            MessageBox.Show("La cantidad debe ser mayor a cero.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        ' Si todas las validaciones pasan, la fila es válida
        Return True
    End Function

End Class

