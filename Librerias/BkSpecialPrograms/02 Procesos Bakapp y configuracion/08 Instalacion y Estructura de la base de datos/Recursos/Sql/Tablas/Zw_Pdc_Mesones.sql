USE [#Base#]


CREATE TABLE [dbo].[Zw_Pdc_Mesones](
	[Codmeson]                  [char](13)      NOT NULL DEFAULT (''),
	[Nommeson]                  [varchar](100)  NOT NULL DEFAULT (''),
	[Activo]                    [bit]           NOT NULL DEFAULT (1),
	[Virtual]                   [bit]           NOT NULL DEFAULT (0),
	[Orden_Meson]               [int]           NOT NULL DEFAULT (0),
	[Operacion]                 [char](4)       NOT NULL DEFAULT (''),
	[Operacion_Equivalente]     [char](4)       NOT NULL DEFAULT (''),
	[Codmaq]                    [char](13)      NOT NULL DEFAULT (''),
	[Permitir_Ing_DFA_Directo]  [bit]           NOT NULL DEFAULT (0),
    [Operacion_Reproceso]       [char](4)       NOT NULL DEFAULT (''),
    [Operacion_Serv_Tecnico]    [char](4)       NOT NULL DEFAULT (''),
    [Maestro]                   [bit]           NOT NULL DEFAULT (0),
    [Abierto]                   [bit]           NOT NULL DEFAULT (0),
    [NombreEquipo_Abierto]      [varchar](50)   NOT NULL DEFAULT (''),
    [Abierto_FechaHora]         [datetime]      NULL,
    [Codigoob_Abierto]          [char](8)       NOT NULL DEFAULT (''),
    [Solicita_Alerta]           [bit]           NOT NULL DEFAULT (0),
    [SolicitaConfOperaciones]   [bit]           NOT NULL DEFAULT (0),
    [ActivaAlPrincipio]         [bit]           NOT NULL DEFAULT (0),
    [ActivaConMesonMaestro]     [bit]           NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Pdc_Mesones] PRIMARY KEY CLUSTERED 
(
	[Codmeson] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


