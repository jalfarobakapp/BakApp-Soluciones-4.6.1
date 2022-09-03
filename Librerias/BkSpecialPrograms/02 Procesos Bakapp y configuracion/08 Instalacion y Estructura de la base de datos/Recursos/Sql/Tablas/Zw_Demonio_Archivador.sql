USE [#Base#]

CREATE TABLE [dbo].[Zw_Demonio_Archivador](
	[Idmaeedo]	[int]			NOT NULL,
	[Tido]		[char](3)		NOT NULL  DEFAULT (''),
	[Nudo]		[varchar](10)	NOT NULL  DEFAULT (''),
	[Fecha]		[datetime]		NULL,
	[Archivado] [bit]			NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_Zw_Demonio_Archivador] PRIMARY KEY CLUSTERED 
(
	[Idmaeedo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

