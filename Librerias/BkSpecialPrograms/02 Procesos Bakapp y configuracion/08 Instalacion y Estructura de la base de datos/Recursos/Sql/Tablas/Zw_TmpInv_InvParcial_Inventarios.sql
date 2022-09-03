USE [#Base#]


CREATE TABLE [dbo].[Zw_TmpInv_InvParcial_Inventarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ano]				[char](4) NOT NULL DEFAULT (''),
	[Mes]				[char](2) NOT NULL DEFAULT (''),
	[Dia]				[char](2) NOT NULL DEFAULT (''),
	[Fecha]				[datetime] NOT NULL,
	[Empresa]			[char](2) NOT NULL DEFAULT (''),
	[Sucursal]			[char](3) NOT NULL DEFAULT (''),
	[Bodega]			[char](3) NOT NULL DEFAULT (''),
	[Nombre_Ajuste]		[varchar](100) NOT NULL DEFAULT (''),
	[Funcionario]		[char](3) NOT NULL DEFAULT (''),
	[Estado]			[bit] NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_TmpInv_InvParcial_Inventarios] PRIMARY KEY CLUSTERED 
(
	[Ano] ASC,
	[Mes] ASC,
	[Dia] ASC,
	[Fecha] ASC,
	[Empresa] ASC,
	[Sucursal] ASC,
	[Bodega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



