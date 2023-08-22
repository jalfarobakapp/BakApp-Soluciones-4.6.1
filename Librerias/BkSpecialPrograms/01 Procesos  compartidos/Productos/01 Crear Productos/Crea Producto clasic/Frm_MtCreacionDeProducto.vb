Imports BkSpecialPrograms.My.Resources
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

Public Class Frm_MtCreacionDeProducto

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim SqlEmpresa As String
    Dim SqlListas As String
    Dim SqlBodegas As String
    Dim SqlImpuestos As String

    Dim SuperFamilia, Familia, SubFamilia As String
    Dim ListaCostoPro, Marca, Rubro, ClasifLibre, JefePro, ZonaPro As String

    Dim _Preguntar_Crear_Otro As Boolean
    Dim _MaxCarac_Ref_Producto As Integer

    Dim _Pedir_Alternativo As Boolean

    Dim _Crear_Alternativo As Boolean
    Dim _CodAlternativo, _CodProveedor, _SucProveedor As String

    Dim _Grabar As Boolean
    Dim _RowProducto As DataRow

    Dim _Cl_Producto As Cl_Producto

    Dim Union = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "UNION" & vbCrLf

    Dim _Cl_CompUdMedidas As New Bk_Comporamiento_UdMedidas.Cl_CompUdMedidas
    Dim _NNmarca As New Bk_Comporamiento_UdMedidas.Nmarca

    Public Property GrabarEnOtraBase As Boolean


    Public ReadOnly Property Pro_Grabar() As Boolean
        Get
            Return _Grabar
        End Get
    End Property

    Public Property Pro_RowProducto() As DataRow
        Get
            Return _RowProducto
        End Get
        Set(value As DataRow)
            _RowProducto = value
        End Set
    End Property

#Region "PROCEDIMIENTO DE CARGA DE DATOS"

    Sub Sb_Cargar_Combos()

        caract_combo(Cmb_Mrpr)
        Consulta_sql = Union & "SELECT KOMR AS Padre,NOKOMR AS Hijo FROM TABMR ORDER BY Hijo" ' WHERE SEMILLA = " & Actividad
        Cmb_Mrpr.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Marca = ""
        Cmb_Mrpr.SelectedValue = Marca

        caract_combo(Cmb_Rupr)
        Consulta_sql = Union & "SELECT KORU AS Padre,NOKORU AS Hijo FROM TABRU ORDER BY Hijo" ' WHERE SEMILLA = " & Actividad
        Cmb_Rupr.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Rubro = ""
        Cmb_Rupr.SelectedValue = Rubro

        caract_combo(Cmb_Clalibpr)
        Consulta_sql = Union & "SELECT KOCARAC AS Padre,LTRIM(RTRIM(KOCARAC))+'-'+LTRIM(RTRIM(NOKOCARAC)) AS Hijo FROM TABCARAC WHERE KOTABLA = 'CLALIBPR' ORDER BY Hijo"
        Cmb_Clalibpr.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        ClasifLibre = ""
        Cmb_Clalibpr.SelectedValue = ClasifLibre

        caract_combo(CmbSuperFamilia)
        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT KOFM AS Padre,NOKOFM AS Hijo FROM TABFM ORDER BY Hijo" ' WHERE SEMILLA = " & Actividad
        CmbSuperFamilia.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        SuperFamilia = ""
        CmbSuperFamilia.SelectedValue = SuperFamilia
        Familia = ""
        SubFamilia = ""

        'caract_combo(Cmb_Ud01pr)
        'Consulta_sql = "SELECT CodigoTabla AS Padre,CodigoTabla AS Hijo" & vbCrLf &
        '               "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones WHERE Tabla = 'RTU' ORDER BY Orden"
        'Cmb_Ud01pr.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        'caract_combo(Cmb_Ud02pr)
        'Consulta_sql = "SELECT CodigoTabla AS Padre,CodigoTabla AS Hijo" & vbCrLf &
        '               "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones WHERE Tabla = 'RTU' ORDER BY Orden"
        'Cmb_Ud02pr.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Arr_Bloquea_Pr(,) As String = {{"", ""},
                                            {"C", "Bloqueado para Compras"},
                                            {"T", "Bloqueado para Compras y Ventas"},
                                            {"V", "Bloqueado para ventas"},
                                            {"X", "Bloqueado en Compras, Ventas y Producción"}}
        Sb_Llenar_Combos(_Arr_Bloquea_Pr, Cmb_Bloqueapr)
        Cmb_Bloqueapr.SelectedValue = ""


        Dim _Arr_Tipo_Productos(,) As String = {{"FPN", "Articulo estándar"},
                                                {"FPS", "Articulo seriado"},
                                                {"FIN", "Insumo productivo"},
                                                {"FUN", "Herramienta estándar"},
                                                {"FUS", "Herramienta seriada"},
                                                {"FLN", "Artículo multiproposito"},
                                                {"SSN", "Servicios y similares"},
                                                {"GEN", "Génerico o agrupador de artículos"}}
        Sb_Llenar_Combos(_Arr_Tipo_Productos, Cmb_Tipr)
        Cmb_Tipr.SelectedValue = "FPN"

        caract_combo(Cmb_Codlista)
        Consulta_sql = Union & "SELECT 'TABPP'+KOLT AS Padre,KOLT+'-'+NOKOLT AS Hijo FROM TABPP"
        Cmb_Codlista.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        ListaCostoPro = "TABPP" & ModListaPrecioCosto
        Cmb_Codlista.SelectedValue = ListaCostoPro


        caract_combo(Cmb_Kofupr)
        Consulta_sql = Union & "SELECT KOFU AS Padre,NOKOFU AS Hijo FROM TABFU"
        Cmb_Kofupr.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        JefePro = ""
        Cmb_Kofupr.SelectedValue = JefePro

        'caract_combo(Cmb_Zonapr)
        'Consulta_sql = Union & "SELECT KOZO AS Padre,NOKOZO AS Hijo FROM TABZO"
        'Cmb_Zonapr.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        'ZonaPro = ""
        'Cmb_Zonapr.SelectedValue = ZonaPro

        caract_combo(Cmb_Zonapr)
        Consulta_sql = Union & "SELECT KOCARAC AS Padre,LTRIM(RTRIM(KOCARAC))+'-'+LTRIM(RTRIM(NOKOCARAC)) AS Hijo FROM TABCARAC WHERE KOTABLA = 'ZONAPRODUC' ORDER BY Hijo"
        Cmb_Zonapr.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        ZonaPro = ""
        Cmb_Zonapr.SelectedValue = ZonaPro

        Dim _Arr_Rgpr(,) As String = {{"N", "Nacional"},
                                      {"I", "Importados"}}
        Sb_Llenar_Combos(_Arr_Rgpr, Cmb_Rgpr)
        Cmb_Rgpr.SelectedValue = "N"

        Dim _Arr_Funclote_Pr(,) As String = {{"", "Manual muestra Ult. Nro. Lote"},
                                            {"A", "A Alfanumérico, manual y libre"},
                                            {"B", "B Numérico correlativo por producto"},
                                            {"C", "C Numérico correlativo general"},
                                            {"D", "D Año mas correlativo general"},
                                            {"E", "E Año, Mes mas correlativo general"},
                                            {"F", "F Numérico mayor y Unico por Dcto."}}
        Sb_Llenar_Combos(_Arr_Funclote_Pr, Cmb_Funclote)
        Cmb_Funclote.SelectedValue = ""

        Dim _Arr_Comportamiento(,) As String = {
                                    {1, "1. Solicitar unidad en que se hará la transacción"},
                                    {2, "2. Comprar en 1era. Udad. Vender en 1era. Udad."},
                                    {3, "3. Comprar en 2da. Udad. Vender en 1era. Udad."},
                                    {4, "4. Comprar en 1era. Udad. Vender en 2da. Udad."},
                                    {5, "5. Comprar en 2da. Udad. Vender en 2da. Udad."},
                                    {6, "6. Solicitar Udad. si es compra, Vender en 1era. Udad."},
                                    {7, "7. Solicitar Udad. si es compra, Vender en 2da. Udad."},
                                    {8, "8. Comprar en 1era. Udad. Solicitar Udad. si es venta"},
                                    {9, "9. Comprar en 2da. Udad. Solicitar Udad. si es venta"},
                                    {10, "10. Utilizar la unidad indivisible (solo para RTU Constante)"},
                                    {11, "11. Vender en 1era. Udad. Sin dividir 2da. Udad"}}
        Sb_Llenar_Combos(_Arr_Comportamiento, Cmb_Nmarca_Comportamiento)
        Cmb_Nmarca_Comportamiento.SelectedValue = 1

        Dim _Arr_Tratamiento(,) As String = {
                            {1, "1. Caso normal, respetar RTU definida"},
                            {2, "2. Solicitar Ancho, Largo y Alto para obtener cantidad 1era. Udad"},
                            {3, "3. Solicitar Ancho y Largo para obtener cantidad 1era. Udad. (MT2)"},
                            {4, "4. Solicitar Ancho y Largo para obtener cantidad 1era. Udad. (CM2)"},
                            {5, "5. Solicitar cantidad solo en Udad. seleccionada y calcular por RTU la otra Udad."},
                            {6, "6. Calcular RTU en forma invertida"},
                            {7, "7. Solicitar cantidad para ambas unidades del producto"},
                            {8, "8. Solicitar RTU del producto"},
                            {9, "9. RTU variable"},
                            {10, "10. RTU constante"}}
        Sb_Llenar_Combos(_Arr_Tratamiento, Cmb_Nmarca_Tratamiento)
        Cmb_Nmarca_Tratamiento.SelectedValue = 1

    End Sub

#End Region

#Region "FUNCIONES ESPECIALES"

    Sub Sb_Actualizar_Grilla(_Grilla As DataGridView)

        With _Grilla

            .Columns("Select").HeaderText = "Sel."
            .Columns("Select").Width = 50
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Width = 100
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Width = 235

        End With

    End Sub

    Private Function Chks(Chk As CheckBox) As Integer
        Dim Nro As Integer = 0
        If Chk.Checked = True Then Nro = 1
        Return Nro
    End Function

    Private Function ChequearTodo(Grilla As DataGridView,
                                  Chk As CheckBoxX,
                                  NombreTabla As String)

        Dim Chequeo As Boolean
        Chequeo = Chk.Checked

        For i As Integer = 0 To Grilla.Rows.Count - 1
            Grilla.Rows(i).Cells(0).Value = Chequeo
        Next

    End Function

    Private Function CodigoSugerido(TIPR As String,
                                    _Iniciales As String,
                                    _MaxCarac_Codigo As Integer) As String

        Dim _CodigoS As String
        Dim _Lop As Boolean = True
        Dim _Reg As Long
        Dim _Codigo_ As String

        _MaxCarac_Codigo = _MaxCarac_Codigo - Len(_Iniciales)

        _CodigoS = _Sql.Fx_Cuenta_Registros("MAEPR", "TIPR = '" & TIPR & "'") '_Sql.Fx_Trae_Dato(, "KOPR", "MAEPR", "TIPR = '" & TIPR & "' Order by desc")
        _CodigoS = _Sql.Fx_Cuenta_Registros("MAEPR", "KOPR LIKE '" & _Iniciales & "%'") + 1

        Do While _Lop

            _Codigo_ = _Iniciales & numero_(_CodigoS, _MaxCarac_Codigo) ' Ferrenueva

            _Reg = _Sql.Fx_Cuenta_Registros("MAEPR", "KOPR = '" & _Codigo_ & "'")
            _Reg += _Sql.Fx_Cuenta_Registros("MAEFICHA", "KOPR = '" & _Codigo_ & "'")
            _Reg += _Sql.Fx_Cuenta_Registros("TABCODAL", "KOPRAL = '" & _Codigo_ & "'")

            If _Reg = 0 Then
                _Lop = False
            Else
                _CodigoS = _CodigoS + 1
            End If
        Loop

        Return _Codigo_

    End Function

#End Region

    Public Sub New(Accion As Cl_Producto.Enum_Accion,
                   Codigo As String,
                   Preguntar_Crear_Otro As Boolean,
                   Crear_Alternativo As Boolean)


        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Cl_Producto = New Cl_Producto()
        _Cl_Producto.Sb_Cargar_Producto(Codigo)
        _Cl_Producto.Pro_Accion = Accion

        _Preguntar_Crear_Otro = Preguntar_Crear_Otro

        Sb_Cargar_Combos()

        AddHandler Txt_Pesoubic.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros
        AddHandler Txt_Ltsubic.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros
        AddHandler Txt_Tolelote.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros
        AddHandler Txt_Vidamedia.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros
        AddHandler Txt_Rlud.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros

        AddHandler Txt_Pesoubic.Validated, AddressOf Sb_Txt_Numerico_Validated
        AddHandler Txt_Ltsubic.Validated, AddressOf Sb_Txt_Numerico_Validated
        AddHandler Txt_Tolelote.Validated, AddressOf Sb_Txt_Numerico_Validated
        AddHandler Txt_Vidamedia.Validated, AddressOf Sb_Txt_Numerico_Validated
        AddHandler Txt_Rlud.Validated, AddressOf Sb_Txt_Numerico_Validated

        AddHandler Txt_Kopr.TextChanged, AddressOf Txtcodigoprincipal_TextChanged
        AddHandler Txt_Nokopr.TextChanged, AddressOf TxtDescripcionLarga_TextChanged

        AddHandler Txt_Kopr.Leave, AddressOf Txtcodigoprincipal_Leave
        AddHandler Txt_Koprte.Leave, AddressOf Txtcodigotecnico_Leave

        Sb_Formato_Generico_Grilla(GrillaBodegas, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(GrillaEmpresa, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(GrillaImpuestos, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(GrillaListaDePrecios, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then

            SuperTabControl1.TabStyle = eSuperTabStyle.Office2007

            Cmb_Mrpr.FocusHighlightEnabled = False
            Cmb_Rupr.FocusHighlightEnabled = False
            Cmb_Clalibpr.FocusHighlightEnabled = False
            Cmb_Kofupr.FocusHighlightEnabled = False
            Cmb_Zonapr.FocusHighlightEnabled = False
            CmbSuperFamilia.FocusHighlightEnabled = False
            CmbFamilia.FocusHighlightEnabled = False
            CmbSubFamilia.FocusHighlightEnabled = False

        End If

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_MtCreacionDeProducto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        AddHandler Btn_Dim_01.Click, AddressOf Btn_Dim_Click
        AddHandler Btn_Dim_02.Click, AddressOf Btn_Dim_Click
        AddHandler Btn_Dim_03.Click, AddressOf Btn_Dim_Click
        AddHandler Btn_Dim_04.Click, AddressOf Btn_Dim_Click
        AddHandler Btn_Dim_05.Click, AddressOf Btn_Dim_Click
        AddHandler Btn_Dim_06.Click, AddressOf Btn_Dim_Click
        AddHandler Btn_Dim_07.Click, AddressOf Btn_Dim_Click
        AddHandler Btn_Dim_08.Click, AddressOf Btn_Dim_Click
        AddHandler Btn_Dim_09.Click, AddressOf Btn_Dim_Click
        AddHandler Btn_Dim_10.Click, AddressOf Btn_Dim_Click
        AddHandler Btn_Dim_11.Click, AddressOf Btn_Dim_Click
        AddHandler Btn_Dim_12.Click, AddressOf Btn_Dim_Click
        AddHandler Btn_Dim_13.Click, AddressOf Btn_Dim_Click

        Sb_Limpiar()

        AddHandler Chk_Tratalote.CheckedChanged, AddressOf Chk_Tratalote_CheckedChanged
        AddHandler Chk_Lotecaja.CheckedChanged, AddressOf Chk_Lotecaja_CheckedChanged

    End Sub

    Sub Sb_Limpiar()

        Txt_Kopr.Text = String.Empty
        Txt_Nokoprra.Text = String.Empty
        Txt_Nokopr.Text = String.Empty
        Txt_Koprte.Text = String.Empty
        Txt_Koge.Text = String.Empty

        Txt_Rlud.Tag = 1
        Txt_Rlud.Text = 1

        Input_Poivpr.Value = _Global_Row_Configp.Item("IVAPAIS")

        ChkSelTodo.Checked = False

        Cmb_Mrpr.SelectedValue = String.Empty
        Cmb_Clalibpr.SelectedValue = String.Empty
        Cmb_Rupr.SelectedValue = String.Empty
        CmbSuperFamilia.SelectedValue = String.Empty
        CmbFamilia.SelectedValue = String.Empty
        CmbSubFamilia.SelectedValue = String.Empty
        Cmb_Kofupr.SelectedValue = String.Empty
        Cmb_Zonapr.SelectedValue = String.Empty

        Txt_Pesoubic.Text = 0
        Txt_Tolelote.Text = 0
        Txt_Ltsubic.Text = 0
        Txt_Vidamedia.Text = 0
        Txt_Alto.Text = 0
        Txt_Largo.Text = 0
        Txt_Ancho.Text = 0

        Txt_Koprra.Text = numero_(Val(_Sql.Fx_Trae_Dato("MAEPR WITH ( NOLOCK )", "MAX(KOPRRA)+1")), 6)

        SuperTabControl1.SelectedTabIndex = 0

        Sb_Cargar_Producto_Traer_Datos_Al_Formulario()

        If _Cl_Producto.Pro_Accion = Cl_Producto.Enum_Accion.Nuevo Then

            Txt_Kopr.Enabled = String.IsNullOrEmpty(Trim(Txt_Kopr.Text)) 'True
            ChkSelTodo.Checked = True
            Cmb_Codlista.SelectedValue = ListaCostoPro

            Me.ActiveControl = Txt_Kopr

        ElseIf _Cl_Producto.Pro_Accion = Cl_Producto.Enum_Accion.Editar Then

            Btn_Mant_Precios.Visible = True
            Btn_Asociaciones.Visible = True
            BtnCodAlternativosProducto.Visible = True
            Btn_Imagenes.Visible = True
            Txt_Kopr.Enabled = False

            Me.ActiveControl = Txt_Nokopr

        End If

        Btn_Dimensiones.Visible = (_Cl_Producto.Pro_Accion = Cl_Producto.Enum_Accion.Editar)

        Dim _Existe As Boolean

        _Existe = _Sql.Fx_Exite_Campo("MAEPR", "NOKOPRAMP")

        Lbl_Nokoprmap.Visible = _Existe
        Txt_Nokopramp.Visible = Lbl_Nokoprmap.Visible

        '_Existe = _Sql.Fx_Exite_Campo("MAEPR", "CAMBIOSUJ")

        'Chk_Cambiosuj.Visible = True

        'Chk_Cambiosuj.Visible = _Existe
        'LabelX28.Visible = Chk_Cambiosuj.Visible

        '_Existe = _Sql.Fx_Exite_Campo("MAEPROBS", "LARGO")

        'Lbl_Largo.Visible = _Existe
        'Txt_Largo.Visible = Lbl_Largo.Visible

        '_Existe = _Sql.Fx_Exite_Campo("MAEPROBS", "ALTO")

        'Lbl_Alto.Visible = _Existe
        'Txt_Alto.Visible = Lbl_Alto.Visible

        '_Existe = _Sql.Fx_Exite_Campo("MAEPROBS", "ANCHO")

        'Lbl_Ancho.Visible = _Existe
        'Txt_Ancho.Visible = Lbl_Ancho.Visible

        Cmb_Nmarca_Comportamiento.Enabled = (Txt_Ud01pr.Text <> Txt_Ud02pr.Text)
        Cmb_Nmarca_Tratamiento.Enabled = (Txt_Ud01pr.Text <> Txt_Ud02pr.Text)

    End Sub

    Private Sub BtnxGrabar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Grabar.Click
        Sb_Grabar1()
    End Sub

    Private Sub Sb_Grabar1()

        If _Cl_Producto.Pro_Accion = Cl_Producto.Enum_Accion.Editar Then
            If Not Fx_Tiene_Permiso(Me, "Prod014") Then
                Return
            End If
        End If

        If String.IsNullOrEmpty(Txt_Kopr.Text.Trim) Then
            MessageBoxEx.Show(Me, "Debe ingresar código principal", "Código principal", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Kopr.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Koprte.Text.Trim) Then
            MessageBoxEx.Show(Me, "Debe ingresar código técnico", "código técnico", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Kopr.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Ud01pr.Text.Trim) Or String.IsNullOrEmpty(Trim(Txt_Ud02pr.Text)) Then
            MessageBoxEx.Show(Me, "Falta la unidad de mediad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If _Cl_Producto.Pro_Accion = Cl_Producto.Enum_Accion.Nuevo Then
            If Not Fx_ValidarExistenciaDeCodigoAlternativo(Txt_Kopr.Text.Trim) Then
                Return
            End If
        End If

        If Len(Trim(Txt_Nokopr.Text)) > 50 Then
            MessageBoxEx.Show(Me, "Largo máximo de la descripción 50 caracteres",
                                   "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Txt_Ud01pr.Text <> Txt_Ud02pr.Text AndAlso Val(Txt_Rlud.Text) = 1 Then
            MessageBoxEx.Show(Me, "No puede crear un producto con distinta unidad de medida y RTU = 1",
                                   "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Txt_Ud01pr.Text = Txt_Ud02pr.Text AndAlso Val(Txt_Rlud.Text) <> 1 Then
            MessageBoxEx.Show(Me, "No puede crear un producto con distinta unidad de medida y RTU = 1",
                                   "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If


        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("MAEPR", "KOPR <> '" & Trim(Txt_Kopr.Text) &
                                               "' AND NOKOPR = '" & Trim(Txt_Nokopr.Text) & "'")
        If _Reg > 0 Then

            If MessageBoxEx.Show(Me, Txt_Nokopr.Text & vbCrLf & vbCrLf & "Esta descripción de producto ya existe" & vbCrLf &
                                  "¿Desea continuar con la grabación?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) <> Windows.Forms.DialogResult.Yes Then
                Txt_Nokopr.Focus()
                Return
            End If

        End If


        If String.IsNullOrEmpty(Trim(Cmb_Codlista.SelectedValue)) Then
            If Not Fx_Tiene_Permiso(Me, "Prod027") Then Return
        End If

        If String.IsNullOrEmpty(Trim(Cmb_Kofupr.SelectedValue)) Then
            If Not Fx_Tiene_Permiso(Me, "Prod024") Then Return
        End If

        If String.IsNullOrEmpty(Trim(Cmb_Zonapr.SelectedValue)) Then
            If Not Fx_Tiene_Permiso(Me, "Prod025") Then Return
        End If

        If String.IsNullOrEmpty(Trim(Cmb_Mrpr.SelectedValue)) Then
            If Not Fx_Tiene_Permiso(Me, "Prod026") Then Return
        End If

        If String.IsNullOrEmpty(Trim(Cmb_Rupr.SelectedValue)) Then
            If Not Fx_Tiene_Permiso(Me, "Prod028") Then Return
        End If

        If String.IsNullOrEmpty(Trim(Cmb_Clalibpr.SelectedValue)) Then
            If Not Fx_Tiene_Permiso(Me, "Prod029") Then Return
        End If

        If String.IsNullOrEmpty(Trim(CmbSuperFamilia.SelectedValue)) Then
            If Not Fx_Tiene_Permiso(Me, "Prod030") Then Return
        End If

        If String.IsNullOrEmpty(Trim(CmbFamilia.SelectedValue)) Then
            If Not Fx_Tiene_Permiso(Me, "Prod031") Then Return
        End If

        If String.IsNullOrEmpty(Trim(CmbSubFamilia.SelectedValue)) Then
            If Not Fx_Tiene_Permiso(Me, "Prod033") Then Return
        End If

        If _Global_Row_Configuracion_General.Item("Pr_Creacion_Exigir_1raDimension") AndAlso String.IsNullOrEmpty(Txt_Nodim1.Text.Trim) Then
            If Not Fx_Tiene_Permiso(Me, "Prod073") Then Return
        End If

        If _Global_Row_Configuracion_General.Item("Pr_Creacion_Exigir_2daDimension") AndAlso String.IsNullOrEmpty(Txt_Nodim2.Text.Trim) Then
            If Not Fx_Tiene_Permiso(Me, "Prod074") Then Return
        End If

        If _Global_Row_Configuracion_General.Item("Pr_Creacion_Exigir_3raDimension") AndAlso String.IsNullOrEmpty(Txt_Nodim3.Text.Trim) Then
            If Not Fx_Tiene_Permiso(Me, "Prod075") Then Return
        End If

        ListaCostoPro = Cmb_Codlista.SelectedValue

        Dim _Pr_AutoPr_Crear_Codigo_Principal_Automatico =
        _Global_Row_Configuracion_General.Item("Pr_AutoPr_Crear_Codigo_Principal_Automatico")

        Dim _Pr_Creacion_Exigir_Precio =
        _Global_Row_Configuracion_General.Item("Pr_Creacion_Exigir_Precio")

        Dim _Pr_Creacion_Exigir_Clasificacion_busqueda =
        _Global_Row_Configuracion_General.Item("Pr_Creacion_Exigir_Clasificacion_busqueda")

        Dim _Pr_Creacion_Exigir_Codigo_Alternativo =
        _Global_Row_Configuracion_General.Item("Pr_Creacion_Exigir_Codigo_Alternativo")

        Dim _Pr_Creacion_Exigir_Dimensiones =
        _Global_Row_Configuracion_General.Item("Pr_Creacion_Exigir_Dimensiones")

        If _Pr_AutoPr_Crear_Codigo_Principal_Automatico Then
            '    If _Crear Then Txtcodigoprincipal.Text = CodigoSugerido("FPN", _Iniciales_Cod, _MaxCarac_Ref_Producto)
        End If

        Dim _Nodo_Raiz_Asociados As Integer = _Global_Row_Configuracion_General.Item("Nodo_Raiz_Asociados")

        ' ACTUALIZAMOS EL REGISTRO DEL PRODUCTO EN EL DATAROW

        _RowProducto.Item("KOPR") = Trim(Txt_Kopr.Text)
        _RowProducto.Item("KOGE") = Trim(Txt_Koge.Text)

        Dim CodRapido As Long

        CodRapido = _Sql.Fx_Cuenta_Registros("MAEPR")

        Txt_Koprra.Text = numero_(Val(_Sql.Fx_Trae_Dato("MAEPR WITH ( NOLOCK )", "MAX(KOPRRA)+1")), 6)
        _RowProducto.Item("KOPRRA") = Txt_Koprra.Text
        _RowProducto.Item("NOKOPR") = Txt_Nokopr.Text.Trim
        _RowProducto.Item("NOKOPRRA") = Mid(Txt_Nokoprra.Text.Trim, 1, 20)

        _RowProducto.Item("KOPRTE") = Txt_Koprte.Text.Trim

        _RowProducto.Item("TIPR") = Cmb_Tipr.SelectedValue.ToString

        _RowProducto.Item("UD01PR") = Txt_Ud01pr.Text.Trim
        _RowProducto.Item("UD02PR") = Txt_Ud02pr.Text.Trim
        _RowProducto.Item("RLUD") = Txt_Rlud.Tag

        _RowProducto.Item("BLOQUEAPR") = Cmb_Bloqueapr.SelectedValue.ToString
        _RowProducto.Item("POIVPR") = Input_Poivpr.Value
        _RowProducto.Item("RGPR") = Cmb_Rgpr.SelectedValue

        _RowProducto.Item("LISCOSTO") = ListaCostoPro

        Dim _Divisible As String
        Dim _Divisible2 As String

        If Chk_Divisible.Checked Then
            _Divisible = "N"
        Else
            _Divisible = "S"
        End If

        If Chk_Divisible2.Checked Then
            _Divisible2 = "N"
        Else
            _Divisible2 = "S"
        End If

        _RowProducto.Item("TRATALOTE") = Chk_Tratalote.Checked ' Stock por lote según origen
        _RowProducto.Item("LOTECAJA") = Chk_Lotecaja.Checked ' Stock por Lote según contenedor
        _RowProducto.Item("CONUBIC") = Chk_Conubic.Checked ' Con Ubicacion en bodega
        _RowProducto.Item("DIVISIBLE") = _Divisible ' Divisible unidad 1 S = Acepta fracciones, N = Solo enteros
        _RowProducto.Item("DIVISIBLE2") = _Divisible2 ' Divisible unidad 2 S = Acepta fracciones, N = Solo enteros
        _RowProducto.Item("PRRG") = Chk_Prrg.Checked ' Descripcion modificable
        _RowProducto.Item("ESACTFI") = Chk_Esactfi.Checked ' Activo fijo (*)
        _RowProducto.Item("MOVETIQ") = Chk_Movetiq.Checked ' Controla movimientos por etiqueta
        _RowProducto.Item("TRATVMEDIA") = Chk_Tratvmedia.Checked ' Tratamiento según Vida media
        _RowProducto.Item("STOCKASEG") = Chk_Stockaseg.Checked ' Con Stock fisico certificado

        _RowProducto.Item("MRPR") = Cmb_Mrpr.SelectedValue ' Marca
        _RowProducto.Item("RUPR") = Cmb_Rupr.SelectedValue ' Rubro
        _RowProducto.Item("CLALIBPR") = Cmb_Clalibpr.SelectedValue 'ClasifLibre

        _RowProducto.Item("FMPR") = CmbSuperFamilia.SelectedValue ' SuperFamilia
        _RowProducto.Item("PFPR") = CmbFamilia.SelectedValue ' Familia
        _RowProducto.Item("HFPR") = CmbSubFamilia.SelectedValue ' SubFamilia

        _RowProducto.Item("KOFUPR") = Cmb_Kofupr.SelectedValue ' JefePro
        _RowProducto.Item("ZONAPR") = Cmb_Zonapr.SelectedValue

        Dim _Nuimpr = 0
        For Each _Fn As DataRow In _Cl_Producto.Pro_Tbl_Impuestos.Rows ' _Ds_Producto.Tables("Tbl_Impuestos").Rows
            If _Fn.Item("Select") Then
                _Nuimpr += 1
            End If
        Next

        _RowProducto.Item("NUIMPR") = _Nuimpr

        _RowProducto.Item("PODEIVPR") = Input_Podeivpr.Value
        _RowProducto.Item("FECRPR") = FechaDelServidor()

        _RowProducto.Item("TOLELOTE") = De_Txt_a_Num_01(Txt_Tolelote.Text)  ' Tolerancia para captura por lotes
        _RowProducto.Item("VIDAMEDIA") = De_Txt_a_Num_01(Txt_Vidamedia.Text) ' Valor vida media

        _RowProducto.Item("PESOUBIC") = De_Txt_a_Num_01(Txt_Pesoubic.Text)
        _RowProducto.Item("LTSUBIC") = De_Txt_a_Num_01(Txt_Ltsubic.Text)

        _RowProducto.Item("ATPR") = ""
        _RowProducto.Item("PLANO") = ""

        _RowProducto.Item("EXENTO") = Chk_Exento.Checked

        _RowProducto.Item("FUNCLOTE") = Cmb_Funclote.SelectedValue
        _RowProducto.Item("NMARCA") = _Cl_CompUdMedidas.Fx_Trae_NMARCA(CInt(Cmb_Nmarca_Comportamiento.SelectedValue), CInt(Cmb_Nmarca_Tratamiento.SelectedValue))

        _RowProducto.Item("NOKOPRAMP") = Txt_Nokopramp.Text.Trim

        Dim _Koprdim As String

        _Koprdim = Btn_Dim_01.Text &
                   Btn_Dim_02.Text &
                   Btn_Dim_03.Text &
                   Btn_Dim_04.Text &
                   Btn_Dim_05.Text &
                   Btn_Dim_06.Text &
                   Btn_Dim_07.Text &
                   Btn_Dim_08.Text &
                   Btn_Dim_09.Text &
                   Btn_Dim_10.Text &
                   Btn_Dim_11.Text &
                   Btn_Dim_12.Text &
                   Btn_Dim_13.Text

        _RowProducto.Item("KOPRDIM") = _Koprdim
        _RowProducto.Item("NODIM1") = Txt_Nodim1.Text
        _RowProducto.Item("NODIM2") = Txt_Nodim2.Text
        _RowProducto.Item("NODIM3") = Txt_Nodim3.Text

        _RowProducto.Item("CAMBIOSUJ") = Chk_Cambiosuj.Checked

        With _Cl_Producto

            .Pro_Maeprobs.Rows(0).Item("MENSAJE01") = Txt_Mensaje01.Text
            .Pro_Maeprobs.Rows(0).Item("MENSAJE02") = Txt_Mensaje02.Text
            .Pro_Maeprobs.Rows(0).Item("MENSAJE03") = Txt_Mensaje03.Text

            .Pro_Maeprobs.Rows(0).Item("ALTO") = Txt_Alto.Text
            .Pro_Maeprobs.Rows(0).Item("LARGO") = Txt_Largo.Text
            .Pro_Maeprobs.Rows(0).Item("ANCHO") = Txt_Ancho.Text

            _Crear_Alternativo = False

            Dim _MsgExisteTbl As String

            _MsgExisteTbl = Fx_ExisteRegistroEnTablaDeOtraBase()

            If Not String.IsNullOrEmpty(_MsgExisteTbl) Then
                MessageBoxEx.Show(Me, _MsgExisteTbl, "No se puede grabar el producto", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Dim _Producto_Creado As String

            If _Cl_Producto.Pro_Accion = Cl_Producto.Enum_Accion.Nuevo Then

                Dim _MsgExistePr As String = Fx_ExisteProductoEnOtraBase(Txt_Kopr.Text)

                If Not String.IsNullOrEmpty(_MsgExistePr) Then
                    MessageBoxEx.Show(Me, _MsgExistePr, "No se puede grabar el producto", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                _Producto_Creado = _Cl_Producto.Fx_Crear_Nuevo_Producto

            ElseIf _Cl_Producto.Pro_Accion = Cl_Producto.Enum_Accion.Editar Then
                _Producto_Creado = _Cl_Producto.Fx_Editar_Producto
            End If

            If Not String.IsNullOrEmpty(_Producto_Creado) Then
                MessageBoxEx.Show(Me, _Producto_Creado, "Problema al crear el producto en Random", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            If _Cl_Producto.Pro_Accion = Cl_Producto.Enum_Accion.Editar Then

                If _Global_Row_Configuracion_General.Item("PermitirMigrarProductosBaseExterna") Then

                    Dim _Codigo As String = Txt_Kopr.Text

                    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Conexion Where GrbProd_Nuevos = 1"
                    Dim _Tbl_Conexiones As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                    For Each _FilaCx As DataRow In _Tbl_Conexiones.Rows

                        Dim _Id_Conexion As Integer = _FilaCx.Item("Id")
                        Dim _BaseDeDatos As String = _FilaCx.Item("BaseDeDatos")
                        Dim _Cl_Migrar_Producto As New Bk_Migrar_Producto.Cl_ConexionExterna

                        Dim _ConexionExternas As New Bk_Migrar_Producto.ConexionExternas

                        _ConexionExternas = _Cl_Migrar_Producto.Fx_CadenaConexionServExt(_Id_Conexion)

                        If _ConexionExternas.EsCorrecto Then

                            Dim _Sql2 = New Class_SQL(_ConexionExternas.Cadena_ConexionSQL_Server_Ext)

                            If _ConexionExternas.SincroProductos Then

                                Dim _RludExt = _Sql2.Fx_Trae_Dato("MAEPR", "RLUD", "KOPR = '" & _Codigo & "'")
                                Dim _EditarRtu As Boolean = True

                                If Val(_RludExt) <> Val(Txt_Rlud.Text) Then
                                    _EditarRtu = False
                                End If

                                _Reg = _Sql2.Fx_Cuenta_Registros("MAEPR", "KOPR = '" & _Codigo & "'")

                                If _Reg = 0 Then
                                    MessageBoxEx.Show(Me, "No se pudo migrar el producto hacia la base de datos externa" & vbCrLf &
                                                          "Base de datos: " & _BaseDeDatos & vbCrLf & vbCrLf & "NO EXISTE EL PRODUCTO",
                                                          "Crear producto en base externa",
                                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Else

                                    Dim _SincroNmarca As Boolean = _Cl_Migrar_Producto.Row_DnExt.Item("SincroNmarca")

                                    If _SincroNmarca Then _EditarRtu = True

                                    Consulta_sql = _Cl_Producto.Fx_Editar_Producto_Base_Externa(_ConexionExternas.Global_BaseBk, _EditarRtu)

                                    Dim _SincroMarcas As Boolean = _Cl_Migrar_Producto.Row_DnExt.Item("SincroMarcas")
                                    Dim _SincroFamilias As Boolean = _Cl_Migrar_Producto.Row_DnExt.Item("SincroFamilias")
                                    Dim _SincroRubros As Boolean = _Cl_Migrar_Producto.Row_DnExt.Item("SincroRubros")
                                    Dim _SincroClaslibre As Boolean = _Cl_Migrar_Producto.Row_DnExt.Item("SincroClaslibre")
                                    Dim _SincroZonaProducto As Boolean = _Cl_Migrar_Producto.Row_DnExt.Item("SincroZonaProducto")
                                    Dim _SincroZonas As Boolean = _Cl_Migrar_Producto.Row_DnExt.Item("SincroZonas")
                                    Dim _SincroEmpresa As Boolean = _Cl_Migrar_Producto.Row_DnExt.Item("SincroEmpresa")
                                    Dim _SincroTratalote As Boolean = _Cl_Migrar_Producto.Row_DnExt.Item("SincroTratalote")
                                    Dim _SincroDimensiones As Boolean = _Cl_Migrar_Producto.Row_DnExt.Item("SincroDimensiones")


                                    If Not _SincroMarcas Then Consulta_sql = Replace(Consulta_sql, "MRPR = @MRPR,", "--MRPR = @MRPR,")
                                    If Not _SincroFamilias Then
                                        Consulta_sql = Replace(Consulta_sql, "FMPR = @FMPR,", "--FMPR = @FMPR,")
                                        Consulta_sql = Replace(Consulta_sql, "PFPR = @PFPR,", "--PFPR = @PFPR,")
                                        Consulta_sql = Replace(Consulta_sql, "HFPR = @HFPR,", "--HFPR = @HFPR,")
                                    End If
                                    If Not _SincroRubros Then Consulta_sql = Replace(Consulta_sql, "RUPR = @RUPR,", "--RUPR = @RUPR,")
                                    If Not _SincroClaslibre Then Consulta_sql = Replace(Consulta_sql, "CLALIBPR = @CLALIBPR,", "--CLALIBPR = @CLALIBPR,")
                                    If Not _SincroZonaProducto Then Consulta_sql = Replace(Consulta_sql, "ZONAPR = @ZONAPR,", "--ZONAPR = @ZONAPR,")
                                    If Not _SincroTratalote Then
                                        Consulta_sql = Replace(Consulta_sql, "TRATALOTE = @TRATALOTE,", "--TRATALOTE = @TRATALOTE,")
                                        Consulta_sql = Replace(Consulta_sql, "LOTECAJA = @LOTECAJA,", "--LOTECAJA = @LOTECAJA,")
                                    End If
                                    If Not _SincroDimensiones Then
                                        Consulta_sql = Replace(Consulta_sql, "KOPRDIM = @KOPRDIM,", "--KOPRDIM = @KOPRDIM,")
                                        Consulta_sql = Replace(Consulta_sql, "NODIM1 = @NODIM1,", "--NODIM1 = @NODIM1,")
                                        Consulta_sql = Replace(Consulta_sql, "NODIM2 = @NODIM2,", "--NODIM2 = @NODIM2,")
                                        Consulta_sql = Replace(Consulta_sql, "NODIM3 = @NODIM3,", "--NODIM3 = @NODIM3,")
                                    End If
                                    If Not _SincroNmarca Then Consulta_sql = Replace(Consulta_sql, "NMARCA = @NMARCA,", "--NMARCA = @NMARCA,")

                                    'Estos tratamientos son siempre por empresa independiente
                                    Consulta_sql = Replace(Consulta_sql, "CONUBIC = @CONUBIC,", "--CONUBIC = @CONUBIC,")
                                    Consulta_sql = Replace(Consulta_sql, "BLOQUEAPR = @BLOQUEAPR,", "--BLOQUEAPR = @BLOQUEAPR,")
                                    Consulta_sql = Replace(Consulta_sql, "LISCOSTO = @LISCOSTO,", "--LISCOSTO = @LISCOSTO,")
                                    Consulta_sql = Replace(Consulta_sql, "FUNCLOTE = @FUNCLOTE,", "--FUNCLOTE = @FUNCLOTE,")
                                    'BLOQUEAPR = @BLOQUEAPR,
                                    If _Sql2.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                                        If _EditarRtu Then
                                            MessageBoxEx.Show(Me, "Producto editado correctamente en la base de datos externa" & vbCrLf &
                                                                  "Base de datos: " & _BaseDeDatos,
                                                                  "Crear producto en base externa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Else
                                            MessageBoxEx.Show(Me, "Producto editado correctamente en la base de datos externa" & vbCrLf &
                                                              "Sin embargo la RTU es distinta a la RTU del producto en la base de datos externa" & vbCrLf &
                                                              "Base de datos: " & _BaseDeDatos & vbCrLf & vbCrLf &
                                                               "Informe de esta situación al administrador del sistema", "Validación",
                                                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                        End If

                                    Else
                                        MessageBoxEx.Show(Me, "No se pudo migrar el producto hacia la base de datos externa" & vbCrLf &
                                                              "Base de datos: " & _BaseDeDatos & vbCrLf & vbCrLf & _Sql2.Pro_Error,
                                                              "Crear producto en base externa",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    End If

                                End If


                            End If

                        Else
                            MessageBoxEx.Show(Me, "No fue posible editar el producto en base de datos externa" & vbCrLf & vbCrLf &
                                                  "Base de datos: " & _BaseDeDatos & vbCrLf & vbCrLf &
                                                  _ConexionExternas.MensajeError, "Editar producto en base externa",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If

                    Next

                End If

            End If


            If _Cl_Producto.Pro_Accion = Cl_Producto.Enum_Accion.Nuevo Then

                Consulta_sql =
                "Insert Into " & _Global_BaseBk & "Zw_Prod_Asociacion (Codigo,Codigo_Nodo,DescripcionBusqueda,Para_filtro,Clas_unica,Producto)" & vbCrLf &
                "Values" & vbCrLf &
                "('" & _RowProducto.Item("KOPR") & "',0,'" & _RowProducto.Item("KOPR") & " " & _RowProducto.Item("NOKOPR") & "',0,0,1)"
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Asociacion Set DescripcionBusqueda = '" & Txt_Kopr.Text.Trim & " " & Txt_Nokopr.Text & "'" & vbCrLf &
                           "Where Codigo = '" & Txt_Kopr.Text & "' And Producto = 1"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_Dimensiones Where Codigo = '" & Txt_Kopr.Text & "'" & vbCrLf &
                           "Insert Into " & _Global_BaseBk & "Zw_Prod_Dimensiones (Codigo,Peso,Alto,Largo,Ancho) Values " &
                           "('" & Txt_Kopr.Text & "'," &
                           De_Num_a_Tx_01(Txt_Pesoubic.Text, False, 5) & "," &
                           De_Num_a_Tx_01(Txt_Alto.Text, False, 5) & "," &
                           De_Num_a_Tx_01(Txt_Largo.Text, False, 5) & "," &
                           De_Num_a_Tx_01(Txt_Ancho.Text, False, 5) & ")"
            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)


            If _Cl_Producto.Pro_Accion = Cl_Producto.Enum_Accion.Nuevo Then

                If String.IsNullOrEmpty(_Producto_Creado) Then

                    If _Pr_Creacion_Exigir_Precio Then
                        Dim _PuedeGrabarSinPrecios As Boolean
                        MessageBoxEx.Show(Me, "A continuación debe ingresar los precios del producto",
                                          "Precios del producto", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Do
                            If Not Fx_Ingresar_Precio_Nuevo_Producto(_RowProducto) Then
                                _PuedeGrabarSinPrecios = Fx_Tiene_Permiso(Me, "Prod011")
                            Else
                                _PuedeGrabarSinPrecios = True
                            End If
                        Loop While Not _PuedeGrabarSinPrecios

                    End If

                    If _Pr_Creacion_Exigir_Clasificacion_busqueda Then
                        Dim ATPR = String.Empty

                        MessageBoxEx.Show(Me, "A continuación debe ingresar las clasificaciones de busqueda del producto",
                                        "Clasificaciones del producto", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Dim _PuedeGrabarSinAsociaciones = False
                        Dim _PuedeGrabarSinAsociaciones_Unicas = False
                        Dim _PuedeGrabarSinAsociaciones_Unicas_Obligatorias = False

                        Dim _Grabar_Sin_Asiciaciones = False

                        Do

                            Dim FrmBa As New Frm_MtCreaProd_01_IngBusqEspecial
                            With FrmBa
                                .TxtCodigo.Text = _RowProducto.Item("KOPR")
                                .TxtDescripcion.Text = _RowProducto.Item("NOKOPR")
                                .ShowDialog(Me)
                            End With

                            Dim _Tbl As DataTable

                            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                                           "Where Producto = 0 And Codigo_Nodo In (Select Codigo_Nodo" & Space(1) &
                                           "From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & Space(1) &
                                           "Where Clas_Unica_X_Producto = 0 And Es_Seleccionable = 1)" & vbCrLf &
                                           "And Codigo = '" & Txt_Kopr.Text & "'"
                            _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)

                            _PuedeGrabarSinAsociaciones = CBool(_Tbl.Rows.Count)

                            If Not CBool(_Tbl.Rows.Count) Then
                                _PuedeGrabarSinAsociaciones = Fx_Tiene_Permiso(Me, "Prod016")
                                If Not _PuedeGrabarSinAsociaciones Then GoTo Sigue_Loop_01
                            End If

                            Dim _Reg_Obligatorios = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_TblArbol_Asociaciones", "Clas_Unica_X_Producto = 1 And Nodo_Raiz = 0")

                            ' ASOCIACIONES UNICAS Y OBLIGATORIAS

                            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                                           "Where Clas_Unica_X_Producto = 1 And Nodo_Raiz = 0 And Codigo_Nodo Not In" & Space(1) &
                                           "(Select Codigo_Nodo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo = '" & Txt_Kopr.Text & "')"
                            _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)

                            If CBool(_Tbl.Rows.Count) Then

                                Dim _Msg As String = String.Empty
                                For Each _Fl As DataRow In _Tbl.Rows
                                    _Msg = _Msg & " - " & _Fl.Item("Descripcion") & vbCrLf
                                Next
                                MessageBoxEx.Show(Me, "Le faltan " & _Tbl.Rows.Count & " asociaciones por marcar" & vbCrLf & vbCrLf & _Msg, "Validación",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)

                                _PuedeGrabarSinAsociaciones_Unicas = Fx_Tiene_Permiso(Me, "Prod050")
                            Else
                                _PuedeGrabarSinAsociaciones_Unicas = True
                            End If

                            If _PuedeGrabarSinAsociaciones And _PuedeGrabarSinAsociaciones_Unicas Then
                                _Grabar_Sin_Asiciaciones = True
                            End If

Sigue_Loop_01:

                        Loop While Not _Grabar_Sin_Asiciaciones

                    End If

                    If _Pr_Creacion_Exigir_Codigo_Alternativo Then

                        MessageBoxEx.Show(Me, "A continuación debe ingresar el código alternativo del producto",
                                       "Código alternativo", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Dim _PuedeGrabarSinAlternativo As Boolean

                        Do

                            If Not Fx_Ingresar_Cod_Alternativo(_RowProducto) Then

                                _PuedeGrabarSinAlternativo = Fx_Tiene_Permiso(Me, "Prod008")

                                If _PuedeGrabarSinAlternativo Then
                                    Exit Do
                                End If
                            Else
                                Exit Do
                            End If
                        Loop While Not _PuedeGrabarSinAlternativo

                    End If

                    If _Pr_Creacion_Exigir_Dimensiones Then

                        Dim _Grabar As Boolean

                        Dim _PuedeGrabarSinDimensiones As Boolean
                        MessageBoxEx.Show(Me, "A continuación debe ingresar los precios del producto",
                                          "Precios del producto", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Do

                            Dim Fm_Dm As New Frm_Dimensiones_Pr(Txt_Kopr.Text, True)
                            Fm_Dm.ShowDialog(Me)
                            _Grabar = Fm_Dm.Grabar
                            Fm_Dm.Dispose()

                            If Not _Grabar Then
                                _PuedeGrabarSinDimensiones = Fx_Tiene_Permiso(Me, "Prod064")
                            Else
                                _PuedeGrabarSinDimensiones = True
                            End If

                        Loop While Not _PuedeGrabarSinDimensiones

                    End If

                    If False Then
                        Fx_Eliminar_Producto(Txt_Kopr.Text, Txt_Nokopr.Text, False)
                        Return
                    End If

                    If _Global_Row_Configuracion_General.Item("PermitirMigrarProductosBaseExterna") Then

                        Dim _Codigo As String = Txt_Kopr.Text

                        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Conexion Where GrbProd_Nuevos = 1"
                        Dim _Tbl_Conexiones As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                        For Each _FilaCx As DataRow In _Tbl_Conexiones.Rows

                            Dim _Id_Conexion As Integer = _FilaCx.Item("Id")
                            Dim _BaseDeDatos As String = _FilaCx.Item("BaseDeDatos")
                            Dim _Cl_Migrar_Producto As New Bk_Migrar_Producto.Cl_Migrar_Producto(_Id_Conexion)

                            If _Cl_Migrar_Producto.SePuedeMigrar Then

                                Dim _GrbProd_Nuevos = _Cl_Migrar_Producto.Row_DnExt.Item("GrbProd_Nuevos")
                                Dim _GrbEnti_Nuevas = _Cl_Migrar_Producto.Row_DnExt.Item("GrbEnti_Nuevas")
                                Dim _GrbProd_Bodegas = _Cl_Migrar_Producto.Row_DnExt.Item("GrbProd_Bodegas")
                                Dim _GrbProd_Listas = _Cl_Migrar_Producto.Row_DnExt.Item("GrbProd_Listas")

                                If _GrbProd_Nuevos Then

                                    If _Cl_Migrar_Producto.Fx_Migrar_Producto(_Codigo) Then
                                        MessageBoxEx.Show(Me, "Producto exportado correctamente hacia la base de datos externa" & vbCrLf &
                                                          "Base de datos: " & _BaseDeDatos,
                                                          "Crear producto en base externa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Else
                                        MessageBoxEx.Show(Me, "No se pudo migrar el producto hacia la base de datos externa" & vbCrLf &
                                                          "Base de datos: " & _BaseDeDatos & vbCrLf & vbCrLf & _Cl_Migrar_Producto.ProError,
                                                          "Crear producto en base externa",
                                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    End If

                                End If

                            Else
                                MessageBoxEx.Show(Me, "No fue posible crear el producto en base de datos externa" & vbCrLf & vbCrLf &
                                                  "Base de datos: " & _BaseDeDatos & vbCrLf & vbCrLf &
                                                  _Cl_Migrar_Producto.ProError, "Crear producto en base externa",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            End If

                        Next

                    End If


                    If _Preguntar_Crear_Otro Then

                        If MessageBoxEx.Show(Me, "¿Desea crear un nuevo producto?",
                                                "Crear producto",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                            If MessageBoxEx.Show(Me, "¿Desea mantener los parametros del producto [Yes] o [No] Limpiar todo?",
                                              "Crear producto",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                                _Cl_Producto.Sb_Cargar_Producto("")
                                Sb_Limpiar()
                            Else
                                Txt_Kopr.Text = String.Empty
                                Txt_Koprte.Text = String.Empty
                            End If
                        Else
                            _Grabar = True
                            Me.Close()
                        End If
                    Else
                        Me.Close()
                    End If
                End If
            Else
                _Grabar = True
                Me.Close()
            End If

        End With

        Txt_Kopr.Focus()
    End Sub

    Private Sub Sb_Grabar2()

        If String.IsNullOrEmpty(Trim(Txt_Kopr.Text)) Then
            MessageBoxEx.Show(Me, "Debe ingresar código principal", "Código principal", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Kopr.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Trim(Txt_Koprte.Text)) Then
            MessageBoxEx.Show(Me, "Debe ingresar código técnico", "código técnico", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Kopr.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Ud01pr.Text.Trim) Or String.IsNullOrEmpty(Txt_Ud02pr.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta la unidad de mediad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Len(Trim(Txt_Nokopr.Text)) > 50 Then

            MessageBoxEx.Show(Me, "Largo máximo de la descripción 50 caracteres",
                                   "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return

        End If

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("MAEPR", "KOPR <> '" & Trim(Txt_Kopr.Text) &
                                               "' AND NOKOPR = '" & Trim(Txt_Nokopr.Text) & "'")
        If _Reg > 0 Then

            If MessageBoxEx.Show(Me, Txt_Nokopr.Text & vbCrLf & vbCrLf & "Esta descripción de producto ya existe" & vbCrLf &
                                  "¿Desea continuar con la grabación?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) <> Windows.Forms.DialogResult.Yes Then
                Txt_Nokopr.Focus()
                Return
            End If
        End If


        If String.IsNullOrEmpty(Trim(Cmb_Codlista.SelectedValue)) Then
            If Not Fx_Tiene_Permiso(Me, "Prod027") Then Return
        End If

        If String.IsNullOrEmpty(Trim(Cmb_Kofupr.SelectedValue)) Then
            If Not Fx_Tiene_Permiso(Me, "Prod024") Then Return
        End If

        If String.IsNullOrEmpty(Trim(Cmb_Zonapr.SelectedValue)) Then
            If Not Fx_Tiene_Permiso(Me, "Prod025") Then Return
        End If

        If String.IsNullOrEmpty(Trim(Cmb_Mrpr.SelectedValue)) Then
            If Not Fx_Tiene_Permiso(Me, "Prod026") Then Return
        End If

        If String.IsNullOrEmpty(Trim(Cmb_Rupr.SelectedValue)) Then
            If Not Fx_Tiene_Permiso(Me, "Prod028") Then Return
        End If

        If String.IsNullOrEmpty(Trim(Cmb_Clalibpr.SelectedValue)) Then
            If Not Fx_Tiene_Permiso(Me, "Prod029") Then Return
        End If

        If String.IsNullOrEmpty(Trim(CmbSuperFamilia.SelectedValue)) Then
            If Not Fx_Tiene_Permiso(Me, "Prod030") Then Return
        End If

        If String.IsNullOrEmpty(Trim(CmbFamilia.SelectedValue)) Then
            If Not Fx_Tiene_Permiso(Me, "Prod031") Then Return
        End If

        If String.IsNullOrEmpty(Trim(CmbSubFamilia.SelectedValue)) Then
            If Not Fx_Tiene_Permiso(Me, "Prod033") Then Return
        End If

        ListaCostoPro = Cmb_Codlista.SelectedValue

        Dim _Pr_AutoPr_Crear_Codigo_Principal_Automatico =
        _Global_Row_Configuracion_General.Item("Pr_AutoPr_Crear_Codigo_Principal_Automatico")

        Dim _Pr_Creacion_Exigir_Precio =
        _Global_Row_Configuracion_General.Item("Pr_Creacion_Exigir_Precio")

        Dim _Pr_Creacion_Exigir_Clasificacion_busqueda =
        _Global_Row_Configuracion_General.Item("Pr_Creacion_Exigir_Clasificacion_busqueda")

        Dim _Pr_Creacion_Exigir_Codigo_Alternativo =
        _Global_Row_Configuracion_General.Item("Pr_Creacion_Exigir_Codigo_Alternativo")

        Dim _Pr_Creacion_Exigir_Dimensiones =
        _Global_Row_Configuracion_General.Item("Pr_Creacion_Exigir_Dimensiones")

        If _Pr_AutoPr_Crear_Codigo_Principal_Automatico Then
            '    If _Crear Then Txtcodigoprincipal.Text = CodigoSugerido("FPN", _Iniciales_Cod, _MaxCarac_Ref_Producto)
        End If

        Dim _Nodo_Raiz_Asociados As Integer = _Global_Row_Configuracion_General.Item("Nodo_Raiz_Asociados")

        ' ACTUALIZAMOS EL REGISTRO DEL PRODUCTO EN EL DATAROW

        _RowProducto.Item("KOPR") = Trim(Txt_Kopr.Text)
        _RowProducto.Item("KOGE") = Trim(Txt_Koge.Text)

        Dim CodRapido As Long

        CodRapido = _Sql.Fx_Cuenta_Registros("MAEPR")

        Txt_Koprra.Text = numero_(Val(_Sql.Fx_Trae_Dato("MAEPR WITH ( NOLOCK )", "MAX(KOPRRA)+1")), 6)
        _RowProducto.Item("KOPRRA") = Txt_Koprra.Text
        _RowProducto.Item("NOKOPR") = Txt_Nokopr.Text.Trim
        _RowProducto.Item("NOKOPRRA") = Trim(Mid(Txt_Nokoprra.Text, 20))

        _RowProducto.Item("KOPRTE") = Txt_Koprte.Text.Trim

        _RowProducto.Item("TIPR") = Cmb_Tipr.SelectedValue.ToString

        _RowProducto.Item("UD01PR") = Txt_Ud01pr.Text.Trim
        _RowProducto.Item("UD02PR") = Txt_Ud02pr.Text.Trim
        _RowProducto.Item("RLUD") = Txt_Rlud.Tag

        _RowProducto.Item("BLOQUEAPR") = Cmb_Bloqueapr.SelectedValue.ToString
        _RowProducto.Item("POIVPR") = Input_Poivpr.Value
        _RowProducto.Item("RGPR") = Cmb_Rgpr.SelectedValue

        _RowProducto.Item("LISCOSTO") = ListaCostoPro

        Dim _Divisible As String
        Dim _Divisible2 As String

        If Chk_Divisible.Checked Then
            _Divisible = "N"
        Else
            _Divisible = "S"
        End If

        If Chk_Divisible2.Checked Then
            _Divisible2 = "N"
        Else
            _Divisible2 = "S"
        End If

        _RowProducto.Item("TRATALOTE") = Chk_Tratalote.Checked ' Stock por lote según origen
        _RowProducto.Item("LOTECAJA") = Chk_Lotecaja.Checked ' Stock por Lote según contenedor
        _RowProducto.Item("CONUBIC") = Chk_Conubic.Checked ' Con Ubicacion en bodega
        _RowProducto.Item("DIVISIBLE") = _Divisible ' Divisible unidad 1 S = Acepta fracciones, N = Solo enteros
        _RowProducto.Item("DIVISIBLE2") = _Divisible2 ' Divisible unidad 2 S = Acepta fracciones, N = Solo enteros
        _RowProducto.Item("PRRG") = Chk_Prrg.Checked ' Descripcion modificable
        _RowProducto.Item("ESACTFI") = Chk_Esactfi.Checked ' Activo fijo (*)
        _RowProducto.Item("MOVETIQ") = Chk_Movetiq.Checked ' Controla movimientos por etiqueta
        _RowProducto.Item("TRATVMEDIA") = Chk_Tratvmedia.Checked ' Tratamiento según Vida media
        _RowProducto.Item("STOCKASEG") = Chk_Stockaseg.Checked ' Con Stock fisico certificado

        _RowProducto.Item("MRPR") = Cmb_Mrpr.SelectedValue ' Marca
        _RowProducto.Item("RUPR") = Cmb_Rupr.SelectedValue ' Rubro
        _RowProducto.Item("CLALIBPR") = Cmb_Clalibpr.SelectedValue 'ClasifLibre

        _RowProducto.Item("FMPR") = CmbSuperFamilia.SelectedValue ' SuperFamilia
        _RowProducto.Item("PFPR") = CmbFamilia.SelectedValue ' Familia
        _RowProducto.Item("HFPR") = CmbSubFamilia.SelectedValue ' SubFamilia

        _RowProducto.Item("KOFUPR") = Cmb_Kofupr.SelectedValue ' JefePro
        _RowProducto.Item("ZONAPR") = Cmb_Zonapr.SelectedValue

        Dim _Nuimpr = 0
        For Each _Fn As DataRow In _Cl_Producto.Pro_Tbl_Impuestos.Rows ' _Ds_Producto.Tables("Tbl_Impuestos").Rows
            If _Fn.Item("Select") Then
                _Nuimpr += 1
            End If
        Next

        _RowProducto.Item("NUIMPR") = _Nuimpr

        _RowProducto.Item("PODEIVPR") = Input_Podeivpr.Value
        _RowProducto.Item("FECRPR") = FechaDelServidor()

        _RowProducto.Item("TOLELOTE") = De_Txt_a_Num_01(Txt_Tolelote.Text)  ' Tolerancia para captura por lotes
        _RowProducto.Item("VIDAMEDIA") = De_Txt_a_Num_01(Txt_Vidamedia.Text) ' Valor vida media

        _RowProducto.Item("PESOUBIC") = De_Txt_a_Num_01(Txt_Pesoubic.Text)
        _RowProducto.Item("LTSUBIC") = De_Txt_a_Num_01(Txt_Ltsubic.Text)

        _RowProducto.Item("ATPR") = ""
        _RowProducto.Item("PLANO") = ""


        '  TOLELOTE, VIDAMEDIA

        With _Cl_Producto

            .Pro_Maeprobs.Rows(0).Item("MENSAJE01") = Txt_Mensaje01.Text
            .Pro_Maeprobs.Rows(0).Item("MENSAJE02") = Txt_Mensaje02.Text
            .Pro_Maeprobs.Rows(0).Item("MENSAJE03") = Txt_Mensaje03.Text

            _Crear_Alternativo = False


            Dim _Producto_Creado As Boolean

            If _Cl_Producto.Pro_Accion = Cl_Producto.Enum_Accion.Nuevo Then
                _Producto_Creado = _Cl_Producto.Fx_Crear_Nuevo_Producto
            ElseIf _Cl_Producto.Pro_Accion = Cl_Producto.Enum_Accion.Editar Then
                _Producto_Creado = _Cl_Producto.Fx_Editar_Producto
            End If


            If _Producto_Creado Then

                If _Cl_Producto.Pro_Accion = Cl_Producto.Enum_Accion.Nuevo Then

                    Consulta_sql =
                    "Insert Into " & _Global_BaseBk & "Zw_Prod_Asociacion (Codigo,Codigo_Nodo,DescripcionBusqueda,Para_filtro,Clas_unica,Producto)" & vbCrLf &
                    "Values" & vbCrLf &
                    "('" & _RowProducto.Item("KOPR") & "',0,'" & _RowProducto.Item("KOPR") & " " & _RowProducto.Item("NOKOPR") & "',0,0,1)"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

            Else
                Return
            End If


            If _Cl_Producto.Pro_Accion = Cl_Producto.Enum_Accion.Nuevo Then

                If _Producto_Creado Then

                    If _Pr_Creacion_Exigir_Precio Then

                        Dim _PuedeGrabarSinPrecios As Boolean

                        MessageBoxEx.Show(Me, "A continuación debe ingresar los precios del producto",
                                          "Precios del producto", MessageBoxButtons.OK, MessageBoxIcon.Information)


                        If Not Fx_Ingresar_Precio_Nuevo_Producto(_RowProducto) Then
                            _PuedeGrabarSinPrecios = Fx_Tiene_Permiso(Me, "Prod011")
                        Else
                            _PuedeGrabarSinPrecios = True
                        End If

                        If Not _PuedeGrabarSinPrecios Then
                            Fx_Eliminar_Producto(Txt_Kopr.Text, Txt_Nokopr.Text, False)
                            Return
                        End If

                    End If


                    If _Pr_Creacion_Exigir_Clasificacion_busqueda Then

                        Dim ATPR = String.Empty

                        MessageBoxEx.Show(Me, "A continuación debe ingresar las clasificaciones de busqueda del producto",
                                        "Clasificaciones del producto", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Dim _PuedeGrabarSinAsociaciones = False
                        Dim _PuedeGrabarSinAsociaciones_Unicas = False
                        Dim _PuedeGrabarSinAsociaciones_Unicas_Obligatorias = False

                        Dim _Grabar_Sin_Asiciaciones = False

                        'Do

                        Dim FrmBa As New Frm_MtCreaProd_01_IngBusqEspecial
                        FrmBa.TxtCodigo.Text = _RowProducto.Item("KOPR")
                        FrmBa.TxtDescripcion.Text = _RowProducto.Item("NOKOPR")
                        FrmBa.ShowDialog(Me)

                        Dim _Tbl As DataTable

                        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                                       "Where Producto = 0 And Codigo_Nodo In (Select Codigo_Nodo" & Space(1) &
                                       "From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & Space(1) &
                                       "Where Clas_Unica_X_Producto = 0 And Es_Seleccionable = 1)" & vbCrLf &
                                       "And Codigo = '" & Txt_Kopr.Text & "'"
                        _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)

                        _PuedeGrabarSinAsociaciones = CBool(_Tbl.Rows.Count)

                        If Not CBool(_Tbl.Rows.Count) Then
                            _PuedeGrabarSinAsociaciones = Fx_Tiene_Permiso(Me, "Prod016")
                            If Not _PuedeGrabarSinAsociaciones Then
                                Fx_Eliminar_Producto(Txt_Kopr.Text, Txt_Nokopr.Text, False)
                                Return
                            End If
                        End If

                        Dim _Reg_Obligatorios = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_TblArbol_Asociaciones", "Clas_Unica_X_Producto = 1 And Nodo_Raiz = 0")

                        ' ASOCIACIONES UNICAS Y OBLIGATORIAS

                        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                                       "Where Clas_Unica_X_Producto = 1 And Nodo_Raiz = 0 And Codigo_Nodo Not In" & Space(1) &
                                       "(Select Codigo_Nodo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo = '" & Txt_Kopr.Text & "')"
                        _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)

                        If CBool(_Tbl.Rows.Count) Then

                            Dim _Msg As String = String.Empty
                            For Each _Fl As DataRow In _Tbl.Rows
                                _Msg = _Msg & " - " & _Fl.Item("Descripcion") & vbCrLf
                            Next
                            MessageBoxEx.Show(Me, "Le faltan " & _Tbl.Rows.Count & " asociaciones por marcar" & vbCrLf & vbCrLf & _Msg, "Validación",
                                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

                            _PuedeGrabarSinAsociaciones_Unicas = Fx_Tiene_Permiso(Me, "Prod050")
                        Else
                            _PuedeGrabarSinAsociaciones_Unicas = True
                        End If

                        If _PuedeGrabarSinAsociaciones And _PuedeGrabarSinAsociaciones_Unicas Then
                            _Grabar_Sin_Asiciaciones = True
                        End If

                        If Not _PuedeGrabarSinAsociaciones Or Not _PuedeGrabarSinAsociaciones_Unicas Then
                            Fx_Eliminar_Producto(Txt_Kopr.Text, Txt_Nokopr.Text, False)
                            Return
                        End If

                        'Loop While Not _Grabar_Sin_Asiciaciones

                    End If


                    If _Pr_Creacion_Exigir_Codigo_Alternativo Then

                        MessageBoxEx.Show(Me, "A continuación debe ingresar el código alternativo del producto",
                                       "Código alternativo", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Dim _PuedeGrabarSinAlternativo As Boolean

                        'Do

                        If Not Fx_Ingresar_Cod_Alternativo(_RowProducto) Then
                            _PuedeGrabarSinAlternativo = Fx_Tiene_Permiso(Me, "Prod008")
                        End If
                        'Loop While Not _PuedeGrabarSinAlternativo

                        If Not _PuedeGrabarSinAlternativo Then
                            Fx_Eliminar_Producto(Txt_Kopr.Text, Txt_Nokopr.Text, False)
                            Return
                        End If

                    End If

                    If _Pr_Creacion_Exigir_Dimensiones Then

                        Dim _Grabar As Boolean

                        Dim Fm_Dm As New Frm_Dimensiones_Pr(Txt_Kopr.Text, True)
                        Fm_Dm.ShowDialog(Me)
                        Fm_Dm.Dispose()

                        If Not _Grabar Then

                            Fx_Eliminar_Producto(Txt_Kopr.Text, Txt_Nokopr.Text, False)
                            Return

                        End If

                    End If


                    If _Preguntar_Crear_Otro Then

                        If MessageBoxEx.Show(Me, "¿Desea crear un nuevo producto?",
                                                "Crear producto",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                            If MessageBoxEx.Show(Me, "¿Desea mantener los parametros del producto [Yes] o [No] Limpiar todo?",
                                              "Crear producto",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                                _Cl_Producto.Sb_Cargar_Producto("")
                                Sb_Limpiar()
                            Else
                                Txt_Kopr.Text = String.Empty
                                Txt_Koprte.Text = String.Empty
                            End If
                        Else
                            _Grabar = True
                            Me.Close()
                        End If
                    Else
                        Me.Close()
                    End If
                End If
            Else
                _Grabar = True
                Me.Close()
            End If

        End With

        Txt_Kopr.Focus()
    End Sub


    Private Sub Txtcodigoprincipal_Leave(sender As System.Object, e As System.EventArgs)
        If _Cl_Producto.Pro_Accion = Cl_Producto.Enum_Accion.Nuevo Then
            If Fx_ValidarExistenciaDeCodigo(sender.text, "KOPR") = True Then Txt_Kopr.Focus()
            If Not Fx_ValidarExistenciaDeCodigoAlternativo(sender.text) Then Txt_Kopr.Focus()

            Dim _MsgExiste As String = Fx_ExisteProductoEnOtraBase(Txt_Kopr.Text)

            If Not String.IsNullOrEmpty(_MsgExiste) Then
                MessageBoxEx.Show(Me, "El sistema esta configurado para sincronizar productos con otra(s) base de datos" & vbCrLf & vbCrLf & _MsgExiste,
                                  "No se puede grabar el producto", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Kopr.Text = String.Empty
                Txt_Koprte.Text = String.Empty
                Txt_Kopr.Focus()
            End If
        End If
    End Sub

    Private Sub Txtcodigotecnico_Leave(sender As System.Object, e As System.EventArgs)
        If _Cl_Producto.Pro_Accion = Cl_Producto.Enum_Accion.Nuevo Then
            If Fx_ValidarExistenciaDeCodigo(sender.text, "KOPRTE") = True Then Txt_Koprte.Focus()
            'If Not Fx_ValidarExistenciaDeCodigoAlternativo(sender.text) Then Txt_Kopr.Focus()
        End If
    End Sub

    Private Sub Txtcodigoprincipal_TextChanged(sender As System.Object, e As System.EventArgs)
        Txt_Koprte.Text = Txt_Kopr.Text
    End Sub

    Private Sub ChkSelEmpresas_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkSelEmpresas.CheckedChanged
        ChequearTodo(GrillaEmpresa, ChkSelEmpresas, "Empresa")
    End Sub

    Private Sub ChkSelBodegas_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkSelBodegas.CheckedChanged
        ChequearTodo(GrillaBodegas, ChkSelBodegas, "Bodega")
    End Sub

    Private Sub ChkSelListas_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkSelListas.CheckedChanged
        ChequearTodo(GrillaListaDePrecios, ChkSelListas, "Listas")
    End Sub

    Private Sub ChkSelTodo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkSelTodo.CheckedChanged
        ChkSelEmpresas.Checked = ChkSelTodo.Checked
        ChkSelBodegas.Checked = ChkSelTodo.Checked
        ChkSelListas.Checked = ChkSelTodo.Checked
    End Sub

    Private Sub TxtDescripcionLarga_TextChanged(sender As System.Object, e As System.EventArgs)
        Txt_Nokoprra.Text = Mid(Txt_Nokopr.Text, 1, 20)
    End Sub

    Private Sub CmbSuperFamilia_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbSuperFamilia.SelectedIndexChanged
        Try

            SuperFamilia = CmbSuperFamilia.SelectedValue.ToString

            Familia = ""
            SubFamilia = ""

            CmbFamilia.DataSource = Nothing
            CmbSubFamilia.DataSource = Nothing

            caract_combo(CmbFamilia)
            Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                           "SELECT KOPF AS Padre,NOKOPF AS Hijo FROM TABPF WHERE KOFM = '" & SuperFamilia & "'"
            CmbFamilia.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

            CmbFamilia.SelectedValue = Familia

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbFamilia_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbFamilia.SelectedIndexChanged
        Try
            Familia = CmbFamilia.SelectedValue.ToString
        Catch ex As Exception

        Finally

            SubFamilia = ""
            CmbSubFamilia.DataSource = Nothing

            caract_combo(CmbSubFamilia)
            Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                           "SELECT KOHF AS Padre, NOKOHF AS Hijo FROM TABHF WHERE KOFM = '" & SuperFamilia & "' AND KOPF = '" & Familia & "'"
            CmbSubFamilia.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
            CmbSubFamilia.SelectedValue = SubFamilia

        End Try
    End Sub

    Private Sub CmbSubFamilia_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbSubFamilia.SelectedIndexChanged
        Try
            SubFamilia = CmbSubFamilia.SelectedValue.ToString
        Catch ex As Exception
            SubFamilia = String.Empty
        End Try
    End Sub

    Private Sub BtnFamilias_Click(sender As System.Object, e As System.EventArgs) Handles BtnFamilias.Click
        If Fx_Tiene_Permiso(Me, "Tbl00001") Then

            Dim Fm As New Frm_Familias_Lista(Frm_Familias_Lista.Enum_Tipo_Vista_Familias.Super_Familias)
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Dim Spfm = SuperFamilia
            Dim Fmfm = Familia
            Dim Subf = SubFamilia

            caract_combo(CmbSuperFamilia)
            Consulta_sql = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                           "SELECT KOFM AS Padre,NOKOFM AS Hijo FROM TABFM ORDER BY Hijo"
            CmbSuperFamilia.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
            CmbSuperFamilia.SelectedValue = Spfm
            CmbFamilia.SelectedValue = Fmfm
            CmbSubFamilia.SelectedValue = Subf

        End If
    End Sub

    Private Sub Cmbmarcas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Try
            Marca = Cmb_Mrpr.SelectedValue.ToString
        Catch ex As Exception
            Marca = String.Empty
        End Try
    End Sub

    Private Sub Cmbrubros_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Rubro = Cmb_Rupr.SelectedValue.ToString
    End Sub

    Private Sub Cmbclalibpr_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        ClasifLibre = Cmb_Clalibpr.SelectedValue.ToString
    End Sub

    Private Sub CmbJefeProducto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        JefePro = Cmb_Kofupr.SelectedValue.ToString
    End Sub

    Private Sub CmbZonaProducto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        ZonaPro = Cmb_Zonapr.SelectedValue.ToString
    End Sub

    Private Sub Cmblista_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Try
            ListaCostoPro = Cmb_Codlista.SelectedValue.ToString
        Catch ex As Exception
            ListaCostoPro = ""
        End Try
    End Sub

    'Private Sub BtnCodAlternativo_Click(sender As System.Object, e As System.EventArgs)
    '    Dim Fr As New Frm_CreaProductos_04_CodAlternativo(Txt_Kopr.Text)
    '    Fr.BtnBuscarEntidad.Enabled = False
    '    Fr.ShowDialog(Me)
    '    Fr.Dispose()
    'End Sub

    Private Sub BtnMantPrecios_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mant_Precios.Click
        Fx_Ingresar_Precio_Nuevo_Producto(_RowProducto)
    End Sub

    Function Fx_Ingresar_Cod_Alternativo(_RowProducto As DataRow) As Boolean

        If Fx_Tiene_Permiso(Me, "Prod020") Then

            Dim Fm As New Frm_CodAlternativo_Ver
            Fm.TxtCodigo.Text = _RowProducto.Item("KOPR")
            Fm.Txtdescripcion.Text = _RowProducto.Item("NOKOPR")
            Fm.TxtRTU.Text = _RowProducto.Item("RLUD")
            Fm.ShowDialog(Me)

            Dim _Reg As Boolean = _Sql.Fx_Cuenta_Registros("TABCODAL", "KOPR = '" & _RowProducto.Item("KOPR") & "'")

            Return _Reg

        End If

    End Function
    Function Fx_Ingresar_Precio_Nuevo_Producto(_RowProducto As DataRow) As Boolean

        Dim _Grabacion_Realizada As Boolean

        If Fx_Tiene_Permiso(Me, "Pre0012") Then

            Dim _Tbl_Listas_Seleccionadas As DataTable

            Dim Fm As New Frm_SeleccionarListaPrecios(Frm_SeleccionarListaPrecios.Enum_Tipo_Lista.Precio, True, False)
            Fm.ShowDialog(Me)
            _Tbl_Listas_Seleccionadas = Fm.Pro_Tbl_Listas_Seleccionadas
            Fm.Dispose()

            If Not (_Tbl_Listas_Seleccionadas Is Nothing) Then

                Dim Fm_P As New Frm_MantLista_Precios_Random(_Tbl_Listas_Seleccionadas, _RowProducto, True)
                Fm_P.ShowDialog(Me)
                _Grabacion_Realizada = Fm_P.Pro_Grabacion_Realizada
                Fm_P.Dispose()

            End If
        End If

        Return _Grabacion_Realizada

    End Function

    Function Fx_Ingresar_Descripcion_por_Arbol_de_clasificacion(_RowProducto As DataRow) As Boolean

        If Fx_Tiene_Permiso(Me, "Prod009") Then

            Dim FrmBa As New Frm_MtCreaProd_01_IngBusqEspecial
            With FrmBa
                .TxtCodigo.Text = _RowProducto.Item("KOPR")
                .TxtDescripcion.Text = _RowProducto.Item("NOKOPR")
                .ShowDialog(Me)
            End With

            Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Asociacion",
                                                                 "Codigo = '" & _RowProducto.Item("KOPR") & "' And Producto = 0"))
            Return _Reg

        End If

    End Function

    Function Fx_Ingresar_Descripcion_por_Arbol_de_clasificacion(_RowProducto As DataRow, _Permiso As String) As Boolean

        Dim _Codigo As String = _RowProducto.Item("KOPR")

        If Fx_Tiene_Permiso(Me, _Permiso) Then

            Dim FrmBa As New Frm_MtCreaProd_01_IngBusqEspecial
            With FrmBa
                .TxtCodigo.Text = _RowProducto.Item("KOPR")
                .TxtDescripcion.Text = _RowProducto.Item("NOKOPR")
                .ShowDialog(Me)
            End With

        End If

    End Function

    Private Sub BtnAsociaciones_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Asociaciones.Click
        If Fx_Tiene_Permiso(Me, "Tbl00002") Then
            Dim Fm As New Frm_MtCreaProd_01_IngBusqEspecial
            Fm.TxtCodigo.Text = Txt_Kopr.Text
            Fm.TxtDescripcion.Text = _Sql.Fx_Trae_Dato("MAEPR", "NOKOPR", "KOPR = '" & Txt_Kopr.Text & "'")
            Fm.ShowDialog(Me)
            Txt_Nokopr.Text = Fm.TxtDescripcion.Text
            Fm.Dispose()
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Sb_Txt_Numerico_Validated(sender As Object, e As EventArgs)
        Dim _Txt = CType(sender, TextBox)
        _Txt.Tag = De_Txt_a_Num_01(_Txt.Text, 5)
        _Txt.Text = FormatNumber(_Txt.Tag, 5)
    End Sub

    Private Sub Btn_Ficha_Click(sender As Object, e As EventArgs) Handles Btn_Ficha.Click

        Dim Fm As New Frm_Archivo_TXT
        Fm.Text = "FICHA TECNICA DEL PRODUCTO"
        Fm.Pro_Grabar_En_Archivo = False
        Fm.Txt_Texto.MaxLength = 80 * 20
        Fm.Pro_Texto_Log = _Cl_Producto.Ficha 'NuloPorNro(_Cl_Producto.Pro_Maeficha.Rows(0).Item("FICHA"), "")
        Fm.Ancho = 800
        Fm.Alto = 280
        Fm.ShowDialog(Me)
        If Fm.Pro_Grabar Then
            Try
                _Cl_Producto.Ficha = Fm.Pro_Texto_Log.ToString.Trim
            Catch ex As Exception
                _Cl_Producto.Ficha = String.Empty
            End Try
        End If
        Fm.Dispose()

    End Sub

    Private Sub Btn_Dimensiones_Click(sender As Object, e As EventArgs) Handles Btn_Dimensiones.Click

        If _Cl_Producto.Pro_Accion = Cl_Producto.Enum_Accion.Editar Then
            If Not Fx_Tiene_Permiso(Me, "Prod014") Then
                Return
            End If
        End If

        Dim Fm As New Frm_Dimensiones_Pr(Txt_Kopr.Text, False)
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            Txt_Alto.Text = Fm.Txt_Alto.Text
            Txt_Ancho.Text = Fm.Txt_Ancho.Text
            Txt_Largo.Text = Fm.Txt_Largo.Text
            Txt_Pesoubic.Text = Fm.Txt_Peso.Text
        End If
        Fm.Dispose()

    End Sub

    Sub Sb_Cargar_Producto_Traer_Datos_Al_Formulario()

        _RowProducto = _Cl_Producto.Pro_Maepr.Rows(0)

        Txt_Kopr.Text = _RowProducto.Item("KOPR")
        Txt_Koprte.Text = NuloPorNro(_RowProducto.Item("KOPRTE"), "")
        Txt_Koprra.Text = _RowProducto.Item("KOPRRA")

        Txt_Nokopr.Text = NuloPorNro(_RowProducto.Item("NOKOPR"), "")
        Txt_Nokoprra.Text = NuloPorNro(_RowProducto.Item("NOKOPRRA"), "") 'Mid(_RowProducto.Item("NOKOPR"), 1, 20)

        Cmb_Tipr.SelectedValue = _RowProducto.Item("TIPR")
        Txt_Ud01pr.Text = NuloPorNro(_RowProducto.Item("UD01PR"), "UN")
        Txt_Ud02pr.Text = NuloPorNro(_RowProducto.Item("UD02PR"), "UN")

        Txt_Rlud.Tag = NuloPorNro(_RowProducto.Item("RLUD"), 1)
        Txt_Rlud.Text = NuloPorNro(_RowProducto.Item("RLUD"), 1)

        Cmb_Bloqueapr.SelectedValue = NuloPorNro(_RowProducto.Item("BLOQUEAPR"), "")
        Input_Poivpr.Value = _RowProducto.Item("POIVPR")
        Input_Podeivpr.Value = _RowProducto.Item("PODEIVPR")
        Cmb_Rgpr.SelectedValue = NuloPorNro(_RowProducto.Item("RGPR"), "N")
        Cmb_Codlista.SelectedValue = _RowProducto.Item("LISCOSTO")

        Dim _Mrpr = Trim(NuloPorNro(_RowProducto.Item("MRPR"), ""))
        Cmb_Mrpr.SelectedValue = _Mrpr 'NuloPorNro(_Mrpr, "")

        Cmb_Rupr.SelectedValue = NuloPorNro(_RowProducto.Item("RUPR"), "")
        Cmb_Clalibpr.SelectedValue = NuloPorNro(_RowProducto.Item("CLALIBPR"), "")

        CmbSuperFamilia.SelectedValue = NuloPorNro(_RowProducto.Item("FMPR"), "")
        CmbFamilia.SelectedValue = NuloPorNro(_RowProducto.Item("PFPR"), "")
        CmbSubFamilia.SelectedValue = NuloPorNro(_RowProducto.Item("HFPR"), "")

        Cmb_Kofupr.SelectedValue = NuloPorNro(_RowProducto.Item("KOFUPR"), "")
        Cmb_Zonapr.SelectedValue = NuloPorNro(_RowProducto.Item("ZONAPR"), "")

        Txt_Pesoubic.Text = NuloPorNro(_RowProducto.Item("PESOUBIC"), 0)
        Txt_Ltsubic.Text = NuloPorNro(_RowProducto.Item("LTSUBIC"), 0)

        Txt_Tolelote.Text = NuloPorNro(_RowProducto.Item("TOLELOTE"), 0)
        Txt_Vidamedia.Text = NuloPorNro(_RowProducto.Item("VIDAMEDIA"), 0)

        Dim _Existe As Boolean

        If _Sql.Fx_Exite_Campo("MAEPR", "ALTO") And _Sql.Fx_Exite_Campo("MAEPR", "LARGO") And _Sql.Fx_Exite_Campo("MAEPR", "ANCHO") Then
            _Existe = True
        End If

        Txt_Mensaje01.Text = String.Empty
        Txt_Mensaje02.Text = String.Empty
        Txt_Mensaje03.Text = String.Empty

        If CBool(_Cl_Producto.Pro_Maeprobs.Rows.Count) Then
            Txt_Mensaje01.Text = _Cl_Producto.Pro_Maeprobs.Rows(0).Item("MENSAJE01")
            Txt_Mensaje02.Text = _Cl_Producto.Pro_Maeprobs.Rows(0).Item("MENSAJE02")
            Txt_Mensaje03.Text = _Cl_Producto.Pro_Maeprobs.Rows(0).Item("MENSAJE03")
        End If

        If _Existe Then

            If CBool(_Cl_Producto.Pro_Maeprobs.Rows.Count) Then
                Txt_Alto.Text = NuloPorNro(_Cl_Producto.Pro_Maeprobs.Rows(0).Item("ALTO"), 0)
                Txt_Largo.Text = NuloPorNro(_Cl_Producto.Pro_Maeprobs.Rows(0).Item("LARGO"), 0)
                Txt_Ancho.Text = NuloPorNro(_Cl_Producto.Pro_Maeprobs.Rows(0).Item("ANCHO"), 0)
            End If

        Else

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Prod_Dimensiones Where Codigo = '" & _RowProducto.Item("KOPR") & "'"
            Dim _Row_dimensiones As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_dimensiones) Then
                Txt_Pesoubic.Text = De_Num_a_Tx_01(NuloPorNro(_Row_dimensiones.Item("Peso"), 0))
                Txt_Alto.Text = De_Num_a_Tx_01(NuloPorNro(_Row_dimensiones.Item("Alto"), 0))
                Txt_Largo.Text = De_Num_a_Tx_01(NuloPorNro(_Row_dimensiones.Item("Largo"), 0))
                Txt_Ancho.Text = De_Num_a_Tx_01(NuloPorNro(_Row_dimensiones.Item("Ancho"), 0))
            End If

        End If

        Chk_Conubic.Checked = NuloPorNro(_RowProducto.Item("CONUBIC"), False)
        Chk_Esactfi.Checked = NuloPorNro(_RowProducto.Item("ESACTFI"), False)
        Chk_Lotecaja.Checked = NuloPorNro(_RowProducto.Item("LOTECAJA"), False)
        Chk_Movetiq.Checked = NuloPorNro(_RowProducto.Item("MOVETIQ"), False)
        Chk_Prrg.Checked = NuloPorNro(_RowProducto.Item("PRRG"), False)
        Chk_Stockaseg.Checked = NuloPorNro(_RowProducto.Item("STOCKASEG"), False)
        Chk_Tratalote.Checked = NuloPorNro(_RowProducto.Item("TRATALOTE"), False)
        Chk_Tratvmedia.Checked = NuloPorNro(_RowProducto.Item("TRATVMEDIA"), False)
        Chk_Exento.Checked = NuloPorNro(_RowProducto.Item("EXENTO"), False)

        Dim _Divisible As String = NuloPorNro(_RowProducto.Item("DIVISIBLE"), "0")
        Dim _Divisible2 As String = NuloPorNro(_RowProducto.Item("DIVISIBLE2"), "0")

        If _Divisible = "N" Or _Divisible = "1" Then
            Chk_Divisible.Checked = True
        End If

        If _Divisible2 = "N" Or _Divisible2 = "1" Then
            Chk_Divisible2.Checked = True
        End If

        Txt_Nodim1.Text = NuloPorNro(_RowProducto.Item("NODIM1"), "")
        Txt_Nodim2.Text = NuloPorNro(_RowProducto.Item("NODIM2"), "")
        Txt_Nodim3.Text = NuloPorNro(_RowProducto.Item("NODIM3"), "")

        Dim _Koprdim As String = NuloPorNro(_RowProducto.Item("KOPRDIM"), "")

        Btn_Dim_01.Text = Mid(_Koprdim, 1, 1)
        Btn_Dim_02.Text = Mid(_Koprdim, 2, 1)
        Btn_Dim_03.Text = Mid(_Koprdim, 3, 1)
        Btn_Dim_04.Text = Mid(_Koprdim, 4, 1)
        Btn_Dim_05.Text = Mid(_Koprdim, 5, 1)
        Btn_Dim_06.Text = Mid(_Koprdim, 6, 1)
        Btn_Dim_07.Text = Mid(_Koprdim, 7, 1)
        Btn_Dim_08.Text = Mid(_Koprdim, 8, 1)
        Btn_Dim_09.Text = Mid(_Koprdim, 9, 1)
        Btn_Dim_10.Text = Mid(_Koprdim, 10, 1)
        Btn_Dim_11.Text = Mid(_Koprdim, 11, 1)
        Btn_Dim_12.Text = Mid(_Koprdim, 12, 1)
        Btn_Dim_13.Text = Mid(_Koprdim, 13, 1)

        Cmb_Funclote.SelectedValue = NuloPorNro(_RowProducto.Item("FUNCLOTE").ToString.Trim, "")

        Chk_Cambiosuj.Checked = NuloPorNro(_RowProducto.Item("CAMBIOSUJ"), False)
        Txt_Nokopramp.Text = NuloPorNro(_RowProducto.Item("NOKOPRAMP"), "")

        Dim _Nmarca = NuloPorNro(_RowProducto.Item("NMARCA").ToString.Trim, "")

        _NNmarca = _Cl_CompUdMedidas.Fx_Decifra_Nmarca(_Nmarca)

        Cmb_Nmarca_Tratamiento.SelectedValue = CInt(_NNmarca.Tratamiento)
        Cmb_Nmarca_Comportamiento.SelectedValue = CInt(_NNmarca.Comportamiento)

        GrillaEmpresa.DataSource = _Cl_Producto.Pro_Tbl_Empresas
        GrillaBodegas.DataSource = _Cl_Producto.Pro_Tbl_Bodegas
        GrillaListaDePrecios.DataSource = _Cl_Producto.Pro_Tbl_Listas
        GrillaImpuestos.DataSource = _Cl_Producto.Pro_Tbl_Impuestos

        Sb_Actualizar_Grilla(GrillaEmpresa)
        Sb_Actualizar_Grilla(GrillaBodegas)
        Sb_Actualizar_Grilla(GrillaListaDePrecios)


        With GrillaImpuestos

            Dim _DisplayIndex = 0

            OcultarEncabezadoGrilla(GrillaImpuestos, True)

            .Columns("Select").HeaderText = "Sel."
            .Columns("Select").Width = 50
            .Columns("Select").ReadOnly = False
            .Columns("Select").Visible = True
            .Columns("Select").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Width = 100
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Width = 300
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            Dim _Exite As Boolean = _Sql.Fx_Exite_Campo("TABIMPR", "NOAPLICEN")

            .Columns("Compras").HeaderText = "Compras"
            .Columns("Compras").Width = 50
            .Columns("Compras").DisplayIndex = _DisplayIndex
            .Columns("Compras").Visible = _Exite
            _DisplayIndex += 1

            .Columns("Ventas").HeaderText = "Ventas"
            .Columns("Ventas").Width = 50
            .Columns("Ventas").DisplayIndex = _DisplayIndex
            .Columns("Ventas").Visible = _Exite
            _DisplayIndex += 1

            .Columns("Stock").HeaderText = "Stock"
            .Columns("Stock").Width = 50
            .Columns("Stock").DisplayIndex = _DisplayIndex
            .Columns("Stock").Visible = _Exite
            _DisplayIndex += 1

            .Columns("Boleta").HeaderText = "Boleta"
            .Columns("Boleta").Width = 50
            .Columns("Boleta").DisplayIndex = _DisplayIndex
            .Columns("Boleta").Visible = _Exite
            _DisplayIndex += 1

            .Columns("POIM").HeaderText = "%"
            .Columns("POIM").Width = 40
            .Columns("POIM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("POIM").Visible = True
            .Columns("POIM").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("MEIM").HeaderText = "Ecuación"
            .Columns("MEIM").Width = 150
            .Columns("MEIM").Visible = True
            .Columns("MEIM").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Chk_Tratalote_CheckedChanged(sender As Object, e As EventArgs)
        If Chk_Tratalote.Checked Then
            Chk_Lotecaja.Checked = False
        End If
    End Sub

    Private Sub Chk_Lotecaja_CheckedChanged(sender As Object, e As EventArgs)
        If Chk_Lotecaja.Checked Then
            Chk_Tratalote.Checked = False
        End If
    End Sub

    Private Sub GrillaImpuestos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaImpuestos.CellEndEdit

        Dim _Fila As DataGridViewRow = GrillaImpuestos.CurrentRow
        Dim _Cabeza = GrillaImpuestos.Columns(GrillaImpuestos.CurrentCell.ColumnIndex).Name

        If _Cabeza = "Select" Then
            If _Fila.Cells("Select").Value Then
                _Fila.Cells("Compras").Value = "Si"
                _Fila.Cells("Ventas").Value = "Si"
                _Fila.Cells("Stock").Value = "Si"
                _Fila.Cells("Boleta").Value = "Si"
            Else
                _Fila.Cells("Compras").Value = String.Empty
                _Fila.Cells("Ventas").Value = String.Empty
                _Fila.Cells("Stock").Value = String.Empty
                _Fila.Cells("Boleta").Value = String.Empty
            End If
        End If

    End Sub

    Private Sub GrillaImpuestos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaImpuestos.CellDoubleClick

        Dim _Fila As DataGridViewRow = GrillaImpuestos.CurrentRow
        Dim _Cabeza = GrillaImpuestos.Columns(GrillaImpuestos.CurrentCell.ColumnIndex).Name

        If _Cabeza = "Compras" Or _Cabeza = "Ventas" Or _Cabeza = "Stock" Or _Cabeza = "Boleta" Then
            If _Fila.Cells(_Cabeza).Value = "Si" Then
                _Fila.Cells(_Cabeza).Value = "No"
            Else
                _Fila.Cells(_Cabeza).Value = "Si"
            End If
        End If

    End Sub

    Private Sub GrillaImpuestos_MouseUp(sender As Object, e As MouseEventArgs) Handles GrillaImpuestos.MouseUp
        GrillaImpuestos.EndEdit()
    End Sub

    Private Sub Btn_Dim_Click(sender As Object, e As EventArgs)

        Dim _Valor As String

        If Rdb_Raiz.Checked Then _Valor = "R"
        If Rdb_1raDimension.Checked Then _Valor = "1"
        If Rdb_2daDimension.Checked Then _Valor = "2"
        If Rdb_3raDimension.Checked Then _Valor = "3"

        sender.Text = _Valor

    End Sub

    Private Sub STab_Dimensiones_Click(sender As Object, e As EventArgs) Handles STab_Dimensiones.Click

        Btn_01.Text = Mid(Txt_Kopr.Text, 1, 1)
        Btn_02.Text = Mid(Txt_Kopr.Text, 2, 1)
        Btn_03.Text = Mid(Txt_Kopr.Text, 3, 1)
        Btn_04.Text = Mid(Txt_Kopr.Text, 4, 1)
        Btn_05.Text = Mid(Txt_Kopr.Text, 5, 1)
        Btn_06.Text = Mid(Txt_Kopr.Text, 6, 1)
        Btn_07.Text = Mid(Txt_Kopr.Text, 7, 1)
        Btn_08.Text = Mid(Txt_Kopr.Text, 8, 1)
        Btn_09.Text = Mid(Txt_Kopr.Text, 9, 1)
        Btn_10.Text = Mid(Txt_Kopr.Text, 10, 1)
        Btn_11.Text = Mid(Txt_Kopr.Text, 11, 1)
        Btn_12.Text = Mid(Txt_Kopr.Text, 12, 1)
        Btn_13.Text = Mid(Txt_Kopr.Text, 13, 1)

        Lbl_Dim_Codigo.Text = Txt_Kopr.Text
        Lbl_Dim_Descripcion.Text = Txt_Nokopr.Text

    End Sub

    Private Sub Txt_Ud02pr_TextChanged(sender As Object, e As EventArgs) Handles Txt_Ud02pr.TextChanged

        Cmb_Nmarca_Comportamiento.Enabled = (Txt_Ud01pr.Text <> Txt_Ud02pr.Text)
        Cmb_Nmarca_Tratamiento.Enabled = (Txt_Ud01pr.Text <> Txt_Ud02pr.Text)

    End Sub

    Private Sub Txt_Ud01pr_TextChanged(sender As Object, e As EventArgs) Handles Txt_Ud01pr.TextChanged

        Cmb_Nmarca_Comportamiento.Enabled = (Txt_Ud01pr.Text <> Txt_Ud02pr.Text)
        Cmb_Nmarca_Tratamiento.Enabled = (Txt_Ud01pr.Text <> Txt_Ud02pr.Text)

    End Sub

    Private Sub BtnCodAlternativosProducto_Click(sender As System.Object, e As System.EventArgs) Handles BtnCodAlternativosProducto.Click
        If Fx_Tiene_Permiso(Me, "Prod020") Then
            Dim Fm As New Frm_CodAlternativo_Ver
            Fm.TxtCodigo.Text = _RowProducto.Item("KOPR")
            Fm.Txtdescripcion.Text = _RowProducto.Item("NOKOPR")
            Fm.TxtRTU.Text = _RowProducto.Item("RLUD")
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Marcas_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Marcas.Click
        If Fx_Tiene_Permiso(Me, "Tbl00016") Then

            Dim _Marca = Trim(Cmb_Mrpr.SelectedValue)
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Marcas,
                                                                 Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "MARCAS"
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Consulta_sql = Union & "SELECT KOMR AS Padre,NOKOMR AS Hijo FROM TABMR ORDER BY Hijo" ' WHERE SEMILLA = " & Actividad
            Cmb_Mrpr.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
            Cmb_Mrpr.SelectedValue = _Marca
        End If
    End Sub

    Private Sub Btn_Rubro_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Rubro.Click
        If Fx_Tiene_Permiso(Me, "Tbl00017") Then

            Dim _Rubro = Cmb_Rupr.SelectedValue
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Rubros,
                                                                 Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "RUBROS"
            Fm.ShowDialog(Me)
            Fm.Dispose()

            caract_combo(Cmb_Rupr)
            Consulta_sql = Union & "SELECT KORU AS Padre,NOKORU AS Hijo FROM TABRU ORDER BY Hijo" ' WHERE SEMILLA = " & Actividad
            Cmb_Rupr.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
            Cmb_Rupr.SelectedValue = _Rubro
        End If
    End Sub

    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX2.Click
        If Fx_Tiene_Permiso(Me, "Tbl00020") Then

            Dim _ClasifLibre = Cmb_Clalibpr.SelectedValue
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Claslibre,
                                                                  Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "CLASIFICACION LIBRE"
            Fm.ShowDialog(Me)
            Fm.Dispose()

            caract_combo(Cmb_Clalibpr)
            Consulta_sql = Union & "SELECT KOCARAC AS Padre,LTRIM(RTRIM(KOCARAC))+'-'+LTRIM(RTRIM(NOKOCARAC)) AS Hijo FROM TABCARAC WHERE KOTABLA = 'CLALIBPR' ORDER BY Hijo"
            Cmb_Clalibpr.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
            Cmb_Clalibpr.SelectedValue = _ClasifLibre
        End If
    End Sub

    Private Sub Btn_Zonas_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Zonas.Click

        'MessageBoxEx.Show(Me, "En desarrollo")
        'Return
        If Fx_Tiene_Permiso(Me, "Tbl00018") Then
            Dim _ZonaPro = Cmb_Zonapr.SelectedValue

            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.ZonaProducto,
                                                                  Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "ZONA PRODUCTO"
            Fm.ShowDialog(Me)
            Fm.Dispose()

            caract_combo(Cmb_Zonapr)
            Consulta_sql = Union & "SELECT KOCARAC AS Padre,LTRIM(RTRIM(KOCARAC))+'-'+LTRIM(RTRIM(NOKOCARAC)) AS Hijo FROM TABCARAC WHERE KOTABLA = 'ZONAPRODUC' ORDER BY Hijo"
            Cmb_Zonapr.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
            Cmb_Zonapr.SelectedValue = ZonaPro

        End If
    End Sub

    Private Sub Btn_TablaClasificaciones_Click(sender As System.Object, e As System.EventArgs) Handles Btn_TablaClasificaciones.Click
        If Fx_Tiene_Permiso(Me, "Tbl00002") Then
            Dim Fm As New Frm_Arbol_Asociacion_02(False, 0, False, Frm_Arbol_Asociacion_02.Enum_Clasificacion.Dinamica, 0)
            Fm.Pro_Identificador_NodoPadre = 0
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Imagenes_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Imagenes.Click

        Dim Fm As New Frm_Imagenes_X_Producto(Txt_Kopr.Text)

        If Fm.Fx_Llenar_Grilla_Imagenes Then
            Fm.ShowDialog(Me)
        Else
            MessageBoxEx.Show(Me, "No existen imagenes para el producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Fm.Dispose()

    End Sub

    Function Fx_ValidarExistenciaDeCodigo(Codigo As String,
                                       Campo As String,
                                       Optional MostrarMensaje As Boolean = True)
        If _Sql.Fx_Trae_Dato("MAEPR", Campo, Campo & " = '" & Codigo & "'") <> "" Then

            If MostrarMensaje = True Then
                MessageBoxEx.Show(Me, "¡Código de producto ya existe!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            Return True
        Else
            Return False
        End If
    End Function

    Function Fx_ValidarExistenciaDeCodigoAlternativo(Codigo As String)
        If _Sql.Fx_Trae_Dato("TABCODAL", "KOPR", "KOPRAL = '" & Codigo.Trim & "'") <> "" Then
            MessageBoxEx.Show(Me, "¡Código ya esta creado como alternativo!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
        Return True
    End Function

    Function Fx_Eliminar_Producto(_Codigo_a_eliminar As String,
                                  _Descripcion As String,
                                  _Preguntar As Boolean)
        If _Preguntar Then
            If Not Fx_Tiene_Permiso(Me, "Prod015") Then
                Return False
            End If
        End If

        Dim _Maeddo As Long = _Sql.Fx_Cuenta_Registros("MAEDDO", "KOPRCT = '" & _Codigo_a_eliminar & "'") ' SELECT TOP 1 * FROM MAEDDO WITH ( NOLOCK )  WHERE KOPRCT='PRODUCTO DE P'
        Dim _Tabcodal As Long = _Sql.Fx_Cuenta_Registros("TABCODAL", "KOPR = '" & _Codigo_a_eliminar & "'") 'SELECT TOP 1 * FROM TABCODAL WITH ( NOLOCK )  WHERE KOPR='PRODUCTO DE P'
        Dim _Potd As Long = _Sql.Fx_Cuenta_Registros("POTD", "CODIGO = '" & _Codigo_a_eliminar & "'")        'SELECT TOP 1 * FROM POTD WITH ( NOLOCK )  WHERE CODIGO='PRODUCTO DE P'
        Dim _Kasiddo As Long = _Sql.Fx_Cuenta_Registros("KASIDDO", "KOPRCT = '" & _Codigo_a_eliminar & "'") 'SELECT TOP 1 * FROM KASIDDO WITH ( NOLOCK )  WHERE KOPRCT='PRODUCTO DE P'


        If CBool(_Maeddo) Then
            MessageBoxEx.Show(Me, "Producto está  presente en documentos de Gestión", "PRODUCTO NO PUEDE SER ELIMINADO",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        If CBool(_Potd) Then
            MessageBoxEx.Show(Me, "Producto está  presente en documentos de Producción", "PRODUCTO NO PUEDE SER ELIMINADO",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        If CBool(_Kasiddo) Then
            MessageBoxEx.Show(Me, "Producto está presente en documentos de Gestión (Documentos reciclados)", "PRODUCTO NO PUEDE SER ELIMINADO",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If


        If CBool(_Tabcodal) Then
            If MessageBoxEx.Show(Me, "Este producto tiene códigos alternativos asociados" & vbCrLf &
                                "¿Desea continuar con la eliminación?", "PRODUCTO NO PUEDE SER ELIMINADO",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                Return False
            End If
        End If

        Dim _Eliminar = True

        If _Preguntar Then
            If MessageBoxEx.Show(Me, "¿Está seguro de eliminar este producto?" & vbCrLf & Trim(_Codigo_a_eliminar) & " - " & Trim(_Descripcion),
                                 "Eliminar producto",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                _Eliminar = False
            End If
        End If

        If _Eliminar Then

            Consulta_sql = "DELETE " & _Global_BaseBk & "Zw_ListaPreCosto WHERE (Codigo = '') AND (CodAlternativo = '')"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "DELETE PDIMEN    WHERE CODIGO ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE MAEPROBS  WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE MAEFICHA  WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE MAEFICHD  WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE TABIMPR   WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE TABPRE    WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE TABBOPR   WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE MPROENVA  WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE MAEPREM   WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE MAEPR     WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE TABCODAL  WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE " & _Global_BaseBk & "Zw_ListaPreCosto WHERE Codigo ='" & _Codigo_a_eliminar & "' And Proveedor = ''" & vbCrLf &
                               "DELETE " & _Global_BaseBk & "Zw_ListaPreProducto WHERE Codigo ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE " & _Global_BaseBk & "Zw_Prod_Asociacion WHERE Codigo ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "UPDATE " & _Global_BaseBk & "Zw_ListaPreCosto Set Codigo = '', Descripcion = ''" & Space(1) &
                               "WHERE  Codigo = '" & _Codigo_a_eliminar & "' AND Proveedor <> ''" & vbCrLf &
                               "DELETE " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo = '" & _Codigo_a_eliminar & "' And Producto = 1" & vbCrLf &
                               "DELETE " & _Global_BaseBk & "Zw_Prod_Dimensiones Where Codigo = '" & _Codigo_a_eliminar & "'"

            Return _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        End If

    End Function

    Function Fx_ExisteProductoEnOtraBase(_Codigo As String) As String

        Dim _MsgExiste As String = String.Empty

        If _Global_Row_Configuracion_General.Item("PermitirMigrarProductosBaseExterna") Then

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Conexion Where GrbProd_Nuevos = 1"
            Dim _Tbl_Conexiones As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            For Each _FilaCx As DataRow In _Tbl_Conexiones.Rows

                Dim _Id_Conexion As Integer = _FilaCx.Item("Id")
                Dim _BaseDeDatos As String = _FilaCx.Item("BaseDeDatos")
                Dim _Cl_Migrar_Producto As New Bk_Migrar_Producto.Cl_Migrar_Producto(_Id_Conexion)

                If _Cl_Migrar_Producto.SePuedeMigrar Then

                    Dim _GrbProd_Nuevos = _Cl_Migrar_Producto.Row_DnExt.Item("GrbProd_Nuevos")
                    Dim _GrbEnti_Nuevas = _Cl_Migrar_Producto.Row_DnExt.Item("GrbEnti_Nuevas")
                    Dim _GrbProd_Bodegas = _Cl_Migrar_Producto.Row_DnExt.Item("GrbProd_Bodegas")
                    Dim _GrbProd_Listas = _Cl_Migrar_Producto.Row_DnExt.Item("GrbProd_Listas")

                    Dim _ExisteMaepr As Boolean = _Cl_Migrar_Producto.Fx_ExisteProductoEnMAEPR(_Codigo)
                    Dim _ExisteTabcodal As Boolean = _Cl_Migrar_Producto.Fx_ExisteProductoEnTABCODAL(_Codigo)

                    If _ExisteMaepr Then _MsgExiste = " - Existe producto en MAEPR (BD: " & _BaseDeDatos & ")" & vbCrLf
                    If _ExisteTabcodal Then _MsgExiste = " - Existe producto en TABCODAL (BD: " & _BaseDeDatos & ")"

                Else
                    'MessageBoxEx.Show(Me, "No fue posible crear el producto en base de datos externa" & vbCrLf & vbCrLf &
                    '                  "Base de datos: " & _BaseDeDatos & vbCrLf & vbCrLf &
                    '                  _Cl_Migrar_Producto.ProError, "Crear producto en base externa",
                    '                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Next

        End If

        Return _MsgExiste

    End Function


    Function Fx_ExisteRegistroEnTablaDeOtraBase() As String

        Dim _MsgExiste As String = String.Empty

        If _Global_Row_Configuracion_General.Item("PermitirMigrarProductosBaseExterna") Then

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Conexion Where GrbProd_Nuevos = 1"
            Dim _Tbl_Conexiones As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            For Each _FilaCx As DataRow In _Tbl_Conexiones.Rows

                Dim _Id_Conexion As Integer = _FilaCx.Item("Id")
                Dim _BaseDeDatos As String = _FilaCx.Item("BaseDeDatos")
                Dim _Cl_Migrar_Producto As New Bk_Migrar_Producto.Cl_Migrar_Producto(_Id_Conexion)

                If _Cl_Migrar_Producto.SePuedeMigrar Then

                    Dim _SincroMarcas As Boolean = _Cl_Migrar_Producto.Row_DnExt.Item("SincroMarcas")
                    Dim _SincroFamilias As Boolean = _Cl_Migrar_Producto.Row_DnExt.Item("SincroFamilias")
                    Dim _SincroRubros As Boolean = _Cl_Migrar_Producto.Row_DnExt.Item("SincroRubros")
                    Dim _SincroClaslibre As Boolean = _Cl_Migrar_Producto.Row_DnExt.Item("SincroClaslibre")
                    Dim _SincroZonaProducto As Boolean = _Cl_Migrar_Producto.Row_DnExt.Item("SincroZonaProducto")

                    If _SincroMarcas Then
                        If Not String.IsNullOrEmpty(Cmb_Mrpr.SelectedValue) AndAlso Not (_Cl_Migrar_Producto.Fx_ExisteReistroenTabla("TABMR", "KOMR = '" & Cmb_Mrpr.SelectedValue & "'")) Then
                            _MsgExiste += " - No Existe MARCA: " & Cmb_Mrpr.SelectedValue.ToString.Trim & "-" & Cmb_Mrpr.Text & vbCrLf
                        End If
                    End If

                    If _SincroRubros Then
                        If Not String.IsNullOrEmpty(Cmb_Rupr.SelectedValue) AndAlso Not (_Cl_Migrar_Producto.Fx_ExisteReistroenTabla("TABRU", "KORU = '" & Cmb_Rupr.SelectedValue & "'")) Then
                            _MsgExiste += " - No Existe RUBRO: " & Cmb_Rupr.SelectedValue.ToString.Trim & "-" & Cmb_Rupr.Text & vbCrLf
                        End If
                    End If

                    If _SincroClaslibre Then
                        If Not String.IsNullOrEmpty(Cmb_Clalibpr.SelectedValue) AndAlso Not (_Cl_Migrar_Producto.Fx_ExisteReistroenTabla("TABCARAC", "KOTABLA = 'CLALIBPR' And KOCARAC = '" & Cmb_Clalibpr.SelectedValue & "'")) Then
                            _MsgExiste += " - No Existe CLASIFICACION LIBRE: " & Cmb_Clalibpr.SelectedValue.ToString.Trim & "-" & Cmb_Clalibpr.Text & vbCrLf
                        End If
                    End If

                    If _SincroZonaProducto Then
                        If Not String.IsNullOrEmpty(Cmb_Zonapr.SelectedValue) AndAlso Not (_Cl_Migrar_Producto.Fx_ExisteReistroenTabla("TABCARAC", "KOTABLA = 'ZONAPRODUC' And KOCARAC = '" & Cmb_Zonapr.SelectedValue & "'")) Then
                            _MsgExiste += " - No Existe ZONA PRODUCTO: " & Cmb_Zonapr.SelectedValue.ToString.Trim & "-" & Cmb_Zonapr.Text & vbCrLf
                        End If
                    End If

                    If _SincroFamilias Then

                        If Not String.IsNullOrEmpty(CmbSuperFamilia.SelectedValue) AndAlso Not (_Cl_Migrar_Producto.Fx_ExisteReistroenTabla("TABFM", "KOFM = '" & CmbSuperFamilia.SelectedValue & "'")) Then
                            _MsgExiste += " - No Existe SUPER-FAMILIA: " & CmbSuperFamilia.SelectedValue.ToString.Trim & "-" & CmbSuperFamilia.Text & vbCrLf
                        End If

                        If Not String.IsNullOrEmpty(CmbFamilia.SelectedValue) AndAlso Not (_Cl_Migrar_Producto.Fx_ExisteReistroenTabla("TABPF", "KOFM = '" & CmbSuperFamilia.SelectedValue & "' And KOPF = '" & CmbFamilia.SelectedValue & "'")) Then
                            _MsgExiste += " - No Existe FAMILIA: " & CmbSuperFamilia.SelectedValue.ToString.Trim & "-" & CmbFamilia.SelectedValue & "-" & CmbFamilia.Text & vbCrLf
                        End If

                        If Not String.IsNullOrEmpty(CmbSubFamilia.SelectedValue) AndAlso Not (_Cl_Migrar_Producto.Fx_ExisteReistroenTabla("TABHF", "KOFM = '" & CmbSuperFamilia.SelectedValue & "' And KOPF = '" & CmbFamilia.SelectedValue & "' And KOHF = '" & CmbSubFamilia.SelectedValue & "'")) Then
                            _MsgExiste += " - No Existe SUB-FAMILIA: " & CmbSuperFamilia.SelectedValue.ToString.Trim & "-" & CmbFamilia.SelectedValue & "-" & CmbSubFamilia.SelectedValue & "-" & CmbSubFamilia.Text & vbCrLf
                        End If

                    End If

                    If Not String.IsNullOrEmpty(_MsgExiste) Then

                        _MsgExiste = "Debe reparar estas  inconsistencias con la datos externa: " & _BaseDeDatos & vbCrLf & vbCrLf & _MsgExiste

                    End If

                End If

            Next

        End If

        Return _MsgExiste

    End Function


End Class

Namespace Bk_Comporamiento_UdMedidas

    Public Class Cl_CompUdMedidas

        Enum Enum_Comportamiento
            nn
            c01_Solicitar_Ud_Que_Hara_Transaccion
            c02_Comprar_en_1ra_Udad_Vender_1ra_Udad
            c03_Comprar_en_2da_Udad_Vender_1ra_Udad
            c04_Comprar_en_1ra_Udad_Vender_2da_Udad
            c05_Comprar_en_2da_Udad_Vender_2da_Udad
            c06_Solicitar_Udad_si_es_compra_Vender_1ra_Udad
            c07_Solicitar_Udad_si_es_compra_Vender_2da_Udad
            c08_Comrar_en_1ra_Udad_Solicitar_Udad_si_es_venta
            c09_Comrar_en_2da_Udad_Solicitar_Udad_si_es_venta
            c10_Utilizar_unidad_indivisible_solo_RTU_constante
            c11_Vender_en_1ra_Udad_sin_dividir_2da_Udad
        End Enum

        Enum Enum_Tratamientos_RTU
            nn
            c01_Caso_normal_respetar_RTU_definida
            c02_Solicitar_Ancho_Largo_y_Alto_Para_obtener_1ra_Udad
            c03_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_MT2
            c04_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_CM2
            c05_Solicitar_cant_solo_Udad_seleccionada_y_calcular_x_RTU_la_otra_Udad
            c06_Calcular_RTU_forma_invertida
            c07_Solicitar_cantidad_ambas_unidades_del_producto
            c08_Solicitar_RTU_producto
            c09_RTU_variable
            c10_RTU_constante
        End Enum

        Function Fx_Trae_NMARCA(_Comportamiento As Enum_Comportamiento,
                                _Tratamientos_RTU As Enum_Tratamientos_RTU) As String

#Region "c01_Caso_normal_respetar_RTU_definida"

            If _Comportamiento = Enum_Comportamiento.c01_Solicitar_Ud_Que_Hara_Transaccion And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c01_Caso_normal_respetar_RTU_definida Then
                Return ""
            End If

            If _Comportamiento = Enum_Comportamiento.c02_Comprar_en_1ra_Udad_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c01_Caso_normal_respetar_RTU_definida Then
                Return "1"
            End If

            If _Comportamiento = Enum_Comportamiento.c03_Comprar_en_2da_Udad_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c01_Caso_normal_respetar_RTU_definida Then
                Return "2"
            End If

            If _Comportamiento = Enum_Comportamiento.c04_Comprar_en_1ra_Udad_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c01_Caso_normal_respetar_RTU_definida Then
                Return "3"
            End If

            If _Comportamiento = Enum_Comportamiento.c05_Comprar_en_2da_Udad_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c01_Caso_normal_respetar_RTU_definida Then
                Return "4"
            End If

            If _Comportamiento = Enum_Comportamiento.c06_Solicitar_Udad_si_es_compra_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c01_Caso_normal_respetar_RTU_definida Then
                Return "a"
            End If

            If _Comportamiento = Enum_Comportamiento.c07_Solicitar_Udad_si_es_compra_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c01_Caso_normal_respetar_RTU_definida Then
                Return "g"
            End If

            If _Comportamiento = Enum_Comportamiento.c08_Comrar_en_1ra_Udad_Solicitar_Udad_si_es_venta And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c01_Caso_normal_respetar_RTU_definida Then
                Return "m"
            End If

            If _Comportamiento = Enum_Comportamiento.c09_Comrar_en_2da_Udad_Solicitar_Udad_si_es_venta And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c01_Caso_normal_respetar_RTU_definida Then
                Return "s"
            End If

            If _Comportamiento = Enum_Comportamiento.c10_Utilizar_unidad_indivisible_solo_RTU_constante And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c01_Caso_normal_respetar_RTU_definida Then
                Return ""
            End If

#End Region

#Region "c02_Solicitar_Ancho_Largo_y_Alto_Para_obtener_1ra_Udad"

            If _Comportamiento = Enum_Comportamiento.c01_Solicitar_Ud_Que_Hara_Transaccion And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c02_Solicitar_Ancho_Largo_y_Alto_Para_obtener_1ra_Udad Then
                Return "A"
            End If

            If _Comportamiento = Enum_Comportamiento.c02_Comprar_en_1ra_Udad_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c02_Solicitar_Ancho_Largo_y_Alto_Para_obtener_1ra_Udad Then
                Return "5"
            End If

            If _Comportamiento = Enum_Comportamiento.c03_Comprar_en_2da_Udad_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c02_Solicitar_Ancho_Largo_y_Alto_Para_obtener_1ra_Udad Then
                Return "F"
            End If

            If _Comportamiento = Enum_Comportamiento.c04_Comprar_en_1ra_Udad_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c02_Solicitar_Ancho_Largo_y_Alto_Para_obtener_1ra_Udad Then
                Return "K"
            End If

            If _Comportamiento = Enum_Comportamiento.c05_Comprar_en_2da_Udad_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c02_Solicitar_Ancho_Largo_y_Alto_Para_obtener_1ra_Udad Then
                Return "P"
            End If

            If _Comportamiento = Enum_Comportamiento.c06_Solicitar_Udad_si_es_compra_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c02_Solicitar_Ancho_Largo_y_Alto_Para_obtener_1ra_Udad Then
                Return "b"
            End If

            If _Comportamiento = Enum_Comportamiento.c07_Solicitar_Udad_si_es_compra_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c02_Solicitar_Ancho_Largo_y_Alto_Para_obtener_1ra_Udad Then
                Return "h"
            End If

            If _Comportamiento = Enum_Comportamiento.c08_Comrar_en_1ra_Udad_Solicitar_Udad_si_es_venta And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c02_Solicitar_Ancho_Largo_y_Alto_Para_obtener_1ra_Udad Then
                Return "n"
            End If

            If _Comportamiento = Enum_Comportamiento.c09_Comrar_en_2da_Udad_Solicitar_Udad_si_es_venta And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c02_Solicitar_Ancho_Largo_y_Alto_Para_obtener_1ra_Udad Then
                Return "t"
            End If

            If _Comportamiento = Enum_Comportamiento.c10_Utilizar_unidad_indivisible_solo_RTU_constante And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c02_Solicitar_Ancho_Largo_y_Alto_Para_obtener_1ra_Udad Then
                Return ""
            End If

            If _Comportamiento = Enum_Comportamiento.c11_Vender_en_1ra_Udad_sin_dividir_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c02_Solicitar_Ancho_Largo_y_Alto_Para_obtener_1ra_Udad Then
                Return "A"
            End If

#End Region

#Region "c03_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_MT2"

            If _Comportamiento = Enum_Comportamiento.c01_Solicitar_Ud_Que_Hara_Transaccion And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c03_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_MT2 Then
                Return "B"
            End If

            If _Comportamiento = Enum_Comportamiento.c02_Comprar_en_1ra_Udad_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c03_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_MT2 Then
                Return "6"
            End If

            If _Comportamiento = Enum_Comportamiento.c03_Comprar_en_2da_Udad_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c03_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_MT2 Then
                Return "G"
            End If

            If _Comportamiento = Enum_Comportamiento.c04_Comprar_en_1ra_Udad_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c03_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_MT2 Then
                Return "L"
            End If

            If _Comportamiento = Enum_Comportamiento.c05_Comprar_en_2da_Udad_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c03_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_MT2 Then
                Return "Q"
            End If

            If _Comportamiento = Enum_Comportamiento.c06_Solicitar_Udad_si_es_compra_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c03_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_MT2 Then
                Return "c"
            End If

            If _Comportamiento = Enum_Comportamiento.c07_Solicitar_Udad_si_es_compra_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c03_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_MT2 Then
                Return "i"
            End If

            If _Comportamiento = Enum_Comportamiento.c08_Comrar_en_1ra_Udad_Solicitar_Udad_si_es_venta And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c03_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_MT2 Then
                Return "o"
            End If

            If _Comportamiento = Enum_Comportamiento.c09_Comrar_en_2da_Udad_Solicitar_Udad_si_es_venta And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c03_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_MT2 Then
                Return "u"
            End If

            If _Comportamiento = Enum_Comportamiento.c10_Utilizar_unidad_indivisible_solo_RTU_constante And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c03_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_MT2 Then
                Return ""
            End If

            If _Comportamiento = Enum_Comportamiento.c11_Vender_en_1ra_Udad_sin_dividir_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c03_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_MT2 Then
                Return "B"
            End If

#End Region

#Region "c04_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_CM2"

            If _Comportamiento = Enum_Comportamiento.c01_Solicitar_Ud_Que_Hara_Transaccion And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c04_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_CM2 Then
                Return "C"
            End If

            If _Comportamiento = Enum_Comportamiento.c02_Comprar_en_1ra_Udad_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c04_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_CM2 Then
                Return "7"
            End If

            If _Comportamiento = Enum_Comportamiento.c03_Comprar_en_2da_Udad_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c04_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_CM2 Then
                Return "H"
            End If

            If _Comportamiento = Enum_Comportamiento.c04_Comprar_en_1ra_Udad_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c04_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_CM2 Then
                Return "M"
            End If

            If _Comportamiento = Enum_Comportamiento.c05_Comprar_en_2da_Udad_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c04_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_CM2 Then
                Return "R"
            End If

            If _Comportamiento = Enum_Comportamiento.c06_Solicitar_Udad_si_es_compra_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c04_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_CM2 Then
                Return "d"
            End If

            If _Comportamiento = Enum_Comportamiento.c07_Solicitar_Udad_si_es_compra_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c04_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_CM2 Then
                Return "j"
            End If

            If _Comportamiento = Enum_Comportamiento.c08_Comrar_en_1ra_Udad_Solicitar_Udad_si_es_venta And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c04_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_CM2 Then
                Return "p"
            End If

            If _Comportamiento = Enum_Comportamiento.c09_Comrar_en_2da_Udad_Solicitar_Udad_si_es_venta And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c04_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_CM2 Then
                Return "v"
            End If

            If _Comportamiento = Enum_Comportamiento.c10_Utilizar_unidad_indivisible_solo_RTU_constante And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c04_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_CM2 Then
                Return ""
            End If

            If _Comportamiento = Enum_Comportamiento.c11_Vender_en_1ra_Udad_sin_dividir_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c04_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_CM2 Then
                Return "C"
            End If

#End Region

#Region "c05_Solicitar_cant_solo_Udad_seleccionada_y_calcular_x_RTU_la_otra_Udad"

            If _Comportamiento = Enum_Comportamiento.c01_Solicitar_Ud_Que_Hara_Transaccion And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c05_Solicitar_cant_solo_Udad_seleccionada_y_calcular_x_RTU_la_otra_Udad Then
                Return "D"
            End If

            If _Comportamiento = Enum_Comportamiento.c02_Comprar_en_1ra_Udad_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c05_Solicitar_cant_solo_Udad_seleccionada_y_calcular_x_RTU_la_otra_Udad Then
                Return "8"
            End If

            If _Comportamiento = Enum_Comportamiento.c03_Comprar_en_2da_Udad_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c05_Solicitar_cant_solo_Udad_seleccionada_y_calcular_x_RTU_la_otra_Udad Then
                Return "I"
            End If

            If _Comportamiento = Enum_Comportamiento.c04_Comprar_en_1ra_Udad_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c05_Solicitar_cant_solo_Udad_seleccionada_y_calcular_x_RTU_la_otra_Udad Then
                Return "N"
            End If

            If _Comportamiento = Enum_Comportamiento.c05_Comprar_en_2da_Udad_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c05_Solicitar_cant_solo_Udad_seleccionada_y_calcular_x_RTU_la_otra_Udad Then
                Return "S"
            End If

            If _Comportamiento = Enum_Comportamiento.c06_Solicitar_Udad_si_es_compra_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c05_Solicitar_cant_solo_Udad_seleccionada_y_calcular_x_RTU_la_otra_Udad Then
                Return "e"
            End If

            If _Comportamiento = Enum_Comportamiento.c07_Solicitar_Udad_si_es_compra_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c05_Solicitar_cant_solo_Udad_seleccionada_y_calcular_x_RTU_la_otra_Udad Then
                Return "k"
            End If

            If _Comportamiento = Enum_Comportamiento.c08_Comrar_en_1ra_Udad_Solicitar_Udad_si_es_venta And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c05_Solicitar_cant_solo_Udad_seleccionada_y_calcular_x_RTU_la_otra_Udad Then
                Return "q"
            End If

            If _Comportamiento = Enum_Comportamiento.c09_Comrar_en_2da_Udad_Solicitar_Udad_si_es_venta And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c05_Solicitar_cant_solo_Udad_seleccionada_y_calcular_x_RTU_la_otra_Udad Then
                Return "w"
            End If

            If _Comportamiento = Enum_Comportamiento.c10_Utilizar_unidad_indivisible_solo_RTU_constante And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c05_Solicitar_cant_solo_Udad_seleccionada_y_calcular_x_RTU_la_otra_Udad Then
                Return ""
            End If

            If _Comportamiento = Enum_Comportamiento.c11_Vender_en_1ra_Udad_sin_dividir_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c05_Solicitar_cant_solo_Udad_seleccionada_y_calcular_x_RTU_la_otra_Udad Then
                Return "D"
            End If

#End Region

#Region "c06_Calcular_RTU_forma_invertida"

            If _Comportamiento = Enum_Comportamiento.c01_Solicitar_Ud_Que_Hara_Transaccion And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c06_Calcular_RTU_forma_invertida Then
                Return "E"
            End If

            If _Comportamiento = Enum_Comportamiento.c02_Comprar_en_1ra_Udad_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c06_Calcular_RTU_forma_invertida Then
                Return "9"
            End If

            If _Comportamiento = Enum_Comportamiento.c03_Comprar_en_2da_Udad_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c06_Calcular_RTU_forma_invertida Then
                Return "J"
            End If

            If _Comportamiento = Enum_Comportamiento.c04_Comprar_en_1ra_Udad_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c06_Calcular_RTU_forma_invertida Then
                Return "O"
            End If

            If _Comportamiento = Enum_Comportamiento.c05_Comprar_en_2da_Udad_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c06_Calcular_RTU_forma_invertida Then
                Return "T"
            End If

            If _Comportamiento = Enum_Comportamiento.c06_Solicitar_Udad_si_es_compra_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c06_Calcular_RTU_forma_invertida Then
                Return "f"
            End If

            If _Comportamiento = Enum_Comportamiento.c07_Solicitar_Udad_si_es_compra_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c06_Calcular_RTU_forma_invertida Then
                Return "l"
            End If

            If _Comportamiento = Enum_Comportamiento.c08_Comrar_en_1ra_Udad_Solicitar_Udad_si_es_venta And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c06_Calcular_RTU_forma_invertida Then
                Return "r"
            End If

            If _Comportamiento = Enum_Comportamiento.c09_Comrar_en_2da_Udad_Solicitar_Udad_si_es_venta And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c06_Calcular_RTU_forma_invertida Then
                Return "x"
            End If

            If _Comportamiento = Enum_Comportamiento.c10_Utilizar_unidad_indivisible_solo_RTU_constante And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c06_Calcular_RTU_forma_invertida Then
                Return ""
            End If

            If _Comportamiento = Enum_Comportamiento.c11_Vender_en_1ra_Udad_sin_dividir_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c06_Calcular_RTU_forma_invertida Then
                Return "E"
            End If

#End Region

#Region "c07_Solicitar_cantidad_ambas_unidades_del_producto"

            If _Comportamiento = Enum_Comportamiento.c01_Solicitar_Ud_Que_Hara_Transaccion And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c07_Solicitar_cantidad_ambas_unidades_del_producto Then
                Return ">"
            End If

            If _Comportamiento = Enum_Comportamiento.c02_Comprar_en_1ra_Udad_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c07_Solicitar_cantidad_ambas_unidades_del_producto Then
                Return "<"
            End If

            If _Comportamiento = Enum_Comportamiento.c03_Comprar_en_2da_Udad_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c07_Solicitar_cantidad_ambas_unidades_del_producto Then
                Return "_"
            End If

            If _Comportamiento = Enum_Comportamiento.c04_Comprar_en_1ra_Udad_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c07_Solicitar_cantidad_ambas_unidades_del_producto Then
                Return "-"
            End If

            If _Comportamiento = Enum_Comportamiento.c05_Comprar_en_2da_Udad_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c07_Solicitar_cantidad_ambas_unidades_del_producto Then
                Return "("
            End If

            If _Comportamiento = Enum_Comportamiento.c06_Solicitar_Udad_si_es_compra_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c07_Solicitar_cantidad_ambas_unidades_del_producto Then
                Return ")"
            End If

            If _Comportamiento = Enum_Comportamiento.c07_Solicitar_Udad_si_es_compra_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c07_Solicitar_cantidad_ambas_unidades_del_producto Then
                Return "["
            End If

            If _Comportamiento = Enum_Comportamiento.c08_Comrar_en_1ra_Udad_Solicitar_Udad_si_es_venta And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c07_Solicitar_cantidad_ambas_unidades_del_producto Then
                Return "]"
            End If

            If _Comportamiento = Enum_Comportamiento.c09_Comrar_en_2da_Udad_Solicitar_Udad_si_es_venta And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c07_Solicitar_cantidad_ambas_unidades_del_producto Then
                Return "*"
            End If

            If _Comportamiento = Enum_Comportamiento.c10_Utilizar_unidad_indivisible_solo_RTU_constante And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c07_Solicitar_cantidad_ambas_unidades_del_producto Then
                Return ""
            End If

            If _Comportamiento = Enum_Comportamiento.c11_Vender_en_1ra_Udad_sin_dividir_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c07_Solicitar_cantidad_ambas_unidades_del_producto Then
                Return ">"
            End If

#End Region

#Region "c08_Solicitar_RTU_producto"

            If _Comportamiento = Enum_Comportamiento.c01_Solicitar_Ud_Que_Hara_Transaccion And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c08_Solicitar_RTU_producto Then
                Return "W"
            End If

            If _Comportamiento = Enum_Comportamiento.c02_Comprar_en_1ra_Udad_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c08_Solicitar_RTU_producto Then
                Return "X"
            End If

            If _Comportamiento = Enum_Comportamiento.c03_Comprar_en_2da_Udad_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c08_Solicitar_RTU_producto Then
                Return "Y"
            End If

            If _Comportamiento = Enum_Comportamiento.c04_Comprar_en_1ra_Udad_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c08_Solicitar_RTU_producto Then
                Return "Z"
            End If

            If _Comportamiento = Enum_Comportamiento.c05_Comprar_en_2da_Udad_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c08_Solicitar_RTU_producto Then
                Return "U"
            End If

            If _Comportamiento = Enum_Comportamiento.c06_Solicitar_Udad_si_es_compra_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c08_Solicitar_RTU_producto Then
                Return "V"
            End If

            If _Comportamiento = Enum_Comportamiento.c07_Solicitar_Udad_si_es_compra_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c08_Solicitar_RTU_producto Then
                Return "y"
            End If

            If _Comportamiento = Enum_Comportamiento.c08_Comrar_en_1ra_Udad_Solicitar_Udad_si_es_venta And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c08_Solicitar_RTU_producto Then
                Return "z"
            End If

            If _Comportamiento = Enum_Comportamiento.c09_Comrar_en_2da_Udad_Solicitar_Udad_si_es_venta And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c08_Solicitar_RTU_producto Then
                Return "+"
            End If

            If _Comportamiento = Enum_Comportamiento.c10_Utilizar_unidad_indivisible_solo_RTU_constante And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c08_Solicitar_RTU_producto Then
                Return ""
            End If

            If _Comportamiento = Enum_Comportamiento.c11_Vender_en_1ra_Udad_sin_dividir_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c08_Solicitar_RTU_producto Then
                Return "W"
            End If

#End Region

#Region "c09_RTU_variable"

            If _Comportamiento = Enum_Comportamiento.c01_Solicitar_Ud_Que_Hara_Transaccion And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c09_RTU_variable Then
                Return "¡"
            End If

            If _Comportamiento = Enum_Comportamiento.c02_Comprar_en_1ra_Udad_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c09_RTU_variable Then
                Return "¿"
            End If

            If _Comportamiento = Enum_Comportamiento.c03_Comprar_en_2da_Udad_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c09_RTU_variable Then
                Return "^"
            End If

            If _Comportamiento = Enum_Comportamiento.c04_Comprar_en_1ra_Udad_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c09_RTU_variable Then
                Return "\"
            End If

            If _Comportamiento = Enum_Comportamiento.c05_Comprar_en_2da_Udad_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c09_RTU_variable Then
                Return "#"
            End If

            If _Comportamiento = Enum_Comportamiento.c06_Solicitar_Udad_si_es_compra_Vender_1ra_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c09_RTU_variable Then
                Return "@"
            End If

            If _Comportamiento = Enum_Comportamiento.c07_Solicitar_Udad_si_es_compra_Vender_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c09_RTU_variable Then
                Return "|"
            End If

            If _Comportamiento = Enum_Comportamiento.c08_Comrar_en_1ra_Udad_Solicitar_Udad_si_es_venta And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c09_RTU_variable Then
                Return "&"
            End If

            If _Comportamiento = Enum_Comportamiento.c09_Comrar_en_2da_Udad_Solicitar_Udad_si_es_venta And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c09_RTU_variable Then
                Return "$"
            End If

            If _Comportamiento = Enum_Comportamiento.c10_Utilizar_unidad_indivisible_solo_RTU_constante And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c09_RTU_variable Then
                Return ""
            End If

            If _Comportamiento = Enum_Comportamiento.c11_Vender_en_1ra_Udad_sin_dividir_2da_Udad And
                _Tratamientos_RTU = Enum_Tratamientos_RTU.c09_RTU_variable Then
                Return "¡"
            End If


#End Region

            Return ""

        End Function

        Function Fx_Decifra_Nmarca(_Nmarca As String) As Bk_Comporamiento_UdMedidas.Nmarca

            Dim _FxNmarca As New Bk_Comporamiento_UdMedidas.Nmarca

            _FxNmarca.Nmarca = _Nmarca

            If String.IsNullOrEmpty(_Nmarca) Then
                _FxNmarca.Comportamiento = Enum_Comportamiento.c01_Solicitar_Ud_Que_Hara_Transaccion
                _FxNmarca.Tratamiento = Enum_Tratamientos_RTU.c01_Caso_normal_respetar_RTU_definida
            End If

            Select Case _Nmarca
                Case "", "A", "B", "C", "D", "E", ">", "W", "¡"
                    _FxNmarca.Comportamiento = Enum_Comportamiento.c01_Solicitar_Ud_Que_Hara_Transaccion ' .c01_Caso_normal_respetar_RTU_definida
                Case "1", "5", "6", "7", "8", "9", "<", "X", "¿"
                    _FxNmarca.Comportamiento = Enum_Comportamiento.c02_Comprar_en_1ra_Udad_Vender_1ra_Udad '.c02_Solicitar_Ancho_Largo_y_Alto_Para_obtener_1ra_Udad
                Case "2", "F", "G", "H", "I", "J", "_", "Y", "^"
                    _FxNmarca.Comportamiento = Enum_Comportamiento.c03_Comprar_en_2da_Udad_Vender_1ra_Udad '.c03_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_MT2
                Case "3", "K", "L", "M", "N", "O", "-", "Z", "\"
                    _FxNmarca.Comportamiento = Enum_Comportamiento.c04_Comprar_en_1ra_Udad_Vender_2da_Udad '.c04_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_CM2
                Case "4", "p", "q", "r", "s", "T", "(", "U", "#", "R", "S"
                    _FxNmarca.Comportamiento = Enum_Comportamiento.c05_Comprar_en_2da_Udad_Vender_2da_Udad '.c05_Solicitar_cant_solo_Udad_seleccionada_y_calcular_x_RTU_la_otra_Udad
                Case "a", "b", "c", "d", "e", "f", ")", "V", "@"
                    _FxNmarca.Comportamiento = Enum_Comportamiento.c06_Solicitar_Udad_si_es_compra_Vender_1ra_Udad '.c06_Calcular_RTU_forma_invertida
                Case "g", "h", "i", "j", "k", "l", "[", "y", "|"
                    _FxNmarca.Comportamiento = Enum_Comportamiento.c07_Solicitar_Udad_si_es_compra_Vender_2da_Udad' .c07_Solicitar_cantidad_ambas_unidades_del_producto
                Case "m", "n", "o", "p", "q", "r", "]", "z", "&"
                    _FxNmarca.Comportamiento = Enum_Comportamiento.c08_Comrar_en_1ra_Udad_Solicitar_Udad_si_es_venta' .c08_Solicitar_RTU_producto
                Case "s", "t", "u", "v", "w", "x", "*", "+", "$"
                    _FxNmarca.Comportamiento = Enum_Comportamiento.c09_Comrar_en_2da_Udad_Solicitar_Udad_si_es_venta' .c09_RTU_variable
                Case "Ñ"
                    _FxNmarca.Comportamiento = Enum_Comportamiento.c10_Utilizar_unidad_indivisible_solo_RTU_constante '.c10_RTU_constante
            End Select

            Select Case _Nmarca
                Case "", "1", "2", "3", "4", "a", "g", "m", "s"
                    _FxNmarca.Tratamiento = Enum_Tratamientos_RTU.c01_Caso_normal_respetar_RTU_definida
                Case "A", "5", "F", "K", "p", "b", "h", "n", "t"
                    _FxNmarca.Tratamiento = Enum_Tratamientos_RTU.c02_Solicitar_Ancho_Largo_y_Alto_Para_obtener_1ra_Udad
                Case "B", "6", "G", "L", "q", "c", "i", "o", "u"
                    _FxNmarca.Tratamiento = Enum_Tratamientos_RTU.c03_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_MT2
                Case "C", "7", "H", "M", "r", "d", "j", "p", "v", "R"
                    _FxNmarca.Tratamiento = Enum_Tratamientos_RTU.c04_Solicitar_Ancho_y_Largo_Para_Para_obtener_1ra_Udad_CM2
                Case "D", "8", "I", "N", "s", "e", "k", "q", "w", "S"
                    _FxNmarca.Tratamiento = Enum_Tratamientos_RTU.c05_Solicitar_cant_solo_Udad_seleccionada_y_calcular_x_RTU_la_otra_Udad
                Case "E", "9", "J", "O", "T", "f", "l", "r", "x"
                    _FxNmarca.Tratamiento = Enum_Tratamientos_RTU.c06_Calcular_RTU_forma_invertida
                Case ">", "<", "_", "-", "(", ")", "[", "]", "*"
                    _FxNmarca.Tratamiento = Enum_Tratamientos_RTU.c07_Solicitar_cantidad_ambas_unidades_del_producto
                Case "W", "X", "Y", "Z", "U", "V", "y", "z", "+"
                    _FxNmarca.Tratamiento = Enum_Tratamientos_RTU.c08_Solicitar_RTU_producto
                Case "¡", "¿", "^", "\", "#", "@", "|", "&", "$", ""
                    _FxNmarca.Tratamiento = Enum_Tratamientos_RTU.c09_RTU_variable
                Case "Ñ"
                    _FxNmarca.Tratamiento = Enum_Tratamientos_RTU.c10_RTU_constante
            End Select

            Return _FxNmarca

        End Function

    End Class

    Public Class Nmarca
        Public Property Nmarca As String
        Public Property Comportamiento As Cl_CompUdMedidas.Enum_Comportamiento
        Public Property Tratamiento As Cl_CompUdMedidas.Enum_Tratamientos_RTU

    End Class

End Namespace
