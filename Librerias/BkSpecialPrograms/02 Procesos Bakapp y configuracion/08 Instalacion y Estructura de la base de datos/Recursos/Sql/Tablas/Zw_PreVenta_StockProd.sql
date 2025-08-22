USE [#Base#]

CREATE TABLE [dbo].[Zw_PreVenta_StockProd](
    [Id]                    [int]           IDENTITY(1,1) NOT NULL,
	[Empresa]		        [char](2)		NOT NULL DEFAULT (''),
    [Sucursal]              [varchar](3)    NOT NULL DEFAULT (''),
	[Bodega]                [varchar](3)    NOT NULL DEFAULT (''),
	[IdCont]		        [int]			NOT NULL DEFAULT (0),
	[Contenedor]	        [varchar](20)	NOT NULL DEFAULT (''),
	[Codigo]		        [varchar](13)	NOT NULL DEFAULT (''),
	[StcfiUd1]		        [float]			NOT NULL DEFAULT (0),
	[StcfiUd2]		        [float]			NOT NULL DEFAULT (0),
	[StcCompUd1]	        [float]			NOT NULL DEFAULT (0),
	[StcCompUd2]	        [float]			NOT NULL DEFAULT (0),
    [StcfiDisponibleUd1]    [float]			NOT NULL DEFAULT (0),
	[StcfiDisponibleUd2]    [float]			NOT NULL DEFAULT (0),
	[FormatoPqte]           [varchar](20)   NOT NULL DEFAULT (''),
	[Ud1XPqte]              [float]			NOT NULL DEFAULT (0),
	[CantMinFormato]        [int]			NOT NULL DEFAULT (0),
	[Moneda]                [varchar](3)    NOT NULL DEFAULT (''),
	[PrecioXUd1]            [float]         NOT NULL DEFAULT (0),
) ON [PRIMARY]
