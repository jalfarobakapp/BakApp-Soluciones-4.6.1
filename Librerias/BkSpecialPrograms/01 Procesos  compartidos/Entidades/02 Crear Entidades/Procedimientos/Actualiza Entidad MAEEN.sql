

Declare
@koen char(13),
@tien char(1),
@rten char(13),
@suen char(10),
@tiposuc char(1),
@nokoen varchar(50),
@sien char(15),
@gien varchar(100),
@paen char(3),
@cien char(3),
@cmen char(3),
@dien varchar(50),
@zoen char(3),
@foen varchar(20),
@faen varchar(20),
@cnen varchar(30),
@kofuen char(3),
@lcen char(8),
@lven char(8),
@crsd float,
@crch float,
@crlt float,
@crpa float,
@crto float,
@cren char(10),
@fevecren datetime,
@feultr datetime,
@nuvecr float,
@dccr float,
@incr float,
@popicr float,
@koplcr char(3),
@contab char(8),
@subauxi char(13),
@contabvta char(8),
@subauxivta char(13),
@codcc char(2),
@nutransmi char(13),
@ruen char(3),
@cpen varchar(40),
@oben varchar(100),
@diprve float,
@email varchar(50),
@cnen2 varchar(30),
@cobrador char(3),
@proteacum float,
@protevige float,
@cpostal varchar(25),
@habilita bit,
@codconve char(13),
@notraedeud bit,
@nokoenamp varchar(100),
@bloqueado bit,
@dimoper float,
@prefen bit,
@bloqencom bit,
@tipoen char(10),
@actien char(10),
@tamaen char(10),
@porprefen float,
@claveen char(10),
@nvvpidepie bit,
@recepelect bit,
@acteco char(10),
@diasvenci int,
@cattrib char(3),
@agretiva bit,
@agretiibb bit,
@agretgan bit,
@agperiva bit,
@agperiibb bit,
@transpoen char(10),
@fecreen datetime,
@firma varchar(25),
@moctaen char(3),
@ctasdelaen varchar(96),
@nacionen varchar(25),
@dirparen varchar(50),
@fecnacen datetime,
@estciven char(1),
@profecen varchar(25),
@conyugen varchar(50),
@rutconen varchar(10),
@rutsocen varchar(10),
@sexoen char(1),
@relacien char(1),
@anexen1 varchar(50),
@anexen2 varchar(50),
@anexen3 varchar(50),
@anexen4 varchar(50),
@occobli bit,
@valivenpag bit,
@emailcomer varchar(50),
@tipocontr char(1),
@ferefauto bit,
@diacobra char(7),
@cuentabco char(20),
@koendpen char(13),
@suendpen char(3),
@rutalun int,
@rutamar int,
@rutamie int,
@rutajue int,
@rutavie int,
@rutasab int,
@rutadom int,
@catlegret char(10),
@imptoret float,
@entiliga char(13),
@porceliga float,
@actecobco char(10)


Set @koen='#KOEN#'               -- char
Set @tien='#TIEN#'               -- char
Set @rten='#RTEN#'               -- char
Set @suen='#SUEN#'               -- char
Set @tiposuc='#TIPOSUC#'         -- char
Set @nokoen='#NOKOEN#'           -- varchar
Set @sien='#SIEN#'               -- char
Set @gien='#GIEN#'               -- varchar
Set @paen='#PAEN#' 		         -- char
Set @cien='#CIEN#' 		         -- char
Set @cmen='#CMEN#'               -- char
Set @dien='#DIEN#'               -- varchar
Set @zoen='#ZOEN#'               -- char
Set @foen='#FOEN#'               -- varchar
Set @faen='#FAEN#'               -- varchar
Set @cnen=''                     -- varchar
Set @kofuen='#KOFUEN#'           -- char
Set @lcen='#LCEN#'               -- char
Set @lven='#LVEN#'               -- char
Set @crsd=#CRSD#                 -- float
Set @crch=#CRCH#                 -- float
Set @crlt=#CRLT#                 -- float
Set @crpa=#CRPA#                 -- float
Set @crto=#CRTO#                 -- float
Set @cren=''                     -- char
Set @fevecren='#FEVECREN#'       -- datetime
Set @feultr='#FEULTR#'           -- datetime
Set @nuvecr=#NUVECR#             -- float
Set @dccr=0                      -- float
Set @incr=0                      -- float
Set @popicr=#POPICR#             -- float PORCENTAJE DE ANTICIPO
Set @koplcr=''                   -- char
Set @contab=''                   -- char
Set @subauxi=''                  -- char
Set @contabvta=''                -- char
Set @subauxivta=''               -- char
Set @codcc=''                    -- char
Set @nutransmi=''                -- char
Set @ruen='#RUEN#'               -- char RUBRO
Set @cpen='#CPEN#'               -- varchar
Set @oben='#OBEN#'               -- varchar
Set @diprve=#DIPRVE#             -- float DIAS PRIMER VENCIMIENTO
Set @email='#EMAIL#'             -- varchar
Set @cnen2=''                    -- varchar
Set @cobrador='#COBRADOR#'       -- char
Set @proteacum=0                 -- float
Set @protevige=0                 -- float
Set @cpostal='#CPOSTAL#'         -- varchar
Set @habilita=0                  -- bit
Set @codconve=''                 -- char
Set @notraedeud=#NOTRAEDEUD#     -- bit  No afecta revision de cta cte.
Set @nokoenamp='#NOKOENAMP#'     -- varchar
Set @bloqueado=#BLOQUEADO#       -- bit
Set @dimoper=#DIMOPER#           -- float
Set @prefen= #PREFEN#            -- bit     Entidada preferecnial
Set @bloqencom=#BLOQENCOM#       -- bit
Set @tipoen='#TIPOEN#'           -- char TIPO DE ENTIDAD
Set @actien='#ACTIEN#'           -- char ACTIVIDAD ECONOMICA
Set @tamaen='#TAMAEN#'           -- char TAMAÑO EMPRESA
Set @porprefen= 0                -- float
Set @claveen=''                  -- char
Set @nvvpidepie= #NVVPIDEPIE#    -- bit
Set @recepelect= #RECEPELECT#    -- bit
Set @acteco=''                   -- char
Set @diasvenci=#DIASVENCI#       -- int
Set @cattrib='RSI'               -- char
Set @agretiva= 0                 -- bit
Set @agretiibb= 0                -- bit
Set @agretgan= 0                 -- bit
Set @agperiva= 0                 -- bit
Set @agperiibb= 0                -- bit
Set @transpoen='#TRANSPOEN#'     -- char TRANSPORTISTA
Set @fecreen='#FECREEN#'         -- datetime
Set @firma=''                    -- varchar
Set @moctaen='#MOCTAEN#'         -- char
Set @ctasdelaen=''               -- varchar
Set @nacionen='#NACIONEN#'       -- varchar
Set @dirparen='#DIRPAREN#'       -- varchar
Set @fecnacen='#FECNACEN#'       -- datetime
Set @estciven='#ESTCIVEN#'       -- char
Set @profecen='#PROFECEN#'       -- varchar
Set @conyugen='#CONYUGEN#'       -- varchar
Set @rutconen='#RUTCONEN#'       -- varchar
Set @rutsocen='#RUTSOCEN#'       -- varchar
Set @sexoen='#SEXOEN#'           -- char
Set @relacien='#RELACIEN#'       -- char
Set @anexen1='#ANEXEN1#'         -- varchar
Set @anexen2='#ANEXEN2#'         -- varchar
Set @anexen3='#ANEXEN3#'         -- varchar
Set @anexen4=''                  -- varchar
Set @occobli= #OCCOBLI#          -- bit        Entidad requiere orden de comrpra
Set @valivenpag= 0               -- bit
Set @emailcomer='#EMAILCOMER#'   -- varchar
Set @tipocontr=''                -- char
Set @ferefauto= #FEREFAUTO#      -- bit        Documentos electrónicos de venta automáticamente generan información de referencia en XML
Set @diacobra='#DIACOBRA#'       -- char
Set @cuentabco='#CUENTABCO#'     -- char       Nro Cta Cte (Cuenta para depositos)
Set @koendpen='#KOENDPEN#'       -- char       Código del banco (Cuenta para depositos)
Set @suendpen='#SUENDPEN#'       --  =         Plaza o sucursal bancaria (Cuenta para depositos)
Set @rutalun=#RUTALUN#           -- int
Set @rutamar=#RUTAMAR#           -- int
Set @rutamie=#RUTAMIE#           -- int
Set @rutajue=#RUTAJUE#           -- int
Set @rutavie=#RUTAVIE#           -- int
Set @rutasab=#RUTASAB#           -- int
Set @rutadom=#RUTADOM#           -- int
Set @catlegret=''                -- char
Set @imptoret=0                  -- float
Set @entiliga=''                 -- char
Set @porceliga=0                 -- float
Set @actecobco='#ACTECOBCO#'     --  Código de actividad economica   char (Cuenta para depositos)


-- 
--
--

UPDATE MAEEN SET 
KOEN=@koen, -- Cod. entidad
TIEN=@tien, -- Tipo entidad
RTEN=@rten, -- Rut Entidad
SUEN=@suen, -- Sucursal
TIPOSUC=@tiposuc, -- Tipo E,S
NOKOEN=@nokoen, -- Razón Social
SIEN=@sien, -- Sigla Entidad
GIEN=@gien, -- Giro 
PAEN=@paen, -- Pais 
CIEN=@cien, -- Ciudad
CMEN=@cmen, -- Comuna
DIEN=@dien, -- Dirección
ZOEN=@zoen, -- Zona
FOEN=@foen, -- Telefono
FAEN=@faen, -- Fax
CNEN=@cnen, -- ??
KOFUEN=@kofuen, -- Vendedor asignado
LCEN=@lcen, -- Lista precio
LVEN=@lven, -- Lista Costo
CRSD=@crsd, -- Credito sin documentar
CRCH=@crch, -- Credito Cheque
CRLT=@crlt, -- Credito Letra
CRPA=@crpa, -- Credito Pagare
CRTO=@crto, -- Credito Total
CREN=@cren, -- ??
FEVECREN=@fevecren, -- Fecha creación
FEULTR=@feultr,       
NUVECR=@nuvecr, -- Numero maximo de vencimientos
DCCR=@dccr,
INCR=@incr,
POPICR=@popicr,
KOPLCR=@koplcr,
--CONTAB=@contab,
--SUBAUXI=@subauxi,
--CONTABVTA=@contabvta,
--SUBAUXIVTA=@subauxivta,
CODCC=@codcc,
NUTRANSMI=@nutransmi,
RUEN=@ruen, -- Rubro 
CPEN=@cpen, -- Observaciones sobre condición de pago
OBEN=@oben, -- Observaciones
DIPRVE=@diprve, -- Dias primer vencimiento
EMAIL=@email,
CNEN2=@cnen2,
COBRADOR=@cobrador,
PROTEACUM=@proteacum,
PROTEVIGE=@protevige,
CPOSTAL=@cpostal, -- Coigo postal
HABILITA=@habilita, -- False
CODCONVE=@codconve,
NOTRAEDEUD=@notraedeud,
NOKOENAMP=@nokoenamp, -- Razón social ampliada
BLOQUEADO=@bloqueado,
DIMOPER=@dimoper, -- Dias morosidad permitida
PREFEN=@prefen,
BLOQENCOM=@bloqencom,
TIPOEN=@tipoen,
ACTIEN=@actien,
TAMAEN=@tamaen,
PORPREFEN=@porprefen,
CLAVEEN=@claveen,
NVVPIDEPIE=@nvvpidepie,
RECEPELECT=@recepelect,
ACTECO=@acteco,
DIASVENCI=@diasvenci, -- Dias entre vencimientos
CATTRIB=@cattrib,
AGRETIVA=@agretiva,
AGRETIIBB=@agretiibb,
AGRETGAN=@agretgan,
AGPERIVA=@agperiva,
AGPERIIBB=@agperiibb,
TRANSPOEN=@transpoen,
FECREEN=@fecreen,
FIRMA=@firma,
MOCTAEN=@moctaen, -- Moneda entidad
CTASDELAEN=@ctasdelaen,
NACIONEN=@nacionen,
DIRPAREN=@dirparen,
FECNACEN=@fecnacen,
ESTCIVEN=@estciven,
PROFECEN=@profecen,
CONYUGEN=@conyugen,
RUTCONEN=@rutconen,
RUTSOCEN=@rutsocen,
SEXOEN=@sexoen,
RELACIEN=@relacien,
ANEXEN1=@anexen1,
ANEXEN2=@anexen2,
ANEXEN3=@anexen3,
ANEXEN4=@anexen4,
OCCOBLI=@occobli,
VALIVENPAG=@valivenpag,
EMAILCOMER=@emailcomer,
TIPOCONTR=@tipocontr,
FEREFAUTO=@ferefauto,
DIACOBRA=@diacobra, -- Dias de cobranza XXXXXXX  = todos ; X X X = Lun,Mie,Vie
CUENTABCO=@cuentabco,
KOENDPEN=@koendpen,
SUENDPEN=@suendpen,
ACTECOBCO=@actecobco,
RUTALUN=@rutalun,
RUTAMAR=@rutamar,
RUTAMIE=@rutamie,
RUTAJUE=@rutajue,
RUTAVIE=@rutavie,
RUTASAB=@rutasab,
RUTADOM=@rutadom



WHERE KOEN=@koen AND SUEN=@suen


--UPDATE MAEEN SET CRTO=0.00000,CRPA=0.00000,CRLT=0.00000,CRCH=0.00000,CRSD=0.00000 WHERE KOEN='15463484     ' 
--SELECT CURRENT_TIMESTAMP AS FECHA, CONVERT( VARCHAR(45), CURRENT_TIMESTAMP, 9 ) AS HORA 
--INSERT INTO TABACTUS ( IPPIDE,IPOTORGA,KOFU,HORAGRAB,VERSION,ACCION) VALUES ( '192.168.137.1','','ZZZ',55759,'( v13.9 [03/09/2013] )','Modificacion de Entidad : 15463484 3 ')

--DELETE MAEENPRO WHERE KOEN=@koen AND SUEN=@suen 
--INSERT INTO MAEENPRO (KOEN,SUEN,PROYECTO) VALUES (@koen,@suen,'') 

