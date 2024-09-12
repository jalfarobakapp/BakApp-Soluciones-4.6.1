USE [#Base#]

CREATE TABLE [dbo].[Zw_Entidades_Holding](
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[CodHolding]	[varchar](10)		NOT NULL DEFAULT (''),
	[NombeHolding]	[varchar](50)		NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Entidades_Holding] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



