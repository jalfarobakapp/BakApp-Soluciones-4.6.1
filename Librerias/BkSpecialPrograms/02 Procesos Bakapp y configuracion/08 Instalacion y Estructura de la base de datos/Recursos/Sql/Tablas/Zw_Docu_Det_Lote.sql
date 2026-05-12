USE [#Base#]

CREATE TABLE [dbo].[Zw_Docu_Det_Lote](
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[Id_Det]		[int]			NOT NULL DEFAULT ('') ,
	[Idmaeddo]		[int]			NOT NULL DEFAULT ('') ,
	[Idmaeedo]		[int]			NOT NULL DEFAULT ('') ,
	[Empresa]		[char](2)		NOT NULL DEFAULT ('') ,
	[Sucursal]		[varchar](3)	NOT NULL DEFAULT ('') ,
	[Bodega]		[varchar](3)	NOT NULL DEFAULT ('') ,
	[Tido]			[varchar](3)	NOT NULL DEFAULT ('') ,
	[Nudo]			[varchar](10)	NOT NULL DEFAULT ('') ,
	[Codigo]		[varchar](13)	NOT NULL DEFAULT ('') ,
	[Descripcion]	[varchar](50)	NOT NULL DEFAULT ('') ,
	[NroLote]		[varchar](20)	NOT NULL DEFAULT ('') ,
	[SubLote]		[varchar](20)	NOT NULL DEFAULT ('') ,
	[FElaboracion]	[datetime]		NULL DEFAULT ('') ,
	[FVencimiento]	[datetime]		NULL DEFAULT ('') ,
	[CantUd1]		[float]			NOT NULL DEFAULT ('') ,
	[CantUd2]		[float]			NOT NULL DEFAULT ('') ,
 CONSTRAINT [PK_Zw_Docu_Det_Lote] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
