Imports DevComponents.DotNetBar

Public Class Clas_Cerrar_Documento

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public ReadOnly Property Pro_Row_Maeedo(ByVal _Idmaeedo As Integer) As DataRow
        Get
            Dim _Row_Maeedo As DataRow

            Consulta_sql = "Select Top 1 * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
            _Row_Maeedo = _Sql.Fx_Get_DataRow(Consulta_sql)

            Return _Row_Maeedo

        End Get
    End Property

    Function Fx_Cerrar_Documento(_Idmaeedo As Integer, _Tbl_Maeddo_Filas_Cerrar As DataTable)

        Dim _SqlQuery = String.Empty

        For Each _Fila As DataRow In _Tbl_Maeddo_Filas_Cerrar.Rows
            _SqlQuery += Fx_Sql_Cerrar_Linea(_Fila) & vbCrLf
        Next

        _SqlQuery += Fx_Sql_Cerrar_o_Abrir_Encabezado(_Idmaeedo)

        Return _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery)

    End Function

    Function Fx_Abrir_Documento(_Idmaeedo As Integer, _Tbl_Maeddo_Filas_Cerrar As DataTable)

        Dim _SqlQuery = String.Empty

        For Each _Fila As DataRow In _Tbl_Maeddo_Filas_Cerrar.Rows
            _SqlQuery += Fx_Sql_Abrir_Linea(_Fila) & vbCrLf
        Next

        _SqlQuery += Fx_Sql_Cerrar_o_Abrir_Encabezado(_Idmaeedo)

        Return _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery)

    End Function

    Function Fx_Sql_Abrir_Linea(ByVal _Row_Maeddo As DataRow) As String

        Dim _SqlQuery = String.Empty

        Dim _Idmaeddo = _Row_Maeddo.Item("IDMAEDDO")

        Dim _Caprco1 As Double = _Row_Maeddo.Item("CAPRCO1")
        Dim _Caprad1 As Double = _Row_Maeddo.Item("CAPRAD1")
        Dim _Caprex1 As Double = _Row_Maeddo.Item("CAPREX1")

        Dim _Caprco2 As Double = _Row_Maeddo.Item("CAPRCO2")
        Dim _Caprad2 As Double = _Row_Maeddo.Item("CAPRAD2")
        Dim _Caprex2 As Double = _Row_Maeddo.Item("CAPREX2")

        Dim _Saldo_Caprad1 = _Caprad1
        Dim _Saldo_Caprad2 = _Caprad2

        If CBool(_Caprad1) Or CBool(_Caprad2) Then

            Dim _New_Caprad1 As String = De_Num_a_Tx_01(_Caprad1, False, 5)
            Dim _New_Caprad2 As String = De_Num_a_Tx_01(_Caprad2, False, 5)

            Dim _Empresa As String = _Row_Maeddo.Item("EMPRESA")
            Dim _Sucursal As String = _Row_Maeddo.Item("SULIDO")
            Dim _Bodega As String = _Row_Maeddo.Item("BOSULIDO")

            Dim _Codigo As String = _Row_Maeddo.Item("KOPRCT")
            Dim _Descripcion As String = _Row_Maeddo.Item("NOKOPR")

            Dim _Tido = _Row_Maeddo.Item("TIDO")

            Dim _Campo_Mov_Stock_Ud1, _Campo_Mov_Stock_Ud2 As String
            Dim _Mueve_Stock = True
            Select Case _Tido
                Case "NVV"
                    _Campo_Mov_Stock_Ud1 = "STOCNV1"
                    _Campo_Mov_Stock_Ud2 = "STOCNV2"

                    _SqlQuery = "Update " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Stock_X_Producto Set " & Space(1) &
                                "Reservado = 1" & vbCrLf &
                                "Where Idmaeddo_Reserva = " & _Idmaeddo & vbCrLf & vbCrLf

                Case "OCC"
                    _Campo_Mov_Stock_Ud1 = "STOCNV1C"
                    _Campo_Mov_Stock_Ud2 = "STOCNV2C"
                Case Else
                    _Mueve_Stock = False
            End Select

            _SqlQuery = "-- Abriendo producto: " & _Codigo & " - " & _Descripcion & vbCrLf & vbCrLf &
                        "UPDATE MAEDDO SET CAPRAD1=0,CAPRAD2=0 WHERE IDMAEDDO=" & _Idmaeddo & vbCrLf &
                        "UPDATE MAEDDO SET ESLIDO=CASE WHEN ROUND(CAPRCO1-CAPRAD1-CAPREX1,5)=0 THEN 'C' ELSE '' END" & vbCrLf &
                        "WHERE IDMAEDDO=" & _Idmaeddo & vbCrLf & vbCrLf & _SqlQuery

            If _Mueve_Stock Then

                _SqlQuery += "UPDATE MAEPR SET " & _Campo_Mov_Stock_Ud1 & "+=" & _New_Caprad1 &
                             "," & _Campo_Mov_Stock_Ud2 & "+=" & _New_Caprad2 & vbCrLf &
                             "WHERE KOPR = '" & _Codigo & "'" & vbCrLf &
                             "UPDATE MAEPREM SET " & _Campo_Mov_Stock_Ud1 & "+=" & _New_Caprad1 &
                             "," & _Campo_Mov_Stock_Ud2 & "+=" & _New_Caprad2 & vbCrLf &
                             "WHERE EMPRESA = '" & _Empresa & "' AND KOPR = '" & _Codigo & "'" & vbCrLf &
                             "UPDATE MAEST SET " & _Campo_Mov_Stock_Ud1 & "+=" & _New_Caprad1 &
                             "," & _Campo_Mov_Stock_Ud2 & "+=" & _New_Caprad2 & vbCrLf &
                             "WHERE EMPRESA='" & _Empresa & "' AND KOSU='" & _Sucursal & "' AND  KOBO='" & _Bodega & "' AND  KOPR='" & _Codigo & "'" & vbCrLf & vbCrLf
            End If

        End If

        Return _SqlQuery

    End Function

    Function Fx_Sql_Cerrar_Linea(ByVal _Row_Maeddo As DataRow) As String

        Dim _SqlQuery = String.Empty

        Dim _Idmaeddo = _Row_Maeddo.Item("IDMAEDDO")

        Dim _Caprco1 As Double = _Row_Maeddo.Item("CAPRCO1")
        Dim _Caprad1 As Double = _Row_Maeddo.Item("CAPRAD1")
        Dim _Caprex1 As Double = _Row_Maeddo.Item("CAPREX1")

        Dim _Caprco2 As Double = _Row_Maeddo.Item("CAPRCO2")
        Dim _Caprad2 As Double = _Row_Maeddo.Item("CAPRAD2")
        Dim _Caprex2 As Double = _Row_Maeddo.Item("CAPREX2")

        Dim _Saldo1 As Double = _Caprco1 - (_Caprad1 + _Caprex1)
        Dim _Saldo2 As Double = _Caprco2 - (_Caprad2 + _Caprex2)

        If CBool(_Saldo1) Or CBool(_Saldo2) Then

            Dim _Saldo_Ud1 As String = De_Num_a_Tx_01(_Saldo1, False, 5)
            Dim _Saldo_Ud2 As String = De_Num_a_Tx_01(_Saldo2, False, 5)

            Dim _Empresa As String = _Row_Maeddo.Item("EMPRESA")
            Dim _Sucursal As String = _Row_Maeddo.Item("SULIDO")
            Dim _Bodega As String = _Row_Maeddo.Item("BOSULIDO")

            Dim _Codigo As String = _Row_Maeddo.Item("KOPRCT")
            Dim _Descripcion As String = _Row_Maeddo.Item("NOKOPR")

            Dim _Tido = _Row_Maeddo.Item("TIDO")

            Dim _Campo_Mov_Stock_Ud1, _Campo_Mov_Stock_Ud2 As String
            Dim _Mueve_Stock = True

            Select Case _Tido
                Case "NVV", "NVI"
                    _Campo_Mov_Stock_Ud1 = "STOCNV1"
                    _Campo_Mov_Stock_Ud2 = "STOCNV2"

                    _SqlQuery = "Update " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Stock_X_Producto Set " & Space(1) &
                                "Reservado = 0" & vbCrLf &
                                "Where Idmaeddo_Reserva = " & _Idmaeddo & vbCrLf & vbCrLf
                Case "OCC"
                    _Campo_Mov_Stock_Ud1 = "STOCNV1C"
                    _Campo_Mov_Stock_Ud2 = "STOCNV2C"
                Case Else
                    _Mueve_Stock = False
            End Select


            _SqlQuery = "-- Cerrrando producto: " & _Codigo & " - " & _Descripcion &
                        vbCrLf &
                        vbCrLf &
                        "UPDATE MAEDDO SET CAPRAD1=CAPRAD1+" & _Saldo_Ud1 & ",CAPRAD2=CAPRAD2+" & _Saldo_Ud2 & " WHERE IDMAEDDO=" & _Idmaeddo & vbCrLf &
                        "UPDATE MAEDDO SET ESLIDO=CASE WHEN ROUND(CAPRCO1-CAPRAD1-CAPREX1,5)=0 THEN 'C' ELSE '' END" & vbCrLf &
                        "WHERE IDMAEDDO=" & _Idmaeddo & vbCrLf & vbCrLf & _SqlQuery

            If _Mueve_Stock Then

                _SqlQuery += "UPDATE MAEPR SET " & _Campo_Mov_Stock_Ud1 & "=" & _Campo_Mov_Stock_Ud1 & "-" & _Saldo_Ud1 &
                             "," & _Campo_Mov_Stock_Ud2 & "=" & _Campo_Mov_Stock_Ud2 & "-" & _Saldo_Ud2 & vbCrLf &
                             "WHERE KOPR = '" & _Codigo & "'" & vbCrLf &
                             "UPDATE MAEPREM SET  " & _Campo_Mov_Stock_Ud1 & "=" & _Campo_Mov_Stock_Ud1 & "-" & _Saldo_Ud1 &
                             "," & _Campo_Mov_Stock_Ud2 & "=" & _Campo_Mov_Stock_Ud2 & "-" & _Saldo_Ud2 & vbCrLf &
                             "WHERE EMPRESA = '" & _Empresa & "' AND KOPR = '" & _Codigo & "'" & vbCrLf &
                             "UPDATE MAEST SET " & _Campo_Mov_Stock_Ud1 & "=" & _Campo_Mov_Stock_Ud1 & "-" & _Saldo_Ud1 &
                             "," & _Campo_Mov_Stock_Ud2 & "=" & _Campo_Mov_Stock_Ud2 & "-" & _Saldo_Ud2 & vbCrLf &
                             "WHERE EMPRESA='" & _Empresa & "' AND KOSU='" & _Sucursal &
                             "' AND KOBO='" & _Bodega & "' AND  KOPR='" & _Codigo & "'" & vbCrLf & vbCrLf

            End If

        End If

        Return _SqlQuery

    End Function

    Function Fx_Sql_Cerrar_o_Abrir_Encabezado(ByVal _Idmaeedo As Integer) As String

        Dim _SqlQuery As String

        _SqlQuery = My.Resources.Recursos_Cierre_Documento.SQLQuery_Cerrar_Encabezado
        _SqlQuery = Replace(_SqlQuery, "#Idmaeedo#", _Idmaeedo)

        Return _SqlQuery

    End Function


End Class
