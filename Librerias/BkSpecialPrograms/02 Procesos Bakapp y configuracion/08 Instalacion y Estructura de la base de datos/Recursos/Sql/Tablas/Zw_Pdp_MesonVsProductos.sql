USE [#Base#]


CREATE TABLE [dbo].[Zw_Pdp_MesonVsProductos](
	[IdMeson]               [int] IDENTITY(1,1) NOT NULL,
	[Codmeson]                   [char](13)      NOT NULL DEFAULT (''),
	[Orden_Meson]               [int]           NOT NULL DEFAULT (0),
	[Estado]                    [char](2)       NOT NULL DEFAULT (''),
	[Idpotpr]                   [int]           NOT NULL DEFAULT (0),
	[Idpotl]                    [int]           NOT NULL DEFAULT (0),
	[Idpote]                    [int]           NOT NULL DEFAULT (0),
	[Empresa]                   [char](2)       NOT NULL DEFAULT (''),
	[Numot]                     [char](10)      NOT NULL DEFAULT (''),
	[Orden_Potpr]               [int]           NOT NULL DEFAULT (0),
	[Operacion]                 [varchar](4)    NOT NULL DEFAULT (''),
	[Nombreop]                  [varchar](50)   NOT NULL DEFAULT (''),
	[Nreg]                      [char](5)       NOT NULL DEFAULT (''),
	[Desde]                     [char](2)       NOT NULL DEFAULT (''),
	[Nivel]                     [int]           NOT NULL DEFAULT (0),
	[Codigo]                    [char](13)      NOT NULL DEFAULT (''),
	[Glosa]                     [varchar](50)   NOT NULL DEFAULT (''),
	[Asignado_Por]              [char](8)       NOT NULL DEFAULT (''),
	[Fecha_Asignacion]          [datetime]      NOT NULL DEFAULT (Getdate()),
	[Fabricar_Recep]            [float]         NOT NULL DEFAULT (0),
	[Fabricado_Recep]           [float]         NOT NULL DEFAULT (0),
	[Saldo_Fabricar_Recep]      [float]         NOT NULL DEFAULT (0),
	[Porc_Fabricacion_Recep]    [float]         NOT NULL DEFAULT (0),
	[Fabricar_OT]               [float]         NOT NULL DEFAULT (0),
	[Fabricado_OT]              [float]         NOT NULL DEFAULT (0),
	[Saldo_Fabricar_OT]         [float]         NOT NULL DEFAULT (0),
	[Porc_Fabricacion]          [float]         NOT NULL DEFAULT (0),
	[Fabricar]                  [float]         NOT NULL DEFAULT (0),
	[Fabricado]                 [float]         NOT NULL DEFAULT (0),
	[Fabricando]                [float]         NOT NULL DEFAULT (0),
	[Saldo_Fabricar]            [float]         NOT NULL DEFAULT (0),
	[Porc_Avance_Saldo_Fab]     [float]         NOT NULL DEFAULT (0),
	[Cod_Funcionario_Asigna]    [char](3)       NOT NULL DEFAULT (''),
	[Prox_Meson]                [varchar](13)   NOT NULL DEFAULT (''),
	[Pertenece]                 [varchar](5)    NOT NULL DEFAULT (''),
	[Reproceso]                 [bit]           NOT NULL DEFAULT (0),
    [Cant_Reproceso]            [float]         NOT NULL DEFAULT (0),
    [IdMeson_Reproceso]         [Int]           NOT NULL DEFAULT (0),
	[Idpotl_Padre]              [int]           NOT NULL DEFAULT (0),
	[AsignadoAlPrincipio]       [int]           NOT NULL DEFAULT (0),
    [CodMesonManda]             [varchar](13)   NOT NULL DEFAULT (''),
    [IdPotpr_Ac1]                [int]           NOT NULL DEFAULT (0),
    [IdPotpr_Ac2]               [int]           NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Pdp_MesonVsProductos] PRIMARY KEY CLUSTERED 
(
	[IdMeson] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

