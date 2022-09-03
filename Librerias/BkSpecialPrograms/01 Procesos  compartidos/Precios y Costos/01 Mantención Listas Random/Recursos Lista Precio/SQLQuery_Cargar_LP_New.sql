--Zw_PsLp#Funcionario#

CREATE TABLE [dbo].[#Tbl_Paso_LP#] ( 
[IdLista]           Int IDENTITY(1, 1) NOT NULL,
[Select]            [Bit] Default (0),
[Editado]           [Bit] Default (0),
[KOLT]              [CHAR] (3) NOT NULL , -- 1
[KOPR]              [CHAR] (13) NOT NULL , -- 2
[KOPRRA]            [CHAR] (6) NOT NULL , -- 3
[KOPRTE]            [CHAR] (20) NOT NULL , -- 4
[FEVI]              [DATETIME] NULL , -- 5
[ECUACION]          [CHAR] (242) Default '', -- 6
[RLUD]              [Float] Default (0), -- 7
[PP01UD]            [Float] Default (0), -- 8
[MG01UD]            [Float] Default (0), -- 9
[DTMA01UD]          [Float] Default (0), -- 10
[PP02UD]            [Float] Default (0), -- 11
[MG02UD]            [Float] Default (0), -- 12
[DTMA02UD]          [Float] Default (0), -- 13
[PPUL01]            [Float] Default (0), -- 14
[PPUL02]            [Float] Default (0), -- 15
[PM01]              [Float] Default (0), -- 16
[PM02]              [Float] Default (0), -- 17
[C_INSUMOS]         [Float] Default (0), -- 18
[C_MAQUINAS]        [Float] Default (0), -- 19
[C_M_OBRA]          [Float] Default (0), -- 20
[C_FABRIC]          [Float] Default (0), -- 21
[C_COMPRA]          [Float] Default (0), -- 22
[C_LIBRE]           [Float] Default (0), -- 23 
[ECUACIONU2]        [CHAR] (242) Default '' , -- 24
[EMG01UD]           [CHAR] (242) Default '' , -- 25
[EMG02UD]           [CHAR] (242) Default '' , -- 26
[EDTMA01UD]         [CHAR] (242) Default '' , -- 27
[EDTMA02UD]         [CHAR] (242) Default '' , -- 28
#Campos_Adicioanles#
[PMSUC]             [Float] Default (0),  
[IVA]               [Float] Default (0),  
[ILA]               [Float] Default (0),  
[MELT]              [CHAR] (1) Default '' ,
[FINMAES]           [Float] Default (0),
[FMPR]              [CHAR] (4) NULL , 
[PFPR]              [CHAR] (4) NULL ,
[HFPR]              [CHAR] (4) NULL ,
[MRPR]              [CHAR] (20) NULL ,
[RUPR]              [CHAR] (3) NULL ,
[NOKOPR]            [CHAR] (50) NULL ,
[UD01PR]            [CHAR] (2) NULL ,
[UD02PR]            [CHAR] (2) NULL ,
[Codigo]            [CHAR] (21) NULL  

 CONSTRAINT [PK_#Tbl_Paso_LP#] PRIMARY KEY CLUSTERED 
(
	[IdLista] ASC,
	[KOLT] ASC,
	[KOPR] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, 
       IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, 
       ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
 
 /*
 
 [DSCTONRO1]         [Float] Default (0), -- 29
[FORM_029]          [CHAR] (121) NULL , -- 30
[DSCTONRO2]         [Float] Default (0), -- 31
[FORM_031]          [CHAR] (121) NULL , -- 32
[DSCTONRO3]         [Float] Default (0), -- 33
[FORM_033]          [CHAR] (121) NULL , -- 34
[MGADICIONA]        [Float] Default (0), -- 35
[FORM_035]          [CHAR] (242) NULL , -- 36 
 
 */
 
/*
CREATE TABLE [dbo].[Zw_PsLp#Funcionario#](
    [IdLista]           Int IDENTITY(1, 1) NOT NULL,
    [Select]            [Bit] Default (0),
	[Lista]             [char](3) NOT NULL,
	[Codigo]            [char](13) NOT NULL,
	[Descripcion]       [varchar](50) default '',
	[Rtu]               [float] Default (0),
	[Ud1]               [varchar](2) default '',
	[Ud2]               [varchar](2) default '',
	[Ej_Fx_documento]   [Bit] Default (0),
	[Ej_Fx_documento2]  [Bit] Default (0),
	[Formula]           [varchar](1000) default '',
	[Formula2]          [varchar](1000) default '',
	[FormulaRdUd1]      [varchar](1000) default '',
	[FormulaRdUd2]      [varchar](1000) default '',
	[Redondear]         [float] Default (0),
	[Costo]             [float] Default (0),
	[Precio]            [float] Default (0),
	[Margen]            [float] Default (0),
	[Margen_Adicional]  [float] Default (0),
	[Costo2]            [float] Default (0),
	[Precio2]           [float] Default (0),
	[Margen2]           [float] Default (0),
	[Margen_Adicional2] [float] Default (0),
	[DsctoMax]          [float] Default (0),
	[Dscto1]            [float] Default (0),
	[Dscto2]            [float] Default (0),
	[Dscto3]            [float] Default (0),
	[Dscto4]            [float] Default (0),
	[Dscto5]            [float] Default (0),
	[Flete]             [float] Default (0),
	[LtCosto]           [Char] (3) Default '',
	[CostoLt]           [float] Default (0),
	[Porc_Iva]          [float] Default (0),
	[Porc_Ila]          [float] Default (0),
	[Impuestos]         [float] Default (0),
	[Iva]               [float] Default (0),
	[Ila]               [float] Default (0),
	[Neto]              [float] Default (0),
	[Bruto]             [float] Default (0),
	[ValoresNetos]      [Bit]   Default (0),
	[Nuevo_Item]        [Bit]   Default (0),
	[Rubro]             [varchar](50) default '',
	[ClasLibre]         [varchar](50) default '',
	[Marca]             [varchar](50) default '',
	[Zona]              [varchar](50) default '',
	[SuperFamilia]      [varchar](50) default '',
	[Familia]           [varchar](50) default '',
	[SubFamilia]        [varchar](50) default '',
	[Pm]                [float]       Default (0),
	[Uc1]               [float]       Default (0),
	[Uc2]               [float]       Default (0)
 CONSTRAINT [PK_Zw_PsLp#Funcionario#] PRIMARY KEY CLUSTERED 
(
	[IdLista] ASC,
	[Lista] ASC,
	[Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, 
       IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, 
       ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

--INSERT INTO Zw_PsLp#Funcionario# (Lista,Codigo,Descripcion,Rtu,Formula,Redondear,
--                                  Costo,Precio,Margen,Margen_Adicional,
--                                  Costo2,Precio2,Margen2,Margen_Adicional2,
--                                  DsctoMax,Dscto1,Dscto2,Dscto3,Dscto4,Dscto5,Flete)
--#ConsultaSql#                                  

*/