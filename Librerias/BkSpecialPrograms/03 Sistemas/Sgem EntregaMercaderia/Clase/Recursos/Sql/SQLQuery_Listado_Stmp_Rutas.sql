Declare @Empresa as Char(2) = '#Empresa#'
Declare @Sucursal as Char(3) = '#Sucursal#'

Select Enc.*,Edo.FEEMDO,Edo.SUDO,En.NOKOEN,
Case Estado 
When 'PREPA' Then 'Preparación'
When 'COMPL' Then 'Completada'
When 'HABIL' Then 'Habilitada para ser facturada.'
When 'FACTU' Then Case TidoGen When 'FCV' Then 'Facturada' When 'BLV' Then 'Boleteada' When 'GDV' Then 'Guía generada' When 'GDP' Then 'Guía generada' Else '???' End
When 'ENTRE' Then 'Entregado por: '+CodFuncionario_Entrega+' - '+FEnt.NOKOFU
When 'CERRA' Then 'Cerrada'
When 'NULO' Then 'Nula'
End As 'Estado_Str',
Case Estado
When 'FACTU' Then Case TipoPago When 'Contado' Then 'pase por CAJA...' When 'Credito' Then 'pase a DESPACHO EN BODEGA...' End
End As 'InfoCliente',
FechaCreacion As 'HoraCreacion',
CAST('' AS Varchar(200)) AS 'Duracion',
CAST(0 As Int) As 'ItemxDoc',
CAST(0 As Int) As 'CantUd1xDoc',
FechaPickeado As 'HoraPickeado',
FechaPlanificacion As 'HoraPlanificacion',
Cast(CONVERT(DATE, EdoF.LAHORA) As datetime) As 'FechaFactu',
Convert(datetime, (EdoF.HORAGRAB*1.0/3600)/24) As 'HoraFactu',
--EdoF.LAHORA As 'FechaFacturacion',
CAST('' As varchar(300)) As 'Informacion',
Cast(Isnull(FA.ErrorGrabar,0) As bit) As 'Error_FacAuto',Isnull(FA.Informacion,'') As 'Info_FacAuto',
CAST(CONVERT(date, FechaCreacion) AS datetime) AS FechaCreacionSH
Into #Paso
From Zw_Stmp_Enc Enc
Inner Join MAEEDO Edo On Edo.IDMAEEDO = Enc.Idmaeedo
Left Join MAEEN En On En.KOEN = Enc.Endo And En.SUEN = Enc.Suendo
Left Join TABFU FEnt On FEnt.KOFU = CodFuncionario_Entrega
Left Join MAEEDO EdoF on EdoF.IDMAEEDO = Enc.IdmaeedoGen
Left Join Zw_Demonio_FacAuto FA On FA.Idmaeedo_NVV = Enc.Idmaeedo
Where 1 > 0
--#Condicion#
Update #Paso Set ItemxDoc = (Select Count(*) From MAEDDO Ddo Where Ddo.IDMAEEDO = #Paso.Idmaeedo And PRCT = 0)
Update #Paso Set CantUd1xDoc = (Select SUM(CAPRCO1) From MAEDDO Ddo Where Ddo.IDMAEEDO = #Paso.Idmaeedo And PRCT = 0)
Update #Paso Set FechaFactu = DATEADD(HOUR, DATEPART(HOUR, HoraFactu),DATEADD(MINUTE, DATEPART(MINUTE, HoraFactu),DATEADD(SECOND, DATEPART(SECOND, HoraFactu),DATEADD(MILLISECOND, DATEPART(MILLISECOND, HoraFactu), CAST(FechaFactu AS DATETIME)))))
Update #Paso Set Informacion = Estado_Str

Update #Paso Set Duracion = CASE 
    WHEN DATEDIFF(MINUTE, FechaCreacion, GETDATE()) = 0 THEN 'Menos de un minuto'
    ELSE
        -- Si no, construimos la cadena de duración condicionalmente
        CASE 
            WHEN DATEDIFF(DAY, FechaCreacion, GETDATE()) = 0 THEN ''
            WHEN DATEDIFF(HOUR, FechaCreacion, GETDATE()) < 24 THEN ''
            ELSE CAST((DATEDIFF(HOUR, FechaCreacion, GETDATE()) / 24) AS VARCHAR) + ' día(s), '
        END +
        CASE 
            WHEN DATEDIFF(HOUR, FechaCreacion, GETDATE()) % 24 = 0 THEN ''
			WHEN DATEDIFF(MINUTE, FechaCreacion, GETDATE()) < 60 THEN ''
            ELSE CAST(DATEDIFF(HOUR, FechaCreacion, GETDATE()) % 24 AS VARCHAR) + ' hr(s), '
        END +
        CASE 
            WHEN DATEDIFF(MINUTE, FechaCreacion, GETDATE()) % 60 = 0 THEN ''
            ELSE CAST(DATEDIFF(MINUTE, FechaCreacion, GETDATE()) % 60 AS VARCHAR) + ' min.'
        END 
END
Where Estado In ('INGRE')

Update #Paso Set Duracion = CASE 
    WHEN DATEDIFF(MINUTE, Case FechaPlanificacion When NULL then FechaCreacion Else FechaPlanificacion End, GETDATE()) = 0 THEN 'Menos de un minuto'
    ELSE
        -- Si no, construimos la cadena de duración condicionalmente
        CASE 
            WHEN DATEDIFF(DAY, Case FechaPlanificacion When NULL then FechaCreacion Else FechaPlanificacion End, GETDATE()) = 0 THEN ''
            WHEN DATEDIFF(HOUR, Case FechaPlanificacion When NULL then FechaCreacion Else FechaPlanificacion End, GETDATE()) < 24 THEN ''
            ELSE CAST((DATEDIFF(HOUR, Case FechaPlanificacion When NULL then FechaCreacion Else FechaPlanificacion End, GETDATE()) / 24) AS VARCHAR) + ' día(s), '
        END +
        CASE 
            WHEN DATEDIFF(HOUR, Case FechaPlanificacion When NULL then FechaCreacion Else FechaPlanificacion End, GETDATE()) % 24 = 0 THEN ''
			WHEN DATEDIFF(MINUTE, Case FechaPlanificacion When NULL then FechaCreacion Else FechaPlanificacion End, GETDATE()) < 60 THEN ''
            ELSE CAST(DATEDIFF(HOUR, Case FechaPlanificacion When NULL then FechaCreacion Else FechaPlanificacion End, GETDATE()) % 24 AS VARCHAR) + ' hr(s), '
        END +
        CASE 
            WHEN DATEDIFF(MINUTE, Case FechaPlanificacion When NULL then FechaCreacion Else FechaPlanificacion End, GETDATE()) % 60 = 0 THEN ''
            ELSE CAST(DATEDIFF(MINUTE, Case FechaPlanificacion When NULL then FechaCreacion Else FechaPlanificacion End, GETDATE()) % 60 AS VARCHAR) + ' min.'
        END 
END
Where Estado In ('PREPA')

Update #Paso Set Duracion = CASE 
    WHEN DATEDIFF(MINUTE, FechaPickeado, GETDATE()) = 0 THEN 'Menos de un minuto'
    ELSE
        -- Si no, construimos la cadena de duración condicionalmente
        CASE 
            WHEN DATEDIFF(DAY, FechaPickeado, GETDATE()) = 0 THEN ''
            WHEN DATEDIFF(HOUR, FechaPickeado, GETDATE()) < 24 THEN ''
            ELSE CAST((DATEDIFF(HOUR, FechaPickeado, GETDATE()) / 24) AS VARCHAR) + ' día(s), '
        END +
        CASE 
            WHEN DATEDIFF(HOUR, FechaPickeado, GETDATE()) % 24 = 0 THEN ''
			WHEN DATEDIFF(MINUTE, FechaPickeado, GETDATE()) < 60 THEN ''
            ELSE CAST(DATEDIFF(HOUR, FechaPickeado, GETDATE()) % 24 AS VARCHAR) + ' hr(s), '
        END +
        CASE 
            WHEN DATEDIFF(MINUTE, FechaPickeado, GETDATE()) % 60 = 0 THEN ''
            ELSE CAST(DATEDIFF(MINUTE, FechaPickeado, GETDATE()) % 60 AS VARCHAR) + ' min.'
        END 
END
Where Estado In ('COMPL')

Update #Paso Set Duracion = CASE 
    WHEN DATEDIFF(MINUTE, FechaFactu, GETDATE()) = 0 THEN 'Menos de un minuto'
    ELSE
        -- Si no, construimos la cadena de duración condicionalmente
        CASE 
            WHEN DATEDIFF(DAY, FechaFactu, GETDATE()) = 0 THEN ''
            WHEN DATEDIFF(HOUR, FechaFactu, GETDATE()) < 24 THEN ''
            ELSE CAST((DATEDIFF(HOUR, FechaFactu, GETDATE()) / 24) AS VARCHAR) + ' día(s), '
        END +
        CASE 
            WHEN DATEDIFF(HOUR, FechaFactu, GETDATE()) % 24 = 0 THEN ''
			WHEN DATEDIFF(MINUTE, FechaFactu, GETDATE()) < 60 THEN ''
            ELSE CAST(DATEDIFF(HOUR, FechaFactu, GETDATE()) % 24 AS VARCHAR) + ' hr(s), '
        END +
        CASE 
            WHEN DATEDIFF(MINUTE, FechaFactu, GETDATE()) % 60 = 0 THEN ''
            ELSE CAST(DATEDIFF(MINUTE, FechaFactu, GETDATE()) % 60 AS VARCHAR) + ' min.'
        END 
END
Where Estado = 'FACTU'


Update #Paso Set Informacion = Estado_Str+', hace '+Duracion Where Estado In ('INGRE','PREPA','COMPL','FACTU') 

Select * From #Paso Order by Ruta,OrdenRuta

--#Select_Paginacion#

Drop table #Paso