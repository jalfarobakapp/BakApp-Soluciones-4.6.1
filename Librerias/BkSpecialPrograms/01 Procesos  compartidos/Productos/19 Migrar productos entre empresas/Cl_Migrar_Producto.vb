
Namespace Bk_Migrar_Producto

    Public Class Cl_Migrar_Producto

        Dim Consulta_sql As String
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim _Sql2 As Class_SQL

        Dim _Ds_Producto_Local As DataSet
        Dim _Ds_Producto_Ext As DataSet
        Dim _TablasRandom As List(Of String)
        Dim _TablasBakapp As List(Of String)
        Dim _CancelarTablas As Boolean
        Dim _CancelarCampos As Boolean

        Dim _Cadena_ConexionSQL_Server_Ext As String

        Public Property ProError As String
        Public Property Codigo As String
        Public Property SePuedeMigrar As Boolean
        Public Property Row_DbExtMaest As DataRow
        Public Property Row_DnExt As DataRow

        Public Property Ds_Producto_Local As DataSet
            Get
                Return _Ds_Producto_Local
            End Get
            Set(value As DataSet)
                _Ds_Producto_Local = value
            End Set
        End Property

        Public Property Ds_Producto_Ext As DataSet
            Get
                Return _Ds_Producto_Ext
            End Get
            Set(value As DataSet)
                _Ds_Producto_Ext = value
            End Set
        End Property

        Public Property TablasRandom As List(Of String)
            Get
                Return _TablasRandom
            End Get
            Set(value As List(Of String))
                _TablasRandom = value
            End Set
        End Property

        Public Property TablasBakapp As List(Of String)
            Get
                Return _TablasBakapp
            End Get
            Set(value As List(Of String))
                _TablasBakapp = value
            End Set
        End Property

        Public Property CancelarTablas As Boolean
            Get
                Return _CancelarTablas
            End Get
            Set(value As Boolean)
                _CancelarTablas = value
            End Set
        End Property

        Public Property CancelarCampos As Boolean
            Get
                Return _CancelarCampos
            End Get
            Set(value As Boolean)
                _CancelarCampos = value
            End Set
        End Property

        Public Property Cadena_ConexionSQL_Server_Ext As String
            Get
                Return _Cadena_ConexionSQL_Server_Ext
            End Get
            Set(value As String)
                _Cadena_ConexionSQL_Server_Ext = value
            End Set
        End Property

        Public Sub New(_Id_Conexion As Integer)

            Sub_ObtenerServExt(_Id_Conexion)

        End Sub

        Public Sub Sub_ObtenerServExt(_Id_Conexion As Integer)

            'Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Maest Where Id = " & _Id_Conexion & "--GrbProd_Nuevos = 1"
            '_Row_DbExtMaest = _Sql.Fx_Get_DataRow(Consulta_sql)

            'If IsNothing(Row_DbExtMaest) Then
            '    ProError = "No existe registro en la tabla Zw_DbExt_Maest para hacer esta gestión" & vbCrLf &
            '               "Informe al administrador del sistema"
            '    Return
            'End If

            'Dim _Id_Conexion = Row_DbExtMaest.Item("Id_Conexion")

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Conexion Where Id = " & _Id_Conexion
            _Row_DnExt = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Servidor = _Row_DnExt.Item("Servidor")
            Dim _Puerto = _Row_DnExt.Item("Puerto")
            Dim _Usuario = _Row_DnExt.Item("Usuario")
            Dim _Clave = _Row_DnExt.Item("Clave")
            Dim _BaseDeDatos = _Row_DnExt.Item("BaseDeDatos")

            Dim _ServidorPuerto As String = _Servidor

            If Not String.IsNullOrEmpty(_Puerto) Then
                _ServidorPuerto = _Servidor & "," & _Puerto
            End If

            _Cadena_ConexionSQL_Server_Ext = "data " &
                                             "source = " & _ServidorPuerto & "; " &
                                             "initial catalog = " & _BaseDeDatos & "; " &
                                             "user id = " & _Usuario & "; " &
                                             "password = " & _Clave

            _Sql2 = New Class_SQL(_Cadena_ConexionSQL_Server_Ext)

            Consulta_sql = "Select * From CONFIGP Where EMPRESA = '" & _Row_DnExt.Item("Empresa") & "'"
            Dim _RowConfigp As DataRow = _Sql2.Fx_Get_DataRow(Consulta_sql, False)

            If IsNothing(_RowConfigp) Then
                ProError = _Sql2.Pro_Error & vbCrLf & "No es posible conectarse con la base de datos externa. Revise los datos de conexión." & vbCrLf &
                    "Informe al administrador del sistema"
                Return
            End If

            Dim _GrbProd_Nuevos = _Row_DnExt.Item("GrbProd_Nuevos")
            Dim _GrbEnti_Nuevas = _Row_DnExt.Item("GrbEnti_Nuevas")
            Dim _GrbProd_Bodegas = _Row_DnExt.Item("GrbProd_Bodegas")
            Dim _GrbProd_Listas = _Row_DnExt.Item("GrbProd_Listas")

            SePuedeMigrar = True

        End Sub

        Function Fx_Migrar_Producto(_Codigo As String) As Boolean

            ProError = String.Empty

            Dim BdBakappExt As String = _Sql2.Fx_Obtener_Valores("Select NOKOCARAC From TABCARAC Where KOTABLA = 'BAKAPP';", 1)(0) & ".dbo."
            'Busca el producto
            _Ds_Producto_Ext = Fx_BuscarProducto(_Codigo, BdBakappExt, _Sql2)
            'Prueba de generacion de consulta migrar producto Dim ConsultaPR = GenerarConsultaMigracion(_Ds_Producto_Local, BdBakappExt)
            If _Ds_Producto_Ext.Tables(0).Rows.Count > 0 Then
                Consulta_sql = "INSERT INTO " & _Global_BaseBk & "[Zw_Migrar_Productos_Log] (Fecha, Kopr, Funcionario, Log) VALUES " &
                    "(Getdate(), '" & _Codigo & "', '" & FUNCIONARIO & "', 'El código de producto ya existe en la base de datos externa.');"
                _Sql.Ej_consulta_IDU(Consulta_sql, False)
                ProError = "El Producto ya existe en la base de datos externa."
                Return False
            Else

                ' Crear consulta migracion

                Dim _Consulta_sql As String

                _Ds_Producto_Local = Fx_BuscarProducto(_Codigo, _Global_BaseBk, _Sql)

                _Consulta_sql = GenerarConsultaMigracion(_Ds_Producto_Local, BdBakappExt) & vbCrLf
                _Consulta_sql += Fx_Insertar_Bodegas(_Codigo) & vbCrLf
                _Consulta_sql += Fx_Insertar_Listas(_Codigo)

                If _Sql2.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_Consulta_sql) Then
                    _Consulta_sql = "Insert Into " & _Global_BaseBk & "[Zw_Migrar_Productos_Log] (Fecha, Kopr, Funcionario, Log) VALUES " &
                        "('Getdate()', '" & _Codigo & "', '" & FUNCIONARIO & "', 'Producto migrado correctamente');"
                    _Sql.Ej_consulta_IDU(_Consulta_sql, False)
                Else
                    ProError = _Sql2.Pro_Error
                    Return False
                End If

            End If

            Return True

        End Function

        Function Fx_BuscarProducto(codigo As String, BaseBk As String, Conn As Class_SQL) As DataSet

            'incluir un select con los nombres de las tablas que se van a incluir

            _TablasRandom = New List(Of String)
            _TablasRandom.Add("MAEPR;KOPR")
            _TablasRandom.Add("MAEPREM;KOPR")
            '_TablasRandom.Add("TABBOPR;KOPR")
            '_TablasRandom.Add("TABPRE;KOPR")
            _TablasRandom.Add("PDIMEN;CODIGO")
            _TablasRandom.Add("MAEPROBS;KOPR")
            _TablasRandom.Add("MAEFICHA;KOPR")
            _TablasRandom.Add("MAEFICHD;KOPR")
            _TablasRandom.Add("TABIMPR;KOPR")
            _TablasRandom.Add("MPROENVA;KOPR")
            _TablasRandom.Add("TABCODAL;KOPR")

            _TablasBakapp = New List(Of String)
            '_TablasBakapp.Add("Zw_ListaPreCosto;Codigo")
            '_TablasBakapp.Add("Zw_ListaPreProducto;Codigo")
            _TablasBakapp.Add("Zw_Prod_Asociacion;Codigo")

            Dim _Ds_Producto As New DataSet

            For Each _TblNameCod As String In _TablasRandom
                Dim _TbCb() = Split(_TblNameCod, ";", 2)
                Dim _Tbl2 As DataTable = Fx_Tabla(_TbCb(0), _TbCb(1), codigo, Conn)
                _Ds_Producto.Tables.Add(_Tbl2)
            Next

            For Each _TblNameCod As String In _TablasBakapp
                Dim _TbCb() = Split(_TblNameCod, ";", 2)
                Dim _Tbl2 As DataTable = Fx_Tabla(BaseBk & _TbCb(0), _TbCb(1), codigo, Conn)
                _Ds_Producto.Tables.Add(_Tbl2)
            Next

            Return _Ds_Producto

        End Function

        Private Function Fx_Tabla(_Nomtabla As String, _Campo As String, _Codigo As String, Conexion As Class_SQL) As DataTable
            Dim _ConsultaSql = "SELECT * FROM " & _Nomtabla & " WHERE " & _Campo & "='" & _Codigo & "';"
            Dim _Tbl As DataTable = Conexion.Fx_Get_Tablas(_ConsultaSql)
            _Tbl.TableName = _Nomtabla '.Replace(_Global_BaseBk, "")
            Return _Tbl
        End Function

        Private Function GenerarConsultaMigracion(_Ds_Producto As DataSet, BdBakappExt As String) As String

            Dim Consulta = String.Empty

            For table = 0 To _Ds_Producto.Tables.Count - 1

                If _Ds_Producto.Tables(table).Rows.Count > 0 Then

                    Dim _NombreTabla As String = _Ds_Producto.Tables(table).TableName

                    'If _Ds_Producto.Tables(table).TableName.Contains(_Global_BaseBk) Then
                    '    Consulta &= "SET IDENTITY_INSERT " & _Ds_Producto.Tables(table).TableName & " ON;" & vbCrLf &
                    '                "INSERT INTO " & _Ds_Producto.Tables(table).TableName & "("
                    'Else
                    Consulta &= "INSERT INTO " & _NombreTabla & "("
                    'End If

                    Dim _CantColumnas As Integer = _Ds_Producto.Tables(table).Columns.Count - 1

                    If _NombreTabla = "MAEFICHD" Then
                        _CantColumnas = _CantColumnas - 1
                    End If

                    Dim _IColum = 0

                    If _NombreTabla.Contains("Zw_Prod_Asociacion") Then
                        _IColum = 1
                    End If

                    For column = _IColum To _CantColumnas
                        Consulta &= _Ds_Producto.Tables(table).Columns(column).ColumnName & ","
                    Next
                    Consulta &= ")"
                    Consulta = Consulta.Replace(",)", ")")

                    Consulta &= " VALUES "

                    For row = 0 To _Ds_Producto.Tables(table).Rows.Count - 1
                        Consulta &= "("
                        For column = _IColum To _CantColumnas
                            Consulta &= "'"
                            Consulta &= _Ds_Producto.Tables(table).Rows(row)(column).ToString().Replace(",", ".") & "',"
                        Next
                        Consulta &= ")"
                        Consulta = Consulta.Replace(",)", ")")
                        Consulta &= ","
                    Next
                    Consulta &= ";" & vbCrLf
                    'If _Ds_Producto.Tables(table).TableName.Contains(_Global_BaseBk) Then
                    '    Consulta = Consulta.Replace("),;", ");SET IDENTITY_INSERT " & _Ds_Producto.Tables(table).TableName & " OFF;")
                    'Else
                    '    Consulta = Consulta.Replace("),;", ");")
                    'End If

                    Consulta = Consulta.Replace("),;", ");")

                End If

            Next

            Consulta = Consulta.Replace(_Global_BaseBk, BdBakappExt)
            Return Consulta

        End Function

        Function Fx_Insertar_Bodegas(_Codigo As String) As String

            Dim _SqlQuery = String.Empty
            Dim _GrbProd_Bodegas As String = _Row_DnExt.Item("GrbProd_Bodegas")

            Consulta_sql = "Select * From TABBO Where EMPRESA+KOSU+KOBO In " & _GrbProd_Bodegas
            Dim _TblBodegas As DataTable = _Sql2.Fx_Get_Tablas(Consulta_sql)

            For Each _Fila As DataRow In _TblBodegas.Rows

                Dim _Empresa As String = _Fila.Item("EMPRESA")
                Dim _Sucursal As String = _Fila.Item("KOSU")
                Dim _Bodega As String = _Fila.Item("KOBO")

                _SqlQuery += "Insert Into TABBOPR (EMPRESA,KOSU,KOBO,KOPR) Values " &
                    "('" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "','" & _Codigo & "')" & vbCrLf

            Next

            Return _SqlQuery

        End Function

        Function Fx_Insertar_Listas(_Codigo As String) As String

            Dim _SqlQuery = String.Empty
            Dim _GrbProd_Listas = _Row_DnExt.Item("GrbProd_Listas")

            Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
            Dim _RowProducto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Koprra As String = _RowProducto.Item("KOPRRA")
            Dim _Koprte As String = _RowProducto.Item("KOPRTE")

            Consulta_sql = "Select * From TABPP Where KOLT In " & _GrbProd_Listas
            Dim _TblListas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            For Each _Fila As DataRow In _TblListas.Rows

                Dim _Kolt As String = _Fila.Item("KOLT")

                _SqlQuery += "Insert Into TABPRE (KOLT,KOPR,KOPRRA,KOPRTE) Values " &
                    "('" & _Kolt & "','" & _Codigo & "','" & _Koprra & "','" & _Koprte & "')" & vbCrLf

            Next

            Return _SqlQuery

        End Function

    End Class

End Namespace


