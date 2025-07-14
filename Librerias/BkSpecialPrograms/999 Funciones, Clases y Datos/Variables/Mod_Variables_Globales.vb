

Namespace csGlobales
    Public Module Mod_Enum_Listados_Globales

        Enum Enum_Tipo_Documento
            Venta
            Compra
            Guia_Despacho
            Guia_Recepcion
            Guia_Recepcion_Prestamos_GRP_PRE
            Guia_Despacho_Interna
            Guia_Recepcion_Interna
            Nota_De_Credito
            Guia_Traslado_Interno
            Guia_Despacho_Devolucion
            Nota_Venta_Interna
            Cotizacion
            Guia_Devolucion_Prestamo_GDD_PRE
            Guia_Despacho_Prestamo_GDP_PRE
            Guia_Devolucion_Consignaciones_GDD_CON
            Guia_Despacho_Consignaciones_GPD_CON
        End Enum

        Enum Enum_Tipo_de_Grabacion
            Nuevo_documento
            Editar_documento
        End Enum

        Enum Enum_Neto_Bruto
            Neto
            Bruto
        End Enum

    End Module

End Namespace

Public Module Mod_Variables_Globales

    Public Fm_Demonio As Object ' New Frm_Demonio_01
    Public Fm_Actualizacion As Object ' New Frm_Actualizar_BakApp
    Public Fm_Padre_Notificaciones As Form

    Public _Global_Nombre_BakApp_Soluciones As String
    Public _Global_Nombre_BakApp_Notificaciones As String
    Public _Global_Nombre_BakApp_Demonio As String
    Public _Global_Nombre_BakApp_DTEMonitor As String

    Public _Global_Nombre_BakApp_Demonio_Impresion As String
    Public _Global_Nombre_BakApp_Demonio_Correos As String

    Public _Global_Es_Touch As Boolean
    Public Dst_Licencia_Empresa As Object

    Public _Global_Informe_Venta_Datos_Actualizados As Boolean
    Public _Global_Notificaciones As Boolean = True
    Public _Global_Menu_Sol_Compra_Productos_Abierto As Boolean

    Public RutEmpresaActiva As String

    Public Servidor_SQL As String
    Public Cadena_ConexionSQL_Server As String
    Public Cadena_ConexionSQL_Server_Base_Paso As String

    Public Codigo_abuscar As String

    Public KeyReg As String

    'Public BaseDeConexion As Integer

    Public _Version_BakApp As String
    Public _Version_BkCompras As String
    'Public _Version_BKpost As String = FileVersionInfo.GetVersionInfo _
    '                               (Application.StartupPath & "\BKpost.dll").FileVersion

    Public _Version_BkSpecialPrograms As String
    Public _Version_Funciones_BakApp As String
    'Dim _Version_ConsultaPrecios As String = FileVersionInfo.GetVersionInfo _
    '                               (Application.StartupPath & "\BkConsultaPrecios.dll").FileVersion
    Public _Version_BkInformes As String

    Public _Global_Row_EstacionBk As DataRow
    Public _Global_Row_Modalidad As DataRow
    Public _Global_Row_Configuracion_General As DataRow
    Public _Global_Row_Configuracion_Estacion As DataRow
    Public _Global_Row_Configp As DataRow
    Public _Global_Row_Empresa As DataRow

    Public _Global_Frm_Menu As Form

    Public _Global_Version_BakApp As String
    Public _Global_EsDiablito As Boolean

    Public EditFrConsultaPre As Boolean
    Public _Global_BaseBk As String

    Private _global_Thema1 As Enum_Themas

    Private _global_camvasColor1 As Integer
    Private _global_baseColor1 As Integer

    Public Nombre_funcionario_activo As String
    Public FUNCIONARIO As String
    Public RazonEmpresa As String
    Public RutEmpresa As String
    Public DireccionEmpresa As String

    Public BaseDatos_SQL As String = ""
    Public Usuario_SQL As String = ""
    Public Clave_SQL As String = ""

    Public BaseDeConexion As Integer

    Public _Global_Sesion As Boolean

    Public _Global_NombreConexion As String

    'Dim _Rojo As Color
    'Dim _Azul As Color
    'Dim _Verde As Color
    'Dim _Amarillo As Color

#Region "VARIABLES DE CONEXION"

    Public Enum ArchivoConexion As Integer
        BasePrincipal = 1
        BaseDeInterfaz = 2
        BaseLocalSql = 3
    End Enum



#End Region

    Public Mod_Modalidad As String
    Public Mod_Empresa As String
    Public Mod_Sucursal As String
    Public Mod_Bodega As String
    Public Mod_Caja As String
    Public Mod_ListaPrecioVenta As String
    Public Mod_ListaPrecioCosto As String

    Enum Enum_Themas
        Claro
        Gris
        Oscuro
        Azul
        Oscuro_Ligth
        Rojo
        Verde
    End Enum


    Public Property Global_Thema As Enum_Themas
        Get
            Return _global_Thema1 'My.Settings.Estilo
        End Get
        Set(value As Enum_Themas)
            _global_Thema1 = value
        End Set
    End Property

    Public Property Global_baseColor As Integer
        Get
            Return _global_baseColor1
        End Get
        Set(value As Integer)
            _global_baseColor1 = value
        End Set
    End Property

    Public Property Global_camvasColor As Integer
        Get
            Return _global_camvasColor1
        End Get
        Set(value As Integer)
            _global_camvasColor1 = value
        End Set
    End Property

    Public Property Rojo As Color
        Get
            If Global_Thema = Enum_Themas.Oscuro Then
                Return Color.FromArgb(230, 123, 115)  'Rojo mas claro
                'Return Color.FromArgb(225, 104, 93)  'Rojo claro
                'Return Color.FromArgb(255, 182, 193) 'Rosado
                'Return Color.FromArgb(220, 78, 66)   'Rojo
            Else
                Return Color.Red
            End If
        End Get
        Set(value As Color)
            '_Rojo = value
        End Set
    End Property

    Public Property Azul As Color
        Get
            If Global_Thema = Enum_Themas.Oscuro Then
                Return Color.FromArgb(37, 136, 213)
            Else
                Return Color.Blue
            End If
        End Get
        Set(value As Color)
            '_Azul = value
        End Set
    End Property

    Public Property Verde As Color
        Get
            If Global_Thema = Enum_Themas.Oscuro Then
                Return Color.FromArgb(30, 215, 96)
            Else
                Return Color.Green
            End If
        End Get
        Set(value As Color)
            '_Verde = value
        End Set
    End Property

    Public Property Amarillo As Color
        Get
            If Global_Thema = Enum_Themas.Oscuro Then
                Return Color.FromArgb(253, 227, 102)
            Else
                Return Color.Yellow
            End If
        End Get
        Set(value As Color)
            'Amarillo = value
        End Set
    End Property

    Public Property Purpura As Color
        Get
            If Global_Thema = Enum_Themas.Oscuro Then
                Return Color.FromArgb(153, 99, 207)
            Else
                Return Color.Purple
            End If
        End Get
        Set(value As Color)
            'Amarillo = value
        End Set
    End Property

    Public Property Rosado As Color
        Get
            If Global_Thema = Enum_Themas.Oscuro Then
                Return Color.FromArgb(255, 182, 193)
            Else
                Return Color.Pink
            End If
        End Get
        Set(value As Color)
            '_Rojo = value
        End Set
    End Property

End Module

