USE [#Base#]

CREATE TABLE [dbo].[Zw_Ftp_Conexiones](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[Tipo]				[varchar](10)		NOT NULL,
	[Usuario]			[varchar](50)		NOT NULL,
	[Clave]				[varchar](50)		NOT NULL,
	[Host]				[varchar](50)		NOT NULL,
	[Puerto]			[varchar](10)		NOT NULL,
	[Fichero]			[varchar](50)		NOT NULL,
	[Carpeta_Imagenes]	[varchar](200)		NOT NULL,
	[Carpeta_Archivos]	[varchar](200)		NOT NULL,
	[Url_public]		[varchar](100)		NOT NULL,
	[Timeout]			[int]				NOT NULL,
	[UsePassive]		[bit]				NOT NULL,
 CONSTRAINT [PK_Zw_Ftp_Conexiones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



