USE [#Base#]

CREATE TABLE [dbo].[Zw_WMS_Picking_Log](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[Id_Enc]			[int]			NULL DEFAULT (0),
	[Idmaeedo]			[int]			NULL DEFAULT (0),
	[Idmaeddo]			[int]			NULL DEFAULT (0),
	[SKU]				[varchar](50)	NULL DEFAULT (''),
	[Tag]				[varchar](50)	NULL DEFAULT (''),
	[Accion]			[varchar](200)	NULL DEFAULT (''),
	[Fecha_Accion]		[datetime]		NULL,
	[Observaciones]		[varchar](500)	NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_WMS_Picking_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

