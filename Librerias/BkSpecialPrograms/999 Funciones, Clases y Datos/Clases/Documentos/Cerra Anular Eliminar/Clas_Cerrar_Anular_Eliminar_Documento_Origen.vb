Imports DevComponents.DotNetBar

Public Class Clas_Cerrar_Anular_Eliminar_Documento_Origen

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Enum Enum_Accion
        Anular
        Eliminar
        Modificar
        Cerrar
    End Enum

    Sub Sb_Cerrar_Documentos_De_Origen(ByVal _Formulario As Form, _
                                       ByVal _Accion As Enum_Accion, _
                                       ByVal _TblDocumentos_Dori As DataTable, _
                                       ByVal _New_Idmaeedo As Integer)

        If Not (_TblDocumentos_Dori Is Nothing) Then

            For Each Fila As DataRow In _TblDocumentos_Dori.Rows

                Dim _Idmaeedo_Dori = Fila.Item("IDMAEEDO")

                Consulta_sql = "Select EMPRESA,SULIDO,BOSULIDO,TIDO,KOPRCT As KOPR,NOKOPR,(Select Top 1 RLUD From MAEPR Where KOPR = KOPRCT) As RLUD" & vbCrLf &
                               "From MAEDDO Where IDMAEEDO = " & _Idmaeedo_Dori
                Dim _TblConsolidar_Stock As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                Select Case _Accion

                    Case Enum_Accion.Anular

                        ' Anulamos la Cotización Original para Reemplazarla por una Nueva cotización

                        Consulta_sql = "Update MAEDDO Set ARCHIRST = '',IDRST = 0,EMPREPA = '',TIDOPA ='',NUDOPA = '',NULIDOPA = ''" & vbCrLf &
                                       "Where IDMAEEDO = " & _New_Idmaeedo
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                        If Fx_EliminarAnular_Doc(_Formulario, _Idmaeedo_Dori, FUNCIONARIO,
                                                 Clas_Cerrar_Anular_Eliminar_Documento_Origen.Enum_Accion.Anular, False, False) Then
                            Sb_Consolidar_Stock(_TblConsolidar_Stock)
                            Exit For
                        End If

                    Case Enum_Accion.Eliminar

                        Consulta_sql = "Update MAEDDO Set ARCHIRST = '',IDRST = 0,EMPREPA = '',TIDOPA ='',NUDOPA = '',NULIDOPA = ''" & vbCrLf &
                                         "Where IDMAEEDO = " & _New_Idmaeedo
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                        If Fx_EliminarAnular_Doc(_Formulario, _Idmaeedo_Dori, FUNCIONARIO,
                                                 Clas_Cerrar_Anular_Eliminar_Documento_Origen.Enum_Accion.Eliminar, False, False) Then
                            Sb_Consolidar_Stock(_TblConsolidar_Stock)
                            Exit For
                        End If

                    Case Enum_Accion.Cerrar

                        Dim _Observacion = String.Empty

                        Consulta_sql = "Select TIDO+'-'+NUDO As NewDoc From MAEEDO Where IDMAEEDO = " & _New_Idmaeedo
                        Dim _RowNewDocumento As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                        If Not (_RowNewDocumento Is Nothing) Then

                            _Observacion = "Este documento es reemplazado por el documento " & _RowNewDocumento.Item("NewDoc") & vbCrLf &
                                           "Gestión realizada por BakApp"

                            _Observacion = "Delete MAEEDOOB Where IDMAEEDO = " & _Idmaeedo_Dori & vbCrLf &
                                           "Insert Into MAEEDOOB (IDMAEEDO,OBDO) Values (" & _Idmaeedo_Dori & ",'" & _Observacion & "')" & vbCrLf

                        End If

                        ' Cerramos el documento de origen
                        Consulta_sql = "Update MAEEDO Set ESDO = 'C',CAPRAD = CAPRCO-CAPREX" & vbCrLf &
                                       "Where IDMAEEDO = " & _Idmaeedo_Dori & vbCrLf &
                                       "Update MAEDDO Set ESLIDO = 'C',CAPRAD1 = CAPRCO1-CAPREX1,CAPRAD2 = CAPRCO2-CAPREX2" & vbCrLf &
                                       "Where IDMAEEDO = " & _Idmaeedo_Dori & vbCrLf & _Observacion

                        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

                End Select

            Next

        End If

    End Sub

    Sub Sb_Consolidar_Stock(ByVal _TblConsolidar_Stock As DataTable)

        Dim _Consolidar As New Class_Consolidar_Stock()

        For Each _Fila As DataRow In _TblConsolidar_Stock.Rows
            Dim _Tido = _Fila.Item("TIDO")
            If _Tido <> "COV" Then
                Dim _Empresa = _Fila.Item("EMPRESA")
                Dim _Sucursal = _Fila.Item("SULIDO")
                Dim _Bodega = _Fila.Item("BOSULIDO")
                _Consolidar.Fx_Consolidar_Stock_x_producto_Unico(_Empresa, _Sucursal, _Bodega, _Fila, False, True)
            End If
        Next

    End Sub

    Function Fx_EliminarAnular_Doc(_Formulario As Form,
                                   _Idmaeedo As Integer,
                                   _Cod_Func_Eliminador As String,
                                   _Accion As Enum_Accion,
                                   _Mostrar_Mensaje As Boolean,
                                   _Reversar_Stock As Boolean) As Boolean

        Dim _FechaEliminacion = FechaDelServidor()

        If Not Revisar_Si_Se_Puede_Eliminar_El_Documento(_Formulario, _Idmaeedo, _Accion, _Mostrar_Mensaje) Then
            Return False
        End If

        Try

            Dim Fecha_Elimi As String = Format(_FechaEliminacion, "yyyyMMdd")

            Consulta_sql = "Select EMPRESA,SUDO,TIDO,NUDO,ENDO,SUENDO,FEEMDO,KOFUDO,VANEDO,VABRDO" & vbCrLf &
                           "From MAEEDO" & vbCrLf &
                           "Where IDMAEEDO = " & _Idmaeedo
            Dim Tabla_Doc As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            With Tabla_Doc.Rows(0)

                Dim _Endo As String = Trim(.Item("ENDO"))
                Dim _Suendo As String = Trim(.Item("SUENDO"))
                Dim _Tido As String = Trim(.Item("TIDO"))
                Dim _Nudo As String = .Item("NUDO")
                Dim _Fecha_Doc_Origen As Date = .Item("FEEMDO")
                Dim _Fecha_Eliminacion As String = Fecha_Elimi
                Dim _Funcionario_Doc_Origen As String = .Item("KOFUDO")
                Dim _Funcionario_Eliminador As String = _Cod_Func_Eliminador
                Dim _Empresa As String = .Item("EMPRESA")
                Dim _Sucursal As String = .Item("SUDO")
                Dim _Neto_Doc_Origen As String = .Item("VANEDO")
                Dim _Bruto_Doc_Origen As String = .Item("VABRDO")

                Dim _Fecha_Ori As String = Format(_Fecha_Doc_Origen, "yyyyMMdd")

                If _Accion = Enum_Accion.Anular Then

                    Consulta_sql = "Insert Into ELIDDO Select * From MAEDDO Where MAEDDO.IDMAEEDO = " & _Idmaeedo & vbCrLf &
                                   "Insert Into ELIEDO Select * From MAEEDO Where MAEEDO.IDMAEEDO = " & _Idmaeedo & vbCrLf &
                                   "Update MAEEDO Set ESDO = 'N',LIBRO = '',KOFUAUDO = '" & _Cod_Func_Eliminador & "' Where IDMAEEDO =" & _Idmaeedo & vbCrLf & vbCrLf

                ElseIf _Accion = Enum_Accion.Eliminar Then

                    Consulta_sql = "Insert Into MAEELIMI (EMPRESA,TIDO,NUDO,ENDO,SUENDO,FEEMDO,FEELIDO,KOFUDO,VANEDO,VABRDO)" & vbCrLf &
                                    "Select EMPRESA,TIDO,NUDO,ENDO,SUENDO,FEEMDO,'" & _Fecha_Eliminacion & "',KOFUDO,VANEDO,VABRDO" & vbCrLf &
                                    "From MAEEDO" & vbCrLf &
                                    "Where IDMAEEDO =" & _Idmaeedo & vbCrLf &
                                    "Insert Into ELIDDO Select * From MAEDDO Where MAEDDO.IDMAEEDO = " & _Idmaeedo & vbCrLf &
                                    "Insert Into ELIEDO Select * From MAEEDO Where MAEEDO.IDMAEEDO = " & _Idmaeedo & vbCrLf &
                                    "Delete MAEEDO Where IDMAEEDO =" & _Idmaeedo & vbCrLf

                ElseIf _Accion = Enum_Accion.Modificar Then

                    Consulta_sql = "Delete MAEEDO Where IDMAEEDO =" & _Idmaeedo & vbCrLf

                End If

                'If _Reversar_Stock Then Consulta_sql += Fx_Reversar_Stock(_Idmaeedo, _Tido)
                If _Reversar_Stock Then Consulta_sql += Fx_Reversar_Stock2(_Idmaeedo, _Tido)

                Consulta_sql +=
                               "Delete From MAEPOSLI" & vbCrLf &
                               "Where MAEPOSLI.IDMAEDDO IN (Select IDMAEDDO From MAEDDO Where IDMAEEDO=" & _Idmaeedo & ")" & vbCrLf &
                               "Delete From MEVENTO Where ARCHIRVE='MAEEDO' And IDRVE=" & _Idmaeedo & vbCrLf &
                               "Delete From MAEIMLI Where IDMAEEDO =" & _Idmaeedo & vbCrLf &
                               "Delete From MAEDTLI Where IDMAEEDO=" & _Idmaeedo & vbCrLf &
                               "Delete From MEVENTO " &
                               "Where ARCHIRVE='MAEDDO' And IDRVE IN (Select IDMAEDDO From MAEDDO Where IDMAEEDO=" & _Idmaeedo & ")" & vbCrLf &
                               "Delete From MAEDDO Where IDMAEEDO=" & _Idmaeedo & vbCrLf &
                               "Delete From MAEVEN Where IDMAEEDO=" & _Idmaeedo & vbCrLf &
                               "Delete From MAEEDOOB Where IDMAEEDO=" & _Idmaeedo & vbCrLf &
                               "Delete From TABPERMISO Where IDRST=" & _Idmaeedo & " And ARCHIRST='MAEEDO'" & vbCrLf &
                               "Select TOP 1 * From MAEDCR WITH (NOLOCK) Where IDMAEEDO=" & _Idmaeedo & vbCrLf &
                               "Delete From MAEDCR Where IDMAEEDO=" & _Idmaeedo & vbCrLf & vbCrLf

                Consulta_sql = Replace(Consulta_sql, "#Idmaeedo#", _Idmaeedo)

                _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

                If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                    Throw New System.Exception(_Sql.Pro_Error)
                End If

                Return True

            End With

        Catch ex As Exception

            'My.Computer.FileSystem.WriteAllText("Archivo_Salida_Error.Log", ex.Message & vbCrLf & ex.StackTrace, False)
            'MessageBoxEx.Show(_Formulario, ex.Message, "Error", _
            '                  Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            MessageBoxEx.Show(_Formulario, "Transaccion desecha" & vbCrLf & vbCrLf & "Error: " & ex.Message, "Problema",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
        End Try

    End Function

    Function Fx_Reversar_Stock(_Idmaeedo As Integer, _Tido As String) As String

        Dim _Consulta_sql = String.Empty

        Dim _Campo1 As String
        Dim _Campo2 As String

        If _Tido = "OCC" Then _Campo1 = "STOCNV1C" : _Campo2 = "STOCNV2C"
        If _Tido = "NVV" Then _Campo1 = "STOCNV1" : _Campo2 = "STOCNV1"

        Consulta_sql = "Select * From MAEDDO Where IDMAEEDO = " & _Idmaeedo & " Order By IDMAEDDO"
        Dim _Tbl_Detalle As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        For Each _Fila As DataRow In _Tbl_Detalle.Rows

            Dim _Empresa As String = _Fila.Item("EMPRESA")
            Dim _Kosu As String = _Fila.Item("SULIDO")
            Dim _Kobo As String = _Fila.Item("BOSULIDO")

            Dim _Koprct As String = _Fila.Item("KOPRCT")
            Dim _CantUd1 As String = De_Num_a_Tx_01(_Fila.Item("CAPRCO1"), False, 5)
            Dim _CantUd2 As String = De_Num_a_Tx_01(_Fila.Item("CAPRCO2"), False, 5)

            _Consulta_sql += "Update MAEPREM Set " & _Campo1 & " = " & _Campo1 & " +- " & _CantUd1 & "," & _Campo2 & " = " & _Campo2 & " +-" & _CantUd2 &
                             " Where EMPRESA = '" & _Empresa & "' And KOPR = '" & _Koprct & "'
                             Update MAEPR Set " & _Campo1 & " = " & _Campo1 & " +-" & _CantUd1 & "," & _Campo2 & " = " & _Campo2 & " +-" & _CantUd2 &
                             " Where KOPR = '" & _Koprct & "'
                             Update MAEST Set " & _Campo1 & " = " & _Campo1 & " +-" & _CantUd1 & "," & _Campo2 & " = " & _Campo2 & " +-" & _CantUd2 &
                             " Where EMPRESA='" & _Empresa & "' And KOSU='" & _Kosu & "' And KOBO='" & _Kobo & "' And KOPR='" & _Koprct & "'" & vbCrLf & vbCrLf

        Next

        Return _Consulta_sql

    End Function

    Function Fx_Reversar_Stock2(_Idmaeedo As Integer, _Tido As String) As String

        Dim _Consulta_sql = String.Empty

        Dim _Campo1 As String
        Dim _Campo2 As String

        Dim _Sr As String

        Consulta_sql = "Select * From MAEDDO Where IDMAEEDO = " & _Idmaeedo & " Order By IDMAEDDO"
        Dim _Tbl_Detalle As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        For Each _Fila As DataRow In _Tbl_Detalle.Rows

            Dim _Empresa As String = _Fila.Item("EMPRESA")
            Dim _Kosu As String = _Fila.Item("SULIDO")
            Dim _Kobo As String = _Fila.Item("BOSULIDO")

            Dim _Koprct As String = _Fila.Item("KOPRCT")
            Dim _CantUd1 As String = De_Num_a_Tx_01(_Fila.Item("CAPRCO1"), False, 5)
            Dim _CantUd2 As String = De_Num_a_Tx_01(_Fila.Item("CAPRCO2"), False, 5)
            Dim _Lincondesp As Boolean = _Fila.Item("LINCONDESP")

            If _Tido = "OCC" Then _Campo1 = "STOCNV1C" : _Campo2 = "STOCNV2C" : _Sr = "-"
            If _Tido = "NVV" Then _Campo1 = "STOCNV1" : _Campo2 = "STOCNV1" : _Sr = "-"

            If _Tido = "BLV" Or _Tido = "FCV" Then
                If _Lincondesp Then
                    _Campo1 = "STFI1" : _Campo2 = "STFI2" : _Sr = "+"
                Else
                    _Campo1 = "STDV1" : _Campo2 = "STDV2" : _Sr = "-"
                End If
            End If

            '_Consulta_sql += "Update MAEPREM Set " & _Campo1 & " = " & _Campo1 & " +- " & _CantUd1 & "," & _Campo2 & " = " & _Campo2 & " +-" & _CantUd2 &
            '                 " Where EMPRESA = '" & _Empresa & "' And KOPR = '" & _Koprct & "'
            '                 Update MAEPR Set " & _Campo1 & " = " & _Campo1 & " +-" & _CantUd1 & "," & _Campo2 & " = " & _Campo2 & " +-" & _CantUd2 &
            '                 " Where KOPR = '" & _Koprct & "'
            '                 Update MAEST Set " & _Campo1 & " = " & _Campo1 & " +-" & _CantUd1 & "," & _Campo2 & " = " & _Campo2 & " +-" & _CantUd2 &
            '                 " Where EMPRESA='" & _Empresa & "' And KOSU='" & _Kosu & "' And KOBO='" & _Kobo & "' And KOPR='" & _Koprct & "'" & vbCrLf & vbCrLf

            _Consulta_sql += "Update MAEPREM Set " & _Campo1 & " = " & _Campo1 & _Sr & _CantUd1 & "," & _Campo2 & " = " & _Campo2 & _Sr & _CantUd2 &
                             " Where EMPRESA = '" & _Empresa & "' And KOPR = '" & _Koprct & "'
                             Update MAEPR Set " & _Campo1 & " = " & _Campo1 & _Sr & _CantUd1 & "," & _Campo2 & " = " & _Campo2 & _Sr & _CantUd2 &
                             " Where KOPR = '" & _Koprct & "'
                             Update MAEST Set " & _Campo1 & " = " & _Campo1 & _Sr & _CantUd1 & "," & _Campo2 & " = " & _Campo2 & _Sr & _CantUd2 &
                             " Where EMPRESA='" & _Empresa & "' And KOSU='" & _Kosu & "' And KOBO='" & _Kobo & "' And KOPR='" & _Koprct & "'" & vbCrLf & vbCrLf
            If _Lincondesp Then

                Consulta_sql += "UPDATE MAEPMSUC SET STFI1 = STFI1 + " & _CantUd1 & ",STFI2 = STFI2 + " & _CantUd2 &
                                " Where EMPRESA='" & _Empresa & "' AND KOSU='" & _Kosu & "' AND KOPR='" & _Koprct & "'" & vbCrLf & vbCrLf

            End If


        Next

        Return _Consulta_sql

    End Function

    Function Revisar_Si_Se_Puede_Eliminar_El_Documento(ByVal _Formulario As Form,
                                                       ByVal _Idmaeedo As Integer,
                                                       ByVal _Accion As Enum_Accion,
                                                       Optional ByVal _Mostrar_Mensaje As Boolean = False) As Boolean

        Consulta_sql = "Select Top 1 IDMAEEDO,TIDO,NUDO,NUDONODEFI From MAEEDO Where IDMAEEDO = " & _Idmaeedo
        Dim _Tbl_Documento As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl_Documento.Rows.Count) Then

            Dim _Tido As String = _Tbl_Documento.Rows(0).Item("TIDO")
            Dim _Nudonodefi As Boolean = _Tbl_Documento.Rows(0).Item("NUDONODEFI")

            If _Nudonodefi Then
                Return True
            End If

            Dim Dst_Paso As New DataSet

            Consulta_sql = My.Resources.Recursos_Eliminar_Anular_Cerra_Doc.Revisar_sutentatorio
            Consulta_sql = Replace(Consulta_sql, "#Idmaeedo#", _Idmaeedo)
            Consulta_sql = Replace(Consulta_sql, "#Tido#", _Tido)

            Dst_Paso = _Sql.Fx_Get_DataSet(Consulta_sql)

            For Each Tabla As DataTable In Dst_Paso.Tables
                If CBool(Tabla.Rows.Count) Then
                    If _Mostrar_Mensaje Then
                        MessageBoxEx.Show(_Formulario,
                                          "El documento es sustentatorio de otro documento" & vbCrLf &
                                          "No es posible " & _Accion.ToString & " documento",
                                          UCase(_Accion) & " DOCUMENTO",
                                          Windows.Forms.MessageBoxButtons.OK,
                                          Windows.Forms.MessageBoxIcon.Error)
                    End If
                    Return False ' NO SE PUEDE ELIMINAR
                End If
            Next

            Return True ' SI SE PUEDE ELIMINAR

        End If

    End Function

End Class
