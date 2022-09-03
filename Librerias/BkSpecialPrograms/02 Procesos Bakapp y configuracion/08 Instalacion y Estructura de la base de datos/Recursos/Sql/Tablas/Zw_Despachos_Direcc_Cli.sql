USE [#Base#]

CREATE TABLE [dbo].[Zw_Despachos_Direcc_Cli](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[CodEntidad]		[varchar](13)   NOT NULL DEFAULT(''),
	[CodSucEntidad]		[varchar](10)   NOT NULL DEFAULT(''),
	[Rut]				[varchar](20)   NOT NULL DEFAULT(''),
	[Nombre_Entidad]	[varchar](50)   NOT NULL DEFAULT(''),
	[Pais]				[char](3)       NOT NULL DEFAULT(''),
	[Ciudad]			[char](3)       NOT NULL DEFAULT(''),
	[Comuna]			[char](3)       NOT NULL DEFAULT(''),
	[Direccion]			[varchar](100)  NOT NULL DEFAULT(''),
	[Telefono]			[varchar](30)   NOT NULL DEFAULT(''),
	[Email]				[varchar](100)  NOT NULL DEFAULT(''),
	[Tipo_Venta]		[varchar](20)   NOT NULL DEFAULT(''),
	[Transportista]		[varchar](13)   NOT NULL DEFAULT(''),
	[Por_Defecto]		[bit]           NOT NULL DEFAULT(0),
    [Nombre_Contacto]	[varchar](50)	Not Null Default (''),
    [Usar_HA]   		[bit]           NOT NULL DEFAULT(0),
    [HA_Manana_Desde]   [datetime]      NULL,
	[HA_Manana_Hasta]   [datetime]      NULL,
	[HA_Tarde_Desde]    [datetime]      NULL,
	[HA_Tarde_Hasta]    [datetime]      NULL,
 CONSTRAINT [PK_Zw_Despachos_Direcc_Cli] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
