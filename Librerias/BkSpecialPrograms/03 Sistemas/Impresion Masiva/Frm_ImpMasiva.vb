Imports System.ComponentModel
Imports DevComponents.DotNetBar

Public Class Frm_ImpMasiva

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim Cl_ImpMasiva As New Cl_ImpMasiva
    Dim ListaDocumentos As New BindingList(Of ImpMasiva.ImpDocumentos)

    Private _Ls_Idmaeedo As List(Of String)
    Private _Tido As String

    Public Sub New(_Tido As String, _Ls_Idmaeedo As List(Of String))

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Ls_Idmaeedo = _Ls_Idmaeedo
        Me._Tido = _Tido

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.None, True, False, False)
        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_ImpMasiva_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Filtro As String = Generar_Filtro_IN_Lista2(_Ls_Idmaeedo, False, "")

        Consulta_sql = "Select IDMAEEDO,TIDO,NUDO From MAEEDO Where IDMAEEDO In " & _Filtro
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        For Each _Row As DataRow In _Tbl.Rows

            ListaDocumentos.Add(Cl_ImpMasiva.Fx_llenar_ImpDocumento(_Row.Item("IDMAEEDO")))

        Next

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

            '.DataSource = _Source

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
            .Columns("Nokoen").Width = 300
            .Columns("Nokoen").DisplayIndex = _DisplayIndex
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
        Dim _NombreFormato As String

        'If _Tido = "GDD" Or _Tido = "GDP" Then
        '    _Subtido = _Fila.Cells("SUBTIDO").Value
        'End If

        ' Verificar si hay alguna fila checada
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

        If String.IsNullOrEmpty(Txt_NombreFormato.Text) Then
            MessageBoxEx.Show(Me, "Debe seleccionar un formato", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        _NombreFormato = CType(Txt_NombreFormato.Tag, DataRow).Item("NombreFormato")
        _Subtido = CType(Txt_NombreFormato.Tag, DataRow).Item("SubTido")

        Dim _Lista As New List(Of LsValiciones.Mensajes)

        For Each _Row As ImpMasiva.ImpDocumentos In ListaDocumentos

            Dim _Idmaeedo As Integer = _Row.Idmaeedo
            Dim _Nudo As String = _Row.Nudo
            Dim _Chk As Boolean = _Row.Chk

            If _Chk Then

                Dim _Mensaje As LsValiciones.Mensajes

                _Mensaje = Fx_Imprimir_Documento2(_Idmaeedo, _Tido, _Nudo, _NombreFormato, False, False, False, Txt_Impresora.Text, _Subtido)

                If Chk_ImprimirCedible.Checked AndAlso _Mensaje.EsCorrecto Then
                    Fx_Imprimir_Documento2(_Idmaeedo, _Tido, _Nudo, _NombreFormato, True, False, False, Txt_Impresora.Text, _Subtido)
                End If

                _Lista.Add(_Mensaje)

            End If

        Next

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

        Me.Refresh()

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
End Class
