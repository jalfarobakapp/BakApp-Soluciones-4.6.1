Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Inf_Ventas_X_Periodo_Proyeccion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Nombre_Tabla_Paso As String
    Dim _Cp_Codigo, _Cp_Descripcion As String

    Dim _Dias_Promedio_R1 As Integer
    Dim _Dias_Promedio_R2 As Integer

    Dim _Meses_R1 As Integer
    Dim _Meses_R2 As Integer

    Dim _Filtro_Sql As String

    Dim _SqlFiltro_Rango_01 As String
    Dim _SqlFiltro_Rango_02 As String
    Dim _Filtro_Nodos As String

    Dim _Tbl_Informe, _Tbl_Totales As DataTable

    Dim _Total_Proyeccion As Double
    Dim _Porc_Proyeccion As Double
    Dim _Proyeccion_Meta As Double
    Dim _Total_Meta As Double


    Public Property Pro_Dias_Transcurridos() As Integer
        Get
            Return Input_Dias_Transcurridos.Value
        End Get
        Set(value As Integer)
            Input_Dias_Transcurridos.Value = value
        End Set
    End Property
    Public Property Pro_Total_Dias() As Integer
        Get
            Return Input_Total_Dias.Value
        End Get
        Set(value As Integer)
            Input_Total_Dias.Value = value
        End Set
    End Property

    Public Property Pro_Chk_Sabado() As Boolean
        Get
            Return Chk_Sabado.Checked
        End Get
        Set(value As Boolean)
            Chk_Sabado.Checked = value
        End Set
    End Property
    Public Property Pro_Chk_Domingo() As Boolean
        Get
            Return Chk_Domingo.Checked
        End Get
        Set(value As Boolean)
            Chk_Domingo.Checked = value
        End Set
    End Property

    Public Property Pro_Fecha_Desde() As Date
        Get
            Return Dtp_Fecha_Proyeccion_Desde.Value
        End Get
        Set(value As Date)
            Dtp_Fecha_Proyeccion_Desde.Value = value
        End Set
    End Property
    Public Property Pro_Fecha_Hasta() As Date
        Get
            Return Dtp_Fecha_Proyeccion_Hasta.Value
        End Get
        Set(value As Date)
            Dtp_Fecha_Proyeccion_Hasta.Value = value
        End Set
    End Property

    Public Sub New(Nombre_Tabla_Paso As String,
                   Cp_Codigo As String,
                   Cp_Descripcion As String,
                   Dias_Promedio_R1 As String,
                   Dias_Promedio_R2 As String,
                   Meses_R1 As String,
                   Meses_R2 As String,
                   SqlFiltro_Rango_01 As String,
                   SqlFiltro_Rango_02 As String,
                   Filtro_Nodos As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla_Proyeccion, 20, New Font("Tahoma", 9), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Totales, 25, New Font("Tahoma", 10), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        _Nombre_Tabla_Paso = Nombre_Tabla_Paso
        _Cp_Codigo = Cp_Codigo
        _Cp_Descripcion = Cp_Descripcion
        _Dias_Promedio_R1 = Dias_Promedio_R1
        _Dias_Promedio_R2 = Dias_Promedio_R2
        _Meses_R1 = Meses_R1
        _Meses_R2 = Meses_R2
        _SqlFiltro_Rango_01 = SqlFiltro_Rango_01
        _SqlFiltro_Rango_02 = SqlFiltro_Rango_02
        _Filtro_Nodos = Filtro_Nodos

        Dtp_Fecha_Proyeccion_Hasta.Value = ultimodiadelmes(FechaDelServidor)
        Dtp_Fecha_Proyeccion_Desde.Value = Primerdiadelmes(FechaDelServidor)

        Sb_Cacular_Dias_Proyeccion()
        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Inf_Ventas_X_Periodo_Proyeccion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Lbl_Dias_Proyeccion.Text = Input_Total_Dias.Value - Input_Dias_Transcurridos.Value

        Input_Dias_Transcurridos.MaxValue = Input_Total_Dias.Value

        If Input_Dias_Transcurridos.Value = Input_Total_Dias.Value Then
            Input_Dias_Transcurridos.Value += -1
        End If

        Sb_Actualizar_Grilla()

        Dim _Fila As DataGridViewRow = Grilla_Totales.Rows(0)

        _Total_Proyeccion = NuloPorNro(_Fila.Cells("Total+Proyeccion").Value, 0)
        _Porc_Proyeccion = NuloPorNro(_Fila.Cells("Porc_Proyeccion").Value, 0)
        _Proyeccion_Meta = NuloPorNro(_Fila.Cells("Proyeccion_Meta").Value, 0)
        _Total_Meta = NuloPorNro(_Fila.Cells("Total_Meta").Value, 0)

        Sb_Calcular_Totales("Porc_Proyeccion")

        AddHandler Grilla_Totales.KeyDown, AddressOf Sb_Grilla_KeyDown
        AddHandler Grilla_Totales.CellEndEdit, AddressOf Sb_Grilla_CellEndEdit
        AddHandler Grilla_Proyeccion.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub


    Sub Sb_Actualizar_Grilla()

        Dim _Unidad = 1
        Dim _Rango As Integer
        Dim _Chk_Mayor_Cero = String.Empty

        Sb_Cacular_Dias_Proyeccion()

        Dim _Dias_Actuales As Integer = Input_Dias_Transcurridos.Value
        Dim _Dias_Total_Mes As Integer = Input_Total_Dias.Value

        If _Cp_Codigo = "0" Then ' _ARBOL_BAKAPP Then

            Consulta_sql = My.Resources.Recursos_Inf_Ventas.Comparativo_de_Ventas_Arbol_Asociaciones

            Consulta_sql = Replace(Consulta_sql, "#Codigo_Nodo#", _Cp_Codigo)
            Consulta_sql = Replace(Consulta_sql, "#Zw_TblArbol_Asociaciones#", _Global_BaseBk & "Zw_TblArbol_Asociaciones")
            Consulta_sql = Replace(Consulta_sql, "#Zw_Prod_Asociacion#", _Global_BaseBk & "Zw_Prod_Asociacion")

        Else
            Consulta_sql = My.Resources.Recursos_Inf_Ventas.Comparativo_de_Ventas
        End If

        Consulta_sql = Replace(Consulta_sql, "#Cp_Codigo#", _Cp_Codigo)
        Consulta_sql = Replace(Consulta_sql, "#Cp_Descripcion#", _Cp_Descripcion)
        Consulta_sql = Replace(Consulta_sql, "#Dias_R1#", _Dias_Promedio_R1)
        Consulta_sql = Replace(Consulta_sql, "#Dias_R2#", _Dias_Promedio_R2)
        Consulta_sql = Replace(Consulta_sql, "#Meses_R1#", _Meses_R1)
        Consulta_sql = Replace(Consulta_sql, "#Meses_R2#", _Meses_R2)
        Consulta_sql = Replace(Consulta_sql, "#Dias_Actuales#", _Dias_Actuales)
        Consulta_sql = Replace(Consulta_sql, "#Dias_Total_Mes#", _Dias_Total_Mes)
        Consulta_sql = Replace(Consulta_sql, "#Total_Meta#", De_Num_a_Tx_01(_Total_Meta, False, 0))
        Consulta_sql = Replace(Consulta_sql, "#_SqlFiltro_Rango_01#", _SqlFiltro_Rango_01)
        Consulta_sql = Replace(Consulta_sql, "#_SqlFiltro_Rango_02#", _SqlFiltro_Rango_02)
        Consulta_sql = Replace(Consulta_sql, "#_Filtro_Nodos#", _Filtro_Nodos)
        Consulta_sql = Replace(Consulta_sql, "#Chk_Mayor_Cero#", _Chk_Mayor_Cero)


        Dim _Prom_Diario_Escogido As String

        If Rdb_Prom_R1.Checked Then
            _Prom_Diario_Escogido = "Prom_Diario_R1"
            _Rango = 1
        ElseIf Rdb_Prom_R2.Checked Then
            _Prom_Diario_Escogido = "Prom_Diario_R2"
            _Rango = 2
        End If

        Consulta_sql = Replace(Consulta_sql, "#Prom_Diario_Escogido#", _Prom_Diario_Escogido)

        If Rdb_Prorroga_R1.Checked Then
            Consulta_sql = Replace(Consulta_sql, "#Porc_R1#", "Porc_R1")
        ElseIf Rdb_Prorroga_Igual.Checked Then
            Consulta_sql = Replace(Consulta_sql, "#Porc_R1#", "(Select Count(*) From #Paso)/100.0")
        End If

        Consulta_sql = Replace(Consulta_sql, "#Total_Venta_RE#", "Total_R1")
        Consulta_sql = Replace(Consulta_sql, "#Tabla_Paso#", _Nombre_Tabla_Paso)

        Dim _Fecha_Desde_01 As Date = Now.Date
        Dim _Fecha_Hasta_01 As Date = Now.Date

        Dim _SqlFiltro_Fechas As String = "And FEEMDO BETWEEN '" & Format(_Fecha_Desde_01, "yyyyMMdd") & "' AND '" &
                                            Format(_Fecha_Hasta_01, "yyyyMMdd") & "'" & vbCrLf

        Consulta_sql = Replace(Consulta_sql, "#_SqlFiltro_Fecha_Rango_01#", _SqlFiltro_Fechas)


        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Tbl_Informe = _Ds.Tables(2) '_Sql.Fx_Get_Tablas(Consulta_sql)
        _Tbl_Totales = _Ds.Tables(3)
        Dim _Row_Totales As DataRow = _Ds.Tables(1).Rows(0)



        With Grilla_Proyeccion

            .DataSource = _Tbl_Informe

            OcultarEncabezadoGrilla(Grilla_Proyeccion)

            .Columns("CODIGO").Width = 100
            .Columns("CODIGO").HeaderText = "Cód."
            .Columns("CODIGO").Visible = True

            .Columns("DESCRIPCION").Width = 280 '340
            .Columns("DESCRIPCION").HeaderText = "Descripción"
            .Columns("DESCRIPCION").Visible = True

            .Columns("Porc_Prorrogado").Width = 100 '110
            .Columns("Porc_Prorrogado").HeaderText = "% Prorroga"
            .Columns("Porc_Prorrogado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_Prorrogado").DefaultCellStyle.Format = "% ###,##.##"
            .Columns("Porc_Prorrogado").Visible = True

            .Columns("Total_Venta_RE").Width = 130 '110
            .Columns("Total_Venta_RE").HeaderText = "Total Ventas R1"
            .Columns("Total_Venta_RE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Venta_RE").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Total_Venta_RE").Visible = True


            .Columns("Prom_Diario_Escogido").Width = 100 '110
            .Columns("Prom_Diario_Escogido").HeaderText = "Prom. Vta. Diario R" & _Rango
            .Columns("Prom_Diario_Escogido").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Prom_Diario_Escogido").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Prom_Diario_Escogido").Visible = True

            .Columns("Total_Venta").Width = 130 '110
            .Columns("Total_Venta").HeaderText = "Total Ventas R2"
            .Columns("Total_Venta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Venta").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Total_Venta").Visible = True

            .Columns("Proyeccion").Width = 100 '110
            .Columns("Proyeccion").HeaderText = "Proyección"
            .Columns("Proyeccion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Proyeccion").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Proyeccion").Visible = True

            .Columns("Total+Proyeccion").Width = 120 '110
            .Columns("Total+Proyeccion").HeaderText = "Ventas + Proyección"
            .Columns("Total+Proyeccion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total+Proyeccion").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Total+Proyeccion").Visible = True

            .Columns("Proyeccion_Adic_Meta_Emp").Width = 140 '110
            .Columns("Proyeccion_Adic_Meta_Emp").HeaderText = "Proyeccción Adicional Meta Empresa"
            .Columns("Proyeccion_Adic_Meta_Emp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Proyeccion_Adic_Meta_Emp").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Proyeccion_Adic_Meta_Emp").Visible = True

            .Columns("Saldo_Meta").Width = 100 '110
            .Columns("Saldo_Meta").HeaderText = "Saldo Meta"
            .Columns("Saldo_Meta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Saldo_Meta").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Saldo_Meta").Visible = True

            .Columns("Ventas_Diarias_Para_Meta").Width = 140 '110
            .Columns("Ventas_Diarias_Para_Meta").HeaderText = "Ventas diarias para alcanzar Meta"
            .Columns("Ventas_Diarias_Para_Meta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Ventas_Diarias_Para_Meta").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Ventas_Diarias_Para_Meta").Visible = True

            .Columns("Total+Proyeccion_Emp").Width = 110 '110
            .Columns("Total+Proyeccion_Emp").HeaderText = "Total + Proyección Meta"
            .Columns("Total+Proyeccion_Emp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total+Proyeccion_Emp").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Total+Proyeccion_Emp").Visible = True

        End With

        With Grilla_Totales

            .DataSource = _Tbl_Totales

            _Tbl_Totales.Columns("Porc_Proyeccion").ReadOnly = False
            _Tbl_Totales.Columns("Proyeccion_Meta").ReadOnly = False
            _Tbl_Totales.Columns("Total_Meta").ReadOnly = False

            OcultarEncabezadoGrilla(Grilla_Totales)

            .Columns("Total+Proyeccion").Width = 130 '110
            .Columns("Total+Proyeccion").HeaderText = "Total + Proyección"
            .Columns("Total+Proyeccion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total+Proyeccion").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Total+Proyeccion").Visible = True

            .Columns("Porc_Proyeccion").Width = 100 '110
            .Columns("Porc_Proyeccion").HeaderText = "% Proyección"
            .Columns("Porc_Proyeccion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_Proyeccion").DefaultCellStyle.Format = "% ###,##.##"
            .Columns("Porc_Proyeccion").Visible = True

            .Columns("Proyeccion_Meta").Width = 130 '110
            .Columns("Proyeccion_Meta").HeaderText = "$ Proyección"
            .Columns("Proyeccion_Meta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Proyeccion_Meta").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Proyeccion_Meta").Visible = True

            .Columns("Total_Meta").Width = 130 '110
            .Columns("Total_Meta").HeaderText = "Meta Empresa"
            .Columns("Total_Meta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Meta").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Total_Meta").Visible = True

        End With

        Dim _Fila As DataGridViewRow = Grilla_Totales.Rows(0)

        _Total_Proyeccion = NuloPorNro(_Fila.Cells("Total+Proyeccion").Value, 0)

        '_Fila.Cells("Porc_Proyeccion").Value = _Porc_Proyeccion
        '_Fila.Cells("Proyeccion_Meta").Value = _Proyeccion_Meta
        '_Fila.Cells("Total_Meta").Value = _Total_Meta

    End Sub


    Private Sub Input_Dias_Transcurridos_ValueChanged(sender As System.Object, e As System.EventArgs) Handles Input_Dias_Transcurridos.ValueChanged
        Lbl_Dias_Proyeccion.Text = Input_Total_Dias.Value - Input_Dias_Transcurridos.Value
    End Sub

    Private Sub Input_Total_Dias_ValueChanged(sender As System.Object, e As System.EventArgs) Handles Input_Total_Dias.ValueChanged
        Input_Dias_Transcurridos.MaxValue = Input_Total_Dias.Value
        Lbl_Dias_Proyeccion.Text = Input_Total_Dias.Value - Input_Dias_Transcurridos.Value
    End Sub

    Private Sub Btn_Actualizar_Informe_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Actualizar_Informe.Click
        Sb_Actualizar_Grilla()
        _Porc_Proyeccion = _Porc_Proyeccion * 100
        Sb_Calcular_Totales("Porc_Proyeccion") 'Porc_Proyeccion
    End Sub

    Private Sub Sb_Grilla_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)

        Dim tecla = e.KeyCode

        If e.KeyValue = Keys.Enter Then

            Dim _Fila As DataGridViewRow = Grilla_Totales.Rows(Grilla_Totales.CurrentRow.Index)
            Dim _Cabeza = Grilla_Totales.Columns(Grilla_Totales.CurrentCell.ColumnIndex).Name

            If _Cabeza <> "Total+Proyeccion" Then

                Grilla_Totales.Columns(_Cabeza).ReadOnly = False
                Grilla_Totales.BeginEdit(True)

                e.SuppressKeyPress = False
                e.Handled = True
            End If

        End If

    End Sub

    Private Sub Sb_Grilla_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Fila As DataGridViewRow = Grilla_Totales.Rows(Grilla_Totales.CurrentRow.Index)
        Dim _Cabeza = Grilla_Totales.Columns(Grilla_Totales.CurrentCell.ColumnIndex).Name

        _Total_Proyeccion = _Fila.Cells("Total+Proyeccion").Value
        _Porc_Proyeccion = _Fila.Cells("Porc_Proyeccion").Value
        _Proyeccion_Meta = _Fila.Cells("Proyeccion_Meta").Value
        _Total_Meta = _Fila.Cells("Total_Meta").Value

        Sb_Calcular_Totales(_Cabeza)
        Grilla_Totales.Columns(_Cabeza).ReadOnly = True



    End Sub

    Sub Sb_Calcular_Totales(_Cabeza As String) 'Porc_Proyeccion


        Select Case _Cabeza

            Case "Porc_Proyeccion"

                _Porc_Proyeccion = _Porc_Proyeccion / 100
                _Proyeccion_Meta = _Total_Proyeccion * _Porc_Proyeccion
                _Total_Meta = _Proyeccion_Meta + _Total_Proyeccion

            Case "Proyeccion_Meta"

                _Porc_Proyeccion = _Proyeccion_Meta / _Total_Proyeccion
                _Total_Meta = _Proyeccion_Meta + _Total_Proyeccion

            Case "Total_Meta"

                'If _Total_Meta < _Total_Proyeccion Then
                'MessageBoxEx.Show(Me, "La proyección total no puede ser menor que la venta más la proyección", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '_Total_Meta = _Total_Proyeccion
                'Else
                _Proyeccion_Meta = _Total_Meta - _Total_Proyeccion
                _Porc_Proyeccion = _Proyeccion_Meta / _Total_Proyeccion
                '_Total_Meta = _Proyeccion_Meta + _Total_Proyeccion
                'End If

        End Select

        Sb_Actualizar_Grilla()


        Dim _Fila As DataGridViewRow = Grilla_Totales.Rows(0)

        _Fila.Cells("Porc_Proyeccion").Value = _Porc_Proyeccion
        _Fila.Cells("Proyeccion_Meta").Value = _Proyeccion_Meta
        _Fila.Cells("Total_Meta").Value = _Total_Meta

    End Sub

    Sub Sb_Calcular_Proyeccion(_Fila As DataGridViewRow)

        Dim _Proyeccion = _Fila.Cells("Proyeccion").Value
        Dim _Total_Proyeccion = _Fila.Cells("Total+Proyeccion").Value
        Dim _Proyeccion_Adic_Meta_Emp = _Fila.Cells("Proyeccion_Adic_Meta_Emp").Value

        Dim _Ventas_Diarias_Para_Meta = _Fila.Cells("Ventas_Diarias_Para_Meta").Value
        Dim _Total_Proyeccion_Emp = _Fila.Cells("Total+Proyeccion_Emp").Value

    End Sub

    Sub Sb_Grilla_RowsPostPaint(sender As System.Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < sender.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If sender.RowHeadersWidth < CInt(size.Width + 20) Then
                sender.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "vb.net",
         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Btn_Excel_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Excel.Click
        If Fx_Tiene_Permiso(Me, "Inf00038") Then ExportarTabla_JetExcel_Tabla(_Tbl_Informe, Me, "Informe")
    End Sub

    Private Function Fx_Feriados(_FDesde As Date, _FHasta As Date) As Integer

        Dim _Fecha_Desde As String = Format(_FDesde, "yyyyMMdd")
        Dim _Fecha_Hasta As String = Format(_FHasta, "yyyyMMdd")

        Dim _Seis As String
        Dim _Siete As String

        If Chk_Sabado.Checked Then _Seis = ",6"
        If Chk_Domingo.Checked Then _Siete = ",7"

        Consulta_sql = "SELECT Tabla,CodigoTabla,NombreTabla,Fecha," &
                       "DATEPART(Dw,Fecha) As Nro_Dia,DATENAME(DW,Fecha) As Nombre_Dia " & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "WHERE (Tabla = 'FERIADOS')" & vbCrLf &
                       "And Fecha Between '" & _Fecha_Desde & "' And '" & _Fecha_Hasta & "'" & vbCrLf &
                       " And DATEPART(Dw,Fecha) In (1,2,3,4,5" & _Seis & _Siete & ")" & vbCrLf &
                       "ORDER BY Fecha"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        'If CBool(_Tbl.Rows.Count) Then
        '_Dias_Feriados_Proyeccion = _Tbl.Rows.Count
        'End If

        Return _Tbl.Rows.Count

    End Function

    Sub Sb_Cacular_Dias_Proyeccion()

        Dim _Fecha_Actual As Date = FechaDelServidor()

        Dim _Fecha_Desde As Date = FormatDateTime(Dtp_Fecha_Proyeccion_Desde.Value, DateFormat.ShortDate)
        Dim _Fecha_Hasta As Date = FormatDateTime(Dtp_Fecha_Proyeccion_Hasta.Value, DateFormat.ShortDate)

        Dim _Dias_Trans_Habiles As Integer = Fx_Cuenta_Dias(_Fecha_Desde, _Fecha_Actual, Opcion_Dias.Habiles)
        Dim _Dias_Trans_Sabados As Integer = Fx_Cuenta_Dias(_Fecha_Desde, _Fecha_Actual, Opcion_Dias.Sabado)
        Dim _Dias_Trans_Domingos As Integer = Fx_Cuenta_Dias(_Fecha_Desde, _Fecha_Actual, Opcion_Dias.Domingo)
        Dim _Dias_Trans_Feriados As Integer = Fx_Feriados(_Fecha_Desde, _Fecha_Actual)

        Input_Dias_Transcurridos.Value = _Dias_Trans_Habiles - _Dias_Trans_Feriados

        If Chk_Sabado.Checked Then Input_Dias_Transcurridos.Value += _Dias_Trans_Sabados
        If Chk_Domingo.Checked Then Input_Dias_Transcurridos.Value += _Dias_Trans_Domingos


        Dim _Dias_Habiles As Integer = Fx_Cuenta_Dias(_Fecha_Desde, _Fecha_Hasta, Opcion_Dias.Habiles)
        Dim _Dias_Sabados As Integer = Fx_Cuenta_Dias(_Fecha_Desde, _Fecha_Hasta, Opcion_Dias.Sabado)
        Dim _Dias_Domingos As Integer = Fx_Cuenta_Dias(_Fecha_Desde, _Fecha_Hasta, Opcion_Dias.Domingo)
        Dim _Dias_Feriados As Integer = Fx_Feriados(_Fecha_Desde, _Fecha_Hasta)

        Input_Total_Dias.Value = _Dias_Habiles - _Dias_Feriados

        If Chk_Sabado.Checked Then Input_Total_Dias.Value += _Dias_Sabados
        If Chk_Domingo.Checked Then Input_Total_Dias.Value += _Dias_Domingos

        Lbl_Dias_Proyeccion.Text = Input_Total_Dias.Value - Input_Dias_Transcurridos.Value

        Input_Dias_Transcurridos.MaxValue = Input_Total_Dias.Value

        If Input_Dias_Transcurridos.Value = Input_Total_Dias.Value Then
            Input_Dias_Transcurridos.Value += -1
        End If

    End Sub

    Private Sub Dtp_Fecha_Desde_01_TextChanged(sender As System.Object, e As System.EventArgs) Handles Dtp_Fecha_Proyeccion_Desde.TextChanged

        Dim _Fecha_Mes_Actual As Date = Primerdiadelmes(FechaDelServidor)

        If FormatDateTime(Dtp_Fecha_Proyeccion_Desde.Value, DateFormat.ShortDate) < FormatDateTime(_Fecha_Mes_Actual, DateFormat.ShortDate) Then
            MessageBoxEx.Show(Me, "La fecha de analisis de proyección no puede ser menor a la fecha " &
                              FormatDateTime(_Fecha_Mes_Actual, DateFormat.ShortDate),
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Dtp_Fecha_Proyeccion_Desde.Value = _Fecha_Mes_Actual

        End If

    End Sub

    Private Sub Dtp_Fecha_Hasta_01_TextChanged(sender As System.Object, e As System.EventArgs) Handles Dtp_Fecha_Proyeccion_Hasta.TextChanged

        If Dtp_Fecha_Proyeccion_Hasta.Value < Dtp_Fecha_Proyeccion_Desde.Value Then
            MessageBoxEx.Show(Me, "La fecha ""Hasta"" no puede ser menor que la fecha ""Desde""", "Validación",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Dtp_Fecha_Proyeccion_Desde.Value = FechaDelServidor()

        End If

    End Sub

    Private Sub Btn_Dias_Feriados_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Dias_Feriados.Click
        Dim Fm As New Frm_Feriados_Anuales
        Fm.Pro_Fecha_Desde = FormatDateTime(Dtp_Fecha_Proyeccion_Desde.Value)
        Fm.Pro_Fecha_Hasta = FormatDateTime(Dtp_Fecha_Proyeccion_Hasta.Value)
        Fm.ShowDialog(Me)
        Fm.Dispose()
        Call Btn_Actualizar_Informe_Click(Nothing, Nothing)
    End Sub
End Class
