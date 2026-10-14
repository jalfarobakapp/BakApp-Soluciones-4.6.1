USE [#Base#]

CREATE TABLE [dbo].[Zw_ListaLC_ValPro](
	[Codigo]			[char](13) NOT NULL,
	[Mcosto]			[float]		NOT NULL DEFAULT (0),
	[VproNeto]			[float]		NOT NULL DEFAULT (0),
	[VproBruto]			[float]		NOT NULL DEFAULT (0),
	[MgDigitado]		[float]		NOT NULL DEFAULT (0),
	[ValDigitado]		[float]		NOT NULL DEFAULT (0),
	[FechaModif]		[date]		NULL,
	[HoraModif]			[time](7)	NULL,
	[FechaHoraModif]	[datetime]	NULL,
	[Procesada]			[bit]		NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Lista_LC_ValPro] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



