USE [#Base#]


CREATE TABLE [dbo].[Zw_Reclamo_Archivos](
	[Id_Archivos] [int] IDENTITY(1,1) NOT NULL,
	[Id_Reclamo] [int] NOT NULL  DEFAULT (0),
	[Estado] [char](3) NOT NULL  DEFAULT (''),
	[Sub_Estado] [char](3) NOT NULL  DEFAULT (''),
	[Nombre_Archivo] [varchar](200) NOT NULL  DEFAULT (''),
	[Archivo] [image] NULL,
 CONSTRAINT [PK_Zw_Reclamo_Archivos] PRIMARY KEY CLUSTERED 
(
	[Id_Archivos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]



