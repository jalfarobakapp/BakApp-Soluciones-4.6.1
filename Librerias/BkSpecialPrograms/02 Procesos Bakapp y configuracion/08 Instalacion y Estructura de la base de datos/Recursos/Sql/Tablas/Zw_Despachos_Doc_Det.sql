USE [#Base#]

CREATE TABLE [dbo].[Zw_Despachos_Doc_Det](
	[Id_Detalle]			[int] IDENTITY(1,1) Not Null,
	[Id_Documentos]			[int]			Not Null DEFAULT (0),
	[Id_Despacho]			[int]			Not Null DEFAULT (0),
	[Nro_Despacho]			[varchar](10)	Not Null Default (''),
	[Empresa]				[char](2)		Not Null DEFAULT (''),
	[Sucursal]				[varchar](3)	Not Null DEFAULT (''),
	[Bodega]				[varchar](3)	Not Null DEFAULT (''),
	[Idmaeedo]				[int]			Not Null DEFAULT (0),
	[Idmaeddo]				[int]			Not Null DEFAULT (0),
	[Tido]					[varchar](3)	Not Null DEFAULT (''),
	[Nudo]					[varchar](10)	Not Null DEFAULT (''),
	[Codigo]				[varchar](13)	Not Null DEFAULT (''),
	[Descripcion]			[varchar](50)	Not Null DEFAULT (''),
	[Untrans]				[int]			Not Null DEFAULT (0),
	[UdTrans]				[varchar](2)	Not Null DEFAULT (''),
	[Rtu]					[float]			Not Null DEFAULT (0),
	[CantCUd1]				[float]			Not Null DEFAULT (0),
	[CantCUd2]				[float]			Not Null DEFAULT (0),
	[CantDUd1]				[float]			Not Null DEFAULT (0),
	[CantDUd2]				[float]			Not Null DEFAULT (0),
	[CantEUd1]				[float]			Not Null DEFAULT (0),
	[CantEUd2]				[float]			Not Null DEFAULT (0),
	[CantRUd1]				[float]			Not Null DEFAULT (0),
	[CantRUd2]				[float]			Not Null DEFAULT (0),
	[DespUd1]				[float]			Not Null DEFAULT (0),
	[DespUd2]				[float]			Not Null DEFAULT (0),
	[CodFuncionario_Desp]	[varchar](3)	Not Null DEFAULT (''),
    [Archirst]          	[varchar](20)	Not Null DEFAULT (''),
	[Idrst]					[int]			Not Null DEFAULT (0),
	[Activo]				[bit]			Not Null DEFAULT (1),
 CONSTRAINT [PK_Zw_Despachos_Doc_Det] PRIMARY KEY CLUSTERED 
(
	[Id_Detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
