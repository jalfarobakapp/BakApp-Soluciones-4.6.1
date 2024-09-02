DECLARE @Empresa		Char(2)  = '{Empresa}'
DECLARE @CantidadMax	Float = {CantidadMax}	-- <-- ACA PONER LA CANTIDAD DE KILOS	
DECLARE @Lista		Char(3) = '{Lista}'
DECLARE @IDMAEDDO		Int
DECLARE @cantidad		Decimal(10,2)
DECLARE @suma_acumulada Decimal(10,2) = 0
DECLARE @CodigoMadre	Varchar(20) = '{CodMadre}' --< -- ACA VA EL CODIGO DE LA CLASIFICACION DEL PRODUCTO
DECLARE @Descripcion	Varchar(50) = (Select top 1 Descripcion From {Bakapp}Zw_TblArbol_Asociaciones Where Codigo_Madre = @CodigoMadre) --TILAPIA IVP' = 
DECLARE @FechaDesde		Datetime = '{FechaDesde}'
DECLARE @FechaHasta		Datetime = '{FechaHasta}' 


-- Crear una tabla temporal para almacenar los resultados
CREATE TABLE #Paso (
    IDMAEDDO INT,
    suma_acumulada DECIMAL(10,2)
);

-- Declarar el cursor
DECLARE cursor_suma CURSOR FOR
    SELECT IDMAEDDO,
           CASE MAEDDO.UDTRPR WHEN 1 THEN MAEDDO.CAPRCO1 ELSE MAEDDO.CAPRCO2 END AS cantidad
    FROM MAEDDO
	Where TIDO = 'FCV' And KOPRCT In (Select Codigo From {Bakapp}Zw_Prod_Asociacion Where Codigo_Nodo In 
										(
										SELECT Prod.Codigo_Nodo
										FROM {Bakapp}Zw_Prod_Asociacion Prod
										Inner Join {Bakapp}Zw_TblArbol_Asociaciones Asoc On Prod.Codigo_Nodo = Asoc.Codigo_Nodo And Asoc.Es_Seleccionable = 1
										Where Asoc.Codigo_Madre = @CodigoMadre))
										And FEEMLI Between @FechaDesde And @FechaHasta
    ORDER BY PPPRNE Desc;

-- Abrir el cursor                 
OPEN cursor_suma;

-- Recuperar la primera fila
FETCH NEXT FROM cursor_suma INTO @IDMAEDDO, @cantidad;

-- Recorrer las filas del cursor
WHILE @@FETCH_STATUS = 0 AND @suma_acumulada + @cantidad <= @CantidadMax
BEGIN                                             
    -- Actualizar la suma acumulada
    SET @suma_acumulada = @suma_acumulada + @cantidad;
    
    -- Insertar la fila actual en la tabla temporal
    INSERT INTO #Paso (IDMAEDDO, suma_acumulada)
    VALUES (@IDMAEDDO, @suma_acumulada);
    
    -- Pasar a la siguiente fila
    FETCH NEXT FROM cursor_suma INTO @IDMAEDDO, @cantidad;
END;

-- Cerrar y desasignar el cursor
CLOSE cursor_suma;
DEALLOCATE cursor_suma;

-- Seleccionar los resultados de la tabla temporal
--SELECT * FROM #Paso;


SELECT 
              MAEDDO.IDMAEEDO,
              MAEDDO.ENDO,
              MAEDDO.SUENDO,
              MAEEN.NOKOEN,
              ISNULL(MAEDDO.ENDOFI,'') AS ENDOFI,
              ISNULL((SELECT TOP 1 NOKOEN FROM MAEEN WHERE KOEN = MAEDDO.ENDOFI),'') AS NOMENDOFI,
              MAEDDO.TIDO,
              MAEDDO.NUDO,
			  MAEDDO.SULIDO,
			  MAEDDO.BOSULIDO,
              MAEDDO.FEEMLI,
              MAEDDO.KOPRCT,
			  MAEDDO.NOKOPR,
              CASE MAEDDO.UDTRPR WHEN 1 THEN MAEDDO.UD01PR ELSE MAEDDO.UD02PR END AS UN,
              CASE MAEDDO.UDTRPR WHEN 1 THEN MAEDDO.CAPRCO1 ELSE MAEDDO.CAPRCO2 END AS CANTIDAD,
              MAEDDO.VANELI,
              MAEEDO.MODO,
              CASE MAEDDO.UDTRPR WHEN 1 THEN MAEDDO.PPPRNERE1 ELSE MAEDDO.PPPRNERE2 END AS PRECIOUD,
              MAEDDO.UDTRPR,
              ISNULL((SELECT TOP 1 E.NOKOEN FROM MAEEN AS E WHERE E.KOEN=MAEEDO.ENDOFI),'') AS NOKOFI  
Into #Paso2
FROM MAEDDO  WITH ( NOLOCK )  
	INNER JOIN MAEEDO ON MAEEDO.IDMAEEDO=MAEDDO.IDMAEEDO  
       LEFT JOIN MAEEN ON MAEDDO.ENDO=MAEEN.KOEN AND MAEDDO.SUENDO=MAEEN.SUEN  
WHERE 
IDMAEDDO In (Select IDMAEDDO From #Paso)
AND MAEDDO.LILG IN ('SI','GR')  
ORDER BY PRECIOUD --DESC 

/*

Si es Outlet hay que dejar el precio lista, se debe corregir esta acción

Update #Paso2 Set PRECIOUD = PP01UD
From #Paso2 
Inner Join TABPRE On KOLT = @Lista And KOPR = KOPRCT
Where LTRIM(RTRIM(ENDO))+RTRIM(LTRIM(SUENDO))
NOT IN (Select LTRIM(RTRIM(Codigo))+LTRIM(RTRIM(Sucursal)) From {Bakapp}Zw_TblInf_EntExcluidas
Where Funcionario = 'RDF' And Excluida in ('V','A','T'))

Recalcular VANELI para las ventas a Outlet, calculando la cantidad X precio de lista.

*/

Select * From #Paso2

Select @CodigoMadre As 'CodigoMAdre',@Descripcion As 'Descripcion',SUM(CANTIDAD) As CANTIDAD, SUM(VANELI) As VANELI,Round(SUM(VANELI)/SUM(CANTIDAD),0) As 'PPV',
(Select MIN(PRECIOUD) From #Paso2) As 'MINPRECIO',(Select MAX(PRECIOUD) From #Paso2) As 'MAXPRECIO'--,Tp.PP01UD As 'PRECIO_LISTA 01P' 
From #Paso2
Inner Join MAEPR Mp On Mp.KOPR = #Paso2.KOPRCT
Left Join TABPRE Tp On Mp.KOPR = Tp.KOPR And Tp.KOLT = @Lista
--Group By Mp.KOPR,Mp.NOKOPR,Tp.PP01UD

-- Limpiar: eliminar la tabla temporal
DROP TABLE #Paso;
DROP TABLE #Paso2;


