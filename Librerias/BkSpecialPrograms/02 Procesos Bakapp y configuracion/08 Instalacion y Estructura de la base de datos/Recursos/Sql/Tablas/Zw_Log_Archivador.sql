USE [#Base#]

CREATE TABLE [dbo].[Zw_Log_Archivador](
	[Idlog]         [int] IDENTITY(1,1) NOT NULL,
	[Fechalog]      [datetime]      NULL,
	[Mensajelog]    [text]          Not NULL Default(''),
	[Usuariolog]    [varchar](10)   Not NULL Default(''), 
 	[Oldidlog]      [int]           Not NULL Default(0),
	[Newidlog]      [int]           Not NULL Default(0),
	[Tablalog]      [varchar](30)   Not NULL Default(''),
 CONSTRAINT [PK_Zw_Log_Archivador] PRIMARY KEY CLUSTERED 
(
	[Idlog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]



