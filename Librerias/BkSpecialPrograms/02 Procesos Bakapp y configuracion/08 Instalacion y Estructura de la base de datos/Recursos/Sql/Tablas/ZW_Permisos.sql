USE [#Base#]


CREATE TABLE [dbo].[ZW_Permisos](
	[Semilla]				[int] IDENTITY(1,1) NOT NULL,
	[CodPermiso]			[varchar](20)		NOT NULL DEFAULT (''),
	[DescripcionPermiso]	[varchar](200)		NOT NULL DEFAULT (''),
	[CodFamilia]			[varchar](20)		NOT NULL DEFAULT (''),
	[NombreFamiliaPermiso]	[varchar](60)		NOT NULL DEFAULT (''),
	[Descuento]				[bit]				NOT NULL DEFAULT (0),
	[Max_Compra]			[bit]				NOT NULL DEFAULT (0),
 CONSTRAINT [PK_ZW_Permisos] PRIMARY KEY CLUSTERED 
(
	[CodPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


