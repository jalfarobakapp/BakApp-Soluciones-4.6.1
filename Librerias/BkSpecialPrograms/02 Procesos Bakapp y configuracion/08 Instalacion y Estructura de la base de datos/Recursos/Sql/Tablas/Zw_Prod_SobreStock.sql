USE [#Base#]

CREATE TABLE [dbo].[Zw_Prod_SobreStock](
	[Id]					[int] IDENTITY(1,1) NOT NULL,
	[Empresa]				[char](2)           NOT NULL,
	[Codigo]				[varchar](13)       NOT NULL,
	[Descripcion]			[varchar](50)       NOT NULL,
	[Activo]				[bit]               NOT NULL,
	[CodFuncionarioCrea]	[varchar](3)        NOT NULL,
	[FechaVigencia]			[datetime]          NULL,
	[FormatoPqte]			[varchar](10)       NOT NULL,
	[PqteHabilitado]		[float]             NOT NULL,
	[PqteComprometido]		[float]             NOT NULL,
	[PqteComprometidoSol]	[float]             NOT NULL,
	[Ud1XPqte]				[float]             NOT NULL,
	[CantMinFormato]		[float]             NOT NULL,
	[Moneda]				[varchar](3)        NOT NULL,
	[PrecioXUd1]			[float]             NOT NULL,
    [Eliminado]             [bit]               NOT NULL,
    [StSobStockUd1]         [float]             NOT NULL,
    [StSobStockUd2]         [float]             NOT NULL,
 CONSTRAINT [PK_Zw_Prod_SobreStock_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
