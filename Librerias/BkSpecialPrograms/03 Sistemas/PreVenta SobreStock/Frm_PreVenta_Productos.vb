Imports BkSpecialPrograms.PreVenta
Imports DevComponents.DotNetBar

Public Class Frm_PreVenta_Productos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Empresa As String
    Private _IdCont As Integer
    Private _Contenedor As String

    Public Property Cl_Contenedor As New Cl_Contenedor
    Public Property ModoSeleccion As Boolean
    Public Property ModoPreVenta As Boolean
    Public Property Seleccionado As Boolean
    Public Property RowProducto As DataRow
    Public Property _Zw_PreVenta_StockProd As New Zw_PreVenta_StockProd

    Public Sub New(_Empresa As String, _IdCont As Integer, _Contenedor As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me._Empresa = _Empresa
        Me._IdCont = _IdCont
        Me._Contenedor = _Contenedor

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Contenedores, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Color_Botones_Barra(Bar1)

        Cl_Contenedor.Zw_Contenedor = Cl_Contenedor.Fx_Llenar_Contenedor(_IdCont)

    End Sub

    Private Sub Frm_ProdContenedorPreVta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "CONTENEDOR: " & Cl_Contenedor.Zw_Contenedor.Contenedor & " - " & Cl_Contenedor.Zw_Contenedor.NombreContenedor

        AddHandler Grilla_Contenedores.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Contenedores.KeyDown, AddressOf Sb_Grilla_KeyDown

        Sb_Actualizar_Grilla()

        Txt_Moneda.Text = Cl_Contenedor.Zw_Contenedor.MonedaVenta
        Txt_Moneda.Enabled = Not ModoSeleccion
        Dtp_FechaLibVenta.Enabled = Not ModoSeleccion
        Dtp_FechaLibVenta.Value = Cl_Contenedor.Zw_Contenedor.FechaLibVenta
        Btn_Grabar.Visible = ModoPreVenta
        Btn_Salir.Visible = ModoSeleccion

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String = String.Empty

        'If Chk_Abierto.Checked Then
        '    _Condicion = " And Estado = 'Abierto'"
        'End If

        Consulta_sql = "Select *,StcfiDisponibleUd1-StcCompUd1 As StDispUd1," &
                       "PqteHabilitado-PqteComprometido As 'PqteDisponible',Cast(0 As Float) As Cantidad" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_PreVenta_StockProd p" & vbCrLf &
                       "Inner Join MAEPR m On m.KOPR = p.Codigo" & vbCrLf &
                       "Where Empresa = '" & _Empresa & "' And IdCont = " & _IdCont & " And Contenedor = '" & _Contenedor & "'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _DisplayIndex = 0

        With Grilla_Contenedores

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla_Contenedores, True)

            '.Columns("Id").Width = 40
            '.Columns("Id").HeaderText = "ID"
            '.Columns("Id").Visible = True
            '.Columns("Id").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Empresa").Width = 30
            '.Columns("Empresa").HeaderText = "Emp"
            '.Columns("Empresa").Visible = True
            '.Columns("Empresa").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOPR").Width = 310
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            If Not ModoSeleccion Then

                .Columns("StcfiUd1").Width = 70
                .Columns("StcfiUd1").HeaderText = "Disponible Ud1"
                .Columns("StcfiUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("StcfiUd1").DefaultCellStyle.Format = "##,###0.##"
                .Columns("StcfiUd1").Visible = True
                .Columns("StcfiUd1").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

            End If

            .Columns("FormatoPqte").Width = 80
            .Columns("FormatoPqte").HeaderText = "Form.Vnta"
            .Columns("FormatoPqte").Visible = True
            .Columns("FormatoPqte").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Ud1XPqte").Width = 60
            .Columns("Ud1XPqte").HeaderText = "Ud1XPallet"
            .Columns("Ud1XPqte").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Ud1XPqte").DefaultCellStyle.Format = "##,###0.##"
            .Columns("Ud1XPqte").Visible = True
            .Columns("Ud1XPqte").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantMinFormato").Width = 70
            .Columns("CantMinFormato").HeaderText = "Cant.Min.Vta XForm."
            .Columns("CantMinFormato").ToolTipText = "Cantidad Minima de venta por Pallet."
            .Columns("CantMinFormato").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantMinFormato").DefaultCellStyle.Format = "##,###0.##"
            .Columns("CantMinFormato").Visible = True
            .Columns("CantMinFormato").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PqteHabilitado").Width = 70
            .Columns("PqteHabilitado").HeaderText = "Habilitado"
            .Columns("PqteHabilitado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PqteHabilitado").DefaultCellStyle.Format = "##,###0.##"
            .Columns("PqteHabilitado").Visible = True
            .Columns("PqteHabilitado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PqteComprometido").Width = 70
            .Columns("PqteComprometido").HeaderText = "Comprometido"
            .Columns("PqteComprometido").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PqteComprometido").DefaultCellStyle.Format = "##,###0.##"
            .Columns("PqteComprometido").Visible = True
            .Columns("PqteComprometido").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PqteDisponible").Width = 70
            .Columns("PqteDisponible").HeaderText = "Disponible"
            .Columns("PqteDisponible").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PqteDisponible").DefaultCellStyle.Format = "##,###0.##"
            .Columns("PqteDisponible").Visible = True
            .Columns("PqteDisponible").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Moneda").Width = 30
            .Columns("Moneda").HeaderText = "M."
            .Columns("Moneda").Visible = True
            .Columns("Moneda").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PrecioXUd1").Width = 70
            .Columns("PrecioXUd1").HeaderText = "Precio"
            .Columns("PrecioXUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PrecioXUd1").DefaultCellStyle.Format = "##,###0.##"
            .Columns("PrecioXUd1").Visible = True
            .Columns("PrecioXUd1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Grilla_Contenedores_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Contenedores.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Contenedores.CurrentRow
        Dim _Codigo As String = _Fila.Cells("Codigo").Value

        Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
        RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

        _Zw_PreVenta_StockProd = New Zw_PreVenta_StockProd

        With _Zw_PreVenta_StockProd

            .Id = _Fila.Cells("Id").Value
            .IdCont = _IdCont
            .Empresa = Cl_Contenedor.Zw_Contenedor.Empresa
            .Sucursal = String.Empty
            .Bodega = String.Empty
            .Codigo = _Fila.Cells("Codigo").Value
            .Descripcion = _Fila.Cells("NOKOPR").Value
            .Contenedor = _Fila.Cells("Contenedor").Value
            .CantMinFormato = _Fila.Cells("CantMinFormato").Value
            .FormatoPqte = IIf(String.IsNullOrEmpty(_Fila.Cells("FormatoPqte").Value), "Pallet", _Fila.Cells("FormatoPqte").Value)
            .StcfiUd1 = _Fila.Cells("StcfiUd1").Value
            .StDispUd1 = _Fila.Cells("StDispUd1").Value
            .PqteHabilitado = _Fila.Cells("PqteHabilitado").Value
            .PqteComprometido = _Fila.Cells("PqteComprometido").Value
            .PqteDisponible = _Fila.Cells("PqteDisponible").Value
            .Ud1XPqte = _Fila.Cells("Ud1XPqte").Value
            .Cantidad = _Fila.Cells("Cantidad").Value
            .CantMinFormato = _Fila.Cells("CantMinFormato").Value
            .Moneda = Cl_Contenedor.Zw_Contenedor.MonedaVenta
            .PrecioXUd1 = _Fila.Cells("PrecioXUd1").Value

        End With

        If ModoSeleccion Then

            If _Fila.Cells("PqteDisponible").Value = 0 Then
                MessageBoxEx.Show(Me, "No hay stock disponible de este producto para la venta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                RowProducto = Nothing
                Return
            End If

            Seleccionado = True
            Me.Close()

        End If

        If ModoPreVenta Then

            Dim Fm As New Frm_PreVenta_IngDet
            Fm._Zw_PreVenta_StockProd = _Zw_PreVenta_StockProd
            Fm.Cl_Contenedor = Cl_Contenedor
            Fm.ShowDialog(Me)

            If Fm.Grabar Then

                _Zw_PreVenta_StockProd = Fm._Zw_PreVenta_StockProd

                With _Zw_PreVenta_StockProd

                    _Fila.Cells("Id").Value = .Id
                    _IdCont = .IdCont
                    _Fila.Cells("Contenedor").Value = .Contenedor
                    _Fila.Cells("CantMinFormato").Value = .CantMinFormato
                    _Fila.Cells("FormatoPqte").Value = .FormatoPqte
                    _Fila.Cells("PqteHabilitado").Value = .PqteHabilitado
                    _Fila.Cells("PqteDisponible").Value = .PqteHabilitado - _Fila.Cells("PqteComprometido").Value
                    _Fila.Cells("StcfiDisponibleUd1").Value = .StcfiDisponibleUd1
                    _Fila.Cells("StcfiDisponibleUd2").Value = .StcfiDisponibleUd2
                    _Fila.Cells("Ud1XPqte").Value = .Ud1XPqte
                    _Fila.Cells("CantMinFormato").Value = .CantMinFormato
                    _Fila.Cells("Moneda").Value = .Moneda
                    _Fila.Cells("PrecioXUd1").Value = .PrecioXUd1

                End With

            End If

            Fm.Dispose()

        End If

    End Sub

    Private Sub Sb_Grilla_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)

        Try

            Dim _Fila As DataGridViewRow = Grilla_Contenedores.CurrentRow
            Dim _Codigo As String = _Fila.Cells("Codigo").Value

            If e.KeyValue = Keys.Enter Then

                SendKeys.Send("{LEFT}")
                e.Handled = True

                Call Grilla_Contenedores_CellDoubleClick(Nothing, Nothing)

            End If

        Catch ex As Exception
            Beep()
        End Try

    End Sub

    Private Sub Frm_ProdContenedorPreVta_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
        If e.KeyValue = Keys.F5 Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Txt_Moneda_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Moneda.ButtonCustomClick

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "TABMO"
        _Filtrar.Campo = "KOMO"
        _Filtrar.Descripcion = "NOKOMO"

        Dim _Komo As String
        Dim _Nokomo As String

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "And KOMO In (Select Distinct KOMO From MAEMO Where TIMO = 'E')",
                               Nothing, False, True) Then

            Dim _Tbl_Modena As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Modena.Rows(0)

            _Komo = _Row.Item("Codigo").ToString.Trim
            _Nokomo = _Row.Item("Descripcion").ToString.Trim

            Txt_Moneda.Text = _Komo

        End If

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _Ls_Zw_PreVenta_StockProd As New List(Of Zw_PreVenta_StockProd)

        For Each _Fila As DataGridViewRow In Grilla_Contenedores.Rows
            Dim _Zw_PreVenta_StockProd As New Zw_PreVenta_StockProd
            With _Zw_PreVenta_StockProd
                .Id = _Fila.Cells("Id").Value
                .IdCont = _IdCont
                .Empresa = _Fila.Cells("Empresa").Value
                .Sucursal = _Fila.Cells("Sucursal").Value
                .Bodega = _Fila.Cells("Bodega").Value
                .Contenedor = _Fila.Cells("Contenedor").Value
                .Codigo = _Fila.Cells("Codigo").Value
                .StcfiDisponibleUd1 = _Fila.Cells("StcfiDisponibleUd1").Value
                .StcfiDisponibleUd2 = _Fila.Cells("StcfiDisponibleUd2").Value
                .FormatoPqte = _Fila.Cells("FormatoPqte").Value
                .PqteHabilitado = _Fila.Cells("PqteHabilitado").Value
                .Ud1XPqte = _Fila.Cells("Ud1XPqte").Value
                .CantMinFormato = _Fila.Cells("CantMinFormato").Value
                .Moneda = Txt_Moneda.Text
                .PrecioXUd1 = _Fila.Cells("PrecioXUd1").Value
            End With
            _Ls_Zw_PreVenta_StockProd.Add(_Zw_PreVenta_StockProd)
        Next

        ' Verificar que al menos un registro tenga PqteHabilitado > 0
        Dim hayHabilitado As Boolean = _Ls_Zw_PreVenta_StockProd.Any(Function(x) Convert.ToDecimal(x.PqteHabilitado) > 0)

        If Not hayHabilitado Then
            MessageBoxEx.Show(Me, "Debe haber al menos un producto con 'Habilitado' mayor a cero.",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Dtp_FechaLibVenta.Value < Date.Now Then
            MessageBoxEx.Show(Me, "La fecha de habilitación de venta no puede ser menos a la fecha actual", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Dtp_FechaLibVenta.Focus()
            Return
        End If

        Cl_Contenedor.Zw_Contenedor.FechaLibVenta = Dtp_FechaLibVenta.Value

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje = Cl_Contenedor.Fx_Grabar_Detalle_En_Contenedor_Documento(Cl_Contenedor.Zw_Contenedor, _Ls_Zw_PreVenta_StockProd)

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If Not _Mensaje.EsCorrecto Then
            Return
        End If

        Me.Close()

    End Sub

End Class
