Imports DevComponents.DotNetBar
Imports System.Data.SqlClient

Public Class Clas_Despacho

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Despacho As Integer
    Dim _Id_Despacho_Padre As Integer
    Dim _Nro_Despacho As String
    Dim _Nro_Sub As String
    Dim _Estado As String

    Dim _Ds_Despacho As DataSet
    Dim _Tbl_Despacho As DataTable
    Dim _Tbl_Despacho_Doc As DataTable
    Dim _Tbl_Despacho_Doc_Det As DataTable
    Dim _Tbl_Despacho_Estados As DataTable
    Dim _Tbl_Lector_Prod_Despachados As DataTable

    Dim _Row_Entidad As DataRow
    Dim _Row_Conf_Despacho As DataRow

    Dim _Error As String

    Dim _Path = AppPath() & "\Data\" & RutEmpresa & "\Tmp\Descargas_BakApp"

    Public Enum Enum_Tipo_Despacho
        Cliente
        Entre_Sucursales
    End Enum

    Enum Enum_Accion
        Nuevo
        Editar
    End Enum

    Dim _Accion As Enum_Accion
    Dim _Desde_Documento As Boolean

    Public Property Id_Despacho As Integer
        Get
            Return _Id_Despacho
        End Get
        Set(value As Integer)
            _Id_Despacho = value
        End Set
    End Property

    Public Property Nro_Despacho As String
        Get
            Return _Nro_Despacho
        End Get
        Set(value As String)
            _Nro_Despacho = value
        End Set
    End Property

    Public Property Ds_Despacho As DataSet
        Get
            Return _Ds_Despacho
        End Get
        Set(value As DataSet)
            _Ds_Despacho = value
        End Set
    End Property

    Public Property Tbl_Despacho As DataTable
        Get
            Return _Tbl_Despacho
        End Get
        Set(value As DataTable)
            _Tbl_Despacho = value
        End Set
    End Property

    Public Property Tbl_Despacho_Doc As DataTable
        Get
            Return _Tbl_Despacho_Doc
        End Get
        Set(value As DataTable)
            _Tbl_Despacho_Doc = value
        End Set
    End Property

    Public Property Tbl_Despacho_Doc_Det As DataTable
        Get
            Return _Tbl_Despacho_Doc_Det
        End Get
        Set(value As DataTable)
            _Tbl_Despacho_Doc_Det = value
        End Set
    End Property

    Public Property Row_Entidad As DataRow
        Get
            Return _Row_Entidad
        End Get
        Set(value As DataRow)
            _Row_Entidad = value
        End Set
    End Property

    Public Property Accion As Enum_Accion
        Get
            Return _Accion
        End Get
        Set(value As Enum_Accion)
            _Accion = value
        End Set
    End Property

    Public Property Tbl_Despacho_Estados As DataTable
        Get
            Return _Tbl_Despacho_Estados
        End Get
        Set(value As DataTable)
            _Tbl_Despacho_Estados = value
        End Set
    End Property

    Public Property Tbl_Lector_Prod_Despachados As DataTable
        Get
            Return _Tbl_Lector_Prod_Despachados
        End Get
        Set(value As DataTable)
            _Tbl_Lector_Prod_Despachados = value
        End Set
    End Property

    Public Property [Error] As String
        Get
            Return _Error
        End Get
        Set(value As String)
            _Error = value
        End Set
    End Property

    Public Property Estado As String
        Get
            Return _Estado
        End Get
        Set(value As String)
            _Estado = value
        End Set
    End Property

    Public Property Desde_Documento As Boolean
        Get
            Return _Desde_Documento
        End Get
        Set(value As Boolean)
            _Desde_Documento = value
        End Set
    End Property

    Public ReadOnly Property Row_Despacho As DataRow
        Get
            If CBool(_Tbl_Despacho.Rows.Count) Then
                Return _Tbl_Despacho.Rows(0)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Property Id_Despacho_Padre As Integer
        Get
            Return _Id_Despacho_Padre
        End Get
        Set(value As Integer)
            _Id_Despacho_Padre = value
        End Set
    End Property

    Public Property Nro_Sub As String
        Get
            Return _Nro_Sub
        End Get
        Set(value As String)
            _Nro_Sub = value
        End Set
    End Property

    Public Property Row_Conf_Despacho As DataRow
        Get
            Return _Row_Conf_Despacho
        End Get
        Set(value As DataRow)
            _Row_Conf_Despacho = value
        End Set
    End Property



    ' Tablas :
    ' Zw_Despachos
    ' Zw_Despachos_Doc
    ' Zw_Despachos_Doc_Det

    Public Sub New(Actualizar_Tablas As Boolean)

        Consulta_sql = "Select ZConf.*,
                            Isnull(Tvta.NombreTabla,'') As Nom_Tipo_Venta,Isnull(NORETI,'') As Nom_Transportista
                            From " & _Global_BaseBk & "Zw_Despachos_Configuracion ZConf
                            Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Tvta On Tvta.Tabla = 'SIS_DESPACHO_TIPO_VENTA' And Tvta.CodigoTabla = Tipo_Venta_X_Defecto
                            Left Join TABRETI On KORETI = Transportista_X_Defecto
                            Where Empresa = '" & Mod_Empresa & "'"
        _Row_Conf_Despacho = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Actualizar_Tablas Then
            Sb_Actualizar_Tabla_Tipo_Envio()
            Sb_Actualizar_Tabla_Tipo_Despacho()
            Sb_Actualizar_Tabla_Estados()
            Sb_Actualizar_Tabla_Tipo_Entrega()
        End If

        _Error = String.Empty

    End Sub

    'Function Fx_Array_Tipo_Envio() As Array

    '    Dim _Array As Array = System.Enum.GetValues(GetType(Enum_Tipo_Envio))
    '    Return _Array

    'End Function

#Region "TIPO ENVIO"

    Sub Sb_Actualizar_Tabla_Tipo_Envio()

        Dim _Tabla = "SIS_DESPACHO_TIPO_ENVIO"
        Dim _DescripcionTabla = "Tipo de envio"

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = '" & _Tabla & "' And CodigoTabla = 'RT'" & vbCrLf &
                       "Delete " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = '" & _Tabla & "' And CodigoTabla = 'DD'" & vbCrLf &
                       "Delete " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = '" & _Tabla & "' And CodigoTabla = 'AG'" & vbCrLf &
                       "Delete " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = '" & _Tabla & "' And CodigoTabla = 'RR'"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','RT','RETIRA CLIENTE')" 'Retiro en tienda
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','DD','DOMICILIO')" ' Despacho a domicilio
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        If _Row_Conf_Despacho.Item("Mostrar_Agencia") Then
            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','AG','AGENCIA')" ' Despacho a agencia/oficina transportista
            _Sql.Ej_consulta_IDU(Consulta_sql, False)
        End If

        If _Row_Conf_Despacho.Item("Mostrar_RetiraTransportista") Then
            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                           "Values ('" & _Tabla & "','" & _DescripcionTabla & "','RR','RETIRA TRANSPORTE')" ' Despacho a agencia/oficina transportista
            _Sql.Ej_consulta_IDU(Consulta_sql, False)
        End If

    End Sub

    Function Fx_Tbl_Tipo_Envio(_Agregar_Fila_En_Blanco As Boolean) As DataTable

        Dim _Condicion = String.Empty

        'Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTabla) Values " &
        '               "('SIS_DESPACHO_TIPO_ENVIO','Tipo de envio','AG','AGENCIA')"
        '_Sql.Ej_consulta_IDU(Consulta_sql, False)

        'Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTabla) Values " &
        '               "Values ('SIS_DESPACHO_TIPO_ENVIO','Tipo de envio','DD','DOMICILIO')"
        '_Sql.Ej_consulta_IDU(Consulta_sql, False)

        'Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTabla) Values " &
        '               "Values ('SIS_DESPACHO_TIPO_ENVIO','Tipo de envio','RT','RETIRA CLIENTE')"
        '_Sql.Ej_consulta_IDU(Consulta_sql, False)


        Dim _Tbl As DataTable

        If _Agregar_Fila_En_Blanco Then
            Consulta_sql = "Select '' As Padre,'' As Hijo Union
                            Select CodigoTabla As Padre,NombreTabla As Hijo From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones 
                            Where Tabla = 'SIS_DESPACHO_TIPO_ENVIO'" & _Condicion
        Else
            Consulta_sql = "Select CodigoTabla As Padre,NombreTabla As Hijo From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones 
                            Where Tabla = 'SIS_DESPACHO_TIPO_ENVIO'" & _Condicion
        End If

        _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

        Return _Tbl

    End Function

#End Region

#Region "TIPO DESPACHO"

    Sub Sb_Actualizar_Tabla_Tipo_Despacho()

        Dim _Tabla = "SIS_DESPACHO_TIPO_DESPACHO"
        Dim _DescripcionTabla = "Tipo de despacho cliente o interno"

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','CLI','CLIENTE')" ' Cliente
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','INT','INTERNO')" ' Interno entre sucursales
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        'Consulta_sql = "Delete " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = '" & _Tabla & "' And CodigoTabla Not IN ('CLI','INT')"
        '_Sql.Ej_consulta_IDU(Consulta_sql, False)

    End Sub

    Function Fx_Tbl_Tipo_Despacho(_Agregar_Fila_En_Blanco As Boolean) As DataTable

        Dim _Tbl As DataTable

        If _Agregar_Fila_En_Blanco Then
            Consulta_sql = "Select '' As Padre,'' As Hijo Union
                            Select CodigoTabla As Padre,NombreTabla As Hijo From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones 
                            Where Tabla = 'SIS_DESPACHO_TIPO_DESPACHO'"
        Else
            Consulta_sql = "Select CodigoTabla As Padre,NombreTabla As Hijo From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones 
                        Where Tabla = 'SIS_DESPACHO_TIPO_DESPACHO'"
        End If

        _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

        Return _Tbl

    End Function

#End Region

#Region "ESTADOS"

    Sub Sb_Actualizar_Tabla_Estados()

        Dim _Tabla = "SIS_DESPACHO_ESTADOS"
        Dim _DescripcionTabla = "Estados"

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','ING','INGRESADO')"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','CON','CONFIRMACION')"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','PRE','PREPARACION')"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','DPR','DESPACHAR (Bulto armado)')"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','DPO','DESPACHADO (Espera cierre)')"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','CIE','CERRADO')"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                "Values ('" & _Tabla & "','" & _DescripcionTabla & "','NUL','NULO')"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        'Consulta_sql = "Delete " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = '" & _Tabla & "' And CodigoTabla Not IN ('ING','CON','PRE','DPR','DPO','CIE','NUL')"
        '_Sql.Ej_consulta_IDU(Consulta_sql, False)

    End Sub

#End Region

#Region "TIPO ENTREGA"

    Sub Sb_Actualizar_Tabla_Tipo_Entrega()

        Dim _Tabla = "SIS_DESPACHO_TIPO_ENTREGA"
        Dim _DescripcionTabla = "Tipo de entrega para llevar al transportista"

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','FUN','FUNCIONARIO DE LA EMPRESA')" ' Cliente
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','TRA','ENTREGADO DIRECTAMENTE AL TRANSPORTISTA')" ' Interno entre sucursales
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','CLI','ENTREGADO AL CLIENTE')" ' Interno entre sucursales
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        'Consulta_sql = "Delete " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = '" & _Tabla & "' And CodigoTabla Not IN ('FUN','TRA','CLI')"
        '_Sql.Ej_consulta_IDU(Consulta_sql, False)

    End Sub

    Function Fx_Tbl_Tipo_Entrega(_Agregar_Fila_En_Blanco As Boolean) As DataTable

        Dim _Tbl As DataTable

        If _Agregar_Fila_En_Blanco Then
            Consulta_sql = "Select '' As Padre,'' As Hijo Union
                            Select CodigoTabla As Padre,NombreTabla As Hijo From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones 
                            Where Tabla = 'SIS_DESPACHO_TIPO_ENTREGA'"
        Else
            Consulta_sql = "Select CodigoTabla As Padre,NombreTabla As Hijo From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones 
                            Where Tabla = 'SIS_DESPACHO_TIPO_ENTREGA'"
        End If

        _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

        Return _Tbl

    End Function

#End Region


    Function Fx_Traer_Listado_Despachos(_Condicion As String) As DataTable

        Dim _Tbl As DataTable

        If Not String.IsNullOrEmpty(_Condicion) Then
            _Condicion = "Where " & _Condicion
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Despachos" & vbCrLf & _Condicion
        _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql, False)

        Return _Tbl

    End Function

    Sub Sb_Nuevo_Despacho()

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Despachos Where 1 < 0
                        Select * From " & _Global_BaseBk & "Zw_Despachos_Doc Where 1 < 0
                        Select * From " & _Global_BaseBk & "Zw_Despachos_Doc_Det Where 1 < 0"
        _Ds_Despacho = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Ds_Despacho.Tables(0).TableName = "Zw_Despachos"
        _Ds_Despacho.Tables(1).TableName = "Zw_Despachos_Doc"
        _Ds_Despacho.Tables(2).TableName = "Zw_Despachos_Doc_Det"

        _Tbl_Despacho = _Ds_Despacho.Tables("Zw_Despachos")
        _Tbl_Despacho_Doc = _Ds_Despacho.Tables("Zw_Despachos_Doc")
        _Tbl_Despacho_Doc_Det = _Ds_Despacho.Tables("Zw_Despachos_Doc_Det")

        Sb_Agregar_Tabla_Lector_Prod_Despachados()

        Dim NewFila As DataRow
        NewFila = _Tbl_Despacho.NewRow
        With NewFila

            .Item("Id_Despacho") = 0
            .Item("Nro_Despacho") = String.Empty
            .Item("Nro_Sub") = String.Empty
            .Item("Empresa") = Mod_Empresa
            .Item("Sucursal") = Mod_Sucursal
            .Item("Bodega") = Mod_Bodega
            .Item("Confirmado") = True
            .Item("Tipo_Despacho") = String.Empty
            .Item("Estado") = String.Empty
            .Item("Referencia") = String.Empty
            .Item("CodEntidad") = String.Empty
            .Item("CodSucEntidad") = String.Empty
            .Item("CodFuncionario") = FUNCIONARIO
            .Item("Rut") = String.Empty
            .Item("Nombre_Entidad") = String.Empty
            .Item("Tipo_Envio") = String.Empty
            .Item("Tipo_Venta") = String.Empty
            .Item("CodPais") = String.Empty
            .Item("CodCiudad") = String.Empty
            .Item("CodComuna") = String.Empty
            .Item("Pais") = String.Empty
            .Item("Ciudad") = String.Empty
            .Item("Comuna") = String.Empty
            .Item("Direccion") = String.Empty
            .Item("Telefono") = String.Empty
            .Item("Email") = String.Empty
            .Item("Transportista") = String.Empty
            .Item("Tipo_Entrega") = String.Empty
            .Item("Transpor_Por_Pagar") = True
            .Item("Entregar_Con_Doc_Pagados") = True
            .Item("Nro_Encomienda") = String.Empty
            .Item("Nombre_Contacto") = String.Empty

            .Item("Tipo_Entrega") = String.Empty
            .Item("CodFuncionario_Transpor") = String.Empty
            .Item("Entregado_Por") = String.Empty
            .Item("Nombre_Transpor") = String.Empty
            .Item("Nro_Encomienda") = String.Empty
            .Item("Observaciones") = String.Empty
            .Item("Id_Despacho_Padre") = 0
            .Item("Sucursal_Retiro") = String.Empty

            .Item("EntregaPaletizada") = False

            _Tbl_Despacho.Rows.Add(NewFila)

        End With

        _Accion = Enum_Accion.Nuevo

    End Sub

    Sub Sb_Cargar_Despacho(Id_Despacho As Integer)

        _Id_Despacho = Id_Despacho

        Consulta_sql = "Select Desp.*,
                        Isnull(Sr.NOKOSU,'') As Nombre_Sucursal_Retiro,
                        Isnull(Sr.DISU,'') As Direccion_Sucursal_Retiro,
                        Isnull(Cmna.NOKOCM,'') As Comuna_Sucursal_Retiro,
                        Isnull(Tr.NORETI,'') As 'Nombre_Transportista',
                        Tdesp.NombreTabla As Nom_Tipo_Despacho,Tenvi.NombreTabla As Nom_Tipo_Envio,Tventa.NombreTabla As Nom_Tipo_Venta,
                        Testa.NombreTabla As Nom_Estado,Desp.Ciudad+', '+Desp.Comuna As Ciudad_Comuna,Tf.NOKOFU As Responsable,
						Isnull(Desp_Padre.CodFuncionario,Desp.CodFuncionario) As CodFuncionario_Crea,
						Isnull(Tf_Padre.NOKOFU,Tf.NOKOFU) As Nombre_Funcionario_Crea,
                        Isnull(Tf_Padre.FOFU,Tf.FOFU) As Fono_Funcionario_Crea,
                        Isnull(Tf_Padre.EMAIL,Tf.EMAIL) As Email_Funcionario_Crea,
                        Isnull(NombreUsuario,'???') As 'NombreUsuario_Crea'
                        
                        From " & _Global_BaseBk & "Zw_Despachos Desp
                        Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Testa On Testa.Tabla = 'SIS_DESPACHO_ESTADOS' And Desp.Estado = Testa.CodigoTabla 
                        Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Tdesp On Tdesp.Tabla = 'SIS_DESPACHO_TIPO_DESPACHO' And Desp.Tipo_Despacho = Tdesp.CodigoTabla 
                        Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Tenvi On Tenvi.Tabla = 'SIS_DESPACHO_TIPO_ENVIO' And Desp.Tipo_Envio = Tenvi.CodigoTabla 
                        Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Tventa On Tventa.Tabla = 'SIS_DESPACHO_TIPO_VENTA' And Desp.Tipo_Venta = Tventa.CodigoTabla 
                        Left Join TABFU Tf On Tf.KOFU = CodFuncionario   
						Left Join TABRETI Tr On Tr.KORETI = Transportista
                        Left Join " & _Global_BaseBk & "Zw_Despachos Desp_Padre On Desp_Padre.Id_Despacho = Desp.Id_Despacho_Padre
						Left Join TABFU Tf_Padre On Tf_Padre.KOFU = Desp_Padre.CodFuncionario 
                        Left Join " & _Global_BaseBk & "Zw_Usuarios ZUs On ZUs.CodFuncionario = Desp_Padre.CodFuncionario 
                        Left Join TABSU Sr On Desp.Empresa = Sr.EMPRESA And Desp.Sucursal_Retiro = Sr.KOSU
                        Left Join TABCM Cmna On Sr.CISU = Cmna.KOCI And Sr.CMSU = Cmna.KOCM
                        Where  Desp.Id_Despacho = " & _Id_Despacho & "

                        Select Doc.*,NOKOEN As Nombre_Entidad,Cast(0 As Bit) As Faltan,Cast(0 As Bit) As Sobran,Cast(0 As Bit) As Correcto,Cast('' As Varchar(100)) As Estado
                        From " & _Global_BaseBk & "Zw_Despachos_Doc Doc
                        Inner Join " & _Global_BaseBk & "Zw_Despachos Despn On Despn.Id_Despacho = Doc.Id_Despacho
                        Left Join MAEEN On KOEN = Despn.CodEntidad And SUEN = Despn.CodSucEntidad
                        Where Doc.Id_Despacho = " & _Id_Despacho & " And Activo = 1

                        Select Det.* From " & _Global_BaseBk & "Zw_Despachos_Doc_Det Det
                        Where Det.Id_Despacho = " & _Id_Despacho & " And Activo = 1

                        Select * From " & _Global_BaseBk & "Zw_Despachos_Estados Where Id_Despacho = " & _Id_Despacho

        _Ds_Despacho = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Ds_Despacho.Tables(0).TableName = "Zw_Despachos"
        _Ds_Despacho.Tables(1).TableName = "Zw_Despachos_Doc"
        _Ds_Despacho.Tables(2).TableName = "Zw_Despachos_Doc_Det"
        _Ds_Despacho.Tables(3).TableName = "Zw_Despachos_Estados"

        Sb_Agregar_Tabla_Lector_Prod_Despachados()

        _Tbl_Despacho = _Ds_Despacho.Tables("Zw_Despachos")

        If Not String.IsNullOrEmpty(_Tbl_Despacho.Rows(0).Item("Observaciones")) Then

            _Tbl_Despacho.Rows(0).Item("Observaciones") = Replace(_Tbl_Despacho.Rows(0).Item("Observaciones"), Chr(13), " ")
            _Tbl_Despacho.Rows(0).Item("Observaciones") = Replace(_Tbl_Despacho.Rows(0).Item("Observaciones"), vbLf, " ")
            _Tbl_Despacho.Rows(0).Item("Observaciones") = Replace(_Tbl_Despacho.Rows(0).Item("Observaciones"), vbCrLf, " ")

        End If

        _Tbl_Despacho_Doc = _Ds_Despacho.Tables("Zw_Despachos_Doc")
        _Tbl_Despacho_Doc_Det = _Ds_Despacho.Tables("Zw_Despachos_Doc_Det")
        _Tbl_Despacho_Estados = _Ds_Despacho.Tables("Zw_Despachos_Estados")

        Dim _CodEntidad As String = _Tbl_Despacho.Rows(0).Item("CodEntidad")
        Dim _SucEntidad As String = _Tbl_Despacho.Rows(0).Item("CodSucEntidad")

        Row_Entidad = Fx_Traer_Datos_Entidad(_CodEntidad, _SucEntidad)

        Id_Despacho_Padre = _Tbl_Despacho.Rows(0).Item("Id_Despacho_Padre")
        Nro_Despacho = _Tbl_Despacho.Rows(0).Item("Nro_Despacho")
        Nro_Sub = _Tbl_Despacho.Rows(0).Item("Nro_Sub")
        Estado = _Tbl_Despacho.Rows(0).Item("Estado")

        _Accion = Enum_Accion.Editar


        Consulta_sql = "Select Desp.*," &
                       "Tdesp.NombreTabla As Nom_Tipo_Despacho,Tenvi.NombreTabla As Nom_Tipo_Envio," &
                       "Testa.NombreTabla As Nom_Estado,Ciudad+', '+Comuna As Ciudad_Comuna,NOKOFU As Responsable
                        Into #Paso_Enc
                        From " & _Global_BaseBk & "Zw_Despachos Desp
                        Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Testa On Testa.Tabla = 'SIS_DESPACHO_ESTADOS' And Desp.Estado = Testa.CodigoTabla 
                        Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Tdesp On Tdesp.Tabla = 'SIS_DESPACHO_TIPO_DESPACHO' And Desp.Tipo_Despacho = Tdesp.CodigoTabla 
                        Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Tenvi On Tenvi.Tabla = 'SIS_DESPACHO_TIPO_ENVIO' And Desp.Tipo_Envio = Tenvi.CodigoTabla 
                        Left Join TABFU On KOFU = CodFuncionario    
                        Where Id_Despacho = " & _Id_Despacho



    End Sub

    Private Sub Sb_Agregar_Tabla_Lector_Prod_Despachados()

        _Tbl_Lector_Prod_Despachados = New DataTable("Zw_Lector_Prod_Despachados")

        'creamos las mismas columnas que hay en el dataset
        _Tbl_Lector_Prod_Despachados.Columns.Add("Codigo_Barras", System.Type.[GetType]("System.String"))
        _Tbl_Lector_Prod_Despachados.Columns.Add("Codigo", System.Type.[GetType]("System.String"))
        _Tbl_Lector_Prod_Despachados.Columns.Add("Descripcion", System.Type.[GetType]("System.String"))
        _Tbl_Lector_Prod_Despachados.Columns.Add("Cantidad", System.Type.[GetType]("System.Double"))
        _Tbl_Lector_Prod_Despachados.Columns.Add("Es_Correcto", System.Type.[GetType]("System.Boolean"))
        _Tbl_Lector_Prod_Despachados.Columns.Add("Cantidad_Documento", System.Type.[GetType]("System.Double"))
        _Tbl_Lector_Prod_Despachados.Columns.Add("Problema", System.Type.[GetType]("System.String"))

        'añadimos la tabla al dataset
        _Ds_Despacho.Tables.Add(_Tbl_Lector_Prod_Despachados)

    End Sub

    Sub Fx_Nuevo_Documento(_Archidrst As String,
                           _Idrst As Integer,
                           _Tido As String,
                           _Nudo As String,
                           _CantC As Double,
                           _CantD As Double,
                           _CantE As Double,
                           _CantR As Double,
                           _Nudonodefi As Boolean)

        Dim _Id_Documentos = 0

        If CBool(_Tbl_Despacho_Doc.Rows.Count) Then
            _Id_Documentos = _Tbl_Despacho_Doc.Rows.Count
        End If

        Dim NewFila As DataRow
        NewFila = _Tbl_Despacho_Doc.NewRow
        With NewFila

            .Item("Id_Documentos") = _Id_Documentos
            .Item("Nro_Despacho") = String.Empty
            .Item("Id_Despacho") = 0
            .Item("Archidrst") = _Archidrst
            .Item("Idrst") = _Idrst
            .Item("Tido") = _Tido
            .Item("Nudo") = _Nudo
            .Item("CantC") = _CantC
            .Item("CantD") = _CantD
            .Item("CantE") = _CantE
            .Item("CantR") = _CantR
            .Item("CantDesp") = 0
            .Item("Activo") = 1
            .Item("Nudonodefi") = _Nudonodefi
            .Item("Id_Documentos_Padre") = 0
            .Item("Reasignado") = False

            _Tbl_Despacho_Doc.Rows.Add(NewFila)

        End With

    End Sub

    Function Fx_Grabar_Documento() As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Id_Despacho As Integer
        Dim _Confirmado As Boolean = Row_Despacho.Item("Confirmado")

        Dim _Nro_Despacho As String = Fx_Nuevo_Nro_Despacho(_Confirmado)

        Dim _Nro_Sub As String = Row_Despacho.Item("Nro_Sub")

        If String.IsNullOrEmpty(_Nro_Sub) Then _Nro_Sub = "001"

        Dim _Empresa As String = Row_Despacho.Item("Empresa")
        Dim _Sucursal As String = Row_Despacho.Item("Sucursal")
        Dim _Bodega As String = Row_Despacho.Item("Bodega")

        Dim _CodFuncionario As String = Row_Despacho.Item("CodFuncionario")

        Dim _Fecha_Emision As DateTime? = Row_Despacho.Item("Fecha_Emision")
        Dim _Fecha_Compromiso As DateTime? = Row_Despacho.Item("Fecha_Compromiso")

        Dim _Fecha_Cierre As DateTime?

        Dim _Tipo_Despacho As String = Row_Despacho.Item("Tipo_Despacho")
        Dim _Tipo_Venta As String = Row_Despacho.Item("Tipo_Venta")
        Dim _Estado As String = Row_Despacho.Item("Estado")
        Dim _Referencia As String = Row_Despacho.Item("Referencia")
        Dim _CodEntidad As String = Row_Despacho.Item("CodEntidad")
        Dim _CodSucEntidad As String = Row_Despacho.Item("CodSucEntidad")
        Dim _Rut As String = Row_Despacho.Item("Rut")
        Dim _Nombre_Entidad As String = Row_Despacho.Item("Nombre_Entidad")
        Dim _Tipo_Envio As String = Row_Despacho.Item("Tipo_Envio")
        Dim _Pais As String = Row_Despacho.Item("Pais")
        Dim _Ciudad As String = Row_Despacho.Item("Ciudad")
        Dim _Comuna As String = Row_Despacho.Item("Comuna")
        Dim _CodPais As String = Row_Despacho.Item("CodPais")
        Dim _CodCiudad As String = Row_Despacho.Item("CodCiudad")
        Dim _CodComuna As String = Row_Despacho.Item("CodComuna")
        Dim _Direccion As String = Row_Despacho.Item("Direccion")
        Dim _Telefono As String = Row_Despacho.Item("Telefono")
        Dim _Email As String = Row_Despacho.Item("Email")
        Dim _Transportista As String = Row_Despacho.Item("Transportista")
        Dim _Tipo_Entrega As String = Row_Despacho.Item("Tipo_Entrega")

        Dim _Transpor_Por_Pagar As Boolean = Row_Despacho.Item("Transpor_Por_Pagar")
        Dim _Entregar_Con_Doc_Pagados As Boolean = Row_Despacho.Item("Entregar_Con_Doc_Pagados")
        Dim _Nro_Encomienda As String = Row_Despacho.Item("Nro_Encomienda")

        Dim _Entregado_Por As String = Row_Despacho.Item("Entregado_Por")
        Dim _Observaciones As String = Replace(Row_Despacho.Item("Observaciones"), "'", "''")
        Dim _Sucursal_Retiro As String = Row_Despacho.Item("Sucursal_Retiro")

        Dim _Nombre_Contacto As String = Row_Despacho.Item("Nombre_Contacto")
        Dim _EntregaPaletizada As Boolean = Row_Despacho.Item("EntregaPaletizada")

        Dim _Id_Despacho_Padre As Integer = Row_Despacho.Item("Id_Despacho_Padre")

        If CBool(_Id_Despacho_Padre) And _Confirmado Then

            _Nro_Despacho = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Despachos", "Nro_Despacho", "Id_Despacho = " & _Id_Despacho_Padre)

        End If

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim _Cn As New SqlConnection

        Try

            _Sql.Sb_Abrir_Conexion(_Cn)
            myTrans = _Cn.BeginTransaction()

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Despachos (Nro_Despacho,Nro_Sub,Confirmado,Empresa,Sucursal,Bodega,CodFuncionario," &
                            "Fecha_Emision,Fecha_Compromiso,Fecha_Cierre," &
                            "Tipo_Despacho,Tipo_Venta,Estado,Referencia,CodEntidad,CodSucEntidad,Rut,Nombre_Entidad," &
                            "Tipo_Envio,Pais,Ciudad,Comuna,Direccion,Telefono,Email,Transportista,Tipo_Entrega," &
                            "Transpor_Por_Pagar,Entregar_Con_Doc_Pagados,Nro_Encomienda," &
                            "Entregado_Por,Observaciones,Id_Despacho_Padre,Sucursal_Retiro,CodPais,CodCiudad,CodComuna,Nombre_Contacto,EntregaPaletizada) Values 
                            ('" & _Nro_Despacho & "','" & _Nro_Sub & "'," & Convert.ToInt32(_Confirmado) & ",'" & _Empresa & "','" & _Sucursal & "','" & _Bodega &
                            "','" & _CodFuncionario & "','" & Format(_Fecha_Emision, "yyyyMMdd HH:mm") & "'," &
                            "'" & Format(_Fecha_Compromiso, "yyyyMMdd") & "','" & Format(_Fecha_Cierre, "yyyyMMdd HH:mm") & "'," & "'" & _Tipo_Despacho & "','" & _Tipo_Venta & "'," &
                            "'" & _Estado & "','" & _Referencia & "','" & _CodEntidad & "','" & _CodSucEntidad & "','" & _Rut & "','" & _Nombre_Entidad & "'," &
                            "'" & _Tipo_Envio & "','" & _Pais & "','" & _Ciudad & "','" & _Comuna & "','" & _Direccion & "','" & _Telefono & "','" & _Email & "','" & _Transportista & "'," &
                            "'" & _Tipo_Entrega & "'," & Convert.ToInt32(_Transpor_Por_Pagar) & "," & Convert.ToInt32(_Entregar_Con_Doc_Pagados) & "," &
                            "'" & _Nro_Encomienda & "','" & _Entregado_Por & "'," &
                            "'" & _Observaciones & "'," & _Id_Despacho_Padre & ",'" & _Sucursal_Retiro & "'," &
                            "'" & _CodPais & "','" & _CodCiudad & "','" & _CodComuna & "','" & _Nombre_Contacto & "'," & Convert.ToInt32(_EntregaPaletizada) & ")"

            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            'Rescatamos el Id_Despacho

            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", _Cn)
            Comando.Transaction = myTrans
            Dim dfd As SqlDataReader = Comando.ExecuteReader()
            While dfd.Read()
                _Id_Despacho = dfd("Identity")
            End While
            dfd.Close()

            If _Id_Despacho_Padre = 0 Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Despachos Set Id_Despacho_Padre = " & _Id_Despacho & " Where Id_Despacho = " & _Id_Despacho_Padre
                Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Despachos_Estados (Id_Despacho,Estado,CodFuncionario,Fecha_Fijacion) Values " &
                           "(" & _Id_Despacho & ",'ING','" & FUNCIONARIO & "',Getdate())"

            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            If Not Desde_Documento Then

                Sb_Insertar_Documentos_y_detalle(_Id_Despacho, _Nro_Despacho, _Empresa, _Sucursal, _Bodega, Comando, myTrans, _Cn)

            End If

            myTrans.Commit()
            _Sql.Sb_Cerrar_Conexion(_Cn)

            Id_Despacho = _Id_Despacho
            Nro_Despacho = _Nro_Despacho

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)
            myTrans.Rollback()

            Return 0

        End Try

    End Function

    Function Fx_Editar_Documento() As Boolean

        'Dim _Row_Despacho As DataRow = _Tbl_Despacho.Rows(0)

        Dim _Id_Despacho As Integer = Id_Despacho

        Dim _Nro_Sub As String = Row_Despacho.Item("Nro_Sub")

        Dim _Empresa As String = Row_Despacho.Item("Empresa")
        Dim _Sucursal As String = Row_Despacho.Item("Sucursal")
        Dim _Bodega As String = Row_Despacho.Item("Sucursal")

        Dim _Confirmado As Boolean = Row_Despacho.Item("Confirmado")

        Dim _CodFuncionario As String = FUNCIONARIO
        Dim _Fecha_Compromiso As DateTime = Row_Despacho.Item("Fecha_Compromiso")

        Dim _Tipo_Despacho As String = Row_Despacho.Item("Tipo_Despacho")
        Dim _Tipo_Venta As String = Row_Despacho.Item("Tipo_Venta")
        Dim _Estado As String = Row_Despacho.Item("Estado")
        Dim _Referencia As String = Row_Despacho.Item("Referencia")
        Dim _CodEntidad As String = Row_Despacho.Item("CodEntidad")
        Dim _CodSucEntidad As String = Row_Despacho.Item("CodSucEntidad")
        Dim _Rut As String = Row_Despacho.Item("Rut")
        Dim _Nombre_Entidad As String = Row_Despacho.Item("Nombre_Entidad")
        Dim _Tipo_Envio As String = Row_Despacho.Item("Tipo_Envio")
        Dim _CodPais As String = Row_Despacho.Item("CodPais")
        Dim _CodCiudad As String = Row_Despacho.Item("CodCiudad")
        Dim _CodComuna As String = Row_Despacho.Item("CodComuna")
        Dim _Pais As String = Row_Despacho.Item("Pais")
        Dim _Ciudad As String = Row_Despacho.Item("Ciudad")
        Dim _Comuna As String = Row_Despacho.Item("Comuna")
        Dim _Direccion As String = Row_Despacho.Item("Direccion")
        Dim _Telefono As String = Row_Despacho.Item("Telefono")
        Dim _Email As String = Row_Despacho.Item("Email")
        Dim _Transportista As String = Row_Despacho.Item("Transportista")
        Dim _Tipo_Entrega As String = Row_Despacho.Item("Tipo_Entrega")

        Dim _Transpor_Por_Pagar As Boolean = Row_Despacho.Item("Transpor_Por_Pagar")
        Dim _Entregar_Con_Doc_Pagados As Boolean = Row_Despacho.Item("Entregar_Con_Doc_Pagados")
        Dim _Nro_Encomienda As String = Row_Despacho.Item("Nro_Encomienda")

        Dim _Observaciones As String = Replace(Row_Despacho.Item("Observaciones"), "'", "''")
        Dim _Sucursal_Retiro As String = Row_Despacho.Item("Sucursal_Retiro")
        Dim _EntregaPaletizada As Boolean = Row_Despacho.Item("EntregaPaletizada")

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Cn As New SqlConnection

        Try

            _Sql.Sb_Abrir_Conexion(_Cn)
            myTrans = _Cn.BeginTransaction()

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Despachos Set
                            Nro_Despacho = '" & _Nro_Despacho & "',
                            Confirmado = " & Convert.ToInt32(_Confirmado) & ",
                            Empresa = '" & _Empresa & "',
                            Sucursal = '" & _Sucursal & "',
                            Bodega = '" & _Bodega & "',
                            CodFuncionario = '" & _CodFuncionario & "',
                            Fecha_Compromiso = '" & Format(_Fecha_Compromiso, "yyyyMMdd") & "',
                            Tipo_Despacho = '" & _Tipo_Despacho & "',
                            Tipo_Venta = '" & _Tipo_Venta & "',
                            Estado = '" & _Estado & "',
                            Referencia = '" & _Referencia & "',
                            CodEntidad = '" & _CodEntidad & "',
                            CodSucEntidad = '" & _CodSucEntidad & "',
                            Rut = '" & _Rut & "',
                            Nombre_Entidad = '" & _Nombre_Entidad & "',
                            Tipo_Envio = '" & _Tipo_Envio & "',
                            CodPais = '" & _CodPais & "',
                            CodCiudad = '" & _CodCiudad & "',
                            CodComuna = '" & _CodComuna & "',
                            Pais = '" & _Pais & "',
                            Ciudad = '" & _Ciudad & "',
                            Comuna = '" & _Comuna & "',
                            Direccion = '" & _Direccion & "',
                            Telefono = '" & _Telefono & "',
                            Email = '" & _Email & "',
                            Transportista = '" & _Transportista & "',
                            Tipo_Entrega = '" & _Tipo_Entrega & "',
                            Transpor_Por_Pagar = " & Convert.ToInt32(_Transpor_Por_Pagar) & ",
                            Entregar_Con_Doc_Pagados = " & Convert.ToInt32(_Entregar_Con_Doc_Pagados) & ",
                            Nro_Encomienda = '" & _Nro_Encomienda & "',
                            Observaciones = '" & _Observaciones & "',
                            Sucursal_Retiro = '" & _Sucursal_Retiro & "',
                            EntregaPaletizada = " & Convert.ToInt32(_EntregaPaletizada) & "
                            Where Id_Despacho = " & _Id_Despacho

            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            'Rescatamos el Id_Despacho

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Despachos_Doc Where Id_Despacho = " & _Id_Despacho & " And Activo = 1" & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Despachos_Doc_Det Where Id_Despacho = " & _Id_Despacho & " And Activo = 1"

            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            If Not Desde_Documento Then

                Sb_Insertar_Documentos_y_detalle(_Id_Despacho, _Nro_Despacho, _Empresa, _Sucursal, _Bodega, Comando, myTrans, _Cn)

            End If

            myTrans.Commit()
            _Sql.Sb_Cerrar_Conexion(_Cn)

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)
            myTrans.Rollback()

        End Try

    End Function

    Function Fx_Anular_Documento() As Boolean

        Dim _Id_Despacho As Integer = Id_Despacho

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Cn As New SqlConnection

        Try

            _Sql.Sb_Abrir_Conexion(_Cn)
            myTrans = _Cn.BeginTransaction()

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Despachos Set Estado = 'NUL' Where Id_Despacho = " & _Id_Despacho & "
                            Delete " & _Global_BaseBk & "Zw_Despachos_Doc Where Id_Despacho = " & _Id_Despacho & "
                            Delete " & _Global_BaseBk & "Zw_Despachos_Doc_Det Where Id_Despacho = " & _Id_Despacho & "
                            Delete " & _Global_BaseBk & "Zw_Despachos_Email_Envios Where Nro_Despacho = '" & _Nro_Despacho & "'
                            Delete " & _Global_BaseBk & "Zw_Despachos_Tom Where Id_Despacho = " & _Id_Despacho

            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            myTrans.Commit()
            _Sql.Sb_Cerrar_Conexion(_Cn)

            _Estado = "NUL"

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)
            myTrans.Rollback()

        End Try

    End Function

    Private Sub Sb_Insertar_Documentos_y_detalle(_Id_Despacho As Integer,
                                                 _Nro_Despacho As String,
                                                 _Empresa As String,
                                                 _Sucursal As String,
                                                 _Bodega As String,
                                                 _Comando As SqlClient.SqlCommand,
                                                 _myTrans As SqlClient.SqlTransaction,
                                                 _Cn As SqlConnection)

        For Each _Fila_Doc As DataRow In _Tbl_Despacho_Doc.Rows

            'Dim _Idmaeedo = _Fila_Doc.Item("Idmaeedo")

            Dim _Archidrst = _Fila_Doc.Item("Archidrst")
            Dim _Idrst = _Fila_Doc.Item("Idrst")
            Dim _Tido = _Fila_Doc.Item("Tido")
            Dim _Nudo = _Fila_Doc.Item("Nudo")
            Dim _CantC = De_Num_a_Tx_01(_Fila_Doc.Item("CantC"), False, 5)
            Dim _CantD = De_Num_a_Tx_01(_Fila_Doc.Item("CantD"), False, 5)
            Dim _CantE = De_Num_a_Tx_01(_Fila_Doc.Item("CantE"), False, 5)
            Dim _Nudonodefi = _Fila_Doc.Item("Nudonodefi")

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Despachos_Doc (Id_Despacho,Nro_Despacho,Archidrst,Idrst,Tido,Nudo,CantC,CantD,CantE,CantR,Nudonodefi) Values " &
                           "(" & _Id_Despacho & ",'" & _Nro_Despacho & "','" & _Archidrst & "'," & _Idrst & ",'" & _Tido & "','" & _Nudo & "'," & _CantC & "," & _CantD & "," & _CantE & ",0," & Convert.ToInt32(_Nudonodefi) & ")"

            _Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            _Comando.Transaction = _myTrans
            _Comando.ExecuteNonQuery()

            If _Archidrst = "MAEEDO" Then

                Dim _Id_Documentos As Integer
                Dim _Idmaeedo As Integer = _Idrst

                _Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", _Cn)
                _Comando.Transaction = _myTrans
                Dim dfd As SqlDataReader = _Comando.ExecuteReader()
                While dfd.Read()
                    _Id_Documentos = dfd("Identity")
                End While
                dfd.Close()

                Dim _SqlWhere = String.Empty

                _SqlWhere = "Where IDMAEEDO = " & _Idmaeedo & " And EMPRESA = '" & _Empresa & "' And SULIDO = '" & _Sucursal & "' And BOSULIDO = '" & _Bodega & "'" & vbCrLf &
                            "And KOPRCT Not In (Select CodigoRd From " & _Global_BaseBk & "Zw_Chilexpress_Conf Where Activo = 1)"

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Despachos_Doc_Det (Id_Documentos,Id_Despacho,Nro_Despacho," &
                               "Empresa,Sucursal,Bodega,Idmaeedo,Idmaeddo,Tido,Nudo,Codigo,Descripcion,Untrans,UdTrans,Rtu," &
                               "CantCUd1,CantDUd1,CantEUd1,CantCUd2,CantDUd2,CantEUd2," &
                               "Archirst,Idrst) 
                                Select " & _Id_Documentos & "," & _Id_Despacho & ",'" & _Nro_Despacho & "'," &
                                "EMPRESA,SULIDO,BOSULIDO,IDMAEEDO,IDMAEDDO,TIDO,NUDO,KOPRCT,NOKOPR,UDTRPR," &
                                "CASE UDTRPR WHEN 1 THEN UD01PR ELSE UD02PR END,RLUDPR," &
                                "CAPRCO1,0,Case TIDO When 'NVV' Then CAPREX1 Else 0 End,CAPRCO2,0,Case TIDO When 'NVV' Then CAPREX2 Else 0 End,
                                Case IDRST When 0 Then '' Else 'Idmaeddo' End,IDRST
                                From MAEDDO" & vbCrLf &
                                _SqlWhere

                _Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                _Comando.Transaction = _myTrans
                _Comando.ExecuteNonQuery()

            End If

        Next

    End Sub

    Function Fx_Insertar_Facturas_VS_Notas_De_Venta_Confirmar() As Boolean

        Dim _Id_Despacho As Integer = Id_Despacho

        Dim _Nro_Sub As String = Row_Despacho.Item("Nro_Sub")

        Dim _Empresa As String = Row_Despacho.Item("Empresa")
        Dim _Sucursal As String = Row_Despacho.Item("Sucursal")
        Dim _Bodega As String = Row_Despacho.Item("Bodega")

        Dim _Observaciones As String = Row_Despacho.Item("Observaciones")

        Consulta_sql = "Select 'MAEEDO' As Archidrst,Edo.IDMAEEDO As Idrst,Edo.TIDO As Tido,Edo.NUDO As Nudo,
                           Sum(Case UDTRPR When 1 Then CAPRCO1 Else CAPRCO2 End) As CantC,
                           Sum(Case UDTRPR When 1 Then CAPRAD1 Else CAPRAD2 End) As CantD,
                           Sum(Case UDTRPR When 1 Then CAPREX1 Else CAPREX2 End) As CantE,
                           NUDONODEFI As Nudonodefi
                           From MAEDDO Ddo
        Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO
                           Where Ddo.IDMAEEDO In
         (Select IDMAEEDO From MAEDDO Where ARCHIRST = 'MAEDDO' And IDRST In (Select IDMAEDDO From MAEDDO Where IDMAEEDO In 
         (Select Idrst From " & _Global_BaseBk & "Zw_Despachos_Doc Where Id_Despacho = " & _Id_Despacho & " And Nudonodefi = 0 And Archidrst = 'MAEEDO')
         And EMPRESA = '" & _Empresa & "' And SULIDO = '" & _Sucursal & "' And BOSULIDO = '" & _Bodega & "'))
                           And Ddo.TIDOPA = 'NVV'  
                           And Ddo.IDMAEEDO Not In (Select Idrst From " & _Global_BaseBk & "Zw_Despachos_Doc Where Id_Despacho = " & _Id_Despacho & ") 
                           And Ddo.EMPRESA = '" & _Empresa & "' And Ddo.SULIDO = '" & _Sucursal & "' And Ddo.BOSULIDO = '" & _Bodega & "' 
                           Group By Edo.IDMAEEDO,Edo.TIDO,Edo.NUDO,Edo.NUDONODEFI"


        _Tbl_Despacho_Doc = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_Tbl_Despacho_Doc.Rows.Count) Then

            Dim myTrans As SqlClient.SqlTransaction
            Dim Comando As SqlClient.SqlCommand

            Dim _Sql2 As New Class_SQL(Cadena_ConexionSQL_Server)
            Dim _Cn As New SqlConnection

            Try

                _Sql2.Sb_Abrir_Conexion(_Cn)
                myTrans = _Cn.BeginTransaction()

                'Rescatamos el Id_Despacho

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Despachos_Doc Set Activo = 0" & vbCrLf & "Where Id_Despacho = " & _Id_Despacho & vbCrLf &
                               "Update " & _Global_BaseBk & "Zw_Despachos_Doc_Det Set Activo = 0 Where Id_Despacho = " & _Id_Despacho

                Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Sb_Insertar_Documentos_y_detalle(_Id_Despacho, _Nro_Despacho, _Empresa, _Sucursal, _Bodega, Comando, myTrans, _Cn)

                'Dim a = 0

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Despachos Set Estado = 'PRE' Where Id_Despacho = " & _Id_Despacho & vbCrLf &
                               "Insert Into " & _Global_BaseBk & "Zw_Despachos_Estados (Id_Despacho,Estado,CodFuncionario,Observacion,Fecha_Fijacion) Values " & vbCrLf &
                               "(" & _Id_Despacho & ",'CON','" & FUNCIONARIO & "','Confirmación automatica, se reemplazan facturas por notas de venta.',Getdate())"

                Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Despachos_Doc_Det Set 
                                CantEUd1 = (Select Isnull(Sum(CantCUd1),0) From " & _Global_BaseBk & "Zw_Despachos_Doc_Det DetFcv Where DetFcv.Idrst = " & _Global_BaseBk & "Zw_Despachos_Doc_Det.Idmaeddo And DetFcv.Id_Despacho = " & _Global_BaseBk & "Zw_Despachos_Doc_Det.Id_Despacho),
                                CantEUd2 = (Select Isnull(Sum(CantCUd2),0) From " & _Global_BaseBk & "Zw_Despachos_Doc_Det DetFcv Where DetFcv.Idrst = " & _Global_BaseBk & "Zw_Despachos_Doc_Det.Idmaeddo And DetFcv.Id_Despacho = " & _Global_BaseBk & "Zw_Despachos_Doc_Det.Id_Despacho)
                                Where Id_Despacho = " & _Id_Despacho & " And Tido = 'NVV' "

                Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Despachos_Doc Set 
                                CantE = (Select Sum(CantEUd1) From " & _Global_BaseBk & "Zw_Despachos_Doc_Det DetNvv Where DetNvv.Id_Despacho = " & _Global_BaseBk & "Zw_Despachos_Doc.Id_Despacho And DetNvv.Idmaeedo = " & _Global_BaseBk & "Zw_Despachos_Doc.Idrst)
                                Where Id_Despacho = " & _Id_Despacho & " And Tido = 'NVV' And Activo = 0"

                Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                'Throw New System.Exception("An exception has occurred.")

                myTrans.Commit()
                _Sql2.Sb_Cerrar_Conexion(_Cn)

                Return True

            Catch ex As Exception

                MsgBox(ex.Message)
                myTrans.Rollback()

            End Try

        End If

    End Function

    Sub Sb_Crear_Desdespachos_Para_Todas_Las_Bodegas_NVV_Facturadas(_Id_Despacho_Padre As Integer)

        Dim _Row_Despacho_Origen As DataRow = Tbl_Despacho.Rows(0)

        Consulta_sql = "Select Distinct Ddo.EMPRESA,Ddo.SULIDO,Ddo.BOSULIDO,Edo.NUDONODEFI 
                        From MAEDDO Ddo
                        Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO
                        Where Ddo.ARCHIRST = 'MAEDDO' And Ddo.IDRST In (
                        Select Idmaeddo From " & _Global_BaseBk & "Zw_Despachos_Doc_Det
                        Where Id_Despacho = " & _Id_Despacho_Padre & ") And Ddo.IDMAEDDO Not In (Select Idmaeddo From " & _Global_BaseBk & "Zw_Despachos_Doc_Det)"

        Dim _Tbl_Bodegas As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Nro_Sub = CInt(_Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Despachos", "Max(Nro_Sub)", "Nro_Despacho = '" & _Nro_Despacho & "'"))

        For Each _Fila_Bodega As DataRow In _Tbl_Bodegas.Rows

            Dim _Empresa = _Fila_Bodega.Item("EMPRESA")
            Dim _Sucursal = _Fila_Bodega.Item("SULIDO")
            Dim _Bodega = _Fila_Bodega.Item("BOSULIDO")

            Consulta_sql = "Select Distinct Edo.IDMAEEDO,Ddo.EMPRESA,Ddo.SULIDO,Ddo.BOSULIDO,Edo.NUDONODEFI 
                            From MAEDDO Ddo
                            Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO
                            Where Ddo.ARCHIRST = 'MAEDDO' And Ddo.IDRST In (
                            Select Idmaeddo From " & _Global_BaseBk & "Zw_Despachos_Doc_Det
                            Where Id_Despacho = " & _Id_Despacho_Padre & ") 
                            And Ddo.IDMAEDDO Not In (Select Idmaeddo From " & _Global_BaseBk & "Zw_Despachos_Doc_Det)
                            And Edo.EMPRESA = '" & _Empresa & "' And SULIDO = '" & _Sucursal & "' And BOSULIDO = '" & _Bodega & "'"

            Dim _Tbl_Maeddo As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim _New_Cl_Despacho As New Clas_Despacho(False)

            _New_Cl_Despacho.Sb_Nuevo_Despacho()

            Dim _Row_Despacho As DataRow = _New_Cl_Despacho.Tbl_Despacho.Rows(0)

            _Nro_Sub += 1
            _Row_Despacho.Item("Nro_Sub") = numero_(_Nro_Sub, 3)

            _Row_Despacho.Item("Empresa") = _Empresa
            _Row_Despacho.Item("Sucursal") = _Sucursal
            _Row_Despacho.Item("Bodega") = _Bodega

            For Each _Fila_Ddo As DataRow In _Tbl_Maeddo.Rows

                Dim _Idmaeedo = _Fila_Ddo.Item("IDMAEEDO")
                Dim _Confirmado = Not _Fila_Ddo.Item("NUDONODEFI")

                _Row_Despacho.Item("Fecha_Emision") = FechaDelServidor()
                _Row_Despacho.Item("Tipo_Despacho") = _Row_Despacho_Origen.Item("Tipo_Despacho")
                _Row_Despacho.Item("Tipo_Venta") = _Row_Despacho_Origen.Item("Tipo_Venta")
                _Row_Despacho.Item("Estado") = _Row_Despacho_Origen.Item("Estado")
                _Row_Despacho.Item("Fecha_Compromiso") = _Row_Despacho_Origen.Item("Fecha_Compromiso")
                _Row_Despacho.Item("Confirmado") = _Confirmado
                _Row_Despacho.Item("Referencia") = _Row_Despacho_Origen.Item("Referencia")
                _Row_Despacho.Item("CodEntidad") = _Row_Despacho_Origen.Item("CodEntidad")
                _Row_Despacho.Item("CodSucEntidad") = _Row_Despacho_Origen.Item("CodSucEntidad")
                _Row_Despacho.Item("Rut") = _Row_Despacho_Origen.Item("Rut")
                _Row_Despacho.Item("Nombre_Entidad") = _Row_Despacho_Origen.Item("Nombre_Entidad")
                _Row_Despacho.Item("Tipo_Envio") = _Row_Despacho_Origen.Item("Tipo_Envio")
                _Row_Despacho.Item("CodPais") = _Row_Despacho_Origen.Item("CodPais")
                _Row_Despacho.Item("CodCiudad") = _Row_Despacho_Origen.Item("CodCiudad")
                _Row_Despacho.Item("CodComuna") = _Row_Despacho_Origen.Item("CodComuna")
                _Row_Despacho.Item("Pais") = _Row_Despacho_Origen.Item("Pais")
                _Row_Despacho.Item("Ciudad") = _Row_Despacho_Origen.Item("Ciudad")
                _Row_Despacho.Item("Comuna") = _Row_Despacho_Origen.Item("Comuna")
                _Row_Despacho.Item("Direccion") = _Row_Despacho_Origen.Item("Direccion")
                _Row_Despacho.Item("Telefono") = _Row_Despacho_Origen.Item("Telefono")
                _Row_Despacho.Item("Email") = _Row_Despacho_Origen.Item("Email")
                _Row_Despacho.Item("Observaciones") = _Row_Despacho_Origen.Item("Observaciones")
                _Row_Despacho.Item("Sucursal_Retiro") = _Row_Despacho_Origen.Item("Sucursal_Retiro")

                _Row_Despacho.Item("Transportista") = _Row_Despacho_Origen.Item("Transportista")
                _Row_Despacho.Item("Transpor_Por_Pagar") = _Row_Despacho_Origen.Item("Transpor_Por_Pagar")
                _Row_Despacho.Item("Entregar_Con_Doc_Pagados") = _Row_Despacho_Origen.Item("Entregar_Con_Doc_Pagados")
                _Row_Despacho.Item("EntregaPaletizada") = _Row_Despacho_Origen.Item("EntregaPaletizada")

                _Row_Despacho.Item("Id_Despacho_Padre") = _Id_Despacho_Padre

                Consulta_sql = "Select 'MAEEDO' As Archidrst,Edo.IDMAEEDO As Idrst,Edo.TIDO As Tido,Edo.NUDO As Nudo,
                                Sum(Case UDTRPR When 1 Then CAPRCO1 Else CAPRCO2 End) As CantC,
                                Sum(Case UDTRPR When 1 Then CAPRAD1 Else CAPRAD2 End) As CantD,
                                Sum(Case UDTRPR When 1 Then CAPREX1 Else CAPREX2 End) As CantE,
                                0 As CantR,
                                NUDONODEFI As Nudonodefi
                                From MAEDDO Ddo
								    Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO
                                Where Edo.IDMAEEDO = " & _Idmaeedo & "
                                And Ddo.EMPRESA = '" & _Empresa & "' And Ddo.SULIDO = '" & _Sucursal & "' And Ddo.BOSULIDO = '" & _Bodega & "'
                                
                                Group By Edo.IDMAEEDO, Edo.TIDO, Edo.NUDO, Edo.NUDONODEFI"

                Dim _Tbl_Maeedo As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                For Each _Fila_Edo As DataRow In _Tbl_Maeedo.Rows

                    Dim _Tido = _Fila_Edo.Item("Tido")
                    Dim _Nudo = _Fila_Edo.Item("Nudo")
                    Dim _CantC = _Fila_Edo.Item("CantC")
                    Dim _CantD = _Fila_Edo.Item("CantD")
                    Dim _CantE = _Fila_Edo.Item("CantE")
                    Dim _CantR = _Fila_Edo.Item("CantR")
                    Dim _Nudonodefi = _Fila_Edo.Item("Nudonodefi")

                    _New_Cl_Despacho.Fx_Nuevo_Documento("MAEEDO", _Idmaeedo, _Tido, _Nudo, _CantC, _CantD, _CantE, _CantR, _Nudonodefi)

                Next

            Next

            _New_Cl_Despacho.Fx_Grabar_Documento()

            _New_Cl_Despacho.Fx_Accion_Confirmacion("CONFIRMACION AUTOMATICA POR FACTURACION DE DOCUMENTO")

        Next

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Despachos_Doc_Det Where Id_Despacho = " & _Id_Despacho
        Dim _Tbl_Documentos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _SqlQuery = String.Empty

        For Each _Fila As DataRow In _Tbl_Documentos.Rows

            Dim _Id_Detalle As Integer = _Fila.Item("Id_Detalle")
            Dim _Idmaeddo As Integer = _Fila.Item("Idmaeddo")

            Dim _CantCUd1 As Double = _Fila.Item("CantCUd1")
            Dim _CantCUd2 As Double = _Fila.Item("CantCUd2")

            Dim _CantDUd1 As Double = _Fila.Item("CantDUd1")
            Dim _CantDUd2 As Double = _Fila.Item("CantDUd2")

            Dim _CantEUd1 As Double = _Fila.Item("CantEUd1")
            Dim _CantEUd2 As Double = _Fila.Item("CantEUd2")

            Dim _CantRUd1 As Double = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Despachos_Doc_Det", "Sum(CantCUd1)", "Archirst = 'Idmaeddo' And Idrst = " & _Idmaeddo, True)
            Dim _CantRUd2 As Double = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Despachos_Doc_Det", "Sum(CantCUd2)", "Archirst = 'Idmaeddo' And Idrst = " & _Idmaeddo, True)

            _SqlQuery += "Update " & _Global_BaseBk & "Zw_Despachos_Doc_Det Set " &
                         "CantRUd1 = " & De_Num_a_Tx_01(_CantRUd1, False, 5) &
                         ",CantRUd2 = " & De_Num_a_Tx_01(_CantRUd2, False, 5) & " Where Id_Detalle = " & _Id_Detalle & vbCrLf

        Next

        If Not String.IsNullOrEmpty(_SqlQuery) Then

            _SqlQuery += vbCrLf & vbCrLf &
                         "Update " & _Global_BaseBk & "Zw_Despachos_Doc Set 
                          CantR = (Select Sum(CantRUd1) From " & _Global_BaseBk & "Zw_Despachos_Doc_Det DetNvv Where DetNvv.Id_Despacho = " & _Global_BaseBk & "Zw_Despachos_Doc.Id_Despacho)
                          Where Id_Despacho = " & _Id_Despacho & " And Tido = 'NVV'" & vbCrLf & vbCrLf

            _SqlQuery += "Update " & _Global_BaseBk & "Zw_Despachos_Doc Set Activo = 0 Where CantC-(CantD+CantE+CantR) = 0 And Id_Despacho = " & _Id_Despacho & vbCrLf &
                         "Update " & _Global_BaseBk & "Zw_Despachos_Doc_Det Set Activo = 0 Where CantCUd1-(CantDUd1+CantEUd1+CantRUd1) = 0 And Id_Despacho = " & _Id_Despacho

            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery) Then

                Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Despachos_Doc", "Id_Despacho = " & _Id_Despacho & " And CantC-(CantD+CantE+CantR) <> 0")

                If Not CBool(_Reg) Then

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Despachos Set " &
                                   "Estado = 'CIN'," &
                                   "Fecha_Cierre = Getdate(),Nro_Encomienda = 'XXX' Where Id_Despacho = " & _Id_Despacho & "

                                   Insert Into " & _Global_BaseBk & "Zw_Despachos_Estados (Id_Despacho,Estado,CodFuncionario,Observacion,Fecha_Fijacion) Values " &
                                   "(" & _Id_Despacho & ",'DPO','" & FUNCIONARIO & "','',Getdate())
                                   Insert Into " & _Global_BaseBk & "Zw_Despachos_Estados (Id_Despacho,Estado,CodFuncionario,Observacion,Fecha_Fijacion) Values " &
                                   "(" & _Id_Despacho & ",'CIE','" & FUNCIONARIO & "','',Getdate())"

                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

            End If

            Dim _Cldespacho_Fx As New Clas_Despacho_Fx
            _Cldespacho_Fx.Fx_Enviar_Correo_Al_Diablito(_Id_Despacho) ', Row_Despacho)

        End If

    End Sub


    Function Fx_Insertar_Facturas_VS_Notas_De_Venta_Facturadas() As Boolean

        Dim _Id_Despacho As Integer = Id_Despacho

        Dim _Nro_Sub As String = Row_Despacho.Item("Nro_Sub")

        Dim _Empresa As String = Row_Despacho.Item("Empresa")
        Dim _Sucursal As String = Row_Despacho.Item("Sucursal")
        Dim _Bodega As String = Row_Despacho.Item("Bodega")

        Dim _Observaciones As String = Row_Despacho.Item("Observaciones")

        Consulta_sql = "Select * From MAEDDO Where ARCHIRST = 'MAEDDO' And IDRST In (
                        Select Idmaeddo From " & _Global_BaseBk & "Zw_Despachos_Doc_Det
                        Where Id_Despacho = " & _Id_Despacho & ") And IDMAEDDO Not In (Select Idmaeddo From " & _Global_BaseBk & "Zw_Despachos_Doc_Det)
                        And TIDO In ('FCV','BLV')"

        _Tbl_Despacho_Doc = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_Tbl_Despacho_Doc.Rows.Count) Then

            Sb_Crear_Desdespachos_Para_Todas_Las_Bodegas_NVV_Facturadas(_Id_Despacho)

            Return True

        End If

    End Function

    Function Fx_Insertar_NVV_Desde_Permisos_Remotos_BakApp(_Idrst As Integer)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Casi_DocEnc Where Id_DocEnc = " & _Idrst
        Dim _Row_DocEnc As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Tido As String = _Row_DocEnc.Item("TipoDoc")
        Dim _Nudo As String = _Row_DocEnc.Item("NroDocumento")
        Dim _CantC As String = De_Num_a_Tx_01(_Row_DocEnc.Item("CantTotal"), False, 5)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Despachos_Doc (Id_Despacho,Archidrst,Idrst,Tido,Nudo,CantC,CantD,CantE,Nudonodefi) Values " &
               "(" & Id_Despacho & ",'Zw_Casi_DocEnc'," & _Idrst & ",'" & _Tido & "','" & _Nudo & "'," & _CantC & ",0,0,0)"
        Return _Sql.Ej_consulta_IDU(Consulta_sql)

    End Function

    Function Fx_Insertar_Despachos_Desde_NVV_Con_Saldo_X_Facturar(_Id_Despacho As Integer, _Nro_Despacho As String) As Boolean ', _Tido As String) As Boolean

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim _Sql2 As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim _Cn As New SqlConnection

        Dim _Nro_Sub As String = numero_(CInt(_Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Despachos", "Max(Nro_Sub)", "Nro_Despacho = '" & _Nro_Despacho & "'")) + 1, 3)

        Dim _Despacho_Estado = String.Empty
        Dim _Estado = String.Empty

        'If _Tido = "NVV" Then

        '    _Estado = "ING"
        '    _Despacho_Estado = "Insert Into " & _Global_BaseBk & "Zw_Despachos_Estados (Id_Despacho,Estado,CodFuncionario,Fecha_Fijacion) Values " &
        '                        "(@Id_Despacho,'ING','ZZZ',Getdate())" & vbCrLf
        'End If

        'If _Tido = "FCV" Or _Tido = "BLV" Then

        _Estado = "PRE"
        _Despacho_Estado = "Insert Into " & _Global_BaseBk & "Zw_Despachos_Estados (Id_Despacho,Estado,CodFuncionario,Fecha_Fijacion) Values " &
                            "(@Id_Despacho,'ING','ZZZ',Getdate())
                                Insert Into " & _Global_BaseBk & "Zw_Despachos_Estados (Id_Despacho,Estado,CodFuncionario,Observacion,Fecha_Fijacion) " &
                            "Values (@Id_Despacho,'CON','ZZZ','Confirmación automatica, reasignación de saldos',Getdate())" & vbCrLf

        'End If


        Try

            _Sql2.Sb_Abrir_Conexion(_Cn)
            myTrans = _Cn.BeginTransaction()

            ' Rescatamos el Id_Despacho
            ' REASIGNACION DE DOCUMENTO A OTRA SUB ORDEN DE TRABAJO.
            ' CantR, CantRUd1 = Cantidad reasignada a otra Sub Orden de despacho

            Consulta_sql = "Declare @Id_Despacho Int 

                           Select @Id_Despacho = " & _Id_Despacho & "

                           Select * Into #Zw_Despachos From " & _Global_BaseBk & "Zw_Despachos Where Id_Despacho = @Id_Despacho
                           Select * Into #Zw_Despachos_Doc From " & _Global_BaseBk & "Zw_Despachos_Doc Where Id_Despacho = @Id_Despacho And Tido In ('BLV','FCV') And CantR <> 0 --And Reasignado = 0
                           Select * Into #Zw_Despachos_Doc_Det From " & _Global_BaseBk & "Zw_Despachos_Doc_Det Where Id_Despacho = @Id_Despacho And Tido In ('BLV','FCV') And CantRUd1 <> 0

                           Update #Zw_Despachos Set Nro_Sub = '" & _Nro_Sub & "',Estado = '" & _Estado & "',Fecha_Emision = Getdate()--,Id_Despacho_Padre = Id_Despacho
                           Update #Zw_Despachos_Doc Set Activo = 1,CantC = CantR,Id_Documentos_Padre = Id_Documentos
                           Update #Zw_Despachos_Doc Set CantE = 0,CantD = 0,CantR = 0
                           
                           Update #Zw_Despachos_Doc_Det Set Archirst = 'Id_Detalle',Idrst = Id_Detalle,Activo = 1
                           Update #Zw_Despachos_Doc_Det Set CantCUd1 = CantRUd1,CantCUd2 = CantRUd2
                           Update #Zw_Despachos_Doc_Det Set CantEUd1 = 0,CantDUd1 = 0,CantEUd2 = 0,CantDUd2 = 0,CantRUd1 = 0,CantRUd2 = 0

                           Update " & _Global_BaseBk & "Zw_Despachos_Doc Set Reasignado = 1 Where Id_Documentos In (Select Id_Documentos From #Zw_Despachos_Doc)

                           Insert Into " & _Global_BaseBk & "Zw_Despachos 

                           Select Id_Despacho_Padre,Nro_Despacho,Nro_Sub,Empresa,Sucursal,Bodega,Confirmado,CodFuncionario,Fecha_Emision,Fecha_Compromiso,Fecha_Despacho,Fecha_Cierre,Tipo_Despacho,Tipo_Envio,Tipo_Venta,Estado,
                           Referencia,CodEntidad,CodSucEntidad,Rut,Nombre_Entidad,Pais,Ciudad,Comuna,Direccion,Telefono,Email,Transportista,Transpor_Por_Pagar,Entregar_Con_Doc_Pagados,Tipo_Entrega,Fecha_Entrega_Transpor,
                           CodFuncionario_Transpor,Entregado_Por,Nombre_Transpor,Nro_Encomienda,Observaciones,EntregaPaletizada 
                           From #Zw_Despachos

                           Select @Id_Despacho = @@IDENTITY 

                           Update #Zw_Despachos_Doc Set Id_Despacho = @Id_Despacho
                           Update #Zw_Despachos_Doc_Det Set Id_Despacho = @Id_Despacho

                           Insert Into " & _Global_BaseBk & "Zw_Despachos_Doc 
                           Select Id_Despacho,Nro_Despacho,Archidrst,Idrst,Tido,Nudo,CantC,CantD,CantR,CantE,CantDesp,Activo,Nudonodefi,Id_Documentos_Padre,Reasignado
                           From #Zw_Despachos_Doc
                           
                           DECLARE @Id_Documentos Int
                           DECLARE Documentos_Doc CURSOR FOR SELECT Id_Documentos FROM " & _Global_BaseBk & "Zw_Despachos_Doc Where Id_Despacho = @Id_Despacho
                           OPEN Documentos_Doc

                           FETCH NEXT FROM Documentos_Doc INTO @Id_Documentos
                           WHILE @@fetch_status = 0
                           BEGIN

                           Insert Into " & _Global_BaseBk & "Zw_Despachos_Doc_Det 
                           Select @Id_Documentos As Id_Documentos,Id_Despacho,Nro_Despacho,Empresa,Sucursal,Bodega,Idmaeedo,Idmaeddo,Tido,Nudo,Codigo,Descripcion,Untrans,UdTrans,Rtu,CantCUd1,CantCUd2,CantDUd1,CantDUd2,
                                  CantEUd1,CantEUd2,DespUd1,DespUd2,CantRUd1,CantRUd2,CodFuncionario_Desp,Archirst,Idrst,Activo
                           FROM #Zw_Despachos_Doc_Det

                           --Select @Id_Documentos
                           FETCH NEXT FROM Documentos_Doc INTO @Id_Documentos
                           END
                           
                           CLOSE Documentos_Doc
                           DEALLOCATE Documentos_Doc

                           " & _Despacho_Estado & " 

                           --Select * From Zw_Despachos
                           --Select * From Zw_Despachos_Doc
                           --Select * From Zw_Despachos_Doc_Det

                           Drop Table #Zw_Despachos
                           Drop Table #Zw_Despachos_Doc
                           Drop Table #Zw_Despachos_Doc_Det"


            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            'Throw New System.Exception("An exception has occurred.")

            myTrans.Commit()
            _Sql2.Sb_Cerrar_Conexion(_Cn)

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)
            myTrans.Rollback()

        End Try

    End Function

#Region "ACCIONES"

    Function Fx_Accion_Confirmacion(_Observacion As String) As Boolean

        Dim _Id_Despacho_Padre = Row_Despacho.Item("Id_Despacho_Padre")

        If Not CBool(_Id_Despacho_Padre) Then
            _Id_Despacho_Padre = _Id_Despacho
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Despachos Where Id_Despacho_Padre = " & _Id_Despacho_Padre & " Or Id_Despacho = " & _Id_Despacho
        Dim _Tbl_Despachos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Consulta_sql = String.Empty

        For Each _Fila As DataRow In _Tbl_Despachos.Rows

            Dim _Id_Despacho = _Fila.Item("Id_Despacho")

            Consulta_sql += "Update " & _Global_BaseBk & "Zw_Despachos Set Estado = 'PRE' Where Id_Despacho = " & _Id_Despacho & "
                             Insert Into " & _Global_BaseBk & "Zw_Despachos_Estados (Id_Despacho,Estado,CodFuncionario,Observacion,Fecha_Fijacion) Values " &
                             "(" & _Id_Despacho & ",'CON','" & FUNCIONARIO & "','" & _Observacion & "',Getdate())" & vbCrLf

        Next

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            Dim _Cldespacho_Fx As New Clas_Despacho_Fx
            _Cldespacho_Fx.Fx_Enviar_Correo_Al_Diablito(_Id_Despacho)

            _Error = String.Empty

            Return True
        Else
            _Error = _Sql.Pro_Error
        End If

    End Function

    Function Fx_Accion_Preparacion(_Observacion As String, _CodFuncionario As String) As Boolean

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Despachos Set Estado = 'DPR' Where Id_Despacho = " & _Id_Despacho & vbCrLf & vbCrLf &
                       "Insert Into " & _Global_BaseBk & "Zw_Despachos_Estados (Id_Despacho,Estado,CodFuncionario,Observacion,Fecha_Fijacion) Values " &
                       "(" & _Id_Despacho & ",'PRE','" & _CodFuncionario & "','" & _Observacion & "',Getdate())" & vbCrLf & vbCrLf

        Dim _CantD As Double
        Dim _CantR As Double
        Dim _Reasignar As Double

        For Each _Fila_Doc As DataRow In _Tbl_Despacho_Doc.Rows

            Dim _Id_Documentos = _Fila_Doc.Item("Id_Documentos")

            _CantD = 0
            _CantR = 0

            For Each _Fila_Det As DataRow In _Tbl_Despacho_Doc_Det.Rows

                Dim _Id_Documentos_H = _Fila_Det.Item("Id_Documentos")

                If _Id_Documentos = _Id_Documentos_H Then

                    Dim _Id_Detalle = _Fila_Det.Item("Id_Detalle")

                    Dim _CantCUd1 As Double = _Fila_Det.Item("CantCUd1")
                    Dim _CantCUd2 As Double = _Fila_Det.Item("CantCUd2")

                    Dim _CantDUd1 As Double = _Fila_Det.Item("CantDUd1")
                    Dim _CantDUd2 As Double = _Fila_Det.Item("CantDUd2")

                    Dim _CantRUd1 As Double = _CantCUd1 - _CantDUd1
                    Dim _CantRUd2 As Double = _CantCUd2 - _CantDUd2

                    _CantD += _CantDUd1
                    _CantR += _CantRUd1

                    Dim _vCantDUd1 = De_Num_a_Tx_01(_CantDUd1, False, 5)
                    Dim _vCantDUd2 = De_Num_a_Tx_01(_CantDUd2, False, 5)

                    Dim _vCantRUd1 = De_Num_a_Tx_01(_CantRUd1, False, 5)
                    Dim _vCantRUd2 = De_Num_a_Tx_01(_CantRUd1, False, 5)

                    Dim _CodFuncionario_Desp = _Fila_Det.Item("CodFuncionario_Desp")

                    Consulta_sql += "Update " & _Global_BaseBk & "Zw_Despachos_Doc_Det Set " &
                                    " CantDUd1 = " & _vCantDUd1 &
                                    ",CantDUd2 = " & _vCantDUd2 &
                                    ",CantRUd1 = " & _vCantRUd1 &
                                    ",CantRUd2 = " & _vCantRUd1 &
                                    ",CodFuncionario_Desp = '" & _CodFuncionario_Desp & "'" & vbCrLf &
                                    "Where Id_Detalle = " & _Id_Detalle & vbCrLf

                End If

            Next

            _Reasignar += _CantR

            Dim _vCantD = De_Num_a_Tx_01(_CantD, False, 5)
            Dim _vCantR = De_Num_a_Tx_01(_CantR, False, 5)

            Consulta_sql += "Update " & _Global_BaseBk & "Zw_Despachos_Doc Set " &
                            " CantD = " & _vCantD &
                            ",CantR = " & _vCantR & vbCrLf &
                            "Where Id_Documentos = " & _Id_Documentos & vbCrLf & vbCrLf

        Next

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            If CBool(_Reasignar) Then

                Dim _Cl_Despacho2 As New Clas_Despacho(False)

                _Cl_Despacho2.Fx_Insertar_Despachos_Desde_NVV_Con_Saldo_X_Facturar(_Id_Despacho, _Nro_Despacho) ', "BLV")

            End If

            '_Estado = "DPR"
            _Error = String.Empty

            Dim _Cldespacho_Fx As New Clas_Despacho_Fx
            _Cldespacho_Fx.Fx_Enviar_Correo_Al_Diablito(_Id_Despacho) ', Row_Despacho)

            Return True

        Else
            _Error = _Sql.Pro_Error
        End If

    End Function

    Function Fx_Accion_Despachado(_Observacion As String) As Boolean

        Dim _Tipo_Entrega = Row_Despacho.Item("Tipo_Entrega")
        Dim _Fecha_Entrega_Transpor = FechaDelServidor()
        Dim _CodFuncionario_Transpor = Row_Despacho.Item("CodFuncionario_Transpor")
        Dim _Entregado_Por = Row_Despacho.Item("Entregado_Por")
        Dim _Nombre_Transpor = Row_Despacho.Item("Nombre_Transpor")

        Dim _Fecha_Cierre = FechaDelServidor()
        Dim _Nro_Encomienda = Row_Despacho.Item("Nro_Encomienda")

        Dim _Cerrado As Boolean

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Despachos Set " &
                       "Estado = 'DPO'," &
                       "Tipo_Entrega = '" & _Tipo_Entrega & "'," &
                       "Fecha_Entrega_Transpor = '" & _Fecha_Entrega_Transpor & "'," &
                       "CodFuncionario_Transpor = '" & _CodFuncionario_Transpor & "'," &
                       "Entregado_Por = '" & _Entregado_Por & "'," &
                       "Nombre_Transpor = '" & _Nombre_Transpor & "' " &
                       "Where Id_Despacho = " & _Id_Despacho & "

                       Insert Into " & _Global_BaseBk & "Zw_Despachos_Estados (Id_Despacho,Estado,CodFuncionario,Observacion,Fecha_Fijacion) Values " &
                       "(" & _Id_Despacho & ",'DPR','" & FUNCIONARIO & "','" & _Observacion & "',Getdate())" & vbCrLf & vbCrLf

        If Not String.IsNullOrEmpty(_Nro_Encomienda) Or _Tipo_Entrega = "CLI" Then

            Consulta_sql += "Update " & _Global_BaseBk & "Zw_Despachos Set " &
                            "Estado = 'CIE'," &
                            "Fecha_Cierre = '" & _Fecha_Cierre & "',Nro_Encomienda = '" & _Nro_Encomienda & "' Where Id_Despacho = " & _Id_Despacho & "

                            Insert Into " & _Global_BaseBk & "Zw_Despachos_Estados (Id_Despacho,Estado,CodFuncionario,Observacion,Fecha_Fijacion) Values " &
                            "(" & _Id_Despacho & ",'DPO','" & FUNCIONARIO & "','" & _Observacion & "',Getdate())
                            Insert Into " & _Global_BaseBk & "Zw_Despachos_Estados (Id_Despacho,Estado,CodFuncionario,Observacion,Fecha_Fijacion) Values " &
                            "(" & _Id_Despacho & ",'CIE','" & FUNCIONARIO & "','Cerrado al momento de despachar.',Getdate())"

            _Cerrado = True

        End If

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            If _Cerrado Then
                _Estado = "CIE"
            Else
                _Estado = "DPO"
            End If
            _Error = String.Empty

            Dim _Cldespacho_Fx As New Clas_Despacho_Fx
            _Cldespacho_Fx.Fx_Enviar_Correo_Al_Diablito(_Id_Despacho) ', Row_Despacho)

            Return True

        Else
            _Error = _Sql.Pro_Error
        End If

    End Function

    Function Fx_Accion_Cerrar_Despachos(_Observacion As String, _Todos As Boolean) As Boolean

        Dim _Fecha_Cierre = FechaDelServidor()

        Dim _Nro_Encomienda = Row_Despacho.Item("Nro_Encomienda")
        Dim _Id_Despacho_Padre = Row_Despacho.Item("Id_Despacho_Padre")

        If _Todos Then
            Consulta_sql = "Select Distinct Id_Despacho 
                            From " & _Global_BaseBk & "Zw_Despachos 
                            Where Nro_Despacho = '" & _Nro_Despacho & "' And Estado = 'DPO'"
        Else
            Consulta_sql = "Select Distinct Id_Despacho 
                            From " & _Global_BaseBk & "Zw_Despachos 
                            Where Id_Despacho = " & _Id_Despacho & " And Estado = 'DPO'"
        End If

        Dim _Tbl_Despachos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Consulta_sql = String.Empty

        For Each _Fila As DataRow In _Tbl_Despachos.Rows

            Dim _Id As Integer = _Fila.Item("Id_Despacho")

            Consulta_sql += "Update " & _Global_BaseBk & "Zw_Despachos Set " &
                            "Estado = 'CIE'," &
                            "Fecha_Cierre = '" & _Fecha_Cierre & "',Nro_Encomienda = '" & _Nro_Encomienda & "' Where Id_Despacho = " & _Id & "

                            Insert Into " & _Global_BaseBk & "Zw_Despachos_Estados (Id_Despacho,Estado,CodFuncionario,Observacion,Fecha_Fijacion) Values " &
                            "(" & _Id & ",'DPO','" & FUNCIONARIO & "','" & _Observacion & "',Getdate())
                            Insert Into " & _Global_BaseBk & "Zw_Despachos_Estados (Id_Despacho,Estado,CodFuncionario,Observacion,Fecha_Fijacion) Values " &
                            "(" & _Id & ",'CIE','" & FUNCIONARIO & "','" & _Observacion & "',Getdate())" & vbCrLf & vbCrLf

        Next

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            _Estado = "CIE"
            _Error = String.Empty

            Row_Despacho.Item("Estado") = _Estado

            Dim _Cldespacho_Fx As New Clas_Despacho_Fx
            _Cldespacho_Fx.Fx_Enviar_Correo_Al_Diablito(_Id_Despacho) ', Row_Despacho)

            Return True
        Else
            _Error = _Sql.Pro_Error
        End If

    End Function

#End Region

    Function Fx_Nuevo_Nro_Despacho(_Confirmado As Boolean) As String

        Dim _NvoNro_Despacho As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _TblPaso = _Sql.Fx_Get_DataTable("Select Max(Nro_Despacho) As Ult_Nro_Despacho" & Space(1) &
                                          "From " & _Global_BaseBk & "Zw_Despachos Where Confirmado = " & Convert.ToInt32(_Confirmado))

        If CBool(_TblPaso.Rows.Count) Then

            Dim _Ult_Nro_OT As String = NuloPorNro(_TblPaso.Rows(0).Item("Ult_Nro_Despacho"), "")

            _NvoNro_Despacho = Fx_Proximo_NroDocumento(_Ult_Nro_OT, 10)

        Else

            _NvoNro_Despacho = numero_(1, 10)

            If Not _Confirmado Then
                _NvoNro_Despacho = ""
            End If

        End If

        If Not _Confirmado And _NvoNro_Despacho = "0000000001" Then
            _NvoNro_Despacho = "P000000001"
        End If

        Return _NvoNro_Despacho

    End Function

    Function Fx_Tomar_Orden_Despacho(_Id_Despacho As Integer, _CodFuncionario As String) As Boolean

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")
        Dim _FechaServidor = Format(FechaDelServidor(), "yyyyMMdd")

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Despachos_Tom Where Id_Despacho = " & _Id_Despacho & " And CodFuncionario = '" & _CodFuncionario & "'
                        Delete " & _Global_BaseBk & "Zw_Despachos_Tom Where NombreEquipo = '" & _NombreEquipo & "' -- And Fecha_Hora < '" & _FechaServidor & "'
                        Insert Into " & _Global_BaseBk & "Zw_Despachos_Tom (Id_Despacho,CodFuncionario,Fecha_Hora,NombreEquipo) Values " & vbCrLf &
                        "(" & _Id_Despacho & ",'" & _CodFuncionario & "',Getdate(),'" & _NombreEquipo & "')"
        Return _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

    End Function

    Function Fx_Soltar_Orden_Despacho(_Id_Despacho As Integer, _CodFuncionario As String) As Boolean

        Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo").ToString.Trim

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Despachos_Tom 
                        Where Id_Despacho = " & _Id_Despacho & " And CodFuncionario = '" & _CodFuncionario & "' And NombreEquipo = '" & _NombreEquipo & "'"
        Return _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

    End Function

    Function Fx_Se_Puede_Editar_La_Orden(_Formulario As Form) As Boolean

        Consulta_sql = "Select *,NOKOFU " & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Despachos_Tom" & vbCrLf &
                       "Left Join TABFU On KOFU = CodFuncionario" & vbCrLf &
                       "Where Id_Despacho = " & _Id_Despacho

        Dim _Row_Despacho_Tom As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Despacho_Tom) Then
            Return True
        Else

            Dim _CodFuncionario = _Row_Despacho_Tom.Item("CodFuncionario")
            Dim _Nokofu = _Row_Despacho_Tom.Item("NOKOFU").ToString.Trim
            Dim _NombreEquipo_Tom = _Row_Despacho_Tom.Item("NombreEquipo").ToString.Trim
            Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo").ToString.Trim

            If _CodFuncionario = FUNCIONARIO And _NombreEquipo_Tom = _NombreEquipo Then

                Return True

            Else

                Dim _Alias = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_EstacionesBkp", "Alias", "NombreEquipo = '" & _NombreEquipo_Tom & "'")

                MessageBoxEx.Show(_Formulario,
                                  "El documento esta siendo utilizado desde la estación de trabajo:" & _NombreEquipo_Tom & " (" & _Alias & ")" & vbCrLf &
                                  "Usuario: " & _Nokofu, "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If

    End Function

    Function Fx_Se_Puede_Confirmar_La_Orden(_Formulario As Form) As Boolean

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Despachos_Doc Set Nudonodefi = (Select NUDONODEFI From MAEEDO Where IDMAEEDO = Idrst)" & Space(1) &
                       "Where Id_Despacho = " & Id_Despacho & " And Nudonodefi = 0 And Archidrst = 'MAEEDO'"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Despachos_Doc",
                                            "Id_Despacho = " & Id_Despacho & " And (Tido = 'NVV' Or Nudonodefi = 1)")

        '_Reg = 0

        If _Reg = 0 Then
            Return True
        Else
            MessageBoxEx.Show(_Formulario, "Existen notas de venta o documentos transitorios, no es posible confirmar la Orden de Despacho", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Function

    Sub Sb_Crear_Desdespacho_Desde_Permiso_Remoto_Aprobado(_Idmaeedo As Integer, _NoIncluirSucursalModalidadEnRetiro As Boolean)

        Try

            Dim _Row_Despacho_Origen As DataRow = Tbl_Despacho.Rows(0)
            Dim Tipo_Envio As String = _Row_Despacho_Origen.Item("Tipo_Envio").ToString.Trim
            Dim _Filtro_Bodegas As String

            If _NoIncluirSucursalModalidadEnRetiro And (Tipo_Envio = "RT" Or Tipo_Envio = "RR") Then
                _Filtro_Bodegas = "And Ddo.SULIDO <> '" & Mod_Sucursal & "'"
            End If

            Consulta_sql = "Select Distinct Edo.IDMAEEDO,Ddo.EMPRESA,Ddo.SULIDO,Ddo.BOSULIDO,Edo.NUDONODEFI 
                            From MAEDDO Ddo
                            Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO
                            Where Edo.IDMAEEDO = " & _Idmaeedo & " And KOPRCT Not In (Select CodigoRd From " & _Global_BaseBk & "Zw_Chilexpress_Conf Where Activo = 1)" & vbCrLf &
                            _Filtro_Bodegas

            Dim _Tbl_Maeddo As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            _Id_Despacho_Padre = 0
            Dim _Nro_Sub = 0

            For Each _Fila_Ddo As DataRow In _Tbl_Maeddo.Rows

                Dim _Empresa = _Fila_Ddo.Item("EMPRESA")
                Dim _Sucursal = _Fila_Ddo.Item("SULIDO")
                Dim _Bodega = _Fila_Ddo.Item("BOSULIDO")
                Dim _Confirmado = Not _Fila_Ddo.Item("NUDONODEFI")

                Dim _New_Cl_Despacho As New Clas_Despacho(False)

                _New_Cl_Despacho.Sb_Nuevo_Despacho()

                Dim _Row_Despacho As DataRow = _New_Cl_Despacho.Tbl_Despacho.Rows(0)

                If _Confirmado Then _Nro_Sub += 1

                _Row_Despacho.Item("Nro_Sub") = numero_(_Nro_Sub, 3)

                _Row_Despacho.Item("Empresa") = _Empresa
                _Row_Despacho.Item("Sucursal") = _Sucursal
                _Row_Despacho.Item("Bodega") = _Bodega

                _Row_Despacho.Item("CodFuncionario") = _Row_Despacho_Origen.Item("CodFuncionario")
                _Row_Despacho.Item("Fecha_Emision") = FechaDelServidor()
                _Row_Despacho.Item("Tipo_Despacho") = _Row_Despacho_Origen.Item("Tipo_Despacho")
                _Row_Despacho.Item("Tipo_Venta") = _Row_Despacho_Origen.Item("Tipo_Venta")
                _Row_Despacho.Item("Estado") = _Row_Despacho_Origen.Item("Estado")
                _Row_Despacho.Item("Fecha_Compromiso") = _Row_Despacho_Origen.Item("Fecha_Compromiso")
                _Row_Despacho.Item("Confirmado") = _Confirmado
                _Row_Despacho.Item("Referencia") = _Row_Despacho_Origen.Item("Referencia")
                _Row_Despacho.Item("CodEntidad") = _Row_Despacho_Origen.Item("CodEntidad")
                _Row_Despacho.Item("CodSucEntidad") = _Row_Despacho_Origen.Item("CodSucEntidad")
                _Row_Despacho.Item("Rut") = _Row_Despacho_Origen.Item("Rut")
                _Row_Despacho.Item("Nombre_Entidad") = _Row_Despacho_Origen.Item("Nombre_Entidad")
                _Row_Despacho.Item("Tipo_Envio") = _Row_Despacho_Origen.Item("Tipo_Envio")
                _Row_Despacho.Item("CodPais") = _Row_Despacho_Origen.Item("CodPais")
                _Row_Despacho.Item("CodCiudad") = _Row_Despacho_Origen.Item("CodCiudad")
                _Row_Despacho.Item("CodComuna") = _Row_Despacho_Origen.Item("CodComuna")
                _Row_Despacho.Item("Pais") = _Row_Despacho_Origen.Item("Pais")
                _Row_Despacho.Item("Ciudad") = _Row_Despacho_Origen.Item("Ciudad")
                _Row_Despacho.Item("Comuna") = _Row_Despacho_Origen.Item("Comuna")
                _Row_Despacho.Item("Direccion") = _Row_Despacho_Origen.Item("Direccion")
                _Row_Despacho.Item("Telefono") = _Row_Despacho_Origen.Item("Telefono")
                _Row_Despacho.Item("Email") = _Row_Despacho_Origen.Item("Email")
                _Row_Despacho.Item("Observaciones") = _Row_Despacho_Origen.Item("Observaciones")
                _Row_Despacho.Item("Nombre_Contacto") = _Row_Despacho_Origen.Item("Nombre_Contacto")

                _Row_Despacho.Item("Transportista") = _Row_Despacho_Origen.Item("Transportista")
                _Row_Despacho.Item("Transpor_Por_Pagar") = _Row_Despacho_Origen.Item("Transpor_Por_Pagar")
                _Row_Despacho.Item("Entregar_Con_Doc_Pagados") = _Row_Despacho_Origen.Item("Entregar_Con_Doc_Pagados")

                _Row_Despacho.Item("Sucursal_Retiro") = _Row_Despacho_Origen.Item("Sucursal_Retiro")
                _Row_Despacho.Item("EntregaPaletizada") = _Row_Despacho_Origen.Item("EntregaPaletizada")


                _Row_Despacho.Item("Id_Despacho_Padre") = _Id_Despacho_Padre

                Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo

                Consulta_sql = "Select 'MAEEDO' As Archidrst,Edo.IDMAEEDO As Idrst,Edo.TIDO As Tido,Edo.NUDO As Nudo,
                                Sum(Case UDTRPR When 1 Then CAPRCO1 Else CAPRCO2 End) As CantC,
                                Sum(Case UDTRPR When 1 Then CAPRAD1 Else CAPRAD2 End) As CantD,
                                Sum(Case UDTRPR When 1 Then CAPREX1 Else CAPREX2 End) As CantE,
                                0 As CantR,
                                NUDONODEFI As Nudonodefi
                                From MAEDDO Ddo
								    Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO
                                Where Edo.IDMAEEDO = " & _Idmaeedo & "
                                And Ddo.EMPRESA = '" & _Empresa & "' And Ddo.SULIDO = '" & _Sucursal & "' And Ddo.BOSULIDO = '" & _Bodega & "'
                                And KOPRCT Not In (Select CodigoRd From " & _Global_BaseBk & "Zw_Chilexpress_Conf Where Activo = 1)

                                Group By Edo.IDMAEEDO, Edo.TIDO, Edo.NUDO, Edo.NUDONODEFI"

                Dim _Tbl_Maeedo As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                For Each _Fila_Edo As DataRow In _Tbl_Maeedo.Rows

                    Dim _Tido = _Fila_Edo.Item("TIDO")
                    Dim _Nudo = _Fila_Edo.Item("NUDO")
                    Dim _CantC = _Fila_Edo.Item("CantC")
                    Dim _CantD = _Fila_Edo.Item("CantD")
                    Dim _CantE = _Fila_Edo.Item("CantE")
                    Dim _CantR = _Fila_Edo.Item("CantR")
                    Dim _Nudonodefi = _Fila_Edo.Item("Nudonodefi")

                    _New_Cl_Despacho.Fx_Nuevo_Documento("MAEEDO", _Idmaeedo, _Tido, _Nudo, _CantC, _CantD, _CantE, _CantR, _Nudonodefi)

                Next

                _New_Cl_Despacho.Fx_Grabar_Documento()

                If _Id_Despacho_Padre = 0 Then
                    _Id_Despacho_Padre = _New_Cl_Despacho.Id_Despacho
                End If

            Next

            Dim _Id_Documentos As Integer = Id_Despacho

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Despachos Where Id_Despacho = " & Id_Despacho & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Despachos_Doc Where Id_Despacho = " & Id_Despacho
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Id_Despacho = 0

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Problema al crear el despacho", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Sub Sb_Crear_Desdespachos_Para_Todas_Las_Bodegas(_Id_Despacho As Integer, ByRef _Id_Despacho_Padre As Integer)

        Dim _Row_Despacho_Origen As DataRow = Tbl_Despacho.Rows(0)

        Consulta_sql = "Select Distinct Ddo.EMPRESA,Ddo.SULIDO,Ddo.BOSULIDO,Edo.NUDONODEFI 
                        From MAEDDO Ddo
                        Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO
                        Where Edo.IDMAEEDO In (Select Idrst From " & _Global_BaseBk & "Zw_Despachos_Doc Where Id_Despacho = " & _Id_Despacho & ")"
        Dim _Tbl_Bodegas As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Nro_Sub = 0

        For Each _Fila_Bodega As DataRow In _Tbl_Bodegas.Rows

            Dim _Empresa = _Fila_Bodega.Item("EMPRESA")
            Dim _Sucursal = _Fila_Bodega.Item("SULIDO")
            Dim _Bodega = _Fila_Bodega.Item("BOSULIDO")

            Consulta_sql = "Select Distinct Edo.IDMAEEDO,Ddo.EMPRESA,Ddo.SULIDO,Ddo.BOSULIDO,Edo.NUDONODEFI 
                            From MAEDDO Ddo
                            Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO
                            Where Edo.IDMAEEDO In (Select Idrst From " & _Global_BaseBk & "Zw_Despachos_Doc Where Id_Despacho = " & _Id_Despacho & ")
                            And Edo.EMPRESA = '" & _Empresa & "' And SULIDO = '" & _Sucursal & "' And BOSULIDO = '" & _Bodega & "'"
            Dim _Tbl_Maeddo As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim _New_Cl_Despacho As New Clas_Despacho(False)

            _New_Cl_Despacho.Sb_Nuevo_Despacho()

            Dim _Row_Despacho As DataRow = _New_Cl_Despacho.Tbl_Despacho.Rows(0)

            _Nro_Sub += 1
            _Row_Despacho.Item("Nro_Sub") = numero_(_Nro_Sub, 3)

            _Row_Despacho.Item("Empresa") = _Empresa
            _Row_Despacho.Item("Sucursal") = _Sucursal
            _Row_Despacho.Item("Bodega") = _Bodega

            For Each _Fila_Ddo As DataRow In _Tbl_Maeddo.Rows

                Dim _Idmaeedo = _Fila_Ddo.Item("IDMAEEDO")
                Dim _Confirmado = Not _Fila_Ddo.Item("NUDONODEFI")

                _Row_Despacho.Item("Fecha_Emision") = FechaDelServidor()
                _Row_Despacho.Item("Tipo_Despacho") = _Row_Despacho_Origen.Item("Tipo_Despacho")
                _Row_Despacho.Item("Tipo_Venta") = _Row_Despacho_Origen.Item("Tipo_Venta")
                _Row_Despacho.Item("Estado") = _Row_Despacho_Origen.Item("Estado")
                _Row_Despacho.Item("Fecha_Compromiso") = _Row_Despacho_Origen.Item("Fecha_Compromiso")
                _Row_Despacho.Item("Confirmado") = _Confirmado
                _Row_Despacho.Item("Referencia") = _Row_Despacho_Origen.Item("Referencia")
                _Row_Despacho.Item("CodEntidad") = _Row_Despacho_Origen.Item("CodEntidad")
                _Row_Despacho.Item("CodSucEntidad") = _Row_Despacho_Origen.Item("CodSucEntidad")
                _Row_Despacho.Item("Rut") = _Row_Despacho_Origen.Item("Rut")
                _Row_Despacho.Item("Nombre_Entidad") = _Row_Despacho_Origen.Item("Nombre_Entidad")
                _Row_Despacho.Item("Tipo_Envio") = _Row_Despacho_Origen.Item("Tipo_Envio")
                _Row_Despacho.Item("CodPais") = _Row_Despacho_Origen.Item("CodPais")
                _Row_Despacho.Item("CodCiudad") = _Row_Despacho_Origen.Item("CodCiudad")
                _Row_Despacho.Item("CodComuna") = _Row_Despacho_Origen.Item("CodComuna")
                _Row_Despacho.Item("Pais") = _Row_Despacho_Origen.Item("Pais")
                _Row_Despacho.Item("Ciudad") = _Row_Despacho_Origen.Item("Ciudad")
                _Row_Despacho.Item("Comuna") = _Row_Despacho_Origen.Item("Comuna")
                _Row_Despacho.Item("Direccion") = _Row_Despacho_Origen.Item("Direccion")
                _Row_Despacho.Item("Telefono") = _Row_Despacho_Origen.Item("Telefono")
                _Row_Despacho.Item("Email") = _Row_Despacho_Origen.Item("Email")
                _Row_Despacho.Item("Observaciones") = _Row_Despacho_Origen.Item("Observaciones")
                _Row_Despacho.Item("Nombre_Contacto") = _Row_Despacho_Origen.Item("Nombre_Contacto")

                _Row_Despacho.Item("Transportista") = _Row_Despacho_Origen.Item("Transportista")
                _Row_Despacho.Item("Transpor_Por_Pagar") = _Row_Despacho_Origen.Item("Transpor_Por_Pagar")
                _Row_Despacho.Item("Entregar_Con_Doc_Pagados") = _Row_Despacho_Origen.Item("Entregar_Con_Doc_Pagados")
                _Row_Despacho.Item("EntregaPaletizada") = _Row_Despacho_Origen.Item("EntregaPaletizada")

                _Row_Despacho.Item("Id_Despacho_Padre") = _Id_Despacho_Padre

                Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo

                Consulta_sql = "Select 'MAEEDO' As Archidrst,Edo.IDMAEEDO As Idrst,Edo.TIDO As Tido,Edo.NUDO As Nudo,
                                Sum(Case UDTRPR When 1 Then CAPRCO1 Else CAPRCO2 End) As CantC,
                                Sum(Case UDTRPR When 1 Then CAPRAD1 Else CAPRAD2 End) As CantD,
                                Sum(Case UDTRPR When 1 Then CAPREX1 Else CAPREX2 End) As CantE,
                                0 As CantR,
                                NUDONODEFI As Nudonodefi
                                From MAEDDO Ddo
								    Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO
                                Where Edo.IDMAEEDO = " & _Idmaeedo & "
                                And Ddo.EMPRESA = '" & _Empresa & "' And Ddo.SULIDO = '" & _Sucursal & "' And Ddo.BOSULIDO = '" & _Bodega & "'
                                
                                Group By Edo.IDMAEEDO, Edo.TIDO, Edo.NUDO, Edo.NUDONODEFI"

                Dim _Tbl_Maeedo As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                For Each _Fila_Edo As DataRow In _Tbl_Maeedo.Rows

                    Dim _Tido = _Fila_Edo.Item("Tido")
                    Dim _Nudo = _Fila_Edo.Item("Nudo")
                    Dim _CantC = _Fila_Edo.Item("CantC")
                    Dim _CantD = _Fila_Edo.Item("CantD")
                    Dim _CantE = _Fila_Edo.Item("CantE")
                    Dim _CantR = _Fila_Edo.Item("CantR")
                    Dim _Nudonodefi = _Fila_Edo.Item("Nudonodefi")

                    _New_Cl_Despacho.Fx_Nuevo_Documento("MAEEDO", _Idmaeedo, _Tido, _Nudo, _CantC, _CantD, _CantE, _CantR, _Nudonodefi)

                Next

            Next

            _New_Cl_Despacho.Fx_Grabar_Documento()

            If _Id_Despacho_Padre = 0 Then
                _Id_Despacho_Padre = _New_Cl_Despacho.Id_Despacho
            End If

        Next

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Despachos Where Id_Despacho = " & Id_Despacho & vbCrLf &
                       "Delete " & _Global_BaseBk & "Zw_Despachos_Doc Where Id_Despacho = " & Id_Despacho & vbCrLf &
                       "Delete " & _Global_BaseBk & "Zw_Despachos_Doc_Det Where Id_Despacho = " & Id_Despacho
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Id_Despacho = 0

    End Sub

    Function Fx_Enviar_Correo(_Nombre_Correo As String,
                              _Para As String,
                              _Asunto As String,
                              _Cc As String,
                              _Estado As String,
                              ByRef _Error As String) As Boolean

        Dim _Enviar = True

        Dim _Adjuntar_Documento = CBool(_Tbl_Despacho_Doc.Rows.Count)
        Dim _Archivos_Adjuntos(_Tbl_Despacho_Doc.Rows.Count - 1) As String

        If _Adjuntar_Documento Then


            Dim _i = 0

            For Each _FDdo As DataRow In _Tbl_Despacho_Doc.Rows

                Dim _Idmaeedo = _FDdo.Item("Idrst")
                Dim _Tido = _FDdo.Item("Tido")
                Dim _Nudo = _FDdo.Item("Nudo")
                Dim _NombreFormato = "Electronica tam. carta"

                'Dim _Subtido As String = _Sql.Fx_Trae_Dato("MAEEDO", "SUBTIDO", "IDMAEEDO = " & _Idmaeedo)

                Dim _Pdf_Adjunto As New Clas_PDF_Crear_Documento(_Idmaeedo,
                                                                 _Tido,
                                                                 _NombreFormato,
                                                                 _Tido & "-" & _Nudo,
                                                                 _Path, _Tido & "-" & _Nudo, False)

                _Pdf_Adjunto.Sb_Crear_PDF("", False, _Pdf_Adjunto.Pro_Nombre_Archivo)

                Dim _Error_Pdf = _Pdf_Adjunto.Pro_Error
                Dim _Existe_File = System.IO.File.Exists(_Pdf_Adjunto.Pro_Full_Path_Archivo_PDF & "\" & _Pdf_Adjunto.Pro_Nombre_Archivo & ".pdf")

                If _Existe_File Then
                    _Archivos_Adjuntos(_i) = _Pdf_Adjunto.Pro_Full_Path_Archivo_PDF & "\" & _Pdf_Adjunto.Pro_Nombre_Archivo & ".pdf"
                End If

                _i += 1

            Next

        End If

        Dim _Crea_Html As New Clase_Crear_Documento_Htm
        Dim _Ruta_Html As String = AppPath() & "\Data\" & RutEmpresa & "\Tmp"

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Correos" & vbCrLf &
                       "Where Nombre_Correo = '" & _Nombre_Correo & "'"
        Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If _Row_Correo IsNot Nothing Then

            Dim _Remitente = Trim(_Row_Correo.Item("Remitente"))

            Dim _Host = _Row_Correo.Item("Host")
            Dim _Puerto = _Row_Correo.Item("Puerto")
            Dim _Contrasena = Trim(_Row_Correo.Item("Contrasena"))

            Dim _CuerpoMensaje = _Row_Correo.Item("CuerpoMensaje")
            _CuerpoMensaje = Replace(_CuerpoMensaje, Chr(13), "<br/>")

            Dim _SSL = _Row_Correo.Item("SSL")

            If String.IsNullOrEmpty(_Asunto) Then
                _Asunto = "Envío de correo automático por BakApp…Sistema de Reclamos"
            End If

            Dim EnviarCorreo As New Frm_Correos_Conf

            Dim _Correo_Enviado As Boolean = EnviarCorreo.Fx_Enviar_Mail(_Host,
                                                                         _Remitente,
                                                                         _Contrasena,
                                                                         _Para,
                                                                         _Cc,
                                                                         _Asunto,
                                                                         _CuerpoMensaje,
                                                                         _Archivos_Adjuntos,
                                                                         _Puerto,
                                                                         _SSL,
                                                                         False)

            _Error = EnviarCorreo.Pro_Error
            _Error = Replace(_Error, "'", "''")
            EnviarCorreo.Dispose()

            Return _Correo_Enviado

        End If

    End Function

    Function Fx_Traer_Encabezado_Documento() As DataRow

        Dim _Empresa As String = Row_Despacho.Item("Empresa")
        Dim _Sucursal As String = Row_Despacho.Item("Sucursal")
        Dim _Bodega As String = Row_Despacho.Item("Bodega")

        Consulta_sql = "Select 'MAEEDO' As Archidrst,Edo.IDMAEEDO As Idrst,Edo.TIDO As Tido,Edo.NUDO As Nudo,
                           Sum(Case UDTRPR When 1 Then CAPRCO1 Else CAPRCO2 End) As CantC,
                           Sum(Case UDTRPR When 1 Then CAPRAD1 Else CAPRAD2 End) As CantD,
                           Sum(Case UDTRPR When 1 Then CAPREX1 Else CAPREX2 End) As CantE,
                           NUDONODEFI As Nudonodefi
                           From MAEDDO Ddo
                           Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO
                           Where Ddo.IDMAEEDO In
                           (Select Idrst From " & _Global_BaseBk & "Zw_Despachos_Doc Where Id_Despacho = " & _Id_Despacho & " And Nudonodefi = 0 And Archidrst = 'MAEEDO')
                            And IDMAEDDO In (Select IDRST From MAEDDO Where ARCHIRST = 'MAEDDO') 
                            And Edo.EMPRESA = '" & _Empresa & "' And Ddo.SULIDO = '" & _Sucursal & "' And Ddo.BOSULIDO = '" & _Bodega & "'
                            Group By Edo.IDMAEEDO,Edo.TIDO,Edo.NUDO,Edo.NUDONODEFI"

        Dim _Row_Encabezado As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Return _Row_Encabezado

    End Function

End Class
