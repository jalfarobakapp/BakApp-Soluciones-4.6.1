USE [#Base#]


CREATE TABLE [dbo].[Zw_Prod_Imagenes](
	[Id]                [int] IDENTITY(1,1) NOT NULL,
	[Codigo]            [char](13)          NOT NULL DEFAULT (''),
	[Desde_URL]         [bit]               NOT NULL DEFAULT (0),
	[Direccion_Imagen]  [varchar](300)      NOT NULL DEFAULT (''),
	[Principal]         [bit] NOT NULL DEFAULT (0),
	[DesdeFtp]          [bit] NOT NULL DEFAULT (0),
	[Id_FTP]            [int] NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Prod_Imagenes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



