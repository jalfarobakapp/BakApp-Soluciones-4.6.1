USE [#Base#]

CREATE TABLE [dbo].[Zw_Stk_Agentes](
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[CodAgente]		[varchar](30)		NOT NULL DEFAULT (''),
	[Activo]		[bit]				NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Stk_Agentes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


