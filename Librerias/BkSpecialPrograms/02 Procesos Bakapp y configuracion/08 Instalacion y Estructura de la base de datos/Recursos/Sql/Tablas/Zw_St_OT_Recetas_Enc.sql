USE [#Base#]

CREATE TABLE [dbo].[Zw_St_OT_Recetas_Enc](
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[Empresa]		[char](2)		NOT NULL DEFAULT (''),
	[Sucursal]		[varchar](3)	NOT NULL DEFAULT (''),
	[CodReceta]		[varchar](20)	NOT NULL DEFAULT (''),
	[Descripcion]	[varchar](50)	NOT NULL DEFAULT (''),
	[Activo]		[bit]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_St_OT_Recetas_Enc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



