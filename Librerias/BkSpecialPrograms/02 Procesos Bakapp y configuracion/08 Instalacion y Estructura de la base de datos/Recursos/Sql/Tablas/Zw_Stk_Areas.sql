USE [#Base#]

CREATE TABLE [dbo].[Zw_Stk_Areas](
	[Id]	[int]			IDENTITY(1,1) NOT NULL,
	[Area]	[varchar](50)	NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Stk_Areas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



