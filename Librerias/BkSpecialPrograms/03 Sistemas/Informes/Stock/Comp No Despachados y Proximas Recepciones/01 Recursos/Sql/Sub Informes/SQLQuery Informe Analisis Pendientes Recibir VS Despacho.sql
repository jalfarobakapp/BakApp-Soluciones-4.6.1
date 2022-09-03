Use #Base_BakApp#

CREATE TABLE [dbo].[#Tabla_Paso_Ppr_VS_Cnd#](
    [Id]								 [int] IDENTITY(1,1) NOT NULL,
    [EMPRESA]                            [Varchar](2)  DEFAULT '',
    [EMPRESA_INFORME]					 [Varchar](50) DEFAULT '',
    --[ENDO]								 [Varchar](13) DEFAULT '',
    --[SUENDO]							 [Varchar](10) DEFAULT '',
    --[NOKOEN]                             [Varchar](50) DEFAULT '',
    --[SULIDO]                             [Varchar](3)  DEFAULT '',
    --[SUCURSAL]                           [Varchar](50) DEFAULT '',
    --[BOSULIDO]                           [Varchar](3)  DEFAULT '',
    --[BODEGA]                             [Varchar](50) DEFAULT '',
    [KOPRCT_]                            [Varchar](13) DEFAULT '',
    [NOKOPR]                             [Varchar](50) DEFAULT '',
    [UM]                                 [Varchar](2)  DEFAULT '',
    [QTY_PEND_X_REC]                     [float]       DEFAULT (0),
    [TOT_SALDOxPRECIO_PEND_X_REC]        [float]       DEFAULT (0),
    [TOT_SALDOxPRECIOREAL_PEND_X_REC]    [float]       DEFAULT (0),
    [TOT_SALDOxPM_TRANS_PEND_X_REC]      [float]       DEFAULT (0),
    [TOT_SALDOxPM_ACTUAL_PEND_X_REC]     [float]       DEFAULT (0),
    [PM_ACTUAL]                          [float]       DEFAULT (0),
    [STK_FIS_BOD]                        [float]       DEFAULT (0),
    [STK_DESPNOFAC]                      [float]       DEFAULT (0),
    [STK_RECENOFAC]                      [float]       DEFAULT (0),
    [QTY_PEND_X_DESP]                    [float]       DEFAULT (0),
    [TOT_SALDOxPDESPIO_PEND_X_DESP]      [float]       DEFAULT (0),
    [TOT_SALDOxPDESPIOREAL_PEND_X_DESP]  [float]       DEFAULT (0),
    [TOT_SALDOxPM_TRANS_PEND_X_DESP]     [float]       DEFAULT (0),
    [TOT_SALDOxPM_ACTUAL_PEND_X_DESP]    [float]       DEFAULT (0),
    [FMPR]                               [Varchar](4)  DEFAULT '',   
    [SUPER_FAMILIA]                      [Varchar](50) DEFAULT '',   
    [PFPR]                               [Varchar](4)  DEFAULT '',   
    [FAMILIA]                            [Varchar](50) DEFAULT '',   
    [HFPR]                               [Varchar](4)  DEFAULT '',   
    [SUB_FAMILIA]                        [Varchar](50) DEFAULT '',   
    [MRPR]							     [Varchar](20) DEFAULT '',   
    [MARCA]							     [Varchar](50) DEFAULT '',   
    [RUPR]                               [Varchar](4)  DEFAULT '',   
    [RUBRO]                              [Varchar](50) DEFAULT '',   
    [CLALIBPR]                           [Varchar](20) DEFAULT '',   
    [CLAS_LIBRE]                         [Varchar](200) DEFAULT ''
    
CONSTRAINT PK_#Tabla_Paso_Ppr_VS_Cnd#_Codigo PRIMARY KEY(Id))
ON [PRIMARY]


--Insert Into #INF004 (EMPRESA_INFORME,ENDO,SUENDO,NOKOEN,SULIDO,SUCURSAL,BOSULIDO,BODEGA,
Insert Into #Tabla_Paso_Ppr_VS_Cnd#
                    (EMPRESA,EMPRESA_INFORME,KOPRCT_,NOKOPR,UM,
                     FMPR,SUPER_FAMILIA,PFPR,FAMILIA,HFPR,SUB_FAMILIA,
                     MRPR,MARCA,RUPR,RUBRO,CLALIBPR,CLAS_LIBRE)
Select DISTINCT      EMPRESA,EMPRESA_INFORME,KOPRCT,NOKOPR,UD0#Ud#PR,
                     FMPR,SUPER_FAMILIA,PFPR,FAMILIA,HFPR,SUB_FAMILIA,
                     MRPR,MARCA,RUPR,RUBRO,CLALIBPR,CLAS_LIBRE

From #Tabla_Paso_Ppr#



--Insert Into #INF004 (EMPRESA_INFORME,ENDO,SUENDO,NOKOEN,SULIDO,SUCURSAL,BOSULIDO,BODEGA,
Insert Into #Tabla_Paso_Ppr_VS_Cnd#
                    (EMPRESA,EMPRESA_INFORME,KOPRCT_,NOKOPR,UM,
                     FMPR,SUPER_FAMILIA,PFPR,FAMILIA,HFPR,SUB_FAMILIA,
                     MRPR,MARCA,RUPR,RUBRO,CLALIBPR,CLAS_LIBRE)
Select DISTINCT      EMPRESA,EMPRESA_INFORME,KOPRCT,NOKOPR,UD0#Ud#PR,
                     FMPR,SUPER_FAMILIA,PFPR,FAMILIA,HFPR,SUB_FAMILIA,
                     MRPR,MARCA,RUPR,RUBRO,CLALIBPR,CLAS_LIBRE

From #Tabla_Paso_Cnd# 

Where KOPRCT Not In (Select KOPRCT_ From #Tabla_Paso_Ppr_VS_Cnd#)          

UPDATE #Tabla_Paso_Ppr_VS_Cnd# SET 

QTY_PEND_X_REC = ISNULL((SELECT SUM(SALDO_Ud#Ud#) From #Tabla_Paso_Ppr# 
                                     WHERE KOPRCT = KOPRCT_),0),
                                     
TOT_SALDOxPRECIO_PEND_X_REC = ISNULL((SELECT SUM(TOT_SALDOxPRECIOREAL) From #Tabla_Paso_Ppr# 
                                     WHERE KOPRCT = KOPRCT_),0),

TOT_SALDOxPRECIOREAL_PEND_X_REC = ISNULL((SELECT SUM(TOT_SALDOxPRECIOREAL) From #Tabla_Paso_Ppr# 
                                     WHERE KOPRCT = KOPRCT_),0),

TOT_SALDOxPM_TRANS_PEND_X_REC = ISNULL((SELECT SUM(TOT_SALDOxPM_TRANS) From #Tabla_Paso_Ppr# 
                                     WHERE KOPRCT = KOPRCT_),0),

TOT_SALDOxPM_ACTUAL_PEND_X_REC = ISNULL((SELECT SUM(TOT_SALDOxPM_ACTUAL) From #Tabla_Paso_Ppr# 
                                    WHERE KOPRCT = KOPRCT_),0)

-- ******************
UPDATE #Tabla_Paso_Ppr_VS_Cnd# SET 
QTY_PEND_X_DESP = ISNULL((SELECT SUM(SALDO_Ud#Ud#) From #Tabla_Paso_Cnd# 
                                     WHERE KOPRCT = KOPRCT_),0),
                                     
TOT_SALDOxPDESPIO_PEND_X_DESP = ISNULL((SELECT SUM(TOT_SALDOxPRECIOREAL) From #Tabla_Paso_Cnd# 
                                     WHERE KOPRCT = KOPRCT_),0),

TOT_SALDOxPDESPIOREAL_PEND_X_DESP = ISNULL((SELECT SUM(TOT_SALDOxPRECIOREAL) From #Tabla_Paso_Cnd# 
                                     WHERE KOPRCT = KOPRCT_),0),

TOT_SALDOxPM_TRANS_PEND_X_DESP = ISNULL((SELECT SUM(TOT_SALDOxPM_TRANS) From #Tabla_Paso_Cnd# 
                                     WHERE KOPRCT = KOPRCT_),0),

TOT_SALDOxPM_ACTUAL_PEND_X_DESP = ISNULL((SELECT SUM(TOT_SALDOxPM_ACTUAL) From #Tabla_Paso_Cnd# 
                                    WHERE KOPRCT = KOPRCT_),0)
                                                     

Select * From #Tabla_Paso_Ppr_VS_Cnd# -- INFORME ANALISIS

--Select * From #Tabla_Paso_Ppr# -- INFORME PROXIMAS RECEPCIONES
--Select * From #Tabla_Paso_Cnd# -- INFORME COMPROMISOS NO DESPACHADOS

--Drop table #INF004


--SELECT * FROM CONFIGP    


