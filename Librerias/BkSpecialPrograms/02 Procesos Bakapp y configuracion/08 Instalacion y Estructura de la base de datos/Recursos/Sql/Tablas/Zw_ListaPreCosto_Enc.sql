USE [#Base#]

CREATE TABLE [dbo].[Zw_ListaPreCosto_Enc](
	[Id]                        [int] IDENTITY(1,1) NOT NULL,
	[Lista]						[char](3) NOT NULL,
	[Proveedor]					[varchar](13) NOT NULL DEFAULT (''),
	[Sucursal]					[varchar](10) NOT NULL DEFAULT (''),
	[FechaVigenciaDesde]		[datetime] NOT NULL,
	[FechaVigenciaHasta]		[datetime] NULL,
	[NombreLista]				[varchar](50) NOT NULL DEFAULT (''),
	[CodFuncionario_Crea]		[varchar](3) NOT NULL DEFAULT (''),
	[FechaCreacion]				[datetime] NULL,
	[Vigente]					[bit] NOT NULL DEFAULT (0),
	[CodFuncionario_Activa]		[varchar](3) NOT NULL DEFAULT (''),
	[FechaActivacionVigencia]	[datetime] NULL,
 CONSTRAINT [PK_Zw_ListaPreCosto_Enc] PRIMARY KEY CLUSTERED 
(
	[Lista] ASC,
	[Proveedor] ASC,
	[Sucursal] ASC,
	[FechaVigenciaDesde] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
