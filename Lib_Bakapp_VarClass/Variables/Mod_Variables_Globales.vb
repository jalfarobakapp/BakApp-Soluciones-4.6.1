Public Module Mod_Variables_Globales

    Public Fm_Demonio As Object ' New Frm_Demonio_01
    Public Fm_Actualizacion As Object ' New Frm_Actualizar_BakApp

    Public _Global_Es_Touch As Boolean
    Public Dst_Licencia_Empresa As Object

    Public _Global_Informe_Venta_Datos_Actualizados As Boolean
    Public _Global_Notificaciones As Boolean = True

    Public RutEmpresaActiva As String

    Public Servidor_SQL As String
    Public Cadena_ConexionSQL_Server As String '= Ruta_conexion(AppPath(True) & "Cadena_conexion.txt")
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

    Public _Global_Version_BakApp As String

    Public EditFrConsultaPre As Boolean
    Public _Global_BaseBk As String


    Public Nombre_funcionario_activo As String
    Public FUNCIONARIO As String
    Public RazonEmpresa As String
    Public RutEmpresa As String
    Public DireccionEmpresa As String


    Public BaseDatos_SQL As String = ""
    Public Usuario_SQL As String = ""
    Public Clave_SQL As String = ""


    Public BaseDeConexion As Integer

    Public sesion As String

#Region "VARIABLES DE CONEXION"

    Public Enum ArchivoConexion As Integer
        BasePrincipal = 1
        BaseDeInterfaz = 2
        BaseLocalSql = 3
    End Enum



#End Region

    Public Modalidad As String
    Public ModEmpresa As String
    Public ModSucursal As String
    Public ModBodega As String
    Public ModCaja As String
    Public ModListaPrecioVenta As String
    Public ModListaPrecioCosto As String

    'Public Cadena_ConexionBkPost As String
    'Public BaseCompacSQL As String '= "BdTmp.sdf"'DbTools.sdf



End Module
