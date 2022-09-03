USE [#Base#]

CREATE TABLE [dbo].[Zw_Prod_Doc_Ult_Ventas](
	[Idmaeedo]	[int]			NOT NULL DEFAULT (0),
	[Empresa]	[char](2)		NOT NULL DEFAULT (''),
	[Codigo]	[varchar](13)	NOT NULL DEFAULT (''),
	[Tido]		[char](3)		NOT NULL DEFAULT (''),
	[Nudo]		[varchar](10)	NOT NULL DEFAULT (''),
	[Endo]		[varchar](13)	NOT NULL DEFAULT (''),
	[Suendo]	[varchar](10)	NOT NULL DEFAULT (''),
	[Feemli]	[datetime]		NULL,
 CONSTRAINT [PK_Zw_Prod_Doc_Ult_Ventas_1] PRIMARY KEY CLUSTERED 
(
	[Idmaeedo] ASC,
	[Empresa] ASC,
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
