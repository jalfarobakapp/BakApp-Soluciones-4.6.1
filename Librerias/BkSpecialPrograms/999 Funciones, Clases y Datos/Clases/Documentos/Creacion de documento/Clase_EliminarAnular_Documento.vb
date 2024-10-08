﻿Imports DevComponents.DotNetBar

Public Class Clase_EliminarAnular_Documento

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Enum _Accion_EA2
        Anular
        Eliminar
        Modificar
    End Enum

    Function Fx_EliminarAnular_Doc(ByVal _Formulario As Form,
                                   ByVal _Idmaeedo As Integer,
                                   ByVal _Cod_Func_Eliminador As String,
                                   ByVal _Accion As _Accion_EA2,
                                   ByVal _Mostrar_Mensaje As Boolean) As Boolean

        Dim _FechaEliminacion = FechaDelServidor()


        If Not Revisar_Si_Se_Puede_Eliminar_El_Documento(_Formulario, _Idmaeedo, _Accion, _Mostrar_Mensaje) Then
            Return False
        End If

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Try

            Dim Fecha_Elimi As String = Format(_FechaEliminacion, "yyyyMMdd")

            Consulta_sql = "Select EMPRESA,SUDO,TIDO,NUDO,ENDO,SUENDO,FEEMDO,KOFUDO,VANEDO,VABRDO" & vbCrLf &
                           "FROM MAEEDO" & vbCrLf &
                           "WHERE IDMAEEDO = " & _Idmaeedo
            Dim Tabla_Doc As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

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



                If _Accion = _Accion_EA2.Anular Then

                    Consulta_sql = "INSERT INTO ELIDDO SELECT * FROM MAEDDO WHERE MAEDDO.IDMAEEDO = " & _Idmaeedo & vbCrLf &
                                   "INSERT INTO ELIEDO SELECT * FROM MAEEDO WHERE MAEEDO.IDMAEEDO = " & _Idmaeedo & vbCrLf &
                                   "Update MAEEDO Set ESDO = 'N',LIBRO = '',KOFUAUDO = '" & _Cod_Func_Eliminador & "' Where IDMAEEDO =" & _Idmaeedo & vbCrLf & vbCrLf

                ElseIf _Accion = _Accion_EA2.Eliminar Then

                    Consulta_sql = "INSERT INTO MAEELIMI (EMPRESA,TIDO,NUDO,ENDO,SUENDO,FEEMDO,FEELIDO,KOFUDO,VANEDO,VABRDO)" & vbCrLf &
                                    "Select EMPRESA,TIDO,NUDO,ENDO,SUENDO,FEEMDO,'" & _Fecha_Eliminacion & "',KOFUDO,VANEDO,VABRDO" & vbCrLf &
                                    "Where IDMAEEDO =" & _Idmaeedo & vbCrLf &
                                    "INSERT INTO ELIDDO SELECT * FROM MAEDDO WHERE MAEDDO.IDMAEEDO = " & _Idmaeedo & vbCrLf &
                                    "INSERT INTO ELIEDO SELECT * FROM MAEEDO WHERE MAEEDO.IDMAEEDO = " & _Idmaeedo & vbCrLf &
                                    "DELETE MAEEDO WHERE IDMAEEDO =" & _Idmaeedo & vbCrLf

                ElseIf _Accion = _Accion_EA2.Modificar Then

                    Consulta_sql = "DELETE MAEEDO WHERE IDMAEEDO =" & _Idmaeedo & vbCrLf

                End If

                Consulta_sql +=
                               "DELETE FROM MAEPOSLI" & vbCrLf &
                               "WHERE MAEPOSLI.IDMAEDDO IN (SELECT IDMAEDDO FROM MAEDDO WHERE IDMAEEDO=" & _Idmaeedo & ")" & vbCrLf &
                               "DELETE FROM MEVENTO WHERE ARCHIRVE='MAEEDO' AND IDRVE=" & _Idmaeedo & vbCrLf &
                               "DELETE FROM MAEIMLI WHERE IDMAEEDO =" & _Idmaeedo & vbCrLf &
                               "DELETE FROM MAEDTLI WHERE IDMAEEDO=" & _Idmaeedo & vbCrLf &
                               "DELETE FROM MEVENTO " &
                               "WHERE ARCHIRVE='MAEDDO' AND IDRVE IN (SELECT IDMAEDDO FROM MAEDDO WHERE IDMAEEDO=" & _Idmaeedo & ")" & vbCrLf &
                               "DELETE FROM MAEDDO WHERE IDMAEEDO=" & _Idmaeedo & vbCrLf &
                               "DELETE FROM MAEVEN WHERE IDMAEEDO=" & _Idmaeedo & vbCrLf &
                               "DELETE FROM MAEEDOOB WHERE IDMAEEDO=" & _Idmaeedo & vbCrLf &
                               "DELETE FROM TABPERMISO WHERE IDRST=" & _Idmaeedo & " AND ARCHIRST='MAEEDO'" & vbCrLf &
                               "SELECT TOP 1 * FROM MAEDCR WITH (NOLOCK) WHERE IDMAEEDO=" & _Idmaeedo & vbCrLf &
                               "DELETE FROM MAEDCR WHERE IDMAEEDO=" & _Idmaeedo & vbCrLf


                Consulta_sql = Replace(Consulta_sql, "#Idmaeedo#", _Idmaeedo)

                'SQL_ServerClass.AbrirConexion_SQLServer(cn2)
                'myTrans = cn2.BeginTransaction()


                'Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                'Comando.Transaction = myTrans
                'Comando.ExecuteNonQuery()
                '
                'myTrans.Commit()

                _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

                Return True


            End With

        Catch ex As Exception

            My.Computer.FileSystem.WriteAllText("Archivo_Salida_Error.Log", ex.Message & vbCrLf & ex.StackTrace, False)
            MessageBoxEx.Show(_Formulario, ex.Message, "Error",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            'myTrans.Rollback()

            MessageBoxEx.Show(_Formulario, "Transaccion desecha", "Problema",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
        Finally

            'SQL_ServerClass.CerrarConexion(cn2)

        End Try

    End Function

    Function Revisar_Si_Se_Puede_Eliminar_El_Documento(ByVal _Formulario As Form,
                                                               ByVal _Idmaeedo As Integer,
                                                               ByVal _Accion As _Accion_EA2,
                                                               Optional ByVal _Mostrar_Mensaje As Boolean = False) As Boolean

        Dim Dst_Paso As New DataSet

        Consulta_sql = My.Resources.Rc_ConsultasSQL.Revisar_sutentatorio
        Consulta_sql = Replace(Consulta_sql, "#Idmaeedo#", _Idmaeedo)

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
                Return False
            End If
        Next
        Return True
    End Function


End Class
