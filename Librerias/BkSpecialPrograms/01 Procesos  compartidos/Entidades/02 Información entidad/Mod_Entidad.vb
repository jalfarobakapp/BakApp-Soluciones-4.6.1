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

End Module
