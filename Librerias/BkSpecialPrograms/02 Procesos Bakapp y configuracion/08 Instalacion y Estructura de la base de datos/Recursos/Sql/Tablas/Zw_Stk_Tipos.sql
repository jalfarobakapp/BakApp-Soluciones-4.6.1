USE [#Base#]


CREATE TABLE [dbo].[Zw_Stk_Tipos](
	[Id]				        [int] IDENTITY(1,1) NOT NULL,
	[Id_Area]			        [int]			NOT NULL DEFAULT (0),
	[Tipo]				        [varchar](50)	NOT NULL DEFAULT (''),
	[ExigeProducto]		        [bit]			NOT NULL DEFAULT (0),
	[Asignado]			        [bit]			NOT NULL DEFAULT (0),
	[AsignadoGrupo]		        [bit]			NOT NULL DEFAULT (0),
	[AsignadoAgente]	        [bit]			NOT NULL DEFAULT (0),
	[Id_Grupo]			        [int]			NOT NULL DEFAULT (0),
	[CodAgente]			        [varchar](3)	NOT NULL DEFAULT (''),
    [CieTk_Id_Area]             [int]           NOT NULL DEFAULT (0),
	[CieTk_Id_Tipo]             [int]           NOT NULL DEFAULT (0),
	[Inc_Cantidades]            [bit]           NOT NULL DEFAULT (0),
	[Inc_Fecha]                 [bit]           NOT NULL DEFAULT (0),
	[Inc_Hora]                  [bit]           NOT NULL DEFAULT (0),
	[RevInventario]             [bit]           NOT NULL DEFAULT (0),
	[AjusInventario]            [bit]           NOT NULL DEFAULT (0),
	[SobreStock]                [bit]           NOT NULL DEFAULT (0),
	[BodModalXDefecto]          [bit]           NOT NULL DEFAULT (0),
	[PreguntaCreaNewTicket]     [bit]           NOT NULL DEFAULT (0),
	[CerrarAgenteSinPerm]       [bit]           NOT NULL DEFAULT (0),
	[RespuestaXDefecto]         [varchar](200)  NOT NULL DEFAULT (''),
	[RespuestaXDefectoCerrar]   [varchar](200)  NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Stk_Tipos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

