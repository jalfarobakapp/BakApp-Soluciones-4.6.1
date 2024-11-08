USE [#Base#]

CREATE TABLE [dbo].[Zw_Demonio_NVVAutoDet](
	[Id_Det]		        [int] 			IDENTITY(1,1) NOT NULL,
	[Id_Enc]		        [int]			NOT NULL DEFAULT (0),
	[Idmaeddo_Ori]	        [int]			NOT NULL DEFAULT (0),
	[Codigo]		        [varchar](13)	NOT NULL DEFAULT (''),
	[Cantidad]		        [float]			NOT NULL DEFAULT (0),
	[Untrans]		        [int]			NOT NULL DEFAULT (0),
	[Descripcion]	        [varchar](50)	NOT NULL DEFAULT (''),
	[Empresa]	            [varchar](2)	NOT NULL DEFAULT (''),
	[Sucursal]	            [varchar](3)	NOT NULL DEFAULT (''),
	[Bodega]	            [varchar](3)	NOT NULL DEFAULT (''),
    [Stfi1]		            [float]			NOT NULL DEFAULT (0),
    [Stfi2]		            [float]			NOT NULL DEFAULT (0),
    [CantidadDefinitiva]	[float]			NOT NULL DEFAULT (0),
    [Stocnv1]	            [float]			NOT NULL DEFAULT (0),
    [Stocnv2]	            [float]			NOT NULL DEFAULT (0),
    [StComp1]	            [float]			NOT NULL DEFAULT (0),
    [StComp2]	            [float]			NOT NULL DEFAULT (0),
    [Stdv1] 	            [float]			NOT NULL DEFAULT (0),
    [Stdv2]	                [float]			NOT NULL DEFAULT (0),
    [Precio]                [float]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Demonio_NVVAutoDet] PRIMARY KEY CLUSTERED 
(
	[Id_Det] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



