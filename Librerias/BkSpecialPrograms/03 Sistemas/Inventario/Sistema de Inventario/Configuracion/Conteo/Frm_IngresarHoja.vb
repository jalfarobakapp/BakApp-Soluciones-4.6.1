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

            .Columns("Ubicacion").Visible = True
            .Columns("Ubicacion").HeaderText = "Ubicacion"
            .Columns("Ubicacion").Width = 120
            .Columns("Ubicacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codigo").Visible = True
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Width = 100
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Width = 300
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantidadUd1").Visible = True
            .Columns("CantidadUd1").HeaderText = "Cantidad"
            .Columns("CantidadUd1").Width = 80
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

        If IsNothing(Grilla_Detalle.CurrentCell) Then
            Return
        End If

        Dim _Cabeza = Grilla_Detalle.Columns(Grilla_Detalle.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla_Detalle.CurrentRow

        Dim _Codproducto As String = NuloPorNro(Of String)(_Fila.Cells("Codigo").Value, "")
        Dim _CantidadUd1 As Double = _Fila.Cells("CantidadUd1").Value
        Dim _Ubicacion As String = NuloPorNro(Of String)(_Fila.Cells("Ubicacion").Value, "")

        Dim _Index As Integer = _Fila.Index

        Select Case e.KeyValue

            Case Keys.Enter

                If _Cabeza = "Descripcion" Then
                    e.Handled = True
                    Return
                End If

                If _Cabeza = "Codigo" Or _Cabeza = "CantidadUd1" Or _Cabeza = "Ubicacion" Then

                    If _Fila.IsNewRow Then

                        If _Cabeza = "CantidadUd1" Then

                            If String.IsNullOrEmpty(_Ubicacion) Then
                                MessageBoxEx.Show(Me, "Debe ingresar la ubicación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Grilla_Detalle.CurrentCell = _Fila.Cells("Ubicacion")
                                Return
                            End If

                            If String.IsNullOrEmpty(_Codproducto) Then
                                MessageBoxEx.Show(Me, "Debe ingresar un código de producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Grilla_Detalle.CurrentCell = _Fila.Cells("Codigo")
                                Return
                            End If

                        End If

                        If _Cabeza = "Codigo" And String.IsNullOrEmpty(_Ubicacion) Then
                            MessageBoxEx.Show(Me, "Debe ingresar la ubicación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Grilla_Detalle.CurrentCell = _Fila.Cells("Ubicacion")
                            Return
                        End If

                        SendKeys.Send("{F2}")
                        e.Handled = True
                        Grilla_Detalle.Columns(_Cabeza).ReadOnly = False
                        Grilla_Detalle.BeginEdit(True)

                    End If

                    If Not _Fila.IsNewRow Then

                        If _Cabeza = "CantidadUd1" Then

                            If String.IsNullOrEmpty(_Ubicacion) Then
                                MessageBoxEx.Show(Me, "Debe ingresar la ubicación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Grilla_Detalle.CurrentCell = _Fila.Cells("Ubicacion")
                                e.Handled = True
                                Return
                            End If

                            If String.IsNullOrEmpty(_Codproducto) Then
                                MessageBoxEx.Show(Me, "Debe ingresar un código de producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Grilla_Detalle.CurrentCell = _Fila.Cells("Codigo")
                                e.Handled = True
                                Return
                            End If

                        End If

                        If _Cabeza = "Codigo" Then

                            If String.IsNullOrEmpty(_Ubicacion) Then
                                MessageBoxEx.Show(Me, "Debe ingresar la ubicación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Grilla_Detalle.CurrentCell = _Fila.Cells("Ubicacion")
                                e.Handled = True
                                Return
                            End If

                            If Not String.IsNullOrEmpty(_Codproducto) Then
                                e.Handled = True
                                Return
                            End If

                        End If

                        If _Cabeza = "Ubicacion" Then

                            If Not String.IsNullOrEmpty(_Ubicacion) Then
                                e.Handled = True
                                Return
                            End If

                        End If

                        SendKeys.Send("{F2}")
                        e.Handled = True
                        Grilla_Detalle.Columns(_Cabeza).ReadOnly = False
                        Grilla_Detalle.BeginEdit(True)

                    End If

                End If


            Case Keys.Delete

                Try
                    If Not _Fila.IsNewRow Then
                        ' Asegúrate de que el índice sea válido antes de intentar eliminar
                        If _Index >= 0 AndAlso _Index < Grilla_Detalle.Rows.Count Then
                            Grilla_Detalle.Rows.RemoveAt(_Index)
                            MessageBoxEx.Show(Me, "Fila eliminada", "Eliminar Fila", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                Catch ex As Exception
                    MessageBoxEx.Show(Me, "Error al eliminar la fila: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            Case Keys.Down

                'AgregarNuevaFila()

        End Select
        Grilla_Detalle.Refresh()
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

        Try

            Select Case _Cabeza

                Case "Codigo"

                    Dim _Codigo = _Fila.Cells("Codigo").Value

                    Dim _Mensaje As New LsValiciones.Mensajes
                    _Mensaje = Fx_BuscarProducto(_Codigo)

                    If Not _Mensaje.EsCorrecto Then

                        _Fila.Cells("Codigo").Value = String.Empty
                        Return

                    End If

                    Dim _Row As DataRow = _Mensaje.Tag

                    With _Fila

                        .Cells("Codigo").Value = _Row.Item("KOPR")
                        .Cells("Descripcion").Value = _Row.Item("NOKOPR")
                        .Cells("Udtrpr").Value = 1
                        .Cells("CantidadUd1").Value = 0

                    End With

                    Grilla_Detalle.CurrentCell = _Fila.Cells("CantidadUd1")

                Case "Cantidad"

                    Dim _Cantidad = _Fila.Cells("Cantidad").Value
                    Dim _Precio = _Fila.Cells("Precio").Value

                    _Fila.Cells("Total").Value = _Cantidad * _Precio

                Case "Ubicacion"

                    Dim _Ubicacion As String = NuloPorNro(Of String)(_Fila.Cells("Ubicacion").Value?.ToString.Trim, "")

                    If String.IsNullOrEmpty(_Ubicacion) Then
                        Return
                    End If

                    Dim _Cl_InvUbicacion As New Cl_InvUbicacion
                    Dim _Mensaje As New LsValiciones.Mensajes

                    _Mensaje = _Cl_InvUbicacion.Fx_Llenar_Zw_Inv_Ubicaciones(_IdInventario, _Ubicacion)

                    If Not _Mensaje.EsCorrecto Then

                        MessageBoxEx.Show(Me, "Ubicación no existe", "Validación", MessageBoxButtons.OK, _Mensaje.Icono)

                        If Not _Fila.IsNewRow Then
                            Grilla_Detalle.Rows.RemoveAt(_Index)
                            'Grilla_Detalle.CurrentCell = Grilla_Detalle.Rows(e.RowIndex).Cells("Ubicacion")
                            'Grilla_Detalle.BeginEdit(True)
                        End If

                        Return

                    End If

                    Grilla_Detalle.CurrentCell = _Fila.Cells("Codigo")

            End Select

        Catch ex As Exception
        Finally
            Grilla_Detalle.Columns(_Cabeza).ReadOnly = True
        End Try

    End Sub

    Private Sub Grilla_Detalle_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs)

        ' Obtener la fila que se está validando
        Dim nuevaFila As DataGridViewRow = Grilla_Detalle.Rows(e.RowIndex)
        Dim _Cabeza = Grilla_Detalle.Columns(e.ColumnIndex).Name

        ' Realizar las validaciones necesarias en la nueva fila
        If Not ValidarFila(nuevaFila, _Cabeza) Then
            ' Cancelar la validación y mantener el foco en la fila actual
            e.Cancel = True
        End If

    End Sub

    Private Function ValidarFila(_Fila As DataGridViewRow, _Cabeza As String) As Boolean
        ' Realizar las validaciones en la fila
        ' Por ejemplo, verificar que los campos obligatorios estén completos

        If Not _Fila.IsNewRow Then
            ' No se valida la fila nueva

            If _Cabeza = "Codigo" Then
                If _Fila.Cells("Codigo").Value Is Nothing Then
                    Return False
                End If
            End If

            If _Cabeza = "Ubicacion" Then
                If _Fila.Cells("Ubicacion").Value Is Nothing Then
                    Return False
                End If
            End If

        End If


        If IsNothing(_Fila.Cells("Codigo").Value) Then
            Return True
        End If

        Dim cantidad As Integer = Convert.ToInt32(_Fila.Cells("CantidadUd1").Value)

        Dim codigoProducto As String = _Fila.Cells("Codigo").Value?.ToString()
        Dim codigoUbicacion As String = _Fila.Cells("Ubicacion").Value?.ToString()

        If String.IsNullOrEmpty(codigoProducto) OrElse String.IsNullOrEmpty(codigoUbicacion) Then
            Return False
        End If

        If _Cabeza = "CantidadUd1" And cantidad <= 0 Then
            Return False
        End If

        'If cantidad <= 0 Then
        '    'MessageBoxEx.Show(Me, "La cantidad debe ser mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return False
        'End If

        ' Si todas las validaciones pasan, la fila es válida
        Return True
    End Function

    'Private Sub Grilla_Detalle_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grilla_Detalle.RowsAdded
    '    ' Obtener la nueva fila agregada
    '    Dim nuevaFila As DataGridViewRow = Grilla_Detalle.Rows(e.RowIndex)

    '    ' Desactivar la creación automática de filas nuevas
    '    Grilla_Detalle.AllowUserToAddRows = False

    '    '' Poner el foco en la columna deseada de la nueva fila
    '    'nuevaFila.Cells("Ubicacion").Selected = True
    'End Sub

    Private Sub Grilla_Detalle_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Detalle.CellEnter
        ' Obtener la columna deseada
        Dim columnaDeseada As DataGridViewColumn = Grilla_Detalle.Columns("CantidadUd1")
        Dim nuevaFila As DataGridViewRow = Grilla_Detalle.Rows(e.RowIndex)


        If nuevaFila.IsNewRow Then
            ' Utilizar BeginInvoke para posponer el cambio de celda
            Me.BeginInvoke(New MethodInvoker(Sub()
                                                 Try
                                                     ' Verificar si la celda aún es accesible antes de cambiar el foco
                                                     If nuevaFila.IsNewRow AndAlso nuevaFila.Cells("Ubicacion").RowIndex < Grilla_Detalle.Rows.Count Then
                                                         Grilla_Detalle.CurrentCell = nuevaFila.Cells("Ubicacion")
                                                         Grilla_Detalle.BeginEdit(True)
                                                     End If
                                                 Catch ex As Exception
                                                     ' Manejar la excepción si es necesario
                                                 End Try
                                             End Sub))
        End If

    End Sub


    Private Sub Grilla_Detalle_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grilla_Detalle.DataError
        ' Manejar los errores de datos
        ' Por ejemplo, mostrar un mensaje de error al usuario
        'MessageBoxEx.Show(Me, "Error de datos en la celda " & e.ColumnIndex & ", " & e.RowIndex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
End Class

