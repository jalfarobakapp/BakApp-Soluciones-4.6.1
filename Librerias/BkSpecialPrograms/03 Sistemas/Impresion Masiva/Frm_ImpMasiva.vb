Imports System.ComponentModel
Imports DevComponents.DotNetBar

Public Class Frm_ImpMasiva

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim Cl_ImpMasiva As New Cl_ImpMasiva
    Dim ListaDocumentos As New BindingList(Of ImpMasiva.ImpDocumentos)

    Private _Ls_Idmaeedo As List(Of String)
    Private _Tido As String
    Private _Cancelar As Boolean

    Public Sub New(_Tido As String, _Ls_Idmaeedo As List(Of String))

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Ls_Idmaeedo = _Ls_Idmaeedo
        Me._Tido = _Tido

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, False, False)
        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_ImpMasiva_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Rdb_ImpFormatoModalidad.Text = "Imprimir en el formato de la modalidad: " & Mod_Modalidad

        For Each _Idmaeedo As String In _Ls_Idmaeedo
            ListaDocumentos.Add(Cl_ImpMasiva.Fx_llenar_ImpDocumento(_Idmaeedo))
        Next

        Sb_Parametros_Informe_Sql(False)
        Sb_ActualizarGrilla()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub

    Sub Sb_ActualizarGrilla()

        ' Desvincular el DataGridView
        Grilla.DataSource = Nothing

        Dim bindingSource As New BindingSource()
        bindingSource.DataSource = ListaDocumentos
        Grilla.DataSource = bindingSource

        With Grilla

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Chk").Visible = True
            .Columns("Chk").HeaderText = "Sel."
            .Columns("Chk").Width = 30
            .Columns("Chk").ReadOnly = False
            .Columns("Chk").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Tido").Visible = True
            .Columns("Tido").HeaderText = "TD"
            .Columns("Tido").Width = 30
            .Columns("Tido").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nudo").Visible = True
            .Columns("Nudo").HeaderText = "Número"
            .Columns("Nudo").Width = 100
            .Columns("Nudo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Endo").Visible = True
            .Columns("Endo").HeaderText = "Entidad"
            .Columns("Endo").Width = 80
            .Columns("Endo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Suendo").Visible = True
            .Columns("Suendo").HeaderText = "Suc."
            .Columns("Suendo").Width = 50
            .Columns("Suendo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nokoen").Visible = True
            .Columns("Nokoen").HeaderText = "Razon social"
            .Columns("Nokoen").Width = 350
            .Columns("Nokoen").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nokoen").Visible = True
            .Columns("Nokoen").HeaderText = "Razon social"
            .Columns("Nokoen").Width = 350
            .Columns("Nokoen").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Modalidad").Visible = True
            .Columns("Modalidad").HeaderText = "Modalidad"
            .Columns("Modalidad").Width = 150
            .Columns("Modalidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreFormato_Modalidad").Visible = True
            .Columns("NombreFormato_Modalidad").HeaderText = "Nombre Formato Modalidad"
            .Columns("NombreFormato_Modalidad").Width = 150
            .Columns("NombreFormato_Modalidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreFormato_ModalidadDoc").Visible = True
            .Columns("NombreFormato_ModalidadDoc").HeaderText = "Nombre Formato Modalidad Documento"
            .Columns("NombreFormato_ModalidadDoc").Width = 150
            .Columns("NombreFormato_ModalidadDoc").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Cantidad").Visible = True
            '.Columns("Cantidad").HeaderText = "Cantidad"
            '.Columns("Cantidad").Width = 100
            '.Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Cantidad").DefaultCellStyle.Format = "###,##0.##"
            '.Columns("Cantidad").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

        End With

    End Sub

    Private Sub Grilla_MouseUp(sender As Object, e As MouseEventArgs) Handles Grilla.MouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Txt_Impresora_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Impresora.ButtonCustomClick

        Dim Fm As New Frm_Seleccionar_Impresoras("")
        Fm.ShowDialog(Me)
        If Fm.Pro_Aceptar Then
            Txt_Impresora.Text = Fm.Pro_Impresora_Seleccionada
        End If
        Fm.Dispose()

    End Sub

    Private Sub Btn_Imprimir_Click(sender As Object, e As EventArgs) Handles Btn_Imprimir.Click

        Dim _Subtido = String.Empty

        Dim hayFilaChecada As Boolean = ListaDocumentos.Any(Function(doc) doc.Chk)

        If Not hayFilaChecada Then
            MessageBoxEx.Show(Me, "Debe seleccionar al menos un documento", "Validación",
                             MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Txt_Impresora.Text) Then
            MessageBoxEx.Show(Me, "Debe seleccionar una impresora", "Validación",
                             MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Rdb_ImpFormatoSeleccionado.Checked AndAlso String.IsNullOrEmpty(Txt_NombreFormato.Text) Then
            MessageBoxEx.Show(Me, "Debe seleccionar un formato", "Validación",
                             MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _NroDocImprimir As Integer = ListaDocumentos.Where(Function(doc) doc.Chk).Count()

        Dim _Msg1 = "CONFIRMAR IMPRESION MASIVA DE DOCUMENTOS"
        Dim _Msg2 = vbCrLf & "¿Está seguro de que desea imprimir " & _NroDocImprimir & " documentos?" & vbCrLf
        Dim _eTaskDialogIcon As eTaskDialogIcon '= eTaskDialogIcon.Information2

        'If _NroDocImprimir > 10 Then
        _eTaskDialogIcon = eTaskDialogIcon.Exclamation
        'End If

        If Not Fx_Confirmar_Lectura(_Msg1, _Msg2.ToUpper, _eTaskDialogIcon) Then
            If Chk_Marcar_Todas.Checked Then
                Chk_Marcar_Todas.Checked = False
            End If
            Return
        End If

        '_NombreFormato = CType(Txt_NombreFormato.Tag, DataRow).Item("NombreFormato")
        _Subtido = CType(Txt_NombreFormato.Tag, DataRow).Item("SubTido")

        Dim _Lista As New List(Of LsValiciones.Mensajes)

        ' Configurar la barra de progreso
        Barra_Progreso.Minimum = 0
        Barra_Progreso.Maximum = _NroDocImprimir
        Barra_Progreso.Value = 0
        Barra_Progreso.Visible = True

        Btn_Imprimir.Enabled = False
        Btn_Cancelar.Enabled = True
        Btn_Cancelar.Visible = True
        _Cancelar = False

        Try
            Sb_HabilitarDeshabilitarControles(False)

            For Each _Row As ImpMasiva.ImpDocumentos In ListaDocumentos

                If _Row.Chk Then

                    Dim _Idmaeedo As Integer = _Row.Idmaeedo
                    Dim _Nudo As String = _Row.Nudo
                    Dim _NombreFormato As String

                    If Rdb_ImpFormatoSeleccionado.Checked Then
                        _NombreFormato = Txt_NombreFormato.Text
                    ElseIf Rdb_ImpFormatoModalidad.Checked Then
                        _NombreFormato = _Row.NombreFormato_Modalidad
                    ElseIf Rdb_ImpFormatoModalidadDoc.Checked Then
                        _NombreFormato = _Row.NombreFormato_ModalidadDoc
                    End If

                    Dim _ImprimirDocAdjuntos = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Format_01",
                                                                 "ImprimirDocAdjuntos",
                                                                 "NombreFormato = '" & _NombreFormato & "' And Subtido = '" & _Subtido & "'",,,, True)

                    If _ImprimirDocAdjuntos Then
                        Fx_ImprimirArchivoAdjunto(_ImprimirDocAdjuntos, _Idmaeedo, Txt_Impresora.Text)
                    End If

                    Dim _Mensaje As LsValiciones.Mensajes

                    _Mensaje = Fx_Imprimir_Documento2(_Idmaeedo, _Tido, _Nudo, _NombreFormato, False, False, False, Txt_Impresora.Text, _Subtido)

                    If Chk_ImprimirCedible.Checked AndAlso _Mensaje.EsCorrecto Then
                        Fx_Imprimir_Documento2(_Idmaeedo, _Tido, _Nudo, _NombreFormato, True, False, False, Txt_Impresora.Text, _Subtido)
                    End If

                    _Lista.Add(_Mensaje)

                    ' Actualizar la barra de progreso
                    Barra_Progreso.Value += 1
                    Barra_Progreso.Refresh()

                    Lbl_Status.Text = "Imprimiendo documentos... " & Barra_Progreso.Value & " de " & _NroDocImprimir

                    Application.DoEvents()

                    ' Verificar si se ha cancelado el proceso
                    If _Cancelar Then
                        MessageBoxEx.Show(Me, "Proceso cancelado por el usuario", "Validación",
                                         MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit For
                    End If

                    ' Verificar si se ha alcanzado el máximo de documentos
                    'If Barra_Progreso.Value >= _DocumentosMarcados Then
                    '    MessageBoxEx.Show(Me, "Se ha alcanzado el máximo de documentos a imprimir", "Validación",
                    '                     MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '    Exit For
                    'End If

                End If

            Next

            If _Cancelar Then
                Me.Close()
            End If

            Barra_Progreso.Visible = False

            Dim ListaQr As LsValiciones.Mensajes = _Lista.FirstOrDefault(Function(p) p.EsCorrecto = False)

            If Not IsNothing(ListaQr) Then
                MessageBoxEx.Show(Me, "Hay documentos con problemas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

            Dim Fmv As New Frm_Validaciones
            Fmv.ListaMensajes = _Lista
            Fmv.ShowDialog(Me)
            Fmv.Dispose()

            For Each _Row As ImpMasiva.ImpDocumentos In ListaDocumentos
                _Row.Chk = False
            Next

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sb_HabilitarDeshabilitarControles(True)
            Barra_Progreso.Minimum = 0
            Barra_Progreso.Value = 0
            Lbl_Status.Text = String.Empty
            Me.Refresh()
        End Try

    End Sub

    Private Sub Txt_NombreFormato_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_NombreFormato.ButtonCustomClick

        Dim Fm As New Frm_Seleccionar_Formato(_Tido)
        Fm.ShowDialog(Me)

        If Fm.Formato_Seleccionado Then
            Txt_NombreFormato.Tag = Fm.Row_Formato_Seleccionado
            Txt_NombreFormato.Text = Fm.Row_Formato_Seleccionado.Item("NombreFormato")
            Chk_ImprimirCedible.Checked = Fm.Row_Formato_Seleccionado.Item("Doc_Electronico")
        End If

        Fm.Dispose()

    End Sub

    Private Sub Chk_Marcar_Todas_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Marcar_Todas.CheckedChanged

        For Each row As DataGridViewRow In Grilla.Rows
            Dim documento As ImpMasiva.ImpDocumentos = CType(row.DataBoundItem, ImpMasiva.ImpDocumentos)
            documento.Chk = Chk_Marcar_Todas.Checked
        Next

        Grilla.Refresh()

    End Sub

    Sub Sb_Parametros_Informe_Sql(_Actualizar As Boolean)

        Dim _Informe = "Impresion_Masiva"

        Dim _FechaHoy As Date = FormatDateTime(FechaDelServidor, DateFormat.ShortDate)
        Dim _Fecha_Hoy = Format(_FechaHoy, "dd-MM-yyyy")

        _Sql.Sb_Parametro_Informe_Sql(Txt_Impresora, _Informe, Txt_Impresora.Name,
                                                 Class_SQL.Enum_Type._Text, Txt_Impresora.Text, _Actualizar, "Imprimir")

        Dim _Tido As String
        Dim _Subtido As String
        Dim _NombreFormato As String

        If _Actualizar Then

            If Not IsNothing(Txt_NombreFormato.Tag) Then

                _Tido = CType(Txt_NombreFormato.Tag, DataRow).Item("TipoDoc")
                _Subtido = CType(Txt_NombreFormato.Tag, DataRow).Item("Subtido")
                _NombreFormato = CType(Txt_NombreFormato.Tag, DataRow).Item("NombreFormato")

                _Sql.Sb_Parametro_Informe_Sql(_Tido, _Informe, "Tido",
                                         Class_SQL.Enum_Type._Text, _Tido, _Actualizar, "Imprimir", True)
                _Sql.Sb_Parametro_Informe_Sql(_Subtido, _Informe, "Subtido",
                                        Class_SQL.Enum_Type._Text, _Subtido, _Actualizar, "Imprimir", True)
                _Sql.Sb_Parametro_Informe_Sql(_NombreFormato, _Informe, "NombreFormato",
                                        Class_SQL.Enum_Type._Text, _NombreFormato, _Actualizar, "Imprimir", True)
            End If

        Else

            _Sql.Sb_Parametro_Informe_Sql(_Tido, _Informe, "Tido",
                                         Class_SQL.Enum_Type._Text, _Tido, _Actualizar, "Imprimir", True)
            _Sql.Sb_Parametro_Informe_Sql(_Subtido, _Informe, "Subtido",
                                        Class_SQL.Enum_Type._Text, "", _Actualizar, "Imprimir", True)
            _Sql.Sb_Parametro_Informe_Sql(_NombreFormato, _Informe, "NombreFormato",
                                        Class_SQL.Enum_Type._Text, "", _Actualizar, "Imprimir", True)

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Format_01" & Space(1) &
                           "Where TipoDoc = '" & _Tido & "' And Subtido = '" & _Subtido & "' And NombreFormato = '" & _NombreFormato & "'"
            Dim _Row_Formato_Seleccionado = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Formato_Seleccionado) Then
                Txt_NombreFormato.Tag = _Row_Formato_Seleccionado
                Txt_NombreFormato.Text = _Row_Formato_Seleccionado.Item("NombreFormato")
                Chk_ImprimirCedible.Checked = _Row_Formato_Seleccionado.Item("Doc_Electronico")
            End If

        End If

        _Sql.Sb_Parametro_Informe_Sql(Rdb_ImpFormatoModalidad, _Informe, Rdb_ImpFormatoModalidad.Name,
                                     Class_SQL.Enum_Type._Boolean, Rdb_ImpFormatoModalidad.Checked, _Actualizar, "Imprimir")
        _Sql.Sb_Parametro_Informe_Sql(Rdb_ImpFormatoModalidadDoc, _Informe, Rdb_ImpFormatoModalidadDoc.Name,
                                        Class_SQL.Enum_Type._Boolean, Rdb_ImpFormatoModalidadDoc.Checked, _Actualizar, "Imprimir")
        _Sql.Sb_Parametro_Informe_Sql(Rdb_ImpFormatoSeleccionado, _Informe, Rdb_ImpFormatoSeleccionado.Name,
                                        Class_SQL.Enum_Type._Boolean, Rdb_ImpFormatoSeleccionado.Checked, _Actualizar, "Imprimir")

    End Sub
    Private Sub Frm_ImpMasiva_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Sb_Parametros_Informe_Sql(True)
    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        _Cancelar = True
    End Sub

    Sub Sb_HabilitarDeshabilitarControles(_Habilitar As Boolean)

        Grilla.Enabled = _Habilitar
        Txt_Impresora.Enabled = _Habilitar
        Txt_NombreFormato.Enabled = _Habilitar
        Btn_Imprimir.Enabled = _Habilitar
        Btn_Cancelar.Enabled = Not _Habilitar
        Btn_Cancelar.Visible = Not _Habilitar
        Chk_ImprimirCedible.Enabled = _Habilitar
        Chk_Marcar_Todas.Enabled = _Habilitar

    End Sub

End Class
