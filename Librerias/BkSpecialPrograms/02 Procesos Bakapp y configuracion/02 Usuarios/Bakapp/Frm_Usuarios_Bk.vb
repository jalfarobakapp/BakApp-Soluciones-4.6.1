Imports DevComponents.DotNetBar

Public Class Frm_Usuarios_Bk

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Private Sub Frm_Usuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()
        Me.ActiveControl = Txtdescripcion

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Cadena As String _
                             = CADENA_A_BUSCAR(RTrim$(Txtdescripcion.Text), "NomFuncionario" & " LIKE '%")

        Dim _Filtro_Inactivos = String.Empty


        Consulta_sql = "SELECT * FROM " & _Global_BaseBk & "Zw_Usuarios" & vbCrLf &
                       "Where NomFuncionario Like '%" & _Cadena & "%'" & vbCrLf &
                       "Order by CodFuncionario"

        With Grilla

            .DataSource = _SQL.Fx_Get_DataTable(Consulta_sql)

            OcultarEncabezadoGrilla(Grilla, False)

            .Columns("CodFuncionario").Visible = True
            .Columns("CodFuncionario").HeaderText = "Cód."
            .Columns("CodFuncionario").Width = 40

            .Columns("NomFuncionario").Visible = True
            .Columns("NomFuncionario").HeaderText = "Participante"
            .Columns("NomFuncionario").Width = 220

            .Columns("Email").Visible = True
            .Columns("Email").HeaderText = "E-mail"
            .Columns("Email").Width = 200

            .Columns("Es_Vendedor").Visible = True
            .Columns("Es_Vendedor").HeaderText = "Vendedor"
            .Columns("Es_Vendedor").Width = 65

        End With

    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _CodFuncionario = _Fila.Cells("CodFuncionario").Value
        Dim _NomFuncionario = _Fila.Cells("NomFuncionario").Value
        Dim _Email = _Fila.Cells("Email").Value
        Dim _Es_Vendedor = _Fila.Cells("Es_Vendedor").Value

        Dim Fm As New Frm_Usuarios_Bk_Ficha
        Fm.Pro_Accion = Frm_Usuarios_Bk_Ficha.Accion.Editar
        Fm.Txt_Codigo.Text = _CodFuncionario
        Fm.Txt_Nombre.Text = _NomFuncionario
        Fm.Txt_Email.Text = _Email
        Fm.Chk_EsVendedor.Checked = _Es_Vendedor
        Fm.ShowDialog(Me)

        If Fm.Pro_Grabar Then

            Beep()
            ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.ok_button,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

            Sb_Actualizar_Grilla()
        End If
        Fm.Dispose()

    End Sub

    Private Sub Btn_Agregar_Participantes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Agregar_Participantes.Click
        If Fx_Tiene_Permiso(Me, "User0002") Then
            Dim Fm As New Frm_Usuarios_Bk_Ficha
            Fm.Pro_Accion = Frm_Usuarios_Bk_Ficha.Accion.Grabar
            Fm.ShowDialog(Me)

            If Fm.Pro_Grabar Then
                Beep()
                ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.ok_button,
                                       2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                Sb_Actualizar_Grilla()
            End If
            Fm.Dispose()
        End If
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

    End Sub

    Private Sub Frm_Usuarios_Bk_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Txtdescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtdescripcion.TextChanged
        Sb_Actualizar_Grilla()
    End Sub
End Class
