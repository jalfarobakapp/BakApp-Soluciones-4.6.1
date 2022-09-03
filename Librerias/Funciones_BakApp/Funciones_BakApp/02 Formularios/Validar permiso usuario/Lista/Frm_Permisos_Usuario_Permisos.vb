Imports DevComponents.DotNetBar
Imports System.Drawing
Imports System.Windows.Forms

Public Class Frm_Permisos_Usuario_Permisos

    Public _CodUsuario As String

    Private Sub Frm_Permisos_Usuario_Permisos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Formato_Generico_Grilla(Grilla_Grupos, 18, New Font("Tahoma", 8), Color.AliceBlue, True)
        Formato_Generico_Grilla(Grilla_Permisos, 18, New Font("Tahoma", 8), Color.AliceBlue, True)

        Grilla_Grupos.MultiSelect = False
        Grilla_Permisos.MultiSelect = False

        Sb_Actualizar_Grilla_Grupos()

    End Sub

    Sub Sb_Actualizar_Grilla_Grupos()

        Consulta_sql = "SELECT distinct CodFamilia,NombreFamiliaPermiso FROM " & _Global_BaseBk & "ZW_Permisos"

        With Grilla_Grupos

            .DataSource = get_Tablas(Consulta_sql, cn1)

            OcultarEncabezadoGrilla(Grilla_Grupos, True)

            .Columns("NombreFamiliaPermiso").Width = 130
            .Columns("NombreFamiliaPermiso").HeaderText = "Familia"
            .Columns("NombreFamiliaPermiso").Visible = True


        End With
    End Sub

    Sub Sb_Actualizar_Grilla_Permisos(ByVal _CodFamilia As String)

        Consulta_sql = "SELECT  CAST( 1 AS bit) AS Chk,CodPermiso," & _
                       "ISnull((Select top 1 DescripcionPermiso " & _
                       "From " & _Global_BaseBk & "ZW_Permisos Z2 Where Z1.CodPermiso = Z2.CodPermiso),'') as DescripcionPermiso" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "ZW_PermisosVsUsuarios Z1" & vbCrLf & _
                       "WHERE CodUsuario = '" & _CodUsuario & "'" & vbCrLf & _
                       "And CodPermiso in (Select CodPermiso From " & _Global_BaseBk & "ZW_Permisos Where CodFamilia = '" & _CodFamilia & "')" & vbCrLf & _
                       "Union" & vbCrLf & _
                       "Select CAST( 0 AS bit) as Chk,CodPermiso, DescripcionPermiso" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "ZW_Permisos" & vbCrLf & _
                       "Where CodPermiso not in (Select CodPermiso " & _
                       "From " & _Global_BaseBk & "ZW_PermisosVsUsuarios Where CodUsuario = '" & _CodUsuario & "')" & vbCrLf & _
                       "and CodFamilia = '" & _CodFamilia & "'" & vbCrLf & _
                       "order by CodPermiso"

        With Grilla_Permisos

            .DataSource = get_Tablas(Consulta_sql, cn1)

            OcultarEncabezadoGrilla(Grilla_Permisos, True)

            .Columns("Chk").Width = 60
            .Columns("Chk").HeaderText = "Selec"
            .Columns("Chk").Visible = True

            .Columns("CodPermiso").Width = 100
            .Columns("CodPermiso").HeaderText = "Código"
            .Columns("CodPermiso").Visible = True

            .Columns("DescripcionPermiso").Width = 350
            .Columns("DescripcionPermiso").HeaderText = "Descripción permiso"
            .Columns("DescripcionPermiso").Visible = True


        End With
    End Sub

    Private Sub Grilla_Grupos_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Grupos.CellEnter

        Dim _CodFamilia As String = Grilla_Grupos.Rows(Grilla_Grupos.CurrentRow.Index).Cells("CodFamilia").Value
        Dim _NombreFamiliaPermiso As String = Grilla_Grupos.Rows(Grilla_Grupos.CurrentRow.Index).Cells("NombreFamiliaPermiso").Value

        Grupo_Permisos.Text = "Permisos: " & UCase(_NombreFamiliaPermiso)
        Sb_Actualizar_Grilla_Permisos(_CodFamilia)

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub Btn_Grabar_Permisos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar_Permisos.Click

        Dim _CodFamilia As String = Grilla_Grupos.Rows(Grilla_Grupos.CurrentRow.Index).Cells("CodFamilia").Value

        Consulta_sql = "Delete " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & vbCrLf & _
                       "WHERE CodUsuario = '" & _CodUsuario & "'" & vbCrLf & _
                       "And CodPermiso in (Select CodPermiso From " & _Global_BaseBk & "ZW_Permisos Where CodFamilia = '" & _CodFamilia & "')" & vbCrLf


        For Each _Fila As DataGridViewRow In Grilla_Permisos.Rows

            Dim _Chk As Boolean = _Fila.Cells("Chk").Value

            If _Chk Then

                Dim _CodPermiso As String = Trim(_Fila.Cells("CodPermiso").Value)
                Dim _Clave_Admin As String = trae_dato(tb, cn1, "ClaveAdministrador", _Global_BaseBk & "ZW_PermisosADM")

                Dim _Llave As String = UCase(_CodPermiso & "@" & _CodUsuario)
                _Llave = Encripta_md5(_Llave)

                Consulta_sql += "INSERT INTO " & _Global_BaseBk & "ZW_PermisosVsUsuarios (CodUsuario, CodPermiso, Llave) VALUES " & _
                                     "('" & _CodUsuario & "','" & _CodPermiso & "','" & _Llave & "')" & vbCrLf
            End If

        Next

        If Ej_consulta_IDU(Consulta_sql, cn1) Then
            Beep()
            ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.save, _
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
        End If

       


    End Sub

    Private Sub Frm_Permisos_Usuario_Permisos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub


    Private Function ChequearTodo(ByVal Grilla As DataGridView, _
                                  ByVal Chk As Boolean)

        For Each _Fila As DataGridViewRow In Grilla.Rows
            _Fila.Cells("Chk").Value = Chk
        Next

    End Function

    Private Sub ChkSeleccionar_CheckedChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles ChkSeleccionar.CheckedChanged
        Dim chk As Boolean = ChkSeleccionar.Checked
        ChequearTodo(Grilla_Permisos, chk)
    End Sub

    
    Private Sub Grilla_Permisos_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grilla_Permisos.MouseUp
        Grilla_Permisos.EndEdit()
    End Sub
End Class