Public Class Frm_AsisCompra_CambioPrecioDet

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _RowLista As DataRow
    Private _CodigoMadre As String
    Private _Lista As String
    Private _CantidadMax As Double
    Private _FechaDesde As DateTime
    Private _FechaHasta As DateTime
    Public Sub New(_CodigoMadre As String, _Lista As String, _CantidadMax As Double, _FechaDesde As DateTime, _FechaHasta As DateTime)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._CodigoMadre = _CodigoMadre
        Me._Lista = _Lista
        Me._CantidadMax = _CantidadMax
        Me._FechaDesde = _FechaDesde
        Me._FechaHasta = _FechaHasta

    End Sub

    Private Sub Frm_AsisCompra_CambioPrecioDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla_Resultado.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Dim Fm_Espera = New Frm_Form_Esperar
        Fm_Espera.BarraCircular.IsRunning = True
        Fm_Espera.Show()

        Consulta_sql = "Select * From TABPP Where KOLT = '" & _Lista & "'"
        _RowLista = _Sql.Fx_Get_DataRow(Consulta_sql)

        Txt_Lista.Text = _RowLista.Item("KOLT") & " - " & _RowLista.Item("NOKOLT")
        Txt_Lista.Tag = _RowLista.Item("KOLT")

        Lbl_FechaEstudioVenta.Text = "Fecha de estudio de venta desde: <b>" & _FechaDesde.ToShortDateString & "</b> hasta <b>" & _FechaHasta.ToShortDateString & "</b>"

        'Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_RevCambioPrecioXCodMadre
        'Consulta_sql = Replace(Consulta_sql, "{Empresa}", ModEmpresa)
        '    Consulta_sql = Replace(Consulta_sql, "{CodMadre}", _CodMadre)
        '    Consulta_sql = Replace(Consulta_sql, "{Lista}", _Lista)
        '    Consulta_sql = Replace(Consulta_sql, "{CantidadMax}", _CantidadMax)
        '    Consulta_sql = Replace(Consulta_sql, "{FechaDesde}", _FechaDesde.ToString("yyyyMMdd"))
        '    Consulta_sql = Replace(Consulta_sql, "{FechaHasta}", _FechaHasta.ToString("yyyyMMdd"))
        '    Consulta_sql = Replace(Consulta_sql, "{Bakapp}", _Global_BaseBk)

        '    Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        '    Dim _Row As DataRow = _Ds.Tables(1).Rows(0)

        'Sb_Actualizar_Grilla()

        Fm_Espera.Close()
        Fm_Espera.Dispose()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_RevCambioPrecioXCodMadre
        Consulta_sql = Replace(Consulta_sql, "{Empresa}", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "{CodMadre}", _CodigoMadre)
        Consulta_sql = Replace(Consulta_sql, "{Lista}", _Lista)
        Consulta_sql = Replace(Consulta_sql, "{CantidadMax}", _CantidadMax)
        Consulta_sql = Replace(Consulta_sql, "{FechaDesde}", _FechaDesde.ToString("yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "{FechaHasta}", _FechaHasta.ToString("yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "{Bakapp}", _Global_BaseBk)

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        Dim _Tbl_Resultado As DataTable = _Ds.Tables(0)
        Dim _Tbl_Precios As DataTable = _Ds.Tables(1)
        Dim _Tbl_Detalle As DataTable = _Ds.Tables(2)

        With Grilla_Resultado

            .DataSource = _Tbl_Resultado

            OcultarEncabezadoGrilla(Grilla_Resultado, True)

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

        With Grilla_Precios

            .DataSource = _Tbl_Precios

            OcultarEncabezadoGrilla(Grilla_Precios, True)

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

        With Grilla_Detalle

            .DataSource = _Tbl_Detalle

            OcultarEncabezadoGrilla(Grilla_Detalle, True)

            Dim _DisplayIndex = 0

            .Columns("TIDO").Visible = True
            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").ToolTipText = "Tipo de documento"
            .Columns("TIDO").Width = 40
            .Columns("TIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDO").Visible = True
            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").ToolTipText = "Número de documento"
            .Columns("NUDO").Width = 40
            .Columns("NUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMLI").Visible = True
            .Columns("FEEMLI").HeaderText = "F.Emisión"
            .Columns("FEEMLI").Width = 100
            .Columns("FEEMLI").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEEMLI").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("KOPRCT").Visible = True
            .Columns("KOPRCT").HeaderText = "Código"
            .Columns("KOPRCT").Width = 100
            .Columns("KOPRCT").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Width = 450
            .Columns("NOKOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("UN").Visible = True
            .Columns("UN").HeaderText = "Descripción"
            .Columns("UN").Width = 450
            .Columns("UN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Precio").HeaderText = "P.Lista"
            .Columns("Precio").ToolTipText = "Precio sincuento de flete incluido"
            .Columns("Precio").Width = 70
            .Columns("Precio").DisplayIndex = _DisplayIndex
            .Columns("Precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Precio").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Precio").Visible = True
            _DisplayIndex += 1


        End With

    End Sub

End Class
