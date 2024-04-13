Imports System.Data.SqlClient
Imports BkSpecialPrograms

Public Class Cl_Mezcla

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property MzEnc As New Modelos_Mezcla.MzEnc
    Public Property MzDet As New Modelos_Mezcla.MzDet
    Public Property MzDet_ls As New List(Of Modelos_Mezcla.MzDet)
    Public Property MzDetProd_ls As New List(Of Modelos_Mezcla.MzDetProd)

    Public Sub New()

    End Sub

    Function Fx_Llenar_MzEnc(_Id_Enc As Integer) As LsValiciones.Mensajes

        Dim _Mensaje_Mezcla As New LsValiciones.Mensajes

        Try

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_CPT_MzEnc Where Id = " & _Id_Enc
            Dim _Row_MzEnc As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row_MzEnc) Then
                Throw New System.Exception("No se encontro el registro en la tabla Zw_Pdp_CPT_MzEnc con el Id: " & _Id_Enc)
            End If

            With MzEnc

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
                .Codnomen = _Row_MzEnc.Item("Codnomen")
                .Descriptor = _Row_MzEnc.Item("Descriptor")
                .Cantnomen = _Row_MzEnc.Item("Cantnomen")
                .Udad = _Row_MzEnc.Item("Udad")
                .CantFabricar = _Row_MzEnc.Item("CantFabricar")
                .CantFabricada = _Row_MzEnc.Item("CantFabricada")
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

            With MzEnc

                .Nro_MZC = Fx_NvoNro_OFMezcla()

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_CPT_MzEnc (Empresa,Nro_MZC,Idpote_Otm,Idpotl_Otm,Numot_Otm,Fiot_Otm,Codigo_Otm," &
                               "Descripcion_Otm,FechaCreacion,Referencia,CodFuncionario,Estado,Codnomen,Descriptor,Cantnomen,Udad,CantFabricar)" & vbCrLf &
                               "Values ('" & .Empresa & "','" & .Nro_MZC & "'," & .Idpote_Otm & "," & .Idpotl_Otm & ",'" & .Numot_Otm &
                               "','" & Format(.Fiot_Otm, "yyyyMMdd") & "','" & .Codigo_Otm & "','" & .Descripcion_Otm &
                               "',Getdate(),'" & .Referencia & "','" & .CodFuncionario & "','" & .Estado & "','" & .Codnomen &
                               "','" & .Descriptor & "'," & De_Num_a_Tx_01(.Cantnomen, False, 5) & ",'" & .Udad & "'," & De_Num_a_Tx_01(.CantFabricar, False, 5) & ")"

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

                For Each _Fila As Modelos_Mezcla.MzDet In MzDet_ls

                    With _Fila

                        .Id_Enc = MzEnc.Id

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
                _Mensaje_Mezcla.Detalle = "Se crea una nueva Orden de fabricación de mezcla Nro: " & .Nro_MZC

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

    Function Fx_Agregar_Nueva_Fabricacion_Mezcla() As LsValiciones.Mensajes

        Dim _Mensaje_Mezcla As New LsValiciones.Mensajes

        Try

            With MzEnc

                .Nro_MZC = Fx_NvoNro_OFMezcla()

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_CPT_MzEnc (Empresa,Nro_MZC,Idpote_Otm,Idpotl_Otm,Numot_Otm,Fiot_Otm,Codigo_Otm," &
                               "Descripcion_Otm,FechaCreacion,Referencia,CodFuncionario,Estado,Codnomen,Descriptor,Cantnomen,Udad,CantFabricar)" & vbCrLf &
                               "Values ('" & .Empresa & "','" & .Nro_MZC & "'," & .Idpote_Otm & "," & .Idpotl_Otm & ",'" & .Numot_Otm &
                               "','" & Format(.Fiot_Otm, "yyyyMMdd") & "','" & .Codigo_Otm & "','" & .Descripcion_Otm &
                               "',Getdate(),'" & .Referencia & "','" & .CodFuncionario & "','" & .Estado & "','" & .Codnomen &
                               "','" & .Descriptor & "'," & De_Num_a_Tx_01(.Cantnomen, False, 5) & ",'" & .Udad & "'," & De_Num_a_Tx_01(.CantFabricar, False, 5) & ")"

                If _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, .Id, False) Then
                    _Mensaje_Mezcla.EsCorrecto = True
                    _Mensaje_Mezcla.Id = .Id
                    _Mensaje_Mezcla.Detalle = "Se crea una nueva Orden de fabricación de mecla Nro: " & .Nro_MZC
                Else
                    Throw New System.Exception(_Sql.Pro_Error)
                End If

            End With

            With MzDet_ls

            End With

        Catch ex As Exception
            _Mensaje_Mezcla.Mensaje = ex.Message
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

Namespace Modelos_Mezcla

    ''' <summary>
    ''' Encabezado de la mezcla
    ''' </summary>
    Public Class MzEnc

        Public Property Id As Integer
        Public Property Empresa As String
        Public Property Nro_MZC As String
        Public Property Idpote_Otm As Integer
        Public Property Idpotl_Otm As Integer
        Public Property Numot_Otm As String
        Public Property Fiot_Otm As DateTime
        Public Property Codigo_Otm As String
        Public Property Descripcion_Otm As String
        Public Property FechaCreacion As DateTime
        Public Property Referencia As String
        Public Property CodFuncionario As String
        Public Property FechaCreacionOT As DateTime
        Public Property Idpote As Integer
        Public Property Estado As String
        Public Property Codnomen As String
        Public Property Descriptor As String
        Public Property Cantnomen As Double
        Public Property Udad As String
        Public Property CantFabricar As Double
        Public Property CantFabricada As Double

    End Class

    ''' <summary>
    ''' Detalle de la mezcla
    ''' </summary>
    Public Class MzDet

        Public Property Id As Integer
        Public Property Id_Enc As Integer
        Public Property Empresa As String
        Public Property SucursalDef As String
        Public Property BodegaDef As String
        Public Property FechaCreacion As DateTime
        Public Property Idpote_Otm As Integer
        Public Property Idpotl_Otm As Integer
        Public Property CodFuncionario As String
        Public Property Codigo As String
        Public Property Descripcion As String
        Public Property Codnomen As String
        Public Property Descriptor As String
        Public Property Cantnomen As Double
        Public Property Udad As String
        Public Property CantFabricar As Double
        Public Property CantFabricada As Double

    End Class

    ''' <summary>
    ''' Detalle de los productos de la nomenclatura del producto a fabricar
    ''' </summary>
    Public Class MzDetProd

        Public Property Id As Integer
        Public Property Id_Enc As Integer
        Public Property Id_Det As Integer
        Public Property Nomenclatura As String
        Public Property Codigo As String
        Public Property Descripcion As String
        Public Property Udad As String
        Public Property CantFabricar As Double
        Public Property CantFabricada As Double
        Public Property Tipo As String
        Public Property Calidad As String
        Public Property SumaCant As Boolean

    End Class



End Namespace
