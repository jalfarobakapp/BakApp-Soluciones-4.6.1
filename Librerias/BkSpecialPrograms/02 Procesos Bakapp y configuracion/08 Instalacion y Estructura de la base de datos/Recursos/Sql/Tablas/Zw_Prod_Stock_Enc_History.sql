USE [#Base#]


CREATE TABLE [dbo].[Zw_Prod_Stock_Enc_History](
	[Codigo]				[varchar](13) NOT NULL,
	[Codigo_Nodo_Madre]		[varchar](20) NOT NULL DEFAULT (0),
	[Fecha_Desde]			[datetime] NULL,
	[Fecha_Ult_Revision]	[datetime] NOT NULL DEFAULT (getdate()),
 CONSTRAINT [PK_Zw_Prod_Stock_Enc_History] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


