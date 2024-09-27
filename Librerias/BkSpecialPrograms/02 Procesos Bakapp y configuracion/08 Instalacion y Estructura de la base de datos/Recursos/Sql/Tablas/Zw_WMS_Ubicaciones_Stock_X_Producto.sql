USE [#Base#]


CREATE TABLE [dbo].[Zw_WMS_Ubicaciones_Stock_X_Producto](
	[Id_Movimiento]         [int] IDENTITY(1,1) NOT NULL,
	[Tipo_Movimiento]       [char](1)           NOT NULL DEFAULT (''),
	[Nro_Movimiento]        [varchar](10)       NOT NULL DEFAULT (''),
	[Empresa]               [char](2)           NOT NULL DEFAULT (''),
	[Sucursal]              [char](3)           NOT NULL DEFAULT (''),
	[Bodega]                [char](3)           NOT NULL DEFAULT (''),
	[Codigo_Sector]         [varchar](20)       NOT NULL DEFAULT (''),
	[Codigo_Ubic]           [varchar](20)       NOT NULL DEFAULT (''),
	[Codigo]                [char](13)          NOT NULL DEFAULT (''),
	[Rtu]                   [float]             NOT NULL DEFAULT (0),
	[Stock_Ud1]             [float]             NOT NULL DEFAULT (0),
	[Stock_Ud2]             [float]             NOT NULL DEFAULT (0),
	[NroSerie_01]           [varchar](20)       NOT NULL DEFAULT (''),
	[NroSerie_02]           [varchar](20)       NOT NULL DEFAULT (''),
	[Peso_Kg]               [float]             NOT NULL DEFAULT (0),
	[Volumen]               [float]             NOT NULL DEFAULT (0),
	[Idmaeddo]              [int]               NOT NULL DEFAULT (0),
	[Tido]                  [varchar](3)        NOT NULL DEFAULT (''),
	[Nudo]                  [varchar](10)       NOT NULL DEFAULT (''),
	[Fecha_Movimiento]      [datetime]          NULL,
	[Reservado]             [bit]               NOT NULL DEFAULT (0),
	[Idmaeddo_Reserva]      [int]               NOT NULL DEFAULT (0),
	[Tido_Reserva]          [varchar](3)        NOT NULL DEFAULT (''),
	[Nudo_Reserva]          [varchar](10)       NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_WMS_Ubicaciones_Stock_X_Producto] PRIMARY KEY CLUSTERED 
(
	[Id_Movimiento] ASC,
	[Tipo_Movimiento] ASC,
	[Nro_Movimiento] ASC,
	[Empresa] ASC,
	[Sucursal] ASC,
	[Bodega] ASC,
	[Codigo_Sector] ASC,
	[Codigo_Ubic] ASC,
	[Codigo] ASC,
	[NroSerie_01] ASC,
	[NroSerie_02] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
