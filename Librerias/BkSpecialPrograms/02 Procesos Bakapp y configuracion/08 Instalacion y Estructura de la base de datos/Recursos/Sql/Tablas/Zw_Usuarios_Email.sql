USE [#Base#]

CREATE TABLE [dbo].[Zw_Usuarios_Email](
	[CodFuncionario] [char](3) NOT NULL DEFAULT (''),
	[Email_SMTP] [varchar](100) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Usuarios_Email] PRIMARY KEY CLUSTERED 
(
	[CodFuncionario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]