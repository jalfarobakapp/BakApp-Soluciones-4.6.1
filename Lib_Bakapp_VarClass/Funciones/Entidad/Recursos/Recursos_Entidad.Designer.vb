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
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Class Recursos_Entidad
        
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
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Lib_Bakapp_VarClassFunc.Recursos_Entidad", GetType(Recursos_Entidad).Assembly)
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
        '''Declare @CodEntidad Char(10) = &apos;#CodEntidad#&apos;,
        '''        @SucEntidad Char(10) = &apos;#SucEntidad#&apos;
        '''
        '''Select CAST( &apos;&apos; AS Varchar(15)) As &apos;Rut&apos;,
        '''       *, 
        '''       Isnull((Select top 1 NOKOFU From TABFU Where KOFU = KOFUEN),&apos;&apos;) As &apos;VENDEDOR&apos;,
        '''       Isnull((Select top 1 NOKOFU From TABFU Where KOFU = COBRADOR),&apos;&apos;) As &apos;NOMCOBRADOR&apos;,
        '''       Case TIPOSUC When &apos;C&apos; Then &apos;CLIENTE&apos; When &apos;P&apos; Then &apos;PROVEEDOR&apos; Else &apos;AMBOS&apos; End As &apos;TIPOSUCURSAL&apos;,
        '''       (Select Top 1 NOKOEN From MAEEN Where KOEN = @CodEntidad And SUEN [resto de la cadena truncado]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property SqlQuery_Datos_Entidad() As String
            Get
                Return ResourceManager.GetString("SqlQuery_Datos_Entidad", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
