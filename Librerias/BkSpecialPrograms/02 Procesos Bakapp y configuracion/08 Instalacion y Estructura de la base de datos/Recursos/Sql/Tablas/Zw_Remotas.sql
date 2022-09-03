USE [#Base#]


CREATE TABLE [dbo].[Zw_Remotas](
	[Id_Rem]					[int] IDENTITY(1,1) NOT NULL,
	[Empresa]					[char](2)       NOT NULL DEFAULT (''),
	[NroRemota]					[char](10)      NOT NULL DEFAULT (''),
	[CodFuncionario_Solicita]	[char](3)       NOT NULL DEFAULT (''),
	[CodFuncionario_Autoriza]	[char](3)       NOT NULL DEFAULT (''),
	[CodPermiso]				[varchar](10)   NOT NULL DEFAULT (''),
	[Descripcion_Adicional]		[varchar](150)  NOT NULL DEFAULT (''),
	[Permiso_Otorgado]			[bit]           NOT NULL DEFAULT (0),
	[Otorga]					[varchar](50)   NOT NULL DEFAULT (''),
	[Id_Casi_DocEnc]			[int]           NOT NULL DEFAULT (0),
	[Fecha_Solicita]			[datetime]      NULL,
	[Fecha_Otorga]				[datetime]      NULL,
	[CodEntidad]				[varchar](13)   NOT NULL DEFAULT (''),
	[CodSucEntidad]				[varchar](10)   NOT NULL DEFAULT (''),
	[NomEntidad]				[varchar](100)  NOT NULL DEFAULT (''),
	[TotalBruto]				[float]         NOT NULL DEFAULT (0),
	[Espera_En_Linea]			[bit]           NOT NULL DEFAULT (0),
	[Eliminada]					[bit]           NOT NULL DEFAULT (0),
	[Observaciones]				[varchar](500)  NOT NULL DEFAULT (''),
	[Id_Notificacion]			[int]           NOT NULL DEFAULT (0),
	[Rev_Usuario_Solicita]		[bit]           NOT NULL DEFAULT (0),
	[Idmaeedo]					[int]           NOT NULL DEFAULT (0),
	[RCadena]					[bit]           NOT NULL DEFAULT (0),
	[RCadena_Id_Enc]			[int]           NOT NULL DEFAULT (0),
	[Padre_NroRemota]			[char](10)      NOT NULL DEFAULT (''),
	[Crear_Doc_Def_Al_Grabar]	[bit]           NOT NULL DEFAULT (0),
	[Nro_RCadena]				[char](10)      NOT NULL DEFAULT (''),
	[Permiso_Presencial]		[bit]           NOT NULL DEFAULT (0),
	[Monto_Aprobacion]			[float]         NOT NULL DEFAULT (0),
	[NombreEquipo_Auto]			[varchar](200)  NOT NULL DEFAULT (''),
    [Heredado]		            [bit]           NOT NULL DEFAULT (0),
    [Id_Rem_Heredado]			[int]           NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Remotas] PRIMARY KEY CLUSTERED 
(
	[NroRemota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
