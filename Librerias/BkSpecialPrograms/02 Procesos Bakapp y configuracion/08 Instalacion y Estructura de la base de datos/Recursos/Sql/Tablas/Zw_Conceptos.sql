USE [#Base#]

CREATE TABLE [dbo].[Zw_Conceptos](
	[Koct]							[char](13)      NOT NULL DEFAULT (''),
	[ModFechVto]					[bit]           NOT NULL DEFAULT (0),
	[ModFechVto_Dias1erVenci]		[int]           NOT NULL DEFAULT (0),
	[NoPermitirMismoConceptoEnDoc]	[bit]           NOT NULL DEFAULT (0),
	[NoAfectaDsctoGlobal]	        [bit]           NOT NULL DEFAULT (0),
	[NoPermitirModificarValor]	    [bit]           NOT NULL DEFAULT (0),
    [Condicionado]                  [bit]           NOT NULL,
	[ClasUnicaBakapp_Condi]         [bit]           NOT NULL,
    [Campo_Condi]                   [varchar](30)   NOT NULL,
	[Cod_Condi]                     [varchar](30)   NOT NULL,
	[PorcCUd1D_Condi]               [float]         NOT NULL,
	[PorcCUd1H_Condi]               [float]         NOT NULL,
	[TotalOtros_Condi]              [bit]           NOT NULL,
	[TotalDocumento_Condi]          [bit]           NOT NULL,
 CONSTRAINT [PK_Zw_Conceptos] PRIMARY KEY CLUSTERED 
(
	[Koct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


