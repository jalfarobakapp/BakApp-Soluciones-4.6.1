'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports System.IO

Public Class Frm_Informe_Gerencia_On_Line

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Cadena_ConexionSQL_Seleccionada As String

    Dim _Ds_Inf_Ventas_OnLine As New Ds_Inf_Ventas_OnLine


    Dim _Tbl_Diario, _Tbl_Mensual, _Tbl_Anual, _Tbl_Guias_Diario, _Tbl_Guias_Mensual As DataTable

    Dim _Tbl_Conexiones As DataTable

    Dim _Total_Diario, _
        _Total_Mensual, _
        _Total_Anual, _
        _Guias_Diarias, _
        _Guias_Mensuales, _
        _Total_Guias_Costo_Diario, _
        _Total_Guias_Costo_Mensual, _
        _Total_Guias_Venta_Diario, _
        _Total_Guias_Venta_Mensual, _
        _Total_Guias_Margen_Diario, _
        _Total_Guias_Margen_Mensual, _
        _Total_Guias_Margen_v_Diario, _
        _Total_Guias_Margen_v_Mensual As Double

    Dim _Fecha_Informe As Date

    Dim _Activar_Tiempo As Boolean

    Dim _Top, _Left As Integer
    Dim _Correr_a_la_derecha As Boolean

    Public Property Pro_Top() As Integer
        Get
            Return Me.Top
        End Get
        Set(ByVal value As Integer)
            _Top = value
        End Set
    End Property

    Public Property Pro_Left() As Integer
        Get
            Return Me.Left
        End Get
        Set(ByVal value As Integer)
            _Left = value
        End Set
    End Property

    Public Property Pro_Fecha_Informe() As Date
        Get
            Return _Fecha_Informe
        End Get
        Set(ByVal value As Date)
            _Activar_Tiempo = False
            _Fecha_Informe = value
            BtnMinimizar.Visible = False
            Btn_Cerrar.Visible = True
            Me.Text = "INFORME DE VENTAS ON - LINE AÑO " & Year(_Fecha_Informe)
        End Set
    End Property

    Public Property Pro_Tiempor_Espera() As Boolean
        Get
            Return Tiempo_Espera.Enabled
        End Get
        Set(ByVal value As Boolean)
            Tiempo_Espera.Enabled = value
        End Set
    End Property

    Public Sub New(ByVal Tbl_Conexiones As DataTable, Optional ByVal Correr_a_la_derecha As Boolean = False)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

       Sb_Formato_Generico_Grilla(Grilla_Dia, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
       Sb_Formato_Generico_Grilla(Grilla_Mes, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
       Sb_Formato_Generico_Grilla(Grilla_Anual, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

       Sb_Formato_Generico_Grilla(Grilla_Guias_Dia, 18, New Font("Tahoma", 8), Color.LightYellow, ScrollBars.Vertical, False, False, False)
       Sb_Formato_Generico_Grilla(Grilla_Guias_Mensual, 18, New Font("Tahoma", 8), Color.LightYellow, ScrollBars.Vertical, False, False, False)

        _Fecha_Informe = FechaDelServidor()

        _Activar_Tiempo = True
        Btn_Cerrar.Visible = False
        _Correr_a_la_derecha = Correr_a_la_derecha

        _Tbl_Conexiones = Tbl_Conexiones

    End Sub

    Sub Sb_Texto_Grupos()

        If Not Me.Text.Contains("(") Then
            Me.Text = "INFORME DE VENTAS ON - LINE AÑO " & Year(_Fecha_Informe)
        End If


        Grupo_Venta_Diaria.Text = "VENTAS POR SUCURSAL FECHA: " & FormatDateTime(_Fecha_Informe, DateFormat.ShortDate)
        Grupo_Venta_Mensual.Text = "ACUMULADO MENSUAL " & UCase(MonthName(Month(_Fecha_Informe))) & " - " & Year(_Fecha_Informe)
        Grupo_Venta_Anual.Text = "VENTAS POR SUCURSAL ACUMULADO ANUAL (" & Year(_Fecha_Informe) & ")"

        Grupo_Guias_Diarias.Text = "GUIAS POR SUCURSAL FECHA: " & FormatDateTime(_Fecha_Informe, DateFormat.ShortDate)
        Grupo_Guias_Mensuales.Text = "GUIAS ACUMULADO MENSUAL " & UCase(MonthName(Month(_Fecha_Informe))) & " - " & Year(_Fecha_Informe)

        Dim _Ano_Anterio As Date = DateAdd(DateInterval.Year, -1, _Fecha_Informe)

        Btn_Ver_Datos_Ano_Anterior.Text = "Ver información año anterior (" & Year(_Ano_Anterio) & ")"

    End Sub

    Private Sub Frm_Informe_Gerencia_On_Line_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If _Correr_a_la_derecha Then
            Me.Top = _Top + 10
            Me.Left = _Left + 10
        End If

        Progreso_Circular_Espera.IsRunning = _Activar_Tiempo
        Sb_Actualizar_Grillas()

        'AddHandler Grilla_Dia.RowPostPaint, AddressOf Sb_RowsPostPaint
        'AddHandler Grilla_Mes.RowPostPaint, AddressOf Sb_RowsPostPaint
        'AddHandler Grilla_Anual.RowPostPaint, AddressOf Sb_RowsPostPaint
        'AddHandler Grilla_Guias_Dia.RowPostPaint, AddressOf Sb_RowsPostPaint

        Sb_Texto_Grupos()

    End Sub

    Sub Sb_Actualizar_Grillas()

        Try
            Bar1.Enabled = False
        

            _Ds_Inf_Ventas_OnLine.Clear()

            _Tbl_Diario = _Ds_Inf_Ventas_OnLine.Tables("Tbl_Diario")
            _Tbl_Mensual = _Ds_Inf_Ventas_OnLine.Tables("Tbl_Mensual")
            _Tbl_Anual = _Ds_Inf_Ventas_OnLine.Tables("Tbl_Anual")
            _Tbl_Guias_Diario = _Ds_Inf_Ventas_OnLine.Tables("Tbl_Guias_Diario")
            _Tbl_Guias_Mensual = _Ds_Inf_Ventas_OnLine.Tables("Tbl_Guias_Mensual")

            _Total_Diario = 0
            _Total_Mensual = 0
            _Total_Anual = 0

            _Total_Guias_Costo_Diario = 0
            _Total_Guias_Costo_Mensual = 0
            _Total_Guias_Venta_Diario = 0
            _Total_Guias_Venta_Mensual = 0
            _Total_Guias_Margen_v_Diario = 0
            _Total_Guias_Margen_v_Mensual = 0

            _Guias_Diarias = 0
            _Guias_Mensuales = 0

            Dim _Directorio As String = Application.StartupPath & "\Data\"
            'Dim _Exists = System.IO.File.Exists(_Directorio & "Conexiones.xml")

            'If Not _Exists Then
            '_DatosConex.WriteXml(_Directorio & "Conexiones.xml")
            'MessageBoxEx.Show("Arvhico XML creado correctamente", "Crear XML de Conexión", _
            '                  MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If

            Dim _DatosConex As New ConexionBK
            _DatosConex.ReadXml(_Directorio & "Conexiones.xml")

            For Each _Fila As DataRow In _Tbl_Conexiones.Rows

                Dim _NombreConexion = _Fila.Item("NombreConexion")
                Dim _Conexion As String = Fx_CadenaConexionSQL(_NombreConexion, _DatosConex)

                Dim _Directorio_Informe = Application.StartupPath & _
                               "\Data\Configuracion_Local\Informes\Informe ventas\Ventas On Line\" & _NombreConexion


                If Not Directory.Exists(_Directorio_Informe) Then
                    System.IO.Directory.CreateDirectory(_Directorio_Informe)
                End If

                Dim _Ds As DataSet
                Dim _Exists = System.IO.File.Exists(_Directorio_Informe & "\Conf_Filtros.xml")
                Dim Fm_Fl As New Frm_Informe_Gerencia_On_Line_Filtros(_NombreConexion)

                If Not _Exists Then
                    Fm_Fl.Sb_Parametros_Actualizar()
                End If
                _Ds = Fm_Fl.Pro_Ds
                Fm_Fl.Dispose()

                Sb_Actualizar_Datos(_Conexion, _Ds)

            Next

            Fx_Nueva_Linea_Venta(_Tbl_Diario, _Total_Diario)
            Fx_Nueva_Linea_Venta(_Tbl_Mensual, _Total_Mensual)
            Fx_Nueva_Linea_Venta(_Tbl_Anual, _Total_Anual)

            Fx_Nueva_Linea_Guia(_Tbl_Guias_Diario, _Guias_Diarias, _Total_Guias_Costo_Diario, _Total_Guias_Venta_Diario)
            Fx_Nueva_Linea_Guia(_Tbl_Guias_Mensual, _Guias_Mensuales, _Total_Guias_Costo_Mensual, _Total_Guias_Venta_Mensual)

            Grilla_Dia.DataSource = _Tbl_Diario
            Grilla_Mes.DataSource = _Tbl_Mensual
            Grilla_Anual.DataSource = _Tbl_Anual

            Grilla_Guias_Dia.DataSource = _Tbl_Guias_Diario
            Grilla_Guias_Mensual.DataSource = _Tbl_Guias_Mensual


            Sb_Formato_Grilla(Grilla_Dia)
            Sb_Formato_Grilla(Grilla_Mes)
            Sb_Formato_Grilla(Grilla_Anual)
            Sb_Formato_Grilla(Grilla_Guias_Dia, True)
            Sb_Formato_Grilla(Grilla_Guias_Mensual, True)


            Sb_Marcar_Linea(Grilla_Dia)
            Sb_Marcar_Linea(Grilla_Mes)
            Sb_Marcar_Linea(Grilla_Anual)
            Sb_Marcar_Linea(Grilla_Guias_Dia)
            Sb_Marcar_Linea(Grilla_Guias_Mensual)

        Catch ex As Exception
        Finally
            Bar1.Enabled = True
        End Try

    End Sub

    Sub Sb_Actualizar_Datos(ByVal _Cadena_ConexionSQL_Server As String, ByVal _Ds As DataSet)


        Dim _Tbl_Configuracion_Filtros As DataTable = _Ds.Tables("Tbl_Configuracion_Filtros")
        Dim _TblFiltro_Sucursal As DataTable = _Ds.Tables("TblFiltro_Sucursal")
        Dim _TblFiltro_Super_Familia As DataTable = _Ds.Tables("TblFiltro_Super_Familia")


        Dim _Fl_Sucursal As String = Generar_Filtro_IN(_TblFiltro_Sucursal, "", "Codigo", False, False, "'")
        Dim _Fl_Super_Familia As String = Generar_Filtro_IN(_TblFiltro_Super_Familia, "", "Codigo", False, False, "'")


        Dim _SQL As New Class_SQL(_Cadena_ConexionSQL_Server)

        Try
            If _Activar_Tiempo Then Tiempo_Espera.Enabled = False

            Dim _Fecha_Servidor = _Fecha_Informe 'FechaDelServidor()

            Dim _Fecha_Dia = Format(_Fecha_Servidor, "yyyyMMdd")

            Dim _Fecha_Mes_Inicio = Format(Primerdiadelmes(_Fecha_Servidor), "yyyyMMdd")
            Dim _Fecha_Mes_Fin = Format(ultimodiadelmes(_Fecha_Servidor), "yyyyMMdd")

            Dim _Fecha_Ano_Inicio = Format(DateSerial(Year(_Fecha_Servidor), 1, 1), "yyyyMMdd")
            Dim _Fecha_Ano_Fin = Year(_Fecha_Servidor) & "1231"


            Dim _Tbl_Inf_Diario, _Tbl_Inf_Mensual, _Tbl_Inf_Anual As DataTable


            '@Fecha_Inicio Date = '#Fecha_Inicio#', 
            '@Fecha_Fin    Date = '#Fecha_Fin#'

            Dim _Nudonodefi = "EDO.NUDONODEFI=0 AND"

            If Chk_Incluir_Vales_Transitorios.Checked Then
                _Nudonodefi = String.Empty
            End If

            ' INFORME DIARIO

            Consulta_sql = My.Resources.Recurso_Vtas_Periodo.Informe_Ventas_x_Perido_Nivel_Documento
            Consulta_sql = Replace(Consulta_sql, "#Fecha_Inicio#", _Fecha_Dia)
            Consulta_sql = Replace(Consulta_sql, "#Fecha_Fin#", _Fecha_Dia)
            Consulta_sql = Replace(Consulta_sql, "#Nudonodefi#", _Nudonodefi)

            _Tbl_Inf_Diario = _SQL.Fx_Get_DataTable(Consulta_sql)

            For Each _Fila As DataRow In _Tbl_Inf_Diario.Rows
                Fx_Nueva_Linea_Venta(_Tbl_Diario, _Fila)
                _Total_Diario += _Fila.Item("MONTO")
            Next

            ' INFORME MENSUAL

            Consulta_sql = My.Resources.Recurso_Vtas_Periodo.Informe_Ventas_x_Perido_Nivel_Documento
            Consulta_sql = Replace(Consulta_sql, "#Fecha_Inicio#", _Fecha_Mes_Inicio)
            Consulta_sql = Replace(Consulta_sql, "#Fecha_Fin#", _Fecha_Mes_Fin)
            Consulta_sql = Replace(Consulta_sql, "#Nudonodefi#", _Nudonodefi)

            _Tbl_Inf_Mensual = _SQL.Fx_Get_DataTable(Consulta_sql)

            For Each _Fila As DataRow In _Tbl_Inf_Mensual.Rows
                Fx_Nueva_Linea_Venta(_Tbl_Mensual, _Fila)
                _Total_Mensual += _Fila.Item("MONTO")
            Next

            ' INFORME ANUAL

            Consulta_sql = My.Resources.Recurso_Vtas_Periodo.Informe_Ventas_x_Perido_Nivel_Documento
            Consulta_sql = Replace(Consulta_sql, "#Fecha_Inicio#", _Fecha_Ano_Inicio)
            Consulta_sql = Replace(Consulta_sql, "#Fecha_Fin#", _Fecha_Ano_Fin)
            Consulta_sql = Replace(Consulta_sql, "#Nudonodefi#", _Nudonodefi)

            _Tbl_Inf_Anual = _SQL.Fx_Get_DataTable(Consulta_sql)

            For Each _Fila As DataRow In _Tbl_Inf_Anual.Rows
                Fx_Nueva_Linea_Venta(_Tbl_Anual, _Fila)
                _Total_Anual += _Fila.Item("MONTO")
            Next

            ' INFORME GUIAS DIARIA

            Consulta_sql = My.Resources.Recurso_Vtas_Periodo.Informe_Guias_Generadas_Nivel_Detalle
            Consulta_sql = Replace(Consulta_sql, "#Fecha_Inicio#", _Fecha_Dia)
            Consulta_sql = Replace(Consulta_sql, "#Fecha_Fin#", _Fecha_Dia)

            If _Tbl_Configuracion_Filtros.Rows(0).Item("Rdb_Sucursales_Algunas") Then
                Dim _Fl = "DDO.SULIDO IN " & _Fl_Sucursal & " AND"
                Consulta_sql = Replace(Consulta_sql, "--#FILTRO_SUCURSALES#", _Fl)
            End If

            If _Tbl_Configuracion_Filtros.Rows(0).Item("Rdb_Super_Familia_Algunos") Then
                Dim _Fl = "DDO.KOPRCT IN (Select KOPR From MAEPR Where FMPR In " & _Fl_Super_Familia & ") AND"
                Consulta_sql = Replace(Consulta_sql, "--#FILTRO_SUPER_FAMILIA# ", _Fl)
            End If


            'Dim _Ds As DataSet = _SQL.Fx_Get_DataSet(Consulta_sql)

            Dim _Tbl_Inf_Guias_Diario = _SQL.Fx_Get_DataTable(Consulta_sql)

            For Each _Fila As DataRow In _Tbl_Inf_Guias_Diario.Rows
                Fx_Nueva_Linea_Guia(_Tbl_Guias_Diario, _Fila)
                _Total_Guias_Venta_Diario += _Fila.Item("MONTO")
                _Total_Guias_Costo_Diario += _Fila.Item("COSTO")
                _Guias_Diarias += _Fila.Item("GUIAS")
            Next

            ' INFORME GUIAS MENSUAL

            Consulta_sql = My.Resources.Recurso_Vtas_Periodo.Informe_Guias_Generadas_Nivel_Detalle
            Consulta_sql = Replace(Consulta_sql, "#Fecha_Inicio#", _Fecha_Mes_Inicio)
            Consulta_sql = Replace(Consulta_sql, "#Fecha_Fin#", _Fecha_Mes_Fin)



            Dim _Tbl_Inf_Guias_Mensual = _SQL.Fx_Get_DataTable(Consulta_sql)

            For Each _Fila As DataRow In _Tbl_Inf_Guias_Mensual.Rows
                Fx_Nueva_Linea_Guia(_Tbl_Guias_Mensual, _Fila)
                _Total_Guias_Venta_Mensual += _Fila.Item("MONTO")
                _Total_Guias_Costo_Mensual += _Fila.Item("COSTO")
                _Guias_Mensuales += _Fila.Item("GUIAS")
            Next



        Catch ex As Exception

        Finally
            If _Activar_Tiempo Then Tiempo_Espera.Enabled = True
        End Try

    End Sub

    Private Sub Fx_Nueva_Linea_Venta(ByVal _Tbl As DataTable, ByVal _Row_Datos As DataRow)

        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow
        With NewFila

            .Item("SUDO") = _Row_Datos.Item("SUDO")
            .Item("NOSUDO") = _Row_Datos.Item("NOSUDO")
            .Item("MONTO") = _Row_Datos.Item("MONTO")

            _Tbl.Rows.Add(NewFila)

        End With

    End Sub

    Private Sub Fx_Nueva_Linea_Venta(ByVal _Tbl As DataTable, ByVal _Monto As Double)

        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow
        With NewFila

            .Item("SUDO") = ""
            .Item("NOSUDO") = "TOTAL"
            .Item("MONTO") = _Monto

            _Tbl.Rows.Add(NewFila)

        End With

    End Sub

    Private Sub Fx_Nueva_Linea_Guia(ByVal _Tbl As DataTable, ByVal _Row_Datos As DataRow)

        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow
        With NewFila

            .Item("SUDO") = _Row_Datos.Item("SUDO")
            .Item("NOSUDO") = _Row_Datos.Item("NOKOSU")

            'Try
            '.Item("FEEMDO") = _Row_Datos.Item("FEEMDO")
            'Catch ex As Exception
            'End Try

            .Item("GUIAS") = _Row_Datos.Item("GUIAS")
            .Item("COSTO") = _Row_Datos.Item("COSTO")
            .Item("MARGEN") = _Row_Datos.Item("MARGEN")
            .Item("MARGEN_V") = _Row_Datos.Item("MARGEN_V")
            .Item("MONTO") = _Row_Datos.Item("MONTO")

            _Tbl.Rows.Add(NewFila)

        End With

    End Sub

    Private Sub Fx_Nueva_Linea_Guia(ByVal _Tbl As DataTable, _
                                    ByVal _Guias As Double, _
                                    ByVal _Costo As Double, _
                                    ByVal _Monto As Double)

        Dim _Margen = (_Monto - _Costo) / _Monto 'Math.Round((_Monto - _Costo) / _Monto, 3)
        Dim _Margen_v = _Monto - _Costo

        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow
        With NewFila

            .Item("SUDO") = ""
            .Item("NOSUDO") = "TOTAL"
            .Item("FEEMDO") = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)
            .Item("GUIAS") = _Guias
            .Item("MONTO") = _Monto
            .Item("COSTO") = _Costo
            .Item("MARGEN_V") = _Margen_v
            .Item("MARGEN") = _Margen

            _Tbl.Rows.Add(NewFila)

        End With

    End Sub

   
    Sub Sb_Formato_Grilla(ByVal _Grilla As DataGridView, Optional ByVal _Guias As Boolean = False)

        OcultarEncabezadoGrilla(_Grilla)

        If _Guias Then


            With _Grilla

                'SUDO,NOKOSU,FEEMDO,COUNT(TIDO) AS GUIAS,SUM(NETO) AS MONTO
                .Columns("SUDO").Width = 30 + 10
                .Columns("SUDO").HeaderText = "Suc."
                .Columns("SUDO").Visible = True

                .Columns("NOSUDO").Width = 150
                .Columns("NOSUDO").HeaderText = "Nombre Sucursal"
                .Columns("NOSUDO").Visible = True

                '.Columns("FEEMDO").Width = 100
                '.Columns("FEEMDO").HeaderText = "Fecha"
                '.Columns("FEEMDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns("GUIAS").Width = 40
                .Columns("GUIAS").HeaderText = "Cant."
                .Columns("GUIAS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("GUIAS").DefaultCellStyle.Format = "###,##"
                .Columns("GUIAS").Visible = True

                '.Columns("COSTO").Width = 100
                '.Columns("COSTO").HeaderText = "Costo"
                '.Columns("COSTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.Columns("COSTO").DefaultCellStyle.Format = "$ ###,##"
                '.Columns("COSTO").Visible = True

                .Columns("MONTO").Width = 100 + 10 + 10
                .Columns("MONTO").HeaderText = "Venta $"
                .Columns("MONTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("MONTO").DefaultCellStyle.Format = "$ ###,##"
                .Columns("MONTO").Visible = True

                .Columns("MARGEN_V").Width = 120
                .Columns("MARGEN_v").HeaderText = "Margen $"
                .Columns("MARGEN_V").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("MARGEN_V").DefaultCellStyle.Format = "$ ###,##"
                .Columns("MARGEN_v").Visible = True

                .Columns("MARGEN").Width = 60
                .Columns("MARGEN").HeaderText = "Margen %"
                .Columns("MARGEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("MARGEN").DefaultCellStyle.Format = "% ###,##.##"
                .Columns("MARGEN").Visible = True

            End With

        Else

            With _Grilla

                .Columns("SUDO").Width = 30 + 10
                .Columns("SUDO").HeaderText = "Suc."
                .Columns("SUDO").Visible = True

                .Columns("NOSUDO").Width = 160 + 20
                .Columns("NOSUDO").HeaderText = "Nombre Sucursal"
                .Columns("NOSUDO").Visible = True

                .Columns("MONTO").Width = 120 + 10
                .Columns("MONTO").HeaderText = "Total"
                .Columns("MONTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("MONTO").DefaultCellStyle.Format = "$ ###,##"
                .Columns("MONTO").Visible = True

            End With

        End If


    End Sub

    Sub Sb_Marcar_Linea(ByVal _Grilla As DataGridView)

        For Each _Fila As DataGridViewRow In _Grilla.Rows

            Dim _Sudo As String = _Fila.Cells("SUDO").Value

            If String.IsNullOrEmpty(_Sudo) Then

                '_Fila.Cells("MONTO").Style.Font = New Font("Courier New", 12, FontStyle.Bold)
                _Fila.DefaultCellStyle.Font = New Font("Courier New", 8, FontStyle.Bold)
                _Fila.DefaultCellStyle.BackColor = Color.LightGreen

            End If

        Next

    End Sub

    Sub Sb_RowsPostPaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
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
            MessageBox.Show(ex.Message, "vb.net", _
         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Tiempo_Espera_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tiempo_Espera.Tick
        Sb_Actualizar_Grillas()
    End Sub

    Private Sub BtnMinimizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMinimizar.Click
        Me.Close()
    End Sub

    Private Sub Frm_Informe_Gerencia_On_Line_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Dim _Tecla As Keys = e.KeyValue

        Select Case _Tecla
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                Sb_Actualizar_Grillas()
        End Select

    End Sub

    Private Sub Btn_Ver_Datos_Ano_Anterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Datos_Ano_Anterior.Click

        Tiempo_Espera.Enabled = False
        Progreso_Circular_Espera.IsRunning = False

        Dim Fm As New Frm_Informe_Gerencia_On_Line(_Tbl_Conexiones, True)
        Fm.Pro_Top = Me.Top
        Fm.Pro_Left = Me.Left
        Fm.Pro_Fecha_Informe = DateAdd(DateInterval.Year, -1, _Fecha_Informe)
        Fm.Pro_Tiempor_Espera = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Tiempo_Espera.Enabled = _Activar_Tiempo
        Progreso_Circular_Espera.IsRunning = _Activar_Tiempo

    End Sub

    Private Sub Btn_Cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cerrar.Click
        Me.Close()
    End Sub

    Private Sub Btn_Ver_Datos_Otra_Fecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Datos_Otra_Fecha.Click

        Tiempo_Espera.Enabled = False
        Progreso_Circular_Espera.IsRunning = False

        Dim _Fecha_Informe As Date
        Dim _Aceptar As Boolean

        Dim _Fm As New Frm_Informe_Gerencia_On_Line_Ingresar_Fecha
        _Fm.Pro_Dtp_Fecha_informe = Now.Date
        _Fm.ShowDialog(Me)
        _Fecha_Informe = _Fm.Pro_Dtp_Fecha_informe
        _Aceptar = _Fm.Pro_Aceptar
        _Fm.Dispose()

        If _Aceptar Then

            Dim Fm As New Frm_Informe_Gerencia_On_Line(_Tbl_Conexiones, True)
            Fm.Pro_Top = Me.Top
            Fm.Pro_Left = Me.Left
            Fm.Pro_Fecha_Informe = _Fecha_Informe
            Fm.Pro_Tiempor_Espera = False
            Fm.Text = "INFORME DE VENTAS ON - LINE (OTRA FECHA): " & FormatDateTime(_Fecha_Informe, DateFormat.ShortDate)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

        Tiempo_Espera.Enabled = _Activar_Tiempo
        Progreso_Circular_Espera.IsRunning = _Activar_Tiempo


    End Sub

    Sub Sb_Filtro_Super_Familias()

        Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado( _
        Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Super_Familia, _
        Frm_Tabla_Caracterizaciones_01_Listado.Accion.Seleccionar)

        'Fm.Pro_TblFilasSeleccionadas

        Fm.Text = "Seleccionar Super Familia"
        Fm.ShowDialog(Me)
        If Not (Fm.Pro_RowFilaSeleccionada Is Nothing) Then

            Dim _CodMaquina = Fm.Pro_RowFilaSeleccionada.Item("CodigoTabla")
            '_Row_Encabezado.Item("CodMaquina") = _CodMaquina
            'Sb_Actualizar_Txt()

        End If
        Fm.Dispose()

    End Sub
  
    Private Sub Btn_Filtro_Super_Familia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro_Super_Familia.Click

        Tiempo_Espera.Enabled = False
        Progreso_Circular_Espera.IsRunning = False

        Dim _Row_Conexion As DataRow
        Dim Fm As New Frm_Seleccion_Empresas(Frm_Seleccion_Empresas.Enum_Accion.Seleccionar)
        Fm.ShowDialog(Me)
        _Row_Conexion = Fm.Pro_Row_Conexion
        Fm.Dispose()

        Dim _Ds_Inf_Ventas_OnLine_Filtros As New Ds_Inf_Ventas_OnLine

        If Not (_Row_Conexion Is Nothing) Then

            Dim _NombreConexion = _Row_Conexion.Item("NombreConexion")

            Dim Fm_Fl As New Frm_Informe_Gerencia_On_Line_Filtros(_NombreConexion)
            Fm_Fl.Text = "Filtros Informe Ventas  On-Line (" & _NombreConexion & ")"
            Fm_Fl.ShowDialog(Me)
            Fm_Fl.Dispose()

        End If

        Tiempo_Espera.Enabled = _Activar_Tiempo
        Progreso_Circular_Espera.IsRunning = _Activar_Tiempo


    End Sub

 
End Class