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
    Friend Class Rs_InvMargenes
        
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
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("BkSpecialPrograms.Rs_InvMargenes", GetType(Rs_InvMargenes).Assembly)
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
        '''  Busca una cadena traducida similar a declare 
        '''@Empresa     Char(2),
        '''@Sucursal    Char(3),
        '''@Bodega      Char(3),
        '''@Fecha1      Date,
        '''@Fecha2      Date,
        '''@Ila         Float,
        '''@Opcion      Int,
        '''@ListaCosto  Char(3),
        '''@Funcionario Char(3) 
        '''
        '''Select @Funcionario = &apos;#_Funcionario_Activo#&apos;,
        '''       @Opcion = #Opcion#,
        '''       @Fecha1 = &apos;#Fecha1#&apos;,
        '''       @Fecha2   = &apos;#Fecha2#&apos;,
        '''       @Empresa  = &apos;#Empresa#&apos;, 
        '''       @ListaCosto = &apos;#ListaCosto#&apos;
        '''
        '''--TIDO,NUDO,FEEMLI,NULIDO,KOPRCT,NOKOPR&apos;
        '''-- DECLARA TABLA VARIABLE PARA ALMACENAR DETALLE DE  [resto de la cadena truncado]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property Margenes_de_venta() As String
            Get
                Return ResourceManager.GetString("Margenes_de_venta", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a declare 
        '''@Empresa     Char(2),
        '''@Sucursal    Char(3),
        '''@Bodega      Char(3),
        '''@Fecha1      Date,
        '''@Fecha2      Date,
        '''@Ila         Float,
        '''@Opcion      Int,
        '''@ListaCosto  Char(3),
        '''@Funcionario Char(3),
        '''@Nodo_Raiz   Int
        '''
        '''Select @Funcionario = &apos;#_Funcionario_Activo#&apos;,
        '''       @Opcion = #Opcion#,
        '''       @Fecha1 = &apos;#Fecha1#&apos;,
        '''       @Fecha2   = &apos;#Fecha2#&apos;,
        '''       @Empresa  = &apos;#Empresa#&apos;, 
        '''       @ListaCosto = &apos;#ListaCosto#&apos;,
        '''       @Nodo_Raiz = #Nodo_Raiz#
        '''
        '''--BEGIN TRY
        '''
        '''--  BEGIN TRANSACTION
        '''     [resto de la cadena truncado]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property Margenes_de_venta2() As String
            Get
                Return ResourceManager.GetString("Margenes_de_venta2", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
