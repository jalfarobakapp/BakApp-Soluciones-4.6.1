USE [#Base#]

CREATE TABLE [dbo].[Zw_Stmp_Enc_Permisos](
	[Id]						[int] IDENTITY(1,1) NOT NULL,
	[Id_Enc]					[int]				NOT NULL,
	[CodPermiso]				[varchar](10)		NOT NULL,
	[NroRemota]					[char](10)			NOT NULL,
	[CodFuncionario_Solicita]	[char](3)			NOT NULL,
	[CodFuncionario_Autoriza]	[char](3)			NOT NULL,
	[FechaHora]					[datetime]			NULL
) ON [PRIMARY]



