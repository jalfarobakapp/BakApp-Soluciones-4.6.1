USE [#Base#]


CREATE TABLE [dbo].[Zw_WMS_Ubicaciones_Stock_X_Producto](
	[Id]                [int]           IDENTITY(1,1) NOT NULL,
	[Empresa]           [char](2)       NOT NULL DEFAULT (''),
	[Sucursal]          [char](3)       NOT NULL DEFAULT (''),
	[Bodega]            [char](3)       NOT NULL DEFAULT (''),
	[Codigo_Sector]     [varchar](20)   NOT NULL DEFAULT (''),
	[Codigo_Ubic]       [varchar](20)   NOT NULL DEFAULT (''),
	[Codigo]            [char](13)      NOT NULL DEFAULT (''),
	[Rtu]               [float]         NOT NULL DEFAULT (0),
	[Stock_Ud1]         [float]         NOT NULL DEFAULT (0),
	[Stock_Ud2]         [float]         NOT NULL DEFAULT (0),
	[NroSerie]          [varchar](20)   NOT NULL DEFAULT (''),
	[Peso_Kg]           [float]         NOT NULL DEFAULT (0),
	[Volumen]           [float]         NOT NULL DEFAULT (0),
    [Paquete]           [varchar](10)   NOT NULL,
	[PaletCaja]         [varchar](10)   NOT NULL,
    [Lote]              [varchar](10)   NOT NULL,
 CONSTRAINT [PK_Zw_WMS_Ubicaciones_Stock_X_Producto] PRIMARY KEY CLUSTERED 
(
	[Empresa]       ASC,
	[Sucursal]      ASC,
	[Bodega]        ASC,
	[Codigo_Ubic]   ASC,
	[Codigo]        ASC,
	[NroSerie]      ASC,
    [Paquete]       ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
