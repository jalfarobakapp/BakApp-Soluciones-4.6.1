 
 Declare @Idmaeedo Int = '#Idmaeedo#',
         @Endo Varchar(10) = '#Endo#',
         @Suendo Varchar(20) = '#Suendo#',
         @Tido Char(3) = '#Tido#',
         @Nudo Char(10) = '#Nudo#',
         @Fecha_Doc_Origen Date = '#Fecha_Doc_Origen#',
         @Fecha_Eliminacion Date = '#Fecha_Eliminacion#',
         @Funcionario_Doc_Origen Char(3) = '#Funcionario_Doc_Origen#',
         @Funcionario_Eliminador Char(3) = '#Funcionario_Eliminador#',
         @Empresa Char(2) = '#Empresa#',
         @Sucursal char(3) = '#Sucursal#',
         @Neto_Doc_Origen Float = #Neto_Doc_Origen#,
         @Bruto_Doc_Origen Float = #Bruto_Doc_Origen#,
         @HoraGrab Int,
         @Accion as Int = #Accion#
 
 
 INSERT INTO MAEELIMI (EMPRESA,TIDO,NUDO,ENDO,SUENDO,FEEMDO,FEELIDO,KOFUDO,VANEDO,VABRDO) VALUES 
 ( @Empresa,@Tido,@Nudo,@Endo,@Suendo,@Fecha_Doc_Origen,@Fecha_Eliminacion,
 @Funcionario_Doc_Origen,@Neto_Doc_Origen,@Bruto_Doc_Origen) 
 
 INSERT INTO ELIDDO SELECT * FROM MAEDDO WHERE MAEDDO.IDMAEEDO = @Idmaeedo
 INSERT INTO ELIEDO SELECT * FROM MAEEDO WHERE MAEEDO.IDMAEEDO = @Idmaeedo
 DELETE FROM MAEPOSLI WHERE MAEPOSLI.IDMAEDDO IN ( SELECT IDMAEDDO FROM MAEDDO WHERE IDMAEEDO=@Idmaeedo ) 
 DELETE FROM MEVENTO WHERE ARCHIRVE='MAEEDO' AND IDRVE=@Idmaeedo
 DELETE FROM MAEIMLI WHERE IDMAEEDO =@Idmaeedo
 DELETE FROM MAEDTLI WHERE IDMAEEDO=@Idmaeedo
 DELETE FROM MEVENTO  WHERE ARCHIRVE='MAEDDO'  AND IDRVE IN ( SELECT IDMAEDDO FROM MAEDDO WHERE IDMAEEDO=@Idmaeedo ) 
 DELETE FROM MAEDDO WHERE IDMAEEDO=@Idmaeedo
 DELETE FROM MAEVEN WHERE IDMAEEDO=@Idmaeedo
 DELETE FROM MAEEDOOB WHERE IDMAEEDO=@Idmaeedo
 DELETE FROM TABPERMISO WHERE IDRST=@Idmaeedo AND ARCHIRST='MAEEDO' 
 SELECT TOP 1 * FROM MAEDCR WITH ( NOLOCK )  WHERE IDMAEEDO=@Idmaeedo
 DELETE FROM MAEDCR WHERE IDMAEEDO=@Idmaeedo
 DELETE FROM MAEEDO WHERE IDMAEEDO=@Idmaeedo
 
 
  set @HoraGrab = convert(money,substring(convert(varchar(20),getdate(),114),1,2)) * 3600 +  
                     convert(money,substring(convert(varchar(20),getdate(),114),4,2)) * 60 +  
                     convert(money,substring(convert(varchar(20),getdate(),114),7,2))
 
If @Accion = 1  Begin
    INSERT INTO MAEEDO (EMPRESA,TIDO,NUDO,ENDO,SUENDO,ESDO,KOFUDO,SUDO,FEEMDO,ESPGDO,
                         MEARDO,MODO,TIMODO,TAMODO,KOTU,TIGEDO,NUTRANSMI,LIBRO,
                         TIDOELEC,HORAGRAB,LAHORA,KOFUAUDO) 
    VALUES 
                       (@Empresa,@Tido,@Nudo,@Endo,@Suendo,'N',@Funcionario_Doc_Origen,@Sucursal,@Fecha_Doc_Origen,
                        'C','B','$','N',583.92000,'1','I','','',
                        0,@HoraGrab,GETDATE(),@Funcionario_Eliminador)
End