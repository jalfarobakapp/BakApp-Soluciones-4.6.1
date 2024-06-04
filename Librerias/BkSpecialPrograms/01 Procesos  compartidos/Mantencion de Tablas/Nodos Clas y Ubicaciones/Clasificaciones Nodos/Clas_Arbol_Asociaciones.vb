'Imports Lib_Bakapp_VarClassFunc
Imports System.Data.SqlClient
Imports DevComponents.DotNetBar

Public Class Clas_Arbol_Asociaciones

    Dim _Formulario As Form
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Public Sub New(Formulario As Form)
        _Formulario = Formulario
    End Sub

    Public Sub Sb_Guardar(_TblFiltroProductos As DataTable,
                          _Codigo_Nodo As String,
                          _Descripcion_Nodo As String,
                          Optional _Barra_Progreso_ As Object = Nothing,
                          Optional _Mostrar_Notificacion As Boolean = False,
                          Optional _Pedir_Permiso As Boolean = True)


        Dim _Filtro_Productos As String

        If _TblFiltroProductos.Rows.Count Then
            _Filtro_Productos = Generar_Filtro_IN(_TblFiltroProductos, "", "Codigo", False, False, "'")
            _Filtro_Productos = "And Codigo Not In " & _Filtro_Productos
        End If

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                       "Where Codigo_Nodo = " & _Codigo_Nodo & Space(1) & _Filtro_Productos

        Dim _TblAsociaciones As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Dim _Sql_Query = String.Empty

        If _TblAsociaciones.Rows.Count Then
            For Each _Fila As DataRow In _TblAsociaciones.Rows
                Dim _Codigo = _Fila.Item("Codigo")
                _Sql_Query += Fx_Borrar_Registro(_Codigo, _Codigo_Nodo, "")
            Next
        End If

        If Not String.IsNullOrEmpty(_Sql_Query) Then
            _Sql.Ej_consulta_IDU(_Sql_Query)
        End If


        If _TblFiltroProductos.Rows.Count Then
            _Filtro_Productos = Generar_Filtro_IN(_TblFiltroProductos, "", "Codigo", False, False, "'")

            Consulta_Sql = "Select KOPR As Codigo,NOKOPR From MAEPR Where KOPR In " & _Filtro_Productos & vbCrLf &
                           "And KOPR Not In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo_Nodo = " & _Codigo_Nodo & ")"

            _TblFiltroProductos = _Sql.Fx_Get_Tablas(Consulta_Sql)

        End If

        If _TblFiltroProductos.Rows.Count Then

            _Filtro_Productos = Generar_Filtro_IN(_TblFiltroProductos, "", "Codigo", False, False, "'")

            Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Asociacion (Codigo,Codigo_Nodo,DescripcionBusqueda,Para_filtro)" & vbCrLf &
                           "Select KOPR,'" & _Codigo_Nodo & "','" & _Descripcion_Nodo & "',1" & vbCrLf &
                           "From MAEPR " & vbCrLf &
                           "WHERE KOPR IN " & _Filtro_Productos & vbCrLf & vbCrLf

            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

                Consulta_Sql = "Select Distinct Codigo_Nodo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                               "WHERE Codigo IN " & _Filtro_Productos & vbCrLf &
                               "And Codigo_Nodo in (Select Codigo_Nodo from " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Es_Seleccionable = 1)"

                Dim _TblNodos As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

                Dim _Sql2 As String = String.Empty

                Dim Contador As Integer = 0


                For Each _Fila As DataRow In _TblNodos.Rows

                    System.Windows.Forms.Application.DoEvents()
                    Dim _Cod_Nodo As String = _Fila.Item("Codigo_Nodo")
                    Dim _Identificacdor_NodoPadre As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblArbol_Asociaciones",
                                                             "Identificacdor_NodoPadre", "Codigo_Nodo = " & _Cod_Nodo)

                    _Sql2 += Fx_Crear_Arbol_de_productos(_Cod_Nodo, _Cod_Nodo) & vbCrLf & vbCrLf &
                             "-------------------" & vbCrLf & vbCrLf

                    Contador += 1

                Next

                _Sql.Ej_consulta_IDU(_Sql2)

            End If

        End If


        If _Mostrar_Notificacion Then
            Beep()
            ToastNotification.Show(_Formulario, "DATOS GUARDADOS CORRECTAMENTE",
                                        My.Resources.ok_button,
                                       2 * 1000, eToastGlowColor.Blue, eToastPosition.MiddleCenter)
        End If

    End Sub

    Function Fx_Crear_Arbol_de_productos(_Cod_Nodo_Origen As String,
                                         _Codigo_Nodo As String,
                                         Optional _Consulta_Sql As String = "")

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
        Dim _TblNodo As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Dim _Identificacdor_NodoPadre = _TblNodo.Rows(0).Item("Identificacdor_NodoPadre")
        Dim _Descripcion_Nodo = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblArbol_Asociaciones", "Descripcion",
                                 "Codigo_Nodo = " & _Identificacdor_NodoPadre)

        If CBool(_Identificacdor_NodoPadre) Then
            _Consulta_Sql += "Insert Into " & _Global_BaseBk & "Zw_Prod_Asociacion (Codigo,Codigo_Nodo,DescripcionBusqueda,Para_filtro)" & vbCrLf &
                        "Select KOPR,'" & _Identificacdor_NodoPadre & "','" & _Descripcion_Nodo & "',1" & vbCrLf &
                        "From MAEPR" & vbCrLf &
                        "WHERE KOPR IN" & vbCrLf &
                        "(SELECT Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion " & vbCrLf &
                        "Where Codigo_Nodo = '" & _Codigo_Nodo & "' and " & vbCrLf &
                        "Codigo not in (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo_Nodo = '" & _Identificacdor_NodoPadre & "' ))" & vbCrLf & vbCrLf
        End If

        If CBool(_TblNodo.Rows.Count) Then

            _Codigo_Nodo = _TblNodo.Rows(0).Item("Identificacdor_NodoPadre")

            Dim _Reg As Boolean = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_TblArbol_Asociaciones",
                                                           "Codigo_Nodo = " & _Codigo_Nodo)

            If _Reg Then
                _Consulta_Sql = Fx_Crear_Arbol_de_productos(_Cod_Nodo_Origen,
                                                            _Codigo_Nodo, _Consulta_Sql)

            End If

        End If

        Return _Consulta_Sql

    End Function

    Function Fx_Borrar_Registro(_Codigo As String,
                                _Codigo_Nodo As String,
                                _Sql_Borra As String) As String


        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Prod_Asociacion" & Space(1) &
                       "Where Codigo = '" & _Codigo & "' And Codigo_Nodo = " & _Codigo_Nodo
        Dim _Row_Producto As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If Not (_Row_Producto Is Nothing) Then

            _Sql_Borra = "Delete " & _Global_BaseBk & "Zw_Prod_Asociacion" & Space(1) &
                          "Where Codigo = '" & _Codigo & "' And Codigo_Nodo = " & _Codigo_Nodo & vbCrLf

            Dim _Nodo_Padre As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblArbol_Asociaciones",
                                                           "Identificacdor_NodoPadre", "Codigo_Nodo = " & _Codigo_Nodo, True)

            If CBool(_Nodo_Padre) Then

                Consulta_Sql = "Select *" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                               "Where Codigo = '" & _Codigo & "' And Codigo_Nodo In (Select Codigo_Nodo" & Space(1) &
                               "From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & Space(1) &
                               "Where Codigo_Nodo <> " & _Codigo_Nodo & " And Identificacdor_NodoPadre = " & _Nodo_Padre & ")"
                Dim _TblPadres As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

                If Not CBool(_TblPadres.Rows.Count) Then
                    Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo = '" & _Codigo & "'"
                    _Row_Producto = _Sql.Fx_Get_DataRow(Consulta_Sql)
                    _Sql_Borra += Fx_Borrar_Registro(_Codigo, _Nodo_Padre, "")
                End If

            End If

        End If

        Return _Sql_Borra

    End Function

    Function Fx_Raiz_Clasificacion(_Codigo_Nodo As String)

        Dim _Full As String = String.Empty
        Dim _CodPadre As String

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        _CodPadre = _Tbl.Rows(0).Item("Identificacdor_NodoPadre")

        If _CodPadre = 0 Then
            Return _Tbl.Rows(0).Item("Descripcion")
        End If

        Do While (_CodPadre <> 0)

            Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _CodPadre
            _Tbl = _Sql.Fx_Get_Tablas(Consulta_Sql) '_SQL.Fx_Get_Tablas(Consulta_sql)

            _CodPadre = _Tbl.Rows(0).Item("Identificacdor_NodoPadre")
            _Full = "\" & _Tbl.Rows(0).Item("Descripcion") & _Full

        Loop

        Return _Full

    End Function

    Function Fx_Lista_Codigos_Raiz_Clasificacion(_Codigo_Nodo As String) As List(Of Integer)

        Dim _Lista As New List(Of Integer)
        Dim _Full As String = String.Empty
        Dim _CodPadre As Integer

        '_Lista.Clear()

        Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
        Dim _RowNodo As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        _CodPadre = _RowNodo.Item("Identificacdor_NodoPadre")

        _Lista.Add(_Codigo_Nodo)

        If _CodPadre = 0 Then
            _Lista.Add(_CodPadre)
        End If

        Do While (_CodPadre <> 0)

            Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _CodPadre
            _RowNodo = _Sql.Fx_Get_DataRow(Consulta_Sql)

            If Not (_RowNodo Is Nothing) Then
                Dim _New_Codigo_Nodo As Integer = _RowNodo.Item("Codigo_Nodo")
                _CodPadre = _RowNodo.Item("Identificacdor_NodoPadre")
                _Lista.Add(_New_Codigo_Nodo)
            End If

        Loop


        Return _Lista
        '0Return _Full

    End Function

    Function Fx_Raiz_Clasificacion_New(_Codigo_Nodo As String, _Full_Path As String) As String

        Dim _Full_New As String

        Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                       "Where Codigo_Nodo = " & _Codigo_Nodo

        Dim _Row_Nodo As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Dim _Identificacdor_NodoPadre = _Row_Nodo.Item("Identificacdor_NodoPadre")

        If CBool(_Identificacdor_NodoPadre) Then

            _Full_New += _Row_Nodo.Item("Descripcion")
            _Full_New += Fx_Raiz_Clasificacion_New(_Identificacdor_NodoPadre, _Full_Path) & "\" & _Full_New

        Else
            _Full_New = _Row_Nodo.Item("Descripcion")
        End If

        Return _Full_New

    End Function



End Class
