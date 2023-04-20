USE [#Base#]

CREATE TABLE [dbo].[Zw_St_OT_Recetas_Prod](
	[Id]			[int]			IDENTITY(1,1) NOT NULL,
	[Id_Rec]		[int]			NOT NULL DEFAULT (0),
	[CodReceta]		[varchar](20)	NOT NULL DEFAULT (''),
	[Codigo]		[varchar](13)	NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_St_OT_Recetas_Prod] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


