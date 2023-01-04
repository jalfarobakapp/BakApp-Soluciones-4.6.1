Imports DevComponents.DotNetBar

Public Class Frm_BusquedaDocumento_Filtro

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Enum _TipoDoc_Sel
        Todos
        Compra
        Venta
        Guias
        BkPost
        Personalizado
    End Enum

    Dim _TipoDoc_Seleccionado As _TipoDoc_Sel
    Dim _Sql_Filtro_Documentos_extra As String

    Dim _Tbl_Filtro_Documentos As DataTable
    Dim _Tbl_Filtro_Funcionarios As DataTable
    Dim _Tbl_Filtro_Entidades As DataTable
    Dim _Tbl_Filtro_Sucursal_Doc As DataTable
    Dim _Row_Documento_Seleccionado As DataRow

    Dim _Sql_Filtro_Otro_Filtro As String

    Dim _CodEntidad, _SucEntidad As String
    Dim _Row_Entidad As DataRow

    Dim _Row_Producto As DataRow

    Dim _Imprimir_Codigos_Barra As Boolean
    Dim _Abrir_Seleccionado As Boolean

    Dim _Pago_a_Documento As Boolean
    Dim _Mostrar_Solo_Datos_Usuario_Activo As Boolean
    Dim _Seleccion_Multiple As Boolean
    Dim _Tbl_DocSeleccionados As DataTable

    Dim _Filtrar_Doc_No_Asociados_Recargo As Boolean
    Dim _Codigo_Recargo As String
    Dim _Ocultar_Envio_Correos_Masivamente As Boolean
    Dim _Abrir_Cerrar_Documentos_Compromiso As Boolean
    Dim _Mostrar_Vales_Transitorios As Boolean

#Region "PROPIEDADES"

    Public Property Pro_TipoDoc_Seleccionado() As _TipoDoc_Sel
        Get

        End Get
        Set(value As _TipoDoc_Sel)
            _TipoDoc_Seleccionado = value
        End Set
    End Property

    Public Property Pro_Sql_Filtro_Documentos_Extra() As String
        Get
            Return _Sql_Filtro_Documentos_extra
        End Get
        Set(value As String)
            _Sql_Filtro_Documentos_extra = value
        End Set
    End Property

    Public Property Pro_Sql_Filtro_Otro_Filtro() As String
        Get
            Return _Sql_Filtro_Otro_Filtro
        End Get
        Set(value As String)
            _Sql_Filtro_Otro_Filtro = value
        End Set
    End Property

    Public Property Pro_Row_Entidad() As DataRow
        Get
            Return _Row_Entidad
        End Get
        Set(value As DataRow)
            _Row_Entidad = value
            If Not _Row_Entidad Is Nothing Then
                _CodEntidad = _Row_Entidad.Item("KOEN")
                _SucEntidad = _Row_Entidad.Item("SUEN")
                Txt_Entidad.Text = "Entidad: " & Trim(_CodEntidad) & ", " & _Row_Entidad.Item("NOKOEN")
                Rdb_Entidad_Una.Checked = True
            End If
        End Set
    End Property

    Public Property Pro_Row_Documento_Seleccionado() As DataRow
        Get
            Return _Row_Documento_Seleccionado
        End Get
        Set(value As DataRow)

        End Set
    End Property

    Public Property Pro_Pago_a_Documento() As Boolean
        Get
            Return _Pago_a_Documento
        End Get
        Set(value As Boolean)
            _Pago_a_Documento = value

            If _Pago_a_Documento Then
                Rdb_Tipo_Documento_Algunos.Enabled = False
                Grupo_Estado_Documento.Enabled = False
            End If

        End Set
    End Property

    Public Property Pro_Chk_Funcionario_Todos() As Boolean
        Get
            Return Rdb_Funcionarios_Todos.Checked
        End Get
        Set(value As Boolean)
            Rdb_Funcionarios_Todos.Checked = value
        End Set
    End Property

    Public Property Pro_Chk_Funcionarios_Algunos() As Boolean
        Get
            Return Rdb_Funcionarios_Algunos.Checked
        End Get
        Set(value As Boolean)
            Rdb_Funcionarios_Algunos.Checked = value
        End Set
    End Property

    Public Property Pro_Chk_Funcionarios_Uno() As Boolean
        Get
            Return Rdb_Funcionarios_Uno.Checked
        End Get
        Set(value As Boolean)
            Rdb_Funcionarios_Uno.Checked = value
        End Set
    End Property

    Public Property Pro_Mostrar_Solo_Datos_Usuario_Activo() As Boolean
        Get
            Return _Mostrar_Solo_Datos_Usuario_Activo
        End Get
        Set(value As Boolean)
            _Mostrar_Solo_Datos_Usuario_Activo = value
        End Set
    End Property

    Public Property Pro_Row_Producto As DataRow
        Get
            Return _Row_Producto
        End Get
        Set(value As DataRow)
            _Row_Producto = value
            If Not _Row_Producto Is Nothing Then
                Dim _Kopr = _Row_Producto.Item("KOPR")
                Dim _Nokopr = _Row_Producto.Item("NOKOPR")
                Txt_Producto.Text = "Producto: " & Trim(_Kopr) & ", " & _Nokopr
                Rdb_Producto_Uno.Checked = True
            End If
        End Set
    End Property

    Public Property Seleccion_Multiple As Boolean
        Get
            Return _Seleccion_Multiple
        End Get
        Set(value As Boolean)
            _Seleccion_Multiple = value
        End Set
    End Property

    Public Property Tbl_DocSeleccionados As DataTable
        Get
            Return _Tbl_DocSeleccionados
        End Get
        Set(value As DataTable)
            _Tbl_DocSeleccionados = value
        End Set
    End Property

    Public Property Filtrar_Doc_No_Asociados_Recargo As Boolean
        Get
            Return _Filtrar_Doc_No_Asociados_Recargo
        End Get
        Set(value As Boolean)
            _Filtrar_Doc_No_Asociados_Recargo = value
        End Set
    End Property

    Public Property Codigo_Recargo As String
        Get
            Return _Codigo_Recargo
        End Get
        Set(value As String)
            _Codigo_Recargo = value
        End Set
    End Property

    Public Property Ocultar_Envio_Correos_Masivamente As Boolean
        Get
            Return _Ocultar_Envio_Correos_Masivamente
        End Get
        Set(value As Boolean)
            _Ocultar_Envio_Correos_Masivamente = value
        End Set
    End Property

    Public Property Abrir_Cerrar_Documentos_Compromiso As Boolean
        Get
            Return _Abrir_Cerrar_Documentos_Compromiso
        End Get
        Set(value As Boolean)
            _Abrir_Cerrar_Documentos_Compromiso = value
        End Set
    End Property

    Public Property Mostrar_Vales_Transitorios As Boolean
        Get
            Return _Mostrar_Vales_Transitorios
        End Get
        Set(value As Boolean)
            _Mostrar_Vales_Transitorios = value
        End Set
    End Property

#End Region

    Public Sub New(Abrir_Seleccionado As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Abrir_Seleccionado = Abrir_Seleccionado

        '-- ESTA INSTRUCCION CIERRA LOS VENCIMIENTOS QUE YA ESTAN CANCELADOS COMPLETAMENTE
        'Dim Fm As New Frm_Reparar_Maeven(Nothing)
        'Fm.Fx_Reparar_Maeven(Me)
        'Fm.Dispose()

        If Global_Thema = Enum_Themas.Oscuro Or Global_Thema = Enum_Themas.Oscuro_Ligth Then ' Dark
            BtnAceptar.ForeColor = Color.White
            TxtNroDocumento.FocusHighlightEnabled = False
        End If

        DtpFechaInicio.Value = Now.Date
        DtpFechaFin.Value = Now.Date

    End Sub

    Private Sub Frm_BusquedaDocumento_Filtro_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Btn_Documentos.Enabled = Rdb_Tipo_Documento_Algunos.Checked
        TxtNroDocumento.Enabled = Rdb_Tipo_Documento_Algunos.Checked
        LblNroDocumento.Enabled = Rdb_Tipo_Documento_Algunos.Checked

        Consulta_sql = "SELECT KOFU AS Padre,KOFU+' - '+NOKOFU AS Hijo FROM TABFU ORDER BY KOFU"
        caract_combo(CmbFuncionarios)

        CmbFuncionarios.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        CmbFuncionarios.SelectedValue = FUNCIONARIO

        'AddHandler ChkTipoDocumento_Todos.CheckedChanged, AddressOf Sb_Grupo_Documento
        AddHandler Rdb_Tipo_Documento_Algunos.CheckedChanged, AddressOf Sb_Grupo_Documento
        AddHandler Rdb_Tipo_Documento_Uno.CheckedChanged, AddressOf Sb_Grupo_Documento


        AddHandler Rdb_Entidad_Todas.CheckedChanged, AddressOf Sb_Grupo_Entidad
        AddHandler Rdb_Entidad_Una.CheckedChanged, AddressOf Sb_Grupo_Entidad

        AddHandler Rdb_Funcionarios_Todos.CheckedChanged, AddressOf Sb_Grupo_Funcionarios
        AddHandler Rdb_Funcionarios_Algunos.CheckedChanged, AddressOf Sb_Grupo_Funcionarios
        AddHandler Rdb_Funcionarios_Uno.CheckedChanged, AddressOf Sb_Grupo_Funcionarios

        AddHandler Rdb_Fecha_Emision_Cualquiera.CheckedChanged, AddressOf Sb_Grupo_Fecha
        AddHandler Rdb_Fecha_Emision_Desde_Hasta.CheckedChanged, AddressOf Sb_Grupo_Fecha

        AddHandler Rdb_Producto_Todos.CheckedChanged, AddressOf Sb_Grupo_Producto
        AddHandler Rdb_Producto_Uno.CheckedChanged, AddressOf Sb_Grupo_Producto

        Sb_Grupo_Documento()
        Sb_Grupo_Entidad()
        Sb_Grupo_Funcionarios()
        Sb_Grupo_Fecha()
        Sb_Grupo_Producto()

        Rdb_Tipo_Documento_Uno.Checked = True

        If _Mostrar_Solo_Datos_Usuario_Activo Then
            Rdb_Funcionarios_Uno.Checked = True
            CmbFuncionarios.Enabled = False
        End If

        _Row_Documento_Seleccionado = Nothing

        Me.ActiveControl = TxtNroDocumento

    End Sub

    Private Sub Btn_Documentos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Documentos.Click
        Sb_Filtro_documentos(_TipoDoc_Seleccionado)
    End Sub

    Sub Sb_Filtro_documentos(_TipoBusqueda As _TipoDoc_Sel)

        Dim _Sql_Filtro_Condicion_Extra = String.Empty ' "And TIPR = 'FPN' And ATPR = ''"

        Select Case _TipoBusqueda
            Case _TipoDoc_Sel.Todos ' Todos
                _Sql_Filtro_Condicion_Extra = ""
            Case _TipoDoc_Sel.Compra ' Compras
                _Sql_Filtro_Condicion_Extra = "WHERE TIGEDO = 'E'"
            Case _TipoDoc_Sel.Venta ' Ventas
                _Sql_Filtro_Condicion_Extra = "WHERE TIGEDO = 'I'"
            Case _TipoDoc_Sel.BkPost
                _Sql_Filtro_Condicion_Extra = "WHERE TIDO IN ('BLV','FCV','COV','NVV')"
            Case _TipoDoc_Sel.Guias
                _Sql_Filtro_Condicion_Extra = "WHERE TIDO IN ('GAR','GCL','GDD','GDI','GDP','GDV','GRC','GRD','GRI','GRP','GTI')"
            Case _TipoDoc_Sel.Personalizado
                ' _Sql_Filtro_Condicion_Extra = _Sql_Filtro_Documentos_extra
        End Select


        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Documentos, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            _Tbl_Filtro_Documentos = _Filtrar.Pro_Tbl_Filtro
            If _Filtrar.Pro_Filtro_Todas Then
                Consulta_sql = "SELECT TIDO AS 'Codigo', NOTIDO AS 'Descripcion' FROM TABTIDO"
                _Tbl_Filtro_Documentos = _Sql.Fx_Get_Tablas(Consulta_sql)
            End If

        End If

    End Sub

    Sub Sb_Grupo_Documento()

        Btn_Documentos.Enabled = Rdb_Tipo_Documento_Algunos.Checked

        LblNroDocumento.Enabled = Rdb_Tipo_Documento_Uno.Checked
        CmbTipoDeDocumentos.Enabled = Rdb_Tipo_Documento_Uno.Checked
        TxtNroDocumento.Enabled = Rdb_Tipo_Documento_Uno.Checked

        If Rdb_Tipo_Documento_Uno.Checked Then
            TxtNroDocumento.Focus()
        End If

    End Sub

    Private Sub Btn_Funcionarios_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Funcionarios.Click
        Sb_Filtro_funcionarios()
    End Sub

    Sub Sb_Filtro_funcionarios()

        Dim _Sql_Filtro_Condicion_Extra = String.Empty

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Funcionarios,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            _Tbl_Filtro_Funcionarios = _Filtrar.Pro_Tbl_Filtro

        End If

    End Sub

    Sub Sb_Grupo_Funcionarios()
        Btn_Funcionarios.Enabled = Rdb_Funcionarios_Algunos.Checked
        CmbFuncionarios.Enabled = Rdb_Funcionarios_Uno.Checked
    End Sub

    Public Sub Sb_LlenarCombo_FlDoc(_TipoBusqueda As _TipoDoc_Sel,
                                    _TipoDoc_Seleccionado As String,
                                    Optional _Sql_Filtro_Documentos As String = "")

        Select Case _TipoBusqueda
            Case _TipoDoc_Sel.Todos ' Todos
                Consulta_sql = "SELECT '' As Padre,'Cualquiera...' as Hijo" & vbCrLf & "Union" & vbCrLf &
                               "SELECT TIDO AS Padre,TIDO+' - '+NOTIDO AS Hijo FROM TABTIDO ORDER BY Padre"
            Case _TipoDoc_Sel.Compra ' Compras
                Consulta_sql = "SELECT TIDO AS Padre,TIDO+' - '+NOTIDO AS Hijo FROM TABTIDO WHERE TIGEDO = 'E' ORDER BY TIDO"
            Case _TipoDoc_Sel.Venta ' Ventas
                Consulta_sql = "SELECT TIDO AS Padre,TIDO+' - '+NOTIDO AS Hijo FROM TABTIDO WHERE TIGEDO = 'I' ORDER BY TIDO"
            Case _TipoDoc_Sel.BkPost
                Consulta_sql = "SELECT TIDO AS Padre,TIDO+' - '+NOTIDO AS Hijo FROM TABTIDO WHERE TIDO IN ('BLV','FCV','COV','NVV') ORDER BY TIDO"
            Case _TipoDoc_Sel.Guias
                Consulta_sql = "SELECT TIDO AS Padre,TIDO+' - '+NOTIDO AS Hijo FROM TABTIDO WHERE TIDO IN ('GAR','GCL','GDD','GDI','GDP','GDV','GRC','GRD','GRI','GRP','GTI') ORDER BY TIDO"
            Case _TipoDoc_Sel.Personalizado
                Consulta_sql = "SELECT TIDO AS Padre,TIDO+' - '+NOTIDO AS Hijo FROM TABTIDO" & vbCrLf & _Sql_Filtro_Documentos & vbCrLf &
                               "ORDER BY TIDO"
        End Select

        caract_combo(CmbTipoDeDocumentos)

        CmbTipoDeDocumentos.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        CmbTipoDeDocumentos.SelectedValue = _TipoDoc_Seleccionado

    End Sub

    Sub Sb_Grupo_Entidad()
        Btn_Entidad_Una.Enabled = Rdb_Entidad_Una.Checked
        Txt_Entidad.Enabled = Rdb_Entidad_Una.Checked
    End Sub

    Sub Sb_Grupo_Fecha()
        LblFecha1.Enabled = Rdb_Fecha_Emision_Desde_Hasta.Checked
        LblFecha2.Enabled = Rdb_Fecha_Emision_Desde_Hasta.Checked
        DtpFechaInicio.Enabled = Rdb_Fecha_Emision_Desde_Hasta.Checked
        DtpFechaFin.Enabled = Rdb_Fecha_Emision_Desde_Hasta.Checked
    End Sub

    Sub Sb_Grupo_Producto()
        Btn_Producto_Uno.Enabled = Rdb_Producto_Uno.Checked
        Txt_Producto.Enabled = Rdb_Producto_Uno.Checked
        If Rdb_Producto_Todos.Checked Then
            Txt_Producto.Text = String.Empty
            _Row_Producto = Nothing
        End If
    End Sub

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        Sb_Buscar_documentos()
    End Sub

    Public Sub Sb_Buscar_documentos()

        Dim _Sql_Filtro_Entidades = String.Empty
        Dim _Sql_Filtro_Documentos = String.Empty
        Dim _Sql_Nro_Documento = String.Empty
        Dim _Sql_Filtro_Fucnionarios = String.Empty
        Dim _Sql_Filtro_Fechas = String.Empty
        Dim _Sql_Filtro_Estado = String.Empty
        Dim _Sql_Filtro_Producto = String.Empty
        Dim _Sql_Filtro_Sucursal_Doc = String.Empty
        Dim _Sql_Filtro_Vales_Transitorios = String.Empty
        Dim _Sql_Orden = String.Empty
        Dim _Sql_Occ = String.Empty
        Dim _Sql_Placa = String.Empty
        Dim _Sql_RetMerca = String.Empty

        Dim _Usar_Otro_Filtros As Boolean

        If Not String.IsNullOrEmpty(_Sql_Filtro_Otro_Filtro) Then
            _Usar_Otro_Filtros = True
        Else
            _Usar_Otro_Filtros = False
        End If

        _Mostrar_Vales_Transitorios = Chk_Mostrar_Vales_Transitorios.Checked

        If Rdb_Tipo_Documento_Algunos.Checked Then
            Dim _FlDoc As Boolean

            _FlDoc = (_Tbl_Filtro_Documentos Is Nothing)

            If _FlDoc Then
                _FlDoc = CBool(_Tbl_Filtro_Documentos.Rows.Count)
            End If

            Dim _Fl = Generar_Filtro_IN(_Tbl_Filtro_Documentos, "", "Codigo", False, False, "'")
            If _Fl = "()" Then _FlDoc = True

            If Not _FlDoc Then
                _Sql_Filtro_Documentos = "And Edo.TIDO In " & Generar_Filtro_IN(_Tbl_Filtro_Documentos, "", "Codigo", False, False, "'")
            Else
                MessageBoxEx.Show(Me, "No se seleccionó ningún documento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If


        ElseIf Rdb_Tipo_Documento_Uno.Checked Then

            If String.IsNullOrEmpty(CmbTipoDeDocumentos.SelectedValue) Then
                _Sql_Filtro_Documentos = String.Empty
                Dim _Tbl As DataTable = CmbTipoDeDocumentos.DataSource

                Dim _Fl As String = Generar_Filtro_IN(_Tbl, "", "Padre", False, False, "'")

                _Sql_Filtro_Documentos = "And Edo.TIDO IN " & _Fl

            Else
                _Sql_Filtro_Documentos = "And Edo.TIDO = '" & CmbTipoDeDocumentos.SelectedValue & "'"
            End If

            If Not String.IsNullOrEmpty(TxtNroDocumento.Text) Then

                Dim _Nudo As String = Fx_Rellena_ceros(TxtNroDocumento.Text, 10)
                Dim _Nro As String

                _Nro = Replace(_Nudo, "-", ",")

                Dim _Cadena = Split(_Nro, ",")

                If _Cadena.Length = 2 Then

                    Dim _Tido = _Cadena(0)
                    _Nudo = Fx_Rellena_ceros(_Cadena(1), 10)

                    _Sql_Filtro_Documentos = String.Empty
                    _Sql_Nro_Documento = "And Edo.TIDO = '" & _Tido & "' And Edo.NUDO = '" & _Nudo & "'"
                    _Usar_Otro_Filtros = False

                    GoTo Buscar
                Else
                    TxtNroDocumento.Text = _Nudo
                    _Sql_Nro_Documento = "And Edo.NUDO = '" & _Nudo & "'"
                End If

            End If

        End If

        If Rdb_Entidad_Una.Checked Then

            'Dim _Todas_Sucursales As Boolean

            If Not String.IsNullOrEmpty(_CodEntidad.Trim) Then

                If Chk_Todas_Sucursales.Checked Then
                    _Sql_Filtro_Entidades = "Edo.ENDO = '" & _CodEntidad & "'"
                Else
                    _Sql_Filtro_Entidades = "Edo.ENDO = '" & _CodEntidad & "' And Edo.SUENDO = '" & _SucEntidad & "'"
                End If

                If ChkBuscarEntidadFisica.Checked Then
                    _Sql_Filtro_Entidades = "(" & _Sql_Filtro_Entidades & ")" & " OR (Edo.ENDOFI = '" & _CodEntidad & "')"
                End If

                _Sql_Filtro_Entidades = "And (" & _Sql_Filtro_Entidades & ")"

            Else
                MessageBoxEx.Show(Me, "No se seleccionó ninguna entidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        End If

        If Rdb_Producto_Uno.Checked Then

            If Not IsNothing(_Row_Producto) Then

                Dim _Kopr = _Row_Producto.Item("KOPR")

                _Sql_Filtro_Producto = "And Edo.IDMAEEDO In (Select IDMAEEDO From MAEDDO Where KOPRCT = '" & _Kopr & "')"

            Else
                MessageBoxEx.Show(Me, "No se seleccionó ningun producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        End If

        If Rdb_Funcionarios_Algunos.Checked Then

            Dim _FlFun As Boolean

            _FlFun = (_Tbl_Filtro_Funcionarios Is Nothing)
            _FlFun = CBool(_Tbl_Filtro_Funcionarios.Rows.Count)

            Dim _Fl = Generar_Filtro_IN(_Tbl_Filtro_Funcionarios, "", "Codigo", False, False, "'")
            If _Fl = "()" Then _FlFun = True

            If _FlFun Then
                _Sql_Filtro_Fucnionarios = "And Edo.KOFUDO In " & _Fl
            Else
                MessageBoxEx.Show(Me, "No se seleccionó ningún funcionario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        ElseIf Rdb_Funcionarios_Uno.Checked Then
            _Sql_Filtro_Fucnionarios = "And Edo.KOFUDO = '" & CmbFuncionarios.SelectedValue & "'"
        End If

        If Rdb_Fecha_Emision_Desde_Hasta.Checked Then

            _Sql_Filtro_Fechas = "And Edo.FEEMDO BETWEEN CONVERT(DATETIME, '" & Format(DtpFechaInicio.Value, "yyyy-MM-dd") & " 00:00:00', 102) " &
                                 "AND CONVERT(DATETIME, '" & Format(DtpFechaFin.Value, "yyyy-MM-dd") & " 23:59:59', 102)"

            '_Sql_Filtro_Fechas = "And Edo.FEEMDO BETWEEN '" & Format(DtpFechaInicio.Value, "yyyyMMdd") &
            '                      "' AND '" & Format(DtpFechaFin.Value, "yyyyMMdd") & "'"
        End If

        If Rdb_Estado_Vigente.Checked Then
            _Sql_Filtro_Estado = "And Edo.ESDO = ''"
        ElseIf Rdb_Estado_Cerradas.Checked Then
            _Sql_Filtro_Estado = "And Edo.ESDO = 'C'"
        End If

        If Rdb_Sucursal_Doc_Algunas.Checked Then
            _Sql_Filtro_Sucursal_Doc = Generar_Filtro_IN(_Tbl_Filtro_Sucursal_Doc, "Chk", "Codigo", False, True, "'")
            _Sql_Filtro_Sucursal_Doc = "And Edo.SUDO In " & _Sql_Filtro_Sucursal_Doc & vbCrLf
        End If

        If Rdb_Ver_Primeros.Checked Then
            _Sql_Orden = "ORDER BY Edo.FEEMDO,Edo.TIDO OPTION ( FAST 20 ) "
        ElseIf Rdb_Ver_Ultimos.Checked Then
            _Sql_Orden = "ORDER BY Edo.FEEMDO DESC,Edo.TIDO DESC OPTION ( FAST 20 ) "
        End If

        Dim _Filtro_Idmaeedo_DRA As String

        If Filtrar_Doc_No_Asociados_Recargo Then

            Consulta_sql = "Select Distinct Ddo.IDMAEEDO 
                        From MAEDDO Ddo
                        Left Join TABTIDO Tdo On Ddo.TIDO = Tdo.TIDO
                        Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO
                        Where 
	                        Ddo.EMPRESA = '" & ModEmpresa & "' 
                        And Edo.TIDO = '" & CmbTipoDeDocumentos.SelectedValue & "'
                        And LILG In ('SI','CR') 
                        And PRCT = 0
                        And (Ddo.CAPRCO1 * Tdo.FICO + Ddo.CAPRAD1 * Tdo.FIAD ) <> 0
                        And Not Exists (Select * From MAEDCR Where MAEDCR.IDDDODCR = Ddo.IDMAEDDO And MAEDCR.RECARCALCU = '" & Codigo_Recargo & "')
                        And Edo.FEEMDO BETWEEN '" & Format(DtpFechaInicio.Value, "yyyyMMdd") & "' And '" & Format(DtpFechaFin.Value, "yyyyMMdd") & "'"

            Dim _Tbl_Filtro_Idmaeedo As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            If _Tbl_Filtro_Idmaeedo.Rows.Count Then
                _Usar_Otro_Filtros = True
                _Filtro_Idmaeedo_DRA = Generar_Filtro_IN(_Tbl_Filtro_Idmaeedo, "", "IDMAEEDO", False, False, "")
                _Sql_Filtro_Otro_Filtro = "And IDMAEEDO In " & _Filtro_Idmaeedo_DRA
            End If

        End If

        If _Mostrar_Vales_Transitorios Then
            _Sql_Filtro_Vales_Transitorios = " And NUDONODEFI In (0,1)"
        Else
            _Sql_Filtro_Vales_Transitorios = " And NUDONODEFI In (0)"
        End If

        If Not String.IsNullOrEmpty(Txt_Ocdo.Text.Trim) Then
            _Sql_Occ = "And IDMAEEDO In (Select IDMAEEDO From MAEEDOOB Where OCDO Like '" & Txt_Ocdo.Text.Trim & "')" & vbCrLf
        End If

        If Not String.IsNullOrEmpty(Txt_Placapat.Text) Then
            _Sql_Placa = "And IDMAEEDO In (Select IDMAEEDO From MAEEDOOB Where PLACAPAT Like '" & Txt_Placapat.Text.Trim & "')" & vbCrLf
        End If

        If Not String.IsNullOrEmpty(Txt_CodRetirador.Text) Then
            _Sql_RetMerca = "And IDMAEEDO In (Select IDMAEEDO From MAEEDOOB Where DIENDESP Like '" & Txt_CodRetirador.Tag.Trim & "')" & vbCrLf
        End If

        Dim _Filtro_Observaciones = String.Empty

        _Filtro_Observaciones = _Sql_Occ & _Sql_Placa & _Sql_RetMerca

Buscar:


        '--Left Join MAEEN Mae2 On Edo.ENDOFI = Mae2.KOEN 
        '#Inner_Join_MAEEN_ENDOFI_SUENDOFI#

        Dim _Left_Join_MAEEN_ENDOFI_SUENDOFI As String
        Dim _Campo_SUENDOFI As String

        If _Sql.Fx_Exite_Campo("MAEEDO", "SUENDOFI") Then
            _Left_Join_MAEEN_ENDOFI_SUENDOFI = "Left Join MAEEN Mae2 On Edo.ENDOFI = Mae2.KOEN And Edo.SUENDOFI = Mae2.SUEN"
            _Campo_SUENDOFI = "Isnull(SUENDOFI,'') As SUENDOFI,"
        Else
            _Left_Join_MAEEN_ENDOFI_SUENDOFI = "Left Join MAEEN Mae2 On Edo.ENDOFI = Mae2.KOEN "
            _Campo_SUENDOFI = String.Empty
        End If


        Consulta_sql = My.Resources._24_Recursos.SQLQuery_Buscar_Docmuento
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#CantidadDoc#", CmbCantFilas.Text)
        Consulta_sql = Replace(Consulta_sql, "#TipoDocumento#", _Sql_Filtro_Documentos)
        Consulta_sql = Replace(Consulta_sql, "#NroDocumento#", _Sql_Nro_Documento)
        Consulta_sql = Replace(Consulta_sql, "#Entidad#", _Sql_Filtro_Entidades)
        Consulta_sql = Replace(Consulta_sql, "#Fecha#", _Sql_Filtro_Fechas)
        Consulta_sql = Replace(Consulta_sql, "#Estado#", _Sql_Filtro_Estado)
        Consulta_sql = Replace(Consulta_sql, "#Funcionario#", _Sql_Filtro_Fucnionarios)
        Consulta_sql = Replace(Consulta_sql, "#Producto#", _Sql_Filtro_Producto)
        Consulta_sql = Replace(Consulta_sql, "#SucursalDocumento#", _Sql_Filtro_Sucursal_Doc)
        Consulta_sql = Replace(Consulta_sql, "#Orden#", _Sql_Orden)
        Consulta_sql = Replace(Consulta_sql, "#Observaciones#", _Filtro_Observaciones)


        Consulta_sql = Replace(Consulta_sql, "#Left_Join_MAEEN_ENDOFI_SUENDOFI#", _Left_Join_MAEEN_ENDOFI_SUENDOFI)
        Consulta_sql = Replace(Consulta_sql, "#Campo_SUENDOFI#", _Campo_SUENDOFI)

        If _Usar_Otro_Filtros Then
            Consulta_sql = Replace(Consulta_sql, "#Otro_Filtro#", _Sql_Filtro_Otro_Filtro)
        Else
            Consulta_sql = Replace(Consulta_sql, "#Otro_Filtro#", "")
        End If

        Consulta_sql = Replace(Consulta_sql, "#ValesTransitorios#", _Sql_Filtro_Vales_Transitorios)
        Consulta_sql = Replace(Consulta_sql, "Zw_Vales_Enc", "Zw_Vales_Enc")

        Me.Cursor = Cursors.WaitCursor

        Dim _Tbl_Paso As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Me.Cursor = Cursors.Default

        If CBool(_Tbl_Paso.Rows.Count) Then

            If _Abrir_Seleccionado Then

                If _Tbl_Paso.Rows.Count = 1 And Not _Abrir_Cerrar_Documentos_Compromiso Then

                    Dim _Idmaeedo As Integer = _Tbl_Paso.Rows(0).Item("IDMAEEDO")
                    Dim _TipoDoc As String = Trim(_Tbl_Paso.Rows(0).Item("TipoDoc"))
                    Dim _Tido As String = _Tbl_Paso.Rows(0).Item("TIDO")
                    Dim _Nudo As String = _Tbl_Paso.Rows(0).Item("NUDO")

                    Dim _Mensaje = MessageBoxEx.Show(Me, "Se encontro solo un registro, eliga su opción" & Environment.NewLine & Environment.NewLine &
                                                     "(Yes) Ver el documento inmediatamente" & Environment.NewLine &
                                                     "(No)  Ver listado " & Environment.NewLine &
                                                     "(Cancel) Volver a la pantalla de busqueda" & Environment.NewLine & Environment.NewLine &
                                         _TipoDoc & ": " & _Tido & "-" & _Nudo, "1 documento encontrado",
                                         MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                    If _Mensaje = Windows.Forms.DialogResult.Yes Then

                        Dim _Idmaeedo_ = _Tbl_Paso.Rows(0).Item("IDMAEEDO")
                        Dim _Fm As New Frm_Ver_Documento(_Idmaeedo_, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)

                        If Rdb_Producto_Uno.Checked And Not IsNothing(_Row_Producto) Then _Fm.Codigo_Marcar = _Row_Producto.Item("KOPR")

                        _Fm.ShowDialog(Me)
                        _Fm.Dispose()

                        Return

                    ElseIf _Mensaje = DialogResult.Cancel Then

                        Return

                    End If

                End If

            End If

            Consulta_sql = Replace(Consulta_sql, "Top " & CmbCantFilas.Text, "Top #CantidadDoc#")

            Dim _Ver As String

            If Rdb_Ver_Primeros.Checked Then
                _Ver = "Ver primeros"
            ElseIf Rdb_Ver_Ultimos.Checked Then
                _Ver = "Ver últimos"
            End If

            Dim Fm As New Frm_BuscarDocumento_Mt
            Fm.Ocultar_Envio_Correos_Masivamente = Ocultar_Envio_Correos_Masivamente
            Fm.Lbl_Ver.Text = _Ver
            Fm.BtnAceptar.Visible = Seleccion_Multiple
            Fm.Pro_Sql_Query = Consulta_sql
            Fm.CmbCantFilas.Text = CmbCantFilas.Text
            Fm.Pro_Pago_a_Documento = _Pago_a_Documento
            Fm.Pro_Abrir_Seleccionado = _Abrir_Seleccionado
            Fm.Seleccion_Multiple = Seleccion_Multiple
            Fm.Abrir_Cerrar_Documentos_Compromiso = _Abrir_Cerrar_Documentos_Compromiso
            Fm.Abrir_Documentos = Rdb_Estado_Cerradas.Checked
            Fm.Cerrar_Documentos = Rdb_Estado_Vigente.Checked

            Fm.ShowDialog(Me)

            Dim _IdMaeedo_Doc = Fm.Pro_IdMaeedo_Doc

            _Tbl_DocSeleccionados = Fm.Tbl_DocSeleccionados

            Fm.Dispose()

            If Seleccion_Multiple Then

                If Not IsNothing(_Tbl_DocSeleccionados) Then
                    Me.Close()
                End If

            Else

                If CBool(Val(Fm.Pro_IdMaeedo_Doc)) And Not _Abrir_Seleccionado Then

                    Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _IdMaeedo_Doc
                    _Row_Documento_Seleccionado = _Sql.Fx_Get_DataRow(Consulta_sql)

                    Me.Close()

                End If

            End If

        Else

            Beep()
            ToastNotification.Show(Me, "NO EXISTEN DATOS QUE MOSTRAR", My.Resources.cross, 3 * 1000,
                                   eToastGlowColor.Red, eToastPosition.MiddleCenter)

        End If

    End Sub

    Private Sub Btn_Entidad_Una_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Entidad_Una.Click

        Dim Fm As New Frm_BuscarEntidad_Mt(False)
        Fm.BtnCrearUser.Visible = False
        Fm.BtnEditarUser.Visible = False
        Fm.BtnEliminarUser.Visible = False

        Fm.ShowDialog(Me)

        If Not (Fm.Pro_RowEntidad Is Nothing) Then
            Pro_Row_Entidad = Fm.Pro_RowEntidad
        End If

    End Sub

    Private Sub TxtNroDocumento_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtNroDocumento.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Buscar_documentos()
        End If
    End Sub

    Private Sub Btn_Producto_Uno_Click(sender As Object, e As EventArgs) Handles Btn_Producto_Uno.Click

        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt()
        Fm.Pro_Actualizar_Precios = True
        Fm.Pro_Mostrar_Info = True
        Fm.BtnBuscarAlternativos.Visible = True
        Fm.Pro_Mostrar_Imagenes = True
        Fm.BtnCrearProductos.Visible = False
        Fm.Pro_Mostrar_Editar = True
        Fm.Pro_Mostrar_Eliminar = False
        Fm.BtnExportaExcel.Visible = False
        Fm.Pro_Tipo_Lista = "P"
        Fm.Pro_Maestro_Productos = False
        Fm.Pro_Lista_Busqueda = ModListaPrecioVenta
        Fm.Pro_Sucursal_Busqueda = ModSucursal
        Fm.Pro_Bodega_Busqueda = ModBodega
        Fm.ShowDialog(Me)

        If Fm.Pro_Seleccionado Then
            Pro_Row_Producto = Fm.Pro_RowProducto
        End If

        Fm.Dispose()

    End Sub

    Private Sub Rdb_Sucursal_Doc_Algunas_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Sucursal_Doc_Algunas.CheckedChanged

        If Rdb_Sucursal_Doc_Algunas.Checked Then

            Dim _Filtrar As New Clas_Filtros_Random(Me)

            If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Sucursal_Doc,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Sucursales, "",
                               False, False) Then

                _Tbl_Filtro_Sucursal_Doc = _Filtrar.Pro_Tbl_Filtro
                If _Filtrar.Pro_Filtro_Todas Then
                    Rdb_Sucursal_Doc_Todas.Checked = True
                    _Tbl_Filtro_Sucursal_Doc = Nothing
                End If

            End If

        End If

    End Sub

    Private Sub Chk_Mostrar_Vales_Transitorios_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Mostrar_Vales_Transitorios.CheckedChanged
        _Mostrar_Vales_Transitorios = Chk_Mostrar_Vales_Transitorios.Checked
    End Sub

    Private Sub Txt_Placapat_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Placapat.ButtonCustomClick

        Dim _Koenresp As String = _Sql.Fx_Trae_Dato("TABRETI", "KOENRESP", "KORETI = '" & Txt_CodRetirador.Tag & "'")

        Dim _Sql_Filtro_Condicion_Extra As String

        If Not String.IsNullOrEmpty(_Koenresp.Trim) Then

            _Sql_Filtro_Condicion_Extra = "And KOENRESP = '" & _Koenresp & "'"

        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "TABPLACA"
        _Filtrar.Campo = "PLACA"
        _Filtrar.Descripcion = "DESCRIP"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "PLACAS PATENTE"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _Sql_Filtro_Condicion_Extra,
                               Nothing, False, True) Then

            Dim _Tbl_Placa As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Placa.Rows(0)

            Dim _Codigo = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Txt_Placapat.Tag = _Codigo
            Txt_Placapat.Text = _Codigo

        End If

    End Sub

    Private Sub Txt_Ocdo_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Ocdo.ButtonCustomClick
        Txt_Ocdo.Text = String.Empty
    End Sub

    Private Sub Txt_CodRetirador_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_CodRetirador.ButtonCustomClick
        Try

            Dim _Filtrar As New Clas_Filtros_Random(Me)

            _Filtrar.Tabla = "TABRETI"
            _Filtrar.Campo = "KORETI"
            _Filtrar.Descripcion = "NORETI"

            _Filtrar.Pro_Nombre_Encabezado_Informe = "RETIRADORES DE MERCADERIA"

            If _Filtrar.Fx_Filtrar(Nothing,
                                   Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "",
                                   Nothing, False, True) Then

                Dim _Tbl_Retirador As DataTable = _Filtrar.Pro_Tbl_Filtro

                Dim _Row As DataRow = _Tbl_Retirador.Rows(0)

                Dim _Codigo = _Row.Item("Codigo").ToString.Trim
                Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

                Txt_CodRetirador.Tag = _Codigo
                Txt_CodRetirador.Text = _Codigo & " - " & _Descripcion

            End If
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Txt_CodRetirador_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_CodRetirador.ButtonCustom2Click
        Txt_CodRetirador.Text = String.Empty
    End Sub

    Private Sub Txt_Placapat_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Placapat.ButtonCustom2Click
        Txt_Placapat.Text = String.Empty
    End Sub

    Private Sub Frm_BusquedaDocumento_Filtro_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

End Class
