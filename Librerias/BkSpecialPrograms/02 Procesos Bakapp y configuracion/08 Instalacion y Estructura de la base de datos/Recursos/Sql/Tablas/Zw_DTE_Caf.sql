USE [#Base#]

CREATE TABLE [dbo].[Zw_DTE_Caf](
	[Empresa]	            [char](2)		NOT NULL DEFAULT (''),
	[Tido]		            [char](3)		NOT NULL DEFAULT (''),
	[RE]		            [varchar](10)	NOT NULL DEFAULT (''),
	[RS]		            [varchar](50)	NOT NULL DEFAULT (''),
	[TD]		            [int]			NOT NULL DEFAULT (0),
	[RNG_D]		            [int]			NOT NULL DEFAULT (0),
	[RNG_H]		            [int]			NOT NULL DEFAULT (0),
	[FA]		            [datetime]		NULL,
	[RSAPK_M]	            [varchar](500)	NULL DEFAULT (''),
	[RSAPK_E]	            [varchar](50)	NULL DEFAULT (''),
	[IDK]		            [varchar](50)	NOT NULL DEFAULT (''),
	[FRMA]		            [varchar](500)	NOT NULL DEFAULT (''),
	[RSASK]		            [varchar](500)	NULL DEFAULT (''),
	[RSAPUBK]	            [varchar](500)	NULL DEFAULT (''),
	[CAF]		            [varchar](2000) NOT NULL DEFAULT (''),
    [AmbienteCertificacion]	[bit]           NOT NULL DEFAULT (0),   
) ON [PRIMARY]



