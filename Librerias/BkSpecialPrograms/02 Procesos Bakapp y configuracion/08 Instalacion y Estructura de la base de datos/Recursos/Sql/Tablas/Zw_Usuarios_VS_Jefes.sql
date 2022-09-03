USE [#Base#]

CREATE TABLE [dbo].[Zw_Usuarios_VS_Jefes](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[Empresa]			[varchar](2)		NOT NULL DEFAULT (''),
	[CodFuncionario]	[char](3)			NOT NULL DEFAULT (''),
	[CodJefe]			[char](3)			NOT NULL DEFAULT (''),
	[CodJefeReemplazo]	[char](3)			NOT NULL DEFAULT ('')
) ON [PRIMARY]



