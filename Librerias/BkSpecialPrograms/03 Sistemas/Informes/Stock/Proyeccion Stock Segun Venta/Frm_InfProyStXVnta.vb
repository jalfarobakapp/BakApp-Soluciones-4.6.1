Imports DevComponents.DotNetBar

Public Class Frm_InfProyStXVnta

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Filtro_VistInf1 As New List(Of Filtro_VistInf1)
    Dim _NombreTablaPaso As String
    Dim _NombreTablaPasoInforme As String
    Dim _Tbl_Informe As DataTable

    Dim _TblBodVenta As DataTable
    Dim _Tbl_Filtro_Sucursales As DataTable

    Dim _Filtro_Bodegas_Est_Vta_Todas As Boolean
    Dim _Filtro_Sucursales_Todas As Boolean

    Private _Filtro_Bodegas_Todas As Boolean
    Private _Filtro_Productos_Todos As Boolean
    Private _Filtro_Rubro_Productos_Todas As Boolean
    Private _Filtro_Marcas_Todas As Boolean
    Private _Filtro_Super_Familias_Todas As Boolean
    Private _Filtro_Familias_Todas As Boolean
    Private _Filtro_Sub_Familias_Todas As Boolean
    Private _Filtro_Clalibpr_Todas As Boolean
    Private _Filtro_Zonas_Productos_Todas As Boolean
    Private _Filtro_Categorias_Todas As Boolean
    Private _Filtro_Codigo_Madre_Todas As Boolean

    Private _Tbl_Filtro_Productos As DataTable
    Private _Tbl_Filtro_Rubro_Productos As DataTable
    Private _Tbl_Filtro_Bodegas As DataTable
    Private _Tbl_Filtro_Marcas As DataTable
    Private _Tbl_Filtro_Super_Familias As DataTable
    Private _Tbl_Filtro_Familias As DataTable
    Private _Tbl_Filtro_Sub_Familias As DataTable
    Private _Tbl_Filtro_Clalibpr As DataTable
    Private _Tbl_Filtro_Zonas_Productos As DataTable

    Private _Tbl_Filtro_Categorias As DataTable
    Private _Tbl_Filtro_Codigo_Madre As DataTable

    Public Property Cl_InfProyStXVnta As Cl_InfProyStXVnta


    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, True, False)



    End Sub

    Private Sub Frm_InfProyStXVnta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _Filtro_Bodegas_Est_Vta_Todas = True

        _Filtro_Sucursales_Todas = True
        _Filtro_Bodegas_Todas = True
        _Filtro_Productos_Todos = True
        _Filtro_Rubro_Productos_Todas = True
        _Filtro_Marcas_Todas = True
        _Filtro_Super_Familias_Todas = True
        _Filtro_Familias_Todas = True
        _Filtro_Sub_Familias_Todas = True
        _Filtro_Clalibpr_Todas = True
        _Filtro_Zonas_Productos_Todas = True
        _Filtro_Categorias_Todas = True
        _Filtro_Codigo_Madre_Todas = True

        Input_MesesEstudio.Value = Cl_InfProyStXVnta.Input_MesesEstudio
        Input_MesesProyeccion.Value = Cl_InfProyStXVnta.Input_MesesProyeccion

        Sb_Cargar_Vista_Informe()

        _NombreTablaPaso = Cl_InfProyStXVnta.NombreTablaPaso
        _NombreTablaPasoInforme = Cl_InfProyStXVnta.NombreTablaPasoInforme

        Sb_Actualizar_Informe("", "")
        Sb_Actualizar_Grilla()

        AddHandler Cmb_Vista_Informe.SelectedIndexChanged, AddressOf Sb_Actualizar_Grilla
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

    End Sub

    Private Sub Btn_Filtrar_Productos_Click(sender As Object, e As EventArgs) Handles Btn_Filtrar_Productos.Click
        ShowContextMenu(Menu_Contextual_Filtros_Productos)
    End Sub

    Private Sub Btn_Filtrar_Suc_Bod_Click(sender As Object, e As EventArgs) Handles Btn_Filtrar_Suc_Bod.Click
        ShowContextMenu(Menu_Contextual_Filtros_Suc_Bod)
    End Sub

    Sub Sb_Cargar_Vista_Informe()

        Dim _Lista As New Filtro_VistInf1

        Dim valoresCombo As New System.Collections.Generic.Dictionary(Of String, String)

        Sb_Insertar_Campo("Empresa", "EMPRESA", "Empresa", "RAZON", valoresCombo)
        Sb_Insertar_Campo("Sucursal", "SUCURSAL", "Sucursal", "NOKOSU", valoresCombo)
        Sb_Insertar_Campo("Bodega", "BODEGA", "Bodega", "NOKOBO", valoresCombo)
        Sb_Insertar_Campo("Codigo", "PRODUCTO", "Codigo", "Descripcion", valoresCombo)
        Sb_Insertar_Campo("Codigo_Nodo", "CODIGOS MADRE", "Codigo_Nodo", "Descripcion_Consolid", valoresCombo)
        Sb_Insertar_Campo("Identificacdor_NodoPadre", "CATEGORIAS", "Identificacdor_NodoPadre", "Descripcion_NP", valoresCombo)
        Sb_Insertar_Campo("Marca", "MARCA", "MRPR", "NOKOMR", valoresCombo)
        Sb_Insertar_Campo("SPFamilia", "SUPER FAMILIA", "FMPR", "NOKOFM", valoresCombo)
        Sb_Insertar_Campo("Familia", "FAMILIA", "PFPR", "NOKOPF", valoresCombo)
        Sb_Insertar_Campo("SubFamilia", "SUB FAMILIA", "HFPR", "NOKOHF", valoresCombo)

        Cmb_Vista_Informe.DisplayMember = "Value"
        Cmb_Vista_Informe.ValueMember = "Key"
        Cmb_Vista_Informe.DataSource = valoresCombo.ToArray

    End Sub

    Sub Sb_Insertar_Campo(_Codigo As String,
                          _Descripcion As String,
                          _Campos As String,
                          _Descripcion_Campos As String,
                          ByRef valoresCombo As Object)

        Dim _Lista As New Filtro_VistInf1

        _Lista.Codigo = _Codigo
        _Lista.Descripcion = _Descripcion
        _Lista.Campos = _Campos
        _Lista.Descripcion_Campos = _Descripcion_Campos
        valoresCombo.Add(_Codigo, _Descripcion)
        _Filtro_VistInf1.Add(_Lista)

    End Sub


    Sub Sb_Actualizar_Informe(_CondicionExtraordinaria As String, _CondicionAdicional As String)

        Dim Fm_Espera As New Frm_Form_Esperar
        Fm_Espera.BarraCircular.IsRunning = True
        Fm_Espera.Show()

        Consulta_sql = My.Resources.Recursos_InfProyStXVnta.SQLQuery_Actualiza_datos_InfStockProyecVnta
        Consulta_sql = Replace(Consulta_sql, "#Global_BaseBk#", _Global_BaseBk)
        Consulta_sql = Replace(Consulta_sql, "#MesesProyeccion#", Input_MesesProyeccion.Value)
        Consulta_sql = Replace(Consulta_sql, "#MesesEstudio#", Input_MesesEstudio.Value)
        Consulta_sql = Replace(Consulta_sql, "#TblPs#", _NombreTablaPaso)
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)

        Consulta_sql = Replace(Consulta_sql, "--Update" & _NombreTablaPaso & "CondicionExtraordinaria", _CondicionExtraordinaria)
        Consulta_sql = Replace(Consulta_sql, "--#CondicionAdicional#", _CondicionAdicional)
        _CondicionAdicional = Replace(_CondicionAdicional, "''", "'")
        Consulta_sql = Replace(Consulta_sql, "--#Condicion1Adicional#", _CondicionAdicional)

        'Dim _Filtro_Bodega As String

        'If _Filtro_Bodegas_Est_Vta_Todas Then
        '    _Filtro_Bodega = String.Empty
        'Else
        '    _Filtro_Bodega = Generar_Filtro_IN(_TblBodVenta, "Chk", "Codigo", False, True, "'")
        '    _Filtro_Bodega = "And Ddo.EMPRESA+Ddo.SULIDO+Ddo.BOSULIDO In " & _Filtro_Bodega
        'End If

        'Consulta_sql = Replace(Consulta_sql, "#FiltroBodegas#", _Filtro_Bodega)

        _Sql.Ej_consulta_IDU(Consulta_sql)

        Fm_Espera.Dispose()

        Me.Text = "INFORMA COMPARATIVO DE STOCK VS PROYECCION DE VENTA (" & _NombreTablaPaso & ")"

    End Sub

    Sub Sb_Actualizar_Grilla()

        Me.Cursor = Cursors.WaitCursor

        Dim _Codigo As String = Cmb_Vista_Informe.SelectedValue
        Dim _Campo As String
        Dim _Descripcion As String

        For Each _Fila As Filtro_VistInf1 In _Filtro_VistInf1

            If _Codigo = _Fila.Codigo Then
                _Campo = _Fila.Campos
                _Descripcion = _Fila.Descripcion_Campos
                Exit For
            End If

        Next

        Dim _Cont = 0
        Dim _CamposColumnas = String.Empty

        Consulta_sql = "Truncate Table " & _NombreTablaPasoInforme
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Dim _SqlFiltro = String.Empty

        _SqlFiltro = Fx_Filtro_Detalle()

        Consulta_sql = "Insert Into " & _NombreTablaPasoInforme & "(CODIGO,DESCRIPCION,PromVta,PromVta_Original,Stock_Fisico)" & vbCrLf &
                       "Select " & _Campo & "," & _Descripcion & ",Sum(PromVta),Sum(PromVta),SUM(Stock_Fisico) From " & _NombreTablaPaso & vbCrLf &
                       "Where 1 > 0" & vbCrLf &
                       _SqlFiltro & vbCrLf &
                       "Group By " & _Campo & "," & _Descripcion
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Select Top 1 * From " & _NombreTablaPaso
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _CampoStock, _UlCampoStock, _CampoPdte, _CampoFsrec As String

        Consulta_sql = "Select * From " & _NombreTablaPasoInforme
        Dim _TblInfGrilla As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        For i = 35 To _Tbl.Columns.Count - 1

            Dim _Nombre = _Tbl.Columns(i).ColumnName
            _Cont += 1

            If _Cont = 1 Or _Cont = 2 Then
                Consulta_sql = "Update " & _NombreTablaPasoInforme & " Set [" & _Nombre & "] = (Select SUM([" & _Nombre & "]) From " & _NombreTablaPaso & " Z1 Where Z1." & _Campo & " = " & _NombreTablaPasoInforme & ".CODIGO)"
                _Sql.Ej_consulta_IDU(Consulta_sql)
            End If

            If _Cont = 1 Then _CampoPdte = _Nombre
            If _Cont = 2 Then _CampoFsrec = _Nombre

            If _Cont = 3 Then

                _CampoStock = _Nombre

                If i = 37 Then
                    Consulta_sql = "Update " & _NombreTablaPasoInforme & " Set [" & _Nombre & "] = (Select SUM(Stock_Fisico) From " & _NombreTablaPaso & " Z1 Where Z1." & _Campo & " = " & _NombreTablaPasoInforme & ".CODIGO)"
                    _Sql.Ej_consulta_IDU(Consulta_sql)
                End If

                _UlCampoStock = _Nombre
                _Cont = 0

            End If

        Next

        Dim _AgruparCampo = String.Empty
        _CamposColumnas = String.Empty
        _Cont = 0

        For i = 35 To _Tbl.Columns.Count - 1

            Dim _Nombre = _Tbl.Columns(i).ColumnName
            _Cont += 1

            If _Cont = 1 Then _CampoPdte = _Nombre
            If _Cont = 2 Then _CampoFsrec = _Nombre

            If _Cont = 3 Then

                _CampoStock = _Nombre

                If i = 37 Then
                    _UlCampoStock = _CampoStock
                End If

                Consulta_sql = "Update " & _NombreTablaPasoInforme & " Set [" & _CampoStock & "] = ([" & _UlCampoStock & "]+[" & _CampoFsrec & "]+[" & _CampoPdte & "]) - PromVta"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Consulta_sql = "Update " & _NombreTablaPasoInforme & " Set [" & _CampoStock & "] = 0 Where [" & _CampoStock & "] < 0"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                _UlCampoStock = _Nombre
                _Cont = 0

            End If

        Next

        Consulta_sql = "Select * From " & _NombreTablaPasoInforme
        _Tbl_Informe = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Informe

            OcultarEncabezadoGrilla(Grilla)

            Dim _Display = 0

            .Columns("CODIGO").Width = 100
            .Columns("CODIGO").HeaderText = "Código"
            .Columns("CODIGO").Visible = True
            .Columns("CODIGO").Frozen = True
            .Columns("CODIGO").DisplayIndex = _Display
            _Display += 1

            .Columns("DESCRIPCION").Width = 330
            .Columns("DESCRIPCION").HeaderText = "Descripción"
            .Columns("DESCRIPCION").Visible = True
            .Columns("DESCRIPCION").Frozen = True
            .Columns("DESCRIPCION").DisplayIndex = _Display
            _Display += 1

            .Columns("PromVta").Width = 90
            .Columns("PromVta").HeaderText = "Prom.Vta"
            .Columns("PromVta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PromVta").DefaultCellStyle.Format = "##,#0.##"
            .Columns("PromVta").Visible = True
            .Columns("PromVta").DisplayIndex = _Display
            _Display += 1

            .Columns("Stock_Fisico").Width = 90
            .Columns("Stock_Fisico").HeaderText = "Stock Fisico"
            .Columns("Stock_Fisico").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Stock_Fisico").DefaultCellStyle.Format = "##,#0.##"
            .Columns("Stock_Fisico").Visible = True
            .Columns("Stock_Fisico").DisplayIndex = _Display
            _Display += 1

            For i = 35 To _Tbl.Columns.Count - 1

                Dim _Nombre = _Tbl.Columns(i).ColumnName
                Dim _ToolTipText = String.Empty

                If Mid(_Nombre, 1, 1) = "P" Then _ToolTipText = "Pendiente " & Mid(_Nombre, 2, 8)
                If Mid(_Nombre, 1, 1) = "S" Then _ToolTipText = "Stock físico que quedara en " & Mid(_Nombre, 2, 8)
                If Mid(_Nombre, 1, 1) = "R" Then _ToolTipText = "Facturas sin recepcionar " & Mid(_Nombre, 4, 8)

                .Columns(_Nombre).Width = 90
                .Columns(_Nombre).HeaderText = _Nombre
                .Columns(_Nombre).ToolTipText = _ToolTipText
                .Columns(_Nombre).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(_Nombre).DefaultCellStyle.Format = "##,#0.##"
                .Columns(_Nombre).Visible = True
                .Columns(_Nombre).DisplayIndex = _Display
                _Display += 1

            Next

        End With

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Btn_Actualizar_Informe_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar_Informe.Click

        'Sb_Crear_Tabla_Paso()
        'Sb_Actualizar_Informe("", "")
        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        'MessageBoxEx.Show(Me, "En Construcción...", "Bakapp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ExportarTabla_JetExcel_Tabla(_Tbl_Informe, Me, "Informe proyeccion")

    End Sub

    Private Sub Btn_Bodega_Vta_Estudio_Click(sender As Object, e As EventArgs) Handles Btn_Bodega_Vta_Estudio.Click

        Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Bodegas, False)
        Fm.Pro_Tbl_Filtro = _TblBodVenta

        Fm.ShowDialog(Me)

        If Fm.Pro_Filtrar Then

            _TblBodVenta = Fm.Pro_Tbl_Filtro

            If Fm.Pro_Filtrar_Todo Then
                _Filtro_Bodegas_Est_Vta_Todas = True
            Else
                If (_TblBodVenta Is Nothing) Then
                    _Filtro_Bodegas_Est_Vta_Todas = True
                Else
                    _Filtro_Bodegas_Est_Vta_Todas = False
                End If
            End If

        End If
        Fm.Dispose()

    End Sub

    Private Sub Btn_Filtro_Sucursales_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Sucursales.Click

        Dim _Sql_Filtro_Condicion_Extra = "And EMPRESA+KOSU In (Select Distinct Empresa+Sucursal From " & _NombreTablaPaso & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Sucursales,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Sucursales, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Sucursales_Todas, False) Then

            _Tbl_Filtro_Sucursales = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Sucursales_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "Sucursal" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "Sucursal"
            End If

        End If

    End Sub

    Function Fx_Filtro_Detalle()

        Dim _Filtro_Sucursales,
            _Filtro_Bodegas,
            _Filtro_Productos,
            _Filtro_Marcas,
            _Filtro_Rubros_Pr,
            _Filtro_Zonas_Pr,
            _Filtro_Categorias_Pr,
            _Filtro_Codigo_Madre_Pr,
            _Filtro_SuperFamilias,
            _Filtro_Familias,
            _Filtro_Sub_Familias,
            _Filtro_ClasLibre As String

        If _Filtro_Sucursales_Todas Then
            _Filtro_Sucursales = String.Empty
        Else
            _Filtro_Sucursales = Generar_Filtro_IN(_Tbl_Filtro_Sucursales, "Chk", "Codigo", False, True, "'")
            _Filtro_Sucursales = "And Sucursal IN " & _Filtro_Sucursales & vbCrLf
        End If

        If _Filtro_Bodegas_Todas Then
            _Filtro_Bodegas = String.Empty
        Else
            _Filtro_Bodegas = Generar_Filtro_IN(_Tbl_Filtro_Bodegas, "Chk", "Codigo", False, True, "'")
            _Filtro_Bodegas = "And Empresa+Sucursal+Bodega IN " & _Filtro_Bodegas & vbCrLf
        End If


        If _Filtro_Productos_Todos Then
            _Filtro_Productos = String.Empty
        Else
            _Filtro_Productos = Generar_Filtro_IN(_Tbl_Filtro_Productos, "Chk", "Codigo", False, True, "'")
            _Filtro_Productos = "And Codigo IN " & _Filtro_Productos & vbCrLf
        End If

        'If _Filtro_Rubro_Productos_Todas Then
        '    _Filtro_Rubros_Pr = String.Empty
        'Else
        '    _Filtro_Rubros_Pr = Generar_Filtro_IN(_Tbl_Filtro_Rubro_Productos, "Chk", "Codigo", False, True, "'")
        '    _Filtro_Ciudad = "And RUEN IN " & _Filtro_Comunas & vbCrLf
        'End If

        If _Filtro_Marcas_Todas Then
            _Filtro_Marcas = String.Empty
        Else
            _Filtro_Marcas = Generar_Filtro_IN(_Tbl_Filtro_Marcas, "Chk", "Codigo", False, True, "'")
            _Filtro_Marcas = "And MRPR In " & _Filtro_Marcas & vbCrLf
        End If

        If _Filtro_Super_Familias_Todas Then
            _Filtro_SuperFamilias = String.Empty
        Else
            _Filtro_SuperFamilias = Generar_Filtro_IN(_Tbl_Filtro_Super_Familias, "Chk", "Codigo", False, True, "'")
            _Filtro_SuperFamilias = "And FMPR In " & _Filtro_SuperFamilias & vbCrLf
        End If

        If _Filtro_Familias_Todas Then
            _Filtro_Familias = String.Empty
        Else
            _Filtro_Familias = Generar_Filtro_IN(_Tbl_Filtro_Familias, "Chk", "Codigo", False, True, "'")
            _Filtro_Familias = "And FMPR+PFPR In " & _Filtro_Familias & vbCrLf
        End If

        If _Filtro_Sub_Familias_Todas Then
            _Filtro_Sub_Familias = String.Empty
        Else
            _Filtro_Sub_Familias = Generar_Filtro_IN(_Tbl_Filtro_Sub_Familias, "Chk", "Codigo", False, True, "'")
            _Filtro_Sub_Familias = "And FMPR+PFPR+HFPR In " & _Filtro_Sub_Familias & vbCrLf
        End If

        If _Filtro_Clalibpr_Todas Then
            _Filtro_ClasLibre = String.Empty
        Else
            _Filtro_ClasLibre = Generar_Filtro_IN(_Tbl_Filtro_Clalibpr, "Chk", "Codigo", False, True, "'")
            _Filtro_ClasLibre = "And CLALIBPR In " & _Filtro_ClasLibre & vbCrLf
        End If

        If _Filtro_Zonas_Productos_Todas Then
            _Filtro_Zonas_Pr = String.Empty
        Else
            _Filtro_Zonas_Pr = Generar_Filtro_IN(_Tbl_Filtro_Zonas_Productos, "Chk", "Codigo", False, True, "'")
            _Filtro_Zonas_Pr = "And KOPRCT IN (Select KOPR From MAEPR Where ZONAPR In " & _Filtro_Zonas_Pr & ")" & vbCrLf
        End If

        If _Filtro_Categorias_Todas Then
            _Filtro_Categorias_Pr = String.Empty
        Else
            _Filtro_Categorias_Pr = Generar_Filtro_IN(_Tbl_Filtro_Categorias, "Chk", "Codigo", False, True, "")
            _Filtro_Categorias_Pr = "And Identificacdor_NodoPadre In " & _Filtro_Categorias_Pr & vbCrLf
        End If

        If _Filtro_Codigo_Madre_Todas Then
            _Filtro_Codigo_Madre_Pr = String.Empty
        Else
            _Filtro_Codigo_Madre_Pr = Generar_Filtro_IN(_Tbl_Filtro_Codigo_Madre, "Chk", "Codigo", False, True, "")
            _Filtro_Codigo_Madre_Pr = "And Codigo_Nodo In " & _Filtro_Codigo_Madre_Pr & vbCrLf
        End If

        'Private _Filtro_Categorias_Todas As Boolean
        'Private _Filtro_Codigo_Madre_Todas As Boolean
        '---------------------------

        Dim _Filtro_Tipr As String


        Dim _Filtro_Externo = _Filtro_Sucursales &
                              _Filtro_Bodegas &
                              _Filtro_Productos &
                              _Filtro_Rubros_Pr &
                              _Filtro_Marcas &
                              _Filtro_Zonas_Pr &
                              _Filtro_SuperFamilias &
                              _Filtro_Familias &
                              _Filtro_Sub_Familias &
                              _Filtro_ClasLibre &
                              _Filtro_Categorias_Pr &
                              _Filtro_Codigo_Madre_Pr

        Return _Filtro_Externo

    End Function

    Private Sub Btn_Filtro_Pro_Productos_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_Productos.Click

        Dim _Sql_Filtro_Condicion_Extra = "And KOPR In (Select Distinct Codigo From " & _NombreTablaPaso & ")"
        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Productos_Todos, False) Then

            _Tbl_Filtro_Productos = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Productos_Todos = _Filtrar.Pro_Filtro_Todas

            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Btn_Filtro_Pro_Super_Familias_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_Super_Familias.Click

        Dim _Sql_Filtro_Condicion_Extra = "And KOFM In (Select Distinct FMPR From " & _NombreTablaPaso & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Super_Familias,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Super_Familia, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Super_Familias_Todas) Then

            _Tbl_Filtro_Super_Familias = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Super_Familias_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "SPFamilia" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "SPFamilia"
            End If

        End If

    End Sub

    Private Sub Btn_Filtro_Pro_Familias_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_Familias.Click

        Dim _Sql_Filtro_Condicion_Extra = String.Empty
        Dim _Filtro_Extra_Familias = String.Empty

        If Not _Filtro_Super_Familias_Todas Then
            If Not (_Tbl_Filtro_Super_Familias Is Nothing) Then
                If _Tbl_Filtro_Super_Familias.Rows.Count Then

                    Dim _Fl_Super_Familias = Generar_Filtro_IN(_Tbl_Filtro_Super_Familias, "Chk", "Codigo", False, True, "'")
                    _Filtro_Extra_Familias = vbCrLf & "And KOFM In " & _Fl_Super_Familias

                End If
            End If
        End If

        _Sql_Filtro_Condicion_Extra = "And KOPF In (Select Distinct PFPR From " & _NombreTablaPaso & ")" & _Filtro_Extra_Familias

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Familias,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Familia, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Familias_Todas) Then

            _Tbl_Filtro_Familias = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Familias_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "Familia" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "Familia"
            End If
        End If

    End Sub

    Private Sub Btn_Filtro_Pro_Sub_Familias_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_Sub_Familias.Click

        Dim _Sql_Filtro_Condicion_Extra = String.Empty
        Dim _Filtro_Extra_Familias = String.Empty

        If Not _Filtro_Super_Familias_Todas Then
            If Not (_Tbl_Filtro_Super_Familias Is Nothing) Then
                If _Tbl_Filtro_Super_Familias.Rows.Count Then

                    Dim _Fl_Super_Familias = Generar_Filtro_IN(_Tbl_Filtro_Super_Familias, "Chk", "Codigo", False, True, "'")
                    _Filtro_Extra_Familias = vbCrLf & "And KOFM In " & _Fl_Super_Familias

                End If
            End If
        End If

        If Not _Filtro_Familias_Todas Then
            If Not (_Tbl_Filtro_Familias Is Nothing) Then
                If _Tbl_Filtro_Familias.Rows.Count Then

                    Dim _Fl_Familias = Generar_Filtro_IN(_Tbl_Filtro_Familias, "Chk", "Codigo", False, True, "'")
                    _Filtro_Extra_Familias += vbCrLf & "And KOFM+KOPF In " & _Fl_Familias

                End If
            End If
        End If

        _Sql_Filtro_Condicion_Extra = "And KOPF In (Select Distinct PFPR From " & _NombreTablaPaso & ")" & vbCrLf &
                                       _Filtro_Extra_Familias

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Sub_Familias,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Sub_Familia, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Sub_Familias_Todas) Then

            _Tbl_Filtro_Sub_Familias = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Sub_Familias_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "SubFamilia" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "SubFamilia"
            End If

        End If

    End Sub

    Private Sub Btn_Filtro_Pro_Marcas_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_Marcas.Click

        Dim _Sql_Filtro_Condicion_Extra = "And KOMR In (Select Distinct MRPR From " & _NombreTablaPaso & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Marcas,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Marcas, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Marcas_Todas) Then

            _Tbl_Filtro_Marcas = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Marcas_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "Marca" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "Marca"
            End If

        End If

    End Sub

    Private Sub Btn_Filtro_Pro_Clas_Libre_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_Clas_Libre.Click

        Dim _Sql_Filtro_Condicion_Extra = "And KOTABLA = 'CLALIBPR' And KOCARAC In (Select Distinct CLALIBPR From " & _NombreTablaPaso & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Clalibpr,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Tabcarac, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Clalibpr_Todas) Then

            _Tbl_Filtro_Clalibpr = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Clalibpr_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "CLALIBPR" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "CLALIBPR"
            End If

        End If

    End Sub

    Private Sub Btn_Filtro_Pro_Rubros_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_Rubros.Click

        Dim _Sql_Filtro_Condicion_Extra = "And KORU In (Select Distinct RUPR From " & _NombreTablaPaso & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Rubro_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Rubros, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Rubro_Productos_Todas, True) Then

            _Tbl_Filtro_Rubro_Productos = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Rubro_Productos_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "RUPR" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "RUPR"
            End If

        End If

    End Sub

    Private Sub Btn_Filtro_Pro_Zonas_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_Zonas.Click

        Dim _Sql_Filtro_Condicion_Extra = "And KOZO In (Select Distinct ZOPR From " & _NombreTablaPaso & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Zonas_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Tabla_Zonas, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Zonas_Productos_Todas, True) Then

            _Tbl_Filtro_Zonas_Productos = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Zonas_Productos_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "ZOPR" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "ZOPR"
            End If

        End If

    End Sub

    Private Sub Btn_Filtro_Bodegas_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Bodegas.Click

        Dim _Sql_Filtro_Condicion_Extra = "And EMPRESA+KOSU+KOBO In (Select Distinct Empresa+Sucursal+Bodega From " & _NombreTablaPaso & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Bodegas,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Bodegas, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Bodegas_Todas, False) Then

            _Tbl_Filtro_Bodegas = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Bodegas_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "Bodega" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "Bodega"
            End If

        End If

    End Sub

    Private Sub Btn_Filtro_Pro_Categorias_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_Categorias.Click

        Dim _Sql_Filtro_Condicion_Extra = "And KOMR In (Select Distinct MRPR From " & _NombreTablaPaso & ")"

        _Sql_Filtro_Condicion_Extra = "And Codigo_Nodo In (Select Distinct Identificacdor_NodoPadre From " &
            _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Nodo_Raiz = 1 And Es_Seleccionable = 1)" & vbCrLf &
            "And Codigo_Nodo In (Select Distinct Identificacdor_NodoPadre From " & _NombreTablaPaso & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_TblArbol_Asociaciones"
        _Filtrar.Campo = "Codigo_Nodo"
        _Filtrar.Descripcion = "Descripcion"

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Categorias,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Categorias_Todas) Then

            _Tbl_Filtro_Categorias = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Categorias_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "Identificacdor_NodoPadre" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "Identificacdor_NodoPadre"
            End If

        End If

    End Sub

    Private Sub Btn_Filtro_Pro_Codigos_Madre_Click(sender As Object, e As EventArgs) Handles Btn_Filtro_Pro_Codigos_Madre.Click

        Dim _Sql_Filtro_Condicion_Extra = "And KOMR In (Select Distinct MRPR From " & _NombreTablaPaso & ")"

        _Sql_Filtro_Condicion_Extra = "And Nodo_Raiz = 1 And Es_Seleccionable = 1" & vbCrLf &
            "And Codigo_Nodo In (Select Distinct Codigo_Nodo From " & _NombreTablaPaso & ")"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_TblArbol_Asociaciones"
        _Filtrar.Campo = "Codigo_Nodo"
        _Filtrar.Descripcion = "Descripcion"

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Codigo_Madre,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _Sql_Filtro_Condicion_Extra,
                               _Filtro_Codigo_Madre_Todas) Then

            _Tbl_Filtro_Codigo_Madre = _Filtrar.Pro_Tbl_Filtro
            _Filtro_Codigo_Madre_Todas = _Filtrar.Pro_Filtro_Todas

            If Cmb_Vista_Informe.SelectedValue = "Codigo_Nodo" Then
                Sb_Actualizar_Grilla()
            Else
                Cmb_Vista_Informe.SelectedValue = "Codigo_Nodo"
            End If

        End If

    End Sub

    Sub Sb_Simular(ByRef _Fila As DataGridViewRow, _PromVta As Double)

        Dim _Codigo = _Fila.Cells("CODIGO").Value
        Dim _Stock_Fisico As Double = _Fila.Cells("Stock_Fisico").Value
        Dim _ValorCampoPdte, _ValorCampoFsrec, _ValorCampoStock, _ValorUlCampoStock As Double

        _Fila.Cells("PromVta").Value = _PromVta

        Dim _Cont = 0

        For i = 5 To _Tbl_Informe.Columns.Count - 1

            Dim _Valor As Double = _Fila.Cells(i).Value
            Dim _NomColumna As String = _Tbl_Informe.Columns(i).ColumnName
            _Cont += 1

            If _Cont = 1 Then _ValorCampoPdte = _Valor
            If _Cont = 2 Then _ValorCampoFsrec = _Valor

            If _Cont = 3 Then

                If i = 7 Then
                    _ValorCampoStock = _Stock_Fisico
                    _Valor = (_ValorCampoFsrec + _ValorCampoPdte + _ValorCampoStock) - _PromVta
                Else
                    _Valor = (_ValorCampoFsrec + _ValorCampoPdte + _ValorUlCampoStock) - _PromVta
                End If

                If _Valor < 0 Then
                    _Valor = 0
                End If

                Consulta_sql = "Update " & _NombreTablaPasoInforme & " Set [" & _NomColumna & "] = " & De_Num_a_Tx_01(_Valor, False, 5) & vbCrLf &
                               "Where CODIGO = '" & _Codigo & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                _Fila.Cells(_NomColumna).Value = _Valor
                _ValorUlCampoStock = _Valor

                _Cont = 0

            End If

        Next

    End Sub

    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    Btn_Cambiar_PromVntaPorc.Visible = True
                    Btn_Cambiar_PromVntaValor.Visible = True
                    ShowContextMenu(Menu_Contextual_Edicion_Datos)
                End If
            End With
        End If
    End Sub

    Private Sub Btn_Cambiar_PromVntaPorc_Click(sender As Object, e As EventArgs) Handles Btn_Cambiar_PromVntaPorc.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Codigo = _Fila.Cells("CODIGO").Value

        Dim _Porc As Double
        Dim _Aceptar As Boolean = InputBox_Bk(Me, "Ingrese el porcentaje de aumento para la simulacion del calculo del stock",
                                              "Simular Stock con aumento de venta en %",
                                              _Porc, False,, 3, True, _Tipo_Imagen.Texto,, _Tipo_Caracter.Solo_Numeros_Enteros)

        If Not _Aceptar Then
            Return
        End If

        Dim _PorcSTR As Double = (_Porc / 100) + 1

        Dim _PromVta_Original As Double = _Fila.Cells("PromVta_Original").Value
        Dim _PromVta As Double = _PromVta_Original * _PorcSTR

        Sb_Simular(_Fila, _PromVta)

    End Sub

    Private Sub Btn_Cambiar_PromVntaValor_Click(sender As Object, e As EventArgs) Handles Btn_Cambiar_PromVntaValor.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Codigo = _Fila.Cells("CODIGO").Value
        Dim _PromVta_Original As Double = _Fila.Cells("PromVta_Original").Value

        Dim _Aceptar As Boolean = InputBox_Bk(Me, "Ingrese el valor de aumento para la simulacion del calculo del stock",
                                              "Simular Stock con aumento de venta",
                                              _PromVta_Original, False,, 0, True, _Tipo_Imagen.Texto,, _Tipo_Caracter.Solo_Numeros_Enteros)

        If Not _Aceptar Then
            Return
        End If

        Dim _PromVta As Double = _PromVta_Original

        Sb_Simular(_Fila, _PromVta)

    End Sub

End Class
