USE [#Base#]

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON

CREATE TABLE [dbo].[ZW_SOC_Encabezado](
	[Id_SOC]            [int] IDENTITY(1,1) NOT NULL,
	[Empresa]           [char](2)     NOT NULL DEFAULT (''),
	[Sucursal]          [char](3)     NOT NULL DEFAULT (''),
	[Nro_SOC]           [char](10)    NOT NULL DEFAULT (''),
	[Tipo_Compra]       [char](1)     NOT NULL DEFAULT (''),
	[Venta_Calzada]     [bit]         NOT NULL DEFAULT (1),
	[Fecha]             [datetime]    NULL,
	[Hora]              [time](7)     NULL,
	[Estado]            [char](2)     NOT NULL DEFAULT ('P'),
	[CodProveedor]      [varchar](50) NOT NULL DEFAULT (''),
	[SucProveedor]      [varchar](50) NOT NULL DEFAULT (''),
	[CodEntDespacho]    [varchar](10) NOT NULL DEFAULT (''),
	[CodSucEntDespacho] [varchar](20) NOT NULL DEFAULT (''),
	[CodCliente]        [char](10)    NOT NULL DEFAULT (''),
	[SucCliente]        [char](20)    NOT NULL DEFAULT (''),
	[Vendedor]          [char](3)     NOT NULL DEFAULT (''),
	[Neto]              [float]       NOT NULL DEFAULT (0),
	[Ila]               [float]       NOT NULL DEFAULT (0),
	[Iva]               [float]       NOT NULL DEFAULT (0),
	[Total]             [float]       NOT NULL DEFAULT (0),
	[IdMaeedo_OCC]      [varchar](20) NOT NULL DEFAULT (''),
	[Nro_OCC]           [varchar](10) NOT NULL DEFAULT (''),
	[Permiso]           [bit]         NOT NULL DEFAULT (0),
	[Ir_a_Retirar]      [bit]         NOT NULL DEFAULT (0),
	[Accion_Retiro]     [char](1)     NOT NULL DEFAULT (''),
	[En_Uso]            [bit]         NOT NULL DEFAULT (0),
	[En_Uso_Usuario]    [char](3)     NOT NULL DEFAULT (''),
	[En_Uso_Fecha]      [datetime]    NULL,
	[En_Uso_Liberada]   [bit]         NOT NULL DEFAULT (0),
	[Stand_By]          [bit]         NOT NULL DEFAULT (0),
 CONSTRAINT [PK_ZW_SOC_Encabezado] PRIMARY KEY CLUSTERED 
(
	[Nro_SOC] ASC,
	[Stand_By] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]



