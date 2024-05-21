USE [#Base#]

CREATE TABLE [dbo].[Zw_Stmp_DetPick](
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[Id_Enc]		[int] NOT NULL DEFAULT (0),
	[Idmaeedo]		[int] NOT NULL DEFAULT (0),
	[Idmaeddo]		[int] NOT NULL DEFAULT (0),
	[Tido]			[varchar](3) NOT NULL DEFAULT (''),
	[Nudo]			[varchar](10) NOT NULL DEFAULT (''),
	[Sku]			[varchar](13) NOT NULL DEFAULT (''),
	[Sku_desc]		[varchar](50) NOT NULL DEFAULT (''),
	[Tag]			[varchar](20) NOT NULL DEFAULT (''),
	[Udtrpr]		[int] NOT NULL DEFAULT (0),
	[Qty]			[float] NOT NULL DEFAULT (0),
	[Loc]			[varchar](30) NOT NULL DEFAULT (''),
	[Cont]			[varchar](30) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Stmp_DetPick] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

