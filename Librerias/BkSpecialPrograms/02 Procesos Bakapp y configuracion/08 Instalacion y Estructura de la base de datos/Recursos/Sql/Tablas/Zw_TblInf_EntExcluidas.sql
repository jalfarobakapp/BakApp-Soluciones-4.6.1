USE [#Base#]


CREATE TABLE [dbo].[Zw_TblInf_EntExcluidas](
	[Excluida] [char](1) NOT NULL DEFAULT (''),
	[Funcionario] [char](3) NOT NULL DEFAULT (''),
	[Codigo] [varchar](10) NOT NULL DEFAULT (''),
	[Sucursal] [varchar](20) NOT NULL DEFAULT (''),
	[Razon] [varchar](50) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_TblInf_EntExcluidas] PRIMARY KEY CLUSTERED 
(
	[Excluida] ASC,
	[Funcionario] ASC,
	[Codigo] ASC,
	[Sucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



