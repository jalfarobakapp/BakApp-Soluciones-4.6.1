USE [#Base#]

CREATE TABLE [dbo].[Zw_CashDro_Transbank_Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha_Hora]                       [datetime]      NOT NULL DEFAULT (GetDate()),
	[Log_Datos_Ultima_Venta_Transbank] [varchar](2000) NOT NULL DEFAULT (''),
	[Idmaeedo_Referencia]              [int]           NOT NULL DEFAULT (0),
	[Monto_Venta_Referencia]           [float]         NOT NULL DEFAULT (0),
	[Voucher]                          [varchar](2000) NOT NULL DEFAULT (''),
	[Comando_Transbank]                [varchar](2000) NOT NULL DEFAULT (''),
	[Respuesta_Transbank]              [varchar](2000) NOT NULL DEFAULT (''),
	[Respuesta_Inicial]                [bit]           NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_CashDro_Transbank_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
