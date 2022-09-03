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

    'Dim _Ds_Producto As New Ds_Producto
    Dim _Preguntar_Crear_Otro As Boolean
    Dim _MaxCarac_Ref_Producto As Integer

    Dim _Pedir_Alternativo As Boolean

    Dim _Crear_Alternativo As Boolean
    Dim _CodAlternativo, _CodProveedor, _SucProveedor As String

    Dim _Grabar As Boolean
    Dim _RowProducto As DataRow

    Dim _Cl_Producto As Cl_Producto

    Dim Union = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "UNION" & vbCrLf
    Public ReadOnly Property Pro_Grabar() As Boolean
        Get
            Return _Grabar
        End Get
    End Property

    Public Property Pro_RowProducto() As DataRow
        Get
            Return _RowProducto
        End Get
        Set(ByVal value As DataRow)
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

        caract_combo(Cmb_Ud01pr)
        Consulta_sql = "SELECT CodigoTabla AS Padre,CodigoTabla AS Hijo" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones WHERE Tabla = 'RTU' ORDER BY Orden"
        Cmb_Ud01pr.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmb_Ud02pr)
        Consulta_sql = "SELECT CodigoTabla AS Padre,CodigoTabla AS Hijo" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones WHERE Tabla = 'RTU' ORDER BY Orden"
        Cmb_Ud02pr.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Arr_Bloquea_Pr(,) As String = {{"", ""},
                                            {"C", "Bloqueado para compras"},
                                            {"T", "Bloqueado para compras y ventas"},
                                            {"V", "Bloqueado para ventas"}}
        Sb_Llenar_Combos(_Arr_Bloquea_Pr, Cmb_Bloqueapr)
        Cmb_Bloqueapr.SelectedValue = ""


        Dim _Arr_Tipo_Productos(,) As String = {{"FIN", "Insumo productivo"},
                                               {"FLN", "Artículo multiproposito"},
                                               {"FPN", "Articulo estándar"},
                                               {"FPS", "Articulo seriado"},
                                               {"FUN", "Herramienta estándar"},
                                               {"FUS", "Herramienta seriada"},
                                               {"GEN", "Génerico o agrupador de artículos"},
                                               {"SSN", "Servicios y similares"}}
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

        caract_combo(Cmb_Zonapr)
        Consulta_sql = Union & "SELECT KOZO AS Padre,NOKOZO AS Hijo FROM TABZO"
        Cmb_Zonapr.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        ZonaPro = ""
        Cmb_Zonapr.SelectedValue = ZonaPro

        Dim _Arr_Rgpr(,) As String = {{"N", "Nacional"},
                                      {"I", "Importados"}}
        Sb_Llenar_Combos(_Arr_Rgpr, Cmb_Rgpr)
        Cmb_Rgpr.SelectedValue = "N"

    End Sub

#End Region

#Region "FUNCIONES ESPECIALES"

    Sub Sb_Actualizar_Grilla(ByVal _Grilla As DataGridView)

        With _Grilla

            ' .DataSource = _Tbl

            .Columns("Select").HeaderText = "Sel."
            .Columns("Select").Width = 50
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Width = 100
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Width = 235

        End With

    End Sub

    Private Function Chks(ByVal Chk As CheckBox) As Integer
        Dim Nro As Integer = 0
        If Chk.Checked = True Then Nro = 1
        Return Nro
    End Function

    Private Function ChequearTodo(ByVal Grilla As DataGridView,
                                  ByVal Chk As CheckBoxX,
                                  ByVal NombreTabla As String)

        Dim Chequeo As Boolean
        Chequeo = Chk.Checked

        For i As Integer = 0 To Grilla.Rows.Count - 1
            Grilla.Rows(i).Cells(0).Value = Chequeo
        Next

    End Function

    Private Function CodigoSugerido(ByVal TIPR As String,
                                    ByVal _Iniciales As String,
                                    ByVal _MaxCarac_Codigo As Integer) As String

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

    Public Sub New(ByVal Accion As Cl_Producto.Enum_Accion,
                   ByVal Codigo As String,
                   ByVal Preguntar_Crear_Otro As Boolean,
                   ByVal Crear_Alternativo As Boolean)


        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        ' Sb_Limpiar()

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

        'AddHandler Cmb_Mrpr.SelectedIndexChanged, AddressOf Cmbmarcas_SelectedIndexChanged
        'AddHandler Cmb_Rupr.SelectedIndexChanged, AddressOf Cmbrubros_SelectedIndexChanged
        'AddHandler Cmb_Clalibpr.SelectedIndexChanged, AddressOf Cmbclalibpr_SelectedIndexChanged
        'AddHandler Cmb_Kofupr.SelectedIndexChanged, AddressOf CmbJefeProducto_SelectedIndexChanged
        'AddHandler Cmb_Zonapr.SelectedIndexChanged, AddressOf CmbZonaProducto_SelectedIndexChanged

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

    Private Sub Frm_MtCreacionDeProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Limpiar()

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

    End Sub

    Private Sub BtnxGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click
        Sb_Grabar1()
    End Sub

    Private Sub Sb_Grabar1()

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

        If String.IsNullOrEmpty(Trim(Cmb_Ud01pr.Text)) Or String.IsNullOrEmpty(Trim(Cmb_Ud02pr.Text)) Then
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
        _RowProducto.Item("NOKOPRRA") = Mid(Txt_Nokoprra.Text.Trim, 1, 20)

        _RowProducto.Item("KOPRTE") = Txt_Koprte.Text.Trim

        _RowProducto.Item("TIPR") = Cmb_Tipr.SelectedValue.ToString

        _RowProducto.Item("UD01PR") = Cmb_Ud01pr.SelectedValue.ToString.Trim
        _RowProducto.Item("UD02PR") = Cmb_Ud02pr.SelectedValue.ToString.Trim
        _RowProducto.Item("RLUD") = Txt_Rlud.Tag

        _RowProducto.Item("BLOQUEAPR") = Cmb_Bloqueapr.SelectedValue.ToString
        _RowProducto.Item("POIVPR") = Input_Poivpr.Value
        _RowProducto.Item("RGPR") = Cmb_Rgpr.SelectedValue

        _RowProducto.Item("LISCOSTO") = ListaCostoPro

        Dim _Divisible As String
        Dim _Divisible2 As String

        If Chk_Divisible.Checked Then
            _Divisible = "S"
        Else
            _Divisible = "N"
        End If

        If Chk_Divisible2.Checked Then
            _Divisible2 = "S"
        Else
            _Divisible2 = "N"
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

        If String.IsNullOrEmpty(Trim(Cmb_Ud01pr.Text)) Or String.IsNullOrEmpty(Trim(Cmb_Ud02pr.Text)) Then
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

        _RowProducto.Item("UD01PR") = Cmb_Ud01pr.SelectedValue.ToString.Trim
        _RowProducto.Item("UD02PR") = Cmb_Ud02pr.SelectedValue.ToString.Trim
        _RowProducto.Item("RLUD") = Txt_Rlud.Tag

        _RowProducto.Item("BLOQUEAPR") = Cmb_Bloqueapr.SelectedValue.ToString
        _RowProducto.Item("POIVPR") = Input_Poivpr.Value
        _RowProducto.Item("RGPR") = Cmb_Rgpr.SelectedValue

        _RowProducto.Item("LISCOSTO") = ListaCostoPro

        Dim _Divisible As String
        Dim _Divisible2 As String

        If Chk_Divisible.Checked Then
            _Divisible = "S"
        Else
            _Divisible = "N"
        End If

        If Chk_Divisible2.Checked Then
            _Divisible2 = "S"
        Else
            _Divisible2 = "N"
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


    Private Sub Txtcodigoprincipal_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If _Cl_Producto.Pro_Accion = Cl_Producto.Enum_Accion.Nuevo Then
            If Fx_ValidarExistenciaDeCodigo(sender.text, "KOPR") = True Then Txt_Kopr.Focus()
        End If
    End Sub

    Private Sub Txtcodigotecnico_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If _Cl_Producto.Pro_Accion = Cl_Producto.Enum_Accion.Nuevo Then
            If Fx_ValidarExistenciaDeCodigo(sender.text, "KOPRTE") = True Then Txt_Koprte.Focus()
        End If
    End Sub

    Private Sub Txtcodigoprincipal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Txt_Koprte.Text = Txt_Kopr.Text
    End Sub

    Private Sub ChkSelEmpresas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSelEmpresas.CheckedChanged
        ChequearTodo(GrillaEmpresa, ChkSelEmpresas, "Empresa")
    End Sub

    Private Sub ChkSelBodegas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSelBodegas.CheckedChanged
        ChequearTodo(GrillaBodegas, ChkSelBodegas, "Bodega")
    End Sub

    Private Sub ChkSelListas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSelListas.CheckedChanged
        ChequearTodo(GrillaListaDePrecios, ChkSelListas, "Listas")
    End Sub

    Private Sub ChkSelTodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSelTodo.CheckedChanged
        ChkSelEmpresas.Checked = ChkSelTodo.Checked
        ChkSelBodegas.Checked = ChkSelTodo.Checked
        ChkSelListas.Checked = ChkSelTodo.Checked
    End Sub

    Private Sub TxtDescripcionLarga_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Txt_Nokoprra.Text = Mid(Txt_Nokopr.Text, 1, 20)
    End Sub

    Private Sub CmbSuperFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbSuperFamilia.SelectedIndexChanged
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

    Private Sub CmbFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbFamilia.SelectedIndexChanged
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

    Private Sub CmbSubFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbSubFamilia.SelectedIndexChanged
        Try
            SubFamilia = CmbSubFamilia.SelectedValue.ToString
        Catch ex As Exception
            SubFamilia = String.Empty
        End Try
    End Sub

    Private Sub BtnFamilias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFamilias.Click
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

    Private Sub Cmbmarcas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Marca = Cmb_Mrpr.SelectedValue.ToString
        Catch ex As Exception
            Marca = String.Empty
        End Try
    End Sub

    Private Sub Cmbrubros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Rubro = Cmb_Rupr.SelectedValue.ToString
    End Sub

    Private Sub Cmbclalibpr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ClasifLibre = Cmb_Clalibpr.SelectedValue.ToString
    End Sub

    Private Sub CmbJefeProducto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        JefePro = Cmb_Kofupr.SelectedValue.ToString
    End Sub

    Private Sub CmbZonaProducto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ZonaPro = Cmb_Zonapr.SelectedValue.ToString
    End Sub

    Private Sub Cmblista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ListaCostoPro = Cmb_Codlista.SelectedValue.ToString
        Catch ex As Exception
            ListaCostoPro = ""
        End Try
    End Sub

    'Private Sub BtnCodAlternativo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim Fr As New Frm_CreaProductos_04_CodAlternativo(Txt_Kopr.Text)
    '    Fr.BtnBuscarEntidad.Enabled = False
    '    Fr.ShowDialog(Me)
    '    Fr.Dispose()
    'End Sub

    Private Sub BtnMantPrecios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mant_Precios.Click
        Fx_Ingresar_Precio_Nuevo_Producto(_RowProducto)
    End Sub

    Function Fx_Ingresar_Cod_Alternativo(ByVal _RowProducto As DataRow) As Boolean

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
    Function Fx_Ingresar_Precio_Nuevo_Producto(ByVal _RowProducto As DataRow) As Boolean

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

    Function Fx_Ingresar_Descripcion_por_Arbol_de_clasificacion(ByVal _RowProducto As DataRow) As Boolean

        If Fx_Tiene_Permiso(Me, "Prod009") Then

            Dim FrmBa As New Frm_MtCreaProd_01_IngBusqEspecial
            With FrmBa
                .TxtCodigo.Text = _RowProducto.Item("KOPR")
                .TxtDescripcion.Text = _RowProducto.Item("NOKOPR")
                .ShowDialog(Me)
            End With

            Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Asociacion", _
                                                                 "Codigo = '" & _RowProducto.Item("KOPR") & "' And Producto = 0"))
            Return _Reg

        End If

    End Function

    Function Fx_Ingresar_Descripcion_por_Arbol_de_clasificacion(ByVal _RowProducto As DataRow, ByVal _Permiso As String) As Boolean

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

    Private Sub BtnAsociaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Asociaciones.Click
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
        Fm.Txt_Texto.MaxLength = 255
        Fm.Pro_Texto_Log = NuloPorNro(_Cl_Producto.Pro_Maeficha.Rows(0).Item("FICHA"), "")
        Fm.Ancho = 800
        Fm.Alto = 280
        Fm.ShowDialog(Me)
        If Fm.Pro_Grabar Then
            _Cl_Producto.Pro_Maeficha.Rows(0).Item("FICHA") = Fm.Pro_Texto_Log
        End If
        Fm.Dispose()

    End Sub

    Private Sub Btn_Dimensiones_Click(sender As Object, e As EventArgs) Handles Btn_Dimensiones.Click

        Dim Fm As New Frm_Dimensiones_Pr(Txt_Kopr.Text, False)
        Fm.ShowDialog(Me)
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
        Cmb_Ud01pr.SelectedValue = NuloPorNro(_RowProducto.Item("UD01PR"), "UN")
        Cmb_Ud02pr.SelectedValue = NuloPorNro(_RowProducto.Item("UD02PR"), "UN")

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

        'Consulta_sql = "Select Top 1 * From MAEPROBS Where KOPR = '" & _Codigo & "'"
        'Dim _RowMaeprobs As DataRow = '_Sql.Fx_Get_DataRow(Consulta_sql)

        If CBool(_Cl_Producto.Pro_Maeprobs.Rows.Count) Then
            Txt_Mensaje01.Text = _Cl_Producto.Pro_Maeprobs.Rows(0).Item("MENSAJE01")
            Txt_Mensaje02.Text = _Cl_Producto.Pro_Maeprobs.Rows(0).Item("MENSAJE02")
            Txt_Mensaje03.Text = _Cl_Producto.Pro_Maeprobs.Rows(0).Item("MENSAJE03")
        Else
            Txt_Mensaje01.Text = String.Empty
            Txt_Mensaje02.Text = String.Empty
            Txt_Mensaje03.Text = String.Empty
        End If

        Chk_Conubic.Checked = NuloPorNro(_RowProducto.Item("CONUBIC"), False)
        Chk_Esactfi.Checked = NuloPorNro(_RowProducto.Item("ESACTFI"), False)
        Chk_Lotecaja.Checked = NuloPorNro(_RowProducto.Item("LOTECAJA"), False)
        Chk_Movetiq.Checked = NuloPorNro(_RowProducto.Item("MOVETIQ"), False)
        Chk_Prrg.Checked = NuloPorNro(_RowProducto.Item("PRRG"), False)
        Chk_Stockaseg.Checked = NuloPorNro(_RowProducto.Item("STOCKASEG"), False)
        Chk_Tratalote.Checked = NuloPorNro(_RowProducto.Item("TRATALOTE"), False)
        Chk_Tratvmedia.Checked = NuloPorNro(_RowProducto.Item("TRATVMEDIA"), False)

        Dim _Divisible As String = NuloPorNro(_RowProducto.Item("DIVISIBLE"), "0")
        Dim _Divisible2 As String = NuloPorNro(_RowProducto.Item("DIVISIBLE2"), "0")

        If _Divisible = "N" Or _Divisible = "1" Then
            Chk_Divisible.Checked = True
        End If

        If _Divisible2 = "N" Or _Divisible2 = "1" Then
            Chk_Divisible2.Checked = True
        End If

        GrillaEmpresa.DataSource = _Cl_Producto.Pro_Tbl_Empresas
        GrillaBodegas.DataSource = _Cl_Producto.Pro_Tbl_Bodegas
        GrillaListaDePrecios.DataSource = _Cl_Producto.Pro_Tbl_Listas
        GrillaImpuestos.DataSource = _Cl_Producto.Pro_Tbl_Impuestos

        Sb_Actualizar_Grilla(GrillaEmpresa)
        Sb_Actualizar_Grilla(GrillaBodegas)
        Sb_Actualizar_Grilla(GrillaListaDePrecios)
        Sb_Actualizar_Grilla(GrillaImpuestos)

    End Sub

    Private Sub BtnCodAlternativosProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCodAlternativosProducto.Click
        If Fx_Tiene_Permiso(Me, "Prod020") Then
            Dim Fm As New Frm_CodAlternativo_Ver
            Fm.TxtCodigo.Text = _RowProducto.Item("KOPR")
            Fm.Txtdescripcion.Text = _RowProducto.Item("NOKOPR")
            Fm.TxtRTU.Text = _RowProducto.Item("RLUD")
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Marcas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Marcas.Click
        If Fx_Tiene_Permiso(Me, "Tbl00016") Then

            Dim _Marca = Trim(Cmb_Mrpr.SelectedValue)
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Marcas, _
                                                                 Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
            Fm.Text = "MARCAS"
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Consulta_sql = Union & "SELECT KOMR AS Padre,NOKOMR AS Hijo FROM TABMR ORDER BY Hijo" ' WHERE SEMILLA = " & Actividad
            Cmb_Mrpr.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
            Cmb_Mrpr.SelectedValue = _Marca
        End If
    End Sub

    Private Sub Btn_Rubro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Rubro.Click
        If Fx_Tiene_Permiso(Me, "Tbl00017") Then

            Dim _Rubro = Cmb_Rupr.SelectedValue
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Rubros, _
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

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        If Fx_Tiene_Permiso(Me, "Tbl00020") Then

            Dim _ClasifLibre = Cmb_Clalibpr.SelectedValue
            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Claslibre, _
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

    Private Sub Btn_Zonas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Zonas.Click

        MessageBoxEx.Show(Me, "En desarrollo")
        Return
        If Fx_Tiene_Permiso(Me, "Tbl00018") Then
            Dim _ZonaPro = Cmb_Zonapr.SelectedValue

            caract_combo(Cmb_Zonapr)
            Consulta_sql = Union & "SELECT KOZO AS Padre,NOKOZO AS Hijo FROM TABZO"
            Cmb_Zonapr.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
            Cmb_Zonapr.SelectedValue = _ZonaPro

        End If
    End Sub

    Private Sub Btn_TablaClasificaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_TablaClasificaciones.Click
        If Fx_Tiene_Permiso(Me, "Tbl00002") Then
            Dim Fm As New Frm_Arbol_Asociacion_02(False, 0, False, Frm_Arbol_Asociacion_02.Enum_Clasificacion.Dinamica, 0)
            Fm.Pro_Identificador_NodoPadre = 0
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Imagenes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imagenes.Click

        Dim Fm As New Frm_Imagenes_X_Producto(Txt_Kopr.Text)

        If Fm.Fx_Llenar_Grilla_Imagenes Then
            Fm.ShowDialog(Me)
        Else
            MessageBoxEx.Show(Me, "No existen imagenes para el producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Fm.Dispose()

    End Sub

    Function Fx_ValidarExistenciaDeCodigo(ByVal Codigo As String,
                                       ByVal Campo As String,
                                       Optional ByVal MostrarMensaje As Boolean = True)
        If _Sql.Fx_Trae_Dato("MAEPR", Campo, Campo & " = '" & Codigo & "'") <> "" Then

            If MostrarMensaje = True Then
                MessageBoxEx.Show(Me, "¡Código de producto ya existe!", "Código principal", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            Return True
        Else
            Return False
        End If
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

End Class
