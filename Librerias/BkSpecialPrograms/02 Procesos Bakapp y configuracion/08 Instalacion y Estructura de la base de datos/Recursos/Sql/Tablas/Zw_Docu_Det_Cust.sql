USE [#Base#]

CREATE TABLE [dbo].[Zw_Docu_Det_Cust](
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[Idmaeedo]		[int]			NOT NULL DEFAULT (0),
	[Idmaeddo]		[int]			NOT NULL DEFAULT (0),
	[CodigoAlt]		[varchar](20)	NOT NULL DEFAULT (''),
	[Descripcion]	[varchar](50)	NOT NULL DEFAULT (''),
	[Cantidad]		[float]			NOT NULL DEFAULT (0),
	[Codigo]		[varchar](13)	NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Docu_Det_Cust] PRIMARY KEY CLUSTERED 
(
	[Idmaeedo] ASC,
	[Idmaeddo] ASC,
	[CodigoAlt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
