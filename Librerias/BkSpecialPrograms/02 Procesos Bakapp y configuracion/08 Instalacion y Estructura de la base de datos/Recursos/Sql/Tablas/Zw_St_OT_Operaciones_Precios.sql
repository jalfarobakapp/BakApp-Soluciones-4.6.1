USE [#Base#]

CREATE TABLE [dbo].[Zw_St_OT_Operaciones_Precios](
	[Id_Ope]	[int]           NOT NULL DEFAULT (0),
	[Empresa]	[varchar](2)    NOT NULL DEFAULT (''),
	[Sucursal]	[varchar](3)    NOT NULL DEFAULT (''),
	[Costo]		[float]         NOT NULL DEFAULT (0),
	[Precio]	[float]         NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_St_OT_Operaciones_Precios] PRIMARY KEY CLUSTERED 
(
	[Id_Ope] ASC,
	[Empresa] ASC,
	[Sucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]



