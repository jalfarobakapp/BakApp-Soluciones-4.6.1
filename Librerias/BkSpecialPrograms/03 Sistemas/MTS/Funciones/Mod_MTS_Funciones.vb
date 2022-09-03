Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Data.SqlClient

Module Mod_MTS_Funciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public _Cancelar_Proceso As Boolean

#Region "FUNCIONES"

    Function Fx_LlenarTablaDeFamiliasDeConDescuentos(ByVal _Bar As Object, _
                                                     ByVal _EtiquetaInformativa As Object, _
                                                     ByVal _TxtLog As Object, _
                                                     ByVal _Directorio As String, _
                                                     ByVal _TablaDBF As String, _
                                                     ByVal _Formulario As Form) As Boolean

        Sb_AddToLog("Actualizando descuentos MTS",
                    "Buscando tabla " & _TablaDBF & ".dbf [" & Date.Now.ToLongTimeString & "]",
                    _TxtLog)


        Dim sSelect As String = "SELECT PRVDSP AS CodProveedor,FAMDSP as Familia,PDSDSP as Descuento FROM " & _
                                _TablaDBF & " WHERE PDSDSP > 0"

        Dim sConn As String


        'sConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
        '         System.IO.Path.GetDirectoryName(sBase) & _
        '         ";Extended Properties=dBASE IV;"

        sConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
               _Directorio & _
               ";Extended Properties=dBASE IV;"

        Using dbConn As New System.Data.OleDb.OleDbConnection(sConn)


            'Using dbConn As New System.Data.Odbc.OdbcConnection(sConn)
            Try

                Sb_AddToLog("Actualizando descuentos MTS", _
                   "Conectando la base ... " & _TablaDBF & ".dbf [" & Date.Now.ToLongTimeString & "]", _
                   _TxtLog)

                dbConn.Open()

                Dim daDBF As New System.Data.OleDb.OleDbDataAdapter(sSelect, dbConn)
                Dim dt As New DataTable

                daDBF.Fill(dt)
                Dim Filas As Long = dt.Rows.Count
                Dim Fila As DataRow

                Sb_AddToLog("Actualizando descuentos MTS", _
                   "Conexión exitosa, " & Filas & " registros encontrados [" & Date.Now.ToLongTimeString & "]", _
                   _TxtLog)

                Dim Familia As String
                Dim DescuentoFamilia As Double
                Dim CodProveedor As String

                Consulta_sql = "Truncate table Zw_Tbl_PFMDSP10"
                 _Sql.Ej_consulta_IDU(Consulta_Sql)

                _Bar.Maximum = Filas
                _Bar.Value = 0

                If Filas > 0 Then

                    For i = 0 To Filas - 1
                        System.Windows.Forms.Application.DoEvents()
                        _Bar.Value += 1

                        Fila = dt(i)

                        CodProveedor = Fila.Item("CodProveedor").ToString
                        Familia = Fila.Item("Familia").ToString
                        DescuentoFamilia = Fila.Item("Descuento").ToString

                        _EtiquetaInformativa.Text = "Total Filas: " & Filas & ", Leyendo fila Nro. " & i + 1

                        Consulta_sql = "INSERT INTO Zw_Tbl_PFMDSP10 (CodProveedor,Familia,Descuento)" & _
                                       "values ('" & CodProveedor & "','" & Familia & "'," & De_Num_a_Tx_01(DescuentoFamilia, False, 2) & ")"
                         _Sql.Ej_consulta_IDU(Consulta_Sql)

                        If _Cancelar_Proceso Then
                            Exit For
                        End If

                    Next

                    _Bar.value = 0
                    _EtiquetaInformativa.TEXT = "."
                End If

                dbConn.Close()

                Sb_AddToLog("Actualizando descuentos MTS", _
                  "Proseco completado correctamente. [" & Date.Now.ToLongTimeString & "]", _
                  _TxtLog)

                Return True

            Catch ex As Exception
                _Bar.value = 0
                Sb_AddToLog("Actualizando descuentos MTS", _
                  "Error. [" & Date.Now.ToLongTimeString & "]", _
                  _TxtLog)
                Sb_AddToLog("Actualizando descuentos MTS", _
                 ex.Message & " [" & Date.Now.ToLongTimeString & "]", _
                 _TxtLog)
                Exit Function
            End Try
        End Using

        'End If
        'End With

    End Function

    Function Fx_Revisar_Cambios_Precios_MTS(ByVal _RutaDeArchivo_DBF As String, _
                                            ByVal _TxtLog As Object, _
                                            ByVal _Fecha_Desde As Date, _
                                            ByVal _Fecha_Hasta As Date) As DataTable

        Try

            Dim sBase As String = _RutaDeArchivo_DBF
            Dim _F_Fecha_Desde As String = Format(_Fecha_Desde, "MM-dd-yyyy")
            Dim _F_Fecha_Hasta As String = Format(_Fecha_Hasta, "MM-dd-yyyy")


            Dim sSelect As String

            Sb_AddToLog("Revisando actualizaciones", _
                       "Revisando tabla MODPRD2.dbf [" & Date.Now.ToLongTimeString & "]", _
                       _TxtLog)

            sSelect = "SELECT DISTINCT RUTPRV As Proveedor,FECHA As Fecha FROM MODPRD2" & vbCrLf & _
            "WHERE FECHA Between " & _Fecha_Desde & " And " & _Fecha_Hasta

            sSelect = "SELECT DISTINCT RUTPRV As Proveedor,FECHA As Fecha FROM MODPRD2" & vbCrLf & _
                      "WHERE FECHA Between #" & _F_Fecha_Desde & "# And #" & _F_Fecha_Hasta & "#"


            Dim sConn As String

            sConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
                     _RutaDeArchivo_DBF & _
                     ";Extended Properties=dBASE IV;"

            Using dbConn As New System.Data.OleDb.OleDbConnection(sConn)

                Try
                    dbConn.Open()

                    Dim daDBF As New System.Data.OleDb.OleDbDataAdapter(sSelect, dbConn)
                    Dim dt As New DataTable

                    daDBF.Fill(dt)
                    'Dim Filas As Long = dt.Rows.Count
                    'Dim Fila As DataRow

                    Sb_AddToLog("Revisando actualizaciones", _
                    "Revisando cambios de precios entre: " & _F_Fecha_Desde & " y " & _F_Fecha_Hasta & " [" & Date.Now.ToLongTimeString & "]", _
                    _TxtLog)

                    Return dt

                    dbConn.Close()

                Catch ex As Exception
                    Sb_AddToLog("Actualizando descuentos MTS", "Error. [" & Date.Now.ToLongTimeString & "]", _TxtLog)
                    Sb_AddToLog("Actualizando descuentos MTS", ex.Message & " [" & Date.Now.ToLongTimeString & "]", _TxtLog)
                    Return Nothing
                End Try
            End Using


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Sub Fx_Actualizar_Lista_Por_Proveedor(ByVal _Bar As Object, _
                                          ByVal _TxtLog As Object, _
                                          ByVal _EtiquetaInformativa As Object, _
                                          ByVal _RutaDeArchivo As String, _
                                          ByVal _CodProveedor As String, _
                                          ByVal _SucProveedor As String, _
                                          ByVal _Lista As String, _
                                          ByVal _Nro_Fila As Integer, _
                                          ByVal _Nro_Total_Proveedores As Integer, _
                                          ByVal _Fecha_Act_P As Date, _
                                          ByVal _GuardarConDscto As Boolean)

        _EtiquetaInformativa.text = "."

        Try

            '_Sql.Fx_Trae_Dato(
            Dim _Proveedor_Razonsocial = _Sql.Fx_Trae_Dato("MAEEN", "NOKOEN", "KOEN = '" & Trim(_CodProveedor) & "'")
            Dim _Proveedor_Sigla = _Sql.Fx_Trae_Dato("MAEEN", "SIEN", "KOEN = '" & Trim(_CodProveedor) & "'")
            '_CodProveedor

            Sb_AddToLog("Actualizando lista de proveedores Nro: " & _Nro_Fila & " de " & _Nro_Total_Proveedores,
                        Trim(_CodProveedor) & "-" & Trim(_Proveedor_Razonsocial) & " [" & Date.Now.ToLongTimeString & "]", _TxtLog)

            Dim sBase As String = _RutaDeArchivo
            Dim sSelect As String = "SELECT CPPPRD AS Codigo," &
                                    "DESPRD as Descripcion," &
                                    "UMEPRD as UnCompra," &
                                    "UMCPRD as UnMinimCompra," &
                                    "PLIPRD as Costo,FAMPRD as Familia FROM " & Trim(_CodProveedor)
            Dim sConn As String

            sConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" &
                     _RutaDeArchivo &
                     ";Extended Properties=dBASE IV;"

            Using dbConn As New System.Data.OleDb.OleDbConnection(sConn)

                Try
                    dbConn.Open()

                    Dim daDBF As New System.Data.OleDb.OleDbDataAdapter(sSelect, dbConn)
                    Dim dt As New DataTable

                    daDBF.Fill(dt)
                    Dim Filas As Long = dt.Rows.Count
                    Dim Fila As DataRow

                    Dim _Fecha_Act As String = Format(_Fecha_Act_P, "yyyyMMdd")
                    Dim _CodigoMTS As String
                    Dim _Codigo As String
                    Dim _Descripcion_MTS As String
                    Dim _Descripcion_RD As String
                    Dim _Familia As String
                    Dim _CostoProveedor As Double
                    Dim _CostoUd1,
                        _CostoUd2 As Double
                    Dim _DescuentoFamilia As Double
                    Dim _Descuento As Double
                    Dim _TotalDescuento As Double
                    Dim _CostoFinal As Double
                    Dim _UnMinimCompra As Integer
                    Dim _Rtu As Integer
                    Dim _UnCompra As String


                    Consulta_sql = String.Empty


                    _Bar.Maximum = Filas
                    _Bar.Value = 0

                    Consulta_sql = "Delete Zw_ListaPreCosto Where Lista = '" & _Lista &
                                   "' And Proveedor = '" & _CodProveedor & "'" & vbCrLf & Consulta_sql

                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    If Filas > 0 Then
                        Dim Existen As Long = 0

                        For i = 0 To Filas - 1
                            System.Windows.Forms.Application.DoEvents()
                            _Bar.Value += 1

                            'If i = 79 Then
                            ' MsgBox("aca")
                            ' End If

                            Fila = dt(i)

                            _CodigoMTS = Fila.Item("Codigo").ToString
                            _Codigo = Trim(_Sql.Fx_Trae_Dato("TABCODAL", "KOPR",
                                                     "KOPRAL = '" & _CodigoMTS & "' AND KOEN = '" & Trim(_CodProveedor) & "'"))


                            _EtiquetaInformativa.text = "Total Filas: " & Filas & ", Leyendo fila Nro. " & i + 1 & ", Articulo encontrado en Random " & Existen

                            _Descripcion_MTS = Fila.Item("Descripcion").ToString
                            _Familia = Trim(Fila.Item("Familia").ToString)
                            _CostoProveedor = Fila.Item("Costo").ToString

                            _UnMinimCompra = Fila.Item("UnMinimCompra").ToString
                            _UnCompra = Trim(Fila.Item("UnCompra").ToString)


                            _DescuentoFamilia = De_Txt_a_Num_01(_Sql.Fx_Trae_Dato("Zw_Tbl_PFMDSP10", "Descuento",
                                             "Familia = '" & _Familia & "' and CodProveedor LIKE '%" & Trim(_CodProveedor) & "%'", True), 3)
                            _Descuento = _DescuentoFamilia
                            _DescuentoFamilia = _DescuentoFamilia / 100
                            _TotalDescuento = (_CostoProveedor * _DescuentoFamilia)

                            _CostoFinal = Math.Round(_CostoProveedor - _TotalDescuento, 0)

                            If _GuardarConDscto Then
                                _CostoProveedor = _CostoFinal
                                _Descuento = 0
                            End If


                            If _Codigo <> "" Then
                                Existen += 1
                                _Rtu = _Sql.Fx_Trae_Dato("MAEPR", "RLUD", "KOPR = '" & _Codigo & "'", True)
                                _Descripcion_RD = _Sql.Fx_Trae_Dato("MAEPR", "NOKOPR", "KOPR = '" & _Codigo & "'")

                                If _Rtu > 1 Then
                                    _CostoUd2 = _CostoProveedor
                                    _CostoUd1 = _CostoUd2 / _Rtu
                                Else
                                    _CostoUd2 = _CostoProveedor
                                    _CostoUd1 = _CostoUd2 * _Rtu
                                End If

                                '_CostoUd1 = _CostoProveedor
                                '_CostoUd2 = 0 '_CostoProveedor * _Rtu



                            Else
                                _Rtu = 0
                                _Descripcion_RD = String.Empty
                                _CostoUd1 = _CostoProveedor
                                _CostoUd2 = 0 ' _CostoProveedor
                            End If


                            _Descripcion_RD = Replace(_Descripcion_RD, "'", "''")
                            _Descripcion_MTS = Replace(_Descripcion_MTS, "'", "''")

                            Dim Reg As Boolean
                            Reg =_Sql.Fx_Cuenta_Registros("Zw_ListaPreCosto", _
                                                 "Proveedor = '" & _CodProveedor & _
                                                 "' And CodAlternativo = '" & _CodigoMTS & _
                                                 "' And Codigo = '" & _Codigo & _
                                                 "' And Lista = '" & _Lista & "'")

                            If Not Reg Then

                                Consulta_sql = "Insert Into Zw_ListaPreCosto (Lista,Proveedor,Sucursal,CodAlternativo,Codigo," & _
                                                "Descripcion,Descripcion_Alt,CostoUd1,CostoUd2,Rtu,FechaVigencia," & _
                                                "Desc1,Desc2,Desc3,Desc4,Desc5,DescSuma,Flete," & _
                                                "Un_Compra,Un_MinCompra) Values " & vbCrLf & _
                                                "('" & _Lista & "','" & _CodProveedor & "','" & _SucProveedor & "','" & _CodigoMTS & _
                                                "','" & _Codigo & "','" & _Descripcion_RD & "','" & _Descripcion_MTS & _
                                                "'," & De_Num_a_Tx_01(_CostoUd1) & "," & De_Num_a_Tx_01(_CostoUd2) & _
                                                "," & De_Num_a_Tx_01(_Rtu, , 5) & ",'" & _Fecha_Act & _
                                                "'," & De_Num_a_Tx_01(_Descuento) & _
                                                ",0,0,0,0,0," & De_Num_a_Tx_01(_Descuento) & _
                                                ",'" & _UnCompra & "'," & _UnMinimCompra & ")" '& vbCrLf & "-- Filas " & i & vbCrLf

                                 _Sql.Ej_consulta_IDU(Consulta_Sql)

                            End If

                            If _Cancelar_Proceso Then Exit For

                        Next


                        Sb_AddToLog("Actualizando lista de proveedores", _
                        "Productos Actualizados: " & FormatNumber(Filas, 0) & _
                        ", Productos encontrados en el Sistema: " & FormatNumber(Existen, 0) & _
                        " [" & Date.Now.ToLongTimeString & "]", _TxtLog)


                        ' Consulta_sql = "Update Zw_TblListaMTSvsProveedores Set Seleccion = 1 Where Endo = '" & _CodProveedor & "'"
                        '  _Sql.Ej_consulta_IDU(Consulta_Sql)

                        'Consulta_sql = "SELECT dbo." & TblPaso & ".CodProveedor, " & vbCrLf & _
                        '               "dbo." & TblPaso & ".CodigoMTS, " & vbCrLf & _
                        '               "dbo." & TblPaso & ".CodigoRandom, " & vbCrLf & _
                        '               "dbo." & TblPaso & ".Descripcion, " & vbCrLf & _
                        '               "dbo." & TblPaso & ".CostoProveedor," & vbCrLf & _
                        '               "dbo." & TblPaso & ".DescuentoFamilia," & vbCrLf & _
                        '               "dbo." & TblPaso & ".TotalDescuento, " & vbCrLf & _
                        '               "dbo." & TblPaso & ".CostoFinal," & vbCrLf & _
                        '               "ISNULL(dbo.TABPRE.PP02UD, 0) AS CostoLista " & vbCrLf & _
                        '               "FROM dbo." & TblPaso & " LEFT OUTER JOIN" & vbCrLf & _
                        '               "dbo.TABPRE ON " & vbCrLf & _
                        '               "dbo." & TblPaso & ".CodigoRandom = dbo.TABPRE.KOPR" & vbCrLf & _
                        '               "WHERE     (dbo.TABPRE.KOLT = '" & LblListadecostos.Text & "')"

                        'Consulta_sql = "SELECT dbo." & TblPaso & ".CodProveedor, " & vbCrLf & _
                        '              "dbo." & TblPaso & ".CodigoMTS, " & vbCrLf & _
                        '              "dbo." & TblPaso & ".CodigoRandom, " & vbCrLf & _
                        '             "dbo." & TblPaso & ".Descripcion, " & vbCrLf & _
                        '             "dbo." & TblPaso & ".CostoProveedor," & vbCrLf & _
                        '             "dbo." & TblPaso & ".DescuentoFamilia," & vbCrLf & _
                        ''             "dbo." & TblPaso & ".TotalDescuento, " & vbCrLf & _
                        '             "dbo." & TblPaso & ".CostoFinal" & vbCrLf & _
                        '            "FROM dbo." & TblPaso



                        '& TblPaso CostoFinal-CostoLista
                        'Ejecutar_consulta_SQL(Consulta_sql, cn1)

                        'tb = New DataTable

                        'da.Fill(tb)
                        'GrillaListaDePrecios.DataSource = tb

                        'FormatoGrilla(GrillaListaDePrecios)

                        _Bar.Value = 0
                    End If

                    'GrillaListaDePrecios.DataSource = dt
                    dbConn.Close()

                    'MsgBox(EtiquetaInformativa.TEXT, MsgBoxStyle.Information, "Proceso terminado")
                    _EtiquetaInformativa.text = "."

                Catch ex As Exception
                    _Bar.Value = 0
                    Sb_AddToLog("Actualizando lista de proveedores", "Error. [" & Date.Now.ToLongTimeString & "]", _TxtLog)
                    Sb_AddToLog("Actualizando lista de proveedores", ex.Message & " [" & Date.Now.ToLongTimeString & "]", _TxtLog)
                    Exit Sub
                End Try
            End Using


            ' El nombre del fichero
            'txtSelect.Text = System.IO.Path.GetFileNameWithoutExtension(txtFic.Text)
            'btnAbrir_Click(Nothing, Nothing)
            'End If
            'End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


#End Region

End Module
