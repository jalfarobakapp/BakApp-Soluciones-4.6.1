USE [#Base#]

CREATE TABLE [dbo].[Zw_ListaPreHistorico](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[Codigo]			[varchar](13)		NOT NULL,
	[Lista]				[varchar](3)		NOT NULL,
	[CodFuncionario]	[varchar](3)		NOT NULL,
	[Fechagrab]			[datetime]			NULL,
	[FechaVigencia]		[datetime]			NULL,
	[PrecioUd1]			[float]				NOT NULL,
	[PrecioUd2]			[float]				NOT NULL,
	[FxEjecUd1]			[bit]				NOT NULL,
	[FxEjecUd2]			[bit]				NOT NULL,
 CONSTRAINT [PK_Zw_ListaPreHistorico] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]



