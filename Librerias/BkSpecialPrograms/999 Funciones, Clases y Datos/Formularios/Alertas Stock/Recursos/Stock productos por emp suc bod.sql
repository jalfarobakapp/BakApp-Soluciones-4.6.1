DECLARE 
@Empresa char(2),
@Codigo char(13)

select @Empresa = '#Empresa#',
       @Codigo = '#Codigo#'


CREATE TABLE [dbo].[#Paso] (
    [Orden]                       [Int]			DEFAULT (0),
    [CodPermiso]                  [Char](10)    DEFAULT '',
    [Empresa]                     [Char](2)     DEFAULT '',
    [Sucursal]                    [Char](3)     DEFAULT '',
	[Bodega]                      [Char](3)     DEFAULT '',
    [EMP_SUC_BOD]                 [Varchar](8)  DEFAULT '',
    [SUC_BOD]                     [Char](6)     DEFAULT '',
    [NOKOBO]                      [Varchar](50) DEFAULT (0),
	[Codigo]                      [VarChar](13) DEFAULT '',
	[ST_FISICO]                   [Float]       DEFAULT (0),
	[ST_DEVENGADO]                [Float]       DEFAULT (0),
	[ST_DESP_SIN_FACTURAR]        [Float]       DEFAULT (0),
	[ST_COMPROMETIDO]             [Float]       DEFAULT (0),
	[ST_COMPROMETIDO_BK]          [Float]       DEFAULT (0), 
	[ST_DISPONIBLE]               [Float]       DEFAULT (0),
	[ST_COMPRAS_NO_RECEPCIONADAS] [Float]       DEFAULT (0),
	[ST_RECEP_SIN_FACTURAR]       [Float]       DEFAULT (0),
	[ST_PEDIDO]                   [Float]       DEFAULT (0),
	[ST_PEDIDO_BK]                [Float]       DEFAULT (0)  
	)

Insert Into #Paso (CodPermiso,Empresa,Sucursal,Bodega,EMP_SUC_BOD,SUC_BOD,NOKOBO,Codigo,ST_FISICO,ST_DEVENGADO,ST_DESP_SIN_FACTURAR,ST_COMPROMETIDO,ST_COMPROMETIDO_BK,ST_DISPONIBLE,
                   ST_COMPRAS_NO_RECEPCIONADAS,ST_RECEP_SIN_FACTURAR,ST_PEDIDO,ST_PEDIDO_BK)
Select 'Bo'+EMPRESA+KOSU+KOBO,EMPRESA,KOSU,KOBO,Ltrim(Rtrim(EMPRESA))+Ltrim(Rtrim(KOSU))+Ltrim(Rtrim(KOBO)),KOSU+KOBO,NOKOBO,@Codigo,0,0,0,0,0,0,0,0,0,0
From TABBO 
Where 1 > 0
And EMPRESA = @Empresa

Update #Paso Set Orden = Isnull((Select Orden From #Global_BaseBk#Zw_TablaDeCaracterizaciones 
						                        		 Where Tabla = '#Tabla#' And CodigoTabla = EMP_SUC_BOD),0)

Update #Paso Set 
			ST_FISICO = Isnull((Select Sum(STFI#Ud#) From MAEST Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR In #Codigos#),0),
			ST_DEVENGADO = Isnull((Select Sum(STDV#Ud#) From MAEST Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR In #Codigos#),0),
			ST_DESP_SIN_FACTURAR = Isnull((Select Sum(DESPNOFAC#Ud#) From MAEST Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR In #Codigos#),0),
			ST_COMPROMETIDO = Isnull((Select Sum(STOCNV#Ud#) From MAEST Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR In #Codigos#),0),
			--ST_DISPONIBLE = Isnull((Select Sum(STFI#Ud#-STOCNV#Ud#) From MAEST Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR In #Codigos#),0),
			ST_COMPRAS_NO_RECEPCIONADAS = Isnull((Select Sum(STDV#Ud#C) From MAEST Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR In #Codigos#),0),
			ST_RECEP_SIN_FACTURAR = Isnull((Select Sum(RECENOFAC#Ud#) From MAEST Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR In #Codigos#),0),
			ST_PEDIDO = Isnull((Select Sum(STOCNV#Ud#C) From MAEST Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR In #Codigos#),0),

            ST_COMPROMETIDO_BK = Isnull((Select Sum(StComp#Ud#) From #Global_BaseBk#Zw_Prod_Stock Stk Where Stk.Empresa = #Paso.Empresa And Stk.Sucursal = #Paso.Sucursal And Stk.Bodega = #Paso.Bodega And Stk.Codigo In #Codigos#),0), --
			ST_PEDIDO_BK = Isnull((Select Sum(StPedi#Ud#) From #Global_BaseBk#Zw_Prod_Stock Stk Where Stk.Empresa = #Paso.Empresa And Stk.Sucursal = #Paso.Sucursal And Stk.Bodega = #Paso.Bodega And Stk.Codigo In #Codigos#),0) --

Update #Paso Set ST_DISPONIBLE = Case When ST_FISICO < 0 Then 0 Else ST_FISICO End -
								 Case When ST_COMPROMETIDO < 0 Then 0 Else ST_COMPROMETIDO End - 
								 Case When ST_COMPROMETIDO_BK < 0 Then 0 Else ST_COMPROMETIDO_BK End

Update #Paso Set ST_DISPONIBLE = 0 Where ST_DISPONIBLE < 0

--#Update_Conficion_Adicional#

Insert Into #Paso (CodPermiso,Empresa,Sucursal,Bodega,SUC_BOD,NOKOBO,Codigo,ST_FISICO,ST_DEVENGADO,ST_DESP_SIN_FACTURAR,ST_COMPROMETIDO,ST_DISPONIBLE,
                   ST_COMPRAS_NO_RECEPCIONADAS,ST_RECEP_SIN_FACTURAR,ST_PEDIDO,ST_COMPROMETIDO_BK,ST_PEDIDO_BK,Orden)
Select 'zzz',
       '10' As EMPRESA,
       '' As KOSU,
       '' As KOBO,
       '' As SUC_BOD,
       'Totales' As NOKOBO,
       '' As KOPR,
       Sum(ST_FISICO) As ST_FISICO, 
       Sum(ST_DEVENGADO) As ST_DEVENGADO, 
       Sum(ST_DESP_SIN_FACTURAR) As ST_DESP_SIN_FACTURAR,
       Sum(ST_COMPROMETIDO) As ST_COMPROMETIDO,
       Sum(ST_DISPONIBLE) As ST_DISPONIBLE,
       Sum(ST_COMPRAS_NO_RECEPCIONADAS) As ST_COMPRAS_NO_RECEPCIONADAS,
       Sum(ST_RECEP_SIN_FACTURAR) As ST_RECEP_SIN_FACTURAR,
       Sum(ST_PEDIDO) As ST_PEDIDO,
       SUM(ST_COMPROMETIDO_BK) As ST_COMPROMETIDO_BK,--
	   SUM(ST_PEDIDO_BK) As ST_PEDIDO_BK,--
       999
From #Paso
Where 1 > 0
#Filtro#
Order By EMPRESA

Select * From #Paso
Where 1 > 0
#Filtro#
Or CodPermiso = 'zzz'
Order by Orden

Drop Table #Paso

/*
       MST.STTR1,
       MST.PRESALCLI1,
       MST.PRESDEPRO1,
       MST.CONSALCLI1,
       MST.CONSDEPRO1,
       MST.DEVENGNCV1,
       MST.DEVENGNCC1,
       MST.DEVSINNCV1,
       MST.DEVSINNCC1,
       MST.STENFAB1,
       MST.STREQFAB1,
*/
