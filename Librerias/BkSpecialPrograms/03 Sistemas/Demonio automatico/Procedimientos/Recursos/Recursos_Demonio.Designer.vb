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
    Friend Class Recursos_Demonio
        
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
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("BkSpecialPrograms.Recursos_Demonio", GetType(Recursos_Demonio).Assembly)
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
        '''  Busca una cadena traducida similar a 
        '''
        '''SELECT *,
        '''       (SELECT TOP 1 RTEN FROM MAEEN WHERE KOEN = ENDO AND SUEN = SUENDO) AS RTEN,
        '''       (SELECT TOP 1 NOKOEN FROM MAEEN WHERE KOEN = ENDO AND SUEN = SUENDO) AS RAZON,
        '''       KOFUDO,(SELECT TOP 1 NOKOFU FROM TABFU WHERE KOFU = KOFUDO) AS FUNCIONARIO
        '''       FROM MAEEDO 
        '''       WHERE IDMAEEDO = #Idmaeedo#
        '''
        '''
        '''SELECT 
        '''       --DO.KOPRCT AS KOPR, 
        '''       DO.*,
        '''       (SELECT TOP 1 KOPRTE FROM MAEPR WHERE KOPR = DO.KOPRCT) AS KOPRTE,
        '''       NOKOPR,
        '''       CASE UDTRPR 
        '''           WHEN 1 [resto de la cadena truncado]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property Picking() As String
            Get
                Return ResourceManager.GetString("Picking", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a 
        '''Declare 
        '''@Fecha as date = &apos;#Fecha#&apos;,
        '''@NombreEquipo as Varchar(30) = &apos;#NombreEquipo#&apos;,
        '''@Tido as Varchar(3) = &apos;#Tido#&apos;
        '''
        '''Select IDMAEEDO,
        '''       Cast(0 as Bit) as Chk,
        '''       TIDO,
        '''       NUDO,
        '''       ENDO,
        '''       SUENDO,
        '''	   (Select Top 1 NOKOEN From MAEEN Where KOEN = ENDO And SUEN = SUENDO) As &apos;RAZON&apos;,
        '''	   VABRDO,
        '''	   (SELECT DISTINCT COUNT(NULIDO) AS CAMPO FROM MAEDDO Do WHERE Do.IDMAEEDO = Edo.IDMAEEDO) As Items,
        '''	   KOFUDO,
        '''	   (Select Top 1 NOKOFU From TABFU Where KOFU = KOFUDO) As &apos;FUN [resto de la cadena truncado]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property SqlQuery_Buscar_Doc_Impresos_y_Log_Errores() As String
            Get
                Return ResourceManager.GetString("SqlQuery_Buscar_Doc_Impresos_y_Log_Errores", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a SELECT  Top #CantidadDoc#
        '''        Cast(0 As Bit) As Chk,
        '''        IDMAEEDO,
        '''        Edo.TIDO,
        '''        --ISNULL((SELECT TOP 1 NOTIDO FROM TABTIDO WHERE TIDO = MAEEDO.TIDO),&apos;&apos;) AS &apos;TipoDoc&apos;,
        '''        Isnull(Tid.NOTIDO,&apos;&apos;) As &apos;TipoDoc&apos;,
        '''		NUDO,
        '''        ENDO,
        '''        SUENDO,
        '''        --ISNULL((SELECT TOP 1 NOKOEN FROM MAEEN WHERE KOEN = ENDO AND SUEN = SUENDO ),&apos;&apos;) AS RAZON,
        '''        Isnull(Mae1.NOKOEN,&apos;&apos;) As RAZON,
        '''		ENDOFI,
        '''        #Campo_SUENDOFI#
        '''        --ISNULL((SELECT TOP 1 NOKOEN FROM MAEEN WHE [resto de la cadena truncado]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property SQLQuery_Cierrer_Docmuento() As String
            Get
                Return ResourceManager.GetString("SQLQuery_Cierrer_Docmuento", resourceCulture)
            End Get
        End Property
    End Class
End Namespace