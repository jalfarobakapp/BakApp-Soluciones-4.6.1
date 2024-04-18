Imports System.Data.SqlClient
Imports BkSpecialPrograms

Public Class Cl_Mezcla

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Zw_Pdp_CPT_MzEnc As New Zw_Pdp_CPT_MzEnc
    Public Property Zw_Pdp_CPT_MzDet As New Zw_Pdp_CPT_MzDet
    Public Property Zw_Pdp_CPT_MzDetIngFab As New Zw_Pdp_CPT_MzDetIngFab
    Public Property Ls_Zw_Pdp_CPT_MzDet As New List(Of Zw_Pdp_CPT_MzDet)

    Public Sub New()

    End Sub

    Function Fx_Llenar_Zw_Pdp_CPT_MzEnc(_Id_Enc As Integer) As LsValiciones.Mensajes

        Dim _Mensaje_Mezcla As New LsValiciones.Mensajes

        Try

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_CPT_MzEnc Where Id = " & _Id_Enc
            Dim _Row_MzEnc As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row_MzEnc) Then
                Throw New System.Exception("No se encontro el registro en la tabla Zw_Pdp_CPT_MzEnc con el Id: " & _Id_Enc)
            End If

            With Zw_Pdp_CPT_MzEnc

                .Id = _Row_MzEnc.Item("Id")
                .Empresa = _Row_MzEnc.Item("Empresa")
                .Nro_MZC = _Row_MzEnc.Item("Nro_MZC")
                .Idpote_Otm = _Row_MzEnc.Item("Idpote_Otm")
                .Idpotl_Otm = _Row_MzEnc.Item("Idpotl_Otm")
                .Numot_Otm = _Row_MzEnc.Item("Numot_Otm")
                .Fiot_Otm = _Row_MzEnc.Item("Fiot_Otm")
                .Codigo_Otm = _Row_MzEnc.Item("Codigo_Otm")
                .Descripcion_Otm = _Row_MzEnc.Item("Descripcion_Otm")
                .FechaCreacion = _Row_MzEnc.Item("FechaCreacion")
                .Referencia = _Row_MzEnc.Item("Referencia")
                .CodFuncionario = _Row_MzEnc.Item("CodFuncionario")
                .Estado = _Row_MzEnc.Item("Estado")
                .Idpote = _Row_MzEnc.Item("Idpote")
                .FechaCreacionOT = NuloPorNro(_Row_MzEnc.Item("FechaCreacionOT"), Now.Date)

                _Mensaje_Mezcla.EsCorrecto = True
                _Mensaje_Mezcla.Id = .Id

            End With

        Catch ex As Exception
            _Mensaje_Mezcla.Mensaje = ex.Message
        End Try

        Return _Mensaje_Mezcla

    End Function

    Function Fx_Llenar_Zw_Pdp_CPT_MzDet(_Id_Det As Integer) As LsValiciones.Mensajes

        Dim _Mensaje_Mezcla As New LsValiciones.Mensajes

        Try

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_CPT_MzDet Where Id = " & _Id_Det
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row) Then
                Throw New System.Exception("No se encontro el registro en la tabla Zw_Pdp_CPT_MzDet con el Id: " & _Id_Det)
            End If

            With Zw_Pdp_CPT_MzDet

                .Id = _Row.Item("Id")
                .Id_Enc = _Row.Item("Id_Enc")
                .Empresa = _Row.Item("Empresa")
                .SucursalDef = _Row.Item("SucursalDef")
                .BodegaDef = _Row.Item("BodegaDef")
                .FechaCreacion = NuloPorNro(_Row.Item("FechaCreacion"), Now.Date)
                .Idpote_Otm = _Row.Item("Idpote_Otm")
                .Idpotl_Otm = _Row.Item("Idpotl_Otm")
                .CodFuncionario = _Row.Item("CodFuncionario")
                .Codigo = _Row.Item("Codigo")
                .Descripcion = _Row.Item("Descripcion")
                .Codnomen = _Row.Item("Codnomen")
                .Descriptor = _Row.Item("Descriptor")
                .Cantnomen = _Row.Item("Cantnomen")
                .Udad = _Row.Item("Udad")
                .CantFabricar = _Row.Item("CantFabricar")
                .CantFabricada = _Row.Item("CantFabricada")

                _Mensaje_Mezcla.EsCorrecto = True
                _Mensaje_Mezcla.Id = .Id

            End With

        Catch ex As Exception
            _Mensaje_Mezcla.Mensaje = ex.Message
        End Try

        Return _Mensaje_Mezcla

    End Function

    Function Fx_Llenar_Zw_Pdp_CPT_MzDetIngFab(_Id_DetIngFab) As LsValiciones.Mensajes

        Dim _Mensaje_Mezcla As New LsValiciones.Mensajes

        Try

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_CPT_MzDetIngFab Where Id = " & _Id_DetIngFab
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row) Then
                Throw New System.Exception("No se encontro el registro en la tabla Zw_Pdp_CPT_MzDetIngFab con el Id: " & _Id_DetIngFab)
            End If

            With Zw_Pdp_CPT_MzDetIngFab

                .Id = _Row.Item("Id")
                .Id_Det = _Row.Item("Id_Det")
                .Id_Enc = _Row.Item("Id_Enc")
                .Codigo = _Row.Item("Codigo")
                .Descripcion = _Row.Item("Descripcion")
                .Udad = _Row.Item("Udad")
                .CantIngresada = _Row.Item("CantIngresada")
                .CantFabricada = _Row.Item("CantFabricada")
                .CodFuncionario = _Row.Item("CodFuncionario")
                .FechaFabricacion = _Row.Item("FechaFabricacion")

                _Mensaje_Mezcla.EsCorrecto = True
                _Mensaje_Mezcla.Id = .Id

            End With

        Catch ex As Exception
            _Mensaje_Mezcla.Mensaje = ex.Message
        End Try

        Return _Mensaje_Mezcla

    End Function

    Function Fx_Crear_Nueva_Mezcla() As LsValiciones.Mensajes

        Dim _Mensaje_Mezcla As New LsValiciones.Mensajes

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        Try

            Consulta_sql = String.Empty

            SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

            myTrans = Cn2.BeginTransaction()

            With Zw_Pdp_CPT_MzEnc

                .Nro_MZC = Fx_NvoNro_OFMezcla()

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_CPT_MzEnc (Empresa,Nro_MZC,Idpote_Otm,Idpotl_Otm,Numot_Otm,Fiot_Otm,Codigo_Otm," &
                               "Descripcion_Otm,CantFabricar,FechaCreacion,Referencia,CodFuncionario,Estado)" & vbCrLf &
                               "Values ('" & .Empresa & "','" & .Nro_MZC & "'," & .Idpote_Otm & "," & .Idpotl_Otm & ",'" & .Numot_Otm &
                               "','" & Format(.Fiot_Otm, "yyyyMMdd") & "','" & .Codigo_Otm & "','" & .Descripcion_Otm &
                               "'," & De_Num_a_Tx_01(.CantFabricar, False, 5) & ",Getdate(),'" & .Referencia & "','" & .CodFuncionario & "','" & .Estado & "')"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Comando = New System.Data.SqlClient.SqlCommand("SELECT @@IDENTITY AS 'Identity'", Cn2)
                Comando.Transaction = myTrans
                Dim dfd1 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
                While dfd1.Read()
                    .Id = dfd1("Identity")
                End While
                dfd1.Close()

                For Each _Fila As Zw_Pdp_CPT_MzDet In Ls_Zw_Pdp_CPT_MzDet

                    With _Fila

                        .Id_Enc = Zw_Pdp_CPT_MzEnc.Id

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_CPT_MzDet (Id_Enc,Empresa,SucursalDef,BodegaDef,FechaCreacion," &
                                       "Idpote_Otm,Idpotl_Otm,CodFuncionario,Codigo,Descripcion,Codnomen,Descriptor,Cantnomen,Udad,CantFabricar,CantFabricada) Values " &
                                       "(" & .Id_Enc & ",'" & .Empresa & "','" & .SucursalDef & "','" & .BodegaDef &
                                       "','" & .FechaCreacion & "'," & .Idpote_Otm & "," & .Idpotl_Otm &
                                       ",'" & .CodFuncionario & "','" & .Codigo & "','" & .Descripcion &
                                       "','" & .Codnomen & "','" & .Descriptor & "'," & De_Num_a_Tx_01(.Cantnomen, False, 5) &
                                       ",'" & .Udad & "'," & De_Num_a_Tx_01(.CantFabricar, False, 5) & "," & De_Num_a_Tx_01(.CantFabricada, False, 5) & ")"

                        Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                    End With

                Next

                myTrans.Commit()
                SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

                _Mensaje_Mezcla.EsCorrecto = True
                _Mensaje_Mezcla.Id = .Id
                _Mensaje_Mezcla.Detalle = "Fabricar Mezcla"
                _Mensaje_Mezcla.Mensaje = "Se crea una nueva Orden de fabricación de mezcla Nro: " & .Nro_MZC

                'Throw New System.Exception(_Sql.Pro_Error)


            End With

        Catch ex As Exception

            _Mensaje_Mezcla.Mensaje = ex.Message
            _Mensaje_Mezcla.Resultado = Consulta_sql
            myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Mezcla

    End Function

    Function Fx_Ingresar_Fabricaciones(_Zw_Pdp_CPT_MzDetIngFab As Zw_Pdp_CPT_MzDetIngFab) As LsValiciones.Mensajes

        Dim _Mensaje_Mezcla As New LsValiciones.Mensajes

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        Try

            Consulta_sql = String.Empty

            SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

            myTrans = Cn2.BeginTransaction()

            With _Zw_Pdp_CPT_MzDetIngFab

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_CPT_MzDetIngFab (Id_Enc,Id_Det,Codigo,Descripcion," &
                               "Udad,CantIngresada,CantFabricada,CodFuncionario,FechaFabricacion) Values " &
                               "(" & .Id_Enc & "," & .Id_Det & ",'" & .Codigo & "','" & .Descripcion &
                               "','" & .Udad & "'," & De_Num_a_Tx_01(.CantIngresada, False, 5) &
                               "," & De_Num_a_Tx_01(.CantFabricada, False, 5) &
                               ",'" & .CodFuncionario & "',Getdate())"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Dim _CantFabricada As Double

                Consulta_sql = "Select SUM(CantFabricada) As CantFabricada" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_Pdp_CPT_MzDetIngFab Where Id_Det = " & .Id_Det

                Comando = New System.Data.SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Dim dfd1 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
                While dfd1.Read()
                    _CantFabricada = dfd1("CantFabricada")
                End While
                dfd1.Close()

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_CPT_MzDet Set CantFabricada = " & De_Num_a_Tx_01(_CantFabricada, False, 5) & vbCrLf &
                               "Where Id = " & .Id_Det
                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Mezcla.EsCorrecto = True
            _Mensaje_Mezcla.Id = 0
            _Mensaje_Mezcla.Detalle = "Fabricar Mezcla"
            _Mensaje_Mezcla.Mensaje = "Mezcla ingresada correctamente"

            'Throw New System.Exception(_Sql.Pro_Error)


        Catch ex As Exception

            _Mensaje_Mezcla.Mensaje = ex.Message
            _Mensaje_Mezcla.Resultado = Consulta_sql
            If IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Mezcla

    End Function

    Function Fx_Editar_Fabricaciones(_Zw_Pdp_CPT_MzDetIngFab As Zw_Pdp_CPT_MzDetIngFab) As LsValiciones.Mensajes

        Dim _Mensaje_Mezcla As New LsValiciones.Mensajes

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        Try

            Consulta_sql = String.Empty

            SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

            myTrans = Cn2.BeginTransaction()

            With _Zw_Pdp_CPT_MzDetIngFab

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_CPT_MzDetIngFab Set " & vbCrLf &
                               "CantIngresada = " & De_Num_a_Tx_01(.CantIngresada, False, 5) &
                               ",CantFabricada = " & De_Num_a_Tx_01(.CantFabricada, False, 5) & vbCrLf &
                               ",CodFuncionario = '" & .CodFuncionario & "'" & vbCrLf &
                               "Where Id = " & .Id

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Dim _CantFabricada As Double

                Consulta_sql = "Select SUM(CantFabricada) As CantFabricada" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_Pdp_CPT_MzDetIngFab Where Id_Det = " & .Id_Det

                Comando = New System.Data.SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Dim dfd1 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
                While dfd1.Read()
                    _CantFabricada = dfd1("CantFabricada")
                End While
                dfd1.Close()

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_CPT_MzDet Set CantFabricada = " & De_Num_a_Tx_01(_CantFabricada, False, 5) & vbCrLf &
                               "Where Id = " & .Id_Det
                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Mezcla.EsCorrecto = True
            _Mensaje_Mezcla.Id = 0
            _Mensaje_Mezcla.Detalle = "Editar Mezcla"
            _Mensaje_Mezcla.Mensaje = "Mezcla actualizada correctamente"

            'Throw New System.Exception(_Sql.Pro_Error)


        Catch ex As Exception

            _Mensaje_Mezcla.Mensaje = ex.Message
            _Mensaje_Mezcla.Resultado = Consulta_sql
            If IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Mezcla

    End Function

    Function Fx_Eliminar_Fabricaciones(_Zw_Pdp_CPT_MzDetIngFab As Zw_Pdp_CPT_MzDetIngFab) As LsValiciones.Mensajes

        Dim _Mensaje_Mezcla As New LsValiciones.Mensajes

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        Try

            Consulta_sql = String.Empty

            SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

            myTrans = Cn2.BeginTransaction()

            With _Zw_Pdp_CPT_MzDetIngFab

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Pdp_CPT_MzDetIngFab" & vbCrLf &
                               "Where Id = " & .Id

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Dim _CantFabricada As Double

                Consulta_sql = "Select SUM(CantFabricada) As CantFabricada" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_Pdp_CPT_MzDetIngFab Where Id_Det = " & .Id_Det

                Comando = New System.Data.SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Dim dfd1 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
                While dfd1.Read()
                    _CantFabricada = dfd1("CantFabricada")
                End While
                dfd1.Close()

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_CPT_MzDet Set CantFabricada = " & De_Num_a_Tx_01(_CantFabricada, False, 5) & vbCrLf &
                               "Where Id = " & .Id_Det
                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Mezcla.EsCorrecto = True
            _Mensaje_Mezcla.Id = 0
            _Mensaje_Mezcla.Detalle = "Eliminar Mezcla"
            _Mensaje_Mezcla.Mensaje = "Mezcla eliminada correctamente"

            'Throw New System.Exception(_Sql.Pro_Error)


        Catch ex As Exception

            _Mensaje_Mezcla.Mensaje = ex.Message
            _Mensaje_Mezcla.Resultado = Consulta_sql
            If IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Mezcla

    End Function

    Function Fx_NvoNro_OFMezcla() As String

        Dim _Nro_CPT As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _TblPaso = _Sql.Fx_Get_Tablas("Select Max(Nro_MZC) As Numero From " & _Global_BaseBk & "Zw_Pdp_CPT_MzEnc")

        Dim _Ult_Nro_OT As String = NuloPorNro(_TblPaso.Rows(0).Item("Numero"), "")

        If String.IsNullOrEmpty(Trim(_Ult_Nro_OT)) Then
            _Ult_Nro_OT = "OFM0000000"
        End If

        _Nro_CPT = Fx_Proximo_NroDocumento(_Ult_Nro_OT, 10)

        Return _Nro_CPT

    End Function

End Class

