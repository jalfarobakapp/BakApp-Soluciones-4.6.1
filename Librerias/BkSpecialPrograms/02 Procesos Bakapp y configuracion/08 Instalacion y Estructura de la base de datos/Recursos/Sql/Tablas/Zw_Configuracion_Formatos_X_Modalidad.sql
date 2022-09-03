USE [#Base#]


CREATE TABLE [dbo].[Zw_Configuracion_Formatos_X_Modalidad](
    [Empresa]			            [varchar](2)	NOT NULL DEFAULT ('01'),
	[Modalidad]			            [varchar](5)	NOT NULL DEFAULT (''),
	[TipoDoc]			            [varchar](3)	NOT NULL DEFAULT (''),
	[NombreFormato]		            [varchar](50)	NOT NULL DEFAULT (''),
	[Grabar_Con_Huella]             [bit]			NOT NULL DEFAULT (0),
	[Sugiere_Despacho]	            [bit]			NOT NULL DEFAULT (0),
	[Obliga_Despacho]	            [bit]			NOT NULL DEFAULT (0),
    [NombreFormato_PDF] 	        [varchar](50)	NOT NULL DEFAULT (''),
    [Guardar_PDF_Auto]	            [bit]			NOT NULL DEFAULT (0),
    [Ruta_PDF]	                    [varchar](500)	        NOT NULL DEFAULT (''),
    [Obliga_Transportista]	        [bit]			NOT NULL DEFAULT (0),
    [Obliga_Despacho_BodDistintas]	[bit]			NOT NULL DEFAULT (0),
    [Enviar_Correo]	                [bit]			NOT NULL DEFAULT (0),
    [Id_Correo]	                    [int]			NOT NULL DEFAULT (0),
    [NombreFormato_Correo]          [varchar](50)   NOT NULL DEFAULT (''),
    [TimbrarXRandom]                [bit]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Configuracion_Formatos_X_Modalidad_1] PRIMARY KEY CLUSTERED 
(
	[Modalidad] ASC,
	[TipoDoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


