Imports DevComponents.DotNetBar

Public Class Frm_Estructura_Base_De_Datos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Tbl_Informe As DataTable
    Dim Rev_Estruc_Db As New Clas_Estructura_Base_De_Datos

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Revisar_Estructura_Db.ForeColor = Color.White
            Btn_Reparar.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Estructura_Base_De_Datos_Load(sender As Object, e As EventArgs) Handles Me.Load

        _Tbl_Informe = Rev_Estruc_Db.Pro_Tbl_Informe
        Grilla.DataSource = _Tbl_Informe
        Sb_Formato_Grilla()

    End Sub

    Sub Sb_Formato_Grilla()

        With Grilla

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Tabla").Width = 250
            .Columns("Tabla").HeaderText = "Tabla"
            .Columns("Tabla").Visible = True

            .Columns("Campo").Width = 200
            .Columns("Campo").HeaderText = "Campo"
            .Columns("Campo").Visible = True

            .Columns("Descripcion").Width = 450
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True

        End With

        Btn_Exportar_Excel.Enabled = False
        Btn_Ver_Estructura.Enabled = False
    End Sub

    Private Sub Btn_Revisar_Estructura_Db_Click(sender As Object, e As EventArgs) Handles Btn_Revisar_Estructura_Db.Click
        Sb_Revisar_Estructura(False)
    End Sub

    Sub Sb_Revisar_Estructura(_Modificar As Boolean)

        _Tbl_Informe.Clear()
        Sb_Formato_Grilla()

        Btn_Revisar_Estructura_Db.Enabled = False

        With Rev_Estruc_Db

            'CASHDRO ARTURITO
            .Sb_Revisar_Tabla2(Me, "Zw_CashDro_Operaciones", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_CashDro_Transbank_Cierre", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_CashDro_Transbank_Log", _Modificar, Lbl_Eventos)

            'DOCUMENTOS EN LA NUBE
            .Sb_Revisar_Tabla2(Me, "Zw_Casi_DocArc", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Casi_DocDet", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Casi_DocDsc", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Casi_DocEnc", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Casi_DocImp", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Casi_DocObs", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Casi_DocTom", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Casi_DocPer", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Casi_DocTag", _Modificar, Lbl_Eventos)

            'CHILEXPRESS
            .Sb_Revisar_Tabla2(Me, "Zw_Chilexpress_Conf", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Chilexpress_Env", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Chilexpress_Res", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_Conceptos", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Compras_en_SII", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Configuracion", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Configuracion_Formatos_X_Modalidad", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Correos", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Correos_Cuentas", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_CorreosEnvioRecepcion", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_CRV_Viajes", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_DbExt_Conexion", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_DbExt_Maest", _Modificar, Lbl_Eventos)

            'DEMONIO
            .Sb_Revisar_Tabla2(Me, "Zw_Demonio_Archivador", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Demonio_Cof_Estacion", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Demonio_Doc_Emitidos_Aviso_Correo", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Demonio_Doc_Emitidos_Aviso_Correo_Adjuntos", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Demonio_Doc_Emitidos_Cola_Impresion", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Demonio_Filtros_X_Estacion", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Demonio_Prestashop", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Demonio_Wordpress", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Demonio_FacAuto", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Demonio_AcpAuto", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Demonio_NVVAuto", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Demonio_NVVAutoDet", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_Demonio_ConfAcpAuto", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Demonio_ConfProgramacion", _Modificar, Lbl_Eventos)

            'SIS. DE DESPACHOS
            .Sb_Revisar_Tabla2(Me, "Zw_Despachos", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Despachos_Doc", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Despachos_Doc_Det", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Despachos_Estados", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Despachos_Email_Aviso", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Despachos_Email_Envios", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Despachos_Tom", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Despachos_Direcc_Cli", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Despachos_Configuracion", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Despachos_Transportistas", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Despachos_MiniCompXProd", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_Despacho_Simple", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_Docu_Archivos", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Docu_ObligPg", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_Docu_Ent", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Docu_Det", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_DTE_Aec", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_DTE_Caf", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_DTE_Configuracion", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_DTE_Documentos", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_DTE_NotifxCorreo", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_DTE_Trackid", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_DTE_Firmar", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_DTE_ReccEnc", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_DTE_ReccDet", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_DTE_ListaEventosDoc", _Modificar, Lbl_Eventos)


            .Sb_Revisar_Tabla2(Me, "Zw_Empresas", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Entidades", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Entidad_Cia_Seguros", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Entidades_ProdExcluidos", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Entidades_ProdMinCompra", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Entidades_Holding", _Modificar, Lbl_Eventos)


            'CNFIGURACION DE ESTACIONES DE TRABAJO
            .Sb_Revisar_Tabla2(Me, "Zw_Estaciones_Poswi", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Estaciones_CashDro", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_EstacionesBkp", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_EstacionesBkp_Configuracion_Local", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Estaciones_Impresoras", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Estaciones_Ruta_PDF", _Modificar, Lbl_Eventos)

            'FINCRED
            .Sb_Revisar_Tabla2(Me, "Zw_Fincred_Config", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Fincred_Documentos", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Fincred_TramaRespuesta", _Modificar, Lbl_Eventos)

            'FORMATOS DE DOCUMENTOS
            .Sb_Revisar_Tabla2(Me, "Zw_Format_01", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Format_02", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Format_Fx", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Format_Pag", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Fuentes_Conf", _Modificar, Lbl_Eventos)

            'INVENTARIO
            .Sb_Revisar_Tabla2(Me, "Zw_Inv_Contador", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Inv_FotoInventario", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Inv_Hoja", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Inv_HojaEli", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Inv_HojaEli_Detalle", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Inv_Hoja_Detalle", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Inv_Inventario", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Inv_Sector", _Modificar, Lbl_Eventos)


            .Sb_Revisar_Tabla2(Me, "Zw_Licencia", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Licencia_Mod", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Linea_Oferta", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_ListaPreCosto", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_ListaPreCosto_Enc", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_ListaPreGlobal", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_ListaPreProducto", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_ListaPreHistorico", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_Log_Gestiones", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Lotes_Enc", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Lotes_Det", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_ListaLC_Programadas", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_ListaLC_Programadas_Detalles", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_MrVsPro", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_Negocios_01_Enc", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Negocios_02_Det", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Negocios_02_Fun", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Negocios_03_Apr", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Negocios_04_Doc", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_Pago_Prov_Autoriza_01_Enc", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Pago_Prov_Autoriza_02_Det", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Pago_Prov_Autoriza_02_Det_Eli", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_Patentes_rvm", _Modificar, Lbl_Eventos)

            'CONFIGURACION DE PERMISO DE USUARIOS, ROLES
            .Sb_Revisar_Tabla2(Me, "ZW_Permisos", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "ZW_PermisosADM", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "ZW_PermisosVsUsuarios", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_Picking", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Picking_Doc", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_PrestaShop", _Modificar, Lbl_Eventos)

            'PRODUCTOS
            .Sb_Revisar_Tabla2(Me, "Zw_Prod_Archivos", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Prod_Asociacion", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Prod_Asociacion_Respaldo", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Prod_Imagenes", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Prod_Log_Compras", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Prod_Padres", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Prod_PrestaShop", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Prod_Ranking", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Prod_Reemplazos", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Prod_SolBodega", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Prod_Stock_Enc_History", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Prod_Ubicacion", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Prod_SolCompra", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Prod_SolCompra_Resp", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Prod_Stock", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Prod_Usuario_Validador", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Prod_Doc_Ult_Ventas", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Prod_Dimensiones", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Prod_CodQR", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Prod_CodQRLogDoc", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Prod_ImpAdicional", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Productos", _Modificar, Lbl_Eventos)

            'SISTEMA DE PUNTOS POR VENTAS
            .Sb_Revisar_Tabla2(Me, "Zw_PtsVta_Configuracion", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_PtsVta_Doc", _Modificar, Lbl_Eventos)

            'PRODUCCION
            .Sb_Revisar_Tabla2(Me, "Zw_Pdc_Mesones", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Pdc_MesonVsMaquina", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Pdc_MesonVsOperario", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Pdp_MaquinaVsProductos", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Pdp_MesonVsProductos", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Pdp_CPT_Tarja", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Pdp_CPT_Tarja_Det", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Pdp_MesonVsProductos_Repro", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Pdp_OT_Prioridad", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Pdp_MesonVsAlertas", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Pdp_MesonVsAlertas_Lectura", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Pdp_MesonVsEnvioRecibe", _Modificar, Lbl_Eventos)

            'SIS. DE RECLAMOS
            .Sb_Revisar_Tabla2(Me, "Zw_Reclamo", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Reclamo_Archivos", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Reclamo_Email_Aviso", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Reclamo_Estados", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Reclamo_Preguntas", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Reclamo_Resolucion", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_Referencias_Dte", _Modificar, Lbl_Eventos)

            ' PERMISOS REMOTOS
            .Sb_Revisar_Tabla2(Me, "Zw_Remotas", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Remotas_En_Cadena_01_Enc", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Remotas_En_Cadena_02_Det", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Remotas_En_Cadena_03_Usu", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Remotas_Notif", _Modificar, Lbl_Eventos)

            'NOTIFICACIONES
            .Sb_Revisar_Tabla2(Me, "Zw_Notificaciones", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "ZW_SOC_Detalle", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "ZW_SOC_Encabezado", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "ZW_SOC_Ent_Cadena", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "ZW_SOC_Log", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "ZW_SOC_Obs", _Modificar, Lbl_Eventos)


            .Sb_Revisar_Tabla2(Me, "Zw_SQL_Querys", _Modificar, Lbl_Eventos)

            'SIS. DE SERVICIO TECNICO
            .Sb_Revisar_Tabla2(Me, "Zw_St_Conf_Info_Reportes", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_St_Conf_Tecnicos_Taller", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_St_OT_Accesorios", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_St_OT_CheckIn", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_St_OT_DetProd", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_St_OT_Doc_Asociados", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_St_OT_Encabezado", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_St_OT_Estados", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_St_OT_Notas", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_St_OT_Operaciones", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_St_OT_Operaciones_Precios", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_St_OT_OpeXServ", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_St_OT_Recetas_Enc", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_St_OT_Recetas_Ope", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_St_OT_Recetas_OpePre", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_St_OT_Recetas_Prod", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_Stk_Agentes", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Stk_AgentesVsTipos", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Stk_Areas", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Stk_Grupos", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Stk_GrupoVsAgente", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Stk_Tickets", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Stk_Tickets_Acciones", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Stk_Tickets_Archivos", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Stk_Tickets_Asignado", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Stk_Tickets_PorDefecto", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Stk_Tickets_Producto", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Stk_Tipos", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Stk_Tipos_Grupos", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Stk_Tickets_Toma", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_Stmp_Enc", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Stmp_Det", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Stmp_DetPick", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Stmp_Enc_Permisos", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Stmp_SalaEspera", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_TablaDeCaracterizaciones", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Tablas_Equivalentes_Rd_Bk", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_Tbl_DisenoBarras", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Tbl_DisenoBarras_SalPtoxEstacion", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_Tbl_Reemplazos", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_TblArbol_Asociaciones", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_TblChoferes_Empresa", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_TblFiltro_InfxUs", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_TblInf_EntExcluidas", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_TblTipoDocumentos", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_TblVehiculos_Empresa", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_TblVehiculos_Empresa_Imagenes", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Tmp_Filtros_Busqueda", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Tmp_Prm_Informes", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_TmpInv_InvParcial", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_TmpInv_InvParcial_Inventarios", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_TmpInv_InvParcialConf", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Turnos", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_UnificadosHitory", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_Usuarios", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Usuarios_Huellas", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Usuarios_Email", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Usuarios_VS_Jefes", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Usuarios_Impresion", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_Vales_Enc", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Vales_Obs", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Version", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_WMS_Ingreso_Det", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_WMS_Ingreso_Enc", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_WMS_Ubicaciones_Bodega", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_WMS_Ubicaciones_Mapa_Det", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_WMS_Ubicaciones_Mapa_Enc", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_WMS_Ubicaciones_Stock_X_Producto", _Modificar, Lbl_Eventos)

            .Sb_Revisar_Tabla2(Me, "Zw_Wordpress", _Modificar, Lbl_Eventos)
            .Sb_Revisar_Tabla2(Me, "Zw_Wordpress_Productos", _Modificar, Lbl_Eventos)

            If Not _Modificar Then

                If .Pro_Base_Corresponde_a_Version Then

                    MessageBoxEx.Show(Me, "Fin revisión de estructura de bade de datos" & vbCrLf &
                                  "La base corresponde a la versión: " & _Global_Version_BakApp, "Bakapp",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else

                    MessageBoxEx.Show(Me, "Problemas en la estructura de la base de datos" & vbCrLf &
                                  "La base no corresponde a la versión: " & _Global_Version_BakApp, "Bakapp",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)

                End If

            End If

        End With

        Btn_Exportar_Excel.Enabled = CBool(_Tbl_Informe.Rows.Count)
        Btn_Ver_Estructura.Enabled = CBool(_Tbl_Informe.Rows.Count)
        Btn_Reparar.Visible = CBool(_Tbl_Informe.Rows.Count)

        Btn_Revisar_Estructura_Db.Enabled = True

        Me.Refresh()

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Try
            Grilla.Enabled = False

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Accion As String = NuloPorNro(_Fila.Cells("Accion").Value, "")
            Dim _Reparado As Boolean = NuloPorNro(_Fila.Cells("Reparado").Value, False)
            Dim _Descripcion As String = _Fila.Cells("Descripcion").Value

            If String.IsNullOrEmpty(_Accion) Then
                MessageBoxEx.Show(Me, "Debe ejecutar la acción directamente en la base de datos", _Descripcion,
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If Not _Reparado Then
                    Consulta_Sql = _Accion
                    Consulta_Sql = Replace(Consulta_Sql, "varbinary (-1)", "varbinary")
                    Consulta_Sql = Replace(Consulta_Sql, "varchar (-1)", "varchar(Max)")

                    If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                        _Fila.Cells("Reparado").Value = True
                        Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
                    End If
                End If
            End If

            Beep()

        Catch ex As Exception
        Finally
            Grilla.Enabled = True
        End Try

    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Excel.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_Informe, Me, "Problemas_Estructura_Db")
    End Sub

    Private Sub Btn_Ver_Estructura_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Estructura.Click

        Try
            Grilla.Enabled = False

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Tabla As String = _Fila.Cells("Tabla").Value

            Dim _Row As DataRow = Rev_Estruc_Db.Fx_Buscar_Tabla_En_Tablas(_Tabla)

            If Not IsNothing(_Row) Then
                Dim _Estructura As String = Replace(_Row.Item("Estructura"), "(')", "('')")
                Dim Fm As New Frm_Archivo_TXT

                Fm.Pro_Nombre_Archivo = "Estrcutura tabla " & _Tabla
                Fm.Pro_Texto_Log = _Estructura
                Fm.Txt_Texto.Text = Replace(Fm.Txt_Texto.Text, "(')", "('')")
                Fm.Alto = 800
                Fm.Ancho = 1000
                Fm.MaximumSize = New Size(0, 0)
                Fm.ShowDialog(Me)
                Fm.Dispose()
            End If

        Catch ex As Exception
        Finally
            Grilla.Enabled = True
        End Try

    End Sub

    Private Sub Btn_Reparar_Click(sender As Object, e As EventArgs) Handles Btn_Reparar.Click

        Sb_Revisar_Estructura(True)
        Sb_Revisar_Estructura(False)
        Return

        For Each _Fila As DataRow In _Tbl_Informe.Rows

            Dim _Accion As String = NuloPorNro(_Fila.Item("Accion").Value, "")
            Dim _Tabla As String = _Fila.Item("Tabla")
            Dim _Campo As String = _Fila.Item("Campo")
            Dim _Reparado As Boolean = NuloPorNro(_Fila.Item("Reparado").Value, False)
            Dim _Descripcion As String = _Fila.Item("Descripcion").Value

            If Not String.IsNullOrEmpty(_Accion) Then
                If Not _Reparado Then
                    Consulta_Sql = _Accion
                    If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                        _Fila.Item("Reparado").Value = True
                        Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
                    End If
                End If
            End If

        Next

    End Sub

End Class
