Imports BkSpecialPrograms.Tablas_Configuracion

Public Class Cl_ConfiModalGral

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

    End Sub

    Function Fx_Llenar_Zw_Configuracion(_Empresa As String, _Modalidad As String) As Tablas_Configuracion.Zw_Configuracion

        Dim _Zw_Configuracion As New Tablas_Configuracion.Zw_Configuracion

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Configuracion Where Empresa = '" & _Empresa & "' And Modalidad = '" & _Modalidad & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        With _Zw_Configuracion

            .Empresa = _Row.Item("Empresa")
            .Modalidad = _Row.Item("Modalidad")
            .Pr_AutoPr_Crear_Codigo_Principal_Automatico = _Row.Item("Pr_AutoPr_Crear_Codigo_Principal_Automatico")
            .Pr_AutoPr_Correlativo_Por_Iniciales = _Row.Item("Pr_AutoPr_Correlativo_Por_Iniciales")
            .Pr_AutoPr_Correlativo_General = _Row.Item("Pr_AutoPr_Correlativo_General")
            .Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico = _Row.Item("Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico")
            .Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo = _Row.Item("Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo")
            .Pr_AutoPr_Ultimo_Codigo_Creado_Correlativo_General = _Row.Item("Pr_AutoPr_Ultimo_Codigo_Creado_Correlativo_General")
            .Pr_Desc_Producto_Solo_Mayusculas = _Row.Item("Pr_Desc_Producto_Solo_Mayusculas")
            .Pr_Creacion_Exigir_Precio = _Row.Item("Pr_Creacion_Exigir_Precio")
            .Pr_Creacion_Exigir_Clasificacion_busqueda = _Row.Item("Pr_Creacion_Exigir_Clasificacion_busqueda")
            .Pr_Creacion_Exigir_Codigo_Alternativo = _Row.Item("Pr_Creacion_Exigir_Codigo_Alternativo")
            .Tbl_Ranking = _Row.Item("Tbl_Ranking")
            .Revisa_Taza_Cambio = _Row.Item("Revisa_Taza_Cambio")
            .Revisar_Taza_Solo_Mon_Extranjeras = _Row.Item("Revisar_Taza_Solo_Mon_Extranjeras")
            .Vnta_Dias_Venci_Coti = _Row.Item("Vnta_Dias_Venci_Coti")
            .Vnta_TipoValor_Bruto_Neto = _Row.Item("Vnta_TipoValor_Bruto_Neto")
            .Vnta_EntidadXdefecto = _Row.Item("Vnta_EntidadXdefecto")
            .Vnta_SucEntXdefecto = _Row.Item("Vnta_SucEntXdefecto")
            .Vnta_Producto_NoCreado = _Row.Item("Vnta_Producto_NoCreado")
            .Vnta_Preguntar_Documento = _Row.Item("Vnta_Preguntar_Documento")
            .SOC_CodTurno = _Row.Item("SOC_CodTurno")
            .SOC_Buscar_Producto = _Row.Item("SOC_Buscar_Producto")
            .SOC_Aprueba_Solo_G1 = _Row.Item("SOC_Aprueba_Solo_G1")
            .SOC_Aprueba_G1_y_G2 = _Row.Item("SOC_Aprueba_G1_y_G2")
            .SOC_Prod_Crea_Solo_Marcas_Proveedor = _Row.Item("SOC_Prod_Crea_Solo_Marcas_Proveedor")
            .SOC_Prod_Crea_Max_Carac_Nom = _Row.Item("SOC_Prod_Crea_Max_Carac_Nom")
            .SOC_Valor_1ra_Aprobacion = _Row.Item("SOC_Valor_1ra_Aprobacion")
            .SOC_Dias_Apela = _Row.Item("SOC_Dias_Apela")
            .SOC_Tipo_Creacion_Producto_Normal_Matriz = _Row.Item("SOC_Tipo_Creacion_Producto_Normal_Matriz")
            .Precio_Costos_Desde = _Row.Item("Precio_Costos_Desde")
            .Precios_Venta_Desde_Random = _Row.Item("Precios_Venta_Desde_Random")
            .Precios_Venta_Desde_BakApp = _Row.Item("Precios_Venta_Desde_BakApp")
            .Vnta_Redondear_Dscto_Cero = _Row.Item("Vnta_Redondear_Dscto_Cero")
            .Nodo_Raiz_Asociados = _Row.Item("Nodo_Raiz_Asociados")
            .Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente = _Row.Item("Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente")
            .Conservar_Responzable_Doc_Relacionado = _Row.Item("Conservar_Responzable_Doc_Relacionado")
            .Preguntar_Si_Cambia_Responsable_Doc_Relacionado = _Row.Item("Preguntar_Si_Cambia_Responsable_Doc_Relacionado")
            .ServTecnico_Empresa = _Row.Item("ServTecnico_Empresa")
            .ServTecnico_Sucursal = _Row.Item("ServTecnico_Sucursal")
            .ServTecnico_Bodega = _Row.Item("ServTecnico_Bodega")
            .Dias_Max_Fecha_Despacho = _Row.Item("Dias_Max_Fecha_Despacho")
            .Dias_Max_Fecha_Despacho_Sab = _Row.Item("Dias_Max_Fecha_Despacho_Sab")
            .Dias_Max_Fecha_Despacho_Dom = _Row.Item("Dias_Max_Fecha_Despacho_Dom")
            .Solicitar_Permiso_OCC_SOC = _Row.Item("Solicitar_Permiso_OCC_SOC")
            .Centro_Costo_Obligatorio_OCC = _Row.Item("Centro_Costo_Obligatorio_OCC")
            .Dias_Para_Hacer_NCV = _Row.Item("Dias_Para_Hacer_NCV")
            .Dias_Para_Hacer_NCV_Oblig = _Row.Item("Dias_Para_Hacer_NCV_Oblig")
            .Dimension_Compra_Prod_Proyec_Oblig = _Row.Item("Dimension_Compra_Prod_Proyec_Oblig")
            .Nombre_Usuario_Correo_Remotas = _Row.Item("Nombre_Usuario_Correo_Remotas")
            .Crear_FCC_Desde_GRC_Vinculado_SII = _Row.Item("Crear_FCC_Desde_GRC_Vinculado_SII")
            .Conservar_Vendedor_No_Preguntar = _Row.Item("Conservar_Vendedor_No_Preguntar")
            .Lista_Precios_Proveedores = _Row.Item("Lista_Precios_Proveedores")
            .No_Solicitar_Permiso_Entidad_Preferencial = _Row.Item("No_Solicitar_Permiso_Entidad_Preferencial")
            .Utilizar_NVV_En_Credito_X_Cliente = _Row.Item("Utilizar_NVV_En_Credito_X_Cliente")
            .Volver_A_Solicitar_Permiso_FCV_desde_NVV = _Row.Item("Volver_A_Solicitar_Permiso_FCV_desde_NVV")
            .No_Permitir_Grabar_Con_Dscto_Superado = _Row.Item("No_Permitir_Grabar_Con_Dscto_Superado")
            .BloqEdiConcepDescuento = _Row.Item("BloqEdiConcepDescuento")
            .BloqEdiConcepRecargo = _Row.Item("BloqEdiConcepRecargo")
            .Solo_Supervisores_Dan_Permisos = _Row.Item("Solo_Supervisores_Dan_Permisos")
            .Pedir_Permiso_Para_Usar_Stanby = _Row.Item("Pedir_Permiso_Para_Usar_Stanby")
            .Utilizar_Ubicaciones_WCM = _Row.Item("Utilizar_Ubicaciones_WCM")
            .Conservar_Bodega_Sig_Linea_Venta = _Row.Item("Conservar_Bodega_Sig_Linea_Venta")
            .Grabar_Despachos_Con_Huella = _Row.Item("Grabar_Despachos_Con_Huella")
            .Monto_Max_CRV_FacMasiva = _Row.Item("Monto_Max_CRV_FacMasiva")
            .Usar_Validador_Prod_X_Compras = _Row.Item("Usar_Validador_Prod_X_Compras")
            .Modalidad_General = _Row.Item("Modalidad_General")
            .Revisar_OCC_Pendientes_X_Productos = _Row.Item("Revisar_OCC_Pendientes_X_Productos")
            .Alerta_Costo_Lista_Distinto_Costo_Proveedor = _Row.Item("Alerta_Costo_Lista_Distinto_Costo_Proveedor")
            .Pr_Creacion_Exigir_Dimensiones = _Row.Item("Pr_Creacion_Exigir_Dimensiones")
            .ValorMinimoNVV = _Row.Item("ValorMinimoNVV")
            .FacElec_Bakapp_Hefesto = _Row.Item("FacElec_Bakapp_Hefesto")
            .Permisos_Descuentos_Por_Responzable = _Row.Item("Permisos_Descuentos_Por_Responzable")
            .FacElect_Usar_AmbienteCertificacion = _Row.Item("FacElect_Usar_AmbienteCertificacion")
            .Utilizar_Lectura_Codigo_QR = _Row.Item("Utilizar_Lectura_Codigo_QR")
            .Las_Cotizaciones_No_Revisan_Permisos = _Row.Item("Las_Cotizaciones_No_Revisan_Permisos")
            .CriterioFechaGDVconFechaDistintaDocOrigen = _Row.Item("CriterioFechaGDVconFechaDistintaDocOrigen")
            .CriterioFechaGDVconFechaDistintaDocOrigenObligatorio = _Row.Item("CriterioFechaGDVconFechaDistintaDocOrigenObligatorio")
            .LeerSoloUnaVezCodBarra = _Row.Item("LeerSoloUnaVezCodBarra")
            .Incorporar_Modo_NVI_y_OCC_Asistente_Compras = _Row.Item("Incorporar_Modo_NVI_y_OCC_Asistente_Compras")
            .Actualizar_Lista_De_Costos_Random_Desde_Bakapp = _Row.Item("Actualizar_Lista_De_Costos_Random_Desde_Bakapp")
            .BloqCambNomCONCEPTOSEnDocumentos = _Row.Item("BloqCambNomCONCEPTOSEnDocumentos")
            .RecepXMLComp_CorreoPOP3 = _Row.Item("RecepXMLComp_CorreoPOP3")
            .RecepXMLCmp_ElimiCorreosPOP3 = _Row.Item("RecepXMLCmp_ElimiCorreosPOP3")
            .RecepXMLCmp_MarcaAgua = _Row.Item("RecepXMLCmp_MarcaAgua")
            .PermitirMigrarProductosBaseExterna = _Row.Item("PermitirMigrarProductosBaseExterna")
            .Fincred_Usar = _Row.Item("Fincred_Usar")
            .Fincred_Id_Token = _Row.Item("Fincred_Id_Token")
            .ServTecnico_ObligaIngProdPresupuesto = _Row.Item("ServTecnico_ObligaIngProdPresupuesto")
            .ListaDesdeSustentatorio = _Row.Item("ListaDesdeSustentatorio")
            .AlertaRevNVVConVtasMismoDia = _Row.Item("AlertaRevNVVConVtasMismoDia")
            .LasNVVDebenSerHabilitadasParaFacturar = _Row.Item("LasNVVDebenSerHabilitadasParaFacturar")
            .B4A_DespachoSimple = _Row.Item("B4A_DespachoSimple")
            .GrabarPreciosHistoricos = _Row.Item("GrabarPreciosHistoricos")
            .RecepXML_Cmp_CorreoSMTP = _Row.Item("RecepXML_Cmp_CorreoSMTP")
            .RecepXML_Cmp_POP3 = _Row.Item("RecepXML_Cmp_POP3")
            .RecepXML_Cmp_IMAP = _Row.Item("RecepXML_Cmp_IMAP")
            .RecepXML_Cmp_IMAP_CarpetaLectura = _Row.Item("RecepXML_Cmp_IMAP_CarpetaLectura")
            .RecepXML_Cmp_IMAP_CarpetaDestino = _Row.Item("RecepXML_Cmp_IMAP_CarpetaDestino")
            .RecepXML_Cmp_IMAP_DescHoy = _Row.Item("RecepXML_Cmp_IMAP_DescHoy")
            .RecepXML_Cmp_IMAP_DescNoLeidos = _Row.Item("RecepXML_Cmp_IMAP_DescNoLeidos")
            .Patentes_rvm = _Row.Item("Patentes_rvm")
            .BloqueaMarcas = _Row.Item("BloqueaMarcas")
            .BloqueaRubros = _Row.Item("BloqueaRubros")
            .BloqueaClasificacionLibre = _Row.Item("BloqueaClasificacionLibre")
            .BloqueaZonaProductos = _Row.Item("BloqueaZonaProductos")
            .BloqueaFamilias = _Row.Item("BloqueaFamilias")
            .Pr_Creacion_Exigir_1raDimension = _Row.Item("Pr_Creacion_Exigir_1raDimension")
            .Pr_Creacion_Exigir_2daDimension = _Row.Item("Pr_Creacion_Exigir_2daDimension")
            .Pr_Creacion_Exigir_3raDimension = _Row.Item("Pr_Creacion_Exigir_3raDimension")
            .ValidaMovFisConCodBarra = _Row.Item("ValidaMovFisConCodBarra")
            .BuscarProdConCodRapido = _Row.Item("BuscarProdConCodRapido")
            .BuscarProdConCodTecnico = _Row.Item("BuscarProdConCodTecnico")
            .ServTecnico_Simple = _Row.Item("ServTecnico_Simple")
            .Pickear_NVVTodas = _Row.Item("Pickear_NVVTodas")
            .Pickear_ProdPesoVariable = _Row.Item("Pickear_ProdPesoVariable")
            .Pickear_FacturarAutoCompletas = _Row.Item("Pickear_FacturarAutoCompletas")

        End With

        Return _Zw_Configuracion

    End Function

    Function Fx_Llenar_CONFIEST(_Empresa As String, _Modalidad As String) As Tablas_Configuracion.CONFIEST

        Dim _Confiest As New Tablas_Configuracion.CONFIEST

        Consulta_sql = "Select * From CONFIEST WITH (NOLOCK) Where EMPRESA = '" & _Empresa & "' And MODALIDAD = '" & _Modalidad & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        With _Confiest

            .Empresa = _Row.Item("EMPRESA")
            .Modalidad = _Row.Item("MODALIDAD")
            .ESUCURSAL = _Row.Item("ESUCURSAL")
            .EBODEGA = _Row.Item("EBODEGA")
            .ECAJA = _Row.Item("ECAJA")
            .ELISTAVEN = _Row.Item("ELISTAVEN")
            .NLISTAVEN = _Row.Item("NLISTAVEN")
            .ELISTACOM = _Row.Item("ELISTACOM")
            .NLISTACOM = _Row.Item("NLISTACOM")
            .ELISTAINT = _Row.Item("ELISTAINT")
            .NLISTAINT = _Row.Item("NLISTAINT")
            .EPARALELA = _Row.Item("EPARALELA")
            .NPARALELA = _Row.Item("NPARALELA")
            .ESERIAL = _Row.Item("ESERIAL")
            .NSERIAL = _Row.Item("NSERIAL")
            .EDESFACV = _Row.Item("EDESFACV")
            .EPAGOSV = _Row.Item("EPAGOSV")
            .CRTO = _Row.Item("CRTO")
            .CRSD = _Row.Item("CRSD")
            .CRCH = _Row.Item("CRCH")
            .CRLT = _Row.Item("CRLT")
            .CRPA = _Row.Item("CRPA")
            .POPICR = _Row.Item("POPICR")
            .NUVECR = _Row.Item("NUVECR")
            .FEVECR = _Row.Item("FEVECR")
            .FMINS = _Row.Item("FMINS")
            .FMAXS = _Row.Item("FMAXS")
            .FMINV = _Row.Item("FMINV")
            .FMAXV = _Row.Item("FMAXV")
            .FMINA = _Row.Item("FMINA")
            .FMAXA = _Row.Item("FMAXA")
            .FMINC = _Row.Item("FMINC")
            .FMAXC = _Row.Item("FMAXC")
            .DRIVE = _Row.Item("DRIVE")
            .STOCK = _Row.Item("STOCK")
            .NVI = _Row.Item("NVI")
            .NVILSR = _Row.Item("NVILSR")
            .NVV = _Row.Item("NVV")
            .NVVLSR = _Row.Item("NVVLSR")
            .GDI = _Row.Item("GDI")
            .GDILSR = _Row.Item("GDILSR")
            .GDP = _Row.Item("GDP")
            .GDPLSR = _Row.Item("GDPLSR")
            .GDV = _Row.Item("GDV")
            .GDVLSR = _Row.Item("GDVLSR")
            .GDD = _Row.Item("GDD")
            .GDDLSR = _Row.Item("GDDLSR")
            .FCV = _Row.Item("FCV")
            .FCVLSR = _Row.Item("FCVLSR")
            .FDV = _Row.Item("FDV")
            .FDVLSR = _Row.Item("FDVLSR")
            .NCV = _Row.Item("NCV")
            .NCVLSR = _Row.Item("NCVLSR")
            .BLV = _Row.Item("BLV")
            .BLVLSR = _Row.Item("BLVLSR")
            .BSV = _Row.Item("BSV")
            .BSVLSR = _Row.Item("BSVLSR")
            .OCI = _Row.Item("OCI")
            .OCILSR = _Row.Item("OCILSR")
            .GRI = _Row.Item("GRI")
            .GRILSR = _Row.Item("GRILSR")
            .OCC = _Row.Item("OCC")
            .OCCLSR = _Row.Item("OCCLSR")
            .COV = _Row.Item("COV")
            .COVLSR = _Row.Item("COVLSR")
            .GAR = _Row.Item("GAR")
            .GARLSR = _Row.Item("GARLSR")
            .FEV = _Row.Item("FEV")
            .FEVLSR = _Row.Item("FEVLSR")
            .FCT = _Row.Item("FCT")
            .FCTLSR = _Row.Item("FCTLSR")
            .GCL = _Row.Item("GCL")
            .GCLLSR = _Row.Item("GCLLSR")
            .FDB = _Row.Item("FDB")
            .FDBLSR = _Row.Item("FDBLSR")
            .NCB = _Row.Item("NCB")
            .NCBLSR = _Row.Item("NCBLSR")
            .LISTAMARG = _Row.Item("LISTAMARG")
            .TIPOMARGEN = _Row.Item("TIPOMARGEN")
            .CAMBIARESP = _Row.Item("CAMBIARESP")
            .NVIKOFOR = _Row.Item("NVIKOFOR")
            .NVVKOFOR = _Row.Item("NVVKOFOR")
            .GDIKOFOR = _Row.Item("GDIKOFOR")
            .GTIKOFOR = _Row.Item("GTIKOFOR")
            .GDPKOFOR = _Row.Item("GDPKOFOR")
            .GDVKOFOR = _Row.Item("GDVKOFOR")
            .GDDKOFOR = _Row.Item("GDDKOFOR")
            .FCVKOFOR = _Row.Item("FCVKOFOR")
            .FDVKOFOR = _Row.Item("FDVKOFOR")
            .BSVKOFOR = _Row.Item("BSVKOFOR")
            .BLVKOFOR = _Row.Item("BLVKOFOR")
            .NCVKOFOR = _Row.Item("NCVKOFOR")
            .OCIKOFOR = _Row.Item("OCIKOFOR")
            .OCCKOFOR = _Row.Item("OCCKOFOR")
            .GRIKOFOR = _Row.Item("GRIKOFOR")
            .GRPKOFOR = _Row.Item("GRPKOFOR")
            .GRCKOFOR = _Row.Item("GRCKOFOR")
            .GRDKOFOR = _Row.Item("GRDKOFOR")
            .FCCKOFOR = _Row.Item("FCCKOFOR")
            .FDCKOFOR = _Row.Item("FDCKOFOR")
            .BLCKOFOR = _Row.Item("BLCKOFOR")
            .NCCKOFOR = _Row.Item("NCCKOFOR")
            .COVKOFOR = _Row.Item("COVKOFOR")
            .GARKOFOR = _Row.Item("GARKOFOR")
            .FEVKOFOR = _Row.Item("FEVKOFOR")
            .FCTKOFOR = _Row.Item("FCTKOFOR")
            .GCLKOFOR = _Row.Item("GCLKOFOR")
            .FDBKOFOR = _Row.Item("FDBKOFOR")
            .NCBKOFOR = _Row.Item("NCBKOFOR")
            .NOEVALIST = _Row.Item("NOEVALIST")
            .VERCONSOL = _Row.Item("VERCONSOL")
            .SOLOVERSUC = _Row.Item("SOLOVERSUC")
            .LUVTVEN = _Row.Item("LUVTVEN")
            .LUVTCOM = _Row.Item("LUVTCOM")
            .DIAEXPIVEN = _Row.Item("DIAEXPIVEN")
            .DIAEXPICOM = _Row.Item("DIAEXPICOM")
            .FTOPEELIM = _Row.Item("FTOPEELIM")
            .CONODD = _Row.Item("CONODD")
            .CONOFERTA = _Row.Item("CONOFERTA")
            .FVL = _Row.Item("FVL")
            .FVLLSR = _Row.Item("FVLLSR")
            .FVX = _Row.Item("FVX")
            .FVXLSR = _Row.Item("FVXLSR")
            .FDX = _Row.Item("FDX")
            .FDXLSR = _Row.Item("FDXLSR")
            .NCX = _Row.Item("NCX")
            .NCXLSR = _Row.Item("NCXLSR")
            .FVLKOFOR = _Row.Item("FVLKOFOR")
            .FVXKOFOR = _Row.Item("FVXKOFOR")
            .FDXKOFOR = _Row.Item("FDXKOFOR")
            .NCXKOFOR = _Row.Item("NCXKOFOR")
            .GTI = _Row.Item("GTI")
            .GTILSR = _Row.Item("GTILSR")
            .GRP = _Row.Item("GRP")
            .GRPLSR = _Row.Item("GRPLSR")
            .RESPXVEND = _Row.Item("RESPXVEND")
            .NEV = _Row.Item("NEV")
            .NEVLSR = _Row.Item("NEVLSR")
            .NEVKOFOR = _Row.Item("NEVKOFOR")
            .FABGRIAUT = _Row.Item("FABGRIAUT")
            .FVZ = _Row.Item("FVZ")
            .FVZLSR = _Row.Item("FVZLSR")
            .FVZKOFOR = _Row.Item("FVZKOFOR")
            .FDZ = _Row.Item("FDZ")
            .FDZLSR = _Row.Item("FDZLSR")
            .FDZKOFOR = _Row.Item("FDZKOFOR")
            .NCZ = _Row.Item("NCZ")
            .NCZLSR = _Row.Item("NCZLSR")
            .NCZKOFOR = _Row.Item("NCZKOFOR")
            .NVC = _Row.Item("NVC")
            .NVCLSR = _Row.Item("NVCLSR")
            .NVCKOFOR = _Row.Item("NVCKOFOR")
            .RIN = _Row.Item("RIN")
            .RINLSR = _Row.Item("RINLSR")
            .RINKOFOR = _Row.Item("RINKOFOR")
            .RGA = _Row.Item("RGA")
            .RGALSR = _Row.Item("RGALSR")
            .RGAKOFOR = _Row.Item("RGAKOFOR")
            .RES = _Row.Item("RES")
            .RESLSR = _Row.Item("RESLSR")
            .RESKOFOR = _Row.Item("RESKOFOR")
            .PRO = _Row.Item("PRO")
            .PROLSR = _Row.Item("PROLSR")
            .PROKOFOR = _Row.Item("PROKOFOR")
            .ESC = _Row.Item("ESC")
            .ESCLSR = _Row.Item("ESCLSR")
            .ESCKOFOR = _Row.Item("ESCKOFOR")
            .NCE = _Row.Item("NCE")
            .NCELSR = _Row.Item("NCELSR")
            .NCEKOFOR = _Row.Item("NCEKOFOR")
            .FEE = _Row.Item("FEE")
            .FEELSR = _Row.Item("FEELSR")
            .FEEKOFOR = _Row.Item("FEEKOFOR")
            .FABGDIAUT = _Row.Item("FABGDIAUT")
            .KOTABLA = _Row.Item("KOTABLA")
            .KOCARAC = _Row.Item("KOCARAC")
            .VERTODOST = _Row.Item("VERTODOST")
            .DIASMAXDOC = _Row.Item("DIASMAXDOC")
            .DIASMAXPAG = _Row.Item("DIASMAXPAG")
            .COBDIADEVA = _Row.Item("COBDIADEVA")
            .AVIDIASVEN = _Row.Item("AVIDIASVEN")
            .CUOTACOMER = _Row.Item("CUOTACOMER")
            .CUOTACANTI = _Row.Item("CUOTACANTI")
            .TIDOEXCLU = _Row.Item("TIDOEXCLU")
            .FISCONBARR = _Row.Item("FISCONBARR")
            .LIMICHVPTO = _Row.Item("LIMICHVPTO")
            .MAXICHVPTO = _Row.Item("MAXICHVPTO")
            .KOFUEN = _Row.Item("KOFUEN")
            .COBRADOR = _Row.Item("COBRADOR")
            .MINVALFCV = _Row.Item("MINVALFCV")
            .MINVALBLV = _Row.Item("MINVALBLV")
            .MINVALBSV = _Row.Item("MINVALBSV")
            .BLX = _Row.Item("BLX")
            .BLXLSR = _Row.Item("BLXLSR")
            .BLXKOFOR = _Row.Item("BLXKOFOR")
            .MINVALBLX = _Row.Item("MINVALBLX")

        End With

    End Function

End Class

Namespace Tablas_Configuracion

    Public Class CONFIEST
        Public Property EMPRESA As String
        Public Property MODALIDAD As String
        Public Property ESUCURSAL As String
        Public Property EBODEGA As String
        Public Property ECAJA As String
        Public Property ELISTAVEN As String
        Public Property NLISTAVEN As String
        Public Property ELISTACOM As String
        Public Property NLISTACOM As String
        Public Property ELISTAINT As String
        Public Property NLISTAINT As String
        Public Property EPARALELA As String
        Public Property NPARALELA As String
        Public Property ESERIAL As String
        Public Property NSERIAL As String
        Public Property EDESFACV As String
        Public Property EPAGOSV As String
        Public Property CRTO As Double
        Public Property CRSD As Double
        Public Property CRCH As Double
        Public Property CRLT As Double
        Public Property CRPA As Double
        Public Property POPICR As Double
        Public Property NUVECR As Double
        Public Property FEVECR As DateTime?
        Public Property FMINS As DateTime?
        Public Property FMAXS As DateTime?
        Public Property FMINV As DateTime?
        Public Property FMAXV As DateTime?
        Public Property FMINA As DateTime?
        Public Property FMAXA As DateTime?
        Public Property FMINC As DateTime?
        Public Property FMAXC As DateTime?
        Public Property DRIVE As String
        Public Property STOCK As String
        Public Property NVI As String
        Public Property NVILSR As String
        Public Property NVV As String
        Public Property NVVLSR As String
        Public Property GDI As String
        Public Property GDILSR As String
        Public Property GDP As String
        Public Property GDPLSR As String
        Public Property GDV As String
        Public Property GDVLSR As String
        Public Property GDD As String
        Public Property GDDLSR As String
        Public Property FCV As String
        Public Property FCVLSR As String
        Public Property FDV As String
        Public Property FDVLSR As String
        Public Property NCV As String
        Public Property NCVLSR As String
        Public Property BLV As String
        Public Property BLVLSR As String
        Public Property BSV As String
        Public Property BSVLSR As String
        Public Property OCI As String
        Public Property OCILSR As String
        Public Property GRI As String
        Public Property GRILSR As String
        Public Property OCC As String
        Public Property OCCLSR As String
        Public Property COV As String
        Public Property COVLSR As String
        Public Property GAR As String
        Public Property GARLSR As String
        Public Property FEV As String
        Public Property FEVLSR As String
        Public Property FCT As String
        Public Property FCTLSR As String
        Public Property GCL As String
        Public Property GCLLSR As String
        Public Property FDB As String
        Public Property FDBLSR As String
        Public Property NCB As String
        Public Property NCBLSR As String
        Public Property LISTAMARG As String
        Public Property TIPOMARGEN As Double
        Public Property CAMBIARESP As Boolean
        Public Property NVIKOFOR As String
        Public Property NVVKOFOR As String
        Public Property GDIKOFOR As String
        Public Property GTIKOFOR As String
        Public Property GDPKOFOR As String
        Public Property GDVKOFOR As String
        Public Property GDDKOFOR As String
        Public Property FCVKOFOR As String
        Public Property FDVKOFOR As String
        Public Property BSVKOFOR As String
        Public Property BLVKOFOR As String
        Public Property NCVKOFOR As String
        Public Property OCIKOFOR As String
        Public Property OCCKOFOR As String
        Public Property GRIKOFOR As String
        Public Property GRPKOFOR As String
        Public Property GRCKOFOR As String
        Public Property GRDKOFOR As String
        Public Property FCCKOFOR As String
        Public Property FDCKOFOR As String
        Public Property BLCKOFOR As String
        Public Property NCCKOFOR As String
        Public Property COVKOFOR As String
        Public Property GARKOFOR As String
        Public Property FEVKOFOR As String
        Public Property FCTKOFOR As String
        Public Property GCLKOFOR As String
        Public Property FDBKOFOR As String
        Public Property NCBKOFOR As String
        Public Property NOEVALIST As Boolean
        Public Property VERCONSOL As Boolean
        Public Property SOLOVERSUC As Boolean
        Public Property LUVTVEN As String
        Public Property LUVTCOM As String
        Public Property DIAEXPIVEN As Integer
        Public Property DIAEXPICOM As Integer
        Public Property FTOPEELIM As DateTime?
        Public Property CONODD As Boolean
        Public Property CONOFERTA As Boolean
        Public Property FVL As String
        Public Property FVLLSR As String
        Public Property FVX As String
        Public Property FVXLSR As String
        Public Property FDX As String
        Public Property FDXLSR As String
        Public Property NCX As String
        Public Property NCXLSR As String
        Public Property FVLKOFOR As String
        Public Property FVXKOFOR As String
        Public Property FDXKOFOR As String
        Public Property NCXKOFOR As String
        Public Property GTI As String
        Public Property GTILSR As String
        Public Property GRP As String
        Public Property GRPLSR As String
        Public Property RESPXVEND As Boolean
        Public Property NEV As String
        Public Property NEVLSR As String
        Public Property NEVKOFOR As String
        Public Property FABGRIAUT As Boolean
        Public Property FVZ As String
        Public Property FVZLSR As String
        Public Property FVZKOFOR As String
        Public Property FDZ As String
        Public Property FDZLSR As String
        Public Property FDZKOFOR As String
        Public Property NCZ As String
        Public Property NCZLSR As String
        Public Property NCZKOFOR As String
        Public Property NVC As String
        Public Property NVCLSR As String
        Public Property NVCKOFOR As String
        Public Property RIN As String
        Public Property RINLSR As String
        Public Property RINKOFOR As String
        Public Property RGA As String
        Public Property RGALSR As String
        Public Property RGAKOFOR As String
        Public Property RES As String
        Public Property RESLSR As String
        Public Property RESKOFOR As String
        Public Property PRO As String
        Public Property PROLSR As String
        Public Property PROKOFOR As String
        Public Property ESC As String
        Public Property ESCLSR As String
        Public Property ESCKOFOR As String
        Public Property NCE As String
        Public Property NCELSR As String
        Public Property NCEKOFOR As String
        Public Property FEE As String
        Public Property FEELSR As String
        Public Property FEEKOFOR As String
        Public Property FABGDIAUT As Boolean
        Public Property KOTABLA As String
        Public Property KOCARAC As String
        Public Property VERTODOST As Boolean
        Public Property DIASMAXDOC As Integer
        Public Property DIASMAXPAG As Integer
        Public Property COBDIADEVA As Boolean
        Public Property AVIDIASVEN As Double
        Public Property CUOTACOMER As Boolean
        Public Property CUOTACANTI As Integer
        Public Property TIDOEXCLU As String
        Public Property FISCONBARR As String
        Public Property LIMICHVPTO As Boolean
        Public Property MAXICHVPTO As Double
        Public Property KOFUEN As String
        Public Property COBRADOR As String
        Public Property MINVALFCV As Double
        Public Property MINVALBLV As Double
        Public Property MINVALBSV As Double
        Public Property BLX As String
        Public Property BLXLSR As String
        Public Property BLXKOFOR As String
        Public Property MINVALBLX As Double

    End Class

    Public Class Zw_Configuracion

        Public Property Empresa As String
        Public Property Modalidad As String
        Public Property Pr_AutoPr_Crear_Codigo_Principal_Automatico As Boolean
        Public Property Pr_AutoPr_Correlativo_Por_Iniciales As Boolean
        Public Property Pr_AutoPr_Correlativo_General As Boolean
        Public Property Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico As String
        Public Property Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo As Integer
        Public Property Pr_AutoPr_Ultimo_Codigo_Creado_Correlativo_General As String
        Public Property Pr_Desc_Producto_Solo_Mayusculas As Boolean
        Public Property Pr_Creacion_Exigir_Precio As Boolean
        Public Property Pr_Creacion_Exigir_Clasificacion_busqueda As Boolean
        Public Property Pr_Creacion_Exigir_Codigo_Alternativo As Boolean
        Public Property Tbl_Ranking As String
        Public Property Revisa_Taza_Cambio As Boolean
        Public Property Revisar_Taza_Solo_Mon_Extranjeras As Boolean
        Public Property Vnta_Dias_Venci_Coti As Integer
        Public Property Vnta_TipoValor_Bruto_Neto As String
        Public Property Vnta_EntidadXdefecto As String
        Public Property Vnta_SucEntXdefecto As String
        Public Property Vnta_Producto_NoCreado As String
        Public Property Vnta_Preguntar_Documento As Boolean
        Public Property SOC_CodTurno As String
        Public Property SOC_Buscar_Producto As String
        Public Property SOC_Aprueba_Solo_G1 As Boolean
        Public Property SOC_Aprueba_G1_y_G2 As Boolean
        Public Property SOC_Prod_Crea_Solo_Marcas_Proveedor As Boolean
        Public Property SOC_Prod_Crea_Max_Carac_Nom As Integer
        Public Property SOC_Valor_1ra_Aprobacion As Double
        Public Property SOC_Dias_Apela As Integer
        Public Property SOC_Tipo_Creacion_Producto_Normal_Matriz As Integer
        Public Property Precio_Costos_Desde As String
        Public Property Precios_Venta_Desde_Random As Boolean
        Public Property Precios_Venta_Desde_BakApp As Boolean
        Public Property Vnta_Redondear_Dscto_Cero As Boolean
        Public Property Nodo_Raiz_Asociados As Integer
        Public Property Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente As Boolean
        Public Property Conservar_Responzable_Doc_Relacionado As Boolean
        Public Property Preguntar_Si_Cambia_Responsable_Doc_Relacionado As Boolean
        Public Property ServTecnico_Empresa As String
        Public Property ServTecnico_Sucursal As String
        Public Property ServTecnico_Bodega As String
        Public Property Dias_Max_Fecha_Despacho As Integer
        Public Property Dias_Max_Fecha_Despacho_Sab As Boolean
        Public Property Dias_Max_Fecha_Despacho_Dom As Boolean
        Public Property Solicitar_Permiso_OCC_SOC As Boolean
        Public Property Centro_Costo_Obligatorio_OCC As Boolean
        Public Property Dias_Para_Hacer_NCV As Integer
        Public Property Dias_Para_Hacer_NCV_Oblig As Integer
        Public Property Dimension_Compra_Prod_Proyec_Oblig As String
        Public Property Nombre_Usuario_Correo_Remotas As String
        Public Property Crear_FCC_Desde_GRC_Vinculado_SII As Boolean
        Public Property Conservar_Vendedor_No_Preguntar As Boolean
        Public Property Lista_Precios_Proveedores As String
        Public Property No_Solicitar_Permiso_Entidad_Preferencial As Boolean
        Public Property Utilizar_NVV_En_Credito_X_Cliente As Boolean
        Public Property Volver_A_Solicitar_Permiso_FCV_desde_NVV As Boolean
        Public Property No_Permitir_Grabar_Con_Dscto_Superado As Boolean
        Public Property BloqEdiConcepDescuento As Boolean
        Public Property BloqEdiConcepRecargo As Boolean
        Public Property Solo_Supervisores_Dan_Permisos As Boolean
        Public Property Pedir_Permiso_Para_Usar_Stanby As Boolean
        Public Property Utilizar_Ubicaciones_WCM As Boolean
        Public Property Conservar_Bodega_Sig_Linea_Venta As Boolean
        Public Property Grabar_Despachos_Con_Huella As Boolean
        Public Property Monto_Max_CRV_FacMasiva As Double
        Public Property Usar_Validador_Prod_X_Compras As Boolean
        Public Property Modalidad_General As Boolean
        Public Property Revisar_OCC_Pendientes_X_Productos As Boolean
        Public Property Alerta_Costo_Lista_Distinto_Costo_Proveedor As Boolean
        Public Property Pr_Creacion_Exigir_Dimensiones As Boolean
        Public Property ValorMinimoNVV As Double
        Public Property FacElec_Bakapp_Hefesto As Boolean
        Public Property Permisos_Descuentos_Por_Responzable As Boolean
        Public Property FacElect_Usar_AmbienteCertificacion As Boolean
        Public Property Utilizar_Lectura_Codigo_QR As Boolean
        Public Property Las_Cotizaciones_No_Revisan_Permisos As Boolean
        Public Property CriterioFechaGDVconFechaDistintaDocOrigen As Integer
        Public Property CriterioFechaGDVconFechaDistintaDocOrigenObligatorio As Boolean
        Public Property LeerSoloUnaVezCodBarra As Boolean
        Public Property Incorporar_Modo_NVI_y_OCC_Asistente_Compras As Boolean
        Public Property Actualizar_Lista_De_Costos_Random_Desde_Bakapp As Boolean
        Public Property BloqCambNomCONCEPTOSEnDocumentos As Boolean
        Public Property RecepXMLComp_CorreoPOP3 As String
        Public Property RecepXMLCmp_ElimiCorreosPOP3 As Boolean
        Public Property RecepXMLCmp_MarcaAgua As String
        Public Property PermitirMigrarProductosBaseExterna As Boolean
        Public Property Fincred_Usar As Boolean
        Public Property Fincred_Id_Token As Integer
        Public Property ServTecnico_ObligaIngProdPresupuesto As Boolean
        Public Property ListaDesdeSustentatorio As Boolean
        Public Property AlertaRevNVVConVtasMismoDia As Boolean
        Public Property LasNVVDebenSerHabilitadasParaFacturar As Boolean
        Public Property B4A_DespachoSimple As Boolean
        Public Property GrabarPreciosHistoricos As Boolean
        Public Property RecepXML_Cmp_CorreoSMTP As String
        Public Property RecepXML_Cmp_POP3 As Boolean
        Public Property RecepXML_Cmp_IMAP As Boolean
        Public Property RecepXML_Cmp_IMAP_CarpetaLectura As String
        Public Property RecepXML_Cmp_IMAP_CarpetaDestino As String
        Public Property RecepXML_Cmp_IMAP_DescHoy As Boolean
        Public Property RecepXML_Cmp_IMAP_DescNoLeidos As Boolean
        Public Property Patentes_rvm As Boolean
        Public Property BloqueaMarcas As Boolean
        Public Property BloqueaRubros As Boolean
        Public Property BloqueaClasificacionLibre As Boolean
        Public Property BloqueaZonaProductos As Boolean
        Public Property BloqueaFamilias As Boolean
        Public Property Pr_Creacion_Exigir_1raDimension As Boolean
        Public Property Pr_Creacion_Exigir_2daDimension As Boolean
        Public Property Pr_Creacion_Exigir_3raDimension As Boolean
        Public Property ValidaMovFisConCodBarra As Boolean
        Public Property BuscarProdConCodRapido As Boolean
        Public Property BuscarProdConCodTecnico As Boolean
        Public Property ServTecnico_Simple As Boolean
        Public Property Pickear_NVVTodas As Boolean
        Public Property Pickear_ProdPesoVariable As Boolean
        Public Property Pickear_FacturarAutoCompletas As Boolean

    End Class

End Namespace
