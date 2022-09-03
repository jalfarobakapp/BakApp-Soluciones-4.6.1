
Declare @CodigoNew Char(13) = '#CodigoNew#', 
        @CodigoOld Char(13) = '#CodigoOld#',
        @Descripcion Varchar(50) = '#Descripcion#'


Update #Base#ZW_ProductosDescartadosInfCompras    Set Codigo = @CodigoNew Where Codigo = @CodigoOld
Update #Base#ZW_SOC_Detalle					      Set Codigo = @CodigoNew Where Codigo = @CodigoOld
Update #Base#Zw_Casi_DocDet				          Set Codigo = @CodigoNew Where Codigo = @CodigoOld
Update #Base#Zw_Demonio_Prestashop                Set Codigo = @CodigoNew Where Codigo = @CodigoOld
Update #Base#Zw_ListaPreCosto                     Set Codigo = @CodigoNew Where Codigo = @CodigoOld
Update #Base#Zw_ListaPreProducto			      Set Codigo = @CodigoNew Where Codigo = @CodigoOld

Update #Base#Zw_Prod_Archivos				      Set Codigo = @CodigoNew Where Codigo = @CodigoOld
UPDATE #Base#Zw_Prod_Asociacion                   Set DescripcionBusqueda = @CodigoNew +' '+ @Descripcion 
                                                  Where Codigo = @CodigoOld And Producto = 1  

UPDATE #Base#Zw_Prod_Asociacion                   Set Codigo = @CodigoNew Where Codigo = @CodigoOld

Update #Base#Zw_Prod_Asociacion_Respaldo          Set Codigo = @CodigoNew Where Codigo = @CodigoOld
Update #Base#Zw_Prod_Imagenes                     Set Codigo = @CodigoNew Where Codigo = @CodigoOld

Update #Base#Zw_Prod_Log_Compras                  Set Codigo = @CodigoNew Where Codigo = @CodigoOld

Update #Base#Zw_Prod_Padres                       Set Codigo_Hijo = @CodigoNew Where Codigo_Hijo = @CodigoOld
Update #Base#Zw_Prod_Padres                       Set Codigo_Padre = @CodigoNew Where Codigo_Padre = @CodigoOld

Update #Base#Zw_Prod_PrestaShop                   Set Codigo = @CodigoNew Where Codigo = @CodigoOld

Update #Base#Zw_Prod_Ranking                      Set Codigo = @CodigoNew Where Codigo = @CodigoOld
Update #Base#Zw_Prod_Reemplazos                   Set Codigo = @CodigoNew Where Codigo = @CodigoOld
Update #Base#Zw_Prod_Rotacion                     Set Codigo = @CodigoNew Where Codigo = @CodigoOld
Update #Base#Zw_Prod_SolBodega                    Set Codigo = @CodigoNew Where Codigo = @CodigoOld

Update #Base#Zw_Prod_SolCompra                    Set Codigo = @CodigoNew Where Codigo = @CodigoOld
Update #Base#Zw_Prod_Stock                        Set Codigo = @CodigoNew Where Codigo = @CodigoOld

Update #Base#Zw_Prod_Stock_Enc_History            Set Codigo = @CodigoNew Where Codigo = @CodigoOld
Update #Base#Zw_Prod_Stock_History                Set Codigo = @CodigoNew Where Codigo = @CodigoOld
Update #Base#Zw_Prod_Ubicacion                    Set Codigo = @CodigoNew Where Codigo = @CodigoOld

Update #Base#Zw_Prod_Usuario_Validador            Set Codigo = @CodigoNew Where Codigo = @CodigoOld
Update #Base#Zw_Reclamo                           Set Codigo = @CodigoNew Where Codigo = @CodigoOld

Update #Base#Zw_St_OT_DetProd					  Set Codigo = @CodigoNew Where Codigo = @CodigoOld
Update #Base#Zw_St_OT_Encabezado                  Set Codigo = @CodigoNew Where Codigo = @CodigoOld
Update #Base#Zw_TmpInv_InvParcial                 Set CodigoPr = @CodigoNew Where CodigoPr = @CodigoOld
Update #Base#Zw_WMS_Ingreso_Det                   Set Codigo = @CodigoNew Where Codigo = @CodigoOld
Update #Base#Zw_WMS_Ubicaciones_Stock_X_Producto  Set Codigo = @CodigoNew Where Codigo = @CodigoOld

Update #Base#Zw_Despachos_Doc_Det                 Set Codigo = @CodigoNew Where Codigo = @CodigoOld
Update #Base#Zw_Despachos_MiniCompXProd           Set Codigo = @CodigoNew Where Codigo = @CodigoOld

Update #Base#Zw_Pdp_MaquinaVsProductos            Set Codigo = @CodigoNew Where Codigo = @CodigoOld
Update #Base#Zw_Pdp_MesonVsProductos              Set Codigo = @CodigoNew Where Codigo = @CodigoOld
Update #Base#Zw_Pdp_MesonVsProductos_Repro        Set Codigo = @CodigoNew Where Codigo = @CodigoOld
