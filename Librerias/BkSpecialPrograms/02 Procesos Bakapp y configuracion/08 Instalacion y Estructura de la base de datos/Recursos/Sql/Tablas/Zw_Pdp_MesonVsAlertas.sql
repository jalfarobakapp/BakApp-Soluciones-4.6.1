USE [#Base#]


CREATE TABLE [dbo].[Zw_Pdp_MesonVsAlertas](
	[Id_Alertas]		[int] IDENTITY(1,1) NOT NULL,
	[Empresa]			[char](2)		NOT NULL DEFAULT (''),
	[Idpotpr]			[int]			NOT NULL DEFAULT (0),
	[Idpotl]			[int]			NOT NULL DEFAULT (0),
	[Idpote]			[int]			NOT NULL DEFAULT (0),
	[Numot]				[char](10)		NOT NULL DEFAULT (''),
	[Operacion]			[varchar](4)	NOT NULL DEFAULT (''),
	[Codigoob_Envia]	[char](8)		NOT NULL DEFAULT (''),
	[Alerta]			[varchar](1000) NOT NULL DEFAULT (''),
	[Fecha_Alerta]		[datetime]		NOT NULL DEFAULT (Getdate()),
	[Editada]			[bit]			NOT NULL DEFAULT (0),
	[Id_Padre_Edit]		[int]			NOT NULL DEFAULT (0),
	[Eliminada]			[bit]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Pdp_MesonVsAlertas] PRIMARY KEY CLUSTERED 
(
	[Id_Alertas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


