'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_InvMargenes_Grf_Res


    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Informe As DataTable
    Dim _Tbl_Detalle As DataTable

    Public Property Tbl_Informe As DataTable
        Get
            Return _Tbl_Informe
        End Get
        Set(value As DataTable)
            _Tbl_Informe = value
        End Set
    End Property

    Public Property Tbl_Detalle As DataTable
        Get
            Return _Tbl_Detalle
        End Get
        Set(value As DataTable)
            _Tbl_Detalle = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(GrillaResumen, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            BtnExportarExcel.ForeColor = Color.White
        End If

    End Sub
    Private Sub Frm_InvMargenes_Grf_Res_Load(sender As Object, e As EventArgs) Handles Me.Load

        AddHandler GrillaResumen.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        With GrillaResumen

            .DataSource = _Tbl_Informe

            OcultarEncabezadoGrilla(GrillaResumen, False)

            .Columns("Koprct").Width = 100
            .Columns("Koprct").HeaderText = "Código"
            .Columns("Koprct").Visible = True

            .Columns("Nokopr").Width = 350
            .Columns("Nokopr").HeaderText = "Descripción"
            .Columns("Nokopr").Visible = True

            .Columns("CantidadUd1").Width = 60
            .Columns("CantidadUd1").HeaderText = "Cant. Ud1"
            .Columns("CantidadUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantidadUd1").DefaultCellStyle.Format = "###,##"
            .Columns("CantidadUd1").Visible = True

            .Columns("TotalCosto").Width = 80
            .Columns("TotalCosto").HeaderText = "Total Costo"
            .Columns("TotalCosto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalCosto").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TotalCosto").Visible = True

            .Columns("TotalPrecio").Width = 80
            .Columns("TotalPrecio").HeaderText = "Total Precio"
            .Columns("TotalPrecio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalPrecio").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TotalPrecio").Visible = True

            .Columns("Total_Mrg").Width = 80
            .Columns("Total_Mrg").HeaderText = "Total Margen"
            .Columns("Total_Mrg").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Mrg").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Total_Mrg").Visible = True

            .Columns("Porc_Markup").Width = 80
            .Columns("Porc_Markup").HeaderText = "Margen %"
            .Columns("Porc_Markup").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_Markup").DefaultCellStyle.Format = "% ##0.##"
            .Columns("Porc_Markup").Visible = True

            '.Columns("Porc_Margen").Width = 70
            '.Columns("Porc_Margen").HeaderText = "Margen Costo %"
            '.Columns("Porc_Margen").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Porc_Margen").DefaultCellStyle.Format = "###,##.##"
            '.Columns("Porc_Margen").Visible = True

        End With

    End Sub
    Public Sub LlenarGrilla(ByVal Rango As String,
                            ByVal Grupo As String,
                            ByVal Desde As Double,
                            ByVal Hasta As Double)

        'If Rango = "> 100" Then
        '    Filtro = "Where " & Grupo & " > 100"
        'ElseIf Rango = "0" Then
        '    Filtro = "Where " & Grupo & " = 0"
        'Else
        '    Filtro = "Where " & Grupo & " Between " & Desde & " And " & Hasta
        'End If

        'Consulta_sql = "Select Koprct, Nokopr, Documentos, CantidadUd1, TotalCosto, TotalPrecio, " & vbCrLf & _
        '               "Total_Mrg, cast(Porc_Markup as decimal(10,2)) as Porc_Markup," & vbCrLf & _
        '               "cast(Porc_Margen as decimal(10,2)) as Porc_Margen" & vbCrLf & _
        '               "From " & TblMrgProductos & vbCrLf & _
        '               Filtro & vbCrLf & _
        '               "order by Porc_Margen"

        With GrillaResumen

            .DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

            .Columns("Documentos").Visible = False

            .Columns("Koprct").Width = 90
            .Columns("Koprct").HeaderText = "Código"

            .Columns("Nokopr").Width = 250
            .Columns("Nokopr").HeaderText = "Descripción"

            .Columns("CantidadUd1").Width = 50
            .Columns("CantidadUd1").HeaderText = "Cant. Ud1"
            .Columns("CantidadUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("TotalCosto").Width = 60
            .Columns("TotalCosto").HeaderText = "Total Costo"
            .Columns("TotalCosto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalCosto").DefaultCellStyle.Format = "$ ###,##"

            .Columns("TotalPrecio").Width = 60
            .Columns("TotalPrecio").HeaderText = "Total Precio"
            .Columns("TotalPrecio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalPrecio").DefaultCellStyle.Format = "$ ###,##"

            .Columns("Total_Mrg").Width = 60
            .Columns("Total_Mrg").HeaderText = "Total Margen"
            .Columns("Total_Mrg").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Mrg").DefaultCellStyle.Format = "$ ###,##"

            .Columns("Porc_Markup").Width = 60
            .Columns("Porc_Markup").HeaderText = "Margen Precio %"
            .Columns("Porc_Markup").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("Porc_Markup").DefaultCellStyle.Format = "% ###,##"

            .Columns("Porc_Margen").Width = 60
            .Columns("Porc_Margen").HeaderText = "Margen Costo %"
            .Columns("Porc_Margen").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End With


    End Sub

    Private Sub GrillaResumen_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrillaResumen.CellDoubleClick

        Dim _Fila As DataGridViewRow = GrillaResumen.Rows(GrillaResumen.CurrentRow.Index)

        Dim _Codigo As String = _Fila.Cells("Koprct").Value
        Dim _Descripcion As String = _Fila.Cells("Nokopr").Value

        Dim _Tbl As DataTable = Fx_Crea_Tabla_Con_Filtro(_Tbl_Detalle, "Koprct = '" & _Codigo & "'", "Koprct")

        Dim Fm As New Frm_InvMargenesDet_(_Codigo, _Descripcion, _Tbl)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub BtnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportarExcel.Click
        'Consulta_sql = "Select Koprct as 'Código', Nokopr as 'Descripción', Documentos, CantidadUd1, TotalCosto, TotalPrecio, " & vbCrLf & _
        '              "Total_Mrg, cast(Porc_Markup as decimal(10,2)) as Porc_Markup," & vbCrLf & _
        '              "cast(Porc_Margen as decimal(10,2)) as Porc_Margen," & vbCrLf & _
        '              "Marca,Nom_Marca,ClasLibre,Nom_ClasLibre,Zona,Nom_Zona,Rubro,Nom_Rubro," & vbCrLf & _
        '              "SuperFamilia,Familia,SubFamilia,Nom_SuperFamilia,Nom_Familia,Nom_SubFamilia" & vbCrLf & _
        '              "From " & TblMrgProductos & vbCrLf & _
        '              Filtro
        ''Zw_TblMrgProductos" & FUNCIONARIO
        'ExportarTabla_JetExcel(Consulta_sql, Me)
        ExportarTabla_JetExcel_Tabla(_Tbl_Informe, Me, Replace(Me.Text, " ", "_"))
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub


End Class