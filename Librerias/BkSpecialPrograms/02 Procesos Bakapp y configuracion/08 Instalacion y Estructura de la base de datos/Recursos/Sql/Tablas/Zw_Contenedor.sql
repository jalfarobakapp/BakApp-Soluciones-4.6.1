USE [#Base#]

CREATE TABLE [dbo].[Zw_Contenedor](
	[IdCont]			[int] IDENTITY(1,1) NOT NULL,
	[Empresa]			[char](2)		NOT NULL DEFAULT (''),
	[Contenedor]		[varchar](20)	NOT NULL DEFAULT (''),
	[NombreContenedor]	[varchar](50)	NOT NULL DEFAULT (''),
	[Idmaeedo_Rela]		[int]			NOT NULL DEFAULT (0),
	[Tido_Rela]			[char](3)		NOT NULL DEFAULT (''),
	[Nudo_Rela]			[varchar](10)	NOT NULL DEFAULT (''),
	[Estado]			[varchar](15)	NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Contenedor] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[Contenedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


