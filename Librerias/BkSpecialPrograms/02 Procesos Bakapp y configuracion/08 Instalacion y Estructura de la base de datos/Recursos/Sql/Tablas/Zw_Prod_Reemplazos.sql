USE [#Base#]


CREATE TABLE [dbo].[Zw_Prod_Reemplazos](
	[Codigo] [varchar](13) NOT NULL DEFAULT (''),
	[Codigo_Madre] [varchar](13) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Prod_Reemplazos] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC,
	[Codigo_Madre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



