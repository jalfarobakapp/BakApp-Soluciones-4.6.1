USE [#Base#]

CREATE TABLE [dbo].[Zw_EstacionesBkp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IpEstacion]					    [varchar](20)	NOT NULL DEFAULT (''),
	[NombreEquipo]					    [varchar](50)	NOT NULL DEFAULT (''),
	[TipoEstacion]					    [char](3)		NOT NULL DEFAULT (''),
	[IpRandom]						    [varchar](20)	NOT NULL DEFAULT (0),
	[KeyReg]						    [varchar](100)	NOT NULL DEFAULT (''),
	[Conectado]						    [bit]			NOT NULL DEFAULT (0),
	[Fecha_Hora_Conec]				    [datetime]		NULL,
	[CodUsuario]					    [varchar](3)	NOT NULL DEFAULT (''),
	[NomUsuario]					    [varchar](50)	NOT NULL DEFAULT (''),
	[Version]						    [varchar](20)	NOT NULL DEFAULT (''),
	[Directorio_GenDTE]				    [varchar](500)	NOT NULL DEFAULT (''),
	[Usuario_X_Defecto]				    [varchar](50)	NOT NULL DEFAULT (''),
	[Modalidad_X_Defecto]			    [varchar](5)	NOT NULL DEFAULT (''),
	[Mos_Notif_X_CdPermiso]			    [bit]			NOT NULL DEFAULT (0),
	[Alias]							    [varchar](200)	NOT NULL DEFAULT (''),
	[Empresa_X_Defecto]				    [char](2)		NOT NULL DEFAULT (''),
	[Usar_Datos_X_Defecto]			    [bit]			NOT NULL DEFAULT (0),
	[Usuario_Actual]				    [varchar](3)	NOT NULL DEFAULT (''),
	[Modalidad_Actual]				    [varchar](5)	NOT NULL DEFAULT (''),
	[Buscar_Actualizacion_En_FTP]	    [bit]			NOT NULL DEFAULT (1),
    [Silenciar_Notificaciones]  	    [bit]			NOT NULL DEFAULT (0),
    [Es_Diablito]  	                    [bit]			NOT NULL DEFAULT (0),
    [Tiene_Lector_Huella]       	    [bit]			NOT NULL DEFAULT (0),
    [Lector_Huella]	    			    [varchar](100)	NOT NULL DEFAULT (''),
    [Modalidad_Caja]	    		    [varchar](5)	NOT NULL DEFAULT (''),
    [Caja_Habilitada]             	    [bit]			NOT NULL DEFAULT (0),
    [ImprDespGrabarCaja]           	    [bit]			NOT NULL DEFAULT (0),
    [Empresa_Actual]				    [Char](2)	    NOT NULL DEFAULT (''),
    [EsDTEMonitor]		    		    [Bit]   	    NOT NULL DEFAULT (0),
    [DTEMonitorAmbienteCertificacion]	[Bit]   	    NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_EstacionesBkp] PRIMARY KEY CLUSTERED 
(
	[IpEstacion] ASC,
	[NombreEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
