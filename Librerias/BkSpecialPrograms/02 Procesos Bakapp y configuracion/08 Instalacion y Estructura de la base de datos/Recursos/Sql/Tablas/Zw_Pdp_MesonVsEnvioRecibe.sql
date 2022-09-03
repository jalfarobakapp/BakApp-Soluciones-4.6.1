USE [#Base#]

CREATE TABLE [dbo].[Zw_Pdp_MesonVsEnvioRecibe](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdMaquina]			[int]           NOT NULL DEFAULT (0),
	[IdMeson_Envia]		[int]           NOT NULL DEFAULT (0),
	[IdMeson_Recibe]	[int]           NOT NULL DEFAULT (0),
	[Codigo]			[varchar](13)   NOT NULL DEFAULT (''),
	[CantEnvia]			[float]         NOT NULL DEFAULT (0),
	[FechaHoraEnvia]	[datetime]      NOT NULL DEFAULT (Getdate()),
	[EsReproceso]		[bit]           NOT NULL DEFAULT (0),
	[Codigoob]			[varchar](8)    NOT NULL DEFAULT (''),
	[CodFuncionario]	[varchar](3)    NOT NULL DEFAULT (''),
	[EsMesonVirtual]	[bit]           NOT NULL DEFAULT (0),
	[EsMesonFinal]		[bit]           NOT NULL DEFAULT (0),
	[Idpotl_Padre]		[int]           NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Pdp_MesonVsEnvioRecibe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

