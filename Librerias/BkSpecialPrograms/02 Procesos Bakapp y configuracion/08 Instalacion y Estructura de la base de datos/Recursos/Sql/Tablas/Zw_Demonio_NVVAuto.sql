USE [#Base#]

CREATE TABLE [dbo].[Zw_Demonio_NVVAuto](
	[Id_Enc]			[int] IDENTITY(1,1) NOT NULL,
	[IdmaeedoOCC_Ori]	[int] NOT NULL DEFAULT (0),
	[NudoOCC_Ori]		[varchar](10) NOT NULL DEFAULT (''),
	[Endo_Ori]			[varchar](13) NOT NULL DEFAULT (''),
	[Suendo_Ori]		[varchar](10) NOT NULL DEFAULT (''),
	[FechaGrab]			[datetime] NULL,
	[GenerarNVV]		[bit] NOT NULL DEFAULT (0),
	[NVVGenerada]		[bit] NOT NULL DEFAULT (0),
	[Idmaeedo_NVV]		[int] NOT NULL DEFAULT (0),
	[Nudo_NVV]			[varchar](10) NOT NULL DEFAULT (''),
	[Feemdo_NVV]		[datetime] NULL,
	[Observaciones]		[varchar](max) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Demonio_NVVAuto] PRIMARY KEY CLUSTERED 
(
	[Id_Enc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]



