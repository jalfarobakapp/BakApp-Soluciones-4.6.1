Imports DevComponents.DotNetBar

Public Class Frm_ImpBarras_EdicionEtiquetas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Dim _Row_Etiqueta As DataRow
    Dim _Color_Selection As Color = Color.Black
    Dim _Semilla As Integer

    Public Property Grabar As Boolean

    Public Sub New(_Semilla As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar1)

        Me._Semilla = _Semilla

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Tbl_DisenoBarras Where Semilla = " & _Semilla
        _Row_Etiqueta = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Private Sub Frm_ImpBarras_EdicionEtiquetas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CmbCantPorLinea.Text = 1

        If Not IsNothing(_Row_Etiqueta) Then

            TxtFuncion.Text = _Row_Etiqueta.Item("FUNCION")
            TxtNombreEtiqueta.Text = _Row_Etiqueta.Item("NombreEtiqueta")
            CmbCantPorLinea.Text = _Row_Etiqueta.Item("CantPorLinea")

        End If

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_Mouse_Clic_Boton_derecho_Grilla

        Sb_Actualizar_Grilla()

        If Global_Thema = Enum_Themas.Oscuro Then
            _Color_Selection = Color.White
        End If

        TxtFuncion.SelectionColor = _Color_Selection
        'Sb_Cambiar_Color(TxtFuncion.TextLength)

        Clipboard.Clear()

    End Sub


#Region "PROCEDIMIENTOS"

#Region "ACTUALIZAR GRILLA FUNCIONES"
    Sub Sb_Actualizar_Grilla()
        Consulta_sql = "SELECT *" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones WHERE Tabla = 'ETIQUETASDEBARRA'" & vbCrLf &
                       "Order by DescripcionTabla"

        With Grilla

            Grilla.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("CodigoTabla").HeaderText = "Función"
            .Columns("CodigoTabla").Visible = True
            .Columns("CodigoTabla").Width = 150
            .Columns("CodigoTabla").DisplayIndex = 0

            .Columns("NombreTabla").HeaderText = "Descripción"
            .Columns("NombreTabla").Visible = True
            .Columns("NombreTabla").Width = 390
            .Columns("NombreTabla").DisplayIndex = 1

            For Each _Fila As DataGridViewRow In .Rows
                _Fila.Cells("CodigoTabla").Style.ForeColor = Color.Blue
            Next

        End With

    End Sub
#End Region


#Region "CAMBIAR COLOR DE PALABRA EN TEXTO"

    Sub Sb_Cambiar_Color(ByVal _Posicion As Integer)

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Fx As String = Trim(_Fila.Cells("CodigoTabla").Value)

            _Fx = QuitaEspacios_ParaCodigos(_Fx, Len(_Fx))

            Dim _Ccolor As Color

            If Global_Thema = Enum_Themas.Oscuro Then
                _Ccolor = Color.FromArgb(81, 188, 255)
            Else
                _Ccolor = Color.Blue
            End If

            Fx_Cambiar_Color(_Fx, _Ccolor, TxtFuncion, _Posicion)

        Next

        TxtFuncion.SelectionStart = _Posicion
        TxtFuncion.SelectionLength = 0

    End Sub

    Private Function Fx_Cambiar_Color(ByVal _Palabra As String,
                                      ByVal _Color As Color,
                                      ByVal _Texto As DevComponents.DotNetBar.Controls.RichTextBoxEx,
                                      ByVal _Posicion As Long) As Boolean

        Dim _Fx = _Palabra
        Dim _LargoFx = Len(_Fx)

        Dim _Cadena As String = _Texto.Text

        For i = 0 To _Posicion '_Texto.TextLength

            Dim _Resto = TxtFuncion.TextLength - i

            If _Resto > _LargoFx Then
                Dim _Cadena_Extraida = _Cadena.Substring(i, _LargoFx)
                If _Cadena_Extraida = _Fx Then

                    Dim currentFont As System.Drawing.Font = _Texto.SelectionFont
                    Dim newFontStyle As System.Drawing.FontStyle

                    With _Texto
                        .Select(i, _LargoFx)
                        .SelectionColor = _Color
                        '.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, FontStyle.Bold)
                    End With
                    i += 1
                End If
            End If

        Next

    End Function

#End Region

#Region "CLIC DERECHO EN GRILLA"
    Sub Sb_Grilla_Mouse_Clic_Boton_derecho_Grilla(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        'Menu_Contextual.Enabled = False
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    Grilla.ContextMenuStrip = ContextMenuStrip1
                Else
                    Grilla.ContextMenuStrip = Nothing
                End If
            End With
        End If

    End Sub
#End Region

#End Region

    Private Sub Frm_ImpBarras_EdicionEtiquetas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyData = Keys.Control + Keys.Z Then
            TxtFuncion.Undo()
        End If

    End Sub



    Private Sub Mnu_CopiarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_CopiarToolStripMenuItem.Click
        Dim _Columna = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim Copiar = Trim(Grilla.Rows(Grilla.CurrentRow.Index).Cells(_Columna).Value)

        Copiar = QuitaEspacios_ParaCodigos(Copiar, Len(Copiar))

        Clipboard.SetText(Copiar)
    End Sub

    Private Sub Mnu_Tex_CortarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_Tex_CortarToolStripMenuItem.Click
        TxtFuncion.Cut()
    End Sub

    Private Sub Mnu_Tex_CopiarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_Tex_CopiarToolStripMenuItem.Click
        TxtFuncion.Copy()
    End Sub

    Private Sub Mnu_Tex_PegarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_Tex_PegarToolStripMenuItem.Click
        TxtFuncion.Paste()
    End Sub

    Private Sub TxtFuncion_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFuncion.TextChanged
        Return
        Dim _Posicion = TxtFuncion.SelectionStart

        TxtFuncion.SelectionStart = 0
        TxtFuncion.SelectionLength = _Posicion
        TxtFuncion.SelectionColor = _Color_Selection

        'Sb_Cambiar_Color(_Posicion)


    End Sub

    Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click

        If String.IsNullOrEmpty(Trim(TxtNombreEtiqueta.Text)) Then
            MessageBoxEx.Show(Me, "Falta nombre de etiqueta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TxtNombreEtiqueta.Focus()
            Return
        End If

        If CBool(_Semilla) Then

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Tbl_DisenoBarras Set" & vbCrLf &
                           "FUNCION = '" & TxtFuncion.Text & "'" & vbCrLf &
                           ",CantPorLinea = " & CmbCantPorLinea.Text & vbCrLf &
                           "Where Semilla = " & _Semilla

        Else

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Tbl_DisenoBarras Where NombreEtiqueta = '" & TxtNombreEtiqueta.Text & "'" & vbCrLf &
                           "Insert Into " & _Global_BaseBk & "Zw_Tbl_DisenoBarras (NombreEtiqueta,FUNCION,CantPorLinea) VALUES ('" &
                           TxtNombreEtiqueta.Text & "','" & TxtFuncion.Text & "'," & CmbCantPorLinea.Text & ")"

        End If

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then

            Grabar = True
            MessageBoxEx.Show(Me, "Dato actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub
End Class
