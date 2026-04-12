
Imports System.ComponentModel
Imports DevComponents.DotNetBar

Public Class Frm_Lotes_Det

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Ls_Lotes As List(Of Zw_Docu_Det_Lote)

    Public Lista_Lotes_Original As BindingList(Of Zw_Docu_Det_Lote)
    Public Lista_Lotes As New BindingList(Of Zw_Docu_Det_Lote)

    Public Property ModoSoloLectura As Boolean = False

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.LightYellow, ScrollBars.None, True, False, False)
        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Lotes_Det_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' 1. Inicializar lista de entrada si es Nothing
        If IsNothing(Ls_Lotes) Then
            Ls_Lotes = New List(Of Zw_Docu_Det_Lote)
        End If

        ' 2. Crear listas binding
        Lista_Lotes_Original = New BindingList(Of Zw_Docu_Det_Lote)(Ls_Lotes)
        Lista_Lotes = New BindingList(Of Zw_Docu_Det_Lote)(ClonarLista(Lista_Lotes_Original))

        ' 3. Si no hay elementos, agregar una línea base para permitir edición/agregado
        If Lista_Lotes.Count = 0 Then
            Dim lineaBase As New Zw_Docu_Det_Lote With {
                .Id = 1,
                .Id_Det = 1,
                .Idmaeddo = 0,
                .Idmaeedo = 0,
                .Tido = String.Empty,
                .Nudo = String.Empty,
                .Codigo = String.Empty,
                .Descripcion = String.Empty,
                .NroLote = String.Empty,
                .SubLote = String.Empty,
                .FElaboracion = Nothing,
                .FVencimiento = Nothing,
                .CantUd1 = 0,
                .CantUd2 = 0
            }

            Lista_Lotes.Add(lineaBase)
        End If

        Sb_ActualizarGrilla()

    End Sub

    Private Function ClonarLista(original As BindingList(Of Zw_Docu_Det_Lote)) As List(Of Zw_Docu_Det_Lote)
        Dim nuevaLista As New List(Of Zw_Docu_Det_Lote)
        For Each item In original
            nuevaLista.Add(New Zw_Docu_Det_Lote With {
                    .Id = item.Id,
                    .Id_Det = item.Id_Det,
                    .Idmaeddo = item.Idmaeddo,
                    .Idmaeedo = item.Idmaeedo,
                    .Tido = item.Tido,
                    .Nudo = item.Nudo,
                    .Codigo = item.Codigo,
                    .Descripcion = item.Descripcion,
                    .NroLote = item.NroLote,
                    .SubLote = item.SubLote,
                    .FElaboracion = item.FElaboracion,
                    .FVencimiento = item.FVencimiento,
                    .CantUd1 = item.CantUd1,
                    .CantUd2 = item.CantUd2
                })
        Next
        Return nuevaLista
    End Function

    Sub Sb_ActualizarGrilla()

        ' Desvincular el DataGridView
        Grilla.DataSource = Nothing

        Dim bindingSource As New BindingSource()
        bindingSource.DataSource = Lista_Lotes
        Grilla.DataSource = bindingSource
        With Grilla

            OcultarEncabezadoGrilla(Grilla, True)
            Dim _DisplayIndex = 0

            .Columns("Codigo").Visible = True
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Width = 100
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantUd1").Visible = True
            .Columns("CantUd1").HeaderText = "Cantidad"
            .Columns("CantUd1").Width = 100
            .Columns("CantUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantUd1").DefaultCellStyle.Format = "###,##0.##"
            .Columns("CantUd1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NroLote").Visible = True
            .Columns("NroLote").HeaderText = "Nro. Lote"
            .Columns("NroLote").Width = 100
            .Columns("NroLote").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SubLote").Visible = True
            .Columns("SubLote").HeaderText = "SubLote"
            .Columns("SubLote").Width = 100
            .Columns("SubLote").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FElaboracion").Visible = True
            .Columns("FElaboracion").HeaderText = "F.Elaboración"
            .Columns("FElaboracion").HeaderText = "Fecha y hora de elaboración"
            .Columns("FElaboracion").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FElaboracion").Width = 120
            .Columns("FElaboracion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FVencimiento").Visible = True
            .Columns("FVencimiento").HeaderText = "F.Vencimiento"
            .Columns("FVencimiento").HeaderText = "Fecha y hora de vencimiento"
            .Columns("FVencimiento").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FVencimiento").Width = 120
            .Columns("FVencimiento").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private currentId As Integer = 1
    Sub Sb_Agregar_Nueva_Linea()

        ' Obtener el valor del campo Id del último registro en la lista y asignarlo a currentId + 1
        If Lista_Lotes.Count > 0 Then
            currentId = Lista_Lotes(Lista_Lotes.Count - 1).Id + 1
        Else
            currentId = 1
        End If

        Dim _Item1 As Zw_Docu_Det_Lote = Lista_Lotes.Item(0)
        Dim _Detalle As New Zw_Docu_Det_Lote

        _Detalle.Id = _Item1.Id
        _Detalle.Id_Det = currentId
        _Detalle.Idmaeddo = _Item1.Idmaeddo
        _Detalle.Idmaeedo = _Item1.Idmaeedo
        _Detalle.Tido = _Item1.Tido
        _Detalle.Nudo = _Item1.Nudo
        _Detalle.Codigo = _Item1.Codigo
        _Detalle.Descripcion = _Item1.Descripcion
        _Detalle.NroLote = String.Empty
        _Detalle.SubLote = String.Empty
        _Detalle.FElaboracion = Nothing
        _Detalle.FVencimiento = Nothing
        _Detalle.CantUd1 = 0
        _Detalle.CantUd2 = 0

        Lista_Lotes.Add(_Detalle)
        Grilla.Refresh()

        Try
            Grilla.CurrentCell = Grilla.Rows(Grilla.RowCount - 1).Cells("CantUd1")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown

        If IsNothing(Grilla.CurrentCell) Then
            Return
        End If

        If Not Btn_Grabar.Enabled Then
            Return
        End If

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Id_Det As Integer = _Fila.Cells("Id_Det").Value
        Dim _NroLote As String = _Fila.Cells("NroLote").Value
        Dim _SubLote As String = _Fila.Cells("SubLote").Value
        Dim _FElaboracion As Date = _Fila.Cells("FElaboracion").Value
        Dim _FVencimiento As Date = _Fila.Cells("FVencimiento").Value
        Dim _CantUd1 As Double = _Fila.Cells("CantUd1").Value

        Dim _Index As Integer = _Fila.Index

        Select Case e.KeyValue

            Case Keys.Enter

                If ModoSoloLectura Then
                    MessageBoxEx.Show(Me, "El formulario se encuentra en modo de solo lectura", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                If _Cabeza = "CantUd1" Or
                   _Cabeza = "NroLote" Or
                   _Cabeza = "SubLote" Or
                   _Cabeza = "FElaboracion" Or
                   _Cabeza = "FVencimiento" Then

                    If _Fila.IsNewRow Then

                        If _Cabeza = "NroLote" Or _Cabeza = "FElaboracion" Or _Cabeza = "FVencimiento" Then

                            If String.IsNullOrEmpty(_NroLote) Then
                                MessageBoxEx.Show(Me, "Debe ingresar el número de Lote", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Grilla.CurrentCell = _Fila.Cells("NroLote")
                                Return
                            End If

                        End If

                        SendKeys.Send("{F2}")
                        e.Handled = True
                        Grilla.Columns(_Cabeza).ReadOnly = False
                        Grilla.BeginEdit(True)

                    End If

                    If Not _Fila.IsNewRow Then

                        'If _Id_Padre = 0 And Not SoloUnProducto Then
                        '    MessageBoxEx.Show(Me, "Esta línea no puede ser editada, pues es la línea de origen del producto", "Validación",
                        '                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        '    Return
                        'End If

                        If _Cabeza = "CantUd1" Then

                            'If String.IsNullOrEmpty(_Fila.Cells("Ubicacion").Value) Then
                            '    MessageBoxEx.Show(Me, "Debe ingresar la ubicación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            '    Grilla.CurrentCell = _Fila.Cells("Ubicacion")
                            '    e.Handled = True
                            '    Return
                            'End If

                            'If String.IsNullOrEmpty(_Empresa) Or String.IsNullOrEmpty(_Sucursal) Or String.IsNullOrEmpty(_Bodega) Then
                            '    MessageBoxEx.Show(Me, "Debe ingresar la bodega", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            '    Grilla.CurrentCell = _Fila.Cells("NroLote")
                            '    e.Handled = True
                            '    Return
                            'End If

                            'If String.IsNullOrEmpty(_Fila.Cells("Um").Value) Then
                            '    MessageBoxEx.Show(Me, "Debe ingresar la unidad de medida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            '    Grilla.CurrentCell = _Fila.Cells("Um")
                            '    e.Handled = True
                            '    Return
                            'End If

                            SendKeys.Send("{F2}")
                            e.Handled = True
                            Grilla.Columns(_Cabeza).ReadOnly = False
                            Grilla.BeginEdit(True)

                        End If

                        If _Cabeza = "FElaboracion" Then

                            Dim _Grabar As Boolean
                            Dim _FechaSeleccionada As DateTime

                            Dim Fm As New Frm_Seleccionar_Fecha

                            Fm.SolicitarConfirmacionDeFecha = True
                            Fm.ExigeFechaMaxima = True
                            Fm.FechaMaxima = Now.Date.AddDays(1)

                            If IsNothing(_Fila.Cells(_Cabeza).Value) Then
                                Fm.FechaDisplay = Now.Date
                            Else
                                Fm.FechaDisplay = _Fila.Cells(_Cabeza).Value
                            End If
                            Fm.Dtp_Fecha.Value = Now.Date
                            Fm.Dtp_Hora.Value = Now
                            Fm.MostraFormularioAlCentro = True
                            Fm.SeleccionarHora = True
                            Fm.ShowDialog(Me)

                            _Grabar = Fm.Grabar
                            _FechaSeleccionada = Fm.FechaSeleccionada
                            Fm.Dispose()

                            If _Grabar Then
                                _Fila.Cells(_Cabeza).Value = _FechaSeleccionada
                            End If

                        End If

                    End If

                End If

            Case Keys.Delete

                Try
                    If Not _Fila.IsNewRow Then

                        If _Id_Det = 0 Then
                            MessageBoxEx.Show(Me, "Esta línea no puede ser eliminada, pues es la línea de origen del producto", "Validación",
                                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return
                        End If

                        ' Asegúrate de que el índice sea válido antes de intentar eliminar
                        'If _Index >= 0 AndAlso _Index < Grilla.Rows.Count AndAlso _Id_Padre = 1 Then

                        If MessageBoxEx.Show(Me, "¿Está seguro de eliminar la fila seleccionada?", "Eliminar Fila",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                            Return
                        End If

                        Grilla.Rows.RemoveAt(_Index)

                        'End If
                    End If

                    If Grilla.Rows.Count = 0 Then
                        Sb_Agregar_Nueva_Linea()
                    End If

                Catch ex As Exception
                    MessageBoxEx.Show(Me, "Error al eliminar la fila: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            Case Keys.Down

                ' Verificar si la fila actual es la última fila visible
                If Grilla.CurrentRow.Index = Grilla.Rows.Count - 1 Then

                    If ModoSoloLectura Then
                        MessageBoxEx.Show(Me, "El formulario se encuentra en modo de solo lectura", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If

                    'If SoloUnProducto Then
                    '    Return
                    'End If

                    'If Not String.IsNullOrEmpty(_Bodega) Then
                    Sb_Agregar_Nueva_Linea()
                    'End If

                End If

        End Select

        Grilla.Refresh()

    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click

        'Public Property Ls_Lotes As List(Of Zw_Docu_Det_Lote)

        'Public Lista_Lotes_Original As BindingList(Of Zw_Docu_Det_Lote)
        'Public Lista_Lotes As New BindingList(Of Zw_Docu_Det_Lote)

        ' Lista que contendrá los registros nuevos o modificados (comparando con Lista_Lotes_Original)
        Dim ListaLotesDiferentes As New List(Of Zw_Docu_Det_Lote)

        ' Si la lista original es Nothing, consideramos todos los elementos como diferentes (nuevos)
        If IsNothing(Lista_Lotes) Then
            Lista_Lotes = New BindingList(Of Zw_Docu_Det_Lote)
        End If

        If IsNothing(Lista_Lotes_Original) Then
            Lista_Lotes_Original = New BindingList(Of Zw_Docu_Det_Lote)
        End If

        ' Recorrer la lista actual y detectar nuevos o distintos
        For Each itemActual As Zw_Docu_Det_Lote In Lista_Lotes

            ' Buscar por Id en la lista original
            Dim encontrado As Zw_Docu_Det_Lote = Lista_Lotes_Original.FirstOrDefault(Function(x) x.Id = itemActual.Id)

            If IsNothing(encontrado) Then
                ' No existe en la original -> nuevo registro
                ListaLotesDiferentes.Add(itemActual)
            Else
                ' Existe -> comparar todos los campos relevantes
                If Not LotesSonIguales(encontrado, itemActual) Then
                    ListaLotesDiferentes.Add(itemActual)
                End If
            End If

        Next

        ' Crear una copia/clon de la lista actual (nueva lista con los registros que hay en Lista_Lotes)
        Dim NuevaListaLotes As List(Of Zw_Docu_Det_Lote) = ClonarLista(Lista_Lotes)

        ' Asignar la copia a la propiedad de salida si se desea sobrescribir Ls_Lotes
        Ls_Lotes = NuevaListaLotes

        ' Ejemplo mínimo de uso: si necesita procesar la lista de diferentes:
        ' Aquí sólo se cuenta y no se muestra UI adicional (puede quitar o adaptar según necesidades).
        If ListaLotesDiferentes.Count > 0 Then
            MessageBoxEx.Show(Me, String.Format("Se encontraron {0} registros nuevos o modificados.", ListaLotesDiferentes.Count),
                              "Diferencias detectadas", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBoxEx.Show(Me, "No se detectaron cambios entre la lista actual y la original.", "Sin cambios",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        ' Si desea cerrar el formulario tras aceptar:
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    ' Compara dos registros lote campo a campo manejando valores Nothing para fechas
    Private Function LotesSonIguales(a As Zw_Docu_Det_Lote, b As Zw_Docu_Det_Lote) As Boolean

        If a Is Nothing AndAlso b Is Nothing Then Return True
        If a Is Nothing OrElse b Is Nothing Then Return False

        If a.Id <> b.Id Then Return False
        If a.Id_Det <> b.Id_Det Then Return False
        If a.Idmaeddo <> b.Idmaeddo Then Return False
        If a.Idmaeedo <> b.Idmaeedo Then Return False
        If Not String.Equals(a.Tido, b.Tido, StringComparison.Ordinal) Then Return False
        If Not String.Equals(a.Nudo, b.Nudo, StringComparison.Ordinal) Then Return False
        If Not String.Equals(a.Codigo, b.Codigo, StringComparison.Ordinal) Then Return False
        If Not String.Equals(a.Descripcion, b.Descripcion, StringComparison.Ordinal) Then Return False
        If Not String.Equals(a.NroLote, b.NroLote, StringComparison.Ordinal) Then Return False
        If Not String.Equals(a.SubLote, b.SubLote, StringComparison.Ordinal) Then Return False

        ' Comparar fechas considerando Nothing
        Dim aFElab = a.FElaboracion
        Dim bFElab = b.FElaboracion
        If aFElab Is Nothing AndAlso Not (bFElab Is Nothing) Then Return False
        If Not (aFElab Is Nothing) AndAlso bFElab Is Nothing Then Return False
        If Not (aFElab Is Nothing) AndAlso Not (bFElab Is Nothing) Then
            If Not aFElab.Equals(bFElab) Then Return False
        End If

        Dim aFVenc = a.FVencimiento
        Dim bFVenc = b.FVencimiento
        If aFVenc Is Nothing AndAlso Not (bFVenc Is Nothing) Then Return False
        If Not (aFVenc Is Nothing) AndAlso bFVenc Is Nothing Then Return False
        If Not (aFVenc Is Nothing) AndAlso Not (bFVenc Is Nothing) Then
            If Not aFVenc.Equals(bFVenc) Then Return False
        End If

        ' Comparar cantidades
        If a.CantUd1 <> b.CantUd1 Then Return False
        If a.CantUd2 <> b.CantUd2 Then Return False

        Return True

    End Function

    'Private Sub Dgv_Lotes_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
    '    ' Evitar excepciones no controladas al pegar/editar; marcar la celda con error
    '    If e.Exception IsNot Nothing Then
    '        Dim row = If(e.RowIndex >= 0 AndAlso e.RowIndex < Dgv_Lotes.Rows.Count, Dgv_Lotes.Rows(e.RowIndex), Nothing)
    '        If row IsNot Nothing Then
    '            row.ErrorText = "Valor inválido"
    '        End If
    '    End If

    '    e.ThrowException = False
    'End Sub

End Class
