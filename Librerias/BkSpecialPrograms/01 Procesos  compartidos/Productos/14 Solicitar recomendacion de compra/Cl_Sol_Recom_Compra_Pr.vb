Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Cl_Sol_Recom_Compra_Pr

    Dim Consulta_sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Dim _Tbl_Prod_SolCompra As DataTable
    Dim _Row_Prod_SolCompra As DataRow
    Dim _Id_SCom As Integer
    Dim _Estado As Enum_Estados
    Dim _Actualizado As Boolean

    Enum Enum_Estados
        Ingresando
        Pendiente
        Revisado
        Respondido
        Acuse_Recibo
    End Enum

    Public Property Row_Prod_SolCompra As DataRow
        Get
            Return _Row_Prod_SolCompra
        End Get
        Set(value As DataRow)
            _Row_Prod_SolCompra = value
        End Set
    End Property

    Public Property Id_SCom As Integer
        Get
            Return _Id_SCom
        End Get
        Set(value As Integer)
            _Id_SCom = value
        End Set
    End Property

    Public Property Estado As Enum_Estados
        Get
            Return _Estado
        End Get
        Set(value As Enum_Estados)
            _Estado = value
        End Set
    End Property

    Public Property Actualizado As Boolean
        Get
            Return _Actualizado
        End Get
        Set(value As Boolean)
            _Actualizado = value
        End Set
    End Property

    Public Sub New()


    End Sub

    Sub Sb_Llenar_Row_Prod_SolCompra(_Id_SCom As Integer)

        Consulta_sql = "SELECT Zprod.*,NOKOEN FROM " & _Global_BaseBk & "Zw_Prod_SolCompra Zprod
                        LEFT JOIN MAEEN ON KOEN = CodCliente And SUEN = CodSucCliente
                        WHERE Id_SCom = " & _Id_SCom
        _Tbl_Prod_SolCompra = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl_Prod_SolCompra.Rows.Count) Then

            Id_SCom = _Id_SCom
            _Row_Prod_SolCompra = _Tbl_Prod_SolCompra.Rows(0)
            Dim _Est As String = _Row_Prod_SolCompra.Item("Estado")
            Estado = Fx_Estado(_Est)

        Else

            Estado = Enum_Estados.Ingresando

            Dim NewFila As DataRow
            NewFila = _Tbl_Prod_SolCompra.NewRow
            With NewFila

                .Item("Id_SCom") = 0
                .Item("Estado") = Fx_Estado(Estado)
                .Item("Empresa") = ModEmpresa
                .Item("Sucursal") = ModSucursal
                .Item("Bodega") = ModBodega
                .Item("Existe_Producto") = False
                .Item("Codigo") = String.Empty
                .Item("Descripcion") = String.Empty
                .Item("Cantidad") = 0
                .Item("CodFun_Solicita") = FUNCIONARIO
                .Item("CodFun_Envio") = String.Empty
                .Item("Para_Stock") = False
                .Item("Venta_Calzada") = False
                .Item("CodCliente") = String.Empty
                .Item("CodSucCliente") = String.Empty
                .Item("Deja_Anticipo") = False
                .Item("Valor_Anticipo") = 0
                '.Item("FechaEnvio")
                '.Item("Revisado") = False
                ''.Item("Fecha_Revisado")
                '.Item("Respuesta") = String.Empty
                .Item("Codigo_Usar") = String.Empty
                .Item("Idmaeedo_OCC") = 0

                _Tbl_Prod_SolCompra.Rows.Add(NewFila)
                _Row_Prod_SolCompra = _Tbl_Prod_SolCompra.Rows(0)

            End With

        End If

    End Sub

    Function Fx_Insertar_Recomandacion_Compra_Producto() As Boolean

        'Dim _Id_SCom
        Dim _Empresa = _Row_Prod_SolCompra.Item("Empresa")
        Dim _Sucursal = _Row_Prod_SolCompra.Item("Sucursal")
        Dim _Bodega = _Row_Prod_SolCompra.Item("Bodega")
        Dim _Existe_Producto = Convert.ToInt32(_Row_Prod_SolCompra.Item("Existe_Producto"))
        Dim _Codigo = _Row_Prod_SolCompra.Item("Codigo")
        Dim _Descripcion = _Row_Prod_SolCompra.Item("Descripcion")
        Dim _Observaciones = _Row_Prod_SolCompra.Item("Observaciones")
        Dim _Cantidad = De_Num_a_Tx_01(_Row_Prod_SolCompra.Item("Cantidad"), False, 5)
        Dim _CodFun_Solicita = _Row_Prod_SolCompra.Item("CodFun_Solicita")
        Dim _CodFun_Envio = _Row_Prod_SolCompra.Item("CodFun_Envio")
        Dim _Para_Stock = Convert.ToInt32(_Row_Prod_SolCompra.Item("Para_Stock"))
        Dim _Venta_Calzada = Convert.ToInt32(_Row_Prod_SolCompra.Item("Venta_Calzada"))
        Dim _CodCliente = _Row_Prod_SolCompra.Item("CodCliente")
        Dim _CodSucCliente = _Row_Prod_SolCompra.Item("CodSucCliente")
        Dim _Deja_Anticipo = Convert.ToInt32(_Row_Prod_SolCompra.Item("Deja_Anticipo"))
        Dim _Valor_Anticipo = De_Num_a_Tx_01(_Row_Prod_SolCompra.Item("Valor_Anticipo"), False, 5)
        'Dim _FechaEnvio = _Row_Prod_SolCompra.Item("FechaEnvio")
        'Dim _Revisado = Convert.ToInt32(_Row_Prod_SolCompra.Item("Revisado"))
        'Dim _Fecha_Revisado = _Row_Prod_SolCompra.Item("Fecha_Revisado")
        'Dim _Respuesta = _Row_Prod_SolCompra.Item("Respuesta")
        Dim _Codigo_Usar = _Row_Prod_SolCompra.Item("Codigo_Usar")
        Dim _Idmaeedo_OCC = _Row_Prod_SolCompra.Item("Idmaeedo_OCC")

        Dim _Numero = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Prod_SolCompra", "MAX(Numero)")

        If String.IsNullOrEmpty(Trim(_Numero)) Then
            _Numero = "0000000001"
        Else
            _Numero = Fx_Proximo_NroDocumento(_Numero, 10)
        End If

        Estado = Enum_Estados.Pendiente
        Dim _Estado = Fx_Estado(Enum_Estados.Pendiente)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_SolCompra (Empresa,Sucursal,Bodega,Numero,Estado,Existe_Producto,
                        Codigo,Descripcion,Cantidad,Observaciones,
                        CodFun_Solicita,CodFun_Envio,Para_Stock,Venta_Calzada,CodCliente,CodSucCliente,Deja_Anticipo,Valor_Anticipo,Fecha_Envio) 
                        VALUES 
                        ('" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "','" & _Numero & "','" & _Estado & "'," & _Existe_Producto & ",'" & _Codigo & "',
                        '" & _Descripcion & "'," & _Cantidad & ",'" & _Observaciones & "','" & _CodFun_Solicita & "','" & _CodFun_Envio & "'," & _Para_Stock & ",
                        " & _Venta_Calzada & ",'" & _CodCliente & "','" & _CodSucCliente & "'," & _Deja_Anticipo & "," & _Valor_Anticipo & ",
                        Getdate())"

        If _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, Id_SCom) Then

            Sb_Llenar_Row_Prod_SolCompra(Id_SCom)
            Return True

        End If

    End Function

    Function Fx_Actualizar_Recomendacion_Compra_Producto() As Boolean

        'Dim _Id_SCom
        Dim _Empresa = _Row_Prod_SolCompra.Item("Empresa")
        Dim _Sucursal = _Row_Prod_SolCompra.Item("Sucursal")
        Dim _Bodega = _Row_Prod_SolCompra.Item("Bodega")
        Dim _Existe_Producto = Convert.ToInt32(_Row_Prod_SolCompra.Item("Existe_Producto"))
        Dim _Codigo = _Row_Prod_SolCompra.Item("Codigo")
        Dim _Descripcion = _Row_Prod_SolCompra.Item("Descripcion")
        Dim _Observaciones = _Row_Prod_SolCompra.Item("Observaciones")
        Dim _Cantidad = De_Num_a_Tx_01(_Row_Prod_SolCompra.Item("Cantidad"), False, 5)
        Dim _CodFun_Solicita = _Row_Prod_SolCompra.Item("CodFun_Solicita")
        Dim _CodFun_Envio = _Row_Prod_SolCompra.Item("CodFun_Envio")
        Dim _Para_Stock = Convert.ToInt32(_Row_Prod_SolCompra.Item("Para_Stock"))
        Dim _Venta_Calzada = Convert.ToInt32(_Row_Prod_SolCompra.Item("Venta_Calzada"))
        Dim _CodCliente = _Row_Prod_SolCompra.Item("CodCliente")
        Dim _CodSucCliente = _Row_Prod_SolCompra.Item("CodSucCliente")
        Dim _Deja_Anticipo = Convert.ToInt32(_Row_Prod_SolCompra.Item("Deja_Anticipo"))
        Dim _Valor_Anticipo = De_Num_a_Tx_01(_Row_Prod_SolCompra.Item("Valor_Anticipo"), False, 5)

        'Dim _FechaEnvio = _Row_Prod_SolCompra.Item("FechaEnvio")
        'Dim _Revisado = Convert.ToInt32(_Row_Prod_SolCompra.Item("Revisado")) 
        'Dim _CodFun_Responde = _Row_Prod_SolCompra.Item("CodFun_Responde")
        'Dim _Respuesta = _Row_Prod_SolCompra.Item("Respuesta")

        Dim _Codigo_Usar = _Row_Prod_SolCompra.Item("Codigo_Usar")
        Dim _Idmaeedo_OCC = _Row_Prod_SolCompra.Item("Idmaeedo_OCC")

        Dim _Estado = Fx_Estado(Estado)

        Consulta_sql = "UPDATE " & _Global_BaseBk & "Zw_Prod_SolCompra SET 
                        Empresa = '" & _Empresa & "',
                        Sucursal = '" & _Sucursal & "',
                        Bodega = '" & _Bodega & "',
                        Estado = '" & _Estado & "',
                        Existe_Producto = " & _Existe_Producto & ",
                        Codigo = '" & _Codigo & "',
                        Descripcion = '" & _Descripcion & "',
                        Cantidad = " & _Cantidad & ",
                        Observaciones = '" & _Observaciones & "',
                        CodFun_Solicita = '" & _CodFun_Solicita & "',
                        CodFun_Envio = '" & _CodFun_Envio & "',
                        Para_Stock = " & _Para_Stock & ",
                        Venta_Calzada = " & _Venta_Calzada & ",
                        CodCliente = '" & _CodCliente & "',
                        CodSucCliente = '" & _CodSucCliente & "',
                        Deja_Anticipo = " & _Deja_Anticipo & ",
                        Valor_Anticipo = " & _Valor_Anticipo & ",
                        Codigo_Usar = '" & _Codigo_Usar & "',
                        Idmaeedo_OCC = " & _Idmaeedo_OCC & "
                        WHERE Id_SCom = " & Id_SCom

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then

            Sb_Llenar_Row_Prod_SolCompra(Id_SCom)
            _Actualizado = True
            Return True

        End If

    End Function

    Function Fx_Insertar_Respuesta(_CodFuncionario As String,
                                   _Estado As Enum_Estados,
                                   _Observaciones As String,
                                   _Agotado As Boolean,
                                   _Pedido As Boolean) As Boolean

        Estado = _Estado
        Dim _Var_Estado = Fx_Estado(Estado)

        Dim _CodFun_Solicita = _Row_Prod_SolCompra.Item("CodFun_Solicita")

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_SolCompra Set Estado = '" & _Var_Estado & "' 
                        Where Id_SCom = " & _Id_SCom & "
                        Insert Into " & _Global_BaseBk & "Zw_Prod_SolCompra_Resp 
                        (Id_SCom,Estado,CodFun_Solicita,CodFun_Responde,Fecha,Observaciones,Agotado,Pedido) Values
                        (" & Id_SCom & ",'" & _Var_Estado & "','" & _CodFun_Solicita & "','" & _CodFuncionario & "',Getdate(),
                        '" & _Observaciones & "'," & Convert.ToInt32(_Agotado) & "," & Convert.ToInt32(_Pedido) & ")"

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            Sb_Llenar_Row_Prod_SolCompra(Id_SCom)
            Return True

        End If

    End Function

    Private Function Fx_Estado(Estado As Enum_Estados) As String

        Dim _Estado As String

        Select Case Estado
            Case Enum_Estados.Ingresando
                _Estado = "ING"
            Case Enum_Estados.Pendiente
                _Estado = "PDT"
            Case Enum_Estados.Respondido
                _Estado = "RPD"
            Case Enum_Estados.Revisado
                _Estado = "REV"
            Case Enum_Estados.Acuse_Recibo
                _Estado = "ARE"
        End Select

        Return _Estado

    End Function

    Private Function Fx_Estado(Estado As String) As Enum_Estados

        Dim _Estado As Enum_Estados

        Select Case Estado
            Case "ING"
                _Estado = Enum_Estados.Ingresando
            Case "PDT"
                _Estado = Enum_Estados.Pendiente
            Case "RPD"
                _Estado = Enum_Estados.Respondido
            Case "REV"
                _Estado = Enum_Estados.Revisado
        End Select

        Return _Estado

    End Function

End Class
