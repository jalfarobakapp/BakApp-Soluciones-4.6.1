USE [#Base#]

CREATE TABLE [dbo].[Zw_St_OT_Recetas_OpePre](
	[Id]		[int]			IDENTITY(1,1) NOT NULL,
	[Id_Rec]	[int]			NOT NULL DEFAULT (0),
	[Id_ReOpe]	[int]			NOT NULL DEFAULT (0),
	[Empresa]	[char](2)		NOT NULL DEFAULT (''),
	[Sucursal]	[varchar](3)	NOT NULL DEFAULT (''),
	[Precio]	[float]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_St_OT_Recetas_OpePre] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
