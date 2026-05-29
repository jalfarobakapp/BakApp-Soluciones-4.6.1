USE [#Base#]

CREATE TABLE [dbo].[Zw_Docu_Det_Lote](
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[Id_Det]		[int]			NOT NULL DEFAULT (0) ,
	[Idmaeddo]		[int]			NOT NULL DEFAULT (0) ,
	[Idmaeedo]		[int]			NOT NULL DEFAULT (0) ,
	[Idmaeddo_Ori]  [int]			NOT NULL DEFAULT (0) ,
    [Tido_Ori]		[varchar](3)	NOT NULL DEFAULT ('') ,
    [Nudo_Ori]		[varchar](3)	NOT NULL DEFAULT ('') ,
	[Empresa]		[char](2)		NOT NULL DEFAULT ('') ,
	[Sucursal]		[varchar](3)	NOT NULL DEFAULT ('') ,
	[Bodega]		[varchar](3)	NOT NULL DEFAULT ('') ,
	[Tido]			[varchar](3)	NOT NULL DEFAULT ('') ,
	[Nudo]			[varchar](10)	NOT NULL DEFAULT ('') ,
	[Codigo]		[varchar](13)	NOT NULL DEFAULT ('') ,
	[Descripcion]	[varchar](50)	NOT NULL DEFAULT ('') ,
	[NroLote]		[varchar](20)	NOT NULL DEFAULT ('') ,
	[SubLote]		[varchar](20)	NOT NULL DEFAULT ('') ,
	[FElaboracion]	[datetime]		NULL,
	[FVencimiento]	[datetime]		NULL,
	[CantUd1]		[float]			NOT NULL DEFAULT (0) ,
	[CantUd2]		[float]			NOT NULL DEFAULT (0) ,
    [CantExUd1]		[float]			NOT NULL DEFAULT (0) ,
	[CantExUd2]		[float]			NOT NULL DEFAULT (0) ,
 CONSTRAINT [PK_Zw_Docu_Det_Lote] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
