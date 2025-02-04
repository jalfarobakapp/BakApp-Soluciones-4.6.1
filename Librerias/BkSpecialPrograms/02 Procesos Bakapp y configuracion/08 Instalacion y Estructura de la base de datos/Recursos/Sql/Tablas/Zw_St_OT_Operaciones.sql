USE [#Base#]

CREATE TABLE [dbo].[Zw_St_OT_Operaciones](
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[Empresa]		[char](2)		    NOT NULL DEFAULT (''),
	[Sucursal]		[varchar](3)	    NOT NULL DEFAULT (''),
	[Operacion]		[varchar](8)	    NOT NULL DEFAULT (''),
	[Descripcion]	[varchar](50)	    NOT NULL DEFAULT (''),
	[Precio]		[float]			    NOT NULL DEFAULT (0),
	[CantMayor1]	[bit]			    NOT NULL DEFAULT (0),
	[Externa]		[bit]			    NOT NULL DEFAULT (0),
	[TienePrecio]	[bit]			    NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_St_OT_Operaciones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


