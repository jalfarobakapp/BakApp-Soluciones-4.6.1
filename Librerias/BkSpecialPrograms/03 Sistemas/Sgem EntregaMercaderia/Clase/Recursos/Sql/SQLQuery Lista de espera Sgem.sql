Declare @Empresa as Char(2) = '#Empresa#'
Declare @Sucursal as Char(3) = '#Sucursal#'

Select Enc.Numero,Enc.Tido,Enc.Nudo,Enc.TidoGen,Enc.NudoGen,Enc.Estado,Edo.SUDO,En.NOKOEN,EdoF.VABRDO,EdoF.VAABDO,EdoF.VABRDO-EdoF.VAABDO As Saldo,EdoF.ESPGDO,
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
End As 'InfoCliente'

--Into #Paso
From Zw_Stmp_Enc Enc
Inner Join MAEEDO Edo On Edo.IDMAEEDO = Enc.Idmaeedo
Left Join MAEEN En On En.KOEN = Enc.Endo And En.SUEN = Enc.Suendo
Left Join TABFU FEnt On FEnt.KOFU = CodFuncionario_Entrega
Left Join MAEEDO EdoF on EdoF.IDMAEEDO = Enc.IdmaeedoGen
Where 1 > 0

--And (Estado = 'FACTU' And EdoF.ESPGDO <> 'C') Or (Estado IN ('PREPA','COMPL') And Planificada = 1 And Facturar = 1)
And (Estado = 'FACTU' And EdoF.VAABDO = 0) Or (Estado IN ('PREPA','COMPL') And Planificada = 1 And Facturar = 1)
Order By EdoF.LAHORA