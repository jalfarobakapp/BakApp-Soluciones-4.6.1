USE [#Base#]

CREATE TABLE [dbo].[Zw_Chilexpress_Res](
	[IdRespuesta] [int] IDENTITY(1,1) NOT NULL,
	[Idenvio]						[int] NOT NULL Default(''),
	[transportOrderNumber]			[varchar](50) NOT NULL Default(''),
	[reference]						[varchar](20) NOT NULL Default(''),
	[productDescription]			[varchar](10) NOT NULL Default(''),
	[serviceDescription]			[varchar](10) NOT NULL Default(''),
	[genericString1]				[varchar](10) NOT NULL Default(''),
	[genericString2]				[varchar](10) NOT NULL Default(''),
	[deliveryTypeCode]				[varchar](10) NOT NULL Default(''),
	[destinationCoverageAreaName]	[varchar](100) NOT NULL Default(''),
	[additionalProductDescription]	[varchar](50) NOT NULL Default(''),
	[barcode]						[varchar](50) NOT NULL Default(''),
	[classificationData]			[varchar](50) NOT NULL Default(''),
	[printedDate]					[datetime] NULL Default(''),
	[labelVersion]					[varchar](10) NOT NULL Default(''),
	[distributionDescription]		[varchar](100) NOT NULL Default(''),
	[companyName]					[varchar](50) NOT NULL Default(''),
	[recipient]						[varchar](50) NOT NULL Default(''),
	[address]						[varchar](100) NOT NULL Default(''),
	[groupReference]				[varchar](50) NOT NULL Default(''),
	[createdDate]					[datetime] NULL Default(''),
 CONSTRAINT [PK_Zw_Chilexpress_Res] PRIMARY KEY CLUSTERED 
(
	[IdRespuesta] ASC,
	[Idenvio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

