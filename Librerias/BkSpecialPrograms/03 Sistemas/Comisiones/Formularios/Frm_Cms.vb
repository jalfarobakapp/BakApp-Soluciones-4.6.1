Imports System.Data.SqlClient
Imports DevComponents.DotNetBar
Imports Spire.Pdf.Exporting.XPS.Schema.Mc

Public Class Frm_Cms

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Public Property Ds As DataSet
    Public Property Id_Enc As Integer

    Dim _Tbl_Filtro_Entidad As DataTable
    Dim _Tbl_Filtro_EntidadExcluidas As DataTable
    Dim _Tbl_Filtro_SucursalDoc As DataTable
    Dim _Tbl_Filtro_Sucursales As DataTable
    Dim _Tbl_Filtro_Bodegas As DataTable
    Dim _Tbl_Filtro_Ciudad As DataTable
    Dim _Tbl_Filtro_Comunas As DataTable
    Dim _Tbl_Filtro_Rubro_Entidades As DataTable
    Dim _Tbl_Filtro_Zonas_Entidades As DataTable
    Dim _Tbl_Filtro_Responzables As DataTable
    Dim _Tbl_Filtro_Vendedores As DataTable
    Dim _Tbl_Filtro_Vendedores_Asignados As DataTable
    Dim _Tbl_Filtro_Productos As DataTable
    Dim _Tbl_Filtro_ProductosExcluidos As DataTable
    Dim _Tbl_Filtro_Super_Familias As DataTable
    Dim _Tbl_Filtro_Familias As DataTable
    Dim _Tbl_Filtro_Sub_Familias As DataTable
    Dim _Tbl_Filtro_Marcas As DataTable
    Dim _Tbl_Filtro_Rubro_Productos As DataTable
    Dim _Tbl_Filtro_Clalibpr As DataTable
    Dim _Tbl_Filtro_Zonas_Productos As DataTable
    Dim _Tbl_Filtro_Tipo_Entidad As DataTable
    Dim _Tbl_Filtro_Act_Economica As DataTable
    Dim _Tbl_Filtro_Tama_Empresa As DataTable
    Dim _Tbl_Filtro_Clas_BakApp As DataTable
    Dim _Tbl_Filtro_Lista_Precio_Asig As DataTable
    Dim _Tbl_Filtro_Lista_Precio_Docu As DataTable

    Public Sub New(_Id_Enc As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Periodo, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Lineas, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Detalle, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_DetalleSc, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Me._Id_Enc = _Id_Enc

    End Sub

    Private Sub Frm_Comi_Periodos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla_Periodo.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Lineas.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Detalle.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_DetalleSc.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        AddHandler Grilla_Lineas.MouseDown, AddressOf Sb_Grilla_MouseDown

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Comisiones_Enc Where Id = " & Id_Enc & vbCrLf &
                       "Select *,NOKOFU From " & _Global_BaseBk & "Zw_Comisiones_Lin" & vbCrLf &
                       "Left Join TABFU On KOFU = CodFuncionario" & vbCrLf &
                       "Where Id_Enc = " & Id_Enc & vbCrLf &
                       "Order by CodFuncionario" & vbCrLf &
                       "Select * From " & _Global_BaseBk & "Zw_Comisiones_Det" & vbCrLf &
                       "Where Id_Enc = " & Id_Enc & vbCrLf &
                       "Select 'COMISION BRUTA SUJETA A SEMANA CORRIDA' As 'Descripcion',* From " & _Global_BaseBk & "Zw_Comisiones_DetSc" & vbCrLf &
                       "Where Id_Enc = " & Id_Enc
        _Ds = _Sql.Fx_Get_DataSet(Consulta_Sql)

        _Ds.Tables(0).TableName = "Periodo"
        _Ds.Tables(1).TableName = "Lineas"
        _Ds.Tables(2).TableName = "Detalle"
        _Ds.Tables(3).TableName = "DetalleSc" ' Semana corrida

        ' Agregar la relación ( campo en común : campo_Relacionado = idCliente )  
        ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  
        _Ds.Relations.Add("Rel_Comisiones_Enc",
                          _Ds.Tables("Periodo").Columns("Id"),
                          _Ds.Tables("Lineas").Columns("Id_Enc"), False)

        _Ds.Relations.Add("Rel_Comisiones_Det",
                          _Ds.Tables("Lineas").Columns("Id"),
                          _Ds.Tables("Detalle").Columns("Id_Lin"), False)

        _Ds.Relations.Add("Rel_Comisiones_DetSc",
                          _Ds.Tables("Detalle").Columns("Id"),
                          _Ds.Tables("DetalleSc").Columns("Id_Det"), False)

        Grilla_Periodo.DataSource = _Ds
        Grilla_Periodo.DataMember = "Periodo"

        Grilla_Lineas.DataSource = _Ds
        Grilla_Lineas.DataMember = "Periodo.Rel_Comisiones_Enc"

        Grilla_Detalle.DataSource = _Ds
        Grilla_Detalle.DataMember = "Periodo.Rel_Comisiones_Enc.Rel_Comisiones_Det"

        Grilla_DetalleSc.DataSource = _Ds
        Grilla_DetalleSc.DataMember = "Periodo.Rel_Comisiones_Enc.Rel_Comisiones_Det.Rel_Comisiones_DetSc"

        OcultarEncabezadoGrilla(Grilla_Periodo, True)
        OcultarEncabezadoGrilla(Grilla_Lineas, True)
        OcultarEncabezadoGrilla(Grilla_Detalle, True)
        OcultarEncabezadoGrilla(Grilla_DetalleSc, True)

        Dim _DisplayIndex = 0

        With Grilla_Periodo

            .Columns("Nombre").Width = 200 + 40
            .Columns("Nombre").HeaderText = "Número"
            .Columns("Nombre").Visible = True
            .Columns("Nombre").ReadOnly = False
            .Columns("Nombre").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Periodo").Width = 80
            .Columns("Periodo").HeaderText = "Periodo"
            .Columns("Periodo").Visible = True
            .Columns("Periodo").ReadOnly = False
            .Columns("Periodo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaDesde").Width = 80
            .Columns("FechaDesde").HeaderText = "Fecha Desde"
            .Columns("FechaDesde").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaDesde").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FechaDesde").ReadOnly = True
            .Columns("FechaDesde").Visible = True
            .Columns("FechaDesde").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaHasta").Width = 80
            .Columns("FechaHasta").HeaderText = "Fecha Hasta"
            .Columns("FechaHasta").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaHasta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FechaHasta").ReadOnly = True
            .Columns("FechaHasta").Visible = True
            .Columns("FechaHasta").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Habiles").Width = 30
            .Columns("Habiles").HeaderText = "Hab."
            .Columns("Habiles").ToolTipText = "Días Habiles"
            .Columns("Habiles").ReadOnly = True
            .Columns("Habiles").Visible = True
            .Columns("Habiles").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Habiles").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sabados").Width = 40
            .Columns("Sabados").HeaderText = "Sáb."
            .Columns("Sabados").ToolTipText = "Días Sabados"
            .Columns("Sabados").ReadOnly = True
            .Columns("Sabados").Visible = True
            .Columns("Sabados").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Sabados").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Domingos").Width = 40
            .Columns("Domingos").HeaderText = "Dom."
            .Columns("Domingos").ToolTipText = "Días domingo"
            .Columns("Domingos").ReadOnly = True
            .Columns("Domingos").Visible = True
            .Columns("Domingos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Domingos").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Festivos").Width = 40
            .Columns("Festivos").HeaderText = "Fes."
            .Columns("Festivos").ToolTipText = "Días Festivos"
            .Columns("Festivos").ReadOnly = True
            .Columns("Festivos").Visible = True
            .Columns("Festivos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Festivos").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Semanas").Width = 40
            .Columns("Semanas").HeaderText = "Sem."
            .Columns("Semanas").ToolTipText = "Semanas"
            .Columns("Semanas").ReadOnly = True
            .Columns("Semanas").Visible = True
            .Columns("Semanas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Semanas").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Refresh()

        End With

        _DisplayIndex = 0

        'Id, Id_Enc, CodFuncionario, SubComBruta, PorcCotizaciones, ComBruta, ComBrutaSemCorr, DiasTrabMes, ValorDia, DomYfest, SemCorrPago

        With Grilla_Lineas

            .Columns("CodFuncionario").Width = 35
            .Columns("CodFuncionario").HeaderText = "Cod."
            .Columns("CodFuncionario").ReadOnly = True
            .Columns("CodFuncionario").Visible = True
            .Columns("CodFuncionario").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOFU").Width = 250
            .Columns("NOKOFU").HeaderText = "Funcionario"
            .Columns("NOKOFU").ReadOnly = True
            .Columns("NOKOFU").Visible = True
            .Columns("NOKOFU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SubComBruta").Width = 100 + 20
            .Columns("SubComBruta").HeaderText = "Com. Neta"
            .Columns("SubComBruta").ToolTipText = "Comisión Neta"
            .Columns("SubComBruta").ReadOnly = True
            .Columns("SubComBruta").Visible = True
            .Columns("SubComBruta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SubComBruta").DefaultCellStyle.Format = "$ ###,##0"
            .Columns("SubComBruta").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PorcCotizaciones").Width = 40
            .Columns("PorcCotizaciones").HeaderText = "Porc %"
            .Columns("PorcCotizaciones").ToolTipText = "Porcentaje comisión"
            .Columns("PorcCotizaciones").ReadOnly = True
            .Columns("PorcCotizaciones").Visible = True
            .Columns("PorcCotizaciones").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PorcCotizaciones").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ComBruta").Width = 100 + 20
            .Columns("ComBruta").HeaderText = "Com. Bruta"
            .Columns("ComBruta").ToolTipText = "Comisión Bruta"
            .Columns("ComBruta").ReadOnly = True
            .Columns("ComBruta").Visible = True
            .Columns("ComBruta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ComBruta").DefaultCellStyle.Format = "$ ###,##0"
            .Columns("ComBruta").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ComBrutaSemCorr").Width = 100
            .Columns("ComBrutaSemCorr").HeaderText = "Com. Bruta S/C"
            .Columns("ComBrutaSemCorr").ToolTipText = "Comision Bruta sujeta a Semana Corrida"
            .Columns("ComBrutaSemCorr").ReadOnly = True
            .Columns("ComBrutaSemCorr").Visible = True
            .Columns("ComBrutaSemCorr").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ComBrutaSemCorr").DefaultCellStyle.Format = "$ ###,##0"
            .Columns("ComBrutaSemCorr").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TotalComBruta").Width = 100 + 20
            .Columns("TotalComBruta").HeaderText = "Total Comisión"
            .Columns("TotalComBruta").ToolTipText = "Comision Bruta + Comision Semana Corrida"
            .Columns("TotalComBruta").ReadOnly = True
            .Columns("TotalComBruta").Visible = True
            .Columns("TotalComBruta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalComBruta").DefaultCellStyle.Format = "$ ###,##0"
            .Columns("TotalComBruta").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1


            .Refresh()

        End With

        _DisplayIndex = 0

        'Id, Id_Enc, Id_Lin, CodFuncionario, Tipo, Valor, Descuento, SubTotal, PorcComision, Total


        With Grilla_Detalle

            .Columns("Descripcion").Width = 180
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").ReadOnly = False
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Valor").Width = 100 + 20
            .Columns("Valor").HeaderText = "Valor"
            '.Columns("Valor").ToolTipText = "Semana corrida a pago"
            .Columns("Valor").ReadOnly = True
            .Columns("Valor").Visible = True
            .Columns("Valor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Valor").DefaultCellStyle.Format = "$ ###,##0.##"
            .Columns("Valor").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descuento").Width = 80
            .Columns("Descuento").HeaderText = "Descuento"
            .Columns("Descuento").ToolTipText = "Descuento"
            .Columns("Descuento").ReadOnly = True
            .Columns("Descuento").Visible = True
            .Columns("Descuento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Descuento").DefaultCellStyle.Format = "$ ###,##0"
            .Columns("Descuento").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SubTotal").Width = 100 + 20
            .Columns("SubTotal").HeaderText = "Sub-Total"
            .Columns("SubTotal").ToolTipText = "Sub-Total"
            .Columns("SubTotal").ReadOnly = True
            .Columns("SubTotal").Visible = True
            .Columns("SubTotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SubTotal").DefaultCellStyle.Format = "$ ###,##0"
            .Columns("SubTotal").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PorcComision").Width = 50
            .Columns("PorcComision").HeaderText = "% CM"
            .Columns("PorcComision").ToolTipText = "Porcentaje comisión"
            .Columns("PorcComision").ReadOnly = True
            .Columns("PorcComision").Visible = True
            .Columns("PorcComision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PorcComision").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Total").Width = 100
            .Columns("Total").HeaderText = "Total"
            .Columns("Total").ToolTipText = "Total"
            .Columns("Total").ReadOnly = True
            .Columns("Total").Visible = True
            .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total").DefaultCellStyle.Format = "$ ###,##0"
            .Columns("Total").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PorcImp").Width = 50
            .Columns("PorcImp").HeaderText = "% Imp"
            .Columns("PorcImp").ToolTipText = "Porcentaje imposiciones"
            .Columns("PorcImp").ReadOnly = True
            .Columns("PorcImp").Visible = True
            .Columns("PorcImp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PorcImp").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ComBruta").Width = 80
            .Columns("ComBruta").HeaderText = "Com. Bruta"
            .Columns("ComBruta").ToolTipText = "Comisión Bruta"
            .Columns("ComBruta").ReadOnly = True
            .Columns("ComBruta").Visible = True
            .Columns("ComBruta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ComBruta").DefaultCellStyle.Format = "$ ###,##0"
            .Columns("ComBruta").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Refresh()

        End With

        With Grilla_DetalleSc

            .Columns("Descripcion").Width = 250
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").ReadOnly = False
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ComBruta").Width = 100
            .Columns("ComBruta").HeaderText = "Valor"
            .Columns("ComBruta").ToolTipText = "Valor Comisión Bruta sujeta a Semana Corridad"
            .Columns("ComBruta").ReadOnly = True
            .Columns("ComBruta").Visible = True
            .Columns("ComBruta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ComBruta").DefaultCellStyle.Format = "$ ###,##0"
            .Columns("ComBruta").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("DiasTrabMes").Width = 60
            .Columns("DiasTrabMes").HeaderText = "Días T/M"
            .Columns("DiasTrabMes").ToolTipText = "Días trabajados en el mes"
            .Columns("DiasTrabMes").ReadOnly = True
            .Columns("DiasTrabMes").Visible = True
            .Columns("DiasTrabMes").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DiasTrabMes").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ValorDia").Width = 100
            .Columns("ValorDia").HeaderText = "Val.Día"
            .Columns("ValorDia").ToolTipText = "Valor día"
            .Columns("ValorDia").ReadOnly = True
            .Columns("ValorDia").Visible = True
            .Columns("ValorDia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ValorDia").DefaultCellStyle.Format = "$ ###,##0"
            .Columns("ValorDia").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Semanas").Width = 100
            .Columns("Semanas").HeaderText = "Semanas"
            .Columns("Semanas").ToolTipText = "Semanas"
            .Columns("Semanas").ReadOnly = True
            .Columns("Semanas").Visible = True
            .Columns("Semanas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Semanas").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TotalPagoSC").Width = 100
            .Columns("TotalPagoSC").HeaderText = "Total"
            .Columns("TotalPagoSC").ToolTipText = "Total semana corrida a pago"
            .Columns("TotalPagoSC").ReadOnly = True
            .Columns("TotalPagoSC").Visible = True
            .Columns("TotalPagoSC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalPagoSC").DefaultCellStyle.Format = "$ ###,##0"
            .Columns("TotalPagoSC").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Habiles").Width = 30
            '.Columns("Habiles").HeaderText = "Hab"
            '.Columns("Habiles").ToolTipText = "Habiles"
            '.Columns("Habiles").ReadOnly = True
            '.Columns("Habiles").Visible = True
            '.Columns("Habiles").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Habiles").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Sabados").Width = 30
            '.Columns("Sabados").HeaderText = "Sáb"
            '.Columns("Sabados").ToolTipText = "Sabados"
            '.Columns("Sabados").ReadOnly = True
            '.Columns("Sabados").Visible = True
            '.Columns("Sabados").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Sabados").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Domingos").Width = 30
            '.Columns("Domingos").HeaderText = "Dom"
            '.Columns("Domingos").ToolTipText = "Sabados"
            '.Columns("Domingos").ReadOnly = True
            '.Columns("Domingos").Visible = True
            '.Columns("Domingos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Domingos").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Festivos").Width = 30
            '.Columns("Festivos").HeaderText = "Fes"
            '.Columns("Festivos").ToolTipText = "Festivos"
            '.Columns("Festivos").ReadOnly = True
            '.Columns("Festivos").Visible = True
            '.Columns("Festivos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Festivos").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Refresh()

        End With

        'Dim _Suma_Dias_Pdte_Preparacion, _Suma_Dias_Pdte_Cierre, _Suma_Dias_Pdte_Despacho As Integer
        'Dim _Msg_Pdte_Preparacion, _Msg_Pdte_Cierre, _Msg_Pdte_Despacho As String

        'Dim _Rows_Pendientes = _Ds.Tables("Pendientes").Rows(0)

        '_Suma_Dias_Pdte_Preparacion = _Rows_Pendientes.Item("Pdte_Preparacion")
        '_Suma_Dias_Pdte_Despacho = _Rows_Pendientes.Item("Pdte_Despacho")
        '_Suma_Dias_Pdte_Cierre = _Rows_Pendientes.Item("Pdte_Cierre")


        Me.Refresh()

    End Sub

    Private Sub Grilla_Detalle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Detalle.CellDoubleClick

        Dim _FilaLin As DataGridViewRow = Grilla_Lineas.CurrentRow
        Dim _FilaDet As DataGridViewRow = Grilla_Detalle.CurrentRow
        Dim _Id_Det As Integer = _FilaDet.Cells("Id").Value
        Dim _TotalNetoComisiones As Double

        Dim _Cabeza = Grilla_Detalle.Columns(Grilla_Detalle.CurrentCell.ColumnIndex).Name
        Dim _ActualizarTotales As Boolean

        Select Case _Cabeza
            Case "Valor"

                Sb_Cargar_TblInforme(_Id_Det)

                Dim _FechaDesde As Date = Grilla_Periodo.Rows(0).Cells("FechaDesde").Value
                Dim _FechaHasta As Date = Grilla_Periodo.Rows(0).Cells("FechaHasta").Value

                Dim _Tabla_Matriz_Informe As String = "Zw_Informe_Venta" '"Zw_TblPaso" ' & Trim(FUNCIONARIO)

                Dim Fm As New Frm_Inf_Ventas_X_Periodo_Cubo(Frm_Inf_Ventas_X_Periodo_Cubo.Enum_Informe.Sucursal,
                                                            _Tabla_Matriz_Informe,
                                                            1,
                                                            _FechaDesde,
                                                            _FechaHasta,
                                                            False)
                Fm.Tbl_Filtro_Entidad = _Tbl_Filtro_Entidad
                Fm.Tbl_Filtro_EntidadExcluidas = _Tbl_Filtro_EntidadExcluidas
                Fm.Tbl_Filtro_SucursalDoc = _Tbl_Filtro_SucursalDoc
                Fm.Tbl_Filtro_Sucursales = _Tbl_Filtro_Sucursales
                Fm.Tbl_Filtro_Bodegas = _Tbl_Filtro_Bodegas
                Fm.Tbl_Filtro_Ciudad = _Tbl_Filtro_Ciudad
                Fm.Tbl_Filtro_Comunas = _Tbl_Filtro_Comunas
                Fm.Tbl_Filtro_Rubro_Entidades = _Tbl_Filtro_Rubro_Entidades
                Fm.Tbl_Filtro_Zonas_Entidades = _Tbl_Filtro_Zonas_Entidades
                Fm.Tbl_Filtro_Responzables = _Tbl_Filtro_Responzables
                Fm.Tbl_Filtro_Vendedores = _Tbl_Filtro_Vendedores
                Fm.Tbl_Filtro_Vendedores_Asignados = _Tbl_Filtro_Vendedores_Asignados
                Fm.Tbl_Filtro_Productos = _Tbl_Filtro_Productos
                Fm.Tbl_Filtro_ProductosExcluidos = _Tbl_Filtro_ProductosExcluidos
                Fm.Tbl_Filtro_Super_Familias = _Tbl_Filtro_Super_Familias
                Fm.Tbl_Filtro_Familias = _Tbl_Filtro_Familias
                Fm.Tbl_Filtro_Sub_Familias = _Tbl_Filtro_Sub_Familias
                Fm.Tbl_Filtro_Marcas = _Tbl_Filtro_Marcas
                Fm.Tbl_Filtro_Rubro_Productos = _Tbl_Filtro_Rubro_Productos
                Fm.Tbl_Filtro_Clalibpr = _Tbl_Filtro_Clalibpr
                Fm.Tbl_Filtro_Zonas_Productos = _Tbl_Filtro_Zonas_Productos
                Fm.Tbl_Filtro_Tipo_Entidad = _Tbl_Filtro_Tipo_Entidad
                Fm.Tbl_Filtro_Act_Economica = _Tbl_Filtro_Act_Economica
                Fm.Tbl_Filtro_Tama_Empresa = _Tbl_Filtro_Tama_Empresa

                Fm.Comisiones = True
                Fm.FechaDesdeFd = _FechaDesde
                Fm.FechaHastaFh = _FechaHasta

                Fm.Btn_Graficar.Visible = False
                Fm.Btn_Crear_Venta.Visible = False
                Fm.Btn_Mantencion_Datos.Visible = False
                Fm.Btn_Consulta_Ventas_X_Cliente.Visible = False
                Fm.Btn_Arbol_Asociaciones.Visible = False

                Fm.ShowDialog(Me)

                If Fm.ImportarComisiones Then

                    _TotalNetoComisiones = Fm.TotalNetoComisiones

                    '_TotalNetoComisiones = 1870718747

                    If Fm.Pro_Filtro_Entidad_Todas Then
                        _Tbl_Filtro_Entidad = Nothing
                    Else
                        _Tbl_Filtro_Entidad = Fm.Tbl_Filtro_Entidad
                    End If

                    _Tbl_Filtro_EntidadExcluidas = Fm.Tbl_Filtro_EntidadExcluidas
                    _Tbl_Filtro_SucursalDoc = Fm.Tbl_Filtro_SucursalDoc
                    _Tbl_Filtro_Sucursales = Fm.Tbl_Filtro_Sucursales
                    _Tbl_Filtro_Bodegas = Fm.Tbl_Filtro_Bodegas
                    _Tbl_Filtro_Ciudad = Fm.Tbl_Filtro_Ciudad
                    _Tbl_Filtro_Comunas = Fm.Tbl_Filtro_Comunas
                    _Tbl_Filtro_Rubro_Entidades = Fm.Tbl_Filtro_Rubro_Entidades
                    _Tbl_Filtro_Zonas_Entidades = Fm.Tbl_Filtro_Zonas_Entidades
                    _Tbl_Filtro_Responzables = Fm.Tbl_Filtro_Responzables
                    _Tbl_Filtro_Vendedores = Fm.Tbl_Filtro_Vendedores
                    _Tbl_Filtro_Vendedores_Asignados = Fm.Tbl_Filtro_Vendedores_Asignados

                    If Fm.Pro_Filtro_Productos_Todos Then
                        _Tbl_Filtro_Productos = Nothing
                    Else
                        _Tbl_Filtro_Productos = Fm.Tbl_Filtro_Productos
                    End If

                    _Tbl_Filtro_ProductosExcluidos = Fm.Tbl_Filtro_ProductosExcluidos
                    _Tbl_Filtro_Super_Familias = Fm.Tbl_Filtro_Super_Familias
                    _Tbl_Filtro_Familias = Fm.Tbl_Filtro_Familias
                    _Tbl_Filtro_Sub_Familias = Fm.Tbl_Filtro_Sub_Familias
                    _Tbl_Filtro_Marcas = Fm.Tbl_Filtro_Marcas
                    _Tbl_Filtro_Rubro_Productos = Fm.Tbl_Filtro_Rubro_Productos
                    _Tbl_Filtro_Clalibpr = Fm.Tbl_Filtro_Clalibpr
                    _Tbl_Filtro_Zonas_Productos = Fm.Tbl_Filtro_Zonas_Productos
                    _Tbl_Filtro_Tipo_Entidad = Fm.Tbl_Filtro_Tipo_Entidad
                    _Tbl_Filtro_Act_Economica = Fm.Tbl_Filtro_Act_Economica
                    _Tbl_Filtro_Tama_Empresa = Fm.Tbl_Filtro_Tama_Empresa

                    _FilaDet.Cells("Valor").Value = _TotalNetoComisiones

                    Sb_Actualizar_TblInforme(_Id_Det)
                    _ActualizarTotales = True

                End If

                Fm.Dispose()

            Case "Descuento", "PorcComision"

                Dim _Valor As Double = _FilaDet.Cells(_Cabeza).Value

                Dim _Aceptar As Boolean = InputBox_Bk(Me, "Ingrese el valor", "Ediar valor", _Valor, False, ,, True, _Tipo_Imagen.Money1, False, _Tipo_Caracter.Moneda)

                If Not _Aceptar Then
                    Return
                End If

                _FilaDet.Cells(_Cabeza).Value = _Valor
                _ActualizarTotales = True

        End Select

        If _ActualizarTotales Then

            Sb_ActualizarValoresPorFuncionario(_FilaLin)
            Return


            Dim _PorcCotizaciones As Double = _FilaLin.Cells("PorcCotizaciones").Value

            Dim _Cien As Double = (100 - _PorcCotizaciones) '- - / 100

            Dim _Valor As Double = _FilaDet.Cells("Valor").Value
            Dim _Descuento As Double = _FilaDet.Cells("Descuento").Value
            Dim _SubTotal As Double = _Valor - _Descuento
            Dim _PorcComision As Double = _FilaDet.Cells("PorcComision").Value

            Dim _Total As Double = Math.Round((_PorcComision / 100) * _SubTotal, 2)
            Dim _ComBruta As Double = (_Total * 100) / _Cien

            _FilaDet.Cells("Subtotal").Value = _SubTotal
            _FilaDet.Cells("Total").Value = _Total
            _FilaDet.Cells("PorcImp").Value = _PorcCotizaciones
            _FilaDet.Cells("ComBruta").Value = _ComBruta

            Dim _SubComBruta As Double

            For Each _Fldet As DataGridViewRow In Grilla_Detalle.Rows
                _SubComBruta += _Fldet.Cells("Total").Value
            Next

            Dim _ComBrutaSemCorr As Double

            For Each _FlDsc As DataGridViewRow In Grilla_DetalleSc.Rows

                Dim _ValorDia As Double
                Dim _TotalPagoSC As Double
                Dim _DiasHabiles As Double = _FlDsc.Cells("DiasHabiles").Value
                Dim _Sabados As Double = _FlDsc.Cells("Sabados").Value
                Dim _Domingos As Double = _FlDsc.Cells("Domingos").Value
                Dim _Festivos As Double = _FlDsc.Cells("Festivos").Value
                Dim _DiasTrabMes As Double = _FlDsc.Cells("DiasTrabMes").Value
                Dim _Semanas As Double = _FlDsc.Cells("Semanas").Value

                _ValorDia = _ComBruta / _DiasHabiles
                _TotalPagoSC = _ValorDia * (_Festivos + _Domingos)

                _FlDsc.Cells("ValorDia").Value = _ValorDia
                _FlDsc.Cells("ValorDia").Value = _ValorDia
                _FlDsc.Cells("TotalPagoSC").Value = _TotalPagoSC

                _ComBrutaSemCorr += _TotalPagoSC

            Next

            Dim _ComBrutaLin As Double = (_SubComBruta * 100) / _Cien
            Dim _TotalComBruta As Double = _ComBrutaLin + _ComBrutaSemCorr

            _FilaLin.Cells("ComBrutaSemCorr").Value = Math.Round(_ComBrutaSemCorr, 0)
            _FilaLin.Cells("SubComBruta").Value = Math.Round(_SubComBruta, 0)
            _FilaLin.Cells("ComBruta").Value = Math.Round(_ComBrutaLin, 0)
            _FilaLin.Cells("TotalComBruta").Value = Math.Round(_TotalComBruta, 0)

        End If

    End Sub

    Sub Sb_Cargar_TblInforme(_Id_Det As Integer)

        _Tbl_Filtro_Entidad = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Entidad")
        _Tbl_Filtro_EntidadExcluidas = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_EntidadExcluidas")
        _Tbl_Filtro_SucursalDoc = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_SucursalDoc")
        _Tbl_Filtro_Sucursales = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Sucursales")
        _Tbl_Filtro_Bodegas = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Bodegas")
        _Tbl_Filtro_Ciudad = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Ciudad")
        _Tbl_Filtro_Comunas = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Comunas")
        _Tbl_Filtro_Rubro_Entidades = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Rubro_Entidades")
        _Tbl_Filtro_Zonas_Entidades = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Zonas_Entidades")
        _Tbl_Filtro_Responzables = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Responzables")
        _Tbl_Filtro_Vendedores = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Vendedores")
        _Tbl_Filtro_Vendedores_Asignados = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Vendedores_Asignados")
        _Tbl_Filtro_Productos = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Productos")
        _Tbl_Filtro_ProductosExcluidos = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_ProductosExcluidos")
        _Tbl_Filtro_Super_Familias = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Super_Familias")
        _Tbl_Filtro_Familias = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Familias")
        _Tbl_Filtro_Sub_Familias = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Sub_Familias")
        _Tbl_Filtro_Marcas = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Marcas")
        _Tbl_Filtro_Rubro_Productos = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Rubro_Productos")
        _Tbl_Filtro_Clalibpr = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Clalibpr")
        _Tbl_Filtro_Zonas_Productos = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Zonas_Productos")
        _Tbl_Filtro_Tipo_Entidad = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Tipo_Entidad")
        _Tbl_Filtro_Act_Economica = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Act_Economica")
        _Tbl_Filtro_Tama_Empresa = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Tama_Empresa")
        '_Tbl_Filtro_Clas_BakApp = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Clas_BakApp")
        '_Tbl_Filtro_Lista_Precio_Asig = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Lista_Precio_Asig")
        '_Tbl_Filtro_Lista_Precio_Docu = Fx_Cargar_TblFiltro(_Id_Det, "Tbl_Filtro_Lista_Precio_Docu")

    End Sub

    Sub Sb_Actualizar_TblInforme(_Id_Det As Integer)

        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_Entidad, _Id_Det, "Tbl_Filtro_Entidad")
        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_EntidadExcluidas, _Id_Det, "Tbl_Filtro_EntidadExcluidas")
        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_SucursalDoc, _Id_Det, "Tbl_Filtro_SucursalDoc")
        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_Sucursales, _Id_Det, "Tbl_Filtro_Sucursales")
        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_Bodegas, _Id_Det, "Tbl_Filtro_Bodegas")
        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_Ciudad, _Id_Det, "Tbl_Filtro_Ciudad")
        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_Comunas, _Id_Det, "Tbl_Filtro_Comunas")
        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_Rubro_Entidades, _Id_Det, "Tbl_Filtro_Rubro_Entidades")
        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_Zonas_Entidades, _Id_Det, "Tbl_Filtro_Zonas_Entidades")
        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_Responzables, _Id_Det, "Tbl_Filtro_Responzables")
        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_Vendedores, _Id_Det, "Tbl_Filtro_Vendedores")
        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_Vendedores_Asignados, _Id_Det, "Tbl_Filtro_Vendedores_Asignados")
        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_Productos, _Id_Det, "Tbl_Filtro_Productos")
        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_ProductosExcluidos, _Id_Det, "Tbl_Filtro_ProductosExcluidos")
        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_Super_Familias, _Id_Det, "Tbl_Filtro_Super_Familias")
        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_Familias, _Id_Det, "Tbl_Filtro_Familias")
        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_Sub_Familias, _Id_Det, "Tbl_Filtro_Sub_Familias")
        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_Marcas, _Id_Det, "Tbl_Filtro_Marcas")
        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_Rubro_Productos, _Id_Det, "Tbl_Filtro_Rubro_Productos")
        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_Clalibpr, _Id_Det, "Tbl_Filtro_Clalibpr")
        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_Zonas_Productos, _Id_Det, "Tbl_Filtro_Zonas_Productos")
        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_Tipo_Entidad, _Id_Det, "Tbl_Filtro_Tipo_Entidad")
        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_Act_Economica, _Id_Det, "Tbl_Filtro_Act_Economica")
        Sb_Actualizar_Filtro_Tmp(_Tbl_Filtro_Tama_Empresa, _Id_Det, "Tbl_Filtro_Tama_Empresa")

    End Sub

    Sub Sb_Actualizar_Filtro_Tmp(_Tbl As DataTable, _Id_Det As Integer, _NombreTblFiltro As String)

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")
        Dim Consulta_sql As String

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Comisiones_DetFlTbl" & vbCrLf &
                       "Where Id_Det = " & _Id_Det & " And NombreTblFiltro = '" & _NombreTblFiltro & "'" & vbCrLf

        If Not _Tbl Is Nothing Then

            If _Tbl.Rows.Count Then

                For Each _Fila As DataRow In _Tbl.Rows

                    Dim _Chk As Boolean = _Fila.Item("Chk")

                    If _Chk Then

                        Dim _Codigo = _Fila.Item("Codigo")
                        Dim _Descripcion = _Fila.Item("Descripcion")

                        Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_Comisiones_DetFlTbl (Id_Det,Chk,Codigo,Descripcion,NombreTblFiltro) VALUES" & Space(1) &
                                        "(" & _Id_Det & ",1,'" & _Codigo & "','" & _Descripcion & "','" & _NombreTblFiltro & "')" & vbCrLf

                    End If

                Next

            End If

        End If

        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

    End Sub

    Function Fx_Cargar_TblFiltro(_Id_Dte As Integer, _NombreTblFiltro As String) As DataTable

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        Dim _Tbl As DataTable

        Consulta_Sql = "Select Chk,Codigo,Descripcion From " & _Global_BaseBk & "Zw_Comisiones_DetFlTbl" & vbCrLf &
                       "Where Id_Det = " & _Id_Dte & " And NombreTblFiltro = '" & _NombreTblFiltro & "'"
        _Tbl = _Sql.Fx_Get_Tablas(Consulta_Sql)

        If CBool(_Tbl.Rows.Count) Then
            _Tbl.TableName = _NombreTblFiltro
        End If

        Return _Tbl

    End Function

    Private Sub Btn_ActualizarVendedores_Click(sender As Object, e As EventArgs) Handles Btn_ActualizarVendedores.Click

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Comisiones_Fun" & vbCrLf &
                       "Where CodFuncionario not in (Select CodFuncionario From " & _Global_BaseBk &
                       "Zw_Comisiones_Lin Where Id_Enc = " & Id_Enc & ") And Habilitado = 1"
        Dim _Tbl_Funcionarios As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Dim _SqlQuery = String.Empty

        For Each _Fila As DataRow In _Tbl_Funcionarios.Rows

            Dim _CodFuncinario As String = _Fila.Item("CodFuncionario")

            Sb_InsertarFuncionario(Id_Enc, _CodFuncinario, True)

        Next

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_InsertarFuncionario(_Id_Enc As Integer, _CodFuncionario As String, _DejarEnCero As Boolean)

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Comisiones_Enc Where Id = " & _Id_Enc
        Dim _Row_Periodo As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Dim _Habiles As Integer = _Row_Periodo.Item("Habiles")
        Dim _Sabados As Integer = _Row_Periodo.Item("Sabados")
        Dim _Domingos As Integer = _Row_Periodo.Item("Domingos")
        Dim _Festivos As Integer = _Row_Periodo.Item("Festivos")
        Dim _Semanas As Integer = _Row_Periodo.Item("Semanas")
        Dim _DiasTrabMes As Integer = _Habiles - _Festivos

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Comisiones_Mis Where CodFuncionario = '" & _CodFuncionario & "'"
        Dim _Tbl_MisComisiones As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Comisiones_Fun Where CodFuncionario = '" & _CodFuncionario & "'"
        Dim _Row_Funcionario As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Dim _PorcCotizaciones As Double = _Row_Funcionario.Item("AFP") + _Row_Funcionario.Item("Salud")

        Dim _Id_Lin As Integer

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand
        Dim cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        Try


            SQL_ServerClass.Sb_Abrir_Conexion(cn2)

            myTrans = cn2.BeginTransaction()

            If _DejarEnCero Then

                Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Comisiones_Lin Where Id_Enc = " & _Id_Enc & " And CodFuncionario = '" & _CodFuncionario & "'" & vbCrLf &
                               "Delete " & _Global_BaseBk & "Zw_Comisiones_Det Where Id_Enc = " & _Id_Enc & " And CodFuncionario = '" & _CodFuncionario & "'" & vbCrLf &
                               "Delete " & _Global_BaseBk & "Zw_Comisiones_DetSc Where Id_Enc = " & _Id_Enc & " And CodFuncionario = '" & _CodFuncionario & "'"

                Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Comisiones_Lin (Id_Enc,CodFuncionario,PorcCotizaciones) " &
                           "Values (" & _Id_Enc & ",'" & _CodFuncionario & "'," & De_Num_a_Tx_01(_PorcCotizaciones, False, 5) & ")"
            Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
            Comando.Transaction = myTrans
            Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
            While dfd1.Read()
                _Id_Lin = dfd1("Identity")
            End While
            dfd1.Close()

            For Each _Fila As DataRow In _Tbl_MisComisiones.Rows

                Dim _Id_Det As Integer
                Dim _Id_Mis As Integer = _Fila.Item("Id")
                Dim _vPorcComision As Double = _Fila.Item("PorcComision")
                Dim _PorcComision As String = De_Num_a_Tx_01(_vPorcComision, False, 5)
                Dim _TieneSC As Boolean = _Fila.Item("TieneSC")
                Dim _Descripcion As String = _Fila.Item("Descripcion")

                Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Comisiones_Det (Id_Enc,Id_Lin,Id_Mis,Descripcion,CodFuncionario,PorcComision) " &
                               "Values (" & _Id_Enc & "," & _Id_Lin & "," & _Id_Mis & ",'" & _Descripcion & "','" & _CodFuncionario & "'," & _PorcComision & ")"

                Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
                Comando.Transaction = myTrans
                dfd1 = Comando.ExecuteReader()
                While dfd1.Read()
                    _Id_Det = dfd1("Identity")
                End While
                dfd1.Close()

                If _TieneSC Then

                    Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Comisiones_DetSc (Id_Enc,Id_Lin,Id_Det,CodFuncionario,DiasHabiles,Sabados,Domingos,Festivos,DiasTrabMes,Semanas) Values " &
                                   "(" & _Id_Enc & "," & _Id_Lin & "," & _Id_Det & ",'" & _CodFuncionario & "'," & _Habiles & "," & _Sabados & "," & _Domingos & "," & _Festivos & "," & _DiasTrabMes & "," & _Semanas & ")"
                    Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                End If

            Next

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

        Catch ex As Exception

            My.Computer.FileSystem.WriteAllText("ArchivoSalida", ex.Message & vbCrLf & ex.StackTrace, False)
            MessageBoxEx.Show(ex.Message & vbCrLf & vbCrLf & "Transaccion desecha", "Problema",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)

            If Not IsNothing(myTrans) Then
                myTrans.Rollback()
            End If

            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

        End Try

    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Btn_ActualizarUsuarioActualRecalcular_Click(sender As Object, e As EventArgs) Handles Btn_ActualizarUsuarioActualRecalcular.Click

        Dim _Fila_Lin As DataGridViewRow = Grilla_Lineas.CurrentRow

        Sb_ActualizarValoresPorFuncionario(_Fila_Lin)

    End Sub

    Private Sub Btn_ActualizarUsuarioActualDejarCero_Click(sender As Object, e As EventArgs) Handles Btn_ActualizarUsuarioActualDejarCero.Click

        Dim _Fila As DataGridViewRow = Grilla_Lineas.CurrentRow

        Dim _CodFuncinario As String = _Fila.Cells("CodFuncionario").Value

        Sb_InsertarFuncionario(Id_Enc, _CodFuncinario, True)

        MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Actualizar datos del funcionario", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_01)
                End If
            End With
        End If
    End Sub

    Sub Sb_ActualizarValoresPorFuncionario(_Fila_Lin As DataGridViewRow)

        Dim _Id_Lin As Integer = _Fila_Lin.Cells("Id").Value
        Dim _PorcCotizaciones As Double = _Fila_Lin.Cells("PorcCotizaciones").Value
        Dim _CodFuncionario As String = _Fila_Lin.Cells("CodFuncionario").Value

        Dim _Cien As Double = (100 - _PorcCotizaciones) '- - / 100

        Dim _Row_Lin = Ds.Tables("Lineas").Select("CodFuncionario = '" & _CodFuncionario & "'", "")

        Dim _SubComBruta As Double
        Dim _ComBrutaSemCorr As Double

        Dim _Tbl_Detalle As DataTable = Ds.Tables("Detalle")

        For Each _Row_Det As DataRow In _Tbl_Detalle.Rows

            If _Id_Lin = _Row_Det.Item("Id_Lin") Then

                Dim _Id_Det As Integer = _Row_Det.Item("Id")

                Dim _Valor As Double = _Row_Det.Item("Valor")
                Dim _Descuento As Double = _Row_Det.Item("Descuento")
                Dim _SubTotal As Double = _Valor - _Descuento
                Dim _PorcComision As Double = _Row_Det.Item("PorcComision")
                Dim _Descripcion As String = _Row_Det.Item("Descripcion")

                _PorcComision = (_PorcComision / 100)

                Dim _Total As Double = Math.Round(_PorcComision * _SubTotal, 2)
                Dim _ComBruta As Double = (_Total * 100) / _Cien

                _Row_Det.Item("Subtotal") = _SubTotal
                _Row_Det.Item("Total") = _Total
                _Row_Det.Item("PorcImp") = _PorcCotizaciones
                _Row_Det.Item("ComBruta") = Math.Round(_ComBruta, 0)

                _SubComBruta += _Row_Det.Item("Total")

                Dim _Tbl_DetalleSc As DataTable = Ds.Tables("DetalleSc")

                For Each _FlDSc As DataRow In _Tbl_DetalleSc.Rows

                    If _Id_Det = _FlDSc.Item("Id_Det") Then

                        Dim _ValorDia As Double
                        Dim _TotalPagoSC As Double
                        Dim _DiasHabiles As Double = _FlDSc.Item("DiasHabiles")
                        Dim _Sabados As Double = _FlDSc.Item("Sabados")
                        Dim _Domingos As Double = _FlDSc.Item("Domingos")
                        Dim _Festivos As Double = _FlDSc.Item("Festivos")
                        Dim _DiasTrabMes As Double = _FlDSc.Item("DiasTrabMes")
                        Dim _Semanas As Double = _FlDSc.Item("Semanas")

                        _ValorDia = _ComBruta / _DiasHabiles
                        _TotalPagoSC = _ValorDia * (_Festivos + _Domingos)

                        _FlDSc.Item("ValorDia") = _ValorDia
                        _FlDSc.Item("TotalPagoSC") = _TotalPagoSC
                        _FlDSc.Item("ComBruta") = Math.Round(_ComBruta, 0)

                        _ComBrutaSemCorr += _TotalPagoSC

                    End If

                Next

            End If

        Next

        Dim _ComBrutaLin As Double = (_SubComBruta * 100) / _Cien
        Dim _TotalComBruta As Double = _ComBrutaLin + _ComBrutaSemCorr

        _Fila_Lin.Cells("ComBrutaSemCorr").Value = Math.Round(_ComBrutaSemCorr, 0)
        _Fila_Lin.Cells("SubComBruta").Value = Math.Round(_SubComBruta, 0)
        _Fila_Lin.Cells("ComBruta").Value = _ComBrutaLin
        _Fila_Lin.Cells("TotalComBruta").Value = _TotalComBruta

        Grilla_Lineas.Refresh()
        Grilla_Detalle.Refresh()
        Grilla_DetalleSc.Refresh()

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _Tbl_Lineas As DataTable = Ds.Tables("Lineas")
        Dim _Tbl_Detalle As DataTable = Ds.Tables("Detalle")
        Dim _Tbl_DetalleSc As DataTable = Ds.Tables("DetalleSc")

        Consulta_Sql = String.Empty

        For Each _Fila_Lineas As DataRow In _Tbl_Lineas.Rows

            Dim _Id_Lin As Integer = _Fila_Lineas.Item("Id")

            Dim _CodFuncionario As String = _Fila_Lineas.Item("CodFuncionario")
            Dim _SubComBruta As String = De_Num_a_Tx_01(_Fila_Lineas.Item("SubComBruta"), False, 5)
            Dim _PorcCotizaciones As String = De_Num_a_Tx_01(_Fila_Lineas.Item("PorcCotizaciones"), False, 5)
            Dim _ComBruta As String = De_Num_a_Tx_01(_Fila_Lineas.Item("ComBruta"), False, 5)
            Dim _ComBrutaSemCorr As String = De_Num_a_Tx_01(_Fila_Lineas.Item("ComBrutaSemCorr"), False, 5)
            Dim _TotalComBruta As String = De_Num_a_Tx_01(_Fila_Lineas.Item("TotalComBruta"), False, 5)

            Consulta_Sql += "Update " & _Global_BaseBk & "Zw_Comisiones_Lin Set " &
                           "SubComBruta = " & _SubComBruta &
                           ",PorcCotizaciones = " & _PorcCotizaciones &
                           ",ComBruta = " & _ComBruta &
                           ",ComBrutaSemCorr = " & _ComBrutaSemCorr &
                           ",TotalComBruta = " & _TotalComBruta &
                           "Where Id = " & _Id_Lin & vbCrLf

        Next

        Consulta_Sql += vbCrLf

        For Each _Fila_Detalle As DataRow In _Tbl_Detalle.Rows

            Dim _Id_Det As Integer = _Fila_Detalle.Item("Id")

            Dim _Descripcion As String = _Fila_Detalle.Item("Descripcion")
            Dim _Valor As String = De_Num_a_Tx_01(_Fila_Detalle.Item("Valor"), False, 5)
            Dim _Descuento As String = De_Num_a_Tx_01(_Fila_Detalle.Item("Descuento"), False, 5)
            Dim _SubTotal As String = De_Num_a_Tx_01(_Fila_Detalle.Item("SubTotal"), False, 5)
            Dim _PorcComision As String = De_Num_a_Tx_01(_Fila_Detalle.Item("PorcComision"), False, 5)
            Dim _Total As String = De_Num_a_Tx_01(_Fila_Detalle.Item("Total"), False, 5)
            Dim _PorcImp As String = De_Num_a_Tx_01(_Fila_Detalle.Item("PorcImp"), False, 5)
            Dim _ComBruta As String = De_Num_a_Tx_01(_Fila_Detalle.Item("ComBruta"), False, 5)

            Consulta_Sql += "Update " & _Global_BaseBk & "Zw_Comisiones_Det Set " &
               "Descripcion = '" & _Descripcion & "'" &
               ",Valor = " & _Valor &
               ",Descuento = " & _Descuento &
               ",SubTotal = " & _SubTotal &
               ",PorcComision = " & _PorcComision &
               ",Total = " & _Total &
               ",PorcImp = " & _PorcImp &
               ",ComBruta = " & _ComBruta &
               "Where Id = " & _Id_Det & vbCrLf

        Next

        Consulta_Sql += vbCrLf

        For Each _Fila_DetalleSc As DataRow In _Tbl_DetalleSc.Rows

            Dim _Id_DetSc As Integer = _Fila_DetalleSc.Item("Id")

            Dim _ComBruta As String = De_Num_a_Tx_01(_Fila_DetalleSc.Item("ComBruta"), False, 5)
            Dim _ValorDia As String = De_Num_a_Tx_01(_Fila_DetalleSc.Item("ValorDia"), False, 5)
            Dim _TotalPagoSC As String = De_Num_a_Tx_01(_Fila_DetalleSc.Item("TotalPagoSC"), False, 5)
            Dim _DiasHabiles As String = De_Num_a_Tx_01(_Fila_DetalleSc.Item("DiasHabiles"), False, 5)
            Dim _Sabados As String = De_Num_a_Tx_01(_Fila_DetalleSc.Item("Sabados"), False, 5)
            Dim _Domingos As String = De_Num_a_Tx_01(_Fila_DetalleSc.Item("Domingos"), False, 5)
            Dim _Festivos As String = De_Num_a_Tx_01(_Fila_DetalleSc.Item("Festivos"), False, 5)
            Dim _DiasTrabMes As String = De_Num_a_Tx_01(_Fila_DetalleSc.Item("DiasTrabMes"), False, 5)
            Dim _Semanas As String = De_Num_a_Tx_01(_Fila_DetalleSc.Item("Semanas"), False, 5)

            Consulta_Sql += "Update " & _Global_BaseBk & "Zw_Comisiones_DetSc Set " &
                "ComBruta = " & _ComBruta &
                ",ValorDia = " & _ValorDia &
                ",TotalPagoSC = " & _TotalPagoSC &
                ",DiasHabiles = " & _DiasHabiles &
                ",Sabados = " & _Sabados &
                ",Domingos = " & _Domingos &
                ",Festivos = " & _Festivos &
                ",DiasTrabMes = " & _DiasTrabMes &
                ",Semanas = " & _Semanas &
                "Where Id = " & _Id_DetSc & vbCrLf

        Next

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

End Class
