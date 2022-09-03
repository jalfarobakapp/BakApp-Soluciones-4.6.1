USE [#Base#]

CREATE TABLE [dbo].[Zw_Pdp_MesonVsAlertas_Lectura](
	[Id_Lectura]	[int] IDENTITY(1,1) NOT NULL,
	[Id_Alertas]	[int]		NOT NULL DEFAULT (''),
	[Leida]			[bit]		NOT NULL DEFAULT (''),
	[Codigoob_Lee]	[char](8)	NOT NULL DEFAULT (''),
	[Fecha_Leida]	[datetime]	NOT NULL DEFAULT (Getdate()),
 CONSTRAINT [PK_Zw_Pdp_MesonVsAlertas_Lectura] PRIMARY KEY CLUSTERED 
(
	[Id_Lectura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



