﻿Imports DevComponents.DotNetBar

Public Class Frm_Cms_FuncMant

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Id As Integer
    Dim _Row_Funcionario As DataRow
    Dim _Tbl_MisComisiones As DataTable

    Public Property Grabar As Boolean
    Public Property EditandoDesdeComisiones As Boolean
    Public Property Afp As Double
    Public Property Salud As Double

    Public Property Row_Funcionario As DataRow
        Get
            Return _Row_Funcionario
        End Get
        Set(value As DataRow)
            _Row_Funcionario = value
        End Set
    End Property

    Public Sub New(_Id As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id = _Id

        Consulta_Sql = "Select TABFU.*,Uss.*" & vbCrLf &
                       "From TABFU" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_Comisiones_Fun Uss On KOFU = Uss.CodFuncionario" & vbCrLf &
                       "Where Uss.Id = " & _Id
        _Row_Funcionario = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If Not IsNothing(_Row_Funcionario) Then
            Txt_AFP.Text = De_Num_a_Tx_01(_Row_Funcionario.Item("AFP"), False, 2)
            Txt_Salud.Text = De_Num_a_Tx_01(_Row_Funcionario.Item("Salud"), False, 2)
        End If

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Cms_FuncMant_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not CBool(_Id) Then
            Me.Height = 212
            Btn_AgregarComision.Visible = False
        End If

        Txt_Funcionario.Text = _Row_Funcionario.Item("KOFU").ToString.Trim & " - " & _Row_Funcionario.Item("NOKOFU").ToString.Trim
        Chk_Habilitado.Checked = _Row_Funcionario.Item("Habilitado")

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

    End Sub


    Sub Sb_Actualizar_Grilla()

        Consulta_Sql = "Select Mis.*," &
                       "Case When (Select COUNT(*) From " & _Global_BaseBk & "Zw_Comisiones_DetFlTbl Fl Where Id_Mis = Mis.Id) = 0 Then 'No' Else 'Si' End As Resumen," &
                       "Case When TieneSC = 1 Then 'Si' Else 'No' End As TieneSmeCorr" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Comisiones_Mis Mis" & vbCrLf &
                       "Where CodFuncionario = '" & _Row_Funcionario.Item("KOFU") & "'"
        _Tbl_MisComisiones = _Sql.Fx_Get_DataTable(Consulta_Sql)

        Dim _DisplayIndex = 0

        With Grilla

            .DataSource = _Tbl_MisComisiones

            OcultarEncabezadoGrilla(Grilla)

            .Columns("Descripcion").Width = 330 - 60
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").ReadOnly = False
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PorcComision").Width = 40
            .Columns("PorcComision").HeaderText = "% CM"
            .Columns("PorcComision").ToolTipText = "Porcenta de comisión"
            .Columns("PorcComision").Visible = True
            .Columns("PorcComision").ReadOnly = False
            .Columns("PorcComision").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Resumen").Width = 60
            .Columns("Resumen").HeaderText = "Tiene Filtros"
            .Columns("Resumen").Visible = True
            .Columns("Resumen").ReadOnly = False
            .Columns("Resumen").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("MisVentas").Width = 60
            .Columns("MisVentas").HeaderText = "Mis Ventas"
            '.Columns("MisVentas").ToolTipText = ""
            .Columns("MisVentas").Visible = True
            .Columns("MisVentas").ReadOnly = False
            .Columns("MisVentas").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TieneSmeCorr").Width = 60
            .Columns("TieneSmeCorr").HeaderText = "Tiene S.C."
            .Columns("TieneSmeCorr").ToolTipText = "Tiene semana corrida"
            .Columns("TieneSmeCorr").Visible = True
            .Columns("TieneSmeCorr").ReadOnly = False
            .Columns("TieneSmeCorr").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        _Afp = Val(Txt_AFP.Text)
        _Salud = Val(Txt_Salud.Text)

        If Chk_Habilitado.Checked Then

            If _Afp = 0 Then
                If MessageBoxEx.Show(Me, "AFP en cero" & vbCrLf &
                                     "¿Confirma dejar el valor en cero?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) <> DialogResult.Yes Then
                    Txt_AFP.Text = 0
                    Txt_AFP.Focus()
                    Return
                End If
            End If

            If _Salud = 0 Then
                If MessageBoxEx.Show(Me, "Salud en cero" & vbCrLf &
                                     "¿Confirma dejar el valor en cero?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) <> DialogResult.Yes Then
                    Txt_Salud.Text = 0
                    Txt_Salud.Focus()
                    Return
                End If
            End If

        End If

        If EditandoDesdeComisiones Then
            Grabar = True
            Me.Close()
            Return
        End If

        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Comisiones_Fun Set" &
                       " AFP = " & De_Num_a_Tx_01(_Afp, False, 5) &
                       ",Salud = " & De_Num_a_Tx_01(_Salud, False, 5) &
                       ",Habilitado = " & Convert.ToInt32(Chk_Habilitado.Checked) & vbCrLf &
                       "Where Id = " & _Id
        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
            Grabar = True
            Me.Close()
        End If

    End Sub

    Private Sub Btn_AgregarComision_Click(sender As Object, e As EventArgs) Handles Btn_AgregarComision.Click

        Dim Fm As New Frm_Cms_AgregarTipos(0, _Row_Funcionario.Item("KOFU"))
        Fm.Text = "FUNCIONARIO: " & _Row_Funcionario.Item("KOFU").ToString.Trim & "-" & _Row_Funcionario.Item("NOKOFU").ToString.Trim
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            Sb_Actualizar_Grilla()
        End If
        Fm.Dispose()

    End Sub

    Private Sub Txt_AFP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_AFP.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii, False))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True

        ElseIf e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(".")
        End If
    End Sub

    Private Sub Txt_Salud_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Salud.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii, False))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True

        ElseIf e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(".")
        End If
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Id As Integer = _Fila.Cells("Id").Value
        Dim _CodFuncionario As String = _Fila.Cells("CodFuncionario").Value

        Dim Fm As New Frm_Cms_AgregarTipos(_Id, _CodFuncionario)
        Fm.Text = "FUNCIONARIO(A): " & Txt_Funcionario.Text.Trim
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            Sb_Actualizar_Grilla()
        End If
        Fm.Dispose()

    End Sub

End Class
