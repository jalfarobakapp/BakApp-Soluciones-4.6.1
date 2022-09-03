USE [#Base#]


CREATE TABLE [dbo].[Zw_Prod_SolBodega](
	[Id]                            [int] IDENTITY(1,1) NOT NULL,
	[CodSolicitud]                  [varchar](30)   NOT NULL DEFAULT (''),
	[Estado]                        [char](3)       NOT NULL DEFAULT (''),
	[Funcionario]                   [char](3)       NOT NULL DEFAULT (''),
	[Codigo]                        [char](13)      NOT NULL DEFAULT (''),
	[Descripcion]                   [varchar](50)   NOT NULL DEFAULT (''),
	[Empresa]                       [char](2)       NOT NULL DEFAULT (''),
	[Sucursal]                      [char](3)       NOT NULL DEFAULT (''),
	[Bodega]                        [char](3)       NOT NULL DEFAULT (''),
	[Ubicacion]                     [varchar](50)   NOT NULL DEFAULT (''),
	[FechaHora_Solicita]            [datetime]      NULL,
	[FechaHora_Entrega]             [datetime]      NULL,
	[FechaHora_Recibe]              [datetime]      NULL,
	[FechaHora_Cierre]              [datetime]      NULL,
	[FechaHora_Autoriza_pasar]      [datetime]      NULL,
	[Funcionario_Entrega]           [char](3)       NOT NULL DEFAULT (''),
	[Funcionario_Recibe]            [char](3)       NOT NULL DEFAULT (''),
	[Funcionario_Autoriza_cierre]   [char](3)       NOT NULL DEFAULT (''),
	[Funcionario_Autoriza_pasar]    [char](3)       NOT NULL DEFAULT (''),
	[Motivo_cierre]                 [varchar](100)  NOT NULL DEFAULT (''),
	[Impreso]                       [bit]           NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Prod_SolBodega] PRIMARY KEY CLUSTERED 
(
	[CodSolicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

