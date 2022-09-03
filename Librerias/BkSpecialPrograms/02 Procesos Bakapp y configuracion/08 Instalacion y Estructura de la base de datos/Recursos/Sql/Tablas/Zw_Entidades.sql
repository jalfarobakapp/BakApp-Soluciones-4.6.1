USE [#Base#]

CREATE TABLE [dbo].[Zw_Entidades](
	[CodEntidad]		            [varchar](13) NOT NULL DEFAULT(''),
	[CodSucEntidad]		            [varchar](20) NOT NULL DEFAULT(''),
	[Libera_NVV]		            [bit] NOT NULL DEFAULT(0),
	[AG_AgenciaxDefDespachos]	    [bit] NOT NULL DEFAULT(0),
	[AG_Transportista]		        [varchar](13) NOT NULL DEFAULT(''),
	[AG_Nombre_Contacto]		    [varchar](50) NOT NULL DEFAULT(''),
    [RT_Transportista]		        [varchar](13) NOT NULL DEFAULT(''),
    [EntregaPaletizada]	            [bit] NOT NULL DEFAULT(0),    
    [Metodo_Abastecer_Dias_Meses]	[int] NOT NULL DEFAULT(0),    
    [Dias_a_Abastecer]	            [int] NOT NULL DEFAULT(0),    
    [Tiempo_Reposicion_Dias_Meses]  [int] NOT NULL DEFAULT(0),    
    [Tiempo_Reposicion]	            [int] NOT NULL DEFAULT(0),    
 CONSTRAINT [PK_Zw_Entidades] PRIMARY KEY CLUSTERED 
(
	[CodEntidad] ASC,
	[CodSucEntidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


