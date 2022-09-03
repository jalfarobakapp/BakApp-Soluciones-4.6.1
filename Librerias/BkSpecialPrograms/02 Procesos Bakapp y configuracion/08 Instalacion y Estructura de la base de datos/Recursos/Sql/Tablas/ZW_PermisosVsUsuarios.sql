USE [#Base#]


CREATE TABLE [dbo].[ZW_PermisosVsUsuarios](
	[Semilla]			[int] IDENTITY(1,1) NOT NULL,
	[CodUsuario]		[char](3)			NOT NULL DEFAULT (''),
	[CodPermiso]		[varchar](20)		NOT NULL DEFAULT (''),
	[Llave]				[varchar](100)		NOT NULL DEFAULT (''),
	[Valor_Dscto]		[float]				NOT NULL DEFAULT (0),
	[Valor_Max_Compra]	[float]				NOT NULL DEFAULT (0)
) ON [PRIMARY]

