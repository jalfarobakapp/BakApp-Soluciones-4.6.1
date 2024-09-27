'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Inf_Vencimientos_Detalle_Documento_Consolidado

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _TblInforme As DataTable

    Dim _Fecha_Inicio As String
    Dim _Fecha_Fin As String

    Dim _Filtro_Maeedo, _
        _Filtro_Maedpce As String

    Dim _SqlConsulta_informe As String

    Dim _Mostrar_Pagos_Pendientes As Boolean

    Public Sub New(ByVal SqlConsulta_informe As String, _
                   ByVal Mostrar_Pagos_Pendientes As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Mostrar_Pagos_Pendientes = Mostrar_Pagos_Pendientes

        _SqlConsulta_informe = SqlConsulta_informe
       Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Inf_Vencimientos_Detalle_Documento_Consolidado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
    End Sub

    Sub Sb_Generar_Informe(ByVal _Fx_Fecha_Inicio As Date, _
                           ByVal _Fx_Fecha_Fin As Date)

        Consulta_sql = _SqlConsulta_informe

        _Fecha_Inicio = Format(_Fx_Fecha_Inicio, "yyyyMMdd")
        _Fecha_Fin = Format(_Fx_Fecha_Fin, "yyyyMMdd")

        Consulta_sql = Replace(Consulta_sql, "#Fecha_Inicio#", _Fecha_Inicio)
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Fin#", _Fecha_Fin)

        Consulta_sql = Replace(Consulta_sql, "#Fecha_Inicio#", _Fecha_Inicio)
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Fin#", _Fecha_Fin)

        Consulta_sql = Replace(Consulta_sql, "--#Filtro_Adicional_Maeedo#", _Filtro_Maeedo)
        Consulta_sql = Replace(Consulta_sql, "--#Filtro_Adicional_Maedpce#", _Filtro_Maedpce)

        If Not _Mostrar_Pagos_Pendientes Then
            Consulta_sql += vbCrLf & vbCrLf & "Delete #INFVEN Where Deuda = 'Pagos'" & vbCrLf & vbCrLf
        End If

        Consulta_sql += _
                       "--UPDATE #INFVEN SET DIAS_ATRASO = 0 WHERE TIDO = 'NCV'" & vbCrLf & _
                       "Select TIDO,Tipo," & vbCrLf & _
                       "Isnull((Select SUM(SALDO) " & _
                       "From #INFVEN Zw Where Inf.Tipo = Zw.Tipo And Inf.TIDO = Zw.TIDO And Zw.DIAS_ATRASO > 0),0) As POR_VENCER," & vbCrLf & _
                       "CAST(0 AS Float) As PORC_POR_VENCER," & vbCrLf & _
                       "Isnull((Select SUM(SALDO) " & _
                       "From #INFVEN Zw Where Inf.Tipo = Zw.Tipo And Inf.TIDO = Zw.TIDO And Zw.DIAS_ATRASO <= 0),0) As VENCIDOS," & vbCrLf & _
                       "CAST(0 AS Float) As PORC_VENCIDOS," & vbCrLf & _
                       "SUM(SALDO) AS SALDO," & vbCrLf & _
                       "CAST(0 AS Float) As PORC_SALDO," & vbCrLf & _
                       "(Select COUNT (DISTINCT RTEN) From #INFVEN Where Inf.Tipo = #INFVEN.Tipo And Inf.TIDO = #INFVEN.TIDO) As CLIENTES" & vbCrLf & _
                       "Into #INF_CONSOLIDADO" & vbCrLf & _
                       "From #INFVEN Inf" & vbCrLf & _
                       "Group By TIDO,Tipo" & vbCrLf & _
                       "Order By TIDO,Tipo" & vbCrLf & vbCrLf & _
                       "UPDATE #INF_CONSOLIDADO SET " & _
                       "PORC_POR_VENCER = Case POR_VENCER When 0 Then 0 Else ROUND(POR_VENCER/(SELECT SUM(POR_VENCER) " & _
                       "FROM #INF_CONSOLIDADO),5) End," & vbCrLf & _
                       "PORC_VENCIDOS = Case VENCIDOS When 0 Then 0 Else ROUND( VENCIDOS/(SELECT SUM(VENCIDOS) " & _
                       "FROM #INF_CONSOLIDADO),5) End," & vbCrLf & _
                       "PORC_SALDO = Case SALDO When 0 Then 0 Else ROUND(VENCIDOS/(SELECT SUM(SALDO) FROM #INF_CONSOLIDADO),5) End" & vbCrLf & _
                       "SELECT * FROM #INF_CONSOLIDADO" & vbCrLf & vbCrLf & _
                       "Drop Table #INFVEN" & vbCrLf & _
                       "Drop Table #INF_CONSOLIDADO"


        _TblInforme = _SQL.Fx_Get_DataTable(Consulta_sql)


        Grilla.DataSource = _TblInforme

        With Grilla

            OcultarEncabezadoGrilla(Grilla)

            .Columns("TIDO").HeaderText = "Tipo" '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("TIDO").Width = 30
            .Columns("TIDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = 0
            .Columns("TIDO").ReadOnly = True

            .Columns("Tipo").HeaderText = "Documento" '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("Tipo").Width = 230
            '.Columns("Tipo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Tipo").Visible = True
            .Columns("Tipo").DisplayIndex = 1
            .Columns("Tipo").ReadOnly = True

            .Columns("POR_VENCER").HeaderText = "$ Por Vencer" '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("POR_VENCER").Width = 95
            .Columns("POR_VENCER").DefaultCellStyle.Format = "$ ###,##"
            .Columns("POR_VENCER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("POR_VENCER").Visible = True
            .Columns("POR_VENCER").DisplayIndex = 2
            .Columns("POR_VENCER").ReadOnly = True

            .Columns("PORC_POR_VENCER").HeaderText = "%" '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("PORC_POR_VENCER").Width = 55
            .Columns("PORC_POR_VENCER").DefaultCellStyle.Format = "###.## %"
            .Columns("PORC_POR_VENCER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PORC_POR_VENCER").Visible = True
            .Columns("PORC_POR_VENCER").DisplayIndex = 3
            .Columns("PORC_POR_VENCER").ReadOnly = True

            .Columns("VENCIDOS").HeaderText = "$ Vencidos" '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("VENCIDOS").Width = 90
            .Columns("VENCIDOS").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VENCIDOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VENCIDOS").Visible = True
            .Columns("VENCIDOS").DisplayIndex = 4
            .Columns("VENCIDOS").ReadOnly = True

            .Columns("PORC_VENCIDOS").HeaderText = "%" '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("PORC_VENCIDOS").Width = 55
            .Columns("PORC_VENCIDOS").DefaultCellStyle.Format = "###.## %"
            .Columns("PORC_VENCIDOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PORC_VENCIDOS").Visible = True
            .Columns("PORC_VENCIDOS").DisplayIndex = 5
            .Columns("PORC_VENCIDOS").ReadOnly = True

            .Columns("SALDO").HeaderText = "$ Saldo" '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("SALDO").Width = 90
            .Columns("SALDO").DefaultCellStyle.Format = "$ ###,##"
            .Columns("SALDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO").Visible = True
            .Columns("SALDO").DisplayIndex = 6
            .Columns("SALDO").ReadOnly = True

            .Columns("PORC_SALDO").HeaderText = "%" '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("PORC_SALDO").Width = 55
            .Columns("PORC_SALDO").DefaultCellStyle.Format = "###.## %"
            .Columns("PORC_SALDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PORC_SALDO").Visible = True
            .Columns("PORC_SALDO").DisplayIndex = 7
            .Columns("PORC_SALDO").ReadOnly = True

            .Columns("CLIENTES").HeaderText = "Clientes" '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("CLIENTES").Width = 70
            '.Columns("CLIENTES").DefaultCellStyle.Format = "$ ###,##"
            .Columns("CLIENTES").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CLIENTES").Visible = True
            .Columns("CLIENTES").DisplayIndex = 8
            .Columns("CLIENTES").ReadOnly = True

        End With

        Dim _Por_Vencer As Double
        Dim _Vencidos As Double
        Dim _Saldos As Double

        For Each _Fila As DataRow In _TblInforme.Rows

            _Por_Vencer += _Fila.Item("POR_VENCER")
            _Vencidos += _Fila.Item("VENCIDOS")
            _Saldos += _Fila.Item("SALDO")

        Next

        Lbl_Por_Vencer.Text = FormatCurrency(Math.Round(_Por_Vencer, 0), 0)
        Lbl_Vencidos.Text = FormatCurrency(Math.Round(_Vencidos, 0), 0)
        Lbl_Saldos.Text = FormatCurrency(Math.Round(_Saldos), 0)


    End Sub

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

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Tido = Trim(_Fila.Cells("Tido").Value)
        Dim _Tipo = Trim(_Fila.Cells("Tipo").Value)
        Dim _Valor = _Fila.Cells(_Cabeza).Value


        Dim Fm As New Frm_Inf_Vencimientos_Detalle_Documentos("ZZZZZZ", "",
                                                              _SqlConsulta_informe,
                                                              _Fecha_Inicio,
                                                              _Fecha_Fin,
                                                              Frm_Inf_Vencimientos_Detalle_Documentos.Accion.Mostrar_todo, 0,
                                                              Frm_Inf_Vencimientos_Detalle_Documentos.Tipo_Informe.Ventas)

        'Fm._Nueva_Fecha_Vencimiento = _Nueva_Fecha_Vencimien
        Fm.Pro_Mover_Fechas = False '_Mover_Fechas = False
        Fm.Pro_Chk_Deuda_Efectiva = _Mostrar_Pagos_Pendientes

        Fm.Pro_Filtro_Maeedo = _Filtro_Maeedo
        Fm.Pro_Filtro_Maedpce = _Filtro_Maedpce

        Dim _Condicion As String = String.Empty

        If _Cabeza = "POR_VENCER" Or _Cabeza = "PORC_POR_VENCER" Or _Cabeza = "VENCIDOS" Or _Cabeza = "PORC_VENCIDOS" Then
            Select Case _Cabeza
                Case "POR_VENCER", "PORC_POR_VENCER"
                    _Condicion = "And DIAS_ATRASO > 0"
                Case "VENCIDOS", "PORC_VENCIDOS"
                    _Condicion = "And DIAS_ATRASO <= 0"
            End Select
            If Not CBool(_Valor) Then

                Beep()
                ToastNotification.Show(Me, "NO EXISTE INFORMACION",
                                       My.Resources.cross,
                                       1 * 1000, eToastGlowColor.Red,
                                       eToastPosition.MiddleCenter)

                'MessageBoxEx.Show(Me, "No existe información", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

        Consulta_sql = "Where TIDO = '" & _Tido & "' And Tipo = '" & _Tipo & "'" & vbCrLf & _Condicion

        Fm.Sb_Generar_Informe(Consulta_sql)

        Fm.ShowDialog(Me)

    End Sub


    Private Sub Btn_Exportar_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar_Excel.Click
        ExportarTabla_JetExcel_Tabla(_TblInforme, Me, "Informe consolidado")
    End Sub

   
End Class