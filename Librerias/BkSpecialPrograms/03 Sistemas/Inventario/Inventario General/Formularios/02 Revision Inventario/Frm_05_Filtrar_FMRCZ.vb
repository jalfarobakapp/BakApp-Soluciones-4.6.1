'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_05_Filtrar_FMRCZ

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _SuperFamilia, _Familia, _SubFamilia As String
    Public _IdInventario As Integer
    Dim _SqlExcel As String

    Dim _TblInf As DataTable

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        caract_combo(CmbxSuperFamilia)
        Consulta_sql = "SELECT '' AS Padre,'Todas' AS Hijo " & vbCrLf & "Union" & vbCrLf & _
                       "SELECT KOFM AS Padre,NOKOFM AS Hijo FROM TABFM ORDER BY Padre" ' WHERE SEMILLA = " & Actividad
        CmbxSuperFamilia.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)
        _SuperFamilia = String.Empty
        CmbxSuperFamilia.SelectedValue = _SuperFamilia
        _Familia = String.Empty
        _SubFamilia = String.Empty

       Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 7), Color.PaleGoldenrod, ScrollBars.Vertical, False, False, False)

    End Sub

    Private Sub CmbxSuperFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxSuperFamilia.SelectedIndexChanged
        Try

            _SuperFamilia = CmbxSuperFamilia.SelectedValue.ToString

            _Familia = String.Empty
            _SubFamilia = String.Empty

            CmbxFamilia.DataSource = Nothing
            CmbxSubFamilia.DataSource = Nothing

            caract_combo(CmbxFamilia)
            Consulta_sql = "SELECT '' AS Padre,'Todas' AS Hijo " & vbCrLf & "Union" & vbCrLf & _
                           "SELECT KOPF AS Padre,' '+RTRIM(LTRIM(KOPF))+' -'+NOKOPF AS Hijo FROM TABPF WHERE KOFM = '" & _SuperFamilia & "'"
            CmbxFamilia.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)

            CmbxFamilia.SelectedValue = _Familia

            'CmbxComuna.Text = Comuna
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbxFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbxFamilia.SelectedIndexChanged
        Try
            _Familia = CmbxFamilia.SelectedValue.ToString
        Catch ex As Exception

        Finally

            _SubFamilia = String.Empty
            CmbxSubFamilia.DataSource = Nothing

            caract_combo(CmbxSubFamilia)
            Consulta_sql = "SELECT '' AS Padre,'Todas' AS Hijo " & vbCrLf & "Union" & vbCrLf & _
                           "SELECT KOHF AS Padre, NOKOHF AS Hijo FROM TABHF WHERE KOFM = '" & _SuperFamilia & "' AND KOPF = '" & _Familia & "'"
            CmbxSubFamilia.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)
            CmbxSubFamilia.SelectedValue = _SubFamilia

        End Try
    End Sub


    Sub ActualizarGrillaInformeInv()

        Consulta_sql = "Select * From  ZW_TmpInvFotoInventario" & vbCrLf & _
                       "Where IdInventario = " & _IdInventario & " And SuperFamilia LIKE '%" & _SuperFamilia & "%' AND" & vbCrLf & _
                       "Familia LIKE '%" & _Familia & "%' AND" & vbCrLf & _
                       "SubFamilia LIKE '%" & _SubFamilia & "%'"
        _SqlExcel = Consulta_sql

        _TblInf = _SQL.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _TblInf

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("CodigoPR").Width = 100
            .Columns("CodigoPR").HeaderText = "Código"
            .Columns("CodigoPR").Visible = True

            .Columns("CodigoTePR").Width = 110
            .Columns("CodigoTePR").HeaderText = "Código Tec."
            .Columns("CodigoTePR").Visible = True

            .Columns("DescripcionPR").Width = 250
            .Columns("DescripcionPR").HeaderText = "Descripción"
            .Columns("DescripcionPR").Visible = True

            .Columns("StFisicoUd1").Width = 50
            .Columns("StFisicoUd1").HeaderText = "Foto Stock"
            .Columns("StFisicoUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StFisicoUd1").Visible = True

            .Columns("Cant_Inventariada").Width = 50
            .Columns("Cant_Inventariada").HeaderText = "Contado"
            .Columns("Cant_Inventariada").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cant_Inventariada").Visible = True

            .Columns("PPP").Width = 50
            .Columns("PPP").HeaderText = "P.P.P"
            .Columns("PPP").DefaultCellStyle.Format = "$ ###,##"
            .Columns("PPP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PPP").Visible = True

            .Columns("PUltCompra").Width = 50
            .Columns("PUltCompra").HeaderText = "C.Ult.C"
            .Columns("PUltCompra").DefaultCellStyle.Format = "$ ###,##"
            .Columns("PUltCompra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PUltCompra").Visible = True

            .Columns("Nom_SuperFamilia").Width = 100
            .Columns("Nom_SuperFamilia").HeaderText = "Super Familia"
            .Columns("Nom_SuperFamilia").Visible = True

            .Columns("Nom_Familia").Width = 150
            .Columns("Nom_Familia").HeaderText = "Familia"
            .Columns("Nom_Familia").Visible = True

            .Columns("Nom_SubFamilia").Width = 150
            .Columns("Nom_SubFamilia").HeaderText = "Sub Familia"
            .Columns("Nom_SubFamilia").Visible = True


        End With
        'CantInventariada PPP PUltCompra
        SumarTotales()
    End Sub

    Sub SumarTotales()
        Dim PPP = Fx_Suma_cantidades( "ISNULL(Cant_Inventariada, 0)*ISNULL(PPP,0)", "ZW_TmpInvFotoInventario", _
                                  "IdInventario = " & _IdInventario & vbCrLf & _
                                  "And SuperFamilia LIKE '%" & _SuperFamilia & "%' AND" & vbCrLf & _
                                  "Familia LIKE '%" & _Familia & "%' AND" & vbCrLf & _
                                  "SubFamilia LIKE '%" & _SubFamilia & "%'")

        Dim CUC = Fx_Suma_cantidades( "ISNULL(Cant_Inventariada, 0)*ISNULL(PUltCompra,0)", "ZW_TmpInvFotoInventario", _
                                  "IdInventario = " & _IdInventario & vbCrLf & _
                                  "And SuperFamilia LIKE '%" & _SuperFamilia & "%' AND" & vbCrLf & _
                                  "Familia LIKE '%" & _Familia & "%' AND" & vbCrLf & _
                                  "SubFamilia LIKE '%" & _SubFamilia & "%'")


        TxtTotalPPP.Text = FormatCurrency(PPP, 0)
        TxtTotalCUC.Text = FormatCurrency(CUC, 0)


    End Sub


    Private Sub Frm_05_Filtrar_FMRCZ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TxtTotalCUC.TextAlign = HorizontalAlignment.Right
        TxtTotalPPP.TextAlign = HorizontalAlignment.Right
        ActualizarGrillaInformeInv()
    End Sub



    Private Sub ButtonItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem1.Click
        ExportarTabla_JetExcel(_SqlExcel, Me, _
                               "Inventario Filtro Familias " & CmbxSuperFamilia.Text & "-" & CmbxFamilia.Text & "-" & CmbxSubFamilia.Text)
    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        ActualizarGrillaInformeInv()
    End Sub
End Class