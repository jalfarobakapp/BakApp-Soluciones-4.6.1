USE [#Base#]


CREATE TABLE [dbo].[Zw_TablaDeCaracterizaciones](
	[Tabla]				[varchar](50) NOT NULL DEFAULT (''),
	[DescripcionTabla]	[varchar](100) NOT NULL DEFAULT (''),
	[CodigoTabla]		[varchar](30) NOT NULL DEFAULT (''),
	[NombreTabla]		[varchar](100) NOT NULL DEFAULT (''),
	[Orden]				[int] NOT NULL DEFAULT (0),
	[ApColor]			[bit] NOT NULL DEFAULT (0),
	[ApModelo]			[bit] NOT NULL DEFAULT (0),
	[ApMedida]			[bit] NOT NULL DEFAULT (0),
	[Porcentaje]		[float] NOT NULL DEFAULT (0),
	[Valor]				[float] NOT NULL DEFAULT (0),
	[Padre_Tabla]		[varchar](20) NOT NULL DEFAULT (''),
	[Padre_CodigoTabla] [varchar](20) NOT NULL DEFAULT (''),
	[Fecha]				[datetime] NULL,
	[Equiv_Kotabla]		[varchar](10) NOT NULL DEFAULT (''),
	[Equiv_Kocarac]		[varchar](20) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_TablaDeCaracterizaciones] PRIMARY KEY CLUSTERED 
(
	[Tabla] ASC,
	[CodigoTabla] ASC,
	[Padre_Tabla] ASC,
	[Padre_CodigoTabla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
