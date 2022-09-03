-- =============================================
-- Autores        : <BakApp,Guido Sepulveda>
-- Fecha Creación : <14-04-2013>
-- Descripcion    :	<Genera Notas de Venta directas en Random>
-- Versión        : 1.0.1
-- =============================================

DECLARE @NumeroTrans char(10)

Set @NumeroTrans = '#NroGDI#'
        
DECLARE        
		@EsAjuste    bit,  -- 1 = Es gruia de ajuste, 0 = No es guia de ajuste
		@Nudo        char(10),
        @Idmaeedo    int,
        @Empresa     char(2),
        @Tido        char(3),
        @Endo        char(13),
        @Suendo      char(3),
        @Sudo        char(3),
        @Feemdo      datetime,
        @Kofudo      char(3),
        @Caprco      float,
        @Vaivdo      float,
        @Vanedo      float,
        @Vabrdo      float,
        @Fe01vedo    datetime,
        @Feulvedo    datetime,
        @Feer        datetime,         -- Fecha esperada de recepcion --
		@Subtido     varchar(10),
		@Marca       varchar(10),
        @Obdo        varchar(250), -- Observacion al documento --
        @Cpdo        varchar(40),  -- Condiciones de pago del documento
        @Diendesp    varchar(50),  -- Dirección entidad de despacho 
        @Texto1      varchar(80),@Texto2 varchar(80),@Texto3 varchar(80),@Texto4 varchar(80),@Texto5 varchar(80),@Texto6 varchar(80),@Texto7 varchar(80),
        @Texto8      varchar(80),@Texto9 varchar(80),@Texto10 varchar(80),@Texto11 varchar(80),@Texto12 varchar(80),@Texto13 varchar(80),@Texto14 varchar(80),
		@Texto15     varchar(80),@Texto16 varchar(80),@Texto17 varchar(80),@Texto18 varchar(80),@Texto19 varchar(80),@Texto20 varchar(80),@Texto21 varchar(80),
		@Texto22     varchar(80),@Texto23 varchar(80),@Texto24 varchar(80),@Texto25 varchar(80),@Texto26 varchar(80),@Texto27 varchar(80),@Texto28 varchar(80),
		@Texto29     varchar(80),@Texto30 varchar(80),@Texto31 varchar(80),@Texto32 varchar(80),
        @Nulido      char(5),      -- Numero de linea 
        @Bosulido    char(3),      -- Bodega de la linea
        @Tipr        Char(3),      -- Tipo de producto 
        @Koprct      char(13),
        @Udtrpr      float,
        @Rludpr      float,
        @Caprco1     float,
        @Ud01pr      char(2),
        @Caprco2     float,
        @Ud02pr      char(2),
        @Koltpr      char(3),
        @Mopppr      char(3),
        @Nudtli      float,
        @Vadtneli    float,
        @Poivli      float,
        @Vaivli      float,
        @Vaneli      float,
        @Vabrli      float,
        @Podtglli    float,
        @Ppprbr      float,
        @Poimglli    float,
        @Vaimli      float,
        @Ppprnere1   float,
        @Ppprnere2   float,
        @Ppprnelt    float,
        @Ppprne      float,
        @Ppprbrlt    float,
        @Pm          float,
        @Nokopr      varchar(50),
        @NvoNumero1  varchar(10),
        @NvoNumero2  varchar(10),
        @lincondesp  bit,
        @HoraGrab    money,
        @nContDt     Int,
        @Podt        float,
        @Vadt        float,
        @Modalidad   char(5),
        @Diasvenci   int,
        @nRegistros  Int, --Almacena la cantidad de registro que retorna la consulta.
        @nWhile      Int  --Almacenará la cantidad de veces que se esta recorriendo en el Bucle.

-- DECLARA TABLA VARIABLE PARA ALMACENAR ENCABEZADO OCC --

DECLARE @Tmp_Maeedo TABLE(
  Id int identity(1,1) not null primary key,
  Modalidad char(5),
  Empresa   char(2),
  Endo      varchar(13),
  Suendo    char(3),
  Sudo      char(3),
  Feemdo    datetime,
  Kofudo    char(3),
  Caprco    float,
  Vaivdo    float,
  Vanedo    float,
  Vabrdo    float,
  Feer      datetime,
  Obdo      varchar(250),
  Cpdo      varchar(40),
  Diendesp  varchar(50),
  Texto1    varchar(80),
  Texto2    varchar(80),
  Texto3    varchar(80),
  Texto4    varchar(80),
  Texto5    varchar(80),
  Texto6    varchar(80),
  Texto7    varchar(80),
  Texto8    varchar(80),
  Texto9    varchar(80),
  Texto10   varchar(80),
  Texto11   varchar(80),
  Texto12   varchar(80),
  Texto13   varchar(80),
  Texto14   varchar(80),
  Texto15   varchar(80),
  Texto16   varchar(80),
  Texto17   varchar(80),
  Texto18   varchar(80),
  Texto19   varchar(80),
  Texto20   varchar(80),
  Texto21   varchar(80),
  Texto22   varchar(80),
  Texto23   varchar(80),
  Texto24   varchar(80),
  Texto25   varchar(80),
  Texto26   varchar(80),
  Texto27   varchar(80),
  Texto28   varchar(80),
  Texto29   varchar(80),
  Texto30   varchar(80),
  Texto31   varchar(80),
  Texto32   varchar(80)
)

-- DECLARA TABLA VARIABLE PARA ALMACENAR DETALLE DE OCC --
DECLARE @Tmp_Maeddo TABLE(
  Id          int identity(1,1) not null primary key,
  Nulido      char( 5),
  Bosulido    char( 3),
  Koprct      char(13),
  Udtrpr      float,
  Caprco1     float,
  Caprco2     float,
  Koltpr      char( 3),
  Nudtli      float,
  Pppnelt     float,
  Ppprne      float,
  Ppprbrlt    float,
  Ppprbr      float,
  Ppprnere1   float,
  Ppprnere2   float,
  Poimglli    float,    
  Vaimli      float,
  Podtglli    float,
  Vadtneli    float,
  Poivli      float,
  Vaivli      float,
  Vaneli      float,
  Vabrli      float,
  Lincondesp  bit
)

-- DECLARA TABLA VARIABLE PARA ALMACENAR DETALLE DE DESCUENTOS --
DECLARE @Tmp_Maedtli TABLE(
  Id int identity(1,1) not null primary key,
  Podt float NULL,
  Vadt float NULL
)

Set @EsAjuste = 1

SELECT @Modalidad='#Modalidad#',
       @Empresa='#Empresa#',
	   @Nudo=''

	   
	   
-- Selecciona el numero de documento que asignara según corresponda
If @Nudo = '' Begin
   SELECT TOP 1 GDI FROM CONFIEST WITH ( NOLOCK )  WHERE EMPRESA=@Empresa AND MODALIDAD=@Modalidad
   -- Colocamos el numero del nuevo documento
   SET @Nudo = (SELECT TOP 1 GDI FROM CONFIEST WITH ( NOLOCK )  WHERE EMPRESA=@Empresa AND MODALIDAD=@Modalidad)
   

    IF @Nudo is not null and rtrim(ltrim(@Nudo)) <> '' and @Nudo <> '0000000000' Begin
         -- Se asigna un nuevo numero para el siguiente documento en la modalidad
         SET @NvoNumero1 = (SELECT dbo.ProxNumero(@Nudo))
         UPDATE CONFIEST SET GDI=@NvoNumero1 WHERE MODALIDAD=@Modalidad AND EMPRESA=@Empresa  
    END

    IF @Nudo is null or rtrim(ltrim(@Nudo)) = '' Begin
      SET @Nudo = (SELECT TOP 1 GDI FROM CONFIEST WITH ( NOLOCK )  WHERE EMPRESA=@Empresa AND MODALIDAD='  ')
    End
  
    If @Nudo = '0000000000' Begin
      Set @Nudo = (SELECT COALESCE(MAX(NUDO),'0000000000') FROM MAEEDO WITH (NOLOCK) Where TIDO = 'GDI')
      Set @Nudo = (SELECT dbo.ProxNumero(@Nudo))
    End
End	
---------------------------------------------------------------------------------------------------------------------------  



     select @Tido = 'GDI'
     select @Diasvenci = 0
     select @HoraGrab = 0
     select @HoraGrab = @HoraGrab + (convert(money,substring(convert(varchar(20),getdate(),114),1,2))  )
     select @HoraGrab = @HoraGrab + (convert(money,substring(convert(varchar(20),getdate(),114),4,2)) / 60 )
     select @HoraGrab = @HoraGrab + (convert(money,substring(convert(varchar(20),getdate(),114),7,2)) / 60 ) / 60
     select @HoraGrab = round(round(@HoraGrab * 60,0)*60 , 0)

     -- TRAE RUT DE LA EMPRESA --
     -- SELECT TOP 1 @Rut = RUT FROM CONFIGP WHERE EMPRESA=@Empresa

     -- BUSCA USUARIO EN TABLA DE USUARIOS --
     --SELECT TOP 1 * FROM TABFU WITH ( NOLOCK ) WHERE KOFU=@Kofu

     -- BUSCA NUMERO DE ORDEN DE COMPRA CORRESPONDIENTE A LA MODALIDAD --
     --SELECT TOP 1 OCC,OCCLSR FROM CONFIEST WITH ( NOLOCK ) WHERE EMPRESA=@Empresa AND MODALIDAD=@Modalidad

     -- NO VERIFICA QUE EL NUMERO DE OCC NO EXISTA EN MAEEDO PORQUE DE EXISTIR
     -- EL SERVIDOR DISPARARA ERROR SIENDO CAPTURADO POR TRY CATCH
     -- SELECT TOP 1 TIDO,NUDO FROM MAEEDO WITH ( NOLOCK ) WHERE EMPRESA=@Empresa AND TIDO='OCC' AND NUDO=@Nudo )

     INSERT INTO @Tmp_Maeedo (Modalidad,Empresa,Endo,Suendo,Sudo,Feemdo,Kofudo,
                              Caprco,Vaivdo,Vanedo,Vabrdo,Feer,Obdo,Cpdo,Diendesp,
                              Texto1,Texto2,Texto3,Texto4,Texto5,Texto6,Texto7,Texto8,Texto9,Texto10,
                              Texto11,Texto12,Texto13,Texto14,Texto15,Texto16,Texto17,Texto18,Texto19,Texto20,
                              Texto21,Texto22,Texto23,Texto24,Texto25,Texto26,Texto27,Texto28,Texto29,Texto30,
                              Texto31,Texto32)
            SELECT TOP 1 MODALIDAD,EMPRESA,ENDO,SUENDO,SUDO,FEEMDO,KOFUDO,
                         CAPRCO,VAIVDO,VANEDO,VABRDO,FEER,OBDO,CPDO,DIENDESP,
                         TEXTO1,TEXTO2,TEXTO3,TEXTO4,TEXTO5,TEXTO6,TEXTO7,TEXTO8,TEXTO9,TEXTO10,
                         TEXTO11,TEXTO12,TEXTO13,TEXTO14,TEXTO15,TEXTO16,TEXTO17,TEXTO18,TEXTO19,TEXTO20,
                         TEXTO21,TEXTO22,TEXTO23,TEXTO24,TEXTO25,TEXTO26,TEXTO27,TEXTO28,TEXTO29,TEXTO30,
                         TEXTO31,TEXTO32
           FROM dbo.x_maeedo WITH ( NOLOCK ) WHERE TIDO=@Tido AND NUDO=@NumeroTrans

     -- TRAE REGISTRO ENCABEZADO --
     SELECT @Endo=(SELECT RUT FROM CONFIGP WHERE EMPRESA=@Empresa),@Suendo='',
            @Sudo=Sudo,
            @Feemdo=Feemdo,
            @Kofudo=Kofudo,
            @Caprco=Caprco,
            @Vaivdo=Vaivdo,
            @Vanedo=Vanedo,
            @Vabrdo=Vabrdo,
            @Feer=Feer,
            @Obdo=Obdo,
            @Cpdo=Cpdo,
            @Diendesp=Diendesp,
            @Texto1=Texto1,@Texto2=Texto2,@Texto3=Texto3,@Texto4=Texto4,@Texto5=Texto5,@Texto6=Texto6,@Texto7=Texto7,@Texto8=Texto8,@Texto9=Texto9,@Texto10=Texto10,
            @Texto11=Texto11,@Texto12=Texto12,@Texto13=Texto13,@Texto14=Texto14,@Texto15=Texto15,@Texto16=Texto16,@Texto17=Texto17,@Texto18=Texto18,@Texto19=Texto19,@Texto20=Texto20,
            @Texto21=Texto21,@Texto22=Texto22,@Texto23=Texto23,@Texto24=Texto24,@Texto25=Texto25,@Texto26=Texto26,@Texto27=Texto27,@Texto28=Texto28,@Texto29=Texto29,@Texto30=Texto30,
            @Texto31=Texto31,@Texto32=Texto32
       FROM @Tmp_Maeedo WHERE Id=1


     -- AGREGA REGISTRO A MAEEDO --     
     INSERT INTO MAEEDO ( EMPRESA,TIDO,NUDO,ENDO,SUENDO )
                 VALUES ( @Empresa,@Tido,@Nudo,@Endo,@Suendo )
     SELECT @Idmaeedo = IDENT_CURRENT('MAEEDO')
     
     

     -- Justifica algunas variables --     
--     SELECT @Endo   = @Endo   + replicate(' ' , 13 - len(@Endo) )
--     SELECT @Suendo = @Suendo + replicate(' ' ,  3 - len(@Suendo) )
--     SELECT @Sudo   = @Sudo   + replicate(' ' ,  3 - len(@Sudo) )
     
     -- Traigo Dias de vencimiento desde MAEEN --
     SELECT TOP 1 @Diasvenci=DIASVENCI FROM MAEEN WITH ( NOLOCK ) WHERE KOEN=@Endo  AND SUEN=@Suendo
     
     -- Se calcula fecha de vencimiento a partir de fecha de emision y dias para el vencimiento --
     /* select @Fe01vedo = CONVERT(VARCHAR(8), DATEADD(day, @Diasvenci, @Feemdo ), 112)*/
     select @Fe01vedo = DATEADD(day, @Diasvenci, @Feemdo )
     
     -- COMIENZA DETALLE --
     
     --Insertamos en la tabla declarada el detalle del documento
       INSERT INTO @Tmp_Maeddo (Nulido,Bosulido,Koprct,Udtrpr,Caprco1,Caprco2,Koltpr,
                              Nudtli,Ppprne,Ppprbrlt,Ppprbr,Ppprnere1,
                              Ppprnere2,Poimglli,Vaimli,Podtglli,Vadtneli,Poivli,Vaivli,Vaneli,Vabrli)
                       SELECT NULIDO,BOSULIDO,KOPRCT,UDTRPR,CAPRCO1,CAPRCO2,KOLTPR,
                              NUDTLI,PPPRNE,PPPRBRLT,PPPRBR,PPPRNERE1,
                              PPPRNERE2,POIMGLLI,VAIMLI,PODTGLLI,VADTNELI,POIVLI,VAIVLI,VANELI,VABRLI
            FROM dbo.x_maeddo WHERE TIDO=@Tido AND NUDO=@NumeroTrans
            
     SET @nRegistros=(SELECT COUNT(*) FROM @Tmp_Maeddo)
     SET @nWhile=1

     --Recorremos la tabla mediante un bucle While.
    WHILE(@nRegistros>0 AND @nWhile<=@nRegistros) BEGIN
     
        --- Agregado para incrementar NULIDO --
           SELECT @Nulido = Replicate('0',5-Len(LTrim(convert(varchar(5),@nWhile))))+
                            LTrim(Convert(char(5),@nWhile))

           SELECT @Bosulido=Bosulido,
                  @Koprct=Koprct,
                  @Udtrpr=Udtrpr,
                  @Caprco1=Caprco1,
                  @Caprco2=Caprco2,
                  @Koltpr=Koltpr,
                  @Nudtli=Nudtli,
                  @Podtglli=Podtglli,
                  @Vadtneli=Vadtneli,
                  @Ppprnelt=Pppnelt,
                  @Ppprne=Ppprne,
                  @Ppprbrlt=Ppprbrlt,
                  @Ppprbr=Ppprbr,
                  @Ppprnere1=Ppprnere1,
                  @Ppprnere2=Ppprnere2,
                  @Poimglli=Poimglli,    
                  @Vaimli=Vaimli,
                  @Poivli=Poivli,
                  @Vaivli=Vaivli,
                  @Vaneli=Vaneli,
                  @Vabrli=Vabrli,
                  @lincondesp=Lincondesp
                  
                  
             FROM @Tmp_Maeddo WHERE Id=@nWhile

       -- Actualiza en MAEPREM stock solicitado para el producto --
             UPDATE MAEPREM SET STFI1 = STFI1 - @Caprco1, STFI2 = STFI2 - @Caprco2 
                    WHERE EMPRESA = @Empresa AND KOPR = @Koprct

       -- Actualiza en MAEPR stock solicitado para el producto --
             UPDATE MAEPR SET STFI1 = STFI1 - @Caprco1, STFI2 = STFI2 - @Caprco2 WHERE KOPR = @Koprct
	   
	   -- Actualiza en MAEPMSUC stock solicitado para el producto --
             UPDATE MAEPMSUC SET STFI1 = STFI1 - @Caprco1, STFI2 = STFI2 - @Caprco2 WHERE KOPR = @Koprct
	 
	   -- Suma stock fisico en ambas unidades --
             UPDATE MAEST SET STFI1 = STFI1 - @Caprco1, STFI2 = STFI2 - @Caprco2
             WHERE EMPRESA=@Empresa AND KOSU=@Sudo AND KOBO=@Bosulido AND KOPR=@Koprct

	
	-- Actialización original de Random, actualiza datos de precios tambien		 
	   /*
	    UPDATE MAEPREM SET 
		       PM = 240.83000,
		       FEPM = {d '2013-06-26'},
			   PMIFRS = 240.83000,
			   FEPMIFRS = {d '2013-06-26'},
			   STFI1 = STFI1 +16.00000,
			   STFI2 = STFI2 +16.00000 
			   WHERE EMPRESA = '01' AND KOPR = '100111       '
        
		UPDATE MAEPR SET 
		       PM = 240.83000,
		       FEPM = {d '2013-06-26'},
			   PMIFRS = 240.83000,
			   FEPMIFRS = {d '2013-06-26'},
			   STFI1 = STFI1 + 16.00000,
			   STFI2 = STFI2 + 16.00000 
			   WHERE KOPR = '100111       '
	   */
       -- Busca producto de la empresa, sucursal y bodega en MAEST --
            
             if not exists( SELECT TOP 1 KOSU FROM MAEST WITH ( NOLOCK )
                      WHERE EMPRESA=@Empresa AND KOSU=@Sudo AND KOBO=@Bosulido AND KOPR=@Koprct ) begin
                -- Si no existe producto de la empresa, sucursal, bodega en MAEST lo agrega --
                INSERT INTO MAEST ( EMPRESA, KOSU , KOBO , KOPR)
                VALUES ( @Empresa, @Sudo, @Bosulido,@Koprct)
             end

       -- Agrega linea de detalle en MAEDDO --
             SELECT @Pm=PM FROM MAEPREM WHERE KOPR=@Koprct and EMPRESA=@Empresa

             SELECT @Tipr=TIPR, @Nokopr=NOKOPR, @Rludpr=RLUD, @Ud01pr=UD01PR,@Ud02pr=UD02PR
             FROM MAEPR WHERE KOPR=@Koprct

             --SELECT @Ppprnere1=PP01UD, @Ppprnere2=PP02UD FROM TABPRE WHERE KOLT=@Koltpr AND KOPR=@Koprct
             /* 
			  if @Ud01pr = @Ud02pr begin
               select @Ppprnere2 = @Ppprnere1
              end

              if @Udtrpr=1 begin
                SELECT @Ppprnelt = @Ppprnere1
                SELECT @Ppprne   = @Ppprnere1
              end 
			  else begin
                SELECT @Ppprnelt = @Ppprnere2
                SELECT @Ppprne   = @Ppprnere2
              end
              */
	   SELECT @Ppprbrlt = @Ppprne * (@Poivli / 100 + 1)
       
    INSERT INTO MAEDDO (IDMAEEDO,ARCHIRST,IDRST,EMPRESA,TIDO,NUDO,ENDO,SUENDO,LILG,NULIDO,SULIDO,BOSULIDO,
                          KOFULIDO,TIPR,KOPRCT,UDTRPR,RLUDPR,CAPRCO1,CAPRAD1,UD01PR,CAPRCO2,CAPRAD2,UD02PR,KOLTPR,MOPPPR,
                          TIMOPPPR,TAMOPPPR,NUDTLI,PODTGLLI,POIMGLLI,VAIMLI,VADTNELI,POIVLI,VAIVLI,VANELI,VABRLI,
                          TIGELI,FEEMLI,FEERLI,PPPRNELT,PPPRNE,PPPRBRLT,PPPRBR,PPPRPM,PPPRNERE1,PPPRNERE2,CAFACO,
                          FVENLOTE,FCRELOTE,NOKOPR,TASADORIG,CUOGASDIF,LINCONDESP,ESLIDO)
                  VALUES (@Idmaeedo,'',0,@Empresa,@Tido,@Nudo,@Endo,@Suendo,'SI',@Nulido,@Sudo,@Bosulido,@Kofudo,
                          @Tipr,@Koprct,@Udtrpr,@Rludpr,@Caprco1,@Caprco1,@Ud01pr,@Caprco2,@Caprco2,@Ud02pr,'TABPP'+@Koltpr,'$','N',
                          1.00000,@Nudtli,@Podtglli,@Poimglli,@Vaimli,@Vadtneli,@Poivli,@Vaivli,@Vaneli,@Vabrli,'I',@Feemdo,
                          @Feer,@Ppprnelt,@Ppprne,@Ppprbrlt,@Ppprbrlt,@Pm,@Ppprnere1,@Ppprnere2,@Caprco1,NULL,NULL,
                          @Nokopr,1.00000,0,1,'C')

                  
                  

            if @Nudtli > 0 begin
                DELETE FROM @Tmp_Maedtli
                --Insertamos en la tabla variable los registros almacenados en x_maedtli --
                INSERT INTO @Tmp_Maedtli(Podt, Vadt)
                     SELECT PODT, VADT FROM dbo.x_maedtli 
                     WHERE TIDO=@Tido AND NUDO=@Nudo AND NULIDO=@Nulido

                SET @Podt=0
                SET @Vadt=0        
                SET @nContDt=1
          
		      while(@nContDt<=@Nudtli) begin
                SELECT @Podt=Podt, @Vadt=Vadt FROM @Tmp_Maedtli WHERE Id=@nContDt  
                INSERT INTO MAEDTLI (IDMAEEDO,NULIDO,KODT,PODT,VADT) 
                         VALUES (@Idmaeedo,@Nulido,'D_SIN_TIPO',@Podt,@Vadt)
                set @nContDt=@nContDt + 1
              end
            end
       SET @nWhile=@nWhile+1
    
	End -- Fin del @nWhile
    
	
	        If @EsAjuste = 1 Begin 
	            Set @Subtido = 'AJU'
                Set @Marca = 'I'
			End 	
            Else Begin				
			    Set @Subtido = ''
                Set @Marca = ''	         
	        End 
	
	        UPDATE MAEEDO SET 
			                  SUENDO=@Suendo,TIGEDO='I',SUDO=@Sudo,FEEMDO=@Feemdo,KOFUDO=@Kofudo,
                              ESPGDO='S',CAPRCO=@Caprco,CAPRAD=@Caprco,MEARDO='N',MODO='$',TIMODO='N',
                              TAMODO=1.00000,VAIVDO=@Vaivdo,VANEDO=@Vanedo,VABRDO=@Vabrdo,
                              FE01VEDO=@Fe01vedo,FEULVEDO=@Fe01vedo,NUVEDO=1.00000,FEER=@Feer,
                              KOTU='1',LCLV=NULL,LAHORA=GETDATE(),DESPACHO=1,HORAGRAB=@HoraGrab,
                              FECHATRIB=NULL,NUMOPERVEN=0,FLIQUIFCV=@Feemdo,SUBTIDO=@Subtido,MARCA=@Marca,
                              ESDO='C'
            WHERE IDMAEEDO=@Idmaeedo
	
	
	
	if LEN(LTRIM(RTRIM(@Obdo))) > 0 or
       LEN(LTRIM(RTRIM(@Cpdo))) > 0 or  -- Condiciones de pago --
       LEN(LTRIM(RTRIM(@Diendesp))) > 0 or  -- Dirección entidad de despacho --
       LEN(LTRIM(RTRIM(@Texto1))) > 0 or
       LEN(LTRIM(RTRIM(@Texto2))) > 0 or
       LEN(LTRIM(RTRIM(@Texto3))) > 0 or
       LEN(LTRIM(RTRIM(@Texto4))) > 0 or
       LEN(LTRIM(RTRIM(@Texto5))) > 0 or
       LEN(LTRIM(RTRIM(@Texto6))) > 0 or
       LEN(LTRIM(RTRIM(@Texto7))) > 0 or
       LEN(LTRIM(RTRIM(@Texto8))) > 0 or
       LEN(LTRIM(RTRIM(@Texto9))) > 0 or
       LEN(LTRIM(RTRIM(@Texto10))) > 0 or
       LEN(LTRIM(RTRIM(@Texto11))) > 0 or
       LEN(LTRIM(RTRIM(@Texto12))) > 0 or
       LEN(LTRIM(RTRIM(@Texto13))) > 0 or
       LEN(LTRIM(RTRIM(@Texto14))) > 0 or
       LEN(LTRIM(RTRIM(@Texto15))) > 0 or
       LEN(LTRIM(RTRIM(@Texto16))) > 0 or
       LEN(LTRIM(RTRIM(@Texto17))) > 0 or
       LEN(LTRIM(RTRIM(@Texto18))) > 0 or
       LEN(LTRIM(RTRIM(@Texto19))) > 0 or
       LEN(LTRIM(RTRIM(@Texto20))) > 0 or
       LEN(LTRIM(RTRIM(@Texto21))) > 0 or
       LEN(LTRIM(RTRIM(@Texto22))) > 0 or
       LEN(LTRIM(RTRIM(@Texto23))) > 0 or
       LEN(LTRIM(RTRIM(@Texto24))) > 0 or
       LEN(LTRIM(RTRIM(@Texto25))) > 0 or
       LEN(LTRIM(RTRIM(@Texto26))) > 0 or
       LEN(LTRIM(RTRIM(@Texto27))) > 0 or
       LEN(LTRIM(RTRIM(@Texto28))) > 0 or
       LEN(LTRIM(RTRIM(@Texto29))) > 0 or
       LEN(LTRIM(RTRIM(@Texto30))) > 0 or
       LEN(LTRIM(RTRIM(@Texto31))) > 0 or
       LEN(LTRIM(RTRIM(@Texto32))) > 0
    begin
    
      -- AGREGA OBSERVACION GENERAL --
      INSERT INTO MAEEDOOB ( IDMAEEDO,OBDO,OCDO,CPDO,DIENDESP,MOTIVO,
                             TEXTO1 ,TEXTO2 ,TEXTO3 ,TEXTO4 ,TEXTO5 ,TEXTO6 ,TEXTO7 ,TEXTO8 ,TEXTO9 ,TEXTO10,
                             TEXTO11,TEXTO12,TEXTO13,TEXTO14,TEXTO15,TEXTO16,TEXTO17,TEXTO18,TEXTO19,TEXTO20,
                             TEXTO21,TEXTO22,TEXTO23,TEXTO24,TEXTO25,TEXTO26,TEXTO27,TEXTO28,TEXTO29,TEXTO30,
                             TEXTO31,TEXTO32,
                             CARRIER,BOOKING,LADING,AGENTE,MEDIOPAGO,TIPOTRANS,KOPAE,KOCIE,KOCME,FECHAE,HORAE,
                             KOPAD,KOCID,KOCMD,FECHAD,HORAD,OBDOEXPO,PLACAPAT)
                    VALUES ( @Idmaeedo,@Obdo,'',@Cpdo,@Diendesp,' ',
                             @Texto1,@Texto2,@Texto3,@Texto4,@Texto5,@Texto6,@Texto7,@Texto8,@Texto9,@Texto10,
                             @Texto11,@Texto12,@Texto13,@Texto14,@Texto15,@Texto16,@Texto17,@Texto18,@Texto19,@Texto20,
                             @Texto21,@Texto22,@Texto23,@Texto24,@Texto25,@Texto26,@Texto27,@Texto28,@Texto29,@Texto30,
                             @Texto31,@Texto32,
                             '','','','','','','','','',NULL,'',
                             '','','',NULL,'','','')
    end

                 DELETE x_maeedo where TIDO = 'GDI' and NUDO = @NumeroTrans 
                 DELETE x_maeddo where TIDO = 'GDI' and NUDO = @NumeroTrans 




/*
-- Estructura de tabla paso x_maeedo --
CREATE TABLE [dbo].[x_maeedo] (
[IDMAEEDO]  int IDENTITY(1, 1) NOT NULL,
[MODALIDAD] char(5)  NOT NULL,  -- Codigo de la modalidad
[EMPRESA]   char(2)  NOT NULL,  -- Codigo de la empresa
[TIDO]      char(3)  NOT NULL,  -- Tipo de documento
[NUDO]      char(10) NOT NULL,  -- Numero del documento
[ENDO]      char(13) NOT NULL,  -- Entidad del documento
[SUENDO]    char(10) NOT NULL,  -- Sucursal de la entidad del documento
[SUDO]      char(3)  NOT NULL,  -- Sucursal documento 
[FEEMDO]    datetime NOT NULL,  -- Fecha Emision documento
[KOFUDO]    char(3)  NOT NULL,  -- codigo funcionario
[CAPRCO]    float    NOT NULL,  -- Cantidad de productos
[VAIVDO]    float    NOT NULL,  -- Valor iva documento
[VANEDO]    float    NOT NULL,  -- Valor neto documento
[VABRDO]    float    NOT NULL,  -- Valor Bruto documento
[FEER]      datetime NULL,      -- Fecha esperada de recepcion 
[OBDO]      varchar(250) DEFAULT '',
[CPDO]      varchar(40) NULL,
[DIENDESP]  varchar(50) NULL,
[TEXTO1]    varchar(80) NULL,
[TEXTO2]    varchar(80) NULL,
[TEXTO3]    varchar(80) NULL,
[TEXTO4]    varchar(80) NULL,
[TEXTO5]    varchar(80) NULL,
[TEXTO6]    varchar(80) NULL,
[TEXTO7]    varchar(80) NULL,
[TEXTO8]    varchar(80) NULL,
[TEXTO9]    varchar(80) NULL,
[TEXTO10]   varchar(80) NULL,
[TEXTO11]   varchar(80) NULL,
[TEXTO12]   varchar(80) NULL,
[TEXTO13]   varchar(80) NULL,
[TEXTO14]   varchar(80) NULL,
[TEXTO15]   varchar(80) NULL,
[TEXTO16]   varchar(80) NULL,
[TEXTO17]   varchar(80) NULL,
[TEXTO18]   varchar(80) NULL,
[TEXTO19]   varchar(80) NULL,
[TEXTO20]   varchar(80) NULL,
[TEXTO21]   varchar(80) NULL,
[TEXTO22]   varchar(80) NULL,
[TEXTO23]   varchar(80) NULL,
[TEXTO24]   varchar(80) NULL,
[TEXTO25]   varchar(80) NULL,
[TEXTO26]   varchar(80) NULL,
[TEXTO27]   varchar(80) NULL,
[TEXTO28]   varchar(80) NULL,
[TEXTO29]   varchar(80) NULL,
[TEXTO30]   varchar(80) NULL,
[TEXTO31]   varchar(80) NULL,
[TEXTO32]   varchar(80) NULL)
ON [PRIMARY];

-- Estructura de tabla paso x_maeddo --
CREATE TABLE [dbo].[x_maeddo] (
[IDMAEDDO]  int IDENTITY(1, 1) NOT NULL,
[TIDO]      char( 3) NOT NULL,   -- Tipo de documento
[NUDO]      char(10) NOT NULL,   -- Numero del documento
[NULIDO]    char( 5) NOT NULL,   -- Numero de linea del documento
[BOSULIDO]  char( 3) NOT NULL,   -- Bodega sucursal linea
[KOPRCT]    char(13) NOT NULL,   -- Codigo del producto
[UDTRPR]    float    NULL,       -- Unidad utilizada en documento
[CAPRCO1]   float    NULL,       -- Cantidad primera unidad
[CAPRCO2]   float    NULL,       -- Cantidad segunda unidad
[KOLTPR]    char( 3) NULL,       -- Codigo lista de precios
[NUDTLI]    float    NULL,       -- Numero de descuentos de la linea
[PODTGLLI]  float    NULL,       -- % Descuento de la linea
[PPPRNELT]  float    NULL,
[PPPRNE]    float    NULL,
[PPPRBRLT]  float    NULL,
[PPPRBR]    float    NULL,
[PPPRNERE1] float    NULL,
[PPPRNERE2] float    NULL,
[POIMGLLI]  float    NULL,
[VAIMLI]    float    NULL,
[VADTNELI]  float    NULL,       -- Valor descuento de la linea
[POIVLI]    float    NULL,       -- % Iva
[VAIVLI]    float    NULL,       -- Valor de Iva
[VANELI]    float    NULL,       -- Valor neto de la linea
[VABRLI]    float    NULL,      -- Valor Bruto de la linea
[LINCONDESP Bit      DEFAULT (0))      -- Valor Bruto de la linea
ON [PRIMARY];

-- Estructura de tabla de paso x_maedtli --
CREATE TABLE [dbo].[x_maedtli] (
[IDMAEDTLI] int IDENTITY(1, 1) NOT NULL,
[TIDO] char(3)   NOT NULL,      -- Tipo de documento
[NUDO] char(10)  NOT NULL,      -- Numero del documento
[NULIDO] char(5) NOT NULL,      -- Numero de linea del documento
[PODT] float     NOT NULL,      -- % de descuento
[VADT] float     NOT NULL)      -- Valor descuento
ON [PRIMARY];





CON ESTO SE PUEDEN TRAER DATOS DE UN DOCUMENTO DE RANDOM HACIA LAS TABLAS X_MAEEDO


INSERT INTO x_maeddo (TIDO, NUDO, NULIDO, BOSULIDO, KOPRCT, UDTRPR, CAPRCO1, CAPRCO2, KOLTPR, NUDTLI, 
             PPPRNELT, PPPRNE, PPPRBRLT, PPPRBR,PPPRNERE1, PPPRNERE2, POIMGLLI, VAIMLI, 
             PODTGLLI, VADTNELI, POIVLI, VAIVLI, VANELI, VABRLI, LINCONDESP)

SELECT TIDO, NUDO, NULIDO, BOSULIDO, KOPRCT, UDTRPR, CAPRCO1, CAPRCO2, SUBSTRING(KOLTPR,6,3), NUDTLI, PPPRNELT, PPPRNE, PPPRBRLT, PPPRBR, 
            PPPRNERE1, PPPRNERE2, POIMGLLI, VAIMLI, PODTGLLI, VADTNELI, POIVLI, VAIVLI, VANELI, VABRLI, LINCONDESP 
FROM MAEDDO 
WHERE TIDO = 'GDI' AND NUDO = 'INV0000082'


INSERT INTO x_maeedo (MODALIDAD,EMPRESA, TIDO, NUDO, ENDO, SUENDO, SUDO, FEEMDO, KOFUDO, CAPRCO, 
                      VAIVDO, VANEDO, VABRDO, FEER)
SELECT  'VTAEM',EMPRESA, TIDO, NUDO, ENDO, SUENDO, SUDO, FEEMDO, KOFUDO, CAPRCO, VAIVDO, VANEDO, VABRDO, FEER
FROM MAEEDO 
WHERE TIDO = 'GDI' AND NUDO = 'INV0000082'













*/