USE [#Base#]


CREATE TABLE [dbo].[Zw_WMS_Ubicaciones_Mapa_Det](
	[Id_Mapa]           [int]               NOT NULL DEFAULT (0),
	[Id]                [int] IDENTITY(1,1) NOT NULL,
	[Empresa]           [char](2)           NOT NULL DEFAULT (''),
	[Sucursal]          [char](3)           NOT NULL DEFAULT (''),
	[Bodega]            [char](3)           NOT NULL DEFAULT (''),
	[Codigo_Sector]     [varchar](20)       NOT NULL DEFAULT (''),
	[Nombre_Sector]     [varchar](50)       NOT NULL DEFAULT (''),
	[Tipo_Objeto]       [varchar](50)       NOT NULL DEFAULT (''),
	[Nombre_Objeto]     [varchar](50)       NOT NULL DEFAULT (''),
	[Texto]             [varchar](200)      NOT NULL DEFAULT (''),
	[Font_Nombre]       [varchar](50)       NOT NULL DEFAULT (''),
	[Font_Tamano]       [float]             NOT NULL DEFAULT (0),
	[Font_Estilo]       [int]               NOT NULL DEFAULT (0),
	[Font_Negrita]      [bit]               NOT NULL DEFAULT (0),
	[Font_Italic]       [bit]               NOT NULL DEFAULT (0),
	[Font_Tachado]      [bit]               NOT NULL DEFAULT (0),
	[Font_Subrayado]    [bit]               NOT NULL DEFAULT (0),
	[Alto_H]            [float]             NOT NULL DEFAULT (0),
	[Ancho_W]           [float]             NOT NULL DEFAULT (0),
	[BackColor]         [float]             NOT NULL DEFAULT (0),
	[ForeColor]         [float]             NOT NULL DEFAULT (0),
	[Relleno]           [float]             NOT NULL DEFAULT (0),
	[Y_Fila]            [float]             NOT NULL DEFAULT (0),
	[X_Columna]         [float]             NOT NULL DEFAULT (0),
	[Orientacion]       [int]               NOT NULL DEFAULT (0),
	[Habilitado]        [bit]               NOT NULL DEFAULT (1),
	[EsCabecera]		[bit]				NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_WMS_Ubicaciones_Mapa_Det] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

