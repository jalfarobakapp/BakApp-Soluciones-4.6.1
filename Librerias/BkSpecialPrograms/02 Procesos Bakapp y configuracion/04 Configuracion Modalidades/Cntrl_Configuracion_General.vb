Imports DevComponents.DotNetBar

Public Class Cntrl_Configuracion_General

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _FmPrincipal As Metro.MetroAppForm
    Dim _Modalidad As String
    Dim _SOC_Valor_1ra_Aprobacion As Double

    Dim _Cod_EntidadXdefecto, _Cod_SucEntXdefecto As String
    Dim _Cod_Vnta_Producto_NoCreado

    Dim _Row_Modalidad As DataRow
    Dim _Tbl_Filtro_Documentos_Excluidos As DataTable

    Dim _Modalidad_General As Boolean

    Dim _Union = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "UNION" & vbCrLf

    Public Sub New(ByVal FmPrincipal As Metro.MetroAppForm, ByVal Row_Modalidad As DataRow, Modalidad_General As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _FmPrincipal = FmPrincipal
        _Row_Modalidad = Row_Modalidad
        _Modalidad = _Row_Modalidad.Item("MODALIDAD")

        _Modalidad_General = Modalidad_General

        If Global_Thema = Enum_Themas.Oscuro Then

            Btn_Grabar.ForeColor = Color.White
            Btn_Numeraciones_Documento.ForeColor = Color.White
            Btn_Excluir_Documentos.ForeColor = Color.White

        End If

        Lbl_Monto_CRV.Visible = Modalidad_General
        Input_Monto_Max_CRV_FacMasiva.Visible = Modalidad_General

    End Sub
    Private Sub Cntrl_Configuracion_General_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

        Dim _Mod As New Clas_Modalidades

        _Global_Row_Configuracion_General = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.General, "")
        _Global_Row_Configuracion_Estacion = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.Estacion, Modalidad)

    End Sub
    Private Sub Cntrl_Configuracion_General_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Cargar_Combo()

        Dim _Tidoexclu As String 'TIDOEXCLU

        With _Row_Modalidad

            _Tidoexclu = Trim(.Item("TIDOEXCLU"))

            Chk_Pr_AutoPr_Crear_Codigo_Principal_Automatico.Checked = .Item("Pr_AutoPr_Crear_Codigo_Principal_Automatico")
            Rdb_Pr_AutoPr_Correlativo_General.Checked = .Item("Pr_AutoPr_Correlativo_General")
            Rdb_Pr_AutoPr_Correlativo_Por_Iniciales.Checked = .Item("Pr_AutoPr_Correlativo_Por_Iniciales")
            Cmb_Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico.SelectedValue = .Item("Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico")
            Txt_Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo.Value = .Item("Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo")

            Chk_Pr_Creacion_Exigir_Precio.Checked = .Item("Pr_Creacion_Exigir_Precio")
            Chk_Pr_Creacion_Exigir_Clasificacion_busqueda.Checked = .Item("Pr_Creacion_Exigir_Clasificacion_busqueda")
            Chk_Pr_Creacion_Exigir_Codigo_Alternativo.Checked = .Item("Pr_Creacion_Exigir_Codigo_Alternativo")

            Chk_Revisar_Tasa_de_Cambio.Checked = .Item("Revisa_Taza_Cambio")
            Chk_Revisar_Taza_Solo_Mon_Extranjeras.Checked = .Item("Revisar_Taza_Solo_Mon_Extranjeras")

            Chk_Pr_Desc_Producto_Solo_Mayusculas.Checked = .Item("Pr_Desc_Producto_Solo_Mayusculas")

            Txt_Dias_Venci_Coti.Text = .Item("Vnta_Dias_Venci_Coti")
            Cmb_TipoValor_Bruto_Neto.SelectedValue = .Item("Vnta_TipoValor_Bruto_Neto")
            Chk_Preguntar_Documento.Checked = .Item("Vnta_Preguntar_Documento")
            Chk_Redondear_Dscto_Cero.Checked = .Item("Vnta_Redondear_Dscto_Cero")

            _Cod_EntidadXdefecto = .Item("Vnta_EntidadXdefecto")
            _Cod_SucEntXdefecto = .Item("Vnta_SucEntXdefecto")

            Txt_Cliente.Text = _Sql.Fx_Trae_Dato("MAEEN", "NOKOEN",
                                         "KOEN = '" & _Cod_EntidadXdefecto & "' AND SUEN = '" & _Cod_SucEntXdefecto & "'")

            _Cod_Vnta_Producto_NoCreado = .Item("Vnta_Producto_NoCreado")
            Txt_Producto_Comodin.Text = _Sql.Fx_Trae_Dato("MAEPR", "NOKOPR", "KOPR = '" & _Cod_Vnta_Producto_NoCreado & "'")

            Cmb_SOC_CodTurno.SelectedValue = .Item("SOC_CodTurno")
            Cmb_SOC_Buscar_Producto.SelectedValue = .Item("SOC_Buscar_Producto")
            Rdb_SOC_Aprueba_Solo_G1.Checked = .Item("SOC_Aprueba_Solo_G1")
            Rdb_SOC_Aprueba_G1_y_G2.Checked = .Item("SOC_Aprueba_G1_y_G2")
            _SOC_Valor_1ra_Aprobacion = .Item("SOC_Valor_1ra_Aprobacion")
            Txt_SOC_Valor_1ra_Aprobacion.Text = FormatCurrency(_SOC_Valor_1ra_Aprobacion, 0)

            Txt_Dias_Apela.Text = .Item("SOC_Dias_Apela")
            Chk_SOC_Prod_Crea_Solo_Marcas_Proveedor.Checked = .Item("SOC_Prod_Crea_Solo_Marcas_Proveedor")
            Txt_Prod_Crea_Max_Carac_Nom.Text = .Item("SOC_Prod_Crea_Max_Carac_Nom")
            Cmb_SOC_Tipo_Creacion_Producto_Normal_Matriz.SelectedValue = .Item("SOC_Tipo_Creacion_Producto_Normal_Matriz")

            Cmb_Nodo_Raiz_Asociados.SelectedValue = .Item("Nodo_Raiz_Asociados")
            Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente.Checked = .Item("Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente")

            Chk_Conservar_Responzable_Doc_Relacionado.Checked = .Item("Conservar_Responzable_Doc_Relacionado")
            Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado.Checked = .Item("Preguntar_Si_Cambia_Responsable_Doc_Relacionado")

            Input_Dias_Max_Fecha_Despacho.Value = .Item("Dias_Max_Fecha_Despacho")
            Chk_Dias_Max_Fecha_Despacho_Sab.Checked = .Item("Dias_Max_Fecha_Despacho_Sab")
            Chk_Dias_Max_Fecha_Despacho_Dom.Checked = .Item("Dias_Max_Fecha_Despacho_Dom")

            Chk_Solicitar_Permiso_OCC_SOC.Checked = .Item("Solicitar_Permiso_OCC_SOC")
            Chk_Centro_Costo_Obligatorio_OCC.Checked = .Item("Centro_Costo_Obligatorio_OCC")

            Chk_No_Solicitar_Permiso_Entidad_Preferencial.Checked = .Item("No_Solicitar_Permiso_Entidad_Preferencial")

            Chk_Utilizar_NVV_En_Credito_X_Cliente.Checked = .Item("Utilizar_NVV_En_Credito_X_Cliente")

            Chk_No_Permitir_Grabar_Con_Dscto_Superado.Checked = .Item("No_Permitir_Grabar_Con_Dscto_Superado")

            Chk_BloqEdiConcepDescuento.Checked = .Item("BloqEdiConcepDescuento")
            Chk_BloqEdiConcepRecargo.Checked = .Item("BloqEdiConcepRecargo")

            Chk_Pedir_Permiso_Para_Usar_Stanby.Checked = .Item("Pedir_Permiso_Para_Usar_Stanby")
            Chk_Conservar_Bodega_Sig_Linea_Venta.Checked = .Item("Conservar_Bodega_Sig_Linea_Venta")

            Chk_Grabar_Despachos_Con_Huella.Checked = .Item("Grabar_Despachos_Con_Huella")
            Input_Monto_Max_CRV_FacMasiva.Value = .Item("Monto_Max_CRV_FacMasiva")

            Chk_Usar_Validador_Prod_X_Compras.Checked = .Item("Usar_Validador_Prod_X_Compras")

            Chk_Revisar_OCC_Pendientes_X_Productos.Checked = .Item("Revisar_OCC_Pendientes_X_Productos")
            Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor.Checked = .Item("Alerta_Costo_Lista_Distinto_Costo_Proveedor")

            chk_Pr_Creacion_Exigir_Dimensiones.Checked = .Item("Pr_Creacion_Exigir_Dimensiones")

        End With

        Grupo_Codigo_Automatico.Enabled = Chk_Pr_AutoPr_Crear_Codigo_Principal_Automatico.Checked

        AddHandler Txt_Dias_Venci_Coti.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros_Enteros
        AddHandler Txt_Dias_Apela.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros_Enteros
        AddHandler Txt_Prod_Crea_Max_Carac_Nom.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros_Enteros
        AddHandler Txt_SOC_Valor_1ra_Aprobacion.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros_Enteros
        AddHandler Chk_Pr_AutoPr_Crear_Codigo_Principal_Automatico.CheckedChanged, AddressOf Sb_Chk_Pr_AutoPr_Crear_Codigo_Principal_Automatico_CheckedChanged

        If _Modalidad_General Then
            Lbl_Modalidad.Text = "<font color=""#349FCE""><b>MODALIDAD GENERAL</b></font>"
            Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente.Enabled = False
            Grupo_Especial_Venta_01.Enabled = False
            pageSlider1.SelectedPage = SPage_Opciones_Generales
        Else
            Lbl_Modalidad.Text = "<font color=""#349FCE""><b>MODALIDAD " & _Modalidad & "</b></font>"
        End If

        If Not String.IsNullOrEmpty(_Tidoexclu) Then

            Dim _Tidos = Split(_Tidoexclu, ",")

            Dim _Fl = Generar_Filtro_IN_Arreglo(_Tidos, False)

            Consulta_sql = "Select TIDO As Codigo,NOTIDO As Descripcion From TABTIDO Where TIDO In " & _Fl
            _Tbl_Filtro_Documentos_Excluidos = _Sql.Fx_Get_Tablas(Consulta_sql)

        End If

    End Sub

    Sub Sb_Cargar_Combo()

        caract_combo(Cmb_SOC_CodTurno)

        Consulta_sql = "SELECT '' AS Padre,'' AS Hijo" & vbCrLf & _
                       "Union" & vbCrLf & _
                       "SELECT CodTurno AS Padre,Nombre_Turno AS Hijo" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "Zw_Turnos" & vbCrLf & _
                       "ORDER BY Padre"

        Cmb_SOC_CodTurno.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql) '_SQL.Fx_Get_Tablas(Consulta_sql)

        Dim _Arr_Busca_Pr(,) As String = {{"0", "MAESTRA PRODUCTOS"}, {"1", "PRODUCTOS DEL PROVEEDOR"}}
        Sb_Llenar_Combos(_Arr_Busca_Pr, Cmb_SOC_Buscar_Producto)
        Cmb_SOC_Buscar_Producto.SelectedValue = "1"


        Dim _Arr_TipoValor_Bruto_Neto(,) As String = {{"N", "NETO"}, {"B", "BRUTO"}}
        Sb_Llenar_Combos(_Arr_TipoValor_Bruto_Neto, Cmb_TipoValor_Bruto_Neto)
        Cmb_TipoValor_Bruto_Neto.SelectedValue = "N"


        Dim _Arr_SOC_Tipo_Creacion_Producto_Normal_Matriz(,) As String = {{"1", "FORMULARIO CLASICO"}, {"2", "FORMULARIO MATRIZ"}}
        Sb_Llenar_Combos(_Arr_SOC_Tipo_Creacion_Producto_Normal_Matriz, Cmb_SOC_Tipo_Creacion_Producto_Normal_Matriz)
        Cmb_SOC_Tipo_Creacion_Producto_Normal_Matriz.SelectedValue = "1"

        Dim _Arr_Tablas_Para_Iniciales_Cod_Automatico(,) As String = {{"MARCAS", "MARCAS"}, _
                                                                      {"FAMILIAS", "SUPER FAMILIA"}, _
                                                                      {"RUBROS", "RUBROS"}, _
                                                                      {"CLASLIBRE", "CLASIFICACION LIBRE"}}
        Sb_Llenar_Combos(_Arr_Tablas_Para_Iniciales_Cod_Automatico, Cmb_Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico)
        Cmb_Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico.SelectedValue = "MARCAS"


        caract_combo(Cmb_Nodo_Raiz_Asociados)
        Consulta_sql = "SELECT '0' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT Codigo_Nodo AS Padre,Descripcion AS Hijo" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                       "WHERE Nodo_Raiz = 0" & vbCrLf &
                       "ORDER BY Padre"
        Cmb_Nodo_Raiz_Asociados.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Nodo_Raiz_Asociados.SelectedValue = "0"

    End Sub



    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click

        '"Where Modalidad = '  '"

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Configuracion_General" & vbCrLf & _
                       "Insert Into " & _Global_BaseBk & "Zw_Configuracion_General (Version,Revisa_Taza_Cambio,Vnta_Dias_Venci_Coti,SOC_CodTurno) Values " & _
                       "('3'," & CInt(Chk_Revisar_Tasa_de_Cambio.Checked) * -1 & "," & CInt(Txt_Dias_Venci_Coti.Text) & ",'" & Trim(Cmb_SOC_CodTurno.SelectedValue) & "')"

        If String.IsNullOrEmpty(Cmb_Nodo_Raiz_Asociados.SelectedValue) Then
            Cmb_Nodo_Raiz_Asociados.SelectedValue = "0"
        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Configuracion Set" & vbCrLf &
                       "Pr_AutoPr_Crear_Codigo_Principal_Automatico = " & Convert.ToInt32(Chk_Pr_AutoPr_Crear_Codigo_Principal_Automatico.Checked) & "," & vbCrLf &
                       "Pr_AutoPr_Correlativo_Por_Iniciales = " & Convert.ToInt32(Rdb_Pr_AutoPr_Correlativo_Por_Iniciales.Checked) & "," & vbCrLf &
                       "Pr_AutoPr_Correlativo_General = " & Convert.ToInt32(Rdb_Pr_AutoPr_Correlativo_General.Checked) & "," & vbCrLf &
                       "Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico = '" & Cmb_Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico.SelectedValue & "'," & vbCrLf &
                       "Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo = " & Txt_Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo.Value & "," & vbCrLf &
                       "Pr_Desc_Producto_Solo_Mayusculas = " & Convert.ToInt32(Chk_Pr_Desc_Producto_Solo_Mayusculas.Checked) & "," & vbCrLf &
                       "Pr_Creacion_Exigir_Precio = " & Convert.ToInt32(Chk_Pr_Creacion_Exigir_Precio.Checked) & "," & vbCrLf &
                       "Pr_Creacion_Exigir_Clasificacion_busqueda = " & Convert.ToInt32(Chk_Pr_Creacion_Exigir_Clasificacion_busqueda.Checked) & "," & vbCrLf &
                       "Pr_Creacion_Exigir_Codigo_Alternativo = " & Convert.ToInt32(Chk_Pr_Creacion_Exigir_Codigo_Alternativo.Checked) & "," & vbCrLf &
                       "Revisa_Taza_Cambio = " & Convert.ToInt32(Chk_Revisar_Tasa_de_Cambio.Checked) & "," & vbCrLf &
                       "Revisar_Taza_Solo_Mon_Extranjeras = " & Convert.ToInt32(Chk_Revisar_Taza_Solo_Mon_Extranjeras.Checked) & "," & vbCrLf &
                       "Vnta_Dias_Venci_Coti = " & Convert.ToInt32(Txt_Dias_Venci_Coti.Text) & "," & vbCrLf &
                       "Vnta_TipoValor_Bruto_Neto = '" & Cmb_TipoValor_Bruto_Neto.SelectedValue & "'," & vbCrLf &
                       "Vnta_EntidadXdefecto = '" & _Cod_EntidadXdefecto & "'," & vbCrLf &
                       "Vnta_SucEntXdefecto = '" & _Cod_SucEntXdefecto & "'," & vbCrLf &
                       "Vnta_Preguntar_Documento = " & Convert.ToInt32(Chk_Preguntar_Documento.Checked) & "," & vbCrLf &
                       "Vnta_Redondear_Dscto_Cero = " & Convert.ToInt32(Chk_Redondear_Dscto_Cero.Checked) & "," & vbCrLf &
                       "SOC_CodTurno = '" & Trim(Cmb_SOC_CodTurno.SelectedValue) & "'," & vbCrLf &
                       "SOC_Buscar_Producto = '" & Cmb_SOC_Buscar_Producto.SelectedValue & "'," & vbCrLf &
                       "SOC_Aprueba_Solo_G1 = " & Convert.ToInt32(Rdb_SOC_Aprueba_Solo_G1.Checked) & "," & vbCrLf &
                       "SOC_Aprueba_G1_y_G2 = " & Convert.ToInt32(Rdb_SOC_Aprueba_G1_y_G2.Checked) & "," & vbCrLf &
                       "SOC_Prod_Crea_Solo_Marcas_Proveedor = " & Convert.ToInt32(Chk_SOC_Prod_Crea_Solo_Marcas_Proveedor.Checked) & "," & vbCrLf &
                       "SOC_Prod_Crea_Max_Carac_Nom = " & Val(Txt_Prod_Crea_Max_Carac_Nom.Text) & "," & vbCrLf &
                       "SOC_Valor_1ra_Aprobacion = " & _SOC_Valor_1ra_Aprobacion & "," & vbCrLf &
                       "SOC_Dias_Apela = " & Val(Txt_Dias_Apela.Text) & "," & vbCrLf &
                       "SOC_Tipo_Creacion_Producto_Normal_Matriz = '" & Cmb_SOC_Tipo_Creacion_Producto_Normal_Matriz.SelectedValue & "'," & vbCrLf &
                       "Nodo_Raiz_Asociados = " & Cmb_Nodo_Raiz_Asociados.SelectedValue & "," & vbCrLf &
                       "Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente = " & Convert.ToInt32(Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente.Checked) & "," & vbCrLf &
                       "Conservar_Responzable_Doc_Relacionado = " & Convert.ToInt32(Chk_Conservar_Responzable_Doc_Relacionado.Checked) & "," & vbCrLf &
                       "Preguntar_Si_Cambia_Responsable_Doc_Relacionado = " & Convert.ToInt32(Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado.Checked) & "," & vbCrLf &
                       "Dias_Max_Fecha_Despacho = " & Input_Dias_Max_Fecha_Despacho.Value & "," & vbCrLf &
                       "Dias_Max_Fecha_Despacho_Sab = " & Convert.ToInt32(Chk_Dias_Max_Fecha_Despacho_Sab.Checked) & "," & vbCrLf &
                       "Dias_Max_Fecha_Despacho_Dom = " & Convert.ToInt32(Chk_Dias_Max_Fecha_Despacho_Dom.Checked) & "," & vbCrLf &
                       "Solicitar_Permiso_OCC_SOC = " & Convert.ToInt32(Chk_Solicitar_Permiso_OCC_SOC.Checked) & "," & vbCrLf &
                       "Centro_Costo_Obligatorio_OCC = " & Convert.ToInt32(Chk_Centro_Costo_Obligatorio_OCC.Checked) & "," & vbCrLf &
                       "No_Solicitar_Permiso_Entidad_Preferencial = " & Convert.ToInt32(Chk_No_Solicitar_Permiso_Entidad_Preferencial.Checked) & "," & vbCrLf &
                       "Utilizar_NVV_En_Credito_X_Cliente = " & Convert.ToInt32(Chk_Utilizar_NVV_En_Credito_X_Cliente.Checked) & "," & vbCrLf &
                       "No_Permitir_Grabar_Con_Dscto_Superado = " & Convert.ToInt32(Chk_No_Permitir_Grabar_Con_Dscto_Superado.Checked) & "," & vbCrLf &
                       "BloqEdiConcepDescuento = " & Convert.ToInt32(Chk_BloqEdiConcepDescuento.Checked) & "," & vbCrLf &
                       "BloqEdiConcepRecargo = " & Convert.ToInt32(Chk_BloqEdiConcepRecargo.Checked) & "," & vbCrLf &
                       "Pedir_Permiso_Para_Usar_Stanby = " & Convert.ToInt32(Chk_Pedir_Permiso_Para_Usar_Stanby.Checked) & "," & vbCrLf &
                       "Conservar_Bodega_Sig_Linea_Venta = " & Convert.ToInt32(Chk_Conservar_Bodega_Sig_Linea_Venta.Checked) & "," & vbCrLf &
                       "Grabar_Despachos_Con_Huella = " & Convert.ToInt32(Chk_Grabar_Despachos_Con_Huella.Checked) & "," & vbCrLf &
                       "Monto_Max_CRV_FacMasiva = " & Input_Monto_Max_CRV_FacMasiva.Value & "," & vbCrLf &
                       "Usar_Validador_Prod_X_Compras = " & Convert.ToInt32(Chk_Usar_Validador_Prod_X_Compras.Checked) & "," & vbCrLf &
                       "Revisar_OCC_Pendientes_X_Productos = " & Convert.ToInt32(Chk_Revisar_OCC_Pendientes_X_Productos.Checked) & "," & vbCrLf &
                       "Alerta_Costo_Lista_Distinto_Costo_Proveedor = " & Convert.ToInt32(Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor.Checked) & "," & vbCrLf &
                       "Pr_Creacion_Exigir_Dimensiones = " & Convert.ToInt32(chk_Pr_Creacion_Exigir_Dimensiones.Checked) & vbCrLf &
                       "Where Modalidad = '" & _Modalidad & "'"



        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            MessageBoxEx.Show(_FmPrincipal, "Datos actualizados correctamente", "Grabar",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
            _FmPrincipal.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
            Me.Dispose()

        Else

            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema!!", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _FmPrincipal.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
        Me.Dispose()
    End Sub

    Private Sub Txt_SOC_Valor_1ra_Aprobacion_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_SOC_Valor_1ra_Aprobacion.Validated

        _SOC_Valor_1ra_Aprobacion = Txt_SOC_Valor_1ra_Aprobacion.Text
        Txt_SOC_Valor_1ra_Aprobacion.Text = FormatCurrency(_SOC_Valor_1ra_Aprobacion, 0)

    End Sub

    Private Sub Sb_Chk_Pr_AutoPr_Crear_Codigo_Principal_Automatico_CheckedChanged(ByVal sender As System.Object, _
                                                                               ByVal e As System.EventArgs)
        Grupo_Codigo_Automatico.Enabled = Chk_Pr_AutoPr_Crear_Codigo_Principal_Automatico.Checked
    End Sub

    Private Sub Btn_Buscar_Cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Buscar_Cliente.Click

        Dim Fm As New Frm_BuscarEntidad_Mt(False)
        Fm.ShowDialog(Me)

        If Fm.Pro_Entidad_Seleccionada Then
            _Cod_EntidadXdefecto = Fm.Pro_RowEntidad.Item("KOEN")
            _Cod_SucEntXdefecto = Fm.Pro_RowEntidad.Item("SUEN")

            Txt_Cliente.Text = _Sql.Fx_Trae_Dato("MAEEN", "NOKOEN",
                                         "KOEN = '" & _Cod_EntidadXdefecto & "' AND SUEN = '" & _Cod_SucEntXdefecto & "'")
        End If

        Fm.Dispose()

    End Sub

    Private Sub Btn_Numeraciones_Documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Numeraciones_Documento.Click

        Dim Fm As New Frm_Configuracion_Estacion_Numeracion_Doc(_Row_Modalidad)
        Fm.Modalidad_General = _Modalidad_General
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_DocConceptosVsPagos_Click(sender As Object, e As EventArgs) Handles Btn_DocConceptosVsPagos.Click

        Dim Fm As New Frm_Conceptos_ObliXDoc(_Modalidad)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Excluir_Documentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excluir_Documentos.Click

        Dim _Sql_Filtro_Condicion_Extra = String.Empty

        Dim _Filtrar As New Clas_Filtros_Random(_FmPrincipal)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Documentos_Excluidos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Documentos, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            _Tbl_Filtro_Documentos_Excluidos = _Filtrar.Pro_Tbl_Filtro

        End If

    End Sub

End Class
