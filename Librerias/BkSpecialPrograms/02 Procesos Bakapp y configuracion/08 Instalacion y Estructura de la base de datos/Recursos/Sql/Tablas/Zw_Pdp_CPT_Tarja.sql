USE [#Base#]

CREATE TABLE [dbo].[Zw_Pdp_CPT_Tarja](
	[Id]				    [int] IDENTITY(1,1) NOT NULL,
	[Empresa]			    [char](2)		NOT NULL Default(''),
	[Idmaeddo]			    [int]			NOT NULL Default(0),
	[Nro_CPT]			    [varchar](10)	NOT NULL Default(''),
	[Lote]				    [varchar](20)	NOT NULL Default(''),
	[Codigo]			    [varchar](13)	NOT NULL Default(''),
	[CodAlternativo]	    [varchar](21)	NOT NULL Default(''),
	[CodAlternativo_Pallet]	[varchar](21)	NOT NULL Default(''),
	[Turno]				    [varchar](1)	NOT NULL Default(''),
	[Planta]			    [varchar](1)	NOT NULL Default(''),
	[Udm]				    [varchar](2)	NOT NULL Default(''),
	[Formato]			    [float]			NOT NULL Default(0),
	[FechaElab]			    [datetime]		NULL,
	[SacosXPallet]		    [int]			NOT NULL Default(0),
	[Analista]			    [varchar](3)	NOT NULL Default(''),
	[Observaciones]		    [varchar](200)	NOT NULL Default(''),
	[Tipo]		            [varchar](10)	NOT NULL Default(''),
    [CantidadTipo]		    [float]			NOT NULL Default(0),
    [CantidadFab]		    [float]			NOT NULL Default(0),
    [Descripcion_Kopral]    [varchar](200)	NOT NULL Default(''),
    [Tolva]                 [varchar](2)	NOT NULL Default(''),
    [Idpote]                [int]			NOT NULL Default(0),
    [Idpotl]                [int]			NOT NULL Default(0),
    [BodegaDesde]           [varchar](10)	NOT NULL Default(''),
 CONSTRAINT [PK_Zw_Pdp_CPT_Tarja] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


