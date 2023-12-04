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

Select KOFU,NOKOFU,CAST(0 As Int) As Clientes,CAST(0 As Int) As Clientes_Atendidos, CAST(0 As Float) As Porc_Atencion 
Into #PasoCl
From TABFU
--Where KOFU In (Select Distinct KOFULIDO From Zw_Informe_Venta Where FEEMDO BETWEEN @FechaDesde And @FechaHasta And PRCT = 0)
Where KOFU In " & _Filtro_Extra & "

Update #PasoCl Set Clientes = (Select COUNT(*) From MAEEN Where KOFUEN = KOFU)
Update #PasoCl Set Clientes_Atendidos = (Select COUNT(*) From MAEEN Where KOEN+SUEN IN (Select ENDO+SUENDO From
										 Zw_Informe_Venta Where KOFULIDO = #PasoCl.KOFU And FEEMDO BETWEEN @FechaDesde And @FechaHasta And PRCT = 0))
Update #PasoCl Set Porc_Atencion = Clientes_Atendidos*1.0000/Clientes*1.0000 Where Clientes > 0

Select KOFU,NOKOFU,Clientes,Clientes_Atendidos,ROUND(Porc_Atencion,2) As Porc_Atencion From #PasoCl

Drop Table #PasoCl"

        _Tbl_Informe = _Sql.Fx_Get_Tablas(Consulta_Sql)

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
            .Columns("NOKOFU").Width = 290
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
            .Columns("Clientes_Atendidos").ToolTipText = "Total de clientes atendidos en el periodo"
            .Columns("Clientes_Atendidos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Clientes_Atendidos").Width = 80
            .Columns("Clientes_Atendidos").DisplayIndex = _DisplayIndex
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
End Class
