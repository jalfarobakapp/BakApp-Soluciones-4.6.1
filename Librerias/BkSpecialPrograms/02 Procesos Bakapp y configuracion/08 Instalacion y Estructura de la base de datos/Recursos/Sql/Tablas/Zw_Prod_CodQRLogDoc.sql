USE [#Base#]


CREATE TABLE [dbo].[Zw_Prod_CodQRLogDoc](
	[Id]			[int] IDENTITY(1,1)	NOT NULL,
	[CodigoQR]		[varchar](300)		NOT NULL DEFAULT (''),
	[Kopral]		[varchar](21)		NOT NULL DEFAULT (''),
	[Tido]			[varchar](3)		NOT NULL DEFAULT (''),
	[Nudo]			[varchar](10)		NOT NULL DEFAULT (''),
	[Idmaeedo]		[int]				NOT NULL DEFAULT (0),
    [Kopr]		    [varchar](13)		NOT NULL DEFAULT (''),
    [CodLeido]		[varchar](300)		NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Prod_CodQRLogDoc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



