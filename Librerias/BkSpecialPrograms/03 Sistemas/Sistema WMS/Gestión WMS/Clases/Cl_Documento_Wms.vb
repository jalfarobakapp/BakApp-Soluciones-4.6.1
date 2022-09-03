Imports DevComponents.DotNetBar

Public Class Cl_Documento_Wms

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Id_Tag As Integer
    Private _Ds_Documento As DataSet


    Public Property Id_Tag() As Integer
        Get
            Return _Id_Tag
        End Get
        Set(ByVal value As Integer)
            _Id_Tag = value
        End Set
    End Property

    Public Property Ds_Documento As DataSet
        Get
            Return _Ds_Documento
        End Get
        Set(value As DataSet)
            _Ds_Documento = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Sub Sb_Cargar_Documento()

        Consulta_sql = "Select Id_Tag,Tipo_Tag,Nro_Tag,Idmaeedo_Ing,Tipo_Ing,Nudo_Ing,Fecha_Ingreso,Fecha_Hora_Ingreso,CodFuncionario," &
                       "Total_Items,Total_CantUd1,Total_CantUd2,Nro_Referencia,Nro_Pallet,Nro_Lote
                        From " & _Global_BaseBk & "Zw_WMS_Ingreso_Enc 
                        Where Id_Tag = " & Id_Tag & "
                        Select Id,Id_Tag,Nro_Tag,Empresa,Sucursal,Bodega,Id_Mapa,Codigo_Sector,Codigo_Ubic,Nro_Pallet,Codigo_Pqte," &
                       "Descripcion_Pqte,Codigo_Sku,Descripcion_Sku,CantUd1,CantUd2,Nro_Lote,Fecha_Vencimiento
                       From " & _Global_BaseBk & "Zw_WMS_Ingreso_Det 
                       Where Id_Tag = " & Id_Tag

        Ds_Documento = _Sql.Fx_Get_DataSet(Consulta_sql)

    End Sub

    Function Fx_Crear_Documeto() As Boolean


    End Function

    Function Fx_Editar_Documento() As Boolean

    End Function

End Class
