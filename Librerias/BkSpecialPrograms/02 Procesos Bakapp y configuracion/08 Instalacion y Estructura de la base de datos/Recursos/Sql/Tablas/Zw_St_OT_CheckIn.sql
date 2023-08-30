USE [#Base#]


CREATE TABLE [dbo].[Zw_St_OT_CheckIn](
	[Id_Ot]     [int]           NOT NULL DEFAULT (0),
	[Semilla]   [int]           IDENTITY(1,1) NOT NULL,
	[Codigo]    [varchar](10)   NOT NULL DEFAULT (''),
	[Check_In]  [varchar](50)   NOT NULL DEFAULT (''),
	[Nota]      [varchar](100)  NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_St_OT_CheckIn] PRIMARY KEY CLUSTERED 
(
	[Semilla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

