'Imports Lib_Bakapp_VarClassFunc
Imports System.Text
Imports System.Text.RegularExpressions
'Imports System.Web.Routing
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
'Imports Microsoft.Office.Interop.Word

Public Class Frm_SQL2Excel_Diseno

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Dim _Tbl_Query As DataTable
    Dim _Tbl_Sql_Command As DataTable
    Dim _Row_SQL_Querys As DataRow

    Dim _Tbl_Tablas_Random As DataTable
    Dim _Tbl_Tablas_BakApp As DataTable

    Dim _Grabacion_Realizada As Boolean

    Dim _Sql_Query_Original As String
    Dim _Color_Selection As Color = Color.Black

    Dim _SqlCommandos As SqlCommandos.SqlLscm

    Public Property Pro_Row_SQL_Querys() As DataRow
        Get
            Return _Row_SQL_Querys
        End Get
        Set(value As DataRow)
            _Row_SQL_Querys = value
            Me.Text = "CONSULTA SQL EN LINEA (" & _Row_SQL_Querys.Item("Id") & ")"
            Txt_Nombre_Query.Text = _Row_SQL_Querys.Item("Nombre_Query")
            Txt_Query_SQL.Text = _Row_SQL_Querys.Item("SQL_Query")
            _Sql_Query_Original = _Row_SQL_Querys.Item("SQL_Query")

            Rdb_Consulta_Global.Checked = _Row_SQL_Querys.Item("Consulta_Global")
            Rdb_Consulta_Personal.Checked = _Row_SQL_Querys.Item("Consulta_Personal")

        End Set
    End Property
    Public ReadOnly Property Pro_Grabacion_Realizada() As Boolean
        Get
            Return _Grabacion_Realizada
        End Get
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar1)

        _SqlCommandos = New SqlCommandos.SqlLscm

    End Sub

    Private Sub Frm_SQL2Excel_Diseno_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_Mouse_Clic_Boton_derecho_Grilla

        Sb_Actualizar_Grilla()

        Txt_Query_SQL.SelectionStart = 0
        Txt_Query_SQL.SelectionLength = _Txt_Query_SQL.TextLength

        'If Global_Thema = Enum_Themas.Oscuro Then
        '    _Color_Selection = Color.White
        'End If

        'Txt_Query_SQL.SelectionColor = _Color_Selection

        If Global_Thema = Enum_Themas.Oscuro Then
            Txt_Query_SQL.BackColor = Color.White
            Txt_Query_SQL.ForeColor = Color.Black
        End If

        AddHandler Txt_Query_SQL.KeyUp, AddressOf Sb_Txt_Query_SQL_KeyUp
        AddHandler Rdb_Consulta_Global.CheckedChanged, AddressOf Sb_Rdb_Consulta_Global_CheckedChanged

        Txt_Query_SQL.SelectionStart = 0
        Txt_Query_SQL.SelectionLength = Txt_Query_SQL.TextLength

        Sb_Cambiar_Color(0, 0, Txt_Query_SQL.TextLength)

        'Dim tabla As New StringBuilder()

        '' Agregar encabezados de columna
        'tabla.AppendLine("Nombre" & vbTab & "Edad" & vbTab & "País")

        '' Agregar filas de datos
        'tabla.AppendLine("Juan" & vbTab & "25" & vbTab & "España")
        'tabla.AppendLine("María" & vbTab & "30" & vbTab & "México")
        'tabla.AppendLine("Carlos" & vbTab & "28" & vbTab & "Argentina")

        '' Insertar la tabla en el RichTextBox
        'Txt_Query_SQL.Text = tabla.ToString()

    End Sub

    Function Fx_Revisar_Consulta_Sin_Modificaciones_En_Tablas_del_Sistema(_Consulta_SQL As String) As Boolean

        Dim _BdBakApp = Replace(_Global_BaseBk, ".dbo.", "")

        Consulta_sql = "SELECT DISTINCT TABLE_NAME FROM " & _BdBakApp & ".INFORMATION_SCHEMA.COLUMNS"
        _Tbl_Tablas_Random = _Sql.Fx_Get_DataTable(Consulta_sql)

        Consulta_sql = "SELECT DISTINCT TABLE_NAME FROM INFORMATION_SCHEMA.COLUMNS"
        _Tbl_Tablas_Random = _Sql.Fx_Get_DataTable(Consulta_sql)

        _Consulta_SQL = UCase(_Consulta_SQL)

        Dim _Cuenta_Update = 0
        Dim _Cuenta_Delete = 0
        Dim _Cuenta_Insert_Into = 0
        Dim _Cuenta_Drop_Table = 0
        Dim _Cuenta_Truncate = 0
        Dim _Cuenta_Alter = 0

        For Each _Fila As DataRow In _Tbl_Tablas_Random.Rows

            Dim _Tabla = _Fila.Item("TABLE_NAME")

            Dim _Update = UCase("UPDATE " & _Tabla)
            Dim _Delete = UCase("DELETE " & _Tabla)
            Dim _Inser_Into = UCase("INSERT INTO " & _Tabla)
            Dim _Drop_Table = UCase("DROP TABLE " & _Tabla)
            Dim _Truncate = UCase("TRUNCATE " & _Tabla)
            Dim _Alter_Table = UCase("ALTER TABLE " & _Tabla)

            If _Consulta_SQL.ToString.Contains(_Update) Then Return False
            If _Consulta_SQL.ToString.Contains(_Delete) Then Return False
            If _Consulta_SQL.ToString.Contains(_Inser_Into) Then Return False
            If _Consulta_SQL.ToString.Contains(_Drop_Table) Then Return False
            If _Consulta_SQL.ToString.Contains(_Truncate) Then Return False
            If _Consulta_SQL.ToString.Contains(_Alter_Table) Then Return False

        Next

        Return True

    End Function

    'Function Fx_Ejecutar_Comsulta_SQL() As DataTable

    '    If Not _Sql.Ej_consulta_IDU(Txt_Query_SQL.Text, False) Then
    '        MessageBoxEx.Show(Me, _Sql.Pro_Error, "ERROR EN LA CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '        Return Nothing
    '    Else
    '        Fx_Ejecutar_Comsulta_SQL = _Sql.Fx_Get_DataTable(Txt_Query_SQL.Text)
    '    End If

    'End Function

    Function Fx_Ejecutar_Comsulta_SQL() As DataSet

        If Not _Sql.Ej_consulta_IDU(Txt_Query_SQL.Text, False) Then
            MessageBoxEx.Show(Me, _Sql.Pro_Error, "ERROR EN LA CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return Nothing
        Else
            Fx_Ejecutar_Comsulta_SQL = _Sql.Fx_Get_DataSet(Txt_Query_SQL.Text)
        End If

    End Function

    Private Sub Btn_Ejecutar_Consulta_SQL_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ejecutar_Consulta_SQL.Click

        If Not String.IsNullOrEmpty(Txt_Query_SQL.Text) Then
            If Fx_Revisar_Consulta_Sin_Modificaciones_En_Tablas_del_Sistema(Txt_Query_SQL.Text) Then

                Me.Cursor = Cursors.WaitCursor

                Dim _Ds As DataSet = Fx_Ejecutar_Comsulta_SQL()

                Me.Cursor = Cursors.Default

                If Not (_Ds Is Nothing) Then

                    If _Ds.Tables.Count > 1 Then

                        Dim _Msg = "La consulta generó varias tablas. Por eso, el archivo de Excel tendrá más de una hoja para mostrar los resultados."

                        MessageBoxEx.Show(Me, Fx_AjustarTexto(_Msg, 80), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                    ExportarTabla_JetExcel_DataSet(_Ds, Me, "Consulta_SQL_personalizada")

                End If

            Else

                Dim info As New TaskDialogInfo("CONSULTA SQL PERSONALIZADA",
                                eTaskDialogIcon.Stop,
                                "EXISTEN COMANDOS NO AUTORIZADOS EN LA CONSULTA",
                                "LOS COMANDO DE MODIFICACION NO ESTAN PERMITIDOS PARA SER UTILIZADOS EN TABLAS DEL SISTEMA" &
                                vbCrLf & vbCrLf &
                                "COMANDOS: UPDATE, DELETE, INSERT, DROP, TRUNACTE, etc...",
                                eTaskDialogButton.Close _
                                , eTaskDialogBackgroundColor.Red, Nothing, Nothing, Nothing, Nothing, Nothing)
                Dim result As eTaskDialogResult = TaskDialog.Show(info)

            End If
        Else
            MessageBoxEx.Show(Me, "NO HAY DATOS EN LA CONSULTA", "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

#Region "PROCEDIMIENTOS"

#Region "ACTUALIZAR GRILLA FUNCIONES"
    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "SELECT *" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & Space(1) &
                       "WHERE Tabla = 'SQL_COMMAND'" & vbCrLf &
                       "Order by DescripcionTabla"
        _Tbl_Sql_Command = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            Grilla.DataSource = _Tbl_Sql_Command

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("CodigoTabla").HeaderText = "Función"
            .Columns("CodigoTabla").Visible = True
            .Columns("CodigoTabla").Width = 150
            .Columns("CodigoTabla").DisplayIndex = 0

            .Columns("DescripcionTabla").HeaderText = "Descripción"
            .Columns("DescripcionTabla").Visible = True
            .Columns("DescripcionTabla").Width = 390
            .Columns("DescripcionTabla").DisplayIndex = 1

            'For Each _Fila As DataGridViewRow In .Rows
            '    _Fila.Cells("CodigoTabla").Style.ForeColor = Color.Blue
            'Next

        End With

    End Sub
#End Region

#Region "GRABAR"

    'Sub Sb_Grabar()

    'If String.IsNullOrEmpty(Trim(TxtNombreEtiqueta.Text)) Then
    'MessageBoxEx.Show(Me, "Falta nombre de etiqueta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    'TxtNombreEtiqueta.Focus()
    'Return
    'End If

    'Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Tbl_DisenoBarras Where NombreEtiqueta = '" & TxtNombreEtiqueta.Text & "'" & vbCrLf & _
    '"INSERT INTO " & _Global_BaseBk & "Zw_Tbl_DisenoBarras (NombreEtiqueta,FUNCION,CantPorLinea) VALUES ('" & _
    'TxtNombreEtiqueta.Text & "','" & TxtFuncion.Text & "'," & CmbCantPorLinea.Text & ")"
    'If  _Sql.Ej_consulta_IDU(Consulta_Sql) Then
    '_Grabado = True
    'Beep()
    'ToastNotification.Show(Me, "ETIQUETA GUARDADA CORRECTAMENTE", _
    'My.Resources.save, _
    '2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
    'Me.Close()
    'End If

    'End Sub

#End Region

#Region "CAMBIAR COLOR DE PALABRA EN TEXTO"

    Sub Sb_Cambiar_Color(_Posicion_Origen As Long,
                         _Posicion_Desde As Long,
                         _Posicion_Hasta As Long)


        For Each _Fila As SqlCommandos.SqlCm In _SqlCommandos._SqlCm 'Grilla.Rows

            Dim _Fx As String = _Fila.Commando

            _Fx = QuitaEspacios_ParaCodigos(_Fx, Len(_Fx))

            Dim _Tipo As String = _Fila.Tipo
            Dim _Ccolor As Color

            Select Case _Tipo
                Case "PRACTICAS"
                    _Ccolor = Color.Blue
                Case "FUNCION"
                    _Ccolor = Color.FromArgb(253, 65, 253)
                Case "OPERADOR"
                    _Ccolor = Color.Gray
                Case Else
                    _Ccolor = Color.Green
            End Select

            Fx_Cambiar_Color(_Fx, _Ccolor, Txt_Query_SQL, _Posicion_Desde, _Posicion_Hasta)

        Next

        ChangeColorForPrefixComentarios(Txt_Query_SQL, "'", "'", Color.Red)
        ChangeColorForPrefix(Txt_Query_SQL, "--", Color.Green)
        ChangeColorForPrefixComentarios(Txt_Query_SQL, "/*", "*/", Color.Green)


        Txt_Query_SQL.SelectionStart = _Posicion_Origen
        Txt_Query_SQL.SelectionLength = 0



    End Sub

    Private Function Fx_Cambiar_Color(_Palabra As String,
                                      _Color As Color,
                                      _Texto As Object,
                                      _Posicion_Desde As Long,
                                      _Posicion_Hasta As Long) As Boolean

        Dim _Fx = _Palabra
        Dim _LargoFx = Len(_Fx)

        Dim _Cadena As String = _Texto.Text

        'Dim _i = Txt_Query_SQL.GetLineFromCharIndex(_Posicion)
        '_i = _Posicion - _i

        For i = _Posicion_Desde To _Posicion_Hasta '_Texto.TextLength

            Dim _Resto = Txt_Query_SQL.TextLength - i
            If _Resto > _LargoFx Then
                Dim _Cadena_Extraida = _Cadena.Substring(i, _LargoFx)
                If UCase(_Cadena_Extraida) = UCase(_Fx) Then

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

    Sub Sb_CambiacolorConIA()

        Dim targetWords As New List(Of String)()
        targetWords.Add("CAST")
        targetWords.Add("DISTINCT")
        targetWords.Add("IF")
        targetWords.Add("ISNULL")
        targetWords.Add("REPLACE")
        targetWords.Add("SUM")
        Fx_ChangeTextColors(Txt_Query_SQL, targetWords, Color.FromArgb(253, 65, 253))

        targetWords.Clear()
        targetWords.Add("IS NULL")
        targetWords.Add("JOIN")
        targetWords.Add("LEFT")
        targetWords.Add("NOT NULL")
        targetWords.Add("RIGHT")
        Fx_ChangeTextColors(Txt_Query_SQL, targetWords, Color.Gray)

        targetWords.Clear()
        targetWords.Add("CASE")
        targetWords.Add("DELETE")
        targetWords.Add("DROP")
        targetWords.Add("ELSE")
        targetWords.Add("END ")
        targetWords.Add("FROM")
        targetWords.Add("GROUP BY")
        targetWords.Add("INSERT INTO")
        targetWords.Add("INTO")
        targetWords.Add("ON")
        targetWords.Add("ORDER BY")
        targetWords.Add("SELECT")
        targetWords.Add("TABLE")
        targetWords.Add("THEN")
        targetWords.Add("TOP")
        targetWords.Add("UPDATE")
        targetWords.Add("WHEN")
        targetWords.Add("WHERE")
        targetWords.Add("WHIT")
        Fx_ChangeTextColors(Txt_Query_SQL, targetWords, Color.Blue)

    End Sub

    Private Sub Fx_ChangeTextColors(richTextBox As RichTextBox, targetWords As List(Of String), color As Color)

        ' Guardar la posición actual del cursor
        Dim originalSelectionStart As Integer = richTextBox.SelectionStart
        Dim originalSelectionLength As Integer = richTextBox.SelectionLength

        ' Iterar sobre cada palabra objetivo
        For Each word As String In targetWords
            Dim index As Integer = 0

            ' Buscar la palabra en el RichTextBox
            While index < richTextBox.TextLength
                index = richTextBox.Find(word, index, RichTextBoxFinds.None)

                ' Si se encuentra la palabra, cambiar el color
                If index <> -1 Then
                    'richTextBox.SelectionStart = index
                    'richTextBox.SelectionLength = word.Length
                    richTextBox.Select(index, word.Length)
                    richTextBox.SelectionColor = color
                Else
                    Exit While
                End If

                index += word.Length
            End While
        Next

        ' Restaurar la selección original
        richTextBox.SelectionStart = originalSelectionStart
        richTextBox.SelectionLength = originalSelectionLength
        richTextBox.SelectionColor = richTextBox.ForeColor

    End Sub

    Private Sub ChangeColorForPrefix(richTextBox As RichTextBox, prefix As String, color As Color)

        Dim originalSelectionStart As Integer = richTextBox.SelectionStart
        Dim originalSelectionLength As Integer = richTextBox.SelectionLength

        Dim index As Integer = 0

        While index < richTextBox.TextLength

            index = richTextBox.Find(prefix, index, RichTextBoxFinds.None)

            Dim _Contador = 0

            If index <> -1 Then

                Dim _Index2 = index
                Dim _Fin = False
                Dim _Palabra = String.Empty

                Do While Not _Fin
                    _Contador += 1
                    If _Index2 = richTextBox.TextLength Then
                        Exit Do
                    End If
                    Dim _Cadena_Extraida = richTextBox.Text.Substring(_Index2, 1)
                    If _Cadena_Extraida = vbCrLf Or _Cadena_Extraida = vbLf Then
                        _Fin = True
                    Else
                        _Palabra += _Cadena_Extraida
                        _Index2 += 1
                    End If
                Loop

                richTextBox.SelectionStart = index
                richTextBox.SelectionLength = _Contador - 1
                richTextBox.SelectionColor = color

            Else
                Exit While
            End If

            index += _Contador - 1

        End While

        richTextBox.SelectionStart = originalSelectionStart
        richTextBox.SelectionLength = originalSelectionLength
        'richTextBox.SelectionColor = richTextBox.ForeColor

    End Sub

    Private Sub ChangeColorForPrefixComentarios(richTextBox As RichTextBox, prefix As String, prefixFIN As String, color As Color)

        Dim originalSelectionStart As Integer = richTextBox.SelectionStart
        Dim originalSelectionLength As Integer = richTextBox.SelectionLength

        Dim index As Integer = 0
        Dim vB = prefixFIN.Length

        While index < richTextBox.TextLength

            index = richTextBox.Find(prefix, index, RichTextBoxFinds.None)

            Dim _Contador = 0

            If index <> -1 Then

                Dim _Index2 = index
                Dim _Fin = False
                Dim _Palabra = String.Empty

                Do While Not _Fin
                    _Contador += 1
                    If _Index2 = richTextBox.TextLength Then
                        Exit Do
                    End If
                    Dim _Cadena_Extraida
                    Try
                        _Cadena_Extraida = richTextBox.Text.Substring(_Index2, vB)
                    Catch ex As Exception
                        _Cadena_Extraida = prefixFIN
                    End Try

                    If _Cadena_Extraida = prefixFIN And _Index2 <> index Then
                        _Fin = True
                        _Contador += 1
                    Else
                        _Palabra += _Cadena_Extraida
                        _Index2 += 1
                    End If
                Loop

                richTextBox.SelectionStart = index
                richTextBox.SelectionLength = _Contador '- 1
                richTextBox.SelectionColor = color

            Else
                Exit While
            End If

            index += _Contador - 1

        End While

        richTextBox.SelectionStart = originalSelectionStart
        richTextBox.SelectionLength = originalSelectionLength
        'richTextBox.SelectionColor = richTextBox.ForeColor

    End Sub

#End Region

#Region "CLIC DERECHO EN GRILLA"
    Sub Sb_Grilla_Mouse_Clic_Boton_derecho_Grilla(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

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

    Private Sub Mnu_Tex_CortarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Tex_CortarToolStripMenuItem.Click
        Txt_Query_SQL.Cut()
    End Sub

    Private Sub Mnu_Tex_CopiarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Tex_CopiarToolStripMenuItem.Click
        Txt_Query_SQL.Copy()
    End Sub

    Private Sub Mnu_Tex_PegarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Tex_PegarToolStripMenuItem.Click
        Txt_Query_SQL.Paste()

        Dim _Posicion = Txt_Query_SQL.SelectionStart
        Txt_Query_SQL.SelectionStart = Txt_Query_SQL.GetLineFromCharIndex(_Posicion)
        Txt_Query_SQL.SelectionLength = _Txt_Query_SQL.TextLength
        Txt_Query_SQL.SelectionColor = Color.Black

        Sb_Cambiar_Color(_Posicion, Txt_Query_SQL.GetLineFromCharIndex(_Posicion), Txt_Query_SQL.TextLength)
        'AddHandler Txt_Query_SQL.TextChanged, AddressOf Sb_Txt_Query_SQL_KeyUp

    End Sub


    Sub Sb_Buscar_Coincidencia(
        _Texto As String,
        RichTextBox As Object,
        _cColor As Color,
        _BackColor As Color)


        Dim Resultados As MatchCollection
        Dim Palabra As Match

        Try
            ' PAsar el pattern e indicar que ignore las mayúsculas y minúsculas al mosmento de buscar  
            Dim obj_Expresion As New Regex(_Texto.ToString, RegexOptions.IgnoreCase)

            ' Ejecutar el método Matches para buscar la cadena en el texto del control  
            ' y retornar un MatchCollection con los resultados  
            Resultados = obj_Expresion.Matches(RichTextBox.Text)

            ' quitar el coloreado anterior  
            With RichTextBox
                .SelectAll()
                .SelectionColor = Color.Black
            End With

            ' Si se encontraron coincidencias recorre las colección    
            For Each Palabra In Resultados
                With RichTextBox
                    .SelectionStart = Palabra.Index ' comienzo de la selección  
                    .SelectionLength = Palabra.Length ' longitud de la cadena a seleccionar  
                    .SelectionColor = _cColor ' color de la selección  
                    .SelectionBackColor = BackColor
                    Debug.Print(Palabra.Value)
                End With
            Next Palabra

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub Btn_Mant_Comandos_SQL_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mant_Comandos_SQL.Click
        Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Sql_Command,
                                                  Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
        Fm.Pro_Padre_Tabla = "SQL_COMMAND"
        Fm.Pro_Padre_CodigoTabla = ""
        Fm.Text = "SQL"
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Sb_Txt_Query_SQL_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs)

        Dim _Key As Keys = e.KeyValue

        Dim _Posicion = Txt_Query_SQL.SelectionStart
        Dim _Linea As Long = Txt_Query_SQL.GetLineFromCharIndex(_Posicion)


        Select Case _Key
            Case Keys.Up, Keys.Down, Keys.Left, Keys.Right


            Case Keys.Space, Keys.Enter, Keys.Back, Keys.Delete

                'Sb_Cambiar_Color(_Posicion, 0, 0)
                'Return
                Dim _Posicion_Desde As Long = Txt_Query_SQL.TextLength - Txt_Query_SQL.GetLineFromCharIndex(_Posicion) - _Linea
                Dim _Posicion_Hasta As Long = Txt_Query_SQL.TextLength + Txt_Query_SQL.GetLineFromCharIndex(_Posicion) - _Linea '_Posicion 'Txt_Query_SQL.TextLength + 80 'Txt_Query_SQL.GetLineFromCharIndex(_Posicion)

                Dim _Cadena_Extraida
                Dim _Cursor = _Posicion
                Dim _Ok As Boolean
                Dim _Contador = 0

                If String.IsNullOrEmpty(Txt_Query_SQL.Text) Then
                    Txt_Query_SQL.SelectionLength = 1000
                    Txt_Query_SQL.SelectionStart = 0 '_Posicion - _Contador '- _i '_Posicion_Desde 'Txt_Query_SQL.GetLineFromCharIndex(_Posicion)
                    Txt_Query_SQL.SelectionColor = Color.Black

                Else

                    If _Cursor > 0 Then
                        Do

                            If _Cursor = 0 Then Exit Do

                            _Cadena_Extraida = Txt_Query_SQL.Text.Substring(_Cursor - 1, 1)
                            Dim _Fila_Rev As Long = Txt_Query_SQL.GetLineFromCharIndex(_Cursor)

                            If _Fila_Rev < _Linea Or _Fila_Rev = 0 Then
                                _Ok = True
                            Else
                                _Cursor -= 1
                                _Contador += 1
                            End If

                        Loop Until _Ok

                        If _Linea = 0 Then
                            _Posicion_Desde = 0
                        Else
                            _Posicion_Desde = _Posicion - _Contador
                        End If
                        _Posicion_Hasta = _Posicion

                        Txt_Query_SQL.SelectionLength = _Contador
                        Txt_Query_SQL.SelectionStart = _Posicion - _Contador '- _i '_Posicion_Desde 'Txt_Query_SQL.GetLineFromCharIndex(_Posicion)
                        Txt_Query_SQL.SelectionColor = Color.Black
                        Sb_Cambiar_Color(_Posicion, _Posicion_Desde, _Posicion_Hasta)
                    End If

                End If

        End Select

    End Sub

    Private Sub Btn_Guardar_Consulta_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Guardar_Consulta.Click

        If Rdb_Consulta_Personal.Checked Then
            If Not Fx_Tiene_Permiso(Me, "Sql00005") Then
                Return
            End If
        End If

        Sb_Guardar()

    End Sub

    Sub Sb_Guardar()

        Try

            Dim _Grabado As Boolean

            If String.IsNullOrEmpty(Txt_Nombre_Query.Text) Then
                Throw New Exception("FALTA EL NOMBRE DE LA CONSULTA")
            End If


            If String.IsNullOrEmpty(Txt_Query_SQL.Text) Then
                If MessageBoxEx.Show(Me, "NO HAY DATOS EN LA CONSULTA" & vbCrLf & vbCrLf &
                                     "¿Desea guardar de todos modos?", "Validación", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) <> Windows.Forms.DialogResult.Yes Then
                    Return
                End If
            End If


            Dim _Existe_Nombre = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_SQL_Querys",
                                 "Nombre_Query = '" & Trim(Txt_Nombre_Query.Text) & "'"))

            Dim _SQL_Query As String = Trim(Txt_Query_SQL.Text)
            _SQL_Query = Replace(_SQL_Query, "'", "''")


            If (_Row_SQL_Querys Is Nothing) Then

                If _Existe_Nombre Then
                    Throw New Exception("El nombre de la consulta ya existe")
                End If


                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_SQL_Querys (Nombre_Query,SQL_Query,Funcionario,Consulta_Global,Consulta_Personal) Values " & Space(1) &
                "('" & Trim(Txt_Nombre_Query.Text) & "'," & vbCrLf &
                "'" & _SQL_Query & "'" & vbCrLf &
                ",'" & FUNCIONARIO &
                "'," & CInt(Rdb_Consulta_Global.Checked) * -1 & "," & CInt(Rdb_Consulta_Personal.Checked) * -1 & ")"

                _Grabado = _Sql.Ej_consulta_IDU(Consulta_sql)

                If _Grabado Then

                    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_SQL_Querys" & vbCrLf &
                                   "Where Nombre_Query = '" & Trim(Txt_Nombre_Query.Text) & "'"
                    _Row_SQL_Querys = _Sql.Fx_Get_DataRow(Consulta_sql)

                End If

            Else

                If Rdb_Consulta_Global.Checked Then
                    If Not Fx_Tiene_Permiso(Me, "Sql00004") Then
                        Return
                    End If
                End If

                Dim _Id = _Row_SQL_Querys.Item("Id")

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_SQL_Querys Set" & Space(1) &
                               "Nombre_Query = '" & FUNCIONARIO & "_Paso'" & vbCrLf &
                               "Where Id =" & _Id
                _Sql.Ej_consulta_IDU(Consulta_sql)

                _Existe_Nombre = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_SQL_Querys",
                                 "Nombre_Query = '" & Trim(Txt_Nombre_Query.Text) & "'"))

                If _Existe_Nombre Then
                    'Consulta_sql = "Update Zw_SQL_Querys Set" & Space(1) &
                    '               "Nombre_Query = '" & _Row_SQL_Querys.Item("Nombre_Query") & "'" & vbCrLf &
                    '               "Where Id =" & _Id
                    '_Sql.Ej_consulta_IDU(Consulta_sql)
                    Throw New Exception("El nombre de la consulta ya existe")
                End If

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_SQL_Querys" & vbCrLf &
                               "Where Id =" & _Id
                _Row_SQL_Querys = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not (_Row_SQL_Querys Is Nothing) Then
                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_SQL_Querys Set 
                                    Nombre_Query = '" & Txt_Nombre_Query.Text.Trim & "',
                                    SQL_Query = '" & _SQL_Query & "',
                                    Consulta_Global = " & CInt(Rdb_Consulta_Global.Checked) * -1 & ",
                                    Consulta_Personal = " & CInt(Rdb_Consulta_Personal.Checked) * -1 & "
                                    Where Id =" & _Id
                    _Grabado = _Sql.Ej_consulta_IDU(Consulta_sql)
                Else
                    Sb_Guardar()
                    Return
                End If

            End If

            If _Grabado Then
                _Sql_Query_Original = Txt_Query_SQL.Text
                _Grabacion_Realizada = True
                MessageBoxEx.Show(Me, "Datos guardados correctamente", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub Sb_Rdb_Consulta_Global_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Rdb_Consulta_Global.Checked Then
            If Not Fx_Tiene_Permiso(Me, "Sql00004") Then
                Rdb_Consulta_Personal.Checked = True
            End If
        End If
    End Sub

    Private Sub Frm_SQL2Excel_Diseno_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Txt_Query_SQL.Text <> _Sql_Query_Original Then
            Dim _Accion = MessageBoxEx.Show(Me, "¿Desea guardar los Cambios?", "Salir",
                                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If _Accion = Windows.Forms.DialogResult.Yes Then
                Sb_Guardar()
            ElseIf _Accion = Windows.Forms.DialogResult.Cancel Then
                e.Cancel = True
            End If
        End If
    End Sub

End Class

Namespace SqlCommandos

    Enum Tipos
        PRACTICAS
        OPERADOR
        FUNCION
    End Enum

    Class SqlCm

        Public Property Commando As String
        Public Property Tipo As String

    End Class

    Class SqlLscm

        Public Property _SqlCm As List(Of SqlCm)

        Public Sub New()

            _SqlCm = New List(Of SqlCm)

            Fx_LlenarComando("CAST", Tipos.FUNCION)
            Fx_LlenarComando("DISTINCT", Tipos.FUNCION)
            Fx_LlenarComando("IF ", Tipos.FUNCION)
            Fx_LlenarComando("ISNULL", Tipos.FUNCION)
            Fx_LlenarComando("REPLACE", Tipos.FUNCION)
            Fx_LlenarComando("SUM", Tipos.FUNCION)

            Fx_LlenarComando("GETDATE", Tipos.FUNCION)
            Fx_LlenarComando("DATEADD", Tipos.FUNCION)
            Fx_LlenarComando("DATEDIFF", Tipos.FUNCION)
            Fx_LlenarComando("YEAR", Tipos.FUNCION)
            Fx_LlenarComando("ROUND", Tipos.FUNCION)
            Fx_LlenarComando("DATEPART", Tipos.FUNCION)
            Fx_LlenarComando("CONVERT", Tipos.FUNCION)
            Fx_LlenarComando("RTRIM", Tipos.FUNCION)
            Fx_LlenarComando("LTRIM", Tipos.FUNCION)
            Fx_LlenarComando("MONTH", Tipos.FUNCION)
            Fx_LlenarComando("DAY", Tipos.FUNCION)

            Fx_LlenarComando("IN ", Tipos.OPERADOR)
            Fx_LlenarComando("IS NULL ", Tipos.OPERADOR)
            Fx_LlenarComando("INNER ", Tipos.OPERADOR)
            Fx_LlenarComando("JOIN", Tipos.OPERADOR)
            Fx_LlenarComando("LEFT ", Tipos.OPERADOR)
            Fx_LlenarComando("NOT NULL ", Tipos.OPERADOR)
            Fx_LlenarComando("RIGHT ", Tipos.OPERADOR)
            Fx_LlenarComando("AND ", Tipos.OPERADOR)
            Fx_LlenarComando("BETWEEN ", Tipos.OPERADOR)
            Fx_LlenarComando("NOT IN ", Tipos.OPERADOR)
            Fx_LlenarComando("OUTER", Tipos.OPERADOR)
            Fx_LlenarComando("LIKE ", Tipos.OPERADOR)
            Fx_LlenarComando("ID NOT NULL", Tipos.OPERADOR)


            Fx_LlenarComando("CASE ", Tipos.PRACTICAS)
            Fx_LlenarComando("DELETE ", Tipos.PRACTICAS)
            Fx_LlenarComando("DROP", Tipos.PRACTICAS)
            Fx_LlenarComando("ELSE", Tipos.PRACTICAS)
            Fx_LlenarComando("END", Tipos.PRACTICAS)
            Fx_LlenarComando("FROM", Tipos.PRACTICAS)
            Fx_LlenarComando("GROUP BY", Tipos.PRACTICAS)
            Fx_LlenarComando("INSERT", Tipos.PRACTICAS)
            Fx_LlenarComando("INTO", Tipos.PRACTICAS)
            Fx_LlenarComando("AS ", Tipos.PRACTICAS)
            Fx_LlenarComando("ON", Tipos.PRACTICAS)
            Fx_LlenarComando("ORDER BY", Tipos.PRACTICAS)
            Fx_LlenarComando("SELECT", Tipos.PRACTICAS)
            Fx_LlenarComando("TABLE", Tipos.PRACTICAS)
            Fx_LlenarComando("THEN", Tipos.PRACTICAS)
            Fx_LlenarComando("TOP ", Tipos.PRACTICAS)
            Fx_LlenarComando("UPDATE ", Tipos.PRACTICAS)
            Fx_LlenarComando("WHEN", Tipos.PRACTICAS)
            Fx_LlenarComando("WHERE", Tipos.PRACTICAS)
            Fx_LlenarComando("WHIT", Tipos.PRACTICAS)
            Fx_LlenarComando("HAVING", Tipos.PRACTICAS)
            Fx_LlenarComando("DECLARE ", Tipos.PRACTICAS)
            Fx_LlenarComando("DATETIME ", Tipos.PRACTICAS)
            Fx_LlenarComando("DATE ", Tipos.PRACTICAS)
            Fx_LlenarComando("INT", Tipos.PRACTICAS)
            Fx_LlenarComando("VARCHAR", Tipos.PRACTICAS)
            Fx_LlenarComando("CHAR", Tipos.PRACTICAS)
            Fx_LlenarComando("CURSOR ", Tipos.PRACTICAS)
            Fx_LlenarComando("BEGIN ", Tipos.PRACTICAS)
            Fx_LlenarComando("END ", Tipos.PRACTICAS)
            Fx_LlenarComando("WHILE ", Tipos.PRACTICAS)
            Fx_LlenarComando("FOR ", Tipos.PRACTICAS)
            Fx_LlenarComando("SET ", Tipos.PRACTICAS)
            Fx_LlenarComando("DATEFIRST ", Tipos.PRACTICAS)
            Fx_LlenarComando("FLOAT ", Tipos.PRACTICAS)
            Fx_LlenarComando("DESC ", Tipos.PRACTICAS)
            Fx_LlenarComando("PERCENT ", Tipos.PRACTICAS)
            Fx_LlenarComando("DISTINCT ", Tipos.PRACTICAS)


        End Sub

        Function Fx_LlenarComando(_Commando As String, _Tipo As SqlCommandos.Tipos)

            Dim _Sl As New SqlCm
            _Sl.Commando = _Commando
            _Sl.Tipo = _Tipo.ToString
            _SqlCm.Add(_Sl)

        End Function

    End Class

End Namespace
