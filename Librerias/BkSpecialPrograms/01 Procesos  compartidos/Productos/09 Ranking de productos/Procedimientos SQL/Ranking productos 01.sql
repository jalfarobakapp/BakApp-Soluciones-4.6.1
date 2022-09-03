

   
   CREATE TABLE Zw_TblMargen(
     Tido        char(3)     default '',  -- Tipo de documento
     Presencia   Int         default  0,  -- Presencia de documento Si es nota de credito -1
     Nudo        char(10)    default '',  -- Numero de documento
     Feemli      Date        default getdate(), -- Fecha de emisión de docuemto
     Nulido      char(5)     default '',  -- Numero de linea del documenmto
     Koprct      Varchar(13) default '',  -- Código de producto
     Nokopr      Varchar(50) default '',  -- Descripción de producto
     CantidadUd1 Float       default (0), -- Cantidad de venta de la unidad 1
     PNetoUnit   Float       default (0), -- Precio unitario neto de la unidad 1
     CostoUnit   float       default (0), -- Costo unitario neto de la unidad 1
     AdicImp     float       default (0), -- Valor adicional al costo, impuestos especificos
     CostoUnitIm float       default (0), -- Costo mas impuestos especificos
     TotalCosto  Float       default (0), -- Valor total del costo
     TotalPrecio float       default (0), -- Valor total del precio neto
     Porct_Ila   Float       default (0), -- Porcentaje de Ila %
     Porct_Iva   Float       default (0), -- Porcentaje de Iva %
     Ila         Float       default (0), -- Valor Ila
     Iva         Float       default (0), -- Valor Iva
     PrecioBruto float       default (0), -- Precio Bruto unitario de la unidad 1
     Val_MrgUnit Float       default (0), -- Valor unitario del margen
     Total_Mrg   Float       default (0), -- Total margen 
     Porc_Markup Float       default (0), -- Porcentaje de Markup % (Margen de venta)
     Porc_Margen Float       default (0), -- Porcentaje de Margen % (Margen de costo)
     Funcionario Char(3)     default '') 

   

   CREATE TABLE Zw_TblMrgImp(
     Koprct      char(13) default '', 
     Impuestos   Float    default (0),
     )

   Insert Into Zw_TblMrgImp (Koprct,Impuestos) 
   SELECT   dbo.MAEPR.KOPR,SUM(ISNULL(dbo.TABIM.POIM, 0)) AS Impuestos
             FROM         dbo.MAEPR LEFT OUTER JOIN
                          dbo.TABIMPR ON dbo.MAEPR.KOPR = dbo.TABIMPR.KOPR LEFT OUTER JOIN
                          dbo.TABIM ON dbo.TABIMPR.KOIM = dbo.TABIM.KOIM
             GROUP BY dbo.MAEPR.KOPR, dbo.MAEPR.NOKOPR 
  
