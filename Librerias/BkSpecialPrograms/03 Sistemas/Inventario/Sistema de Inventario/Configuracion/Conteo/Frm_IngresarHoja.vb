Imports System.ComponentModel
Imports System.IO
Imports DevComponents.DotNetBar
Imports Newtonsoft.Json

Public Class Frm_IngresarHoja

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Cl_Inventario As New Cl_Inventario
    Public Property Cl_Conteo As New Cl_Conteo
    Public Property Reconteo As Boolean
    Public Property CodigoReconteo As String

    Private _IdInventario As Integer
    Private _IdHoja As Integer
    Private _CodFuncionario As String

    ' Crear un BindingSource y enlazarlo al DataGridView
    Dim _Source As BindingSource

    Public Sub New(_IdInventario As Integer, _IdHoja As Integer, _CodFuncionario As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._IdHoja = _IdHoja
        Me._IdInventario = _IdInventario
        Me._CodFuncionario = _CodFuncionario

        Cl_Inventario.Fx_Llenar_Zw_Inv_Inventario(_IdInventario)

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        If CBool(_IdHoja) Then
            Cl_Conteo.Fx_Llenar_Zw_Inv_Hoja(_IdHoja)
        Else
            Cl_Conteo.Fx_Nueva_Hoja(Cl_Inventario.Zw_Inv_Inventario, _NombreEquipo, _CodFuncionario)
            Txt_Nro_Hoja.Text = "En Construcción..."
        End If

        Sb_Formato_Generico_Grilla(Grilla_Detalle, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, False, False)
        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_IngresarHoja_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Chk_Reconteo.Checked = Reconteo

        Me.ActiveControl = Txt_IdContador1
        Sb_ActualizarGrilla()

        AddHandler Grilla_Detalle.RowValidating, AddressOf Grilla_Detalle_RowValidating
        AddHandler Grilla_Detalle.EditingControlShowing, AddressOf Grilla_Detalle_EditingControlShowing
        AddHandler Grilla_Detalle.MouseDown, AddressOf Grilla_MouseDown
        AddHandler Grilla_Detalle.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Txt_Nro_Hoja.ReadOnly = True
        Txt_Nro_Hoja.Enabled = CBool(_IdHoja)

        Txt_IdContador1.Tag = 0
        Txt_IdContador2.Tag = 0

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

            .Columns("Sector").Visible = True
            .Columns("Sector").HeaderText = "Sector"
            .Columns("Sector").Width = 110
            .Columns("Sector").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Ubicacion").Visible = True
            .Columns("Ubicacion").HeaderText = "Ubicación"
            .Columns("Ubicacion").Width = 100
            .Columns("Ubicacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codigo").Visible = True
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Width = 100
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Width = 250
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").HeaderText = "Cantidad"
            .Columns("Cantidad").Width = 60
            .Columns("Cantidad").DefaultCellStyle.Format = "##,###0.#####"
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Grilla_Detalle_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla_Detalle.KeyDown

        If IsNothing(Grilla_Detalle.CurrentCell) Then
            Return
        End If

        Dim _Cabeza = Grilla_Detalle.Columns(Grilla_Detalle.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla_Detalle.CurrentRow

        Dim _Codproducto As String = NuloPorNro(Of String)(_Fila.Cells("Codigo").Value, "")
        Dim _CantidadUd1 As Double = _Fila.Cells("Cantidad").Value
        Dim _Sector As String = NuloPorNro(Of String)(_Fila.Cells("Sector").Value, "")

        Dim _Index As Integer = _Fila.Index

        Select Case e.KeyValue

            Case Keys.Enter

                If _Cabeza = "Descripcion" Then
                    e.Handled = True
                    Return
                End If

                If _Cabeza = "Codigo" Or _Cabeza = "Cantidad" Or _Cabeza = "Sector" Or _Cabeza = "Ubicacion" Then

                    If _Fila.IsNewRow Then

                        If String.IsNullOrEmpty(Txt_Nro_Hoja.Text) Then
                            MessageBoxEx.Show(Me, "Debe ingresar el número de hoja", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Txt_Nro_Hoja.Focus()
                            Return
                        End If

                        If String.IsNullOrEmpty(Txt_IdContador1.Text) Then
                            MessageBoxEx.Show(Me, "Debe ingresar el contador 1", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Txt_IdContador1.Focus()
                            Return
                        End If

                        If _Cabeza = "Cantidad" Then

                            If String.IsNullOrEmpty(_Sector) Then
                                MessageBoxEx.Show(Me, "Debe ingresar el sector", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Grilla_Detalle.CurrentCell = _Fila.Cells("Sector")
                                Return
                            End If

                            If String.IsNullOrEmpty(_Codproducto) Then
                                MessageBoxEx.Show(Me, "Debe ingresar un código de producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Grilla_Detalle.CurrentCell = _Fila.Cells("Codigo")
                                Return
                            End If

                        End If

                        If _Cabeza = "Codigo" And String.IsNullOrEmpty(_Sector) Then
                            MessageBoxEx.Show(Me, "Debe ingresar el sector", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Grilla_Detalle.CurrentCell = _Fila.Cells("Sector")
                            Return
                        End If

                        If _Cabeza = "Sector" Then

                            Dim _Codigo As String

                            If Grilla_Detalle.RowCount > 1 Then
                                _Codigo = Grilla_Detalle.Rows(Grilla_Detalle.CurrentCell.RowIndex - 1).Cells("Codigo").Value
                                If String.IsNullOrWhiteSpace(_Codigo) Then
                                    MessageBoxEx.Show(Me, "Debe ingresar un código de producto en la fila anterior", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Grilla_Detalle.CurrentCell = Grilla_Detalle.Rows(Grilla_Detalle.RowCount - 1).Cells("Codigo")
                                    Return
                                End If
                            End If

                        End If

                        SendKeys.Send("{F2}")
                        e.Handled = True
                        Grilla_Detalle.Columns(_Cabeza).ReadOnly = False
                        Grilla_Detalle.BeginEdit(True)

                    End If

                    If Not _Fila.IsNewRow Then

                        If _Cabeza = "Cantidad" Then

                            If String.IsNullOrEmpty(_Sector) Then
                                MessageBoxEx.Show(Me, "Debe ingresar la ubicación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Grilla_Detalle.CurrentCell = _Fila.Cells("Sector")
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

                            If String.IsNullOrEmpty(_Sector) Then
                                MessageBoxEx.Show(Me, "Debe ingresar el sector", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Grilla_Detalle.CurrentCell = _Fila.Cells("Sector")
                                e.Handled = True
                                Return
                            End If

                            If Not String.IsNullOrEmpty(_Codproducto) Then
                                e.Handled = True
                                Return
                            End If

                        End If

                        If _Cabeza = "Ubicacion" Then

                            If String.IsNullOrEmpty(_Sector) Then
                                MessageBoxEx.Show(Me, "Debe ingresar el sector", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Grilla_Detalle.CurrentCell = _Fila.Cells("Sector")
                                e.Handled = True
                                Return
                            End If

                        End If

                        If _Cabeza = "Sector" Then

                            If Not String.IsNullOrEmpty(_Sector) Then
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

                            If MessageBoxEx.Show(Me, "¿Está seguro de eliminar la fila seleccionada?", "Eliminar Fila",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                                Return
                            End If

                            Grilla_Detalle.Rows.RemoveAt(_Index)

                        End If
                    End If
                Catch ex As Exception
                    MessageBoxEx.Show(Me, "Error al eliminar la fila: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            Case Keys.Down

        End Select

        Grilla_Detalle.Refresh()

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
                Fm.Pro_Mostrar_Info = False
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

                        .Cells("Nro_Hoja").Value = Txt_Nro_Hoja.Text
                        .Cells("Id").Value = _Fila.Index
                        .Cells("IdInventario").Value = _IdInventario
                        .Cells("Empresa").Value = Cl_Inventario.Zw_Inv_Inventario.Empresa
                        .Cells("Sucursal").Value = Cl_Inventario.Zw_Inv_Inventario.Sucursal
                        .Cells("Bodega").Value = Cl_Inventario.Zw_Inv_Inventario.Bodega
                        .Cells("Responsable").Value = _CodFuncionario
                        .Cells("TipoConteo").Value = String.Empty
                        .Cells("Codigo").Value = _Row.Item("KOPR")
                        .Cells("Descripcion").Value = _Row.Item("NOKOPR")
                        .Cells("Udtrpr").Value = 1
                        .Cells("Rtu").Value = _Row.Item("RLUD")
                        .Cells("Cantidad").Value = 0
                        .Cells("Ud1").Value = _Row.Item("UD01PR")
                        .Cells("Ud2").Value = _Row.Item("UD02PR")
                        .Cells("Reconteo").Value = Chk_Reconteo.Checked

                    End With

                    Grilla_Detalle.CurrentCell = _Fila.Cells("Cantidad")

                Case "Cantidad"

                    Dim _Cantidad As Double = _Fila.Cells("Cantidad").Value
                    Dim _Udtrpr As Integer = _Fila.Cells("Udtrpr").Value
                    Dim _Rtu As Double = _Fila.Cells("Rtu").Value

                    If _Udtrpr = 1 Then
                        _Fila.Cells("CantidadUd1").Value = _Cantidad
                        _Fila.Cells("CantidadUd2").Value = _Cantidad * _Rtu
                    End If

                    If _Udtrpr = 2 Then
                        _Fila.Cells("CantidadUd2").Value = _Cantidad
                        _Fila.Cells("CantidadUd1").Value = _Cantidad / _Rtu
                    End If

                Case "Sector"

                    Dim _Sector As String = NuloPorNro(Of String)(_Fila.Cells("Sector").Value?.ToString.Trim, "")

                    'If String.IsNullOrEmpty(_Sector) Then
                    '    Return
                    'End If

                    Dim _Cl_InvUbicacion As New Cl_InvSectores
                    Dim _Mensaje As New LsValiciones.Mensajes

                    _Mensaje = _Cl_InvUbicacion.Fx_Llenar_Zw_Inv_Sector(_IdInventario, _Sector)

                    If Not _Mensaje.EsCorrecto Then

                        If Not String.IsNullOrEmpty(_Sector) Then
                            MessageBoxEx.Show(Me, "Sector no existe", "Validación", MessageBoxButtons.OK, _Mensaje.Icono)
                        End If

                        _Sector = Fx_BuscarSector()
                        If String.IsNullOrEmpty(_Sector) Then
                            If Not _Fila.IsNewRow Then
                                Grilla_Detalle.Rows.RemoveAt(_Index)
                            End If
                            Return
                        End If
                        _Fila.Cells("Sector").Value = _Sector

                        _Mensaje = _Cl_InvUbicacion.Fx_Llenar_Zw_Inv_Sector(_IdInventario, _Sector)
                        'If Not _Fila.IsNewRow Then
                        '    Grilla_Detalle.Rows.RemoveAt(_Index)
                        'End If
                        'Return

                    End If

                    _Fila.Cells("IdSector").Value = _Cl_InvUbicacion.Zw_Inv_Sector.Id

                    If Reconteo Then

                        _Fila.Cells("Codigo").Value = CodigoReconteo

                        Consulta_sql = "Select KOPR,NOKOPR,RLUD,UD01PR,UD02PR From MAEPR Where KOPR = '" & CodigoReconteo & "'"
                        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                        With _Fila

                            .Cells("Nro_Hoja").Value = Txt_Nro_Hoja.Text
                            .Cells("Id").Value = _Fila.Index
                            .Cells("IdInventario").Value = _IdInventario
                            .Cells("Empresa").Value = Cl_Inventario.Zw_Inv_Inventario.Empresa
                            .Cells("Sucursal").Value = Cl_Inventario.Zw_Inv_Inventario.Sucursal
                            .Cells("Bodega").Value = Cl_Inventario.Zw_Inv_Inventario.Bodega
                            .Cells("Responsable").Value = _CodFuncionario
                            .Cells("TipoConteo").Value = String.Empty
                            .Cells("Codigo").Value = _Row.Item("KOPR")
                            .Cells("Descripcion").Value = _Row.Item("NOKOPR")
                            .Cells("Udtrpr").Value = 1
                            .Cells("Rtu").Value = _Row.Item("RLUD")
                            .Cells("Cantidad").Value = 0
                            .Cells("Ud1").Value = _Row.Item("UD01PR")
                            .Cells("Ud2").Value = _Row.Item("UD02PR")
                            .Cells("Recontado").Value = Chk_Reconteo.Checked

                        End With

                        Grilla_Detalle.CurrentCell = _Fila.Cells("Cantidad")
                    Else
                        Grilla_Detalle.CurrentCell = _Fila.Cells("Ubicacion")
                    End If

                Case "Ubicacion"
                    Grilla_Detalle.CurrentCell = _Fila.Cells("Codigo")
            End Select

        Catch ex As Exception
        Finally
            If _Cabeza <> "_Cabeza" Then
                Grilla_Detalle.Columns(_Cabeza).ReadOnly = True
            End If
        End Try

    End Sub

    Function Fx_BuscarSector() As String

        Dim _Sector As String = String.Empty

        Dim Fm As New Frm_Inv_Sector_Lista(_IdInventario)
        Fm.ModoSeleccionSector = True
        Fm.Text = "UBICACIONES DEL INVENTARIO: " & Cl_Inventario.Zw_Inv_Inventario.NombreInventario
        Fm.ShowDialog(Me)
        If Fm._SectorSeleccionado Then
            _Sector = Fm._Zw_Inv_Sector_Seleccionado.Sector
        End If

        Return _Sector

    End Function

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

            If _Cabeza = "Sector" Then
                If _Fila.Cells("Sector").Value Is Nothing Then
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

        Dim cantidad As Integer = Convert.ToInt32(_Fila.Cells("Cantidad").Value)

        Dim codigoProducto As String = _Fila.Cells("Codigo").Value?.ToString()
        Dim codigoSector As String = _Fila.Cells("Sector").Value?.ToString()

        If String.IsNullOrEmpty(codigoProducto) OrElse String.IsNullOrEmpty(codigoSector) Then
            Return False
        End If

        If _Cabeza = "Cantidad" And cantidad <= 0 Then
            Return False
        End If

        If _Cabeza = "Codigo" And cantidad = 0 Then
            Grilla_Detalle.CurrentCell = _Fila.Cells("Cantidad")
            Return False
        End If

        'If cantidad <= 0 Then
        '    'MessageBoxEx.Show(Me, "La cantidad debe ser mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return False
        'End If

        ' Si todas las validaciones pasan, la fila es válida
        Return True
    End Function

    Private Sub Grilla_Detalle_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Detalle.CellEnter
        ' Obtener la columna deseada
        Dim columnaDeseada As DataGridViewColumn = Grilla_Detalle.Columns("Cantidad")
        Dim nuevaFila As DataGridViewRow = Grilla_Detalle.Rows(e.RowIndex)


        If nuevaFila.IsNewRow Then
            ' Utilizar BeginInvoke para posponer el cambio de celda
            Me.BeginInvoke(New MethodInvoker(Sub()
                                                 Try
                                                     ' Verificar si la celda aún es accesible antes de cambiar el foco
                                                     If nuevaFila.IsNewRow AndAlso nuevaFila.Cells("Sector").RowIndex < Grilla_Detalle.Rows.Count Then
                                                         If String.IsNullOrWhiteSpace(nuevaFila.Cells("Sector").Value) Then
                                                             Grilla_Detalle.CurrentCell = nuevaFila.Cells("Sector")
                                                             Grilla_Detalle.BeginEdit(True)
                                                         End If
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

    Private Sub Grilla_Detalle_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
        Dim validar As TextBox = CType(e.Control, TextBox)
        AddHandler validar.KeyPress, AddressOf Sb_Validar_Keypress
    End Sub

    Private Sub Sb_Validar_Keypress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        ' obtener indice de la columna

        'With sender

        Dim _Columna As Integer = Grilla_Detalle.CurrentCellAddress.X 'Current.ColumnIndex
        Dim _Fila As Integer = Grilla_Detalle.CurrentCellAddress.Y 'Current.ColumnIndex

        Dim _Cabeza = Grilla_Detalle.Columns(_Columna).Name

        ' comprobar si la celda en edición corresponde a la columna 1 o 2
        If _Cabeza = "Cantidad" Or _Cabeza = "Precio" Or _Cabeza = "DescuentoPorc" Or _Cabeza = "DescuentoValor" Then

            ' Obtener caracter  
            Dim _Caracter As Char = e.KeyChar

            ' referencia a la celda  
            Dim _Txt As TextBox = CType(sender, TextBox)

            If e.KeyChar = "."c Then
                ' si se pulsa la coma se convertirá en punto
                'e.Handled = True
                SendKeys.Send(",")
                e.KeyChar = ","c
                _Caracter = ","
            End If

            Dim _Caracter_Raro = ChrW(Keys.Back)
            Dim _EsNumero As Boolean = Char.IsNumber(_Caracter)

            ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
            ' es el separador decimal, y que no contiene ya el separador  
            If (Char.IsNumber(_Caracter)) Or
               (_Caracter = ChrW(Keys.Back)) Or
               ((_Caracter = "-") And (_Txt.Text.Contains("-") = False)) Or
               (_Caracter = ",") And (_Txt.Text.Contains(",") = False) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

        End If

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        'If String.IsNullOrEmpty(Txt_Nro_Hoja.Text) Then
        '    MessageBoxEx.Show(Me, "Debe ingresar el número de hoja", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Txt_Nro_Hoja.Focus()
        '    Return
        'End If

        If String.IsNullOrEmpty(Txt_IdContador1.Text) Then
            MessageBoxEx.Show(Me, "Debe ingresar el contador 1", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_IdContador1.Focus()
            Return
        End If

        If Cl_Conteo.Ls_Zw_Inv_Hoja_Detalle.Count = 0 Then
            MessageBoxEx.Show(Me, "Debe ingresar al menos un producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Grilla_Detalle.Focus()
            Grilla_Detalle.CurrentCell = Grilla_Detalle.Rows(Grilla_Detalle.Rows.Count - 1).Cells("Sector")
            Return
        End If

        Dim _Item As Integer = 1

        For Each _Fila As DataGridViewRow In Grilla_Detalle.Rows

            'If Not _Fila.IsNewRow AndAlso _Fila.Cells("Cantidad").Value <= 0 Then
            '    MessageBoxEx.Show(Me, "La cantidad debe ser mayor a cero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    Grilla_Detalle.Focus()
            '    Grilla_Detalle.CurrentCell = Grilla_Detalle.Rows(_Fila.Index).Cells("Cantidad")
            '    Return
            'End If

            _Fila.Cells("Item_Hoja").Value = numero_(_Item, 5)
            _Item += 1

            _Fila.Cells("IdContador1").Value = NuloPorNro(Of Integer)(Txt_IdContador1.Tag, 0)
            _Fila.Cells("IdContador2").Value = NuloPorNro(Of Integer)(Txt_IdContador2.Tag, 0)

        Next

        Cl_Conteo.Ls_Zw_Inv_Hoja_Detalle.RemoveAll(Function(d) d.Codigo = "")

        With Cl_Conteo.Zw_Inv_Hoja

            .NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")
            .IdContador1 = Txt_IdContador1.Tag
            .IdContador2 = Txt_IdContador2.Tag
            .Nro_Hoja = Txt_Nro_Hoja.Text
            .FechaCreacion = Dtp_FechaCreacion.Value
            .Reconteo = Chk_Reconteo.Checked

        End With

        'Dim json As String

        'json = JsonConvert.SerializeObject(Cl_Conteo.Ls_Zw_Inv_Hoja_Detalle, Formatting.Indented)
        'File.WriteAllText("D:\JsonB4Android\Inventario\Ls_Zw_Inv_Hoja_Detalle.json", json)

        'json = JsonConvert.SerializeObject(Cl_Conteo.Zw_Inv_Hoja, Formatting.Indented)
        'File.WriteAllText("D:\JsonB4Android\Inventario\Zw_Inv_Hoja.json", json)

        Dim _Mensaje As LsValiciones.Mensajes

        _Mensaje = Cl_Conteo.Fx_Grabar_Nueva_Hoja()

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If Not _Mensaje.EsCorrecto Then
            Return
        End If

        Me.Close()

    End Sub

    Private Sub Txt_IdContador1_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_IdContador1.ButtonCustomClick
        Sb_BuscarContador(sender)
    End Sub

    Private Sub Txt_IdContador1_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_IdContador1.ButtonCustom2Click
        If Not String.IsNullOrEmpty(Txt_IdContador2.Text) Then
            If Not String.IsNullOrEmpty(Txt_IdContador2.Tag) Then
                MessageBoxEx.Show(Me, "Debe eliminar el contador 2", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_IdContador2.Focus()
                Return
            End If
        End If
        Txt_IdContador1.Tag = 0
        Txt_IdContador1.Text = String.Empty
    End Sub

    Private Sub Txt_IdContador2_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_IdContador2.ButtonCustomClick
        If String.IsNullOrEmpty(Txt_IdContador1.Text) Then
            MessageBoxEx.Show(Me, "Debe ingresar el contador 1", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_IdContador1.Focus()
            Return
        End If
        Sb_BuscarContador(sender)
    End Sub

    Private Sub Txt_IdContador2_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_IdContador2.ButtonCustom2Click
        Txt_IdContador2.Tag = 0
        Txt_IdContador2.Text = String.Empty
    End Sub

    Sub Sb_BuscarContador(_Txt As TextBox)

        Dim _Zw_Inv_Contador As Zw_Inv_Contador
        Dim _Seleccionado As Boolean

        Dim Fm As New Frm_Contadores
        Fm.ModoSeleccion = True
        Fm.ShowDialog(Me)

        _Seleccionado = Fm.Seleccionado
        _Zw_Inv_Contador = Fm.Cl_Contador.Zw_Inv_Contador

        Fm.Dispose()

        If Not _Seleccionado Then
            Return
        End If

        If _Txt.Name = "Txt_IdContador1" Then
            If Txt_IdContador2.Tag = _Zw_Inv_Contador.Id Then
                MessageBoxEx.Show(Me, "El contador " & _Zw_Inv_Contador.Nombre & " ya fue seleccionado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

        If _Txt.Name = "Txt_IdContador2" Then
            If Txt_IdContador1.Tag = _Zw_Inv_Contador.Id Then
                MessageBoxEx.Show(Me, "El contador " & _Zw_Inv_Contador.Nombre & " ya fue seleccionado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

        _Txt.Tag = _Zw_Inv_Contador.Id
        _Txt.Text = _Zw_Inv_Contador.Nombre

    End Sub

    Private Sub Btn_Observaciones_Click(sender As Object, e As EventArgs) Handles Btn_Observaciones.Click

        Dim _Fila As DataGridViewRow = Grilla_Detalle.CurrentRow
        Dim _Observaciones As String = NuloPorNro(Of String)(_Fila.Cells("Observaciones").Value, "")
        Dim _Codigo As String = NuloPorNro(Of String)(_Fila.Cells("Codigo").Value, "")
        Dim _Descripcion As String = NuloPorNro(Of String)(_Fila.Cells("Descripcion").Value, "")
        Dim _Aceptar As Boolean

        _Aceptar = InputBox_Bk(Me, "Observaciones de la línea activa" & vbCrLf &
                               _Codigo & " - " & _Descripcion, "Observaciones", _Observaciones,
                               True, _Tipo_Mayus_Minus.Mayusculas, 200, True)

        If Not _Aceptar Then
            Return
        End If

        _Fila.Cells("Observaciones").Value = _Observaciones

    End Sub

    Private Sub Btn_Copiar_Click(sender As Object, e As EventArgs) Handles Btn_Copiar.Click
        With Grilla_Detalle
            Try
                Dim _Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
                Dim _Texto_Cabeza = .Columns(.CurrentCell.ColumnIndex).HeaderText

                Dim Copiar = .Rows(.CurrentRow.Index).Cells(_Cabeza).Value
                Clipboard.SetText(Copiar)

                ToastNotification.Show(Me, _Texto_Cabeza & " esta en el portapapeles", Btn_Copiar.Image,
                                       2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
            Catch ex As Exception
                MessageBoxEx.Show(Me, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End With
    End Sub

    Sub Grilla_MouseDown(sender As Object, e As MouseEventArgs)

        If e.Button = MouseButtons.Right Then

            Dim _Hti As DataGridView.HitTestInfo = Grilla_Detalle.HitTest(e.X, e.Y)

            If _Hti.RowIndex >= 0 Then

                Dim Hitest As DataGridView.HitTestInfo = Grilla_Detalle.HitTest(e.X, e.Y)

                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    Grilla_Detalle.CurrentCell = Grilla_Detalle.Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                Else
                    Return
                End If

                If Grilla_Detalle.CurrentRow.IsNewRow Then
                    Return
                End If

                Grilla_Detalle.Rows(_Hti.RowIndex).Selected = True
                ShowContextMenu(Menu_Contextual_01)

            End If

        End If

    End Sub

    Private Sub Btn_EliminarFila_Click(sender As Object, e As EventArgs) Handles Btn_EliminarFila.Click

        Dim _Fila As DataGridViewRow = Grilla_Detalle.CurrentRow
        Dim _Index As Integer = _Fila.Index

        Try
            If Not _Fila.IsNewRow Then
                ' Asegúrate de que el índice sea válido antes de intentar eliminar
                If _Index >= 0 AndAlso _Index < Grilla_Detalle.Rows.Count Then

                    If MessageBoxEx.Show(Me, "¿Está seguro de eliminar la fila seleccionada?", "Eliminar Fila",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                        Return
                    End If

                    Grilla_Detalle.Rows.RemoveAt(_Index)

                End If
            End If
        Catch ex As Exception
            MessageBoxEx.Show(Me, "Error al eliminar la fila: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Grilla_Detalle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Detalle.CellDoubleClick
        ' Simula la presión de la tecla Enter
        SendKeys.Send("{ENTER}")
    End Sub
End Class

