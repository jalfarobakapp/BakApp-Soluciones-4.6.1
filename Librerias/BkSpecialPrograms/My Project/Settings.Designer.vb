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


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.9.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "Funcionalidad para autoguardar My.Settings"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Archivador_Ruta() As String
            Get
                Return CType(Me("Archivador_Ruta"),String)
            End Get
            Set
                Me("Archivador_Ruta") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Archivador_Filtro_Arch() As String
            Get
                Return CType(Me("Archivador_Filtro_Arch"),String)
            End Get
            Set
                Me("Archivador_Filtro_Arch") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property Asis_Compra_TblBodCompra() As Global.System.Data.DataTable
            Get
                Return CType(Me("Asis_Compra_TblBodCompra"),Global.System.Data.DataTable)
            End Get
            Set
                Me("Asis_Compra_TblBodCompra") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property Asis_Compra_TblBodVenta() As Global.System.Data.DataTable
            Get
                Return CType(Me("Asis_Compra_TblBodVenta"),Global.System.Data.DataTable)
            End Get
            Set
                Me("Asis_Compra_TblBodVenta") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property Asis_Compra_Metodo_Abastecer_Dias_Meses() As Integer
            Get
                Return CType(Me("Asis_Compra_Metodo_Abastecer_Dias_Meses"),Integer)
            End Get
            Set
                Me("Asis_Compra_Metodo_Abastecer_Dias_Meses") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property Asis_Compra_Tiempo_Reposicion_Dias_Meses() As Integer
            Get
                Return CType(Me("Asis_Compra_Tiempo_Reposicion_Dias_Meses"),Integer)
            End Get
            Set
                Me("Asis_Compra_Tiempo_Reposicion_Dias_Meses") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property Asis_Compra_Dias_a_Abastecer() As Integer
            Get
                Return CType(Me("Asis_Compra_Dias_a_Abastecer"),Integer)
            End Get
            Set
                Me("Asis_Compra_Dias_a_Abastecer") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property Asis_Compra_Tiempo_Reposicion() As Integer
            Get
                Return CType(Me("Asis_Compra_Tiempo_Reposicion"),Integer)
            End Get
            Set
                Me("Asis_Compra_Tiempo_Reposicion") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Sabado() As Boolean
            Get
                Return CType(Me("Asis_Compra_Sabado"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Sabado") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Domingo() As Boolean
            Get
                Return CType(Me("Asis_Compra_Domingo"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Domingo") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Ud1_Compra() As Boolean
            Get
                Return CType(Me("Asis_Compra_Ud1_Compra"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Ud1_Compra") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Ud2_Compra() As Boolean
            Get
                Return CType(Me("Asis_Compra_Ud2_Compra"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Ud2_Compra") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Procesar_Uno_A_Uno() As Boolean
            Get
                Return CType(Me("Asis_Compra_Procesar_Uno_A_Uno"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Procesar_Uno_A_Uno") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Productos_Todos() As Boolean
            Get
                Return CType(Me("Asis_Compra_Productos_Todos"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Productos_Todos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Productos_Vendidos_Los_Ultimos_Dias() As Boolean
            Get
                Return CType(Me("Asis_Compra_Productos_Vendidos_Los_Ultimos_Dias"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Productos_Vendidos_Los_Ultimos_Dias") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Productos_Con_Movimientos_De_Venta() As Boolean
            Get
                Return CType(Me("Asis_Compra_Productos_Con_Movimientos_De_Venta"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Productos_Con_Movimientos_De_Venta") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Productos_Seleccionar() As Boolean
            Get
                Return CType(Me("Asis_Compra_Productos_Seleccionar"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Productos_Seleccionar") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Productos_Familias_Marcas_Etc() As Boolean
            Get
                Return CType(Me("Asis_Compra_Productos_Familias_Marcas_Etc"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Productos_Familias_Marcas_Etc") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Productos_Ranking() As Boolean
            Get
                Return CType(Me("Asis_Compra_Productos_Ranking"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Productos_Ranking") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Productos_Proveedor() As Boolean
            Get
                Return CType(Me("Asis_Compra_Productos_Proveedor"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Productos_Proveedor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Traer_Productos_De_Reemplazo() As Boolean
            Get
                Return CType(Me("Asis_Compra_Traer_Productos_De_Reemplazo"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Traer_Productos_De_Reemplazo") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Ent_Fisica() As Boolean
            Get
                Return CType(Me("Asis_Compra_Ent_Fisica"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Ent_Fisica") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Asis_Compra_Koen_p() As String
            Get
                Return CType(Me("Asis_Compra_Koen_p"),String)
            End Get
            Set
                Me("Asis_Compra_Koen_p") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Asis_Compra_Suen_p() As String
            Get
                Return CType(Me("Asis_Compra_Suen_p"),String)
            End Get
            Set
                Me("Asis_Compra_Suen_p") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Asis_Compra_Tipo_de_compra() As String
            Get
                Return CType(Me("Asis_Compra_Tipo_de_compra"),String)
            End Get
            Set
                Me("Asis_Compra_Tipo_de_compra") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Costo_Ultimo_Documento_Seleccionado() As Boolean
            Get
                Return CType(Me("Asis_Compra_Costo_Ultimo_Documento_Seleccionado"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Costo_Ultimo_Documento_Seleccionado") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Costo_Lista_Proveedor() As Boolean
            Get
                Return CType(Me("Asis_Compra_Costo_Lista_Proveedor"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Costo_Lista_Proveedor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property Asis_Compra_Fecha_Tope_Proveedores_Automaticos() As Date
            Get
                Return CType(Me("Asis_Compra_Fecha_Tope_Proveedores_Automaticos"),Date)
            End Get
            Set
                Me("Asis_Compra_Fecha_Tope_Proveedores_Automaticos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Asis_Compra_Documento_Compra() As String
            Get
                Return CType(Me("Asis_Compra_Documento_Compra"),String)
            End Get
            Set
                Me("Asis_Compra_Documento_Compra") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Sacar_Productos_Sin_Rotacion() As Boolean
            Get
                Return CType(Me("Asis_Compra_Sacar_Productos_Sin_Rotacion"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Sacar_Productos_Sin_Rotacion") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Restar_Stok_Bodega() As Boolean
            Get
                Return CType(Me("Asis_Compra_Restar_Stok_Bodega"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Restar_Stok_Bodega") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_No_Considera_Con_Stock_Pedido_OCC_NVI() As Boolean
            Get
                Return CType(Me("Asis_Compra_No_Considera_Con_Stock_Pedido_OCC_NVI"),Boolean)
            End Get
            Set
                Me("Asis_Compra_No_Considera_Con_Stock_Pedido_OCC_NVI") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Mostrar_Solo_Stock_Critico() As Boolean
            Get
                Return CType(Me("Asis_Compra_Mostrar_Solo_Stock_Critico"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Mostrar_Solo_Stock_Critico") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Quitar_Bloqueados_Compra() As Boolean
            Get
                Return CType(Me("Asis_Compra_Quitar_Bloqueados_Compra"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Quitar_Bloqueados_Compra") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Rango_Fechas_Vta_Promedio() As Boolean
            Get
                Return CType(Me("Asis_Compra_Rango_Fechas_Vta_Promedio"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Rango_Fechas_Vta_Promedio") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property Asis_Compra_Fecha_Vta_Desde() As Date
            Get
                Return CType(Me("Asis_Compra_Fecha_Vta_Desde"),Date)
            End Get
            Set
                Me("Asis_Compra_Fecha_Vta_Desde") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property Asis_Compra_Fecha_Vta_Hasta() As Date
            Get
                Return CType(Me("Asis_Compra_Fecha_Vta_Hasta"),Date)
            End Get
            Set
                Me("Asis_Compra_Fecha_Vta_Hasta") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Rango_Meses_Vta_Promedio() As Boolean
            Get
                Return CType(Me("Asis_Compra_Rango_Meses_Vta_Promedio"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Rango_Meses_Vta_Promedio") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("12")>  _
        Public Property Asis_Compra_Ultimos_Meses_Vta_Promedio() As Byte
            Get
                Return CType(Me("Asis_Compra_Ultimos_Meses_Vta_Promedio"),Byte)
            End Get
            Set
                Me("Asis_Compra_Ultimos_Meses_Vta_Promedio") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Sumar_Rotacion_Hermanos() As Boolean
            Get
                Return CType(Me("Asis_Compra_Sumar_Rotacion_Hermanos"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Sumar_Rotacion_Hermanos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Rotacion_Con_Ent_Excluidas() As Boolean
            Get
                Return CType(Me("Asis_Compra_Rotacion_Con_Ent_Excluidas"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Rotacion_Con_Ent_Excluidas") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property Asis_Compra_Cantidad_Dias_Ultima_Venta() As Integer
            Get
                Return CType(Me("Asis_Compra_Cantidad_Dias_Ultima_Venta"),Integer)
            End Get
            Set
                Me("Asis_Compra_Cantidad_Dias_Ultima_Venta") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property Asis_Compra_Fecha_Movimientos_Desde() As Date
            Get
                Return CType(Me("Asis_Compra_Fecha_Movimientos_Desde"),Date)
            End Get
            Set
                Me("Asis_Compra_Fecha_Movimientos_Desde") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property Asis_Compra_Fecha_Movimientos_Hasta() As Date
            Get
                Return CType(Me("Asis_Compra_Fecha_Movimientos_Hasta"),Date)
            End Get
            Set
                Me("Asis_Compra_Fecha_Movimientos_Hasta") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property Asis_Compra_TblFiltroProductos() As Global.System.Data.DataTable
            Get
                Return CType(Me("Asis_Compra_TblFiltroProductos"),Global.System.Data.DataTable)
            End Get
            Set
                Me("Asis_Compra_TblFiltroProductos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property Asis_Compra_Productos_Ranking_Input() As Integer
            Get
                Return CType(Me("Asis_Compra_Productos_Ranking_Input"),Integer)
            End Get
            Set
                Me("Asis_Compra_Productos_Ranking_Input") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property Asis_Compra_Proyeccion_Redondeo() As Integer
            Get
                Return CType(Me("Asis_Compra_Proyeccion_Redondeo"),Integer)
            End Get
            Set
                Me("Asis_Compra_Proyeccion_Redondeo") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Asis_Compra_Padre_Asociacion_Productos() As String
            Get
                Return CType(Me("Asis_Compra_Padre_Asociacion_Productos"),String)
            End Get
            Set
                Me("Asis_Compra_Padre_Asociacion_Productos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property Estilo() As Integer
            Get
                Return CType(Me("Estilo"),Integer)
            End Get
            Set
                Me("Estilo") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Codigo")>  _
        Public Property Asis_Compra_Campo_Orden() As String
            Get
                Return CType(Me("Asis_Compra_Campo_Orden"),String)
            End Get
            Set
                Me("Asis_Compra_Campo_Orden") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Ascending")>  _
        Public Property Asis_Compra_Campo_Orden_Orden() As String
            Get
                Return CType(Me("Asis_Compra_Campo_Orden_Orden"),String)
            End Get
            Set
                Me("Asis_Compra_Campo_Orden_Orden") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Asis_Compra_Guardar_Campo_Orden() As Boolean
            Get
                Return CType(Me("Asis_Compra_Guardar_Campo_Orden"),Boolean)
            End Get
            Set
                Me("Asis_Compra_Guardar_Campo_Orden") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Contacto_Origen() As String
            Get
                Return CType(Me("Contacto_Origen"),String)
            End Get
            Set
                Me("Contacto_Origen") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Correo_Origen() As String
            Get
                Return CType(Me("Correo_Origen"),String)
            End Get
            Set
                Me("Correo_Origen") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Direccion_Origen() As String
            Get
                Return CType(Me("Direccion_Origen"),String)
            End Get
            Set
                Me("Direccion_Origen") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Dpto_Origen() As String
            Get
                Return CType(Me("Dpto_Origen"),String)
            End Get
            Set
                Me("Dpto_Origen") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Numero_Origen() As String
            Get
                Return CType(Me("Numero_Origen"),String)
            End Get
            Set
                Me("Numero_Origen") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Telefono_Origen() As String
            Get
                Return CType(Me("Telefono_Origen"),String)
            End Get
            Set
                Me("Telefono_Origen") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Cod_Region_Origen() As String
            Get
                Return CType(Me("Cod_Region_Origen"),String)
            End Get
            Set
                Me("Cod_Region_Origen") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Cod_Comuna_Origen() As String
            Get
                Return CType(Me("Cod_Comuna_Origen"),String)
            End Get
            Set
                Me("Cod_Comuna_Origen") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Cod_Direccion_Origen() As String
            Get
                Return CType(Me("Cod_Direccion_Origen"),String)
            End Get
            Set
                Me("Cod_Direccion_Origen") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.BkSpecialPrograms.My.MySettings
            Get
                Return Global.BkSpecialPrograms.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
