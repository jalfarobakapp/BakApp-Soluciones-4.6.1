USE [#Base#]


CREATE TABLE [dbo].[Zw_WMS_Ingreso_Enc](
	[Id_WMS] [int] IDENTITY(1,1) NOT NULL,
	[TipoDoc] [char](3) NOT NULL DEFAULT (''),
	[Nro_WMS] [varchar](10) NOT NULL DEFAULT (''),
	[Tipo_Ingreso] [varchar](max) NOT NULL DEFAULT (''),
	[Fecha_Hora_Ingreso] [datetime] NULL,
	[Funcionario] [char](3) NOT NULL DEFAULT (''),
	[Total_Items] [float] NOT NULL DEFAULT (0),
	[Total_CantUd1] [float] NOT NULL DEFAULT (0),
	[Total_CantUd2] [float] NOT NULL DEFAULT (0),
	[Nro_Referencia] [varchar](50) NOT NULL DEFAULT (''),
	[Nro_Pallet] [varchar](20) NOT NULL DEFAULT (''),
	[Nro_Lote] [varchar](20) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_WMS_Ingreso_Enc] PRIMARY KEY CLUSTERED 
(
	[Id_WMS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


