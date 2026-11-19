USE [#Base#]

CREATE TABLE [dbo].[Zw_Entidades_Asociacion](
	[Id]					[int] IDENTITY(1,1) NOT NULL,
	[CodEntidad]			[varchar](8)	NOT NULL DEFAULT (''),
	[CodSucEntidad]			[varchar](10)	NOT NULL DEFAULT (''),
	[Codigo_Nodo]			[varchar](20)	NOT NULL DEFAULT (''),
	[DescripcionBusqueda]	[varchar](1000) NOT NULL DEFAULT (''),
	[Para_filtro]			[bit]			NOT NULL DEFAULT (0),
	[Nodo_origen]			[int]			NOT NULL DEFAULT (0),
	[Clas_unica]			[bit]			NOT NULL DEFAULT (0),
	[Codigo_Madre]			[varchar](20)	NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Entidades_Asociacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


