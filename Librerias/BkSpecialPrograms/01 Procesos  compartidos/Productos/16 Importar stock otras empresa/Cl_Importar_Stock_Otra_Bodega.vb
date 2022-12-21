Public Class Cl_Importar_Stock_Otra_Bodega

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Cadena_ConexionSQL_Server_Original = Cadena_ConexionSQL_Server
    Dim _Cadena_ConexionSQL_Server_Origen As String

    Public Sub New(_Cadena_ConexionSQL_Server_Origen As String)
        Me._Cadena_ConexionSQL_Server_Origen = _Cadena_ConexionSQL_Server_Origen
    End Sub

    Protected Overrides Sub Finalize()
        Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original
        MyBase.Finalize()
    End Sub

    Private Sub Sb_Actualizar_Stock_Desde_Otra_Bodega_De_Otra_Empresa(_Tbl_Productos As DataTable)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Maest Where Activo = 1"
        Dim _Tbl_DbExtMaest As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        For Each _FilaMst As DataRow In _Tbl_DbExtMaest.Rows

            Dim _Id_Conexion = _FilaMst.Item("Id_Conexion")

            Consulta_sql = "Select * From Zw_DbExt_Conexion Where Id = " & _Id_Conexion
            Dim _Row_DnExt As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Servidor = _Row_DnExt.Item("Servidor")
            Dim _Puerto = _Row_DnExt.Item("Puerto")
            Dim _Usuario = _Row_DnExt.Item("Usuario")
            Dim _Clave = _Row_DnExt.Item("Clave")
            Dim _BaseDeDatos = _Row_DnExt.Item("BaseDeDatos")

            Dim _Empresa_Ori = _FilaMst.Item("Empresa_Ori")
            Dim _Sucursal_Ori = _FilaMst.Item("Sucursal_Ori")
            Dim _Bodega_Ori = _FilaMst.Item("Bodega_Ori")

            Dim _Empresa_Des = _FilaMst.Item("Empresa_Des")
            Dim _Sucursal_Des = _FilaMst.Item("Sucursal_Des")
            Dim _Bodega_Des = _FilaMst.Item("Bodega_Des")

            Dim _SqlQuery = String.Empty

            For Each _FlProd As DataRow In _Tbl_Productos.Rows

                Dim _Codigo = _FlProd.Item("Codigo").Value

                If Not String.IsNullOrEmpty(_Puerto) Then
                    _Servidor = _Servidor & "," & _Puerto
                End If

                Dim _Cadena_ConexionSQL_Server_Origen = "data " &
                                                        "source = " & _Servidor & "; " &
                                                        "initial catalog = " & _BaseDeDatos & "; " &
                                                        "user id = " & _Usuario & "; " &
                                                        "password = " & _Clave

                Dim _Cl_Importar_Stock_Otra_Bodega As New Cl_Importar_Stock_Otra_Bodega(_Cadena_ConexionSQL_Server_Origen)

                _SqlQuery += _Cl_Importar_Stock_Otra_Bodega.Fx_Extraer_Stock_X_Producto(_Empresa_Ori, _Sucursal_Ori, _Bodega_Ori,
                                                                                           _Empresa_Des, _Sucursal_Des, _Bodega_Des,
                                                                                           _Codigo) & vbCrLf

            Next

            If Not String.IsNullOrEmpty(_SqlQuery) Then

            End If

        Next

    End Sub

    Function Fx_Extraer_Stock_X_Producto(_Empresa_Origen As String,
                                         _Sucursal_Origen As String,
                                         _Bodega_Origen As String,
                                         _Empresa_Destino As String,
                                         _Sucursal_Destino As String,
                                         _Bodega_Destino As String,
                                         _Codigo As String) As String

        Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Origen

        _Sql = New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = "Select Top 1 * From MAEST 
                        Where EMPRESA = '" & _Empresa_Origen & "' And KOSU = '" & _Sucursal_Origen & "' And KOBO = '" & _Bodega_Origen & "' And KOPR = '" & _Codigo & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _SqlQuery = String.Empty

        For Each _Fila As DataRow In _Tbl.Rows

            '_SqlQuery = "Delete MAEST Where EMPRESA = '" & _Empresa_Destino & "' And KOSU = '" & _Sucursal_Destino & "' And KOBO = '" & _Bodega_Destino & "' And KOPR = '" & _Codigo & "'" & vbCrLf &
            '            "Insert Into MAEST (EMPRESA,KOSU,KOBO,KOPR,@Campos)"

            'Dim _Campos_Adicionales = String.Empty

            'For _i = 4 To _Tbl.Columns.Count - 1

            '    Dim _Columna As DataColumn = _Tbl.Columns(_i)
            '    Dim _Nombre_Columna As String = _Columna.ColumnName

            '    _Campos_Adicionales = _Campos_Adicionales & "," & _Nombre_Columna

            'Next

            '_SqlQuery = Replace(_SqlQuery, ",@Campos", _Campos_Adicionales)
            '_SqlQuery = _SqlQuery & vbCrLf & "Values" & vbCrLf & "('" & _Empresa_Destino & "','" & _Sucursal_Destino & "','" & _Bodega_Destino & "','" & _Codigo & "',@Campos)" & vbCrLf & vbCrLf

            '_Campos_Adicionales = String.Empty

            'For _i = 4 To _Tbl.Columns.Count - 1

            '    Dim _Columna As DataColumn = _Tbl.Columns(_i)
            '    Dim _Nombre_Columna As String = _Columna.ColumnName

            '    Dim _Valor As Double = _Fila.Item(_Columna)

            '    _Campos_Adicionales = _Campos_Adicionales & "," & De_Num_a_Tx_01(_Valor, False, 5)

            'Next

            '_SqlQuery = Replace(_SqlQuery, ",@Campos", _Campos_Adicionales)

            Dim StfiBodExt1 As Double = _Fila.Item("STFI1")
            Dim StfiBodExt2 As Double = _Fila.Item("STFI2")

            _SqlQuery = "Delete " & _Global_BaseBk & "Zw_Prod_Stock Where Empresa = '" & _Empresa_Destino & "' And Sucursal = '" & _Sucursal_Destino & "' And Bodega = '" & _Bodega_Destino & "' And Codigo = '" & _Codigo & "'" & vbCrLf &
                        "Insert Into " & _Global_BaseBk & "Zw_Prod_Stock (Empresa,Sucursal,Bodega,Codigo,StfiBodExt1,StfiBodExt2) Values " &
                        "('" & _Empresa_Destino & "','" & _Sucursal_Destino & "','" & _Bodega_Destino & "','" & _Codigo & "'" &
                        "," & De_Num_a_Tx_01(StfiBodExt1, False, 5) & "," & De_Num_a_Tx_01(StfiBodExt2, False, 5) & ")"

        Next

        Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original

        Return _SqlQuery

    End Function

    Function Fx_Traer_Productos(_TblProductos As DataTable, _Campo_Codigo As String) As DataTable

        Dim _Filtro_Productos As String = Generar_Filtro_IN(_TblProductos, "", _Campo_Codigo, False, False, "'")

        Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Origen

        _Sql = New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = "Select KOPR As Codigo,NOKOPR As Descripcion From MAEPR Where KOPR In " & _Filtro_Productos
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original

        Return _Tbl

    End Function

    Function Fx_Traer_Productos_Con_Stock_Positivo(_TblProductos As DataTable,
                                                   _Campo_Codigo As String,
                                                   _Empresa_Origen As String,
                                                   _Sucursal_Origen As String,
                                                   _Bodega_Origen As String) As DataTable

        Dim _Filtro_Productos As String = Generar_Filtro_IN(_TblProductos, "", _Campo_Codigo, False, False, "'")

        Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Origen

        _Sql = New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = "Select KOPR As Codigo,NOKOPR As Descripcion" & vbCrLf &
                       "From MAEPR" & vbCrLf &
                       "Where KOPR In " & _Filtro_Productos & vbCrLf &
                       "And KOPR In (Select KOPR From MAEST " &
                       "Where EMPRESA = '" & _Empresa_Origen & "' And KOSU = '" & _Sucursal_Origen & "' And KOBO = '" & _Bodega_Origen & "' And STFI1 > 0)"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Server_Original

        Return _Tbl

    End Function

End Class
