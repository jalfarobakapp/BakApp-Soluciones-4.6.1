Public Class Cl_Listas_Programadas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _FechaProgramacion As DateTime

    Public Sub New()

    End Sub

    Sub Sb_Grabar_Listas_Programadas(_FechaProgramacion As DateTime)

        Me._FechaProgramacion = _FechaProgramacion

        Dim _Str_FechaProgramacion = Format(_FechaProgramacion, "yyyyMMdd")

        Consulta_sql = "Select Id,Codigo,NombreProgramacion,FechaCreacion,FechaProgramada,Aplicado,Funcionario," &
                       "Activo,Id_Padre,Editada,Eliminada, FuncionarioElimina, FechaEliminacion" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_ListaLC_Programadas" & vbCrLf &
                       "Where FechaProgramada = '" & _Str_FechaProgramacion & "' And Activo = 1 And Aplicado = 0 And Eliminada = 0 "

        Dim _Tbl_ListasProgramadas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl_ListasProgramadas.Rows.Count) Then

            Dim _Filtros_Id = Generar_Filtro_IN(_Tbl_ListasProgramadas, "", "Id", True, False, "")

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_ListaLC_Programadas Set Activo = 0 Where Id In " & _Filtros_Id
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

        For Each _Fila As DataRow In _Tbl_ListasProgramadas.Rows

            Dim _SqlQuery = String.Empty

            Dim _Id_Enc = _Fila.Item("Id")

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_ListaLC_Programadas_Detalles Where Id_Enc = " & _Id_Enc
            Dim _Tbl_ListasProgramadas_Detalle As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            _SqlQuery += "Update " & _Global_BaseBk & "Zw_ListaLC_Programadas Set " &
                         "Aplicado = 1,FechaAplica = Getdate(),Informacion = 'Ok.',ErrorAlGrabar = 0" & vbCrLf &
                         "Where Id = " & _Id_Enc & vbCrLf & vbCrLf

            For Each _FilaDet As DataRow In _Tbl_ListasProgramadas_Detalle.Rows

                Dim _Kolt As String = _FilaDet.Item("Lista")
                Dim _Kopr As String = _FilaDet.Item("Codigo")
                Dim _Pp01ud As Double = _FilaDet.Item("PrecioUd1")
                Dim _Pp02ud As Double = _FilaDet.Item("PrecioUd2")
                Dim _Mg01ud As Double = _FilaDet.Item("MargenPorc")
                Dim _Ecuacion As String = _FilaDet.Item("EcuacionUd1")
                Dim _Ecuacion2 As String = _FilaDet.Item("EcuacionUd2")

                _SqlQuery += "Update TABPRE Set " &
                             "PP01UD = " & De_Num_a_Tx_01(_Pp01ud, False, 5) & "," &
                             "PP02UD = " & De_Num_a_Tx_01(_Pp02ud, False, 5) & "," &
                             "MG01UD = " & De_Num_a_Tx_01(_Mg01ud, False, 5) & "," &
                             "ECUACION = '" & _Ecuacion & "'," &
                             "ECUACIONU2 = '" & _Ecuacion2 & "'" & Space(1) &
                             "Where KOLT = '" & _Kolt & "' And KOPR = '" & _Kopr & "'" & vbCrLf

            Next

            _SqlQuery += vbCrLf

            If Not String.IsNullOrEmpty(_SqlQuery) Then

                If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery) Then

                    Dim _Filtros_Id = Generar_Filtro_IN(_Tbl_ListasProgramadas, "", "Id", True, False, "")
                    Dim _Error = Replace(_Sql.Pro_Error, "'", "''")

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_ListaLC_Programadas Set " &
                                   "Activo = 0,ErrorAlGrabar = 1,Informacion = '" & Mid(_Error.ToString.Trim, 1, 2000) & "'" & vbCrLf &
                                   "Where Id = " & _Id_Enc
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

            End If

        Next

    End Sub

End Class
