USE [#Base#]


CREATE TABLE [dbo].[Zw_Format_Fx](
	[Id]					[int] IDENTITY(1,1) NOT NULL,
	[Seccion]				[char](1)		NOT NULL DEFAULT (''),
	[Nombre_Funcion]		[varchar](100)	NOT NULL DEFAULT (''),
	[Funcion_Bk]			[bit]			NOT NULL DEFAULT (0),
	[Tipo_de_dato]			[char](1)		NOT NULL DEFAULT (''),
	[Formato]				[varchar](1000) NOT NULL DEFAULT (''),
	[Tabla]					[varchar](100)	NOT NULL DEFAULT (''),
	[Campo]					[varchar](100)	NOT NULL DEFAULT (''),
	[SqlQuery]				[varchar](1000) NOT NULL DEFAULT (''),
	[Borde_Variable]		[bit]			NOT NULL DEFAULT (0),
	[Orden_Detalle]			[int]			NOT NULL DEFAULT (0),
	[Codigo_De_Barras]		[bit]			NOT NULL DEFAULT (0),
	[Es_Descuento]			[bit]			NOT NULL DEFAULT (0),
	[Es_Porcentaje]			[bit]			NOT NULL DEFAULT (0),
	[Descripcion_Funcion]	[varchar](1000) NOT NULL DEFAULT (''),
	[Cheque]				[bit]			NOT NULL DEFAULT (0),
	[Sol_Bodega]			[bit]			NOT NULL DEFAULT (0),
	[SQL_Personalizada]		[bit]			NOT NULL DEFAULT (0),
    [CodigoQR]      		[bit]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Format_Fx] PRIMARY KEY CLUSTERED 
(
	[Seccion] ASC,
	[Nombre_Funcion] ASC,
	[Cheque] ASC,
	[Sol_Bodega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
