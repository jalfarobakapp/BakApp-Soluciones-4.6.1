USE [#Base#]

CREATE TABLE [dbo].[Zw_Stmp_Det](
	[Id]						[int] IDENTITY(1,1) NOT NULL,
	[Id_Enc]					[int]			NOT NULL DEFAULT (0),
	[Idmaeedo]					[int]			NOT NULL DEFAULT (0),
	[Idmaeddo]					[int]			NOT NULL DEFAULT (0),
	[Codigo]					[varchar](13)	NOT NULL DEFAULT (''),
	[Descripcion]				[varchar](50)	NOT NULL DEFAULT (''),
	[Nulido]					[varchar](5)	NOT NULL DEFAULT (''),
	[Udtrpr]					[int]			NOT NULL DEFAULT (0),
	[Rludpr]					[float]			NOT NULL DEFAULT (0),
	[RtuVariable]				[bit]			NOT NULL DEFAULT (0),
	[Rlud_Real]					[float]			NOT NULL DEFAULT (0),
	[Udpr]						[char](2)		NOT NULL DEFAULT (''),
	[Cantidad]					[float]			NOT NULL DEFAULT (0),
	[Caprco1_Ori]				[float]			NOT NULL DEFAULT (0),
	[Caprco1_Real]				[float]			NOT NULL DEFAULT (0),
	[Ud01pr]					[char](2)		NOT NULL DEFAULT (''),
	[Caprco2_Ori]				[float]			NOT NULL DEFAULT (0),
	[Caprco2_Real]				[float]			NOT NULL DEFAULT (0),
	[Ud02pr]					[char](2)		NOT NULL DEFAULT (''),
	[Pickeado]					[bit]			NOT NULL DEFAULT (0),
	[CodFuncionario_Pickea]		[varchar](3)	NOT NULL DEFAULT (''),
	[EnProceso]					[bit]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Stmp_Det] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



