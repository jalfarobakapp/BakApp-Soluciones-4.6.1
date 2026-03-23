USE [#Base#]

CREATE TABLE [dbo].[Zw_Prod_SobreStock](
	[Id]					[int] IDENTITY(1,1) NOT NULL,
	[Empresa]				[char](2)           NOT NULL DEFAULT (''),
	[Codigo]				[varchar](13)       NOT NULL DEFAULT (''),
	[Descripcion]			[varchar](50)       NOT NULL DEFAULT (''),
	[Activo]				[bit]               NOT NULL DEFAULT (0),
	[CodFuncionarioCrea]	[varchar](3)        NOT NULL DEFAULT (''),
	[FechaVigencia]			[datetime]          NULL,
	[FormatoPqte]			[varchar](10)       NOT NULL DEFAULT (''),
	[PqteHabilitado]		[float]             NOT NULL DEFAULT (0),
	[PqteStock]             [float]             NOT NULL DEFAULT (0),
	[PqteComprometido]		[float]             NOT NULL DEFAULT (0),
	[PqteComprometidoSol]	[float]             NOT NULL DEFAULT (0),
	[Ud1XPqte]				[float]             NOT NULL DEFAULT (0),
	[CantMinFormato]		[float]             NOT NULL DEFAULT (0),
	[Moneda]				[varchar](3)        NOT NULL DEFAULT (''),
	[PrecioXUd1]			[float]             NOT NULL DEFAULT (0),
    [Eliminado]             [bit]               NOT NULL DEFAULT (0),
    [StSobStockUd1]         [float]             NOT NULL DEFAULT (0),
    [StSobStockUd2]         [float]             NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Prod_SobreStock_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
