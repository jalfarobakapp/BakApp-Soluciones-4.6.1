Declare @Codigo      Char(13),
        @Empresa     Char(2),
        @Sucursal    Char(3),
        @Bodega      Char(3),
        @OpcionCosto Char(3),
        @ListaCosto  Char(3),
        @CostoUnit   Float,
        @FechaInv    Date
        
        
Select @Empresa = '#Empresa#',
       @Sucursal = '#Sucursal#',
       @Bodega = '#Bodega#',
       @Codigo = '#Codigo#',
       @OpcionCosto ='#OpcCosto#',
       @ListaCosto = '#ListaCosto#',
       @FechaInv = '#FechaInv#'
        

                              
   insert into Zw_TmpInv_InvParcial (Empresa,Sucursal,Bodega,CodigoPr,CodBarras,Descripcion,Rtu,StockActual,FechaInv,HoraInv)
   SELECT @Empresa,@Sucursal,@Bodega,dbo.MAEPR.KOPR, ISNULL((SELECT TOP (1) KOPRAL FROM dbo.TABCODAL WHERE (KOPR = @Codigo) AND (KOEN = '')), '') 
       AS KOPRAL,dbo.MAEPR.NOKOPR, dbo.MAEPR.RLUD, dbo.MAEST.STFI1,@FechaInv,GETDATE()
   FROM         dbo.MAEPR LEFT OUTER JOIN
                dbo.MAEST ON dbo.MAEPR.KOPR = dbo.MAEST.KOPR
   WHERE     (dbo.MAEST.EMPRESA = @Empresa) AND (dbo.MAEST.KOSU = @Sucursal) 
   AND (dbo.MAEST.KOBO = @Bodega) AND (dbo.MAEPR.KOPR = @Codigo) 

   If @OpcionCosto = 'PM#' Begin -- Costo promedio ponderado por sistema
      Set @CostoUnit = Isnull((Select top 1 PM from MAEPREM WHERE KOPR = @Codigo AND EMPRESA = @Empresa),0)
   End 

   If @OpcionCosto = 'UC#' Begin -- Costo de ultima compra por sistema
      Set @CostoUnit = Isnull((Select top 1 PPUL01 from MAEPREM WHERE KOPR = @Codigo AND EMPRESA = @Empresa),0)
   End

   If @OpcionCosto = 'LT#' Begin -- Costo de ultima compra por sistema
      Set @CostoUnit = Isnull((Select top 1 PP01UD From TABPRE Where KOPR = @Codigo
                               And KOLT = @ListaCosto),0)
   End

   Update Zw_TmpInv_InvParcial Set CostoUnitUd1 = @CostoUnit,CostoUnitUd2 = @CostoUnit*Rtu
   Where CodigoPr = @Codigo

