Public Class Frm_Sectores_ProductosEnSector

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Dv As DataView
    Private _Tbl_Productos As DataTable

    Private _Id_Mapa As Integer
    Private _Codigo_Sector As String
    Private _Codigo_Ubic As String

    Private _MesActual As Date
    Private _Row_Sector As DataRow

    Public Sub New(_Id_Mapa As Integer, _Codigo_Sector As String, _Codigo_Ubic As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Mapa = _Id_Mapa
        Me._Codigo_Sector = _Codigo_Sector
        Me._Codigo_Ubic = _Codigo_Ubic

        _MesActual = Date.Now

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, False, False)

        Consulta_sql = "Select Id_Sector,Id_Mapa,Empresa,Sucursal,Bodega,Codigo_Sector,Nombre_Sector," &
                       "Es_SubSector,EsCabecera,SoloUnaUbicacion,OblConfimarUbic" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Sectores" & vbCrLf &
                       "Where Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector & "'"
        _Row_Sector = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Private Sub Frm_Sectores_ProductosEnSector_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Lbl_YearMonth.Text = _MesActual.ToString("MMMM yyyy")
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Try

            Me.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            Dim _FechaDesde As Date = Primerdiadelmes(_MesActual)
            Dim _FechaHasta As Date = ultimodiadelmes(_FechaDesde)

            Dim _CampoDias As String
            Dim _Dias As Integer = DateDiff(DateInterval.Day, _FechaDesde, _FechaHasta)

            For i = 1 To _FechaHasta.Day

                Dim _Año = _FechaDesde.Year
                Dim _Mes = numero_(_FechaDesde.Month, 2)
                Dim _Dia = numero_(i, 2)

                If i = _FechaHasta.Day Then
                    _CampoDias += "MAX(CASE WHEN d.Day = '" & _Año & "-" & _Mes & "-" & _Dia & "' AND z.Codigo IS NOT NULL THEN 'X' ELSE '' END) AS [" & _Dia & "]"
                Else
                    _CampoDias += "MAX(CASE WHEN d.Day = '" & _Año & "-" & _Mes & "-" & _Dia & "' AND z.Codigo IS NOT NULL THEN 'X' ELSE '' END) AS [" & _Dia & "]," & vbCrLf
                End If

            Next

            Consulta_sql = "-- Muestra los productos que ha tenido una ubicacion em un mes en especifico y los productos asociados a esta ubicabion en el tiempo
    DECLARE @FechaDesde DATE = '" & Format(_FechaDesde, "yyyyMMdd") & "';
    DECLARE @FechaHasta DATE = '" & Format(_FechaHasta, "yyyyMMdd") & "';

    -- Crear una tabla temporal con los días del rango de fechas
    WITH DaysOfMonth AS (
        SELECT DATEADD(DAY, n, @FechaDesde) AS Day
        FROM (SELECT TOP (DATEDIFF(DAY, @FechaDesde, @FechaHasta) + 1) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n FROM master.dbo.spt_values) AS Numbers
    )

    -- Consulta principal
    SELECT 
        p.Codigo,Mp.NOKOPR As 'Descripcion',
        " & _CampoDias & "
    FROM 
        (SELECT DISTINCT Codigo 
         FROM " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal 
         WHERE Codigo_Sector = '" & _Codigo_Sector & "' 
         AND Codigo_Ubic = '" & _Codigo_Ubic & "') AS p
    CROSS JOIN 
        DaysOfMonth AS d
    LEFT JOIN 
        " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal AS z ON p.Codigo = z.Codigo AND z.Codigo_Sector = '" & _Codigo_Sector & "' AND z.Codigo_Ubic = '" & _Codigo_Ubic & "' AND 
        CASE 
            WHEN ISDATE(z.FechaIngreso) = 1 THEN CONVERT(DATE, z.FechaIngreso, 120) 
            ELSE NULL 
        END = d.Day
    Left Join MAEPR Mp On Mp.KOPR = p.Codigo
    GROUP BY 
        p.Codigo,Mp.NOKOPR
    ORDER BY 
        p.Codigo"

            Dim _New_Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)
            _Dv = New DataView
            _Dv.Table = _New_Ds.Tables("Table")
            _Tbl_Productos = _Dv.Table

            With Grilla

                .DataSource = _Dv

                OcultarEncabezadoGrilla(Grilla, True)

                Dim _DisplayIndex = 0

                .Columns("Codigo").Visible = True
                .Columns("Codigo").HeaderText = "Código."
                .Columns("Codigo").Width = 100
                .Columns("Codigo").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Descripcion").Visible = True
                .Columns("Descripcion").HeaderText = "Descripción"
                .Columns("Descripcion").Width = 270
                .Columns("Descripcion").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                For i = 1 To _FechaHasta.Day

                    Dim _Columna = numero_(i, 2)

                    .Columns(_Columna).Visible = True
                    .Columns(_Columna).HeaderText = _Columna
                    .Columns(_Columna).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns(_Columna).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns(_Columna).Width = 20
                    .Columns(_Columna).DisplayIndex = _DisplayIndex
                    _DisplayIndex += 1

                Next

            End With

        Catch ex As Exception
        Finally
            Me.Enabled = True
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub Btn_MesAnterior_Click(sender As Object, e As EventArgs) Handles Btn_MesAnterior.Click

        _MesActual = DateAdd(DateInterval.Month, -1, _MesActual)
        Lbl_YearMonth.Text = _MesActual.ToString("MMMM yyyy")

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Btn_MesSiguiente_Click(sender As Object, e As EventArgs) Handles Btn_MesSiguiente.Click

        _MesActual = DateAdd(DateInterval.Month, 1, _MesActual)
        Lbl_YearMonth.Text = _MesActual.ToString("MMMM yyyy")

        Sb_Actualizar_Grilla()

    End Sub

End Class
