USE [#Base#]


CREATE TABLE [dbo].[Zw_Fincred_TramaRespuesta](
	[Id]							[int] IDENTITY(1,1) NOT NULL,
	[Token]							[varchar](50)		NOT NULL DEFAULT (''),
	[Producto]						[int]				NOT NULL DEFAULT (0),
	[Origen_transaccion]			[int]				NOT NULL DEFAULT (0),
	[Rut_girador]					[varchar](13)		NOT NULL DEFAULT (''),
	[Rut_comprador]					[varchar](13)		NOT NULL DEFAULT (''),
	[Numero_transaccion_cliente]	[int]				NOT NULL DEFAULT (0),
	[Numero_documento_transaccion]	[varchar](10)		NOT NULL DEFAULT (''),
	[Banco]							[int]				NOT NULL DEFAULT (0),
	[Monto_total_venta]				[float]				NOT NULL DEFAULT (0),
	[Cantidad_documentos_venta]		[int]				NOT NULL DEFAULT (0),
	[Estado_transaccion]			[int]				NOT NULL DEFAULT (0),
	[Codigo_negacion_transaccion]	[int]				NOT NULL DEFAULT (0),
	[Descripcion_negacion]			[varchar](80)		NOT NULL DEFAULT (''),
	[EnProceso]						[bit]				NOT NULL DEFAULT (0),
	[Idmaeedo]						[int]				NOT NULL DEFAULT (0),
	[Tido]							[varchar](3)		NOT NULL DEFAULT (''),
	[Nudo]							[varchar](10)		NOT NULL DEFAULT (''),
	[Json]							[varchar](max)		NOT NULL DEFAULT (''),
    [FechaCreacion]                 [datetime]          NULL DEFAULT (getdate()),
 CONSTRAINT [PK_Zw_Fincred_TramaRespuesta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


