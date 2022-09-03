USE [#Base#]


CREATE TABLE [dbo].[Zw_TmpInv_InvParcialConf](
	[Empresa] [char](2) NOT NULL DEFAULT (''),
	[Sucursal] [char](3) NOT NULL DEFAULT (''),
	[Bodega] [char](3) NOT NULL DEFAULT (''),
	[OpcionCosto] [char](3) NOT NULL DEFAULT (''),
	[ListaDeCostos] [char](3) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_TmpInv_InvParcialConf] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[Sucursal] ASC,
	[Bodega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

