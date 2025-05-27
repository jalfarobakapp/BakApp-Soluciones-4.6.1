USE [#Base#]

CREATE TABLE [dbo].[Zw_Stk_Tickets](
	[Id]					[int] IDENTITY(1,1) NOT NULL,
    [Id_Raiz]   			[int] NOT NULL DEFAULT (0),
	[Empresa]				[char](2) NOT NULL DEFAULT (''),
	[Sucursal]				[varchar](3) NOT NULL DEFAULT (''),
	[Numero]				[varchar](10) NOT NULL DEFAULT (''),
	[SubNro]				[varchar](3) NOT NULL DEFAULT (''),
	[Id_Area]				[int] NOT NULL DEFAULT (0),
	[Id_Tipo]				[int] NOT NULL DEFAULT (0),
	[Prioridad]				[varchar](2) NOT NULL DEFAULT (''),
	[FechaCreacion]			[datetime] NULL,
	[CodFuncionario_Crea]	[varchar](3) NOT NULL DEFAULT (''),
	[Asunto]				[varchar](50) NOT NULL DEFAULT (''),
	[Descripcion]			[varchar](max) NOT NULL DEFAULT (''),
	[Asignado]				[bit] NOT NULL DEFAULT (0),
	[AsignadoGrupo]			[bit] NOT NULL DEFAULT (0),
	[Id_Grupo]				[int] NOT NULL DEFAULT (0),
	[AsignadoAgente]		[bit] NOT NULL DEFAULT (0),
	[CodAgente]				[varchar](3) NOT NULL DEFAULT (''),
	[Estado]				[varchar](4) NOT NULL DEFAULT (''),
	[UltAccion]				[varchar](4) NOT NULL DEFAULT (''),
	[CodFuncionario_Cierra] [varchar](3) NOT NULL DEFAULT (''),
	[FechaCierre]			[datetime] NULL,
	[Id_Padre]				[int] NOT NULL DEFAULT (0),
    [Rechazado]				[bit] NOT NULL DEFAULT (0),
    [Aceptado]				[bit] NOT NULL DEFAULT (0),    
    [Cerrado]				[bit] NOT NULL DEFAULT (0),  
    [FechaCerrado]          [datetime] NULL,
 CONSTRAINT [PK_Zw_Stk_Tickets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]



