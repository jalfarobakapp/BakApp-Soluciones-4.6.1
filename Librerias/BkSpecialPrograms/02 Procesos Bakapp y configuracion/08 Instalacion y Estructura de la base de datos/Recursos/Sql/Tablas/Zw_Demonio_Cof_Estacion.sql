USE [#Base#]


CREATE TABLE [dbo].[Zw_Demonio_Cof_Estacion](
	[Id]										[int]			IDENTITY(1,1) NOT NULL,
	[NombreEquipo]								[varchar](50)	NOT NULL DEFAULT (''),
	[TipoDoc]									[char](3)		NOT NULL DEFAULT (''),
	[NombreDoc]									[varchar](100)	NOT NULL DEFAULT (''),
	[Traer_Doc_Auto_Imprimir]					[bit]			NOT NULL DEFAULT (0),
	[Imprimir]									[bit]			NOT NULL DEFAULT (0),
	[Nro_Copias_Impresion]						[int]			NOT NULL DEFAULT (0),
	[Traer_Doc_Auto_Correo]						[bit]			NOT NULL DEFAULT (0),
	[Correo]									[bit]			NOT NULL DEFAULT (0),
	[Nombre_Correo]								[varchar](50)	NOT NULL DEFAULT (''),
	[Imprimir_Barras]							[bit]			NOT NULL DEFAULT (0),
	[NombreFormato]								[varchar](50)	NOT NULL DEFAULT (''),
	[Prestashop]								[bit]			NOT NULL DEFAULT (0),
	[Tipo_Definitivo_Vale]						[char](1)		NOT NULL DEFAULT ('D'),
	[Es_Cashdro]								[bit]			NOT NULL DEFAULT (0),
	[Imprimir_Voucher_TJV]						[bit]			NOT NULL DEFAULT (0),
	[Imprimir_Voucher_TJV_Original_Transbak]	[bit]			NOT NULL DEFAULT (0),
	[Imprimir_Picking]							[bit]			NOT NULL DEFAULT (0),
	[Imp_Suc_Modal]								[bit]			NOT NULL DEFAULT (1),
 CONSTRAINT [PK_Zw_Demonio_Cof_Estacion] PRIMARY KEY CLUSTERED 
(
	[NombreEquipo] ASC,
	[TipoDoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


