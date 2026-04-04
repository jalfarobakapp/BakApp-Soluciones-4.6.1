USE [#Base#]


CREATE TABLE [dbo].[Zw_WMS_RutaXDoc](
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[Empresa]		[char](2)			NOT NULL DEFAULT (''),
	[Id_Enc]		[int]				NOT NULL DEFAULT (0),
	[Idmaeedo]		[int]				NOT NULL DEFAULT (0),
	[Tido]			[char](3)			NOT NULL DEFAULT (''),
	[Nudo]			[varchar](10)		NOT NULL DEFAULT (''),
	[Ruta]			[varchar](10)		NOT NULL DEFAULT (''),
	[OrdenRuta]		[int]				NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_WMS_RutaXDoc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



