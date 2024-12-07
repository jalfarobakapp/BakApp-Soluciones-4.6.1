
Update #TablaPaso# Set 
                       Nom_Rubro = Isnull((Select top 1 NOKORU From TABRU WITH (NOLOCK) Where KORU = Rubro),''),
                       Nom_Marca = Isnull((Select Top 1 NOKOMR From TABMR WITH (NOLOCK) Where KOMR = Marca),''),
                       Nom_Zona = Isnull((Select Top 1 NOKOZO From TABZO WITH (NOLOCK) Where KOZO = Zona),''),
                       Nom_SuperFamilia = Isnull((Select Top 1 NOKOFM From TABFM WITH (NOLOCK) Where KOFM = SuperFamilia),''),
                       Nom_Familia = Isnull((Select Top 1 NOKOPF From TABPF WITH (NOLOCK)
                                            Where KOFM = SuperFamilia And KOPF = Familia),''),
                       Nom_SubFamilia = Isnull((Select Top 1 NOKOHF From TABHF WITH (NOLOCK)
                                            Where KOFM = SuperFamilia And KOPF = Familia And KOHF = SubFamilia),''),
                       Nom_ClasificacionLibre = Isnull((Select Top 1 NOKOCARAC From TABCARAC WITH (NOLOCK)
                                            Where KOTABLA = 'CLALIBPR' And KOCARAC = ClasificacionLibre),'')
   

   Update #TablaPaso# Set Fecha_Ult_Venta = '19000101',IdGRC = 0,IdOCC = 0,IdGDD = 0


Update  #TablaPaso# Set IdGDD = IsNull((Select Top 1 IDMAEDDO From MAEDDO WITH (NOLOCK)
Where TIDO = 'GDD' And KOPRCT = Codigo And ESLIDO = '' Order By FEEMLI Desc),0)     

Update #TablaPaso# Set Fecha_Ult_Venta = Isnull((Select Max(FEEMLI) From MAEDDO WITH (NOLOCK) Where IDMAEEDO In 
(Select IDMAEEDO From MAEEDO WITH (NOLOCK) Where TIDO In ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL','FVT','FVX','FVZ','NCE','NCV','NCX','NCZ','NEV','RIN')
#EntExcluidas#
)
And KOPRCT = Codigo
#FiltroBodegas#
--Order By FEEMLI Desc
),'19000101')


												   
												   

