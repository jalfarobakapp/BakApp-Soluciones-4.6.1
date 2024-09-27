Imports DevComponents.DotNetBar
Imports System.Data.SqlClient

Public Class Frm_Demonio_02_Conf_X_Estacion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _TblDemonio_Doc As DataTable
    Dim _NombreEquipo As String
    Dim _Impresora As String
    Dim _Grabar As Boolean
    Dim _Tipo_Configuracion As Frm_Demonio_04_Conf_Impr_X_Funcionarios.Tipo_Configuracion

    'Enum Tipo_Configuracion
    '    Impresion
    '    Correo
    '    Prestashop
    '    Impresion_Picking
    'End Enum

    Public Property Pro_Impresora() As String
        Get
            Return _Impresora
        End Get
        Set(ByVal value As String)
            _Impresora = value
        End Set
    End Property
    Public Property Pro_NombreEquipo()
        Get
            Return _NombreEquipo
        End Get
        Set(ByVal value)
            _NombreEquipo = value
        End Set
    End Property
    Public ReadOnly Property Pro_Grabar() As Boolean
        Get
            Return _Grabar
        End Get
    End Property

    Public Sub New(ByVal Tipo_Conf As Frm_Demonio_04_Conf_Impr_X_Funcionarios.Tipo_Configuracion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Tipo_Configuracion = Tipo_Conf

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Imp_Picking_01_Conf_Sel_documentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler Rdb_Definitivo.CheckedChanged, AddressOf Sb_Rdb_Clic
        AddHandler Rdb_Vale.CheckedChanged, AddressOf Sb_Rdb_Clic
        AddHandler Rdb_Ambos.CheckedChanged, AddressOf Sb_Rdb_Clic
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Imprimir = False
        Dim _Correo = False
        Dim _Prestashop = False
        Dim _Emitidos = False
        Dim _Picking = False


        Select Case _Tipo_Configuracion
            Case Frm_Demonio_04_Conf_Impr_X_Funcionarios.Tipo_Configuracion.Impresion
                _Imprimir = True
            Case Frm_Demonio_04_Conf_Impr_X_Funcionarios.Tipo_Configuracion.Correo
                _Correo = True
            Case Frm_Demonio_04_Conf_Impr_X_Funcionarios.Tipo_Configuracion.Prestashop
                _Prestashop = True
            Case Frm_Demonio_04_Conf_Impr_X_Funcionarios.Tipo_Configuracion.Impresion_Picking
                _Picking = True
        End Select

        Try

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_Cof_Estacion (NombreEquipo,TipoDoc,NombreDoc)" & vbCrLf &
                           "Select '" & _NombreEquipo & "',TIDO,NOTIDO From TABTIDO" & Space(1) &
                           "Where TIDO Not In (Select TipoDoc From " & _Global_BaseBk & "Zw_Demonio_Cof_Estacion" & Space(1) &
                           "Where NombreEquipo = '" & _NombreEquipo & "')" & vbCrLf &
                           "Select *,Case Tipo_Definitivo_Vale When 'D' Then 'Definitivo' When 'V' Then 'Vales transitorios' When 'A' Then 'Ambos' End As Def_Vale" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_Demonio_Cof_Estacion Where NombreEquipo = '" & _NombreEquipo & "'"

            _TblDemonio_Doc = _Sql.Fx_Get_DataTable(Consulta_sql)


            With Grilla

                '.DataSource = Nothing
                .DataSource = _TblDemonio_Doc 'Ds_Config_Picking
                '.DataMember = Ds_Config_Picking.Tables("Tbl_Conf_Documentos").TableName

                OcultarEncabezadoGrilla(Grilla, True)

                Dim _DisplayIndex = 0

                .Columns("TipoDoc").Width = 40
                .Columns("TipoDoc").HeaderText = "Tipo"
                .Columns("TipoDoc").Visible = True
                .Columns("TipoDoc").ReadOnly = True
                .Columns("TipoDoc").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("NombreDoc").Width = 180
                .Columns("NombreDoc").HeaderText = "Descripción"
                .Columns("NombreDoc").Visible = True
                .Columns("NombreDoc").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Traer_Doc_Auto_Imprimir").Width = 100
                .Columns("Traer_Doc_Auto_Imprimir").HeaderText = "Traer Automáticamente para imprimir"
                .Columns("Traer_Doc_Auto_Imprimir").Visible = _Imprimir
                .Columns("Traer_Doc_Auto_Imprimir").ReadOnly = False
                .Columns("Traer_Doc_Auto_Imprimir").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Traer_Doc_Auto_Correo").Width = 100
                .Columns("Traer_Doc_Auto_Correo").HeaderText = "Traer Automáticamente para correos"
                .Columns("Traer_Doc_Auto_Correo").Visible = _Correo
                .Columns("Traer_Doc_Auto_Correo").ReadOnly = False
                .Columns("Traer_Doc_Auto_Correo").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Correo").Width = 50
                .Columns("Correo").HeaderText = "Correo"
                .Columns("Correo").Visible = _Correo
                .Columns("Correo").ReadOnly = False
                .Columns("Correo").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Prestashop").Width = 80
                .Columns("Prestashop").HeaderText = "Prestashop"
                .Columns("Prestashop").Visible = _Prestashop
                .Columns("Prestashop").ReadOnly = False
                .Columns("Prestashop").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                If _Imprimir Then

                    .Columns("Def_Vale").Width = 120
                    .Columns("Def_Vale").HeaderText = "Definitivos o Vales"
                    .Columns("Def_Vale").Visible = True
                    .Columns("Def_Vale").ReadOnly = False
                    .Columns("Def_Vale").DisplayIndex = _DisplayIndex
                    _DisplayIndex += 1

                    .Columns("Imprimir_Voucher_TJV").Width = 120
                    .Columns("Imprimir_Voucher_TJV").HeaderText = "Impr. Voucher TJV. Formato BakApp"
                    .Columns("Imprimir_Voucher_TJV").Visible = True
                    .Columns("Imprimir_Voucher_TJV").ReadOnly = False
                    .Columns("Imprimir_Voucher_TJV").DisplayIndex = _DisplayIndex
                    _DisplayIndex += 1

                    .Columns("Imprimir_Voucher_TJV_Original_Transbak").Width = 120
                    .Columns("Imprimir_Voucher_TJV_Original_Transbak").HeaderText = "Impr. Voucher TJV. Formato Transbak (Recomendado)"
                    .Columns("Imprimir_Voucher_TJV_Original_Transbak").Visible = True
                    .Columns("Imprimir_Voucher_TJV_Original_Transbak").ReadOnly = False
                    .Columns("Imprimir_Voucher_TJV_Original_Transbak").DisplayIndex = _DisplayIndex
                    _DisplayIndex += 1

                    .Columns("Imp_Suc_Modal").Width = 120
                    .Columns("Imp_Suc_Modal").HeaderText = "Impr. Solo doc. Suc. Modalidad " & ModSucursal
                    .Columns("Imp_Suc_Modal").Visible = True
                    .Columns("Imp_Suc_Modal").ReadOnly = False
                    .Columns("Imp_Suc_Modal").DisplayIndex = _DisplayIndex
                    _DisplayIndex += 1

                End If

                .Columns("Imprimir_Picking").Width = 120
                .Columns("Imprimir_Picking").HeaderText = "Imprimir picking"
                .Columns("Imprimir_Picking").Visible = _Picking
                .Columns("Imprimir_Picking").ReadOnly = False
                .Columns("Imprimir_Picking").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

            End With

            Sb_InsertarBotonenGrilla(Grilla, "Btn_Fl_Func", "Configuración ...", "Filtro Funcionarios", 7, _Tipo_Boton.Boton)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click

        _Grabar = Fx_Grabar()

        If _Grabar Then
            Me.Close()
        End If

    End Sub

    Function Fx_Grabar() As Boolean

        Consulta_sql = String.Empty

        For Each _Fila As DataRow In _TblDemonio_Doc.Rows

            Dim _TipoDoc = _Fila.Item("TipoDoc")
            Dim _Imprimir = CInt(_Fila.Item("Imprimir")) * -1
            Dim _Correo = CInt(_Fila.Item("Correo")) * -1
            Dim _Traer_Doc_Auto_Imprimir = CInt(_Fila.Item("Traer_Doc_Auto_Imprimir")) * -1
            Dim _Traer_Doc_Auto_Correo = CInt(_Fila.Item("Traer_Doc_Auto_Correo")) * -1
            Dim _Nombre_Correo = _Fila.Item("Nombre_Correo")
            Dim _NombreFormato = _Fila.Item("NombreFormato")
            Dim _Prestashop = CInt(_Fila.Item("Prestashop")) * -1
            Dim _Tipo_Definitivo_Vale = _Fila.Item("Tipo_Definitivo_Vale")
            Dim _Imprimir_Voucher_TJV = CInt(_Fila.Item("Imprimir_Voucher_TJV")) * -1
            Dim _Imprimir_Voucher_TJV_Original_Transbak = CInt(_Fila.Item("Imprimir_Voucher_TJV_Original_Transbak")) * -1
            Dim _Imprimir_Picking = CInt(_Fila.Item("Imprimir_Picking")) * -1
            Dim _Imp_Suc_Modal = CInt(_Fila.Item("Imp_Suc_Modal")) * -1

            If String.IsNullOrEmpty(_Nombre_Correo) Then
                _Correo = 0
            End If

            Consulta_sql += "Update " & _Global_BaseBk & "Zw_Demonio_Cof_Estacion Set " & vbCrLf &
                            "Imprimir = " & _Imprimir &
                            ",Correo = " & _Correo &
                            ",Traer_Doc_Auto_Imprimir = " & _Traer_Doc_Auto_Imprimir &
                            ",Traer_Doc_Auto_Correo = " & _Traer_Doc_Auto_Correo &
                            ",Nombre_Correo = '" & _Nombre_Correo & "'" &
                            ",NombreFormato = '" & _NombreFormato & "'" & vbCrLf &
                            ",Prestashop = '" & _Prestashop & "'" & vbCrLf &
                            ",Tipo_Definitivo_Vale = '" & _Tipo_Definitivo_Vale & "'" & vbCrLf &
                            ",Imprimir_Voucher_TJV = " & _Imprimir_Voucher_TJV & vbCrLf &
                            ",Imprimir_Voucher_TJV_Original_Transbak = " & _Imprimir_Voucher_TJV_Original_Transbak & vbCrLf &
                            ",Imprimir_Picking = " & _Imprimir_Picking & vbCrLf &
                            ",Imp_Suc_Modal = " & _Imp_Suc_Modal & vbCrLf &
                            "Where NombreEquipo = '" & _NombreEquipo & "' And TipoDoc = '" & _TipoDoc & "'" & vbCrLf & vbCrLf

        Next

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            Return True
        Else
            MessageBoxEx.Show(Me, "Problemas al actualizar los datos tabla Zw_Demonio_Cof_Estacion", "Problemas BakApp",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Function

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Cabeza = Grilla.Columns(e.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Fx_Configurar_Correo_O_Formato(_Cabeza, _Fila)

    End Sub

    Private Sub Grilla_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellClick

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _IdPadre = _Fila.Cells("Id").Value
        Dim _Tido = _Fila.Cells("TipoDoc").Value
        Dim _NombreFormato = _Fila.Cells("NombreFormato").Value
        Dim _Subtido = String.Empty ' _Fila.Cells("Subtido").Value
        Dim _Imprimir_Picking = _Fila.Cells("Imprimir_Picking").Value


        Select Case _Cabeza

            Case "Btn_Fl_Func"

                If _Tipo_Configuracion = Frm_Demonio_04_Conf_Impr_X_Funcionarios.Tipo_Configuracion.Impresion Then
                    ShowContextMenu(Menu_Contextual_02)
                Else
                    Sb_Conf_X_Estacion(_Tipo_Configuracion)
                End If

            Case "Btn_Reimprimir"

                If String.IsNullOrEmpty(_NombreFormato) Then
                    MessageBoxEx.Show(Me, "Debe asignar un formato para la impresión del documento",
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                If Fx_Tiene_Permiso(Me, "Pick0004") Then

                    Dim _IdMaeedo As String

                    Dim _Fm As New Frm_BusquedaDocumento_Filtro(False)
                    With _Fm

                        .Grupo_Funcionario.Enabled = False
                        .Rdb_Funcionarios_Uno.Checked = False
                        .Pro_Sql_Filtro_Documentos_Extra =
                        "And TIDO = '" & _Tido & "'" 'IN (Select TipoDoc From " & _Global_BaseBk & "Zw_Picking_Doc Where Imprimir = 1)"
                        .Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado
                        .Rdb_Tipo_Documento_Uno.Checked = True
                        .Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado,
                                             _Tido, "WHERE TIDO = '" & _Tido & "'")
                        .Rdb_Estado_Todos.Checked = True
                        .Rdb_Funcionarios_Todos.Checked = True
                        .Grupo_Funcionario.Enabled = False
                        .Rdb_Fecha_Emision_Desde_Hasta.Checked = True
                        .ShowDialog(Me)

                        If Not (.Pro_Row_Documento_Seleccionado Is Nothing) Then

                            _IdMaeedo = .Pro_Row_Documento_Seleccionado.Item("IDMAEEDO")
                            _Tido = .Pro_Row_Documento_Seleccionado.Item("TIDO")

                            Consulta_sql = "Select Top 1 * From MAEEDO Where IDMAEEDO = " & _IdMaeedo
                            Dim _RowEncabezado As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                            Dim Fm_Imp As New Frm_ImpresionDoc_Configuracion(_Tido, _NombreFormato, "", _Subtido)
                            Fm_Imp.Pro_Impresora = _Impresora
                            Fm_Imp.Fx_Imprimir_Vista_Previa(Me, _RowEncabezado, False, False, False, False, True, False)
                        Else
                            Return
                        End If

                    End With

                End If

        End Select


    End Sub

    Sub Sb_Conf_X_Estacion(_Tipo_Configuracion As Frm_Demonio_04_Conf_Impr_X_Funcionarios.Tipo_Configuracion)

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _IdPadre = _Fila.Cells("Id").Value

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Demonio_Cof_Estacion Where Id = " & _IdPadre

        Dim _Row_Demonio_Cof_Estacion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim Fm As Frm_Demonio_04_Conf_Impr_X_Funcionarios = New Frm_Demonio_04_Conf_Impr_X_Funcionarios(_Tipo_Configuracion, _Row_Demonio_Cof_Estacion)

        Fm.Pro_Impresora = _Impresora
        Fm.ShowDialog(Me)

        If Fm.Pro_Grabar Then

            Dim _Fecha = Format(FechaDelServidor, "yyyyMMdd")

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion" & vbCrLf &
                           "Where Fecha = '" & _Fecha & "' And NombreEquipo = '" & _NombreEquipo & "' And Impreso = 0"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Beep()
            ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE",
                                   My.Resources.ok_button,
                                   2 * 1000, eToastGlowColor.Green,
                                   eToastPosition.MiddleCenter)
        End If

        Fm.Dispose()

    End Sub

    Private Sub Grilla_CellMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Grilla.CellMouseUp

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Imprimir_Picking = _Fila.Cells("Imprimir_Picking").Value
        Dim _Tido = _Fila.Cells("TipoDoc").Value

        Grilla.EndEdit()

    End Sub

    Private Sub Grilla_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEndEdit

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Cabeza_N = String.Empty
        Dim _Imprimir_Picking = _Fila.Cells("Imprimir_Picking").Value
        Dim _Tido = _Fila.Cells("TipoDoc").Value

        Dim _Valor As Boolean

        Select Case _Cabeza
            Case "Imprimir_Voucher_TJV"
                If _Fila.Cells("Imprimir_Voucher_TJV").Value Then _Fila.Cells("Imprimir_Voucher_TJV_Original_Transbak").Value = False
            Case "Imprimir_Voucher_TJV_Original_Transbak"
                If _Fila.Cells("Imprimir_Voucher_TJV_Original_Transbak").Value Then _Fila.Cells("Imprimir_Voucher_TJV").Value = False
        End Select

        Return
        If _Cabeza = "Imprimir" Or _Cabeza = "Correo" Then

            Select Case _Cabeza
                Case "Imprimir"
                    _Cabeza_N = "NombreFormato"
                Case "Correo"
                    _Cabeza_N = "Nombre_Correo"
            End Select

            If _Fila.Cells(_Cabeza).Value Then
                If Not Fx_Configurar_Correo_O_Formato(_Cabeza_N, _Fila) Then
                    Beep()
                    ToastNotification.Show(Me, "NO SE REALIZO NINGUNA SELECCION",
                                           My.Resources.cross,
                                           2 * 1000, eToastGlowColor.Red,
                                           eToastPosition.MiddleCenter)

                    _Fila.Cells(_Cabeza).Value = False
                End If
            Else
                _Fila.Cells(_Cabeza_N).Value = String.Empty
            End If
        End If

    End Sub

    Function Fx_Configurar_Correo_O_Formato(ByVal _Cabeza As String,
                                            ByVal _Fila As DataGridViewRow) As Boolean

        Dim _TipoDoc As String = _Fila.Cells("TipoDoc").Value
        Dim _Imprimir As Boolean = _Fila.Cells("Imprimir").Value
        Dim _Correo As Boolean = _Fila.Cells("Correo").Value

        Dim _Ok As Boolean

        Select Case _Cabeza

            Case "Nombre_Correo"

                If _Correo Then

                    Dim Fm As New Frm_Correos_SMTP
                    Fm.Pro_Seleccionar = True
                    Fm.ShowDialog(Me)

                    If Fm.Pro_Seleccionado Then
                        _Fila.Cells("Nombre_Correo").Value = Fm.Pro_Row_Fila_Seleccionada.Item("Nombre_Correo")
                        _Ok = True
                    End If
                    Fm.Dispose()
                    Grilla.EndEdit()

                Else

                    Beep()
                    ToastNotification.Show(Me, "ESTA DESHABILITADO",
                                           My.Resources.cross,
                                           2 * 1000, eToastGlowColor.Red,
                                           eToastPosition.MiddleCenter)

                End If

            Case "NombreFormato"

                If _Imprimir Then

                    Dim Fm As New Frm_Seleccionar_Formato(_TipoDoc)
                    If CBool(Fm.Tbl_Formatos.Rows.Count) Then
                        Fm.ShowDialog(Me)
                        If Fm.Formato_Seleccionado Then
                            _Fila.Cells("NombreFormato").Value = Fm.Row_Formato_Seleccionado.Item("NombreFormato")
                            _Ok = True
                        End If
                    Else
                        MessageBoxEx.Show(Me, "No existen formatos adicionales para este documento", "Validación",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                    Fm.Dispose()

                Else

                    Beep()
                    ToastNotification.Show(Me, "ESTA DESHABILITADO",
                                           My.Resources.cross,
                                           2 * 1000, eToastGlowColor.Red,
                                           eToastPosition.MiddleCenter)

                End If


        End Select

        Return _Ok

    End Function

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

                    Dim _Tido = _Fila.Cells("TipoDoc").Value

                    If _Tido = "FCV" Or _Tido = "BLV" Then

                        Dim _Tipo_Definitivo_Vale = _Fila.Cells("Tipo_Definitivo_Vale").Value
                        Dim _Def_Vale = _Fila.Cells("Def_Vale").Value

                        Select Case _Tipo_Definitivo_Vale
                            Case "D"
                                Rdb_Definitivo.Checked = True
                            Case "V"
                                Rdb_Vale.Checked = True
                            Case "A"
                                Rdb_Ambos.Checked = True
                        End Select

                        ShowContextMenu(Menu_Contextual_01)

                    End If

                End If
            End With
        End If
    End Sub

    Sub Sb_Rdb_Clic(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs)

        If CType(sender, DevComponents.DotNetBar.CheckBoxItem).Checked Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Tipo_Definitivo_Vale As String ' = _Fila.Cells("Tipo_Definitivo_Vale").Value
            Dim _Def_Vale As String '= _Fila.Cells("Def_Vale").Value

            If Rdb_Definitivo.Checked Then
                _Def_Vale = "Definitivo" : _Tipo_Definitivo_Vale = "D"
            ElseIf Rdb_Vale.Checked Then
                _Def_Vale = "Vales transitorios" : _Tipo_Definitivo_Vale = "V"
            ElseIf Rdb_Ambos.Checked Then
                _Def_Vale = "Ambos" : _Tipo_Definitivo_Vale = "A"
            End If

            _Fila.Cells("Tipo_Definitivo_Vale").Value = _Tipo_Definitivo_Vale
            _Fila.Cells("Def_Vale").Value = _Def_Vale

        End If

    End Sub

    Private Sub Btn_Conf_Definitivos_Click(sender As Object, e As EventArgs) Handles Btn_Conf_Definitivos.Click

        Me.Sb_Conf_X_Estacion(Frm_Demonio_04_Conf_Impr_X_Funcionarios.Tipo_Configuracion.Impresion)

    End Sub

    Private Sub Btn_Conf_Vales_Transitorios_Click(sender As Object, e As EventArgs) Handles Btn_Conf_Vales_Transitorios.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _TipoDoc As String = _Fila.Cells("TipoDoc").Value

        If _TipoDoc = "BLV" Or _TipoDoc = "FCV" Then
            Me.Sb_Conf_X_Estacion(Frm_Demonio_04_Conf_Impr_X_Funcionarios.Tipo_Configuracion.Impresion_Vale_Transitorio)
        Else
            MessageBoxEx.Show(Me, "Opción solo para boletas y facturas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub
End Class
