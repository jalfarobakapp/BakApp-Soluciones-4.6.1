USE [#Base#]

CREATE TABLE [dbo].[Zw_Despacho_Simple](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Idmaeedo]				[int] NOT NULL DEFAULT (0),
	[CodTipoDespacho]		[int] NOT NULL DEFAULT (0),
	[TipoDespacho]			[varchar](50) NOT NULL DEFAULT (''),
	[TipoPagoDesp]			[varchar](50) NOT NULL DEFAULT (''),
	[DireccionDesp]			[varchar](50) NOT NULL DEFAULT (''),
	[TransporteDesp]		[varchar](50) NOT NULL DEFAULT (''),
	[ObservacionesDesp]		[varchar](50) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Despacho_Simple] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



