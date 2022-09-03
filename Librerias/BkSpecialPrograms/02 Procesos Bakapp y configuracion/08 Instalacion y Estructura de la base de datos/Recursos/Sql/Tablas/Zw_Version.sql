USE [#Base#]


CREATE TABLE [dbo].[Zw_Version](
	[Semilla]				[int] IDENTITY(1,1) NOT NULL,
	[Version]				[varchar](50) NOT NULL DEFAULT (''),
	[Nombre_Archivo]		[varchar](50) NOT NULL DEFAULT (''),
	[Fecha_Actualizacion]	[datetime] NULL,
	[Activa]				[bit] NOT NULL DEFAULT (0),
	[Url_Descarga]			[varchar](500) NOT NULL DEFAULT (''),
	[Version_Anterior]		[varchar](50) NOT NULL DEFAULT (''),
    [TipoBK]        		[varchar](20) NOT NULL DEFAULT (''),    
 CONSTRAINT [PK_Zw_Version] PRIMARY KEY CLUSTERED 
(
	[Version] ASC,
	[Nombre_Archivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



