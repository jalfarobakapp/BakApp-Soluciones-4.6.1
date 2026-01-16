USE [#Base#]

CREATE TABLE [dbo].[Zw_WMS_Paquetes](
	[Id]				[int]			IDENTITY(1,1) NOT NULL,
	[CodPaquete]		[varchar](10)	NOT NULL DEFAULT (''),
	[Sku]				[varchar](13)	NOT NULL DEFAULT (''),
	[Empresa]			[char](2)		NOT NULL DEFAULT (''),
	[Sucursal]			[varchar](3)	NOT NULL DEFAULT (''),
	[Bodega]			[varchar](3)	NOT NULL DEFAULT (''),
	[Ubicacion]			[varchar](30)	NOT NULL DEFAULT (''),
	[Pallet]			[varchar](10)	NOT NULL DEFAULT (''),
	[Qty]				[float]			NOT NULL DEFAULT (0),
	[Qty2]				[float]			NOT NULL DEFAULT (0),
	[Id_Enc]			[int]			NOT NULL DEFAULT (0),
	[Idmaeedo]			[int]			NOT NULL DEFAULT (0),
	[Reservado]			[bit]			NOT NULL DEFAULT (0),
	[Tido]				[varchar](3)	NOT NULL DEFAULT (''),
	[Nudo]				[varchar](10)	NOT NULL DEFAULT (''),
    [FechaIngreso]      [datetime]      NULL,
 CONSTRAINT [PK_Zw_WMS_Paquetes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Zw_WMS_Paquetes] UNIQUE NONCLUSTERED 
(
	[CodPaquete] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]




