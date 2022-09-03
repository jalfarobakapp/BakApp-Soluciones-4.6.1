USE [#Base#]

CREATE TABLE [dbo].[Zw_Prod_Padres](
	[Carpeta]		[varchar](100) NOT NULL DEFAULT (''),
	[Codigo_Hijo]	[varchar](13) NOT NULL DEFAULT (''),
	[Codigo_Padre]	[varchar](13) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Prod_Padres] PRIMARY KEY CLUSTERED 
(
	[Carpeta] ASC,
	[Codigo_Hijo] ASC,
	[Codigo_Padre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


