USE [#Base#]

CREATE TABLE [dbo].[Zw_Demonio_Doc_Emitidos_Cola_Impresion](
	[Id]				                [int] IDENTITY(1,1) NOT NULL,
	[NombreEquipo]		                [varchar](50)   NOT NULL DEFAULT (''),
	[Idmaeedo]			                [nchar](10)     NOT NULL DEFAULT (''),
	[Tido]				                [char](3)       NOT NULL DEFAULT (''),
	[Nudo]				                [varchar](10)   NOT NULL DEFAULT (''),
	[Funcionario]		                [char](3)       NOT NULL DEFAULT (''),
	[Revizado_Demonio]	                [bit]           NOT NULL DEFAULT (0),
	[Impreso]			                [bit]           NOT NULL DEFAULT (0),
	[Error_Al_Imprimir]                 [bit]           NOT NULL DEFAULT (0),
	[Fecha]				                [datetime]      NULL,
	[NombreFormato]		                [varchar](50)   NOT NULL DEFAULT (''),
	[Log_Error]			                [varchar](500)  NOT NULL DEFAULT (''),
	[Nudonodefi]		                [int]           NOT NULL DEFAULT (0),
	[Intentos]			                [int]           NOT NULL DEFAULT (0),
	[Picking]			                [bit]           NOT NULL DEFAULT (0),
	[Obs_01]			                [varchar](100)  NOT NULL DEFAULT (''),
    [Fecha_Hora]		                [datetime]      NOT NULL DEFAULT (GetDate()),
    [Insertado_Desde_Diablito]	        [bit]           NOT NULL DEFAULT (0),
    [Nro_Copias_Impresion]		        [int]           NOT NULL DEFAULT (0),
    [Impresora]         		        [varchar](50)   NOT NULL DEFAULT (''),
    [Imprimir_Voucher_TJV]		        [bit]           NOT NULL DEFAULT (0),
    [Imprimir_Voucher_TJV_Original]		[bit]           NOT NULL DEFAULT (0),
    [Vale_Transitorio]          		[bit]           NOT NULL DEFAULT (0),    
    [FirmarDTE]          		        [bit]           NOT NULL DEFAULT (0),
    [AmbienteCertificacion]          	[bit]           NOT NULL DEFAULT (0),
    [Id_Dte]          		            [int]           NOT NULL DEFAULT (0),
    [Log_Firma]          		        [varchar](500)  NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Demonio_Doc_Emitidos_Cola_Impresion] PRIMARY KEY CLUSTERED 
(
	[NombreEquipo] ASC,
	[Idmaeedo] ASC,
	[Nudonodefi] ASC,
	[Picking] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
