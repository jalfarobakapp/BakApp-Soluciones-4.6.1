USE [#Base#]


CREATE TABLE [dbo].[Zw_Usuarios_Huellas](
    [Id]                [int] IDENTITY(1,1) NOT NULL,
	[CodFuncionario]    [char](3)           NOT NULL DEFAULT (''),
	[Nro_Huella]        [int]               NOT NULL DEFAULT (0),
    [Zk4500]            [bit]               NOT NULL DEFAULT (0),
	[Huella]            [text]              NOT NULL DEFAULT (''),
    [Uare4500]          [bit]               NOT NULL DEFAULT (0),
    [Huella_Uare4500]   [varbinary](max)    NULL,
 CONSTRAINT [PK_Zw_Usuarios_Huellas] PRIMARY KEY CLUSTERED 
(
	[CodFuncionario] ASC,
	[Nro_Huella] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

