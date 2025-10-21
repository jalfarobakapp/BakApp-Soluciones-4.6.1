USE [#Base#]

CREATE TABLE [dbo].[Zw_Demonio_NVVAuto](
	[Id_Enc]			        [int]           IDENTITY(1,1) NOT NULL,
	[IdmaeedoOCC_Ori]	        [int]           NOT NULL DEFAULT (0),
	[NudoOCC_Ori]		        [varchar](20)   NOT NULL DEFAULT (''),
	[Endo_Ori]			        [varchar](13)   NOT NULL DEFAULT (''),
	[Suendo_Ori]		        [varchar](10)   NOT NULL DEFAULT (''),
	[FechaGrab]			        [datetime]      NULL,
	[GenerarNVV]		        [bit]           NOT NULL DEFAULT (0),
	[NVVGenerada]		        [bit]           NOT NULL DEFAULT (0),
	[Idmaeedo_NVV]		        [int]           NOT NULL DEFAULT (0),
	[Nudo_NVV]			        [varchar](10)   NOT NULL DEFAULT (''),
	[Feemdo_NVV]		        [datetime]      NULL,
	[Observaciones]		        [varchar](max)  NOT NULL DEFAULT (''),
    [TipoOri]			        [varchar](10)   NOT NULL DEFAULT (''),
    [Ocdo]                      [varchar](40)   NOT NULL DEFAULT (''),
    [Texto1]                    [varchar](80)   NOT NULL DEFAULT (''),
    [Texto2]                    [varchar](80)   NOT NULL DEFAULT (''),
    [Texto3]                    [varchar](80)   NOT NULL DEFAULT (''),
    [Texto4]                    [varchar](80)   NOT NULL DEFAULT (''),
    [Texto5]                    [varchar](80)   NOT NULL DEFAULT (''),
    [Texto6]                    [varchar](80)   NOT NULL DEFAULT (''),
    [Texto7]                    [varchar](80)   NOT NULL DEFAULT (''),
    [Texto8]                    [varchar](80)   NOT NULL DEFAULT (''),
    [Texto9]                    [varchar](80)   NOT NULL DEFAULT (''),
    [Texto10]                   [varchar](80)   NOT NULL DEFAULT (''),
    [Facturar]                  [bit]           NOT NULL DEFAULT (0),
    [DocEmitir]                 [varchar](3)    NOT NULL DEFAULT (''),
    [CodFuncionario_Factura]    [varchar](3)    NOT NULL DEFAULT (''),
    [EnvFacAutoBk]              [bit]           NOT NULL DEFAULT (0),
    [Modalidad_Fac]             [varchar](5)    NOT NULL DEFAULT (''),
    [Empresa]                   [char](2)       NOT NULL DEFAULT (''),
    [Feer_NVV]                  [datetime]      NULL,
 CONSTRAINT [PK_Zw_Demonio_NVVAuto] PRIMARY KEY CLUSTERED 
(
	[Id_Enc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]



