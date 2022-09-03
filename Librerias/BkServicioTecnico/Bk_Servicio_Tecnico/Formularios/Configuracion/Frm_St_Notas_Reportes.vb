Imports BkSpecialPrograms
Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc


Public Class Frm_St_Notas_Reportes

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_St_Notas_Reportes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Editar_Documento(False)

        Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_St_Conf_Info_Reportes"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl.Rows.Count) Then
            Txt_Condiciones.Text = _Tbl.Rows(0).Item("Condiciones")
            Txt_Garantia.Text = _Tbl.Rows(0).Item("Garantia")
        End If

    End Sub

    Sub Sb_Editar_Documento(ByVal _Editar As Boolean)

        Dim _Read_Only As Boolean
        Dim _Color As Color = Color.White

        If _Editar Then

            Btn_Editar.Visible = False
            Btn_Cancelar.Visible = True
            Btn_Grabar.Visible = True

        Else

            Btn_Editar.Visible = True
            Btn_Cancelar.Visible = False
            Btn_Grabar.Visible = False

            _Read_Only = True
            _Color = Color.LightGray
        End If

        Txt_Condiciones.ReadOnly = _Read_Only
        Txt_Condiciones.BackColor = _Color
        Txt_Condiciones.FocusHighlightEnabled = _Editar

        Txt_Garantia.ReadOnly = _Read_Only
        Txt_Garantia.BackColor = _Color
        Txt_Garantia.FocusHighlightEnabled = _Editar

        Me.Refresh()

    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Sb_Editar_Documento(False)
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        If TienePermiso("Stec0016") Then
            Sb_Editar_Documento(True)
        End If
    End Sub

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click

        Consulta_sql = "TRUNCATE TABLE " & _Global_BaseBk & "Zw_St_Conf_Info_Reportes" & vbCrLf & vbCrLf &
                       "Insert Into " & _Global_BaseBk & "Zw_St_Conf_Info_Reportes (Reporte,Condiciones, Garantia) Values " &
                       "('REPORTES','" & Txt_Condiciones.Text & "','" & Txt_Garantia.Text & "')"

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            Beep()
            ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE",
                                   Btn_Grabar.Image,
                                   2 * 1000, eToastGlowColor.Green,
                                   eToastPosition.MiddleCenter)
            Sb_Editar_Documento(False)
        End If

    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub
End Class