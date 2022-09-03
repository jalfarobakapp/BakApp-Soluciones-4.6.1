USE [#Base#]


CREATE TABLE [dbo].[Zw_Pdp_MaquinaVsProductos](
	[IdMaquina]             [int] IDENTITY(1,1) NOT NULL,
	[IdMeson]               [int]           NOT NULL DEFAULT (0),
	[Estado]                [varchar](3)    NULL,
	[Idpotpr]               [int]           NOT NULL DEFAULT (0),
	[Idpotl]                [int]           NOT NULL DEFAULT (0),
	[Idpote]                [int]           NOT NULL DEFAULT (0),
	[Numot]                 [varchar](10)   NOT NULL DEFAULT (''),
	[Codmeson]              [char](13)      NOT NULL DEFAULT (''),
	[Operacion]             [char](4)       NOT NULL DEFAULT (''),
	[CodMaq]                [char](13)      NOT NULL DEFAULT (''),
	[Obrero]                [char](8)       NOT NULL DEFAULT (''),
	[Codigo]                [char](13)      NOT NULL DEFAULT (''),
	[Descripcion]           [varchar](50)   NOT NULL DEFAULT (''),
	[Fecha_Hora_Inicio]     [datetime]      NOT NULL DEFAULT (getdate()),
	[Fecha_Hora_Termino]    [datetime]      NULL,
	[Fabricar]              [float]         NOT NULL DEFAULT (0),
	[Fabricado]             [float]         NOT NULL DEFAULT (0),
	[Porc_Fabricacion]      [float]         NOT NULL DEFAULT (0),
	[Porc_Avance_Saldo_Fab] [float]         NOT NULL DEFAULT (0),
	[Idpdatfae]             [int]           NOT NULL DEFAULT (0),
	[Kocaudet]              [char](10)      NOT NULL DEFAULT (''),
	[Observacion]           [varchar](500)  NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Pdp_MaquinaVsProductos] PRIMARY KEY CLUSTERED 
(
	[IdMaquina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

