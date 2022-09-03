USE [#Base#]

CREATE TABLE [dbo].[Zw_Casi_DocTag](
	[Id_Tag] 		[int] 			IDENTITY(1,1) NOT NULL,
	[Id_DocEnc] 	[int] 			NOT NULL Default(0),
	[Archirve] 		[varchar](8) 	NOT NULL Default(''),
	[Idrve] 		[int] 			NOT NULL Default(0),
	[Kofu] 			[varchar](3) 	NOT NULL Default(''),
	[Fevento] 		[datetime] 		NOT NULL Default(Getdate()),
	[Kotabla] 		[varchar](10) 	NOT NULL Default(''),
	[Kocarac] 		[varchar](10) 	NOT NULL Default(''),
	[Nokocarac] 	[varchar](200) 	NOT NULL Default(''),
	[Archirse] 		[varchar](8) 	NOT NULL Default(''),
	[Idrse] 		[int] 			NOT NULL Default(0),
	[Horagrab] 		[int] 			NOT NULL Default(0),
	[Fecharef] 		[datetime] 		NULL,
	[Link] 			[varchar](400) 	NOT NULL Default(''),
	[Kofudest] 		[varchar](3) 	NOT NULL Default(''),
	[Dessutabla]	[varchar](50) 	NOT NULL Default(''),
 CONSTRAINT [PK_Zw_Casi_DocTag] PRIMARY KEY CLUSTERED 
(
	[Id_Tag] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
