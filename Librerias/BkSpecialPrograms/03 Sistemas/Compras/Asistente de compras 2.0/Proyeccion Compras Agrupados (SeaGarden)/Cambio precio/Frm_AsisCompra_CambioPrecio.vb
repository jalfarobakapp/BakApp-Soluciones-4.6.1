Imports NUnrar.Unpack

Public Class Frm_AsisCompra_CambioPrecio

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Tbl_Productos As DataTable
    Private _Lista As String
    Private _FechaDesde As DateTime
    Private _FechaHasta As DateTime
    Private _RowLista As DataRow
    Public Sub New(_Tbl_Productos As DataTable, _Lista As String, _FechaDesde As DateTime, _FechaHasta As DateTime)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Tbl_Productos = _Tbl_Productos
        Me._Lista = _Lista
        Me._FechaDesde = _FechaDesde
        Me._FechaHasta = _FechaHasta

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Formato_Generico_Grilla(Grilla_Productos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_AsisCompra_CambioPrecio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Dim Fm_Espera = New Frm_Form_Esperar
        Fm_Espera.BarraCircular.IsRunning = True
        Fm_Espera.Show()

        Consulta_sql = "Select * From TABPP Where KOLT = '" & _Lista & "'"
        _RowLista = _Sql.Fx_Get_DataRow(Consulta_sql)

        Txt_Lista.Text = _RowLista.Item("KOLT") & " - " & _RowLista.Item("NOKOLT")
        Txt_Lista.Tag = _RowLista.Item("KOLT")

        Lbl_FechaEstudioVenta.Text = "Fecha de estudio de venta desde: <b>" & _FechaDesde.ToShortDateString & "</b> hasta <b>" & _FechaHasta.ToShortDateString & "</b>"

        For Each _Fila As DataRow In _Tbl_Productos.Rows

            Dim _CodMadre As String = _Fila.Item("Codigo_Nodo_Madre")
            Dim _CantidadMax As Double = _Fila.Item("RotMensual_NoQuiebra")

            Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_RevCambioPrecioXCodMadre
            Consulta_sql = Replace(Consulta_sql, "{Empresa}", Mod_Empresa)
            Consulta_sql = Replace(Consulta_sql, "{CodMadre}", _CodMadre)
            Consulta_sql = Replace(Consulta_sql, "{Lista}", _Lista)
            Consulta_sql = Replace(Consulta_sql, "{CantidadMax}", _CantidadMax)
            Consulta_sql = Replace(Consulta_sql, "{FechaDesde}", _FechaDesde.ToString("yyyyMMdd"))
            Consulta_sql = Replace(Consulta_sql, "{FechaHasta}", _FechaHasta.ToString("yyyyMMdd"))
            Consulta_sql = Replace(Consulta_sql, "{Bakapp}", _Global_BaseBk)

            Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

            Dim _Row As DataRow = _Ds.Tables(1).Rows(0)

            _Fila.Item("PPV") = _Row.Item("PPV")
            _Fila.Item("MinPrecio") = _Row.Item("MinPrecio")
            _Fila.Item("MaxPrecio") = _Row.Item("MaxPrecio")
            _Fila.Item("RevisarPrecio") = _Row.Item("RevisarPrecio")

        Next

        Sb_Actualizar_Grilla()

        Fm_Espera.Close()
        Fm_Espera.Dispose()

    End Sub

    Sub Sb_Actualizar_Grilla()

        'Dim _New_Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)
        '_Dv = New DataView
        '_Dv.Table = _New_Ds.Tables("Table")
        '_Tbl_Tickets_Stem = _Dv.Table

        With Grilla

            .DataSource = _Tbl_Productos

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Codigo_Nodo_Madre").Visible = True
            .Columns("Codigo_Nodo_Madre").HeaderText = "Cód.Madre."
            .Columns("Codigo_Nodo_Madre").ToolTipText = "Código madre"
            .Columns("Codigo_Nodo_Madre").Width = 80
            .Columns("Codigo_Nodo_Madre").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Producto").Visible = True
            .Columns("Producto").HeaderText = "Descripción"
            .Columns("Producto").Width = 270
            .Columns("Producto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StockUd1").Visible = True
            .Columns("StockUd1").HeaderText = "Stock físico"
            .Columns("StockUd1").Width = 60
            .Columns("StockUd1").DisplayIndex = _DisplayIndex
            .Columns("StockUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StockUd1").DefaultCellStyle.Format = "###,##0.##"
            _DisplayIndex += 1

            .Columns("Promedio_Mensual").Visible = True
            .Columns("Promedio_Mensual").HeaderText = "Promedio Ventas" & vbCrLf & "últimos 3 meses"
            .Columns("Promedio_Mensual").ToolTipText = "Promedio de venta mensual de los últimos 3 meses"
            .Columns("Promedio_Mensual").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Promedio_Mensual").Width = 80
            .Columns("Promedio_Mensual").DisplayIndex = _DisplayIndex
            .Columns("Promedio_Mensual").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Promedio_Mensual").DefaultCellStyle.Format = "###,##0.##"
            _DisplayIndex += 1

            .Columns("RotMensual_NoQuiebra").Visible = True
            .Columns("RotMensual_NoQuiebra").HeaderText = "Promedio Ventas " & vbCrLf & "Mensual No Quiebra"
            .Columns("RotMensual_NoQuiebra").ToolTipText = "Promedio de venta mensual que se necesita vender para no quebrar stock"
            .Columns("RotMensual_NoQuiebra").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("RotMensual_NoQuiebra").Width = 80
            .Columns("RotMensual_NoQuiebra").DisplayIndex = _DisplayIndex
            .Columns("RotMensual_NoQuiebra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RotMensual_NoQuiebra").DefaultCellStyle.Format = "###,##0.##"
            _DisplayIndex += 1

            .Columns("PPV").HeaderText = "P.P.V."
            .Columns("PPV").ToolTipText = "Precio promedio ponderado de venta"
            .Columns("PPV").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("PPV").Width = 70
            .Columns("PPV").DisplayIndex = _DisplayIndex
            .Columns("PPV").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PPV").DefaultCellStyle.Format = "###,##0.##"
            .Columns("PPV").Visible = True
            _DisplayIndex += 1

            .Columns("MinPrecio").HeaderText = "Precio mínimo"
            .Columns("MinPrecio").ToolTipText = "Precio mínimo"
            .Columns("MinPrecio").Width = 70
            .Columns("MinPrecio").DisplayIndex = _DisplayIndex
            .Columns("MinPrecio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("MinPrecio").DefaultCellStyle.Format = "###,##0.##"
            .Columns("MinPrecio").Visible = True
            _DisplayIndex += 1

            .Columns("MaxPrecio").HeaderText = "Precio máximo"
            .Columns("MaxPrecio").ToolTipText = "Precio máximo"
            .Columns("MaxPrecio").Width = 70
            .Columns("MaxPrecio").DisplayIndex = _DisplayIndex
            .Columns("MaxPrecio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("MaxPrecio").DefaultCellStyle.Format = "###,##0.##"
            .Columns("MaxPrecio").Visible = True
            _DisplayIndex += 1

            .Columns("RevisarPrecio").Visible = True
            .Columns("RevisarPrecio").HeaderText = "R.P."
            .Columns("RevisarPrecio").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("RevisarPrecio").ToolTipText = "Revisar precio"
            .Columns("RevisarPrecio").Width = 30
            .Columns("RevisarPrecio").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Frm_AsisCompra_CambioPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyValue = Keys.F5 Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(e.RowIndex)

        Dim _CodMadre As String = _Fila.Cells("Codigo_Nodo_Madre").Value
        Dim _CantidadMax As Double = _Fila.Cells("RotMensual_NoQuiebra").Value

        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_RevCambioPrecioXCodMadre
        Consulta_sql = Replace(Consulta_sql, "{Empresa}", Mod_Empresa)
        Consulta_sql = Replace(Consulta_sql, "{CodMadre}", _CodMadre)
        Consulta_sql = Replace(Consulta_sql, "{Lista}", _Lista)
        Consulta_sql = Replace(Consulta_sql, "{CantidadMax}", _CantidadMax)
        Consulta_sql = Replace(Consulta_sql, "{FechaDesde}", _FechaDesde.ToString("yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "{FechaHasta}", _FechaHasta.ToString("yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "{Bakapp}", _Global_BaseBk)

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        ExportarTabla_JetExcel_DataSet(_Ds, Me, "Cambio de precio")

    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter

        Try

            Dim _Fila As DataGridViewRow = Grilla.Rows(e.RowIndex)
            Dim _CodigoMadre As String = _Fila.Cells("Codigo_Nodo_Madre").Value

            Consulta_sql = "Select '" & _CodigoMadre & "' As 'CodigoMadre','" & _Lista & "' As 'Lista',FEVI As 'FechaGrab'," &
                           "Mp.KOPR As 'Codigo',Mp.NOKOPR As 'Descripcion',PP01UD As 'PrecioLista'" & vbCrLf &
                           "From MAEPR Mp" & vbCrLf &
                           "Left Join TABPRE Pre On Pre.KOLT = '" & _Lista & "' And Mp.KOPR = Pre.KOPR" & vbCrLf &
                           "Where Mp.KOPR In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo_Nodo In" & vbCrLf &
                           "(Select Prod.Codigo_Nodo" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_Prod_Asociacion Prod" & vbCrLf &
                           "Inner Join " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Asoc On Prod.Codigo_Nodo = Asoc.Codigo_Nodo And Asoc.Es_Seleccionable = 1" & vbCrLf &
                           "Where Asoc.Codigo_Madre = '" & _CodigoMadre & "'))"

            Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            With Grilla_Productos

                .DataSource = _Tbl

                OcultarEncabezadoGrilla(Grilla_Productos, True)

                Dim _DisplayIndex = 0

                .Columns("Lista").Visible = True
                .Columns("Lista").HeaderText = "Lista"
                .Columns("Lista").Width = 40
                .Columns("Lista").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Codigo").Visible = True
                .Columns("Codigo").HeaderText = "Código"
                .Columns("Codigo").Width = 100
                .Columns("Codigo").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Descripcion").Visible = True
                .Columns("Descripcion").HeaderText = "Descripción"
                .Columns("Descripcion").Width = 450
                .Columns("Descripcion").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("FechaGrab").Visible = True
                .Columns("FechaGrab").HeaderText = "F.Vigencia"
                .Columns("FechaGrab").Width = 100
                .Columns("FechaGrab").DefaultCellStyle.Format = "dd/MM/yyyy"
                .Columns("FechaGrab").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("PrecioLista").HeaderText = "P.Lista"
                .Columns("PrecioLista").ToolTipText = "Precio de lista"
                .Columns("PrecioLista").Width = 70
                .Columns("PrecioLista").DisplayIndex = _DisplayIndex
                .Columns("PrecioLista").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("PrecioLista").DefaultCellStyle.Format = "###,##0.##"
                .Columns("PrecioLista").Visible = True
                _DisplayIndex += 1


            End With

        Catch ex As Exception

        End Try

    End Sub

End Class
