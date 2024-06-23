Imports DevComponents.DotNetBar

Public Class Frm_Demonio_04_Conf_Impr_X_Funcionarios

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _TblFuncionarios As DataTable
    Dim _Row_Demonio_Cof_Estacion As DataRow
    Dim _Impresora As String ' Impresora por defecto
    Dim _Grabar As Boolean
    Dim _Tipo_Configuracion As Tipo_Configuracion

    Enum Tipo_Configuracion
        Impresion
        Correo
        Prestashop
        Impresion_Picking
        Impresion_Vale_Transitorio
    End Enum

    Dim _Condicion_Extra As String = String.Empty
    Dim _RowDocumento_Pruebas As DataRow

    Public ReadOnly Property Pro_Grabar() As Boolean
        Get
            Return _Grabar
        End Get
    End Property
    Public Property Pro_Impresora() As String
        Get
            Return _Impresora
        End Get
        Set(ByVal value As String)
            _Impresora = value
        End Set
    End Property
    Public Sub New(ByVal Tipo_Conf As Tipo_Configuracion,
                   ByVal Row_Demonio_Cof_Estacion As DataRow)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Row_Demonio_Cof_Estacion = Row_Demonio_Cof_Estacion
        _Tipo_Configuracion = Tipo_Conf

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Limpiar.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Imp_Picking_03_Funcionarios_VS_Impresoras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla.EditingControlShowing, AddressOf Grilla_EditingControlShowing

        Me.Text = "Configuración de impresión y correos por funcionarios. Formato: " & Trim(_Row_Demonio_Cof_Estacion.Item("NombreDoc"))

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, False, False)

        Sb_Actualizar_Grilla()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _IdPadre = _Row_Demonio_Cof_Estacion.Item("Id")
        Dim _NombreEquipo = _Row_Demonio_Cof_Estacion.Item("NombreEquipo")
        Dim _TipoDoc = _Row_Demonio_Cof_Estacion.Item("TipoDoc")
        Dim _Nombre_Correo = _Row_Demonio_Cof_Estacion.Item("Nombre_Correo")
        Dim _Imprimir, _Correo As Boolean
        Dim _Picking = 0
        Dim _Vale_Transitorio = 0

        Select Case _Tipo_Configuracion

            Case Tipo_Configuracion.Impresion

                _Imprimir = True
                _Correo = False
                _Condicion_Extra = "And Picking = 0 And Vale_Transitorio = 0"

            Case Tipo_Configuracion.Impresion_Picking

                _Imprimir = True
                _Correo = False
                _Condicion_Extra = "And Picking = 1"
                _Picking = 1

            Case Tipo_Configuracion.Impresion_Vale_Transitorio

                _Imprimir = True
                _Correo = False
                _Condicion_Extra = "And Vale_Transitorio = 1"
                _Vale_Transitorio = 1

            Case Tipo_Configuracion.Correo

                _Imprimir = False
                _Correo = True
                _Condicion_Extra = "And Picking = 0 And Vale_Transitorio = 0"

        End Select

        Try

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Filtros_X_Estacion Set Nro_Copias_Impresion = 1 Where Nro_Copias_Impresion = 0"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_Filtros_X_Estacion " & vbCrLf &
                           "(IdPadre,NombreEquipo,TipoDoc,Codigo,Nombre_Funcionario,Nombre_Correo,Picking,Nro_Copias_Impresion,Vale_Transitorio)" & vbCrLf &
                           "Select " & _IdPadre & ",'" & _NombreEquipo & "','" & _TipoDoc & "',KOFU,NOKOFU,'" & _Nombre_Correo & "'," & _Picking & ",1," & _Vale_Transitorio & " From TABFU" &
                           vbCrLf &
                           "Where KOFU Not In (Select Codigo From " & _Global_BaseBk & "Zw_Demonio_Filtros_X_Estacion" & Space(1) &
                           "Where IdPadre = " & _IdPadre & Space(1) & _Condicion_Extra & ")" &
                           vbCrLf & vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_Demonio_Filtros_X_Estacion Set NombreEquipo = '" & _NombreEquipo & Space(1) &
                           "'Where IdPadre = " & _IdPadre & vbCrLf & vbCrLf &
                           "Select Cast(0 as bit) As Chk,* From " & _Global_BaseBk & "Zw_Demonio_Filtros_X_Estacion" & vbCrLf &
                           "Where IdPadre = " & _IdPadre & " And TipoDoc = '" & _TipoDoc & "' And Codigo <> '' " & _Condicion_Extra & " 
                            Order By Codigo"

            _TblFuncionarios = _Sql.Fx_Get_DataTable(Consulta_sql)

            With Grilla

                .DataSource = _TblFuncionarios

                OcultarEncabezadoGrilla(Grilla, True)

                .Columns("Chk").Width = 30
                .Columns("Chk").HeaderText = "Sel"
                .Columns("Chk").Visible = True
                .Columns("Chk").ReadOnly = False

                .Columns("Codigo").Width = 40
                .Columns("Codigo").HeaderText = "Cód"
                .Columns("Codigo").Visible = True

                .Columns("Nombre_Funcionario").Width = 220
                .Columns("Nombre_Funcionario").HeaderText = "Funcionario"
                .Columns("Nombre_Funcionario").Visible = True

                .Columns("Impresora").Width = 180
                .Columns("Impresora").HeaderText = "Impresora"
                .Columns("Impresora").Visible = _Imprimir

                Dim _NomFormato As String

                If _Tipo_Configuracion = Tipo_Configuracion.Impresion Then
                    _NomFormato = "Formato documento"
                End If

                If _Tipo_Configuracion = Tipo_Configuracion.Impresion_Vale_Transitorio Then
                    _NomFormato = "Formato vale transitorio"
                End If

                If _Tipo_Configuracion = Tipo_Configuracion.Impresion_Picking Then
                    _NomFormato = "Formato picking"
                End If

                .Columns("NombreFormato").Width = 180
                .Columns("NombreFormato").HeaderText = _NomFormato
                .Columns("NombreFormato").Visible = _Imprimir

                .Columns("Nro_Copias_Impresion").Width = 50
                .Columns("Nro_Copias_Impresion").HeaderText = "Copias"
                .Columns("Nro_Copias_Impresion").Visible = _Imprimir
                .Columns("Nro_Copias_Impresion").ReadOnly = False

                .Columns("Nombre_Correo").Width = 210
                .Columns("Nombre_Correo").HeaderText = "Nombre Correo SMTP"
                .Columns("Nombre_Correo").Visible = _Correo

                .Columns("Correo_Para").Width = 210
                .Columns("Correo_Para").HeaderText = "Destinatarios"
                .Columns("Correo_Para").Visible = _Correo

                .Columns("NombreFormato_Correo").Width = 180
                .Columns("NombreFormato_Correo").HeaderText = "Formato interno"
                .Columns("NombreFormato_Correo").Visible = _Correo

                .Columns("Para_Maeenmail").Width = 100
                .Columns("Para_Maeenmail").HeaderText = "Maeen Mail?"
                .Columns("Para_Maeenmail").Visible = _Correo
                .Columns("Para_Maeenmail").ReadOnly = False

                .Columns("Usar_CtaSMTP_Funcionario").Width = 100
                .Columns("Usar_CtaSMTP_Funcionario").HeaderText = "Usar mi SMTP?"
                .Columns("Usar_CtaSMTP_Funcionario").Visible = _Correo
                .Columns("Usar_CtaSMTP_Funcionario").ReadOnly = False

            End With

            For Each _Row As DataGridViewRow In Grilla.Rows

                Dim _Impresora = _Row.Cells("Impresora").Value

                If Fx_Validar_Impresora(_Impresora) Then
                    _Row.Cells("Impresora").Style.ForeColor = Verde
                Else
                    If String.IsNullOrEmpty(_Impresora) Then
                        _Row.Cells("Impresora").Style.ForeColor = Verde
                    Else
                        _Row.Cells("Impresora").Value += " (???)"
                        _Row.Cells("Impresora").Style.ForeColor = Rojo
                    End If
                End If

            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click

        Dim _SqlQuery = String.Empty

        Dim _IdPadre = _Row_Demonio_Cof_Estacion.Item("Id")
        Dim _NombreEquipo = _Row_Demonio_Cof_Estacion.Item("NombreEquipo")

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Id = _Fila.Cells("Id").Value

            Dim _CodFuncionario = _Fila.Cells("Codigo").Value
            Dim _Nombre_Funcionario = _Fila.Cells("Nombre_Funcionario").Value
            Dim _Impresora = Trim(Replace(_Fila.Cells("Impresora").Value, "(???)", ""))
            Dim _NombreFormato = _Fila.Cells("NombreFormato").Value
            Dim _Nro_Copias_Impresion = _Fila.Cells("Nro_Copias_Impresion").Value

            Dim _Nombre_Correo = _Fila.Cells("Nombre_Correo").Value
            Dim _Correo_Para = _Fila.Cells("Correo_Para").Value
            Dim _NombreFormato_Correo = _Fila.Cells("NombreFormato_Correo").Value
            Dim _Para_Maeenmail = Convert.ToInt32(_Fila.Cells("Para_Maeenmail").Value)
            Dim _Usar_CtaSMTP_Funcionario = Convert.ToInt32(_Fila.Cells("Usar_CtaSMTP_Funcionario").Value)

            Dim _Impresora_Valida As Boolean

            If String.IsNullOrEmpty(_Impresora) Then
                _Impresora_Valida = True
            Else
                _Impresora_Valida = Fx_Validar_Impresora(_Impresora)
            End If

            If _Impresora_Valida Then

                If Not String.IsNullOrEmpty(_Impresora) Then
                    If String.IsNullOrEmpty(_NombreFormato) Then
                        MessageBoxEx.Show(Me, "Falta asignar formato de impresión en algunos registros", "Validación",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If
                End If

                _SqlQuery += "--" & _CodFuncionario & " - " & _Nombre_Funcionario & vbCrLf & "Update " & _Global_BaseBk & "Zw_Demonio_Filtros_X_Estacion" & Space(1) &
                             "Set" &
                             " Impresora = '" & _Impresora & "'" &
                             ",NombreFormato = '" & _NombreFormato & "'" &
                             ",Nro_Copias_Impresion = " & _Nro_Copias_Impresion &
                             ",Nombre_Correo = '" & _Nombre_Correo & "'" &
                             ",Correo_Para = '" & Replace(_Correo_Para, "'", "''") & "'" &
                             ",NombreFormato_Correo = '" & _NombreFormato_Correo & "'" & Space(1) &
                             ",Para_Maeenmail = '" & _Para_Maeenmail & "'" & Space(1) &
                             ",Usar_CtaSMTP_Funcionario = '" & _Usar_CtaSMTP_Funcionario & "'" & Space(1) &
                             "Where Id = " & _Id & Space(1) & _Condicion_Extra & vbCrLf & vbCrLf
            Else
                MessageBoxEx.Show(Me, "Impresora:(" & _Impresora & ")" & vbCrLf &
                                  "Funcionario:" & _Nombre_Funcionario & vbCrLf &
                                  "No se efectuaran los cambios, debe regularizar esta situación",
                                  "Problema con impresora", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        Next

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery) Then
            _Grabar = True
            Me.Close()
        Else
            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        Sb_Cambiar_Objeto()
    End Sub

    Sub Sb_Cambiar_Objeto(Optional ByVal _Quitar As Boolean = False)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Impresora_Fila As String = _Fila.Cells("Impresora").Value

        Dim _TipoDoc = _Row_Demonio_Cof_Estacion.Item("TipoDoc")

        If _Quitar Then

            _Fila.Cells(_Cabeza).Value = String.Empty
            If _Cabeza = "Impresora" Then
                _Fila.Cells("NombreFormato").Value = String.Empty
            End If
            If _Cabeza = "Correo" Then
                _Fila.Cells("NombreFormato").Value = String.Empty
            End If

        Else

            Select Case _Cabeza

                Case "Impresora"

                    If String.IsNullOrEmpty(_Impresora_Fila) Then
                        _Impresora_Fila = _Impresora
                    End If

                    Dim Fm As New Frm_Seleccionar_Impresoras(_Impresora_Fila)
                    Fm.ShowDialog(Me)

                    If Not String.IsNullOrEmpty(Trim(Fm.Pro_Impresora_Seleccionada)) Then
                        _Fila.Cells(_Cabeza).Value = Fm.Pro_Impresora_Seleccionada
                    End If
                    Fm.Dispose()

                Case "NombreFormato", "NombreFormato_Correo" '"NombreFormato_Picking"

                    If _Cabeza = "NombreFormato" Then

                        If Not Fx_Validar_Impresora(_Impresora_Fila) Then

                            Beep()
                            ToastNotification.Show(Me, "PROBLEMAS CON LA IMPRESORA, REVISE SU CONFIGURACION",
                                                  My.Resources.cross,
                                                   2 * 1000, eToastGlowColor.Red,
                                                   eToastPosition.MiddleCenter)

                        End If

                    End If

                    Dim Fm As New Frm_Seleccionar_Formato(_TipoDoc)
                    If CBool(Fm.Tbl_Formatos.Rows.Count) Then
                        Fm.ShowDialog(Me)
                        If Fm.Formato_Seleccionado Then
                            _Fila.Cells(_Cabeza).Value = Fm.Row_Formato_Seleccionado.Item("NombreFormato")
                        End If
                    Else
                        MessageBoxEx.Show(Me, "No existen formatos adicionales para este documento",
                                          "Validación",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                    Fm.Dispose()

                Case "Nombre_Correo"

                    Dim Fm As New Frm_Correos_SMTP
                    Fm.Pro_Seleccionar = True
                    Fm.ShowDialog(Me)

                    If Fm.Pro_Seleccionado Then
                        _Fila.Cells("Nombre_Correo").Value = Fm.Pro_Row_Fila_Seleccionada.Item("Nombre_Correo")
                    End If
                    Fm.Dispose()

            End Select

        End If

    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

                    Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

                    Dim _Impresora = _Fila.Cells("Impresora").Value
                    Dim _NombreFormato = _Fila.Cells("NombreFormato").Value

                    Select Case _Cabeza

                        Case "Impresora"

                            If Not String.IsNullOrEmpty(_Impresora) Then
                                Btn_Copiar_impresora.Enabled = True
                                Btn_Quitar_Impresora.Enabled = True
                            Else
                                Btn_Copiar_impresora.Enabled = False
                                Btn_Quitar_Impresora.Enabled = False
                            End If

                            If String.IsNullOrEmpty(_Impresora) Or
                               String.IsNullOrEmpty(_NombreFormato) Then
                                Btn_Imprimir_Pagina_Pruebas.Enabled = False
                            Else
                                Btn_Imprimir_Pagina_Pruebas.Enabled = True
                            End If

                            ShowContextMenu(Menu_Contextual_Impresora)

                        Case "NombreFormato", "NombreFormato_Correo" '--"NombreFormato_Picking",

                            If Not String.IsNullOrEmpty(_Impresora) Then
                                ShowContextMenu(Menu_Contextual_Formato)
                            End If

                        Case "Nombre_Correo"

                            ShowContextMenu(Menu_Contextual_Correo)

                    End Select

                End If

            End With

        End If

    End Sub

    Private Sub Btn_Cambiar_Impresora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cambiar_Impresora.Click
        Sb_Cambiar_Objeto()
    End Sub

    Private Sub Btn_Quitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Quitar_Impresora.Click
        Sb_Cambiar_Objeto(True)
    End Sub

    Private Sub Btn_Copiar_impresora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Copiar_impresora.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Impresora = _Fila.Cells("Impresora").Value
        Dim _NombreFormato = _Fila.Cells("NombreFormato").Value

        Dim _Cont = 0
        If Not String.IsNullOrEmpty(_Impresora) Then

            If Fx_Validar_Impresora(_Impresora) Then

                For Each _Row As DataGridViewRow In Grilla.Rows
                    Dim _Chk As Boolean = _Row.Cells("Chk").Value
                    If _Chk Then
                        _Row.Cells("Impresora").Value = _Impresora
                        _Row.Cells("NombreFormato").Value = _NombreFormato
                        _Cont += 1
                    End If
                Next

                Beep()

                If CBool(_Cont) Then
                    ToastNotification.Show(Me, "CONFIGURACION COPIADA CORRECTAMENTE",
                                           Btn_Copiar_impresora.Image,
                                           2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                Else
                    ToastNotification.Show(Me, "NO HAY FILAS SELECCIONADAS", My.Resources.cross,
                                           2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                End If


            Else
                MessageBoxEx.Show(Me, "Revise la configuración de impresoras en su equipo",
                                  "Problemas con esta impresora",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If

    End Sub

    Private Sub Btn_Cambiar_Correo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cambiar_Correo.Click
        Sb_Cambiar_Objeto()
    End Sub

    Private Sub Btn_Quitar_Correo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Quitar_Correo.Click
        Sb_Cambiar_Objeto(True)
    End Sub

    Private Sub Btn_Cambiar_Formato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cambiar_Formato.Click
        Sb_Cambiar_Objeto()
    End Sub

    Private Sub Btn_Quitar_Formato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Quitar_Formato.Click
        Sb_Cambiar_Objeto(True)
    End Sub

    Private Sub ChkSeleccionar_CheckedChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles ChkSeleccionar.CheckedChanged

        Dim chk As Boolean = ChkSeleccionar.Checked

        For Each _Fila As DataGridViewRow In Grilla.Rows
            _Fila.Cells("Chk").Value = chk
        Next

        Grilla.CurrentCell = Grilla.Rows(0).Cells("Codigo")

    End Sub

    Private Sub Btn_Imprimir_Pagina_Pruebas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir_Pagina_Pruebas.Click

        Dim _IdMaeedo As String
        Dim _Tido = _Row_Demonio_Cof_Estacion.Item("TipoDoc")

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Impresora = _Fila.Cells("Impresora").Value
        Dim _NombreFormato = _Fila.Cells("NombreFormato").Value

        If Not (_RowDocumento_Pruebas Is Nothing) Then

            Dim _Nudo = _RowDocumento_Pruebas.Item("NUDO")

            Dim _Consulta = MessageBoxEx.Show(Me, "¿Desea utilizar el mismo documento para imprimir?" & vbCrLf &
                                              "Documento: " & _Tido & "-" & _Nudo, "Imprimir", MessageBoxButtons.YesNoCancel)

            If _Consulta = Windows.Forms.DialogResult.Yes Then
                'True
            ElseIf _Consulta = Windows.Forms.DialogResult.No Then
                _RowDocumento_Pruebas = Nothing
            Else
                Return
            End If

        End If

        If (_RowDocumento_Pruebas Is Nothing) Then
            Dim _Fm As New Frm_BusquedaDocumento_Filtro(False)
            With _Fm

                .Grupo_Funcionario.Enabled = False
                .Rdb_Funcionarios_Uno.Checked = False
                .Pro_Sql_Filtro_Documentos_Extra =
                "And TIDO = '" & _Tido & "'" 'IN (Select TipoDoc From " & _Global_BaseBk & "Zw_Picking_Doc Where Imprimir = 1)"
                .Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado
                .Rdb_Tipo_Documento_Uno.Checked = True
                '.Pro_Sql_Filtro_Otro_Filtro = "And IDMAEEDO Not In (Select Id_Doc_As From " & _Global_BaseBk & "Zw_Vales_Enc)"
                '.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado, _
                '                     _Tido, "WHERE TIDO IN (Select TipoDoc From " & _Global_BaseBk & "Zw_Picking_Doc Where Imprimir = 1)")
                .Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado,
                                     _Tido, "WHERE TIDO = '" & _Tido & "'")

                .Rdb_Estado_Todos.Checked = True
                .Rdb_Funcionarios_Todos.Checked = True
                .Grupo_Funcionario.Enabled = False
                .Rdb_Fecha_Emision_Desde_Hasta.Checked = True
                .ShowDialog(Me)

                _RowDocumento_Pruebas = .Pro_Row_Documento_Seleccionado
                .Dispose()
            End With
        End If


        If Not (_RowDocumento_Pruebas Is Nothing) Then

            _IdMaeedo = _RowDocumento_Pruebas.Item("IDMAEEDO")

            Dim _Impresion_Pruebas = Fx_Enviar_A_Imprimir_Documento(Me, _NombreFormato, _IdMaeedo, True,
                                                                    False, _Impresora, False, 0, False, "")

            If Not String.IsNullOrEmpty(_Impresion_Pruebas) Then
                MessageBoxEx.Show(Me, _Impresion_Pruebas, "Problema",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Else
            Return
        End If

    End Sub


    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click

        Dim _tBL = _TblFuncionarios

        Dim _Cont = 0
        For Each _Row As DataGridViewRow In Grilla.Rows
            Dim _Chk As Boolean = _Row.Cells("Chk").Value
            If _Chk Then
                Select Case _Tipo_Configuracion
                    Case Tipo_Configuracion.Impresion, Tipo_Configuracion.Impresion_Picking
                        _Row.Cells("Impresora").Value = String.Empty
                        _Row.Cells("NombreFormato").Value = String.Empty
                        _Row.Cells("Nro_Copias_Impresion").Value = 1
                        _Row.Cells("Impresora").Style.ForeColor = Verde
                    Case Tipo_Configuracion.Correo
                        _Row.Cells("Correo_Para").Value = String.Empty
                        _Row.Cells("Nombre_Correo").Value = String.Empty
                        _Row.Cells("NombreFormato_Correo").Value = String.Empty
                        _Row.Cells("Para_Maeenmail").Value = False
                        _Row.Cells("Usar_CtaSMTP_Funcionario").Value = False
                End Select

                _Cont += 1
            End If
        Next

        Beep()

        If CBool(_Cont) Then
            ToastNotification.Show(Me, "FILAS LIMPIAS",
                                   Btn_Limpiar.Image,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
        Else
            ToastNotification.Show(Me, "NO HAY FILAS SELECCIONADAS", My.Resources.cross,
                                   2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
        End If


    End Sub

    Private Sub Grilla_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEndEdit

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If _Cabeza = "Nro_Copias_Impresion" Then

            Dim _Nro_Copias_Impresion = _Fila.Cells("Nro_Copias_Impresion").Value

            If _Nro_Copias_Impresion <= 0 Then
                Beep()
                _Fila.Cells("Nro_Copias_Impresion").Value = 1
            Else
                If _Nro_Copias_Impresion > 2 Then

                    If MessageBoxEx.Show(Me, "¿Está seguro de querer imprimir más de 2 copias?",
                                         "Copias de impresión",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning) <> Windows.Forms.DialogResult.Yes Then

                        _Fila.Cells("Nro_Copias_Impresion").Value = 1

                    End If

                End If
            End If

        End If

    End Sub

    Private Sub Grilla_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
        Dim Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If Cabeza = "Nro_Copias_Impresion" Then
            ' referencia a la celda  
            Dim validar As TextBox = CType(e.Control, TextBox)
            ' agregar el controlador de eventos para el KeyPress  
            AddHandler validar.KeyPress, AddressOf Validar_Keypress_Nros_Grilla
        End If
    End Sub

    Private Sub Grilla_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grilla.MouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Btn_Destinatarios_Click(sender As Object, e As EventArgs) Handles Btn_Destinatarios.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Correo_Para As String = Replace(NuloPorNro(_Fila.Cells("Correo_Para").Value, ""), "''", "'")

        Dim _Tbl_Destinatarios As DataTable

        If Not String.IsNullOrEmpty(_Correo_Para) Then
            Consulta_sql = "Select Cast(1 As Bit) As Chk,KOFU As Codigo,NOKOFU As Descripcion 
                            From TABFU
                            Where KOFU In " & _Correo_Para
            _Tbl_Destinatarios = _Sql.Fx_Get_DataTable(Consulta_sql)
        End If


        Dim _Sql_Filtro_Condicion_Extra = "And INACTIVO = 0 And KOFU IN (Select KOFU From TABFUEM Where EMPRESA = '" & ModEmpresa & "')"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Destinatarios,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra,
                               Nothing, False, False) Then

            _Tbl_Destinatarios = _Filtrar.Pro_Tbl_Filtro

            _Correo_Para = Generar_Filtro_IN(_Tbl_Destinatarios, "Chk", "Codigo", False, True, "'")
            _Fila.Cells("Correo_Para").Value = _Correo_Para

        End If

    End Sub

    Private Sub Btn_Copiar_Correos_Click(sender As Object, e As EventArgs) Handles Btn_Copiar_Correos.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Nombre_Correo = _Fila.Cells("Nombre_Correo").Value
        Dim _Correo_Para = _Fila.Cells("Correo_Para").Value
        Dim _NombreFormato_Correo = _Fila.Cells("NombreFormato_Correo").Value
        Dim _Para_Maeenmail = _Fila.Cells("Para_Maeenmail").Value
        Dim _Usar_CtaSMTP_Funcionario = _Fila.Cells("Usar_CtaSMTP_Funcionario").Value

        Dim _Cont = 0

        For Each _Row As DataGridViewRow In Grilla.Rows

            Dim _Chk As Boolean = _Row.Cells("Chk").Value

            If _Chk Then

                _Row.Cells("Nombre_Correo").Value = _Nombre_Correo
                _Row.Cells("Correo_Para").Value = _Correo_Para
                _Row.Cells("NombreFormato_Correo").Value = _NombreFormato_Correo
                _Row.Cells("Para_Maeenmail").Value = _Para_Maeenmail
                _Row.Cells("Usar_CtaSMTP_Funcionario").Value = _Usar_CtaSMTP_Funcionario

                _Cont += 1

            End If

        Next

        Beep()

        If CBool(_Cont) Then
            ToastNotification.Show(Me, "CONFIGURACION COPIADA CORRECTAMENTE",
                                   Btn_Copiar_impresora.Image,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
        Else
            ToastNotification.Show(Me, "NO HAY FILAS SELECCIONADAS", My.Resources.cross,
                                   2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
        End If

    End Sub

End Class
