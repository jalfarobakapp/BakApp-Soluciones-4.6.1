USE [#Base#]

CREATE TABLE [dbo].[Zw_CRV_Viajes](
	[Id_CRV]				[int] IDENTITY(1,1) NOT NULL,
	[Nro_CRV]				[varchar](10)	NOT NULL DEFAULT (''),
	[Patente]				[varchar](10)	NOT NULL DEFAULT (''),
	[CodChofer]				[varchar](3)	NOT NULL DEFAULT (''),
	[CodEntidad]			[varchar](13)	NOT NULL DEFAULT (''),
	[SucEntidad]			[varchar](10)	NOT NULL DEFAULT (''),
	[Pais]					[varchar](3)	NOT NULL DEFAULT (''),
	[Ciudad]				[nchar](3)		NOT NULL DEFAULT (''),
	[Comuna]				[nchar](3)		NOT NULL DEFAULT (''),
	[Direccion]				[varchar](100)	NOT NULL DEFAULT (''),
	[Fecha_Hora_Salida]		[datetime] NULL,
	[Fecha_Hora_Llegada]	[datetime] NULL,
	[Km_Salida]				[float]			NOT NULL DEFAULT (0),
	[Km_Llegada]			[float]			NOT NULL DEFAULT (0),
	[Observacion]			[varchar](1000) NOT NULL DEFAULT (''),
	[Estado]				[char](2)		NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_CRV_Viajes] PRIMARY KEY CLUSTERED 
(
	[Nro_CRV] ASC,
	[Patente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



