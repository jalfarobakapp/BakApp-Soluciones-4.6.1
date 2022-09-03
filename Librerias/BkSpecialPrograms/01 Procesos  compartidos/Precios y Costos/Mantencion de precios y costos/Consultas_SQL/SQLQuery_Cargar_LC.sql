USE [#Base#]

CREATE TABLE [dbo].[Zw_PsLc#Funcionario#](
    [Id]                Int IDENTITY(1, 1)	NOT NULL,
    [Select]            [Bit]				Default (0),
	[Lista]             [char](3)			NOT NULL,
	[Proveedor]         [Varchar](13)		NOT NULL,
	[Sucursal]          [Varchar](10)		NOT NULL,
	[CodAlternativo]    [Varchar](20)		NOT NULL,
	[Codigo]            [char](13)			NOT NULL,
	[Descripcion]       [Varchar](50)		Default '',
	[Descripcion_Alt]   [Varchar](100)		Default '',
	[CostoUd1]          [Float]				Default (0),
	[CostoUd2]          [Float]				Default (0),
	[Rtu]               [Float]				Default (0),
	[FechaVigencia]     [Date],
	[Desc1]             [Float]				Default (0),
	[Desc2]             [Float]				Default (0),
	[Desc3]             [Float]				Default (0),
	[Desc4]             [Float]				Default (0),
	[Desc5]             [Float]				Default (0),
	[DescSuma]          [Float]				Default (0),
	[Flete]             [Float]				Default (0),
	[Un_Compra]         [Char](2)			Default '',
	[Un_MinCompra]      [Int]				Default (1),
	[Ac_Oferta]         [Bit]				Default (0),
	[Ac_Disponible]     [Bit]				Default (0),
	[Ac_Cotizar]        [Bit]				Default (0),
	[No_Usar]           [Bit]				Default (0),
	[Ud1]               [Varchar](2)		Default '',
	[Ud2]               [Varchar](2)		Default '',
	[Pm]                [Float]				Default (0),
	[Uc1]               [Float]				Default (0),
	[Uc2]               [Float]				Default (0),
	[Repetidos]         [Int]				Default (0),
    [Id_Hijo]           [Int]				Default (0),
    [Id_Padre]          [Int]				Default (0),
 CONSTRAINT [PK_Zw_PsLc#Funcionario#] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Lista]   ASC,
	[Codigo]  ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, 
       IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, 
       ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

--INSERT INTO Zw_PsLp#Funcionario# (Lista,Codigo,Descripcion,Rtu,Formula,Redondear,
--                                  Costo,Precio,Margen,Margen_Adicional,
--                                  Costo2,Precio2,Margen2,Margen_Adicional2,
--                                  DsctoMax,Dscto1,Dscto2,Dscto3,Dscto4,Dscto5,Flete)
--#ConsultaSql#                                  

