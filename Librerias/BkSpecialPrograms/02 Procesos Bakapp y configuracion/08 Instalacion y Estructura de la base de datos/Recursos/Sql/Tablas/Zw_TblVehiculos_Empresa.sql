USE [#Base#]


CREATE TABLE [dbo].[Zw_TblVehiculos_Empresa](
	[Id_Vehiculo] [int] IDENTITY(1,1) NOT NULL,
	[Patente] [varchar](10) NOT NULL DEFAULT (''),
	[Nombre_Vehiculo] [varchar](50) NOT NULL DEFAULT (''),
	[CodigoTabla_Tipo_Vehiculo] [varchar](50) NOT NULL DEFAULT (''),
	[Ano] [int] NOT NULL DEFAULT (0),
	[CodigoTabla_Marca] [varchar](20) NOT NULL DEFAULT (''),
	[CodigoTabla_Modelo] [varchar](20) NOT NULL DEFAULT (''),
	[Nro_Motor] [varchar](50) NOT NULL DEFAULT (''),
	[Nro_Chasis] [varchar](50) NOT NULL DEFAULT (''),
	[Nro_Serie] [varchar](50) NOT NULL DEFAULT (''),
	[Nro_Vin] [varchar](50) NOT NULL DEFAULT (''),
	[CodigoTabla_Color] [varchar](50) NOT NULL DEFAULT (''),
	[Kilometraje] [float] NOT NULL DEFAULT (0),
	[CodChofer] [char](3) NOT NULL DEFAULT (''),
	[Habilitado] [bit] NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_TblVehiculos_Empresa] PRIMARY KEY CLUSTERED 
(
	[Patente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
