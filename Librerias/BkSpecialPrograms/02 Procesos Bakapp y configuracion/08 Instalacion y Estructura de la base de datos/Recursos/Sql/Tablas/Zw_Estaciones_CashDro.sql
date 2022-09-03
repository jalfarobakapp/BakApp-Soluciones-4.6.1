USE [#Base#]

CREATE TABLE [dbo].[Zw_Estaciones_CashDro](
	[NombreEquipo]					[nchar](50)		NOT NULL DEFAULT (''),
	[Funcionario]					[char](3)		NOT NULL DEFAULT (''),
	[Modalidad]						[varchar](5)	NOT NULL DEFAULT (''),
	[Ip_CashDro]					[varchar](20)	NOT NULL DEFAULT (''),
	[Usuario_CashDro]				[varchar](50)	NOT NULL DEFAULT (''),
	[Contrasena_CashDro]			[varchar](50)	NOT NULL DEFAULT (''),
	[EFV]							[bit]			NOT NULL DEFAULT (0),
	[TJV]							[bit]			NOT NULL DEFAULT (0),
	[NCV]							[bit]			NOT NULL DEFAULT (0),
	[Tiempo_Espera]					[int]			NOT NULL DEFAULT (0),
	[Fase_Prueba]					[bit]			NOT NULL DEFAULT (0),
	[Directorio_Demonio]			[varchar](1000) NOT NULL DEFAULT (''),
	[Abrir_Demonio]					[bit]			NOT NULL DEFAULT (0),
	[Tbk_Puerto]					[varchar](10)	NOT NULL DEFAULT (''),
	[Tbk_Tasa_de_baudios]			[varchar](10)	NOT NULL DEFAULT (''),
	[Tbk_Paridad]					[varchar](10)	NOT NULL DEFAULT (''),
	[Tbk_Bits_de_parada]			[varchar](10)	NOT NULL DEFAULT (''),
	[Tbk_Bits_de_datos]				[varchar](10)	NOT NULL DEFAULT (''),
	[Tbk_Hexadecimal]				[bit]			NOT NULL DEFAULT (0),
	[Tbk_Texto]						[bit]			NOT NULL DEFAULT (0),
	[Tbk_Post_Codigo_Comercio]		[varchar](30)	NOT NULL DEFAULT (''),
	[Tbk_Post_Terminal]				[varchar](30)	NOT NULL DEFAULT (''),
	[Tbk_Post_Version]				[varchar](20)	NOT NULL DEFAULT (''),
	[Impresora_Predeterminada]		[varchar](100)	NOT NULL DEFAULT (''),
	[Fase_Prueba_Tarjeta]			[bit]			NOT NULL DEFAULT (0),
	[Fase_Prueba_Nota_De_Credito]	[bit]			NOT NULL DEFAULT (0),
    [TJV_Emdp_Credito]				[varchar](13)	NOT NULL DEFAULT (''),
    [TJV_Emdp_Debito]				[varchar](13)	NOT NULL DEFAULT (''),
    [Post_Autoservicio]	    		[bit]			NOT NULL DEFAULT (0),
    [Post_Integrado]	    		[bit]			NOT NULL DEFAULT (0),
    [Usar_Post_Integrado]	   		[bit]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Estaciones_CashDro] PRIMARY KEY CLUSTERED 
(
	[NombreEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


