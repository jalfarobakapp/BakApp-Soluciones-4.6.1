USE [#Base#]


CREATE TABLE [dbo].[Zw_Pdc_MesonVsMaquina](
	[Codmeson]      [char](13)      NOT NULL DEFAULT (''),
	[Codmaq]        [char](13)      NOT NULL DEFAULT (''),
	[Nombremaq]     [varchar](50)   NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Pdc_MesonVsMaquina] PRIMARY KEY CLUSTERED 
(
	[Codmeson] ASC,
	[Codmaq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

