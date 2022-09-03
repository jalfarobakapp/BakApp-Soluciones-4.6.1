USE [#Base#]

CREATE TABLE [dbo].[Zw_Docu_ObligPg](
	[Id]		        [int] IDENTITY(1,1) NOT NULL,
	[Modalidad]         [char](5)			NOT NULL DEFAULT (''),
	[Tido]		        [char](3)			NOT NULL DEFAULT (''),
	[Tidp]		        [char](3)			NOT NULL DEFAULT (''),
	[Concepto]	        [varchar](13)		NOT NULL DEFAULT (''),
    [Obliga_DRA]	    [int]       		NOT NULL DEFAULT (0),
	[Cond_Obliga]       [varchar](10)		NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Docu_ObligPg] PRIMARY KEY CLUSTERED 
(
	[Modalidad] ASC,
	[Tido] ASC,
	[Tidp] ASC,
	[Concepto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
