USE [#Base#]


CREATE TABLE [dbo].[Zw_ListaLC_Programadas](
	[Id]					[int] IDENTITY(1,1) NOT NULL,
	[Codigo]				[char](13) NOT NULL DEFAULT (''),
	[NombreProgramacion]	[varchar](200) NOT NULL DEFAULT (''),
	[FechaCreacion]			[datetime] NULL,
	[FechaProgramada]		[datetime] NULL,
	[FechaAplica]			[datetime] NULL,
	[Aplicado]				[bit] NOT NULL DEFAULT (0),
	[Funcionario]			[varchar](50) NOT NULL DEFAULT (''),
	[Activo]				[bit] NOT NULL DEFAULT (0),
	[Id_Padre]				[int] NOT NULL DEFAULT (0),
	[Editada]				[bit] NOT NULL DEFAULT (0),
	[Eliminada]				[bit] NOT NULL DEFAULT (0),
	[FuncionarioElimina]	[varchar](3) NOT NULL DEFAULT (''),
	[FechaEliminacion]		[datetime] NULL,
	[Informacion]			[varchar](2000) NOT NULL DEFAULT (''),
	[ErrorAlGrabar]			[bit] NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_ListaLC_Programadas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


