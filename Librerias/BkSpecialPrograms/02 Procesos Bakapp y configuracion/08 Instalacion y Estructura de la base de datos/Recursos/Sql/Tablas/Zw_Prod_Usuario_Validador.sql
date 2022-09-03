USE [#Base#]

CREATE TABLE [dbo].[Zw_Prod_Usuario_Validador](
	[Empresa]			[varchar](2) NOT NULL DEFAULT (''),
	[CodFuncionario]	[char](3) NOT NULL DEFAULT (''),
	[Codigo]			[varchar](13) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Prod_Usuario_Validador_1] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[CodFuncionario] ASC,
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
