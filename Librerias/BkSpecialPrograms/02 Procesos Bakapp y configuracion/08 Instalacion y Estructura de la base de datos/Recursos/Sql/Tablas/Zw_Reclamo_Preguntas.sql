USE [#Base#]


CREATE TABLE [dbo].[Zw_Reclamo_Preguntas](
	[Id_Reclamo] [int] NOT NULL  DEFAULT (0),
	[Tipo_Reclamo] [varchar](3) NOT NULL  DEFAULT (''),
	[Cod_Pregunta] [varchar](3) NOT NULL  DEFAULT (''),
	[Respuesta] [varchar](300) NOT NULL  DEFAULT (''),
 CONSTRAINT [PK_Zw_Reclamo_Preguntas] PRIMARY KEY CLUSTERED 
(
	[Id_Reclamo] ASC,
	[Tipo_Reclamo] ASC,
	[Cod_Pregunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

