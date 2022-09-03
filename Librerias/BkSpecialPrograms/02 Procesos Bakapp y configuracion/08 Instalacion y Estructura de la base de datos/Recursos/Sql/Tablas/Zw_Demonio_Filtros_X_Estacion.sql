USE [#Base#]


CREATE TABLE [dbo].[Zw_Demonio_Filtros_X_Estacion](
	[IdPadre]                   [int]               NOT NULL DEFAULT (0),
	[Id]					    [int] IDENTITY(1,1) NOT NULL,
	[NombreEquipo]			    [varchar](50)       NOT NULL DEFAULT (''),
	[TipoDoc]				    [char](3)           NOT NULL DEFAULT (''),
	[Codigo]				    [varchar](50)       NOT NULL DEFAULT (''),
	[Nombre_Funcionario]	    [varchar](50)       NOT NULL DEFAULT (''),
	[Impresora]				    [varchar](300)      NOT NULL DEFAULT (''),
	[NombreFormato]			    [varchar](50)       NOT NULL DEFAULT (''),
	[Nro_Copias_Impresion]	    [int]               NOT NULL DEFAULT (0),
	[Nombre_Correo]			    [varchar](50)       NOT NULL DEFAULT (''),
	[Correo_Para]			    [varchar](200)      NOT NULL DEFAULT (''),
	[Correo_CC]				    [varchar](500)      NOT NULL DEFAULT (''),
	[Correo_Body]			    [varchar](8000)     NOT NULL DEFAULT (''),
	[Picking]				    [bit]               NOT NULL DEFAULT (0),
	[NombreFormato_Correo]	    [varchar](50)       NOT NULL DEFAULT (''),
	[Para_Maeenmail]		    [bit]               NOT NULL DEFAULT (0),
	[Usar_CtaSMTP_Funcionario]	[bit]               NOT NULL DEFAULT (0),
	[Vale_Transitorio]	        [bit]               NOT NULL DEFAULT (0),
CONSTRAINT [PK_Zw_Demonio_Filtros_X_Estacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[NombreEquipo] ASC,
	[TipoDoc] ASC,
	[Codigo] ASC,
	[Picking] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
