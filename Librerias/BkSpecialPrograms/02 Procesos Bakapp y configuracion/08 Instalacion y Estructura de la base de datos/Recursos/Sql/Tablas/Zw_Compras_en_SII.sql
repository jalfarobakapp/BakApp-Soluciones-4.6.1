USE [#Base#]


CREATE TABLE [dbo].[Zw_Compras_en_SII](
	[Id]						[int] IDENTITY(1,1) NOT NULL ,
	[Periodo]					[int]				NOT NULL DEFAULT (0),
	[Mes]						[int]				NOT NULL DEFAULT (0),
	[Idmaeedo]					[int]				NOT NULL DEFAULT (0),
	[TipoDoc]					[int]				NOT NULL DEFAULT (0),
	[Tido]						[char](3)			NOT NULL DEFAULT (''),
	[Nudo]						[char](10)			NOT NULL DEFAULT (''),
	[Endo]						[char](13)			NOT NULL DEFAULT (''),
	[Libro]						[char](14)			NOT NULL DEFAULT (''),
	[Rut_Proveedor]				[varchar](15)		NOT NULL DEFAULT (''),
	[Razon_Social]				[varchar](100)		NOT NULL DEFAULT (''),
	[Folio]						[varchar](10)		NOT NULL DEFAULT (''),
	[Idmaeedo_Sugerido]			[int]				NOT NULL DEFAULT (0),
	[Tido_Sugerido]				[char](3)			NOT NULL DEFAULT (''),
	[Nudo_Sugerido]				[varchar](10)		NOT NULL DEFAULT (''),
	[Libro_Sugerido]			[char](14)			NOT NULL DEFAULT (''),
	[Fecha_Docto]				[datetime]			NULL,
	[Fecha_Recepcion]			[datetime]			NULL,
	[Fecha_Acuse]				[datetime]			NULL,
	[Monto_Exento]				[float]				NOT NULL DEFAULT (0),
	[Monto_Neto]				[float]				NOT NULL DEFAULT (0),
	[Monto_Iva_Recuperable]		[float]				NOT NULL DEFAULT (0),
	[Monto_Iva_No_Recuperable]	[float]				NOT NULL DEFAULT (0),
	[Monto_Total]				[float]				NOT NULL DEFAULT (0),
	[Valor_Otro_impuesto]		[float]				NOT NULL DEFAULT (0),
	[Vanedo]					[float]				NOT NULL DEFAULT (0),
	[Vaivdo]					[float]				NOT NULL DEFAULT (0),
	[Vabrdo]					[float]				NOT NULL DEFAULT (0),
	[Diferencia]				[float]				NOT NULL DEFAULT (0),
	[Revisado]					[bit]				NOT NULL DEFAULT (0),
	[Idmaeedo_GRC]  			[int]				NOT NULL DEFAULT (0)
) ON [PRIMARY]