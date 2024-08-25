          
           
Select     CEst.*,           
           Csu.NOKOSU, Cbo.NOKOBO, Cja.NOKOCJ,
           Z1.*
From         dbo.TABBO AS Cbo RIGHT OUTER JOIN
                      dbo.CONFIEST AS CEst WITH (NOLOCK) ON Cbo.EMPRESA = CEst.EMPRESA AND Cbo.KOSU = CEst.ESUCURSAL AND Cbo.KOBO = CEst.EBODEGA LEFT OUTER JOIN
                      dbo.TABCJ AS Cja ON CEst.EMPRESA = Cja.EMPRESA AND CEst.ESUCURSAL = Cja.KOSU AND CEst.ECAJA = Cja.KOCJ LEFT OUTER JOIN
                      dbo.TABSU AS Csu ON CEst.ESUCURSAL = Csu.KOSU AND CEst.EMPRESA = Csu.EMPRESA RIGHT OUTER JOIN
                      #Tbl_Configuracion# AS Z1 ON CEst.MODALIDAD = Z1.Modalidad  

Where Z1.Modalidad = '#Modalidad#' And Z1.Empresa = '#Empresa#'                                          
                      
                     
                     

                      
                      