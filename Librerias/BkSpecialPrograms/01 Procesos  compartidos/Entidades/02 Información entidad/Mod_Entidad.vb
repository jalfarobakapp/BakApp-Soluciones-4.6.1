Imports DevComponents.DotNetBar

Public Module Mod_Entidad

    Public Function Fx_Entidad_Tiene_Deudas_CtaCte(_Formulario As Form,
                                                   _RowEntidad As DataRow,
                                                   _Mostrar_Formulario As Boolean,
                                                   ByRef _Solicitar_Permiso_Remoto As Boolean,
                                                   ByRef _Bloqueada As Boolean) As Boolean

        If (_RowEntidad Is Nothing) Then Return True

        _Bloqueada = _RowEntidad.Item("BLOQUEADO")

        Dim _NOTRAEDEUD As Boolean = _RowEntidad.Item("NOTRAEDEUD")

        If _NOTRAEDEUD Then

            Return True

        Else

            '-- ESTA INSTRUCCION CIERRA LOS VENCIMIENTOS QUE YA ESTAN CANCELADOS COMPLETAMENTE
            Dim Fm As New Frm_Reparar_Maeven(_RowEntidad)
            Fm.Fx_Reparar_Maeven(_Formulario)
            Fm.Dispose()

            If _Bloqueada Then

                If _Solicitar_Permiso_Remoto Then

                    MessageBoxEx.Show(_Formulario, "Entidad bloqueada para realizar Compras y Ventas", "Diríjase a tesorería",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    Dim _Koen = _RowEntidad.Item("KOEN")
                    Dim _Suen = _RowEntidad.Item("SUEN")

                    _Bloqueada = Not Fx_Tiene_Permiso(_Formulario, "Bkp00021",,,,, _Koen, _Suen)

                    If _Bloqueada Then
                        Return False
                    End If

                End If

            End If

            Dim Fm_D As New Frm_InfoEnt_Deudas_Doc_Comerciales(_RowEntidad, 0, 0, 0, 0, True)
            Fm_D.Btn_CambCodPago.Visible = False

            If Fm_D.Pro_Tiene_Deudas Then
                If _Mostrar_Formulario Then
                    Fm_D.ShowDialog(_Formulario)
                Else
                    Return False
                End If
            Else
                Return True
            End If

            Fm_D.Dispose()

        End If

    End Function

    Public Function Fx_Entidad_Revisar_Protestos(_CodEntidad As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_sql As String

        Try

            Consulta_sql = "Select TIDO,NUDO,NUCUDO,MODO,VABRDO,FEEMDO" & vbCrLf &
                           "From CDOCCOE With(Nolock)" & vbCrLf &
                           "Where ENDO = '" & _CodEntidad & "' And TIDO IN ('chv','ltv','pav') And ESPGDO <> 'C' And VABRDO <> 0 "
            Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If Not IsNothing(_Tbl) Then
                If _Tbl.Rows.Count > 0 Then
                    _Mensaje.Tag = _Tbl
                    Throw New System.Exception("Entidad presenta " & _Tbl.Rows.Count & " protestos vigentes.")
                End If
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Entidad no presenta protestos vigentes."
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function

End Module
