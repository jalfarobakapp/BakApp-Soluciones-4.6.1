
CREATE TABLE [dbo].[#Paso](
	[EMPRESA]           [char](2)  Default (''),
	[KOSU]              [char](3)	Default (''),
	[KOBO]              [char](3)	Default (''),
	[KOPR]              [char](13)	Default (''),
	[NOKOPR]            [varchar](50)	Default (''),
	[STFI1]             [float]	Default(0),
    [STFI2]             [float]	Default(0),
	StockF_Ud1          [float]    Default(0),
	StockF_Ud2          [float]    Default(0),
	Dif_StockF_Ud1      [float]    Default(0),
	Dif_StockF_Ud2      [float]    Default(0),
	[STDV1]             [float]    Default(0),
	[STDV2]             [float]    Default(0),
	StockDev_Ud1        [float]    Default(0),
	StockDev_Ud2        [float]    Default(0),
	Dif_StockDev_Ud1    [float]    Default(0),
	Dif_StockDev_Ud2    [float]    Default(0),
	[DESPNOFAC1]        [float]	Default(0),
	[DESPNOFAC2]        [float]	Default(0),
	StockDsf_Ud1        [float]	Default(0),
	StockDsf_Ud2        [float]	Default(0),
	Dif_StockDsf_Ud1    [float]    Default(0),
	Dif_StockDsf_Ud2    [float]    Default(0),
	[STOCNV1]           [float]    Default(0),
	[STOCNV2]           [float]    Default(0),
	StockCom_Ud1        [float]    Default(0),
	StockCom_Ud2        [float]    Default(0),
	Dif_StockCom_Ud1    [float]    Default(0),
	Dif_StockCom_Ud2    [float]    Default(0),
	[STDV1C]            [float]    Default(0),
	[STDV2C]            [float]    Default(0),
	StockCnr_Ud1        [float]    Default(0),
	StockCnr_Ud2        [float]    Default(0),
	Dif_StockCnr_Ud1    [float]    Default(0),
	Dif_StockCnr_Ud2    [float]    Default(0),
	[RECENOFAC1]        [float]	Default(0),
	[RECENOFAC2]        [float]	Default(0),
	StockRsf_Ud1        [float]	Default(0),
	StockRsf_Ud2        [float]	Default(0),
	Dif_StockRsf_Ud1    [float]    Default(0),
	Dif_StockRsf_Ud2    [float]    Default(0),
	[STOCNV1C]          [float]    Default(0),
	[STOCNV2C]          [float]    Default(0),
	StockPed_Ud1        [float]    Default(0),
	StockPed_Ud2        [float]    Default(0),
	Dif_StockPed_Ud1    [float]    Default(0),
	Dif_StockPed_Ud2    [float]    Default(0),
	[STTR1]             [float]    Default(0),
	[STTR2]             [float]    Default(0),
	StockTrans_Ud1      [float]    Default(0),
	StockTrans_Ud2      [float]    Default(0),
	Dif_StockTrans_Ud1  [float]    Default(0),
	Dif_StockTrans_Ud2  [float]    Default(0),
	Consolidado         [Bit]      Default(0),
 CONSTRAINT [PK_#Paso] PRIMARY KEY CLUSTERED 
(
	[EMPRESA] ASC,
	[KOSU] ASC,
	[KOBO] ASC,
	[KOPR] ASC
))

/*
Insert Into #Tabla_Paso# (EMPRESA,KOSU,KOBO,KOPR,STFI1,STFI2,STDV1,STDV2,DESPNOFAC1,DESPNOFAC2,STOCNV1,STOCNV2,STDV1C,STDV2C,RECENOFAC1,RECENOFAC2,STOCNV1C,STOCNV2C)
Select EMPRESA,KOSU,KOBO,KOPR,STFI1,STFI2,STDV1,STDV2,DESPNOFAC1,DESPNOFAC2,STOCNV1,STOCNV2,STDV1C,STDV2C,RECENOFAC1,RECENOFAC2,STOCNV1C,STOCNV2C 
From MAEST 
Where 1 > 0
#Condicion#
*/

Select * From #Paso
Drop Table #Paso
