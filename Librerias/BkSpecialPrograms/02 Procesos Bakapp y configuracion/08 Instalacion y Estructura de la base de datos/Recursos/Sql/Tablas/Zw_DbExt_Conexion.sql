USE [#Base#]

CREATE TABLE [dbo].[Zw_DbExt_Conexion](
	[Id]				    [int]           IDENTITY(1,1) NOT NULL,
	[Nombre_Conexion]   	[varchar](100)	NOT NULL DEFAULT (''),
	[Servidor]			    [varchar](50)	NOT NULL DEFAULT (''),
	[Puerto]			    [varchar](8)	NOT NULL DEFAULT (''),
	[Usuario]			    [varchar](50)	NOT NULL DEFAULT (''),
	[Clave]				    [varchar](50)	NOT NULL DEFAULT (''),
	[BaseDeDatos]		    [varchar](50)	NOT NULL DEFAULT (''),
	[Empresa]   		    [char](2)   	NOT NULL DEFAULT (''),
	[GrbProd_Nuevos]        [bit]      	    NOT NULL DEFAULT (0),
	[GrbEnti_Nuevas]        [bit]      	    NOT NULL DEFAULT (0),
    [GrbProd_Bodegas]	    [varchar](200)	NOT NULL DEFAULT (''),
    [GrbProd_Listas]	    [varchar](200)	NOT NULL DEFAULT (''),
    [GrbOCC_Nuevas]         [bit]      	    NOT NULL DEFAULT (0),    
    [SincroProductos]       [bit]      	    NOT NULL DEFAULT (0),    
    [SincroMarcas]          [bit]      	    NOT NULL DEFAULT (0),    
    [SincroFamilias]        [bit]      	    NOT NULL DEFAULT (0),    
    [SincroRubros]          [bit]      	    NOT NULL DEFAULT (0),    
    [SincroClaslibre]       [bit]      	    NOT NULL DEFAULT (0),    
    [SincroZonaProducto]    [bit]      	    NOT NULL DEFAULT (0),    
    [SincroZonas]           [bit]      	    NOT NULL DEFAULT (0),    
 CONSTRAINT [PK_Zw_DbExt_Conexion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
