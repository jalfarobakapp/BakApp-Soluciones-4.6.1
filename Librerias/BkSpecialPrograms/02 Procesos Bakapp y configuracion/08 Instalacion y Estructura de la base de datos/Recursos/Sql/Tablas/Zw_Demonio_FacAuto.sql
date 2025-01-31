USE [#Base#]

CREATE TABLE [dbo].[Zw_Demonio_FacAuto](
	[Id]				        [int] IDENTITY(1,1) NOT NULL,
	[NombreEquipo]		        [varchar](50)		NOT NULL DEFAULT (''),
	[Idmaeedo_NVV]		        [int]				NOT NULL DEFAULT (0),
	[Nudo_NVV]			        [varchar](10)		NOT NULL DEFAULT (''),
	[Modalidad_Fac]		        [varchar](5)		NOT NULL DEFAULT (''),
	[Fecha_Facturar]	        [datetime]			NULL,
	[Facturar]			        [bit]				NOT NULL DEFAULT (0),
	[Facturando]		        [bit]				NOT NULL DEFAULT (0),
	[Facturado]			        [bit]				NOT NULL DEFAULT (0),
	[Idmaeedo_FCV]		        [int]				NOT NULL DEFAULT (0),
	[Nudo_Fcv]			        [varchar](10)		NOT NULL DEFAULT (''),
	[Fecha_Facturado]	        [datetime]			NULL,
	[Informacion]		        [varchar](max)		NOT NULL DEFAULT (''),
	[ErrorGrabar]		        [bit]				NOT NULL DEFAULT (0),
	[DesdePickeo]		        [bit]				NOT NULL DEFAULT (0),
	[Id_Pickeo]		            [int]				NOT NULL DEFAULT (0),
	[DocEmitir]		            [varchar](3)		NOT NULL DEFAULT (''),
	[CerrarDespFact]	        [bit]				NOT NULL DEFAULT (0),
    [CodFuncionario_Factura]    [char](3)		    NOT NULL DEFAULT (0),
    [FechaHoraFacturado]        [datetime]			NULL,
    [DesdeNVVAuto]		        [bit]				NOT NULL DEFAULT (0),
    [CantItem]                  [int]				NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Demonio_FacAuto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]



