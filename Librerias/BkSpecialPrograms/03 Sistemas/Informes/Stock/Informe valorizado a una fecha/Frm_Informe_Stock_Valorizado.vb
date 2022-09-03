'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Informe_Stock_Valorizado

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tabla_Paso As String = _Global_BaseBk & "Tbl_Paso" & FUNCIONARIO & "_St"  '#Tabla_Paso#

    Dim _Ds_Informes As DataSet
    Dim _Tbl_Informe_X_Sucursal As DataTable
    Dim _Tbl_Informe_X_Familias As DataTable
    Dim _Tbl_Informe_X_Productos As DataTable

    Dim _Tbl_Filtro_Super_Familias As DataTable
    Dim _Tbl_Filtro_Familias As DataTable
    Dim _Tbl_Filtro_Sub_Familias As DataTable

    Dim _Tbl_Filtro_Marcas As DataTable
    Dim _Tbl_Filtro_Rubro As DataTable
    Dim _Tbl_Filtro_Clalibpr As DataTable
    Dim _Tbl_Filtro_Zonas As DataTable

    Dim _Tbl_Filtro_Bodegas As DataTable

    Dim _Filtro_Marcas_Todas As Boolean
    Dim _Filtro_Super_Familias_Todas As Boolean
    Dim _Filtro_Familias_Todas As Boolean
    Dim _Filtro_Sub_Familias_Todas As Boolean
    Dim _Filtro_Rubro_Todas As Boolean
    Dim _Filtro_Clalibpr_Todas As Boolean
    Dim _Filtro_Zonas_Todas As Boolean
    Dim _Filtro_Bodegas_Todas As Boolean

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Filtro_Marcas_Todas = True
        _Filtro_Super_Familias_Todas = True
        _Filtro_Familias_Todas = True
        _Filtro_Sub_Familias_Todas = True
        _Filtro_Rubro_Todas = True
        _Filtro_Clalibpr_Todas = True
        _Filtro_Zonas_Todas = True
        _Filtro_Bodegas_Todas = True


        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Ejecutar_Informe.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Informe_Stock_Valorizado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dtp_Fecha_Actual.Value = FechaDelServidor()
        Dtp_Fecha_Anterior.Value = FechaDelServidor()

        Consulta_sql = "Drop Table " & _Tabla_Paso
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

    End Sub

    Private Sub Frm_Informe_Stock_Valorizado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Consulta_sql = "Drop Table " & _Tabla_Paso
        _Sql.Ej_consulta_IDU(Consulta_sql, False)
    End Sub

    Private Sub Btn_Ejecutar_Informe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ejecutar_Informe.Click

        Dim _Excluir_Productos_SSN = String.Empty
        Dim _Excluir_Productos_FLN = String.Empty
        Dim _Filtros_Productos = String.Empty
        Dim _Excluir_Productos_Bloqueados = String.Empty

        If Chk_Excluye_SSN.Checked Then
            _Excluir_Productos_SSN = "AND MAEPR.TIPR <> 'SSN'"
        End If

        If Chk_Excluye_FLN.Checked Then
            _Excluir_Productos_FLN = "AND MAEPR.TIPR <> 'FLN'"
        End If

        If Chk_No_Bloqueados.Checked Then
            _Excluir_Productos_Bloqueados = "NOT COALESCE(MAEPR.BLOQUEAPR,'') IN ( 'C','V','T','X' ) "
        End If

        _Filtros_Productos = Fx_Filtros_Productos()

        Dim _Fecha_Informe As String

        Dim _Fecha_Hoy As String = Format(Now.Date, "yyyyMMdd")

        Dim _Filtro_Bodega As String

        If _Filtro_Bodegas_Todas Then
            _Filtro_Bodega = String.Empty
        Else
            _Filtro_Bodega = Generar_Filtro_IN(_Tbl_Filtro_Bodegas, "Chk", "Codigo", False, True, "'")
            _Filtro_Bodega = "AND TABBOPR.EMPRESA+TABBOPR.KOSU+TABBOPR.KOBO IN " & _Filtro_Bodega
        End If

        Consulta_sql = "Drop Table " & _Tabla_Paso
        _Sql.Ej_consulta_IDU(Consulta_sql, False)


        If Rdb_Valorizado_Fecha_Actual.Checked Then
            Consulta_sql = My.Resources.Recursos_Stockval.SQLQuery_Informe_Stock_Valorizado_fecha_actual
        ElseIf Rdb_Valorizado_Fecha_Anterior.Checked Then

            _Fecha_Informe = Format(Dtp_Fecha_Anterior.Value, "yyyyMMdd")

            If _Fecha_Hoy = _Fecha_Informe Then
                Consulta_sql = My.Resources.Recursos_Stockval.SQLQuery_Informe_Stock_Valorizado_fecha_actual
            Else
                'MessageBoxEx.Show(Me, "El informe se generara a una fecha distinta a la fecha actual." & vbCrLf & _
                '                  "El informe tardara mas tiempo de lo normal.... por favor espere", _
                '                  "Informe de Stock una fecha anterior", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Consulta_sql = My.Resources.Recursos_Stockval.SQLQuery_Informe_Stock_Valorizado_a_una_fecha
                Consulta_sql = Replace(Consulta_sql, "#Fecha_Informe#", _Fecha_Informe)
            End If
        End If


        Consulta_sql = Replace(Consulta_sql, "#Excluir_Productos_SSN#", _Excluir_Productos_SSN)
        Consulta_sql = Replace(Consulta_sql, "#Excluir_Productos_FLN#", _Excluir_Productos_FLN)
        Consulta_sql = Replace(Consulta_sql, "#Filtros_Productos#", _Filtros_Productos)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Bodegas#", _Filtro_Bodega)
        Consulta_sql = Replace(Consulta_sql, "#Excluir_Productos_Bloqueados#", _Excluir_Productos_Bloqueados)
        Consulta_sql = Replace(Consulta_sql, "#Tabla_Paso#", _Tabla_Paso)
        Consulta_sql = Replace(Consulta_sql, "#Funcionario#", FUNCIONARIO)

        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False

        _Sql.Ej_consulta_IDU(Consulta_sql)

        Dim Fm As New Frm_Informe_Composicion_Stock(Frm_Informe_Composicion_Stock.Enum_Informe.Sucursal, _
                                                    _Tabla_Paso, False)

        Fm.Pro_Rdb_Saldo_Con_saldo_Positivo = Rdb_Saldo_Con_saldo_Positivo.Checked
        Fm.Pro_Rdb_Saldo_Con_y_sin_saldo = Rdb_Saldo_Con_y_sin_saldo.Checked
        Fm.Pro_Rdb_Saldo_Distinto_de_cero = Rdb_Saldo_Distinto_de_cero.Checked

        Fm.Text = "Informe de Stock valorizado por SUCURSAL"
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Me.Cursor = Cursors.Default
        Me.Enabled = True


    End Sub

    Function Fx_Filtros_Productos() As String

        Dim _Filtros, _
            _Filtro_Rubros, _
            _Filtro_Marcas, _
            _Filtro_Zonas, _
            _Filtro_SuperFamilias, _
            _Filtro_Familias, _
            _Filtro_SubFamilias, _
            _Filtro_ClasLibre As String


        If _Filtro_Rubro_Todas Then
            _Filtro_Rubros = String.Empty
        Else
            _Filtro_Rubros = Generar_Filtro_IN(_Tbl_Filtro_Rubro, "Chk", "Codigo", False, True, "'")
            '_Filtro_Rubros = "And KOPR IN (Select KOPR From MAEPR Where RUPR In " & _Filtro_Rubros & ")"
            _Filtro_Rubros = "AND MAEPR.RUPR IN " & _Filtro_Rubros
        End If

        If _Filtro_Marcas_Todas Then
            _Filtro_Marcas = String.Empty
        Else
            _Filtro_Marcas = Generar_Filtro_IN(_Tbl_Filtro_Marcas, "Chk", "Codigo", False, True, "'")
            '_Filtro_Marcas = "And KOPR IN (Select KOPR From MAEPR Where MRPR In " & _Filtro_Marcas & ")"
            _Filtro_Marcas = "AND MAEPR.MRPR IN " & _Filtro_Marcas
        End If

        If _Filtro_Super_Familias_Todas Then
            _Filtro_SuperFamilias = String.Empty
        Else
            _Filtro_SuperFamilias = Generar_Filtro_IN(_Tbl_Filtro_Super_Familias, "Chk", "Codigo", False, True, "'")
            '_Filtro_SuperFamilias = "And KOPR IN (Select KOPR From MAEPR Where FMPR In " & _Filtro_SuperFamilias & ")"
            _Filtro_SuperFamilias = "AND MAEPR.FMPR IN " & _Filtro_SuperFamilias
        End If

        If _Filtro_Familias_Todas Then
            _Filtro_Familias = String.Empty
        Else
            _Filtro_Familias = Generar_Filtro_IN(_Tbl_Filtro_Familias, "Chk", "Codigo", False, True, "'")
            '_Filtro_SuperFamilias = "And KOPR IN (Select KOPR From MAEPR Where FMPR In " & _Filtro_SuperFamilias & ")"
            _Filtro_Familias = "AND MAEPR.FMPR+MAEPR.PFPR IN " & _Filtro_Familias
        End If

        If _Filtro_Sub_Familias_Todas Then
            _Filtro_SubFamilias = String.Empty
        Else
            _Filtro_SubFamilias = Generar_Filtro_IN(_Tbl_Filtro_Sub_Familias, "Chk", "Codigo", False, True, "'")
            '_Filtro_SuperFamilias = "And KOPR IN (Select KOPR From MAEPR Where FMPR In " & _Filtro_SuperFamilias & ")"
            _Filtro_SubFamilias = "AND MAEPR.FMPR+MAEPR.PFPR+MAEPR.HFPR IN " & _Filtro_SubFamilias
        End If

        If _Filtro_Clalibpr_Todas Then
            _Filtro_ClasLibre = String.Empty
        Else
            _Filtro_ClasLibre = Generar_Filtro_IN(_Tbl_Filtro_Clalibpr, "Chk", "Codigo", False, True, "'")
            '_Filtro_ClasLibre = "And KOPR IN (Select KOPR From MAEPR Where CLALIBPR In " & _Filtro_ClasLibre & ")"
            _Filtro_ClasLibre = "AND MAEPR.CLALIBPR IN " & _Filtro_ClasLibre
        End If

        If _Filtro_Zonas_Todas Then
            _Filtro_Zonas = String.Empty
        Else
            _Filtro_Zonas = Generar_Filtro_IN(_Tbl_Filtro_Zonas, "Chk", "Codigo", False, True, "'")
            '_Filtro_Zonas = "And KOPR IN (Select KOPR From MAEPR Where ZONAPR In " & _Filtro_Zonas & ")"
            _Filtro_Zonas = "AND MAEPR.ZONAPR IN " & _Filtro_Zonas
        End If

        '---------------------------

        _Filtros = _Filtro_ClasLibre & vbCrLf & _
                   _Filtro_Marcas & vbCrLf & _
                   _Filtro_Rubros & vbCrLf & _
                   _Filtro_SuperFamilias & vbCrLf & _
                   _Filtro_Familias & vbCrLf & _
                   _Filtro_SubFamilias & vbCrLf & _
                   _Filtro_Zonas

        Return _Filtros

    End Function

    Private Sub BtnFiltrosBodega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtros_Bodega.Click

        Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Bodegas, False)
        Fm.Pro_Tbl_Filtro = _Tbl_Filtro_Bodegas

        Fm.ShowDialog(Me)

        If Fm.Pro_Filtrar Then

            _Tbl_Filtro_Bodegas = Fm.Pro_Tbl_Filtro

            If Fm.Pro_Filtrar_Todo Then
                _Filtro_Bodegas_Todas = True
            Else
                If (_Tbl_Filtro_Bodegas Is Nothing) Then
                    _Filtro_Bodegas_Todas = True
                Else
                    _Filtro_Bodegas_Todas = False
                End If
            End If

        End If
        Fm.Dispose()

    End Sub

    Private Sub Btn_Clasificacion_Productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Clasificacion_Productos.Click

        Dim Fm As New Frm_Filtro_Especial_Productos
        Fm.Pro_Filtro_Clalibpr_Todas = _Filtro_Clalibpr_Todas
        Fm.Pro_Filtro_Marcas_Todas = _Filtro_Marcas_Todas
        Fm.Pro_Filtro_Rubro_Todas = _Filtro_Rubro_Todas
        Fm.Pro_Filtro_Super_Familias_Todas = _Filtro_Super_Familias_Todas
        Fm.Pro_Filtro_Zonas_Todas = _Filtro_Zonas_Todas

        Fm.Pro_Tbl_Filtro_Clalibpr = _Tbl_Filtro_Clalibpr
        Fm.Pro_Tbl_Filtro_Marcas = _Tbl_Filtro_Marcas
        Fm.Pro_Tbl_Filtro_Rubro = _Tbl_Filtro_Rubro
        Fm.Pro_Tbl_Filtro_Super_Familias = _Tbl_Filtro_Super_Familias
        Fm.Pro_Tbl_Filtro_Zonas = _Tbl_Filtro_Zonas

        Fm.ShowDialog(Me)

        _Tbl_Filtro_Clalibpr = Fm.Pro_Tbl_Filtro_Clalibpr
        _Tbl_Filtro_Marcas = Fm.Pro_Tbl_Filtro_Marcas
        _Tbl_Filtro_Rubro = Fm.Pro_Tbl_Filtro_Rubro
        _Tbl_Filtro_Super_Familias = Fm.Pro_Tbl_Filtro_Super_Familias
        _Tbl_Filtro_Zonas = Fm.Pro_Tbl_Filtro_Zonas

        _Filtro_Clalibpr_Todas = Fm.Pro_Filtro_Clalibpr_Todas
        _Filtro_Marcas_Todas = Fm.Pro_Filtro_Marcas_Todas
        _Filtro_Rubro_Todas = Fm.Pro_Filtro_Rubro_Todas
        _Filtro_Super_Familias_Todas = Fm.Pro_Filtro_Super_Familias_Todas
        _Filtro_Zonas_Todas = Fm.Pro_Filtro_Zonas_Todas

        Fm.Dispose()

    End Sub


    Private Sub Rdb_Valorizado_Fecha_Anterior_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Valorizado_Fecha_Anterior.CheckedChanged
        Dtp_Fecha_Anterior.Enabled = Rdb_Valorizado_Fecha_Anterior.Checked
    End Sub

    Private Sub Bar2_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bar2.ItemClick

    End Sub
End Class