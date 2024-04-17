
Public Class Cl_Puntos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Zw_PtsVta_Configuracion As New Zw_PtsVta_Configuracion

    Public Sub New()

    End Sub

    Function Fx_Llenar_Zw_PtsVta_Configuracion(_Empresa As String) As Zw_PtsVta_Configuracion

        Dim _Zw_PtsVta_Configuracion As New Zw_PtsVta_Configuracion

        If Not _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_PtsVta_Configuracion") Then
            Return Nothing
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_PtsVta_Configuracion Where Empresa = '" & _Empresa & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_PtsVta_Configuracion (Empresa) Values ('" & _Empresa & "')"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_PtsVta_Configuracion Where Empresa = '" & _Empresa & "'"
            _Row = _Sql.Fx_Get_DataRow(Consulta_sql)

        End If

        With _Zw_PtsVta_Configuracion

            .Id = _Row.Item("Id")
            .Empresa = _Row.Item("Empresa")
            .GCadaPesos = _Row.Item("GCadaPesos")
            .GEquivPuntos = _Row.Item("GEquivPuntos")
            .RCadaPuntos = _Row.Item("RCadaPuntos")
            .REquivPesos = _Row.Item("REquivPesos")
            .MinPtosCanjear = _Row.Item("MinPtosCanjear")
            .ValMinPedCajear = _Row.Item("ValMinPedCajear")
            .Concepto = _Row.Item("Concepto")

        End With

        Return _Zw_PtsVta_Configuracion

    End Function

    Function Fx_Grabar_Configuracion() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            With Zw_PtsVta_Configuracion

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_PtsVta_Configuracion Set " & vbCrLf &
                               "GCadaPesos = " & .GCadaPesos & vbCrLf &
                               ",GEquivPuntos = " & .GEquivPuntos & vbCrLf &
                               ",RCadaPuntos = " & .RCadaPuntos & vbCrLf &
                               ",REquivPesos = " & .REquivPesos & vbCrLf &
                               ",MinPtosCanjear = " & .MinPtosCanjear & vbCrLf &
                               ",ValMinPedCajear = " & .ValMinPedCajear & vbCrLf &
                               "Where Empresa = '" & .Empresa & "'"
                If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                    Throw New System.Exception(_Sql.Pro_Error)
                End If

                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "Grabación OK."
                _Mensaje.Mensaje = "Datos actualizados correctamente"

            End With

        Catch ex As Exception
            _Mensaje.Detalle = "Problema al grabar"
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function

    Function Fx_Grabar_Registro_Puntos(_Idmaeedo As Integer, _PtsUsados As Double) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        Dim _Row As DataRow

        Try

            If Not _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_PtsVta_Doc") Then
                _Mensaje.Detalle = "Validación"
                Throw New System.Exception("No existe tabla " & _Global_BaseBk & "Zw_PtsVta_Doc")
            End If

            With Zw_PtsVta_Configuracion

                'Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_PtsVta_Doc Where Idmaeedo = " & _Idmaeedo
                '_Row = _Sql.Fx_Get_DataRow(Consulta_sql)

                'If Not IsNothing(_Row) Then
                '    _Mensaje.Detalle = "Validación"
                '    Throw New System.Exception("Ya existen puntos asignado a este documento" & vbCrLf &
                '                               "Documento: " & _Row.Item("Tido") & "-" & _Row.Item("Nudo"))
                'End If

                Consulta_sql = "Select IDMAEEDO,ENDO,SUENDO,TIDO,NUDO,FEEMDO,VABRDO,VAABDO,NUDONODEFI From MAEEDO Where IDMAEEDO = " & _Idmaeedo
                _Row = _Sql.Fx_Get_DataRow(Consulta_sql)

                If IsNothing(_Row) Then
                    _Mensaje.Detalle = "Validación"
                    Throw New System.Exception("No se econtro el registro en la tabla MAEEDO con IDMAEEDO = " & _Idmaeedo)
                End If

                If _Row.Item("TIDO") <> "FCV" AndAlso _Row.Item("TIDO") <> "BLV" AndAlso _Row.Item("TIDO") <> "NCV" Then
                    _Mensaje.Detalle = "Validación"
                    Throw New System.Exception("Solo se permiten documentos: FCV, BLV y NCV")
                End If

                Dim _JuntaPuntos As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Entidades", "JuntaPuntos",
                                                                "CodEntidad = '" & _Row.Item("ENDO") & "' And CodSucEntidad = '" & _Row.Item("SUENDO") & "'")


                If Not _JuntaPuntos Then
                    _Mensaje.Detalle = "Validación"
                    Throw New System.Exception("La entidad no junta puntos")
                End If

                Dim _PuntosGanados As Double

                _PuntosGanados = (_Row.Item("VABRDO") / .GCadaPesos) * .GEquivPuntos

                If _Row.Item("TIDO") = "NCV" Then
                    _PuntosGanados = _PuntosGanados * -1
                End If

                'If _Row.Item("NUDONODEFI") Then
                '    _Mensaje.Detalle = "Validación"
                '    Throw New System.Exception("El documento aun es un vale transitorio")
                'End If

                Dim _Zw_PtsVta_Doc As New Zw_PtsVta_Doc

                With _Zw_PtsVta_Doc

                    .Idmaeedo = _Row.Item("IDMAEEDO")
                    .Tido = _Row.Item("TIDO")
                    .Nudo = _Row.Item("NUDO")
                    .CodEntidad = _Row.Item("ENDO")
                    .CodSucEntidad = _Row.Item("SUENDO")
                    .Nudonodefi = _Row.Item("NUDONODEFI")
                    .Feemdo = _Row.Item("FEEMDO")
                    .Vabrdo = _Row.Item("VABRDO")
                    .PtsGanados = Math.Round(_PuntosGanados)
                    .PtsUsados = _PtsUsados

                    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_PtsVta_Doc Where Idmaeedo = " & _Idmaeedo
                    _Row = _Sql.Fx_Get_DataRow(Consulta_sql)

                    If Not IsNothing(_Row) Then
                        .Id = _Row.Item("Id")
                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_PtsVta_Doc Set Nudonodefi = " & Convert.ToInt32(.Nudonodefi) & ",Nudo = '" & .Nudo & "' Where Idmaeedo = " & _Idmaeedo
                        If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                            Throw New System.Exception(_Sql.Pro_Error)
                        End If
                    Else
                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_PtsVta_Doc (Idmaeedo,Tido,Nudo,CodEntidad,CodSucEntidad,Nudonodefi," &
                                       "Feemdo,Vabrdo,PtsGanados,PtsUsados) Values " &
                                       "(" & .Idmaeedo &
                                       ",'" & .Tido &
                                       "','" & .Nudo &
                                       "','" & .CodEntidad &
                                       "','" & .CodSucEntidad &
                                       "'," & Convert.ToInt32(.Nudonodefi) &
                                       ",'" & Format(.Feemdo, "yyyyMMdd") &
                                       "'," & De_Num_a_Tx_01(.Vabrdo, False, 5) &
                                       "," & De_Num_a_Tx_01(.PtsGanados, False, 5) &
                                       "," & De_Num_a_Tx_01(.PtsUsados, False, 5) & ")"
                        If Not _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, .Id, False) Then
                            Throw New System.Exception(_Sql.Pro_Error)
                        End If
                    End If

                    _Mensaje.Id = .Id
                    _Mensaje.EsCorrecto = True
                    _Mensaje.Detalle = "Grabación OK."
                    _Mensaje.Mensaje = "El cliente acaba de sumar " & .PtsGanados & " puntos."

                End With

            End With

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function

    Function Fx_Confirmar_Puntos(_Idmaeedo As Integer) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        Dim _Row As DataRow

        Try

            If Not _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_PtsVta_Doc") Then
                _Mensaje.Detalle = "Validación"
                Throw New System.Exception("No existe tabla " & _Global_BaseBk & "Zw_PtsVta_Doc")
            End If

            Consulta_sql = "Select IDMAEEDO,ENDO,SUENDO,TIDO,NUDO,FEEMDO,VABRDO,VAABDO,NUDONODEFI From MAEEDO Where IDMAEEDO = " & _Idmaeedo
            _Row = _Sql.Fx_Get_DataRow(Consulta_sql)

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_PtsVta_Doc Set Nudonodefi = 1 Where IDMAEEDO = " & _Idmaeedo

            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                _Mensaje.Detalle = "Validación"
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Gración OK."
            _Mensaje.Mensaje = "Datos actualizados correctamente"

        Catch ex As Exception
            _Mensaje.Detalle = "Problema al grabar"
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function

End Class
