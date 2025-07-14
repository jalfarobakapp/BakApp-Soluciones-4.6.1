Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Inf_Vencimientos_Mes_Detalle_Diario

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Fecha_Inicio, _Fecha_Fin As Date
    Dim _Valor_Maximo_Marca As Double
    Dim _SqlConsulta_informe As String

    Dim _Ex_Index_Fila As Integer
    Dim _Ex_Index_Columna As Integer

    Dim _Arrastrando As Boolean

    Dim _Reprocesar_Informe As Boolean '_Vencimientos_Cambiados As Boolean
    Dim _Chk_Deuda_Efectiva As Boolean

    Public _Tipo_Informe As Tipo_Informe
    Dim _Cambiando_Fecha_Vencimiento As Boolean
    Dim _Id_Correo As Integer

    Dim _Filtro_Maeedo,
        _Filtro_Maedpce As String

    Enum Tipo_Informe
        Diario
        Mensual
        Anual
    End Enum

    Dim _Informe As Informe_VC

    Enum Informe_VC
        Compras
        Ventas
    End Enum

    Public ReadOnly Property Pro_Reprocesar_Informe() As Boolean
        Get
            Return _Reprocesar_Informe
        End Get
    End Property

    Public Sub New(ByVal New_SqlConsulta As String,
                   ByVal New_Fecha_Inicio As Date,
                   ByVal New_Fecha_Fin As Date,
                   ByVal New_Valor_Maximo As Double,
                   ByVal New_Id_Correo As Integer,
                   ByVal New_Informe As Informe_VC)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        _SqlConsulta_informe = New_SqlConsulta
        _Fecha_Inicio = New_Fecha_Inicio
        _Fecha_Fin = New_Fecha_Fin
        _Valor_Maximo_Marca = New_Valor_Maximo
        _Id_Correo = New_Id_Correo

        _Informe = New_Informe

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Inf_Vencimientos_Mes_Detalle_Diario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If _Tipo_Informe = Tipo_Informe.Diario Then
            Sb_Generar_Informe_Diario(_Fecha_Inicio, _Fecha_Fin)
        ElseIf _Tipo_Informe = Tipo_Informe.Mensual Then
            Sb_Generar_Informe_Mensual(_Fecha_Inicio, _Fecha_Fin)
            Btn_Cambiar_Fechas_Vencimiento.Visible = False
            Btn_Quitar_Celdas_En_Cero.Visible = False

            AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown_Boton_Derecho

        End If

    End Sub


    Sub Sb_Generar_Informe_Diario(ByVal _Fecha_Inicio As Date,
                                  ByVal _Fecha_Fin As Date)


        Consulta_sql = _SqlConsulta_informe 'My.Resources.Recursos_Inf_Compras_Vencimiento.Informe_Vencimientos_Compras_Anuales & vbCrLf & vbCrLf
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Inicio#", Format(_Fecha_Inicio, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Fin#", Format(_Fecha_Fin, "yyyyMMdd"))

        Consulta_sql = Replace(Consulta_sql, "--#Filtro_Adicional_Maeedo#", _Filtro_Maeedo)
        Consulta_sql = Replace(Consulta_sql, "--#Filtro_Adicional_Maedpce#", _Filtro_Maedpce)

        If Not _Chk_Deuda_Efectiva Then
            Consulta_sql += vbCrLf & vbCrLf & "Delete #INFVEN Where Deuda = 'Pagos'" & vbCrLf & vbCrLf
        End If

        Dim _Sql1 = Consulta_sql & vbCrLf & "Select distinct FEVE From #INFVEN" & vbCrLf & "Drop Table #INFVEN"


        Dim _TblDias As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Consulta_sql += "SELECT VEN.RTEN,VEN.RUT,VEN.ENDO,VEN.NOKOEN,TOTAL_D = SUM(COALESCE(VEN.VAVE-VEN.VAABVE ,0.0))," & vbCrLf

        Dim _i = 0

        Dim _Dias = DateDiff(DateInterval.Day, _Fecha_Inicio, _Fecha_Fin)

        Dim _Arreglo_Dias(_Dias) As String


        Dim _Fecha_dia As Date = _Fecha_Inicio

        Dim _Sql_Suma As String = String.Empty

        For _i = 0 To _Dias

            Dim _Coma = ","

            Dim _Dia_Palabra = UCase(WeekdayName(Weekday(_Fecha_dia.Date, FirstDayOfWeek.System)))

            Dim _Dia = numero_(_Fecha_dia.Day, 2)
            Dim _Mes = numero_(_Fecha_dia.Month, 2)
            Dim _Ano = numero_(_Fecha_dia.Year, 4)

            Dim _Campo As String = _Dia_Palabra & "_" & _Dia & "_" & _Mes & "_" & _Ano
            _Arreglo_Dias(_i) = _Campo

            If FormatDateTime(_Fecha_dia, DateFormat.ShortDate) = FormatDateTime(_Fecha_Fin, DateFormat.ShortDate) Then _Coma = ""

            Consulta_sql += _Campo & "=SUM(" & vbCrLf &
                            "CASE " & vbCrLf &
                            "WHEN VEN.FEVE  BETWEEN '" & Format(_Fecha_dia, "yyyyMMdd") &
                            "' AND '" & Format(_Fecha_dia, "yyyyMMdd") & "'  THEN COALESCE(VEN.VAVE-VEN.VAABVE ,0.0)" & vbCrLf &
                            "ELSE 0.0" & vbCrLf &
                            "END )" & _Coma & vbCrLf

            _Sql_Suma += "Sum(" & _Campo & ") as '" & _Campo & "'" & _Coma & vbCrLf

            _Fecha_dia = DateAdd(DateInterval.Day, 1, _Fecha_dia)

        Next

        If _Dias > 6 Then
            Grilla.ScrollBars = ScrollBars.Horizontal
        End If

        Consulta_sql += "INTO #INFVENR  " & vbCrLf &
                        "FROM #INFVEN AS VEN WITH ( NOLOCK ) " & vbCrLf &
                        "GROUP BY VEN.RTEN,VEN.RUT,VEN.ENDO,VEN.NOKOEN" & vbCrLf &
                        "SELECT  #INFVENR.*" &
                        "FROM #INFVENR  WITH ( NOLOCK )" & vbCrLf &
                        "Union" & vbCrLf &
                        "SELECT '9999999' AS RTEN,'' AS RUT,'ZZZZZZ' AS ENDO," &
                                                    "'ZZZ' AS NOKOEN,TOTAL_D = SUM(TOTAL_D)," & _Sql_Suma & vbCrLf &
                        "FROM #INFVENR" & vbCrLf &
                        "ORDER BY #INFVENR.RTEN  OPTION ( FAST 20 ) " & vbCrLf &
                        "Drop Table #INFVEN" & vbCrLf &
                        "Drop Table #INFVENR"
        '"ORDER BY #INFVENR.ENDO,#INFVENR.SUENDO  OPTION ( FAST 20 ) " & vbCrLf & _

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)
        Dim _Tbl As DataTable = _Ds.Tables(0)

        With Grilla

            .DataSource = _Tbl
            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("RUT").Width = 80
            .Columns("RUT").HeaderText = "Rut"
            .Columns("RUT").Visible = True
            .Columns("RUT").Frozen = True
            .Columns("RUT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            '.Columns("ENDO").Width = 70
            '.Columns("ENDO").HeaderText = "Entidad"
            '.Columns("ENDO").Visible = True
            '.Columns("ENDO").Frozen = True

            .Columns("NOKOEN").Width = 170
            .Columns("NOKOEN").HeaderText = "Razón social"
            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").Frozen = True

            ' .Columns("TOTAL_D").Width = 120
            ' .Columns("TOTAL_D").HeaderText = "Total deuda"
            ' .Columns("TOTAL_D").DefaultCellStyle.Format = "$ ###,##"
            ' .Columns("TOTAL_D").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' .Columns("TOTAL_D").Visible = True
            ' .Columns("TOTAL_D").Frozen = True

            For Each _Fila As String In _Arreglo_Dias

                Dim _Datos = Split(_Fila, "_")

                Dim _Dia_Palabra = _Datos(0)
                Dim _Dia = _Datos(1)
                Dim _Mes = _Datos(2)
                Dim _Ano = _Datos(3)

                .Columns(_Fila).HeaderText = _Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
                .Columns(_Fila).Width = 90
                .Columns(_Fila).DefaultCellStyle.Format = "$ ###,##"
                .Columns(_Fila).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(_Fila).Visible = True

            Next

            _Tbl.Columns("RUT").ReadOnly = False
            _Tbl.Columns("NOKOEN").ReadOnly = False

            For Each _Row As DataRow In _Tbl.Rows
                Dim _Rt = Trim(_Row.Item("RTEN"))
                Dim _Rut As String
                If IsNumeric(_Rt) Then
                    _Rut = FormatNumber(_Rt, 0) & "-" & RutDigito(_Rt)
                End If
                _Row.Item("RUT") = _Rut
            Next

        End With

        Sb_Formato_Informe_Diario()

    End Sub

    Sub Sb_Formato_Informe_Diario()

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Endo = _Fila.Cells("ENDO").Value

            If _Endo = "TOTAL" Or _Endo = "ZZZZZZ" Then

                _Fila.DefaultCellStyle.Font = New Font("Tahoma", 9, FontStyle.Regular)

                With Grilla

                    Dim NCol As Integer = .ColumnCount

                    Dim _Rojo As Color = Color.Red
                    Dim _Verde As Color = Color.Green

                    If Global_Thema = Enum_Themas.Oscuro Then
                        _Rojo = Color.FromArgb(220, 78, 66)
                        _Verde = Color.FromArgb(30, 215, 96)
                    End If

                    For i As Integer = 0 To NCol - 1

                        Dim NomColumna = .Columns(i).Name.ToString()

                        If NomColumna = "TOTAL_D" Then

                            _Fila.Cells(NomColumna).Style.Font = New Font("Tahoma", 10, FontStyle.Regular)
                            _Fila.Cells(NomColumna).Style.ForeColor = _Rojo

                        ElseIf NomColumna <> "ENDO" And NomColumna <> "RUT" And NomColumna <> "NOKOEN" Then

                            Dim _Valor = NuloPorNro(_Fila.Cells(NomColumna).Value, 0)


                            If _Valor < _Valor_Maximo_Marca Then
                                _Fila.Cells(NomColumna).Style.ForeColor = _Verde
                            Else
                                _Fila.Cells(NomColumna).Style.ForeColor = _Rojo
                            End If

                        End If

                    Next

                End With

                _Fila.Cells("RUT").Value = "TOTAL"
                '_Tbl.Columns("NOKOEN").ReadOnly = False
                _Fila.Cells("NOKOEN").Value = ""

            End If

            If Global_Thema = Enum_Themas.Oscuro Then
                If _Cambiando_Fecha_Vencimiento Then
                    _Fila.Cells("RUT").Style.ForeColor = Color.FromArgb(46, 50, 50)
                    _Fila.Cells("NOKOEN").Style.ForeColor = Color.FromArgb(46, 50, 50)
                Else
                    _Fila.Cells("RUT").Style.ForeColor = Color.White
                    _Fila.Cells("NOKOEN").Style.ForeColor = Color.White
                End If
            Else
                If _Cambiando_Fecha_Vencimiento Then
                    _Fila.Cells("RUT").Style.ForeColor = Color.Gray
                    _Fila.Cells("NOKOEN").Style.ForeColor = Color.Gray
                Else
                    _Fila.Cells("RUT").Style.ForeColor = Color.Black
                    _Fila.Cells("NOKOEN").Style.ForeColor = Color.Black
                End If
            End If

        Next

    End Sub

    Sub Sb_Generar_Informe_Mensual(ByVal _Fecha_Inicio As Date,
                                   ByVal _Fecha_Fin As Date)

        Me.Cursor = Cursors.WaitCursor

        Consulta_sql = _SqlConsulta_informe 'My.Resources.Recursos_Inf_Compras_Vencimiento.Informe_Vencimientos_Compras_Anuales & vbCrLf & vbCrLf
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Inicio#", Format(_Fecha_Inicio, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Fin#", Format(_Fecha_Fin, "yyyyMMdd"))

        Consulta_sql = Replace(Consulta_sql, "--#Filtro_Adicional_Maeedo#", _Filtro_Maeedo)
        Consulta_sql = Replace(Consulta_sql, "--#Filtro_Adicional_Maedpce#", _Filtro_Maedpce)


        If Not _Chk_Deuda_Efectiva Then
            Consulta_sql += vbCrLf & vbCrLf & "Delete #INFVEN Where Deuda = 'Pagos'" & vbCrLf & vbCrLf
        End If

        Dim _Sql1 = Consulta_sql & vbCrLf & "Select distinct FEVE From #INFVEN" & vbCrLf & "Drop Table #INFVEN"

        Dim _TblDias As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        'Consulta_sql += "SELECT VEN.RTEN,VEN.RUT,VEN.ENDO,VEN.SUENDO,VEN.NOKOEN,TOTAL_D = SUM(COALESCE(VEN.VAVE-VEN.VAABVE ,0.0))," & vbCrLf
        Consulta_sql += "SELECT VEN.RTEN,VEN.RUT,VEN.ENDO,VEN.NOKOEN,Cast(0 As Int) As DIAS_ATRASO,TOTAL_D = SUM(COALESCE(VEN.VAVE-VEN.VAABVE ,0.0))," & vbCrLf


        Dim _i = 0

        Dim _Meses = DateDiff(DateInterval.Month, _Fecha_Inicio, _Fecha_Fin)

        Dim _Arreglo_Meses(_Meses) As String


        Dim _Fecha_mes As Date = _Fecha_Inicio

        Dim _Sql_Suma As String = String.Empty

        For _i = 0 To _Meses

            Dim _Coma = ","

            Dim _Dia = numero_(_Fecha_mes.Day, 2)
            Dim _Mes = numero_(_Fecha_mes.Month, 2)
            Dim _Ano = numero_(_Fecha_mes.Year, 4)

            Dim _Mes_Palabra = UCase(MonthName(_Mes))

            Dim _Campo As String = _Mes_Palabra & "_" & _Ano
            _Arreglo_Meses(_i) = _Campo

            Dim _Fecha_Inicio_Mes As Date = Primerdiadelmes(_Fecha_mes)
            Dim _Fecha_Fin_Mes As Date = ultimodiadelmes(_Fecha_mes)

            If _i = _Meses Then
                _Coma = ""
            End If

            Consulta_sql += _Campo & "=SUM(" & vbCrLf &
                            "CASE " & vbCrLf &
                            "WHEN VEN.FEVE  BETWEEN '" & Format(_Fecha_Inicio_Mes, "yyyyMMdd") &
                            "' AND '" & Format(_Fecha_Fin_Mes, "yyyyMMdd") & "'  THEN COALESCE(VEN.VAVE-VEN.VAABVE ,0.0)" & vbCrLf &
                            "ELSE 0.0" & vbCrLf &
                            "END )" & _Coma & vbCrLf

            _Sql_Suma += "Sum(" & _Campo & ") as '" & _Campo & "'" & _Coma & vbCrLf

            _Fecha_mes = DateAdd(DateInterval.Month, 1, _Fecha_mes)

        Next

        Dim _Sql_Tido_Atraso As String

        If _Informe = Informe_VC.Compras Then
            _Sql_Tido_Atraso = "'BLC','FCC','FCT','FDC','RGA'"
        ElseIf _Informe = Informe_VC.Ventas Then
            _Sql_Tido_Atraso = "'BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL','FVT','FVX','FVZ'"
        End If

        Consulta_sql += "INTO #INFVENR  " & vbCrLf &
                        "FROM #INFVEN AS VEN WITH ( NOLOCK ) " & vbCrLf &
                        "GROUP BY VEN.RTEN,VEN.RUT,VEN.ENDO,VEN.NOKOEN" &
                        vbCrLf &
                        vbCrLf &
                        "Update #INFVENR Set DIAS_ATRASO = Isnull((Select Min(DIAS_ATRASO) From #INFVEN Z1" & Space(1) &
                        "Where Z1.RTEN = Z2.RTEN And TIDO In (" & _Sql_Tido_Atraso & ") ),0)" & vbCrLf &
                        "From #INFVENR Z2" &
                        vbCrLf &
                        vbCrLf &
                        "SELECT  #INFVENR.*" &
                        "FROM #INFVENR  WITH ( NOLOCK )" & vbCrLf &
                        "Union" & vbCrLf &
                        "SELECT '9999999' AS RTEN,'' AS RUT,'ZZZZZZ' AS ENDO,'ZZZ' AS NOKOEN,Cast(0 As Int) As DIAS_ATRASO,TOTAL_D = SUM(TOTAL_D)," & vbCrLf &
                        _Sql_Suma & vbCrLf &
                        "FROM #INFVENR" & vbCrLf &
                        "ORDER BY #INFVENR.ENDO OPTION ( FAST 20 ) " & vbCrLf &
                        "Drop Table #INFVEN" & vbCrLf &
                        "Drop Table #INFVENR"

        Consulta_sql = Replace(Consulta_sql, "#Empresa#", Mod_Empresa)

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        Dim _Tbl As DataTable = _Ds.Tables(0)

        _Tbl.Columns("RUT").ReadOnly = False
        _Tbl.Columns("NOKOEN").ReadOnly = False
        '_Tbl.Columns("RUT").ReadOnly = False

        With Grilla

            .DataSource = _Tbl
            OcultarEncabezadoGrilla(Grilla)

            .Columns("RTEN").Frozen = True
            .Columns("ENDO").Frozen = True

            .Columns("RUT").Width = 80
            .Columns("RUT").HeaderText = "Rut"
            .Columns("RUT").Visible = True
            .Columns("RUT").Frozen = True
            .Columns("RUT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("NOKOEN").Width = 300
            .Columns("NOKOEN").HeaderText = "Razón social"
            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").Frozen = True

            .Columns("DIAS_ATRASO").Width = 50
            .Columns("DIAS_ATRASO").HeaderText = "Mayor atraso"
            .Columns("DIAS_ATRASO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DIAS_ATRASO").Visible = True
            .Columns("DIAS_ATRASO").Frozen = True

            .Columns("TOTAL_D").Width = 120
            .Columns("TOTAL_D").HeaderText = "Total deuda"
            .Columns("TOTAL_D").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TOTAL_D").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TOTAL_D").Visible = True
            .Columns("TOTAL_D").Frozen = True

            For Each _Fila As String In _Arreglo_Meses

                Dim _Datos = Split(_Fila, "_")

                Dim _Mes_Palabra = _Datos(0)
                Dim _Ano = _Datos(1)

                .Columns(_Fila).HeaderText = _Mes_Palabra & ", " & _Ano
                .Columns(_Fila).Width = 90
                .Columns(_Fila).DefaultCellStyle.Format = "$ ###,##"
                .Columns(_Fila).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(_Fila).Visible = True
            Next

        End With

        For Each _Row As DataRow In _Tbl.Rows

            Dim _Rt = Trim(_Row.Item("RTEN"))
            Dim _Rut As String

            If Not String.IsNullOrEmpty(_Rt) Then _Rut = FormatNumber(Val(_Rt), 0) & "-" & RutDigito(_Rt)
            _Row.Item("RUT") = _Rut

        Next

        Sb_Formato_Informe_Mensual()
        Sb_Quitar_Columnas_en_cero()

        Me.Cursor = Cursors.Default

    End Sub

    Sub Sb_Formato_Informe_Mensual()

        Dim _Rojo As Color = Color.Red
        Dim _Verde As Color = Color.Green

        If Global_Thema = Enum_Themas.Oscuro Then
            _Rojo = Color.FromArgb(220, 78, 66)
            _Verde = Color.FromArgb(30, 215, 96)
        End If

        For Each _Fila As DataGridViewRow In Grilla.Rows

            ' _Fila.Cells("TOTAL_D").Style.Font = New Font("Tahoma", 9, FontStyle.Bold)

            Dim _Valor_Total = NuloPorNro(_Fila.Cells("TOTAL_D").Value, 0)

            If _Valor_Total < 0 Then
                _Fila.Cells("TOTAL_D").Style.ForeColor = _Verde
            Else
                _Fila.Cells("TOTAL_D").Style.ForeColor = _Rojo
            End If

            Dim _Endo = _Fila.Cells("ENDO").Value

            If _Endo = "TOTAL" Or _Endo = "ZZZZZZ" Then

                _Fila.DefaultCellStyle.Font = New Font("Tahoma", 9, FontStyle.Regular)

                With Grilla
                    ' ¿Cuantas columnas y cuantas filas?
                    Dim NCol As Integer = .ColumnCount
                    'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
                    For i As Integer = 0 To NCol - 1

                        Dim NomColumna = .Columns(i).Name.ToString()

                        If NomColumna = "TOTAL_D" Then
                            _Fila.Cells(NomColumna).Style.Font = New Font("Tahoma", 10, FontStyle.Regular)
                            _Fila.Cells(NomColumna).Style.ForeColor = _Rojo
                        ElseIf NomColumna <> "ENDO" And NomColumna <> "RUT" And
                               NomColumna <> "NOKOEN" And NomColumna <> "DIAS_ATRASO" Then

                            Dim _Valor = NuloPorNro(_Fila.Cells(NomColumna).Value, 0)

                            If _Valor < _Valor_Maximo_Marca Then
                                _Fila.Cells(NomColumna).Style.ForeColor = _Verde
                            Else
                                _Fila.Cells(NomColumna).Style.ForeColor = _Rojo
                            End If

                        End If

                    Next

                End With

                _Fila.Cells("RUT").Value = "TOTAL"
                _Fila.Cells("NOKOEN").Value = ""

            End If

        Next


    End Sub

    Private Sub Frm_Inf_Vencimientos_Mes_Detalle_Diario_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Sb_Revisar_Columna()
        'Sb_Mostrar_Detalle(False, Accion.Mostrar_todo)
    End Sub

    Sub Sb_Revisar_Columna()

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Endo = _Fila.Cells("ENDO").Value
        Dim _SuEndo = "" ' _Fila.Cells("SUENDO").Value

        Select Case _Cabeza
            Case "TOTAL_D", "DIAS_ATRASO"
                If _Endo = "TOTAL" Or _Endo = "ZZZZZZ" Then
                    Sb_Mostrar_Detalle(False, Accion.Mostrar_todo, _Id_Correo)
                Else
                    Btn_Mnu_Mostrar_deuda_actual.Text = "Mostrar detalle deuda actual"
                    Lbl_Mnu_1.Visible = False
                    Btn_Mnu_Ficha_Entidad.Visible = False
                    ShowContextMenu(Menu_Contextual_01)
                End If
            Case "ENDO", "NOKOEN"
                If _Endo = "TOTAL" Or _Endo = "ZZZZZZ" Then
                    Sb_Mostrar_Detalle(False, Accion.Mostrar_todo, _Id_Correo)
                Else
                    Btn_Mnu_Mostrar_deuda_actual.Text = "Mostrar detalle deuda actual"
                    Lbl_Mnu_1.Visible = True
                    Btn_Mnu_Ficha_Entidad.Visible = True
                    ShowContextMenu(Menu_Contextual_01)
                End If
            Case Else
                If _Endo = "TOTAL" Or _Endo = "ZZZZZZ" Then
                    Sb_Mostrar_Detalle(False, Accion.Mostrar_todo, _Id_Correo)
                Else
                    Btn_Mnu_Mostrar_deuda_actual.Text = "Mostrar detalle actual columna: " & _Cabeza
                    Lbl_Mnu_1.Visible = False
                    Btn_Mnu_Ficha_Entidad.Visible = False
                    ShowContextMenu(Menu_Contextual_01)
                End If
        End Select

    End Sub

    Enum Accion
        Mover_Fechas
        Cobranza
        Mostrar_todo
    End Enum

    Sub Sb_Mostrar_Detalle(ByVal _Mover As Boolean,
                           ByVal _Accion As Accion,
                           ByVal _Id_Correo_ As Integer,
                           Optional ByVal _Nueva_Fecha As String = "",
                           Optional ByVal _Mostrar_todo As Boolean = False)


        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Nueva_Fecha_Vencimiento As Date

        Dim _Endo = _Fila.Cells("ENDO").Value
        Dim _SuEndo = "" '_Fila.Cells("SUENDO").Value

        If _Endo = "TOTAL" Then _Endo = String.Empty
        Dim _Fx_Fecha_Inicio, _Fx_Fecha_Fin As String


        _Fx_Fecha_Inicio = Format(_Fecha_Inicio, "yyyyMMdd")
        _Fx_Fecha_Fin = Format(_Fecha_Fin, "yyyyMMdd")

        If _Cabeza = "ENDO" Or _Cabeza = "RUT" Or _Cabeza = "NOKOEN" Or _Cabeza = "TOTAL_D" Or _Cabeza = "DIAS_ATRASO" Then
            _Fx_Fecha_Inicio = Format(_Fecha_Inicio, "yyyyMMdd")
            _Fx_Fecha_Fin = Format(_Fecha_Fin, "yyyyMMdd")
        Else


            Dim _Fecha = Split(_Cabeza, "_")
            Dim _Fecha_Vencimiento As String

            If _Tipo_Informe = Tipo_Informe.Diario Then

                _Fecha_Vencimiento = _Fecha(3) & _Fecha(2) & _Fecha(1)
                _Fx_Fecha_Inicio = _Fecha_Vencimiento
                _Fx_Fecha_Fin = _Fecha_Vencimiento

                If Not String.IsNullOrEmpty(_Nueva_Fecha) Then
                    _Nueva_Fecha_Vencimiento = CDate(Mid(_Nueva_Fecha, 7, 4) & "-" & Mid(_Nueva_Fecha, 5, 2) & "-" & Mid(_Nueva_Fecha, 1, 4))
                End If

            ElseIf _Tipo_Informe = Tipo_Informe.Mensual Then

                Dim _Fecha_ As Date = CDate("01/" & Fx_Mes_a_Numero(_Fecha(0)) & "/" & _Fecha(1))

                _Fx_Fecha_Inicio = Format(Primerdiadelmes(_Fecha_), "yyyyMMdd")
                _Fx_Fecha_Fin = Format(ultimodiadelmes(_Fecha_), "yyyyMMdd")

            End If

        End If


        If _Mostrar_todo Then
            _Fx_Fecha_Inicio = "19000101"
            _Fx_Fecha_Fin = "30001201"
        End If



        Dim Fm As New Frm_Inf_Vencimientos_Detalle_Documentos(_Endo, _SuEndo, _SqlConsulta_informe,
                                                              _Fx_Fecha_Inicio, _Fx_Fecha_Fin,
                                                              _Accion, _Id_Correo_, _Informe)

        Fm.Pro_Nueva_Fecha_Vencimiento = _Nueva_Fecha_Vencimiento '_Nueva_Fecha_Vencimiento = _Nueva_Fecha_Vencimiento
        Fm.Pro_Mover_Fechas = _Mover '_Mover_Fechas = _Mover
        Fm.Pro_Chk_Deuda_Efectiva = _Chk_Deuda_Efectiva

        Fm.Pro_Filtro_Maeedo = _Filtro_Maeedo
        Fm.Pro_Filtro_Maedpce = _Filtro_Maedpce

        Fm.Sb_Generar_Informe()

        If Fm.Grilla.RowCount Then
            Fm.ShowDialog(Me)

            Dim _TblInforme As DataTable = Fm.Pro_TblInforme

            If Fm.Pro_Mover_Fechas Then ' _Mover_Fechas Then
                If Fx_Revisar_Si_Es_Posible_Cambiar_Fechas_De_Documentos(_TblInforme, True, _Nueva_Fecha) = 0 Then
                    If Fx_Cambiar_Fechas_De_Documentos(_TblInforme, True, _Nueva_Fecha) Then
                        Sb_Generar_Informe_Diario(_Fecha_Inicio, _Fecha_Fin)
                    End If
                End If
            End If

            _Reprocesar_Informe = Fm.Pro_Reprocesar_Informe '_Vencimientos_Cambiados

            If _Reprocesar_Informe Then

                If _Tipo_Informe = Tipo_Informe.Diario Then
                    Sb_Generar_Informe_Diario(_Fecha_Inicio, _Fecha_Fin)
                ElseIf _Tipo_Informe = Tipo_Informe.Mensual Then
                    Sb_Generar_Informe_Mensual(_Fecha_Inicio, _Fecha_Fin)
                End If

                If Grilla.Rows.Count = 1 Then
                    MessageBoxEx.Show(Me, "No hay datos que mostrar", "Informe detallado",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Close()
                End If

            End If

        Else
            MessageBoxEx.Show(Me, "No hay datos que mostrar", "Informe detallado",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Fm.Dispose()


    End Sub

    Function Fx_Mes_a_Numero(ByVal _MesPalabra As String)

        _MesPalabra = UCase(_MesPalabra)
        Dim _Mes As Integer

        Select Case _MesPalabra
            Case "ENERO"
                _Mes = 1
            Case "FEBRERO"
                _Mes = 2
            Case "MARZO"
                _Mes = 3
            Case "ABRIL"
                _Mes = 4
            Case "MAYO"
                _Mes = 5
            Case "JUNIO"
                _Mes = 6
            Case "JULIO"
                _Mes = 7
            Case "AGOSTO"
                _Mes = 8
            Case "SEPTIEMBRE"
                _Mes = 9
            Case "OCTUBRE"
                _Mes = 10
            Case "NOVIEMBRE"
                _Mes = 11
            Case "DICIEMBRE"
                _Mes = 12
        End Select

        Return _Mes
    End Function

    Function Fx_Revisar_Si_Es_Posible_Cambiar_Fechas_De_Documentos(ByVal _TblDocumento As DataTable,
                                                                   ByVal _Solo_Checkeados As Boolean,
                                                                   ByVal _Nueva_Fecha As String) As Integer

        Dim _Documentos As Integer

        Dim _Fecha_Vencimiento = CDate(Mid(_Nueva_Fecha, 7, 4) & "-" & Mid(_Nueva_Fecha, 5, 2) & "-" & Mid(_Nueva_Fecha, 1, 4))

        For Each _Fila_Tbl As DataRow In _TblDocumento.Rows

            Dim _Chk As Boolean

            _Chk = _Fila_Tbl.Item("Chk")

            If Not _Solo_Checkeados Then
                _Chk = True
            End If

            If _Chk Then

                Dim _Fecha_Emision As Date = _Fila_Tbl.Item("FEEMDO")

                If _Fecha_Emision > _Fecha_Vencimiento Then
                    _Documentos += 1
                End If

            End If
        Next

        If CBool(_Documentos) Then
            MessageBoxEx.Show(Me, "Existen documentos que la fecha de emisión es mayor a la del vencimiento seleccionado" & vbCrLf &
                              "Documentos con problemas: " & _Documentos, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Return _Documentos

    End Function

    Function Fx_Cambiar_Fechas_De_Documentos(ByVal _TblDocumento As DataTable,
                                             ByVal _Solo_Checkeados As Boolean,
                                             ByVal _Nueva_Fecha As String) As Boolean

        Consulta_sql = String.Empty

        For Each _Fila_Tbl As DataRow In _TblDocumento.Rows

            Dim _Chk As Boolean

            _Chk = _Fila_Tbl.Item("Chk")

            If Not _Solo_Checkeados Then
                _Chk = True
            End If

            If _Chk Then

                Dim _Idmaeven As Integer = _Fila_Tbl.Item("IDMAEVEN")
                Dim _Idmaeedo As Integer = _Fila_Tbl.Item("IDMAEEDO")


                Dim _HoraGrab = Hora_Grab_fx(False)

                Dim _Fecha_Anterior = _Fila_Tbl.Item("FEVE")
                Dim _Fecha_Nuevo_Vencimiento = CDate(Mid(_Nueva_Fecha, 7, 4) & "-" & Mid(_Nueva_Fecha, 5, 2) & "-" & Mid(_Nueva_Fecha, 1, 4))


                Consulta_sql += "INSERT INTO MEVENTO (ARCHIRVE,IDRVE,ARCHIRSE,IDRSE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC," &
                                "FECHAREF,HORAGRAB) VALUES " & vbCrLf &
                                "('MAEEDO'," & _Idmaeedo & ",'',0,'" & FUNCIONARIO &
                                "',GetDate(),'FECHA_VENC','CAMBIO'," &
                                "'FECHA DE VENCIMIENTO DESDE " & FormatDateTime(_Fecha_Anterior, DateFormat.ShortDate) &
                                " A " & FormatDateTime(_Fecha_Nuevo_Vencimiento, DateFormat.ShortDate) &
                                "','" & Format(_Fecha_Anterior, "yyyyMMdd") & "'," & _HoraGrab & ")" & vbCrLf

                Consulta_sql += "Update MAEVEN Set FEVE = '" & _Nueva_Fecha & "' Where IDMAEVEN = " & _Idmaeven & vbCrLf &
                                "UPDATE MAEEDO SET FE01VEDO = (Select Min(FEVE) From MAEVEN WHERE IDMAEEDO=" & _Idmaeedo & ") " &
                                "Where IDMAEEDO = " & _Idmaeedo & vbCrLf &
                                "UPDATE MAEEDO SET FEULVEDO = (Select Max(FEVE) From MAEVEN WHERE IDMAEEDO=" & _Idmaeedo & ") " &
                                "Where IDMAEEDO = " & _Idmaeedo & vbCrLf &
                                "UPDATE MAEEDO SET NUVEDO = (Select Count(*) From MAEVEN WHERE IDMAEEDO=" & _Idmaeedo & ") " &
                                "Where IDMAEEDO = " & _Idmaeedo & vbCrLf & vbCrLf
            End If

        Next

        'If String.IsNullOrEmpty(Consulta_sql) Then Return False

        Return _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

    End Function


    Private Sub BtnActualizarInformacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Actualizar_Informacion.Click
        If _Tipo_Informe = Tipo_Informe.Diario Then
            Sb_Generar_Informe_Diario(_Fecha_Inicio, _Fecha_Fin)
        ElseIf _Tipo_Informe = Tipo_Informe.Mensual Then
            Sb_Generar_Informe_Mensual(_Fecha_Inicio, _Fecha_Fin)
        End If
    End Sub

    Sub Sb_Quitar_Columnas_en_cero()

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Rut = NuloPorNro(_Fila.Cells("RUT").Value, "")

            If _Rut = "TOTAL" Then '"9.999.999-3" Then

                '_Fila.DefaultCellStyle.Font = New Font("Tahoma", 9, FontStyle.Bold)

                With Grilla

                    Dim NCol As Integer = .ColumnCount
                    'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
                    For i As Integer = 0 To NCol - 1

                        Dim NomColumna = .Columns(i).Name.ToString()

                        If NomColumna <> "ENDO" And NomColumna <> "RUT" And NomColumna <> "NOKOEN" And NomColumna <> "DIAS_ATRASO" Then
                            Dim _Valor = NuloPorNro(_Fila.Cells(NomColumna).Value, 0)

                            If _Valor = 0 Then
                                Grilla.Columns(NomColumna).Visible = False
                            End If

                        End If

                    Next

                End With

            End If

        Next
    End Sub

    Private Sub Btn_Quitar_Celdas_En_Cero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Quitar_Celdas_En_Cero.Click
        Sb_Quitar_Columnas_en_cero()
    End Sub

    Private Sub Btn_Exportar_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar_Excel.Click
        ExportarTabla_JetExcel_Tabla(Grilla.DataSource, Me, Me.Text)
    End Sub

    Sub Sb_Eventos_Arrastrar(ByVal _Asignar As Boolean)


        If _Asignar Then

            AddHandler Grilla.DragEnter, AddressOf Sb_Grilla_DragEnter
            AddHandler Grilla.DragDrop, AddressOf Sb_Grilla_DragDrop
            AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
            AddHandler Grilla.DragOver, AddressOf Sb_Grilla_DragOver
            AddHandler Grilla.MouseMove, AddressOf Sb_Grilla_MouseMove

            Btn_Actualizar_Informacion.Enabled = False
            Btn_Buscar_Entidad.Enabled = False
            Btn_Quitar_Celdas_En_Cero.Enabled = False
            Btn_Cambiar_Fechas_Vencimiento.Text = "Terminar de cambiar fechas"
            Btn_Exportar_Excel.Enabled = False
            Me.ControlBox = False

            Beep()
            ToastNotification.Show(Me, "CAMBIO DE FECHA ACTIVADO", My.Resources.ok_button,
                                  1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        Else

            RemoveHandler Grilla.DragEnter, AddressOf Sb_Grilla_DragEnter
            RemoveHandler Grilla.DragDrop, AddressOf Sb_Grilla_DragDrop
            RemoveHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
            RemoveHandler Grilla.DragOver, AddressOf Sb_Grilla_DragOver
            RemoveHandler Grilla.MouseMove, AddressOf Sb_Grilla_MouseMove

            Btn_Actualizar_Informacion.Enabled = True
            Btn_Buscar_Entidad.Enabled = True
            Btn_Quitar_Celdas_En_Cero.Enabled = True
            Btn_Cambiar_Fechas_Vencimiento.Text = "Cambiar fechas de vencimiento"
            Btn_Exportar_Excel.Enabled = True
            Me.ControlBox = True

            Beep()
            ToastNotification.Show(Me, "CAMBIO DE FECHA DESACTIVADO", My.Resources.ok_button,
                                   1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        End If

        _Cambiando_Fecha_Vencimiento = _Asignar
        Sb_Formato_Informe_Diario()

        Me.Refresh()

    End Sub

    Private Sub Sb_Grilla_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub Sb_Grilla_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)

        Dim Point = Grilla.PointToClient(New Point(e.X, e.Y))
        Dim Hitest As DataGridView.HitTestInfo = Grilla.HitTest(Point.X, Point.Y)
        Dim _Cabeza_Origen As String = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Cabeza_Destino As String = Grilla.Columns(Hitest.ColumnIndex).Name

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        If _Cabeza_Origen <> _Cabeza_Destino Then

            Dim _Valor = _Fila.Cells(Grilla.CurrentCell.ColumnIndex).Value

            If CBool(_Valor) Then


                Dim _Fecha = Split(_Cabeza_Destino, "_")
                Dim _Fecha_Vencimiento As String = _Fecha(3) & _Fecha(2) & _Fecha(1)


                Radio1.Text = "Mover todas"
                Radio2.Text = "Seleccionar"

                Dim _Radios = New Command() {Radio1, Radio2}

                Dim _Tbl = Fx_Tbl_Todos()

                If _Tbl.Rows.Count = 1 Then
                    If Fx_Revisar_Si_Es_Posible_Cambiar_Fechas_De_Documentos(_Tbl, False, _Fecha_Vencimiento) = 0 Then
                        If Fx_Cambiar_Fechas_De_Documentos(_Tbl, False, _Fecha_Vencimiento) Then
                            Sb_Generar_Informe_Diario(_Fecha_Inicio, _Fecha_Fin)

                        End If
                    End If
                Else

                    Dim info As New TaskDialogInfo("Cambiar fechas de vencimiento",
                             eTaskDialogIcon.CheckMark2,
                              "¿Seleccione una opción?",
                              "Esto cambiara la fecha de los documentos seleccionados a una nueva fecha de vencimiento" & vbCrLf &
                              "Número de documentos: " & _Tbl.Rows.Count,
                              eTaskDialogButton.Ok + eTaskDialogButton.Cancel _
                              , eTaskDialogBackgroundColor.Red, _Radios, Nothing, Nothing, Nothing, Nothing)

                    Dim result As eTaskDialogResult = TaskDialog.Show(info)

                    If result = eTaskDialogResult.Ok Then

                        If Radio1.Checked Then
                            If Fx_Revisar_Si_Es_Posible_Cambiar_Fechas_De_Documentos(_Tbl, False, _Fecha_Vencimiento) = 0 Then
                                If Fx_Cambiar_Fechas_De_Documentos(_Tbl, False, _Fecha_Vencimiento) Then
                                    Sb_Generar_Informe_Diario(_Fecha_Inicio, _Fecha_Fin)

                                End If
                            End If
                        ElseIf Radio2.Checked Then
                            e.Effect = DragDropEffects.Copy
                            Sb_Mostrar_Detalle(True, Accion.Mover_Fechas, _Id_Correo, _Fecha_Vencimiento)

                        End If
                    End If
                End If
            End If

        End If

        _Fila.Cells(_Ex_Index_Columna).Style.BackColor = Color.White
        Grilla.Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex).Style.BackColor = Color.White

        Grilla.CurrentCell = Grilla.Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'Get the Index of Row which is being Dragged
        'We would use this Index on Drop to identify which Row was dragged and get the values from that row
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim _Index_Fila As Integer = Grilla.HitTest(e.X, e.Y).RowIndex
            Dim _Index_Columna As Integer = Grilla.HitTest(e.X, e.Y).ColumnIndex

            _Ex_Index_Fila = _Index_Fila
            _Ex_Index_Columna = _Index_Columna

            Dim NomColumna

            Try
                NomColumna = Grilla.Columns(_Index_Columna).Name.ToString()
            Catch ex As Exception
                Return
            End Try

            If NomColumna <> "ENDO" And NomColumna <> "SUENDO" And NomColumna <> "NOKOEN" Then

                Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

                Dim _Valo As Double = _Fila.Cells(_Index_Columna).Value

                If CBool(_Valo) Then
                    If _Index_Fila > -1 Then
                        ' Pass the Index as "Data" argument of the DoDragDrop Function
                        Grilla.DoDragDrop(Grilla.Rows(_Index_Fila), DragDropEffects.Move)
                    End If
                Else
                    Beep()
                End If
            End If

        End If
    End Sub

    Private Sub Sb_Grilla_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        'Just to Show a mouse icon to denote drop is allowed here

        Dim Point = Grilla.PointToClient(New Point(e.X, e.Y))
        Dim Hitest As DataGridView.HitTestInfo = Grilla.HitTest(Point.X, Point.Y)

        Dim _Index_Fila = Hitest.RowIndex
        Dim _Index_Columna = Hitest.ColumnIndex
        Dim _Cabeza_Destino As String = Grilla.Columns(Hitest.ColumnIndex).Name

        Dim _Fila As DataGridViewRow

        _Fila = Grilla.Rows(_Ex_Index_Fila)
        _Fila.Cells(_Ex_Index_Columna).Style.BackColor = Color.White

        _Fila = Grilla.Rows(_Index_Fila)

        _Ex_Index_Fila = _Index_Fila
        _Ex_Index_Columna = _Index_Columna

        Dim _Fila_Index_Actual As Integer = Grilla.CurrentRow.Index

        Dim _Valor = Trim(_Fila.Cells("NOKOEN").Value)

        If String.IsNullOrEmpty(_Valor) Or
           _Cabeza_Destino = "ENDO" Or
           _Cabeza_Destino = "RUT" Or
           _Cabeza_Destino = "NOKOEN" Or
           _Fila_Index_Actual <> _Index_Fila Then

            e.Effect = DragDropEffects.None
            '_Fila.Cells(_Index_Columna).Style.BackColor = Color.Red
        Else
            e.Effect = DragDropEffects.Move
            _Fila.Cells(_Index_Columna).Style.BackColor = Color.GreenYellow
        End If

        'If _Cabeza_Destino = "ENDO" Or _Cabeza_Destino = "SUENDO" Or _Cabeza_Destino = "NOKOEN" Then
        'e.Effect = DragDropEffects.None
        'Else
        'e.Effect = DragDropEffects.Move
        'End If



    End Sub

    Private Sub Sb_Grilla_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'If _Arrastrando Then
        Dim Hitest As DataGridView.HitTestInfo = Grilla.HitTest(e.X, e.Y)
        If Hitest.Type = DataGridViewHitTestType.Cell Then
            Grilla.CurrentCell = Grilla.Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
        End If
        '_Arrastrando = False
        'End If
    End Sub



    Function Fx_Tbl_Todos() As DataTable

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Endo = _Fila.Cells("ENDO").Value
        Dim _SuEndo = "" ' _Fila.Cells("SUENDO").Value

        If _Endo = "TOTAL" Then _Endo = String.Empty
        Dim _Fx_Fecha_Inicio, _Fx_Fecha_Fin As String

        If _Cabeza = "ENDO" Or _Cabeza = "NOKOEN" Then
            _Fx_Fecha_Inicio = Format(_Fecha_Inicio, "yyyyMMdd")
            _Fx_Fecha_Fin = Format(_Fecha_Fin, "yyyyMMdd")
        Else
            Dim _Fecha = Split(_Cabeza, "_")
            Dim _Fecha_Vencimiento As String = _Fecha(3) & _Fecha(2) & _Fecha(1)
            _Fx_Fecha_Inicio = _Fecha_Vencimiento
            _Fx_Fecha_Fin = _Fecha_Vencimiento
        End If

        Dim Fm As New Frm_Inf_Vencimientos_Detalle_Documentos(_Endo, _SuEndo, _SqlConsulta_informe,
                                                              _Fx_Fecha_Inicio, _Fx_Fecha_Fin,
                                                              Frm_Inf_Vencimientos_Detalle_Documentos.Accion.Mostrar_todo,
                                                              _Id_Correo, _Tipo_Informe)
        Fm.Sb_Generar_Informe()
        Dim _Tbl As DataTable = Fm.Pro_TblInforme 'Fm._TblInforme
        Fm.Dispose()
        Return _Tbl

    End Function


    Private Sub Btn_Cambiar_Fechas_Vencimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cambiar_Fechas_Vencimiento.Click

        Dim _Cambiar As Boolean

        If _Cambiando_Fecha_Vencimiento Then
            _Cambiar = False
        Else
            _Cambiar = True
        End If

        If Fx_Tiene_Permiso(Me, "Doc00006") Then '("Ope00001") Then
            Sb_Eventos_Arrastrar(_Cambiar)
        End If

    End Sub



    Private Sub Sb_Grilla_MouseDown_Boton_Derecho(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
                    Dim _Endo = _Fila.Cells("ENDO").Value

                    If _Endo <> "TOTAL" Then
                        Sb_Revisar_Columna()
                    End If
                    'ShowContextMenu(Menu_Contextual_01)
                End If
            End With
        End If
    End Sub

    Private Sub Grilla_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Grilla.ColumnHeaderMouseClick
        If _Tipo_Informe = Tipo_Informe.Diario Then
            Sb_Formato_Informe_Diario()
        ElseIf _Tipo_Informe = Tipo_Informe.Mensual Then
            Sb_Formato_Informe_Mensual()
        End If
    End Sub


    Private Sub Btn_Mostrar_deuda_actual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Mostrar_deuda_actual.Click
        Sb_Mostrar_Detalle(False, Accion.Mostrar_todo, _Id_Correo)
    End Sub


    Private Sub Btn_Mostrar_deuda_completa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Mostrar_deuda_completa.Click
        Sb_Mostrar_Detalle(False, Accion.Mostrar_todo, 0, "", True)
    End Sub

    Private Sub Btn_Enviar_Correo_Cobranza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Enviar_Correo_Cobranza.Click
        Sb_Mostrar_Detalle(False, Accion.Cobranza, _Id_Correo)
    End Sub

    Private Sub Btn_Buscar_Entidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Buscar_Entidad.Click

        Dim Fm As New Frm_BuscarEntidad_Mt(False)
        Fm.ShowDialog(Me)

        If Not (Fm.Pro_RowEntidad Is Nothing) Then

            Dim _Koen As String = Trim(Fm.Pro_RowEntidad.Item("KOEN"))

            Dim _Rt = Trim(Fm.Pro_RowEntidad.Item("RTEN"))
            Dim _Rut As String

            _Rut = FormatNumber(Val(_Rt), 0) & "-" & RutDigito(_Rt)

            If BuscarDatoEnGrilla(_Rut, "RUT", Grilla) Then
                Grilla.CurrentCell = Grilla.Rows(Grilla.CurrentRow.Index).Cells("RUT")
                Grilla.Focus()
            Else
                MessageBoxEx.Show(Me, "Esta entidad no se encontro en la lista actual",
                                  "Buscar entidad", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If
        End If
        Fm.Dispose()

    End Sub

    Private Sub Btn_Ficha_Entidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Ficha_Entidad.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Endo = _Fila.Cells("ENDO").Value
        Dim _SuEndo = String.Empty

        Dim Fm As New Frm_Crear_Entidad_Mt
        Fm.Fx_Llenar_Entidad(_Endo, _SuEndo)
        Fm.CrearEntidad = False
        Fm.EditarEntidad = True
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Mnu_Enviar_Correo_Cobranza_Deuda_Completa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Enviar_Correo_Cobranza_Deuda_Completa.Click
        Sb_Mostrar_Detalle(False, Accion.Cobranza, _Id_Correo, , True)
    End Sub


    Public Property Pro_Chk_Deuda_Efectiva()
        Get
            Return _Chk_Deuda_Efectiva
        End Get
        Set(ByVal value)
            _Chk_Deuda_Efectiva = value
            If value Then
                Btn_Cambiar_Fechas_Vencimiento.Visible = False
            End If
        End Set
    End Property


    Public Property Pro_Filtro_Maeedo() As String
        Get
            Return _Filtro_Maeedo
        End Get
        Set(ByVal value As String)
            _Filtro_Maeedo = value
        End Set
    End Property

    Public Property Pro_Filtro_Maedpce() As String
        Get
            Return _Filtro_Maedpce
        End Get
        Set(ByVal value As String)
            _Filtro_Maedpce = value
        End Set
    End Property



End Class
