'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Anotaciones_Tabuladas_02_Detalle

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Kotabla As String
    Public _Idmaeedo_ligado As Integer

    Enum Tipo_Apertura
        Mantencion_tabla
        Seleccion_tabla
    End Enum

    Enum Incorporacion_clasificaciones
        Linea_Activa
        Tickeadas
        Todas
    End Enum

    Dim _Tipo_Apertura As Tipo_Apertura
    Public _Incorporacion As Incorporacion_clasificaciones
    Public _Incorporar As Boolean

    Public _TblDetalle As DataTable

    Public Sub New(ByVal Kotabla As String, ByVal Apertura As Tipo_Apertura)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        _Kotabla = Kotabla
        _Tipo_Apertura = Apertura
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then

            Btn_Incorporar_anotaciones.ForeColor = Color.White

        End If


    End Sub

    Private Sub Frm_Anotaciones_Tabuladas_02_Detalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        If _Tipo_Apertura = Tipo_Apertura.Mantencion_tabla Then
            AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown_MenuEditar
            Btn_Incorporar_anotaciones.Visible = False
        ElseIf _Tipo_Apertura = Tipo_Apertura.Seleccion_tabla Then
            AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown_EnlaceExterno
            Grilla.ContextMenuStrip = Nothing
            Btn_Crear_Tabla.Visible = False
        End If

        Sb_Actualizar_Grilla()
    End Sub


    Private Sub Sb_Grilla_MouseDown_MenuEditar(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Editar_Eliminar)
                End If
            End With
        End If
    End Sub

    Private Sub Sb_Grilla_MouseDown_EnlaceExterno(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If _Cabeza = "Enlace_Externo" Then

            If e.Button = Windows.Forms.MouseButtons.Right Then
                With sender
                    Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                    If Hitest.Type = DataGridViewHitTestType.Cell Then
                        .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
                        Btn_Quitar_Link.Enabled = _Fila.Cells("IDRSE").Value
                        ShowContextMenu(Menu_Ligar_documentos)
                    End If
                End With
            End If
        End If

    End Sub


    Private Sub Btn_Crear_Tabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Crear_Tabla.Click

        Dim Fm As New Frm_Anotaciones_Tabuladas_03_Crear_Tabla_Enc_Det(
        Frm_Anotaciones_Tabuladas_03_Crear_Tabla_Enc_Det.Tipo_Tabla.Detalle,
        Frm_Anotaciones_Tabuladas_03_Crear_Tabla_Enc_Det.Tipo_Grabacion.Nuevo, , , _Kotabla)

        Fm.Text = "CREAR NUEVA CLASIFICACION"
        Fm.ShowDialog(Me)
        If Fm._Grabar Then
            Beep()
            ToastNotification.Show(Me, "DATOS ACTUALIZAOS CORRECTAMENTE", My.Resources.ok_button,
                                   1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        End If
        Sb_Actualizar_Grilla()
        Fm.Dispose()
    End Sub

    Private Sub Btn_Editar_tabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar_tabla.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim Fm As New Frm_Anotaciones_Tabuladas_03_Crear_Tabla_Enc_Det(
        Frm_Anotaciones_Tabuladas_03_Crear_Tabla_Enc_Det.Tipo_Tabla.Detalle,
        Frm_Anotaciones_Tabuladas_03_Crear_Tabla_Enc_Det.Tipo_Grabacion.Editar,
                                                         _Fila.Cells("KOCARAC").Value,
                                                         _Fila.Cells("NOKOCARAC").Value,
                                                         _Kotabla)

        Fm.Text = "EDITAR TABLA"
        Fm.ShowDialog(Me)
        If Fm._Grabar Then
            Beep()
            ToastNotification.Show(Me, "DATOS ACTUALIZAOS CORRECTAMENTE", My.Resources.ok_button,
                                   1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
            _Fila.Cells("NOKOCARAC").Value = Fm.Txt_Descripcion.Text

        End If
        Fm.Dispose()

    End Sub

    Private Sub Btn_Eliminar_tabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar_tabla.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Kotabla As String = _Fila.Cells("KOTABLA").Value
        Dim _Kocarac As String = _Fila.Cells("KOCARAC").Value

        If MessageBoxEx.Show(Me, "¿Está seguro de querer eliminar esta clasificación?", "Eliminar Tabla",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then

            Consulta_sql = "DELETE TABCARAC WHERE KOTABLA = '" & _Kotabla & "' And KOCARAC = '" & _Kocarac & "'"
            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                Beep()
                ToastNotification.Show(Me, "CLAIFICACION ELIMINADA CORRECTAMENTE", My.Resources.ok_button,
                                       1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
            End If
        End If

    End Sub

    Sub Sb_Actualizar_Grilla()

        If _Tipo_Apertura = Tipo_Apertura.Mantencion_tabla Then
            Consulta_sql = "Select * From TABCARAC Where KOTABLA = '" & _Kotabla & "'"
        ElseIf _Tipo_Apertura = Tipo_Apertura.Seleccion_tabla Then
            Consulta_sql = "Select CAST( 0 AS bit) AS Chk,*,CAST( '' AS Varchar(100)) AS Enlace_Externo," &
                           "CAST( '' AS Char(8)) AS ARCHIRSE,CAST( 0 AS Int) AS IDRSE" & vbCrLf &
                           "From TABCARAC Where KOTABLA = '" & _Kotabla & "'"
        End If


        _TblDetalle = _SQL.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _TblDetalle

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _Mas = 570

            If _Tipo_Apertura = Tipo_Apertura.Seleccion_tabla Then
                .Columns("Chk").HeaderText = "Sel"
                .Columns("Chk").Width = 30
                .Columns("Chk").Visible = True
                _Mas = 350
            End If

            .Columns("KOCARAC").HeaderText = "Código"
            .Columns("KOCARAC").Width = 100
            .Columns("KOCARAC").Visible = True
            .Columns("KOCARAC").ReadOnly = True

            .Columns("NOKOCARAC").HeaderText = "Descripción"
            .Columns("NOKOCARAC").Width = _Mas
            .Columns("NOKOCARAC").Visible = True

            If _Tipo_Apertura = Tipo_Apertura.Seleccion_tabla Then
                .Columns("Enlace_Externo").HeaderText = "Enlace externo"
                .Columns("Enlace_Externo").Width = 220
                .Columns("Enlace_Externo").Visible = True
                .Columns("Enlace_Externo").ReadOnly = True
            End If

            If _Tipo_Apertura = Tipo_Apertura.Mantencion_tabla Then
                .Columns("NOKOCARAC").ReadOnly = True
            ElseIf _Tipo_Apertura = Tipo_Apertura.Seleccion_tabla Then
                .Columns("NOKOCARAC").ReadOnly = False
            End If

        End With

    End Sub

    Private Sub Frm_Anotaciones_Tabuladas_02_Detalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Incorporar_Linea_Activa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Incorporar_Linea_Activa.Click
        Grilla.EndEdit()
        _Incorporacion = Incorporacion_clasificaciones.Linea_Activa
        _Incorporar = True

        Dim _Index As Integer = Grilla.CurrentRow.Index

        For Each _Fila As DataGridViewRow In Grilla.Rows
            If _Index = _Fila.Index Then
                _Fila.Cells("Chk").Value = True
            Else
                _Fila.Cells("Chk").Value = False
            End If
        Next

        Me.Close()
    End Sub

    Private Sub Btn_Incorporar_Solo_Tickeados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Incorporar_Solo_Tickeados.Click
        Grilla.EndEdit()
        Dim _Tickeados = 0
        For Each _Fila As DataGridViewRow In Grilla.Rows
            If _Fila.Cells("Chk").Value Then
                _Tickeados += 1
            End If
        Next

        If CBool(_Tickeados) Then
            _Incorporacion = Incorporacion_clasificaciones.Tickeadas
            _Incorporar = True
            Me.Close()
        Else
            MessageBoxEx.Show(Me, "No existen filas seleccionadas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Btn_Incorporar_todas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Incorporar_todas.Click
        Grilla.EndEdit()
        _Incorporacion = Incorporacion_clasificaciones.Todas
        _Incorporar = True
        For Each _Fila As DataGridViewRow In Grilla.Rows
            _Fila.Cells("Chk").Value = True
        Next
        Me.Close()
    End Sub

    Private Sub Grilla_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEndEdit

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If _Cabeza = "NOKOCARAC" Then
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            _Fila.Cells("Chk").Value = True
            _Fila.Cells("NOKOCARAC").Value = Mid(_Fila.Cells("NOKOCARAC").Value, 1, 50)
        End If


    End Sub

    Private Sub Grilla_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grilla.MouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Btn_Enlazar_documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Enlazar_documento.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Fm As New Frm_BusquedaDocumento_Filtro(False)
        _Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Todos, "")
        _Fm.Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Todos
        _Fm.ShowDialog(Me)

        If Not (_Fm.Pro_Row_Documento_Seleccionado Is Nothing) Then

            With _Fm.Pro_Row_Documento_Seleccionado
                _Idmaeedo_ligado = .Item("IDMAEEDO")
                _Fila.Cells("ARCHIRSE").Value = "MAEEDO"
                _Fila.Cells("IDRSE").Value = .Item("IDMAEEDO")
                Dim _Documento As String = .Item("TIDO") & "-" & .Item("NUDO")
                _Fila.Cells("Enlace_Externo").Value = _Documento
            End With

        End If
        _Fm.Dispose()

    End Sub


    Private Sub Btn_Quitar_Link_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Quitar_Link.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        _Fila.Cells("ARCHIRSE").Value = ""
        _Fila.Cells("IDRSE").Value = 0
        _Fila.Cells("Enlace_Externo").Value = ""

    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        If _Cabeza = "NOKOCARAC" Then

            _Fila.Cells("NOKOCARAC").Value = _Fila.Cells("NOKOCARAC").Value.ToString.Trim
            SendKeys.Send("{F2}")
            Grilla.BeginEdit(True)

        ElseIf _Cabeza = "Enlace_Externo" Then

            Btn_Quitar_Link.Enabled = _Fila.Cells("IDRSE").Value
            ShowContextMenu(Menu_Ligar_documentos)

        End If

    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown

        If e.KeyValue = Keys.Enter Then

            e.Handled = True
            Call Grilla_CellDoubleClick(Nothing, Nothing)

        End If

    End Sub


End Class
