USE [#Base#]

CREATE TABLE [dbo].[Zw_Prod_CodQR](
    [Semilla]   [int] IDENTITY(1,1) NOT NULL,
	[CodigoQR]	[varchar](300)  NOT NULL DEFAULT (''),
	[Kopral]	[varchar](21)	NOT NULL DEFAULT (''),
	[Koen]	    [varchar](13)	NOT NULL DEFAULT (''),
	[Kopr]	    [varchar](13)	NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Prod_CodQR] PRIMARY KEY CLUSTERED 
(
	[CodigoQR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



