USE [#Base#]

CREATE TABLE [dbo].[Zw_ListaLC_Programadas_Detalles](
	[Id]					[int] IDENTITY(1,1) NOT NULL,
	[Id_Enc]				[int] NOT NULL DEFAULT (0),
	[Lista]					[char](3) NOT NULL DEFAULT (''),
	[NombreLista]			[varchar](30) NOT NULL DEFAULT (''),
	[Codigo]				[char](13) NOT NULL DEFAULT (''),
	[PrecioUd1]				[float] NOT NULL DEFAULT (0),
	[PrecioUd2]				[float] NOT NULL DEFAULT (0),
	[EcuacionUd1]			[varchar](200) NOT NULL DEFAULT (''),
	[EcuacionUd2]			[varchar](200) NOT NULL DEFAULT (''),
	[Rtu]					[float] NOT NULL DEFAULT (0),
	[MargenPorc]			[float] NOT NULL DEFAULT (0),
	[VarMcosto]				[float] NOT NULL DEFAULT (0),
	[VarPm]					[float] NOT NULL DEFAULT (0),
	[VarUc]					[float] NOT NULL DEFAULT (0),
	[VarFlete]				[float] NOT NULL DEFAULT (0),
	[VarIva]				[float] NOT NULL DEFAULT (0),
	[VarIla]				[float] NOT NULL DEFAULT (0),
	[VarNetoDigit]			[float] NOT NULL DEFAULT (0),
	[VarValorDigit]			[float] NOT NULL DEFAULT (0),
	[Eliminada]				[bit] NOT NULL DEFAULT (0),
	[FuncionarioElimina]	[varchar](3) NOT NULL DEFAULT (''),
	[FechaEliminacion]		[datetime] NULL,
 CONSTRAINT [PK_Zw_ListaLC_Programadas_Detalles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
