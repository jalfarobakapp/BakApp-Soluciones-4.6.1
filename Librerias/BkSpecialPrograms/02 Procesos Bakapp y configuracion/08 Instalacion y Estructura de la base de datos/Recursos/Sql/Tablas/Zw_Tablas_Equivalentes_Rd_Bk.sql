USE [#Base#]

CREATE TABLE [dbo].[Zw_Tablas_Equivalentes_Rd_Bk](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tabla_Random] [varchar](30) NOT NULL DEFAULT (''),
	[Campo_Random] [varchar](30) NOT NULL DEFAULT (''),
	[Tabla_Bakapp] [varchar](30) NOT NULL DEFAULT (''),
	[Campo_Bakapp] [varchar](30) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Tablas_Equivalentes_Rd_Bk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


