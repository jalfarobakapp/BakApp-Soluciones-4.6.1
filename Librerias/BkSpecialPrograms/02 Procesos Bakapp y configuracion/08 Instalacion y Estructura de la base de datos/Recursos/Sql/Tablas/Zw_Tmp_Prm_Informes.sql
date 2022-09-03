USE [#Base#]


CREATE TABLE [dbo].[Zw_Tmp_Prm_Informes](
	[Funcionario]   [char](3)       NOT NULL DEFAULT (''),
	[Informe]       [varchar](50)   NOT NULL DEFAULT (''),
	[Campo]         [varchar](100)  NOT NULL DEFAULT (''),
	[Tipo]          [varchar](30)   NOT NULL DEFAULT (''),
	[Valor]         [varchar](100)  NOT NULL DEFAULT (''),
	[Grupo]         [varchar](50)   NOT NULL DEFAULT (''),
	[NombreEquipo]  [varchar](50)   NOT NULL DEFAULT (''),
	[Modalidad]     [varchar](5)    NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Tmp_Prm_Informes] PRIMARY KEY CLUSTERED 
(
	[Funcionario] ASC,
	[Informe] ASC,
	[Campo] ASC,
	[NombreEquipo] ASC,
	[Modalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


