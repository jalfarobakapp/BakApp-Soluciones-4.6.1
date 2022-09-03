USE [#Base#]


CREATE TABLE [dbo].[Zw_St_OT_Notas](
	[Id_Ot] [int] NOT NULL DEFAULT (0),
	[Defecto_segun_cliente] [varchar](2000) NOT NULL DEFAULT (''),
	[Reparacion_a_realizar] [varchar](2000) NOT NULL DEFAULT (''),
	[Defecto_encontrado] [varchar](2000) NOT NULL DEFAULT (''),
	[Reparacion_Realizada] [varchar](2000) NOT NULL DEFAULT (''),
	[Chk_no_se_pudo_reparar] [bit] NOT NULL DEFAULT (0),
	[Motivo_no_reparo] [varchar](1000) NOT NULL DEFAULT (''),
	[Nota_Etapa_01] [varchar](200) NOT NULL DEFAULT (''),
	[Nota_Etapa_02] [varchar](200) NOT NULL DEFAULT (''),
	[Nota_Etapa_03] [varchar](200) NOT NULL DEFAULT (''),
	[Nota_Etapa_04] [varchar](200) NOT NULL DEFAULT (''),
	[Nota_Etapa_05] [varchar](200) NOT NULL DEFAULT (''),
	[Nota_Etapa_06] [varchar](1000) NOT NULL DEFAULT (''),
	[Nota_Etapa_07] [varchar](200) NOT NULL DEFAULT (''),
	[Nota_Etapa_08] [varchar](200) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_St_OT_Notas] PRIMARY KEY CLUSTERED 
(
	[Id_Ot] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]