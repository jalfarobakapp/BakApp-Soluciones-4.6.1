USE [#Base#]


CREATE TABLE [dbo].[Zw_St_Conf_Tecnicos_Taller](
	[CodFuncionario]        [char](3)       NOT NULL DEFAULT (''),
	[NomFuncionario]        [varchar](50)   NOT NULL DEFAULT (''),
	[Direccion]             [varchar](50)   NOT NULL DEFAULT (''),
	[Telefono]              [varchar](30)   NOT NULL DEFAULT (''),
	[Email]                 [varchar](50)   NOT NULL DEFAULT (''),
	[Pais]                  [char](3)       NOT NULL DEFAULT (''),
	[Ciudad]                [char](3)       NOT NULL DEFAULT (''),
	[Comuna]                [char](3)       NOT NULL DEFAULT (''),
	[Star]                  [int]           NOT NULL DEFAULT (0),
	[Chk_Taller_Externo]    [bit]           NOT NULL DEFAULT (0),
	[Chk_Habilitado]        [bit]           NOT NULL DEFAULT (0),
	[Chk_Supervisor]        [bit]           NOT NULL DEFAULT (0),
	[Chk_Domicilio]         [bit]           NOT NULL DEFAULT (0),
	[Informacion]           [varchar](1000) NOT NULL DEFAULT (''),
    [EsTecnico]             [bit]           NOT NULL DEFAULT (0),
    [PwTecnico]             [varchar](5)    NOT NULL DEFAULT (''),
    [EsTaller]              [bit]           NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_St_Conf_Tecnicos_Taller] PRIMARY KEY CLUSTERED 
(
	[CodFuncionario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
