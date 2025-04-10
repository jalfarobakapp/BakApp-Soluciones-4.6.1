USE [#Base#]

CREATE TABLE [dbo].[Zw_Stk_Tickets_Producto](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[Id_Ticket]			[int]			NOT NULL DEFAULT (0),
	[Id_Raiz]			[int]			NOT NULL DEFAULT (0),
	[Numero]			[varchar](10)   NOT NULL DEFAULT (''),
	[Empresa]			[char](2)		NOT NULL DEFAULT (''),
	[Sucursal]			[varchar](3)	NOT NULL DEFAULT (''),
	[Bodega]			[varchar](3)	NOT NULL DEFAULT (''),
	[Codigo]			[varchar](13)	NOT NULL DEFAULT (''),
	[Descripcion]		[varchar](50)	NOT NULL DEFAULT (''),
	[Rtu]				[float]			NOT NULL DEFAULT (0),
	[UdMedida]			[int]			NOT NULL DEFAULT (0),
	[Ud1]				[varchar](2)	NOT NULL DEFAULT (''),
	[Ud2]				[varchar](2)	NOT NULL DEFAULT (''),
	[StfiEnBodega]      [float]			NOT NULL DEFAULT (0),
    [Cantidad]			[float]			NOT NULL DEFAULT (0),
    [Diferencia]        [float]			NOT NULL DEFAULT (0),
    [FechaRev]			[datetime]		NULL,
	[Stfi1]				[float]			NOT NULL DEFAULT (0),
	[Stfi2]				[float]			NOT NULL DEFAULT (0),		
	[RevInventario]		[bit]			NOT NULL DEFAULT (0),
	[AjusInventario]	[bit]			NOT NULL DEFAULT (0),
	[SobreStock]		[bit]			NOT NULL DEFAULT (0),
    [Ubicacion]			[varchar](30)	NOT NULL DEFAULT (''),
    [Id_TicketAc]       [int]           NOT NULL DEFAULT (''),
    [Id_Padre]          [int]           NOT NULL DEFAULT (''),
    [ConfCantCero]      [bit]           NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Stk_Tickets_Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

