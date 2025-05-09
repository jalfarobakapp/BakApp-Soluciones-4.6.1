USE [#Base#]


CREATE TABLE [dbo].[Zw_Demonio_Conf_Cerrar_Documentos](
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[NombreEquipo]	[varchar](50)	NOT NULL DEFAULT (''),
	[Id_Padre]		[int]			NOT NULL DEFAULT (0),
	[Ejecutar]		[bit]			NOT NULL DEFAULT (0),
	[Tido]			[varchar](3)	NOT NULL DEFAULT (''),
	[Dias]			[int]			NOT NULL DEFAULT (0),
	[FEmision]		[bit]			NOT NULL DEFAULT (0),
	[FDespacho]		[bit]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Demonio_Conf_Cerrar_Documentos] PRIMARY KEY CLUSTERED 
(
	[NombreEquipo] ASC,
	[Id_Padre] ASC,
	[Tido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



