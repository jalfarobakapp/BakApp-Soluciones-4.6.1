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
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Class Recursos_Inf_Tesoreria
        
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
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("BkSpecialPrograms.Recursos_Inf_Tesoreria", GetType(Recursos_Inf_Tesoreria).Assembly)
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
        '''SELECT Mdc.IDMAEDPCE,
        '''       Mdc.TIDP AS TIPO_DOC, 
        '''       Mdc.EMDP AS COD_BANCO, 
        '''       (Select Top 1 NOKOENDP From TABENDP Where KOENDP = Mdc.EMDP And TIDPEN = &apos;CH&apos;) As NOM_BANCO,
        '''       Mdc.NUCUDP AS N_DOC,
        '''       Mdc.ENDP AS KOEN, 
        '''       Mae.NOKOEN AS NOKOEN, 
        '''       Mdc.FEVEDP, 
        '''       Mdc.VADP AS MONTO, 
        '''       Mdc.CUDP AS CUENTA
        '''       Into #Paso_Cartera
        '''FROM   dbo.MAEDPCE Mdc INNER JOIN
        '''       dbo.MAEEN Mae ON Mdc.ENDP = Mae.KOEN
        '''WHERE Mdc.TIDP In (&apos;CHV&apos;) AND (Mdc.FEVEDP &gt; GETDATE [resto de la cadena truncado]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property SQLQuery_Informe_de_cheques_en_cartera_por_clientes() As String
            Get
                Return ResourceManager.GetString("SQLQuery_Informe_de_cheques_en_cartera_por_clientes", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
