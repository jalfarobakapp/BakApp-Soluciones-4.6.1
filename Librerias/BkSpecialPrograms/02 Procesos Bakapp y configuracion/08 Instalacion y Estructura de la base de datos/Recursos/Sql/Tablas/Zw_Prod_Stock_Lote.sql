USE [#Base#]

CREATE TABLE [dbo].[Zw_Prod_Stock_Lote](
	[Empresa]		[char](2)		NOT NULL DEFAULT (''),
	[Sucursal]		[varchar](3)	NOT NULL DEFAULT (''),
	[Bodega]		[varchar](3)	NOT NULL DEFAULT (''),
	[NroLote]		[varchar](20)	NOT NULL DEFAULT (''),
	[SubLote]		[varchar](20)	NOT NULL DEFAULT (''),
	[Codigo]		[varchar](13)	NOT NULL DEFAULT (''),
	[FElaboracion]	[datetime]		NULL,
	[FVencimiento]	[datetime]		NULL,
	[Stfilt1]		[float]			NOT NULL DEFAULT (0),
	[Stfilt2]		[float]			NOT NULL DEFAULT (0),
	[Sttr1]			[float]			NOT NULL DEFAULT (0),
	[Sttr2]			[float]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Prod_Stock_Lote] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[Sucursal] ASC,
	[Bodega] ASC,
	[NroLote] ASC,
	[SubLote] ASC,
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

