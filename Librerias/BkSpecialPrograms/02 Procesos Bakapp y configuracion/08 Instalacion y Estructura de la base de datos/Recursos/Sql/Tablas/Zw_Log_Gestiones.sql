USE [#Base#]


CREATE TABLE [dbo].[Zw_Log_Gestiones](
	[Id]                    [int] IDENTITY(1,1) NOT NULL,
	[Empresa]               [char](2)           NOT NULL DEFAULT (''),
	[NombreEquipo]          [varchar](50)       NOT NULL DEFAULT (''),
	[Funcionario]           [char](3)           NOT NULL DEFAULT (''),
	[Modalidad]             [char](5)           NOT NULL DEFAULT (''),
	[Archirst]              [varchar](20)       NOT NULL DEFAULT (''),
	[Idrst]                 [int]               NOT NULL DEFAULT (0),
	[Fecha_Hora]            [datetime]          NOT NULL DEFAULT (GetDate()),
	[CodAccion]             [varchar](20)       NOT NULL DEFAULT (''),
	[Accion]                [varchar](1000)     NOT NULL DEFAULT (''),
	[CodPermiso]            [varchar](20)       NOT NULL DEFAULT (''),
	[Kopr]                  [varchar](13)       NOT NULL DEFAULT (''),
	[Koen]                  [varchar](13)       NOT NULL DEFAULT (''),
	[Suen]                  [varchar](10)       NOT NULL DEFAULT (''),
	[Solicitud_Permiso]     [bit]               NOT NULL DEFAULT (0),
	[Funcionario_Autoriza]  [char](3)           NOT NULL DEFAULT (''),
    [PermisoRemoto]         [bit]               NOT NULL DEFAULT (0),
    [Id_Rem]                [int]               NOT NULL DEFAULT (0),
    [NroRemota]             [varchar](10)       NOT NULL DEFAULT (''),
    [Tido]                  [varchar](3)        NOT NULL DEFAULT (''),
    [Nudo]                  [varchar](10)       NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Log_Gestiones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
