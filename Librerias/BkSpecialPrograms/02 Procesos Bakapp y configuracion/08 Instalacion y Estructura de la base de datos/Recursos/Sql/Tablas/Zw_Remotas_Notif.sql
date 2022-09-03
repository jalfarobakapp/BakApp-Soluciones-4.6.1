USE [#Base#]

CREATE TABLE [dbo].[Zw_Remotas_Notif](
	[Id]						[int] IDENTITY(1,1) NOT NULL,
	[NroRemota]					[varchar](10)		NOT NULL DEFAULT (''),
	[CodFuncionario_Destino]	[char](3)			NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Remotas_Notif] PRIMARY KEY CLUSTERED 
(
	[NroRemota] ASC,
	[CodFuncionario_Destino] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
