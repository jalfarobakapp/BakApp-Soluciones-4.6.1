USE [#Base#]


CREATE TABLE [dbo].[Zw_Usuarios](
    [Id]                [int] IDENTITY(1,1) NOT NULL,
    [NombreUsuario]     [varchar](80)   NOT NULL,
	[Password]          [varchar](30)   NOT NULL,
	[CodFuncionario]    [char](3)       NOT NULL DEFAULT (''),
	[NomFuncionario]    [varchar](100)  NOT NULL DEFAULT (''),
	[Rut]               [varchar](20)   NOT NULL DEFAULT (''),
	[Direccion]         [varchar](100)  NOT NULL DEFAULT (''),
	[CodPais]           [char](4)       NOT NULL DEFAULT (''),
	[CodCiudad]         [char](4)       NOT NULL DEFAULT (''),
	[CodComuna]         [char](4)       NOT NULL DEFAULT (''),
	[Modalidad_defecto] [char](5)       NOT NULL DEFAULT (''),
	[Telefono_fijo]     [varchar](50)   NOT NULL DEFAULT (''),
	[Telefono_movil]    [varchar](50)   NOT NULL DEFAULT (''),
	[Email]             [varchar](100)  NOT NULL DEFAULT (''),
	[Cargo]             [varchar](50)   NOT NULL DEFAULT (''),
	[Pwfu]              [varchar](50)   NOT NULL DEFAULT (''),
	[Es_Vendedor]       [bit]           NOT NULL DEFAULT (0),
    [Kogru_Ventas]      [varchar](15)   NOT NULL DEFAULT (''),
  CONSTRAINT [PK_Zw_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
