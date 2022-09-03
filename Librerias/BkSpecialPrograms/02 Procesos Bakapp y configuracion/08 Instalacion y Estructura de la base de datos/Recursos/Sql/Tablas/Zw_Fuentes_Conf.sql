USE [#Base#]


CREATE TABLE [dbo].[Zw_Fuentes_Conf](
	[Formulario]	[varchar](50)	NOT NULL DEFAULT (''),
	[Parrafo]		[varchar](50)	NOT NULL DEFAULT (''),
	[Etiqueta]		[char](2)		NOT NULL DEFAULT (''),
	[Fuente]		[varchar](50)	NOT NULL DEFAULT (''),
	[Tamano]		[float]			NOT NULL DEFAULT (0),
	[Estilo]		[int]			NOT NULL DEFAULT (0),
	[Color]			[float]			NOT NULL DEFAULT (0),
	[Columna_X]		[float]			NOT NULL DEFAULT (0),
	[Fila_Y]		[float]			NOT NULL DEFAULT (0),
	[Texto]			[varchar](1000) NOT NULL DEFAULT ('')
) ON [PRIMARY]


