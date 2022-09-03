USE [#Base#]


CREATE TABLE [dbo].[Zw_Prod_SolCompra](
	[Id_SCom] [int] IDENTITY(1,1)   NOT NULL,
	[Empresa] [char](2)             NOT NULL DEFAULT (''),
	[Sucursal] [char](3)            NOT NULL DEFAULT (''),
	[Bodega] [char](3)              NOT NULL DEFAULT (''),
	[Numero] [varchar](10)          NOT NULL DEFAULT (''),
	[Estado] [char](3)              NOT NULL DEFAULT (''),
	[Existe_Producto] [bit]         NOT NULL DEFAULT (0),
	[Codigo] [varchar](13)          NOT NULL DEFAULT (''),
	[Descripcion] [varchar](50)     NOT NULL DEFAULT (''),
	[Cantidad] [float]              NOT NULL DEFAULT (0),
	[Observaciones] [varchar](2000) NOT NULL DEFAULT (''),
	[CodFun_Solicita] [char](3)     NOT NULL DEFAULT (''),
	[CodFun_Envio] [char](3)        NOT NULL DEFAULT (''),
	[Para_Stock] [bit]              NOT NULL DEFAULT (0),
	[Venta_Calzada] [bit]           NOT NULL DEFAULT (0),
	[CodCliente] [varchar](13)      NOT NULL DEFAULT (''),
	[CodSucCliente] [varchar](10)   NOT NULL DEFAULT (''),
	[Deja_Anticipo] [bit]           NOT NULL DEFAULT (0),
	[Valor_Anticipo] [float]        NOT NULL DEFAULT (0),
	[Fecha_Envio] [datetime]        NOT NULL DEFAULT (Getdate()),
	[Codigo_Usar] [varchar](13)     NOT NULL DEFAULT (''),
	[Idmaeedo_OCC] [int]            NOT NULL DEFAULT (0),
	[Visto] [bit]                   NOT NULL DEFAULT (0),
	[Fecha_Visto] [datetime]        NULL,
 CONSTRAINT [PK_Zw_Prod_SolCompra] PRIMARY KEY CLUSTERED 
(
	[Id_SCom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



