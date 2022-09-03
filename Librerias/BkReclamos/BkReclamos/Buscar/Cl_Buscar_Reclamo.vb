Imports DevComponents.DotNetBar
Public Class Cl_Buscar_Reclamo

    Dim _Numero As String
    Dim _Tbl_Estado As DataTable
    Dim _Tbl_Sub_Estado As DataTable
    Dim _Tbl_Accion As DataTable
    Dim _Fecha_Emision_Desde As Date
    Dim _Fecha_Emision_Hasta As Date
    Dim _Tbl_Tipo_Reclamo As DataTable
    Dim _Tbl_Sub_Tipo_Reclamo As DataTable
    Dim _Tbl_Entidad As DataTable
    Dim _Nombre_Contacto As String
    Dim _Email_Contacto As String
    Dim _Telefono_Contacto As String
    Dim _Tbl_Vendedor As DataTable
    Dim _Tbl_Producto As DataTable
    Dim _Tbl_Suc_Elaboracion As DataTable

    Public Property Numero As String
        Get
            Return _Numero
        End Get
        Set(value As String)
            _Numero = value
        End Set
    End Property

    Public Property Tbl_Estado As DataTable
        Get
            Return _Tbl_Estado
        End Get
        Set(value As DataTable)
            _Tbl_Estado = value
        End Set
    End Property

    Public Property Tbl_Accion As DataTable
        Get
            Return _Tbl_Accion
        End Get
        Set(value As DataTable)
            _Tbl_Accion = value
        End Set
    End Property

    Public Property Tbl_Tipo_Reclamo As DataTable
        Get
            Return _Tbl_Tipo_Reclamo
        End Get
        Set(value As DataTable)
            _Tbl_Tipo_Reclamo = value
        End Set
    End Property

    Public Property Tbl_Sub_Tipo_Reclamo As DataTable
        Get
            Return _Tbl_Sub_Tipo_Reclamo
        End Get
        Set(value As DataTable)
            _Tbl_Sub_Tipo_Reclamo = value
        End Set
    End Property

    Public Property Email_Contacto As String
        Get
            Return _Email_Contacto
        End Get
        Set(value As String)
            _Email_Contacto = value
        End Set
    End Property

    Public Property Telefono_Contacto As String
        Get
            Return _Telefono_Contacto
        End Get
        Set(value As String)
            _Telefono_Contacto = value
        End Set
    End Property

    Public Property Tbl_Vendedor As DataTable
        Get
            Return _Tbl_Vendedor
        End Get
        Set(value As DataTable)
            _Tbl_Vendedor = value
        End Set
    End Property

    Public Property Tbl_Suc_Elaboracion As DataTable
        Get
            Return _Tbl_Suc_Elaboracion
        End Get
        Set(value As DataTable)
            _Tbl_Suc_Elaboracion = value
        End Set
    End Property

    Public Property Nombre_Contacto As String
        Get
            Return _Nombre_Contacto
        End Get
        Set(value As String)
            _Nombre_Contacto = value
        End Set
    End Property

    Public Property Fecha_Emision_Desde As Date
        Get
            Return _Fecha_Emision_Desde
        End Get
        Set(value As Date)
            _Fecha_Emision_Desde = value
        End Set
    End Property

    Public Property Fecha_Emision_Hasta As Date
        Get
            Return _Fecha_Emision_Hasta
        End Get
        Set(value As Date)
            _Fecha_Emision_Hasta = value
        End Set
    End Property

    Public Property Tbl_Entidad As DataTable
        Get
            Return _Tbl_Entidad
        End Get
        Set(value As DataTable)
            _Tbl_Entidad = value
        End Set
    End Property

    Public Property Tbl_Producto As DataTable
        Get
            Return _Tbl_Producto
        End Get
        Set(value As DataTable)
            _Tbl_Producto = value
        End Set
    End Property

    Public Property Tbl_Sub_Estado As DataTable
        Get
            Return _Tbl_Sub_Estado
        End Get
        Set(value As DataTable)
            _Tbl_Sub_Estado = value
        End Set
    End Property
End Class
