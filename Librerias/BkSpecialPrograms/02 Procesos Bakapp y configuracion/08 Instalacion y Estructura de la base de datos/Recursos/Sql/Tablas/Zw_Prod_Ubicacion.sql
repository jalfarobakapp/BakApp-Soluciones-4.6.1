USE [#Base#]

CREATE TABLE [dbo].[Zw_Prod_Ubicacion](
	[Semilla]               [int] IDENTITY(1,1) NOT NULL,
	[Empresa]               [varchar](2)        NOT NULL DEFAULT (''),
	[Sucursal]              [varchar](3)        NOT NULL DEFAULT (''),
	[Bodega]                [varchar](3)        NOT NULL DEFAULT (''),
	[Id_Mapa]               [int]               NOT NULL DEFAULT (0),
	[Codigo_Sector]         [varchar](20)       NOT NULL DEFAULT (''),
	[Codigo_Ubic]           [varchar](20)       NOT NULL DEFAULT (''),
	[Codigo]                [char](13)          NOT NULL DEFAULT (''),
	[Primaria]              [bit]               NOT NULL DEFAULT (0),
	[Stock_Minimo_Ubic]     [float]             NOT NULL DEFAULT (0),
	[Stock_Maximo_Ubic]     [float]             NOT NULL DEFAULT (0),
    [FechaIngreso]          [datetime]          NULL,
	[Stock_Ubic_Ud1]        [float]             NOT NULL DEFAULT (0),
	[Stock_Ubic_Ud2]        [float]             NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Prod_Ubicacion] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[Sucursal] ASC,
	[Bodega] ASC,
	[Id_Mapa] ASC,
	[Codigo_Sector] ASC,
	[Codigo_Ubic] ASC,
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
