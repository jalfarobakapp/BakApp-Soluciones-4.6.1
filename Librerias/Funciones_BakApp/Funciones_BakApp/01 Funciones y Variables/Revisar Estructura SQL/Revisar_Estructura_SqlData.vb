Imports DevComponents.DotNetBar
Imports Lib_Bakapp_VarClassFunc

Public Class Revisar_Estructura_SqlData

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim Reg As Integer
    Dim Sql_Tabla As String = "SELECT TABLE_NAME AS TABLA," & vbCrLf & _
                              "COLUMN_NAME AS COLUMNA," & vbCrLf & _
                              "DATA_TYPE AS TIPO_DE_DATO," & vbCrLf & _
                              "CHARACTER_OCTET_LENGTH AS VALOR_MAXIMO," & vbCrLf & _
                              "COLUMN_DEFAULT AS VALOR_POR_DEFECTO," & vbCrLf & _
                              "IS_NULLABLE AS ACEPTA_NULOS," & vbCrLf & _
                              "ORDINAL_POSITION AS POSISION" & vbCrLf & _
                              "FROM INFORMATION_SCHEMA.COLUMNS" & vbCrLf & _
                              "WHERE TABLE_NAME = 'Tabla'" & vbCrLf & _
                              "AND COLUMNA = 'Columana'" & vbCrLf & _
                              "ORDER BY TABLE_NAME,ORDINAL_POSITION"


    'Llenar_Tabla_Bk(Tbl_Bk, "Id", "int", "NULL", "NULL", False, 1)
    'Llenar_Tabla_Bk(Tbl_Bk, "Sistema", "char", "10", "('')", True, 2)
    'Llenar_Tabla_Bk(Tbl_Bk, "TipoValor", "char", "1", "('N')", True, 3)
    'Llenar_Tabla_Bk(Tbl_Bk, "PrecioFormula", "bit", "NULL", "((0))", False, 4)
    'Llenar_Tabla_Bk(Tbl_Bk, "TipoFormula", "char", "1", "('G')", False, 5)
    'Llenar_Tabla_Bk(Tbl_Bk, "EntidadXdefecto", "varchar", "13", "('')", False, 6)
    'Llenar_Tabla_Bk(Tbl_Bk, "SucEntXdefecto", "varchar", "10", "('')", False, 7)
    'Llenar_Tabla_Bk(Tbl_Bk, "TipoCreaProducto", "char", "1", "('')", True, 8)
    'Llenar_Tabla_Bk(Tbl_Bk, "MueveStock", "bit", "NULL", "((0))", True, 9)
    'Llenar_Tabla_Bk(Tbl_Bk, "CodMadre", "bit", "NULL", "((0))", True, 10)
    'Llenar_Tabla_Bk(Tbl_Bk, "ListaVenta", "char", "3", "('')", False, 11)
    'Llenar_Tabla_Bk(Tbl_Bk, "ListaCompra", "char", "3", "('')", False, 12)
    'Llenar_Tabla_Bk(Tbl_Bk, "SolicitudCompra", "bit", "NULL", "((0))", False, 13)



    Sub ZW_Bkp_Configuracion()

        Dim Tbl_Bk As String = "ZW_Bkp_Configuracion"

        If Existe_Tabla(Tbl_Bk) Then

            Dim Arreglo_Tbl(,) As String = _
            {{Tbl_Bk, "Id", "int", "NULL", "NULL", False, 1}, _
             {Tbl_Bk, "Sistema", "char", "10", "('')", True, 2}, _
             {Tbl_Bk, "TipoValor", "char", "1", "('N')", True, 3}, _
             {Tbl_Bk, "PrecioFormula", "bit", "NULL", "((0))", False, 4}, _
             {Tbl_Bk, "TipoFormula", "char", "1", "('G')", False, 5}, _
             {Tbl_Bk, "EntidadXdefecto", "varchar", "13", "('')", False, 6}, _
             {Tbl_Bk, "SucEntXdefecto", "varchar", "10", "('')", False, 7}, _
             {Tbl_Bk, "TipoCreaProducto", "char", "1", "('')", True, 8}, _
             {Tbl_Bk, "MueveStock", "bit", "NULL", "((0))", True, 9}, _
             {Tbl_Bk, "CodMadre", "bit", "NULL", "((0))", True, 10}, _
             {Tbl_Bk, "ListaVenta", "char", "3", "('')", False, 11}, _
             {Tbl_Bk, "ListaCompra", "char", "3", "('')", False, 12}, _
             {Tbl_Bk, "SolicitudCompra", "bit", "NULL", "((0))", False, 13}}

            For i = 0 To 12

                Consulta_sql = Replace(Sql_Tabla, "Tabla", Tbl_Bk)
                Consulta_sql = Replace(Sql_Tabla, "Columna", Tbl_Bk)

                Dim Tbl_tmp As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                Dim TABLA As String = Tbl_tmp.Rows(0).Item("TABLA")
                Dim COLUMNA As String = Tbl_tmp.Rows(0).Item("COLUMNA")
                Dim TIPO_DE_DATO As String = Tbl_tmp.Rows(0).Item("TIPO_DE_DATO")
                Dim VALOR_MAXIMO As String = Tbl_tmp.Rows(0).Item("VALOR_MAXIMO")
                Dim VALOR_POR_DEFECTO As String = Tbl_tmp.Rows(0).Item("VALOR_POR_DEFECTO")
                Dim ACEPTA_NULOS As Boolean = Tbl_tmp.Rows(0).Item("ACEPTA_NULOS")
                Dim POSISION As Integer = Tbl_tmp.Rows(0).Item("POSISION")

                If Arreglo_Tbl(i, 1) = COLUMNA Then

                End If

            Next


            'Consulta_sql = Replace(Sql_Tabla, "Tabla", Tbl_Bk)
            'Dim Tbl_tmp = get_Tablas(Consulta_sql, cn1)

        Else

        End If

    End Sub

    Function Existe_Tabla(ByVal Tabla As String) As Boolean
        Reg = _Sql.Fx_Cuenta_Registros("INFORMATION_SCHEMA.COLUMNS", "TABLE_NAME = '" & Tabla & "'")
        Return CBool(Reg)
    End Function


End Class

Module Tablas_BakApp

    Function Llenar_Tabla_Bk(ByVal TABLA As String, _
                             ByVal COLUMNA As String, _
                             ByVal TIPO_DE_DATO As String, _
                             ByVal VALOR_MAXIMO As String, _
                             ByVal VALOR_POR_DEFECTO As String, _
                             ByVal ACEPTA_NULOS As Boolean, _
                             ByVal POSISION As Integer)

        Dim Ds As New Ds_Tablas_BakApp

        Dim NewFila As DataRow
        NewFila = Ds.Tables("Tablas_").NewRow
        With NewFila
            .Item("TABLA") = TABLA
            .Item("COLUMNA") = COLUMNA
            .Item("TIPO_DE_DATO") = TIPO_DE_DATO
            .Item("VALOR_MAXIMO") = VALOR_MAXIMO
            .Item("VALOR_POR_DEFECTO") = VALOR_POR_DEFECTO
            .Item("ACEPTA_NULOS") = ACEPTA_NULOS
            .Item("POSISION") = POSISION
            Ds.Tables("Tablas_").Rows.Add(NewFila)
        End With

        Return Ds.Tables("Tablas_")

    End Function

End Module

