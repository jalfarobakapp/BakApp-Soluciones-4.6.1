Imports DevComponents.DotNetBar

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
    Private _Cabeza As String
    Private _FechaVista As Date

    Public Sub New(_Id_Mapa As Integer, _Codigo_Sector As String, _Codigo_Ubic As String, _FechaVista As Date)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Mapa = _Id_Mapa
        Me._Codigo_Sector = _Codigo_Sector
        Me._Codigo_Ubic = _Codigo_Ubic
        Me._FechaVista = _FechaVista

        _MesActual = _FechaVista

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, False, False)

        Consulta_sql = "Select Id_Sector,Id_Mapa,Empresa,RAZON,Sucursal,NOKOSU,Bodega,NOKOBO,Codigo_Sector,Nombre_Sector," &
                       "Es_SubSector,EsCabecera,SoloUnaUbicacion,OblConfimarUbic" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Sectores z" & vbCrLf &
                       "Left Join CONFIGP c On c.EMPRESA = z.Empresa" & vbCrLf &
                       "Left Join TABSU s On s.EMPRESA = z.Empresa And s.KOSU = z.Sucursal" & vbCrLf &
                       "Left Join TABBO b On b.EMPRESA = z.Empresa And b.KOSU = z.Sucursal And b.KOBO = z.Bodega" & vbCrLf &
                       "Where Id_Mapa = " & _Id_Mapa & " And Codigo_Sector = '" & _Codigo_Sector & "'"
        _Row_Sector = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Private Sub Frm_Sectores_ProductosEnSector_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Lbl_EmpSucBod.Text = _Row_Sector.Item("RAZON").ToString.Trim & " - " &
                             _Row_Sector.Item("NOKOSU").ToString.Trim & " - " &
                             _Row_Sector.Item("NOKOBO").ToString.Trim
        LabelX4.Text = _Row_Sector.Item("Codigo_Sector")


        Lbl_YearMonth.Text = _MesActual.ToString("MMMM yyyy")
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

        Btn_MesSiguiente.Enabled = Not (Date.Today.Month = _MesActual.Month)

    End Sub

    Sub Sb_Actualizar_Grilla()

        Try

            Me.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            Dim _FechaDesde As Date = Primerdiadelmes(_MesActual)
            Dim _FechaHasta As Date = ultimodiadelmes(_FechaDesde)

            Dim _CampoDias As String = String.Empty
            Dim _Dias As Integer = DateDiff(DateInterval.Day, _FechaDesde, _FechaHasta)

            For i = 1 To _FechaHasta.Day

                Dim _Año = _FechaDesde.Year
                Dim _Mes = numero_(_FechaDesde.Month, 2)
                Dim _Dia = numero_(i, 2)

                If i = _FechaHasta.Day Then
                    _CampoDias += "MAX(CASE WHEN d.Day = '" & _Año & "-" & _Mes & "-" & _Dia & "' AND z.Codigo IS NOT NULL And Salida = 0 THEN 'X' ELSE '' END) AS [" & _Dia & "]"
                Else
                    _CampoDias += "MAX(CASE WHEN d.Day = '" & _Año & "-" & _Mes & "-" & _Dia & "' AND z.Codigo IS NOT NULL And Salida = 0 THEN 'X' ELSE '' END) AS [" & _Dia & "]," & vbCrLf
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
         AND Codigo_Ubic = '" & _Codigo_Ubic & "' And FechaIngreso between @FechaDesde And @FechaHasta And Salida = 0) AS p
    Cross Join
        DaysOfMonth AS d
    Left Join
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
                '.Columns(_Columna).Resizable = DataGridViewTriState.False
                .Columns("Codigo").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Descripcion").Visible = True
                .Columns("Descripcion").HeaderText = "Descripción"
                .Columns("Descripcion").Width = 270
                '.Columns(_Columna).Resizable = DataGridViewTriState.False
                .Columns("Descripcion").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                For i = 1 To _FechaHasta.Day

                    Dim _Columna = numero_(i, 2)

                    .Columns(_Columna).Visible = True
                    .Columns(_Columna).HeaderText = _Columna
                    .Columns(_Columna).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns(_Columna).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns(_Columna).Resizable = DataGridViewTriState.False
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

        Btn_MesSiguiente.Enabled = Not (Date.Today.Month = _MesActual.Month)

    End Sub

    Private Sub Btn_MesSiguiente_Click(sender As Object, e As EventArgs) Handles Btn_MesSiguiente.Click

        _MesActual = DateAdd(DateInterval.Month, 1, _MesActual)
        Lbl_YearMonth.Text = _MesActual.ToString("MMMM yyyy")

        Sb_Actualizar_Grilla()

        Btn_MesSiguiente.Enabled = Not (Date.Today.Month = _MesActual.Month)

    End Sub

    Private Sub Grilla_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla.CellMouseDoubleClick
        Return
        ' Verificar si el doble clic fue en el encabezado de la columna
        If e.RowIndex = -1 Then
            'MessageBox.Show("Doble clic en el encabezado de la columna: " & Grilla.Columns(e.ColumnIndex).HeaderText)
            Return
        End If

        ' Si no fue en el encabezado, proceder con el manejo del doble clic en la celda
        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Codigo As String = _Fila.Cells("Codigo").Value
        Dim _Cabeza As String = Grilla.Columns(e.ColumnIndex).Name

        If _Cabeza = "Codigo" Or _Cabeza = "Descripcion" Then
            Exit Sub
        End If

        Dim _Fecha As Date = Date.Parse(_Cabeza & "/" & _MesActual.Month & "/" & _MesActual.Year)

        If _Fecha > Date.Today Then
            MessageBoxEx.Show(Me, "No se pueden marcar o desmarcar columnas de una fecha futura", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Marca As String = _Fila.Cells(_Cabeza).Value

        If _Marca = "X" Then

            If _Fila.Cells(_Cabeza).Tag Is Nothing Then
                _Fila.Cells(_Cabeza).Tag = True
            End If

            _Fila.Cells(_Cabeza).Value = ""

        Else

            If _Fila.Cells(_Cabeza).Tag Is Nothing Then
                _Fila.Cells(_Cabeza).Tag = False
            End If

            _Fila.Cells(_Cabeza).Value = "X"

        End If

    End Sub

    Private Sub Grilla_ColumnHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla.ColumnHeaderMouseDoubleClick
        Return
        _Cabeza = Grilla.Columns(e.ColumnIndex).Name

        If _Cabeza = "Codigo" Or _Cabeza = "Descripcion" Then
            Exit Sub
        End If

        Dim _Fecha As Date = Date.Parse(_Cabeza & "/" & _MesActual.Month & "/" & _MesActual.Year)

        ' Verificar si _Fecha es igual o mayor a la fecha de hoy
        If _Fecha > Date.Today Then
            MessageBoxEx.Show(Me, "No se pueden marcar o desmarcar columnas de una fecha futura", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        ShowContextMenu(Menu_Contextual_01)

    End Sub
    Private Sub Btn_AgregarProductosUbic_Click(sender As Object, e As EventArgs) Handles Btn_AgregarProductosUbic.Click

    End Sub
    Private Sub Btn_MarcarTodos_Click(sender As Object, e As EventArgs) Handles Btn_MarcarTodos.Click
        Sb_MarcarDesmarcar(_Cabeza, True)
    End Sub

    Private Sub Btn_DesmarcarTodos_Click(sender As Object, e As EventArgs) Handles Btn_DesmarcarTodos.Click
        Sb_MarcarDesmarcar(_Cabeza, False)
    End Sub

    Sub Sb_MarcarDesmarcar(_Cabeza As String, _Marcar As Boolean)

        For Each _Fila As DataGridViewRow In Grilla.Rows

            If _Marcar Then

                If _Fila.Cells(_Cabeza).Tag Is Nothing Then
                    _Fila.Cells(_Cabeza).Tag = False
                End If

                _Fila.Cells(_Cabeza).Value = "X"

            Else

                If _Fila.Cells(_Cabeza).Tag Is Nothing Then
                    _Fila.Cells(_Cabeza).Tag = True
                End If

                _Fila.Cells(_Cabeza).Value = ""

            End If

        Next

    End Sub

    Private Sub Btn_Copiar_Click(sender As Object, e As EventArgs) Handles Btn_Copiar.Click

    End Sub

    Private Sub Btn_ExportarExcelProductos_Click(sender As Object, e As EventArgs) Handles Btn_ExportarExcelProductos.Click

        Dim _NombreArchivo As String = "Productos en " & LabelX4.Text & "-" & Lbl_YearMonth.Text

        ExportarTabla_JetExcel_Tabla(_Tbl_Productos, Me, _NombreArchivo)

    End Sub

End Class
