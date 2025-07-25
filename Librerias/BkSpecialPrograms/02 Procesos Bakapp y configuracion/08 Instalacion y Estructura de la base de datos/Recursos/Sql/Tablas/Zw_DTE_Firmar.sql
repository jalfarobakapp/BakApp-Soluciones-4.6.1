USE [#Base#]

CREATE TABLE [dbo].[Zw_DTE_Firmar](
	[Id]		            [int]			IDENTITY(1,1) NOT NULL,
	[Idmaeedo]	            [int]			NOT NULL Default(0),
	[Tido]		            [varchar](3)	NOT NULL Default(''),
	[Nudo]		            [varchar](10)	NOT NULL Default(''),
	[Firmar]	            [bit]			NOT NULL Default(0),
	[Id_Dte]	            [int]			NOT NULL Default(0),
	[Log_Error]             [varchar](max)  NOT NULL Default(''),
    [AmbienteCertificacion]	[bit]           NOT NULL DEFAULT (0),   
    [FechaEnvio]        	[datetime]		NULL,
    [Empresa]               [char](3)		NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_DTE_Firmar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]



