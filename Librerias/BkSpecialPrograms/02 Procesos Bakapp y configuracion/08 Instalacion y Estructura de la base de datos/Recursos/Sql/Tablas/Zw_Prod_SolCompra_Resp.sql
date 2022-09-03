USE [#Base#]

CREATE TABLE [dbo].[Zw_Prod_SolCompra_Resp](
	[Id_Resp] [int] IDENTITY(1,1) NOT NULL,
	[Id_SCom] [int] NOT NULL DEFAULT (0),
	[Estado] [char](3) NOT NULL DEFAULT (''),
	[CodFun_Solicita] [char](3) NOT NULL DEFAULT (''),
	[CodFun_Responde] [char](3) NOT NULL DEFAULT (''),
	[Fecha] [datetime] NOT NULL DEFAULT (Getdate()),
	[Observaciones] [varchar](2000) NOT NULL DEFAULT (''),
	[Agotado] [bit] NOT NULL DEFAULT (0),
	[Pedido] [bit] NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Prod_SolCompra_Resp] PRIMARY KEY CLUSTERED 
(
	[Id_SCom] ASC,
	[Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



