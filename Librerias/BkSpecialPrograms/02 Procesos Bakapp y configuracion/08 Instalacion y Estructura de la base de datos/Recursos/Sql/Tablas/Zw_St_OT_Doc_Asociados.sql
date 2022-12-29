USE [#Base#]


CREATE TABLE [dbo].[Zw_St_OT_Doc_Asociados](
	[Id_Ot]				[int]          NOT NULL DEFAULT (0),
	[Idmaeedo]			[int]          NOT NULL DEFAULT (0),
	[Tido]				[char](3)      NOT NULL DEFAULT (''),
	[Nudo]				[varchar](10)  NOT NULL DEFAULT (''),
	[Estado]			[char](1)      NOT NULL DEFAULT (''),
	[Fecha_Doc]			[datetime]     NOT NULL DEFAULT (Getdate()),
	[Fecha_Asociacion]	[datetime]     NOT NULL DEFAULT (Getdate()),
	[Garantia]			[bit]          NOT NULL DEFAULT (0),
	[Seleccionado]		[bit]          NOT NULL DEFAULT (0),
	[Documento_Externo] [bit]          NOT NULL DEFAULT (0),
	[MovTodasSubOT]     [bit]          NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_St_OT_Doc_Asociados] PRIMARY KEY CLUSTERED 
(
	[Id_Ot] ASC,
	[Idmaeedo] ASC,
	[Garantia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
