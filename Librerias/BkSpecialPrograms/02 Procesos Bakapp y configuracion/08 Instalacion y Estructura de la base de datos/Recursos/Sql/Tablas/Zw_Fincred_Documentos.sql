USE [#Base#]


CREATE TABLE [dbo].[Zw_Fincred_Documentos](
	[Id]					[int] IDENTITY(1,1) NOT NULL,
	[Id_TR]					[int]			NOT NULL DEFAULT (0),
	[Nro_documento]			[int]			NOT NULL DEFAULT (0),
	[Monto_documento]		[float]			NOT NULL DEFAULT (0),
	[Fecha_vencimiento]		[varchar](8)	NOT NULL DEFAULT (''),
	[Autorizacion]			[varchar](30)	NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Fincred_Documentos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



