
SELECT  Distinct @Top 
     -- Foto.Semilla As 'Semilla', 
		Foto.CodigoPR As 'CodProducto', 
		Foto.CodigoRaPR As 'CodRapido', 
        Foto.CodigoTePR As 'CodTecnico', 
		Foto.DescripcionPR As 'Descripcion', 
		ROUND(Foto.StFisicoUd1, 2) AS 'FStock_Ud1', 
        ISNULL(dbo.ZW_TmpInvPs01@Funcionario.TotalInv,0) AS 'TotalInv', 
		SUM(ISNULL(Zw_PInv.CantidadInventariada, 0)) AS 'CantInventariada', 
        ROUND(Foto.PPP, 3) AS 'PPP', 
		Foto.PUltCompra As 'PUC'
FROM    dbo.ZW_TmpInvProductosInventariados AS Zw_PInv RIGHT OUTER JOIN
        dbo.ZW_TmpInvFotoInventario As Foto ON Zw_PInv.Dia = dbo.ZW_TmpInvFotoInventario.Dia AND 
        Zw_PInv.Mes = Foto.Mes AND 
        Zw_PInv.Ano = Foto.Ano AND 
        Zw_PInv.IdBodega = Foto.IdBodega AND 
        Zw_PInv.Codproducto = Foto.CodigoPR LEFT OUTER JOIN
        dbo.ZW_TmpInvPs01@Funcionario ON Foto.CodigoPR = dbo.ZW_TmpInvPs01@Funcionario.Codproducto
GROUP BY Foto.Semilla, Foto.CodigoRaPR, Foto.CodigoTePR,Foto.DescripcionPR, Foto.StFisicoUd1, Foto.PPP, 
         Foto.PUltCompra, Foto.CodigoPR, Foto.IdBodega,Zw_PInv.SemillaUbicacion, 
         dbo.ZW_TmpInvPs01@Funcionario.TotalInv, Foto.Ano, Foto.Mes,Foto.Dia
HAVING      (Foto.Ano = '@Ano')  AND 
            (Foto.Mes = '@Mes')  AND 
			(Foto.Dia = '@Dia')  AND 
            (Foto.IdBodega = @IdBodega)  AND 
			(Foto.CodigoPR = '@Codigo') AND 
			(Zw_PInv.SemillaUbicacion = @SemillaUbicacion) 
			OR
            (Foto.Ano = '@Ano')  AND 
			(Foto.Mes = '@Mes')  AND 
			(Foto.Dia = '@Dia')  AND 
            (Foto.IdBodega = @IdBodega)  AND 
			(Foto.CodigoPR >= '@Codigo') AND 
            (Zw_PInv.SemillaUbicacion = @SemillaUbicacion)
ORDER BY Foto.CodigoPR					  
					  
