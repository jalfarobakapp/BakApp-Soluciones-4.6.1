USE [#Base#]

CREATE TABLE [dbo].[Zw_Estaciones_Ruta_PDF](
	[NombreEquipo]  [varchar](50)   NOT NULL DEFAULT (''),
	[Modalidad]		[varchar](5)    NOT NULL DEFAULT (''),
	[Tido]			[char](3)       NOT NULL DEFAULT (''),
	[Ruta_PDF]		[varchar](1000) NOT NULL DEFAULT (''),
	[Empresa]		[char](2) NOT NULL DEFAULT (''),
    [Tipo_Ruta]		[varchar](1000) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Estaciones_Ruta_PDF] PRIMARY KEY CLUSTERED 
(
	[NombreEquipo] ASC,
	[Modalidad] ASC,
	[Tido] ASC,
	[Empresa] ASC,
    [Tipo_Ruta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


