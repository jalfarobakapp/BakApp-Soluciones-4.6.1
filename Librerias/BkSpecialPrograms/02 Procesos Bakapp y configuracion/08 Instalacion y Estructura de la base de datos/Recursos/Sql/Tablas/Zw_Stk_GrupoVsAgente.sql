USE [#Base#]

CREATE TABLE [dbo].[Zw_Stk_GrupoVsAgente](
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[Id_Grupo]		[int]		NOT NULL DEFAULT (0),
	[CodAgente]		[char](3)	NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Stk_GrupoVsAgente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


