Public Class Frm_InformePtosClientes

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Row_Entidad As DataRow
    Private _Tbl_Informe As DataTable
    Private _Koen As String
    Private _Suen As String

    Public Sub New(Koen As String, Suen As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Koen = Koen
        _Suen = Suen
        _Row_Entidad = Fx_Traer_Datos_Entidad(Koen, Suen)

        Sb_Formato_Generico_Grilla(Grilla_Detalle, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_InformePtosClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Txt_Entidad.Text = _Row_Entidad.Item("KOEN").ToString.Trim & " - " & _Row_Entidad.Item("NOKOEN")

        AddHandler Grilla_Detalle.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select CodEntidad,CodSucEntidad," &
                       "Case when Nudonodefi = 0 then SUM(PtsGanados) Else 0 End As 'PtsGanados',Sum(PtsUsados) As 'PtsUsados'" & vbCrLf &
                       "Into #Paso" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_PtsVta_Doc" & vbCrLf &
                       "Where CodEntidad = '" & _Koen & "' And CodSucEntidad = '" & _Suen & "'" & vbCrLf &
                       "Group by CodEntidad,CodSucEntidad,Nudonodefi" & vbCrLf &
                       "Select CodEntidad,CodSucEntidad,NOKOEN,PtsGanados As 'PuntosGanados',PtsUsados As 'PuntosUtilizados',PtsGanados-PtsUsados As PuntosAFavor" & vbCrLf &
                       "From #Paso" & vbCrLf &
                       "Inner Join SIERRALTA_PRB.dbo.MAEEN On KOEN = CodEntidad And SUEN = CodSucEntidad" & vbCrLf &
                       "Select *,Case When Nudonodefi = 1 Then 0 Else PtsGanados end As 'Ptos_Acumulados',PtsUsados As 'Ptos_Utilizados'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_PtsVta_Doc" & vbCrLf &
                       "Where CodEntidad = '" & _Koen & "' And CodSucEntidad = '" & _Suen & "'" & vbCrLf &
                       "Order by Id" & vbCrLf &
                       "Drop table #Paso"

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Tbl_Informe = _Ds.Tables(1)

        With Grilla_Detalle

            .DataSource = _Tbl_Informe

            OcultarEncabezadoGrilla(Grilla_Detalle, True)

            Dim _DisplayIndex = 0

            .Columns("Tido").Width = 30
            .Columns("Tido").HeaderText = "TD"
            .Columns("Tido").ReadOnly = True
            .Columns("Tido").Visible = True
            .Columns("Tido").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nudo").Width = 90
            .Columns("Nudo").HeaderText = "Número"
            .Columns("Nudo").ReadOnly = True
            .Columns("Nudo").Visible = True
            .Columns("Nudo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Feemdo").HeaderText = "F.Emisión"
            .Columns("Feemdo").Width = 70
            .Columns("Feemdo").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Feemdo").Visible = True
            .Columns("Feemdo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Vabrdo").Width = 100
            .Columns("Vabrdo").HeaderText = "Monto"
            .Columns("Vabrdo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Vabrdo").DefaultCellStyle.Format = "$ ###,##0.##"
            .Columns("Vabrdo").Visible = True
            .Columns("Vabrdo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Ptos_Acumulados").Width = 120
            .Columns("Ptos_Acumulados").HeaderText = "Puntos Ganados"
            .Columns("Ptos_Acumulados").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Ptos_Acumulados").DefaultCellStyle.Format = "###,###.##"
            .Columns("Ptos_Acumulados").Visible = True
            .Columns("Ptos_Acumulados").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Ptos_Utilizados").Width = 120
            .Columns("Ptos_Utilizados").HeaderText = "Puntos Utilizados"
            .Columns("Ptos_Utilizados").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Ptos_Utilizados").DefaultCellStyle.Format = "###,###.##"
            .Columns("Ptos_Utilizados").Visible = True
            .Columns("Ptos_Utilizados").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Refresh()

        End With

        Dim _Row_Ptos As DataRow = _Ds.Tables(0).Rows(0)

        Lbl_PuntosGanados.Text = FormatNumber(_Row_Ptos.Item("PuntosGanados"), 0)
        Lbl_PuntosUtilizados.Text = FormatNumber(_Row_Ptos.Item("PuntosUtilizados"), 0)
        Lbl_PuntosAFavor.Text = FormatNumber(_Row_Ptos.Item("PuntosAFavor"), 0)

    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_Informe, Me, "Puntos")
    End Sub
End Class
