USE [#Base#]


CREATE TABLE [dbo].[Zw_Pdp_OT_Prioridad](
	[Idpote]			[int]       NOT NULL DEFAULT (0),
	[Numot]				[char](10)  NOT NULL DEFAULT (''),
	[Fecha_Prioridad]	[datetime]  NOT NULL DEFAULT (Getdate()),
	[Grado]				[int]       NOT NULL DEFAULT (1),
 CONSTRAINT [PK_Zw_Pdp_OT_Prioridad] PRIMARY KEY CLUSTERED 
(
	[Idpote] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


