Imports DevComponents.DotNetBar

Public Class Frm_Informe_Compr_No_Despachados

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tabla_Paso As String = _Global_BaseBk & "Tbl_Paso" & FUNCIONARIO & "_Cnd"

    Dim _Ds_Informes As DataSet
    Dim _Tbl_Informe_X_Sucursal As DataTable
    Dim _Tbl_Informe_X_Familias As DataTable
    Dim _Tbl_Informe_X_Productos As DataTable

    Dim _Tbl_Filtro_Super_Familias As DataTable
    Dim _Tbl_Filtro_Marcas As DataTable
    Dim _Tbl_Filtro_Rubro As DataTable
    Dim _Tbl_Filtro_Clalibpr As DataTable
    Dim _Tbl_Filtro_Zonas As DataTable

    Dim _Filtro_Documentos As String

    Dim _Tbl_Filtro_Bodegas As DataTable

    Dim _Filtro_Marcas_Todas As Boolean
    Dim _Filtro_Super_Familias_Todas As Boolean
    Dim _Filtro_Rubro_Todas As Boolean
    Dim _Filtro_Clalibpr_Todas As Boolean
    Dim _Filtro_Zonas_Todas As Boolean
    Dim _Filtro_Bodegas_Todas As Boolean

    Dim _Informe_Analisis As Boolean
    Dim _Informe_Generado As Boolean

    Public ReadOnly Property Pro_Informe_Generado() As Boolean
        Get
            Return _Informe_Generado
        End Get
    End Property

    Public Property Pro_Informe_Analisis() As Boolean
        Get
            Return _Informe_Analisis
        End Get
        Set(value As Boolean)
            _Informe_Analisis = value
        End Set
    End Property

    Public ReadOnly Property Pro_Nombre_Tabla_Paso() As String
        Get
            Return _Tabla_Paso
        End Get
    End Property

    Public ReadOnly Property Pro_Filtro_Documentos()
        Get
            Dim _Filtro As String = Replace(_Filtro_Documentos, "AND ED.", "")
            Return _Filtro
        End Get
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Filtro_Marcas_Todas = True
        _Filtro_Super_Familias_Todas = True
        _Filtro_Rubro_Todas = True
        _Filtro_Clalibpr_Todas = True
        _Filtro_Zonas_Todas = True
        _Filtro_Bodegas_Todas = True

        Sb_Color_Botones_Barra(Bar1)
        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Informe_Compr_No_Despachados_01_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim _Fecha_Hoy = FechaDelServidor()

        Dtp_Fecha_Emision_Desde.Value = _Fecha_Hoy
        Dtp_Fecha_Emision_Hasta.Value = _Fecha_Hoy
        Dtp_Fecha_Recepcion_Desde.Value = _Fecha_Hoy
        Dtp_Fecha_Recepcion_Hasta.Value = _Fecha_Hoy

        Chk_NVVHabilitadasFacturar.Visible = _Global_Row_Configuracion_General.Item("LasNVVDebenSerHabilitadasParaFacturar")
        Chk_NVVHabilitadasFacturar.Checked = _Global_Row_Configuracion_General.Item("LasNVVDebenSerHabilitadasParaFacturar")

        If Chk_NVVHabilitadasFacturar.Visible Then
            AddHandler Chk_NVVHabilitadasFacturar.CheckedChanged, AddressOf Chk_NVVHabilitadasFacturar_CheckedChanged
        End If

        'If _Global_Row_Configuracion_General.Item("LasNVVDebenSerHabilitadasParaFacturar") Then
        '    Rdb_NVV.Text = "Notas de venta (NVV) Solo Habilitadas"
        'End If

    End Sub

    Function Fx_Filtros_Productos() As String

        Dim _Filtros,
            _Filtro_Rubros,
            _Filtro_Marcas,
            _Filtro_Zonas,
            _Filtro_SuperFamilias,
            _Filtro_ClasLibre As String


        If _Filtro_Rubro_Todas Then
            _Filtro_Rubros = String.Empty
        Else
            _Filtro_Rubros = Generar_Filtro_IN(_Tbl_Filtro_Rubro, "Chk", "Codigo", False, True, "'")
            '_Filtro_Rubros = "And KOPR IN (Select KOPR From MAEPR Where RUPR In " & _Filtro_Rubros & ")"
            _Filtro_Rubros = "AND PR.RUPR IN " & _Filtro_Rubros
        End If

        If _Filtro_Marcas_Todas Then
            _Filtro_Marcas = String.Empty
        Else
            _Filtro_Marcas = Generar_Filtro_IN(_Tbl_Filtro_Marcas, "Chk", "Codigo", False, True, "'")
            '_Filtro_Marcas = "And KOPR IN (Select KOPR From MAEPR Where MRPR In " & _Filtro_Marcas & ")"
            _Filtro_Marcas = "AND PR.MRPR IN " & _Filtro_Marcas
        End If

        If _Filtro_Super_Familias_Todas Then
            _Filtro_SuperFamilias = String.Empty
        Else
            _Filtro_SuperFamilias = Generar_Filtro_IN(_Tbl_Filtro_Super_Familias, "Chk", "Codigo", False, True, "'")
            '_Filtro_SuperFamilias = "And KOPR IN (Select KOPR From MAEPR Where FMPR In " & _Filtro_SuperFamilias & ")"
            _Filtro_SuperFamilias = "AND PR.FMPR IN " & _Filtro_SuperFamilias
        End If

        If _Filtro_Clalibpr_Todas Then
            _Filtro_ClasLibre = String.Empty
        Else
            _Filtro_ClasLibre = Generar_Filtro_IN(_Tbl_Filtro_Clalibpr, "Chk", "Codigo", False, True, "'")
            '_Filtro_ClasLibre = "And KOPR IN (Select KOPR From MAEPR Where CLALIBPR In " & _Filtro_ClasLibre & ")"
            _Filtro_ClasLibre = "AND PR.CLALIBPR IN " & _Filtro_ClasLibre
        End If

        If _Filtro_Zonas_Todas Then
            _Filtro_Zonas = String.Empty
        Else
            _Filtro_Zonas = Generar_Filtro_IN(_Tbl_Filtro_Zonas, "Chk", "Codigo", False, True, "'")
            '_Filtro_Zonas = "And KOPR IN (Select KOPR From MAEPR Where ZONAPR In " & _Filtro_Zonas & ")"
            _Filtro_Zonas = "AND PR.ZONAPR IN " & _Filtro_Zonas
        End If

        '---------------------------

        _Filtros = _Filtro_ClasLibre & vbCrLf &
                   _Filtro_Marcas & vbCrLf &
                   _Filtro_Rubros & vbCrLf &
                   _Filtro_SuperFamilias & vbCrLf &
                   _Filtro_Zonas

        Return _Filtros

    End Function

    Private Sub Btn_Filtros_Bodega_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtros_Bodega.Click
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

    Private Sub Btn_Clasificacion_Productos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Clasificacion_Productos.Click
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

    Private Sub Btn_Ejecutar_Informe_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ejecutar_Informe.Click

        Dim _Ud As Integer

        If Rdb_Ud1.Checked Then
            _Ud = 1
        ElseIf Rdb_Ud2.Checked Then
            _Ud = 2
        End If

        Dim _Filtro_Detalle As String
        Dim _Filtro_Productos As String = Fx_Filtros_Productos()

        Dim _Fecha_Emision_Desde As String = Format(Dtp_Fecha_Emision_Desde.Value, "yyyyMMdd")
        Dim _Fecha_Emision_Hasta As String = Format(Dtp_Fecha_Emision_Hasta.Value, "yyyyMMdd")

        Dim _Fecha_Recepcion_Desde As String = Format(Dtp_Fecha_Recepcion_Desde.Value, "yyyyMMdd")
        Dim _Fecha_Recepcion_Hasta As String = Format(Dtp_Fecha_Recepcion_Hasta.Value, "yyyyMMdd")


        Dim _Filtro_Bodega As String

        If _Filtro_Bodegas_Todas Then
            _Filtro_Bodega = String.Empty
        Else
            _Filtro_Bodega = Generar_Filtro_IN(_Tbl_Filtro_Bodegas, "Chk", "Codigo", False, True, "'")
            _Filtro_Bodega = "AND TABBOPR.EMPRESA+TABBOPR.KOSU+TABBOPR.KOBO IN " & _Filtro_Bodega
        End If

        If Rdb_Lineas_Pendientes.Checked Then
            _Filtro_Detalle = "AND DD.CAPRCO1<>(DD.CAPRAD1+DD.CAPREX1)" & vbCrLf
        ElseIf Rdb_Lineas_Todas.Checked Then
            _Filtro_Detalle = String.Empty
        End If

        If Rdb_BLV.Checked Then
            _Filtro_Documentos = "AND ED.TIDO='BLV'" & vbCrLf
        ElseIf Rdb_FCV.Checked Then
            _Filtro_Documentos = "AND ED.TIDO='FCV'" & vbCrLf
        ElseIf Rdb_NCV.Checked Then
            _Filtro_Documentos = "AND ED.TIDO='NCV'" & vbCrLf
        ElseIf Rdb_NVV.Checked Then
            _Filtro_Documentos = "AND ED.TIDO='NVV'" & vbCrLf

            If Chk_NVVHabilitadasFacturar.Visible Then

                If Chk_NVVHabilitadasFacturar.Checked Then
                    _Filtro_Documentos += "AND ED.IDMAEEDO In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Docu_Ent Where HabilitadaFac = 1)" & vbCrLf
                    MessageBoxEx.Show(Me, "Se mostraran solo notas de venta habilitadas para facturar", "Información",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If

        ElseIf Rdb_NVI.Checked Then
            _Filtro_Documentos = "AND ED.TIDO='NVI'" & vbCrLf
        ElseIf Rdb_COV.Checked Then
            _Filtro_Documentos = "AND ED.TIDO='COV'" & vbCrLf
        ElseIf Rdb_Todos.Checked Then
            If Chk_Incluir_COV.Checked Then
                _Filtro_Documentos = "AND ED.TIDO IN ('BLV','FCV','NCV','NVV','NVI','COV')"
            Else
                _Filtro_Documentos = "AND ED.TIDO IN ('BLV','FCV','NCV','NVV','NVI')"
            End If
        End If

        Dim _Filtro_Fecha_Recepcion As String

        If Chk_Fecha_Recepcion.Checked Then
            _Filtro_Fecha_Recepcion = "AND DD.FEERLI BETWEEN '" & _Fecha_Recepcion_Desde &
                                      "' AND '" & _Fecha_Recepcion_Hasta & "'" & vbCrLf
        Else
            _Filtro_Fecha_Recepcion = String.Empty
        End If


        Consulta_sql = "Drop Table " & _Tabla_Paso
        _Sql.Ej_consulta_IDU(Consulta_sql, False)


        Consulta_sql = My.Resources.Recursos_Proximas_Recepciones.SQLQuery_Proximas_Recepciones
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Detalle#", _Filtro_Detalle)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Productos#", _Filtro_Productos)
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Ud#", _Ud)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Documentos#", _Filtro_Documentos)
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Emision_Desde#", _Fecha_Emision_Desde)
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Emision_Hasta#", _Fecha_Emision_Hasta)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Fecha_Recepcion#", _Filtro_Fecha_Recepcion)

        Dim _Reg = _Sql.Fx_Cuenta_Registros("INFORMATION_SCHEMA.COLUMNS",
                                            "COLUMN_NAME LIKE 'SUENDOFI' AND TABLE_NAME = 'MAEEDO'")
        If Not CBool(_Reg) Then
            Consulta_sql = Replace(Consulta_sql, "ISNULL(ED.SUENDOFI,'') AS SUENDOFI,", "--ISNULL(ED.SUENDOFI,'') AS SUENDOFI,")
        End If

        Consulta_sql = Replace(Consulta_sql, "#Tabla_Paso#", _Tabla_Paso)

        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False


        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            _Informe_Generado = True

            Me.Cursor = Cursors.Default

            If _Informe_Analisis Then
                Me.Close()
                Return
            End If

            Me.Cursor = Cursors.Default
            Me.Enabled = True

            _Reg = _Sql.Fx_Cuenta_Registros(_Tabla_Paso)

            If Not CBool(_Reg) Then
                MessageBoxEx.Show(Me, "No existen datos que mostrar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Dim Fm As New Frm_Informe_Prox_Recep_Y_Comp_No_Desp(Frm_Informe_Prox_Recep_Y_Comp_No_Desp.Enum_Informe_Padre.Informe_Compromisos_No_Despachados,
                                                    Frm_Informe_Prox_Recep_Y_Comp_No_Desp.Enum_Informe.Sucursal,
                                                    _Tabla_Paso,
                                                    _Ud, False)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Frm_Informe_Compr_No_Despachados_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Consulta_sql = "Drop Table " & _Tabla_Paso
        _Sql.Ej_consulta_IDU(Consulta_sql, False)
    End Sub

    Private Sub Rdb_Todos_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Todos.CheckedChanged
        Chk_Incluir_COV.Visible = Rdb_Todos.Checked
        If Rdb_Todos.Checked Then
            Chk_Incluir_COV.Checked = False
        End If
    End Sub

    Private Sub Chk_NVVHabilitadasFacturar_CheckedChanged(sender As Object, e As EventArgs)
        If Not Chk_NVVHabilitadasFacturar.Checked Then
            If Not Fx_Tiene_Permiso(Me, "Inf00046") Then
                Chk_NVVHabilitadasFacturar.Checked = True
            End If
        End If
    End Sub
End Class
