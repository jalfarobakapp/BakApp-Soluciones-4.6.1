USE [#Base#]

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON

CREATE TABLE [dbo].[ZW_SOC_Obs](
	[Id_SOC]                   [int]          NOT NULL,
	[Nro_SOC]                  [char](10)     NOT NULL DEFAULT (''),
	[Accion]                   [char](1)      NOT NULL DEFAULT (''),
	[Observaciones]            [varchar](300) NOT NULL DEFAULT (''),
	[ObsAutoriza]              [varchar](300) NOT NULL DEFAULT (''),
	[Fecha_Facturacion_Cli]    [date]         NULL,
	[Nro_Occ_Cli]              [varchar](20)  NOT NULL DEFAULT (''),
	[CodEntidad_Retiro]        [varchar](10)  NOT NULL DEFAULT (''),
	[SucEntidad_Retiro]        [varchar](10)  NOT NULL DEFAULT (''),
	[Ciudad_Retiro]            [varchar](100) NOT NULL DEFAULT (''),
	[Comuna_Retiro]            [varchar](100) NOT NULL DEFAULT (''),
	[Direccion_Retiro]         [varchar](100) NOT NULL DEFAULT (''),
	[Fecha_Retiro]             [date]         NULL,
	[Hora_Retiro]              [varchar](100) NOT NULL DEFAULT (''),
	[Rutcontac_Retiro]         [varchar](20)  NOT NULL DEFAULT (''),
	[Contacto_Retiro]          [varchar](100) NOT NULL DEFAULT (''),
	[Contacto_Email]           [varchar](100) NOT NULL DEFAULT (''),
	[Fono_Retiro]              [varchar](50)  NOT NULL DEFAULT (''),
	[Rutcontac_AutorizaPrecio] [varchar](20)  NOT NULL DEFAULT (''),
	[PreciosAtorizadosPor]     [varchar](100) NOT NULL DEFAULT ('')
) ON [PRIMARY]
