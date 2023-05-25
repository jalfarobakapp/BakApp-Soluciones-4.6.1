Imports DevComponents.DotNetBar
Public Class Frm_Comisiones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Public Property Ds As DataSet
    Public Property Id_Enc As Integer

    Public Sub New(_Id_Enc As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Periodo, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Lineas, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Detalle, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Me._Id_Enc = _Id_Enc

    End Sub

    Private Sub Frm_Comi_Periodos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla_Periodo.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Lineas.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Periodo.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Comisiones_Enc Where Id = " & Id_Enc & vbCrLf &
                       "Select *,NOKOFU From " & _Global_BaseBk & "Zw_Comisiones_Lin" & vbCrLf &
                       "Left Join TABFU On KOFU = CodFuncionario" & vbCrLf &
                       "Where Id_Enc = " & Id_Enc & vbCrLf &
                       "Select Det.*,Tp.Descripcion From " & _Global_BaseBk & "Zw_Comisiones_Det Det" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Comisiones_Tipos Tp On Det.Tipo = Tp.Tipo" & vbCrLf &
                       "Where Id_Enc = " & Id_Enc
        _Ds = _Sql.Fx_Get_DataSet(Consulta_Sql)

        _Ds.Tables(0).TableName = "Periodo"
        _Ds.Tables(1).TableName = "Lineas"
        _Ds.Tables(2).TableName = "Detalle"

        ' Agregar la relación ( campo en común : campo_Relacionado = idCliente )  
        ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  
        _Ds.Relations.Add("Rel_Comisiones_Enc",
                          _Ds.Tables("Periodo").Columns("Id"),
                          _Ds.Tables("Lineas").Columns("Id_Enc"), False)

        _Ds.Relations.Add("Rel_Comisiones_Det",
                          _Ds.Tables("Lineas").Columns("Id"),
                          _Ds.Tables("Detalle").Columns("Id_Lin"), False)

        Grilla_Periodo.DataSource = _Ds
        Grilla_Periodo.DataMember = "Periodo"

        Grilla_Lineas.DataSource = _Ds
        Grilla_Lineas.DataMember = "Periodo.Rel_Comisiones_Enc"

        Grilla_Detalle.DataSource = _Ds
        Grilla_Detalle.DataMember = "Periodo.Rel_Comisiones_Enc.Rel_Comisiones_Det"

        OcultarEncabezadoGrilla(Grilla_Periodo, True)
        OcultarEncabezadoGrilla(Grilla_Lineas, True)
        OcultarEncabezadoGrilla(Grilla_Detalle, True)

        Dim _DisplayIndex = 0

        With Grilla_Periodo

            .Columns("Nombre").Width = 200
            .Columns("Nombre").HeaderText = "Número"
            .Columns("Nombre").Visible = True
            .Columns("Nombre").ReadOnly = False
            .Columns("Nombre").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Periodo").Width = 80
            .Columns("Periodo").HeaderText = "Número"
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

            .Columns("NOKOFU").Width = 200
            .Columns("NOKOFU").HeaderText = "Funcionario"
            .Columns("NOKOFU").ReadOnly = True
            .Columns("NOKOFU").Visible = True
            .Columns("NOKOFU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PorcCotizaciones").Width = 40
            .Columns("PorcCotizaciones").HeaderText = "Porc %"
            .Columns("PorcCotizaciones").ToolTipText = "Porcentaje comisión"
            .Columns("PorcCotizaciones").ReadOnly = True
            .Columns("PorcCotizaciones").Visible = True
            .Columns("PorcCotizaciones").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PorcCotizaciones").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ComBruta").Width = 100
            .Columns("ComBruta").HeaderText = "Com. Bruta"
            .Columns("ComBruta").ToolTipText = "Comisión Bruta"
            .Columns("ComBruta").ReadOnly = True
            .Columns("ComBruta").Visible = True
            .Columns("ComBruta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ComBruta").DefaultCellStyle.Format = "$ ###,##0.##"
            .Columns("ComBruta").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ComBrutaSemCorr").Width = 100
            .Columns("ComBrutaSemCorr").HeaderText = "Com. Bruta S/C"
            .Columns("ComBrutaSemCorr").ToolTipText = "Comision Bruta sujeta a Semana Corrida"
            .Columns("ComBrutaSemCorr").ReadOnly = True
            .Columns("ComBrutaSemCorr").Visible = True
            .Columns("ComBrutaSemCorr").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ComBrutaSemCorr").DefaultCellStyle.Format = "$ ###,##0.##"
            .Columns("ComBrutaSemCorr").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("DiasTrabMes").Width = 30
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
            .Columns("ValorDia").DefaultCellStyle.Format = "$ ###,##0.##"
            .Columns("ValorDia").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("DomYfest").Width = 30
            .Columns("DomYfest").HeaderText = "Dom & Fes"
            .Columns("DomYfest").ToolTipText = "Domingos y festivos"
            .Columns("DomYfest").ReadOnly = True
            .Columns("DomYfest").Visible = True
            .Columns("DomYfest").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DomYfest").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SemCorrPago").Width = 100
            .Columns("SemCorrPago").HeaderText = "Sem.C/P"
            .Columns("SemCorrPago").ToolTipText = "Semana corrida a pago"
            .Columns("SemCorrPago").ReadOnly = True
            .Columns("SemCorrPago").Visible = True
            .Columns("SemCorrPago").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SemCorrPago").DefaultCellStyle.Format = "$ ###,##0.##"
            .Columns("SemCorrPago").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Refresh()

        End With

        _DisplayIndex = 0

        'Id, Id_Enc, Id_Lin, CodFuncionario, Tipo, Valor, Descuento, SubTotal, PorcComision, Total


        With Grilla_Detalle

            .Columns("Tipo").Width = 40
            .Columns("Tipo").HeaderText = "Tipo"
            .Columns("Tipo").Visible = True
            .Columns("Tipo").ReadOnly = False
            .Columns("Tipo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Width = 150
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").ReadOnly = False
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Valor").Width = 100
            .Columns("Valor").HeaderText = "Valor"
            '.Columns("Valor").ToolTipText = "Semana corrida a pago"
            .Columns("Valor").ReadOnly = True
            .Columns("Valor").Visible = True
            .Columns("Valor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Valor").DefaultCellStyle.Format = "$ ###,##0.##"
            .Columns("Valor").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descuento").Width = 100
            .Columns("Descuento").HeaderText = "Descuento"
            .Columns("Descuento").ToolTipText = "Descuento"
            .Columns("Descuento").ReadOnly = True
            .Columns("Descuento").Visible = True
            .Columns("Descuento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Descuento").DefaultCellStyle.Format = "$ ###,##0.##"
            .Columns("Descuento").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SubTotal").Width = 100
            .Columns("SubTotal").HeaderText = "Sub-Total"
            .Columns("SubTotal").ToolTipText = "Sub-Total"
            .Columns("SubTotal").ReadOnly = True
            .Columns("SubTotal").Visible = True
            .Columns("SubTotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SubTotal").DefaultCellStyle.Format = "$ ###,##0.##"
            .Columns("SubTotal").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PorcComision").Width = 100
            .Columns("PorcComision").HeaderText = "Porc%"
            .Columns("PorcComision").ToolTipText = "Porcentaje comisión"
            .Columns("PorcComision").ReadOnly = True
            .Columns("PorcComision").Visible = True
            .Columns("PorcComision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PorcComision").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

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

End Class
