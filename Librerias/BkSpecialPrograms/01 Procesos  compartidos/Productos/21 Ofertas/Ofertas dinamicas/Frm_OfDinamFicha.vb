﻿Imports DevComponents.DotNetBar

Public Class Frm_OfDinamFicha

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Codigo As String
    Dim _Tbl_Listas As DataTable

    Public Property Grabar As Boolean
    Public Property Eliminado As Boolean
    Public Property Row_Maeeres As DataRow

    Public Sub New(_Codigo As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Codigo = _Codigo

        If Not String.IsNullOrEmpty(_Codigo) Then

            Consulta_sql = "Select * From MAEERES Where CODIGO = '" & _Codigo & "' And TIPORESE = 'din'"
            _Row_Maeeres = _Sql.Fx_Get_DataRow(Consulta_sql)

        End If

    End Sub

    Private Sub Frm_OfDinamFicha_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Chk_Tipotrat1.CheckedChanged, AddressOf Chk_Tipotrat_CheckedChanged
        AddHandler Chk_Tipotrat2.CheckedChanged, AddressOf Chk_Tipotrat_CheckedChanged
        AddHandler Chk_Tipotrat3.CheckedChanged, AddressOf Chk_Tipotrat_CheckedChanged
        AddHandler Chk_Tipotrat4.CheckedChanged, AddressOf Chk_Tipotrat_CheckedChanged

        caract_combo(Cmb_Concepto)
        Consulta_sql = "SELECT KOCT AS Padre,LTRIM(RTRIM(KOCT))+'-'+LTRIM(RTRIM(NOKOCT)) AS Hijo FROM TABCT WHERE TICT = 'D' ORDER BY Hijo"
        Cmb_Concepto.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Concepto.SelectedValue = ""

        If IsNothing(_Row_Maeeres) Then

            Dtp_Fioferta.Value = Nothing
            Dtp_Ftoferta.Value = Nothing
            Txt_Codigo.Enabled = True
            Txt_Udad.Enabled = True
            Txt_Udad.Text = String.Empty
            Me.ActiveControl = Txt_Codigo

        Else

            Txt_Codigo.Enabled = False
            Txt_Codigo.Text = _Row_Maeeres.Item("CODIGO")
            Txt_Descriptor.Text = _Row_Maeeres.Item("DESCRIPTOR").ToString.Trim
            Dtp_Fioferta.Value = _Row_Maeeres.Item("FIOFERTA")
            Dtp_Ftoferta.Value = _Row_Maeeres.Item("FTOFERTA")
            Txt_Udad.Text = _Row_Maeeres.Item("UDAD")
            Input_Cantmin.Value = _Row_Maeeres.Item("CANTMIN")
            Chk_Rangos.Checked = _Row_Maeeres.Item("RANGOS")

            Select Case _Row_Maeeres.Item("TIPOTRAT")
                Case "1"
                    Chk_Tipotrat1.Checked = True
                Case "2"
                    Chk_Tipotrat2.Checked = True
                Case "3"
                    Chk_Tipotrat3.Checked = True
                Case "4"
                    Chk_Tipotrat4.Checked = True
                Case Else
                    Chk_Tipotrat1.Checked = True
            End Select

            Txt_Valdesc.Text = _Row_Maeeres.Item("VALDESC")
            Txt_Ecupordesc.Text = _Row_Maeeres.Item("ECUPORDESC").ToString.Trim
            Cmb_Concepto.SelectedValue = _Row_Maeeres.Item("CONCEPTO")

            Txt_Listas.Text = _Row_Maeeres.Item("LISTAS")

            Dim _Listas As String = Txt_Listas.Text.Replace("TABPP", "")
            Dim _ListasPr() = _Listas.Split("_")

            Dim _Filtro_Listas As String = Generar_Filtro_IN_Arreglo(_ListasPr, False)

            If _Filtro_Listas <> "()" Then

                Consulta_sql = "Select Cast(1 As Bit) As Chk,KOLT As Codigo,NOKOLT As Descripcion From TABPP Where KOLT In " & _Filtro_Listas
                _Tbl_Listas = _Sql.Fx_Get_Tablas(Consulta_sql)

            End If

            Chk_Desc_Lun.Checked = (_Row_Maeeres.Item("DESC_LUN") = "S")
            Chk_Desc_Mar.Checked = (_Row_Maeeres.Item("DESC_MAR") = "S")
            Chk_Desc_Mie.Checked = (_Row_Maeeres.Item("DESC_MIE") = "S")
            Chk_Desc_Jue.Checked = (_Row_Maeeres.Item("DESC_JUE") = "S")
            Chk_Desc_Vie.Checked = (_Row_Maeeres.Item("DESC_VIE") = "S")
            Chk_Desc_Sab.Checked = (_Row_Maeeres.Item("DESC_SAB") = "S")
            Chk_Desc_Dom.Checked = (_Row_Maeeres.Item("DESC_DOM") = "S")

            Me.ActiveControl = Txt_Codigo

        End If

    End Sub

    Private Sub Chk_Tipotrat_CheckedChanged(sender As Object, e As EventArgs)

        If Chk_Tipotrat1.Checked Or Chk_Tipotrat2.Checked Then
            Lbl_Valdesc.Text = "Porcentaje"
        End If

        If Chk_Tipotrat1.Checked Or Chk_Tipotrat2.Checked Then
            Lbl_Valdesc.Text = "Monto"
        End If

    End Sub

    Private Sub Txt_Listas_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Listas.ButtonCustomClick

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "TABPP"
        _Filtrar.Campo = "KOLT"
        _Filtrar.Descripcion = "NOKOLT"

        If _Filtrar.Fx_Filtrar(_Tbl_Listas,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "",
                               False, True) Then

            _Tbl_Listas = _Filtrar.Pro_Tbl_Filtro
            Txt_Listas.Text = String.Empty

            For Each _Lista As DataRow In _Tbl_Listas.Rows
                Txt_Listas.Text += "TABPP" & _Lista.Item("Codigo") & "_"
            Next

        End If

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Txt_Codigo.Text) Then
            MessageBoxEx.Show(Me, "Código de descuento no puede estar vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Codigo.Focus()
            Return
        End If

        If Dtp_Fioferta.Value = #1/1/0001 12:00:00 AM# Then
            MessageBoxEx.Show(Me, "La fecha de inicio no puede estar vacía", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Dtp_Fioferta.Focus()
            Return
        End If

        If Dtp_Ftoferta.Value = #1/1/0001 12:00:00 AM# Then
            MessageBoxEx.Show(Me, "La fecha de termino no puede estar vacía", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Dtp_Ftoferta.Focus()
            Return
        End If

        If Dtp_Fioferta.Value > Dtp_Ftoferta.Value Then
            MessageBoxEx.Show(Me, "La fecha de inicio no puede ser mayor a la fecha de termino", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Dtp_Ftoferta.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Udad.Text) Then
            MessageBoxEx.Show(Me, "Unidad de medida no puede estar vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Udad.Focus()
            Return
        End If

        Dim _Codigo As String = Txt_Codigo.Text
        Dim _Cantmin As Integer = Input_Cantmin.Value
        Dim _Rangos As Integer = Convert.ToInt32(Chk_Rangos.Checked)
        Dim _Descriptor As String = Txt_Descriptor.Text
        Dim _Udad As String = Txt_Udad.Text
        Dim _Concepto As String = Cmb_Concepto.SelectedValue
        Dim _Fioferta As String = Format(Dtp_Fioferta.Value, "yyyyMMdd")
        Dim _Ftoferta As String = Format(Dtp_Ftoferta.Value, "yyyyMMdd")
        Dim _Listas As String = Txt_Listas.Text
        Dim _Desc_lun As String = "N"
        Dim _Desc_mar As String = "N"
        Dim _Desc_mie As String = "N"
        Dim _Desc_jue As String = "N"
        Dim _Desc_vie As String = "N"
        Dim _Desc_sab As String = "N"
        Dim _Desc_dom As String = "N"

        If Chk_Desc_Lun.Checked Then _Desc_lun = "S"
        If Chk_Desc_Mar.Checked Then _Desc_mar = "S"
        If Chk_Desc_Mie.Checked Then _Desc_mie = "S"
        If Chk_Desc_Jue.Checked Then _Desc_jue = "S"
        If Chk_Desc_Vie.Checked Then _Desc_vie = "S"
        If Chk_Desc_Sab.Checked Then _Desc_sab = "S"
        If Chk_Desc_Dom.Checked Then _Desc_dom = "S"

        Dim _Valdesc As String = De_Num_a_Tx_01(Txt_Valdesc.Text, False, 5)

        Dim _Tipotrat As Integer = 1

        If Chk_Tipotrat1.Checked Then _Tipotrat = 1
        If Chk_Tipotrat2.Checked Then _Tipotrat = 2
        If Chk_Tipotrat3.Checked Then _Tipotrat = 3
        If Chk_Tipotrat4.Checked Then _Tipotrat = 4

        Dim _Ecuvaldesc As String = Txt_Ecupordesc.Text

        Consulta_sql = "Delete MAEERES Where CODIGO = '" & _Codigo & "' And TIPORESE = 'din'" & vbCrLf &
                       "Insert Into MAEERES (CODIGO,CANTIDAD,CANTMIN,RANGOS,DESCRIPTOR,UDAD,TIPORESE,CONCEPTO,FIOFERTA,FTOFERTA,LISTAS,APLICAUT,DESC_LUN,DESC_MAR,DESC_MIE,DESC_JUE,DESC_VIE,DESC_SAB,DESC_DOM,DESCVALOR,TIPOTRAT,VALDESC,ECUVALDESC) VALUES " &
                       "('" & _Codigo & "',0," & _Cantmin & "," & _Rangos & ",'" & _Descriptor & "','" & _Udad & "','din','" & _Concepto & "'" &
                       ",'" & _Fioferta & "','" & _Ftoferta & "','" & _Listas & "',0" &
                       ",'" & _Desc_lun & "','" & _Desc_mar & "','" & _Desc_mie & "','" & _Desc_jue & "','" & _Desc_vie & "'" &
                       ",'" & _Desc_sab & "','" & _Desc_dom & "',0," & _Tipotrat & "," & _Valdesc & ",'" & _Ecuvaldesc & "')"

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            Consulta_sql = "Select * From MAEERES Where CODIGO = '" & Txt_Codigo.Text & "' And TIPORESE = 'din'"
            Row_Maeeres = _Sql.Fx_Get_DataRow(Consulta_sql)

            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Grabar = True
            Me.Close()
        Else
            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Txt_Codigo_Leave(sender As Object, e As EventArgs) Handles Txt_Codigo.Leave

        Dim _Codigo As String = Txt_Codigo.Text
        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("MAEERES", "CODIGO = '" & _Codigo & "'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "Código de oferta ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Codigo.Focus()
        End If

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        If Not Fx_Tiene_Permiso(Me, "Ofer0004") Then
            Return
        End If

        Dim _Codigo As String = Txt_Codigo.Text

        If MessageBoxEx.Show(Me, "¿Confirma quitar este producto de la oferta?", "Quitar productos",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_sql = "Delete From MAEERES Where CODIGO = '" & _Codigo & "'" & vbCrLf &
                       "Delete From MAEDRES Where CODIGO = '" & _Codigo & "'"
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Grabar = True
            Eliminado = True
            MessageBoxEx.Show(Me, "Oferta eliminada correctamente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If

    End Sub
End Class