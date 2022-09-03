USE [#Base#]


CREATE TABLE [dbo].[Zw_Wordpress](
	[Codigo_Pagina]			[varchar](10)	NOT NULL DEFAULT (''),
	[Nombre_Pagina]			[varchar](100)	NOT NULL DEFAULT (''),
	[Host]					[varchar](50)	NOT NULL DEFAULT (''),
	[Usuario]				[varchar](50)	NOT NULL DEFAULT (''),
	[Clave]					[varchar](50)	NOT NULL DEFAULT (''),
	[Puerto_X_Defecto]		[bit]			NOT NULL DEFAULT (0),
	[Puerto]				[int]			NOT NULL DEFAULT (0),
	[Base_Datos]			[varchar](50)	NOT NULL DEFAULT (''),
	[Conexion_Activa]		[bit]			NOT NULL DEFAULT (0),
	[Cod_Lista]				[varchar](3)	NOT NULL DEFAULT (''),
	[Usar_Stock_Maximo]		[bit]			NOT NULL DEFAULT (0),
	[Stock_Maximo]			[float]			NOT NULL DEFAULT (0),
	[Codigo_Padre_Primario] [bit]			NOT NULL DEFAULT (0),
	[Desactiva_01]			[bit]			NOT NULL DEFAULT (0),
	[Desactiva_02]			[bit]			NOT NULL DEFAULT (0),
	[Desactiva_03]			[bit]			NOT NULL DEFAULT (0),
	[Desactiva_04]			[bit]			NOT NULL DEFAULT (0),
	[Minimo_Stock]			[float]			NOT NULL DEFAULT (0),
	[Grabar_Stock_X_Bodega] [bit]			NOT NULL DEFAULT (0),
	[Consumer_Key_Get]		[varchar](50)	NOT NULL DEFAULT (''),
	[Consumer_Secret_Get]	[varchar](50)	NOT NULL DEFAULT (''),
	[Consumer_Key_Put]		[varchar](50)	NOT NULL DEFAULT (''),
	[Consumer_Secret_Put]	[varchar](50)	NOT NULL DEFAULT (''),
    [BaseReal]	    		[bit]			NOT NULL DEFAULT (0),
	[PrecioNeto]			[bit]			NOT NULL DEFAULT (0),
) ON [PRIMARY]



