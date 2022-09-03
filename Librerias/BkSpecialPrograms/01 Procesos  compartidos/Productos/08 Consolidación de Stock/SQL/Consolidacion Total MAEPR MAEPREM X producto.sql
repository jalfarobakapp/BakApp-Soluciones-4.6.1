Declare @Empresa Char(2) = '#Empresa#',
        @Codigo Char(13) = '#Codigo#'

UPDATE MAEPR SET 
                 STFI1 = ISNULL((select SUM(STFI1) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 STFI2 = ISNULL((select SUM(STFI2) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 STDV1 = ISNULL((select SUM(STDV1) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 STDV2 = ISNULL((select SUM(STDV2) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 
                 STOCNV1 = ISNULL((select SUM(STOCNV1) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 STOCNV2 = ISNULL((select SUM(STOCNV2) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 STDV1C = ISNULL((select SUM(STDV1C) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 STDV2C = ISNULL((select SUM(STDV2C) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
             
                 STOCNV1C = ISNULL((select SUM(STOCNV1C) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 STOCNV2C = ISNULL((select SUM(STOCNV2C) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 DESPNOFAC1 = ISNULL((select SUM(DESPNOFAC1) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 DESPNOFAC2 = ISNULL((select SUM(DESPNOFAC2) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 
                 RECENOFAC1 = ISNULL((select SUM(RECENOFAC1) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 RECENOFAC2 = ISNULL((select SUM(RECENOFAC2) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 STTR1 = ISNULL((select SUM(STTR1) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 STTR2 = ISNULL((select SUM(STTR2) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 
                 PRESALCLI1 = ISNULL((select SUM(PRESALCLI1) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 PRESALCLI2 = ISNULL((select SUM(PRESALCLI2) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 PRESDEPRO1 = ISNULL((select SUM(PRESDEPRO1) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 PRESDEPRO2 = ISNULL((select SUM(PRESDEPRO2) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 
                 CONSALCLI1 = ISNULL((select SUM(CONSALCLI1) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 CONSALCLI2 = ISNULL((select SUM(CONSALCLI2) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 DEVENGNCV1 = ISNULL((select SUM(DEVENGNCV1) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 DEVENGNCV2 = ISNULL((select SUM(DEVENGNCV2) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                
                 DEVENGNCC1 = ISNULL((select SUM(DEVENGNCC1) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 DEVENGNCC2 = ISNULL((select SUM(DEVENGNCC2) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 DEVSINNCV1 = ISNULL((select SUM(DEVSINNCV1) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 DEVSINNCV2 = ISNULL((select SUM(DEVSINNCV2) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 
                 DEVSINNCC1 = ISNULL((select SUM(DEVSINNCC1) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 DEVSINNCC2 = ISNULL((select SUM(DEVSINNCC2) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 STENFAB1 = ISNULL((select SUM(STENFAB1) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 STENFAB2 = ISNULL((select SUM(STENFAB2) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 
                 STREQFAB1 = ISNULL((select SUM(STREQFAB1) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0),
                 STREQFAB2 = ISNULL((select SUM(STREQFAB2) From MAEST Ms WHERE Ms.KOPR = MAEPR.KOPR),0)
                 
WHERE KOPR = @Codigo                 
                 

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
                 
WHERE EMPRESA = @Empresa And KOPR = @Codigo                          