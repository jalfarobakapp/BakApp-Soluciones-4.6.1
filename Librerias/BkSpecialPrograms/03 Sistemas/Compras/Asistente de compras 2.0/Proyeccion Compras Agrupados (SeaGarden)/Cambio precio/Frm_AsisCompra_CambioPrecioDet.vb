Public Class Frm_AsisCompra_CambioPrecioDet

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String
    Private _Ds As DataSet
    Private _RowLista As DataRow
    Private _CodigoMadre As String
    Private _Lista As String
    Private _CantidadMax As Double
    Private _CantidadNoQuiebra As Double
    Private _FechaDesde As DateTime
    Private _FechaHasta As DateTime
    Public Sub New(_CodigoMadre As String, _Lista As String, _CantidadMax As Double, _FechaDesde As DateTime, _FechaHasta As DateTime)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._CodigoMadre = _CodigoMadre
        Me._Lista = _Lista
        Me._CantidadMax = _CantidadMax
        Me._CantidadNoQuiebra = _CantidadMax
        Me._FechaDesde = _FechaDesde
        Me._FechaHasta = _FechaHasta

        Sb_Formato_Generico_Grilla(Grilla_Resultado, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Formato_Generico_Grilla(Grilla_Precios, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Formato_Generico_Grilla(Grilla_Detalle, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_AsisCompra_CambioPrecioDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla_Resultado.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Precios.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Detalle.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Dim Fm_Espera = New Frm_Form_Esperar
        Fm_Espera.BarraCircular.IsRunning = True
        Fm_Espera.Show()

        Consulta_sql = "Select * From TABPP Where KOLT = '" & _Lista & "'"
        _RowLista = _Sql.Fx_Get_DataRow(Consulta_sql)

        Txt_Lista.Text = _RowLista.Item("KOLT") & " - " & _RowLista.Item("NOKOLT")
        Txt_Lista.Tag = _RowLista.Item("KOLT")

        Lbl_FechaEstudioVenta.Text = "Fecha de estudio de venta desde: <b>" & _FechaDesde.ToShortDateString & "</b> hasta <b>" & _FechaHasta.ToShortDateString & "</b>"

        Input_CantNoQuiebra.Value = _CantidadMax

        Sb_Actualizar_Grilla()

        Fm_Espera.Close()
        Fm_Espera.Dispose()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_RevCambioPrecioXCodMadre
        Consulta_sql = Replace(Consulta_sql, "{Empresa}", Mod_Empresa)
        Consulta_sql = Replace(Consulta_sql, "{CodMadre}", _CodigoMadre)
        Consulta_sql = Replace(Consulta_sql, "{Lista}", _Lista)
        Consulta_sql = Replace(Consulta_sql, "{CantidadMax}", Math.Round(Input_CantNoQuiebra.Value, 0))
        Consulta_sql = Replace(Consulta_sql, "{CantidadNoQuiebra}", Math.Round(_CantidadNoQuiebra, 0))
        Consulta_sql = Replace(Consulta_sql, "{FechaDesde}", _FechaDesde.ToString("yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "{FechaHasta}", _FechaHasta.ToString("yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "{Bakapp}", _Global_BaseBk)

        _Ds = _Sql.Fx_Get_DataSet(Consulta_sql)

        Dim _Tbl_Resultado As DataTable = _Ds.Tables(0)
        Dim _Tbl_Precios As DataTable = _Ds.Tables(1)
        Dim _Tbl_Detalle As DataTable = _Ds.Tables(2)

        With Grilla_Resultado

            .DataSource = _Tbl_Resultado

            OcultarEncabezadoGrilla(Grilla_Resultado, True)

            Dim _DisplayIndex = 0

            .Columns("CodigoMadre").Visible = True
            .Columns("CodigoMadre").HeaderText = "Cód.Madre."
            .Columns("CodigoMadre").ToolTipText = "Código madre"
            .Columns("CodigoMadre").Width = 80
            .Columns("CodigoMadre").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Width = 230
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantidadNoQuiebra").Visible = True
            .Columns("CantidadNoQuiebra").HeaderText = "Cant.No Quiebra"
            .Columns("CantidadNoQuiebra").ToolTipText = "Cantidad mensual de ventas necesaria para evitar quiebre de stock, según el estudio"
            .Columns("CantidadNoQuiebra").Width = 100
            .Columns("CantidadNoQuiebra").DisplayIndex = _DisplayIndex
            .Columns("CantidadNoQuiebra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantidadNoQuiebra").DefaultCellStyle.Format = "###,##0.##"
            _DisplayIndex += 1

            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").HeaderText = "Cant. Tope"
            .Columns("Cantidad").ToolTipText = "Cantidad a la que se llego a tope para el estudio"
            .Columns("Cantidad").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Cantidad").Width = 80
            .Columns("Cantidad").DisplayIndex = _DisplayIndex
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").DefaultCellStyle.Format = "###,##0.##"
            _DisplayIndex += 1

            '.Columns("Cantidad").Visible = True
            '.Columns("Cantidad").HeaderText = "Promedio Ventas" & vbCrLf & "últimos 3 meses"
            '.Columns("Cantidad").ToolTipText = "Promedio de venta mensual de los últimos 3 meses"
            '.Columns("Cantidad").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("Cantidad").Width = 80
            '.Columns("Cantidad").DisplayIndex = _DisplayIndex
            '.Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Cantidad").DefaultCellStyle.Format = "###,##0.##"
            '_DisplayIndex += 1

            .Columns("TotalNeto").Visible = True
            .Columns("TotalNeto").HeaderText = "Total Neto"
            '.Columns("TotalNeto").ToolTipText = "Promedio de venta mensual que se necesita vender para no quebrar stock"
            .Columns("TotalNeto").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("TotalNeto").Width = 80
            .Columns("TotalNeto").DisplayIndex = _DisplayIndex
            .Columns("TotalNeto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalNeto").DefaultCellStyle.Format = "###,##0.##"
            _DisplayIndex += 1

            .Columns("Ppv").HeaderText = "P.P.V."
            .Columns("Ppv").ToolTipText = "Precio promedio ponderado de venta"
            .Columns("Ppv").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Ppv").Width = 70
            .Columns("Ppv").DisplayIndex = _DisplayIndex
            .Columns("Ppv").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Ppv").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Ppv").Visible = True
            _DisplayIndex += 1

            .Columns("MinPrecio").HeaderText = "Precio mínimo"
            .Columns("MinPrecio").ToolTipText = "Precio mínimo de venta, sin incluir el flete."
            .Columns("MinPrecio").Width = 70
            .Columns("MinPrecio").DisplayIndex = _DisplayIndex
            .Columns("MinPrecio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("MinPrecio").DefaultCellStyle.Format = "###,##0.##"
            .Columns("MinPrecio").Visible = True
            _DisplayIndex += 1

            .Columns("MaxPrecio").HeaderText = "Precio máximo"
            .Columns("MaxPrecio").ToolTipText = "Precio máximo de venta, sin incluir el flete."
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
            .Columns("Descripcion").Width = 500
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
            .Columns("TIDO").Width = 30
            .Columns("TIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDO").Visible = True
            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").ToolTipText = "Número de documento"
            .Columns("NUDO").Width = 80
            .Columns("NUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ENDO").Visible = True
            .Columns("ENDO").HeaderText = "Entidad"
            .Columns("ENDO").Width = 80
            .Columns("ENDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").HeaderText = "Razón social"
            .Columns("NOKOEN").Width = 290
            .Columns("NOKOEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMLI").Visible = True
            .Columns("FEEMLI").HeaderText = "F.Emisión"
            .Columns("FEEMLI").Width = 80
            .Columns("FEEMLI").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEEMLI").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("KOPRCT").Visible = True
            .Columns("KOPRCT").HeaderText = "Código"
            .Columns("KOPRCT").Width = 100
            .Columns("KOPRCT").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("NOKOPR").Visible = True
            '.Columns("NOKOPR").HeaderText = "Descripción"
            '.Columns("NOKOPR").Width = 150
            '.Columns("NOKOPR").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("UN").Visible = True
            .Columns("UN").HeaderText = "UN"
            .Columns("UN").Width = 30
            .Columns("UN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CANTIDAD").HeaderText = "Cantidad"
            .Columns("CANTIDAD").Width = 60
            .Columns("CANTIDAD").DisplayIndex = _DisplayIndex
            .Columns("CANTIDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CANTIDAD").DefaultCellStyle.Format = "###,##0.##"
            .Columns("CANTIDAD").Visible = True
            _DisplayIndex += 1

            .Columns("Precio").HeaderText = "P.Venta"
            .Columns("Precio").ToolTipText = "Precio de venta sin flete incluido"
            .Columns("Precio").Width = 60
            .Columns("Precio").DisplayIndex = _DisplayIndex
            .Columns("Precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Precio").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Precio").Visible = True
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Grilla_Detalle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Detalle.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Detalle.CurrentRow
        Dim _Idmaeedo As Integer = _Fila.Cells("Idmaeedo").Value
        Dim _Codigo As String = _Fila.Cells("KOPRCT").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.Codigo_Marcar = _Codigo
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Excel.Click
        ExportarTabla_JetExcel_DataSet(_Ds, Me, "Productos sugiere cambio de precios")
    End Sub

    Private Sub Input_CantNoQuiebra_ButtonCustomClick(sender As Object, e As EventArgs) Handles Input_CantNoQuiebra.ButtonCustomClick
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Grilla_Detalle_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Detalle.CellEnter
        Try
            Dim _Fila As DataGridViewRow = Grilla_Detalle.CurrentRow
            Dim _Codigo As String = _Fila.Cells("KOPRCT").Value
            Dim _Descripcion As String = _Fila.Cells("NOKOPR").Value
            Dim _PrecioVenta As Double = _Fila.Cells("PrecioVenta").Value
            Dim _PrecioLista As Double = _Fila.Cells("PrecioLista").Value
            Dim _Lista As String = Mid(_Fila.Cells("KOLTPR").Value, 6, 3)
            Dim _Flete As Double = _Fila.Cells("Flete").Value

            Txt_InfoDetalle.Text = _Codigo.Trim & " - " & _Descripcion.Trim & ", Precio de venta: " & _PrecioVenta & " - Precio de lista: " & _PrecioLista & " - Lista: " & _Lista & " - Flete: " & _Flete

        Catch ex As Exception
            Txt_InfoDetalle.Text = String.Empty
        End Try
    End Sub
End Class
