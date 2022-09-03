USE [#Base#]


CREATE TABLE [dbo].[Zw_EstacionesBkp_Configuracion_Local](
	[Id]					[int] IDENTITY(1,1) NOT NULL,
	[NombreEquipo]			[varchar](50)	NOT NULL DEFAULT (''),
	[Modulo]				[varchar](50)	NOT NULL DEFAULT (''),
	[Descripcion_Accion]	[varchar](200)	NOT NULL DEFAULT (''),
	[Codigo_Accion]			[varchar](20)	NOT NULL DEFAULT (''),
	[Tipo_de_dato]			[varchar](20)	NOT NULL DEFAULT (''),
	[Accion]				[varchar](100)	NOT NULL DEFAULT (''),
	[Max_Caracteres]		[int]			NOT NULL DEFAULT (0),
	[Autorizado]			[bit]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_EstacionesBkp_Configuracion_Local] PRIMARY KEY CLUSTERED 
(
	[NombreEquipo] ASC,
	[Codigo_Accion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

