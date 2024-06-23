
Public Module Mod_Funciones_Remotas

    Dim Consulta_sql As String

    Function Fx_Solicitar_Remota(ByVal _CodFuncionario_Solicita As String,
                                 ByVal _CodPermiso As String,
                                 ByVal _Descripcion_Adicional As String,
                                 ByVal _Id_Casi_DocEnc As Integer,
                                 ByVal _CodEntidad As String,
                                 ByVal _NomEntidad As String,
                                 ByVal _Espera_En_Liena As Boolean,
                                 Optional _CodSucEntidad As String = "",
                                 Optional _Permiso_Presencial As Boolean = False,
                                 Optional _Idmaeedo As Integer = 0,
                                 Optional _CodFuncionario_Autoriza As String = "",
                                 Optional _Observaciones As String = "",
                                 Optional _Fecha_Otorga As DateTime? = Nothing,
                                 Optional _Padre_NroRemota As String = "") As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Otorga = String.Empty
        Dim _Permiso_Otorgado = 0

        If Not String.IsNullOrEmpty(_CodFuncionario_Autoriza) Then
            _Otorga = "Autorizado"
            _Permiso_Otorgado = 1
        End If

        Dim _Fecha_Otorga_Str = String.Empty
        Dim _Bool_Fecha_Otorga As Boolean = _Fecha_Otorga.HasValue

        If _Bool_Fecha_Otorga Then
            _Fecha_Otorga_Str = "Convert(datetime,'" & Format(_Fecha_Otorga, "dd-MM-yyyy hh:mm:ss") & "')"
        Else
            _Fecha_Otorga_Str = "Getdate()"
        End If

        Dim _NroRemota As String
        Dim _Ult_NroRemota = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Remotas", "MAX(NroRemota)")

        If String.IsNullOrEmpty(Trim(_Ult_NroRemota)) Then
            _Ult_NroRemota = 1
        Else
            _Ult_NroRemota = Math.Round(Val(Mid(_Ult_NroRemota, 2, 10)) + 1, 0)
        End If

        _NroRemota = "R" & numero_(Val(_Ult_NroRemota), 9)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Casi_DocEnc" & vbCrLf &
                       "Where Id_DocEnc = " & _Id_Casi_DocEnc
        Dim _Zw_Doc_Enc As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _TotalBruto As Double = 0

        If CBool(_Zw_Doc_Enc.Rows.Count) Then
            _TotalBruto = _Zw_Doc_Enc.Rows(0).Item("TotalBrutoDoc")
        End If

        If String.IsNullOrEmpty(_Descripcion_Adicional) Then
            _Descripcion_Adicional = _Sql.Fx_Trae_Dato(_Global_BaseBk & "ZW_Permisos", "DescripcionPermiso", "CodPermiso = '" & _CodPermiso & "'")
        End If

        Dim _Id_Rem As Integer

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Remotas " &
                       "(Empresa,NroRemota,CodFuncionario_Solicita,CodFuncionario_Autoriza,CodPermiso,Descripcion_Adicional,Permiso_Otorgado,Otorga," &
                       "Id_Casi_DocEnc,Fecha_Solicita,CodEntidad,CodSucEntidad,NomEntidad,TotalBruto,Espera_En_Linea,Permiso_Presencial,Idmaeedo,Observaciones,Padre_NroRemota) Values " &
                       "('" & ModEmpresa & "','" & _NroRemota & "','" & _CodFuncionario_Solicita & "','" & _CodFuncionario_Autoriza & "','" & _CodPermiso &
                       "','" & _Descripcion_Adicional & "'," & _Permiso_Otorgado & ",'" & _Otorga & "'," & _Id_Casi_DocEnc & ",GetDate(),'" & _CodEntidad &
                       "','" & _CodSucEntidad & "','" & _NomEntidad &
                       "'," & De_Num_a_Tx_01(_TotalBruto, False, 0) & "," & Convert.ToInt32(_Espera_En_Liena) & "," & Convert.ToInt32(_Permiso_Presencial) & "
                       ," & _Idmaeedo & ",'" & _Observaciones & "','" & _Padre_NroRemota & "')"

        If _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Rem) Then

            If Not String.IsNullOrEmpty(_CodFuncionario_Autoriza) Then
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Remotas Set Fecha_Otorga = " & _Fecha_Otorga_Str & " Where Id_Rem = " & _Id_Rem
                _Sql.Ej_consulta_IDU(Consulta_sql)
            End If

            Return _NroRemota
        Else
            Return ""
        End If

    End Function

End Module
