USE [#Base#]

CREATE TABLE [dbo].[Zw_Entidad_CiaSeguro](
	[Id] [int]              IDENTITY(1,1)   NOT NULL,
	[CodEntidad]			[varchar](13)   NOT NULL DEFAULT (''),
	[CodSucEntidad]			[varchar](20)   NOT NULL DEFAULT (''),
	[CodEntidad_Cia]		[varchar](13)   NOT NULL DEFAULT (''),
	[CodSucEntidad_Cia]		[varchar](20)   NOT NULL DEFAULT (''),
	[MontoAsignado]			[float]         NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Entidad_CiaSeguro] PRIMARY KEY CLUSTERED 
(
	[CodEntidad] ASC,
	[CodSucEntidad] ASC,
	[CodEntidad_Cia] ASC,
	[CodSucEntidad_Cia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



