USE [#Base#]

CREATE TABLE [dbo].[Zw_DTE_ListaEventosDoc](
	[Id]				[int]           IDENTITY(1,1) NOT NULL,
	[Id_Dte]			[int]			NOT NULL DEFAULT (0),
	[Id_Trackid]		[int]			NOT NULL DEFAULT (0),
	[Idmaeedo]			[int]			NOT NULL DEFAULT (0),
	[Tido]				[char](3)		NOT NULL DEFAULT (''),
	[Nudo]				[varchar](10)	NOT NULL DEFAULT (''),
	[CodEvento]			[varchar](3)	NOT NULL DEFAULT (''),
	[DescEvento]		[varchar](200)	NOT NULL DEFAULT (''),
	[RutResponsable]	[varchar](10)	NOT NULL DEFAULT (''),
	[DvResponsable]		[varchar](1)	NOT NULL DEFAULT (''),
	[FechaEvento]		[datetime]		NULL 
 CONSTRAINT [PK_Zw_DTE_ListaEventosDoc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

