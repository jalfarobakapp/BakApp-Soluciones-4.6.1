USE [#Base#]


CREATE TABLE [dbo].[Zw_Negocios_02_Det](
	[Id_Detalle] [int] IDENTITY(1,1) NOT NULL,
	[Nro_Negocio] [varchar](10) NOT NULL DEFAULT (''),
	[Stand_By] [bit] NOT NULL DEFAULT (0),
	[Valor_UF] [float] NOT NULL DEFAULT (0),
	[Linea_Credito_SC_Ac_UF] [float] NOT NULL DEFAULT (0),
	[Linea_Credito_Int_Ac_Peso] [float] NOT NULL DEFAULT (0),
	[Linea_Credito_Int_Ac_UF] [float] NOT NULL DEFAULT (0),
	[Cod_Clas_Crediticia_Ac_Seg_Credito] [varchar](20) NOT NULL DEFAULT (''),
	[Clasif_Riesgo_comercial] [varchar](25) NOT NULL DEFAULT (''),
	[Morosidades_y_protestos] [varchar](25) NOT NULL DEFAULT (''),
	[Deuda_Actual] [float] NOT NULL DEFAULT (0),
	[Deuda_Actual_UF] [float] NOT NULL DEFAULT (0),
	[Fecha_Prox_Vencimiento] [datetime] NOT NULL DEFAULT (0),
	[Direcctorio_Archivos_Adjuntos] [varchar](800) NOT NULL DEFAULT (''),
	[Prorroga_Negociacion_Vigente] [float] NOT NULL DEFAULT (0),
	[Monto_Prox_Vencimiento] [float] NOT NULL DEFAULT (0),
	[Obs_Proximos_Vencimientos_CxC] [varchar](2000) NOT NULL DEFAULT (''),
	[Monto_Venta_Civa] [float] NOT NULL DEFAULT (0),
	[Monto_Venta_Civa_UF] [float] NOT NULL DEFAULT (0),
	[Plazo_Venta_Dias] [float] NOT NULL DEFAULT (0),
	[CodVendedor] [char](3) NOT NULL DEFAULT (''),
	[NomVendedor] [varchar](50) NOT NULL DEFAULT (''),
	[Producto] [varchar](100) NOT NULL DEFAULT (''),
	[Precio] [varchar](100) NOT NULL DEFAULT (''),
	[Rentabilidad] [varchar](100) NOT NULL DEFAULT (''),
	[Dias_libres] [int] NOT NULL DEFAULT (0),
	[Taza_de_interes] [varchar](25) NOT NULL DEFAULT (''),
	[Doc_Venta_SI] [bit] NOT NULL DEFAULT (0),
	[Cod_Doc_Venta_SI] [varchar](20) NOT NULL DEFAULT (''),
	[Doc_Venta_NO] [bit] NOT NULL DEFAULT (0),
	[Ficha_Int_Cli_Completa] [bit] NOT NULL DEFAULT (0),
	[Ficha_Int_Cli_Parcial] [bit] NOT NULL DEFAULT (0),
	[Ficha_Int_Cli_SinAntecedentes] [bit] NOT NULL DEFAULT (0),
	[Observaciones_Jefe] [varchar](1000) NOT NULL DEFAULT (''),
	[Observaciones] [varchar](1000) NOT NULL DEFAULT (''),
	[Cierre_CodAutoriza] [char](3) NOT NULL DEFAULT (''),
	[Cierre_NombreAutoriza] [varchar](50) NOT NULL DEFAULT (''),
	[Cierre_Observaciones] [varchar](500) NOT NULL DEFAULT (''),
	[Total_Neto_Aprobado_Uf] [float] NOT NULL DEFAULT (0),
	[Total_Neto_Aprobado_Pesos] [float] NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Negocios_02_Det] PRIMARY KEY CLUSTERED 
(
	[Id_Detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

