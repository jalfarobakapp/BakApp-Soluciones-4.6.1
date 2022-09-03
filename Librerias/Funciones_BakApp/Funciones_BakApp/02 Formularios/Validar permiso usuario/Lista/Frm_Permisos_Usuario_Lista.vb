Imports DevComponents.DotNetBar
Imports System.Windows.Forms
Imports System.Drawing


Public Class Frm_Permisos_Usuario_Lista

    Private Sub Frm_Permisos_Usuario_Lista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, True, True, False)

        'Consulta_sql = "DELETE " & _Global_BaseBk & "ZW_Permisos where CodPermiso not IN " & _
        '               "(SELECT RTRIM(LTRIM(Empresa)) + RTRIM(LTRIM(Sucursal)) + RTRIM(LTRIM(Bodega)) + 'Inv'" & vbCrLf & _
        '               "FROM " & _Global_BaseBk & "ZW_TmpInvBodegasInventario)" & vbCrLf & _
        '               "AND CodPermiso like '%Inv'"
        'Ej_consulta_IDU(Consulta_sql, cn1)

        Sb_Actualizar_Grilla()

        AddHandler Chk_Solo_Activos.CheckedChanged, AddressOf Chk_Solo_Activos_CheckedChanged

        Me.ActiveControl = Txtdescripcion

    End Sub

    Function Sb_Actualizar_Grilla()

        Dim cadena As String _
                             = CADENA_A_BUSCAR(RTrim$(Txtdescripcion.Text), "KOFU+NOKOFU" & " LIKE '%")

        Dim _Filtro_Inactivos = String.Empty

        If Chk_Solo_Activos.Checked Then
            _Filtro_Inactivos = "And INACTIVO = 0"
        End If

        Consulta_sql = "SELECT * FROM TABFU" & vbCrLf & _
                       "WHERE KOFU+NOKOFU LIKE '%" & cadena & "%'" & vbCrLf & _Filtro_Inactivos

        With Grilla

            .DataSource = get_Tablas(Consulta_sql, cn1)

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("KOFU").Width = 60
            .Columns("KOFU").HeaderText = "Código"
            .Columns("KOFU").Visible = True

            .Columns("NOKOFU").Width = 340
            .Columns("NOKOFU").HeaderText = "Nombre usuario"
            .Columns("NOKOFU").Visible = True

            For Each _Fila As DataGridViewRow In .Rows

                If _Fila.Cells("INACTIVO").Value Then
                    _Fila.DefaultCellStyle.BackColor = Color.Yellow
                End If

            Next


        End With

    End Function

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        Sb_Revisar_Usuario()
    End Sub

    Sub Sb_Revisar_Usuario()
        Try
            If Grilla.SelectedRows.Count Then

                Dim _CodUsuario As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("KOFU").Value
                Dim _Nombre_Usuario As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("NOKOFU").Value

                Dim Fm As New Frm_Permisos_Usuario_Permisos
                Fm._CodUsuario = _CodUsuario
                Fm.Text = "Usuario: [" & _CodUsuario & "], " & _Nombre_Usuario
                Fm.ShowDialog(Me)
            Else
                Beep()
                ToastNotification.Show(Me, "NO HAY USUARIOS SELECCIONADOS", My.Resources.delete_button_error, _
                                  1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    Private Sub Btn_Ver_Permisos_de_usuarios_activo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Permisos_de_usuarios_activo.Click
        Sb_Revisar_Usuario()
    End Sub

    Private Sub Frm_Permisos_Usuario_Lista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Txtdescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtdescripcion.TextChanged
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub Chk_Solo_Activos_CheckedChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs)
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Grilla_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Grilla.Enter
        Btn_Ver_Permisos_de_usuarios_activo.Enabled = True
    End Sub

    Private Sub Txtdescripcion_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtdescripcion.Enter
        Btn_Ver_Permisos_de_usuarios_activo.Enabled = False
    End Sub
End Class