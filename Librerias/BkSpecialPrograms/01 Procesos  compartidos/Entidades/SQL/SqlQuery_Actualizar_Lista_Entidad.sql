
Declare @Lista Char(3),
        @CodEntidad Char(13)

Select @Lista = '#Lista#',@CodEntidad = '#CodEntidad#'

Insert Into Zw_ListaPreCosto (Lista, Proveedor, Sucursal, CodAlternativo, Codigo, Descripcion, Descripcion_Alt, 
                              CostoUd1, CostoUd2, Rtu, FechaVigencia, 
                              Un_Compra, Un_MinCompra)
select @Lista,KOEN,'',KOPRAL,KOPR,NOKOPRAL,NOKOPRAL,
        (Select top 1 Case 
                          When RLUD >= 1 Then PP01UD
                          When RLUD < 1 Then PP02UD
                      End    
         From TABPRE Tp Where Tp.KOPR = Td.KOPR And KOLT = @Lista),
        (Select top 1 Case 
                          When RLUD <= 1 Then PP01UD
                          When RLUD > 1 Then PP02UD
                      End    
         From TABPRE Tp Where Tp.KOPR = Td.KOPR And KOLT = @Lista),
        (Select RLUD From MAEPR Mp Where Mp.KOPR = Td.KOPR ) as 'Rtu', 
        GetDate(),
        Case 
             When (Select RLUD From MAEPR Mp Where Mp.KOPR = Td.KOPR) <= 1 THen (Select UD01PR From MAEPR Mp Where Mp.KOPR = Td.KOPR)
             When (Select RLUD From MAEPR Mp Where Mp.KOPR = Td.KOPR) >  1 THen (Select UD02PR From MAEPR Mp Where Mp.KOPR = Td.KOPR)
             End,
        (Select Case  
                    When RLUD < 1 Then 1
                    Else RLUD End From MAEPR Mp Where Mp.KOPR = Td.KOPR ) as 'Um'  
                FROM TABCODAL Td 
        WHERE 
        KOPRAL NOT IN (Select CodAlternativo From Zw_ListaPreCosto Where Proveedor = @CodEntidad)
        And 
        KOEN = @CodEntidad