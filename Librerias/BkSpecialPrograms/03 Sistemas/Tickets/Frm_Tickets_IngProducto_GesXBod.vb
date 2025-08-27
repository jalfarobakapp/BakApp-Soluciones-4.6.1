Imports System.ComponentModel
Imports DevComponents.DotNetBar

Public Class Frm_Tickets_IngProducto_GesXBod

    Public listaProductosOriginal As BindingList(Of Zw_Stk_Tickets_Producto)
    Public listaProductos As New BindingList(Of Zw_Stk_Tickets_Producto)

    Public Property Cl_Tickets As Cl_Tickets
    Public Property SoloUnProducto As Boolean
    Public Property ModoSoloLectura As Boolean
    Public Property Grabar As Boolean
    Public Property ConfirmaCantidades As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Detalle, 18, New Font("Tahoma", 8), Color.LightYellow, ScrollBars.None, True, False, False)
        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Tickets_IngProducto_GesXBod_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla_Detalle.EditingControlShowing, AddressOf Grilla_Detalle_EditingControlShowing
        AddHandler Grilla_Detalle.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        ' Asignar la lista de detalles a listaProductos
        'listaProductos = New BindingList(Of Zw_Stk_Tickets_Producto)(Cl_Tickets.Ls_Zw_Stk_Tickets_Producto)

        listaProductosOriginal = New BindingList(Of Zw_Stk_Tickets_Producto)(Cl_Tickets.Ls_Zw_Stk_Tickets_Producto)
        listaProductos = New BindingList(Of Zw_Stk_Tickets_Producto)(ClonarLista(listaProductosOriginal))

        Txt_Producto.Text = Cl_Tickets.Zw_Stk_Tickets_Producto.Codigo & " - " & Cl_Tickets.Zw_Stk_Tickets_Producto.Descripcion
        Txt_Producto.Enabled = True
        Txt_Producto.ReadOnly = True

        Sb_ActualizarGrilla()

        ' Establecer el foco en la primera fila de la grilla en el campo Um
        If Grilla_Detalle.Rows.Count > 0 Then
            Grilla_Detalle.CurrentCell = Grilla_Detalle.Rows(0).Cells("Ubicacion")
            Grilla_Detalle.BeginEdit(True)
        End If

        Btn_Grabar.Enabled = Not ModoSoloLectura

    End Sub

    Private Function ClonarLista(original As BindingList(Of Zw_Stk_Tickets_Producto)) As List(Of Zw_Stk_Tickets_Producto)
        Dim nuevaLista As New List(Of Zw_Stk_Tickets_Producto)
        For Each item In original
            nuevaLista.Add(New Zw_Stk_Tickets_Producto With {
                    .Id = item.Id,
                    .Id_Padre = item.Id_Padre,
                    .Id_Raiz = item.Id_Raiz,
                    .Id_Ticket = item.Id_Ticket,
                    .Id_TicketAc = item.Id_TicketAc,
                    .AjusInventario = item.AjusInventario,
                    .Empresa = item.Empresa,
                    .Sucursal = item.Sucursal,
                    .Bodega = item.Bodega,
                    .Descripcion_Bodega = item.Descripcion_Bodega,
                    .Codigo = item.Codigo,
                    .Descripcion = item.Descripcion,
                    .Ubicacion = item.Ubicacion,
                    .UdMedida = item.UdMedida,
                    .Ud1 = item.Ud1,
                    .Ud2 = item.Ud2,
                    .Um = item.Um,
                    .StfiEnBodega = item.StfiEnBodega,
                    .Cantidad = item.Cantidad,
                    .Diferencia = item.Diferencia,
                    .FechaRev = item.FechaRev,
                    .Numero = item.Numero,
                    .RevInventario = item.RevInventario,
                    .Rtu = item.Rtu,
                    .SobreStock = item.SobreStock,
                    .Stfi1 = item.Stfi1,
                    .Stfi2 = item.Stfi2,
                    .ConfCantCero = item.ConfCantCero
                })
        Next
        Return nuevaLista
    End Function

    Private currentId As Integer = 1

    Sub Sb_Agregar_Nueva_Linea()

        ' Obtener el valor del campo Id del último registro en la lista y asignarlo a currentId + 1
        If listaProductos.Count > 0 Then
            currentId = listaProductos(listaProductos.Count - 1).Id + 1
        Else
            currentId = 1
        End If

        Dim _Item1 As Zw_Stk_Tickets_Producto = listaProductos.Item(0)
        Dim _Detalle As New Zw_Stk_Tickets_Producto

        _Detalle.Id = currentId
        _Detalle.Id_Padre = _Item1.Id
        _Detalle.Id_Raiz = _Item1.Id_Raiz
        _Detalle.Codigo = _Item1.Codigo
        _Detalle.Descripcion = _Item1.Descripcion
        _Detalle.Ud1 = _Item1.Ud1
        _Detalle.Ud2 = _Item1.Ud2
        _Detalle.Um = _Item1.Um

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

            .Columns("Ubicacion").Visible = True
            .Columns("Ubicacion").HeaderText = "Ubicación"
            .Columns("Ubicacion").Width = 150
            .Columns("Ubicacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Descripcion_Bodega").Visible = True
            '.Columns("Descripcion_Bodega").HeaderText = "Nombre de bodega"
            '.Columns("Descripcion_Bodega").Width = 250
            '.Columns("Descripcion_Bodega").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Um").Visible = True
            .Columns("Um").HeaderText = "UM"
            .Columns("Um").ToolTipText = "Unidad de medida"
            .Columns("Um").Width = 30
            .Columns("Um").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").HeaderText = "Stock Físico"
            .Columns("Cantidad").Width = 100
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Cantidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StfiEnBodega").Visible = True
            .Columns("StfiEnBodega").HeaderText = "Stock Sistema"
            .Columns("StfiEnBodega").Width = 100
            .Columns("StfiEnBodega").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StfiEnBodega").DefaultCellStyle.Format = "###,##0.##"
            .Columns("StfiEnBodega").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Diferencia").Visible = True
            .Columns("Diferencia").HeaderText = "Diferencia"
            .Columns("Diferencia").Width = 100
            .Columns("Diferencia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Diferencia").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Diferencia").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaRev").Visible = True
            .Columns("FechaRev").HeaderText = "Fecha/Hora Rev."
            .Columns("FechaRev").HeaderText = "Fecha y hora de revisión"
            .Columns("FechaRev").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
            .Columns("FechaRev").Width = 120
            .Columns("FechaRev").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ConfCantCero").Visible = True
            .Columns("ConfCantCero").HeaderText = "CCC"
            .Columns("ConfCantCero").ToolTipText = "Confirmar cantidad cero"
            .Columns("ConfCantCero").Width = 30
            .Columns("ConfCantCero").DisplayIndex = _DisplayIndex
            .Columns("ConfCantCero").ReadOnly = ModoSoloLectura
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

                If ModoSoloLectura Then
                    MessageBoxEx.Show(Me, "El formulario se encuentra en modo de solo lectura", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                If _Cabeza = "Ubicacion" Or
                   _Cabeza = "StfiEnBodega" Or
                   _Cabeza = "Cantidad" Or
                   _Cabeza = "Empresa" Or
                   _Cabeza = "Sucursal" Or
                   _Cabeza = "Bodega" Or
                   _Cabeza = "Um" Or
                   _Cabeza = "FechaRev" Then

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

                        If _Id_Padre = 0 And Not SoloUnProducto Then
                            MessageBoxEx.Show(Me, "Esta línea no puede ser editada, pues es la línea de origen del producto", "Validación",
                                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return
                        End If

                        If _Cabeza = "StfiEnBodega" Or _Cabeza = "Cantidad" Then

                            If String.IsNullOrEmpty(_Fila.Cells("Ubicacion").Value) Then
                                MessageBoxEx.Show(Me, "Debe ingresar la ubicación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Grilla_Detalle.CurrentCell = _Fila.Cells("Ubicacion")
                                e.Handled = True
                                Return
                            End If

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
                            Fm_b.Pro_Empresa = Mod_Empresa
                            Fm_b.Pro_Sucursal = NuloPorNro(_Fila.Cells("Sucursal").Value, Mod_Sucursal)
                            Fm_b.Pro_Bodega = NuloPorNro(_Fila.Cells("Bodega").Value, Mod_Bodega)
                            Fm_b.RevisarPermisosBodega = False
                            Fm_b.Pedir_Permiso = False
                            Fm_b.ShowDialog(Me)

                            If Fm_b.Pro_Seleccionado Then

                                '' Verificar si ya existe la misma empresa, sucursal y bodega en la lista
                                'For Each producto As Zw_Stk_Tickets_Producto In listaProductos
                                '    If producto.Empresa = Fm_b.Pro_RowBodega.Item("EMPRESA") AndAlso
                                '        producto.Sucursal = Fm_b.Pro_RowBodega.Item("KOSU") AndAlso
                                '        producto.Bodega = Fm_b.Pro_RowBodega.Item("KOBO") AndAlso producto.Id <> currentId AndAlso producto.Id_TicketAc = 0 Then
                                '        MessageBoxEx.Show(Me, "Ya existe un registro con la misma empresa, sucursal y bodega", "Validación",
                                '                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                '        Grilla_Detalle.CurrentCell = _Fila.Cells("Bodega")
                                '        Return
                                '    End If
                                'Next

                                _Fila.Cells("Empresa").Value = Fm_b.Pro_RowBodega.Item("EMPRESA")
                                _Fila.Cells("Sucursal").Value = Fm_b.Pro_RowBodega.Item("KOSU")
                                _Fila.Cells("Bodega").Value = Fm_b.Pro_RowBodega.Item("KOBO")

                            End If

                            Fm_b.Dispose()

                            Grilla_Detalle.CurrentCell = _Fila.Cells("Ubicacion")

                        End If

                        If _Cabeza = "Um" Then

                            If CBool(_Id_Padre) Then
                                Beep()
                                Return
                            End If

                            Dim Fm As New Frm_Cantidades_Selec_Ud(_Fila.Cells("Ud1").Value, _Fila.Cells("Ud2").Value)
                            Fm.ShowDialog(Me)
                            If Fm.Seleccionada Then
                                _Fila.Cells("Um").Value = Fm.UdTrans
                                Grilla_Detalle.CurrentCell = _Fila.Cells("Cantidad") ' StfiEnBodega
                            End If
                            Fm.Dispose()

                        End If

                        If _Cabeza = "FechaRev" Then

                            Dim _Grabar As Boolean
                            Dim _FechaSeleccionada As DateTime

                            Dim Fm As New Frm_Seleccionar_Fecha

                            Fm.SolicitarConfirmacionDeFecha = True
                            Fm.ExigeFechaMaxima = True
                            Fm.FechaMaxima = Now.Date.AddDays(1)

                            If IsNothing(_Fila.Cells("FechaRev").Value) Then
                                Fm.FechaDisplay = Now.Date
                            Else
                                Fm.FechaDisplay = _Fila.Cells("FechaRev").Value
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
                                _Fila.Cells("FechaRev").Value = _FechaSeleccionada
                            End If

                        End If

                        If _Cabeza = "Ubicacion" Then

                            'SendKeys.Send("{F2}")
                            'e.Handled = True
                            'Grilla_Detalle.Columns(_Cabeza).ReadOnly = False
                            'Grilla_Detalle.BeginEdit(True)

                            'Dim _SqlFiltro_Fechas As String

                            '_SqlFiltro_Fechas = "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Desde.Value, "yyyyMMdd") & "' AND '" &
                            '                     Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd") & "'" & vbCrLf

                            If String.IsNullOrEmpty(_Sucursal) Or String.IsNullOrEmpty(_Sucursal) Then
                                MessageBoxEx.Show(Me, "Falta la bodega", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Return
                            End If

                            Dim _Sql_Filtro_Condicion_Extra = "And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "'"

                            Dim _Filtrar As New Clas_Filtros_Random(Me)

                            _Filtrar.Tabla = _Global_BaseBk & "Zw_Bodega_Ubic"
                            _Filtrar.Campo = "Ubicacion"
                            _Filtrar.Descripcion = "Ubicacion"

                            If _Filtrar.Fx_Filtrar(Nothing,
                                                   Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _Sql_Filtro_Condicion_Extra, Nothing, False, True) Then

                                Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

                                If SoloUnProducto Then

                                    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
                                    Dim Consulta_sql As String

                                    Consulta_sql = "Select Top 1 Prod.Codigo,Prod.Descripcion,Prod.Numero,Prod.Ubicacion,Tks.CodFuncionario_Crea,NOKOFU" & vbCrLf &
                                               "From " & _Global_BaseBk & "Zw_Stk_Tickets_Producto Prod" & vbCrLf &
                                               "Inner Join " & _Global_BaseBk & "Zw_Stk_Tickets Tks On Tks.Id_Raiz = Prod.Id_Raiz" & vbCrLf &
                                               "Inner Join TABFU On KOFU = Tks.CodFuncionario_Crea" & vbCrLf &
                                               "Where 1>0 --Id_Tipo = " & Cl_Tickets.Zw_Stk_Tipos.Id & vbCrLf &
                                               " And Prod.Empresa = '" & _Empresa & "' And Prod.Sucursal = '" & _Sucursal & "'" &
                                               " And Prod.Bodega = '" & _Bodega & "' And Prod.Codigo = '" & Cl_Tickets.Zw_Stk_Tickets_Producto.Codigo & "'" &
                                               " And Prod.Ubicacion = '" & _Row.Item("Codigo") & "' And Estado In ('ABIE','PROC')"

                                    Dim _Row2 As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                                    If Not IsNothing(_Row2) Then

                                        Dim _Msj = "Ya hay un ticket abierto por esta misma solución. " & "Ticket " & _Row2.Item("Numero") & vbCrLf & vbCrLf &
                                               "De: " & _Row2.Item("CodFuncionario_Crea") & "-" & _Row2.Item("NOKOFU").ToString.Trim() & vbCrLf &
                                               "Producto: " & Cl_Tickets.Zw_Stk_Tickets_Producto.Codigo.Trim & " - " & _Row2.Item("Descripcion") & vbCrLf &
                                               "Ubicación: " & _Row2.Item("Ubicacion") & vbCrLf & vbCrLf &
                                               "No es posible crear 2 Ticket iguales para la misma bodega, ubicación y producto."

                                        MessageBoxEx.Show(Me, _Msj, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                        _Fila.Cells("Ubicacion").Value = String.Empty
                                        Return

                                    End If

                                Else

                                    ' Verificar si ya existe la misma empresa, sucursal y bodega en la lista
                                    For Each producto As Zw_Stk_Tickets_Producto In listaProductos
                                        If producto.Empresa = _Empresa AndAlso
                                            producto.Sucursal = _Sucursal AndAlso
                                            producto.Bodega = _Bodega AndAlso producto.Ubicacion = _Row.Item("Codigo") AndAlso producto.Id <> currentId AndAlso producto.Id_TicketAc = 0 Then
                                            MessageBoxEx.Show(Me, "Ya existe un registro con la misma empresa (" & _Empresa & "), sucursal (" & _Sucursal & "), bodega (" & _Bodega & ") y ubicación (" & _Row.Item("Codigo") & ")", "Validación",
                                                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                            _Fila.Cells("Ubicacion").Value = String.Empty
                                            Grilla_Detalle.CurrentCell = _Fila.Cells("Ubicacion")
                                            Return
                                        End If
                                    Next

                                End If

                                _Fila.Cells("Ubicacion").Value = _Row.Item("Codigo")
                                Grilla_Detalle.CurrentCell = _Fila.Cells("Um")

                            End If

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
                        'If _Index >= 0 AndAlso _Index < Grilla_Detalle.Rows.Count AndAlso _Id_Padre = 1 Then

                        If MessageBoxEx.Show(Me, "¿Está seguro de eliminar la fila seleccionada?", "Eliminar Fila",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                            Return
                        End If

                        Grilla_Detalle.Rows.RemoveAt(_Index)

                        'End If
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

                    If ModoSoloLectura Then
                        MessageBoxEx.Show(Me, "El formulario se encuentra en modo de solo lectura", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If

                    If SoloUnProducto Then
                        Return
                    End If

                    If Not String.IsNullOrEmpty(_Bodega) Then
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

                Case "Cantidad", "StfiEnBodega"

                    Dim _Cantidad As Double = _Fila.Cells("Cantidad").Value
                    Dim _StfiEnBodega As Double = _Fila.Cells("StfiEnBodega").Value
                    Dim _Diferencia As Double = _Cantidad - _StfiEnBodega

                    _Fila.Cells("Diferencia").Value = _Diferencia

                    If _Cabeza = "Cantidad" Then
                        Grilla_Detalle.CurrentCell = _Fila.Cells("StfiEnBodega")
                    Else
                        Grilla_Detalle.CurrentCell = _Fila.Cells("FechaRev")
                    End If

                    If CBool(_Cantidad + _StfiEnBodega) Then
                        _Fila.Cells("ConfCantCero").Value = False
                    End If

                Case "Ubicacion"

                    If Not String.IsNullOrWhiteSpace(_Fila.Cells("Ubicacion").Value) Then
                        Grilla_Detalle.CurrentCell = _Fila.Cells("Um")
                    End If

            End Select

        Catch ex As Exception
        Finally
            If _Cabeza <> "_Cabeza" And _Cabeza <> "ConfCantCero" Then
                Grilla_Detalle.Columns(_Cabeza).ReadOnly = True
            End If
        End Try

    End Sub

    Private Sub Sb_Validar_Keypress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        ' obtener indice de la columna

        'With sender

        Dim _Columna As Integer = Grilla_Detalle.CurrentCellAddress.X 'Current.ColumnIndex
        Dim _Fila As Integer = Grilla_Detalle.CurrentCellAddress.Y 'Current.ColumnIndex

        Dim _Cabeza = Grilla_Detalle.Columns(_Columna).Name

        ' comprobar si la celda en edición corresponde a la columna 1 o 2

        If _Cabeza = "Cantidad" Or _Cabeza = "StfiEnBodega" Then

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

    Private Sub Grilla_Detalle_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
        Dim validar As TextBox = CType(e.Control, TextBox)
        AddHandler validar.KeyPress, AddressOf Sb_Validar_Keypress
    End Sub

    Private Sub Grilla_Detalle_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
        ' Manejar los errores de datos
        ' Por ejemplo, mostrar un mensaje de error al usuario
        'MessageBoxEx.Show(Me, "Error de datos en la celda " & e.ColumnIndex & ", " & e.RowIndex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _ContFila = 1

        ' Validar que el campo Ubicacion no esté vacío en la lista de productos
        For Each producto As Zw_Stk_Tickets_Producto In listaProductos

            If String.IsNullOrWhiteSpace(producto.Bodega) Then
                MessageBoxEx.Show(Me, "Todos los productos deben tener una bodega." & vbCrLf & "Fila: " & _ContFila,
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            If String.IsNullOrWhiteSpace(producto.Ubicacion) Then
                MessageBoxEx.Show(Me, "Todos los productos deben tener una ubicación." & vbCrLf & "Fila: " & _ContFila,
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            If String.IsNullOrWhiteSpace(producto.Um) Then
                MessageBoxEx.Show(Me, "Todos los productos deben tener una unidad de medida (UM)." & vbCrLf & "Fila: " & _ContFila,
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            If producto.Id_Ticket = 0 AndAlso producto.Cantidad = 0 AndAlso producto.StfiEnBodega = 0 AndAlso Not producto.ConfCantCero Then

                MessageBoxEx.Show(Me, "El Stock Físico y el Stock del Sistema no pueden ser ambos iguales a cero, a menos que se" & vbCrLf &
                                  "confirme explícitamente la cantidad en cero en el campo CCC." & vbCrLf & "Fila: " & _ContFila,
                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return

                'ElseIf producto.Id_Ticket = 0 AndAlso producto.Cantidad = 0 AndAlso producto.StfiEnBodega = 0 Then

                '    MessageBoxEx.Show(Me, "El Stock Físico y Stock Sistema no pueden ser igual a cero" & vbCrLf & "Fila: " & _ContFila,
                '          "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '    Return

            End If

            If IsNothing(producto.FechaRev) Then
                MessageBoxEx.Show(Me, "Todos los productos deben tener una fecha y hora de revisión (Fecha/Hora Rev.)." & vbCrLf & "Fila: " & _ContFila,
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            _ContFila += 1

        Next


        If Not ModoSoloLectura AndAlso SoloUnProducto Then

            Dim _Msg1 = "CONFIRMAR CANTIDADES"
            Dim _Msg2 = vbCrLf &
                        "Stock sistema: " & listaProductos.Item(0).StfiEnBodega & vbCrLf &
                        "Stock físico: " & listaProductos.Item(0).Cantidad & vbCrLf &
                        "Diferencia: " & listaProductos.Item(0).Diferencia & vbCrLf

            If Not Fx_Confirmar_Lectura(_Msg1, _Msg2, eTaskDialogIcon.Exclamation) Then
                Return
            End If

            ConfirmaCantidades = True

        End If

        listaProductosOriginal = New BindingList(Of Zw_Stk_Tickets_Producto)(ClonarLista(listaProductos))

        ' Eliminar los productos que no están en listaProductos
        Dim productosAEliminar = Cl_Tickets.Ls_Zw_Stk_Tickets_Producto.Where(Function(p) Not listaProductosOriginal.Any(Function(lp) lp.Id = p.Id)).ToList()
        For Each productoAEliminar In productosAEliminar
            Cl_Tickets.Ls_Zw_Stk_Tickets_Producto.Remove(productoAEliminar)
        Next

        For Each productoOriginal In listaProductosOriginal
            Dim productoExistente = Cl_Tickets.Ls_Zw_Stk_Tickets_Producto.FirstOrDefault(Function(p) p.Id = productoOriginal.Id)
            If productoExistente IsNot Nothing Then
                productoExistente.Id_Padre = productoOriginal.Id_Padre
                productoExistente.Id_Raiz = productoOriginal.Id_Raiz
                productoExistente.Id_Ticket = productoOriginal.Id_Ticket
                productoExistente.Id_TicketAc = productoOriginal.Id_TicketAc
                productoExistente.AjusInventario = productoOriginal.AjusInventario
                productoExistente.Empresa = productoOriginal.Empresa
                productoExistente.Sucursal = productoOriginal.Sucursal
                productoExistente.Bodega = productoOriginal.Bodega
                productoExistente.Descripcion_Bodega = productoOriginal.Descripcion_Bodega
                productoExistente.Codigo = productoOriginal.Codigo
                productoExistente.Descripcion = productoOriginal.Descripcion
                productoExistente.Ubicacion = productoOriginal.Ubicacion
                productoExistente.UdMedida = productoOriginal.UdMedida
                productoExistente.Ud1 = productoOriginal.Ud1
                productoExistente.Ud2 = productoOriginal.Ud2
                productoExistente.Um = productoOriginal.Um
                productoExistente.StfiEnBodega = productoOriginal.StfiEnBodega
                productoExistente.Cantidad = productoOriginal.Cantidad
                productoExistente.Diferencia = productoOriginal.Diferencia
                productoExistente.FechaRev = productoOriginal.FechaRev
                productoExistente.Numero = productoOriginal.Numero
                productoExistente.RevInventario = productoOriginal.RevInventario
                productoExistente.Rtu = productoOriginal.Rtu
                productoExistente.SobreStock = productoOriginal.SobreStock
                productoExistente.Stfi1 = productoOriginal.Stfi1
                productoExistente.Stfi2 = productoOriginal.Stfi2
                productoExistente.ConfCantCero = productoOriginal.ConfCantCero
            Else
                Cl_Tickets.Ls_Zw_Stk_Tickets_Producto.Add(productoOriginal)
            End If
        Next

        Grabar = True
        Me.Close()

    End Sub

    Private Sub Grilla_Detalle_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles Grilla_Detalle.CellBeginEdit

        Dim _Fila As DataGridViewRow = Grilla_Detalle.CurrentRow
        Dim _Cabeza = Grilla_Detalle.Columns(e.ColumnIndex).Name

        If CBool(_Fila.Cells("Id_Ticket").Value) Then
            Beep()
            e.Cancel = True
        End If

        If _Cabeza = "ConfCantCero" Then
            If _Fila.Cells("Cantidad").Value <> 0 Or
            _Fila.Cells("StfiEnBodega").Value <> 0 Or
            String.IsNullOrWhiteSpace(_Fila.Cells("Sucursal").Value) Or
            String.IsNullOrWhiteSpace(_Fila.Cells("Bodega").Value) Or
            String.IsNullOrWhiteSpace(_Fila.Cells("Ubicacion").Value) Then
                Beep()
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub Grilla_Detalle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Detalle.CellDoubleClick
        ' Simular la presión de la tecla Enter
        Dim args As New KeyEventArgs(Keys.Enter)
        Grilla_Detalle_KeyDown(sender, args)
    End Sub

    Private Sub Grilla_Detalle_MouseUp(sender As Object, e As MouseEventArgs) Handles Grilla_Detalle.MouseUp
        Grilla_Detalle.EndEdit()
    End Sub
End Class
