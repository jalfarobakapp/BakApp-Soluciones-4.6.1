USE [#Base#]


CREATE TABLE [dbo].[ZW_SOC_Detalle](
	[Id_SOC] [int] NOT NULL DEFAULT (0),
	[Id_SOC_Detalle] [int] IDENTITY(1,1) NOT NULL,
	[Nro_SOC] [char](10) NOT NULL DEFAULT (''),
	[Autorizado] [bit] NOT NULL DEFAULT (0),
	[Empresa] [char](2) NOT NULL DEFAULT (''),
	[Sucursal] [char](3) NOT NULL DEFAULT (''),
	[Bodega] [char](3) NOT NULL DEFAULT (''),
	[Codigo] [char](13) NOT NULL DEFAULT (''),
	[Rtu] [float] NOT NULL DEFAULT (0),
	[CodigoAlternativo] [char](20) NOT NULL DEFAULT (''),
	[Descripcion] [varchar](100) NOT NULL DEFAULT (''),
	[CodProveedor] [char](10) NOT NULL DEFAULT (''),
	[SucProveedor] [varchar](10) NOT NULL DEFAULT (''),
	[Cantidad] [float] NOT NULL DEFAULT (0),
	[Cantidad_Ud1] [float] NOT NULL DEFAULT (0),
	[Cantidad_Ud2] [float] NOT NULL DEFAULT (0),
	[UnTrans] [char](2) NOT NULL DEFAULT (''),
	[UdTrans] [float] NOT NULL DEFAULT (0),
	[Precio] [float] NOT NULL DEFAULT (0),
	[Precio_Origen] [float] NOT NULL DEFAULT (0),
	[Precio_Lista] [float] NOT NULL DEFAULT (0),
	[Precio_Ud1] [float] NOT NULL DEFAULT (0),
	[Precio_Ud2] [float] NOT NULL DEFAULT (0),
	[DsctoPorc] [float] NOT NULL DEFAULT (0),
	[Dscto1] [float] NOT NULL DEFAULT (0),
	[Dscto2] [float] NOT NULL DEFAULT (0),
	[Dscto3] [float] NOT NULL DEFAULT (0),
	[Dscto4] [float] NOT NULL DEFAULT (0),
	[Dscto5] [float] NOT NULL DEFAULT (0),
	[Totaldescuento] [float] NOT NULL DEFAULT (0),
	[Ivalinea] [float] NOT NULL DEFAULT (0),
	[Netolinea] [float] NOT NULL DEFAULT (0),
	[Brutolinea] [float] NOT NULL DEFAULT (0),
	[CrearProducto] [bit] NOT NULL DEFAULT (0),
	[TipoProducto] [char](3) NOT NULL DEFAULT (''),
	[Marca] [varchar](20) NOT NULL DEFAULT (''),
	[Rubro] [varchar](4) NOT NULL DEFAULT (''),
	[Super_Familia] [varchar](4) NOT NULL DEFAULT (''),
	[Familia] [varchar](4) NOT NULL DEFAULT (''),
	[Sub_Familia] [varchar](4) NOT NULL DEFAULT (''),
	[Unidad1] [char](2) NOT NULL DEFAULT (''),
	[Unidad2] [char](2) NOT NULL DEFAULT (''),
	[Observacion_Linea] [varchar](200) NOT NULL DEFAULT (''),
	[Moneda] [varchar](10) NOT NULL DEFAULT (''),
	[Tipo_Moneda] [char](1) NOT NULL DEFAULT (''),
	[Tipo_Cambio] [float] NOT NULL DEFAULT (0),
	[Cantidad_Original] [float] NOT NULL DEFAULT (0),
	[Obs_Rechazo] [varchar](200) NOT NULL DEFAULT (''),
	[Cantidad_Sugerida_Rechazo] [float] NOT NULL DEFAULT (0),
	[Obs_Apelacion] [varchar](200) NOT NULL DEFAULT (''),
	[Cantidad_Sugerida_Apelacion] [float] NOT NULL DEFAULT (0),
	[Cantidad_Definitiva] [float] NOT NULL DEFAULT (0),
	[Precio_Dig] [bit] NOT NULL DEFAULT (0),
	
 CONSTRAINT [PK_ZW_SOC_Detalle] PRIMARY KEY CLUSTERED 
(
	[Id_SOC] ASC,
	[Id_SOC_Detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



