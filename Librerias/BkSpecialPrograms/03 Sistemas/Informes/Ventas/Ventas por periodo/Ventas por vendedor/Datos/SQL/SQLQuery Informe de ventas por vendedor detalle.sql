SELECT EDO.TIDO, EDO.NUDO, EDO.ENDO, EDO.SUENDO, EDO.SUDO,EDO.FEEMDO, EDO.KOFUDO, EDO.MODO, EDO.TIMODO, EDO.TAMODO,EDO.CAPRAD, EDO.CAPREX,
       'VANEDO'=CASE  
                    WHEN EDO.TIMODO='E' THEN 
                         EDO.VANEDO*EDO.TAMODO*
                            (CASE 
                                 WHEN EDO.TIDO IN ('NCV','NCX','NEV') OR EDO.TIDO='NCC' THEN -1 
                                 ELSE 1 
                             END)  
                    ELSE EDO.VANEDO* 
                            (CASE 
                                 WHEN EDO.TIDO IN ('NCV','NCX','NEV') OR EDO.TIDO='NCC' THEN -1 
                                 ELSE 1 
                             END)  
                 END,
        'VAIVDO'=CASE  
                     WHEN EDO.TIMODO='E' THEN 
                          EDO.VAIVDO*EDO.TAMODO* 
                             (CASE 
                                  WHEN EDO.TIDO IN ('NCV','NCX','NEV') OR EDO.TIDO='NCC' THEN -1 
                                  ELSE 1 
                              END)  
                     ELSE EDO.VAIVDO* 
                             (CASE 
                                  WHEN EDO.TIDO IN ('NCV','NCX','NEV') OR EDO.TIDO='NCC' THEN -1 
                                  ELSE 1 
                              END)  
                  END, 
         'VABRDO'=CASE  
                      WHEN EDO.TIMODO='E' THEN 
                           EDO.VABRDO*EDO.TAMODO* 
                              (CASE 
                                   WHEN EDO.TIDO IN ('NCV','NCX','NEV') OR EDO.TIDO='NCC' THEN -1 
                                   ELSE 1 
                               END)  
                      ELSE EDO.VABRDO* 
                              (CASE 
                                   WHEN EDO.TIDO IN ('NCV','NCX','NEV') OR EDO.TIDO='NCC' THEN -1 
                                   ELSE 1 
                               END)  
                    END,
         'VAABDO'=CASE 
                      WHEN EDO.TIMODO='E' THEN 
                           EDO.VAABDO*EDO.TAMODO* 
                              (CASE 
                                   WHEN EDO.TIDO IN ('NCV','NCX','NEV') OR EDO.TIDO='NCC' THEN -1 
                                   ELSE 1 
                               END)  
                      ELSE EDO.VAABDO* 
                              (CASE 
                                   WHEN EDO.TIDO IN ('NCV','NCX','NEV') OR EDO.TIDO='NCC' THEN -1 
                                   ELSE 1 
                               END)  
                      END,
          'VASADO'=CASE  
                       WHEN EDO.TIMODO='E' THEN (EDO.VABRDO-EDO.VAABDO)*EDO.TAMODO* 
                              (CASE 
                                   WHEN EDO.TIDO IN ('NCV','NCX','NEV') OR EDO.TIDO='NCC' THEN -1 
                                   ELSE 1 
                               END)
                       ELSE (EDO.VABRDO-EDO.VAABDO)* 
                              (CASE 
                                   WHEN EDO.TIDO IN ('NCV','NCX','NEV') OR EDO.TIDO='NCC' THEN -1 
                                   ELSE 1 
                               END)  
                   END,
     EDO.ESPGDO,DDO.LILG,DDO.NULIDO,DDO.SULIDO,DDO.LUVTLIDO,DDO.BOSULIDO,DDO.KOFULIDO, 
     'PRCT'=ISNULL(DDO.PRCT,0),DDO.TICT,DDO.TIPR,DDO.NUSEPR,DDO.KOPRCT,DDO.UDTRPR,DDO.RLUDPR,
           'CAPRCO1'=CASE  
                         WHEN EDO.TIDO IN ('GDV','GDP','GDD','GRC','GRP','GRI') THEN DDO.CAPRCO1-DDO.CAPREX1  
                         WHEN EDO.TIDO IN ('NCV','NCC','NCX','NEV') THEN DDO.CAPRCO1*(-1)  
                         ELSE DDO.CAPRCO1 
                     END,
     DDO.CAPRAD1,DDO.CAPREX1,DDO.CAPRNC1,DDO.UD01PR,
           'CAPRCO2'=CASE  
                         WHEN EDO.TIDO IN ('GDV','GDP','GDD','GRC','GRP','GRI') THEN DDO.CAPRCO2-DDO.CAPREX2  
                         WHEN EDO.TIDO IN ('NCV','NCC','NCX','NEV') THEN DDO.CAPRCO2*(-1) 
                         ELSE DDO.CAPRCO2 
                     END,
     DDO.CAPRAD2,DDO.CAPREX2,DDO.CAPRNC2,DDO.UD02PR,DDO.PPPRNE,DDO.PPPRBR,
           'VALORNETO'=CASE  
                           WHEN EDO.TIMODO='E' THEN DDO.VANELI*EDO.TAMODO*  
                              (CASE 
                                   WHEN EDO.TIDO IN ('NCV','NCX','NEV') OR EDO.TIDO='NCC' THEN -1 
                                   ELSE 1 
                               END)  
                           ELSE DDO.VANELI* 
                              (CASE 
                                   WHEN EDO.TIDO IN ('NCV','NCX','NEV') OR EDO.TIDO='NCC' THEN -1 
                                   ELSE 1 
                               END)  
                           END, 
      DDO.VABRLI,DDO.FEEMLI,DDO.FEERLI,DDO.PPPRPM,DDO.ESLIDO,DDO.PPPRNERE1,DDO.PPPRNERE2,
            'NOKOPR'=CASE DDO.PRCT 
                         WHEN 0 THEN DDO.NOKOPR 
                         ELSE TABCT.NOKOCT 
                     END,
            'NOKOMR'=ISNULL(TABMR.NOKOMR,''),
            'NOKOFM'=CASE DDO.PRCT 
                         WHEN 1 THEN 'CONCEPTOS' 
                         ELSE ISNULL(TABFM.NOKOFM,'') 
                     END,
      'NOZONA'=ISNULL(TABZO.NOKOZO,''),
      'NOKORU'=ISNULL(TABRU.NOKORU,''),
      'NOKOSU'=ISNULL(TABSU.NOKOSU,''),
      'NOKOFU'=ISNULL(TABFU.NOKOFU,''),
      'NOKOBO'=ISNULL(TABBO.NOKOBO,''),
             'FMPR'=CASE DDO.PRCT 
                         WHEN 1 THEN '_ct_' 
                         ELSE ISNULL(MAEPR.FMPR,'') 
                    END,
      'MRPR'=ISNULL(MAEPR.MRPR,''),
      'NOKOEN'=ISNULL(MAEEN.NOKOEN,''),
      'ZOEN'=ISNULL(MAEEN.ZOEN,''),
      'RUEN'=ISNULL(MAEEN.RUEN,''),
      'RECEPRRE'=ISNULL(TABCT.RECAPRRE,0),
      'NOKOPF'=ISNULL(TABPF.NOKOPF,''),
      'NOKOHF'=ISNULL(TABHF.NOKOHF,''),
      'PFPR'=ISNULL(MAEPR.PFPR,''),
      'HFPR'=ISNULL(MAEPR.HFPR,''),
      DDO.PROYECTO,TPROYECT.NOPROYECTO  
      INTO #VENVEN
      FROM MAEEDO EDO WITH ( NOLOCK ) INNER JOIN MAEDDO DDO ON EDO.IDMAEEDO = DDO.IDMAEEDO  
      AND DDO.LILG NOT IN ('GR','IM')  AND NOT ( DDO.TIDO = 'GDV' AND DDO.ESLIDO = 'C' )  
      LEFT JOIN TABSU ON TABSU.KOSU=DDO.SULIDO  LEFT JOIN TABFU ON TABFU.KOFU=DDO.KOFULIDO  LEFT JOIN MAEPR   
       ON MAEPR.KOPR=DDO.KOPRCT  LEFT JOIN MAEEN ON MAEEN.KOEN=EDO.ENDO AND MAEEN.SUEN=EDO.SUENDO  LEFT JOIN TABMR 
          ON TABMR.KOMR=MAEPR.MRPR  LEFT JOIN TABLUG   ON TABLUG.LUVT=DDO.LUVTLIDO  LEFT JOIN TABFM
              ON TABFM.KOFM=MAEPR.FMPR  LEFT JOIN TABPF    ON TABPF.KOFM=MAEPR.FMPR AND TABPF.KOPF=MAEPR.PFPR  
              LEFT JOIN TABHF    ON TABHF.KOFM=MAEPR.FMPR AND TABHF.KOPF=MAEPR.PFPR AND TABHF.KOHF=MAEPR.HFPR 
               LEFT JOIN TABZO    ON TABZO.KOZO=MAEEN.ZOEN  LEFT JOIN TABRU    ON TABRU.KORU=MAEEN.RUEN 
                LEFT JOIN TABBO    ON TABBO.KOBO=DDO.BOSULIDO  LEFT JOIN TPROYECT
                 ON TPROYECT.PROYECTO=DDO.PROYECTO  LEFT JOIN TABCT ON DDO.KOPRCT=TABCT.KOCT AND DDO.PRCT=1  
       WHERE 1 > 0 
       --And EDO.EMPRESA='01' 
       --And EDO.FEEMDO BETWEEN {d '2015-11-06'} And {d '2015-11-06'} 
       #Filtro_Empresa#
       #Filtro_Sucursales#
       #Filtro_Fecha#
       #Filtro_Vendedor#
       #Filtro_Documentos#
       And NOT (EDO.TIDO = 'GDV' And EDO.ESDO = 'C')  
       And EDO.ESDO<>'N' 

