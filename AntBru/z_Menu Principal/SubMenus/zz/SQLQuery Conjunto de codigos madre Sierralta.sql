SELECT      CAST('' As Varchar(30)) As Codigo_Madre, CODMADRE, KOPR,Cast('' As Char) As FM,Cast('' As Char(1)) As Familia,0 as Familias, NOKOPR,
            Cast('' As Varchar(100)) As Descripcion,  
                             (SELECT        COUNT(*) AS Expr1
                               FROM            [@CODMADRE] AS z2
                               WHERE        (z1.CODMADRE = CODMADRE)) AS Hijos
Into Zw_Paso1
FROM            [@CODMADRE] AS z1

Update Zw_Paso1 Set FM = RIGHt(REPLACE(CODMADRE,' ',''),3)
Update Zw_Paso1 Set FM = ''
Where FM not In (select KOCARAC from TABCARAC WHERE KOTABLA = 'CLALIBPR  ' Union  Select 'EUA' Union Select 'KML')

Update Zw_Paso1 Set Codigo_Madre = rtrim(ltrim(REPLACE(CODMADRE,FM,'')))

Select Distinct Codigo_Madre As CM,CODMADRE As CD,Cast(0 As Int) As Familias Into Zw_Paso2 From Zw_Paso1

--Update Zw_Paso1 Set Familia = 'a' Where Familias = 1
Update Zw_Paso2 Set Familias = (Select COUNT(*) From Zw_Paso2 Z2 Where Z2.CM = Z1.CM)
From Zw_Paso2 Z1

Update Zw_Paso1 Set Familias = (Select TOP 1 Familias From Zw_Paso2 Where CM = Codigo_Madre)
Update Zw_Paso1 Set Familia = 1 Where Familias = 1

Update Zw_Paso1 Set Descripcion = rtrim(ltrim(NOKOPR))+' ('+rtrim(rtrim(Codigo_Madre))+')'--+'_Fm_'+rtrim(ltrim(Familia))+')'

CREATE INDEX IDX_Codigo_Madre ON Zw_Paso1 (Codigo_Madre)

Select * From Zw_Paso1 Order by Codigo_Madre

--Drop Table Zw_Paso1
--Drop Table Zw_Paso2

--select * from TABCARAC WHERE KOTABLA = 'CLALIBPR  '


--'0911610116'


   