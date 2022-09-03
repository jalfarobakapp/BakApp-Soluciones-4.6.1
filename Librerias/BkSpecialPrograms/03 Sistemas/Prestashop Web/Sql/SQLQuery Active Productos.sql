
Declare @Sitio Varchar(100)

Set @Sitio = '#Sitio#'

SELECT PShop.*,
       Isnull(P1.Codigo_Padre,'') As Padre,Cast(0 As Float) As Stock_Padre,Cast(0 As Float) As Precio_Padre,Cast(0 As bit) As Primario_Padre,
	   Isnull(P2.Codigo_Hijo,'') As Hijo,Cast(0 As Float) As Stock_Hijo,Cast(0 As Float) As Precio_Hijo,Cast(0 As bit) As Primario_Hijo
Into #Paso
FROM #Global_Base_Bakapp#Zw_Prod_PrestaShop PShop
	Left Join #Global_Base_Bakapp#Zw_Prod_Padres P1 On PShop.Codigo = P1.Codigo_Hijo And P1.Carpeta = @Sitio 
		Left Join #Global_Base_Bakapp#Zw_Prod_Padres P2 On PShop.Codigo = P2.Codigo_Padre And P1.Carpeta = @Sitio 
WHERE (Sitio = @Sitio) 

Update #Paso Set Hijo = '' Where Hijo Not In (Select Codigo From #Global_Base_Bakapp#Zw_Prod_PrestaShop Where Sitio = @Sitio)
Update #Paso Set Padre = '' Where Padre Not In (Select Codigo From #Global_Base_Bakapp#Zw_Prod_PrestaShop Where Sitio = @Sitio)

Update #Paso Set Stock_Hijo = Isnull((Select Top 1 Stock_Rd From #Global_Base_Bakapp#Zw_Prod_PrestaShop Z1 Where Hijo = Z1.Codigo And Sitio = @Sitio),0)
Update #Paso Set Precio_Hijo = Isnull((Select Top 1 Precio_Rd From #Global_Base_Bakapp#Zw_Prod_PrestaShop Z1 Where Hijo = Z1.Codigo And Sitio = @Sitio),0)
Update #Paso Set Primario_Hijo = Isnull((Select Top 1 Primario From #Global_Base_Bakapp#Zw_Prod_PrestaShop Z1 Where Hijo = Z1.Codigo And Sitio = @Sitio),0)

Update #Paso Set Stock_Padre = Isnull((Select Top 1 Stock_Rd From #Global_Base_Bakapp#Zw_Prod_PrestaShop Z1 Where Padre = Z1.Codigo And Sitio = @Sitio),0)
Update #Paso Set Precio_Padre = Isnull((Select Top 1 Precio_Rd From #Global_Base_Bakapp#Zw_Prod_PrestaShop Z1 Where Padre = Z1.Codigo And Sitio = @Sitio),0)
Update #Paso Set Primario_Padre = Isnull((Select Top 1 Primario From #Global_Base_Bakapp#Zw_Prod_PrestaShop Z1 Where Padre = Z1.Codigo And Sitio = @Sitio),0)

Update #Paso Set Active = 1

--Update #Paso Set Active = 0
--Where Stock_Rd = 0 And Hijo <> '' And Stock_Hijo > 0

--Update #Paso Set Active = 0
--Where Padre <> '' And Stock_Padre > 0 

--Update #Paso Set Active = 0
--Where Padre <> '' And Stock_Rd = 0

--Update #Paso Set Active = 0
--Where Primario = 1 And Hijo <> '' And Stock_Rd = 0

--Update #Paso Set Active = 1 
--Where Primario = 1 And Hijo <> '' And Stock_Hijo = 0

--Update #Paso Set Active = 0
--Where Precio_Rd = 0

--Update #Paso Set Active = 0
--Where Primario = 1 And Stock_Rd = 0 -- Active = 1

--Update #Paso Set Active = 1 
--Where Primario = 0 And Padre <> '' And Stock_Padre = 0

#Condiciones_Inactivar#

Update #Global_Base_Bakapp#Zw_Prod_PrestaShop Set Active = #Paso.Active
From #Paso
Inner Join #Global_Base_Bakapp#Zw_Prod_PrestaShop Pshop On #Paso.Codigo = Pshop.Codigo And #Paso.Sitio = Pshop.Sitio
Where Pshop.Sitio = @Sitio

Drop Table #Paso