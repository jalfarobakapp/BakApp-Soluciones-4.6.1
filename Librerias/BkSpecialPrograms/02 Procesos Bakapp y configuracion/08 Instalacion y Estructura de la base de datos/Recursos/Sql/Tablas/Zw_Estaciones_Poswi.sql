USE [#Base#]


CREATE TABLE [dbo].[Zw_Estaciones_Poswi](
	[NombreEquipo]			[varchar](50)	NOT NULL DEFAULT (''),
	[Usuario]				[char](3)		NOT NULL DEFAULT (''),
	[Modalidad]				[nchar](10)		NOT NULL DEFAULT (''),
	[Impresion_X_BakApp]	[bit]			NOT NULL DEFAULT (1),
	[Enviar_Mail_X_BakApp]	[bit]			NOT NULL DEFAULT (1),
	[Impresion_X_Poswi]		[bit]			NOT NULL DEFAULT (0),
	[Enviar_Mail_X_Poswi]	[bit]			NOT NULL DEFAULT (0),
	[Mail_Random]			[varchar](20)	NOT NULL DEFAULT ('EMAILCOMER'),
	[Version]				[varchar](50)	NOT NULL DEFAULT (''),
	[Num_Poswi]				[bit]			NOT NULL DEFAULT (0),
	[COV_Nro]				[varchar](10)	NOT NULL DEFAULT (''),
	[NVV_Nro]				[varchar](10)	NOT NULL DEFAULT (''),
	[NombreEquipo_Demonio]	[varchar](50)	NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Estaciones_Poswi] PRIMARY KEY CLUSTERED 
(
	[NombreEquipo] ASC,
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
