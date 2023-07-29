Imports System.Security.Cryptography
Imports DevComponents.DotNetBar
Public Class Frm_Configuracion_Gral

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Modalidad As String

    Dim _Cod_EntidadXdefecto, _Cod_SucEntXdefecto As String
    Dim _Cod_Vnta_Producto_NoCreado

    Dim _Row_Modalidad As DataRow
    Dim _Tbl_Filtro_Documentos_Excluidos As DataTable

    Dim _Modalidad_General As Boolean

    Dim _Union = "SELECT '' AS Padre,'' AS Hijo " & vbCrLf & "UNION" & vbCrLf
    Public Sub New(_Row_Modalidad As DataRow, _Modalidad_General As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me._Row_Modalidad = _Row_Modalidad
        Me._Modalidad_General = _Modalidad_General

        Me._Modalidad = _Row_Modalidad.Item("MODALIDAD")

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar1)

        Lbl_Monto_CRV.Enabled = _Modalidad_General
        Input_Monto_Max_CRV_FacMasiva.Enabled = _Modalidad_General

        Dim _Arr_Filtro(,) As String

        _Arr_Filtro = {{"1", "Conservar fecha actual para el documento"},
                       {"2", "Fecha de despacho igual a la fecha del documento de origen en Encabezado y Detalle"},
                       {"3", "Fecha de despacho igual a la fecha del documento de origen Solo en Detalle"}}
        Sb_Llenar_Combos(_Arr_Filtro, Cmb_CriterioFechaGDVconFechaDistintaDocOrigen)

        Txt_Lista_Precios_Proveedores.Tag = String.Empty

    End Sub

    Private Sub Frm_Configuracion_Gral_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Cmb_CriterioFechaGDVconFechaDistintaDocOrigen.SelectedValue = "1"
        SuperTabControl1.SelectedTabIndex = 0

        SpTab_DatosEmpresa.Visible = (_Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Empresas") And _Modalidad_General)
        SpTab_FincredPays.Visible = (RutEmpresaActiva = "76095906-5" Or RutEmpresaActiva = "79514800-0")
        SuperTabItem1.Visible = _Modalidad_General

        Txt_Fincred_Id_Token.Text = String.Empty

        If SpTab_DatosEmpresa.Visible Then

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Empresas Where Empresa = '" & ModEmpresa & "'"
            _Global_Row_Empresa = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Global_Row_Empresa) Then

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Empresas (Empresa,Rut,Razon,Ncorto,Direccion,Pais,Ciudad,Giro)" & vbCrLf &
                               "Select EMPRESA,RUT,RAZON,NCORTO,DIRECCION,PAIS,CIUDAD,GIRO From CONFIGP Where EMPRESA = '" & ModEmpresa & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Empresas Where Empresa = '" & ModEmpresa & "'"
                _Global_Row_Empresa = _Sql.Fx_Get_DataRow(Consulta_sql)

            End If

            Txt_CpEmpresa.Text = _Global_Row_Empresa.Item("Empresa")
            Txt_CpRut.Text = _Global_Row_Empresa.Item("Rut")
            Txt_CpNcorto.Text = _Global_Row_Empresa.Item("Ncorto")
            Txt_CpRazon.Text = _Global_Row_Empresa.Item("Razon")
            Txt_CpDireccion.Text = _Global_Row_Empresa.Item("Direccion")
            Txt_CpPais.Text = _Global_Row_Empresa.Item("Pais")
            Txt_CpCiudad.Text = _Global_Row_Empresa.Item("Ciudad")
            Txt_CpComuna.Text = _Global_Row_Empresa.Item("Comuna")
            Txt_CpGiro.Text = _Global_Row_Empresa.Item("Giro")
            Txt_CpActeco.Text = _Global_Row_Empresa.Item("Acteco").ToString.Trim

            If String.IsNullOrEmpty(Txt_CpActeco.Text) Then
                Txt_CpActeco.Text = _Global_Row_Configp.Item("ACTECO").ToString.Trim
            End If

        End If

        Sb_Cargar_Combo()

        Dim _Tidoexclu As String

        With _Row_Modalidad

            _Tidoexclu = Trim(.Item("TIDOEXCLU"))

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

            Chk_Volver_A_Solicitar_Permiso_FCV_desde_NVV.Checked = .Item("Volver_A_Solicitar_Permiso_FCV_desde_NVV")

            Txt_ValorMinimoNVV.Text = .Item("ValorMinimoNVV")


            Chk_FacElec_Bakapp_Hefesto.Checked = .Item("FacElec_Bakapp_Hefesto")
            Chk_Permisos_Descuentos_Por_Responzable.Checked = .Item("Permisos_Descuentos_Por_Responzable")
            Chk_FacElect_Usar_AmbienteCertificacion.Checked = .Item("FacElect_Usar_AmbienteCertificacion")
            Chk_Utilizar_Lectura_Codigo_QR.Checked = .Item("Utilizar_Lectura_Codigo_QR")

            Chk_Las_Cotizaciones_No_Revisan_Permisos.Checked = .Item("Las_Cotizaciones_No_Revisan_Permisos")

            Cmb_CriterioFechaGDVconFechaDistintaDocOrigen.SelectedValue = NuloPorNro(.Item("CriterioFechaGDVconFechaDistintaDocOrigen"), "1")

            If IsNothing(Cmb_CriterioFechaGDVconFechaDistintaDocOrigen.SelectedValue) Then
                Cmb_CriterioFechaGDVconFechaDistintaDocOrigen.SelectedValue = 1
            End If

            Chk_CriterioFechaGDVconFechaDistintaDocOrigenObligatorio.Checked = .Item("CriterioFechaGDVconFechaDistintaDocOrigenObligatorio")
            Chk_LeerSoloUnaVezCodBarra.Checked = .Item("LeerSoloUnaVezCodBarra")

            Chk_Incorporar_Modo_NVI_y_OCC_Asistente_Compras.Checked = .Item("Incorporar_Modo_NVI_y_OCC_Asistente_Compras")
            Chk_Actualizar_Lista_De_Costos_Random_Desde_Bakapp.Checked = .Item("Actualizar_Lista_De_Costos_Random_Desde_Bakapp")

            Chk_BloqCambNomCONCEPTOSEnDocumentos.Checked = .Item("BloqCambNomCONCEPTOSEnDocumentos")

            Chk_PermitirMigrarProductosBaseExterna.Checked = .Item("PermitirMigrarProductosBaseExterna")

            Txt_Lista_Precios_Proveedores.Tag = .Item("Lista_Precios_Proveedores").ToString.Trim

            Consulta_sql = "Select * From TABPP Where KOLT = '" & Txt_Lista_Precios_Proveedores.Tag & "'"
            Dim _RowLista As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_RowLista) Then
                Txt_Lista_Precios_Proveedores.Text = _RowLista.Item("KOLT") & " - " & _RowLista.Item("NOKOLT")
            End If

            If SpTab_FincredPays.Visible Then

                Txt_Fincred_Id_Token.Tag = .Item("Fincred_Id_Token")
                Chk_Fincred_Usar.Checked = .Item("Fincred_Usar")
                Sb_Revisar_Fincred_Token(Txt_Fincred_Id_Token.Tag)

            End If

            Chk_ListaDesdeSustentatorio.Checked = .Item("ListaDesdeSustentatorio")
            Rdb_Crear_FCC_Desde_GRC_Vinculado_SII.Checked = .Item("Crear_FCC_Desde_GRC_Vinculado_SII")
            Chk_AlertaRevNVVConVtasMismoDia.Checked = .Item("AlertaRevNVVConVtasMismoDia")

            Chk_LasNVVDebenSerHabilitadasParaFacturar.Checked = .Item("LasNVVDebenSerHabilitadasParaFacturar")
            Chk_B4A_DespachoSimple.Checked = .Item("B4A_DespachoSimple")

            Chk_GrabarPreciosHistoricos.Checked = .Item("GrabarPreciosHistoricos")

            Chk_Patentes_rvm.Checked = .Item("Patentes_rvm")

            Chk_BloqueaClasificacionLibre.Checked = .Item("BloqueaClasificacionLibre")
            Chk_BloqueaFamilias.Checked = .Item("BloqueaFamilias")
            Chk_BloqueaMarcas.Checked = .Item("BloqueaMarcas")
            Chk_BloqueaRubros.Checked = .Item("BloqueaRubros")
            Chk_BloqueaZonaProductos.Checked = .Item("BloqueaZonaProductos")


        End With

        Rdb_Crear_FCC_Desde_GRC_Vinculado_SII.Enabled = Not _Modalidad_General

        Chk_Revisar_Tasa_de_Cambio.Enabled = _Modalidad_General
        Chk_Revisar_Taza_Solo_Mon_Extranjeras.Enabled = _Modalidad_General
        Chk_BloqEdiConcepDescuento.Enabled = _Modalidad_General
        Chk_BloqEdiConcepRecargo.Enabled = _Modalidad_General
        Chk_Pedir_Permiso_Para_Usar_Stanby.Enabled = _Modalidad_General
        Chk_FacElec_Bakapp_Hefesto.Enabled = _Modalidad_General

        If Not _Modalidad_General Then
            Chk_FacElect_Usar_AmbienteCertificacion.Enabled = _Global_Row_Configuracion_General.Item("FacElec_Bakapp_Hefesto")
        End If

        Chk_Utilizar_Lectura_Codigo_QR.Enabled = Not _Modalidad_General

        Chk_Pr_Desc_Producto_Solo_Mayusculas.Enabled = _Modalidad_General
        Chk_Pr_Creacion_Exigir_Precio.Enabled = _Modalidad_General
        Chk_Pr_Creacion_Exigir_Clasificacion_busqueda.Enabled = _Modalidad_General
        Chk_Pr_Creacion_Exigir_Codigo_Alternativo.Enabled = _Modalidad_General
        chk_Pr_Creacion_Exigir_Dimensiones.Enabled = _Modalidad_General

        Chk_Centro_Costo_Obligatorio_OCC.Enabled = _Modalidad_General
        Chk_Solicitar_Permiso_OCC_SOC.Enabled = _Modalidad_General
        Chk_Usar_Validador_Prod_X_Compras.Enabled = _Modalidad_General
        Chk_No_Permitir_Grabar_Con_Dscto_Superado.Enabled = _Modalidad_General
        Chk_No_Solicitar_Permiso_Entidad_Preferencial.Enabled = _Modalidad_General

        Chk_Conservar_Responzable_Doc_Relacionado.Enabled = _Modalidad_General
        Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado.Enabled = _Modalidad_General
        Chk_Volver_A_Solicitar_Permiso_FCV_desde_NVV.Enabled = _Modalidad_General
        Chk_Revisar_OCC_Pendientes_X_Productos.Enabled = _Modalidad_General
        Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor.Enabled = _Modalidad_General

        Chk_Permisos_Descuentos_Por_Responzable.Enabled = _Modalidad_General
        Chk_Las_Cotizaciones_No_Revisan_Permisos.Enabled = _Modalidad_General

        Btn_Asociar_Prod_Funcionarios.Enabled = Chk_Usar_Validador_Prod_X_Compras.Checked

        LabelX17.Enabled = _Modalidad_General
        Cmb_CriterioFechaGDVconFechaDistintaDocOrigen.Enabled = _Modalidad_General
        Chk_CriterioFechaGDVconFechaDistintaDocOrigenObligatorio.Enabled = _Modalidad_General
        Chk_LeerSoloUnaVezCodBarra.Enabled = _Modalidad_General
        Chk_Incorporar_Modo_NVI_y_OCC_Asistente_Compras.Enabled = _Modalidad_General
        Chk_BloqCambNomCONCEPTOSEnDocumentos.Enabled = _Modalidad_General

        Chk_PermitirMigrarProductosBaseExterna.Enabled = _Modalidad_General
        Chk_ListaDesdeSustentatorio.Enabled = _Modalidad_General

        Chk_Actualizar_Lista_De_Costos_Random_Desde_Bakapp.Enabled = _Modalidad_General
        LabelX20.Enabled = _Modalidad_General
        Txt_Lista_Precios_Proveedores.Enabled = _Modalidad_General

        Chk_GrabarPreciosHistoricos.Enabled = _Modalidad_General

        Txt_Fincred_Id_Token.Enabled = Not _Modalidad_General

        Btn_FincredConfiguracion.Enabled = _Modalidad_General
        LabelX22.Enabled = _Modalidad_General
        Line1.Enabled = _Modalidad_General

        Chk_AlertaRevNVVConVtasMismoDia.Enabled = Not _Modalidad_General
        Chk_LasNVVDebenSerHabilitadasParaFacturar.Enabled = _Modalidad_General
        Chk_B4A_DespachoSimple.Enabled = Not _Modalidad_General

        Chk_Patentes_rvm.Enabled = _Modalidad_General

        Chk_BloqueaClasificacionLibre.Enabled = _Modalidad_General
        Chk_BloqueaFamilias.Enabled = _Modalidad_General
        Chk_BloqueaMarcas.Enabled = _Modalidad_General
        Chk_BloqueaRubros.Enabled = _Modalidad_General
        Chk_BloqueaZonaProductos.Enabled = _Modalidad_General

        AddHandler Txt_Dias_Venci_Coti.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros_Enteros
        AddHandler Txt_ValorMinimoNVV.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros_Enteros

        If _Modalidad_General Then
            Me.Text = "CONFIGURACION DE MODALIDAD GENERAL"
            Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente.Enabled = False
        Else
            Me.Text = "MODALIDAD " & _Modalidad
        End If

        If Not String.IsNullOrEmpty(_Tidoexclu) Then

            Dim _Tidos = Split(_Tidoexclu, ",")

            Dim _Fl = Generar_Filtro_IN_Arreglo(_Tidos, False)

            Consulta_sql = "Select TIDO As Codigo,NOTIDO As Descripcion From TABTIDO Where TIDO In " & _Fl
            _Tbl_Filtro_Documentos_Excluidos = _Sql.Fx_Get_Tablas(Consulta_sql)

        End If

    End Sub

    Private Sub Frm_Configuracion_Gral_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        Dim _Mod As New Clas_Modalidades

        _Global_Row_Configuracion_General = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.General, "")
        _Global_Row_Configuracion_Estacion = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.Estacion, Modalidad)

    End Sub

    Private Sub Btn_Numeraciones_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Numeraciones_Documento.Click

        Dim Fm As New Frm_Configuracion_Estacion_Numeracion_Doc(_Row_Modalidad)
        Fm.Modalidad_General = _Modalidad_General
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Excluir_Documentos_Click(sender As Object, e As EventArgs) Handles Btn_Excluir_Documentos.Click

        Dim _Sql_Filtro_Condicion_Extra = String.Empty

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Filtro_Documentos_Excluidos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Documentos, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            _Tbl_Filtro_Documentos_Excluidos = _Filtrar.Pro_Tbl_Filtro

        End If

    End Sub

    Private Sub Btn_DocConceptosVsPagos_Click(sender As Object, e As EventArgs) Handles Btn_DocConceptosVsPagos.Click

        Dim Fm As New Frm_Conceptos_ObliXDoc(_Modalidad)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        '"Where Modalidad = '  '"

        'Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Configuracion_General" & vbCrLf &
        '               "Insert Into " & _Global_BaseBk & "Zw_Configuracion_General (Version,Revisa_Taza_Cambio,Vnta_Dias_Venci_Coti,SOC_CodTurno) Values " &
        '               "('3'," & CInt(Chk_Revisar_Tasa_de_Cambio.Checked) * -1 & "," & CInt(Txt_Dias_Venci_Coti.Text) & ",'" & Trim(Cmb_SOC_CodTurno.SelectedValue) & "')"

        If SpTab_DatosEmpresa.Visible Then

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Empresas Set " & vbCrLf &
                           "Rut = '" & Txt_CpRut.Text.Trim & "'," &
                           "Razon = '" & Txt_CpRazon.Text.Trim & "'," &
                           "Ncorto = '" & Txt_CpNcorto.Text.Trim & "'," &
                           "Direccion = '" & Txt_CpDireccion.Text.Trim & "'," &
                           "Pais = '" & Txt_CpPais.Text.Trim & "'," &
                           "Ciudad = '" & Txt_CpCiudad.Text.Trim & "'," &
                           "Comuna = '" & Txt_CpComuna.Text.Trim & "'," &
                           "Giro = '" & Txt_CpGiro.Text.Trim & "'," &
                           "Acteco = '" & Txt_CpActeco.Text.Trim & "'" & vbCrLf &
                           "Where Empresa = '" & Txt_CpEmpresa.Text.Trim & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

        If String.IsNullOrEmpty(Cmb_Nodo_Raiz_Asociados.SelectedValue) Then
            Cmb_Nodo_Raiz_Asociados.SelectedValue = "0"
        End If

        Consulta_sql = "Update CONFIEST Set TIDOEXCLU = '' Where EMPRESA = '" & ModEmpresa & "' And MODALIDAD = '" & _Modalidad & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql)
        Dim _Bodegas_Excluidas = String.Empty

        If Not IsNothing(_Tbl_Filtro_Documentos_Excluidos) Then
            For Each _Fl As DataRow In _Tbl_Filtro_Documentos_Excluidos.Rows
                _Bodegas_Excluidas += _Fl.Item("Codigo") & ","
            Next
        End If

        If Not String.IsNullOrEmpty(_Bodegas_Excluidas) Then
            Consulta_sql = "Update CONFIEST Set TIDOEXCLU = '" & _Bodegas_Excluidas & "' Where EMPRESA = '" & ModEmpresa & "' And MODALIDAD = '" & _Modalidad & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        'If Not Chk_FacElec_Bakapp_Hefesto.Checked Then
        '    Chk_FacElect_Usar_AmbienteCertificacion.Checked = False
        'End If

        If Chk_FacElect_Usar_AmbienteCertificacion.Checked Then

            If MessageBoxEx.Show(Me, "Esta modalidad quedara en modo Ambiente de Certificación y Pruebas" & vbCrLf & vbCrLf &
                                 "¿Confirma esta condición?",
                                 "Modo Certificación Factura Eléctronica SII", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                Return
            End If

        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Configuracion Set" & vbCrLf &
                       " Pr_Desc_Producto_Solo_Mayusculas = " & Convert.ToInt32(Chk_Pr_Desc_Producto_Solo_Mayusculas.Checked) & vbCrLf &
                       ",Pr_Creacion_Exigir_Precio = " & Convert.ToInt32(Chk_Pr_Creacion_Exigir_Precio.Checked) & vbCrLf &
                       ",Pr_Creacion_Exigir_Clasificacion_busqueda = " & Convert.ToInt32(Chk_Pr_Creacion_Exigir_Clasificacion_busqueda.Checked) & vbCrLf &
                       ",Pr_Creacion_Exigir_Codigo_Alternativo = " & Convert.ToInt32(Chk_Pr_Creacion_Exigir_Codigo_Alternativo.Checked) & vbCrLf &
                       ",Revisa_Taza_Cambio = " & Convert.ToInt32(Chk_Revisar_Tasa_de_Cambio.Checked) & vbCrLf &
                       ",Revisar_Taza_Solo_Mon_Extranjeras = " & Convert.ToInt32(Chk_Revisar_Taza_Solo_Mon_Extranjeras.Checked) & vbCrLf &
                       ",Vnta_Dias_Venci_Coti = " & Convert.ToInt32(Txt_Dias_Venci_Coti.Text) & vbCrLf &
                       ",Vnta_TipoValor_Bruto_Neto = '" & Cmb_TipoValor_Bruto_Neto.SelectedValue & "'" & vbCrLf &
                       ",Vnta_EntidadXdefecto = '" & _Cod_EntidadXdefecto & "'" & vbCrLf &
                       ",Vnta_SucEntXdefecto = '" & _Cod_SucEntXdefecto & "'" & vbCrLf &
                       ",Vnta_Preguntar_Documento = " & Convert.ToInt32(Chk_Preguntar_Documento.Checked) & vbCrLf &
                       ",Vnta_Redondear_Dscto_Cero = " & Convert.ToInt32(Chk_Redondear_Dscto_Cero.Checked) & vbCrLf &
                       ",Nodo_Raiz_Asociados = " & Cmb_Nodo_Raiz_Asociados.SelectedValue & vbCrLf &
                       ",Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente = " & Convert.ToInt32(Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente.Checked) & vbCrLf &
                       ",Conservar_Responzable_Doc_Relacionado = " & Convert.ToInt32(Chk_Conservar_Responzable_Doc_Relacionado.Checked) & vbCrLf &
                       ",Preguntar_Si_Cambia_Responsable_Doc_Relacionado = " & Convert.ToInt32(Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado.Checked) & vbCrLf &
                       ",Dias_Max_Fecha_Despacho = " & Input_Dias_Max_Fecha_Despacho.Value & vbCrLf &
                       ",Dias_Max_Fecha_Despacho_Sab = " & Convert.ToInt32(Chk_Dias_Max_Fecha_Despacho_Sab.Checked) & vbCrLf &
                       ",Dias_Max_Fecha_Despacho_Dom = " & Convert.ToInt32(Chk_Dias_Max_Fecha_Despacho_Dom.Checked) & vbCrLf &
                       ",Solicitar_Permiso_OCC_SOC = " & Convert.ToInt32(Chk_Solicitar_Permiso_OCC_SOC.Checked) & vbCrLf &
                       ",Crear_FCC_Desde_GRC_Vinculado_SII = " & Convert.ToInt32(Rdb_Crear_FCC_Desde_GRC_Vinculado_SII.Checked) & vbCrLf &
                       ",Centro_Costo_Obligatorio_OCC = " & Convert.ToInt32(Chk_Centro_Costo_Obligatorio_OCC.Checked) & vbCrLf &
                       ",No_Solicitar_Permiso_Entidad_Preferencial = " & Convert.ToInt32(Chk_No_Solicitar_Permiso_Entidad_Preferencial.Checked) & vbCrLf &
                       ",Utilizar_NVV_En_Credito_X_Cliente = " & Convert.ToInt32(Chk_Utilizar_NVV_En_Credito_X_Cliente.Checked) & vbCrLf &
                       ",Volver_A_Solicitar_Permiso_FCV_desde_NVV = " & Convert.ToInt32(Chk_Volver_A_Solicitar_Permiso_FCV_desde_NVV.Checked) & vbCrLf &
                       ",No_Permitir_Grabar_Con_Dscto_Superado = " & Convert.ToInt32(Chk_No_Permitir_Grabar_Con_Dscto_Superado.Checked) & vbCrLf &
                       ",BloqEdiConcepDescuento = " & Convert.ToInt32(Chk_BloqEdiConcepDescuento.Checked) & vbCrLf &
                       ",BloqEdiConcepRecargo = " & Convert.ToInt32(Chk_BloqEdiConcepRecargo.Checked) & vbCrLf &
                       ",Pedir_Permiso_Para_Usar_Stanby = " & Convert.ToInt32(Chk_Pedir_Permiso_Para_Usar_Stanby.Checked) & vbCrLf &
                       ",Conservar_Bodega_Sig_Linea_Venta = " & Convert.ToInt32(Chk_Conservar_Bodega_Sig_Linea_Venta.Checked) & vbCrLf &
                       ",Grabar_Despachos_Con_Huella = " & Convert.ToInt32(Chk_Grabar_Despachos_Con_Huella.Checked) & vbCrLf &
                       ",Monto_Max_CRV_FacMasiva = " & Input_Monto_Max_CRV_FacMasiva.Value & vbCrLf &
                       ",Usar_Validador_Prod_X_Compras = " & Convert.ToInt32(Chk_Usar_Validador_Prod_X_Compras.Checked) & vbCrLf &
                       ",Revisar_OCC_Pendientes_X_Productos = " & Convert.ToInt32(Chk_Revisar_OCC_Pendientes_X_Productos.Checked) & vbCrLf &
                       ",Alerta_Costo_Lista_Distinto_Costo_Proveedor = " & Convert.ToInt32(Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor.Checked) & vbCrLf &
                       ",Pr_Creacion_Exigir_Dimensiones = " & Convert.ToInt32(chk_Pr_Creacion_Exigir_Dimensiones.Checked) & vbCrLf &
                       ",ValorMinimoNVV = " & Val(Txt_ValorMinimoNVV.Text) & vbCrLf &
                       ",FacElec_Bakapp_Hefesto = " & Convert.ToInt32(Chk_FacElec_Bakapp_Hefesto.Checked) & vbCrLf &
                       ",Permisos_Descuentos_Por_Responzable = " & Convert.ToInt32(Chk_Permisos_Descuentos_Por_Responzable.Checked) & vbCrLf &
                       ",FacElect_Usar_AmbienteCertificacion = " & Convert.ToInt32(Chk_FacElect_Usar_AmbienteCertificacion.Checked) & vbCrLf &
                       ",Utilizar_Lectura_Codigo_QR = " & Convert.ToInt32(Chk_Utilizar_Lectura_Codigo_QR.Checked) & vbCrLf &
                       ",Las_Cotizaciones_No_Revisan_Permisos = " & Convert.ToInt32(Chk_Las_Cotizaciones_No_Revisan_Permisos.Checked) & vbCrLf &
                       ",CriterioFechaGDVconFechaDistintaDocOrigen = " & Cmb_CriterioFechaGDVconFechaDistintaDocOrigen.SelectedValue & vbCrLf &
                       ",CriterioFechaGDVconFechaDistintaDocOrigenObligatorio = " & Convert.ToInt32(Chk_CriterioFechaGDVconFechaDistintaDocOrigenObligatorio.Checked) & vbCrLf &
                       ",LeerSoloUnaVezCodBarra = " & Convert.ToInt32(Chk_LeerSoloUnaVezCodBarra.Checked) & vbCrLf &
                       ",Incorporar_Modo_NVI_y_OCC_Asistente_Compras = " & Convert.ToInt32(Chk_Incorporar_Modo_NVI_y_OCC_Asistente_Compras.Checked) & vbCrLf &
                       ",Actualizar_Lista_De_Costos_Random_Desde_Bakapp = " & Convert.ToInt32(Chk_Actualizar_Lista_De_Costos_Random_Desde_Bakapp.Checked) & vbCrLf &
                       ",BloqCambNomCONCEPTOSEnDocumentos = " & Convert.ToInt32(Chk_BloqCambNomCONCEPTOSEnDocumentos.Checked) & vbCrLf &
                       ",PermitirMigrarProductosBaseExterna = " & Convert.ToInt32(Chk_PermitirMigrarProductosBaseExterna.Checked) & vbCrLf &
                       ",Lista_Precios_Proveedores = '" & Txt_Lista_Precios_Proveedores.Tag & "'" & vbCrLf &
                       ",Fincred_Usar = " & Convert.ToInt32(Chk_Fincred_Usar.Checked) & vbCrLf &
                       ",Fincred_Id_Token = " & Txt_Fincred_Id_Token.Tag & vbCrLf &
                       ",ListaDesdeSustentatorio = " & Convert.ToInt32(Chk_ListaDesdeSustentatorio.Checked) & vbCrLf &
                       ",AlertaRevNVVConVtasMismoDia = " & Convert.ToInt32(Chk_AlertaRevNVVConVtasMismoDia.Checked) & vbCrLf &
                       ",LasNVVDebenSerHabilitadasParaFacturar = " & Convert.ToInt32(Chk_LasNVVDebenSerHabilitadasParaFacturar.Checked) & vbCrLf &
                       ",B4A_DespachoSimple = " & Convert.ToInt32(Chk_B4A_DespachoSimple.Checked) & vbCrLf &
                       ",GrabarPreciosHistoricos = " & Convert.ToInt32(Chk_GrabarPreciosHistoricos.Checked) & vbCrLf &
                       ",Patentes_rvm = " & Convert.ToInt32(Chk_Patentes_rvm.Checked) & vbCrLf &
                       ",BloqueaMarcas = " & Convert.ToInt32(Chk_BloqueaMarcas.Checked) & vbCrLf &
                       ",BloqueaRubros = " & Convert.ToInt32(Chk_BloqueaRubros.Checked) & vbCrLf &
                       ",BloqueaClasificacionLibre = " & Convert.ToInt32(Chk_BloqueaClasificacionLibre.Checked) & vbCrLf &
                       ",BloqueaZonaProductos = " & Convert.ToInt32(Chk_BloqueaZonaProductos.Checked) & vbCrLf &
                       ",BloqueaFamilias = " & Convert.ToInt32(Chk_BloqueaFamilias.Checked) & vbCrLf &
                       "Where Empresa = '" & ModEmpresa & "' And Modalidad = '" & _Modalidad & "'"

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
            Me.Close()

        Else

            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema!!", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub Btn_Asociar_Prod_Funcionarios_Click(sender As Object, e As EventArgs) Handles Btn_Asociar_Prod_Funcionarios.Click

        Dim Fm As New Frm_Prod_Vs_Funcionarios_Fun
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Chk_Usar_Validador_Prod_X_Compras_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Usar_Validador_Prod_X_Compras.CheckedChanged
        Btn_Asociar_Prod_Funcionarios.Enabled = Chk_Usar_Validador_Prod_X_Compras.Checked
    End Sub

    Private Sub Btn_Buscar_Cliente_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Cliente.Click

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

    Private Sub Btn_Editar_Datos_Empresa_Click(sender As Object, e As EventArgs) Handles Btn_Editar_Datos_Empresa.Click

        Txt_CpRut.Enabled = True
        Txt_CpNcorto.Enabled = True
        Txt_CpRazon.Enabled = True
        Txt_CpDireccion.Enabled = True
        Txt_CpPais.Enabled = True
        Txt_CpCiudad.Enabled = True
        Txt_CpComuna.Enabled = True
        Txt_CpGiro.Enabled = True
        Txt_CpActeco.Enabled = True

        Txt_CpRut.Focus()

        MessageBoxEx.Show(Me, "Ahora es posible actualizar los datos de la empresa" & vbCrLf &
                          "De igual forma para que los datos se modifiquen debe grabar el formulario", "Editar datos de la empresa",
                                                                                                       MessageBoxButtons.OK, MessageBoxIcon.Information)

        Btn_Editar_Datos_Empresa.Enabled = False

    End Sub

    Private Sub Chk_FacElec_Bakapp_Hefesto_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_FacElec_Bakapp_Hefesto.CheckedChanged
        'Chk_FacElect_Usar_AmbienteCertificacion.Enabled = Chk_FacElec_Bakapp_Hefesto.Checked
    End Sub

    Private Sub Chk_Actualizar_Lista_De_Costos_Random_Desde_Bakapp_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Actualizar_Lista_De_Costos_Random_Desde_Bakapp.CheckedChanged
        LabelX20.Enabled = Chk_Actualizar_Lista_De_Costos_Random_Desde_Bakapp.Checked
        Txt_Lista_Precios_Proveedores.Enabled = Chk_Actualizar_Lista_De_Costos_Random_Desde_Bakapp.Checked
    End Sub

    Private Sub Txt_Lista_Precios_Proveedores_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Lista_Precios_Proveedores.ButtonCustomClick

        Dim Fm As New Frm_SeleccionarListaPrecios(Frm_SeleccionarListaPrecios.Enum_Tipo_Lista.Costo, False, False)
        Fm.ShowDialog(Me)
        Dim _Tbl_Lista_Seleccionada = Fm.Pro_Tbl_Listas_Seleccionadas
        Fm.Dispose()

        If Not (_Tbl_Lista_Seleccionada Is Nothing) Then
            Txt_Lista_Precios_Proveedores.Tag = _Tbl_Lista_Seleccionada.Rows(0).Item("Lista")
            Txt_Lista_Precios_Proveedores.Text = _Tbl_Lista_Seleccionada.Rows(0).Item("Lista").ToString.Trim &
                                                " - " & _Tbl_Lista_Seleccionada.Rows(0).Item("Nombre_Lista").ToString.Trim
        End If

    End Sub

    Private Sub Btn_FincredConfiguracion_Click(sender As Object, e As EventArgs) Handles Btn_FincredConfiguracion.Click

        Dim Fm As New Frm_FincredTokens
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Txt_TokenFincred_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Fincred_Id_Token.ButtonCustomClick

        Dim Fm As New Frm_FincredTokens
        Fm.Seleccionar = True
        Fm.ShowDialog(Me)
        If Not IsNothing(Fm.RowToken) Then
            Sb_Revisar_Fincred_Token(Fm.RowToken.Item("Id"))
        End If
        Fm.Dispose()

    End Sub

    Sub Sb_Revisar_Fincred_Token(_Id As Integer)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Fincred_Config Where Id = " & _Id
        Dim _RowToken As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_RowToken) Then
            Txt_Fincred_Id_Token.Tag = _RowToken.Item("Id")
            Txt_Fincred_Id_Token.Text = _RowToken.Item("Token") & " - Nombre Sucursal: " & _RowToken.Item("NombreSucursal")

            If _RowToken.Item("AmbientePruebas") Then
                Txt_Fincred_Id_Token.Text += ", Ambiente de pruebas"
            End If
        Else
            Txt_Fincred_Id_Token.Tag = 0
            Txt_Fincred_Id_Token.Text = "No hay Token asignado, no se revisara el crédito en esta modalidad..."
            If _Modalidad_General Then
                Txt_Fincred_Id_Token.Text = String.Empty
            End If
        End If

    End Sub

    Private Sub Txt_Fincred_Id_Token_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Fincred_Id_Token.ButtonCustom2Click

        If MessageBoxEx.Show(Me, "¿Confirma quitar el Token actual?", "Quitar Token",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Sb_Revisar_Fincred_Token(0)
        End If

    End Sub

    Sub Sb_Cargar_Combo()

        'caract_combo(Cmb_SOC_CodTurno)

        'Consulta_sql = "SELECT '' AS Padre,'' AS Hijo" & vbCrLf &
        '               "Union" & vbCrLf &
        '               "SELECT CodTurno AS Padre,Nombre_Turno AS Hijo" & vbCrLf &
        '               "FROM " & _Global_BaseBk & "Zw_Turnos" & vbCrLf &
        '               "ORDER BY Padre"

        'Cmb_SOC_CodTurno.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        'Dim _Arr_Busca_Pr(,) As String = {{"0", "MAESTRA PRODUCTOS"}, {"1", "PRODUCTOS DEL PROVEEDOR"}}
        'Sb_Llenar_Combos(_Arr_Busca_Pr, Cmb_SOC_Buscar_Producto)
        'Cmb_SOC_Buscar_Producto.SelectedValue = "1"


        Dim _Arr_TipoValor_Bruto_Neto(,) As String = {{"N", "NETO"}, {"B", "BRUTO"}}
        Sb_Llenar_Combos(_Arr_TipoValor_Bruto_Neto, Cmb_TipoValor_Bruto_Neto)
        Cmb_TipoValor_Bruto_Neto.SelectedValue = "N"


        'Dim _Arr_SOC_Tipo_Creacion_Producto_Normal_Matriz(,) As String = {{"1", "FORMULARIO CLASICO"}, {"2", "FORMULARIO MATRIZ"}}
        'Sb_Llenar_Combos(_Arr_SOC_Tipo_Creacion_Producto_Normal_Matriz, Cmb_SOC_Tipo_Creacion_Producto_Normal_Matriz)
        'Cmb_SOC_Tipo_Creacion_Producto_Normal_Matriz.SelectedValue = "1"

        'Dim _Arr_Tablas_Para_Iniciales_Cod_Automatico(,) As String = {{"MARCAS", "MARCAS"},
        '                                                              {"FAMILIAS", "SUPER FAMILIA"},
        '                                                              {"RUBROS", "RUBROS"},
        '                                                              {"CLASLIBRE", "CLASIFICACION LIBRE"}}
        'Sb_Llenar_Combos(_Arr_Tablas_Para_Iniciales_Cod_Automatico, Cmb_Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico)
        'Cmb_Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico.SelectedValue = "MARCAS"


        caract_combo(Cmb_Nodo_Raiz_Asociados)
        Consulta_sql = "SELECT '0' AS Padre,'' AS Hijo " & vbCrLf & "Union" & vbCrLf &
                       "SELECT Codigo_Nodo AS Padre,Descripcion AS Hijo" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                       "WHERE Nodo_Raiz = 0" & vbCrLf &
                       "ORDER BY Padre"
        Cmb_Nodo_Raiz_Asociados.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Nodo_Raiz_Asociados.SelectedValue = "0"

    End Sub

End Class
