'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Usuarios_Bk_Ficha
    Private _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Private Consulta_sql As String

    Private _Grabar As Boolean
    Private _Eliminar As Boolean

    Public Property Pro_Accion As Accion
    Public Property Pro_Grabar As Boolean
    Public Property Pro_Elimiar As Boolean

    Public Enum Accion
        Grabar
        Editar
        Eliminar
    End Enum

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Trim(Txt_Codigo.Text)) Then
            MessageBoxEx.Show(Me, "Código no puede estar vacio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Trim(Txt_Nombre.Text)) Then
            MessageBoxEx.Show(Me, "Nombre no puede estar vacio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Trim(Txt_Email.Text)) Then
            MessageBoxEx.Show(Me, "Email no puede estar vacio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Pro_Accion = Accion.Grabar Then
            _Grabar = Fx_Grabar(Txt_Codigo.Text, Txt_Nombre.Text, Txt_Email.Text, Accion.Grabar)
        ElseIf Pro_Accion = Accion.Editar Then
            If Fx_Tiene_Permiso(Me, "User0003") Then
                _Grabar = Fx_Grabar(Txt_Codigo.Text, Txt_Nombre.Text, Txt_Email.Text, Accion.Editar)
            End If
        End If

        If _Grabar Then
            Me.Close()
        End If

    End Sub

    Private Sub Frm_Usuarios_Ficha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Pro_Accion = Accion.Editar Then
            Txt_Codigo.Enabled = False
            Btn_Eliminar.Visible = True
        ElseIf Pro_Accion = Accion.Grabar Then
            Btn_Eliminar.Visible = False
        End If

    End Sub


    Public Function Fx_Grabar(ByVal _CodFuncionario As String,
                              ByVal _NomFuncionario As String,
                              ByVal _Email As String, ByVal _Accion_fx As Accion)

        If _Accion_fx = Accion.Grabar Then

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Usuarios (CodFuncionario,NomFuncionario,Email,Es_Vendedor) Values " &
                           "('" & _CodFuncionario & "','" & _NomFuncionario & "','" & _Email & "'," & CInt(Chk_EsVendedor.Checked) * -1 & ")"

        ElseIf _Accion_fx = Accion.Editar Then

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Usuarios " &
                           "Set NomFuncionario = '" & _NomFuncionario &
                           "',Email = '" & _Email & "', Es_Vendedor = " & CInt(Chk_EsVendedor.Checked) * -1 & vbCrLf &
                           "Where CodFuncionario = '" & _CodFuncionario & "'"

        ElseIf _Accion_fx = Accion.Eliminar Then
            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Usuarios Where CodFuncionario = '" & _CodFuncionario & "'"
        End If


        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Pro_Accion = _Accion_fx
            Return True
        End If


    End Function

    Private Sub Btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar.Click
        If Fx_Tiene_Permiso(Me, "User0004") Then
            If Fx_Grabar(Txt_Codigo.Text, "", "", Accion.Eliminar) Then
                _Grabar = True
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Frm_Usuarios_Bk_Ficha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class