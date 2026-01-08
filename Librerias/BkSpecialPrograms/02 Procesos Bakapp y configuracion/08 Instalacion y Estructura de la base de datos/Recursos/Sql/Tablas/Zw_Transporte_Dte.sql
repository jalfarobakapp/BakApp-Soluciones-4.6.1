USE [#Base#]

CREATE TABLE [dbo].[Zw_Transporte_Dte](
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[Empresa]		[char](2)		NOT NULL DEFAULT (''),
	[Idmaeedo]		[int]			NOT NULL DEFAULT (0),
	[Tido]			[char](3)		NOT NULL DEFAULT (''),
	[Nudo]			[varchar](10)	NOT NULL DEFAULT (''),
	[Patente]		[varchar](8)	NOT NULL DEFAULT (''),
	[RUTTrans]		[varchar](10)	NOT NULL DEFAULT (''),
	[Chofer]		[varchar](40)	NOT NULL DEFAULT (''),
	[RUTChofer]		[varchar](10)	NOT NULL DEFAULT (''),
	[DirDest]		[varchar](70)	NOT NULL DEFAULT (''),
	[CmnaDest]		[varchar](20)	NOT NULL DEFAULT (''),
	[CiudadDest]	[varchar](20)	NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Transporte_Dte] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

