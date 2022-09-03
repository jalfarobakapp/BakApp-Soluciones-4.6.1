USE [#Base#]


CREATE TABLE [dbo].[Zw_Referencias_Dte](
	[Id_Ref]	[int] IDENTITY(1,1) NOT NULL,
	[Id_Doc]	[int] NOT NULL DEFAULT (''),
	[Tido]		[char](3) NOT NULL DEFAULT (''),
	[Nudo]		[varchar](10) NOT NULL DEFAULT (''),
	[NroLinRef] [int] NOT NULL DEFAULT (0),
	[TpoDocRef] [varchar](3) NOT NULL DEFAULT (''),
	[FolioRef]	[varchar](20) NOT NULL DEFAULT (''),
	[RUTOt]		[varchar](10) NOT NULL DEFAULT (''),
	[IdAdicOtr]	[varchar](20) NOT NULL DEFAULT (''),
	[FchRef]	[datetime] NULL,
	[CodRef]	[int] NOT NULL DEFAULT (0),
	[RazonRef]	[varchar](90) NOT NULL DEFAULT (''),
	[Kasi]		[bit] NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Referencias_Dte] PRIMARY KEY CLUSTERED 
(
	[Id_Doc] ASC,
	[NroLinRef] ASC,
	[Kasi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

