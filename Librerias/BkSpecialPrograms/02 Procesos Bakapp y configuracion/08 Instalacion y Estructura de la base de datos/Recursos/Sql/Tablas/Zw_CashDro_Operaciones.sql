USE [#Base#]

CREATE TABLE [dbo].[Zw_CashDro_Operaciones](
	[Id]                     [int] IDENTITY(1,1)	NOT NULL,
	[Numero]                 [varchar](10)			NOT NULL DEFAULT (''),
	[OperationId]            [varchar](10)			NOT NULL DEFAULT (''),
	[FechaHora_Inicio]       [datetime]				NULL  DEFAULT Getdate(),
	[FechaHora_Fin]          [datetime]				NULL,
	[posid]                  [varchar](100)			NOT NULL DEFAULT (''),
	[posuser]                [varchar](100)			NOT NULL DEFAULT (''),
	[Venta_Generada]         [bit]					NOT NULL DEFAULT (0),
	[Cancelado_Por_Usuario]  [bit]					NOT NULL DEFAULT (0),
	[Cancelado_Por_Tiempo]   [bit]					NOT NULL DEFAULT (0),
	[Tido]                   [varchar](3)			NOT NULL DEFAULT (''),
	[Nudo]                   [varchar](10)			NOT NULL DEFAULT (''),
	[Pagado_CashDro]         [bit]					NOT NULL DEFAULT (0),
	[Pagado_Transbank]       [bit]					NOT NULL DEFAULT (0),
	[Pagado_Nota_de_credito] [bit]					NOT NULL DEFAULT (0),
	[Pagado_Random]          [bit]					NOT NULL DEFAULT (0),
	[Idmaeedo]               [int]					NOT NULL DEFAULT (0),
	[Tipo_De_Pago]           [char](3)				NOT NULL DEFAULT (''),
	[Monto]                  [float]				NOT NULL DEFAULT (0),
	[Impreso]                [bit]					NOT NULL DEFAULT (0),
	[Log_Error]              [varchar](1000)		NOT NULL DEFAULT (''),
	[Status_Tarjeta]         [varchar](200)			NOT NULL DEFAULT (''),
	[Respuesta_Tarjeta]      [varchar](2000)		NOT NULL DEFAULT (''),
	[Idmaeedo_NCV]           [int]					NOT NULL DEFAULT (0),
	[Nudo_NCV]               [varchar](10)			NOT NULL DEFAULT (''),
	[Error_Extraccion_Respuesta_Transbank] [bit]	NOT NULL DEFAULT (0),
	[Idmaedpce]              [int]					NOT NULL DEFAULT (0),
	[Vuelto]                 [float]				NOT NULL DEFAULT (0),
	[Vuelto_Entregado]       [bit]					NOT NULL DEFAULT (0),
	[Modalidad]              [varchar](5)			NOT NULL DEFAULT (''),
	[Empresa]                [varchar](2)			NOT NULL DEFAULT (''),
	[Sucursal]               [varchar](3)			NOT NULL DEFAULT (''),
	[Bodega]                 [varchar](3)			NOT NULL DEFAULT (''),
	[Caja]                   [varchar](2)			NOT NULL DEFAULT (''),
	[Padre_OperationId]      [varchar](10)			NOT NULL DEFAULT (''),
	[Ajuste_Sencillo]        [float]				NOT NULL DEFAULT (0),
	[Valor_Asignado]         [float]				NOT NULL DEFAULT (0),
	[Padre_Id]               [int]					NOT NULL DEFAULT (0),
	[Idmaeedo_H]             [int]					NOT NULL DEFAULT (0),
	[Id_Log_Transbank]       [int]					NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_CashDro_Operaciones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

