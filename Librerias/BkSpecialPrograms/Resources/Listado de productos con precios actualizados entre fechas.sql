
SELECT top 500 
       Codigo,
       (Select top 1 NOKOPR from MAEPR where KOPR = TB.Codigo ) AS Descripcion,
       Mcosto,
       VproNeto,
       VproBruto,
       MgDigitado,
       ValDigitado,
       FechaModif,
       isnull(convert(varchar, HoraModif, 108) ,'00:00:00') as Hora,
       (SELECT TOP 1 TIDO FROM MAEDDO WHERE IDMAEDDO = 
         (SELECT TOP 1 IDMAEDDO FROM MAEDDO WHERE TIDO = 'GRC' AND KOPRCT = TB.Codigo ORDER BY FEEMLI DESC)) AS 'Tido_UlRc',
       (SELECT TOP 1 NUDO FROM MAEDDO WHERE IDMAEDDO = 
         (SELECT TOP 1 IDMAEDDO FROM MAEDDO WHERE TIDO = 'GRC' AND KOPRCT = TB.Codigo ORDER BY FEEMLI DESC)) as 'Nudo_UlRc',
       (SELECT TOP 1 FEEMLI FROM MAEDDO WHERE IDMAEDDO = 
         (SELECT TOP 1 IDMAEDDO FROM MAEDDO WHERE TIDO = 'GRC' AND KOPRCT = TB.Codigo ORDER BY FEEMLI DESC)) as 'Fecha_UlRc',
       DATEDIFF(d,FechaModif,(SELECT TOP 1 FEEMLI FROM MAEDDO WHERE IDMAEDDO = 
         (SELECT TOP 1 IDMAEDDO FROM MAEDDO WHERE TIDO = 'GRC' AND KOPRCT = TB.Codigo ORDER BY FEEMLI DESC))) * -1 as dias 
FROM Zw_ListaLC_ValPro as TB
WHERE FechaModif BETWEEN '#FechaInicio#' AND '#FechaFin#'