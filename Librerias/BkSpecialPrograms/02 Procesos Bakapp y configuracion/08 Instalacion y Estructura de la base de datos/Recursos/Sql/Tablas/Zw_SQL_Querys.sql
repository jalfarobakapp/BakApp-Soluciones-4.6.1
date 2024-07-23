USE [#Base#]


CREATE TABLE [dbo].[Zw_SQL_Querys](
	[Id]                    [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Query]          [varchar](200)      NOT NULL DEFAULT (''),
	[SQL_Query]             [varchar](max)      NOT NULL DEFAULT (''),
	[Funcionario]           [varchar](3)        NOT NULL DEFAULT (''),
	[Consulta_Global]       [bit]               NOT NULL DEFAULT (0),
	[Consulta_Personal]     [bit]               NOT NULL DEFAULT (0),
    [Nota]                  [varchar](max)      NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_SQL_Querys] PRIMARY KEY CLUSTERED 
(
	[Nombre_Query] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]



