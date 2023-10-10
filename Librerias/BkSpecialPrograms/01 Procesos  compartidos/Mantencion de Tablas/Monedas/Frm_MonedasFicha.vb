Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports DevComponents.DotNetBar

Public Class Frm_MonedasFicha

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Moneda As DataRow

    Public Property Grabar As Boolean
    Public Property Eliminado As Boolean

    Public Sub New(_Komo As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "Select * From TABMO Where KOMO = '" & _Komo & "'"
        _Row_Moneda = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Private Sub Frm_MonedasFicha_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Arr_Tipo_Entidad(,) As String = {{"N", "Nacional"},
                                             {"E", "Externa"}}
        Sb_Llenar_Combos(_Arr_Tipo_Entidad, Cmb_Timo)
        Cmb_Timo.SelectedValue = "E"

        Dtp_Femo.Value = FechaDelServidor()

        If Not IsNothing(_Row_Moneda) Then

            Txt_Komo.Enabled = False
            Txt_Komo.Text = _Row_Moneda.Item("KOMO")
            Txt_Nokomo.Text = _Row_Moneda.Item("NOKOMO")
            Txt_Vamo.Tag = _Row_Moneda.Item("VAMO")
            Txt_Vamo.Text = _Row_Moneda.Item("VAMO")
            'Dtp_Femo.Value = _Row_Moneda.Item("FEMO")
            Cmb_Timo.SelectedValue = _Row_Moneda.Item("TIMO")
            Btn_Eliminar.Visible = True

        End If

        AddHandler Txt_Vamo.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrWhiteSpace(Txt_Komo.Text) Then
            MessageBoxEx.Show(Me, "Código de moneda no puede estar vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Komo.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(Txt_Nokomo.Text) Then
            MessageBoxEx.Show(Me, "Nombre de moneda no puede estar vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Nokomo.Focus()
            Return
        End If

        If Not CBool(Val(Txt_Vamo.Text)) Then
            MessageBoxEx.Show(Me, "El valor de la moneda no puede ser cero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Vamo.Focus()
            Return
        End If

        Consulta_sql = String.Empty

        If IsNothing(_Row_Moneda) Then

            Consulta_sql = "Insert Into TABMO (KOMO,NOKOMO,FEMO,TIMO,VAMO,VAMOCOM) Values " & vbCrLf &
                           "('" & Txt_Komo.Text & "','" & Txt_Nokomo.Text.Trim & "','" & Format(Dtp_Femo.Value, "yyyyMMdd") &
                           "','" & Cmb_Timo.SelectedValue & "'," & De_Num_a_Tx_01(Txt_Vamo.Text) & ",1.0)" & vbCrLf


        End If

        Consulta_sql += "Insert Into MAEMO (KOMO,NOKOMO,FEMO,TIMO,VAMO,VAMOCOM) VALUES " &
                       "('" & Txt_Komo.Text & "','" & Txt_Nokomo.Text.Trim & "','" & Format(Dtp_Femo.Value, "yyyyMMdd") &
                       "','" & Cmb_Timo.SelectedValue & "'," & De_Num_a_Tx_01(Txt_Vamo.Text) & ",1.0)" & vbCrLf &
                       "Update TABMO Set " &
                       "NOKOMO='" & Txt_Nokomo.Text.Trim & "'" &
                       ",FEMO = '" & Format(Dtp_Femo.Value, "yyyyMMdd") & "'" &
                       ",TIMO = '" & Cmb_Timo.SelectedValue & "'" &
                       ",VAMO = " & De_Num_a_Tx_01(Txt_Vamo.Text) &
                       ",VAMOCOM = 1.0 " &
                       "WHERE KOMO = '" & Txt_Komo.Text & "'" & vbCrLf &
                       "Update PNOMDIM Set VALOR = " & De_Num_a_Tx_01(Txt_Vamo.Text) & " Where CODIGO = 'VALOR_" & Txt_Komo.Text.Trim & "' "

        If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Grabar = True
        Me.Close()

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        If Not Fx_Tiene_Permiso(Me, "Espr0032") Then
            Return
        End If

        Dim _Komo As String = Txt_Komo.Text

        If _Komo.Trim = "$" Or _Komo = "US$" Then
            MessageBoxEx.Show(Me, "Moneda fijada por el sistema, no puede ser eliminada", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Consulta_sql = "Select Top 1 MODO FROM MAEEDO With ( NOLOCK )  WHERE MODO='" & Txt_Komo.Text & "'" & vbCrLf &
                       "Select Top 1 MODP FROM MAEDPCE With ( NOLOCK )  WHERE MODP='" & Txt_Komo.Text & "'"
        Dim _Ds_Monedas As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        If _Ds_Monedas.Tables(0).Rows.Count + _Ds_Monedas.Tables(1).Rows.Count Then
            MessageBoxEx.Show(Me, "Existen documentos asociados a esta moneda, no se puede eliminar", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Confirma la eliminación de esta moneda?", "Eliminar moneda",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_sql = "Delete From TABMO Where CODIGO = '" & _Komo & "'" & vbCrLf &
                       "Delete From MAEMO Where CODIGO = '" & _Komo & "'"
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Grabar = True
            Eliminado = True
            MessageBoxEx.Show(Me, "Moneda eliminada correctamente", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If

    End Sub

    Private Sub Txt_Komo_Leave(sender As Object, e As EventArgs) Handles Txt_Komo.Leave

        Dim _Codigo As String = Txt_Komo.Text
        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("TABMO", "KOMO = '" & _Codigo & "'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "Código de la moneda ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Komo.Focus()
        End If

    End Sub
End Class
