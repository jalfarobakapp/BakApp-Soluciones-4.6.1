Imports System.ComponentModel
Imports BkSpecialPrograms.Cl_Fincred_Bakapp.Cl_Fincred_SQL
Imports DevComponents.DotNetBar

Public Class Frm_Ver_Documento_CustomizarDet

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Source As BindingSource
    Private _Row_Producto As DataRow
    Private _Idmaeedo As Integer
    Private _Idmaeddo As Integer
    Private _Koen As String
    Private _Codigo As String
    Private _Cantidad As Double
    Public Property Cl_NVVCustomizable As Cl_NVVCustomizable

    Dim listaProductos As New BindingList(Of Zw_Docu_Det_Cust)

    Public Sub New(_Idmaeedo As Integer, _Idmaeddo As Integer, _Koen As String, _Codigo As String, _Cantidad As Double)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Idmaeedo = _Idmaeedo
        Me._Idmaeddo = _Idmaeddo
        Me._Koen = _Koen
        Me._Codigo = _Codigo
        Me._Cantidad = _Cantidad

        Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
        _Row_Producto = _Sql.Fx_Get_DataRow(Consulta_sql)

        Sb_Formato_Generico_Grilla(Grilla_Detalle, 18, New Font("Tahoma", 8), Color.LightYellow, ScrollBars.None, True, False, False)
        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Ver_Documento_CustomizarDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Cl_NVVCustomizable = New Cl_NVVCustomizable

        ' Asignar la lista de detalles a listaProductos
        listaProductos = New BindingList(Of Zw_Docu_Det_Cust)(Cl_NVVCustomizable.Ls_Detalle)

        AddHandler Grilla_Detalle.RowValidating, AddressOf Grilla_Detalle_RowValidating
        AddHandler Grilla_Detalle.EditingControlShowing, AddressOf Grilla_Detalle_EditingControlShowing
        AddHandler Grilla_Detalle.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Cl_NVVCustomizable = New Cl_NVVCustomizable

        Sb_Agregar_Nueva_Linea()

        Sb_ActualizarGrilla()

        Me.Text = "Producto: " & _Row_Producto.Item("KOPR").ToString.Trim & " - " & _Row_Producto.Item("NOKOPR").ToString.Trim & ", Cantidad: " & _Cantidad

        Cl_NVVCustomizable.Fx_Llenar_Detalle(_Idmaeddo)

        If Cl_NVVCustomizable.Ls_Detalle.Count > 0 Then

            Grilla_Detalle.Rows.Clear()

            For Each _Fila As Zw_Docu_Det_Cust In Cl_NVVCustomizable.Ls_Detalle

                listaProductos.Add(_Fila)

            Next

            Btn_Grabar.Enabled = Not CBool((_Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Docu_Ent", "HabilitadaFac", "Idmaeedo = " & _Idmaeedo,,,, True)))

        End If

    End Sub

    Sub Sb_Agregar_Nueva_Linea()

        Dim _Detalle As New Zw_Docu_Det_Cust

        With _Detalle

            .Id = 0
            .Idmaeedo = _Idmaeedo
            .Idmaeddo = _Idmaeddo
            .CodigoAlt = String.Empty
            .Descripcion = String.Empty
            .Cantidad = 0
            .Codigo = _Row_Producto.Item("KOPR")

        End With

        listaProductos.Add(_Detalle)
        Grilla_Detalle.Refresh()

        Try
            Grilla_Detalle.CurrentCell = Grilla_Detalle.Rows(Grilla_Detalle.RowCount - 1).Cells("CodigoAlt")
        Catch ex As Exception

        End Try

    End Sub

    Sub Sb_ActualizarGrilla()

        ' Desvincular el DataGridView
        Grilla_Detalle.DataSource = Nothing

        '' Crear un BindingList a partir de la lista
        'Dim bindingList As New BindingList(Of Zw_Docu_Det_Cust)(Cl_NVVCustomizable.Ls_Detalle)

        '' Crear un BindingSource y enlazarlo al DataGridView
        '_Source = New BindingSource(bindingList, Nothing)

        Dim bindingSource As New BindingSource()
        bindingSource.DataSource = listaProductos
        Grilla_Detalle.DataSource = bindingSource

        With Grilla_Detalle

            '.DataSource = _Source

            OcultarEncabezadoGrilla(Grilla_Detalle, True)

            Dim _DisplayIndex = 0

            .Columns("CodigoAlt").Visible = True
            .Columns("CodigoAlt").HeaderText = "Código"
            .Columns("CodigoAlt").Width = 120
            .Columns("CodigoAlt").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Width = 410
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").HeaderText = "Cantidad"
            .Columns("Cantidad").Width = 100
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Cantidad").DisplayIndex = _DisplayIndex
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

        Dim _CodigoAlt As String = NuloPorNro(Of String)(_Fila.Cells("CodigoAlt").Value, "")
        Dim _Cantidad As Double = _Fila.Cells("Cantidad").Value

        Dim _Index As Integer = _Fila.Index

        Select Case e.KeyValue

            Case Keys.Enter

                If _Cabeza = "Descripcion" Then
                    e.Handled = True
                    Return
                End If

                If _Cabeza = "CodigoAlt" Or _Cabeza = "Cantidad" Then

                    If _Fila.IsNewRow Then

                        If _Cabeza = "Cantidad" Then

                            If String.IsNullOrEmpty(_CodigoAlt) Then
                                MessageBoxEx.Show(Me, "Debe ingresar un código de producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Grilla_Detalle.CurrentCell = _Fila.Cells("CodigoAlt")
                                Return
                            End If

                        End If

                        SendKeys.Send("{F2}")
                        e.Handled = True
                        Grilla_Detalle.Columns(_Cabeza).ReadOnly = False
                        Grilla_Detalle.BeginEdit(True)

                    End If

                    If Not _Fila.IsNewRow Then

                        If _Cabeza = "Cantidad" Then

                            If String.IsNullOrEmpty(_CodigoAlt) Then
                                MessageBoxEx.Show(Me, "Debe ingresar un código de producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Grilla_Detalle.CurrentCell = _Fila.Cells("CodigoAlt")
                                e.Handled = True
                                Return
                            End If

                        End If

                        If _Cabeza = "CodigoAlt" Then

                            If Not String.IsNullOrEmpty(_CodigoAlt) Then
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

                    If Grilla_Detalle.Rows.Count = 0 Then
                        Sb_Agregar_Nueva_Linea()
                    End If

                Catch ex As Exception
                    MessageBoxEx.Show(Me, "Error al eliminar la fila: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            Case Keys.Down

                ' Verificar si la fila actual es la última fila visible
                If Grilla_Detalle.CurrentRow.Index = Grilla_Detalle.Rows.Count - 1 Then

                    If Not String.IsNullOrEmpty(_CodigoAlt) Then
                        Sb_Agregar_Nueva_Linea()
                    End If

                End If

        End Select

        Grilla_Detalle.Refresh()

    End Sub

    Private Sub Grilla_Detalle_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Detalle.CellEndEdit

        Dim _Cabeza = Grilla_Detalle.Columns(e.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla_Detalle.CurrentRow

        Dim _Index As Integer = _Fila.Index

        Try

            Select Case _Cabeza

                Case "CodigoAlt"

                    Dim _Codigo = _Row_Producto.Item("KOPR")

                    Dim _Mensaje As New LsValiciones.Mensajes
                    _Mensaje = Fx_BuscarProducto(_Codigo)

                    If Not _Mensaje.EsCorrecto Then

                        MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                        _Fila.Cells("CodigoAlt").Value = String.Empty

                        Return

                    End If

                    Dim _Row As DataRow = _Mensaje.Tag
                    Dim _Id = _Idmaeddo

                    ' Verificar si el código ya está en la lista
                    For Each row As DataGridViewRow In Grilla_Detalle.Rows
                        If Not row.IsNewRow AndAlso row.Index <> _Index AndAlso row.Cells("CodigoAlt").Value.ToString.Trim = _Row.Item("KOPRAL").ToString.Trim Then
                            MessageBoxEx.Show(Me, "El código ya está en la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                            _Id = 0
                            _Row.Item("KOPRAL") = String.Empty
                            _Row.Item("NOKOPRAL") = String.Empty
                            Exit For
                        End If
                    Next

                    With _Fila

                        .Cells("Idmaeddo").Value = _Id
                        .Cells("CodigoAlt").Value = _Row.Item("KOPRAL")
                        .Cells("Descripcion").Value = _Row.Item("NOKOPRAL")
                        .Cells("Cantidad").Value = 0

                    End With

                    If CBool(_Id) Then
                        Grilla_Detalle.CurrentCell = _Fila.Cells("Cantidad")
                    End If

            End Select

        Catch ex As Exception
        Finally
            If _Cabeza <> "_Cabeza" Then
                Grilla_Detalle.Columns(_Cabeza).ReadOnly = True
            End If
        End Try

    End Sub

    Function Fx_BuscarProducto(_Codigo As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim _Row As DataRow
            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("TABCODAL", "KOPR = '" & _Codigo & "' And KOEN = '" & _Koen & "'")

            If Not CBool(_Reg) Then
                Throw New System.Exception("Este producto no tiene códigos alternativos asociados al cliente")
            End If

            Dim Fm As New Frm_CodAlternativo_Ver
            Fm.TxtCodigo.Text = _Codigo
            Fm.Txtdescripcion.Text = _Row_Producto.Item("NOKOPR")
            Fm.TxtRTU.Text = _Row_Producto.Item("RLUD")
            Fm.Koen = _Koen
            Fm.MostrarSoloDeEntidad = True
            Fm.ModoSeleccion = True
            Fm.ShowDialog(Me)
            _Row = Fm.RowTabcodalSeleccionado
            Fm.Dispose()

            If IsNothing(_Row) Then
                _Mensaje.Cancelado = True
                Throw New System.Exception("Producto no seleccionado")
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

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Cl_NVVCustomizable.Ls_Detalle.Clear()

        If String.IsNullOrEmpty(listaProductos.Item(0).CodigoAlt) Then
            MessageBoxEx.Show(Me, "No hay registros en el detalle", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Grilla_Detalle.Focus()
            Grilla_Detalle.CurrentCell = Grilla_Detalle.Rows(Grilla_Detalle.Rows.Count - 1).Cells("CodigoAlt")
            Return
        End If

        ' Agregar productos de listaProductos a Cl_NVVCustomizable.Ls_Detalle
        For Each producto In listaProductos
            Cl_NVVCustomizable.Ls_Detalle.Add(producto)
        Next

        Cl_NVVCustomizable.Ls_Detalle.RemoveAll(Function(d) d.CodigoAlt = "")

        ' Sumar las cantidades del campo "Cantidad" de la lista Cl_NVVCustomizable.Ls_Detalle
        Dim totalCantidad As Double = Cl_NVVCustomizable.Ls_Detalle.Sum(Function(d) d.Cantidad)
        Dim _CantidadDetalle As Double = _Sql.Fx_Trae_Dato("MAEDDO", "CAPRCO1", "IDMAEDDO = " & _Idmaeddo)

        If _CantidadDetalle <> totalCantidad Then

            Cl_NVVCustomizable.Ls_Detalle.Clear()

            MessageBoxEx.Show(Me, "Las cantidades del detalle del documento vs las cantidades ingresadas no coinciden", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        'Dim json As String

        'json = JsonConvert.SerializeObject(Cl_Conteo.Ls_Zw_Inv_Hoja_Detalle, Formatting.Indented)
        'File.WriteAllText("D:\JsonB4Android\Inventario\Ls_Zw_Inv_Hoja_Detalle.json", json)

        'json = JsonConvert.SerializeObject(Cl_Conteo.Zw_Inv_Hoja, Formatting.Indented)
        'File.WriteAllText("D:\JsonB4Android\Inventario\Zw_Inv_Hoja.json", json)

        Dim _Mensaje As LsValiciones.Mensajes

        _Mensaje = Cl_NVVCustomizable.Fx_Grabar_Detalle_Customizados()

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If Not _Mensaje.EsCorrecto Then
            Return
        End If

        Me.Close()

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

        If _Cabeza = "Cantidad" Then

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

            If _Cabeza = "CodigoAlt" Then
                If _Fila.Cells("CodigoAlt").Value Is Nothing Then
                    Return False
                End If
            End If

        End If

        If IsNothing(_Fila.Cells("CodigoAlt").Value) Then
            Return True
        End If

        Dim cantidad As Integer = Convert.ToInt32(_Fila.Cells("Cantidad").Value)

        Dim _CodigoAlt As String = _Fila.Cells("CodigoAlt").Value?.ToString()

        'If String.IsNullOrEmpty(_CodigoAlt) Then
        '    Return False
        'End If

        If _Cabeza = "Cantidad" And cantidad <= 0 Then
            Return False
        End If

        'If _Cabeza = "CodigoAlt" And cantidad = 0 Then
        '    Grilla_Detalle.CurrentCell = _Fila.Cells("Cantidad")
        '    Return False
        'End If

        'If cantidad <= 0 Then
        '    'MessageBoxEx.Show(Me, "La cantidad debe ser mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return False
        'End If

        ' Si todas las validaciones pasan, la fila es válida
        Return True
    End Function

    Private Sub Grilla_Detalle_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
        ' Manejar los errores de datos
        ' Por ejemplo, mostrar un mensaje de error al usuario
        'MessageBoxEx.Show(Me, "Error de datos en la celda " & e.ColumnIndex & ", " & e.RowIndex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub Grilla_Detalle_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Detalle.CellEnter
        ' Obtener la columna deseada
        Dim columnaDeseada As DataGridViewColumn = Grilla_Detalle.Columns("Cantidad")
        Dim nuevaFila As DataGridViewRow = Grilla_Detalle.Rows(e.RowIndex)

        If Not nuevaFila.IsNewRow Then

        End If

        If nuevaFila.IsNewRow Then
            ' Utilizar BeginInvoke para posponer el cambio de celda
            Me.BeginInvoke(New MethodInvoker(Sub()
                                                 Try
                                                     ' Verificar si la celda aún es accesible antes de cambiar el foco
                                                     If nuevaFila.IsNewRow AndAlso nuevaFila.Cells("CodigoAlt").RowIndex < Grilla_Detalle.Rows.Count Then
                                                         If String.IsNullOrWhiteSpace(nuevaFila.Cells("CodigoAlt").Value) Then
                                                             Grilla_Detalle.CurrentCell = nuevaFila.Cells("CodigoAlt")
                                                             Grilla_Detalle.BeginEdit(True)
                                                         End If
                                                     End If
                                                 Catch ex As Exception
                                                     ' Manejar la excepción si es necesario
                                                 End Try
                                             End Sub))
        End If

    End Sub

    Private Sub Frm_Ver_Documento_CustomizarDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
