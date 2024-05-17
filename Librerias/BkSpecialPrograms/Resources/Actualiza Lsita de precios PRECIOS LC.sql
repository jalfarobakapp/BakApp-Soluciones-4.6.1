
Declare @Empresa char(2)
Set @Empresa = '#Empresa#'

-- // Creación de tabla de paso 

IF EXISTS (SELECT * FROM sysobjects WHERE name='Zw_ListaLC_TblPasoListas') BEGIN
DROP TABLE Zw_ListaLC_TblPasoListas
END

--Lista, NombreLista, Codigo, PrecioUd1,PrecioUd2,Rtu, MargenPorc, VarMcosto,VarPm, VarUc, VarFlete, VarIva, VarIla,VarNetoDigit,VarValorDigit

CREATE TABLE [dbo].[Zw_ListaLC_TblPasoListas] (
 [Id]  int IDENTITY(1, 1)     NOT NULL,
 [Lista]         char(3)      DEFAULT '',  -- Codigo de la modalidad
 [NombreLista]   char(30)     DEFAULT '',  -- Codigo de la empresa
 [Codigo]        char(13)     DEFAULT '',  -- Tipo de documento
 [PrecioUd1]     float        DEFAULT '0', -- Numero del documento
 [PrecioUd2]     float        DEFAULT '0', -- Entidad del documento
 [EcuacionUd1]   varchar(242) DEFAULT '',  -- Formula de la Unidad 1
 [EcuacionUd2]   Varchar(242) DEFAULT '',  -- Formula de la Unidad 2
 [Rtu]           float        DEFAULT '0',  -- Sucursal de la entidad del documento
 [MargenPorc]    float        DEFAULT '0',  -- Sucursal documento 
 [VarMcosto]     float        DEFAULT '0',  -- Fecha Emision documento
 [VarPm]         float        DEFAULT '0',  -- codigo funcionario
 [VarUc]         float        DEFAULT '0',  -- Cantidad de productos
 [VarFlete]      float        DEFAULT '0',  -- Valor iva documento
 [VarIva]        float        DEFAULT '0',  -- Valor neto documento
 [VarIla]        float        DEFAULT '0',  -- Valor Bruto documento
 [VarNetoDigit]  float        DEFAULT '0',  -- Fecha esperada de recepcion 
 [VarValorDigit] float        DEFAULT '0' ,
 CONSTRAINT [PK_Zw_ListaLC_TblPasoListas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];


-- //

-- // Declaración de variables

Declare @Codigo char(13), 
        @Flete Float,
        @ValorBruto Float,
        @ValorNetoPropuesto Float,
        @MargenPropuesto Float,
        @ValorPropuesto Float, 
        @Mcosto Float, 
        @Mg Float,
        @Ila Float,
        @Iva Float,
		@Impuestos Float
        
Set @Codigo = '#Codigo'
Set @Iva = #Iva
Set @Ila = #Ila
Set @Impuestos = #Impuestos


Set @Flete = (Select TOP 1 RECARGO from TABRECPR WHERE KOPR = @Codigo AND RECARGO > 0)

Set @MargenPropuesto = #MargenPropuesto
Set @ValorBruto = #PrecioDigitado


Set @Mcosto  =(SELECT CASE 
                      WHEN ISNULL(dbo.MAEPREM.PPUL01, 0) > ISNULL(dbo.MAEPREM.PM, 0) THEN ISNULL(dbo.MAEPREM.PPUL01, 0) 
                      ELSE ISNULL(dbo.MAEPREM.PM, 0) END FROM MAEPREM WHERE KOPR = @Codigo AND EMPRESA = '01')

Set @Mg = 1+((@MargenPropuesto+#Impuestos)/100)
Set @ValorPropuesto = @Mcosto * @Mg
Set	@ValorNetoPropuesto = @ValorPropuesto /@Mg


--Select @Codigo as codigo,@Flete as flete,@MargenPropuesto as margen,@Mcosto as Mcosto,@ValorBruto as bruto,
--         @ValorPropuesto as ValorPropuestoBruto, @ValorNetoPropuesto as ValorPropuestoNeto, @Mg as Mg
 
--Truncate table Zw_ListaLC_TblPasoListas
            
insert into Zw_ListaLC_TblPasoListas (Lista, NombreLista, Codigo, PrecioUd1,
                                      PrecioUd2,EcuacionUd1,EcuacionUd2,
                                      Rtu, MargenPorc, VarMcosto, 
                                      VarPm, VarUc, VarFlete, VarIva, VarIla, 
                                      VarNetoDigit,VarValorDigit)

SELECT   DISTINCT  Zw_ListaLC_Listas_1.Lista As 'Lista', 
           Zw_ListaLC_Listas_1.NombreLista As 'NombreLista', 
           dbo.MAEPR.KOPR As 'Codigo', 
           dbo.TABPRE.PP01UD As 'PrecioUd1', 
           dbo.TABPRE.PP02UD As 'PrecioUd2', 
           dbo.TABPRE.ECUACION As 'EcuacionUd1', 
           dbo.TABPRE.ECUACIONU2 As 'EcuacionUd2', 
           dbo.MAEPR.RLUD As 'Rtu', 
           dbo.TABPRE.MG01UD As 'Margen', 
           CASE 
            WHEN ISNULL(dbo.MAEPREM.PPUL01, 0) > ISNULL(dbo.MAEPREM.PM, 0) THEN ISNULL(dbo.MAEPREM.PPUL01, 0) 
            ELSE ISNULL(dbo.MAEPREM.PM, 0) END AS 'Mcosto', 
           dbo.MAEPREM.PM As 'PPm', 
           dbo.MAEPREM.PPUL01 As 'PUc',
           @Flete AS 'Flete', 
           @Iva As 'Iva', 
           @Ila As 'Ila',
           0,
           @ValorBruto
FROM         dbo.PDIMEN RIGHT OUTER JOIN
                      dbo.MAEPREM ON dbo.PDIMEN.CODIGO = dbo.MAEPREM.KOPR RIGHT OUTER JOIN
                      dbo.MAEPR ON dbo.MAEPREM.KOPR = dbo.MAEPR.KOPR LEFT OUTER JOIN
                      dbo.TABPRE ON dbo.MAEPR.KOPR = dbo.TABPRE.KOPR LEFT OUTER JOIN
                      dbo.Zw_ListaLC_Listas AS Zw_ListaLC_Listas_1 ON dbo.TABPRE.KOLT = Zw_ListaLC_Listas_1.Lista
WHERE     (dbo.TABPRE.KOLT IN
                          (
                          SELECT Lista FROM dbo.Zw_ListaLC_Listas Where Accion in (1,2)
                          )) AND 
                               (dbo.MAEPR.KOPR = @Codigo) AND 
                               (dbo.MAEPREM.EMPRESA = @Empresa)
 
                      
--select * from Zw_ListaLC_TblPasoListas ORDER BY Lista