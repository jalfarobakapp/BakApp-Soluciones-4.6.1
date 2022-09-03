USE [#Base#]


CREATE TABLE [dbo].[Zw_Entidad_Cia_Seguros](
	[Rut]				[varchar](13)	NOT NULL DEFAULT (''),
	[Monto_Asignado]	[float]			NOT NULL DEFAULT (0),
	[Moneda]			[varchar](3)	NOT NULL DEFAULT (''),
	[Clascrediticia]	[varchar](10)	NOT NULL DEFAULT (''),
	[Fecha_Vigencia]	[datetime]		NULL,
	[Porc_Exposicion]	[float]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Entidad_Cia_Seguros] PRIMARY KEY CLUSTERED 
(
	[Rut] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


