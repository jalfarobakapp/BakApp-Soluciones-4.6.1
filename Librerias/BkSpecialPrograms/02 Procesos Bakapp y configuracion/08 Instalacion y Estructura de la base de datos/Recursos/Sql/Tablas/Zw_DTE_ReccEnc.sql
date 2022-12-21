USE [#Base#]

CREATE TABLE [dbo].[Zw_DTE_ReccEnc](
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[RutEmisor]		[varchar](20)		NOT NULL DEFAULT (''),
	[Glosa]			[varchar](100)		NOT NULL DEFAULT (''),
	[NombreArchivo] [varchar](100)		NOT NULL DEFAULT (''),
	[FechaRecep]	[datetime]			NULL,
	[Xml]			[varchar](max)		NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_DTE_ReccEnc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


