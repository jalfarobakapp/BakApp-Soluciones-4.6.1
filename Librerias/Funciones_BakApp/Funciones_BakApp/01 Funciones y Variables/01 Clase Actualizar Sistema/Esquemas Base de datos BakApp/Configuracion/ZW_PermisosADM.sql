USE [#Base#]

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON

CREATE TABLE [dbo].[ZW_PermisosADM](
	[ClaveAdministrador] [varchar](50) NOT NULL DEFAULT (''),
	[Nombre] [varchar](30) NULL DEFAULT ('')
) ON [PRIMARY]


Insert Into ZW_PermisosADM (ClaveAdministrador,Nombre) Values 
                           ('21232f297a57a5a743894a0e4a801fc3','Administrador del sistema')
-- Clave admin

