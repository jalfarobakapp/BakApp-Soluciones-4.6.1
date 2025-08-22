Public Class Frm_PreVenta_Productos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Empresa As String
    Private _IdCont As Integer
    Private _Contenedor As String

    Dim _Cl_Contenedor As New Cl_Contenedor

    Public Property ModoSeleccion As Boolean
    Public Property ModoPreVenta As Boolean
    Public Property Seleccionado As Boolean
    Public Property RowProducto As DataRow
    Public Property Cl_PreVenta As New PreVenta.Cl_PreVenta

    Public Sub New(_Empresa As String, _IdCont As Integer, _Contenedor As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me._Empresa = _Empresa
        Me._IdCont = _IdCont
        Me._Contenedor = _Contenedor

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Contenedores, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Color_Botones_Barra(Bar1)

        _Cl_Contenedor.Zw_Contenedor = _Cl_Contenedor.Fx_Llenar_Contenedor(_IdCont)

    End Sub

    Private Sub Frm_ProdContenedorPreVta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "CONTENEDOR: " & _Cl_Contenedor.Zw_Contenedor.Contenedor & " - " & _Cl_Contenedor.Zw_Contenedor.NombreContenedor

        AddHandler Grilla_Contenedores.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Contenedores.KeyDown, AddressOf Sb_Grilla_KeyDown

        Sb_Actualizar_Grilla()

        Btn_Grabar.Visible = Not ModoSeleccion

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String = String.Empty

        'If Chk_Abierto.Checked Then
        '    _Condicion = " And Estado = 'Abierto'"
        'End If

        Consulta_sql = "Select *,StcfiDisponibleUd1-StcCompUd1 As StDispUd1,PqteHabilitado-PqteComprometido As 'PqteDisponible'" & vbCrLf &
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

        With Cl_PreVenta

            .Id = _Fila.Cells("Id").Value
            .IdCont = _IdCont
            .Codigo = _Fila.Cells("Codigo").Value
            .Descripcion = _Fila.Cells("NOKOPR").Value
            .Contenedor = _Fila.Cells("Contenedor").Value
            .CantMinFormato = _Fila.Cells("CantMinFormato").Value
            .FormatoPqte = _Fila.Cells("FormatoPqte").Value
            .StcfiUd1 = _Fila.Cells("StcfiUd1").Value
            .StDispUd1 = _Fila.Cells("StDispUd1").Value
            .PqteHabilitado = _Fila.Cells("PqteHabilitado").Value
            .PqteComprometido = _Fila.Cells("PqteComprometido").Value
            .PqteDisponible = _Fila.Cells("PqteDisponible").Value
            .Ud1XPqte = _Fila.Cells("Ud1XPqte").Value
            .Cantidad = _Fila.Cells("CantMinFormato").Value
            .CantMinFormato = _Fila.Cells("CantMinFormato").Value
            .Moneda = _Fila.Cells("Moneda").Value
            .PrecioXUd1 = _Fila.Cells("PrecioXUd1").Value

        End With

        If ModoSeleccion Then
            Seleccionado = True
            Me.Close()
        End If

        If ModoPreVenta Then

            Dim Fm As New Frm_PreVenta_IngDet
            Fm.Cl_PreVenta = Cl_PreVenta
            Fm.ShowDialog(Me)

            If Fm.Grabar Then

                Cl_PreVenta = Fm.Cl_PreVenta

                With Cl_PreVenta

                    _Fila.Cells("Id").Value = .Id
                    _IdCont = .IdCont
                    _Fila.Cells("Contenedor").Value = .Contenedor
                    _Fila.Cells("CantMinFormato").Value = .CantMinFormato
                    _Fila.Cells("FormatoPqte").Value = .FormatoPqte
                    _Fila.Cells("PqteHabilitado").Value = .PqteHabilitado
                    _Fila.Cells("PqteDisponible").Value = .PqteHabilitado - _Fila.Cells("PqteComprometido").Value
                    _Fila.Cells("Ud1XPqte").Value = .Ud1XPqte
                    _Fila.Cells("CantMinFormato").Value = .Cantidad
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

End Class
