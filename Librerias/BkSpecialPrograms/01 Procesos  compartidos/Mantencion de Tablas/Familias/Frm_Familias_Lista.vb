Imports BkSpecialPrograms.Bk_Migrar_Producto
Imports DevComponents.DotNetBar

Public Class Frm_Familias_Lista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Tbl As DataTable
    Dim _Dv As New DataView

    Dim _Row_Familia As DataRow
    Dim _No_Cerrar As Boolean

    Dim _Tipo_Vista_Familias As Enum_Tipo_Vista_Familias

    Public Property Kofm As String
    Public Property Kopf As String
    Public Property Kohf As String
    Public Property ModoSeleccion As Boolean

    Public Property Ls_SelSuperFamilias As New List(Of SelSuperFamilias)
    Public Property Ls_SelFamilias As New List(Of SelFamilias)
    Public Property Ls_SelSubFamilias As New List(Of SelSubFamilias)
    Public Property Seleccionados As Boolean
    Public Property ObligaSeleccionar As Boolean = True
    Enum Enum_Tipo_Vista_Familias
        Super_Familias
        Familias
        Sub_Familias
    End Enum

    Public Property Grabar As Boolean

    Public Sub New(_Tipo_Vista_Familias As Enum_Tipo_Vista_Familias)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Tipo_Vista_Familias = _Tipo_Vista_Familias

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then Txt_Descripcion.FocusHighlightEnabled = False
        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Familias_Lista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Btn_Exportar_Excel.Visible = False
        Btn_Sincronizar.Visible = False

        Btn_Crear.Visible = Not ModoSeleccion

        Select Case _Tipo_Vista_Familias
            Case Enum_Tipo_Vista_Familias.Super_Familias
                AddHandler Btn_Crear.Click, AddressOf Sb_Crear_Super_Familias
                Btn_Crear.Text = "Crear Super Familias"
                Me.Text = "SUPER FAMILIAS"
                Lbl_Encabezado.Text = String.Empty
                Btn_Exportar_Excel.Visible = True
                Btn_Sincronizar.Visible = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_DbExt_Conexion", "SincroFamilias = 1"))
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

        If _Global_Row_Configuracion_General.Item("BloqueaFamilias") Then
            RemoveHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
            Btn_Crear.Enabled = False
            Btn_Sincronizar.Enabled = False
            WarningBox.Visible = True
        End If

        Btn_Aceptar.Visible = ModoSeleccion

    End Sub

    Sub Sb_Actualizar_Grilla()

        'Dim _Cadena As String
        Dim _Condicion = String.Empty

        Dim _Campo_Descripcion As String
        Dim _Descripcion As String

        Dim _CampoSelect As String = String.Empty

        Select Case _Tipo_Vista_Familias

            Case Enum_Tipo_Vista_Familias.Super_Familias

                '_Cadena = CADENA_A_BUSCAR(Txt_Descripcion.Text.Trim, "KOFM+NOKOFM LIKE '%")
                '_Condicion = "Where KOFM+NOKOFM LIKE '%" & _Cadena & "%'"

                Consulta_Sql = "Select Cast(0 As Bit) As Chk,* From TABFM " & vbCrLf &
                               "Order By KOFM"

                _Campo_Descripcion = "NOKOFM"
                _Descripcion = "Super Familias"

            Case Enum_Tipo_Vista_Familias.Familias

                '_Cadena = CADENA_A_BUSCAR(Txt_Descripcion.Text.Trim, "Fml.KOPF+Fml.NOKOPF LIKE '%")
                '_Condicion = "Where Fml.KOFM = '" & _Kofm & "' And Fml.KOPF+Fml.NOKOPF LIKE '%" & _Cadena & "%'"

                Consulta_Sql = "Select Cast(0 As Bit) As Chk,Spf.KOFM,Spf.NOKOFM,Fml.KOPF,Fml.NOKOPF From TABPF Fml" & vbCrLf &
                                "Left Join TABFM Spf On Spf.KOFM = Fml.KOFM" & vbCrLf &
                                "Where Fml.KOFM = '" & Kofm & "'" & vbCrLf &
                                "Order By KOPF"

                _Campo_Descripcion = "NOKOPF"
                _Descripcion = "Familias"

            Case Enum_Tipo_Vista_Familias.Sub_Familias

                '_Cadena = CADENA_A_BUSCAR(Txt_Descripcion.Text.Trim, "Sbf.KOHF+Sbf.NOKOHF LIKE '%")
                '_Condicion = "Where Sbf.KOFM = '" & _Kofm & "' And Sbf.KOPF = '" & _Kopf & "' And Sbf.KOHF+Sbf.NOKOHF LIKE '%" & _Cadena & "%'"

                Consulta_Sql = "Select Cast(0 As Bit) As Chk,Spf.KOFM,Spf.NOKOFM,Fml.KOPF,Fml.NOKOPF,Sbf.KOHF,Sbf.NOKOHF From TABHF Sbf" & vbCrLf &
                               "Left Join TABFM Spf On Spf.KOFM = Sbf.KOFM" & vbCrLf &
                               "Left Join TABPF Fml On Fml.KOFM = Sbf.KOFM And Fml.KOPF = Sbf.KOPF" & vbCrLf &
                               "Where Sbf.KOFM = '" & Kofm & "' And Sbf.KOPF = '" & Kopf & "'" & vbCrLf &
                               " Order By KOHF"

                _Campo_Descripcion = "NOKOHF"
                _Descripcion = "Sub Familias"

        End Select

        Dim _New_Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql)
        _Dv = New DataView
        _Dv.Table = _New_Ds.Tables("Table")
        _Tbl = _Dv.Table

        With Grilla

            .DataSource = _Dv

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Chk").Width = 30
            .Columns("Chk").HeaderText = "Sel."
            .Columns("Chk").Visible = ModoSeleccion
            .Columns("Chk").ReadOnly = False
            .Columns("Chk").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

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

        If ModoSeleccion Then
            MarcarSeleccionados()
        End If

    End Sub

    Private Sub Txt_Descripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Descripcion.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Filtrar()
        End If
    End Sub

    Private Sub Txt_Descripcion_TextChanged(sender As Object, e As EventArgs) Handles Txt_Descripcion.TextChanged
        If String.IsNullOrEmpty(Txt_Descripcion.Text.Trim) Then
            Sb_Filtrar()
        End If
    End Sub

    Sub Sb_Filtrar()
        Try
            If IsNothing(_Dv) Then Return

            Select Case _Tipo_Vista_Familias
                Case Enum_Tipo_Vista_Familias.Super_Familias
                    _Dv.RowFilter = String.Format("KOFM+NOKOFM Like '%{0}%'", Txt_Descripcion.Text.Trim)
                Case Enum_Tipo_Vista_Familias.Familias
                    _Dv.RowFilter = String.Format("KOFM+KOPF+NOKOPF Like '%{0}%'", Txt_Descripcion.Text.Trim)
                Case Enum_Tipo_Vista_Familias.Sub_Familias
                    _Dv.RowFilter = String.Format("KOFM+KOPF+KOHF+NOKOHF Like '%{0}%'", Txt_Descripcion.Text.Trim)
            End Select

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Cuek!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Excel.Click

        Consulta_Sql = "Select Spfm.KOFM,Spfm.NOKOFM,Isnull(Fmla.KOPF,'') As KOPF,Isnull(Fmla.NOKOPF,'') As NOKOPF,Isnull(Sbfm.KOHF,'') As KOHF,Isnull(Sbfm.NOKOHF,'') As NOKOHF, 
	                   Rtrim(Ltrim(Spfm.NOKOFM))+ Case When Fmla.NOKOPF Is Null Then '' Else ' - '+Rtrim(Ltrim(Fmla.NOKOPF)) End+
                       Case When Sbfm.NOKOHF Is Null Then '' Else ' - '+Rtrim(Ltrim(Sbfm.NOKOHF)) End As 'Localidad'	
                       From TABFM Spfm 
                       Left Join TABPF Fmla On Fmla.KOFM = Spfm.KOFM 
                       Left Join TABHF Sbfm On Sbfm.KOFM = Fmla.KOFM And Fmla.KOPF = Sbfm.KOPF
                       Order By Spfm.KOFM,Fmla.NOKOPF,NOKOHF"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

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

        Dim _Chk As Boolean = _Fila.Cells("Chk").Value

        Dim _Kofm = _Fila.Cells("KOFM").Value.ToString.Trim
        Dim _Kopf = String.Empty
        Dim _Kohf = String.Empty
        Dim _ObligaSeleccionar As Boolean = Not _Chk

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
        Fm.ModoSeleccion = ModoSeleccion
        Fm.ObligaSeleccionar = _ObligaSeleccionar
        Fm.Kofm = _Kofm
        Fm.Kopf = _Kopf
        Fm.Text = _Texto

        Fm.Ls_SelSuperFamilias = Ls_SelSuperFamilias
        Fm.Ls_SelFamilias = Ls_SelFamilias
        Fm.Ls_SelSubFamilias = Ls_SelSubFamilias

        Fm.ShowDialog(Me)

        If Fm.Seleccionados Then

            Select Case _Tipo_Vista_Familias
                Case Enum_Tipo_Vista_Familias.Super_Familias

                    Ls_SelSuperFamilias = Fm.Ls_SelSuperFamilias
                    Ls_SelFamilias = Fm.Ls_SelFamilias

                    If Not _Chk And Fm.Ls_SelFamilias.Any(Function(sf) sf.Kofm = _Kofm) Then
                        Dim _SelSuperFamilias As New SelSuperFamilias
                        _SelSuperFamilias.Kofm = _Kofm
                        _SelSuperFamilias.Nokofm = _Fila.Cells("NOKOFM").Value.ToString.Trim
                        Ls_SelSuperFamilias.Add(_SelSuperFamilias)
                        _Fila.Cells("Chk").Value = True
                    End If

                Case Enum_Tipo_Vista_Familias.Familias

                    Ls_SelFamilias = Fm.Ls_SelFamilias

                    If Not _Chk And Fm.Ls_SelSubFamilias.Any(Function(sf) sf.Kofm = _Kofm AndAlso sf.Kopf = _Kopf) Then
                        Dim _SelFamilias As New SelFamilias
                        _SelFamilias.Kofm = _Kofm
                        _SelFamilias.Kopf = _Kopf
                        _SelFamilias.Nokopf = _Fila.Cells("NOKOPF").Value.ToString.Trim
                        Ls_SelFamilias.Add(_SelFamilias)
                        _Fila.Cells("Chk").Value = True
                    End If

                Case Enum_Tipo_Vista_Familias.Sub_Familias
                    Ls_SelSubFamilias = Fm.Ls_SelSubFamilias
            End Select

        End If

        Fm.Dispose()

        If Not ModoSeleccion Then
            Txt_Descripcion.Text = String.Empty
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Sub Sb_Crear_Super_Familias()

        Dim Fm As New Frm_Crear_SpfmFmSbfm(Frm_Crear_SpfmFmSbfm.Enum_Tipo_Familia.Super_Familia)
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            Sb_Actualizar_Grilla()
            Sb_Sincronizar_Bases_Externas()
        End If
        Fm.Dispose()

    End Sub

    Sub Sb_Crear_Familias()

        Dim Fm As New Frm_Crear_SpfmFmSbfm(Frm_Crear_SpfmFmSbfm.Enum_Tipo_Familia.Familia)
        Fm.Kofm = _Kofm
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            Sb_Actualizar_Grilla()
            Sb_Sincronizar_Bases_Externas()
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
            Sb_Sincronizar_Bases_Externas()
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

                Sb_Sincronizar_Bases_Externas()

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
                Sb_Sincronizar_Bases_Externas()

            End If

        End If

    End Sub

    Private Sub Btn_Edit_Comuna_Click(sender As Object, e As EventArgs) Handles Btn_Edit_SubFamilia.Click

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
                Sb_Sincronizar_Bases_Externas()

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
                Sb_Sincronizar_Bases_Externas()

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
                Sb_Sincronizar_Bases_Externas()
            End If

        End If

    End Sub

    Private Sub Btn_Elim_Comuna_Click(sender As Object, e As EventArgs) Handles Btn_Elim_SubFamilia.Click

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
                Sb_Sincronizar_Bases_Externas()

            End If

        End If

    End Sub

    Private Sub Frm_Familias_Lista_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Sub Sb_Sincronizar_Bases_Externas()

        Dim _Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Conexion Where SincroTblFamilias = 1"
        Dim _Tbl_Conexiones As DataTable = _Sql.Fx_Get_DataTable(_Consulta_sql)

        If _Tbl_Conexiones.Rows.Count Then

            Dim _SqlQuerySel, _SqlQueryDel, _SqlQueryIns As String

            Select Case _Tipo_Vista_Familias
                Case Enum_Tipo_Vista_Familias.Super_Familias

                    _SqlQuerySel = "Select * From TABFM"
                    _SqlQueryDel = "Truncate Table TABFM"

                Case Enum_Tipo_Vista_Familias.Familias

                    _SqlQuerySel = "Select KOPF,NOKOPF From TABPF Where KOFM = '" & _Kofm & "'"
                    _SqlQueryDel = "Delete TABPF Where KOFM = '" & _Kofm & "'"

                Case Enum_Tipo_Vista_Familias.Sub_Familias

                    _SqlQuerySel = "Select KOHF,NOKOHF From TABHF Where KOFM = '" & _Kofm & "' And KOPF = '" & _Kopf & "'"
                    _SqlQueryDel = "Delete TABHF Where KOFM = '" & _Kofm & "' And KOPF = '" & _Kopf & "'"

            End Select


            Dim _Cl_ConexionExterna As New Cl_ConexionExterna
            Dim _Conexion As New ConexionExternas

            Dim _Tabla1 As DataTable = _Sql.Fx_Get_DataTable(_SqlQuerySel)

            For Each _FilaCx As DataRow In _Tbl_Conexiones.Rows

                Dim _Id_Conexion As Integer = _FilaCx.Item("Id")
                _Conexion = _Cl_ConexionExterna.Fx_CadenaConexionServExt(_Id_Conexion)

                If _Conexion.EsCorrecto Then

                    Dim _Sql2 As New Class_SQL(_Conexion.Cadena_ConexionSQL_Server_Ext)

                    _SqlQueryIns = String.Empty

                    For Each _Fila As DataRow In _Tabla1.Rows

                        Dim _V1 = _Fila.Item(0)
                        Dim _V2 = _Fila.Item(1).ToString.Trim

                        Select Case _Tipo_Vista_Familias
                            Case Enum_Tipo_Vista_Familias.Super_Familias
                                _SqlQueryIns += "Insert Into TABFM (KOFM,NOKOFM) Values ('" & _V1 & "','" & _V2 & "')" & vbCrLf
                            Case Enum_Tipo_Vista_Familias.Familias
                                _SqlQueryIns += "Insert Into TABPF (KOFM,KOPF,NOKOPF) Values ('" & _Kofm & "','" & _V1 & "','" & _V2 & "')" & vbCrLf
                            Case Enum_Tipo_Vista_Familias.Sub_Familias
                                _SqlQueryIns += "Insert Into TABHF (KOFM,KOPF,KOHF,NOKOHF) Values ('" & _Kofm & "','" & _Kopf & "','" & _V1 & "','" & _V2 & "')" & vbCrLf
                        End Select

                    Next

                    Consulta_Sql = _SqlQueryDel & vbCrLf & _SqlQueryIns

                    If _Sql2.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then
                        MessageBoxEx.Show(Me, "Datos actualizado en la base de datos externa" & vbCrLf & vbCrLf &
                                          "Base de dato: " & _FilaCx.Item("BaseDeDatos"), "Sincronización base externa",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBoxEx.Show(Me, "Error al actualizar la base de datos externa" & vbCrLf & vbCrLf &
                                          "Base de dato: " & _FilaCx.Item("BaseDeDatos") & vbCrLf &
                                          _Sql2.Pro_Error, "Sincronización base externa",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                End If

            Next

        End If

    End Sub

    Sub Sb_Sincronizar_Bases_Externas_Todo()

        Dim _Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Conexion Where SincroFamilias = 1"
        Dim _Tbl_Conexiones As DataTable = _Sql.Fx_Get_DataTable(_Consulta_sql)

        If _Tbl_Conexiones.Rows.Count Then

            Dim _SqlQuerySel, _SqlQueryDel, _SqlQueryIns As String

            Dim _Cl_ConexionExterna As New Cl_ConexionExterna
            Dim _Conexion As New ConexionExternas

            For Each _FilaCx As DataRow In _Tbl_Conexiones.Rows

                Dim _Id_Conexion As Integer = _FilaCx.Item("Id")
                _Conexion = _Cl_ConexionExterna.Fx_CadenaConexionServExt(_Id_Conexion)

                If _Conexion.EsCorrecto Then

                    Dim _Sql2 As New Class_SQL(_Conexion.Cadena_ConexionSQL_Server_Ext)

                    _SqlQueryIns = String.Empty

                    _SqlQuerySel = "Select * From TABFM"
                    Dim _Tabfm As DataTable = _Sql.Fx_Get_DataTable(_SqlQuerySel)

                    For Each _Fila As DataRow In _Tabfm.Rows

                        Dim _V1 = _Fila.Item(0)
                        Dim _V2 = _Fila.Item(1).ToString.Trim

                        _SqlQueryIns += "Insert Into TABFM (KOFM,NOKOFM) Values ('" & _V1 & "','" & _V2 & "')" & vbCrLf

                    Next

                    _SqlQueryIns += vbCrLf

                    _SqlQuerySel = "Select * From TABPF"
                    Dim _Tabpf As DataTable = _Sql.Fx_Get_DataTable(_SqlQuerySel)

                    For Each _Fila As DataRow In _Tabpf.Rows

                        Dim _V1 = _Fila.Item(0)
                        Dim _V2 = _Fila.Item(1)
                        Dim _V3 = _Fila.Item(2).ToString.Trim

                        _SqlQueryIns += "Insert Into TABPF (KOFM,KOPF,NOKOPF) Values ('" & _V1 & "','" & _V2 & "','" & _V3 & "')" & vbCrLf

                    Next

                    _SqlQueryIns += vbCrLf

                    _SqlQuerySel = "Select * From TABHF"
                    Dim _Tabhf As DataTable = _Sql.Fx_Get_DataTable(_SqlQuerySel)

                    For Each _Fila As DataRow In _Tabhf.Rows

                        Dim _V1 = _Fila.Item(0)
                        Dim _V2 = _Fila.Item(1)
                        Dim _V3 = _Fila.Item(2)
                        Dim _V4 = _Fila.Item(3).ToString.Trim

                        _SqlQueryIns += "Insert Into TABHF (KOFM,KOPF,KOHF,NOKOHF) Values ('" & _V1 & "','" & _V2 & "','" & _V3 & "','" & _V4 & "')" & vbCrLf

                    Next

                    _SqlQueryDel = "Truncate Table TABFM" & vbCrLf &
                                   "Truncate Table TABPF" & vbCrLf &
                                   "Truncate Table TABHF" & vbCrLf

                    Consulta_Sql = _SqlQueryDel & vbCrLf & _SqlQueryIns

                    If _Sql2.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then
                        MessageBoxEx.Show(Me, "Datos actualizado en la base de datos externa" & vbCrLf & vbCrLf &
                                          "Base de dato: " & _FilaCx.Item("BaseDeDatos"), "Sincronización base externa",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBoxEx.Show(Me, "Error al actualizar la base de datos externa" & vbCrLf & vbCrLf &
                                          "Base de dato: " & _FilaCx.Item("BaseDeDatos") & vbCrLf &
                                          _Sql2.Pro_Error, "Sincronización base externa",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                End If

            Next

        End If

    End Sub

    Private Sub Btn_Sincronizar_Click(sender As Object, e As EventArgs) Handles Btn_Sincronizar.Click
        Sb_Sincronizar_Bases_Externas_Todo()
    End Sub

    Private Sub WarningBox_OptionsClick(sender As Object, e As EventArgs) Handles WarningBox.OptionsClick
        MessageBoxEx.Show(Me, "La tabla se encuentra bloqueada para creación/edición/eliminación de registros." & vbCrLf &
                          "Esta configuración se obtiene de la configuración general.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click

        If ObligaSeleccionar Then

            Select Case _Tipo_Vista_Familias
                Case Enum_Tipo_Vista_Familias.Super_Familias
                    If Ls_SelSuperFamilias.Count = 0 Then
                        MessageBoxEx.Show(Me, "Debe seleccionar al menos una Super Familia", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If
                Case Enum_Tipo_Vista_Familias.Familias
                    If Ls_SelFamilias.Count = 0 Then
                        MessageBoxEx.Show(Me, "Debe seleccionar al menos una Familia", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If
                Case Enum_Tipo_Vista_Familias.Sub_Familias
                    If Ls_SelSubFamilias.Count = 0 Then
                        MessageBoxEx.Show(Me, "Debe seleccionar al menos una Sub Familia", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If
            End Select

        End If

        Seleccionados = True
        Ls_SelSuperFamilias = Ls_SelSuperFamilias.Distinct().ToList()
        Ls_SelFamilias = Ls_SelFamilias.Distinct().ToList()
        Ls_SelSubFamilias = Ls_SelSubFamilias.Distinct().ToList()
        Me.Close()

    End Sub

    Private Function ObtenerKofmSelSuperFamilias() As String
        Dim kofmString As String = ""
        For Each selSuperFamilia As SelSuperFamilias In Ls_SelSuperFamilias
            kofmString += "'" & selSuperFamilia.Kofm & "',"
        Next
        kofmString = kofmString.TrimEnd(",")
        Return kofmString
    End Function

    Private Function ObtenerKofmSelSelFamilias() As String
        Dim kofmkopfString As String = ""
        For Each selFamilia As SelFamilias In Ls_SelFamilias
            kofmkopfString += "'" & selFamilia.Kofm & selFamilia.Kopf & "',"
        Next
        kofmkopfString = kofmkopfString.TrimEnd(",")
        Return kofmkopfString
    End Function

    Private Function ObtenerKofmSelSelSelSubFamilias() As String
        Dim kofmkopfkohfString As String = ""
        For Each selSubFamilia As SelSubFamilias In Ls_SelSubFamilias
            kofmkopfkohfString += "'" & selSubFamilia.Kofm & selSubFamilia.Kopf & selSubFamilia.Kohf & "',"
        Next
        kofmkopfkohfString = kofmkopfkohfString.TrimEnd(",")
        Return kofmkopfkohfString
    End Function

    Private Sub MarcarSeleccionados()
        For Each fila As DataRow In _Tbl.Rows
            Dim valor As String = fila("KOFM").ToString().Trim()
            Dim encontrado As Boolean = False

            Select Case _Tipo_Vista_Familias
                Case Enum_Tipo_Vista_Familias.Super_Familias
                    encontrado = Ls_SelSuperFamilias.Any(Function(x) x.Kofm = valor)
                Case Enum_Tipo_Vista_Familias.Familias
                    Dim kopf As String = fila("KOPF").ToString().Trim()
                    encontrado = Ls_SelFamilias.Any(Function(x) x.Kofm = valor AndAlso x.Kopf = kopf)
                Case Enum_Tipo_Vista_Familias.Sub_Familias
                    Dim kopf As String = fila("KOPF").ToString().Trim()
                    Dim kohf As String = fila("KOHF").ToString().Trim()
                    encontrado = Ls_SelSubFamilias.Any(Function(x) x.Kofm = valor AndAlso x.Kopf = kopf AndAlso x.Kohf = kohf)
            End Select

            fila("Chk") = encontrado
        Next
    End Sub

    Private Sub Grilla_MouseUp(sender As Object, e As MouseEventArgs) Handles Grilla.MouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Grilla_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEndEdit

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Cabeza As String = Grilla.Columns(e.ColumnIndex).Name

        Dim _Chk As Boolean = _Fila.Cells("Chk").Value
        Dim _Kofm As String = _Fila.Cells("KOFM").Value
        Dim _Kopf As String = String.Empty
        Dim _Kohf As String = String.Empty

        If _Cabeza = "Chk" Then

            Select Case _Tipo_Vista_Familias

                Case Enum_Tipo_Vista_Familias.Super_Familias

                    If _Chk Then
                        Dim _SelSuperFamilias As New SelSuperFamilias
                        _SelSuperFamilias.Kofm = _Kofm
                        _SelSuperFamilias.Nokofm = _Fila.Cells("NOKOFM").Value.ToString.Trim
                        Ls_SelSuperFamilias.Add(_SelSuperFamilias)
                    Else
                        Ls_SelSuperFamilias.RemoveAll(Function(sf) sf.Kofm = _Kofm)
                        Ls_SelFamilias.RemoveAll(Function(sf) sf.Kofm = _Kofm)
                        Ls_SelSubFamilias.RemoveAll(Function(sf) sf.Kofm = _Kofm)
                    End If

                Case Enum_Tipo_Vista_Familias.Familias

                    _Kopf = _Fila.Cells("KOPF").Value.ToString.Trim

                    If _Chk Then
                        Dim _SelFamilias As New SelFamilias
                        _SelFamilias.Kofm = _Kofm
                        _SelFamilias.Kopf = _Kopf
                        _SelFamilias.Nokopf = _Fila.Cells("NOKOPF").Value.ToString.Trim
                        Ls_SelFamilias.Add(_SelFamilias)
                    Else
                        Ls_SelFamilias.RemoveAll(Function(sf) sf.Kofm = _Kofm AndAlso sf.Kopf = _Kopf)
                        Ls_SelSubFamilias.RemoveAll(Function(sf) sf.Kofm = _Kofm AndAlso sf.Kopf = _Kopf)
                    End If

                Case Enum_Tipo_Vista_Familias.Sub_Familias

                    _Kopf = _Fila.Cells("KOPF").Value.ToString.Trim
                    _Kohf = _Fila.Cells("KOHF").Value.ToString.Trim

                    If _Chk Then
                        Dim _SelSubFamilias As New SelSubFamilias
                        _SelSubFamilias.Kofm = _Kofm
                        _SelSubFamilias.Kopf = _Kopf
                        _SelSubFamilias.Kohf = _Kohf
                        _SelSubFamilias.Nokohf = _Fila.Cells("NOKOHF").Value.ToString.Trim
                        Ls_SelSubFamilias.Add(_SelSubFamilias)
                    Else
                        Ls_SelSubFamilias.RemoveAll(Function(sf) sf.Kofm = _Kofm AndAlso sf.Kopf = _Kopf AndAlso sf.Kohf = _Kohf)
                    End If

            End Select

        End If

    End Sub

    Private Sub Chk_Seleccionar_Todos_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Seleccionar_Todos.CheckedChanged
        For Each _Fila As DataGridViewRow In Grilla.Rows
            _Fila.Cells("Chk").Value = Chk_Seleccionar_Todos.Checked
        Next
    End Sub
End Class

Public Class SelSuperFamilias

    Public Property Kofm As String
    Public Property Nokofm As String

End Class

Public Class SelFamilias

    Public Property Kofm As String
    Public Property Kopf As String
    Public Property Nokopf As String

End Class

Public Class SelSubFamilias

    Public Property Kofm As String
    Public Property Kopf As String
    Public Property Kohf As String
    Public Property Nokohf As String

End Class
