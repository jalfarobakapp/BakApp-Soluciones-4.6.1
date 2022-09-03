USE [#Base#]


CREATE TABLE [dbo].[Zw_Docu_Archivos](
	[Id]				[int] IDENTITY(1,1) Not Null,
	[Idmaeedo]			[int]			Not Null DEFAULT (0),
	[Nombre_Archivo]	[varchar](200)	Not Null DEFAULT (''),
	[Archivo]			[image]			Null,
	[Fecha]				[datetime]		Not Null DEFAULT (''),
	[CodFuncionario]	[char](3)			Not Null DEFAULT (''),
 CONSTRAINT [PK_Zw_Docu_Archivos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

