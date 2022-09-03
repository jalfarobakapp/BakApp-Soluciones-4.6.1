USE [#Base#]


CREATE TABLE [dbo].[Zw_Prod_Log_Compras](
	[Id]                    [int] IDENTITY(1,1) NOT NULL,
	[NombreEquipo]          [varchar](50)       NOT NULL DEFAULT (''),
	[CodFuncionario]        [char](3)           NOT NULL DEFAULT (''),
	[Codigo]                [varchar](13)       NOT NULL DEFAULT (''),
	[Fecha_Ult_Estudio]     [datetime]          NULL,
	[Bodegas_Stock]         [varchar](500)      NOT NULL DEFAULT (''),
	[Stock_Fisico_Ud1]      [float]             NOT NULL DEFAULT (0),
	[Stock_Fisico_Ud2]      [float]             NOT NULL DEFAULT (0),
	[Stock_CriticoUd1_Rd]   [float]             NOT NULL DEFAULT (0),
	[Stock_CriticoUd2_Rd]   [float]             NOT NULL DEFAULT (0),
	[Bodegas_Venta]         [varchar](500)      NOT NULL DEFAULT (''),
	[RotDiariaUd1]          [float]             NOT NULL DEFAULT (0),
	[RotDiariaUd2]          [float]             NOT NULL DEFAULT (0),
	[RotMensualUd1]         [float]             NOT NULL DEFAULT (0),
	[RotMensualUd2]         [float]             NOT NULL DEFAULT (0),
	[CantComprar]           [float]             NOT NULL DEFAULT (0),
	[CantSugeridaTot]       [float]             NOT NULL DEFAULT (0),
	[Dias_Avastecer]        [int]               NOT NULL DEFAULT (0),
	[Tiempo_Reposicion]     [int]               NOT NULL DEFAULT (0),
	[CodProveedor]          [varchar](10)       NOT NULL DEFAULT (''),
	[CodSucProveedor]       [varchar](13)       NOT NULL DEFAULT (''),
	[CodAlternativo]        [varchar](20)       NOT NULL DEFAULT (''),
	[Idmaeedo_Ult_occ]      [int]               NOT NULL DEFAULT (0),
	[Fecha_Ult_occ]         [datetime]          NULL,
 CONSTRAINT [PK_Zw_Prod_Log_Compras] PRIMARY KEY CLUSTERED 
(
	[NombreEquipo] ASC,
	[CodFuncionario] ASC,
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
