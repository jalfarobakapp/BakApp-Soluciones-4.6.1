﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'StronglyTypedResourceBuilder generó automáticamente esta clase
    'a través de una herramienta como ResGen o Visual Studio.
    'Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    'con la opción /str o recompile su proyecto de VS.
    '''<summary>
    '''  Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Class Recursos_Info_Producto
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("BkSpecialPrograms.Recursos_Info_Producto", GetType(Recursos_Info_Producto).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        '''  búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Select 
        '''&apos;Tot. Compras&apos; as &apos;Concepto&apos;,
        '''(Select Isnull(sum(#SumTotalQtyUd#),0) from #Tabla_de_Paso# 
        '''Where Tipo = &apos;C&apos;
        '''And Fecha &gt;= DATEADD(day, -1, GETDATE())) as &apos;Del Día&apos;,
        '''(select Isnull(sum(#SumTotalQtyUd#),0) from #Tabla_de_Paso# 
        '''Where Tipo = &apos;C&apos;
        '''And Fecha &gt;= DATEADD(WEEK, -1, GETDATE())) as &apos;Ult.Semana&apos;,
        '''(Select Isnull(sum(#SumTotalQtyUd#),0) from #Tabla_de_Paso# 
        '''Where Tipo = &apos;C&apos;
        '''And Fecha &gt;= DATEADD(DAY, -30, GETDATE())) as &apos;Ult.30 días&apos;,
        '''(Select Isnull(sum(#SumTotalQtyUd#),0) from #Tabla_d [resto de la cadena truncado]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property MovAcumulados() As String
            Get
                Return ResourceManager.GetString("MovAcumulados", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a -- Datos de cumplimiento de entrega de productos por parte del proveedor
        '''
        '''Declare @Endo Char(10) = &apos;#Koen#&apos;
        '''Declare @Suendo Char(10) = &apos;#Suen#&apos;
        '''Declare @Codigo Char(13) = &apos;#Codigo#&apos;
        '''Declare @Meses Int = #Meses#
        '''
        '''Select Distinct Edo.IDMAEEDO,Edo.FEEMDO
        '''Into #Paso_Documentos
        '''From MAEDDO Ddo 
        '''Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO
        '''Where Ddo.IDMAEEDO In (Select IDMAEEDO From MAEEDO Where TIDO = &apos;OCC&apos; And ENDO = @Endo And SUENDO = @Suendo And FEEMDO &gt; DATEADD(M,-@Meses,Getdate()))
        '''And K [resto de la cadena truncado]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property SQLQuery_Calculo_de_cumplimiento_de_entregas_por_parte_de_un_proveedor_por_Producto() As String
            Get
                Return ResourceManager.GetString("SQLQuery_Calculo_de_cumplimiento_de_entregas_por_parte_de_un_proveedor_por_Produc"& _ 
                        "to", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a DECLARE 
        '''@Codigo  Char(13) 
        '''
        '''Select @Codigo = &apos;#Codigo#&apos;
        '''
        '''SELECT    *,
        '''            Isnull(TABMR.NOKOMR,&apos;&apos;) as &apos;Marca&apos;,
        '''            Isnull(TABFM.NOKOFM,&apos;&apos;) as &apos;SuperFamilia&apos;, 
        '''            Isnull(TABPF.NOKOPF,&apos;&apos;) as &apos;Familia&apos;, 
        '''            Isnull(TABHF.NOKOHF,&apos;&apos;) as &apos;SubFamilia&apos;, 
        '''            Isnull(TABRU.NOKORU,&apos;&apos;) as &apos;Rubro&apos;,  
        '''            Isnull(TABZO.NOKOZO,&apos;&apos;) as &apos;Zona&apos;
        '''FROM         dbo.TABFM RIGHT OUTER JOIN
        '''                      dbo.TABHF RIGHT OUTER JOIN
        '''                      dbo.MAEPR L [resto de la cadena truncado]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property SQLQuery_DatosDelProducto() As String
            Get
                Return ResourceManager.GetString("SQLQuery_DatosDelProducto", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a DECLARE 
        '''@Empresa Char(2),
        '''--@Codigo Varchar(13),
        '''@Fecha1 Datetime,
        '''@Fecha2 Datetime,
        '''@CodFuncionario Char(3)
        '''
        '''
        '''Select @Empresa = &apos;#Empresa#&apos;,@Fecha1 = &apos;#Fecha1#&apos;,@Fecha2 = &apos;#Fecha2#&apos;,@CodFuncionario = &apos;#Funcionario#&apos;
        '''
        '''--drop table #Tabla_de_Paso#
        '''CREATE TABLE [dbo].[#Tabla_de_Paso#](
        '''[Tipo]                  [Char](1)     DEFAULT &apos;&apos;,
        '''[Sucursal]              [Char](3)     DEFAULT &apos;&apos;,
        '''[Bodega]                [Char](3)     DEFAULT &apos;&apos;,
        '''[Fecha]                 [Datetime],
        '''[Mes_Palabra]            [resto de la cadena truncado]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property SQLQuery_Estadisticas_por_producto() As String
            Get
                Return ResourceManager.GetString("SQLQuery_Estadisticas_por_producto", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a DECLARE 
        '''@Empresa char(2),
        '''@Fecha_Desde datetime,
        '''@Fecha_Hasta datetime
        '''
        '''select @Empresa = &apos;#Empresa#&apos;,
        '''       @Fecha_Desde = &apos;#Fecha_Desde#&apos;,
        '''       @Fecha_Hasta = &apos;#Fecha_Hasta#&apos;
        '''
        '''SELECT 
        '''        ISNULL(SUM(CASE 
        '''                 WHEN MAEDDO.TIDO IN (&apos;OCC&apos;) 
        '''                 THEN CASE WHEN MAEDDO.CAPREX#Ud# &lt;&gt; 0 THEN CAPRCO#Ud# ELSE 0 END 
        '''                 ELSE 0
        '''               END),0) AS &apos;Solicitud_Compra_Ud&apos;,
        '''    ISNULL(SUM(CASE 
        '''                 WHEN MAEDDO.TIDO IN (&apos;FCC&apos;,&apos;NCV&apos;)
        '''       [resto de la cadena truncado]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property SQLQuery_Mov_Stock_Diario_Tabla() As String
            Get
                Return ResourceManager.GetString("SQLQuery_Mov_Stock_Diario_Tabla", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a 
        '''SELECT TOP (1) 
        '''              &apos;Ult. Guía&apos; AS Obs, 
        '''               ISNULL(EDD.TIDO,&apos;&apos;) AS Tipo,
        '''               ISNULL(EDD.NUDO,&apos;&apos;) AS Numero, 
        '''               ISNULL(dbo.MAEEN.NOKOEN,&apos;&apos;) AS Razon, 
        '''                ISNULL((Select top 1 NOKOEN From MAEEN Where KOEN = EDD.ENDOFI),&apos;&apos;) as EntFisica, 
        '''               ISNULL(EDD.FEEMLI,&apos;&apos;) AS Fecha, 
        '''               CASE WHEN EDD.UDTRPR = 1 THEN EDD.UD01PR ELSE EDD.UD02PR END AS &apos;UD&apos;,
        '''               CASE WHEN EDD.UDTRPR = 1 THEN CAPRCO1 ELSE CAPRCO2 END AS &apos; [resto de la cadena truncado]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property UltimasOccGrcFcc_Pendientes() As String
            Get
                Return ResourceManager.GetString("UltimasOccGrcFcc_Pendientes", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a DECLARE @Empresa       Char( 2),
        '''        @Codigo        Char(13) 
        '''        
        '''Select @Empresa = &apos;#Empresa#&apos;,@Codigo = &apos;#Codigo#&apos;
        '''
        '''SELECT TOP #NroDocumentos#
        '''              MAEDDO.IDMAEEDO,
        '''              MAEDDO.ENDO,
        '''              MAEDDO.SUENDO,
        '''              MAEEN.NOKOEN,
        '''              ISNULL(MAEDDO.ENDOFI,&apos;&apos;) AS ENDOFI,
        '''              ISNULL((SELECT TOP 1 NOKOEN FROM MAEEN WHERE KOEN = MAEDDO.ENDOFI),&apos;&apos;) AS NOMENDOFI,
        '''              MAEDDO.TIDO,
        '''              MAEDDO.NUDO,
        '''			  MAEDDO.SULIDO,
        '''			   [resto de la cadena truncado]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property Ultimos_Movimientos_Del_Producto() As String
            Get
                Return ResourceManager.GetString("Ultimos_Movimientos_Del_Producto", resourceCulture)
            End Get
        End Property
    End Class
End Namespace