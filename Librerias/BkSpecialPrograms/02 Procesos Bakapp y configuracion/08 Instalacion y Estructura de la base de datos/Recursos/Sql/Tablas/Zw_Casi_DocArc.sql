USE [#Base#]


CREATE TABLE [dbo].[Zw_Casi_DocArc](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[Id_DocEnc]			[varchar](10)		NOT NULL DEFAULT (''),
	[Nombre_Archivo]	[varchar](200)		NOT NULL DEFAULT (''),
	[Archivo]			[image]				NULL,
	[Fecha]				[datetime]			NOT NULL DEFAULT (Getdate()),
	[CodFuncionario]	[char](3)			NOT NULL DEFAULT (''),
	[En_Construccion]	[bit]				NOT NULL DEFAULT (0),
	[NombreEquipo]		[varchar](20)		NOT NULL DEFAULT (''),
    [Idmaeedo]	        [int]				NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Casi_DocArc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
