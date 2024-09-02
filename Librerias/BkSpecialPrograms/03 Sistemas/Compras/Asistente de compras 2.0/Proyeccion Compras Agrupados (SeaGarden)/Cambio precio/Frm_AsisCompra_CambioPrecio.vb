Public Class Frm_AsisCompra_CambioPrecio

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Tbl_Productos As DataTable
    Private _FechaDesde As DateTime
    Private _FechaHasta As DateTime

    Public Sub New(_Tbl_Productos As DataTable, _FechaDesde As DateTime, _FechaHasta As DateTime)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Tbl_Productos = _Tbl_Productos
        Me._FechaDesde = _FechaDesde
        Me._FechaHasta = _FechaHasta

    End Sub

    Private Sub Frm_AsisCompra_CambioPrecio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For Each _Fila As DataRow In _Tbl_Productos.Rows

            Dim _CodMadre As String = _Fila.Item("Codigo_Nodo_Madre")
            Dim _CantidadMax As Double = _Fila.Item("RotCalculo")

            Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_RevCambioPrecioXCodMadre
            Consulta_sql = Replace(Consulta_sql, "{Empresa}", ModEmpresa)
            Consulta_sql = Replace(Consulta_sql, "{CodMadre}", _CodMadre)
            Consulta_sql = Replace(Consulta_sql, "{CantidadMax}", _CantidadMax)
            Consulta_sql = Replace(Consulta_sql, "{FechaDesde}", _FechaDesde.ToString("yyyyMMdd"))
            Consulta_sql = Replace(Consulta_sql, "{FechaHasta}", _FechaHasta.ToString("yyyyMMdd"))
            Consulta_sql = Replace(Consulta_sql, "{Bakapp}", _Global_BaseBk)

            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            _Fila.Item("PPV") = _Row.Item("PPV")
            _Fila.Item("MinPrecio") = _Row.Item("MinPrecio")
            _Fila.Item("MaxPrecio") = _Row.Item("MaxPrecio")

        Next

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        'Dim _New_Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)
        '_Dv = New DataView
        '_Dv.Table = _New_Ds.Tables("Table")
        '_Tbl_Tickets_Stem = _Dv.Table

        With Grilla

            .DataSource = _Tbl_Productos

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            .Columns("Codigo_Nodo_Madre").Visible = True
            .Columns("Codigo_Nodo_Madre").HeaderText = "Cód.Madre."
            .Columns("Codigo_Nodo_Madre").ToolTipText = "Código madre"
            .Columns("Codigo_Nodo_Madre").Width = 30
            .Columns("Codigo_Nodo_Madre").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Producto").Visible = True
            .Columns("Producto").HeaderText = "Descripción"
            .Columns("Producto").Width = 70
            .Columns("Producto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StockUd1").Visible = True
            .Columns("StockUd1").HeaderText = "TD"
            .Columns("StockUd1").Width = 30
            .Columns("StockUd1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Promedio_Mensual").Visible = True
            .Columns("Promedio_Mensual").HeaderText = "Prom.Mensual"
            .Columns("Promedio_Mensual").Width = 70
            .Columns("Promedio_Mensual").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PPV").HeaderText = "P.P.V."
            .Columns("PPV").ToolTipText = "Precio promedio ponderado de venta"
            .Columns("PPV").Width = 40
            .Columns("PPV").DisplayIndex = _DisplayIndex
            .Columns("PPV").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PPV").DefaultCellStyle.Format = "###,##0.##"
            .Columns("PPV").Visible = True
            _DisplayIndex += 1

            .Columns("MinPrecio").HeaderText = "P. mínimo"
            .Columns("MinPrecio").ToolTipText = "Precio mínimo"
            .Columns("MinPrecio").Width = 40
            .Columns("MinPrecio").DisplayIndex = _DisplayIndex
            .Columns("MinPrecio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("MinPrecio").DefaultCellStyle.Format = "###,##0.##"
            .Columns("MinPrecio").Visible = True
            _DisplayIndex += 1

            .Columns("MaxPrecio").HeaderText = "P. máximo"
            .Columns("MaxPrecio").ToolTipText = "Precio máximo"
            .Columns("MaxPrecio").Width = 40
            .Columns("MaxPrecio").DisplayIndex = _DisplayIndex
            .Columns("MaxPrecio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("MaxPrecio").DefaultCellStyle.Format = "###,##0.##"
            .Columns("MaxPrecio").Visible = True
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
End Class
