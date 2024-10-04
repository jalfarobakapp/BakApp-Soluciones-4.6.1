Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_MantListas_Crear

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Enum Accion
        Nuevo
        Editar
    End Enum

    Dim _Accion As Accion
    Dim _Row_ListaRandom As DataRow
    Dim _Row_ListaBakapp As DataRow

    Private _Lista As String

    Public Property Pro_Lista() As DataRow
        Get
            Return _Row_ListaRandom
        End Get
        Set(value As DataRow)
            _Row_ListaRandom = value
        End Set
    End Property

    Public Sub New(New_Accion As Accion,
                   RowLista As DataRow)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Accion = New_Accion
        _Row_ListaRandom = RowLista

        If Not IsNothing(_Row_ListaRandom) Then
            _Lista = _Row_ListaRandom.Item("KOLT")
            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_ListaPreGlobal Where Lista = '" & _Lista & "'"
            _Row_ListaBakapp = _Sql.Fx_Get_DataRow(Consulta_sql)
        End If

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_MantListas_Crear_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        caract_combo(Cmb_Moneda)
        Consulta_sql = "Select KOMO AS Padre,NOKOMO AS Hijo From TABMO Order by Hijo"
        Cmb_Moneda.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
        Cmb_Moneda.SelectedValue = "$"

        GroupPanel2.Enabled = (_Accion = Accion.Editar)

        If _Accion = Accion.Editar Then

            Txt_Codigo_Lista.Enabled = False
            Txt_Codigo_Lista.Text = _Row_ListaRandom.Item("KOLT")
            Txt_Nombre_Lista.Text = _Row_ListaRandom.Item("NOKOLT")

            Dim _Tilt As String = _Row_ListaRandom.Item("TILT")

            If _Tilt = "C" Then
                Rdb_Lista_Costos.Checked = True
            ElseIf _Tilt = "P" Then
                Rdb_Lista_Precios.Checked = True
            End If

            Dim _Melt As String = _Row_ListaRandom.Item("MELT")

            If _Melt = "N" Then
                Rdb_Neto.Checked = True
            ElseIf _Melt = "B" Then
                Rdb_Bruto.Checked = True
            End If

            Txt_Ecudef01ud.Text = _Row_ListaRandom.Item("ECUDEF01UD")
            Txt_Ecudef02ud.Text = _Row_ListaRandom.Item("ECUDEF02UD")

            Dim _Moneda As String = _Row_ListaRandom.Item("MOLT")
            _Moneda = IIf(String.IsNullOrEmpty(Trim(_Moneda)), "$", _Moneda)
            Cmb_Moneda.SelectedValue = _Moneda

            Chk_EsListaSuperior.Checked = _Row_ListaBakapp.Item("EsListaSuperior")
            Txt_ListaInferior.Tag = _Row_ListaBakapp.Item("ListaInferior")
            Input_Flete.Value = _Row_ListaBakapp.Item("Flete")
            Input_VentaMinVencLP.Value = _Row_ListaBakapp.Item("VentaMinVencLP")

            If Not Chk_EsListaSuperior.Checked Then

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_ListaPreGlobal Where Lista = '" & _Row_ListaBakapp.Item("ListaSuperior") & "'"
                Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not IsNothing(_Row) Then
                    Grupo_Tipo_Lista.Enabled = False
                    Wb_ListaMinorista.Visible = True
                    Wb_ListaMinorista.OptionsButtonVisible = False
                    Wb_ListaMinorista.Text = "<b>Es lista minorista</b> La lista mayorista es: <i>" & _Row.Item("Lista") & " - " & _Row.Item("Nombre_Lista") & "</i>"
                    Panel_Mayorista.Enabled = False
                    Chk_EsListaSuperior.Enabled = False
                End If

            Else

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_ListaPreGlobal Where Lista = '" & _Row_ListaBakapp.Item("ListaInferior") & "'"
                Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Txt_ListaInferior.Text = _Row.Item("Lista").ToString.Trim & "-" & _Row.Item("Nombre_Lista").ToString.Trim

            End If

        End If

        AddHandler Chk_EsListaSuperior.CheckedChanged, AddressOf Chk_EsListaSuperior_CheckedChanged

    End Sub

    Private Sub BtnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGrabar.Click

        If Chk_EsListaSuperior.Checked Then
            If Input_VentaMinVencLP.Value = 0 Then
                MessageBoxEx.Show(Me, "Debe ingresar el valor mínimo de venta para mantener la lista de precios mayorista", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Input_VentaMinVencLP.Focus()
                Return
            End If
            If String.IsNullOrEmpty(Txt_ListaInferior.Text) Then
                MessageBoxEx.Show(Me, "Debe ingresar la lista de precio minorista", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_ListaInferior.Focus()
                Return
            End If
        End If

        Dim _Kolt = Trim(Txt_Codigo_Lista.Text)
        Dim _Nokolt = Trim(Txt_Nombre_Lista.Text)
        Dim _Permiso = "Lp-" & Txt_Codigo_Lista.Text
        Dim _Tilt As String

        If Rdb_Lista_Costos.Checked Then
            _Tilt = "C"
        ElseIf Rdb_Lista_Precios.Checked Then
            _Tilt = "P"
        End If

        Dim _Melt, _Molt, _Timolt As String

        If Rdb_Neto.Checked Then
            _Melt = "N"
        ElseIf Rdb_Bruto.Checked Then
            _Melt = "B"
        End If
        _Molt = Cmb_Moneda.SelectedValue
        _Timolt = _Sql.Fx_Trae_Dato("TABMO", "TIMO", "KOMO = '" & _Molt & "'")

        Dim _Koop, _Nokoop As String

        _Koop = "LI-" & _Kolt & "00"
        _Nokoop = "TABPP" & _Kolt & " -> " & _Nokolt

        Dim _Fevi As String = "Getdate()"

        Consulta_sql = String.Empty

        If Not Chk_EsListaSuperior.Checked Then
            Txt_ListaInferior.Tag = String.Empty
            Input_VentaMinVencLP.Value = 0
        End If

        If _Accion = Accion.Editar Then

            Try
                _Fevi = "'" & Format(_Row_ListaRandom.Item("FEVI"), "yyyyMMdd") & "'"
            Catch ex As Exception
                _Fevi = "'" & Format(FechaDelServidor, "yyyyMMdd") & "'"
            End Try


            'Consulta_sql = "Delete TABPP Where KOLT = '" & _Kolt & "'" & vbCrLf &
            '               "Insert Into TABPP (TILT,KOLT,MELT,MOLT,TIMOLT,NOKOLT,FEVI,OPERA,ECUDEF01UD,ECUDEF02UD) Values " &
            '               "('" & _Tilt & "','" & _Kolt & "','" & _Melt & "','" & _Molt & "','" & _Timolt & "','" & _Nokolt &
            '               "'," & _Fevi & ",'','" & Trim(Txt_Ecudef01ud.Text) & "','" & Trim(Txt_Ecudef02ud.Text) & "')" & vbCrLf & vbCrLf &
            '               "Update MAEOP Set NOKOOP = '" & _Nokoop & "' Where KOOP = '" & _Koop & "'"

            Consulta_sql = "Update TABPP Set " & vbCrLf &
                           "TILT = '" & _Tilt & "'" &
                           ",KOLT = '" & _Kolt & "'" &
                           ",MELT = '" & _Melt & "'" &
                           ",MOLT = '" & _Molt & "'" &
                           ",TIMOLT = '" & _Timolt & "'" &
                           ",NOKOLT = '" & _Nokolt & "'" &
                           ",OPERA = ''" &
                           ",ECUDEF01UD = '" & Txt_Ecudef01ud.Text.Trim & "'" &
                           ",ECUDEF02UD = '" & Txt_Ecudef02ud.Text.Trim & "'" & vbCrLf &
                           "Where KOLT = '" & _Kolt & "';" &
                           vbCrLf &
                           vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_ListaPreGlobal Set " & vbCrLf &
                           "Moneda = '" & Cmb_Moneda.SelectedValue & "'" &
                           ",Nombre_Lista = '" & _Nokolt & "'" &
                           ",TipoValor = '" & _Timolt & "'" &
                           ",ValoresNetos = " & Convert.ToInt32(Rdb_Neto.Checked) &
                           ",Flete = " & De_Num_a_Tx_01(Input_Flete.Value, False, 5) &
                           ",EsListaSuperior = " & Convert.ToInt32(Chk_EsListaSuperior.Checked) &
                           ",ListaInferior = '" & Txt_ListaInferior.Tag & "'" &
                           ",VentaMinVencLP = " & De_Num_a_Tx_01(Input_VentaMinVencLP.Value, False, 5) & vbCrLf &
                           "Where Lista = '" & _Lista & "';" & vbCrLf

            If Chk_EsListaSuperior.Checked Then
                Consulta_sql += "Update " & _Global_BaseBk & "Zw_ListaPreGlobal Set ListaSuperior = '" & _Lista & "' Where Lista = '" & Txt_ListaInferior.Tag & "'" & vbCrLf
            Else
                Consulta_sql += "Update " & _Global_BaseBk & "Zw_ListaPreGlobal Set ListaSuperior = '' Where ListaSuperior = '" & _Lista & "'" & vbCrLf
            End If

        Else
            Consulta_sql = "Insert Into TABPP (TILT,KOLT,MELT,MOLT,TIMOLT,NOKOLT,FEVI,OPERA,ECUDEF01UD,ECUDEF02UD) Values " &
                           "('" & _Tilt & "','" & _Kolt & "','" & _Melt & "','" & _Molt & "','" & _Timolt & "','" & _Nokolt &
                           "'," & _Fevi & ",'','" & Trim(Txt_Ecudef01ud.Text) & "','" & Trim(Txt_Ecudef02ud.Text) & "')" & vbCrLf &
                           "Insert Into MAEOP (KOOP,NOKOOP) Values ('" & _Koop & "','" & _Nokoop & "')"
        End If

        If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If _Accion = Accion.Nuevo Then
            Me.Close()
        Else
            MessageBoxEx.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub Frm_MantListas_Crear_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Fx1_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Fx1.Click
        Txt_Ecudef01ud.Text = Fx_Cambiar_Formula(Txt_Ecudef01ud.Text)
    End Sub

    Private Sub Btn_Fx2_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Fx2.Click
        Txt_Ecudef01ud.Text = Fx_Cambiar_Formula(Txt_Ecudef01ud.Text)
    End Sub

    Function Fx_Cambiar_Formula(_Formula As String)

        Dim _Fxd As Boolean

        If LCase(Trim(_Formula)) = Trim(_Formula) Then
            _Fxd = True
        Else
            _Fxd = False
        End If

        Dim Fm As New Frm_MantListas_Conf_Funciones(_Formula, _Fxd, Rdb_Neto.Checked)
        Fm.ShowDialog(Me)

        If Fm.Pro_Grabar Then
            _Formula = Fm.Txt_Formula_Fx.Text
            Fm.Dispose()
        End If

        Return _Formula

    End Function

    Private Sub Txt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)

        Dim _Comas() = Split(CType(sender, TextBox).Text, ",")

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))

        KeyAscii = CShort(SoloNumeros(KeyAscii, False))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyChar = "."c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            If _Comas.Length = 1 Then SendKeys.Send(",")
        ElseIf e.KeyChar = ","c Then
            If _Comas.Length > 1 Or _Comas(0) = "" Then e.Handled = True
        End If

    End Sub

    Function SoloNumerosSinPuntosNiComas(Keyascii As Short) As Short
        If InStr("1234567890", Chr(Keyascii)) = 0 Then
            SoloNumerosSinPuntosNiComas = 0
        Else
            SoloNumerosSinPuntosNiComas = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumerosSinPuntosNiComas = Keyascii
            Case 13
                SoloNumerosSinPuntosNiComas = Keyascii
        End Select
    End Function

    Private Sub Txt_ListaInferior_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_ListaInferior.ButtonCustomClick

        Dim _Row As DataRow
        Dim _Lista_Seleccionada As DataTable

        Dim Fm As New Frm_SeleccionarListaPrecios(Frm_SeleccionarListaPrecios.Enum_Tipo_Lista.Precio, False, True)
        Fm.NoPedirPermiso = True
        Fm.FiltroAdicional = "And KOLT Not In ('" & _Lista & "')"
        Fm.ShowDialog(Me)
        _Lista_Seleccionada = Fm.Pro_Tbl_Listas_Seleccionadas

        If IsNothing(_Lista_Seleccionada) Then
            Return
        End If

        _Row = _Lista_Seleccionada.Rows(0)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_ListaPreGlobal Where ListaInferior = '" & _Row.Item("Lista") & "' And Lista <> '" & _Lista & "'"
        Dim _RowListaInferior As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_RowListaInferior) Then
            MessageBoxEx.Show("La lista seleccionada es una lista minorista de la lista: " & _Row.Item("Lista").ToString.Trim & "-" & _Row.Item("Nombre_Lista").ToString.Trim,
                          "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_ListaInferior_ButtonCustomClick(Nothing, Nothing)
            Return
        End If

        Txt_ListaInferior.Text = _Row.Item("Lista").ToString.Trim & "-" & _Row.Item("Nombre_Lista").ToString.Trim
        Txt_ListaInferior.Tag = _Row.Item("Lista").ToString.Trim

    End Sub

    Private Sub Txt_ListaInferior_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_ListaInferior.ButtonCustom2Click
        Txt_ListaInferior.Text = String.Empty
        Txt_ListaInferior.Tag = String.Empty
    End Sub

    Private Sub Chk_EsListaSuperior_CheckedChanged(sender As Object, e As EventArgs)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_ListaPreGlobal Where ListaInferior = '" & _Lista & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row) Then
            If Chk_EsListaSuperior.Checked Then
                Chk_EsListaSuperior.Checked = False
                MessageBoxEx.Show("La lista seleccionada es una lista minorista de la lista: " & _Row.Item("Lista").ToString.Trim & "-" & _Row.Item("Nombre_Lista").ToString.Trim,
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        Panel_Mayorista.Enabled = Chk_EsListaSuperior.Checked

    End Sub

End Class
