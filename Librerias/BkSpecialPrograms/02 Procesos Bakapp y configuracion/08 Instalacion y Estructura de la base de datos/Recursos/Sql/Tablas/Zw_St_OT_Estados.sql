USE [#Base#]


CREATE TABLE [dbo].[Zw_St_OT_Estados](
	[Id_Ot]             [int]           NOT NULL DEFAULT (0),
	[CodEstado]         [varchar](2)    NOT NULL DEFAULT (''),
	[Fecha_Fijacion]    [datetime]      NULL,
	[CodFuncionario]    [char](3)       NOT NULL DEFAULT (''),
	[NomFuncionario]    [varchar](50)   NOT NULL DEFAULT (''),
	[Semilla]           [int]           IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Zw_St_OT_Estados] PRIMARY KEY CLUSTERED 
(
	[Id_Ot] ASC,
	[CodEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


