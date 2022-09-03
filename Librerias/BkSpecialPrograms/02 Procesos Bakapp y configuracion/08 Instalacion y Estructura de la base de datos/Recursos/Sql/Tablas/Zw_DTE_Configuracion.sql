USE [#Base#]

CREATE TABLE [dbo].[Zw_DTE_Configuracion](
	[Id] [int] IDENTITY(1,1)	NOT NULL,
	[Empresa]	            [char](2)		NOT NULL DEFAULT (''),
	[Campo]		            [varchar](50)	NOT NULL DEFAULT (''),
	[Valor]		            [varchar](200)	NOT NULL DEFAULT (''),
	[FechaMod]	            [datetime]		NULL,
	[TipoCampo]             [varchar](20)	NOT NULL DEFAULT (''),
	[TipoConfiguracion]     [varchar](50)	NOT NULL DEFAULT (''),
    [AmbienteCertificacion]	[bit]           NOT NULL DEFAULT (0),   
 CONSTRAINT [PK_Zw_DTE_Configuracion] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[Campo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
