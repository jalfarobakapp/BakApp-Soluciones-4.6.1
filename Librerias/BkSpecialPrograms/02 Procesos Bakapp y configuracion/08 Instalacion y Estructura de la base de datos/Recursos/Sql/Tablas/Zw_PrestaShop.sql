USE [#Base#]


CREATE TABLE [dbo].[Zw_PrestaShop](
	[Codigo_Pagina]			[varchar](10)	NOT NULL DEFAULT (''),
	[Nombre_Pagina]			[varchar](100)	NOT NULL DEFAULT (''),
	[Host]					[varchar](50)	NOT NULL DEFAULT (''),
	[Usuario]				[varchar](50)	NOT NULL DEFAULT (''),
	[Clave]					[varchar](50)	NOT NULL DEFAULT (''),
	[Puerto_X_Defecto]		[bit]			NOT NULL DEFAULT (0),
	[Puerto]				[int]			NOT NULL DEFAULT (3306),
	[Base_Datos]			[varchar](50)	NOT NULL DEFAULT (''),
	[Conexion_Activa]		[bit]			NOT NULL DEFAULT (0),
	[Cod_Lista]				[varchar](3)	NOT NULL DEFAULT (''),
	[Usar_Stock_Maximo]		[bit]			NOT NULL DEFAULT (0),
	[Stock_Maximo]			[float]			NOT NULL DEFAULT (0),
	[Codigo_Padre_Primario]	[bit]			NOT NULL DEFAULT (0),
	[Desactiva_01]			[bit]			NOT NULL DEFAULT (0),
	[Desactiva_02]			[bit]			NOT NULL DEFAULT (0),
	[Desactiva_03]			[bit]			NOT NULL DEFAULT (0),	
	[Desactiva_04]			[bit]			NOT NULL DEFAULT (0),	
	[Minimo_Stock]			[float]			NOT NULL DEFAULT (0),	
    [Grabar_Stock_X_Bodega]	[bit]			NOT NULL DEFAULT (0),	
 CONSTRAINT [PK_Zw_PrestaShop] PRIMARY KEY CLUSTERED 
(
	[Codigo_Pagina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]




