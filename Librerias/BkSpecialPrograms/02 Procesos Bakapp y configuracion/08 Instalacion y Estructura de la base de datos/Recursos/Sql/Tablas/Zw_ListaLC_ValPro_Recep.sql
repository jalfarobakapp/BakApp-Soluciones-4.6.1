USE [#Base#]

CREATE TABLE [dbo].[Zw_ListaLC_ValPro_Recep](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[Idmaeedo]			[int]			NOT NULL DEFAULT (0),
	[Idmaeddo]			[int]			NOT NULL DEFAULT (0),
	[Tido]				[char](3)		NOT NULL DEFAULT (''),
	[Nudo]				[varchar](10)	NOT NULL DEFAULT (''),
	[Codigo]			[varchar](13)	NOT NULL DEFAULT (''),
	[FechaRev]			[datetime]		NULL,
	[Estado]			[varchar](15)	NOT NULL DEFAULT (''),
	[CodFuncionario]	[varchar](3)	NOT NULL DEFAULT (''),
	[NombreEquipo]		[varchar](50)	NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_ListaLC_ValPro_Recep] PRIMARY KEY CLUSTERED 
(
	[Idmaeedo] ASC,
	[Idmaeddo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



