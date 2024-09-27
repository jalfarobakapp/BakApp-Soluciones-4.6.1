Imports DevComponents.DotNetBar

Public Class Frm_OfDinamFicha

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Codigo As String
    Dim _Tbl_Listas As DataTable

    Public Property Grabar As Boolean
    Public Property Eliminado As Boolean
    Public Property Row_Maeeres As DataRow

    Dim _Tbl_TipoOferta As DataTable

    Public Sub New(_Codigo As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Codigo = _Codigo

        If Not String.IsNullOrEmpty(_Codigo) Then

            Consulta_sql = "Select * From MAEERES Where CODIGO = '" & _Codigo & "' And TIPORESE = 'din'"
            _Row_Maeeres = _Sql.Fx_Get_DataRow(Consulta_sql)

        End If

        Sb_Grabar_Parametros_SQL(False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_OfDinamFicha_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Chk_Tipotrat1.CheckedChanged, AddressOf Chk_Tipotrat_CheckedChanged
        AddHandler Chk_Tipotrat2.CheckedChanged, AddressOf Chk_Tipotrat_CheckedChanged
        AddHandler Chk_Tipotrat3.CheckedChanged, AddressOf Chk_Tipotrat_CheckedChanged
        AddHandler Chk_Tipotrat4.CheckedChanged, AddressOf Chk_Tipotrat_CheckedChanged
        AddHandler Txt_Valdesc.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros

        caract_combo(Cmb_Concepto)
        Consulta_sql = "SELECT KOCT AS Padre,LTRIM(RTRIM(KOCT))+'-'+LTRIM(RTRIM(NOKOCT)) AS Hijo FROM TABCT WHERE TICT = 'D' ORDER BY Hijo"
        Cmb_Concepto.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
        Cmb_Concepto.SelectedValue = ""

        caract_combo(Cmb_Kogen)
        Consulta_sql = "SELECT KOCARAC AS Padre,LTRIM(RTRIM(NOKOCARAC)) AS Hijo FROM TABCARAC WHERE KOTABLA = 'TIPOOFERTA' ORDER BY Hijo"
        _Tbl_TipoOferta = _Sql.Fx_Get_DataTable(Consulta_sql)
        Cmb_Kogen.DataSource = _Tbl_TipoOferta
        Cmb_Kogen.SelectedValue = ""

        Txt_Valdesc.Enabled = True

        Lbl_Kogen.Visible = CBool(_Tbl_TipoOferta.Rows.Count)
        Cmb_Kogen.Visible = CBool(_Tbl_TipoOferta.Rows.Count)

        If IsNothing(_Row_Maeeres) Then

            Dtp_Fioferta.Value = Nothing
            Dtp_Ftoferta.Value = Nothing
            Txt_Codigo.Enabled = True
            Txt_Udad.Enabled = True
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
                _Tbl_Listas = _Sql.Fx_Get_DataTable(Consulta_sql)

            End If

            Chk_Desc_Lun.Checked = (_Row_Maeeres.Item("DESC_LUN") = "S")
            Chk_Desc_Mar.Checked = (_Row_Maeeres.Item("DESC_MAR") = "S")
            Chk_Desc_Mie.Checked = (_Row_Maeeres.Item("DESC_MIE") = "S")
            Chk_Desc_Jue.Checked = (_Row_Maeeres.Item("DESC_JUE") = "S")
            Chk_Desc_Vie.Checked = (_Row_Maeeres.Item("DESC_VIE") = "S")
            Chk_Desc_Sab.Checked = (_Row_Maeeres.Item("DESC_SAB") = "S")
            Chk_Desc_Dom.Checked = (_Row_Maeeres.Item("DESC_DOM") = "S")

            If CBool(_Tbl_TipoOferta.Rows.Count) Then
                Cmb_Kogen.SelectedValue = _Row_Maeeres.Item("KOGEN")
            End If

            Me.ActiveControl = Txt_Descriptor

        End If

    End Sub

    Private Sub Chk_Tipotrat_CheckedChanged(sender As Object, e As EventArgs)

        If Chk_Tipotrat1.Checked Or Chk_Tipotrat2.Checked Then
            Lbl_Valdesc.Text = "Porcentaje"
        End If

        If Chk_Tipotrat3.Checked Or Chk_Tipotrat4.Checked Then
            Lbl_Valdesc.Text = "Monto"
        End If

    End Sub

    Private Sub Txt_Listas_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Listas.ButtonCustomClick

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "TABPP"
        _Filtrar.Campo = "KOLT"
        _Filtrar.Descripcion = "NOKOLT"

        If _Filtrar.Fx_Filtrar(_Tbl_Listas,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "", False, False) Then

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

        Dim _Kogen = String.Empty

        If CBool(_Tbl_TipoOferta.Rows.Count) Then
            If String.IsNullOrEmpty(Cmb_Kogen.Text) Then
                MessageBoxEx.Show(Me, "Falta el tipo de Oferta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Udad.Focus()
                Return
            End If
            _Kogen = Cmb_Kogen.SelectedValue
        End If


        Dim _FechaServidor As Date = FechaDelServidor()

        Dim resultadoInicio As Integer = Date.Compare(_FechaServidor, Dtp_Fioferta.Value)
        Dim resultadoFin As Integer = Date.Compare(_FechaServidor, Dtp_Ftoferta.Value)

        If (resultadoInicio >= 0 And resultadoFin <= 0) Or Dtp_Fioferta.Value > _FechaServidor Then

            'La fecha está entre las dos fechas

            Dim _Fs As String = Format(_FechaServidor, "yyyyMMdd")
            Dim _Fi As String = Format(Dtp_Fioferta.Value, "yyyyMMdd")
            Dim _Ft As String = Format(Dtp_Ftoferta.Value, "yyyyMMdd")

            Consulta_sql = "Select ELEMENTO Into #Ps1 From MAEDRES Where CODIGO = '" & Txt_Codigo.Text.Trim & "'" & vbCrLf &
                           "Select * From MAEERES Where CODIGO In" & vbCrLf &
                           "(Select CODIGO From MAEDRES Where ELEMENTO In (Select ELEMENTO From #Ps1))" & vbCrLf &
                           "And CODIGO <> '" & Txt_Codigo.Text.Trim & "' And ('" & _Fi & "' Between FIOFERTA And FTOFERTA Or '" & _Ft & "' Between FIOFERTA And FTOFERTA)" & vbCrLf &
                           "Drop Table #Ps1"

            Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If CBool(_Tbl.Rows.Count) Then
                MessageBoxEx.Show(Me, "PRODUCTOS YA ACTIVOS EN OTRA OFERTA." & vbCrLf & "NO SE PUEDE ACTIVAR ESTE DESCUENTO." & vbCrLf & vbCrLf &
                                  "Puedes suceder 2 cosas:" & vbCrLf &
                                  "- Hay una oferta con productos que ya esta activa." & vbCrLf &
                                  "- Hay una oferta que se activara en una fecha futura y coincidirá con esta oferta.",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

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

        Dim _Valdesc As String = De_Num_a_Tx_01(CDbl(Txt_Valdesc.Text), False, 5)

        Dim _Tipotrat As Integer = 1

        If Chk_Tipotrat1.Checked Then _Tipotrat = 1
        If Chk_Tipotrat2.Checked Then _Tipotrat = 2
        If Chk_Tipotrat3.Checked Then _Tipotrat = 3
        If Chk_Tipotrat4.Checked Then _Tipotrat = 4

        Dim _Ecuvaldesc As String = Txt_Ecupordesc.Text

        Consulta_sql = "Delete MAEERES Where CODIGO = '" & _Codigo & "' And TIPORESE = 'din'" & vbCrLf &
                       "Insert Into MAEERES (CODIGO,CANTIDAD,CANTMIN,RANGOS,DESCRIPTOR,UDAD,TIPORESE,CONCEPTO,FIOFERTA,FTOFERTA,LISTAS,APLICAUT," &
                       "DESC_LUN,DESC_MAR,DESC_MIE,DESC_JUE,DESC_VIE,DESC_SAB,DESC_DOM,DESCVALOR,TIPOTRAT,VALDESC,ECUVALDESC,KOGEN) VALUES " &
                       "('" & _Codigo & "',0," & _Cantmin & "," & _Rangos & ",'" & _Descriptor & "','" & _Udad & "','din','" & _Concepto & "'" &
                       ",'" & _Fioferta & "','" & _Ftoferta & "','" & _Listas & "',0" &
                       ",'" & _Desc_lun & "','" & _Desc_mar & "','" & _Desc_mie & "','" & _Desc_jue & "','" & _Desc_vie & "'" &
                       ",'" & _Desc_sab & "','" & _Desc_dom & "',0," & _Tipotrat & "," & _Valdesc & ",'" & _Ecuvaldesc & "','" & _Kogen & "')"

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            Sb_GrabarNuevaLineaHistorica(Txt_Codigo.Text)

            Consulta_sql = "Select * From MAEERES Where CODIGO = '" & Txt_Codigo.Text & "' And TIPORESE = 'din'"
            Row_Maeeres = _Sql.Fx_Get_DataRow(Consulta_sql)

            Sb_Grabar_Parametros_SQL(True)

            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Grabar = True
            Me.Close()

        Else
            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Sub Sb_GrabarNuevaLineaHistorica(_Codigo As String)

        If Not _Sql.Fx_Existe_Tabla("MAEERES_Hist") Then
            Return
        End If

        Consulta_sql = "Insert Into MAEERES_Hist (CODIGO,CANTIDAD,UDAD,DESCRIPTOR,ESTARESE,TIPORESE,
CONCEPTO,LISTAS,FIOFERTA,FTOFERTA,APLICAUT,PORDESC,ECUPORDESC,DESC_LUN,DESC_MAR,DESC_MIE,
DESC_JUE,DESC_VIE,DESC_SAB,DESC_DOM,DESCVALOR,VALDESC,ECUVALDESC,KOGEN,CANTMIN,TIPOTRAT,RANGOS,INCLUYENVV,TGRANEL,FGRABACION,KOFUGRABA)
Select CODIGO,CANTIDAD,UDAD,DESCRIPTOR,ESTARESE,TIPORESE,CONCEPTO,LISTAS,FIOFERTA,FTOFERTA,APLICAUT,PORDESC,ECUPORDESC,DESC_LUN,DESC_MAR,DESC_MIE,
DESC_JUE,DESC_VIE,DESC_SAB,DESC_DOM,DESCVALOR,VALDESC,ECUVALDESC,KOGEN,CANTMIN,TIPOTRAT,RANGOS,INCLUYENVV,TGRANEL,GETDATE(),'" & FUNCIONARIO & "'
FROM MAEERES Pd
WHERE NOT EXISTS (
    SELECT 1
    FROM MAEERES_Hist Hj
    WHERE Pd.CODIGO = Hj.CODIGO And Pd.CANTIDAD = Hj.CANTIDAD And Pd.UDAD = Hj.UDAD And Pd.DESCRIPTOR = Hj.DESCRIPTOR And Pd.ESTARESE = Hj.ESTARESE 
	And Pd.TIPORESE = Hj.TIPORESE And Pd.CONCEPTO = Hj.CONCEPTO And Pd.LISTAS = Hj.LISTAS And Pd.FIOFERTA = Hj.FIOFERTA And Pd.FTOFERTA = Hj.FTOFERTA 
	And Pd.APLICAUT = Hj.APLICAUT And Pd.PORDESC = Hj.PORDESC And Pd.ECUPORDESC = Hj.ECUPORDESC And Pd.DESC_LUN = Hj.DESC_LUN And Pd.DESC_MAR = Hj.DESC_MAR
	And Pd.DESC_MIE = Hj.DESC_MIE And Pd.DESC_JUE = Hj.DESC_JUE And Pd.DESC_VIE = Hj.DESC_VIE And Pd.DESC_SAB = Hj.DESC_SAB And Pd.DESC_DOM = Hj.DESC_DOM 
	And Pd.DESCVALOR = Hj.DESCVALOR And Pd.VALDESC = Hj.VALDESC And Pd.ECUVALDESC = Hj.ECUVALDESC And Pd.KOGEN = Hj.KOGEN And Pd.CANTMIN = Hj.CANTMIN
	And Pd.TIPOTRAT = Hj.TIPOTRAT And Pd.RANGOS = Hj.RANGOS And Pd.INCLUYENVV = Hj.INCLUYENVV And Pd.TGRANEL = Hj.TGRANEL
	And Pd.CODIGO = '" & _Codigo & "'
)
And CODIGO = '" & _Codigo & "'"
        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

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

        If MessageBoxEx.Show(Me, "¿Confirma eliminar esta oferta?", "Eliminar oferta",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_sql = String.Empty

        If _Sql.Fx_Existe_Tabla("MAEERES_Hist") Then

            Consulta_sql = "Insert Into MAEERES_Hist (CODIGO,CANTIDAD,UDAD,DESCRIPTOR,ESTARESE,TIPORESE,CONCEPTO,LISTAS,FIOFERTA,FTOFERTA,APLICAUT,PORDESC,ECUPORDESC,DESC_LUN,DESC_MAR,DESC_MIE,
DESC_JUE,DESC_VIE,DESC_SAB,DESC_DOM,DESCVALOR,VALDESC,ECUVALDESC,KOGEN,CANTMIN,TIPOTRAT,RANGOS,INCLUYENVV,TGRANEL,FGRABACION,KOFUGRABA,OFERTAELIMINADA)
Select CODIGO,CANTIDAD,UDAD,DESCRIPTOR,ESTARESE,TIPORESE,CONCEPTO,LISTAS,FIOFERTA,FTOFERTA,APLICAUT,PORDESC,ECUPORDESC,DESC_LUN,DESC_MAR,DESC_MIE,
DESC_JUE,DESC_VIE,DESC_SAB,DESC_DOM,DESCVALOR,VALDESC,ECUVALDESC,KOGEN,CANTMIN,TIPOTRAT,RANGOS,INCLUYENVV,TGRANEL,GETDATE(),'" & FUNCIONARIO & "',1 
From MAEERES 
Where CODIGO = '" & _Codigo & "'" & vbCrLf

        End If

        Consulta_sql += "Delete From MAEERES Where CODIGO = '" & _Codigo & "'" & vbCrLf &
                        "Delete From MAEDRES Where CODIGO = '" & _Codigo & "'"

        If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Grabar = True
        Eliminado = True
        MessageBoxEx.Show(Me, "Oferta eliminada correctamente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

    End Sub

    Sub Sb_Grabar_Parametros_SQL(_Actualizar As Boolean)

        _Sql.Sb_Parametro_Informe_Sql(Txt_Listas, "Ofertas_Dinamincas",
                              Txt_Listas.Name, Class_SQLite.Enum_Type._String, Txt_Listas.Text, _Actualizar,, False)

        _Sql.Sb_Parametro_Informe_Sql(Chk_Desc_Lun, "Ofertas_Dinamincas",
                              Chk_Desc_Lun.Name, Class_SQLite.Enum_Type._Boolean, Chk_Desc_Lun.Checked, _Actualizar,, False)

        _Sql.Sb_Parametro_Informe_Sql(Chk_Desc_Mar, "Ofertas_Dinamincas",
                      Chk_Desc_Mar.Name, Class_SQLite.Enum_Type._Boolean, Chk_Desc_Mar.Checked, _Actualizar,, False)

        _Sql.Sb_Parametro_Informe_Sql(Chk_Desc_Mie, "Ofertas_Dinamincas",
                      Chk_Desc_Mie.Name, Class_SQLite.Enum_Type._Boolean, Chk_Desc_Mie.Checked, _Actualizar,, False)

        _Sql.Sb_Parametro_Informe_Sql(Chk_Desc_Jue, "Ofertas_Dinamincas",
                      Chk_Desc_Jue.Name, Class_SQLite.Enum_Type._Boolean, Chk_Desc_Jue.Checked, _Actualizar,, False)

        _Sql.Sb_Parametro_Informe_Sql(Chk_Desc_Vie, "Ofertas_Dinamincas",
                      Chk_Desc_Vie.Name, Class_SQLite.Enum_Type._Boolean, Chk_Desc_Vie.Checked, _Actualizar,, False)

        _Sql.Sb_Parametro_Informe_Sql(Chk_Desc_Sab, "Ofertas_Dinamincas",
                      Chk_Desc_Sab.Name, Class_SQLite.Enum_Type._Boolean, Chk_Desc_Sab.Checked, _Actualizar,, False)

        _Sql.Sb_Parametro_Informe_Sql(Chk_Desc_Dom, "Ofertas_Dinamincas",
                      Chk_Desc_Dom.Name, Class_SQLite.Enum_Type._Boolean, Chk_Desc_Dom.Checked, _Actualizar,, False)

        _Sql.Sb_Parametro_Informe_Sql(Txt_Udad, "Ofertas_Dinamincas",
                              Txt_Udad.Name, Class_SQLite.Enum_Type._String, Txt_Udad.Text, _Actualizar,, False)

    End Sub

End Class
