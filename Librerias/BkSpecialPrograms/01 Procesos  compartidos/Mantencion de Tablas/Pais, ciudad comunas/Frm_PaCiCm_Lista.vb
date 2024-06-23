Imports DevComponents.DotNetBar
Public Class Frm_PaCiCm_Lista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Dv As New DataView

    Dim _Row_Localidad As DataRow
    Dim _No_Cerrar As Boolean

    Public Property Row_Localidad As DataRow
        Get
            Return _Row_Localidad
        End Get
        Set(value As DataRow)
            _Row_Localidad = value
        End Set
    End Property

    Public Property No_Cerrar As Boolean
        Get
            Return _No_Cerrar
        End Get
        Set(value As Boolean)
            _No_Cerrar = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            Txt_Descripcion.FocusHighlightEnabled = False
            BtnAceptar.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_PaCiCm_Lista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

    End Sub
    Sub Sb_Actualizar_Grilla()

        Dim _Cadena As String = CADENA_A_BUSCAR(Txt_Descripcion.Text.Trim, "Pa.NOKOPA+Ci.NOKOCI+Cm.NOKOCM LIKE '%")

        Dim _Condicion = String.Empty

        'If Not String.IsNullOrEmpty(Txt_Descripcion.Text.Trim) Then
        _Condicion = "Where NOKOPA+NOKOCI+NOKOCM LIKE '%" & _Cadena & "%'"
        _Condicion = "Where Pa.NOKOPA Like '%" & _Cadena & "%' Or Ci.NOKOCI Like '%" & _Cadena & "%' Or Cm.NOKOCM Like '%" & _Cadena & "%'"
        'End If

        Consulta_Sql = "Select Pa.KOPA,Pa.NOKOPA,Isnull(Ci.KOCI,'') As KOCI,Isnull(Ci.NOKOCI,'') As NOKOCI,Isnull(Cm.KOCM,'') As KOCM,Isnull(Cm.NOKOCM,'') As NOKOCM, 
	                    Rtrim(Ltrim(Pa.NOKOPA))+ Case When Ci.NOKOCI Is Null Then '' Else ' - '+Rtrim(Ltrim(Ci.NOKOCI)) End+" &
                        "Case When Cm.NOKOCM Is Null Then '' Else ' - '+Rtrim(Ltrim(Cm.NOKOCM)) End As Localidad	
                        From TABPA Pa 
                        Left Join TABCI Ci On Ci.KOPA = Pa.KOPA 
                        Left Join TABCM Cm On Cm.KOPA = Ci.KOPA And Ci.KOCI = Cm.KOCI
                        " & _Condicion & "
                        Order By Pa.KOPA,Ci.NOKOCI,NOKOCM"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        'Dim _New_Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql)

        '_Dv.Table = _New_Ds.Tables(0)

        With Grilla

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("KOPA").Width = 40
            .Columns("KOPA").HeaderText = "PA"
            .Columns("KOPA").ReadOnly = True
            .Columns("KOPA").Visible = True

            .Columns("KOCI").Width = 40
            .Columns("KOCI").HeaderText = "CI"
            .Columns("KOCI").ReadOnly = True
            .Columns("KOCI").Visible = True

            .Columns("KOCM").Width = 50
            .Columns("KOCM").HeaderText = "CM"
            .Columns("KOCM").ReadOnly = True
            .Columns("KOCM").Visible = True

            .Columns("Localidad").Width = 370
            .Columns("Localidad").HeaderText = "Descripción"
            .Columns("Localidad").ReadOnly = True
            .Columns("Localidad").Visible = True

        End With

        Btn_Crear_Ciudad.Enabled = False
        Btn_Crear_Comuna.Enabled = False

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Kopa = _Fila.Cells("KOPA").Value.ToString.Trim
        Dim _Koci = _Fila.Cells("KOCI").Value.ToString.Trim
        Dim _Kocm = _Fila.Cells("KOCM").Value.ToString.Trim

        If String.IsNullOrEmpty(_Kocm) Then
            MessageBoxEx.Show(Me, "Este registro no tiene comuna", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Consulta_Sql = "Select Pa.KOPA,Pa.NOKOPA,Ci.KOCI,Ci.NOKOCI,Cm.KOCM,Cm.NOKOCM,
                        Rtrim(Ltrim(Pa.NOKOPA))+' - '+Rtrim(Ltrim(Ci.NOKOCI))+' - '+Rtrim(Ltrim(Cm.NOKOCM)) As Localidad	
                        From TABCM Cm 
                        Inner Join TABCI Ci On Ci.KOPA = Cm.KOPA And Ci.KOCI = Cm.KOCI
                        Inner Join TABPA Pa On Pa.KOPA = Cm.KOPA
                        Where Pa.KOPA = '" & _Kopa & "' And Ci.KOCI = '" & _Koci & "' And Cm.KOCM = '" & _Kocm & "'"

        _Row_Localidad = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If Not _No_Cerrar Then
            Me.Close()
        End If

    End Sub

    Private Sub Btn_Edit_Pais_Click(sender As Object, e As EventArgs) Handles Btn_Edit_Pais.Click

        If Fx_Tiene_Permiso(Me, "Tbl00047") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Kopa = _Fila.Cells("KOPA").Value
            Dim _Nokopa = _Fila.Cells("NOKOPA").Value.ToString.Trim
            Dim _Nokoci = _Fila.Cells("NOKOCI").Value.ToString.Trim
            Dim _Nokocm = _Fila.Cells("NOKOCM").Value.ToString.Trim

            Dim _Aceptar As Boolean = InputBox_Bk(Me, "Nombre del pais", "Pais", _Nokopa, False,, 30, True)

            If _Aceptar Then

                Consulta_Sql = "Update TABPA Set NOKOPA = '" & _Nokopa & "' Where KOPA = '" & _Kopa & "'"

                If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

                    Dim _Localidad = _Nokopa.ToString.Trim & " - " & _Nokoci.ToString.Trim & " - " & _Nokocm.ToString.Trim
                    Txt_Descripcion.Text = String.Empty
                    Sb_Actualizar_Grilla()

                    BuscarDatoEnGrilla(_Localidad, "Localidad", Grilla)

                    MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Pais", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            End If

        End If

    End Sub

    Private Sub Btn_Elim_Pais_Click(sender As Object, e As EventArgs) Handles Btn_Elim_Pais.Click

        If Fx_Tiene_Permiso(Me, "Tbl00048") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Kopa = _Fila.Cells("KOPA").Value
            Dim _Nokopa = _Fila.Cells("NOKOPA").Value

            Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEEN", "PAEN = '" & _Kopa & "'"))

            If _Reg Then

                MessageBoxEx.Show(Me, "No puede eliminar este pais contiene entidades asociadas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return

            End If

            _Reg = CBool(_Sql.Fx_Cuenta_Registros("TABCI", "KOPA = '" & _Kopa & "'"))

            If _Reg Then

                MessageBoxEx.Show(Me, "No puede eliminar este pais contiene ciudades asociadas" & vbCrLf &
                                  "Primero debe eliminar las ciudades", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return

            End If

            If MessageBoxEx.Show(Me, "¿Confirma la eliminación del pais " & _Nokopa & "?", "Eliminar pais",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Consulta_Sql = "Delete TABPA Where KOPA = '" & _Kopa & "'"

                If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                    Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
                    MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Pais", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If

        End If

    End Sub

    Private Sub Btn_Edit_Ciudad_Click(sender As Object, e As EventArgs) Handles Btn_Edit_Ciudad.Click

        If Fx_Tiene_Permiso(Me, "Tbl00047") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Kopa = _Fila.Cells("KOPA").Value
            Dim _Koci = _Fila.Cells("KOCI").Value
            Dim _Nokopa = _Fila.Cells("NOKOCI").Value
            Dim _Nokoci = _Fila.Cells("NOKOCI").Value.ToString.Trim
            Dim _Nokocm = _Fila.Cells("NOKOCM").Value.ToString.Trim

            Dim _Aceptar As Boolean = InputBox_Bk(Me, "Nombre de la ciudad/región", "Ciudad/Región", _Nokoci, False,, 30, True)

            If _Aceptar Then

                Consulta_Sql = "Update TABCI Set NOKOCI = '" & _Nokoci & "' Where KOPA = '" & _Kopa & "' And KOCI = '" & _Koci & "'"

                If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

                    Dim _Localidad = _Nokopa.ToString.Trim & " - " & _Nokoci.ToString.Trim & " - " & _Nokocm.ToString.Trim
                    Txt_Descripcion.Text = String.Empty
                    Sb_Actualizar_Grilla()

                    BuscarDatoEnGrilla(_Localidad, "Localidad", Grilla)

                    MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Ciudad/Región", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If

        End If

    End Sub

    Private Sub Btn_Elim_Ciudad_Click(sender As Object, e As EventArgs) Handles Btn_Elim_Ciudad.Click

        If Fx_Tiene_Permiso(Me, "Tbl00048") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Kopa = _Fila.Cells("KOPA").Value
            Dim _Koci = _Fila.Cells("KOCI").Value
            Dim _Nokoci = _Fila.Cells("NOKOCI").Value

            Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEEN", "PAEN = '" & _Kopa & "' And CIEN = '" & _Koci & "'"))

            If _Reg Then

                MessageBoxEx.Show(Me, "No puede eliminar esta ciudad/región contiene entidades asociadas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return

            End If

            _Reg = CBool(_Sql.Fx_Cuenta_Registros("TABCM", "KOPA = '" & _Kopa & "' And KOCI = '" & _Koci & "'"))

            If _Reg Then

                MessageBoxEx.Show(Me, "No puede eliminar esta ciudad contiene comunas asociadas" & vbCrLf &
                                  "Primero debe eliminar las comunas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return

            End If

            If MessageBoxEx.Show(Me, "¿Confirma la eliminación de la ciudad/región " & _Nokoci & "?", "Eliminar ciudad/región",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Consulta_Sql = "Delete TABCI Where KOPA = '" & _Kopa & "' And KOCI = '" & _Koci & "'"

                If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                    Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
                    MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Ciudad/Región", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If

        End If

    End Sub

    Private Sub Btn_Edit_Comuna_Click(sender As Object, e As EventArgs) Handles Btn_Edit_Comuna.Click

        If Fx_Tiene_Permiso(Me, "Tbl00047") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Kopa = _Fila.Cells("KOPA").Value
            Dim _Koci = _Fila.Cells("KOCI").Value
            Dim _Kocm = _Fila.Cells("KOCM").Value
            Dim _Nokopa = _Fila.Cells("NOKOPA").Value
            Dim _Nokoci = _Fila.Cells("NOKOCI").Value
            Dim _Nokocm = _Fila.Cells("NOKOCM").Value.ToString.Trim

            Dim _Aceptar As Boolean = InputBox_Bk(Me, "Nombre de la comuna", "Comuna", _Nokocm, False,, 30, True)

            If _Aceptar Then

                Consulta_Sql = "Update TABCM Set NOKOCM = '" & _Nokocm & "' Where KOPA = '" & _Kopa & "' And KOCI = '" & _Koci & "' And KOCM = '" & _Kocm & "'"

                If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

                    Dim _Localidad = _Nokopa.ToString.Trim & " - " & _Nokoci.ToString.Trim & " - " & _Nokocm.ToString.Trim
                    Txt_Descripcion.Text = String.Empty
                    Sb_Actualizar_Grilla()

                    BuscarDatoEnGrilla(_Localidad, "Localidad", Grilla)

                    MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Comuna", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If

        End If

    End Sub

    Private Sub Btn_Elim_Comuna_Click(sender As Object, e As EventArgs) Handles Btn_Elim_Comuna.Click

        If Fx_Tiene_Permiso(Me, "Tbl00048") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Kopa = _Fila.Cells("KOPA").Value
            Dim _Koci = _Fila.Cells("KOCI").Value
            Dim _Kocm = _Fila.Cells("KOCM").Value
            Dim _Nokoci = _Fila.Cells("NOKOCM").Value

            Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEEN", "PAEN = '" & _Kopa & "' And CIEN = '" & _Koci & "' And CMEN = '" & _Kocm & "'"))

            If _Reg Then

                MessageBoxEx.Show(Me, "No puede eliminar esta comuna contiene entidades asociadas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return

            End If

            If MessageBoxEx.Show(Me, "¿Confirma la eliminación de la comuna " & _Nokoci & "?", "Eliminar comuna",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Consulta_Sql = "Delete TABCM Where KOPA = '" & _Kopa & "' And KOCI = '" & _Koci & "' And KOCM = '" & _Kocm & "'"

                If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                    Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
                    MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Comuna", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If

        End If

    End Sub

    Private Sub Btn_Crear_Pais_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Pais.Click

        If Fx_Tiene_Permiso(Me, "Tbl00047") Then

            Dim Fm As New Frm_Crear_PaCiCm(Frm_Crear_PaCiCm.Enum_Tp.Pais, "")
            Fm.Text = "CREAR PAIS"
            Fm.ShowDialog(Me)

            If Fm.Grabar Then

                Dim _Localidad = Fm.Localidad
                Txt_Descripcion.Text = String.Empty
                Sb_Actualizar_Grilla()

                BuscarDatoEnGrilla(_Localidad, "Localidad", Grilla)

            End If

            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Crear_Ciudad_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Ciudad.Click

        If Fx_Tiene_Permiso(Me, "Tbl00047") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Kopa = _Fila.Cells("KOPA").Value
            Dim _Nokopa = _Fila.Cells("NOKOPA").Value.ToString.Trim
            Dim _Localidad = _Fila.Cells("Localidad").Value.ToString.Trim

            Dim Fm As New Frm_Crear_PaCiCm(Frm_Crear_PaCiCm.Enum_Tp.Ciudad, _Localidad)
            Fm.Kopa = _Kopa
            Fm.Text = "CREAR CIUDAD - Pais: " & _Nokopa
            Fm.ShowDialog(Me)

            If Fm.Grabar Then

                _Localidad = Fm.Localidad
                Txt_Descripcion.Text = String.Empty
                Sb_Actualizar_Grilla()

                BuscarDatoEnGrilla(_Localidad, "Localidad", Grilla)

            End If

            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Crear_Comuna_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Comuna.Click

        If Fx_Tiene_Permiso(Me, "Tbl00047") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Kopa = _Fila.Cells("KOPA").Value
            Dim _Koci = _Fila.Cells("KOCI").Value
            Dim _Nokopa = _Fila.Cells("NOKOPA").Value.ToString.Trim
            Dim _Nokoci = _Fila.Cells("NOKOCI").Value.ToString.Trim
            Dim _Localidad = _Fila.Cells("Localidad").Value.ToString.Trim

            Dim Fm As New Frm_Crear_PaCiCm(Frm_Crear_PaCiCm.Enum_Tp.Comuna, _Localidad)
            Fm.Kopa = _Kopa
            Fm.Koci = _Koci
            Fm.Text = "CREAR COMUNA - Pais: " & _Nokopa & " - Ciudad: " & _Nokoci
            Fm.ShowDialog(Me)

            If Fm.Grabar Then

                _Localidad = Fm.Localidad
                Txt_Descripcion.Text = String.Empty
                Sb_Actualizar_Grilla()

                BuscarDatoEnGrilla(_Localidad, "Localidad", Grilla)

            End If

            Fm.Dispose()

        End If

    End Sub

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Kopa = _Fila.Cells("KOPA").Value.ToString.Trim
        Dim _Koci = _Fila.Cells("KOCI").Value.ToString.Trim

        Btn_Crear_Ciudad.Enabled = (Not String.IsNullOrEmpty(_Kopa))
        Btn_Crear_Comuna.Enabled = (Not String.IsNullOrEmpty(_Kopa) And Not String.IsNullOrEmpty(_Koci))

    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim Hitest As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
            If Hitest.Type = DataGridViewHitTestType.Cell Then
                sender.CurrentCell = sender.Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

                Dim _Kopa = _Fila.Cells("KOPA").Value.ToString.Trim
                Dim _Koci = _Fila.Cells("KOCI").Value.ToString.Trim
                Dim _Kocm = _Fila.Cells("KOCM").Value.ToString.Trim

                Btn_Mnu_Ciudad.Visible = Not String.IsNullOrEmpty(_Koci)
                Btn_Mnu_Comuna.Visible = Not String.IsNullOrEmpty(_Kocm)

                ShowContextMenu(Menu_Contextual_01)

            End If
        End If

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

    Private Sub Btn_Exportar_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Excel.Click

        Consulta_Sql = "Select Pa.KOPA,Pa.NOKOPA,Isnull(Ci.KOCI,'') As KOCI,Isnull(Ci.NOKOCI,'') As NOKOCI,Isnull(Cm.KOCM,'') As KOCM,Isnull(Cm.NOKOCM,'') As NOKOCM, 
	                    Rtrim(Ltrim(Pa.NOKOPA))+ Case When Ci.NOKOCI Is Null Then '' Else ' - '+Rtrim(Ltrim(Ci.NOKOCI)) End+" &
                        "Case When Cm.NOKOCM Is Null Then '' Else ' - '+Rtrim(Ltrim(Cm.NOKOCM)) End As Localidad	
                        From TABPA Pa 
                        Left Join TABCI Ci On Ci.KOPA = Pa.KOPA 
                        Left Join TABCM Cm On Cm.KOPA = Ci.KOPA And Ci.KOCI = Cm.KOCI
                        Order By Pa.KOPA,Ci.NOKOCI,NOKOCM"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Pais_Cuidas_Comunas")

    End Sub
End Class
