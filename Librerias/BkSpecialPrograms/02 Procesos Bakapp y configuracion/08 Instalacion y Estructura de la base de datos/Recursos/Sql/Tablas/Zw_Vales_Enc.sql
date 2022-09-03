USE [#Base#]


CREATE TABLE [dbo].[Zw_Vales_Enc](
	[Id]					[int] IDENTITY(1,1) NOT NULL,
	[NroVale]				[char](10) NOT NULL DEFAULT (''),
	[CodEntidad]			[char](10) NOT NULL DEFAULT (''),
	[SucEntidad]			[char](10) NOT NULL DEFAULT (''),
	[Tipo_Entrega]			[char](1) NOT NULL DEFAULT (''),
	[Estado]				[char](1) NOT NULL DEFAULT (''),
	[Fecha_Emision]			[datetime] NULL,
	[Hora_Emision]			[datetime] NULL,
	[Fecha_Activacion]		[datetime] NULL,
	[Hora_Activacion]		[datetime] NULL,
	[Funcionario_Marca]		[char](3) NOT NULL DEFAULT (''),
	[Funcionario_Activa]	[char](3) NOT NULL DEFAULT (''),
	[Funcionario_Anula]		[char](3) NOT NULL DEFAULT (''),
	[Fecha_Cierre]			[datetime] NULL,
	[Id_Doc_As]				[int] NOT NULL DEFAULT (0),
	[Tipo_Doc_As]			[char](3) NOT NULL DEFAULT (''),
	[NroDoc_Doc_As]			[char](10) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Vales_Enc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
