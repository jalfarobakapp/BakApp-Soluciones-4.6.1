Imports DevComponents.DotNetBar
Imports Bk_Produccion
Imports BkSpecialPrograms

Public Class Produccion_Mesones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Frm_Menu.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_Mesones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mesones.Click

        Dim Fm As New Frm_Mesones
        Fm.ShowDialog(Frm_Menu)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Mesones_Gestion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mesones_Gestion.Click

        Dim Fm As New Frm_Busqueda_OT
        Fm.ShowDialog(Frm_Menu)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Operarios_vs_Mesones_Click(sender As Object, e As EventArgs) Handles Btn_Operarios_vs_Mesones.Click

        Dim _Sql_Filtro_Condicion_Extra = "And INACTIVO = 0"

        Dim _Filtrar As New Clas_Filtros_Random(Frm_Menu)
        Dim _Codigoob As String
        Dim _Nombreob As String

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Pdc_Operarios, _Sql_Filtro_Condicion_Extra,
                               Nothing, False, True) Then

            Dim _Tbl_Operacion As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Operacion.Rows(0)

            _Codigoob = _Row.Item("Codigo").ToString.Trim
            _Nombreob = _Row.Item("Descripcion").ToString.Trim

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Pdc_MesonVsOperario", "Codigoob = '" & _Codigoob & "'")

            If CBool(_Reg) Then

                Dim _Puede_Acceder_A_Los_Mesones = True
                Dim _Clas_Alerta_Trab_Sin_Cerrar As New Clas_Alerta_Trab_Sin_Cerrar

                'If False Then ' Se desactiva para entregar versión a Johnny

                Dim _Trabajos_Pendientes = _Clas_Alerta_Trab_Sin_Cerrar.Fx_Tiene_Trabajos_Abiertos(_Codigoob)

                If _Trabajos_Pendientes > 0 Then

                    MessageBoxEx.Show(Me, "Usted tiene trabajos pendientes sin cerrar" & vbCrLf &
                                      "Para poder seguir con la gestión primero debe cerrar los trabajos pendiente", "ALERTA",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    Dim Fm1 As New Frm_TrabMaq_Sin_Cerrar(_Codigoob)
                    Fm1.Text = "Operario: " & _Codigoob.Trim & "-" & _Nombreob
                    Fm1.ShowDialog(Me)
                    Fm1.Dispose()

                    _Puede_Acceder_A_Los_Mesones = Not CBool(_Clas_Alerta_Trab_Sin_Cerrar.Fx_Tiene_Trabajos_Abiertos(_Codigoob))

                End If

                If Not _Puede_Acceder_A_Los_Mesones Then
                    MessageBoxEx.Show(Me, "No puede seguir con la gestión, primero debe cerrar los trabjos pendientes", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                'End If

                Dim _Codmeson As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Pdc_MesonVsOperario", "Codmeson", "Codigoob = '" & _Codigoob & "' And Por_Defecto = 1")

                Dim Fm As New Frm_Meson_Operario(_Codigoob, True)
                If Not String.IsNullOrEmpty(Trim(_Codmeson)) Then
                    Fm.Cmb_Mesones.SelectedValue = _Codmeson
                End If
                Fm.ShowDialog(Me)
                Fm.Dispose()

            Else

                MessageBoxEx.Show(Me, "No existen mesones asiganados a este usuario" & vbCrLf &
                                  "Código: " & Trim(_Codigoob) & " - " & _Nombreob, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

        End If

    End Sub

    Private Sub Btn_Asignacion_OT_Al_Meson_Click(sender As Object, e As EventArgs) Handles Btn_Asignacion_OT_Al_Meson.Click

        Dim Fm As New Frm_Meson_Asignar_Productos(Frm_Meson_Asignar_Productos.Enum_Tipo_OT.Fabricacion)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Produccion_Mesones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Where Idpotpr Not IN (Select IDPOTPR From POTPR)" & vbCrLf &
                       "Delete " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Where Idpotpr Not IN (Select IDPOTPR From POTPR)"
        _Sql.Ej_consulta_IDU(Consulta_Sql)

    End Sub

    Private Sub Btn_Nomenclaturas_Click(sender As Object, e As EventArgs) Handles Btn_Nomenclaturas.Click

        Dim Fm As New Frm_Nomenclaturas
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Maestra_De_Operarios_Click(sender As Object, e As EventArgs) Handles Btn_Maestra_De_Operarios.Click

        Dim Fm As New Frm_Maestro_Operarios
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub
End Class
