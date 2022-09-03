USE [#Base#]

CREATE TABLE [dbo].[Zw_Usuarios_Impresion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CodFuncionario]            		[char](3)       NOT NULL DEFAULT (''),
	[Empresa]				            [char](2)       NOT NULL DEFAULT (''),
	[Modalidad]	            			[char](5)       NOT NULL DEFAULT (''),
	[Tido]				            	[char](3)       NOT NULL DEFAULT (''),
	[SubTido]			            	[char](3)       NOT NULL DEFAULT (''),
	[Tipo]				            	[varchar](20)   NOT NULL DEFAULT (''),
	[NombreEquipo_Imprime]          	[varchar](20)   NOT NULL DEFAULT (''),
	[NombreFormato]		            	[varchar](50)   NOT NULL DEFAULT (''),
	[Nro_Copias]	            		[int]           NOT NULL DEFAULT (1),
	[Activo]	            			[bit]           NOT NULL DEFAULT (1),
	[Impresora]			            	[varchar](50)   NOT NULL DEFAULT (''),
    [Imprimir_Voucher_TJV_No_Imprimir]	[bit]           NOT NULL DEFAULT (1),
    [Imprimir_Voucher_TJV]				[bit]           NOT NULL DEFAULT (0),
    [Imprimir_Voucher_TJV_Original]		[bit]           NOT NULL DEFAULT (0),
    [Imp_Todas_Modalidades]				[bit]           NOT NULL DEFAULT (1),
    [Sucursal_Picking]	            	[varchar](50)   NOT NULL DEFAULT (''),
    [Bodega_Picking]	            	[varchar](50)   NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Usuarios_Impresion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

