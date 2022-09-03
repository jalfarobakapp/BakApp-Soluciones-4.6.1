Declare @Lista Char(3) = '#Lista#',
        @TipoCosto int = #TipoCosto#,
		@Empresa Char(2) = '#Empresa#'

If @TipoCosto = 0 -- Costo Lista de Precios
Begin		
  SELECT 
    KOPR,
    (SELECT TOP 1 NOKOPR FROM MAEPR WHERE KOPR = Tp.KOPR ) as NOKOPR,
    PP01UD as CostoUd1,
    PP02UD as CostoUd2 
  FROM TABPRE Tp
  WHERE KOLT = @Lista #Filtro_Productos#
End

If @TipoCosto = 1 -- Costo Ultima Compra
Begin		
  Select KOPR,(SELECT TOP 1 NOKOPR FROM MAEPR WHERE KOPR = Tp.KOPR ) as NOKOPR,
  PPUL01 as CostoUd1,PPUL02 as CostoUd2 from MAEPREM Tp
  WHERE EMPRESA = @Empresa #Filtro_Productos#
End

If @TipoCosto = 2 -- Costo PM
Begin		
  Select KOPR,(SELECT TOP 1 NOKOPR FROM MAEPR WHERE KOPR = Mpm.KOPR ) as NOKOPR,
  PM as CostoUd1,
  Isnull((Select Top 1 RLUD From MAEPR Where KOPR = Mpm.KOPR),1) * PM  as CostoUd2 
  from MAEPREM Mpm
  WHERE EMPRESA = @Empresa #Filtro_Productos#
End



