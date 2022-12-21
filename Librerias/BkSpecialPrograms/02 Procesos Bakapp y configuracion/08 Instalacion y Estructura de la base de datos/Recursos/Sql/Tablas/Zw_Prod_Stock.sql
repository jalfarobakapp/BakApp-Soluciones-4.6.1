USE [#Base#]

CREATE TABLE [dbo].[Zw_Prod_Stock](
	[Codigo]        [varchar](13)   NOT NULL Default(''),
	[Empresa]       [char](2)       NOT NULL Default(''),
	[Sucursal]      [varchar](3)    NOT NULL Default(''),
	[Bodega]        [varchar](3)    NOT NULL Default(''),
	[StComp1]       [float]         NOT NULL Default(0),
	[StComp2]       [float]         NOT NULL Default(0),
	[StPedi1]       [float]         NOT NULL Default(0),
	[StPedi2]       [float]         NOT NULL Default(0),
	[StfiBodExt1]   [float]         NOT NULL Default(0),
	[StfiBodExt2]   [float]         NOT NULL Default(0),    
 CONSTRAINT [PK_Zw_Prod_Stock] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC,
	[Empresa] ASC,
	[Sucursal] ASC,
	[Bodega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

