USE [#Base#]


CREATE TABLE [dbo].[Zw_Picking](
	[Idmaeedo]	[int]			NOT NULL DEFAULT (0),
	[Tido]		[varchar](3)	NOT NULL DEFAULT (''),
	[Nudo]		[varchar](10)	NOT NULL DEFAULT (''),
	[Impreso]	[bit]			NOT NULL DEFAULT (0),
	[Correo]	[bit]			NOT NULL DEFAULT (0),
	[Fecha]		[datetime]		NULL,
	[Hora]		[datetime]		NULL,
 CONSTRAINT [PK_Zw_Picking] PRIMARY KEY CLUSTERED 
(
	[Idmaeedo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



