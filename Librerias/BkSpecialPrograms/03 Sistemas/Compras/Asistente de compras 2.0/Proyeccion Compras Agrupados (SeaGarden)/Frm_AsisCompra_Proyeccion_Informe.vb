'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Imports System.Reflection
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.SuperGrid.Style
Imports System.Collections.Generic
Imports System.Drawing

Public Class Frm_AsisCompra_Proyeccion_Informe

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Ds_Informe As DataSet

    Dim _HitColumn As GridColumn

    Dim _TblInforme As DataTable
    Dim _TblInforme_Detalle As DataTable
    Dim _TblInforme_Detalle_Nivel_Producto As DataTable
    Dim _TblInforme_Totales As DataTable

    ' Formato de colores para las grillas
    Private _Background1 As New Background(Color.White, Color.FromArgb(238, 244, 251), 45)
    Private _Background2 As New Background(Color.FromArgb(249, 249, 234))
    Private _Background3 As New Background(Color.FromArgb(255, 247, 250))

    Private _Background1_Black As New Background(Color.Black)
    Private _Background2_Black As New Background(Color.Black)
    Private _Background3_Black As New Background(Color.Black)

    Dim _Grilla_Activa As String
    Dim _Panel_Activo As GridPanel

    Dim _Ud As Integer

    Dim _Proyeccion As Enum_Proyeccion
    Dim _Fecha_Servidor As Date
    Dim _Clas_Asistente_Compras As Clas_Asistente_Compras

    Enum Enum_Proyeccion
        Diaria
        Semanal
        Mensual
    End Enum

    Dim _Tabla_Paso As String

    Dim _Identificador_NodoPadre As String
    Dim _Filtro_Nodos As String
    Dim _Porc_Creciminto As Integer
    Dim _Dias_Proyeccion As Integer
    Dim _Marca_Proyeccion As Integer
    Dim _Dias_Abastecer As Integer
    Dim _Campos As Integer

    Dim _Row_Nodo As DataRow

    Dim _Tiempo_Reposicion As Integer

    Dim _RotCalculo As String
    Dim _Sql_Consulta_Actualiza_Stock As String

    Public Property Pro_Proyeccion() As Enum_Proyeccion
        Get
            Return _Proyeccion
        End Get
        Set(value As Enum_Proyeccion)
            _Proyeccion = value
        End Set
    End Property
    Public Property Pro_Input_Redondeo() As Integer
        Get
            Return Input_Redondeo.Value
        End Get
        Set(value As Integer)
            Input_Redondeo.Value = value
        End Set
    End Property

    Public Sub New(Tabla_Paso As String,
                   Identificador_NodoPadre As String,
                   Ud As Integer,
                   Filtro_Nodos As String,
                   Porc_Creciminto As Integer,
                   Dias_Proyeccion As Integer,
                   Marca_Proyeccion As Integer,
                   Dias_Abastecer As Integer,
                   Campos As Integer,
                   RotCalculo As String,
                   Sql_Consulta_Actualiza_Stock As String,
                   ByRef Clas_Asistente_Compras As Clas_Asistente_Compras)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        '_TblInforme = TblInforme
        '_TblInforme_Detalle = TblInforme_Detalle

        _Clas_Asistente_Compras = Clas_Asistente_Compras

        _Tabla_Paso = Tabla_Paso
        _Identificador_NodoPadre = Identificador_NodoPadre
        _Ud = Ud
        _Filtro_Nodos = Filtro_Nodos
        _Porc_Creciminto = Porc_Creciminto
        _Dias_Proyeccion = Dias_Proyeccion
        _Marca_Proyeccion = Marca_Proyeccion
        _Dias_Abastecer = Dias_Abastecer
        _Campos = Campos
        _RotCalculo = RotCalculo
        _Sql_Consulta_Actualiza_Stock = Sql_Consulta_Actualiza_Stock

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_AsisCompra_Proyeccion_Informe_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                       "Where Codigo_Nodo = " & _Identificador_NodoPadre
        _Row_Nodo = _Sql.Fx_Get_DataRow(Consulta_sql)

        Sb_Initialize_Grid()
        Sb_Actualizar_SuperGrid()

        Me.WindowState = FormWindowState.Maximized

        AddHandler Rdb_Proyeccion_Rotacion_Diaria.CheckedChanged, AddressOf Sb_Rdb_Rotacion_CheckedChanged
        AddHandler Rdb_Proyeccion_Promedio_Diario.CheckedChanged, AddressOf Sb_Rdb_Rotacion_CheckedChanged

        Lbl_VerdeClaro.BackColor = Color.FromArgb(146, 208, 80)
        Lbl_VerdeOscuro.BackColor = Color.FromArgb(0, 128, 0)
        Lbl_Amarillo.BackColor = Color.FromArgb(255, 255, 0)
        Lbl_Blanco.BackColor = Color.White
        Lbl_Rosado.BackColor = Color.FromArgb(255, 182, 193)

    End Sub

    Private Sub Sb_Initialize_Grid()

        Dim panel As GridPanel = Super_Grilla.PrimaryGrid

        panel.Name = "Informe"
        panel.ShowToolTips = True

        panel.MinRowHeight = 20
        panel.AutoGenerateColumns = True

        If Global_Thema = Enum_Themas.Oscuro Then
            panel.DefaultVisualStyles.GroupByStyles.Default.Background = _Background1_Black
        Else
            panel.DefaultVisualStyles.GroupByStyles.Default.Background = _Background1
        End If

        panel.SelectionGranularity = SelectionGranularity.Cell

        AddHandler Super_Grilla.CellValueChanged, AddressOf SuperGridControl1CellValueChanged
        AddHandler Super_Grilla.GetCellStyle, AddressOf SuperGridControl1GetCellStyle
        AddHandler Super_Grilla.DataBindingComplete, AddressOf SuperGridControl1DataBindingComplete

        AddHandler Super_Grilla.SelectionChanged, AddressOf SuperGridControl1SelectionChanged

    End Sub

    Function Fx_Generar_Informe_Ds() As DataSet

        Dim _Ds_Proyecto As DataSet

        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Proyeccion_Compras_30_60_120
        Consulta_sql = Replace(Consulta_sql, "#TablaPaso#", _Tabla_Paso)
        Consulta_sql = Replace(Consulta_sql, "#Tbl_BakApp#", _Global_BaseBk)
        Consulta_sql = Replace(Consulta_sql, "#Ud#", _Ud)

        Consulta_sql = Replace(Consulta_sql, "#Filtro_Nodos#", _Filtro_Nodos)

        Consulta_sql = Replace(Consulta_sql, "#Identificador_NodoPadre#", _Identificador_NodoPadre)
        Consulta_sql = Replace(Consulta_sql, "#Porc_Creciminto#", _Porc_Creciminto)
        Consulta_sql = Replace(Consulta_sql, "#Dias_Proyeccion#", _Dias_Proyeccion)
        Consulta_sql = Replace(Consulta_sql, "#Marca_Proyeccion#", _Marca_Proyeccion)
        Consulta_sql = Replace(Consulta_sql, "#Dias_Abastecer#", _Dias_Abastecer)

        '_Identificador_NodoPadre
        '_Porc_Creciminto
        '_Dias_Proyeccion
        '_Marca_Proyeccion
        '_Dias_Abastecer


        Dim _Sql_Campos_Proyeccion = String.Empty
        Dim _Sql_Update_Campo_Proyeccion = String.Empty

        Dim _MesActual = _Fecha_Servidor.Month
        Dim _YearActual = _Fecha_Servidor.Year

        For _i = 1 To _Campos 'Input_Cant_Campos.Value

            Dim _Campo = numero_(_i, 2) & "_P"
            'Dim _Campo2 = numero_(_i, 2) & "_P" & "_" & numero_(_MesActual, 2) & "_" & _YearActual

            _Sql_Campos_Proyeccion += "CAST('' As Char(1)) As '" & _Campo & "'," & vbCrLf
            _Sql_Update_Campo_Proyeccion +=
            "Update #Tbl_Paso_Proyecto_01 Set [" & _Campo & "] = Case When Duracion_Proyeccion >= " & _i & " Then " & vbCrLf &
            "Case When @Marca_Proyeccion < " & _i & " Then 'O' Else 'X' End Else '-' end" & vbCrLf &
            "-------" & vbCrLf

            _MesActual += 1
            If _MesActual = 13 Then
                _MesActual = 1
                _YearActual += 1
            End If

        Next

        Consulta_sql = Replace(Consulta_sql, "#Campos_Proyeccion#", _Sql_Campos_Proyeccion)
        Consulta_sql = Replace(Consulta_sql, "#Update_Campos_Proyeccion#", _Sql_Update_Campo_Proyeccion)

        If Rdb_Proyeccion_Rotacion_Diaria.Checked Then _RotCalculo = "D"
        If Rdb_Proyeccion_Promedio_Diario.Checked Then _RotCalculo = "P"

        Consulta_sql = Replace(Consulta_sql, "#RotCalculo#", _RotCalculo)

        _Ds_Proyecto = _Sql.Fx_Get_DataSet(Consulta_sql)

        Return _Ds_Proyecto

    End Function

    Sub Sb_Actualizar_SuperGrid()

        Dim Fm_Espera = New Frm_Form_Esperar
        Fm_Espera.BarraCircular.IsRunning = True
        Fm_Espera.Show()

        _Fecha_Servidor = FechaDelServidor()

        _Ds_Informe = Fx_Generar_Informe_Ds()

        Me.Text = "Informe de proyección de compras a nivel: " & _Proyeccion.ToString

        _TblInforme_Detalle = _Ds_Informe.Tables(0)
        _TblInforme = _Ds_Informe.Tables(1)
        _TblInforme_Detalle_Nivel_Producto = _Ds_Informe.Tables(2)
        _TblInforme_Totales = _Ds_Informe.Tables(3)

        _Ds_Informe.Relations.Add("1",
                                    _Ds_Informe.Tables("Table1").Columns("Codigo_Nodo"),
                                     _Ds_Informe.Tables("Table").Columns("Codigo_Nodo"), False)

        _Ds_Informe.Relations.Add("2",
                                  _Ds_Informe.Tables("Table").Columns("Codigo"),
                                  _Ds_Informe.Tables("Table2").Columns("Codigo"), False)

        Super_Grilla.PrimaryGrid.DataSource = _Ds_Informe
        Super_Grilla.PrimaryGrid.DataMember = "Table1"

        Fm_Espera.Close()

    End Sub

    Sub Sb_Marcar_Super_Grilla(_Grilla As GridPanel)

        _Fecha_Servidor = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)

        Dim _Cell As GridCell

        For Each _Fila As GridRow In _Grilla.Rows

            Dim _Cant_Comprar_Sug As Double = _Fila.Cells("Cant_Comprar_Sug").Value

            Dim _Redondeo As Double = Math.Round(_Cant_Comprar_Sug / Input_Redondeo.Value, 1)
            Dim _Redondeo_C = Math.Ceiling(_Redondeo)

            _Cant_Comprar_Sug = _Redondeo_C * Input_Redondeo.Value

            _Fila.Cells("Cant_Comprar_Sug_Red").Value = _Cant_Comprar_Sug

            Dim _RotCalculo = _Fila.Cells("RotCalculo").Value

            Dim _Stock_Asegurado_Proyeccion = _Fila.Cells("Stock_Asegurado_Proyeccion").Value
            Dim _Duracion_Proyeccion = _Fila.Cells("Duracion_Proyeccion").Value
            Dim _Duracion_Proyeccion_Recepcion = _Fila.Cells("Duracion_Proyeccion_Recepcion").Value
            Dim _Proyeccion_Abastecer = _Fila.Cells("Proyeccion_Abastecer").Value

            Dim _Codigo_Nodo_Padre = _Fila.Cells("Codigo_Nodo").Value
            Dim _Producto = _Fila.Cells("Producto").Value

            Dim _StockUd As Double = _Fila.Cells("StockUd" & _Ud).Value
            Dim _StockPedidoUd As Double = _Fila.Cells("StockPedidoUd" & _Ud).Value
            Dim _StockFacSinRecepUd As Double = _Fila.Cells("StockFacSinRecepUd" & _Ud).Value

            If _Codigo_Nodo_Padre = 1504 Or (_StockUd + _StockPedidoUd + _StockFacSinRecepUd) <= 0 Or _RotCalculo = 0 Then '9790 Then
                Dim a = True
            End If

            Dim _MesActual = _Fecha_Servidor.Month
            Dim _YearActual = _Fecha_Servidor.Year

            For _i = 1 To _Campos '_Stock_Asegurado_Proyeccion

                Dim _Cmp = numero_(_i, 2) & "_P"
                'Dim _Cmp2 = _Cmp & "_" & numero_(_Fecha_Servidor.Month, 2) & "_" & _Fecha_Servidor.Year
                'Dim _Campo2 = numero_(_i, 2) & "_P" & "_" & numero_(_MesActual, 2) & "_" & _YearActual

                _Cell = _Fila.GetCell(_Cmp)

                If _i <= _Stock_Asegurado_Proyeccion Or (_RotCalculo = 0 And _StockUd > 0) Then 'Color.Green
                    _Cell.Value = "A"
                Else
                    If _i <= _Duracion_Proyeccion Then
                        _Cell.Value = "S"
                    ElseIf _i <= _Proyeccion_Abastecer Then
                        If Not _Cell.CellStyles.Default.Background.Color1 = Color.GreenYellow Then
                            _Cell.Value = "P"
                        End If
                    End If
                End If

                _MesActual += 1
                If _MesActual = 13 Then
                    _MesActual = 1
                    _YearActual += 1
                End If

                If _i = _Campos Then Exit For

            Next

            For Each _Fila_Detalle As DataRow In _TblInforme_Detalle.Rows

                Dim _Codigo_Nodo_Hijo = _Fila_Detalle.Item("Codigo_Nodo")
                Dim _Codigo_Nodo_Madre = _Fila_Detalle.Item("Codigo_Nodo_Madre")

                If _Codigo_Nodo_Padre = _Codigo_Nodo_Hijo Then

                    Dim _Idmaeedo = _Fila_Detalle.Item("Idmaeedo")
                    Dim _Mes_Actual = Month(Now.Date)

                    If CBool(_Idmaeedo) Then

                        If _Codigo_Nodo_Padre = 90 Or _Codigo_Nodo_Madre = "NACIO01" Then '9790 Then
                            Dim a = True
                        End If

                        Dim _Duracion As Integer

                        If _Duracion_Proyeccion >= _Duracion_Proyeccion_Recepcion Then
                            _Duracion = _Duracion_Proyeccion
                        Else
                            _Duracion = _Duracion_Proyeccion_Recepcion
                        End If

                        Dim _ValV = "V"

                        Dim _Fecha_Recepcion As Date = _Fila_Detalle.Item("Fecha_Recep")
                        Dim _MesRecep = _Fecha_Recepcion.Month ' Month(_Fecha_Recepcion)
                        Dim _YearRecep = _Fecha_Recepcion.Year ' Month(_Fecha_Recepcion)

                        _MesActual = _Fecha_Servidor.Month
                        _YearActual = _Fecha_Servidor.Year

                        If _YearRecep < _YearActual Then
                            _ValV = "R"
                        Else
                            If _MesRecep < _MesActual And _YearActual = _YearRecep Then
                                _ValV = "R"
                            End If
                        End If

                        If _Duracion = 0 And _ValV = "R" Then
                            _Duracion = 1
                        End If

                        Dim _Mm As Integer = 0

                        Dim _Sigue_Revisando = True
                        Dim _Mes_Consulta As Integer = _Mes_Actual

                        Do While _Sigue_Revisando

                            If _Mes_Consulta <> _MesRecep Then
                                _Mm += 1
                            Else
                                _Sigue_Revisando = False
                            End If

                            _Mes_Consulta += 1

                            If _Mes_Consulta = 13 Then _Mes_Consulta = 1

                        Loop

                        Dim _Salir = False

                        If _Mm < 0 Then
                            _Mm = 0
                        End If

                        Dim _Cmp

                        For _i = 1 To _Duracion_Proyeccion

                            Select Case _Proyeccion
                                Case Enum_Proyeccion.Diaria
                                    _Mm = 0
                                Case Enum_Proyeccion.Semanal
                                Case Enum_Proyeccion.Mensual
                            End Select

                            _Cmp = numero_(_i + _Mm, 2)

                            'Dim _Campo22 = numero_(_i, 2) & "_P" & "_" & numero_(_MesActual, 2) & "_" & _YearActual
                            Dim _Cmp2var1 = _Cmp & "_" & numero_(_Fecha_Servidor.Month, 2) & "_" & _Fecha_Servidor.Year

                            Dim _Cmp2Var = Split(_Cmp2var1, "_")


                            'If Val(_Cmp2Var(2)) > _Fecha_Servidor.Year Then
                            '    _ValV = "R"
                            'End If

                            If CInt(_Cmp) = 13 Then
                                Exit For
                            End If

                            Dim _Cell_Cmp = _Cmp & "_P"

                            'RESCATAMOS LA CELDA QUE NOS INTERESA
                            _Cell = _Fila.GetCell(_Cell_Cmp)

                            Dim _Valor = _Cell.Value

                            If _Valor <> "A" Then

                                For _ii = 1 To _Duracion_Proyeccion_Recepcion
                                    If _Cmp >= 13 Or _ii > _Duracion_Proyeccion Then
                                        Exit For
                                    End If
                                    _Cell = _Fila.GetCell(_Cell_Cmp)
                                    _Cell.Value = _ValV '"V"
                                    _Cmp = numero_(_i + _ii + _Mm, 2)
                                    _Cell_Cmp = _Cmp & "_P"

                                    Dim _Name = _Cell.GridColumn.Name

                                Next

                                _Salir = True

                            End If

                            If _Salir Then Exit For

                        Next

                        Dim _P = _Producto

                    End If

                End If

            Next

        Next

        'Return

        'For Each _Fila As GridRow In _Grilla.Rows

        '    Dim _CodigoNodo = _Fila.Cells("Codigo_Nodo").Value

        '    Dim _RotCalculo = Math.Round(_Fila.Cells("RotCalculo").Value, 0)
        '    Dim _StockUd = Math.Round(_Fila.Cells("StockUd" & _Ud).Value, 0)
        '    Dim _StockPedidoUd = Math.Round(_Fila.Cells("StockPedidoUd" & _Ud).Value, 0)
        '    Dim _StockFacSinRecepUd = Math.Round(_Fila.Cells("StockFacSinRecepUd" & _Ud).Value, 0)

        '    Dim _Producto = _Fila.Cells("Producto").Value

        '    Consulta_sql = "Select KOPRCT As Codigo,IDMAEEDO,TIDO,NUDO,ENDO,SUENDO,(Select Top 1 NOKOEN From MAEEN Where KOEN+SUEN = ENDO+SUENDO) As Razon," &
        '                   "UD01PR,CAPRCO1,CAPREX1,(CAPRCO1-(CAPRAD1+CAPREX1)) As Saldo, FEERLI " &
        '                   "From MAEDDO" & vbCrLf &
        '                   "Where KOPRCT  In (SELECT Codigo FROM " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo_Nodo = '" & _CodigoNodo & "') And" & vbCrLf &
        '                   "TIDO In ('OCC','FCC') And ESLIDO = '' " & vbCrLf &
        '                   "Order By FEERLI Desc"

        '    Dim _Tbl_Detalle As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        '    For Each _Row As DataRow In _Tbl_Detalle.Rows

        '        Dim _Idmaeedo = NuloPorNro(_Row.Item("IDMAEEDO"), 0)

        '        If CBool(_Idmaeedo) Then

        '            Dim _Tido = Trim(_Row.Item("TIDO"))
        '            Dim _Nudo = _Row.Item("NUDO")
        '            Dim _Fecha_Recep As Date

        '            If CBool(_StockPedidoUd) Then

        '                _Cell = _Fila.GetCell("StockPedidoUd" & _Ud)

        '                If _Tido = "OCC" Then

        '                    _Fecha_Recep = FormatDateTime(_Row.Item("FEERLI"), DateFormat.ShortDate)

        '                    If _Fecha_Recep < _Fecha_Servidor Then
        '                        _Cell.CellStyles.Default.Background.Color1 = Color.White
        '                        _Cell.CellStyles.Default.Background.Color2 = Color.LightPink
        '                    Else
        '                        _Cell.CellStyles.Default.Background.Color1 = Color.White
        '                        _Cell.CellStyles.Default.Background.Color2 = Color.LightGreen
        '                    End If

        '                End If

        '            End If

        '            If CBool(_StockFacSinRecepUd) Then

        '                If _Tido = "FCC" Then

        '                    _Cell = _Fila.GetCell("StockFacSinRecepUd" & _Ud)

        '                    _Fecha_Recep = FormatDateTime(_Row.Item("FEERLI"), DateFormat.ShortDate)

        '                    If _Fecha_Recep < _Fecha_Servidor Then
        '                        '_Cell.CellStyles.Default.TextColor = Color.Red
        '                        '_Fila.Cells("StockFacSinRecepUd" & _Ud).Style.ForeColor = Color.Red
        '                        '_Fila.Cells("StockFacSinRecepUd" & _Ud).CellStyles.Default.TextColor = Color.Red
        '                        '_Fila.Cells("StockFacSinRecepUd" & _Ud).CellStyles.Item(StyleType.Default).TextColor = Color.Red
        '                        _Cell.CellStyles.Default.Background.Color1 = Color.White
        '                        _Cell.CellStyles.Default.Background.Color2 = Color.LightPink
        '                    Else
        '                        '_Cell.CellStyles.Default.TextColor = Color.Green
        '                        '_Fila.Cells("StockFacSinRecepUd" & _Ud).Style.ForeColor = Color.Green
        '                        ' _Fila.Cells("StockFacSinRecepUd" & _Ud).CellStyles.Default.TextColor = Color.Green
        '                        '_Fila.Cells("StockFacSinRecepUd" & _Ud).CellStyles.Item(StyleType.Default).TextColor = Color.Green
        '                        _Cell.CellStyles.Default.Background.Color1 = Color.White
        '                        _Cell.CellStyles.Default.Background.Color2 = Color.LightGreen
        '                    End If
        '                    'Else
        '                    '   _Fila.Cells("StockFacSinRecepUd" & _Ud).Style.ForeColor = Color.Red
        '                End If

        '            End If

        '        End If

        '    Next


        '    If Not CBool(_RotCalculo) Then

        '        For _i = 1 To _Campos ' _Stock_Asegurado_Proyeccion

        '            Dim _Cmp = numero_(_i, 2)

        '            _Cell = _Fila.GetCell(_Cmp)

        '            If CBool(_StockUd) Then
        '                _Cell.CellStyles.Default.Background.Color1 = Color.Green
        '                _Cell.CellStyles.Default.Background.Color2 = Color.Green
        '                '_Fila.Cells(_Cmp).Style.BackColor = Color.Green
        '            ElseIf CBool(_StockPedidoUd) Or CBool(_StockFacSinRecepUd) Then
        '                '_Fila.Cells(_Cmp).Style.BackColor = Color.GreenYellow
        '                _Cell.CellStyles.Default.Background.Color1 = Color.GreenYellow
        '                _Cell.CellStyles.Default.Background.Color2 = Color.GreenYellow
        '            End If

        '            If _i = _Campos Then Exit For

        '        Next

        '    End If

        '    ' INCORPORAR CAMPO Tendencia

        '    Dim _Tendencia = _Fila.Cells("Tendencia").Value

        '    If CBool(_Tendencia) Then

        '        _Cell = _Fila.GetCell("Tendencia")

        '        If _Tendencia < 0 Then
        '            _Cell.CellStyles.Default.Background.Color1 = Color.White
        '            _Cell.CellStyles.Default.Background.Color2 = Color.LightPink
        '            '_Cell.CellStyles.[Default].TextColor = Color.Red
        '        Else
        '            _Cell.CellStyles.Default.Background.Color1 = Color.White
        '            _Cell.CellStyles.Default.Background.Color2 = Color.LightGreen
        '            '_Cell.CellStyles.[Default].TextColor = Color.Green
        '        End If

        '    End If

        'Next

        'Me.Refresh()

    End Sub

    Private Sub Btn_Actualizar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Actualizar.Click
        Sb_Actualizar_SuperGrid()
    End Sub

    Sub Sb_Revisar_Info_Producto(_Fila As Object)

        Dim _FilTro_Nodos = "(" & _Fila.Cells("Codigo_Nodo").Value & ")"

        Dim _Tabla_Paso As String = "Zw_InfCompras01" & FUNCIONARIO

        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Proyeccion_Compras_30_60_120
        Consulta_sql = Replace(Consulta_sql, "#TablaPaso#", _Tabla_Paso)
        Consulta_sql = Replace(Consulta_sql, "#Tbl_BakApp#", _Global_BaseBk)
        Consulta_sql = Replace(Consulta_sql, "#Ud#", _Ud)

        Consulta_sql = Replace(Consulta_sql, "#Filtro_Nodos#", _FilTro_Nodos)

        Consulta_sql = Replace(Consulta_sql, "#Identificador_NodoPadre#", 0) '_Identificador_NodoPadre)
        Consulta_sql = Replace(Consulta_sql, "#Porc_Creciminto#", _Porc_Creciminto)
        Consulta_sql = Replace(Consulta_sql, "#Dias_Proyeccion#", _Dias_Proyeccion)
        Consulta_sql = Replace(Consulta_sql, "#Marca_Proyeccion#", _Marca_Proyeccion)
        Consulta_sql = Replace(Consulta_sql, "#Dias_Abastecer#", _Dias_Abastecer)

        Dim _Sql_Campos_Proyeccion = String.Empty
        Dim _Sql_Update_Campo_Proyeccion = String.Empty

        For _i = 1 To _Campos

            Dim _Campo = numero_(_i, 2)

            _Sql_Campos_Proyeccion += "CAST('' As Char(1)) As '" & _Campo & "'," & vbCrLf
            _Sql_Update_Campo_Proyeccion +=
            "Update #Tbl_Paso_Proyecto_01 Set [" & _Campo & "] = Case When Duracion_Proyeccion >= " & _i & " Then " & vbCrLf &
            "Case When @Marca_Proyeccion < " & _i & " Then 'O' Else 'X' End Else '-' end" & vbCrLf &
            "-------" & vbCrLf

        Next

        Consulta_sql = Replace(Consulta_sql, "#Campos_Proyeccion#", _Sql_Campos_Proyeccion)
        Consulta_sql = Replace(Consulta_sql, "#Update_Campos_Proyeccion#", _Sql_Update_Campo_Proyeccion)

        Consulta_sql = Replace(Consulta_sql, "#RotCalculo#", _RotCalculo)

        Dim _Ds_Proyecto As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        Dim _Rotacion_Diaria As Double = _Fila.Cells("RotCalculo").Value
        Dim _Stock_Critico As Double = _Fila.Cells("Stock_CriticoUd" & _Ud & "_Rd").Value '_Fila.Cells("Stock_CriticoUd" & _Ud).Value

        ' Dim Fm As New Frm_AsisCompra_Proyeccion_Detalle(_Ds_Proyecto, _Ud, _Rotacion_Diaria, _Stock_Critico)
        ' Fm.ShowDialog(Me)
        ' Fm.Dispose()

    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Exportar_Excel.Click
        ExportarTabla_JetExcel_Tabla(_TblInforme, Me, "Proyección Compras")
    End Sub

    Private Sub Btn_Informe_Proximas_Recepciones_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Informe_Proximas_Recepciones.Click
        If Fx_Tiene_Permiso(Me, "Inc00003") Then
            Dim Fm As New Frm_Informe_Proximas_Recepiones
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Sb_Grilla_ColumnHeaderMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        Try
            Me.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            'Sb_Marcar_Grilla()
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message)
        Finally
            Me.Enabled = True
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub Btn_Estadisticas_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Estadisticas_Producto.Click

        'Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Fila As GridRow = TryCast(Super_Grilla.ActiveRow, GridRow)

        'Dim _Codigo As String = _Fila.Cells("Codigo").Value
        'Dim _Descripcion As String = _Fila.Cells("Descripcion").Value


        ''_Clas_Asistente_Compras.Pro_Rdb_Agrupar_x_Asociados = Rdb_Agrupar_x_Asociados.Checked

        'Dim _Ud As Integer
        'If _Clas_Asistente_Compras.Pro_Rdb_Ud1_Compra Then : _Ud = 1 : Else : _Ud = 2 : End If

        '_Clas_Asistente_Compras.Sb_Info_Calculo_Rotacion(Me, _Codigo, _Descripcion, _Ud)

        'Return


        Dim _Fecha_Ref_Inicio As Date = DateAdd(DateInterval.Year, -1, _Fecha_Servidor)
        Dim _Fecha_Ref_Fin As Date = _Fecha_Servidor

        Dim _Codigo As String = _Fila.Cells("Codigo").Value
        Dim _Codigo_Nodo_Madre As String = _Fila.Cells("Codigo_Nodo_Madre").Value

        Consulta_sql = "Select Top 1 * From " & _Clas_Asistente_Compras.Pro_Nombre_Tbl_Paso_Informe & vbCrLf &
                       "Where Codigo_Nodo_Madre = '" & _Codigo_Nodo_Madre & "' --And Es_Agrupador = 1"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)


        Dim _Fecha_Inicio As Date = NuloPorNro(_Row.Item("Fecha_Inicio"), _Fecha_Ref_Inicio)
        Dim _Fecha_Fin As Date = NuloPorNro(_Row.Item("Fecha_Fin"), _Fecha_Ref_Fin)

        If _Fecha_Fin > _Fecha_Ref_Fin Then _Fecha_Fin = _Fecha_Ref_Fin

        Dim _Stock_Critico As Double

        Dim _Ud As Integer
        If _Clas_Asistente_Compras.Pro_Rdb_Ud1_Compra Then : _Ud = 1 : Else : _Ud = 2 : End If

        _Stock_Critico = _Row.Item("Stock_CriticoUd" & _Ud & "_Rd")

        Consulta_sql = "Select Codigo From " & _Clas_Asistente_Compras.Pro_Nombre_Tbl_Paso_Informe & vbCrLf &
                       "Where Codigo_Nodo_Madre = '" & _Codigo_Nodo_Madre & "'"
        Dim _Tbl_Productos_Hermanos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim Fm As New Frm_EstadisticaProducto(_Codigo)

        Fm.Pro_Tbl_Productos_Hermanos = _Tbl_Productos_Hermanos
        Fm.Pro_Agrupar_Reemplazos = True
        Fm.Pro_Filtro_Bodegas_Todas = _Clas_Asistente_Compras.Pro_Filtro_Bodegas_Todas
        Fm.Pro_Tbl_Filtro_Bodegas = _Clas_Asistente_Compras.Pro_Tbl_Filtro_Bodegas
        Fm.Pro_Incluir_Analisi_Con_Ent_Excluidas = _Clas_Asistente_Compras.Pro_Chk_Rotacion_Con_Ent_Excluidas
        Fm.Input_Stock_Minimo.Enabled = False
        Fm.Pro_Stock_Critico = _Stock_Critico
        Fm.Pro_Fecha_Moviminetos_Stock_Desde = _Fecha_Inicio
        Fm.Pro_Fecha_Moviminetos_Stock_Hasta = _Fecha_Fin
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Actualizar_Rotacion_Producto_Actual_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Actualizar_Rotacion_Producto_Actual.Click

        Dim _Fila As GridRow = TryCast(Super_Grilla.ActiveRow, GridRow)

        Dim _Codigo_Nodo = _Fila.Cells("Codigo_Nodo").Value
        Dim _Es_Agrupador = 1

        Consulta_sql = "Select Distinct Codigo," &
                       "(Select Top 1 NOKOPR From MAEPR Where KOPR = Codigo) As Descripcion" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                       "Where Codigo_Nodo = '" & _Codigo_Nodo & "'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim Fm As New Frm_Rotacion_Selec_Prod_Parametros
        Fm.Pro_Tbl_Productos_Seleccionados = _Tbl
        Fm.Chk_Incluir_Ventas_Entidades_Excluidas.Checked = _Clas_Asistente_Compras.Pro_Chk_Rotacion_Con_Ent_Excluidas
        Fm.Chk_Incluir_Ventas_Entidades_Excluidas.Enabled = False
        Fm.Pro_Input_Dias_Advertencia_Rotacion = _Clas_Asistente_Compras.Pro_Input_Dias_Advertencia_Rotacion
        Fm.Pro_Chk_Advertir_Rotacion = _Clas_Asistente_Compras.Pro_Chk_Advertir_Rotacion
        Fm.ShowDialog(Me)

        If Fm.Pro_Informe_Procesado Then
            _Clas_Asistente_Compras.Sb_Actualizar_Stock(False)
            _Clas_Asistente_Compras.Sb_Actualizar_Rotacion("", True)
            Sb_Actualizar_SuperGrid()
        End If

    End Sub

    Private Sub Btn_Infor_Rotacion_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Infor_Rotacion.Click

        'Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Fila As GridRow = TryCast(Super_Grilla.ActiveRow, GridRow)

        Dim _Codigo_Nodo_Madre As String = _Fila.Cells("Codigo_Nodo_Madre").Value

        Dim _Codigo As String = _Sql.Fx_Trae_Dato(_Clas_Asistente_Compras.Pro_Nombre_Tbl_Paso_Informe, "Codigo", "Codigo_Nodo_Madre = '" & _Codigo_Nodo_Madre & "'")
        Dim _Descripcion As String = _Fila.Cells("Producto").Value

        _Clas_Asistente_Compras.Sb_Info_Calculo_Rotacion(Me, _Codigo, _Descripcion, _Ud)

    End Sub

    Private Sub Btn_Ver_documento_origen_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ver_documento_origen.Click
        'Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        If _HitColumn.IsSelected = True Then

            _Panel_Activo = CType(sender, SuperGridControl).ActiveGrid

            Dim _Cabeza = _HitColumn.Name ' Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
            Dim _Fila As GridRow = TryCast(Super_Grilla.ActiveRow, GridRow)
            'Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

            Dim Copiar As String = _Fila.Cells(_Cabeza).Value
            Clipboard.SetText(Copiar)

        End If

    End Sub

    Private Sub SuperGridControl1CellValueChanged(sender As Object, e As GridCellValueChangedEventArgs)
        Dim panel As GridPanel = e.GridPanel

        'Si el valor de una celda en el panel' Detalles del pedido 'ha cambiado
        'luego actualice su pie de página para reflejar el cambio

        If panel.Name.Equals("Order Details") = True Then
            UpdateDetailsFooter(panel, "VANELI", "VAIVLI", "VABRLI")
        End If
    End Sub

    Private Sub UpdateDetailsFooter(panel As GridPanel,
                                    _CNeto As String,
                                    _CIva As String,
                                    _CTotal As String)
        If panel.Footer Is Nothing Then
            panel.Footer = New GridFooter()
        End If

        Dim _Total_Neto As Double = TotalRows(panel.Rows, _CNeto) '"VANELI")
        Dim _Total_Iva As Double = TotalRows(panel.Rows, _CIva) '"VAIVLI")
        Dim _Total_Bruto As Double = TotalRows(panel.Rows, _CTotal) ' "VABRLI")

        Dim _Pie_Pag As String = "Neto <font color=""Green""><i>" & FormatCurrency(_Total_Neto, 0) & "</i></font>" & vbCrLf &
                                 ", I.V.A. <font color=""Green""><i>" & FormatCurrency(_Total_Iva, 0) & "</i></font>" & vbCrLf &
                                 ", Total <font color=""Green""><i>" & FormatCurrency(_Total_Bruto, 0) & "</i></font>"
        'String.Format("Total Neto <font color=""Green""><i>{0:C}</i></font>", _Total_Neto) & vbCrLf & _
        'String.Format("Total Iva <font color=""Green""><i>{0:C}</i></font>", _Total_Iva) & vbCrLf & _
        'String.Format("Total Bruto <font color=""Green""><i>{0:C}</i></font>", _Total_Bruto)

        panel.Footer.Text = _Pie_Pag 'String.Format("Total sales <font color=""Green""><i>{0:C}</i></font>", _Total_Neto)
    End Sub

    Private Function TotalRows(rows As IEnumerable(Of GridElement),
                               _Campo As String) As Double
        Dim total As Decimal = 0

        For Each item As GridContainer In rows
            If TypeOf item Is GridRow Then
                Dim row As GridRow = CType(item, GridRow)


                Dim _Vaneli = row(_Campo).Value
                'DirectCast(IIf(row("VANELI").Value Is Nothing, 0D, _
                '               row("VANELI").Value), Decimal)
                'Dim discount As Single = CSng(IIf(row("Discount").Value Is Nothing, 0D, row("Discount").Value))
                'Dim quantity As Short = CShort(Fix(IIf(row("Quantity").Value Is Nothing, 0D, row("Quantity").Value)))


                'Dim unitPrice As Decimal = DirectCast(IIf(row("UnitPrice").Value Is Nothing, 0D, row("UnitPrice").Value), Decimal)
                'Dim discount As Single = CSng(IIf(row("Discount").Value Is Nothing, 0D, row("Discount").Value))
                'Dim quantity As Short = CShort(Fix(IIf(row("Quantity").Value Is Nothing, 0D, row("Quantity").Value)))
                total += _Vaneli
                'total += (unitPrice - CDec(discount)) * quantity
            End If

            If item.Rows.Count > 0 Then
                total += TotalRows(item.Rows, _Campo)
            End If
        Next item

        Return (total)

    End Function

    Private Function Fx_Tbl_Occ_Fcc(_CodigoNodo As String, _Tido As String) As DataTable

        Consulta_sql = "Select KOPRCT As Codigo,IDMAEEDO,TIDO,NUDO,ENDO,SUENDO,(Select Top 1 NOKOEN From MAEEN Where KOEN+SUEN = ENDO+SUENDO) As Razon," &
                          "UD01PR,CAPRCO1,CAPREX1,(CAPRCO1-(CAPRAD1+CAPREX1)) As Saldo, FEERLI " &
                          "From MAEDDO" & vbCrLf &
                          "Where KOPRCT  In (SELECT Codigo FROM " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo_Nodo = '" & _CodigoNodo & "') And" & vbCrLf &
                          "TIDO = '" & _Tido & "' And ESLIDO = '' " & vbCrLf &
                          "Order By FEERLI Desc"

        Return _Sql.Fx_Get_Tablas(Consulta_sql)

    End Function

    Private Sub SuperGridControl1GetCellStyle(sender As Object, e As GridGetCellStyleEventArgs)

        Dim _Grilla As GridPanel = e.GridPanel

        If Global_Thema = Enum_Themas.Oscuro Then
            e.Style.TextColor = Color.White
        Else
            e.Style.TextColor = Color.Black
        End If

        Dim _Cabeza = e.GridCell.GridColumn.Name
        Dim _Fila As GridRow = _Grilla.Rows(e.GridCell.RowIndex)

        Dim _Valor = _Fila.Cells(_Cabeza).Value

        If _Grilla.Name = "Informe" Then

            If _Cabeza = "Codigo_Nodo" Then

                If Global_Thema = Enum_Themas.Oscuro Then ': e.Style.Background.Color1 = Color.Black : e.Style.Background.Color2 = Color.Black
                    e.Style.Background.Color1 = Color.Black
                    e.Style.Background.Color2 = Color.Black
                Else
                    e.Style.Background.Color1 = Color.White
                    e.Style.Background.Color2 = Color.White
                End If

                If Global_Thema = Enum_Themas.Oscuro Then e.Style.TextColor = Amarillo

            End If

            If _Cabeza = "StockPedidoUd" & _Ud Or _Cabeza = "StockFacSinRecepUd" & _Ud Or _Cabeza = "Tendencia" Then

                If Global_Thema = Enum_Themas.Oscuro Then
                    If _Valor > 0 Then : e.Style.TextColor = Verde : ElseIf _Valor < 0 Then : e.Style.TextColor = Rojo : End If
                Else
                    If _Valor > 0 Then : e.Style.Background.Color1 = Color.White : e.Style.Background.Color2 = Color.LightGreen
                    ElseIf _Valor < 0 Then : e.Style.Background.Color1 = Color.White : e.Style.Background.Color2 = Color.LightPink : End If
                End If

            End If

            If _Cabeza.Contains("_P") And Not IsNumeric(_Valor) Then

                Dim _Color As Color

                If _Valor = "A" Then _Color = Color.Green
                If _Valor = "V" Then _Color = Color.GreenYellow
                If _Valor = "R" Then _Color = Color.LightPink
                If _Valor = "P" Then _Color = Color.Yellow
                If _Valor = "S" Then _Color = Color.Yellow

                e.Style.Background.Color1 = _Color : e.Style.Background.Color2 = _Color
                e.Style.TextColor = Color.Black

            End If

        ElseIf _Grilla.Name = "Table" Then

            Dim _CodigoNodo = _Fila.Cells("Codigo_Nodo").Value

            Dim _RotCalculo = Math.Round(_Fila.Cells("RotCalculo").Value, 0)
            Dim _StockUd = Math.Round(_Fila.Cells("StockUd" & _Ud).Value, 0)
            Dim _StockPedidoUd = Math.Round(_Fila.Cells("StockPedidoUd" & _Ud).Value, 0)
            Dim _StockFacSinRecepUd = Math.Round(_Fila.Cells("StockFacSinRecepUd" & _Ud).Value, 0)

            Dim _Producto = _Fila.Cells("Producto").Value

            Dim _Tbl_Detalle As DataTable
            Dim _Fecha_Recep As Date

            If _Cabeza = "Codigo" Then

                If Global_Thema = Enum_Themas.Oscuro Then ': e.Style.Background.Color1 = Color.Black : e.Style.Background.Color2 = Color.Black : e.Style.TextColor = Amarillo
                    e.Style.Background.Color1 = Color.Black
                    e.Style.Background.Color2 = Color.Black
                    e.Style.TextColor = Amarillo
                Else
                    e.Style.Background.Color1 = Color.White
                    e.Style.Background.Color2 = Color.White
                End If

            End If

            If _Cabeza = "StockPedidoUd" & _Ud Then

                If CBool(_StockPedidoUd) Then

                    _Tbl_Detalle = Fx_Tbl_Occ_Fcc(_CodigoNodo, "OCC")

                    For Each _Row As DataRow In _Tbl_Detalle.Rows

                        Dim _Idmaeedo = NuloPorNro(_Row.Item("IDMAEEDO"), 0)

                        If CBool(_Idmaeedo) Then

                            _Fecha_Recep = FormatDateTime(_Row.Item("FEERLI"), DateFormat.ShortDate)

                            If _Fecha_Recep < _Fecha_Servidor Then
                                e.Style.TextColor = Rojo
                            Else
                                e.Style.TextColor = Verde
                            End If

                        End If

                    Next

                End If

            End If

            If _Cabeza = "StockFacSinRecepUd" & _Ud Then

                If CBool(_StockFacSinRecepUd) Then

                    _Tbl_Detalle = Fx_Tbl_Occ_Fcc(_CodigoNodo, "FCC")

                    For Each _Row As DataRow In _Tbl_Detalle.Rows

                        Dim _Idmaeedo = NuloPorNro(_Row.Item("IDMAEEDO"), 0)

                        If CBool(_Idmaeedo) Then

                            _Fecha_Recep = FormatDateTime(_Row.Item("FEERLI"), DateFormat.ShortDate)

                            If _Fecha_Recep < _Fecha_Servidor Then
                                e.Style.TextColor = Rojo
                            Else
                                e.Style.TextColor = Verde
                            End If

                        End If

                    Next

                End If

            End If

        ElseIf _Grilla.Name = "Table2" Then

            Select Case _Cabeza

                Case "FEERLI"

                    Dim _Feerli As Date = FormatDateTime(e.GridCell.Value, DateFormat.ShortDate)

                    If _Feerli < _Fecha_Servidor Then
                        e.Style.TextColor = Rojo
                    Else
                        e.Style.TextColor = Verde
                    End If

                Case "TIDO", "NUDO"

                    If _Fila.Cells("TIDO").Value = "OCC" Then
                        e.Style.TextColor = Verde
                    Else
                        e.Style.TextColor = Purpura
                    End If

            End Select

        End If

    End Sub

    Sub Sb_Ocultar_encabezados_Super_Grilla(_Grilla As GridPanel)

        With _Grilla

            Dim NCol As Integer = .Columns.Count 'ColumnCount
            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 0 To NCol - 1

                Dim NomColumna = .Columns(i).Name.ToString()
                'Dim TipoColumna = .Columns(i).CellType.ToString 'DataGrid.Columns(i - 1).ValueType.ToString()

                .Columns(i).Visible = False
                .Columns(i).ReadOnly = True ' _ReadOnly
                .Columns(i).GroupBoxEffects = GroupBoxEffects.None
                '.Columns(i).CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
                '.Columns(i).EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIpAddressInputEditControl)
                '.Columns(i).HeaderStyles.Default.Image = My.Resources.ok_button 'CType(Resources.GetObject("resource.Image"), System.Drawing.Image)
                '.Columns(i).Name = "IpAddressInput"
                '.Columns(i).Width = 150
                'If Activar_Orden_Automatico Then

                'End If

            Next

        End With


        _Grilla.ShowToolTips = True
        _Grilla.GroupByRow.Visible = False

        _Grilla.MinRowHeight = 20
        _Grilla.AutoGenerateColumns = True

        _Grilla.DefaultVisualStyles.GroupByStyles.Default.Background = _Background1


        _Grilla.SelectionGranularity = SelectionGranularity.Cell

    End Sub

    Private Sub SuperGridControl1DataBindingComplete(sender As Object, e As GridDataBindingCompleteEventArgs)

        Dim panel As GridPanel = e.GridPanel

        panel.GroupByRow.Visible = True
        panel.GroupByRow.Text = "GRUPOS"

        Select Case panel.DataMember
            Case "Table1"

                Sb_Formato_Grilla_Asociados(panel)
            Case "Table"
                'AddHandler Super_Grilla.GetCellStyle, AddressOf SuperGridControl1GetCellStyle
                Sb_Formato_Grilla_Productos(panel)
                'RemoveHandler Super_Grilla.GetCellStyle, AddressOf SuperGridControl1GetCellStyle
            Case "Table2"
                panel.SortLevel = SortLevel.None
                Sb_Formato_Grilla_Documentos(panel)
        End Select

    End Sub

    Private Sub SuperGridControl1SelectionChanged(sender As Object, e As GridEventArgs)

        Dim panel As GridPanel = e.GridPanel 'superGridControl1.PrimaryGrid
        Dim items As SelectedElementCollection = panel.GetSelectedElements()
        Dim cells As List(Of GridCell) = items.GetCells()

        _Grilla_Activa = panel.DataMember.ToString

        Dim s As String = Nothing

        If cells.Count > 0 Then
            For Each cell As GridCell In cells
                '  If ValuesMatch(s, DirectCast(cell.Value, String)) = False Then
                'Exit For
                'End If
            Next
        End If

        ' TbxCellText.Text = s
    End Sub

    Sub Sb_Formato_Grilla_Asociados(_Grilla As GridPanel)

        Dim _Duracion As String
        Dim _Campos As Integer
        Dim _Pref_Campo As String

        Select Case _Proyeccion
            Case Enum_Proyeccion.Diaria
                _Duracion = "diaria" : _Campos = 60 : _Pref_Campo = "Día"
            Case Enum_Proyeccion.Semanal
                _Duracion = "semanal" : _Campos = 20 : _Pref_Campo = "Sem"
            Case Enum_Proyeccion.Mensual
                _Duracion = "mensual" : _Campos = 12 : _Pref_Campo = "Mes"
        End Select

        Dim _Rotacion As String

        'If _RotCalculo = "D" Then
        '    _Rotacion = "Rotación" & vbCrLf & "diria"
        'ElseIf _RotCalculo = "E" Then
        '    _Rotacion = "Rotación" & vbCrLf & "efectiva"
        'End If

        If Rdb_Proyeccion_Promedio_Diario.Checked Then _Rotacion = "Promedio" & vbCrLf & "diario"
        If Rdb_Proyeccion_Rotacion_Diaria.Checked Then _Rotacion = "Rotación" & vbCrLf & "diaria"

        Me.Text = "Informe de proyección de compras a nivel: " & _Duracion
        'Grupo_Detalle.Text = "AGRUPACION: " & UCase(_Row_Nodo.Item("Descripcion"))

        Sb_Ocultar_encabezados_Super_Grilla(_Grilla)


        With _Grilla

            .FrozenColumnCount = 1
            .ColumnHeader.RowHeight = 70
            .ShowRowGridIndex = True
            .GroupByRow.Visible = False
            '.UseAlternateRowStyle = True

            .Caption.Text = "(INFORME DE COMPRAS COMERCIO EXTERIOR)<div align=""vcenter"">Información detallada de los productos de la empresa</div>"
            '(Detallede busqueda)<div align="vcenter">Información detallada de los productos de la empresa</div>

            .Columns(0).GroupBoxEffects = GroupBoxEffects.None
            'panel.Columns("Region").NullString = "<no locale>"

            .Columns(0).CellStyles.Default.Background = New Background(Color.AliceBlue)

            ' Dim _Padding As DevComponents.DotNetBar.SuperGrid.Style.Padding = New DevComponents.DotNetBar.SuperGrid.Style.Padding

            '_Padding.Bottom = 4
            '_Padding.Left = 4
            '_Padding.Right = 4
            '_Padding.Top = 4
            '.ColumnHeader.Size
            For Each column As GridColumn In .Columns
                column.ColumnSortMode = ColumnSortMode.Multiple
                column.ResizeMode = ColumnResizeMode.MoveFollowingElements
                'column.AutoSizeMode = ColumnAutoSizeMode.AllCells
                '   column.HeaderStyles.Default.Margin = _Padding
                'column.HeaderText = "Masked TextBox"
            Next column

            Dim _DisplayIndex = 0
            Dim _Campo As String

            _Campo = "Codigo_Nodo"
            .Columns(_Campo).Width = 80
            .Columns(_Campo).HeaderText = "Nodo"
            .Columns(_Campo).GroupBoxEffects = GroupBoxEffects.Move
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Campo = "Codigo_Nodo_Madre"
            .Columns(_Campo).Width = 80
            .Columns(_Campo).HeaderText = "Codigo"
            .Columns(_Campo).GroupBoxEffects = GroupBoxEffects.Move
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Campo = "Producto"
            .Columns(_Campo).Width = 200
            .Columns(_Campo).HeaderText = _Campo
            .Columns(_Campo).GroupBoxEffects = GroupBoxEffects.Move
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Campo = "StockUd" & _Ud
            .Columns(_Campo).Width = 80
            .Columns(_Campo).HeaderText = "Stock" & vbCrLf & "físico"
            DirectCast(.Columns(_Campo).RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"
            .Columns(_Campo).CellStyles.Default.Alignment = Alignment.MiddleRight
            '.Columns(_Campo).ToolTipText = "Stock consolidado según bodegas seleccionadas"
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Campo = "StockPedidoUd" & _Ud
            .Columns(_Campo).Width = 80
            .Columns(_Campo).HeaderText = "Stock" & vbCrLf & "pedido"
            DirectCast(.Columns(_Campo).RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"
            .Columns(_Campo).CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Campo = "StockFacSinRecepUd" & _Ud
            .Columns(_Campo).Width = 80
            .Columns(_Campo).HeaderText = "Stock" & vbCrLf & "facturado" & vbCrLf & "sin" & vbCrLf & "recepcionar."
            DirectCast(.Columns(_Campo).RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"
            .Columns(_Campo).CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Campo = "RotCalculo"
            .Columns(_Campo).Width = 80
            .Columns(_Campo).HeaderText = _Rotacion
            DirectCast(.Columns(_Campo).RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"
            .Columns(_Campo).CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            Dim _Campo_HT = String.Empty

            If Rdb_Proyeccion_Promedio_Diario.Checked Then
                _Campo = "Promedio_Mensual"
                _Campo_HT = "Promedio" & vbCrLf & "mensual"
            End If

            If Rdb_Proyeccion_Rotacion_Diaria.Checked Then
                _Campo = "Venta_Periodo"
                _Campo_HT = "Rotación" & vbCrLf & "mensual" & vbCrLf & "(Mediana)"
            End If

            .Columns(_Campo).Width = 80
            .Columns(_Campo).HeaderText = _Campo_HT '"Rotación" & vbCrLf & "mensual" & vbCrLf & "(Mediana)"
            DirectCast(.Columns(_Campo).RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"
            .Columns(_Campo).CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            'Incorporar estos 2 campos

            '.Columns("SumTotalQtyUd" & _Ud & "_Ult_3Cio").Width = 80
            '.Columns("SumTotalQtyUd" & _Ud & "_Ult_3Cio").HeaderText = "Ventas" & vbCrLf & "ultimo tercio" & vbCrLf & "según estudio" '"Rot X " & _Dias_Proyeccion & " días"
            'DirectCast(.Columns("SumTotalQtyUd" & _Ud & "_Ult_3Cio").RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"
            '.Columns("SumTotalQtyUd" & _Ud & "_Ult_3Cio").CellStyles.Default.Alignment = Alignment.MiddleRight
            '.Columns("SumTotalQtyUd" & _Ud & "_Ult_3Cio").Visible = True
            '.Columns("SumTotalQtyUd" & _Ud & "_Ult_3Cio").DisplayIndex = 7

            _Campo = "Promedio_3Mes"
            .Columns(_Campo).Width = 100
            .Columns(_Campo).HeaderText = "Promedio Ventas" & vbCrLf & "ultimos 3 meses"
            DirectCast(.Columns(_Campo).RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"
            .Columns(_Campo).CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Campo = "SumTotalQtyUd1_Ult_3Cio"
            .Columns(_Campo).Width = 80
            .Columns(_Campo).HeaderText = "Ventas" & vbCrLf & "Ventas ultimo" & vbCrLf & "mes" '"Rot X " & _Dias_Proyeccion & " días"
            DirectCast(.Columns(_Campo).RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"
            .Columns(_Campo).CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns(_Campo).Visible = True
            .Columns(_Campo).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Campo = "Tendencia"
            .Columns("Tendencia").Width = 70
            .Columns("Tendencia").HeaderText = "Tendencia"
            DirectCast(.Columns("Tendencia").RenderControl, GridDoubleInputEditControl).DisplayFormat = "%##,##"
            .Columns("Tendencia").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("Tendencia").Visible = True
            .Columns("Tendencia").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Campo = "Duracion_Proyeccion"
            .Columns("Duracion_Proyeccion").Width = 80
            .Columns("Duracion_Proyeccion").HeaderText = "Duración" & vbCrLf & _Duracion & vbCrLf & "Según stock"
            DirectCast(.Columns("Duracion_Proyeccion").RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"
            .Columns("Duracion_Proyeccion").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("Duracion_Proyeccion").Visible = True
            .Columns("Duracion_Proyeccion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Campo = "Cant_Comprar"
            .Columns("Cant_Comprar").Width = 80
            .Columns("Cant_Comprar").HeaderText = "Cantidad" & vbCrLf & "necesaria" '"Cant. Comprar"
            DirectCast(.Columns("Cant_Comprar").RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"
            .Columns("Cant_Comprar").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("Cant_Comprar").Visible = True
            .Columns("Cant_Comprar").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Campo = "Cant_Comprar_Sug_Red"
            .Columns("Cant_Comprar_Sug_Red").Width = 80
            .Columns("Cant_Comprar_Sug_Red").HeaderText = "Cantidad" & vbCrLf & "sugerida" & vbCrLf & "comprar"
            DirectCast(.Columns("Cant_Comprar_Sug_Red").RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"
            .Columns("Cant_Comprar_Sug_Red").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("Cant_Comprar_Sug_Red").Visible = True
            .Columns("Cant_Comprar_Sug_Red").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Dias_Abastecer").Width = 60
            '.Columns("Dias_Abastecer").HeaderText = "Stock Ud. " & _Ud
            '.Columns("Dias_Abastecer").DefaultCellStyle.Format = "##,###"
            '.Columns("Dias_Abastecer").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Dias_Abastecer").Visible = True

            Dim _Ano = Year(Now.Date)
            Dim _Mes = Month(Now.Date)

            Dim _MesActual = _Fecha_Servidor.Month
            Dim _YearActual = _Fecha_Servidor.Year

            For _i = 1 To _Campos

                Dim _Columna = numero_(_i, 2) & "_P"
                'Dim _Columna = numero_(_i, 2) & "_P" & "_" & numero_(_MesActual, 2) & "_" & _YearActual

                Dim _Nombre_Columna As String

                .Columns(_Columna).Width = 30

                If _Mes = 13 Then _Mes = 1

                If _Proyeccion = Enum_Proyeccion.Mensual Then
                    _Nombre_Columna = MonthName(_Mes, True)
                    .Columns(_Columna).Width = 30
                    .Columns(_Columna).HeaderText = _Nombre_Columna
                End If

                _Mes += 1

                .Columns(_Columna).CellStyles.Default.Alignment = Alignment.MiddleCenter
                .Columns(_Columna).Visible = True

                _MesActual += 1
                If _MesActual = 13 Then
                    _MesActual = 1
                    _YearActual += 1
                End If

            Next

        End With

        Sb_Marcar_Super_Grilla(_Grilla)

        If _Grilla.Footer Is Nothing Then
            _Grilla.Footer = New GridFooter()
        End If


        ' INCORPORAR EL PIE DEL INFORME CON LA TABLA _TblInforme_Totales

        'If False Then

        Dim _Total_Stock_Fisico As Double = _TblInforme_Totales.Rows(0).Item("StockUd")
        Dim _Total_Stock_Pedido As Double = _TblInforme_Totales.Rows(0).Item("StockPedidoUd")
        Dim _Total_Stock_FSRecepcionar As Double = _TblInforme_Totales.Rows(0).Item("StockFacSinRecepUd")

        Dim _Total_Rot_Diaria As Double = _TblInforme_Totales.Rows(0).Item("RotDiariaUd")
        Dim _Total_Rot_Mensual As Double = _TblInforme_Totales.Rows(0).Item("RotMensualUd")

        Dim _Promedio As Double = _TblInforme_Totales.Rows(0).Item("Prom_Pond")

        Dim _Total_Cant_Sugerida As Double = _TblInforme_Totales.Rows(0).Item("Cant_Comprar_Sug")
        Dim _Total_Cant_Sugerida2 As Double = _TblInforme_Totales.Rows(0).Item("Cant_Comprar_Sug2")

        Dim _Fsz As String = "size = ""11"""

        Dim _Color As String = "Green"

        If Global_Thema = Enum_Themas.Oscuro Then

            _Color = "#69E495"

        End If

        Dim _Pie_Pag As String = "<font " & _Fsz & ">Stock Fisico: </font><font " & _Fsz & " color=""" & _Color & """>" & FormatNumber(_Total_Stock_Fisico, 0) & "</font>" & vbCrLf &
                                     ", <font " & _Fsz & ">Stock Pedido: </font><font " & _Fsz & " color=""" & _Color & """>" & FormatNumber(_Total_Stock_Pedido, 0) & "</font>" & vbCrLf &
                                     ", <font " & _Fsz & ">Stock Fac.S/Recepcionar: </font><font " & _Fsz & " color=""" & _Color & """>" & FormatNumber(_Total_Stock_FSRecepcionar, 0) & "</font>" & vbCrLf &
                                     ", <font " & _Fsz & ">Rot. Diaria: </font><font " & _Fsz & " color=""" & _Color & """>" & FormatNumber(_Total_Rot_Diaria, 0) & "</font>" & vbCrLf &
                                     ", <font " & _Fsz & ">Rot. Mensual: </font><font " & _Fsz & " color=""" & _Color & """>" & FormatNumber(_Total_Rot_Mensual, 0) & "</font>" & vbCrLf &
                                     ", <font " & _Fsz & ">Prom.Ponderado: </font><font " & _Fsz & " color=""" & _Color & """>" & FormatNumber(_Promedio, 2) & "</font>" & vbCrLf &
                                     ", <font " & _Fsz & ">Total Cant.Sugerida: </font><font " & _Fsz & " color=""" & _Color & """>" & FormatNumber(_Total_Cant_Sugerida, 0) & "</font>" & vbCrLf &
                                     ", <font " & _Fsz & ">Total Cant.Sugerida/23.000: </font><font " & _Fsz & " color=""" & _Color & """>" & FormatNumber(_Total_Cant_Sugerida2, 0) & "</font>"


        _Grilla.Footer.Text = _Pie_Pag

        'End If

        Me.Cursor = Cursors.Default
        Me.Enabled = True

    End Sub

    Sub Sb_Formato_Grilla_Productos(_Grilla As GridPanel)

        Dim _Duracion As String
        Dim _Campos As Integer
        Dim _Pref_Campo As String

        Select Case _Proyeccion
            Case Enum_Proyeccion.Diaria
                _Duracion = "diaria" : _Campos = 60 : _Pref_Campo = "Día"
            Case Enum_Proyeccion.Semanal
                _Duracion = "semanal" : _Campos = 20 : _Pref_Campo = "Sem"
            Case Enum_Proyeccion.Mensual
                _Duracion = "mensual" : _Campos = 12 : _Pref_Campo = "Mes"
        End Select

        Sb_Ocultar_encabezados_Super_Grilla(_Grilla)

        With _Grilla

            .FrozenColumnCount = 1
            .ColumnHeader.RowHeight = 60
            .ShowRowGridIndex = True
            .GroupByRow.Visible = False

            .Columns(0).GroupBoxEffects = GroupBoxEffects.None
            'panel.Columns("Region").NullString = "<no locale>"

            .Columns(0).CellStyles.Default.Background = New Background(Color.LightYellow)

            For Each column As GridColumn In .Columns
                column.ColumnSortMode = ColumnSortMode.Multiple
            Next column

            .Caption = New GridCaption()

            Dim _Color As String = "Maroon"

            If Global_Thema = Enum_Themas.Oscuro Then
                _Color = "#A24B40"
            End If

            .Caption.Text = String.Format("Producto asociador: <font color=""" & _Color & """><i>""{1}</i></font>, asociados ({0})",
                            .Rows.Count,
                            CType(.Parent, GridRow)("Producto").Value)

            .DefaultVisualStyles.CaptionStyles.Default.Alignment = Alignment.MiddleLeft
            '.DefaultVisualStyles.GroupByStyles.Default.Background = _Background2

            'UpdateDetailsFooter(_Grilla, "VANEDO", "VAIVDO", "VABRDO")

            Dim _Campo As String

            _Campo = "Codigo"
            .Columns(_Campo).Width = 120
            .Columns(_Campo).HeaderText = "Código"
            .Columns(_Campo).Visible = True

            _Campo = "Descripcion"
            .Columns(_Campo).Width = 300
            .Columns(_Campo).HeaderText = "Descripción"
            .Columns(_Campo).Visible = True

            _Campo = "Ud" & _Ud
            .Columns("Ud" & _Ud).Width = 30
            .Columns("Ud" & _Ud).HeaderText = "UN"
            .Columns("Ud" & _Ud).CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("Ud" & _Ud).Visible = True

            _Campo = "StockUd" & _Ud
            .Columns(_Campo).Width = 70
            .Columns(_Campo).HeaderText = "Stock"
            DirectCast(.Columns(_Campo).RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"
            .Columns(_Campo).CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns(_Campo).Visible = True

            _Campo = "StockPedidoUd" & _Ud
            .Columns(_Campo).Width = 70
            .Columns(_Campo).HeaderText = "Stock" & vbCrLf & "pedido"
            DirectCast(.Columns(_Campo).RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"
            .Columns(_Campo).CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns(_Campo).Visible = True

            _Campo = "StockFacSinRecepUd" & _Ud
            .Columns(_Campo).Width = 70
            .Columns(_Campo).HeaderText = "Stock" & vbCrLf & "facturado" & vbCrLf & "sin" & vbCrLf & "recepcionar"
            DirectCast(.Columns(_Campo).RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"
            .Columns(_Campo).CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns(_Campo).Visible = True

            _Campo = "RotDiariaUd" & _Ud & "_Prod"
            .Columns(_Campo).Width = 70
            .Columns(_Campo).HeaderText = "Rotación" & vbCrLf & "diaria"
            DirectCast(.Columns(_Campo).RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"
            .Columns(_Campo).CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns(_Campo).Visible = True

            _Campo = "RotMensualUd" & _Ud & "_Prod"
            .Columns(_Campo).Width = 70
            .Columns(_Campo).HeaderText = "Rotación" & vbCrLf & "mensual"
            DirectCast(.Columns(_Campo).RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"
            .Columns(_Campo).CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns(_Campo).Visible = True

            '.Columns("RotEfectivaUd" & _Ud).Width = 70
            '.Columns("RotEfectivaUd" & _Ud).HeaderText = "Rotación" & vbCrLf & "efectiva"
            'DirectCast(.Columns("RotEfectivaUd" & _Ud).RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"
            '.Columns("RotEfectivaUd" & _Ud).CellStyles.Default.Alignment = Alignment.MiddleRight
            '.Columns("RotEfectivaUd" & _Ud).Visible = True

            '.Columns("Duracion_Proyeccion").Width = 70
            '.Columns("Duracion_Proyeccion").HeaderText = "Duración" & vbCrLf & _Duracion
            'DirectCast(.Columns("Duracion_Proyeccion").RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"
            '.Columns("Duracion_Proyeccion").CellStyles.Default.Alignment = Alignment.MiddleRight
            '.Columns("Duracion_Proyeccion").Visible = True

            '.Columns("Cant_Comprar_Sug").Width = 70
            '.Columns("Cant_Comprar_Sug").HeaderText = "Cantidad" & vbCrLf & "sugerida" & vbCrLf & "comprar"
            'DirectCast(.Columns("Cant_Comprar_Sug").RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"
            '.Columns("Cant_Comprar_Sug").CellStyles.Default.Alignment = Alignment.MiddleRight
            '.Columns("Cant_Comprar_Sug").Visible = True

        End With

        'Sb_Marcar_Grilla()

        Me.Cursor = Cursors.Default
        Me.Enabled = True

    End Sub

    Sub Sb_Formato_Grilla_Documentos(_Grilla As GridPanel)

        Dim _Duracion As String
        Dim _Campos As Integer
        Dim _Pref_Campo As String

        Select Case _Proyeccion
            Case Enum_Proyeccion.Diaria
                _Duracion = "diaria" : _Campos = 60 : _Pref_Campo = "Día"
            Case Enum_Proyeccion.Semanal
                _Duracion = "semanal" : _Campos = 20 : _Pref_Campo = "Sem"
            Case Enum_Proyeccion.Mensual
                _Duracion = "mensual" : _Campos = 12 : _Pref_Campo = "Mes"
        End Select

        Sb_Ocultar_encabezados_Super_Grilla(_Grilla)

        With _Grilla

            .FrozenColumnCount = 1
            .ColumnHeader.RowHeight = 60
            .ShowRowGridIndex = True
            .GroupByRow.Visible = False
            '.UseAlternateRowStyle = True

            .Columns(0).GroupBoxEffects = GroupBoxEffects.None

            .Columns(0).CellStyles.Default.Background = New Background(Color.LightGreen)

            For Each column As GridColumn In .Columns
                column.ColumnSortMode = ColumnSortMode.Multiple
            Next column

            'panel.Columns("Region").NullString = "<no locale>"

            '.Caption = New GridCaption()

            '.Caption.Text = String.Format("Documentos ({0}), Cliente: <font color=""Maroon""><i>""{1}</i>""</font>", _
            '                .Rows.Count, _
            '                "!!!")

            .DefaultVisualStyles.CaptionStyles.Default.Alignment = Alignment.MiddleLeft
            '.DefaultVisualStyles.GroupByStyles.Default.Background = _Background2


            .Columns("TIDO").Width = 30
            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Visible = True

            .Columns("NUDO").Width = 90
            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Visible = True

            .Columns("ENDO").Width = 80
            .Columns("ENDO").HeaderText = "Entidad"
            .Columns("ENDO").Visible = True

            .Columns("SUENDO").Width = 50
            .Columns("SUENDO").HeaderText = "Suc."
            .Columns("SUENDO").Visible = True

            .Columns("Razon").Width = 260
            .Columns("Razon").HeaderText = "Nombre proveedor"
            .Columns("Razon").Visible = True

            .Columns("UD0" & _Ud & "PR").Width = 30
            .Columns("UD0" & _Ud & "PR").HeaderText = "UD"
            .Columns("UD0" & _Ud & "PR").Visible = True

            .Columns("CAPRCO" & _Ud).Width = 60
            .Columns("CAPRCO" & _Ud).HeaderText = "Cantidad"
            DirectCast(.Columns("CAPRCO" & _Ud).RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"
            .Columns("CAPRCO" & _Ud).CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("CAPRCO" & _Ud).Visible = True

            .Columns("CAPREX" & _Ud).Width = 80
            .Columns("CAPREX" & _Ud).HeaderText = "Cantidad" & vbCrLf & "recepcionada"
            DirectCast(.Columns("CAPREX" & _Ud).RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"
            .Columns("CAPREX" & _Ud).CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("CAPREX" & _Ud).Visible = True

            .Columns("Saldo").Width = 60
            .Columns("Saldo").HeaderText = "Saldo"
            DirectCast(.Columns("Saldo").RenderControl, GridDoubleInputEditControl).DisplayFormat = "###,##"
            .Columns("Saldo").CellStyles.Default.Alignment = Alignment.MiddleRight
            .Columns("Saldo").Visible = True

            .Columns("FEERLI").Width = 100
            .Columns("FEERLI").HeaderText = "Fecha" & vbCrLf & "recepción"
            .Columns("FEERLI").Visible = True

        End With


        Me.Cursor = Cursors.Default
        Me.Enabled = True

    End Sub

    Private Sub Super_Grilla_CellDoubleClick(sender As System.Object, e As DevComponents.DotNetBar.SuperGrid.GridCellDoubleClickEventArgs) Handles Super_Grilla.CellDoubleClick

        _Panel_Activo = CType(sender, SuperGridControl).ActiveGrid

        'If (e.Button And MouseButtons.Right) = MouseButtons.Right Then
        'Dim item As GridElement = Super_Grilla.GetElementAt(e.Location)

        '_HitColumn = _Panel_Activo.Columns(e.GridCell.ColumnIndex)

        Dim _Fila As GridRow = TryCast(Super_Grilla.ActiveRow, GridRow)

        'If TypeOf item Is GridCell Then

        Btn_Actualizar_Rotacion_Producto_Actual.Visible = False
        Btn_Estadisticas_Producto.Visible = False
        Btn_Infor_Rotacion.Visible = False

        Select Case _Panel_Activo.DataMember
            Case "Table"
                Btn_Estadisticas_Producto.Visible = True
                ShowContextMenu(Menu_Contextual_Productos)
            Case "Table1"
                Sb_Revisar_Info_Producto(_Fila)
            Case "Table2"
                Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value
                Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
                Fm.ShowDialog(Me)
                Fm.Dispose()
        End Select

    End Sub

    Private Sub Super_Grilla_CellMouseDown(sender As System.Object, e As DevComponents.DotNetBar.SuperGrid.GridCellMouseEventArgs) Handles Super_Grilla.CellMouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then
            _Panel_Activo = CType(sender, SuperGridControl).ActiveGrid

            'If (e.Button And MouseButtons.Right) = MouseButtons.Right Then
            'Dim item As GridElement = Super_Grilla.GetElementAt(e.Location)

            Dim _Fila As GridRow = TryCast(Super_Grilla.ActiveRow, GridRow)


            'If TypeOf item Is GridCell Then

            'Dim _HitColumn As GridColumn
            _HitColumn = _Panel_Activo.Columns(e.GridCell.ColumnIndex)

            Btn_Actualizar_Rotacion_Producto_Actual.Visible = False
            Btn_Estadisticas_Producto.Visible = False
            Btn_Infor_Rotacion.Visible = False

            Select Case _Panel_Activo.DataMember
                Case "Table"
                    Btn_Estadisticas_Producto.Visible = True
                    ShowContextMenu(Menu_Contextual_Productos)
                Case "Table1"
                    Btn_Infor_Rotacion.Visible = True
                    ShowContextMenu(Menu_Contextual_Productos)
                Case "Table2"

            End Select
        End If

    End Sub

    Private Sub Btn_Colapsar_Filas_Click(sender As Object, e As EventArgs) Handles Btn_Colapsar_Filas.Click
        Super_Grilla.PrimaryGrid.CollapseAll()
    End Sub

    Private Sub Super_Grilla_BeforeExpand(sender As Object, e As GridBeforeExpandEventArgs) Handles Super_Grilla.BeforeExpand

        Dim _Grilla As GridPanel = e.GridPanel

        If _Grilla.Name = "Table" Then

            Dim _Fila As GridRow = TryCast(Super_Grilla.ActiveRow, GridRow)
            Dim _Suma As Double = _Fila.Cells("StockPedidoUd" & _Ud).Value + _Fila.Cells("StockFacSinRecepUd" & _Ud).Value

            If Not CBool(_Suma) Then

                Beep()
                e.Cancel = True

                ToastNotification.Show(Me, "NO EXISTE INFORMACION", Nothing,
                                  2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

            End If

        End If

    End Sub

    Private Sub Frm_AsisCompra_Proyeccion_Informe_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize

        If Me.Visible Then
            For Each f As Form In Application.OpenForms
                If f.Name <> Me.Name Then
                    If Me.WindowState = FormWindowState.Minimized Then
                        f.WindowState = Me.WindowState
                    Else
                        If f.Name = "Frm_Menu" Or f.Name = "Frm_01_Asis_Compra_Resultados" Then
                            f.WindowState = FormWindowState.Maximized
                        Else
                            f.WindowState = FormWindowState.Normal
                        End If
                    End If
                End If
            Next
        End If

    End Sub

    Private Sub Sb_Rdb_Rotacion_CheckedChanged(sender As Object, e As EventArgs)
        If sender.Checked Then
            Sb_Actualizar_SuperGrid()
        End If
    End Sub


End Class
