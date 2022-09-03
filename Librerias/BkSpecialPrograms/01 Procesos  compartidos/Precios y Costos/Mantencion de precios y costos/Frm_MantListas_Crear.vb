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
    Dim _RowLista As DataRow
    'Dim _Lista As String
    'Dim _FormulaGrabarRD As String

    Public Property Pro_Lista() As DataRow
        Get
            Return _RowLista
        End Get
        Set(ByVal value As DataRow)
            _RowLista = value
        End Set
    End Property

    Public Sub New(ByVal New_Accion As Accion,
                   ByVal RowLista As DataRow)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Accion = New_Accion
        _RowLista = RowLista
        '_Lista = New_Lista

    End Sub

    Private Sub Frm_MantListas_Crear_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        caract_combo(Cmb_Moneda)
        Consulta_sql = "SELECT KOMO AS Padre,NOKOMO AS Hijo FROM TABMO ORDER BY Hijo" ' WHERE SEMILLA = " & Actividad
        Cmb_Moneda.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)
        Cmb_Moneda.SelectedValue = "$"

        If _Accion = Accion.Editar Then

            'Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_ListaPreGlobal Where Lista = '" & _Lista & "'"
            '_RowLista = _Sql.Fx_Get_DataRow(Consulta_sql)

            Txt_Codigo_Lista.Enabled = False
            Txt_Codigo_Lista.Text = _RowLista.Item("KOLT")
            Txt_Nombre_Lista.Text = _RowLista.Item("NOKOLT")

            Dim _Tilt As String = _RowLista.Item("TILT")

            If _Tilt = "C" Then
                Rdb_Lista_Costos.Checked = True
            ElseIf _Tilt = "P" Then
                Rdb_Lista_Precios.Checked = True
            End If

            Dim _Melt As String = _RowLista.Item("MELT")

            If _Melt = "N" Then
                Rdb_Neto.Checked = True
            ElseIf _Melt = "B" Then
                Rdb_Bruto.Checked = True
            End If


            Txt_Ecudef01ud.Text = _RowLista.Item("ECUDEF01UD")
            Txt_Ecudef02ud.Text = _RowLista.Item("ECUDEF02UD")

            Dim _Moneda As String = _RowLista.Item("MOLT")
            _Moneda = IIf(String.IsNullOrEmpty(Trim(_Moneda)), "$", _Moneda)
            Cmb_Moneda.SelectedValue = _Moneda

            '_FormulaGrabarRD = _RowLista.Item("FormulaGrabarRD")

            'Chk_Ej_Fx_documento.Checked = _RowLista.Item("Ej_Fx_documento")
            'Chk_Ej_Fx_documento2.Checked = _RowLista.Item("Ej_Fx_documento2")
            Grupo_Tipo_Lista.Enabled = False


        End If

        'AddHandler Txt_Margen_Ud1.KeyPress, AddressOf Txt_KeyPress
        'AddHandler Txt_Margen_Ud2.KeyPress, AddressOf Txt_KeyPress
        'AddHandler Txt_DsctoMax.KeyPress, AddressOf Txt_KeyPress

    End Sub


    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click


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
        'LI-01C00	TABPP01C -> COSTO ULTIMA COMPRA CM     
        Consulta_sql = String.Empty


        If _Accion = Accion.Editar Then
            _Fevi = "'" & Format(_RowLista.Item("FEVI"), "yyyyMMdd") & "'"
            Consulta_sql = "Delete TABPP Where KOLT = '" & _Kolt & "'" & vbCrLf &
                           "Insert Into TABPP (TILT,KOLT,MELT,MOLT,TIMOLT,NOKOLT,FEVI,OPERA,ECUDEF01UD,ECUDEF02UD) Values " &
                           "('" & _Tilt & "','" & _Kolt & "','" & _Melt & "','" & _Molt & "','" & _Timolt & "','" & _Nokolt &
                           "'," & _Fevi & ",'','" & Trim(Txt_Ecudef01ud.Text) & "','" & Trim(Txt_Ecudef02ud.Text) & "')" & vbCrLf & vbCrLf &
                           "Update MAEOP Set NOKOOP = '" & _Nokoop & "' Where KOOP = '" & _Koop & "'"
        Else
            Consulta_sql = "Insert Into TABPP (TILT,KOLT,MELT,MOLT,TIMOLT,NOKOLT,FEVI,OPERA,ECUDEF01UD,ECUDEF02UD) Values " &
                           "('" & _Tilt & "','" & _Kolt & "','" & _Melt & "','" & _Molt & "','" & _Timolt & "','" & _Nokolt &
                           "'," & _Fevi & ",'','" & Trim(Txt_Ecudef01ud.Text) & "','" & Trim(Txt_Ecudef02ud.Text) & "')" & vbCrLf &
                          "Insert Into MAEOP (KOOP,NOKOOP) Values ('" & _Koop & "','" & _Nokoop & "')"
        End If


        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            If _Accion = Accion.Nuevo Then
                Me.Close()
            Else

                Beep()
                ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.ok_button,
                                       1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
            End If

        End If

    End Sub

    Private Sub Frm_MantListas_Crear_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Fx1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Fx1.Click
        Txt_Ecudef01ud.Text = Fx_Cambiar_Formula(Txt_Ecudef01ud.Text)
    End Sub

    Private Sub Btn_Fx2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Fx2.Click
        Txt_Ecudef01ud.Text = Fx_Cambiar_Formula(Txt_Ecudef01ud.Text)
    End Sub

    Function Fx_Cambiar_Formula(ByVal _Formula As String)

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

    Private Sub Txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

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


    Function SoloNumerosSinPuntosNiComas(ByVal Keyascii As Short) As Short
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




End Class
