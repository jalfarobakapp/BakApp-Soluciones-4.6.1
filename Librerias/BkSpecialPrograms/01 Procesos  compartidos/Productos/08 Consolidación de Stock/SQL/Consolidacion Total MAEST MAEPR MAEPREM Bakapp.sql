Declare @Empresa Char(2) = '#Empresa#'

Update #Tabla_Paso# Set Dif_StockF_Ud1 = STFI1-StockF_Ud1,
                        Dif_StockF_Ud2 = STFI1-StockF_Ud2,
				        Dif_StockDev_Ud1 = STDV1-StockDev_Ud1,
					    Dif_StockDev_Ud2 = STDV2-StockDev_Ud2,
					    Dif_StockDsf_Ud1 = DESPNOFAC1-StockDsf_Ud1,
					    Dif_StockDsf_Ud2 = DESPNOFAC2-StockDsf_Ud2,
					    Dif_StockCom_Ud1 = STOCNV1-StockCom_Ud1,
					    Dif_StockCom_Ud2 = STOCNV2-StockCom_Ud2,
					    Dif_StockCnr_Ud1 = STDV1C-StockCnr_Ud1,
					    Dif_StockCnr_Ud2 = STDV1C-StockCnr_Ud2,
					    Dif_StockRsf_Ud1 = RECENOFAC1-StockRsf_Ud1,
					    Dif_StockRsf_Ud2 = RECENOFAC2-StockRsf_Ud2,
					    Dif_StockPed_Ud1 = STOCNV1C-StockPed_Ud1,
					    Dif_StockPed_Ud2 = STOCNV2C-StockPed_Ud2

Delete #Tabla_Paso#
Where 
(Dif_StockF_Ud1 = 0 And 
 Dif_StockDev_Ud1 = 0 And 
 Dif_StockDsf_Ud1 = 0 And 
 Dif_StockCom_Ud1 = 0 And 
 Dif_StockCnr_Ud1 = 0 And 
 Dif_StockRsf_Ud1 = 0 And 
 Dif_StockPed_Ud1 = 0 And
 Dif_StockF_Ud2 = 0 And 
 Dif_StockDev_Ud2 = 0 And 
 Dif_StockDsf_Ud2 = 0 And 
 Dif_StockCom_Ud2 = 0 And 
 Dif_StockCnr_Ud2 = 0 And 
 Dif_StockRsf_Ud2 = 0 And 
 Dif_StockPed_Ud2 = 0)


Update MAEST Set MAEST.STFI1      = TbPaso.StockF_Ud1, 
                 MAEST.STFI2      = TbPaso.StockF_Ud2, 
				 MAEST.STDV1      = TbPaso.StockDev_Ud1, 
				 MAEST.STDV2      = TbPaso.StockDev_Ud2, 
				 MAEST.DESPNOFAC1 = TbPaso.StockDsf_Ud1, 
				 MAEST.DESPNOFAC2 = TbPaso.StockDsf_Ud2, 
                 MAEST.STOCNV1    = TbPaso.StockCom_Ud1, 
				 MAEST.STOCNV2    = TbPaso.StockCom_Ud2, 
				 MAEST.STDV1C     = TbPaso.StockCnr_Ud1, 
				 MAEST.STDV2C     = TbPaso.StockCnr_Ud2, 
				 MAEST.RECENOFAC1 = TbPaso.StockRsf_Ud1, 
				 MAEST.RECENOFAC2 = TbPaso.StockRsf_Ud2, 
				 MAEST.STOCNV1C   = TbPaso.StockPed_Ud1, 
				 MAEST.STOCNV2C   = TbPaso.StockPed_Ud2
FROM MAEST AS Mst INNER JOIN
                        #Tabla_Paso# AS TbPaso  ON TbPaso.EMPRESA = Mst.EMPRESA AND TbPaso.KOSU = Mst.KOSU AND TbPaso.KOBO = Mst.KOBO AND TbPaso.KOPR = Mst.KOPR				 

Where 
(Dif_StockF_Ud1   <> 0 Or 
 Dif_StockDev_Ud1 <> 0 Or 
 Dif_StockDsf_Ud1 <> 0 Or 
 Dif_StockCom_Ud1 <> 0 Or 
 Dif_StockCnr_Ud1 <> 0 Or 
 Dif_StockRsf_Ud1 <> 0 Or 
 Dif_StockPed_Ud1 <> 0 Or
 Dif_StockF_Ud2   <> 0 Or 
 Dif_StockDev_Ud2 <> 0 Or 
 Dif_StockDsf_Ud2 <> 0 Or 
 Dif_StockCom_Ud2 <> 0 Or 
 Dif_StockCnr_Ud2 <> 0 Or 
 Dif_StockRsf_Ud2 <> 0 Or 
 Dif_StockPed_Ud2 <> 0)



UPDATE MAEPR SET 
                 STFI1 = ISNULL((select SUM(STFI1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 STFI2 = ISNULL((select SUM(STFI2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 STDV1 = ISNULL((select SUM(STDV1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 STDV2 = ISNULL((select SUM(STDV2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 
                 STOCNV1 = ISNULL((select SUM(STOCNV1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 STOCNV2 = ISNULL((select SUM(STOCNV2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 STDV1C = ISNULL((select SUM(STDV1C) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 STDV2C = ISNULL((select SUM(STDV2C) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
             
                 STOCNV1C = ISNULL((select SUM(STOCNV1C) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 STOCNV2C = ISNULL((select SUM(STOCNV2C) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 DESPNOFAC1 = ISNULL((select SUM(DESPNOFAC1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 DESPNOFAC2 = ISNULL((select SUM(DESPNOFAC2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 
                 RECENOFAC1 = ISNULL((select SUM(RECENOFAC1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 RECENOFAC2 = ISNULL((select SUM(RECENOFAC2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 STTR1 = ISNULL((select SUM(STTR1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 STTR2 = ISNULL((select SUM(STTR2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 
                 PRESALCLI1 = ISNULL((select SUM(PRESALCLI1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 PRESALCLI2 = ISNULL((select SUM(PRESALCLI2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 PRESDEPRO1 = ISNULL((select SUM(PRESDEPRO1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 PRESDEPRO2 = ISNULL((select SUM(PRESDEPRO2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 
                 CONSALCLI1 = ISNULL((select SUM(CONSALCLI1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 CONSALCLI2 = ISNULL((select SUM(CONSALCLI2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 DEVENGNCV1 = ISNULL((select SUM(DEVENGNCV1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 DEVENGNCV2 = ISNULL((select SUM(DEVENGNCV2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                
                 DEVENGNCC1 = ISNULL((select SUM(DEVENGNCC1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 DEVENGNCC2 = ISNULL((select SUM(DEVENGNCC2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 DEVSINNCV1 = ISNULL((select SUM(DEVSINNCV1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 DEVSINNCV2 = ISNULL((select SUM(DEVSINNCV2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 
                 DEVSINNCC1 = ISNULL((select SUM(DEVSINNCC1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 DEVSINNCC2 = ISNULL((select SUM(DEVSINNCC2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 STENFAB1 = ISNULL((select SUM(STENFAB1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 STENFAB2 = ISNULL((select SUM(STENFAB2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 
                 STREQFAB1 = ISNULL((select SUM(STREQFAB1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0),
                 STREQFAB2 = ISNULL((select SUM(STREQFAB2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPR.KOPR),0)
                 
WHERE KOPR In (Select KOPR From #Tabla_Paso#)
                 

UPDATE MAEPREM SET 
                 STFI1 = ISNULL((select SUM(STFI1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 STFI2 = ISNULL((select SUM(STFI2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 STDV1 = ISNULL((select SUM(STDV1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 STDV2 = ISNULL((select SUM(STDV2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 
                 STOCNV1 = ISNULL((select SUM(STOCNV1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 STOCNV2 = ISNULL((select SUM(STOCNV2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 STDV1C = ISNULL((select SUM(STDV1C) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 STDV2C = ISNULL((select SUM(STDV2C) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
             
                 STOCNV1C = ISNULL((select SUM(STOCNV1C) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 STOCNV2C = ISNULL((select SUM(STOCNV2C) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 DESPNOFAC1 = ISNULL((select SUM(DESPNOFAC1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 DESPNOFAC2 = ISNULL((select SUM(DESPNOFAC2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 
                 RECENOFAC1 = ISNULL((select SUM(RECENOFAC1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 RECENOFAC2 = ISNULL((select SUM(RECENOFAC2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 STTR1 = ISNULL((select SUM(STTR1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 STTR2 = ISNULL((select SUM(STTR2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 
                 PRESALCLI1 = ISNULL((select SUM(PRESALCLI1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 PRESALCLI2 = ISNULL((select SUM(PRESALCLI2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 PRESDEPRO1 = ISNULL((select SUM(PRESDEPRO1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 PRESDEPRO2 = ISNULL((select SUM(PRESDEPRO2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 
                 CONSALCLI1 = ISNULL((select SUM(CONSALCLI1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 CONSALCLI2 = ISNULL((select SUM(CONSALCLI2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 DEVENGNCV1 = ISNULL((select SUM(DEVENGNCV1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 DEVENGNCV2 = ISNULL((select SUM(DEVENGNCV2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                
                 DEVENGNCC1 = ISNULL((select SUM(DEVENGNCC1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 DEVENGNCC2 = ISNULL((select SUM(DEVENGNCC2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 DEVSINNCV1 = ISNULL((select SUM(DEVSINNCV1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 DEVSINNCV2 = ISNULL((select SUM(DEVSINNCV2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 
                 DEVSINNCC1 = ISNULL((select SUM(DEVSINNCC1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 DEVSINNCC2 = ISNULL((select SUM(DEVSINNCC2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 STENFAB1 = ISNULL((select SUM(STENFAB1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 STENFAB2 = ISNULL((select SUM(STENFAB2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 
                 STREQFAB1 = ISNULL((select SUM(STREQFAB1) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0),
                 STREQFAB2 = ISNULL((select SUM(STREQFAB2) From MAEST Ms WHERE EMPRESA = @Empresa AND Ms.KOPR = MAEPREM.KOPR),0)        
                 
WHERE KOPR In (Select KOPR From #Tabla_Paso#)
       