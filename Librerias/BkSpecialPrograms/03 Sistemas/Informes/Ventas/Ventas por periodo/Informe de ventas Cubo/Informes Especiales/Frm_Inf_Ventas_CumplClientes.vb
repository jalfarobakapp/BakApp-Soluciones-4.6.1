Imports BkSpecialPrograms.Frm_Tickets_Lista
Imports DevComponents.DotNetBar
Public Class Frm_Inf_Ventas_CumplClientes

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Tbl_Informe As DataTable

    Dim _FechaDesde As Date
    Dim _FechaHasta As Date

    Dim _Tbl_FiltroVendedores As DataTable

    Public Sub New(_FechaDesde As Date, _FechaHasta As Date, _Tbl_FiltroVendedores As DataTable)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._FechaDesde = _FechaDesde
        Me._FechaHasta = _FechaHasta
        Me._Tbl_FiltroVendedores = _Tbl_FiltroVendedores

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Inf_Ventas_CumplClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text += " " & _FechaDesde.ToShortDateString & " - " & _FechaHasta.ToShortDateString

        Sb_Actualizar_Grilla()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub


    Sub Sb_Actualizar_Grilla()

        Dim _Filtro_Extra As String = Generar_Filtro_IN(_Tbl_FiltroVendedores, "", "KOFU", False, False, "'")

        Consulta_Sql = "
Declare @FechaDesde As datetime = '" & Format(_FechaDesde, "yyyyMMdd") & "'
Declare @FechaHasta As datetime = '" & Format(_FechaHasta, "yyyyMMdd") & "'

Select KOFU,NOKOFU,CAST(0 As Int) As Clientes,CAST(0 As Int) As Clientes_Atendidos,CAST(0 As Int) As Clientes_NOAtendidos,CAST(0 As Float) As Porc_Atencion 
Into #PasoCl
From TABFU
--Where KOFU In (Select Distinct KOFULIDO From Zw_Informe_Venta Where FEEMDO BETWEEN @FechaDesde And @FechaHasta And PRCT = 0)
Where KOFU In " & _Filtro_Extra & "

Update #PasoCl Set Clientes = (Select COUNT(*) From MAEEN Where KOFUEN = KOFU)
Update #PasoCl Set Clientes_Atendidos = (Select COUNT(*) From MAEEN Where KOEN+SUEN IN (Select ENDO+SUENDO From
										 Zw_Informe_Venta Where KOFULIDO = #PasoCl.KOFU And FEEMDO BETWEEN @FechaDesde And @FechaHasta And PRCT = 0) And KOFUEN = #PasoCl.KOFU)
Update #PasoCl Set Porc_Atencion = Clientes_Atendidos*1.0000/Clientes*1.0000 Where Clientes > 0
Update #PasoCl Set Clientes_NOAtendidos = Clientes-Clientes_Atendidos Where Clientes > Clientes_Atendidos

Select KOFU,NOKOFU,Clientes,Clientes_Atendidos,Clientes_NOAtendidos,ROUND(Porc_Atencion,2) As Porc_Atencion From #PasoCl

Drop Table #PasoCl"

        _Tbl_Informe = _Sql.Fx_Get_DataTable(Consulta_Sql)

        With Grilla

            .DataSource = _Tbl_Informe

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            '.Columns("BtnImagen_Tag").Width = 50
            '.Columns("BtnImagen_Tag").HeaderText = "Tag"
            '.Columns("BtnImagen_Tag").Visible = True
            '.Columns("BtnImagen_Tag").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("KOFU").Visible = True
            .Columns("KOFU").HeaderText = "Ven."
            .Columns("KOFU").Width = 40
            .Columns("KOFU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOFU").Visible = True
            .Columns("NOKOFU").HeaderText = "Nombre vendedor"
            .Columns("NOKOFU").Width = 230
            .Columns("NOKOFU").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Clientes").Visible = True
            .Columns("Clientes").HeaderText = "Clientes Asignados"
            .Columns("Clientes").ToolTipText = "Total de clientes asignados al vendedor"
            .Columns("Clientes").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Clientes").Width = 80
            .Columns("Clientes").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Clientes_Atendidos").Visible = True
            .Columns("Clientes_Atendidos").HeaderText = "Clientes Atendidos"
            .Columns("Clientes_Atendidos").ToolTipText = "Total de clientes atendidos durante este periodo"
            .Columns("Clientes_Atendidos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Clientes_Atendidos").Width = 70
            .Columns("Clientes_Atendidos").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Clientes_NOAtendidos").Visible = True
            .Columns("Clientes_NOAtendidos").HeaderText = "Clientes No Atendidos"
            .Columns("Clientes_NOAtendidos").ToolTipText = "Total de clientes sin antender durante este periodo"
            .Columns("Clientes_NOAtendidos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Clientes_NOAtendidos").Width = 70
            .Columns("Clientes_NOAtendidos").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Porc_Atencion").Visible = True
            .Columns("Porc_Atencion").HeaderText = "Porcentaje Atendidos"
            .Columns("Porc_Atencion").ToolTipText = "Porcentaje de cumplimiento de atención de cartera de clientes en el periodo"
            .Columns("Porc_Atencion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_Atencion").DefaultCellStyle.Format = "% ###,##0.##"
            .Columns("Porc_Atencion").Width = 100
            .Columns("Porc_Atencion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_Informe, Me, "Ventas clientes Vs atencion")
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Kofuen As String = _Fila.Cells("KOFU").Value
        Dim _Cabeza As String = Grilla.Columns(e.ColumnIndex).Name
        Dim _Texto As String

        If _Cabeza <> "Clientes" And _Cabeza <> "Clientes_Atendidos" And _Cabeza <> "Clientes_NOAtendidos" Then
            Return
        End If

        Consulta_Sql = "Declare @FechaDesde As datetime = '" & Format(_FechaDesde, "yyyyMMdd") & "'" & vbCrLf &
                       "Declare @FechaHasta As datetime = '" & Format(_FechaHasta, "yyyyMMdd") & "'" & vbCrLf &
                       "Select KOEN,SUEN,NOKOEN,KOEN+SUEN As KS" & vbCrLf &
                       "Into #PasoAsignados" & vbCrLf &
                       "From MAEEN" & vbCrLf &
                       "Where KOFUEN = '" & _Kofuen & "'" & vbCrLf &
                       "Select KOEN, SUEN, NOKOEN, KOEN + SUEN As KS" & vbCrLf &
                       "Into #PasoAntendidos" & vbCrLf &
                       "From MAEEN" & vbCrLf &
                       "Where KOFUEN = '" & _Kofuen & "' And KOEN+SUEN In (Select ENDO+SUENDO From Zw_Informe_Venta Where KOFULIDO = '" & _Kofuen & "' And FEEMDO BETWEEN @FechaDesde And @FechaHasta And PRCT = 0)" & vbCrLf &
                       "Select KOEN,SUEN,NOKOEN,KOEN+SUEN As KS" & vbCrLf &
                       "Into #PasoNoAntendidos" & vbCrLf &
                       "From MAEEN" & vbCrLf &
                       "Where KOFUEN = '" & _Kofuen & "' And KOEN+SUEN Not In (Select KOEN+SUEN From #PasoAntendidos)" & vbCrLf &
                       "Select * From #PasoAsignados" & vbCrLf &
                       "Select * From #PasoAntendidos" & vbCrLf &
                       "Select * From #PasoNoAntendidos" & vbCrLf &
                       "Drop table #PasoAsignados" & vbCrLf &
                       "Drop table #PasoAntendidos" & vbCrLf &
                       "Drop table #PasoNoAntendidos"

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql)

        Dim _Tbl_Asignados As DataTable = _Ds.Tables(0)
        Dim _Tbl_Atendidos As DataTable = _Ds.Tables(1)
        Dim _Tbl_NoAtendidos As DataTable = _Ds.Tables(2)

        Dim _Tbl As DataTable

        Select Case _Cabeza
            Case "Clientes"
                _Texto = "CLIENTES ASIGNADOS AL VENDEDOR"
                _Tbl = _Tbl_Asignados
            Case "Clientes_Atendidos"
                _Texto = "CLIENTES ATENDIDOS"
                _Tbl = _Tbl_Atendidos
            Case "Clientes_NOAtendidos"
                _Texto = "CLIENTES NO ATENDIDOS"
                _Tbl = _Tbl_NoAtendidos
        End Select

        If IsNothing(_Tbl) OrElse _Tbl.Rows.Count = 0 Then
            MessageBoxEx.Show(Me, "No hay datos que mostrar", _Texto, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Filtro As String = Generar_Filtro_IN(_Tbl, "", "KS", False, False, "'")
        Dim _Sql_Filtro_Condicion_Extra = "And KOFUEN = '" & _Kofuen & "' And KOEN+SUEN In " & _Filtro

        Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Otra)
        Fm.Pro_Tabla = "MAEEN"
        Fm.Pro_Campo = "KOEN"
        Fm.Pro_Descripcion = "NOKOEN"
        Fm.Pro_Seleccionar_Solo_Uno = True
        Fm.Pro_Requiere_Seleccion = False
        'Fm.Pro_Tbl_Filtro = _Cl_Buscar.Tbl_Sub_Tipo_Reclamo
        Fm.Text = _Texto
        Fm.Pro_Sql_Filtro_Condicion_Extra = _Sql_Filtro_Condicion_Extra
        Fm.MostrarNumeracionDeRegistros = True
        'Fm.Pro_Orden_By = "ORDER BY Orden"
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

End Class
