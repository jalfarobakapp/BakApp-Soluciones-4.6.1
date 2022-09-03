Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Cl_Documento

    Dim _New_Idmaeedo As Integer

    Dim _DtsConfig As New DatosBakApp
    Dim _Ds_Documento_Origen As DataSet
    Dim _Tbl_Lector_Codigos As DataTable

    Dim _Fila_Clonada As DataGridViewRow

    Dim _Ds_Matriz_Documentos As New Ds_Matriz_Documentos
    Dim _TblEncabezado As DataTable
    Dim _TblDetalle As DataTable
    Dim _TblObservaciones As DataTable
    Dim _TblEmpaque As DataTable

    Dim _Row_Encabezado_Doc As DataRow
    Dim _Row_Observaciones_Doc As DataRow
    Dim _Row_PermisosNecesarios As DataRow

    'Dim Fr_Alerta_Stock As DevComponents.DotNetBar.Balloon

    Dim _RowEntidad As DataRow
    Dim _RowEntidad_Despacho As DataRow
    Dim _RowEntidad_X_Defecto As DataRow
    Dim _RowEntidad_Soc As DataRow

    Dim _CodVendedor As String

    Dim _RowLista As DataRow
    Dim _RowMoneda_Doc As DataRow

    Dim _ElistaVen As String
    Dim _ElistaCom As String

    Dim _Hay_Descuentos_Individuales As Boolean
    Dim _Hay_Descuentos_Globales As Boolean

    Dim _Precio_Costos_Desde As String

    Dim _Post_Venta As Boolean
    Dim _Es_Ajuste As Boolean

    Dim _Documento_Interno As Boolean

    Dim _Modalidad_Origen As String

    Dim _Idmaeedo_Origen As Integer
    Dim _Editar_documento As Boolean
    Dim _En_Construccion As Boolean

    Dim _Tbl_Series_WMS As DataTable

    Dim _Ruta_Documento_Bkp As String

    Dim _Revisar_Notificacion_Automatica_Remota As Boolean
    Dim _RowRemota_Notificacion As DataRow
    Dim _Revision_Remota As Boolean
    Dim _Autorizado_Remota As Boolean
    Dim _Rechazado_Remota As Boolean
    Dim _Bloquear_Edicion_Detalle As Boolean
    Dim _Preguntar_Si_Receptor_Crea_Documento_Definitivo As Boolean
    Dim _No_Volver_A_Preguntar_Agrupa_Producto As Boolean

    Dim _Codigo_abuscar As String
    Dim _Agrupar_Reemplazos As Boolean
    Dim _Ds_Documento_de_Origen As DataSet
    Dim _Id_Activo As String
    Dim _No_Puede_Ver_Precios As Boolean '= Fx_Tiene_Permiso(Me, "NO00001", , False)


    Dim _Tipo_Documento As csGlobales.Enum_Tipo_Documento
    Dim _Tido As String
    Dim _SubTido As String

    Dim _Cantidad_Origen As Double
    Dim _Precio_Origen As Double

    Dim _Tipo_de_Grabacion As Enum_Tipo_de_Grabacion

    Enum Enum_Tipo_de_Grabacion
        Nuevo_documento
        Editar_documento
    End Enum

    Enum Enum_Neto_Bruto
        Neto
        Bruto
    End Enum

    Dim _TblDocumentos_Dori As DataTable

    Dim _Cerrar_Al_Grabar As Boolean
    Dim _Solicitar_Observaciones_Al_Grabar As Boolean

    Dim _Correr_a_la_derecha As Boolean

    Dim _Revisando_Situacion_Comercial As Boolean
    Dim _Mostrar_Margen As Boolean
    Dim _Mostrar_Costos As Boolean
    Dim _Permiso_Remoto As Boolean

    Dim _Grabar As Boolean

    'Dim _Cl_Soc As Cl_Solicitud_Compra

    Public Property Pro_New_Idmaeedo As Integer
        Get
            Return _New_Idmaeedo
        End Get
        Set(value As Integer)
            _New_Idmaeedo = value
        End Set
    End Property

    Public Property Pro_DtsConfig As DatosBakApp
        Get
            Return _DtsConfig
        End Get
        Set(value As DatosBakApp)
            _DtsConfig = value
        End Set
    End Property

    Public Property Pro_Ds_Documento_Origen As DataSet
        Get
            Return _Ds_Documento_Origen
        End Get
        Set(value As DataSet)
            _Ds_Documento_Origen = value
        End Set
    End Property

    Public Property Pro_Tbl_Lector_Codigos As DataTable
        Get
            Return _Tbl_Lector_Codigos
        End Get
        Set(value As DataTable)
            _Tbl_Lector_Codigos = value
        End Set
    End Property

    Public Property Pro_Fila_Clonada As DataGridViewRow
        Get
            Return _Fila_Clonada
        End Get
        Set(value As DataGridViewRow)
            _Fila_Clonada = value
        End Set
    End Property

    Public Property Pro_Ds_Matriz_Documentos As Ds_Matriz_Documentos
        Get
            Return _Ds_Matriz_Documentos
        End Get
        Set(value As Ds_Matriz_Documentos)
            _Ds_Matriz_Documentos = value
        End Set
    End Property

    Public Property Pro_TblEncabezado As DataTable
        Get
            Return _TblEncabezado
        End Get
        Set(value As DataTable)
            _TblEncabezado = value
        End Set
    End Property

    Public Property Pro_TblDetalle As DataTable
        Get
            Return _TblDetalle
        End Get
        Set(value As DataTable)
            _TblDetalle = value
        End Set
    End Property

    Public Property Pro_TblObservaciones As DataTable
        Get
            Return _TblObservaciones
        End Get
        Set(value As DataTable)
            _TblObservaciones = value
        End Set
    End Property

    Public Property Pro_TblEmpaque As DataTable
        Get
            Return _TblEmpaque
        End Get
        Set(value As DataTable)
            _TblEmpaque = value
        End Set
    End Property

    Public Property Pro_Row_Encabezado_Doc As DataRow
        Get
            Return _Row_Encabezado_Doc
        End Get
        Set(value As DataRow)
            _Row_Encabezado_Doc = value
        End Set
    End Property

    Public Property Pro_Row_Observaciones_Doc As DataRow
        Get
            Return _Row_Observaciones_Doc
        End Get
        Set(value As DataRow)
            _Row_Observaciones_Doc = value
        End Set
    End Property

    Public Property Pro_Row_PermisosNecesarios As DataRow
        Get
            Return _Row_PermisosNecesarios
        End Get
        Set(value As DataRow)
            _Row_PermisosNecesarios = value
        End Set
    End Property

    Public Property Pro_RowEntidad As DataRow
        Get
            Return _RowEntidad
        End Get
        Set(value As DataRow)
            _RowEntidad = value
        End Set
    End Property

    Public Property Pro_RowEntidad_Despacho As DataRow
        Get
            Return _RowEntidad_Despacho
        End Get
        Set(value As DataRow)
            _RowEntidad_Despacho = value
        End Set
    End Property

    Public Property Pro_RowEntidad_X_Defecto As DataRow
        Get
            Return _RowEntidad_X_Defecto
        End Get
        Set(value As DataRow)
            _RowEntidad_X_Defecto = value
        End Set
    End Property

    Public Property Pro_RowEntidad_Soc As DataRow
        Get
            Return _RowEntidad_Soc
        End Get
        Set(value As DataRow)
            _RowEntidad_Soc = value
        End Set
    End Property

    Public Property Pro_CodVendedor As String
        Get
            Return _CodVendedor
        End Get
        Set(value As String)
            _CodVendedor = value
        End Set
    End Property

    Public Property Pro_RowLista As DataRow
        Get
            Return _RowLista
        End Get
        Set(value As DataRow)
            _RowLista = value
        End Set
    End Property

    Public Property Pro_RowMoneda_Doc As DataRow
        Get
            Return _RowMoneda_Doc
        End Get
        Set(value As DataRow)
            _RowMoneda_Doc = value
        End Set
    End Property

    Public Property Pro_ElistaVen As String
        Get
            Return _ElistaVen
        End Get
        Set(value As String)
            _ElistaVen = value
        End Set
    End Property

    Public Property Pro_ElistaCom As String
        Get
            Return _ElistaCom
        End Get
        Set(value As String)
            _ElistaCom = value
        End Set
    End Property

    Public Property Pro_Hay_Descuentos_Individuales As Boolean
        Get
            Return _Hay_Descuentos_Individuales
        End Get
        Set(value As Boolean)
            _Hay_Descuentos_Individuales = value
        End Set
    End Property

    Public Property Pro_Hay_Descuentos_Globales As Boolean
        Get
            Return _Hay_Descuentos_Globales
        End Get
        Set(value As Boolean)
            _Hay_Descuentos_Globales = value
        End Set
    End Property

    Public Property Pro_Precio_Costos_Desde As String
        Get
            Return _Precio_Costos_Desde
        End Get
        Set(value As String)
            _Precio_Costos_Desde = value
        End Set
    End Property

    Public Property Pro_Post_Venta As Boolean
        Get
            Return _Post_Venta
        End Get
        Set(value As Boolean)
            _Post_Venta = value
        End Set
    End Property

    Public Property Pro_Es_Ajuste As Boolean
        Get
            Return _Es_Ajuste
        End Get
        Set(value As Boolean)
            _Es_Ajuste = value
        End Set
    End Property

    Public Property Pro_Documento_Interno As Boolean
        Get
            Return _Documento_Interno
        End Get
        Set(value As Boolean)
            _Documento_Interno = value
        End Set
    End Property

    Public Property Pro_Modalidad_Origen As String
        Get
            Return _Modalidad_Origen
        End Get
        Set(value As String)
            _Modalidad_Origen = value
        End Set
    End Property

    Public Property Pro_Idmaeedo_Origen As Integer
        Get
            Return _Idmaeedo_Origen
        End Get
        Set(value As Integer)
            _Idmaeedo_Origen = value
        End Set
    End Property

    Public Property Pro_Editar_documento As Boolean
        Get
            Return _Editar_documento
        End Get
        Set(value As Boolean)
            _Editar_documento = value
        End Set
    End Property

    Public Property Pro_En_Construccion As Boolean
        Get
            Return _En_Construccion
        End Get
        Set(value As Boolean)
            _En_Construccion = value
        End Set
    End Property

    Public Property Pro_Tbl_Series_WMS As DataTable
        Get
            Return _Tbl_Series_WMS
        End Get
        Set(value As DataTable)
            _Tbl_Series_WMS = value
        End Set
    End Property

    Public Property Pro_Ruta_Documento_Bkp As String
        Get
            Return _Ruta_Documento_Bkp
        End Get
        Set(value As String)
            _Ruta_Documento_Bkp = value
        End Set
    End Property

    Public Property Pro_Revisar_Notificacion_Automatica_Remota As Boolean
        Get
            Return _Revisar_Notificacion_Automatica_Remota
        End Get
        Set(value As Boolean)
            _Revisar_Notificacion_Automatica_Remota = value
        End Set
    End Property

    Public Property Pro_RowRemota_Notificacion As DataRow
        Get
            Return _RowRemota_Notificacion
        End Get
        Set(value As DataRow)
            _RowRemota_Notificacion = value
        End Set
    End Property

    Public Property Pro_Revision_Remota As Boolean
        Get
            Return _Revision_Remota
        End Get
        Set(value As Boolean)
            _Revision_Remota = value
        End Set
    End Property

    Public Property Pro_Autorizado_Remota As Boolean
        Get
            Return _Autorizado_Remota
        End Get
        Set(value As Boolean)
            _Autorizado_Remota = value
        End Set
    End Property

    Public Property Pro_Rechazado_Remota As Boolean
        Get
            Return _Rechazado_Remota
        End Get
        Set(value As Boolean)
            _Rechazado_Remota = value
        End Set
    End Property

    Public Property Pro_Bloquear_Edicion_Detalle As Boolean
        Get
            Return _Bloquear_Edicion_Detalle
        End Get
        Set(value As Boolean)
            _Bloquear_Edicion_Detalle = value
        End Set
    End Property

    Public Property Pro_Preguntar_Si_Receptor_Crea_Documento_Definitivo As Boolean
        Get
            Return _Preguntar_Si_Receptor_Crea_Documento_Definitivo
        End Get
        Set(value As Boolean)
            _Preguntar_Si_Receptor_Crea_Documento_Definitivo = value
        End Set
    End Property

    Public Property Pro_No_Volver_A_Preguntar_Agrupa_Producto As Boolean
        Get
            Return _No_Volver_A_Preguntar_Agrupa_Producto
        End Get
        Set(value As Boolean)
            _No_Volver_A_Preguntar_Agrupa_Producto = value
        End Set
    End Property

    Public Property Pro_Codigo_abuscar As String
        Get
            Return _Codigo_abuscar
        End Get
        Set(value As String)
            _Codigo_abuscar = value
        End Set
    End Property

    Public Property Pro_Agrupar_Reemplazos As Boolean
        Get
            Return _Agrupar_Reemplazos
        End Get
        Set(value As Boolean)
            _Agrupar_Reemplazos = value
        End Set
    End Property

    Public Property Pro_Id_Activo As String
        Get
            Return _Id_Activo
        End Get
        Set(value As String)
            _Id_Activo = value
        End Set
    End Property

    Public Property Pro_No_Puede_Ver_Precios As Boolean
        Get
            Return _No_Puede_Ver_Precios
        End Get
        Set(value As Boolean)
            _No_Puede_Ver_Precios = value
        End Set
    End Property

    Public Property Pro_Tipo_Documento As csGlobales.Enum_Tipo_Documento
        Get
            Return _Tipo_Documento
        End Get
        Set(value As csGlobales.Enum_Tipo_Documento)
            _Tipo_Documento = value
        End Set
    End Property

    Public Property Pro_Tido As String
        Get
            Return _Tido
        End Get
        Set(value As String)
            _Tido = value
        End Set
    End Property

    Public Property Pro_SubTido As String
        Get
            Return _SubTido
        End Get
        Set(value As String)
            _SubTido = value
        End Set
    End Property

    Public Property Pro_Cantidad_Origen As Double
        Get
            Return _Cantidad_Origen
        End Get
        Set(value As Double)
            _Cantidad_Origen = value
        End Set
    End Property

    Public Property Pro_Precio_Origen As Double
        Get
            Return _Precio_Origen
        End Get
        Set(value As Double)
            _Precio_Origen = value
        End Set
    End Property

    Public Property Pro_Tipo_de_Grabacion As Enum_Tipo_de_Grabacion
        Get
            Return _Tipo_de_Grabacion
        End Get
        Set(value As Enum_Tipo_de_Grabacion)
            _Tipo_de_Grabacion = value
        End Set
    End Property

    Public Property Pro_TblDocumentos_Dori As DataTable
        Get
            Return _TblDocumentos_Dori
        End Get
        Set(value As DataTable)
            _TblDocumentos_Dori = value
        End Set
    End Property

    Public Property Pro_Cerrar_Al_Grabar As Boolean
        Get
            Return _Cerrar_Al_Grabar
        End Get
        Set(value As Boolean)
            _Cerrar_Al_Grabar = value
        End Set
    End Property

    Public Property Pro_Solicitar_Observaciones_Al_Grabar As Boolean
        Get
            Return _Solicitar_Observaciones_Al_Grabar
        End Get
        Set(value As Boolean)
            _Solicitar_Observaciones_Al_Grabar = value
        End Set
    End Property

    'Public Property Pro_Cl_Soc As Cl_Solicitud_Compra
    '    Get
    '        Return _Cl_Soc
    '    End Get
    '    Set(value As Cl_Solicitud_Compra)
    '        _Cl_Soc = value
    '    End Set
    'End Property

    Public Sub New()

    End Sub
End Class
