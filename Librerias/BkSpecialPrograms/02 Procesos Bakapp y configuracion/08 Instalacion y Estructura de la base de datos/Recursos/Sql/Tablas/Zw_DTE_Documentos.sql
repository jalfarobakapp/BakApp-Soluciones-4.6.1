USE [#Base#]

CREATE TABLE [dbo].[Zw_DTE_Documentos](
	[Id_Dte] [int] IDENTITY(1,1) NOT NULL,
	[Idmaeedo]			    [int]			NOT NULL DEFAULT (0),
	[Tido]				    [char](3)		NOT NULL DEFAULT (''),
	[Nudo]				    [varchar](10)	NOT NULL DEFAULT (''),
	[Trackid]			    [varchar](20)	NOT NULL DEFAULT (''),
	[FechaSolicitud]	    [datetime]		NULL,
	[Xml]				    [varchar](max)	NOT NULL DEFAULT (''),
	[Firma]				    [varchar](2000) NOT NULL DEFAULT (''),
	[CaratulaXml]		    [varchar](max)	NOT NULL DEFAULT (''),
	[Respuesta]			    [varchar](1000) NOT NULL DEFAULT (''),
    [AmbienteCertificacion]	[bit]           NOT NULL DEFAULT (0),   
    [Procesar]          	[bit]           NOT NULL DEFAULT (0),   
    [Procesado]	            [bit]           NOT NULL DEFAULT (0),   
    [ErrorEnvioDTE]	        [bit]           NOT NULL DEFAULT (0),       
    [Eliminado]	            [bit]           NOT NULL DEFAULT (0), 
    [CaratulaXmlEmail]	    [varchar](max)	NOT NULL DEFAULT (''),
    [Empresa]               [char](2)		NOT NULL DEFAULT (''),
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
