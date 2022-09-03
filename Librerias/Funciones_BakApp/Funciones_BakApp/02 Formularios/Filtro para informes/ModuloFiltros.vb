Public Module ModuloFiltros

    Public Documentos_Filtro As String

    Function CargarFiltro(ByVal TipoDeFiltro As String, _
                     ByVal CdInforme As String, _
                     ByVal InfTextoEnPantalla As String, _
                     ByVal FormularioPadre As Object, _
                     Optional ByVal Incluye_Sin_Clasificacion As Boolean = True)

        Dim Fm As New Frm_FiltroInf_Mt
        Fm.TipoDeFiltro = TipoDeFiltro
        Fm.CodInforme = CdInforme
        Fm.CargarDatos(Incluye_Sin_Clasificacion)
        Fm.Text = InfTextoEnPantalla
        Fm.ShowDialog(FormularioPadre)
        Return Fm.Chekeado
    End Function

    Function Generar_Filtro_IN(ByVal Tabla As DataTable, _
                               ByVal _CodChk As String, _
                               ByVal _CodCampo As String, _
                               ByVal _EsNumero As Boolean, _
                               ByVal _TieneChk As Boolean, _
                               Optional ByVal _Separador As String = "''")

        Dim Cadena As String = String.Empty
        Dim Separador As String = ""

        If _EsNumero Then
            Separador = "#"
        Else
            Separador = "@"
        End If

        If (Tabla Is Nothing) Then Return "()"

        Dim i = 0
        For Each Rd As DataRow In Tabla.Rows

            Dim Estado As DataRowState = Rd.RowState

            If Estado <> DataRowState.Deleted Then
                Dim _Cadena As String = Rd.Item(_CodCampo).ToString()
                Dim _Encadenar As Boolean = False

                If _TieneChk Then
                    If Rd.Item(_CodChk) Then
                        _Encadenar = True
                    End If
                Else
                    If Not String.IsNullOrEmpty(Trim(_Cadena)) Then _Encadenar = True
                End If

                If _Encadenar Then
                    Cadena = Cadena & Separador & Trim(Rd.Item(_CodCampo).ToString) & Separador '& Coma
                End If
            End If
            i += 1
        Next

        If _EsNumero Then
            Cadena = Replace(Cadena, "##", ",")
            Cadena = Replace(Cadena, "#", "")
        Else
            Cadena = Replace(Cadena, "@@", "@,@")
            Cadena = Replace(Cadena, "@", _Separador)
        End If

        Cadena = "(" & Cadena & ")"

        Return Cadena

    End Function

    Sub MarcarTodosLosFiltro(ByVal CodInforme As String, _
                             ByVal TipoDeFiltro As String)

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_TblFiltro_InfxUs Where Funcionario = '" & FUNCIONARIO & _
                       "' And Informe = '" & CodInforme & "' And Tabla = '" & TipoDeFiltro & "'"
        Ej_consulta_IDU(Consulta_sql, cn1)

        Consulta_sql = "Insert into " & _Global_BaseBk & "Zw_TblFiltro_InfxUs (Funcionario, Informe, Tabla, Codigo,Filtro)" & vbCrLf & _
                                      "Values ('" & FUNCIONARIO & "','" & CodInforme & _
                                      "','" & TipoDeFiltro & "','','''Ver Todo''')"
        Ej_consulta_IDU(Consulta_sql, cn1)
    End Sub

    Sub DesMarcarTodosLosFiltro(ByVal CodInforme As String, _
                                ByVal TipoDeFiltro As String)

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_TblFiltro_InfxUs Where Funcionario = '" & FUNCIONARIO & _
                       "' And Informe = '" & CodInforme & "' And Tabla = '" & TipoDeFiltro & "'"
        Ej_consulta_IDU(Consulta_sql, cn1)

        Consulta_sql = "Insert into " & _Global_BaseBk & "Zw_TblFiltro_InfxUs (Funcionario, Informe, Tabla, Codigo,Filtro)" & vbCrLf & _
                                      "Values ('" & FUNCIONARIO & "','" & CodInforme & _
                                      "','" & TipoDeFiltro & "','','()')"
        Ej_consulta_IDU(Consulta_sql, cn1)
    End Sub



    Function HacerFiltro(ByVal Campo As String, _
                         ByVal Filtro As String)
        If Filtro = "()" Then
            Filtro = "And " & Campo & " In ('#@$')"
        ElseIf Filtro = "'Ver Todo'" Or String.IsNullOrEmpty(Filtro) Then
            Filtro = String.Empty
        Else
            Filtro = "And " & Campo & " In " & Filtro
        End If
        Return Filtro
    End Function


    Sub MarcarFiltroDeProductos(ByVal CodInforme As String)
        If Cuenta_registros(_Global_BaseBk & "Zw_TblFiltro_InfxUs", _
                            "Funcionario = '" & FUNCIONARIO & _
                            "' And Informe = '" & CodInforme & "' And Tabla = 'TABBO'") = 0 Then
            MarcarTodosLosFiltro(CodInforme, "TABBO")
        End If

        If Cuenta_registros(_Global_BaseBk & "Zw_TblFiltro_InfxUs", _
                            "Funcionario = '" & FUNCIONARIO & _
                            "' And Informe = '" & CodInforme & "' And Tabla = 'RUPR'") = 0 Then
            MarcarTodosLosFiltro(CodInforme, "RUPR")
        End If
        If Cuenta_registros(_Global_BaseBk & "Zw_TblFiltro_InfxUs", _
                            "Funcionario = '" & FUNCIONARIO & _
                            "' And Informe = '" & CodInforme & "' And Tabla = 'CLALIBPR'") = 0 Then
            MarcarTodosLosFiltro(CodInforme, "CLALIBPR")
        End If
        If Cuenta_registros(_Global_BaseBk & "Zw_TblFiltro_InfxUs", _
                            "Funcionario = '" & FUNCIONARIO & _
                            "' And Informe = '" & CodInforme & "' And Tabla = 'MRPR'") = 0 Then
            MarcarTodosLosFiltro(CodInforme, "MRPR")
        End If
        If Cuenta_registros(_Global_BaseBk & "Zw_TblFiltro_InfxUs", _
                            "Funcionario = '" & FUNCIONARIO & _
                            "' And Informe = '" & CodInforme & "' And Tabla = 'ZONAPR'") = 0 Then
            MarcarTodosLosFiltro(CodInforme, "ZONAPR")
        End If
        If Cuenta_registros(_Global_BaseBk & "Zw_TblFiltro_InfxUs", _
                            "Funcionario = '" & FUNCIONARIO & _
                            "' And Informe = '" & CodInforme & "' And Tabla = 'ZONAPR'") = 0 Then
            DesMarcarTodosLosFiltro(CodInforme, "ZONAPR")
        End If
        If Cuenta_registros(_Global_BaseBk & "Zw_TblFiltro_InfxUs", _
                            "Funcionario = '" & FUNCIONARIO & _
                            "' And Informe = '" & CodInforme & "' And Tabla = 'FMPR'") = 0 Then
            MarcarTodosLosFiltro(CodInforme, "FMPR")
        End If


    End Sub



End Module
