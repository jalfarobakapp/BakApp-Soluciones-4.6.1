USE [#Base#]

CREATE TABLE [dbo].[Zw_Docu_Det](
	[Idmaeddo]			[int]			NOT NULL DEFAULT (0),
	[Idmaeedo]			[int]			NOT NULL DEFAULT (0),
	[Tido]				[varchar](3)	NOT NULL DEFAULT (''),
	[Nudo]				[varchar](10)	NOT NULL DEFAULT (''),
	[Codigo]			[varchar](13)	NOT NULL DEFAULT (''),
	[Descripcion]		[varchar](50)	NOT NULL DEFAULT (''),
	[RtuVariable]		[bit]			NOT NULL DEFAULT (0),
    [Empresa]           [char](2)       NOT NULL DEFAULT (''),
	[Sucursal]          [varchar](3)    NOT NULL DEFAULT (''),
	[Bodega]            [varchar](3)    NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Docu_Det] PRIMARY KEY CLUSTERED 
(
	[Idmaeddo] ASC,
	[Idmaeedo] ASC,
	[Tido] ASC,
	[Nudo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



