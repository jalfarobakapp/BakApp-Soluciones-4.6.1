USE [#Base#]

CREATE TABLE [dbo].[Zw_Stk_Tickets_PorDefecto](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[CodFuncionario]	[varchar](3)	NOT NULL DEFAULT (''),
	[Asunto]			[varchar](50)	NOT NULL DEFAULT (''),
	[Id_Area]			[int]			NOT NULL DEFAULT (0),
	[Id_Tipo]			[int]			NOT NULL DEFAULT (0),
	[Prioridad]			[varchar](2)	NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Stk_Tickets_PorDefecto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Zw_Stk_Tickets_PorDefecto] UNIQUE NONCLUSTERED 
(
	[CodFuncionario] ASC,
	[Asunto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



