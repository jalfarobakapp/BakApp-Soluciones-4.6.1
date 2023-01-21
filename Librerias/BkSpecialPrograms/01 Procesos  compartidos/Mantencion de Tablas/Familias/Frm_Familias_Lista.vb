Imports DevComponents.DotNetBar

Public Class Frm_Familias_Lista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Dv As New DataView

    Dim _Row_Familia As DataRow
    Dim _No_Cerrar As Boolean

    Dim _Kofm As String
    Dim _Kopf As String
    Dim _kohf As String

    Dim _Tipo_Vista_Familias As Enum_Tipo_Vista_Familias

    Public Property Kofm As String
        Get
            Return _Kofm
        End Get
        Set(value As String)
            _Kofm = value
        End Set
    End Property

    Public Property Kopf As String
        Get
            Return _Kopf
        End Get
        Set(value As String)
            _Kopf = value
        End Set
    End Property

    Public Property Kohf As String
        Get
            Return _kohf
        End Get
        Set(value As String)
            _kohf = value
        End Set
    End Property

    Enum Enum_Tipo_Vista_Familias
        Super_Familias
        Familias
        Sub_Familias
    End Enum

    Public Sub New(_Tipo_Vista_Familias As Enum_Tipo_Vista_Familias)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Tipo_Vista_Familias = _Tipo_Vista_Familias

        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then Txt_Descripcion.FocusHighlightEnabled = False
        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Familias_Lista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Btn_Exportar_Excel.Visible = False

        Select Case _Tipo_Vista_Familias
            Case Enum_Tipo_Vista_Familias.Super_Familias
                AddHandler Btn_Crear.Click, AddressOf Sb_Crear_Super_Familias
                Btn_Crear.Text = "Crear Super Familias"
                Me.Text = "SUPER FAMILIAS"
                Lbl_Encabezado.Text = String.Empty
                Btn_Exportar_Excel.Visible = True
            Case Enum_Tipo_Vista_Familias.Familias
                AddHandler Btn_Crear.Click, AddressOf Sb_Crear_Familias
                Btn_Crear.Text = "Crear Familias"
                Me.Top += 20
                Me.Left += 20
                Dim _Super_Familia = _Sql.Fx_Trae_Dato("TABFM", "NOKOFM", "KOFM = '" & _Kofm & "'").ToString.Trim
                Me.Text = "FAMILIAS"
                Lbl_Encabezado.Text = "Super Familia: " & _Super_Familia
            Case Enum_Tipo_Vista_Familias.Sub_Familias
                AddHandler Btn_Crear.Click, AddressOf Sb_Crear_Sub_Familias
                Btn_Crear.Text = "Crear Sub-Familias"
                Me.Top += 40
                Me.Left += 40
                Dim _Super_Familia = _Sql.Fx_Trae_Dato("TABFM", "NOKOFM", "KOFM = '" & _Kofm & "'").ToString.Trim
                Dim _Familia = _Sql.Fx_Trae_Dato("TABPF", "NOKOPF", "KOFM = '" & _Kofm & "' And KOPF = '" & _Kopf & "'").ToString.Trim
                Me.Text = "SUB FAMILIAS"
                Lbl_Encabezado.Text = "Supere Familia: " & _Super_Familia & ", Familia: " & _Familia
        End Select

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Cadena As String
        Dim _Condicion = String.Empty

        Dim _Campo_Descripcion As String
        Dim _Descripcion As String

        Select Case _Tipo_Vista_Familias
            Case Enum_Tipo_Vista_Familias.Super_Familias

                _Cadena = CADENA_A_BUSCAR(Txt_Descripcion.Text.Trim, "KOFM+NOKOFM LIKE '%")
                _Condicion = "Where KOFM+NOKOFM LIKE '%" & _Cadena & "%'"
                Consulta_Sql = "Select * From TABFM " & _Condicion & " Order By KOFM"
                _Campo_Descripcion = "NOKOFM"
                _Descripcion = "Super Familias"

            Case Enum_Tipo_Vista_Familias.Familias

                _Cadena = CADENA_A_BUSCAR(Txt_Descripcion.Text.Trim, "Fml.KOPF+Fml.NOKOPF LIKE '%")
                _Condicion = "Where Fml.KOFM = '" & _Kofm & "' And Fml.KOPF+Fml.NOKOPF LIKE '%" & _Cadena & "%'"

                Consulta_Sql = "Select Spf.KOFM,Spf.NOKOFM,Fml.KOPF,Fml.NOKOPF From TABPF Fml
                                Left Join TABFM Spf On Spf.KOFM = Fml.KOFM" & vbCrLf &
                                _Condicion & " Order By KOPF"

                _Campo_Descripcion = "NOKOPF"
                _Descripcion = "Familias"

            Case Enum_Tipo_Vista_Familias.Sub_Familias

                _Cadena = CADENA_A_BUSCAR(Txt_Descripcion.Text.Trim, "Sbf.KOHF+Sbf.NOKOHF LIKE '%")
                _Condicion = "Where Sbf.KOFM = '" & _Kofm & "' And Sbf.KOPF = '" & _Kopf & "' And Sbf.KOHF+Sbf.NOKOHF LIKE '%" & _Cadena & "%'"

                Consulta_Sql = "Select Spf.KOFM,Spf.NOKOFM,Fml.KOPF,Fml.NOKOPF,Sbf.KOHF,Sbf.NOKOHF From TABHF Sbf
                                Left Join TABFM Spf On Spf.KOFM = Sbf.KOFM
                                Left Join TABPF Fml On Fml.KOFM = Sbf.KOFM And Fml.KOPF = Sbf.KOPF" & vbCrLf &
                                _Condicion & " Order By KOHF"

                _Campo_Descripcion = "NOKOHF"
                _Descripcion = "Sub Familias"

        End Select


        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        With Grilla

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("KOFM").Width = 40
            .Columns("KOFM").HeaderText = "SUPF"
            .Columns("KOFM").ReadOnly = True
            .Columns("KOFM").Visible = True
            .Columns("KOFM").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns(_Campo_Descripcion).Width = 380 + 40 + 40

            If _Tipo_Vista_Familias = Enum_Tipo_Vista_Familias.Familias Or _Tipo_Vista_Familias = Enum_Tipo_Vista_Familias.Sub_Familias Then
                .Columns("KOPF").Width = 40
                .Columns("KOPF").HeaderText = "FAMI"
                .Columns("KOPF").ReadOnly = True
                .Columns("KOPF").Visible = True
                .Columns("KOPF").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1
                .Columns(_Campo_Descripcion).Width = 380 + 40
            End If

            If _Tipo_Vista_Familias = Enum_Tipo_Vista_Familias.Sub_Familias Then
                .Columns("KOHF").Width = 40
                .Columns("KOHF").HeaderText = "SUBF"
                .Columns("KOHF").ReadOnly = True
                .Columns("KOHF").Visible = True
                .Columns("KOHF").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1
                .Columns(_Campo_Descripcion).Width = 380
            End If

            .Columns(_Campo_Descripcion).HeaderText = _Descripcion
            .Columns(_Campo_Descripcion).ReadOnly = True
            .Columns(_Campo_Descripcion).Visible = True

        End With

    End Sub

    Private Sub Txt_Descripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Descripcion.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Txt_Descripcion_TextChanged(sender As Object, e As EventArgs) Handles Txt_Descripcion.TextChanged
        If String.IsNullOrEmpty(Txt_Descripcion.Text.Trim) Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Excel.Click

        Consulta_Sql = "Select Spfm.KOFM,Spfm.NOKOFM,Isnull(Fmla.KOPF,'') As KOPF,Isnull(Fmla.NOKOPF,'') As NOKOPF,Isnull(Sbfm.KOHF,'') As KOHF,Isnull(Sbfm.NOKOHF,'') As NOKOHF, 
	                   Rtrim(Ltrim(Spfm.NOKOFM))+ Case When Fmla.NOKOPF Is Null Then '' Else ' - '+Rtrim(Ltrim(Fmla.NOKOPF)) End+
                       Case When Sbfm.NOKOHF Is Null Then '' Else ' - '+Rtrim(Ltrim(Sbfm.NOKOHF)) End As 'Localidad'	
                       From TABFM Spfm 
                       Left Join TABPF Fmla On Fmla.KOFM = Spfm.KOFM 
                       Left Join TABHF Sbfm On Sbfm.KOFM = Fmla.KOFM And Fmla.KOPF = Sbfm.KOPF
                       Order By Spfm.KOFM,Fmla.NOKOPF,NOKOHF"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Pais_Cuidas_Comunas")

    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown

        If CBool(Grilla.RowCount) Then

            Dim _Key As Keys = e.KeyValue

            Select Case _Key

                Case Keys.Enter

                    SendKeys.Send("{LEFT}")
                    e.Handled = True
                    Call Grilla_CellDoubleClick(Nothing, Nothing)

            End Select

        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Kofm = _Fila.Cells("KOFM").Value.ToString.Trim
        Dim _Kopf = String.Empty
        Dim _Kohf = String.Empty

        Dim _vTipo_Vista_Familias As Enum_Tipo_Vista_Familias
        Dim _Texto As String

        Select Case _Tipo_Vista_Familias
            Case Enum_Tipo_Vista_Familias.Super_Familias
                _Kofm = _Fila.Cells("KOFM").Value.ToString.Trim
                _Texto = "FAMILIAS (SupF: " & _Fila.Cells("NOKOFM").Value.ToString.Trim
                _vTipo_Vista_Familias = Enum_Tipo_Vista_Familias.Familias
            Case Enum_Tipo_Vista_Familias.Familias
                _Kofm = _Fila.Cells("KOFM").Value.ToString.Trim
                _Kopf = _Fila.Cells("KOPF").Value.ToString.Trim
                _vTipo_Vista_Familias = Enum_Tipo_Vista_Familias.Sub_Familias
            Case Enum_Tipo_Vista_Familias.Sub_Familias
                Return
        End Select

        Dim Fm As New Frm_Familias_Lista(_vTipo_Vista_Familias)
        Fm.Kofm = _Kofm
        Fm.Kopf = _Kopf
        Fm.Text = _Texto
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Txt_Descripcion.Text = String.Empty
        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Crear_Super_Familias()

        Dim Fm As New Frm_Crear_SpfmFmSbfm(Frm_Crear_SpfmFmSbfm.Enum_Tipo_Familia.Super_Familia)
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            Sb_Actualizar_Grilla()
        End If
        Fm.Dispose()

    End Sub

    Sub Sb_Crear_Familias()

        Dim Fm As New Frm_Crear_SpfmFmSbfm(Frm_Crear_SpfmFmSbfm.Enum_Tipo_Familia.Familia)
        Fm.Kofm = _Kofm
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            Sb_Actualizar_Grilla()
        End If
        Fm.Dispose()

    End Sub

    Sub Sb_Crear_Sub_Familias()

        Dim Fm As New Frm_Crear_SpfmFmSbfm(Frm_Crear_SpfmFmSbfm.Enum_Tipo_Familia.Sub_Familia)
        Fm.Kofm = _Kofm
        Fm.Kopf = _Kopf
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            Sb_Actualizar_Grilla()
        End If
        Fm.Dispose()

    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            Dim Hitest As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)

            If Hitest.Type = DataGridViewHitTestType.Cell Then

                sender.CurrentCell = sender.Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

                Select Case _Tipo_Vista_Familias
                    Case Enum_Tipo_Vista_Familias.Super_Familias
                        ShowContextMenu(Menu_Contextual_Super_Familia)
                    Case Enum_Tipo_Vista_Familias.Familias
                        ShowContextMenu(Menu_Contextual_Familia)
                    Case Enum_Tipo_Vista_Familias.Sub_Familias
                        ShowContextMenu(Menu_Contextual_Sub_Familia)
                End Select

            End If

        End If

    End Sub

    Private Sub Btn_Edit_Super_Familia_Click(sender As Object, e As EventArgs) Handles Btn_Edit_Super_Familia.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Kofm = _Fila.Cells("KOFM").Value
        Dim _Nokofm = _Fila.Cells("NOKOFM").Value.ToString.Trim

        Dim _Aceptar As Boolean = InputBox_Bk(Me, "Nombre de la Super Familia", "Super Familia", _Nokofm, False,, 30, True)

        If _Aceptar Then

            Consulta_Sql = "Update TABFM Set NOKOFM = '" & _Nokofm & "' Where KOFM = '" & _Kofm & "'"

            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

                Dim _Localidad = _Nokofm.ToString.Trim
                Txt_Descripcion.Text = String.Empty
                Sb_Actualizar_Grilla()

                BuscarDatoEnGrilla(_Localidad, "Localidad", Grilla)

                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Super Familia", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If

    End Sub

    Private Sub Btn_Edit_Familia_Click(sender As Object, e As EventArgs) Handles Btn_Edit_Familia.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Kofm = _Fila.Cells("KOFM").Value
        Dim _Kopf = _Fila.Cells("KOPF").Value
        Dim _Nokofm = _Fila.Cells("NOKOFM").Value.ToString.Trim
        Dim _Nokopf = _Fila.Cells("NOKOPF").Value.ToString.Trim

        Dim _Aceptar As Boolean = InputBox_Bk(Me, "Nombre de la Familia", "Familia", _Nokopf, False,, 30, True)

        If _Aceptar Then

            Consulta_Sql = "Update TABPF Set NOKOPF = '" & _Nokopf & "' Where KOFM = '" & _Kofm & "' And KOPF = '" & _Kopf & "'"

            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

                Dim _Localidad = _Nokofm.ToString.Trim & " - " & _Nokopf.ToString.Trim
                Txt_Descripcion.Text = String.Empty
                Sb_Actualizar_Grilla()

                BuscarDatoEnGrilla(_Localidad, "Localidad", Grilla)

                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Ciudad/Región", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub

    Private Sub Btn_Edit_Comuna_Click(sender As Object, e As EventArgs) Handles Btn_Edit_Comuna.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Kofm = _Fila.Cells("KOFM").Value
        Dim _Kopf = _Fila.Cells("KOPF").Value
        Dim _Kohf = _Fila.Cells("KOHF").Value
        Dim _Nokofm = _Fila.Cells("NOKOFM").Value.ToString.Trim
        Dim _Nokopf = _Fila.Cells("NOKOPF").Value.ToString.Trim
        Dim _Nokohf = _Fila.Cells("NOKOHF").Value.ToString.Trim

        Dim _Aceptar As Boolean = InputBox_Bk(Me, "Nombre de la Sub-Familia", "Sub-Familia", _Nokohf, False,, 30, True)

        If _Aceptar Then

            Consulta_Sql = "Update TABHF Set NOKOHF = '" & _Nokohf & "' Where KOFM = '" & _Kofm & "' And KOPF = '" & _Kopf & "' And KOHF = '" & _Kohf & "'"

            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

                Dim _Localidad = _Nokofm.ToString.Trim & " - " & _Nokopf.ToString.Trim & " - " & _Nokohf.ToString.Trim
                Txt_Descripcion.Text = String.Empty
                Sb_Actualizar_Grilla()

                BuscarDatoEnGrilla(_Localidad, "Localidad", Grilla)

                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Comuna", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub

    Private Sub Btn_Elim_Familia_Click(sender As Object, e As EventArgs) Handles Btn_Elim_Familia.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Kopf = _Fila.Cells("KOPF").Value
        Dim _Nokofm = _Fila.Cells("NOKOFM").Value.ToString.Trim
        Dim _Nokopf = _Fila.Cells("NOKOPF").Value.ToString.Trim

        Dim _Reg As Boolean

        _Reg = CBool(_Sql.Fx_Cuenta_Registros("TABHF", "KOFM = '" & _Kofm & "' And KOPF = '" & _Kopf & "'"))

        If _Reg Then

            MessageBoxEx.Show(Me, "No puede eliminar esta Familia ya que contiene Sub-Familias asociadas" & vbCrLf &
                              "Primero debe eliminar las Sub-Familias asociadas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        _Reg = CBool(_Sql.Fx_Cuenta_Registros("MAEPR", "FMPR = '" & _Kofm & "' And PFPR = '" & _Kopf & "'"))

        If _Reg Then

            If MessageBoxEx.Show(Me, "Esta familia contiene productos asociados" & vbCrLf &
                              "¿Esta seguro de querer eliminar de todas formas?", "Validación",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Stop) <> DialogResult.Yes Then
                Return
            End If

        End If

        If MessageBoxEx.Show(Me, "¿Confirma la eliminación de la Familia " & _Nokofm & "?", "Eliminar Familia",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Consulta_Sql = "Delete TABPF Where KOFM = '" & _Kofm & "' And KOPF = '" & _Kopf & "'"

            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Super Familia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub

    Private Sub Btn_Elim_Super_Familia_Click(sender As Object, e As EventArgs) Handles Btn_Elim_Super_Familia.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Kofm = _Fila.Cells("KOFM").Value
        Dim _Nokofm = _Fila.Cells("NOKOFM").Value

        Dim _Reg As Boolean

        _Reg = CBool(_Sql.Fx_Cuenta_Registros("TABPF", "KOFM = '" & _Kofm & "'"))

        If _Reg Then

            MessageBoxEx.Show(Me, "No puede eliminar esta super familia ya que contiene Familias asociadas" & vbCrLf &
                              "Primero debe eliminar las Familias asociadas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        _Reg = CBool(_Sql.Fx_Cuenta_Registros("MAEPR", "FMPR = '" & _Kofm & "'"))

        If _Reg Then

            If MessageBoxEx.Show(Me, "Esta super familia contiene productos asociados" & vbCrLf &
                              "¿Esta seguro de querer eliminar de todas formas?", "Validación",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Stop) <> DialogResult.Yes Then
                Return
            End If

        End If

        If MessageBoxEx.Show(Me, "¿Confirma la eliminación de la Super Familia " & _Nokofm & "?", "Eliminar Super Familia",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Consulta_Sql = "Delete TABFM Where KOFM = '" & _Kofm & "'"

            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Super Familia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub

    Private Sub Btn_Elim_Comuna_Click(sender As Object, e As EventArgs) Handles Btn_Elim_Comuna.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Kohf = _Fila.Cells("KOHF").Value
        Dim _Nokofm = _Fila.Cells("NOKOFM").Value.ToString.Trim
        Dim _Nokopf = _Fila.Cells("NOKOPF").Value.ToString.Trim

        Dim _Reg As Boolean

        _Reg = CBool(_Sql.Fx_Cuenta_Registros("MAEPR", "FMPR = '" & _Kofm & "' And PFPR = '" & _Kopf & "' And HFPR = '" & _Kohf & "'"))

        If _Reg Then

            If MessageBoxEx.Show(Me, "Esta Sub-Familia contiene productos asociados" & vbCrLf &
                              "¿Esta seguro de querer eliminar de todas formas?", "Validación",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Stop) <> DialogResult.Yes Then
                Return
            End If

        End If

        If MessageBoxEx.Show(Me, "¿Confirma la eliminación de la Sub-Familia " & _Nokofm & "?", "Eliminar Sub-Familia",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Consulta_Sql = "Delete TABHF Where KOFM = '" & _Kofm & "' And KOPF = '" & _Kopf & "' And KOHF = '" & _Kohf & "'"

            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Super Familia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub

    Private Sub Frm_Familias_Lista_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub


End Class
