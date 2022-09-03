DECLARE @Lista char(3) = '#Lista#',
        @Entidad Char(13) = '#Entidad#'

INSERT INTO Zw_ListaPreCosto (Lista, Proveedor, CodAlternativo, Codigo, CostoUd1, CostoUd2, Rtu, 
                              FechaVigencia, Desc1, Desc2, Desc3, Desc4, Desc5, Flete)

SELECT 
       @Lista,
       @Entidad,
       ISNULL((SELECT TOP 1 Rtrim(Ltrim(KOPRAL)) FROM TABCODAL WHERE KOEN = @Entidad AND KOPR = Mp.KOPR),''),
       KOPR,
       0,
       0,
       RLUD,
       GETDATE(),0,0,0,0,0,
       Isnull((SELECT Sum(RECARGO) From TABRECPR Where KOEN = @Entidad And KOPR = Mp.KOPR),0)	   

FROM MAEPR Mp 
Where KOPR In (
SELECT Codigo FROM Zw_InfCompras
Where CantComprar > 0 and CodProveedor = @Entidad 
And Codigo Not IN (Select Codigo From Zw_ListaPreCosto Where Proveedor = @Entidad And Lista = @Lista))     
       
       
--FROM MAEPR Mp 
--Where
--KOPR Not In (Select Codigo From Zw_ListaPreCosto Where Proveedor = @Entidad And Lista = @Lista)
--and KOPR in --(Select KOPR From TABCODAL WHERE KOEN = @Entidad)
--(SELECT DISTINCT KOPRCT FROM MAEDDO WHERE (ENDO = @Entidad OR ENDOFI = @Entidad) 
--                                    AND TIDO IN ('FCC','OCC','GRC'))

Update Zw_ListaPreCosto Set 
Flete = Isnull((SELECT Sum(RECARGO) From TABRECPR Where KOEN = @Entidad And KOPR = Codigo),0)