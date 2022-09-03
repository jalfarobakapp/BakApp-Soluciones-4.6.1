Imports DevComponents.DotNetBar

Public Class Cl_SolCreaProducto

    Dim Consulta_sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Dim _Tbl_NewMaepr As DataTable
    Dim _Row_NewMaepr As DataRow
    Dim _Row_Proveedor As DataRow

    Dim _Row_Configuracion_BkCompra As DataRow

    Dim _SOC_Prod_Crea_Solo_Marcas_Proveedor

    Dim _ListaCostoPro As String

    Public Property Row_NewMaepr As DataRow
        Get
            Return _Row_NewMaepr
        End Get
        Set(value As DataRow)
            _Row_NewMaepr = value
        End Set
    End Property

    Public Property Row_Proveedor As DataRow
        Get
            Return _Row_Proveedor
        End Get
        Set(value As DataRow)
            _Row_Proveedor = value
        End Set
    End Property

    Public Property Tbl_NewMaepr As DataTable
        Get
            Return _Tbl_NewMaepr
        End Get
        Set(value As DataTable)
            _Tbl_NewMaepr = value
        End Set
    End Property

    Public Property Id_CPr As Integer
        Get
            Return _Row_NewMaepr.Item("Id_CPr")
        End Get
        Set(value As Integer)

            If IsNothing(_Row_NewMaepr) Then
                Sb_Llenar_RowProducto(value)
            End If

            _Row_NewMaepr.Item("Id_CPr") = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Sub Sb_Llenar_RowProducto(_Id_CPr As Integer)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_SolCreapr Where Id_CPr = " & _Id_CPr
        _Tbl_NewMaepr = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl_NewMaepr.Rows.Count) Then

            _Row_NewMaepr = _Tbl_NewMaepr.Rows(0)
            _Row_Proveedor = Fx_Traer_Datos_Entidad(_Row_NewMaepr.Item("Codproveedor"), _Row_NewMaepr.Item("Sucproveedor"))

        Else

            Dim NewFila As DataRow
            NewFila = _Tbl_NewMaepr.NewRow
            With NewFila

                .Item("Id_CPr") = 0
                .Item("Tipr") = "FPN"
                .Item("Kopr") = "@Crear_Prod"
                .Item("Nokopr") = String.Empty
                .Item("Koprra") = String.Empty
                .Item("Nokoprra") = String.Empty
                .Item("Koprte") = String.Empty
                .Item("Koge") = String.Empty
                .Item("Nmarca") = String.Empty
                .Item("Ud01pr") = String.Empty
                .Item("Ud02pr") = String.Empty
                .Item("Rlud") = 1
                .Item("Poivpr") = _Global_Row_Configp.Item("IVAPAIS")
                .Item("Numimpr") = 0
                .Item("Rgpr") = "N"
                .Item("Codproveedor") = String.Empty
                .Item("Sucproveedor") = String.Empty
                .Item("Kopral") = String.Empty
                .Item("CostoUd1") = 0
                .Item("CostoUd2") = 0
                .Item("Fmpr") = String.Empty
                .Item("Pfpr") = String.Empty
                .Item("Hfpr") = String.Empty
                .Item("Mrpr") = String.Empty
                .Item("Atpr") = String.Empty
                .Item("Rupr") = String.Empty
                .Item("Clalibpr") = String.Empty
                .Item("Kofupr") = String.Empty
                .Item("Zonapr") = String.Empty
                .Item("Observaciones") = String.Empty

                _Tbl_NewMaepr.Rows.Add(NewFila)
                _Row_NewMaepr = _Tbl_NewMaepr.Rows(0)

            End With

        End If

    End Sub

    Function Fx_Crear_Producto() As Boolean

        Dim _Kopr = _Row_NewMaepr.Item("Kopr")
        Dim _Nokopr = _Row_NewMaepr.Item("Nokopr")

        Dim _Codproveedor = _Row_Proveedor.Item("Koen")
        Dim _Sucproveedor = _Row_Proveedor.Item("Suen")

        Dim _Kopral = _Row_NewMaepr.Item("Kopral")

        Dim _Ud01pr = _Row_NewMaepr.Item("Ud01pr")
        Dim _Ud02pr = _Row_NewMaepr.Item("Ud02pr")
        Dim _Rlud = De_Num_a_Tx_01(_Row_NewMaepr.Item("Rlud"), False, 5)
        Dim _Tipr = _Row_NewMaepr.Item("Tipr")
        Dim _Poivpr = _Row_NewMaepr.Item("Poivpr")

        Dim _Observaciones = _Row_NewMaepr.Item("Observaciones")

        Dim _Mrpr = _Row_NewMaepr.Item("Mrpr")
        Dim _Rupr = _Row_NewMaepr.Item("Rupr")
        Dim _Clalibpr = _Row_NewMaepr.Item("Clalibpr")
        Dim _Fmpr = _Row_NewMaepr.Item("Fmpr")
        Dim _Pfpr = _Row_NewMaepr.Item("Pfpr")
        Dim _Hfpr = _Row_NewMaepr.Item("Hfpr")
        Dim _Kofupr = _Row_NewMaepr.Item("Kofupr")
        Dim _Zonapr = _Row_NewMaepr.Item("Zonapr")

        Dim _CostoUd1 = De_Num_a_Tx_01(_Row_NewMaepr.Item("CostoUd1"), False, 5)
        Dim _CostoUd2 = De_Num_a_Tx_01(_Row_NewMaepr.Item("CostoUd2"), False, 5)

        Dim _Nmarca = _Row_NewMaepr.Item("Nmarca")

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_SolCreapr (Tipr,Kopr,Nokopr,Koprra,Nokoprra,Koprte,Koge,Nmarca,Ud01pr,Ud02pr,Rlud," &
                       "Poivpr,Numimpr,Rgpr,Codproveedor,Sucproveedor,Kopral,CostoUd1,CostoUd2,Fmpr,Pfpr,Hfpr,Mrpr,Atpr,Rupr," &
                       "Clalibpr,Kofupr,Zonapr,Observaciones) Values " &
                       "('" & _Tipr & "','" & _Kopr & "','" & _Nokopr & "','','','','','" & _Nmarca & "','" & _Ud01pr & "','" & _Ud02pr &
                       "'," & _Rlud & "," & _Poivpr & ",0,'N','" & _Codproveedor & "','" & _Sucproveedor & "','" & _Kopral &
                       "'," & _CostoUd1 & "," & _CostoUd2 & ",'" & _Fmpr & "','" & _Pfpr & "','" & _Hfpr & "','" & _Mrpr &
                       "','','" & _Rupr & "','" & _Clalibpr & "','" & _Kofupr & "','" & _Zonapr & "','" & _Observaciones & "')"

        Return _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, Id_CPr, False)

    End Function

    Function Fx_Editar_Producto() As Boolean

        Dim _Kopr = _Row_NewMaepr.Item("Kopr")
        Dim _Nokopr = _Row_NewMaepr.Item("Nokopr")

        Dim _Codproveedor = _Row_Proveedor.Item("Koen")
        Dim _Sucproveedor = _Row_Proveedor.Item("Suen")

        Dim _Kopral = _Row_NewMaepr.Item("Kopral")

        Dim _Ud01pr = _Row_NewMaepr.Item("Ud01pr")
        Dim _Ud02pr = _Row_NewMaepr.Item("Ud02pr")
        Dim _Rlud = De_Num_a_Tx_01(_Row_NewMaepr.Item("Rlud"), False, 5)
        Dim _Tipr = _Row_NewMaepr.Item("Tipr")
        Dim _Poivpr = _Row_NewMaepr.Item("Poivpr")

        Dim _Observaciones = _Row_NewMaepr.Item("Observaciones")

        Dim _Mrpr = _Row_NewMaepr.Item("Mrpr")
        Dim _Rupr = _Row_NewMaepr.Item("Rupr")
        Dim _Clalibpr = _Row_NewMaepr.Item("Clalibpr")
        Dim _Fmpr = _Row_NewMaepr.Item("Fmpr")
        Dim _Pfpr = _Row_NewMaepr.Item("Pfpr")
        Dim _Hfpr = _Row_NewMaepr.Item("Hfpr")
        Dim _Kofupr = _Row_NewMaepr.Item("Kofupr")
        Dim _Zonapr = _Row_NewMaepr.Item("Zonapr")

        Dim _CostoUd1 = De_Num_a_Tx_01(_Row_NewMaepr.Item("CostoUd1"), False, 5)
        Dim _CostoUd2 = De_Num_a_Tx_01(_Row_NewMaepr.Item("CostoUd2"), False, 5)

        Dim _Nmarca = _Row_NewMaepr.Item("Nmarca")

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_SolCreapr Set " & vbCrLf &
                       "Tipr='" & _Tipr & "'," &
                       "Kopr='" & _Kopr & "'," &
                       "Nokopr='" & _Nokopr & "'," &
                       "Koprra = '',Nokoprra = '',Koprte = '',Koge = ''," &
                       "Nmarca = '" & _Nmarca & "'," &
                       "Ud01pr = '" & _Ud01pr & "'," &
                       "Ud02pr = '" & _Ud02pr & "'," &
                       "Rlud = " & _Rlud & "," &
                       "Poivpr = " & _Poivpr & "," &
                       "Numimpr = 0," &
                       "Rgpr = 'N'," &
                       "Codproveedor = '" & _Codproveedor & "'," &
                       "Sucproveedor = '" & _Sucproveedor & "'," &
                       "Kopral = '" & _Kopral & "'," &
                       "CostoUd1 = " & _CostoUd1 & "," &
                       "CostoUd2 = " & _CostoUd2 & "," &
                       "Fmpr = '" & _Fmpr & "'," &
                       "Pfpr = '" & _Pfpr & "'," &
                       "Hfpr = '" & _Hfpr & "'," &
                       "Mrpr = '" & _Mrpr & "'," &
                       "Atpr = ''," &
                       "Rupr = '" & _Rupr & "'," &
                       "Clalibpr = '" & _Clalibpr & "'," &
                       "Kofupr = '" & _Kofupr & "'," &
                       "Zonapr = '" & _Zonapr & "'," &
                       "Observaciones = '" & _Observaciones & "'" & vbCrLf &
                       "Where Id_CPr = " & Id_CPr

        Return _Sql.Ej_consulta_IDU(Consulta_sql, False)

    End Function

    Function Fx_Eliminar_Producto() As Boolean

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_SolCreapr Where Id_CPr = " & Id_CPr
        Return _Sql.Ej_consulta_IDU(Consulta_sql)

    End Function

End Class
